#!/usr/bin/env node
/**
 * The release gate (see CLAUDE.md, rule 2). One command that runs every check this repository has and says plainly
 * what passed, what failed and what could NOT be verified here.
 *
 *   node scripts/verify-all.mjs            quick checks (no builds)
 *   node scripts/verify-all.mjs --full     everything, including builds and live end-to-end runs
 *   node scripts/verify-all.mjs --only secrets,identity
 *
 * Exit code 0 only when every check that was run passed AND (in --full mode) no required check was skipped.
 * A skipped check is never a passed check.
 */
import { spawnSync } from 'node:child_process';
import { readFileSync, existsSync, statSync } from 'node:fs';
import { resolve, join, dirname, relative } from 'node:path';
import { fileURLToPath } from 'node:url';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const args = process.argv.slice(2);
const full = args.includes('--full');
const onlyArg = args.find((a) => a.startsWith('--only'));
const only = onlyArg ? (onlyArg.includes('=') ? onlyArg.split('=')[1] : args[args.indexOf(onlyArg) + 1]).split(',') : null;

const sh = (cmd, cmdArgs, opts = {}) => spawnSync(cmd, cmdArgs, { cwd: root, encoding: 'utf8', maxBuffer: 64 * 1024 * 1024, timeout: 1_500_000, ...opts });
const tail = (r, n = 12) => `${r.stdout || ''}${r.stderr || ''}`.trim().split('\n').slice(-n).join('\n');
const has = (cmd) => spawnSync('sh', ['-c', `command -v ${cmd}`], { encoding: 'utf8' }).status === 0;

/** Every file git knows or would add (respects .gitignore), as repo-relative paths. */
function repoFiles() {
  const r = sh('git', ['ls-files', '-co', '--exclude-standard', '-z']);
  return r.stdout.split('\0').filter(Boolean).filter((f) => existsSync(join(root, f)) && statSync(join(root, f)).isFile());
}
const isText = (f) => !/\.(png|jpe?g|gif|ico|webp|avif|woff2?|ttf|otf|exe|dll|msi|zip|gz|db|sqlite|pdf|bmp|snk|resources|pfx|jar|apk|aab|so|node)$/i.test(f);
const read = (f) => { try { return readFileSync(join(root, f), 'utf8'); } catch { return ''; } };

// ---------------------------------------------------------------------------------------------------------------------
// Checks. Each returns { status: 'PASS' | 'FAIL' | 'SKIP', detail }.
// ---------------------------------------------------------------------------------------------------------------------

