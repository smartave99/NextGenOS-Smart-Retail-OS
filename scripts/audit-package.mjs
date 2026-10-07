#!/usr/bin/env node
/**
 * Looks inside what a customer will receive (a folder, or a .zip / .apk / .deb / .msi-extracted folder) and fails if it holds anything it must not
 * (CLAUDE.md, section 3: "No source code in anything a customer receives").
 *
 *   node scripts/audit-package.mjs <folder-or-zip> [more...] [--obfuscated NextGenOS.Hub.Core.dll,...] [--names-from apps/business-hub/src]
 *
 * With --customer-package (one customer's website, put together by the assemble step) the customer's own licence file is accepted, at licence/licence.ngos and nowhere else; everything
 * else is still looked at: the customer's folder is checked like any other file, so a source file, an environment file, a database or a key planted in it fails.
 *
 * With --node-app (the website is a Node.js server and needs the folder of its libraries) the node_modules folder itself is accepted, and everything inside it is checked like any other file,
 * with two differences that only apply to JavaScript: a library may name the header of a key file it reads (a key is a secret only when its text follows), and minified code such as
 * "s.password=r.password," is not a connection string.
 *
 * Fails on:
 *   - source and project files (.cs .vb .ts .tsx .map .pdb .sln .slnx .csproj .vbproj .razor ...), test programs and test libraries,
 *     anything of the Licence Studio, node_modules, git data;
 *   - secrets and personal data files: .env, databases, licence files, private keys and certificates, key stores, local settings, logs;
 *   - the obfuscator's name map;
 *   - a secret pattern (see scripts/lib/secret-patterns.mjs) in a text file, or as text inside a program file (plain or UTF-16, as .NET stores strings);
 *   - with --obfuscated: a program that still carries the real names of its own types (the names are collected from the source folders in
 *     --names-from), which means the obfuscation did not happen.
 *
 * Exit code 0 only when nothing was found. It says what it looked at, so "passed" is never silent.
 */
import { readdirSync, readFileSync, statSync, existsSync, mkdtempSync, rmSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, relative, resolve, basename, extname, sep } from 'node:path';
import { fileURLToPath } from 'node:url';
import { SECRET_PATTERNS, SECRET_ALLOW } from './lib/secret-patterns.mjs';

const FORBIDDEN_EXT = new Set(['.cs', '.vb', '.fs', '.ts', '.tsx', '.jsx', '.map', '.pdb', '.sln', '.slnx', '.csproj', '.vbproj', '.fsproj', '.props', '.targets',
  '.razor', '.cshtml', '.resx', '.snk', '.pfx', '.p12', '.pem', '.key', '.jks', '.keystore', '.db', '.sqlite', '.sqlite3', '.db-wal', '.db-shm', '.ngoslic', '.ngos', '.log', '.bak']);
