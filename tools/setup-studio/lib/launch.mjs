// The Setup Studio's way of opening itself as a program of its own. The general part (which browser, the window, one copy at a time, nobody is using it) is app-window.mjs,
// the same file as scripts/lib/app-window.mjs; this file adds what is the Studio's own: where it keeps its note, and how it knows that a Studio really answers.
import { join } from 'node:path';
import { configFolder } from './secrets.mjs';
import * as window from './app-window.mjs';

export { findAppBrowser, appWindowArgs, windowWasClosedByPerson, whatNextAfterWindow, waitUntil, HANDED_OFF_IDLE_MS, idleWatch } from './app-window.mjs';

export const runningFile = (env = process.env) => window.runningFile(configFolder(env));
export const writeRunning = (note, env = process.env) => window.writeRunning(note, configFolder(env));
export const clearRunning = (env = process.env, pid = process.pid) => window.clearRunning(configFolder(env), pid);

/** Opens the Studio's window, with a profile of its own inside the Studio's config folder. */
export const openAppWindow = (url, options = {}) => window.openAppWindow(url, { profileDir: join(configFolder(), 'window'), ...options });

/** The Studio that is already running for this person, or null: it must answer /api/state with the secret in its own address. */
export function findRunning(env = process.env, { fetchFn = fetch, alive } = {}) {
  return window.findRunning(configFolder(env), {
    alive,
    answers: async (url) => {
      const u = new URL(url);
      const res = await fetchFn(`${u.origin}/api/state`, { headers: { 'x-studio-key': u.searchParams.get('k') ?? '' }, signal: AbortSignal.timeout(3000) });
      const body = res.ok ? await res.json() : null;
      return !!body && typeof body.initialised === 'boolean';
    },
  });
}
