using SmartRetail.Pos.Core.Labels;

namespace SmartRetail.Pos.Tests;

public class Code128Tests
{
    [Fact]
    public void Even_length_numbers_use_code_set_c_two_digits_a_symbol()
    {
        // Start C (105), 41, 72; check = (105 + 1*41 + 2*72) % 103 = 290 % 103 = 84; stop.
        Assert.Equal(new[] { 105, 41, 72, 84, 106 }, Code128.Symbols("4172"));
        // (105 + 1*0 + 2*12) % 103 = 129 % 103 = 26.
        Assert.Equal(new[] { 105, 0, 12, 26, 106 }, Code128.Symbols("0012"));
    }

    [Fact]
    public void An_odd_last_digit_switches_to_code_set_b()
    {
        // Start C, 12, Code B (100), '3' = 19; check = (105 + 12 + 2*100 + 3*19) % 103 = 374 % 103 = 65.
        Assert.Equal(new[] { 105, 12, 100, 19, 65, 106 }, Code128.Symbols("123"));
        // A 13-digit barcode: six pairs, then the last digit.
        Assert.Equal(new[] { 105, 20, 0, 0, 0, 0, 1, 100, 17 }, Code128.Symbols("2000000000011").Take(9));
        // A single digit is code set B alone: start B, '7' = 23; check = (104 + 23) % 103 = 24.
        Assert.Equal(new[] { 104, 23, 24, 106 }, Code128.Symbols("7"));
    }

    [Fact]
    public void Anything_else_uses_code_set_b()
    {
        var symbols = Code128.Symbols("RICE-BATCH-A");
        Assert.Equal(104, symbols[0]);
        Assert.Equal("RICE-BATCH-A".Select(c => c - 32), symbols.Skip(1).Take(12));
        var check = 104;
        for (var i = 1; i <= 12; i++)
        {
            check += i * symbols[i];
        }
        Assert.Equal(check % 103, symbols[^2]);
    }

    [Fact]
    public void Every_symbol_is_eleven_modules_and_the_stop_thirteen()
    {
        var widths = Code128.Widths("4172");

        // Start, two data symbols, check: 4 x 11 modules, then the stop's 13.
        Assert.Equal(4 * 11 + 13, widths.Sum());
        Assert.Equal(4 * 6 + 7, widths.Count);
        Assert.All(widths, w => Assert.InRange(w, 1, 4));
    }

    [Fact]
    public void The_svg_path_draws_each_bar_inside_quiet_zones()
    {
        var (path, width) = Code128.SvgPath("4172");

        Assert.Equal(10 + 57 + 10, width);
        Assert.StartsWith("M10 0h2v1h-2z", path); // Start C begins with a bar two modules wide.
        Assert.Equal(16, path.Count(c => c == 'M')); // 3 bars a symbol x 5 symbols, plus the stop's final bar.
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("दूध")]
    [InlineData("tab\there")]
    public void Text_a_barcode_cannot_hold_is_refused(string? text)
    {
        Assert.False(Code128.CanEncode(text));
        Assert.Throws<ArgumentException>(() => Code128.Symbols(text!));
    }

    [Fact]
    public void Codes_as_long_as_the_pos_column_can_be_encoded()
    {
        Assert.Equal(100, Code128.MaxLength);
        Assert.True(Code128.CanEncode(new string('A', 50)));
        Assert.True(Code128.CanEncode(new string('7', Code128.MaxLength)));
        Assert.False(Code128.CanEncode(new string('7', Code128.MaxLength + 1)));
        Assert.Equal(77, Code128.Width("4172"));
    }
}
