-- Version 2, Phase 4, step 2: automatic rules over the business event history. NEW TABLES ONLY; nothing that exists is changed.
-- A rule is DATA in a fixed shape: "when N or more confirmed events whose type starts with X (each at least this sure) happen about the same thing or place within M minutes, propose an event of type Y".
-- The shape cannot say "do" anything: the only thing a rule ever produces is a PROPOSED event, which waits for a person to confirm or reject it. A rule looks only at events recorded after it was
-- saved, and never at events that rules made. checkpoint_at and checkpoint_id say how far the rule has looked: the 'recorded_at' and the number of the newest event already looked at for its present version
-- (the number breaks a tie between events recorded in the same second, so that a burst of thousands is worked through and never looked at twice from the start).
-- event_rule_firings remembers each firing, so that the same trigger never fires twice (whatever happens to the program in between) and a busy thing does not fire again within the rule's window.
-- Every table carries tenant_id and site_id. The way back is Data/Rollbacks/029_event_rules.sql.

CREATE TABLE event_rules (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  name TEXT NOT NULL, enabled INTEGER NOT NULL DEFAULT 0 CHECK (enabled IN (0, 1)), version INTEGER NOT NULL DEFAULT 1,
  type_prefix TEXT NOT NULL, min_confidence REAL NOT NULL CHECK (min_confidence >= 0 AND min_confidence <= 1),
  min_count INTEGER NOT NULL CHECK (min_count >= 1 AND min_count <= 1000),
  window_minutes INTEGER NOT NULL CHECK (window_minutes >= 1 AND window_minutes <= 10080),
  group_by TEXT NOT NULL CHECK (group_by IN ('subject', 'zone', 'all')),
  then_type TEXT NOT NULL, then_confidence REAL NOT NULL CHECK (then_confidence >= 0 AND then_confidence <= 1), explanation TEXT,
  checkpoint_at TEXT, checkpoint_id INTEGER NOT NULL DEFAULT 0, created_at TEXT NOT NULL, created_by INTEGER, updated_at TEXT NOT NULL, updated_by INTEGER, retired_at TEXT,
  PRIMARY KEY (tenant_id, site_id, id));

CREATE TABLE event_rule_firings (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', rule_id INTEGER NOT NULL, rule_version INTEGER NOT NULL,
  trigger_event_id INTEGER NOT NULL, trigger_recorded_at TEXT NOT NULL, trigger_occurred_at TEXT NOT NULL, group_key TEXT NOT NULL,
  event_id INTEGER, fired_at TEXT NOT NULL,
  PRIMARY KEY (tenant_id, site_id, rule_id, rule_version, trigger_event_id, trigger_recorded_at));
CREATE INDEX ix_rule_firings_group ON event_rule_firings(tenant_id, site_id, rule_id, group_key, trigger_occurred_at);
