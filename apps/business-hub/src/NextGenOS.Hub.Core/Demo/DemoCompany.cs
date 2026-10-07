using System.Globalization;
using System.Text.Json;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Projects;
using NextGenOS.Hub.Purchasing;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Demo;

public sealed class DemoOptions
{
    public string Industry { get; set; } = "retail";
    public string Country { get; set; } = "";
    /// <summary>State or province, for countries whose tax depends on it. Left empty, a sensible one is chosen.</summary>
    public string? Region { get; set; }
    /// <summary>The business name to use; left empty, the industry pack's sample name is used.</summary>
    public string? Name { get; set; }
    /// <summary>How many days of past trading to make.</summary>
    public int Days { get; set; } = 14;
    /// <summary>The same number gives the same company every time.</summary>
    public int Seed { get; set; } = 2026;
}

public sealed record DemoSummary(string Company, string Industry, string Country, int Items, int People, int Documents, int Loans, int Projects, int Bookings, int Tables);

/// <summary>
/// Makes a sample business out of an industry pack, in any country: its items, people and (for a café, library, builder or studio) tables, loans,
/// projects and bookings, then a couple of weeks of trading through the same services the screens use. It is how a business is shown to a buyer, and
/// how every industry is tested from start to finish. Prices are sample figures only.
/// </summary>
public static class DemoCompany
{
    /// <summary>Opens the shop database at the path (it must have no items or documents yet), fills it, and says what it made.</summary>
    public static DemoSummary Fill(string dbPath, DemoOptions options, DateTimeOffset? now = null)
    {
        var real = now ?? DateTimeOffset.UtcNow;
        var clock = new FixedClock(real.AddDays(-Math.Max(1, options.Days)));
        var app = HubApp.Open(dbPath, clock);
        return new Builder(app, clock, options, real).Run();
    }

    private sealed class Builder
    {
        private readonly HubApp _app;
        private readonly FixedClock _clock;
        private readonly DemoOptions _o;
        private readonly DateTimeOffset _now;
        private readonly Random _rng;
        private IndustryPack _pack = null!;
        private ShopContext _shop = null!;
        private int _scale = 1;
        private readonly List<Item> _items = new();
        private readonly List<Party> _people = new();
        private int _tables;
        private int _projects;
        private int _bookings;
        private int _loans;

        public Builder(HubApp app, FixedClock clock, DemoOptions options, DateTimeOffset now)
        {
            _app = app;
            _clock = clock;
            _o = options;
            _now = now;
            _rng = new Random(options.Seed);
        }

        private JsonElement Demo => _pack.Demo;

        public DemoSummary Run()
        {
            var industry = IndustryCatalog.Get(_o.Industry);
            var country = Tax.PackCatalog.Get(_o.Country);
            if (Convert.ToInt64(_app.Db.Scalar("SELECT (SELECT COUNT(*) FROM items) + (SELECT COUNT(*) FROM documents)") ?? 0L) > 0)
                throw new HubException("not-empty", "A demo company can only be added to a new shop that has no items or invoices yet.");

            var region = _o.Region ?? country.Tax.Regions?.List?.FirstOrDefault()?.Code ?? "";
            var existing = _app.SettingsStore.Load();
            existing.Name = !string.IsNullOrWhiteSpace(_o.Name) ? _o.Name!.Trim() : Text(industry.Demo, "company") ?? industry.Name + " demo";
            existing.Country = country.Country;
            existing.Region = region;
            existing.Industry = industry.Id;
            existing.PricesIncludeTax = country.Tax.PricesIncludeTaxDefault;
            existing.RoundTotal = country.Tax.Rounding?.DefaultOn ?? false;
            // The shop is marked as set up only when the sample is fully built (below): the background upkeep waits for that, and the sample's open sales are dated days back, so they would look forgotten.
            _app.Shop.Save(existing);
            _shop = _app.Shop.Current;
            _pack = _shop.Industry;
            _scale = _shop.Decimals == 0 ? _shop.CurrencyCode switch { "IDR" => 100, "VND" => 200, "KRW" => 15, _ => 3 } : 1;

            AddCatalogAndPeople();
            switch (_pack.Id)
            {
                case "restaurant": Restaurant(); break;
                case "library": Library(); break;
                case "construction": Construction(); break;
                case "services": Services(); break;
                default: CounterTrade(); break;
            }
            _clock.Set(_now);
            var finished = _app.SettingsStore.Load();
            finished.SetupDone = true;
            _app.Shop.Save(finished);
            var documents = (int)Convert.ToInt64(_app.Db.Scalar("SELECT COUNT(*) FROM documents") ?? 0L);
            return new DemoSummary(existing.Name, _pack.Id, country.Country, _items.Count, _people.Count, documents, _loans, _projects, _bookings, _tables);
        }

