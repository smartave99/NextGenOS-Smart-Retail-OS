// What the Hub's Windows and Linux package builders share: running a command and stopping on the first problem, and the check that the licence keys are built in.
import { spawnSync } from 'node:child_process';
import { readFileSync } from 'node:fs';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

export const here = dirname(fileURLToPath(import.meta.url));
export const repo = resolve(here, '..', '..', '..');

export function flags(argv) {
  const flag = (n, d) => { const i = argv.indexOf(n); return i >= 0 ? argv[i + 1] : d; };
  return { flag, has: (n) => argv.includes(n) };
}

/** Runs a command in the repository; on any failure prints what it said and stops the whole build. Returns what it wrote. */
export function run(cmd, a, opts = {}) {
  const r = spawnSync(cmd, a, { cwd: repo, encoding: 'utf8', maxBuffer: 256 * 1024 * 1024, ...opts });
  if (r.error || r.status !== 0) { console.error(`\n${cmd} ${a.join(' ')}\n${r.error ? r.error.message : ''}${(r.stdout || '').slice(-4000)}${(r.stderr || '').slice(-4000)}`); process.exit(1); }
  return r.stdout || '';
}

export const say = (m) => console.log(`\n== ${m}`);

/** The licence keys must be built into the licence library: a package without them would refuse every licence. --allow-no-key is for trying the build only. */
export function checkKeys(allowNoKey) {
  const defaults = readFileSync(join(repo, 'licensing', 'clients', 'dotnet', 'NextGenOS.Licensing', 'LicenceDefaults.cs'), 'utf8');
  const keyCount = (defaults.match(/new TrustedKey\(/g) || []).length;
  const url = /ServerUrl = "([^"]*)"/.exec(defaults)?.[1] || '';
  if ((keyCount === 0 || !url) && !allowNoKey) {
    console.error('The licence keys are not built in yet (licensing/clients/dotnet/NextGenOS.Licensing/LicenceDefaults.cs has no key or no Studio address).\nA package made now would refuse every licence. In the Licence Studio folder run:\n  node src/cli.js sync-clients --url https://your-studio-address\nthen run this again. (Only to try the build: add --allow-no-key.)');
    process.exit(1);
  }
  console.log(keyCount ? `Licence keys built in: ${keyCount}; Studio address ${url}` : 'WARNING: no licence key built in (--allow-no-key): this package refuses every licence.');
  return { keyCount, url };
}

/** The names of our own programs inside the published Hub folder (the ones whose type names are hidden and checked). */
export const OUR_PROGRAMS = ['NextGenOS.Hub.dll', 'NextGenOS.Hub.Core.dll', 'NextGenOS.Tax.dll', 'NextGenOS.Devices.dll', 'NextGenOS.Licensing.dll', 'NextGenOS.Licensing.AspNetCore.dll'];
export const NAMES_FROM = 'apps/business-hub/src,libs/dotnet,licensing/clients/dotnet';

/** The prerequisites.json that goes inside every package: what it carries, what it relies on the system for (scripts/audit-prerequisites.mjs checks it; docs/PREREQUISITES.md explains it). */
export function prerequisitesFor(os, arch) {
  return {
    schema: 1,
    os,
    arch,
    bundled: ['dotnet-runtime-self-contained', 'aspnetcore-runtime', 'native-libraries (database engine, picture and barcode library)', 'every library the program uses'],
    system: os === 'windows' ? ['windows-10-22h2-or-11-x64', 'windows-system-dlls', 'web-browser-edge'] : ['glibc-2.35-or-newer', 'libstdc++6-libgcc-s1', 'openssl-3', 'web-browser', 'systemd'],
    minimumSystem: os === 'windows' ? 'Windows 10 (22H2) or Windows 11, 64-bit; or Windows Server 2019 or later' : 'Ubuntu 22.04 or 24.04, Linux Mint 21 or later, Debian 12 or later; 64-bit Intel/AMD or ARM',
  };
}

/** Libraries the published program does not need to run and that a customer's machine should not have: tracing, debugging and memory-dump helpers of the .NET runtime (the tracing one also asks for a library no desktop has, and a memory dump would copy what the program holds). */
export const NOT_NEEDED_ON_LINUX = ['libcoreclrtraceptprovider.so', 'libmscordbi.so', 'libmscordaccore.so', 'createdump'];
