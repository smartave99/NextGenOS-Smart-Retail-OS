// The keys for AI services. A key comes from the computer's own settings (an environment variable) or, when a person pastes it into the Studio, from one small file in
// that person's own user folder (never in the workspace, never in the repository, never in a backup). A key is never shown again, never written to the activity record,
// and never sent anywhere but to the service it belongs to.
import { existsSync, readFileSync, mkdirSync, chmodSync } from 'node:fs';
import { homedir, platform } from 'node:os';
import { join } from 'node:path';
import { writeAtomic } from './fsx.mjs';

export const PROVIDERS = {
  anthropic: { label: 'Claude (Anthropic API)', env: ['ANTHROPIC_API_KEY'] },
  openai: { label: 'OpenAI or an OpenAI-compatible service', env: ['OPENAI_API_KEY'] },
  gemini: { label: 'Google Gemini', env: ['GEMINI_API_KEY', 'GOOGLE_API_KEY'] },
  generic: { label: 'Another tool (key passed to it)', env: ['SETUP_STUDIO_GENERIC_KEY'] },
};

export function configFolder(env = process.env) {
  if (env.SETUP_STUDIO_HOME) return env.SETUP_STUDIO_HOME;
  if (platform() === 'win32') return join(env.APPDATA || join(homedir(), 'AppData', 'Roaming'), 'NextGenOS Setup Studio');
  return join(env.XDG_CONFIG_HOME || join(homedir(), '.config'), 'nextgenos-setup-studio');
}

const file = (env) => join(configFolder(env), 'keys.json');
const readFile = (env) => { try { return existsSync(file(env)) ? JSON.parse(readFileSync(file(env), 'utf8')) : {}; } catch { return {}; } };

/** The key for a service, or null. The computer's own setting wins over a pasted one. */
export function getKey(provider, env = process.env) {
  const p = PROVIDERS[provider];
  if (!p) return null;
  for (const name of p.env) if (env[name]) return env[name];
  const saved = readFile(env)[provider];
  return typeof saved === 'string' && saved ? saved : null;
}

/** Says whether a key is there and where it comes from, never the key. */
export function keyStatus(env = process.env) {
  const saved = readFile(env);
  const out = {};
  for (const [id, p] of Object.entries(PROVIDERS)) out[id] = { label: p.label, set: !!getKey(id, env), from: p.env.some((n) => env[n]) ? 'computer' : saved[id] ? 'studio' : null, envNames: p.env };
  return out;
}

export function saveKey(provider, key, env = process.env) {
  if (!PROVIDERS[provider]) throw new Error('That service is not known.');
  const value = String(key ?? '').trim();
  if (value.length < 8 || value.length > 400 || /\s/.test(value)) throw new Error('That does not look like a key. Paste the whole key, without spaces.');
  const all = readFile(env);
  all[provider] = value;
  mkdirSync(configFolder(env), { recursive: true, mode: 0o700 });
  writeAtomic(file(env), JSON.stringify(all, null, 2) + '\n', { mode: 0o600 });
  try { chmodSync(file(env), 0o600); } catch { /* the folder is the person's own on this system */ }
}

export function removeKey(provider, env = process.env) {
  const all = readFile(env);
  delete all[provider];
  writeAtomic(file(env), JSON.stringify(all, null, 2) + '\n', { mode: 0o600 });
}

// ---- the two access codes for the build service -----------------------------------------------------------------------------------------------------
// The build service makes a customer's website and Android app. The Studio holds two access codes for it: one that may only start builds and watch them, and one that may only
// keep and fetch the results. They are kept exactly like the AI keys: in the same small file in this person's own user folder, never in the workspace, a pack, a backup, the
// activity record or a message, never shown again, and sent only to the build service.
export const BUILD_CODES = {
  start: { label: 'Access code for starting builds', key: 'build-start' },
  results: { label: 'Access code for keeping the results', key: 'build-results' },
};

/** The access code, or null. */
export function getBuildCode(which, env = process.env) {
  const c = BUILD_CODES[which];
  if (!c) return null;
  const saved = readFile(env)[c.key];
  return typeof saved === 'string' && saved ? saved : null;
}

/** Says whether each code is there, never the code. */
export function buildCodeStatus(env = process.env) {
  return Object.fromEntries(Object.entries(BUILD_CODES).map(([id, c]) => [id, { label: c.label, set: !!getBuildCode(id, env) }]));
}

