// The licence service through the Studio: connecting it (who may), what a customer's Licences section shows and who may do what, asking for a customer's licence when their website
// and app are made (once, whatever is pressed twice), and every way the Licence Studio can fail. The Licence Studio is a stand-in on this PC that speaks the same "contract v1" as the
// real one (tests/stand-in-licence-studio.mjs); the real one was NOT used (docs/SETUP-STUDIO.md says so).
import { test } from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, rmSync, readFileSync, readdirSync, statSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { startStudio } from '../lib/server.mjs';
import { checkIntake } from '../lib/intake.mjs';
import { checkAddress, actingName, termsOf, termsWords, requestBody, idempotencyKey, isoOf, normaliseLicence, describeLicence, LicenceError } from '../lib/licences.mjs';
import { standInGitHub, readZipFiles } from './stand-in-github.mjs';
import { standInLicenceStudio } from './stand-in-licence-studio.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const PNG = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==';
const good = (over = {}) => ({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example' } }, device: { kind: 'touch-pos', os: 'windows', screen: 'standard' }, look: { primaryColor: '#0a7d4b', style: 'friendly' }, licence: { whiteLabel: 'theme', seats: 3, plan: 'business' }, ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' }, android: { wanted: true, appId: 'com.luzonfresh.shop' } }, ...over });
const until = async (condition, what = 'it did not happen in time') => { for (let i = 0; i < 400 && !(await condition()); i += 1) await new Promise((done) => setTimeout(done, 25)); assert.ok(await condition(), what); };

/** A Studio on this PC with a stand-in Licence Studio and a stand-in build service, and the people who use it. */
async function boot({ stand = {}, licenceOptions = {} } = {}) {
  const root = mkdtempSync(join(tmpdir(), 'studio-licences-'));
  process.env.SETUP_STUDIO_HOME = join(root, 'home');
  const gh = await standInGitHub({});
  const ls = await standInLicenceStudio({});
  Object.assign(ls.options, stand);
  const studio = await startStudio({ folder: join(root, 'ws'), env: process.env, build: { api: gh.url, pollMs: 15, ceilingMs: 10_000, requestTimeoutMs: 1500, downloadTimeoutMs: 5000, lostContactLimit: 3 }, licence: { requestTimeoutMs: 1500, ...licenceOptions } });
  const base = studio.url.split('?')[0].replace(/\/$/, '');
  const said = [];   // every answer the Studio gave, to look for a secret in
  const call = async (method, path, { body, session, name } = {}) => {
    const res = await fetch(base + path, { method, headers: { 'content-type': 'application/json', 'x-studio-key': studio.token, ...(session ? { 'x-studio-session': session } : {}) }, body: body === undefined ? undefined : JSON.stringify(body) });
    const type = res.headers.get('content-type') ?? '';
    const out = { status: res.status, json: type.includes('json') ? await res.json() : null, buffer: type.includes('json') ? null : Buffer.from(await res.arrayBuffer()) };
    said.push({ path, text: JSON.stringify(out.json) ?? '' });
    void name;
    return out;
  };
  return { root, gh, ls, studio, call, said, folder: join(root, 'ws'), done: async () => { await studio.close(); await gh.close(); await ls.close(); rmSync(root, { recursive: true, force: true }); } };
}
async function people(s) {
  const admin = (await s.call('POST', '/api/setup', { body: { name: 'Asha Admin', password: 'a-long-password' } })).json.session;
  const sales = (await s.call('POST', '/api/team', { session: admin, body: { name: 'Sam Sales', role: 'sales', password: 'sam-long-password' } })).json.member;
  const reviewer = (await s.call('POST', '/api/team', { session: admin, body: { name: 'Rita Reviewer', role: 'reviewer', password: 'rita-long-password' } })).json.member;
  const sam = (await s.call('POST', '/api/signin', { body: { id: sales.id, password: 'sam-long-password' } })).json.session;
  const rita = (await s.call('POST', '/api/signin', { body: { id: reviewer.id, password: 'rita-long-password' } })).json.session;
  return { admin, sam, rita };
}
async function connectBuild(s, admin) {
  assert.equal((await s.call('PUT', '/api/build-service', { session: admin, body: { sourceRepo: s.gh.source, resultsRepo: s.gh.results, ref: '' } })).status, 200);
  assert.equal((await s.call('PUT', '/api/build-service/codes/start', { session: admin, body: { code: s.gh.tokens.start } })).status, 200);
  assert.equal((await s.call('PUT', '/api/build-service/codes/results', { session: admin, body: { code: s.gh.tokens.results } })).status, 200);
}
async function connectLicence(s, admin) {
  const a = await s.call('PUT', '/api/licence-service', { session: admin, body: { url: s.ls.url } });
  assert.equal(a.status, 200, JSON.stringify(a.json));
  const b = await s.call('PUT', '/api/licence-service/code', { session: admin, body: { code: s.ls.token } });
  assert.equal(b.status, 200, JSON.stringify(b.json));
  assert.equal(b.json.connection.ready, true);
}
async function approvedCustomer(s, { sam, rita }, intake = good()) {
  const id = (await s.call('POST', '/api/customers', { session: sam, body: { intake } })).json.customer.id;
  await s.call('PUT', `/api/customers/${id}/logo`, { session: sam, body: { data: PNG } });
  await s.call('POST', `/api/customers/${id}/proposal`, { session: sam });
  await s.call('POST', `/api/customers/${id}/submit`, { session: sam });
  assert.equal((await s.call('POST', `/api/customers/${id}/approve`, { session: rita })).json.customer.state, 'approved');
  return id;
}
const press = (s, session, id, body = {}) => s.call('POST', `/api/customers/${id}/website-app/build`, { session, body });
const finished = (s, session, id) => until(async () => ['done', 'partly', 'failed'].includes((await s.call('GET', `/api/customers/${id}/website-app`, { session })).json.current?.state));
const lic = (s, session, id) => s.call('GET', `/api/customers/${id}/licences`, { session });
const posts = (s) => s.ls.seen.filter((r) => r.method === 'POST' && r.path === '/api/staff/v1/licences');

/** Every file under a folder, as text where it is text. */
function everyFile(dir) {
  const out = [];
  for (const name of readdirSync(dir)) {
    const p = join(dir, name);
    if (statSync(p).isDirectory()) out.push(...everyFile(p)); else out.push({ path: p, bytes: readFileSync(p) });
  }
  return out;
}

// ---- small pieces ---------------------------------------------------------------------------------------------------------------------------------------------------

test('the address of the Licence Studio: https only (http only on this same PC), no name or password, nothing after the name', () => {
  assert.equal(checkAddress(''), '');
  assert.equal(checkAddress('  https://licence.example.com/ '), 'https://licence.example.com');
  assert.equal(checkAddress('https://licence.example.com:8443/studio/'), 'https://licence.example.com:8443/studio');
  assert.equal(checkAddress('http://127.0.0.1:5400'), 'http://127.0.0.1:5400');
  assert.equal(checkAddress('http://localhost:5400/'), 'http://localhost:5400');
  for (const bad of ['licence.example.com', 'http://licence.example.com', 'http://192.168.1.20:5400', 'ftp://licence.example.com', 'https://user:secret-value@licence.example.com', 'https://licence.example.com/?code=abc', 'https://licence.example.com/#x', 'https://licence.example.com/a%20b', 'https://licence.example.com/a;b', 'https://licence.example.com/' + 'a'.repeat(300)]) {
    assert.throws(() => checkAddress(bad), (e) => e instanceof LicenceError && e.status === 400 && /^The address of the Licence Studio /.test(e.message) && /https:\/\/licence\.yourcompany\.example/.test(e.message), bad);
  }
});

test('the staff member\'s name travels as it is when it is plain text, and written with %-escapes otherwise', () => {
  assert.equal(actingName({ name: 'Rita Reviewer' }), 'Rita Reviewer');
  assert.equal(actingName({ name: 'Zoë Ünal' }), 'Zo%C3%AB%20%C3%9Cnal');
  assert.equal(actingName({ name: '100% Sam' }), '100%25%20Sam');
  assert.equal(actingName({ name: 'Line\nBreak' }), 'Line Break');
  assert.equal(actingName(null), 'unknown');
  for (const n of ['Rita Reviewer', 'Zoë Ünal', '日本語の名前', '100% Sam']) assert.match(actingName({ name: n }), /^[\x20-\x7e]+$/, 'it can be put in a header');
});

test('what the approved setup says the licence is: paid by default, a trial stops, a paid licence shows a banner; an old setup has no plan', () => {
  const paid = termsOf({ licence: { whiteLabel: 'theme', seats: 3, plan: 'business' } });
  assert.deepEqual(paid, { plan: 'business', trial: false, trialDays: null, devices: 3, onEnd: 'banner', onEndChosen: false, brandId: '', whiteLabel: 'theme' });
  const trial = termsOf({ licence: { seats: 1, plan: 'starter', trial: true } });
  assert.deepEqual([trial.trial, trial.trialDays, trial.onEnd, trial.onEndChosen], [true, 14, 'stop', false]);
  assert.equal(termsOf({ licence: { trial: true, trialDays: 30, plan: 'starter' } }).trialDays, 30);
  assert.equal(termsOf({ licence: { trial: true, trialDays: 500, plan: 'starter' } }).trialDays, 14, 'a number that is not allowed is not used');
  assert.deepEqual([termsOf({ licence: { onEnd: 'stop', plan: 'x' } }).onEnd, termsOf({ licence: { trial: true, onEnd: 'banner', plan: 'x' } }).onEnd], ['stop', 'banner'], 'a choice is kept');
  const old = termsOf({ licence: { whiteLabel: 'none', seats: 1 } });
  assert.deepEqual([old.plan, old.devices, old.trial, old.onEnd], ['', 1, false, 'banner'], 'a setup approved before these choices existed has no plan');
  assert.equal(termsOf(undefined).devices, 1);
  assert.match(termsWords(paid), /plan "business", 3 PCs, paid, with no end date; when it ends, the shop keeps working and shows a banner/);
  assert.match(termsWords(trial), /a trial of 14 days; when it ends, the till stops selling/);
});

test('the request for a licence: from the approved setup only, a paid licence has no end date, a trial has its days, and the key that makes it safe to repeat is the same each time', () => {
  const intake = { business: { name: 'Luzon Fresh Mart', country: 'ph' }, licence: { whiteLabel: 'theme', seats: 3, plan: 'business', brandId: '12' } };
  assert.deepEqual(requestBody('luzon-fresh-mart', intake), { externalCustomerId: 'luzon-fresh-mart', customerName: 'Luzon Fresh Mart', country: 'PH', plan: 'business', limits: { devices: 3 }, onEnd: 'banner', exp: null, brandId: 12, white: { level: 'theme' } });
  const trial = requestBody('luzon-fresh-mart', { business: { name: 'Luzon Fresh Mart', country: 'PH' }, licence: { plan: 'starter', trial: true, trialDays: 21, brandId: 'north-brand' } });
  assert.deepEqual([trial.trialDays, 'exp' in trial, trial.onEnd, trial.brandId, trial.limits], [21, false, 'stop', 'north-brand', { devices: 1 }]);
  assert.equal(idempotencyKey('luzon-fresh-mart', 1), 'ngos-studio-luzon-fresh-mart-release-1');
  assert.notEqual(idempotencyKey('luzon-fresh-mart', 2), idempotencyKey('luzon-fresh-mart', 1));
  assert.notEqual(idempotencyKey('other-shop', 1), idempotencyKey('luzon-fresh-mart', 1));
  assert.match(idempotencyKey('a'.repeat(41), 9999), /^[A-Za-z0-9._-]{1,100}$/);
});

test('the choices in the details: a plan written wrongly, a trial of a strange length and a brand written wrongly are named where they were typed', () => {
  const ok = checkIntake(good({ licence: { whiteLabel: 'theme', seats: 2, plan: ' Business ', trial: true, trialDays: 30, onEnd: 'stop', brandId: '7' } }));
  assert.equal(ok.complete, true, JSON.stringify(ok.errors));
  assert.deepEqual(ok.value.licence, { whiteLabel: 'theme', seats: 2, plan: 'business', trial: true, trialDays: 30, onEnd: 'stop', brandId: '7' });
  const empty = checkIntake(good({ licence: { whiteLabel: 'none' } }));
  assert.equal(empty.complete, true);
  assert.deepEqual([empty.value.licence.plan, empty.value.licence.trial, empty.value.licence.trialDays, empty.value.licence.onEnd], ['', false, 14, 'auto']);
  const bad = checkIntake(good({ licence: { plan: 'Big Plan!', trialDays: 400, brandId: 'a b' } }));
  assert.deepEqual(bad.errors.filter((e) => e.field.startsWith('licence.')).map((e) => e.field).sort(), ['licence.brandId', 'licence.plan', 'licence.trialDays']);
  assert.equal(checkIntake(good({ licence: { trialDays: 14.5 } })).errors.some((e) => e.field === 'licence.trialDays'), true);
  assert.equal(checkIntake(good({ licence: { onEnd: 'explode' } })).value.licence.onEnd, 'auto');
});

test('dates the Licence Studio writes in two ways are both read; a licence it cannot make sense of is left out; what it says is cleaned', () => {
  assert.equal(isoOf(1_790_000_000), '2026-09-21T14:13:20.000Z');
  assert.equal(isoOf(1_790_000_000_000), '2026-09-21T14:13:20.000Z');
  assert.equal(isoOf('2026-10-05T08:30:00Z'), '2026-10-05T08:30:00.000Z');
  for (const nothing of [null, undefined, 0, -5, 'soon', '', {}, NaN]) assert.equal(isoOf(nothing), null);
  assert.equal(normaliseLicence(null), null);
  assert.equal(normaliseLicence({ lid: 'no way', plan: 'x' }), null);
  assert.equal(normaliseLicence({ lid: '../../etc' }), null);
  const l = normaliseLicence({ lid: 'L-ABC12345', keyMasked: 'NGOS-•••••-AB12', plan: '<b>business</b>', modules: ['pos', 'hub', '<x>', 'a b'], limits: { devices: 3, stores: 'many' }, exp: null, onEnd: 'stop', trial: true, trialDaysLeft: 9.7, status: 'Active',
    devices: [{ id: 'pc-1', label: 'Counter <1>', activatedAt: 1_790_000_000, lastCheckIn: '2026-10-05T08:30:00Z', version: '1.4.0' }, { id: '../bad', label: 'x' }, 'junk'], moves: { used: 1 } });
  assert.deepEqual([l.plan, l.modules, l.limits, l.onEnd, l.trial, l.trialDaysLeft, l.status, l.moves], ['b business /b', ['pos', 'hub'], { devices: 3, stores: 0, users: 0 }, 'stop', true, 9, 'active', { used: 1, allowed: 2, windowDays: 365 }]);
  assert.deepEqual(l.devices.map((d) => [d.id, d.label, d.activatedAt, d.lastCheckIn]), [['pc-1', 'Counter 1', '2026-09-21T14:13:20.000Z', '2026-10-05T08:30:00.000Z']]);
  assert.equal(normaliseLicence({ lid: 'L-ABC12345', keyMasked: '<script>' }).keyMasked, '');
});

test('a licence in plain words: kind, what happens when it ends, moves, and the state; an unknown state is shown as it is, never hidden', () => {
  const base = { lid: 'L-ABC12345', plan: 'business', limits: { devices: 3, stores: 1, users: 10 }, exp: null, onEnd: 'banner', trial: false, trialDaysLeft: null, status: 'active', devices: [{ id: 'a' }, { id: 'b' }], moves: { used: 1, allowed: 2, windowDays: 365 } };
  const paid = describeLicence(base);
  assert.deepEqual([paid.state, paid.kind, paid.pcs, paid.moves, paid.movesLeft, paid.off], ['Working', 'Paid', '2 of 3 PCs in use', 'Moves used: 1 of 2 this year', 1, false]);
  assert.match(paid.whenItEnds, /^No end date: it keeps working\. If an end date is ever set, then when it ends the shop keeps working and shows a banner\.$/);
  const trial = describeLicence({ ...base, trial: true, trialDaysLeft: 9, exp: '2026-10-14T00:00:00.000Z', onEnd: 'stop' });
  assert.equal(trial.kind, 'Trial: 9 days left');
  assert.equal(trial.whenItEnds, 'Ends on 14 Oct 2026. When it ends, the till stops selling (the owner can still see and export their own data).');
  assert.equal(describeLicence({ ...base, trial: true, trialDaysLeft: 1 }).kind, 'Trial: 1 day left');
  assert.equal(describeLicence({ ...base, trial: true, trialDaysLeft: 0 }).kind, 'Trial: ends today');
  assert.equal(describeLicence({ ...base, trial: true, trialDaysLeft: -2 }).kind, 'Trial (ended)');
  assert.equal(describeLicence({ ...base, trial: true, trialDaysLeft: null, status: 'expired' }).kind, 'Trial (ended)');
  assert.equal(describeLicence({ ...base, onEnd: null }).whenItEnds, 'The Licence Studio did not say what happens when it ends.');
  for (const status of ['revoked', 'suspended']) assert.deepEqual([describeLicence({ ...base, status }).state, describeLicence({ ...base, status }).off], ['Switched off', true]);
  assert.equal(describeLicence({ ...base, status: 'expired' }).state, 'Ended');
  assert.equal(describeLicence({ ...base, status: 'strange' }).state, 'Status: strange');
  assert.equal(describeLicence({ ...base, moves: { used: 0, allowed: 2, windowDays: 90 } }).moves, 'Moves used: 0 of 2 in the last 90 days');
  assert.equal(describeLicence({ ...base, limits: { devices: 0, stores: 0, users: 0 } }).pcs, '2 of any number of PCs in use');
});

// ---- connecting the licence service -------------------------------------------------------------------------------------------------------------------------

test('who may connect the licence service; the address is checked, the staff access code is saved, tested and never shown', async () => {
  const s = await boot();
  try {
    const { admin, sam, rita } = await people(s);
    const first = (await s.call('GET', '/api/licence-service', { session: sam })).json.connection;
    assert.deepEqual([first.ready, first.url, first.code.set], [false, '', false]);
    assert.match(first.why, /not connected the licence service yet/);
    for (const who of [sam, rita]) {
      assert.equal((await s.call('PUT', '/api/licence-service', { session: who, body: { url: s.ls.url } })).status, 403);
      assert.equal((await s.call('PUT', '/api/licence-service/code', { session: who, body: { code: s.ls.token } })).status, 403);
      assert.equal((await s.call('DELETE', '/api/licence-service/code', { session: who })).status, 403);
      assert.equal((await s.call('POST', '/api/licence-service/test', { session: who })).status, 403);
    }
    assert.equal(s.ls.seen.length, 0, 'nobody who may not connect it made the Studio call it');
    for (const url of ['licence.example.com', 'http://licence.example.com', 'https://who:what-is-it@licence.example.com']) {
      const refused = await s.call('PUT', '/api/licence-service', { session: admin, body: { url } });
      assert.equal(refused.status, 400, url);
      assert.match(refused.json.error, /^The address of the Licence Studio /);
    }
    for (const code of ['short', 'has spaces in the middle of it', 's'.repeat(401)]) assert.equal((await s.call('PUT', '/api/licence-service/code', { session: admin, body: { code } })).status, 400, code);
    // the code of the build service is not the code of the Licence Studio
    await connectBuild(s, admin);
    const mixed = await s.call('PUT', '/api/licence-service/code', { session: admin, body: { code: s.gh.tokens.start } });
    assert.equal(mixed.status, 400);
    assert.match(mixed.json.error, /one of the build service's access codes/);

    await connectLicence(s, admin);
    const conn = (await s.call('GET', '/api/licence-service', { session: sam })).json.connection;
    assert.deepEqual([conn.ready, conn.url, conn.code.set], [true, s.ls.url, true]);
    assert.ok(!JSON.stringify(s.said).includes(s.ls.token), 'no answer holds the staff access code');

    const test = (await s.call('POST', '/api/licence-service/test', { session: admin })).json;
    assert.equal(test.ok, true, JSON.stringify(test.checks));
    assert.deepEqual(test.checks.map((c) => c.id), ['address', 'answers', 'code', 'rights']);
    assert.equal(test.checks.find((c) => c.id === 'rights').ok, null, 'what cannot be known is said to be unknown');
    const probe = s.ls.seen.at(-1);
    assert.deepEqual([probe.method, probe.path, probe.acting, probe.hadCode], ['GET', '/api/staff/v1/customers/studio-connection-test/licences', 'Asha Admin', true]);

    // removing the code
    const removed = await s.call('DELETE', '/api/licence-service/code', { session: admin });
    assert.deepEqual([removed.json.connection.code.set, removed.json.connection.ready], [false, false]);
    await s.call('PUT', '/api/licence-service/code', { session: admin, body: { code: s.ls.token } });

    const trail = (await s.call('GET', '/api/audit', { session: admin })).json.entries;
    assert.ok(trail.some((e) => e.action === 'key.saved' && e.detail === 'licence service: staff access code for the licence studio'));
    assert.ok(trail.some((e) => e.action === 'licence.service.tested' && e.detail === 'every check passed'));
    assert.ok(trail.some((e) => e.action === 'settings.changed' && e.detail === 'licenceService'));
    assert.ok(!JSON.stringify(trail).includes(s.ls.token));
  } finally { await s.done(); }
});

test('"Test the connection" says in plain words what is wrong: the wrong code, a code that may not look, nothing there, another web page, an older Licence Studio, nothing typed', async () => {
  const s = await boot();
  try {
    const { admin } = await people(s);
    const test = async () => (await s.call('POST', '/api/licence-service/test', { session: admin })).json;
    const words = (r, id) => r.checks.find((c) => c.id === id)?.words ?? '';
    let r = await test();
    assert.equal(r.ok, false);
    assert.match(words(r, 'address'), /Type the address of the Licence Studio and save it first/);
    await s.call('PUT', '/api/licence-service', { session: admin, body: { url: s.ls.url } });
    r = await test();
    assert.match(words(r, 'code-set'), /staff access code has not been added yet/);
    assert.equal(s.ls.seen.length, 0, 'with no code, nothing is sent');
    // a wrong code
    await s.call('PUT', '/api/licence-service/code', { session: admin, body: { code: 'a-wrong-staff-code-0000-xyz' } });
    r = await test();
    assert.equal(r.ok, false);
    assert.match(words(r, 'code'), /did not accept the staff access code/);
    assert.ok(!JSON.stringify(r).includes('a-wrong-staff-code'));
    // the right one
    await s.call('PUT', '/api/licence-service/code', { session: admin, body: { code: s.ls.token } });
    assert.equal((await test()).ok, true);
    // a code that may not look
    s.ls.options.forbidReads = true;
    r = await test();
    assert.match(words(r, 'code'), /will not let it look at licences\. It says: This staff access code may not look at licences\./);
    s.ls.options.forbidReads = false;
    // a Licence Studio that does not know a customer says so in its own way: that is still a yes
    s.ls.options.unknownCustomer404 = true;
    assert.equal((await test()).ok, true);
    s.ls.options.unknownCustomer404 = false;
    // an older Licence Studio, another web page, nothing there, a failing one
    s.ls.options.oldServer = true;
    assert.match(words(await test(), 'answers'), /does not know the staff calls this Studio uses/);
    s.ls.options.oldServer = false;
    s.ls.options.html = true;
    assert.match(words(await test(), 'answers'), /not the way the Licence Studio does/);
    s.ls.options.html = false;
    s.ls.options.fail = [{ match: /licences$/, status: 500, times: 1 }];
    assert.match(words(await test(), 'answers'), /had a problem \(500\)/);
    s.ls.options.down = true;
    r = await test();
    assert.equal(r.ok, false);
    assert.match(words(r, 'answers'), /could not reach the Licence Studio/);
    s.ls.options.down = false;
    assert.ok(!JSON.stringify(s.said).includes(s.ls.token));
  } finally { await s.done(); }
});

test('the staff access code and every activation key live only in the Studio\'s own secret store: not in the workspace, a backup, a pack, a message or the activity record', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectBuild(s, who.admin); await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    assert.equal((await press(s, who.rita, id)).status, 200);
    await finished(s, who.rita, id);
    const key = s.ls.made()[0].key;
    const shown = await s.call('POST', `/api/customers/${id}/licences/${s.ls.made()[0].lid}/key`, { session: who.rita });
    assert.equal(shown.json.key, key);
    // the store holds them, for this person only
    const store = join(s.root, 'home', 'keys.json');
    assert.ok(readFileSync(store, 'utf8').includes(s.ls.token) && readFileSync(store, 'utf8').includes(key));
    if (process.platform !== 'win32') assert.equal(statSync(store).mode & 0o077, 0, 'only its owner can read the store');
    const backup = (await s.call('POST', '/api/backup', { session: who.admin })).json;
    const zip = readZipFiles(readFileSync(backup.file));
    assert.ok(zip.size > 3);
    const secrets = [s.ls.token, key];
    for (const [name, bytes] of zip) for (const secret of secrets) assert.ok(!bytes.includes(secret), `${name} (in the backup) holds a secret`);
    for (const f of everyFile(s.folder)) for (const secret of secrets) assert.ok(!f.bytes.includes(secret), `${f.path} holds a secret`);
    for (const a of s.said) for (const secret of secrets) if (!a.path.endsWith('/key')) assert.ok(!a.text.includes(secret), `the answer to ${a.path} holds a secret`);
    assert.ok(!JSON.stringify((await s.call('GET', '/api/audit', { session: who.admin })).json).match(/NGOS-[A-Z0-9]{5}-[A-Z0-9]{5}/), 'no key in the activity record');
    // and a licence's key never comes with the list
    const list = (await lic(s, who.rita, id)).json;
    assert.match(list.licences[0].keyMasked, /^NGOS-•+-•+-•+-/);
    assert.ok(!JSON.stringify(list).includes(key));
  } finally { await s.done(); }
});

// ---- the customer's Licences section -----------------------------------------------------------------------------------------------------------------------

test('the Licences section: what the licence is, in plain words, for everyone signed in; the key and the changes only for the roles that may', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    // nothing yet: what the approved setup asks for
    let v = (await lic(s, who.sam, id)).json;
    assert.deepEqual([v.service.ready, v.licences, v.problem, v.can], [true, [], '', { key: false, manage: false, admin: false, connect: false }]);
    assert.equal(v.expected.ok, true);
    assert.match(v.expected.words, /^plan "business", 3 PCs, paid, with no end date; when it ends, the shop keeps working and shows a banner$/);
    assert.equal(v.expected.release, 1);

    const trial = s.ls.seed(id, { lid: 'L-TRIAL0001', plan: 'starter', trial: true, trialDaysLeft: 9, exp: 1_790_777_600, onEnd: 'stop', limits: { devices: 2, stores: 1, users: 3 } });
    s.ls.addDevice(trial.lid, { label: 'Front counter' });
    s.ls.addDevice(trial.lid, { label: 'Back office', lastCheckIn: 1_790_100_000 });
    s.ls.seed('another-shop', { lid: 'L-OTHER0001' });
    v = (await lic(s, who.sam, id)).json;
    assert.deepEqual(v.licences.map((l) => l.lid), ['L-TRIAL0001'], 'only this customer\'s');
    const one = v.licences[0];
    assert.deepEqual([one.words.state, one.words.kind, one.words.pcs, one.words.moves, one.keyHeld], ['Working', 'Trial: 9 days left', '2 of 2 PCs in use', 'Moves used: 0 of 2 this year', false]);
    assert.match(one.words.whenItEnds, /^Ends on \d+ \w+ 2026\. When it ends, the till stops selling/);
    assert.deepEqual(one.devices.map((d) => [d.label, d.version, typeof d.activatedAt, typeof d.lastCheckIn]), [['Front counter', '1.4.0', 'string', 'string'], ['Back office', '1.4.0', 'string', 'string']]);
    assert.ok(!JSON.stringify(v).includes(trial.key), 'the whole key never comes with the list');

    // the key: a salesperson may not, a reviewer may when this PC holds it (it does not: the licence was made in the Licence Studio itself)
    assert.equal((await s.call('POST', `/api/customers/${id}/licences/L-TRIAL0001/key`, { session: who.sam })).status, 403);
    const nokey = await s.call('POST', `/api/customers/${id}/licences/L-TRIAL0001/key`, { session: who.rita });
    assert.equal(nokey.status, 404);
    assert.equal(nokey.json.code, 'licence-key-missing');
    assert.match(nokey.json.error, /does not hold the whole key .* only once, when the licence is made/);
    assert.equal((await s.call('POST', `/api/customers/${id}/licences/L-OTHER0001/key`, { session: who.rita })).status, 404, 'another customer\'s licence cannot be reached from this customer\'s page');

    // each role sees what it may do
    assert.deepEqual((await lic(s, who.rita, id)).json.can, { key: true, manage: true, admin: false, connect: false });
    assert.deepEqual((await lic(s, who.admin, id)).json.can, { key: true, manage: true, admin: true, connect: true });
    const meCan = async (session) => { const c = (await s.call('GET', '/api/me', { session })).json.can; return [c['licence.key'], c['licence.manage'], c['licence.admin']]; };
    assert.deepEqual([await meCan(who.sam), await meCan(who.rita), await meCan(who.admin)], [[false, false, false], [true, true, false], [true, true, true]]);
    assert.equal((await s.call('POST', `/api/customers/${id}/licences/L-OTHER0001/extend`, { session: who.rita, body: { days: 5 } })).status, 404, 'nor can it be changed from here');
    // a customer that does not exist is a plain "not found"
    assert.equal((await lic(s, who.sam, 'nobody-here')).status, 404);
    assert.equal((await s.call('GET', '/api/customers/nobody-here/licences', { session: who.sam })).status, 404);
  } finally { await s.done(); }
});

