-- The way back from 029_event_rules.sql: drops the two tables that step made. The events the rules proposed are in the event history and stay there (each says in its data which rule made it).
-- Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_rule_firings_group;
DROP TABLE IF EXISTS event_rule_firings;
DROP TABLE IF EXISTS event_rules;
