namespace NextGenOS.Hub.Ai;

// The words the AI foundation stores and compares. They are plain strings (not enums) on purpose: they are written to the database and shown to people, the program's
// names are hidden in the shipped build (a renamed enum member would change what is stored), and a string survives a model, a provider or a version being replaced.

/// <summary>What kind of data a task handles. It decides where the task may run (see <see cref="Routing"/>).</summary>
public static class DataClass
{
    public const string Public = "PUBLIC";
    public const string Internal = "INTERNAL";
    public const string Confidential = "CONFIDENTIAL";
    public const string Personal = "PERSONAL";
    public const string Financial = "FINANCIAL";
    public const string Video = "VIDEO";
    public const string Audio = "AUDIO";
    public const string Biometric = "BIOMETRIC";
    public const string PaymentSensitive = "PAYMENT_SENSITIVE";

    public static readonly IReadOnlyList<string> All = new[] { Public, Internal, Confidential, Personal, Financial, Video, Audio, Biometric, PaymentSensitive };

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    /// <summary>Said in the words the owner reads.</summary>
    public static string Label(string value) => value switch
    {
        Public => "Public information",
        Internal => "Internal figures (for example anonymous totals)",
        Confidential => "Confidential business information",
        Personal => "Customers' and staff's personal data",
        Financial => "Financial records",
        Video => "Camera video and pictures",
        Audio => "Sound recordings",
        Biometric => "Biometric data (faces, fingerprints)",
        PaymentSensitive => "Card and payment details",
        _ => value,
    };
}

/// <summary>What an AI service is asked to do.</summary>
public static class AiTask
{
    public const string Generate = "generate";
    public const string Embed = "embed";
    public const string Vision = "vision";
    public const string Speech = "speech";
    public const string Ocr = "ocr";
    public const string Rerank = "rerank";
    public const string Detect = "detect";
    public const string Segment = "segment";
    public const string Track = "track";

    public static readonly IReadOnlyList<string> All = new[] { Generate, Embed, Vision, Speech, Ocr, Rerank, Detect, Segment, Track };

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    public static string Label(string value) => value switch
    {
        Generate => "Writing and answering", Embed => "Finding similar things (embeddings)", Vision => "Understanding pictures", Speech => "Understanding speech",
        Ocr => "Reading text in pictures", Rerank => "Ranking search results", Detect => "Finding objects in pictures", Segment => "Outlining objects in pictures",
        Track => "Following objects between pictures", _ => value,
    };
}

/// <summary>Where an AI service runs. The order here is the default order of preference.</summary>
public static class ProviderLocation
{
    public const string Local = "local";
    public const string LocalOptimized = "local-optimized";
    public const string Lan = "lan";
    public const string Cli = "cli";
    public const string Api = "api";

    /// <summary>Local first, then the local network, then the owner's own subscription tool, then the owner's own online account.</summary>
    public static readonly IReadOnlyList<string> DefaultOrder = new[] { Local, LocalOptimized, Lan, Cli, Api };

    public static bool IsKnown(string? value) => value is not null && DefaultOrder.Contains(value);

    /// <summary>True when the data stays on this computer.</summary>
    public static bool StaysOnThisComputer(string location) => location is Local or LocalOptimized;

    public static string Label(string value) => value switch
    {
        Local => "This computer", LocalOptimized => "This computer (optimised runtime)", Lan => "Another computer in the shop's network",
        Cli => "A tool the owner signed in to (command line)", Api => "An online service", _ => value,
    };
}

/// <summary>Where a model stands. A model is never used just because it is newer: it is tested, run beside the old one, compared, then promoted.</summary>
public static class ModelStatus
{
    public const string Candidate = "candidate";
    public const string Testing = "testing";
    public const string Shadow = "shadow";
    public const string Active = "active";
    public const string Deprecated = "deprecated";
    public const string RolledBack = "rolled-back";

    public static readonly IReadOnlyList<string> All = new[] { Candidate, Testing, Shadow, Active, Deprecated, RolledBack };

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    /// <summary>The moves that make sense: forwards through testing and shadow, back out of any stage, and a way to try a retired model again.</summary>
    public static bool CanMove(string from, string to) => (from, to) switch
    {
        (Candidate, Testing) or (Testing, Shadow) or (Shadow, Active) or (Testing, Active) => true,
        (Active, Deprecated) or (Active, RolledBack) or (Shadow, RolledBack) or (Testing, RolledBack) => true,
        (Candidate, Deprecated) or (Testing, Deprecated) or (Shadow, Deprecated) => true,
        (Deprecated, Candidate) or (RolledBack, Candidate) => true,
        _ => false,
    };

    public static string Label(string value) => value switch
    {
        Candidate => "Candidate", Testing => "Being tested", Shadow => "Running beside the active one", Active => "In use", Deprecated => "Retired", RolledBack => "Rolled back", _ => value,
    };
}

/// <summary>The switches for the major capabilities. All start off.</summary>
public static class FlagKey
{
    public const string AiAssistant = "ai_assistant";
    public const string CameraAnalytics = "camera_analytics";
    public const string LocalEmbeddings = "local_embeddings";
    public const string RemoteAi = "remote_ai";
    public const string BusinessOntology = "business_ontology";
    public const string EventEngine = "event_engine";
    public const string PredictiveInventory = "predictive_inventory";
    public const string AdvancedRules = "advanced_rules";

    public static readonly IReadOnlyList<string> All = new[] { AiAssistant, CameraAnalytics, LocalEmbeddings, RemoteAi, BusinessOntology, EventEngine, PredictiveInventory, AdvancedRules };

    public static string Label(string key) => key switch
    {
        AiAssistant => "Business assistant", CameraAnalytics => "Camera analytics", LocalEmbeddings => "Local search by meaning (embeddings)",
        RemoteAi => "Use online AI services", BusinessOntology => "Business map (things and how they relate)", EventEngine => "Business event history",
        PredictiveInventory => "Stock forecasts", AdvancedRules => "Advanced automatic rules", _ => key,
    };

    public static string Describe(string key) => key switch
    {
        AiAssistant => "Lets staff ask questions about the business in plain words. Needs a connected AI service.",
        CameraAnalytics => "Understands what cameras see (needs a capable computer). Raw video stays on this computer.",
        LocalEmbeddings => "Finds products, documents and notes by meaning, using a model on this computer.",
        RemoteAi => "Allows an online AI service to be used at all. Even then, only the kinds of data you allowed for that service leave this computer.",
        BusinessOntology => "Keeps a map of the business: products, shelves, devices, people and how they connect.",
        EventEngine => "Keeps a history of what happened in the business, with the reason the system believes it.",
        PredictiveInventory => "Forecasts which products will run out. Needs the event history.",
        AdvancedRules => "Automatic rules such as 'if a shelf is nearly empty and the back room is full, create a task'.",
        _ => "",
    };
}
