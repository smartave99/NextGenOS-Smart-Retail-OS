// The launcher of a background program that is used in a browser window (AppLauncher.nsi with OPEN_URL: the Business Hub's zip, the dashboard) and its command line
// (scripts/make-launcher.mjs). What it is told is checked before anything is made; what it makes says what it should; the launchers that only start a program are unchanged.
// Running it is done under Wine in launcher-open-wine.test.mjs.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, readFileSync, rmSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { buildLauncher, checkOpenAddress, launcherDefines, LAUNCHER_SCRIPT } from '../lib/build-launcher.mjs';
import { launcherOptions, parseArguments } from '../make-launcher.mjs';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const skip = spawnSync('makensis', ['-VERSION']).error ? 'makensis (NSIS) is not installed here' : false;
const icon = join(repo, 'scripts', 'launcher', 'product.ico');
const base = { outFile: join(tmpdir(), 'x.exe'), name: 'Example', program: 'app\\run.exe', icon };
const open = { url: 'http://127.0.0.1:5080' };
const has = (buf, text) => buf.includes(Buffer.from(text, 'utf16le'));

test('the defines of a launcher that opens a window carry the address, the port and the waiting time; one that only starts a program carries none of them', () => {
  const plain = launcherDefines({ ...base, args: 'a b' });
  assert.ok(plain.includes('-DARGS=a b'));
  assert.ok(!plain.some((d) => d.startsWith('-DOPEN_')), 'no window of its own');
  const d = launcherDefines({ ...base, open: { ...open, waitSeconds: 45, profile: 'my-window', helper: 'Start X (with a window, for problems)' } });
  for (const want of ['-DOPEN_URL=http://127.0.0.1:5080', '-DOPEN_HOST=127.0.0.1', '-DOPEN_PORT=5080', '-DOPEN_WAIT=45', '-DOPEN_PROFILE=my-window', '-DOPEN_HELPER=Start X (with a window, for problems)']) assert.ok(d.includes(want), want);
  assert.ok(!d.some((x) => x.startsWith('-DARGS=')), 'a program that needs no words is given none');
  assert.ok(launcherDefines({ ...base, open }).includes('-DOPEN_WAIT=60'), 'a minute by default');
});

