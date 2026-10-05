using Microsoft.Extensions.Options;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Owner;
using SmartRetail.Pos.Core.Review;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Where the owner's live view stands on this PC.</summary>
public sealed record OwnerViewStatus
{
    public bool Connected { get; init; }
    public string ShopName { get; init; } = "";

    /// <summary>The project's host name, e.g. abcd.supabase.co.</summary>
    public string Project { get; init; } = "";

    public DateTimeOffset? LastSentAt { get; init; }
    public bool Sending { get; init; }

    /// <summary>Why the last try did not work, in words for the owner; null when it did.</summary>
    public string? Problem { get; init; }

    /// <summary>When the Monday review was last sent; null before.</summary>
    public DateTimeOffset? ReviewSentAt { get; init; }

    /// <summary>Why the Monday review could not be sent, in words for the owner; null when it could. The live figures
    /// go on either way.</summary>
    public string? ReviewProblem { get; init; }

    /// <summary>The name of the shop's main PC when this PC is a counter, which sends nothing to the project; null when this PC is the
    /// main one (or the project does not tell).</summary>
    public string? MainPc { get; init; }
}

/// <summary>
/// The owner's live view from this PC. It connects to the owner's Supabase project with a one-time code from the
/// website's Live shop (or the owner's page), then sends the shop's figures (<see cref="OwnerLive"/>,
/// <see cref="OwnerDay"/>) every minute, and within 20 seconds of a new bill. Only figures leave the PC: never a
/// customer's name or phone number. A PC that found no POS database (it shows the demo shop) never sends. Once an hour,
/// when the week turns, and when the owner marks the week as reviewed at the shop, it also sends the Monday review
/// (<see cref="OwnerReview"/>); a project whose script does not have it yet only means the review is not shown. It also
/// answers the questions the owner asks the shop's AI on the website, with the shop's own AI, as Ask AI does.
/// </summary>
public sealed class OwnerViewService
{
    public static readonly TimeSpan SendEvery = TimeSpan.FromMinutes(1);

    /// <summary>Days of history sent after connecting, after each start and every <see cref="HistoryEvery"/>; the
    /// other sends carry the last <see cref="RecentDays"/>, so a bill typed in or corrected for an earlier day shows.</summary>
    public const int HistoryDays = 60;
    public const int RecentDays = 8;
    public static readonly TimeSpan HistoryEvery = TimeSpan.FromHours(1);

    /// <summary>The Fix now list is checked again when the last check is this old, even with nobody at the dashboard.</summary>
    private static readonly TimeSpan FixNowEvery = TimeSpan.FromMinutes(10);

    /// <summary>How long the shop's AI may take over one of the owner's questions.</summary>
    public static readonly TimeSpan AnswerWithin = TimeSpan.FromMinutes(5);

    public const string NoPosToConnect = "This PC did not find the POS database, so it shows the demo shop. Connect the PC where "
        + "the POS runs instead. Live shop on your website opens on any computer.";

    public const string NoPosToSend = "This PC did not find the POS database when Smart Retail POS started, so nothing is sent and "
        + "Live shop keeps the last real figures. Restart Smart Retail POS once the POS works.";

    private readonly AiEnvironment _ai;
    private readonly OwnerViewClient _client;
    private readonly ISecretProtector _protector;
    private readonly ISalesFactsRepository _facts;
    private readonly IInvoiceRepository _invoices;
    private readonly IStockRepository _stock;
    private readonly FixNowService _checks;
    private readonly ReviewService _reviews;
    private readonly DataSourceInfo _source;
    private readonly PosConnectionReport _report;
    private readonly IChatBackend _chat;
    private readonly ShopOptions _shop;
    private readonly TimeProvider _clock;
    private readonly ILogger<OwnerViewService> _log;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private SalesSummary? _sentToday;
    private DateTimeOffset _sentAt;
    private bool _historySent;
    private DateTimeOffset _historySentAt;

    /// <summary>When the Monday review is sent next (UTC ticks; 0 is at once), and for which week it was last sent.
    /// Read and written from the sending and from the review's own change event.</summary>
    private long _reviewDueTicks;
    private DateOnly _reviewWeek;

