#!/usr/bin/env node
// End to end: the real storefront (production build, Node middleware) against the real Licence Studio.
// Run through with-studio.mjs, which provides NGOS_E2E_URL / _CLI / _KEYS:
//   node licensing/e2e/with-studio.mjs -- node licensing/e2e/storefront-e2e.mjs
import { spawn, spawnSync } from 'node:child_process';
import { readFileSync, writeFileSync, mkdtempSync, rmSync, existsSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import http from 'node:http';
import net from 'node:net';

const here = dirname(fileURLToPath(import.meta.url));
const app = resolve(here, '..', '..', 'apps', 'storefront-web-mobile');
const defaultsFile = join(app, 'src', 'lib', 'licence', 'defaults.ts');
const original = readFileSync(defaultsFile, 'utf8');
const url = process.env.NGOS_E2E_URL;
if (!url) { console.error('Run through with-studio.mjs'); process.exit(2); }

const cli = (...args) => {
  const [cmd, ...base] = process.env.NGOS_E2E_CLI.split(' ');
  const r = spawnSync(cmd, [...base, ...args], { env: { ...process.env, STUDIO_DATA: process.env.NGOS_E2E_DATA, NODE_NO_WARNINGS: '1' }, encoding: 'utf8' });
  if (r.status !== 0) throw new Error(`CLI ${args.join(' ')} failed: ${r.stderr}${r.stdout}`);
  return r.stdout.trim();
};
const port = await new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); });
const licDir = mkdtempSync(join(tmpdir(), 'ngos-site-'));
let server;
let failures = 0;
const check = (name, ok, detail = '') => { console.log(`${ok ? 'PASS' : 'FAIL'}  ${name}${ok ? '' : '  ' + detail}`); if (!ok) failures += 1; };

/** GET with a chosen Host header (undici's fetch cannot set it). */
const get = (path, host = `localhost:${port}`) => new Promise((res, rej) => {
  http.get({ host: '127.0.0.1', port, path, headers: { host } }, (r) => { let b = ''; r.on('data', (d) => { b += d; }); r.on('end', () => res({ status: r.statusCode, headers: r.headers, body: b })); }).on('error', rej);
});
const sleep = (ms) => new Promise((r) => setTimeout(r, ms));
const waitFor = async (fn, ms = 20000) => { const end = Date.now() + ms; while (Date.now() < end) { if (await fn()) return true; await sleep(500); } return false; };

