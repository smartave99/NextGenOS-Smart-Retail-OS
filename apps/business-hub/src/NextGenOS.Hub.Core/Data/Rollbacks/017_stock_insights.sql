-- The way back from 017_stock_insights.sql: drops the four tables that step made. Items, suppliers, stock, sales and everything else are untouched. Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_insight_findings_subject;
DROP INDEX IF EXISTS ix_insight_findings_run;
DROP TABLE IF EXISTS insight_findings;
DROP INDEX IF EXISTS ix_insight_runs_rule;
DROP TABLE IF EXISTS insight_runs;
DROP TABLE IF EXISTS insight_settings;
DROP TABLE IF EXISTS supply_terms;
