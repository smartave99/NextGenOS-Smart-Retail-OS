// Opening the Studio as a program of its own: which browser shows it, one Studio at a time, stopping when its window is closed or when nobody is using it, and quitting it from the page.
import test from 'node:test';
import assert from 'node:assert/strict';
import { chmodSync, existsSync, mkdtempSync, readFileSync, rmSync, writeFileSync, mkdirSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname } from 'node:path';
import { spawn } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { createHash } from 'node:crypto';
import { startStudio } from '../lib/server.mjs';
import { appWindowArgs, clearRunning, findAppBrowser, findRunning, idleWatch, runningFile, waitUntil, whatNextAfterWindow, windowWasClosedByPerson, writeRunning } from '../lib/launch.mjs';

const studio = join(dirname(fileURLToPath(import.meta.url)), '..', 'studio.mjs');
const temp = (name) => mkdtempSync(join(tmpdir(), `${name}-`));
const wait = (ms) => new Promise((r) => setTimeout(r, ms));
const keyOf = (url) => new URL(url).searchParams.get('k');
const originOf = (url) => new URL(url).origin;

test('the browser that shows the Studio: Edge first on Windows, then the others, none when there is none, or the one named by hand', () => {
  const have = (...paths) => (p) => paths.includes(p);
  const env = { 'ProgramFiles(x86)': 'C:\\Program Files (x86)', ProgramFiles: 'C:\\Program Files', LOCALAPPDATA: 'C:\\Users\\a\\AppData\\Local' };
  const edge = 'C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe';
  const chrome = 'C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe';
  assert.equal(findAppBrowser({ platform: 'win32', env, exists: have(edge, chrome) }), edge);
  assert.equal(findAppBrowser({ platform: 'win32', env, exists: have(chrome) }), chrome);
  assert.equal(findAppBrowser({ platform: 'win32', env, exists: have() }), null);

  assert.equal(findAppBrowser({ platform: 'linux', env: { PATH: '/usr/local/bin:/usr/bin' }, exists: have('/usr/bin/chromium', '/usr/bin/google-chrome') }), '/usr/bin/google-chrome', 'Chrome is tried before Chromium');
  assert.equal(findAppBrowser({ platform: 'linux', env: { PATH: '/usr/bin' }, exists: have() }), null);
  assert.equal(findAppBrowser({ platform: 'darwin', env: {}, exists: have('/Applications/Google Chrome.app/Contents/MacOS/Google Chrome') }), '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome');

  assert.equal(findAppBrowser({ platform: 'linux', env: { PATH: '/usr/bin', SETUP_STUDIO_BROWSER: '/opt/mine/browser' }, exists: have('/opt/mine/browser', '/usr/bin/chromium') }), '/opt/mine/browser');
  assert.equal(findAppBrowser({ platform: 'linux', env: { PATH: '/usr/bin', SETUP_STUDIO_BROWSER: '/opt/gone/browser' }, exists: have('/usr/bin/chromium') }), '/usr/bin/chromium', 'a path that is not there is ignored');
});

test('the window is only the Studio\'s page, with a profile of its own', () => {
  const args = appWindowArgs('http://127.0.0.1:5391/?k=abc', '/home/a/.config/nextgenos-setup-studio/window');
  assert.ok(args.includes('--app=http://127.0.0.1:5391/?k=abc'));
  assert.ok(args.includes('--user-data-dir=/home/a/.config/nextgenos-setup-studio/window'));
  assert.ok(args.includes('--no-first-run'));
  assert.ok(args.includes('--disable-background-mode'), 'a closed window must not leave the browser running in the background (the next start would hand its page to it and end at once)');
});

test('a window that ends at once, or could not start, is not "the person closed it"; one that was open a while is', () => {
  assert.equal(windowWasClosedByPerson({ code: 0, ms: 90_000 }), true);
  assert.equal(windowWasClosedByPerson({ code: 0, ms: 800 }), false);
  assert.equal(windowWasClosedByPerson({ error: new Error('no such file'), ms: 5 }), false);
});

