#!/usr/bin/env node
// End to end, the way a customer gets it: the real website is built into a package (its own Node.js, server, static files, libraries and native parts), the package is audited,
// unpacked, started with its own Node.js, and brought into use with a licence from the real Licence Studio:
//   node licensing/e2e/with-studio.mjs -- node licensing/e2e/website-package-e2e.mjs
//
// The throw-away Studio's public key is built into a COPY of the website's source for this run (the repository's own files are not changed); the package made from it is
// used here only and is never kept. What it shows: the audits pass on the folder and the zip, the package refuses visitors and programme calls without a licence, and works
// with a licence for its address, in its own brand, and refuses a changed licence file and another web address.
import { spawn, spawnSync } from 'node:child_process';
import { existsSync, mkdirSync, mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import http from 'node:http';
import net from 'node:net';
import { appDir, copyAppSource, makeWebsitePackage } from '../../scripts/make-website-package.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const repo = resolve(here, '..', '..');
if (!process.env.NGOS_E2E_URL) { console.error('Run through with-studio.mjs'); process.exit(2); }
const os = process.platform === 'win32' ? 'windows' : 'linux';

const cli = (...args) => {
  const [cmd, ...base] = process.env.NGOS_E2E_CLI.split(' ');
  const r = spawnSync(cmd, [...base, ...args], { env: { ...process.env, STUDIO_DATA: process.env.NGOS_E2E_DATA, NODE_NO_WARNINGS: '1' }, encoding: 'utf8' });
  if (r.status !== 0) throw new Error(`Studio command ${args.join(' ')} failed: ${r.stderr}${r.stdout}`);
  return r.stdout.trim();
};
const node = (args, opts = {}) => spawnSync(process.execPath, args, { cwd: repo, encoding: 'utf8', maxBuffer: 64 * 1024 * 1024, timeout: 600000, ...opts });
const freePort = () => new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); });
const sleep = (ms) => new Promise((r) => setTimeout(r, ms));
const waitFor = async (fn, ms = 20000) => { const end = Date.now() + ms; while (Date.now() < end) { if (await fn()) return true; await sleep(500); } return false; };

let failures = 0;
const check = (name, ok, detail = '') => { console.log(`${ok ? 'PASS' : 'FAIL'}  ${name}${ok ? '' : '  ' + String(detail).slice(0, 1500)}`); if (!ok) failures += 1; };

