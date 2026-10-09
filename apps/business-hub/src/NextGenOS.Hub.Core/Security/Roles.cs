namespace NextGenOS.Hub.Security;

/// <summary>What each role may do. Every screen and every service call that changes something asks here, never "is this a manager?".</summary>
public static class Perm
{
    public const string Sell = "sell";
    public const string Orders = "orders";
    public const string Kitchen = "kitchen";
    public const string Loans = "loans";
    public const string Projects = "projects";
    public const string Appointments = "appointments";
    public const string Catalog = "catalog";
    public const string Parties = "parties";
    public const string Stock = "stock";
    public const string Purchases = "purchases";
    public const string Reports = "reports";
    public const string Void = "void";
    /// <summary>Giving any discount at the till. A cashier without it may still give a small one, up to the limit the owner sets in Settings.</summary>
    public const string Discount = "discount";
    public const string Settings = "settings";
    public const string Users = "users";
    /// <summary>The people who work for the shop: commission earners (salespeople, brokers) and what is owed to them, and, later, employees and their pay. Owners and managers.</summary>
    public const string Staff = "staff";
    /// <summary>Connecting AI services, choosing what they may receive, and reading what they cost. The owner only.</summary>
    public const string Ai = "ai";
    /// <summary>Letting counter PCs connect over the shop's network, pairing them and removing them. The owner only.</summary>
    public const string Network = "network";
}

public static class Roles
{
    public const string Owner = "owner";
    public const string Manager = "manager";
    public const string Cashier = "cashier";
    public const string Kitchen = "kitchen";
    public const string Librarian = "librarian";

    public static readonly IReadOnlyList<string> All = new[] { Owner, Manager, Cashier, Kitchen, Librarian };

    private static readonly Dictionary<string, HashSet<string>> Grants = new()
    {
        [Owner] = new(new[] { Perm.Sell, Perm.Orders, Perm.Kitchen, Perm.Loans, Perm.Projects, Perm.Appointments, Perm.Catalog, Perm.Parties, Perm.Stock, Perm.Purchases, Perm.Reports, Perm.Void, Perm.Discount, Perm.Settings, Perm.Users, Perm.Ai, Perm.Network, Perm.Staff }),
        [Manager] = new(new[] { Perm.Sell, Perm.Orders, Perm.Kitchen, Perm.Loans, Perm.Projects, Perm.Appointments, Perm.Catalog, Perm.Parties, Perm.Stock, Perm.Purchases, Perm.Reports, Perm.Void, Perm.Discount, Perm.Staff }),
        [Cashier] = new(new[] { Perm.Sell, Perm.Orders, Perm.Loans, Perm.Appointments, Perm.Parties }),
        [Kitchen] = new(new[] { Perm.Kitchen }),
        [Librarian] = new(new[] { Perm.Loans, Perm.Parties, Perm.Catalog }),
    };

    public static bool Can(string role, string permission) => Grants.TryGetValue(role, out var set) && set.Contains(permission);

    public static string Label(string role) => role switch
    {
        Owner => "Owner", Manager => "Manager", Cashier => "Cashier / front desk", Kitchen => "Kitchen", Librarian => "Librarian", _ => role,
    };
}
