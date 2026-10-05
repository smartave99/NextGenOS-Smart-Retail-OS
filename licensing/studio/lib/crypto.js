'use strict';
// Cryptography for the Licence Studio: signing keys, signed tokens, key encryption, passwords.
// Only Node's built-in `crypto` is used. The format is specified in ../../spec/LICENCE-FORMAT.md.

const crypto = require('node:crypto');

const TOKEN_PREFIX = 'NGOS1';
const ISSUER = 'nextgenos';

const b64u = (buf) => Buffer.from(buf).toString('base64url');
const fromB64u = (text) => Buffer.from(String(text), 'base64url');

/** A new P-256 signing key: { kid, publicKey (b64u uncompressed point), privateKeyPem }. */
function generateSigningKey() {
  const { publicKey, privateKey } = crypto.generateKeyPairSync('ec', { namedCurve: 'prime256v1' });
  const jwk = publicKey.export({ format: 'jwk' });
  const point = Buffer.concat([Buffer.from([0x04]), fromB64u(jwk.x), fromB64u(jwk.y)]);
  const kid = 'k' + new Date().toISOString().slice(0, 10).replace(/-/g, '') + '-' + crypto.randomBytes(3).toString('hex');
  return {
    kid,
    publicKey: b64u(point),
    privateKeyPem: privateKey.export({ type: 'pkcs8', format: 'pem' }),
  };
}

/** Turns a b64u uncompressed point into a Node public KeyObject. */
function publicKeyObject(publicKeyB64u) {
  const point = fromB64u(publicKeyB64u);
  if (point.length !== 65 || point[0] !== 0x04) throw new Error('Not an uncompressed P-256 public key.');
  return crypto.createPublicKey({
    key: { kty: 'EC', crv: 'P-256', x: b64u(point.subarray(1, 33)), y: b64u(point.subarray(33, 65)) },
    format: 'jwk',
  });
}

/** Signs a payload object as a token. `signer` is { kid, privateKeyPem }. */
function signToken(payload, signer) {
  const body = Object.assign({ v: 1, iss: ISSUER, kid: signer.kid }, payload);
  const head = `${TOKEN_PREFIX}.${b64u(Buffer.from(JSON.stringify(body), 'utf8'))}`;
  const signature = crypto.sign('sha256', Buffer.from(head, 'ascii'), {
    key: signer.privateKeyPem,
    dsaEncoding: 'ieee-p1363',
  });
  return `${head}.${b64u(signature)}`;
}

/**
 * Verifies a token against a list of trusted keys [{ kid, publicKey }].
 * Returns the payload, or throws an Error whose message says what failed.
 */
function verifyToken(token, trustedKeys, expectedType) {
  const parts = String(token || '').split('.');
  if (parts.length !== 3 || parts[0] !== TOKEN_PREFIX) throw new Error('Not a NextGen OS token.');
  let payload;
  try {
    payload = JSON.parse(fromB64u(parts[1]).toString('utf8'));
  } catch (e) {
    throw new Error('Token payload is not valid.');
  }
  if (!payload || typeof payload !== 'object' || payload.iss !== ISSUER) throw new Error('Wrong issuer.');
  const key = (trustedKeys || []).find((k) => k.kid === payload.kid);
  if (!key) throw new Error('Unknown signing key.');
  const signature = fromB64u(parts[2]);
  const ok = signature.length === 64 && crypto.verify(
    'sha256',
    Buffer.from(`${parts[0]}.${parts[1]}`, 'ascii'),
    { key: publicKeyObject(key.publicKey), dsaEncoding: 'ieee-p1363' },
    signature,
  );
  if (!ok) throw new Error('Signature does not match.');
  if (payload.v !== 1) throw new Error('Unsupported version.');
  if (expectedType && payload.typ !== expectedType) throw new Error(`Expected a ${expectedType} token.`);
  return payload;
}

// ----- Encrypting the private key at rest (scrypt + AES-256-GCM) -----

