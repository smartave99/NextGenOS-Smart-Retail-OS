-- Changing many items at once, with a record and an undo (docs/old-programs/02-masters-accounting-reports.md, A2.6: bulk price change, bulk tax change, switching items on and off).
-- NEW TABLES only; nothing that exists is changed. The older program changed prices and tax rates in bulk with no record and no undo; here every change is kept, so that it can be read
-- and, while nothing has touched the item since, taken back.
--   catalog_changes        one row for each press of "Change": what kind of change it was ('price', 'tax', 'sale' = switching items on or off sale, or 'undo'), a sentence for a person, who and when.
--                          An undo points at the change it took back (undoes), and the change points at its undo (undone_by).
--   catalog_change_items   one row for each item and field the change touched, with the value before and after, as text ('12500' for a price in minor units, 'GST12' for a tax code, '1' or '0' for on sale).
-- The tables carry tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/020_catalog_changes.sql.
CREATE TABLE catalog_changes (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  kind TEXT NOT NULL CHECK (kind IN ('price', 'tax', 'sale', 'undo')),
  summary TEXT NOT NULL, at TEXT NOT NULL, user_id INTEGER,
  undoes INTEGER REFERENCES catalog_changes(id), undone_by INTEGER REFERENCES catalog_changes(id));
CREATE INDEX ix_catalog_changes_at ON catalog_changes(tenant_id, site_id, at);

CREATE TABLE catalog_change_items (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  change_id INTEGER NOT NULL REFERENCES catalog_changes(id), item_id INTEGER NOT NULL REFERENCES items(id),
  field TEXT NOT NULL CHECK (field IN ('price_minor', 'trade_price_minor', 'tax_code', 'active')),
  old_value TEXT NOT NULL, new_value TEXT NOT NULL);
CREATE INDEX ix_catalog_change_items_change ON catalog_change_items(change_id);
CREATE INDEX ix_catalog_change_items_item ON catalog_change_items(item_id);
