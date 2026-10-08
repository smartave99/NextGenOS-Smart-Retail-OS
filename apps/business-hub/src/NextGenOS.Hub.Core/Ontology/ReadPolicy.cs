using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Ontology;

/// <summary>
/// Who may see a kind of thing in the business map (blueprint ONT-010). The map is a way of looking at the shop's records, so it shows a person exactly what the shop's own screens already
/// show that person and nothing more: a cashier sees products, customers and bills, not the people who work here or the owner's projects; a kitchen screen sees tables and menu items, not
/// money. The same rule is applied before anything is handed to a screen or, later, to an assistant, so the assistant can never tell what the person asking could not see.
/// <para>
/// The built-in kinds are listed below, each with the permissions the shop's screens ask for. A kind the owner adds is judged by its data class instead: public and internal things are for
/// anyone who works here, confidential things need the reports, personal things need the customer list. A kind that is none of these (card details, biometric data) is for nobody.
/// </para>
/// </summary>
public static class ReadPolicy
{
    /// <summary>What the screens for bills and orders ask for (the same list as <c>DocumentService</c>), and the reports.</summary>
    private static readonly string[] Documents = [Perm.Sell, Perm.Orders, Perm.Loans, Perm.Appointments, Perm.Projects, Perm.Purchases, Perm.Reports];

    private static readonly string[] AnyWork = [Perm.Sell, Perm.Orders, Perm.Kitchen, Perm.Loans, Perm.Appointments, Perm.Projects, Perm.Catalog, Perm.Parties, Perm.Stock, Perm.Purchases, Perm.Reports, Perm.Void, Perm.Discount, Perm.Settings, Perm.Users, Perm.Ai, Perm.Network];

    private static readonly IReadOnlyDictionary<string, string[]> ByType = new Dictionary<string, string[]>
    {
        [EntityType.Product] = [Perm.Sell, Perm.Orders, Perm.Kitchen, Perm.Loans, Perm.Appointments, Perm.Projects, Perm.Catalog, Perm.Stock, Perm.Purchases, Perm.Reports],
        [EntityType.Party] = [Perm.Parties, Perm.Purchases, Perm.Reports],
        [EntityType.User] = [Perm.Users],
        [EntityType.Document] = Documents,
        [EntityType.Payment] = [Perm.Sell, Perm.Reports],
        [EntityType.Table] = [Perm.Orders, Perm.Kitchen],
        [EntityType.Project] = [Perm.Projects, Perm.Reports],
        [EntityType.Device] = [Perm.Settings, Perm.Ai],
    };

    /// <summary>The permissions of which any one lets a person see this kind of thing. Empty: nobody. (The program itself always may.)</summary>
    public static IReadOnlyList<string> Needed(string type, string dataClass)
    {
        if (ByType.TryGetValue(type, out var listed)) return listed;
        return dataClass switch
        {
            DataClass.Public or DataClass.Internal => AnyWork,
            DataClass.Confidential or DataClass.Financial => [Perm.Reports],
            DataClass.Personal => [Perm.Parties],
            _ => [],   // card details, biometric data, pictures and sound are never read through the map
        };
    }

    /// <summary>May this person see things of this kind?</summary>
    public static bool CanSee(Actor who, string type, string dataClass) => who.CanAny(Needed(type, dataClass));
}
