-- The way back from 031_assistant.sql: drops the one table that step made, with the questions in it. Nothing of the shop's own records is touched. Used by HubDb.Rollback, which copies the
-- database first (so the questions are in that copy).
DROP INDEX IF EXISTS ix_assistant_questions_user;
DROP INDEX IF EXISTS ix_assistant_questions_when;
DROP TABLE IF EXISTS assistant_questions;
