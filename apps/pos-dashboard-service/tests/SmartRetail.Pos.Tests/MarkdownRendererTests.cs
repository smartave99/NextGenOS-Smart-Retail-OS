using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.JSInterop;
using SmartRetail.Pos.Web.Components.Shared;
using SmartRetail.Pos.Web.Components.Shared.Chat;

namespace SmartRetail.Pos.Tests;

/// <summary>Renders components to HTML, as the page would get them, without a browser.</summary>
internal static class Html
{
    public static async Task<string> RenderAsync<T>(IDictionary<string, object?> parameters) where T : IComponent
    {
        var services = new ServiceCollection();
        services.AddSingleton<IJSRuntime, NoJs>();
        await using var provider = services.BuildServiceProvider();
        await using var renderer = new HtmlRenderer(provider, NullLoggerFactory.Instance);
        return await renderer.Dispatcher.InvokeAsync(async () =>
            (await renderer.RenderComponentAsync<T>(ParameterView.FromDictionary(parameters))).ToHtmlString());
    }

    public static Task<string> MarkdownAsync(string? text) =>
        RenderAsync<MarkdownView>(new Dictionary<string, object?> { [nameof(MarkdownView.Text)] = text });

    private sealed class NoJs : IJSRuntime
    {
        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args) => default;

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args) => default;
    }
}

public class MarkdownRendererTests
{
    // The HTML writer used here spells ₹ as &#x20B9;, a line break inside code as &#xA;, and ends <br> and <hr> with " /".
    private const string Rupee = "&#x20B9;";

    [Fact]
    public async Task A_short_answer_is_one_paragraph()
    {
        Assert.Equal($"<div class=\"md\"><p>Sales today: <strong>{Rupee}5,723</strong> from 5 bills.</p></div>",
            await Html.MarkdownAsync("Sales today: **₹5,723** from 5 bills."));
        Assert.Equal("<div class=\"md\"></div>", await Html.MarkdownAsync(null));
        Assert.Equal("<div class=\"md\"></div>", await Html.MarkdownAsync("  \n\n "));
    }

    [Fact]
    public async Task Headings_keep_their_order_with_restrained_levels()
    {
        var html = await Html.MarkdownAsync("# Today\nText\n## This week\n### Tea\n#### Detail\n##### Deeper");
        Assert.Equal("<div class=\"md\"><h3>Today</h3><p>Text</p><h3>This week</h3><h4>Tea</h4><h5>Detail</h5><h5>Deeper</h5></div>", html);
    }

    [Fact]
    public async Task Lists_bullets_numbers_nested_and_loose()
    {
        Assert.Equal("<div class=\"md\"><ul><li>Tea<ul><li>250 g</li><li>1 kg</li></ul></li><li>Oil</li></ul></div>",
            await Html.MarkdownAsync("- Tea\n  - 250 g\n  - 1 kg\n- Oil"));
        Assert.Equal("<div class=\"md\"><ol start=\"3\"><li>Third</li><li>Fourth</li></ol></div>",
            await Html.MarkdownAsync("3. Third\n4. Fourth"));
        Assert.Equal("<div class=\"md\"><ol><li><p>One</p></li><li><p>Two</p></li></ol></div>",
            await Html.MarkdownAsync("1. One\n\n2. Two"));
        Assert.Equal("<div class=\"md\"><p>The best seller is <strong>Tea</strong>.</p><ul><li>Keep it near the counter.</li></ul></div>",
            await Html.MarkdownAsync("The best seller is **Tea**.\n- Keep it near the counter."));
    }

    [Fact]
    public async Task A_code_block_has_its_language_a_copy_button_and_escaped_code()
    {
        var html = await Html.MarkdownAsync("```sql\nselect top 5 Name\nfrom Product where Price < 100 -- <b>\n```");
        Assert.Contains("<span class=\"md-code-lang\">sql</span>", html);
        Assert.Contains("title=\"Copy the code\"", html);
        Assert.Contains("<pre tabindex=\"0\"><code>select top 5 Name&#xA;from Product where Price &lt; 100 -- &lt;b&gt;</code></pre>", html);
        Assert.Contains("<span class=\"md-code-lang\">Code</span>", await Html.MarkdownAsync("    indented code"));
        Assert.Contains("<span class=\"md-code-lang\">cscript</span>", await Html.MarkdownAsync("```c<script>\nx\n```"));
    }

    [Fact]
    public async Task A_table_scrolls_in_its_own_box_with_numbers_on_the_right()
    {
        var html = await Html.MarkdownAsync("| Product | Qty | Sales |\n|:--|:-:|--:|\n| **Tea** | 4 | ₹480 |\n| Oil | 2 | ₹310 |");
        Assert.StartsWith("<div class=\"md\"><div class=\"md-table-wrap\" role=\"region\" aria-label=\"Table\" tabindex=\"0\"><table class=\"md-table\">", html);
        Assert.Contains("<thead><tr><th>Product</th><th class=\"mid\">Qty</th><th class=\"num\">Sales</th></tr></thead>", html);
        Assert.Contains($"<tbody><tr><td><strong>Tea</strong></td><td class=\"mid\">4</td><td class=\"num\">{Rupee}480</td></tr><tr><td>Oil</td>", html);
    }

