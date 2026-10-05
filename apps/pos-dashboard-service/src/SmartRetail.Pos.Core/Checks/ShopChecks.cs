using System.Globalization;

namespace SmartRetail.Pos.Core.Checks;

/// <summary>
/// The shop's figures checked for mistakes that cost money or break the rules: prices below cost or above MRP,
/// items sold at a loss or above MRP this week, one barcode on two products, and things worth a look (very big
/// discounts, prices far above cost, no purchase price, stock below zero, missing bill numbers, money owed for
/// long). Every finding says what to do in the POS; nothing here changes it.
/// </summary>
public static class ShopChecks
{
    /// <summary>A line with at least this share of its value taken off counts as a big discount.</summary>
    public const decimal BigDiscountShare = 0.3m;

    /// <summary>A price before GST this many times the purchase price or more may be a typing mistake.</summary>
    public const decimal FarAboveCostTimes = 3m;

    /// <summary>A line losing less than this (rounding) is not a loss.</summary>
    private const decimal Paisa = 0.5m;

    private static readonly CultureInfo India = CultureInfo.GetCultureInfo("en-IN");

    /// <summary>Everything found, those to fix now first, the most money at stake first within each kind.</summary>
    public static IReadOnlyList<Finding> Run(CheckFacts facts)
    {
        ArgumentNullException.ThrowIfNull(facts);
        var sales = Sales(facts.RecentLines);
        var findings = new List<Finding>();
        findings.AddRange(PriceFindings(facts.Prices));
        findings.AddRange(SameCodes(facts.Prices));
        findings.AddRange(SoldAtLoss(sales));
        findings.AddRange(SoldAboveMrp(sales));
        findings.AddRange(BigDiscounts(facts.RecentLines));
        findings.AddRange(BigBillDiscounts(facts.RecentLines));
        findings.AddRange(MissingBills(facts.RecentBills));
        if (facts.OwedLong is { Bills: > 0 } owed)
        {
            findings.Add(new Finding
            {
                Key = Key("owed", owed.Bills, owed.Owed),
                Kind = FindingKind.OwedLong,
                Level = FindingLevel.CheckSoon,
                Title = $"{Money.Format(owed.Owed)} owed for over 30 days",
                Detail = $"{Plural(owed.Bills, "bill")} given on credit before {owed.Before.ToString("d MMM", India)} {(owed.Bills == 1 ? "is" : "are")} still not fully paid.",
                WhatToDo = "Remind the customers, and record payments in the POS when they come.",
                AtStake = owed.Owed,
                Since = owed.Oldest,
            });
        }

        return findings
            .OrderBy(f => f.Level)
            .ThenBy(f => f.Kind)
            .ThenByDescending(f => f.AtStake)
            .ThenBy(f => f.Title, StringComparer.Ordinal)
            .ToList();
    }

    /// <summary>The price before GST, which is what a purchase price compares with.</summary>
    public static decimal BeforeGst(decimal price, decimal gstPercent) =>
        gstPercent > 0 ? price / (1m + gstPercent / 100m) : price;

    /// <summary>The lowest whole-rupee price, GST included, that does not lose money.</summary>
    public static decimal LowestFairPrice(decimal cost, decimal gstPercent) =>
        Math.Ceiling(Money.Round(cost * (1m + gstPercent / 100m)));

