-- The way back from 018_actions.sql: drops the two tables that step made. Orders that were drafted by an approved action are ordinary orders and stay. Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_action_transitions_row;
DROP TABLE IF EXISTS action_transitions;
DROP INDEX IF EXISTS ix_actions_status;
DROP INDEX IF EXISTS ux_actions_key;
DROP TABLE IF EXISTS actions;
