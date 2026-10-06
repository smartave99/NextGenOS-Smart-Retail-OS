using System.Text.RegularExpressions;
using NextGenOS.Hub.Ai;

namespace NextGenOS.Hub.Ontology;

/// <summary>Where a kind of thing lives: in a record the shop already has (read in place, never copied), or only in the business map.</summary>
public static class EntityKind
{
    public const string Mapped = "mapped";
    public const string Native = "native";
}

/// <summary>The built-in kinds of thing. Names are the part before the colon of a reference: "product:12", "zone:aisle-3".</summary>
public static class EntityType
{
    // mapped: records the shop already has
    public const string Product = "product";
    public const string Party = "party";
    public const string User = "user";
    public const string Document = "document";
    public const string Payment = "payment";
    public const string Table = "table";
    public const string Project = "project";

    // native: only in the business map
    public const string Site = "site";
    public const string Zone = "zone";
    public const string Shelf = "shelf";
    public const string Device = "device";
}

/// <summary>The built-in kinds of connection.</summary>
public static class RelationType
{
    // stored
    public const string PartOf = "part_of";
    public const string LocatedIn = "located_in";
    public const string Observes = "observes";
    public const string StockedOn = "stocked_on";
    public const string SuppliedBy = "supplied_by";

    // derived from the shop's own records
    public const string IssuedTo = "issued_to";
    public const string HandledBy = "handled_by";
    public const string Contains = "contains";
    public const string Settles = "settles";
    public const string TakenBy = "taken_by";
    public const string SeatedAt = "seated_at";
    public const string ForProject = "for_project";
    public const string ForClient = "for_client";
    public const string Corrects = "corrects";
}

public sealed record EntityTypeDefinition(string Name, string Label, string Kind, string DataClass, bool Builtin);

public sealed record RelationTypeDefinition(string Name, string Label, IReadOnlyList<string> FromTypes, IReadOnlyList<string> ToTypes, bool Derived, bool Builtin);

/// <summary>A reference to a thing: its kind and its key, written "kind:key" ("product:12", "zone:aisle-3"). This is also how events name things.</summary>
public readonly record struct ThingRef(string Type, string Key)
{
    private static readonly Regex Pattern = new(@"^(?<type>[a-z][a-z0-9_]{0,39}):(?<key>[A-Za-z0-9][A-Za-z0-9._\-]{0,79})$", RegexOptions.CultureInvariant | RegexOptions.Compiled, TimeSpan.FromMilliseconds(250));

    public override string ToString() => Type + ":" + Key;

    public static bool TryParse(string? text, out ThingRef thing)
    {
        thing = default;
        var m = Pattern.Match((text ?? "").Trim());
        if (!m.Success) return false;
        thing = new ThingRef(m.Groups["type"].Value, m.Groups["key"].Value);
        return true;
    }

    public static ThingRef Parse(string? text) =>
        TryParse(text, out var thing) ? thing : throw new HubException("bad-ref", "A thing is named like 'zone:aisle-3' or 'product:12': a kind, a colon, and a short key with no spaces.");
}

/// <summary>What the business map knows out of the box. Written to the database the first time the map is used, so that it is data like anything else and the owner can add to it.</summary>
public static class BuiltIn
{
    public static readonly IReadOnlyList<EntityTypeDefinition> EntityTypes = new EntityTypeDefinition[]
    {
        new(EntityType.Product, "Product or service", EntityKind.Mapped, DataClass.Internal, true),
        new(EntityType.Party, "Customer, supplier or other party", EntityKind.Mapped, DataClass.Personal, true),
        new(EntityType.User, "Person who works here (signs in)", EntityKind.Mapped, DataClass.Personal, true),
        new(EntityType.Document, "Bill, order, quote or other document", EntityKind.Mapped, DataClass.Financial, true),
        new(EntityType.Payment, "Payment", EntityKind.Mapped, DataClass.Financial, true),
        new(EntityType.Table, "Restaurant table", EntityKind.Mapped, DataClass.Internal, true),
        new(EntityType.Project, "Project", EntityKind.Mapped, DataClass.Confidential, true),
        new(EntityType.Site, "Shop or site", EntityKind.Native, DataClass.Internal, true),
        new(EntityType.Zone, "Zone or area", EntityKind.Native, DataClass.Internal, true),
        new(EntityType.Shelf, "Shelf or place for stock", EntityKind.Native, DataClass.Internal, true),
        new(EntityType.Device, "Device (camera, sensor, scale, printer)", EntityKind.Native, DataClass.Internal, true),
    };

    public static readonly IReadOnlyList<RelationTypeDefinition> RelationTypes = new RelationTypeDefinition[]
    {
        // stored
        new(RelationType.PartOf, "is part of", [EntityType.Zone, EntityType.Site], [EntityType.Site, EntityType.Zone], false, true),
        new(RelationType.LocatedIn, "is in", [EntityType.Shelf, EntityType.Device, EntityType.Table], [EntityType.Zone, EntityType.Site], false, true),
        new(RelationType.Observes, "watches", [EntityType.Device], [EntityType.Zone, EntityType.Shelf, EntityType.Table], false, true),
        new(RelationType.StockedOn, "is kept on", [EntityType.Product], [EntityType.Shelf, EntityType.Zone], false, true),
        new(RelationType.SuppliedBy, "is supplied by", [EntityType.Product], [EntityType.Party], false, true),
        // derived from the shop's own records
        new(RelationType.IssuedTo, "was issued to", [EntityType.Document], [EntityType.Party], true, true),
        new(RelationType.HandledBy, "was handled by", [EntityType.Document], [EntityType.User], true, true),
        new(RelationType.Contains, "has a line for", [EntityType.Document], [EntityType.Product], true, true),
        new(RelationType.Settles, "pays", [EntityType.Payment], [EntityType.Document], true, true),
        new(RelationType.TakenBy, "was taken by", [EntityType.Payment], [EntityType.User], true, true),
        new(RelationType.SeatedAt, "is at", [EntityType.Document], [EntityType.Table], true, true),
        new(RelationType.ForProject, "belongs to", [EntityType.Document], [EntityType.Project], true, true),
        new(RelationType.ForClient, "is for", [EntityType.Project], [EntityType.Party], true, true),
        new(RelationType.Corrects, "corrects", [EntityType.Document], [EntityType.Document], true, true),
    };
}

