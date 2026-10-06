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
