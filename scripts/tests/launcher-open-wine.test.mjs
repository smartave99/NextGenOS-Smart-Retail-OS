// The launcher of a background program that is used in a browser window (scripts/launcher/AppLauncher.nsi with OPEN_URL: the Business Hub's zip and the dashboard), RUN under
// Wine: it starts the program only when nothing answers yet, waits until it answers, opens the window, and starts the program once when it is opened twice at once.
// The shipped launcher is a 32-bit Windows program. Wine here runs it only when 32-bit Wine is installed (apt-get install wine32:i386, on a machine set up for i386); the same
// script is therefore also built for 64-bit Windows (makensis -XTarget amd64-unicode), which every Wine can run, and the tests run for each build that can be run. Which builds
// ran is printed ("LAUNCHERS RUN: ..."), and the gate says it.
// The stand-in "program" is Wine's own cmd.exe writing a line into a file; the "program answering" is a server on THIS side, started when that line appears (Wine shares the
// network of this machine); the stand-in "browser" is a tiny program that writes the command line it was given. This proves the logic. It does not prove that no black window
// flashes: that needs a real Windows PC with a person looking (CLAUDE.md, section 10; docs/OPEN-WORK.md).
// Needs: makensis, wine64 and Xvfb (apt-get install nsis wine64 xvfb). Without them every test here is skipped, and the gate says "not verified" (scripts/checks/hub.mjs).
import test, { after } from 'node:test';
import assert from 'node:assert/strict';
import net from 'node:net';
import { spawn, spawnSync } from 'node:child_process';
import { copyFileSync, existsSync, mkdirSync, mkdtempSync, readFileSync, rmSync, statSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { LAUNCHER_SCRIPT, launcherDefines } from '../lib/build-launcher.mjs';

const have = (cmd) => spawnSync('sh', ['-c', `command -v ${cmd}`]).status === 0;
const WINE64 = ['/usr/lib/wine/wine64', '/usr/lib/wine64/wine64', '/usr/bin/wine64'].find((p) => existsSync(p)) ?? null;
const WINE32 = ['/usr/lib/wine/wine', '/usr/bin/wine'].find((p) => existsSync(p)) ?? null;   // the loader that also runs 32-bit programs, when 32-bit Wine is installed
const WINESERVER = ['/usr/lib/wine/wineserver', '/usr/lib/wine64/wineserver64', '/usr/bin/wineserver'].find((p) => existsSync(p)) ?? null;
const skip = !have('makensis') ? 'makensis (NSIS) is not installed here' : !WINE64 || !WINESERVER ? 'wine64 is not installed here' : !have('Xvfb') ? 'Xvfb is not installed here' : false;

const sleep = (ms) => new Promise((r) => setTimeout(r, ms));
async function until(what, check, ms = 60_000) {
  const end = Date.now() + ms;
  while (Date.now() < end) { const v = check(); if (v) return v; await sleep(150); }
  throw new Error(`Gave up waiting for ${what}.`);
}
const freePort = () => new Promise((resolve) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => resolve(p)); }); });
const listen = (port) => new Promise((resolve, reject) => { const s = net.createServer((c) => c.end()); s.once('error', reject); s.listen(port, '127.0.0.1', () => resolve(s)); });

let root = null;
let prefix = null;
let xvfb = null;
let display = null;
let cmdExe = null;
const wineEnv = (extra = {}) => ({ ...process.env, WINEPREFIX: prefix, WINEARCH: 'win64', WINEDEBUG: '-all', WINEDLLOVERRIDES: 'mscoree,mshtml=', DISPLAY: display, ...extra });

