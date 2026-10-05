namespace SmartRetail.Pos.Core.Billing;

/// <summary>Turns bill lines into money. Pure functions, so every rule here is unit-tested.</summary>
public static class BillCalculator
{
    public static LineCharge Line(BillLine line, BillOptions options)
    {
        ArgumentNullException.ThrowIfNull(line);
        ArgumentNullException.ThrowIfNull(options);

        var discountPercent = Math.Clamp(line.DiscountPercent, 0m, 100m);
        var gstPercent = Math.Clamp(line.GstRatePercent, 0m, 100m);

        var gross = Money.Round(line.Qty * line.Rate);
        var discount = Money.Round(gross * discountPercent / 100m);
        var net = gross - discount;

        decimal taxable, cgst = 0m, sgst = 0m, igst = 0m;

        if (options.PricesIncludeTax)
        {
            // The customer pays the shelf price; work the tax out of it so the line total never moves.
            taxable = Money.Round(net / (1m + gstPercent / 100m));
            var tax = net - taxable;
            if (options.GstMode == GstMode.Interstate)
            {
                igst = tax;
            }
            else
            {
                cgst = Money.Round(tax / 2m);
                sgst = tax - cgst;
            }
        }
        else
        {
            // Tax is added on top; CGST and SGST are each charged at half the rate.
            taxable = net;
            if (options.GstMode == GstMode.Interstate)
            {
                igst = Money.Round(taxable * gstPercent / 100m);
            }
            else
            {
                cgst = Money.Round(taxable * gstPercent / 200m);
                sgst = cgst;
            }
        }

        return new LineCharge
        {
            Gross = gross,
            Discount = discount,
            Taxable = taxable,
            Cgst = cgst,
            Sgst = sgst,
            Igst = igst,
            LineTotal = taxable + cgst + sgst + igst,
        };
    }

    public static BillTotals Totals(IEnumerable<BillLine> lines, BillOptions options)
    {
        ArgumentNullException.ThrowIfNull(lines);
        ArgumentNullException.ThrowIfNull(options);

        var count = 0;
        decimal qty = 0m, discount = 0m, taxable = 0m, cgst = 0m, sgst = 0m, igst = 0m, subTotal = 0m;

        foreach (var line in lines)
        {
            var charge = Line(line, options);
            count++;
            qty += line.Qty;
            discount += charge.Discount;
            taxable += charge.Taxable;
            cgst += charge.Cgst;
            sgst += charge.Sgst;
            igst += charge.Igst;
            subTotal += charge.LineTotal;
        }

        var grandTotal = options.RoundToNearestRupee ? Money.RoundToRupee(subTotal) : subTotal;

        return new BillTotals
        {
            ItemCount = count,
            TotalQty = qty,
            Discount = discount,
            Taxable = taxable,
            Cgst = cgst,
            Sgst = sgst,
            Igst = igst,
            SubTotal = subTotal,
            RoundOff = grandTotal - subTotal,
            GrandTotal = grandTotal,
        };
    }
}
