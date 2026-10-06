#!/usr/bin/env node
/**
 * Makes the Setup Studio as one folder (and one zip) a member of staff can unpack and double-click, on a computer with nothing installed: it carries its own Node.js.
 *
 *   node tools/setup-studio/scripts/make-bundle.mjs --os windows|linux|macos --version 1.0.0 [--out dist] (--node-runtime <folder> | --download-node 22.12.0)
 *
 *   --node-runtime  a folder with an official Node.js runtime of that system already unpacked (node.exe, or bin/node)
 *   --download-node fetches nodejs.org's own build of that version for that system, and checks it against nodejs.org's published SHA-256 list
 *
 * What goes in: the Studio's program, the part of the Brand Studio it shares, the country and industry packs (as data), the Hub's two style files for the preview, the Studio's one
 * library (production only), and Node.js. What never goes in: tests, the workspace, keys, `.env` files, a `.git` folder. The bundle is for staff; it is never given to a customer.
 */
import { createHash } from 'node:crypto';
import { chmodSync, cpSync, existsSync, mkdirSync, mkdtempSync, readFileSync, readdirSync, rmSync, statSync, writeFileSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, resolve, dirname, relative, sep } from 'node:path';
import { fileURLToPath } from 'node:url';
import { writeZipFile } from '../lib/zip.mjs';
import { buildLauncher } from '../../../scripts/lib/build-launcher.mjs';
import { SECRET_PATTERNS, SECRET_ALLOW } from '../../../scripts/lib/secret-patterns.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const studio = resolve(here, '..');
const repo = resolve(studio, '..', '..');
const args = process.argv.slice(2);
const flag = (n) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : undefined; };
const os = flag('--os');
const version = flag('--version') ?? JSON.parse(readFileSync(join(studio, 'package.json'), 'utf8')).version;
const out = resolve(flag('--out') ?? join(repo, 'dist'));
if (!['windows', 'linux', 'macos'].includes(os ?? '')) { console.error('Say the system: --os windows|linux|macos'); process.exit(2); }
if (!/^\d+\.\d+\.\d+$/.test(version)) { console.error('The version must be three numbers: --version 1.0.0'); process.exit(2); }

const say = (m) => console.log(`\n== ${m}`);
const run = (cmd, a, opts = {}) => {
  const r = spawnSync(cmd, a, { encoding: 'utf8', maxBuffer: 256 * 1024 * 1024, ...opts });
  if (r.error || r.status !== 0) { console.error(`\n${cmd} ${a.join(' ')}\n${r.error?.message ?? ''}${(r.stdout || '').slice(-3000)}${(r.stderr || '').slice(-3000)}`); process.exit(1); }
  return r.stdout || '';
};
const sha256 = (buf) => createHash('sha256').update(buf).digest('hex');

