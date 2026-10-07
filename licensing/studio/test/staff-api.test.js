'use strict';
// The staff API (licensing/spec/STAFF-API.md): sign-in with a service-account token, roles, idempotency, audit, rate limits,
// and every call, against a real Studio on a random port.

const test = require('node:test');
const assert = require('node:assert/strict');
const crypto = require('node:crypto');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { open, now } = require('../lib/db');
const keystore = require('../lib/keystore');
const { Auth } = require('../lib/auth');
const { createApp } = require('../src/app');
const C = require('../lib/crypto');
const { DAY } = require('../lib/studio');
const { fp } = require('./helpers');

async function start() {
  const dataDir = fs.mkdtempSync(path.join(os.tmpdir(), 'studio-staff-'));
  const db0 = open(dataDir);
  keystore.createKey(db0, dataDir, now());
  const auth0 = new Auth(db0);
  auth0.createUser({ email: 'boss@example.com', name: 'Boss', role: 'admin', password: 'Correct-Horse-9' });
  auth0.createUser({ email: 'sam@example.com', name: 'Sam', role: 'sales', password: 'Correct-Horse-9' });
  db0.close();
  const app = createApp({ dataDir });
  await new Promise((r) => app.server.listen(0, '127.0.0.1', r));
  const base = `http://127.0.0.1:${app.server.address().port}`;
  const make = (name, role) => app.accounts.create({ name, role, createdBy: 'test' }).token;
  const tokens = { admin: make('Admin tool', 'admin'), sales: make('Main Studio', 'sales'), support: make('Help desk', 'support') };

  /** One staff-API call. `as` is a role name from `tokens`, or a literal token. */
  const call = async (method, p, { as = 'sales', body, user = 'Priya', key, headers = {} } = {}) => {
    const h = { ...headers };
    const token = tokens[as] || as;
    if (token) h.authorization = `Bearer ${token}`;
    if (user) h['x-acting-user'] = user;
    if (key) h['idempotency-key'] = key;
    if (body !== undefined) h['content-type'] = 'application/json';
    const res = await fetch(base + p, { method, headers: h, body: body === undefined ? undefined : (typeof body === 'string' ? body : JSON.stringify(body)) });
    return { status: res.status, body: await res.json(), headers: res.headers };
  };
  const api = (p) => `/api/staff/v1${p}`;
  const stop = () => new Promise((r) => app.server.close(r));
  return { app, base, dataDir, tokens, call, api, stop };
}

const NEW_LICENCE = { externalCustomerId: 'proj_green', customerName: 'Green Mart', country: 'IN', plan: 'business' };
let keyCounter = 0;
const nextKey = () => `test-key-${Date.now()}-${(keyCounter += 1)}`;
const create = (s, body = {}, opts = {}) => s.call('POST', s.api('/licences'), { body: { ...NEW_LICENCE, ...body }, key: nextKey(), ...opts });

test('sign-in: no token, a wrong token, a switched-off token and a token of the wrong shape are all 401 with a plain message', async () => {
  const s = await start();
  try {
    const url = s.api('/customers/proj_green/licences');
    const none = await s.call('GET', url, { as: '' });
    assert.equal(none.status, 401);
    assert.equal(none.body.error, 'unauthorized');
    assert.match(none.body.message, /token/);
    assert.deepEqual(Object.keys(none.body).sort(), ['error', 'message']);
    for (const bad of ['ngsa_' + 'A'.repeat(43), 'not-a-token', 'ngsa_', 'x'.repeat(500)]) assert.equal((await s.call('GET', url, { as: bad })).status, 401, bad.slice(0, 12));
    const basic = await fetch(s.base + url, { headers: { authorization: `Basic ${Buffer.from('a:b').toString('base64')}` } });
    assert.equal(basic.status, 401);

    const extra = s.app.accounts.create({ name: 'Temporary', role: 'sales' });
    assert.equal((await s.call('GET', url, { as: extra.token })).status, 200);
    s.app.accounts.revoke(extra.id);
    assert.equal((await s.call('GET', url, { as: extra.token })).status, 401, 'switched off: stops at once');
  } finally { await s.stop(); }
});

test('wrong tokens are slowed down for the address, but they never lock out a good token', async () => {
  const s = await start();
  try {
    const url = s.api('/customers/x/licences');
    let last;
    for (let i = 0; i < 12; i += 1) last = await s.call('GET', url, { as: 'ngsa_' + C.randomToken(32) });
    assert.equal(last.status, 429);
    assert.equal(last.body.error, 'rate_limited');
    assert.equal((await s.call('GET', url, { as: 'sales' })).status, 200, 'the real token still works');
  } finally { await s.stop(); }
});

