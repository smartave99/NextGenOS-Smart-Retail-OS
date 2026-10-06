using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Ai;

/// <summary>How a use of an AI service ended. A refused or over-budget request is written down too: what did not happen is part of the record.</summary>
public static class Outcome
{
    public const string Ok = "ok";
    public const string Failed = "failed";
    public const string Refused = "refused";
    public const string OverBudget = "over-budget";
}

public sealed record UsageEntry(string? ProviderId, string? Model, string Task, string Feature, string DataClass, int TokensIn, int TokensOut, long CostMicros, long DurationMs, string Outcome, string? Detail, long? UserId);

public sealed record UsageRow(long Id, DateTimeOffset At, string? ProviderId, string? Model, string Task, string Feature, string DataClass, int TokensIn, int TokensOut, long CostMicros, long DurationMs, string Outcome, string? Detail, long? UserId);

public sealed record UsageTotals(long Requests, long TokensIn, long TokensOut, long CostMicros)
{
    public long Tokens => TokensIn + TokensOut;

    public static readonly UsageTotals None = new(0, 0, 0, 0);
}

public sealed record ProviderUsage(string? ProviderId, UsageTotals Used, long Refused, long Failed, long OverBudget);

/// <summary>The money and limit rules, with no database in them.</summary>
public static class Budget
{
    /// <summary>What a call cost, in millionths of the shop's money. Prices are for 1,000 tokens; the result is rounded up so a cost is never shown as less than it was.</summary>
    public static long Cost(long tokensIn, long tokensOut, long? priceInMicrosPer1k, long? priceOutMicrosPer1k)
    {
        var micros = checked(tokensIn * (priceInMicrosPer1k ?? 0) + tokensOut * (priceOutMicrosPer1k ?? 0));
        return (micros + 999) / 1000;
    }

    /// <summary>The sentence to show when a limit stops the call, or null when the call may go ahead.</summary>
    public static string? Check(string providerName, ProviderLimits limits, UsageTotals today, UsageTotals month, long estimatedTokens)
    {
        if (limits.RequestsPerDay is { } perDay && today.Requests >= perDay) return providerName + " has reached its limit of " + perDay + " requests for today.";
        if (limits.TokensPerDay is { } tokensDay && today.Tokens + estimatedTokens > tokensDay) return providerName + " has reached its limit for today (" + tokensDay + " tokens).";
        if (limits.TokensPerMonth is { } tokensMonth && month.Tokens + estimatedTokens > tokensMonth) return providerName + " has reached its limit for this month (" + tokensMonth + " tokens).";
        if (limits.CostMicrosPerMonth is { } cost && month.CostMicros >= cost) return providerName + " has reached its spending limit for this month.";
        return null;
    }
}

/// <summary>The record of every use of an AI service (what, which service, how much it cost) and the limits it is held to. Days and months are counted in universal time.</summary>
public sealed class UsageService(HubDb db, IClock clock)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;

    public void Record(UsageEntry entry) => db.InTransaction((c, t) => HubDb.Exec(c,
        "INSERT INTO ai_usage(tenant_id, site_id, at, provider_id, model, task, feature, data_class, tokens_in, tokens_out, cost_micros, duration_ms, outcome, detail, user_id) " +
        "VALUES ($t, $s, $at, $p, $m, $task, $f, $c, $in, $out, $cost, $ms, $o, $d, $u)", t,
        ("$t", Tenant), ("$s", Site), ("$at", Iso.Text(clock.UtcNow)), ("$p", entry.ProviderId), ("$m", entry.Model), ("$task", entry.Task), ("$f", entry.Feature), ("$c", entry.DataClass),
        ("$in", entry.TokensIn), ("$out", entry.TokensOut), ("$cost", entry.CostMicros), ("$ms", entry.DurationMs), ("$o", entry.Outcome), ("$d", Trim(entry.Detail)), ("$u", entry.UserId)));

    public UsageTotals Today(string providerId) => Totals(providerId, new DateTimeOffset(clock.UtcNow.UtcDateTime.Date, TimeSpan.Zero));

    public UsageTotals ThisMonth(string providerId)
    {
        var now = clock.UtcNow.UtcDateTime;
        return Totals(providerId, new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, TimeSpan.Zero));
    }

    /// <summary>What was used since a time, counting only the calls that went through.</summary>
    public UsageTotals Totals(string providerId, DateTimeOffset since) => db.Query(
        "SELECT COUNT(*) AS n, COALESCE(SUM(tokens_in), 0) AS i, COALESCE(SUM(tokens_out), 0) AS o, COALESCE(SUM(cost_micros), 0) AS c FROM ai_usage " +
        "WHERE tenant_id = $t AND site_id = $s AND provider_id = $p AND outcome = 'ok' AND at >= $since",
        r => new UsageTotals(r.Int("n"), r.Int("i"), r.Int("o"), r.Int("c")), ("$t", Tenant), ("$s", Site), ("$p", providerId), ("$since", Iso.Text(since))).Single();

    /// <summary>One line for every service used since a time, and one for what was refused before any service was chosen.</summary>
    public IReadOnlyList<ProviderUsage> Summary(DateTimeOffset since) => db.Query(
        "SELECT provider_id, " +
        "SUM(CASE WHEN outcome = 'ok' THEN 1 ELSE 0 END) AS n, " +
        "COALESCE(SUM(CASE WHEN outcome = 'ok' THEN tokens_in ELSE 0 END), 0) AS i, COALESCE(SUM(CASE WHEN outcome = 'ok' THEN tokens_out ELSE 0 END), 0) AS o, " +
        "COALESCE(SUM(CASE WHEN outcome = 'ok' THEN cost_micros ELSE 0 END), 0) AS c, " +
        "SUM(CASE WHEN outcome = 'refused' THEN 1 ELSE 0 END) AS refused, SUM(CASE WHEN outcome = 'failed' THEN 1 ELSE 0 END) AS failed, SUM(CASE WHEN outcome = 'over-budget' THEN 1 ELSE 0 END) AS over " +
        "FROM ai_usage WHERE tenant_id = $t AND site_id = $s AND at >= $since GROUP BY provider_id ORDER BY provider_id",
        r => new ProviderUsage(r.TextOrNull("provider_id"), new UsageTotals(r.Int("n"), r.Int("i"), r.Int("o"), r.Int("c")), r.Int("refused"), r.Int("failed"), r.Int("over")),
        ("$t", Tenant), ("$s", Site), ("$since", Iso.Text(since)));

    public IReadOnlyList<UsageRow> Recent(int limit = 50) => db.Query(
        "SELECT id, at, provider_id, model, task, feature, data_class, tokens_in, tokens_out, cost_micros, duration_ms, outcome, detail, user_id FROM ai_usage " +
        "WHERE tenant_id = $t AND site_id = $s ORDER BY id DESC LIMIT $n",
        r => new UsageRow(r.Int("id"), r.Time("at"), r.TextOrNull("provider_id"), r.TextOrNull("model"), r.Text("task"), r.Text("feature"), r.Text("data_class"), (int)r.Int("tokens_in"),
            (int)r.Int("tokens_out"), r.Int("cost_micros"), r.Int("duration_ms"), r.Text("outcome"), r.TextOrNull("detail"), r.IntOrNull("user_id")),
        ("$t", Tenant), ("$s", Site), ("$n", Math.Clamp(limit, 1, 500)));

    // What a service says in an error can be long, and must never fill the record.
    private static string? Trim(string? text) => text is null ? null : text.Length <= 300 ? text : text[..300] + "…";
}
