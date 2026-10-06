using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Web.Services;

/// <summary>The "Ai" section of appsettings.json.</summary>
public sealed class AiOptions
{
    public const string SectionName = "Ai";

    /// <summary>The AI settings file. Empty: the one the AI side panel uses, so an AI tool set up there works here.</summary>
    public string SettingsFile { get; set; } = "";

    public string SettingsFilePath => string.IsNullOrWhiteSpace(SettingsFile) ? SettingsStore.DefaultFilePath : SettingsFile;

    /// <summary>Where the customer's AI profile (profile/ai.json) is looked for. Empty: beside the program, and the folder above it.</summary>
    public string ProfileFolder { get; set; } = "";
}

/// <summary>Whether an AI tool can answer: the one that will, or why none can.</summary>
public sealed record AiReadiness(bool Ready, string Provider, IReadOnlyList<string> Problems);

public sealed record SavedPlan(string FileName, DateTime Written, string Period, string Provider);

public sealed record WrittenPlan(string Text, string Provider, TimeSpan Duration, SavedPlan Saved);

/// <summary>
/// Asks the AI tool set up in the side panel (Codex CLI first by default) for a plan to grow sales. The AI gets a
/// <see cref="SalesBrief"/> (figures and product names only, never customer details) and what the assistant
/// remembers, such as what the shop tried before and how it went. Each plan is kept as a Markdown file so the owner
/// can read it again.
/// </summary>
public sealed partial class GrowthPlanService
{
    private readonly AiEnvironment _ai;
    private readonly ProductPhotoService _photos;
    private readonly StorageService _storage;
    private readonly MemoryService _memory;
    private readonly ActionService _actions;

    public GrowthPlanService(AiEnvironment ai, ProductPhotoService photos, StorageService storage, MemoryService memory, ActionService actions)
    {
        _ai = ai;
        _photos = photos;
        _storage = storage;
        _memory = memory;
        _actions = actions;
    }

    /// <summary>The "Growth plans" folder in the data folder the owner chose.</summary>
    public string PlansFolder => _storage.PlansFolder;

    public async Task<AiReadiness> CheckAsync(CancellationToken ct)
    {
        var router = _ai.CreateRouter();
        var problems = new List<string>();
        foreach (var provider in router.PlanOrder(ProviderIds.Auto))
        {
            var status = await router.GetStatusAsync(provider, refresh: true, ct);
            if (status.IsReady)
            {
                return new AiReadiness(true, provider.DisplayName, problems);
            }

            problems.Add(provider.DisplayName + ": " + status.Detail);
        }

        return new AiReadiness(false, "", problems);
    }

    public async Task<WrittenPlan> WriteAsync(SalesReport report, PlanLanguage language, string? goal, IProgress<string>? progress, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(report);
        var router = _ai.CreateRouter(AiJob.Plan);
        var request = new AiRequest
        {
            SystemPrompt = GrowthPlanPrompt.SystemPrompt,
            UserPrompt = GrowthPlanPrompt.UserPrompt(Brief(report), language, goal, _memory.Snapshot(), _actions.DoingNow()),
        };

        var response = await router.CompleteAsync(request, ProviderIds.Auto, ct, progress);
        var provider = router.Find(response.ProviderId)?.DisplayName ?? response.ProviderId;
        var text = response.Text.Trim();
        return new WrittenPlan(text, provider, response.Duration, Save(report.Range, text, provider));
    }

    /// <summary>The latest saved plans, newest first.</summary>
    public IReadOnlyList<SavedPlan> RecentPlans(int count = 8)
    {
        if (!Directory.Exists(PlansFolder))
        {
            return Array.Empty<SavedPlan>();
        }

        return Directory.EnumerateFiles(PlansFolder, "plan-*.md")
            .Select(Path.GetFileName)
            .Where(name => name is not null && PlanFileName().IsMatch(name))
            .OrderByDescending(name => name, StringComparer.Ordinal)
            .Take(count)
            .Select(name => Describe(name!))
            .ToList();
    }

    /// <summary>A saved plan's text, or null. Only plan files in the plans folder can be read.</summary>
    public (SavedPlan Plan, string Text)? Read(string? fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName) || !PlanFileName().IsMatch(fileName))
        {
            return null;
        }

        var path = Path.Combine(PlansFolder, fileName);
        if (!File.Exists(path))
        {
            return null;
        }

        var lines = File.ReadAllLines(path, Encoding.UTF8);
        var text = string.Join('\n', lines.SkipWhile(line => line.StartsWith("<!--", StringComparison.Ordinal)).SkipWhile(string.IsNullOrWhiteSpace));
        return (Describe(fileName), text);
    }

    /// <summary>The text the AI gets, with what each product is where a product photo taught the AI.</summary>
    public string Brief(SalesReport report) => SalesBrief.Write(report, _photos.WhatItIs);

    private SavedPlan Save(DateRange range, string text, string provider)
    {
        Directory.CreateDirectory(PlansFolder);
        var written = DateTime.Now;
        var fileName = $"plan-{written:yyyyMMdd-HHmmss}.md";
        var period = Period(range);
        var header = $"<!-- Smart Retail POS: plan to grow sales | period: {period} | written by: {provider.Replace("--", "-")} -->";
        File.WriteAllText(Path.Combine(PlansFolder, fileName), header + "\n\n" + text + "\n", new UTF8Encoding(false));
        return new SavedPlan(fileName, written, period, provider);
    }

    private SavedPlan Describe(string fileName)
    {
        var written = DateTime.ParseExact(fileName[5..20], "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
        string period = "", provider = "";
        try
        {
            var first = File.ReadLines(Path.Combine(PlansFolder, fileName)).FirstOrDefault() ?? "";
            period = HeaderField().Match(first) is { Success: true } p ? p.Groups["period"].Value.Trim() : "";
            provider = HeaderBy().Match(first) is { Success: true } b ? b.Groups["by"].Value.Trim() : "";
        }
        catch (IOException)
        {
        }

        return new SavedPlan(fileName, written, period, provider);
    }

    private static string Period(DateRange range) =>
        range.From.ToString("d MMM yyyy", CultureInfo.InvariantCulture) + " to " + range.To.ToString("d MMM yyyy", CultureInfo.InvariantCulture);

    [GeneratedRegex(@"^plan-\d{8}-\d{6}\.md$")]
    private static partial Regex PlanFileName();

    [GeneratedRegex(@"period: (?<period>[^|]+)")]
    private static partial Regex HeaderField();

    [GeneratedRegex(@"written by: (?<by>.+?) -->")]
    private static partial Regex HeaderBy();
}
