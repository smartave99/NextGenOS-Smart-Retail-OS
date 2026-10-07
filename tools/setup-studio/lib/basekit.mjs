// The programs folder: the files of one NextGenOS release (the Hub's Windows setup and Linux package, the AI assistant, the website, the Android apps), with base-kit.json
// that names each one and its SHA-256 fingerprint. The Studio reads it, checks every file against its fingerprint, and then only copies; it never builds a program.
// The list protects against a damaged or incomplete download. It is not a signature: it cannot tell an authentic list from a forged one.
import { createHash } from 'node:crypto';
import { createReadStream, existsSync, readFileSync, statSync } from 'node:fs';
import { join, resolve } from 'node:path';

export const ROLES = {
  'hub-windows-setup': 'The Windows setup for the Hub',
  'hub-windows-zip': 'The Hub as a zip for Windows',
  'hub-linux-deb': 'The Linux package for the Hub',
  'ai-addon-windows': 'The AI assistant for Windows',
  'website-generic': 'The website program, the same for every customer (the Studio puts a customer\'s folder and licence beside it)',
  website: 'A website made for one customer',
  'android-apk': 'An Android app',
  'android-aab': 'An Android app for the Play Store',
};
const PLAIN_NAME = /^[A-Za-z0-9][A-Za-z0-9._+-]{0,150}$/;

export async function sha256File(path) {
  const h = createHash('sha256');
  for await (const chunk of createReadStream(path)) h.update(chunk);
  return h.digest('hex');
}

/**
 * Reads and checks a programs folder. Returns { ok, folder, version, trial, signing, files, problems }, where files are [{ name, role, os, arch, kit?, bytes, sha256, path }].
 * Every problem is a sentence a person can act on. When the manifest is missing or unreadable nothing else is looked at.
 */
export async function readBaseKit(folder) {
  const problems = [];
  const root = folder ? resolve(String(folder)) : '';
  const out = { ok: false, folder: root, version: null, trial: false, signing: { windows: 'unknown', android: 'unknown' }, files: [], problems };
  if (!root || !existsSync(root) || !statSync(root).isDirectory()) { problems.push('That folder was not found. Type the full path of the folder where you saved the release files.'); return out; }
  const manifestPath = join(root, 'base-kit.json');
  if (!existsSync(manifestPath)) { problems.push('The file base-kit.json is not in that folder. Download every file of the release into one folder, including base-kit.json.'); return out; }
  let m;
  try { m = JSON.parse(readFileSync(manifestPath, 'utf8')); } catch { problems.push('base-kit.json cannot be read. Download it again.'); return out; }
  if (!m || m.schema !== 1 || !Array.isArray(m.files)) { problems.push('base-kit.json is not one this Studio understands. Update the Studio, or download the release again.'); return out; }
  if (!/^\d+\.\d+\.\d+$/.test(String(m.version))) problems.push('base-kit.json does not say which version this is.');
  out.version = String(m.version);
  out.trial = m.trial === true;
  out.signing = { windows: String(m.signing?.windows ?? 'unknown').slice(0, 80), android: String(m.signing?.android ?? 'unknown').slice(0, 80) };
  for (const f of m.files.slice(0, 200)) {
    const name = String(f?.name ?? '');
    if (!PLAIN_NAME.test(name) || name.includes('..')) { problems.push(`base-kit.json lists a file with a name that is not allowed: ${name.slice(0, 60)}`); continue; }
    if (!ROLES[f.role]) continue;   // a part this Studio does not know (a newer release): left alone
    const path = join(root, name);
    if (!existsSync(path)) { problems.push(`${name} is missing. Download it into the same folder.`); continue; }
    const bytes = statSync(path).size;
    if (bytes !== f.bytes) { problems.push(`${name} is ${bytes < f.bytes ? 'incomplete' : 'not the file that was released'} (${bytes} bytes, expected ${f.bytes}). Download it again.`); continue; }
    if (await sha256File(path) !== f.sha256) { problems.push(`${name} does not match its fingerprint, so it was damaged or changed. Download it again.`); continue; }
    out.files.push({ name, role: f.role, os: String(f.os ?? ''), arch: String(f.arch ?? ''), ...(f.kit ? { kit: String(f.kit) } : {}), bytes, sha256: f.sha256, path });
  }
  if (!out.files.some((f) => f.role.startsWith('hub-'))) problems.push('No Hub program was found in this folder.');
  out.ok = problems.length === 0;
  return out;
}

/** The files of a role (and a system, a processor, a brand kit), as the pack builder asks for them. */
export function pick(kit, role, { os, arch, kit: brand } = {}) {
  return kit.files.filter((f) => f.role === role && (!os || f.os === os) && (!arch || f.arch === arch) && (brand === undefined || f.kit === brand));
}
