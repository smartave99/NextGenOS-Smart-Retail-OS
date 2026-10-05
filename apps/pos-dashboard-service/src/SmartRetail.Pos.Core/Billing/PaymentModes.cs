namespace SmartRetail.Pos.Core.Billing;

/// <summary>How a bill is paid.</summary>
public static class PaymentModes
{
    public const string Cash = "Cash";
    public const string Upi = "UPI";
    public const string Card = "Card";
    public const string Cheque = "Cheque";

    /// <summary>Nothing paid now; the full amount goes on the customer's account.</summary>
    public const string Credit = "Credit";

    public static IReadOnlyList<string> All { get; } = new[] { Cash, Upi, Card, Cheque, Credit };
}
