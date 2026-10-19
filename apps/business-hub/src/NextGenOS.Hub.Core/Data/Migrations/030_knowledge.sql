-- Version 2, Phase 5, step 1: the owner's own notes as local knowledge, searched by words, and by meaning when a local AI service can make the vectors. NEW TABLES ONLY; nothing that exists is changed.
-- knowledge_sources holds one row for each note (a title, the kind of information it holds, a fingerprint of its text and who wrote it); knowledge_chunks holds the note's text in short pieces and,
-- once an AI service has made them, each piece's vector (a list of numbers) with the name of the model that made it. A vector is nothing the shop depends on: with every AI service off, the
-- notes are still kept and found by their words. A note that is retired loses its text and its vectors; only the row that says it existed stays (and the audit record of who did it).
-- Vectors of different models are never compared with each other (the model's name is kept with each). Every table carries tenant_id and site_id.
-- The way back is Data/Rollbacks/030_knowledge.sql.

CREATE TABLE knowledge_sources (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  ref TEXT NOT NULL, kind TEXT NOT NULL, title TEXT NOT NULL, data_class TEXT NOT NULL,
  content_sha256 TEXT NOT NULL, chars INTEGER NOT NULL,
  created_at TEXT NOT NULL, created_by INTEGER, updated_at TEXT NOT NULL, updated_by INTEGER, retired_at TEXT,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE UNIQUE INDEX ux_knowledge_ref ON knowledge_sources(tenant_id, site_id, ref);

CREATE TABLE knowledge_chunks (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', source_id INTEGER NOT NULL, seq INTEGER NOT NULL,
  text TEXT NOT NULL, vector BLOB, model TEXT, dims INTEGER, embedded_at TEXT,
  PRIMARY KEY (tenant_id, site_id, source_id, seq));
CREATE INDEX ix_knowledge_chunks_pending ON knowledge_chunks(tenant_id, site_id, embedded_at);