        // ---- reading the pack ----------------------------------------------------------------------------------------------------

        private static string? Text(JsonElement e, string name) =>
            e.ValueKind == JsonValueKind.Object && e.TryGetProperty(name, out var v) && v.ValueKind == JsonValueKind.String ? v.GetString() : null;

        private static IEnumerable<JsonElement> Each(JsonElement e, string name) =>
            e.ValueKind == JsonValueKind.Object && e.TryGetProperty(name, out var v) && v.ValueKind == JsonValueKind.Array ? v.EnumerateArray() : Enumerable.Empty<JsonElement>();

        private static int? Number(JsonElement e, string name) =>
            e.ValueKind == JsonValueKind.Object && e.TryGetProperty(name, out var v) && v.ValueKind == JsonValueKind.Number ? v.GetInt32() : null;

        /// <summary>A sample amount from the pack ("425.00") in this currency's smallest unit, scaled up for currencies with no decimals.</summary>
        private long Minor(string text)
        {
            var value = decimal.Parse(text, NumberStyles.Number, CultureInfo.InvariantCulture) * _scale;
            return (long)Math.Round(value * Pow10(_shop.Decimals), 0, MidpointRounding.AwayFromZero);
        }

        private static decimal Pow10(int n) => (decimal)Math.Pow(10, n);

        private string? Phone(string? text) => text is null ? null : text.StartsWith("+91", StringComparison.Ordinal) ? "+" + _shop.Country.PhoneCode.TrimStart('+') + text[3..] : text;

        // ---- time ------------------------------------------------------------------------------------------------------------------

        private DateOnly Today => _shop.Time.LocalDate(_now);

        private DateOnly DaysAgo(int days) => Today.AddDays(-days);

        /// <summary>Moves the clock to a local time on a day some days ago (but never into the future).</summary>
        private void At(int daysAgo, int hour, int minute = 0)
        {
            var when = _shop.Time.At(DaysAgo(daysAgo), new TimeOnly(hour, minute));
            _clock.Set(when > _now ? _now : when);
        }

        // ---- the catalogue and people ------------------------------------------------------------------------------------------------

