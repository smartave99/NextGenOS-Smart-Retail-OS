// The gate shows what each failed test said, so that a failure seen only on a build machine can be understood (and its cause fixed) instead of being shrugged off as a timing accident.
import { test } from 'node:test';
import assert from 'node:assert/strict';
import { failedTests } from '../lib/failed-tests.mjs';

const OUTPUT = `
  Passed NextGenOS.Hub.Tests.Quiet.Test_one [12 ms]
  Failed NextGenOS.Hub.Tests.AiJobQueueTests.Requests_are_answered_in_order [4 s]
  Error Message:
   Assert.Equal() Failure: Values differ
Expected: (0, 0)
Actual:   (1, 0)
  Stack Trace:
     at NextGenOS.Hub.Tests.AiJobQueueTests.Requests_are_answered_in_order() in /work/AiJobQueueTests.cs:line 93
  Passed NextGenOS.Hub.Tests.Quiet.Test_two [3 ms]
  Failed NextGenOS.Hub.Tests.Other.Second_one [9 ms]
  Error Message:
   boom
Failed!  - Failed:     2, Passed:   739, Skipped:     0, Total:   741, Duration: 5 m 22 s - NextGenOS.Hub.Tests.dll (net10.0)
`;

test('each failed test is shown with its message, and passed tests are left out', () => {
  const found = failedTests(OUTPUT);
  assert.equal(found.length, 2);
  assert.match(found[0], /^Failed NextGenOS\.Hub\.Tests\.AiJobQueueTests\.Requests_are_answered_in_order/);
  assert.match(found[0], /Expected: \(0, 0\)/);
  assert.match(found[0], /Actual:   \(1, 0\)|Actual: +\(1, 0\)/);
  assert.doesNotMatch(found[0], /Test_two|Second_one/);
  assert.match(found[1], /boom/);
  assert.doesNotMatch(found[1], /Failed!/);
});

test('a run with no failed test gives nothing, and only the first few are shown', () => {
  assert.deepEqual(failedTests('  Passed A.B [1 ms]\nPassed!  - Failed: 0, Passed: 1\n'), []);
  const many = Array.from({ length: 20 }, (_, i) => `  Failed T.T${i} [1 ms]\n  Error Message:\n   no\n`).join('');
  assert.equal(failedTests(many, 6).length, 6);
});

test('a Node test that failed is shown with its message, and a test that passed is left out', () => {
  const tap = [
    'ok 1 - one',
    '  ---',
    '  duration_ms: 4.8',
    "  type: 'test'",
    '  ...',
    'not ok 2 - a part that failed is published with its words',
    '  ---',
    '  duration_ms: 806.3',
    "  type: 'test'",
    "  location: '/work/customer-build-results.test.mjs:287:1'",
    "  failureType: 'testCodeFailure'",
    '  error: |-',
    '    The input was expected to not match the regular expression /apk|aab|ANDROID/.',
    "  code: 'ERR_ASSERTION'",
    '  stack: |-',
    '    at TestContext.<anonymous> (file:///work/customer-build-results.test.mjs:303:10)',
    '  ...',
    'ok 3 - three',
    '  ---',
    '  duration_ms: 1',
    '  ...',
    '# tests 3',
  ].join('\n');
  const found = failedTests(tap);
  assert.equal(found.length, 1);
  assert.match(found[0], /^not ok 2 - a part that failed is published with its words/);
  assert.match(found[0], /expected to not match the regular expression/);
  assert.doesNotMatch(found[0], /three|duration_ms|at TestContext/);
  assert.deepEqual(failedTests('ok 1 - fine\n  ---\n  duration_ms: 1\n  ...\n# fail 0\n'), []);
});
