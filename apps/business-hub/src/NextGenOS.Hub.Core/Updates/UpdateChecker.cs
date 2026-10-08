using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace NextGenOS.Hub.Updates;

public static class UpdateStates
{
    public const string None = "none";
    public const string UpToDate = "up-to-date";
    public const string Ready = "ready";
    public const string Approved = "approved";
    public const string Failed = "failed";
}

/// <summary>What one look found. <see cref="Problem"/> is in plain words for the owner and is only set when <see cref="State"/> is "failed".</summary>
public sealed record UpdateCheckResult(string State, string? Available, string? File, string? Sha256, string? Notes, string? Problem);

/// <summary>
/// Looks for a newer version in the update folder online (hub-latest.json). When there is one it first makes sure GitHub signed it for the project's own release, before downloading
/// anything, then downloads the setup (whole, or in the pieces the folder keeps it in) and checks its size and SHA-256. The setup is kept in the updates folder; <b>nothing is installed here</b>.
/// What is sent: a plain request for two public files, with the program's name and version in the usual "user agent" line, and a time stamp so a cached copy is not read. Nothing of the
/// shop is sent, not even its name.
/// </summary>
public sealed class UpdateChecker(HttpClient http, UpdateSettings trust, string folder, Version current)
{
    private const int MaxTextBytes = 256 * 1024;
    private static readonly TimeSpan TextTimeout = TimeSpan.FromSeconds(30);
    private static readonly TimeSpan SetupTimeout = TimeSpan.FromMinutes(30);

    /// <summary>The line the program names itself with, so the people who run the online folder can see which versions are in use.</summary>
    public string Agent => "SmartRetailPOS-Hub/" + current.ToString(3);

    public async Task<UpdateCheckResult> CheckAsync(DateTimeOffset now, CancellationToken ct)
    {
        try
        {
            return await FindAsync(now, ct);
        }
        catch (HubException e) when (e.Code == "update")
        {
            return Failed(e.Message);
        }
        catch (HttpRequestException e)
        {
            return Failed("The update folder could not be reached: " + e.Message);
        }
        catch (IOException e)
        {
            return Failed("The update could not be kept on this PC: " + e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Failed("The update could not be kept on this PC: " + e.Message);
        }
        catch (OperationCanceledException) when (!ct.IsCancellationRequested)
        {
            return Failed("The update folder did not answer in time.");
        }
    }

    private static UpdateCheckResult Failed(string problem) => new(UpdateStates.Failed, null, null, null, null, problem);

    private async Task<UpdateCheckResult> FindAsync(DateTimeOffset now, CancellationToken ct)
    {
        // A fresh copy each time: the folder is behind a cache.
        var stamp = now.UtcDateTime.ToString("yyyyMMddHHmm", CultureInfo.InvariantCulture);
        var manifest = UpdateManifest.Parse(await GetTextAsync(new Uri(trust.Feed, UpdateManifest.FeedFile + "?check=" + stamp), null, ours: true, ct));
        if (manifest.ParsedVersion <= current)
        {
            DeleteSetups(keep: null);
            return new UpdateCheckResult(UpdateStates.UpToDate, null, null, null, null, null);
        }

        // GitHub's word first, so nothing is downloaded that the project's release did not make.
        var keys = await GetTextAsync(ReleaseStatement.KeysUrl, ReleaseStatement.KeysUrl.Host, ours: false, ct);
        var problem = ReleaseStatement.Check(manifest.Statement, keys, trust.Source, manifest.Audience, manifest.Version);
        if (problem is not null)
            throw new HubException("update", "Version " + manifest.Version + " was not published by the program's own release (" + problem + "), so it was not downloaded.");

        var path = Path.Combine(folder, manifest.File);
        if (!File.Exists(path) || new FileInfo(path).Length != manifest.Size || Sha256Of(path) != manifest.Sha256)
            await DownloadAsync(path, manifest, ct);

        DeleteSetups(keep: manifest.File);
        return new UpdateCheckResult(UpdateStates.Ready, manifest.Version, manifest.File, manifest.Sha256, manifest.Notes, null);
    }

    /// <summary>The SHA-256 of a file, lower-case hex.</summary>
    public static string Sha256Of(string path)
    {
        using var stream = File.OpenRead(path);
        return Convert.ToHexString(SHA256.HashData(stream)).ToLowerInvariant();
    }

    private async Task<string> GetTextAsync(Uri url, string? expectedHost, bool ours, CancellationToken ct)
    {
        using var timeout = CancellationTokenSource.CreateLinkedTokenSource(ct);
        timeout.CancelAfter(TextTimeout);
        using var request = Ask(url, ours);
        using var response = await http.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, timeout.Token);
        Check(response, url, expectedHost);
        await using var body = await response.Content.ReadAsStreamAsync(timeout.Token);
        using var copy = new MemoryStream();
        await CopyAsync(body, copy, MaxTextBytes, timeout.Token);
        return Encoding.UTF8.GetString(copy.ToArray());
    }

