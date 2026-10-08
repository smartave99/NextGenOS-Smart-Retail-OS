-- Offers, coupons and gift vouchers (docs/old-programs/02-masters-accounting-reports.md, A1.7 to A1.9). NEW TABLES and NEW COLUMNS only; nothing that exists is changed.
--   offers            the shop's rules, one row each: money off a bill that comes to an amount between two limits ('bill-range'), a gift voucher given to a bill that comes to an amount
--                     ('gift-rule'), a percent off one item ('item-percent'), and "buy so many, get so many free" for one item ('buy-get'). Dates are the shop's own days, both included;
--                     an empty date means no limit on that side.
--   vouchers          coupons (made for a customer by the shop) and gift vouchers (earned by a bill). A code is used once: the row says when and on which bill. A row is never removed.
--   document_offers   what was taken off a bill by an offer or by a voucher, for the bill to show. Written again whenever an open bill changes; kept as it was when the bill is made.
--   party_discounts   a customer's standing discount percent (the older POS kept this on the customer).
--   documents.offer_discount_minor / offer_declined   what offers and vouchers take off the whole bill (part of the bill's discount, like points used), and whether the cashier
--                     chose not to use the bill-range offer.
--   document_lines.discount_source   who set the line's discount: empty = a person, 'customer' = the customer's standing discount, 'offer' = an item offer.
--   document_lines.free_for_line_id  a line of free goods ("buy so many, get so many free") points at the line it came with.
-- The tables carry tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/009_offers.sql.
CREATE TABLE offers (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  kind TEXT NOT NULL CHECK (kind IN ('bill-range', 'gift-rule', 'item-percent', 'buy-get')),
  name TEXT, item_id INTEGER REFERENCES items(id),
  amount_from_minor INTEGER, amount_to_minor INTEGER, amount_minor INTEGER NOT NULL DEFAULT 0, pct_milli INTEGER NOT NULL DEFAULT 0,
  min_qty_milli INTEGER NOT NULL DEFAULT 0, free_qty_milli INTEGER NOT NULL DEFAULT 0,
  valid_from TEXT, valid_to TEXT, enabled INTEGER NOT NULL DEFAULT 1, created_at TEXT NOT NULL);
CREATE INDEX ix_offers_kind ON offers(tenant_id, site_id, kind, enabled);
CREATE INDEX ix_offers_item ON offers(item_id);

CREATE TABLE vouchers (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  kind TEXT NOT NULL CHECK (kind IN ('coupon', 'gift')),
  code TEXT NOT NULL, amount_minor INTEGER NOT NULL CHECK (amount_minor > 0),
  party_id INTEGER REFERENCES parties(id),
  valid_from TEXT, valid_to TEXT, enabled INTEGER NOT NULL DEFAULT 1,
  issued_at TEXT NOT NULL, issued_document_id INTEGER, issued_by INTEGER,
  used_at TEXT, used_document_id INTEGER,
  UNIQUE (tenant_id, site_id, code));
CREATE INDEX ix_vouchers_party ON vouchers(party_id);
CREATE INDEX ix_vouchers_used_document ON vouchers(used_document_id);

CREATE TABLE document_offers (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  document_id INTEGER NOT NULL, kind TEXT NOT NULL CHECK (kind IN ('bill-offer', 'coupon', 'gift')),
  offer_id INTEGER, voucher_id INTEGER REFERENCES vouchers(id), label TEXT NOT NULL, amount_minor INTEGER NOT NULL);
CREATE INDEX ix_document_offers_document ON document_offers(document_id);

CREATE TABLE party_discounts (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  party_id INTEGER NOT NULL REFERENCES parties(id), pct_milli INTEGER NOT NULL CHECK (pct_milli BETWEEN 0 AND 100000), enabled INTEGER NOT NULL DEFAULT 1,
  PRIMARY KEY (tenant_id, site_id, party_id));

ALTER TABLE documents ADD COLUMN offer_discount_minor INTEGER NOT NULL DEFAULT 0;
ALTER TABLE documents ADD COLUMN offer_declined INTEGER NOT NULL DEFAULT 0;
ALTER TABLE document_lines ADD COLUMN discount_source TEXT;
ALTER TABLE document_lines ADD COLUMN free_for_line_id INTEGER;
