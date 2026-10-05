using System.Net;
using System.Text.Json;
using SmartRetail.Pos.Core.Owner;

namespace SmartRetail.Pos.Web.Services;

/// <summary>A problem with the owner's live view, in words for the owner.</summary>
public sealed class OwnerViewException : Exception
{
    public OwnerViewException(string message, bool disconnected = false, Exception? inner = null, bool listFull = false, bool refused = false,
        bool notMain = false, bool missing = false)
        : base(message, inner)
    {
        Disconnected = disconnected;
        ListFull = listFull;
        Refused = refused;
        NotMain = notMain;
        Missing = missing;
    }

    /// <summary>The project no longer knows this PC's key: the owner disconnected it on the website.</summary>
    public bool Disconnected { get; }

    /// <summary>The website's waiting list holds as many products as it takes: more are offered once the owner has decided on some.</summary>
    public bool ListFull { get; }

    /// <summary>The project's own function refused what it was given (with its reason as the message), as opposed to not being
    /// reached: the same call will be refused again.</summary>
    public bool Refused { get; }

    /// <summary>Another shop PC is the shop's main PC and does this for the shop (the message names it).</summary>
    public bool NotMain { get; }

    /// <summary>The project's script has no such function: it is older than this app.</summary>
    public bool Missing { get; }
}

/// <summary>This PC's connection, as the project gave it.</summary>
public sealed record OwnerViewConnection(string Key, string ShopId, string ShopName);

/// <summary>A question the owner asked the shop's AI on the website.</summary>
public sealed record OwnerQuestion(string Id, string Question);

/// <summary>What the website's waiting list says about a product: <c>sending</c>, <c>waiting</c> for the owner, <c>published</c> or <c>declined</c>,
/// the two fingerprints of what was offered, the photos it should have, and the ones that have arrived.</summary>
public sealed record SiteProductState(string Product, string State, string Version, string PhotosVersion, IReadOnlyList<string> PhotoKinds, IReadOnlyList<string> Staged);

/// <summary>The answer to offering a product: where it stands, and the photos to send now (none when it needs none).</summary>
public sealed record SiteOfferReply(string State, IReadOnlyList<string> SendPhotos);

/// <summary>What this PC is among the shop's PCs: the main one (which does the shop's work for the owner), or a counter, with the name of
/// the PC that is the main one.</summary>
public sealed record PcRole(bool Main, string? MainLabel);

/// <summary>
/// Talks to the owner's Supabase project, through the functions of <c>cloud/supabase-owner-view.sql</c> that the
/// public key may call: connect this PC with a one-time code, send the figures, take the owner's questions for the
/// shop's AI and give the answers, forget the connection.
/// </summary>
public sealed class OwnerViewClient
{
    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

    private readonly HttpClient _http;

    public OwnerViewClient(HttpClient http) => _http = http;

    public async Task<OwnerViewConnection> ConnectAsync(string projectUrl, string publicKey, string code, string label, CancellationToken ct)
    {
        var reply = await CallAsync(projectUrl, publicKey, "connect_shop_pc", new { p_code = code, p_label = label }, ct).ConfigureAwait(false);
        var key = Text(reply, "key");
        var shop = Text(reply, "shop_id");
        if (key is not { Length: >= 32 } || shop is null)
        {
            throw new OwnerViewException("Supabase answered, but not as the owner view does. Run supabase-owner-view.sql again in its SQL Editor.");
        }

        return new OwnerViewConnection(key, shop, Text(reply, "shop_name") ?? "");
    }

    public Task SendAsync(string projectUrl, string publicKey, string key, OwnerLive live, IReadOnlyList<OwnerDay> days, CancellationToken ct) =>
        CallAsync(projectUrl, publicKey, "send_live_figures", new { p_key = key, p_live = live, p_days = days }, ct);

    /// <summary>Sends one of the weekly screens' reports (the Monday review is <see cref="OwnerReview.Kind"/>), which
    /// replaces the one sent before. A project whose script is older than this app has no such function: it is told to run it again.</summary>
    public Task SendReportAsync(string projectUrl, string publicKey, string key, string kind, object report, CancellationToken ct) =>
        CallAsync(projectUrl, publicKey, "send_shop_report", new { p_key = key, p_kind = kind, p_data = report }, ct, MissingReports);

    public Task DisconnectAsync(string projectUrl, string publicKey, string key, CancellationToken ct) =>
        CallAsync(projectUrl, publicKey, "disconnect_shop_pc", new { p_key = key }, ct);