test('a browser that ends at once is only "handed off" when the page really appears; otherwise the page is shown in the usual browser', async () => {
  let t = 0;
  const timing = { now: () => t, sleep: async (ms) => { t += ms; }, waitMs: 1000, pollMs: 100 };
  assert.equal(await waitUntil(() => true, timing), true);
  assert.equal(await waitUntil(() => false, timing), false, 'the time runs out');
  let calls = 0;
  assert.equal(await waitUntil(() => { calls += 1; return calls > 3; }, timing), true, 'seen after a little while');

  const closedByPerson = { code: 0, ms: 90_000 };
  const quick = { code: 0, ms: 300 };
  assert.equal(await whatNextAfterWindow(closedByPerson, { pageSeen: () => false, ...timing }), 'stop');
  assert.equal(await whatNextAfterWindow(quick, { pageSeen: () => true, ...timing }), 'handed-off', 'the page is there: do not open it a second time');
  assert.equal(await whatNextAfterWindow(quick, { pageSeen: () => false, ...timing }), 'show-elsewhere', 'no page appeared');
  assert.equal(await whatNextAfterWindow({ error: new Error('no such file'), ms: 4 }, { pageSeen: () => true, ...timing }), 'show-elsewhere', 'it could not even start');
});

test('a Studio that is running is found; one that is gone, or a note that is wrong, is not (and the note is removed)', async () => {
  const home = temp('running');
  const env = { SETUP_STUDIO_HOME: join(home, 'cfg') };
  const running = await startStudio({ folder: join(home, 'ws'), port: 0 });
  try {
    assert.equal(await findRunning(env), null, 'no note, none running');
    writeRunning({ url: running.url, folder: join(home, 'ws') }, env);
    const found = await findRunning(env);
    assert.equal(found.url, running.url);
    assert.equal(found.pid, process.pid);

    // a note about a process that is not there
    writeFileSync(runningFile(env), JSON.stringify({ pid: 2 ** 22 + 12345, url: running.url, folder: 'x' }));
    assert.equal(await findRunning(env), null);
    assert.equal(existsSync(runningFile(env)), false, 'the stale note is removed');

    // a note that is not even a note
    writeFileSync(runningFile(env), 'not json');
    assert.equal(await findRunning(env), null);

    // a note whose address is not this PC's
    writeRunning({ url: 'http://example.com:80/?k=abc', folder: 'x' }, env);
    assert.equal(await findRunning(env), null);

    // a note about this process, but nothing answers there
    await running.close();
    writeRunning({ url: running.url, folder: 'x' }, env);
    assert.equal(await findRunning(env), null);

    // clearing only removes the note of the process that wrote it
    writeRunning({ url: running.url, pid: 4242, folder: 'x' }, env);
    clearRunning(env, 1);
    assert.equal(existsSync(runningFile(env)), true);
    clearRunning(env, 4242);
    assert.equal(existsSync(runningFile(env)), false);
  } finally { await running.close().catch(() => {}); rmSync(home, { recursive: true, force: true }); }
});

test('nobody is using the Studio: it stops after a long time with no sign of a page, and a sleeping PC does not count', () => {
  let t = 0;
  let tick = null;
  let stopped = 0;
  let idle = 0;
  const every = (fn) => { tick = fn; return { unref() {} }; };
  const watch = idleWatch({ idleMs: 600, tickMs: 100, now: () => t, onIdle: () => { idle += 1; }, every, stopEvery: () => { stopped += 1; } });
  for (let i = 0; i < 5; i += 1) { t += 100; tick(); }
  assert.equal(idle, 0, 'not yet');
  watch.beat();
  for (let i = 0; i < 5; i += 1) { t += 100; tick(); }
  assert.equal(idle, 0, 'a sign of a page starts the count again');
  t += 10_000; tick();
  assert.equal(idle, 0, 'ten seconds in one step is the PC having slept, not nobody using it');
  for (let i = 0; i < 6; i += 1) { t += 100; tick(); }
  assert.equal(idle, 0);
  t += 100; tick();
  assert.equal(idle, 1, 'now it has been idle for longer than the time');
  assert.equal(stopped, 1);
});

test('the page can say it is there and can quit the Studio, only with the secret, and not while the AI is working', async () => {
  const home = temp('quit');
  let beats = 0;
  let quit = 0;
  const s = await startStudio({ folder: join(home, 'ws'), port: 0, onBeat: () => { beats += 1; }, onQuit: () => { quit += 1; } });
  const plain = await startStudio({ folder: join(home, 'ws2'), port: 0 });
  try {
    const call = (u, method, path, key = keyOf(u.url ?? u)) => fetch(originOf(u.url ?? u) + path, { method, headers: { 'x-studio-key': key, ...(method === 'POST' ? { 'content-type': 'application/json' } : {}) }, body: method === 'POST' ? '{}' : undefined });
    assert.equal((await call(s, 'GET', '/api/alive')).status, 200);
    assert.equal(beats, 1);
    assert.equal((await call(s, 'GET', '/api/alive', 'wrong')).status, 401, 'without the secret nothing is accepted');
    assert.equal(beats, 1);
    assert.equal((await call(s, 'POST', '/api/quit', 'wrong')).status, 401);
    await wait(400);
    assert.equal(quit, 0);

    s.state.aiRunning.add('c1');
    const busy = await call(s, 'POST', '/api/quit');
    assert.equal(busy.status, 409);
    assert.match((await busy.json()).error, /still working/);
    s.state.aiRunning.clear();

    assert.equal((await call(s, 'POST', '/api/quit')).status, 200);
    await wait(500);
    assert.equal(quit, 1, 'the Studio was told to stop');

    const none = await call(plain, 'POST', '/api/quit');
    assert.equal(none.status, 409, 'a Studio with nothing to stop it says so plainly');
  } finally { await s.close(); await plain.close(); rmSync(home, { recursive: true, force: true }); }
});

