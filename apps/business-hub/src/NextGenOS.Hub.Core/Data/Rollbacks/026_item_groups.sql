-- The way back from 026_item_groups.sql: forgets the quick groups. Items and bills are untouched. Used by HubDb.Rollback, which copies the database first.
DROP TABLE IF EXISTS item_group_members;
DROP INDEX IF EXISTS ux_item_groups_barcode;
DROP INDEX IF EXISTS ux_item_groups_name;
DROP TABLE IF EXISTS item_groups;
