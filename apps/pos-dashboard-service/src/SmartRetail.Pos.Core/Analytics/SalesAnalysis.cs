namespace SmartRetail.Pos.Core.Analytics;

/// <summary>Turns a period's sales facts into the report behind the sales dashboard and the AI growth plan.
/// Pure: no clock, no database.</summary>
public static class SalesAnalysis
{
    public const int TopProductCount = 15;
    public const int ChangeCount = 5;
    public const int ListLimit = 25;
    public const int TopCustomerCount = 10;

    /// <summary>Stock that lasts fewer days than this, at the period's pace, needs reordering.</summary>
    public const int ReorderWithinDays = 7;

    /// <summary>A product must be on at least this many bills to count as a seller worth reordering (one-off
    /// items that sold out are normal), and on one bill per <see cref="ReorderDaysPerBill"/> days over longer periods.</summary>
    public const int ReorderMinimumBills = 3;
    public const int ReorderDaysPerBill = 10;

    /// <summary>A default customer holding more than this share of the bills is the walk-in customer.</summary>
    public const decimal WalkInShareThreshold = 0.25m;

    private static readonly HashSet<string> WalkInNames = new(StringComparer.OrdinalIgnoreCase)
    {
        "", "cash", "cash customer", "cash sale", "cash sales", "walk in", "walk-in", "walkin", "walk in customer",
        "walk-in customer", "counter", "counter sale", "general", "general customer", "customer",
    };

    public static SalesReport Analyse(SalesFacts current, SalesFacts previous, IReadOnlyList<ProductFacts> products)
    {
        ArgumentNullException.ThrowIfNull(current);
        ArgumentNullException.ThrowIfNull(previous);
        ArgumentNullException.ThrowIfNull(products);

        var range = current.Range;
        var catalog = products.GroupBy(p => p.Id).ToDictionary(g => g.Key, g => g.First());
        var days = current.Days.Where(d => range.Contains(d.Day)).ToList();
        var previousDays = previous.Days.Where(d => previous.Range.Contains(d.Day)).ToList();
        var sold = SumByProduct(current.ProductDays.Where(p => range.Contains(p.Day)));
        var soldBefore = SumByProduct(previous.ProductDays.Where(p => previous.Range.Contains(p.Day)));
        var totals = Totals(days, sold.Values);

        // Per-day rates count from the first bill in the period, so a shop that started mid-period is not
        // diluted by days before it existed.
        var firstSale = days.Where(d => d.Bills > 0).Select(d => (DateOnly?)d.Day).Min();
        var hours = Hours(current.Hours.Where(h => range.Contains(h.Day)));
        var activeDays = firstSale is { } first ? range.To.DayNumber - first.DayNumber + 1 : range.Days;

        return new SalesReport
        {
            Range = range,
            PreviousRange = previous.Range,
            Current = totals,
            Previous = Totals(previousDays, soldBefore.Values),
            Daily = Daily(range, days, previous.Range, previousDays),
            Monthly = Monthly(range, days, current.ProductDays),
            Weekdays = Weekdays(range, days, firstSale),
            Hours = hours,
            TimedBills = hours.Sum(h => h.Bills),
            TimesReadable = current.TimesReadable,
            BusiestHours = BusiestHours(hours),
            TopProducts = TopProducts(sold, soldBefore, catalog, activeDays),
            Rising = Changes(sold, soldBefore, catalog, rising: true, totals.Sales),
            Falling = Changes(sold, soldBefore, catalog, rising: false, totals.Sales),
            Categories = Categories(sold, soldBefore, catalog),
            SlowMovers = SlowMovers(products, sold, range).Take(ListLimit).ToList(),
            SlowMoverCount = SlowMovers(products, sold, range).Count(),
            MoneyInSlowStock = SlowMovers(products, sold, range).Sum(s => s.StockValue),
            ReorderNow = ReorderNow(sold, catalog, activeDays),
            NegativeStock = products.Where(p => p.StockInHand < 0)
                .OrderBy(p => p.StockInHand).ThenBy(p => p.Name, StringComparer.OrdinalIgnoreCase)
                .Take(ListLimit)
                .Select(p => new StockProblem(p.Id, p.Code, p.Name, p.StockInHand))
                .ToList(),
            NegativeStockCount = products.Count(p => p.StockInHand < 0),
            Payments = Payments(current.Payments),
            Customers = Customers(current.Customers, range, totals.Bills, out var topCustomers),
            TopCustomers = topCustomers,
        };
    }