// ---- the real program, started as a person's double-click does ---------------------------------------------------------------------------

function start(args, env, { keep = false } = {}) {
  const child = spawn(process.execPath, [studio, ...args], { env: { ...process.env, ...env }, stdio: ['ignore', 'pipe', 'pipe'] });
  const run = { child, log: '', exited: new Promise((r) => child.once('exit', (code) => r(code))) };
  child.stdout.on('data', (d) => { run.log += d; }); child.stderr.on('data', (d) => { run.log += d; });
  // The address the Studio prints; the waiting stops when it is found, when the program ends, or after twenty seconds.
  run.url = new Promise((res, rej) => {
    let look = null;
    let timer = null;
    const done = () => { clearInterval(look); clearTimeout(timer); };
    timer = setTimeout(() => { done(); rej(new Error('no address printed:\n' + run.log)); }, 20_000);
    look = setInterval(() => { const m = /(http:\/\/127\.0\.0\.1:\d+\/\?k=[\w-]+)/.exec(run.log); if (m) { done(); res(m[1]); } }, 50);
    child.once('exit', () => { done(); rej(new Error('the program ended without an address:\n' + run.log)); });
  });
  if (!keep) run.url.catch(() => {});
  return run;
}

test('opened as a program: it shows no terminal, makes one Studio, a second opening makes no second, and the page quits it', { skip: process.platform === 'win32' }, async () => {
  const home = temp('app');
  const env = { SETUP_STUDIO_HOME: join(home, 'cfg'), SETUP_STUDIO_WORKSPACE: join(home, 'ws') };
  const first = start(['serve', '--app', '--nowindow'], env);
  try {
    const url = await first.url;
    assert.match(first.log, /Close its window to stop it/);
    assert.ok(existsSync(join(home, 'cfg', 'running.json')), 'it says that it is running');
    const note = JSON.parse(readFileSync(join(home, 'cfg', 'running.json'), 'utf8'));
    assert.equal(note.pid, first.child.pid);

    // a second double-click: no second Studio, and it ends at once
    const second = start(['serve', '--app', '--nowindow'], env);
    const code = await Promise.race([second.exited, wait(15_000).then(() => 'still running')]);
    assert.equal(code, 0, second.log);
    assert.doesNotMatch(second.log, /is running, on this PC only/, 'it started no second Studio');
    assert.equal(JSON.parse(readFileSync(join(home, 'cfg', 'running.json'), 'utf8')).pid, first.child.pid, 'the first one is still the one that is noted');

    // the page's Quit button
    const quit = await fetch(originOf(url) + '/api/quit', { method: 'POST', headers: { 'x-studio-key': keyOf(url), 'content-type': 'application/json' }, body: '{}' });
    assert.equal(quit.status, 200);
    assert.equal(await Promise.race([first.exited, wait(10_000).then(() => 'still running')]), 0);
    assert.equal(existsSync(join(home, 'cfg', 'running.json')), false, 'its note is gone when it is');
  } finally { first.child.kill(); rmSync(home, { recursive: true, force: true }); }
});

test('opened as a program with a window: the window is the browser it is told to use, and closing that window stops the Studio', { skip: process.platform === 'win32', timeout: 60_000 }, async () => {
  const home = temp('window');
  const bin = join(home, 'bin'); mkdirSync(bin);
  const standIn = join(bin, 'stand-in-browser');
  // a browser that keeps its "window" open for six seconds, and says what it was asked to open
  writeFileSync(standIn, `#!/bin/sh\necho "$@" > "${join(home, 'asked.txt')}"\nsleep 6\n`);
  chmodSync(standIn, 0o755);
  const env = { SETUP_STUDIO_HOME: join(home, 'cfg'), SETUP_STUDIO_WORKSPACE: join(home, 'ws'), SETUP_STUDIO_BROWSER: standIn, PATH: `${bin}:${dirname(process.execPath)}:/usr/bin:/bin` };
  const run = start(['serve', '--app'], env);
  try {
    const url = await run.url;
    await wait(500);
    const asked = readFileSync(join(home, 'asked.txt'), 'utf8');
    assert.ok(asked.includes(`--app=${url}`), asked);
    assert.match(asked, /--user-data-dir=.*window/);
    assert.equal(await Promise.race([run.exited, wait(20_000).then(() => 'still running')]), 0, 'closing the window stops the Studio');
    assert.equal(existsSync(join(home, 'cfg', 'running.json')), false);
  } finally { run.child.kill(); rmSync(home, { recursive: true, force: true }); }
});

