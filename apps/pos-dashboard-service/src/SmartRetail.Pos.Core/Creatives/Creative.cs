namespace SmartRetail.Pos.Core.Creatives;

/// <summary>A creative's shape and where it is used. The picture is exported at exactly this size.</summary>
public sealed record CreativeFormat(string Id, string Name, string Use, int Width, int Height)
{
    public static CreativeFormat Square { get; } = new("square", "Square post", "Instagram, Facebook and WhatsApp posts", 1080, 1080);

    public static CreativeFormat Portrait { get; } = new("portrait", "Portrait post", "Instagram and Facebook feeds", 1080, 1350);

    public static CreativeFormat Story { get; } = new("story", "Story", "Instagram and WhatsApp stories and status", 1080, 1920);

    public static CreativeFormat Banner { get; } = new("banner", "Wide banner", "Facebook, the shop's website and YouTube", 1200, 628);

    public static CreativeFormat Poster { get; } = new("a4", "A4 poster", "printing for the shop (300 dots an inch)", 2480, 3508);

    public static IReadOnlyList<CreativeFormat> All { get; } = [Square, Portrait, Story, Banner, Poster];

    public static CreativeFormat Find(string? id) => All.FirstOrDefault(format => format.Id == id) ?? Square;

    /// <summary>E.g. "1080 × 1080 px".</summary>
    public string Size => $"{Width} × {Height} px";
}

/// <summary>The look the AI designs in; the owner's own instructions come on top.</summary>
public sealed record CreativeStyle(string Id, string Name, string Brief)
{
    public static CreativeStyle Clean { get; } = new("clean", "Clean and modern", "clean and modern, with plenty of space, one bold accent colour and crisp product shots");

    public static CreativeStyle Festive { get; } = new("festive", "Festive", "festive, for an Indian festival: rich colours, marigolds, diyas and warm lights");

    public static CreativeStyle Sale { get; } = new("sale", "Big sale", "a bold sale: energetic colours, strong shapes and big, confident type");

    public static CreativeStyle Premium { get; } = new("premium", "Premium", "premium and elegant: deep tones, soft light and refined type");

    public static CreativeStyle Fresh { get; } = new("fresh", "Fresh and natural", "fresh and natural: greens, daylight and natural textures");

    public static CreativeStyle Playful { get; } = new("playful", "Playful", "playful and bright: cheerful colours and rounded shapes, fun for families");

    public static IReadOnlyList<CreativeStyle> All { get; } = [Clean, Festive, Sale, Premium, Fresh, Playful];

    public static CreativeStyle Find(string? id) => All.FirstOrDefault(style => style.Id == id) ?? Clean;
}

/// <summary>A product in a creative, and the offer the owner chose for it (none by default). Its price is always the POS's.</summary>
public sealed record CreativeItem(int ProductId, decimal? Offer = null);

/// <summary>What the owner asks for. Each picture keeps the brief it was made from.</summary>
public sealed record CreativeBrief
{
    public const int MaxProducts = 4;

    public const int MaxReferences = 2;

    public string Format { get; init; } = CreativeFormat.Square.Id;

    public string Style { get; init; } = CreativeStyle.Clean.Id;

    public string Headline { get; init; } = "";

    public string Subtitle { get; init; } = "";

    public string CallToAction { get; init; } = "";

    public string SmallPrint { get; init; } = "";

    public string Background { get; init; } = "";

    /// <summary>Anything else the owner asks the AI for.</summary>
    public string Instructions { get; init; } = "";

    public IReadOnlyList<CreativeItem> Products { get; init; } = [];

    /// <summary>Pictures the owner added to take the look from: file names in the creative's assets folder.</summary>
    public IReadOnlyList<string> References { get; init; } = [];

    /// <summary>The app puts each product's price on the picture.</summary>
    public bool ShowPrices { get; init; } = true;
}

/// <summary>Where a price tag's top-left corner is, as shares (0 to 1) of the picture's width and height.</summary>
public sealed record TagPlace(double X, double Y);

/// <summary>One picture made for a creative: from its brief, or a change to an earlier picture.</summary>
public sealed record CreativeGeneration
{
    public int Number { get; init; }

    /// <summary>The picture this one changes; null for one made from the brief.</summary>
    public int? Parent { get; init; }

    /// <summary>What the owner asked to change.</summary>
    public string Change { get; init; } = "";

    public CreativeBrief Brief { get; init; } = new();

    public DateTime Started { get; init; }

    /// <summary>When it was made or failed; null while it is being made.</summary>
    public DateTime? Finished { get; init; }

    public bool HasImage { get; init; }

    public string? Problem { get; init; }

    /// <summary>Which AI made it, e.g. "Codex CLI (OpenAI)".</summary>
    public string By { get; init; } = "";

    /// <summary>What the AI says it made.</summary>
    public string Notes { get; init; } = "";

    public double Seconds { get; init; }

    /// <summary>Codex's usage limit was reached while this picture was being made: it waits for the limit to lift and is made then,
    /// also after the app has been closed and opened again.</summary>
    public bool WaitingForLimit { get; init; }

    /// <summary>Each price tag's place, in the order of the brief's products: first where the AI left room, then where
    /// staff moved it.</summary>
    public IReadOnlyList<TagPlace> Tags { get; init; } = [];

    public bool IsMaking => Finished is null;
}

/// <summary>A creative: the owner's brief and every picture made for it, kept in the data folder.</summary>
public sealed record CreativeProject
{
    public string Id { get; init; } = "";

    public string Title { get; init; } = "";

    public DateTime Created { get; init; }

    public DateTime Updated { get; init; }

    public CreativeBrief Brief { get; init; } = new();

    public IReadOnlyList<CreativeGeneration> Generations { get; init; } = [];

    /// <summary>The picture the owner chose to use; exports use it.</summary>
    public int? Chosen { get; init; }

    public CreativeGeneration? Generation(int number) => Generations.FirstOrDefault(generation => generation.Number == number);

    public int NextNumber => Generations.Count == 0 ? 1 : Generations.Max(generation => generation.Number) + 1;

    public bool IsMaking => Generations.Any(generation => generation.IsMaking);

    /// <summary>The picture to show first: the chosen one, else the newest that was made.</summary>
    public CreativeGeneration? Shown =>
        (Chosen is { } chosen ? Generation(chosen) : null) is { HasImage: true } picked
            ? picked
            : Generations.Where(generation => generation.HasImage).MaxBy(generation => generation.Number);
}

/// <summary>The shop's brand, used by every creative: its name, colours, notes for the AI and logo.</summary>
public sealed record CreativeBrand
{
    public const int MaxColours = 2;

    public string ShopName { get; init; } = "";

    /// <summary>As #RRGGBB; the first colours the price tags.</summary>
    public IReadOnlyList<string> Colours { get; init; } = [];

    public string Notes { get; init; } = "";

    /// <summary>The logo's file name in the brand folder; null when there is none.</summary>
    public string? Logo { get; init; }
}
