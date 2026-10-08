-- The shop's own copies (blueprint OPS-002, decision 11): one row for every try at a copy, good or not, so that the owner can see whether the last copy worked and what to do if it did not.
-- NEW TABLE only; nothing that exists is changed. Every table carries tenant_id and site_id. The way back is Data/Rollbacks/013_backups.sql.
CREATE TABLE backup_runs (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  started_at TEXT NOT NULL, kind TEXT NOT NULL CHECK (kind IN ('nightly', 'manual')), status TEXT NOT NULL CHECK (status IN ('ok', 'failed')),
  folder TEXT, file_name TEXT, size_bytes INTEGER NOT NULL DEFAULT 0, sha256 TEXT, schema_version INTEGER NOT NULL DEFAULT 0, error TEXT, kept INTEGER NOT NULL DEFAULT 1);
CREATE INDEX ix_backup_runs_at ON backup_runs(tenant_id, site_id, started_at);
