using System;
using System.Numerics;
using System.Text;

namespace NextGenOS.Tax
{
    /// <summary>Money as exact text: parsing "199.50" into minor units, and showing an amount the way the country writes it.</summary>
    public static class MoneyText
    {
        /// <summary>"199.50" with 2 decimals is 19950. Fewer digits are allowed ("199.5"), more are refused.</summary>
        public static BigInteger Parse(string text, int decimals)
        {
            if (text == null) throw new FormatException("No amount given.");
            var s = text.Trim();
            var dot = s.IndexOf('.');
            var whole = dot < 0 ? s : s.Substring(0, dot);
            var frac = dot < 0 ? string.Empty : s.Substring(dot + 1);
            if (whole.Length == 0 || !AllDigits(whole) || (dot >= 0 && (frac.Length == 0 || !AllDigits(frac)))) throw new FormatException("\"" + text + "\" is not an amount.");
            if (frac.Length > decimals) throw new FormatException("\"" + text + "\" has more than " + decimals + " decimals.");
            return BigInteger.Parse(whole + frac.PadRight(decimals, '0'));
        }

        /// <summary>19950 with 2 decimals is "199.50".</summary>
        public static string Minor(BigInteger value, int decimals)
        {
            var negative = value.Sign < 0;
            var digits = BigInteger.Abs(value).ToString().PadLeft(decimals + 1, '0');
            var body = decimals == 0 ? digits : digits.Substring(0, digits.Length - decimals) + "." + digits.Substring(digits.Length - decimals);
            return negative ? "-" + body : body;
        }

        /// <summary>
        /// The amount as a person reads it in this currency: "₹12,34,567.50", "1.234,50 €", "-$5.00". The input is an amount as the engine gives it
        /// ("1234567.5" is read as 1234567.50).
        /// </summary>
        public static string Format(string amount, CurrencyInfo currency)
        {
            var negative = amount != null && amount.TrimStart().StartsWith("-", StringComparison.Ordinal);
            var minor = Parse(negative ? amount.Trim().Substring(1) : amount, currency.Decimals);
            var plain = Minor(minor, currency.Decimals);
            var dot = plain.IndexOf('.');
            var whole = dot < 0 ? plain : plain.Substring(0, dot);
            var frac = dot < 0 ? string.Empty : plain.Substring(dot + 1);
            var grouped = Group(whole, currency.Grouping, currency.GroupSeparator);
            var number = frac.Length == 0 ? grouped : grouped + currency.DecimalSeparator + frac;
            var space = currency.SymbolSpace ? " " : string.Empty;
            var shown = currency.SymbolPosition == "after" ? number + space + currency.Symbol : currency.Symbol + space + number;
            return negative && minor.Sign != 0 ? "-" + shown : shown;
        }

        private static string Group(string whole, string style, string separator)
        {
            if (style == "none" || whole.Length <= 3) return whole;
            var sb = new StringBuilder();
            var tail = whole.Substring(whole.Length - 3);
            var head = whole.Substring(0, whole.Length - 3);
            var size = style == "indian" ? 2 : 3;
            var parts = new System.Collections.Generic.List<string>();
            while (head.Length > size)
            {
                parts.Insert(0, head.Substring(head.Length - size));
                head = head.Substring(0, head.Length - size);
            }
            if (head.Length > 0) parts.Insert(0, head);
            parts.Add(tail);
            for (var i = 0; i < parts.Count; i++)
            {
                if (i > 0) sb.Append(separator);
                sb.Append(parts[i]);
            }
            return sb.ToString();
        }

        private static bool AllDigits(string s)
        {
            foreach (var ch in s) if (ch < '0' || ch > '9') return false;
            return s.Length > 0;
        }
    }
}