/** One folder as a person would have it: the launcher and the program beside it, and the stand-in browser elsewhere. `variant.target` is makensis' way to build for 64-bit. */
function folder(variant, { port, wait = 60 }) {
  const dir = mkdtempSync(join(root, 't-'));
  const app = join(dir, 'app');
  const web = join(dir, 'browser');
  mkdirSync(app); mkdirSync(web);
  copyFileSync(cmdExe, join(app, 'hub.exe'));
  // A tiny 64-bit program that appends the command line it was given to browser.txt, next to itself: the stand-in for Edge.
  const nsi = join(web, 'browser.nsi');
  writeFileSync(nsi, ['Unicode true', 'Target amd64-unicode', `OutFile "${join(web, 'msedge.exe')}"`, 'SilentInstall silent', 'RequestExecutionLevel user', 'Section',
    '  FileOpen $0 "$EXEDIR\\browser.txt" a', '  FileSeek $0 0 END', '  FileWrite $0 "$CMDLINE$\\r$\\n"', '  FileClose $0', 'SectionEnd', ''].join('\n'));
  const stand = spawnSync('makensis', ['-V1', nsi], { encoding: 'utf8' });
  assert.equal(stand.status, 0, stand.stdout + stand.stderr);
  const launcher = join(app, 'Start Hub.exe');
  // The same defines the shipped launcher gets.
  const defines = launcherDefines({ outFile: launcher, name: 'Test Hub', program: 'hub.exe', args: '/c echo x>> started.txt', open: { url: `http://127.0.0.1:${port}`, waitSeconds: wait, profile: 'test-window', helper: 'Start Hub (with a window, for problems)' } });
  const made = spawnSync('makensis', ['-V2', ...variant.target, ...defines, LAUNCHER_SCRIPT], { encoding: 'utf8' });
  assert.equal(made.status, 0, made.stdout + made.stderr);
  const lines = (file) => (existsSync(file) ? readFileSync(file, 'latin1').split(/\r?\n/).filter(Boolean) : []);
  return {
    launcher, dir,
    started: () => lines(join(app, 'started.txt')),
    windows: () => lines(join(web, 'browser.txt')),
    windowFile: join(web, 'browser.txt'),
    run: () => {
      const child = spawn(variant.wine, [launcher], { env: wineEnv({ NEXTGENOS_APP_BROWSER: join(web, 'msedge.exe') }), stdio: 'ignore', detached: true });
      const done = new Promise((resolve) => child.once('exit', resolve));
      return { child, done, kill: () => { try { process.kill(-child.pid, 'SIGKILL'); } catch { /* it is gone */ } } };
    },
  };
}

// ---- the set-up: a display and a Windows folder of Wine's own, and which builds of the launcher this Wine can run -----------------------------------------------------------------

const variants = [];
if (!skip) {
  root = mkdtempSync(join(tmpdir(), 'launcher-wine-'));
  prefix = join(root, 'prefix');
  // A display of its own for Wine, chosen by the X server itself.
  xvfb = spawn('Xvfb', ['-displayfd', '3', '-screen', '0', '800x600x24', '-nolisten', 'tcp'], { stdio: ['ignore', 'ignore', 'ignore', 'pipe'] });
  display = await new Promise((resolve, reject) => {
    xvfb.stdio[3].once('data', (d) => resolve(`:${String(d).trim()}`));
    xvfb.once('error', reject);
    xvfb.once('exit', () => reject(new Error('Xvfb stopped at once')));
  });
  const first = spawnSync(WINE32 ?? WINE64, ['cmd', '/c', 'exit'], { env: wineEnv(), timeout: 180_000 });
  assert.ok(!first.error, 'Wine could not start');
  cmdExe = join(prefix, 'drive_c', 'windows', 'system32', 'cmd.exe');
  assert.ok(existsSync(cmdExe), 'Wine has no cmd.exe');
  variants.push({ name: '64-bit build', target: ['-XTarget amd64-unicode'], wine: WINE64 });
  // Can this Wine run the shipped 32-bit launcher? Try it once, with the stand-in program.
  if (WINE32 && existsSync(join(prefix, 'drive_c', 'windows', 'syswow64'))) {
    const probe = folder({ name: '32-bit probe', target: [], wine: WINE32 }, { port: await freePort(), wait: 2 });
    const run = probe.run();
    try { await until('the 32-bit probe', () => probe.started().length > 0, 25_000); variants.push({ name: '32-bit build (the one that ships)', target: [], wine: WINE32 }); } catch { /* this Wine cannot run 32-bit programs */ } finally { run.kill(); }
  }
  console.log(`LAUNCHERS RUN: ${variants.map((v) => v.name).join(' and ')}${variants.length === 1 ? ' (this Wine has no 32-bit support: the shipped 32-bit build was not run)' : ''}`);
}

