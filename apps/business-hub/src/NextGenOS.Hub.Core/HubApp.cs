using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Lending;
using NextGenOS.Hub.Restaurant;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub;

/// <summary>
/// All the Hub's services over one shop database, built together: what the web program, the demo command and the tests use. Services that depend
/// on each other are given each other here, once.
/// </summary>
public sealed class HubApp
{
    private HubApp(HubDb db, IClock clock)
    {
        Db = db;
        Clock = clock;
        SettingsStore = new SettingsStore(db);
        Shop = new ShopContextProvider(SettingsStore);
        Audit = new AuditService(db, clock);
        Numbering = new Numbering(Shop);
        Parties = new PartyService(db, Shop, clock);
        Catalog = new CatalogService(db, Shop, clock);
        Documents = new DocumentService(db, Shop, clock, Numbering, Catalog, Parties, Audit);
        Users = new UserService(db, clock, Audit);
        Restaurant = new RestaurantService(db, Shop, clock, Documents, Audit);
        Library = new LibraryService(db, Shop, clock, Catalog, Parties, Documents, Audit);
    }

    public HubDb Db { get; }
    public IClock Clock { get; }
    public SettingsStore SettingsStore { get; }
    public ShopContextProvider Shop { get; }
    public AuditService Audit { get; }
    public Numbering Numbering { get; }
    public PartyService Parties { get; }
    public CatalogService Catalog { get; }
    public DocumentService Documents { get; }
    public UserService Users { get; }
    public RestaurantService Restaurant { get; }
    public LibraryService Library { get; }

    /// <summary>Opens (and, if needed, creates or brings up to date) the shop database at a path.</summary>
    public static HubApp Open(string path, IClock? clock = null)
    {
        var db = new HubDb(path);
        db.Migrate();
        return new HubApp(db, clock ?? new SystemClock());
    }
}
