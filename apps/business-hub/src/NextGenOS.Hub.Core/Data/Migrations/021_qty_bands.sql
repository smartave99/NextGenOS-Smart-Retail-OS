-- Quantity discounts: a percent off a line of one item when the quantity bought falls in a band (docs/old-programs/02-masters-accounting-reports.md, A2.8: "Item / Product Discount").
-- NEW TABLE only; nothing that exists is changed. A band is "from this quantity to this quantity (or with no top)": quantities are in thousandths, the percent in thousandths of a percent.
-- Unlike the older program, a quantity that is in no band gets NO discount (the older one gave it the largest band's discount, which is probably a bug: QD4 and QD5 in the study).
-- The line's discount_source says 'band' when a band gave the discount, so that it can be worked out again whenever the quantity changes and never overwrites a discount a person typed.
-- The table carries tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/021_qty_bands.sql.
CREATE TABLE item_qty_bands (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  item_id INTEGER NOT NULL REFERENCES items(id),
  min_qty_milli INTEGER NOT NULL CHECK (min_qty_milli > 0),
  max_qty_milli INTEGER CHECK (max_qty_milli IS NULL OR max_qty_milli >= min_qty_milli),
  pct_milli INTEGER NOT NULL CHECK (pct_milli > 0 AND pct_milli <= 100000),
  created_at TEXT NOT NULL);
CREATE INDEX ix_item_qty_bands_item ON item_qty_bands(item_id);