    public OwnerViewService(AiEnvironment ai, OwnerViewClient client, ISecretProtector protector, ISalesFactsRepository facts,
        IInvoiceRepository invoices, IStockRepository stock, FixNowService checks, ReviewService reviews, DataSourceInfo source,
        PosConnectionReport report, IChatBackend chat, IOptions<ShopOptions> shop, TimeProvider clock, ILogger<OwnerViewService> log)
    {
        _ai = ai;
        _client = client;
        _protector = protector;
        _facts = facts;
        _invoices = invoices;
        _stock = stock;
        _checks = checks;
        _reviews = reviews;
        _source = source;
        _report = report;
        _chat = chat;
        _shop = shop.Value;
        _clock = clock;
        _log = log;
        // A week marked as reviewed at the shop reaches the owner at the next send, not in an hour.
        _reviews.Changed += () => Volatile.Write(ref _reviewDueTicks, 0);
        var settings = Settings;
        Status = settings.IsConnected
            ? new OwnerViewStatus { Connected = true, ShopName = settings.ShopName, Project = Host(settings.ProjectUrl), Problem = HasShopData ? null : NoPosToSend }
            : new OwnerViewStatus();
    }

    public event Action? Changed;

    public OwnerViewStatus Status { get; private set; }

    public OwnerViewSettings Settings => _ai.LoadSettings().OwnerView;

    /// <summary>False when Pos:Mode Auto found no POS database and the app shows the demo shop: the owner's own
    /// computer, or a shop PC whose SQL Server was not ready. Such a PC never sends, since the figures would be the
    /// demo's. The demo chosen on purpose (Pos:Mode Demo) may send, marked as the demo.</summary>
    public bool HasShopData => !(_report.Automatic && !_report.Found);

    /// <summary>Connects this PC with the code Live shop shows, then sends the figures at once.</summary>
    public async Task ConnectAsync(string projectUrl, string publicKey, string code, CancellationToken ct = default)
    {
        var url = OwnerViewRules.ProjectUrl(projectUrl, out var problem) ?? throw new OwnerViewException(problem!);
        var key = OwnerViewRules.PublicKey(publicKey, out problem) ?? throw new OwnerViewException(problem!);
        var oneTime = OwnerViewRules.Code(code) ?? throw new OwnerViewException("Type the 8-letter code from Live shop, like ABCD-EFGH.");
        if (!HasShopData)
        {
            throw new OwnerViewException(NoPosToConnect);
        }

        var connection = await _client.ConnectAsync(url, key, oneTime, Label(), ct).ConfigureAwait(false);
        var protectedKey = _protector.Protect(connection.Key);
        Save(s =>
        {
            s.ProjectUrl = url;
            s.PublicKey = key;
            s.ShopName = connection.ShopName;
            s.ProtectedKey = protectedKey;
            s.ConnectedAt = _clock.GetUtcNow().UtcDateTime;
        });
        _historySent = false;
        _sentToday = null;
        ReviewDueNow();
        Update(new OwnerViewStatus { Connected = true, ShopName = connection.ShopName, Project = Host(url) });
        await SendNowAsync(ct).ConfigureAwait(false);
    }

    /// <summary>Makes this PC the shop's main PC (the owner pressed the button): the PC that was the main one becomes a counter, and this one
    /// sends everything at once. The name of the PC that was the main one, or null.</summary>
    public async Task<string?> MakeMainAsync(CancellationToken ct = default)
    {
        var settings = Settings;
        if (Key(settings) is not { } key)
        {
            throw new OwnerViewException("This PC's key for the owner view could not be read. Connect it again with a new code.");
        }

        string? previous;
        try
        {
            previous = await _client.ClaimMainPcAsync(settings.ProjectUrl, settings.PublicKey, key, ct).ConfigureAwait(false);
        }
        catch (OwnerViewException ex) when (ex.Disconnected)
        {
            Forget(ex.Message);
            throw;
        }

        _historySent = false;
        _sentToday = null;
        ReviewDueNow();
        Update(Status with { MainPc = null });
        await SendNowAsync(ct).ConfigureAwait(false);
        return previous;
    }

