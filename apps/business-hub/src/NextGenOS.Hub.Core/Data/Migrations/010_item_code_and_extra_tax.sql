-- A bill line keeps a copy of two things the country's tax may ask for, as they were when the line was made (the item can change later; the bill must not):
--   item_code            the code of the goods or service sold (the country's own name for it is in its pack; empty when the country has none)
--   extra_tax_pct_milli  a further tax on top of the main one, as a percent in thousandths (12000 = 12%), passed to the tax engine as the line's extra tax
-- NEW COLUMNS only; nothing that exists is changed. The way back is Data/Rollbacks/010_item_code_and_extra_tax.sql.
ALTER TABLE document_lines ADD COLUMN item_code TEXT;
ALTER TABLE document_lines ADD COLUMN extra_tax_pct_milli INTEGER NOT NULL DEFAULT 0;
