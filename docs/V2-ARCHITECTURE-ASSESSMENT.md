# Version 2: architecture assessment (Phase 0)

Written 6 October 2026 from a read-only inspection of the repository (three assistants and a review of the code). **Nothing in the Hub parts was built or run for this inspection**; test counts below are counts of tests in the source, not results. The direction and the rules are in `docs/VERSION-2.md` and `CLAUDE.md`, section 15.

## 1. What exists today

| Program | What it is | Relevant facts |
|---|---|---|
| **Business Hub** (`apps/business-hub`) | The new shop program for every kind of business. C# on .NET 10, Blazor Server, Kestrel on `127.0.0.1:5280`; a Windows service (NSIS setup) or a systemd service (.deb). | SQLite (`shop.db`) with raw parameterised SQL, no ORM. One database is one shop. Forward-only numbered SQL migrations (`Core/Data/Migrations`, only `001_initial.sql` so far). Cookie sign-in, 5 fixed roles, 14 permissions as ASP.NET policies. `audit_log` table. Hand-wired services in `Core/HubApp.cs`. One licensed background worker. No REST API for the UI (pages call services in-process). No AI. |
| **Windows POS** (`apps/pos-desktop`) | The older VB.NET shop till (India GST), SQL Server. | Decompiled source; its schema survives only in the AI add-on's `Data/PosSchemaData.cs` and a test fixture (the original `DBscript.sql` is not in the repository). |
| **AI add-on** (`apps/pos-ai-companion`) | C# (net48 + net8) assistant beside the Windows POS. | Eight providers behind `IAiProvider` (3 CLI, 4 API incl. an OpenAI-compatible one defaulting to Ollama, 1 custom CLI) and a router with fallback; per-job model and thinking level (`AiJob`); keys protected with Windows DPAPI; `SqlGuard` (one SELECT on approved tables), `PiiMasker`; reads the POS database read-only. About 540 tests. |
| **Dashboard** (`apps/pos-dashboard-service`) | .NET 10 Blazor web dashboard for the Windows POS. | Product search by camera photo: DINOv2 as ONNX on CPU, downloaded once on the owner's request, size and SHA-256 pinned. Supabase "owner's live view". |
| **Storefront** (`apps/storefront-web-mobile`) | Next.js website and Android app. | Own LLM routing, Gemini embeddings into Postgres pgvector, Groq speech and vision. |
| **Setup Studio / Licence Studio** (`tools/`, `licensing/`) | Node programs for NextGenOS staff and the owner. | Setup Studio: seven AI adapters, keys in a plaintext file (mode 0600). |

## 2. What the vision needs, and what exists

