// Assembling a customer's website: THE website (the same for every customer) + the customer's folder + the customer's licence file become that customer's ready-to-run folder and zip.
// It is a copy of files and checks: no build, no network. These tests make a stand-in for THE website (the real one is built by scripts/make-website-package.mjs), use the website's real rules
// file (the one that travels inside the package), and look at what comes out. The package audit (scripts/audit-package.mjs) is run on the result.
import test from 'node:test';
import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import { existsSync, mkdirSync, mkdtempSync, readFileSync, readdirSync, rmSync, statSync, symlinkSync, writeFileSync, copyFileSync, chmodSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { dirname, join } from 'node:path';
import { spawnSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { makeZip, listZip } from '../lib/zip.mjs';
import { AssembleError, MARK_FILE, assembleWebsite, checkCustomerName, checkPerson, inspectLicence } from '../lib/website-assemble.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const repo = join(here, '..', '..', '..');
const RULES = join(repo, 'apps', 'storefront-web-mobile', 'src', 'lib', 'customer', 'rules.mjs');
const AUDIT = join(repo, 'scripts', 'audit-package.mjs');
const tmp = () => mkdtempSync(join(tmpdir(), 'assemble-test-'));
const clean = (...dirs) => { for (const d of dirs) rmSync(d, { recursive: true, force: true }); };
const put = (root, files) => { for (const [name, content] of Object.entries(files)) { const full = join(root, ...name.split('/')); mkdirSync(dirname(full), { recursive: true }); writeFileSync(full, content); } return root; };
const PNG = Buffer.concat([Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]), Buffer.alloc(40)]);
const PACKS = { countries: ['PH', 'GB', 'IN'], industries: ['retail', 'generic', 'restaurant'] };
const b64 = (o) => Buffer.from(JSON.stringify(o)).toString('base64url');
/** A licence-shaped file (the signature is not checked here: the website does that when it runs). */
const licenceText = (claims = {}) => `NGOS1.${b64({ v: 1, iss: 'nextgenos', typ: 'lic', kid: 'k1', lid: 'L-1', exp: null, trial: false, bind: { mode: 'domain', domains: ['shop.luzon.example'] }, ...claims })}.${'A'.repeat(86)}`;
const sha = (buf) => createHash('sha256').update(buf).digest('hex');

