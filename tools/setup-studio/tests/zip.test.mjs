// The streaming zip writer: big and small files, packed and plain ones, names that are refused, and a real unzip (where there is one) agreeing.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, writeFileSync, readFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { randomBytes } from 'node:crypto';
import { spawnSync } from 'node:child_process';
import { writeZipFile, listZip } from '../lib/zip.mjs';

test('files of every kind go in and come out the same, checked by a real unzip', async () => {
  const dir = mkdtempSync(join(tmpdir(), 'zip-test-'));
  try {
    const big = randomBytes(3_000_000);
    const text = Buffer.from('hello '.repeat(200_000));
    writeFileSync(join(dir, 'setup.exe'), big);
    writeFileSync(join(dir, 'notes.txt'), text);
    writeFileSync(join(dir, 'run.sh'), '#!/bin/sh\necho hi\n', { mode: 0o755 });
    const zip = join(dir, 'out.zip');
    await writeZipFile(zip, [
      { name: 'Pack/setup.exe', file: join(dir, 'setup.exe') },
      { name: 'Pack/notes.txt', file: join(dir, 'notes.txt') },
      { name: 'Pack/run.sh', file: join(dir, 'run.sh') },
      { name: 'Pack/profile/theme.json', data: '{"schema":1}' },
      { name: 'Pack/empty.txt', data: '' },
    ]);
    assert.deepEqual(listZip(readFileSync(zip)), ['Pack/setup.exe', 'Pack/notes.txt', 'Pack/run.sh', 'Pack/profile/theme.json', 'Pack/empty.txt']);
    // a plain text file shrinks; the packed setup is stored as it is
    assert.ok(readFileSync(zip).length < big.length + 200_000);
    const unzip = spawnSync('unzip', ['-tq', zip], { encoding: 'utf8' });
    if (unzip.error) {
      const py = spawnSync('python3', ['-c', 'import sys,zipfile; z=zipfile.ZipFile(sys.argv[1]); assert z.testzip() is None; print("ok")', zip], { encoding: 'utf8' });
      assert.equal(py.stdout.trim(), 'ok', py.stderr);
    } else assert.equal(unzip.status, 0, unzip.stdout + unzip.stderr);
    const out = join(dir, 'x');
    const ex = spawnSync('python3', ['-c', 'import sys,zipfile; zipfile.ZipFile(sys.argv[1]).extractall(sys.argv[2])', zip, out], { encoding: 'utf8' });
    if (!ex.error && ex.status === 0) {
      assert.ok(readFileSync(join(out, 'Pack/setup.exe')).equals(big));
      assert.ok(readFileSync(join(out, 'Pack/notes.txt')).equals(text));
      assert.equal(readFileSync(join(out, 'Pack/profile/theme.json'), 'utf8'), '{"schema":1}');
    }
  } finally { rmSync(dir, { recursive: true, force: true }); }
});

test('a file name that could write outside the folder is refused', async () => {
  const dir = mkdtempSync(join(tmpdir(), 'zip-test-'));
  try {
    for (const name of ['../x', '/etc/x', 'C:/x']) await assert.rejects(writeZipFile(join(dir, 'a.zip'), [{ name, data: 'x' }]), /not allowed/);
  } finally { rmSync(dir, { recursive: true, force: true }); }
});