test('only this PC\'s own plain address may be opened in a window by a launcher', () => {
  assert.deepEqual(checkOpenAddress('http://127.0.0.1:5280'), { url: 'http://127.0.0.1:5280', host: '127.0.0.1', port: 5280 });
  assert.equal(checkOpenAddress('http://127.0.0.1:5080/admin').url, 'http://127.0.0.1:5080/admin');
  for (const bad of ['https://127.0.0.1:5280', 'http://localhost:5280', 'http://192.168.1.5:5280', 'http://example.com:5280', 'http://127.0.0.1', 'http://127.0.0.1:99999', 'http://user:pw@127.0.0.1:5280', 'http://127.0.0.1:5280/?x=1', 'http://127.0.0.1:5280/#a', 'not a web address', '', undefined, 'http://127.0.0.1:5280/"; evil']) {
    assert.throws(() => checkOpenAddress(bad), /launcher's address/, String(bad));
  }
});

test('it refuses a waiting time, a window profile or a helper name that could break the script', () => {
  for (const waitSeconds of [0, -1, 601, 1.5, '60']) assert.throws(() => launcherDefines({ ...base, open: { ...open, waitSeconds } }), /waiting time/, String(waitSeconds));
  for (const profile of ['', '..\\x', 'a/b', 'a"b', ' x', '-x', 'x'.repeat(70), 5]) assert.throws(() => launcherDefines({ ...base, open: { ...open, profile } }), /window profile/, String(profile));
  for (const helper of ['', 'a"b', 'a\nb', 5]) assert.throws(() => launcherDefines({ ...base, open: { ...open, helper } }), /helper name/, String(helper));
  assert.throws(() => launcherDefines({ ...base, args: 'a"b' }), /args/);
});

test('the launcher script starts the program hidden, and uses no command window and no script host', () => {
  const nsi = readFileSync(LAUNCHER_SCRIPT, 'utf8');
  assert.equal([...nsi.matchAll(/ExecShell "open" "\$EXEDIR\\\$\{PROGRAM\}" "\$\{ARGS\}" SW_HIDE/g)].length, 2, 'both kinds start the program with a hidden window');
  assert.ok(!/cmd\.exe|powershell|wscript|cscript|mshta|nsExec/i.test(nsi.replace(/;.*$/gm, '')), 'no command window, no script host');
  assert.match(nsi, /RequestExecutionLevel user/, 'no administrator question');
  assert.match(nsi, /SilentInstall silent/, 'no setup window');
  assert.ok(!/^\s*(WriteReg\w*|DeleteReg\w*|File|WriteUninstaller|CreateShortCut|CopyFiles|Delete|WriteINIStr|FileOpen)\b/im.test(nsi.replace(/;.*$/gm, '')), 'it installs nothing and writes nothing: it only starts the program');
});

test('a launcher that only starts a program is the same as before: nothing of the window kind is in it', { skip }, () => {
  const dir = mkdtempSync(join(tmpdir(), 'launcher-open-'));
  try {
    const out = join(dir, 'Start Example.exe');
    buildLauncher({ ...base, outFile: out, args: 'start.js --app', workdir: 'app', check: 'app\\start.js' });
    const exe = readFileSync(out);
    assert.equal(exe.readUInt16LE(exe.readUInt32LE(0x3c) + 24 + 68), 2, 'a window program: no black window');
    for (const text of ['ws2_32', 'NextGenOS.Launcher.', '--app=', 'did not start within', 'msedge']) assert.ok(!has(exe, text), `no "${text}" in a launcher that only starts a program`);
    assert.ok(has(exe, 'start.js --app') && has(exe, 'Unpack the whole zip file'));
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('a launcher that opens a window says what it does, in plain words, and a program with no words is started with none', { skip }, () => {
  const dir = mkdtempSync(join(tmpdir(), 'launcher-open-'));
  try {
    const out = join(dir, 'Start Example.exe');
    buildLauncher({ ...base, outFile: out, program: 'Example.Web.exe', version: '2.3.4', open: { url: 'http://127.0.0.1:5080', waitSeconds: 45, profile: 'example-window', helper: 'Start Example (with a window, for problems)' } });
    const exe = readFileSync(out);
    assert.equal(exe.readUInt16LE(exe.readUInt32LE(0x3c) + 24 + 68), 2, 'a window program: no black window');
    for (const text of ['Example.Web.exe', '--app=http://127.0.0.1:5080', '--user-data-dir=', 'example-window', '--no-first-run', 'NextGenOS.Launcher.5080', 'ws2_32::connect', 'did not start within 45 seconds', 'Start Example (with a window, for problems)',
      'Microsoft\\Edge\\Application\\msedge.exe', 'Google\\Chrome\\Application\\chrome.exe', 'NEXTGENOS_APP_BROWSER', 'Example', '2.3.4']) assert.ok(has(exe, text), `the launcher says "${text}"`);
    // Without a helper name the message does not point at a file that is not there.
    const out2 = join(dir, 'Start Example 2.exe');
    buildLauncher({ ...base, outFile: out2, open });
    assert.ok(!has(readFileSync(out2), 'with a window, for problems'));
    assert.ok(has(readFileSync(out2), 'call the person who gave you the program'));
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the command line: it says what is wrong, in words, and never makes a launcher that is not what was asked for', () => {
  assert.throws(() => parseArguments(['--out', 'a.exe', '--name', 'N']), /--program is missing/);
  assert.throws(() => parseArguments(['--out', 'a.exe', '--name', 'N', '--program', 'p.exe', '--colour', 'red']), /I do not know "--colour"/);
  assert.throws(() => parseArguments(['--out', 'a.exe', '--name', 'N', '--program']), /--program needs a value/);
  assert.throws(() => parseArguments(['--out', 'a.exe', '--name', 'N', '--program', 'p.exe', '--wait', '30']), /--wait only goes with --open/);
  const s = parseArguments(['--out', 'a.exe', '--name', 'N', '--program', 'p.exe', '--open', 'http://127.0.0.1:5080', '--wait', '30', '--args', '--flag']);
  assert.equal(s['--args'], '--flag', 'a value that starts with two dashes is a value');
  const o = launcherOptions(s);
  assert.equal(o.outFile, resolve('a.exe'));
  assert.deepEqual(o.open, { url: 'http://127.0.0.1:5080', waitSeconds: 30 });
  assert.equal(o.icon, icon, 'the product icon unless another is given');
  assert.ok(!('open' in launcherOptions(parseArguments(['--out', 'a.exe', '--name', 'N', '--program', 'p.exe']))));
});

test('the command line makes the launcher, and stops with a message when the address is not this PC\'s own', { skip }, () => {
  const dir = mkdtempSync(join(tmpdir(), 'launcher-open-'));
  try {
    const out = join(dir, 'Start Smart Retail POS.exe');
    const run = (extra) => spawnSync(process.execPath, [join(repo, 'scripts', 'make-launcher.mjs'), '--out', out, '--name', 'Smart Retail POS', '--program', 'SmartRetail.Pos.Web.exe', ...extra], { encoding: 'utf8' });
    const good = run(['--open', 'http://127.0.0.1:5080', '--profile', 'smart-retail-pos-dashboard-window', '--helper', 'Start Smart Retail POS (with a window, for problems)', '--version', '2.18.0']);
    assert.equal(good.status, 0, good.stderr);
    assert.match(good.stdout, /^Wrote .*Start Smart Retail POS\.exe/);
    const exe = readFileSync(out);
    assert.ok(has(exe, '--app=http://127.0.0.1:5080') && has(exe, '2.18.0') && has(exe, 'SmartRetail.Pos.Web.exe'));
    const bad = run(['--open', 'http://shop.example.com:5080']);
    assert.equal(bad.status, 1);
    assert.match(bad.stderr, /must be this PC's own/);
    const typo = run(['--oopen', 'x']);
    assert.equal(typo.status, 2);
    assert.match(typo.stderr, /I do not know "--oopen"/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the dashboard\'s build script gives the launcher maker only settings it knows, and the whole set makes a launcher', { skip }, () => {
  const line = readFileSync(join(repo, 'apps', 'pos-dashboard-service', 'build.ps1'), 'utf8').split(/\r?\n/).find((l) => l.startsWith('node $launcherTool'));
  assert.ok(line, 'build.ps1 calls the launcher maker');
  const flags = [...line.matchAll(/ (--[a-z]+) /g)].map((m) => m[1]);
  for (const needed of ['--out', '--name', '--program', '--open', '--helper']) assert.ok(flags.includes(needed), `build.ps1 gives ${needed}`);
  const values = { '--out': 'x.exe', '--name': 'Smart Retail POS', '--program': 'SmartRetail.Pos.Web.exe', '--open': 'http://127.0.0.1:5080', '--wait': '90', '--profile': 'smart-retail-pos-dashboard-window', '--helper': 'Start Smart Retail POS (with a window, for problems)', '--version': '2.18.0' };
  const settings = parseArguments(flags.flatMap((f) => [f, values[f] ?? 'unknown flag']));
  const dir = mkdtempSync(join(tmpdir(), 'launcher-open-'));
  try {
    const exe = buildLauncher({ ...launcherOptions(settings), outFile: join(dir, 'Start Smart Retail POS.exe') });
    assert.ok(has(readFileSync(exe), 'did not start within 90 seconds'));
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('a launcher for a program that Windows starts (a service) only waits: it carries the words of its "starting" window, and a till gets the full-screen kind', () => {
  const waiting = launcherDefines({ ...base, open: { ...open, waitOnly: true, startingText: 'Smart Retail POS is starting.' } });
  assert.ok(waiting.includes('-DWAIT_ONLY=1'));
  assert.ok(waiting.includes('-DSTARTING_TEXT=Smart Retail POS is starting.'));
  assert.ok(!waiting.includes('-DKIOSK=1'));
  assert.ok(launcherDefines({ ...base, open: { ...open, waitOnly: true, kiosk: true } }).includes('-DKIOSK=1'));
  assert.ok(!launcherDefines({ ...base, open }).includes('-DWAIT_ONLY=1'), 'the launcher of the zip still starts its program');
  assert.throws(() => launcherDefines({ ...base, open: { ...open, startingText: 'x' } }), /only waits/);
  assert.throws(() => launcherDefines({ ...base, open: { ...open, waitOnly: true, startingText: 'a "quote"' } }), /no quote or line break/);
  assert.throws(() => launcherDefines({ ...base, open: { ...open, waitOnly: true, startingText: 'x'.repeat(121) } }), /1 to 120/);
});

test('the launcher program never opens the usual web browser: its script has no ExecShell on the address, and it says in words what to do when there is no Edge or Chrome', { skip }, () => {
  const script = readFileSync(LAUNCHER_SCRIPT, 'utf8');
  assert.ok(!/ExecShell\s+"open"\s+"\$\{OPEN_URL\}"/.test(script), 'the address is never handed to the usual browser');
  assert.match(script, /needs Microsoft Edge or Google Chrome/);
  const dir = mkdtempSync(join(tmpdir(), 'wait-launcher-'));
  try {
    const out = join(dir, 'Open.exe');
    buildLauncher({ outFile: out, name: 'Example', program: 'app\\run.exe', icon, open: { ...open, waitOnly: true, startingText: 'Example is starting.' } });
    const bytes = readFileSync(out);
    assert.ok(has(bytes, 'Example is starting.'), 'the words of the "starting" window are in the program');
    assert.ok(has(bytes, 'needs Microsoft Edge or Google Chrome'), 'and what to do when there is no such browser');
    assert.ok(!has(bytes, 'This installs'), 'nothing of a setup');
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

// ---- the icon of a program that is a Windows service: it switches the service on, and says what is wrong when it does not answer ------------------------------------------------

test('a launcher can be told the name of the Windows service it opens; only a plain name is taken, and only by a launcher that waits', () => {
  const waiting = { ...open, waitOnly: true };
  assert.ok(launcherDefines({ ...base, open: { ...waiting, service: 'NextGenOSHub' } }).includes('-DSERVICE_NAME=NextGenOSHub'));
  assert.ok(!launcherDefines({ ...base, open: waiting }).some((d) => d.startsWith('-DSERVICE_NAME')), 'no service named: the launcher does what it did before');
  for (const service of ['', '1abc', 'a b', 'a"b', 'a&b', 'a|b', 'x'.repeat(62), 5, '..\\x']) assert.throws(() => launcherDefines({ ...base, open: { ...waiting, service } }), /service name/, String(service));
  assert.throws(() => launcherDefines({ ...base, open: { ...open, service: 'NextGenOSHub' } }), /only waits/, 'a launcher that starts its program has no service');
});

test('the words that look at the PC (HubProblemNote.nsh) use only built-in Windows commands, hidden, write nothing but the note, and the launcher itself still runs nothing', () => {
  const dir = join(repo, 'scripts', 'launcher');
  const note = readFileSync(join(dir, 'HubProblemNote.nsh'), 'utf8').replace(/^\s*;.*$/gm, '');
  assert.ok(!/powershell|wscript|cscript|mshta|bitsadmin|certutil|curl|wget|\.vbs|\.ps1|\.bat\b/i.test(note), 'no script host and no download tool');
  const allowed = new Set(['sc.exe', 'cmd.exe', 'netstat', 'findstr', 'find', 'netsh', 'wevtutil.exe', 'type', 'date', 'time', 'ver', 'echo', 'echo.', 'notepad.exe']);
  // Every command named in a nsExec line or a note section is one of the built-in ones.
  const commands = [];
  for (const m of note.matchAll(/nsExec::\w+\s+'([^']+)'/g)) commands.push(m[1]);
  for (const m of note.matchAll(/HubNoteSection\s+"[^"]*"\s+(?:"([^"]+)"|'([^']+)')/g)) commands.push(m[1] ?? m[2]);
  assert.ok(commands.length >= 10, 'the note asks Windows several things');
  for (const text of commands) {
    for (const part of text.replace(/^cmd\.exe \/c /, '').replace(/2>&1/g, '').split(/\s*(?:&|\|)\s*/)) {
      const first = part.replace(/^\(+/, '').trim().split(/[\s>)]/)[0];
      if (first && !first.startsWith('${')) assert.ok(allowed.has(first), `"${first}" is not a built-in command the note may run (in: ${text})`);
    }
  }
  // It is hidden (nsExec) and writes only to the note.
  assert.ok(!/ExecWait|ExecShell|ExecShellWait/.test(note.replace(/Exec\s+'"\$R0" "\$R8"'/g, '')), 'nothing is run with a window except the note opened for reading');
  for (const m of note.matchAll(/FileOpen\s+\$\w+\s+"([^"]+)"/g)) assert.equal(m[1], '$R8', 'it writes to the note and nowhere else');
  assert.ok(!/RegWrite|WriteReg|DeleteReg|Delete\s|CopyFiles|Rename|RMDir|WriteINIStr/i.test(note), 'it changes nothing on the PC');
  // The sentences are plain: no jargon in what a shop owner reads.
  const sentences = [...note.matchAll(/StrCpy \$R7 "([^"]+)"/g)].map((m) => m[1]);
  assert.equal(sentences.length, 5, 'one sentence for each thing that can be wrong');
  for (const s of sentences) assert.ok(!/exception|stack|dll|registry|SCM|0x[0-9a-f]+/i.test(s), `plain words: ${s}`);
  // AppLauncher.nsi itself: still nothing run and nothing written (the helpers are the .nsh files).
  const launcher = readFileSync(LAUNCHER_SCRIPT, 'utf8').replace(/^\s*;.*$/gm, '');
  assert.ok(!/cmd\.exe|nsExec|powershell|wscript|cscript|mshta/i.test(launcher), 'the launcher script runs no command');
  for (const f of ['TcpAnswers.nsh', 'HubProblemNote.nsh']) assert.ok(!/powershell|wscript|cscript|mshta/i.test(readFileSync(join(dir, f), 'utf8')), `${f} runs no script host`);
});

test('the icon of the Business Hub asks Windows to switch the service on, gives up when it keeps switching itself off, and says in words what is wrong; the other icons do not', { skip }, () => {
  const dir = mkdtempSync(join(tmpdir(), 'service-launcher-'));
  try {
    const out = join(dir, 'Open.exe');
    buildLauncher({ outFile: out, name: 'Example', program: 'app\\run.exe', icon, open: { ...open, waitOnly: true, service: 'ExampleService', startingText: 'Example is starting.' } });
    const exe = readFileSync(out);
    for (const text of ['sc.exe start ExampleService', 'sc.exe query ExampleService', 'did not open.', 'is not installed correctly on this PC', 'is switched on but does not answer on this PC', 'is still starting', 'could not keep', 'is keeping the place (port',
      'problem-note.txt', 'NEXTGENOS_NOTE_VIEWER', 'wevtutil.exe', 'excludedportrange', 'hub-start.txt', 'Please send the note, or a picture of it, to the person who looks after your computers']) assert.ok(has(exe, text), `the icon says "${text}"`);
    assert.ok(!has(exe, 'has not started yet'), 'the vague message is gone from this icon');
    // An icon that names no service is the one it was before: it waits and says so, and runs nothing.
    const plain = join(dir, 'Plain.exe');
    buildLauncher({ outFile: plain, name: 'Example', program: 'app\\run.exe', icon, open: { ...open, waitOnly: true } });
    const p = readFileSync(plain);
    assert.ok(has(p, 'has not started yet'));
    for (const text of ['sc.exe', 'wevtutil', 'problem-note', 'NEXTGENOS_NOTE_VIEWER']) assert.ok(!has(p, text), `no "${text}" in an icon that names no service`);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the waiting for a service is timed by the clock, never by counting turns of a loop (Windows takes a second or two to refuse a connection, so a turn is not half a second)', () => {
  const launcher = readFileSync(LAUNCHER_SCRIPT, 'utf8').replace(/^\s*;.*$/gm, '');
  const setup = readFileSync(join(repo, 'apps', 'business-hub', 'installer', 'SmartRetailHub.nsi'), 'utf8').replace(/^\s*;.*$/gm, '');
  const loops = [['the icon', launcher.slice(launcher.indexOf('waiting:'), launcher.indexOf('waitfailed:'))], ['the setup', setup.slice(setup.indexOf('Function WaitForHub'), setup.indexOf('FunctionEnd', setup.indexOf('Function WaitForHub')))]];
  for (const [who, loop] of loops) {
    assert.ok(loop.length > 200, `${who}: the loop was found`);
    assert.match(loop, /GetTickCount/, `${who} reads the clock`);
    assert.ok(!/IntOp \$\d \$\d \+ 1\s+\$\{If\} \$\d (>=|>) (10|20|180)\b/.test(loop), `${who} must not count turns of the loop to know that ten seconds have passed`);
    assert.match(loop, /10000/, `${who} looks at the service every ten seconds by the clock`);
  }
});