const SECRET_PATTERNS = [
  [/sk-proj-[A-Za-z0-9_-]{20,}/, 'OpenAI project key'],
  [/\bsk-[A-Za-z0-9]{32,}\b/, 'API key (sk-...)'],
  [/\bnpg_[A-Za-z0-9]{10,}/, 'Neon database password'],
  [/\bgsk_[A-Za-z0-9]{20,}/, 'Groq key'],
  [/AIza[0-9A-Za-z_-]{35}/, 'Google API key'],
  [/\bAKIA[0-9A-Z]{16}\b/, 'AWS access key'],
  [/\bghp_[A-Za-z0-9]{30,}/, 'GitHub token'],
  [/-----BEGIN (?:RSA |EC |OPENSSH |ENCRYPTED )?PRIVATE KEY-----/, 'private key'],
  [/postgres(?:ql)?:\/\/[^\s"'<>:@]+:[^\s"'<>@]{4,}@/, 'database URL with a password'],
  [/AuthSecret\s*=\s*"[^"]{12,}"/, 'Firebase database secret'],
  [/\b(?:Password|Pwd)=[^;"'\s${}(][^;"'\s]{5,};/i, 'password in a connection string'],
];
// Test and example files may hold obviously fake values; these exact fakes are allowed.
const SECRET_ALLOW = [/Password=your_password/, /Password=not-a-real-password/, /sk-test-0+/, /postgres:\/\/user:secret@host/, /postgres:\/\/authenticator:\$\{/, /sk-abc/, /secret_test/];
const SECRET_SKIP_PATH = /^(licenses\/|.*package-lock\.json$|.*\.min\.js$|apps\/pos-dashboard-service\/owner-app\/vendor\/|apps\/storefront-web-mobile\/android\/gradle)/;

function checkSecrets() {
  const hits = [];
  for (const f of repoFiles()) {
    if (!isText(f) || SECRET_SKIP_PATH.test(f)) continue;
    const text = read(f);
    if (text.length > 3_000_000) continue;
    const lines = text.split('\n');
    lines.forEach((line, i) => {
      if (line.length > 4000) return;
      for (const [re, what] of SECRET_PATTERNS) {
        if (re.test(line) && !SECRET_ALLOW.some((a) => a.test(line))) hits.push(`${f}:${i + 1}  ${what}`);
      }
    });
  }
  return hits.length ? { status: 'FAIL', detail: `${hits.length} possible secret(s):\n  ` + hits.slice(0, 40).join('\n  ') + (hits.length > 40 ? `\n  ... and ${hits.length - 40} more` : '') } : { status: 'PASS', detail: 'no secret patterns in tracked or new files' };
}

const BYPASS_PATTERNS = [
  [/ACTV99-NEXT/, 'hard-coded licence key'],
  [/class\s+LicenseWriter/, 'licence writer (keygen)'],
  [/Activate_POS\.(ps1|bat)/, 'activation bypass script'],
  [/softwarelicensemanager-/, "third party's licence database"],
  [/Permanent License Activation Script/i, 'activation bypass script'],
  [/VT",\s*ENC\(vtill\)/, 'licence writer (keygen)'],
];
const BYPASS_ALLOW_PATH = /^(scripts\/verify-all\.mjs|CLAUDE\.md|docs\/|licensing\/studio\/test\/)/;
function checkBypass() {
  const hits = [];
  const files = repoFiles();
  for (const f of files) {
    if (/Activate_POS\.(ps1|bat)$/.test(f)) hits.push(`${f}  activation bypass script exists`);
    if (!isText(f) || BYPASS_ALLOW_PATH.test(f) || SECRET_SKIP_PATH.test(f)) continue;
    const text = read(f);
    for (const [re, what] of BYPASS_PATTERNS) if (re.test(text)) hits.push(`${f}  ${what}`);
  }
  return hits.length ? { status: 'FAIL', detail: [...new Set(hits)].slice(0, 30).join('\n  ') } : { status: 'PASS', detail: 'no licence bypass, keygen or hard-coded licence found' };
}

// Smart Avenue 99 is a customer. Its identity may live only in brand kits, documentation of that customer, and the (separate) decompiled POS source.
// Internal names of the legacy POS source (assembly, exe, solution paths): renaming them needs a Windows build machine to regression-test.
const IDENTITY_ALLOW = /^(SmartRetailSuite\.sln|scripts\/build-all\.ps1|apps\/pos-desktop\/|brand-kits\/|docs\/|CLAUDE\.md|CHANGELOG\.md|scripts\/verify-all\.mjs|apps\/pos-desktop\/(Source|Documentation)\/|licenses\/|.*package-lock\.json$|apps\/storefront-web-mobile\/(tmp\/|.*\.resolved$|build_log|test-output|compare-output|verification_result))/;
function checkIdentity() {
  const hits = [];
  for (const f of repoFiles()) {
    if (!isText(f) || IDENTITY_ALLOW.test(f)) continue;
    const text = read(f);
    const m = /smart ?avenue|smartavenue|smart_avenue/i.exec(text);
    if (m) {
      const line = text.slice(0, m.index).split('\n').length;
      hits.push(`${f}:${line}  "${m[0]}"`);
    }
  }
  return hits.length
    ? { status: 'FAIL', detail: `${hits.length} place(s) still carry a customer's identity in product code:\n  ` + hits.slice(0, 40).join('\n  ') + (hits.length > 40 ? `\n  ... and ${hits.length - 40} more` : '') }
    : { status: 'PASS', detail: "no customer identity in product code" };
}

function checkNames() {
  const hits = [];
  for (const f of repoFiles()) {
    if (!isText(f) || /^(licenses\/|apps\/pos-desktop\/(Source|Documentation)\/|.*package-lock\.json$|scripts\/verify-all\.mjs|CLAUDE\.md)/.test(f)) continue;
    const text = read(f);
    for (const bad of ['NextGen OS', 'Smart Retail OS']) if (text.includes(bad)) hits.push(`${f}  "${bad}" (use NextGenOS / Smart Retail POS)`);
  }
  return hits.length ? { status: 'FAIL', detail: hits.slice(0, 30).join('\n  ') } : { status: 'PASS', detail: 'company, product and suite names are consistent' };
}

function runCmd(name, cmd, cmdArgs, opts = {}) {
  const r = sh(cmd, cmdArgs, opts);
  return r.status === 0 ? { status: 'PASS', detail: tail(r, 3), out: `${r.stdout}${r.stderr}` } : { status: 'FAIL', detail: tail(r, 30), out: `${r.stdout}${r.stderr}` };
}

const needs = (tool, fn) => (has(tool) ? fn() : { status: 'SKIP', detail: `${tool} is not installed here` });

const checks = [
  { name: 'secrets', title: 'No secrets in the repository', run: checkSecrets },
  { name: 'bypass', title: 'No licence bypass, keygen or hard-coded licence', run: checkBypass },
  { name: 'identity', title: "No customer's identity in product code", run: checkIdentity },
  { name: 'names', title: 'Company / product / suite names are consistent', run: checkNames },
  {
    name: 'studio', title: 'Licence Studio tests (crypto, protocol, roles, HTTP)',
    run: () => needs('node', () => runCmd('studio', 'node', ['--no-warnings', '--test', 'test/*.test.js'], { cwd: join(root, 'licensing', 'studio') })),
  },
  {
    name: 'dotnet-lib', title: '.NET licence library builds for .NET Framework 4.8 and .NET 8', full: true,
    run: () => needs('dotnet', () => runCmd('dotnet-lib', 'dotnet', ['build', 'licensing/clients/dotnet/NextGenOS.Licensing', '-c', 'Release', '--nologo', '-v', 'q', '-warnaserror-'])),
  },
  {
    name: 'dotnet-live', title: '.NET licence library: vectors + live end-to-end against a real Studio (0 skipped)', full: true,
    run: () => needs('dotnet', () => {
      const r = runCmd('dotnet-live', 'node', ['licensing/e2e/with-studio.mjs', '--', 'dotnet', 'test', 'licensing/clients/dotnet/NextGenOS.Licensing.Tests', '--nologo']);
      if (r.status === 'PASS' && /Skipped:\s*[1-9]/.test(r.out)) return { status: 'FAIL', detail: 'tests were skipped: ' + tail({ stdout: r.out, stderr: '' }, 4) };
      return r;
    }),
  },
  {
    name: 'storefront-tests', title: 'Storefront unit tests and type check', full: true,
    run: () => needs('node', () => {
      const dir = join(root, 'apps', 'storefront-web-mobile');
      if (!existsSync(join(dir, 'node_modules'))) return { status: 'SKIP', detail: 'run npm ci in apps/storefront-web-mobile first' };
      const a = runCmd('vitest', 'npx', ['vitest', 'run'], { cwd: dir });
      if (a.status !== 'PASS') return a;
      return runCmd('tsc', 'npx', ['tsc', '--noEmit'], { cwd: dir });
    }),
  },
  {
    name: 'storefront-e2e', title: 'Storefront production build + licence gate against a real Studio', full: true,
    run: () => needs('node', () => {
      if (!existsSync(join(root, 'apps', 'storefront-web-mobile', 'node_modules'))) return { status: 'SKIP', detail: 'run npm ci in apps/storefront-web-mobile first' };
      const r = runCmd('storefront-e2e', 'node', ['licensing/e2e/with-studio.mjs', '--', 'node', 'licensing/e2e/storefront-e2e.mjs'], { timeout: 1_800_000 });
      const dirty = sh('git', ['diff', '--quiet', '--', 'apps/storefront-web-mobile/src/lib/licence/defaults.ts']).status !== 0;
      return dirty ? { status: 'FAIL', detail: 'the e2e left defaults.ts modified' } : r;
    }),
  },
];

// Registered by other parts of the repository as they are added (kept in scripts/checks/*.mjs).
import { readdirSync } from 'node:fs';
const extraDir = join(root, 'scripts', 'checks');
if (existsSync(extraDir)) {
  for (const f of readdirSync(extraDir).filter((x) => x.endsWith('.mjs')).sort()) {
    const mod = await import(join(extraDir, f));
    for (const c of mod.checks({ root, sh, has, runCmd, repoFiles, read, isText, tail, join, existsSync })) checks.push(c);
  }
}

// What this gate can never prove from here. Printed every time so that nobody forgets it.
const NOT_VERIFIED = [
  'The Windows programs (POS, AI add-on, dashboard host) running on a real Windows PC with a real shop database.',
  'Real printers, barcode scanners, cash drawers and cameras (the device layer is tested with virtual devices and loop-back connections).',
  'The Android app on a real phone (it is built and signed by the release workflow in GitHub Actions).',
  'Code signing of installers (needs your certificate), and the Windows SmartScreen reputation.',
  "Each country's tax and invoicing law (the packs are data, to be reviewed by a local adviser before use).",
  'A penetration test by an independent security firm.',
  'Legal review of EULA.txt, the reseller agreement and your company details (counsel).',
];

// ---------------------------------------------------------------------------------------------------------------------
const selected = checks.filter((c) => (only ? only.includes(c.name) : full || !c.full));
const rows = [];
for (const c of selected) {
  process.stdout.write(`... ${c.title}\n`);
  const t0 = Date.now();
  let r;
  try { r = c.run(); } catch (e) { r = { status: 'FAIL', detail: `the check crashed: ${e.message}` }; }
  r.seconds = Math.round((Date.now() - t0) / 1000);
  rows.push({ c, r });
  if (r.status !== 'PASS') console.log(`    ${r.status}: ${String(r.detail).split('\n').join('\n    ')}`);
}

const pad = (s, n) => String(s).padEnd(n);
console.log('\n=== Release gate ===');
for (const { c, r } of rows) console.log(`${pad(r.status, 5)} ${pad(c.name, 18)} ${c.title}  (${r.seconds}s)`);
const failed = rows.filter((x) => x.r.status === 'FAIL');
const skipped = rows.filter((x) => x.r.status === 'SKIP');
const notRun = checks.filter((c) => !selected.includes(c));
console.log(`\n${rows.length - failed.length - skipped.length} passed, ${failed.length} failed, ${skipped.length} skipped, ${notRun.length} not run (${full ? 'full' : 'quick'} mode).`);
if (notRun.length) console.log(`Not run in this mode: ${notRun.map((c) => c.name).join(', ')}  (use --full)`);
console.log('\nNOT VERIFIED by this gate (say so whenever you report on the work):');
for (const n of NOT_VERIFIED) console.log(`  - ${n}`);
const bad = failed.length > 0 || (full && skipped.length > 0);
console.log(bad ? '\nGATE: NOT PASSED. The work is not complete.' : (full ? '\nGATE: PASSED (full). Remember the NOT VERIFIED list.' : '\nQuick checks passed. Run with --full before saying anything is complete.'));
process.exit(bad ? 1 : 0);