/** The Node.js runtime for the bundle: [{ from, to, mode }] files to put under node/. */
async function runtime(work) {
  const given = flag('--node-runtime');
  const wantedFile = os === 'windows' ? 'node.exe' : join('bin', 'node');
  if (given) {
    const root = resolve(given);
    if (!existsSync(join(root, wantedFile))) { console.error(`${join(root, wantedFile)} was not found. Give the folder of an unpacked official Node.js for ${os}.`); process.exit(1); }
    return { root, files: [wantedFile, ...['LICENSE', 'LICENSE.md'].filter((f) => existsSync(join(root, f)))] };
  }
  const v = flag('--download-node');
  if (!v || !/^\d+\.\d+\.\d+$/.test(v)) { console.error('Give the Node.js to carry: --node-runtime <folder> or --download-node 22.12.0'); process.exit(2); }
  const arch = os === 'macos' ? 'darwin-arm64' : os === 'windows' ? 'win-x64' : 'linux-x64';
  const name = `node-v${v}-${arch}.${os === 'windows' ? 'zip' : 'tar.xz'}`;
  const base = `https://nodejs.org/dist/v${v}`;
  say(`Fetching ${name} from nodejs.org`);
  const sums = await (await fetch(`${base}/SHASUMS256.txt`)).text();
  const want = sums.split('\n').map((l) => l.trim().split(/\s+/)).find((p) => p[1] === name)?.[0];
  if (!want) { console.error(`nodejs.org's list has no ${name}.`); process.exit(1); }
  const res = await fetch(`${base}/${name}`);
  if (!res.ok) { console.error(`Could not download ${name} (${res.status}).`); process.exit(1); }
  const buf = Buffer.from(await res.arrayBuffer());
  if (sha256(buf) !== want) { console.error(`${name} does not match nodejs.org's published fingerprint. Not used.`); process.exit(1); }
  const file = join(work, name);
  writeFileSync(file, buf);
  const root = join(work, 'node-runtime');
  mkdirSync(root, { recursive: true });
  if (os === 'windows') run('unzip', ['-q', file, '-d', root]); else run('tar', ['-xf', file, '-C', root]);
  const inner = join(root, `node-v${v}-${arch}`);
  return { root: inner, files: [wantedFile, ...['LICENSE', 'LICENSE.md'].filter((f) => existsSync(join(inner, f)))] };
}

