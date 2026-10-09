#!/usr/bin/env node
/**
 * Makes the Linux package for the Business Hub (a .deb, for Ubuntu, Linux Mint, Debian and the like), the way a customer receives it:
 *   node apps/business-hub/installer/build-linux.mjs --version 1.0.0 [--arch x64|arm64] [--out dist] [--allow-no-key]
 *
 *   1. publishes the Hub as one self-contained folder (no .NET needed on the PC), and takes away the runtime's tracing and debugging helpers,
 *   2. hides the names in our programs (scripts/protect-dotnet.mjs) and deletes symbols and maps,
 *   3. checks it runs on a factory-new PC (scripts/audit-prerequisites.mjs), then audits the folder: no source, no test program, no key, no database, no licence file, no secret,
 *   4. writes the .deb: the program in /opt/nextgenos/smart-retail-hub, a service that starts with the PC (own account, shop data in /var/lib/nextgenos, never removed),
 *      a Start-menu entry and a full-screen entry, and the command `smart-retail-pos`; then opens the .deb again and audits what is inside.
 * A setup prepared for one business is a second, small package made by the Setup Studio (smart-retail-profile-<name>): it only adds the profile folder.
 * It stops at the first problem. The licence keys must already be built into the licence library (see build.mjs); --allow-no-key is for trying the build only.
 * Needs: dotnet 10 SDK, node 22, Obfuscar (found or installed by scripts/lib/obfuscar.mjs), dpkg-deb (any Debian or Ubuntu has it).
 */
import { spawnSync } from 'node:child_process';
import { chmodSync, copyFileSync, cpSync, existsSync, mkdirSync, mkdtempSync, readdirSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve } from 'node:path';
import { here, repo, flags, run, say, checkKeys, prerequisitesFor, OUR_PROGRAMS, NAMES_FROM, NOT_NEEDED_ON_LINUX } from './common.mjs';

const { flag, has } = flags(process.argv.slice(2));
const version = flag('--version', '');
if (!/^\d+\.\d+\.\d+$/.test(version)) { console.error('Say the version as three numbers: --version 1.0.0'); process.exit(2); }
const arch = flag('--arch', 'x64');
if (!['x64', 'arm64'].includes(arch)) { console.error('The system must be x64 or arm64: --arch x64'); process.exit(2); }
const rid = `linux-${arch}`;
const debArch = arch === 'x64' ? 'amd64' : 'arm64';
const dist = resolve(flag('--out', join(repo, 'dist')));
const maintainer = flag('--maintainer', 'NextGenOS <smartave99@gmail.com>');
const allowNoKey = has('--allow-no-key');

if (spawnSync('dpkg-deb', ['--version'], { encoding: 'utf8' }).status !== 0) { console.error('dpkg-deb is not installed. A .deb is built on Debian, Ubuntu or Linux Mint (the release workflow does it on an Ubuntu runner).'); process.exit(1); }

checkKeys(allowNoKey);

