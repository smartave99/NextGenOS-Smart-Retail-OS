using SmartRetail.Pos.Core;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Billing;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Data.Demo;

/// <summary>
/// A sample shop held in memory: products, customers and two years of bills. Used for demos, training and
/// screenshots, and whenever no POS database is configured. Saving a bill lowers stock, as the real shop
/// would. Nothing is written to disk; restarting the app resets it.
/// </summary>
public sealed class DemoStore : IProductRepository, ICustomerRepository, IStockRepository, IInvoiceRepository, ISalesFactsRepository, IShopChecksRepository
{
    /// <summary>Two years, so every period on the sales dashboard has a period before it to compare with.</summary>
    public const int HistoryDays = 730;

    // Bills from 9 AM to 9 PM: a quiet morning, a lull after lunch and the evening rush, as real shops see.
    private static readonly double[] HourWeights = { 0.5, 0.8, 1.0, 0.9, 0.7, 0.6, 0.7, 0.9, 1.2, 1.6, 1.7, 1.2 };

    // Busier weekends and festive months (Navratri, Diwali), a quieter May, as a small Indian shop sees.
    private static readonly decimal[] WeekdayFactor = { 1.25m, 0.85m, 0.9m, 0.95m, 1.0m, 1.1m, 1.35m };
    private static readonly decimal[] MonthFactor = { 0m, 0.95m, 0.9m, 1.0m, 1.0m, 0.9m, 1.05m, 1.0m, 1.05m, 1.0m, 1.25m, 1.3m, 1.1m };

    private readonly object _gate = new();
    private readonly List<Product> _products;
    private readonly List<Customer> _customers;
    private readonly List<StoredInvoice> _invoices = new();
    private readonly DateOnly _today;
    private readonly Dictionary<int, int> _billsPerFinancialYear = new();
    private long _lastInvoiceId;

    public DemoStore(TimeProvider clock, bool seedSales)
    {
        ArgumentNullException.ThrowIfNull(clock);
        _today = DateOnly.FromDateTime(clock.GetLocalNow().DateTime);
        _products = DemoCatalog.Products().ToList();
        _customers = DemoCatalog.Customers().ToList();
        if (seedSales)
        {
            SeedSales(clock.GetLocalNow().DateTime);
        }
    }

    public Task<IReadOnlyList<Product>> SearchAsync(string? term, int limit, CancellationToken ct = default)
    {
        lock (_gate)
        {
            IEnumerable<Product> query = _products;
            if (!string.IsNullOrWhiteSpace(term))
            {
                var t = term.Trim();
                query = query.Where(p => Contains(p.Name, t) || Contains(p.Code, t) || Contains(p.Barcode, t));
            }
            return Task.FromResult<IReadOnlyList<Product>>(query.OrderBy(p => p.Name).Take(limit).ToList());
        }
    }

