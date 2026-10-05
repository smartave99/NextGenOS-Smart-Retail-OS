using Markdig;
using Markdig.Extensions.EmphasisExtras;
using Markdig.Extensions.Tables;
using Markdig.Extensions.TaskLists;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MarkdownCodeBlock = Markdig.Syntax.CodeBlock;

namespace SmartRetail.Pos.Web.Components.Shared.Chat;

/// <summary>
/// Draws an AI answer's Markdown as page elements: headings, paragraphs, lists (nested too), quotes, code, tables,
/// rules, links and emphasis. Nothing in an answer is ever put on the page as HTML: HTML in it shows as text, links
/// must be http or https (and open in the browser), and pictures are never loaded. A single line break stays a line
/// break, as the AI wrote it. Half-written Markdown, as it arrives while an answer streams, draws as far as it goes.
/// </summary>
public static class MarkdownRenderer
{
    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
        .UsePipeTables()
        .UseEmphasisExtras(EmphasisExtraOptions.Strikethrough)
        .UseTaskLists()
        .UseAutoLinks()
        .DisableHtml()
        .Build();

    /// <summary>Deeper lists and quotes than this are drawn flat: an answer never needs more.</summary>
    private const int MaxDepth = 8;

    public static MarkdownDocument Parse(string? text) => Markdown.Parse(text ?? "", Pipeline);

    public static RenderFragment Render(string? text)
    {
        var document = Parse(text);
        return builder => Blocks(builder, document, 0);
    }

    private static void Blocks(RenderTreeBuilder builder, ContainerBlock container, int depth, bool tight = false)
    {
        // Each block is its own region, so a growing answer only redraws its last block. Every turn of a loop uses the
        // same sequence number: Blazor matches them in order.
        for (var i = 0; i < container.Count; i++)
        {
            builder.OpenRegion(10);
            Block(builder, container[i], depth, tight);
            builder.CloseRegion();
        }
    }

    private static void Block(RenderTreeBuilder builder, Block block, int depth, bool tight)
    {
        switch (block)
        {
            case HeadingBlock heading:
                builder.OpenElement(0, heading.Level <= 2 ? "h3" : heading.Level == 3 ? "h4" : "h5");
                Inlines(builder, heading.Inline);
                builder.CloseElement();
                break;

            case ParagraphBlock paragraph when tight:
                // In a tight list an item's text sits in the item itself, as browsers draw it.
                Inlines(builder, paragraph.Inline);
                break;

            case ParagraphBlock paragraph:
                builder.OpenElement(0, "p");
                Inlines(builder, paragraph.Inline);
                builder.CloseElement();
                break;

            case ListBlock list:
                builder.OpenElement(0, list.IsOrdered ? "ol" : "ul");
                if (list.IsOrdered && int.TryParse(list.OrderedStart, out var start) && start != 1)
                {
                    builder.AddAttribute(1, "start", start);
                }

                for (var i = 0; i < list.Count; i++)
                {
                    builder.OpenRegion(11);
                    builder.OpenElement(0, "li");
                    if (list[i] is ContainerBlock item)
                    {
                        if (IsTask(item))
                        {
                            builder.AddAttribute(1, "class", "task");
                        }

                        Blocks(builder, item, depth + 1, tight: !list.IsLoose);
                    }

                    builder.CloseElement();
                    builder.CloseRegion();
                }

                builder.CloseElement();
                break;

            case QuoteBlock quote:
                builder.OpenElement(0, "blockquote");
                Blocks(builder, quote, depth + 1);
                builder.CloseElement();
                break;

            case Table table:
                TableBlock(builder, table);
                break;

            case FencedCodeBlock fenced:
                Code(builder, Text(fenced), Language(fenced.Info));
                break;

            case MarkdownCodeBlock code:
                Code(builder, Text(code), null);
                break;

            case ThematicBreakBlock:
                builder.OpenElement(0, "hr");
                builder.CloseElement();
                break;

            case LinkReferenceDefinitionGroup or BlankLineBlock:
                break;

            case HtmlBlock html:
                // Only when HTML is not turned off; even then it is text.
                builder.OpenElement(0, "p");
                builder.AddContent(1, Text(html));
                builder.CloseElement();
                break;

            case ContainerBlock other when depth < MaxDepth:
                Blocks(builder, other, depth + 1, tight);
                break;

            case LeafBlock leaf:
                builder.OpenElement(0, "p");
                if (leaf.Inline is { } inline)
                {
                    Inlines(builder, inline);
                }
                else
                {
                    builder.AddContent(1, Text(leaf));
                }

                builder.CloseElement();
                break;
        }
    }

    private static void TableBlock(RenderTreeBuilder builder, Table table)
    {
        var header = table.OfType<TableRow>().TakeWhile(row => row.IsHeader).ToList();
        var body = table.OfType<TableRow>().Skip(header.Count).ToList();

        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "md-table-wrap");
        builder.AddAttribute(2, "role", "region");
        builder.AddAttribute(3, "aria-label", "Table");
        builder.AddAttribute(4, "tabindex", "0");
        builder.OpenElement(5, "table");
        builder.AddAttribute(6, "class", "md-table");
        if (header.Count > 0)
        {
            builder.OpenElement(7, "thead");
            Rows(builder, table, header, "th");
            builder.CloseElement();
        }

