# AI assistant 2.0: the plan and the state

This file is the working record of the owner's brief of 12 October 2026. **The brief itself is recorded word for word in `docs/OWNER-REQUESTS.md`** (the entry of 2026-10-12). If this file and the brief differ, the brief is right. Read `CLAUDE.md` (sections 3, 15, 16 and 17) first.

## The owner's standing rules for this work

1. **The shop's live database is read-only for the AI, absolutely.** Nothing the AI does, directly or indirectly, writes to the shop program's database, its files, its settings or its business records. Defence in depth, failing closed. The AI may write only its **own** data (chat history, memory, campaigns, tasks, reminders, notes, reports, pictures, snapshots), kept apart from the shop's database. If a read-only database account has to be made by a person, the steps are written down; nothing makes it silently.
2. **No commit, push, publish or deploy of this work without the owner's permission.** The code of this work stays in the working folder until the owner says so. (Recording the owner's words and this file is not code of the assistant and is pushed so that every person and every AI assistant can read it.)
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

## Phases and state

| Phase | What | State |
|---|---|---|
| 1 | Investigation and root causes | begun (12 October 2026) |
| 2 | Conversation repair: context, persistence, prompt assembly, provider independence | not started |
| 3 | Routing: business talk without SQL | not started |
| 4 | Safe tools, projects, tasks, reminders | not started |
| 5 | Marketing and growth: campaigns, e-rickshaw planner, visibility, measurement | not started |
| 6 | Screen: the bottom gap, conversation list, campaign and task links | not started |
| 7 | Verification and the final report | not started |

*(Keep this table and the acceptance list true in the same change as the work, as `CLAUDE.md` section 13 asks.)*