    /// <summary>Stops sending and asks the project to forget this PC's key. The project URL and public key stay, to
    /// connect again with a new code.</summary>
    public async Task DisconnectAsync(CancellationToken ct = default)
    {
        var settings = Settings;
        if (Key(settings) is { } key)
        {
            try
            {
                await _client.DisconnectAsync(settings.ProjectUrl, settings.PublicKey, key, ct).ConfigureAwait(false);
            }
            catch (OwnerViewException ex)
            {
                // The owner can still remove it on the website; this PC stops sending either way.
                _log.LogWarning(ex, "The owner view could not forget this PC's key.");
            }
        }

        Forget(null);
    }

    /// <summary>Sends when a minute has passed or today's bills changed. Called every few seconds by
    /// <see cref="OwnerViewWorker"/>.</summary>
    public async Task TickAsync(CancellationToken ct)
    {
        var settings = Settings;
        if (!settings.IsConnected)
        {
            if (Status.Connected)
            {
                Update(new OwnerViewStatus());
            }

            return;
        }

        if (!HasShopData)
        {
            NotSending(settings);
            return;
        }

        var today = DateOnly.FromDateTime(_clock.GetLocalNow().DateTime);
        var seen = await _invoices.GetSalesForDayAsync(today, ct).ConfigureAwait(false);
        if (_historySent && seen == _sentToday && _clock.GetUtcNow() - _sentAt < SendEvery)
        {
            return;
        }

        await SendAsync(settings, seen, ct).ConfigureAwait(false);
    }

    public async Task SendNowAsync(CancellationToken ct = default)
    {
        var settings = Settings;
        if (settings.IsConnected && !HasShopData)
        {
            NotSending(settings);
        }
        else if (settings.IsConnected)
        {
            var seen = await _invoices.GetSalesForDayAsync(DateOnly.FromDateTime(_clock.GetLocalNow().DateTime), ct).ConfigureAwait(false);
            await SendAsync(settings, seen, ct).ConfigureAwait(false);
        }
    }

    /// <summary>Answers the oldest question the owner asked the shop's AI on the website, if there is one: the same AI
    /// and the same care as Ask AI at the shop. False when there was nothing to answer.</summary>
    public async Task<bool> AnswerNextQuestionAsync(CancellationToken ct)
    {
        var settings = Settings;
        if (!settings.IsConnected || !HasShopData || Status.MainPc is not null || Key(settings) is not { } key)
        {
            return false;
        }

        OwnerQuestion? question;
        try
        {
            question = await _client.NextQuestionAsync(settings.ProjectUrl, settings.PublicKey, key, ct).ConfigureAwait(false);
        }
        catch (OwnerViewException)
        {
            // Not reachable now, or disconnected: sending the figures says so, and forgets the connection.
            return false;
        }

        if (question is null)
        {
            return false;
        }

        OwnerAnswer answer;
        using (var limit = CancellationTokenSource.CreateLinkedTokenSource(ct))
        {
            limit.CancelAfter(AnswerWithin);
            try
            {
                var reply = await _chat.AskAsync(question.Question, new Progress<string>(), limit.Token).ConfigureAwait(false);
                answer = OwnerAnswer.From(reply, maskContacts: _ai.LoadSettings().Privacy.MaskContactDetails).Fit();
            }
            catch (OperationCanceledException) when (!ct.IsCancellationRequested)
            {
                answer = OwnerAnswer.Problem("The shop's AI took too long over this question. Ask again, perhaps more simply.");
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _log.LogError(ex, "The shop's AI could not answer the owner's question.");
                answer = OwnerAnswer.Problem("The shop's AI could not answer this time. Ask again in a moment.");
            }
        }

        try
        {
            await _client.AnswerAsync(settings.ProjectUrl, settings.PublicKey, key, question.Id, answer, ct).ConfigureAwait(false);
        }
        catch (OwnerViewException ex)
        {
            // The question is taken again after 10 minutes, and answered then.
            _log.LogWarning(ex, "The answer to the owner's question could not be sent.");
        }

        return true;
    }