    /// <summary>Groups the POS's payment mode names: "By Cash" → Cash, "Google Pay" → UPI, and so on.</summary>
    public static string PaymentGroup(string? mode)
    {
        var text = (mode ?? "").Trim().ToLowerInvariant();
        if (text.Length == 0)
        {
            return "Other";
        }

        if (text.Contains("card"))
        {
            return "Card";
        }

        if (text.Contains("upi") || text.Contains("google") || text.Contains("gpay") || text.Contains("phonepe")
            || text.Contains("phone pe") || text.Contains("paytm") || text.Contains("bhim") || text.Contains("wallet"))
        {
            return "UPI / wallet";
        }

        if (text.Contains("cheque") || text.Contains("check"))
        {
            return "Cheque";
        }

        if (text.Contains("credit") || text.Contains("udhar") || text.Contains("later"))
        {
            return "Credit";
        }

        if (text.Contains("bank") || text.Contains("neft") || text.Contains("rtgs") || text.Contains("imps") || text.Contains("transfer"))
        {
            return "Bank transfer";
        }

        return text.Contains("cash") ? "Cash" : "Other";
    }

    /// <summary>The POS's default customer for counter sales: named like "Cash", or holding a large share of all bills.</summary>
    public static bool IsWalkIn(CustomerFacts customer, int billsInPeriod)
    {
        ArgumentNullException.ThrowIfNull(customer);
        var name = string.Join(' ', (customer.Name ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries));
        return WalkInNames.Contains(name)
            || (billsInPeriod >= 20 && customer.Bills > billsInPeriod * WalkInShareThreshold);
    }

    private static SalesTotals Totals(IReadOnlyCollection<DaySales> days, IEnumerable<ProductSum> sold)
    {
        var lines = sold.ToList();
        var bills = days.Sum(d => d.Bills);
        var costed = lines.Sum(p => p.CostedSalesBeforeTax);
        return new SalesTotals
        {
            Sales = days.Sum(d => d.Sales),
            Returns = days.Sum(d => d.Returns),
            SalesBeforeTax = lines.Sum(p => p.SalesBeforeTax),
            Bills = bills,
            DaysWithSales = days.Count(d => d.Bills > 0),
            Outstanding = days.Sum(d => d.Outstanding),
            ProductsPerBill = bills == 0 ? 0m : lines.Sum(p => p.Bills) / (decimal)bills,
            Profit = costed - lines.Sum(p => p.Cost),
            CostedSalesBeforeTax = costed,
        };
    }

    private static List<TrendPoint> Daily(DateRange range, List<DaySales> days, DateRange previousRange, List<DaySales> previousDays)
    {
        var sales = previousDays.Concat(days).GroupBy(d => d.Day).ToDictionary(g => g.Key, g => (Sales: g.Sum(d => d.Sales), Bills: g.Sum(d => d.Bills)));
        var points = new List<TrendPoint>(range.Days);
        foreach (var day in range.EachDay())
        {
            // The average only uses days the facts cover, so the first days are not dragged down by unknowns.
            var window = Enumerable.Range(0, 7).Select(back => day.AddDays(-back))
                .Where(d => range.Contains(d) || previousRange.Contains(d))
                .ToList();
            var average = window.Sum(d => sales.TryGetValue(d, out var s) ? s.Sales : 0m) / window.Count;
            var today = sales.TryGetValue(day, out var value) ? value : (Sales: 0m, Bills: 0);
            points.Add(new TrendPoint(day, today.Sales, today.Bills, average));
        }

        return points;
    }

