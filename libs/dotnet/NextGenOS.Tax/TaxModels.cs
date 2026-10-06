using System.Collections.Generic;
using Newtonsoft.Json;

namespace NextGenOS.Tax
{
    /// <summary>What is true of the whole sale (country-packs/SPEC.md section 5).</summary>
    public sealed class TaxContext
    {
        [JsonProperty("pricesIncludeTax")] public bool PricesIncludeTax { get; set; }
        [JsonProperty("sellerRegion")] public string SellerRegion { get; set; }
        [JsonProperty("buyerRegion")] public string BuyerRegion { get; set; }
        /// <summary>False for a seller who is not registered for the tax: no tax is charged.</summary>
        [JsonProperty("registered")] public bool Registered { get; set; } = true;
        /// <summary>Round the total as the pack says (cash rounding). Null: the pack's default.</summary>
        [JsonProperty("roundTotal")] public bool? RoundTotal { get; set; }
    }

    public sealed class TaxLineInput
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("qty")] public string Qty { get; set; }
        [JsonProperty("unitPrice")] public string UnitPrice { get; set; }
        [JsonProperty("taxCode")] public string TaxCode { get; set; }
        [JsonProperty("discountPercent")] public string DiscountPercent { get; set; }
        [JsonProperty("discountAmount")] public string DiscountAmount { get; set; }
        [JsonProperty("cessPercent")] public string CessPercent { get; set; }
        [JsonProperty("customerDiscount")] public string CustomerDiscount { get; set; }
    }

    /// <summary>A whole-document amount: service charge, fee, tip, retention or advance (SPEC section 9).</summary>
    public sealed class TaxAdjustmentInput
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("kind")] public string Kind { get; set; }
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("percent")] public string Percent { get; set; }
        [JsonProperty("amount")] public string Amount { get; set; }
        [JsonProperty("base")] public string Base { get; set; }
        [JsonProperty("taxCode")] public string TaxCode { get; set; }
    }

    public sealed class Component
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("amount")] public string Amount { get; set; }
    }

    public sealed class LineResult
    {
        [JsonProperty("gross")] public string Gross { get; set; }
        [JsonProperty("discount")] public string Discount { get; set; }
        [JsonProperty("taxable")] public string Taxable { get; set; }
        [JsonProperty("components")] public List<Component> Components { get; set; }
        [JsonProperty("cess")] public string Cess { get; set; }
        [JsonProperty("customerDiscount")] public string CustomerDiscount { get; set; }
        [JsonProperty("exemptAmount")] public string ExemptAmount { get; set; }
        [JsonProperty("lineTotal")] public string LineTotal { get; set; }
    }

    public sealed class AdjustmentResult
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("kind")] public string Kind { get; set; }
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("amount")] public string Amount { get; set; }
        [JsonProperty("taxable")] public string Taxable { get; set; }
        [JsonProperty("components")] public List<Component> Components { get; set; }
    }

    public sealed class TotalsResult
    {
        [JsonProperty("gross")] public string Gross { get; set; }
        [JsonProperty("discount")] public string Discount { get; set; }
        [JsonProperty("taxable")] public string Taxable { get; set; }
        [JsonProperty("components")] public List<Component> Components { get; set; }
        [JsonProperty("cess")] public string Cess { get; set; }
        [JsonProperty("customerDiscount")] public string CustomerDiscount { get; set; }
        [JsonProperty("exemptSales")] public string ExemptSales { get; set; }
        [JsonProperty("subTotal")] public string SubTotal { get; set; }
        [JsonProperty("roundOff")] public string RoundOff { get; set; }
        [JsonProperty("grandTotal")] public string GrandTotal { get; set; }
        [JsonProperty("tips")] public string Tips { get; set; }
        [JsonProperty("advances")] public string Advances { get; set; }
        [JsonProperty("retention")] public string Retention { get; set; }
        [JsonProperty("payable")] public string Payable { get; set; }
        [JsonProperty("credit")] public string Credit { get; set; }
    }

    public sealed class ByCodeResult
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("percent")] public string Percent { get; set; }
        [JsonProperty("taxable")] public string Taxable { get; set; }
        [JsonProperty("components")] public List<Component> Components { get; set; }
        [JsonProperty("cess")] public string Cess { get; set; }
    }

    /// <summary>The answer. Every amount is a string in major units with exactly the currency's number of decimals ("1234.50").</summary>
    public sealed class TaxResult
    {
        [JsonProperty("lines")] public List<LineResult> Lines { get; set; }
        [JsonProperty("adjustments")] public List<AdjustmentResult> Adjustments { get; set; }
        [JsonProperty("totals")] public TotalsResult Totals { get; set; }
        [JsonProperty("byCode")] public List<ByCodeResult> ByCode { get; set; }
    }
}