const FORBIDDEN_NAME = [
  [/^\.env(\..*)?$/i, 'environment file'],
  [/^appsettings\.(local|development|secrets?)\.json$/i, 'local settings'],
  [/^(secrets?|user-secrets)\.json$/i, 'secrets file'],
  [/^mapping\.(txt|xml)$/i, 'obfuscator name map'],
  [/^obfuscar/i, 'obfuscator'],
  [/^licence\.ngos$|^licen[cs]e-file/i, 'licence file'],
  [/(^|[-_.])(private|signing)[-_.]?key/i, 'private or signing key'],
  [/^studio[-_.]?(data|keys?)/i, 'Licence Studio data'],
  [/(^|\.)(Tests?|E2EHost|IntegrationTests?)\.(dll|exe|deps\.json|runtimeconfig\.json)$/i, 'test program'],
  [/^(xunit|Microsoft\.TestPlatform|Microsoft\.NET\.Test\.Sdk|testhost|coverlet|Microsoft\.VisualStudio\.TestPlatform|Microsoft\.CodeCoverage)/i, 'test framework'],
  [/\.(test|spec)\.(m?js|ts|tsx)$/i, 'test file'],
  [/^(package-lock|yarn\.lock|pnpm-lock)/i, 'lock file (build input, not product)'],
];
const FORBIDDEN_DIR = [
  [/^node_modules$/i, 'node_modules'],
  [/^\.git$/i, 'git data'],
  [/^\.github$/i, 'CI settings'],
  [/^licensing$/i, 'licensing folder (the Licence Studio is private)'],
  [/^studio$/i, 'Licence Studio'],
  [/^(setup-studio|brand-studio)$/i, 'a NextGenOS staff tool (the Setup Studio and the Brand Studio never go to a customer)'],
  [/^NextGenOS Setup Studio$/i, 'the Setup Studio\'s own workspace'],
  [/^(tests?|__tests__|e2e|testvectors)$/i, 'tests'],
  [/^(\.vs|\.idea|\.vscode)$/i, 'editor settings'],
];
const BINARY_EXT = new Set(['.dll', '.exe', '.so', '.dylib', '.node', '.apk', '.aab', '.msi', '.png', '.jpg', '.jpeg', '.gif', '.webp', '.ico', '.woff', '.woff2', '.ttf', '.otf', '.br', '.gz', '.zip', '.pdf', '.bin', '.dat', '.snk', '.avif', '.bmp']);

/** Reads the whole audit of one folder and returns { problems, looked } without printing. */
export function auditFolder(folder, options = {}) {
  const root = resolve(folder);
  const problems = [];
  let files = 0;
  let programs = 0;
  const walk = (dir) => {
    for (const e of readdirSync(dir, { withFileTypes: true })) {
      const full = join(dir, e.name);
      const rel = relative(root, full).split(sep).join('/');
      if (e.isDirectory()) {
        // A Node.js server (the website) needs its libraries' folder: with nodeApp the folder itself is accepted, and everything inside it is still checked like any other file.
        const bad = FORBIDDEN_DIR.find(([re, what]) => re.test(e.name) && !(options.nodeApp && what === 'node_modules'));
        if (bad) { problems.push(`${rel}/  ${bad[1]}`); continue; }
        walk(full);
        continue;
      }
      if (!e.isFile()) continue;
      files += 1;
      const ext = extname(e.name).toLowerCase();
      // The one licence file a customer's own website may carry (options.customerPackage): the customer's, from the Licence Studio, in the folder the website reads it from.
      const customerLicence = Boolean(options.customerPackage) && /(^|\/)licence\/licence\.ngos$/.test(rel);
      if (FORBIDDEN_EXT.has(ext) && !customerLicence) problems.push(`${rel}  ${describeExt(ext)}`);
      const code = Boolean(options.nodeApp) && /\.(m?js|cjs)$/i.test(e.name);
      // A library's error class may be called SigningKeyNotFoundError.js: in JavaScript code inside node_modules the name alone says nothing (a key file would have a key extension, which is refused above).
      const badName = customerLicence ? undefined : FORBIDDEN_NAME.find(([re, what]) => re.test(e.name) && !(code && rel.includes('node_modules/') && what === 'private or signing key'));
      if (badName) problems.push(`${rel}  ${badName[1]}`);
      if (statSync(full).size > 200 * 1024 * 1024) continue;
      if (!BINARY_EXT.has(ext)) {
        const text = readFileSync(full, 'utf8');
        for (const hit of findSecrets(text, { code })) problems.push(`${rel}  contains ${hit}`);
      } else if (['.dll', '.exe', '.node', '.so'].includes(ext)) {
        programs += 1;
        const bytes = readFileSync(full);
        for (const hit of findSecrets(bytes.toString('latin1'))) problems.push(`${rel}  contains ${hit}`);
        for (const hit of findSecrets(bytes.toString('utf16le'))) problems.push(`${rel}  contains ${hit} (as .NET text)`);
        // Offset by one byte as well, so text that does not start on an even byte is still read.
        for (const hit of findSecrets(bytes.subarray(1).toString('utf16le'))) problems.push(`${rel}  contains ${hit} (as .NET text)`);
      }
    }
  };
  walk(root);

  const names = options.names && options.names.size ? options.names : null;
  const expected = options.obfuscated || [];
  for (const dll of expected) {
    const path = join(root, dll);
    if (!existsSync(path)) { problems.push(`${dll}  expected in the package but missing`); continue; }
    if (!names) { problems.push(`${dll}  --obfuscated needs --names-from (the source to take the real names from)`); continue; }
    const text = readFileSync(path).toString('latin1');
    // Names sit in the program's name table one after another, each ending in a zero byte: match whole names (PartyKind, not PartyKinds).
    const left = [...names].filter((n) => text.includes('\0' + n + '\0'));
    if (left.length) problems.push(`${dll}  is not obfuscated: still holds ${left.length} real type name(s), for example ${left.slice(0, 5).join(', ')}`);
  }
  return { problems: [...new Set(problems)], files, programs };
}