    private static List<MonthPoint> Monthly(DateRange range, List<DaySales> days, IReadOnlyList<ProductDaySales> productDays)
    {
        var profit = productDays.Where(p => range.Contains(p.Day))
            .GroupBy(p => (p.Day.Year, p.Day.Month))
            .ToDictionary(g => g.Key, g => g.Sum(p => p.CostedSalesBeforeTax - p.Cost));
        var byMonth = days.GroupBy(d => (d.Day.Year, d.Day.Month)).ToDictionary(g => g.Key, g => (Sales: g.Sum(d => d.Sales), Bills: g.Sum(d => d.Bills)));

        var months = new List<MonthPoint>();
        for (var month = new DateOnly(range.From.Year, range.From.Month, 1); month <= range.To; month = month.AddMonths(1))
        {
            var key = (month.Year, month.Month);
            var totals = byMonth.TryGetValue(key, out var value) ? value : (Sales: 0m, Bills: 0);
            var partial = month < range.From || month.AddMonths(1).AddDays(-1) > range.To;
            months.Add(new MonthPoint(month.Year, month.Month, totals.Sales, totals.Bills, profit.GetValueOrDefault(key), partial));
        }

        return months;
    }

    private static List<WeekdayPoint> Weekdays(DateRange range, List<DaySales> days, DateOnly? firstSale)
    {
        var counted = range.EachDay().Where(d => firstSale is null || d >= firstSale).ToList();
        var byDay = days.GroupBy(d => d.Day).ToDictionary(g => g.Key, g => (Sales: g.Sum(d => d.Sales), Bills: g.Sum(d => d.Bills)));
        var order = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
        return order.Select(weekday =>
        {
            var matching = counted.Where(d => d.DayOfWeek == weekday).ToList();
            if (matching.Count == 0)
            {
                return new WeekdayPoint(weekday, 0m, 0m, 0);
            }

            var sales = matching.Sum(d => byDay.TryGetValue(d, out var v) ? v.Sales : 0m);
            var bills = matching.Sum(d => byDay.TryGetValue(d, out var v) ? v.Bills : 0);
            return new WeekdayPoint(weekday, sales / matching.Count, bills / (decimal)matching.Count, matching.Count);
        }).ToList();
    }

    /// <summary>Every hour from the earliest to the latest one with a bill, empty hours in between included.</summary>
    private static List<HourPoint> Hours(IEnumerable<HourSales> hours)
    {
        var byHour = hours
            .Where(h => h.Hour is >= 0 and <= 23 && h.Bills > 0)
            .GroupBy(h => h.Hour)
            .ToDictionary(g => g.Key, g => (Sales: g.Sum(h => h.Sales), Bills: g.Sum(h => h.Bills)));
        if (byHour.Count == 0)
        {
            return new List<HourPoint>();
        }

        var total = byHour.Values.Sum(v => v.Sales);
        var first = byHour.Keys.Min();
        return Enumerable.Range(first, byHour.Keys.Max() - first + 1)
            .Select(hour =>
            {
                var (sales, bills) = byHour.GetValueOrDefault(hour);
                return new HourPoint(hour, sales, bills, total > 0 ? sales / total : 0m);
            })
            .ToList();
    }

    /// <summary>The two hours in a row with the most sales (the earlier pair on a tie), or one hour when the other of
    /// the pair sold nothing.</summary>
    private static HourWindow? BusiestHours(IReadOnlyList<HourPoint> hours)
    {
        if (hours.All(h => h.Sales <= 0))
        {
            return null;
        }

        var first = Enumerable.Range(0, Math.Max(1, hours.Count - 1))
            .OrderByDescending(i => hours[i].Sales + (i + 1 < hours.Count ? hours[i + 1].Sales : 0m))
            .ThenBy(i => i)
            .First();
        var pair = hours.Skip(first).Take(2).Where(h => h.Sales > 0).ToList();
        return new HourWindow(pair[0].Hour, pair[^1].Hour + 1, pair.Sum(h => h.Sales), pair.Sum(h => h.Bills), pair.Sum(h => h.Share));
    }

