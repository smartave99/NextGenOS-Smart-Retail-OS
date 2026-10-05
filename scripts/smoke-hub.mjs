#!/usr/bin/env node
/**
 * Starts the published Business Hub program once and looks at what it answers, the way a person opening it for the first time would:
 *   node scripts/smoke-hub.mjs <path to NextGenOS.Hub.exe | NextGenOS.Hub>  [--dll]      (--dll: the argument is a .dll, run with dotnet)
 * With no licence on this PC the Hub must answer 402 with the page that asks for a key, set the safety headers, and open nothing else.
 * Exit code 0 only when all of that holds. The release workflow runs this on a real Windows runner against the program in the setup.
 */
import { spawn } from 'node:child_process';
import { mkdtempSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import net from 'node:net';

const args = process.argv.slice(2);
const target = args.find((a) => !a.startsWith('--'));
if (!target) { console.error('Usage: node scripts/smoke-hub.mjs <NextGenOS.Hub.exe> [--dll]'); process.exit(2); }

const port = await new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); });
const data = mkdtempSync(join(tmpdir(), 'hub-smoke-'));
const url = `http://127.0.0.1:${port}`;
const common = [`--Hub:DataFolder=${data}`, `--Kestrel:Endpoints:Http:Url=${url}`, '--Logging:LogLevel:Default=Warning'];
const child = args.includes('--dll') ? spawn('dotnet', [target, ...common], { stdio: ['ignore', 'pipe', 'pipe'] }) : spawn(target, common, { stdio: ['ignore', 'pipe', 'pipe'] });
let log = '';
child.stdout.on('data', (d) => { log += d; });
child.stderr.on('data', (d) => { log += d; });
let exited = null;
child.on('exit', (c) => { exited = c; });

let failures = 0;
const check = (what, ok, detail = '') => { console.log(`${ok ? 'PASS' : 'FAIL'}  ${what}${ok ? '' : '  ' + detail}`); if (!ok) failures += 1; };
const sleep = (ms) => new Promise((r) => setTimeout(r, ms));

try {
  let up = false;
  for (let i = 0; i < 120 && exited === null; i += 1) {
    try { await fetch(url + '/'); up = true; break; } catch { await sleep(500); }
  }
  check('the program starts and answers on this PC', up, exited !== null ? `it stopped with code ${exited}\n${log.slice(-1500)}` : 'no answer in 60 seconds\n' + log.slice(-1500));
  if (up) {
    const home = await fetch(url + '/', { headers: { accept: 'text/html' }, redirect: 'manual' });
    const text = await home.text();
    check('with no licence it answers 402 (payment required), not a page of the shop', home.status === 402, String(home.status));
    check('the page asks for a licence key, in plain words', /needs a licence/i.test(text) && /key/i.test(text));
    check('the page has a place to type the key', /name="key"/.test(text));
    check('the answer is not cached and not sniffed', home.headers.get('cache-control') === 'no-store' && home.headers.get('x-content-type-options') === 'nosniff');
    for (const path of ['/setup', '/login', '/sell', '/export/sales.csv', '/_framework/blazor.web.js', '/api/anything']) {
      const r = await fetch(url + path, { redirect: 'manual' });
      check(`${path} is closed too (402)`, r.status === 402, String(r.status));
    }
    check('it listens on this PC only', !/0\.0\.0\.0|\[::\]/.test(log));
  }
} finally {
  child.kill();
  await sleep(500);
  try { rmSync(data, { recursive: true, force: true }); } catch { /* the program may still hold a file for a moment */ }
}
console.log(failures ? `\n${failures} check(s) failed` : '\nThe published Business Hub starts and refuses to work without a licence.');
process.exit(failures ? 1 : 0);
