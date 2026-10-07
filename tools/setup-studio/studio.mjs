#!/usr/bin/env node
/**
 * NextGenOS Setup Studio: turn a customer's details into a ready-to-install Smart Retail POS (their look, words and settings). For NextGenOS staff only.
 *
 *   node tools/setup-studio/studio.mjs serve --app [--folder <where the Studio keeps its files>] [--port 5391]
 *       opens the Studio in a window of its own (no address bar, no terminal); one Studio at a time; closing the window stops it
 *   node tools/setup-studio/studio.mjs serve [--open] [...]     runs in this terminal; --open also opens it in the PC's usual browser
 *   node tools/setup-studio/studio.mjs check                    check the Studio's files (the activity record, every approved release)
 *   node tools/setup-studio/studio.mjs where                    say where the Studio keeps its files
 *
 * Everything else is done in the page it shows (on this PC only). See docs/SETUP-STUDIO.md.
 */
import { spawn } from 'node:child_process';
import { mkdirSync, writeFileSync } from 'node:fs';
import { join, resolve } from 'node:path';
import { startStudio, defaultWorkspaceFolder } from './lib/server.mjs';
import { Workspace } from './lib/workspace.mjs';
import { configFolder } from './lib/secrets.mjs';
import { clearRunning, findRunning, HANDED_OFF_IDLE_MS, idleWatch, openAppWindow, whatNextAfterWindow, writeRunning } from './lib/launch.mjs';

const BOOLEAN = new Set(['open', 'app', 'nowindow']);
const [command = 'serve', ...rest] = process.argv.slice(2);
const opts = {};
for (let i = 0; i < rest.length; i += 1) { if (rest[i].startsWith('--')) { const k = rest[i].slice(2); if (BOOLEAN.has(k)) opts[k] = true; else { opts[k] = rest[i + 1]; i += 1; } } }
const folder = opts.folder ? resolve(opts.folder) : defaultWorkspaceFolder();
const say = (m = '') => console.log(m);

function openWithSystem(target) {
  const [cmd, args] = process.platform === 'win32' ? ['cmd', ['/c', 'start', '""', target]] : process.platform === 'darwin' ? ['open', [target]] : ['xdg-open', [target]];
  try { spawn(cmd, args, { detached: true, stdio: 'ignore', windowsHide: true }).on('error', () => {}).unref(); } catch { /* the address is printed anyway */ }
}

/** In a window with no terminal a problem would be invisible: it is written in a note and the note is opened. */
function showProblem(message) {
  try {
    const dir = configFolder();
    mkdirSync(dir, { recursive: true });
    const file = join(dir, 'Setup Studio problem.txt');
    writeFileSync(file, `The NextGenOS Setup Studio could not start.\r\n\r\n${message}\r\n\r\nIf it keeps happening, send this note to NextGenOS support (smartave99@gmail.com, +91 6123115368).\r\n`);
    openWithSystem(file);
  } catch { /* nothing more can be done */ }
}

try {
  if (command === 'where') { say(folder); process.exit(0); }
  if (command === 'check') {
    if (!Workspace.exists(folder)) { say(`There is no Studio in ${folder} yet.`); process.exit(1); }
    const ws = Workspace.open(folder);
    const audit = ws.verifyAudit();
    say(`Activity record: ${audit.ok ? `${audit.count} entries, none changed` : `CHANGED at entry ${audit.brokenAt} (${audit.why})`}`);
    let bad = audit.ok ? 0 : 1;
    for (const c of ws.list()) for (const n of ws.releaseNumbers(c.id)) { const v = ws.verifyRelease(c.id, n); say(`${c.id} release ${n}: ${v.ok ? 'matches what was approved' : 'CHANGED: ' + v.problems.join('; ')}`); if (!v.ok) bad += 1; }
    process.exit(bad ? 1 : 0);
  }
  if (command !== 'serve') { say('Usage: studio.mjs serve [--app] [--folder dir] [--port n] [--open] | check | where'); process.exit(2); }

  // A second double-click must not start a second Studio on the same files: it brings the one that is running to the front, in a new window.
  if (opts.app) {
    const running = await findRunning();
    if (running) {
      if (!opts.nowindow && !openAppWindow(running.url)) openWithSystem(running.url);
      process.exit(0);
    }
  }

  let watch = null;
  let appWindow = null;
  let stopping = false;
  let studio = null;
  const stop = async () => {
    if (stopping) return;
    stopping = true;
    clearRunning();
    watch?.stop();
    try { appWindow?.child.kill(); } catch { /* it is already closed */ }
    await studio.close();
    process.exit(0);
  };

  let lastBeat = 0;   // when a page last said it is there
  studio = await startStudio({ folder, port: Number(opts.port ?? 0), onBeat: () => { lastBeat = Date.now(); watch?.beat(); }, onQuit: stop });
  writeRunning({ url: studio.url, folder: studio.state.folder });
  say('NextGenOS Setup Studio is running, on this PC only.');
  say(`  Open this address in your web browser: ${studio.url}`);
  say(`  Its files are in: ${studio.state.folder}`);

  // With no window to watch (a tab in the PC's usual browser, or a terminal run), the Studio stops by itself after a long time with no page open.
  const watchForTheTab = (idleMs) => { watch ??= idleWatch({ idleMs, onIdle: stop }); };

  if (opts.app) {
    say('  Close its window to stop it.');
    if (opts.nowindow) watchForTheTab();
    else {
      appWindow = openAppWindow(studio.url);
      if (!appWindow) { openWithSystem(studio.url); watchForTheTab(); }
      else {
        const { started } = appWindow;
        appWindow.closed.then(async (ended) => {
          const next = await whatNextAfterWindow(ended, { pageSeen: () => lastBeat >= started, waitMs: Number(process.env.NEXTGENOS_WINDOW_WAIT_MS) || undefined });
          if (next === 'stop') return stop();
          appWindow = null;
          if (next === 'handed-off') { watchForTheTab(HANDED_OFF_IDLE_MS); return undefined; }   // the window is open in a browser we cannot watch: do not open it a second time
          // The browser could not start, or the page never appeared: show it in the PC's usual browser instead.
          openWithSystem(studio.url);
          watchForTheTab();
          return undefined;
        });
      }
    }
  } else {
    say('  Close this window (or press Ctrl+C) to stop it.');
    if (opts.open) openWithSystem(studio.url);
  }
  process.on('SIGINT', stop); process.on('SIGTERM', stop);
} catch (e) {
  console.error(`\n${e.message}\n`);
  if (opts.app) showProblem(e.message);
  process.exit(1);
}
