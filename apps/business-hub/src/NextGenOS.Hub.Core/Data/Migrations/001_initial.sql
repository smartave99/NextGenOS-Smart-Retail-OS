-- The Business Hub's database (one SQLite file per shop). Money is whole minor units; quantities are thousandths; times are UTC, ISO 8601.

CREATE TABLE settings (key TEXT PRIMARY KEY, value TEXT NOT NULL);

CREATE TABLE users (
  id INTEGER PRIMARY KEY, username TEXT NOT NULL UNIQUE COLLATE NOCASE, display_name TEXT NOT NULL, role TEXT NOT NULL,
  password_hash TEXT NOT NULL, active INTEGER NOT NULL DEFAULT 1, failed_logins INTEGER NOT NULL DEFAULT 0, locked_until TEXT, created_at TEXT NOT NULL);

CREATE TABLE parties (
  id INTEGER PRIMARY KEY, kind TEXT NOT NULL, code TEXT, name TEXT NOT NULL, phone TEXT, email TEXT, address TEXT, tax_id TEXT, region TEXT,
  member_type TEXT, price_level TEXT NOT NULL DEFAULT 'retail', credit_limit_minor INTEGER NOT NULL DEFAULT 0, terms_days INTEGER NOT NULL DEFAULT 0,
  card_barcode TEXT UNIQUE, notes TEXT, active INTEGER NOT NULL DEFAULT 1, created_at TEXT NOT NULL);
CREATE INDEX ix_parties_kind ON parties(kind, name);

CREATE TABLE items (
  id INTEGER PRIMARY KEY, kind TEXT NOT NULL, sku TEXT, barcode TEXT UNIQUE, name TEXT NOT NULL, category TEXT, unit TEXT NOT NULL DEFAULT 'pc',
  price_minor INTEGER NOT NULL DEFAULT 0, trade_price_minor INTEGER, cost_minor INTEGER NOT NULL DEFAULT 0, tax_code TEXT NOT NULL,
  track_stock INTEGER NOT NULL DEFAULT 0, reorder_milli INTEGER NOT NULL DEFAULT 0, station TEXT, duration_min INTEGER,
  attrs TEXT NOT NULL DEFAULT '{}', active INTEGER NOT NULL DEFAULT 1, created_at TEXT NOT NULL);
CREATE INDEX ix_items_name ON items(name);

CREATE TABLE stock_moves (
  id INTEGER PRIMARY KEY, item_id INTEGER NOT NULL REFERENCES items(id), qty_milli INTEGER NOT NULL, reason TEXT NOT NULL,
  document_id INTEGER, note TEXT, at TEXT NOT NULL, user_id INTEGER);
CREATE INDEX ix_stock_item ON stock_moves(item_id);

CREATE TABLE number_series (type TEXT NOT NULL, year_key TEXT NOT NULL, next_no INTEGER NOT NULL, PRIMARY KEY (type, year_key));

CREATE TABLE documents (
  id INTEGER PRIMARY KEY, type TEXT NOT NULL, number TEXT UNIQUE, status TEXT NOT NULL, direction TEXT NOT NULL DEFAULT 'out',
  party_id INTEGER REFERENCES parties(id), issued_at TEXT, created_at TEXT NOT NULL, due_at TEXT,
  currency_decimals INTEGER NOT NULL, prices_include_tax INTEGER NOT NULL, seller_region TEXT, buyer_region TEXT, round_total INTEGER NOT NULL DEFAULT 0,
  registered INTEGER NOT NULL DEFAULT 1, adjustments TEXT NOT NULL DEFAULT '[]', result TEXT,
  subtotal_minor INTEGER NOT NULL DEFAULT 0, tax_minor INTEGER NOT NULL DEFAULT 0, total_minor INTEGER NOT NULL DEFAULT 0,
  payable_minor INTEGER NOT NULL DEFAULT 0, paid_minor INTEGER NOT NULL DEFAULT 0,
  tips_minor INTEGER NOT NULL DEFAULT 0, retention_minor INTEGER NOT NULL DEFAULT 0, advance_minor INTEGER NOT NULL DEFAULT 0,
  table_id INTEGER, project_id INTEGER, ref_document_id INTEGER, user_id INTEGER, notes TEXT, meta TEXT NOT NULL DEFAULT '{}');
CREATE INDEX ix_docs_type ON documents(type, issued_at);
CREATE INDEX ix_docs_party ON documents(party_id);
CREATE INDEX ix_docs_table ON documents(table_id, status);
CREATE INDEX ix_docs_project ON documents(project_id);

CREATE TABLE document_lines (
  id INTEGER PRIMARY KEY, document_id INTEGER NOT NULL REFERENCES documents(id) ON DELETE CASCADE, line_no INTEGER NOT NULL,
  item_id INTEGER REFERENCES items(id), description TEXT NOT NULL, qty_milli INTEGER NOT NULL, unit TEXT, unit_price_minor INTEGER NOT NULL,
  discount_pct_milli INTEGER NOT NULL DEFAULT 0, tax_code TEXT NOT NULL, customer_discount TEXT, fired INTEGER NOT NULL DEFAULT 0,
  note TEXT, station TEXT, boq_id INTEGER);
CREATE INDEX ix_lines_doc ON document_lines(document_id);
CREATE INDEX ix_lines_item ON document_lines(item_id);

CREATE TABLE payments (
  id INTEGER PRIMARY KEY, document_id INTEGER REFERENCES documents(id), party_id INTEGER, project_id INTEGER, method TEXT NOT NULL,
  amount_minor INTEGER NOT NULL, reference TEXT, at TEXT NOT NULL, user_id INTEGER, kind TEXT NOT NULL DEFAULT 'payment');
