-- The way back from 025_pack_link.sql: forgets which items are sold loose from which. Packs already opened stay opened (their stock moves are kept). Used by HubDb.Rollback, which copies the database first.
ALTER TABLE items DROP COLUMN per_pack_milli;
ALTER TABLE items DROP COLUMN pack_item_id;
