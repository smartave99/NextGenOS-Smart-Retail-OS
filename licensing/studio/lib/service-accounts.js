'use strict';
// Sign-ins for tools, not people: the main Setup Studio calls the Licence Studio's staff API with one of these.
// An administrator makes the account, the token is shown once, and only a hash of it is kept (so a copy of the database
// cannot be used to sign in). An account has a role from the Studio's own role model, so it can do only what that role can.

const C = require('./crypto');
const { PERMISSIONS } = require('./auth');

const TOKEN_PREFIX = 'ngsa_';

class ServiceAccounts {
  constructor(db, clock) {
    this.db = db;
    this.clock = clock || (() => Math.floor(Date.now() / 1000));
  }

  /** Makes an account. Returns { id, name, role, token }: the token is shown to the administrator this once and is not kept. */
  create({ name, role, createdBy }) {
    const label = String(name || '').trim().slice(0, 60);
    if (!label) throw new Error('Give the account a name (for example "Main Studio").');
    if (!PERMISSIONS[role]) throw new Error('Choose a role.');
    const token = TOKEN_PREFIX + C.randomToken(32);
    const r = this.db.prepare('INSERT INTO service_accounts(name, role, token_hash, token_hint, created_by, created_at) VALUES (?,?,?,?,?,?)')
      .run(label, role, C.sha256Hex(token), token.slice(0, 9), String(createdBy || '').slice(0, 120), this.clock());
    return { id: Number(r.lastInsertRowid), name: label, role, token };
  }

  list() {
    return this.db.prepare('SELECT id, name, role, token_hint, active, created_by, created_at, last_used_at, revoked_at FROM service_accounts ORDER BY active DESC, created_at DESC').all();
  }

  get(id) {
    return this.db.prepare('SELECT id, name, role, token_hint, active, created_by, created_at, last_used_at, revoked_at FROM service_accounts WHERE id = ?').get(id) || null;
  }

  /** Switches an account off for good. Its token stops working at once. */
  revoke(id) {
    const a = this.get(id);
    if (!a) throw new Error('That account was not found.');
    this.db.prepare('UPDATE service_accounts SET active = 0, revoked_at = ? WHERE id = ? AND active = 1').run(this.clock(), id);
    return this.get(id);
  }

  /** The account a token belongs to, or null (unknown, malformed or switched off). Notes when it was last used. */
  authenticate(token) {
    const t = String(token || '');
    if (!t.startsWith(TOKEN_PREFIX) || t.length < 30 || t.length > 200) return null;
    const row = this.db.prepare('SELECT id, name, role, active FROM service_accounts WHERE token_hash = ?').get(C.sha256Hex(t));
    if (!row || !row.active) return null;
    const now = this.clock();
    this.db.prepare('UPDATE service_accounts SET last_used_at = ? WHERE id = ?').run(now, row.id);
    return { id: row.id, name: row.name, role: row.role };
  }
}

module.exports = { ServiceAccounts, TOKEN_PREFIX };