test('a token is limited to 120 calls a minute', async () => {
  const s = await start();
  try {
    const url = s.api('/customers/x/licences');
    let last;
    for (let i = 0; i < 121; i += 1) last = await s.call('GET', url, { as: 'support' });
    assert.equal(last.status, 429);
    assert.equal(last.body.error, 'rate_limited');
    assert.equal((await s.call('GET', url, { as: 'sales' })).status, 200, 'another token has its own allowance');
  } finally { await s.stop(); }
});

test('only a hash of a token is kept: not in the table, not in the database file, and the list never shows it', async () => {
  const s = await start();
  try {
    const made = s.app.accounts.create({ name: 'Hash check', role: 'sales', createdBy: 'test' });
    assert.match(made.token, /^ngsa_[A-Za-z0-9_-]{43}$/);
    const row = s.app.db.prepare('SELECT * FROM service_accounts WHERE id = ?').get(made.id);
    assert.equal(row.token_hash, crypto.createHash('sha256').update(made.token).digest('hex'));
    assert.ok(!Object.values(row).some((v) => String(v).includes(made.token)));
    assert.ok(!JSON.stringify(s.app.accounts.list()).includes(made.token));
    assert.ok(!JSON.stringify(s.app.accounts.get(made.id)).includes(made.token));
    s.app.db.exec('PRAGMA wal_checkpoint(TRUNCATE)');
    for (const f of fs.readdirSync(s.dataDir).filter((n) => n.startsWith('studio.db'))) {
      assert.ok(!fs.readFileSync(path.join(s.dataDir, f)).includes(made.token), `${f} must not hold the token`);
    }
    // Every call is audited, and the audit never holds a token either.
    await s.call('GET', s.api('/customers/x/licences'), { as: made.token });
    const audit = s.app.db.prepare('SELECT * FROM audit').all().map((r) => JSON.stringify(r)).join('\n');
    assert.ok(!audit.includes(made.token));
    assert.ok(!audit.includes(s.tokens.sales));
  } finally { await s.stop(); }
});

test('roles: sales makes, lists, extends, converts and frees; support lists and frees; only an administrator switches a licence off and on', async () => {
  const s = await start();
  try {
    const made = await create(s, { trialDays: 14 }, { as: 'sales' });
    assert.equal(made.status, 201);
    const lid = made.body.lid;
    s.app.studio.activate({ key: made.body.key, fp: fp('pc-1'), host: 'PC-1' }, 'ip');
    const deviceId = s.app.studio.listActivations(lid)[0].id;
    const list = s.api('/customers/proj_green/licences');
    const L = (p) => s.api(`/licences/${lid}${p}`);

    const matrix = [
      // [name, call, who may, who may not]
      ['list', (as) => s.call('GET', list, { as }), ['admin', 'sales', 'support'], []],
      ['create', (as) => create(s, { externalCustomerId: `proj_${as}` }, { as }), ['admin', 'sales'], ['support']],
      ['extend', (as) => s.call('POST', L('/extend'), { as, body: { days: 3 } }), ['admin', 'sales'], ['support']],
      ['convert', (as) => s.call('POST', L('/convert'), { as, body: {} }), ['admin', 'sales'], ['support']],
      ['revoke', (as) => s.call('POST', L('/revoke'), { as, body: { reason: 'test' } }), ['admin'], ['sales', 'support']],
      ['restore', (as) => s.call('POST', L('/restore'), { as, body: {} }), ['admin'], ['sales', 'support']],
    ];
    // Refusals first (they must not change anything), then the allowed calls, in an order that makes each one valid.
    for (const [name, run, , denied] of matrix) {
      for (const who of denied) {
        const r = await run(who);
        assert.equal(r.status, 403, `${name} as ${who}`);
        assert.equal(r.body.error, 'forbidden');
        assert.match(r.body.message, /role/);
      }
    }
    assert.equal(s.app.studio.getLicence(lid).status, 'active');
    assert.equal(s.app.studio.getLicence(lid).trial, true, 'refused calls changed nothing');
    for (const who of ['admin', 'sales', 'support']) assert.equal((await matrix[0][1](who)).status, 200, `list as ${who}`);
    for (const who of ['admin', 'sales']) assert.equal((await matrix[1][1](who)).status, 201, `create as ${who}`);
    assert.equal((await matrix[2][1]('sales')).status, 200);
    assert.equal((await matrix[2][1]('admin')).status, 200);
    assert.equal((await matrix[3][1]('sales')).status, 200);
    assert.equal((await matrix[4][1]('admin')).status, 200);
    assert.equal((await matrix[5][1]('admin')).status, 200);
    assert.equal((await s.call('POST', L(`/devices/${deviceId}/free`), { as: 'support', body: { reason: 'broke' } })).status, 200);

    // A sales token keeps a salesperson's limits.
    const tooMany = await create(s, { externalCustomerId: 'proj_big', limits: { devices: 99 } }, { as: 'sales' });
    assert.equal(tooMany.status, 403);
    assert.match(tooMany.body.message, /allows up to 10 PCs/);
    const withModules = await create(s, { externalCustomerId: 'proj_mod', modules: ['pos', 'chain'] }, { as: 'sales' });
    assert.equal(withModules.status, 403);
    assert.equal((await create(s, { externalCustomerId: 'proj_mod2', modules: ['pos', 'chain'] }, { as: 'admin' })).status, 201);
    assert.equal((await create(s, { externalCustomerId: 'proj_none', bindMode: 'none' }, { as: 'sales' })).status, 403);
    assert.equal((await create(s, { externalCustomerId: 'proj_full', white: 'full' }, { as: 'sales' })).status, 403);
    assert.equal((await create(s, { externalCustomerId: 'proj_full2', white: { level: 'full' } }, { as: 'admin' })).status, 201);
  } finally { await s.stop(); }
});

