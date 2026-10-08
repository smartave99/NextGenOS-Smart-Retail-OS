using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Ai;

/// <summary>How a value that may be sent to an AI service is shaped. Free text is not one of them: nothing a person typed as a remark, a note or a message can be sent.</summary>
public static class FieldKind
{
    /// <summary>A short name of a thing (a product, a category): at most 8 words of letters, digits and a few marks. Not a sentence, not an address, not a person's name known to the shop.</summary>
    public const string Label = "label";
    /// <summary>A code or unit: letters, digits, dots, dashes and underscores, no spaces.</summary>
    public const string Code = "code";
    /// <summary>A whole number.</summary>
    public const string Number = "number";
    /// <summary>An amount with up to three decimals.</summary>
    public const string Money = "money";
    /// <summary>A day, written 2026-10-08.</summary>
    public const string Date = "date";
    /// <summary>One of a short list of words.</summary>
    public const string Choice = "choice";
}

/// <summary>One thing a purpose may send: its name, its shape, how private it is, and whether the purpose cannot go on without it.</summary>
public sealed record EgressField(string Name, string Kind, string DataClass, bool Required = false, IReadOnlyList<string>? Choices = null, int MaxLength = 60);

/// <summary>
/// A reason to send something to an AI service, written in code (blueprint AI-014). It says which feature it belongs to, which switch must be on, what the service is asked to do (a fixed
/// instruction that no data can change) and exactly which fields may be sent. Anything else supplied with a request is left out, and the record says its name (never its value).
/// </summary>
public sealed record EgressPurpose(string Id, string Title, string Feature, string Flag, string Task, string Instruction, IReadOnlyList<EgressField> Fields, int MaxTokens = 200)
{
    /// <summary>The most private kind among the fields: what the request is treated as when nothing smaller is known.</summary>
    public string MostPrivateClass => Fields.Select(f => f.DataClass).OrderByDescending(EgressGuard.Rank).FirstOrDefault() ?? DataClass.Public;
}

/// <summary>The closed list of purposes. A purpose that is not here cannot send anything.</summary>
public static class EgressPurposes
{
    public static readonly EgressPurpose LowStockExplain = new(
        "low_stock_explain", "Explain a running-low warning in one sentence", "insights", FlagKey.PredictiveInventory, AiTask.Generate,
        "You help a shop owner. In one short, friendly sentence of plain words, say why the item below may run out before its next delivery. Use only the figures given. Give no orders and mention nothing else.",
        [
            new("item", FieldKind.Label, DataClass.Internal, Required: true), new("unit", FieldKind.Code, DataClass.Internal, MaxLength: 12), new("on_hand", FieldKind.Number, DataClass.Internal, Required: true),
            new("sold", FieldKind.Number, DataClass.Internal, Required: true), new("days_looked_at", FieldKind.Number, DataClass.Internal, Required: true), new("delivery_days", FieldKind.Number, DataClass.Internal, Required: true),
            new("spare_days", FieldKind.Number, DataClass.Internal),
        ]);

    public static readonly EgressPurpose ProductDescription = new(
        "product_description", "Write a short description of a product for the shop's website", "storefront", FlagKey.AiAssistant, AiTask.Generate,
        "You write for a shop's website. In two short sentences of plain words, describe the product below for a shopper. Use only what is given. Do not invent facts, prices or offers.",
        [new("name", FieldKind.Label, DataClass.Public, Required: true), new("category", FieldKind.Label, DataClass.Public), new("tone", FieldKind.Choice, DataClass.Public, Choices: ["plain", "friendly", "formal"], MaxLength: 12)]);

    public static readonly IReadOnlyList<EgressPurpose> All = [LowStockExplain, ProductDescription];

    public static EgressPurpose? Find(string? id) => All.FirstOrDefault(p => p.Id == id);
}

/// <summary>What a feature asks to send: a purpose from the list and the values it has for that purpose's fields, by name. Extra values are left out.</summary>
public sealed record EgressRequest(string Purpose, IReadOnlyDictionary<string, string> Fields);

/// <summary>What the guard made of a request: the text to send (or why nothing is sent), and the field-by-field account that is written down.</summary>
public sealed record EgressBuild(bool Ok, string? Refusal, string Text, string DataClass, IReadOnlyList<EgressSent> Sent, IReadOnlyList<string> Dropped);

/// <summary>One field that went (or would have gone): its name, its kind of data and its length. Never the value.</summary>
public sealed record EgressSent(string Name, string DataClass, int Length);

