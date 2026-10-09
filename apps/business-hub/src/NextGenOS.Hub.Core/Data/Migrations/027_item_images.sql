-- Pictures of items (docs/old-programs/02 A2.10: the older POS kept several JPEGs for each product and showed the first on the touch tiles). NEW TABLE only. The pictures are kept in the shop's database
-- (not as files beside it) so that a backup, the copy made before an import, an update and the counter PCs that connect to the main PC all carry them with no extra step. The program checks what a file
-- really is (it does not believe the name it came with) and keeps a few small pictures for each item, not a library.
-- The table carries tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/027_item_images.sql.
CREATE TABLE item_images (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  item_id INTEGER NOT NULL REFERENCES items(id), content_type TEXT NOT NULL, data BLOB NOT NULL, sort_no INTEGER NOT NULL DEFAULT 0, created_at TEXT NOT NULL);
CREATE INDEX ix_item_images_item ON item_images(item_id, sort_no, id);