test('the staff member\'s name is needed for every change, and every call is written to the History with it', async () => {
  const s = await start();
  try {
    const noName = await create(s, {}, { user: '' });
    assert.equal(noName.status, 400);
    assert.equal(noName.body.error, 'acting_user_required');
    assert.equal(s.app.db.prepare('SELECT COUNT(*) AS n FROM licences').get().n, 0);

    const made = await create(s, {}, { user: 'Priya N' });
    assert.equal(made.status, 201);
    assert.equal((await s.call('GET', s.api('/customers/proj_green/licences'), { user: '' })).status, 200, 'a look-up may come without a name');
    assert.equal((await s.call('GET', s.api('/customers/proj_green/licences'), { user: encodeURIComponent('Zoë Ñ') })).status, 200);
    assert.equal((await s.call('POST', s.api(`/licences/${made.body.lid}/revoke`), { as: 'sales', body: { reason: 'x' } })).status, 403);

    const rows = s.app.db.prepare("SELECT * FROM audit WHERE action LIKE 'staff.%' OR action = 'licence.create' ORDER BY id").all();
    const text = rows.map((r) => `${r.user_email} | ${r.action} | ${r.target} | ${r.detail}`).join('\n');
    assert.match(text, /Priya N via Main Studio \| staff\.create \| L-/);
    assert.match(text, /Priya N via Main Studio \| licence\.create/);
    assert.match(text, /\(no name given\) via Main Studio \| staff\.list/);
    assert.match(text, /Zoë Ñ via Main Studio \| staff\.list/);
    assert.match(text, /Priya via Main Studio \| staff\.revoke\.refused \| L-.* \| forbidden/, 'a refused call is written down too');
    assert.match(text, /staff\.create\.refused[^\n]*acting_user_required/);
    const audit = s.app.db.prepare("SELECT ip FROM audit WHERE action = 'staff.create'").get();
    assert.match(audit.ip, /127\.0\.0\.1/);
  } finally { await s.stop(); }
});

