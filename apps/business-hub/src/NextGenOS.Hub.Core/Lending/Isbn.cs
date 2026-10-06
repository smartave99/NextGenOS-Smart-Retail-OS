namespace NextGenOS.Hub.Lending;

/// <summary>ISBN check digits, so a mistyped number is caught at the desk.</summary>
public static class Isbn
{
    public static string Clean(string text) => new(text.Where(c => char.IsDigit(c) || c is 'X' or 'x').Select(char.ToUpperInvariant).ToArray());

    public static bool IsValid(string text)
    {
        var s = Clean(text);
        return s.Length switch { 10 => Valid10(s), 13 => Valid13(s), _ => false };
    }

    private static bool Valid13(string s)
    {
        if (!s.All(char.IsDigit)) return false;
        var sum = 0;
        for (var i = 0; i < 12; i++) sum += (s[i] - '0') * (i % 2 == 0 ? 1 : 3);
        return (10 - sum % 10) % 10 == s[12] - '0';
    }

    private static bool Valid10(string s)
    {
        var sum = 0;
        for (var i = 0; i < 10; i++)
        {
            int v;
            if (s[i] == 'X') { if (i != 9) return false; v = 10; }
            else if (char.IsDigit(s[i])) v = s[i] - '0';
            else return false;
            sum += v * (10 - i);
        }
        return sum % 11 == 0;
    }
}
