// A workflow that calls the Release workflow (the trial release does) must give it every permission any of its jobs asks for.
// GitHub does not run the call otherwise: it stops at start-up ("startup_failure") before a single job runs, and nothing in the files looks wrong. That happened once
// when the Release workflow's last job began asking for `id-token: write` (a signed statement for the update folder) and the trial caller was not told.
import test from 'node:test';
import assert from 'node:assert/strict';
import { readdirSync, readFileSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';

const root = join(dirname(fileURLToPath(import.meta.url)), '..', '..');
const workflows = join(root, '.github', 'workflows');
const RANK = { none: 0, read: 1, write: 2 };

const lines = (file) => readFileSync(join(workflows, file), 'utf8').replace(/\r\n/g, '\n').split('\n');
const indentOf = (l) => l.length - l.trimStart().length;

/** Every `permissions:` block in the lines given, as { scope, indent, perms }. Only block form (`permissions:` followed by `key: level` lines) is used in these files. */
export function permissionBlocks(ls) {
  const blocks = [];
  for (let n = 0; n < ls.length; n += 1) {
    const m = /^(\s*)permissions:\s*(#.*)?$/.exec(ls[n]);
    if (!m) continue;
    const perms = {};
    for (let k = n + 1; k < ls.length; k += 1) {
      if (ls[k].trim() === '' || ls[k].trim().startsWith('#')) continue;
      if (indentOf(ls[k]) <= m[1].length) break;
      const kv = /^\s*([a-z-]+):\s*(none|read|write)\b/.exec(ls[k]);
      if (kv) perms[kv[1]] = kv[2];
    }
    blocks.push({ line: n, indent: m[1].length, perms });
  }
  return blocks;
}

/** The highest level asked for, per permission, by any job (or the top of the file) in a workflow. */
export function asked(ls) {
  const top = {};
  for (const b of permissionBlocks(ls)) {
    for (const [name, level] of Object.entries(b.perms)) {
      if ((RANK[level] ?? 0) > (RANK[top[name]] ?? 0)) top[name] = level;
    }
  }
  return top;
}

/** The lines of the job in `ls` whose `uses:` is the given reusable workflow. */
function callingJob(ls, target) {
  const at = ls.findIndex((l) => new RegExp(`^\\s+uses:\\s*${target.replace(/[.*+?^${}()|[\]\\/]/g, '\\$&')}\\s*$`).test(l));
  if (at < 0) return null;
  let start = at;
  while (start > 0 && !/^  [A-Za-z0-9_-]+:\s*$/.test(ls[start])) start -= 1;
  let end = at + 1;
  while (end < ls.length && !/^  [A-Za-z0-9_-]+:\s*$/.test(ls[end]) && !/^\S/.test(ls[end])) end += 1;
  return ls.slice(start, end);
}

test('the reader finds the permissions a job asks for', () => {
  const sample = ['permissions:', '  contents: write', '', 'jobs:', '  a:', '    permissions:', '      contents: read', '      id-token: write  # for the signed statement', '    steps: []'];
  assert.deepEqual(asked(sample), { contents: 'write', 'id-token': 'write' });
  assert.deepEqual(permissionBlocks(sample).map((b) => b.perms), [{ contents: 'write' }, { contents: 'read', 'id-token': 'write' }]);
});

test('the Release workflow asks for the signed-statement permission only in its last job', () => {
  const release = lines('release.yml');
  const withIdToken = permissionBlocks(release).filter((b) => b.perms['id-token'] === 'write');
  assert.equal(withIdToken.length, 1, 'only the job that publishes the update may ask for id-token: write');
  const owner = release.slice(0, withIdToken[0].line).reverse().find((l) => /^  [A-Za-z0-9_-]+:\s*$/.test(l));
  assert.match(owner, /publish-update:/);
});

for (const file of readdirSync(workflows).filter((f) => /\.ya?ml$/.test(f) && f !== 'release.yml')) {
  const ls = lines(file);
  const job = callingJob(ls, './.github/workflows/release.yml');
  if (!job) continue;
  test(`${file} gives the Release workflow every permission it asks for`, () => {
    const given = Object.assign({}, ...permissionBlocks(job).map((b) => b.perms));
    const need = asked(lines('release.yml'));
    for (const [name, level] of Object.entries(need)) {
      if (level === 'read' || level === 'write') {
        assert.ok((RANK[given[name]] ?? 0) >= RANK[level], `${file}: the call to the Release workflow must give "${name}: ${level}" (it has "${given[name] ?? 'nothing'}"); GitHub otherwise refuses to start the run`);
      }
    }
  });
}

test('at least one workflow calls the Release workflow (so the check above is not empty)', () => {
  const callers = readdirSync(workflows).filter((f) => f !== 'release.yml' && callingJob(lines(f), './.github/workflows/release.yml'));
  assert.ok(callers.includes('trial-release.yml'), `callers found: ${callers.join(', ') || 'none'}`);
});
