using System.Globalization;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Data.Demo;

/// <summary>
/// Sample products and customers for the demo shop. Prices, stock and GST rates are illustrative only.
/// Barcodes use the 20–29 prefix GS1 reserves for in-store numbering, so they never clash with real products.
/// </summary>
internal static class DemoCatalog
{
    public static IEnumerable<Product> Products()
    {
        var id = 0;
        Product Item(string name, string category, string hsn, decimal gst, decimal price, decimal mrp, decimal inHand, decimal min)
        {
            id++;
            return new Product
            {
                Id = id,
                Code = (1000 + id).ToString(CultureInfo.InvariantCulture),
                Name = name,
                Barcode = InStoreEan13(id),
                HsnCode = hsn,
                Category = category,
                GstRatePercent = gst,
                SellingPrice = price,
                Mrp = mrp,
                StockInHand = inHand,
                MinStock = min,
            };
        }

        yield return Item("Basmati Rice 5 kg", "Staples", "1006", 5m, 549m, 599m, 18m, 10m);
        yield return Item("Whole Wheat Atta 5 kg", "Staples", "1101", 5m, 265m, 285m, 6m, 10m);
        yield return Item("Toor Dal 1 kg", "Staples", "0713", 5m, 165m, 180m, 25m, 15m);
        yield return Item("Sugar 1 kg", "Staples", "1701", 5m, 48m, 52m, 40m, 20m);
        yield return Item("Iodised Salt 1 kg", "Staples", "2501", 0m, 28m, 30m, 30m, 15m);
        yield return Item("Sunflower Oil 1 L", "Oils & Ghee", "1512", 5m, 155m, 175m, 4m, 12m);
        yield return Item("Desi Ghee 1 L", "Oils & Ghee", "0405", 5m, 640m, 675m, 7m, 5m);
        yield return Item("Toned Milk 500 ml", "Dairy", "0401", 0m, 28m, 28m, 36m, 24m);
        yield return Item("Paneer 200 g", "Dairy", "0406", 0m, 90m, 95m, 8m, 10m);
        yield return Item("Butter 100 g", "Dairy", "0405", 5m, 58m, 60m, 20m, 10m);
        yield return Item("Tea 250 g", "Beverages", "0902", 5m, 140m, 150m, 22m, 10m);
        yield return Item("Instant Coffee 50 g", "Beverages", "2101", 5m, 175m, 185m, 9m, 6m);
        yield return Item("Drinking Water 1 L", "Beverages", "2201", 5m, 20m, 20m, 48m, 24m);
        yield return Item("Glucose Biscuits 200 g", "Snacks", "1905", 5m, 20m, 20m, 120m, 50m);
        yield return Item("Bhujia 200 g", "Snacks", "2106", 5m, 55m, 60m, 35m, 20m);
        yield return Item("Milk Chocolate 50 g", "Snacks", "1806", 5m, 45m, 50m, 60m, 30m);
        yield return Item("Toothpaste 150 g", "Personal Care", "3306", 5m, 95m, 105m, 3m, 12m);
        yield return Item("Shampoo 180 ml", "Personal Care", "3305", 5m, 160m, 175m, 14m, 8m);
        yield return Item("Bath Soap 4 × 100 g", "Personal Care", "3401", 5m, 145m, 160m, 26m, 12m);
        yield return Item("Detergent Powder 1 kg", "Household", "3402", 18m, 110m, 120m, 11m, 10m);
        yield return Item("Dishwash Liquid 500 ml", "Household", "3402", 18m, 99m, 110m, 9m, 8m);
        yield return Item("Floor Cleaner 1 L", "Household", "3808", 18m, 185m, 199m, 2m, 6m);
        yield return Item("Notebook 172 pages", "Stationery", "4820", 0m, 55m, 60m, 80m, 40m);
        yield return Item("Ball Pen, pack of 5", "Stationery", "9608", 18m, 45m, 50m, 45m, 25m);
        yield return Item("Copper Water Bottle 1 L", "Home & Kitchen", "7418", 12m, 699m, 799m, 12m, 4m);
        yield return Item("Steel Lunch Box, 3 tiers", "Home & Kitchen", "7323", 12m, 449m, 499m, 10m, 4m);
        yield return Item("Glass Jar Set of 3", "Home & Kitchen", "7013", 18m, 299m, 349m, 15m, 5m);
    }

    /// <summary>Purchase prices set by hand, before GST. The biscuits' supplier charges more than they sell for.</summary>
    public static IReadOnlyDictionary<string, decimal> PurchasePrices { get; } = new Dictionary<string, decimal>(StringComparer.Ordinal)
    {
        ["Glucose Biscuits 200 g"] = 20.50m,
    };

    /// <summary>The products added in the last few weeks, with how many days ago; the rest came with the shop's first day.</summary>
    public static IReadOnlyDictionary<string, int> NewArrivals { get; } = new Dictionary<string, int>(StringComparer.Ordinal)
    {
        ["Copper Water Bottle 1 L"] = 9,
        ["Steel Lunch Box, 3 tiers"] = 16,
        ["Glass Jar Set of 3"] = 4,
    };

    public static IEnumerable<Customer> Customers()
    {
        string[] names =
        {
            "Ramesh Kumar", "Priya Sharma", "Anil Verma", "Sunita Devi",
            "Mohammed Irfan", "Kavita Patel", "Gurpreet Singh", "Lakshmi Iyer",
        };

        for (var i = 0; i < names.Length; i++)
        {
            yield return new Customer
            {
                Id = i + 1,
                Name = names[i],
                Phone = "90000001" + (i + 1).ToString("00", CultureInfo.InvariantCulture),
            };
        }
    }

    /// <summary>A valid EAN-13 in the in-store range: "20" + 10-digit number + check digit.</summary>
    internal static string InStoreEan13(int number)
    {
        var body = "20" + number.ToString("0000000000", CultureInfo.InvariantCulture);
        var sum = 0;
        for (var i = 0; i < body.Length; i++)
        {
            var digit = body[i] - '0';
            sum += i % 2 == 0 ? digit : digit * 3;
        }
        return body + ((10 - sum % 10) % 10).ToString(CultureInfo.InvariantCulture);
    }
}
