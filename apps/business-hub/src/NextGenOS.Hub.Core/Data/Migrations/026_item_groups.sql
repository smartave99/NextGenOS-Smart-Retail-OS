-- Quick groups of items (docs/old-programs/02 A2.7: the older POS's "combo packs"). A group is a name, an optional barcode of its own and a list of items with a usual quantity each. Picking it at the till
-- adds every item as a line of its own at its own price; the older program had no bundle price either ("a combo is a quick way to add a group of items, not a bundle price"). NEW TABLES only.
-- The tables carry tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/026_item_groups.sql.
CREATE TABLE item_groups (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  name TEXT NOT NULL, barcode TEXT, active INTEGER NOT NULL DEFAULT 1, created_at TEXT NOT NULL);
CREATE UNIQUE INDEX ux_item_groups_name ON item_groups(tenant_id, site_id, name COLLATE NOCASE);
CREATE UNIQUE INDEX ux_item_groups_barcode ON item_groups(tenant_id, site_id, barcode) WHERE barcode IS NOT NULL;

CREATE TABLE item_group_members (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  group_id INTEGER NOT NULL REFERENCES item_groups(id), item_id INTEGER NOT NULL REFERENCES items(id), qty_milli INTEGER NOT NULL CHECK (qty_milli > 0),
  PRIMARY KEY (group_id, item_id));
