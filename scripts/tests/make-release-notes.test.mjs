// The release page: it tells a person what to download and what to do with it, names only the files that were really built, and says what was not built.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, mkdirSync, writeFileSync, rmSync, readFileSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const script = join(repo, 'scripts', 'make-release-notes.mjs');
const template = join(repo, '.github', 'release-notes.md');

const FULL = [
  'SmartRetailPOS-Hub-Setup-1.0.0.exe', 'SmartRetailPOS-Hub-1.0.0-win-x64.zip',
  'smart-retail-pos-hub_1.0.0-1_amd64.deb', 'smart-retail-pos-hub_1.0.0-1_arm64.deb',
  'website-example-shop-windows.zip', 'website-example-shop-linux.zip',
  'SmartRetailPOS-example-shop-1.0.0.apk', 'SmartRetailPOS-example-shop-1.0.0.aab',
  'NextGenOS-Setup-Studio-1.0.0-windows.zip', 'NextGenOS-Setup-Studio-1.0.0-linux.zip',
  'HOW-TO-TRY.txt', 'SHA256SUMS.txt', 'base-kit.json',
];

function folder(files, extra = {}) {
  const dir = mkdtempSync(join(tmpdir(), 'notes-'));
  mkdirSync(dir, { recursive: true });
  for (const f of files) writeFileSync(join(dir, f), 'x'.repeat(2048));
  for (const [name, text] of Object.entries(extra)) writeFileSync(join(dir, name), text);
  return dir;
}

function notes(dir, args = []) {
  const r = spawnSync(process.execPath, [script, '--dist', dir, '--commit', 'abc1234def', '--tag', 'v1.0.0-trial7', ...args], { encoding: 'utf8' });
  return { status: r.status, out: r.stdout, err: r.stderr };
}

const STATUS = 'Release gate: success\nWindows setup for the Business Hub: built success, tried on a Windows PC success\nLinux packages for the Business Hub: success\nAndroid app: success\nSetup Studio for staff: success\nWebsite for the customer (Linux and Windows): success\n';

