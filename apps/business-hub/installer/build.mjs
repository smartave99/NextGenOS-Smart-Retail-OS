#!/usr/bin/env node
/**
 * Makes the Windows setup for the Business Hub, the way a customer receives it:
 *   node apps/business-hub/installer/build.mjs --version 1.0.0 [--out dist] [--rid win-x64] [--allow-no-key]
 *
 *   1. publishes the Hub as one self-contained folder (no .NET needed on the customer's PC),
 *   2. hides the names in our programs (scripts/protect-dotnet.mjs) and deletes symbols and maps,
 *   3. audits the folder: no source, no test program, no key, no database, no licence file, no secret, names really hidden,
 *   4. writes the setup (NSIS, SmartRetailHub.nsi) and a plain zip of the same folder, and audits the zip too.
 * It stops at the first problem. The licence keys must already be built into the licence library ("sync-clients" in the Licence Studio,
 * or the release workflow's step): a setup without them would refuse every licence. --allow-no-key is for trying the build only.
 * Needs: dotnet 10 SDK, node 22, Obfuscar (found or installed by scripts/lib/obfuscar.mjs), NSIS (makensis).
 */
import { spawnSync } from 'node:child_process';
import { existsSync, mkdirSync, mkdtempSync, readFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const repo = resolve(here, '..', '..', '..');
const args = process.argv.slice(2);
const flag = (n, d) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : d; };
const version = flag('--version', '');
if (!/^\d+\.\d+\.\d+$/.test(version)) { console.error('Say the version as three numbers: --version 1.0.0'); process.exit(2); }
const rid = flag('--rid', 'win-x64');
const dist = resolve(flag('--out', join(repo, 'dist')));
const allowNoKey = args.includes('--allow-no-key');

const run = (cmd, a, opts = {}) => {
  const r = spawnSync(cmd, a, { cwd: repo, encoding: 'utf8', maxBuffer: 256 * 1024 * 1024, ...opts });
  if (r.error || r.status !== 0) { console.error(`\n${cmd} ${a.join(' ')}\n${r.error ? r.error.message : ''}${(r.stdout || '').slice(-4000)}${(r.stderr || '').slice(-4000)}`); process.exit(1); }
  return r.stdout || '';
};
const say = (m) => console.log(`\n== ${m}`);

// 0. Keys.
const defaults = readFileSync(join(repo, 'licensing', 'clients', 'dotnet', 'NextGenOS.Licensing', 'LicenceDefaults.cs'), 'utf8');
const keyCount = (defaults.match(/new TrustedKey\(/g) || []).length;
const url = /ServerUrl = "([^"]*)"/.exec(defaults)?.[1] || '';
if ((keyCount === 0 || !url) && !allowNoKey) {
  console.error('The licence keys are not built in yet (licensing/clients/dotnet/NextGenOS.Licensing/LicenceDefaults.cs has no key or no Studio address).\nA setup made now would refuse every licence. In the Licence Studio folder run:\n  node src/cli.js sync-clients --url https://your-studio-address\nthen run this again. (Only to try the build: add --allow-no-key.)');
  process.exit(1);
}
console.log(keyCount ? `Licence keys built in: ${keyCount}; Studio address ${url}` : 'WARNING: no licence key built in (--allow-no-key): this setup refuses every licence.');

// 1. Publish.
const work = mkdtempSync(join(tmpdir(), 'hub-installer-'));
const out = join(work, 'hub');
try {
  say(`Publishing the Business Hub (${rid}, self-contained)`);
  run('dotnet', ['publish', join(repo, 'apps', 'business-hub', 'src', 'NextGenOS.Hub.Web'), '-c', 'Release', '-r', rid, '--self-contained', 'true', '-o', out,
    `-p:Version=${version}`, '-p:DebugType=none', '-p:DebugSymbols=false', '--nologo', '-v', 'q']);
  if (!existsSync(join(out, rid.startsWith('win') ? 'NextGenOS.Hub.exe' : 'NextGenOS.Hub'))) throw new Error('the program file is missing after publishing');

  // 2. Hide.
  say('Hiding the names in our programs');
  process.stdout.write(run('node', [join(repo, 'scripts', 'protect-dotnet.mjs'), '--dir', out, '--partial', 'NextGenOS.Hub.dll']));

  // 3. Audit.
  say('Auditing the folder');
  const mine = ['NextGenOS.Hub.dll', 'NextGenOS.Hub.Core.dll', 'NextGenOS.Tax.dll', 'NextGenOS.Devices.dll', 'NextGenOS.Licensing.dll', 'NextGenOS.Licensing.AspNetCore.dll'];
  const audit = (target) => process.stdout.write(run('node', [join(repo, 'scripts', 'audit-package.mjs'), target, ...(target === out ? ['--obfuscated', mine.join(','), '--names-from', 'apps/business-hub/src,libs/dotnet,licensing/clients/dotnet'] : [])]));
  audit(out);

  mkdirSync(dist, { recursive: true });
  const base = `SmartRetailPOS-Hub-${version}-${rid}`;

  // 4a. The zip: the same folder, for a person who deploys by hand.
  say('Writing the zip');
  const zip = join(dist, `${base}.zip`);
  rmSync(zip, { force: true });
  if (process.platform === 'win32') run('tar', ['-a', '-c', '-f', zip, '-C', out, '.']);   // Windows' own tar writes zip files
  else run('zip', ['-q', '-r', zip, '.'], { cwd: out });
  audit(zip);

  // 4b. The setup.
  say('Writing the setup');
  const list = join(work, 'uninstall-files.nsh');
  process.stdout.write(run('node', [join(here, 'make-uninstall-list.mjs'), out, list]));
  const makensis = process.platform === 'win32' && existsSync('C:\\Program Files (x86)\\NSIS\\makensis.exe') ? 'C:\\Program Files (x86)\\NSIS\\makensis.exe' : 'makensis';
  const setup = join(dist, `SmartRetailPOS-Hub-Setup-${version}.exe`);
  process.stdout.write(run(makensis, ['-V2', `-DVERSION=${version}`, `-DSOURCE=${out}`, `-DUNINSTALL_LIST=${list}`, `-DOUTFILE=${setup}`, `-DEULA=${join(repo, 'EULA.txt')}`, `-DNOTICES=${join(repo, 'THIRD-PARTY-NOTICES.md')}`, join(here, 'SmartRetailHub.nsi')]));
  console.log(`\nWrote:\n  ${setup}\n  ${zip}`);
} finally {
  rmSync(work, { recursive: true, force: true });
}
