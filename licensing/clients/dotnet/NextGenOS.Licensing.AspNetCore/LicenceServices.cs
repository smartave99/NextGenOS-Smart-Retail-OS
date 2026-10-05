using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection;
using NextGenOS.Licensing;

namespace NextGenOS.Licensing.AspNetCore;

public static class LicenceServices
{
    /// <summary>
    /// Puts the signed licence in front of a web program: the manager (needing <paramref name="module"/>), the cached state, the brand, the
    /// check-in worker and the stop of live screens. Use <c>app.UseLicenceGate()</c> first in the pipeline, and
    /// <see cref="AddLicensedWorker{TWorker}"/> for every background worker.
    /// </summary>
    public static IServiceCollection AddNextGenOSLicence(this IServiceCollection services, string module, string appVersion)
    {
        var manager = ProductLicence.CreateManager(module, appVersion);
        services.AddSingleton(manager);
        services.AddSingleton(new ProductLicence(manager.Evaluate));
        services.AddSingleton<BrandService>();
        services.AddHostedService<LicenceWorker>();
        services.AddScoped<CircuitHandler, LicenceCircuitHandler>();
        return services;
    }
}
