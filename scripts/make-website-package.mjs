#!/usr/bin/env node
/**
 * Makes the website for ONE customer as one folder and one zip that runs on a factory-new computer of its system with nothing installed first:
 * it carries its own Node.js, the built server, the static files, the libraries it needs and the native parts for that system.
 *
 *   node scripts/make-website-package.mjs --os windows|linux --version 1.0.0 --customer <short-name> --settings <website-settings.env>
 *        (--node-runtime <folder> | --download-node 22.22.0)  [--out dist] [--allow-no-key] [--deps-from <installed libraries>] [--logo <logo.png>]
 *   node scripts/make-website-package.mjs --os linux --version 1.0.0 --kit <brand-kits folder name> ...     (settings and logo come from the customer's brand kit)
 *
 *   --settings        the customer's public settings: the file the Setup Studio writes as website-settings.env (name, address, country, kind of business, place).
 *                     They are compiled into the website, which is why each customer needs a build of their own. No password or key may be in it.
 *   --kit             a folder name under brand-kits/: the settings and the logo are taken from its brand.json (a --settings file adds to them or overrides them).
 *   --customer        the short name used in the file names: website-<customer>-<os>.zip (letters, digits and hyphens). With --kit it defaults to the kit's name.
 *   --node-runtime    a folder with an official Node.js of that system already unpacked (node.exe, or bin/node)
 *   --download-node   fetches nodejs.org's own build of that version and checks it against nodejs.org's published SHA-256 list
 *   --deps-from       a node_modules folder that matches package-lock.json (saves the install on a developer's computer); without it the libraries are installed with "npm ci"
 *   --allow-no-key    only for trying the build: the licence keys are not built in, the website refuses every licence, and the package says so on its face
 *
 * What goes in: the website's built server and static files, the production libraries it needs (checked for their licences), Node.js, the start scripts, a plain README,
 * prerequisites.json and the EULA and notices. What never goes in: source (.ts, .tsx, .map), tests, .env files, keys, databases, a licence, the build tools' leftovers
 * (scripts/audit-package.mjs and scripts/audit-prerequisites.mjs check it, and this script stops when they find anything).
 *
 * A website is built on the system it is for (a Windows website on Windows, a Linux one on Linux): Prisma's database engine and the picture library are different files
 * for each system, and only a build on the real system can be started and tested there. The release workflow has a job for each.
 * The licence keys must already be built into src/lib/licence/defaults.ts (the workflow's "apply-public-keys" step); the licence check stays in force.
 */
import { createHash } from 'node:crypto';
import { spawnSync } from 'node:child_process';
import {
  chmodSync, copyFileSync, cpSync, existsSync, linkSync, mkdirSync, mkdtempSync, openSync, closeSync, readSync, readdirSync, readFileSync, readlinkSync,
  rmSync, statSync, symlinkSync, writeFileSync,
} from 'node:fs';
import { tmpdir } from 'node:os';
import { basename, dirname, join, relative, resolve, sep } from 'node:path';
import { fileURLToPath } from 'node:url';
import { auditFolder, findSecrets } from './audit-package.mjs';
import { auditPrerequisites } from './audit-prerequisites.mjs';
import { writeZipFile } from '../tools/setup-studio/lib/zip.mjs';
import { buildLauncher } from './lib/build-launcher.mjs';

const here = dirname(fileURLToPath(import.meta.url));
export const repo = resolve(here, '..');
export const appDir = join(repo, 'apps', 'storefront-web-mobile');

/** A problem a person can put right: it is said in plain words and the build stops. */
export class WebsiteError extends Error {}

export const SYSTEMS = ['windows', 'linux'];
export const TRIAL_FILE = 'NO-LICENCE-KEYS-TRIAL-ONLY.txt';

// ---------------------------------------------------------------------------------------------------------------------
// Names
// ---------------------------------------------------------------------------------------------------------------------

/**
 * The customer's short name, as it is used in file names: the same form as the Setup Studio's customer names (tools/setup-studio/lib/intake.mjs, SLUG) and the brand kits'.
 * Nothing that could leave the output folder, and nothing a file system treats specially.
 */
export function checkCustomer(id) {
  const text = String(id ?? '');
  if (!/^[a-z0-9][a-z0-9-]{0,39}[a-z0-9]$/.test(text)) {
    throw new WebsiteError(`"${text.slice(0, 60)}" cannot be used as the customer's short name. Use 2 to 41 small letters, digits and hyphens, for example luzon-fresh-mart.`);
  }
  return text;
}
export function checkSystem(os) {
  if (!SYSTEMS.includes(os)) throw new WebsiteError('Say the system the website is for: --os windows or --os linux.');
  return os;
}
export function checkVersion(version) {
  if (!/^\d+\.\d+\.\d+$/.test(String(version ?? ''))) throw new WebsiteError('Say the version as three numbers: --version 1.0.0');
  return String(version);
}
/** The folder and the zip of one customer's website for one system. The Setup Studio looks for this exact name (tools/setup-studio/lib/pack.mjs). */
export const packageName = (customer, os) => `website-${checkCustomer(customer)}-${checkSystem(os)}`;

// ---------------------------------------------------------------------------------------------------------------------
// The customer's public settings
// ---------------------------------------------------------------------------------------------------------------------

const plain = (max) => (v) => (v.length > max ? `is longer than ${max} letters` : /[<>\u0000-\u001f\u007f]/.test(v) ? 'has a character that is not allowed (< > or a control character)' : null);
const webAddress = (secure) => (v) => {
  let u;
  try { u = new URL(v); } catch { return 'is not a web address (write it like https://shop.example.com)'; }
  if (u.protocol !== 'https:' && !(u.protocol === 'http:' && !secure)) return secure ? 'must start with https://' : 'must start with http:// or https://';
  if (u.username || u.password) return 'must not hold a user name or a password';
  if (u.search || u.hash) return 'must not have a ? or a # part';
  return v.length > 200 ? 'is too long' : null;
};
const pattern = (re, example) => (v) => (re.test(v) ? null : `is not in the form ${example}`);

/**
 * The public settings the website knows (NEXT_PUBLIC_*: compiled into the pages every visitor receives). Anything else is refused: a private setting
 * (database address, password, key) belongs in private-settings.env on the computer that runs the website, never in the package.
 */