    private static IEnumerable<Finding> PriceFindings(IReadOnlyList<PriceFacts> prices)
    {
        foreach (var p in prices)
        {
            var inStock = p.Qty > 0;
            var beforeGst = BeforeGst(p.Price, p.GstPercent);
            if (p.Cost > 0 && p.Price > 0 && beforeGst < p.Cost - 0.005m)
            {
                var costWithGst = Money.Round(p.Cost * (1m + p.GstPercent / 100m));
                var loss = costWithGst - p.Price;
                yield return new Finding
                {
                    Key = Key("below-cost", p.ProductId, p.Code, p.Price, p.Cost, p.GstPercent),
                    Kind = FindingKind.BelowCost,
                    Level = inStock ? FindingLevel.FixNow : FindingLevel.CheckSoon,
                    Title = p.Name,
                    Detail = $"Sells for {Money.Format(p.Price)} but costs {Money.Format(costWithGst)} with {Percent(p.GstPercent)} GST (bought at {Money.Format(p.Cost)}). Each one sold loses {Money.Format(loss)}.{StockNote(p)}",
                    WhatToDo = $"In the POS, raise the price to at least {Money.FormatCompact(LowestFairPrice(p.Cost, p.GstPercent))}, or correct the purchase price if it is wrong.",
                    ProductId = p.ProductId,
                    Search = p.Name,
                    AtStake = loss * Math.Max(1m, p.Qty),
                    Problem = Key("below-cost", p.ProductId, p.Code),
                };
            }

            if (p.Mrp > 0 && p.Price > p.Mrp + 0.005m)
            {
                yield return new Finding
                {
                    Key = Key("above-mrp", p.ProductId, p.Code, p.Price, p.Mrp),
                    Kind = FindingKind.AboveMrp,
                    Level = inStock ? FindingLevel.FixNow : FindingLevel.CheckSoon,
                    Title = p.Name,
                    Detail = $"Sells for {Money.Format(p.Price)}, above its MRP of {Money.Format(p.Mrp)}. Charging more than the MRP is not allowed.{StockNote(p)}",
                    WhatToDo = $"In the POS, lower the price to {Money.FormatCompact(p.Mrp)} or less, or correct the MRP if it is wrong.",
                    ProductId = p.ProductId,
                    Search = p.Name,
                    AtStake = (p.Price - p.Mrp) * Math.Max(1m, p.Qty),
                    Problem = Key("above-mrp", p.ProductId, p.Code),
                };
            }

            if (p.Cost > 0 && beforeGst >= p.Cost * FarAboveCostTimes)
            {
                yield return new Finding
                {
                    Key = Key("far-above-cost", p.ProductId, p.Code, p.Price, p.Cost),
                    Kind = FindingKind.FarAboveCost,
                    Level = FindingLevel.CheckSoon,
                    Title = p.Name,
                    Detail = $"Sells for {Money.Format(p.Price)}, {Times(beforeGst / p.Cost)} its purchase price of {Money.Format(p.Cost)} before GST. A typing mistake in the price or the purchase price?",
                    WhatToDo = "Check both in the POS. If they are right, mark this as on purpose.",
                    ProductId = p.ProductId,
                    Search = p.Name,
                    AtStake = 0m,
                    Problem = Key("far-above-cost", p.ProductId, p.Code),
                };
            }

            if (p.Cost <= 0 && inStock)
            {
                yield return new Finding
                {
                    Key = Key("no-cost", p.ProductId, p.Code),
                    Kind = FindingKind.NoCost,
                    Level = FindingLevel.CheckSoon,
                    Title = p.Name,
                    Detail = $"The POS has no purchase price for it, so its profit cannot be worked out, and a price below cost would go unnoticed.{StockNote(p)}",
                    WhatToDo = "Enter the purchase price in the POS.",
                    ProductId = p.ProductId,
                    Search = p.Name,
                    AtStake = p.Price * p.Qty,
                    Problem = Key("no-cost", p.ProductId, p.Code),
                };
            }

            if (p.Qty < 0)
            {
                yield return new Finding
                {
                    Key = Key("negative-stock", p.ProductId, p.Code, p.Qty),
                    Kind = FindingKind.NegativeStock,
                    Level = FindingLevel.CheckSoon,
                    Title = p.Name,
                    Detail = $"The POS shows {Qty(p.Qty)} in stock: it was billed without a purchase being entered, or a count is wrong.",
                    WhatToDo = "Enter the missing purchase, or correct the stock, in the POS.",
                    ProductId = p.ProductId,
                    Search = p.Name,
                    AtStake = -p.Qty * p.Price,
                    Problem = Key("negative-stock", p.ProductId, p.Code),
                };
            }
        }
    }