test('who may do what to a licence: free a PC and extend a trial and turn it into a paid one (a reviewer or an administrator), switch off and on (an administrator only); each needs the right thing and is written in the activity record', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    const t = s.ls.seed(id, { lid: 'L-TRIAL0001', plan: 'starter', trial: true, trialDaysLeft: 5, exp: 1_790_400_000, onEnd: 'stop' });
    s.ls.addDevice(t.lid, { label: 'Front counter' }); s.ls.addDevice(t.lid, { label: 'Back office' });
    const at = (path) => `/api/customers/${id}/licences/L-TRIAL0001/${path}`;
    const attempts = [['devices/pc-1/free', { reason: 'The old PC was replaced' }], ['extend', { days: 7 }], ['convert', {}], ['revoke', { reason: 'Not paid' }], ['restore', {}]];

    // a salesperson may look and nothing else
    for (const [path, body] of attempts) assert.equal((await s.call('POST', at(path), { session: who.sam, body })).status, 403, path);
    assert.equal(s.ls.seen.filter((r) => r.method === 'POST').length, 0, 'a refused person made the Studio ask for nothing');
    // a reviewer may free, extend and convert, not switch off or on
    for (const path of ['revoke', 'restore']) { const r = await s.call('POST', at(path), { session: who.rita, body: { reason: 'Not paid' } }); assert.equal(r.status, 403, path); assert.match(r.json.error, /Your role \(Reviewer\) cannot switch a licence o/); }
    assert.equal(s.ls.seen.filter((r) => r.method === 'POST').length, 0);

    // free a PC: a reason is needed, the PC must be on the licence, and the move is counted
    for (const reason of [undefined, '', 'ok']) assert.equal((await s.call('POST', at('devices/pc-1/free'), { session: who.rita, body: { reason } })).status, 400, String(reason));
    assert.equal((await s.call('POST', at('devices/pc-99/free'), { session: who.rita, body: { reason: 'The old PC was replaced' } })).status, 404);
    assert.equal((await s.call('POST', at('devices/..%2F..%2Fx/free'), { session: who.rita, body: { reason: 'The old PC was replaced' } })).status, 404);
    const freed = await s.call('POST', at('devices/pc-1/free'), { session: who.rita, body: { reason: 'The old PC was replaced' } });
    assert.equal(freed.status, 200, JSON.stringify(freed.json));
    assert.deepEqual(freed.json.licences[0].devices.map((d) => d.label), ['Back office']);
    assert.equal(freed.json.licences[0].words.moves, 'Moves used: 1 of 2 this year');
    const sent = s.ls.seen.find((r) => r.path.endsWith('/devices/pc-1/free'));
    assert.deepEqual([sent.method, sent.acting, sent.hadCode, sent.body], ['POST', 'Rita Reviewer', true, { reason: 'The old PC was replaced' }]);

    // extend a trial: days are checked, only a trial can be extended
    for (const days of [0, -3, 91, 2.5, 'many', undefined]) assert.equal((await s.call('POST', at('extend'), { session: who.rita, body: { days } })).status, 400, String(days));
    const ext = await s.call('POST', at('extend'), { session: who.rita, body: { days: 7 } });
    assert.equal(ext.status, 200);
    assert.equal(ext.json.licences[0].words.kind, 'Trial: 12 days left');
    assert.deepEqual(s.ls.seen.find((r) => r.path.endsWith('/extend')).body, { days: 7 });

    // turn the trial into a paid licence; it cannot be done twice, and a paid licence cannot be extended
    const conv = await s.call('POST', at('convert'), { session: who.rita, body: {} });
    assert.equal(conv.status, 200);
    assert.deepEqual([conv.json.licences[0].words.kind, conv.json.licences[0].trial], ['Paid', false]);
    const again = await s.call('POST', at('convert'), { session: who.rita, body: {} });
    assert.equal(again.status, 409);
    assert.match(again.json.error, /not a trial/);
    assert.match((await s.call('POST', at('extend'), { session: who.rita, body: { days: 7 } })).json.error, /Only a trial can be extended/);

    // an administrator switches it off (with a reason) and on again; a switched-off licence cannot be switched off again
    assert.equal((await s.call('POST', at('revoke'), { session: who.admin, body: {} })).status, 400);
    const off = await s.call('POST', at('revoke'), { session: who.admin, body: { reason: 'The customer asked to stop' } });
    assert.equal(off.status, 200);
    assert.deepEqual([off.json.licences[0].words.state, off.json.licences[0].words.off], ['Switched off', true]);
    assert.match((await s.call('POST', at('revoke'), { session: who.admin, body: { reason: 'The customer asked to stop' } })).json.error, /already switched off/);
    assert.equal((await s.call('POST', at('restore'), { session: who.admin, body: {} })).json.licences[0].words.state, 'Working');
    assert.match((await s.call('POST', at('restore'), { session: who.admin, body: {} })).json.error, /not switched off/);

    const trail = (await s.call('GET', `/api/audit?customer=${id}`, { session: who.admin })).json.entries.map((e) => [e.action, e.who.name, e.detail]).reverse();
    assert.deepEqual(trail.filter(([a]) => a.startsWith('licence.')), [
      ['licence.device.freed', 'Rita Reviewer', 'L-TRIAL0001: Front counter. Reason: The old PC was replaced'],
      ['licence.extended', 'Rita Reviewer', 'L-TRIAL0001: the trial was extended by 7 days'],
      ['licence.converted', 'Rita Reviewer', 'L-TRIAL0001: the trial became a paid licence'],
      ['licence.revoked', 'Asha Admin', 'L-TRIAL0001: switched off. Reason: The customer asked to stop'],
      ['licence.restored', 'Asha Admin', 'L-TRIAL0001: switched on again'],
    ]);
    // what is sent for every change carries the name of the person
    assert.deepEqual([...new Set(s.ls.seen.filter((r) => r.method === 'POST').map((r) => r.acting))].sort(), ['Asha Admin', 'Rita Reviewer']);
  } finally { await s.done(); }
});

