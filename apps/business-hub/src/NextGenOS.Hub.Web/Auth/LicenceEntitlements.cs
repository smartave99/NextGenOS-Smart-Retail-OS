using NextGenOS.Hub.Ai;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Auth;

/// <summary>What this PC's signed licence allows. A part of the program that needs a module (the AI parts need "ai") asks here, and a licence that is not usable allows nothing.</summary>
public sealed class LicenceEntitlements(ProductLicence licence) : IEntitlements
{
    public bool Has(string module)
    {
        var state = licence.State;
        return state.IsUsable && state.HasModule(module);
    }
}
