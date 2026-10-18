# AI assistant 2.0: the plan and the state

This file is the working record of the owner's brief of 12 October 2026. **The brief itself is recorded word for word in `docs/OWNER-REQUESTS.md`** (the entry of 2026-10-12). If this file and the brief differ, the brief is right. Read `CLAUDE.md` (sections 3, 15, 16 and 17) first.

## The owner's standing rules for this work

1. **The shop's live database is read-only for the AI, absolutely.** Nothing the AI does, directly or indirectly, writes to the shop program's database, its files, its settings or its business records. Defence in depth, failing closed. The AI may write only its **own** data (chat history, memory, campaigns, tasks, reminders, notes, reports, pictures, snapshots), kept apart from the shop's database. If a read-only database account has to be made by a person, the steps are written down; nothing makes it silently.
2. **No commit, push, publish or deploy of this work without the owner's permission.** The code of this work stayed in the working folder until the owner said so. **The owner gave that permission on 18 October 2026** (asked in the session: "commit, open a PR, merge when green"), so it is committed, tried by the build on GitHub and merged into `main` after that passes. It is still **not released or deployed** to any shop: a release is a separate decision.
3. **Reuse first (`CLAUDE.md` section 17).** The existing memory, chat history, providers, poster and growth-plan features are extended, not replaced.
4. **Say what is true.** No invented prices, reach or sales figures; no fake capabilities; correlation is not shown as cause; a test is "passed" only when it was run.

## Where the brief's folders are (the brief uses an older layout)

| The brief says | In this repository |
|---|---|
| `SmartRetailAI/src/SmartRetail.AI.Core/...` | `apps/pos-ai-companion/src/SmartRetail.AI.Core/...` |
| `SmartRetailPOS/src/SmartRetail.Pos.Web/...` | `apps/pos-dashboard-service/src/SmartRetail.Pos.Web/...` |

## The owner's acceptance list (every line must be shown, not claimed)

