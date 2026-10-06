using NextGenOS.Hub;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Projects;

namespace NextGenOS.Hub.Tests;

public class ProjectTests
{
    // Prices below are in pounds; the contract is 150,000.00 + VAT: a 100,000.00 foundation and ten walls at 5,000.00.
    private static (HubFixture F, Party Client, Project P, BoqItem A, BoqItem B) Setup(string retention = "5", long advance = 1_500_000)
    {
        var f = new HubFixture("GB", "construction");
        var client = f.App.Parties.Create(new PartyInput { Kind = "client", Name = "R. Singh" });
        var p = f.App.Projects.Create("P-001", "House extension", client.Id, "12 Garden Lane", retention);
        var a = f.App.Projects.AddBoq(p.Id, "1.1", "Foundation", "lump sum", 1000, 10_000_000, "material");
        var b = f.App.Projects.AddBoq(p.Id, "2.1", "Walls", "wall", 10_000, 500_000, "labour");
        if (advance > 0) f.App.Projects.ReceiveAdvance(p.Id, advance, "bank", "cheque 101");
        return (f, client, f.App.Projects.Get(p.Id)!, a, b);
    }

    [Fact]
    public void A_project_has_a_contract_value_from_its_bill_of_quantities_and_an_advance_starts_the_work()
    {
        var (f, _, p, a, b) = Setup(advance: 0);
        using (f)
        {
            Assert.Equal("quoted", p.Status);
            Assert.Equal(10_000_000, a.AmountMinor);
            Assert.Equal(5_000_000, b.AmountMinor);
            Assert.Equal(15_000_000, f.App.Projects.ContractValue(p.Id));
            Assert.Equal("not-active", Assert.Throws<HubException>(() => f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 10_000 } })).Code);
            f.App.Projects.ReceiveAdvance(p.Id, 1_500_000, "bank");
            var after = f.App.Projects.Get(p.Id)!;
            Assert.Equal("active", after.Status);
            Assert.Equal(1_500_000, after.AdvanceMinor);
            Assert.Equal("duplicate-code", Assert.Throws<HubException>(() => f.App.Projects.Create("P-001", "Again", p.PartyId)).Code);
        }
    }

    [Fact]
    public void A_quote_lists_the_bill_of_quantities_with_tax_added_at_the_end()
    {
        var (f, _, p, _, _) = Setup(advance: 0);
        using (f)
        {
            var quote = f.App.Projects.CreateQuote(p.Id);
            Assert.Equal(DocTypes.Quote, quote.Document.Type);
            Assert.StartsWith("QUO-", quote.Document.Number);
            Assert.Equal(15_000_000, quote.Document.SubtotalMinor);
            Assert.Equal(3_000_000, quote.Document.TaxMinor); // 20% VAT, added on top
            Assert.Equal(18_000_000, quote.Document.TotalMinor);
            Assert.Equal(DocStatus.Issued, quote.Document.Status);
        }
    }

    [Fact]
    public void Progress_bills_charge_the_work_since_the_last_bill_hold_back_retention_and_recover_the_advance_to_the_last_penny()
    {
        var (f, _, p, a, b) = Setup();
        using (f)
        {
            // Bill 1: foundation 50%, walls 20% => 50,000 + 10,000
            var bill1 = f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 50_000 }, new ProgressInput { BoqId = b.Id, CumulativePctMilli = 20_000 } });
            Assert.Equal(DocTypes.ProgressBill, bill1.Document.Type);
            Assert.Equal(6_000_000, bill1.Document.SubtotalMinor);
            Assert.Equal(1_200_000, bill1.Document.TaxMinor);
            Assert.Equal(7_200_000, bill1.Document.TotalMinor);
            Assert.Equal(300_000, bill1.Document.RetentionMinor);
            Assert.Equal(600_000, bill1.Document.AdvanceMinor); // 15,000 x 60,000 / 150,000
            Assert.Equal(6_300_000, bill1.Document.PayableMinor);
            Assert.Equal("unpaid", bill1.Document.PaymentState);
            Assert.NotNull(bill1.Document.DueAt);
            Assert.Equal(new DateTimeOffset(2026, 11, 4, 6, 30, 0, TimeSpan.Zero), bill1.Document.DueAt);

            // Bill 2: foundation 100%, walls 60%
            var bill2 = f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 100_000 }, new ProgressInput { BoqId = b.Id, CumulativePctMilli = 60_000 } });
            Assert.Equal(7_000_000, bill2.Document.SubtotalMinor);
            Assert.Equal(350_000, bill2.Document.RetentionMinor);
            Assert.Equal(700_000, bill2.Document.AdvanceMinor);
            Assert.Equal(8_400_000 - 350_000 - 700_000, bill2.Document.PayableMinor);

            // Bill 3: the walls are finished: the rest of the advance is recovered
            var bill3 = f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = b.Id, CumulativePctMilli = 100_000 } });
            Assert.Equal(2_000_000, bill3.Document.SubtotalMinor);
            Assert.Equal(100_000, bill3.Document.RetentionMinor);
            Assert.Equal(200_000, bill3.Document.AdvanceMinor);
            Assert.Equal(1_500_000, f.App.Projects.Get(p.Id)!.AdvanceRecoveredMinor);

            var status = f.App.Projects.Status(p.Id);
            Assert.Equal(15_000_000, status.BilledNetMinor);
            Assert.Equal(750_000, status.RetentionHeldMinor); // 5% of 150,000.00
            Assert.Equal(100_000, status.PercentCompleteMilli);
            Assert.Equal(1_500_000, status.AdvanceRecoveredMinor);
            Assert.Equal(3, f.App.Projects.Bills(p.Id).Count);
        }
    }

    [Fact]
    public void A_bill_cannot_go_back_or_repeat_and_percent_must_make_sense()
    {
        var (f, _, p, a, b) = Setup();
        using (f)
        {
            f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 40_000 } });
            Assert.Equal("percent-back", Assert.Throws<HubException>(() => f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 30_000 } })).Code);
            Assert.Equal("nothing-new", Assert.Throws<HubException>(() => f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 40_000 } })).Code);
            Assert.Equal("percent", Assert.Throws<HubException>(() => f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = b.Id, CumulativePctMilli = 100_001 } })).Code);
            Assert.Equal("boq", Assert.Throws<HubException>(() => f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = 9999, CumulativePctMilli = 10_000 } })).Code);
        }
    }

    [Fact]
    public void Odd_percentages_never_drift_the_total_billed_over_the_bills_is_exactly_the_contract_value()
    {
        var f = new HubFixture("GB", "construction");
        using (f)
        {
            var client = f.App.Parties.Create(new PartyInput { Kind = "client", Name = "Client" });
            var p = f.App.Projects.Create("P-9", "Odd", client.Id, null, "0");
            var item = f.App.Projects.AddBoq(p.Id, "1", "Odd sum", "lump sum", 1000, 1_000_001, "material"); // 10,000.01
            f.App.Projects.ReceiveAdvance(p.Id, 100, "bank");
            long sum = 0;
            foreach (var pct in new long[] { 33_333, 66_667, 100_000 })
                sum += f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = item.Id, CumulativePctMilli = pct } }).Document.SubtotalMinor;
            Assert.Equal(1_000_001, sum);
        }
    }

    [Fact]
    public void Retention_is_released_at_the_end_as_an_untaxed_invoice_and_not_more_than_is_held()
    {
        var (f, client, p, a, b) = Setup();
        using (f)
        {
            f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 100_000 }, new ProgressInput { BoqId = b.Id, CumulativePctMilli = 100_000 } });
            Assert.Equal(750_000, f.App.Projects.RetentionHeld(p.Id));
            Assert.Equal("retention-amount", Assert.Throws<HubException>(() => f.App.Projects.ReleaseRetention(p.Id, 800_000)).Code);
            var half = f.App.Projects.ReleaseRetention(p.Id, 250_000);
            Assert.Equal(250_000, half.Document.TotalMinor);
            Assert.Equal(0, half.Document.TaxMinor);
            Assert.Equal(500_000, f.App.Projects.RetentionHeld(p.Id));
            f.App.Projects.ReleaseRetention(p.Id);
            Assert.Equal(0, f.App.Projects.RetentionHeld(p.Id));
            Assert.Equal("retention-amount", Assert.Throws<HubException>(() => f.App.Projects.ReleaseRetention(p.Id)).Code);
            Assert.Equal(client.Id, half.Document.PartyId);
        }
    }

    [Fact]
    public void Costs_are_kept_by_kind_and_the_profit_so_far_is_what_was_billed_less_what_was_spent()
    {
        var (f, _, p, a, b) = Setup();
        using (f)
        {
            f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 100_000 } });
            var supplier = f.App.Parties.Create(new PartyInput { Kind = "supplier", Name = "Metro Supplies" });
            f.App.Projects.AddCost(p.Id, "material", "Cement and steel", 4_000_000, supplier.Id, a.Id, "INV-7788");
            f.App.Projects.AddCost(p.Id, "labour", "Masons, week 1", 1_200_000);
            Assert.Equal("kind", Assert.Throws<HubException>(() => f.App.Projects.AddCost(p.Id, "gifts", "x", 1)).Code);
            Assert.Equal("amount", Assert.Throws<HubException>(() => f.App.Projects.AddCost(p.Id, "labour", "x", 0)).Code);
            var status = f.App.Projects.Status(p.Id);
            Assert.Equal(5_200_000, status.CostsMinor);
            Assert.Equal(4_000_000, status.CostsByKind["material"]);
            Assert.Equal(10_000_000 - 5_200_000, status.ProfitSoFarMinor);
            Assert.Equal(66_667, status.PercentCompleteMilli); // 100,000 of 150,000
            Assert.NotNull(b);
        }
    }

    [Fact]
    public void An_approved_variation_joins_the_contract_and_can_be_billed_a_rejected_one_does_not()
    {
        var (f, _, p, a, _) = Setup(advance: 0);
        using (f)
        {
            f.App.Projects.ReceiveAdvance(p.Id, 1, "bank");
            var v1 = f.App.Projects.AddVariation(p.Id, "Extra window", 800_000);
            var v2 = f.App.Projects.AddVariation(p.Id, "Cancelled porch", -500_000);
            Assert.Equal(1, v1.No);
            Assert.Equal(2, v2.No);
            Assert.Equal(15_000_000, f.App.Projects.ContractValue(p.Id));
            f.App.Projects.Approve(v1.Id);
            f.App.Projects.Reject(v2.Id);
            Assert.Equal(15_800_000, f.App.Projects.ContractValue(p.Id));
            Assert.Equal("decided", Assert.Throws<HubException>(() => f.App.Projects.Approve(v1.Id)).Code);
            Assert.Equal("decided", Assert.Throws<HubException>(() => f.App.Projects.Reject(v1.Id)).Code);
            var vo = f.App.Projects.Boq(p.Id).Single(x => x.VariationId == v1.Id);
            Assert.Equal("VO-1", vo.Code);
            var bill = f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = vo.Id, CumulativePctMilli = 100_000 } });
            Assert.Equal(800_000, bill.Document.SubtotalMinor);
            Assert.Equal(15_800_000, f.App.Projects.Status(p.Id).ContractMinor);
            Assert.Equal(800_000, f.App.Projects.Status(p.Id).VariationsMinor);
            Assert.NotNull(a);
        }
    }

    [Fact]
    public void The_client_pays_a_bill_in_parts_and_what_is_owed_is_tracked_per_project()
    {
        var (f, client, p, a, _) = Setup();
        using (f)
        {
            var bill = f.App.Projects.CreateProgressBill(p.Id, new[] { new ProgressInput { BoqId = a.Id, CumulativePctMilli = 50_000 } });
            // 50,000 + 10,000 VAT = 60,000; less 2,500 retention and 5,000 advance recovered (15,000 x 50,000 / 150,000) = 52,500 payable
            Assert.Equal(5_250_000, bill.Document.PayableMinor);
            f.App.Projects.ReceiveAdvance(p.Id, 1, "bank");
            f.App.Projects.ReceivePayment(bill.Document.Id, 2_000_000, "bank", "ref 1");
            var status = f.App.Projects.Status(p.Id);
            Assert.Equal(2_000_000, status.PaidMinor);
            Assert.Equal(3_250_000, status.OutstandingMinor);
            Assert.Equal(3_250_000, f.App.Documents.Outstanding(client.Id));
            f.App.Projects.ReceivePayment(bill.Document.Id, 3_250_000, "cheque");
            Assert.Equal(0, f.App.Documents.Outstanding(client.Id));
        }
    }
}
