#!/usr/bin/env node
/**
 * Starts a built website package once, with the Node.js inside it and the way its start script starts it, and looks at what it answers, the way a person opening it for the first time would:
 *   node scripts/smoke-website.mjs <package folder> --os windows|linux
 * With no licence the website must answer "not available" to a visitor (503), 402 to every programme call, keep only the activation page open, serve its own static files,
 * set the safety headers, run in production mode, listen on this computer only, and say in plain words when its port is already used.
 * Exit code 0 only when all of that holds. The folder is used as it is: the website writes a cache into it, so run this on an unpacked copy, never on a package that will be shipped.
 */
import { spawn, spawnSync } from 'node:child_process';
import { existsSync, readdirSync } from 'node:fs';
import { networkInterfaces } from 'node:os';
import { join, resolve } from 'node:path';
import net from 'node:net';
import http from 'node:http';

const args = process.argv.slice(2);
const target = args.find((a, i) => !a.startsWith('--') && args[i - 1] !== '--os');
const os = args[args.indexOf('--os') + 1];
if (!target || !['windows', 'linux'].includes(os || '')) { console.error('Usage: node scripts/smoke-website.mjs <package folder> --os windows|linux'); process.exit(2); }
const folder = resolve(target);
for (const f of [os === 'windows' ? 'node/node.exe' : 'start-website.sh', 'start-website.js', 'app/server.js']) {
  if (!existsSync(join(folder, ...f.split('/')))) { console.error(`${f} is not in ${folder}: is this the package folder?`); process.exit(2); }
}
if ((os === 'windows') !== (process.platform === 'win32')) { console.error(`A ${os} package can only be started on ${os === 'windows' ? 'Windows' : 'Linux'}.`); process.exit(2); }

const freePort = () => new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); });
const port = await freePort();

/** The start command a person would use: the start script on Linux (it checks the machine first), Node.js with the launcher on Windows (the .bat only adds a pause). */
const startCommand = (p, extra = []) => (os === 'windows'
  ? [join(folder, 'node', 'node.exe'), [join(folder, 'start-website.js'), String(p), ...extra]]
  : ['sh', [join(folder, 'start-website.sh'), String(p), ...extra]]);
// A clean environment: no licence, no database, nothing from this computer's settings.
const cleanEnv = Object.fromEntries(Object.entries(process.env).filter(([k]) => /^(PATH|HOME|USERPROFILE|TEMP|TMP|TMPDIR|SYSTEMROOT|WINDIR|COMSPEC|PATHEXT|LANG|LC_ALL)$/i.test(k)));
const [cmd, cmdArgs] = startCommand(port);
const child = spawn(cmd, cmdArgs, { cwd: folder, env: cleanEnv, stdio: ['ignore', 'pipe', 'pipe'] });
let log = '';
child.stdout.on('data', (d) => { log += d; });
child.stderr.on('data', (d) => { log += d; });
let exited = null;
child.on('exit', (c) => { exited = c; });

let failures = 0;
const check = (what, ok, detail = '') => { console.log(`${ok ? 'PASS' : 'FAIL'}  ${what}${ok ? '' : '  ' + String(detail).slice(0, 1200)}`); if (!ok) failures += 1; };
const sleep = (ms) => new Promise((r) => setTimeout(r, ms));
const get = (path, host = '127.0.0.1') => new Promise((res, rej) => {
  const req = http.get({ host, port, path, headers: { host: `localhost:${port}` }, timeout: 20000 }, (r) => { let b = ''; r.on('data', (d) => { b += d; }); r.on('end', () => res({ status: r.statusCode, headers: r.headers, body: b })); });
  req.on('error', rej);
  req.on('timeout', () => req.destroy(new Error('no answer in 20 seconds')));
});
const stop = async (c) => {
  if (c.exitCode !== null) return;
  if (os === 'windows') spawnSync('taskkill', ['/pid', String(c.pid), '/t', '/f']); else c.kill('SIGTERM');
  for (let i = 0; i < 20 && c.exitCode === null; i += 1) await sleep(250);
  if (c.exitCode === null) c.kill('SIGKILL');
};

