using System.Text.RegularExpressions;

namespace NextGenOS.Hub.Ai;

/// <summary>What the owner allowed one AI service to receive. <see cref="Features"/> is "*" (every feature) or a comma-separated list of feature names.</summary>
public sealed record ConsentFact(string DataClass, string Features);

/// <summary>What the routing rules need to know about one AI service. It holds no secret and no connection.</summary>
public sealed record ProviderFacts(string Id, string Name, string Location, bool Enabled, IReadOnlySet<string> Tasks, string EndpointClass, IReadOnlyList<ConsentFact> Consents);

/// <summary>One question to the routing rules: this task, with this kind of data, for this feature.</summary>
/// <param name="RemoteAllowed">Is the switch "Use online AI services" on (and licensed)?</param>
/// <param name="Preferred">A service to try first when it is allowed (for example the one the owner picked for this feature).</param>
public sealed record RouteQuestion(string Task, string DataClass, string Feature, bool RemoteAllowed, string? Preferred = null);

/// <summary>What the rules decided about one service, and why, in words the owner can read.</summary>
public sealed record RouteStep(string ProviderId, string ProviderName, bool Allowed, string Reason);

/// <summary>The services that may be used, best first, and the reason for every service that was left out. <see cref="Refusal"/> is the sentence to show when none may be used.</summary>
public sealed record RouteDecision(IReadOnlyList<string> Order, IReadOnlyList<RouteStep> Trace, string? Refusal)
{
    public bool Allowed => Order.Count > 0;
}

/// <summary>
/// The privacy rules: which AI service may receive which kind of data. It is a pure function (no database, no network), so every rule can be tested, and it fails closed:
/// an unknown kind of data, an unknown place or a missing permission means "no".
/// <list type="bullet">
/// <item>Card and payment details, and biometric data (faces, fingerprints), never leave this computer. No setting and no permission changes that.</item>
/// <item>A service on this computer may receive any other kind of data.</item>
/// <item>A service on the shop's network may receive public and internal data; the rest needs the owner's permission for that service.</item>
/// <item>An online service (a tool the owner signed in to, or an online account) needs the switch "Use online AI services", and for everything but public data the owner's permission for that service and that kind of data.</item>
/// </list>
/// </summary>
public static class Routing
{
    /// <summary>The kinds of data that no AI service outside this computer may ever receive.</summary>
    public static bool NeverLeavesTheComputer(string dataClass) => dataClass is DataClass.Biometric or DataClass.PaymentSensitive;

    /// <summary>True when sending this kind of data to a service at this place needs the owner's permission.</summary>
    public static bool NeedsConsent(string dataClass, string location) => location switch
    {
        ProviderLocation.Local or ProviderLocation.LocalOptimized => false,
        ProviderLocation.Lan => dataClass is not (DataClass.Public or DataClass.Internal),
        _ => dataClass != DataClass.Public,
    };

    public static RouteDecision Decide(RouteQuestion question, IEnumerable<ProviderFacts> providers)
    {
        if (!DataClass.IsKnown(question.DataClass)) return new RouteDecision([], [], "The kind of data was not named, so nothing was sent to any AI service.");
        if (!AiTask.IsKnown(question.Task)) return new RouteDecision([], [], "The kind of work was not named, so nothing was sent to any AI service.");

        var trace = new List<RouteStep>();
        var allowed = new List<ProviderFacts>();
        foreach (var provider in providers)
        {
            var (ok, reason) = Judge(question, provider);
            trace.Add(new RouteStep(provider.Id, provider.Name, ok, reason));
            if (ok) allowed.Add(provider);
        }

        var order = allowed
            .OrderBy(p => p.Id == question.Preferred ? 0 : 1)
            .ThenBy(p => Rank(p.Location))
            .ThenBy(p => p.Id, StringComparer.Ordinal)
            .Select(p => p.Id)
            .ToList();
        return new RouteDecision(order, trace, order.Count > 0 ? null : Refusal(question, trace));
    }

    private static int Rank(string location)
    {
        var at = ProviderLocation.DefaultOrder.ToList().IndexOf(location);
        return at < 0 ? int.MaxValue : at;
    }

