using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Knowledge;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// An embedding service for tests that gives words a meaning: words that mean the same (inexpensive, affordable, cheap) land in the same place, so a question can find a note with none of its
/// words. Everything is made of 48 numbers and is the same every time.
/// </summary>
public sealed class WordEmbedder(string id, string location, string model = "words-v1") : IEmbeddingProvider
{
    private static readonly Dictionary<string, string> Same = new()
    {
        ["inexpensive"] = "cheap", ["affordable"] = "cheap", ["budget"] = "cheap",
        ["pricey"] = "expensive", ["costly"] = "expensive",
        ["supplier"] = "vendor", ["wholesaler"] = "vendor",
    };

    public string Id => id;
    public string DisplayName => id;
    public string Location => location;
    public IReadOnlySet<string> Tasks { get; } = new HashSet<string> { AiTask.Embed };
    public int Calls { get; private set; }
    public List<string> Seen { get; } = new();
    public ProviderException? Fails { get; set; }
    public string Model { get; set; } = model;
    public bool WrongCount { get; set; }

    public Task<ProviderHealth> CheckAsync(CancellationToken cancel) => Task.FromResult(new ProviderHealth(Fails is null, "fine", [Model], TimeSpan.Zero));

    public Task<EmbeddingResponse> EmbedAsync(EmbeddingRequest request, CancellationToken cancel)
    {
        Calls++;
        Seen.AddRange(request.Inputs);
        if (Fails is not null) throw Fails;
        var vectors = request.Inputs.Select(Vector).ToList();
        if (WrongCount) vectors.RemoveAt(0);
        return Task.FromResult(new EmbeddingResponse(vectors, Model, 48, 10, TimeSpan.FromMilliseconds(1)));
    }

    public static float[] Vector(string text)
    {
        var v = new float[48];
        foreach (var raw in text.Split([' ', '.', ',', '?', '!', '\n', '\'', ':'], StringSplitOptions.RemoveEmptyEntries))
        {
            var word = raw.ToLowerInvariant();
            word = Same.GetValueOrDefault(word, word);
            var h = 17;
            foreach (var ch in word) h = (h * 31 + ch) & 0x7fffffff;
            v[h % 48] += 1;
        }

        return v;
    }
}

/// <summary>
/// The owner's notes as local knowledge (Version 2, Phase 5, step 1): kept in pieces, found by their words always and by their meaning when "Search by meaning" is on and an AI service that may
/// receive them has made vectors; privacy follows the note, a person finds only what the shop would show them anyway, and nothing here needs an AI service to work.
/// </summary>
public sealed class KnowledgeTests : IDisposable
{
    private readonly AiFixture f = new();

    public KnowledgeTests() => f.Allow(FlagKey.LocalEmbeddings);

    public void Dispose() => f.Dispose();

    private KnowledgeService K => f.App.Knowledge;

    private WordEmbedder Embedder(string id = "here", string location = ProviderLocation.Local, string model = "words-v1")
    {
        var service = new WordEmbedder(id, location, model);
        f.Factory.Services[id] = service;
        var url = location is ProviderLocation.Local or ProviderLocation.LocalOptimized ? "http://127.0.0.1:11434" : location == ProviderLocation.Lan ? "http://192.168.1.20:11434" : "https://api.example.com/v1";
        f.Ai.Providers.Save(new ProviderInput(id, id, OpenAiCompatibleProvider.AdapterId, location, url, "m", [AiTask.Embed], null, null, null), 1);
        f.Ai.Providers.SetEnabled(id, true, 1);
        return service;
    }

    private KnowledgeSource Note(string title = "Rice supplier", string text = "The supplier gives a cheap price for rice when we order ten bags.", string dataClass = DataClass.Internal) =>
        K.AddNote(title, text, dataClass, 1);

    // ---- cutting a note into pieces ---------------------------------------------------------------------------------------------

