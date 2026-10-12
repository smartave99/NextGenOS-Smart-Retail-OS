#!/usr/bin/env node
/**
 * Makes the Windows setup for the Business Hub, the way a customer receives it:
 *   node apps/business-hub/installer/build.mjs --version 1.0.0 [--out dist] [--rid win-x64] [--allow-no-key]
 *        [--update-feed https://.../hub/ --release-repository-id N --release-owner-id N [--release-workflow .github/workflows/release.yml]]   (where it looks for updates)
 *
 *   1. publishes the Hub as one self-contained folder (no .NET needed on the customer's PC),
 *   2. hides the names in our programs (scripts/protect-dotnet.mjs) and deletes symbols and maps,
 *   3. checks it runs on a factory-new PC (scripts/audit-prerequisites.mjs), then audits the folder: no source, no test program, no key, no database, no licence file, no secret, names really hidden,
 *   4. writes the setup (NSIS, SmartRetailHub.nsi), then a plain zip of the same folder with a hidden launcher beside the program ("Start Business Hub", no black window: zip-launcher.mjs),
 *      and audits the zip too.
 * It stops at the first problem. The licence keys must already be built into the licence library ("sync-clients" in the Licence Studio,
 * or the release workflow's step): a setup without them would refuse every licence. --allow-no-key is for trying the build only.
 * Needs: dotnet 10 SDK, node 22, Obfuscar (found or installed by scripts/lib/obfuscar.mjs), NSIS (makensis).
 */
import { existsSync, mkdirSync, mkdtempSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve } from 'node:path';
import { here, repo, flags, run, say, checkKeys, prerequisitesFor, updateProperties, OUR_PROGRAMS, NAMES_FROM } from './common.mjs';
import { addZipLauncher, addServiceLaunchers, removeServiceLaunchers } from './zip-launcher.mjs';

const { flag, has } = flags(process.argv.slice(2));
const version = flag('--version', '');
if (!/^\d+\.\d+\.\d+$/.test(version)) { console.error('Say the version as three numbers: --version 1.0.0'); process.exit(2); }
const rid = flag('--rid', 'win-x64');
const dist = resolve(flag('--out', join(repo, 'dist')));
const allowNoKey = has('--allow-no-key');
const updates = updateProperties(flag);   // where this Hub looks for updates and whom it trusts: nothing unless the release workflow gives it (blueprint REL-016)

// 0. Keys.
checkKeys(allowNoKey);

// 1. Publish.
const work = mkdtempSync(join(tmpdir(), 'hub-installer-'));
const out = join(work, 'hub');
try {
  say(`Publishing the Business Hub (${rid}, self-contained)`);
  run('dotnet', ['publish', join(repo, 'apps', 'business-hub', 'src', 'NextGenOS.Hub.Web'), '-c', 'Release', '-r', rid, '--self-contained', 'true', '-o', out,
    `-p:Version=${version}`, ...updates, '-p:DebugType=none', '-p:DebugSymbols=false', '--nologo', '-v', 'q']);
  if (!existsSync(join(out, rid.startsWith('win') ? 'NextGenOS.Hub.exe' : 'NextGenOS.Hub'))) throw new Error('the program file is missing after publishing');

  // 2. Hide.
  say('Hiding the names in our programs');
  process.stdout.write(run('node', [join(repo, 'scripts', 'protect-dotnet.mjs'), '--dir', out, '--partial', 'NextGenOS.Hub.dll']));

  // 2b. Say what the folder carries and what it relies on Windows for, and check that is true (CLAUDE.md, section 6: it runs on a factory-new PC).
  writeFileSync(join(out, 'prerequisites.json'), JSON.stringify(prerequisitesFor('windows', 'x64'), null, 2) + '\n');
  say('Checking it needs nothing that is not in the folder or in Windows itself');
  process.stdout.write(run('node', [join(repo, 'scripts', 'audit-prerequisites.mjs'), out, '--os', 'windows', '--arch', 'x64']));

  // 3. Audit.
  say('Auditing the folder');
  const audit = (target) => process.stdout.write(run('node', [join(repo, 'scripts', 'audit-package.mjs'), target, ...(target === out ? ['--obfuscated', OUR_PROGRAMS.join(','), '--names-from', NAMES_FROM] : [])]));
  audit(out);

  mkdirSync(dist, { recursive: true });
  const base = `SmartRetailPOS-Hub-${version}-${rid}`;

  // 4a. The setup, from the folder as it was published. It installs the Hub as a Windows service, and puts two small programs beside it that the icons use: they wait until the Hub
  // (which Windows starts with the PC; the icon also asks Windows to start it when it is off) answers, and then open its window of its own. They never start a second copy of it and never use the web browser.
  say('Adding the programs that open the Hub\'s window to the folder for the setup');
  try { console.log(`  ${addServiceLaunchers(out, { version }).join('\n  ')}`); } catch (e) { console.error(`\n${e.message}`); process.exit(1); }
  process.stdout.write(run('node', [join(repo, 'scripts', 'audit-prerequisites.mjs'), out, '--os', 'windows', '--arch', 'x64']));
  audit(out);
  say('Writing the setup');
  const list = join(work, 'uninstall-files.nsh');
  process.stdout.write(run('node', [join(here, 'make-uninstall-list.mjs'), out, list]));
  const makensis = process.platform === 'win32' && existsSync('C:\\Program Files (x86)\\NSIS\\makensis.exe') ? 'C:\\Program Files (x86)\\NSIS\\makensis.exe' : 'makensis';
  const setup = join(dist, `SmartRetailPOS-Hub-Setup-${version}.exe`);
  process.stdout.write(run(makensis, ['-V2', `-DVERSION=${version}`, `-DSOURCE=${out}`, `-DUNINSTALL_LIST=${list}`, `-DOUTFILE=${setup}`, `-DEULA=${join(repo, 'EULA.txt')}`, `-DNOTICES=${join(repo, 'THIRD-PARTY-NOTICES.md')}`, join(here, 'SmartRetailHub.nsi')]));

  removeServiceLaunchers(out);   // the zip has its own launcher below

  // 4b. The zip: the same folder, for a person who deploys by hand. Double-clicking NextGenOS.Hub.exe would show a black window, so the zip carries "Start Business Hub" beside it
  // (a small hidden launcher: it starts the Hub in the background and opens it in a window of its own), a helper with a window for finding a problem, and a read-me that says the
  // setup is the normal way (CLAUDE.md, section 10). The folder is checked again with the launcher in it.
  say('Adding the launcher, the helper and the read-me to the folder for the zip');
  try { console.log(`  ${addZipLauncher(out, { version }).join('\n  ')}`); } catch (e) { console.error(`\n${e.message}`); process.exit(1); }
  process.stdout.write(run('node', [join(repo, 'scripts', 'audit-prerequisites.mjs'), out, '--os', 'windows', '--arch', 'x64']));
  audit(out);
  say('Writing the zip');
  const zip = join(dist, `${base}.zip`);
  rmSync(zip, { force: true });
  if (process.platform === 'win32') run(join(process.env.SystemRoot || 'C:\\Windows', 'System32', 'tar.exe'), ['-a', '-c', '-f', zip, '-C', out, '.']);   // Windows' own tar writes zip files (another tar earlier on the path may not)
  else run('zip', ['-q', '-r', zip, '.'], { cwd: out });
  audit(zip);
  console.log(`\nWrote:\n  ${setup}\n  ${zip}`);
} finally {
  rmSync(work, { recursive: true, force: true });
}