        private void AddCatalogAndPeople()
        {
            At(_o.Days, 9);
            var tracksStock = _pack.Features.StockTracking != "never";
            foreach (var p in Each(Demo, "parties"))
            {
                var kind = Text(p, "kind") ?? "customer";
                var party = _app.Parties.Create(new PartyInput
                {
                    Kind = kind,
                    Name = Text(p, "name") ?? "Unnamed",
                    Phone = Phone(Text(p, "phone")),
                    MemberType = Text(p, "memberType"),
                    PriceLevel = Text(p, "priceLevel") ?? "retail",
                    CreditLimitMinor = Text(p, "creditLimit") is { } limit ? Minor(limit) : 0,
                    TermsDays = Text(p, "creditLimit") is not null ? (int)_pack.RuleNumber("creditDays", 30) : 0,
                });
                _people.Add(party);
            }

            foreach (var i in Each(Demo, "items"))
            {
                var kind = Text(i, "kind") ?? "stock";
                if (kind == "title")
                {
                    var title = _app.Library.AddTitle(Text(i, "name") ?? "Untitled", Text(i, "author"), Text(i, "isbn"), Text(i, "category"));
                    _app.Library.AddCopies(title.Id, Number(i, "copies") ?? 1);
                    _items.Add(title);
                    continue;
                }
                var price = Minor(Text(i, "price") ?? "0");
                var stock = Text(i, "stock");
                var item = _app.Catalog.Create(new ItemInput
                {
                    Kind = kind,
                    Name = Text(i, "name") ?? "Unnamed",
                    Category = Text(i, "category"),
                    Unit = Text(i, "unit") ?? "pc",
                    PriceMinor = price,
                    TradePriceMinor = Text(i, "tradePrice") is { } trade ? Minor(trade) : null,
                    CostMinor = stock is not null ? price * 7 / 10 : 0,
                    TaxClass = Text(i, "class") ?? "standard",
                    Barcode = Text(i, "barcode"),
                    Station = Text(i, "station"),
                    DurationMin = Number(i, "duration"),
                    TrackStock = stock is not null && tracksStock ? true : null,
                    ReorderMilli = stock is not null ? 5_000 : 0,
                });
                if (stock is not null && tracksStock) _app.Catalog.Adjust(item.Id, ShopContext.QtyMilli(stock), "opening stock");
                _items.Add(item);
            }
        }

        private IReadOnlyList<Item> Sellable => _items.Where(i => i.Kind is "stock" or "service" or "menu").ToList();

        private T Pick<T>(IReadOnlyList<T> list) => list[_rng.Next(list.Count)];

        private string PayMethod() => Pick(_shop.PaymentMethods.Where(m => m != "credit").ToList());

        /// <summary>The way of paying the story wants ("bank", "cash"), or the shop's own first way when its list of ways does not have it (a customer's prepared setup can choose its own list).</summary>
        private string Way(string wanted) => _shop.PaymentMethods.Contains(wanted) ? wanted : _shop.PaymentMethods.FirstOrDefault(m => m != "credit") ?? wanted;

        /// <summary>What a customer would hand over: the exact amount, or for cash the next note.</summary>
        private long Tender(string method, long payable)
        {
            if (method != "cash") return payable;
            var step = (long)Pow10(_shop.Decimals) * 10;
            return (payable + step - 1) / step * step;
        }

        // ---- shops: counter sales, returns, buying in, trade credit -------------------------------------------------------------------

        private long Qty(Item item) => _shop.Features.WeighedItems && item.Unit is "kg" or "L" ? 500 + 250 * _rng.Next(0, 9) : 1_000 * _rng.Next(1, 4);

