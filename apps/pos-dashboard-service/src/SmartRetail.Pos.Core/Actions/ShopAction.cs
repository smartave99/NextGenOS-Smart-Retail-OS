namespace SmartRetail.Pos.Core.Actions;

public enum ActionKind
{
    Advert,
    Offer,
    Display,
    NewProduct,
    PriceChange,
    Other,
}

public static class ActionKinds
{
    public static IReadOnlyList<ActionKind> All { get; } = Enum.GetValues<ActionKind>();

    public static string Name(this ActionKind kind) => kind switch
    {
        ActionKind.Advert => "Advertising",
        ActionKind.Offer => "Offer or discount",
        ActionKind.Display => "Display or placement",
        ActionKind.NewProduct => "New product",
        ActionKind.PriceChange => "Price change",
        _ => "Something else",
    };

    /// <summary>The kind for a word the AI or an older file used, e.g. "advert" or "new-product".</summary>
    public static ActionKind Parse(string? word) => (word ?? "").Trim().ToLowerInvariant().Replace("-", "").Replace(" ", "") switch
    {
        "advert" or "advertising" or "ad" or "ads" => ActionKind.Advert,
        "offer" or "discount" => ActionKind.Offer,
        "display" or "placement" => ActionKind.Display,
        "newproduct" or "product" => ActionKind.NewProduct,
        "price" or "pricechange" => ActionKind.PriceChange,
        _ => ActionKind.Other,
    };
}

/// <summary>
/// Something the shop did to sell more, as in the decision ledger: what, when, what it cost, and which products it
/// was for. The figures say later how it went (<see cref="ActionMeasure"/>), and the lesson can be kept in memory.
/// </summary>
public sealed record ShopAction
{
    public const int MaxTitle = 120;
    public const int MaxText = 300;

    public string Id { get; init; } = "";
    public string Title { get; init; } = "";
    public ActionKind Kind { get; init; }
    public DateOnly Start { get; init; }

    /// <summary>Its last day; null while it goes on.</summary>
    public DateOnly? End { get; init; }

    /// <summary>What it cost, in rupees; 0 when nothing or not known.</summary>
    public decimal Cost { get; init; }

    /// <summary>The products it was for; none for the whole shop.</summary>
    public IReadOnlyList<int> ProductIds { get; init; } = Array.Empty<int>();

    /// <summary>Their names when it was saved, to show.</summary>
    public IReadOnlyList<string> ProductNames { get; init; } = Array.Empty<string>();

    /// <summary>What the owner hoped it would change, e.g. "more bills from the market side".</summary>
    public string Expected { get; init; } = "";

    /// <summary>"Owner", or "Chat" when it was taken from a chat.</summary>
    public string Source { get; init; } = "Owner";

    public DateTime Added { get; init; }
    public bool Cancelled { get; init; }

    /// <summary>The lesson, once kept in memory.</summary>
    public string? Lesson { get; init; }

    /// <summary>For a new product, its test (<see cref="ProductTests"/>): judged by units sold on its review day rather
    /// than by sales against the days before; null for other actions, and for new products noted before tests.</summary>
    public ProductTest? Test { get; init; }

    public bool IsWholeShop => ProductIds.Count == 0;

    /// <summary>Why it cannot be saved, or null when it can.</summary>
    public string? Problem()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            return "Say what the shop did.";
        }

        if (Title.Trim().Length > MaxTitle)
        {
            return $"Keep what it was to under {MaxTitle} characters.";
        }

        if (End is { } end && end < Start)
        {
            return "It ends before it starts.";
        }

        if (Cost < 0)
        {
            return "The cost cannot be below zero.";
        }

        if (Expected.Length > MaxText)
        {
            return $"Keep what it should change to under {MaxText} characters.";
        }

        if (Test is not { } test)
        {
            return null;
        }

        if (Kind != ActionKind.NewProduct)
        {
            return "Only a new product is tested.";
        }

        return IsWholeShop ? "Choose the new product, so its sales can be counted."
            : ProductIds.Count > 1 ? "A test is for one new product: keep just that one, so its own units are judged."
            : test.Problem(Start);
    }
}