test('moving a licence to a new PC at most 2 times a year: when the moves are used a reviewer is told so without asking the Licence Studio; an administrator may try, and what the Licence Studio answers is said in plain words', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    const l = s.ls.seed(id, { lid: 'L-PAID00001', moves: 2 });
    for (const n of [1, 2, 3]) s.ls.addDevice(l.lid, { label: `Counter ${n}` });
    const free = (session, device = 'pc-1') => s.call('POST', `/api/customers/${id}/licences/L-PAID00001/devices/${device}/free`, { session, body: { reason: 'The old PC was replaced' } });
    const before = s.ls.seen.length;
    const refused = await free(who.rita);
    assert.equal(refused.status, 403);
    assert.equal(refused.json.code, 'moves');
    assert.match(refused.json.error, /already moved their licence 2 of 2 times this year, which is as often as the licence allows\. Moving more needs an administrator\./);
    assert.deepEqual(s.ls.seen.slice(before).map((r) => r.method), ['GET'], 'it was looked up, and nothing was asked to change');
    // the page tells the reviewer the same thing in the list it shows (2 of 2 used)
    assert.equal((await lic(s, who.rita, id)).json.licences[0].words.movesLeft, 0);
    // an administrator tries; the Licence Studio holds the limit and says no
    const stopped = await free(who.admin);
    assert.equal(stopped.status, 409);
    assert.equal(stopped.json.code, 'moves');
    assert.match(stopped.json.error, /moved their licence to a new PC as often as a year allows \(2 times\)\. It says: This licence has been moved twice in the last year\. To allow more, the owner has to approve it in the Licence Studio\./);
    assert.equal(s.ls.licences.get('L-PAID00001').devices.length, 3, 'nothing was freed');
    // a move that is still allowed goes through
    s.ls.licences.get('L-PAID00001').moves = 1;
    const ok = await free(who.rita);
    assert.equal(ok.status, 200);
    assert.equal(ok.json.licences[0].words.moves, 'Moves used: 2 of 2 this year');
  } finally { await s.done(); }
});

