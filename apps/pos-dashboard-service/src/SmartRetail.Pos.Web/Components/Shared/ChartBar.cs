namespace SmartRetail.Pos.Web.Components.Shared;

/// <summary>One bar of a <see cref="SalesChart"/>.</summary>
public sealed record ChartBar(string Label, decimal Value, string Tooltip, bool Highlight = false);

/// <summary>One row of a <see cref="ShareBars"/> list.</summary>
public sealed record ShareRow(string Label, string Value, decimal Share, string? Note = null, string? Tone = null);
