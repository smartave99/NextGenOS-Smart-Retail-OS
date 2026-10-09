-- People who earn a commission on bills: salespeople and brokers (docs/old-programs/03-india-tax-and-staff.md, B1 and B2). NEW TABLES only; nothing that exists is changed.
--   earners         the master: a salesperson (a percent of the bill, from this record at the time of the sale) or a broker (a percent or an amount typed for each bill). Never deleted, only switched off.
--   bill_earners    who is named on a bill that is being made, and how the commission is worked out: on the taxable value ('taxable') or on the whole total ('total'), a percent, or an amount.
--                   The older program had two commission methods that never met (docs B1 quirk 1); the Hub has one: when the bill becomes final, one commission entry is written for each person named.
--   earner_ledger   what the shop owes each person, line by line: commission earned (+), commission taken back when goods come back or the bill is cancelled (-), money paid to the person (-), and an
--                   opening balance when the shop is moved across. The balance is the sum. Rows are only ever added, never changed.
-- The tables carry tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/022_commission.sql.
CREATE TABLE earners (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  kind TEXT NOT NULL CHECK (kind IN ('salesperson', 'broker')),
  name TEXT NOT NULL, phone TEXT, email TEXT, address TEXT,
  pct_milli INTEGER NOT NULL DEFAULT 0 CHECK (pct_milli BETWEEN 0 AND 100000),
  active INTEGER NOT NULL DEFAULT 1, notes TEXT, created_at TEXT NOT NULL);
CREATE INDEX ix_earners_kind ON earners(tenant_id, site_id, kind, active);

CREATE TABLE bill_earners (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  document_id INTEGER NOT NULL, earner_id INTEGER NOT NULL REFERENCES earners(id),
  basis TEXT NOT NULL CHECK (basis IN ('taxable', 'total')),
  pct_milli INTEGER CHECK (pct_milli IS NULL OR pct_milli BETWEEN 0 AND 100000),
  amount_minor INTEGER CHECK (amount_minor IS NULL OR amount_minor >= 0),
  PRIMARY KEY (document_id, earner_id));

CREATE TABLE earner_ledger (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  earner_id INTEGER NOT NULL REFERENCES earners(id), at TEXT NOT NULL,
  kind TEXT NOT NULL CHECK (kind IN ('commission', 'reversal', 'payment', 'opening')),
  document_id INTEGER, base_minor INTEGER, amount_minor INTEGER NOT NULL, method TEXT, note TEXT, user_id INTEGER);
CREATE INDEX ix_earner_ledger_earner ON earner_ledger(earner_id, at);
CREATE INDEX ix_earner_ledger_document ON earner_ledger(document_id);
