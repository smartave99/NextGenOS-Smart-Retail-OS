using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Core.Billing;

/// <summary>One editable line of the bill being built.</summary>
public sealed class BillLine
{
    public int ProductId { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string? HsnCode { get; set; }
    public decimal Rate { get; set; }
    public decimal Qty { get; set; } = 1m;
    public decimal DiscountPercent { get; set; }
    public decimal GstRatePercent { get; set; }

    public static BillLine From(Product product) => new()
    {
        ProductId = product.Id,
        Code = product.Code,
        Name = product.Name,
        HsnCode = product.HsnCode,
        Rate = product.SellingPrice,
        GstRatePercent = product.GstRatePercent,
    };
}
