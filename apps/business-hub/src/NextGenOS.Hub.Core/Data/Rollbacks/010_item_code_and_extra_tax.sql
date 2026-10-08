-- The way back from 010_item_code_and_extra_tax.sql: drops the two columns that step added. The bills and their lines are untouched (the amounts stay as they were worked out). Used by
-- HubDb.Rollback, which copies the database first.
ALTER TABLE document_lines DROP COLUMN extra_tax_pct_milli;
ALTER TABLE document_lines DROP COLUMN item_code;
