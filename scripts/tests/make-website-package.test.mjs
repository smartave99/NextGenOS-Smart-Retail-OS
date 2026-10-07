// Tests for scripts/make-website-package.mjs: what goes into THE website package (the one program every customer gets), what never does (no customer's settings), how the settings are checked, which names are refused,
// how the start program behaves, and that the audits pass a good package and refuse a package with a planted source file, .env file, key or database.
// A real build (next build, Node.js, the package, started) is run by the release gate: scripts/checks/website.mjs.
import test from 'node:test';
import assert from 'node:assert/strict';
import { existsSync, mkdirSync, mkdtempSync, readFileSync, readdirSync, rmSync, statSync, writeFileSync, symlinkSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { dirname, join } from 'node:path';
import { spawnSync } from 'node:child_process';
import net from 'node:net';
import { fileURLToPath } from 'node:url';
import { listZip } from '../../tools/setup-studio/lib/zip.mjs';
import { assembleWebsite } from '../../tools/setup-studio/lib/website-assemble.mjs';
import {
  CUSTOMER_FOLDER, LAUNCHER, RULES_COPY, RULES_FILE, START_BAT, START_BAT_NAME, START_SH, TRIAL_FILE, WebsiteError, assemblePackage, buildEnvironment, checkCustomer, checkLogo, checkPackage, checkSystem, checkVersion, copyAppSource,
  genericName, keysBuiltIn, knownPacks, writeCustomerFolder, librariesMatchLock, licenceProblems, packageName, parseSettings, readmeFor, settingsFromKit, zipPackage,
} from '../make-website-package.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const scripts = join(here, '..');
const tmp = () => mkdtempSync(join(tmpdir(), 'website-test-'));
const put = (root, files) => { for (const [name, content] of Object.entries(files)) { const full = join(root, ...name.split('/')); mkdirSync(dirname(full), { recursive: true }); writeFileSync(full, content); } return root; };
const clean = (...dirs) => { for (const d of dirs) rmSync(d, { recursive: true, force: true }); };
const hostOs = process.platform === 'win32' ? 'windows' : 'linux';
const otherOs = hostOs === 'windows' ? 'linux' : 'windows';

/** A minimal 64-bit ELF file that needs the given shared libraries (the same builder as in audit-prerequisites.test.mjs). */
function makeElf({ needed = [], machine = 62 } = {}) {
  const strs = Buffer.concat([Buffer.from([0]), ...needed.map((n) => Buffer.from(n + '\0'))]);
  const offsets = []; let at = 1;
  for (const n of needed) { offsets.push(at); at += n.length + 1; }
  const dynEntries = [...offsets.map((o) => [1n, BigInt(o)]), [5n, 0n], [0n, 0n]];
  const phoff = 64, phsize = 56 * 2;
  const strOff = phoff + phsize;
  const dynOff = strOff + strs.length + ((8 - ((strOff + strs.length) % 8)) % 8);
  const dynSize = dynEntries.length * 16;
  const buf = Buffer.alloc(dynOff + dynSize);
  buf.writeUInt32BE(0x7f454c46, 0); buf[4] = 2; buf[5] = 1; buf[6] = 1;
  buf.writeUInt16LE(3, 16); buf.writeUInt16LE(machine, 18); buf.writeBigUInt64LE(BigInt(phoff), 32); buf.writeUInt16LE(56, 54); buf.writeUInt16LE(2, 56);
  buf.writeUInt32LE(1, phoff); buf.writeBigUInt64LE(0n, phoff + 8); buf.writeBigUInt64LE(0n, phoff + 16); buf.writeBigUInt64LE(BigInt(buf.length), phoff + 32);
  const p2 = phoff + 56; buf.writeUInt32LE(2, p2); buf.writeBigUInt64LE(BigInt(dynOff), p2 + 8); buf.writeBigUInt64LE(BigInt(dynOff), p2 + 16); buf.writeBigUInt64LE(BigInt(dynSize), p2 + 32);
  strs.copy(buf, strOff);
  dynEntries.forEach(([tag, val], i) => { buf.writeBigUInt64LE(tag, dynOff + i * 16); buf.writeBigUInt64LE(tag === 5n ? BigInt(strOff) : val, dynOff + i * 16 + 8); });
  return buf;
}

/** A minimal 64-bit Windows program file that imports the given DLLs. */
function makePe({ imports = [], machine = 0x8664 } = {}) {
  const peAt = 0x80, optSize = 240, secAt = peAt + 24 + optSize, secRaw = 0x400;
  const descSize = (imports.length + 1) * 20;
  const names = Buffer.concat(imports.map((n) => Buffer.from(n + '\0')));
  const buf = Buffer.alloc(secRaw + descSize + names.length + 16);
  buf.writeUInt16LE(0x5a4d, 0); buf.writeUInt32LE(peAt, 0x3c);
  buf.writeUInt32LE(0x4550, peAt); buf.writeUInt16LE(machine, peAt + 4); buf.writeUInt16LE(1, peAt + 6); buf.writeUInt16LE(optSize, peAt + 20);
  const opt = peAt + 24; buf.writeUInt16LE(0x20b, opt);
  const dirs = opt + 112;
  buf.writeUInt32LE(0x1000, dirs + 8); buf.writeUInt32LE(descSize, dirs + 12);
  buf.write('.idata', secAt); buf.writeUInt32LE(descSize + names.length, secAt + 8); buf.writeUInt32LE(0x1000, secAt + 12); buf.writeUInt32LE(descSize + names.length, secAt + 16); buf.writeUInt32LE(secRaw, secAt + 20);
  let nameRva = 0x1000 + descSize;
  imports.forEach((n, i) => { buf.writeUInt32LE(nameRva, secRaw + i * 20 + 12); nameRva += n.length + 1; });
  names.copy(buf, secRaw + descSize);
  return buf;
}

// Fake secrets are built from pieces, so that no line of this file looks like a secret to the gate's scan (scripts/scan-history.mjs reads every commit).
const KEY_HEAD = ['-----BEGIN', 'PRIVATE KEY-----'].join(' ');
const KEY_BODY = 'MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC7abcdef';
const DB_URL = ['postgresql://admin', 'SuperSecret99@db.example.invalid/shop'].join(':');
const MINIFIED = 's.pass' + 'word=r.pass' + 'word,s.host=r.host,s.port=r.port;break;';

const pkgJson = (name, license = 'MIT') => JSON.stringify({ name, version: '1.0.0', license });

/** The pieces of a built website, as the build leaves them, with the leftovers a real build also leaves (source, .env, types, maps, other systems' picture parts). */
function fakeBuild(os) {
  const root = tmp();
  const linux = os === 'linux';
  const standalone = put(join(root, 'standalone'), {
    'server.js': '// the website\'s server\n',
    'package.json': '{"scripts":{"dev":"next dev"},"devDependencies":{"vitest":"1"}}',
    '.env.production': 'NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart\n',
    '.next/BUILD_ID': 'abc',
    '.next/server/app/page.js': 'module.exports = {};',
    'src/components/CTA.tsx': 'export default function CTA() { return null; }',
    'src/lib/region/generated/lite.json': '{}',
    'node_modules/next/package.json': pkgJson('next'),
    'node_modules/next/index.js': 'module.exports = {};',
    'node_modules/next/LICENSE': 'MIT licence text',
    'node_modules/typed/package.json': pkgJson('typed'),
    'node_modules/typed/index.js': 'module.exports = 1;',
    'node_modules/typed/index.d.ts': 'export {};',
    'node_modules/typed/index.js.map': '{}',
    'node_modules/@img/colour/package.json': pkgJson('@img/colour'),
    'node_modules/@img/colour/index.js': 'module.exports = 1;',
    // a library whose error class is called SigningKeyNotFoundError, and minified code that sets a password field: neither is a secret
    'node_modules/jwks-rsa/package.json': pkgJson('jwks-rsa'),
    'node_modules/jwks-rsa/src/errors/SigningKeyNotFoundError.js': 'class SigningKeyNotFoundError extends Error {}',
    'node_modules/jwks-rsa/src/pem.js': `const header = "${KEY_HEAD}"; module.exports = header;`,
    'node_modules/next/dist/polyfill.js': `case 1:s.username=r.username,${MINIFIED}`,
  });
  const fixed = { 'node_modules/@img/sharp-linux-x64/package.json': pkgJson('@img/sharp-linux-x64', 'Apache-2.0'), 'node_modules/@img/sharp-win32-x64/package.json': pkgJson('@img/sharp-win32-x64', 'Apache-2.0 AND LGPL-3.0-or-later') };
  if (linux) {
    put(standalone, {
      ...Object.fromEntries(Object.entries(fixed).filter(([k]) => k.includes('linux-x64'))),
      'node_modules/@img/sharp-libvips-linux-x64/package.json': pkgJson('@img/sharp-libvips-linux-x64', 'LGPL-3.0-or-later'),
      'node_modules/@img/sharp-libvips-linuxmusl-x64/package.json': pkgJson('@img/sharp-libvips-linuxmusl-x64', 'LGPL-3.0-or-later'),
      'node_modules/@img/sharp-linuxmusl-x64/package.json': pkgJson('@img/sharp-linuxmusl-x64', 'Apache-2.0'),
    });
    mkdirSync(join(standalone, 'node_modules/.prisma/client'), { recursive: true });
    mkdirSync(join(standalone, 'node_modules/@img/sharp-linux-x64/lib'), { recursive: true });
    mkdirSync(join(standalone, 'node_modules/@img/sharp-libvips-linux-x64/lib'), { recursive: true });
    mkdirSync(join(standalone, 'node_modules/@img/sharp-linuxmusl-x64/lib'), { recursive: true });
    writeFileSync(join(standalone, 'node_modules/.prisma/client/libquery_engine-debian-openssl-3.0.x.so.node'), makeElf({ needed: ['libssl.so.3', 'libcrypto.so.3', 'libc.so.6'] }));
    writeFileSync(join(standalone, 'node_modules/@img/sharp-linux-x64/lib/sharp-linux-x64.node'), makeElf({ needed: ['libvips-cpp.so.8', 'libc.so.6'] }));
    writeFileSync(join(standalone, 'node_modules/@img/sharp-libvips-linux-x64/lib/libvips-cpp.so.8'), makeElf({ needed: ['libc.so.6'] }));
    writeFileSync(join(standalone, 'node_modules/@img/sharp-linuxmusl-x64/lib/sharp-linuxmusl-x64.node'), makeElf({ needed: ['libc.musl-x86_64.so.1'] }));
  } else {
    put(standalone, Object.fromEntries(Object.entries(fixed).filter(([k]) => k.includes('win32-x64'))));
    put(standalone, { 'node_modules/@img/sharp-linux-x64/package.json': pkgJson('@img/sharp-linux-x64', 'Apache-2.0') });
    mkdirSync(join(standalone, 'node_modules/.prisma/client'), { recursive: true });
    mkdirSync(join(standalone, 'node_modules/@img/sharp-win32-x64/lib'), { recursive: true });
    mkdirSync(join(standalone, 'node_modules/@img/sharp-linux-x64/lib'), { recursive: true });
    writeFileSync(join(standalone, 'node_modules/.prisma/client/query_engine-windows.dll.node'), makePe({ imports: ['KERNEL32.dll', 'ntdll.dll', 'ws2_32.dll'] }));
    writeFileSync(join(standalone, 'node_modules/@img/sharp-win32-x64/lib/sharp-win32-x64.node'), makePe({ imports: ['KERNEL32.dll'] }));
    writeFileSync(join(standalone, 'node_modules/@img/sharp-linux-x64/lib/sharp-linux-x64.node'), makeElf({ needed: ['libc.so.6'] }));   // another system's file, to be taken out
  }
  const staticDir = put(join(root, 'static'), { 'chunks/main-abc.js': 'console.log(1);', 'css/app.css': 'body{}' });
  const publicDir = put(join(root, 'public'), { 'favicon.ico': 'ico', 'logo.png': 'png' });
  const nodeRoot = join(root, 'node');
  if (linux) { mkdirSync(join(nodeRoot, 'bin'), { recursive: true }); writeFileSync(join(nodeRoot, 'bin', 'node'), makeElf({ needed: ['libdl.so.2', 'libstdc++.so.6', 'libm.so.6', 'libgcc_s.so.1', 'libpthread.so.0', 'libc.so.6'] }), { mode: 0o755 }); }
  else { mkdirSync(nodeRoot, { recursive: true }); writeFileSync(join(nodeRoot, 'node.exe'), makePe({ imports: ['KERNEL32.dll', 'WS2_32.dll', 'ADVAPI32.dll'] })); }
  writeFileSync(join(nodeRoot, 'LICENSE'), 'Node.js licence text\n');
  return { root, standalone, staticDir, publicDir, node: { root: nodeRoot, version: 'v22.22.0' } };
}

const SETTINGS = { NEXT_PUBLIC_SITE_NAME: 'Luzon Fresh Mart', NEXT_PUBLIC_SITE_URL: 'https://shop.luzonfresh.example', NEXT_PUBLIC_COUNTRY: 'PH', NEXT_PUBLIC_INDUSTRY: 'retail', NEXT_PUBLIC_SHOP_PLACE: 'Quezon City, Philippines' };
function make(os, extra = {}) {
  const b = fakeBuild(os);
  const out = join(b.root, 'out');
  const r = assemblePackage({ out, os, version: '1.2.3', standalone: b.standalone, staticDir: b.staticDir, publicDir: b.publicDir, node: b.node, keyCount: 1, now: new Date('2026-01-01T00:00:00Z'), ...extra });
  return { ...b, out, ...r };
}

// ---------------------------------------------------------------------------------------------------------------------

test('the settings file the Setup Studio writes is read: CRLF, comments, a quoted value', () => {
  const text = ['# Public settings for Luzon Fresh Mart\'s website.', 'NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart', 'NEXT_PUBLIC_SITE_URL=https://shop.luzonfresh.example', 'NEXT_PUBLIC_COUNTRY=PH', 'NEXT_PUBLIC_INDUSTRY=retail',
    'NEXT_PUBLIC_SHOP_PLACE="Quezon City, Philippines"', '', '# No password or key is written here.', ''].join('\r\n');
  const r = parseSettings(text, { countries: ['PH', 'IN'], industries: ['retail', 'library'] });
  assert.deepEqual(r.problems, []);
  assert.deepEqual(r.values, SETTINGS);
  // The Studio leaves the website name out when it was not given: the website then uses its own neutral address.
  assert.deepEqual(parseSettings('NEXT_PUBLIC_SITE_NAME=X Shop\r\n# NEXT_PUBLIC_SITE_URL=https://   (the website name was not given)\r\nNEXT_PUBLIC_COUNTRY=PH\r\n').problems, []);
});

test('private settings, unknown names and malformed lines are refused in plain words', () => {
  const r = parseSettings(['NEXT_PUBLIC_SITE_NAME=Shop', 'DATABASE_URL=postgres://user:secret@host/shop', 'NGOS_LICENCE=abc', 'NEXT_PUBLIC_NOTHING=1', 'just some words', 'NEXT_PUBLIC_COUNTRY=PH', 'NEXT_PUBLIC_COUNTRY=IN'].join('\n')).problems.join('\n');
  assert.match(r, /DATABASE_URL is not a public setting.*private-settings\.env/);
  assert.match(r, /NGOS_LICENCE is not a public setting/);
  assert.match(r, /NEXT_PUBLIC_NOTHING is not a setting this website knows/);
  assert.match(r, /Line 5 is not a setting/);
  assert.match(r, /NEXT_PUBLIC_COUNTRY is written twice/);
});

test('values are checked: a shop name is needed, addresses must be addresses, a country needs its pack, a key is never accepted', () => {
  const bad = (text, opts) => parseSettings(text, opts).problems.join('\n');
  assert.match(bad('NEXT_PUBLIC_COUNTRY=PH'), /NEXT_PUBLIC_SITE_NAME is missing/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME='), /NEXT_PUBLIC_SITE_NAME is empty/);
  assert.match(bad(`NEXT_PUBLIC_SITE_NAME=${'x'.repeat(81)}`), /longer than 80/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=<script>'), /character that is not allowed/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_SITE_URL=not a url'), /NEXT_PUBLIC_SITE_URL is not a web address/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_SITE_URL=ftp://shop.example'), /must start with http/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_SITE_URL=https://user:pw@shop.example'), /must not hold a user name or a password/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_SITE_URL=https://shop.example/?a=1'), /must not have a \? or a # part/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_COUNTRY=philippines'), /two capital letters/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_COUNTRY=ZZ', { countries: ['PH'] }), /no country pack for ZZ/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_INDUSTRY=spaceship', { industries: ['retail'] }), /no industry pack called spaceship/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_SUPABASE_URL=http://db.example'), /must start with https/);
  assert.match(bad('NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY=sb_secret_abcdefghijklmnop'), /publishable key/);
  const service = `eyJhbGciOiJIUzI1NiJ9.${Buffer.from(JSON.stringify({ role: 'service_role' })).toString('base64url')}.c2ln`;
  assert.match(bad(`NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_SUPABASE_ANON_KEY=${service}`), /not the public \(anon\) key/);
  // a value that looks like a key is refused, because the package check would refuse the finished package
  assert.match(bad(`NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_FIREBASE_API_KEY=AIza${'x'.repeat(35)}`), /looks like a secret key \(Google API key\)/);
});

test('names that try to leave the folder, or that are odd, are refused; the package is named by one rule', () => {
  for (const id of ['../evil', '..', 'a/b', 'a\\b', '/etc', 'C:\\x', 'Luzon', 'x', '-a', 'a-', 'a b', 'a.b', '', null, undefined, 'a'.repeat(43), 'ünï', 'a\0b', 'a\nb']) assert.throws(() => checkCustomer(id), WebsiteError, String(id));
  for (const id of ['luzon-fresh-mart', 'ab', 'shop2', 'a-b-c', 'a'.repeat(41)]) assert.equal(checkCustomer(id), id);
  assert.equal(packageName('luzon-fresh-mart', 'linux'), 'website-luzon-fresh-mart-linux');
  assert.equal(packageName('luzon-fresh-mart', 'windows'), 'website-luzon-fresh-mart-windows');
  assert.throws(() => packageName('../x', 'linux'), WebsiteError);
  assert.throws(() => packageName('luzon', 'macos'), /windows or --os linux/);
  assert.throws(() => checkSystem(undefined), WebsiteError);
  assert.throws(() => checkVersion('1.0'), /three numbers/);
  assert.equal(checkVersion('1.2.3'), '1.2.3');
});

test('a brand kit gives the settings and the logo; a logo that is not a picture, or a name that points elsewhere, is not used', () => {
  const root = tmp();
  try {
    const png = Buffer.concat([Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]), Buffer.alloc(32)]);
    put(root, { 'kit/brand.json': JSON.stringify({ schema: 1, name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', logo: 'logo.png', contact: { address: 'Rizal Ave, Quezon City, Philippines' }, storefront: { siteUrl: 'https://shop.luzonfresh.example' } }) });
    writeFileSync(join(root, 'kit', 'logo.png'), png);
    const k = settingsFromKit(join(root, 'kit'));
    assert.deepEqual(k.values, { ...SETTINGS });
    assert.equal(k.logo, join(root, 'kit', 'logo.png'));
    checkLogo(k.logo);
    writeFileSync(join(root, 'kit', 'logo.png'), 'not a picture');
    assert.throws(() => checkLogo(join(root, 'kit', 'logo.png')), /not a PNG/);
    put(root, { 'kit2/brand.json': JSON.stringify({ schema: 1, name: 'A', logo: '../kit/logo.png' }) });
    assert.equal(settingsFromKit(join(root, 'kit2')).logo, null);
    assert.throws(() => settingsFromKit(join(root, 'nothing')), /no brand kit/);
  } finally { clean(root); }
});

test('the licence keys built into the website are counted (none means a trial)', () => {
  const root = tmp();
  try {
    put(root, { 'src/lib/licence/defaults.ts': 'export const TRUSTED_KEYS: { kid: string; publicKey: string }[] = [];\nexport const LICENCE_SERVER_URL = "";\n' });
    assert.deepEqual(keysBuiltIn(root), { count: 0, url: '' });
    put(root, { 'src/lib/licence/defaults.ts': `export const TRUSTED_KEYS: { kid: string; publicKey: string }[] = [{"kid":"k1","publicKey":"${'A'.repeat(43)}"}];\nexport const LICENCE_SERVER_URL = "https://licence.example";\n` });
    assert.deepEqual(keysBuiltIn(root), { count: 1, url: 'https://licence.example' });
    assert.throws(() => keysBuiltIn(join(root, 'elsewhere')), /not the website's folder/);
  } finally { clean(root); }
});

test('the libraries\' licences are read: permissive ones pass, GPL and unknown ones do not, the picture library is the one named exception', () => {
  const root = tmp();
  try {
    put(root, {
      'a/package.json': pkgJson('a', 'MIT'), 'b/package.json': pkgJson('b', '(MIT OR GPL-3.0)'), 'c/package.json': pkgJson('c', 'Apache-2.0'),
      '@img/sharp-libvips-linux-x64/package.json': pkgJson('@img/sharp-libvips-linux-x64', 'LGPL-3.0-or-later'),
      '@img/sharp-win32-x64/package.json': pkgJson('@img/sharp-win32-x64', 'Apache-2.0 AND LGPL-3.0-or-later'),
    });
    assert.deepEqual(licenceProblems(root), []);
    put(root, { 'g/package.json': pkgJson('g', 'GPL-3.0'), 'n/package.json': JSON.stringify({ name: 'n', version: '1' }), 'l/package.json': pkgJson('l', 'LGPL-3.0-or-later'), 'x/package.json': pkgJson('x', 'MIT AND GPL-2.0-only'),
      'a/node_modules/deep/package.json': pkgJson('deep', 'AGPL-3.0'), 'nc/package.json': pkgJson('nc', 'CC-BY-NC-4.0') });
    const r = licenceProblems(root).join('\n');
    for (const who of ['g ', 'n ', 'l ', 'x ', 'a/node_modules/deep', 'nc ']) assert.match(r, new RegExp(who.replace('/', '\\/')), who);
    assert.doesNotMatch(r, /sharp/);
    assert.match(r, /none stated/);
  } finally { clean(root); }
});

test('the installed libraries must be the ones package-lock.json names', () => {
  const root = tmp();
  try {
    put(root, { 'app/package-lock.json': JSON.stringify({ packages: { '': {}, 'node_modules/a': { version: '1.0.0' }, 'node_modules/b': { version: '2.0.0' } } }) });
    assert.throws(() => librariesMatchLock(join(root, 'app'), join(root, 'app', 'node_modules')), /not installed with npm ci/);
    put(root, { 'app/node_modules/.package-lock.json': JSON.stringify({ packages: { 'node_modules/a': { version: '1.0.0' } } }) });
    librariesMatchLock(join(root, 'app'), join(root, 'app', 'node_modules'));
    put(root, { 'app/node_modules/.package-lock.json': JSON.stringify({ packages: { 'node_modules/a': { version: '1.0.1' }, 'node_modules/extra': { version: '1.0.0' } } }) });
    assert.throws(() => librariesMatchLock(join(root, 'app'), join(root, 'app', 'node_modules')), /do not match package-lock\.json \(node_modules\/a, node_modules\/extra\)/);
  } finally { clean(root); }
});

test('the build sees the public settings and the tools, and nothing else of this computer', () => {
  const saved = { ...process.env };
  Object.assign(process.env, { DATABASE_URL: 'postgres://user:secret@host/shop', NGOS_LICENCE: 'a.b.c', GROQ_API_KEY: 'x', LICENCE_DIR: '/x', NGOS_DEV_UNLICENSED: '1', NEXT_PUBLIC_SITE_NAME: 'From this computer', NEXT_PUBLIC_COUNTRY: 'IN' });
  try {
    const env = buildEnvironment({ NEXT_PUBLIC_SITE_NAME: 'Luzon Fresh Mart' });
    for (const name of ['DATABASE_URL', 'NGOS_LICENCE', 'GROQ_API_KEY', 'LICENCE_DIR', 'NGOS_DEV_UNLICENSED', 'NEXT_PUBLIC_COUNTRY']) assert.equal(env[name], undefined, name);
    assert.equal(env.NEXT_PUBLIC_SITE_NAME, 'Luzon Fresh Mart');
    assert.equal(env.NODE_ENV, 'production');
    assert.ok(env.PATH, 'the tools are found');
    assert.equal(env.NGOS_PACKAGE_BUILD, undefined);
    assert.equal(buildEnvironment({}, { NGOS_PACKAGE_BUILD: '1' }).NGOS_PACKAGE_BUILD, '1');
  } finally { for (const k of Object.keys(process.env)) if (!(k in saved)) delete process.env[k]; Object.assign(process.env, saved); }
});

test('the build folder gets the website\'s source and nothing private: no .env, no licence, no phone app, no generated files', () => {
  const root = tmp();
  try {
    put(join(root, 'app'), {
      'src/app/page.tsx': 'x', 'package.json': '{}', 'package-lock.json': '{}', 'next.config.ts': 'x', 'prisma/schema.prisma': 'x', 'public/logo.png': 'x', 'scripts/generate-version.js': 'x',
      'customer/brand.json': '{"name":"A customer"}', 'customer/assets/logo.png': 'x', '.env.local': 'SECRET=1', '.env.example': 'A=', '.env': 'B=', '.licence/licence.ngos': 'token', 'src/licence.ngos': 'token', 'android/app/build.gradle': 'x', 'node_modules/a/index.js': 'x', '.next/BUILD_ID': 'x',
      'public/sw.js': 'x', 'public/workbox-1.js': 'x', 'public/version.json': '{}', 'tsconfig.tsbuildinfo': '{}', 'next-env.d.ts': 'x',
    });
    copyAppSource(join(root, 'app'), join(root, 'copy'));
    const kept = (function walk(d, base = d) { return readdirSync(d, { withFileTypes: true }).flatMap((e) => (e.isDirectory() ? walk(join(d, e.name), base) : [join(d, e.name).slice(base.length + 1).split('\\').join('/')])); })(join(root, 'copy')).sort();
    assert.deepEqual(kept, ['next.config.ts', 'package-lock.json', 'package.json', 'prisma/schema.prisma', 'public/logo.png', 'scripts/generate-version.js', 'src/app/page.tsx']);
  } finally { clean(root); }
});

// ---------------------------------------------------------------------------------------------------------------------

test('a Linux package is put together from the build: what goes in, what is left out, and the audits pass', () => {
  const p = make('linux');
  try {
    const at = (f) => join(p.folder, ...f.split('/'));
    for (const f of ['start-website.js', 'app-window.mjs', RULES_COPY, 'start-website.sh', 'READ ME FIRST.txt', 'private-settings.example.env', 'prerequisites.json', 'PACKAGE-INFO.json', 'node/bin/node', 'node/LICENSE', 'EULA.txt'.replace('EULA.txt', 'licence/READ ME.txt'),
      'app/server.js', 'app/package.json', 'app/.next/BUILD_ID', 'app/.next/server/app/page.js', 'app/.next/static/chunks/main-abc.js', 'app/public/favicon.ico', 'app/node_modules/next/index.js', 'app/node_modules/next/LICENSE',
      'app/node_modules/.prisma/client/libquery_engine-debian-openssl-3.0.x.so.node', 'app/node_modules/@img/sharp-linux-x64/lib/sharp-linux-x64.node']) assert.ok(existsSync(at(f)), `${f} is in the package`);
    // Left out: the build's source, its .env, the other systems' picture parts, type files and maps, the build's own package.json.
    for (const f of ['app/src', 'app/.env.production', 'app/node_modules/typed/index.d.ts', 'app/node_modules/typed/index.js.map', 'app/node_modules/@img/sharp-linuxmusl-x64', 'app/node_modules/@img/sharp-libvips-linuxmusl-x64', 'start-website.bat']) assert.ok(!existsSync(at(f)), `${f} is not in the package`);
    assert.doesNotMatch(readFileSync(at('app/package.json'), 'utf8'), /scripts|devDependencies|vitest/);
    assert.ok(statSync(at('start-website.sh')).mode & 0o100, 'the start script can be run');
    const sh = readFileSync(at('start-website.sh'), 'utf8');
    assert.match(sh, /--app/, 'it opens the website as a program of its own');
    assert.match(sh, /--install-menu/, 'it can put the website in the applications menu');
    assert.ok(!readdirSync(p.folder).some((n) => /\.(exe|bat)$/.test(n)), 'no Windows launcher in a Linux package');
    assert.ok(statSync(at('node/bin/node')).mode & 0o100, 'Node.js can be run');
    assert.deepEqual(p.pruned.other.sort(), ['@img/sharp-libvips-linuxmusl-x64', '@img/sharp-linuxmusl-x64'].sort());

    const pre = JSON.parse(readFileSync(at('prerequisites.json'), 'utf8'));
    assert.deepEqual([pre.schema, pre.os, pre.arch], [1, 'linux', 'x64']);
    assert.deepEqual(pre.system, ['glibc-2.35-or-newer', 'libstdc++6-libgcc-s1', 'openssl-3']);
    assert.ok(pre.bundled.some((b) => /nodejs-runtime/.test(b)) && pre.minimumSystem.includes('Ubuntu 22.04'));
    const info = JSON.parse(readFileSync(at('PACKAGE-INFO.json'), 'utf8'));
    assert.deepEqual([info.generic, info.version, info.os, info.node, info.licenceKeysBuiltIn, info.trialWithoutLicenceKeys, info.customerFolder], [true, '1.2.3', 'linux', 'v22.22.0', 1, false, CUSTOMER_FOLDER]);
    assert.ok(!('customer' in info) && !('name' in info) && !('publicSettings' in info), 'the package says nothing about a customer');
    assert.equal(p.name, 'website-linux');
    assert.equal(readFileSync(at(RULES_COPY), 'utf8'), readFileSync(RULES_FILE, 'utf8'), 'the rules that check a customer folder travel with the program, unchanged');
    assert.ok(!existsSync(at(CUSTOMER_FOLDER)), 'no customer folder in the program');

    const checked = checkPackage(p.folder, { os: 'linux' });
    assert.deepEqual(checked.problems, []);
    // The audits as a person (or the workflow) runs them.
    const a = spawnSync(process.execPath, [join(scripts, 'audit-package.mjs'), p.folder, '--node-app'], { encoding: 'utf8' });
    assert.equal(a.status, 0, a.stdout + a.stderr);
    const b = spawnSync(process.execPath, [join(scripts, 'audit-prerequisites.mjs'), p.folder, '--os', 'linux'], { encoding: 'utf8' });
    assert.equal(b.status, 0, b.stdout + b.stderr);
    // Without --node-app the audit still refuses the libraries' folder: only the website may carry one.
    const strict = spawnSync(process.execPath, [join(scripts, 'audit-package.mjs'), p.folder], { encoding: 'utf8' });
    assert.equal(strict.status, 1);
    assert.match(strict.stdout, /node_modules\/\s+node_modules/);
  } finally { clean(p.root); }
});

test('a Windows package: its own start file, Windows native parts, and no Linux file', () => {
  const p = make('windows');
  try {
    const at = (f) => join(p.folder, ...f.split('/'));
    for (const f of ['Start Website.exe', START_BAT_NAME, 'app-window.mjs', 'start-website.js', 'node/node.exe', 'app/node_modules/.prisma/client/query_engine-windows.dll.node', 'app/node_modules/@img/sharp-win32-x64/lib/sharp-win32-x64.node']) assert.ok(existsSync(at(f)), f);
    assert.ok(!existsSync(at('start-website.sh')) && !existsSync(at('app/node_modules/@img/sharp-linux-x64')), 'nothing for the other system');
    const bat = readFileSync(at(START_BAT_NAME), 'utf8');
    // The icon people double-click is a window program (no black terminal) that starts the website's own Node.js as a program of its own.
    const exe = readFileSync(at('Start Website.exe'));
    assert.equal(exe.subarray(0, 2).toString('latin1'), 'MZ');
    assert.equal(exe.readUInt16LE(exe.readUInt32LE(0x3c) + 24 + 68), 2, 'a window program (subsystem 2): no black terminal opens');
    assert.ok(exe.includes(Buffer.from('start-website.js --app', 'utf16le')), 'it starts the website as a program of its own');
    assert.ok(!existsSync(at('Start Website.bat')), 'no script that opens a terminal is the way in');
    assert.equal(readFileSync(at('app-window.mjs'), 'utf8'), readFileSync(join(scripts, 'lib', 'app-window.mjs'), 'utf8'), 'the window code is the one source, unchanged');
    assert.ok(bat.split('\n').slice(0, -1).every((l) => l.endsWith('\r')), 'a Windows script has Windows line ends');
    const pre = JSON.parse(readFileSync(at('prerequisites.json'), 'utf8'));
    assert.deepEqual(pre.system, ['windows-10-22h2-or-11-x64', 'windows-system-dlls']);
    assert.deepEqual(checkPackage(p.folder, { os: 'windows' }).problems, []);
    const b = spawnSync(process.execPath, [join(scripts, 'audit-prerequisites.mjs'), p.folder, '--os', 'windows'], { encoding: 'utf8' });
    assert.equal(b.status, 0, b.stdout + b.stderr);
    // A Windows package that carries a Linux program file is refused.
    writeFileSync(at('app/node_modules/other.so'), makeElf({ needed: ['libc.so.6'] }));
    assert.match(checkPackage(p.folder, { os: 'windows' }).problems.join('\n'), /other\.so\s+is a Linux program file in a Windows package/);
  } finally { clean(p.root); }
});

test('a package with something planted in it is refused: source, .env, a key, a database, a licence, a test, a Windows file, a missing manifest', () => {
  const p = make('linux');
  try {
    const at = (f) => join(p.folder, ...f.split('/'));
    const plant = (rel, content, expected) => {
      mkdirSync(dirname(at(rel)), { recursive: true });
      writeFileSync(at(rel), content);
      try { assert.match(checkPackage(p.folder, { os: 'linux' }).problems.join('\n'), expected, rel); } finally { rmSync(at(rel), { force: true }); }
    };
    plant('app/src/page.tsx', 'export default function Page() {}', /page\.tsx\s+source code/);
    plant('app/lib/server.ts', 'export const a = 1;', /server\.ts\s+source code/);
    plant('app/node_modules/typed/index.d.ts', 'export {};', /index\.d\.ts\s+source code/);
    plant('app/.next/server/page.js.map', '{}', /page\.js\.map\s+source map/);
    plant('app/.env', 'DATABASE_URL=x', /\.env\s+environment file/);
    plant('app/.env.local', 'A=1', /\.env\.local\s+environment file/);
    plant('private-settings.env.bak', 'x', /\.bak/);
    plant('licence/licence.ngos', 'eyJ.x.y', /licence\.ngos\s+licence file/);
    plant('app/shop.db', 'x', /shop\.db\s+database/);
    plant('app/signing.pem', 'x', /signing\.pem\s+key or certificate/);
    plant('app/notes.txt', DB_URL, /contains database URL with a password/);
    plant('app/notes2.txt', KEY_HEAD, /contains private key/);
    plant('app/key.js', `const k = "${KEY_HEAD}\\n${KEY_BODY}";`, /key\.js\s+contains private key/);
    plant('app/node_modules/x/a.test.js', 'x', /a\.test\.js\s+test file/);
    plant('app/tests/run.js', 'x', /tests\/\s+tests/);
    plant('app/node_modules/x/package-lock.json', '{}', /package-lock\.json\s+lock file/);
    plant('app/node_modules/win.dll', makePe({ imports: ['KERNEL32.dll'] }), /win\.dll\s+is a Windows program file in a Linux package/);
    plant('app/node_modules/needs.so', makeElf({ needed: ['libfontconfig.so.1'] }), /needs libfontconfig\.so\.1/);
    plant('app/node_modules/old/package.json', pkgJson('old', 'GPL-3.0'), /old \(old\) has the licence "GPL-3\.0"/);
    // A package without its manifest, or without a part it needs, is refused.
    const manifest = readFileSync(at('prerequisites.json'));
    rmSync(at('prerequisites.json'));
    assert.match(checkPackage(p.folder, { os: 'linux' }).problems.join('\n'), /prerequisites\.json is missing/);
    writeFileSync(at('prerequisites.json'), manifest);
    rmSync(at('app/.next/static'), { recursive: true });
    assert.match(checkPackage(p.folder, { os: 'linux' }).problems.join('\n'), /app\/\.next\/static is missing/);
  } finally { clean(p.root); }
});

test('the database engine and the picture library for the system must be in the package', () => {
  const p = make('linux');
  try {
    rmSync(join(p.folder, 'app/node_modules/.prisma/client/libquery_engine-debian-openssl-3.0.x.so.node'));
    rmSync(join(p.folder, 'app/node_modules/@img/sharp-linux-x64'), { recursive: true });
    const r = checkPackage(p.folder, { os: 'linux' }).problems.join('\n');
    assert.match(r, /database engine for linux is missing/);
    assert.match(r, /picture library for linux is missing/);
  } finally { clean(p.root); }
});

test('a trial build (no licence keys) says so on its face; a real one does not', () => {
  const trial = make('linux', { trial: true, keyCount: 0 });
  const real = make('linux', { trial: false });
  try {
    assert.ok(existsSync(join(trial.folder, TRIAL_FILE)));
    assert.match(readFileSync(join(trial.folder, TRIAL_FILE), 'utf8'), /WITHOUT licence keys.*never|Do not give it to a customer/s);
    assert.match(readFileSync(join(trial.folder, 'READ ME FIRST.txt'), 'utf8'), /^\*\*\* TRIAL BUILD, NO LICENCE KEYS \*\*\*/);
    assert.equal(JSON.parse(readFileSync(join(trial.folder, 'PACKAGE-INFO.json'), 'utf8')).trialWithoutLicenceKeys, true);
    assert.ok(!existsSync(join(real.folder, TRIAL_FILE)));
    assert.doesNotMatch(readFileSync(join(real.folder, 'READ ME FIRST.txt'), 'utf8'), /TRIAL BUILD/);
  } finally { clean(trial.root, real.root); }
});

test('the package is the same for every customer: no customer folder, no name, no settings, no logo; changing what the build was given about a customer changes nothing', () => {
  const a = make('linux');
  const b = make('linux', { now: new Date('2026-01-01T00:00:00Z') });
  try {
    const textsOf = (folder) => Object.fromEntries(['READ ME FIRST.txt', 'PACKAGE-INFO.json', 'start-website.js', 'start-website.sh', 'private-settings.example.env', 'prerequisites.json'].map((f) => [f, readFileSync(join(folder, f), 'utf8')]));
    assert.deepEqual(textsOf(a.folder), textsOf(b.folder));
    for (const [file, text] of Object.entries(textsOf(a.folder))) assert.doesNotMatch(text, /Luzon|smart ?avenue|Quezon|@.*\.(com|example)/i, file);
    assert.match(readFileSync(join(a.folder, 'READ ME FIRST.txt'), 'utf8'), /^Smart Retail POS: the website\r\n/);
    assert.match(readFileSync(join(a.folder, 'READ ME FIRST.txt'), 'utf8'), /folder "customer"/);
    assert.equal(genericName('windows'), 'website-windows');
    assert.throws(() => genericName('macos'), WebsiteError);
    assert.equal(a.name, genericName('linux'));
    assert.deepEqual(checkPackage(a.folder, { os: 'linux' }).problems, []);
  } finally { clean(a.root, b.root); }
});

test('a customer folder, a customer\'s name or a licence file in THE website is refused; in one customer\'s website the customer folder and the customer\'s licence are right', () => {
  const p = make('linux');
  try {
    const at = (f) => join(p.folder, ...f.split('/'));
    put(p.folder, { 'customer/brand.json': JSON.stringify({ name: 'Luzon Fresh Mart' }) });
    assert.match(checkPackage(p.folder, { os: 'linux' }).problems.join('\n'), /customer\/ is in the package: THE website is the same for every customer/);
    // The same folder is exactly what one customer's website carries.
    assert.deepEqual(checkPackage(p.folder, { os: 'linux', kind: 'customer' }).problems, []);
    rmSync(at('customer'), { recursive: true });
    const info = JSON.parse(readFileSync(at('PACKAGE-INFO.json'), 'utf8'));
    writeFileSync(at('PACKAGE-INFO.json'), JSON.stringify({ ...info, customer: 'luzon-fresh-mart', name: 'Luzon Fresh Mart', publicSettings: SETTINGS }));
    assert.match(checkPackage(p.folder, { os: 'linux' }).problems.join('\n'), /PACKAGE-INFO\.json holds a customer's name or settings/);
    writeFileSync(at('PACKAGE-INFO.json'), JSON.stringify(info));
    // A licence file: refused in THE website, accepted only at licence/licence.ngos of one customer's website, and nowhere else.
    put(p.folder, { 'licence/licence.ngos': 'a.b.c' });
    assert.match(checkPackage(p.folder, { os: 'linux' }).problems.join('\n'), /licence\.ngos\s+licence file/);
    assert.deepEqual(checkPackage(p.folder, { os: 'linux', kind: 'customer' }).problems, []);
    const strict = spawnSync(process.execPath, [join(scripts, 'audit-package.mjs'), p.folder, '--node-app'], { encoding: 'utf8' });
    assert.equal(strict.status, 1);
    const customer = spawnSync(process.execPath, [join(scripts, 'audit-package.mjs'), p.folder, '--node-app', '--customer-package'], { encoding: 'utf8' });
    assert.equal(customer.status, 0, customer.stdout + customer.stderr);
    rmSync(at('licence/licence.ngos'));
    put(p.folder, { 'app/licence.ngos': 'a.b.c', 'customer/licence/licence.ngos': 'x' });
    assert.match(checkPackage(p.folder, { os: 'linux', kind: 'customer' }).problems.join('\n'), /app\/licence\.ngos\s+licence file/);
    rmSync(at('app/licence.ngos'));
    // Things planted in the customer folder are refused even in a customer's website.
    for (const [rel, content, what] of [['customer/page.tsx', 'export {}', /source code/], ['customer/.env', 'A=1', /environment file/], ['customer/shop.db', 'x', /database/], ['customer/app.js.map', '{}', /source map/], ['customer/key.pem', 'x', /key or certificate/], ['customer/notes.txt', DB_URL, /database URL with a password/]]) {
      put(p.folder, { [rel]: content });
      assert.match(checkPackage(p.folder, { os: 'linux', kind: 'customer' }).problems.join('\n'), what, rel);
      rmSync(at(rel));
    }
  } finally { clean(p.root); }
});

test('THE website, as this program writes it, is assembled into one customer\'s website (the build service\'s way: settings, brand kit and logo) that passes the package check and the audit, and THE website itself is not changed', async () => {
  const p = make('linux');
  const root = tmp();
  try {
    const png = Buffer.concat([Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]), Buffer.alloc(32)]);
    put(root, { 'kit/brand.json': JSON.stringify({ schema: 1, name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', logo: 'logo.png', contact: { address: 'Rizal Ave, Quezon City, Philippines' }, storefront: { siteUrl: 'https://shop.luzonfresh.example' } }) });
    writeFileSync(join(root, 'logo.png'), png);
    const before = JSON.stringify(readdirSync(p.folder).sort());
    const folder = writeCustomerFolder(join(root, 'customer'), { kitFolder: join(root, 'kit'), values: SETTINGS, logo: join(root, 'logo.png') });
    assert.deepEqual(readdirSync(folder).sort(), ['assets', 'brand.json', 'website-settings.env']);
    const made = await assembleWebsite({ genericPackage: p.folder, customerFolder: folder, customer: 'luzon-fresh-mart', person: 'the build service', allowNoLicence: true, out: join(root, 'out'), packs: knownPacks() });
    assert.equal(made.name, 'website-luzon-fresh-mart-linux');
    assert.deepEqual(checkPackage(made.folder, { os: 'linux', kind: 'customer' }).problems, []);
    const a = spawnSync(process.execPath, [join(scripts, 'audit-package.mjs'), made.folder, made.zip, '--node-app', '--customer-package'], { encoding: 'utf8' });
    assert.equal(a.status, 0, a.stdout + a.stderr);
    const b = spawnSync(process.execPath, [join(scripts, 'audit-prerequisites.mjs'), made.folder, '--os', 'linux'], { encoding: 'utf8' });
    assert.equal(b.status, 0, b.stdout + b.stderr);
    const info = JSON.parse(readFileSync(join(made.folder, 'PACKAGE-INFO.json'), 'utf8'));
    assert.deepEqual([info.customer, info.name, info.generic, info.licenceIncluded], ['luzon-fresh-mart', 'Luzon Fresh Mart', false, false]);
    assert.equal(made.settings.country, 'PH');
    assert.equal(made.settings.shopPlace, 'Quezon City, Philippines');
    assert.equal(JSON.stringify(readdirSync(p.folder).sort()), before, 'THE website was not changed');
    assert.deepEqual(checkPackage(p.folder, { os: 'linux' }).problems, []);
    // a second customer from the same program: another name, another country, nothing of the first
    const second = writeCustomerFolder(join(root, 'second'), { values: { NEXT_PUBLIC_SITE_NAME: 'Second Shop', NEXT_PUBLIC_COUNTRY: 'GB' } });
    const made2 = await assembleWebsite({ genericPackage: p.folder, customerFolder: second, customer: 'second-shop', person: 'the build service', allowNoLicence: true, out: join(root, 'out'), packs: knownPacks() });
    assert.equal(made2.settings.country, 'GB');
    assert.doesNotMatch(readFileSync(join(made2.folder, 'READ ME FIRST.txt'), 'utf8') + readFileSync(join(made2.folder, 'PACKAGE-INFO.json'), 'utf8'), /Luzon|Quezon/);
    assert.deepEqual(readdirSync(join(made2.folder, 'customer')).sort(), ['website-settings.env']);
  } finally { clean(p.root, root); }
});

test('the zip holds the package under its own folder name, with the files that can be run marked so, and the audit passes it', async () => {
  const p = make('linux');
  try {
    const zip = join(p.out, `${p.name}.zip`);
    const count = await zipPackage(p.folder, zip);
    const names = listZip(readFileSync(zip));
    assert.equal(names.length, count);
    assert.ok(names.every((n) => n.startsWith('website-linux/')), 'everything is under one folder');
    for (const want of ['start-website.sh', 'node/bin/node', 'app/server.js', 'prerequisites.json', 'PACKAGE-INFO.json', 'READ ME FIRST.txt', 'customer-rules.mjs']) assert.ok(names.includes(`website-linux/${want}`), want);
    assert.ok(!names.some((n) => /\.(tsx?|map)$|\/\.env|\.ngos$/.test(n)), 'no source, map, .env or licence in the zip');
    const a = spawnSync(process.execPath, [join(scripts, 'audit-package.mjs'), zip, '--node-app'], { encoding: 'utf8' });
    assert.equal(a.status, 0, a.stdout + a.stderr);
    assert.match(a.stdout, /PASS\s+website-linux\.zip/);
  } finally { clean(p.root); }
});

// ---------------------------------------------------------------------------------------------------------------------

/** A package folder with the real start program and a stand-in server that only writes down what it was started with. */
function launcherFolder(files = {}) {
  const root = tmp();
  put(root, {
    'start-website.js': LAUNCHER, 'PACKAGE-INFO.json': JSON.stringify({ name: 'Luzon Fresh Mart', version: '1.2.3' }),
    'app/server.js': 'require("fs").writeFileSync(require("path").join(__dirname, "..", "seen.json"), JSON.stringify({ HOSTNAME: process.env.HOSTNAME, PORT: process.env.PORT, NODE_ENV: process.env.NODE_ENV, LICENCE_DIR: process.env.LICENCE_DIR, DATABASE_URL: process.env.DATABASE_URL, NEXT_PUBLIC_SITE_NAME: process.env.NEXT_PUBLIC_SITE_NAME, DEV: process.env.NGOS_DEV_UNLICENSED, ALREADY: process.env.ALREADY, CUSTOMER_DIR: process.env.NGOS_CUSTOMER_DIR, CWD: process.cwd() }));',
    ...files,
  });
  return root;
}
const freePort = () => new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); });
const start = (root, args, env = {}) => spawnSync(process.execPath, [join(root, 'start-website.js'), ...args], { cwd: root, encoding: 'utf8', timeout: 30000, env: { PATH: process.env.PATH, ...env } });
const seen = (root) => JSON.parse(readFileSync(join(root, 'seen.json'), 'utf8'));

test('the start program: listens on this computer only, in production mode, on the port asked for, and tells the person what to do', async () => {
  const root = launcherFolder();
  try {
    const port = await freePort();
    const r = start(root, [String(port)]);
    assert.equal(r.status, 0, r.stdout + r.stderr);
    const s = seen(root);
    assert.deepEqual([s.HOSTNAME, s.PORT, s.NODE_ENV], ['127.0.0.1', String(port), 'production']);
    assert.equal(s.LICENCE_DIR, join(root, 'licence'));
    assert.equal(s.CUSTOMER_DIR, join(root, 'customer'), 'the customer\'s settings are read from the folder beside the program');
    assert.ok(existsSync(join(root, 'licence')), 'the folder for the licence is made');
    assert.equal(s.CWD, join(root, 'app'));
    assert.match(r.stdout, new RegExp(`Luzon Fresh Mart \\(version 1\\.2\\.3\\)`));
    assert.match(r.stdout, new RegExp(`http://127\\.0\\.0\\.1:${port}`));
    assert.match(r.stdout, /close this window/);
    assert.match(r.stdout, /no licence yet.*\/admin\/licence/s);
    // With a licence file there, it does not say so.
    put(root, { 'licence/licence.ngos': 'a.b.c' });
    assert.doesNotMatch(start(root, ['--port', String(port)]).stdout, /no licence yet/);
    // Other computers only when asked.
    const open = start(root, [String(port), '--public']);
    assert.equal(seen(root).HOSTNAME, '0.0.0.0');
    assert.match(open.stdout, /Other computers can open it too/);
  } finally { clean(root); }
});

test('the start program reads private-settings.env but never lets it switch production off, skip the licence check, or change what is built in', async () => {
  const root = launcherFolder({
    'private-settings.env': ['# a comment', 'DATABASE_URL="postgres://user:secret@host/shop"', 'NODE_ENV=development', 'NGOS_DEV_UNLICENSED=1', 'NEXT_PUBLIC_SITE_NAME=Somebody Else', 'PORT=1', 'ALREADY=from the file', 'not a setting'].join('\r\n'),
  });
  try {
    const port = await freePort();
    const r = start(root, [String(port)], { ALREADY: 'from the computer' });
    assert.equal(r.status, 0, r.stdout + r.stderr);
    const s = seen(root);
    assert.equal(s.DATABASE_URL, 'postgres://user:secret@host/shop');
    assert.equal(s.NODE_ENV, 'production');
    assert.equal(s.DEV, undefined);
    assert.equal(s.NEXT_PUBLIC_SITE_NAME, undefined);
    assert.equal(s.PORT, String(port));
    assert.equal(s.ALREADY, 'from the computer', 'a setting of the computer wins over the file');
    assert.match(r.stdout, /Ignored in private-settings\.env.*NODE_ENV.*NGOS_DEV_UNLICENSED.*NEXT_PUBLIC_SITE_NAME.*PORT/);
  } finally { clean(root); }
});

test('the start program says in plain words what is wrong: an unknown word, a bad port, a port in use, an incomplete folder', async () => {
  const root = launcherFolder();
  const taken = net.createServer();
  try {
    let r = start(root, ['--nonsense']);
    assert.equal(r.status, 1);
    assert.match(r.stderr, /I do not understand "--nonsense"/);
    r = start(root, ['70000']);
    assert.equal(r.status, 1);
    assert.match(r.stderr, /from 1 to 65535/);
    const port = await new Promise((res) => taken.listen(0, '127.0.0.1', () => res(taken.address().port)));
    r = start(root, [String(port)]);
    assert.equal(r.status, 1);
    assert.match(r.stderr, new RegExp(`Port ${port} is already used by another program`));
    assert.match(r.stderr, /another port, for example 8080/);
    rmSync(join(root, 'app', 'server.js'));
    r = start(root, ['8080']);
    assert.equal(r.status, 1);
    assert.match(r.stderr, /not complete.*app\/server\.js/s);
  } finally { taken.close(); clean(root); }
});

test('the start scripts: the Linux one checks the machine and hands over to the bundled Node.js, the Windows one pauses on an error', () => {
  const root = tmp();
  try {
    writeFileSync(join(root, 's.sh'), START_SH);
    const syntax = spawnSync('sh', ['-n', join(root, 's.sh')], { encoding: 'utf8' });
    if (!syntax.error) assert.equal(syntax.status, 0, syntax.stderr);
    assert.match(START_SH, /^#!\/bin\/sh\n/);
    assert.match(START_SH, /exec \.\/node\/bin\/node start-website\.js "\$@"/);
    assert.match(START_SH, /uname -m/);
    assert.match(START_SH, /libssl\\\.so\\\.3/);
    assert.match(START_SH, /sudo apt install libssl3/);
    assert.ok(!START_SH.includes('\r'), 'a shell script has Unix line ends');
    assert.match(START_BAT, /"node\\node\.exe" "start-website\.js" %\*/);
    assert.match(START_BAT, /errorlevel 1 pause/);
    assert.match(START_BAT, /PROCESSOR_ARCHITECTURE/);
    for (const text of [START_SH, START_BAT, LAUNCHER]) assert.doesNotMatch(text, /AKIA|sk-|gsk_|BEGIN .*PRIVATE|password\s*=\s*['"][^'"]/i);
  } finally { clean(root); }
});

test('the README is plain: it says what to do, for the right system, and that nothing needs installing first', () => {
  for (const os of ['windows', 'linux']) {
    const text = readmeFor({ os, trial: false, version: '1.2.3', nodeVersion: 'v22.22.0' });
    assert.match(text, /Nothing has to be installed first/);
    assert.match(text, os === 'windows' ? /Double-click "Start Website"/ : /\.\/start-website\.sh --app/);
    assert.match(text, /no black terminal window|terminal can be closed at once/, 'it says there is no terminal to keep open');
    assert.doesNotMatch(text, /leave (it|the terminal) open/i);
    assert.match(text, /close its window/, 'it says how to stop it');
    assert.match(text, /http:\/\/127\.0\.0\.1:3000\/admin\/licence/);
    assert.match(text, /private-settings\.example\.env/);
    assert.ok(text.split('\n').slice(0, -1).every((l) => l.endsWith('\r')));
    assert.ok(text.split('\n').length < 60, 'a short page');
  }
});

// ---------------------------------------------------------------------------------------------------------------------

const run = (args) => spawnSync(process.execPath, [join(scripts, 'make-website-package.mjs'), ...args], { encoding: 'utf8', timeout: 60000 });

test('the command refuses, before it builds anything, what it cannot make: no arguments, another system than this computer, a bad name, bad settings', () => {
  const root = tmp();
  try {
    put(root, { 'good.env': 'NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart\nNEXT_PUBLIC_COUNTRY=PH\n', 'private.env': 'NEXT_PUBLIC_SITE_NAME=Shop\nDATABASE_URL=postgres://user:secret@host/shop\n', 'badcountry.env': 'NEXT_PUBLIC_SITE_NAME=Shop\nNEXT_PUBLIC_COUNTRY=ZZ\n' });
    const base = ['--os', hostOs, '--version', '1.0.0', '--out', join(root, 'out'), '--download-node', '22.22.0'];
    assert.equal(run([]).status, 2);
    assert.match(run(['--os', 'macos', '--version', '1.0.0']).stderr, /windows or --os linux/);
    assert.match(run(['--os', hostOs, '--version', '1.0']).stderr, /three numbers/);
    const other = run(['--os', otherOs, '--version', '1.0.0', '--customer', 'luzon', '--settings', join(root, 'good.env')]);
    assert.equal(other.status, 1);
    assert.match(other.stderr, new RegExp(`is built on a ${hostOs === 'windows' ? 'Linux' : 'Windows'} computer`));
    assert.match(run([...base, '--settings', join(root, 'good.env')]).stderr, /short name/);
    const generic = run(['--os', otherOs, '--version', '1.0.0']);
    assert.equal(generic.status, 1, 'the website for another system is refused whether or not a customer is named');
    assert.match(generic.stderr, new RegExp(`is built on a ${hostOs === 'windows' ? 'Linux' : 'Windows'} computer`));
    for (const id of ['../evil', 'a/b', 'A', '..']) { const r = run([...base, '--customer', id, '--settings', join(root, 'good.env')]); assert.equal(r.status, 1, id); assert.match(r.stderr, /short name/, id); }
    assert.match(run([...base, '--customer', 'luzon']).stderr, /Give the customer's public settings/);
    assert.match(run([...base, '--customer', 'luzon', '--settings', join(root, 'private.env')]).stderr, /DATABASE_URL is not a public setting/);
    assert.match(run([...base, '--customer', 'luzon', '--settings', join(root, 'badcountry.env')]).stderr, /no country pack for ZZ/);
    assert.match(run([...base, '--customer', 'luzon', '--settings', join(root, 'missing.env')]).stderr, /was not found/);
    assert.match(run([...base, '--kit', '../x']).stderr, /not a brand kit name/);
    assert.match(run([...base, '--kit', 'no-such-kit']).stderr, /no brand kit/);
    assert.ok(!existsSync(join(root, 'out')), 'nothing was made');
  } finally { clean(root); }
});

test('a symbolic link in the build cannot carry a file from outside into the package', () => {
  const b = fakeBuild('linux');
  const secret = join(b.root, 'outside.txt');
  try {
    writeFileSync(secret, 'host file');
    try { symlinkSync(secret, join(b.standalone, 'node_modules', 'next', 'link.txt')); } catch { return; }   // no permission to make links here: nothing to test
    const r = assemblePackage({ out: join(b.root, 'out'), os: 'linux', customer: 'luzon-fresh-mart', version: '1.0.0', settings: SETTINGS, standalone: b.standalone, staticDir: b.staticDir, publicDir: b.publicDir, node: b.node });
    const copied = join(r.folder, 'app', 'node_modules', 'next', 'link.txt');
    // The link is followed at the time of copying (the build's own files only): what is in the package is a plain file, never a link.
    assert.ok(!existsSync(copied) || !statSync(copied).isSymbolicLink());
  } finally { clean(b.root); }
});
