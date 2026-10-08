-- The way back from 012_request_key.sql: drops the index and the column that step added. The bills are untouched. Used by HubDb.Rollback, which copies the database first.
DROP INDEX ux_documents_request_key;
ALTER TABLE documents DROP COLUMN request_key;
