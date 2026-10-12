// scripts/customer-build/results.mjs against a small stand-in for GitHub's web interface (the same approach as scripts/tests/release-assets.test.mjs):
// the draft release of a build, inputs.zip taken off it, the files of the parts put on it, result.json and SHA256SUMS.txt written, and the release published LAST.
// A real GitHub with the owner's repositories and tokens is not used here (docs/CUSTOMER-BUILDS.md says so).
import { test, before, after } from 'node:test';
import assert from 'node:assert/strict';
import http from 'node:http';
import { spawn } from 'node:child_process';
import { createHash } from 'node:crypto';
import { mkdirSync, mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';
import { createClient } from '../customer-build/github-api.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const results = join(here, '..', 'customer-build', 'results.mjs');
const resultCli = join(here, '..', 'customer-build', 'result.mjs');
const REPO = 'owner/results';
const TOKEN = 'res-token-0123456789';
const COMMIT = 'c'.repeat(40);
const sha = (b) => createHash('sha256').update(b).digest('hex');

let server; let base; let work;
let releases; let nextId; let calls; let auths; let echoToken; let digestFor; let failNext;

function reset() { releases = []; nextId = 100; calls = []; auths = []; echoToken = false; digestFor = new Map(); failNext = 0; }

/** A draft release the way the Setup Studio leaves it: tag customer-<id>-<n>, inputs.zip on it. */
function studioMakes(customer, build, { files = { 'inputs.zip': 'the inputs' }, draft = true } = {}) {
  const r = { id: nextId++, tag_name: `customer-${customer}-${build}`, draft, body: '', upload_url: `${base}/uploads/releases/PLACEHOLDER/assets{?name,label}`, files: new Map() };
  r.upload_url = `${base}/uploads/releases/${r.id}/assets{?name,label}`;
  for (const [name, data] of Object.entries(files)) r.files.set(name, { id: nextId++, data: Buffer.from(data) });
  releases.push(r);
  return r;
}
const stripped = ({ files, ...r }) => r;

async function body(req) { const chunks = []; for await (const c of req) chunks.push(c); return Buffer.concat(chunks); }

before(async () => {
  reset();
  server = http.createServer(async (req, res) => {
    const url = new URL(req.url, 'http://x');
    calls.push(`${req.method} ${url.pathname}`);
    auths.push(req.headers.authorization);
    const send = (code, obj) => { res.writeHead(code, { 'content-type': 'application/json' }); res.end(obj === undefined ? '' : JSON.stringify(obj)); };
    if (req.headers.authorization !== `Bearer ${TOKEN}`) return send(401, { message: 'bad credentials' });
    const path = url.pathname;
    let m;
    // The token reaches the results repository only.
    if (path.startsWith('/repos/') && !path.startsWith(`/repos/${REPO}/`)) return send(404, { message: 'Not Found' });
    if (req.method === 'GET' && path === `/repos/${REPO}/releases`) {
      if (echoToken) return send(422, { message: `your token ${TOKEN} is odd` });
      if (failNext > 0) { failNext -= 1; return send(502, { message: 'bad gateway' }); }
      const page = Number(url.searchParams.get('page') || 1);
      return send(200, releases.slice().reverse().slice((page - 1) * 100, page * 100).map(stripped));
    }
    if ((m = path.match(new RegExp(`^/repos/${REPO}/releases/(\\d+)$`)))) {
      const r = releases.find((x) => x.id === Number(m[1]));
      if (!r) return send(404, { message: 'not found' });
      if (req.method === 'GET') return send(200, stripped(r));
      if (req.method === 'PATCH') { Object.assign(r, JSON.parse((await body(req)).toString())); return send(200, stripped(r)); }
    }
    if ((m = path.match(new RegExp(`^/repos/${REPO}/releases/(\\d+)/assets$`))) && req.method === 'GET') {
      const r = releases.find((x) => x.id === Number(m[1]));
      return send(200, [...r.files.entries()].map(([name, f]) => ({ id: f.id, name, size: f.data.length, ...(digestFor.has(name) ? { digest: digestFor.get(name) } : {}) })));
    }
    if ((m = path.match(new RegExp(`^/repos/${REPO}/releases/assets/(\\d+)$`)))) {
      for (const r of releases) for (const [name, f] of r.files) if (f.id === Number(m[1])) {
        if (req.method === 'DELETE') { r.files.delete(name); return send(204); }
        if (req.method === 'GET') { res.writeHead(200, { 'content-type': 'application/octet-stream' }); return res.end(f.data); }
      }
      return send(404, { message: 'no such file' });
    }
    if ((m = path.match(/^\/uploads\/releases\/(\d+)\/assets$/)) && req.method === 'POST') {
      const r = releases.find((x) => x.id === Number(m[1]));
      const data = await body(req);
      const name = url.searchParams.get('name');
      if (r.files.has(name)) return send(422, { message: 'already_exists' });
      r.files.set(name, { id: nextId++, data });
      return send(201, { name });
    }
    return send(404, { message: 'no such route' });
  });
  await new Promise((r) => server.listen(0, '127.0.0.1', r));
  base = `http://127.0.0.1:${server.address().port}`;
  work = mkdtempSync(join(tmpdir(), 'cb-results-'));
});

after(() => { server.close(); rmSync(work, { recursive: true, force: true }); });

// The stand-in lives in this process, so the programs run beside it, not in the way of it.
const exec = (script, args, env = {}) => new Promise((done) => {
  const child = spawn('node', [script, ...args], {
    env: {
      ...process.env, GITHUB_OUTPUT: '', GITHUB_API_URL: base, GITHUB_REPOSITORY: 'owner/source', RESULTS_RETRY_DELAY_MS: '5',
      RESULTS_TOKEN: TOKEN, RESULTS_REPO: REPO, CUSTOMER: 'acme-test', BUILD: '3', ...env,
    },
  });
  let stdout = ''; let stderr = '';
  child.stdout.on('data', (d) => { stdout += d; });
  child.stderr.on('data', (d) => { stderr += d; });
  child.on('close', (status) => done({ status, stdout, stderr }));
});
const run = (args, env) => exec(results, args, env);
const file = (name, text) => { const f = join(work, name); writeFileSync(f, text); return f; };
const fresh = (name) => { const d = join(work, name); rmSync(d, { recursive: true, force: true }); mkdirSync(d, { recursive: true }); return d; };
const names = (r) => [...r.files.keys()].sort();

// ---- reading the inputs -----------------------------------------------------------------------------------------------------

test('inputs.zip is taken off the draft release of this build, and only this build', async () => {
  reset();
  studioMakes('acme-test', 2, { files: { 'inputs.zip': 'build two' } });
  const mine = studioMakes('acme-test', 3, { files: { 'inputs.zip': 'build three' } });
  studioMakes('other-shop', 3, { files: { 'inputs.zip': 'someone else' } });
  const out = join(fresh('dl1'), 'inputs.zip');
  const output = file('gh-out-1.txt', '');
  const r = await run(['download-inputs', '--out', out], { GITHUB_OUTPUT: output });
  assert.equal(r.status, 0, r.stderr);
  assert.equal(readFileSync(out, 'utf8'), 'build three');
  assert.equal(readFileSync(output, 'utf8'), `release_id=${mine.id}\n`);
});

test('every request carries the results token and nothing else, whatever other tokens are in the environment', async () => {
  reset();
  studioMakes('acme-test', 3);
  const r = await run(['download-inputs', '--out', join(fresh('dl2'), 'inputs.zip')], { GITHUB_TOKEN: 'the-source-repos-token', GH_TOKEN: 'another-token' });
  assert.equal(r.status, 0, r.stderr);
  assert.ok(auths.length >= 3);
  assert.deepEqual([...new Set(auths)], [`Bearer ${TOKEN}`]);
});

test('without the token, or with a name that is not allowed, it says so in plain words and asks GitHub nothing', async () => {
  reset();
  studioMakes('acme-test', 3);
  const noToken = await run(['download-inputs', '--out', join(work, 'x.zip')], { RESULTS_TOKEN: '' });
  assert.equal(noToken.status, 1);
  assert.match(noToken.stderr, /no RESULTS_TOKEN/);
  for (const env of [{ CUSTOMER: '../evil' }, { CUSTOMER: 'Acme' }, { BUILD: '0' }, { BUILD: '3; id' }, { RESULTS_REPO: 'owner/source' }, { RESULTS_REPO: 'nonsense' }]) {
    const r = await run(['download-inputs', '--out', join(work, 'x.zip')], env);
    assert.equal(r.status, 1, JSON.stringify(env));
    assert.ok(r.stderr.length > 20, JSON.stringify(env));
  }
  assert.deepEqual(calls, []);
});

test('a build that does not exist, is finished, or has no inputs is refused with what to do, and the reason is handed to the next job', async () => {
  reset();
  const output = file('gh-out-2.txt', '');
  const none = await run(['download-inputs', '--out', join(work, 'x.zip')], { GITHUB_OUTPUT: output });
  assert.equal(none.status, 1);
  assert.match(none.stderr, /no build called customer-acme-test-3/);
  assert.match(none.stderr, /Connect the build service/);
  assert.match(readFileSync(output, 'utf8'), /^ok=false\nmessage=The build service could not take the customer's settings/);

  studioMakes('acme-test', 3, { draft: false });
  const finished = await run(['download-inputs', '--out', join(work, 'x.zip')]);
  assert.match(finished.stderr, /already finished/);

  reset();
  studioMakes('acme-test', 3, { files: { 'inputs.zip': 'x', 'result.json': '{}' } });
  assert.match((await run(['download-inputs', '--out', join(work, 'x.zip')])).stderr, /already has its result/);

  reset();
  studioMakes('acme-test', 3, { files: { 'other.txt': 'x' } });
  assert.match((await run(['download-inputs', '--out', join(work, 'x.zip')])).stderr, /has no inputs\.zip/);
});

test('when GitHub repeats the token back in an error, it never reaches the output', async () => {
  reset();
  echoToken = true;
  const r = await run(['download-inputs', '--out', join(work, 'x.zip')]);
  assert.equal(r.status, 1);
  assert.ok(!r.stderr.includes(TOKEN) && !r.stdout.includes(TOKEN));
  assert.match(r.stderr, /\*\*\*/);
});

test('a passing problem at GitHub is tried again, and the token is never sent to an address that is not GitHub\'s', async () => {
  reset();
  studioMakes('acme-test', 3);
  failNext = 2;
  const r = await run(['download-inputs', '--out', join(fresh('dl3'), 'inputs.zip')]);
  assert.equal(r.status, 0, r.stderr);

  const rel = releases[0];
  const client = createClient({ token: TOKEN, repo: REPO, apiUrl: base, retryDelayMs: 1 });
  const before = auths.length;
  await assert.rejects(client.uploadAsset({ id: rel.id, upload_url: 'https://evil.example.invalid/uploads/assets{?name}' }, 'a.txt', Buffer.from('x')), /not GitHub's own/);
  assert.equal(auths.slice(before).filter((a) => a === undefined).length, 0);
  assert.ok(!calls.slice(-1)[0].includes('evil'), 'no request went to the other address');
});

// ---- putting the files of a part on the release ---------------------------------------------------------------------------------

test('only the files this build service makes for this customer are put on the release, and only while it is a draft', async () => {
  reset();
  const rel = studioMakes('acme-test', 3);
  const zip = file('website-acme-test-linux.zip', 'linux site');
  const up = await run(['upload', '--files', zip]);
  assert.equal(up.status, 0, up.stderr);
  assert.equal(rel.files.get('website-acme-test-linux.zip').data.toString(), 'linux site');
  writeFileSync(zip, 'linux site, second try');
  assert.equal((await run(['upload', '--files', zip])).status, 0);
  assert.equal(rel.files.get('website-acme-test-linux.zip').data.toString(), 'linux site, second try', 'a file with the same name is replaced');

  for (const bad of ['inputs.zip', 'result.json', 'SHA256SUMS.txt', 'evil.js', 'website-other-shop-linux.zip', 'brand.json']) {
    const r = await run(['upload', '--files', file(bad, 'x')]);
    assert.equal(r.status, 1, bad);
    assert.match(r.stderr, /not a file this build service makes/, bad);
  }
  assert.deepEqual(names(rel), ['inputs.zip', 'website-acme-test-linux.zip'], 'inputs.zip is the Studio\'s and stays as it was');
  assert.equal(rel.files.get('inputs.zip').data.toString(), 'the inputs');

  rel.draft = false;
  const late = await run(['upload', '--files', zip]);
  assert.equal(late.status, 1);
  assert.match(late.stderr, /already finished/);
});

// ---- finishing: result.json, the fingerprints, publishing last ----------------------------------------------------------------------

/** A build as the jobs leave it: the draft with inputs.zip, the files of the parts put on it, and each part's report in a folder. */
async function builtRelease({ website = true, android = true, windows = true } = {}) {
  const rel = studioMakes('acme-test', 3);
  const parts = fresh(`parts-${rel.id}`);
  const made = {};
  const put = async (name, text) => { made[name] = text; assert.equal((await run(['upload', '--files', file(name, text)])).status, 0); return join(work, name); };
  if (website) {
    const linux = await put('website-acme-test-linux.zip', 'linux site bytes');
    assert.equal((await exec(resultCli, ['part', '--part', 'website-linux', '--job-status', 'success', '--files', linux, '--out', parts])).status, 0);
    if (windows) {
      const win = await put('website-acme-test-windows.zip', 'windows site bytes');
      assert.equal((await exec(resultCli, ['part', '--part', 'website-windows', '--job-status', 'success', '--files', win, '--out', parts])).status, 0);
    }
  }
  if (android) {
    const files = [await put('SmartRetailPOS-acme-test-1.0.3.apk', 'apk bytes'), await put('SmartRetailPOS-acme-test-1.0.3.aab', 'aab bytes'), await put('ANDROID-SIGNING.txt', 'Signed with: one-off TEST key')];
    assert.equal((await exec(resultCli, ['part', '--part', 'android', '--job-status', 'success', '--files', files.join(','), '--out', parts])).status, 0);
  }
  calls = [];
  return { rel, parts, made };
}
const finishEnv = (parts, over = {}) => ({
  SOURCE_COMMIT: COMMIT, STARTED_AT: '2026-10-06T10:00:00Z', TRIAL: 'false', WEBSITE_REQUESTED: 'true', ANDROID_REQUESTED: 'true',
  INPUTS_RESULT: 'success', WEBSITE_RESULT: 'success', ANDROID_RESULT: 'success', ...over,
});
const finish = (parts, over) => run(['finish', '--parts', parts], finishEnv(parts, over));

test('a build where every part worked: result.json, the fingerprints of every file, and the release published last', async () => {
  reset();
  const { rel, parts, made } = await builtRelease();
  const r = await finish(parts);
  assert.equal(r.status, 0, r.stderr);

  assert.equal(rel.draft, false, 'published');
  const result = JSON.parse(rel.files.get('result.json').data.toString());
  assert.deepEqual(Object.keys(result), ['schema', 'customer', 'build', 'trial', 'sourceCommit', 'startedAt', 'finishedAt', 'parts']);
  assert.equal(result.schema, 1);
  assert.equal(result.customer, 'acme-test');
  assert.equal(result.build, 3);
  assert.equal(result.trial, false);
  assert.equal(result.sourceCommit, COMMIT);
  assert.equal(result.startedAt, '2026-10-06T10:00:00Z');
  assert.match(result.finishedAt, /^\d{4}-\d\d-\d\dT\d\d:\d\d:\d\d\.\d+Z$/);
  assert.deepEqual(Object.keys(result.parts), ['website-linux', 'website-windows', 'android']);
  for (const p of Object.values(result.parts)) { assert.equal(p.status, 'success'); assert.ok(p.message.length > 10); }

  // The fingerprints: every file on the release, each as its real SHA-256, in the form sha256sum writes.
  const sums = rel.files.get('SHA256SUMS.txt').data.toString();
  const lines = Object.fromEntries(sums.trim().split('\n').map((l) => { const [h, ...n] = l.split('  '); return [n.join('  '), h]; }));
  assert.deepEqual(Object.keys(lines).sort(), ['ANDROID-SIGNING.txt', 'SmartRetailPOS-acme-test-1.0.3.aab', 'SmartRetailPOS-acme-test-1.0.3.apk', 'inputs.zip', 'result.json', 'website-acme-test-linux.zip', 'website-acme-test-windows.zip']);
  for (const [name, text] of Object.entries(made)) assert.equal(lines[name], sha(Buffer.from(text)), name);
  assert.equal(lines['inputs.zip'], sha(Buffer.from('the inputs')));
  assert.equal(lines['result.json'], sha(rel.files.get('result.json').data));
  assert.deepEqual(names(rel), [...Object.keys(lines), 'SHA256SUMS.txt'].sort());
  assert.ok(!names(rel).includes('NO-LICENCE-KEYS-TRIAL-ONLY.txt'), 'not a trial');

  // Published LAST: the only change that makes the build "finished" comes after result.json and the fingerprints.
  const writes = calls.filter((c) => c.startsWith('POST') || c.startsWith('PATCH'));
  assert.equal(writes[writes.length - 1], `PATCH /repos/${REPO}/releases/${rel.id}`);
  assert.equal(calls.filter((c) => c.startsWith('PATCH')).length, 1);
  assert.match(rel.body, /^Build 3 for acme-test\./);
  assert.match(r.stdout, /Published customer-acme-test-3/);
});

test('a part that failed is published with its words, and leaves no file of its own behind', async () => {
  reset();
  const { rel, parts } = await builtRelease();
  // The app failed while it was being built, after it had put one file on the release.
  const apk = join(work, 'SmartRetailPOS-acme-test-1.0.3.apk');
  rmSync(join(parts, 'part-android.json'));
  assert.equal((await exec(resultCli, ['part', '--part', 'android', '--job-status', 'failure', '--steps', 'settings=success,build=failure', '--files', apk, '--out', parts])).status, 0);
  const r = await finish(parts, { ANDROID_RESULT: 'failure' });
  assert.equal(r.status, 0, r.stderr);
  assert.equal(rel.draft, false);
  const result = JSON.parse(rel.files.get('result.json').data.toString());
  assert.equal(result.parts.android.status, 'failure');
  assert.match(result.parts.android.message, /Android app could not be made\. It stopped while building it/);
  assert.equal(result.parts['website-linux'].status, 'success');
  assert.deepEqual(names(rel), ['SHA256SUMS.txt', 'inputs.zip', 'result.json', 'website-acme-test-linux.zip', 'website-acme-test-windows.zip'], 'the app\'s partial files are taken away');
  // Only the file names are looked at: each line also holds a fingerprint (64 random letters and digits), which can spell "aab" by chance (it did, once in about a hundred runs).
  const listed = rel.files.get('SHA256SUMS.txt').data.toString().split('\n').filter(Boolean).map((line) => line.replace(/^[0-9a-f]{64}\s+/, ''));
  assert.deepEqual(listed, ['inputs.zip', 'result.json', 'website-acme-test-linux.zip', 'website-acme-test-windows.zip'], 'the list names the files that are on the release, and no file of the app');
});

test('a part that left no report is explained from how its job ended, and a part not asked for is skipped', async () => {
  reset();
  const { rel, parts } = await builtRelease({ android: false });
  rmSync(join(parts, 'part-website-windows.json'));
  const r = await finish(parts, { ANDROID_REQUESTED: 'false', ANDROID_RESULT: 'skipped', WEBSITE_RESULT: 'cancelled' });
  assert.equal(r.status, 0, r.stderr);
  const result = JSON.parse(rel.files.get('result.json').data.toString());
  assert.equal(result.parts['website-linux'].status, 'success');
  assert.equal(result.parts['website-windows'].status, 'failure');
  assert.match(result.parts['website-windows'].message, /was stopped before it was finished/);
  assert.deepEqual(result.parts.android, { status: 'skipped', message: 'This part was not asked for in this build.' });
  assert.ok(!names(rel).includes('website-acme-test-windows.zip'), 'a part with no report claims no file');
});

test('a file that did not arrive whole, or whose fingerprint is not the one the build made, makes its part fail', async () => {
  reset();
  const { rel, parts } = await builtRelease();
  rel.files.get('website-acme-test-linux.zip').data = Buffer.from('cut off');
  digestFor.set('website-acme-test-windows.zip', `sha256:${'0'.repeat(64)}`);
  const r = await finish(parts);
  assert.equal(r.status, 0, r.stderr);
  const result = JSON.parse(rel.files.get('result.json').data.toString());
  assert.equal(result.parts['website-linux'].status, 'failure');
  assert.equal(result.parts['website-windows'].status, 'failure');
  assert.match(result.parts['website-linux'].message, /did not arrive whole in the results place/);
  assert.equal(result.parts.android.status, 'success');
  assert.ok(!names(rel).some((n) => n.startsWith('website-')), 'neither website is handed over');
});

test('when the settings were refused nothing was built: the parts that were asked for say why, the others are skipped', async () => {
  reset();
  const rel = studioMakes('acme-test', 3);
  const empty = fresh('parts-refused');
  const message = 'The files the Setup Studio sent were not accepted. website-settings.env: NEXT_PUBLIC_SITE_NAME is missing.';
  const r = await finish(empty, { INPUTS_RESULT: 'failure', WEBSITE_RESULT: 'skipped', ANDROID_RESULT: 'skipped', ANDROID_REQUESTED: 'false', INPUTS_MESSAGE: message });
  assert.equal(r.status, 0, r.stderr);
  const result = JSON.parse(rel.files.get('result.json').data.toString());
  assert.equal(result.parts['website-linux'].status, 'failure');
  assert.equal(result.parts['website-linux'].message, message);
  assert.equal(result.parts['website-windows'].status, 'failure');
  assert.equal(result.parts.android.status, 'skipped');
  assert.equal(rel.draft, false);

  // Nothing is known about the parts (the settings could not even be read): every part counts as asked for.
  reset();
  const rel2 = studioMakes('acme-test', 3);
  const r2 = await finish(empty, { INPUTS_RESULT: 'failure', WEBSITE_REQUESTED: 'unknown', ANDROID_REQUESTED: 'unknown', INPUTS_MESSAGE: '' });
  assert.equal(r2.status, 0, r2.stderr);
  const result2 = JSON.parse(rel2.files.get('result.json').data.toString());
  assert.deepEqual(Object.values(result2.parts).map((p) => p.status), ['failure', 'failure', 'failure']);
  assert.match(result2.parts.android.message, /could not read the customer's settings/);
});

test('a trial build is marked in result.json and by a file, and the file has a fingerprint too; a real build has no such file', async () => {
  reset();
  const { rel, parts } = await builtRelease();
  const r = await finish(parts, { TRIAL: 'true' });
  assert.equal(r.status, 0, r.stderr);
  assert.equal(JSON.parse(rel.files.get('result.json').data.toString()).trial, true);
  const marker = rel.files.get('NO-LICENCE-KEYS-TRIAL-ONLY.txt').data.toString();
  assert.match(marker, /NO licence keys/);
  assert.match(marker, /Do not give it to a customer/);
  assert.match(rel.files.get('SHA256SUMS.txt').data.toString(), new RegExp(`${sha(Buffer.from(marker))}  NO-LICENCE-KEYS-TRIAL-ONLY.txt`));
  assert.match(rel.body, /TRIAL BUILD/);

  // When it is not known whether the keys were there, the cautious answer is a trial.
  reset();
  const second = await builtRelease();
  assert.equal((await finish(second.parts, { TRIAL: '' })).status, 0);
  assert.equal(JSON.parse(second.rel.files.get('result.json').data.toString()).trial, true);
});

test('a finished build is never changed: finishing it again, or finishing one that is not there, stops', async () => {
  reset();
  const { rel, parts } = await builtRelease();
  assert.equal((await finish(parts)).status, 0);
  calls = [];
  const again = await finish(parts);
  assert.equal(again.status, 1);
  assert.match(again.stderr, /already finished/);
  assert.deepEqual(calls.filter((c) => !c.startsWith('GET')), [], 'nothing was written');
  assert.equal(rel.draft, false);

  reset();
  const missing = await finish(fresh('parts-none'));
  assert.equal(missing.status, 1);
  assert.match(missing.stderr, /no build called customer-acme-test-3/);
});

test('finish needs the commit it was built from, and a part report that is damaged is not trusted', async () => {
  reset();
  const { rel, parts } = await builtRelease();
  const noCommit = await finish(parts, { SOURCE_COMMIT: 'abc' });
  assert.equal(noCommit.status, 1);
  assert.match(noCommit.stderr, /commit/);
  assert.equal(rel.draft, true);

  writeFileSync(join(parts, 'part-android.json'), JSON.stringify({ schema: 1, part: 'android', status: 'success', message: 'x', files: [{ name: 'evil.exe', size: 1, sha256: 'a'.repeat(64) }] }));
  assert.equal((await finish(parts)).status, 0);
  const result = JSON.parse(rel.files.get('result.json').data.toString());
  assert.equal(result.parts.android.status, 'failure', 'a report that claims a file this build service does not make is not believed');
});

test('result.json, the fingerprint list and the page of the release hold no token and nothing that looks like a secret', async () => {
  reset();
  const { rel, parts } = await builtRelease();
  const r = await finish(parts);
  assert.equal(r.status, 0, r.stderr);
  for (const name of ['result.json', 'SHA256SUMS.txt']) assert.ok(!rel.files.get(name).data.toString().includes(TOKEN), name);
  assert.ok(!rel.body.includes(TOKEN));
  assert.ok(!r.stdout.includes(TOKEN) && !r.stderr.includes(TOKEN));
});
