-- The way back from 030_knowledge.sql: drops the two tables that step made, with the notes and vectors in them. Nothing of the shop's own records is touched. Used by HubDb.Rollback, which copies
-- the database first (so the notes are in that copy).
DROP INDEX IF EXISTS ix_knowledge_chunks_pending;
DROP TABLE IF EXISTS knowledge_chunks;
DROP INDEX IF EXISTS ux_knowledge_ref;
DROP TABLE IF EXISTS knowledge_sources;