try {
  // Build the storefront with the throw-away Studio's public key built in (restored in the finally block).
  const keys = JSON.parse(process.env.NGOS_E2E_KEYS).keys.map((k) => ({ kid: k.kid, publicKey: k.publicKey }));
  writeFileSync(defaultsFile, `export const TRUSTED_KEYS: { kid: string; publicKey: string }[] = ${JSON.stringify(keys)};\nexport const LICENCE_SERVER_URL = ${JSON.stringify(url)};\n`);
  const env = { ...process.env, NEXT_PUBLIC_SITE_URL: `http://localhost:${port}`, NEXT_TELEMETRY_DISABLED: '1' };
  const build = spawnSync('npx', ['next', 'build'], { cwd: app, env, encoding: 'utf8', timeout: 600000 });
  if (build.status !== 0) { console.error(build.stdout.slice(-3000), build.stderr.slice(-2000)); throw new Error('The storefront did not build.'); }
  console.log('Built the storefront.');

  server = spawn('npx', ['next', 'start', '-p', String(port), '-H', '127.0.0.1'], { cwd: app, env: { ...env, LICENCE_DIR: licDir, NGOS_CRL_REFRESH_SECONDS: '2', NODE_ENV: 'production' }, stdio: ['ignore', 'pipe', 'pipe'] });
  let log = '';
  server.stdout.on('data', (d) => { log += d; });
  server.stderr.on('data', (d) => { log += d; });
  if (!(await waitFor(async () => { try { return (await get('/licence-required')).status > 0; } catch { return false; } }, 60000))) throw new Error('The storefront did not start.\n' + log);

  // ---- no licence ----
  let r = await get('/privacy');
  check('no licence: visitors get a plain "not available" page (503)', r.status === 503 && r.body.includes('not available right now'), `${r.status}`);
  check('no licence: the page gives no reason or key', !/NGOS|licen[sc]e (has|is)/i.test(r.body.replace(/Site owner/g, '')) );
  r = await get('/api/assistant/health');
  check('no licence: API calls get 402 licence_required', r.status === 402 && r.body.includes('licence_required'), `${r.status} ${r.body}`);
  r = await get('/admin/licence');
  check('no licence: the activation page stays reachable', r.status === 200, `${r.status}`);
  check('security headers are on every response', ['content-security-policy', 'strict-transport-security', 'x-content-type-options', 'x-frame-options', 'referrer-policy', 'permissions-policy'].every((h) => r.headers[h]), JSON.stringify(Object.keys(r.headers)));
  check('CSP forbids objects, base tags and foreign framing', /object-src 'none'/.test(r.headers['content-security-policy']) && /base-uri 'self'/.test(r.headers['content-security-policy']) && /frame-ancestors 'self'/.test(r.headers['content-security-policy']));

  // ---- a website licence for localhost ----
  const brand = JSON.parse(cli('create-brand', '--name', 'Luzon Fresh Mart', '--primary', '#aa2233', '--email', 'help@luzonfresh.example')).brand;
  const lic = JSON.parse(cli('create-licence', '--customer', 'Luzon Fresh Mart', '--country', 'Philippines', '--plan', 'growth', '--bind', 'domain', '--domains', 'localhost', '--brand', String(brand), '--white', 'none'));
  const token = cli('licence-file', lic.lid);
  writeFileSync(join(licDir, 'licence.ngos'), token + '\n');
  check('licence file placed', existsSync(join(licDir, 'licence.ngos')));
  check('with a valid licence the static pages are served (200)', await waitFor(async () => (await get('/privacy')).status === 200), 'still not 200');
  r = await get('/manifest.webmanifest');
  const manifest = JSON.parse(r.body);
  check('the licence brand is applied: manifest carries the brand name (level none = locked)', manifest.name === 'Luzon Fresh Mart', JSON.stringify(manifest.name));

  // ---- wrong address ----
  r = await get('/privacy', 'evil.example.net');
  check('the same licence on another web address is refused', r.status === 503, `${r.status}`);
  r = await get('/privacy', 'localhost.evil.test');
  check('a look-alike address is refused', r.status === 503, `${r.status}`);

  // ---- tampered file ----
  const good = readFileSync(join(licDir, 'licence.ngos'), 'utf8');
  const [p, body, sig] = good.trim().split('.');
  const changed = JSON.parse(Buffer.from(body, 'base64url').toString()); changed.exp = null; changed.limits.stores = 999;
  writeFileSync(join(licDir, 'licence.ngos'), `${p}.${Buffer.from(JSON.stringify(changed)).toString('base64url')}.${sig}\n`);
  check('an edited licence file is refused', await waitFor(async () => (await get('/privacy')).status === 503, 15000));
  writeFileSync(join(licDir, 'licence.ngos'), good);
  check('the original file works again', await waitFor(async () => (await get('/privacy')).status === 200, 15000));

  // ---- withdrawn: the site learns it from the revocation list ----
  cli('revoke', lic.lid, '--reason', 'test');
  check('a withdrawn licence stops the site at the next list refresh', await waitFor(async () => (await get('/privacy')).status === 503, 30000));

  // ---- ended ----
  const ended = JSON.parse(cli('create-licence', '--customer', 'Old Shop', '--plan', 'growth', '--term', 'trial30', '--start', '2020-01-01', '--bind', 'domain', '--domains', 'localhost'));
  writeFileSync(join(licDir, 'licence.ngos'), cli('licence-file', ended.lid) + '\n');
  check('an ended licence is refused', await waitFor(async () => (await get('/privacy')).status === 503, 15000));

  // ---- a licence without the online shop ----
  const nostore = JSON.parse(cli('create-licence', '--customer', 'Billing Only', '--plan', 'starter', '--bind', 'domain', '--domains', 'localhost'));
  writeFileSync(join(licDir, 'licence.ngos'), cli('licence-file', nostore.lid) + '\n');
  check('a licence that does not include the website is refused', await waitFor(async () => (await get('/privacy')).status === 503, 15000));
} catch (e) {
  console.error('ERROR', e.message);
  failures += 1;
} finally {
  if (server) server.kill('SIGTERM');
  writeFileSync(defaultsFile, original);
  rmSync(licDir, { recursive: true, force: true });
}
console.log(failures === 0 ? '\nStorefront end-to-end: all checks passed.' : `\nStorefront end-to-end: ${failures} FAILED.`);
process.exit(failures === 0 ? 0 : 1);