// ---- the one button: the licence first, then the website and app ------------------------------------------------------------------------------------------

test('with the licence service not connected the build goes on, says plainly that no licence was made, and asks nobody', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectBuild(s, who.admin);
    const id = await approvedCustomer(s, who);
    const page = (await lic(s, who.sam, id)).json;
    assert.deepEqual([page.service.ready, page.licences, page.problem], [false, [], '']);
    assert.match(page.service.why, /has not connected the licence service yet/);
    const started = await press(s, who.rita, id);
    assert.equal(started.status, 200, JSON.stringify(started.json));
    assert.deepEqual(started.json.licence, { outcome: 'not-connected' });
    assert.deepEqual(started.json.current.licence, { outcome: 'not-connected' }, 'and it is kept with the build');
    await finished(s, who.rita, id);
    const done = (await s.call('GET', `/api/customers/${id}/website-app`, { session: who.sam })).json;
    assert.equal(done.current.state, 'done');
    assert.deepEqual(done.current.licence, { outcome: 'not-connected' });
    assert.equal(s.ls.seen.length, 0, 'the Licence Studio was not asked anything');
    // the address is saved but the code is not: still not connected
    await s.call('PUT', '/api/licence-service', { session: who.admin, body: { url: s.ls.url } });
    assert.equal((await press(s, who.rita, id)).json.licence.outcome, 'not-connected');
    assert.equal(s.ls.seen.length, 0);
  } finally { await s.done(); }
});