    private static IEnumerable<Finding> SameCodes(IReadOnlyList<PriceFacts> prices) =>
        prices
            .Where(p => p.Code.Length > 0)
            .GroupBy(p => p.Code, StringComparer.OrdinalIgnoreCase)
            .Select(g => g.GroupBy(p => p.ProductId).Select(same => same.First()).OrderBy(p => p.ProductId).ToList())
            .Where(products => products.Count > 1)
            .Select(products => new Finding
            {
                Key = Key("same-code", products[0].Code, string.Join(",", products.Select(p => p.ProductId))),
                Kind = FindingKind.SameCode,
                Level = FindingLevel.FixNow,
                Title = $"Barcode {products[0].Code}",
                Detail = $"{Plural(products.Count, "product")} share it: {string.Join(", ", products.Select(p => p.Name))}. Scanning it bills only one of them, maybe at the wrong price.",
                WhatToDo = "In the POS, give each product its own barcode, then print new stickers on the Barcodes page.",
                ProductId = products[0].ProductId,
                Search = products[0].Code,
                AtStake = products.Max(p => p.Price) - products.Min(p => p.Price),
                Problem = Key("same-code", products[0].Code),
            });

    /// <summary>A bill line as the customer paid for it: after its own discount and its part of any discount on the
    /// whole bill, which is shared out over the bill's lines by their value.</summary>
    private sealed record Sale(SoldLine Line, decimal Amount, decimal Taxable, decimal OffTheBill)
    {
        /// <summary>What was paid for each piece.</summary>
        public decimal Paid => Money.Round(Amount / Line.Qty);

        public bool Discounted => Line.Discount > 0 || OffTheBill > 0;
    }

    private static IReadOnlyList<Sale> Sales(IReadOnlyList<SoldLine> lines) =>
        lines
            .GroupBy(l => l.BillId)
            .SelectMany(bill =>
            {
                // The POS's lines add up to the bill before its own discount.
                var value = bill.Sum(l => l.Amount);
                var off = bill.Max(l => l.BillDiscount);
                var share = value > 0 && off > 0 ? Math.Min(off, value) / value : 0m;
                return bill.Select(l => new Sale(l, l.Amount * (1m - share), l.Taxable * (1m - share), l.Amount * share));
            })
            .ToList();

    /// <summary>The latest first. Their keys carry the latest bill, so another sale like them shows them again after
    /// the owner marked them as on purpose, while older bills leaving the week do not.</summary>
    private static List<Sale> Newest(IEnumerable<Sale> sales) =>
        sales.OrderByDescending(s => s.Line.Date).ThenByDescending(s => s.Line.BillId).ToList();

    private static IEnumerable<Finding> SoldAtLoss(IReadOnlyList<Sale> sales) =>
        sales
            .Where(s => s.Line.Qty > 0 && s.Line.PurchaseRate > 0 && s.Taxable < s.Line.PurchaseRate * s.Line.Qty - Paisa)
            .GroupBy(s => (s.Line.ProductId, s.Paid, Cost: Money.Round(s.Line.PurchaseRate)))
            .Select(g =>
            {
                var sold = Newest(g);
                var lost = sold.Sum(s => s.Line.PurchaseRate * s.Line.Qty - s.Taxable);
                var qty = sold.Sum(s => s.Line.Qty);
                var first = sold[0].Line;
                return new Finding
                {
                    Key = Key("sold-at-loss", g.Key.ProductId, g.Key.Paid, g.Key.Cost, first.BillId),
                    Kind = FindingKind.SoldAtLoss,
                    Level = FindingLevel.FixNow,
                    Title = first.Name,
                    Detail = $"Sold {Qty(qty)} at {Money.Format(g.Key.Paid)} each{AfterADiscount(sold)}, {Money.Format(Money.Round(sold.Sum(s => s.Taxable) / qty))} before GST, though bought at {Money.Format(first.PurchaseRate)} before GST: {Money.Format(Money.Round(lost))} lost on {Bills(sold)}.",
                    WhatToDo = "Check the price and any discount given at the till, and the purchase price, in the POS.",
                    ProductId = first.ProductId,
                    Search = first.Name,
                    BillId = first.BillId,
                    AtStake = lost,
                    Bills = BillsOf(sold.Select(s => s.Line)),
                };
            });

