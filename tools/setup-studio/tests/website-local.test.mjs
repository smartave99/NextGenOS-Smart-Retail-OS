// A customer's website package, made on the staff PC with no GitHub and no internet: the website program from the kit + the customer's folder + the customer's licence file.
// These tests go through the Studio's real interface (the same server the page talks to). The website program is a stand-in (website-stand-in.mjs); the rules file that checks the
// customer's folder is the website's real one, which travels inside the package.
import { test } from 'node:test';
import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import { existsSync, mkdirSync, mkdtempSync, readFileSync, readdirSync, rmSync, statSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { startStudio } from '../lib/server.mjs';
import { checkIntake } from '../lib/intake.mjs';
import { listZip } from '../lib/zip.mjs';
import { extractZip } from '../lib/unzip.mjs';
import { customerFolderFiles, describeLicence, makeWebsitePackage, withLocalWebsites, websiteSystems } from '../lib/website-local.mjs';
import { readBaseKit } from '../lib/basekit.mjs';
import { licenceText, makeKit } from './website-stand-in.mjs';

const PNG = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==';
const sha = (buf) => createHash('sha256').update(buf).digest('hex');
const rawIntake = (over = {}) => ({
  business: { name: 'Luzon Fresh Mart', tagline: 'Fresh every morning', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example', address: 'Rizal Ave, Quezon City, Philippines' } },
  device: { kind: 'touch-pos', os: 'windows', screen: 'standard' }, look: { primaryColor: '#0a7d4b', style: 'friendly' }, licence: { whiteLabel: 'theme' },
  ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' }, android: { wanted: false, appId: '' }, aiAddon: { wanted: false } }, ...over,
});

/** The details as the Studio keeps them in an approved release (checked and filled in). */
const intake = (over = {}) => checkIntake(rawIntake(over)).value;

/** Starts a Studio on this PC. `kit` is the built-in kit's folder (it need not exist). Everything is made fresh and removed by done(). */
async function boot({ kit = 'no-kit-here' } = {}) {
  const root = mkdtempSync(join(tmpdir(), 'studio-web-'));
  process.env.SETUP_STUDIO_HOME = join(root, 'home');
  const studio = await startStudio({ folder: join(root, 'ws'), env: process.env, kitFolder: join(root, kit) });
  const base = studio.url.split('?')[0].replace(/\/$/, '');
  const call = async (method, path, { body, session, key = studio.token } = {}) => {
    const res = await fetch(base + path, { method, headers: { 'content-type': 'application/json', 'x-studio-key': key ?? '', ...(session ? { 'x-studio-session': session } : {}) }, body: body === undefined ? undefined : JSON.stringify(body) });
    const type = res.headers.get('content-type') ?? '';
    return { status: res.status, headers: res.headers, json: type.includes('json') ? await res.json() : null, buffer: type.includes('json') ? null : Buffer.from(await res.arrayBuffer()) };
  };
  const admin = (await call('POST', '/api/setup', { body: { name: 'Asha Admin', password: 'a-long-password' } })).json.session;
  const member = async (name, role, password) => { const m = (await call('POST', '/api/team', { session: admin, body: { name, role, password } })).json.member; return (await call('POST', '/api/signin', { body: { id: m.id, password } })).json.session; };
  const sam = await member('Sam Sales', 'sales', 'sam-long-password');
  const rita = await member('Rita Reviewer', 'reviewer', 'rita-long-password');
  /** A customer taken all the way to an approved release. */
  const approved = async (over = {}, { logo = true } = {}) => {
    const id = (await call('POST', '/api/customers', { session: sam, body: { intake: intake(over) } })).json.customer.id;
    if (logo) await call('PUT', `/api/customers/${id}/logo`, { session: sam, body: { data: PNG } });
    await call('POST', `/api/customers/${id}/proposal`, { session: sam });
    await call('POST', `/api/customers/${id}/submit`, { session: sam });
    assert.equal((await call('POST', `/api/customers/${id}/approve`, { session: rita })).json.customer.state, 'approved');
    return id;
  };
  return { root, studio, base, call, admin, sam, rita, member, approved, ws: join(root, 'ws'), done: async () => { await studio.close(); rmSync(root, { recursive: true, force: true }); delete process.env.SETUP_STUDIO_HOME; } };
}
const made = (s, id, os, n = 1) => join(s.ws, 'builds', id, 'website-local', String(n), `website-${id}-${os}.zip`);

test('a good run: the built-in kit is used, the website package is made on this PC for the system asked, with the customer\'s folder and the hidden mark, and no licence file yet', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit' });
    const id = await s.approved();

    const before = await s.call('GET', `/api/customers/${id}/website-package`, { session: s.sam });
    assert.equal(before.status, 200);
    assert.equal(before.json.canMake, true);
    assert.equal(before.json.programs.source, 'built-in');
    assert.deepEqual(before.json.systems.map((x) => [x.id, x.available]), [['linux', true], ['windows', true]]);
    assert.equal(before.json.licence.state, 'none');
    assert.deepEqual(before.json.made, []);

    assert.equal((await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.sam, body: { systems: ['linux'] } })).status, 403, 'a salesperson cannot make it');
    assert.equal((await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: [] } })).status, 400, 'a system must be chosen');
    assert.equal((await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['plan9'] } })).status, 400);

    const r = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    assert.equal(r.status, 200, JSON.stringify(r.json));
    const result = r.json.results[0];
    assert.equal(result.name, `website-${id}-linux.zip`);
    assert.equal(result.licenceIncluded, false);
    assert.match(result.notes.join(' '), /no licence file yet/);
    assert.ok(existsSync(made(s, id, 'linux')));
    assert.equal(result.sha256, sha(readFileSync(made(s, id, 'linux'))));
    assert.equal(result.bytes, statSync(made(s, id, 'linux')).size);
    assert.ok(!existsSync(made(s, id, 'windows')), 'only the system asked for');
    assert.deepEqual(readdirSync(join(s.ws, 'builds', id, 'website-local', '1')), [`website-${id}-linux.zip`], 'the working folder is gone');

    // what is inside: the program unchanged, the customer's folder in the website's form, no licence, the mark
    const names = listZip(readFileSync(made(s, id, 'linux')));
    const top = `website-${id}-linux/`;
    for (const want of ['start-website.sh', 'customer-rules.mjs', 'customer/brand.json', 'customer/website-settings.env', 'customer/assets/logo.png', 'app/.next/server/.build-info', 'PACKAGE-INFO.json']) assert.ok(names.includes(top + want), want);
    assert.ok(!names.includes(top + 'licence/licence.ngos'), 'no licence file was given, so none is inside');
    assert.ok(!names.some((n) => /setup\.json|theme\.json/.test(n)), 'the customer\'s lists of items and people (setup.json) never go into a website');
    const unpacked = join(s.root, 'unpacked');
    extractZip(made(s, id, 'linux'), unpacked);
    const brand = JSON.parse(readFileSync(join(unpacked, top, 'customer', 'brand.json'), 'utf8'));
    assert.deepEqual([brand.name, brand.country, brand.industry, brand.logo, brand.storefront.siteUrl], ['Luzon Fresh Mart', 'PH', 'retail', 'logo.png', 'https://luzonfresh.example']);
    assert.match(readFileSync(join(unpacked, top, 'customer', 'website-settings.env'), 'utf8'), /NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart/);
    const mark = JSON.parse(readFileSync(join(unpacked, top, 'app', '.next', 'server', '.build-info'), 'utf8'));
    assert.deepEqual([mark.customer, mark.person, mark.licence], [id, 'Rita Reviewer', null], 'the hidden mark names the customer and the person who made it');
    assert.match(readFileSync(join(unpacked, top, 'READ ME FIRST.txt'), 'utf8'), /licence\s+EMPTY: the licence file is not here yet/);

    // recorded: in the customer's list of what was made, with its fingerprint, and in the activity record
    const customer = (await s.call('GET', `/api/customers/${id}`, { session: s.sam })).json.customer;
    const record = customer.builds.at(-1);
    assert.deepEqual([record.kind, record.release, record.os, record.file, record.sha256, record.licenceIncluded, record.trial, record.by.name], ['website-local', 1, 'linux', result.name, result.sha256, false, false, 'Rita Reviewer']);
    assert.equal(customer.state, 'approved', 'making a website package does not turn the customer into "installer ready"');
    const trail = (await s.call('GET', `/api/audit?customer=${id}`, { session: s.rita })).json.entries;
    assert.ok(trail.some((e) => e.action === 'website.assembled' && e.detail.includes('no licence file yet')));
    const after = (await s.call('GET', `/api/customers/${id}/website-package`, { session: s.sam })).json;
    assert.deepEqual(after.made.map((m) => [m.os, m.name, m.sha256, m.there, m.replaced, m.forThisRelease]), [['linux', `website-${id}-linux.zip`, result.sha256, true, false, true]]);

    // the second system, later: the first stays
    const w = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['windows'] } });
    assert.equal(w.status, 200);
    assert.ok(existsSync(made(s, id, 'windows')) && existsSync(made(s, id, 'linux')));
    // making the same one again replaces it, and the older record is marked as replaced
    const again = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    assert.equal(again.status, 200);
    const list = again.json.made.filter((m) => m.os === 'linux');
    assert.deepEqual(list.map((m) => [m.replaced, m.there]), [[false, true], [true, false]]);
  } finally { await s.done(); }
});