test('make a licence: the answer, the key that activates, the client found by its id, and the list shape', async () => {
  const s = await start();
  try {
    const made = await create(s, { onEnd: 'banner' });
    assert.equal(made.status, 201);
    assert.deepEqual(Object.keys(made.body).sort(), ['key', 'lid']);
    assert.match(made.body.lid, /^L-[0-9A-Z]{8}$/);
    assert.match(made.body.key, /^NGOS(-[0-9A-HJKMNP-TV-Z]{5}){4}$/);

    // The key really activates a PC, and the licence says what staff asked for.
    const res = await fetch(s.base + '/api/v1/activate', { method: 'POST', headers: { 'content-type': 'application/json' }, body: JSON.stringify({ key: made.body.key, version: '1.0', fp: fp('counter-1'), host: 'COUNTER-1' }) });
    assert.equal(res.status, 200);
    const claims = C.verifyToken((await res.json()).lic, s.app.studio.trustedKeys(), 'lic');
    assert.deepEqual([claims.cust.name, claims.cust.country, claims.edition, claims.exp, claims.trial, claims.onEnd], ['Green Mart', 'IN', 'business', null, false, 'banner']);
    assert.equal(claims.act.checkInDays, 30);
    assert.equal(claims.act.graceDays, 60);

    // A second licence for the same client lands on the same customer; a renamed client is renamed.
    const second = await create(s, { customerName: 'Green Mart Ltd', plan: 'starter' });
    assert.equal(second.status, 201);
    assert.equal(s.app.db.prepare('SELECT COUNT(*) AS n FROM customers').get().n, 1);
    assert.equal(s.app.db.prepare('SELECT name FROM customers').get().name, 'Green Mart Ltd');

    const list = await s.call('GET', s.api('/customers/proj_green/licences'));
    assert.equal(list.status, 200);
    assert.deepEqual(Object.keys(list.body), ['licences']);
    assert.equal(list.body.licences.length, 2);
    const one = list.body.licences.find((l) => l.lid === made.body.lid);
    assert.deepEqual(Object.keys(one), ['lid', 'keyMasked', 'plan', 'modules', 'limits', 'exp', 'onEnd', 'trial', 'trialDaysLeft', 'status', 'devices', 'moves']);
    assert.match(one.keyMasked, /^NGOS-\*{5}-\*{5}-\*{5}-[0-9A-HJKMNP-TV-Z]{5}$/);
    assert.ok(made.body.key.endsWith(one.keyMasked.slice(-5)));
    assert.ok(!JSON.stringify(list.body).includes(made.body.key), 'the full key is never in a list');
    assert.deepEqual([one.plan, one.exp, one.onEnd, one.trial, one.trialDaysLeft, one.status], ['business', null, 'banner', false, null, 'active']);
    assert.deepEqual(one.limits, { devices: 3, stores: 1, users: 10 });
    assert.deepEqual(one.modules, ['pos', 'hub', 'ai', 'dashboard', 'owner-live']);
    assert.deepEqual(one.moves, { used: 0, allowed: 2, windowDays: 365 });
    assert.equal(one.devices.length, 1);
    assert.deepEqual(Object.keys(one.devices[0]), ['id', 'label', 'activatedAt', 'lastCheckIn', 'version']);
    assert.equal(one.devices[0].label, 'COUNTER-1');
    assert.equal(one.devices[0].version, '1.0');
    assert.ok(Number.isInteger(one.devices[0].activatedAt) && Number.isInteger(one.devices[0].lastCheckIn));

    // A client with no licence is an empty list, not an error.
    const none = await s.call('GET', s.api('/customers/proj_unknown/licences'));
    assert.deepEqual([none.status, none.body], [200, { licences: [] }]);
    assert.equal((await s.call('GET', s.api('/customers/' + encodeURIComponent('bad id!') + '/licences'))).status, 400);
  } finally { await s.stop(); }
});

test('make a licence: what staff can ask for, and what is refused in plain words', async () => {
  const s = await start();
  try {
    const sizes = await create(s, { externalCustomerId: 'a1', limits: { devices: 5, users: 20 } });
    assert.deepEqual(s.app.studio.getLicence(sizes.body.lid).limits, { devices: 5, stores: 1, users: 20 }, 'what is missing comes from the plan');

    const dated = await create(s, { externalCustomerId: 'a2', exp: '2099-12-31' });
    assert.equal(s.app.studio.getLicence(dated.body.lid).exp, Math.floor(Date.parse('2099-12-31T23:59:59Z') / 1000));
    assert.equal(s.app.studio.getLicence(dated.body.lid).on_end, 'banner', 'a paid licence with an end date still defaults to banner');
    const stops = await create(s, { externalCustomerId: 'a3', exp: now() + 400 * DAY, onEnd: 'stop' });
    assert.equal(s.app.studio.getLicence(stops.body.lid).on_end, 'stop');
    const openEnded = await create(s, { externalCustomerId: 'a4', exp: null });
    assert.equal(s.app.studio.getLicence(openEnded.body.lid).exp, null);

    const site = await create(s, { externalCustomerId: 'a5', plan: 'growth', bindMode: 'domain', domains: ['shop.example.com'] });
    assert.deepEqual(s.app.studio.getLicence(site.body.lid).bind, { mode: 'domain', domains: ['shop.example.com'] });
    const white = await create(s, { externalCustomerId: 'a6', white: { level: 'none' } });
    assert.equal(s.app.studio.getLicence(white.body.lid).white_level, 'none');
    const brandId = s.app.studio.saveBrand(null, { name: 'RetailPro', primaryColor: '#112233' }, { id: 1, email: 'x', role: 'admin' }, 'ip');
    const branded = await create(s, { externalCustomerId: 'a7', brandId });
    assert.equal(s.app.studio.getLicence(branded.body.lid).brand_id, brandId);

    const trial = await create(s, { externalCustomerId: 'a8', trialDays: 21 });
    const t = s.app.studio.getLicence(trial.body.lid);
    assert.deepEqual([t.trial, t.on_end, t.exp - t.nbf], [true, 'stop', 21 * DAY]);

    const refused = [
      [{ externalCustomerId: undefined }, /externalCustomerId/],
      [{ customerName: '' }, /customerName/],
      [{ plan: undefined }, /plan/],
      [{ plan: 'nonsense' }, /no plan "nonsense"/],
      [{ externalCustomerId: 'bad id' }, /customer id/],
      [{ trialDays: 5, exp: null }, /either trialDays or exp/],
      [{ trialDays: 5, exp: now() + DAY }, /either trialDays or exp/],
      [{ trialDays: 0 }, /1 to 365/],
      [{ trialDays: 'ten' }, /1 to 365/],
      [{ trialDays: 14, onEnd: 'banner' }, /always stops/],
      [{ onEnd: 'later' }, /keeps working/],
      [{ onEnd: 5 }, /onEnd/],
      [{ exp: 'next year' }, /end date/],
      [{ exp: now() - DAY }, /after the start/],
      [{ limits: { devices: -1 } }, /limits\.devices/],
      [{ limits: [1] }, /limits/],
      [{ brandId: 9999 }, /brand/],
      [{ brandId: 'x' }, /brandId/],
      [{ white: 'purple' }, /white/],
      [{ bindMode: 'sideways' }, /bindMode/],
      [{ bindMode: 'domain' }, /website address/],
      [{ country: 5 }, /country/],
      [{ modules: 'pos' }, /modules/],
    ];
    for (const [change, message] of refused) {
      const body = { ...NEW_LICENCE, externalCustomerId: 'refused', ...change };
      for (const k of Object.keys(body)) if (body[k] === undefined) delete body[k];
      const r = await s.call('POST', s.api('/licences'), { body, key: nextKey() });
      assert.equal(r.status === 400 || r.status === 403, true, JSON.stringify(change) + ' -> ' + r.status);
      assert.match(r.body.message, message, JSON.stringify(change));
      assert.deepEqual(Object.keys(r.body).sort(), ['error', 'message']);
    }
    assert.equal(s.app.db.prepare("SELECT COUNT(*) AS n FROM customers WHERE external_id = 'refused'").get().n, 0, 'a refused call leaves nothing behind, not even the customer');
  } finally { await s.stop(); }
});

