// scripts/customer-build/result.mjs: the words and files a customer build reports (result.json, SHA256SUMS.txt, the report of each part). No network here.
import test from 'node:test';
import assert from 'node:assert/strict';
import { existsSync, mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { dirname, join } from 'node:path';
import { spawnSync } from 'node:child_process';
import { createHash } from 'node:crypto';
import { fileURLToPath } from 'node:url';
import {
  buildResultJson, describeFiles, isOutputName, missingPartOutcome, PARTS, PART_LABELS, partFileProblem, partOutcome, parseSteps, readPartReport, releaseNotes, safeMessage, STEP_WORDS, sumsText,
} from '../customer-build/result.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const script = join(here, '..', 'customer-build', 'result.mjs');
const tmp = () => mkdtempSync(join(tmpdir(), 'cb-result-'));
const sha = (b) => createHash('sha256').update(b).digest('hex');
const HEX = 'a'.repeat(64);

test('a part that worked says so, and one that failed names the step it stopped at, in words a person understands', () => {
  assert.deepEqual(partOutcome('website-linux', 'success'), { status: 'success', message: 'The website for Linux was built, checked and put with the results.' });
  const failed = partOutcome('website-windows', 'failure', { settings: 'success', build: 'failure', audit: 'skipped' });
  assert.equal(failed.status, 'failure');
  assert.equal(failed.message, 'The website for Windows could not be made. It stopped while building it. The build service\'s log for this build shows the details.');
  assert.match(partOutcome('android', 'failure', { signing: 'failure' }).message, /preparing the key the app is signed with/);
  assert.match(partOutcome('android', 'cancelled').message, /stopped before it was finished/);
  assert.match(partOutcome('android', 'failure', {}).message, /did not say why/);
  assert.match(partOutcome('android', 'failure', { somethingnew: 'failure' }).message, /could not be made/);
  assert.throws(() => partOutcome('ios', 'success'), /Unknown part/);
});

test('no sentence names GitHub or its Actions: the Setup Studio calls it the build service', () => {
  const all = [];
  for (const part of PARTS) {
    all.push(partOutcome(part, 'success').message, partOutcome(part, 'cancelled').message, partOutcome(part, 'failure').message);
    for (const step of Object.keys(STEP_WORDS)) all.push(partOutcome(part, 'failure', { [step]: 'failure' }).message);
    for (const r of ['cancelled', 'skipped', 'failure', 'success']) all.push(missingPartOutcome(part, r).message);
  }
  all.push(...Object.values(STEP_WORDS), releaseNotes({ customer: 'acme-test', build: 1, trial: true, parts: Object.fromEntries(PARTS.map((p) => [p, { status: 'failure', message: 'x' }])) }));
  for (const text of all) assert.doesNotMatch(text, /github|actions|workflow|runner|artifact|job\b/i, text);
});

test('a part that left no report is explained from how its job ended', () => {
  assert.match(missingPartOutcome('website-linux', 'cancelled').message, /stopped before it was finished/);
  assert.match(missingPartOutcome('android', 'skipped').message, /not started, because an earlier part/);
  assert.match(missingPartOutcome('android', 'failure').message, /did not report back/);
  assert.equal(missingPartOutcome('android', 'success').status, 'failure', 'a job that says success but left no report is not trusted');
});

test('the file names a build may make are exactly the ones agreed with the Setup Studio, for that customer only', () => {
  for (const good of ['website-acme-test-linux.zip', 'website-acme-test-windows.zip', 'SmartRetailPOS-acme-test-1.0.4.apk', 'SmartRetailPOS-acme-test-1.0.4.aab', 'ANDROID-SIGNING.txt']) assert.equal(isOutputName(good, 'acme-test'), true, good);
  for (const bad of ['website-other-linux.zip', 'website-acme-test-mac.zip', 'SmartRetailPOS-acme-test-1.0.apk', 'SmartRetailPOS-acme-test-1.0.4.exe', 'inputs.zip', 'result.json', 'SHA256SUMS.txt', '../website-acme-test-linux.zip', 'x/website-acme-test-linux.zip', 'brand.json', 'NO-LICENCE-KEYS-TRIAL-ONLY.txt']) assert.equal(isOutputName(bad, 'acme-test'), false, bad);

  const f = (name) => ({ name, size: 1, sha256: HEX });
  assert.equal(partFileProblem('website-linux', [f('website-acme-test-linux.zip')], 'acme-test'), null);
  assert.ok(partFileProblem('website-linux', [f('website-acme-test-windows.zip')], 'acme-test'));
  assert.ok(partFileProblem('website-linux', [], 'acme-test'));
  const app = ['SmartRetailPOS-acme-test-1.0.4.apk', 'SmartRetailPOS-acme-test-1.0.4.aab', 'ANDROID-SIGNING.txt'].map(f);
  assert.equal(partFileProblem('android', app, 'acme-test'), null);
  assert.ok(partFileProblem('android', app.slice(1), 'acme-test'));
  assert.ok(partFileProblem('android', [f('SmartRetailPOS-acme-test-1.0.4.apk'), f('SmartRetailPOS-acme-test-1.0.5.aab'), f('ANDROID-SIGNING.txt')], 'acme-test'), 'the apk and the aab must be the same version');
});

test('a message is one safe line: no control characters, a limit, and never a secret or a token', () => {
  assert.equal(safeMessage('  one\n\ttwo   three \u0000 '), 'one two three');
  assert.equal(safeMessage('x'.repeat(1000)).length, 400);
  const aws = ['AK', 'IA', 'ABCDEFGHIJKLMNOP'].join('');
  assert.match(safeMessage(`the key ${aws} failed`), /left out because it looked like it held a secret/);
  assert.match(safeMessage(`token ${['github', 'pat', 'A'.repeat(30)].join('_')} here`), /left out/);
  assert.equal(safeMessage('the value s3cr3t-value-123 was refused', { secrets: ['s3cr3t-value-123'] }), 'the value *** was refused');
  assert.equal(safeMessage(null), '');
});

test('result.json holds exactly what was agreed and nothing else', () => {
  const parts = {
    'website-linux': { status: 'success', message: 'ok', files: ['ignored'] },
    'website-windows': { status: 'failure', message: 'bad', extra: 1 },
    android: { status: 'skipped', message: 'not asked' },
  };
  const r = buildResultJson({ customer: 'acme-test', build: 3, trial: 1, sourceCommit: 'a'.repeat(40), startedAt: '2026-10-06T10:00:00Z', finishedAt: '2026-10-06T10:30:00Z', parts, token: 'must-not-appear' });
  assert.deepEqual(r, {
    schema: 1, customer: 'acme-test', build: 3, trial: true, sourceCommit: 'a'.repeat(40), startedAt: '2026-10-06T10:00:00Z', finishedAt: '2026-10-06T10:30:00Z',
    parts: { 'website-linux': { status: 'success', message: 'ok' }, 'website-windows': { status: 'failure', message: 'bad' }, android: { status: 'skipped', message: 'not asked' } },
  });
  assert.deepEqual(Object.keys(r), ['schema', 'customer', 'build', 'trial', 'sourceCommit', 'startedAt', 'finishedAt', 'parts']);
});

test('the fingerprint list is in the form sha256sum writes, sorted, one file to a line', () => {
  const text = sumsText([{ name: 'b.txt', sha256: HEX }, { name: 'a.txt', sha256: 'b'.repeat(64) }]);
  assert.equal(text, `${'b'.repeat(64)}  a.txt\n${HEX}  b.txt\n`);
});

test('the page of the release says in plain words what worked, and marks a trial', () => {
  const parts = { 'website-linux': { status: 'success', message: 'It worked.' }, 'website-windows': { status: 'failure', message: 'It did not.' }, android: { status: 'skipped', message: 'Not asked.' } };
  const notes = releaseNotes({ customer: 'acme-test', build: 3, trial: true, parts });
  assert.match(notes, /^Build 3 for acme-test\./);
  assert.match(notes, /TRIAL BUILD: it has no licence keys/);
  assert.match(notes, /Website for Linux: worked/);
  assert.match(notes, /Website for Windows: did NOT work/);
  assert.match(notes, /Android app: not asked for/);
  assert.doesNotMatch(releaseNotes({ customer: 'acme-test', build: 3, trial: false, parts }), /TRIAL/);
});

test('a report read back is checked: its shape, its file names, a failed part claims no file', () => {
  const good = JSON.stringify({ schema: 1, part: 'website-linux', status: 'success', message: 'Fine.', files: [{ name: 'website-acme-test-linux.zip', size: 10, sha256: HEX }] });
  assert.deepEqual(readPartReport(good, 'website-linux', 'acme-test'), { status: 'success', message: 'Fine.', files: [{ name: 'website-acme-test-linux.zip', size: 10, sha256: HEX }] });
  assert.equal(readPartReport(good, 'website-windows', 'acme-test'), null, 'a report for another part');
  assert.equal(readPartReport('not json', 'website-linux', 'acme-test'), null);
  assert.equal(readPartReport(good.replace('"schema":1', '"schema":2').replace('"schema": 1', '"schema": 2'), 'website-linux', 'acme-test'), null);
  assert.equal(readPartReport(good.replace('website-acme-test-linux.zip', 'evil.exe'), 'website-linux', 'acme-test'), null);
  assert.equal(readPartReport(good.replace(HEX, 'zz'), 'website-linux', 'acme-test'), null);
  assert.equal(readPartReport(good.replace('"size":10', '"size":-1').replace('"size": 10', '"size": -1'), 'website-linux', 'acme-test'), null);
  const failed = JSON.stringify({ schema: 1, part: 'website-linux', status: 'failure', message: 'Broke.', files: [{ name: 'website-acme-test-linux.zip', size: 10, sha256: HEX }] });
  assert.deepEqual(readPartReport(failed, 'website-linux', 'acme-test'), { status: 'failure', message: 'Broke.', files: [] });
});

// ---- the command the last step of every build job runs -------------------------------------------------------------------------

const part = (args) => spawnSync('node', [script, 'part', ...args], { encoding: 'utf8' });

test('the part command writes the report: fingerprints of the files for a part that worked, none for one that failed', () => {
  const dir = tmp();
  const zip = join(dir, 'website-acme-test-linux.zip');
  writeFileSync(zip, 'zip bytes');
  const out = join(dir, 'part');
  const ok = part(['--part', 'website-linux', '--job-status', 'success', '--steps', 'settings=success,build=success', '--files', zip, '--out', out]);
  assert.equal(ok.status, 0, ok.stderr);
  const report = JSON.parse(readFileSync(join(out, 'part-website-linux.json'), 'utf8'));
  assert.deepEqual(report, { schema: 1, part: 'website-linux', status: 'success', message: 'The website for Linux was built, checked and put with the results.', files: [{ name: 'website-acme-test-linux.zip', size: 9, sha256: sha('zip bytes') }] });
  assert.deepEqual(describeFiles([zip]), report.files);

  // The same files, but the job failed: no file is handed over.
  const failed = part(['--part', 'website-linux', '--job-status', 'failure', '--steps', 'settings=success,build=failure', '--files', zip, '--out', out]);
  assert.equal(failed.status, 0, failed.stderr);
  const bad = JSON.parse(readFileSync(join(out, 'part-website-linux.json'), 'utf8'));
  assert.equal(bad.status, 'failure');
  assert.deepEqual(bad.files, []);
  assert.match(bad.message, /stopped while building it/);

  // A part that worked but whose file is missing stops with a clear error and writes no report that says it worked.
  rmSync(out, { recursive: true, force: true });
  assert.notEqual(part(['--part', 'website-linux', '--job-status', 'success', '--files', join(dir, 'gone.zip'), '--out', out]).status, 0);
  assert.equal(existsSync(join(out, 'part-website-linux.json')), false);
  assert.equal(part(['--part', 'nonsense', '--out', out]).status, 2);
  rmSync(dir, { recursive: true, force: true });
});

test('a step that is written twice (its Linux and its Windows form) counts as the worse of the two', () => {
  assert.deepEqual(parseSteps('settings=success,smoke=skipped,smoke=failure,window=skipped'), { settings: 'success', smoke: 'failure', window: 'skipped' });
  assert.deepEqual(parseSteps('smoke=failure,smoke=skipped'), { smoke: 'failure' });
  assert.deepEqual(parseSteps('smoke=success,smoke=skipped'), { smoke: 'success' });
  assert.deepEqual(parseSteps('keys=,build=success'), { keys: '', build: 'success' });
  assert.deepEqual(parseSteps('Bad Id=failure,../x=failure,ok=success'), { ok: 'success' }, 'only step ids are taken');
  assert.deepEqual(parseSteps(''), {});
  // And the part command uses it: a Windows step that failed is named, though its Linux twin was skipped.
  const dir = tmp();
  const r = part(['--part', 'website-windows', '--job-status', 'failure', '--steps', 'smoke=skipped,smoke=failure', '--out', dir]);
  assert.equal(r.status, 0, r.stderr);
  assert.match(JSON.parse(readFileSync(join(dir, 'part-website-windows.json'), 'utf8')).message, /starting it to see that it refuses to work without a licence/);
  rmSync(dir, { recursive: true, force: true });
});

test('every part has a plain label', () => {
  assert.deepEqual(Object.keys(PART_LABELS), PARTS);
});