CREATE INDEX ix_pay_doc ON payments(document_id);
CREATE INDEX ix_pay_at ON payments(at);

-- Restaurant
CREATE TABLE tables (id INTEGER PRIMARY KEY, name TEXT NOT NULL UNIQUE, seats INTEGER NOT NULL DEFAULT 2, zone TEXT, active INTEGER NOT NULL DEFAULT 1);
CREATE TABLE kitchen_tickets (
  id INTEGER PRIMARY KEY, document_id INTEGER NOT NULL REFERENCES documents(id), station TEXT NOT NULL, status TEXT NOT NULL,
  fired_at TEXT NOT NULL, ready_at TEXT, served_at TEXT, seq INTEGER NOT NULL);
CREATE TABLE kitchen_ticket_lines (ticket_id INTEGER NOT NULL REFERENCES kitchen_tickets(id) ON DELETE CASCADE, line_id INTEGER NOT NULL, description TEXT NOT NULL, qty_milli INTEGER NOT NULL, note TEXT);

-- Library
CREATE TABLE copies (id INTEGER PRIMARY KEY, item_id INTEGER NOT NULL REFERENCES items(id), barcode TEXT NOT NULL UNIQUE, status TEXT NOT NULL, note TEXT);
CREATE TABLE loans (
  id INTEGER PRIMARY KEY, copy_id INTEGER NOT NULL REFERENCES copies(id), party_id INTEGER NOT NULL REFERENCES parties(id),
  issued_at TEXT NOT NULL, due_at TEXT NOT NULL, returned_at TEXT, renewals INTEGER NOT NULL DEFAULT 0, user_id INTEGER);
CREATE INDEX ix_loans_open ON loans(returned_at, due_at);
CREATE INDEX ix_loans_party ON loans(party_id);
CREATE TABLE reservations (
  id INTEGER PRIMARY KEY, item_id INTEGER NOT NULL REFERENCES items(id), party_id INTEGER NOT NULL REFERENCES parties(id),
  at TEXT NOT NULL, status TEXT NOT NULL, copy_id INTEGER, hold_until TEXT);
CREATE TABLE fines (
  id INTEGER PRIMARY KEY, loan_id INTEGER REFERENCES loans(id), party_id INTEGER NOT NULL, amount_minor INTEGER NOT NULL,
  reason TEXT NOT NULL, status TEXT NOT NULL, at TEXT NOT NULL, document_id INTEGER);

-- Construction
CREATE TABLE projects (
  id INTEGER PRIMARY KEY, code TEXT NOT NULL UNIQUE, name TEXT NOT NULL, party_id INTEGER NOT NULL REFERENCES parties(id), site TEXT,
  status TEXT NOT NULL, retention_pct_milli INTEGER NOT NULL DEFAULT 0, advance_minor INTEGER NOT NULL DEFAULT 0,
  advance_recovered_minor INTEGER NOT NULL DEFAULT 0, start_on TEXT, end_on TEXT, notes TEXT, created_at TEXT NOT NULL);
CREATE TABLE boq_items (
  id INTEGER PRIMARY KEY, project_id INTEGER NOT NULL REFERENCES projects(id) ON DELETE CASCADE, code TEXT NOT NULL, description TEXT NOT NULL,
  unit TEXT NOT NULL, qty_milli INTEGER NOT NULL, rate_minor INTEGER NOT NULL, kind TEXT NOT NULL, tax_code TEXT NOT NULL, variation_id INTEGER);
CREATE TABLE progress_lines (
  document_id INTEGER NOT NULL REFERENCES documents(id) ON DELETE CASCADE, boq_id INTEGER NOT NULL REFERENCES boq_items(id),
  cum_pct_milli INTEGER NOT NULL, prev_pct_milli INTEGER NOT NULL, value_minor INTEGER NOT NULL, PRIMARY KEY (document_id, boq_id));
CREATE TABLE project_costs (
  id INTEGER PRIMARY KEY, project_id INTEGER NOT NULL REFERENCES projects(id) ON DELETE CASCADE, at TEXT NOT NULL, kind TEXT NOT NULL,
  description TEXT NOT NULL, party_id INTEGER, amount_minor INTEGER NOT NULL, boq_id INTEGER, reference TEXT);
CREATE TABLE variations (
  id INTEGER PRIMARY KEY, project_id INTEGER NOT NULL REFERENCES projects(id) ON DELETE CASCADE, no INTEGER NOT NULL, description TEXT NOT NULL,
  amount_minor INTEGER NOT NULL, tax_code TEXT NOT NULL, status TEXT NOT NULL, at TEXT NOT NULL);

-- Appointments
CREATE TABLE appointments (
  id INTEGER PRIMARY KEY, party_id INTEGER REFERENCES parties(id), staff_id INTEGER NOT NULL REFERENCES parties(id), item_id INTEGER NOT NULL REFERENCES items(id),
  start_at TEXT NOT NULL, end_at TEXT NOT NULL, status TEXT NOT NULL, document_id INTEGER, notes TEXT, created_at TEXT NOT NULL);
CREATE INDEX ix_appt_staff ON appointments(staff_id, start_at);

CREATE TABLE audit_log (id INTEGER PRIMARY KEY, at TEXT NOT NULL, user_id INTEGER, action TEXT NOT NULL, entity TEXT, entity_id INTEGER, detail TEXT);
