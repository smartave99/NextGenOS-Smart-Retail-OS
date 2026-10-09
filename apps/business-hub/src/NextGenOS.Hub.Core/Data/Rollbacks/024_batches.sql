-- The way back from 024_batches.sql: forgets the batches. Every move keeps its quantity and value, so the stock of every item is the same as before; only which batch it was in is lost. Used by
-- HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_stock_batch;
DROP INDEX IF EXISTS ux_item_batches_no;
DROP TABLE IF EXISTS item_batches;
ALTER TABLE document_lines DROP COLUMN exp_on;
ALTER TABLE document_lines DROP COLUMN mfg_on;
ALTER TABLE document_lines DROP COLUMN batch_no;
ALTER TABLE stock_moves DROP COLUMN batch_id;
ALTER TABLE items DROP COLUMN track_batches;