function describeExt(ext) {
  if (['.cs', '.vb', '.fs', '.ts', '.tsx', '.jsx', '.razor', '.cshtml', '.resx'].includes(ext)) return 'source code';
  if (['.csproj', '.vbproj', '.fsproj', '.sln', '.slnx', '.props', '.targets'].includes(ext)) return 'project file';
  if (ext === '.map') return 'source map';
  if (ext === '.pdb') return 'debug symbols';
  if (['.db', '.sqlite', '.sqlite3', '.db-wal', '.db-shm'].includes(ext)) return 'database';
  if (['.ngoslic', '.ngos'].includes(ext)) return 'licence file';
  if (['.snk', '.pfx', '.p12', '.pem', '.key', '.jks', '.keystore'].includes(ext)) return 'key or certificate';
  return 'file that does not belong in a package';
}

/** A key file's text: the header and then its base64 body (a library that only names the header, to know what to look for, holds no key). */
const PRIVATE_KEY_WITH_BODY = /-----BEGIN (?:RSA |EC |OPENSSH |ENCRYPTED )?PRIVATE KEY-----(?:\s|\\n|\\r)*[A-Za-z0-9+/]{40,}/;

/** { code: true } reads JavaScript as code (a node app's own and its libraries'): see the note at the top. */
export function findSecrets(text, { code = false } = {}) {
  const hits = [];
  if (!text) return hits;
  for (const [pattern, what] of SECRET_PATTERNS) {
    if (code && what === 'password in a connection string') continue;
    const re = code && what === 'private key' ? PRIVATE_KEY_WITH_BODY : pattern;
    const global = new RegExp(re.source, re.flags.includes('g') ? re.flags : re.flags + 'g');
    for (const m of text.matchAll(global)) {
      const around = text.slice(Math.max(0, m.index - 20), m.index + m[0].length + 20);
      if (!SECRET_ALLOW.some((a) => a.test(around))) { hits.push(what); break; }
    }
  }
  return hits;
}

/**
 * The names of the types written in the .cs files under these folders: the names an obfuscated program must no longer show.
 * A name that is also the name of a property or field somewhere (a class Appointment and a property Appointment) is left out: property names
 * are kept on purpose where the JSON reader and the screens bind by name, so such a word proves nothing either way.
 */
export function typeNamesFrom(folders) {
  const names = new Set();
  const texts = [];
  const skip = new Set(['bin', 'obj', 'node_modules', '.git']);
  const walk = (dir) => {
    for (const e of readdirSync(dir, { withFileTypes: true })) {
      if (e.isDirectory()) { if (!skip.has(e.name)) walk(join(dir, e.name)); continue; }
      if (!e.name.endsWith('.cs') && !e.name.endsWith('.razor')) continue;
      const text = readFileSync(join(dir, e.name), 'utf8');
      texts.push(text);
      if (!e.name.endsWith('.cs')) continue;
      for (const m of text.matchAll(/\b(?:class|record|struct|interface|enum)\s+([A-Z][A-Za-z0-9]{8,})\b/g)) names.add(m[1]);
    }
  };
  for (const f of folders) if (existsSync(f)) walk(f);
  const all = texts.join('\n');
  for (const n of [...names]) {
    if (new RegExp(`[\\w>\\]?]\\s+${n}\\s*(\\{\\s*(get|init|set)|=>|;|=[^=>]|[,)])`).test(all)) names.delete(n);
  }
  return names;
}

