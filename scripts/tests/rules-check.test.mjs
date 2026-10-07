// The check that keeps the owner's rules in the repository: it passes the real repository, and it notices every way a rule can be lost.
import test from 'node:test';
import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { rulesProblems, REQUIRED_SECTIONS, POINTER_FILES, DECISION_COUNT } from '../checks/rules.mjs';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const realRead = (f) => { try { return readFileSync(join(repo, f), 'utf8'); } catch { return ''; } };
const withChange = (changes) => (f) => (f in changes ? changes[f] : realRead(f));

test('the real repository keeps every rule, every pointer file and the open-work list', () => {
  assert.deepEqual(rulesProblems(realRead), []);
});

test('a lost or emptied rule section is named', () => {
  const rules = realRead('CLAUDE.md');
  const noSection13 = rules.replace(/^## 13\. .*$/m, '## Thirteen');
  assert.ok(rulesProblems(withChange({ 'CLAUDE.md': noSection13 })).some((p) => /lost its section 13/.test(p)));
  const emptied = rules.replace(/never have to repeat/g, 'x');
  assert.ok(rulesProblems(withChange({ 'CLAUDE.md': emptied })).some((p) => /section 13 .* no longer says "never have to repeat"/.test(p)));
  assert.ok(rulesProblems(withChange({ 'CLAUDE.md': '' })).some((p) => /CLAUDE\.md is missing/.test(p)));
});

test('every section of CLAUDE.md the check requires is really there once, in order', () => {
  const rules = realRead('CLAUDE.md');
  for (const [n] of REQUIRED_SECTIONS) assert.equal((rules.match(new RegExp(`^## ${n}\\. `, 'gm')) ?? []).length, 1, `section ${n}`);
});

test('a pointer file that is missing, points nowhere, or grows its own rules is named', () => {
  for (const f of POINTER_FILES) {
    assert.ok(rulesProblems(withChange({ [f]: '' })).some((p) => p.startsWith(f + ' is missing')), f);
    assert.ok(rulesProblems(withChange({ [f]: 'Some other rules.\n' })).some((p) => p.startsWith(f + ' does not point')), f);
    assert.ok(rulesProblems(withChange({ [f]: 'See CLAUDE.md.\n' + 'a rule\n'.repeat(60) })).some((p) => p.startsWith(f + ' is long')), f);
  }
});

test('the open-work list must exist, keep its three parts and say when it was last updated', () => {
  assert.ok(rulesProblems(withChange({ 'docs/OPEN-WORK.md': '' })).some((p) => /docs\/OPEN-WORK\.md is missing/.test(p)));
  const open = realRead('docs/OPEN-WORK.md');
  assert.ok(rulesProblems(withChange({ 'docs/OPEN-WORK.md': open.replace('## Needs the owner', '## Other') })).some((p) => /lost its part "Needs the owner"/.test(p)));
  assert.ok(rulesProblems(withChange({ 'docs/OPEN-WORK.md': open.replace(/^Last updated: .*$/m, '') })).some((p) => /no "Last updated/.test(p)));
});

test('the owner\'s recorded decisions must stay: the file, every numbered decision and the owner\'s own description', () => {
  assert.ok(rulesProblems(withChange({ 'docs/PLATFORM-DECISIONS.md': '' })).some((p) => /docs\/PLATFORM-DECISIONS\.md is missing/.test(p)));
  const decisions = realRead('docs/PLATFORM-DECISIONS.md');
  for (let n = 1; n <= DECISION_COUNT; n += 1) assert.equal((decisions.match(new RegExp(`^### ${n}\\. `, 'gm')) ?? []).length, 1, `decision ${n}`);
  assert.ok(rulesProblems(withChange({ 'docs/PLATFORM-DECISIONS.md': decisions.replace(/^### 7\. .*$/m, '### Seven') })).some((p) => /lost decision 7/.test(p)));
  assert.ok(rulesProblems(withChange({ 'docs/PLATFORM-DECISIONS.md': decisions.replace('The picture, in the owner', 'x') })).some((p) => /lost the owner's own description/.test(p)));
});
