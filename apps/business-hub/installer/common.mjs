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

/**
 * The build properties that tell a Hub where to look for updates and whose signed statement to trust (blueprint REL-016): the public online folder (https, ending in /), and the
 * repository, its owner and the release workflow, by GitHub's own numbers. They are written into the program by the build and are never read from a setting on the PC. Given none, a build
 * does not look for updates (a trial, a build on a laptop); given a folder, it must be given the numbers too and all must be well formed, or the build stops: a Hub that looks in the wrong place
 * would be found out only in a shop.
 * Names (or the environment, which the release workflow sets): --update-feed / NGOS_UPDATE_FEED, --release-repository-id / NGOS_RELEASE_REPOSITORY_ID,
 * --release-owner-id / NGOS_RELEASE_OWNER_ID, --release-workflow / NGOS_RELEASE_WORKFLOW (default .github/workflows/release.yml once any of the others is given).
 */
export function updateProperties(flag, env = process.env) {
  const feed = (flag('--update-feed', env.NGOS_UPDATE_FEED || '') || '').trim();
  const repositoryId = (flag('--release-repository-id', env.NGOS_RELEASE_REPOSITORY_ID || '') || '').trim();
  const ownerId = (flag('--release-owner-id', env.NGOS_RELEASE_OWNER_ID || '') || '').trim();
  const workflowGiven = (flag('--release-workflow', env.NGOS_RELEASE_WORKFLOW || '') || '').trim();
  if (!feed) return [];   // the folder is the switch: without it there is nothing to look in, and the numbers (which the release workflow always gives) are left out
  const workflow = workflowGiven || '.github/workflows/release.yml';
  const problems = [];
  let url = null;
  try { url = new URL(feed); } catch { /* reported below */ }
  if (!url || url.protocol !== 'https:' || !url.pathname.endsWith('/') || url.search || url.hash || url.username || url.password) problems.push('the update folder must be an https address ending in / (no sign-in details, no ? part)');
  if (!/^\d{1,20}$/.test(repositoryId)) problems.push("the repository's number must be digits (GitHub shows it as repository_id)");
  if (!/^\d{1,20}$/.test(ownerId)) problems.push("the repository owner's number must be digits (GitHub shows it as repository_owner_id)");
  if (!/^\.github\/workflows\/[A-Za-z0-9._-]{1,100}\.ya?ml$/.test(workflow)) problems.push('the release workflow must be a file under .github/workflows');
  if (problems.length) { console.error('The update settings of this build are not right:\n  - ' + problems.join('\n  - ')); process.exit(2); }
  return [`-p:UpdateFeed=${feed}`, `-p:ReleaseRepositoryId=${repositoryId}`, `-p:ReleaseOwnerId=${ownerId}`, `-p:ReleaseWorkflow=${workflow}`];
}
