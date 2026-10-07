'use strict';
// The Studio's database (SQLite, built into Node 22). One file: <data>/studio.db

const fs = require('node:fs');
const path = require('node:path');
const { DatabaseSync } = require('node:sqlite');

const SCHEMA = `
CREATE TABLE IF NOT EXISTS users (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  email TEXT NOT NULL UNIQUE COLLATE NOCASE,
  name TEXT NOT NULL,
  role TEXT NOT NULL CHECK (role IN ('admin','sales','support')),
  pass_hash TEXT NOT NULL,
  active INTEGER NOT NULL DEFAULT 1,
  must_change_password INTEGER NOT NULL DEFAULT 0,
  failed_logins INTEGER NOT NULL DEFAULT 0,
  locked_until INTEGER NOT NULL DEFAULT 0,
  created_at INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS sessions (
  token_hash TEXT PRIMARY KEY,
  user_id INTEGER NOT NULL REFERENCES users(id) ON DELETE CASCADE,
  csrf TEXT NOT NULL,
  ip TEXT,
  created_at INTEGER NOT NULL,
  expires_at INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS customers (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name TEXT NOT NULL,
  country TEXT NOT NULL DEFAULT '',
  contact_name TEXT NOT NULL DEFAULT '',
  email TEXT NOT NULL DEFAULT '',
  phone TEXT NOT NULL DEFAULT '',
  notes TEXT NOT NULL DEFAULT '',
  external_id TEXT,
  created_by INTEGER REFERENCES users(id),
  created_at INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS plans (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  code TEXT NOT NULL UNIQUE,
  name TEXT NOT NULL,
  description TEXT NOT NULL DEFAULT '',
  modules TEXT NOT NULL,
  limits TEXT NOT NULL,
  caps TEXT NOT NULL,
  term_days INTEGER NOT NULL DEFAULT 365,
  active INTEGER NOT NULL DEFAULT 1,
  sort INTEGER NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS resellers (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name TEXT NOT NULL,
  email TEXT NOT NULL DEFAULT '',
  notes TEXT NOT NULL DEFAULT '',
  active INTEGER NOT NULL DEFAULT 1,
  created_at INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS brands (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name TEXT NOT NULL,
  data TEXT NOT NULL,
  reseller_id INTEGER REFERENCES resellers(id),
  active INTEGER NOT NULL DEFAULT 1,
  created_at INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS licences (
  lid TEXT PRIMARY KEY,
  licence_key TEXT NOT NULL UNIQUE,
  customer_id INTEGER NOT NULL REFERENCES customers(id),
  reseller_id INTEGER REFERENCES resellers(id),
  plan_code TEXT NOT NULL,
  modules TEXT NOT NULL,
  limits TEXT NOT NULL,
  bind TEXT NOT NULL,
  brand_id INTEGER REFERENCES brands(id),
  act TEXT NOT NULL,
  trial INTEGER NOT NULL DEFAULT 0,
  white_level TEXT NOT NULL DEFAULT 'theme' CHECK (white_level IN ('none','theme','full')),
  on_end TEXT NOT NULL DEFAULT 'stop' CHECK (on_end IN ('banner','stop')),
  nbf INTEGER NOT NULL,
  exp INTEGER,
  status TEXT NOT NULL DEFAULT 'active' CHECK (status IN ('active','suspended','revoked')),
  status_reason TEXT NOT NULL DEFAULT '',
  rev INTEGER NOT NULL DEFAULT 1,
  notes TEXT NOT NULL DEFAULT '',
  created_by INTEGER REFERENCES users(id),
  created_at INTEGER NOT NULL,
  updated_at INTEGER NOT NULL
);
CREATE INDEX IF NOT EXISTS licences_customer ON licences(customer_id);
CREATE TABLE IF NOT EXISTS activations (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  lid TEXT NOT NULL REFERENCES licences(lid) ON DELETE CASCADE,
  fp TEXT NOT NULL,
  host TEXT NOT NULL DEFAULT '',
  version TEXT NOT NULL DEFAULT '',
  usage TEXT NOT NULL DEFAULT '{}',
  active INTEGER NOT NULL DEFAULT 1,
  first_seen INTEGER NOT NULL,
  last_seen INTEGER NOT NULL,
  last_checkin INTEGER NOT NULL,
  ip TEXT NOT NULL DEFAULT ''
);
CREATE INDEX IF NOT EXISTS activations_lid ON activations(lid, active);
-- What happened to a licence's PCs, for the history on the licence page and for the "2 moves in 365 days" rule.
-- kind: activated | client_deactivate | staff_free
CREATE TABLE IF NOT EXISTS licence_events (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  lid TEXT NOT NULL REFERENCES licences(lid) ON DELETE CASCADE,
  ts INTEGER NOT NULL,
  kind TEXT NOT NULL,
  activation_id INTEGER,
  host TEXT NOT NULL DEFAULT '',
  actor TEXT NOT NULL DEFAULT '',
  reason TEXT NOT NULL DEFAULT ''
);
CREATE INDEX IF NOT EXISTS licence_events_lid ON licence_events(lid, ts);
-- Sign-ins for tools (the main Setup Studio): only a hash of the token is kept.
CREATE TABLE IF NOT EXISTS service_accounts (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name TEXT NOT NULL,
  role TEXT NOT NULL CHECK (role IN ('admin','sales','support')),
  token_hash TEXT NOT NULL UNIQUE,
  token_hint TEXT NOT NULL DEFAULT '',
  active INTEGER NOT NULL DEFAULT 1,
  created_by TEXT NOT NULL DEFAULT '',
  created_at INTEGER NOT NULL,
  last_used_at INTEGER,
  revoked_at INTEGER
);
-- Answers to "make a licence" calls, so that a repeated call never makes a second licence.
CREATE TABLE IF NOT EXISTS idempotency (
  account_id INTEGER NOT NULL REFERENCES service_accounts(id),
  idem_key TEXT NOT NULL,
  body_hash TEXT NOT NULL,
  lid TEXT NOT NULL REFERENCES licences(lid),
  created_at INTEGER NOT NULL,
  PRIMARY KEY (account_id, idem_key)
);
CREATE TABLE IF NOT EXISTS keys (
  kid TEXT PRIMARY KEY,
  public_key TEXT NOT NULL,
  status TEXT NOT NULL CHECK (status IN ('active','pending','retired')),
  created_at INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS audit (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  ts INTEGER NOT NULL,
  user_id INTEGER,
  user_email TEXT NOT NULL DEFAULT '',
  action TEXT NOT NULL,
  target TEXT NOT NULL DEFAULT '',
  detail TEXT NOT NULL DEFAULT '',
  ip TEXT NOT NULL DEFAULT ''
);
CREATE INDEX IF NOT EXISTS audit_ts ON audit(ts DESC);
CREATE TABLE IF NOT EXISTS settings (
  key TEXT PRIMARY KEY,
  value TEXT NOT NULL
);
`;

