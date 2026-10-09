-- The way back from 021_qty_bands.sql: drops the quantity bands. Lines already on bills keep the discount a band gave them (their source reads 'band' and nothing else changes). Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_item_qty_bands_item;
DROP TABLE IF EXISTS item_qty_bands;
