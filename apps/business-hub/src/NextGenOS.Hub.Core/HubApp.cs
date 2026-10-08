using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Counters;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Appointments;
using NextGenOS.Hub.Backups;
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
    private HubApp(HubDb db, IClock clock, NextGenOS.Devices.Printing.PrintService? print, AiOptions? ai, bool trusted, NetworkOptions? network)
    {
        Db = db;
        Clock = clock;
        Audit = new AuditService(db, clock);
        Access = new Access(db, Audit, trusted);
        SettingsStore = new SettingsStore(db, Access);
        Shop = new ShopContextProvider(SettingsStore);
        Numbering = new Numbering(Shop);
        Parties = new PartyService(db, Shop, clock, Access);
        Books = new BooksService(db, clock);
        Catalog = new CatalogService(db, Shop, clock, Access, Books);
        Loyalty = new LoyaltyService(db, Shop, clock);
        Offers = new OffersService(db, Shop, clock, Audit, Access);
        Documents = new DocumentService(db, Shop, clock, Numbering, Catalog, Parties, Audit, Books, Loyalty, Offers, Access);
        Users = new UserService(db, clock, Audit, Access);
        Restaurant = new RestaurantService(db, Shop, clock, Documents, Audit, Access);
        Library = new LibraryService(db, Shop, clock, Catalog, Parties, Documents, Audit, Access);
        Projects = new ProjectService(db, Shop, clock, Documents, Parties, Audit, Books, Access);
        Appointments = new AppointmentService(db, Shop, clock, Catalog, Parties, Documents, Access);
        Purchasing = new PurchaseService(Documents, Catalog, Parties, Access);
        Reports = new ReportService(db, Shop, clock, Catalog);
        TaxRegisters = new TaxRegisterService(db, Shop);
        PrinterProfiles = new PrinterStore(SettingsStore, Audit);
        Printing = new HubPrinting(PrinterProfiles, print ?? new NextGenOS.Devices.Printing.PrintService(), Documents, Catalog, Shop, Audit, Offers, Loyalty);
        // The optional AI services. Built here, started by nobody: nothing runs, connects or downloads until the owner switches it on (and the licence has the AI part).
        Ai = new AiFoundation(db, clock, Audit, Path.GetDirectoryName(Path.GetFullPath(db.Path)) ?? ".", Access, ai);
        // The business event history (observations, events, evidence pointers) and its forgetting. Writing waits for the owner's switch; nothing in the shop's own screens writes to it yet.
        Retention = new RetentionService(db, clock, Audit, Access);
        Events = new EventStore(db, clock, Audit, Ai.Flags, Retention, Access);
        // The business map: what things there are and how they connect. The shop's own records are read in place, never copied.
        Ontology = new OntologyService(db, clock, Audit, Ai.Flags, Access);
        // Moving a shop across from an older system (a check first, then one all-or-nothing move). Nothing runs until the owner starts it from Settings.
        Importer = new ImportService(db, Shop, clock, Audit, Catalog, Parties, Offers, Books, Access);
        // The shop's own copies, made every night to a second place the owner chose (Settings, Backups), and putting one back.
        Backups = new BackupService(db, Shop, SettingsStore, clock, Audit, Access);
        // A store with one main PC and many counter PCs on the shop's own network: switched off unless the owner chose it (and the Hub was started again since). Nothing leaves the shop.
        Network = new StoreNetwork(db, clock, Audit, Access, Path.GetDirectoryName(Path.GetFullPath(db.Path)) ?? ".", network);
    }

    public HubDb Db { get; }
    /// <summary>The lock in front of every command that changes money, stock, people or settings: see <see cref="Security.Access"/>.</summary>
    public Access Access { get; }
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
    public BackupService Backups { get; }
    public StoreNetwork Network { get; }

    /// <summary>
    /// The shop's tidying that nobody has to ask for: clears sales left open for more than a day, lets library holds run out, and forgets business-event records that are past their day
    /// (whatever the switches say: forgetting never waits for one). It does nothing until the set-up has finished: before that the shop is still being made, and the sample company's open
    /// sales are dated days back, so they would look like sales that were forgotten.
    /// </summary>
    public void Upkeep()
    {
        var settings = Shop.Settings;
        if (string.IsNullOrEmpty(settings.Country) || !settings.SetupDone) return;
        using var asTheProgram = Access.AsSystem();
        Documents.DiscardStaleDrafts();
        Books.CatchUp();
        if (Shop.Current.Features.Lending) Library.ProcessHolds();
        Retention.Prune(null);
        Backups.RunIfDue();   // the night's copy, when it is due (a failed try is written down and shown to the owner; it never stops the till)
    }

    /// <summary>
    /// Opens (and, if needed, creates or brings up to date) the shop database at a path. An update of a shop that has data first makes a checked copy, in <paramref name="backupFolder"/>
    /// (next to the file when null); if the copy cannot be made this throws and the shop's data is untouched (<see cref="HubDb.Migrate()"/>).
    /// </summary>
    public static HubApp Open(string path, IClock? clock = null, NextGenOS.Devices.Printing.PrintService? print = null, AiOptions? ai = null, string? backupFolder = null, NetworkOptions? network = null) =>
        Open(path, clock, print, ai, backupFolder, trusted: false, network);

    /// <summary>
    /// A shop in which a command with nobody named is allowed: for the tests and for filling the sample company, where the program acts on its own. Not reachable from the program
    /// (internal): the shop that people use is opened with <see cref="Open(string, IClock?, NextGenOS.Devices.Printing.PrintService?, AiOptions?, string?)"/>, where a command with
    /// nobody named is refused (see <see cref="Security.Access"/>).
    /// </summary>
    internal static HubApp OpenTrusted(string path, IClock? clock = null, NextGenOS.Devices.Printing.PrintService? print = null, AiOptions? ai = null, string? backupFolder = null, NetworkOptions? network = null) =>
        Open(path, clock, print, ai, backupFolder, trusted: true, network);

    private static HubApp Open(string path, IClock? clock, NextGenOS.Devices.Printing.PrintService? print, AiOptions? ai, string? backupFolder, bool trusted, NetworkOptions? network)
    {
        var db = new HubDb(path, backupFolder);
        db.Migrate();
        var app = new HubApp(db, clock ?? new SystemClock(), print, ai, trusted, network);
        // Bills and payments made before the books existed are written into them now, before anything asks what a customer owes (the credit check reads the books).
        app.Books.CatchUp();
        return app;
    }
}