test('the licence slot: a licence file put in place goes into the package; its text is never in the activity record; a wrong file is refused in plain words', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit' });
    const id = await s.approved();
    const path = `/api/customers/${id}/website-package/licence`;
    const good = licenceText();

    assert.equal((await s.call('PUT', path, { session: s.sam, body: { text: good } })).status, 403, 'a salesperson cannot put a licence file in place');
    for (const [text, pattern] of [
      ['', /empty/], ['hello', /not a licence file from the Licence Studio/], [`${good}\nmore text`, /not a licence file/], ['x'.repeat(30000), /too big/],
      [licenceText({ bind: { mode: 'device', domains: [] } }), /for Windows PCs, not for a website/], [licenceText({ trial: true, exp: 1000 }), /trial licence and it has ended/],
      [`NGOS1.${Buffer.from(JSON.stringify({ v: 1, iss: 'nextgenos', typ: 'crl' })).toString('base64url')}.${'A'.repeat(86)}`, /is not a licence/],
    ]) {
      const bad = await s.call('PUT', path, { session: s.rita, body: { text } });
      assert.equal(bad.status, 400, text.slice(0, 30));
      assert.match(bad.json.error, pattern);
    }
    assert.equal((await s.call('GET', `/api/customers/${id}/website-package`, { session: s.sam })).json.licence.state, 'none', 'a refused file is not kept');

    const ok = await s.call('PUT', path, { session: s.rita, body: { text: `${good}\n` } });
    assert.equal(ok.status, 200);
    assert.deepEqual([ok.json.licence.state, ok.json.licence.tiedTo, ok.json.licence.ends, ok.json.licence.trial, ok.json.licence.fingerprint.length], ['ok', ['luzonfresh.example'], null, false, 16]);
    assert.deepEqual(ok.json.licence.notes, [], 'the licence is for the address in the customer\'s details');
    const file = join(s.ws, 'licences', id, 'website.ngos');
    assert.equal(readFileSync(file, 'utf8'), good + '\n');
    if (process.platform !== 'win32') assert.equal(statSync(file).mode & 0o077, 0, 'only this user can read it');
    // it is not in a backup of the workspace
    const backup = await s.call('POST', '/api/backup', { session: s.admin });
    assert.equal(backup.status, 200);
    assert.ok(!listZip(readFileSync(backup.json.file)).some((n) => n.includes('licence')), 'a backup never carries a licence file');
    // a licence for another address is said, not refused (the website decides when it runs)
    const other = await s.call('PUT', path, { session: s.rita, body: { text: licenceText({ bind: { mode: 'domain', domains: ['somewhere-else.example'] } }) } });
    assert.match(other.json.licence.notes.join(' '), /tied to somewhere-else\.example, but the customer folder says the website is at luzonfresh\.example/);
    await s.call('PUT', path, { session: s.rita, body: { text: good } });

    const r = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    assert.equal(r.status, 200, JSON.stringify(r.json));
    assert.equal(r.json.results[0].licenceIncluded, true);
    assert.deepEqual(r.json.results[0].notes, []);
    const unpacked = join(s.root, 'unpacked');
    extractZip(made(s, id, 'linux'), unpacked);
    assert.equal(readFileSync(join(unpacked, `website-${id}-linux`, 'licence', 'licence.ngos'), 'utf8'), good + '\n');
    const mark = JSON.parse(readFileSync(join(unpacked, `website-${id}-linux`, 'app', '.next', 'server', '.build-info'), 'utf8'));
    assert.equal(mark.licence, sha(good).slice(0, 16));

    const trail = JSON.stringify((await s.call('GET', '/api/audit', { session: s.admin })).json);
    assert.ok(trail.includes('licence.slot') && trail.includes(ok.json.licence.fingerprint), 'who put it in place is written down, with its fingerprint');
    assert.ok(!trail.includes(good.slice(8, 60)), 'the licence text itself is never in the activity record');

    // taking it away
    assert.equal((await s.call('DELETE', path, { session: s.sam })).status, 403);
    assert.equal((await s.call('DELETE', path, { session: s.rita })).json.licence.state, 'none');
    assert.equal((await s.call('DELETE', path, { session: s.rita })).status, 404, 'nothing left to take away');
    assert.ok(!existsSync(file));
  } finally { await s.done(); }
});

