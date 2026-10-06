-- The way back from 002_ai_foundation.sql: drops only the tables that migration made (in the opposite order). Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_ai_usage_provider;
DROP INDEX IF EXISTS ix_ai_usage_at;
DROP TABLE IF EXISTS ai_usage;
DROP INDEX IF EXISTS ix_ai_models_identity;
DROP TABLE IF EXISTS ai_models;
DROP TABLE IF EXISTS ai_provider_consent;
DROP TABLE IF EXISTS ai_providers;
DROP TABLE IF EXISTS feature_flags;