test('a repeated call with the same Idempotency-Key returns the same licence and never makes a second one', async () => {
  const s = await start();
  try {
    const none = await s.call('POST', s.api('/licences'), { body: NEW_LICENCE });
    assert.equal(none.status, 400);
    assert.equal(none.body.error, 'idempotency_key_required');
    const odd = await s.call('POST', s.api('/licences'), { body: NEW_LICENCE, key: 'short' });
    assert.equal(odd.status, 400);

    const first = await s.call('POST', s.api('/licences'), { body: NEW_LICENCE, key: 'order-0001' });
    const again = await s.call('POST', s.api('/licences'), { body: NEW_LICENCE, key: 'order-0001' });
    assert.deepEqual([first.status, again.status], [201, 200]);
    assert.deepEqual(again.body, first.body);
    // The same content in another order of keys is the same call.
    const reordered = await s.call('POST', s.api('/licences'), { body: { plan: 'business', country: 'IN', customerName: 'Green Mart', externalCustomerId: 'proj_green' }, key: 'order-0001' });
    assert.deepEqual(reordered.body, first.body);
    // At the same time, many times: still one.
    const burst = await Promise.all(Array.from({ length: 8 }, () => s.call('POST', s.api('/licences'), { body: NEW_LICENCE, key: 'order-0001' })));
    for (const r of burst) assert.deepEqual(r.body, first.body);
    assert.equal(s.app.db.prepare('SELECT COUNT(*) AS n FROM licences').get().n, 1);

    // The same key for a different licence is refused, and nothing is made.
    const clash = await s.call('POST', s.api('/licences'), { body: { ...NEW_LICENCE, plan: 'starter' }, key: 'order-0001' });
    assert.equal(clash.status, 422);
    assert.equal(clash.body.error, 'idempotency_conflict');
    assert.equal(s.app.db.prepare('SELECT COUNT(*) AS n FROM licences').get().n, 1);

    // Another key is another licence; the same key from another token is its own too.
    const second = await s.call('POST', s.api('/licences'), { body: NEW_LICENCE, key: 'order-0002' });
    assert.notEqual(second.body.lid, first.body.lid);
    const other = await s.call('POST', s.api('/licences'), { body: NEW_LICENCE, key: 'order-0001', as: 'admin' });
    assert.equal(other.status, 201);
    assert.notEqual(other.body.lid, first.body.lid);
    assert.equal(s.app.db.prepare('SELECT COUNT(*) AS n FROM licences').get().n, 3);

    // A call that was refused did not use up its key: it can be sent again, corrected.
    const bad = await s.call('POST', s.api('/licences'), { body: { ...NEW_LICENCE, plan: 'nonsense' }, key: 'order-0003' });
    assert.equal(bad.status, 400);
    const fixed = await s.call('POST', s.api('/licences'), { body: NEW_LICENCE, key: 'order-0003' });
    assert.equal(fixed.status, 201);
    // The answer to a repeated call still has the key, even after the licence was switched off.
    await s.call('POST', s.api(`/licences/${first.body.lid}/revoke`), { as: 'admin', body: { reason: 'x' } });
    assert.deepEqual((await s.call('POST', s.api('/licences'), { body: NEW_LICENCE, key: 'order-0001' })).body, first.body);
  } finally { await s.stop(); }
});

