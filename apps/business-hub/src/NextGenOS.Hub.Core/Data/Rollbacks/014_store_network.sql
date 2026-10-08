-- The way back from 014_store_network.sql: drops only the tables that migration made. Counter PCs that were paired lose their pairing (they must be paired again after a new
-- forward run); nothing of the shop's own records is touched. Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_network_devices_token;
DROP TABLE IF EXISTS network_devices;
DROP INDEX IF EXISTS ix_network_codes_live;
DROP TABLE IF EXISTS network_pairing_codes;