export function saveBuildCode(which, code, env = process.env) {
  const c = BUILD_CODES[which];
  if (!c) throw new Error('That access code is not known.');
  const value = String(code ?? '').trim();
  if (value.length < 20 || value.length > 400 || !/^[\x21-\x7e]+$/.test(value)) throw new Error('That does not look like an access code. Paste the whole code, without spaces.');
  const other = Object.keys(BUILD_CODES).find((id) => id !== which);
  if (getBuildCode(other, env) === value) throw new Error('This is the same code as the other box. The two boxes need two different codes: one for starting builds and one for keeping the results.');
  const all = readFile(env);
  all[c.key] = value;
  mkdirSync(configFolder(env), { recursive: true, mode: 0o700 });
  writeAtomic(file(env), JSON.stringify(all, null, 2) + '\n', { mode: 0o600 });
  try { chmodSync(file(env), 0o600); } catch { /* the folder is the person's own on this system */ }
}

export function removeBuildCode(which, env = process.env) {
  const c = BUILD_CODES[which];
  if (!c) throw new Error('That access code is not known.');
  const all = readFile(env);
  delete all[c.key];
  writeAtomic(file(env), JSON.stringify(all, null, 2) + '\n', { mode: 0o600 });
}

// ---- the staff access code for the Licence Studio, and the activation keys of the licences it made ----------------------------------------------------------
// The Licence Studio is a separate private program on the owner's own server. It gives this Studio one staff access code of its own (it may ask about a customer's licences and
// do the few things staff may do, and nothing else; it can be switched off alone). The Studio never holds the licence SIGNING key: only this limited code. Both the code and the
// activation keys (the "NGOS-..." text a customer types when they first start the program) are kept like the other secrets: in the small file in this person's own user folder, never
// in the workspace, a backup, a pack, the activity record or a message, and sent only to the Licence Studio.
export const LICENCE_CODE = { label: 'Staff access code for the Licence Studio', key: 'licence-service' };

const printable = (v, min) => typeof v === 'string' && v.length >= min && v.length <= 400 && /^[\x21-\x7e]+$/.test(v);

/** The staff access code for the Licence Studio, or null. */
export function getLicenceCode(env = process.env) {
  const saved = readFile(env)[LICENCE_CODE.key];
  return typeof saved === 'string' && saved ? saved : null;
}

/** Says whether the code is there, never the code. */
export function licenceCodeStatus(env = process.env) {
  return { label: LICENCE_CODE.label, set: !!getLicenceCode(env) };
}

export function saveLicenceCode(code, env = process.env) {
  const value = String(code ?? '').trim();
  if (!printable(value, 16)) throw new Error('That does not look like a staff access code. Paste the whole code, without spaces.');
  for (const which of Object.keys(BUILD_CODES)) if (getBuildCode(which, env) === value) throw new Error('That is one of the build service\'s access codes. The Licence Studio gives out a staff access code of its own: paste that one.');
  const all = readFile(env);
  all[LICENCE_CODE.key] = value;
  mkdirSync(configFolder(env), { recursive: true, mode: 0o700 });
  writeAtomic(file(env), JSON.stringify(all, null, 2) + '\n', { mode: 0o600 });
  try { chmodSync(file(env), 0o600); } catch { /* the folder is the person's own on this system */ }
}

export function removeLicenceCode(env = process.env) {
  const all = readFile(env);
  delete all[LICENCE_CODE.key];
  writeAtomic(file(env), JSON.stringify(all, null, 2) + '\n', { mode: 0o600 });
}

const keyName = (customerId, lid) => `${customerId}/${lid}`;

/** The activation key of a licence that this Studio asked for, or null. (The Licence Studio shows the whole key only once, when it makes the licence.) */
export function getLicenceKey(customerId, lid, env = process.env) {
  const held = readFile(env)['licence-keys'];
  const v = held && typeof held === 'object' ? held[keyName(customerId, lid)] : null;
  return typeof v === 'string' && v ? v : null;
}

/** Every activation key held, as the texts only (used to keep them out of any message). */
export function heldLicenceKeys(env = process.env) {
  const held = readFile(env)['licence-keys'];
  return held && typeof held === 'object' ? Object.values(held).filter((v) => typeof v === 'string' && v) : [];
}

export function saveLicenceKey(customerId, lid, key, env = process.env) {
  const value = String(key ?? '').trim();
  if (!printable(value, 8)) throw new Error('The Licence Studio sent a key the Studio could not read.');
  const all = readFile(env);
  all['licence-keys'] = { ...(all['licence-keys'] && typeof all['licence-keys'] === 'object' ? all['licence-keys'] : {}), [keyName(customerId, lid)]: value };
  mkdirSync(configFolder(env), { recursive: true, mode: 0o700 });
  writeAtomic(file(env), JSON.stringify(all, null, 2) + '\n', { mode: 0o600 });
  try { chmodSync(file(env), 0o600); } catch { /* the folder is the person's own on this system */ }
}
