-- Version 2, phase 1: the foundation for the optional AI features. NEW TABLES ONLY: nothing that exists is changed, so the shop program works exactly as before
-- with all of this switched off (it is: every flag starts off). Every table carries tenant_id and site_id (this installation is one organisation and one site,
-- 'local' and 'main') so that a later edition with several sites does not have to rewrite them. The way back is Data/Rollbacks/002_ai_foundation.sql.

-- Switches for the major capabilities. A row says what the owner chose; no row means the default in code (off).
CREATE TABLE feature_flags (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  key TEXT NOT NULL, enabled INTEGER NOT NULL DEFAULT 0 CHECK (enabled IN (0, 1)),
  updated_at TEXT NOT NULL, updated_by INTEGER,
  PRIMARY KEY (tenant_id, site_id, key));

-- The AI services the owner connected. A secret (an API key) is never here: secret_name is only the NAME it has in the secret store.
CREATE TABLE ai_providers (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  id TEXT NOT NULL, name TEXT NOT NULL, adapter TEXT NOT NULL,
  location TEXT NOT NULL CHECK (location IN ('local', 'local-optimized', 'lan', 'cli', 'api')),
  base_url TEXT NOT NULL, default_model TEXT, secret_name TEXT,
  tasks TEXT NOT NULL DEFAULT 'generate,embed',
  enabled INTEGER NOT NULL DEFAULT 0 CHECK (enabled IN (0, 1)),
  price_in_micros_per_1k INTEGER, price_out_micros_per_1k INTEGER,
  limit_requests_per_day INTEGER, limit_tokens_per_day INTEGER, limit_tokens_per_month INTEGER, limit_cost_micros_per_month INTEGER,
  created_at TEXT NOT NULL, updated_at TEXT NOT NULL,
  PRIMARY KEY (tenant_id, site_id, id));

-- What the owner allowed a provider to receive. A row is a permission; no row is no permission; revoking deletes the row (the audit log keeps the history).
CREATE TABLE ai_provider_consent (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  provider_id TEXT NOT NULL, data_class TEXT NOT NULL, features TEXT NOT NULL DEFAULT '*',
  granted_at TEXT NOT NULL, granted_by INTEGER,
  PRIMARY KEY (tenant_id, site_id, provider_id, data_class),
  FOREIGN KEY (tenant_id, site_id, provider_id) REFERENCES ai_providers(tenant_id, site_id, id) ON DELETE CASCADE);

-- The models the owner knows about (never downloaded automatically) and where each stands: candidate, testing, shadow, active, deprecated, rolled back.
CREATE TABLE ai_models (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  id INTEGER NOT NULL, model_id TEXT NOT NULL, provider_id TEXT, family TEXT, task TEXT NOT NULL, version TEXT, quantization TEXT, precision TEXT,
  parameter_count INTEGER, memory_mb INTEGER, disk_mb INTEGER, runtime TEXT, context_length INTEGER, embedding_dimension INTEGER,
  license TEXT, commercial_use TEXT NOT NULL DEFAULT 'unknown' CHECK (commercial_use IN ('yes', 'no', 'unknown')),
  status TEXT NOT NULL DEFAULT 'candidate' CHECK (status IN ('candidate', 'testing', 'shadow', 'active', 'deprecated', 'rolled-back')),
  installed INTEGER NOT NULL DEFAULT 0, notes TEXT, created_at TEXT NOT NULL, updated_at TEXT NOT NULL,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE UNIQUE INDEX ix_ai_models_identity ON ai_models(tenant_id, site_id, task, model_id, COALESCE(provider_id, ''));

-- One row for every use of an AI service, also the refused ones, so that spending and what left the computer can always be shown.
CREATE TABLE ai_usage (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', at TEXT NOT NULL,
  provider_id TEXT, model TEXT, task TEXT NOT NULL, feature TEXT NOT NULL, data_class TEXT NOT NULL,
  tokens_in INTEGER NOT NULL DEFAULT 0, tokens_out INTEGER NOT NULL DEFAULT 0, cost_micros INTEGER NOT NULL DEFAULT 0, duration_ms INTEGER NOT NULL DEFAULT 0,
  outcome TEXT NOT NULL CHECK (outcome IN ('ok', 'failed', 'refused', 'over-budget')), detail TEXT, user_id INTEGER);
CREATE INDEX ix_ai_usage_at ON ai_usage(tenant_id, site_id, at);
CREATE INDEX ix_ai_usage_provider ON ai_usage(tenant_id, site_id, provider_id, at);