test('a trial: 14 days, shown as a trial with the days left, extended, then turned into a paid licence', async () => {
  const s = await start();
  try {
    const made = await create(s, { trialDays: 14 });
    const lid = made.body.lid;
    const view = async () => (await s.call('GET', s.api('/customers/proj_green/licences'))).body.licences.find((l) => l.lid === lid);
    let v = await view();
    assert.deepEqual([v.trial, v.trialDaysLeft, v.onEnd, v.status], [true, 14, 'stop', 'active']);
    assert.ok(Math.abs(v.exp - (now() + 14 * DAY)) < 5);

    const extended = await s.call('POST', s.api(`/licences/${lid}/extend`), { body: { days: 7 } });
    assert.equal(extended.status, 200);
    assert.equal(extended.body.ok, true);
    assert.equal(extended.body.licence.trialDaysLeft, 21);
    assert.equal(extended.body.licence.exp, v.exp + 7 * DAY);

    const rev = s.app.studio.getLicence(lid).rev;
    const converted = await s.call('POST', s.api(`/licences/${lid}/convert`), { body: {} });
    assert.equal(converted.status, 200);
    assert.deepEqual([converted.body.licence.trial, converted.body.licence.trialDaysLeft, converted.body.licence.exp, converted.body.licence.onEnd, converted.body.licence.status], [false, null, null, 'banner', 'active']);
    assert.equal(s.app.studio.getLicence(lid).rev, rev + 1);
    const noBody = await s.call('POST', s.api(`/licences/${lid}/convert`), { body: undefined });
    assert.equal(noBody.status, 409, 'no longer a trial; a call with no body is read the same');
    assert.equal(noBody.body.error, 'conflict');

    const noEnd = await s.call('POST', s.api(`/licences/${lid}/extend`), { body: { days: 3 } });
    assert.equal(noEnd.status, 409);
    assert.match(noEnd.body.message, /no end date/);
    for (const days of [0, -1, 'x', 3651, 1.5, undefined]) {
      const trial = (await create(s, { externalCustomerId: 'proj_t2', trialDays: 5 })).body.lid;
      assert.equal((await s.call('POST', s.api(`/licences/${trial}/extend`), { body: { days } })).status, 400, String(days));
    }
    assert.equal((await s.call('POST', s.api('/licences/L-NOPE0000/extend'), { body: { days: 3 } })).status, 404);
    assert.equal((await s.call('POST', s.api('/licences/L-NOPE0000/convert'), { body: {} })).status, 404);
  } finally { await s.stop(); }
});

test('the status words: active, ended (still works), stopped, not started, revoked, withdrawn', async () => {
  const s = await start();
  try {
    const paid = (await create(s, { externalCustomerId: 'proj_s', exp: now() + 100 * DAY, onEnd: 'banner' })).body.lid;
    const strict = (await create(s, { externalCustomerId: 'proj_s', exp: now() + 100 * DAY, onEnd: 'stop' })).body.lid;
    const trial = (await create(s, { externalCustomerId: 'proj_s', trialDays: 10 })).body.lid;
    const later = (await create(s, { externalCustomerId: 'proj_s' })).body.lid;
    s.app.db.prepare('UPDATE licences SET nbf = ? WHERE lid = ?').run(now() + 30 * DAY, later);
    const switched = (await create(s, { externalCustomerId: 'proj_s' })).body.lid;
    await s.call('POST', s.api(`/licences/${switched}/revoke`), { as: 'admin', body: { reason: 'unpaid' } });
    const withdrawn = (await create(s, { externalCustomerId: 'proj_s' })).body.lid;
    s.app.studio.setStatus(withdrawn, 'revoked', 'fraud', { id: 1, email: 'x', role: 'admin' }, 'ip');

    const real = s.app.studio.clock;
    s.app.studio.clock = () => real() + 400 * DAY;
    try {
      const all = (await s.call('GET', s.api('/customers/proj_s/licences'))).body.licences;
      const st = (lid) => all.find((l) => l.lid === lid).status;
      assert.deepEqual([st(paid), st(strict), st(trial), st(later), st(switched), st(withdrawn)], ['ended', 'stopped', 'stopped', 'active', 'revoked', 'withdrawn']);
      assert.equal(all.find((l) => l.lid === trial).trialDaysLeft, 0);
    } finally { s.app.studio.clock = real; }
    const now1 = (await s.call('GET', s.api('/customers/proj_s/licences'))).body.licences;
    assert.equal(now1.find((l) => l.lid === later).status, 'not_started');
    assert.equal(now1.find((l) => l.lid === paid).status, 'active');
  } finally { await s.stop(); }
});

