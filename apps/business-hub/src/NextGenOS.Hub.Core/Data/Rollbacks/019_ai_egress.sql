-- The way back from 019_ai_egress.sql: drops the one table that step made. Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_ai_egress_at;
DROP TABLE IF EXISTS ai_egress_log;
