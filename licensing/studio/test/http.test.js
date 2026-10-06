'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { open, now } = require('../lib/db');
const keystore = require('../lib/keystore');
const { Auth } = require('../lib/auth');
const { createApp } = require('../src/app');
const C = require('../lib/crypto');
const { fp } = require('./helpers');

/** Starts a real Studio on a random port with a fresh data folder, an administrator and a salesperson. */
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

test('pages need a sign-in; the sign-in page is hardened', async () => {
  const s = await start();
  try {
    const b = new Browser(s.base);
    for (const p of ['/', '/licences', '/customers', '/settings', '/backup']) {
      const res = await b.fetch(p);
      assert.equal(res.status, 303, p);
      assert.equal(res.headers.get('location'), '/login');
    }
    const login = await b.fetch('/login');
    assert.equal(login.status, 200);
    const csp = login.headers.get('content-security-policy');
    assert.match(csp, /script-src 'self'/);
    assert.match(csp, /frame-ancestors 'none'/);
    assert.equal(login.headers.get('x-frame-options'), 'DENY');
    assert.equal(login.headers.get('cache-control'), 'no-store');
    assert.match(login.headers.getSetCookie().join(';'), /HttpOnly/);
    assert.match(login.headers.getSetCookie().join(';'), /SameSite=Strict/);
    assert.ok(!(await login.text()).includes('<script>'), 'no inline scripts');
  } finally { await s.stop(); }
});

test('sign-in: wrong password is refused with one generic message; CSRF is required', async () => {
  const s = await start();
  try {
    const b = new Browser(s.base);
    const bad = await b.post('/login', { email: 'boss@example.com', password: 'nope' }, '/login');
    assert.equal(bad.status, 200);
    assert.match(await bad.text(), /e-mail or the password is not right/);
    const nobody = await b.post('/login', { email: 'nobody@example.com', password: 'nope' }, '/login');
    assert.match(await nobody.text(), /e-mail or the password is not right/);

    await b.fetch('/login');
    const noToken = await b.fetch('/login', { method: 'POST', headers: { 'content-type': 'application/x-www-form-urlencoded' }, body: 'email=boss%40example.com&password=Correct-Horse-9' });
    assert.match(await noToken.text(), /page expired/);

    await b.login('boss@example.com');
    assert.equal((await b.fetch('/')).status, 200);
    // A POST without the CSRF token is refused even when signed in.
    const forged = await b.fetch('/licences/new', { method: 'POST', headers: { 'content-type': 'application/x-www-form-urlencoded' }, body: 'customerId=new&nc_name=Evil&planCode=starter&term=y1' });
    assert.equal(forged.status, 403);
    assert.equal(s.app.db.prepare('SELECT COUNT(*) AS n FROM customers').get().n, 0);
  } finally { await s.stop(); }
});

test('sales can sell and look up, but cannot reach admin pages or withdraw a licence', async () => {
  const s = await start();
  try {
    const b = new Browser(s.base);
    await b.login('sam@example.com');
    for (const p of ['/', '/licences', '/licences/new', '/customers', '/offline', '/brands', '/help']) assert.equal((await b.fetch(p)).status, 200, p);
    for (const p of ['/users', '/plans', '/audit', '/settings', '/backup', '/brands/new']) assert.equal((await b.fetch(p)).status, 403, p);

    const created = await b.post('/licences/new', { customerId: 'new', nc_name: 'Blue Bazaar', nc_country: 'Philippines', nc_email: 'owner@bluebazaar.example', nc_contactName: 'Maria', planCode: 'business', term: 'y1', bindMode: 'device', whiteLevel: 'theme' }, '/licences/new');
    assert.equal(created.status, 303);
    const lid = /\/licences\/(L-[0-9A-Z]+)/.exec(created.headers.get('location'))[1];
    const view = await (await b.fetch(`/licences/${lid}`)).text();
    assert.match(view, /NGOS-[0-9A-Z]{5}-/);
    assert.match(view, /Hello Maria,/);
    assert.ok(!view.includes('Withdraw for good'), 'sales must not see the withdraw button');

    const revoke = await b.post(`/licences/${lid}/revoke`, { reason: 'x' }, `/licences/${lid}`);
    assert.equal(revoke.status, 403);
    assert.equal(s.app.studio.getLicence(lid).status, 'active');

    // Over the plan limit: the form comes back with a plain message and nothing is created.
    const tooMany = await b.post('/licences/new', { customerId: '1', planCode: 'business', term: 'y1', devices: '99', bindMode: 'device', whiteLevel: 'theme' }, '/licences/new');
    assert.equal(tooMany.status, 200);
    assert.match(await tooMany.text(), /allows up to 10 PCs/);

    // Perpetual and full re-brand are not offered to sales.
    const page = await (await b.fetch('/licences/new')).text();
    assert.ok(!page.includes('value="perpetual"'));
    assert.ok(!page.includes('Full re-brand'));
  } finally { await s.stop(); }
});

