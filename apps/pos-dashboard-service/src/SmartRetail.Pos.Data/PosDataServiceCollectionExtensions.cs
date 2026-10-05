using Microsoft.Extensions.DependencyInjection;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Data.Demo;
using SmartRetail.Pos.Data.SqlServer;

namespace SmartRetail.Pos.Data;

public static class PosDataServiceCollectionExtensions
{
    /// <summary>Registers the repositories for the configured data source, plus a <see cref="DataSourceInfo"/>.</summary>
    public static IServiceCollection AddPosData(this IServiceCollection services, PosDataOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        switch (options.Mode)
        {
            case PosDataMode.Demo:
                var store = new DemoStore(TimeProvider.System, seedSales: true);
                services.AddSingleton(store);
                services.AddSingleton<IProductRepository>(store);
                services.AddSingleton<ICustomerRepository>(store);
                services.AddSingleton<IStockRepository>(store);
                services.AddSingleton<IInvoiceRepository>(store);
                services.AddSingleton<ISalesFactsRepository>(store);
                services.AddSingleton<IShopChecksRepository>(store);
                services.AddSingleton(new DataSourceInfo("Demo shop (sample data)", IsDemo: true, CanSaveBills: true));
                break;

            case PosDataMode.SqlServer:
                if (string.IsNullOrWhiteSpace(options.ConnectionString))
                {
                    throw new InvalidOperationException(
                        "Pos:Mode is SqlServer but Pos:ConnectionString is empty. Set it in appsettings.Local.json " +
                        "or the Pos__ConnectionString environment variable, or set Pos:Mode to Demo.");
                }

                var db = new SqlDb(options.ConnectionString, options.CommandTimeoutSeconds);
                services.AddSingleton(db);
                services.AddSingleton<IProductRepository, SqlServerProductRepository>();
                services.AddSingleton<ICustomerRepository, SqlServerCustomerRepository>();
                services.AddSingleton<IStockRepository, SqlServerStockRepository>();
                services.AddSingleton<IInvoiceRepository, SqlServerInvoiceRepository>();
                services.AddSingleton<ISalesFactsRepository, SqlServerSalesFactsRepository>();
                services.AddSingleton<IShopChecksRepository, SqlServerShopChecksRepository>();
                services.AddSingleton(new DataSourceInfo(db.Describe() + " (read-only)", IsDemo: false, CanSaveBills: false));
                break;

            case PosDataMode.Auto:
                throw new InvalidOperationException("Pos:Mode Auto must be resolved to SqlServer or Demo before the data services are added.");

            default:
                throw new ArgumentOutOfRangeException(nameof(options), options.Mode, "Unknown Pos:Mode.");
        }

        return services;
    }
}