/** A stand-in for THE website: what the assemble step looks at (its description, its rules file, its start file), without the libraries and the build. */
function genericFolder(root, { os = 'linux', extra = {}, info = {} } = {}) {
  const dir = join(root, `website-${os}`);
  put(dir, {
    'PACKAGE-INFO.json': JSON.stringify({ schema: 1, product: 'Smart Retail POS website', generic: true, version: '1.2.3', os, arch: 'x64', builtAt: '2026-01-01T00:00:00.000Z', node: 'v22.22.0', licenceKeysBuiltIn: 1, trialWithoutLicenceKeys: false, customerFolder: 'customer', ...info }, null, 2),
    'READ ME FIRST.txt': 'Smart Retail POS: the website\r\n===\r\nThe steps are the same for every shop.\r\n',
    'start-website.js': '// starts the website\n',
    'start-website.sh': '#!/bin/sh\necho start\n',
    'app/server.js': '// the server\n',
    'app/.next/BUILD_ID': 'abc',
    'app/.next/server/app/page.js': 'module.exports = {};',
    'licence/READ ME.txt': 'Put the licence file here.',
    'node/LICENSE': 'Node.js licence',
    ...extra,
  });
  copyFileSync(RULES, join(dir, 'customer-rules.mjs'));
  if (process.platform !== 'win32') for (const f of ['start-website.sh']) chmodSync(join(dir, f), 0o755);
  return dir;
}
function genericZip(root, folder) {
  const entries = [];
  const walk = (d, prefix) => { for (const e of readdirSync(d, { withFileTypes: true })) { if (e.isDirectory()) walk(join(d, e.name), `${prefix}/${e.name}`); else entries.push({ name: `${prefix}/${e.name}`, data: readFileSync(join(d, e.name)), mode: e.name.endsWith('.sh') ? 0o755 : 0o644 }); } };
  const top = folder.split(/[\\/]/).pop();
  walk(folder, top);
  const zip = join(root, `${top}.zip`);
  writeFileSync(zip, makeZip(entries));
  return zip;
}
const LUZON = {
  'brand.json': JSON.stringify({ schema: 1, name: 'Luzon Fresh Mart', tagline: 'Fresh every morning', primaryColor: '#0b6e4f', country: 'PH', industry: 'retail', language: 'en-PH', logo: 'logo.png', contact: { email: 'hello@luzon.example', address: 'Rizal Ave, Quezon City, Philippines' }, storefront: { siteUrl: 'https://shop.luzon.example' } }),
};
function customerFolder(root, files = LUZON, logo = true) {
  const dir = join(root, 'customer-in');
  put(dir, files);
  if (logo) { mkdirSync(join(dir, 'assets'), { recursive: true }); writeFileSync(join(dir, 'assets', 'logo.png'), PNG); }
  return dir;
}
function licenceFile(root, text = licenceText()) { const f = join(root, 'licence.ngos'); writeFileSync(f, text + '\n'); return f; }
const base = (root, over = {}) => ({
  genericPackage: over.genericPackage ?? genericFolder(root), customerFolder: over.customerFolder ?? customerFolder(root), licenceFile: 'licenceFile' in over ? over.licenceFile : licenceFile(root),
  customer: 'luzon-fresh-mart', person: 'Asha Admin', out: join(root, 'out'), packs: PACKS, now: new Date('2026-10-07T09:30:00Z'), ...over,
});
const refused = async (opts, pattern) => {
  await assert.rejects(() => assembleWebsite(opts), (e) => { assert.ok(e instanceof AssembleError, `an AssembleError, not ${e?.stack}`); assert.match(e.message, pattern); return true; });
  assert.deepEqual(existsSync(opts.out) ? readdirSync(opts.out) : [], [], 'nothing was written');
};

