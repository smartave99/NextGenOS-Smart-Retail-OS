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
