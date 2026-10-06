// scripts/customer-build/validate-inputs.mjs: what the customer-build workflow accepts from the Setup Studio and what it refuses (docs/CUSTOMER-BUILDS.md).
// The bundle inputs.zip is data from outside this repository: names, sizes, the zip itself and every value in it are read as untrusted.
import test from 'node:test';
import assert from 'node:assert/strict';
import { existsSync, mkdtempSync, readFileSync, readdirSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { dirname, join } from 'node:path';
import { spawnSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { deflateRawSync, crc32 } from 'node:zlib';
import { makeZip, writeZipFile } from '../../tools/setup-studio/lib/zip.mjs';
import {
  checkBuildJson, checkBuildNumber, checkCustomerName, checkResultsRepo, InputsError, licenceKeysState, readInputsZip, validateInputs, versionFor,
} from '../customer-build/validate-inputs.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const script = join(here, '..', 'customer-build', 'validate-inputs.mjs');
const tmp = () => mkdtempSync(join(tmpdir(), 'cb-validate-'));

// A real (1 pixel) PNG picture.
const PNG = Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==', 'base64');
const BRAND = { schema: 1, name: 'Acme Test Shop', primaryColor: '#0f6cbd', logo: 'logo.png', country: 'GB', industry: 'retail', storefront: { siteUrl: 'https://shop.example.com' }, android: { appId: 'com.example.acme', storefrontUrl: 'https://shop.example.com' } };
const SETTINGS = 'NEXT_PUBLIC_SITE_NAME=Acme Test Shop\nNEXT_PUBLIC_SITE_URL=https://shop.example.com\nNEXT_PUBLIC_COUNTRY=GB\nNEXT_PUBLIC_INDUSTRY=retail\n';
const buildJson = (over = {}) => ({ schema: 1, customer: 'acme-test', build: 3, studioVersion: '1.0.0', parts: { website: true, android: true }, ...over });

/** The four files, each changeable; `drop` takes one away. */
function bundle({ build = buildJson(), brand = BRAND, settings = SETTINGS, logo = PNG, drop = [], extra = [] } = {}) {
  const files = {
    'build.json': Buffer.from(JSON.stringify(build)),
    'brand.json': Buffer.from(typeof brand === 'string' ? brand : JSON.stringify(brand)),
    'website-settings.env': Buffer.from(settings),
    'logo.png': logo,
  };
  for (const d of drop) delete files[d];
  return makeZip([...Object.entries(files).map(([name, data]) => ({ name, data })), ...extra]);
}
const ask = (zip, over = {}) => {
  const outDir = tmp();
  const r = validateInputs({ customer: 'acme-test', build: '3', resultsRepo: 'owner/results', sourceRepo: 'owner/source', zip, outDir, ...over });
  return { ...r, outDir };
};

test('a good bundle is accepted, its files are written, and the version is the product\'s with the build number', () => {
  const r = ask(bundle());
  assert.equal(r.ok, true, r.message);
  assert.deepEqual(r.parts, { website: true, android: true });
  assert.equal(r.version, '1.0.3');
  assert.deepEqual(readdirSync(r.outDir).sort(), ['brand.json', 'build.json', 'logo.png', 'website-settings.env']);
  assert.equal(readFileSync(join(r.outDir, 'website-settings.env'), 'utf8'), SETTINGS);
  rmSync(r.outDir, { recursive: true, force: true });
});

test('a zip written by the Studio\'s streaming writer (sizes after the data) is read too', async () => {
  const dir = tmp();
  const file = join(dir, 'inputs.zip');
  writeFileSync(join(dir, 'x.json'), JSON.stringify(buildJson()));
  await writeZipFile(file, [
    { name: 'build.json', file: join(dir, 'x.json') },
    { name: 'brand.json', data: JSON.stringify(BRAND) },
    { name: 'website-settings.env', data: SETTINGS },
    { name: 'logo.png', data: PNG },
  ]);
  const files = readInputsZip(readFileSync(file));
  assert.equal(JSON.parse(files['build.json']).customer, 'acme-test');
  assert.deepEqual(files['logo.png'], PNG);
  rmSync(dir, { recursive: true, force: true });
});

test('only a website, or only an app, may be asked for; the other files are then not needed', () => {
  const siteOnly = ask(bundle({ build: buildJson({ parts: { website: true } }), brand: '{"schema":1,"name":"Acme Test Shop","primaryColor":"#0f6cbd"}', drop: ['logo.png'] }));
  assert.equal(siteOnly.ok, true, siteOnly.message);
  assert.deepEqual(siteOnly.parts, { website: true, android: false });

  const appOnly = ask(bundle({ build: buildJson({ parts: { android: true } }), drop: ['website-settings.env'] }));
  assert.equal(appOnly.ok, true, appOnly.message);
  assert.deepEqual(appOnly.parts, { website: false, android: true });
});

test('the customer name must be small letters, digits and hyphens (2 to 41), and nothing that could leave a folder', () => {
  for (const good of ['acme-test', 'ab', 'a1', 'shop-2-go', 'x'.repeat(41)]) assert.equal(checkCustomerName(good), good);
  for (const bad of ['', 'a', 'Acme', 'acme_test', 'acme test', 'acme.test', '../acme', 'acme/test', 'acme\\test', '-acme', 'acme-', 'x'.repeat(42), 'acme;rm -rf', 'acme$(id)', 'acme\nx', 'café', 'ACME', null, undefined]) {
    assert.throws(() => checkCustomerName(bad), InputsError, `${JSON.stringify(bad)} must be refused`);
  }
  assert.throws(() => checkCustomerName('Bad Name'), /2 to 41 small letters, digits and hyphens/);
});

test('the build number is a whole number from 1', () => {
  assert.equal(checkBuildNumber('1'), 1);
  assert.equal(checkBuildNumber('12'), 12);
  for (const bad of ['', '0', '01', '-1', '1.5', '1e3', 'abc', ' 3', '3 ', '12345678', '3; id', null, undefined]) assert.throws(() => checkBuildNumber(bad), InputsError, `${JSON.stringify(bad)}`);
  assert.equal(versionFor(7), '1.0.7');
  assert.equal(versionFor(7, '2.3'), '2.3.7');
  assert.throws(() => versionFor(7, '2'), /two numbers/);
});

test('the results place is owner/name and never the repository that holds the source', () => {
  assert.equal(checkResultsRepo('owner/results', { sourceRepo: 'owner/source' }), 'owner/results');
  for (const bad of ['', 'results', 'a/b/c', 'owner/ results', 'owner/results; id', '/x', 'x/', 'owner/re$ults']) assert.throws(() => checkResultsRepo(bad), InputsError, bad);
  assert.throws(() => checkResultsRepo('Owner/Source', { sourceRepo: 'owner/source' }), /holds the programs' source/);
  const r = ask(bundle(), { resultsRepo: 'owner/source' });
  assert.equal(r.ok, false);
  assert.match(r.message, /same repository as the one that holds the programs' source/);
});

test('a bad name is refused before the zip is even looked at, and nothing is written', () => {
  const r = ask(bundle(), { customer: '../evil' });
  assert.equal(r.ok, false);
  assert.match(r.message, /cannot be used/);
  assert.deepEqual(existsSync(r.outDir) ? readdirSync(r.outDir) : [], []);
});

/** A zip made by hand, to plant what the Studio's writer would never make. */
function rawZip(name, data, { flags = 0x0800, method = 8, claimedSize = null, crc = null, packed = null } = {}) {
  const nameBytes = Buffer.from(name);
  const body = packed ?? (method === 8 ? deflateRawSync(data) : data);
  const u16 = (n) => { const b = Buffer.alloc(2); b.writeUInt16LE(n); return b; };
  const u32 = (n) => { const b = Buffer.alloc(4); b.writeUInt32LE(n >>> 0); return b; };
  const c = crc ?? crc32(data);
  const usize = claimedSize ?? data.length;
  const local = Buffer.concat([u32(0x04034b50), u16(20), u16(flags), u16(method), u16(0), u16(0), u32(c), u32(body.length), u32(usize), u16(nameBytes.length), u16(0), nameBytes, body]);
  const central = Buffer.concat([u32(0x02014b50), u16(20), u16(20), u16(flags), u16(method), u16(0), u16(0), u32(c), u32(body.length), u32(usize), u16(nameBytes.length), u16(0), u16(0), u16(0), u16(0), u32(0), u32(0), nameBytes]);
  const end = Buffer.concat([u32(0x06054b50), u16(0), u16(0), u16(1), u16(1), u32(central.length), u32(local.length), u16(0)]);
  return Buffer.concat([local, central, end]);
}

test('a file that is not one of the four is refused, whatever its name', () => {
  for (const name of ['sub/brand.json', 'logo.svg', 'README.md', 'brand.json/', '.env', 'build.json ']) {
    const r = ask(bundle({ extra: [{ name, data: 'x' }] }));
    assert.equal(r.ok, false, name);
    assert.ok(/which is not one of the files|holds \d+ files/.test(r.message), `${name}: ${r.message}`);
    assert.deepEqual(existsSync(r.outDir) ? readdirSync(r.outDir) : [], [], `${name}: nothing may be written`);
  }
  // Names the Studio's own writer would never make (a way out of the folder, an absolute path, a drive): planted by hand.
  for (const name of ['../evil.txt', '/etc/passwd', 'C:\\x.txt', '..\\..\\x', 'brand.json\u0000.exe']) {
    const r = ask(rawZip(name, Buffer.from('x')));
    assert.equal(r.ok, false, name);
    assert.match(r.message, /which is not one of the files/, name);
    assert.deepEqual(existsSync(r.outDir) ? readdirSync(r.outDir) : [], [], `${name}: nothing may be written`);
  }
});

test('a locked, damaged, lying or oversized zip is refused with plain words', () => {
  const data = Buffer.from(JSON.stringify(buildJson()));
  assert.deepEqual(Object.keys(readInputsZip(rawZip('build.json', data))), ['build.json']);
  assert.throws(() => readInputsZip(rawZip('build.json', data, { flags: 0x0801 })), /locked with a password/);
  assert.throws(() => readInputsZip(rawZip('build.json', data, { method: 99 })), /packed in a way that is not used/);
  assert.throws(() => readInputsZip(rawZip('build.json', data, { crc: 12345 })), /checksum is wrong/);
  assert.throws(() => readInputsZip(rawZip('build.json', data, { claimedSize: 99999 })), /bigger than it should be/);
  // A small declared size, but a body that inflates to a great deal: the reader stops at the limit.
  const bomb = Buffer.alloc(2 * 1024 * 1024, 0x41);
  assert.throws(() => readInputsZip(rawZip('build.json', bomb, { claimedSize: 100, crc: crc32(bomb) })), /damaged or bigger than it should be|bigger than it should be/);
  assert.throws(() => readInputsZip(Buffer.from('this is not a zip file at all, not even close')), /not a zip file/);
  assert.throws(() => readInputsZip(Buffer.alloc(10)), /not a zip file/);
  const cut = rawZip('build.json', data).subarray(0, 40);
  assert.throws(() => readInputsZip(cut), InputsError);
  assert.throws(() => readInputsZip(Buffer.alloc(9 * 1024 * 1024)), /far bigger/);
});

test('a name written twice, or more files than the four, is refused', () => {
  const twice = makeZip([{ name: 'build.json', data: '{}' }, { name: 'build.json', data: '{}' }]);
  assert.throws(() => readInputsZip(twice), /twice/);
  const many = makeZip(['build.json', 'brand.json', 'website-settings.env', 'logo.png', 'build.json'].map((name) => ({ name, data: 'x' })));
  assert.throws(() => readInputsZip(many), /holds 5 files/);
});

test('build.json must agree with the build that was started, and may only ask for parts that are known', () => {
  const ok = checkBuildJson(buildJson(), { customer: 'acme-test', build: 3 });
  assert.deepEqual(ok.parts, { website: true, android: true });
  const refused = (over, pattern) => assert.throws(() => checkBuildJson(buildJson(over), { customer: 'acme-test', build: 3 }), pattern);
  refused({ customer: 'other-shop' }, /another customer/);
  refused({ build: 4 }, /another build number/);
  refused({ build: '3' }, /another build number/);
  refused({ schema: 2 }, /schema/);
  refused({ parts: { website: true, ios: true } }, /does not know \("ios"\)/);
  refused({ parts: { website: 'yes' } }, /true or false/);
  refused({ parts: { website: false, android: false } }, /nothing to be built/);
  refused({ parts: {} }, /nothing to be built/);
  refused({ parts: [] }, /does not say which parts|nothing/);
  refused({ studioVersion: 'x; rm -rf /' }, /not written plainly/);
  assert.throws(() => checkBuildJson([], { customer: 'acme-test', build: 3 }), /not a description of a build/);
});

test('a bundle with a mismatching or unknown build.json says which parts were wanted when it can', () => {
  const r = ask(bundle({ build: buildJson({ customer: 'other-shop' }) }));
  assert.equal(r.ok, false);
  assert.match(r.message, /another customer/);
  const unknown = ask(bundle({ build: buildJson({ parts: { website: true, ios: true } }) }));
  assert.equal(unknown.ok, false);
  assert.equal(unknown.parts, null);
});

test('a value that looks like a secret is refused in any of the files, and the message never repeats it', () => {
  // Built from pieces, so that this file itself holds no key-shaped text.
  const aws = ['AK', 'IA', 'ABCDEFGHIJKLMNOP'].join('');
  const db = ['postgres', '://admin:', 'hunter2hunter2', '@db.example.com/shop'].join('');
  const cases = [
    ['website-settings.env', { settings: `${SETTINGS}NEXT_PUBLIC_SHOP_PLACE=${aws}\n` }],
    ['brand.json', { brand: { ...BRAND, tagline: aws } }],
    ['build.json', { build: buildJson({ studioVersion: db }) }],
    ['website-settings.env', { settings: `${SETTINGS}DATABASE_URL=${db}\n` }],
  ];
  for (const [file, over] of cases) {
    const r = ask(bundle(over));
    assert.equal(r.ok, false, file);
    assert.ok(!r.message.includes(aws) && !r.message.includes('hunter2'), 'the message must not repeat the secret');
    assert.deepEqual(existsSync(r.outDir) ? readdirSync(r.outDir) : [], [], 'nothing is written when a bundle is refused');
  }
  const r = ask(bundle({ settings: `${SETTINGS}NEXT_PUBLIC_SHOP_PLACE=${aws}\n` }));
  assert.match(r.message, /looks like a secret/);
});

test('the website\'s settings are checked by the website package\'s own rules (a private setting, an unknown country)', () => {
  const priv = ask(bundle({ settings: `${SETTINGS}SUPABASE_SERVICE_ROLE_KEY=abc\n` }));
  assert.equal(priv.ok, false);
  assert.match(priv.message, /not a public setting/);
  const country = ask(bundle({ settings: SETTINGS.replace('GB', 'ZZ') }));
  assert.equal(country.ok, false);
  assert.match(country.message, /no country pack for ZZ/);
  const noName = ask(bundle({ settings: 'NEXT_PUBLIC_COUNTRY=GB\n' }));
  assert.equal(noName.ok, false);
  assert.match(noName.message, /NEXT_PUBLIC_SITE_NAME is missing/);
  const missing = ask(bundle({ drop: ['website-settings.env'] }));
  assert.equal(missing.ok, false);
  assert.match(missing.message, /website-settings.env is missing/);
});

test('an app needs its application id, the address it opens and its colour; the brand is checked as the Brand Studio checks it', () => {
  const noAndroid = ask(bundle({ brand: { schema: 1, name: 'Acme Test Shop', primaryColor: '#0f6cbd' } }));
  assert.equal(noAndroid.ok, false);
  assert.match(noAndroid.message, /no application id/);
  assert.match(noAndroid.message, /no website address for the app/);
  const badId = ask(bundle({ brand: { ...BRAND, android: { appId: 'NotAnId', storefrontUrl: 'https://shop.example.com' } } }));
  assert.equal(badId.ok, false);
  assert.match(badId.message, /Android app id must look like/);
  const pale = ask(bundle({ brand: { ...BRAND, primaryColor: '#ffffcc' } }));
  assert.equal(pale.ok, false);
  assert.match(pale.message, /too light/);
  const noBrand = ask(bundle({ drop: ['brand.json'] }));
  assert.equal(noBrand.ok, false);
  assert.match(noBrand.message, /brand.json is missing/);
  const notJson = ask(bundle({ brand: 'not json at all' }));
  assert.equal(notJson.ok, false);
  assert.match(notJson.message, /brand.json cannot be read/);
});

test('the shop\'s name is the app\'s name, so for an app it must be one the app set-up accepts (said now, not after a long build)', () => {
  for (const name of ['Joe\'s Shop', 'A & B', 'x'.repeat(41), 'Say "hi"', 'back\\slash']) {
    const r = ask(bundle({ brand: { ...BRAND, name } }));
    assert.equal(r.ok, false, name);
    assert.match(r.message, /name of the app|name/, name);
  }
  const app = ask(bundle({ brand: { ...BRAND, name: 'Joe\'s Shop' } }));
  assert.match(app.message, /also the name of the app/);
  // A website alone has no such limit (apart from the Brand Studio's own).
  const site = ask(bundle({ build: buildJson({ parts: { website: true } }), brand: { ...BRAND, name: 'Joe\'s Shop' } }));
  assert.equal(site.ok, true, site.message);
});

test('a logo must be a real PNG of a sensible size', () => {
  const text = ask(bundle({ logo: Buffer.from('<svg xmlns="http://www.w3.org/2000/svg"></svg>') }));
  assert.equal(text.ok, false);
  assert.match(text.message, /not a PNG|logo/i);
  const gone = ask(bundle({ drop: ['logo.png'] }));
  assert.equal(gone.ok, false, 'brand.json names logo.png, so it must be there');
  assert.match(gone.message, /logo file logo.png is not in the kit folder/);
});

test('without both licence values the build is a trial; with one of the two it stops', () => {
  assert.deepEqual(licenceKeysState({}), { trial: true, problem: null });
  assert.deepEqual(licenceKeysState({ publicKeys: '  ', licenceUrl: '' }), { trial: true, problem: null });
  assert.deepEqual(licenceKeysState({ publicKeys: '{"keys":[]}', licenceUrl: 'https://licence.example.com' }), { trial: false, problem: null });
  assert.match(licenceKeysState({ publicKeys: '{"keys":[]}', licenceUrl: '' }).problem, /NGOS_PUBLIC_KEYS is set but NGOS_LICENCE_URL is not/);
  assert.match(licenceKeysState({ publicKeys: '', licenceUrl: 'https://x.example.com' }).problem, /NGOS_LICENCE_URL is set but NGOS_PUBLIC_KEYS is not/);
});

test('a real build (keys built in) is only made from the main branch; a trial may be made from any branch', () => {
  const real = { publicKeys: '{"keys":[]}', licenceUrl: 'https://licence.example.com', defaultBranch: 'main' };
  assert.deepEqual(licenceKeysState({ ...real, ref: 'refs/heads/main' }), { trial: false, problem: null });
  const other = licenceKeysState({ ...real, ref: 'refs/heads/feature/new-thing' });
  assert.match(other.problem, /only made from the main branch \(main\)/);
  assert.match(other.problem, /started from "feature\/new-thing"/);
  assert.match(licenceKeysState({ ...real, ref: 'refs/tags/v1.0.0' }).problem, /started from "v1\.0\.0"/);
  // A trial has no keys built in, so it may come from any branch.
  assert.deepEqual(licenceKeysState({ ref: 'refs/heads/feature/new-thing', defaultBranch: 'main' }), { trial: true, problem: null });
  // When the workflow does not say where it runs, nothing is assumed (the command line of the workflow always says).
  assert.deepEqual(licenceKeysState(real), { trial: false, problem: null });
});

// ---- the command line, as the workflow runs it ------------------------------------------------------------------------------

const run = (args, env = {}) => spawnSync('node', [script, ...args], { encoding: 'utf8', env: { ...process.env, GITHUB_OUTPUT: '', GITHUB_REPOSITORY: 'owner/source', ...env } });
const outputs = (file) => Object.fromEntries(readFileSync(file, 'utf8').split('\n').filter(Boolean).map((l) => [l.slice(0, l.indexOf('=')), l.slice(l.indexOf('=') + 1)]));

test('the command line writes the answers for the next jobs, one value to a line, and stops the job when the files are refused', () => {
  const dir = tmp();
  const zip = join(dir, 'inputs.zip');
  writeFileSync(zip, bundle());
  const out = join(dir, 'out');
  const github = join(dir, 'github-output');
  writeFileSync(github, '');
  const env = { CUSTOMER: 'acme-test', BUILD: '3', RESULTS_REPO: 'owner/results', GITHUB_OUTPUT: github };
  const good = run(['check', '--zip', zip, '--out', out], env);
  assert.equal(good.status, 0, good.stderr);
  assert.deepEqual(outputs(github), { ok: 'true', customer: 'acme-test', build: '3', version: '1.0.3', message: '', website: 'true', android: 'true' });
  assert.ok(existsSync(join(out, 'brand.json')));

  // Refused: exit 1 for a job that builds; with --report-only exit 0, so the first job can hand its answer on.
  writeFileSync(zip, bundle({ settings: 'NEXT_PUBLIC_COUNTRY=GB\n' }));
  writeFileSync(github, '');
  const refused = run(['check', '--zip', zip, '--out', out], env);
  assert.equal(refused.status, 1);
  assert.match(refused.stderr, /not accepted/);
  const o = outputs(github);
  assert.equal(o.ok, 'false');
  assert.equal(o.website, 'true');
  assert.ok(!o.message.includes('\n') && o.message.length > 20);
  assert.ok(!existsSync(join(out, 'brand.json')), 'a refused bundle leaves nothing behind');
  writeFileSync(github, '');
  assert.equal(run(['check', '--zip', zip, '--out', out, '--report-only'], env).status, 0);
  assert.equal(outputs(github).ok, 'false');

  // A zip that is not a zip, and a missing file, are refused in plain words too.
  writeFileSync(zip, 'not a zip');
  assert.match(run(['check', '--zip', zip, '--out', out], env).stderr, /not a zip file/);
  assert.match(run(['check', '--zip', join(dir, 'nothing.zip'), '--out', out], env).stderr, /was not found/);
  rmSync(dir, { recursive: true, force: true });
});

test('the keys command writes trial=true without the licence values and stops on half of them', () => {
  const dir = tmp();
  const github = join(dir, 'github-output');
  writeFileSync(github, '');
  assert.equal(run(['keys'], { NGOS_PUBLIC_KEYS: '', NGOS_LICENCE_URL: '', GITHUB_OUTPUT: github }).status, 0);
  assert.equal(outputs(github).trial, 'true');
  writeFileSync(github, '');
  assert.equal(run(['keys'], { NGOS_PUBLIC_KEYS: '{"k":1}', NGOS_LICENCE_URL: 'https://l.example.com', GITHUB_OUTPUT: github }).status, 0);
  assert.equal(outputs(github).trial, 'false');
  const half = run(['keys'], { NGOS_PUBLIC_KEYS: '{"k":1}', NGOS_LICENCE_URL: '', GITHUB_OUTPUT: github });
  assert.equal(half.status, 1);
  assert.match(half.stderr, /Only one of the two licence values/);
  // The first job only reports, and a following step stops it, so that its answer is handed on whatever happens.
  writeFileSync(github, '');
  assert.equal(run(['keys', '--report-only'], { NGOS_PUBLIC_KEYS: '{"k":1}', NGOS_LICENCE_URL: '', GITHUB_OUTPUT: github }).status, 0);
  assert.match(outputs(github).keys_problem, /Only one of the two licence values/);
  // A real build off the main branch is refused the same way.
  writeFileSync(github, '');
  const branch = run(['keys', '--report-only'], { NGOS_PUBLIC_KEYS: '{"k":1}', NGOS_LICENCE_URL: 'https://l.example.com', GITHUB_REF: 'refs/heads/some-branch', DEFAULT_BRANCH: 'main', GITHUB_OUTPUT: github });
  assert.equal(branch.status, 0);
  assert.match(outputs(github).keys_problem, /only made from the main branch/);
  writeFileSync(github, '');
  assert.equal(run(['keys', '--report-only'], { NGOS_PUBLIC_KEYS: '{"k":1}', NGOS_LICENCE_URL: 'https://l.example.com', GITHUB_REF: 'refs/heads/main', DEFAULT_BRANCH: 'main', GITHUB_OUTPUT: github }).status, 0);
  assert.equal(outputs(github).keys_problem, '');
  assert.equal(run(['nonsense']).status, 2);
  rmSync(dir, { recursive: true, force: true });
});