test('without the website program in the kit, or with a damaged one, nothing is made and the page says what to do', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit', websites: [] });
    const id = await s.approved();
    const status = (await s.call('GET', `/api/customers/${id}/website-package`, { session: s.rita })).json;
    assert.equal(status.canMake, false);
    assert.match(status.why, /do not hold the website program/);
    assert.deepEqual(status.systems.map((x) => x.available), [false, false]);
    const none = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux', 'windows'] } });
    assert.equal(none.status, 409);
    assert.equal(none.json.code, 'no-website-program');
    assert.match(none.json.error, /website program for Linux and Windows \(website-linux\.zip, website-windows\.zip\) is not in the programs that came with the Studio/);
    assert.ok(!existsSync(join(s.ws, 'builds', id, 'website-local')), 'nothing was written');

    // only one system in the kit: the other is refused before anything is made
    await makeKit(s.root, { name: 'kit-b', websites: ['linux'] });
    await s.call('PUT', '/api/programs', { session: s.admin, body: { folder: join(s.root, 'kit-b') } });
    const both = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux', 'windows'] } });
    assert.equal(both.status, 409);
    assert.match(both.json.error, /for Windows \(website-windows\.zip\) is not in the programs folder/);
    assert.ok(!existsSync(made(s, id, 'linux')), 'a missing second system stops the first from being made too');
    assert.equal((await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } })).status, 200);

    // a changed file is caught by its fingerprint before it is used
    await makeKit(s.root, { name: 'kit-c', websites: ['linux'] });
    assert.equal((await s.call('PUT', '/api/programs', { session: s.admin, body: { folder: join(s.root, 'kit-c') } })).json.saved, true);
    const damaged = join(s.root, 'kit-c', 'website-linux.zip');
    const bytes = readFileSync(damaged);
    bytes[bytes.length - 40] ^= 0xff;
    writeFileSync(damaged, bytes);   // damaged after the folder was chosen
    const bad = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    assert.equal(bad.status, 409);
    assert.match(bad.json.error, /website-linux\.zip does not match its fingerprint, so it was damaged or changed/);
    const checked = (await s.call('GET', `/api/customers/${id}/website-package`, { session: s.rita })).json;
    assert.equal(checked.canMake, false);
    assert.equal(checked.programs.ok, false);
  } finally { await s.done(); }
});

