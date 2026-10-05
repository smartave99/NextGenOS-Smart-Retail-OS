namespace SmartRetail.Pos.Core.Billing;

/// <summary>How GST is charged on a bill.</summary>
public enum GstMode
{
    /// <summary>Sale within the shop's state: the tax is split into CGST and SGST.</summary>
    Intrastate,

    /// <summary>Sale to another state: the whole tax is IGST.</summary>
    Interstate,
}
