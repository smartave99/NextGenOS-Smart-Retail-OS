using Microsoft.Net.Http.Headers;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Memory;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Bills;
using SmartRetail.Pos.Data;
using SmartRetail.Pos.Web.Components;
using NextGenOS.Licensing.AspNetCore;
using SmartRetail.Pos.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Machine-specific settings such as the SQL Server connection string live in this git-ignored file.
// Environment variables are added again after it so they still win.
builder.Configuration
    .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables();

var ai = builder.Configuration.GetSection(AiOptions.SectionName).Get<AiOptions>() ?? new AiOptions();
var configured = builder.Configuration.GetSection(PosDataOptions.SectionName).Get<PosDataOptions>() ?? new PosDataOptions();

// Pos:Mode Auto finds the POS database on this PC (read-only), or falls back to the demo shop.
var (posData, connection) = await PosAutoConnect.ResolveAsync(configured, ai.SettingsFilePath, CancellationToken.None);
builder.Services.AddPosData(posData);
builder.Services.AddSingleton(connection);
builder.Services.Configure<ShopOptions>(builder.Configuration.GetSection(ShopOptions.SectionName));
builder.Services.PostConfigure<ShopOptions>(shop =>
{
    // Unless appsettings names the shop: its name from the POS database, or the demo shop's.
    if (string.IsNullOrWhiteSpace(shop.Name))
    {
        var demo = posData.Mode == PosDataMode.Demo;
        shop.Name = connection.CompanyName.Length > 0 ? connection.CompanyName : demo ? ShopOptions.DemoName : ShopOptions.DefaultName;
        if (demo && string.IsNullOrWhiteSpace(shop.Address))
        {
            shop.Address = ShopOptions.DemoAddress;
        }
    }
});
builder.Services.Configure<AiOptions>(builder.Configuration.GetSection(AiOptions.SectionName));
builder.Services.AddSingleton<AiRunGate>();
builder.Services.AddSingleton<AiEnvironment>();
builder.Services.AddSingleton<AiSetupService>();
builder.Services.AddSingleton<CodexAccountService>();
builder.Services.AddSingleton<StorageService>();
// What the Windows app found when it looked for a newer version, for the bell and Settings.
builder.Services.Configure<UpdateOptions>(builder.Configuration.GetSection(UpdateOptions.SectionName));
builder.Services.AddSingleton<UpdateStatusService>();
builder.Services.AddSingleton<WhatsNewService>();
builder.Services.Configure<CodexUpdateOptions>(builder.Configuration.GetSection(CodexUpdateOptions.SectionName));
builder.Services.AddSingleton<CodexUpdateService>();
builder.Services.AddLicensedWorker<CodexUpdateWorker>();
builder.Services.AddSingleton<ProductPhotoService>();
// Finding a product with the camera: barcodes always, and its look once turned on (DINOv2, on this PC).
builder.Services.Configure<CameraSearchOptions>(builder.Configuration.GetSection(CameraSearchOptions.SectionName));
builder.Services.AddSingleton<CameraSearchService>();
builder.Services.AddLicensedWorker<CameraSearchWorker>();
builder.Services.AddLicensedWorker<PhotoMakerWorker>();
builder.Services.AddSingleton<GrowthPlanService>();
builder.Services.AddSingleton<PosterStore>();
builder.Services.AddSingleton<PosterService>();
builder.Services.AddSingleton<PosterArtworkWorker>();
// Creatives: advertisements designed by Codex's image tool from the owner's brief, with the POS's prices added by the app.
builder.Services.AddSingleton<CreativeStore>();
builder.Services.AddSingleton<CreativeService>();
builder.Services.AddLicensedWorker<CreativeWorker>();
builder.Services.AddSingleton<FixNowService>();
builder.Services.AddSingleton<PlaybookService>();
builder.Services.AddSingleton<PriceCheckService>();
builder.Services.AddSingleton<MemoryService>();
builder.Services.AddSingleton<ActionService>();
builder.Services.AddSingleton<ReviewService>();
builder.Services.AddLicensedWorker<ReviewWorker>();
builder.Services.AddSingleton<ChatHistoryService>();
builder.Services.AddLicensedWorker<ChatHistoryCleaner>();

// The owner's live view: the shop's figures sent to the owner's own Supabase project, for the website.
builder.Services.AddSingleton<SmartRetail.AI.Settings.ISecretProtector>(
    OperatingSystem.IsWindows() ? new SmartRetail.AI.Settings.DpapiSecretProtector() : new MemorySecretProtector());
builder.Services.AddSingleton(_ => new OwnerViewClient(
    new HttpClient(new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(5) }) { Timeout = TimeSpan.FromSeconds(30) }));
