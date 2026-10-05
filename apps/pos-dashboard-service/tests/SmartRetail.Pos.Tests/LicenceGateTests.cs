using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace SmartRetail.Pos.Tests;

/// <summary>Without a usable licence the dashboard serves one page (or one JSON answer) with status 402 and nothing else; with one it is untouched.</summary>
public sealed class LicenceGateTests
{
    private static LicenceState Usable(string? brandName = null, string? colour = null) => new()
    {
        Status = LicenceStatus.Valid,
        Licence = new LicenceClaims
        {
            Modules = ["pos", "ai", "dashboard"],
            Brand = brandName is null ? null : new BrandProfile { Id = "B-7", Name = brandName, PrimaryColor = colour, SupportEmail = "help@example.com" },
        },
    };

    private static LicenceState Unusable(LicenceStatus status = LicenceStatus.Missing) => new() { Status = status };

    /// <summary>The gate with a stand-in dashboard behind it, the way Program.cs builds it.</summary>
    private sealed class Rig
    {
        public Rig(Func<LicenceState> state)
        {
            Licence = new ProductLicence(state, new MovingClock());
            Services = new ServiceCollection().AddSingleton(Licence).AddSingleton<BrandService>().BuildServiceProvider();
            var app = new ApplicationBuilder(Services);
            app.UseLicenceGate();
            app.Run(context =>
            {
                Reached = true;
                return context.Response.WriteAsync("dashboard");
            });
            Pipeline = app.Build();
        }

        public RequestDelegate Pipeline { get; }

        public ProductLicence Licence { get; }

        public IServiceProvider Services { get; }

        public bool Reached { get; private set; }
    }

    [Fact]
    public async Task A_valid_licence_lets_everything_through()
    {
        var rig = new Rig(() => Usable());
        var (status, body, _) = await Send(rig, "/");
        Assert.Equal(200, status);
        Assert.Equal("dashboard", body);
        Assert.True(rig.Reached);
    }

    [Theory]
    [InlineData(LicenceStatus.Missing)]
    [InlineData(LicenceStatus.NotActivated)]
    [InlineData(LicenceStatus.Expired)]
    [InlineData(LicenceStatus.Revoked)]
    [InlineData(LicenceStatus.DeviceMismatch)]
    [InlineData(LicenceStatus.ClockTampered)]
    [InlineData(LicenceStatus.Invalid)]
    [InlineData(LicenceStatus.ModuleNotLicensed)]
    [InlineData(LicenceStatus.NeedsCheckIn)]
    public async Task Any_state_that_is_not_valid_or_grace_shows_the_licence_page_and_nothing_else(LicenceStatus status)
    {
        var rig = new Rig(() => Unusable(status));
        foreach (var path in new[] { "/", "/ask", "/app.css", "/_blazor/negotiate", "/product-photos/1/all.zip" })
        {
            var (code, body, _) = await Send(rig, path);
            Assert.Equal(402, code);
            Assert.Contains("needs a licence", body);
            Assert.DoesNotContain("dashboard", body);
        }

        Assert.False(rig.Reached);
    }

    [Fact]
    public async Task Grace_still_runs_the_dashboard()
    {
        var rig = new Rig(() => new LicenceState { Status = LicenceStatus.Grace, GraceDaysLeft = 3, Licence = new LicenceClaims() });
        var (status, _, _) = await Send(rig, "/");
        Assert.Equal(200, status);
        Assert.True(rig.Reached);
    }

    [Fact]
    public async Task A_browser_gets_the_page_and_anything_else_gets_json_with_the_reason()
    {
        var rig = new Rig(() => Unusable(LicenceStatus.Revoked));

        var (code, json, context) = await Send(rig, "/api/anything", accept: "application/json");
        Assert.Equal(402, code);
        Assert.StartsWith("application/json", context.Response.ContentType);
        Assert.Contains("\"error\":\"licence\"", json);
        Assert.Contains("\"status\":\"Revoked\"", json);
        Assert.Equal("no-store", context.Response.Headers.CacheControl.ToString());

        var (postCode, _, _) = await Send(rig, "/ask", accept: "text/html", method: "POST");
        Assert.Equal(402, postCode);

        var (_, html, page) = await Send(rig, "/", accept: "text/html,application/xhtml+xml");
        Assert.StartsWith("text/html", page.Response.ContentType);
        Assert.Contains("withdrawn", html);
        Assert.Contains("default-src 'none'", page.Response.Headers.ContentSecurityPolicy.ToString());
    }

    [Fact]
    public async Task The_page_names_the_brand_of_the_licence_and_encodes_everything_it_shows()
    {
        var rig = new Rig(() => new LicenceState
        {
            Status = LicenceStatus.Expired,
            Licence = new LicenceClaims { Brand = new BrandProfile { Id = "B-7", Name = "<img src=x onerror=alert(1)>Acme", PrimaryColor = "red;}</style><script>alert(1)</script>", SupportEmail = "a@b.c\"><b>" } },
        });

        var (_, html, _) = await Send(rig, "/");
        Assert.DoesNotContain("<img", html);
        Assert.DoesNotContain("<script", html);
        Assert.DoesNotContain("<b>", html);
        Assert.Contains("&lt;img", html);
        Assert.Contains("--accent:#0071e3", html); // a colour that is not plain hex is ignored
    }

