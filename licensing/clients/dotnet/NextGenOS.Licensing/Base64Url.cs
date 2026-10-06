using System;

namespace NextGenOS.Licensing
{
    /// <summary>base64url without padding (RFC 4648 section 5).</summary>
    public static class Base64Url
    {
        public static string Encode(byte[] data)
        {
            return Convert.ToBase64String(data).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }

        public static byte[] Decode(string text)
        {
            if (text == null) throw new FormatException("Nothing to decode.");
            var s = text.Replace('-', '+').Replace('_', '/');
            switch (s.Length % 4)
            {
                case 2: s += "=="; break;
                case 3: s += "="; break;
                case 1: throw new FormatException("Not base64url.");
            }
            return Convert.FromBase64String(s);
        }
    }
}