test('the one button asks for the licence first, with the plan and the number of PCs from the approved setup, once, with a key that is the same each time; then the build carries on and the whole key can be shown for the hand-over', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectBuild(s, who.admin); await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    // the page says before the press what will be asked for
    assert.equal((await lic(s, who.rita, id)).json.expected.words.startsWith('plan "business", 3 PCs, paid'), true);
    s.ls.options.onRequest = (e) => { if (e.method === 'POST') e.dispatchesBefore = s.gh.seen.filter((r) => r.path.endsWith('/dispatches')).length; };
    const started = await press(s, who.rita, id);
    assert.equal(started.status, 200, JSON.stringify(started.json));
    assert.deepEqual([started.json.licence.outcome, started.json.licence.plan, started.json.licence.trial, started.json.licence.keyKept], ['made', 'business', false, true]);
    assert.ok(!JSON.stringify(started.json).match(/NGOS-[A-Z0-9]{5}-/), 'the key is not in the answer to the button');
    const [made] = posts(s);
    assert.deepEqual([made.acting, made.hadCode, made.idempotency], ['Rita Reviewer', true, `ngos-studio-${id}-release-1`]);
    assert.deepEqual(made.body, { externalCustomerId: id, customerName: 'Luzon Fresh Mart', country: 'PH', plan: 'business', limits: { devices: 3 }, onEnd: 'banner', exp: null, white: { level: 'theme' } });
    // it was asked before the build was started
    assert.equal(made.dispatchesBefore, 0, 'no build had been started when the licence was asked for');
    await finished(s, who.rita, id);
    assert.equal((await s.call('GET', `/api/customers/${id}/website-app`, { session: who.rita })).json.current.state, 'done');

    // the licence is there, with its key held for the hand-over
    const v = (await lic(s, who.rita, id)).json;
    assert.deepEqual(v.licences.map((l) => [l.plan, l.keyHeld, l.words.kind, l.limits.devices]), [['business', true, 'Paid', 3]]);
    const key = await s.call('POST', `/api/customers/${id}/licences/${v.licences[0].lid}/key`, { session: who.rita });
    assert.equal(key.json.key, s.ls.made()[0].key);
    assert.match(key.json.key, /^NGOS-[A-Z0-9]{5}-[A-Z0-9]{5}-[A-Z0-9]{5}-[A-Z0-9]{5}$/);
    const trail = (await s.call('GET', `/api/audit?customer=${id}`, { session: who.admin })).json.entries.map((e) => [e.action, e.detail]);
    assert.ok(trail.some(([a, d]) => a === 'licence.requested' && d === `${made.body ? s.ls.made()[0].lid : ''}: plan "business", 3 PCs, paid, with no end date; when it ends, the shop keeps working and shows a banner; from release 1`));
    assert.ok(trail.some(([a, d]) => a === 'licence.key.shown' && d === `licence ${s.ls.made()[0].lid}`));

    // making them again does not make another licence
    const again = await press(s, who.rita, id);
    assert.equal(again.status, 200);
    assert.deepEqual([again.json.licence.outcome, again.json.licence.lid], ['existing', s.ls.made()[0].lid]);
    await finished(s, who.rita, id);
    assert.equal(posts(s).length, 1);
    assert.equal(s.ls.made().length, 1);
  } finally { await s.done(); }
});

