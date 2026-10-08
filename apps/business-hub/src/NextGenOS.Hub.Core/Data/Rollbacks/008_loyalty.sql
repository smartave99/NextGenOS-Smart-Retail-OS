-- The way back from 008_loyalty.sql: drops the points table (and its triggers) and the two columns that migration added. The bills are untouched. Used by HubDb.Rollback, which copies
-- the database first.
ALTER TABLE documents DROP COLUMN loyalty_discount_minor;
ALTER TABLE documents DROP COLUMN loyalty_points_used_cent;
DROP TRIGGER IF EXISTS loyalty_ledger_no_delete;
DROP TRIGGER IF EXISTS loyalty_ledger_no_update;
DROP INDEX IF EXISTS ix_loyalty_document;
DROP INDEX IF EXISTS ix_loyalty_party;
DROP TABLE IF EXISTS loyalty_ledger;
