using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NextGenOS.Tax
{
    /// <summary>
    /// An amount of money written out in English words, for the total on a full tax invoice: "One thousand two hundred fifty rupees and fifty paise only".
    /// The currency's own words (rupee and paisa, lakh and crore, "only") come from the pack (<see cref="CurrencyWords"/>, SPEC section 4d); nothing about a
    /// country is written here. A pack without words, or with grouping that needs names it does not give, gets no words (null): an invoice then shows none.
    /// </summary>
    public static class NumberWords
    {
        private static readonly string[] Small =
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
            "sixteen", "seventeen", "eighteen", "nineteen",
        };

        private static readonly string[] Tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static readonly string[] StandardScales = { "thousand", "million", "billion", "trillion" };

        /// <summary>The amount (in the currency's smallest unit) in words, or null when the currency's pack gives no words.</summary>
        public static string AmountInWords(BigInteger minorUnits, CurrencyInfo currency)
        {
            var words = currency == null ? null : currency.Words;
            if (words == null || words.Major == null || words.Major.Count != 2) return null;
            var indian = currency.Grouping == "indian";
            IList<string> scales = words.Scales != null && words.Scales.Count > 0 ? words.Scales : (indian ? null : StandardScales);
            if (scales == null) return null;
            var decimals = currency.Decimals < 0 ? 0 : currency.Decimals;
            var factor = BigInteger.Pow(10, decimals);
            var negative = minorUnits.Sign < 0;
            var abs = BigInteger.Abs(minorUnits);
            var whole = BigInteger.Divide(abs, factor);
            var part = abs - whole * factor;
            if (!part.IsZero && (words.Minor == null || words.Minor.Count != 2)) return null;

            var text = new StringBuilder();
            if (negative) text.Append("minus ");
            text.Append(Say(whole, indian, scales)).Append(' ').Append(whole.IsOne ? words.Major[0] : words.Major[1]);
            if (!part.IsZero)
            {
                text.Append(' ').Append(string.IsNullOrWhiteSpace(words.Join) ? "and" : words.Join.Trim()).Append(' ');
                text.Append(Say(part, indian, scales)).Append(' ').Append(part.IsOne ? words.Minor[0] : words.Minor[1]);
            }
            if (!string.IsNullOrWhiteSpace(words.Ending)) text.Append(' ').Append(words.Ending.Trim());
            var result = text.ToString();
            return char.ToUpperInvariant(result[0]) + result.Substring(1);
        }

        /// <summary>A whole number in English words; the big steps are named by <paramref name="scales"/>, smallest first, and the last one takes everything above it.</summary>
        private static string Say(BigInteger n, bool indian, IList<string> scales)
        {
            if (n.IsZero) return Small[0];
            var parts = new List<BigInteger> { n % 1000 };
            var rest = n / 1000;
            for (var i = 0; i < scales.Count && !rest.IsZero; i++)
            {
                if (i == scales.Count - 1) { parts.Add(rest); rest = BigInteger.Zero; }
                else
                {
                    var size = indian ? 100 : 1000;
                    parts.Add(rest % size);
                    rest /= size;
                }
            }
            var pieces = new List<string>();
            for (var j = parts.Count - 1; j >= 0; j--)
            {
                if (parts[j].IsZero) continue;
                var spoken = parts[j] < 1000 ? Below1000((int)parts[j]) : Say(parts[j], indian, scales);
                pieces.Add(j == 0 ? spoken : spoken + " " + scales[j - 1]);
            }
            return string.Join(" ", pieces);
        }

        private static string Below1000(int n)
        {
            var pieces = new List<string>();
            if (n >= 100) { pieces.Add(Small[n / 100] + " hundred"); n %= 100; }
            if (n >= 20) pieces.Add(n % 10 == 0 ? Tens[n / 10] : Tens[n / 10] + "-" + Small[n % 10]);
            else if (n > 0) pieces.Add(Small[n]);
            return string.Join(" ", pieces);
        }
    }
}
