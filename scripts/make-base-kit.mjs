#!/usr/bin/env node
/**
 * Writes base-kit.json for a folder of release files: the list the Setup Studio reads to know which program is which, and to check that none was damaged on the way.
 *
 *   node scripts/make-base-kit.mjs <folder> [--version 1.0.0]
 *
 * The release workflow runs it on the files it built; a person who downloads the release's files into one folder gives that folder to the Studio.
 * Each file is named by what it is (a role), the system it is for, and its SHA-256 fingerprint. Files it does not recognise are left out of the list (and said).
 * The list guards against a damaged or incomplete download. It is not a signature: it cannot tell an authentic list from a forged one (see docs/SETUP-STUDIO.md).
 */
import { createHash } from 'node:crypto';
import { createReadStream, existsSync, readFileSync, readdirSync, statSync, writeFileSync } from 'node:fs';
import { join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

/** [pattern, role, extra(match)] in the order they are tried. The roles are the ones the Studio's pack builder asks for. */
export const RULES = [
  [/^SmartRetailPOS-Hub-Setup-(\d+\.\d+\.\d+)\.exe$/, 'hub-windows-setup', () => ({ os: 'windows', arch: 'x64' })],
  [/^SmartRetailPOS-Hub-(\d+\.\d+\.\d+)-win-x64\.zip$/, 'hub-windows-zip', () => ({ os: 'windows', arch: 'x64' })],
  [/^smart-retail-pos-hub_(\d+\.\d+\.\d+)-\d+_(amd64|arm64)\.deb$/, 'hub-linux-deb', (m) => ({ os: 'linux', arch: m[2] === 'amd64' ? 'x64' : 'arm64' })],
  [/^SmartRetailAI-Setup(?:-(\d+\.\d+\.\d+))?\.exe$/, 'ai-addon-windows', () => ({ os: 'windows', arch: 'x64' })],
  // THE website, the one program every customer gets: made once per release with no customer's settings inside. The Setup Studio puts a customer's folder and licence beside it (assemble).
  [/^website-(windows|linux)\.zip$/, 'website-generic', (m) => ({ os: m[1], arch: 'x64' })],
  // A website made for one customer (the build service's older way: the customer's folder is already beside the program): the file says whose and for which system. The version is inside it (PACKAGE-INFO.json), not in the name.
  [/^website-([a-z0-9][a-z0-9-]{1,40})-(windows|linux)\.zip$/, 'website', (m) => ({ os: m[2], arch: 'x64', kit: m[1] })],
  [/^SmartRetailPOS-([a-z0-9][a-z0-9-]{1,40})-(\d+\.\d+\.\d+)\.apk$/, 'android-apk', (m) => ({ os: 'android', kit: m[1] })],
  [/^SmartRetailPOS-([a-z0-9][a-z0-9-]{1,40})-(\d+\.\d+\.\d+)\.aab$/, 'android-aab', (m) => ({ os: 'android', kit: m[1] })],
];

export async function sha256File(path) {
  const h = createHash('sha256');
  for await (const chunk of createReadStream(path)) h.update(chunk);
  return h.digest('hex');
}

/** Looks at a folder and returns the manifest object (and the names it did not recognise). */
export async function makeBaseKit(folder, { version = null, now = new Date() } = {}) {
  const root = resolve(folder);
  const files = [];
  const ignored = [];
  const versions = new Set();
  for (const name of readdirSync(root).sort()) {
    const path = join(root, name);
    if (!statSync(path).isFile() || name === 'base-kit.json') continue;
    let matched = false;
    for (const [pattern, role, extra] of RULES) {
      const m = pattern.exec(name);
      if (!m) continue;
      matched = true;
      const v = role.startsWith('website') ? null : role.startsWith('android') ? m[2] : m[1];
      if (v) versions.add(v);
      files.push({ name, role, ...extra(m), bytes: statSync(path).size, sha256: await sha256File(path) });
      break;
    }
    if (!matched) ignored.push(name);
  }
  if (!files.length) throw new Error('No release file was recognised in that folder (a Hub setup, a Linux package, ...).');
  const say = (file) => (existsSync(join(root, file)) ? readFileSync(join(root, file), 'utf8').trim() : 'unknown');
  const hubVersions = new Set(files.filter((f) => f.role.startsWith('hub-')).map((f) => /(\d+\.\d+\.\d+)/.exec(f.name)?.[1]));
  if (hubVersions.size > 1) throw new Error(`The Hub files are of different versions (${[...hubVersions].join(', ')}). Put one release's files in the folder.`);
  const chosen = version ?? [...hubVersions][0] ?? [...versions][0];
  if (!/^\d+\.\d+\.\d+$/.test(chosen ?? '')) throw new Error('Say the version as three numbers: --version 1.0.0');
  return {
    manifest: {
      schema: 1, version: chosen, createdAt: now.toISOString(),
      trial: existsSync(join(root, 'NO-LICENCE-KEYS-TRIAL-ONLY.txt')),
      signing: { windows: say('WINDOWS-SIGNING.txt'), android: say('ANDROID-SIGNING.txt').replace(/^Signed with:\s*/, '') },
      files,
    },
    ignored,
  };
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const args = process.argv.slice(2);
  const folder = args.find((a, i) => !a.startsWith('--') && !(i > 0 && args[i - 1] === '--version'));
  if (!folder || !existsSync(folder)) { console.error('Usage: node scripts/make-base-kit.mjs <folder of release files> [--version 1.0.0]'); process.exit(2); }
  try {
    const { manifest, ignored } = await makeBaseKit(folder, { version: args.includes('--version') ? args[args.indexOf('--version') + 1] : null });
    writeFileSync(join(resolve(folder), 'base-kit.json'), JSON.stringify(manifest, null, 2) + '\n');
    console.log(`base-kit.json: version ${manifest.version}, ${manifest.files.length} file(s)${manifest.trial ? ', TRIAL BUILD (no licence keys)' : ''}`);
    for (const f of manifest.files) console.log(`  ${f.role.padEnd(18)} ${f.name}`);
    if (ignored.length) console.log(`Not listed (not recognised): ${ignored.join(', ')}`);
  } catch (e) { console.error(String(e.message || e)); process.exit(1); }
}
