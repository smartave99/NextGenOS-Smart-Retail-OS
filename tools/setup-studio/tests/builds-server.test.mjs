// The build service through the Studio's own interface: who may connect it and start a build, the whole way from an approved customer to a pack that holds the website and the app
// the build service made, what a trial does to the pack, a Studio closed in the middle of a build, and the words on the screens. The build service is a stand-in on this PC.
import { test } from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, rmSync, writeFileSync, readFileSync, readdirSync, statSync, mkdirSync, chmodSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { startStudio } from '../lib/server.mjs';
import { listZip } from '../lib/zip.mjs';
import { makeBaseKit } from '../../../scripts/make-base-kit.mjs';
import { standInGitHub, readZipFiles } from './stand-in-github.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const PNG = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==';
const good = (over = {}) => ({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example' } }, device: { kind: 'touch-pos', os: 'windows', screen: 'standard' }, look: { primaryColor: '#0a7d4b', style: 'friendly' }, licence: { whiteLabel: 'theme' }, ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' }, android: { wanted: true, appId: 'com.luzonfresh.shop' } }, ...over });
const until = async (condition, what = 'it did not happen in time') => { for (let i = 0; i < 400 && !(await condition()); i += 1) await new Promise((done) => setTimeout(done, 25)); assert.ok(await condition(), what); };

/** A Studio on this PC with a stand-in build service, and the three kinds of person. */
async function boot({ stand = {}, folderOf = null } = {}) {
  const root = folderOf?.root ?? mkdtempSync(join(tmpdir(), 'studio-builds-srv-'));
  process.env.SETUP_STUDIO_HOME = join(root, 'home');
  const gh = folderOf?.gh ?? await standInGitHub({});
  Object.assign(gh.options, stand);
  const studio = await startStudio({ folder: join(root, 'ws'), env: process.env, build: { api: gh.url, pollMs: 15, ceilingMs: 10_000, requestTimeoutMs: 1500, downloadTimeoutMs: 5000, lostContactLimit: 3 } });
  const base = studio.url.split('?')[0].replace(/\/$/, '');
  const call = async (method, path, { body, session } = {}) => {
    const res = await fetch(base + path, { method, headers: { 'content-type': 'application/json', 'x-studio-key': studio.token, ...(session ? { 'x-studio-session': session } : {}) }, body: body === undefined ? undefined : JSON.stringify(body) });
    const type = res.headers.get('content-type') ?? '';
    return { status: res.status, json: type.includes('json') ? await res.json() : null, buffer: type.includes('json') ? null : Buffer.from(await res.arrayBuffer()) };
  };
  return { root, gh, studio, call, folder: join(root, 'ws'), done: async ({ keep = false } = {}) => { await studio.close(); if (!keep) { await gh.close(); rmSync(root, { recursive: true, force: true }); } } };
}
async function people(s) {
  const admin = (await s.call('POST', '/api/setup', { body: { name: 'Asha Admin', password: 'a-long-password' } })).json.session;
  const sales = (await s.call('POST', '/api/team', { session: admin, body: { name: 'Sam Sales', role: 'sales', password: 'sam-long-password' } })).json.member;
  const reviewer = (await s.call('POST', '/api/team', { session: admin, body: { name: 'Rita Reviewer', role: 'reviewer', password: 'rita-long-password' } })).json.member;
  const sam = (await s.call('POST', '/api/signin', { body: { id: sales.id, password: 'sam-long-password' } })).json.session;
  const rita = (await s.call('POST', '/api/signin', { body: { id: reviewer.id, password: 'rita-long-password' } })).json.session;
  return { admin, sam, rita };
}
/** The administrator connects the build service: the two names and the two codes. */
async function connect(s, admin) {
  assert.equal((await s.call('PUT', '/api/build-service', { session: admin, body: { sourceRepo: s.gh.source, resultsRepo: s.gh.results, ref: '' } })).status, 200);
  assert.equal((await s.call('PUT', '/api/build-service/codes/start', { session: admin, body: { code: s.gh.tokens.start } })).status, 200);
  assert.equal((await s.call('PUT', '/api/build-service/codes/results', { session: admin, body: { code: s.gh.tokens.results } })).status, 200);
}
/** A customer who gets a website and an app, approved by a second person. */
async function approvedCustomer(s, { sam, rita }, intake = good()) {
  const id = (await s.call('POST', '/api/customers', { session: sam, body: { intake } })).json.customer.id;
  await s.call('PUT', `/api/customers/${id}/logo`, { session: sam, body: { data: PNG } });
  await s.call('POST', `/api/customers/${id}/proposal`, { session: sam });
  await s.call('POST', `/api/customers/${id}/submit`, { session: sam });
  assert.equal((await s.call('POST', `/api/customers/${id}/approve`, { session: rita })).json.customer.state, 'approved');
  return id;
}
async function programs(root, admin, s) {
  const dir = join(root, 'programs');
  mkdirSync(dir, { recursive: true });
  writeFileSync(join(dir, 'SmartRetailPOS-Hub-Setup-1.4.0.exe'), Buffer.alloc(4000, 7));
  writeFileSync(join(dir, 'smart-retail-pos-hub_1.4.0-1_amd64.deb'), Buffer.alloc(3000, 9));
  writeFileSync(join(dir, 'base-kit.json'), JSON.stringify((await makeBaseKit(dir)).manifest));
  assert.equal((await s.call('PUT', '/api/programs', { session: admin, body: { folder: dir } })).json.saved, true);
  return dir;
}
const current = async (s, session, id) => (await s.call('GET', `/api/customers/${id}/website-app`, { session })).json;

test('who may connect the build service and who may start a build; the access codes are saved, checked and never shown', async () => {
  const s = await boot();
  try {
    const { admin, sam, rita } = await people(s);
    const first = (await s.call('GET', '/api/build-service', { session: sam })).json.connection;
    assert.equal(first.ready, false);
    assert.match(first.why, /not connected the build service yet/);
    assert.deepEqual(first.codes, { start: { label: 'Access code for starting builds', set: false }, results: { label: 'Access code for keeping the results', set: false } });
    for (const who of [sam, rita]) {
      assert.equal((await s.call('PUT', '/api/build-service', { session: who, body: { sourceRepo: 'acme/a', resultsRepo: 'acme/b' } })).status, 403);
      assert.equal((await s.call('PUT', '/api/build-service/codes/start', { session: who, body: { code: s.gh.tokens.start } })).status, 403);
      assert.equal((await s.call('DELETE', '/api/build-service/codes/start', { session: who })).status, 403);
      assert.equal((await s.call('POST', '/api/build-service/test', { session: who })).status, 403);
    }
    // names are checked
    for (const bad of [{ sourceRepo: 'not a name', resultsRepo: 'acme/b' }, { sourceRepo: 'acme/a', resultsRepo: 'acme/a' }, { sourceRepo: 'acme/a', resultsRepo: 'acme/b', ref: 'bad ref' }]) assert.equal((await s.call('PUT', '/api/build-service', { session: admin, body: bad })).status, 400);
    // codes are checked; the same code is not taken twice; nothing comes back with a code in it
    assert.equal((await s.call('PUT', '/api/build-service/codes/start', { session: admin, body: { code: 'short' } })).status, 400);
    assert.equal((await s.call('PUT', '/api/build-service/codes/nonsense', { session: admin, body: { code: s.gh.tokens.start } })).status, 400);
    const saved = await s.call('PUT', '/api/build-service/codes/start', { session: admin, body: { code: s.gh.tokens.start } });
    assert.equal(saved.json.connection.codes.start.set, true);
    const twice = await s.call('PUT', '/api/build-service/codes/results', { session: admin, body: { code: s.gh.tokens.start } });
    assert.equal(twice.status, 400);
    assert.match(twice.json.error, /same code as the other box/);
    await connect(s, admin);
    const everything = JSON.stringify([saved.json, twice.json, (await s.call('GET', '/api/build-service', { session: sam })).json, (await s.call('GET', '/api/settings', { session: admin })).json]);
    for (const code of Object.values(s.gh.tokens)) assert.ok(!everything.includes(code), 'no answer holds a code');
    assert.equal((await s.call('GET', '/api/build-service', { session: sam })).json.connection.ready, true);

    const test = await s.call('POST', '/api/build-service/test', { session: admin });
    assert.equal(test.json.ok, true, JSON.stringify(test.json.checks.filter((c) => c.ok !== true)));
    assert.ok(!JSON.stringify(test.json).includes(s.gh.tokens.start));
    s.gh.options.startCanReadContents = true;
    const strong = (await s.call('POST', '/api/build-service/test', { session: admin })).json;
    assert.equal(strong.ok, false);
    assert.match(strong.checks.find((c) => c.id === 'start-power').words, /can also read the programs' source code/);

    // removing a code
    const removed = await s.call('DELETE', '/api/build-service/codes/results', { session: admin });
    assert.equal(removed.json.connection.codes.results.set, false);
    assert.equal(removed.json.connection.ready, false);
    // the activity record says what was done, never the code
    const trail = (await s.call('GET', '/api/audit', { session: admin })).json.entries;
    assert.ok(trail.some((e) => e.action === 'key.saved' && /build service: access code for starting builds/.test(e.detail)));
    assert.ok(trail.some((e) => e.action === 'build.service.tested'));
    assert.ok(trail.some((e) => e.action === 'settings.changed' && e.detail === 'build'));
    assert.ok(!JSON.stringify(trail).includes(s.gh.tokens.start) && !JSON.stringify(trail).includes(s.gh.tokens.results));
  } finally { await s.done(); }
});

test('the whole way: an approved customer, the build, the files that come back, and a pack that holds the website and the app; nothing is recorded as an installer until the pack is made', async () => {
  const s = await boot();
  try {
    const who = await people(s);
    await connect(s, who.admin);
    const id = await approvedCustomer(s, who);
    const dir = await programs(s.root, who.admin, s);

    // a salesperson sees what is ready and what would be sent, and cannot start it
    const plan = await current(s, who.sam, id);
    assert.equal(plan.canStart, true);
    assert.deepEqual(plan.parts.map((p) => [p.id, p.state]), [['website-linux', 'missing'], ['website-windows', 'missing'], ['android', 'missing']]);
    assert.match(plan.inputs.brand, /"name": "Luzon Fresh Mart"/);
    assert.match(plan.inputs.settings, /NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart/);
    assert.deepEqual(plan.inputs.files.map((f) => f.name).sort(), ['brand.json', 'build.json', 'logo.png', 'website-settings.env']);
    assert.equal((await s.call('POST', `/api/customers/${id}/website-app/build`, { session: who.sam, body: {} })).status, 403);
    assert.equal((await s.call('POST', `/api/customers/${id}/website-app/look`, { session: who.sam })).status, 403);
    assert.equal(s.gh.seen.filter((r) => r.path.endsWith('/dispatches')).length, 0);
    // before the build, the installer step says the website and the app are not there
    assert.deepEqual((await s.call('GET', `/api/customers/${id}/outputs`, { session: who.rita })).json.items.map((i) => [i.id, i.status]), [['shop-pc', 'ready'], ['website', 'missing'], ['android', 'missing']]);

    const started = await s.call('POST', `/api/customers/${id}/website-app/build`, { session: who.rita, body: {} });
    assert.equal(started.status, 200, JSON.stringify(started.json));
    assert.equal(started.json.current.n, 1);
    assert.equal((await s.call('POST', `/api/customers/${id}/website-app/build`, { session: who.rita, body: {} })).json.error ?? 'x', 'A build is already running for this customer. Wait for it to finish.', 'one at a time');
    await until(async () => ['done', 'partly', 'failed'].includes((await current(s, who.sam, id)).current.state));
    const done = (await current(s, who.sam, id)).current;
    assert.equal(done.state, 'done', JSON.stringify(done));
    assert.equal((await current(s, who.sam, id)).parts.every((p) => p.state === 'built'), true);

    // the customer is not "built" by this; the record and the activity say what happened
    const customer = (await s.call('GET', `/api/customers/${id}`, { session: who.rita })).json.customer;
    assert.equal(customer.state, 'approved');
    assert.equal(customer.builds.at(-1).kind, 'website-app');
    const trail = (await s.call('GET', `/api/audit?customer=${id}`, { session: who.rita })).json.entries.map((e) => e.action);
    assert.ok(trail.includes('build.requested') && trail.includes('build.finished'));

    // now the installer step finds them, and the pack holds them
    const out = (await s.call('GET', `/api/customers/${id}/outputs`, { session: who.rita })).json;
    assert.deepEqual(out.items.map((i) => [i.id, i.status]), [['shop-pc', 'ready'], ['website', 'ready'], ['android', 'ready']]);
    assert.equal(out.trial, false);
    assert.equal(out.programs.files.length, 2, 'the programs folder\'s own list is not changed by the customer\'s files');
    const made = await s.call('POST', `/api/customers/${id}/outputs/pack`, { session: who.rita, body: {} });
    assert.equal(made.status, 200, JSON.stringify(made.json));
    assert.equal(made.json.customer.state, 'built');
    const pack = await s.call('GET', `/api/customers/${id}/builds/1/pack.zip`, { session: who.rita });
    const names = listZip(pack.buffer);
    for (const want of ['Luzon Fresh Mart/3 - Website/website-luzon-fresh-mart-linux.zip', 'Luzon Fresh Mart/3 - Website/website-luzon-fresh-mart-windows.zip', 'Luzon Fresh Mart/4 - Android app/SmartRetailPOS-luzon-fresh-mart-1.0.1.apk', 'Luzon Fresh Mart/4 - Android app/SmartRetailPOS-luzon-fresh-mart-1.0.1.aab', 'Luzon Fresh Mart/1 - Shop PC (Windows)/SmartRetailPOS-Hub-Setup-1.4.0.exe']) assert.ok(names.includes(want), want);
    assert.ok(!names.some((n) => /inputs\.zip|result\.json|SHA256SUMS/.test(n)), 'the settings that were sent and the report stay out of the pack');
    const contents = JSON.parse(readFileSync(join(s.folder, 'builds', id, '1', `${id}-pack-release-1`, 'Luzon Fresh Mart', 'PACK-CONTENTS.json'), 'utf8'));
    assert.deepEqual(contents.parts.find((p) => p.id === 'website').programs.map((f) => f.name).sort(), ['website-luzon-fresh-mart-linux.zip', 'website-luzon-fresh-mart-windows.zip']);
    assert.equal(contents.programs.trial, false);

    // a file changed afterwards is not packed
    const site = join(s.folder, 'builds', id, 'website-app', '1');
    chmodSync(join(site, 'website-luzon-fresh-mart-linux.zip'), 0o644);
    writeFileSync(join(site, 'website-luzon-fresh-mart-linux.zip'), Buffer.alloc(statSync(join(site, 'website-luzon-fresh-mart-linux.zip')).size, 3));
    const refused = await s.call('POST', `/api/customers/${id}/outputs/pack`, { session: who.rita, body: {} });
    assert.equal(refused.status, 409);
    assert.equal(refused.json.code, 'site');
    assert.match(refused.json.error, /website-luzon-fresh-mart-linux\.zip was changed after it was fetched/);

    // make them again, this time a trial (no licence keys): the pack is refused unless it is only to try
    s.gh.options.outcome = 'trial';
    assert.equal((await current(s, who.sam, id)).canStart, true);
    const again = await s.call('POST', `/api/customers/${id}/website-app/build`, { session: who.rita, body: {} });
    assert.equal(again.status, 200);
    assert.equal(again.json.current.n, 2);
    await until(async () => (await current(s, who.sam, id)).current.state === 'done');
    assert.equal((await current(s, who.sam, id)).current.trial, true);
    const outTrial = (await s.call('GET', `/api/customers/${id}/outputs`, { session: who.rita })).json;
    assert.equal(outTrial.trial, true, 'the installer step offers "only to try"');
    const trialRefused = await s.call('POST', `/api/customers/${id}/outputs/pack`, { session: who.rita, body: {} });
    assert.equal(trialRefused.status, 409);
    assert.match(trialRefused.json.error, /licence keys/);
    assert.equal((await s.call('POST', `/api/customers/${id}/outputs/pack`, { session: who.rita, body: { allowTrial: true } })).status, 200);
    void dir;
  } finally { await s.done(); }
});

test('a Studio closed in the middle of a build: the build carries on, and a new Studio on the same files picks it up when the step is opened', async () => {
  const first = await boot({ stand: { holdPublish: true } });
  let second = null;
  try {
    const who = await people(first);
    await connect(first, who.admin);
    const id = await approvedCustomer(first, who);
    assert.equal((await first.call('POST', `/api/customers/${id}/website-app/build`, { session: who.rita, body: {} })).status, 200);
    await first.done({ keep: true });   // the Studio is closed (the build service goes on)
    first.gh.options.holdPublish = false;
    await until(() => first.gh.release(`customer-${id}-1`)?.draft === false, 'the build did not finish');
    second = await boot({ folderOf: first });
    // the people and the customer are in the same files; sign in again
    const members = (await second.call('GET', '/api/state')).json.team;
    const rita = (await second.call('POST', '/api/signin', { body: { id: members.find((m) => m.name === 'Rita Reviewer').id, password: 'rita-long-password' } })).json.session;
    const sam = (await second.call('POST', '/api/signin', { body: { id: members.find((m) => m.name === 'Sam Sales').id, password: 'sam-long-password' } })).json.session;
    assert.equal((await current(second, sam, id)).current.state, 'running', 'a salesperson only looks');
    await new Promise((done) => setTimeout(done, 150));
    assert.equal((await current(second, sam, id)).current.state, 'running', 'and does not pick the build up');
    await current(second, rita, id);   // a reviewer opening the step does
    await until(async () => (await current(second, sam, id)).current.state === 'done');
    assert.ok(readdirSync(join(second.folder, 'builds', id, 'website-app', '1')).includes('SmartRetailPOS-luzon-fresh-mart-1.0.1.apk'));
  } finally { if (second) await second.done(); else { await first.gh.close(); rmSync(first.root, { recursive: true, force: true }); } }
});

test('the screens speak plain words: no technical name of the build service on any screen it adds', () => {
  const forbidden = /\b(token|workflow|github|actions?|dispatch|runner|pipeline|commit|branch|json|api)\b/i;
  const view = (name) => readFileSync(join(here, '..', 'ui', 'js', 'views', name), 'utf8');
  const noNotes = (text) => text.split('\n').filter((l) => !/^\s*\/\//.test(l)).join('\n');
  const settings = view('settings.js');
  const card = noNotes(settings.slice(settings.indexOf('async function buildServiceCard'), settings.indexOf('// ---------- AI tools')));
  const site = noNotes(view('site.js'));
  assert.ok(card.length > 1500 && site.length > 3000, 'both were found');
  // what a person reads is a quoted text of more than one word (class names, ids and addresses are not read)
  const said = (text) => [...text.matchAll(/(['`])((?:\\.|(?!\1)[^\\])*)\1/g)].map((m) => m[2]).filter((t) => /[A-Za-z]+ [A-Za-z]+/.test(t) && !/^[a-z0-9-]+( [a-z0-9-]+)*$/.test(t));
  for (const [where, text] of [['the step', site], ['the settings card', card]]) {
    const lines = said(text);
    assert.ok(lines.length > 15, `${where}: its words were found (${lines.length})`);
    for (const line of lines) assert.doesNotMatch(line, forbidden, `${where}: ${line}`);
  }
  assert.match(settings, /Connect the build service/);
  assert.match(site, /Website and app/);
});

test('the roles are written down: what the Studio guide says each role may do with the build service matches what the Studio allows', () => {
  const guide = readFileSync(join(here, '..', '..', '..', 'docs', 'SETUP-STUDIO.md'), 'utf8');
  assert.match(guide, /Connect the build service/);
  assert.match(guide, /\*\*Sales\*\*[^\n]*see what would be built/);
  assert.match(guide, /\*\*Reviewer\*\*[^\n]*start the website and app build/);
  assert.match(guide, /\*\*Administrator\*\*[^\n]*connect the build service/);
});
