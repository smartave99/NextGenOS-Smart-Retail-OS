-- The way back from 006_import_log.sql: drops only the tables that migration made (in the opposite order). Used by HubDb.Rollback, which copies the database first.
-- Items, people and stock that an import added are the shop's own records and stay; only the memory of the import goes (so a later import would add them again).
DROP TABLE IF EXISTS party_opening_balances;
DROP INDEX IF EXISTS ix_import_map_hub;
DROP TABLE IF EXISTS import_id_map;
DROP INDEX IF EXISTS ix_import_runs_at;
DROP TABLE IF EXISTS import_runs;