const work = mkdtempSync(join(tmpdir(), 'studio-bundle-'));
try {
  const top = join(work, 'NextGenOS Setup Studio');
  const tools = join(top, 'tools');
  const here2 = join(tools, 'setup-studio');
  say('Copying the Studio');
  mkdirSync(here2, { recursive: true });
  for (const f of ['studio.mjs', 'package.json', 'package-lock.json']) cpSync(join(studio, f), join(here2, f));
  for (const d of ['lib', 'ui']) cpSync(join(studio, d), join(here2, d), { recursive: true });
  // The launchers sit at the top of the bundle; they start the Studio from its own folder, with the Node.js beside it, and show it in a window of its own (no terminal).
  if (os === 'windows') {
    // "Setup Studio.exe" is a small program with the Studio's icon that starts the Studio's Node.js with no console window. It is made here with NSIS (makensis).
    try {
      buildLauncher({ outFile: join(top, 'Setup Studio.exe'), name: 'NextGenOS Setup Studio', program: 'tools\\setup-studio\\node\\node.exe', workdir: 'tools\\setup-studio', check: 'tools\\setup-studio\\studio.mjs', args: 'studio.mjs serve --app', icon: join(studio, 'launcher', 'studio.ico'), version });
    } catch (e) { console.error(`\n${e.message}`); process.exit(1); }
    cpSync(join(studio, 'launcher', 'Setup Studio (with a window, for problems).bat'), join(top, 'Setup Studio (with a window, for problems).bat'));
  } else {
    cpSync(join(studio, 'launcher', 'setup-studio.sh'), join(top, 'setup-studio.sh'));
    chmodSync(join(top, 'setup-studio.sh'), 0o755);
  }
  mkdirSync(join(tools, 'brand-studio', 'lib'), { recursive: true });
  cpSync(join(repo, 'tools', 'brand-studio', 'lib', 'kit.mjs'), join(tools, 'brand-studio', 'lib', 'kit.mjs'));
  say('Copying the packs and the Hub\'s style files (data)');
  cpSync(join(repo, 'country-packs', 'packs'), join(here2, 'packs', 'country-packs', 'packs'), { recursive: true });
  cpSync(join(repo, 'industry-packs', 'packs'), join(here2, 'packs', 'industry-packs', 'packs'), { recursive: true });
  mkdirSync(join(here2, 'assets'), { recursive: true });
  cpSync(join(repo, 'apps', 'business-hub', 'src', 'NextGenOS.Hub.Web', 'wwwroot', 'hub.css'), join(here2, 'assets', 'hub.css'));
  cpSync(join(repo, 'design', 'tokens.css'), join(here2, 'assets', 'tokens.css'));
  say('Installing the Studio\'s one library (production only)');
  run('npm', ['ci', '--omit=dev', '--ignore-scripts', '--no-audit', '--no-fund', '--prefer-offline'], { cwd: here2 });
  say('Adding Node.js');
  const rt = await runtime(work);
  for (const f of rt.files) {
    const to = join(here2, 'node', f);
    mkdirSync(dirname(to), { recursive: true });
    cpSync(join(rt.root, f), to);
    if (!f.startsWith('LICENSE') && os !== 'windows') chmodSync(to, 0o755);
  }
  writeFileSync(join(top, 'READ ME FIRST.txt'), [
    'NextGenOS Setup Studio', '======================', '',
    'For NextGenOS staff only. Do not give this folder to a customer.', '',
    os === 'windows'
      ? 'Double-click "Setup Studio" (the icon with the blue box). The Studio opens in a window of its own; there is no black terminal window.'
      : 'Run ./setup-studio.sh (once, in a terminal; you can close the terminal at once). The Studio opens in a window of its own. To have it in the applications menu, run ./setup-studio.sh --install-menu.',
    'The first time, make the administrator account. To stop the Studio, close its window or press the Quit button (the power icon, bottom left).',
    os === 'windows' ? 'If Windows says "Windows protected your PC" (the program is not signed yet): click "More info", then "Run anyway". If something goes wrong, open "Setup Studio (with a window, for problems)" and read what it says.' : 'If something goes wrong, run ./setup-studio.sh --show and read what it says.', '',
    'It keeps its files in Documents/NextGenOS Setup Studio. Back them up from Settings.',
    'To make a customer\'s pack you also need the released programs: Settings, "The programs folder".', '',
  ].join('\r\n'));

  say('Checking what is inside');
  const problems = [];
  const files = [];
  const walk = (dir) => { for (const e of readdirSync(dir, { withFileTypes: true })) { const full = join(dir, e.name); if (e.isDirectory()) { if (e.name === '.git') problems.push(`${relative(top, full)} is git data`); walk(full); } else files.push(full); } };
  walk(top);
  for (const f of files) {
    const rel = relative(top, f).split(sep).join('/');
    // Our own tests never go in (a library may carry its own, which are not ours to remove).
    if (!rel.includes('/node_modules/') && (/(^|\/)(tests?|__tests__)\//.test(rel) || /\.(test|spec|e2e)\.m?js$/.test(rel))) problems.push(`${rel} is a test file`);
    if (/(^|\/)\.env(\.|$)|(^|\/)(keys|secrets?)\.json$|\.(pem|pfx|p12|key|db|sqlite)$/i.test(rel)) problems.push(`${rel} looks like a secret or a database`);
    if (/\.(m?js|json|css|html|txt|md|bat|sh|svg)$/.test(rel) && statSync(f).size < 2_000_000) {
      const text = readFileSync(f, 'utf8');
      text.split('\n').forEach((line, i) => { for (const [re, what] of SECRET_PATTERNS) if (re.test(line) && !SECRET_ALLOW.some((a) => a.test(line))) problems.push(`${rel}:${i + 1}  ${what}`); });
    }
  }
  if (problems.length) { console.error('\nThe bundle holds what it must not:\n  ' + problems.slice(0, 40).join('\n  ')); process.exit(1); }
  console.log(`${files.length} files checked: no test, no workspace, no key, no database, no secret pattern.`);

  say('Writing the zip');
  mkdirSync(out, { recursive: true });
  const zip = join(out, `NextGenOS-Setup-Studio-${version}-${os}.zip`);
  const items = files.sort().map((f) => ({ name: `NextGenOS Setup Studio/${relative(top, f).split(sep).join('/')}`, file: f, ...(statSync(f).mode & 0o111 ? { mode: 0o755 } : {}) }));
  await writeZipFile(zip, items);
  console.log(`\nWrote:\n  ${zip}\n  SHA-256 ${sha256(readFileSync(zip))}`);
} finally {
  rmSync(work, { recursive: true, force: true });
}