const work = mkdtempSync(join(tmpdir(), 'hub-linux-'));
const program = join(work, 'hub');
const tree = join(work, 'deb');
try {
  say(`Publishing the Business Hub (${rid}, self-contained)`);
  run('dotnet', ['publish', join(repo, 'apps', 'business-hub', 'src', 'NextGenOS.Hub.Web'), '-c', 'Release', '-r', rid, '--self-contained', 'true', '-o', program,
    `-p:Version=${version}`, '-p:DebugType=none', '-p:DebugSymbols=false', '--nologo', '-v', 'q']);
  if (!existsSync(join(program, 'NextGenOS.Hub'))) throw new Error('the program file is missing after publishing');
  for (const name of NOT_NEEDED_ON_LINUX) rmSync(join(program, name), { force: true });

  say('Hiding the names in our programs');
  process.stdout.write(run('node', [join(repo, 'scripts', 'protect-dotnet.mjs'), '--dir', program, '--partial', 'NextGenOS.Hub.dll']));

  writeFileSync(join(program, 'prerequisites.json'), JSON.stringify(prerequisitesFor('linux', arch), null, 2) + '\n');
  say('Checking it needs nothing that is not in the folder or in the base system');
  process.stdout.write(run('node', [join(repo, 'scripts', 'audit-prerequisites.mjs'), program, '--os', 'linux', '--arch', arch]));

  say('Auditing the folder');
  const audit = (target, extra = []) => process.stdout.write(run('node', [join(repo, 'scripts', 'audit-package.mjs'), target, ...extra]));
  audit(program, ['--obfuscated', OUR_PROGRAMS.join(','), '--names-from', NAMES_FROM]);

  say('Writing the .deb');
  const opt = join(tree, 'opt', 'nextgenos', 'smart-retail-hub');
  mkdirSync(opt, { recursive: true });
  cpSync(program, opt, { recursive: true });
  const put = (from, to, mode) => { mkdirSync(join(to, '..'), { recursive: true }); copyFileSync(from, to); chmodSync(to, mode); };
  const lin = (n) => join(here, 'linux', n);
  put(lin('nextgenos-hub.service'), join(tree, 'lib', 'systemd', 'system', 'nextgenos-hub.service'), 0o644);
  put(lin('smart-retail-pos'), join(tree, 'usr', 'bin', 'smart-retail-pos'), 0o755);
  put(lin('smart-retail-pos.desktop'), join(tree, 'usr', 'share', 'applications', 'smart-retail-pos.desktop'), 0o644);
  put(lin('smart-retail-pos-fullscreen.desktop'), join(tree, 'usr', 'share', 'applications', 'smart-retail-pos-fullscreen.desktop'), 0o644);
  put(lin('smart-retail-pos.svg'), join(tree, 'usr', 'share', 'icons', 'hicolor', 'scalable', 'apps', 'smart-retail-pos.svg'), 0o644);
  const doc = join(tree, 'usr', 'share', 'doc', 'smart-retail-pos-hub');
  put(join(repo, 'EULA.txt'), join(doc, 'copyright'), 0o644);
  put(join(repo, 'THIRD-PARTY-NOTICES.md'), join(doc, 'THIRD-PARTY-NOTICES.md'), 0o644);

  // Nothing in the package may be changed by the account the Hub runs as. Only the program, its libraries and our own scripts are run; everything else is plain data.
  const runnable = (name) => name === 'NextGenOS.Hub' || /\.so(\.\d+)*$/.test(name) || ['smart-retail-pos', 'postinst', 'prerm', 'postrm'].includes(name);
  const fix = (dir) => {
    for (const e of readdirSync(dir, { withFileTypes: true })) {
      const full = join(dir, e.name);
      if (e.isDirectory()) { chmodSync(full, 0o755); fix(full); } else if (e.isFile()) chmodSync(full, runnable(e.name) ? 0o755 : 0o644);
    }
  };
  fix(tree);
  chmodSync(tree, 0o755);

  const control = join(tree, 'DEBIAN');
  mkdirSync(control, { recursive: true });
  const installedKib = Math.ceil(Number(run('du', ['-sk', tree]).split(/\s/)[0]) || 0);
  writeFileSync(join(control, 'control'), [
    'Package: smart-retail-pos-hub',
    `Version: ${version}-1`,
    `Architecture: ${debArch}`,
    `Maintainer: ${maintainer}`,
    `Installed-Size: ${installedKib}`,
    'Depends: libc6 (>= 2.34), libgcc-s1, libstdc++6, libssl3 | libssl3t64, systemd',
    'Recommends: chromium | chromium-browser | google-chrome-stable | microsoft-edge-stable',   // a browser that can show a window of its own; Firefox cannot, so it is not named (apt installs the first one when none is there)
    'Section: misc',
    'Priority: optional',
    'Description: Smart Retail POS Hub by NextGenOS',
    ' The counter, stock, bills and reports of a business: a shop, a restaurant, a library,',
    ' a builder or a salon. It runs quietly in the background and starts with the PC.',
    ' You open it from the Smart Retail POS entry in the applications menu, in a window of its own.',
    ' .',
    " It carries everything it needs. The shop's information is kept in /var/lib/nextgenos",
    ' and is never removed when the program is uninstalled.',
    '',
  ].join('\n'));
  for (const script of ['postinst', 'prerm', 'postrm']) put(lin(script), join(control, script), 0o755);

  mkdirSync(dist, { recursive: true });
  const deb = join(dist, `smart-retail-pos-hub_${version}-1_${debArch}.deb`);
  rmSync(deb, { force: true });
  // xz: every Debian and Ubuntu that is supported can open it (newer compressors are not on older systems).
  run('dpkg-deb', ['--root-owner-group', '-Zxz', '-z6', '--build', tree, deb]);

  say('Opening the .deb again and auditing what is inside');
  const check = join(work, 'unpacked');
  mkdirSync(check);
  run('dpkg-deb', ['-x', deb, check]);
  audit(join(check, 'opt', 'nextgenos', 'smart-retail-hub'), ['--obfuscated', OUR_PROGRAMS.join(','), '--names-from', NAMES_FROM]);
  audit(deb);
  console.log(`\nWrote:\n  ${deb}`);
} finally {
  rmSync(work, { recursive: true, force: true });
}
