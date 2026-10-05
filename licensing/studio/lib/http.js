'use strict';
// Small HTTP helpers: request body, cookies, security headers, client address, rate limiting.

const { ApiError } = require('./studio');

/** Allows `limit` hits per `windowSeconds` for a key; used to slow down guessing. */
class RateLimiter {
  constructor(limit, windowSeconds, clock) {
    this.limit = limit;
    this.window = windowSeconds;
    this.clock = clock || (() => Date.now() / 1000);
    this.hits = new Map();
  }

  /** Returns true if the call is allowed (and counts it). */
  take(key) {
    const t = this.clock();
    const list = (this.hits.get(key) || []).filter((x) => x > t - this.window);
    if (list.length >= this.limit) { this.hits.set(key, list); return false; }
    list.push(t);
    this.hits.set(key, list);
    if (this.hits.size > 20000) for (const [k, v] of this.hits) if (!v.some((x) => x > t - this.window)) this.hits.delete(k);
    return true;
  }
}

function readBody(req, maxBytes) {
  return new Promise((resolve, reject) => {
    const chunks = [];
    let size = 0;
    req.on('data', (c) => {
      size += c.length;
      if (size > maxBytes) { reject(new ApiError(413, 'too_large', 'The request is too large.')); req.destroy(); return; }
      chunks.push(c);
    });
    req.on('end', () => resolve(Buffer.concat(chunks).toString('utf8')));
    req.on('error', reject);
  });
}

async function readJson(req, maxBytes = 64 * 1024) {
  const raw = await readBody(req, maxBytes);
  if (!raw) return {};
  try {
    const value = JSON.parse(raw);
    if (!value || typeof value !== 'object' || Array.isArray(value)) throw new Error('x');
    return value;
  } catch (_) {
    throw new ApiError(400, 'bad_request', 'The request is not valid JSON.');
  }
}

/** Reads an HTML form. Repeated names become arrays (for check boxes). */
async function readForm(req, maxBytes = 512 * 1024) {
  const raw = await readBody(req, maxBytes);
  const out = {};
  for (const [k, v] of new URLSearchParams(raw)) {
    if (k in out) out[k] = [].concat(out[k], v);
    else out[k] = v;
  }
  return out;
}

function parseCookies(header) {
  const out = {};
  for (const part of String(header || '').split(';')) {
    const i = part.indexOf('=');
    if (i > 0) out[part.slice(0, i).trim()] = decodeURIComponent(part.slice(i + 1).trim());
  }
  return out;
}

/** The caller's address. X-Forwarded-For is believed only when the Studio is told it sits behind a proxy. */
function clientIp(req, trustProxy) {
  if (trustProxy) {
    const xff = String(req.headers['x-forwarded-for'] || '').split(',')[0].trim();
    if (xff) return xff.slice(0, 64);
  }
  return String(req.socket.remoteAddress || '').replace(/^::ffff:/, '').slice(0, 64);
}

function isSecureRequest(req, trustProxy) {
  if (trustProxy) return String(req.headers['x-forwarded-proto'] || '').split(',')[0].trim() === 'https';
  return !!req.socket.encrypted;
}

function isLoopback(address) {
  return address === '127.0.0.1' || address === '::1' || address === 'localhost';
}

const SECURITY_HEADERS = {
  'X-Content-Type-Options': 'nosniff',
  'X-Frame-Options': 'DENY',
  'Referrer-Policy': 'no-referrer',
  'Cross-Origin-Opener-Policy': 'same-origin',
  'Cross-Origin-Resource-Policy': 'same-origin',
  'Permissions-Policy': 'camera=(), microphone=(), geolocation=()',
  'Content-Security-Policy': "default-src 'none'; img-src 'self' data:; style-src 'self'; script-src 'self'; connect-src 'self'; form-action 'self'; frame-ancestors 'none'; base-uri 'none'",
};

function send(res, status, body, headers = {}) {
  res.writeHead(status, { ...SECURITY_HEADERS, 'Cache-Control': 'no-store', ...headers });
  res.end(body);
}

function sendJson(res, status, value, headers = {}) {
  send(res, status, JSON.stringify(value), { 'Content-Type': 'application/json; charset=utf-8', ...headers });
}

function sendHtml(res, status, html, headers = {}) {
  send(res, status, html, { 'Content-Type': 'text/html; charset=utf-8', ...headers });
}

function redirect(res, location, headers = {}) {
  send(res, 303, '', { Location: location, ...headers });
}

module.exports = {
  RateLimiter, readJson, readForm, readBody, parseCookies, clientIp, isSecureRequest, isLoopback,
  send, sendJson, sendHtml, redirect, SECURITY_HEADERS,
};
