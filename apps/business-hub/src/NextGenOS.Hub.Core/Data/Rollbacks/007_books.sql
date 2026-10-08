-- The way back from 007_books.sql: drops only the tables (and their triggers) that migration made. The bills and payments are untouched and are posted again when the step is run forward.
-- Used by HubDb.Rollback, which copies the database first.
DROP TRIGGER IF EXISTS journal_lines_no_delete;
DROP TRIGGER IF EXISTS journal_lines_no_update;
DROP TRIGGER IF EXISTS journal_entries_no_delete;
DROP TRIGGER IF EXISTS journal_entries_no_update;
DROP INDEX IF EXISTS ix_journal_lines_account;
DROP INDEX IF EXISTS ix_journal_lines_entry;
DROP TABLE IF EXISTS journal_lines;
DROP INDEX IF EXISTS ix_journal_entries_at;
DROP TABLE IF EXISTS journal_entries;
DROP INDEX IF EXISTS ux_accounts_role;
DROP TABLE IF EXISTS accounts;
