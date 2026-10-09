namespace NextGenOS.Hub.Shop;

/// <summary>One thing a key can do at the till, with the key it has until the shop chooses another.</summary>
public sealed record TillAction(string Id, string Label, string Short, string Default);

/// <summary>
/// The keys of the sell screen (the older POS, docs/old-programs/04 D: its function keys did different jobs in different tills, the help list could disagree with the code, and a customer could not change them).
/// Here there is one map for the sell screen. It is data: the shop chooses the key of each action (or none), the screen shows the keys that are really in force, and a key can be used only once. A key is a
/// function key (F1 to F12), or Ctrl or Alt with a letter or a digit; a plain letter would be lost in the middle of typing.
/// </summary>
public static class TillKeys
{
    public static readonly IReadOnlyList<TillAction> Actions =
    [
        new("scan", "Go to the box where you scan or search", "scan", "F2"),
        new("customer", "Go to the customer box", "customer", "F4"),
        new("amount", "Go to the amount received", "amount", "F8"),
        new("drawer", "Open the cash drawer", "drawer", "F6"),
        new("complete", "Complete the sale", "complete", "F12"),
    ];

    /// <summary>The key of each action in force now: the shop's own choice where it made one (an empty text means no key), else the starting key.</summary>
    public static IReadOnlyDictionary<string, string> Effective(IReadOnlyDictionary<string, string>? chosen) =>
        Actions.ToDictionary(a => a.Id, a => chosen is not null && chosen.TryGetValue(a.Id, out var key) ? key : a.Default);

    /// <summary>A key as it is written on screen and kept: "f2" becomes "F2", "ctrl + s" becomes "Ctrl+S". Empty means no key. Null when it is not a key the till can use.</summary>
    public static string? Normalize(string? text)
    {
        var typed = (text ?? "").Trim();
        if (typed.Length == 0) return "";
        var parts = typed.Split('+', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return null;
        bool ctrl = false, alt = false, shift = false;
        foreach (var modifier in parts[..^1])
        {
            switch (modifier.ToLowerInvariant())
            {
                case "ctrl" or "control": ctrl = true; break;
                case "alt": alt = true; break;
                case "shift": shift = true; break;
                default: return null;
            }
        }
        var key = parts[^1].ToUpperInvariant();
        var isFunction = key.Length is 2 or 3 && key[0] == 'F' && int.TryParse(key[1..], out var n) && n is >= 1 and <= 12 && key[1] != '0';
        var isLetterOrDigit = key.Length == 1 && (char.IsAsciiLetterOrDigit(key[0]));
        if (!isFunction && !(isLetterOrDigit && (ctrl || alt))) return null;
        return (ctrl ? "Ctrl+" : "") + (alt ? "Alt+" : "") + (shift ? "Shift+" : "") + key;
    }

    /// <summary>Why a set of keys cannot be used (in plain words), or null when it can: every key must be one the till can use, and no key may do two things.</summary>
    public static string? Problem(IReadOnlyDictionary<string, string> keys)
    {
        foreach (var action in Actions)
        {
            if (!keys.TryGetValue(action.Id, out var key)) continue;
            if (Normalize(key) is null) return $"\"{key}\" cannot be used for \"{action.Label.ToLowerInvariant()}\". Use a function key like F2, or Ctrl or Alt with a letter or a number, like Ctrl+S.";
        }
        var used = keys.Where(k => !string.IsNullOrEmpty(Normalize(k.Value))).GroupBy(k => Normalize(k.Value)!).FirstOrDefault(g => g.Count() > 1);
        if (used is not null) return $"{used.Key} is chosen for more than one thing. Give each its own key.";
        return null;
    }
}
