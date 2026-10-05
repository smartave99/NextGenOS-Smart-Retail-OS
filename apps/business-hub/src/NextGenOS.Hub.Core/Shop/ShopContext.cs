using System.Text.Json;
using Newtonsoft.Json;
using NextGenOS.Hub.Data;
using NextGenOS.Tax;

namespace NextGenOS.Hub.Shop;

/// <summary>
/// Everything the programs need to know about this shop at once: its settings, its country pack (with the shop's own rate changes), its industry
/// pack (with the owner's switches and renamed words), its clock and how to write money. Built from the settings; rebuilt when they change.
/// </summary>
public sealed class ShopContext
{
    public ShopContext(ShopSettings settings)
    {
        Settings = settings;
        Country = ApplyOverrides(PackCatalog.Get(settings.Country), settings);
        Industry = IndustryCatalog.Get(settings.Industry);
        Features = Industry.Features.Clone();
        foreach (var (name, on) in settings.FeatureOverrides) SetFeature(Features, name, on);
        Time = new ShopTime(Country.Timezone);
        PaymentMethods = settings.PaymentMethods.Count > 0 ? settings.PaymentMethods : Industry.Defaults.PaymentMethods;
    }

    public ShopSettings Settings { get; }
    public CountryPack Country { get; }
    public IndustryPack Industry { get; }
    public Features Features { get; }
    public ShopTime Time { get; }
    public IReadOnlyList<string> PaymentMethods { get; }

    public int Decimals => Country.Currency.Decimals;
    public string CurrencyCode => Country.Currency.Code;

    // ---- words ---------------------------------------------------------------------------------------------------------------

    public string Singular(string term) => Settings.VocabularyOverrides.TryGetValue(term, out var pair) && pair.Length == 2 ? pair[0] : Industry.Singular(term);

    public string Plural(string term) => Settings.VocabularyOverrides.TryGetValue(term, out var pair) && pair.Length == 2 ? pair[1] : Industry.Plural(term);

    // ---- money -----------------------------------------------------------------------------------------------------------------

    /// <summary>Minor units as exact text with the currency's decimals: 19950 is "199.50".</summary>
    public string Text(long minor) => MoneyText.Minor(minor, Decimals);

    /// <summary>Minor units as a person reads it in this country: ₹1,99,950.00.</summary>
    public string Money(long minor) => MoneyText.Format(Text(minor), Country.Currency);

    /// <summary>"199.5" → 19950 (refuses more decimals than the currency has).</summary>
    public long Minor(string text) => (long)MoneyText.Parse(text, Decimals);

    public static string Qty(long milli) => MoneyText.Minor(milli, 3);

    public static long QtyMilli(string text) => (long)MoneyText.Parse(text, 3);

    // ---- tax -------------------------------------------------------------------------------------------------------------------

    /// <summary>"standard", "reduced", "zero", "exempt" or a rate code: the rate code it means in this country.</summary>
    public string TaxCode(string classOrCode)
    {
        if (Country.Tax.Rates.Any(r => r.Code == classOrCode)) return classOrCode;
        if (Country.Tax.Classes != null && Country.Tax.Classes.TryGetValue(classOrCode, out var code)) return code;
        if (classOrCode == "reduced" && Country.Tax.Classes != null && Country.Tax.Classes.TryGetValue("standard", out var standard)) return standard;
        throw new ArgumentException($"\"{classOrCode}\" is not a tax class or a rate code of {Country.Name}.");
    }

    public TaxRate Rate(string code) => Country.Tax.Rates.FirstOrDefault(r => r.Code == code) ?? throw new ArgumentException($"Unknown tax code {code}.");

    // ---- rules of the trade -----------------------------------------------------------------------------------------------------

    /// <summary>A number from the industry's rules, unless the owner set their own.</summary>
    public decimal Rule(string name, decimal fallback = 0m)
    {
        if (Settings.RuleOverrides.TryGetValue(name, out var text) && decimal.TryParse(text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out var d)) return d;
        return Industry.RuleNumber(name, fallback);
    }