    private void NotSending(OwnerViewSettings settings)
    {
        if (Status.Problem != NoPosToSend || !Status.Connected)
        {
            Update(new OwnerViewStatus { Connected = true, ShopName = settings.ShopName, Project = Host(settings.ProjectUrl), Problem = NoPosToSend });
        }
    }

    private async Task SendAsync(OwnerViewSettings settings, SalesSummary seen, CancellationToken ct)
    {
        await _gate.WaitAsync(ct).ConfigureAwait(false);
        try
        {
            if (!HasShopData)
            {
                // Never the demo's figures in place of the shop's.
                return;
            }

            var key = Key(settings);
            if (key is null)
            {
                Update(Status with { Problem = "This PC's key for the owner view could not be read. Connect it again with a new code." });
                return;
            }

            // A shop's PCs keep their own photos and decisions, so only its main PC sends: a counter says so and leaves it to the main one.
            var role = await _client.PcRoleAsync(settings.ProjectUrl, settings.PublicKey, key, ct).ConfigureAwait(false);
            if (!role.Main)
            {
                _sentToday = seen;
                _sentAt = _clock.GetUtcNow();
                Update(Status with { Connected = true, ShopName = settings.ShopName, Project = Host(settings.ProjectUrl), Sending = false, Problem = null, MainPc = role.MainLabel ?? "another PC" });
                return;
            }

            Update(Status with { Connected = true, ShopName = settings.ShopName, Project = Host(settings.ProjectUrl), Sending = true, MainPc = null });
            var now = _clock.GetLocalNow();
            var full = !_historySent || _clock.GetUtcNow() - _historySentAt >= HistoryEvery;
            var (live, days) = await BuildAsync(now, full, ct).ConfigureAwait(false);
            await _client.SendAsync(settings.ProjectUrl, settings.PublicKey, key, live, days, ct).ConfigureAwait(false);
            if (full)
            {
                _historySentAt = _clock.GetUtcNow();
            }

            _historySent = true;
            _sentToday = seen;
            _sentAt = _clock.GetUtcNow();
            Update(Status with { Sending = false, LastSentAt = now, Problem = null });
            await SendReviewIfDueAsync(settings, key, now, ct).ConfigureAwait(false);
        }
        catch (OwnerViewException ex) when (ex.Disconnected)
        {
            _log.LogWarning("The owner view says this PC was disconnected on the website.");
            Forget(ex.Message);
        }
        catch (OwnerViewException ex) when (ex.NotMain)
        {
            // Another PC was made the main one since this PC asked.
            Update(Status with { Sending = false, Problem = null, MainPc = OwnerViewClient.MainLabelOf(ex.Message) ?? "another PC" });
        }
        catch (OwnerViewException ex)
        {
            Update(Status with { Sending = false, Problem = ex.Message });
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _log.LogError(ex, "Sending the owner view failed.");
            Update(Status with { Sending = false, Problem = "The shop's figures could not be read from the POS. It will be tried again." });
        }
        finally
        {
            _gate.Release();
        }
    }

