#!/usr/bin/env node
/**
 * NextGenOS Setup Studio: turn a customer's details into a ready-to-install Smart Retail POS (their look, words and settings). For NextGenOS staff only.
 *
 *   node tools/setup-studio/studio.mjs serve [--folder <where the Studio keeps its files>] [--port 5391] [--open]
 *   node tools/setup-studio/studio.mjs check                    check the Studio's files (the activity record, every approved release)
 *   node tools/setup-studio/studio.mjs where                    say where the Studio keeps its files
 *
 * Everything else is done in the web page it opens (on this PC only). See docs/SETUP-STUDIO.md.
 */
import { spawn } from 'node:child_process';
import { resolve } from 'node:path';
import { startStudio, defaultWorkspaceFolder } from './lib/server.mjs';
import { Workspace } from './lib/workspace.mjs';

const [command = 'serve', ...rest] = process.argv.slice(2);
const opts = {};
for (let i = 0; i < rest.length; i += 1) { if (rest[i].startsWith('--')) { const k = rest[i].slice(2); if (k === 'open') opts.open = true; else { opts[k] = rest[i + 1]; i += 1; } } }
const folder = opts.folder ? resolve(opts.folder) : defaultWorkspaceFolder();
const say = (m = '') => console.log(m);

function openBrowser(url) {
  const [cmd, args] = process.platform === 'win32' ? ['cmd', ['/c', 'start', '""', url]] : process.platform === 'darwin' ? ['open', [url]] : ['xdg-open', [url]];
  try { spawn(cmd, args, { detached: true, stdio: 'ignore', windowsHide: true }).on('error', () => {}).unref(); } catch { /* the address is printed anyway */ }
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
  if (command !== 'serve') { say('Usage: studio.mjs serve [--folder dir] [--port n] [--open] | check | where'); process.exit(2); }
  const studio = await startStudio({ folder, port: Number(opts.port ?? 0) });
  say('NextGenOS Setup Studio is running, on this PC only.');
  say(`  Open this address in your web browser: ${studio.url}`);
  say(`  Its files are in: ${studio.state.folder}`);
  say('  Close this window (or press Ctrl+C) to stop it.');
  if (opts.open) openBrowser(studio.url);
  const stop = () => studio.close().then(() => process.exit(0));
  process.on('SIGINT', stop); process.on('SIGTERM', stop);
} catch (e) {
  console.error(`\n${e.message}\n`);
  process.exit(1);
}