test('a full release: every program has its steps, with the real file names', () => {
  const dir = folder(FULL, { 'BUILD-STATUS.txt': STATUS, 'WINDOWS-SIGNING.txt': 'NOT signed', 'ANDROID-SIGNING.txt': 'Signed with: one-off TEST key' });
  try {
    const { status, out } = notes(dir);
    assert.equal(status, 0);
    assert.match(out, /### Start here: what do you want to try\?/);
    assert.match(out, /Download `SmartRetailPOS-Hub-Setup-1\.0\.0\.exe`/);
    assert.match(out, /sudo apt install \.\/smart-retail-pos-hub_1\.0\.0-1_amd64\.deb/);
    assert.match(out, /double-click \*\*Start Website\*\*/);
    assert.doesNotMatch(out, /Start Website\.bat/, 'the website opens from its icon, not from a script that shows a terminal');
    assert.match(out, /\.\/start-website\.sh --app/);
    assert.match(out, /To stop it, close its window/);
    assert.doesNotMatch(out, /127\.0\.0\.1:5280/, 'the Hub opens from its icon: nobody is asked to type an address');
    assert.match(out, /closing the window does not stop it/, 'the Hub keeps running in the background');
    assert.match(out, /double-click \*\*Setup Studio\*\*/);
    assert.doesNotMatch(out, /Setup Studio\.bat/, 'the Studio opens from its icon, not from a script that shows a terminal');
    assert.match(out, /There is no black terminal window/);
    assert.match(out, /\.\/setup-studio\.sh/);
    assert.match(out, /--install-menu/);
    assert.match(out, /unknown publisher/, 'an unsigned setup warns about the warning Windows will show');
    assert.match(out, /one-off TEST key/);
    assert.doesNotMatch(out, /### Not in this release/);
    assert.doesNotMatch(out, /\{\{|\}\}/, 'every place of the template is filled');
    assert.match(out, /Version 1\.0\.0|version 1\.0\.0/);
    assert.match(out, /Built from abc1234def/);
    assert.match(out, /Release gate: success/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('a part that was not built is named as missing, not described as if it were there', () => {
  const partial = FULL.filter((f) => !/\.exe$|\.apk$|\.aab$|Hub-1\.0\.0-win/.test(f));
  const dir = folder(partial, { 'BUILD-STATUS.txt': STATUS.replace('built success, tried on a Windows PC success', 'built failure, tried on a Windows PC skipped').replace('Android app: success', 'Android app: failure') });
  try {
    const { status, out } = notes(dir);
    assert.equal(status, 0);
    assert.match(out, /### Not in this release/);
    assert.match(out, /The shop program for Windows \(the setup\)\.\*\* Status: Windows setup for the Business Hub: built failure/);
    assert.match(out, /The Android app\.\*\* Status: Android app: failure/);
    assert.doesNotMatch(out, /SmartRetailPOS-Hub-Setup/, 'a setup that was not built is not offered');
    assert.doesNotMatch(out, /#### The Android app/);
    assert.match(out, /#### The shop program on Linux/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('a trial says so at the top and says what the right result looks like; a real release does not', () => {
  const trial = folder(FULL, { 'NO-LICENCE-KEYS-TRIAL-ONLY.txt': 'trial' });
  const real = folder(FULL);
  try {
    const t = notes(trial).out;
    assert.match(t, /^> \*\*TRIAL BUILD, NO LICENCE KEYS\./);
    assert.match(t, /needs a licence/);
    const r = notes(real).out;
    assert.doesNotMatch(r, /TRIAL BUILD/);
    assert.match(r, /type the key NextGenOS gave you/);
  } finally { rmSync(trial, { recursive: true, force: true }); rmSync(real, { recursive: true, force: true }); }
});

test('a signed setup is described as signed', () => {
  const dir = folder(FULL, { 'WINDOWS-SIGNING.txt': 'Signed with the owner certificate' });
  try {
    const out = notes(dir).out;
    assert.doesNotMatch(out, /unknown publisher/);
    assert.match(out, /publisher's name/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('no customer is named unless the file names say so: the example release names none, another kit shows its own name', () => {
  const example = folder(FULL);
  const other = folder(FULL.map((f) => f.replace('example-shop', 'luzon-fresh-mart')));
  try {
    const a = notes(example).out;
    assert.doesNotMatch(a, /smart.?avenue/i);
    assert.match(a, /shop\.example\.com/, 'the example app says its address is a placeholder');
    const b = notes(other).out;
    assert.match(b, /luzon-fresh-mart/);
    assert.doesNotMatch(b, /shop\.example\.com/);
  } finally { rmSync(example, { recursive: true, force: true }); rmSync(other, { recursive: true, force: true }); }
});

test('the list of all files names every file with its size and what it is, and the page is the same for the same files', () => {
  const dir = folder([...FULL, 'surprise.bin']);
  try {
    const a = notes(dir).out;
    const b = notes(dir).out;
    assert.equal(a, b);
    for (const f of [...FULL, 'surprise.bin']) assert.ok(a.includes('`' + f + '`'), `${f} is in the list`);
    assert.match(a, /\| `surprise\.bin` \| 2 KB \| Other file of this release\. \|/);
    assert.match(a, /<details>/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('a template with a place the program does not know, or a missing folder, stops with a clear message', () => {
  const dir = folder(FULL);
  const bad = join(dir, 'bad-template.md');
  writeFileSync(bad, 'Hello {{NOT_A_PLACE}}\n');
  try {
    const r = notes(dir, ['--template', bad]);
    assert.equal(r.status, 1);
    assert.match(r.err, /NOT_A_PLACE/);
    const none = spawnSync(process.execPath, [script, '--dist', join(dir, 'nowhere')], { encoding: 'utf8' });
    assert.equal(none.status, 2);
    assert.match(none.stderr, /Usage/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the real template has every place the program fills, and no other', () => {
  const text = readFileSync(template, 'utf8');
  const used = new Set([...text.matchAll(/\{\{([A-Z_]+)\}\}/g)].map((m) => m[1]));
  for (const p of ['TRIAL_BANNER', 'VERSION', 'CHANGELOG', 'START_HERE', 'MISSING', 'ALL_FILES', 'STATUS', 'COMMIT']) assert.ok(used.has(p), `${p} is in the template`);
  assert.equal(used.size, 8);
});

// ---- a release of the Setup Studio alone (a tag such as studio-v1.0.0) ----------------------------------------------------------------------
const STUDIO_FILES = ['NextGenOS-Setup-Studio-1.0.0-windows.zip', 'NextGenOS-Setup-Studio-1.0.0-linux.zip', 'SHA256SUMS.txt'];
const STUDIO_STATUS = 'Release gate: success (every check of scripts/verify-all.mjs --full)\nSetup Studio for staff: success\nSetup Studio opened on a Windows PC: success\n';

function studioNotes(dir, args = []) {
  const r = spawnSync(process.execPath, [script, '--dist', dir, '--commit', 'abc1234def', '--tag', 'studio-v1.0.0-rc1', '--only', 'studio', ...args], { encoding: 'utf8' });
  return { status: r.status, out: r.stdout, err: r.stderr };
}

test('a Studio release page speaks only of the Studio: its steps, what it needs, no shop program, website or app', () => {
  const dir = folder(STUDIO_FILES, { 'BUILD-STATUS.txt': STUDIO_STATUS });
  try {
    const { status, out } = studioNotes(dir);
    assert.equal(status, 0);
    assert.match(out, /^\*\*NextGenOS Setup Studio\*\*, version 1\.0\.0/);
    assert.match(out, /never give it to a customer/);
    assert.match(out, /\| The Setup Studio \(NextGenOS staff only\) \| `NextGenOS-Setup-Studio-1\.0\.0-linux\.zip`<br>`NextGenOS-Setup-Studio-1\.0\.0-windows\.zip` \|/);
    assert.match(out, /double-click \*\*Setup Studio\*\*/);
    assert.match(out, /There is no black terminal window/);
    assert.match(out, /closing the window|close its window/i);
    assert.match(out, /This release holds only the Studio/, 'it says where the programs for a customer come from');
    assert.match(out, /full release/);
    for (const other of [/The shop program on/, /The online shop \(website\)/, /The Android app/, /Download `SmartRetailPOS/, /sudo apt install/, /HOW-TO-TRY/, /licence key from the NextGenOS Licence Studio\. Nothing in this release works/]) {
      assert.doesNotMatch(out, other, String(other));
    }
    assert.doesNotMatch(out, /### Not in this release/, 'the other parts are not expected in a Studio release, so they are not listed as missing');
    assert.doesNotMatch(out, /TRIAL BUILD/);
    assert.doesNotMatch(out, /\{\{|\}\}/);
    assert.match(out, /Setup Studio opened on a Windows PC: success/);
    assert.match(out, /Built from abc1234def/);
    assert.doesNotMatch(out, /smart.?avenue/i);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('a Studio release without its Linux file names only that file as missing', () => {
  const dir = folder(STUDIO_FILES.filter((f) => !/linux/.test(f)), { 'BUILD-STATUS.txt': STUDIO_STATUS.replace('Setup Studio for staff: success', 'Setup Studio for staff: failure') });
  try {
    const { status, out } = studioNotes(dir);
    assert.equal(status, 0);
    assert.match(out, /### Not in this release/);
    assert.match(out, /- \*\*The Setup Studio for Linux\.\*\* Status: Setup Studio for staff: failure/);
    assert.doesNotMatch(out, /Setup Studio for Windows\.\*\*/);
    assert.doesNotMatch(out, /shop program for/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the version on a Studio page is the Studio\'s own, even when the tag says something else is coming', () => {
  const dir = folder(STUDIO_FILES, { 'BUILD-STATUS.txt': STUDIO_STATUS });
  try {
    assert.match(studioNotes(dir, ['--tag', 'studio-v1.0.0']).out, /version 1\.0\.0, part of/);
    assert.match(studioNotes(dir, ['--version', '1.0.0']).out, /version 1\.0\.0, part of/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('only the Studio can be asked for alone', () => {
  const dir = folder(STUDIO_FILES);
  try {
    const spawned = spawnSync(process.execPath, [script, '--dist', dir, '--commit', 'abc1234def', '--only', 'hub'], { encoding: 'utf8' });
    const r = { status: spawned.status, err: spawned.stderr };
    assert.equal(r.status, 1);
    assert.match(r.err, /--only can be "studio", not "hub"/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('the Studio template has every place the program fills, and no other', () => {
  const text = readFileSync(join(repo, '.github', 'release-notes-studio.md'), 'utf8');
  const used = new Set([...text.matchAll(/\{\{([A-Z_]+)\}\}/g)].map((m) => m[1]));
  for (const p of ['VERSION', 'CHANGELOG', 'START_HERE', 'MISSING', 'ALL_FILES', 'STATUS', 'COMMIT']) assert.ok(used.has(p), `${p} is in the template`);
  assert.ok(!used.has('TRIAL_BANNER'), 'a Studio release is never a trial without keys: it holds no keys at all');
  assert.equal(used.size, 7);
});

test('a Studio release with a Windows installer has installer steps and changelog', () => {
  const filesWithInstaller = [...STUDIO_FILES, 'NextGenOS-Setup-Studio-Setup-1.0.0.exe'];
  const dir = folder(filesWithInstaller, { 'BUILD-STATUS.txt': STUDIO_STATUS });
  try {
    const { status, out } = studioNotes(dir);
    assert.equal(status, 0);
    assert.match(out, /### What changed in this version \(Change log\)/);
    assert.match(out, /Download \*\*`NextGenOS-Setup-Studio-Setup-1\.0\.0\.exe`\*\*/);
    assert.match(out, /Windows 1-click installer/);
    assert.match(out, /\| The Setup Studio for Windows \(1-click installer\) \| `NextGenOS-Setup-Studio-Setup-1\.0\.0\.exe` \|/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});