    [Fact]
    public void A_short_note_is_one_piece_and_paragraphs_are_kept_together_while_they_fit()
    {
        Assert.Equal(["Buy rice on Monday."], Chunker.Split("  Buy rice on Monday.  "));
        Assert.Equal(["First paragraph.\n\nSecond paragraph."], Chunker.Split("First paragraph.\r\n\r\n\r\n   \r\nSecond   paragraph."));
        Assert.Empty(Chunker.Split("   \n\n  "));
        Assert.Empty(Chunker.Split(null));
    }

    [Fact]
    public void A_long_note_is_cut_after_a_sentence_where_it_can_and_no_piece_is_longer_than_the_limit()
    {
        var sentence = "This is one sentence of a note about the way the shop does things. ";
        var long1 = string.Concat(Enumerable.Repeat(sentence, 40));   // one paragraph of about 2,700 letters
        var pieces = Chunker.Split(long1);
        Assert.True(pieces.Count >= 4);
        Assert.All(pieces, p => Assert.True(p.Length <= Chunker.MaxChars, "a piece of " + p.Length + " letters"));
        Assert.All(pieces, p => Assert.EndsWith(".", p));                       // each ends where a sentence ends
        Assert.Equal(long1.Trim().Replace("  ", " "), string.Join(" ", pieces)); // nothing is lost or added

        var noSpaces = new string('x', 2000);   // no space and no full stop anywhere: cut at the limit
        var cut = Chunker.Split(noSpaces);
        Assert.Equal([800, 800, 400], cut.Select(p => p.Length).ToArray());

        Assert.Equal(Chunker.Split(long1), Chunker.Split(long1));   // the same text, the same pieces
    }

    [Fact]
    public void Paragraphs_that_do_not_fit_together_start_a_new_piece_and_the_text_is_all_there()
    {
        var a = new string('a', 500) + ".";
        var b = new string('b', 500) + ".";
        var pieces = Chunker.Split(a + "\n\n" + b);
        Assert.Equal([a, b], pieces);
    }

