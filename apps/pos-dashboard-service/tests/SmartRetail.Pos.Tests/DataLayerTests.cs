using Microsoft.Extensions.DependencyInjection;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Data;
using SmartRetail.Pos.Data.Demo;
using SmartRetail.Pos.Data.SqlServer;

namespace SmartRetail.Pos.Tests;

public class DataLayerTests
{
    [Fact]
    public void Demo_catalogue_barcodes_are_valid_unique_in_store_codes()
    {
        var products = DemoCatalog.Products().ToList();

        Assert.Equal(products.Count, products.Select(p => p.Id).Distinct().Count());
        Assert.Equal(products.Count, products.Select(p => p.Code).Distinct().Count());
        Assert.Equal(products.Count, products.Select(p => p.Barcode).Distinct().Count());
        Assert.All(products, p =>
        {
            Assert.Matches("^2[0-9]{12}$", p.Barcode);
            Assert.True(HasValidCheckDigit(p.Barcode!), p.Barcode);
            Assert.True(p.SellingPrice <= p.Mrp, p.Name);
        });
        Assert.Equal("2000000000084", DemoCatalog.InStoreEan13(8));
    }

    [Fact]
    public void Demo_mode_serves_everything_from_one_store()
    {
        using var provider = new ServiceCollection().AddPosData(new PosDataOptions()).BuildServiceProvider();

        var store = provider.GetRequiredService<DemoStore>();
        Assert.Same(store, provider.GetRequiredService<IProductRepository>());
        Assert.Same(store, provider.GetRequiredService<ICustomerRepository>());
        Assert.Same(store, provider.GetRequiredService<IStockRepository>());
        Assert.Same(store, provider.GetRequiredService<IInvoiceRepository>());

        var source = provider.GetRequiredService<DataSourceInfo>();
        Assert.True(source.IsDemo);
        Assert.True(source.CanSaveBills);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Sql_server_mode_needs_a_connection_string(string? connectionString)
    {
        var options = new PosDataOptions { Mode = PosDataMode.SqlServer, ConnectionString = connectionString };

        Assert.Throws<InvalidOperationException>(() => new ServiceCollection().AddPosData(options));
    }

    [Fact]
    public void Sql_server_mode_is_read_only_and_never_shows_the_password()
    {
        var options = new PosDataOptions
        {
            Mode = PosDataMode.SqlServer,
            ConnectionString = @"Server=SHOP-PC\SQLEXPRESS;Database=PosDb;User ID=pos_reader;Password=not-a-real-password;TrustServerCertificate=true",
        };

        using var provider = new ServiceCollection().AddPosData(options).BuildServiceProvider();

        var source = provider.GetRequiredService<DataSourceInfo>();
        Assert.Equal(@"PosDb on SHOP-PC\SQLEXPRESS (read-only)", source.Name);
        Assert.False(source.IsDemo);
        Assert.False(source.CanSaveBills);
        Assert.DoesNotContain("not-a-real-password", source.Name);
        Assert.IsType<SqlServerProductRepository>(provider.GetRequiredService<IProductRepository>());
        Assert.IsType<SqlServerInvoiceRepository>(provider.GetRequiredService<IInvoiceRepository>());
    }

    [Theory]
    [InlineData("rice", "%rice%")]
    [InlineData("  rice ", "%rice%")]
    [InlineData("50%", "%50[%]%")]
    [InlineData("a_b", "%a[_]b%")]
    [InlineData("[x]", "%[[]x]%")]
    public void Search_terms_become_literal_like_patterns(string term, string expected)
    {
        Assert.Equal(expected, SqlDb.ContainsPattern(term));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void An_empty_search_term_matches_everything(string? term)
    {
        Assert.Null(SqlDb.ContainsPattern(term));
    }

    [Fact]
    public void Database_description_shows_only_the_database_and_server()
    {
        Assert.Equal(@"PosDb on .\SQLEXPRESS", new SqlDb(@"Server=.\SQLEXPRESS;Database=PosDb;User ID=u;Password=x1", 15).Describe());
        Assert.Equal("POS database on localhost", new SqlDb("Server=localhost;Integrated Security=true", 15).Describe());
        Assert.Throws<ArgumentException>(() => new SqlDb(" ", 15));
    }

    private static bool HasValidCheckDigit(string ean13)
    {
        var sum = 0;
        for (var i = 0; i < 12; i++)
        {
            sum += (ean13[i] - '0') * (i % 2 == 0 ? 1 : 3);
        }
        return (10 - sum % 10) % 10 == ean13[12] - '0';
    }
}
