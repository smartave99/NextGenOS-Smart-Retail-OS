#!/usr/bin/env node
// End to end, the way a customer gets it: the real Business Hub (not the test host) is published, protected (names hidden), audited
// (no source, no test program, no key), started, and brought into use with a licence from the real Licence Studio:
//   node licensing/e2e/with-studio.mjs -- node licensing/e2e/hub-e2e.mjs
//
// The throw-away Studio's public key is built into the licence library for this run only (the same "sync-clients" step an owner does
// before a release); the two files it writes are put back afterwards, whatever happens.
import { spawnSync } from 'node:child_process';
import { readFileSync, writeFileSync, existsSync, mkdtempSync, rmSync, readdirSync } from 'node:fs';
import { tmpdir, homedir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const repo = resolve(here, '..', '..');
const hubWeb = join(repo, 'apps', 'business-hub', 'src', 'NextGenOS.Hub.Web');
const defaults = [
  join(repo, 'licensing', 'clients', 'dotnet', 'NextGenOS.Licensing', 'LicenceDefaults.cs'),
  join(repo, 'apps', 'storefront-web-mobile', 'src', 'lib', 'licence', 'defaults.ts'),
];
if (!process.env.NGOS_E2E_URL) { console.error('Run through with-studio.mjs'); process.exit(2); }

const cli = (...args) => {
  const [cmd, ...base] = process.env.NGOS_E2E_CLI.split(' ');
  const r = spawnSync(cmd, [...base, ...args], { env: { ...process.env, STUDIO_DATA: process.env.NGOS_E2E_DATA, NODE_NO_WARNINGS: '1' }, encoding: 'utf8' });
  if (r.status !== 0) throw new Error(`Studio command ${args.join(' ')} failed: ${r.stderr}${r.stdout}`);
  return r.stdout.trim();
};
const run = (cmd, args, opts = {}) => {
  const r = spawnSync(cmd, args, { cwd: repo, encoding: 'utf8', maxBuffer: 64 * 1024 * 1024, ...opts });
  if (r.status !== 0) { console.error(`${cmd} ${args.join(' ')}\n${(r.stdout || '').slice(-3000)}${(r.stderr || '').slice(-3000)}`); throw new Error(`${cmd} failed`); }
  return r.stdout;
};

// The licence files a program on this PC writes (Linux: /usr/share when allowed, else the person's own folder). Leave no trace of the test.
const licenceDirs = [join('/usr/share', 'NextGenOS', 'SmartRetailPOS'), join(process.env.XDG_DATA_HOME || join(homedir(), '.local', 'share'), 'NextGenOS', 'SmartRetailPOS')];
// (A program only looks at these folders, creating them empty, so an empty one is nothing to protect.)
const inUse = licenceDirs.filter((d) => existsSync(d) && readdirSync(d).length > 0);
if (inUse.length) { console.error(`A licence is already stored on this PC (${inUse.join(', ')}); this test will not touch it. Move it away and run again.`); process.exit(2); }

const originals = defaults.map((f) => (existsSync(f) ? readFileSync(f, 'utf8') : null));
const work = mkdtempSync(join(tmpdir(), 'ngos-hub-release-'));
let code = 1;
try {
  // 1. Build the keys into the library, exactly as an owner does before a release.
  console.log(cli('sync-clients', '--url', process.env.NGOS_E2E_URL).split('\n')[0]);

  // 2. Publish the real Hub, protect it, audit it.
  const out = join(work, 'hub');
  run('dotnet', ['publish', hubWeb, '-c', 'Release', '-o', out, '-p:DebugType=none', '-p:DebugSymbols=false', '--nologo', '-v', 'q']);
  console.log('Published the Business Hub.');
  const protect = spawnSync('node', [join(repo, 'scripts', 'protect-dotnet.mjs'), '--dir', out, '--partial', 'NextGenOS.Hub.dll'], { encoding: 'utf8' });
  process.stdout.write(protect.stdout);
  if (protect.status !== 0) { process.stderr.write(protect.stderr); throw new Error('the protection step failed'); }
  const mine = ['NextGenOS.Hub.dll', 'NextGenOS.Hub.Core.dll', 'NextGenOS.Tax.dll', 'NextGenOS.Devices.dll', 'NextGenOS.Licensing.dll', 'NextGenOS.Licensing.AspNetCore.dll'];
  const audit = spawnSync('node', [join(repo, 'scripts', 'audit-package.mjs'), out, '--obfuscated', mine.join(','), '--names-from', ['apps/business-hub/src', 'libs/dotnet', 'licensing/clients/dotnet'].join(',')], { cwd: repo, encoding: 'utf8' });
  process.stdout.write(audit.stdout);
  if (audit.status !== 0) throw new Error('the package audit failed');

  // 3. A licence from the Studio, then the browser scenario against the protected program.
  const brand = JSON.parse(cli('create-brand', '--name', 'Luzon Fresh Mart', '--primary', '#aa2233', '--email', 'help@luzonfresh.example')).brand;
  const lic = JSON.parse(cli('create-licence', '--customer', 'Luzon Fresh Mart', '--country', 'Philippines', '--plan', 'business', '--devices', '2', '--brand', String(brand), '--white', 'theme'));
  const scenario = spawnSync('node', ['licensed.e2e.mjs'], {
    cwd: join(repo, 'apps', 'business-hub', 'e2e'), stdio: 'inherit', timeout: 900_000,
    env: { ...process.env, HUB_HOST_DLL: join(out, 'NextGenOS.Hub.dll'), HUB_E2E_KEY: lic.key, HUB_E2E_BRAND: 'Luzon Fresh Mart', HUB_E2E_STUDIO_CLI: process.env.NGOS_E2E_CLI, HUB_E2E_LID: lic.lid },
  });
  code = scenario.status ?? 1;
} catch (e) {
  console.error(String(e.message || e));
} finally {
  defaults.forEach((f, i) => { if (originals[i] !== null) writeFileSync(f, originals[i]); });
  licenceDirs.forEach((d) => { try { rmSync(d, { recursive: true, force: true }); } catch { /* nothing to remove */ } });
  rmSync(work, { recursive: true, force: true });
}
process.exit(code);
