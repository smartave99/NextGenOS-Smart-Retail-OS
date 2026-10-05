'use strict';
// The signing key: created once, kept encrypted on disk, unlocked with a passphrase.

const fs = require('node:fs');
const path = require('node:path');
const C = require('./crypto');

function keyDir(dataDir) { return path.join(dataDir, 'keys'); }

/** The passphrase comes from STUDIO_PASSPHRASE, or from <data>/passphrase.txt (created at setup, mode 600). */
function readPassphrase(dataDir) {
  if (process.env.STUDIO_PASSPHRASE) return process.env.STUDIO_PASSPHRASE;
  const file = path.join(dataDir, 'passphrase.txt');
  if (fs.existsSync(file)) return fs.readFileSync(file, 'utf8').trim();
  throw new Error('The signing key passphrase is missing. Set STUDIO_PASSPHRASE, or restore <data>/passphrase.txt.');
}

/**
 * Creates a signing key. The first key is active at once; a later one is only prepared ('pending'), so that its public key can
 * be put into the next release of the apps before anything is signed with it. activateKey() then switches over.
 */
function createKey(db, dataDir, now) {
  fs.mkdirSync(keyDir(dataDir), { recursive: true, mode: 0o700 });
  let passphrase;
  try {
    passphrase = readPassphrase(dataDir);
  } catch (_) {
    passphrase = C.randomToken(32);
    fs.writeFileSync(path.join(dataDir, 'passphrase.txt'), passphrase + '\n', { mode: 0o600 });
  }
  const key = C.generateSigningKey();
  const box = C.encryptSecret(key.privateKeyPem, passphrase);
  fs.writeFileSync(path.join(keyDir(dataDir), `${key.kid}.key.json`), JSON.stringify({ kid: key.kid, publicKey: key.publicKey, ...box }, null, 2), { mode: 0o600 });
  const first = db.prepare("SELECT COUNT(*) AS n FROM keys WHERE status = 'active'").get().n === 0;
  db.prepare('INSERT INTO keys(kid, public_key, status, created_at) VALUES (?,?,?,?)').run(key.kid, key.publicKey, first ? 'active' : 'pending', now);
  return { kid: key.kid, publicKey: key.publicKey, status: first ? 'active' : 'pending' };
}

/** Switches signing to a prepared key; the old one stays trusted for checking what it signed. */
function activateKey(db, kid) {
  const row = db.prepare("SELECT kid FROM keys WHERE kid = ? AND status = 'pending'").get(kid);
  if (!row) throw new Error('That key is not waiting to be switched on.');
  db.exec("UPDATE keys SET status = 'retired' WHERE status = 'active'");
  db.prepare("UPDATE keys SET status = 'active' WHERE kid = ?").run(kid);
}

/** Loads and decrypts the active signing key: { kid, privateKeyPem }. */
function loadSigner(db, dataDir) {
  const row = db.prepare("SELECT kid FROM keys WHERE status = 'active' ORDER BY created_at DESC LIMIT 1").get();
  if (!row) throw new Error('There is no signing key yet. Run "node src/cli.js init" first.');
  const file = path.join(keyDir(dataDir), `${row.kid}.key.json`);
  if (!fs.existsSync(file)) throw new Error(`The key file ${file} is missing. Restore it from your backup.`);
  const box = JSON.parse(fs.readFileSync(file, 'utf8'));
  return { kid: row.kid, privateKeyPem: C.decryptSecret(box, readPassphrase(dataDir)) };
}

module.exports = { createKey, activateKey, loadSigner, readPassphrase };