test('a good folder and a licence give the customer\'s ready-to-run website: the program, the customer folder, the licence, the mark', async () => {
  const root = tmp();
  try {
    const r = await assembleWebsite(base(root));
    const at = (f) => join(r.folder, ...f.split('/'));
    assert.equal(r.name, 'website-luzon-fresh-mart-linux');
    assert.deepEqual(readdirSync(join(root, 'out')).sort(), ['website-luzon-fresh-mart-linux', 'website-luzon-fresh-mart-linux.zip']);
    // the program is the same as it was: every file of THE website is there, byte for byte
    for (const f of ['start-website.js', 'app/server.js', 'app/.next/BUILD_ID', 'customer-rules.mjs', 'node/LICENSE']) assert.ok(readFileSync(at(f)).equals(readFileSync(join(root, 'website-linux', ...f.split('/')))), f);
    // the customer's folder, as it was given
    assert.deepEqual(readdirSync(at('customer')).sort(), ['assets', 'brand.json']);
    assert.equal(readFileSync(at('customer/brand.json'), 'utf8'), LUZON['brand.json']);
    assert.ok(readFileSync(at('customer/assets/logo.png')).equals(PNG));
    // the licence, where the website reads it
    assert.equal(readFileSync(at('licence/licence.ngos'), 'utf8'), licenceText() + '\n');
    assert.ok(existsSync(at('licence/READ ME.txt')));
    // who it is for
    const info = JSON.parse(readFileSync(at('PACKAGE-INFO.json'), 'utf8'));
    assert.deepEqual([info.generic, info.customer, info.name, info.os, info.version, info.licenceIncluded, info.assembledAt], [false, 'luzon-fresh-mart', 'Luzon Fresh Mart', 'linux', '1.2.3', true, '2026-10-07T09:30:00.000Z']);
    const readme = readFileSync(at('READ ME FIRST.txt'), 'utf8');
    assert.match(readme, /^Luzon Fresh Mart: the website\r\n/);
    assert.match(readme, /customer "luzon-fresh-mart"/);
    assert.match(readme, /The steps are the same for every shop\./);
    // the hidden mark: customer, person, time (and which licence)
    const mark = JSON.parse(readFileSync(at(MARK_FILE), 'utf8'));
    assert.deepEqual(mark, { schema: 1, customer: 'luzon-fresh-mart', person: 'Asha Admin', madeAt: '2026-10-07T09:30:00.000Z', licence: sha(licenceText()).slice(0, 16), program: '1.2.3' });
    assert.deepEqual(r.mark, mark);
    assert.equal(r.settings.siteName, 'Luzon Fresh Mart');
    assert.deepEqual(r.notes, []);
    // the zip: one folder at the top, the program can still be run
    const names = listZip(readFileSync(r.zip));
    assert.ok(names.every((n) => n.startsWith('website-luzon-fresh-mart-linux/')));
    for (const want of ['start-website.sh', 'customer/brand.json', 'customer/assets/logo.png', 'licence/licence.ngos', MARK_FILE, 'PACKAGE-INFO.json']) assert.ok(names.includes(`website-luzon-fresh-mart-linux/${want}`), want);
    assert.equal(r.sha256, sha(readFileSync(r.zip)));
    if (process.platform !== 'win32') assert.ok(statSync(at('start-website.sh')).mode & 0o100, 'the start file can still be run');
    // the package audit, as the release gate runs it: a customer's website is accepted with its own licence file, and the folder is clean
    const ok = spawnSync(process.execPath, [AUDIT, r.folder, r.zip, '--node-app', '--customer-package'], { encoding: 'utf8' });
    assert.equal(ok.status, 0, ok.stdout + ok.stderr);
    const strict = spawnSync(process.execPath, [AUDIT, r.folder, '--node-app'], { encoding: 'utf8' });
    assert.equal(strict.status, 1, 'without --customer-package a licence file is still refused');
    assert.match(strict.stdout, /licence\.ngos\s+licence file/);
  } finally { clean(root); }
});

test('the same result from the zip as from the folder, and a zip with the wrong fingerprint is refused', async () => {
  const root = tmp();
  try {
    const folder = genericFolder(root);
    const zip = genericZip(root, folder);
    const fromZip = await assembleWebsite({ ...base(root, { genericPackage: zip, expectedSha256: sha(readFileSync(zip)) }), out: join(root, 'out-zip') });
    const fromFolder = await assembleWebsite({ ...base(root, { genericPackage: folder }), out: join(root, 'out-folder') });
    const files = (dir) => (function walk(d, p = '') { return readdirSync(d, { withFileTypes: true }).flatMap((e) => (e.isDirectory() ? walk(join(d, e.name), `${p}${e.name}/`) : [`${p}${e.name}`])); })(dir).sort();
    assert.deepEqual(files(fromZip.folder), files(fromFolder.folder));
    if (process.platform !== 'win32') assert.ok(statSync(join(fromZip.folder, 'start-website.sh')).mode & 0o100, 'the right to run survives the zip');
    await refused({ ...base(root, { genericPackage: zip, expectedSha256: 'f'.repeat(64) }), out: join(root, 'out-bad') }, /does not match the fingerprint/);
    // assembling again (the same customer) replaces the earlier result, whole
    const again = await assembleWebsite({ ...base(root, { genericPackage: zip }), out: join(root, 'out-zip'), person: 'Someone Else' });
    assert.equal(JSON.parse(readFileSync(join(again.folder, MARK_FILE), 'utf8')).person, 'Someone Else');
  } finally { clean(root); }
});

