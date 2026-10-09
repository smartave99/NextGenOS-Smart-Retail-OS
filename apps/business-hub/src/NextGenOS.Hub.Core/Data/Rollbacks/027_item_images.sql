-- The way back from 027_item_images.sql: forgets the pictures of items. Items and bills are untouched. Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_item_images_item;
DROP TABLE IF EXISTS item_images;
