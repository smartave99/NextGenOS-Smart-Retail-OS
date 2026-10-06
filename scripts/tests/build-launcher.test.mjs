// The small Windows launcher of a program: a window program (so no black terminal opens), with the program's name, icon and what it starts, and it refuses what could break the script.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, readFileSync, rmSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { buildLauncher, findMakensis } from '../lib/build-launcher.mjs';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const skip = spawnSync('makensis', ['-VERSION']).error ? 'makensis (NSIS) is not installed here' : false;
const base = { name: 'Example Program', program: 'node\\node.exe', args: 'start.js --app', icon: join(repo, 'scripts', 'launcher', 'product.ico') };

test('the launcher is a window program that starts the program hidden with what it is told', { skip }, () => {
  const dir = mkdtempSync(join(tmpdir(), 'launcher-'));
  try {
    const out = join(dir, 'Start Example.exe');
    buildLauncher({ ...base, outFile: out, workdir: 'app', check: 'app\\start.js', version: '2.3.4' });
    const exe = readFileSync(out);
    assert.equal(exe.subarray(0, 2).toString('latin1'), 'MZ');
    const pe = exe.readUInt32LE(0x3c);
    assert.equal(exe.readUInt16LE(pe + 24 + 68), 2, 'a window program (subsystem 2): no black window opens');
    const has = (text) => exe.includes(Buffer.from(text, 'utf16le'));
    assert.ok(has('start.js --app'), 'what it gives the program');
    assert.ok(has('node\\node.exe'), 'the program it starts');
    assert.ok(has('app\\start.js'), 'the file it checks first');
    assert.ok(has('Example Program'));
    assert.ok(has('2.3.4'));
    assert.ok(has('Unpack the whole zip file'), 'it says in plain words what to do when the files are not all there');
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('it will not make a launcher from a name or a path that could change the script', { skip }, () => {
  const dir = mkdtempSync(join(tmpdir(), 'launcher-'));
  try {
    const out = join(dir, 'x.exe');
    assert.throws(() => buildLauncher({ ...base, outFile: out, name: 'Bad" Name' }), /name .*quote or a line break/);
    assert.throws(() => buildLauncher({ ...base, outFile: out, args: 'a\nb' }), /args .*quote or a line break/);
    assert.throws(() => buildLauncher({ ...base, outFile: out, program: '' }), /program is missing/);
    assert.throws(() => buildLauncher({ ...base, outFile: out, version: '1.0' }), /three numbers/);
    assert.throws(() => buildLauncher({ ...base, outFile: out, icon: join(dir, 'no.ico') }), /icon file is not there/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('without NSIS it says in plain words what to install, and it finds NSIS where Windows puts it', () => {
  assert.throws(() => buildLauncher({ ...base, outFile: join(tmpdir(), 'x.exe'), makensis: null }), /needs NSIS \(makensis\)/);
  const found = findMakensis({ platform: 'win32', env: { 'ProgramFiles(x86)': 'C:\\Program Files (x86)' }, exists: (p) => p === 'C:\\Program Files (x86)\\NSIS\\makensis.exe', run: () => ({ error: new Error('not on the path') }) });
  assert.equal(found, 'C:\\Program Files (x86)\\NSIS\\makensis.exe');
  assert.equal(findMakensis({ platform: 'linux', env: {}, exists: () => false, run: () => ({ error: new Error('no') }) }), null);
});
