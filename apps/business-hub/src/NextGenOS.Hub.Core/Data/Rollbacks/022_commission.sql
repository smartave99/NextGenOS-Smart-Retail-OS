-- The way back from 022_commission.sql: drops the commission people, the choices on bills and the ledger of what is owed to them. Bills and the books are untouched (the entries the books
-- already hold for commission stay where they are). Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_earner_ledger_document;
DROP INDEX IF EXISTS ix_earner_ledger_earner;
DROP TABLE IF EXISTS earner_ledger;
DROP TABLE IF EXISTS bill_earners;
DROP INDEX IF EXISTS ix_earners_kind;
DROP TABLE IF EXISTS earners;
