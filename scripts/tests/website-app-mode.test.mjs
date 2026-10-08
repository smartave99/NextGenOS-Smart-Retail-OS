// The website opened as a program of its own (start-website.js --app): the real start program with a stand-in website and stand-in browsers. One copy at a time, the window is the
// browser it is told to use, closing it stops the website, and a problem is written in a note (there is no terminal to show it).
import test from 'node:test';
import assert from 'node:assert/strict';
import { chmodSync, copyFileSync, existsSync, mkdirSync, mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { spawn } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { LAUNCHER } from '../make-website-package.mjs';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const skip = process.platform === 'win32' ? 'a Linux test' : false;
const wait = (ms) => new Promise((r) => setTimeout(r, ms));

/** A package folder with a stand-in website: it answers 503 like a website with no licence, on the port it is given. */
function pack(root, info = { customer: 'luzon-fresh-mart', name: 'Luzon Fresh Mart', version: '1.2.3' }) {
  const dir = join(root, 'pkg');
  mkdirSync(join(dir, 'app'), { recursive: true });
  writeFileSync(join(dir, 'start-website.js'), LAUNCHER);
  copyFileSync(join(repo, 'scripts', 'lib', 'app-window.mjs'), join(dir, 'app-window.mjs'));
  writeFileSync(join(dir, 'PACKAGE-INFO.json'), JSON.stringify(info));
  writeFileSync(join(dir, 'app', 'server.js'), "require('http').createServer((req, res) => { res.statusCode = 503; res.end('not available ' + req.url); }).listen(Number(process.env.PORT), process.env.HOSTNAME);\n");
  return dir;
}

function browser(root, body) {
  const bin = join(root, 'bin'); mkdirSync(bin, { recursive: true });
  const file = join(bin, 'stand-in-browser');
  writeFileSync(file, `#!/bin/sh\n${body}\n`);
  chmodSync(file, 0o755);
  const opener = join(bin, 'xdg-open');
  writeFileSync(opener, `#!/bin/sh\necho "$1" >> "${join(root, 'opened.txt')}"\n`);
  chmodSync(opener, 0o755);
  return { file, bin };
}

function start(dir, root, extra, env) {
  const child = spawn(process.execPath, [join(dir, 'start-website.js'), ...extra], {
    cwd: dir, env: { ...process.env, ...env, HOME: join(root, 'home'), XDG_CONFIG_HOME: join(root, 'cfg'), APPDATA: join(root, 'cfg') }, stdio: ['ignore', 'pipe', 'pipe'],
  });
  const run = { child, log: '', exited: new Promise((r) => child.once('exit', (code) => r(code))) };
  child.stdout.on('data', (d) => { run.log += d; }); child.stderr.on('data', (d) => { run.log += d; });
  return run;
}

const configOf = (root) => join(root, 'cfg', 'nextgenos-website', 'luzon-fresh-mart');

test('as a program: the window is the browser it is told to use, opened at the website; a second start makes no second website; closing the window stops it', { skip, timeout: 90_000 }, async () => {
  const root = mkdtempSync(join(tmpdir(), 'website-app-'));
  const dir = pack(root);
  const b = browser(root, `echo "$@" > "${join(root, 'asked.txt')}"\nsleep 7`);
  const env = { NEXTGENOS_APP_BROWSER: b.file, PATH: `${b.bin}:${dirname(process.execPath)}:/usr/bin:/bin` };
  const first = start(dir, root, ['--app', '8197'], env);
  try {
    for (let i = 0; i < 100 && !existsSync(join(root, 'asked.txt')); i += 1) await wait(150);
    const asked = readFileSync(join(root, 'asked.txt'), 'utf8');
    // With no licence yet, the window opens on the page where the key is typed (a window has no address bar to type it in).
    assert.ok(asked.includes('--app=http://127.0.0.1:8197/admin/licence'), asked);
    assert.match(asked, /--user-data-dir=.*nextgenos-website.*luzon-fresh-mart.*window/);
    assert.ok(existsSync(join(configOf(root), 'running.json')), 'it says that it is running');
    assert.equal(JSON.parse(readFileSync(join(configOf(root), 'running.json'), 'utf8')).pid, first.child.pid);
    const page = await fetch('http://127.0.0.1:8197/');
    assert.equal(page.status, 503, 'the stand-in website answers');

    // a second start: it brings up the window that is open and makes no second website
    writeFileSync(join(root, 'asked.txt'), '');
    const second = start(dir, root, ['--app', '8197'], env);
    assert.equal(await Promise.race([second.exited, wait(20_000).then(() => 'still running')]), 0, second.log);
    assert.doesNotMatch(second.log, /EADDRINUSE/);
    assert.ok(readFileSync(join(root, 'asked.txt'), 'utf8').includes('--app=http://127.0.0.1:8197'), 'it opened a window on the website that is running');
    assert.equal(JSON.parse(readFileSync(join(configOf(root), 'running.json'), 'utf8')).pid, first.child.pid, 'the first one is still the one that is noted');

    // the window is closed (the stand-in browser ends after seven seconds): the website stops
    assert.equal(await Promise.race([first.exited, wait(30_000).then(() => 'still running')]), 0, 'closing the window stops the website');
    assert.equal(existsSync(join(configOf(root), 'running.json')), false);
  } finally { first.child.kill(); rmSync(root, { recursive: true, force: true }); }
});

test('THE website (the same for every customer, no customer in its package note) keeps its note in a folder called "website", not "undefined"', { skip, timeout: 60_000 }, async () => {
  const root = mkdtempSync(join(tmpdir(), 'website-app-'));
  const dir = pack(root, { generic: true, version: '1.2.3' });
  const b = browser(root, `echo "$@" > "${join(root, 'asked.txt')}"\nsleep 5`);
  const env = { NEXTGENOS_APP_BROWSER: b.file, PATH: `${b.bin}:${dirname(process.execPath)}:/usr/bin:/bin` };
  const first = start(dir, root, ['--app', '8198'], env);
  try {
    for (let i = 0; i < 100 && !existsSync(join(root, 'asked.txt')); i += 1) await wait(150);
    const note = join(root, 'cfg', 'nextgenos-website', 'website', 'running.json');
    assert.ok(existsSync(note), 'the note that it is running is in the folder "website" (the Windows check of the release workflow looks there)');
    assert.equal(existsSync(join(root, 'cfg', 'nextgenos-website', 'undefined')), false);
    assert.equal(JSON.parse(readFileSync(note, 'utf8')).pid, first.child.pid);
    assert.equal(await Promise.race([first.exited, wait(30_000).then(() => 'still running')]), 0);
  } finally { first.child.kill(); rmSync(root, { recursive: true, force: true }); }
});

test('with a licence in place the window opens on the website itself', { skip, timeout: 60_000 }, async () => {
  const root = mkdtempSync(join(tmpdir(), 'website-app-'));
  const dir = pack(root);
  mkdirSync(join(dir, 'licence'), { recursive: true });
  writeFileSync(join(dir, 'licence', 'licence.ngos'), 'stand-in');
  const b = browser(root, `echo "$@" > "${join(root, 'asked.txt')}"\nsleep 6`);
  const run = start(dir, root, ['--app', '8198'], { NEXTGENOS_APP_BROWSER: b.file, PATH: `${b.bin}:${dirname(process.execPath)}:/usr/bin:/bin` });
  try {
    for (let i = 0; i < 100 && !existsSync(join(root, 'asked.txt')); i += 1) await wait(150);
    const asked = readFileSync(join(root, 'asked.txt'), 'utf8');
    assert.ok(asked.includes('--app=http://127.0.0.1:8198 ') || asked.trim().endsWith('--app=http://127.0.0.1:8198') || /--app=http:\/\/127\.0\.0\.1:8198(\s|$)/.test(asked), asked);
    assert.ok(!asked.includes('/admin/licence'));
  } finally { run.child.kill(); rmSync(root, { recursive: true, force: true }); }
});

test('port 3000 taken by another program: it picks a free port by itself, as a program of its own', { skip, timeout: 60_000 }, async () => {
  const net = await import('node:net');
  const blocker = net.createServer(); await new Promise((r) => blocker.listen(3000, '127.0.0.1', r).on('error', () => r()));
  if (!blocker.listening) return; // port 3000 is not ours to take on this machine: the case cannot be made here
  const root = mkdtempSync(join(tmpdir(), 'website-app-'));
  const dir = pack(root);
  const b = browser(root, `echo "$@" > "${join(root, 'asked.txt')}"\nsleep 4`);
  const run = start(dir, root, ['--app'], { NEXTGENOS_APP_BROWSER: b.file, PATH: `${b.bin}:${dirname(process.execPath)}:/usr/bin:/bin` });
  try {
    for (let i = 0; i < 100 && !existsSync(join(root, 'asked.txt')); i += 1) await wait(150);
    const m = /--app=http:\/\/127\.0\.0\.1:(\d+)/.exec(readFileSync(join(root, 'asked.txt'), 'utf8'));
    assert.ok(m && m[1] !== '3000', 'another port was used');
  } finally { run.child.kill(); blocker.close(); rmSync(root, { recursive: true, force: true }); }
});

test('no browser that can show a window: nothing is left running, and the problem is written in a note that opens', { skip, timeout: 60_000 }, async () => {
  const root = mkdtempSync(join(tmpdir(), 'website-app-'));
  const dir = pack(root);
  const b = browser(root, 'exit 0');
  // PATH holds only a stand-in opener: no Chromium-based browser anywhere
  const run = start(dir, root, ['--app', '8199'], { PATH: `${b.bin}:${dirname(process.execPath)}` });
  try {
    assert.equal(await Promise.race([run.exited, wait(40_000).then(() => 'still running')]), 1, run.log);
    const note = join(configOf(root), 'Website problem.txt');
    assert.ok(existsSync(note), 'a note was written');
    assert.match(readFileSync(note, 'utf8'), /no Microsoft Edge, Google Chrome or Chromium/);
    for (let i = 0; i < 30 && !existsSync(join(root, 'opened.txt')); i += 1) await wait(100);
    assert.ok(readFileSync(join(root, 'opened.txt'), 'utf8').includes('Website problem.txt'), 'the note was opened');
    assert.equal(existsSync(join(configOf(root), 'running.json')), false, 'no note that it is running is left');
    await assert.rejects(fetch('http://127.0.0.1:8199/'), 'the website is not left running');
  } finally { run.child.kill(); rmSync(root, { recursive: true, force: true }); }
});

test('a browser that ends at once: the website does not stay running unseen; a note says what to do', { skip, timeout: 60_000 }, async () => {
  const root = mkdtempSync(join(tmpdir(), 'website-app-'));
  const dir = pack(root);
  const b = browser(root, 'exit 0');
  const run = start(dir, root, ['--app', '8200'], { NEXTGENOS_APP_BROWSER: b.file, PATH: `${b.bin}:${dirname(process.execPath)}:/usr/bin:/bin` });
  try {
    assert.equal(await Promise.race([run.exited, wait(40_000).then(() => 'still running')]), 1, run.log);
    assert.match(readFileSync(join(configOf(root), 'Website problem.txt'), 'utf8'), /could not be opened/);
    assert.equal(existsSync(join(configOf(root), 'running.json')), false);
  } finally { run.child.kill(); rmSync(root, { recursive: true, force: true }); }
});

test('without --app it behaves as before: it runs in the terminal and says so', { skip, timeout: 60_000 }, async () => {
  const root = mkdtempSync(join(tmpdir(), 'website-app-'));
  const dir = pack(root);
  const run = start(dir, root, ['8201'], { PATH: `${dirname(process.execPath)}:/usr/bin:/bin` });
  try {
    for (let i = 0; i < 100 && !/Starting\./.test(run.log); i += 1) await wait(100);
    assert.match(run.log, /Leave this window open while the website is in use/);
    assert.ok(!existsSync(join(configOf(root), 'running.json')), 'no program note: this is the terminal way');
    assert.equal((await fetch('http://127.0.0.1:8201/')).status, 503);
  } finally { run.child.kill(); rmSync(root, { recursive: true, force: true }); }
});
