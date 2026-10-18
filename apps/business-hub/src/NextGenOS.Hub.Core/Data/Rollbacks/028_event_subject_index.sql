-- The way back from 028_event_subject_index.sql: drops the two indexes that step made. No event, observation or other row is touched. Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_events_zone;
DROP INDEX IF EXISTS ix_events_subject;
