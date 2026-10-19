using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Ontology;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Knowledge;

/// <summary>
/// The owner's own notes (a supplier's terms, a way of doing things, a decision) kept as local knowledge that can be found again (Version 2, Phase 5, step 1). A note is kept in short pieces
/// in the shop's database. It is found by its words whatever AI is or is not there; when the owner has switched on "Search by meaning" and an AI service that may receive the note's kind of
/// information makes vectors for the pieces, the search also finds pieces by what they mean (a question about "cheap" finds a note that says "inexpensive").
/// <list type="bullet">
/// <item><b>AI is optional.</b> Searching never needs an AI service and never fails because one is missing: it says in plain words that it used words only, and why.</item>
/// <item><b>Privacy follows the note.</b> Every note has a kind of information chosen by the owner (<see cref="DataClass"/>); making its vectors goes through the same door as every AI work
/// (<see cref="AiGateway"/>: licence, switch, the privacy rules, the limits, the record of use), in that kind, so a note about people is never sent to an online service unless the owner allowed
/// that. Card and payment details and biometric data are never kept in a note.</item>
/// <item><b>What a person may read is what a person may search.</b> A result is shown only when the person asking may see that kind of information anywhere else in the shop
/// (<see cref="ReadPolicy"/>), so an assistant that uses this (Phase 6) can never tell what the person asking could not read.</item>
/// <item><b>Answers point at their source:</b> every hit carries the note's reference (<c>note:7</c>), its title and the piece that matched.</item>
/// </list>
/// Writing needs the AI helpers' permission and the switch (and the licence's AI part); looking and retiring never need the switch. Retiring a note deletes its text and its vectors.
/// </summary>
public sealed class KnowledgeService(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, AiGateway gateway, IVectorIndex index, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    public const string Note = "note";
    public const int MaxTitleChars = 120;
    public const int MaxTextChars = 20_000;
    public const int MaxNotes = 500;
    public const int MaxPieces = 20_000;
    public const int BatchSize = 16;
    public const int MaxBatchesPerPass = 25;
    public const int MaxQueryChars = 300;
    public const int MaxResults = 20;
    public const int ExcerptChars = 300;
    /// <summary>A vector that is less like the question than this is not counted as a match by meaning.</summary>
    public const double MinSimilarity = 0.2;
    private const double MeaningShare = 0.7;
    private const string FeatureName = "knowledge";

    private static readonly string[] Allowed = [DataClass.Public, DataClass.Internal, DataClass.Confidential, DataClass.Personal, DataClass.Financial];

    /// <summary>True while notes can be added and vectors made: the licence has the AI part and "Search by meaning" is on.</summary>
    public bool Recording => flags.IsEnabled(FlagKey.LocalEmbeddings);

    // ---- the notes ----------------------------------------------------------------------------------------------------------------

    public KnowledgeSource AddNote(string title, string text, string dataClass, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var made = Check(title, text, dataClass);
        var now = clock.UtcNow;
        long id = 0;
        db.InTransaction((c, t) =>
        {
            var active = Convert.ToInt64(HubDb.Scalar(c, "SELECT COUNT(*) FROM knowledge_sources WHERE tenant_id = $t AND site_id = $s AND retired_at IS NULL", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
            if (active >= MaxNotes) throw new HubException("too-many", "There are already " + MaxNotes + " notes. Retire one you no longer need first.");
            CheckRoom(c, t, made.Pieces.Count, 0);
            id = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM knowledge_sources WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
            HubDb.Exec(c,
                "INSERT INTO knowledge_sources(tenant_id, site_id, id, ref, kind, title, data_class, content_sha256, chars, created_at, created_by, updated_at, updated_by) " +
                "VALUES ($t, $s, $id, $ref, $k, $title, $dc, $sha, $chars, $at, $u, $at, $u)", t,
                ("$t", Tenant), ("$s", Site), ("$id", id), ("$ref", Note + ":" + id.ToString(CultureInfo.InvariantCulture)), ("$k", Note), ("$title", made.Title), ("$dc", made.DataClass), ("$sha", made.Sha),
                ("$chars", made.Text.Length), ("$at", Iso.Text(now)), ("$u", userId));
            InsertPieces(c, t, id, made.Pieces);
            audit.Log(c, t, userId, "knowledge.add", "knowledge_source", id, "'" + Shorten(made.Title, 60) + "' (" + made.DataClass + "), " + made.Pieces.Count + " piece(s)");
        });
        return Get(id)!;
    }

    /// <summary>Replaces a note's title, text and kind of information. Its old pieces and vectors are deleted; the new pieces wait for vectors.</summary>
    public KnowledgeSource UpdateNote(long id, string title, string text, string dataClass, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var made = Check(title, text, dataClass);
        var now = clock.UtcNow;
        db.InTransaction((c, t) =>
        {
            var retired = HubDb.Scalar(c, "SELECT retired_at IS NOT NULL FROM knowledge_sources WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id));
            if (retired is null) throw new HubException("no-note", "That note does not exist.");
            if (Convert.ToInt64(retired, CultureInfo.InvariantCulture) != 0) throw new HubException("retired", "That note was retired. Write a new one.");
            var kept = Convert.ToInt64(HubDb.Scalar(c, "SELECT COUNT(*) FROM knowledge_chunks WHERE tenant_id = $t AND site_id = $s AND source_id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id)), CultureInfo.InvariantCulture);
            CheckRoom(c, t, made.Pieces.Count, (int)kept);
            HubDb.Exec(c, "DELETE FROM knowledge_chunks WHERE tenant_id = $t AND site_id = $s AND source_id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id));
            HubDb.Exec(c,
                "UPDATE knowledge_sources SET title = $title, data_class = $dc, content_sha256 = $sha, chars = $chars, updated_at = $at, updated_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$title", made.Title), ("$dc", made.DataClass), ("$sha", made.Sha), ("$chars", made.Text.Length), ("$at", Iso.Text(now)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            InsertPieces(c, t, id, made.Pieces);
            audit.Log(c, t, userId, "knowledge.update", "knowledge_source", id, "'" + Shorten(made.Title, 60) + "' (" + made.DataClass + "), " + made.Pieces.Count + " piece(s)");
        });
        return Get(id)!;
    }

    /// <summary>Takes a note out of use for good: its text and vectors are deleted; the row that says it existed stays. Never needs the switch.</summary>
    public void RetireNote(long id, long? userId)
    {
        access.Require(Perm.Ai);
        db.InTransaction((c, t) =>
        {
            var retired = HubDb.Scalar(c, "SELECT retired_at IS NOT NULL FROM knowledge_sources WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id));
            if (retired is null) throw new HubException("no-note", "That note does not exist.");
            if (Convert.ToInt64(retired, CultureInfo.InvariantCulture) != 0) return;
            HubDb.Exec(c, "DELETE FROM knowledge_chunks WHERE tenant_id = $t AND site_id = $s AND source_id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", id));
            HubDb.Exec(c, "UPDATE knowledge_sources SET retired_at = $at, updated_at = $at, updated_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "knowledge.retire", "knowledge_source", id, "note retired; its text and vectors were deleted");
        });
    }

    public IReadOnlyList<KnowledgeSource> List(bool includeRetired = false)
    {
        access.Require(Perm.Ai);
        return db.Query(Select + " AND (s.retired_at IS NULL OR $all = 1) ORDER BY s.id", MapSource, ("$t", Tenant), ("$s", Site), ("$all", includeRetired ? 1 : 0));
    }

    public KnowledgeSource? Get(long id)
    {
        access.Require(Perm.Ai);
        return db.QueryOne(Select + " AND s.id = $id", MapSource, ("$t", Tenant), ("$s", Site), ("$id", id));
    }

    /// <summary>The text of a note, for the owner to edit. Only for the AI helpers' permission.</summary>
    public string? TextOf(long id)
    {
        access.Require(Perm.Ai);
        var pieces = db.Query("SELECT text FROM knowledge_chunks WHERE tenant_id = $t AND site_id = $s AND source_id = $id ORDER BY seq", r => r.Text("text"), ("$t", Tenant), ("$s", Site), ("$id", id));
        return pieces.Count == 0 ? null : string.Join("\n\n", pieces);
    }

    /// <summary>How many pieces of notes are waiting for a vector.</summary>
    public int Waiting()
    {
        access.Require(Perm.Ai);
        return PendingCount();
    }

    // ---- making vectors -------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Asks the AI services that may receive each note's kind of information for the vectors of the pieces that have none yet, a few at a time, up to <see cref="MaxBatchesPerPass"/> batches.
    /// A refusal, a service that does not answer or an answer that cannot be used stops the pass quietly and says why; the notes stay and are found by their words. Never throws for an AI problem.
    /// </summary>
    public async Task<PrepareResult> PrepareAsync(long? userId, CancellationToken cancel = default)
    {
        access.Require(Perm.Ai);
        if (!Recording) return new PrepareResult(0, PendingCount(), "Search by meaning is switched off (or not in the licence), so notes are found by their words only.");
        var prepared = 0;
        string? stopped = null;
        for (var batch = 0; batch < MaxBatchesPerPass; batch++)
        {
            var rows = db.Query(
                "SELECT c.source_id, c.seq, c.text, s.data_class FROM knowledge_chunks c JOIN knowledge_sources s ON s.tenant_id = c.tenant_id AND s.site_id = c.site_id AND s.id = c.source_id " +
                "WHERE c.tenant_id = $t AND c.site_id = $s AND c.vector IS NULL AND s.retired_at IS NULL ORDER BY s.data_class, c.source_id, c.seq LIMIT $n",
                r => (Source: r.GetInt64(0), Seq: r.GetInt32(1), Text: r.Text("text"), Class: r.Text("data_class")), ("$t", Tenant), ("$s", Site), ("$n", BatchSize));
            if (rows.Count == 0) break;
            var kind = rows[0].Class;   // one batch holds one kind of information, so that the privacy rules judge it as what it is
            var same = rows.Where(r => r.Class == kind).ToList();
            var answer = await gateway.EmbedAsync(new AiContext(FeatureName, kind, userId, FlagKey.LocalEmbeddings), new EmbeddingRequest(same.Select(r => r.Text).ToList()), cancel);
            if (!answer.Ok)
            {
                stopped = answer.Refusal ?? "No AI service answered.";
                break;
            }

            var done = answer.Value!;
            if (done.Vectors.Count != same.Count || done.Dimensions < 1 || done.Vectors.Any(v => v.Length != done.Dimensions))
            {
                stopped = "An AI service gave an answer that could not be used, so nothing from it was kept.";
                break;
            }

            try
            {
                for (var i = 0; i < same.Count; i++) index.Put(same[i].Source, same[i].Seq, done.Model, done.Vectors[i], clock.UtcNow);
                prepared += same.Count;
            }
            catch (HubException ex) when (ex.Code is "bad-vector" or "bad-model")
            {
                stopped = "An AI service gave a vector that could not be kept: " + ex.Message;
                break;
            }
            catch (HubException ex) when (ex.Code == "no-piece")
            {
                // A note was changed or retired while its vectors were being made: the pieces that are left are done in the next batch.
                prepared += 0;
            }
        }

        var waiting = PendingCount();
        return new PrepareResult(prepared, waiting, stopped ?? (waiting > 0 && prepared > 0 ? "More pieces are waiting: press the button again." : null));
    }

    /// <summary>Forgets every vector (before a different model is used), so that all pieces are prepared again. The words stay.</summary>
    public int ForgetVectors(long? userId)
    {
        access.Require(Perm.Ai);
        var n = index.Clear();
        if (n > 0) audit.Log(userId, "knowledge.clear", "knowledge_source", null, n + " vector(s) forgotten");
        return n;
    }

    // ---- looking ------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Finds pieces of notes for a question, best first, each with the note it comes from. Only notes of a kind the person asking may read anywhere else in the shop are looked at. Words always
    /// count; the meaning counts too when "Search by meaning" is on, vectors exist, and an AI service that may receive the question answers. Never fails for want of an AI service.
    /// </summary>
    public async Task<KnowledgeAnswer> SearchAsync(string query, int limit = 5, CancellationToken cancel = default)
    {
        var who = access.Who();
        var text = (query ?? "").Trim();
        if (text.Length == 0) throw new HubException("bad-query", "Write what to look for.");
        if (text.Length > MaxQueryChars) throw new HubException("bad-query", "What to look for is too long (at most " + MaxQueryChars + " letters).");
        if (text.Any(ch => char.IsControl(ch) && ch != ' ') || TextGuard.ContainsCardNumber(text)) throw new HubException("bad-query", "What to look for has characters or numbers that cannot be used here.");
        limit = Math.Clamp(limit, 1, MaxResults);

        var sources = db.Query("SELECT id, ref, title, data_class FROM knowledge_sources WHERE tenant_id = $t AND site_id = $s AND retired_at IS NULL ORDER BY id",
                r => (Id: r.Int("id"), Ref: r.Text("ref"), Title: r.Text("title"), Class: r.Text("data_class")), ("$t", Tenant), ("$s", Site))
            .Where(s => ReadPolicy.CanSee(who, Note, s.Class)).ToDictionary(s => s.Id);
        if (sources.Count == 0) return new KnowledgeAnswer([], false, null);

        var pieces = db.Query("SELECT source_id, seq, text, CASE WHEN vector IS NULL THEN NULL ELSE model END AS model FROM knowledge_chunks WHERE tenant_id = $t AND site_id = $s ORDER BY source_id, seq",
                r => (Source: r.Int("source_id"), Seq: (int)r.Int("seq"), Text: r.Text("text"), Model: r.TextOrNull("model")), ("$t", Tenant), ("$s", Site))
            .Where(p => sources.ContainsKey(p.Source)).ToList();

        // Words: each word of the question counts for more the fewer pieces hold it, so a word that is in every piece (and a word of any language) needs no list of words to ignore.
        var words = Words(text).Distinct().ToList();
        var haystack = pieces.Select(p => (Piece: p, Words: Words(sources[p.Source].Title + " " + p.Text).ToHashSet(StringComparer.Ordinal))).ToList();
        var weights = words.ToDictionary(w => w, w => Math.Log(1 + (double)pieces.Count / (1 + haystack.Count(h => h.Words.Contains(w)))), StringComparer.Ordinal);
        var total = weights.Values.Sum();
        var byWords = new Dictionary<(long, int), double>();
        if (total > 0)
            foreach (var h in haystack)
            {
                var found = words.Where(w => h.Words.Contains(w)).Sum(w => weights[w]);
                if (found > 0) byWords[(h.Piece.Source, h.Piece.Seq)] = found / total;
            }

        // Meaning: only while it is switched on, and only when pieces have vectors; an AI problem is a note, never an error.
        var byMeaning = new Dictionary<(long, int), double>();
        var usedMeaning = false;
        HashSet<(long, int)> comparable = [];
        string? note = null;
        var withVector = pieces.Count(p => p.Model is not null);
        if (!Recording)
            note = withVector > 0 ? "Searched by words only: search by meaning is switched off (or not in the licence)." : null;
        else if (withVector == 0)
            note = pieces.Count > 0 ? "Searched by words only: the notes have not been prepared for search by meaning yet." : null;
        else
        {
            var asked = await gateway.EmbedAsync(new AiContext(FeatureName, DataClass.Confidential, who.UserId, FlagKey.LocalEmbeddings), new EmbeddingRequest([text]), cancel);
            if (!asked.Ok || asked.Value!.Vectors.Count != 1)
                note = "Searched by words only: " + (asked.Refusal ?? "no AI service answered.");
            else
            {
                usedMeaning = true;
                var model = asked.Value.Model;
                foreach (var hit in index.Nearest(model, asked.Value.Vectors[0], Math.Max(limit * 4, 20), sources.Keys.ToList()))
                    if (hit.Similarity >= MinSimilarity) byMeaning[(hit.SourceId, hit.Seq)] = hit.Similarity;
                // Vectors of another model cannot be compared with this one's: those pieces (and any with no vector) are found by their words.
                comparable = pieces.Where(p => p.Model == model).Select(p => (p.Source, p.Seq)).ToHashSet();
                var unprepared = pieces.Count - comparable.Count;
                if (unprepared > 0)
                    note = unprepared + (unprepared == 1 ? " piece is" : " pieces are") + " not prepared for search by meaning with this model yet and " + (unprepared == 1 ? "was" : "were") + " found by words only.";
            }
        }

        var texts = pieces.ToDictionary(p => (p.Source, p.Seq), p => p);
        var hits = new List<(KnowledgeHit Hit, long Source)>();
        foreach (var key in byWords.Keys.Union(byMeaning.Keys))
        {
            var piece = texts[key];
            var kw = byWords.GetValueOrDefault(key);
            var hasMeaning = byMeaning.TryGetValue(key, out var cosine);
            var score = usedMeaning && comparable.Contains(key) ? MeaningShare * cosine + (1 - MeaningShare) * kw : kw;
            if (score <= 0) continue;
            var source = sources[piece.Source];
            hits.Add((new KnowledgeHit(source.Ref, source.Title, piece.Seq, Shorten(piece.Text, ExcerptChars), Math.Round(Math.Min(score, 1), 4), hasMeaning, source.Class), piece.Source));
        }

        var best = hits.OrderByDescending(h => h.Hit.Score).ThenBy(h => h.Source).ThenBy(h => h.Hit.Piece).Take(limit).Select(h => h.Hit).ToList();
        return new KnowledgeAnswer(best, usedMeaning, note);
    }

    // ---- inside ---------------------------------------------------------------------------------------------------------------------

    private void RequireOn()
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "Notes for search by meaning are not part of this shop's licence.");
        if (!flags.IsEnabled(FlagKey.LocalEmbeddings)) throw new HubException("knowledge-off", "Search by meaning is switched off, so notes cannot be added. You can switch it on under AI helpers.");
    }

    private sealed record Made(string Title, string Text, string DataClass, string Sha, IReadOnlyList<string> Pieces);

    private static Made Check(string? title, string? text, string? dataClass)
    {
        var name = EventRules.Words(title, MaxTitleChars, "title") ?? throw new HubException("bad-title", "Give the note a title.");
        var body = (text ?? "").Replace("\r\n", "\n", StringComparison.Ordinal).Replace('\r', '\n').Trim();
        if (body.Length == 0) throw new HubException("bad-text", "The note has no words in it.");
        if (body.Length > MaxTextChars) throw new HubException("too-long", "The note is too long (at most " + MaxTextChars + " letters). Make two notes.");
        if (body.Any(ch => char.IsControl(ch) && ch is not ('\n' or '\t'))) throw new HubException("bad-text", "The note has characters that cannot be kept.");
        if (TextGuard.ContainsCardNumber(body)) throw new HubException("never-stored", "The note looks like it holds a card number, which is never kept.");
        if (!DataClass.IsKnown(dataClass)) throw new HubException("bad-class", "Say what kind of information the note holds.");
        if (dataClass is DataClass.PaymentSensitive or DataClass.Biometric) throw new HubException("never-stored", "Card and payment details and biometric data are never kept in a note.");
        if (!Allowed.Contains(dataClass)) throw new HubException("bad-class", "A note holds words: choose public, internal, confidential, personal or financial information.");
        var pieces = Chunker.Split(body);
        if (pieces.Count == 0) throw new HubException("bad-text", "The note has no words in it.");
        return new Made(name, body, dataClass!, Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(body))).ToLowerInvariant(), pieces);
    }

    private static void CheckRoom(SqliteConnection c, SqliteTransaction t, int adding, int removing)
    {
        var existing = Convert.ToInt64(HubDb.Scalar(c, "SELECT COUNT(*) FROM knowledge_chunks WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
        if (existing - removing + adding > MaxPieces) throw new HubException("too-many", "There is no room for more notes (at most " + MaxPieces + " pieces). Retire notes you no longer need first.");
    }

    private static void InsertPieces(SqliteConnection c, SqliteTransaction t, long id, IReadOnlyList<string> pieces)
    {
        for (var i = 0; i < pieces.Count; i++)
            HubDb.Exec(c, "INSERT INTO knowledge_chunks(tenant_id, site_id, source_id, seq, text) VALUES ($t, $s, $id, $q, $text)", t, ("$t", Tenant), ("$s", Site), ("$id", id), ("$q", i), ("$text", pieces[i]));
    }

    private int PendingCount() => (int)Convert.ToInt64(db.Scalar(
        "SELECT COUNT(*) FROM knowledge_chunks c JOIN knowledge_sources s ON s.tenant_id = c.tenant_id AND s.site_id = c.site_id AND s.id = c.source_id WHERE c.tenant_id = $t AND c.site_id = $s AND c.vector IS NULL AND s.retired_at IS NULL",
        ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);

    /// <summary>The words of a text: runs of letters and digits, in lower case. Any language: a letter is whatever the text system calls one.</summary>
    private static IEnumerable<string> Words(string text)
    {
        var word = new StringBuilder();
        foreach (var ch in text)
        {
            if (char.IsLetterOrDigit(ch)) word.Append(char.ToLowerInvariant(ch));
            else if (word.Length > 0)
            {
                if (word.Length >= 2) yield return word.ToString();
                word.Clear();
            }
        }

        if (word.Length >= 2) yield return word.ToString();
    }

    private static string Shorten(string text, int max) => text.Length <= max ? text : text[..(max - 1)].TrimEnd() + "…";

    private const string Select =
        "SELECT s.id, s.ref, s.kind, s.title, s.data_class, s.chars, s.created_at, s.updated_at, s.retired_at, " +
        "(SELECT COUNT(*) FROM knowledge_chunks c WHERE c.tenant_id = s.tenant_id AND c.site_id = s.site_id AND c.source_id = s.id) AS pieces, " +
        "(SELECT COUNT(*) FROM knowledge_chunks c WHERE c.tenant_id = s.tenant_id AND c.site_id = s.site_id AND c.source_id = s.id AND c.vector IS NOT NULL) AS with_vectors " +
        "FROM knowledge_sources s WHERE s.tenant_id = $t AND s.site_id = $s";

    private static KnowledgeSource MapSource(SqliteDataReader r) => new(
        r.Int("id"), r.Text("ref"), r.Text("kind"), r.Text("title"), r.Text("data_class"), (int)r.Int("chars"), (int)r.Int("pieces"), (int)r.Int("with_vectors"), r.Time("created_at"), r.Time("updated_at"), r.TimeOrNull("retired_at"));
}