    // ---- the vector index -------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_index_finds_the_closest_vectors_made_by_the_same_model_and_only_those_it_may()
    {
        K.AddNote("one", "alpha", DataClass.Internal, 1);
        K.AddNote("two", "beta", DataClass.Internal, 1);
        K.AddNote("three", "gamma", DataClass.Internal, 1);
        var index = new SqliteVectorIndex(f.App.Db);
        var at = f.Shop.Clock.UtcNow;
        index.Put(1, 0, "m1", [1, 0, 0], at);
        index.Put(2, 0, "m1", [0.9f, 0.1f, 0], at);
        index.Put(3, 0, "m2", [1, 0, 0], at);   // another model: never compared

        var hits = index.Nearest("m1", [2, 0, 0], 5);
        Assert.Equal([1L, 2L], hits.Select(h => h.SourceId).ToArray());
        Assert.InRange(hits[0].Similarity, 0.999, 1.0001);
        Assert.InRange(hits[1].Similarity, 0.9, 0.999);
        Assert.Equal([2L], index.Nearest("m1", [2, 0, 0], 5, [2]).Select(h => h.SourceId).ToArray());
        Assert.Single(index.Nearest("m1", [1, 0, 0], 1));
        Assert.Empty(index.Nearest("m1", [1, 0], 5));        // another number of dimensions
        Assert.Empty(index.Nearest("none", [1, 0, 0], 5));
        Assert.Equal(new Dictionary<string, long> { ["m1"] = 2, ["m2"] = 1 }, index.Counts().OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
        Assert.Equal(3, index.Clear());
        Assert.Empty(index.Counts());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void A_vector_that_is_empty_not_a_number_or_all_zeros_is_refused(int which)
    {
        K.AddNote("one", "alpha", DataClass.Internal, 1);
        var vector = which switch { 0 => Array.Empty<float>(), 1 => new[] { 0f, 0f }, 2 => new[] { 1f, float.NaN }, _ => new[] { float.PositiveInfinity, 1f } };
        Assert.Equal("bad-vector", Assert.Throws<HubException>(() => new SqliteVectorIndex(f.App.Db).Put(1, 0, "m", vector, f.Shop.Clock.UtcNow)).Code);
        Assert.Equal("no-piece", Assert.Throws<HubException>(() => new SqliteVectorIndex(f.App.Db).Put(99, 0, "m", [1f], f.Shop.Clock.UtcNow)).Code);
        Assert.Equal("bad-model", Assert.Throws<HubException>(() => new SqliteVectorIndex(f.App.Db).Put(1, 0, " ", [1f], f.Shop.Clock.UtcNow)).Code);
    }

    // ---- keeping notes ------------------------------------------------------------------------------------------------------------

    [Fact]
    public void A_note_is_kept_in_pieces_with_a_reference_and_what_kind_of_information_it_holds()
    {
        var note = Note(text: "First part.\n\nSecond part.");
        Assert.Equal(("note:1", "note", "Rice supplier", DataClass.Internal), (note.Ref, note.Kind, note.Title, note.DataClass));
        Assert.Equal((1, 0), (note.Pieces, note.PiecesWithVectors));
        Assert.Equal("First part.\n\nSecond part.", K.TextOf(note.Id));
        Assert.Equal(2, Note("Second", "Another").Id);
        Assert.Equal(2, K.List().Count);
        Assert.Equal(2, K.Waiting());
        Assert.Equal(64, Assert.Single(f.App.Db.Query("SELECT length(content_sha256) FROM knowledge_sources WHERE id = 1", r => r.GetInt32(0))));
    }

    [Theory]
    [InlineData("title", "")]
    [InlineData("title", "   ")]
    [InlineData("title", "bad\u0007title")]
    [InlineData("text", "")]
    [InlineData("text", "bad\u0000text")]
    [InlineData("text", "paid with 4111 1111 1111 1111")]
    [InlineData("class", "SECRET")]
    [InlineData("class", "")]
    [InlineData("class", DataClass.PaymentSensitive)]
    [InlineData("class", DataClass.Biometric)]
    [InlineData("class", DataClass.Video)]
    [InlineData("class", DataClass.Audio)]
    public void A_note_with_a_part_that_is_not_allowed_is_refused_and_nothing_is_kept(string part, string value)
    {
        Assert.Throws<HubException>(() => K.AddNote(part == "title" ? value : "Title", part == "text" ? value : "Some words.", part == "class" ? value : DataClass.Internal, 1));
        Assert.Empty(K.List(includeRetired: true));
        Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM knowledge_chunks")));
    }

    [Fact]
    public void The_edges_of_what_is_allowed_are_allowed_and_one_past_them_is_not()
    {
        K.AddNote(new string('t', KnowledgeService.MaxTitleChars), new string('x', KnowledgeService.MaxTextChars), DataClass.Confidential, 1);
        Assert.Equal("too-long", Assert.Throws<HubException>(() => K.AddNote("t", new string('x', KnowledgeService.MaxTextChars + 1), DataClass.Internal, 1)).Code);
        Assert.Equal("too-long", Assert.Throws<HubException>(() => K.AddNote(new string('t', KnowledgeService.MaxTitleChars + 1), "x", DataClass.Internal, 1)).Code);
        foreach (var kind in new[] { DataClass.Public, DataClass.Internal, DataClass.Confidential, DataClass.Personal, DataClass.Financial })
            K.AddNote("kind " + kind, "words", kind, 1);
    }

    [Fact]
    public void Writing_needs_the_switch_and_the_licence_but_looking_retiring_and_searching_by_words_never_do()
    {
        var note = Note();
        f.Ai.Flags.Set(FlagKey.LocalEmbeddings, false, 1);
        Assert.Equal("knowledge-off", Assert.Throws<HubException>(() => K.AddNote("x", "y", DataClass.Internal, 1)).Code);
        Assert.Equal("knowledge-off", Assert.Throws<HubException>(() => K.UpdateNote(note.Id, "x", "y", DataClass.Internal, 1)).Code);
        Assert.Single(K.List());
        Assert.NotNull(K.TextOf(note.Id));
        Assert.Single(K.SearchAsync("rice").GetAwaiter().GetResult().Hits);

        f.Ai.Flags.Set(FlagKey.LocalEmbeddings, true, 1);
        f.Entitled.Allowed = false;
        Assert.Equal("not-licensed", Assert.Throws<HubException>(() => K.AddNote("x", "y", DataClass.Internal, 1)).Code);
        K.RetireNote(note.Id, 1);   // taking a note away is always allowed
        Assert.Empty(K.List());
    }

    [Fact]
    public void Changing_a_note_replaces_its_pieces_and_forgets_their_vectors_and_a_retired_note_loses_its_words()
    {
        var here = Embedder();
        var note = Note();
        K.PrepareAsync(1).GetAwaiter().GetResult();
        Assert.Equal(1, K.List().Single().PiecesWithVectors);

        var changed = K.UpdateNote(note.Id, "Rice supplier (new)", "Now we pay a fair price.", DataClass.Confidential, 1);
        Assert.Equal(("Rice supplier (new)", DataClass.Confidential, 0), (changed.Title, changed.DataClass, changed.PiecesWithVectors));
        Assert.Equal("Now we pay a fair price.", K.TextOf(note.Id));
        Assert.Equal(1, K.Waiting());

        K.RetireNote(note.Id, 1);
        var gone = Assert.Single(K.List(includeRetired: true));
        Assert.True(gone.Retired);
        Assert.Null(K.TextOf(note.Id));
        Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar("SELECT COUNT(*) FROM knowledge_chunks")));
        Assert.Equal("retired", Assert.Throws<HubException>(() => K.UpdateNote(note.Id, "x", "y", DataClass.Internal, 1)).Code);
        Assert.Equal("no-note", Assert.Throws<HubException>(() => K.UpdateNote(99, "x", "y", DataClass.Internal, 1)).Code);
        Assert.Equal("no-note", Assert.Throws<HubException>(() => K.RetireNote(99, 1)).Code);
        K.RetireNote(note.Id, 1);   // again: nothing happens, and nothing more is written in the audit record
        Assert.Equal(1, f.App.Audit.Recent(50).Count(a => a.Action == "knowledge.retire"));
        Assert.Empty(K.SearchAsync("fair price").GetAwaiter().GetResult().Hits);
        Assert.Equal(1, here.Calls);   // the vectors were made once, before the change
    }