    /// <summary>The figures as they stand at <paramref name="now"/>: the live view, and the days for the history
    /// (the last <see cref="HistoryDays"/> when <paramref name="full"/>, else the last <see cref="RecentDays"/>).</summary>
    internal async Task<(OwnerLive Live, IReadOnlyList<OwnerDay> Days)> BuildAsync(DateTimeOffset now, bool full, CancellationToken ct)
    {
        var today = DateOnly.FromDateTime(now.DateTime);
        var range = DateRange.Ending(today, full ? HistoryDays : RecentDays);
        var facts = await _facts.GetFactsAsync(range, ct).ConfigureAwait(false);
        var names = (await _facts.GetProductsAsync(ct).ConfigureAwait(false))
            .GroupBy(p => p.Id)
            .ToDictionary(g => g.Key, g => g.First().Name);
        var times = await _facts.GetBillTimesAsync(new DateRange(today.AddDays(-7), today), ct).ConfigureAwait(false);
        var figures = TodayFigures.From(now.DateTime,
            facts.Days.Select(d => new TrendPoint(d.Day, d.Sales, d.Bills, 0m)),
            times.Where(t => t.Day == today || t.Day == today.AddDays(-7)).ToList());
        var bills = await _invoices.SearchAsync(new BillQuery { From = today, To = today, Take = OwnerLive.MaxBills }, ct).ConfigureAwait(false);
        var findings = (_checks.Last is { } checkedLast && now.DateTime - checkedLast.CheckedAt < FixNowEvery
            ? checkedLast
            : await _checks.CheckAsync(ct: ct).ConfigureAwait(false)).Open;

        var live = OwnerLive.From(new OwnerLiveInputs
        {
            ShopName = _shop.Name.Length > 0 ? _shop.Name : Settings.ShopName,
            Demo = _source.IsDemo,
            Now = now,
            Figures = figures,
            CreditToday = facts.Days.Where(d => d.Day == today).Sum(d => d.Outstanding),
            TodaysBills = bills.Items,
            TodaysProducts = facts.ProductDays.Where(p => p.Day == today).ToList(),
            ProductNames = names,
            LowStock = await _stock.GetLowStockAsync(OwnerLive.MaxLowStock, ct).ConfigureAwait(false),
            FixNow = findings,
        });
        var days = OwnerDay.From(facts, names);
        return (live, days);
    }

    /// <summary>Sends the Monday review when it is due: an hour after the last send (ten minutes after a failed try), when
    /// the week turned, or when the owner marked the week as reviewed at the shop. A review that cannot be sent never
    /// stops the live figures: the owner is told why in Settings, and a disconnected PC is dealt with by the caller.</summary>
    private async Task SendReviewIfDueAsync(OwnerViewSettings settings, string key, DateTimeOffset now, CancellationToken ct)
    {
        var week = ReviewWeeks.LastWeek(DateOnly.FromDateTime(now.DateTime));
        var due = now.UtcTicks >= Volatile.Read(ref _reviewDueTicks);
        var weekTurned = _reviewWeek != default && week.From != _reviewWeek;
        if (!due && !weekTurned)
        {
            return;
        }

        // This week has its try now; a try that fails is repeated by the clock (ten minutes), not at every send.
        _reviewWeek = week.From;
        try
        {
            var data = await _reviews.LoadAsync(ct, judgeDue: false).ConfigureAwait(false);
            var review = OwnerReview.From(new OwnerReviewInputs
            {
                Demo = _source.IsDemo,
                Now = now,
                Week = data.Week,
                ThisWeek = data.ThisWeek,
                WeekBefore = data.WeekBefore,
                YearBefore = data.YearBefore,
                Alerts = data.Alerts,
                ReviewedOn = data.Reviewed is { } reviewed ? DateOnly.FromDateTime(reviewed) : null,
            });
            await _client.SendReportAsync(settings.ProjectUrl, settings.PublicKey, key, OwnerReview.Kind, review, ct).ConfigureAwait(false);
            Volatile.Write(ref _reviewDueTicks, OwnerReview.NextDue(now, sent: true).UtcTicks);
            Update(Status with { ReviewSentAt = now, ReviewProblem = null });
        }
        catch (OwnerViewException ex) when (ex.Disconnected)
        {
            throw;
        }
        catch (OwnerViewException ex)
        {
            Volatile.Write(ref _reviewDueTicks, OwnerReview.NextDue(now, sent: false).UtcTicks);
            Update(Status with { ReviewProblem = ex.Message });
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _log.LogError(ex, "The Monday review could not be worked out for the owner view.");
            Volatile.Write(ref _reviewDueTicks, OwnerReview.NextDue(now, sent: false).UtcTicks);
            Update(Status with { ReviewProblem = "The Monday review could not be read from the POS. It will be tried again." });
        }
    }

    private void ReviewDueNow()
    {
        Volatile.Write(ref _reviewDueTicks, 0);
        _reviewWeek = default;
    }

    /// <summary>This PC's key for the project, for the other things this PC sends the project (the website's products); null when it is
    /// not connected or the key cannot be read.</summary>
    internal string? DeviceKey() => Key(Settings);

    /// <summary>Changes the owner view's settings and keeps them.</summary>
    internal void SaveSettings(Action<OwnerViewSettings> change) => Save(change);

