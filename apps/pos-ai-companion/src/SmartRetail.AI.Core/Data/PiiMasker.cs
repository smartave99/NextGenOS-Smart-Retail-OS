using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Data
{
    /// <summary>Hides customer contact details before query results are sent to an AI provider.
    /// The shop still sees the real values on screen.</summary>
    public static class PiiMasker
    {
        private static readonly Regex ContactColumn = new Regex(
            @"contact|mobile|phone|email|address|zipcode|pincode|gstin|aadha?ar|^pan$|accountnumber|ifsc",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        // A mobile number as people write it: "9876543210", "98765 43210", "98765-43210", "+91 98765 43210".
        private static readonly Regex MobileNumber = new Regex(@"(?<!\d)(?:\+?91[\s-]?)?[6-9](?:[ -]?\d){9}(?!\d)", RegexOptions.CultureInvariant);

        // Any number dialled with 0, +91 or 0091 in front: a landline with its area code, "011-23456789",
        // "(0124) 456 7890", "+91 11 2345 6789", or a mobile with a 0 in front, "09876543210".
        private static readonly Regex DialledNumber = new Regex(@"(?<!\d)(?:(?:\+|00)91[\s-]?\(?|\(?0)[1-9](?:\)?[ -]?\d){9}(?!\d)", RegexOptions.CultureInvariant);

        private static readonly Regex EmailAddress = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}", RegexOptions.CultureInvariant);

        public static bool IsContactColumn(string columnName) => ContactColumn.IsMatch(columnName ?? "");

        public static QueryResult Mask(QueryResult result)
        {
            var contactColumns = result.Columns.Select(IsContactColumn).ToArray();
            var rows = result.Rows
                .Select(row => row.Select((value, i) => MaskValue(value, contactColumns[i])).ToArray())
                .ToList();
            return new QueryResult(result.Columns, rows, result.Truncated, result.Duration);
        }

        /// <summary>Free text, such as a chat message, with phone numbers and e-mail addresses hidden.</summary>
        public static string MaskText(string text)
        {
            return string.IsNullOrEmpty(text) ? text ?? "" : MaskNumbersAndAddresses(text);
        }

        private static object MaskValue(object value, bool isContactColumn)
        {
            if (!(value is string text))
            {
                return isContactColumn && value != null ? "[hidden]" : value;
            }

            if (isContactColumn)
            {
                return text.Trim().Length == 0 ? text : Partial(text.Trim());
            }

            return MaskNumbersAndAddresses(text);
        }

        private static string MaskNumbersAndAddresses(string text)
        {
            text = MobileNumber.Replace(text, m => Partial(m.Value));
            text = DialledNumber.Replace(text, m => Partial(m.Value));
            return EmailAddress.Replace(text, m => Partial(m.Value));
        }

        /// <summary>Keeps the first and last two characters so values stay distinguishable.</summary>
        internal static string Partial(string value)
        {
            if (value.Length <= 4)
            {
                return new string('*', value.Length);
            }

            return value.Substring(0, 2) + new string('*', Math.Min(6, value.Length - 4)) + value.Substring(value.Length - 2);
        }
    }
}
