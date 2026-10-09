// The Brand Studio opened as a program of its own (brand.mjs serve --app): the real program with stand-in browsers. One copy at a time, closing the window stops it, the page's
// Quit stops it, and a browser that ends at once hands the page to the usual browser.
import test from 'node:test';
import assert from 'node:assert/strict';
import { chmodSync, existsSync, mkdirSync, mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { spawn } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { WIZARD_HTML, WIZARD_JS } from '../lib/wizard.mjs';
import { startServer } from '../lib/server.mjs';

const brand = join(dirname(fileURLToPath(import.meta.url)), '..', 'brand.mjs');
const skip = process.platform === 'win32' ? 'a Linux test' : false;
const wait = (ms) => new Promise((r) => setTimeout(r, ms));
const keyOf = (url) => new URL(url).searchParams.get('k');
const originOf = (url) => new URL(url).origin;

function start(args, env) {
  const child = spawn(process.execPath, [brand, ...args], { env: { ...process.env, ...env }, stdio: ['ignore', 'pipe', 'pipe'] });
  const run = { child, log: '', exited: new Promise((r) => child.once('exit', (code) => r(code))) };
  child.stdout.on('data', (d) => { run.log += d; }); child.stderr.on('data', (d) => { run.log += d; });
  run.url = new Promise((res, rej) => {
    let look = null; let timer = null;
    const done = () => { clearInterval(look); clearTimeout(timer); };
    timer = setTimeout(() => { done(); rej(new Error('no address printed:\n' + run.log)); }, 20_000);
    look = setInterval(() => { const m = /(http:\/\/127\.0\.0\.1:\d+\/\?k=[\w-]+)/.exec(run.log); if (m) { done(); res(m[1]); } }, 50);
    child.once('exit', () => { done(); rej(new Error('the program ended without an address:\n' + run.log)); });
  });
  run.url.catch(() => {});
  return run;
}

test('the wizard has a Quit button, says when the Brand Studio has stopped, and tells it that it is still open', () => {
  assert.match(WIZARD_HTML, /id="quit"/);
  assert.match(WIZARD_JS, /\/api\/quit/);
  assert.match(WIZARD_JS, /\/api\/alive/);
  assert.match(WIZARD_JS, /The Brand Studio has stopped/);
});

test('the page can say it is there and can quit, only with the secret', { skip }, async () => {
  const root = mkdtempSync(join(tmpdir(), 'brand-quit-'));
  let beats = 0; let quits = 0;
  const s = await startServer({ root, port: 0, onBeat: () => { beats += 1; }, onQuit: () => { quits += 1; } });
  const plain = await startServer({ root, port: 0 });
  try {
    const call = (u, method, path, key = keyOf(u.url)) => fetch(originOf(u.url) + path, { method, headers: { 'x-brand-studio': key, 'content-type': 'application/json' }, body: method === 'POST' ? '{}' : undefined });
    assert.equal((await call(s, 'GET', '/api/alive')).status, 200);
    assert.equal(beats, 1);
    assert.equal((await call(s, 'GET', '/api/alive', 'wrong')).status, 401);
    assert.equal((await call(s, 'POST', '/api/quit', 'wrong')).status, 401);
    await wait(400);
    assert.equal(quits, 0);
    assert.equal((await call(s, 'POST', '/api/quit')).status, 200);
    await wait(500);
    assert.equal(quits, 1);
    assert.equal((await call(plain, 'POST', '/api/quit')).status, 409, 'a Brand Studio with nothing to stop it says so plainly');
  } finally { await s.close(); await plain.close(); rmSync(root, { recursive: true, force: true }); }
});

test('as a program: one Brand Studio, a second opening makes no second, and the page quits it', { skip, timeout: 90_000 }, async () => {
  const home = mkdtempSync(join(tmpdir(), 'brand-app-'));
  const env = { BRAND_STUDIO_HOME: join(home, 'cfg'), BRAND_STUDIO_ROOT: join(home, 'root') };
  mkdirSync(join(home, 'root'), { recursive: true });
  const first = start(['serve', '--app', '--nowindow'], env);
  try {
    const url = await first.url;
    assert.match(first.log, /Close its window to stop it/);
    assert.equal(JSON.parse(readFileSync(join(home, 'cfg', 'running.json'), 'utf8')).pid, first.child.pid);
    const second = start(['serve', '--app', '--nowindow'], env);
    assert.equal(await Promise.race([second.exited, wait(15_000).then(() => 'still running')]), 0, second.log);
    assert.doesNotMatch(second.log, /is open on this PC only/, 'it started no second Brand Studio');
    assert.equal(JSON.parse(readFileSync(join(home, 'cfg', 'running.json'), 'utf8')).pid, first.child.pid);
    const quit = await fetch(originOf(url) + '/api/quit', { method: 'POST', headers: { 'x-brand-studio': keyOf(url), 'content-type': 'application/json' }, body: '{}' });
    assert.equal(quit.status, 200);
    assert.equal(await Promise.race([first.exited, wait(10_000).then(() => 'still running')]), 0);
    assert.equal(existsSync(join(home, 'cfg', 'running.json')), false);
  } finally { first.child.kill(); rmSync(home, { recursive: true, force: true }); }
});

test('with a window: it is the browser it is told to use, and closing it stops the Brand Studio', { skip, timeout: 60_000 }, async () => {
  const home = mkdtempSync(join(tmpdir(), 'brand-window-'));
  const bin = join(home, 'bin'); mkdirSync(bin);
  const standIn = join(bin, 'stand-in-browser');
  writeFileSync(standIn, `#!/bin/sh\necho "$@" > "${join(home, 'asked.txt')}"\nsleep 6\n`); chmodSync(standIn, 0o755);
  mkdirSync(join(home, 'root'), { recursive: true });
  const env = { BRAND_STUDIO_HOME: join(home, 'cfg'), BRAND_STUDIO_ROOT: join(home, 'root'), NEXTGENOS_APP_BROWSER: standIn, PATH: `${bin}:${dirname(process.execPath)}:/usr/bin:/bin` };
  const run = start(['serve', '--app'], env);
  try {
    const url = await run.url;
    await wait(500);
    const asked = readFileSync(join(home, 'asked.txt'), 'utf8');
    assert.ok(asked.includes(`--app=${url}`), asked);
    assert.match(asked, /--user-data-dir=.*window/);
    assert.equal(await Promise.race([run.exited, wait(20_000).then(() => 'still running')]), 0, 'closing the window stops the Brand Studio');
  } finally { run.child.kill(); rmSync(home, { recursive: true, force: true }); }
});

test('a browser that ends at once and whose page never appears: the usual web browser is NOT used; a note says what to do, and the Brand Studio stops', { skip, timeout: 60_000 }, async () => {
  const home = mkdtempSync(join(tmpdir(), 'brand-handoff-'));
  const bin = join(home, 'bin'); mkdirSync(bin);
  const standIn = join(bin, 'stand-in-browser'); writeFileSync(standIn, '#!/bin/sh\nexit 0\n'); chmodSync(standIn, 0o755);
  const opener = join(bin, 'xdg-open'); writeFileSync(opener, `#!/bin/sh\necho "$1" > "${join(home, 'opened.txt')}"\n`); chmodSync(opener, 0o755);
  mkdirSync(join(home, 'root'), { recursive: true });
  const env = { BRAND_STUDIO_HOME: join(home, 'cfg'), BRAND_STUDIO_ROOT: join(home, 'root'), NEXTGENOS_APP_BROWSER: standIn, NEXTGENOS_WINDOW_WAIT_MS: '1500', PATH: `${bin}:${dirname(process.execPath)}:/usr/bin:/bin` };
  const run = start(['serve', '--app'], env);
  try {
    const url = await run.url;
    for (let i = 0; i < 80 && !existsSync(join(home, 'opened.txt')); i += 1) await wait(100);
    const opened = readFileSync(join(home, 'opened.txt'), 'utf8').trim();
    assert.notEqual(opened, url, 'the page was NOT handed to the usual web browser');
    assert.match(opened, /Brand Studio problem\.txt$/, 'what was opened is the note');
    assert.match(readFileSync(opened, 'utf8'), /Microsoft Edge, Google Chrome or Chromium/, 'the note says what is missing');
    for (let i = 0; i < 50 && run.child.exitCode === null; i += 1) await wait(100);
    assert.notEqual(run.child.exitCode, null, 'the Brand Studio stopped: it has no window to show');
  } finally { run.child.kill(); rmSync(home, { recursive: true, force: true }); }
});

test('a browser that ends at once but whose page appears (it handed the page to a copy of itself that was already running): the usual browser is NOT opened as well', { skip, timeout: 60_000 }, async () => {
  const home = mkdtempSync(join(tmpdir(), 'brand-handedoff-'));
  const bin = join(home, 'bin'); mkdirSync(bin);
  const standIn = join(bin, 'stand-in-browser');
  // ends at once; a second later "the page" says it is there
  writeFileSync(standIn, `#!/bin/sh\nurl="\${1#--app=}"\nkey="\${url#*k=}"\norigin="$(echo "$url" | sed 's#/?k=.*##')"\n( sleep 1; "${process.execPath}" -e "fetch(process.argv[1] + '/api/alive', { headers: { 'X-Brand-Studio': process.argv[2] } }).catch(() => {})" "$origin" "$key" ) >/dev/null 2>&1 &\nexit 0\n`); chmodSync(standIn, 0o755);
  const opener = join(bin, 'xdg-open'); writeFileSync(opener, `#!/bin/sh\necho "$1" > "${join(home, 'opened.txt')}"\n`); chmodSync(opener, 0o755);
  mkdirSync(join(home, 'root'), { recursive: true });
  const env = { BRAND_STUDIO_HOME: join(home, 'cfg'), BRAND_STUDIO_ROOT: join(home, 'root'), NEXTGENOS_APP_BROWSER: standIn, NEXTGENOS_WINDOW_WAIT_MS: '3000', PATH: `${bin}:${dirname(process.execPath)}:/usr/bin:/bin` };
  const run = start(['serve', '--app'], env);
  try {
    await run.url;
    await wait(7000);
    assert.equal(existsSync(join(home, 'opened.txt')), false, 'the page was not opened a second time in the usual browser');
    assert.equal(run.child.exitCode, null, 'still running');
  } finally { run.child.kill(); rmSync(home, { recursive: true, force: true }); }
});
