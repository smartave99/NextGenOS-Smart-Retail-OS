using System.Text.Json;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Owner;
using SmartRetail.Pos.Core.Review;

namespace SmartRetail.Pos.Tests;

/// <summary>The Monday review as the owner's page gets it: figures and product names, nothing else.</summary>
public class OwnerReviewTests
{
    private static readonly JsonSerializerOptions Web = new(JsonSerializerDefaults.Web);

    private static readonly DateRange Week = new(new DateOnly(2026, 9, 21), new DateOnly(2026, 9, 27)); // Monday to Sunday

    private static OwnerReviewInputs Inputs() => new()
    {
        Now = new DateTimeOffset(2026, 9, 28, 9, 15, 0, TimeSpan.FromHours(5.5)),
        Week = Week,
        ThisWeek = new SalesTotals { Sales = 123456.784m, Bills = 301, SalesBeforeTax = 110000m, CostedSalesBeforeTax = 100000m, Profit = 19000m },
        WeekBefore = new SalesTotals { Sales = 100000m, Bills = 250, SalesBeforeTax = 90000m },
        YearBefore = new SalesTotals { Sales = 90000m, Bills = 240 },
        Alerts = new[]
        {
            new ShopAlert { Kind = AlertKind.StockOut, ProductId = 1, Name = "Basmati Rice 5 kg", StockInHand = 4, QtyPerDay = 2.456m, DaysLeft = 1.6285m, Figures = "4 left; it sells about 2 a day", Recommendation = "Reorder today." },
            new ShopAlert { Kind = AlertKind.StockOut, ProductId = 2, Name = "Tea 250 g", StockInHand = -3, QtyPerDay = 0.2m, DaysLeft = 0m },
            new ShopAlert { Kind = AlertKind.DeadStock, ProductId = 3, Name = "Pen (call 9876543210)", StockInHand = 40, StockValue = 200.004m, Figures = "40 in stock, ₹200 tied up", Recommendation = "Clear it." },
        },
        ReviewedOn = new DateOnly(2026, 9, 28),
    };

    [Fact]
    public void Last_week_is_set_against_the_week_before_and_the_same_week_a_year_before()
    {
        var review = OwnerReview.From(Inputs());

        Assert.Equal((Week.From, Week.To, 123456.78m, 301), (review.ThisWeek.From, review.ThisWeek.To, review.ThisWeek.Sales, review.ThisWeek.Bills));
        // The average bill is rounded to paise; the profit and its margin are sent only when purchase prices are known.
        Assert.Equal(410.16m, review.ThisWeek.AverageBill);
        Assert.Equal((19000m, 0.19m), (review.ThisWeek.Profit, review.ThisWeek.Margin));
        Assert.Equal((new DateOnly(2026, 9, 14), new DateOnly(2026, 9, 20), 100000m, 250), (review.WeekBefore.From, review.WeekBefore.To, review.WeekBefore.Sales, review.WeekBefore.Bills));
        Assert.Null(review.WeekBefore.Profit);
        Assert.Null(review.WeekBefore.Margin);
        // 52 weeks back, so a Monday is compared with a Monday.
        var year = review.YearBefore!;
        Assert.Equal((new DateOnly(2025, 9, 22), new DateOnly(2025, 9, 28), 90000m, 240), (year.From, year.To, year.Sales, year.Bills));
        Assert.Equal(DayOfWeek.Monday, year.From.DayOfWeek);
        Assert.Equal((1, false, new DateOnly(2026, 9, 28)), (review.Version, review.Demo, review.ReviewedOn));
    }

    [Fact]
    public void Without_bills_a_year_before_the_page_is_told_so_and_a_week_without_sales_is_zero()
    {
        var review = OwnerReview.From(Inputs() with { YearBefore = null, ThisWeek = new SalesTotals(), ReviewedOn = null, Demo = true });

        Assert.Null(review.YearBefore);
        Assert.Null(review.ReviewedOn);
        Assert.True(review.Demo);
        Assert.Equal((0m, 0, 0m), (review.ThisWeek.Sales, review.ThisWeek.Bills, review.ThisWeek.AverageBill));
        Assert.Null(review.ThisWeek.Profit);
        Assert.Contains("\"yearBefore\":null", JsonSerializer.Serialize(review, Web));
    }

