using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace NextGenOS.Tax.Tests
{
    public class PackTests
    {
        [Fact]
        public void Every_pack_file_is_built_in_and_names_its_own_country()
        {
            var files = Directory.GetFiles(Path.Combine(VectorTests.RepositoryRoot(), "country-packs", "packs"), "*.json");
            Assert.True(files.Length >= 30);
            foreach (var file in files)
            {
                var code = Path.GetFileNameWithoutExtension(file);
                var pack = PackCatalog.Get(code);
                Assert.Equal(code, pack.Country);
                Assert.Equal(1, pack.Schema);
                Assert.Matches("^[A-Z]{3}$", pack.Currency.Code);
            }
            Assert.Equal(files.Length, PackCatalog.All().Count);
        }

        [Fact]
        public void India_and_the_Philippines_have_what_a_shop_there_needs()
        {
            var india = PackCatalog.Get("IN");
            Assert.Equal("gst-india", india.Tax.Model);
            Assert.Equal("INR", india.Currency.Code);
            Assert.Equal(new[] { "5", "18", "40" }, india.Tax.Rates.Where(r => !r.Legacy && r.Percent != null && (r.Percent == "5" || r.Percent == "18" || r.Percent == "40")).Select(r => r.Percent).ToArray());
            Assert.Contains(india.Tax.Rates, r => r.Code == "GST12" && r.Legacy);
            Assert.True(india.Tax.Regions.List.Count >= 36);
            Assert.Contains(india.Tax.Regions.List, r => r.Code == "10" && r.Name == "Bihar");
            Assert.Matches(india.Tax.BusinessId.Pattern, "27AAPFU0939F1ZV");
            Assert.DoesNotMatch(india.Tax.BusinessId.Pattern, "27AAPFU0939F1");

            var ph = PackCatalog.Get("PH");
            Assert.Equal("PHP", ph.Currency.Code);
            Assert.Contains(ph.Tax.Rates, r => r.Code == "VAT12" && r.Percent == "12");
            Assert.Contains(ph.Tax.CustomerDiscounts, d => d.Code == "SENIOR" && d.Percent == "20" && d.VatExempt);
            Assert.Contains(ph.Tax.CustomerDiscounts, d => d.Code == "PWD" && d.Percent == "20" && d.VatExempt);
        }

        [Fact]
        public void A_country_with_no_pack_is_refused_with_the_way_to_add_one()
        {
            Assert.Null(PackCatalog.Find("ZZ"));
            Assert.Null(PackCatalog.Find(null));
            var ex = Assert.Throws<ArgumentException>(() => PackCatalog.Get("ZZ"));
            Assert.Contains("country-packs/tools/cli.mjs new ZZ", ex.Message);
            Assert.Equal("IN", PackCatalog.Find(" in ").Country);
        }

        [Fact]
        public void Every_starter_pack_says_it_is_not_yet_checked_by_a_local_adviser()
        {
            foreach (var pack in PackCatalog.All().Where(p => !p.IsReviewed)) Assert.Matches(@"^\d{4}-\d{2}-\d{2}$", pack.AsOf);
            Assert.All(PackCatalog.All(), p => Assert.True(p.IsReviewed || p.Review == null));
        }

        [Fact]
        public void A_bad_amount_or_code_is_refused_with_a_plain_message()
        {
            var india = PackCatalog.Get("IN");
            var context = new TaxContext { PricesIncludeTax = true, SellerRegion = "27" };
            Assert.Throws<ArgumentException>(() => TaxEngine.Calculate(india, context, new[] { new TaxLineInput { Qty = "1", UnitPrice = "10.00", TaxCode = "NOPE" } }));
            Assert.Throws<FormatException>(() => TaxEngine.Calculate(india, context, new[] { new TaxLineInput { Qty = "1", UnitPrice = "10.005", TaxCode = "GST5" } }));
            Assert.Throws<FormatException>(() => TaxEngine.Calculate(india, context, new[] { new TaxLineInput { Qty = "x", UnitPrice = "10", TaxCode = "GST5" } }));
            Assert.Throws<ArgumentException>(() => TaxEngine.Calculate(india, context, new[] { new TaxLineInput { Qty = "1", UnitPrice = "10", TaxCode = "GST5", CustomerDiscount = "SENIOR" } }));
            Assert.Throws<ArgumentException>(() => TaxEngine.Calculate(india, context, new[] { new TaxLineInput { Qty = "1", UnitPrice = "10", TaxCode = "GST5" } }, new[] { new TaxAdjustmentInput { Kind = "bribe", Amount = "1" } }));
        }

        [Fact]
        public void An_empty_bill_is_all_zero()
        {
            var result = TaxEngine.Calculate(PackCatalog.Get("IN"), new TaxContext { PricesIncludeTax = true, SellerRegion = "27" }, new TaxLineInput[0]);
            Assert.Equal("0.00", result.Totals.GrandTotal);
            Assert.Equal("0.00", result.Totals.Payable);
            Assert.Equal(new[] { "CGST", "SGST" }, result.Totals.Components.Select(c => c.Name).ToArray());
        }

        [Fact]
        public void The_packs_that_ship_pass_the_same_checks_as_the_command_line_tool()
        {
            // The pack tool (node country-packs/tools/cli.mjs check) is the full validator; this keeps the C# side honest about the same basics.
            foreach (var pack in PackCatalog.All())
            {
                Assert.True(pack.Currency.Decimals >= 0 && pack.Currency.Decimals <= 3, pack.Country);
                Assert.NotEqual(pack.Currency.DecimalSeparator, pack.Currency.GroupSeparator);
                foreach (var rate in pack.Tax.Rates) Assert.Matches("^[A-Za-z0-9]{1,12}$", rate.Code);
                if (pack.Tax.BusinessId != null && !string.IsNullOrEmpty(pack.Tax.BusinessId.Pattern)) new Regex(pack.Tax.BusinessId.Pattern);
            }
        }
    }
}
