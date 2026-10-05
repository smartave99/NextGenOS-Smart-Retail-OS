'use strict';
// Shared test setup: an in-memory Studio with a fresh key and a movable clock.

const { open } = require('../lib/db');
const C = require('../lib/crypto');
const { Studio } = require('../lib/studio');
const { Auth } = require('../lib/auth');

function makeStudio() {
  const db = open(':memory:');
  const state = { t: 1_800_000_000 }; // fixed "now" for repeatable tests
  const clock = () => state.t;
  const key = C.generateSigningKey();
  db.prepare('INSERT INTO keys(kid, public_key, status, created_at) VALUES (?,?,?,?)').run(key.kid, key.publicKey, 'active', state.t);
  const studio = new Studio({ db, signer: { kid: key.kid, privateKeyPem: key.privateKeyPem }, clock });
  studio.seedDefaults();
  const addUser = db.prepare('INSERT INTO users(id, email, name, role, pass_hash, created_at) VALUES (?,?,?,?,?,?)');
  addUser.run(1, 'admin@example.com', 'Admin', 'admin', 'x', state.t);
  addUser.run(2, 'sales@example.com', 'Sales', 'sales', 'x', state.t);
  const auth = new Auth(db, clock);
  return { db, studio, auth, state, key, trusted: [{ kid: key.kid, publicKey: key.publicKey }] };
}

const ADMIN = { id: 1, email: 'admin@example.com', role: 'admin' };
const SALES = { id: 2, email: 'sales@example.com', role: 'sales' };

/** A fake PC fingerprint: five parts, derived from a name. */
function fp(name, kinds = ['bios', 'board', 'cpu', 'disk', 'os']) {
  const crypto = require('node:crypto');
  const out = {};
  for (const k of kinds) out[k] = crypto.createHash('sha256').update(`ngos-fp-v1:${k}:${name}-${k}`).digest('hex').slice(0, 32);
  return out;
}

module.exports = { makeStudio, ADMIN, SALES, fp };
