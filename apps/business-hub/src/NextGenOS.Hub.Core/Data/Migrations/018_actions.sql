-- Typed actions with approval (blueprint ACT-012 and ACT-013). NEW TABLES ONLY; nothing that exists is changed.
--   actions             one row for each thing that was asked for in the closed list of typed actions (today: a draft order to a supplier): what exactly was asked (the input, kept as it was
--                       given), the facts it was judged on (and a fingerprint of them), a plain-words description of what would happen, who asked and when, when the request runs out, who
--                       approved or declined and when, what came of it, and where it came from (for example a "running low" warning). The status moves only along the lines the program allows.
--   action_transitions  every step the status took, with who took it, the permission that allowed it, why, and what it rested on. Only ever added to.
-- Every table carries tenant_id and site_id. The way back is Data/Rollbacks/018_actions.sql.

CREATE TABLE actions (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  action_id TEXT NOT NULL, version INTEGER NOT NULL,
  status TEXT NOT NULL CHECK (status IN ('proposed', 'validated', 'awaiting_approval', 'approved', 'executing', 'succeeded', 'failed', 'cancelled', 'expired')),
  input TEXT NOT NULL, bound TEXT NOT NULL, bound_hash TEXT NOT NULL, summary TEXT NOT NULL,
  proposed_by INTEGER, proposed_at TEXT NOT NULL, expires_at TEXT NOT NULL,
  source_type TEXT, source_id INTEGER, idempotency_key TEXT,
  decided_by INTEGER, decided_at TEXT, decision_note TEXT,
  executed_at TEXT, result TEXT, error TEXT,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE UNIQUE INDEX ux_actions_key ON actions(tenant_id, site_id, idempotency_key) WHERE idempotency_key IS NOT NULL;
CREATE INDEX ix_actions_status ON actions(tenant_id, site_id, status, id);

CREATE TABLE action_transitions (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL, action_row INTEGER NOT NULL,
  at TEXT NOT NULL, from_status TEXT, to_status TEXT NOT NULL, actor_id INTEGER, actor_label TEXT NOT NULL, permission TEXT, reason TEXT, evidence TEXT,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_action_transitions_row ON action_transitions(tenant_id, site_id, action_row, id);
