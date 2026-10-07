// Where the programs are. The Studio puts a customer's pack together from the files of one NextGenOS release (the "kit": base-kit.json and the files it lists).
// There are two places such a kit can be:
//   1. the kit built into this Studio: the "Complete" Studio carries every program of a release in a folder called "kit" next to the program (<install folder>/kit, and the same in
//      the portable zip). Staff download and choose nothing.
//   2. a folder an administrator chose in Settings (for a newer release than the one built in, or when this Studio has no kit of its own).
// A folder the administrator chose always wins: it is what they asked for. With none chosen, the built-in kit is used. All the same checks apply to both (readBaseKit: every file
// against its fingerprint; a trial release only "to try it"). Nothing here builds anything and nothing is fetched from anywhere.
import { existsSync, readFileSync, readdirSync, statSync } from 'node:fs';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { readBaseKit } from './basekit.mjs';

const here = dirname(fileURLToPath(import.meta.url));

/**
 * The folder where this Studio's own kit would be. The bundle puts the Studio's files in <top>/tools/setup-studio, so the top (the install folder, or the unpacked zip) is three
 * folders above this file, and the kit is <top>/kit. In a checkout of the repository there is no such folder, so no kit is found there.
 */
export const builtInKitFolder = () => resolve(here, '..', '..', '..', 'kit');

/** Three whole numbers, compared as numbers: negative when a is older than b. Anything that is not a version counts as older than a real one. */
export function compareVersions(a, b) {
  const parse = (v) => (/^(\d+)\.(\d+)\.(\d+)$/.exec(String(v ?? '')) ?? []).slice(1).map(Number);
  const x = parse(a); const y = parse(b);
  if (!x.length || !y.length) return x.length ? 1 : y.length ? -1 : 0;
  for (let i = 0; i < 3; i += 1) if (x[i] !== y[i]) return x[i] < y[i] ? -1 : 1;
  return 0;
}

/** A quick look at a kit folder without reading the big files: is there a list, which release does it say, is it a trial. Never throws. */
export function peekKit(folder) {
  const none = { present: false, folder: folder ? resolve(String(folder)) : '', version: null, trial: false };
  try {
    const root = resolve(String(folder));
    const file = join(root, 'base-kit.json');
    if (!existsSync(file) || !statSync(file).isFile()) return none;
    const m = JSON.parse(readFileSync(file, 'utf8'));
    if (!m || m.schema !== 1 || !Array.isArray(m.files)) return { ...none, folder: root, present: true, version: null };
    return { present: true, folder: root, version: /^\d+\.\d+\.\d+$/.test(String(m.version)) ? String(m.version) : null, trial: m.trial === true };
  } catch { return none; }
}

// Reading a kit means reading every file once to check its fingerprint, and the kit built into the Studio is several hundred megabytes. It is read again only when a file has changed
// (its name, size or time), so the first screen does not wait for it each time. A pack is always made from a fresh, full check (fresh: true).
const cache = new Map();
function stampOf(root) {
  try {
    return readdirSync(root).sort().map((name) => { const s = statSync(join(root, name)); return `${name}|${s.size}|${s.mtimeMs}`; }).join('\n');
  } catch { return null; }
}

/** readBaseKit, remembered while nothing in the folder has changed. */
export async function readKit(folder, { fresh = false } = {}) {
  const root = resolve(String(folder));
  const stamp = stampOf(root);
  const hit = cache.get(root);
  if (!fresh && stamp !== null && hit?.stamp === stamp) return hit.kit;
  const kit = await readBaseKit(root);
  if (stamp !== null) cache.set(root, { stamp, kit }); else cache.delete(root);
  return kit;
}

/**
 * What the Studio uses now. `chosen` is the folder an administrator typed in Settings ('' for none); `builtIn` is the folder of the kit built into this Studio.
 * Returns { source: 'chosen' | 'built-in' | 'none', folder, builtIn: { present, version, trial, folder }, kit, newerBuiltIn }:
 *   kit is the checked result of readBaseKit for the folder in use (null when there is none), newerBuiltIn is true when a folder was chosen but the kit built into this Studio is a
 *   newer release than the one in it (so the Studio can say so and offer to use its own).
 */
export async function programsInUse({ chosen = '', builtIn = builtInKitFolder(), fresh = false } = {}) {
  const inside = peekKit(builtIn);
  const wanted = String(chosen ?? '').trim();
  if (wanted) {
    const kit = await readBaseKit(wanted);   // a folder somebody chose is read again every time, as before
    return { source: 'chosen', folder: kit.folder, builtIn: inside, kit, newerBuiltIn: inside.present && !!inside.version && compareVersions(inside.version, kit.version) > 0 };
  }
  if (inside.present) {
    const kit = await readKit(inside.folder, { fresh });
    return { source: 'built-in', folder: inside.folder, builtIn: inside, kit, newerBuiltIn: false };
  }
  return { source: 'none', folder: '', builtIn: inside, kit: null, newerBuiltIn: false };
}

/** The words for the first-screen checklist, for the programs line. state is one of: missing, problem, trial, ready. */
export function programsLine({ source, builtIn, kit, newerBuiltIn }) {
  const hint = 'Fix it in Settings, "The programs folder".';
  if (source === 'none') {
    return {
      state: 'missing',
      text: 'The Studio does not build programs. It puts a customer\'s installer together from the files of a release. On GitHub open the release, download every file into one folder, then choose that folder in Settings, "The programs folder". Until then it cannot give anyone an installer. (The Complete Setup Studio of a release has these files built in, so nothing has to be downloaded.)',
    };
  }
  if (!kit.ok) {
    return {
      state: 'problem',
      text: source === 'built-in'
        ? `The programs built into this Studio have a problem: ${kit.problems?.[0] ?? 'they cannot be read'}. Install the Complete Setup Studio again, or choose a folder with a release's files in Settings, "The programs folder".`
        : `The programs folder has a problem: ${kit.problems?.[0] ?? 'it cannot be read'}. ${hint}`,
    };
  }
  const where = source === 'built-in' ? `Built into this Studio: release ${kit.version}.` : `Release ${kit.version} is in place (the folder chosen in Settings).`;
  const newer = newerBuiltIn ? ` This Studio has a newer release built in (release ${builtIn.version}): in Settings, "The programs folder", press "Use the programs built into this Studio" to use it.` : '';
  if (kit.trial) {
    return {
      state: 'trial',
      text: `${where} These files come from a trial release without licence keys. The Studio can make a pack from them only to try it, never to give to a customer. A release made with your licence keys is needed for a real customer.${newer}`,
    };
  }
  return { state: 'ready', text: source === 'built-in' ? `${where} Nothing has to be downloaded.${newer}` : `${where}${newer}` };
}