    [Fact]
    public void There_are_limits_on_how_many_notes_and_pieces_there_can_be_and_retiring_makes_room()
    {
        for (var i = 0; i < KnowledgeService.MaxNotes; i++) K.AddNote("note " + i, "words " + i, DataClass.Internal, 1);
        Assert.Equal("too-many", Assert.Throws<HubException>(() => K.AddNote("one more", "words", DataClass.Internal, 1)).Code);
        K.RetireNote(1, 1);
        K.AddNote("one more", "words", DataClass.Internal, 1);
        Assert.Equal(KnowledgeService.MaxNotes, K.List().Count);
    }

    [Fact]
    public void Every_change_to_a_note_is_in_the_audit_record_with_who_made_it_and_without_its_text()
    {
        var note = K.AddNote("Supplier terms", "secret words about the price", DataClass.Confidential, 7);
        K.UpdateNote(note.Id, "Supplier terms 2", "other words", DataClass.Confidential, 7);
        K.RetireNote(note.Id, 7);
        var lines = f.App.Audit.Recent(20).Where(a => a.Action.StartsWith("knowledge.", StringComparison.Ordinal)).Reverse().ToList();
        Assert.Equal(["knowledge.add", "knowledge.update", "knowledge.retire"], lines.Select(l => l.Action).ToArray());
        Assert.All(lines, l => Assert.Equal(7, l.UserId));
        Assert.DoesNotContain("secret words", string.Join("|", lines.Select(l => l.Detail)));
    }

    // ---- finding by words (no AI at all) -------------------------------------------------------------------------------------------

