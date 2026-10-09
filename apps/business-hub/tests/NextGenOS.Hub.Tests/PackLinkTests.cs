using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Purchasing;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Merge, products tools: selling loose from a pack (the older POS's alternate unit and "pieces in one main unit", study 02 A2.3 and M4: a box of 12 bought at 400.00 and sold at 600.00, six pieces sold
/// is half a box: margin 100.00). The Hub links the loose item to its box and opens whole boxes when a sale needs more pieces than are on the shelf. Prices exclude tax and are in rupees.
/// </summary>
public class PackLinkTests
{
    private static HubFixture Shop(bool allowNegative = true) => new("IN", "retail", s => { s.AllowNegativeStock = allowNegative; s.PricesIncludeTax = false; });

    private static Item Box(HubFixture f) => f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Biscuits box", PriceMinor = 60_000, TaxClass = "zero", TrackStock = true });

    private static Item Piece(HubFixture f, Item box, long perPackMilli = 12_000) =>
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Biscuits", PriceMinor = 5_000, TaxClass = "zero", TrackStock = true, PackItemId = box.Id, PerPackMilli = perPackMilli });

    /// <summary>Boxes bought at 400.00 each.</summary>
    private static void BuyBoxes(HubFixture f, Item box, long qtyMilli)
    {
        var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Mill" });
        var order = f.App.Purchasing.CreateOrder(supplier.Id, new[] { new PurchaseLine { ItemId = box.Id, QtyMilli = qtyMilli, CostMinor = 40_000 } });
        f.App.Purchasing.Receive(order.Document.Id);
    }

    private static DocumentView Sell(HubFixture f, Item item, long qtyMilli)
    {
        var draft = f.App.Documents.CreateDraft(new DraftOptions { Lines = { new LineInput { ItemId = item.Id, QtyMilli = qtyMilli } } });
        var pay = f.App.Documents.Get(draft.Document.Id)!.Document.PayableMinor;
        return f.App.Documents.Issue(draft.Document.Id, new IssueOptions { Payments = { new PaymentInput { Method = "cash", AmountMinor = pay } } });
    }

    private static (long Qty, long Value) Stock(HubFixture f, Item item) => f.App.Db.Query("SELECT COALESCE(SUM(qty_milli), 0), COALESCE(SUM(value_minor), 0) FROM stock_moves WHERE item_id = $i", r => (Qty: r.GetInt64(0), Value: r.GetInt64(1)), ("$i", item.Id)).Single();

    [Fact]
    public void M4_selling_pieces_opens_a_box_and_the_pieces_cost_their_share_of_it()
    {
        using var f = Shop();
        var box = Box(f);
        var piece = Piece(f, box);
        BuyBoxes(f, box, 10_000);   // 10 boxes at 400.00

        var sale = Sell(f, piece, 6_000);   // six pieces at 50.00

        Assert.Equal(30_000, sale.Document.TotalMinor);
        Assert.Equal((9_000L, 360_000L), Stock(f, box));   // one box opened: nine left, worth 9 x 400.00
        Assert.Equal((6_000L, 20_000L), Stock(f, piece));  // 12 pieces came out of the box, six were sold: six left, worth half of 400.00
        var row = f.App.Reports.Bills(new DateOnly(2026, 10, 5), new DateOnly(2026, 10, 5)).Single();
        Assert.Equal(20_000, row.CostMinor);               // six pieces cost 200.00 (half a box)
        Assert.Equal(10_000, row.ProfitMinor);             // M4: margin 0.5 x (600 - 400) = 100.00
    }

    [Fact]
    public void A_sale_that_the_loose_pieces_can_fill_opens_nothing_and_the_next_one_that_cannot_opens_another_box()
    {
        using var f = Shop();
        var box = Box(f);
        var piece = Piece(f, box);
        BuyBoxes(f, box, 3_000);

        Sell(f, piece, 5_000);   // opens a box: 12 - 5 = 7 pieces
        Sell(f, piece, 7_000);   // exactly what is left: nothing opened
        Assert.Equal((2_000L, 0L), (Stock(f, box).Qty, Stock(f, piece).Qty));

        Sell(f, piece, 1_000);   // none left: opens a second box
        Assert.Equal((1_000L, 11_000L), (Stock(f, box).Qty, Stock(f, piece).Qty));
        Assert.Equal(2, OpenMoves(f, box));
    }

    private static int OpenMoves(HubFixture f, Item item) => (int)Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM stock_moves WHERE item_id = $i AND reason = 'open-pack'", ("$i", item.Id)));

    [Fact]
    public void A_sale_of_more_than_a_box_opens_as_many_boxes_as_it_needs_and_the_pieces_left_have_the_rest_of_the_value()
    {
        using var f = Shop();
        var box = Box(f);
        var piece = Piece(f, box);
        BuyBoxes(f, box, 5_000);

        Sell(f, piece, 30_000);   // 30 pieces need three boxes (36), six are left

        Assert.Equal((2_000L, 80_000L), Stock(f, box));
        Assert.Equal((6_000L, 20_000L), Stock(f, piece));
        var all = f.App.Catalog.StockList().Sum(s => s.ValueMinor);
        Assert.Equal(80_000 + 20_000, all);   // opening boxes moves value from one item to the other and loses none
    }

    [Fact]
    public void Value_is_never_lost_to_rounding_when_a_box_does_not_divide_into_whole_amounts()
    {
        using var f = Shop();
        var box = Box(f);
        var piece = Piece(f, box, 7_000);   // seven to a box: 400.00 / 7 does not divide
        BuyBoxes(f, box, 1_000);

        Sell(f, piece, 3_000);
        Sell(f, piece, 4_000);

        var (qty, value) = Stock(f, piece);
        Assert.Equal(0, qty);
        Assert.Equal(0, value);   // the last piece took exactly what was left of the box
        Assert.Equal(0, f.App.Catalog.StockList().Sum(s => s.ValueMinor));
    }

    [Fact]
    public void With_no_box_on_the_shelf_the_shops_rule_about_stock_below_nothing_decides()
    {
        using var f = Shop(allowNegative: false);
        var box = Box(f);
        var piece = Piece(f, box);

        var ex = Assert.Throws<HubException>(() => Sell(f, piece, 1_000));

        Assert.Equal("stock", ex.Code);
        Assert.Equal(0, OpenMoves(f, box));
        using var g = Shop(allowNegative: true);
        var box2 = Box(g);
        var piece2 = Piece(g, box2);
        Sell(g, piece2, 1_000);
        Assert.Equal(-1_000, Stock(g, piece2).Qty);   // no box to open: the piece stock goes below nothing, as for any item
    }

    [Fact]
    public void Goods_brought_back_and_a_cancelled_sale_put_pieces_back_as_pieces()
    {
        using var f = Shop();
        var box = Box(f);
        var piece = Piece(f, box);
        BuyBoxes(f, box, 2_000);
        var sale = Sell(f, piece, 5_000);

        f.App.Documents.CreateCreditNote(sale.Document.Id, new[] { (sale.Lines[0].Id, 2_000L) }, "wrong", "cash", null);
        Assert.Equal((1_000L, 9_000L), (Stock(f, box).Qty, Stock(f, piece).Qty));   // 12 - 5 + 2 = 9 pieces

        f.App.Documents.Void(Sell(f, piece, 1_000).Document.Id, "mistake", null);
        Assert.Equal(9_000, Stock(f, piece).Qty);
    }

    [Fact]
    public void Packs_can_be_opened_by_hand_and_only_as_many_as_are_on_the_shelf()
    {
        using var f = Shop();
        var box = Box(f);
        var piece = Piece(f, box);
        BuyBoxes(f, box, 2_000);

        f.App.Catalog.OpenPacks(piece.Id, 2);

        Assert.Equal((0L, 24_000L), (Stock(f, box).Qty, Stock(f, piece).Qty));
        Assert.Equal("stock", Assert.Throws<HubException>(() => f.App.Catalog.OpenPacks(piece.Id, 1)).Code);
        Assert.Equal("pack-count", Assert.Throws<HubException>(() => f.App.Catalog.OpenPacks(piece.Id, 0)).Code);
        Assert.Equal("not-loose", Assert.Throws<HubException>(() => f.App.Catalog.OpenPacks(box.Id, 1)).Code);
    }

    [Fact]
    public void A_link_needs_a_real_pack_of_two_or_more_whole_pieces_and_cannot_be_chained_or_mixed_with_batches()
    {
        using var f = Shop();
        var box = Box(f);
        var piece = Piece(f, box);
        var services = f.App.Catalog.Create(new ItemInput { Kind = "service", Name = "Haircut", PriceMinor = 1_000, TaxClass = "zero" });

        Assert.Equal("pack-size", Assert.Throws<HubException>(() => Piece(f, box, 1_000)).Code);
        Assert.Equal("pack-size", Assert.Throws<HubException>(() => Piece(f, box, 2_500)).Code);
        Assert.Equal("pack-item", Assert.Throws<HubException>(() => f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "X", TaxClass = "zero", TrackStock = true, PackItemId = 9_999, PerPackMilli = 4_000 })).Code);
        Assert.Equal("pack-stock", Assert.Throws<HubException>(() => f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "X", TaxClass = "zero", TrackStock = true, PackItemId = services.Id, PerPackMilli = 4_000 })).Code);
        Assert.Equal("pack-chain", Assert.Throws<HubException>(() => f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Single biscuit", TaxClass = "zero", TrackStock = true, PackItemId = piece.Id, PerPackMilli = 4_000 })).Code);
        Assert.Equal("pack-item", Assert.Throws<HubException>(() => f.App.Catalog.Update(box.Id, new ItemInput { Kind = "stock", Name = box.Name, TaxClass = "zero", TrackStock = true, PackItemId = box.Id, PerPackMilli = 4_000 })).Code);
        Assert.Equal("pack-chain", Assert.Throws<HubException>(() => f.App.Catalog.Update(box.Id, new ItemInput { Kind = "stock", Name = box.Name, TaxClass = "zero", TrackStock = true, PackItemId = piece.Id, PerPackMilli = 4_000 })).Code);
        Assert.Equal("pack-batches", Assert.Throws<HubException>(() => f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Batched", TaxClass = "zero", TrackStock = true, TrackBatches = true, PackItemId = box.Id, PerPackMilli = 4_000 })).Code);
        Assert.Equal("pack-batches", Assert.Throws<HubException>(() => f.App.Catalog.Update(box.Id, new ItemInput { Kind = "stock", Name = box.Name, TaxClass = "zero", TrackStock = true, TrackBatches = true })).Code);   // the box has loose pieces
    }

    [Fact]
    public void A_change_that_says_nothing_about_the_link_keeps_it_and_the_link_can_be_taken_away_or_changed()
    {
        using var f = Shop();
        var box = Box(f);
        var piece = Piece(f, box);

        f.App.Catalog.Update(piece.Id, new ItemInput { Kind = "stock", Name = "Biscuits (loose)", PriceMinor = 5_500, TaxClass = "zero", TrackStock = true });
        var kept = f.App.Catalog.Get(piece.Id)!;
        Assert.Equal((box.Id, 12_000L), (kept.PackItemId, kept.PerPackMilli));

        f.App.Catalog.Update(piece.Id, new ItemInput { Kind = "stock", Name = kept.Name, PriceMinor = kept.PriceMinor, TaxClass = "zero", TrackStock = true, PackItemId = box.Id, PerPackMilli = 10_000 });
        Assert.Equal(10_000, f.App.Catalog.Get(piece.Id)!.PerPackMilli);

        f.App.Catalog.Update(piece.Id, new ItemInput { Kind = "stock", Name = kept.Name, PriceMinor = kept.PriceMinor, TaxClass = "zero", TrackStock = true, PackItemId = 0 });
        var loose = f.App.Catalog.Get(piece.Id)!;
        Assert.Equal((null, 0L), (loose.PackItemId, loose.PerPackMilli));
    }
}
