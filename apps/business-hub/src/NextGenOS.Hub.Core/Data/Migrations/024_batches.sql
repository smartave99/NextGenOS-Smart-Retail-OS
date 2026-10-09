-- Batch numbers and expiry dates (docs/old-programs/01 section 6.2 and 6.8, 02 A2: the older POS kept stock "per lot" with a batch number and dates). Only added; nothing that exists is changed.
--   items.track_batches       0 for every item that exists (and for every item the shop does not switch on): such an item behaves exactly as before. 1: the item's stock is kept in batches.
--   item_batches              one row for each batch of an item: its number, when it was made and when it expires. A batch is made by a delivery (a purchase line that names it) or by a count.
--   stock_moves.batch_id      which batch a move of stock was in (null for an item that keeps no batches). The stock of a batch is the sum of its moves; the stock of the item is still the sum of all
--                             its moves, so costs and values (decision 36) are worked out as before and only share a move among batches afterwards.
--   document_lines.batch_no / mfg_on / exp_on   what a purchase line says about the batch that arrived with it.
-- The way back is Data/Rollbacks/024_batches.sql.
ALTER TABLE items ADD COLUMN track_batches INTEGER NOT NULL DEFAULT 0;
ALTER TABLE stock_moves ADD COLUMN batch_id INTEGER;
ALTER TABLE document_lines ADD COLUMN batch_no TEXT;
ALTER TABLE document_lines ADD COLUMN mfg_on TEXT;
ALTER TABLE document_lines ADD COLUMN exp_on TEXT;
CREATE TABLE item_batches (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  item_id INTEGER NOT NULL REFERENCES items(id), batch_no TEXT NOT NULL, mfg_on TEXT, exp_on TEXT, created_at TEXT NOT NULL);
CREATE UNIQUE INDEX ux_item_batches_no ON item_batches(item_id, batch_no);
CREATE INDEX ix_stock_batch ON stock_moves(batch_id);
