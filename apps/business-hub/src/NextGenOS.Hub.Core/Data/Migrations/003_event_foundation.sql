-- Version 2, phase 2: the event foundation. NEW TABLES ONLY (nothing that exists is changed), all of them empty until the owner switches the "business event history" switch on and
-- something is recorded. Two kinds of record are kept apart on purpose:
--   an OBSERVATION is what a model or a sensor saw (a box around a hand): uncertain, plentiful, kept for a short time, never a business fact;
--   an EVENT is a business fact derived from observations and rules ("a customer picked up a product"), with who, what, where, when, how sure, why the system believes it,
--   which observations and which evidence support it, and which rule, model or person made it.
-- Rows are only added. A fact that was wrong is not changed: its status says so (rejected, superseded) and the correction points back at it. Every row carries tenant_id and
-- site_id ('local', 'main'), a data class and the day it may be forgotten (retain_until). The way back is Data/Rollbacks/003_event_foundation.sql.

CREATE TABLE observations (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  kind TEXT NOT NULL,
  source_type TEXT NOT NULL CHECK (source_type IN ('model', 'sensor', 'device', 'system', 'person')),
  source_id TEXT NOT NULL, model_id TEXT, model_version TEXT,
  zone_ref TEXT, subject_ref TEXT, label TEXT,
  confidence REAL NOT NULL DEFAULT 1 CHECK (confidence >= 0 AND confidence <= 1),
  data TEXT, data_class TEXT NOT NULL,
  occurred_at TEXT NOT NULL, recorded_at TEXT NOT NULL, retain_until TEXT NOT NULL,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_observations_time ON observations(tenant_id, site_id, occurred_at);
CREATE INDEX ix_observations_retain ON observations(tenant_id, site_id, retain_until);

CREATE TABLE events (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  type TEXT NOT NULL,
  actor_ref TEXT, subject_ref TEXT, object_ref TEXT, zone_ref TEXT,
  occurred_at TEXT NOT NULL, recorded_at TEXT NOT NULL,
  confidence REAL NOT NULL DEFAULT 1 CHECK (confidence >= 0 AND confidence <= 1),
  status TEXT NOT NULL DEFAULT 'confirmed' CHECK (status IN ('proposed', 'confirmed', 'rejected', 'superseded')),
  made_by_type TEXT NOT NULL CHECK (made_by_type IN ('rule', 'model', 'person', 'system', 'import')),
  made_by_id TEXT NOT NULL, made_by_version TEXT,
  explanation TEXT, data TEXT, data_class TEXT NOT NULL,
  correlation_id TEXT, idempotency_key TEXT, supersedes INTEGER,
  retain_until TEXT NOT NULL, created_by INTEGER,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_events_time ON events(tenant_id, site_id, occurred_at);
CREATE INDEX ix_events_type ON events(tenant_id, site_id, type, occurred_at);
CREATE INDEX ix_events_retain ON events(tenant_id, site_id, retain_until);
CREATE UNIQUE INDEX ix_events_idempotency ON events(tenant_id, site_id, idempotency_key) WHERE idempotency_key IS NOT NULL;

-- SUPPORTED_BY: which observations an event rests on.
CREATE TABLE event_observations (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', event_id INTEGER NOT NULL, observation_id INTEGER NOT NULL,
  PRIMARY KEY (tenant_id, site_id, event_id, observation_id),
  FOREIGN KEY (tenant_id, site_id, event_id) REFERENCES events(tenant_id, site_id, id) ON DELETE CASCADE);

-- Evidence is a POINTER to something kept elsewhere (a picture file, a clip, a document, a record), with its fingerprint so that a changed file is noticed. Never the content itself.
CREATE TABLE event_evidence (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL, event_id INTEGER NOT NULL,
  kind TEXT NOT NULL CHECK (kind IN ('image', 'clip', 'document', 'record', 'transcript')),
  reference TEXT NOT NULL, sha256 TEXT, data_class TEXT NOT NULL, created_at TEXT NOT NULL, retain_until TEXT NOT NULL,
  PRIMARY KEY (tenant_id, site_id, id),
  FOREIGN KEY (tenant_id, site_id, event_id) REFERENCES events(tenant_id, site_id, id) ON DELETE CASCADE);
CREATE INDEX ix_event_evidence_event ON event_evidence(tenant_id, site_id, event_id);
CREATE INDEX ix_event_evidence_retain ON event_evidence(tenant_id, site_id, retain_until);

-- How long each kind of record is kept, by what it is and what kind of data it holds. No row means the default in code. Personal, camera, sound and biometric data have
-- short defaults, and biometric data is not kept at all unless the owner has written a row for it here (that is the opt-in).
CREATE TABLE retention_policies (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  subject TEXT NOT NULL CHECK (subject IN ('observation', 'event', 'evidence')), data_class TEXT NOT NULL,
  days INTEGER NOT NULL CHECK (days >= 1 AND days <= 3650), updated_at TEXT NOT NULL, updated_by INTEGER,
  PRIMARY KEY (tenant_id, site_id, subject, data_class));