    private static (bool Allowed, string Reason) Judge(RouteQuestion q, ProviderFacts p)
    {
        if (!p.Enabled) return (false, "It is switched off.");
        if (!p.Tasks.Contains(q.Task)) return (false, "It does not do this kind of work (" + AiTask.Label(q.Task).ToLowerInvariant() + ").");
        if (!ProviderLocation.IsKnown(p.Location)) return (false, "Its place is not known, so it is not used.");

        // Where a service is said to be must be where its address points: a "local" service at an address on the internet is not local.
        var stays = ProviderLocation.StaysOnThisComputer(p.Location);
        if (stays && p.EndpointClass != EndpointClassifier.Loopback) return (false, "It is said to run on this computer, but its address does not point to this computer, so it is not treated as local.");
        if (p.Location == ProviderLocation.Lan && p.EndpointClass is not (EndpointClassifier.Loopback or EndpointClassifier.PrivateNetwork)) return (false, "It is said to be in the shop's network, but its address is not, so it is not used.");
        if (p.Location == ProviderLocation.Api && p.EndpointClass == EndpointClassifier.Invalid) return (false, "Its address is not a valid web address.");

        if (NeverLeavesTheComputer(q.DataClass) && !stays)
            return (false, DataClass.Label(q.DataClass) + " never leave this computer, whatever is allowed.");

        if (p.Location is ProviderLocation.Cli or ProviderLocation.Api && !q.RemoteAllowed)
            return (false, "Online AI services are switched off.");

        if (!NeedsConsent(q.DataClass, p.Location))
            return (true, stays ? "It runs on this computer." : "This kind of data may go there without asking.");

        var consent = p.Consents.FirstOrDefault(c => c.DataClass == q.DataClass && Covers(c.Features, q.Feature));
        return consent is null
            ? (false, "You have not allowed it to receive: " + DataClass.Label(q.DataClass).ToLowerInvariant() + ".")
            : (true, "You allowed it to receive: " + DataClass.Label(q.DataClass).ToLowerInvariant() + ".");
    }

    private static bool Covers(string features, string feature) =>
        features == "*" || features.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Contains(feature, StringComparer.Ordinal);

    private static string Refusal(RouteQuestion q, List<RouteStep> trace)
    {
        if (trace.Count == 0) return "No AI service is set up.";
        if (NeverLeavesTheComputer(q.DataClass)) return DataClass.Label(q.DataClass) + " never leave this computer, and no AI service on this computer is switched on for this kind of work.";
        // The most useful thing to tell the owner is the reason for a service that is on and does this kind of work.
        var relevant = trace.FirstOrDefault(s => !s.Reason.StartsWith("It is switched off", StringComparison.Ordinal) && !s.Reason.StartsWith("It does not do", StringComparison.Ordinal));
        return relevant is null
            ? "No AI service that does this kind of work is switched on."
            : relevant.ProviderName + ": " + relevant.Reason;
    }
}

/// <summary>
/// A second line of defence: what the text itself shows is taken into account, whatever the caller called it. A payment card number means payment data; an e-mail address or a telephone
/// number means personal data. It is a net with holes (a name on its own is not found), so the owner's permission stays the real guard for personal data.
/// </summary>
public static partial class TextGuard
{
    [GeneratedRegex(@"(?<![\d])(?:\d[ \-]?){13,19}(?![\d])", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex DigitRuns();

    [GeneratedRegex(@"[A-Za-z0-9._%+\-]{1,64}@[A-Za-z0-9\-]{1,63}(?:\.[A-Za-z0-9\-]{1,63})+", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex EmailAddress();

    [GeneratedRegex(@"(?<![\w])\+\d{1,3}[\s.\-]?\(?\d{1,4}\)?(?:[\s.\-]?\d{2,4}){2,4}(?![\w])", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex InternationalPhone();

    [GeneratedRegex(@"(?<!\d)\(?\d{3}\)?[\s.\-]\d{3}[\s.\-]\d{4}(?!\d)", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex GroupedPhone();

    /// <summary>An e-mail address or a telephone number written the usual ways ("+91 98765 43210", "(555) 123-4567"). A bare run of digits is not taken for one: it could be a barcode.</summary>
    public static bool ContainsContactDetails(string? text)
    {
        if (string.IsNullOrEmpty(text) || text.Length < 6) return false;
        try
        {
            return EmailAddress().IsMatch(text) || InternationalPhone().IsMatch(text) || GroupedPhone().IsMatch(text);
        }
        catch (RegexMatchTimeoutException)
        {
            return true;   // when in doubt, treat it as personal data
        }
    }

    public static bool ContainsCardNumber(string? text)
    {
        if (string.IsNullOrEmpty(text) || text.Length < 13) return false;
        try
        {
            foreach (Match match in DigitRuns().Matches(text))
            {
                var digits = new string(match.Value.Where(char.IsAsciiDigit).ToArray());
                if (digits.Length is >= 13 and <= 19 && Luhn(digits)) return true;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return true;   // when in doubt, treat it as payment data
        }

        return false;
    }

    private static bool Luhn(string digits)
    {
        var sum = 0;
        var doubleIt = false;
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            var d = digits[i] - '0';
            if (doubleIt) { d *= 2; if (d > 9) d -= 9; }
            sum += d;
            doubleIt = !doubleIt;
        }

        return sum % 10 == 0;
    }
}
