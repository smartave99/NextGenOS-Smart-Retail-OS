using System.Text.Json.Nodes;
using NextGenOS.Hub.Setup;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Tests;

/// <summary>The setup file NextGenOS prepares for one business: read without ever throwing, a bad part left out and named, and applied through the same services as the screens.</summary>
public class SetupProfileTests
{
    private const string Good = """
    {
      "schema": 1,
      "business": { "name": "Luzon Fresh Mart", "country": "PH", "industry": "retail" },
      "settings": { "pricesIncludeTax": true, "taxRegistered": true, "roundTotal": false, "receiptFooter": "Salamat po!", "paymentMethods": ["cash", "gcash", "card"] },
      "vocabulary": { "customer": ["Suki", "Sukis"] },
      "features": { "tables": false },
      "starter": {
        "items": [
          { "name": "Rice 5 kg", "price": "285.00", "kind": "stock", "unit": "bag", "category": "Grocery", "barcode": "4800000000011" },
          { "name": "Gift wrapping", "price": 20, "kind": "service" }
        ],
        "people": [ { "kind": "supplier", "name": "Manila Wholesale", "phone": "+63 2 5555 0100" } ]
      }
    }
    """;

    [Fact]
    public void A_good_file_is_read_in_full_with_nothing_to_report()
    {
        var p = SetupProfile.Parse(Good);
        Assert.Empty(p.Problems);
        Assert.Equal("Luzon Fresh Mart", p.Name);
        Assert.Equal("PH", p.Country);
        Assert.Equal("retail", p.Industry);
        Assert.Equal(new[] { "cash", "gcash", "card" }, p.PaymentMethods);
        Assert.Equal(2, p.Items.Count);
        Assert.Single(p.People);
        Assert.True(p.HasStarter);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Nothing_at_all_is_an_empty_profile_and_not_a_problem(string? text)
    {
        var p = SetupProfile.Parse(text);
        Assert.Empty(p.Problems);
        Assert.Null(p.Name);
        Assert.False(p.HasStarter);
    }

    [Theory]
    [InlineData("{ not json")]
    [InlineData("[1,2,3]")]
    [InlineData("\"text\"")]
    [InlineData("{}")]
    [InlineData("{\"schema\": 2}")]
    [InlineData("{\"schema\": \"1\"}")]
    public void Text_that_is_not_a_profile_never_throws_and_applies_nothing(string text)
    {
        var p = SetupProfile.Parse(text);
        Assert.NotEmpty(p.Problems);
        Assert.Null(p.Name);
        Assert.Empty(p.Items);
    }

    [Fact]
    public void A_deeply_nested_file_is_refused_not_followed()
    {
        var deep = string.Concat(Enumerable.Repeat("{\"a\":", 200)) + "1" + new string('}', 200);
        var p = SetupProfile.Parse(deep);
        Assert.NotEmpty(p.Problems);
    }

    [Fact]
    public void A_bad_part_is_left_out_and_named_and_the_rest_still_applies()
    {
        var p = SetupProfile.Parse("""
        {
          "schema": 1,
          "business": { "name": "Test", "country": "ZZ", "industry": "spaceship", "region": "nope" },
          "settings": { "paymentMethods": ["cash", "<script>", 5] },
          "vocabulary": { "customer": ["Guest"], "nonsense": ["a", "b"] },
          "features": { "tables": true, "launchRockets": true },
          "starter": { "items": [ { "name": "No price" }, { "name": "Negative", "price": "-5" }, { "name": "Fine", "price": "10.5" } ] },
          "password": "hunter2"
        }
        """);
        Assert.Equal("Test", p.Name);
        Assert.Null(p.Country);
        Assert.Null(p.Industry);
        Assert.Equal(new[] { "cash" }, p.PaymentMethods);
        Assert.Empty(p.Vocabulary);   // "customer" has no pair, and "nonsense" is not a word of a business
        Assert.True(p.FeatureChoices["tables"]);
        Assert.False(p.FeatureChoices.ContainsKey("launchRockets"));
        Assert.Single(p.Items);
        Assert.Equal("Fine", p.Items[0].Name);
        var all = string.Join("\n", p.Problems);
        foreach (var part in new[] { "ZZ", "spaceship", "nope", "launchRockets", "password", "starter item" }) Assert.Contains(part, all);
    }

    [Fact]
    public void A_secret_written_into_the_file_is_never_kept()
    {
        var p = SetupProfile.Parse("""{ "schema": 1, "business": { "name": "A", "password": "hunter2", "licence": "NGOS-AAAAA" }, "owner": { "user": "x", "password": "y" } }""");
        Assert.Equal("A", p.Name);
        Assert.Contains("owner", string.Join("\n", p.Problems));
        // The profile has nowhere to hold a password, a licence or a tax rate.
        var type = typeof(SetupProfile);
        foreach (var banned in new[] { "Password", "Licence", "License", "Key", "Secret", "TaxRate", "Rate" })
            Assert.DoesNotContain(type.GetProperties(), x => x.Name.Contains(banned, StringComparison.Ordinal));
    }

    [Fact]
    public void Control_characters_are_taken_out_of_text_and_long_text_is_cut()
    {
        var p = SetupProfile.Parse("{\"schema\":1,\"business\":{\"name\":\"A\\u0007B\\u0000C\"},\"notes\":\"" + new string('x', 5000) + "\"}");
        Assert.Equal("ABC", p.Name);
        Assert.Equal(2000, p.Notes!.Length);
    }

    [Fact]
    public void A_very_long_list_is_cut_at_the_limit()
    {
        var items = string.Join(",", Enumerable.Range(0, SetupProfile.MaxStarter + 50).Select(i => $"{{\"name\":\"Item {i}\",\"price\":\"1\"}}"));
        var p = SetupProfile.Parse("{\"schema\":1,\"starter\":{\"items\":[" + items + "]}}");
        Assert.Equal(SetupProfile.MaxStarter, p.Items.Count);
        Assert.Contains("50 starter item", string.Join("\n", p.Problems));
    }

    [Fact]
    public void Settings_words_and_parts_go_into_the_shop_settings()
    {
        var p = SetupProfile.Parse(Good);
        var settings = new ShopSettings { Name = "x", Country = "PH", Industry = "retail", PricesIncludeTax = false, ReceiptFooter = "Thank you!" };
        p.ApplyTo(settings);
        Assert.True(settings.PricesIncludeTax);
        Assert.Equal("Salamat po!", settings.ReceiptFooter);
        Assert.Equal(new[] { "cash", "gcash", "card" }, settings.PaymentMethods);
        Assert.Equal(new[] { "Suki", "Sukis" }, settings.VocabularyOverrides["customer"]);
        Assert.False(settings.FeatureOverrides["tables"]);
    }

    [Fact]
    public void A_profile_with_no_settings_leaves_the_shops_own_choices_alone()
    {
        var settings = new ShopSettings { PricesIncludeTax = false, RoundTotal = true, ReceiptFooter = "Keep me" };
        SetupProfile.Parse("{\"schema\":1}").ApplyTo(settings);
        Assert.False(settings.PricesIncludeTax);
        Assert.True(settings.RoundTotal);
        Assert.Equal("Keep me", settings.ReceiptFooter);
    }

    [Fact]
    public void Starter_items_and_people_are_added_through_the_normal_services()
    {
        using var fx = new HubFixture("PH", "retail");
        var result = SetupProfile.Parse(Good).ApplyStarter(fx.App);
        Assert.Equal(2, result.Items);
        Assert.Equal(1, result.People);
        Assert.Empty(result.Skipped);
        var rice = fx.App.Catalog.FindByCode("4800000000011");
        Assert.NotNull(rice);
        Assert.Equal("Rice 5 kg", rice!.Name);
        Assert.Equal(28500, rice.PriceMinor);
        Assert.Equal("Manila Wholesale", Assert.Single(fx.App.Parties.Search("supplier")).Name);
    }

    [Fact]
    public void A_starter_line_that_cannot_be_added_is_named_and_the_others_still_go_in()
    {
        using var fx = new HubFixture("PH", "retail");
        var p = SetupProfile.Parse("""
        { "schema": 1, "starter": { "items": [
            { "name": "One", "price": "5", "barcode": "123" },
            { "name": "Two", "price": "6", "barcode": "123" },
            { "name": "Three", "price": "7", "barcode": "456" } ] } }
        """);
        var result = p.ApplyStarter(fx.App);
        Assert.Equal(2, result.Items);
        Assert.Single(result.Skipped);
        Assert.StartsWith("Two:", result.Skipped[0]);
    }

    [Fact]
    public void An_item_kind_the_business_does_not_use_becomes_the_normal_kind()
    {
        var p = SetupProfile.Parse("""{ "schema": 1, "business": { "industry": "library" }, "starter": { "items": [ { "name": "Moby Dick", "price": "0", "kind": "gadget" } ] } }""");
        Assert.Equal("title", p.Items[0].Kind);
    }
}

/// <summary>The shared vectors (apps/business-hub/tests/vectors/setup-profile.json): the same cases the Setup Studio's own rules (tools/setup-studio/lib/rules.mjs) pass.</summary>
public class SetupProfileVectorTests
{
    private static readonly JsonNode Vectors = JsonNode.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "setup-profile.json")))!;

    public static IEnumerable<object[]> Cases() => Vectors["cases"]!.AsArray().Select((c, i) => new object[] { i, c!["name"]!.GetValue<string>() });

    /// <summary>The profile in the one plain form the vectors use (a part with nothing in it is left out, as is a missing field).</summary>
    private static JsonNode? Plain(SetupProfile p)
    {
        if (!p.IsProfile) return null;
        var o = new JsonObject { ["schema"] = 1 };
        var business = new JsonObject();
        if (p.Name is not null) business["name"] = p.Name;
        if (p.Country is not null) business["country"] = p.Country;
        if (p.Industry is not null) business["industry"] = p.Industry;
        if (p.Region is not null) business["region"] = p.Region;
        if (business.Count > 0) o["business"] = business;
        var settings = new JsonObject();
        if (p.PricesIncludeTax is { } a) settings["pricesIncludeTax"] = a;
        if (p.TaxRegistered is { } b) settings["taxRegistered"] = b;
        if (p.RoundTotal is { } c) settings["roundTotal"] = c;
        if (p.AllowNegativeStock is { } d) settings["allowNegativeStock"] = d;
        if (p.ReceiptFooter is not null) settings["receiptFooter"] = p.ReceiptFooter;
        if (p.PaymentMethods.Count > 0) settings["paymentMethods"] = new JsonArray(p.PaymentMethods.Select(m => (JsonNode)JsonValue.Create(m)!).ToArray());
        if (settings.Count > 0) o["settings"] = settings;
        if (p.Vocabulary.Count > 0) o["vocabulary"] = new JsonObject(p.Vocabulary.Select(v => KeyValuePair.Create(v.Key, (JsonNode?)new JsonArray(v.Value.Select(w => (JsonNode)JsonValue.Create(w)!).ToArray()))));
        if (p.FeatureChoices.Count > 0) o["features"] = new JsonObject(p.FeatureChoices.Select(f => KeyValuePair.Create(f.Key, (JsonNode?)JsonValue.Create(f.Value))));
        var starter = new JsonObject();
        if (p.Items.Count > 0)
            starter["items"] = new JsonArray(p.Items.Select(i =>
            {
                var item = new JsonObject { ["name"] = i.Name, ["price"] = i.Price, ["kind"] = i.Kind, ["taxClass"] = i.TaxClass };
                if (i.Barcode is not null) item["barcode"] = i.Barcode;
                if (i.Unit is not null) item["unit"] = i.Unit;
                if (i.Category is not null) item["category"] = i.Category;
                return (JsonNode)item;
            }).ToArray());
        if (p.People.Count > 0)
            starter["people"] = new JsonArray(p.People.Select(x =>
            {
                var person = new JsonObject { ["kind"] = x.Kind, ["name"] = x.Name };
                if (x.Phone is not null) person["phone"] = x.Phone;
                if (x.Email is not null) person["email"] = x.Email;
                return (JsonNode)person;
            }).ToArray());
        if (starter.Count > 0) o["starter"] = starter;
        if (p.Notes is not null) o["notes"] = p.Notes;
        return o;
    }

    [Theory]
    [MemberData(nameof(Cases))]
    public void The_profile_is_read_the_way_the_vectors_say(int index, string name)
    {
        var c = Vectors["cases"]![index]!;
        var text = c["raw"] is { } raw ? raw.GetValue<string>() : c["input"]!.ToJsonString();
        var p = SetupProfile.Parse(text);
        var expect = c["expect"]!;
        Assert.True(JsonNode.DeepEquals(expect["value"], Plain(p)), $"{name}\nexpected: {expect["value"]?.ToJsonString()}\nread:     {Plain(p)?.ToJsonString()}");
        Assert.Equal(expect["problems"]!.AsArray().Select(x => x!.GetValue<string>()).ToArray(), p.Problems.ToArray());
    }
}