export const PUBLIC_SETTINGS = {
  NEXT_PUBLIC_SITE_NAME: { required: true, check: (v) => (v ? plain(80)(v) : 'is empty') },
  NEXT_PUBLIC_SITE_URL: { check: webAddress(false) },
  NEXT_PUBLIC_COUNTRY: { check: pattern(/^[A-Z]{2}$/, 'two capital letters, such as PH') },
  NEXT_PUBLIC_REGION_CODE: { check: pattern(/^[A-Z]{2}$/, 'two capital letters, such as PH') },
  NEXT_PUBLIC_INDUSTRY: { check: pattern(/^[a-z][a-z-]{1,30}$/, 'small letters, such as retail') },
  NEXT_PUBLIC_SHOP_PLACE: { check: plain(120) },
  NEXT_PUBLIC_SUPABASE_URL: { check: webAddress(true) },
  NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY: { check: (v) => (/^sb_publishable_[A-Za-z0-9_-]{10,}$/.test(v) ? null : 'must be the publishable key (sb_publishable_...). A secret key is never put in a website') },
  NEXT_PUBLIC_SUPABASE_ANON_KEY: {
    check: (v) => {
      const m = /^eyJ[\w-]+\.([\w-]+)\.[\w-]+$/.exec(v);
      if (!m) return 'is not a public (anon) key';
      try { return JSON.parse(Buffer.from(m[1], 'base64url').toString()).role === 'anon' ? null : 'is not the public (anon) key: a key with another role is never put in a website'; } catch { return 'is not a public (anon) key'; }
    },
  },
  NEXT_PUBLIC_FIREBASE_API_KEY: { check: pattern(/^[A-Za-z0-9_-]{20,60}$/, 'the web API key from the Firebase console') },
  NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN: { check: pattern(/^[a-z0-9.-]{4,100}$/, 'a host name') },
  NEXT_PUBLIC_FIREBASE_PROJECT_ID: { check: pattern(/^[a-z0-9-]{4,40}$/, 'a project id') },
  NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET: { check: pattern(/^[a-z0-9._-]{4,100}$/, 'a bucket name') },
  NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID: { check: pattern(/^\d{4,20}$/, 'a number') },
  NEXT_PUBLIC_FIREBASE_APP_ID: { check: pattern(/^\d+:\d+:web:[a-f0-9]+$/, '1:123:web:abc') },
  NEXT_PUBLIC_CLOUDINARY_CLOUD_NAME: { check: pattern(/^[A-Za-z0-9_-]{2,60}$/, 'a cloud name') },
  NEXT_PUBLIC_CLOUDINARY_API_KEY: { check: pattern(/^\d{6,20}$/, 'a number') },
};

/** The country and industry packs this repository knows (a website for a country that has no pack would silently use the wrong money and dates). */
export function knownPacks(root = repo) {
  const names = (dir) => (existsSync(dir) ? readdirSync(dir).filter((f) => f.endsWith('.json')).map((f) => f.slice(0, -5)) : null);
  return { countries: names(join(root, 'country-packs', 'packs')), industries: names(join(root, 'industry-packs', 'packs')) };
}

/**
 * Reads the text of a settings file (KEY=value lines, # comments, CRLF or LF, a value may be in quotes).
 * Returns { values, problems }: every problem is a sentence a person can act on; nothing is built while there is one.
 */
export function parseSettings(text, { countries = null, industries = null, requireName = true } = {}) {
  const values = {};
  const problems = [];
  String(text ?? '').split(/\r?\n/).forEach((raw, i) => {
    const line = raw.replace(/^\uFEFF/, '').trim();
    if (!line || line.startsWith('#')) return;
    const at = `Line ${i + 1}`;
    const m = /^([A-Za-z_][A-Za-z0-9_]*)\s*=\s*(.*)$/.exec(line);
    if (!m) { problems.push(`${at} is not a setting. Write one setting per line, like NEXT_PUBLIC_SITE_NAME=My Shop.`); return; }
    const key = m[1];
    let value = m[2].trim();
    if (/^(".*"|'.*')$/.test(value) && value.length >= 2) value = value.slice(1, -1);
    if (!key.startsWith('NEXT_PUBLIC_')) {
      problems.push(`${at}: ${key} is not a public setting. Passwords, keys and the database address never go into the website package: they go in private-settings.env on the computer that runs the website.`);
      return;
    }
    const rule = PUBLIC_SETTINGS[key];
    if (!rule) { problems.push(`${at}: ${key} is not a setting this website knows.`); return; }
    if (key in values) { problems.push(`${at}: ${key} is written twice.`); return; }
    const why = value === '' && !rule.required ? null : rule.check(value);
    if (why) { problems.push(`${at}: ${key} ${why}.`); return; }
    const secret = findSecrets(value);
    if (secret.length) {
      problems.push(`${at}: ${key} looks like a secret key (${secret.join(', ')}). The package check refuses any value that looks like a key, so it cannot be put in a website.`);
      return;
    }
    if (value !== '') values[key] = value;
  });
  if (requireName) for (const [key, rule] of Object.entries(PUBLIC_SETTINGS)) if (rule.required && !values[key]) problems.push(`${key} is missing: the website needs the shop's name.`);
  if (values.NEXT_PUBLIC_COUNTRY && countries && !countries.includes(values.NEXT_PUBLIC_COUNTRY)) problems.push(`NEXT_PUBLIC_COUNTRY: there is no country pack for ${values.NEXT_PUBLIC_COUNTRY} (the packs are: ${countries.join(', ')}).`);
  if (values.NEXT_PUBLIC_INDUSTRY && industries && !industries.includes(values.NEXT_PUBLIC_INDUSTRY)) problems.push(`NEXT_PUBLIC_INDUSTRY: there is no industry pack called ${values.NEXT_PUBLIC_INDUSTRY} (the packs are: ${industries.join(', ')}).`);
  return { values, problems };
}

/** The public settings a brand kit gives (brand-kits/<name>/brand.json): the same fields the Setup Studio writes into website-settings.env. */
export function settingsFromKit(kitFolder) {
  const file = join(kitFolder, 'brand.json');
  if (!existsSync(file)) throw new WebsiteError(`There is no brand kit at ${kitFolder} (it needs a brand.json).`);
  let brand;
  try { brand = JSON.parse(readFileSync(file, 'utf8')); } catch { throw new WebsiteError(`${file} cannot be read as JSON.`); }
  const out = {};
  if (brand.name) out.NEXT_PUBLIC_SITE_NAME = String(brand.name);
  if (brand.storefront?.siteUrl) out.NEXT_PUBLIC_SITE_URL = String(brand.storefront.siteUrl);
  if (brand.country) out.NEXT_PUBLIC_COUNTRY = String(brand.country);
  if (brand.industry) out.NEXT_PUBLIC_INDUSTRY = String(brand.industry);
  const place = String(brand.contact?.address ?? '').split(',').slice(-2).join(',').trim();
  if (place) out.NEXT_PUBLIC_SHOP_PLACE = place;
  const logo = brand.logo && /^[\w.-]+\.png$/i.test(String(brand.logo)) && existsSync(join(kitFolder, String(brand.logo))) ? join(kitFolder, String(brand.logo)) : null;
  return { values: out, logo, text: Object.entries(out).map(([k, v]) => `${k}=${v}`).join('\n') };
}

/** Whether a file is a real PNG picture of a sensible size (the website refers to its logo as /logo.png). */
export function checkLogo(file) {
  const bytes = statSync(file).size;
  const head = Buffer.alloc(8);
  const fd = openSync(file, 'r');
  try { readSync(fd, head, 0, 8, 0); } finally { closeSync(fd); }
  if (!head.equals(Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]))) throw new WebsiteError(`${file} is not a PNG picture. The website's logo must be a PNG.`);
  if (bytes > 3 * 1024 * 1024) throw new WebsiteError(`${file} is bigger than 3 MB. Use a smaller logo.`);
}

// ---------------------------------------------------------------------------------------------------------------------
// Licence keys (public) built into the website, and the libraries' licences
// ---------------------------------------------------------------------------------------------------------------------

