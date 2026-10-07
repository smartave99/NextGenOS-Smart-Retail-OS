-- The way back from 005_line_and_bill_discounts.sql: takes away only the columns that migration added. Used by HubDb.Rollback, which copies the database first.
ALTER TABLE documents DROP COLUMN bill_discount_pct_milli;
ALTER TABLE documents DROP COLUMN bill_discount_minor;
ALTER TABLE document_lines DROP COLUMN ref_line_id;
ALTER TABLE document_lines DROP COLUMN discount_amount_minor;