builder.Services.AddSingleton<OwnerViewService>();
builder.Services.AddLicensedWorker<OwnerViewWorker>();
builder.Services.AddLicensedWorker<OwnerQuestionWorker>();
// Finished products offered to the owner's website: they wait in the owner's Supabase project until the owner approves each one there.
builder.Services.AddSingleton<WebsiteService>();
builder.Services.AddLicensedWorker<WebsiteWorker>();

// Ask AI: one chat for the app window and the side panel. On the POS database it is the side panel's assistant
// (SqlGuard, a transaction that is rolled back, contact details hidden from the AI); on the demo shop the AI answers
// from the sales figures. Both are given what the assistant remembers, and "Remember that…" and "Forget…" change
// memory without an AI.
builder.Services.AddSingleton<IChatBackend>(services =>
{
    var memory = services.GetRequiredService<MemoryService>();
    IChatBackend chat = posData.Mode == PosDataMode.SqlServer
        ? new BusinessChatBackend(
            () => services.GetRequiredService<AiEnvironment>().CreateRouter(AiJob.Ask),
            new SqlClientQueryExecutor(posData.ConnectionString!, Math.Max(30, posData.CommandTimeoutSeconds)),
            () => services.GetRequiredService<AiEnvironment>().LoadSettings(),
            memory: memory.Snapshot)
        : ActivatorUtilities.CreateInstance<DemoChatBackend>(services);
    return new MemoryChatBackend(chat, memory);
});
// Photos and voice notes sent with chat questions: temporary, gone when the chat ends.
builder.Services.AddSingleton(_ => new ChatAttachmentStore());
builder.Services.AddSingleton(services =>
{
    var chat = new Conversation(services.GetRequiredService<IChatBackend>());
    var log = services.GetRequiredService<ILogger<Conversation>>();
    chat.Failed += (_, exception) => log.LogError(exception, "A chat question failed.");
    // Kept after every answer, so closing the app, even suddenly (the desktop app stops the dashboard at once), loses
    // nothing of the chat.
    chat.Changed += (_, _) =>
    {
        if (!chat.Busy)
        {
            services.GetRequiredService<ChatHistoryService>().KeepSoFar(chat.Messages);
        }
    };
    chat.Ended += (_, ended) =>
    {
        services.GetRequiredService<ChatHistoryService>().Keep(ended);
        services.GetRequiredService<ChatAttachmentStore>().Delete(ended.SelectMany(message => message.Attachments));
    };
    return chat;
});
builder.Services.AddSingleton<ChatInputs>();
// After a chat, the AI (thinking briefly) suggests what is worth remembering, and what the owner said the shop is
// doing to sell more, to track on the Actions page.
builder.Services.AddSingleton(services =>
{
    var ai = services.GetRequiredService<AiEnvironment>();
    var reviewer = new MemoryReviewer(services.GetRequiredService<Conversation>(), services.GetRequiredService<MemoryService>(),
        () => ai.CreateRouter(AiJob.MemoryReview), ai.LoadSettings);
    reviewer.ActionsSuggested += (_, heard) => services.GetRequiredService<ActionService>().Suggest(heard);
    return reviewer;
});
builder.Services.AddLicensedWorker<MemoryReviewWorker>();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddScoped<BillSession>();
builder.Services.AddScoped<CameraSearchLauncher>();

// The signed licence (one per PC, shared with the Windows app and the POS): the dashboard runs only with a valid one that includes the
// dashboard module. The gate, the stop of live screens, the check-in and the brand come from NextGenOS.Licensing.AspNetCore.
builder.Services.AddNextGenOSLicence("dashboard", typeof(Program).Assembly.GetName().Version?.ToString() ?? "0.0.0");

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Photos and voice notes left from a chat of an earlier run (the app stopped suddenly) go: the chat went with it.
app.Services.GetRequiredService<ChatAttachmentStore>().DeleteLeftOver();

// The chat going on when the app closes is kept with the past chats, as if a new one had started, and its photos and
// voice notes go.
app.Lifetime.ApplicationStopping.Register(() =>
{
    var chat = app.Services.GetRequiredService<Conversation>().Messages;
    app.Services.GetRequiredService<ChatHistoryService>().Keep(chat);
    app.Services.GetRequiredService<ChatAttachmentStore>().Delete(chat.SelectMany(message => message.Attachments));
});

// First of all: nothing is served, not even a static file, without a usable licence.
app.UseLicenceGate();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

// No HTTPS redirect: the app listens on 127.0.0.1 only (see Kestrel in appsettings.json), so
// traffic never leaves the shop PC.
app.UseAntiforgery();

