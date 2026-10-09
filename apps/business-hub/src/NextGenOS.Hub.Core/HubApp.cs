using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Counters;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Actions;
using NextGenOS.Hub.Appointments;
using NextGenOS.Hub.Backups;
using NextGenOS.Hub.Books;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Import;
using NextGenOS.Hub.Insights;
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
using NextGenOS.Hub.Staff;
using NextGenOS.Hub.Diagnostics;
using NextGenOS.Hub.Updates;

namespace NextGenOS.Hub;

/// <summary>
/// All the Hub's services over one shop database, built together: what the web program, the demo command and the tests use. Services that depend
/// on each other are given each other here, once.
/// </summary>
public sealed class HubApp
{
    private HubApp(HubDb db, IClock clock, NextGenOS.Devices.Printing.PrintService? print, AiOptions? ai, bool trusted, NetworkOptions? network, UpdateOptions? updates)
    {
        Db = db;
        Clock = clock;
        Audit = new AuditService(db, clock);
        Access = new Access(db, Audit, trusted);
        SettingsStore = new SettingsStore(db, Access);
        Shop = new ShopContextProvider(SettingsStore);
        Numbering = new Numbering(Shop);
        Parties = new PartyService(db, Shop, clock, Access);
        // The optional AI services. Built here, started by nobody: nothing runs, connects or downloads until the owner switches it on (and the licence has the AI part).
        Ai = new AiFoundation(db, clock, Audit, Path.GetDirectoryName(Path.GetFullPath(db.Path)) ?? ".", Access, ai);
        // The business event history (observations, events, evidence pointers) and its forgetting. Writing waits for the owner's switch.
        Retention = new RetentionService(db, clock, Audit, Access);
        Events = new EventStore(db, clock, Audit, Ai.Flags, Retention, Access);
        // The outbox: a sale, a return, a payment, a purchase and a stock change leave a message in the very transaction that makes them (only while the event history is on); the upkeep delivers them.
        Outbox = new OutboxService(db, clock, Ai.Flags, Events, Audit, Access);
        Books = new BooksService(db, clock, Access);
        Catalog = new CatalogService(db, Shop, clock, Access, Books, Outbox);
        CatalogChanges = new CatalogChangeService(db, Shop, clock, Audit, Access);
        Loyalty = new LoyaltyService(db, Shop, clock);
        Offers = new OffersService(db, Shop, clock, Audit, Access);
        Earners = new EarnerService(db, Shop, clock, Audit, Books, Access);
        Payroll = new PayrollService(db, Shop, clock, Audit, Books, Access);
        Batches = new BatchService(db, Shop, clock, Audit, Access);
        Groups = new GroupService(db, Catalog, Audit, clock, Access);
        Documents = new DocumentService(db, Shop, clock, Numbering, Catalog, Parties, Audit, Books, Loyalty, Offers, Outbox, Access, Earners);
        Users = new UserService(db, clock, Audit, Access);
        Restaurant = new RestaurantService(db, Shop, clock, Documents, Audit, Access);
        Library = new LibraryService(db, Shop, clock, Catalog, Parties, Documents, Audit, Access);
        Projects = new ProjectService(db, Shop, clock, Documents, Parties, Audit, Books, Access);
        Appointments = new AppointmentService(db, Shop, clock, Catalog, Parties, Documents, Access);
        Purchasing = new PurchaseService(Documents, Catalog, Parties, Access);
        // Running low against the supplier's delivery time: plain arithmetic on the shop's own figures, off until the owner switches on stock forecasts.
        Supply = new SupplyService(db, clock, Audit, Access);
        Insights = new InsightService(db, clock, Audit, Ai.Flags, Outbox, Supply, Access);
        // Requests for a closed list of things, each approved by a person before it is done (today: a draft order to a supplier). Off until the owner switches on suggested actions.
        Actions = new ActionService(db, clock, Audit, Ai.Flags, Outbox, Insights, new ActionRegistry([new CreatePurchaseOrderAction(db, Parties, Catalog, Purchasing, Shop)]), Access);
        Reports = new ReportService(db, Shop, clock, Catalog, Access);
        TaxRegisters = new TaxRegisterService(db, Shop, Access);
        PrinterProfiles = new PrinterStore(SettingsStore, Audit);
        Printing = new HubPrinting(PrinterProfiles, print ?? new NextGenOS.Devices.Printing.PrintService(), Documents, Catalog, Shop, Audit, Offers, Loyalty);
        // The business map: what things there are and how they connect. The shop's own records are read in place, never copied.
        Ontology = new OntologyService(db, clock, Audit, Ai.Flags, Access);
        // Moving a shop across from an older system (a check first, then one all-or-nothing move). Nothing runs until the owner starts it from Settings.
        Importer = new ImportService(db, Shop, clock, Audit, Catalog, Parties, Offers, Books, Access);
        ItemSheets = new ItemSheetService(db, Shop, clock, Audit, Catalog, Books, Access);
        PartySheets = new PartySheetService(db, Shop, clock, Audit, Parties, Books, Access);
        // The shop's own copies, made every night to a second place the owner chose (Settings, Backups), and putting one back.
        Backups = new BackupService(db, Shop, SettingsStore, clock, Audit, Access);
        // Updates through the main PC: looks for a signed newer version, keeps it checked on this PC, and waits for the owner's yes. Nothing is installed by it. A copy built without a place to look never looks.
        Updates = new UpdateService(db, SettingsStore, clock, Audit, Backups, Access, updates);
        // A store with one main PC and many counter PCs on the shop's own network: switched off unless the owner chose it (and the Hub was started again since). Nothing leaves the shop.
        Network = new StoreNetwork(db, clock, Audit, Access, Path.GetDirectoryName(Path.GetFullPath(db.Path)) ?? ".", network);
        // The Help button's support file: facts about how the shop is set up and how it is doing, never what it sold or to whom.
        Support = new SupportService(this);
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
    public OutboxService Outbox { get; }
    public CatalogChangeService CatalogChanges { get; }
    public ItemSheetService ItemSheets { get; }
    public PartySheetService PartySheets { get; }
    public EarnerService Earners { get; }
    public PayrollService Payroll { get; }
    public BatchService Batches { get; }
    public GroupService Groups { get; }
    public LoyaltyService Loyalty { get; }
    public OffersService Offers { get; }
    public DocumentService Documents { get; }
    public UserService Users { get; }
    public RestaurantService Restaurant { get; }
    public LibraryService Library { get; }
    public ProjectService Projects { get; }
    public AppointmentService Appointments { get; }
    public PurchaseService Purchasing { get; }
    public SupplyService Supply { get; }
    public InsightService Insights { get; }
    public ActionService Actions { get; }
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
    public UpdateService Updates { get; }
    public StoreNetwork Network { get; }
    public SupportService Support { get; }

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
        Actions.Sweep();
        try { Insights.RunIfDue(); } catch (HubException) { /* a forecast that cannot be made today is made tomorrow; it never stops the rest of the upkeep */ }
        Outbox.DispatchAll();   // messages left by sales and stock changes since the last time are handed to the event history (nothing happens while it is switched off)
        if (Shop.Current.Features.Lending) Library.ProcessHolds();
        Retention.Prune(null);
        Backups.RunIfDue();   // the night's copy, when it is due (a failed try is written down and shown to the owner; it never stops the till)
    }

