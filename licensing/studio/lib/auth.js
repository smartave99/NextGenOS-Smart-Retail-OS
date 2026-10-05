'use strict';
// Users, roles, sign-in and sessions for the Studio's web pages.

const C = require('./crypto');

const SESSION_HOURS = 10;
const MAX_FAILED = 5;
const LOCK_MINUTES = 15;

const PERMISSIONS = {
  admin: ['*'],
  sales: ['customers.write', 'customers.view', 'licences.view', 'licences.create', 'licences.change', 'devices.free', 'offline.use', 'brands.view'],
  support: ['customers.view', 'licences.view', 'devices.free', 'offline.use', 'brands.view'],
};

const ROLE_LABELS = { admin: 'Administrator', sales: 'Sales', support: 'Support' };

function can(user, permission) {
  if (!user) return false;
  const list = PERMISSIONS[user.role] || [];
  return list.includes('*') || list.includes(permission);
}

class Auth {
  constructor(db, clock) {
    this.db = db;
    this.clock = clock || (() => Math.floor(Date.now() / 1000));
  }

  static validatePassword(password) {
    const p = String(password || '');
    if (p.length < 10) return 'The password needs at least 10 characters.';
    if (!/[a-zA-Z]/.test(p) || !/[0-9]/.test(p)) return 'The password needs letters and at least one number.';
    return null;
  }

  createUser({ email, name, role, password, mustChange }) {
    const mail = String(email || '').trim().toLowerCase();
    if (!/^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(mail)) throw new Error('Enter a valid e-mail address.');
    if (!PERMISSIONS[role]) throw new Error('Choose a role.');
    const problem = Auth.validatePassword(password);
    if (problem) throw new Error(problem);
    const r = this.db.prepare('INSERT INTO users(email, name, role, pass_hash, must_change_password, created_at) VALUES (?,?,?,?,?,?)')
      .run(mail, String(name || mail).trim().slice(0, 80), role, C.hashPassword(password), mustChange ? 1 : 0, this.clock());
    return Number(r.lastInsertRowid);
  }

  listUsers() { return this.db.prepare('SELECT id, email, name, role, active, must_change_password, created_at FROM users ORDER BY name').all(); }

  getUser(id) { return this.db.prepare('SELECT id, email, name, role, active, must_change_password FROM users WHERE id = ?').get(id) || null; }

  countAdmins() { return this.db.prepare("SELECT COUNT(*) AS n FROM users WHERE role = 'admin' AND active = 1").get().n; }

  setActive(id, active) {
    const u = this.getUser(id);
    if (!u) throw new Error('User not found.');
    if (!active && u.role === 'admin' && this.countAdmins() <= 1) throw new Error('There must be at least one active administrator.');
    this.db.prepare('UPDATE users SET active = ? WHERE id = ?').run(active ? 1 : 0, id);
    if (!active) this.db.prepare('DELETE FROM sessions WHERE user_id = ?').run(id);
  }

  setRole(id, role) {
    const u = this.getUser(id);
    if (!u || !PERMISSIONS[role]) throw new Error('User or role not found.');
    if (u.role === 'admin' && role !== 'admin' && this.countAdmins() <= 1) throw new Error('There must be at least one active administrator.');
    this.db.prepare('UPDATE users SET role = ? WHERE id = ?').run(role, id);
  }

  setPassword(id, password, mustChange) {
    const problem = Auth.validatePassword(password);
    if (problem) throw new Error(problem);
    this.db.prepare('UPDATE users SET pass_hash = ?, must_change_password = ?, failed_logins = 0, locked_until = 0 WHERE id = ?')
      .run(C.hashPassword(password), mustChange ? 1 : 0, id);
    this.db.prepare('DELETE FROM sessions WHERE user_id = ?').run(id);
  }

  /** Returns { ok: true, user } or { ok: false, message }. The message never says which part was wrong. */
  login(email, password) {
    const t = this.clock();
    const row = this.db.prepare('SELECT * FROM users WHERE email = ?').get(String(email || '').trim().toLowerCase());
    const generic = { ok: false, message: 'The e-mail or the password is not right.' };
    if (!row || !row.active) {
      C.verifyPassword(password || '', 'scrypt$AAAAAAAAAAAAAAAAAAAAAA$AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA'); // keep the timing the same
      return generic;
    }
    if (row.locked_until > t) return { ok: false, message: `Too many wrong attempts. Try again in ${Math.ceil((row.locked_until - t) / 60)} minutes.` };
    if (!C.verifyPassword(String(password || ''), row.pass_hash)) {
      const failed = row.failed_logins + 1;
      this.db.prepare('UPDATE users SET failed_logins = ?, locked_until = ? WHERE id = ?').run(failed >= MAX_FAILED ? 0 : failed, failed >= MAX_FAILED ? t + LOCK_MINUTES * 60 : 0, row.id);
      return generic;
    }
    this.db.prepare('UPDATE users SET failed_logins = 0, locked_until = 0 WHERE id = ?').run(row.id);
    return { ok: true, user: { id: row.id, email: row.email, name: row.name, role: row.role, mustChange: !!row.must_change_password } };
  }

  startSession(userId, ip) {
    const token = C.randomToken(32);
    const csrf = C.randomToken(24);
    const t = this.clock();
    this.db.prepare('INSERT INTO sessions(token_hash, user_id, csrf, ip, created_at, expires_at) VALUES (?,?,?,?,?,?)')
      .run(C.sha256Hex(token), userId, csrf, String(ip || '').slice(0, 64), t, t + SESSION_HOURS * 3600);
    this.db.prepare('DELETE FROM sessions WHERE expires_at < ?').run(t);
    return { token, csrf, maxAge: SESSION_HOURS * 3600 };
  }

  /** The signed-in user and CSRF token for a session cookie value, or null. */
  session(token) {
    if (!token) return null;
    const row = this.db.prepare(`SELECT s.csrf, s.expires_at, u.id, u.email, u.name, u.role, u.active, u.must_change_password
      FROM sessions s JOIN users u ON u.id = s.user_id WHERE s.token_hash = ?`).get(C.sha256Hex(token));
    if (!row || row.expires_at < this.clock() || !row.active) return null;
    return { csrf: row.csrf, user: { id: row.id, email: row.email, name: row.name, role: row.role, mustChange: !!row.must_change_password } };
  }

  endSession(token) {
    if (token) this.db.prepare('DELETE FROM sessions WHERE token_hash = ?').run(C.sha256Hex(token));
  }
}

module.exports = { Auth, can, PERMISSIONS, ROLE_LABELS };