        private DocumentView Sale(Party? customer = null, bool onCredit = false, int lines = 0)
        {
            var count = lines > 0 ? lines : _rng.Next(1, 5);
            var picked = Enumerable.Range(0, count).Select(_ => Pick(Sellable)).GroupBy(i => i.Id).Select(g => g.First()).ToList();
            var draft = _app.Documents.CreateDraft(new DraftOptions
            {
                PartyId = customer?.Id,
                Lines = picked.Select(i => new LineInput { ItemId = i.Id, QtyMilli = Qty(i) }).ToList(),
            });
            var payable = draft.Document.PayableMinor;
            if (onCredit) return _app.Documents.Issue(draft.Document.Id, new IssueOptions { OnCredit = true, TermsDays = customer?.TermsDays });
            var method = PayMethod();
            return _app.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = method, AmountMinor = Tender(method, payable) } } });
        }

        private void CounterTrade()
        {
            var customers = _people.Where(p => p.Kind == "customer").ToList();
            var trade = customers.Where(c => c.CreditLimitMinor > 0).ToList();
            var invoices = new List<DocumentView>();
            for (var day = _o.Days; day >= 1; day--)
            {
                if (day == 10) BuyStock(day, payHalf: true);
                if (day == 6) BuyStock(day, payHalf: false);
                var sales = _rng.Next(3, 7);
                for (var n = 0; n < sales; n++)
                {
                    At(day, 9 + n * 2, _rng.Next(0, 55));
                    invoices.Add(Sale(_rng.Next(4) == 0 && customers.Count > 0 ? Pick(customers) : null));
                }
                if (_shop.Features.Credit && trade.Count > 0 && day % 4 == 0)
                {
                    At(day, 18, 30);
                    var buyer = Pick(trade);
                    var sale = Sale(buyer, onCredit: true, lines: 2);
                    if (day % 8 == 0) _app.Documents.AddPayment(sale.Document.Id, new PaymentInput { Method = Way("bank"), AmountMinor = sale.Document.PayableMinor / 2, Reference = "Part payment" });
                }
            }

            _clock.Set(_now.AddMinutes(-120));
            ReturnSomething(invoices);
            _clock.Set(_now.AddMinutes(-100));
            for (var n = 0; n < 4; n++)
            {
                Sale();
                _clock.Advance(TimeSpan.FromMinutes(20));
            }
        }

        /// <summary>A customer brings something back (counter shops only): a recent cash sale, one item.</summary>
        private void ReturnSomething(IReadOnlyList<DocumentView> invoices)
        {
            if (!_shop.Features.CounterSale) return;
            var original = invoices.Where(v => v.Document.PartyId is null && v.Lines.Count > 0).Skip(1).LastOrDefault();
            if (original is null) return;
            var line = original.Lines[0];
            _app.Documents.CreateCreditNote(original.Document.Id, new[] { (line.Id, Math.Min(line.QtyMilli, 1_000L)) }, "Customer returned it", Way("cash"), null);
        }

        /// <summary>Goods arrive from the supplier: stock goes up and the supplier is paid half now, or nothing yet.</summary>
        private void BuyStock(int daysAgo, bool payHalf)
        {
            var supplier = _people.FirstOrDefault(p => p.Kind == "supplier");
            if (supplier is null || !_shop.Features.Purchases) return;
            var stocked = _items.Where(i => i.Kind is "stock" or "ingredient" && i.CostMinor > 0).Take(3).ToList();
            if (stocked.Count == 0) return;
            At(daysAgo, 7);
            var order = _app.Purchasing.CreateOrder(supplier.Id, stocked.Select(i => new PurchaseLine { ItemId = i.Id, QtyMilli = 20_000, CostMinor = i.CostMinor }));
            var received = _app.Purchasing.Receive(order.Document.Id);
            if (payHalf) _app.Purchasing.Pay(order.Document.Id, received.Document.PayableMinor / 2, Way("bank"), "Part payment");
        }

        // ---- restaurant: tables, kitchen, bills --------------------------------------------------------------------------------------------

        private void Restaurant()
        {
            At(_o.Days, 8);
            foreach (var t in Each(Demo, "tables"))
            {
                _app.Restaurant.AddTable(Text(t, "name") ?? "Table", Number(t, "seats") ?? 2, Text(t, "zone"));
                _tables++;
            }
            var menu = _items.Where(i => i.Kind == "menu").ToList();
            var tables = _app.Restaurant.Tables();

            for (var day = _o.Days; day >= 1; day--)
            {
                if (day == 9) BuyStock(day, payHalf: true);
                var visits = _rng.Next(4, 9);
                for (var n = 0; n < visits; n++)
                {
                    At(day, 9 + n * 2, _rng.Next(0, 40));
                    var table = tables[n % tables.Count];
                    var order = _app.Restaurant.OpenOrder(table.Id, Math.Min(table.Seats, _rng.Next(1, 5)));
                    foreach (var item in Enumerable.Range(0, _rng.Next(2, 5)).Select(_ => Pick(menu)).GroupBy(i => i.Id).Select(g => g.First()))
                        _app.Restaurant.AddItem(order.Document.Id, item.Id, 1_000 * _rng.Next(1, 3), _rng.Next(6) == 0 ? "No sugar" : null);
                    var tickets = _app.Restaurant.Fire(order.Document.Id);
                    foreach (var ticket in tickets) for (var step = 0; step < 3; step++) _app.Restaurant.Advance(ticket.Id);
                    _clock.Advance(TimeSpan.FromMinutes(35));
                    Close(order.Document.Id);
                }
                if (day % 2 == 0)
                {
                    At(day, 13, 15);
                    var takeaway = _app.Restaurant.OpenTakeaway("Phone order");
                    _app.Restaurant.AddItem(takeaway.Document.Id, Pick(menu).Id, 2_000);
                    foreach (var ticket in _app.Restaurant.Fire(takeaway.Document.Id)) for (var step = 0; step < 3; step++) _app.Restaurant.Advance(ticket.Id);
                    Close(takeaway.Document.Id, serviceCharge: false);
                }
            }

            // The café as it is right now: tables with guests, food in each stage.
            _clock.Set(_now.AddMinutes(-40));
            var seated = new[] { tables[2], tables[4], tables[5] };
            var orders = seated.Select(t => _app.Restaurant.OpenOrder(t.Id, Math.Min(t.Seats, 3))).ToList();
            foreach (var order in orders)
                foreach (var item in new[] { menu[0], menu[3], menu[^2] }) _app.Restaurant.AddItem(order.Document.Id, item.Id);
            var first = _app.Restaurant.Fire(orders[0].Document.Id);
            foreach (var ticket in first) _app.Restaurant.Advance(ticket.Id);              // being prepared
            var second = _app.Restaurant.Fire(orders[1].Document.Id);
            foreach (var ticket in second) { _app.Restaurant.Advance(ticket.Id); _app.Restaurant.Advance(ticket.Id); } // ready to serve
            // the third table has ordered but nothing is sent to the kitchen yet
        }

        private void Close(long orderId, bool? serviceCharge = null)
        {
            var charge = serviceCharge ?? _rng.Next(3) != 0;
            var tip = _rng.Next(4) == 0 ? _app.Restaurant.TipFromPercent(orderId, 10) : 0;
            var bill = _app.Restaurant.SetBillOptions(orderId, charge && _app.Restaurant.DefaultAdjustments().Count > 0, tip);
            var method = PayMethod();
            _app.Restaurant.Pay(orderId, new[] { new PaymentInput { Method = method, AmountMinor = Tender(method, bill.Document.PayableMinor) } });
        }

        // ---- library: members, loans, fines, a reservation --------------------------------------------------------------------------------------

        private void Library()
        {
            var titles = _items.Where(i => i.Kind == "title").ToList();
            var members = _people.Where(p => p.Kind == "member").ToList();
            if (titles.Count < 6 || members.Count < 4) throw new HubException("demo-data", "The library sample needs at least six titles and four members.");
            var asha = members[0];
            var ravi = members[1];
            var meera = members[2];
            var tara = members[3];

            string Copy(Item title, int index) => _app.Library.CopiesOf(title.Id)[index].Barcode;

            At(20, 10); _loans++; _app.Library.Issue(asha.Id, Copy(titles[0], 0));                 // Asha keeps this one too long
            At(20, 10, 5); _loans++; _app.Library.Issue(asha.Id, Copy(titles[1], 0));
            At(20, 11); _loans++; _app.Library.Issue(tara.Id, Copy(titles[4], 0));
            At(18, 11); _loans++; _app.Library.Issue(ravi.Id, Copy(titles[0], 1));
            At(15, 12); foreach (var t in new[] { titles[1], titles[2], titles[3] }) { _loans++; _app.Library.Issue(meera.Id, Copy(t, t == titles[1] ? 1 : 0)); }
            At(13, 10); _app.Library.Return(Copy(titles[1], 0));                                   // Asha brings one back on time
            At(8, 16); _app.Library.Return(Copy(titles[2], 0));

            // Tara brings hers back three days late and pays the fine at the desk.
            At(3, 10); _app.Library.Return(Copy(titles[4], 0));
            var fine = _app.Library.UnpaidFines(tara.Id).Sum(f => f.AmountMinor);
            _app.Library.PayFines(tara.Id, new[] { new PaymentInput { Method = Way("cash"), AmountMinor = fine } }, null);
            At(3, 11); _app.Library.Renew(_app.Library.OpenLoansOf(meera.Id).First().Loan.Id);

            // Every copy of one title is out, so a member asks for it to be kept for them.
            var popular = titles[5];
            var copies = _app.Library.CopiesOf(popular.Id);
            At(2, 10);
            for (var n = 0; n < copies.Count; n++) { _loans++; _app.Library.Issue(n % 2 == 0 ? meera.Id : tara.Id, copies[n].Barcode); }
            At(1, 10); _app.Library.Reserve(popular.Id, asha.Id);

            // Ravi brings his book back three days late and has not paid the fine yet: the desk will not lend to him until he does.
            At(1, 17); _app.Library.Return(Copy(titles[0], 1));
            _clock.Set(_now);
        }

        // ---- construction: projects, progress bills, costs ----------------------------------------------------------------------------------------

        private void Construction()
        {
            var supplier = _people.FirstOrDefault(p => p.Kind == "supplier");
            var sub = _people.FirstOrDefault(p => p.Kind == "subcontractor");
            var projects = new List<(Project Project, IReadOnlyList<BoqItem> Boq)>();
            At(_o.Days, 9);
            foreach (var p in Each(Demo, "projects"))
            {
                var client = _people.First(x => x.Name == Text(p, "client"));
                var project = _app.Projects.Create(Text(p, "code") ?? "P-000", Text(p, "name") ?? "Project", client.Id, Text(p, "site"), Text(p, "retention"));
                foreach (var b in Each(p, "boq"))
                    _app.Projects.AddBoq(project.Id, Text(b, "code") ?? "", Text(b, "description") ?? "", Text(b, "unit") ?? "lump sum", ShopContext.QtyMilli(Text(b, "qty") ?? "1"), Minor(Text(b, "rate") ?? "0"), Text(b, "kind") ?? "material");
                _app.Projects.CreateQuote(project.Id);
                _app.Projects.SetStatus(project.Id, "active");
                projects.Add((_app.Projects.Get(project.Id)!, _app.Projects.Boq(project.Id)));
                _projects++;
            }
            if (projects.Count < 2) throw new HubException("demo-data", "The construction sample needs two projects.");
            var (house, houseBoq) = projects[0];
            var (shop, shopBoq) = projects[1];

            At(11, 10); _app.Projects.AddCost(house.Id, "material", "Cement, steel and sand for the foundation", Minor("120000.00"), supplier?.Id, houseBoq[0].Id, "BILL-4471");
            At(10, 10); _app.Projects.ReceiveAdvance(shop.Id, _app.Projects.ContractValue(shop.Id) / 10, Way("bank"), "Advance 10%");
            At(9, 14); _app.Projects.AddCost(house.Id, "labour", "Mason gang, two weeks", Minor("40000.00"), null, houseBoq[1].Id);

            At(8, 11);
            var bill1 = _app.Projects.CreateProgressBill(house.Id, new[]
            {
                new ProgressInput { BoqId = houseBoq[0].Id, CumulativePctMilli = 100_000 },
                new ProgressInput { BoqId = houseBoq[1].Id, CumulativePctMilli = 25_000 },
            }, "Progress bill 1");

            At(7, 11); _app.Projects.AddVariation(house.Id, "Extra window opening in the front wall", Minor("18000.00"));
            _app.Projects.Approve(_app.Projects.Variations(house.Id)[0].Id);
            At(6, 10); _app.Projects.AddCost(house.Id, "subcontract", "Roof slab, first payment", Minor("60000.00"), sub?.Id, houseBoq[2].Id, "SUB-12");

            At(5, 11);
            _app.Projects.CreateProgressBill(shop.Id, new[]
            {
                new ProgressInput { BoqId = shopBoq[0].Id, CumulativePctMilli = 50_000 },
                new ProgressInput { BoqId = shopBoq[1].Id, CumulativePctMilli = 40_000 },
            }, "Progress bill 1");
            At(4, 9); _app.Projects.ReceivePayment(bill1.Document.Id, bill1.Document.PayableMinor, Way("bank"), "Transfer received");
            At(4, 15); _app.Projects.AddCost(shop.Id, "labour", "Partition crew", Minor("65000.00"));

            At(3, 11);
            _app.Projects.CreateProgressBill(house.Id, new[]
            {
                new ProgressInput { BoqId = houseBoq[0].Id, CumulativePctMilli = 100_000 },
                new ProgressInput { BoqId = houseBoq[1].Id, CumulativePctMilli = 60_000 },
                new ProgressInput { BoqId = houseBoq[2].Id, CumulativePctMilli = 30_000 },
            }, "Progress bill 2");                                                                  // left unpaid: shows in what is owed
            _clock.Set(_now);
        }

        // ---- services: staff, bookings, visits ------------------------------------------------------------------------------------------------------

        private void Services()
        {
            var staff = _people.Where(p => p.Kind == "staff").ToList();
            var clients = _people.Where(p => p.Kind == "customer").ToList();
            var services = _items.Where(i => i.Kind == "service").ToList();
            var products = _items.Where(i => i.Kind == "stock").ToList();
            if (staff.Count < 2 || clients.Count == 0 || services.Count == 0) throw new HubException("demo-data", "The studio sample needs two staff, a customer and a service.");
            var closed = Each(_pack.Rules.ValueKind == JsonValueKind.Object ? _pack.Rules : default, "closedWeekdays").Select(e => (DayOfWeek)e.GetInt32()).ToHashSet();
            var slots = new[] { new TimeOnly(9, 0), new TimeOnly(11, 0), new TimeOnly(14, 30) };

            for (var day = _o.Days; day >= 1; day--)
            {
                var date = DaysAgo(day);
                if (closed.Contains(date.DayOfWeek)) continue;
                var visits = _rng.Next(2, 4);
                for (var n = 0; n < visits; n++)
                {
                    var who = staff[(day + n) % staff.Count];
                    var client = Pick(clients);
                    var service = Pick(services);
                    At(day, slots[n].Hour, slots[n].Minute);
                    var visit = _app.Appointments.Book(client.Id, who.Id, service.Id, date, slots[n], walkIn: true); // a walk-in arrives as it is booked
                    _clock.Advance(TimeSpan.FromMinutes(service.Id % 2 == 0 ? 45 : 30));
                    var extras = products.Count > 0 && _rng.Next(3) == 0 ? new[] { new LineInput { ItemId = Pick(products).Id } } : null;
                    var worth = service.PriceMinor + (extras is null ? 0 : _items.First(i => i.Id == extras[0].ItemId).PriceMinor);
                    var way = Way("cash");
                    var due = way == "cash" ? worth * 3 / 2 : _app.Appointments.Preview(visit.Id, extras).Document.PayableMinor;   // only cash can be over-paid (change is given)
                    _app.Appointments.Invoice(visit.Id, extras, new[] { new PaymentInput { Method = way, AmountMinor = Tender(way, due) } });
                    _bookings++;
                }
            }

            // Bookings still to come.
            _clock.Set(_now);
            var booked = 0;
            for (var ahead = 1; ahead <= 10 && booked < 5; ahead++)
            {
                var date = Today.AddDays(ahead);
                var who = staff[booked % staff.Count];
                var service = services[booked % services.Count];
                var free = _app.Appointments.FreeSlots(who.Id, service.Id, date);
                if (free.Count == 0) continue;
                _app.Appointments.Book(clients[booked % clients.Count].Id, who.Id, service.Id, date, free[Math.Min(free.Count - 1, booked * 2)]);
                booked++;
                _bookings++;
            }
            if (products.Count > 0)
            {
                _clock.Set(_now.AddMinutes(-60));
                Sale(null, lines: 1);
            }
        }
    }
}