    private string? Key(OwnerViewSettings settings)
    {
        if (!settings.IsConnected)
        {
            return null;
        }

        try
        {
            return _protector.Unprotect(settings.ProtectedKey);
        }
        catch (Exception ex) when (ex is System.Security.Cryptography.CryptographicException or FormatException or InvalidOperationException)
        {
            // Saved by another Windows account, or on another PC.
            return null;
        }
    }

    private void Forget(string? problem)
    {
        Save(s =>
        {
            s.ProtectedKey = "";
            s.ShopName = "";
            s.ConnectedAt = null;
        });
        _historySent = false;
        _sentToday = null;
        ReviewDueNow();
        Update(new OwnerViewStatus { Problem = problem });
    }

    private void Save(Action<OwnerViewSettings> change)
    {
        var store = new SettingsStore(_ai.SettingsFile);
        var all = store.Load();
        change(all.OwnerView);
        store.Save(all);
    }

    private void Update(OwnerViewStatus status)
    {
        Status = status;
        Changed?.Invoke();
    }

    private static string Label()
    {
        var label = "Shop PC (" + Environment.MachineName + ")";
        return label.Length <= 60 ? label : label[..60];
    }

    private static string Host(string url) => Uri.TryCreate(url, UriKind.Absolute, out var uri) ? uri.Host : "";
}

/// <summary>Answers the owner's questions for the shop's AI: looks every 5 seconds, and answers one after another.</summary>
public sealed class OwnerQuestionWorker : BackgroundService
{
    private static readonly TimeSpan LookEvery = TimeSpan.FromSeconds(5);

    private readonly OwnerViewService _owner;
    private readonly ILogger<OwnerQuestionWorker> _log;

    public OwnerQuestionWorker(OwnerViewService owner, ILogger<OwnerQuestionWorker> log)
    {
        _owner = owner;
        _log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken).ConfigureAwait(false);
            using var timer = new PeriodicTimer(LookEvery);
            do
            {
                try
                {
                    while (await _owner.AnswerNextQuestionAsync(stoppingToken).ConfigureAwait(false))
                    {
                    }
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    _log.LogError(ex, "Answering the owner's questions failed.");
                }
            }
            while (await timer.WaitForNextTickAsync(stoppingToken).ConfigureAwait(false));
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
        }
    }
}

/// <summary>Keeps the owner's live view up to date: looks every 20 seconds, sends when something changed or a
/// minute has passed.</summary>
public sealed class OwnerViewWorker : BackgroundService
{
    private static readonly TimeSpan LookEvery = TimeSpan.FromSeconds(20);

    private readonly OwnerViewService _owner;
    private readonly ILogger<OwnerViewWorker> _log;

    public OwnerViewWorker(OwnerViewService owner, ILogger<OwnerViewWorker> log)
    {
        _owner = owner;
        _log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            // Let the app finish starting first.
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken).ConfigureAwait(false);
            using var timer = new PeriodicTimer(LookEvery);
            do
            {
                try
                {
                    await _owner.TickAsync(stoppingToken).ConfigureAwait(false);
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    _log.LogWarning(ex, "Could not look at the POS for the owner view.");
                }
            }
            while (await timer.WaitForNextTickAsync(stoppingToken).ConfigureAwait(false));
        }
        catch (OperationCanceledException)
        {
        }
    }
}

/// <summary>Where Windows' DPAPI is missing (the app is tested on Linux), this PC's key is kept in memory only and
/// never written to disk: after a restart the PC must be connected again.</summary>
public sealed class MemorySecretProtector : ISecretProtector
{
    private const string Prefix = "memory:";
    private readonly System.Collections.Concurrent.ConcurrentDictionary<string, string> _secrets = new();

    public string Protect(string plainText)
    {
        var handle = Prefix + Guid.NewGuid().ToString("N");
        _secrets[handle] = plainText;
        return handle;
    }

    public string Unprotect(string protectedValue) => _secrets.TryGetValue(protectedValue, out var plain)
        ? plain
        : throw new System.Security.Cryptography.CryptographicException("This key was kept in memory by an earlier run.");
}