    public Task<Product?> FindByCodeAsync(string codeOrBarcode, CancellationToken ct = default)
    {
        var code = codeOrBarcode?.Trim() ?? "";
        lock (_gate)
        {
            var product = _products.FirstOrDefault(p =>
                string.Equals(p.Code, code, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(p.Barcode, code, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(product);
        }
    }

    Task<IReadOnlyList<Customer>> ICustomerRepository.SearchAsync(string? term, int limit, CancellationToken ct)
    {
        lock (_gate)
        {
            IEnumerable<Customer> query = _customers;
            if (!string.IsNullOrWhiteSpace(term))
            {
                var t = term.Trim();
                query = query.Where(c => Contains(c.Name, t) || Contains(c.Phone, t));
            }
            return Task.FromResult<IReadOnlyList<Customer>>(query.OrderBy(c => c.Name).Take(limit).ToList());
        }
    }

    public Task<IReadOnlyList<StockLevel>> GetLowStockAsync(int limit, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var low = _products
                .Where(p => p.IsLowStock)
                .Select(p => new StockLevel { ProductId = p.Id, Code = p.Code, Name = p.Name, InHand = p.StockInHand, MinStock = p.MinStock })
                .OrderByDescending(s => s.Shortfall)
                .ThenBy(s => s.Name)
                .Take(limit)
                .ToList();
            return Task.FromResult<IReadOnlyList<StockLevel>>(low);
        }
    }

    public Task<SavedInvoice> SaveAsync(NewInvoice invoice, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(invoice);
        if (invoice.Lines.Count == 0)
        {
            throw new InvalidOperationException("A bill needs at least one item.");
        }

        lock (_gate)
        {
            if (invoice.CustomerId is { } customerId && _customers.All(c => c.Id != customerId))
            {
                throw new InvalidOperationException("That customer is not on record.");
            }

            var stored = Store(invoice);
            foreach (var line in invoice.Lines)
            {
                var index = _products.FindIndex(p => p.Id == line.ProductId);
                if (index >= 0)
                {
                    _products[index] = _products[index] with { StockInHand = _products[index].StockInHand - line.Qty };
                }
            }

            return Task.FromResult(new SavedInvoice
            {
                Id = stored.Summary.Id,
                Number = stored.Summary.Number,
                GrandTotal = invoice.Totals.GrandTotal,
                ChangeDue = invoice.ChangeDue,
                Balance = invoice.Balance,
            });
        }
    }

    public Task<IReadOnlyList<InvoiceSummary>> GetRecentAsync(int limit, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var recent = _invoices
                .Select(i => i.Summary)
                .OrderByDescending(s => s.Date)
                .ThenByDescending(s => s.Id)
                .Take(limit)
                .ToList();
            return Task.FromResult<IReadOnlyList<InvoiceSummary>>(recent);
        }
    }

    public Task<IReadOnlyList<PriceFacts>> GetPricesAsync(CancellationToken ct = default)
    {
        lock (_gate)
        {
            IReadOnlyList<PriceFacts> prices = _products.Select(p => new PriceFacts
            {
                ProductId = p.Id,
                Name = p.Name,
                Code = string.IsNullOrWhiteSpace(p.Barcode) ? p.Code : p.Barcode,
                Price = p.SellingPrice,
                Mrp = p.Mrp,
                Cost = CostPrice(p),
                GstPercent = p.GstRatePercent,
                Qty = p.StockInHand,
            }).ToList();
            return Task.FromResult(prices);
        }
    }

    public Task<IReadOnlyList<SoldLine>> GetSoldLinesAsync(DateRange range, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var costs = _products.ToDictionary(p => p.Id, CostPrice);
            var mrps = _products.ToDictionary(p => p.Id, p => p.Mrp);
            IReadOnlyList<SoldLine> lines = _invoices
                .Where(i => range.Contains(DateOnly.FromDateTime(i.Summary.Date)))
                .SelectMany(i => i.Invoice.Lines.Select(l => new SoldLine
                {
                    BillId = i.Summary.Id,
                    BillNumber = i.Summary.Number,
                    Date = i.Summary.Date,
                    ProductId = l.ProductId,
                    Name = l.Name,
                    Qty = l.Qty,
                    Rate = l.Rate,
                    Mrp = mrps.GetValueOrDefault(l.ProductId),
                    Discount = l.Discount,
                    Amount = l.LineTotal,
                    Taxable = l.Taxable,
                    PurchaseRate = costs.GetValueOrDefault(l.ProductId),
                }))
                .ToList();
            return Task.FromResult(lines);
        }
    }

    public Task<IReadOnlyList<BillStub>> GetBillsAsync(DateRange range, CancellationToken ct = default)
    {
        lock (_gate)
        {
            IReadOnlyList<BillStub> bills = _invoices
                .Where(i => range.Contains(DateOnly.FromDateTime(i.Summary.Date)))
                .Select(i => new BillStub(i.Summary.Id, i.Summary.Number, i.Summary.Date))
                .OrderBy(b => b.Id)
                .ToList();
            return Task.FromResult(bills);
        }
    }