| Need (from `docs/VERSION-2.md`) | Today |
|---|---|
| Hardware capability detection | **None** for AI (only a licence fingerprint, disk space, and ONNX fixed at 2 threads). |
| One provider-agnostic AI layer | **Three separate stacks** (C#, Node, TypeScript) with different default models and no shared contract. |
| Secure secrets | **Four mechanisms**: DPAPI (Windows only), plaintext key file, AES-GCM with an environment key, environment variables. The Hub has none. |
| Privacy routing by data class | None. The add-on masks some columns and Indian phone numbers and e-mails (`PiiMasker`). |
| AI job queue with priorities | None shared: four one-at-a-time queues in separate features, a usage-limit pause for one CLI. |
| Events, observations, provenance | None. The Hub's `audit_log` is written inside the checkout transaction and is the nearest thing to an event feed. |
| Ontology / relationships | None. Industry packs (`industry-packs/packs/*.json`) have an `aiContext` phrase that nothing uses. |
| Multi-tenancy (organisation, site, zone, device) | **None**: one database is one shop; no such ids anywhere. |
| Feature flags | None general: per-industry "features" with owner overrides, a fixed switch in `ShopContext.SetFeature`. |
| Cost and usage tracking, AI audit | None (only a Codex limit percentage). |
| Camera analytics | Browser stills only (barcode and product photo). No RTSP, ONVIF, video, detection, tracking. |
| Vector search | pgvector in the storefront; a JSON file of vectors in the dashboard. Not in the Hub. |

## 3. Decisions

1. **The host is the Business Hub.** It is the program for every kind of business, the one that is white-label and runs on Windows and Linux, and it already has the licence gate, users, permissions and an audit log. The Windows POS and the AI add-on become **source systems** later (their read-only adapters feed events), not the host.
2. **New code starts inside `NextGenOS.Hub.Core` (folder `Ai/`)**, written so that it depends on nothing of the Hub except a small database interface, so it can move to `libs/dotnet` when the add-on or the dashboard needs it. A new assembly now would add a new program to hide (Obfuscar) and to audit, for no gain yet.
3. **The existing C# providers are adopted by adapter later, not rewritten.** Phase 1 adds the contracts and one real adapter (an OpenAI-compatible endpoint, which covers Ollama, llama.cpp, vLLM, a LAN server and OpenRouter).
4. **New tables only, and every one carries `tenant_id` and `site_id`** (defaults `local` and `main`). Nothing existing changes. Retrofitting these ids later would touch every table and query.
5. **Everything starts off.** Every AI feature flag defaults to off; no model is downloaded; no network call is made unless the owner has configured a provider and consented to the data classes it may receive.
6. **The licence module `ai` already exists** in the format (plans `business` and above). The Hub starts checking it for the AI settings; no format change, so no change to the three licence libraries (`CLAUDE.md` section 4).
7. **One secret store contract.** Windows Credential Manager on Windows; an encrypted vault file elsewhere; never plaintext (`CLAUDE.md` section 15).
8. **Migrations get a safety net first:** a copy of `shop.db` before any pending migration runs, and a tested "down" script for every new migration (forward-only, no backup, and untested upgrades today).

## 4. Exact integration points (Business Hub)

| What | Where |
|---|---|
| Register services | `HubHost.AddHub` (singleton `HubApp` plus auth, branding, licence) or the `HubApp` constructor in `Core/HubApp.cs` |
| Schema | a new numbered file in `Core/Data/Migrations/` (embedded, picked up by `HubDb.Migrate`) |
| Permission | a `Perm` constant, then `Roles.Grants` and `Permissions.All` (both lists by hand) |
| Settings | `SettingsStore.GetText/SetText` with a namespaced key; a new tab in `Components/Pages/Settings.razor` (`Tabs()`) |
| Background work | `AddLicensedWorker<T>` only (the gate fails on `AddHostedService<` in `HubHost.cs`) |
| Endpoints | a static `Map(app)` like `DeviceEndpoints`, called from `UseHub`, with `RequireAuthorization` and manual antiforgery |
| Licence | `LicenceState.HasModule("ai")` through `ProductLicence` |
| Reading checkout data without touching it | poll `documents`, `payments`, `stock_moves`, `audit_log` by id from a licensed worker |

## 5. Debt and blockers that matter

- No event or outbox layer, no idempotency keys (safety comes from status checks and unique constraints).
- No tenancy; limits in the licence (devices, stores, users) are not enforced by the Hub.
- Migrations: forward-only, no checksum, no backup, and the upgrade path has never run on a real old database (only `001` exists).
- `audit_log` is append-only by convention only: no trigger, no hash chain.
- Roles are fixed in code, and services do not check permissions themselves (pages and endpoints do). An AI assistant that calls services directly would skip them: **every AI tool must go through an explicit permission check** (Phase 6).
- Obfuscar renames types and fields: no persisted type names from reflection in new code.
- Anything native or any model file must be bundled and pass `scripts/audit-prerequisites.mjs`; shared tax code must still compile on net48 and C# 10.
- **Findings in the existing AI code that conflict with the rules and must be fixed** (listed in `docs/OPEN-WORK.md`): the add-on's "Ask AI" sends hosted providers customer names, cities, states and remarks (the README says personal data is hidden; names are not), plus the table and column layout, photos and the typed question unmasked, and masking can be switched off; the Setup Studio keeps API keys in a plaintext file; DPAPI secrets cannot be saved on Linux; the add-on's prompts and PII masking are India-specific (`CLAUDE.md` section 8); no AI audit trail or cost tracking exists anywhere.

## 6. The smallest safe Phase 1 (what is built first)

**In:** feature flags (a general mechanism, all AI flags off); a hardware capability service and profile (`LIGHT_LOCAL` to `ENTERPRISE_SERVER`) with honest "unknown" where a probe is not possible; the provider contracts (`LLMProvider`, `EmbeddingProvider`, `VisionProvider`, `SpeechProvider`, `OCRProvider`, `RerankerProvider`, `ObjectDetectionProvider`, `SegmentationProvider`, `TrackingProvider`) and one real adapter (OpenAI-compatible); a provider registry; data classification and a routing policy (local first, never leaving for `PAYMENT_SENSITIVE`, raw video local by default) as pure, tested logic with a recorded reason for every decision; a model registry (what is configured, its status, never an automatic download); a secret store; consent records; the migration (new tables, with a down script and a backup first); an **AI** tab in Settings behind the `ai` licence module and an `ai.manage` permission; audit entries for every change; tests; documentation.

**Out, on purpose:** events, ontology, rules, embeddings, RAG, the assistant, cameras, predictions (Phases 2 to 8); downloading or running a model; any remote call by default; any change to checkout, tax, payment or stock code.

## 6. Phase 1: what was built (and what was not)

Written when Phase 1 was finished in a cloud session. Everything below is in `apps/business-hub/src/NextGenOS.Hub.Core/Ai/` unless it says otherwise, and was run: the Hub's test projects pass (see the gate), and the AI screen was driven in a real Chromium (`apps/business-hub/e2e/ai.e2e.mjs`).

| Piece | What it does | Where it stops |
|---|---|---|
| **Feature switches** (`FeatureFlags.cs`) | Eight switches, all off. A switch counts only when the owner chose it **and** the signed licence has the `ai` module. A host that says nothing about the licence gets "no AI at all". Every change is audited. | Switches exist for capabilities that are not built yet (cameras, events, ontology, forecasts, rules): they do nothing today. |
| **Hardware profile** (`Hardware.cs`) | Looks at memory, processor, graphics cards (NVIDIA's own tool when installed), Apple, Jetson boards and free disk, and says which of six profiles the computer is, with plain-words warnings. What it could not look at is "unknown", never guessed. Cached for five minutes. | Not tried on real GPUs here. AMD and Intel cards on Windows are not measured (DirectML is assumed, and the screen says so in a note). OpenVINO, TensorRT and ONNX Runtime are not probed. NPUs: only a Qualcomm assumption. |
| **Privacy routing** (`Routing.cs`) | A pure function: card details and biometrics never leave this computer; a service on this computer may take anything else; the shop network takes public and internal data and the rest only with the owner's permission; online services also need the "online" switch. Unknown data kinds are refused. A card number found in a text makes it payment data (Luhn check). | Nothing hides or removes names and phone numbers from text sent to an online service the owner allowed; the owner's permission is the only guard for personal data. No per-feature "must stay local" policy beyond what the owner grants. |
| **Where a service really is** (`Endpoints.cs`, `OpenAiCompatible.cs`) | A service said to be "on this computer" must have a loopback address; "in the shop" a private one; online ones need https. The connection itself refuses any address outside the allowed place (looked up at connect time), follows no redirects and uses no proxy inside the shop. | A hostname that resolves to a changing address is checked at every connection, not at every packet. |
| **Secrets** (`Secrets.cs`) | Keys go to the Windows Credential Manager on Windows, or an AES-256-GCM file with its key in a separate owner-only file elsewhere. The database holds only the name. Screens never show a key again; errors are cleaned of keys. | The Windows store was written against the documented calls and is **not run** here (no Windows). The file store does not protect against someone who can already read every file of the Hub's account. |
| **First adapter** (`OpenAiCompatible.cs`) | Chat and embeddings for anything that speaks the common web protocol: Ollama, LM Studio, llama.cpp server, vLLM, a LAN server, OpenRouter, OpenAI. Tried against a real web server on this computer. | Not tried against a real model or a real online account. The command-line assistants (Claude, Codex, Antigravity) and the adapters of the AI add-on are not connected to the Hub yet; speech, vision, OCR, detection and tracking are interfaces only. |
| **Services, permissions, models** (`Providers.cs`, `Models.cs`) | Connect, change, switch on and remove services; allow a kind of data per service (and per feature); move a model through candidate, testing, shadow, in use, retired; roll back to the model before; refuse a model whose licence forbids business use. Moving a service to another address switches it off and takes back its permissions. | Models are only a list: nothing downloads, installs or checks a file yet. No evaluation or comparison runs. |
| **Gateway, usage, limits** (`Gateway.cs`, `Usage.cs`) | One door for business code: licence, switch, privacy rules, limits (requests a day, tokens a month, spending a month), falling back to the next allowed service, and a record of every use, refusal and failure. | No job queue and no priorities: calls are made when asked, one at a time per caller. The record is never pruned. |
| **Database** (`Data/Migrations/002_ai_foundation.sql`, `Data/Rollbacks/002_ai_foundation.sql`, `Data/HubDb.cs`) | Five new tables with `tenant_id` and `site_id`; nothing existing changed. A whole copy of the shop database is made before an update of an existing shop (`VACUUM INTO`), and every new step has a tested way back (`HubDb.Rollback`). | The way back is for the person who looks after the computer; nothing in the program offers it. Never run on a real, old shop database. |
| **Screen** (`Web/Components/Pages/AiSettings.razor`) | **Settings, AI helpers** (owner only): the computer, the switches, services with their permissions, limits and a Test button, models, what was used. | Words are English like the rest of the Hub. |

Not started, by design: the event store, the ontology, projections, rules, embeddings and a vector store, the assistant, cameras and prediction (Phases 2 to 8).

## 7. Phase 2: what was built (and what was not)

Everything is in `apps/business-hub/src/NextGenOS.Hub.Core/Events/` (and the screen in `Web/Components/Pages/EventHistory.razor`). Run: the Hub's test projects, and `apps/business-hub/e2e/events.e2e.mjs` in a real Chromium.

| Piece | What it does | Where it stops |
|---|---|---|
| **Two kinds of record, kept apart** | An **observation** is what a model or a sensor saw (uncertain, plentiful, short-lived, never a business fact). An **event** is a business fact with who or what, which thing, where, when, how sure, why the system believes it, what made it (a rule, a model, a person, the program, an import), and which observations and which evidence it rests on. | The event types are free dotted names (`customer_session.picked_up_product`), not a fixed catalogue: the catalogue and the mapping of the shop's own records into it come with the ontology (Phase 3). |
| **Append-only** (`EventStore.cs`) | Rows are only added. A wrong event is marked rejected; a correction is a new event that points back at the old one, which is marked replaced; both stay and the history reads as it was. The same fact sent twice with the same key is kept once. A record is refused whole when any part is wrong. | Nothing stops someone with the database file from editing it by hand (`audit_log` has the same limit). |
| **Provenance** (`Explain`) | "Why does the system believe this?": what made it and its version, how sure, the explanation text, the observations and evidence it rests on, what it corrects and what replaced it, and how many of its observations have been forgotten since. | The explanation text is written by whatever made the event; the program does not check that it is true. |
| **Evidence is a pointer** | A picture, clip or document is a reference (and a fingerprint) to a file kept elsewhere; the store never holds the content. | Nothing yet keeps those files: the camera storage (Phase 7) will, and deletes what the forgetting lists. |
| **Anonymous by default** (`EventRules`) | People and things are named by opaque references (`track:cam1:17`, `user:5`, `product:123`): a name, an e-mail address or a phone number with spaces is refused. Card and payment details are never kept (refused by kind and by a card-number check in every text part). | A reference could still be built from a person's identity by a careless source (an id that is a phone number without spaces); the first sources are ours. |
| **Retention and forgetting** (`Retention.cs`) | Every record carries the day it may be forgotten, from the owner's rules or short defaults (camera and sound observations 3 days, personal observations 7, other observations 14; events 365, personal 90; evidence 30, camera 7). Biometric data is not kept at all unless the owner writes a number of days (the opt-in). The background worker forgets what is past its day every ten minutes, **whatever the switches say**, and lists the evidence references that were forgotten. | The forgetting is of this program's records; copies in a backup made before the day stay in that backup. |
| **The switch** | Writing needs the owner's switch "Business event history" and the licence's `ai` part; reading, confirming or rejecting, and forgetting do not. | The shop's own sales, voids and stock changes do not write events yet. |
| **Screen** | *Settings, AI helpers, Business events* (owner only): what is kept, a filter by what, start of the type, standing and days, "Why?", "Yes, it happened" and "No, it was wrong" for events that are only proposed, the retention rules, and "forget what is past its time now". | No ingest interface for other programs: an edge box or a camera service will need an authenticated way in (Phase 7 and the edge and cloud work). |
| **Database** (`Data/Migrations/003_event_foundation.sql`) | Five new tables with `tenant_id` and `site_id`, only added, and a tested way back for this step alone. | As for step 2: never run on a real, old shop database. |

## 8. Phase 3: what was built (and what was not)

Everything is in `apps/business-hub/src/NextGenOS.Hub.Core/Ontology/` (and the screen in `Web/Components/Pages/BusinessMap.razor`). Run: the Hub's test projects, and `apps/business-hub/e2e/map.e2e.mjs` in a real Chromium.

| Piece | What it does | Where it stops |
|---|---|---|
| **No second copy of the shop** (`Catalogue.cs`, `MappedSources`) | Seven kinds of thing are the shop's own records and are **read in place** by their number: product (`items`), party (`parties`), user, document, payment, table, project. The map holds no copy, so a renamed product shows its new name at once, and a removed record is reported by the check instead of hidden. | Appointments, loans, library copies, stock movements, kitchen tickets and bill-of-quantity lines are not mapped yet. |
| **Places and devices** | Four kinds exist only in the map because the shop has no table for them: site, zone, shelf, device (a camera is a device). The owner can add more native kinds. Names have a short plain key (`zone:aisle-3`), which is also how events name things. | The map does not yet say where a person or a product is *now* (that is state, Phase 4); a product can be connected to the shelf it is kept on, with no quantity. |
| **Connections are data** (`ontology_relationships`) | Part of, is in, watches, kept on, supplied by (and any kind the owner adds), each with the kinds of thing it may join, the day it began and, once ended, the day it ended. Ended connections stay. A place cannot be put inside itself. Retiring a place ends every connection to it. | No weights, no confidence on connections, and nobody checks that a connection is *true*: it is what a person or a rule said. |
| **Derived connections** (`DerivedRules`) | What the shop's records already say is worked out when asked, never stored twice: a bill was issued to a party and handled by a user, has a line for a product, sits at a table or belongs to a project; a payment pays a bill and was taken by a user; a project is for a client; a bill corrects a bill. Read-only, at most 200 each. | Only the foreign keys the shop already has; nothing is inferred. |
| **Kind of information** | Each kind says what it holds (parties and users: personal; bills and payments: financial; places and products: internal). | Recorded and shown, **not yet enforced**: the assistant (Phase 6) is what will have to obey it. |
| **Screen** | *Settings, AI helpers, Business map* (owner only): places and devices with where each is, connections with a way to end one, connecting two things, looking a thing up (both directions, with "from your records" marked), and a check that nothing points at something that is gone. Events now show names where the map knows them. | No picture of the shop's layout, no drag and drop, no import. |
| **Database** (`Data/Migrations/004_ontology_foundation.sql`) | Four new tables with `tenant_id` and `site_id`; the built-in kinds are written the first time the map is used, as data. A tested way back for this step alone. | As for the earlier steps: never run on a real, old shop database. |

