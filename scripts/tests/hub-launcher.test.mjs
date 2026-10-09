// The Business Hub's Linux menu entry: it opens the Hub as a window of its own (a Chromium-based browser in app mode), or full screen for a touch till; never in the usual browser tab. The program itself is a background service: the window is only a window.
import test from 'node:test';
import assert from 'node:assert/strict';
import http from 'node:http';
import { chmodSync, existsSync, mkdirSync, mkdtempSync, readFileSync, rmSync, symlinkSync, writeFileSync } from 'node:fs';
import { spawn } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const script = join(repo, 'apps', 'business-hub', 'installer', 'linux', 'smart-retail-pos');
const skip = process.platform === 'win32' ? 'a Linux script' : false;

/** A folder of stand-ins: only these programs exist for the script (a real browser on this PC must not take part). */
function world(browsers) {
  const dir = mkdtempSync(join(tmpdir(), 'hub-launcher-'));
  const bin = join(dir, 'bin'); mkdirSync(bin);
  for (const tool of ['seq', 'sleep', 'mkdir']) for (const base of ['/usr/bin', '/bin']) if (existsSync(join(base, tool))) { symlinkSync(join(base, tool), join(bin, tool)); break; }
  for (const name of browsers) { writeFileSync(join(bin, name), `#!/bin/sh\necho "${name} $*" > "${dir}/asked.txt"\n`); chmodSync(join(bin, name), 0o755); }
  return { dir, bin };
}

async function run(browsers, args = []) {
  const w = world(browsers);
  const server = http.createServer((req, res) => res.end('ok'));
  await new Promise((r) => server.listen(0, '127.0.0.1', r));
  const url = `http://127.0.0.1:${server.address().port}`;
  const child = spawn('/bin/bash', [script, ...args], { env: { PATH: w.bin, XDG_DATA_HOME: join(w.dir, 'data'), HOME: join(w.dir, 'home'), SMART_RETAIL_POS_URL: url }, stdio: 'ignore' });
  const code = await new Promise((r) => child.once('exit', r));
  server.close();
  const asked = existsSync(join(w.dir, 'asked.txt')) ? readFileSync(join(w.dir, 'asked.txt'), 'utf8').trim() : '';
  rmSync(w.dir, { recursive: true, force: true });
  return { code, asked, url, data: join(w.dir, 'data') };
}

test('it opens the Hub as a window of its own, with a profile of its own', { skip }, async () => {
  const r = await run(['chromium', 'xdg-open']);
  assert.equal(r.code, 0);
  assert.ok(r.asked.startsWith('chromium '), r.asked);
  assert.ok(r.asked.includes(`--app=${r.url}`), r.asked);
  assert.ok(r.asked.includes(`--user-data-dir=${r.data}/nextgenos/smart-retail-pos-window`), r.asked);
  assert.ok(!r.asked.includes('--kiosk'));
});

test('Chrome and Edge do the same; Chromium is tried first', { skip }, async () => {
  assert.ok((await run(['google-chrome'])).asked.startsWith('google-chrome --app='));
  assert.ok((await run(['microsoft-edge'])).asked.startsWith('microsoft-edge --app='));
});

test('with no browser that can open a window of its own, the usual web browser is NOT used: it says so and stops', { skip }, async () => {
  const r = await run(['xdg-open']);
  assert.equal(r.code, 1);
  assert.equal(r.asked, '', 'the address was not handed to the usual web browser');
});

test('a touch till still opens full screen', { skip }, async () => {
  const r = await run(['chromium', 'xdg-open'], ['--fullscreen']);
  assert.ok(r.asked.includes('--kiosk'), r.asked);
  assert.ok(r.asked.includes(r.url));
  assert.ok(!r.asked.includes('--app='));
});

test('with nothing to open it with it says where to go, and fails', { skip }, async () => {
  const r = await run([]);
  assert.equal(r.code, 1);
});
