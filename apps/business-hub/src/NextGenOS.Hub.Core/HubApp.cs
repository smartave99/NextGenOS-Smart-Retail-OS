using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Appointments;
using NextGenOS.Hub.Books;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Import;
using NextGenOS.Hub.Lending;
using NextGenOS.Hub.Loyalty;
using NextGenOS.Hub.Offers;
using NextGenOS.Hub.Ontology;
using NextGenOS.Hub.Printing;
using NextGenOS.Hub.Projects;
using NextGenOS.Hub.Purchasing;
using NextGenOS.Hub.Reports;
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
    private HubApp(HubDb db, IClock clock, NextGenOS.Devices.Printing.PrintService? print, AiOptions? ai)
    {
        Db = db;
        Clock = clock;
        SettingsStore = new SettingsStore(db);
        Shop = new ShopContextProvider(SettingsStore);
        Audit = new AuditService(db, clock);
        Numbering = new Numbering(Shop);
        Parties = new PartyService(db, Shop, clock);
        Catalog = new CatalogService(db, Shop, clock);
        Books = new BooksService(db, clock);
        Loyalty = new LoyaltyService(db, Shop, clock);
        Offers = new OffersService(db, Shop, clock, Audit);
        Documents = new DocumentService(db, Shop, clock, Numbering, Catalog, Parties, Audit, Books, Loyalty, Offers);
        Users = new UserService(db, clock, Audit);
        Restaurant = new RestaurantService(db, Shop, clock, Documents, Audit);
        Library = new LibraryService(db, Shop, clock, Catalog, Parties, Documents, Audit);
        Projects = new ProjectService(db, Shop, clock, Documents, Parties, Audit, Books);
        Appointments = new AppointmentService(db, Shop, clock, Catalog, Parties, Documents);
        Purchasing = new PurchaseService(Documents, Catalog, Parties);
        Reports = new ReportService(db, Shop, clock, Catalog);
        TaxRegisters = new TaxRegisterService(db, Shop);
        PrinterProfiles = new PrinterStore(SettingsStore, Audit);
        Printing = new HubPrinting(PrinterProfiles, print ?? new NextGenOS.Devices.Printing.PrintService(), Documents, Catalog, Shop, Audit, Offers, Loyalty);
        // The optional AI services. Built here, started by nobody: nothing runs, connects or downloads until the owner switches it on (and the licence has the AI part).
        Ai = new AiFoundation(db, clock, Audit, Path.GetDirectoryName(Path.GetFullPath(db.Path)) ?? ".", ai);
        // The business event history (observations, events, evidence pointers) and its forgetting. Writing waits for the owner's switch; nothing in the shop's own screens writes to it yet.
        Retention = new RetentionService(db, clock, Audit);
        Events = new EventStore(db, clock, Audit, Ai.Flags, Retention);
        // The business map: what things there are and how they connect. The shop's own records are read in place, never copied.
        Ontology = new OntologyService(db, clock, Audit, Ai.Flags);
        // Moving a shop across from an older system (a check first, then one all-or-nothing move). Nothing runs until the owner starts it from Settings.
        Importer = new ImportService(db, Shop, clock, Audit, Catalog, Parties, Offers);
    }

    public HubDb Db { get; }
    public IClock Clock { get; }
    public SettingsStore SettingsStore { get; }
    public ShopContextProvider Shop { get; }
    public AuditService Audit { get; }
    public Numbering Numbering { get; }
    public PartyService Parties { get; }
    public CatalogService Catalog { get; }
    public BooksService Books { get; }
    public LoyaltyService Loyalty { get; }
    public OffersService Offers { get; }
    public DocumentService Documents { get; }
    public UserService Users { get; }
    public RestaurantService Restaurant { get; }
    public LibraryService Library { get; }
    public ProjectService Projects { get; }
    public AppointmentService Appointments { get; }
    public PurchaseService Purchasing { get; }
    public ReportService Reports { get; }
    public TaxRegisterService TaxRegisters { get; }
    public PrinterStore PrinterProfiles { get; }
    public HubPrinting Printing { get; }
    public AiFoundation Ai { get; }
    public RetentionService Retention { get; }
    public EventStore Events { get; }
    public OntologyService Ontology { get; }
    public ImportService Importer { get; }

    /// <summary>
    /// The shop's tidying that nobody has to ask for: clears sales left open for more than a day, lets library holds run out, and forgets business-event records that are past their day
    /// (whatever the switches say: forgetting never waits for one). It does nothing until the set-up has finished: before that the shop is still being made, and the sample company's open
    /// sales are dated days back, so they would look like sales that were forgotten.
    /// </summary>
    public void Upkeep()
    {
        var settings = Shop.Settings;
        if (string.IsNullOrEmpty(settings.Country) || !settings.SetupDone) return;
        Documents.DiscardStaleDrafts();
        Books.CatchUp();
        if (Shop.Current.Features.Lending) Library.ProcessHolds();
        Retention.Prune(null);
    }

    /// <summary>
    /// Opens (and, if needed, creates or brings up to date) the shop database at a path. An update of a shop that has data first makes a checked copy, in <paramref name="backupFolder"/>
    /// (next to the file when null); if the copy cannot be made this throws and the shop's data is untouched (<see cref="HubDb.Migrate()"/>).
    /// </summary>
    public static HubApp Open(string path, IClock? clock = null, NextGenOS.Devices.Printing.PrintService? print = null, AiOptions? ai = null, string? backupFolder = null)
    {
        var db = new HubDb(path, backupFolder);
        db.Migrate();
        var app = new HubApp(db, clock ?? new SystemClock(), print, ai);
        // Bills and payments made before the books existed are written into them now, before anything asks what a customer owes (the credit check reads the books).
        app.Books.CatchUp();
        return app;
    }
}
