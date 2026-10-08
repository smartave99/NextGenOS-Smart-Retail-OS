using System.Net;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Web.Tests;

/// <summary>An update that cannot make its safe copy does not start; the owner is told so in plain words and the shop's data is untouched.</summary>
public class UpdateSafetyWebTests
{
    [Fact]
    public async Task When_the_safe_copy_before_an_update_cannot_be_made_the_shop_does_not_open_and_the_owner_is_told_what_to_do()
    {
        var f = new HubWebFactory();
        using var _ = f;
        // An older shop (first structure only) is already in the data folder, and the folder for copies cannot be made.
        Directory.CreateDirectory(f.Folder);
        var path = Path.Combine(f.Folder, "shop.db");
        HubApp.Open(path).Db.Rollback(1);
        var blocker = Path.Combine(f.Folder, "blocker");
        File.WriteAllText(blocker, "not a folder");
        f.BackupFolder = Path.Combine(blocker, "copies");

        var http = f.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = false, HandleCookies = false });
        http.DefaultRequestHeaders.Accept.ParseAdd("text/html");
        var page = await http.GetAsync("/");

        Assert.Equal(HttpStatusCode.ServiceUnavailable, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        Assert.Contains("The update has not started", html);
        Assert.Contains("was not changed", html);
        Assert.DoesNotContain("   at ", html);

        var db = new HubDb(path);
        Assert.Equal(new long[] { 1 }, db.Query("SELECT version FROM schema_version", r => r.GetInt64(0)).ToArray());   // no step ran
    }
}
