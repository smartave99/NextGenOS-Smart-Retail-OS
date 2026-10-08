namespace NextGenOS.Hub.Counters;

/// <summary>What the program that hosts the Hub gives the store network. Nothing given means: counter PCs are off, and the licence gives no limit.</summary>
public sealed record NetworkOptions(NetworkRuntime? Runtime = null, Func<int>? DeviceLimit = null);

/// <summary>Where the store network stands, for the owner's screen.</summary>
public sealed record StoreNetworkStatus(
    bool Chosen, int ChosenPort, bool Running, int RunningPort, bool Accepting, bool RestartNeeded, string? Problem,
    string HostName, IReadOnlyList<string> Addresses, IReadOnlyList<string> Urls, string? AuthorityFingerprint, bool AuthorityMade, DateTimeOffset? CertificateEnds);

/// <summary>
/// A store with one main PC and many counter PCs, on the shop's own network. The main PC (this one) keeps all the data. The owner switches counter PCs on or off here; the choice is kept in a
/// small file and read when the Hub starts (the web server cannot start listening while it runs), so switching ON needs a restart of the Hub, while switching OFF stops every counter PC at once.
/// Pairing and the counter PCs are in <see cref="Pairing"/>. Nothing here sends anything outside the shop.
/// </summary>
public sealed class StoreNetwork
{
    private readonly AuditService _audit;
    private readonly string _folder;
    private readonly Security.Access _access;

    public StoreNetwork(Data.HubDb db, IClock clock, AuditService audit, Security.Access access, string dataFolder, NetworkOptions? options)
    {
        _audit = audit;
        _access = access;
        _folder = dataFolder;
        Runtime = options?.Runtime ?? NetworkRuntime.Off();
        var limit = options?.DeviceLimit;
        Pairing = new PairingService(db, clock, audit, access, () => limit?.Invoke() ?? 0, () => Runtime.Accepting);
    }

    public NetworkRuntime Runtime { get; }

    public PairingService Pairing { get; }

    /// <summary>Raised after the owner's choice was saved (so that the web program can end every counter PC's open connections when the choice is OFF).</summary>
    public event Action<bool>? ChoiceChanged;

    /// <summary>The owner's saved choice, read from the file now.</summary>
    public NetworkSettings Saved() => NetworkSettingsFile.Read(_folder);

    public StoreNetworkStatus Status()
    {
        var saved = Saved();
        var r = Runtime;
        // A change of port, or switching on while the Hub is not listening yet, needs a restart. Switching off does not (counter PCs are refused at once).
        var restart = saved.Enabled && (!r.Running || saved.Port != r.Port);
        var urls = r.Running
            ? r.Hosts.Where(h => h is not ("localhost" or "127.0.0.1")).Select(h => "https://" + h + ":" + r.Port).ToList()
            : new List<string>();
        return new StoreNetworkStatus(saved.Enabled, saved.Port, r.Running, r.Port, r.Accepting, restart, saved.Problem ?? r.Problem,
            r.HostName, r.Addresses, urls, r.AuthorityFingerprint, r.Certificates?.AuthorityMade ?? false, r.Certificates?.ServerExpires);
    }

    /// <summary>
    /// Saves the owner's choice. Switching OFF takes effect at once. Switching ON (or changing the port) takes effect when the Hub is started again, and the owner is told so. Throws a
    /// <see cref="HubException"/> with plain words when the port is not allowed or the file cannot be written.
    /// </summary>
    public void Configure(long? userId, bool enabled, int port)
    {
        _access.Require(Security.Perm.Network);
        if (NetworkSettingsFile.CheckPort(port, Runtime.ReservedPorts) is { } problem) throw new HubException("bad-port", problem);
        try
        {
            NetworkSettingsFile.Write(_folder, new NetworkSettings(enabled, port));
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            throw new HubException("not-saved", "The choice could not be saved on this PC (" + ex.Message + "). Nothing was changed.");
        }

        Runtime.Choose(enabled);
        _audit.Log(userId, enabled ? "network.enable" : "network.disable", "network", null,
            enabled ? "Counter PCs may connect on port " + port + " once the Hub has been restarted." : "Counter PCs may no longer connect.");
        ChoiceChanged?.Invoke(enabled);
    }
}
