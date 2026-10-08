-- The way back from 011_party_tax_id.sql: drops the column that step added. The bills are untouched. Used by HubDb.Rollback, which copies the database first.
ALTER TABLE documents DROP COLUMN party_tax_id;
