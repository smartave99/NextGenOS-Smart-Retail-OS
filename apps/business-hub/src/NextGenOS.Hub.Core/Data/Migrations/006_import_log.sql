-- Moving a shop across from an older system (Import/): NEW TABLES ONLY, nothing that exists is changed, and all of them are empty until a person runs an import.
--   import_runs             one row for each import that was done: when, who, which old system, what was added, the match report the person read, and the copy of this
--                           database that was made just before. A check (a "dry run") writes nothing: only a finished import leaves a row here.
--   import_id_map           which old row became which row here ("old product 12 is item 340"), so that running the import again adds nothing twice.
--   party_opening_balances  what a customer owed the shop (or the shop owed a supplier) on the day of the move. The Hub has no customer or supplier account yet, so nothing in the
--                           program's screens reads this table; it keeps the figure safely until the account view is built (docs/OPEN-WORK.md).
-- Every table carries tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/006_import_log.sql.
-- No password is ever written to any of these tables: the program asks for it each time and keeps it only in memory.

CREATE TABLE import_runs (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  at TEXT NOT NULL, user_id INTEGER,
  source_kind TEXT NOT NULL, source_id TEXT NOT NULL,
  items_added INTEGER NOT NULL DEFAULT 0, customers_added INTEGER NOT NULL DEFAULT 0, suppliers_added INTEGER NOT NULL DEFAULT 0,
  stock_moves_added INTEGER NOT NULL DEFAULT 0, balances_added INTEGER NOT NULL DEFAULT 0,
  backup_path TEXT, report TEXT NOT NULL,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_import_runs_at ON import_runs(tenant_id, site_id, at);

CREATE TABLE import_id_map (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  source_kind TEXT NOT NULL, source_id TEXT NOT NULL, entity TEXT NOT NULL CHECK (entity IN ('item', 'customer', 'supplier')), old_key TEXT NOT NULL,
  hub_id INTEGER NOT NULL, run_id INTEGER NOT NULL,
  PRIMARY KEY (tenant_id, site_id, source_kind, source_id, entity, old_key));
CREATE INDEX ix_import_map_hub ON import_id_map(tenant_id, site_id, entity, hub_id);

-- balance_minor: positive when the person owes the shop, negative when the shop owes the person (the same sign for customers and suppliers).
CREATE TABLE party_opening_balances (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', party_id INTEGER NOT NULL,
  balance_minor INTEGER NOT NULL, as_of TEXT NOT NULL, run_id INTEGER,
  PRIMARY KEY (tenant_id, site_id, party_id));
