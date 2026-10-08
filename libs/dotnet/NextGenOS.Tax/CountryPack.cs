using System.Collections.Generic;
using Newtonsoft.Json;

namespace NextGenOS.Tax
{
    /// <summary>A country pack (country-packs/SPEC.md section 3): money, language, tax rules and invoice requirements as data.</summary>
    public sealed class CountryPack
    {
        [JsonProperty("schema")] public int Schema { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("asOf")] public string AsOf { get; set; }
        [JsonProperty("review")] public PackReview Review { get; set; }
        [JsonProperty("currency")] public CurrencyInfo Currency { get; set; }
        [JsonProperty("locale")] public string Locale { get; set; }
        [JsonProperty("languages")] public List<string> Languages { get; set; }
        [JsonProperty("timezone")] public string Timezone { get; set; }
        [JsonProperty("phoneCode")] public string PhoneCode { get; set; }
        [JsonProperty("fiscalYearStart")] public FiscalYearStart FiscalYearStart { get; set; }
        [JsonProperty("tax")] public TaxRules Tax { get; set; }
        [JsonProperty("invoice")] public InvoiceRules Invoice { get; set; }
        [JsonProperty("notes")] public List<string> Notes { get; set; }

        /// <summary>True when a local adviser has recorded that they checked the rules.</summary>
        [JsonIgnore] public bool IsReviewed { get { return Review != null; } }
    }

    public sealed class PackReview
    {
        [JsonProperty("by")] public string By { get; set; }
        [JsonProperty("on")] public string On { get; set; }
        [JsonProperty("notes")] public string Notes { get; set; }
    }

    public sealed class CurrencyInfo
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("symbol")] public string Symbol { get; set; }
        [JsonProperty("decimals")] public int Decimals { get; set; }
        [JsonProperty("symbolPosition")] public string SymbolPosition { get; set; }
        [JsonProperty("symbolSpace")] public bool SymbolSpace { get; set; }
        [JsonProperty("grouping")] public string Grouping { get; set; }
        [JsonProperty("decimalSeparator")] public string DecimalSeparator { get; set; }
        [JsonProperty("groupSeparator")] public string GroupSeparator { get; set; }
    }

    public sealed class FiscalYearStart
    {
        [JsonProperty("month")] public int Month { get; set; }
        [JsonProperty("day")] public int Day { get; set; }
    }

    public sealed class TaxRules
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("model")] public string Model { get; set; }
        [JsonProperty("pricesIncludeTaxDefault")] public bool PricesIncludeTaxDefault { get; set; }
        [JsonProperty("rates")] public List<TaxRate> Rates { get; set; }
        /// <summary>The four everyday classes (standard, reduced, zero, exempt) and the rate code each one means.</summary>
        [JsonProperty("classes")] public Dictionary<string, string> Classes { get; set; }
        [JsonProperty("regions")] public RegionList Regions { get; set; }
        [JsonProperty("businessId")] public BusinessIdRule BusinessId { get; set; }
        /// <summary>The code a line may carry for the goods or service sold, under the country's own name for it. Null: the country has none.</summary>
        [JsonProperty("itemCode")] public NamedTaxField ItemCode { get; set; }
        /// <summary>A further tax some items carry on top of the main one, as a percent set on the item, under the country's own name for it. Null: the country has none.</summary>
        [JsonProperty("extraTax")] public NamedTaxField ExtraTax { get; set; }
        [JsonProperty("customerDiscounts")] public List<CustomerDiscount> CustomerDiscounts { get; set; }
        [JsonProperty("rounding")] public RoundingRule Rounding { get; set; }
    }

    public sealed class TaxRate
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("percent")] public string Percent { get; set; }
        [JsonProperty("exempt")] public bool Exempt { get; set; }
        [JsonProperty("zero")] public bool Zero { get; set; }
        [JsonProperty("taxable")] public bool Taxable { get; set; }
        [JsonProperty("legacy")] public bool Legacy { get; set; }
        [JsonProperty("component")] public string Component { get; set; }
    }

    public sealed class RegionList
    {
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("list")] public List<Region> List { get; set; }
    }

    public sealed class Region
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("components")] public List<RegionComponent> Components { get; set; }
    }

    public sealed class RegionComponent
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("percent")] public string Percent { get; set; }
        [JsonProperty("editable")] public bool Editable { get; set; }
    }

    /// <summary>A field the country's tax asks for on an item or a line: the words for it, and a line of help.</summary>
    public sealed class NamedTaxField
    {
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("help")] public string Help { get; set; }
    }

    public sealed class BusinessIdRule
    {
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("pattern")] public string Pattern { get; set; }
    }

    public sealed class CustomerDiscount
    {
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("percent")] public string Percent { get; set; }
        [JsonProperty("vatExempt")] public bool VatExempt { get; set; }
        [JsonProperty("law")] public string Law { get; set; }
    }

    public sealed class RoundingRule
    {
        [JsonProperty("total")] public string Total { get; set; }
        [JsonProperty("increment")] public string Increment { get; set; }
        [JsonProperty("defaultOn")] public bool DefaultOn { get; set; }
    }

    public sealed class InvoiceRules
    {
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("requiredFields")] public List<string> RequiredFields { get; set; }
        [JsonProperty("eInvoice")] public string EInvoice { get; set; }
        [JsonProperty("retentionYears")] public int RetentionYears { get; set; }
    }
}