after(() => {
  if (skip) return;
  spawnSync(WINESERVER, ['-k'], { env: wineEnv() });
  xvfb?.kill();
  rmSync(root, { recursive: true, force: true });
});

for (const variant of variants) {
  const t = (name, options, fn) => test(`${name} [${variant.name}]`, options, fn);

  t('nothing answers yet: it starts the program, waits until it answers, and only then opens the window', {}, async () => {
    const port = await freePort();
    const f = folder(variant, { port });
    const run = f.run();
    let server;
    try {
      await until('the program to be started', () => f.started().length > 0);
      assert.equal(f.windows().length, 0, 'no window while the program does not answer');
      await sleep(2500);
      assert.equal(f.windows().length, 0, 'still no window: the program has not answered yet');
      server = await listen(port);
      const answeredAt = Date.now();
      await until('the window', () => f.windows().length > 0);
      assert.ok(statSync(f.windowFile).mtimeMs >= answeredAt - 1500, 'the window was opened after the program answered');
      await run.done;
      assert.equal(f.started().length, 1, 'the program was started once');
      assert.equal(f.windows().length, 1, 'one window');
      const line = f.windows()[0];
      assert.ok(line.includes(`--app=http://127.0.0.1:${port}`), `the window shows only the program, no address bar: ${line}`);
      assert.ok(line.includes('--user-data-dir='), 'with a profile of its own');
      assert.ok(/test-window/.test(line), 'the profile folder named for this program');
      assert.ok(line.includes('--no-first-run'), line);
    } finally { run.kill(); server?.close(); }
  });

  t('the program already answers: it is not started again, the window opens at once', {}, async () => {
    const port = await freePort();
    const server = await listen(port);
    const f = folder(variant, { port });
    const run = f.run();
    try {
      await until('the window', () => f.windows().length > 0);
      await run.done;
      assert.equal(f.started().length, 0, 'the program that is already running is left alone');
      assert.equal(f.windows().length, 1);
      assert.ok(f.windows()[0].includes(`--app=http://127.0.0.1:${port}`));
    } finally { run.kill(); server.close(); }
  });

  t('started twice at once: the program is started once and one window opens', {}, async () => {
    const port = await freePort();
    const f = folder(variant, { port });
    const a = f.run();
    const b = f.run();
    let server;
    try {
      await until('the program to be started', () => f.started().length > 0);
      await sleep(2500);
      server = await listen(port);
      await until('the window', () => f.windows().length > 0);
      await Promise.all([a.done, b.done]);
      assert.equal(f.started().length, 1, 'one copy of the program');
      assert.equal(f.windows().length, 1, 'one window, not two');
    } finally { a.kill(); b.kill(); server?.close(); }
  });

  t('the program never answers: no window opens (the person is told, in a message, after the waiting time)', {}, async () => {
    const port = await freePort();
    const f = folder(variant, { port, wait: 3 });
    const run = f.run();
    try {
      await until('the program to be started', () => f.started().length > 0);
      // After the waiting time the launcher shows a message and stops there: it never opens a window onto a program that is not there.
      await sleep(9000);
      assert.equal(f.windows().length, 0);
      assert.equal(f.started().length, 1);
    } finally { run.kill(); }
  });

  t('opened again later, while the program runs, it opens another window and does not start a second program', {}, async () => {
    const port = await freePort();
    const server = await listen(port);
    const f = folder(variant, { port });
    try {
      for (let i = 1; i <= 2; i += 1) {
        const run = f.run();
        await run.done;
        await until(`window ${i}`, () => f.windows().length >= i);
      }
      assert.equal(f.started().length, 0);
      assert.equal(f.windows().length, 2);
    } finally { server.close(); }
  });
}

test('at least the 64-bit build was run (without Wine every test above is absent and this one is skipped)', { skip }, () => {
  assert.ok(variants.length >= 1);
});