    /// <summary>The oldest question waiting for the shop's AI, taken by this PC; null when there is none.</summary>
    public async Task<OwnerQuestion?> NextQuestionAsync(string projectUrl, string publicKey, string key, CancellationToken ct)
    {
        var reply = await CallAsync(projectUrl, publicKey, "next_shop_question", new { p_key = key }, ct).ConfigureAwait(false);
        return Text(reply, "id") is { } id && Text(reply, "question") is { } question ? new OwnerQuestion(id, question) : null;
    }

    public Task AnswerAsync(string projectUrl, string publicKey, string key, string questionId, OwnerAnswer answer, CancellationToken ct) =>
        CallAsync(projectUrl, publicKey, "answer_shop_question", new { p_key = key, p_id = questionId, p_answer = answer, p_failed = answer.Failed }, ct);

    /// <summary>What this PC is among the shop's PCs. A project whose script is older than the roles has one PC per shop: this is the main one.</summary>
    public async Task<PcRole> PcRoleAsync(string projectUrl, string publicKey, string key, CancellationToken ct)
    {
        try
        {
            var reply = await CallAsync(projectUrl, publicKey, "get_shop_pc_role", new { p_key = key }, ct).ConfigureAwait(false);
            var main = reply.ValueKind != JsonValueKind.Object || !reply.TryGetProperty("main", out var flag) || flag.ValueKind != JsonValueKind.False;
            return new PcRole(main, main ? null : Text(reply, "main_label"));
        }
        catch (OwnerViewException ex) when (ex.Missing)
        {
            return new PcRole(true, null);
        }
    }

    /// <summary>Makes this PC the shop's main PC; the name of the PC that was the main one, or null.</summary>
    public async Task<string?> ClaimMainPcAsync(string projectUrl, string publicKey, string key, CancellationToken ct)
    {
        var reply = await CallAsync(projectUrl, publicKey, "claim_main_pc", new { p_key = key }, ct, MissingRoles).ConfigureAwait(false);
        return Text(reply, "previous");
    }

    /// <summary>The name of the main PC in the project's refusal ("Another shop PC, "Counter 1", is this shop's main PC…").</summary>
    public static string? MainLabelOf(string message)
    {
        var match = System.Text.RegularExpressions.Regex.Match(message ?? "", "\"([^\"]+)\"");
        return match.Success ? match.Groups[1].Value : null;
    }

    /// <summary>What the owner is told when the project's script does not have the main PC yet.</summary>
    public const string MissingRoles = "Your Supabase project does not know the main PC yet. Run supabase-owner-view.sql in its SQL Editor once more; running it again is safe.";

    /// <summary>What the waiting list holds, by product number.</summary>
    public async Task<IReadOnlyList<SiteProductState>> ProductStatesAsync(string projectUrl, string publicKey, string key, CancellationToken ct)
    {
        var reply = await CallAsync(projectUrl, publicKey, "get_shop_product_states", new { p_key = key }, ct, MissingProducts).ConfigureAwait(false);
        var states = new List<SiteProductState>();
        if (reply.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in reply.EnumerateArray())
            {
                if (Text(item, "product") is { } product && Text(item, "state") is { } state)
                {
                    states.Add(new SiteProductState(product, state, Text(item, "version") ?? "", Text(item, "photos_version") ?? "", Strings(item, "photo_kinds"), Strings(item, "staged")));
                }
            }
        }