    private static List<ProductLine> TopProducts(Dictionary<int, ProductSum> sold, Dictionary<int, ProductSum> soldBefore, Dictionary<int, ProductFacts> catalog, int activeDays)
    {
        var total = sold.Values.Sum(p => p.Sales);
        return sold.Values
            .Where(p => p.Sales > 0)
            .OrderByDescending(p => p.Sales).ThenBy(p => p.ProductId)
            .Take(TopProductCount)
            .Select(p =>
            {
                var product = catalog.GetValueOrDefault(p.ProductId);
                var before = soldBefore.GetValueOrDefault(p.ProductId)?.Sales ?? 0m;
                var perDay = p.Qty / activeDays;
                var stock = product?.StockInHand ?? 0m;
                return new ProductLine
                {
                    ProductId = p.ProductId,
                    Code = product?.Code ?? "",
                    Name = product?.Name ?? "Product " + p.ProductId,
                    Category = CategoryOf(product),
                    Qty = p.Qty,
                    Sales = p.Sales,
                    Share = total > 0 ? p.Sales / total : 0m,
                    Bills = p.Bills,
                    Profit = p.CostedSalesBeforeTax - p.Cost,
                    ProfitMargin = p.CostedSalesBeforeTax > 0 ? (p.CostedSalesBeforeTax - p.Cost) / p.CostedSalesBeforeTax : null,
                    StockInHand = stock,
                    DaysOfStock = perDay > 0 ? Math.Max(0m, stock) / perDay : null,
                    PreviousSales = before,
                    Change = before > 0 ? (p.Sales - before) / before : null,
                };
            })
            .ToList();
    }

    private static List<ProductChange> Changes(Dictionary<int, ProductSum> sold, Dictionary<int, ProductSum> soldBefore, Dictionary<int, ProductFacts> catalog, bool rising, decimal totalSales)
    {
        if (soldBefore.Count == 0)
        {
            return new List<ProductChange>();
        }

        // Ignore changes too small to matter: under 0.5% of the period's sales.
        var noticeable = totalSales * 0.005m;
        var changes = sold.Keys.Union(soldBefore.Keys)
            .Select(id =>
            {
                var product = catalog.GetValueOrDefault(id);
                return new ProductChange(
                    id,
                    product?.Name ?? "Product " + id,
                    CategoryOf(product),
                    sold.GetValueOrDefault(id)?.Sales ?? 0m,
                    soldBefore.GetValueOrDefault(id)?.Sales ?? 0m);
            })
            .Where(c => Math.Abs(c.Difference) >= Math.Max(noticeable, 0.01m));

        return (rising
                ? changes.Where(c => c.Difference > 0).OrderByDescending(c => c.Difference)
                : changes.Where(c => c.Difference < 0).OrderBy(c => c.Difference))
            .ThenBy(c => c.ProductId)
            .Take(ChangeCount)
            .ToList();
    }