        builder.OpenElement(8, "tbody");
        Rows(builder, table, body, "td");
        builder.CloseElement();
        builder.CloseElement();
        builder.CloseElement();
    }

    private static void Rows(RenderTreeBuilder builder, Table table, IReadOnlyList<TableRow> rows, string cellElement)
    {
        for (var r = 0; r < rows.Count; r++)
        {
            builder.OpenRegion(13);
            builder.OpenElement(0, "tr");
            var cells = rows[r].OfType<TableCell>().ToList();
            for (var c = 0; c < cells.Count; c++)
            {
                var cell = cells[c];
                builder.OpenRegion(14);
                builder.OpenElement(0, cellElement);
                // A cell's column, as Markdig's own HTML writer finds it: its index when set, else its place in the row.
                var column = cell.ColumnIndex >= 0 ? cell.ColumnIndex : c;
                var align = column < table.ColumnDefinitions.Count ? table.ColumnDefinitions[column].Alignment : null;
                if (align is TableColumnAlign.Right)
                {
                    builder.AddAttribute(1, "class", "num");
                }
                else if (align is TableColumnAlign.Center)
                {
                    builder.AddAttribute(1, "class", "mid");
                }

                // A cell holds a paragraph; its words go straight into the cell.
                Blocks(builder, cell, MaxDepth, tight: true);
                builder.CloseElement();
                builder.CloseRegion();
            }

            builder.CloseElement();
            builder.CloseRegion();
        }
    }

    private static void Code(RenderTreeBuilder builder, string code, string? language)
    {
        builder.OpenComponent<CodeBlock>(0);
        builder.AddComponentParameter(1, nameof(CodeBlock.Code), code);
        builder.AddComponentParameter(2, nameof(CodeBlock.Language), language);
        builder.CloseComponent();
    }

    private static void Inlines(RenderTreeBuilder builder, ContainerInline? container)
    {
        if (container is null)
        {
            return;
        }

        foreach (var inline in container)
        {
            builder.OpenRegion(12);
            Inline(builder, inline);
            builder.CloseRegion();
        }
    }

    private static void Inline(RenderTreeBuilder builder, Inline inline)
    {
        switch (inline)
        {
            case LiteralInline literal:
                builder.AddContent(0, literal.Content.ToString());
                break;

            case CodeInline code:
                builder.OpenElement(0, "code");
                builder.AddContent(1, code.Content);
                builder.CloseElement();
                break;

            case EmphasisInline emphasis:
                builder.OpenElement(0, emphasis.DelimiterChar == '~' ? "del" : emphasis.DelimiterCount >= 2 ? "strong" : "em");
                Inlines(builder, emphasis);
                builder.CloseElement();
                break;

            case LineBreakInline:
                builder.OpenElement(0, "br");
                builder.CloseElement();
                break;

            case LinkInline { IsImage: true } image:
                // Pictures in an answer are never loaded: only their description shows.
                Inlines(builder, image);
                break;

            case LinkInline link when SafeUrl(link.GetDynamicUrl?.Invoke() ?? link.Url) is { } url:
                Link(builder, url, link);
                break;

            case LinkInline link:
                Inlines(builder, link);
                break;

            case AutolinkInline auto when !auto.IsEmail && SafeUrl(auto.Url) is { } url:
                builder.OpenElement(0, "a");
                builder.AddAttribute(1, "href", url);
                builder.AddAttribute(2, "target", "_blank");
                builder.AddAttribute(3, "rel", "noopener noreferrer");
                builder.AddContent(4, auto.Url);
                builder.CloseElement();
                break;

            case AutolinkInline auto:
                builder.AddContent(0, auto.Url);
                break;

            case HtmlEntityInline entity:
                builder.AddContent(0, entity.Transcoded.ToString());
                break;

            case HtmlInline html:
                builder.AddContent(0, html.Tag);
                break;

            case TaskList task:
                builder.OpenElement(0, "input");
                builder.AddAttribute(1, "type", "checkbox");
                builder.AddAttribute(2, "disabled", true);
                builder.AddAttribute(3, "checked", task.Checked);
                builder.AddAttribute(4, "aria-label", task.Checked ? "Done" : "Not done");
                builder.CloseElement();
                break;

            case DelimiterInline delimiter:
                // A delimiter that matched nothing, e.g. a lone "**" while an answer is still arriving.
                builder.AddContent(0, delimiter.ToLiteral());
                Inlines(builder, delimiter);
                break;

            case ContainerInline other:
                Inlines(builder, other);
                break;

            case LeafInline leaf:
                builder.AddContent(0, leaf.ToString());
                break;
        }
    }

    private static void Link(RenderTreeBuilder builder, string url, LinkInline link)
    {
        builder.OpenElement(0, "a");
        builder.AddAttribute(1, "href", url);
        builder.AddAttribute(2, "target", "_blank");
        builder.AddAttribute(3, "rel", "noopener noreferrer");
        if (!string.IsNullOrWhiteSpace(link.Title))
        {
            builder.AddAttribute(4, "title", link.Title);
        }

        Inlines(builder, link);
        builder.CloseElement();
    }

    /// <summary>The address when it is a plain web address; null for anything else (javascript:, data:, files).</summary>
    public static string? SafeUrl(string? url)
    {
        var trimmed = (url ?? "").Trim();
        return Uri.TryCreate(trimmed, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp)
            ? uri.AbsoluteUri
            : null;
    }

    private static bool IsTask(ContainerBlock item) =>
        item.Count > 0 && item[0] is ParagraphBlock { Inline.FirstChild: TaskList };

    private static string Text(LeafBlock block) => block.Lines.ToString().TrimEnd('\n', '\r');

    /// <summary>The code block's language as a short label: its first word, letters and a few signs only.</summary>
    private static string? Language(string? info)
    {
        var word = (info ?? "").Trim().Split(' ', 2)[0];
        var clean = new string(word.Where(c => char.IsLetterOrDigit(c) || c is '+' or '#' or '-' or '.').Take(20).ToArray());
        return clean.Length == 0 ? null : clean;
    }
}