    /// <summary>
    /// The part of the upkeep that needs the internet, called by the background worker on its own schedule: looks for a newer version of the program when it is due (<see cref="UpdateService"/>).
    /// A problem with the internet is written down by the service and never thrown; nothing is installed.
    /// </summary>
    public async Task UpkeepOnlineAsync(CancellationToken ct = default)
    {
        var settings = Shop.Settings;
        if (string.IsNullOrEmpty(settings.Country) || !settings.SetupDone) return;
        using var asTheProgram = Access.AsSystem();
        await Updates.LookIfDueAsync(ct);
    }

    /// <summary>
    /// Opens (and, if needed, creates or brings up to date) the shop database at a path. An update of a shop that has data first makes a checked copy, in <paramref name="backupFolder"/>
    /// (next to the file when null); if the copy cannot be made this throws and the shop's data is untouched (<see cref="HubDb.Migrate()"/>).
    /// </summary>
    public static HubApp Open(string path, IClock? clock = null, NextGenOS.Devices.Printing.PrintService? print = null, AiOptions? ai = null, string? backupFolder = null, NetworkOptions? network = null, UpdateOptions? updates = null) =>
        Open(path, clock, print, ai, backupFolder, trusted: false, network, updates);

    /// <summary>
    /// A shop in which a command with nobody named is allowed: for the tests and for filling the sample company, where the program acts on its own. Not reachable from the program
    /// (internal): the shop that people use is opened with <see cref="Open(string, IClock?, NextGenOS.Devices.Printing.PrintService?, AiOptions?, string?)"/>, where a command with
    /// nobody named is refused (see <see cref="Security.Access"/>).
    /// </summary>
    internal static HubApp OpenTrusted(string path, IClock? clock = null, NextGenOS.Devices.Printing.PrintService? print = null, AiOptions? ai = null, string? backupFolder = null, NetworkOptions? network = null, UpdateOptions? updates = null) =>
        Open(path, clock, print, ai, backupFolder, trusted: true, network, updates);

    private static HubApp Open(string path, IClock? clock, NextGenOS.Devices.Printing.PrintService? print, AiOptions? ai, string? backupFolder, bool trusted, NetworkOptions? network, UpdateOptions? updates)
    {
        var db = new HubDb(path, backupFolder);
        db.Migrate();
        var app = new HubApp(db, clock ?? new SystemClock(), print, ai, trusted, network, updates);
        // Bills and payments made before the books existed are written into them now, before anything asks what a customer owes (the credit check reads the books).
        app.Books.CatchUp();
        // What a stopped program left in the outbox is delivered now (once: the event history keeps one event for one message).
        using (app.Access.AsSystem()) app.Outbox.DispatchAll();
        return app;
    }
}
