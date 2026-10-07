'use strict';
// Test rig for the Studio's web pages: a real Studio on a random port, and a tiny browser that keeps cookies and CSRF tokens.

const assert = require('node:assert/strict');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { open, now } = require('../lib/db');
const keystore = require('../lib/keystore');
const { Auth } = require('../lib/auth');
const { createApp } = require('../src/app');

/** Starts a real Studio on a random port with a fresh data folder, an administrator, a salesperson and a support person. */
async function start() {
  const dataDir = fs.mkdtempSync(path.join(os.tmpdir(), 'studio-http-'));
  const db0 = open(dataDir);
  keystore.createKey(db0, dataDir, now());
  const auth0 = new Auth(db0);
  auth0.createUser({ email: 'boss@example.com', name: 'Boss', role: 'admin', password: 'Correct-Horse-9' });
  auth0.createUser({ email: 'sam@example.com', name: 'Sam', role: 'sales', password: 'Correct-Horse-9' });
  auth0.createUser({ email: 'sue@example.com', name: 'Sue', role: 'support', password: 'Correct-Horse-9' });
  db0.close();
  const app = createApp({ dataDir });
  await new Promise((r) => app.server.listen(0, '127.0.0.1', r));
  const base = `http://127.0.0.1:${app.server.address().port}`;
  return { app, base, dataDir, stop: () => new Promise((r) => app.server.close(r)) };
}

/** A tiny browser: keeps cookies, follows nothing, reads the CSRF token out of pages. */
class Browser {
  constructor(base) { this.base = base; this.jar = {}; }
  async fetch(p, opts = {}) {
    const headers = { ...(opts.headers || {}), cookie: Object.entries(this.jar).map(([k, v]) => `${k}=${v}`).join('; ') };
    const res = await fetch(this.base + p, { redirect: 'manual', ...opts, headers });
    for (const c of res.headers.getSetCookie()) {
      const [pair] = c.split(';');
      const i = pair.indexOf('=');
      const value = pair.slice(i + 1);
      if (/Max-Age=0/i.test(c)) delete this.jar[pair.slice(0, i)]; else this.jar[pair.slice(0, i)] = value;
    }
    return res;
  }
  async csrf(p) { const html = await (await this.fetch(p)).text(); const m = /name="_csrf" value="([^"]+)"/.exec(html); return m && m[1]; }
  async post(p, form, csrfFrom = p) {
    const token = await this.csrf(csrfFrom);
    return this.fetch(p, { method: 'POST', headers: { 'content-type': 'application/x-www-form-urlencoded' }, body: new URLSearchParams({ _csrf: token, ...form }).toString() });
  }
  async login(email, password = 'Correct-Horse-9') {
    const res = await this.post('/login', { email, password }, '/login');
    assert.equal(res.status, 303, 'login should redirect');
    return res;
  }
}

module.exports = { start, Browser };