test('a Windows website is assembled the same way and is named for its system', async () => {
  const root = tmp();
  try {
    const r = await assembleWebsite(base(root, { genericPackage: genericFolder(root, { os: 'windows', extra: { 'Start Website.exe': 'MZ' } }) }));
    assert.equal(r.name, 'website-luzon-fresh-mart-windows');
    assert.ok(existsSync(join(r.folder, 'Start Website.exe')));
  } finally { clean(root); }
});

test('the licence file is needed: without it nothing is made, unless it was said that it comes later', async () => {
  const root = tmp();
  try {
    await refused(base(root, { licenceFile: null }), /licence file is missing/);
    await refused(base(root, { licenceFile: join(root, 'nothing.ngos') }), /was not found/);
    for (const [text, pattern] of [['', /empty/], ['hello', /not a licence file from the Licence Studio/], ['NGOS1.abc.def', /not a licence file/], [licenceText().replace('NGOS1', 'NGOS2'), /not a licence file/],
      [`NGOS1.${b64({ v: 1, iss: 'someone-else', typ: 'lic' })}.${'A'.repeat(86)}`, /is not a licence/], [`NGOS1.${b64({ v: 1, iss: 'nextgenos', typ: 'crl' })}.${'A'.repeat(86)}`, /is not a licence/],
      [licenceText({ bind: { mode: 'device', domains: [] } }), /for Windows PCs, not for a website/], [licenceText({ trial: true, exp: 1000 }), /trial licence and it has ended/], ['x'.repeat(30000), /too big/]]) {
      await refused(base(root, { licenceFile: licenceFile(root, text) }), pattern);
    }
    const later = await assembleWebsite(base(root, { licenceFile: null, allowNoLicence: true }));
    assert.ok(!existsSync(join(later.folder, 'licence', 'licence.ngos')));
    assert.match(later.notes.join(' '), /no licence file yet/);
    assert.equal(JSON.parse(readFileSync(join(later.folder, 'PACKAGE-INFO.json'), 'utf8')).licenceIncluded, false);
    assert.match(readFileSync(join(later.folder, 'READ ME FIRST.txt'), 'utf8'), /EMPTY: the licence file is not here yet/);
    assert.equal(later.mark.licence, null);
  } finally { clean(root); }
});

test('a licence that looks wrong for this customer is said so (the website decides when it runs): another web address, a paid licence that has ended, a trial', () => {
  const now = new Date('2026-10-07T00:00:00Z');
  assert.deepEqual(inspectLicence(licenceText(), { siteUrl: 'https://shop.luzon.example', now }).notes, []);
  assert.match(inspectLicence(licenceText(), { siteUrl: 'https://elsewhere.example', now }).notes.join(' '), /tied to shop\.luzon\.example, but the customer folder says the website is at elsewhere\.example/);
  assert.deepEqual(inspectLicence(licenceText({ bind: { mode: 'domain', domains: ['*.luzon.example'] } }), { siteUrl: 'https://shop.luzon.example', now }).notes, []);
  assert.match(inspectLicence(licenceText({ exp: 1000 }), { now }).notes.join(' '), /keeps working with a banner/);
  assert.match(inspectLicence(licenceText({ trial: true }), { now }).notes.join(' '), /TRIAL licence/);
  assert.deepEqual(inspectLicence(licenceText({ exp: 1000 }), { now }).problems, []);
});

