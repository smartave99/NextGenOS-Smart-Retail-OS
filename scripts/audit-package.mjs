#!/usr/bin/env node
/**
 * Looks inside what a customer will receive (a folder, or a .zip / .apk / .msi-extracted folder) and fails if it holds anything it must not
 * (CLAUDE.md, section 3: "No source code in anything a customer receives").
 *
 *   node scripts/audit-package.mjs <folder-or-zip> [more...] [--obfuscated NextGenOS.Hub.Core.dll,...] [--names-from apps/business-hub/src]
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
        const bad = FORBIDDEN_DIR.find(([re]) => re.test(e.name));
        if (bad) { problems.push(`${rel}/  ${bad[1]}`); continue; }
        walk(full);
        continue;
      }
      if (!e.isFile()) continue;
      files += 1;
      const ext = extname(e.name).toLowerCase();
      if (FORBIDDEN_EXT.has(ext)) problems.push(`${rel}  ${describeExt(ext)}`);
      const badName = FORBIDDEN_NAME.find(([re]) => re.test(e.name));
      if (badName) problems.push(`${rel}  ${badName[1]}`);
      if (statSync(full).size > 200 * 1024 * 1024) continue;
      if (!BINARY_EXT.has(ext)) {
        const text = readFileSync(full, 'utf8');
        for (const hit of findSecrets(text)) problems.push(`${rel}  contains ${hit}`);
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

export function findSecrets(text) {
  const hits = [];
  if (!text) return hits;
  for (const [re, what] of SECRET_PATTERNS) {
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
  const tries = [['unzip', ['-q', zip, '-d', out]], ['tar', ['-xf', zip, '-C', out]], ['python3', ['-m', 'zipfile', '-e', zip, out]]];
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
  const targets = args.filter((a, i) => !a.startsWith('--') && !(i > 0 && args[i - 1].startsWith('--')));
  if (!targets.length) { console.error('Usage: node scripts/audit-package.mjs <folder-or-zip>... [--obfuscated a.dll,b.dll] [--names-from dir,dir]'); process.exit(2); }
  const obfuscated = (value('--obfuscated') || '').split(',').filter(Boolean);
  const names = typeNamesFrom((value('--names-from') || '').split(',').filter(Boolean).map((p) => resolve(p)));
  let failed = false;
  for (const t of targets) {
    let folder = resolve(t);
    let temp = null;
    if (!existsSync(folder)) { console.error(`${t}: not found`); failed = true; continue; }
    if (statSync(folder).isFile()) { temp = extract(folder); folder = temp; }
    const { problems, files, programs } = auditFolder(folder, { obfuscated, names });
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
