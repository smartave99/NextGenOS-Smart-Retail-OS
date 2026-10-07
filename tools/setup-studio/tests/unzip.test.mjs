// The Studio's zip reader: it opens what the Studio's own zip writer makes, and refuses a zip that tries to write outside its folder, holds a link, repeats a name, is damaged or is cut short.
import test from 'node:test';
import assert from 'node:assert/strict';
import { existsSync, mkdtempSync, readFileSync, rmSync, statSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { makeZip, writeZipFile } from '../lib/zip.mjs';
import { ZipError, extractZip, readEntries, safeEntryName } from '../lib/unzip.mjs';

const tmp = () => mkdtempSync(join(tmpdir(), 'unzip-test-'));
const clean = (...dirs) => { for (const d of dirs) rmSync(d, { recursive: true, force: true }); };

/** A zip with a name changed after it was written (the writer refuses bad names, so a hostile zip is made by hand: same length, so every offset stays right). */
function renamed(buffer, from, to) {
  assert.equal(from.length, to.length);
  const out = Buffer.from(buffer);
  let at = 0;
  for (;;) { at = out.indexOf(from, at); if (at < 0) break; out.write(to, at); at += to.length; }
  return out;
}

test('a zip the Studio wrote is opened as it was: names, contents, and the right to run', () => {
  const root = tmp();
  try {
    const zip = join(root, 'a.zip');
    writeFileSync(zip, makeZip([
      { name: 'site/start.sh', data: '#!/bin/sh\necho hi\n', mode: 0o755 },
      { name: 'site/app/data.json', data: JSON.stringify({ a: 1 }).repeat(200) },
      { name: 'site/empty.txt', data: '' },
    ]));
    const r = extractZip(zip, join(root, 'out'));
    assert.deepEqual(r.tops, ['site']);
    assert.equal(r.files, 3);
    assert.equal(readFileSync(join(root, 'out', 'site', 'app', 'data.json'), 'utf8'), JSON.stringify({ a: 1 }).repeat(200));
    assert.equal(readFileSync(join(root, 'out', 'site', 'empty.txt'), 'utf8'), '');
    if (process.platform !== 'win32') {
      assert.ok(statSync(join(root, 'out', 'site', 'start.sh')).mode & 0o100, 'the start file can be run');
      assert.ok(!(statSync(join(root, 'out', 'site', 'app', 'data.json')).mode & 0o111), 'a data file cannot');
    }
  } finally { clean(root); }
});

test('a big file written the streaming way (the way a package is zipped) is read back whole', async () => {
  const root = tmp();
  try {
    const big = join(root, 'big.bin');
    writeFileSync(big, Buffer.alloc(3_000_000, 7));
    const zip = join(root, 'b.zip');
    await writeZipFile(zip, [{ name: 'p/big.bin', file: big }, { name: 'p/note.txt', data: 'plain' }]);
    const r = extractZip(zip, join(root, 'out'));
    assert.equal(r.files, 2);
    assert.ok(readFileSync(join(root, 'out', 'p', 'big.bin')).equals(Buffer.alloc(3_000_000, 7)));
    assert.deepEqual(readEntries(zip).map((e) => e.name), ['p/big.bin', 'p/note.txt']);
  } finally { clean(root); }
});

test('names that try to leave the folder are refused before anything is written', () => {
  const root = tmp();
  try {
    for (const hostile of ['../evil.txt', '..\\evil.txt', '/evil/txt.txt', 'C:/evil/txt.tx', 'x/../../e.txt']) {
      const placeholder = 'q'.repeat(hostile.length);
      const zip = join(root, 'evil.zip');
      writeFileSync(zip, renamed(Buffer.from(makeZip([{ name: placeholder, data: 'payload' }])), placeholder, hostile));
      assert.throws(() => extractZip(zip, join(root, 'out')), ZipError, hostile);
      assert.ok(!existsSync(join(root, 'out', 'evil.txt')) && !existsSync(join(root, 'evil.txt')), hostile);
    }
    for (const bad of ['../x', 'a/../b', '/abs', 'C:\\x', 'a\\b', 'a\0b', '']) assert.throws(() => safeEntryName(bad), ZipError, JSON.stringify(bad));
    assert.equal(safeEntryName('site/app/file.js'), 'site/app/file.js');
  } finally { clean(root); }
});

test('a link, a name used twice, a locked file, a damaged file and a cut-short zip are refused', () => {
  const root = tmp();
  try {
    const zip = join(root, 'z.zip');
    const good = makeZip([{ name: 'site/a.txt', data: 'hello hello hello hello' }, { name: 'site/b.txt', data: 'second' }]);

    // a link: the file's type bits in the zip's list say "symbolic link"
    const link = Buffer.from(good);
    const first = link.indexOf(Buffer.from([0x50, 0x4b, 0x01, 0x02]));
    link.writeUInt32LE(((0o120000 | 0o777) << 16) >>> 0, first + 38);
    writeFileSync(zip, link);
    assert.throws(() => extractZip(zip, join(root, 'o1')), /holds a link/);

    writeFileSync(zip, makeZip([{ name: 'site/a.txt', data: 'one' }, { name: 'SITE/A.txt', data: 'two' }]));
    assert.throws(() => extractZip(zip, join(root, 'o2')), /twice/);

    const locked = Buffer.from(good);
    locked.writeUInt16LE(locked.readUInt16LE(first + 8) | 1, first + 8);
    writeFileSync(zip, locked);
    assert.throws(() => extractZip(zip, join(root, 'o3')), /password/);

    // a file whose bytes were changed after the zip was made no longer matches its fingerprint
    const damaged = Buffer.from(good);
    const at = damaged.indexOf('second');
    damaged.write('SECOND', at);
    writeFileSync(zip, damaged);
    assert.throws(() => extractZip(zip, join(root, 'o4')), /does not match its fingerprint/);

    writeFileSync(zip, good.subarray(0, good.length - 40));
    assert.throws(() => extractZip(zip, join(root, 'o5')), ZipError);
    writeFileSync(zip, 'this is not a zip at all');
    assert.throws(() => extractZip(zip, join(root, 'o6')), /not a zip/);
  } finally { clean(root); }
});
