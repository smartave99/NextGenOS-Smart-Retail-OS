using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Catalog;

/// <summary>Customers, guests, members, clients, suppliers and staff: everybody the shop deals with, in one list with a kind.</summary>
public sealed class PartyService(HubDb db, ShopContextProvider shop, IClock clock, Access access)
{
    private const string Columns = "id, kind, code, name, phone, email, address, tax_id, region, member_type, price_level, credit_limit_minor, terms_days, card_barcode, notes, active";

    private static Party Map(SqliteDataReader r) => new(
        r.Int("id"), r.Text("kind"), r.TextOrNull("code"), r.Text("name"), r.TextOrNull("phone"), r.TextOrNull("email"), r.TextOrNull("address"),
        r.TextOrNull("tax_id"), r.TextOrNull("region"), r.TextOrNull("member_type"), r.Text("price_level"), r.Int("credit_limit_minor"),
        (int)r.Int("terms_days"), r.TextOrNull("card_barcode"), r.TextOrNull("notes"), r.Flag("active"));

    public Party Create(PartyInput input)
    {
        access.Require(Perm.Parties);
        var id = db.InTransaction((c, t) => Create(c, t, input));
        return Get(id)!;
    }

    /// <summary>Adds a person inside the caller's transaction (so that a bigger action, such as moving a shop across from an older system, is all or nothing). Returns the new id.</summary>
    public long Create(SqliteConnection connection, SqliteTransaction transaction, PartyInput input)
    {
        Validate(input);
        try
        {
            return HubDb.Insert(connection,
                "INSERT INTO parties(kind, code, name, phone, email, address, tax_id, region, member_type, price_level, credit_limit_minor, terms_days, card_barcode, notes, created_at) " +
                "VALUES ($kind, $code, $name, $phone, $email, $address, $tax, $region, $mt, $pl, $cl, $td, $card, $notes, $at)", transaction,
                ("$kind", input.Kind), ("$code", Blank(input.Code)), ("$name", input.Name.Trim()), ("$phone", Blank(input.Phone)), ("$email", Blank(input.Email)),
                ("$address", Blank(input.Address)), ("$tax", Blank(input.TaxId)), ("$region", Blank(input.Region)), ("$mt", Blank(input.MemberType)),
                ("$pl", input.PriceLevel), ("$cl", input.CreditLimitMinor), ("$td", input.TermsDays), ("$card", Blank(input.CardBarcode)), ("$notes", Blank(input.Notes)),
                ("$at", Iso.Text(clock.UtcNow)));
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
        {
            throw new HubException("duplicate-card", "That card number is already on another record.");
        }
    }

    public Party Update(long id, PartyInput input)
    {
        access.Require(Perm.Parties);
        Validate(input);
        try
        {
            var changed = db.InTransaction((c, t) => HubDb.Exec(c,
                "UPDATE parties SET kind=$kind, code=$code, name=$name, phone=$phone, email=$email, address=$address, tax_id=$tax, region=$region, member_type=$mt, " +
                "price_level=$pl, credit_limit_minor=$cl, terms_days=$td, card_barcode=$card, notes=$notes WHERE id=$id", t,
                ("$id", id), ("$kind", input.Kind), ("$code", Blank(input.Code)), ("$name", input.Name.Trim()), ("$phone", Blank(input.Phone)), ("$email", Blank(input.Email)),
                ("$address", Blank(input.Address)), ("$tax", Blank(input.TaxId)), ("$region", Blank(input.Region)), ("$mt", Blank(input.MemberType)), ("$pl", input.PriceLevel),
                ("$cl", input.CreditLimitMinor), ("$td", input.TermsDays), ("$card", Blank(input.CardBarcode)), ("$notes", Blank(input.Notes))));
            if (changed == 0) throw new HubException("not-found", "That record was not found.");
            return Get(id)!;
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
        {
            throw new HubException("duplicate-card", "That card number is already on another record.");
        }
    }

    public Party? Get(long id) => db.QueryOne($"SELECT {Columns} FROM parties WHERE id = $id", Map, ("$id", id));

    public Party? FindByCard(string barcode) => db.QueryOne($"SELECT {Columns} FROM parties WHERE card_barcode = $b AND active = 1", Map, ("$b", barcode.Trim()));

    /// <summary>Everybody of a kind (or of every kind), matching a piece of the name, phone, code or card; active ones first.</summary>
    public IReadOnlyList<Party> Search(string? kind = null, string? text = null, int limit = 50, bool includeInactive = false)
    {
        var like = "%" + (text ?? "").Trim().Replace("%", "\\%").Replace("_", "\\_") + "%";
        return db.Query(
            $"SELECT {Columns} FROM parties WHERE ($kind IS NULL OR kind = $kind) AND ($all = 1 OR active = 1) " +
            "AND ($t = '' OR name LIKE $like ESCAPE '\\' OR phone LIKE $like ESCAPE '\\' OR code LIKE $like ESCAPE '\\' OR card_barcode LIKE $like ESCAPE '\\') " +
            "ORDER BY active DESC, name COLLATE NOCASE LIMIT $limit", Map,
            ("$kind", kind), ("$all", includeInactive ? 1 : 0), ("$t", (text ?? "").Trim()), ("$like", like), ("$limit", limit));
    }

    public void SetActive(long id, bool active)
    {
        access.Require(Perm.Parties);
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE parties SET active = $a WHERE id = $id", t, ("$a", active ? 1 : 0), ("$id", id)));
    }

    private void Validate(PartyInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Name)) throw new HubException("name-missing", "Please give a name.");
        if (input.Name.Length > 120) throw new HubException("name-long", "That name is too long.");
        var allowed = shop.Current.Industry.PartyKinds.Select(k => k.Id).Append("staff").Append("customer").Append("supplier").Distinct().ToList();
        if (!allowed.Contains(input.Kind)) throw new HubException("kind", $"\"{input.Kind}\" is not a kind of record this business keeps.");
        if (input.CreditLimitMinor < 0) throw new HubException("credit-limit", "A credit limit cannot be negative.");
        if (input.TermsDays is < 0 or > 365) throw new HubException("terms", "Payment terms must be between 0 and 365 days.");
        if (input.PriceLevel is not ("retail" or "trade")) throw new HubException("price-level", "Price level must be retail or trade.");
        if (!string.IsNullOrWhiteSpace(input.Email) && !input.Email.Contains('@')) throw new HubException("email", "That e-mail address does not look right.");
    }

    private static string? Blank(string? text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();
}
