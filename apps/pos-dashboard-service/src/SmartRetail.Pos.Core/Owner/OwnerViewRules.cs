using System.Text.Json;

namespace SmartRetail.Pos.Core.Owner;

/// <summary>What the owner types to connect this PC to their Supabase project, checked before anything is sent.</summary>
public static class OwnerViewRules
{
    /// <summary>One-time codes: 8 letters and digits that are easy to read (no 0, O, 1 or I), shown as ABCD-EFGH.</summary>
    public const int CodeLength = 8;
    public const string CodeLetters = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

    private const int MaxKeyLength = 2048;

    /// <summary>The project's address as "https://host", or null with the reason in <paramref name="problem"/>. Plain
    /// http is only for a project on this PC itself (Supabase's local test setup).</summary>
    public static string? ProjectUrl(string? text, out string? problem)
    {
        problem = null;
        var value = (text ?? "").Trim().TrimEnd('/');
        if (!Uri.TryCreate(value, UriKind.Absolute, out var uri)
            || !(uri.Scheme == Uri.UriSchemeHttps || (uri.Scheme == Uri.UriSchemeHttp && uri.IsLoopback)) || uri.Host.Length == 0
            || uri.UserInfo.Length > 0 || uri.AbsolutePath != "/" || uri.Query.Length > 0 || uri.Fragment.Length > 0)
        {
            problem = "Paste the project URL from Supabase (Project Settings, then Data API), like https://abcd.supabase.co.";
            return null;
        }

        return uri.GetLeftPart(UriPartial.Authority);
    }

    /// <summary>The project's public key, or null with the reason. A secret key is refused: this PC must never hold one.</summary>
    public static string? PublicKey(string? text, out string? problem)
    {
        problem = null;
        var key = (text ?? "").Trim();
        var role = JwtRole(key);
        if (key.StartsWith("sb_secret_", StringComparison.Ordinal) || role == "service_role")
        {
            problem = "That is the project's secret key, which must never leave Supabase. Paste the public key: \"anon public\" or \"publishable\".";
            return null;
        }

        if (key.Length is 0 or > MaxKeyLength || !key.All(IsKeyCharacter)
            || !(key.StartsWith("sb_publishable_", StringComparison.Ordinal) || role == "anon"))
        {
            problem = "Paste the project's public key from Supabase (Project Settings, then API Keys): \"anon public\" or \"publishable\".";
            return null;
        }

        return key;
    }

    /// <summary>Whether the key is a JSON Web Token (the older keys), which is also sent as the bearer token.</summary>
    public static bool IsJwt(string key) => JwtRole(key) is not null;

    /// <summary>"abcd-efgh" or "ABCD EFGH" as "ABCDEFGH"; null when it cannot be a code.</summary>
    public static string? Code(string? text)
    {
        var code = new string((text ?? "").Where(c => !char.IsWhiteSpace(c) && c != '-').ToArray()).ToUpperInvariant();
        return code.Length == CodeLength && code.All(c => CodeLetters.Contains(c)) ? code : null;
    }

    /// <summary>The "role" of a JSON Web Token such as Supabase's older keys; null when the key is not one.</summary>
    private static string? JwtRole(string key)
    {
        var parts = key.Split('.');
        if (parts.Length != 3 || parts[1].Length is 0 or > MaxKeyLength)
        {
            return null;
        }

        try
        {
            var payload = parts[1].Replace('-', '+').Replace('_', '/');
            payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
            using var json = JsonDocument.Parse(Convert.FromBase64String(payload));
            return json.RootElement.ValueKind == JsonValueKind.Object
                && json.RootElement.TryGetProperty("role", out var role) && role.ValueKind == JsonValueKind.String
                ? role.GetString()
                : null;
        }
        catch (Exception ex) when (ex is FormatException or JsonException)
        {
            return null;
        }
    }

    private static bool IsKeyCharacter(char c) => char.IsAsciiLetterOrDigit(c) || c is '.' or '_' or '-';
}
