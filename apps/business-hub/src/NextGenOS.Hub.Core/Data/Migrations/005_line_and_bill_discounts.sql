-- Discounts in the shop's own money (docs/PLATFORM-DECISIONS.md decision 33; study docs/old-programs/01-selling-buying-stock.md section 1).
-- A line can be given a discount as an amount (not only as a percent); a whole bill can be given a discount as an amount or a percent, which is spread over the
-- lines before the tax is worked out. A line of a credit note remembers which line of the invoice it gives back (ref_line_id), so that what was returned is counted
-- exactly, whatever the discounts. Old rows keep working: every new column has a harmless default.
ALTER TABLE document_lines ADD COLUMN discount_amount_minor INTEGER NOT NULL DEFAULT 0;
ALTER TABLE document_lines ADD COLUMN ref_line_id INTEGER;
ALTER TABLE documents ADD COLUMN bill_discount_minor INTEGER NOT NULL DEFAULT 0;
ALTER TABLE documents ADD COLUMN bill_discount_pct_milli INTEGER NOT NULL DEFAULT 0;
