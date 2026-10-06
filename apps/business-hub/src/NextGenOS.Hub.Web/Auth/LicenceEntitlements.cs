using NextGenOS.Hub.Ai;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Auth;

/// <summary>What this PC's signed licence allows. A part of the program that needs a module (the AI parts need "ai") asks here, and a licence that is not usable allows nothing.</summary>
public static class LicenceEntitlements
{
    /// <summary>The licence looked at again each time it is asked (the licence object itself looks at the files only every half minute).</summary>
    public static IEntitlements From(ProductLicence licence) => new DelegateEntitlements(module =>
    {
        var state = licence.State;
        return state.IsUsable && state.HasModule(module);
    });
}
