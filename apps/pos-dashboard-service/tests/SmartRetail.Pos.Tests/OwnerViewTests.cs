using System.Net;
using System.Text;
using System.Text.Json;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Core.Models;
using SmartRetail.Pos.Core.Owner;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public class OwnerViewTests
{
    private static readonly JsonSerializerOptions Web = new(JsonSerializerDefaults.Web);

    /// <summary>A token like Supabase's older keys, with this role (the signature is not checked here).</summary>
    private static string Jwt(string role)
    {
        static string Part(string json) => Convert.ToBase64String(Encoding.UTF8.GetBytes(json)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        return Part("{\"alg\":\"HS256\",\"typ\":\"JWT\"}") + "." + Part("{\"iss\":\"supabase\",\"ref\":\"abcd\",\"role\":\"" + role + "\"}") + ".c2lnbmF0dXJl";
    }

    [Theory]
    [InlineData("https://abcd.supabase.co", "https://abcd.supabase.co")]
    [InlineData("  https://abcd.supabase.co/ ", "https://abcd.supabase.co")]
    [InlineData("https://db.example.in:8443", "https://db.example.in:8443")]
    [InlineData("http://127.0.0.1:54321", "http://127.0.0.1:54321")]
    public void A_project_url_is_kept_as_its_address(string text, string expected)
    {
        Assert.Equal(expected, OwnerViewRules.ProjectUrl(text, out var problem));
        Assert.Null(problem);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abcd.supabase.co")]
    [InlineData("http://abcd.supabase.co")]
    [InlineData("https://abcd.supabase.co/rest/v1")]
    [InlineData("https://abcd.supabase.co/?x=1")]
    [InlineData("https://user:pass@abcd.supabase.co")]
    [InlineData("ftp://abcd.supabase.co")]
    public void Anything_else_is_not_a_project_url(string text)
    {
        Assert.Null(OwnerViewRules.ProjectUrl(text, out var problem));
        Assert.Contains("project URL", problem);
    }

    [Fact]
    public void Only_a_public_key_is_taken()
    {
        var anon = Jwt("anon");
        Assert.Equal(anon, OwnerViewRules.PublicKey(" " + anon + " ", out _));
        Assert.True(OwnerViewRules.IsJwt(anon));
        Assert.Equal("sb_publishable_AbC-123_x", OwnerViewRules.PublicKey("sb_publishable_AbC-123_x", out _));
        Assert.False(OwnerViewRules.IsJwt("sb_publishable_AbC-123_x"));

        foreach (var secret in new[] { Jwt("service_role"), "sb_secret_AbC123" })
        {
            Assert.Null(OwnerViewRules.PublicKey(secret, out var problem));
            Assert.Contains("secret key", problem);
        }

        foreach (var other in new[] { "", "hello", Jwt("authenticated"), "sb_publishable_has space", "a.b.c" })
        {
            Assert.Null(OwnerViewRules.PublicKey(other, out var problem));
            Assert.Contains("public key", problem);
        }
    }

    [Theory]
    [InlineData("ABCD-EFGH", "ABCDEFGH")]
    [InlineData(" abcd efgh ", "ABCDEFGH")]
    [InlineData("k7m2-p9qx", "K7M2P9QX")]
    [InlineData("ABCDEFG", null)]
    [InlineData("ABCD-EFG0", null)]
    [InlineData("ABCD-EFGI", null)]
    [InlineData("ABCD-EFGH-J", null)]
    public void A_one_time_code_is_eight_easy_letters(string text, string? expected) => Assert.Equal(expected, OwnerViewRules.Code(text));

    private static OwnerLiveInputs Inputs()
    {
        var today = new DateOnly(2026, 9, 27);
        var times = new[]
        {
            new BillTime(today, today.ToDateTime(new TimeOnly(10, 5)), 300m),
            new BillTime(today, today.ToDateTime(new TimeOnly(18, 57)), 450m),
            new BillTime(today.AddDays(-7), today.AddDays(-7).ToDateTime(new TimeOnly(11, 0)), 500m),
        };
        var figures = TodayFigures.From(today.ToDateTime(new TimeOnly(19, 2)),
            new[] { new TrendPoint(today, 750m, 2, 0m), new TrendPoint(today.AddDays(-7), 500m, 1, 0m) }, times);
        return new OwnerLiveInputs
        {
            ShopName = " Demo Mart 99 ",
            Now = new DateTimeOffset(2026, 9, 27, 19, 2, 0, TimeSpan.FromHours(5.5)),
            Figures = figures,
            CreditToday = 150m,
            TodaysBills = new[]
            {
                new InvoiceSummary { Id = 1, Number = "GST-0001", Date = today.ToDateTime(TimeOnly.MinValue), SavedAt = today.ToDateTime(new TimeOnly(10, 5)), CustomerName = "Asha Rao 9876543210", GrandTotal = 300m },
                new InvoiceSummary { Id = 2, Number = "GST-0002", Date = today.ToDateTime(TimeOnly.MinValue), SavedAt = today.ToDateTime(new TimeOnly(18, 57)), CustomerName = "Ramesh Kumar", GrandTotal = 450m, Balance = 150m },
            },
            TodaysProducts = new[]
            {
                new ProductDaySales { Day = today, ProductId = 7, Qty = 2, Sales = 100m },
                new ProductDaySales { Day = today, ProductId = 8, Qty = 1, Sales = 650m },
            },
            ProductNames = new Dictionary<int, string> { [7] = "Toned Milk 500 ml", [8] = "Basmati Rice 5 kg" },
            LowStock = new[] { new StockLevel { ProductId = 7, Name = "Toned Milk 500 ml", InHand = 3, MinStock = 24 } },
            FixNow = new[]
            {
                new Finding { Kind = FindingKind.BelowCost, Level = FindingLevel.FixNow, Title = "Glucose Biscuits 200 g" },
                new Finding { Kind = FindingKind.OwedLong, Level = FindingLevel.CheckSoon, Title = "Ramesh Kumar 9876543210" },
                new Finding { Kind = FindingKind.MissingBills, Level = FindingLevel.FixNow, Title = "GST-0003" },
            },
        };
    }

    [Fact]
    public void The_live_view_has_todays_figures_bills_and_best_sellers()
    {
        var live = OwnerLive.From(Inputs());

        Assert.Equal(("Demo Mart 99", false, 750m, 2, 150m), (live.Shop, live.Demo, live.Today.Sales, live.Today.Bills, live.Today.Credit));
        Assert.Equal(("18:57", "19:02", 500m), (live.Today.LastBillAt, live.Today.ComparedAt, live.Today.LastWeekSales));
        Assert.Equal(0.5m, live.Today.VsLastWeek);
        // Rounded, so the page gets a share, not a long fraction.
        Assert.Equal(0.3333m, OwnerLive.From(Inputs() with { Figures = Inputs().Figures with { ChangeVsLastWeek = 1m / 3m } }).Today.VsLastWeek);
        Assert.Equal(new (string, string?, decimal, decimal)[] { ("GST-0002", "18:57", 450m, 150m), ("GST-0001", "10:05", 300m, 0m) },
            live.Bills.Select(b => (b.Number, b.Time, b.Total, b.Due)));
        Assert.Equal(new[] { "Basmati Rice 5 kg", "Toned Milk 500 ml" }, live.Top.Select(p => p.Name));
        Assert.Equal(new OwnerStock("Toned Milk 500 ml", 3, 24), Assert.Single(live.LowStock));
        Assert.Equal(7, live.Week.Count);
        Assert.Contains(live.Hours, h => h.Hour == 18 && h.Sales == 450m);
    }

    [Fact]
    public void The_live_view_never_carries_a_customers_name_or_phone_number()
    {
        var live = OwnerLive.From(Inputs());
        var json = JsonSerializer.Serialize(live, Web);

        Assert.DoesNotContain("Asha", json);
        Assert.DoesNotContain("Ramesh", json);
        Assert.DoesNotContain("9876543210", json);
        // A mistake in a product is named; money owed and missing bills only say what kind they are.
        Assert.Equal(2, live.FixNow.Count);
        Assert.Equal(new (string, string?)[] { ("Selling below cost", "Glucose Biscuits 200 g"), ("Missing bill numbers", null), ("Money owed for a long time", null) },
            live.FixNow.Items.Select(f => (f.Kind, f.Title)));
    }

    [Fact]
    public void A_phone_number_typed_into_a_product_or_shop_name_is_masked()
    {
        var inputs = Inputs() with
        {
            ShopName = "Demo Mart 9876543210",
            ProductNames = new Dictionary<int, string> { [7] = "Milk (call 9876543210)", [8] = "Basmati Rice 5 kg" },
            LowStock = new[] { new StockLevel { ProductId = 7, Name = "Milk (call 9876543210)", InHand = 3, MinStock = 24 } },
        };

        var live = OwnerLive.From(inputs);
        var day = OwnerDay.From(new SalesFacts
        {
            Range = new DateRange(inputs.Figures.Day, inputs.Figures.Day),
            Days = new[] { new DaySales { Day = inputs.Figures.Day, Bills = 1, Sales = 100m } },
            ProductDays = inputs.TodaysProducts,
        }, inputs.ProductNames);
        var json = JsonSerializer.Serialize(live, Web) + JsonSerializer.Serialize(day, Web);

        Assert.DoesNotContain("9876543210", json);
        Assert.Equal("Demo Mart 98••••••10", live.Shop);
        Assert.Contains(live.Top, p => p.Name == "Milk (call 98••••••10)");
        Assert.Equal("Milk (call 98••••••10)", live.LowStock[0].Name);
        Assert.Contains(day[0].Top, p => p.Name == "Milk (call 98••••••10)");
        // Bill numbers are not personal: they stay as the POS has them.
        Assert.Contains(live.Bills, b => b.Number == "GST-0001");
    }

    [Fact]
    public void The_history_has_each_days_totals_hours_and_best_sellers()
    {
        var day = new DateOnly(2026, 9, 26);
        var facts = new SalesFacts
        {
            Range = new DateRange(day.AddDays(-1), day),
            Days = new[] { new DaySales { Day = day, Bills = 3, Sales = 900m, Returns = 50m }, new DaySales { Day = day.AddDays(-5), Bills = 9, Sales = 1 } },
            Hours = new[] { new HourSales { Day = day, Hour = 19, Bills = 2, Sales = 600m }, new HourSales { Day = day, Hour = 10, Bills = 1, Sales = 300m } },
            ProductDays = new[] { new ProductDaySales { Day = day, ProductId = 8, Qty = 1, Sales = 650m } },
        };

        var days = OwnerDay.From(facts, new Dictionary<int, string> { [8] = "Basmati Rice 5 kg" });

        var only = Assert.Single(days);
        Assert.Equal((day, 900m, 3, 50m), (only.Day, only.Sales, only.Bills, only.Returns));
        Assert.Equal(new[] { 10, 19 }, only.Hours.Select(h => h.Hour));
        Assert.Equal("Basmati Rice 5 kg", Assert.Single(only.Top).Name);
        Assert.Contains("\"day\":\"2026-09-26\"", JsonSerializer.Serialize(only, Web));
    }

    [Fact]
    public void A_day_without_bills_is_sent_as_none_so_deleted_bills_leave_the_history()
    {
        var day = new DateOnly(2026, 9, 26);
        var facts = new SalesFacts
        {
            Range = new DateRange(day.AddDays(-7), day),
            Days = new[]
            {
                new DaySales { Day = day.AddDays(-5), Bills = 4, Sales = 400m },
                new DaySales { Day = day.AddDays(-4), Bills = 0, Sales = 0m },
                new DaySales { Day = day.AddDays(-2), Bills = 2, Sales = 200m },
            },
            Hours = new[] { new HourSales { Day = day.AddDays(-5), Hour = 11, Bills = 4, Sales = 400m } },
        };

        var days = OwnerDay.From(facts, new Dictionary<int, string>());

        // From the first day with bills to the last day asked for, today with no bill yet included.
        Assert.Equal(Enumerable.Range(-5, 6).Select(i => day.AddDays(i)), days.Select(d => d.Day));
        Assert.Equal(new[] { 400m, 0m, 0m, 200m, 0m, 0m }, days.Select(d => d.Sales));
        var none = days[1];
        Assert.Equal((0, 0m), (none.Bills, none.Returns));
        Assert.Empty(none.Hours);
        Assert.Empty(none.Top);
        Assert.Empty(OwnerDay.From(facts with { Days = Array.Empty<DaySales>() }, new Dictionary<int, string>()));
    }

    [Fact]
    public void The_app_carries_the_supabase_script_as_it_is()
    {
        using var script = typeof(OwnerViewScript).Assembly.GetManifestResourceStream("supabase-owner-view.sql");
        Assert.NotNull(script);
        using var reader = new StreamReader(script);
        var path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "cloud", "supabase-owner-view.sql");
        Assert.Equal(File.ReadAllText(path), reader.ReadToEnd());
    }

    [Fact]
    public async Task Connecting_calls_the_project_with_the_public_key_and_the_code()
    {
        var handler = new SupabaseStub().Answer(HttpStatusCode.OK, "{\"key\":\"" + new string('k', 64) + "\",\"shop_id\":\"5b8f\",\"shop_name\":\"Demo Mart 99\"}");
        var client = new OwnerViewClient(new HttpClient(handler));
        var anon = Jwt("anon");

        var connection = await client.ConnectAsync("https://abcd.supabase.co", anon, "ABCDEFGH", "Shop PC (TILL-1)", default);

        Assert.Equal((new string('k', 64), "5b8f", "Demo Mart 99"), (connection.Key, connection.ShopId, connection.ShopName));
        var (request, body) = Assert.Single(handler.Requests);
        Assert.Equal("https://abcd.supabase.co/rest/v1/rpc/connect_shop_pc", request.RequestUri!.ToString());
        Assert.Equal(anon, Assert.Single(request.Headers.GetValues("apikey")));
        Assert.Equal("Bearer " + anon, request.Headers.Authorization!.ToString());
        Assert.Equal("{\"p_code\":\"ABCDEFGH\",\"p_label\":\"Shop PC (TILL-1)\"}", body);
    }

    [Fact]
    public void The_answer_for_the_owner_has_the_words_and_the_table_as_Ask_AI_shows_them()
    {
        var rows = Enumerable.Range(1, 120)
            .Select(i => new object[] { "Product " + i, 10m * i, new DateTime(2026, 9, 27, 18, 57, 0), new DateTime(2026, 9, 27), DBNull.Value, true })
            .ToList();
        rows[0][0] = new string('x', 300);
        var message = new ChatMessage(ChatRole.Assistant, "Here are the best sellers.", DateTime.Now)
        {
            Table = ChatTable.From(new QueryResult(new[] { "Name", "Sales", "Last sold", "Day", "Note", "Active" }, rows, truncated: true, TimeSpan.FromSeconds(1))),
            Sql = "select top 5 Name from Product",
            Source = "Codex CLI · 4.2 s",
        };

        var answer = OwnerAnswer.From(message, maskContacts: false);
        var json = JsonSerializer.Serialize(answer, Web);

        Assert.Equal(("Here are the best sellers.", "Codex CLI · 4.2 s", false), (answer.Text, answer.Source, answer.Failed));
        Assert.Equal(new[] { "Name", "Sales", "Last sold", "Day", "Note", "Active" }, answer.Columns);
        Assert.Equal((OwnerAnswer.MaxRows, 120), (answer.Rows.Count, answer.TotalRows));
        Assert.Equal(new object?[] { "Product 2", 20m, "2026-09-27 18:57", "2026-09-27", null, true }, answer.Rows[1]);
        Assert.Equal(OwnerAnswer.MaxCellLength, Assert.IsType<string>(answer.Rows[0][0]).Length);
        // The query itself stays at the shop.
        Assert.DoesNotContain("select top", json);
        Assert.DoesNotContain("\"failed\"", json);
        Assert.True(OwnerAnswer.From(new ChatMessage(ChatRole.Assistant, "No AI tool is ready.", DateTime.Now) { IsProblem = true }, maskContacts: true).Failed);
        // JSON has no NaN: such a cell is sent empty.
        var odd = new ChatMessage(ChatRole.Assistant, "Odd figures.", DateTime.Now)
        {
            Table = ChatTable.From(new QueryResult(new[] { "A", "B", "C" }, new List<object[]> { new object[] { double.NaN, float.PositiveInfinity, 1.5 } }, truncated: false, TimeSpan.Zero)),
        };
        Assert.Equal(new object?[] { null, null, 1.5 }, OwnerAnswer.From(odd, maskContacts: false).Rows[0]);
    }

    [Fact]
    public void Contact_details_leave_the_shop_masked_unless_privacy_shares_them()
    {
        var rows = new List<object[]> { new object[] { "Ramesh Kumar", "9876543210", "Asked on 98765 43210 about ramesh@example.com", 1250m } };
        var message = new ChatMessage(ChatRole.Assistant, "Ramesh (9876543210) owes the most.", DateTime.Now)
        {
            Table = ChatTable.From(new QueryResult(new[] { "Customer", "Mobile", "Note", "Due" }, rows, truncated: false, TimeSpan.Zero)),
        };

        var masked = OwnerAnswer.From(message, maskContacts: true);
        var json = JsonSerializer.Serialize(masked, Web);

        Assert.DoesNotContain("9876543210", json);
        Assert.DoesNotContain("98765 43210", json);
        Assert.DoesNotContain("ramesh@example.com", json);
        Assert.Equal(("Ramesh Kumar", 1250m), ((string)masked.Rows[0][0]!, (decimal)masked.Rows[0][3]!));
        Assert.Contains("9876543210", JsonSerializer.Serialize(OwnerAnswer.From(message, maskContacts: false), Web));
    }

    [Fact]
    public void A_wide_answer_is_cut_to_what_Supabase_takes_and_says_how_many_rows_there_were()
    {
        var columns = Enumerable.Range(1, 14).Select(i => "Column " + i).ToArray();
        var rows = Enumerable.Range(1, 120).Select(r => columns.Select(_ => (object)new string('x', 250)).ToArray()).ToList();
        var message = new ChatMessage(ChatRole.Assistant, "Everything.", DateTime.Now)
        {
            Table = ChatTable.From(new QueryResult(columns, rows, truncated: true, TimeSpan.Zero)),
        };

        var full = OwnerAnswer.From(message, maskContacts: true);
        var sent = full.Fit();

        Assert.True(JsonSerializer.SerializeToUtf8Bytes(full, Web).Length > OwnerAnswer.MaxBytes);
        Assert.True(JsonSerializer.SerializeToUtf8Bytes(sent, Web).Length <= OwnerAnswer.MaxBytes);
        Assert.InRange(sent.Rows.Count, 1, 99);
        Assert.Equal(120, sent.TotalRows);
        Assert.Same(sent, sent.Fit());
    }

    [Fact]
    public async Task The_shop_PC_takes_a_question_and_gives_the_answer_with_its_own_key()
    {
        var handler = new SupabaseStub().Answer(HttpStatusCode.OK, "{\"id\":\"9c1f\",\"question\":\"How were sales today?\",\"asked_at\":\"2026-09-27T17:00:00+00:00\"}");
        var client = new OwnerViewClient(new HttpClient(handler));

        var question = await client.NextQuestionAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", default);
        handler.Answer(HttpStatusCode.OK, "null");
        var none = await client.NextQuestionAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", default);
        handler.Answer(HttpStatusCode.NoContent, "");
        await client.AnswerAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", "9c1f", OwnerAnswer.Problem("Too slow."), default);

        Assert.Equal(new OwnerQuestion("9c1f", "How were sales today?"), question);
        Assert.Null(none);
        Assert.EndsWith("/rest/v1/rpc/next_shop_question", handler.Requests[0].Request.RequestUri!.ToString());
        Assert.Equal("{\"p_key\":\"device-key\"}", handler.Requests[0].Body);
        var (request, body) = handler.Requests[2];
        Assert.EndsWith("/rest/v1/rpc/answer_shop_question", request.RequestUri!.ToString());
        using var json = JsonDocument.Parse(body!);
        Assert.Equal(("device-key", "9c1f", true), (json.RootElement.GetProperty("p_key").GetString(), json.RootElement.GetProperty("p_id").GetString(), json.RootElement.GetProperty("p_failed").GetBoolean()));
        Assert.Equal("Too slow.", json.RootElement.GetProperty("p_answer").GetProperty("text").GetString());
    }

    [Fact]
    public async Task A_publishable_key_goes_in_apikey_only()
    {
        var handler = new SupabaseStub().Answer(HttpStatusCode.OK, "\"2026-09-27T13:32:00+00:00\"");
        var client = new OwnerViewClient(new HttpClient(handler));

        await client.SendAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", OwnerLive.From(Inputs()), Array.Empty<OwnerDay>(), default);

        var (request, body) = Assert.Single(handler.Requests);
        Assert.EndsWith("/rest/v1/rpc/send_live_figures", request.RequestUri!.ToString());
        Assert.Null(request.Headers.Authorization);
        using var json = JsonDocument.Parse(body!);
        Assert.Equal("device-key", json.RootElement.GetProperty("p_key").GetString());
        Assert.Equal(750m, json.RootElement.GetProperty("p_live").GetProperty("today").GetProperty("sales").GetDecimal());
        Assert.Equal(JsonValueKind.Array, json.RootElement.GetProperty("p_days").ValueKind);
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, "{\"code\":\"P0001\",\"message\":\"That code is wrong or has expired. Make a new one on the website.\"}", "That code is wrong or has expired", false)]
    [InlineData(HttpStatusCode.Forbidden, "{\"code\":\"28000\",\"message\":\"This shop PC is not connected\"}", "disconnected on the website", true)]
    [InlineData(HttpStatusCode.NotFound, "{\"code\":\"PGRST202\",\"message\":\"Could not find the function\"}", "not set up in this Supabase project", false)]
    [InlineData(HttpStatusCode.Unauthorized, "{\"message\":\"Invalid API key\"}", "did not accept the public key", false)]
    [InlineData(HttpStatusCode.InternalServerError, "oops", "could not take the figures (500)", false)]
    public async Task Supabase_problems_are_said_for_the_owner(HttpStatusCode status, string body, string expected, bool disconnected)
    {
        var client = new OwnerViewClient(new HttpClient(new SupabaseStub().Answer(status, body)));

        var problem = await Assert.ThrowsAsync<OwnerViewException>(() =>
            client.SendAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", OwnerLive.From(Inputs()), Array.Empty<OwnerDay>(), default));

        Assert.Contains(expected, problem.Message);
        Assert.Equal(disconnected, problem.Disconnected);
    }

    [Fact]
    public async Task The_review_goes_to_the_project_under_its_kind_with_the_shop_PCs_key()
    {
        var handler = new SupabaseStub().Answer(HttpStatusCode.OK, "\"2026-09-28T04:00:00+00:00\"");
        var client = new OwnerViewClient(new HttpClient(handler));
        var review = OwnerReview.From(new OwnerReviewInputs
        {
            Week = new DateRange(new DateOnly(2026, 9, 21), new DateOnly(2026, 9, 27)),
            ThisWeek = new SalesTotals { Sales = 1000m, Bills = 4 },
        });

        await client.SendReportAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", OwnerReview.Kind, review, default);

        var (request, body) = Assert.Single(handler.Requests);
        Assert.EndsWith("/rest/v1/rpc/send_shop_report", request.RequestUri!.ToString());
        Assert.Null(request.Headers.Authorization);
        using var json = JsonDocument.Parse(body!);
        Assert.Equal(("device-key", "review"), (json.RootElement.GetProperty("p_key").GetString(), json.RootElement.GetProperty("p_kind").GetString()));
        var data = json.RootElement.GetProperty("p_data");
        Assert.Equal((1000m, 4, "2026-09-21"), (data.GetProperty("thisWeek").GetProperty("sales").GetDecimal(), data.GetProperty("thisWeek").GetProperty("bills").GetInt32(), data.GetProperty("thisWeek").GetProperty("from").GetString()));
    }

    [Fact]
    public async Task A_project_with_an_older_script_is_told_to_run_it_again_but_only_for_the_review()
    {
        var client = new OwnerViewClient(new HttpClient(new SupabaseStub().Answer(HttpStatusCode.NotFound, "{\"code\":\"PGRST202\",\"message\":\"Could not find the function public.send_shop_report\"}")));

        var review = await Assert.ThrowsAsync<OwnerViewException>(() =>
            client.SendReportAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", OwnerReview.Kind, new { }, default));
        var live = await Assert.ThrowsAsync<OwnerViewException>(() =>
            client.SendAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", OwnerLive.From(Inputs()), Array.Empty<OwnerDay>(), default));

        Assert.Equal(OwnerViewClient.MissingReports, review.Message);
        Assert.Contains("weekly review", review.Message);
        Assert.False(review.Disconnected);
        Assert.Contains("not set up in this Supabase project", live.Message);
    }

    [Fact]
    public async Task A_shop_PC_disconnected_on_the_website_is_told_so_when_it_sends_the_review_too()
    {
        var client = new OwnerViewClient(new HttpClient(new SupabaseStub().Answer(HttpStatusCode.Forbidden, "{\"code\":\"28000\",\"message\":\"This shop PC is not connected\"}")));

        var problem = await Assert.ThrowsAsync<OwnerViewException>(() =>
            client.SendReportAsync("https://abcd.supabase.co", "sb_publishable_abc", "device-key", OwnerReview.Kind, new { }, default));

        Assert.True(problem.Disconnected);
    }

    [Fact]
    public async Task No_connection_is_said_plainly()
    {
        var client = new OwnerViewClient(new HttpClient(new SupabaseStub { Failure = new HttpRequestException("No such host") }));

        var problem = await Assert.ThrowsAsync<OwnerViewException>(() =>
            client.ConnectAsync("https://abcd.supabase.co", "sb_publishable_abc", "ABCDEFGH", "Shop PC", default));

        Assert.Contains("Could not reach Supabase", problem.Message);
    }

    /// <summary>Answers every request the same way and keeps what was sent.</summary>
    private sealed class SupabaseStub : HttpMessageHandler
    {
        private HttpStatusCode _status = HttpStatusCode.OK;
        private string _body = "";

        public List<(HttpRequestMessage Request, string? Body)> Requests { get; } = new();

        public Exception? Failure { get; init; }

        public SupabaseStub Answer(HttpStatusCode status, string body)
        {
            _status = status;
            _body = body;
            return this;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add((request, request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken)));
            if (Failure is not null)
            {
                throw Failure;
            }

            return new HttpResponseMessage(_status) { Content = new StringContent(_body, Encoding.UTF8, "application/json") };
        }
    }
}