    [Fact]
    public async Task Words_are_found_with_every_AI_service_off_and_the_answer_points_at_its_note()
    {
        Note("Rice supplier", "The supplier gives a cheap price for rice when we order ten bags.");
        Note("Opening hours", "We open at nine and close at six on weekdays.");
        var embedder = Embedder();
        f.Ai.Flags.Set(FlagKey.LocalEmbeddings, false, 1);

        var answer = await K.SearchAsync("what price for rice?");
        var hit = Assert.Single(answer.Hits);
        Assert.Equal(("note:1", "Rice supplier", 0, false), (hit.Ref, hit.Title, hit.Piece, hit.ByMeaning));
        Assert.Contains("cheap price for rice", hit.Excerpt);
        Assert.InRange(hit.Score, 0.01, 1);
        Assert.False(answer.UsedMeaning);
        Assert.Null(answer.Note);   // nothing was prepared, so there is nothing to explain
        Assert.Equal(0, embedder.Calls);

        Assert.Equal("note:2", (await K.SearchAsync("close at six")).Hits.Single().Ref);
        Assert.Empty((await K.SearchAsync("zebra")).Hits);
    }

    [Fact]
    public async Task A_word_found_in_every_piece_counts_for_little_and_a_rare_word_for_a_lot_in_any_language()
    {
        Note("a", "the shop sells rice and the shop sells oil");
        Note("b", "the shop sells rice and the shop sells sugar");
        Note("c", "the shop sells tea");
        var best = (await K.SearchAsync("the sugar")).Hits;
        Assert.Equal("note:2", best[0].Ref);   // 'sugar' is rare; 'the' is everywhere
        Note("d", "कोई भी दुकान चावल बेचती है");
        Assert.Equal("note:4", (await K.SearchAsync("चावल")).Hits.Single().Ref);   // another script: no list of words to ignore is needed
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("bad\u0007query")]
    [InlineData("card 4111 1111 1111 1111")]
    public async Task A_question_that_is_empty_has_odd_characters_or_a_card_number_is_refused(string query) =>
        Assert.Equal("bad-query", (await Assert.ThrowsAsync<HubException>(() => K.SearchAsync(query))).Code);

    [Fact]
    public async Task A_question_that_is_too_long_is_refused_and_the_number_of_answers_is_kept_within_bounds()
    {
        Assert.Equal("bad-query", (await Assert.ThrowsAsync<HubException>(() => K.SearchAsync(new string('a', KnowledgeService.MaxQueryChars + 1)))).Code);
        for (var i = 0; i < 30; i++) K.AddNote("note " + i, "rice and more words " + i, DataClass.Internal, 1);
        Assert.Equal(KnowledgeService.MaxResults, (await K.SearchAsync("rice", 1000)).Hits.Count);
        Assert.Single((await K.SearchAsync("rice", 0)).Hits);
        Assert.Equal(5, (await K.SearchAsync("rice")).Hits.Count);
    }

    [Fact]
    public async Task An_excerpt_is_short_and_ends_with_dots_when_the_piece_is_longer()
    {
        K.AddNote("long", "rice " + new string('x', 700), DataClass.Internal, 1);
        var hit = (await K.SearchAsync("rice")).Hits.Single();
        Assert.True(hit.Excerpt.Length <= KnowledgeService.ExcerptChars);
        Assert.EndsWith("…", hit.Excerpt);
    }

    // ---- making vectors, and finding by meaning ------------------------------------------------------------------------------------

    [Fact]
    public async Task Preparing_makes_a_vector_for_each_piece_once_and_asking_again_does_nothing()
    {
        Note("one", "alpha words");
        Note("two", "beta words");
        var here = Embedder();

        var first = await K.PrepareAsync(1);
        Assert.Equal((2, 0, null), (first.Prepared, first.Waiting, first.Note));
        Assert.Equal(1, here.Calls);   // both pieces in one asking
        Assert.All(K.List(), s => Assert.Equal((1, 1), (s.Pieces, s.PiecesWithVectors)));
        Assert.Equal("words-v1", Assert.Single(f.App.Db.Query("SELECT DISTINCT model FROM knowledge_chunks", r => r.GetString(0))));

        var again = await K.PrepareAsync(1);
        Assert.Equal((0, 0, null), (again.Prepared, again.Waiting, again.Note));
        Assert.Equal(1, here.Calls);
    }

