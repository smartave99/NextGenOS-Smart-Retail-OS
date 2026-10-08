-- A bill keeps the other person's tax number as it was when the bill was made (a customer or supplier can change their number later; an old bill and the registers made from it must not change).
-- NEW COLUMN only. Bills made before this step get the number their customer or supplier has now (the best that is known), once, here. The way back is Data/Rollbacks/011_party_tax_id.sql.
ALTER TABLE documents ADD COLUMN party_tax_id TEXT;
UPDATE documents SET party_tax_id = (SELECT NULLIF(TRIM(p.tax_id), '') FROM parties p WHERE p.id = documents.party_id) WHERE party_id IS NOT NULL;
