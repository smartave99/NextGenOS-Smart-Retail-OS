-- The shop's books (docs/PLATFORM-DECISIONS.md decision 32: proper double entry). NEW TABLES ONLY; nothing that exists is changed.
--   accounts         the list of accounts (cash, customers owe us, sales, tax collected ...). An account is made the first time something is posted to it.
--   journal_entries  one entry for each thing that happened with money: a bill issued, a payment, a refund, a bill cancelled. The pair (source, source_id) is unique, so a bill or a
--                    payment is posted once and only once, however often the posting is asked for.
--   journal_lines    the two or more lines of an entry: an account, who it concerns (a customer or supplier), and a debit or a credit. The lines of an entry add up to nothing.
-- The books are never edited: a trigger refuses any change or removal of an entry or a line; a mistake is put right by a new entry. Every table carries tenant_id and site_id.
-- The way back is Data/Rollbacks/007_books.sql; it drops only these tables (the bills and payments themselves are kept and can be posted again).

CREATE TABLE accounts (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  code TEXT NOT NULL, name TEXT NOT NULL, kind TEXT NOT NULL CHECK (kind IN ('asset', 'liability', 'equity', 'income', 'expense')),
  role TEXT, ref TEXT, active INTEGER NOT NULL DEFAULT 1, created_at TEXT NOT NULL,
  UNIQUE (tenant_id, site_id, code));
CREATE UNIQUE INDEX ux_accounts_role ON accounts(tenant_id, site_id, role, COALESCE(ref, '')) WHERE role IS NOT NULL;

CREATE TABLE journal_entries (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  at TEXT NOT NULL, source TEXT NOT NULL, source_id INTEGER NOT NULL, memo TEXT, user_id INTEGER, created_at TEXT NOT NULL,
  UNIQUE (tenant_id, site_id, source, source_id));
CREATE INDEX ix_journal_entries_at ON journal_entries(tenant_id, site_id, at);

CREATE TABLE journal_lines (
  id INTEGER PRIMARY KEY, tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  entry_id INTEGER NOT NULL REFERENCES journal_entries(id), account_id INTEGER NOT NULL REFERENCES accounts(id), party_id INTEGER,
  debit_minor INTEGER NOT NULL DEFAULT 0, credit_minor INTEGER NOT NULL DEFAULT 0,
  CHECK (debit_minor >= 0 AND credit_minor >= 0 AND NOT (debit_minor > 0 AND credit_minor > 0)));
CREATE INDEX ix_journal_lines_entry ON journal_lines(entry_id);
CREATE INDEX ix_journal_lines_account ON journal_lines(tenant_id, site_id, account_id, party_id);

CREATE TRIGGER journal_entries_no_update BEFORE UPDATE ON journal_entries BEGIN SELECT RAISE(ABORT, 'The books cannot be changed. Put a mistake right with a new entry.'); END;
CREATE TRIGGER journal_entries_no_delete BEFORE DELETE ON journal_entries BEGIN SELECT RAISE(ABORT, 'The books cannot be changed. Put a mistake right with a new entry.'); END;
CREATE TRIGGER journal_lines_no_update BEFORE UPDATE ON journal_lines BEGIN SELECT RAISE(ABORT, 'The books cannot be changed. Put a mistake right with a new entry.'); END;
CREATE TRIGGER journal_lines_no_delete BEFORE DELETE ON journal_lines BEGIN SELECT RAISE(ABORT, 'The books cannot be changed. Put a mistake right with a new entry.'); END;
