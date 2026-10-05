using System.Text;
using System.Text.RegularExpressions;

namespace SmartRetail.Pos.Core;

/// <summary>Helpers for showing personal details only as far as a screen needs them.</summary>
public static partial class PersonalData
{
    /// <summary>Hides the middle digits of long numbers, such as a phone number typed into a customer's name:
    /// "Asha_9876543210" → "Asha_98••••••10", "98765 43210" → "98••• •••10". For summary screens, where the
    /// full number is not needed.</summary>
    public static string MaskNumbers(string? text) => LongNumber().Replace(text ?? "", match =>
    {
        var digits = match.Value.Count(char.IsAsciiDigit);
        var seen = 0;
        var masked = new StringBuilder(match.Value.Length);
        foreach (var c in match.Value)
        {
            if (!char.IsAsciiDigit(c))
            {
                masked.Append(c);
                continue;
            }

            masked.Append(seen < 2 || seen >= digits - 2 ? c : '•');
            seen++;
        }

        return masked.ToString();
    });

    // Seven or more digits, allowing a single space or hyphen between them.
    [GeneratedRegex(@"\d(?:[ -]?\d){6,}")]
    private static partial Regex LongNumber();
}