    private HttpRequestMessage Ask(Uri url, bool ours)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        if (ours) request.Headers.UserAgent.ParseAdd(Agent);
        return request;
    }

    /// <summary>
    /// The answer must be a success, and (also after any redirect) still come over https, and from <paramref name="expectedHost"/> when one is named: the place that says which key
    /// GitHub signs with is never taken from anywhere else.
    /// </summary>
    private static void Check(HttpResponseMessage response, Uri asked, string? expectedHost)
    {
        if (!response.IsSuccessStatusCode) throw new HubException("update", asked.Host + " answered " + (int)response.StatusCode + " for " + asked.AbsolutePath + ".");
        var final = response.RequestMessage?.RequestUri ?? asked;
        if (final.Scheme != Uri.UriSchemeHttps || (expectedHost is not null && !string.Equals(final.Host, expectedHost, StringComparison.OrdinalIgnoreCase)))
            throw new HubException("update", asked.Host + " sent the answer from somewhere that cannot be trusted, so it was not used.");
    }

    private async Task DownloadAsync(string path, UpdateManifest manifest, CancellationToken ct)
    {
        Directory.CreateDirectory(folder);
        var partial = path + ".part";
        try
        {
            using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(ct))
            {
                timeout.CancelAfter(SetupTimeout);
                await using var file = new FileStream(partial, FileMode.Create, FileAccess.Write, FileShare.None);
                // One file, or the pieces in order: each must have exactly the size the description gives.
                for (var number = 1; number <= manifest.PartCount; number++)
                {
                    var url = new Uri(trust.Feed, manifest.PartName(number));
                    using var request = Ask(url, ours: true);
                    using var response = await http.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, timeout.Token);
                    if (!response.IsSuccessStatusCode) throw new HubException("update", "The setup for version " + manifest.Version + " could not be downloaded (" + (int)response.StatusCode + ").");
                    Check(response, url, null);
                    await using var body = await response.Content.ReadAsStreamAsync(timeout.Token);
                    var expected = manifest.PartLength(number);
                    if (await CopyAsync(body, file, expected, timeout.Token) != expected) throw new HubException("update", Different(manifest));
                }
            }

            if (new FileInfo(partial).Length != manifest.Size || Sha256Of(partial) != manifest.Sha256) throw new HubException("update", Different(manifest));
            if (File.Exists(path)) File.Delete(path);
            File.Move(partial, path);
        }
        finally
        {
            if (File.Exists(partial)) File.Delete(partial);
        }
    }

    private static string Different(UpdateManifest manifest) => "The setup for version " + manifest.Version + " came down different from what was published, so it was not kept.";

    /// <summary>Copies at most <paramref name="limit"/> bytes and returns how many; more than that is refused.</summary>
    private static async Task<long> CopyAsync(Stream from, Stream to, long limit, CancellationToken ct)
    {
        var buffer = new byte[81920];
        long total = 0;
        int read;
        while ((read = await from.ReadAsync(buffer, ct)) > 0)
        {
            total += read;
            if (total > limit) throw new HubException("update", "The update folder sent more than was expected, so it was not kept.");
            await to.WriteAsync(buffer.AsMemory(0, read), ct);
        }
        return total;
    }

    /// <summary>Removes downloaded setups other than <paramref name="keep"/>, and any left half-downloaded.</summary>
    public void DeleteSetups(string? keep)
    {
        if (!Directory.Exists(folder)) return;
        foreach (var path in Directory.EnumerateFiles(folder).Where(p => UpdateManifest.IsKeptSetup(Path.GetFileName(p))).ToList())
        {
            if (string.Equals(Path.GetFileName(path), keep, StringComparison.OrdinalIgnoreCase)) continue;
            try { File.Delete(path); }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* still in use: next time */ }
        }
    }
}
