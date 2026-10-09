using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>The bill as a full page (A4 or A5): the same bill as the receipt, with the tax for each rate, the total in words where the country's pack gives the money's words, the terms and a place to sign.</summary>
public class TaxInvoiceWebTests
{
    private const string Password = "correct horse battery";

    private static HttpClient Client(HubWebFactory factory)
    {
        var http = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = false, HandleCookies = false });
        http.DefaultRequestHeaders.Accept.ParseAdd("text/html");
        return http;
    }

    private static async Task<string> SignIn(HttpClient http)
    {
        var page = await http.GetAsync("/login");
        var html = await page.Content.ReadAsStringAsync();
        var token = Regex.Match(html, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var formName = Regex.Match(html, "name=\"_handler\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        var cookies = string.Join("; ", page.Headers.GetValues("Set-Cookie").Select(c => c.Split(';')[0]));
        var request = new HttpRequestMessage(HttpMethod.Post, "/login") { Content = new FormUrlEncodedContent(new Dictionary<string, string> { ["__RequestVerificationToken"] = token, ["_handler"] = formName, ["Username"] = "owner", ["Password"] = Password }) };
        request.Headers.Add("Cookie", cookies);
        var response = await http.SendAsync(request);
        var session = response.Headers.GetValues("Set-Cookie").First(c => c.StartsWith("hub.session=", StringComparison.Ordinal));
        return cookies + "; " + session.Split(';')[0];
    }

    private static async Task<string> Page(HttpClient http, string path, string cookie)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        request.Headers.Add("Cookie", cookie);
        var response = await http.SendAsync(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>A shop in the country, one bill of 2 × 500.00 at 18 percent (1,000.00 before tax, 1,180.00 in all); returns the bill's id and a way to change the shop's settings.</summary>
    private static (long Bill, Action<Action<ShopSettings>> Change) SetUp(HubWebFactory f, string country, string region, string industry = "retail", string taxCode = "GST18")
    {
        var app = f.Services.GetRequiredService<HubApp>();
        app.Shop.Save(new ShopSettings { Name = "Test Shop", Address = "1 Main Road", Country = country, Region = region, Industry = industry, SetupDone = true, PricesIncludeTax = false });
        var owner = app.Users.Create("owner", "Olivia Owner", Roles.Owner, Password).Id;
        long bill;
        using (app.Access.As(owner))
        {
            var draft = app.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { Description = "Rice", UnitPriceMinor = 50_000, QtyMilli = 2000, TaxCode = taxCode } } });
            var issued = app.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = draft.Document.PayableMinor } } });
            bill = issued.Document.Id;
        }
        return (bill, change => { var s = app.Shop.Settings; change(s); using (app.Access.As(owner)) app.Shop.Save(s); app.Shop.Invalidate(); });
    }

    [Fact]
    public async Task The_bill_opens_in_each_layout_and_a_layout_that_is_not_one_of_them_is_ignored()
    {
        // the pages are drawn in the browser after the page opens, so what each layout shows is checked in e2e/invoice.e2e.mjs; here only that every layout opens for a signed-in person and for nobody else
        using var f = new HubWebFactory();
        var (bill, change) = SetUp(f, "IN", "27");
        var http = Client(f);
        var stranger = await http.GetAsync($"/documents/{bill}?layout=a4");
        Assert.Equal(HttpStatusCode.Redirect, stranger.StatusCode);
        var cookie = await SignIn(http);
        foreach (var layout in new[] { "receipt", "a4", "a5", "nonsense" }) Assert.Contains("<html", await Page(http, $"/documents/{bill}?layout={layout}", cookie));
        change(s => s.BillLayout = "a5");
        Assert.Contains("<html", await Page(http, $"/documents/{bill}", cookie));
    }
}
