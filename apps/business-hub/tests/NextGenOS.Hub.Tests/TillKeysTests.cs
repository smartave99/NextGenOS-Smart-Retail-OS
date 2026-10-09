using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Tests;

/// <summary>The keys of the sell screen are the shop's own (docs/old-programs/04 D: one map, shown on screen, changeable). The rules about what a key may be.</summary>
public class TillKeysTests
{
    [Theory]
    [InlineData("f2", "F2")]
    [InlineData(" F12 ", "F12")]
    [InlineData("ctrl + s", "Ctrl+S")]
    [InlineData("shift+alt+9", "Alt+Shift+9")]
    [InlineData("", "")]
    [InlineData("   ", "")]
    public void A_key_is_written_the_same_way_whatever_was_typed(string typed, string expected) => Assert.Equal(expected, TillKeys.Normalize(typed));

    [Theory]
    [InlineData("F13")]
    [InlineData("F0")]
    [InlineData("S")]              // a plain letter would be lost in typing
    [InlineData("Shift+S")]
    [InlineData("Ctrl+F2+X")]
    [InlineData("Hyper+S")]
    [InlineData("Enter")]
    public void Anything_else_is_not_a_key_the_till_can_use(string typed) => Assert.Null(TillKeys.Normalize(typed));

    [Fact]
    public void The_starting_keys_are_used_until_the_shop_chooses_and_an_empty_choice_means_no_key()
    {
        var starting = TillKeys.Effective(null);
        Assert.Equal(new[] { "scan", "customer", "amount", "drawer", "complete" }, starting.Keys.ToArray());
        Assert.All(starting.Values, v => Assert.NotNull(TillKeys.Normalize(v)));

        var chosen = TillKeys.Effective(new Dictionary<string, string> { ["complete"] = "Alt+S", ["drawer"] = "" });

        Assert.Equal("Alt+S", chosen["complete"]);
        Assert.Equal("", chosen["drawer"]);
        Assert.Equal(starting["scan"], chosen["scan"]);
    }

    [Fact]
    public void A_key_cannot_do_two_things_and_a_wrong_key_is_said_in_plain_words()
    {
        Assert.Null(TillKeys.Problem(TillKeys.Effective(null)));
        Assert.Null(TillKeys.Problem(new Dictionary<string, string> { ["scan"] = "", ["drawer"] = "" }));   // several with no key is fine
        Assert.Contains("more than one thing", TillKeys.Problem(new Dictionary<string, string> { ["scan"] = "F5", ["complete"] = "f5" }));
        Assert.Contains("cannot be used", TillKeys.Problem(new Dictionary<string, string> { ["scan"] = "S" }));
    }

    [Fact]
    public void The_shops_choice_is_kept_with_the_settings()
    {
        using var f = new HubFixture();
        var settings = f.App.Shop.Settings;
        settings.ShortcutKeys = new Dictionary<string, string> { ["complete"] = "Alt+S" };
        f.App.Shop.Save(settings);

        Assert.Equal("Alt+S", TillKeys.Effective(f.App.Shop.Settings.ShortcutKeys)["complete"]);
    }
}
