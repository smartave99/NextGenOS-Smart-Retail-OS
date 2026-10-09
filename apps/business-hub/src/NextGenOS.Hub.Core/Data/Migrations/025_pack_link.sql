-- Selling loose from a pack (docs/old-programs/02 A2.3: the older POS gave a product an alternate unit and "pieces in one main unit"). The Hub does it with two items instead of a conversion, so that stock
-- of both is exact: the loose item (a piece) is linked to the item it comes out of (a box or a pack), and when a sale needs more pieces than are on the shelf, whole packs are opened by themselves.
-- Only added; nothing that exists is changed.
--   items.pack_item_id    on the loose item: the item whose packs it is opened from (null: not sold loose).
--   items.per_pack_milli  on the loose item: how many pieces one pack holds, in thousandths (12000 = twelve).
-- The way back is Data/Rollbacks/025_pack_link.sql.
ALTER TABLE items ADD COLUMN pack_item_id INTEGER;
ALTER TABLE items ADD COLUMN per_pack_milli INTEGER;