    public Task<IReadOnlyList<StockBatch>> GetBatchesAsync(IReadOnlyCollection<int> productIds, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(productIds);
        lock (_gate)
        {
            // The demo shop keeps one batch a product, billed by its barcode.
            IReadOnlyList<StockBatch> batches = _products
                .Where(p => productIds.Contains(p.Id))
                .Select(p => new StockBatch
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Code = string.IsNullOrWhiteSpace(p.Barcode) ? p.Code : p.Barcode,
                    Mrp = p.Mrp,
                    Price = p.SellingPrice,
                    Qty = p.StockInHand,
                })
                .ToList();
            return Task.FromResult(batches);
        }
    }

    public Task<BillPage> SearchAsync(BillQuery query, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(query);
        query = query.Checked();
        lock (_gate)
        {
            var phones = _customers.ToDictionary(c => c.Id, c => c.Phone);
            var from = query.From?.ToDateTime(TimeOnly.MinValue);
            var to = query.To?.AddDays(1).ToDateTime(TimeOnly.MinValue);
            var matching = _invoices
                .Where(i => (from is null || i.Summary.Date >= from) && (to is null || i.Summary.Date < to))
                .Where(i => !query.OnlyOwed || i.Summary.Balance > 0)
                .Where(i => query.UpToId is not { } upTo || i.Summary.Id <= upTo)
                .Where(i => query.Text is not { } text
                    || Contains(i.Summary.Number, text)
                    || Contains(i.Summary.CustomerName, text)
                    || (i.Invoice.CustomerId is { } id && Contains(phones.GetValueOrDefault(id), text)))
                .Select(i => i.Summary)
                .ToList();

            return Task.FromResult(new BillPage
            {
                Items = matching.OrderByDescending(s => s.Date).ThenByDescending(s => s.Id).Skip(query.Skip).Take(query.Take).ToList(),
                Total = matching.Count,
                TotalAmount = matching.Sum(s => s.GrandTotal),
                TotalOwed = matching.Sum(s => Math.Max(0m, s.Balance)),
                First = matching.Count == 0 ? null : matching.Min(s => s.Date),
                Last = matching.Count == 0 ? null : matching.Max(s => s.Date),
                NewestId = matching.Count == 0 ? null : matching.Max(s => s.Id),
            });
        }
    }

    public Task<BillDetails?> GetAsync(long id, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var bill = _invoices.Find(i => i.Summary.Id == id);
            if (bill is null)
            {
                return Task.FromResult<BillDetails?>(null);
            }

            var invoice = bill.Invoice;
            var products = _products.ToDictionary(p => p.Id);
            return Task.FromResult<BillDetails?>(new BillDetails
            {
                Summary = bill.Summary,
                CustomerPhone = _customers.Find(c => c.Id == invoice.CustomerId)?.Phone,
                SubTotal = invoice.Lines.Sum(l => l.LineTotal),
                Cgst = invoice.Totals.Cgst,
                Sgst = invoice.Totals.Sgst,
                Igst = invoice.Totals.Igst,
                RoundOff = invoice.Totals.RoundOff,
                Paid = invoice.Paid,
                Operator = "Counter 1",
                Items = invoice.Lines.Select(line => new BillItem
                {
                    ProductId = line.ProductId,
                    Name = line.Name,
                    Code = line.Code,
                    Qty = line.Qty,
                    Rate = line.Rate,
                    Mrp = products.GetValueOrDefault(line.ProductId)?.Mrp ?? 0m,
                    Discount = line.Discount,
                    TaxPercent = line.GstRatePercent,
                    Tax = line.Tax,
                    Amount = line.LineTotal,
                }).ToList(),
                Payments = invoice.Paid > 0
                    ? new[] { new BillPayment(invoice.CreatedAtLocal, invoice.PaymentMode, invoice.Paid) }
                    : Array.Empty<BillPayment>(),
            });
        }
    }

    public Task<SalesSummary> GetSalesForDayAsync(DateOnly day, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var bills = _invoices.Where(i => DateOnly.FromDateTime(i.Summary.Date) == day).ToList();
            return Task.FromResult(new SalesSummary
            {
                Day = day,
                BillCount = bills.Count,
                Total = bills.Sum(b => b.Summary.GrandTotal),
                Outstanding = bills.Sum(b => b.Summary.Balance),
            });
        }
    }

    // Caller holds _gate.
    private StoredInvoice Store(NewInvoice invoice)
    {
        var date = DateOnly.FromDateTime(invoice.CreatedAtLocal);
        var fyStart = FinancialYear.StartYear(date);
        var sequence = _billsPerFinancialYear.GetValueOrDefault(fyStart) + 1;
        _billsPerFinancialYear[fyStart] = sequence;

        var stored = new StoredInvoice(
            new InvoiceSummary
            {
                Id = ++_lastInvoiceId,
                Number = $"SR/{FinancialYear.ShortLabel(date)}/{sequence:0000}",
                // As the POS keeps it: the date on the bill, the time only in its log.
                Date = invoice.CreatedAtLocal.Date,
                SavedAt = invoice.CreatedAtLocal,
                CustomerName = invoice.CustomerName,
                GrandTotal = invoice.Totals.GrandTotal,
                Balance = invoice.Balance,
            },
            invoice);
        _invoices.Add(stored);
        return stored;
    }

    public Task<BillSpan?> GetBillSpanAsync(CancellationToken ct = default)
    {
        lock (_gate)
        {
            if (_invoices.Count == 0)
            {
                return Task.FromResult<BillSpan?>(null);
            }

            var days = _invoices.Select(i => DateOnly.FromDateTime(i.Summary.Date)).ToList();
            return Task.FromResult<BillSpan?>(new BillSpan(days.Min(), days.Max()));
        }
    }

    public Task<int> CountBillsWithAsync(DateRange range, IReadOnlyCollection<int> productIds, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(productIds);
        lock (_gate)
        {
            return Task.FromResult(_invoices.Count(i => range.Contains(DateOnly.FromDateTime(i.Summary.Date))
                && i.Invoice.Lines.Any(l => productIds.Contains(l.ProductId))));
        }
    }

    public Task<SalesFacts> GetFactsAsync(DateRange range, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var costs = _products.ToDictionary(p => p.Id, CostPrice);
            var bills = _invoices.Where(i => range.Contains(DateOnly.FromDateTime(i.Summary.Date))).ToList();
            var firstBills = _invoices
                .GroupBy(i => i.Invoice.CustomerId ?? 0)
                .ToDictionary(g => g.Key, g => DateOnly.FromDateTime(g.Min(i => i.Summary.Date)));

            return Task.FromResult(new SalesFacts
            {
                Range = range,
                Days = bills
                    .GroupBy(b => DateOnly.FromDateTime(b.Summary.Date))
                    .Select(g => new DaySales
                    {
                        Day = g.Key,
                        Bills = g.Count(),
                        Sales = g.Sum(b => b.Summary.GrandTotal),
                        Outstanding = g.Sum(b => b.Summary.Balance),
                    })
                    .OrderBy(d => d.Day)
                    .ToList(),
                ProductDays = bills
                    .SelectMany(b => b.Invoice.Lines.Select(line => (Day: DateOnly.FromDateTime(b.Summary.Date), BillId: b.Summary.Id, Line: line)))
                    .GroupBy(x => (x.Day, x.Line.ProductId))
                    .Select(g =>
                    {
                        var cost = costs.GetValueOrDefault(g.Key.ProductId);
                        var beforeTax = g.Sum(x => x.Line.Taxable);
                        var qty = g.Sum(x => x.Line.Qty);
                        return new ProductDaySales
                        {
                            Day = g.Key.Day,
                            ProductId = g.Key.ProductId,
                            Qty = qty,
                            Sales = g.Sum(x => x.Line.LineTotal),
                            SalesBeforeTax = beforeTax,
                            CostedSalesBeforeTax = cost > 0 ? beforeTax : 0m,
                            Cost = cost * qty,
                            Bills = g.Select(x => x.BillId).Distinct().Count(),
                        };
                    })
                    .ToList(),
                Hours = bills
                    .Where(b => b.Summary.Time is not null)
                    .GroupBy(b => (Day: DateOnly.FromDateTime(b.Summary.Date), b.Summary.Time!.Value.Hour))
                    .Select(g => new HourSales { Day = g.Key.Day, Hour = g.Key.Hour, Bills = g.Count(), Sales = g.Sum(b => b.Summary.GrandTotal) })
                    .ToList(),
                Payments = bills
                    .Where(b => b.Invoice.Paid > 0)
                    .GroupBy(b => b.Invoice.PaymentMode)
                    .Select(g => new PaymentTotal { Mode = g.Key, Payments = g.Count(), Amount = g.Sum(b => b.Invoice.Paid) })
                    .ToList(),
                Customers = bills
                    .GroupBy(b => b.Invoice.CustomerId ?? 0)
                    .Select(g => new CustomerFacts
                    {
                        Id = g.Key,
                        Name = g.Key == 0 ? "Walk-in customer" : g.First().Invoice.CustomerName,
                        Bills = g.Count(),
                        Sales = g.Sum(b => b.Summary.GrandTotal),
                        FirstBillEver = firstBills[g.Key],
                        LastBill = DateOnly.FromDateTime(g.Max(b => b.Summary.Date)),
                    })
                    .ToList(),
            });
        }
    }

    public Task<IReadOnlyList<BillTime>> GetBillTimesAsync(DateRange range, CancellationToken ct = default)
    {
        lock (_gate)
        {
            IReadOnlyList<BillTime> times = _invoices
                .Where(i => range.Contains(DateOnly.FromDateTime(i.Summary.Date)))
                .OrderBy(i => i.Summary.Date).ThenBy(i => i.Summary.Id)
                .Select(i => new BillTime(DateOnly.FromDateTime(i.Summary.Date), i.Summary.SavedAt, i.Summary.GrandTotal))
                .ToList();
            return Task.FromResult(times);
        }
    }

    public Task<IReadOnlyList<ProductFacts>> GetProductsAsync(CancellationToken ct = default)
    {
        lock (_gate)
        {
            return Task.FromResult<IReadOnlyList<ProductFacts>>(_products.Select(p => new ProductFacts
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Category = p.Category ?? "",
                StockInHand = p.StockInHand,
                MinStock = p.MinStock,
                CostPrice = CostPrice(p),
                SellingPrice = p.SellingPrice,
                GstRatePercent = p.GstRatePercent,
                AddedOn = DemoCatalog.NewArrivals.TryGetValue(p.Name, out var days)
                    ? _today.AddDays(-days)
                    : _today.AddDays(-(HistoryDays - 1)),
            }).ToList());
        }
    }

    /// <summary>An illustrative purchase price: the price before GST less a typical margin for the category. One
    /// product's supplier raised the price and the shop did not follow, so the demo has a mistake to find.</summary>
    private static decimal CostPrice(Product product)
    {
        if (DemoCatalog.PurchasePrices.TryGetValue(product.Name, out var set))
        {
            return set;
        }

        var share = product.Category switch
        {
            "Staples" => 0.88m,
            "Oils & Ghee" or "Dairy" => 0.9m,
            "Beverages" => 0.8m,
            "Snacks" => 0.72m,
            "Personal Care" => 0.75m,
            "Household" => 0.78m,
            "Stationery" => 0.6m,
            _ => 0.8m,
        };
        return Money.Round(product.SellingPrice / (1m + product.GstRatePercent / 100m) * share);
    }

    /// <summary>A repeatable two years of counter sales ending now, built with the real billing rules: more
    /// bills at weekends and in the festive season, a steady growth, stationery that only sells when schools
    /// open, coffee that stopped selling a few months ago, and a few kitchen products added in the last weeks.</summary>
    private void SeedSales(DateTime now)
    {
        var random = new Random(20260401);
        for (var daysAgo = HistoryDays - 1; daysAgo >= 0; daysAgo--)
        {
            var day = now.Date.AddDays(-daysAgo);
            var expected = 9m * WeekdayFactor[(int)day.DayOfWeek] * MonthFactor[day.Month] * (1m - 0.12m * daysAgo / 365m);
            var times = Enumerable.Range(0, daysAgo == 0 ? 5 : Math.Max(3, (int)Math.Round(expected) + random.Next(-2, 3)))
                .Select(_ => day.Add(OpeningTime(random.Next(0, 12 * 60))))
                .Order()
                .ToList();
            if (times.Count(t => t > now) is > 0 and var toCome)
            {
                // Today's bills still to come are made in the minutes just before now instead, a few minutes apart.
                var gap = TimeSpan.FromTicks(Math.Min(TimeSpan.FromMinutes(6).Ticks, (now - day).Ticks / toCome));
                times = times.Where(t => t <= now)
                    .Concat(Enumerable.Range(0, toCome).Select(i => now - gap * (toCome - 1 - i)))
                    .Order()
                    .ToList();
            }

            var weights = _products.Select(p => Popularity(p, day, daysAgo)).ToList();
            var nth = 0;
            foreach (var time in times)
            {
                nth++;
                var bill = new Bill();
                for (var l = random.Next(1, 5); l > 0; l--)
                {
                    bill.Add(_products[Pick(random, weights)], random.Next(1, 4));
                }

                if (daysAgo == 1 && nth == 1)
                {
                    // Yesterday's first bill: 40% off two bottles of water, more than was meant, sold below cost. Always
                    // the same product, whatever else the bill has, so the checks have the same mistake to find every day.
                    var water = _products.First(p => p.Name == "Drinking Water 1 L");
                    foreach (var line in bill.Lines.Where(l => l.ProductId == water.Id).ToList())
                    {
                        bill.Remove(line);
                    }

                    bill.Add(water, 2m).DiscountPercent = 40m;
                }

                var roll = random.Next(100);
                var mode = roll < 4 ? PaymentModes.Credit : roll < 12 ? PaymentModes.Card : roll < 50 ? PaymentModes.Upi : PaymentModes.Cash;
                if (mode == PaymentModes.Credit || random.Next(100) < 28)
                {
                    // Regulars: the first few customers come far more often than the rest.
                    bill.Customer = _customers[Math.Min(random.Next(_customers.Count), random.Next(_customers.Count))];
                }

                var total = bill.Totals.GrandTotal;
                var received = mode == PaymentModes.Credit ? Money.RoundToRupee(total / 2m) : total;
                Store(bill.ToInvoice(mode, received, time));
                if (daysAgo == 2 && nth == 1)
                {
                    // A bill typed in the next morning: its time of sale is not known.
                    var late = _invoices[^1];
                    _invoices[^1] = late with { Summary = late.Summary with { SavedAt = day.AddDays(1).AddHours(10).AddMinutes(5) } };
                }

                if (daysAgo == 3 && nth == 2)
                {
                    // A bill deleted at the till: its number is gone, which the checks notice.
                    _invoices.RemoveAt(_invoices.Count - 1);
                }
            }
        }
    }

    /// <summary>The time a bill is made from an even random minute of the 12 opening hours, spread by
    /// <see cref="HourWeights"/>. Later minutes give later times, so the bills of a day keep their order.</summary>
    private static TimeSpan OpeningTime(int minute)
    {
        var left = minute / (12.0 * 60) * HourWeights.Sum();
        var hour = 0;
        while (hour < HourWeights.Length - 1 && left >= HourWeights[hour])
        {
            left -= HourWeights[hour];
            hour++;
        }

        return TimeSpan.FromHours(9 + hour) + TimeSpan.FromMinutes(Math.Min(59, left / HourWeights[hour] * 60));
    }

    private static double Popularity(Product product, DateTime day, int daysAgo)
    {
        if (product.Name.StartsWith("Instant Coffee", StringComparison.Ordinal) && daysAgo < 120)
        {
            return 0;
        }

        if (DemoCatalog.NewArrivals.TryGetValue(product.Name, out var added) && daysAgo > added)
        {
            // Not in the shop yet.
            return 0;
        }

        return product.Category switch
        {
            "Staples" or "Dairy" => 3,
            "Snacks" => 2.5,
            "Beverages" => 2,
            "Oils & Ghee" or "Personal Care" => 1.5,
            "Stationery" => day.Month is 6 or 7 ? 4 : 0,
            _ => 1,
        };
    }

    private static int Pick(Random random, IReadOnlyList<double> weights)
    {
        var roll = random.NextDouble() * weights.Sum();
        for (var i = 0; i < weights.Count; i++)
        {
            roll -= weights[i];
            if (roll < 0)
            {
                return i;
            }
        }

        return weights.Count - 1;
    }

    private static bool Contains(string? value, string term) =>
        value is not null && value.Contains(term, StringComparison.OrdinalIgnoreCase);

    private sealed record StoredInvoice(InvoiceSummary Summary, NewInvoice Invoice);
}
