using System.Globalization;
using SmartRetail.Pos.Core;

namespace SmartRetail.Pos.Tests;

public class MoneyTests
{
    private static decimal D(string value) => decimal.Parse(value, CultureInfo.InvariantCulture);

    [Theory]
    [InlineData("0", "₹0.00")]
    [InlineData("5", "₹5.00")]
    [InlineData("999.5", "₹999.50")]
    [InlineData("1000", "₹1,000.00")]
    [InlineData("99999.99", "₹99,999.99")]
    [InlineData("100000", "₹1,00,000.00")]
    [InlineData("123456.78", "₹1,23,456.78")]
    [InlineData("12345678.9", "₹1,23,45,678.90")]
    [InlineData("-1500.25", "-₹1,500.25")]
    [InlineData("0.005", "₹0.01")]
    [InlineData("-0.004", "₹0.00")]
    public void Formats_rupees_with_indian_digit_grouping(string amount, string expected) =>
        Assert.Equal(expected, Money.Format(D(amount)));

    [Theory]
    [InlineData("123456.78", "1,23,456.78")]
    [InlineData("-1500.25", "-1,500.25")]
    [InlineData("0", "0.00")]
    public void Plain_amounts_have_no_rupee_sign(string amount, string expected) =>
        Assert.Equal(expected, Money.FormatAmount(D(amount)));

    [Theory]
    [InlineData("1000", "₹1,000")]
    [InlineData("0", "₹0")]
    [InlineData("12.5", "₹12.50")]
    [InlineData("2000.01", "₹2,000.01")]
    public void Compact_amounts_drop_zero_paise(string amount, string expected) =>
        Assert.Equal(expected, Money.FormatCompact(D(amount)));

    [Theory]
    [InlineData("2", "2")]
    [InlineData("1.250", "1.25")]
    [InlineData("0.5", "0.5")]
    [InlineData("1.2346", "1.235")]
    public void Quantities_drop_trailing_zeros(string qty, string expected) =>
        Assert.Equal(expected, Money.FormatQty(D(qty)));

    [Theory]
    [InlineData("2.345", "2.35")]
    [InlineData("-2.345", "-2.35")]
    [InlineData("2.344", "2.34")]
    public void Rounds_to_paise_half_away_from_zero(string amount, string expected) =>
        Assert.Equal(D(expected), Money.Round(D(amount)));

    [Theory]
    [InlineData("10.5", "11")]
    [InlineData("10.49", "10")]
    [InlineData("-10.5", "-11")]
    public void Rounds_to_whole_rupees_half_away_from_zero(string amount, string expected) =>
        Assert.Equal(D(expected), Money.RoundToRupee(D(amount)));
}

public class PersonalDataTests
{
    [Theory]
    [InlineData("Asha_9876543210", "Asha_98••••••10")]
    [InlineData("Ravi 98765 43210", "Ravi 98••• •••10")]
    [InlineData("+91-98765-43210", "+91-•••••-•••10")]
    [InlineData("Shop 1234567", "Shop 12•••67")]
    [InlineData("Teddy 22", "Teddy 22")]
    [InlineData(null, "")]
    public void Long_numbers_in_names_are_partly_hidden(string? name, string shown)
    {
        Assert.Equal(shown, PersonalData.MaskNumbers(name));
    }
}