/** How many public licence keys, and which Studio address, are built into src/lib/licence/defaults.ts of this copy of the website. */
export function keysBuiltIn(app) {
  const file = join(app, 'src', 'lib', 'licence', 'defaults.ts');
  if (!existsSync(file)) throw new WebsiteError(`${file} is missing: this is not the website's folder.`);
  const text = readFileSync(file, 'utf8');
  const count = (text.match(/["']?publicKey["']?\s*:\s*"[A-Za-z0-9+/=_-]{20,}"/g) || []).length;
  const url = /LICENCE_SERVER_URL\s*=\s*"([^"]*)"/.exec(text)?.[1] || '';
  return { count, url };
}

const OK_LICENCES = new Set(['MIT', 'MIT-0', 'ISC', 'BSD', 'BSD-2-Clause', 'BSD-3-Clause', '0BSD', 'Apache-2.0', 'BlueOak-1.0.0', 'CC0-1.0', 'CC-BY-4.0', 'Unlicense', 'Python-2.0', 'Zlib', 'WTFPL', 'Artistic-2.0']);
/** Licences that allow proprietary redistribution only under conditions, and the libraries NextGenOS has looked at (THIRD-PARTY-NOTICES.md, "The website package"). */
export const LICENCE_EXCEPTIONS = [
  [/^@img\/sharp-(libvips-)?/, /^(LGPL-3\.0-or-later|LGPL-3\.0|Apache-2\.0 AND LGPL-3\.0-or-later)$/, 'the picture library (libvips, LGPL: a separate file the user can replace)'],
  [/^lightningcss$/, /^MPL-2\.0$/, 'a style compiler, unchanged (MPL-2.0)'],
];

/** Each library's licence, read from its package.json. A licence that forbids proprietary redistribution (GPL, AGPL, SSPL, non-commercial), and a library with none, is a problem. */
export function licenceProblems(modules) {
  const problems = [];
  const walk = (nm) => {
    if (!existsSync(nm)) return;
    for (const e of readdirSync(nm, { withFileTypes: true })) {
      if (!e.isDirectory() || e.name.startsWith('.')) continue;
      const dir = join(nm, e.name);
      if (e.name.startsWith('@')) { walk(dir); continue; }
      const file = join(dir, 'package.json');
      if (existsSync(file)) {
        let pkg = null;
        try { pkg = JSON.parse(readFileSync(file, 'utf8')); } catch { /* reported below */ }
        const name = pkg?.name || relative(modules, dir).split(sep).join('/');
        const raw = pkg ? (typeof pkg.license === 'string' ? pkg.license : pkg.license?.type || (Array.isArray(pkg.licenses) ? pkg.licenses.map((l) => l.type).join(' OR ') : '')) : '';
        const text = String(raw || '').trim();
        const special = LICENCE_EXCEPTIONS.find(([who, what]) => who.test(name) && what.test(text));
        // "(A OR B)" is fine when one of them is; "A AND B" only when both are.
        const alternatives = text.replace(/[()]/g, '').split(/\s+OR\s+/i).map((alt) => alt.split(/\s+AND\s+/i).map((x) => x.trim()));
        const fine = alternatives.some((all) => all.every((l) => OK_LICENCES.has(l)));
        if (!special && !fine) problems.push(`${relative(modules, dir).split(sep).join('/')} (${name}) has the licence "${text || 'none stated'}", which is not on the list of licences that allow proprietary redistribution`);
      }
      walk(join(dir, 'node_modules'));
    }
  };
  walk(modules);
  return problems;
}

// ---------------------------------------------------------------------------------------------------------------------
// Node.js
// ---------------------------------------------------------------------------------------------------------------------

const sha256 = (buf) => createHash('sha256').update(buf).digest('hex');
const nodeFile = (os) => (os === 'windows' ? 'node.exe' : join('bin', 'node'));
const hostOs = () => (process.platform === 'win32' ? 'windows' : process.platform === 'linux' ? 'linux' : null);

function extract(file, into) {
  const tar = process.platform === 'win32' ? join(process.env.SystemRoot || 'C:\\Windows', 'System32', 'tar.exe') : 'tar';
  const r = file.endsWith('.zip') && process.platform !== 'win32' ? spawnSync('unzip', ['-q', file, '-d', into], { encoding: 'utf8' }) : spawnSync(tar, ['-xf', file, '-C', into], { encoding: 'utf8' });
  if (r.error || r.status !== 0) throw new WebsiteError(`Node.js could not be unpacked (${r.error?.message || (r.stderr || '').slice(0, 300)}). The unpacking needs ${file.endsWith('.zip') ? 'unzip or Windows tar' : 'tar and xz'}.`);
}

/**
 * The Node.js to carry: { root, version }. A folder that was given is used as it is; --download-node fetches nodejs.org's own build and checks it against nodejs.org's
 * published SHA-256 list (the download is kept in cacheDir, and checked again against the list every time).
 */
export async function nodeRuntime({ os, given = null, download = null, work, cacheDir = join(tmpdir(), 'ngos-node-cache') }) {
  if (given) {
    const root = resolve(given);
    if (!existsSync(join(root, nodeFile(os)))) throw new WebsiteError(`${join(root, nodeFile(os))} was not found. Give the folder of an unpacked official Node.js for ${os}.`);
    let version = null;
    if (hostOs() === os) { const r = spawnSync(join(root, nodeFile(os)), ['--version'], { encoding: 'utf8' }); version = r.status === 0 ? r.stdout.trim() : null; }
    return { root, version };
  }
  if (!download || !/^\d+\.\d+\.\d+$/.test(download)) throw new WebsiteError('Say which Node.js to carry: --node-runtime <folder> or --download-node 22.22.0');
  const arch = os === 'windows' ? 'win-x64' : 'linux-x64';
  const name = `node-v${download}-${arch}.${os === 'windows' ? 'zip' : 'tar.xz'}`;
  const base = `https://nodejs.org/dist/v${download}`;
  const sums = await fetch(`${base}/SHASUMS256.txt`);
  if (!sums.ok) throw new WebsiteError(`nodejs.org's list of fingerprints could not be fetched (${sums.status}).`);
  const want = (await sums.text()).split('\n').map((l) => l.trim().split(/\s+/)).find((p) => p[1] === name)?.[0];
  if (!want) throw new WebsiteError(`nodejs.org's list has no ${name}.`);
  mkdirSync(cacheDir, { recursive: true });
  const cached = join(cacheDir, name);
  let buf = existsSync(cached) ? readFileSync(cached) : null;
  if (buf && sha256(buf) !== want) buf = null;
  if (!buf) {
    const res = await fetch(`${base}/${name}`);
    if (!res.ok) throw new WebsiteError(`${name} could not be downloaded (${res.status}).`);
    buf = Buffer.from(await res.arrayBuffer());
    if (sha256(buf) !== want) throw new WebsiteError(`${name} does not match nodejs.org's published fingerprint. It is not used.`);
    writeFileSync(cached, buf);
  }
  const into = join(work, 'node-runtime');
  mkdirSync(into, { recursive: true });
  extract(cached, into);
  return { root: join(into, `node-v${download}-${arch}`), version: `v${download}` };
}

// ---------------------------------------------------------------------------------------------------------------------
// Building the website
// ---------------------------------------------------------------------------------------------------------------------

/** What a build may see of this computer: its tools and its temporary folder, and the public settings. Nothing else (no database address, no key, no licence) can end up in the pages. */
export function buildEnvironment(settings, extra = {}) {
  const keep = /^(PATH|HOME|USER|LOGNAME|SHELL|TERM|USERPROFILE|USERNAME|USERDOMAIN|COMPUTERNAME|APPDATA|LOCALAPPDATA|HOMEDRIVE|HOMEPATH|ALLUSERSPROFILE|TEMP|TMP|TMPDIR|SYSTEMROOT|SYSTEMDRIVE|WINDIR|COMSPEC|PATHEXT|OS|PSMODULEPATH|PROGRAMFILES|PROGRAMFILES\(X86\)|PROGRAMW6432|PROGRAMDATA|COMMONPROGRAMFILES|NUMBER_OF_PROCESSORS|PROCESSOR_[A-Z0-9_]+|LANG|LC_ALL|CI|NODE_EXTRA_CA_CERTS|SSL_CERT_FILE|HTTPS?_PROXY|NO_PROXY|NPM_CONFIG_[A-Z_]+)$/i;
  const env = {};
  for (const [k, v] of Object.entries(process.env)) if (keep.test(k)) env[k] = v;
  return { ...env, ...settings, NODE_ENV: 'production', NEXT_TELEMETRY_DISABLED: '1', PRISMA_HIDE_UPDATE_MESSAGE: '1', CHECKPOINT_DISABLE: '1', NODE_OPTIONS: '--max-old-space-size=4096', ...extra };
}

const SKIP_TOP = new Set(['node_modules', '.next', 'android', 'android-shell', 'assets', '.vscode', 'dist-electron', 'releases', 'coverage', 'out', 'build', 'tmp', '.git', '.vercel', '.licence']);
const GENERATED_PUBLIC = /^public[\\/](sw\.js(\.map)?|swe-worker-[^\\/]+\.js|workbox-[^\\/]+\.js|version\.json)$/;

/** Copies the website's source into a build folder, leaving out what is generated, what is for the phone app, and anything private (.env files, a licence). */
export function copyAppSource(from, to) {
  cpSync(from, to, {
    recursive: true,
    filter: (path) => {
      const rel = relative(from, path);
      if (!rel) return true;
      const top = rel.split(sep)[0];
      if (SKIP_TOP.has(top) || top.startsWith('.env') || top === 'tsconfig.tsbuildinfo' || top === 'next-env.d.ts') return false;
      if (GENERATED_PUBLIC.test(rel)) return false;
      if (/(^|[\\/])(licence\.ngos|crl\.ngos|install-id)$/.test(rel) || /\.(ngoslic|ngos)$/.test(rel)) return false;
      return true;
    },
  });
}

/** Hard-links an installed node_modules folder into the build folder (no second copy on the disk); the database library, which the build rewrites, is copied for real. */
export function linkLibraries(from, to) {
  const copied = new Set(['.prisma', '@prisma']);
  const link = (src, dest) => {
    mkdirSync(dest, { recursive: true });
    for (const e of readdirSync(src, { withFileTypes: true })) {
      const a = join(src, e.name);
      const b = join(dest, e.name);
      if (e.isDirectory()) link(a, b);
      else if (e.isSymbolicLink()) symlinkSync(readlinkSync(a), b);
      else if (e.isFile()) { try { linkSync(a, b); } catch { copyFileSync(a, b); } }
    }
  };
  mkdirSync(to, { recursive: true });
  for (const e of readdirSync(from, { withFileTypes: true })) {
    if (e.name === '.cache') continue;
    if (copied.has(e.name)) cpSync(join(from, e.name), join(to, e.name), { recursive: true });
    else if (e.isDirectory()) link(join(from, e.name), join(to, e.name));
    else if (e.isSymbolicLink()) symlinkSync(readlinkSync(join(from, e.name)), join(to, e.name));
    else if (e.isFile()) { try { linkSync(join(from, e.name), join(to, e.name)); } catch { copyFileSync(join(from, e.name), join(to, e.name)); } }
  }
}

/** Installed libraries must be the ones package-lock.json names, or the website would be built from something nobody reviewed. */
export function librariesMatchLock(app, modules) {
  const hidden = join(modules, '.package-lock.json');
  if (!existsSync(hidden)) throw new WebsiteError(`${modules} has no .package-lock.json: it was not installed with npm ci. Install the libraries first (cd apps/storefront-web-mobile && npm ci), or leave out --deps-from.`);
  const want = JSON.parse(readFileSync(join(app, 'package-lock.json'), 'utf8')).packages || {};
  const have = JSON.parse(readFileSync(hidden, 'utf8')).packages || {};
  const off = Object.entries(have).filter(([k, v]) => k && (!want[k] || want[k].version !== v.version)).map(([k]) => k);
  if (off.length) throw new WebsiteError(`The installed libraries do not match package-lock.json (${off.slice(0, 4).join(', ')}${off.length > 4 ? ', ...' : ''}). Run npm ci in apps/storefront-web-mobile and try again.`);
}

function run(cmd, args, opts = {}) {
  const r = spawnSync(cmd, args, { encoding: 'utf8', maxBuffer: 256 * 1024 * 1024, ...opts });
  if (r.error || r.status !== 0) throw new WebsiteError(`${basename(cmd)} ${args.map((a) => basename(a)).join(' ')} stopped.\n${r.error?.message ?? ''}${(r.stdout || '').slice(-3500)}${(r.stderr || '').slice(-3500)}`);
  return r.stdout || '';
}

/**
 * Builds the website in a copy of its folder (the repository is not touched) and returns where the pieces are: { standalone, staticDir, publicDir, keys }.
 * The libraries come from --deps-from (hard-linked) or from "npm ci"; the database library is made for THIS system; the pages are built with the customer's public settings only.
 */
export function buildWebsite({ work, settings, source = appDir, depsFrom = null, logo = null, allowNoKey = false, log = () => {} }) {
  const app = join(work, 'app');
  log('Copying the website\'s source into a build folder');
  copyAppSource(source, app);
  if (logo) { checkLogo(logo); copyFileSync(logo, join(app, 'public', 'logo.png')); }

  const keys = keysBuiltIn(app);
  if ((keys.count === 0 || !keys.url) && !allowNoKey) {
    throw new WebsiteError('The licence keys are not built into the website yet (src/lib/licence/defaults.ts has no key or no Studio address).\nA website made now would refuse every licence. Build them in first:\n  node licensing/studio/src/cli.js apply-public-keys --keys @keys.json --url https://your-studio-address\n(Only to try the build: add --allow-no-key.)');
  }
  console.log(keys.count ? `Licence keys built in: ${keys.count}; Studio address ${keys.url}` : 'WARNING: no licence key is built in (--allow-no-key): this website refuses every licence.');

  const modules = join(app, 'node_modules');
  if (depsFrom) {
    log('Linking the installed libraries');
    librariesMatchLock(source, resolve(depsFrom));
    linkLibraries(resolve(depsFrom), modules);
  } else {
    log('Installing the libraries (npm ci)');
    run(process.platform === 'win32' ? 'npm.cmd' : 'npm', ['ci', '--ignore-scripts', '--no-audit', '--no-fund', '--prefer-offline'], { cwd: app, env: buildEnvironment({}, { NODE_ENV: 'development' }), shell: process.platform === 'win32' });
  }

  const env = buildEnvironment(settings, { NGOS_PACKAGE_BUILD: '1' });
  log('Making the database library for this system (Prisma)');
  run(process.execPath, [join(modules, 'prisma', 'build', 'index.js'), 'generate', '--schema', join(app, 'prisma', 'schema.prisma')], { cwd: app, env });
  run(process.execPath, [join(app, 'scripts', 'generate-version.js')], { cwd: app, env });
  log('Building the website (next build); this takes a few minutes');
  run(process.execPath, [join(modules, 'next', 'dist', 'bin', 'next'), 'build'], { cwd: app, env });

  const standalone = join(app, '.next', 'standalone');
  if (!existsSync(join(standalone, 'server.js'))) throw new WebsiteError('The build did not make a server folder (.next/standalone/server.js is missing).');
  return { standalone, staticDir: join(app, '.next', 'static'), publicDir: join(app, 'public'), keys };
}

// ---------------------------------------------------------------------------------------------------------------------
// The package
// ---------------------------------------------------------------------------------------------------------------------

/** Which picture library parts belong to which system. Everything else under @img is for another system and goes. */
const PICTURE_PARTS = { linux: ['sharp-linux-x64', 'sharp-libvips-linux-x64'], windows: ['sharp-win32-x64'] };
const REMOVE_FILES = /\.(tsx?|jsx|map|log|bak)$/i;   // includes .d.ts: source and type files are not part of a running program

/** Takes out of the server folder what is not for this system or not part of a running program. Returns what was removed. */
export function pruneApp(app, os) {
  const removed = { other: [], files: 0 };
  const img = join(app, 'node_modules', '@img');
  if (existsSync(img)) {
    for (const e of readdirSync(img)) {
      if (e === 'colour' || PICTURE_PARTS[os].includes(e)) continue;
      rmSync(join(img, e), { recursive: true, force: true });
      removed.other.push(`@img/${e}`);
    }
  }
  const walk = (dir) => {
    for (const e of readdirSync(dir, { withFileTypes: true })) {
      const full = join(dir, e.name);
      if (e.isDirectory()) walk(full);
      else if (REMOVE_FILES.test(e.name)) { rmSync(full, { force: true }); removed.files += 1; }
    }
  };
  walk(app);
  return removed;
}

/** The text of prerequisites.json: what the package carries and what it relies on the machine for (docs/PREREQUISITES.md). */
export function prerequisitesFor(os, nodeVersion = null) {
  return {
    schema: 1, os, arch: 'x64',
    bundled: ['nodejs-runtime (an official build, checked against nodejs.org\'s fingerprint)', 'the built website and its static files', 'native-libraries (database engine, picture library)', 'every library the website uses'],
    system: os === 'windows' ? ['windows-10-22h2-or-11-x64', 'windows-system-dlls'] : ['glibc-2.35-or-newer', 'libstdc++6-libgcc-s1', 'openssl-3'],
    ...(os === 'windows' ? { launchers: ['Start Website.exe'] } : {}),
    minimumSystem: os === 'windows' ? 'Windows 10 (22H2) or Windows 11, 64-bit Intel/AMD; or Windows Server 2019 or later' : 'Ubuntu 22.04 or 24.04, Linux Mint 21 or later, Debian 12 or later; 64-bit Intel/AMD',
    ...(nodeVersion ? { node: nodeVersion } : {}),
  };
}

const CRLF = (lines) => lines.join('\r\n') + '\r\n';

/** The private settings the person who runs the website fills in (never in the package: this file is only a list of names, with no value). */
export function privateSettingsExample(os) {
  const keyCommand = os === 'windows' ? 'node\\node.exe -e "console.log(require(\'crypto\').randomBytes(32).toString(\'base64\'))"' : './node/bin/node -e "console.log(require(\'crypto\').randomBytes(32).toString(\'base64\'))"';
  return CRLF([
    '# Private settings for this website.',
    '# Copy this file to "private-settings.env" (in this same folder) and fill in what you use.',
    '# That file holds passwords and keys: keep it on this computer only. Never e-mail it, and never put it in a zip you share.',
    '# The shop\'s name, address, country and kind of business are already inside the website; they are not set here.',
    '',
    '# Where the website keeps its products and pages: a PostgreSQL database with the "vector" add-on (for example from Supabase or Neon).',
    'DATABASE_URL=',
    'DIRECT_URL=',
    '',
    '# Who may open the admin pages before any staff member exists (e-mail addresses, separated by commas; each must sign in with a verified e-mail).',
    'OWNER_ADMIN_EMAILS=',
    '',
    '# Locks the AI service keys that are kept in the database. Make one with this command and paste the answer:',
    `#   ${keyCommand}`,
    '# Keep it only here. If it is lost, the AI service keys must be typed in again.',
    'NGOS_DATA_KEY=',
    '',
    '# The licence. Normally leave this out: put the licence file in the folder "licence", or type the key on the page /admin/licence.',
    '# NGOS_LICENCE=',
    '',
    '# Set this to 1 when a web server (nginx, Caddy, IIS) sits in front of this website and passes on the real web address.',
    '# NGOS_TRUST_PROXY=1',
    '',
    '# Pictures (Cloudinary).',
    'CLOUDINARY_CLOUD_NAME=',
    'CLOUDINARY_API_KEY=',
    'CLOUDINARY_API_SECRET=',
    '',
    '# Sign-in for staff (a Firebase service account).',
    'FIREBASE_PROJECT_ID=',
    'FIREBASE_CLIENT_EMAIL=',
    'FIREBASE_PRIVATE_KEY=',
    '',
    '# The AI assistant (use the services you have).',
    'GROQ_API_KEY=',
    'GEMINI_API_KEY_1=',
    'LIGHTNING_API_KEY=',
    '',
    '# Faster answers (optional).',
    'UPSTASH_REDIS_REST_URL=',
    'UPSTASH_REDIS_REST_TOKEN=',
  ]);
}

/**
 * The program that starts the website (scripts/website-launcher.cjs, written into the package as start-website.js). It runs with the Node.js that is inside the package. Plain words,
 * because the person who reads them is a shop owner or the person who looks after the shop's computer. It never changes a setting that decides what the website is allowed to do:
 * the production mode is set there. With --app it opens the website as a program of its own (see scripts/lib/app-window.mjs).
 */
export const LAUNCHER = readFileSync(join(here, 'website-launcher.cjs'), 'utf8');

export const START_BAT_NAME = 'Start Website (with a window, for problems).bat';
export const START_BAT = CRLF([
  '@echo off',
  'rem Starts the website in this window, which shows what it says: for finding a problem, or for the person who looks after the website\'s computer.',
  'rem The normal way to open the website is "Start Website" (the icon), which has no such window and opens the website as a program of its own.',
  'rem It carries its own Node.js: nothing has to be installed first.',
  'rem   Start Website (with a window, for problems).bat            starts it on this computer, at http://127.0.0.1:3000',
  'rem   Start Website (with a window, for problems).bat 8080       starts it on another port',
  'rem   Start Website (with a window, for problems).bat --public   lets other computers open it too',
  'cd /d "%~dp0"',
  'if /i not "%PROCESSOR_ARCHITECTURE%"=="AMD64" if /i not "%PROCESSOR_ARCHITEW6432%"=="AMD64" (',
  '  echo This website needs a 64-bit Windows PC with an Intel or AMD processor. This computer is not one.',
  '  pause',
  '  exit /b 1',
  ')',
  '"node\\node.exe" "start-website.js" %*',
  'if errorlevel 1 pause',
]);

export const START_SH = `#!/bin/sh
# Starts the website. It carries its own Node.js: nothing has to be installed first.
#   ./start-website.sh --app            opens the website as a program of its own (a window, no terminal); this terminal can be closed at once. Closing the window stops it.
#   ./start-website.sh --install-menu   puts "Smart Retail POS website" in the applications menu, so it opens like any other program
#   ./start-website.sh                  starts it in this terminal, on this computer, at http://127.0.0.1:3000 (for the person who looks after the website's computer)
#   ./start-website.sh 8080             starts it on another port
#   ./start-website.sh --public         lets other computers open it too
here="$(cd "$(dirname "$0")" && pwd)" || exit 1
cd "$here" || exit 1
# The customer's short name is in PACKAGE-INFO.json (nothing about a customer is written in this program).
customer="$(sed -n 's/.*"customer": *"\\([a-z0-9-]*\\)".*/\\1/p' PACKAGE-INFO.json 2> /dev/null | head -n 1)"
[ -n "$customer" ] || customer=website
note="\${XDG_CONFIG_HOME:-$HOME/.config}/nextgenos-website/$customer"
# A problem is said in the terminal, and, when there is no terminal (--app), written in a note that opens by itself.
problem() {
  echo "$1"
  if [ "$app" = yes ]; then
    mkdir -p "$note" 2> /dev/null
    printf '%s\\n' 'The website could not start.' '' "$1" > "$note/Website problem.txt"
    command -v xdg-open > /dev/null 2>&1 && xdg-open "$note/Website problem.txt" > /dev/null 2>&1 &
  fi
  exit 1
}
app=no
case "\${1:-}" in
  --install-menu)
    dir="\${XDG_DATA_HOME:-$HOME/.local/share}/applications"
    mkdir -p "$dir" || exit 1
    cat > "$dir/nextgenos-website-$customer.desktop" <<DESKTOP
[Desktop Entry]
Type=Application
Name=Smart Retail POS website ($customer)
Comment=The online shop, as a program of its own
Exec="$here/start-website.sh" --app
Terminal=false
Categories=Office;
DESKTOP
    echo "Done. The website is now in your applications menu: Smart Retail POS website ($customer)"
    exit 0 ;;
  --app) app=yes ;;
esac
case "$(uname -m)" in
  x86_64|amd64) ;;
  *) problem "This website is made for 64-bit Intel or AMD computers. This computer is a $(uname -m)." ;;
esac
# The website's database part needs OpenSSL 3, which Ubuntu 22.04 and later and Debian 12 and later have.
found=no
for f in /lib/libssl.so.3 /lib64/libssl.so.3 /usr/lib/libssl.so.3 /usr/lib64/libssl.so.3 /lib/*/libssl.so.3 /usr/lib/*/libssl.so.3; do
  if [ -e "$f" ]; then found=yes; fi
done
if [ "$found" = no ] && { /sbin/ldconfig -p 2> /dev/null || ldconfig -p 2> /dev/null; } | grep -q 'libssl\\.so\\.3'; then found=yes; fi
if [ "$found" = no ]; then
  problem "This computer does not have OpenSSL 3, which the website's database part needs. On Ubuntu, Linux Mint or Debian, open a terminal and type:  sudo apt install libssl3"
fi
if [ "$app" = yes ]; then
  # Started so that the terminal (or the file manager) can be closed at once; what it says goes to a log.
  mkdir -p "$note" 2> /dev/null
  nohup ./node/bin/node start-website.js "$@" > "$note/website.log" 2>&1 &
  exit 0
fi
exec ./node/bin/node start-website.js "$@"
`;

/** The page of steps for the shop owner or the person who looks after the computer. */
export function readmeFor({ name, os, customer, trial, version, nodeVersion }) {
  const windows = os === 'windows';
  const start = windows ? 'Start Website (with a window, for problems).bat' : './start-website.sh';
  return CRLF([
    ...(trial ? ['*** TRIAL BUILD, NO LICENCE KEYS ***', 'This website was made without the licence keys. It can never be licensed: it only shows the page "not available". It is for trying the start-up only.', 'Never give it to a customer.', ''] : []),
    `${name}: the website`,
    '='.repeat(`${name}: the website`.length),
    '',
    `This folder holds the website of ${name}, ready to run (version ${version}). Nothing has to be installed first: it carries its own copy of everything it needs${nodeVersion ? ` (Node.js ${nodeVersion})` : ''}.`,
    windows ? 'It is for Windows 10 (22H2) or Windows 11, 64-bit.' : 'It is for Ubuntu 22.04 or 24.04, Linux Mint 21 or later, or Debian 12 or later, 64-bit Intel/AMD.',
    '',
    'WHAT YOU NEED BESIDES THIS FOLDER',
    '  - The licence for this website: the licence key, or the licence file, from NextGenOS. It is tied to the website\'s web address.',
    '  - The website\'s own accounts: a database (PostgreSQL), and the picture storage, sign-in and AI services you use. They are listed in private-settings.example.env.',
    '',
    'TO TRY IT (about 5 minutes)',
    windows ? '  1. Unpack the zip into a folder you may write to, for example C:\\NextGenOS-Website. Not into Program Files.' : '  1. Unpack the zip into your home folder (or any folder you may write to).',
    `  2. ${windows ? 'Double-click "Start Website" (the icon with the blue box). The website opens in a window of its own: there is no black terminal window. If Windows says "Windows protected your PC", click "More info", then "Run anyway".' : 'Run  ./start-website.sh --app  (once, in a terminal; the terminal can be closed at once). The website opens in a window of its own. To have it in the applications menu, run  ./start-website.sh --install-menu.'}`,
    '  3. With no licence yet, the window shows the page where you type the licence key. Type the key you were given and press the button (or put the licence file, licence.ngos, in the folder "licence" and start again). The page is /admin/licence of the website: http://127.0.0.1:3000/admin/licence. Visitors to a website that has no licence see a page that says it is not available. That is correct.',
    '  4. To stop the website, close its window. Starting it again while it is open only brings up the same window.',
    '',
    'TO PUT IT ONLINE (for the person who looks after the website\'s computer)',
    `  - Copy private-settings.example.env to private-settings.env and fill it in. Then start with  ${start}  again.`,
    '  - The website listens on this computer only. Put a web server with HTTPS (Caddy, nginx or IIS) in front of it, pointing at http://127.0.0.1:3000, and set NGOS_TRUST_PROXY=1 in private-settings.env.',
    `  - To start it on another port:  ${start} 8080.  To let other computers open it without a web server:  ${start} --public  (not safe on the open internet).`,
    '  - The licence is tied to the website\'s web address: open the website by that address (through the web server), not by 127.0.0.1.',
    windows ? '  - To keep it running all day without anyone opening a window, run it as a service (a tool such as NSSM can run node\\node.exe with start-website.js), or as a scheduled task at start-up. The "Start Website" icon is for opening it as a program on a laptop or counter PC.' : '  - To keep it running all day without anyone opening a window, run it from a systemd service (ExecStart=./node/bin/node start-website.js). ./start-website.sh --app is for opening it as a program on a laptop or counter PC.',
    '',
    'WHAT IS BUILT IN',
    '  The shop\'s name, address, country, kind of business and place are part of the website itself (see PACKAGE-INFO.json). To change them, ask NextGenOS for a new build of the website: they cannot be changed by editing a file in this folder.',
    '',
    'WHAT IS NOT IN THIS FOLDER, ON PURPOSE',
    '  No password, no key, no database and no licence. Keep private-settings.env and the folder "licence" to yourself and back them up.',
    '',
    'MORE',
    `  EULA.txt is the licence agreement. THIRD-PARTY-NOTICES.md lists the other software inside. The licence texts of the libraries are in their own folders under app${windows ? '\\' : '/'}node_modules.`,
  ]);
}

/** The words on the trial flag (the same idea as the Hub's NO-LICENCE-KEYS-TRIAL-ONLY.txt). */
export const TRIAL_TEXT = 'This website was built WITHOUT licence keys: it can never be licensed and refuses every visitor. It was made only to try the start-up. Do not give it to a customer.\n';

/**
 * Writes the package folder from the pieces of a built website. Nothing here builds anything, so it is also what the tests use with stand-in pieces.
 *   standalone, staticDir, publicDir   the build's server folder, its .next/static and its public folder
 *   node                               { root, version }: an unpacked Node.js of that system
 *   returns the folder
 */
export function assemblePackage({ out, os, customer, version, settings, standalone, staticDir, publicDir, node, trial = false, keyCount = 0, notices = {}, now = new Date() }) {
  checkSystem(os);
  const name = packageName(customer, os);
  checkVersion(version);
  const pkg = join(out, name);
  rmSync(pkg, { recursive: true, force: true });
  mkdirSync(pkg, { recursive: true });

  // The server folder: without the source files the build leaves behind (src/ is traced in by the build and is not needed to run), the build's .env files and its package.json.
  const app = join(pkg, 'app');
  cpSync(standalone, app, {
    recursive: true, dereference: true,
    filter: (from) => {
      const rel = relative(standalone, from);
      if (!rel) return true;
      const top = rel.split(sep)[0];
      if (top === 'src' || top.startsWith('.env') || top === 'package.json') return false;
      if (rel.includes(`node_modules${sep}.cache`)) return false;
      return true;
    },
  });
  cpSync(staticDir, join(app, '.next', 'static'), { recursive: true });
  cpSync(publicDir, join(app, 'public'), { recursive: true });
  writeFileSync(join(app, 'package.json'), JSON.stringify({ name: `website-${customer}`, version, private: true }, null, 2) + '\n');
  const pruned = pruneApp(app, os);

  // Node.js, as nodejs.org built it, with its licence.
  const nodePath = nodeFile(os);
  mkdirSync(dirname(join(pkg, 'node', nodePath)), { recursive: true });
  copyFileSync(join(node.root, nodePath), join(pkg, 'node', nodePath));
  for (const f of ['LICENSE', 'LICENSE.md']) if (existsSync(join(node.root, f))) copyFileSync(join(node.root, f), join(pkg, 'node', f));
  if (os !== 'windows') chmodSync(join(pkg, 'node', nodePath), 0o755);

  const name2 = settings.NEXT_PUBLIC_SITE_NAME || customer;
  writeFileSync(join(pkg, 'start-website.js'), LAUNCHER);
  // The window code is one file for every program of ours (scripts/lib/app-window.mjs); the package carries it unchanged.
  copyFileSync(join(here, 'lib', 'app-window.mjs'), join(pkg, 'app-window.mjs'));
  if (os === 'windows') {
    // "Start Website.exe" starts the website's own Node.js with no terminal window; the website then opens in a window of its own.
    buildLauncher({ outFile: join(pkg, 'Start Website.exe'), name: 'Smart Retail POS website', program: 'node\\node.exe', args: 'start-website.js --app', check: 'start-website.js', icon: join(here, 'launcher', 'product.ico'), version: /^\d+\.\d+\.\d+/.exec(version)?.[0] ?? '1.0.0' });
    writeFileSync(join(pkg, START_BAT_NAME), START_BAT);
  } else {
    writeFileSync(join(pkg, 'start-website.sh'), START_SH, { mode: 0o755 });
  }
  writeFileSync(join(pkg, 'private-settings.example.env'), privateSettingsExample(os));
  writeFileSync(join(pkg, 'prerequisites.json'), JSON.stringify(prerequisitesFor(os, node.version), null, 2) + '\n');
  mkdirSync(join(pkg, 'licence'), { recursive: true });
  writeFileSync(join(pkg, 'licence', 'READ ME.txt'), CRLF(['Put the website\'s licence file here, named licence.ngos, or type the licence key on the page /admin/licence of the running website (it saves the file here).', 'Do not give this folder to anyone: the licence is for this website only.']));
  writeFileSync(join(pkg, 'PACKAGE-INFO.json'), JSON.stringify({
    schema: 1, product: 'Smart Retail POS website', customer, name: name2, version, os, arch: 'x64', builtAt: now.toISOString(), node: node.version,
    licenceKeysBuiltIn: keyCount, trialWithoutLicenceKeys: Boolean(trial), publicSettings: settings,
  }, null, 2) + '\n');
  writeFileSync(join(pkg, 'READ ME FIRST.txt'), readmeFor({ name: name2, os, customer, trial, version, nodeVersion: node.version }));
  if (trial) writeFileSync(join(pkg, TRIAL_FILE), TRIAL_TEXT);
  for (const [file, from] of Object.entries({ 'EULA.txt': notices.eula, 'THIRD-PARTY-NOTICES.md': notices.thirdParty })) if (from && existsSync(from)) copyFileSync(from, join(pkg, file));
  if (os !== 'windows') chmodSync(join(pkg, 'start-website.sh'), 0o755);
  return { folder: pkg, name, pruned };
}

/** What must be in a finished package. */
export const requiredFiles = (os) => [
  'start-website.js', 'app-window.mjs', os === 'windows' ? 'Start Website.exe' : 'start-website.sh', 'READ ME FIRST.txt', 'private-settings.example.env', 'prerequisites.json', 'PACKAGE-INFO.json',
  os === 'windows' ? 'node/node.exe' : 'node/bin/node', 'node/LICENSE', 'app/server.js', 'app/package.json', 'app/.next/BUILD_ID', 'app/.next/static', 'app/public',
];

/** A program file for another system in the package (a Windows library in a Linux package, a macOS one anywhere). */
function foreignPrograms(root, os) {
  const found = [];
  const walk = (dir) => {
    for (const e of readdirSync(dir, { withFileTypes: true })) {
      const full = join(dir, e.name);
      if (e.isDirectory()) { walk(full); continue; }
      if (!e.isFile()) continue;
      const fd = openSync(full, 'r');
      const head = Buffer.alloc(4);
      let n = 0;
      try { n = readSync(fd, head, 0, 4, 0); } finally { closeSync(fd); }
      if (n < 4) continue;
      const rel = relative(root, full).split(sep).join('/');
      const magic = head.readUInt32BE(0);
      if (os === 'windows' && magic === 0x7f454c46) found.push(`${rel}  is a Linux program file in a Windows package`);
      else if (os === 'linux' && head[0] === 0x4d && head[1] === 0x5a && /\.(exe|dll|node|sys|ocx)$/i.test(e.name)) found.push(`${rel}  is a Windows program file in a Linux package`);
      else if ([0xfeedfacf, 0xcffaedfe, 0xfeedface, 0xcefaedfe].includes(magic) || (magic === 0xcafebabe && /\.(node|dylib)$/i.test(e.name))) found.push(`${rel}  is a macOS program file`);
    }
  };
  walk(root);
  return found;
}

/**
 * Looks at a finished package folder the way a customer's machine would: the files that must be there, nothing that must not be (scripts/audit-package.mjs, with the website's
 * node_modules allowed and still checked), nothing it needs that a factory-new machine lacks (scripts/audit-prerequisites.mjs), the right native parts for the system, and the libraries' licences.
 * Returns { problems, files, programs }.
 */
export function checkPackage(folder, { os }) {
  checkSystem(os);
  const root = resolve(folder);
  const problems = [];
  for (const f of requiredFiles(os)) if (!existsSync(join(root, ...f.split('/')))) problems.push(`${f} is missing from the package`);
  const audit = auditFolder(root, { nodeApp: true });
  problems.push(...audit.problems);
  problems.push(...auditPrerequisites(root, { os, arch: 'x64' }).problems);
  problems.push(...foreignPrograms(root, os));
  const engines = join(root, 'app', 'node_modules', '.prisma', 'client');
  const engineName = os === 'windows' ? /^query_engine-windows\.dll\.node$/ : /^libquery_engine-debian-openssl-3\.0\.x\.so\.node$/;
  if (!existsSync(engines) || !readdirSync(engines).some((f) => engineName.test(f))) problems.push(`the database engine for ${os} is missing (app/node_modules/.prisma/client): the database part of the website would not start`);
  const sharpDir = join(root, 'app', 'node_modules', '@img', os === 'windows' ? 'sharp-win32-x64' : 'sharp-linux-x64', 'lib');
  if (!existsSync(sharpDir) || !readdirSync(sharpDir).some((f) => f.endsWith('.node'))) problems.push(`the picture library for ${os} is missing (app/node_modules/@img): pictures would not be resized`);
  problems.push(...licenceProblems(join(root, 'app', 'node_modules')));
  return { problems: [...new Set(problems)], files: audit.files, programs: audit.programs };
}

/** Writes the zip of a package folder, with the folder's own name at the top, so unpacking never spills files over somebody's folder. */
export async function zipPackage(folder, zipFile) {
  const top = basename(folder);
  const items = [];
  const walk = (dir) => {
    for (const e of readdirSync(dir, { withFileTypes: true }).sort((a, b) => (a.name < b.name ? -1 : 1))) {
      const full = join(dir, e.name);
      if (e.isDirectory()) walk(full);
      else if (e.isFile()) items.push({ name: `${top}/${relative(folder, full).split(sep).join('/')}`, file: full, ...(statSync(full).mode & 0o111 ? { mode: 0o755 } : {}) });
    }
  };
  walk(folder);
  rmSync(zipFile, { force: true });
  await writeZipFile(zipFile, items);
  return items.length;
}

// ---------------------------------------------------------------------------------------------------------------------
// The whole job
// ---------------------------------------------------------------------------------------------------------------------

/**
 * Builds, packs, checks and zips the website of one customer. Returns { folder, zip, sha256, trial, files }.
 * `source` is the website's folder. Only the end-to-end test of the licence (licensing/e2e/website-package-e2e.mjs) gives another one, a copy of it with a throw-away Studio's
 * public key built in, so that a licensed website can be tried; the command line has no such switch, and the repository's own files are never changed.
 */
export async function makeWebsitePackage(opts) {
  const { os, version, out, allowNoKey = false, depsFrom = null, kit = null, settingsFile = null, logo = null, nodeGiven = null, nodeDownload = null, source = appDir, log = (m) => console.log(`\n== ${m}`) } = opts;
  checkSystem(os);
  checkVersion(version);
  if (hostOs() !== os) {
    throw new WebsiteError(`A website for ${os === 'windows' ? 'Windows' : 'Linux'} is built on a ${os === 'windows' ? 'Windows' : 'Linux'} computer: the database engine and the picture library are different files for each system, and only a build on the real system can be started and tested there.\nThe release workflow has a job for each system.`);
  }
  if (process.arch !== 'x64') throw new WebsiteError('Only 64-bit Intel/AMD websites are built (this computer is ' + process.arch + ').');

  // The customer's public settings: from the brand kit, and from the settings file (which adds to them or overrides them).
  const packs = knownPacks();
  let values = {};
  let kitLogo = null;
  let customer = opts.customer || null;
  if (!kit && !settingsFile) throw new WebsiteError('Give the customer\'s public settings: --settings <website-settings.env> or --kit <brand kit name>.');
  if (kit) {
    if (!/^[a-z0-9][a-z0-9-]{1,40}$/.test(kit)) throw new WebsiteError(`"${String(kit).slice(0, 60)}" is not a brand kit name.`);
    const k = settingsFromKit(join(repo, 'brand-kits', kit));
    values = { ...k.values };
    kitLogo = k.logo;
    customer = customer || kit;
  }
  if (settingsFile) {
    if (!existsSync(settingsFile)) throw new WebsiteError(`The settings file ${settingsFile} was not found.`);
    const own = parseSettings(readFileSync(settingsFile, 'utf8'), { ...packs, requireName: !kit });
    if (own.problems.length) throw new WebsiteError(`The settings in ${basename(settingsFile)} cannot be used:\n  ${own.problems.join('\n  ')}`);
    values = { ...values, ...own.values };
  }
  checkCustomer(customer);
  const parsed = parseSettings(Object.entries(values).map(([k, v]) => `${k}=${v}`).join('\n'), packs);
  if (parsed.problems.length) throw new WebsiteError(`The settings cannot be used:\n  ${parsed.problems.join('\n  ')}`);
  const chosenLogo = logo ? resolve(logo) : kitLogo;
  if (chosenLogo) checkLogo(chosenLogo);

  const work = mkdtempSync(join(tmpdir(), 'ngos-site-'));
  try {
    log('Node.js to carry');
    const node = await nodeRuntime({ os, given: nodeGiven, download: nodeDownload, work });
    const built = buildWebsite({ work, settings: parsed.values, source, depsFrom, logo: chosenLogo, allowNoKey, log });
    const trial = built.keys.count === 0 || !built.keys.url;
    log('Putting the package together');
    mkdirSync(out, { recursive: true });
    const { folder, name, pruned } = assemblePackage({
      out, os, customer, version, settings: parsed.values, standalone: built.standalone, staticDir: built.staticDir, publicDir: built.publicDir, node, trial,
      keyCount: built.keys.count, notices: { eula: join(repo, 'EULA.txt'), thirdParty: join(repo, 'THIRD-PARTY-NOTICES.md') },
    });
    console.log(`Removed from the build: ${pruned.files} source/type/map files${pruned.other.length ? `; other systems' parts: ${pruned.other.join(', ')}` : ''}.`);
    rmSync(work, { recursive: true, force: true });   // the build folder is large: free it before the checks and the zip

    log('Checking the package (no source, no secret, nothing a factory-new computer lacks, the right native parts, licences)');
    const checked = checkPackage(folder, { os });
    if (checked.problems.length) throw new WebsiteError(`The package holds what it must not, or lacks what it needs:\n  ${checked.problems.slice(0, 40).join('\n  ')}${checked.problems.length > 40 ? `\n  ... and ${checked.problems.length - 40} more` : ''}`);
    console.log(`${checked.files} files checked (${checked.programs} program files): nothing that is source, secret, a test or a database; each program file needs only what is inside or the base system.`);

    log('Writing the zip');
    const zip = join(out, `${name}.zip`);
    const count = await zipPackage(folder, zip);
    return { folder, zip, files: count, trial, sha256: sha256(readFileSync(zip)) };
  } finally {
    rmSync(work, { recursive: true, force: true });
  }
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const args = process.argv.slice(2);
  const flag = (n) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : undefined; };
  const has = (n) => args.includes(n);
  try {
    if (has('--help') || args.length === 0) {
      console.log('Usage: node scripts/make-website-package.mjs --os windows|linux --version 1.0.0 --customer <short-name> --settings <website-settings.env> (--node-runtime <folder> | --download-node 22.22.0) [--out dist] [--allow-no-key] [--deps-from <node_modules>] [--logo <logo.png>]\n       node scripts/make-website-package.mjs --os linux --version 1.0.0 --kit <brand kit name> --download-node 22.22.0');
      process.exit(args.length ? 0 : 2);
    }
    const r = await makeWebsitePackage({
      os: flag('--os'), version: flag('--version'), customer: flag('--customer') || null, kit: flag('--kit') || null, settingsFile: flag('--settings') ? resolve(flag('--settings')) : null,
      nodeGiven: flag('--node-runtime') || null, nodeDownload: flag('--download-node') || null, out: resolve(flag('--out') ?? join(repo, 'dist')),
      allowNoKey: has('--allow-no-key'), depsFrom: flag('--deps-from') || null, logo: flag('--logo') || null,
    });
    console.log(`\nWrote:\n  ${r.zip}\n  ${r.folder}${sep}   (${r.files} files)\n  SHA-256 ${r.sha256}${r.trial ? '\n\nTRIAL BUILD: no licence keys are built in. It can never be licensed. Never give it to a customer.' : ''}`);
  } catch (e) {
    if (e instanceof WebsiteError) { console.error(`\n${e.message}`); process.exit(1); }
    throw e;
  }
}
