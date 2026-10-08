-- The way back from 013_backups.sql: drops the list of tries at a copy. The copies themselves (files in the owner's chosen place) are not touched. Used by HubDb.Rollback, which copies the database first.
DROP TABLE backup_runs;
