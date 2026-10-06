using System.Text;

namespace NextGenOS.Licensing
{
    /// <summary>Licence keys look like NGOS-XXXXX-XXXXX-XXXXX-XXXXX. People type them, so spaces, case and look-alike letters are forgiven.</summary>
    public static class LicenceKey
    {
        /// <summary>The canonical key, or null when the text cannot be a key.</summary>
        public static string Normalise(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            var sb = new StringBuilder();
            foreach (var ch in text.ToUpperInvariant())
            {
                if ((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'Z')) sb.Append(ch);
            }
            var s = sb.ToString();
            if (s.StartsWith("NGOS")) s = s.Substring(4);
            s = s.Replace('O', '0').Replace('I', '1').Replace('L', '1');
            if (s.Length != 20) return null;
            foreach (var ch in s)
            {
                if (!"0123456789ABCDEFGHJKMNPQRSTVWXYZ".Contains(ch.ToString())) return null;
            }
            return "NGOS-" + s.Substring(0, 5) + "-" + s.Substring(5, 5) + "-" + s.Substring(10, 5) + "-" + s.Substring(15, 5);
        }
    }
}
