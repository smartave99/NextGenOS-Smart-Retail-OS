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
        /// <summary>The currency's words, for writing an amount in words on a full tax invoice (SPEC section 4d). Null: the pack gives none and no words are printed.</summary>
        [JsonProperty("words")] public CurrencyWords Words { get; set; }
    }

    /// <summary>The words a country uses for its money when an amount is written out (SPEC section 4d). English words only; other languages come with the screen translations.</summary>
    public sealed class CurrencyWords
    {
        /// <summary>The whole unit, singular and plural: ["rupee", "rupees"].</summary>
        [JsonProperty("major")] public System.Collections.Generic.List<string> Major { get; set; }
        /// <summary>The smallest unit, singular and plural: ["paisa", "paise"]. Needed when the currency has decimals.</summary>
        [JsonProperty("minor")] public System.Collections.Generic.List<string> Minor { get; set; }
        /// <summary>The names of the big steps, smallest first: ["thousand", "lakh", "crore"]. Needed with "indian" grouping; without it the English thousand, million, billion and trillion are used.</summary>
        [JsonProperty("scales")] public System.Collections.Generic.List<string> Scales { get; set; }
        /// <summary>The word between the whole part and the small part. Null: "and".</summary>
        [JsonProperty("join")] public string Join { get; set; }
        /// <summary>The word that closes the amount ("only"). Null or empty: none.</summary>
        [JsonProperty("ending")] public string Ending { get; set; }
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
        /// <summary>The lists this country's tax returns are made from (which bills go in which list). Null: the country has none.</summary>
        [JsonProperty("returns")] public ReturnRules Returns { get; set; }
        /// <summary>The blocks of the summary of supplies a country's periodic return asks for (what was sold and bought, line by line). Null: the country has none.</summary>
        [JsonProperty("summary")] public SummaryRules Summary { get; set; }
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

    /// <summary>The lists a country's tax returns are made from: each bill or credit note goes into the first list whose rule it meets.</summary>
    public sealed class ReturnRules
    {
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("lists")] public List<ReturnList> Lists { get; set; }
    }

    /// <summary>The blocks of a summary of supplies: each line of a bill, credit note or purchase goes in the first block of its side whose rule it meets.</summary>
    public sealed class SummaryRules
    {
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("blocks")] public List<SummaryBlock> Blocks { get; set; }
    }

    public sealed class SummaryBlock
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("label")] public string Label { get; set; }
        /// <summary>"outward" (sales; credit notes are taken off) or "inward" (purchases).</summary>
        [JsonProperty("side")] public string Side { get; set; }
        [JsonProperty("when")] public SummaryWhen When { get; set; }
    }

    /// <summary>What a line must meet to go in a block. Everything named must be true; what is not named does not matter.</summary>
    public sealed class SummaryWhen
    {
        /// <summary>"taxed" (the line has a rate above nothing), "zero" (taxable at nothing) or "exempt" (outside the tax).</summary>
        [JsonProperty("rate")] public string Rate { get; set; }
        [JsonProperty("partyHasTaxId")] public bool? PartyHasTaxId { get; set; }
        [JsonProperty("betweenRegions")] public bool? BetweenRegions { get; set; }
    }

    public sealed class ReturnList
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("label")] public string Label { get; set; }
        /// <summary>"bill" (a sale made out to the buyer) or "credit" (a credit note given to the buyer).</summary>
        [JsonProperty("kind")] public string Kind { get; set; }
        [JsonProperty("when")] public ReturnWhen When { get; set; }
    }

    /// <summary>What a document must meet to go in a list. Everything named must be true; what is not named does not matter.</summary>
    public sealed class ReturnWhen
    {
        /// <summary>True: the buyer has a tax number on the bill. False: the buyer has none.</summary>
        [JsonProperty("partyHasTaxId")] public bool? PartyHasTaxId { get; set; }
        /// <summary>True: the buyer's place is not the seller's (an empty place counts as the seller's). False: it is the same.</summary>
        [JsonProperty("betweenRegions")] public bool? BetweenRegions { get; set; }
        /// <summary>The bill's total is more than this amount (a decimal in the currency, like "100000").</summary>
        [JsonProperty("totalOver")] public string TotalOver { get; set; }
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