    [Fact]
    public async Task Check_again_reads_the_licence_again_and_goes_back_to_the_dashboard_even_with_no_licence()
    {
        var calls = 0;
        var rig = new Rig(() => { calls++; return Unusable(); });
        var first = await Send(rig, "/");
        var before = calls;
        var (status, _, context) = await Send(rig, LicenceGate.RecheckPath);
        Assert.Equal(402, first.Status);
        Assert.Equal(302, status);
        Assert.Equal("/", context.Response.Headers.Location.ToString());
        Assert.True(calls > before);
    }

    [Fact]
    public void A_licence_that_cannot_be_read_stops_the_dashboard()
    {
        var licence = new ProductLicence(() => throw new IOException("disk"), new MovingClock());
        Assert.False(licence.IsUsable);
        Assert.Equal(LicenceStatus.Invalid, licence.State.Status);
    }

    [Fact]
    public void The_state_is_looked_at_again_after_half_a_minute_not_on_every_request()
    {
        var clock = new MovingClock();
        var calls = 0;
        var licence = new ProductLicence(() => { calls++; return calls == 1 ? Usable() : Unusable(LicenceStatus.Revoked); }, clock);

        Assert.True(licence.IsUsable);
        Assert.True(licence.IsUsable);
        Assert.Equal(1, calls);
        clock.Advance(TimeSpan.FromSeconds(31));
        Assert.False(licence.IsUsable);
        Assert.Equal(2, calls);
    }

    [Fact]
    public void The_brand_comes_from_the_licence_and_is_NextGenOS_Smart_Retail_POS_without_one()
    {
        var plain = new BrandService(new ProductLicence(() => Usable(), new MovingClock()));
        Assert.Equal("Smart Retail POS", plain.Name);
        Assert.Equal("by NextGenOS", plain.By);
        Assert.Equal(string.Empty, plain.Style);

        var own = new BrandService(new ProductLicence(() => Usable("Acme POS", "#00AA55"), new MovingClock()));
        Assert.Equal("Acme POS", own.Name);
        Assert.Null(own.By); // the reseller's own brand does not say "by NextGenOS" unless the licence says so
        Assert.Contains("--accent:#00aa55", own.Style);
        Assert.Equal("help@example.com", own.SupportEmail);
    }

    [Theory]
    [InlineData("#0071e3", "#0071e3")]
    [InlineData("#ABCDEF", "#abcdef")]
    [InlineData("red", null)]
    [InlineData("#fff", null)]
    [InlineData("#12345g", null)]
    [InlineData("#123456;}body{display:none", null)]
    [InlineData("url(javascript:alert(1))", null)]
    [InlineData(null, null)]
    public void Only_plain_hex_colours_reach_the_pages_style(string? input, string? expected) => Assert.Equal(expected, BrandService.Hex(input));

    [Fact]
    public async Task A_live_screen_stops_when_the_licence_is_lost()
    {
        var usable = true;
        var licence = new ProductLicence(() => usable ? Usable() : Unusable(LicenceStatus.Revoked), new MovingClock());
        var handler = new LicenceCircuitHandler(licence);
        var ran = 0;
        var wrapped = handler.CreateInboundActivityHandler(_ => { ran++; return Task.CompletedTask; });

        await wrapped(null!);
        Assert.Equal(1, ran);

        usable = false;
        licence.Reload();
        await Assert.ThrowsAsync<InvalidOperationException>(() => wrapped(null!));
        Assert.Equal(1, ran);
    }

    [Fact]
    public async Task A_background_worker_runs_only_while_the_licence_is_usable()
    {
        var usable = false;
        var licence = new ProductLicence(() => usable ? Usable() : Unusable(), new MovingClock());
        CountingWorker.Reset();
        var services = new ServiceCollection().AddSingleton(licence).BuildServiceProvider();
        using var worker = new LicensedWorker<CountingWorker>(services, licence, NullLogger<LicensedWorker<CountingWorker>>.Instance, TimeSpan.FromMilliseconds(20));

        await worker.StartAsync(CancellationToken.None);
        await Task.Delay(300);
        Assert.Equal(0, CountingWorker.Started); // no licence: no work in the background

        usable = true;
        licence.Reload();
        Assert.True(await WaitFor(() => CountingWorker.Started == 1), "the worker did not start once the licence was there");

        usable = false;
        licence.Reload();
        Assert.True(await WaitFor(() => CountingWorker.Stopped == 1), "the worker did not stop when the licence was lost");

        await worker.StopAsync(CancellationToken.None);
    }

    private static async Task<bool> WaitFor(Func<bool> condition)
    {
        for (var i = 0; i < 200 && !condition(); i++)
        {
            await Task.Delay(50);
        }

        return condition();
    }

    private static async Task<(int Status, string Body, DefaultHttpContext Context)> Send(Rig rig, string path, string accept = "text/html", string method = "GET")
    {
        var context = new DefaultHttpContext { RequestServices = rig.Services };
        context.Request.Method = method;
        context.Request.Path = path;
        context.Request.Headers.Accept = accept;
        var body = new MemoryStream();
        context.Response.Body = body;
        await rig.Pipeline(context);
        return (context.Response.StatusCode, Encoding.UTF8.GetString(body.ToArray()), context);
    }

    private sealed class CountingWorker : Microsoft.Extensions.Hosting.BackgroundService
    {
        public static int Started;
        public static int Stopped;

        public static void Reset()
        {
            Started = 0;
            Stopped = 0;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Interlocked.Increment(ref Started);
            try
            {
                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                Interlocked.Increment(ref Stopped);
            }
        }
    }

    private sealed class MovingClock : TimeProvider
    {
        private DateTimeOffset _now = DateTimeOffset.UtcNow;

        public void Advance(TimeSpan by) => _now += by;

        public override DateTimeOffset GetUtcNow() => _now;
    }
}
