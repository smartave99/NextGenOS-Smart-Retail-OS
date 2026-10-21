using System.Globalization;
using System.Text.Json;
using NextGenOS.Hub.Actions;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Insights;
using NextGenOS.Hub.Knowledge;
using NextGenOS.Hub.Reports;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Assistant;

/// <summary>
/// "Ask the shop" (Version 2, Phase 6, step 1): a person writes a question in their own words and gets an answer written from the shop's own records and notes, with the facts it rests on
/// numbered beside it. It can only LOOK THINGS UP; there is nothing in it that changes the shop. Where an answer points at a running-low warning, the screen can <b>offer</b> the order that
/// warning proposes: the program builds it from the warning's own figures (never a model), a person presses "Ask for approval", and it then waits, as any such request does, for someone who
/// may buy to approve it (the typed actions, <see cref="ActionService"/>). The assistant cannot ask for it, approve it or do it.
/// <list type="bullet">
/// <item><b>The shop never depends on it.</b> It is off until the owner switches on "Business assistant". It runs apart from the till: at most two questions at once, a time limit, and a person
/// who asks too often is asked to wait. With no AI service, or none that may receive the information, it still shows the facts it found; it never fails the screen.</item>
/// <item><b>It obeys the person asking.</b> Only the lookups that person's role allows are shown to the model; each lookup is checked again, and the shop's own services check again inside, as for the
/// person's own screens. A cashier who asks about takings is told that is not for them; the notes a person finds are only those the shop would show them anyway.</item>
/// <item><b>The model chooses, the program decides.</b> The model may name lookups from the short list; anything else it names is dropped. What it writes is checked: a pointer to a fact that
/// does not exist is taken out. If nothing was found, no model is asked at all, so nothing can be made up.</item>
/// <item><b>Privacy follows the facts.</b> The question is treated as confidential business information, and the answer is requested in the strictest kind of information among the facts (money is
/// financial, a note is whatever the owner marked it), through the one door every AI work uses: the licence, the switch, the privacy rules, the owner's permissions, the limits and the record of use.</item>
/// <item><b>Written down:</b> who asked, the question, which lookups were made (never what they found) and how it ended; kept 90 days. The answer itself is not kept.</item>
/// </list>
/// </summary>
public sealed class AssistantService(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, AiGateway gateway, KnowledgeService knowledge, ReportService reports, InsightService insights, ActionService actions, CatalogService catalog, ShopContextProvider shop, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;
    private const string FeatureName = "assistant";

    public const int MinQuestionChars = 3;
    public const int MaxQuestionChars = 500;
    public const int MaxFacts = 30;
    public const int MaxFactChars = 600;
    public const int KeepDays = 90;
    public const int MaxPerHour = 30;
    public const string NotKept = "(not kept: the question held a telephone number or an e-mail address)";
    public const int AtOnce = 2;

    /// <summary>The longest one question may take, all its lookups and both requests to a model included. A slow AI service is given up on, quietly; the facts are shown instead.</summary>
    internal TimeSpan TimeLimit { get; set; } = TimeSpan.FromSeconds(120);

    private readonly IReadOnlyList<ToolSpec> _tools = AssistantTools.Build(reports, knowledge, insights, shop, clock);
    private readonly SemaphoreSlim _busy = new(AtOnce, AtOnce);

    /// <summary>True while a question can be asked: the licence has the AI part and "Business assistant" is on.</summary>
    public bool On => flags.IsEnabled(FlagKey.AiAssistant);

    /// <summary>Every lookup there is, for the guide and the owner's screen (not limited to what one person may use).</summary>
    public IReadOnlyList<ToolInfo> AllLookups => _tools.Select(t => t.Info).ToList();

    private Actor Asker()
    {
        var who = access.Who();
        if (who.IsSystem || who.UserId is null) throw new HubException("not-signed-in", "Please sign in first.");
        return who;
    }

    private void RequireOn()
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "The business assistant is not part of this shop's licence.");
        if (!flags.IsEnabled(FlagKey.AiAssistant)) throw new HubException("assistant-off", "The business assistant is switched off. The owner can switch it on under Settings, AI helpers.");
    }

    /// <summary>What this person's role lets the assistant look up for them.</summary>
    public IReadOnlyList<ToolInfo> WhatICanLookAt()
    {
        var who = Asker();
        return _tools.Where(t => t.CanUse(who)).Select(t => t.Info).ToList();
    }

    // ---- asking ------------------------------------------------------------------------------------------------------------------------

    public async Task<AssistantReply> AskAsync(string? question, CancellationToken cancel = default)
    {
        var who = Asker();
        RequireOn();
        var text = Check(question);
        if (CountSince(who.UserId!.Value, clock.UtcNow.AddHours(-1)) >= MaxPerHour)
            throw new HubException("assistant-slow-down", "You have asked a lot of questions in the last hour. Please wait a little before asking again.");
        if (!_busy.Wait(0)) throw new HubException("assistant-busy", "The assistant is busy with other questions. Please try again in a moment.");
        try
        {
            return await AskInsideAsync(who, text, cancel);
        }
        finally
        {
            _busy.Release();
        }
    }

    private async Task<AssistantReply> AskInsideAsync(Actor who, string question, CancellationToken caller)
    {
        using var limit = CancellationTokenSource.CreateLinkedTokenSource(caller);
        limit.CancelAfter(TimeLimit);
        var token = limit.Token;
        var notes = new List<string>();
        var allowed = _tools.Where(t => t.CanUse(who)).ToList();
        string? providerId = null, model = null;

        // 1. Which lookups? Asked of a model only when there is a choice to make; without one (or when it does not answer) the notes are searched with the question itself.
        var calls = new List<ToolCall>();
        if (allowed.Count > 1)
        {
            var planned = await GenerateAsync(who, DataClass.Confidential, Prompts.PlanInstructions(allowed.Select(t => t.Info).ToList()), question, 300, token, caller);
            if (planned.Reply is null) notes.Add("The assistant could not ask an AI service which records to look at, so it only looked through your notes. " + planned.Why);
            else
            {
                var plan = Prompts.ReadPlan(planned.Reply.Text, allowed.Select(t => t.Id).ToList());
                if (!plan.Understood) notes.Add("The AI service did not say clearly which records to look at, so only your notes were searched.");
                foreach (var ignored in plan.Ignored) notes.Add("A lookup the assistant does not have, or that you may not use, was left out: " + ignored + ".");
                calls.AddRange(plan.Calls);
            }
        }

        if (calls.All(c => c.Tool != AssistantTools.NotesId)) calls.Insert(0, new ToolCall(AssistantTools.NotesId, new Dictionary<string, string>()));

        // 2. Do them, as this person. A lookup that does not work is written down and the others go on.
        var facts = new List<AssistantFact>();
        var runs = new List<ToolRun>();
        var kind = DataClass.Confidential;
        foreach (var call in calls)
        {
            var spec = allowed.First(t => t.Id == call.Tool);
            try
            {
                var found = await spec.Run(call.Args, question, token);
                var taken = 0;
                foreach (var line in found.Lines)
                {
                    if (facts.Count >= MaxFacts) { notes.Add("There were more facts than fit; the rest were left out."); break; }
                    facts.Add(new AssistantFact(facts.Count + 1, spec.Id, spec.Title, Prompts.Clip(Prompts.OneLine(line.Text), MaxFactChars), line.Ref));
                    taken++;
                }

                if (taken > 0) kind = AssistantTools.Stricter(kind, found.DataClass);
                if (found.Note is not null) notes.Add(found.Note);
                runs.Add(new ToolRun(spec.Id, spec.Title, call.Args, taken, null));
            }
            catch (HubException ex)
            {
                runs.Add(new ToolRun(spec.Id, spec.Title, call.Args, 0, ex.Message));
            }
            catch (OperationCanceledException) when (!caller.IsCancellationRequested)
            {
                runs.Add(new ToolRun(spec.Id, spec.Title, call.Args, 0, "It took too long."));
            }
        }

        // 3. Write the answer from the facts, if there are any and an AI service may do it.
        string mode;
        string? answer = null;
        IReadOnlyList<int> cited = [];
        if (facts.Count == 0) mode = AssistantMode.NothingFound;
        else
        {
            var made = await GenerateAsync(who, kind, Prompts.AnswerInstructions, Prompts.AnswerQuestion(facts, question), 600, token, caller);
            if (made.Reply is null)
            {
                mode = AssistantMode.FactsOnly;
                notes.Add("No AI service wrote an answer, so the facts are shown as they are. " + made.Why);
            }
            else
            {
                var checkedAnswer = Prompts.CheckAnswer(made.Reply.Text, facts.Count);
                if (checkedAnswer.Text.Length == 0)
                {
                    mode = AssistantMode.FactsOnly;
                    notes.Add("The AI service gave no answer, so the facts are shown as they are.");
                }
                else
                {
                    mode = AssistantMode.Answered;
                    answer = checkedAnswer.Text;
                    cited = checkedAnswer.Cited;
                    providerId = made.ProviderId;
                    model = made.Reply.Model;
                    if (checkedAnswer.Removed > 0) notes.Add("The AI service pointed at " + checkedAnswer.Removed + (checkedAnswer.Removed == 1 ? " fact that does not exist; that pointer was" : " facts that do not exist; those pointers were") + " taken out.");
                    if (cited.Count == 0) notes.Add("The answer does not point at any of the facts. Check it against the list.");
                }
            }
        }

        var offers = OffersFor(facts, notes);
        var id = Record(who, question, runs, facts, mode, providerId, model, notes);
        return new AssistantReply(id, question, mode, answer, facts, cited, runs, notes, providerId, model, offers);
    }

    private sealed record Generated(LlmResponse? Reply, string? ProviderId, string Why);

    /// <summary>One request to a model through the gateway. Never throws for an AI problem: the reason, in plain words, is the answer.</summary>
    private async Task<Generated> GenerateAsync(Actor who, string dataClass, string instructions, string content, int maxTokens, CancellationToken token, CancellationToken caller)
    {
        try
        {
            var asked = await gateway.GenerateAsync(new AiContext(FeatureName, dataClass, who.UserId, FlagKey.AiAssistant),
                new LlmRequest([new LlmMessage("system", instructions), new LlmMessage("user", content)], Temperature: 0, MaxTokens: maxTokens), token);
            return asked.Ok ? new Generated(asked.Value, asked.ProviderId, "") : new Generated(null, null, asked.Refusal ?? "");
        }
        catch (OperationCanceledException) when (!caller.IsCancellationRequested)
        {
            return new Generated(null, null, "The AI service took too long to answer.");
        }
    }

    private static string Check(string? question)
    {
        var text = Prompts.OneLine((question ?? "").Replace('\r', ' ').Replace('\n', ' '));
        if (text.Length < MinQuestionChars) throw new HubException("bad-question", "Write your question first.");
        if (text.Length > MaxQuestionChars) throw new HubException("bad-question", "Please keep the question to " + MaxQuestionChars + " letters or fewer.");
        if (text.Any(char.IsControl)) throw new HubException("bad-question", "The question has characters that cannot be used here.");
        if (TextGuard.ContainsCardNumber(text)) throw new HubException("bad-question", "Please do not type card numbers here.");
        return text;
    }

    // ---- offers: a request a person may ask for -------------------------------------------------------------------------------------------

    /// <summary>
    /// The requests the screen may offer for what the answer rests on: for each running-low warning among the facts that still needs an order, the order that warning proposes, checked with the
    /// rules of the Buying page and described in plain words. Nothing is kept. Only for a person who may ask for such an order, and only while "Suggested actions" is on.
    /// </summary>
    private IReadOnlyList<AssistantOffer> OffersFor(IReadOnlyList<AssistantFact> facts, List<string> notes)
    {
        var ids = facts.Select(f => f.Ref).Where(r => r is not null && r.StartsWith(AssistantTools.FindingRef, StringComparison.Ordinal))
            .Select(r => long.TryParse(r![AssistantTools.FindingRef.Length..], NumberStyles.None, CultureInfo.InvariantCulture, out var n) ? n : 0).Where(n => n > 0).Distinct().ToList();
        if (ids.Count == 0) return [];
        if (!actions.On)
        {
            notes.Add("To ask for an order from a warning here, the owner switches on Suggested actions under AI helpers.");
            return [];
        }

        var offers = new List<AssistantOffer>();
        foreach (var id in ids)
        {
            try
            {
                var finding = insights.Finding(id);
                if (finding is not { State: "open", Status: LowStockStatus.Order }) continue;
                var prepared = actions.Preview(CreatePurchaseOrderActionId, 1, CreatePurchaseOrderAction.InputFor(finding, catalog.Get(finding.ItemId)?.CostMinor ?? 0));
                offers.Add(new AssistantOffer(id, CreatePurchaseOrderActionId, "Order more " + finding.Detail.Name, prepared.Summary, prepared.Ok ? null : prepared.Problems[0], prepared.Ok));
            }
            catch (HubException)
            {
                // A person who may not ask for this, or a warning that is gone, simply gets no offer.
            }
        }

        return offers;
    }

    private const string CreatePurchaseOrderActionId = "CreatePurchaseOrder";

    /// <summary>
    /// A person presses "Ask for approval" on an offer. It asks for exactly what the Buying page would ask for from the same warning (the same request, by the same key, so asking twice is one
    /// request), as this person, and it waits for someone who may buy to approve it. Nothing is ordered, received or paid by this. Refused when the assistant is off, the person is not signed in,
    /// the warning is not open or needs no order, or the person may not ask for such an order.
    /// </summary>
    public ActionView AskForApproval(long findingId)
    {
        var who = Asker();
        RequireOn();
        var finding = insights.Finding(findingId) ?? throw new HubException("no-finding", "That warning was not found.");
        if (finding.Status != LowStockStatus.Order) throw new HubException("no-order-needed", "That warning does not need an order.");
        var made = actions.Propose(CreatePurchaseOrderActionId, 1, CreatePurchaseOrderAction.InputFor(finding, catalog.Get(finding.ItemId)?.CostMinor ?? 0), "finding", finding.Id, "finding:" + finding.Id, who.UserId);
        audit.Log(who.UserId, "assistant.request", "action", made.Id, "asked for from the warning " + finding.Id + " that the assistant pointed at");
        return made;
    }

    // ---- the record ----------------------------------------------------------------------------------------------------------------------

    private long Record(Actor who, string question, IReadOnlyList<ToolRun> runs, IReadOnlyList<AssistantFact> facts, string outcome, string? providerId, string? model, IReadOnlyList<string> notes)
    {
        // A question that holds a telephone number or an e-mail address is answered like any other, but nothing that could repeat it is kept: not its words, not the choices a model made from it, not a remark.
        var personal = TextGuard.ContainsContactDetails(question);
        var tools = runs.Select(r => r.Tool + (personal || r.Args.Count == 0 ? "" : "(" + string.Join(", ", r.Args.Where(a => a.Key != "words").OrderBy(a => a.Key, StringComparer.Ordinal).Select(a => a.Key + "=" + Choice(r.Tool, a.Key, a.Value))) + ")")).ToList();
        var sources = facts.Select(f => f.Ref ?? f.Tool).Distinct(StringComparer.Ordinal).ToList();
        var note = notes.Count == 0 || personal ? null : Prompts.Clip(string.Join(" | ", notes), 500);
        if (note is not null && TextGuard.ContainsContactDetails(note)) note = null;
        var kept = personal ? NotKept : question;
        return db.InTransaction((c, t) =>
        {
            var next = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM assistant_questions WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
            HubDb.Exec(c,
                "INSERT INTO assistant_questions(tenant_id, site_id, id, asked_at, user_id, role, question, tools, sources, outcome, provider_id, model, note) VALUES ($t, $s, $id, $at, $u, $r, $q, $tools, $src, $o, $p, $m, $n)", t,
                ("$t", Tenant), ("$s", Site), ("$id", next), ("$at", Iso.Text(clock.UtcNow)), ("$u", who.UserId), ("$r", who.Role), ("$q", kept), ("$tools", JsonSerializer.Serialize(tools)), ("$src", JsonSerializer.Serialize(sources)),
                ("$o", outcome), ("$p", providerId), ("$m", model), ("$n", note));
            audit.Log(c, t, who.UserId, "assistant.ask", "assistant_question", next, outcome + "; looked at: " + string.Join(", ", runs.Select(r => r.Tool)));
            return next;
        });
    }

    /// <summary>What a model chose for a lookup, as the record keeps it: only a choice the lookup offers (a period, a way of ranking); anything else a model wrote is not kept.</summary>
    private string Choice(string tool, string name, string value) =>
        _tools.FirstOrDefault(t => t.Id == tool)?.Args.FirstOrDefault(a => a.Name == name)?.Choices?.Contains(value) == true ? value : "(not kept)";

    private int CountSince(long userId, DateTimeOffset since) => (int)Convert.ToInt64(db.Scalar(
        "SELECT COUNT(*) FROM assistant_questions WHERE tenant_id = $t AND site_id = $s AND user_id = $u AND asked_at >= $since", ("$t", Tenant), ("$s", Site), ("$u", userId), ("$since", Iso.Text(since))) ?? 0L, CultureInfo.InvariantCulture);

    /// <summary>Questions, newest first. A person sees their own; the people who may use the AI helpers see everyone's.</summary>
    public IReadOnlyList<AskedQuestion> Recent(int limit = 20)
    {
        var who = Asker();
        var everyone = who.CanAny([Perm.Ai]);
        return db.Query(
            "SELECT q.id, q.asked_at, q.user_id, u.display_name AS name, q.role, q.question, q.tools, q.sources, q.outcome, q.provider_id, q.model, q.note FROM assistant_questions q LEFT JOIN users u ON u.id = q.user_id " +
            "WHERE q.tenant_id = $t AND q.site_id = $s AND ($all = 1 OR q.user_id = $me) ORDER BY q.id DESC LIMIT $n",
            r => new AskedQuestion(r.Int("id"), r.Time("asked_at"), r.IntOrNull("user_id"), r.TextOrNull("name"), r.TextOrNull("role"), r.Text("question"), Strings(r.Text("tools")), Strings(r.Text("sources")), r.Text("outcome"),
                r.TextOrNull("provider_id"), r.TextOrNull("model"), r.TextOrNull("note")),
            ("$t", Tenant), ("$s", Site), ("$all", everyone ? 1 : 0), ("$me", who.UserId), ("$n", Math.Clamp(limit, 1, 200)));
    }

    private static IReadOnlyList<string> Strings(string json)
    {
        try { return JsonSerializer.Deserialize<List<string>>(json) ?? []; }
        catch (JsonException) { return []; }
    }

    /// <summary>The program's own tidying: questions older than <see cref="KeepDays"/> are forgotten. Called by the upkeep.</summary>
    internal int Sweep() => db.InTransaction((c, t) => HubDb.Exec(c, "DELETE FROM assistant_questions WHERE tenant_id = $t AND site_id = $s AND asked_at < $old", t,
        ("$t", Tenant), ("$s", Site), ("$old", Iso.Text(clock.UtcNow.AddDays(-KeepDays)))));
}