    private static List<CategoryLine> Categories(Dictionary<int, ProductSum> sold, Dictionary<int, ProductSum> soldBefore, Dictionary<int, ProductFacts> catalog)
    {
        var total = sold.Values.Sum(p => p.Sales);
        var before = soldBefore.Values
            .GroupBy(p => CategoryOf(catalog.GetValueOrDefault(p.ProductId)), StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.Sum(p => p.Sales), StringComparer.OrdinalIgnoreCase);

        return sold.Values
            .GroupBy(p => CategoryOf(catalog.GetValueOrDefault(p.ProductId)), StringComparer.OrdinalIgnoreCase)
            .Select(g =>
            {
                var sales = g.Sum(p => p.Sales);
                var costed = g.Sum(p => p.CostedSalesBeforeTax);
                var profit = costed - g.Sum(p => p.Cost);
                var previousSales = before.GetValueOrDefault(g.Key);
                return new CategoryLine
                {
                    Name = g.Key,
                    Sales = sales,
                    Share = total > 0 ? sales / total : 0m,
                    Profit = profit,
                    ProfitMargin = costed > 0 ? profit / costed : null,
                    ProductsSold = g.Count(p => p.Qty > 0),
                    PreviousSales = previousSales,
                    Change = previousSales > 0 ? (sales - previousSales) / previousSales : null,
                };
            })
            .OrderByDescending(c => c.Sales).ThenBy(c => c.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IEnumerable<SlowMover> SlowMovers(IReadOnlyList<ProductFacts> products, Dictionary<int, ProductSum> sold, DateRange range)
    {
        return products
            // A product added during the period has not had the whole period to sell.
            .Where(p => p.Active && p.StockInHand > 0 && !(sold.GetValueOrDefault(p.Id)?.Qty > 0) && !(p.AddedOn > range.From))
            .Select(p => new SlowMover
            {
                ProductId = p.Id,
                Code = p.Code,
                Name = p.Name,
                Category = CategoryOf(p),
                StockInHand = p.StockInHand,
                StockValue = p.StockInHand * (p.CostPrice > 0 ? p.CostPrice : p.SellingPrice),
            })
            .OrderByDescending(s => s.StockValue).ThenBy(s => s.Name, StringComparer.OrdinalIgnoreCase);
    }

    private static List<ReorderItem> ReorderNow(Dictionary<int, ProductSum> sold, Dictionary<int, ProductFacts> catalog, int activeDays)
    {
        return sold.Values
            .Where(p => p.Qty > 0 && p.Bills >= Math.Max(ReorderMinimumBills, (activeDays + ReorderDaysPerBill - 1) / ReorderDaysPerBill)
                && catalog.ContainsKey(p.ProductId))
            .Select(p =>
            {
                var product = catalog[p.ProductId];
                var perDay = p.Qty / activeDays;
                return new ReorderItem
                {
                    ProductId = p.ProductId,
                    Code = product.Code,
                    Name = product.Name,
                    StockInHand = product.StockInHand,
                    MinStock = product.MinStock,
                    QtyPerDay = perDay,
                    DaysOfStock = Math.Max(0m, product.StockInHand) / perDay,
                    Sales = p.Sales,
                };
            })
            .Where(r => r.StockInHand <= 0 || (r.MinStock > 0 && r.StockInHand <= r.MinStock) || r.DaysOfStock < ReorderWithinDays)
            .OrderByDescending(r => r.Sales).ThenBy(r => r.ProductId)
            .Take(ListLimit)
            .ToList();
    }

    private static List<PaymentShare> Payments(IReadOnlyList<PaymentTotal> payments)
    {
        var total = payments.Sum(p => p.Amount);
        return payments
            .GroupBy(p => PaymentGroup(p.Mode))
            .Select(g => new PaymentShare(g.Key, g.Sum(p => p.Amount), g.Sum(p => p.Payments), total > 0 ? g.Sum(p => p.Amount) / total : 0m))
            .OrderByDescending(p => p.Amount).ThenBy(p => p.Group, StringComparer.Ordinal)
            .ToList();
    }

    private static CustomerSummary Customers(IReadOnlyList<CustomerFacts> customers, DateRange range, int bills, out IReadOnlyList<TopCustomer> top)
    {
        var walkIn = customers.Where(c => IsWalkIn(c, bills)).ToList();
        var named = customers.Where(c => !IsWalkIn(c, bills)).ToList();
        top = named
            .OrderByDescending(c => c.Sales).ThenBy(c => c.Id)
            .Take(TopCustomerCount)
            .Select(c => new TopCustomer(c.Name, c.Bills, c.Sales, c.LastBill))
            .ToList();

        var walkInBills = walkIn.Sum(c => c.Bills);
        return new CustomerSummary
        {
            NamedCustomers = named.Count,
            RepeatCustomers = named.Count(c => c.Bills >= 2),
            NewCustomers = named.Count(c => range.Contains(c.FirstBillEver)),
            WalkInBills = walkInBills,
            WalkInShare = bills > 0 ? walkInBills / (decimal)bills : 0m,
            NamedCustomerSales = named.Sum(c => c.Sales),
        };
    }

    private static string CategoryOf(ProductFacts? product) =>
        string.IsNullOrWhiteSpace(product?.Category) ? "Other" : product.Category.Trim();

    private static Dictionary<int, ProductSum> SumByProduct(IEnumerable<ProductDaySales> lines)
    {
        return lines.GroupBy(l => l.ProductId).ToDictionary(g => g.Key, g => new ProductSum
        {
            ProductId = g.Key,
            Qty = g.Sum(l => l.Qty),
            Sales = g.Sum(l => l.Sales),
            SalesBeforeTax = g.Sum(l => l.SalesBeforeTax),
            CostedSalesBeforeTax = g.Sum(l => l.CostedSalesBeforeTax),
            Cost = g.Sum(l => l.Cost),
            Bills = g.Sum(l => l.Bills),
        });
    }

    private sealed record ProductSum
    {
        public int ProductId { get; init; }
        public decimal Qty { get; init; }
        public decimal Sales { get; init; }
        public decimal SalesBeforeTax { get; init; }
        public decimal CostedSalesBeforeTax { get; init; }
        public decimal Cost { get; init; }
        public int Bills { get; init; }
    }
}
