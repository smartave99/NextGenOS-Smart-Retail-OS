// The build properties that tell a Hub where to look for updates (blueprint REL-016): none given means none written; some given means all must be given and well formed.
import test from 'node:test';
import assert from 'node:assert/strict';
import { spawnSync } from 'node:child_process';
import { updateProperties, flags } from './../../apps/business-hub/installer/common.mjs';

const good = { NGOS_UPDATE_FEED: 'https://updates.example.test/hub/', NGOS_RELEASE_REPOSITORY_ID: '1384926224', NGOS_RELEASE_OWNER_ID: '260031592' };
const none = (n, d) => d;   // no command-line flag given: only the environment speaks

test('a build given nothing does not look for updates', () => {
  assert.deepEqual(updateProperties(none, {}), []);
});

test('the numbers without a folder write nothing: the folder is the switch (the release workflow always gives the numbers)', () => {
  assert.deepEqual(updateProperties(none, { NGOS_RELEASE_REPOSITORY_ID: '1384926224', NGOS_RELEASE_OWNER_ID: '260031592', NGOS_RELEASE_WORKFLOW: '.github/workflows/release.yml' }), []);
});

test('a build given the folder and the numbers looks there, for the default release workflow', () => {
  assert.deepEqual(updateProperties(none, good), [
    '-p:UpdateFeed=https://updates.example.test/hub/', '-p:ReleaseRepositoryId=1384926224', '-p:ReleaseOwnerId=260031592', '-p:ReleaseWorkflow=.github/workflows/release.yml',
  ]);
});

test('command-line flags speak over the environment', () => {
  const { flag } = flags(['--update-feed', 'https://other.example.test/x/', '--release-workflow', '.github/workflows/ship.yaml']);
  const props = updateProperties(flag, good);
  assert.ok(props.includes('-p:UpdateFeed=https://other.example.test/x/'));
  assert.ok(props.includes('-p:ReleaseWorkflow=.github/workflows/ship.yaml'));
});

// A bad value stops the build with exit code 2 and says what is wrong; run in a child so that this test keeps going.
function refused(env) {
  const code = `import { updateProperties } from './apps/business-hub/installer/common.mjs'; updateProperties((n, d) => d, ${JSON.stringify(env)});`;
  return spawnSync(process.execPath, ['--input-type=module', '-e', code], { cwd: new URL('../..', import.meta.url), encoding: 'utf8' });
}

for (const [name, change, words] of [
  ['a folder that is not https', { NGOS_UPDATE_FEED: 'http://updates.example.test/hub/' }, 'https address ending in /'],
  ['a folder that is not a folder', { NGOS_UPDATE_FEED: 'https://updates.example.test/hub' }, 'https address ending in /'],
  ['a folder with a query', { NGOS_UPDATE_FEED: 'https://updates.example.test/hub/?x=1' }, 'https address ending in /'],
  ['a folder with sign-in details', { NGOS_UPDATE_FEED: 'https://user:secret@updates.example.test/hub/' }, 'https address ending in /'],
  ['a repository number that is not digits', { NGOS_RELEASE_REPOSITORY_ID: 'smart-retail' }, "repository's number"],
  ['an owner number that is missing', { NGOS_RELEASE_OWNER_ID: '' }, "owner's number"],
  ['a workflow outside .github/workflows', { NGOS_RELEASE_WORKFLOW: 'scripts/release.yml' }, 'release workflow'],
  ['a workflow that climbs out of the folder', { NGOS_RELEASE_WORKFLOW: '.github/workflows/../../evil.yml' }, 'release workflow'],
  ['only the folder, without the numbers', { NGOS_RELEASE_REPOSITORY_ID: '', NGOS_RELEASE_OWNER_ID: '' }, "repository's number"],
]) {
  test(`stops the build for ${name}`, () => {
    const env = { ...good, ...change };
    // Only the folder given (the two numbers cleared) counts as "some given": it must then be refused for the missing numbers.
    const r = refused(env);
    assert.equal(r.status, 2, r.stderr);
    assert.match(r.stderr, new RegExp(words.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')));
  });
}