1. A natural 10 to 20 message conversation without re-explaining the topic.
2. Business and marketing talk without insisting on shop data.
3. The conversation history is used as the AI's context, not only stored and shown.
4. A conversation resumes after the application restarts.
5. Shop projects and approved durable facts are remembered across conversations.
6. Campaigns and tasks can be made, saved, changed and revisited (outside the shop's database).
7. An e-rickshaw campaign can be planned: budget, artwork, tasks, timeline, measurable signs.
8. Sales and bill trends can be set against campaign periods, with the limits of what that proves said plainly.
9. The Ask AI screen has no empty region at the bottom.
10. The live shop database and the shop program's files stay protected from writes.
11. What already works is kept.
12. The relevant tests pass, or what could not be run is said.

## Phases and state (13 October 2026)

All of this was kept **uncommitted** until the owner gave permission (18 October 2026, rule 2 above); it is then committed and merged into `main` through a pull request once the build on GitHub passes. Nothing was published or deployed to any shop.

| Phase | What | State |
|---|---|---|
| 1 | Investigation and root causes | **done** (12 October 2026; below) |
| 2 | Conversation repair: context, persistence, prompt assembly, provider independence | **built and tested** (see "What is built") |
| 3 | Routing: business talk without SQL | **built and tested** |
| 4 | Safe tools, projects, tasks, reminders in the assistant's own store | **built and tested**; the tools are a written list kept by tests, not a runtime dispatcher |
| 5 | Marketing and growth: campaigns, plans, the owner's own numbers, comparison with limits | **built and tested**; sales are read from the POS through the existing Actions page |
| 6 | Screen: the bottom gap, plan and task links, chat naming, copy and save | **built and tested**; one gap below |
| 7 | Verification and the final report | the checks below were run; the report is in the answer to the owner |

*(Keep this table and the acceptance list true in the same change as the work, as `CLAUDE.md` section 13 asks.)*

## What is built

Paths are in this repository's layout ("AI" = `apps/pos-ai-companion/src/SmartRetail.AI.Core`, "Web" = `apps/pos-dashboard-service/src/SmartRetail.Pos.Web`).

**The conversation (phases 2 and 3).** Every question is asked with the chat so far in its prompt, because the AI tools keep no chat of their own. `Assistant/ConversationContext.cs` builds that context for each question: the last messages word for word, an older part as a short rule-based summary (no model, so the same messages always give the same summary: the goal and the limits such as a budget are cut last), the topic, and, only when the owner asks to go back ("what did we discuss last time?"), words from an earlier chat. It fits a budget of characters, ignores a failure or a stop as if it were not an answer, and is the same for every provider (another AI tool taking over is given the same chat). `Assistant/RequestRouter.cs` decides, without asking an AI, where a message goes: **advice and talk** go to a conversation with no query and no reading of the shop's database; **questions about the shop's figures** go to the database as before (one guarded SELECT); **both** ("why did sales fall, and what should we do?") get the figures, with the facts and the causes kept apart; **keeping work** goes to the plan; "yes" or "continue" goes where the chat was going. A message it cannot place goes to the data path, where the AI may still say no query is needed and the answer is then a conversation. A chat is kept after every answer, resumes after the app restarts (and from *Past chats*, "Continue this chat"), can be given a name that stays, and can be copied or saved as plain words. What went into a prompt is logged in numbers, never in words.

**The plan (phase 4).** `Work/*` is the assistant's own store: projects, tasks, reminders, notes and the owner's own numbers, in `Memory\work.json` of the data folder, never in the POS. Each item has `tenant_id` and `site_id` (`local`, `main`). What the AI suggests comes back in a fixed shape that cannot express a database, a file or a command; the application checks every entry (`WorkRules`: no instruction to the AI, length limits, a task only in a project that exists, no duplicate, sensible dates) and, unless the owner switched it off, the suggestion waits for the owner's **Save** (in the chat under the answer, or on the page *Plan & tasks*). Every change is in a journey and can be undone, one answer at a time (and only while the item is still as that change left it: the latest change of an item first). The assistant may not keep a phone number or an e-mail address in the plan (the owner may, by hand; they are hidden from the AI tool whenever the plan is put into a prompt), and the owner's own numbers have a room of their own (600), so a campaign counted every day does not fill the plan. Reminders show in the app; **they are not sent to anyone**. The page is `Web/Components/Pages/WorkPlan.razor` (menu: *Plan & tasks*).

**Marketing and growth (phase 5).** A campaign is a project with a channel, a place, its days and a budget **the owner set**. The owner enters, by hand, **numbers about it** (people counted, enquiries, money spent, quotations): they are kept as the owner's, labelled "not from the POS", and **never estimated** (a number nobody gave is refused, and the AI is told so). `Work/CampaignReport.cs` adds them up and sets counts before the campaign against counts during it, only with at least three counted days on each side, and says what that cannot show. The POS's sales for the campaign's days are read through the existing **Actions** page (`ShopAction`/`ActionMeasure`, unchanged except that the wording no longer says the action "added" sales and every verdict page carries the same limits sentence); the two are shown apart. A plan can be started from a **template** (`Work/CampaignTemplates.cs`): one neutral built-in (quotations, message, artwork, brief, start, count, ask, review), and a customer's own from its profile. The page is `Web/Components/Pages/CampaignView.razor`; it links to the Posters page.

**The screen (phase 6).** The empty band under the question box (measured at 88 to 92 px when the page opens and 44 px while reading, from a stylesheet sum) is gone: 38 px in every state, with a permanent browser test (`scripts/tests/ask-layout.test.mjs`, in the full gate as `ask-layout`). The header has *Plan & tasks*, *Copy chat* and *Save as file*; an answer that suggested work has *Save to my plan*, *Don't save* and a link, and says in words what is saved, what waits and what was left out. Past chats can be named. Stop, streaming, *Ask again*, copy and the "Latest" button already existed and are kept.

**Read-only (the first rule).** See `docs/POS-READ-ONLY.md`: eight layers, the tests that pin them, the steps to make the read-only login, and what is not verified.

**Words of a customer's language, money and trade are data (`CLAUDE.md` section 8).** The program recognises plain English only. A customer's own words (Hindi and Hinglish, rupees, e-rickshaws) are in `profile\chat-words.json`, and its own campaign plans in `profile\campaigns.json`, beside `ai.json`; this customer's are in `brand-kits/smart-avenue-99/`. With none the assistant still works (a message it cannot place goes to the data path, where the AI reads it with the chat). The white-label baseline went down by one.

## The owner's acceptance list: what shows each line

| # | Shown by | Not shown |
|---|---|---|
| 1 | `ConversationMemoryTests`: the owner's own example ("…e-rickshaw poster advertising… What do you think?" then "Yes, tell me") is a conversation, not "what do you want to know about the shop"; a ten-message chat carries every earlier point into the last prompt | a long talk with a real AI tool |
| 2 | the router sends advice to a conversation with no query and no reading of the shop's database; `…When_the_AI_says_no_query_is_needed…` | the quality of a real model's advice |
| 3 | the prompts of the tests contain the chat; `Another_AI_tool_taking_over_is_given_the_same_chat`; stopped and failed questions are never shown as answers | each provider's own limits on prompt size (the budget is in characters, not in each provider's tokens) |
| 4 | `A_chat_kept_and_resumed_after_the_app_restarted…` and `ChatResumeTests` (resume by itself soon after a restart, from Past chats, a name stays) | a restart of the real app window |
| 5 | the plan and the memory are files that survive a restart (`WorkTests`, `WorkServiceTests`); the plan is in the prompts; the older memory (Shop and Owner) is unchanged | recall by meaning (it is by words in common) |
| 6 | `WorkTests`, `CampaignTests`: made, saved (after Save), changed, dropped, undone, found again after a restart; `WorkPlanPageTests` render the pages | clicking in a real browser (the pages were rendered and looked at in Chromium with the real stylesheet, but not driven) |
| 7 | `CampaignTests.The_e_rickshaw_plan_is_made…` (budget, tasks with dates, a reminder, a quotation the owner gave, a number nobody gave is left out); `CampaignTemplateTests` | nothing was run against a real AI tool; no price, reach or result is invented by the program |
| 8 | `CampaignTests` (counts before and during, with the limits); `ActionMeasureTests`; `WorkServiceTests.A_campaign_can_be_tracked_in_Actions…` | a real shop's data |
| 9 | `scripts/tests/ask-layout.test.mjs`: 4 tests, 6 window sizes, with the app window's bar and in a browser, with 0, 2 and 12 exchanges, dark theme, the side panel | the owner's own screen (their screenshots did not reach the assistant) |
| 10 | `PosReadOnlyTests`, `PosAccessTests`, `SqlGuardTests` (see `docs/POS-READ-ONLY.md`) | a real SQL Server: the script and the check |
| 11 | the AI add-on's and the dashboard's whole test suites pass; the older tests that pinned the old design were changed on purpose, each named in the commit message when it is committed | |
| 12 | see "How it was checked" in the answer to the owner | see "Not verified" there |