/// <summary>Nothing is chosen for the owner (CLAUDE.md, section 8): no country, until set-up or the customer's profile names one.</summary>
public class NoFixedMarketTests
{
    [Fact]
    public void A_new_shop_has_no_country_and_says_so_in_plain_words_until_set_up_chooses_one()
    {
        Assert.Equal("", new ShopSettings().Country);
        var path = Path.Combine(Path.GetTempPath(), "hub-nomarket-" + Guid.NewGuid().ToString("N") + ".db");
        try
        {
            var app = HubApp.Open(path);
            var ex = Assert.Throws<HubException>(() => app.Shop.Current);
            Assert.Equal("not-set-up", ex.Code);
            Assert.Contains("not set up yet", ex.Message);
            app.Shop.Save(new ShopSettings { Name = "A", Country = "PH", Industry = "retail", SetupDone = true });
            Assert.Equal("PHP", app.Shop.Current.CurrencyCode);
        }
        finally { foreach (var f in new[] { path, path + "-wal", path + "-shm" }) { try { File.Delete(f); } catch (IOException) { } } }
    }

    [Fact]
    public void A_sample_company_is_never_made_for_a_country_nobody_named()
    {
        var path = Path.Combine(Path.GetTempPath(), "hub-nomarket-" + Guid.NewGuid().ToString("N") + ".db");
        try { Assert.Throws<ArgumentException>(() => NextGenOS.Hub.Demo.DemoCompany.Fill(path, new NextGenOS.Hub.Demo.DemoOptions { Industry = "retail" })); }
        finally { foreach (var f in new[] { path, path + "-wal", path + "-shm" }) { try { File.Delete(f); } catch (IOException) { } } }
    }
}
