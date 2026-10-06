// The Debian package writer: what it makes can be read back, and a real dpkg (where there is one) accepts it.
import test from 'node:test';
import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import { mkdtempSync, writeFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { spawnSync } from 'node:child_process';
import { makeDeb, readDeb } from '../lib/deb.mjs';

const control = { Package: 'smart-retail-profile-acme', Version: '1.0.3', Architecture: 'all', Maintainer: 'NextGenOS <help@example.org>', Description: 'Prepared set-up for Acme\nOnly data.\n\nSecond paragraph.' };
const files = [
  { name: 'opt/nextgenos/smart-retail-hub/profile/setup.json', data: '{"schema":1}' },
  { name: 'opt/nextgenos/smart-retail-hub/profile/theme.json', data: Buffer.from('{"schema":1}') },
  { name: 'etc/xdg/autostart/smart-retail-pos-fullscreen.desktop', data: '[Desktop Entry]\nType=Application\n', mode: 0o644 },
];

test('a package can be read back: its fields, its scripts and every file with its fingerprint', () => {
  const deb = makeDeb({ control, files, scripts: { postinst: '#!/bin/sh\nexit 0\n' } });
  const back = readDeb(deb);
  assert.match(back.control, /^Package: smart-retail-profile-acme\nVersion: 1\.0\.3\nArchitecture: all\n/);
  assert.match(back.control, /Installed-Size: 1\n/);
  assert.match(back.control, /\nDescription: Prepared set-up for Acme\n Only data\.\n \.\n Second paragraph\.\n$/);
  assert.equal(back.scripts.postinst, '#!/bin/sh\nexit 0\n');
  assert.deepEqual(back.files.map((f) => f.name), files.map((f) => f.name));
  assert.equal(back.files[0].data.toString(), '{"schema":1}');
  for (const f of back.files) assert.ok(back.md5sums.includes(`${createHash('md5').update(f.data).digest('hex')}  ${f.name}`));
  assert.equal(back.files[0].mode, 0o644);
});

test('the same input makes the same package, byte for byte', () => {
  const when = new Date('2026-01-02T03:04:05Z');
  assert.ok(makeDeb({ control, files, when }).equals(makeDeb({ control, files, when })));
});

test('a name with .. or a slash at the start, a bad package name, a bad version and a bad system are refused', () => {
  for (const name of ['../x', '/etc/x', 'a//b', 'a/../b']) assert.throws(() => makeDeb({ control, files: [{ name, data: 'x' }] }), /not allowed/);
  assert.throws(() => makeDeb({ control: { ...control, Package: 'Bad Name' }, files }), /package name/);
  assert.throws(() => makeDeb({ control: { ...control, Version: 'x1' }, files }), /version/);
  assert.throws(() => makeDeb({ control: { ...control, Architecture: 'sparc' }, files }), /system/);
});

test('a very long path is split the way tar wants it, and still reads back whole', () => {
  const name = 'opt/' + 'folder-with-a-long-name/'.repeat(6) + 'file.txt';
  assert.ok(name.length > 100);
  const back = readDeb(makeDeb({ control, files: [{ name, data: 'x' }] }));
  assert.equal(back.files[0].name, name);
  assert.throws(() => makeDeb({ control, files: [{ name: 'a'.repeat(300), data: 'x' }] }), /too long/);
});

test('a line break in a field cannot add a second field', () => {
  const back = readDeb(makeDeb({ control: { ...control, Maintainer: 'A\nDepends: evil' }, files }));
  assert.ok(!/^Depends:/m.test(back.control));
});

test('a real dpkg, where this PC has one, opens it and lists the same files', () => {
  const have = spawnSync('dpkg-deb', ['--version'], { encoding: 'utf8' });
  if (have.status !== 0) { assert.ok(true, 'no dpkg here: the package was checked by reading it back'); return; }
  const dir = mkdtempSync(join(tmpdir(), 'deb-test-'));
  try {
    const path = join(dir, 'p.deb');
    writeFileSync(path, makeDeb({ control, files, scripts: { postinst: '#!/bin/sh\nexit 0\n' } }));
    const info = spawnSync('dpkg-deb', ['--info', path], { encoding: 'utf8' });
    assert.equal(info.status, 0, info.stderr);
    assert.match(info.stdout, /Package: smart-retail-profile-acme/);
    const list = spawnSync('dpkg-deb', ['-c', path], { encoding: 'utf8' });
    assert.equal(list.status, 0, list.stderr);
    for (const f of files) assert.ok(list.stdout.includes('./' + f.name), f.name);
    const field = spawnSync('dpkg-deb', ['-f', path, 'Version'], { encoding: 'utf8' });
    assert.equal(field.stdout.trim(), '1.0.3');
  } finally { rmSync(dir, { recursive: true, force: true }); }
});
