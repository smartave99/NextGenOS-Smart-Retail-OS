// The tag of a Setup Studio release must name the version the Studio really has.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, writeFileSync, rmSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const script = join(repo, 'scripts', 'check-studio-version.mjs');

function check(tag, version) {
  const dir = mkdtempSync(join(tmpdir(), 'studio-version-'));
  try {
    const pkg = join(dir, 'package.json');
    writeFileSync(pkg, JSON.stringify({ name: 'x', version }));
    const r = spawnSync(process.execPath, [script, tag, '--package', pkg], { encoding: 'utf8' });
    return { status: r.status, out: r.stdout, err: r.stderr };
  } finally { rmSync(dir, { recursive: true, force: true }); }
}

test('a tag with the Studio\'s own number passes, with or without a candidate suffix', () => {
  for (const tag of ['studio-v1.0.0', 'studio-v1.0.0-rc1', 'studio-v1.0.0-beta2', 'studio-v1.0.0-alpha1']) {
    const r = check(tag, '1.0.0');
    assert.equal(r.status, 0, tag + ' ' + r.err);
    assert.match(r.out, /matches the Setup Studio version 1\.0\.0/);
  }
});

test('another number is refused and says which two numbers differ', () => {
  const r = check('studio-v1.2.0', '1.0.0');
  assert.equal(r.status, 1);
  assert.match(r.err, /says version 1\.2\.0, but the Setup Studio in this code is version 1\.0\.0/);
});

test('a tag that is not a Studio tag is refused with the right way to write one', () => {
  for (const tag of ['v1.0.0', 'studio-1.0.0', 'studio-v1.0', 'studio-v1.0.0-final', 'studio-v1.0.0-rc', '']) {
    const r = check(tag, '1.0.0');
    assert.equal(r.status, 1, tag);
    assert.match(r.err, /is not a Setup Studio release tag/);
  }
});

test('the real Studio in this repository has a version the tag checker can use', () => {
  const r = spawnSync(process.execPath, [script, 'studio-v0.0.0'], { encoding: 'utf8' });
  assert.equal(r.status, 1);
  assert.match(r.stderr, /the Setup Studio in this code is version \d+\.\d+\.\d+/);
});
