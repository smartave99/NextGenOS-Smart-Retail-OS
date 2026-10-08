-- A store with one main PC and many counter PCs (the owner's decision 4, phase 1: on the shop's own network only). NEW TABLES ONLY: nothing that exists is changed.
-- The main PC keeps all the shop's data; a counter PC is only a window onto it. Two things are kept here and nothing else:
--   a PAIRING CODE: a short one-time code the owner makes for a new counter PC. Only a salted hash of it is kept, never the code itself; it runs out after ten minutes and works once.
--   a DEVICE: a counter PC that was paired. Only a hash of its long random token is kept, never the token (the counter PC holds that, in a cookie). Removing a counter PC marks it
--   (revoked_at); the row stays, so the history reads as it happened and its token stops working at once.
-- Every table carries tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/014_store_network.sql.

CREATE TABLE network_pairing_codes (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  code_hash TEXT NOT NULL, salt TEXT NOT NULL,
  created_at TEXT NOT NULL, created_by INTEGER, expires_at TEXT NOT NULL,
  used_at TEXT, used_by_device INTEGER, cancelled_at TEXT,
  wrong_attempts INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE INDEX ix_network_codes_live ON network_pairing_codes(tenant_id, site_id, expires_at) WHERE used_at IS NULL AND cancelled_at IS NULL;

CREATE TABLE network_devices (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  name TEXT NOT NULL, token_hash TEXT NOT NULL,
  paired_at TEXT NOT NULL, paired_with_code INTEGER,
  last_seen_at TEXT, last_address TEXT,
  revoked_at TEXT, revoked_by INTEGER,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE UNIQUE INDEX ix_network_devices_token ON network_devices(tenant_id, site_id, token_hash);