test('free a PC: needs a reason, checks the licence, is not limited, and is not a move by the customer', async () => {
  const s = await start();
  try {
    const lid = (await create(s, { limits: { devices: 1 } })).body.lid;
    const key = s.app.studio.getLicence(lid).licence_key;
    const seat = (name) => { s.app.studio.activate({ key, fp: fp(name), host: name.toUpperCase() }, 'ip'); return s.app.studio.listActivations(lid).find((a) => a.active).id; };
    const free = (id, body, as = 'sales', licence = lid) => s.call('POST', s.api(`/licences/${licence}/devices/${id}/free`), { as, body });

    let id = seat('a');
    assert.equal((await free(id, {})).status, 400);
    assert.equal((await free(id, { reason: '   ' })).status, 400);
    assert.equal(s.app.studio.getActivation(id).active, 1);
    const other = (await create(s, { externalCustomerId: 'proj_other' })).body.lid;
    assert.equal((await free(id, { reason: 'x' }, 'sales', other)).status, 404, 'a PC of another licence');
    assert.equal((await free(99999, { reason: 'x' })).status, 404);
    assert.equal((await free('abc', { reason: 'x' })).status, 404);

    for (let i = 0; i < 4; i += 1) {
      id = i === 0 ? id : seat(`pc-${i}`);
      const r = await free(id, { reason: `old PC ${i}` }, i % 2 ? 'support' : 'sales');
      assert.equal(r.status, 200);
      assert.equal(r.body.ok, true);
      assert.equal(r.body.licence.lid, lid);
      assert.equal(r.body.licence.devices.length, 0);
      assert.deepEqual(r.body.licence.moves, { used: 0, allowed: 2, windowDays: 365 });
    }
    assert.equal((await free(id, { reason: 'again' })).status, 200, 'freeing a free PC is not an error');
    const history = s.app.studio.history(lid).filter((e) => e.kind === 'staff_free');
    assert.equal(history.length, 4);
    assert.match(history[0].actor, /Priya via /);
    assert.equal(history[0].reason, 'old PC 3');

    // The customer's own moves are counted separately, and shown in the list.
    const a = s.app.studio.activate({ key, fp: fp('mine'), host: 'MINE' }, 'ip');
    s.app.studio.deactivate({ lid, act: a.act, fp: fp('mine') }, 'ip');
    const v = (await s.call('GET', s.api('/customers/proj_green/licences'))).body.licences.find((l) => l.lid === lid);
    assert.deepEqual(v.moves, { used: 1, allowed: 2, windowDays: 365 });
  } finally { await s.stop(); }
});

test('switch a licence off and on: the PCs are told at their next check-in; a licence withdrawn for good cannot come back', async () => {
  const s = await start();
  try {
    const made = (await create(s)).body;
    const f = fp('pc');
    const first = s.app.studio.activate({ key: made.key, fp: f, host: 'PC' }, 'ip');
    const off = await s.call('POST', s.api(`/licences/${made.lid}/revoke`), { as: 'admin', body: { reason: 'Payment overdue' } });
    assert.equal(off.status, 200);
    assert.equal(off.body.licence.status, 'revoked');
    assert.equal(s.app.studio.getLicence(made.lid).status_reason, 'Payment overdue');
    const refused = await fetch(s.base + '/api/v1/checkin', { method: 'POST', headers: { 'content-type': 'application/json' }, body: JSON.stringify({ lid: made.lid, act: first.act, fp: f }) });
    assert.equal((await refused.json()).error.code, 'suspended');
    assert.deepEqual(C.verifyToken(s.app.studio.crlToken(), s.app.studio.trustedKeys(), 'crl').revoked, [made.lid]);

    assert.equal((await s.call('POST', s.api(`/licences/${made.lid}/revoke`), { as: 'admin', body: {} })).status, 400, 'a reason is needed');
    const on = await s.call('POST', s.api(`/licences/${made.lid}/restore`), { as: 'admin', body: {} });
    assert.equal(on.status, 200);
    assert.equal(on.body.licence.status, 'active');
    assert.equal((await s.call('POST', s.api(`/licences/${made.lid}/restore`), { as: 'admin', body: {} })).status, 200, 'restoring a working licence changes nothing');
    const ok = await fetch(s.base + '/api/v1/checkin', { method: 'POST', headers: { 'content-type': 'application/json' }, body: JSON.stringify({ lid: made.lid, act: first.act, fp: f }) });
    assert.equal(ok.status, 200);

    s.app.studio.setStatus(made.lid, 'revoked', 'fraud', { id: 1, email: 'x', role: 'admin' }, 'ip'); // withdrawn for good on the Studio's own pages
    const back = await s.call('POST', s.api(`/licences/${made.lid}/restore`), { as: 'admin', body: {} });
    assert.equal(back.status, 409);
    assert.equal(back.body.error, 'conflict');
    assert.equal((await s.call('POST', s.api(`/licences/${made.lid}/revoke`), { as: 'admin', body: { reason: 'x' } })).status, 409);
    assert.equal((await s.call('POST', s.api(`/licences/${made.lid}/extend`), { as: 'admin', body: { days: 3 } })).status, 409);
    assert.equal((await s.call('POST', s.api('/licences/L-NOPE0000/revoke'), { as: 'admin', body: { reason: 'x' } })).status, 404);
  } finally { await s.stop(); }
});

