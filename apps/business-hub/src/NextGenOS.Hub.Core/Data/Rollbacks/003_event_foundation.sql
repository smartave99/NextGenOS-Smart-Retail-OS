-- The way back from 003_event_foundation.sql: drops only the tables that migration made (in the opposite order). Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_event_evidence_retain;
DROP INDEX IF EXISTS ix_event_evidence_event;
DROP TABLE IF EXISTS event_evidence;
DROP TABLE IF EXISTS event_observations;
DROP INDEX IF EXISTS ix_events_idempotency;
DROP INDEX IF EXISTS ix_events_retain;
DROP INDEX IF EXISTS ix_events_type;
DROP INDEX IF EXISTS ix_events_time;
DROP TABLE IF EXISTS events;
DROP INDEX IF EXISTS ix_observations_retain;
DROP INDEX IF EXISTS ix_observations_time;
DROP TABLE IF EXISTS observations;
DROP TABLE IF EXISTS retention_policies;