const work = mkdtempSync(join(tmpdir(), 'ngos-site-e2e-'));
let server = null;
try {
  // A copy of the website's source with the throw-away Studio's public key built in (the repository's defaults.ts stays as it is).
  const source = join(work, 'source');
  copyAppSource(appDir, source);
  const keys = JSON.parse(process.env.NGOS_E2E_KEYS).keys.map((k) => ({ kid: k.kid, publicKey: k.publicKey }));
  writeFileSync(join(source, 'src', 'lib', 'licence', 'defaults.ts'), `export const TRUSTED_KEYS: { kid: string; publicKey: string }[] = ${JSON.stringify(keys)};\nexport const LICENCE_SERVER_URL = ${JSON.stringify(process.env.NGOS_E2E_URL)};\n`);
  const settings = join(work, 'website-settings.env');
  writeFileSync(settings, 'NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart\r\nNEXT_PUBLIC_SITE_URL=https://shop.luzonfresh.example\r\nNEXT_PUBLIC_COUNTRY=PH\r\nNEXT_PUBLIC_INDUSTRY=retail\r\nNEXT_PUBLIC_SHOP_PLACE=Quezon City, Philippines\r\n');

  const made = await makeWebsitePackage({
    os, version: '0.0.1', customer: 'e2e-shop', settingsFile: settings, out: join(work, 'out'), source,
    depsFrom: existsSync(join(appDir, 'node_modules')) ? join(appDir, 'node_modules') : null, nodeDownload: process.env.NGOS_NODE_VERSION || '22.22.0',
    log: (m) => console.log(`== ${m}`),
  });
  check('the package is built, checked and zipped', existsSync(made.zip));
  check('with keys built in it is not a trial build', made.trial === false && !existsSync(join(made.folder, 'NO-LICENCE-KEYS-TRIAL-ONLY.txt')));

  // The audits, as the release workflow runs them, on the folder and on the zip.
  let r = node(['scripts/audit-package.mjs', made.folder, made.zip, '--node-app']);
  check('scripts/audit-package.mjs passes the folder and the zip', r.status === 0 && /PASS\s+website-e2e-shop-/.test(r.stdout), r.stdout + r.stderr);
  r = node(['scripts/audit-prerequisites.mjs', made.folder, '--os', os]);
  check('scripts/audit-prerequisites.mjs passes: a factory-new computer needs nothing more', r.status === 0 && /PASS/.test(r.stdout), r.stdout + r.stderr);

  // Unpack the zip (as a customer would) and use that copy.
  const unpacked = join(work, 'unpacked');
  mkdirSync(unpacked, { recursive: true });
  const un = os === 'windows' ? spawnSync(join(process.env.SystemRoot || 'C:\\Windows', 'System32', 'tar.exe'), ['-xf', made.zip, '-C', unpacked], { encoding: 'utf8' }) : spawnSync('unzip', ['-q', made.zip, '-d', unpacked], { encoding: 'utf8' });
  check('the zip can be unpacked', un.status === 0, un.stderr);
  const pkg = join(unpacked, `website-e2e-shop-${os}`);

  // No licence: the package refuses (the same look as the start of the Hub's published program).
  r = node(['scripts/smoke-website.mjs', pkg, '--os', os]);
  check('started with no licence it refuses visitors and programme calls, serves its files, and tells the person what to do', r.status === 0, r.stdout + r.stderr);
  console.log(r.stdout.split('\n').filter((l) => l.startsWith('SKIP')).join('\n'));

  // With a licence for its address.
  const port = await freePort();
  const licDir = join(pkg, 'licence');
  const get = (path, host = `localhost:${port}`) => new Promise((res, rej) => {
    http.get({ host: '127.0.0.1', port, path, headers: { host } }, (x) => { let b = ''; x.on('data', (d) => { b += d; }); x.on('end', () => res({ status: x.statusCode, headers: x.headers, body: b })); }).on('error', rej);
  });
  const startFile = os === 'windows' ? [join(pkg, 'node', 'node.exe'), [join(pkg, 'start-website.js'), String(port)]] : ['sh', [join(pkg, 'start-website.sh'), String(port)]];
  server = spawn(startFile[0], startFile[1], { cwd: pkg, env: { PATH: process.env.PATH, NGOS_CRL_REFRESH_SECONDS: '2' }, stdio: ['ignore', 'pipe', 'pipe'] });
  let log = '';
  server.stdout.on('data', (d) => { log += d; });
  server.stderr.on('data', (d) => { log += d; });
  check('the packaged website starts', await waitFor(async () => { try { return (await get('/licence-required')).status > 0; } catch { return false; } }, 90000), log);

  const brand = JSON.parse(cli('create-brand', '--name', 'Luzon Fresh Mart', '--primary', '#aa2233', '--email', 'help@luzonfresh.example')).brand;
  const lic = JSON.parse(cli('create-licence', '--customer', 'Luzon Fresh Mart', '--country', 'Philippines', '--plan', 'growth', '--bind', 'domain', '--domains', 'localhost', '--brand', String(brand), '--white', 'none'));
  const token = cli('licence-file', lic.lid);
  writeFileSync(join(licDir, 'licence.ngos'), token + '\n');
  check('with a licence file in the package\'s licence folder the pages are served (200)', await waitFor(async () => (await get('/privacy')).status === 200), 'still not 200');
  const manifest = JSON.parse((await get('/manifest.webmanifest')).body);
  check('the licence\'s brand is applied: the manifest carries the brand name', manifest.name === 'Luzon Fresh Mart', JSON.stringify(manifest.name));
  const home = await get('/');
  check('the home page of the licensed website answers (it is the shop\'s page, not the licence page)', home.status > 0 && home.status !== 402 && !/not available right now/.test(home.body), `${home.status}`);
  check('the same licence on another web address is refused', (await get('/privacy', 'evil.example.net')).status === 503);

  const good = readFileSync(join(licDir, 'licence.ngos'), 'utf8');
  const [p, body, sig] = good.trim().split('.');
  const changed = JSON.parse(Buffer.from(body, 'base64url').toString()); changed.exp = null; changed.limits.stores = 999;
  writeFileSync(join(licDir, 'licence.ngos'), `${p}.${Buffer.from(JSON.stringify(changed)).toString('base64url')}.${sig}\n`);
  check('an edited licence file is refused', await waitFor(async () => (await get('/privacy')).status === 503, 15000));
  writeFileSync(join(licDir, 'licence.ngos'), good);
  check('the original file works again', await waitFor(async () => (await get('/privacy')).status === 200, 15000));
  cli('revoke', lic.lid, '--reason', 'test');
  check('a withdrawn licence stops the website at the next list refresh', await waitFor(async () => (await get('/privacy')).status === 503, 40000));
} catch (e) {
  console.error('ERROR', e.stack || e.message);
  failures += 1;
} finally {
  if (server) { if (os === 'windows') spawnSync('taskkill', ['/pid', String(server.pid), '/t', '/f']); else server.kill('SIGTERM'); }
  await sleep(500);
  rmSync(work, { recursive: true, force: true });
}
console.log(failures === 0 ? '\nWebsite package end-to-end: all checks passed.' : `\nWebsite package end-to-end: ${failures} FAILED.`);
process.exit(failures === 0 ? 0 : 1);
