// The programs folder (the kit): the checks on its files, and the quick look the screens use so that opening a page does not read every installer again.
import { test } from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, rmSync, utimesSync, writeFileSync, readFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { pick, readBaseKit } from '../lib/basekit.mjs';
import { makeKit } from './website-stand-in.mjs';

test('the website program is found in the kit by its role and its system, and a kit without it still reads', async () => {
  const root = mkdtempSync(join(tmpdir(), 'studio-kit-'));
  try {
    const kit = await readBaseKit(await makeKit(root, { name: 'both' }));
    assert.equal(kit.ok, true);
    assert.deepEqual(pick(kit, 'website-generic').map((f) => [f.name, f.os, f.arch]).sort(), [['website-linux.zip', 'linux', 'x64'], ['website-windows.zip', 'windows', 'x64']]);
    assert.deepEqual(pick(kit, 'website-generic', { os: 'linux' }).map((f) => f.name), ['website-linux.zip']);
    assert.deepEqual(pick(kit, 'website', { kit: 'anyone' }), [], 'a website made for one customer is another role');
    const bare = await readBaseKit(await makeKit(root, { name: 'bare', websites: [] }));
    assert.equal(bare.ok, true);
    assert.deepEqual(pick(bare, 'website-generic'), []);
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('a quick look trusts a file whose size and time are unchanged; a full read never does, and a changed file is noticed either way', async () => {
  const root = mkdtempSync(join(tmpdir(), 'studio-kit-'));
  try {
    const dir = await makeKit(root, { name: 'kit', websites: ['linux'] });
    const file = join(dir, 'website-linux.zip');
    const stamp = new Date('2026-10-01T10:00:00Z');   // a whole second, so the time can be put back exactly
    utimesSync(file, stamp, stamp);
    assert.equal((await readBaseKit(dir)).ok, true, 'a full read');
    // the same size, other content, the time put back: only a full read can tell
    const bytes = readFileSync(file);
    bytes[bytes.length - 50] ^= 0xff;
    writeFileSync(file, bytes);
    utimesSync(file, stamp, stamp);
    assert.equal((await readBaseKit(dir, { quick: true })).ok, true, 'a screen that only looks is quick');
    const full = await readBaseKit(dir);
    assert.equal(full.ok, false);
    assert.match(full.problems[0], /website-linux\.zip does not match its fingerprint/);
    // after a full read that found the file wrong, a quick look no longer trusts it
    assert.equal((await readBaseKit(dir, { quick: true })).ok, false);
    // a file that is changed in the usual way (its time moves) is noticed by a quick look too
    writeFileSync(file, Buffer.concat([bytes, Buffer.from('more')]));
    assert.match((await readBaseKit(dir, { quick: true })).problems[0], /not the file that was released/);
    writeFileSync(file, bytes);
    utimesSync(file, new Date(Date.now() + 5000), new Date(Date.now() + 5000));
    assert.equal((await readBaseKit(dir, { quick: true })).ok, false);
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('a folder that is not a kit says so in plain words', async () => {
  const root = mkdtempSync(join(tmpdir(), 'studio-kit-'));
  try {
    assert.match((await readBaseKit(join(root, 'nowhere'))).problems[0], /folder was not found/);
    assert.match((await readBaseKit(root)).problems[0], /base-kit\.json is not in that folder/);
    writeFileSync(join(root, 'base-kit.json'), '{ nope');
    assert.match((await readBaseKit(root)).problems[0], /cannot be read/);
    writeFileSync(join(root, 'base-kit.json'), JSON.stringify({ schema: 1, version: '1.0.0', files: [{ name: '../escape.exe', role: 'hub-windows-setup', bytes: 1, sha256: 'a'.repeat(64) }] }));
    assert.match((await readBaseKit(root)).problems[0], /name that is not allowed/);
  } finally { rmSync(root, { recursive: true, force: true }); }
});