## Not built, or not yet true

- **The old side panel** (the small Windows form beside the POS, `Desktop/MainForm.cs`) still answers one question at a time, with no chat memory; it gets the new routing (so advice is no longer refused) and the read-only check, not the conversation. The conversation, the plan and the campaigns are in the dashboard's **Ask AI** (the app window).
- **Reminders are not delivered.** They show on the page; nothing sends a message, a sound or an e-mail.
- **No outside action exists.** Nothing prints, publishes, orders or contacts anyone. When one is added it needs the owner's approval each time (`AssistantTools`).
- **The profile files are not carried yet.** The Setup Studio and the add-on's setup program copy `ai.json` only; `chat-words.json` and `campaigns.json` must be copied by hand into `profile\` for now (`docs/OPEN-WORK.md`, 12zzz).
- **Posters:** the campaign page links to the Posters page; it does not start a poster by itself.
- **Recall is by words in common**, not by meaning (no embeddings, as the brief says: no new heavy parts before they are needed).
- **No data-class routing table yet** (`CLAUDE.md` section 15's classes `PERSONAL`, `FINANCIAL`, and so on, as a policy that decides where a task may run): the add-on's AI tools were already local-first and the personal details hidden; the classes are not written as code.

## Phase 1: why the assistant forgets, and why the screen has a gap (12 October 2026, found by reading the code and by rendering the screen)

Paths are in this repository's layout. "AI" is `apps/pos-ai-companion/src/SmartRetail.AI.Core`, "Web" is `apps/pos-dashboard-service/src/SmartRetail.Pos.Web`.

### The conversation: five causes, one chain

1. **The history never reaches the model.** `Conversation` keeps every message in a list, but when a question is asked it passes the backend **only the question text** (`Assistant/Conversation.cs`, `Start(...)` calls `_backend.AskAsync(question, progress, token)`; the interface `IChatBackend.AskAsync(string question, ...)` has no place for earlier turns). `BusinessChatBackend` makes a **new `BusinessAssistant` for each question** and `BusinessAssistant.AskAsync(question, ...)` builds both prompts from that question alone (`Assistant/Prompts.cs`: `SqlRequest` and `AnswerRequest`). The chat on the screen is a picture of a memory that the model does not have. This alone explains "Yes, tell me" being answered as a fresh question.
2. **The model is given the wrong job.** The prompt makes it *"the data analyst"* that must turn the owner's question into ONE SQL query; the only other exit is `"sql": null` with a one-sentence explanation. So a question that is not a data question (advice about e-rickshaw posters) can only be refused, and a follow-up with no data in it ("Yes, tell me") becomes "please say what you want to know about the shop". The refusal wording in the owner's example is the model's own, written because the prompt leaves it no other way to answer. Every question is treated as a data question first, and the shop's database layout is read before the model is even asked (`GetSchemaAsync`).
3. **The providers are stateless on purpose, which is fine.** An `AiRequest` is a system prompt and a user prompt (`Providers/AiProvider.cs`); Codex runs `exec --ephemeral` (`CodexCliProvider.cs`) and its app server starts an `ephemeral` thread each time (`CodexAppServer.cs`). That is right for privacy, and it means the application must put the context into every prompt itself. It does not, so the providers are not where the bug is, and they need no change: the same context works for Codex, Claude, Gemini, the API providers and a custom tool.
4. **A saved chat is never used as context, and a restart starts empty.** `ChatHistoryService` writes the chat after every answer (`Memory/ChatHistory.cs`, a file a month, personal details hidden, kept six months, searchable), and `PastChat` can show it and ask a question again, but nothing reads a saved chat back into the live `Conversation`, and the live `Conversation` (a singleton in `Web/Program.cs`) is empty after the app starts. The record exists; the chat does not resume.
5. **Long-term memory is only the owner's two short lists.** `MemoryStore`/`MemoryRules` keep a *Shop* part (2,200 characters) and an *Owner* part (1,375), at most 300 characters per entry, suggested by the AI after a chat and saved when the owner agrees, with undo (`Memory/MemoryReviewer.cs`). It goes into every prompt, which is right, but it is not a conversation, and it cannot hold a project, a campaign or a plan.

*Small things found on the way:* the 30-minute cache of the shop's database layout lives in `BusinessAssistant`, which is made anew for every question, so it never helps (the layout is read again each time); a failed or stopped question leaves a "Something went wrong" or "Stopped." message in the list, which must not be fed back into a prompt as if it were an answer; the demo shop's chat (`Web/Services/DemoChatBackend.cs`) is a general advisor, but it is also memoryless.

*Not the cause (checked):* dependency-injection lifetimes (`Conversation`, the backend and the history service are singletons, so the app window and the side panel share one chat); memory compaction (nothing compacts a chat today; the memory review only runs when a chat ends); switching providers (the router keeps the provider that wrote the query for the rest of that question, and there is no history to lose); the Codex session settings (see 3).

### The empty band under the question box

Rendered in Chromium with the real `app.css` and the real element structure of the screen (`scratchpad/layout/measure.mjs`, six window sizes, with and without the app window's own top bar): the question box sits **88 to 92 px above the bottom of the window** when the page opens (62 to 66 px of it under the small "The AI can make mistakes" line), and **44 px** above it while a long chat is being read, so it also jumps by 44 px as the reader scrolls. *Cause:* `.content { padding: 28px 36px 44px }` (`Web/wwwroot/app.css`, line 551) keeps 44 px of padding under every page; `.chat` is sized to exactly fill what is left (`min-height: calc(100vh - 72px - var(--frame))`, line 1436, where 72 = 28 + 44); and the composer is `position: sticky; bottom: 0` **inside** `.chat` (line 1528), so it can only stick to the bottom of the chat, never to the bottom of the window, and the page's own bottom padding, the composer's 18 px padding and the footnote all stack up under the box. The two media queries that change the page padding (lines 2137 and 2179) leave the `72px` in `.chat` wrong, so the gap also differs by window width. *Not the cause:* the Windows taskbar (the app window is placed inside the screen's work area, `AppWindow.cs`). The owner's screenshots were not part of the text that reached the assistant; this was reproduced from the code, not from the pictures.

### What already exists and is reused

| Wanted by the brief | Already in the repository | Plan |
|---|---|---|
| Shop memory (layer C) | `Memory/MemoryStore`, `MemoryRules`, `MemoryReviewer`, the Memory page: view, correct, forget, undo, owner approval | extend (projects and decisions as a third part), keep its rules |
| Past chats, search | `Memory/ChatHistory` and the Past chats pages | resume a chat; use it as context |
| Marketing record | `Pos.Core/Actions/ShopAction` (an "Advertising" action with dates, cost, products, what was expected, a lesson), `ActionMeasure` (sales before and after, read-only), the Actions page, `ActionService` | campaigns are built on it, not beside it |
| Growth plan, Monday review, playbooks | `GrowthPlanService`, `MondayReview`, `Memory/Playbooks` | linked from the chat and from campaigns |
| Posters, creative drafts | `PosterService`, `CreativeService` | called from a campaign |
| Read-only shop data | `Data/SqlGuard`, a rolled-back transaction, `PiiMasker` | kept and tested harder |