    /// <summary>A money rule (a fine per day) as minor units.</summary>
    public long RuleMinor(string name)
    {
        if (Settings.RuleOverrides.TryGetValue(name, out var text)) return Minor(text);
        return Minor(Industry.RuleText(name, "0"));
    }

    /// <summary>The adjustments an industry applies to every bill by default (service charge ...), after the owner's changes.</summary>
    public IReadOnlyList<DefaultAdjustment> DefaultAdjustments()
    {
        var list = new List<DefaultAdjustment>();
        foreach (var a in Industry.Defaults.Adjustments)
        {
            var percent = a.Percent;
            if (Settings.AdjustmentOverrides.TryGetValue(a.Code, out var o))
            {
                if (o == "") continue; // switched off for good
                percent = o;
            }
            list.Add(new DefaultAdjustment { Code = a.Code, Kind = a.Kind, Label = a.Label, Percent = percent, Base = a.Base, Taxed = a.Taxed, Optional = a.Optional });
        }
        return list;
    }

    /// <summary>An adjustment as the tax engine takes it: a taxed one is given the country's standard rate.</summary>
    public TaxAdjustmentInput ToInput(DefaultAdjustment a) => new()
    {
        Code = a.Code, Kind = a.Kind, Label = a.Label, Percent = a.Percent, Base = a.Base,
        TaxCode = a.Taxed ? TaxCode("standard") : null,
    };

    /// <summary>The first day of the fiscal year a local date belongs to: "2026" for 5 October 2026 in India (the year starts on 1 April).</summary>
    public string YearKey(DateOnly localDate)
    {
        var start = Country.FiscalYearStart;
        var begins = new DateOnly(localDate.Year, start.Month, Math.Min(start.Day, DateTime.DaysInMonth(localDate.Year, start.Month)));
        return (localDate >= begins ? localDate.Year : localDate.Year - 1).ToString(System.Globalization.CultureInfo.InvariantCulture);
    }

    // ---- internals -------------------------------------------------------------------------------------------------------------

    private static void SetFeature(Features f, string name, bool on)
    {
        switch (name)
        {
            case "counterSale": f.CounterSale = on; break;
            case "tables": f.Tables = on; break;
            case "kitchen": f.Kitchen = on; break;
            case "lending": f.Lending = on; break;
            case "projects": f.Projects = on; break;
            case "appointments": f.Appointments = on; break;
            case "credit": f.Credit = on; break;
            case "purchases": f.Purchases = on; break;
            case "weighedItems": f.WeighedItems = on; break;
        }
    }

    private static CountryPack ApplyOverrides(CountryPack original, ShopSettings settings)
    {
        if (settings.RateOverrides.Count == 0 && settings.ComponentOverrides.Count == 0) return original;
        var copy = JsonConvert.DeserializeObject<CountryPack>(JsonConvert.SerializeObject(original))!;
        foreach (var (code, percent) in settings.RateOverrides)
        {
            var rate = copy.Tax.Rates.FirstOrDefault(r => r.Code == code);
            if (rate != null && rate.Percent != null) rate.Percent = percent;
        }
        foreach (var (key, percent) in settings.ComponentOverrides)
        {
            var parts = key.Split('/', 2);
            if (parts.Length != 2) continue;
            var region = copy.Tax.Regions?.List?.FirstOrDefault(r => r.Code == parts[0]);
            var comp = region?.Components?.FirstOrDefault(c => c.Name == parts[1]);
            if (comp != null) comp.Percent = percent;
        }
        return copy;
    }
}

/// <summary>Hands out the current <see cref="ShopContext"/> and builds a new one when the settings change.</summary>
public sealed class ShopContextProvider(SettingsStore store)
{
    private readonly object _gate = new();
    private ShopContext? _current;

    public ShopContext Current
    {
        get
        {
            lock (_gate) return _current ??= new ShopContext(store.Load());
        }
    }

    public ShopSettings Settings => store.Load();

    public void Save(ShopSettings settings)
    {
        store.Save(settings);
        lock (_gate) _current = null;
    }

    public void Invalidate()
    {
        lock (_gate) _current = null;
    }
}
