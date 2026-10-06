// The history scan finds a secret that was committed and later deleted, says where (never the value), and passes a clean history.
import { test } from 'node:test';
import assert from 'node:assert/strict';
import { spawnSync } from 'node:child_process';
import { mkdtempSync, writeFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { scanHistory } from '../scan-history.mjs';

const script = join(dirname(fileURLToPath(import.meta.url)), '..', 'scan-history.mjs');
const repo = () => {
  const dir = mkdtempSync(join(tmpdir(), 'scan-history-'));
  const git = (...a) => { const r = spawnSync('git', ['-C', dir, '-c', 'user.name=t', '-c', 'user.email=t@example.invalid', '-c', 'commit.gpgsign=false', ...a], { encoding: 'utf8' }); assert.equal(r.status, 0, r.stderr); return r.stdout; };
  git('init', '-q');
  return { dir, git, commit: (file, text, msg) => { writeFileSync(join(dir, file), text); git('add', '-A'); git('commit', '-q', '-m', msg); } };
};
// Built from pieces so this test file does not itself hold a secret-looking line.
const fakeKey = () => ['sk', 'proj', 'A1b2C3d4E5f6G7h8I9j0K1l2M3n4'].join('-');

test('a secret that was committed and then deleted is found, with its place and not its value', async () => {
  const r = repo();
  try {
    r.commit('a.txt', 'nothing here\n', 'first');
    r.commit('config.txt', `key=${fakeKey()}\n`, 'oops');
    r.commit('config.txt', 'key=\n', 'removed again');
    const found = await scanHistory(r.dir);
    assert.equal(found.hits.length, 1);
    assert.equal(found.hits[0].file, 'config.txt');
    assert.ok(!JSON.stringify(found).includes('A1b2C3d4'), 'the value is never reported');
    const cli = spawnSync('node', [script, '--root', r.dir], { encoding: 'utf8' });
    assert.equal(cli.status, 1);
    assert.ok(!cli.stdout.includes('A1b2C3d4'));
  } finally { rmSync(r.dir, { recursive: true, force: true }); }
});

test('a clean history passes', async () => {
  const r = repo();
  try {
    r.commit('a.txt', 'hello\n', 'first');
    r.commit('b.txt', 'password=\n', 'second');
    const found = await scanHistory(r.dir);
    assert.deepEqual(found.hits, []);
    assert.equal(found.commits, 2);
    assert.equal(spawnSync('node', [script, '--root', r.dir], { encoding: 'utf8' }).status, 0);
  } finally { rmSync(r.dir, { recursive: true, force: true }); }
});

test('the obviously fake values the gate allows are allowed in history too', async () => {
  const r = repo();
  try {
    r.commit('c.txt', 'postgres://user:secret@host/db\n', 'example');
    assert.deepEqual((await scanHistory(r.dir)).hits, []);
  } finally { rmSync(r.dir, { recursive: true, force: true }); }
});
