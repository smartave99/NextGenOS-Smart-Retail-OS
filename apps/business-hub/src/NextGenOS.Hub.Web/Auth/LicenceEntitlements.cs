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

    /// <summary>
    /// How many PCs the signed licence is for (<c>limits.devices</c>): the main PC and its counter PCs together. 0 means the licence gives no limit (or there is no usable licence, in which
    /// nothing runs anyway). Handed to the Hub as a function, for the same reason as <see cref="From"/>.
    /// </summary>
    public static Func<int> DeviceLimit(ProductLicence licence) => () =>
    {
        var state = licence.State;
        return state.IsUsable && state.Licence?.Limits is { Devices: > 0 } limits ? limits.Devices : 0;
    };
}
