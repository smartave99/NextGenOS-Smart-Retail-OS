namespace SmartRetail.Pos.Web.Services;

/// <summary>What the shop PC needs from the owner's Supabase project to offer products to the website.</summary>
public interface IWebsiteSite
{
    /// <summary>What the waiting list holds now.</summary>
    Task<IReadOnlyList<SiteProductState>> StatesAsync(CancellationToken ct);

    /// <summary>Offers a product; the reply says which photos to send.</summary>
    Task<SiteOfferReply> OfferAsync(WebsiteOffer offer, bool again, CancellationToken ct);

    /// <summary>Sends one photo; the answer is the product's state.</summary>
    Task<string> SendPhotoAsync(WebsiteOffer offer, OfferPhoto photo, PreparedPhoto prepared, CancellationToken ct);

    /// <summary>Takes a product off the list (before the owner has decided on it).</summary>
    Task WithdrawAsync(string product, CancellationToken ct);
}

/// <summary>What one round of offering did.</summary>
/// <param name="Offered">Products offered or finished this round.</param>
/// <param name="Photos">Photos sent.</param>
/// <param name="ListFull">The waiting list is full: more are offered once the owner has decided on some.</param>
/// <param name="Problem">Why the round stopped early, in words for the owner; null when it did not.</param>
/// <param name="Failed">Products that could not be offered because of something about the product itself (a photo that cannot be read).</param>
/// <param name="Withdrawn">Products taken off the list because they are no longer fit to offer.</param>
public sealed record WebsiteRound(int Offered, int Photos, bool ListFull, string? Problem, IReadOnlyList<int> Failed, IReadOnlyList<int> Withdrawn);

/// <summary>What to do about a product, given what the waiting list holds.</summary>
public enum OfferPlan
{
    /// <summary>It is on the list as it is now (waiting for the owner, or decided on): nothing to send.</summary>
    UpToDate,

    /// <summary>The owner declined it: it stays declined unless the owner asks for it again at the shop.</summary>
    Declined,

    /// <summary>It is not on the list, something about it changed, or its photos are still on their way.</summary>
    Send,
}

/// <summary>
/// Offers the finished products to the owner's website, a few at a time: the words and prices first, then the photos the waiting
/// list asks for (only the ones it does not have, and none for a product whose price changed). It stops at once when the list is full,
/// when the project says this PC was disconnected, or when Supabase cannot be reached; a product with a photo that cannot be read
/// is left for later and the others go on.
/// </summary>
public sealed class WebsiteSender
{
    /// <summary>Products offered in one round, so one round stays short; the rest follow in the next.</summary>
    public const int PerRound = 3;

    private readonly IWebsiteSite _site;
    private readonly Func<byte[], PreparedPhoto> _prepare;
    private readonly Func<string, byte[]> _read;
    private readonly int _perRound;

    public WebsiteSender(IWebsiteSite site, Func<byte[], PreparedPhoto>? prepare = null, Func<string, byte[]>? read = null, int perRound = PerRound)
    {
        _site = site;
        _prepare = prepare ?? WebsitePhotos.Prepare;
        _read = read ?? File.ReadAllBytes;
        _perRound = perRound;
    }

    public static OfferPlan Plan(WebsiteOffer offer, SiteProductState? onList)
    {
        if (onList is null)
        {
            return OfferPlan.Send;
        }

        if (onList.State == "declined")
        {
            return OfferPlan.Declined;
        }

        var same = onList.Version == offer.Version && onList.PhotosVersion == offer.PhotosVersion && onList.PhotoKinds.SequenceEqual(offer.Kinds);
        return same && onList.State != "sending" ? OfferPlan.UpToDate : OfferPlan.Send;
    }