test('administrator: whole path from sale to activation, PC release, hold, withdraw', async () => {
  const s = await start();
  try {
    const admin = new Browser(s.base);
    await admin.login('boss@example.com');
    const created = await admin.post('/licences/new', { customerId: 'new', nc_name: 'Green Mart', planCode: 'starter', term: 'y1', bindMode: 'device', whiteLevel: 'theme' }, '/licences/new');
    const lid = /\/licences\/(L-[0-9A-Z]+)/.exec(created.headers.get('location'))[1];
    const lic = s.app.studio.getLicence(lid);

    // The app activates over the API.
    const call = async (p, body) => { const r = await fetch(s.base + p, { method: 'POST', headers: { 'content-type': 'application/json' }, body: JSON.stringify(body) }); return { status: r.status, body: await r.json() }; };
    const a1 = await call('/api/v1/activate', { key: lic.licence_key.toLowerCase(), version: '2.18.0', fp: fp('counter-1'), host: 'COUNTER-1' });
    assert.equal(a1.status, 200);
    const keys = s.app.studio.trustedKeys();
    assert.equal(C.verifyToken(a1.body.lic, keys, 'lic').lid, lid);

    // Starter allows one PC: a second one is refused with a plain message.
    const a2 = await call('/api/v1/activate', { key: lic.licence_key, fp: fp('counter-2'), host: 'COUNTER-2' });
    assert.equal(a2.status, 409);
    assert.equal(a2.body.error.code, 'limit_reached');

    // The admin frees the first PC from the page.
    const view = await (await admin.fetch(`/licences/${lid}`)).text();
    assert.match(view, /COUNTER-1/);
    const actId = /\/free\/(\d+)/.exec(view)[1];
    assert.equal((await admin.post(`/licences/${lid}/free/${actId}`, {}, `/licences/${lid}`)).status, 303);
    assert.equal((await call('/api/v1/activate', { key: lic.licence_key, fp: fp('counter-2'), host: 'COUNTER-2' })).status, 200);

    // Hold: check-in fails with "suspended", the list shows the licence.
    await admin.post(`/licences/${lid}/suspend`, { reason: 'unpaid' }, `/licences/${lid}`);
    const held = await call('/api/v1/checkin', { lid, act: a1.body.act, fp: fp('counter-1') });
    assert.equal(held.body.error.code, 'suspended');
    const crl = await (await fetch(s.base + '/api/v1/crl')).json();
    assert.deepEqual(C.verifyToken(crl.crl, keys, 'crl').revoked, [lid]);
    await admin.post(`/licences/${lid}/resume`, {}, `/licences/${lid}`);
    assert.deepEqual(C.verifyToken((await (await fetch(s.base + '/api/v1/crl')).json()).crl, keys, 'crl').revoked, []);

    // Withdraw is permanent.
    await admin.post(`/licences/${lid}/revoke`, { reason: 'fraud' }, `/licences/${lid}`);
    assert.equal(s.app.studio.getLicence(lid).status, 'revoked');
    assert.equal((await call('/api/v1/activate', { key: lic.licence_key, fp: fp('counter-3') })).body.error.code, 'revoked');

    // Everything was written to the history.
    const audit = await (await admin.fetch('/audit')).text();
    for (const word of ['licence.create', 'activate', 'device.free', 'licence.suspended', 'licence.revoked']) assert.ok(audit.includes(word), word);

    // Download and backup work for administrators.
    const dl = await admin.fetch(`/licences/${lid}/download`);
    assert.match(dl.headers.get('content-disposition'), /licence-L-/);
    assert.match(await dl.text(), /^NGOS1\./);
    const backup = await admin.fetch('/backup');
    assert.equal(backup.status, 200);
    assert.equal(Buffer.from(await backup.arrayBuffer()).subarray(0, 15).toString(), 'SQLite format 3');
  } finally { await s.stop(); }
});

test('offline activation through the page', async () => {
  const s = await start();
  try {
    const b = new Browser(s.base);
    await b.login('sue@example.com'); // support may use the offline tool
    const customer = s.app.studio.createCustomer({ name: 'Remote Shop' }, { id: null, email: 'x', role: 'admin' }, 'ip');
    const lic = s.app.studio.createLicence({ customerId: customer.id, planCode: 'business', term: 'y1', offline: true }, { id: null, email: 'x', role: 'admin' }, 'ip');
    const request = 'NGOSREQ1.' + Buffer.from(JSON.stringify({ key: lic.licence_key, fp: fp('far-away'), host: 'FARPC', version: '2.18.0' })).toString('base64url');
    const res = await b.post('/offline', { request }, '/offline');
    const html = await res.text();
    assert.equal(res.status, 200);
    const answer = /NGOSRES1\.[A-Za-z0-9_-]+/.exec(html)[0];
    const body = JSON.parse(Buffer.from(answer.slice(9), 'base64url').toString());
    assert.equal(C.verifyToken(body.act, s.app.studio.trustedKeys(), 'act').lid, lic.lid);
    const bad = await (await b.post('/offline', { request: 'junk' }, '/offline')).text();
    assert.match(bad, /not a request code/);
  } finally { await s.stop(); }
});