/// <summary>How a kind of connection is worked out from the shop's own records. Each query takes <c>$id</c> and returns ids; they are read-only and capped.</summary>
public sealed record DerivedRule(string Relation, string FromType, string ToType, string OutgoingSql, string IncomingSql);

public static class DerivedRules
{
    public const int Cap = 200;

    public static readonly IReadOnlyList<DerivedRule> All = new DerivedRule[]
    {
        new(RelationType.IssuedTo, EntityType.Document, EntityType.Party,
            "SELECT party_id FROM documents WHERE id = $id AND party_id IS NOT NULL",
            "SELECT id FROM documents WHERE party_id = $id ORDER BY id DESC LIMIT " + Cap),
        new(RelationType.HandledBy, EntityType.Document, EntityType.User,
            "SELECT user_id FROM documents WHERE id = $id AND user_id IS NOT NULL",
            "SELECT id FROM documents WHERE user_id = $id ORDER BY id DESC LIMIT " + Cap),
        new(RelationType.Contains, EntityType.Document, EntityType.Product,
            "SELECT DISTINCT item_id FROM document_lines WHERE document_id = $id AND item_id IS NOT NULL ORDER BY item_id LIMIT " + Cap,
            "SELECT DISTINCT document_id FROM document_lines WHERE item_id = $id ORDER BY document_id DESC LIMIT " + Cap),
        new(RelationType.Settles, EntityType.Payment, EntityType.Document,
            "SELECT document_id FROM payments WHERE id = $id AND document_id IS NOT NULL",
            "SELECT id FROM payments WHERE document_id = $id ORDER BY id LIMIT " + Cap),
        new(RelationType.TakenBy, EntityType.Payment, EntityType.User,
            "SELECT user_id FROM payments WHERE id = $id AND user_id IS NOT NULL",
            "SELECT id FROM payments WHERE user_id = $id ORDER BY id DESC LIMIT " + Cap),
        new(RelationType.SeatedAt, EntityType.Document, EntityType.Table,
            "SELECT table_id FROM documents WHERE id = $id AND table_id IS NOT NULL",
            "SELECT id FROM documents WHERE table_id = $id ORDER BY id DESC LIMIT " + Cap),
        new(RelationType.ForProject, EntityType.Document, EntityType.Project,
            "SELECT project_id FROM documents WHERE id = $id AND project_id IS NOT NULL",
            "SELECT id FROM documents WHERE project_id = $id ORDER BY id DESC LIMIT " + Cap),
        new(RelationType.ForClient, EntityType.Project, EntityType.Party,
            "SELECT party_id FROM projects WHERE id = $id",
            "SELECT id FROM projects WHERE party_id = $id ORDER BY id DESC LIMIT " + Cap),
        new(RelationType.Corrects, EntityType.Document, EntityType.Document,
            "SELECT ref_document_id FROM documents WHERE id = $id AND ref_document_id IS NOT NULL",
            "SELECT id FROM documents WHERE ref_document_id = $id ORDER BY id DESC LIMIT " + Cap),
    };
}

/// <summary>How to look up a record the shop already has: its name for a person, and whether it exists. Read-only.</summary>
public sealed record MappedSource(string Type, string LabelSql, string AttributesSql);

public static class MappedSources
{
    public static readonly IReadOnlyList<MappedSource> All = new MappedSource[]
    {
        new(EntityType.Product, "SELECT name FROM items WHERE id = $id", "SELECT json_object('kind', kind, 'unit', unit, 'category', category, 'active', active) FROM items WHERE id = $id"),
        new(EntityType.Party, "SELECT name FROM parties WHERE id = $id", "SELECT json_object('kind', kind, 'active', active) FROM parties WHERE id = $id"),
        new(EntityType.User, "SELECT display_name FROM users WHERE id = $id", "SELECT json_object('role', role, 'active', active) FROM users WHERE id = $id"),
        new(EntityType.Document, "SELECT COALESCE(number, type || ' #' || id) FROM documents WHERE id = $id", "SELECT json_object('type', type, 'status', status) FROM documents WHERE id = $id"),
        new(EntityType.Payment, "SELECT method || ' payment #' || id FROM payments WHERE id = $id", "SELECT json_object('method', method, 'kind', kind) FROM payments WHERE id = $id"),
        new(EntityType.Table, "SELECT name FROM tables WHERE id = $id", "SELECT json_object('seats', seats, 'zone', zone, 'active', active) FROM tables WHERE id = $id"),
        new(EntityType.Project, "SELECT name FROM projects WHERE id = $id", "SELECT json_object('code', code, 'status', status) FROM projects WHERE id = $id"),
    };
}