    private static IEnumerable<Finding> SoldAboveMrp(IReadOnlyList<Sale> sales) =>
        sales
            .Where(s => s.Line.Qty > 0 && s.Line.Mrp > 0 && s.Paid > s.Line.Mrp + 0.005m)
            .GroupBy(s => (s.Line.ProductId, s.Paid, Mrp: Money.Round(s.Line.Mrp)))
            .Select(g =>
            {
                var sold = Newest(g);
                var first = sold[0].Line;
                var over = sold.Sum(s => (s.Paid - s.Line.Mrp) * s.Line.Qty);
                return new Finding
                {
                    Key = Key("sold-above-mrp", g.Key.ProductId, g.Key.Paid, g.Key.Mrp, first.BillId),
                    Kind = FindingKind.SoldAboveMrp,
                    Level = FindingLevel.FixNow,
                    Title = first.Name,
                    Detail = $"Billed at {Money.Format(g.Key.Paid)} each{AfterADiscount(sold)}, above its MRP of {Money.Format(first.Mrp)}: customers paid {Money.Format(Money.Round(over))} too much on {Bills(sold)}.",
                    WhatToDo = $"In the POS, bring the price to {Money.FormatCompact(first.Mrp)} or less. Customers who complain can be refunded the difference.",
                    ProductId = first.ProductId,
                    Search = first.Name,
                    BillId = first.BillId,
                    AtStake = over,
                    Bills = BillsOf(sold.Select(s => s.Line)),
                };
            });

    private static string AfterADiscount(IEnumerable<Sale> sold) => sold.Any(s => s.Discounted) ? " after a discount" : "";

    private static IEnumerable<Finding> BigDiscounts(IReadOnlyList<SoldLine> lines) =>
        lines
            .Where(l => l.Qty > 0 && l.Discount > 0 && l.Discount >= BigDiscountShare * (l.Amount + l.Discount))
            .Select(l => new Finding
            {
                Key = Key("big-discount", l.BillId, l.ProductId, l.Discount),
                Kind = FindingKind.BigDiscount,
                Level = FindingLevel.CheckSoon,
                Title = $"{l.Name}, bill {l.BillNumber}",
                Detail = $"{Money.Format(l.Discount)} off ({Percent(Money.Round(l.Discount / (l.Amount + l.Discount) * 100m))}) on {l.Date.ToString("d MMM", India)}: it came to {Money.Format(l.Amount)}.",
                WhatToDo = "Check with whoever billed it that this discount was meant.",
                ProductId = l.ProductId,
                BillId = l.BillId,
                Search = l.Name,
                AtStake = l.Discount,
                Bills = BillsOf(new[] { l }),
            });