    [Fact]
    public async Task A_question_is_answered_by_meaning_when_no_word_is_shared_and_the_answer_says_it_was_found_by_meaning()
    {
        Note("Rice supplier", "The vendor gives a cheap price for rice when we order ten bags.");
        Note("Opening hours", "We open at nine and close at six on weekdays.");
        Embedder();
        await K.PrepareAsync(1);

        var answer = await K.SearchAsync("An inexpensive wholesaler?");   // no word in common with the note
        Assert.True(answer.UsedMeaning);
        Assert.Null(answer.Note);
        var hit = answer.Hits.First();
        Assert.Equal(("note:1", true), (hit.Ref, hit.ByMeaning));
        Assert.DoesNotContain(answer.Hits, h => h.Ref == "note:2");   // the opening hours are not about prices

        // Words alone would not have found it.
        f.Ai.Flags.Set(FlagKey.LocalEmbeddings, false, 1);
        var plain = await K.SearchAsync("An inexpensive wholesaler?");
        Assert.DoesNotContain(plain.Hits, h => h.Ref == "note:1");
        Assert.False(plain.UsedMeaning);
        Assert.Contains("switched off", plain.Note);
    }

    [Fact]
    public async Task Meaning_and_words_together_rank_a_piece_that_has_both_above_one_that_has_only_one()
    {
        Note("both", "cheap rice from the vendor");
        Note("meaning only", "affordable grain from a wholesaler");
        Embedder();
        await K.PrepareAsync(1);
        var hits = (await K.SearchAsync("cheap rice vendor")).Hits;
        Assert.Equal(["note:1", "note:2"], hits.Select(h => h.Ref).ToArray());
        Assert.True(hits[0].Score > hits[1].Score);
        Assert.All(hits, h => Assert.InRange(h.Score, 0.0001, 1));
    }

    [Fact]
    public async Task With_no_AI_service_preparing_says_why_keeps_every_note_and_searching_still_works()
    {
        Note();
        var result = await K.PrepareAsync(1);
        Assert.Equal(0, result.Prepared);
        Assert.Equal(1, result.Waiting);
        Assert.Contains("No AI service", result.Note);
        Assert.Single((await K.SearchAsync("rice")).Hits);
    }

    [Fact]
    public async Task When_the_service_fails_or_gives_a_bad_answer_nothing_is_kept_and_the_pass_stops_quietly()
    {
        Note();
        var here = Embedder();
        here.Fails = new ProviderException(ProviderException.Unreachable, "not there");
        var failed = await K.PrepareAsync(1);
        Assert.Equal(0, failed.Prepared);
        Assert.NotNull(failed.Note);
        Assert.Equal(1, K.Waiting());

        here.Fails = null;
        here.WrongCount = true;
        var wrong = await K.PrepareAsync(1);
        Assert.Equal(0, wrong.Prepared);
        Assert.Contains("could not be used", wrong.Note);
        Assert.Equal(1, K.Waiting());

        here.WrongCount = false;
        Assert.Equal(1, (await K.PrepareAsync(1)).Prepared);
    }

    [Fact]
    public async Task A_question_that_the_service_cannot_answer_falls_back_to_words_and_says_so()
    {
        Note();
        var here = Embedder();
        await K.PrepareAsync(1);
        here.Fails = new ProviderException(ProviderException.Timeout, "too slow");
        var answer = await K.SearchAsync("price for rice");
        Assert.False(answer.UsedMeaning);
        Assert.Single(answer.Hits);
        Assert.StartsWith("Searched by words only:", answer.Note);
    }