try {
  let up = false;
  for (let i = 0; i < 180 && exited === null; i += 1) {
    try { await get('/licence-required'); up = true; break; } catch { await sleep(500); }
  }
  check('the website starts, with its own Node.js, and answers on this computer', up, exited !== null ? `it stopped with code ${exited}\n${log.slice(-1500)}` : `no answer in 90 seconds\n${log.slice(-1500)}`);
  if (up) {
    check('it tells the person, in words, where to open it', new RegExp(`http://127\\.0\\.0\\.1:${port}`).test(log) && /close this window/i.test(log), log.slice(-600));
    check('it tells the person that a licence is still needed', /no licence yet/i.test(log) && /\/admin\/licence/.test(log), log.slice(-600));

    let r = await get('/privacy');
    check('with no licence a visitor gets a plain "not available" page (503), not the shop', r.status === 503 && /not available right now/.test(r.body), `${r.status}`);
    check('that page gives no reason and no key', !/NGOS|licen[sc]e (has|is)/i.test(r.body.replace(/Site owner/g, '')));
    r = await get('/');
    check('the home page is closed too (503)', r.status === 503, `${r.status}`);
    r = await get('/api/assistant/health');
    check('with no licence a programme call gets 402 licence_required', r.status === 402 && r.body.includes('licence_required'), `${r.status} ${r.body.slice(0, 200)}`);
    r = await get('/admin/licence');
    check('only the activation page stays open (200)', r.status === 200, `${r.status}`);
    const h = r.headers;
    check('the safety headers are on the answer', ['content-security-policy', 'strict-transport-security', 'x-content-type-options', 'x-frame-options', 'referrer-policy', 'permissions-policy'].every((n) => h[n]), JSON.stringify(Object.keys(h)));
    const csp = h['content-security-policy'] || '';
    check('it forbids objects, base tags and foreign framing', /object-src 'none'/.test(csp) && /base-uri 'self'/.test(csp) && /frame-ancestors 'self'/.test(csp));
    check('it runs in production mode (no development shortcuts, no eval)', /upgrade-insecure-requests/.test(csp) && !/unsafe-eval/.test(csp), csp);

    const chunks = join(folder, 'app', '.next', 'static', 'chunks');
    const chunk = existsSync(chunks) ? readdirSync(chunks).find((f) => f.endsWith('.js')) : null;
    r = chunk ? await get(`/_next/static/chunks/${chunk}`) : { status: 0, headers: {} };
    check('the website serves its own static files', r.status === 200 && /javascript/.test(r.headers['content-type'] || ''), `${chunk} ${r.status} ${r.headers['content-type']}`);
    r = await get('/favicon.ico');
    check('and its public files (the icon)', r.status === 200, `${r.status}`);

    check('it listens on this computer only', !/0\.0\.0\.0|\[::\]/.test(log));
    const other = Object.values(networkInterfaces()).flat().find((i) => i && !i.internal && i.family === 'IPv4');
    if (other) {
      const reached = await get('/licence-required', other.address).then(() => true, () => false);
      check(`and a connection to this computer's other address (${other.address}) is refused`, !reached);
    } else console.log('SKIP  no other network address on this computer to try (the log check above still ran)');

    // A second copy on the same port must say so in plain words and stop.
    const [c2, a2] = startCommand(port);
    const second = spawn(c2, a2, { cwd: folder, env: cleanEnv, stdio: ['ignore', 'pipe', 'pipe'] });
    let log2 = '';
    second.stdout.on('data', (d) => { log2 += d; });
    second.stderr.on('data', (d) => { log2 += d; });
    for (let i = 0; i < 40 && second.exitCode === null; i += 1) await sleep(250);
    check('a second start on the same port stops and says in plain words that the port is used', second.exitCode === 1 && /already used by another program/.test(log2), `${second.exitCode} ${log2.slice(-400)}`);
    await stop(second);
    const [c3, a3] = startCommand(port, ['--nonsense']);
    const third = spawnSync(c3, a3, { cwd: folder, env: cleanEnv, encoding: 'utf8', timeout: 30000 });
    check('an unknown word on the start command is refused in plain words', third.status === 1 && /I do not understand/.test(third.stderr || ''), `${third.status} ${third.stderr}`);
  }
} finally {
  await stop(child);
}
console.log(failures ? `\n${failures} check(s) failed` : '\nThe website package starts with its own Node.js and refuses to work without a licence.');
process.exit(failures ? 1 : 0);
