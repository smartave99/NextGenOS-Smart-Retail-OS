using SmartRetail.Pos.Core.Labels;

namespace SmartRetail.Pos.Tests;

public class LabelSheetTests
{
    [Fact]
    public void Every_a4_sheet_fits_its_stickers_on_the_page()
    {
        foreach (var sheet in LabelSheet.All.Append(LabelSheet.CounterBook))
        {
            var width = sheet.LeftMm + sheet.Across * sheet.LabelWidthMm + (sheet.Across - 1) * sheet.GapAcrossMm;
            var height = sheet.TopMm + sheet.Down * sheet.LabelHeightMm + (sheet.Down - 1) * sheet.GapDownMm;
            Assert.True(width <= sheet.PageWidthMm + 0.1m, $"{sheet.Id} is {width} mm wide");
            Assert.True(height <= sheet.PageHeightMm + 0.1m, $"{sheet.Id} is {height} mm high");
        }

        Assert.Equal(65, LabelSheet.Find("a4-65").PerPage);
        Assert.Same(LabelSheet.Default, LabelSheet.Find("no-such-sheet"));
    }

    [Fact]
    public void Stickers_go_along_each_row_from_the_top_left()
    {
        var sheet = LabelSheet.Find("a4-65");

        Assert.Equal((4.65m, 10.7m), sheet.Position(0));
        Assert.Equal((4.65m + 40.6m, 10.7m), sheet.Position(1));
        Assert.Equal((4.65m, 10.7m + 21.2m), sheet.Position(5));
        Assert.Equal((4.65m + 4 * 40.6m, 10.7m + 12 * 21.2m), sheet.Position(64));
        Assert.Throws<ArgumentOutOfRangeException>(() => sheet.Position(65));
    }

    [Fact]
    public void A_part_used_sheet_starts_at_the_first_free_sticker()
    {
        var sheet = LabelSheet.Find("a4-24");
        var stickers = Enumerable.Range(1, 30).Select(i => i.ToString(System.Globalization.CultureInfo.InvariantCulture)).ToList();

        var pages = sheet.Pages(stickers, startAt: 21);

        // 4 on the part-used sheet, 24 on the next, the last 2 on a third.
        Assert.Equal(new[] { 24, 24, 2 }, pages.Select(p => p.Count));
        Assert.All(pages[0].Take(20), Assert.Null);
        Assert.Equal(new[] { "1", "2", "3", "4" }, pages[0].Skip(20));
        Assert.Equal(new[] { "29", "30" }, pages[2]);
    }

    [Fact]
    public void A_label_printer_prints_one_row_a_page_and_never_skips()
    {
        var roll = LabelSheet.Find("roll-2x38x25");

        var pages = roll.Pages(new[] { "a", "b", "c" }, startAt: 7);

        Assert.True(roll.IsRoll);
        Assert.Equal(new[] { 2, 1 }, pages.Select(p => p.Count));
        Assert.Equal("a", pages[0][0]);
    }

    [Theory]
    [InlineData("4172", "a4-65", null)] // the shop's 4-digit codes: bars 0.42 mm
    [InlineData("2000000000022", "a4-65", null)] // 13 digits: 0.21 mm, still fine
    [InlineData("SR-BATCH-2026-SEPT-01", "a4-65", "Its code is too long to scan on these stickers: choose bigger stickers.")]
    [InlineData("SR-BATCH-2026-SEPT-01", "a4-14", null)] // the same code on 99 mm stickers
    [InlineData("SR-BATCH-2026-SEPT-01", "book", null)]
    [InlineData("दूध", "a4-65", "Its code has letters a barcode cannot hold (only English letters, digits and simple signs).")]
    [InlineData("", "a4-65", "It has no code to print.")]
    public void A_code_is_only_printed_where_its_bars_come_out_wide_enough_to_scan(string code, string sheet, string? problem)
    {
        var paper = sheet == "book" ? LabelSheet.CounterBook : LabelSheet.Find(sheet);

        Assert.Equal(problem, Sticker.Fits(code, paper));
    }

    [Fact]
    public void The_bars_width_follows_the_sticker_and_its_margins()
    {
        Assert.Equal((38.1m - 3m) * 0.92m, LabelSheet.Find("a4-65").BarsWidthMm);
        Assert.Equal((63.5m - 5m) * 0.92m, LabelSheet.Find("a4-24").BarsWidthMm);
        Assert.Equal(64m - 5.6m, LabelSheet.CounterBook.BarsWidthMm);
        Assert.Equal(0.42m, Math.Round(Sticker.ModuleMm("4172", LabelSheet.Default), 2));
    }

    [Fact]
    public void Stickers_repeat_as_asked_up_to_the_limit()
    {
        var milk = new Sticker(2, "4172", "Toned Milk 500 ml", 30m, 28m);
        var rice = new Sticker(1, "0412", "Basmati Rice 5 kg", 0m, 549m);

        var stickers = Sticker.Repeat(new[] { (milk, 3), (rice, 2), (milk, -1) });

        Assert.Equal(new[] { "4172", "4172", "4172", "0412", "0412" }, stickers.Select(s => s.Code));
        Assert.True(milk.ShowsMrp);
        Assert.False(rice.ShowsMrp);
        Assert.Equal(Sticker.MaxPerPrint, Sticker.Repeat(new[] { (milk, 5000) }).Count);
        Assert.Empty(LabelSheet.Default.Pages(Array.Empty<Sticker>(), startAt: 10));
    }
}
