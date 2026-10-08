-- The business-event outbox (blueprint EVT-009). NEW TABLES ONLY; nothing that exists is changed. Written to inside the very transaction that makes a sale, a return, a payment, a purchase or
-- a stock change, so that the fact and its message either both exist or neither does. A dispatcher in the shop's upkeep takes the committed rows (a few at a time, under a lease that runs
-- out if the program stops half-way), hands each to its consumers, and marks it delivered only after the consumer has kept it. A message can be delivered twice and does no harm: the event
-- store keeps one event for one message (its key is "outbox:<id>"), and outbox_processed remembers what each consumer has already done.
-- Rows are written only while the business event history is switched on (and licensed); with it off nothing is written. Every table carries tenant_id and site_id.
-- The way back is Data/Rollbacks/016_outbox.sql.

CREATE TABLE outbox (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  event_type TEXT NOT NULL, schema_version INTEGER NOT NULL DEFAULT 1,
  aggregate_type TEXT NOT NULL, aggregate_id INTEGER NOT NULL,
  occurred_at TEXT NOT NULL, created_at TEXT NOT NULL,
  actor_id INTEGER, correlation_id TEXT, data_class TEXT NOT NULL, payload TEXT NOT NULL,
  status TEXT NOT NULL DEFAULT 'pending' CHECK (status IN ('pending', 'delivered', 'failed')),
  attempts INTEGER NOT NULL DEFAULT 0, next_attempt_at TEXT NOT NULL, leased_until TEXT, last_error TEXT, delivered_at TEXT,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_outbox_due ON outbox(tenant_id, site_id, status, next_attempt_at);

CREATE TABLE outbox_processed (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', consumer TEXT NOT NULL, outbox_id INTEGER NOT NULL, processed_at TEXT NOT NULL,
  PRIMARY KEY (tenant_id, site_id, consumer, outbox_id));