    /// <summary>One round: takes back the <paramref name="withdraw"/> products, then offers up to <see cref="PerRound"/> of the
    /// <paramref name="offers"/> the list does not have as they are.</summary>
    public async Task<WebsiteRound> RunAsync(IReadOnlyList<WebsiteOffer> offers, IReadOnlyList<SiteProductState> onList,
        IReadOnlyList<string> withdraw, CancellationToken ct)
    {
        var states = onList.GroupBy(state => state.Product).ToDictionary(group => group.Key, group => group.First());
        var failed = new List<int>();
        var withdrawn = new List<int>();
        int offered = 0, photos = 0;
        try
        {
            foreach (var product in withdraw)
            {
                ct.ThrowIfCancellationRequested();
                await _site.WithdrawAsync(product, ct).ConfigureAwait(false);
                if (int.TryParse(product, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out var id))
                {
                    withdrawn.Add(id);
                }
            }

            foreach (var offer in offers)
            {
                ct.ThrowIfCancellationRequested();
                if (offered >= _perRound)
                {
                    break;
                }

                states.TryGetValue(offer.Key, out var state);
                if (Plan(offer, state) != OfferPlan.Send)
                {
                    continue;
                }

                try
                {
                    photos += await OfferOneAsync(offer, again: false, ct).ConfigureAwait(false);
                    offered++;
                }
                catch (Exception ex) when (ex is InvalidDataException or IOException or UnauthorizedAccessException
                    || ex is OwnerViewException { Refused: true, ListFull: false, Disconnected: false, NotMain: false })
                {
                    // Something about this one product (a photo file that cannot be read, or what the project refuses): the others
                    // go on, and this one is tried again later.
                    failed.Add(offer.ProductId);
                }
            }
        }
        catch (OwnerViewException ex) when (ex.ListFull)
        {
            return new WebsiteRound(offered, photos, true, null, failed, withdrawn);
        }
        catch (OwnerViewException ex) when (!ex.Disconnected)
        {
            return new WebsiteRound(offered, photos, false, ex.Message, failed, withdrawn);
        }

        return new WebsiteRound(offered, photos, false, null, failed, withdrawn);
    }

    /// <summary>Offers a product the owner declined once more, at the owner's wish. Returns the photos sent.</summary>
    public Task<int> OfferAgainAsync(WebsiteOffer offer, CancellationToken ct) => OfferOneAsync(offer, again: true, ct);

    private async Task<int> OfferOneAsync(WebsiteOffer offer, bool again, CancellationToken ct)
    {
        var reply = await _site.OfferAsync(offer, again, ct).ConfigureAwait(false);
        var sent = 0;
        foreach (var kind in reply.SendPhotos)
        {
            ct.ThrowIfCancellationRequested();
            var photo = offer.Photos.FirstOrDefault(p => WebsiteOffers.KindName(p.Kind) == kind)
                ?? throw new InvalidDataException("The waiting list asked for a photo this product does not have.");
            var prepared = _prepare(_read(photo.Path));
            await _site.SendPhotoAsync(offer, photo, prepared, ct).ConfigureAwait(false);
            sent++;
        }

        return sent;
    }
}

/// <summary>The waiting list in the owner's Supabase project, reached with this PC's own key.</summary>
public sealed class SupabaseWebsite : IWebsiteSite
{
    private readonly OwnerViewClient _client;
    private readonly string _url;
    private readonly string _publicKey;
    private readonly string _key;

    public SupabaseWebsite(OwnerViewClient client, string projectUrl, string publicKey, string deviceKey)
    {
        _client = client;
        _url = projectUrl;
        _publicKey = publicKey;
        _key = deviceKey;
    }

    public Task<IReadOnlyList<SiteProductState>> StatesAsync(CancellationToken ct) => _client.ProductStatesAsync(_url, _publicKey, _key, ct);

    public Task<SiteOfferReply> OfferAsync(WebsiteOffer offer, bool again, CancellationToken ct) =>
        _client.OfferProductAsync(_url, _publicKey, _key, offer.Key, WebsiteOffers.DataOf(offer), offer.Version, offer.PhotosVersion, offer.Kinds, again, ct);

    public Task<string> SendPhotoAsync(WebsiteOffer offer, OfferPhoto photo, PreparedPhoto prepared, CancellationToken ct) =>
        _client.SendProductPhotoAsync(_url, _publicKey, _key, offer.Key, WebsiteOffers.KindName(photo.Kind), prepared.Mime, prepared.Base64, offer.PhotosVersion, ct);

    public Task WithdrawAsync(string product, CancellationToken ct) => _client.WithdrawProductAsync(_url, _publicKey, _key, product, ct);
}
