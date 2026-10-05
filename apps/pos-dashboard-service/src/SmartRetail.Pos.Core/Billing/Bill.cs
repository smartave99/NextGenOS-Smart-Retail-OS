using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Core.Billing;

/// <summary>
/// The bill being built at the counter: its lines, customer and options.
/// Screens stay thin; the rules live here so they can be tested.
/// </summary>
public sealed class Bill
{
    private readonly List<BillLine> _lines = new();

    public IReadOnlyList<BillLine> Lines => _lines;
    public BillOptions Options { get; set; } = BillOptions.Default;
    public Customer Customer { get; set; } = Customer.WalkIn;
    public bool IsEmpty => _lines.Count == 0;

    public BillTotals Totals => BillCalculator.Totals(_lines, Options);

    public LineCharge ChargeFor(BillLine line) => BillCalculator.Line(line, Options);

    /// <summary>Adds a product. Adding a product that is already on the bill raises its quantity.</summary>
    public BillLine Add(Product product, decimal qty = 1m)
    {
        ArgumentNullException.ThrowIfNull(product);
        if (qty <= 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(qty), "Quantity must be more than zero.");
        }

        var existing = _lines.FirstOrDefault(l => l.ProductId == product.Id);
        if (existing is not null)
        {
            existing.Qty += qty;
            return existing;
        }

        var line = BillLine.From(product);
        line.Qty = qty;
        _lines.Add(line);
        return line;
    }

    public void Remove(BillLine line) => _lines.Remove(line);

    public void Clear()
    {
        _lines.Clear();
        Customer = Customer.WalkIn;
    }

    /// <summary>Why the bill cannot be saved yet. Empty when it is ready.</summary>
    public IReadOnlyList<string> Problems(decimal amountReceived)
    {
        var problems = new List<string>();
        if (IsEmpty)
        {
            problems.Add("Add at least one item.");
        }

        foreach (var line in _lines)
        {
            if (line.Qty <= 0m)
            {
                problems.Add($"Quantity of {line.Name} must be more than zero.");
            }
            if (line.Rate < 0m)
            {
                problems.Add($"Rate of {line.Name} cannot be negative.");
            }
            if (line.DiscountPercent is < 0m or > 100m)
            {
                problems.Add($"Discount on {line.Name} must be between 0% and 100%.");
            }
        }

        if (amountReceived < 0m)
        {
            problems.Add("Amount received cannot be negative.");
        }
        else if (!IsEmpty && Customer.IsWalkIn && amountReceived < Totals.GrandTotal)
        {
            problems.Add("Choose a customer to save a bill that is not fully paid.");
        }

        return problems;
    }

    /// <summary>Freezes the bill into the record that is saved.</summary>
    public NewInvoice ToInvoice(string paymentMode, decimal amountReceived, DateTime nowLocal)
    {
        var problems = Problems(amountReceived);
        if (problems.Count > 0)
        {
            throw new InvalidOperationException(string.Join(" ", problems));
        }

        var lines = _lines.Select(line =>
        {
            var charge = ChargeFor(line);
            return new NewInvoiceLine
            {
                ProductId = line.ProductId,
                Code = line.Code,
                Name = line.Name,
                HsnCode = line.HsnCode,
                Qty = line.Qty,
                Rate = line.Rate,
                DiscountPercent = line.DiscountPercent,
                GstRatePercent = line.GstRatePercent,
                Discount = charge.Discount,
                Taxable = charge.Taxable,
                Tax = charge.Tax,
                LineTotal = charge.LineTotal,
            };
        }).ToList();

        return new NewInvoice
        {
            CustomerId = Customer.IsWalkIn ? null : Customer.Id,
            CustomerName = Customer.Name,
            Options = Options,
            PaymentMode = paymentMode,
            AmountReceived = amountReceived,
            CreatedAtLocal = nowLocal,
            Lines = lines,
            Totals = Totals,
        };
    }
}
