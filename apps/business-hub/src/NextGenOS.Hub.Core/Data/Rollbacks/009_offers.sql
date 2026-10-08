-- The way back from 009_offers.sql: drops the offer, voucher and customer-discount tables and the columns that migration added. The bills and their lines are untouched (a free line stays
-- on its bill as an ordinary line, with the full discount it was given). Used by HubDb.Rollback, which copies the database first.
ALTER TABLE document_lines DROP COLUMN free_for_line_id;
ALTER TABLE document_lines DROP COLUMN discount_source;
ALTER TABLE documents DROP COLUMN offer_declined;
ALTER TABLE documents DROP COLUMN offer_discount_minor;
DROP TABLE IF EXISTS party_discounts;
DROP INDEX IF EXISTS ix_document_offers_document;
DROP TABLE IF EXISTS document_offers;
DROP INDEX IF EXISTS ix_vouchers_used_document;
DROP INDEX IF EXISTS ix_vouchers_party;
DROP TABLE IF EXISTS vouchers;
DROP INDEX IF EXISTS ix_offers_item;
DROP INDEX IF EXISTS ix_offers_kind;
DROP TABLE IF EXISTS offers;