test('the assemble step itself checks the program\'s fingerprint against the programs list, and a program that was swapped after it was read is refused', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    const dir = await makeKit(s.root, { name: 'kit', websites: ['linux'] });
    const id = await s.approved();
    const kit = await readBaseKit(dir);
    const parts = { intake: intake(), logo: null };
    const folder = join(s.root, 'out');
    const ok = await makeWebsitePackage({ id, parts, kit, os: 'linux', person: 'Rita Reviewer', folder });
    assert.equal(ok.licenceIncluded, false);
    // the file changes between reading the list and using it (same name, other content)
    const swapped = Buffer.from(readFileSync(join(dir, 'website-linux.zip')));
    swapped[swapped.length - 60] ^= 0x55;
    writeFileSync(join(dir, 'website-linux.zip'), swapped);
    await assert.rejects(() => makeWebsitePackage({ id, parts, kit, os: 'linux', person: 'Rita Reviewer', folder: join(s.root, 'out2') }), /does not match the fingerprint in the programs folder/);
    assert.ok(!existsSync(join(s.root, 'out2')) || readdirSync(join(s.root, 'out2')).length === 0, 'nothing was kept');
  } finally { await s.done(); }
});

test('a customer\'s folder that the website would not accept is refused in plain words and nothing is kept: a key in the details, a name that cannot be written into the mark', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit' });
    const fakeUrl = ['postgresql://admin', 'SuperSecret99@db.example.invalid/shop'].join(':');
    const leaky = await s.approved({ business: { ...intake().business, name: 'Leaky Shop', tagline: fakeUrl } });
    const r = await s.call('POST', `/api/customers/${leaky}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    assert.equal(r.status, 409);
    assert.match(r.json.error, /The website cannot be put together yet/);
    assert.match(r.json.error, /brand\.json contains what looks like a secret \(database URL with a password\)/);
    assert.ok(!r.json.error.includes('SuperSecret99'), 'the secret is not repeated in the message');
    assert.deepEqual(readdirSync(join(s.ws, 'builds', leaky, 'website-local', '1')), [], 'nothing was kept, not even a working folder');
    assert.equal((await s.call('GET', `/api/customers/${leaky}`, { session: s.sam })).json.customer.builds.filter((b) => b.kind === 'website-local').length, 0, 'and nothing was recorded');

    // a team member whose name the hidden mark cannot hold
    const tiny = await s.member('Z', 'reviewer', 'zed-long-password');
    const id = await s.approved({ business: { ...intake().business, name: 'Second Shop' } });
    const named = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: tiny, body: { systems: ['linux'] } });
    assert.equal(named.status, 409);
    assert.match(named.json.error, /Your name in the Studio cannot be written into the website's hidden mark/);
    const angled = await s.member('<b>Eve</b>', 'reviewer', 'eve-long-password');
    assert.match((await s.call('POST', `/api/customers/${id}/website-package/make`, { session: angled, body: { systems: ['linux'] } })).json.error, /hidden mark/);
  } finally { await s.done(); }
});

test('a customer name that tries to leave the folder is never used: in the address, and in the function', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    const dir = await makeKit(s.root, { name: 'kit' });
    for (const bad of ['..', '../evil', '..%2fevil', 'a%2fb', 'a%5cb', '%2e%2e', 'x', 'Luzon', 'a b', '%00', 'ünï']) {
      for (const [method, tail] of [['GET', ''], ['POST', '/make'], ['PUT', '/licence'], ['DELETE', '/licence']]) {
        const r = await s.call(method, `/api/customers/${bad}/website-package${tail}`, { session: s.rita, body: method === 'GET' || method === 'DELETE' ? undefined : { systems: ['linux'], text: licenceText() } });
        assert.ok([400, 404].includes(r.status), `${method} ${bad}${tail} gave ${r.status}`);
      }
    }
    assert.ok(!existsSync(join(s.ws, 'builds')) && !existsSync(join(s.ws, 'licences')), 'nothing was made anywhere');
    const kit = await readBaseKit(dir);
    for (const id of ['../evil', 'a/b', 'a\\b', '/etc', 'C:\\x', 'Luzon', '-a', 'a-', '', null]) {
      await assert.rejects(() => makeWebsitePackage({ id, parts: { intake: intake(), logo: null }, kit, os: 'linux', person: 'Rita Reviewer', folder: join(s.root, 'o') }), /cannot be used as the customer's short name/, String(id));
    }
    assert.ok(!existsSync(join(s.root, 'o')) && !existsSync(join(s.root, 'evil')));
  } finally { await s.done(); }
});

test('a customer who was not set up for a website, or whose setup is not approved yet, gets none, and the page says why', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit' });
    const draft = (await s.call('POST', '/api/customers', { session: s.sam, body: { intake: intake() } })).json.customer.id;
    const early = (await s.call('GET', `/api/customers/${draft}/website-package`, { session: s.sam })).json;
    assert.equal(early.canMake, false);
    assert.match(early.blockers[0], /Approve a setup first/);
    assert.equal((await s.call('POST', `/api/customers/${draft}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } })).status, 409);

    const noSite = await s.approved({ business: { ...intake().business, name: 'Corner Books' }, ecosystem: { website: { wanted: false, domain: '' }, android: { wanted: false, appId: '' }, aiAddon: { wanted: false } } });
    const status = (await s.call('GET', `/api/customers/${noSite}/website-package`, { session: s.sam })).json;
    assert.equal(status.canMake, false);
    assert.match(status.blockers.join(' '), /not set up to get a website/);
    const refused = await s.call('POST', `/api/customers/${noSite}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    assert.equal(refused.status, 409);
    assert.equal(refused.json.code, 'not-wanted');
  } finally { await s.done(); }
});

test('a release changed after it was approved is never used for a website', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit' });
    const id = await s.approved();
    const { chmodSync } = await import('node:fs');
    const theme = join(s.ws, 'customers', id, 'releases', '1', 'theme.json');
    chmodSync(theme, 0o644);
    writeFileSync(theme, '{"schema":1,"shape":"square"}');
    const r = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    assert.equal(r.status, 409);
    assert.equal(r.json.code, 'tampered');
    const status = (await s.call('GET', `/api/customers/${id}/website-package`, { session: s.sam })).json;
    assert.match(status.blockers[0], /does not match what was approved/);
    assert.equal(status.canMake, false);
  } finally { await s.done(); }
});

test('a kit made without licence keys is only for trying: refused unless the person says so, and marked everywhere', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit', trial: true });
    const id = await s.approved();
    assert.equal((await s.call('GET', `/api/customers/${id}/website-package`, { session: s.sam })).json.programs.trial, true);
    const refused = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    assert.equal(refused.status, 409);
    assert.equal(refused.json.code, 'trial');
    assert.match(refused.json.error, /made without the licence keys/);
    const r = await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'], allowTrial: true } });
    assert.equal(r.status, 200, JSON.stringify(r.json));
    assert.equal(r.json.results[0].trial, true);
    assert.equal(r.json.made[0].trial, true);
    extractZip(made(s, id, 'linux'), join(s.root, 'unpacked'));
    assert.match(readFileSync(join(s.root, 'unpacked', `website-${id}-linux`, 'READ ME FIRST.txt'), 'utf8'), /^\*\*\* TRIAL BUILD, NO LICENCE KEYS \*\*\*/);
    // and the pack refuses it unless it is only to try
    const pack = await s.call('POST', `/api/customers/${id}/outputs/pack`, { session: s.rita, body: {} });
    assert.equal(pack.status, 409);
    assert.match(pack.json.error, /licence keys/);
  } finally { await s.done(); }
});

test('what was made goes into the customer\'s pack with its fingerprint, and into the hand-over sheet; a package changed afterwards is refused', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit' });
    const id = await s.approved();
    const outputsBefore = (await s.call('GET', `/api/customers/${id}/outputs`, { session: s.rita })).json;
    assert.equal(outputsBefore.source, 'built-in');
    const website = (rows) => rows.find((i) => i.id === 'website');
    assert.equal(website(outputsBefore.items).status, 'missing');
    assert.match(website(outputsBefore.items).note, /has not been made yet.*"Website and app" step.*no internet needed/);

    await s.call('PUT', `/api/customers/${id}/website-package/licence`, { session: s.rita, body: { text: licenceText() } });
    for (const os of ['linux', 'windows']) assert.equal((await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: [os] } })).status, 200);
    const linux = readFileSync(made(s, id, 'linux'));
    const windows = readFileSync(made(s, id, 'windows'));

    const outputs = (await s.call('GET', `/api/customers/${id}/outputs`, { session: s.rita })).json;
    assert.equal(website(outputs.items).status, 'ready');
    assert.deepEqual(website(outputs.items).files.sort(), [`website-${id}-linux.zip`, `website-${id}-windows.zip`]);
    assert.match(website(outputs.items).note, /made for this customer on this PC \(Linux and Windows\).* and the licence file/);
    assert.ok(outputs.builds.filter((b) => b.kind === 'website-local').every((b) => b.sha256.length === 64), 'every output is in the list with its fingerprint');

    const sheetBefore = (await s.call('GET', `/api/customers/${id}/handover`, { session: s.sam })).json.sheet;
    const section = sheetBefore.sections.find((x) => x.heading === 'Your website package');
    assert.ok(section.bullets.some((b) => b.includes(sha(linux)) && b.includes('for Linux')));
    assert.ok(section.bullets.some((b) => b.includes(sha(windows)) && b.includes('for Windows')));
    assert.ok(!section.bullets.some((b) => /licence file for the website is not inside/.test(b)), 'the licence is inside, so the sheet does not say it is missing');

    const pack = await s.call('POST', `/api/customers/${id}/outputs/pack`, { session: s.rita, body: {} });
    assert.equal(pack.status, 200, JSON.stringify(pack.json));
    const got = await s.call('GET', `/api/customers/${id}/builds/1/pack.zip`, { session: s.rita });
    const names = listZip(got.buffer);
    for (const want of ['Luzon Fresh Mart/3 - Website/website-' + id + '-linux.zip', 'Luzon Fresh Mart/3 - Website/website-' + id + '-windows.zip', 'Luzon Fresh Mart/3 - Website/website-settings.env']) assert.ok(names.includes(want), want);
    extractZip(join(s.ws, 'builds', id, '1', `${id}-pack-release-1`, `${id}-pack-release-1.zip`), join(s.root, 'pack'));
    const site = join(s.root, 'pack', 'Luzon Fresh Mart', '3 - Website');
    assert.ok(readFileSync(join(site, `website-${id}-linux.zip`)).equals(linux), 'copied exactly');
    const readme = readFileSync(join(site, 'READ ME FIRST.txt'), 'utf8');
    assert.ok(readme.includes(`Fingerprint of website-${id}-linux.zip (SHA-256): ${sha(linux)}`));
    assert.match(readme, /package made for Luzon Fresh Mart/);
    assert.match(readme, /in the folder "customer" inside the website/);
    assert.match(readme, /The licence file for the website is inside/);
    assert.doesNotMatch(readme, /built into this website/, 'it no longer says the settings are built in');
    const start = readFileSync(join(s.root, 'pack', 'Luzon Fresh Mart', 'START HERE.html'), 'utf8');
    assert.ok(start.includes('Your website package') && start.includes(sha(linux)), 'the pack\'s own sheet names the same fingerprint as the Studio\'s page');

    // a package changed after it was made is never put in a pack
    writeFileSync(made(s, id, 'windows'), Buffer.concat([windows.subarray(0, windows.length - 1), Buffer.from([windows.at(-1) ^ 1])]));
    const tampered = await s.call('POST', `/api/customers/${id}/outputs/pack`, { session: s.rita, body: {} });
    assert.equal(tampered.status, 409);
    assert.equal(tampered.json.code, 'site');
    assert.match(tampered.json.error, new RegExp(`website-${id}-windows\\.zip was changed after it was made`));
    // a package that is gone is said so
    rmSync(made(s, id, 'windows'));
    assert.match((await s.call('POST', `/api/customers/${id}/outputs/pack`, { session: s.rita, body: {} })).json.error, /no longer in the Studio's folder/);
  } finally { await s.done(); }
});

test('the website package can be downloaded by those who make it, and by no one else; a made-up name finds nothing', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    await makeKit(s.root, { name: 'kit' });
    const id = await s.approved();
    await s.call('POST', `/api/customers/${id}/website-package/make`, { session: s.rita, body: { systems: ['linux'] } });
    const url = `/api/customers/${id}/website-package/1/linux/website.zip`;
    const got = await s.call('GET', url, { session: s.rita });
    assert.equal(got.status, 200);
    assert.equal(got.headers.get('content-type'), 'application/zip');
    assert.match(got.headers.get('content-disposition'), new RegExp(`filename="website-${id}-linux\\.zip"`));
    assert.ok(got.buffer.equals(readFileSync(made(s, id, 'linux'))));
    assert.equal((await s.call('GET', url, { session: s.sam })).status, 403);
    assert.equal((await s.call('GET', url, { session: s.rita, key: null })).status, 401);
    for (const bad of [`/api/customers/${id}/website-package/1/windows/website.zip`, `/api/customers/${id}/website-package/2/linux/website.zip`, `/api/customers/${id}/website-package/1/..%2f..%2fstudio/website.zip`, `/api/customers/${id}/website-package/abc/linux/website.zip`, `/api/customers/${id}/website-package/-1/linux/website.zip`]) {
      assert.equal((await s.call('GET', bad, { session: s.rita })).status, 404, bad);
    }
    rmSync(made(s, id, 'linux'));
    assert.match((await s.call('GET', url, { session: s.rita })).json.error, /no longer there/);
  } finally { await s.done(); }
});

test('the built-in kit: used when it is there, not when it is not; an administrator can point to another folder and come back; a damaged one is said so', async () => {
  const none = await boot({ kit: 'nothing-here' });
  try {
    const p = (await none.call('GET', '/api/programs', { session: none.admin })).json;
    assert.deepEqual([p.source, p.builtIn.present, p.programs.ok, p.programs.folder], ['none', false, false, ''], 'no built-in kit: the old way, the administrator chooses a folder');
    const r = (await none.call('GET', '/api/readiness', { session: none.admin })).json;
    assert.equal(r.items.find((i) => i.id === 'programs').state, 'missing');
    assert.match(r.items.find((i) => i.id === 'programs').text, /download every file into one folder/);
    assert.equal(r.items.find((i) => i.id === 'website').state, 'missing');
    assert.match(r.items.find((i) => i.id === 'website').text, /no website package can be made/);
  } finally { await none.done(); }

  const s = await boot({ kit: 'kit' });
  try {
    const dir = await makeKit(s.root, { name: 'kit' });
    const p = (await s.call('GET', '/api/programs', { session: s.rita })).json;
    assert.deepEqual([p.source, p.builtIn.present, p.builtIn.ok, p.builtIn.version, p.programs.ok, p.programs.version], ['built-in', true, true, '1.4.0', true, '1.4.0'], 'the built-in kit is used without anyone choosing a folder');
    assert.equal(p.programs.files.length, 4);
    const readiness = (await s.call('GET', '/api/readiness', { session: s.rita })).json;
    const by = Object.fromEntries(readiness.items.map((i) => [i.id, i]));
    assert.equal(by.programs.state, 'ready');
    assert.match(by.programs.text, /Release 1\.4\.0 is in place \(the programs that came with the Studio\)/);

    // an administrator points to another folder (a reviewer cannot); an empty box comes back to the built-in kit
    const other = await makeKit(s.root, { name: 'newer', websites: ['linux'] });
    assert.equal((await s.call('PUT', '/api/programs', { session: s.rita, body: { folder: other } })).status, 403);
    const chosen = await s.call('PUT', '/api/programs', { session: s.admin, body: { folder: other } });
    assert.deepEqual([chosen.json.saved, chosen.json.source, chosen.json.programs.folder, chosen.json.builtIn.present], [true, 'chosen', other, true]);
    assert.deepEqual((await s.call('GET', '/api/readiness', { session: s.rita })).json.items.find((i) => i.id === 'website').state, 'partly');
    const back = await s.call('PUT', '/api/programs', { session: s.admin, body: { folder: '' } });
    assert.deepEqual([back.json.source, back.json.programs.folder], ['built-in', dir]);
    // a folder that is not good is not kept, and the built-in kit stays in use
    const wrong = await s.call('PUT', '/api/programs', { session: s.admin, body: { folder: join(s.root, 'nowhere') } });
    assert.equal(wrong.json.saved, false);
    assert.equal((await s.call('GET', '/api/programs', { session: s.rita })).json.source, 'built-in');

    // a damaged file in the built-in kit is said so, in plain words, on the first screen
    const hub = join(dir, 'SmartRetailPOS-Hub-Setup-1.4.0.exe');
    writeFileSync(hub, Buffer.alloc(4000, 1));
    const damaged = (await s.call('GET', '/api/readiness', { session: s.rita })).json.items.find((i) => i.id === 'programs');
    assert.equal(damaged.state, 'problem');
    assert.match(damaged.text, /The programs that came with the Studio have a problem: SmartRetailPOS-Hub-Setup-1\.4\.0\.exe does not match its fingerprint.*Ask NextGenOS for a new Studio, or choose a folder of release files/);
    assert.equal((await s.call('GET', '/api/readiness', { session: s.rita })).json.items.find((i) => i.id === 'website').state, 'problem');
  } finally { await s.done(); }
});

test('the first screen says truthfully which of the three things are there: the programs, the website program, and the licence files', async () => {
  const s = await boot({ kit: 'kit' });
  try {
    const dir = await makeKit(s.root, { name: 'kit' });
    const read = async () => Object.fromEntries((await s.call('GET', '/api/readiness', { session: s.rita })).json.items.map((i) => [i.id, i]));
    let by = await read();
    assert.equal(by.website.state, 'ready');
    assert.match(by.website.text, /website program \(from release 1\.4\.0\) is in the programs, for Linux and Windows.*"Make the website package".*needs no internet/);
    assert.equal(by.licence.state, 'not-built', 'it does not claim the Studio asks the Licence Studio');
    assert.match(by.licence.text, /cannot ask the Licence Studio for a licence yet; that is planned and is not in this version/);
    assert.match(by.licence.text, /There are no customers yet/);
    assert.match(by['build-service'].text, /Android app.*built on GitHub, not on this PC.*The website does not need this/);
    assert.doesNotMatch(JSON.stringify(by), /build the website on GitHub|website and app have the customer's settings built/);

    const a = await s.approved();
    const b = await s.approved({ business: { ...intake().business, name: 'Second Shop' } });
    by = await read();
    assert.match(by.licence.text, /Licence files in place: 0 of 2 customers/);
    await s.call('PUT', `/api/customers/${a}/website-package/licence`, { session: s.rita, body: { text: licenceText() } });
    assert.match((await read()).licence.text, /Licence files in place: 1 of 2 customers/);
    void b;

    // a trial kit is said to be only for trying
    await makeKit(s.root, { name: 'trial-kit', trial: true });
    await s.call('PUT', '/api/programs', { session: s.admin, body: { folder: join(s.root, 'trial-kit') } });
    by = await read();
    assert.equal(by.website.state, 'trial');
    assert.match(by.website.text, /trial release made without licence keys.*never given to a customer/);
    void dir;
  } finally { await s.done(); }
});

test('the customer\'s folder is the very one the pack and the build service use: brand.json and the settings file, the logo in assets, no setup.json, a too-light second colour left out', () => {
  const parts = { intake: intake({ look: { primaryColor: '#0a7d4b', accentColor: '#ffff00', style: 'friendly' } }), logo: { ext: 'png', bytes: Buffer.from('x') } };
  const files = customerFolderFiles(parts);
  assert.deepEqual(files.map((f) => f.name), ['brand.json', 'website-settings.env', 'assets/logo.png']);
  const brand = JSON.parse(files[0].data);
  assert.equal(brand.accentColor, undefined, 'white words cannot be read on a light second colour, so the website would refuse it; the shop program leaves it out too');
  assert.equal(brand.primaryColor, '#0a7d4b');
  assert.equal(brand.logo, 'logo.png');
  assert.match(files[1].data, /NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart\r\nNEXT_PUBLIC_SITE_URL=https:\/\/luzonfresh\.example\r\nNEXT_PUBLIC_COUNTRY=PH/);
  const noLogo = customerFolderFiles({ intake: intake(), logo: null });
  assert.deepEqual(noLogo.map((f) => f.name), ['brand.json', 'website-settings.env']);
  assert.equal(JSON.parse(noLogo[0].data).logo, undefined);
  // another customer, another country, another trade: another folder (nothing is fixed in code)
  const other = customerFolderFiles({ intake: intake({ business: { name: 'Gilded Page Books', country: 'GB', industry: 'library', contact: { phone: '+44 20 7946 0000', email: 'hello@gilded.example', address: 'Leeds, England' } }, ecosystem: { website: { wanted: true, domain: 'gilded.example' }, android: { wanted: false, appId: '' }, aiAddon: { wanted: false } } }), logo: null });
  const brand2 = JSON.parse(other[0].data);
  assert.deepEqual([brand2.name, brand2.country, brand2.industry], ['Gilded Page Books', 'GB', 'library']);
  assert.match(other[1].data, /NEXT_PUBLIC_SITE_NAME=Gilded Page Books/);
});

test('what a licence says about itself is put in plain terms, without claiming to have checked the signature', () => {
  const now = new Date('2026-10-07T00:00:00Z');
  assert.deepEqual(describeLicence(null), { state: 'none', problems: [], notes: [] });
  const slot = (text) => ({ text, file: '/x' });
  const ok = describeLicence(slot(licenceText({ exp: Math.floor(Date.parse('2027-01-31T00:00:00Z') / 1000) })), { siteUrl: 'https://luzonfresh.example', now });
  assert.deepEqual([ok.state, ok.tiedTo, ok.ends, ok.trial, ok.notes], ['ok', ['luzonfresh.example'], '2027-01-31', false, []]);
  assert.equal(describeLicence(slot(licenceText({ trial: true })), { now }).trial, true);
  assert.match(describeLicence(slot(licenceText({ trial: true })), { now }).notes.join(' '), /TRIAL licence/);
  const bad = describeLicence(slot('hello'), { now });
  assert.deepEqual([bad.state, bad.problems.length], ['problem', 1]);
  assert.equal(describeLicence(slot(licenceText({ bind: { mode: 'device', domains: [] } })), { now }).state, 'problem');
  assert.deepEqual(describeLicence(slot(licenceText({ bind: { mode: 'domain', domains: ['a\u0000b.example', 7] } })), { now }).tiedTo, ['a?b.example', '7'], 'what the licence says is shown as plain text only');
});

test('the packages made on this PC count as if they were in the programs folder, and a record that does not match its file is named', async () => {
  const root = mkdtempSync(join(tmpdir(), 'studio-web-unit-'));
  try {
    const dir = await makeKit(root, { name: 'kit' });
    const kit = await readBaseKit(dir);
    assert.deepEqual(websiteSystems(kit).map((x) => [x.id, !!x.file]), [['linux', true], ['windows', true]]);
    const folder = join(root, 'made');
    mkdirSync(folder);
    const bytes = Buffer.from('a website package');
    writeFileSync(join(folder, 'website-luzon-linux.zip'), bytes);
    const record = { kind: 'website-local', release: 1, os: 'linux', file: 'website-luzon-linux.zip', bytes: bytes.length, sha256: sha(bytes), trial: false, licenceIncluded: true };
    const withIt = await withLocalWebsites(kit, { builds: [record, { kind: 'pack', release: 1 }, { ...record, release: 2, os: 'windows' }], folderOf: () => folder, release: 1, customerId: 'luzon', verify: true });
    const site = withIt.files.filter((f) => f.role === 'website');
    assert.deepEqual(site.map((f) => [f.name, f.os, f.kit, f.assembled, f.licenceIncluded]), [['website-luzon-linux.zip', 'linux', 'luzon', true, true]], 'only this release, only this customer');
    assert.deepEqual(withIt.siteProblems, []);
    assert.equal(withIt.files.filter((f) => f.role === 'website-generic').length, 2, 'the programs themselves are untouched');
    // another customer's file name is never used
    const otherName = await withLocalWebsites(kit, { builds: [{ ...record, file: 'website-someone-else-linux.zip' }], folderOf: () => folder, release: 1, customerId: 'luzon' });
    assert.match(otherName.siteProblems[0], /website-luzon-linux\.zip is not the file that was recorded/);
    // a file of another size, or changed in place, is named
    writeFileSync(join(folder, 'website-luzon-linux.zip'), 'a different package, longer');
    assert.match((await withLocalWebsites(kit, { builds: [record], folderOf: () => folder, release: 1, customerId: 'luzon' })).siteProblems[0], /is not the file that was made \(its size is different\)/);
    writeFileSync(join(folder, 'website-luzon-linux.zip'), Buffer.from('a website packagf'));
    assert.deepEqual((await withLocalWebsites(kit, { builds: [record], folderOf: () => folder, release: 1, customerId: 'luzon' })).siteProblems, [], 'a quick look checks the size');
    assert.match((await withLocalWebsites(kit, { builds: [record], folderOf: () => folder, release: 1, customerId: 'luzon', verify: true })).siteProblems[0], /was changed after it was made \(its fingerprint is different\)/);
    rmSync(join(folder, 'website-luzon-linux.zip'));
    assert.match((await withLocalWebsites(kit, { builds: [record], folderOf: () => folder, release: 1, customerId: 'luzon' })).siteProblems[0], /no longer in the Studio's folder.*Make the website package again/);
    // a made one takes the place of one fetched from the build service for the same system
    const service = { ...kit, files: [...kit.files, { name: 'website-luzon-linux.zip', role: 'website', os: 'linux', arch: 'x64', kit: 'luzon', bytes: 1, sha256: 'f'.repeat(64), path: '/elsewhere' }] };
    writeFileSync(join(folder, 'website-luzon-linux.zip'), bytes);
    const merged = await withLocalWebsites(service, { builds: [record], folderOf: () => folder, release: 1, customerId: 'luzon' });
    assert.deepEqual(merged.files.filter((f) => f.role === 'website').map((f) => f.path), [join(folder, 'website-luzon-linux.zip')]);
  } finally { rmSync(root, { recursive: true, force: true }); }
});