    [Fact]
    public async Task Vectors_of_another_model_are_not_compared_with_this_ones_and_those_pieces_are_found_by_their_words()
    {
        Note("old", "cheap rice");
        var here = Embedder(model: "words-v1");
        await K.PrepareAsync(1);
        Note("new", "inexpensive beans");
        here.Model = "words-v2";
        await K.PrepareAsync(1);   // only the new piece is made, by the new model

        var answer = await K.SearchAsync("cheap");
        Assert.True(answer.UsedMeaning);
        Assert.Contains("not prepared for search by meaning with this model yet", answer.Note);
        Assert.Contains(answer.Hits, h => h.Ref == "note:2" && h.ByMeaning);    // found by meaning, with the new model's vectors
        Assert.Contains(answer.Hits, h => h.Ref == "note:1" && !h.ByMeaning);   // found by its word: its vector is another model's and is not used

        Assert.Equal(2, K.ForgetVectors(1));
        Assert.Equal(2, K.Waiting());
        Assert.Equal(0, K.ForgetVectors(1));
    }

    [Fact]
    public async Task Pieces_not_prepared_yet_are_found_by_words_while_the_prepared_ones_are_found_by_meaning()
    {
        Note("first", "cheap rice");
        Embedder();
        await K.PrepareAsync(1);
        Note("second", "cheap tea");   // written after: no vector yet
        var answer = await K.SearchAsync("cheap");
        Assert.True(answer.UsedMeaning);
        Assert.Contains("1 piece is not prepared", answer.Note);
        Assert.Equal(2, answer.Hits.Count);
    }

    // ---- privacy follows the note ----------------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_note_about_people_is_never_sent_to_an_online_service_that_was_not_allowed_it_and_it_is_sent_to_a_service_on_this_computer()
    {
        Note("Customers", "Asha likes tea.", DataClass.Personal);
        var online = Embedder("online", ProviderLocation.Api);
        f.Allow(FlagKey.RemoteAi);
        f.Ai.Providers.Grant("online", DataClass.Internal, null, 1);   // allowed internal information, not personal
        var refused = await K.PrepareAsync(1);
        Assert.Equal(0, refused.Prepared);
        Assert.Contains("You have not allowed it to receive", refused.Note);
        Assert.Equal(0, online.Calls);

        var here = Embedder("here");
        var done = await K.PrepareAsync(1);
        Assert.Equal(1, done.Prepared);
        Assert.Equal(1, here.Calls);
        Assert.Equal(0, online.Calls);
    }

    [Fact]
    public async Task One_pass_asks_for_one_kind_of_information_at_a_time()
    {
        Note("public", "opening hours", DataClass.Public);
        Note("people", "Asha likes tea", DataClass.Personal);
        Note("money", "the bank balance", DataClass.Financial);
        var here = Embedder();
        Assert.Equal(3, (await K.PrepareAsync(1)).Prepared);
        Assert.Equal(3, here.Calls);   // three kinds, three askings: the privacy rules judge each as what it is
    }

    // ---- what a person may read is what a person may search -------------------------------------------------------------------------

    [Fact]
    public async Task A_person_finds_only_notes_of_a_kind_the_shop_would_show_them_anyway()
    {
        var owner = f.App.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        var manager = f.App.Users.Create("mia", "Mia Manager", Roles.Manager, "manager good password").Id;
        var cashier = f.App.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        var kitchen = f.App.Users.Create("kim", "Kim Kitchen", Roles.Kitchen, "kitchen good password").Id;
        K.AddNote("hours", "shared words: our opening hours", DataClass.Public, owner);
        K.AddNote("rules", "shared words: how we do things", DataClass.Internal, owner);
        K.AddNote("terms", "shared words: the supplier's price terms", DataClass.Confidential, owner);
        K.AddNote("customers", "shared words: who buys what", DataClass.Personal, owner);
        K.AddNote("books", "shared words: the bank balance", DataClass.Financial, owner);
        var strict = f.OpenStrict();

        async Task<string[]> Found(long? who)
        {
            using var scope = strict.Access.As(who);
            return (await strict.Knowledge.SearchAsync("shared words", 20)).Hits.Select(h => h.Title).Order().ToArray();
        }

        Assert.Equal(["books", "customers", "hours", "rules", "terms"], await Found(owner));
        Assert.Equal(["books", "customers", "hours", "rules", "terms"], await Found(manager));   // the manager reads the books, the reports and the customer list
        Assert.Equal(["customers", "hours", "rules"], await Found(cashier));                       // the cashier opens the customer list at the till, but not the price terms or the books
        Assert.Equal(["hours", "rules"], await Found(kitchen));                                    // the kitchen screen sees neither the customer list nor the money
        using (strict.Access.As(null as long?))
            Assert.Equal("not-signed-in", (await Assert.ThrowsAsync<HubException>(() => strict.Knowledge.SearchAsync("shared words"))).Code);
    }

