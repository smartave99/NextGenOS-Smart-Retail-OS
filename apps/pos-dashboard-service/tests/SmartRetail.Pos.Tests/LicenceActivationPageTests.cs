using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace SmartRetail.Pos.Tests;

/// <summary>A web program with no licence lets the person enter a key on the licence page; it cannot be driven from another site and cannot be used to read files.</summary>
public sealed class LicenceActivationPageTests : IDisposable
{
    private readonly string _folder = Path.Combine(Path.GetTempPath(), "licence-page-" + Guid.NewGuid().ToString("N"));
    private bool _usable;

    public LicenceActivationPageTests() => Directory.CreateDirectory(_folder);

    public void Dispose()
    {
        try { Directory.Delete(_folder, true); } catch (IOException) { }
    }

    private RequestDelegate Pipeline(bool withManager)
    {
        var licence = new ProductLicence(() => _usable
            ? new LicenceState { Status = LicenceStatus.Valid, Licence = new LicenceClaims { Modules = ["hub"] } }
            : new LicenceState { Status = LicenceStatus.Missing });
        var services = new ServiceCollection().AddSingleton(licence).AddSingleton<BrandService>();
        if (withManager)
        {
            services.AddSingleton(new LicenceManager(new LicenceOptions { RequiredModule = "hub", Directory = _folder }));
        }

        var provider = services.BuildServiceProvider();
        var app = new ApplicationBuilder(provider);
        app.UseLicenceGate();
        app.Run(context => context.Response.WriteAsync("the program"));
        var built = app.Build();
        return context =>
        {
            context.RequestServices = provider;
            return built(context);
        };
    }

    private static async Task<(int Status, string Body, DefaultHttpContext Context)> Send(RequestDelegate pipeline, string method, string path, string? form = null, Action<IHeaderDictionary>? headers = null)
    {
        var context = new DefaultHttpContext();
        context.Request.Method = method;
        context.Request.Path = path;
        context.Request.Headers.Accept = "text/html";
        if (form is not null)
        {
            var bytes = Encoding.UTF8.GetBytes(form);
            context.Request.ContentType = "application/x-www-form-urlencoded";
            context.Request.Body = new MemoryStream(bytes);
            context.Request.ContentLength = bytes.Length;
        }

        headers?.Invoke(context.Request.Headers);
        var body = new MemoryStream();
        context.Response.Body = body;
        await pipeline(context);
        return (context.Response.StatusCode, Encoding.UTF8.GetString(body.ToArray()), context);
    }

    [Fact]
    public async Task With_a_licence_manager_the_page_has_a_place_for_the_key_and_without_one_it_points_to_the_app()
    {
        var (status, html, _) = await Send(Pipeline(true), "GET", "/");
        Assert.Equal(402, status);
        Assert.Contains("name=\"key\"", html);
        Assert.Contains("action=\"/licence-activate\"", html);
        Assert.DoesNotContain("open the", html);

        var (_, plain, _) = await Send(Pipeline(false), "GET", "/");
        Assert.DoesNotContain("name=\"key\"", plain);
        Assert.Contains("open the Smart Retail POS app", plain);
    }

    [Theory]
    [InlineData("key=&code=", "Please type your licence key")]
    [InlineData("key=hello", "does not look like a licence key")]
    [InlineData("code=C%3A%5CWindows%5Cwin.ini", "does not look like a licence code")]
    [InlineData("code=%2Fetc%2Fpasswd", "does not look like a licence code")]
    public async Task A_key_or_code_that_is_not_one_is_refused_with_plain_words_and_the_program_stays_closed(string form, string expected)
    {
        var (status, html, _) = await Send(Pipeline(true), "POST", LicenceGate.ActivatePath, form);
        Assert.Equal(402, status);
        Assert.Contains(expected, html);
        Assert.DoesNotContain("the program", html);
    }

    [Fact]
    public async Task A_licence_code_that_is_not_signed_is_refused_without_an_error_page()
    {
        var (status, html, _) = await Send(Pipeline(true), "POST", LicenceGate.ActivatePath, "code=NGOS1.not-a-real-licence");
        Assert.Equal(402, status);
        Assert.Contains("class=\"problem\"", html);
    }

    [Theory]
    [InlineData("cross-site", null)]
    [InlineData("same-site", null)]
    [InlineData(null, "https://evil.example")]
    public async Task A_request_from_another_site_cannot_activate(string? fetchSite, string? origin)
    {
        var (status, html, _) = await Send(Pipeline(true), "POST", LicenceGate.ActivatePath, "key=NGOS-ABCDE-12345-FGHJK-67890", h =>
        {
            if (fetchSite is not null) h["Sec-Fetch-Site"] = fetchSite;
            if (origin is not null) h.Origin = origin;
            h.Host = "localhost:5280";
        });
        Assert.Equal(402, status);
        Assert.Contains("could not be done from here", html);
    }

    [Fact]
    public async Task The_activation_address_does_nothing_for_a_program_with_no_manager_and_goes_home_once_licensed()
    {
        var (status, _, _) = await Send(Pipeline(false), "POST", LicenceGate.ActivatePath, "key=x");
        Assert.Equal(402, status);

        _usable = true;
        var (code, _, context) = await Send(Pipeline(true), "GET", LicenceGate.ActivatePath);
        Assert.Equal(302, code);
        Assert.Equal("/", context.Response.Headers.Location.ToString());
    }
}