test('API: rate limit on wrong keys, bad input is refused, unknown calls 404', async () => {
  const s = await start();
  try {
    const call = (p, body, method = 'POST') => fetch(s.base + p, { method, headers: { 'content-type': 'application/json' }, body: method === 'POST' ? JSON.stringify(body) : undefined });
    assert.equal((await call('/api/v1/health', null, 'GET')).status, 200);
    assert.equal((await call('/api/v1/nothing', {})).status, 404);
    assert.equal((await call('/api/v1/activate', { key: 5 })).status, 400);
    assert.equal((await call('/api/v1/activate', { key: 'NGOS-AAAAA-AAAAA-AAAAA-AAAAA', fp: { os: 'nothex' } })).status, 404); // unknown key is answered before the fingerprint
    const raw = await fetch(s.base + '/api/v1/activate', { method: 'POST', body: '{not json' });
    assert.equal(raw.status, 400);
    let last;
    for (let i = 0; i < 12; i += 1) last = await call('/api/v1/activate', { key: 'NGOS-AAAAA-AAAAA-AAAAA-AAAAA', fp: { os: '0'.repeat(32) } });
    assert.equal(last.status, 429);
  } finally { await s.stop(); }
});

test('password change signs the person out; a temporary password must be replaced first', async () => {
  const s = await start();
  try {
    const admin = new Browser(s.base);
    await admin.login('boss@example.com');
    const res = await admin.post('/users', { name: 'New Person', email: 'new@example.com', role: 'sales' }, '/users');
    const html = await res.text();
    const temp = /Temporary password \(shown once\): <span class="mono">([A-Z0-9-]+)<\/span>/.exec(html)[1];

    const nb = new Browser(s.base);
    const login = await nb.login('new@example.com', temp);
    assert.equal(login.headers.get('location'), '/account?forced=1');
    assert.equal((await nb.fetch('/licences')).headers.get('location'), '/account?forced=1');
    const changed = await nb.post('/account/password', { current: temp, password: 'Brand-New-Pass-77' }, '/account');
    assert.equal(changed.status, 303);
    assert.match(changed.headers.get('location'), /^\/login/);
    await nb.login('new@example.com', 'Brand-New-Pass-77');
    assert.equal((await nb.fetch('/licences')).status, 200);
  } finally { await s.stop(); }
});

test('settings: the release box shows the public keys and the address, never a private key, and asks for the address first', async () => {
  const s = await start();
  try {
    const admin = new Browser(s.base);
    await admin.login('boss@example.com');
    const first = await (await admin.fetch('/settings')).text();
    assert.match(first, /NGOS_PUBLIC_KEYS/);
    assert.match(first, /public address[^<]*above and save it first/, 'no address yet: it says to fill it in');
    const shown = JSON.parse(first.match(/<textarea id="rel-keys"[^>]*>([\s\S]*?)<\/textarea>/)[1].replace(/&quot;/g, '"'));
    assert.deepEqual(shown.keys, JSON.parse(JSON.stringify(s.app.studio.trustedKeys())), 'exactly what "export-public-keys" prints');
    assert.doesNotMatch(first, /"d"\s*:|privateKey|private_key/, 'nothing private is shown');
    await admin.post('/settings', { public_url: 'https://licence.example.com/' }, '/settings');
    const second = await (await admin.fetch('/settings')).text();
    assert.match(second, /<input id="rel-url"[^>]*value="https:\/\/licence\.example\.com"/, 'the address, without the closing slash');
    assert.doesNotMatch(second, /above and save it first/);
  } finally { await s.stop(); }
});

test('settings: key rotation prepares a key first and only then switches', async () => {
  const s = await start();
  try {
    const admin = new Browser(s.base);
    await admin.login('boss@example.com');
    const before = s.app.studio.signer.kid;
    await admin.post('/settings/key/prepare', {}, '/settings');
    const keys = s.app.db.prepare('SELECT kid, status FROM keys').all();
    assert.equal(keys.length, 2);
    const pending = keys.find((k) => k.status === 'pending');
    assert.equal(s.app.studio.signer.kid, before, 'still signing with the old key');
    await admin.post('/settings/key/switch', { kid: pending.kid }, '/settings');
    assert.equal(s.app.studio.signer.kid, pending.kid);
    // Licences signed before still verify, because the old key stays trusted.
    const customer = s.app.studio.createCustomer({ name: 'K' }, { id: null, email: 'x', role: 'admin' }, 'ip');
    const lic = s.app.studio.createLicence({ customerId: customer.id, planCode: 'starter', term: 'y1' }, { id: null, email: 'x', role: 'admin' }, 'ip');
    const token = s.app.studio.licenceToken(lic);
    assert.equal(JSON.parse(Buffer.from(token.split('.')[1], 'base64url')).kid, pending.kid);
    assert.equal(C.verifyToken(token, s.app.studio.trustedKeys(), 'lic').lid, lic.lid);
  } finally { await s.stop(); }
});
