using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Ontology;

/// <summary>
/// A thing the business map knows, as a person would describe it. <see cref="Exists"/> is false when a record the shop had has been removed since. <see cref="AsOf"/> is the moment it was read
/// and <see cref="Origin"/> says where it came from: a record the shop already keeps ("shop record", read live, the source of truth) or something kept only in the map ("business map").
/// </summary>
public sealed record ThingView(ThingRef Ref, string Label, string Kind, string DataClass, bool Exists, bool Retired, string? AttributesJson, DateTimeOffset? AsOf = null, string? Origin = null);

/// <summary>One connection. A derived one (<see cref="Derived"/>) is worked out from the shop's own records and has no id; a stored one has the day it began and, if it has ended, the day it did.</summary>
public sealed record Link(long? Id, string Relation, string RelationLabel, ThingRef From, ThingRef To, bool Derived, DateTimeOffset? Since, DateTimeOffset? Until, string? AttributesJson, string? Source);

/// <summary>Something wrong with the map that a person should look at.</summary>
public sealed record MapProblem(string What, long? RelationshipId);

/// <summary>
/// The business map: the kinds of thing in the business (products, people, bills, payments, places, shelves, devices) and the connections between them, as data. The shop's own
/// records are read in place and never copied; only places and devices, which have no table of their own, and the connections the shop's records do not already hold, are kept here.
/// Connections that the shop's records already imply (a payment settles a bill, a bill has a line for a product) are worked out when asked and never stored twice.
/// Reading needs nothing; adding needs the owner's switch "Business map" and the licence's "ai" part.
/// </summary>
public sealed partial class OntologyService(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    public const string Outgoing = "out";
    public const string Incoming = "in";
    public const string Both = "both";

    private readonly object _gate = new();
    private bool _ready;

    [GeneratedRegex(@"^[a-z][a-z0-9_]{1,39}$", RegexOptions.CultureInvariant)]
    private static partial Regex NamePattern();

    [GeneratedRegex(@"^[a-z0-9][a-z0-9._\-]{0,59}$", RegexOptions.CultureInvariant)]
    private static partial Regex KeyPattern();

    public bool Writable => flags.IsEnabled(FlagKey.BusinessOntology);

    // ---- the kinds ----------------------------------------------------------------------------------------------------------------

    public IReadOnlyList<EntityTypeDefinition> EntityTypes()
    {
        EnsureCatalogue();
        return db.Query("SELECT name, label, kind, data_class, builtin FROM ontology_entity_types WHERE tenant_id = $t AND site_id = $s ORDER BY builtin DESC, kind DESC, name",
            r => new EntityTypeDefinition(r.Text("name"), r.Text("label"), r.Text("kind"), r.Text("data_class"), r.Int("builtin") == 1), ("$t", Tenant), ("$s", Site));
    }

    public IReadOnlyList<RelationTypeDefinition> RelationTypes()
    {
        EnsureCatalogue();
        return db.Query("SELECT name, label, from_types, to_types, derived, builtin FROM ontology_relation_types WHERE tenant_id = $t AND site_id = $s ORDER BY builtin DESC, derived, name",
            r => new RelationTypeDefinition(r.Text("name"), r.Text("label"), r.Text("from_types").Split(',', StringSplitOptions.RemoveEmptyEntries), r.Text("to_types").Split(',', StringSplitOptions.RemoveEmptyEntries),
                r.Int("derived") == 1, r.Int("builtin") == 1), ("$t", Tenant), ("$s", Site));
    }

    /// <summary>A new kind of thing that exists only in the business map (a "loading bay", a "fridge").</summary>
    public EntityTypeDefinition AddEntityType(string name, string label, string dataClass, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        EnsureCatalogue();
        var key = (name ?? "").Trim();
        if (!NamePattern().IsMatch(key)) throw new HubException("bad-type", "A kind of thing is a short lower-case word, such as 'fridge' or 'loading_bay'.");
        var words = EventRules.Words(label, 60, "name") ?? throw new HubException("bad-label", "Give the kind of thing a name people can read.");
        if (dataClass is not (DataClass.Public or DataClass.Internal or DataClass.Confidential or DataClass.Personal))
            throw new HubException("bad-class", "A kind of thing may hold public, internal, confidential or personal information. Card details, biometric data and money records are not kept here.");
        if (EntityTypes().Any(t => t.Name == key)) throw new HubException("duplicate-type", "There is already a kind of thing called '" + key + "'.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "INSERT INTO ontology_entity_types(tenant_id, site_id, name, label, kind, data_class, builtin) VALUES ($t, $s, $n, $l, 'native', $d, 0)", t,
                ("$t", Tenant), ("$s", Site), ("$n", key), ("$l", words), ("$d", dataClass));
            audit.Log(c, t, userId, "map.type", "ontology_type", null, "new kind of thing: " + key);
        });
        return EntityTypes().Single(x => x.Name == key);
    }

    /// <summary>A new kind of connection between kinds of thing. It is stored (never worked out from the shop's records).</summary>
    public RelationTypeDefinition AddRelationType(string name, string label, IEnumerable<string> fromTypes, IEnumerable<string> toTypes, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var key = (name ?? "").Trim();
        if (!NamePattern().IsMatch(key)) throw new HubException("bad-type", "A kind of connection is a short lower-case word or two, such as 'faces' or 'next_to'.");
        var words = EventRules.Words(label, 60, "name") ?? throw new HubException("bad-label", "Give the kind of connection a name people can read.");
        var known = EntityTypes().Select(x => x.Name).ToHashSet();
        var from = fromTypes.Select(x => x.Trim()).Where(x => x.Length > 0).Distinct().ToList();
        var to = toTypes.Select(x => x.Trim()).Where(x => x.Length > 0).Distinct().ToList();
        if (from.Count == 0 || to.Count == 0) throw new HubException("bad-type", "Say which kinds of thing it joins.");
        if (from.Concat(to).FirstOrDefault(x => !known.Contains(x)) is { } unknown) throw new HubException("bad-type", "'" + unknown + "' is not a kind of thing the map knows.");
        if (RelationTypes().Any(r => r.Name == key)) throw new HubException("duplicate-type", "There is already a kind of connection called '" + key + "'.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "INSERT INTO ontology_relation_types(tenant_id, site_id, name, label, from_types, to_types, derived, builtin) VALUES ($t, $s, $n, $l, $f, $to, 0, 0)", t,
                ("$t", Tenant), ("$s", Site), ("$n", key), ("$l", words), ("$f", string.Join(',', from)), ("$to", string.Join(',', to)));
            audit.Log(c, t, userId, "map.type", "ontology_type", null, "new kind of connection: " + key);
        });
        return RelationTypes().Single(x => x.Name == key);
    }

    // ---- things that live only in the map -----------------------------------------------------------------------------------------------

    /// <summary>Adds a place or a device. The key is a short plain name; when none is given it is made from the name.</summary>
    public ThingView CreateThing(string type, string? key, string name, string? attributesJson, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var definition = EntityTypes().FirstOrDefault(x => x.Name == type) ?? throw new HubException("bad-type", "The map does not know a kind of thing called '" + type + "'.");
        if (definition.Kind != EntityKind.Native) throw new HubException("mapped-type", "A " + definition.Label.ToLowerInvariant() + " is a record the shop already has; it cannot be added here.");
        var words = EventRules.Words(name, 80, "name") ?? throw new HubException("bad-name", "Give it a name.");
        var theKey = string.IsNullOrWhiteSpace(key) ? Slug(words) : key.Trim().ToLowerInvariant();
        if (!KeyPattern().IsMatch(theKey)) throw new HubException("bad-key", "The short name must be letters, numbers, dots and dashes, with no spaces (for example 'aisle-3').");
        var attributes = EventRules.Json(attributesJson, "details");
        db.InTransaction((c, t) =>
        {
            if (HubDb.Scalar(c, "SELECT 1 FROM ontology_entities WHERE tenant_id = $t AND site_id = $s AND type = $ty AND key = $k", t, ("$t", Tenant), ("$s", Site), ("$ty", type), ("$k", theKey)) is not null)
                throw new HubException("duplicate-thing", "There is already a " + definition.Label.ToLowerInvariant() + " called '" + theKey + "'.");
            HubDb.Exec(c, "INSERT INTO ontology_entities(tenant_id, site_id, type, key, name, attributes, created_at, created_by) VALUES ($t, $s, $ty, $k, $n, $a, $at, $u)", t,
                ("$t", Tenant), ("$s", Site), ("$ty", type), ("$k", theKey), ("$n", words), ("$a", attributes), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId));
            audit.Log(c, t, userId, "map.add", "ontology_entity", null, type + ":" + theKey + " (" + words + ")");
        });
        return Find(new ThingRef(type, theKey))!;
    }

    public ThingView Rename(ThingRef thing, string name, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var words = EventRules.Words(name, 80, "name") ?? throw new HubException("bad-name", "Give it a name.");
        var changed = 0;
        db.InTransaction((c, t) =>
        {
            changed = HubDb.Exec(c, "UPDATE ontology_entities SET name = $n WHERE tenant_id = $t AND site_id = $s AND type = $ty AND key = $k AND retired_at IS NULL", t,
                ("$n", words), ("$t", Tenant), ("$s", Site), ("$ty", thing.Type), ("$k", thing.Key));
            if (changed > 0) audit.Log(c, t, userId, "map.rename", "ontology_entity", null, thing + " is now called " + words);
        });
        if (changed == 0) throw new HubException("no-thing", "That is not in the map, or it has been retired.");
        return Find(thing)!;
    }

    /// <summary>A place or device that is gone. It stays in the map, marked, with the history of its connections; every live connection to it ends now.</summary>
    public void Retire(ThingRef thing, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var now = Iso.Text(clock.UtcNow);
        db.InTransaction((c, t) =>
        {
            var n = HubDb.Exec(c, "UPDATE ontology_entities SET retired_at = $at WHERE tenant_id = $t AND site_id = $s AND type = $ty AND key = $k AND retired_at IS NULL", t,
                ("$at", now), ("$t", Tenant), ("$s", Site), ("$ty", thing.Type), ("$k", thing.Key));
            if (n == 0) throw new HubException("no-thing", "That is not in the map, or it has already been retired.");
            var ended = HubDb.Exec(c, "UPDATE ontology_relationships SET valid_to = $at, ended_by = $u WHERE tenant_id = $t AND site_id = $s AND valid_to IS NULL AND (from_ref = $r OR to_ref = $r)", t,
                ("$at", now), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$r", thing.ToString()));
            audit.Log(c, t, userId, "map.retire", "ontology_entity", null, thing + " retired; " + ended + " connections ended");
        });
    }

    /// <summary>The things of one kind, for the person asking: nothing at all when their role may not see that kind of thing.</summary>
    public IReadOnlyList<ThingView> Things(string type, bool includeRetired = false)
    {
        var sees = Seeing(access.Who());
        if (!sees(type)) return [];
        var rows = db.Query("SELECT key FROM ontology_entities WHERE tenant_id = $t AND site_id = $s AND type = $ty" + (includeRetired ? "" : " AND retired_at IS NULL") + " ORDER BY name, key",
            r => r.Text("key"), ("$t", Tenant), ("$s", Site), ("$ty", type));
        return rows.Select(k => Find(new ThingRef(type, k))).Where(x => x is not null).Select(x => x!).ToList();
    }

    // ---- who may see what (ONT-010) ---------------------------------------------------------------------------------------------------------

    /// <summary>
    /// A test of whether this person may see a kind of thing (<see cref="ReadPolicy"/>), remembered for the length of one question. A kind the map does not know is not seen by anyone
    /// but the program, so a made-up kind and a hidden one look the same.
    /// </summary>
    private Func<string, bool> Seeing(Actor who)
    {
        if (who.IsSystem) return _ => true;
        var types = EntityTypes().ToDictionary(t => t.Name, t => t.DataClass);
        var memo = new Dictionary<string, bool>();
        return type => memo.TryGetValue(type, out var known) ? known : memo[type] = types.TryGetValue(type, out var dataClass) && ReadPolicy.CanSee(who, type, dataClass);
    }

    // ---- looking a thing up -----------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// What a reference points at, or null when it points at nothing the person asking may see: a record that is not there, a kind the map does not know, and a kind this person's role may not
    /// see all answer the same way, so asking never shows that something exists.
    /// </summary>
    public ThingView? Resolve(ThingRef thing)
    {
        var sees = Seeing(access.Who());
        return sees(thing.Type) ? Find(thing) : null;
    }

    /// <summary>The same, with no check of who is asking: for the map's own commands (which check their own permission) and its own housekeeping. Never handed to a screen or an assistant.</summary>
    private ThingView? Find(ThingRef thing)
    {
        EnsureCatalogue();
        var now = clock.UtcNow;
        var type = db.QueryOne("SELECT name, label, kind, data_class, builtin FROM ontology_entity_types WHERE tenant_id = $t AND site_id = $s AND name = $n",
            r => new EntityTypeDefinition(r.Text("name"), r.Text("label"), r.Text("kind"), r.Text("data_class"), r.Int("builtin") == 1), ("$t", Tenant), ("$s", Site), ("$n", thing.Type));
        if (type is null) return null;
        if (type.Kind == EntityKind.Native)
        {
            return db.QueryOne("SELECT name, attributes, retired_at FROM ontology_entities WHERE tenant_id = $t AND site_id = $s AND type = $ty AND key = $k",
                r => new ThingView(thing, r.Text("name"), EntityKind.Native, type.DataClass, true, !r.IsDBNull(r.GetOrdinal("retired_at")), r.TextOrNull("attributes"), now, OriginMap),
                ("$t", Tenant), ("$s", Site), ("$ty", thing.Type), ("$k", thing.Key));
        }

        var source = MappedSources.All.FirstOrDefault(s => s.Type == thing.Type);
        if (source is null || !long.TryParse(thing.Key, NumberStyles.None, CultureInfo.InvariantCulture, out var id)) return null;
        var label = db.Scalar(source.LabelSql, ("$id", id));
        if (label is null) return null;   // the record is gone (or was never there)
        var attributes = db.Scalar(source.AttributesSql, ("$id", id));
        return new ThingView(thing, Convert.ToString(label, CultureInfo.InvariantCulture) ?? thing.ToString(), EntityKind.Mapped, type.DataClass, true, false, attributes is null ? null : Convert.ToString(attributes, CultureInfo.InvariantCulture), now, OriginShop);
    }

    public const string OriginShop = "shop record";
    public const string OriginMap = "business map";

    // ---- connections ---------------------------------------------------------------------------------------------------------------------

    public Link Relate(string relation, ThingRef from, ThingRef to, long? userId, string? attributesJson = null, string source = "person")
    {
        access.Require(Perm.Ai);
        RequireOn();
        if (source is not ("person" or "rule" or "system" or "import")) throw new HubException("bad-source", "Say who made the connection: a person, a rule, the program or an import.");
        var type = RelationTypes().FirstOrDefault(r => r.Name == relation) ?? throw new HubException("bad-type", "The map does not know a kind of connection called '" + relation + "'.");
        if (type.Derived) throw new HubException("derived-type", "'" + type.Label + "' is worked out from the shop's own records, so it is never added by hand.");
        if (!type.FromTypes.Contains(from.Type)) throw new HubException("bad-ends", "A " + from.Type + " cannot be the one that '" + type.Label + "' something (it joins " + string.Join(" or ", type.FromTypes) + " to " + string.Join(" or ", type.ToTypes) + ").");
        if (!type.ToTypes.Contains(to.Type)) throw new HubException("bad-ends", "A " + to.Type + " cannot be what something '" + type.Label + "' (it joins " + string.Join(" or ", type.FromTypes) + " to " + string.Join(" or ", type.ToTypes) + ").");
        if (from == to) throw new HubException("bad-ends", "A thing cannot be connected to itself.");
        foreach (var end in new[] { from, to })
        {
            var view = Find(end);
            if (view is null) throw new HubException("no-thing", end + " is not in the map or in the shop's records.");
            if (view.Retired) throw new HubException("retired-thing", end + " has been retired.");
        }

        var attributes = EventRules.Json(attributesJson, "details");
        if (relation == RelationType.PartOf && IsInside(from, to)) throw new HubException("loop", "That would put a place inside itself.");
        long id = 0;
        try
        {
            db.InTransaction((c, t) =>
            {
                id = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM ontology_relationships WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
                HubDb.Exec(c, "INSERT INTO ontology_relationships(tenant_id, site_id, id, type, from_ref, to_ref, attributes, source, valid_from, created_by) VALUES ($t, $s, $id, $ty, $f, $to, $a, $src, $at, $u)", t,
                    ("$t", Tenant), ("$s", Site), ("$id", id), ("$ty", relation), ("$f", from.ToString()), ("$to", to.ToString()), ("$a", attributes), ("$src", source), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId));
                audit.Log(c, t, userId, "map.connect", "ontology_relationship", id, from + " " + relation + " " + to);
            });
        }
        catch (SqliteException e) when (e.SqliteErrorCode == 19)
        {
            throw new HubException("duplicate-link", "They are already connected that way.");
        }

        return Stored(id)!;
    }

    /// <summary>Ends a connection. It stays in the history, with the day it ended.</summary>
    public void Unrelate(long id, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        db.InTransaction((c, t) =>
        {
            var link = HubDb.Query(c, "SELECT type, from_ref, to_ref FROM ontology_relationships WHERE tenant_id = $t AND site_id = $s AND id = $id AND valid_to IS NULL",
                r => (Type: r.Text("type"), From: r.Text("from_ref"), To: r.Text("to_ref")), t, ("$t", Tenant), ("$s", Site), ("$id", id)).FirstOrDefault();
            if (link.Type is null) throw new HubException("no-link", "That connection does not exist, or has already ended.");
            HubDb.Exec(c, "UPDATE ontology_relationships SET valid_to = $at, ended_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "map.disconnect", "ontology_relationship", id, link.From + " " + link.Type + " " + link.To);
        });
    }

    public Link? Stored(long id) => db.QueryOne(LinkSelect + " AND id = $id", MapLink, ("$t", Tenant), ("$s", Site), ("$id", id));

    /// <summary>
    /// What a thing is connected to, in both directions unless one is asked for: the stored connections that are live (or all of them, with their days) and those worked out from the shop's
    /// records. For the person asking: nothing when they may not see the thing itself, and no connection whose other end they may not see (so a cashier sees who a bill was issued to, but not
    /// which member of staff handled it).
    /// </summary>
    public IReadOnlyList<Link> Related(ThingRef thing, string direction = Both, string? relation = null, bool includeEnded = false)
    {
        if (direction is not (Outgoing or Incoming or Both)) throw new HubException("bad-direction", "Ask for what it is connected to ('out'), what is connected to it ('in'), or both.");
        var sees = Seeing(access.Who());
        if (!sees(thing.Type)) return [];
        var labels = RelationTypes().ToDictionary(r => r.Name, r => r.Label);
        var links = new List<Link>();
        var sql = LinkSelect + " AND (" + (direction == Incoming ? "to_ref = $r" : direction == Outgoing ? "from_ref = $r" : "from_ref = $r OR to_ref = $r") + ")"
            + (includeEnded ? "" : " AND valid_to IS NULL") + (relation is null ? "" : " AND type = $rel") + " ORDER BY id";
        var args = new List<(string, object?)> { ("$t", Tenant), ("$s", Site), ("$r", thing.ToString()) };
        if (relation is not null) args.Add(("$rel", relation));
        links.AddRange(db.Query(sql, MapLink, args.ToArray()));

        if (long.TryParse(thing.Key, NumberStyles.None, CultureInfo.InvariantCulture, out var id))
        {
            foreach (var rule in DerivedRules.All.Where(r => relation is null || r.Relation == relation))
            {
                if (direction != Incoming && rule.FromType == thing.Type)
                    foreach (var target in db.Query(rule.OutgoingSql, r => r.GetInt64(0), ("$id", id)))
                        links.Add(new Link(null, rule.Relation, labels.GetValueOrDefault(rule.Relation, rule.Relation), thing, new ThingRef(rule.ToType, target.ToString(CultureInfo.InvariantCulture)), true, null, null, null, OriginShop));
                if (direction != Outgoing && rule.ToType == thing.Type)
                    foreach (var source in db.Query(rule.IncomingSql, r => r.GetInt64(0), ("$id", id)))
                        links.Add(new Link(null, rule.Relation, labels.GetValueOrDefault(rule.Relation, rule.Relation), new ThingRef(rule.FromType, source.ToString(CultureInfo.InvariantCulture)), thing, true, null, null, null, OriginShop));
            }
        }

        return links.Where(l => sees(l.From.Type) && sees(l.To.Type)).Select(l => l with { RelationLabel = labels.GetValueOrDefault(l.Relation, l.Relation) }).ToList();
    }

    /// <summary>Everything the map holds that is no longer right: a live connection to a thing that has gone from the shop's records, or been retired.</summary>
    public IReadOnlyList<MapProblem> Check()
    {
        access.Require(Perm.Ai);
        var problems = new List<MapProblem>();
        foreach (var link in db.Query(LinkSelect + " AND valid_to IS NULL ORDER BY id", MapLink, ("$t", Tenant), ("$s", Site)))
            foreach (var end in new[] { link.From, link.To })
            {
                var view = Find(end);
                if (view is null) problems.Add(new MapProblem(end + " is in a connection (" + link.From + " " + link.Relation + " " + link.To + ") but is no longer there.", link.Id));
                else if (view.Retired) problems.Add(new MapProblem(end + " was retired but is still in a connection (" + link.From + " " + link.Relation + " " + link.To + ").", link.Id));
            }

        return problems;
    }

    /// <summary>The place a thing is in, and the place that is in, and so on up to the site: "Aisle 3, Back shop, Corner Mart".</summary>
    public IReadOnlyList<ThingView> Ancestors(ThingRef thing)
    {
        var path = new List<ThingView>();
        var seen = new HashSet<ThingRef> { thing };
        var current = thing;
        for (var step = 0; step < 20; step++)
        {
            var up = Related(current, Outgoing).FirstOrDefault(l => !l.Derived && (l.Relation == RelationType.PartOf || l.Relation == RelationType.LocatedIn));
            if (up is null || !seen.Add(up.To)) break;
            var view = Resolve(up.To);
            if (view is null) break;
            path.Add(view);
            current = up.To;
        }

        return path;
    }

    // ---- inside ---------------------------------------------------------------------------------------------------------------------------

    private bool IsInside(ThingRef thing, ThingRef candidateParent)
    {
        // "thing part_of candidateParent" would be a loop when candidateParent is already, further up, inside thing.
        var current = candidateParent;
        for (var step = 0; step < 50; step++)
        {
            if (current == thing) return true;
            var up = db.QueryOne("SELECT to_ref FROM ontology_relationships WHERE tenant_id = $t AND site_id = $s AND type = 'part_of' AND from_ref = $r AND valid_to IS NULL LIMIT 1",
                r => r.Text("to_ref"), ("$t", Tenant), ("$s", Site), ("$r", current.ToString()));
            if (up is null || !ThingRef.TryParse(up, out var parent)) return false;
            current = parent;
        }

        return true;   // a chain this long is a loop already
    }

    private void RequireOn()
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "The business map is not part of this shop's licence.");
        if (!flags.IsEnabled(FlagKey.BusinessOntology)) throw new HubException("map-off", "The business map is switched off, so nothing can be added to it.");
    }

    private void EnsureCatalogue()
    {
        if (_ready) return;
        lock (_gate)
        {
            if (_ready) return;
            db.InTransaction((c, t) =>
            {
                foreach (var type in BuiltIn.EntityTypes)
                    HubDb.Exec(c, "INSERT OR IGNORE INTO ontology_entity_types(tenant_id, site_id, name, label, kind, data_class, builtin) VALUES ($t, $s, $n, $l, $k, $d, 1)", t,
                        ("$t", Tenant), ("$s", Site), ("$n", type.Name), ("$l", type.Label), ("$k", type.Kind), ("$d", type.DataClass));
                foreach (var type in BuiltIn.RelationTypes)
                    HubDb.Exec(c, "INSERT OR IGNORE INTO ontology_relation_types(tenant_id, site_id, name, label, from_types, to_types, derived, builtin) VALUES ($t, $s, $n, $l, $f, $to, $d, 1)", t,
                        ("$t", Tenant), ("$s", Site), ("$n", type.Name), ("$l", type.Label), ("$f", string.Join(',', type.FromTypes)), ("$to", string.Join(',', type.ToTypes)), ("$d", type.Derived ? 1 : 0));
            });
            _ready = true;
        }
    }

    private static string Slug(string name)
    {
        var chars = name.ToLowerInvariant().Select(ch => char.IsAsciiLetterOrDigit(ch) ? ch : '-').ToArray();
        var slug = Regex.Replace(new string(chars), "-{2,}", "-").Trim('-');
        if (slug.Length == 0) throw new HubException("bad-name", "Give it a name with letters or numbers in it.");
        return slug.Length > 60 ? slug[..60].TrimEnd('-') : slug;
    }

    private const string LinkSelect = "SELECT id, type, from_ref, to_ref, attributes, source, valid_from, valid_to FROM ontology_relationships WHERE tenant_id = $t AND site_id = $s";

    private static Link MapLink(SqliteDataReader r) => new(r.Int("id"), r.Text("type"), r.Text("type"), ThingRef.Parse(r.Text("from_ref")), ThingRef.Parse(r.Text("to_ref")), false,
        r.Time("valid_from"), r.TimeOrNull("valid_to"), r.TextOrNull("attributes"), r.Text("source"));
}
