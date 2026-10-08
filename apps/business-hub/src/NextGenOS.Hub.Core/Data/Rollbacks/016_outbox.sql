-- The way back from 016_outbox.sql: drops the two tables that step made. The sales, payments and stock changes are untouched, and so are the events already kept in the event history.
-- Used by HubDb.Rollback, which copies the database first.
DROP TABLE IF EXISTS outbox_processed;
DROP INDEX IF EXISTS ix_outbox_due;
DROP TABLE IF EXISTS outbox;
