using System.Net;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The AI settings screen: who may open it, what it says without and with the licence, and that merely looking at it changes nothing.</summary>
public class AiSettingsWebTests
{
    private static HttpClient Client(HubWebFactory factory)
    {
        var http = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = false, HandleCookies = false });
        http.DefaultRequestHeaders.Accept.ParseAdd("text/html");
        return http;
    }

    private static void SetUp(HubWebFactory f)
    {
        f.Hub.Shop.Save(new ShopSettings { Name = "Test Shop", Country = "IN", Region = "27", Industry = "retail", SetupDone = true });
        f.Hub.Users.Create("owner", "Olivia Owner", Roles.Owner, "correct horse battery");
        f.Hub.Users.Create("boss", "Mia Manager", Roles.Manager, "manager good password");
    }

    private static async Task<string> SignIn(HttpClient http, string user, string password)
    {
        var page = await http.GetAsync("/login");
        var html = await page.Content.ReadAsStringAsync();
        var token = Regex.Match(html, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var formName = Regex.Match(html, "name=\"_handler\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var cookies = string.Join("; ", page.Headers.GetValues("Set-Cookie").Select(c => c.Split(';')[0]));
        var request = new HttpRequestMessage(HttpMethod.Post, "/login") { Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["__RequestVerificationToken"] = token, ["_handler"] = formName, ["Username"] = user, ["Password"] = password }) };
        request.Headers.Add("Cookie", cookies);
        var response = await http.SendAsync(request);
        var session = response.Headers.GetValues("Set-Cookie").First(c => c.StartsWith("hub.session=", StringComparison.Ordinal));
        return cookies + "; " + session.Split(';')[0];
    }

    private static async Task<HttpResponseMessage> Get(HttpClient http, string path, string cookie = "")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        if (cookie.Length > 0) request.Headers.Add("Cookie", cookie);
        return await http.SendAsync(request);
    }

    [Fact]
    public async Task The_licence_decides_whether_the_AI_parts_exist_and_opening_the_screen_changes_nothing()
    {
        // The screen is drawn live in the browser (the browser test checks its words); here: what the server decides and keeps.
        foreach (var modules in new[] { new[] { "hub" }, new[] { "hub", "ai" } })
        {
            using var f = new HubWebFactory { Modules = modules };
            SetUp(f);
            var http = Client(f);
            var owner = await SignIn(http, "owner", "correct horse battery");

            var page = await Get(http, "/settings/ai", owner);

            Assert.Equal(HttpStatusCode.OK, page.StatusCode);
            Assert.Equal(modules.Contains("ai"), f.Hub.Ai.Flags.Licensed);
            Assert.All(f.Hub.Ai.Flags.All(), s => { Assert.False(s.Chosen); Assert.False(s.Effective); });
            Assert.Empty(f.Hub.Ai.Providers.List());
            Assert.Empty(f.Hub.Ai.Models.List());
            Assert.Empty(f.Hub.Ai.Usage.Recent());
        }
    }

    [Fact]
    public async Task A_signed_out_person_is_sent_to_sign_in_and_the_manager_is_not_the_owner()
    {
        using var f = new HubWebFactory { Modules = ["hub", "ai"] };
        SetUp(f);
        var http = Client(f);

        var anonymous = await Get(http, "/settings/ai");
        Assert.Equal(HttpStatusCode.Redirect, anonymous.StatusCode);
        Assert.Contains("/login", anonymous.Headers.Location!.OriginalString);

        Assert.True(Roles.Can(Roles.Owner, Perm.Ai));
        Assert.False(Roles.Can(Roles.Manager, Perm.Ai));
        // A manager can sign in; the screen itself says "not for your role" (checked in the browser test), and nothing about the AI is changed by trying.
        var manager = await SignIn(http, "boss", "manager good password");
        await Get(http, "/settings/ai", manager);
        Assert.All(f.Hub.Ai.Flags.All(), s => Assert.False(s.Chosen));
    }

    [Fact]
    public void The_program_asks_the_signed_licence_for_the_AI_part_and_a_licence_that_is_not_usable_allows_nothing()
    {
        var withAi = new NextGenOS.Licensing.AspNetCore.ProductLicence(() => new NextGenOS.Licensing.LicenceState { Status = NextGenOS.Licensing.LicenceStatus.Valid, Licence = new NextGenOS.Licensing.LicenceClaims { Modules = ["hub", "ai"] } });
        var without = new NextGenOS.Licensing.AspNetCore.ProductLicence(() => new NextGenOS.Licensing.LicenceState { Status = NextGenOS.Licensing.LicenceStatus.Valid, Licence = new NextGenOS.Licensing.LicenceClaims { Modules = ["hub"] } });
        var expired = new NextGenOS.Licensing.AspNetCore.ProductLicence(() => new NextGenOS.Licensing.LicenceState { Status = NextGenOS.Licensing.LicenceStatus.Expired, Licence = new NextGenOS.Licensing.LicenceClaims { Modules = ["hub", "ai"] } });
        var missing = new NextGenOS.Licensing.AspNetCore.ProductLicence(() => new NextGenOS.Licensing.LicenceState { Status = NextGenOS.Licensing.LicenceStatus.Missing });
        Assert.True(new NextGenOS.Hub.Web.Auth.LicenceEntitlements(withAi).Has("ai"));
        Assert.False(new NextGenOS.Hub.Web.Auth.LicenceEntitlements(without).Has("ai"));
        Assert.False(new NextGenOS.Hub.Web.Auth.LicenceEntitlements(expired).Has("ai"));
        Assert.False(new NextGenOS.Hub.Web.Auth.LicenceEntitlements(missing).Has("ai"));
    }

    [Fact]
    public async Task The_event_history_screen_is_for_the_owner_and_looking_at_it_records_nothing()
    {
        using var f = new HubWebFactory { Modules = ["hub", "ai"] };
        SetUp(f);
        var http = Client(f);

        var anonymous = await Get(http, "/settings/events");
        Assert.Equal(HttpStatusCode.Redirect, anonymous.StatusCode);
        Assert.Contains("/login", anonymous.Headers.Location!.OriginalString);

        var owner = await SignIn(http, "owner", "correct horse battery");
        Assert.Equal(HttpStatusCode.OK, (await Get(http, "/settings/events", owner)).StatusCode);
        var manager = await SignIn(http, "boss", "manager good password");
        await Get(http, "/settings/events", manager);

        Assert.False(f.Hub.Events.Recording);
        Assert.Equal(new NextGenOS.Hub.Events.EventCounts(0, 0, 0, 0, 0, null, null), f.Hub.Events.Counts());
        Assert.Empty(f.Hub.Audit.Recent().Where(a => a.Action.StartsWith("events.", StringComparison.Ordinal)));
    }

    [Fact]
    public async Task The_background_upkeep_forgets_records_past_their_day_without_any_switch()
    {
        using var f = new HubWebFactory { Modules = ["hub", "ai"] };
        SetUp(f);
        // An observation that is long past its day, and the history switched off: forgetting does not wait for a switch.
        f.Hub.Db.InTransaction((c, t) => NextGenOS.Hub.Data.HubDb.Exec(c,
            "INSERT INTO observations(id, kind, source_type, source_id, confidence, data_class, occurred_at, recorded_at, retain_until) VALUES (1, 'object.detected', 'model', 'cam-1', 1, 'INTERNAL', '2020-01-01T00:00:00Z', '2020-01-01T00:00:00Z', '2020-01-15T00:00:00Z')", t));
        Assert.False(f.Hub.Events.Recording);
        Assert.Equal(1, f.Hub.Events.Counts().Observations);

        // The worker's first round runs as soon as it starts.
        var log = new CapturingLog();
        using var worker = new NextGenOS.Hub.Web.Auth.HubWorker(f.Hub, log);
        await worker.StartAsync(CancellationToken.None);
        // The first round starts by itself (on its own thread); give it a moment.
        for (var i = 0; i < 100 && f.Hub.Events.Counts().Observations > 0; i++) await Task.Delay(50);
        await worker.StopAsync(CancellationToken.None);

        Assert.True(log.Problems.Count == 0, string.Join(" | ", log.Problems));
        Assert.Equal(0, f.Hub.Events.Counts().Observations);
        Assert.Contains(f.Hub.Audit.Recent(), a => a.Action == "events.forgotten");
    }

    private sealed class CapturingLog : Microsoft.Extensions.Logging.ILogger<NextGenOS.Hub.Web.Auth.HubWorker>
    {
        public List<string> Problems { get; } = new();

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel) => true;

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, Microsoft.Extensions.Logging.EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) =>
            Problems.Add(formatter(state, exception) + (exception is null ? "" : ": " + exception.GetType().Name + " " + exception.Message));
    }
}