    /// <summary>A big discount on a whole bill: one finding for the bill, not one for each of its lines.</summary>
    private static IEnumerable<Finding> BigBillDiscounts(IReadOnlyList<SoldLine> lines) =>
        lines
            .GroupBy(l => l.BillId)
            .Select(bill => (Line: bill.First(), Value: bill.Sum(l => l.Amount), Off: bill.Max(l => l.BillDiscount)))
            .Where(b => b.Off > 0 && b.Value > 0 && b.Off >= BigDiscountShare * b.Value)
            .Select(b => new Finding
            {
                Key = Key("big-bill-discount", b.Line.BillId, b.Off),
                Kind = FindingKind.BigDiscount,
                Level = FindingLevel.CheckSoon,
                Title = $"Bill {b.Line.BillNumber}",
                Detail = $"{Money.Format(b.Off)} off the whole bill ({Percent(Money.Round(Math.Min(b.Off, b.Value) / b.Value * 100m))} of {Money.Format(b.Value)}) on {b.Line.Date.ToString("d MMM", India)}.",
                WhatToDo = "Check with whoever billed it that this discount was meant.",
                BillId = b.Line.BillId,
                AtStake = b.Off,
                Bills = BillsOf(new[] { b.Line }),
            });

    /// <summary>Gaps in the bills' ids: deleted or cancelled bills leave them.</summary>
    private static IEnumerable<Finding> MissingBills(IReadOnlyList<BillStub> bills)
    {
        var ordered = bills.OrderBy(b => b.Id).ToList();
        for (var i = 1; i < ordered.Count; i++)
        {
            var before = ordered[i - 1];
            var after = ordered[i];
            var missing = after.Id - before.Id - 1;
            if (missing <= 0)
            {
                continue;
            }

            yield return new Finding
            {
                Key = Key("missing-bills", before.Id, after.Id),
                Kind = FindingKind.MissingBills,
                Level = FindingLevel.CheckSoon,
                Title = missing == 1 ? $"1 bill missing after {before.Number}" : $"{missing} bills missing after {before.Number}",
                Detail = $"Between bill {before.Number} ({before.Date.ToString("d MMM", India)}) and bill {after.Number} ({after.Date.ToString("d MMM", India)}) the POS has no {(missing == 1 ? "bill" : "bills")} numbered in between. Deleted or cancelled bills leave such gaps.",
                WhatToDo = "Ask who deleted or cancelled them, and why. The POS's own reports may list deleted bills.",
                BillId = before.Id,
                AtStake = missing,
                Bills = new[]
                {
                    new FindingBill(before.Id, before.Number, DateOnly.FromDateTime(before.Date)),
                    new FindingBill(after.Id, after.Number, DateOnly.FromDateTime(after.Date)),
                },
            };
        }
    }

    /// <summary>The distinct bills of some bill lines, the latest first.</summary>
    private static IReadOnlyList<FindingBill> BillsOf(IEnumerable<SoldLine> lines) =>
        lines
            .GroupBy(l => l.BillId)
            .Select(g => new FindingBill(g.Key, g.First().BillNumber, DateOnly.FromDateTime(g.First().Date)))
            .OrderByDescending(b => b.Day).ThenByDescending(b => b.Id)
            .ToList();

    private static string Bills(IEnumerable<Sale> sold)
    {
        var numbers = sold.Select(s => s.Line.BillNumber).Distinct().ToList();
        return numbers.Count switch
        {
            1 => "bill " + numbers[0],
            <= 3 => "bills " + string.Join(", ", numbers),
            _ => $"{numbers.Count} bills, the latest {numbers[0]}",
        };
    }

    private static string StockNote(PriceFacts p) => p.Qty > 0 ? $" {Qty(p.Qty)} in stock." : "";

    private static string Qty(decimal qty) => Money.FormatQty(qty);

    private static string Percent(decimal percent) => percent.ToString("0.##", CultureInfo.InvariantCulture) + "%";

    private static string Times(decimal times) => times.ToString("0.#", CultureInfo.InvariantCulture) + " times";

    private static string Plural(int count, string word) => count == 1 ? "1 " + word : count + " " + word + "s";

    private static string Key(string kind, params object[] parts) =>
        kind + "|" + string.Join("|", parts.Select(p => p switch
        {
            decimal d => Money.Round(d).ToString("0.00", CultureInfo.InvariantCulture),
            IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
            _ => p?.ToString() ?? "",
        }));
}
