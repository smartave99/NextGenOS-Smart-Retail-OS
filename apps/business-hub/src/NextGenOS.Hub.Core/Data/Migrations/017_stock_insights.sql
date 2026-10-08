-- Running low against the supplier's delivery time (blueprint INS-011). NEW TABLES ONLY; nothing that exists is changed.
--   supply_terms      for an item that is bought in: who supplies it, how many days they take to deliver, how many spare days the owner wants, the pack it comes in and the least they will send.
--                     A person typed these in (and is named), so the rule trusts them; an item without them is never judged, only listed as "no delivery time yet".
--   insight_settings  what a rule is told to use (how many days of selling it looks at, how many days an order should cover beyond the delivery time ...), kept as data, one row per rule.
--   insight_runs      each time a rule was run: which rule and version, the moment it was run as of, the settings used and a fingerprint of everything it looked at and how many items were judged
--                     or left out (and why), so the same figures always give the same answer and a run can be shown again as it was.
--   insight_findings  what a run found, with the figures and the reasons it rests on, and what a person did about it (still open, set aside, replaced by a later run, acted on).
-- Every table carries tenant_id and site_id. The way back is Data/Rollbacks/017_stock_insights.sql.

CREATE TABLE supply_terms (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  item_id INTEGER NOT NULL REFERENCES items(id), supplier_id INTEGER NOT NULL REFERENCES parties(id),
  lead_days INTEGER NOT NULL CHECK (lead_days BETWEEN 0 AND 365),
  safety_days INTEGER NOT NULL DEFAULT 0 CHECK (safety_days BETWEEN 0 AND 365),
  pack_milli INTEGER NOT NULL DEFAULT 1000 CHECK (pack_milli > 0),
  min_order_milli INTEGER NOT NULL DEFAULT 0 CHECK (min_order_milli >= 0),
  entered_by INTEGER, entered_at TEXT NOT NULL,
  PRIMARY KEY (tenant_id, site_id, item_id));

CREATE TABLE insight_settings (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  rule_id TEXT NOT NULL, settings TEXT NOT NULL, updated_at TEXT NOT NULL, updated_by INTEGER,
  PRIMARY KEY (tenant_id, site_id, rule_id));

CREATE TABLE insight_runs (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  rule_id TEXT NOT NULL, rule_version TEXT NOT NULL, as_of TEXT NOT NULL, settings TEXT NOT NULL, inputs_hash TEXT NOT NULL,
  items_checked INTEGER NOT NULL, items_flagged INTEGER NOT NULL, summary TEXT NOT NULL, created_at TEXT NOT NULL, created_by INTEGER,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_insight_runs_rule ON insight_runs(tenant_id, site_id, rule_id, id);

CREATE TABLE insight_findings (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  run_id INTEGER NOT NULL, rule_id TEXT NOT NULL, rule_version TEXT NOT NULL,
  subject_type TEXT NOT NULL, subject_id INTEGER NOT NULL,
  status TEXT NOT NULL, payload TEXT NOT NULL,
  state TEXT NOT NULL DEFAULT 'open' CHECK (state IN ('open', 'dismissed', 'superseded', 'actioned')),
  created_at TEXT NOT NULL, decided_at TEXT, decided_by INTEGER, decision_note TEXT,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_insight_findings_run ON insight_findings(tenant_id, site_id, run_id);
CREATE INDEX ix_insight_findings_subject ON insight_findings(tenant_id, site_id, rule_id, subject_type, subject_id, state);
