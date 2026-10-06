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