    [Fact]
    public void Products_running_out_and_not_selling_come_with_their_figures_and_numbers_in_names_are_masked()
    {
        var review = OwnerReview.From(Inputs());

        Assert.Equal(new OwnerRunningOut("Basmati Rice 5 kg", 4m, 2.46m, 1.63m), review.RunningOut[0]);
        // Stock is never sent below none.
        Assert.Equal(new OwnerRunningOut("Tea 250 g", 0m, 0.2m, 0m), review.RunningOut[1]);
        Assert.Equal(new OwnerNotSelling("Pen (call 98••••••10)", 40m, 200m), Assert.Single(review.NotSelling));
        Assert.DoesNotContain("9876543210", JsonSerializer.Serialize(review, Web));
    }

    [Fact]
    public void Each_list_is_cut_to_what_the_rules_raise_at_most()
    {
        var many = Enumerable.Range(1, 30).SelectMany(i => new[]
        {
            new ShopAlert { Kind = AlertKind.StockOut, ProductId = i, Name = "Out " + i, StockInHand = 1 },
            new ShopAlert { Kind = AlertKind.DeadStock, ProductId = 100 + i, Name = "Dead " + i, StockInHand = 1, StockValue = i },
        }).ToList();

        var review = OwnerReview.From(Inputs() with { Alerts = many });

        Assert.Equal(ShopAlerts.MaxEach, review.RunningOut.Count);
        Assert.Equal(ShopAlerts.MaxEach, review.NotSelling.Count);
        Assert.Equal("Out 1", review.RunningOut[0].Name);
    }

    [Fact]
    public void Only_figures_and_product_names_leave_the_shop_not_the_rules_words_nor_the_owners_notes()
    {
        var json = JsonSerializer.Serialize(OwnerReview.From(Inputs()), Web);
        using var document = JsonDocument.Parse(json);
        var names = new HashSet<string>();
        void Collect(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (var property in element.EnumerateObject())
                    {
                        names.Add(property.Name);
                        Collect(property.Value);
                    }

                    break;
                case JsonValueKind.Array:
                    foreach (var item in element.EnumerateArray())
                    {
                        Collect(item);
                    }

                    break;
            }
        }

        Collect(document.RootElement);

        // Every property the page can get; a new one must be added here on purpose, after asking what it could reveal.
        var allowed = new[]
        {
            "version", "demo", "sentAt", "thisWeek", "weekBefore", "yearBefore", "runningOut", "notSelling", "reviewedOn",
            "from", "to", "sales", "bills", "averageBill", "profit", "margin", "name", "inHand", "perDay", "daysLeft", "value",
        };
        Assert.Empty(names.Except(allowed));
        Assert.DoesNotContain("tied up", json);
        Assert.DoesNotContain("Reorder", json);
    }

    [Fact]
    public void The_page_gets_camel_case_names_and_plain_dates()
    {
        using var json = JsonDocument.Parse(JsonSerializer.Serialize(OwnerReview.From(Inputs()), Web));
        var root = json.RootElement;

        Assert.Equal("2026-09-21", root.GetProperty("thisWeek").GetProperty("from").GetString());
        Assert.Equal(123456.78m, root.GetProperty("thisWeek").GetProperty("sales").GetDecimal());
        Assert.Equal("2026-09-28", root.GetProperty("reviewedOn").GetString());
        Assert.Equal("Basmati Rice 5 kg", root.GetProperty("runningOut")[0].GetProperty("name").GetString());
        Assert.Equal("review", OwnerReview.Kind);
    }

    [Fact]
    public void The_review_is_sent_again_in_an_hour_or_after_a_failed_try_in_ten_minutes()
    {
        var now = new DateTimeOffset(2026, 9, 28, 9, 15, 0, TimeSpan.FromHours(5.5));

        Assert.Equal(now.AddHours(1), OwnerReview.NextDue(now, sent: true));
        Assert.Equal(now.AddMinutes(10), OwnerReview.NextDue(now, sent: false));
    }
}
