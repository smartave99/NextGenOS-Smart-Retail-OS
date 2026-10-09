-- The way back from 020_catalog_changes.sql: drops the record of bulk changes. The items keep the prices, tax codes and on-sale flags they have now. Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_catalog_change_items_item;
DROP INDEX IF EXISTS ix_catalog_change_items_change;
DROP TABLE IF EXISTS catalog_change_items;
DROP INDEX IF EXISTS ix_catalog_changes_at;
DROP TABLE IF EXISTS catalog_changes;