function encryptSecret(plainText, passphrase) {
  const salt = crypto.randomBytes(16);
  const iv = crypto.randomBytes(12);
  const key = crypto.scryptSync(passphrase, salt, 32, { N: 1 << 15, r: 8, p: 1, maxmem: 128 * 1024 * 1024 });
  const cipher = crypto.createCipheriv('aes-256-gcm', key, iv);
  const data = Buffer.concat([cipher.update(plainText, 'utf8'), cipher.final()]);
  return { v: 1, kdf: 'scrypt', salt: b64u(salt), iv: b64u(iv), tag: b64u(cipher.getAuthTag()), data: b64u(data) };
}

function decryptSecret(box, passphrase) {
  const key = crypto.scryptSync(passphrase, fromB64u(box.salt), 32, { N: 1 << 15, r: 8, p: 1, maxmem: 128 * 1024 * 1024 });
  const decipher = crypto.createDecipheriv('aes-256-gcm', key, fromB64u(box.iv));
  decipher.setAuthTag(fromB64u(box.tag));
  try {
    return Buffer.concat([decipher.update(fromB64u(box.data)), decipher.final()]).toString('utf8');
  } catch (e) {
    throw new Error('Wrong passphrase, or the key file was changed.');
  }
}

// ----- Passwords and random values -----

function hashPassword(password) {
  const salt = crypto.randomBytes(16);
  const hash = crypto.scryptSync(password, salt, 32, { N: 1 << 15, r: 8, p: 1, maxmem: 128 * 1024 * 1024 });
  return `scrypt$${b64u(salt)}$${b64u(hash)}`;
}

function verifyPassword(password, stored) {
  const [kind, salt, hash] = String(stored || '').split('$');
  if (kind !== 'scrypt' || !salt || !hash) return false;
  const expected = fromB64u(hash);
  const actual = crypto.scryptSync(password, fromB64u(salt), expected.length, { N: 1 << 15, r: 8, p: 1, maxmem: 128 * 1024 * 1024 });
  return crypto.timingSafeEqual(actual, expected);
}

const sha256Hex = (text) => crypto.createHash('sha256').update(text).digest('hex');
const randomToken = (bytes = 32) => crypto.randomBytes(bytes).toString('base64url');

/** Constant-time string comparison. */
function safeEqual(a, b) {
  const x = Buffer.from(String(a));
  const y = Buffer.from(String(b));
  return x.length === y.length && crypto.timingSafeEqual(x, y);
}

// ----- Licence keys: NGOS-XXXXX-XXXXX-XXXXX-XXXXX, Crockford base 32 (no I L O U) -----

const KEY_ALPHABET = '0123456789ABCDEFGHJKMNPQRSTVWXYZ';

function randomChars(count) {
  let out = '';
  while (out.length < count) {
    for (const byte of crypto.randomBytes(count * 2)) {
      if (byte < 224) out += KEY_ALPHABET[byte % 32]; // 224 = 7 * 32: no modulo bias
      if (out.length === count) break;
    }
  }
  return out;
}

function generateLicenceKey() {
  const body = randomChars(20);
  return 'NGOS-' + body.match(/.{5}/g).join('-');
}

/** Normalises what a person typed (case, spaces, look-alike characters) and returns the canonical key, or null. */
function normaliseLicenceKey(text) {
  let s = String(text || '').toUpperCase().replace(/[^0-9A-Z]/g, '');
  if (s.startsWith('NGOS')) s = s.slice(4);
  s = s.replace(/O/g, '0').replace(/[IL]/g, '1');
  if (!/^[0-9A-HJKMNP-TV-Z]{20}$/.test(s)) return null;
  return 'NGOS-' + s.match(/.{5}/g).join('-');
}

function generateLicenceId() {
  return 'L-' + randomChars(8);
}

module.exports = {
  TOKEN_PREFIX, ISSUER, b64u, fromB64u,
  generateSigningKey, publicKeyObject, signToken, verifyToken,
  encryptSecret, decryptSecret, hashPassword, verifyPassword,
  sha256Hex, randomToken, safeEqual,
  generateLicenceKey, normaliseLicenceKey, generateLicenceId,
};
