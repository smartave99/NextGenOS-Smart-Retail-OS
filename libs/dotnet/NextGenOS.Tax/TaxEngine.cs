using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace NextGenOS.Tax
{
    /// <summary>
    /// Turns bill lines into money for any country (country-packs/SPEC.md). All arithmetic is on whole numbers (minor units, milli-percents), so
    /// the answer is exact and the same as the TypeScript engine's: the vectors in country-packs/vectors prove it.
    /// </summary>
    public static class TaxEngine
    {
        private static readonly BigInteger Hundred = 100000; // a percent is worked in thousandths: 100 % = 100000

        /// <summary>Round half up: floor((2a + b) / 2b) for a >= 0, b > 0.</summary>
        private static BigInteger R(BigInteger a, BigInteger b) { return (2 * a + b) / (2 * b); }

        private static BigInteger Milli(string percent) { return MoneyText.Parse(percent, 3); }

        public static TaxResult Calculate(CountryPack pack, TaxContext context, IList<TaxLineInput> lines, IList<TaxAdjustmentInput> adjustments = null)
        {
            if (pack == null) throw new ArgumentNullException("pack");
            if (context == null) throw new ArgumentNullException("context");
            if (lines == null) throw new ArgumentNullException("lines");
            adjustments = adjustments ?? new List<TaxAdjustmentInput>();

            var d = pack.Currency.Decimals;
            var model = pack.Tax.Model;
            var registered = context.Registered;
            var inclusive = context.PricesIncludeTax;
            var rounding = pack.Tax.Rounding ?? new RoundingRule { Total = "none" };
            var roundTotal = context.RoundTotal ?? rounding.DefaultOn;

            var outLines = new List<Work>();
            foreach (var line in lines)
            {
                var rate = RateOf(pack, line.TaxCode);
                var q = MoneyText.Parse(line.Qty, 3);
                var p = MoneyText.Parse(line.UnitPrice, d);
                var gross = R(q * p, 1000);
                BigInteger discount = 0;
                if (line.DiscountAmount != null) discount = MoneyText.Parse(line.DiscountAmount, d);
                else if (line.DiscountPercent != null) discount = R(gross * Milli(line.DiscountPercent), Hundred);
                if (discount > gross) discount = gross;
                var net = gross - discount;

                var taxFree = !registered || rate.Exempt || rate.Zero || model == "none";
                BigInteger r = 0;
                List<Comp> comps = null;
                if (model == "regional")
                {
                    comps = RegionComponents(pack, context.BuyerRegion ?? context.SellerRegion);
                    if (!taxFree) r = comps.Aggregate(BigInteger.Zero, (a, c) => a + c.Milli);
                }
                else if (!taxFree)
                {
                    r = Milli(rate.Percent);
                }
                var cess = taxFree || line.CessPercent == null ? BigInteger.Zero : Milli(line.CessPercent);

                var work = new Work { Code = line.TaxCode, Percent = FormatPercent(r), Gross = gross, Discount = discount };
                var names = ComponentNames(pack, model, context, rate, comps);

                CustomerDiscount cd = null;
                if (!string.IsNullOrEmpty(line.CustomerDiscount))
                {
                    cd = (pack.Tax.CustomerDiscounts ?? new List<CustomerDiscount>()).FirstOrDefault(x => x.Code == line.CustomerDiscount);
                    if (cd == null) throw new ArgumentException("Unknown customer discount " + line.CustomerDiscount);
                }

                if (cd != null)
                {
                    var baseValue = inclusive ? R(net * Hundred, Hundred + r) : net;
                    var cdAmount = R(baseValue * Milli(cd.Percent), Hundred);
                    work.CustomerDiscount = cdAmount;
                    if (cd.VatExempt)
                    {
                        work.Taxable = 0;
                        work.Parts = names.Select(n => new Part { Name = n, Amount = 0 }).ToList();
                        work.ExemptAmount = baseValue;
                        work.LineTotal = baseValue - cdAmount;
                    }
                    else
                    {
                        var t = baseValue - cdAmount;
                        var rest = TaxLine(model, names, t, r, cess, false, comps);
                        work.Taxable = t;
                        work.Parts = rest.Parts;
                        work.Cess = rest.Cess;
                        work.LineTotal = t + Sum(rest.Parts) + rest.Cess;
                    }
                }
                else
                {
                    var rest = TaxLine(model, names, net, r, cess, inclusive, comps);
                    work.Taxable = rest.Taxable;
                    work.Parts = rest.Parts;
                    work.Cess = rest.Cess;
                    work.ExemptAmount = rate.Exempt ? rest.Taxable : 0;
                    work.LineTotal = rest.Taxable + Sum(rest.Parts) + rest.Cess;
                }
                outLines.Add(work);
            }

            var totalNames = outLines.Count > 0 ? outLines[0].Parts.Select(x => x.Name).ToList() : ComponentNames(pack, model, context, new TaxRate(), null);
            var totals = new Sums();
            var byCode = new List<Bucket>();
            foreach (var l in outLines)
            {
                totals.Gross += l.Gross; totals.Discount += l.Discount; totals.Taxable += l.Taxable; totals.Cess += l.Cess;
                totals.CustomerDiscount += l.CustomerDiscount; totals.ExemptSales += l.ExemptAmount; totals.SubTotal += l.LineTotal;
                Add(totals.Parts, l.Parts);
                var b = Bucket.Find(byCode, l.Code, l.Percent);
                b.Taxable += l.Taxable; b.Cess += l.Cess;
                Add(b.Parts, l.Parts);
            }

            // Adjustments (section 9), worked from the lines only.
            var lineTaxable = totals.Taxable;
            var lineSub = totals.SubTotal;
            var adjOut = new List<AdjWork>();
            BigInteger tips = 0, advances = 0, retention = 0;
            foreach (var adj in adjustments)
            {
                var baseValue = (adj.Base ?? "taxable") == "subTotal" ? lineSub : lineTaxable;
                BigInteger? pct = adj.Percent != null ? (BigInteger?)Milli(adj.Percent) : null;
                if (adj.Kind == "surcharge" || adj.Kind == "fee")
                {
                    var amount = pct.HasValue ? R(baseValue * pct.Value, Hundred) : MoneyText.Parse(adj.Amount, d);
                    var parts = new List<Part>();
                    BigInteger taxable = 0;
                    if (!string.IsNullOrEmpty(adj.TaxCode))
                    {
                        var rate = RateOf(pack, adj.TaxCode);
                        var taxFree = !registered || rate.Exempt || rate.Zero || model == "none";
                        BigInteger r = 0;
                        List<Comp> comps = null;
                        if (model == "regional")
                        {
                            comps = RegionComponents(pack, context.BuyerRegion ?? context.SellerRegion);
                            if (!taxFree) r = comps.Aggregate(BigInteger.Zero, (a, c) => a + c.Milli);
                        }
                        else if (!taxFree)
                        {
                            r = Milli(rate.Percent);
                        }
                        var rest = TaxLine(model, ComponentNames(pack, model, context, rate, comps), amount, r, 0, false, comps);
                        taxable = rest.Taxable;
                        parts = rest.Parts;
                        totals.Taxable += taxable;
                        Add(totals.Parts, parts);
                        var b = Bucket.Find(byCode, adj.TaxCode, FormatPercent(r));
                        b.Taxable += taxable;
                        Add(b.Parts, parts);
                    }
                    totals.SubTotal += amount + Sum(parts);
                    adjOut.Add(new AdjWork { Code = adj.Code, Kind = adj.Kind, Label = adj.Label ?? string.Empty, Amount = amount, Taxable = taxable, Parts = parts });
                }
                else if (adj.Kind == "tip")
                {
                    var amount = MoneyText.Parse(adj.Amount, d);
                    tips += amount;
                    adjOut.Add(new AdjWork { Code = adj.Code, Kind = adj.Kind, Label = adj.Label ?? string.Empty, Amount = amount, Parts = new List<Part>() });
                }
                else if (adj.Kind == "advance")
                {
                    var amount = MoneyText.Parse(adj.Amount, d);
                    advances += amount;
                    adjOut.Add(new AdjWork { Code = adj.Code, Kind = adj.Kind, Label = adj.Label ?? string.Empty, Amount = amount, Parts = new List<Part>() });
                }
                else if (adj.Kind == "retention")
                {
                    var amount = pct.HasValue ? R(baseValue * pct.Value, Hundred) : MoneyText.Parse(adj.Amount, d);
                    retention += amount;
                    adjOut.Add(new AdjWork { Code = adj.Code, Kind = adj.Kind, Label = adj.Label ?? string.Empty, Amount = amount, Parts = new List<Part>() });
                }
                else
                {
                    throw new ArgumentException("Unknown adjustment kind " + adj.Kind);
                }
            }

            var grand = totals.SubTotal;
            if (roundTotal && rounding.Total == "nearest")
            {
                var inc = MoneyText.Parse(rounding.Increment, d);
                grand = R(totals.SubTotal, inc) * inc;
            }
            var payable = grand + tips - advances - retention;
            BigInteger credit = 0;
            if (payable.Sign < 0) { credit = -payable; payable = 0; }

            Func<BigInteger, string> f = n => MoneyText.Minor(n, d);
            Func<IEnumerable<Part>, List<Component>> comp = ps => ps.Select(x => new Component { Name = x.Name, Amount = f(x.Amount) }).ToList();
            return new TaxResult
            {
                Lines = outLines.Select(l => new LineResult
                {
                    Gross = f(l.Gross), Discount = f(l.Discount), Taxable = f(l.Taxable), Components = comp(l.Parts), Cess = f(l.Cess),
                    CustomerDiscount = f(l.CustomerDiscount), ExemptAmount = f(l.ExemptAmount), LineTotal = f(l.LineTotal),
                }).ToList(),
                Adjustments = adjOut.Select(a => new AdjustmentResult { Code = a.Code, Kind = a.Kind, Label = a.Label, Amount = f(a.Amount), Taxable = f(a.Taxable), Components = comp(a.Parts) }).ToList(),
                Totals = new TotalsResult
                {
                    Gross = f(totals.Gross), Discount = f(totals.Discount), Taxable = f(totals.Taxable),
                    Components = totalNames.Select(n => new Component { Name = n, Amount = f(totals.Parts.ContainsKey(n) ? totals.Parts[n] : 0) }).ToList(),
                    Cess = f(totals.Cess), CustomerDiscount = f(totals.CustomerDiscount), ExemptSales = f(totals.ExemptSales),
                    SubTotal = f(totals.SubTotal), RoundOff = f(grand - totals.SubTotal), GrandTotal = f(grand),
                    Tips = f(tips), Advances = f(advances), Retention = f(retention), Payable = f(payable), Credit = f(credit),
                },
                ByCode = byCode.Select(b => new ByCodeResult { Code = b.Code, Percent = b.Percent, Taxable = f(b.Taxable), Components = b.Parts.Select(x => new Component { Name = x.Key, Amount = f(x.Value) }).ToList(), Cess = f(b.Cess) }).ToList(),
            };
        }

        // ---- steps 5 to 7 of the specification ----------------------------------------------------------------------------------

        private static Rest TaxLine(string model, List<string> names, BigInteger value, BigInteger r, BigInteger c, bool inclusive, List<Comp> comps)
        {
            BigInteger taxable, tax, cess;
            if (inclusive)
            {
                taxable = R(value * Hundred, Hundred + r + c);
                var taxTotal = value - taxable;
                cess = R(taxable * c, Hundred);
                tax = taxTotal - cess;
            }
            else
            {
                taxable = value;
                cess = R(taxable * c, Hundred);
                tax = 0;
            }

            var parts = new List<Part>();
            if (model == "none" || names.Count == 0)
            {
                // no tax
            }
            else if (model == "gst-india")
            {
                if (names.Count == 2)
                {
                    var cgst = inclusive ? R(tax, 2) : R(taxable * r, 200000);
                    var sgst = inclusive ? tax - cgst : cgst;
                    parts.Add(new Part { Name = "CGST", Amount = cgst });
                    parts.Add(new Part { Name = "SGST", Amount = sgst });
                }
                else
                {
                    parts.Add(new Part { Name = "IGST", Amount = inclusive ? tax : R(taxable * r, Hundred) });
                }
            }
            else if (model == "regional")
            {
                var total = inclusive ? tax : R(taxable * r, Hundred);
                BigInteger used = 0;
                for (var i = 0; i < comps.Count; i++)
                {
                    BigInteger amount;
                    if (i == comps.Count - 1) amount = total - used;
                    else if (r.IsZero) amount = 0;
                    else amount = inclusive ? R(total * comps[i].Milli, r) : R(taxable * comps[i].Milli, Hundred);
                    used += amount;
                    parts.Add(new Part { Name = comps[i].Name, Amount = amount });
                }
            }
            else
            {
                parts.Add(new Part { Name = names[0], Amount = inclusive ? tax : R(taxable * r, Hundred) });
            }
            return new Rest { Taxable = taxable, Parts = parts, Cess = cess };
        }

        private static List<string> ComponentNames(CountryPack pack, string model, TaxContext context, TaxRate rate, List<Comp> comps)
        {
            if (model == "gst-india")
            {
                var inter = !string.IsNullOrEmpty(context.BuyerRegion) && !string.IsNullOrEmpty(context.SellerRegion) && context.BuyerRegion != context.SellerRegion;
                return inter ? new List<string> { "IGST" } : new List<string> { "CGST", "SGST" };
            }
            if (model == "regional") return (comps ?? RegionComponents(pack, context.BuyerRegion ?? context.SellerRegion)).Select(x => x.Name).ToList();
            if (model == "none") return new List<string>();
            return new List<string> { string.IsNullOrEmpty(rate.Component) ? pack.Tax.Name : rate.Component };
        }

        private static TaxRate RateOf(CountryPack pack, string code)
        {
            var rate = pack.Tax.Rates.FirstOrDefault(x => x.Code == code);
            if (rate == null) throw new ArgumentException("Unknown tax code " + code);
            return rate;
        }

        private static List<Comp> RegionComponents(CountryPack pack, string region)
        {
            var found = pack.Tax.Regions == null || pack.Tax.Regions.List == null ? null : pack.Tax.Regions.List.FirstOrDefault(x => x.Code == region);
            if (found == null || found.Components == null) throw new ArgumentException("No tax components for region " + region);
            return found.Components.Select(c => new Comp { Name = c.Name, Milli = Milli(c.Percent) }).ToList();
        }

        private static string FormatPercent(BigInteger milli)
        {
            var whole = milli / 1000;
            var frac = (milli % 1000).ToString().PadLeft(3, '0').TrimEnd('0');
            return frac.Length > 0 ? whole + "." + frac : whole.ToString();
        }

        private static BigInteger Sum(IEnumerable<Part> parts) { return parts.Aggregate(BigInteger.Zero, (a, p) => a + p.Amount); }

        private static void Add(Dictionary<string, BigInteger> into, IEnumerable<Part> parts)
        {
            foreach (var p in parts) into[p.Name] = (into.ContainsKey(p.Name) ? into[p.Name] : BigInteger.Zero) + p.Amount;
        }

        private static void Add(List<KeyValuePair<string, BigInteger>> into, IEnumerable<Part> parts)
        {
            foreach (var p in parts)
            {
                var i = into.FindIndex(x => x.Key == p.Name);
                if (i < 0) into.Add(new KeyValuePair<string, BigInteger>(p.Name, p.Amount));
                else into[i] = new KeyValuePair<string, BigInteger>(p.Name, into[i].Value + p.Amount);
            }
        }

        private sealed class Part { public string Name; public BigInteger Amount; }
        private sealed class Comp { public string Name; public BigInteger Milli; }
        private sealed class Rest { public BigInteger Taxable; public List<Part> Parts; public BigInteger Cess; }

        private sealed class Work
        {
            public string Code, Percent;
            public BigInteger Gross, Discount, Taxable, Cess, CustomerDiscount, ExemptAmount, LineTotal;
            public List<Part> Parts = new List<Part>();
        }

        private sealed class AdjWork
        {
            public string Code, Kind, Label;
            public BigInteger Amount, Taxable;
            public List<Part> Parts;
        }

        private sealed class Sums
        {
            public BigInteger Gross, Discount, Taxable, Cess, CustomerDiscount, ExemptSales, SubTotal;
            public Dictionary<string, BigInteger> Parts = new Dictionary<string, BigInteger>();
        }

        private sealed class Bucket
        {
            public string Code, Percent;
            public BigInteger Taxable, Cess;
            public List<KeyValuePair<string, BigInteger>> Parts = new List<KeyValuePair<string, BigInteger>>();

            public static Bucket Find(List<Bucket> all, string code, string percent)
            {
                var b = all.FirstOrDefault(x => x.Code == code);
                if (b == null) { b = new Bucket { Code = code, Percent = percent }; all.Add(b); }
                return b;
            }
        }
    }
}