/// <summary>
/// The rules about what may leave. Pure: no database, no network. It builds the text from the purpose's fixed instruction and the allowed fields only, and refuses (sending nothing) when an
/// allowed field holds something that is not the shape it should be, looks like a card number, a telephone number, an address, a person's name the shop knows, a link, or an instruction to
/// the service ("ignore the above…").
/// </summary>
public static partial class EgressGuard
{
    [GeneratedRegex(@"^[\p{L}\p{N}][\p{L}\p{M}\p{N} \-_.,()/&'%+]*$", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex LabelShape();

    [GeneratedRegex(@"^[A-Za-z0-9._\-]{1,40}$", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex CodeShape();

    [GeneratedRegex(@"^-?\d{1,15}$", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex NumberShape();

    [GeneratedRegex(@"^-?\d{1,12}(\.\d{1,3})?$", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex MoneyShape();

    [GeneratedRegex(@"(https?:|www\.|ftp:|[a-z0-9\-]+\.(com|net|org|io|in|co|app|dev)\b)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, matchTimeoutMilliseconds: 250)]
    private static partial Regex Link();

    [GeneratedRegex(@"\b(ignore|disregard|forget|override|bypass)\b.{0,30}\b(above|previous|prior|earlier|instructions?|rules?|prompt)\b|\bsystem\s+prompt\b|\byou\s+are\s+(now|a|an)\b|\bact\s+as\b|\bpretend\b|\bjailbreak\b|\b(reveal|print|show|send|list)\b.{0,30}\b(all|every|customers?|passwords?|keys?|secrets?|database|table)\b",
        RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, matchTimeoutMilliseconds: 250)]
    private static partial Regex InstructionLike();

    /// <summary>How private a kind of data is, for choosing the strictest among several: the order of <see cref="DataClass.All"/>.</summary>
    public static int Rank(string dataClass) => Math.Max(0, DataClass.All.ToList().IndexOf(dataClass));

    public static EgressBuild Build(EgressPurpose purpose, IReadOnlyDictionary<string, string> supplied, IReadOnlyCollection<string> knownPeople)
    {
        var allowed = purpose.Fields.ToDictionary(f => f.Name, StringComparer.Ordinal);
        var dropped = supplied.Keys.Where(k => !allowed.ContainsKey(k)).Order(StringComparer.Ordinal).ToList();
        var sent = new List<EgressSent>();
        var text = new StringBuilder(purpose.Instruction).Append("\n\nFigures:");
        var strictest = DataClass.Public;
        foreach (var field in purpose.Fields)
        {
            if (!supplied.TryGetValue(field.Name, out var raw) || string.IsNullOrWhiteSpace(raw))
            {
                if (field.Required) return Refused("The field “" + field.Name + "” is needed for this and was not given.", dropped);
                continue;
            }

            var value = raw.Trim();
            if (Problem(field, value, knownPeople) is { } problem) return Refused("The value of “" + field.Name + "” cannot be sent: " + problem, dropped);
            sent.Add(new EgressSent(field.Name, field.DataClass, value.Length));
            if (Rank(field.DataClass) > Rank(strictest)) strictest = field.DataClass;
            text.Append("\n- ").Append(field.Name).Append(": ").Append(value);
        }

        return new EgressBuild(true, null, text.ToString(), strictest, sent, dropped);
    }

    private static EgressBuild Refused(string why, IReadOnlyList<string> dropped) => new(false, why, "", DataClass.Public, [], dropped);

    /// <summary>Why this value may not be sent in this field, in words that do not repeat it, or null when it may.</summary>
    private static string? Problem(EgressField field, string value, IReadOnlyCollection<string> knownPeople)
    {
        if (value.Length > field.MaxLength) return "it is longer than this field allows.";
        if (value.Any(char.IsControl)) return "it has line breaks or other characters that cannot be sent.";
        if (TextGuard.ContainsCardNumber(value)) return "it looks like a card number, which never leaves this computer.";
        if (TextGuard.ContainsContactDetails(value)) return "it looks like an e-mail address or a telephone number.";
        if (Link().IsMatch(value)) return "it looks like a link.";
        try
        {
            switch (field.Kind)
            {
                case FieldKind.Number when !NumberShape().IsMatch(value): return "it is not a whole number.";
                case FieldKind.Money when !MoneyShape().IsMatch(value): return "it is not an amount.";
                case FieldKind.Code when !CodeShape().IsMatch(value): return "it is not a short code.";
                case FieldKind.Date when !DateOnly.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _): return "it is not a day written like 2026-10-08.";
                case FieldKind.Choice when field.Choices is null || !field.Choices.Contains(value, StringComparer.Ordinal): return "it is not one of the words this field accepts.";
                case FieldKind.Label:
                    if (!LabelShape().IsMatch(value)) return "it is not a short name (letters, digits and a few marks only).";
                    if (value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length > 8) return "it is longer than a short name (at most 8 words).";
                    if (InstructionLike().IsMatch(value)) return "it reads like an instruction to the service.";
                    break;
            }

            if (field.Kind is FieldKind.Label or FieldKind.Code && NamesAPerson(value, knownPeople)) return "it contains the name of a person or an address the shop knows.";
        }
        catch (RegexMatchTimeoutException)
        {
            return "it could not be checked.";
        }

        return null;
    }

    /// <summary>
    /// True when the value holds a name or an address the shop keeps for a customer, supplier or member of staff: a name of several words anywhere in it, a first name or a surname when it is the
    /// whole value, a one-word name only when it is the whole value; a line of an address anywhere in it. (A product that has the same name as a customer is refused too: asking is cheap, leaking is not.)
    /// </summary>
    internal static bool NamesAPerson(string value, IReadOnlyCollection<string> knownPeople)
    {
        var v = value.Trim();
        foreach (var known in knownPeople)
        {
            var k = known.Trim();
            if (k.Length < 3) continue;
            if (k.Contains(' ') || k.Length >= 12) { if (v.Contains(k, StringComparison.OrdinalIgnoreCase)) return true; }
            else if (v.Equals(k, StringComparison.OrdinalIgnoreCase)) return true;
            // A first name or a surname on its own is enough to point at a person.
            if (k.Contains(' ') && k.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Any(w => w.Length >= 3 && v.Equals(w, StringComparison.OrdinalIgnoreCase))) return true;
        }

        return false;
    }
}

/// <summary>The names and addresses the shop keeps for people, read fresh for each request so that a person added a minute ago is already protected. Read only; nothing leaves.</summary>
public sealed class PersonalValues(HubDb db)
{
    public IReadOnlyList<string> Known()
    {
        var found = db.Query("SELECT name FROM parties UNION SELECT display_name FROM users UNION SELECT address FROM parties WHERE address IS NOT NULL AND length(address) >= 6", r => r.GetString(0));
        // An address is known whole and line by line ("12 Garden Lane, Pune 411001": the street, then the town), so that part of it given alone is still caught.
        return found.Concat(found.Where(a => a.Contains(',')).SelectMany(a => a.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).Where(part => part.Length >= 8)).Distinct().ToList();
    }
}

/// <summary>What the egress log is told about the request it belongs to.</summary>
public sealed record EgressNote(string Purpose, IReadOnlyList<EgressSent> Sent, IReadOnlyList<string> Dropped);

/// <summary>One row of what left (or was stopped from leaving), for the owner's screen.</summary>
public sealed record EgressRow(long Id, DateTimeOffset At, string? ProviderId, string? Model, string? Location, string Purpose, string Feature, string DataClass, string? ConsentVersion,
    IReadOnlyList<EgressSent> Fields, IReadOnlyList<string> Dropped, string Outcome, int TokensIn, int TokensOut, long CostMicros, string? Detail);

/// <summary>The record of what was sent to AI services, field by field (names, kinds and lengths; never values).</summary>
public sealed class EgressLog(HubDb db, IClock clock, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

    internal void Record(EgressNote note, string feature, string dataClass, ProviderRecord? provider, string? consentVersion, string? model, string outcome, int tokensIn, int tokensOut, long costMicros, string? detail, long? userId) =>
        db.InTransaction((c, t) => HubDb.Exec(c,
            "INSERT INTO ai_egress_log(tenant_id, site_id, at, provider_id, model, location, purpose, feature, data_class, consent_version, fields, dropped, outcome, tokens_in, tokens_out, cost_micros, detail, user_id) " +
            "VALUES ($t, $s, $at, $p, $m, $l, $pu, $f, $c, $cv, $fi, $dr, $o, $ti, $to, $co, $d, $u)", t,
            ("$t", Tenant), ("$s", Site), ("$at", Iso.Text(clock.UtcNow)), ("$p", provider?.Id), ("$m", model), ("$l", provider?.Location), ("$pu", note.Purpose), ("$f", feature), ("$c", dataClass), ("$cv", consentVersion),
            ("$fi", JsonSerializer.Serialize(note.Sent, Json)), ("$dr", JsonSerializer.Serialize(note.Dropped, Json)), ("$o", outcome), ("$ti", tokensIn), ("$to", tokensOut), ("$co", costMicros),
            ("$d", detail is { Length: > 300 } ? detail[..300] : detail), ("$u", userId)));

    public IReadOnlyList<EgressRow> Recent(int limit = 50)
    {
        access.Require(Perm.Ai);
        return db.Query(
            "SELECT id, at, provider_id, model, location, purpose, feature, data_class, consent_version, fields, dropped, outcome, tokens_in, tokens_out, cost_micros, detail FROM ai_egress_log WHERE tenant_id = $t AND site_id = $s ORDER BY id DESC LIMIT $n",
            r => new EgressRow(r.Int("id"), r.Time("at"), r.TextOrNull("provider_id"), r.TextOrNull("model"), r.TextOrNull("location"), r.Text("purpose"), r.Text("feature"), r.Text("data_class"), r.TextOrNull("consent_version"),
                JsonSerializer.Deserialize<List<EgressSent>>(r.Text("fields"), Json) ?? [], JsonSerializer.Deserialize<List<string>>(r.Text("dropped"), Json) ?? [], r.Text("outcome"), (int)r.Int("tokens_in"), (int)r.Int("tokens_out"),
                r.Int("cost_micros"), r.TextOrNull("detail")), ("$t", Tenant), ("$s", Site), ("$n", Math.Clamp(limit, 1, 500)));
    }
}