/** A database made by an older Studio gets the new columns; nothing is dropped or rewritten. */
function migrate(db) {
  const has = (table, column) => db.prepare(`PRAGMA table_info(${table})`).all().some((c) => c.name === column);
  // Licences made before "what happens at the end" keep behaving as they did: they stop (spec 10.1).
  if (!has('licences', 'on_end')) db.exec("ALTER TABLE licences ADD COLUMN on_end TEXT NOT NULL DEFAULT 'stop' CHECK (on_end IN ('banner','stop'))");
  if (!has('customers', 'external_id')) db.exec('ALTER TABLE customers ADD COLUMN external_id TEXT');
  // A client of the main Setup Studio is found by its id there; one id is one customer.
  db.exec('CREATE UNIQUE INDEX IF NOT EXISTS customers_external ON customers(external_id) WHERE external_id IS NOT NULL');
}

function open(dataDir) {
  let file = ':memory:';
  if (dataDir !== ':memory:') {
    fs.mkdirSync(dataDir, { recursive: true, mode: 0o700 });
    file = path.join(dataDir, 'studio.db');
  }
  const db = new DatabaseSync(file);
  db.exec('PRAGMA journal_mode = WAL; PRAGMA foreign_keys = ON; PRAGMA busy_timeout = 5000;');
  db.exec(SCHEMA);
  migrate(db);
  return db;
}

/** Runs fn inside a transaction; rolls back if it throws. */
function transaction(db, fn) {
  db.exec('BEGIN IMMEDIATE');
  try {
    const result = fn();
    db.exec('COMMIT');
    return result;
  } catch (e) {
    try { db.exec('ROLLBACK'); } catch (_) { /* already rolled back */ }
    throw e;
  }
}

const now = () => Math.floor(Date.now() / 1000);

module.exports = { open, transaction, now };