    [Fact]
    public async Task Quotes_rules_and_emphasis()
    {
        Assert.Equal("<div class=\"md\"><blockquote><p>Check the <em>expiry</em> dates.</p></blockquote><hr /><p><del>old</del> <code>new</code></p></div>",
            await Html.MarkdownAsync("> Check the *expiry* dates.\n\n---\n\n~~old~~ `new`"));
    }

    [Fact]
    public async Task A_single_line_break_stays_a_line_break()
    {
        Assert.Equal($"<div class=\"md\"><p>Sales: {Rupee}5,723<br />Bills: 5</p></div>", await Html.MarkdownAsync("Sales: ₹5,723\nBills: 5"));
    }

    [Fact]
    public async Task Html_in_an_answer_is_only_text()
    {
        var html = await Html.MarkdownAsync("<b>not bold</b> and <script>alert(1)</script>\n\n<div onclick=\"x()\">block</div>\n\n<img src=x onerror=alert(1)>");
        Assert.DoesNotContain("<b>", html);
        Assert.DoesNotContain("<script", html);
        Assert.DoesNotContain("<img", html);
        Assert.DoesNotContain("<div onclick", html);
        Assert.Contains("&lt;b&gt;not bold&lt;/b&gt;", html);
        Assert.Contains("&lt;script&gt;alert(1)&lt;/script&gt;", html);
    }

    [Fact]
    public async Task Only_web_links_are_links_and_pictures_never_load()
    {
        var html = await Html.MarkdownAsync(
            "[Supplier](https://example.com/list?a=1 \"Price list\") [bad](javascript:alert(1)) [file](file:///c:/x) ![logo](https://example.com/logo.png) see https://example.org/offers");
        Assert.Contains("<a href=\"https://example.com/list?a=1\" target=\"_blank\" rel=\"noopener noreferrer\" title=\"Price list\">Supplier</a>", html);
        Assert.Contains("<a href=\"https://example.org/offers\" target=\"_blank\" rel=\"noopener noreferrer\">https://example.org/offers</a>", html);
        Assert.DoesNotContain("javascript:", html);
        Assert.DoesNotContain("file:", html);
        Assert.DoesNotContain("<img", html);
        Assert.Contains(" bad ", html);
        Assert.Contains(" logo ", html);
        Assert.Null(MarkdownRenderer.SafeUrl("data:text/html,x"));
        Assert.Equal("http://example.com/", MarkdownRenderer.SafeUrl(" http://example.com "));
    }

    [Fact]
    public async Task Task_lists_show_boxes_that_cannot_be_changed()
    {
        var html = await Html.MarkdownAsync("- [x] Order tea\n- [ ] Call the supplier");
        Assert.Contains("<li class=\"task\"><input type=\"checkbox\" disabled checked aria-label=\"Done\" /> Order tea</li>", html);
        Assert.Contains("<li class=\"task\"><input type=\"checkbox\" disabled aria-label=\"Not done\" /> Call the supplier</li>", html);
    }

    [Fact]
    public async Task Half_written_markdown_draws_as_far_as_it_goes()
    {
        // While an answer streams, it often stops inside bold text, a table or a code block.
        Assert.Equal("<div class=\"md\"><p>The best seller is **Te</p></div>", await Html.MarkdownAsync("The best seller is **Te"));
        var code = await Html.MarkdownAsync("## Query\n```sql\nselect top 5");
        Assert.Contains("<h3>Query</h3>", code);
        Assert.Contains("<code>select top 5</code>", code);
        Assert.Contains("<p>| Product | Sal</p>", await Html.MarkdownAsync("| Product | Sal"));
    }

    [Fact]
    public async Task A_mixed_answer_keeps_every_part_in_order()
    {
        var html = await Html.MarkdownAsync(string.Join("\n", new[]
        {
            "# Sales this week", "Up **12%** on last week.", "", "- Tea", "  1. 250 g", "  2. 1 kg", "- Oil", "",
            "More text.", "", "```", "a = 1", "```", "", "## By day", "| Day | Sales |", "|---|--:|", "| Mon | 900 |", "",
            "> Sunday was best.", "", "1. Stock up", "   - before Friday",
        }));
        var order = new[] { "<h3>Sales this week</h3>", "<ul><li>Tea<ol><li>250 g</li>", "<p>More text.</p>", "md-code", "<h3>By day</h3>", "md-table", "<blockquote>", "<ol><li>Stock up<ul><li>before Friday</li></ul></li></ol>" };
        var at = 0;
        foreach (var part in order)
        {
            var next = html.IndexOf(part, at, StringComparison.Ordinal);
            Assert.True(next >= 0, "Missing or out of order: " + part + "\n" + html);
            at = next;
        }
    }
}
