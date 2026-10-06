# Version 2: the Business Operating System

The owner's direction for the second version, kept here so that nobody has to repeat it. The rules that bind every assistant and person are in `CLAUDE.md`, section 15; the inspection of the code is `docs/V2-ARCHITECTURE-ASSESSMENT.md`; what is left is `docs/OPEN-WORK.md`.

## The idea

The product grows from point-of-sale and stock software into a **real-time business operating system**, without rebuilding the shop program: it keeps every workflow, its data integrity, its screens and its compatibility, and learns to understand people, products, stock, customers, anonymous visitor sessions, staff, suppliers, places, shelves, counters, devices, transactions, payments, tasks, documents, cameras and sensors.

```
physical world + digital systems
        -> observations -> events -> ontology
        -> current business state (digital twin) -> analytics
        -> AI reasoning -> predictions -> recommended or automated actions
```

**The shop program works with every AI service switched off.** AI improves it and is never a dependency of checkout, payment recording, receipts, stock movement for a sale, or sign-in.

## Principles (they decide every trade-off)

1. **Local first.** Local data, database, events, embeddings, analytics, ontology and (where the hardware allows) inference and camera processing. Business data, CCTV, customer activity, invoices, stock, audio and documents are never sent to an outside AI provider unless the owner chose it. Cloud AI is optional.
2. **Replaceable models.** One provider layer; no vendor name in business logic. The long-term value is the ontology, the event history, the integrations, the rules, the current state, the feedback data, the permissions, the audit trail and the customer's own knowledge.
3. **Privacy routing.** Every AI task has a data class (`PUBLIC`, `INTERNAL`, `CONFIDENTIAL`, `PERSONAL`, `FINANCIAL`, `VIDEO`, `AUDIO`, `BIOMETRIC`, `PAYMENT_SENSITIVE`). A policy decides where it may run: `PAYMENT_SENSITIVE` never leaves the device; raw CCTV stays local; customer personal data stays local unless specifically authorised; anonymous aggregates may go to a remote provider if configured. Organisations can write their own policies. Default order: local model, local optimised model, LAN inference server, the owner's CLI provider, the owner's API provider, unless the owner changes it. A remote provider is used only if the owner permitted that data class for that provider and feature, and the owner is told in plain words what may leave, to whom, and for which features.
4. **Hardware-adaptive.** Detect the machine, pick a profile (`LIGHT_LOCAL`, `STANDARD_LOCAL`, `GPU_LOCAL`, `HEAVY_GPU`, `EDGE_SERVER`, `ENTERPRISE_SERVER`), load models on demand, unload when idle, never load everything at once, and never let AI slow the till (checkout always has priority).
5. **Observation is not event.** A model's raw output is an *observation*; an *event* is inferred from observations, rules and POS data, with a confidence and a recorded reason. Events are immutable; a correction is a new superseding, verification or correction record, never a silent rewrite.
6. **Provenance.** Every AI-derived conclusion records model, version, runtime, confidence, input references, time, pipeline and rule version, evidence and human verification, so "why does the system believe this happened?" always has an answer.
7. **Evidence and retention.** Evidence (image, clip, audio, document, sensor reading, scan) is referenced by events, kept only as long as the organisation's configured retention, and raw continuous video is off by default.
8. **Anonymous by default.** Physical customer tracking uses anonymous session ids; no permanent biometric identification; no facial recognition as a default dependency; retention and deletion controls exist.
9. **The assistant obeys the application's permissions.** It queries structured data through controlled tools (never free semantic guessing), checks the same RBAC as the person asking (a cashier who cannot see profit cannot get it from the assistant), and any consequential action (refund, deleting a transaction, changing stock or a price, a supplier order, a message to a customer, changing permissions) is only recommended until a person approves, unless an administrator configured a safe automation rule.
10. **Everything is audited**, including AI provider changes, AI actions, corrections, exports, permission, rule and model changes, and automation actions; records should resist tampering.
11. **No hidden spending.** External providers have monthly, daily, per-user and per-feature budgets, token and request limits, allowed models and allowed data classes; usage is shown.
12. **Secrets** live in the operating system's credential store (Windows Credential Manager, macOS Keychain, Linux Secret Service) or an encrypted vault: never in plaintext, never in logs, masked on screen, never in the repository.
13. **Feature flags** for every major capability (`ai_assistant`, `camera_analytics`, `local_embeddings`, `remote_ai`, `business_ontology`, `event_engine`, `predictive_inventory`, `advanced_rules`), so rollout and rollback are safe.
14. **Multi-business ready.** Organisation, site, zone and device scoping from the start of every new table; tenant data never leaks between organisations; the edge instance works offline and syncs events, aggregates, configuration and alerts (never raw video by default) with idempotency and clock-drift handling.
15. **Honesty.** Never fake an integration; never call a placeholder production-ready; if something cannot be built properly yet, build the interface and document what is missing (`CLAUDE.md` section 2).

## Vocabulary

- **Observation:** something a model or sensor saw (a box around a hand, a product leaving a shelf).
- **Event:** a business fact derived from observations and rules (`customer_session.picked_up_product`), with who or what, did what, to what, where, when, with what confidence, based on which evidence, detected by which model or system.
- **Ontology:** the objects of the business (organisation, site, zone, actor, product, shelf, device, order, payment, task, document, policy...) and their relationships (customer PURCHASED product, camera OBSERVES zone, supplier SUPPLIES product, event SUPPORTED_BY evidence). Relationships are data. The existing Hub tables map into it; no duplicate "AI product".
- **State (digital twin):** what is true now, projected from events (a shelf's estimated quantity, a checkout's queue, a device's health).

## Phases

| Phase | Content | State |
|---|---|---|
| 0 | Repository understanding | **Done**: `docs/V2-ARCHITECTURE-ASSESSMENT.md` |
| 1 | AI foundation: hardware detection, provider interfaces and registry, model configuration, secure key storage, feature flags, privacy routing policy, consent, the AI settings tab | In progress |
| 2 | Event foundation: universal event schema, event store, provenance, event APIs and viewer | Not started |
| 3 | Ontology foundation: entities, relationships, mapping of the existing POS objects, APIs | Not started |
| 4 | Business intelligence: projections, current state, rules engine, analytics | Not started |
| 5 | Embeddings and local knowledge: local embedding provider, vector abstraction (pgvector, Qdrant behind an interface), document ingestion, RAG with source references | Not started |
| 6 | The assistant: local LLM, routing, controlled query tools, permission enforcement, human approval | Not started |
| 7 | Camera intelligence: registry, streams (RTSP, ONVIF, USB, file), detection and tracking, observations, event inference with configurable thresholds | Not started |
| 8 | Advanced: VLM escalation, predictions, anomaly detection, workflow agents, model evaluation and promotion (candidate, testing, shadow, active, deprecated, rolled back) | Not started |

Larger infrastructure (Kafka or Redpanda, ClickHouse, Kubernetes, MinIO) is not introduced until the scale needs it; the interfaces leave room for it. Migrations use the project's own system, are reversible where practical, and never drop a production column or table.