test('a browser that ends at once but whose page appears (it handed the page to a copy of itself that was already running): the usual browser is NOT opened as well', { skip: process.platform === 'win32', timeout: 60_000 }, async () => {
  const home = temp('handedoff');
  const bin = join(home, 'bin'); mkdirSync(bin);
  const standIn = join(bin, 'stand-in-browser');
  // ends at once, like Edge or Chrome handing the page to a copy that is already running; a second later "the page" says it is there
  writeFileSync(standIn, `#!/bin/sh\nurl="\${1#--app=}"\nkey="\${url#*k=}"\norigin="$(echo "$url" | sed 's#/?k=.*##')"\n( sleep 1; "${process.execPath}" -e "fetch(process.argv[1] + '/api/alive', { headers: { 'x-studio-key': process.argv[2] } }).catch(() => {})" "$origin" "$key" ) >/dev/null 2>&1 &\nexit 0\n`); chmodSync(standIn, 0o755);
  const opener = join(bin, 'xdg-open');
  writeFileSync(opener, `#!/bin/sh\necho "$1" > "${join(home, 'opened.txt')}"\n`); chmodSync(opener, 0o755);
  const env = { SETUP_STUDIO_HOME: join(home, 'cfg'), SETUP_STUDIO_WORKSPACE: join(home, 'ws'), SETUP_STUDIO_BROWSER: standIn, NEXTGENOS_WINDOW_WAIT_MS: '3000', PATH: `${bin}:${dirname(process.execPath)}:/usr/bin:/bin` };
  const run = start(['serve', '--app'], env);
  try {
    await run.url;
    await wait(7000);
    assert.equal(existsSync(join(home, 'opened.txt')), false, 'the page was not opened a second time in the usual browser');
    assert.equal(run.child.exitCode, null, 'the Studio is still running');
  } finally { run.child.kill(); rmSync(home, { recursive: true, force: true }); }
});

test('a browser that ends at once and whose page never appears: the Studio opens it in the usual browser and keeps running', { skip: process.platform === 'win32', timeout: 60_000 }, async () => {
  const home = temp('handoff');
  const bin = join(home, 'bin'); mkdirSync(bin);
  const standIn = join(bin, 'stand-in-browser');
  writeFileSync(standIn, '#!/bin/sh\nexit 0\n'); chmodSync(standIn, 0o755);
  const opener = join(bin, 'xdg-open');
  writeFileSync(opener, `#!/bin/sh\necho "$1" > "${join(home, 'opened.txt')}"\n`); chmodSync(opener, 0o755);
  const env = { SETUP_STUDIO_HOME: join(home, 'cfg'), SETUP_STUDIO_WORKSPACE: join(home, 'ws'), SETUP_STUDIO_BROWSER: standIn, NEXTGENOS_WINDOW_WAIT_MS: '1500', PATH: `${bin}:${dirname(process.execPath)}:/usr/bin:/bin` };
  const run = start(['serve', '--app'], env);
  try {
    const url = await run.url;
    for (let i = 0; i < 80 && !existsSync(join(home, 'opened.txt')); i += 1) await wait(100);
    assert.equal(readFileSync(join(home, 'opened.txt'), 'utf8').trim(), url, 'the page was handed to the usual browser');
    assert.equal(run.child.exitCode, null, 'the Studio is still running');
  } finally { run.child.kill(); rmSync(home, { recursive: true, force: true }); }
});

test('the window code is one file: every copy that travels with a program is the same as the one source', () => {
  const here = dirname(fileURLToPath(import.meta.url));
  const repo = join(here, '..', '..', '..');
  const sha = (p) => createHash('sha256').update(readFileSync(p)).digest('hex');
  const source = sha(join(repo, 'scripts', 'lib', 'app-window.mjs'));
  for (const copy of [join(repo, 'tools', 'setup-studio', 'lib', 'app-window.mjs'), join(repo, 'tools', 'brand-studio', 'lib', 'app-window.mjs')]) {
    if (existsSync(copy)) assert.equal(sha(copy), source, `${copy} differs from scripts/lib/app-window.mjs: copy the source over it`);
  }
});
