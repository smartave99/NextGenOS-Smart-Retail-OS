// The Business Hub's plain zip (apps/business-hub/installer/build.mjs): double-clicking NextGenOS.Hub.exe there would show a black window, so the zip carries "Start Business Hub"
// (a hidden launcher that starts the Hub once and opens it in a window of its own), a helper with a window for problems, and a read-me that says the setup is the normal way.
// CLAUDE.md, section 10. The launcher's behaviour is run under Wine in launcher-open-wine.test.mjs; a real Windows PC is still needed to look for a flashing black window.
import test from 'node:test';
import assert from 'node:assert/strict';
import { spawnSync } from 'node:child_process';
import { existsSync, mkdtempSync, readFileSync, readdirSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { auditPrerequisites } from '../audit-prerequisites.mjs';
import { auditFolder } from '../audit-package.mjs';
import { peImports } from '../lib/binary-imports.mjs';
import { buildLauncher } from '../lib/build-launcher.mjs';
import { prerequisitesFor } from '../../apps/business-hub/installer/common.mjs';
import { addZipLauncher, HUB_ADDRESS, HUB_PROGRAM, HUB_SERVICE, LAUNCHER_FILE, PROBLEM_HELPER, README_FILE, problemHelperText, readMeText } from '../../apps/business-hub/installer/zip-launcher.mjs';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const skip = spawnSync('makensis', ['-VERSION']).error ? 'makensis (NSIS) is not installed here' : false;

/** A folder like the published Hub: a stand-in for the program (not a real Windows program: the audit then has only the launcher to read) and its prerequisites.json. */
function hubFolder() {
  const dir = mkdtempSync(join(tmpdir(), 'hub-zip-'));
  writeFileSync(join(dir, HUB_PROGRAM), 'stand-in for the Hub program');
  writeFileSync(join(dir, 'prerequisites.json'), JSON.stringify(prerequisitesFor('windows', 'x64'), null, 2) + '\n');
  return dir;
}
const has = (buf, text) => buf.includes(Buffer.from(text, 'utf16le'));

test('the zip gets the launcher, the helper with a window and the read-me, and prerequisites.json names the launcher', { skip }, () => {
  const dir = hubFolder();
  try {
    const added = addZipLauncher(dir, { version: '1.2.3' });
    assert.deepEqual(added, [LAUNCHER_FILE, `${PROBLEM_HELPER}.bat`, README_FILE]);
    for (const f of added) assert.ok(existsSync(join(dir, f)), f);
    assert.equal(LAUNCHER_FILE, 'Start Business Hub.exe');
    const manifest = JSON.parse(readFileSync(join(dir, 'prerequisites.json'), 'utf8'));
    assert.deepEqual(manifest.launchers, [LAUNCHER_FILE]);
    assert.deepEqual(manifest.system, ['windows-10-22h2-or-11-x64', 'windows-system-dlls', 'web-browser-edge'], 'nothing new is asked of the PC');
    addZipLauncher(dir, { version: '1.2.3' });
    assert.deepEqual(JSON.parse(readFileSync(join(dir, 'prerequisites.json'), 'utf8')).launchers, [LAUNCHER_FILE], 'adding it twice does not list it twice');
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the launcher is a window program of 32-bit Windows that starts the Hub once and opens its address in a window of its own', { skip }, () => {
  const dir = hubFolder();
  try {
    addZipLauncher(dir, { version: '1.2.3' });
    const exe = readFileSync(join(dir, LAUNCHER_FILE));
    assert.equal(exe.subarray(0, 2).toString('latin1'), 'MZ');
    const pe = exe.readUInt32LE(0x3c);
    assert.equal(exe.readUInt16LE(pe + 4), 0x14c, 'a 32-bit program (the one such program a 64-bit package may carry: docs/PREREQUISITES.md)');
    assert.equal(exe.readUInt16LE(pe + 24 + 68), 2, 'a window program (subsystem 2): no black window opens');
    for (const text of [HUB_PROGRAM, `--app=${HUB_ADDRESS}`, '--user-data-dir=', PROBLEM_HELPER, 'did not start within 90 seconds', 'NextGenOS.Launcher.5280', 'smart-retail-pos-window', 'Smart Retail POS Hub', '1.2.3', 'Unpack the whole zip file']) {
      assert.ok(has(exe, text), `the launcher says "${text}"`);
    }
    assert.ok(has(exe, 'ws2_32::connect'), 'it asks whether the Hub already answers before it starts one');
    assert.ok(!has(exe, 'cmd.exe') && !has(exe, 'powershell'), 'it starts the program itself: no command window, no script host');
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the launcher imports nothing a factory-new Windows does not have, and the folder passes both audits with it in', { skip }, () => {
  const dir = hubFolder();
  try {
    addZipLauncher(dir, { version: '1.2.3' });
    const own = auditPrerequisites(dir, { os: 'windows', arch: 'x64' });
    assert.deepEqual(own.problems, [], own.problems.join('\n'));
    const package_ = auditFolder(dir);
    assert.deepEqual(package_.problems, [], package_.problems.join('\n'));
    // The open-window kind adds no import to the launcher: its few more actions are made through the helper that NSIS carries inside it.
    const plain = join(dir, 'plain.exe');
    buildLauncher({ outFile: plain, name: 'Plain', program: 'x.exe', args: 'a' });
    const sameImports = (a, b) => JSON.stringify([...peImports(readFileSync(a)).imports].sort()) === JSON.stringify([...peImports(readFileSync(b)).imports].sort());
    assert.ok(sameImports(plain, join(dir, LAUNCHER_FILE)), 'the same Windows libraries as the launchers that only start a program');
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('without the launcher the audit would refuse the 32-bit file: the manifest has to name it', { skip }, () => {
  const dir = hubFolder();
  try {
    addZipLauncher(dir, { version: '1.2.3' });
    const manifest = JSON.parse(readFileSync(join(dir, 'prerequisites.json'), 'utf8'));
    delete manifest.launchers;
    writeFileSync(join(dir, 'prerequisites.json'), JSON.stringify(manifest));
    assert.match(auditPrerequisites(dir, { os: 'windows', arch: 'x64' }).problems.join('\n'), /Start Business Hub\.exe: made for another processor/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('it stops, in plain words, when there is no program to start, no manifest or no version', { skip }, () => {
  const dir = hubFolder();
  try {
    assert.throws(() => addZipLauncher(dir, { version: '1.2' }), /three numbers/);
    rmSync(join(dir, HUB_PROGRAM));
    assert.throws(() => addZipLauncher(dir, { version: '1.2.3' }), /NextGenOS\.Hub\.exe is not in .*nothing to start/);
    writeFileSync(join(dir, HUB_PROGRAM), 'x');
    rmSync(join(dir, 'prerequisites.json'));
    assert.throws(() => addZipLauncher(dir, { version: '1.2.3' }), /prerequisites\.json is missing/);
    assert.throws(() => addZipLauncher(dir, { version: '1.2.3', makensis: null }), /prerequisites\.json|NSIS/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the read-me says in plain words that the setup is the normal way, how to open it, what closing the window does, and where the data is', () => {
  const text = readMeText('1.2.3');
  assert.match(text, /The normal way to put the Hub on a PC is the SETUP file \(SmartRetailPOS-Hub-Setup-1\.2\.3\.exe\)/);
  assert.match(text, /Double-click "Start Business Hub"/);
  assert.match(text, /There is no black window/);
  assert.match(text, /Closing its window does NOT stop it/);
  assert.match(text, /End task/);
  assert.match(text, /ProgramData\\NextGenOS\\Hub/);
  assert.ok(text.includes(`"${PROBLEM_HELPER}"`), 'it names the helper for problems');
  assert.match(text, /Windows protected your PC/);
  assert.ok(text.includes('\r\n'), 'Windows line endings');
  // Plain words: nobody is told to open a terminal, type a command or leave a window open.
  assert.ok(!/terminal|command prompt|powershell|type the|run the command/i.test(text), 'no jargon');
});

test('the helper with a window says it is for problems and runs the Hub in that window; the address is the one the Hub and the setup use', () => {
  const bat = problemHelperText();
  assert.match(bat, /^@echo off\r\nrem Opens the Smart Retail POS Hub in this window so that you can read what it says, for finding a problem\./);
  assert.match(bat, /normal way is "Start Business Hub"/);
  assert.match(bat, /\r\nNextGenOS\.Hub\.exe\r\n/);
  assert.equal(`${PROBLEM_HELPER}.bat`, 'Start Business Hub (with a window, for problems).bat');
  const kestrel = JSON.parse(readFileSync(join(repo, 'apps/business-hub/src/NextGenOS.Hub.Web/appsettings.json'), 'utf8')).Kestrel.Endpoints.Http.Url;
  assert.equal(HUB_ADDRESS, kestrel, 'the launcher waits at the address the Hub listens on');
  assert.equal(/!define ADDRESS "([^"]+)"/.exec(readFileSync(join(repo, 'apps/business-hub/installer/SmartRetailHub.nsi'), 'utf8'))[1], HUB_ADDRESS, 'the setup opens the same address');
});

test('the icon, the setup and the Hub name the same Windows service, so the icon can switch on the one the setup made', () => {
  const nsi = readFileSync(join(repo, 'apps/business-hub/installer/SmartRetailHub.nsi'), 'utf8');
  assert.equal(/!define SERVICE "([^"]+)"/.exec(nsi)[1], HUB_SERVICE, 'the setup makes the service the icon asks about');
  assert.match(readFileSync(join(repo, 'apps/business-hub/src/NextGenOS.Hub.Web/HubHost.cs'), 'utf8'), new RegExp(`ServiceName = "${HUB_SERVICE}"`), 'the Hub answers to the same name');
  assert.equal(/!define PORT "(\d+)"/.exec(nsi)[1], new URL(HUB_ADDRESS).port, 'the setup waits at the port the Hub listens on');
});

test('the setup makes a service that is on early, that the people at the PC may switch ON and nothing more, and the setup waits until the Hub answers (and says in words when it does not)', () => {
  const nsi = readFileSync(join(repo, 'apps/business-hub/installer/SmartRetailHub.nsi'), 'utf8').replace(/^\s*;.*$/gm, '');
  assert.match(nsi, /sc\.exe create \$\{SERVICE\}[^\n]*start= auto /, 'it starts with the PC at once');
  assert.match(nsi, /sc\.exe config \$\{SERVICE\}[^\n]*start= auto /, 'an update sets the same');
  assert.doesNotMatch(nsi, /delayed-auto/, 'not "delayed": a till must be ready as early as the PC is');
  assert.match(nsi, /sc\.exe failureflag \$\{SERVICE\} 1/, 'Windows also restarts it when it stops with an error');
  const sd = /sc\.exe sdset \$\{SERVICE\} "(D:[^"]+)"/.exec(nsi)?.[1];
  assert.ok(sd, 'the rights on the service are set');
  const aces = [...sd.matchAll(/\(A;;([A-Z]+);;;([A-Z]{2})\)/g)].map((m) => ({ who: m[2], rights: m[1].match(/../g) }));
  const of = (who) => aces.filter((a) => a.who === who).flatMap((a) => a.rights);
  assert.ok(of('IU').includes('RP'), 'the people at the PC may start it');
  for (const bad of ['WP', 'DT', 'DC', 'SD', 'WD', 'WO']) assert.ok(!of('IU').includes(bad), `the people at the PC may not (${bad}): stop it, pause it, change it, delete it or change who may`);
  assert.ok(!aces.some((a) => ['WD', 'AU', 'BU', 'AN', 'LS', 'NS'].includes(a.who)), 'nobody else is given a right');
  assert.ok(of('SU').every((r) => ['CC', 'LC', 'SW', 'LO', 'CR', 'RC'].includes(r)), 'other service accounts may only look');
  assert.match(nsi, /Function VerifyStarted[\s\S]*Call WaitForHub[\s\S]*Call HubWriteNote/, 'it waits for the Hub to answer, and writes the note when it does not');
  assert.match(nsi, /sc\.exe start \$\{SERVICE\}'\s+Pop \$0\s+Call VerifyStarted/, 'right after it asks Windows to start the service');
  assert.match(nsi, /\$\{Silent\}[\s\S]*SetErrorLevel 3/, 'a quiet install ends with code 3 when the Hub does not answer');
  assert.match(nsi, /icacls\.exe "\$APPDATA\\\$\{COMPANY\}\\Logs" \/grant "\*S-1-5-19:\(OI\)\(CI\)M"/, 'the service may write the notes about how it started');
  assert.match(nsi, /Call PortBind\s+\$\{If\} \$0 == 10013/, 'the setup says so when Windows keeps the Hub\'s place (port) for itself');
  assert.match(nsi, /icacls\.exe "\$APPDATA\\\$\{COMPANY\}\\Hub\\\*" \/reset \/T \/C \/Q/, 'files an earlier copy left take the folder\'s rights again');
  assert.ok(!/powershell|wscript|cscript|mshta/i.test(nsi), 'no script host');
});

test('the build writes the setup first and adds the launcher to the folder only for the zip; and the setup itself never starts the console program', () => {
  const build = readFileSync(join(repo, 'apps/business-hub/installer/build.mjs'), 'utf8');
  const setupAt = build.indexOf("say('Writing the setup')");
  const launcherAt = build.indexOf('addZipLauncher(out');
  const zipAt = build.indexOf("say('Writing the zip')");
  assert.ok(setupAt > 0 && launcherAt > setupAt && zipAt > launcherAt, 'setup, then the launcher, then the zip');
  const afterLauncher = build.slice(launcherAt, zipAt);
  assert.match(afterLauncher, /audit-prerequisites\.mjs/, 'the prerequisites are checked again with the launcher in the folder');
  assert.match(afterLauncher, /audit\(out\)/, 'and so is the folder itself');
  assert.match(build, /audit\(zip\)/, 'and the zip');
  // The setup installs a service and window shortcuts: no launcher file of its own (it would start a second copy beside the service).
  assert.ok(!/Start Business Hub/.test(readFileSync(join(repo, 'apps/business-hub/installer/SmartRetailHub.nsi'), 'utf8')));
  assert.ok(!readdirSync(join(repo, 'apps/business-hub/installer')).some((f) => /\.(bat|cmd)$/i.test(f)), 'no script beside the build');
});