        return states;
    }

    /// <summary>Offers a product to the owner's website (it waits there for the owner). The reply says which photos to send.</summary>
    public async Task<SiteOfferReply> OfferProductAsync(string projectUrl, string publicKey, string key, string product, JsonElement data,
        string version, string photosVersion, IReadOnlyList<string> photoKinds, bool again, CancellationToken ct)
    {
        var reply = await CallAsync(projectUrl, publicKey, "send_shop_product",
            new { p_key = key, p_product = product, p_data = data, p_version = version, p_photos_version = photosVersion, p_photo_kinds = photoKinds, p_again = again },
            ct, MissingProducts).ConfigureAwait(false);
        return Text(reply, "state") is { } state
            ? new SiteOfferReply(state, Strings(reply, "send_photos"))
            : throw new OwnerViewException(MissingProducts);
    }

    /// <summary>Sends one photo of an offered product; the answer is the product's state (<c>waiting</c> once the last photo is there).</summary>
    public async Task<string> SendProductPhotoAsync(string projectUrl, string publicKey, string key, string product, string kind, string mime,
        string base64, string photosVersion, CancellationToken ct)
    {
        var reply = await CallAsync(projectUrl, publicKey, "send_shop_product_photo",
            new { p_key = key, p_product = product, p_kind = kind, p_mime = mime, p_content = base64, p_photos_version = photosVersion },
            ct, MissingProducts).ConfigureAwait(false);
        return reply.ValueKind == JsonValueKind.String ? reply.GetString() ?? "" : "";
    }

    /// <summary>Takes back a product that is no longer fit to offer, if the owner has not decided on it.</summary>
    public Task WithdrawProductAsync(string projectUrl, string publicKey, string key, string product, CancellationToken ct) =>
        CallAsync(projectUrl, publicKey, "withdraw_shop_product", new { p_key = key, p_product = product }, ct, MissingProducts);

    /// <summary>The website's categories, as its admin sent them; null until it has.</summary>
    public async Task<SmartRetail.AI.Products.SiteCategoryList?> SiteCategoriesAsync(string projectUrl, string publicKey, string key, CancellationToken ct)
    {
        var reply = await CallAsync(projectUrl, publicKey, "get_site_categories", new { p_key = key }, ct, MissingProducts).ConfigureAwait(false);
        return reply.ValueKind == JsonValueKind.Object ? SmartRetail.AI.Products.SiteCategoryList.Parse(reply.GetRawText()) : null;
    }

    /// <summary>What the owner is told when the project's script does not have the website's waiting list yet.</summary>
    public const string MissingProducts = "Your Supabase project does not have the website's waiting list yet. Run supabase-owner-view.sql in its SQL Editor once more; running it again is safe.";

    /// <summary>What the owner is told when the project's script does not have the weekly reports yet.</summary>
    public const string MissingReports = "Your Supabase project does not have the weekly review yet. Run supabase-owner-view.sql in its SQL Editor once more; running it again is safe.";

    private async Task<JsonElement> CallAsync(string projectUrl, string publicKey, string function, object body, CancellationToken ct, string? whenMissing = null)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, projectUrl + "/rest/v1/rpc/" + function)
        {
            Content = JsonContent.Create(body, options: Json),
        };
        request.Headers.Add("apikey", publicKey);
        if (OwnerViewRules.IsJwt(publicKey))
        {
            // The older keys are tokens and go as the bearer too; the newer publishable keys go in apikey only.
            request.Headers.Authorization = new("Bearer", publicKey);
        }

        HttpResponseMessage response;
        try
        {
            response = await _http.SendAsync(request, ct).ConfigureAwait(false);
        }
        catch (HttpRequestException ex)
        {
            throw new OwnerViewException("Could not reach Supabase. Check the internet connection and the project URL.", inner: ex);
        }
        catch (TaskCanceledException ex) when (!ct.IsCancellationRequested)
        {
            throw new OwnerViewException("Supabase did not answer in time. It will be tried again.", inner: ex);
        }

        using (response)
        {
            var text = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return string.IsNullOrWhiteSpace(text) ? default : JsonDocument.Parse(text).RootElement.Clone();
            }

            throw Problem(response.StatusCode, text, whenMissing);
        }
    }

    /// <summary>Supabase's error, said for the owner. Errors raised by the owner view's own functions are already.
    /// <paramref name="whenMissing"/> is what to say when the function is not in the project: the project has the owner
    /// view but an older script, for the functions added later.</summary>
    internal static OwnerViewException Problem(HttpStatusCode status, string body, string? whenMissing = null)
    {
        string? code = null;
        string? message = null;
        try
        {
            using var json = JsonDocument.Parse(body);
            code = Text(json.RootElement, "code");
            message = Text(json.RootElement, "message");
        }
        catch (JsonException)
        {
        }

        return code switch
        {
            "28000" => new OwnerViewException("This PC was disconnected on the website. Connect it again with a new code.", disconnected: true),
            "P0001" when !string.IsNullOrWhiteSpace(message) => new OwnerViewException(message!.Trim(), listFull: message!.Contains("waiting list is full", StringComparison.Ordinal), refused: true,
                notMain: message!.Contains("is this shop's main PC", StringComparison.Ordinal)),
            "PGRST202" => new OwnerViewException(whenMissing ?? "The owner view is not set up in this Supabase project yet. Run supabase-owner-view.sql in its SQL Editor.", missing: true),
            _ when status is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden =>
                new OwnerViewException("Supabase did not accept the public key. Copy it again from the project's API keys."),
            _ when status == HttpStatusCode.NotFound =>
                new OwnerViewException("No Supabase project answered at that URL. Copy it again from the project's settings."),
            _ => new OwnerViewException($"Supabase could not take the figures ({(int)status}). It will be tried again."),
        };
    }

    private static IReadOnlyList<string> Strings(JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.Array
            ? value.EnumerateArray().Where(item => item.ValueKind == JsonValueKind.String).Select(item => item.GetString() ?? "").ToList()
            : Array.Empty<string>();

    private static string? Text(JsonElement element, string name) =>
        element.ValueKind == JsonValueKind.Object && element.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.String
            ? value.GetString()
            : null;
}