test('a customer folder that holds anything it should not is refused, and nothing is made: an environment file, source, a map, a database, a key, a licence, a script, a folder, a link', async () => {
  const root = tmp();
  try {
    const cases = [
      ['.env', 'DATABASE_URL=x', /\.env is an environment file/],
      ['.env.local', 'A=1', /an environment file/],
      ['page.tsx', 'export default 1', /page\.tsx is a program or source code/],
      ['app.ts', 'export {}', /source code/],
      ['bundle.js.map', '{}', /source map/],
      ['shop.db', 'x', /database/],
      ['server.pem', 'x', /key or a certificate/],
      ['licence.ngos', 'NGOS1.a.b', /licence file/],
      ['run.sh', 'echo hi', /program or source code/],
      ['notes.txt', 'hello', /not a file a customer folder may hold/],
      ['secrets/readme.txt', 'x', /secrets\/ is a folder/],
      ['assets/page.tsx', 'x', /assets\/page\.tsx is a program or source code/],
      ['assets/.env', 'A=1', /assets\/\.env is an environment file/],
      ['assets/fake.png', 'this is text', /assets\/fake\.png is not a real PNG picture/],
      ['assets/evil.svg', '<svg xmlns="http://www.w3.org/2000/svg"><script>alert(1)</script></svg>', /carries a script/],
      ['assets/inner/logo.png', PNG, /assets\/inner is not a plain file/],
    ];
    for (const [name, content, pattern] of cases) {
      const dir = customerFolder(root);
      put(dir, { [name]: content });
      await refused(base(root, { customerFolder: dir }), pattern);
      rmSync(dir, { recursive: true, force: true });
    }
    if (process.platform !== 'win32') {
      const dir = customerFolder(root);
      symlinkSync('/etc/passwd', join(dir, 'brand-copy.json'));
      await refused(base(root, { customerFolder: dir }), /brand-copy\.json is a link/);
      rmSync(dir, { recursive: true, force: true });
      const linked = join(root, 'linked');
      symlinkSync(customerFolder(root), linked);
      await refused(base(root, { customerFolder: linked }), /is not a folder \(a link is not accepted\)/);
    }
    await refused(base(root, { customerFolder: join(root, 'no-such-folder') }), /was not found/);
  } finally { clean(root); }
});

test('a secret in a customer\'s settings is refused, wherever in the folder it is', async () => {
  const root = tmp();
  try {
    const fakeUrl = ['postgresql://admin', 'SuperSecret99@db.example.invalid/shop'].join(':');
    const fakeKey = ['-----BEGIN', 'PRIVATE KEY-----'].join(' ');
    for (const [files, pattern] of [
      [{ 'brand.json': JSON.stringify({ schema: 1, name: 'Shop', tagline: fakeUrl }) }, /brand\.json contains what looks like a secret \(database URL with a password\)/],
      [{ 'brand.json': JSON.stringify({ schema: 1, name: 'Shop' }), 'website-settings.env': `NEXT_PUBLIC_SITE_NAME=Shop\nNEXT_PUBLIC_FIREBASE_API_KEY=AIza${'x'.repeat(35)}\n` }, /website-settings\.env contains what looks like a secret \(Google API key\)/],
      [{ 'brand.json': JSON.stringify({ schema: 1, name: 'Shop' }), 'setup.json': fakeKey }, /setup\.json contains what looks like a secret \(private key\)/],
      [{ 'brand.json': JSON.stringify({ schema: 1, name: 'Shop' }), 'website-settings.env': 'NEXT_PUBLIC_SITE_NAME=Shop\nDATABASE_URL=postgres://user:secret@host/shop\n' }, /DATABASE_URL is not a public setting/],
    ]) {
      const dir = customerFolder(root, files, false);
      await refused(base(root, { customerFolder: dir }), pattern);
      rmSync(dir, { recursive: true, force: true });
    }
  } finally { clean(root); }
});

test('the website\'s own rules are applied: a value it would leave out is refused now, while a person can put it right', async () => {
  const root = tmp();
  try {
    for (const [brand, pattern] of [
      [{ name: 'Shop', country: 'ZZ' }, /there is no country pack for ZZ/],
      [{ name: 'Shop', industry: 'spaceship' }, /no industry pack called spaceship/],
      [{ name: 'Shop', primaryColor: '#ffff00' }, /main colour is too light/],
      [{ name: 'Shop', storefront: { siteUrl: 'ftp://x.example' } }, /the web address/],
      [{ name: 'Shop', logo: 'missing.png' }, /names the logo missing\.png/],
      [{ country: 'PH' }, /gives no shop name/],
      [{ name: '<b>Shop</b>' }, /character that is not allowed/],
    ]) {
      const dir = customerFolder(root, { 'brand.json': JSON.stringify({ schema: 1, ...brand }) }, false);
      await refused(base(root, { customerFolder: dir }), pattern);
      rmSync(dir, { recursive: true, force: true });
    }
    await refused(base(root, { customerFolder: customerFolder(root, { 'brand.json': '{ not json' }, false) }), /brand\.json cannot be read/);
  } finally { clean(root); }
});

