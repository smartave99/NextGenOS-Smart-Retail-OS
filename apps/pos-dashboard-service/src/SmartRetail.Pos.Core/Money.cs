using System.Globalization;
using System.Text;

namespace SmartRetail.Pos.Core;

/// <summary>Indian Rupee helpers: rounding to paise and ₹ formatting with Indian digit grouping.</summary>
public static class Money
{
    /// <summary>Rounds to paise (2 decimals), half away from zero, as bills do.</summary>
    public static decimal Round(decimal amount) => Math.Round(amount, 2, MidpointRounding.AwayFromZero);

    /// <summary>Rounds to the nearest whole rupee, half away from zero.</summary>
    public static decimal RoundToRupee(decimal amount) => Math.Round(amount, 0, MidpointRounding.AwayFromZero);

    /// <summary>Formats e.g. 123456.78 as "₹1,23,456.78". Negative amounts get a leading minus.</summary>
    public static string Format(decimal amount) => Compose(amount, "₹");

    /// <summary>Like <see cref="Format"/> without the ₹ sign, for receipt columns: "1,23,456.78".</summary>
    public static string FormatAmount(decimal amount) => Compose(amount, "");

    /// <summary>Like <see cref="Format"/>, but whole rupees drop the paise: 1000 → "₹1,000", 12.5 → "₹12.50".</summary>
    public static string FormatCompact(decimal amount)
    {
        var text = Format(amount);
        return text.EndsWith(".00", StringComparison.Ordinal) ? text[..^3] : text;
    }

    private static string Compose(decimal amount, string symbol)
    {
        var rounded = Round(amount);
        var negative = rounded < 0;
        rounded = Math.Abs(rounded);

        var whole = decimal.Truncate(rounded);
        var paise = (int)((rounded - whole) * 100m);

        var text = symbol + GroupIndian(whole) + "." + paise.ToString("00", CultureInfo.InvariantCulture);
        return negative ? "-" + text : text;
    }

    /// <summary>Formats a quantity without trailing zeros: 2 → "2", 1.250 → "1.25".</summary>
    public static string FormatQty(decimal qty) => qty.ToString("0.###", CultureInfo.InvariantCulture);

    // Indian grouping: the last three digits, then groups of two (12,34,56,789).
    private static string GroupIndian(decimal whole)
    {
        var digits = whole.ToString("0", CultureInfo.InvariantCulture);
        if (digits.Length <= 3)
        {
            return digits;
        }

        var head = digits[..^3];
        var builder = new StringBuilder();
        for (var i = 0; i < head.Length; i++)
        {
            if (i > 0 && (head.Length - i) % 2 == 0)
            {
                builder.Append(',');
            }
            builder.Append(head[i]);
        }
        return builder.Append(',').Append(digits[^3..]).ToString();
    }
}