test('bad requests: unknown calls, wrong methods, bad JSON and big bodies are answered in the same {error, message} form', async () => {
  const s = await start();
  try {
    const shape = (r) => assert.deepEqual(Object.keys(r.body).sort(), ['error', 'message']);
    const unknown = await s.call('GET', s.api('/nothing'));
    assert.deepEqual([unknown.status, unknown.body.error], [404, 'not_found']);
    shape(unknown);
    const wrong = await s.call('DELETE', s.api('/licences'));
    assert.equal(wrong.status, 404);
    shape(wrong);
    const get = await s.call('GET', s.api('/licences'));
    assert.equal(get.status, 404);
    const junk = await s.call('POST', s.api('/licences'), { body: '{not json', key: nextKey() });
    assert.deepEqual([junk.status, junk.body.error], [400, 'bad_request']);
    shape(junk);
    const array = await s.call('POST', s.api('/licences'), { body: '[1]', key: nextKey() });
    assert.equal(array.status, 400);
    const big = await s.call('POST', s.api('/licences'), { body: JSON.stringify({ ...NEW_LICENCE, notes: 'x'.repeat(66 * 1024) }), key: nextKey() });
    assert.deepEqual([big.status, big.body.error], [413, 'too_large']);
    const encoded = await s.call('GET', s.api('/customers/%E0%A4%A/licences'));
    assert.equal(encoded.status, 400);
    shape(encoded);
    assert.equal(unknown.headers.get('cache-control'), 'no-store');
    assert.match(unknown.headers.get('content-type'), /application\/json/);
  } finally { await s.stop(); }
});

test('the customer\'s own "free this PC" over the programs\' API: the third in a year is 409 move_limit_reached, and staff can still free it', async () => {
  const s = await start();
  try {
    const made = (await create(s, { limits: { devices: 1 } })).body;
    const post = async (p, body) => { const r = await fetch(s.base + p, { method: 'POST', headers: { 'content-type': 'application/json' }, body: JSON.stringify(body) }); return { status: r.status, body: await r.json() }; };
    for (let i = 0; i < 2; i += 1) {
      const a = await post('/api/v1/activate', { key: made.key, fp: fp(`own-${i}`), host: `OWN-${i}` });
      assert.equal(a.status, 200);
      assert.deepEqual((await post('/api/v1/deactivate', { lid: made.lid, act: a.body.act, fp: fp(`own-${i}`) })).body, { ok: true });
    }
    const third = await post('/api/v1/activate', { key: made.key, fp: fp('own-2'), host: 'OWN-2' });
    const refused = await post('/api/v1/deactivate', { lid: made.lid, act: third.body.act, fp: fp('own-2') });
    assert.equal(refused.status, 409);
    assert.equal(refused.body.error.code, 'move_limit_reached');
    assert.match(refused.body.error.message, /contact your supplier/);
    assert.equal((await post('/api/v1/checkin', { lid: made.lid, act: third.body.act, fp: fp('own-2') })).status, 200, 'the PC still works');

    const seat = s.app.studio.listActivations(made.lid).find((x) => x.active).id;
    const staff = await s.call('POST', s.api(`/licences/${made.lid}/devices/${seat}/free`), { body: { reason: 'the customer called' } });
    assert.equal(staff.status, 200);
    assert.deepEqual(staff.body.licence.moves, { used: 2, allowed: 2, windowDays: 365 });
    assert.equal((await post('/api/v1/activate', { key: made.key, fp: fp('own-3'), host: 'OWN-3' })).status, 200, 'room for the new PC');
  } finally { await s.stop(); }
});
