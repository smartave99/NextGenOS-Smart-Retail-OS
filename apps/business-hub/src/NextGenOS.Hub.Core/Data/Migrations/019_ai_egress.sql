-- What left this computer for an AI service, field by field (blueprint AI-014). NEW TABLE ONLY; nothing that exists is changed.
--   ai_egress_log  one row for each request made through a purpose on the closed list of egress purposes, also the refused ones: which service and model, where it runs, the purpose and the
--                  feature, the kind of data, the version of the owner's permission it relied on (when it was given), WHICH FIELDS were sent (name, kind of data, length) and which supplied
--                  fields were left out, what it cost and how it ended. It never holds a value that was sent, a reply, a name, an address or a number of a person.
-- Carries tenant_id and site_id. The way back is Data/Rollbacks/019_ai_egress.sql.

CREATE TABLE ai_egress_log (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', at TEXT NOT NULL,
  provider_id TEXT, model TEXT, location TEXT, purpose TEXT NOT NULL, feature TEXT NOT NULL, data_class TEXT NOT NULL, consent_version TEXT,
  fields TEXT NOT NULL, dropped TEXT NOT NULL, outcome TEXT NOT NULL CHECK (outcome IN ('ok', 'failed', 'refused', 'over-budget')),
  tokens_in INTEGER NOT NULL DEFAULT 0, tokens_out INTEGER NOT NULL DEFAULT 0, cost_micros INTEGER NOT NULL DEFAULT 0, detail TEXT, user_id INTEGER);
CREATE INDEX ix_ai_egress_at ON ai_egress_log(tenant_id, site_id, at);