app.MapStaticAssets();

// Product photos, from the data folder the owner chose. The store only hands back file names it made.
app.MapGet("/product-photos/{productId:int}/all.zip", async (int productId, string? set, ProductPhotoService photos, CancellationToken ct) =>
    await photos.ZipAsync(productId, set, ct) is { } zip ? Results.File(zip.Zip, "application/zip", zip.FileName) : Results.NotFound());
app.MapGet("/product-photos/{productId:int}/{fileName}", (int productId, string fileName, bool? download, ProductPhotoService photos, HttpContext http) =>
{
    if (photos.Store.PathOf(productId, fileName) is not { } path)
    {
        return Results.NotFound();
    }

    http.Response.Headers.CacheControl = "private, max-age=31536000, immutable";
    var type = Path.GetExtension(path).ToLowerInvariant() switch
    {
        ".png" => "image/png",
        ".webp" => "image/webp",
        _ => "image/jpeg",
    };
    return Results.File(path, type, download == true ? photos.DownloadName(productId, fileName) : null);
});
// Photos and voice notes sent with chat questions, for the chat's own screens. The store only hands back names it made.
app.MapGet("/chat-attachments/{name}", (string name, ChatAttachmentStore attachments, HttpContext http) =>
{
    if (attachments.PathOf(name) is not { } path)
    {
        return Results.NotFound();
    }

    http.Response.Headers.CacheControl = "private, no-store";
    return Results.File(path, ChatAttachmentStore.ContentType(path), enableRangeProcessing: true);
});
// Posters' artwork, from the data folder. The store only hands back names it made.
app.MapGet("/poster-art/{id}/{fileName}", (string id, string fileName, PosterStore posters, HttpContext http) =>
{
    if (posters.ArtworkPath(id, fileName) is not { } path)
    {
        return Results.NotFound();
    }

    http.Response.Headers.CacheControl = "private, max-age=31536000, immutable";
    return Results.File(path, "image/png");
});
// Creatives' pictures, the pictures added to take their look from, their exports and the shop's logo, from the data
// folder. The store only hands back names it made.
app.MapGet("/creative-files/{id}/picture/{number:int}", (string id, int number, CreativeStore creatives, HttpContext http) =>
{
    if (creatives.ResultPath(id, number) is not { } path)
    {
        return Results.NotFound();
    }

    http.Response.Headers.CacheControl = "private, no-cache";
    return Results.File(path, "image/png");
});
app.MapGet("/creative-files/{id}/asset/{name}", (string id, string name, CreativeStore creatives, HttpContext http) =>
{
    if (creatives.AssetPath(id, name) is not { } path)
    {
        return Results.NotFound();
    }

    http.Response.Headers.CacheControl = "private, max-age=31536000, immutable";
    return Results.File(path, ChatAttachmentStore.ContentType(path));
});
app.MapGet("/creative-files/{id}/export/{name}", (string id, string name, CreativeStore creatives, HttpContext http) =>
{
    if (creatives.ExportPath(id, name) is not { } path)
    {
        return Results.NotFound();
    }

    http.Response.Headers.CacheControl = "private, no-cache";
    return Results.File(path, "image/png", name);
});
app.MapGet("/creative-files/brand/{name}", (string name, CreativeStore creatives, HttpContext http) =>
{
    if (creatives.LogoPath(name) is not { } path)
    {
        return Results.NotFound();
    }

    http.Response.Headers.CacheControl = "private, max-age=31536000, immutable";
    return Results.File(path, ChatAttachmentStore.ContentType(path));
});
// Every bill a search on the Bills page finds, as a spreadsheet. Read straight from the POS, a few thousand at a time.
app.MapGet("/bills.csv", async (string? q, string? from, string? to, bool? owed, IInvoiceRepository invoices, HttpContext http, CancellationToken ct) =>
{
    var query = BillLinks.Parse(q, from, to, owed);
    http.Response.ContentType = "text/csv; charset=utf-8";
    http.Response.Headers.CacheControl = "no-store";
    var disposition = new ContentDispositionHeaderValue("attachment");
    disposition.SetHttpFileName(BillCsv.FileName(query));
    http.Response.Headers.ContentDisposition = disposition.ToString();
    await using var writer = new StreamWriter(http.Response.Body, BillCsv.Encoding, bufferSize: 64 * 1024);
    await writer.WriteLineAsync(BillCsv.Header);
    await foreach (var bill in invoices.AllAsync(query, ct))
    {
        await writer.WriteLineAsync(BillCsv.Row(bill));
    }
});
// The owner view's Supabase script, which Settings opens for the owner to run in the project.
app.MapOwnerViewScript();
app.MapGoogleLens();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
