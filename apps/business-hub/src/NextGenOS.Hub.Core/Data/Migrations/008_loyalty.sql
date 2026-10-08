-- Loyalty points (docs/PLATFORM-DECISIONS.md decision 31: points per item, each point worth some money). NEW TABLE and NEW COLUMNS only; nothing that exists is changed.
--   loyalty_ledger  one row for each change of a customer's points (earned on a bill, used on a bill, taken back with a return or a cancelled bill, a correction). Points are kept in
--                   hundredths. The balance is the sum of the rows. A row is never edited or removed (a trigger refuses it); a mistake is put right with a new row.
--   documents.loyalty_points_used_cent / loyalty_discount_minor   the points a customer chose to use on a bill that is still open, and what they are worth; they are part of the bill's
--                   discount once the bill is made.
-- The table carries tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/008_loyalty.sql.
CREATE TABLE loyalty_ledger (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  party_id INTEGER NOT NULL REFERENCES parties(id), at TEXT NOT NULL,
  kind TEXT NOT NULL CHECK (kind IN ('earn', 'redeem', 'return', 'void', 'adjust', 'opening')),
  points_cent INTEGER NOT NULL, document_id INTEGER, memo TEXT, user_id INTEGER, created_at TEXT NOT NULL);
CREATE INDEX ix_loyalty_party ON loyalty_ledger(tenant_id, site_id, party_id, id);
CREATE INDEX ix_loyalty_document ON loyalty_ledger(document_id);
CREATE TRIGGER loyalty_ledger_no_update BEFORE UPDATE ON loyalty_ledger BEGIN SELECT RAISE(ABORT, 'Points cannot be changed. Put a mistake right with a new line.'); END;
CREATE TRIGGER loyalty_ledger_no_delete BEFORE DELETE ON loyalty_ledger BEGIN SELECT RAISE(ABORT, 'Points cannot be changed. Put a mistake right with a new line.'); END;

ALTER TABLE documents ADD COLUMN loyalty_points_used_cent INTEGER NOT NULL DEFAULT 0;
ALTER TABLE documents ADD COLUMN loyalty_discount_minor INTEGER NOT NULL DEFAULT 0;
