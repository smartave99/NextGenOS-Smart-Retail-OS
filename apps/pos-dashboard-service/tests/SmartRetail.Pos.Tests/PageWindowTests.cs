using SmartRetail.Pos.Core.Paging;

namespace SmartRetail.Pos.Tests;

public sealed class PageWindowTests
{
    [Fact]
    public void A_list_is_cut_into_pages_and_each_page_knows_its_rows()
    {
        var first = PageWindow.Of(1, 50, 120);
        Assert.Equal((3, 0, 1, 50), (first.Pages, first.Skip, first.First, first.Last));
        Assert.False(first.HasPrevious);
        Assert.True(first.HasNext);

        var last = PageWindow.Of(3, 50, 120);
        Assert.Equal((3, 100, 101, 120), (last.Pages, last.Skip, last.First, last.Last));
        Assert.True(last.HasPrevious);
        Assert.False(last.HasNext);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(-4, 1)]
    [InlineData(null, 1)]
    [InlineData(99, 3)]
    public void A_page_that_is_missing_or_beyond_the_list_is_kept_inside_it(int? asked, int shown)
    {
        Assert.Equal(shown, PageWindow.Of(asked, 50, 120).Page);
    }

    [Theory]
    [InlineData(0, 1, 0, 0)]
    [InlineData(1, 1, 1, 1)]
    [InlineData(50, 1, 1, 50)]
    [InlineData(51, 2, 51, 51)]
    public void The_last_page_of_an_empty_list_or_of_one_row_over_a_page_still_makes_sense(int total, int pages, int first, int last)
    {
        var window = PageWindow.Of(int.MaxValue, 50, total);

        Assert.Equal((pages, pages, first, last), (window.Pages, window.Page, window.First, window.Last));
    }

    [Theory]
    [InlineData("3", 3)]
    [InlineData("0", 0)]
    [InlineData("abc", null)]
    [InlineData("-2", null)]
    [InlineData("2.5", null)]
    [InlineData(" 4", null)]
    [InlineData("99999999999", null)]
    [InlineData("", null)]
    [InlineData(null, null)]
    public void A_number_in_an_address_is_plain_digits_or_nothing(string? text, int? expected)
    {
        Assert.Equal(expected, PageWindow.Parse(text));
    }

    [Fact]
    public void Only_the_sizes_a_person_may_choose_are_taken_and_others_give_the_fallback()
    {
        Assert.Equal(new[] { 10, 25, 50, 100 }, PageWindow.Sizes);
        Assert.Equal(25, PageWindow.SizeOrDefault(25, 50));
        Assert.Equal(50, PageWindow.SizeOrDefault(7, 50));
        Assert.Equal(100, PageWindow.SizeOrDefault(null, 100));
        Assert.Equal(50, PageWindow.SizeOrDefault(100000, 50));
    }

    [Theory]
    [InlineData(1, 1, "1")]
    [InlineData(3, 2, "1 2 3")]
    [InlineData(12, 1, "1 2 … 12")]
    [InlineData(12, 3, "1 2 3 4 … 12")]
    [InlineData(12, 6, "1 … 5 6 7 … 12")]
    [InlineData(12, 11, "1 … 10 11 12")]
    [InlineData(12, 12, "1 … 11 12")]
    [InlineData(6, 4, "1 2 3 4 5 6")]
    public void The_pager_links_the_ends_and_the_pages_beside_this_one(int pages, int page, string expected)
    {
        var window = PageWindow.Of(page, 10, pages * 10);

        Assert.Equal(pages, window.Pages);
        Assert.Equal(expected, string.Join(' ', window.Numbers().Select(n => n?.ToString() ?? "…")));
    }
}
