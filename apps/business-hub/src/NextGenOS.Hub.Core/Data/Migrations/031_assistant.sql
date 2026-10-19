-- Version 2, Phase 6, step 1: the assistant that answers a question from the shop's own records and notes. NEW TABLE ONLY; nothing that exists is changed.
-- assistant_questions keeps, for each question that was asked, who asked (and in which role), the question, which lookups were made (the name of each and its choices, never what they returned),
-- which notes were pointed at, how it ended and which AI service and model wrote the answer. It does NOT keep the answer or the figures it was made from: those are in the shop's records, and the
-- person who asked could read them there. The program forgets a question after 90 days. Every table carries tenant_id and site_id.
-- The way back is Data/Rollbacks/031_assistant.sql.

CREATE TABLE assistant_questions (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  asked_at TEXT NOT NULL, user_id INTEGER, role TEXT,
  question TEXT NOT NULL, tools TEXT NOT NULL, sources TEXT NOT NULL,
  outcome TEXT NOT NULL, provider_id TEXT, model TEXT, note TEXT,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_assistant_questions_when ON assistant_questions(tenant_id, site_id, asked_at);
CREATE INDEX ix_assistant_questions_user ON assistant_questions(tenant_id, site_id, user_id, asked_at);