function extract(zip) {
  const out = mkdtempSync(join(tmpdir(), 'ngos-audit-'));
  if (/\.deb$/i.test(zip)) {
    // A Debian package: its files and its scripts (dpkg-deb), or the same by hand when this is not a Debian-like PC.
    const a = spawnSync('dpkg-deb', ['-R', zip, out], { encoding: 'utf8' });
    if (!a.error && a.status === 0) return out;
    const b = spawnSync('sh', ['-c', 'ar x "$1" && for f in control.tar.* data.tar.*; do mkdir -p "x-$f" && tar -xf "$f" -C "x-$f"; done', 'sh', zip], { cwd: out, encoding: 'utf8' });
    if (!b.error && b.status === 0) return out;
    rmSync(out, { recursive: true, force: true });
    throw new Error(`could not open ${zip} (needs dpkg-deb, or ar and tar)`);
  }
  const windowsTar = join(process.env.SystemRoot || 'C:\\Windows', 'System32', 'tar.exe');
  const tries = [...(process.platform === 'win32' ? [[windowsTar, ['-xf', zip, '-C', out]]] : []), ['unzip', ['-q', zip, '-d', out]], ['tar', ['-xf', zip, '-C', out]], ['python3', ['-m', 'zipfile', '-e', zip, out]]];
  for (const [cmd, a] of tries) {
    const r = spawnSync(cmd, a, { encoding: 'utf8' });
    if (!r.error && r.status === 0) return out;
  }
  rmSync(out, { recursive: true, force: true });
  throw new Error(`could not open ${zip} (needs unzip, tar or python3)`);
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const args = process.argv.slice(2);
  const value = (name) => { const i = args.indexOf(name); return i >= 0 ? args[i + 1] : undefined; };
  const nodeApp = args.includes('--node-app');
  const customerPackage = args.includes('--customer-package');
  const targets = args.filter((a, i) => !a.startsWith('--') && !(i > 0 && args[i - 1].startsWith('--') && !['--node-app', '--customer-package'].includes(args[i - 1])));
  if (!targets.length) { console.error('Usage: node scripts/audit-package.mjs <folder-or-zip>... [--obfuscated a.dll,b.dll] [--names-from dir,dir] [--node-app] [--customer-package]'); process.exit(2); }
  const obfuscated = (value('--obfuscated') || '').split(',').filter(Boolean);
  const names = typeNamesFrom((value('--names-from') || '').split(',').filter(Boolean).map((p) => resolve(p)));
  let failed = false;
  for (const t of targets) {
    let folder = resolve(t);
    let temp = null;
    if (!existsSync(folder)) { console.error(`${t}: not found`); failed = true; continue; }
    if (statSync(folder).isFile()) { temp = extract(folder); folder = temp; }
    const { problems, files, programs } = auditFolder(folder, { obfuscated, names, nodeApp, customerPackage });
    if (temp) rmSync(temp, { recursive: true, force: true });
    if (problems.length) {
      failed = true;
      console.log(`FAIL  ${basename(t)}: ${problems.length} problem(s) in ${files} files`);
      for (const p of problems.slice(0, 60)) console.log('  ' + p);
      if (problems.length > 60) console.log(`  ... and ${problems.length - 60} more`);
    } else {
      console.log(`PASS  ${basename(t)}: ${files} files (${programs} programs) checked; no source, project, test, key, database or licence file; no secret pattern in text or programs${obfuscated.length ? `; ${obfuscated.length} program(s) show none of ${names.size} real type names` : ''}`);
    }
  }
  process.exit(failed ? 1 : 0);
}
