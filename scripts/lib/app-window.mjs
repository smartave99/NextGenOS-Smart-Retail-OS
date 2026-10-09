// Opening a local program as a program of its own: a window with no address bar and no terminal behind it, one copy at a time, stopping when the window is closed.
// The program is a web page served on this PC only; the window is the PC's own Edge, Chrome or Chromium (Windows always has Edge) opened in "app" mode with a profile of its own,
// so closing it is something the program can see. Nothing here is specific to one program: the Setup Studio, the Brand Studio and the website each use this file.
// There is ONE source: scripts/lib/app-window.mjs. The copies in tools/setup-studio/lib and tools/brand-studio/lib, and the one a website package carries, are the same file
// (a test says so), because each of those programs travels without the rest of the repository.
import { spawn } from 'node:child_process';
import { existsSync, mkdirSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { delimiter, join } from 'node:path';

/** Browsers that can show a page as an app window, in the order they are tried. */
const WINDOWS = [['Microsoft', 'Edge', 'Application', 'msedge.exe'], ['Google', 'Chrome', 'Application', 'chrome.exe'], ['BraveSoftware', 'Brave-Browser', 'Application', 'brave.exe'], ['Vivaldi', 'Application', 'vivaldi.exe']];
const LINUX = ['microsoft-edge', 'microsoft-edge-stable', 'google-chrome', 'google-chrome-stable', 'chromium', 'chromium-browser', 'brave-browser', 'vivaldi'];
const MACOS = ['/Applications/Microsoft Edge.app/Contents/MacOS/Microsoft Edge', '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome', '/Applications/Chromium.app/Contents/MacOS/Chromium', '/Applications/Brave Browser.app/Contents/MacOS/Brave Browser'];

/**
 * The browser to show the page in as an app window, or null when the PC has none of them.
 * `override` names one by hand (a full path to a Chromium-based browser; the settings NEXTGENOS_APP_BROWSER, or SETUP_STUDIO_BROWSER, give it); a path that does not exist is ignored.
 */
export function findAppBrowser({ platform = process.platform, env = process.env, exists = existsSync, override = env.NEXTGENOS_APP_BROWSER || env.SETUP_STUDIO_BROWSER } = {}) {
  if (override && exists(override)) return override;
  if (platform === 'win32') {
    const bases = [env['ProgramFiles(x86)'], env.ProgramFiles, env.ProgramW6432, env.LOCALAPPDATA].filter(Boolean);
    // Edge first, in every place it can be, then the others.
    for (const parts of WINDOWS) for (const base of bases) { const p = [base, ...parts].join('\\'); if (exists(p)) return p; }
    return null;
  }
  if (platform === 'darwin') return MACOS.find((p) => exists(p)) ?? null;
  const dirs = String(env.PATH ?? '').split(delimiter).filter(Boolean);
  for (const name of LINUX) for (const dir of dirs) { const p = join(dir, name); if (exists(p)) return p; }
  return null;
}

/** What the browser is told: only the program's page in a window of its own, with its own profile (so it never touches the person's own browsing). */
export function appWindowArgs(url, profileDir, { width = 1320, height = 880 } = {}) {
  // --disable-background-mode: when the window is closed the browser must end, not stay alive in the background; a copy that stays makes the next start hand its page to it and end at once.
  return [`--app=${url}`, `--user-data-dir=${profileDir}`, `--window-size=${width},${height}`, '--no-first-run', '--no-default-browser-check', '--disable-background-mode'];
}

/** Opens the app window. Returns { child, closed, started } (closed resolves with the way it ended), or null when there is no browser for it. */
export function openAppWindow(url, { browser = findAppBrowser(), profileDir, spawnFn = spawn, size } = {}) {
  if (!browser) return null;
  if (!profileDir) throw new Error('openAppWindow needs a profile folder of its own.');
  mkdirSync(profileDir, { recursive: true });
  const started = Date.now();
  const child = spawnFn(browser, appWindowArgs(url, profileDir, size), { stdio: 'ignore' });
  const closed = new Promise((resolve) => {
    child.once('exit', (code, signal) => resolve({ code, signal, ms: Date.now() - started }));
    child.once('error', (error) => resolve({ error, ms: Date.now() - started }));
  });
  return { child, closed, started };
}

/**
 * Whether the window's end means "the person closed it". A browser that ends within a few seconds of starting, or could not start, handed the page to another browser
 * program (or never opened it).
 */
export function windowWasClosedByPerson(ended, quickMs = 5000) {
  return !ended.error && ended.ms >= quickMs;
}

/**
 * Waits until seen() says yes, for at most waitMs. Gives true when it was seen, false when the time ran out. (The clock and the pause can be replaced, for tests.)
 */
export async function waitUntil(seen, { waitMs = 40_000, pollMs = 250, now = Date.now, sleep = (ms) => new Promise((resolve) => setTimeout(resolve, ms)) } = {}) {
  const end = now() + waitMs;
  while (now() < end) {
    if (seen()) return true;
    await sleep(pollMs);
  }
  return !!seen();
}

/**
 * What to do when the window's browser program has ended.
 *   'stop'           the person closed the window: stop the program.
 *   'handed-off'     it ended at once, but the page itself said it is there (Edge and Chrome hand the page to a copy of themselves that is already running and end): the window is open,
 *                    only it is not ours to watch. Leave it alone, and stop when nobody has used the page for a while. Opening the page again in the usual browser would show it twice.
 *   'show-elsewhere' it could not start, or no page appeared in time: there is no window of ours to show. The caller says so in a plain note and stops; it never shows the page in the PC's usual web browser (the owner's rule: our programs open like programs).
 * pageSeen() says whether the page has said it is there since the window was opened.
 */
export async function whatNextAfterWindow(ended, { pageSeen, waitMs, ...timing }) {
  if (windowWasClosedByPerson(ended)) return 'stop';
  if (ended.error) return 'show-elsewhere';
  return (await waitUntil(pageSeen, { waitMs, ...timing })) ? 'handed-off' : 'show-elsewhere';
}

/** How long a page that was handed to a browser we cannot watch may be silent before the program stops (a page that is hidden or minimised still says it is there about once a minute). */
export const HANDED_OFF_IDLE_MS = 3 * 60_000;

// ---- one copy at a time --------------------------------------------------------------------------------------------------------------

export const runningFile = (dir) => join(dir, 'running.json');

export function writeRunning({ pid = process.pid, url, folder }, dir) {
  mkdirSync(dir, { recursive: true });
  writeFileSync(runningFile(dir), JSON.stringify({ pid, url, folder, started: new Date().toISOString() }) + '\n', { mode: 0o600 });
}

export function clearRunning(dir, pid = process.pid) {
  try {
    const now = JSON.parse(readFileSync(runningFile(dir), 'utf8'));
    if (now.pid === pid) rmSync(runningFile(dir), { force: true });
  } catch { /* nothing to clear */ }
}

const pidAlive = (pid) => { try { process.kill(pid, 0); return true; } catch (e) { return e.code === 'EPERM'; } };

/**
 * The copy that is already running for this person, or null. A leftover note from a program that is gone is removed.
 * `answers(url)` says whether the program really answers at that address (each program asks in its own way); the address must be this PC's own.
 */
export async function findRunning(dir, { answers, alive = pidAlive } = {}) {
  let note;
  try { note = JSON.parse(readFileSync(runningFile(dir), 'utf8')); } catch { return null; }
  const gone = () => { rmSync(runningFile(dir), { force: true }); return null; };
  if (!note || typeof note.url !== 'string' || !Number.isInteger(note.pid) || !alive(note.pid)) return gone();
  try {
    if (new URL(note.url).hostname !== '127.0.0.1') return gone();
    return (await answers(note.url)) ? { url: note.url, pid: note.pid, folder: note.folder } : gone();
  } catch { return gone(); }
}

// ---- nobody is using it any more -----------------------------------------------------------------------------------------------------

/**
 * Calls onIdle when no page has said it is there (beat) for idleMs. A time when the whole PC was asleep is not counted: after sleep the first check only starts the count again.
 */
export function idleWatch({ idleMs = 10 * 60_000, tickMs = 30_000, now = Date.now, onIdle, every = setInterval, stopEvery = clearInterval }) {
  let last = now();
  let before = last;
  const timer = every(() => {
    const t = now();
    const gap = t - before;
    before = t;
    if (gap > tickMs * 3) { last = t; return; }
    if (t - last > idleMs) { stopEvery(timer); onIdle(); }
  }, tickMs);
  timer?.unref?.();
  return { beat: () => { last = now(); }, stop: () => stopEvery(timer) };
}