    [Fact]
    public async Task What_the_vectors_find_is_filtered_the_same_way()
    {
        var owner = f.App.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        var cashier = f.App.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        K.AddNote("terms", "the vendor gives a cheap price", DataClass.Confidential, owner);
        K.AddNote("hours", "we open at nine", DataClass.Internal, owner);
        Embedder();
        await K.PrepareAsync(owner);
        var strict = f.OpenStrict();
        using (strict.Access.As(cashier))
        {
            var answer = await strict.Knowledge.SearchAsync("an inexpensive wholesaler");
            Assert.DoesNotContain(answer.Hits, h => h.Ref == "note:1");
        }

        using (strict.Access.As(owner))
            Assert.Contains((await strict.Knowledge.SearchAsync("an inexpensive wholesaler")).Hits, h => h.Ref == "note:1");
    }

    [Fact]
    public async Task Only_the_people_who_may_use_the_AI_helpers_may_write_look_at_every_note_and_make_vectors()
    {
        var owner = f.App.Users.Create("olivia", "Olivia Owner", Roles.Owner, "correct horse battery").Id;
        var cashier = f.App.Users.Create("tara", "Tara Till", Roles.Cashier, "another good password").Id;
        var note = K.AddNote("hours", "we open at nine", DataClass.Internal, owner);
        var strict = f.OpenStrict();
        using (strict.Access.As(cashier))
        {
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Knowledge.AddNote("x", "y", DataClass.Internal, cashier)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Knowledge.UpdateNote(note.Id, "x", "y", DataClass.Internal, cashier)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Knowledge.RetireNote(note.Id, cashier)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Knowledge.List()).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Knowledge.Get(note.Id)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Knowledge.TextOf(note.Id)).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Knowledge.Waiting()).Code);
            Assert.Equal("forbidden", (await Assert.ThrowsAsync<HubException>(() => strict.Knowledge.PrepareAsync(cashier))).Code);
            Assert.Equal("forbidden", Assert.Throws<HubException>(() => strict.Knowledge.ForgetVectors(cashier)).Code);
        }

        using (strict.Access.As(owner)) Assert.Single(strict.Knowledge.List());
    }

    // ---- the database step -----------------------------------------------------------------------------------------------------------

    [Fact]
    public void The_new_tables_carry_the_tenant_and_the_site()
    {
        foreach (var table in new[] { "knowledge_sources", "knowledge_chunks" })
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0));
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
        }
    }

    [Fact]
    public void The_step_can_be_undone_alone_and_the_shop_is_untouched_and_a_forward_run_makes_the_tables_again()
    {
        var item = f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 42500, TaxClass = "standard" });
        Note();
        f.App.Db.Rollback(29);
        var names = f.App.Db.Query("SELECT name FROM sqlite_master", r => r.GetString(0)).ToHashSet();
        Assert.DoesNotContain("knowledge_sources", names);
        Assert.DoesNotContain("knowledge_chunks", names);
        Assert.DoesNotContain("ix_knowledge_chunks_pending", names);
        Assert.Contains("event_rules", names);   // the step before stays
        Assert.Equal("Rice", f.App.Db.Scalar("SELECT name FROM items WHERE id = $i", ("$i", item.Id)));
        Assert.True(File.Exists(f.App.Db.LastBackup));

        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Shop.Clock, null, null);
        Assert.Equal(0L, Convert.ToInt64(again.Db.Scalar("SELECT COUNT(*) FROM knowledge_sources")));
        Assert.Equal("Rice", again.Db.Scalar("SELECT name FROM items WHERE id = $i", ("$i", item.Id)));
    }
}