test('a name that tries to leave the folder is refused: the customer\'s short name, the person, and the names inside the program zip', async () => {
  const root = tmp();
  try {
    for (const bad of ['../evil', '..', 'a/b', 'a\\b', '/etc', 'C:\\x', 'Luzon', 'x', '-a', 'a-', 'a b', 'a.b', '', null, undefined, 'a'.repeat(43), 'ünï', 'a\0b', 'a\nb']) {
      assert.throws(() => checkCustomerName(bad), AssembleError, String(bad));
      await refused(base(root, { customer: bad }), /cannot be used as the customer's short name/);
    }
    for (const good of ['luzon-fresh-mart', 'ab', 'shop2', 'a'.repeat(41)]) assert.equal(checkCustomerName(good), good);
    for (const bad of ['', 'x', 'a'.repeat(81), 'a\nb', '<b>x</b>']) assert.throws(() => checkPerson(bad), AssembleError, String(bad));
    await refused(base(root, { person: '' }), /Say who is making this website/);
    // a zip of the program whose names leave the folder (made by hand: the writer itself refuses such a name)
    const hostile = '../../../../../evil.txt';
    const placeholder = 'q'.repeat(hostile.length);
    const evil = join(root, 'evil.zip');
    writeFileSync(evil, Buffer.from(Buffer.from(makeZip([{ name: 'website-linux/PACKAGE-INFO.json', data: '{}' }, { name: placeholder, data: 'payload' }])).toString('latin1').replaceAll(placeholder, hostile), 'latin1'));
    await refused(base(root, { genericPackage: evil }), /could not be opened: A file in the zip has a name that is not allowed/);
    assert.ok(!existsSync(join(root, 'evil.txt')) && !existsSync(join(root, 'out', 'evil.txt')));
  } finally { clean(root); }
});

test('only THE website is accepted as the program: not one that already has a customer, a customer folder or a licence, or one without the rules file', async () => {
  const root = tmp();
  try {
    const attempts = [
      [() => genericFolder(root, { info: { generic: false, customer: 'other-shop', name: 'Other Shop' } }), /not the generic one/],
      [() => genericFolder(root, { info: { publicSettings: { NEXT_PUBLIC_SITE_NAME: 'Other Shop' } } }), /not the generic one/],
      [() => genericFolder(root, { extra: { 'customer/brand.json': '{}' } }), /already holds a customer folder/],
      [() => genericFolder(root, { extra: { 'licence/licence.ngos': 'x' } }), /already holds a customer folder or a licence file/],
      [() => genericFolder(root, { info: { os: 'windows' } }), /another system than its folder name/],
    ];
    for (const [make, pattern] of attempts) {
      const folder = make();
      await refused(base(root, { genericPackage: folder }), pattern);
      rmSync(folder, { recursive: true, force: true });
    }
    const old = genericFolder(root);
    rmSync(join(old, 'customer-rules.mjs'));
    await refused(base(root, { genericPackage: old }), /too old to be assembled/);
    writeFileSync(join(old, 'customer-rules.mjs'), 'export const a = 1;\n');
    await refused(base(root, { genericPackage: old }), /does not have readCustomerFolder/);
    rmSync(old, { recursive: true, force: true });
    if (process.platform !== 'win32') {
      const linked = genericFolder(root);
      symlinkSync('/etc/hostname', join(linked, 'app', 'taken.txt'));
      await refused(base(root, { genericPackage: linked }), /holds a link \(app\/taken\.txt\)/);
      rmSync(linked, { recursive: true, force: true });
    }
    const odd = join(root, 'something-else');
    put(odd, { 'PACKAGE-INFO.json': '{}' });
    await refused(base(root, { genericPackage: odd }), /is not THE website/);
    await refused(base(root, { genericPackage: join(root, 'missing.zip') }), /was not found/);
  } finally { clean(root); }
});

test('the command line makes the same website and says in plain words what is wrong', () => {
  const root = tmp();
  try {
    const b = base(root);
    const cli = join(repo, 'scripts', 'assemble-website.mjs');
    const run = (args) => spawnSync(process.execPath, [cli, ...args], { encoding: 'utf8', timeout: 60000 });
    const ok = run(['--program', b.genericPackage, '--customer-folder', b.customerFolder, '--licence', b.licenceFile, '--customer', 'luzon-fresh-mart', '--person', 'Asha Admin', '--out', b.out, '--audit']);
    assert.equal(ok.status, 0, ok.stdout + ok.stderr);
    assert.match(ok.stdout, /website-luzon-fresh-mart-linux\.zip/);
    assert.match(ok.stdout, /audit passed/);
    assert.ok(existsSync(join(b.out, 'website-luzon-fresh-mart-linux', 'licence', 'licence.ngos')));
    const bad = run(['--program', b.genericPackage, '--customer-folder', b.customerFolder, '--customer', 'luzon-fresh-mart', '--person', 'A B', '--out', join(root, 'out2')]);
    assert.equal(bad.status, 1);
    assert.match(bad.stderr, /licence file is missing/);
    // the older way, as the release workflow and the build service give a customer: a settings file, or a brand kit
    writeFileSync(join(root, 'second.env'), 'NEXT_PUBLIC_SITE_NAME=Second Shop\r\nNEXT_PUBLIC_COUNTRY=GB\r\n');
    const env = run(['--program', b.genericPackage, '--settings', join(root, 'second.env'), '--customer', 'second-shop', '--no-licence', '--person', 'the release workflow', '--out', join(root, 'out-env'), '--audit']);
    assert.equal(env.status, 0, env.stdout + env.stderr);
    assert.deepEqual(readdirSync(join(root, 'out-env', 'website-second-shop-linux', 'customer')), ['website-settings.env']);
    const kit = run(['--program', b.genericPackage, '--kit', 'example-shop', '--customer', 'example-shop', '--no-licence', '--person', 'the release workflow', '--out', join(root, 'out-kit'), '--audit']);
    assert.equal(kit.status, 0, kit.stdout + kit.stderr);
    assert.deepEqual(readdirSync(join(root, 'out-kit', 'website-example-shop-linux', 'customer')).sort(), ['assets', 'brand.json', 'website-settings.env']);
    writeFileSync(join(root, 'private.env'), 'NEXT_PUBLIC_SITE_NAME=Shop\nDATABASE_URL=postgres://user:secret@host/shop\n');
    const priv = run(['--program', b.genericPackage, '--settings', join(root, 'private.env'), '--customer', 'third-shop', '--no-licence', '--person', 'A B', '--out', join(root, 'out-private')]);
    assert.equal(priv.status, 1);
    assert.match(priv.stderr, /DATABASE_URL is not a public setting/);
    assert.ok(!existsSync(join(root, 'out-private')));
    assert.equal(run([]).status, 2);
    assert.equal(run(['--program', b.genericPackage, '--customer-folder', b.customerFolder, '--customer', '../x', '--person', 'A B', '--licence', b.licenceFile, '--out', join(root, 'out3')]).status, 1);
    assert.ok(!existsSync(join(root, 'out3')) || readdirSync(join(root, 'out3')).length === 0);
  } finally { clean(root); }
});