test('a trial asks for a trial: its days, and the till stops when it ends', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectBuild(s, who.admin); await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who, good({ licence: { whiteLabel: 'none', seats: 1, plan: 'starter', trial: true, trialDays: 21 } }));
    assert.equal((await press(s, who.rita, id)).json.licence.outcome, 'made');
    assert.deepEqual(posts(s)[0].body, { externalCustomerId: id, customerName: 'Luzon Fresh Mart', country: 'PH', plan: 'starter', limits: { devices: 1 }, onEnd: 'stop', trialDays: 21, white: { level: 'none' } });
    const l = (await lic(s, who.rita, id)).json.licences[0];
    assert.deepEqual([l.trial, l.onEnd, l.words.kind, l.words.whenItEnds.startsWith('Ends on ')], [true, 'stop', 'Trial: 21 days left', true]);
    await finished(s, who.rita, id);
  } finally { await s.done(); }
});

test('two presses at once, a retry after an answer was lost, and a list that said "none" by mistake: one licence is made, never two', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectBuild(s, who.admin); await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    // two at once
    const both = await Promise.all([press(s, who.rita, id), press(s, who.admin, id)]);
    assert.deepEqual(both.map((r) => r.status).sort(), [200, 409], 'one build starts, the other is told one is running');
    assert.match(both.find((r) => r.status === 409).json.error, /already running/);
    await finished(s, who.rita, id);
    assert.equal(s.ls.made().length, 1);
    assert.equal(posts(s).length, 1, 'the second press did not ask again');

    // the Licence Studio is told twice with the same key (the list said "none" once by mistake): it makes it once and the Studio gets the key again
    const key = s.ls.made()[0].key;
    s.ls.options.hideListOnce = 1;
    const replay = await press(s, who.rita, id);
    assert.equal(replay.status, 200, JSON.stringify(replay.json));
    assert.equal(replay.json.licence.outcome, 'made');
    assert.equal(posts(s).length, 2);
    assert.equal(posts(s)[1].idempotency, posts(s)[0].idempotency, 'the same key');
    assert.equal(s.ls.made().length, 1, 'but still one licence');
    assert.equal((await s.call('POST', `/api/customers/${id}/licences/${s.ls.made()[0].lid}/key`, { session: who.rita })).json.key, key);
    await finished(s, who.rita, id);

    // a new customer: the answer to "make it" is lost on the way
    const second = await approvedCustomer(s, who, good({ business: { name: 'Cebu Corner Shop', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0101', email: 'help@cebucorner.example' } }, ecosystem: { website: { wanted: true, domain: 'cebucorner.example' }, android: { wanted: false, appId: '' } } }));
    s.ls.options.dropAnswerOnce = 1;
    const lost = await press(s, who.rita, second);
    assert.equal(lost.status, 409);
    assert.equal(lost.json.code, 'licence-service', 'the page may offer to build without a licence for now');
    assert.match(lost.json.error, /could not reach the Licence Studio/);
    assert.equal(s.gh.seen.filter((r) => r.path.endsWith('/dispatches')).length, 2, 'no build was started for the second customer');
    assert.equal(s.ls.made().length, 2, 'the Licence Studio did make it');
    // the retry finds the licence there and goes on; the whole key is not held by this PC (it never came), and the page says so
    const retry = await press(s, who.rita, second);
    assert.equal(retry.status, 200, JSON.stringify(retry.json));
    assert.equal(retry.json.licence.outcome, 'existing');
    assert.equal(s.ls.made().length, 2, 'not a third');
    const missing = await s.call('POST', `/api/customers/${second}/licences/${retry.json.licence.lid}/key`, { session: who.rita });
    assert.equal(missing.status, 404);
    await finished(s, who.rita, second);
  } finally { await s.done(); }
});

test('when the licence cannot be made nothing is built, unless the person chooses to build without one for now; the build then says "no licence made yet"', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectBuild(s, who.admin); await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    const dispatches = () => s.gh.seen.filter((r) => r.path.endsWith('/dispatches')).length;
    // the Licence Studio is down
    s.ls.options.down = true;
    const down = await press(s, who.rita, id);
    assert.equal(down.status, 409);
    assert.deepEqual([down.json.code, /could not reach the Licence Studio/.test(down.json.error)], ['licence-service', true]);
    assert.equal(dispatches(), 0);
    s.ls.options.down = false;
    // a wrong staff access code, a code that may only look
    await s.call('PUT', '/api/licence-service/code', { session: who.admin, body: { code: 'a-wrong-staff-code-0000-xyz' } });
    const wrong = await press(s, who.rita, id);
    assert.deepEqual([wrong.status, wrong.json.code], [409, 'licence-service']);
    assert.match(wrong.json.error, /did not accept this Studio's staff access code/);
    await s.call('PUT', '/api/licence-service/code', { session: who.admin, body: { code: s.ls.token } });
    s.ls.options.forbidWrites = true;
    const refused = await press(s, who.rita, id);
    assert.deepEqual([refused.status, refused.json.code], [403, 'licence-refused']);
    assert.match(refused.json.error, /will not let this Studio make this customer's licence\. It says: This staff access code may only look, not change anything\. The staff access code may have been made without that right/);
    s.ls.options.forbidWrites = false;
    // a plan the Licence Studio does not have
    const unknown = await approvedCustomer(s, who, good({ business: { name: 'Davao Dry Goods', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0102', email: 'help@davao.example' } }, licence: { whiteLabel: 'none', seats: 2, plan: 'platinum' }, ecosystem: { website: { wanted: true, domain: 'davao.example' }, android: { wanted: false, appId: '' } } }));
    const rejected = await press(s, who.rita, unknown);
    assert.deepEqual([rejected.status, rejected.json.code], [400, 'licence-rejected']);
    assert.match(rejected.json.error, /did not accept the request .* It says: There is no plan called "platinum"\. The plans are starter, business, growth\./);
    assert.equal(dispatches(), 0, 'nothing was built through all of that');
    assert.equal(s.ls.made().length, 0, 'and no licence was made');

    // the person's own choice
    const asked = posts(s).length;
    const without = await press(s, who.rita, id, { withoutLicence: true });
    assert.equal(without.status, 200, JSON.stringify(without.json));
    assert.deepEqual(without.json.licence, { outcome: 'skipped' });
    assert.deepEqual(without.json.current.licence, { outcome: 'skipped' });
    assert.equal(posts(s).length, asked, 'no licence was asked for');
    await finished(s, who.rita, id);
    assert.deepEqual((await s.call('GET', `/api/customers/${id}/website-app`, { session: who.rita })).json.current.licence, { outcome: 'skipped' });
    // a later press, with the Licence Studio back, makes it
    const later = await press(s, who.rita, id);
    assert.equal(later.json.licence.outcome, 'made');
    await finished(s, who.rita, id);
  } finally { await s.done(); }
});

test('an approved setup with no plan cannot ask for a licence: it says so in plain words and offers to build without one; a salesperson cannot start anything; a build that cannot start asks for no licence', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who, good({ licence: { whiteLabel: 'theme', seats: 3 } }));
    const page = (await lic(s, who.sam, id)).json;
    assert.deepEqual([page.expected.ok, /^No plan is chosen in the approved setup/.test(page.expected.problem)], [false, true]);
    // the build service is not connected: the build cannot start, so no licence is asked for either
    const looked = s.ls.seen.length;
    const early = await press(s, who.rita, id);
    assert.equal(early.status, 409);
    assert.match(early.json.error, /not connected the build service yet/);
    assert.equal(s.ls.seen.length, looked, 'the Licence Studio was not asked anything');
    await connectBuild(s, who.admin);
    const before = s.ls.seen.length;
    const noPlan = await press(s, who.rita, id);
    assert.deepEqual([noPlan.status, noPlan.json.code], [409, 'licence-terms']);
    assert.match(noPlan.json.error, /^No plan is chosen in the approved setup, so no licence can be asked for\. Choose the plan in the details .* Or build now and make the licence later\.$/);
    assert.equal(posts(s).length, 0);
    assert.equal(s.ls.seen.length - before, 1, 'only the look at what the customer has');
    // a salesperson
    const sam = await press(s, who.sam, id);
    assert.equal(sam.status, 403);
    assert.equal(s.ls.seen.length - before, 1, 'and a salesperson asked for nothing');
    // building without
    assert.equal((await press(s, who.rita, id, { withoutLicence: true })).json.licence.outcome, 'skipped');
    await finished(s, who.rita, id);
  } finally { await s.done(); }
});

// ---- every ending ------------------------------------------------------------------------------------------------------------------------------------------

test('every way the Licence Studio can fail is said in plain words on the page and never holds a secret: not connected, a wrong code, a code that may not look, the server down, a failing server, another web page, an answer that is too big, too slow', async () => {
  const s = await boot({ licenceOptions: { requestTimeoutMs: 400 } });
  try {
    const who = await people(s);
    await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    const problem = async () => (await lic(s, who.rita, id)).json;
    // the page itself is still there, with a plain sentence
    s.ls.options.down = true;
    let v = await problem();
    assert.deepEqual([v.licences, /^The Studio could not reach the Licence Studio \(/.test(v.problem), v.service.ready], [[], true, true]);
    s.ls.options.down = false;
    s.ls.options.slowMs = 900;
    assert.match((await problem()).problem, /^The Licence Studio did not answer in time\./);
    s.ls.options.slowMs = 0;
    s.ls.options.fail = [{ match: /licences$/, status: 500, times: 1 }];
    assert.match((await problem()).problem, /^The Licence Studio had a problem \(500\)\. It usually passes: try again in a minute\. It says: Something broke inside the Licence Studio\.$/);
    s.ls.options.fail = [{ match: /licences$/, status: 503, times: 1, body: 'not json at all' }];
    assert.match((await problem()).problem, /^The Licence Studio had a problem \(503\)/);
    s.ls.options.fail = [{ match: /licences$/, status: 429, times: 1 }];
    assert.match((await problem()).problem, /too many requests/);
    s.ls.options.html = true;
    assert.match((await problem()).problem, /^That address answered, but not the way the Licence Studio does\./);
    s.ls.options.html = false;
    s.ls.options.bigAnswer = true;
    assert.match((await problem()).problem, /sent far more than it should/);
    s.ls.options.bigAnswer = false;
    s.ls.options.forbidReads = true;
    assert.match((await problem()).problem, /will not let this Studio look at this customer's licences\. It says: This staff access code may not look at licences\./);
    s.ls.options.forbidReads = false;
    await s.call('PUT', '/api/licence-service/code', { session: who.admin, body: { code: 'a-wrong-staff-code-0000-xyz' } });
    assert.match((await problem()).problem, /did not accept this Studio's staff access code\. It may have been typed wrongly, switched off in the Licence Studio, or run out\./);
    await s.call('PUT', '/api/licence-service/code', { session: who.admin, body: { code: s.ls.token } });
    // a Licence Studio that does not know the customer yet has no licence for them: either answer is "none"
    s.ls.options.unknownCustomer404 = true;
    v = await problem();
    assert.deepEqual([v.licences, v.problem], [[], '']);
    s.ls.options.unknownCustomer404 = false;
    // an older one, which answers "not found" to everything, is not taken for "no licence"
    s.ls.options.oldServer = true;
    assert.match((await problem()).problem, /^The Licence Studio did not find what the Studio asked for/);
    s.ls.options.oldServer = false;
    assert.deepEqual([(await problem()).problem, (await problem()).licences], ['', []]);
    // nothing printed or kept holds the code
    assert.ok(!JSON.stringify(s.said).includes(s.ls.token) && !JSON.stringify(s.said).includes('a-wrong-staff-code'));
    // the licence changes meet the same endings
    const l = s.ls.seed(id, { lid: 'L-TRIAL0001', trial: true, trialDaysLeft: 3 });
    s.ls.options.down = true;
    const act = await s.call('POST', `/api/customers/${id}/licences/L-TRIAL0001/extend`, { session: who.rita, body: { days: 7 } });
    assert.deepEqual([act.status, /could not reach the Licence Studio/.test(act.json.error)], [409, true]);
    s.ls.options.down = false;
    s.ls.options.forbidWrites = true;
    const refused = await s.call('POST', `/api/customers/${id}/licences/L-TRIAL0001/extend`, { session: who.rita, body: { days: 7 } });
    assert.deepEqual([refused.status, refused.json.code], [403, 'licence-refused']);
    assert.equal(l.trialDaysLeft, 3, 'nothing changed');
    s.ls.options.forbidWrites = false;
    // a licence removed there since the page was drawn
    s.ls.licences.delete('L-TRIAL0001');
    const gone = await s.call('POST', `/api/customers/${id}/licences/L-TRIAL0001/extend`, { session: who.rita, body: { days: 7 } });
    assert.deepEqual([gone.status, gone.json.code], [404, 'licence-gone']);
    for (const a of s.said) assert.ok(!a.text.includes(s.ls.token), `the answer to ${a.path} holds the staff access code`);
  } finally { await s.done(); }
});

test('the licence service is not connected: every Licences call says so in plain words and nothing is sent anywhere', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    const id = await approvedCustomer(s, who);
    const v = (await lic(s, who.rita, id)).json;
    assert.deepEqual([v.service.ready, v.licences, v.problem], [false, [], '']);
    assert.match(v.service.why, /Settings, "Connect the licence service"/);
    for (const [path, body] of [['devices/pc-1/free', { reason: 'The old PC was replaced' }], ['extend', { days: 3 }], ['convert', {}]]) {
      const r = await s.call('POST', `/api/customers/${id}/licences/L-ANYONE001/${path}`, { session: who.rita, body });
      assert.equal(r.status, 409, path);
      assert.match(r.json.error, /has not connected the licence service yet/);
    }
    assert.equal((await s.call('POST', `/api/customers/${id}/licences/L-ANYONE001/revoke`, { session: who.admin, body: { reason: 'Not paid at all' } })).status, 409);
    assert.equal(s.ls.seen.length, 0);
  } finally { await s.done(); }
});

test('a name that is not plain text still reaches the Licence Studio, written with %-escapes', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connectLicence(s, who.admin);
    const id = await approvedCustomer(s, who);
    const zoe = (await s.call('POST', '/api/team', { session: who.admin, body: { name: 'Zoë Ünal', role: 'reviewer', password: 'zoe-long-password' } })).json.member;
    const session = (await s.call('POST', '/api/signin', { body: { id: zoe.id, password: 'zoe-long-password' } })).json.session;
    assert.equal((await lic(s, session, id)).status, 200);
    assert.equal(s.ls.seen.at(-1).acting, 'Zo%C3%AB%20%C3%9Cnal');
    assert.equal(decodeURIComponent(s.ls.seen.at(-1).acting), 'Zoë Ünal');
  } finally { await s.done(); }
});

// ---- what a person reads and what the guide says ----------------------------------------------------------------------------------------------------------

test('the screens speak plain words: no technical name of the licence service on any screen it adds', () => {
  const forbidden = /\b(token|workflow|github|actions?|dispatch|runner|pipeline|commit|branch|json|api|idempotency|bearer|header|endpoint|http|url|payload)\b/i;
  const view = (name) => readFileSync(join(here, '..', 'ui', 'js', 'views', name), 'utf8');
  const noNotes = (text) => text.split('\n').filter((l) => !/^\s*\/\//.test(l)).join('\n');
  const settings = view('settings.js');
  const card = noNotes(settings.slice(settings.indexOf('async function licenceServiceCard'), settings.indexOf('void sheet')));
  const step = noNotes(view('licence.js'));
  const site = noNotes(view('site.js'));
  const details = noNotes(view('details.js'));
  const detailsLicence = details.slice(details.indexOf('How they are licensed'), details.indexOf('Notes', details.indexOf('How they are licensed')));
  assert.ok(card.length > 2500 && step.length > 6000 && site.length > 6000 && detailsLicence.length > 700, 'all were found');
  // what a person reads is a quoted text of more than one word (class names, ids and addresses are not read)
  const said = (text) => [...text.matchAll(/(['`])((?:\\.|(?!\1)[^\\])*)\1/g)].map((m) => m[2].replace(/\$\{[^}]*\}/g, '')).filter((t) => /[A-Za-z]+ [A-Za-z]+/.test(t) && !/^[a-z0-9-]+( [a-z0-9-]+)*$/.test(t));
  for (const [where, text] of [['the settings card', card], ['the Licence step', step], ['the licence parts of the website and app step', site], ['the licence choices in the details', detailsLicence]]) {
    const lines = said(text);
    assert.ok(lines.length > 4, `${where}: its words were found (${lines.length})`);
    for (const line of lines) assert.doesNotMatch(line.replace(/\bhttps:\/\/licence\.yourcompany\.example\b|\bhttps:\/\/\b/g, ''), forbidden, `${where}: ${line}`);
  }
  assert.match(settings, /Connect the licence service/);
  assert.match(step, /Licence/);
  // the words of the Licence Studio's own answers (lib/licences.mjs) are plain too
  const lib = noNotes(readFileSync(join(here, '..', 'lib', 'licences.mjs'), 'utf8'));
  for (const line of said(lib).filter((t) => /^(The |This |That |Please |Only |Approve |No |An administrator|Your )/.test(t))) assert.doesNotMatch(line.replace(/https:\/\/licence\.yourcompany\.example/g, ''), forbidden, line);
});

test('the Licence step and the settings are on the page; the new rights are in the list of roles; nothing the licence service is called is fixed in the screens', () => {
  const root = join(here, '..');
  const customer = readFileSync(join(root, 'ui', 'js', 'views', 'customer.js'), 'utf8');
  assert.match(customer, /\{ id: 'licence', label: 'Licence'/);
  assert.match(customer, /licence: \(\) => import\('\.\/licence\.js'\)/);
  const server = readFileSync(join(root, 'lib', 'server.mjs'), 'utf8');
  for (const perm of ['licence.key', 'licence.manage', 'licence.admin']) assert.ok(server.includes(`'${perm}'`), perm);
  // the Licence Studio has no address of its own in the Studio's code: it is the owner's setting
  for (const f of ['licences.mjs', 'server.mjs']) assert.doesNotMatch(readFileSync(join(root, 'lib', f), 'utf8'), /https?:\/\/(?!127\.0\.0\.1|localhost|licence\.yourcompany\.example|api\.github|uploads\.github)[a-z0-9.-]+\.[a-z]{2,}/i, f);
});

test('the guide says how to connect the licence service, who may do what with a licence, and that it has only been tried against a stand-in', () => {
  const guide = readFileSync(join(here, '..', '..', '..', 'docs', 'SETUP-STUDIO.md'), 'utf8');
  assert.match(guide, /Settings, Connect the licence service/);
  assert.match(guide, /\*\*Sales\*\*[^\n]*not show its key or change it/);
  assert.match(guide, /\*\*Reviewer\*\*[^\n]*show a licence key for the hand-over, free a PC, extend a trial, turn a trial into a paid licence/);
  assert.match(guide, /\*\*Administrator\*\*[^\n]*switch a licence off and on again/);
  assert.match(guide, /"No licence made yet"/);
  assert.match(guide, /Idempotency-Key/);
  assert.match(guide, /Which Android file goes to whom/);
  assert.match(guide, /tried only against a stand-in/);
  assert.match(guide, /\*\*NOT checked\*\* \(a person must\): \*\*the Licence Studio for real\*\*/);
  // the guide never promises what the Studio does not do
  assert.match(guide, /does not set up the customer's Google Play account for them yet/);
});
