// The release files travel through a draft GitHub Release. This runs scripts/release-assets.mjs against a small stand-in for GitHub's API.
import { test, before, after } from 'node:test';
import assert from 'node:assert/strict';
import http from 'node:http';
import { spawn } from 'node:child_process';
import { mkdtempSync, writeFileSync, readFileSync, rmSync, readdirSync, existsSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const script = join(dirname(fileURLToPath(import.meta.url)), '..', 'release-assets.mjs');
const REPO = 'acme/shop';
let server; let base; let work;
let releases; let nextId; let calls; let failFirstUpload; let refs; let tagsRefused;

function reset() {
  releases = []; nextId = 100; calls = []; failFirstUpload = false; refs = new Map(); tagsRefused = false;
}

async function body(req) { const chunks = []; for await (const c of req) chunks.push(c); return Buffer.concat(chunks); }

before(async () => {
  reset();
  server = http.createServer(async (req, res) => {
    const url = new URL(req.url, 'http://x');
    calls.push(`${req.method} ${url.pathname}`);
    const send = (code, obj) => { res.writeHead(code, { 'content-type': 'application/json' }); res.end(obj === undefined ? '' : JSON.stringify(obj)); };
    if (req.headers.authorization !== 'Bearer test-token') return send(401, { message: 'bad credentials' });
    const path = url.pathname;
    let m;
    if (req.method === 'GET' && path === `/repos/${REPO}/releases`) return send(200, releases.map(({ files, ...r }) => r));
    if (req.method === 'POST' && path === `/repos/${REPO}/releases`) {
      const input = JSON.parse((await body(req)).toString());
      const r = { id: nextId++, ...input, html_url: `${base}/releases/${input.tag_name}`, upload_url: `${base}/uploads/releases/PLACEHOLDER/assets{?name,label}`, assets: [], files: new Map() };
      r.upload_url = `${base}/uploads/releases/${r.id}/assets{?name,label}`;
      releases.push(r);
      return send(201, { ...r, files: undefined });
    }
    if ((m = path.match(new RegExp(`^/repos/${REPO}/git/ref/tags/(.+)$`))) && req.method === 'GET') {
      return refs.has(decodeURIComponent(m[1])) ? send(200, { ref: `refs/tags/${m[1]}`, object: { sha: refs.get(decodeURIComponent(m[1])) } }) : send(404, { message: 'Not Found' });
    }
    if (req.method === 'POST' && path === `/repos/${REPO}/git/refs`) {
      const input = JSON.parse((await body(req)).toString());
      if (tagsRefused) return send(403, { message: 'Resource not accessible by integration' });
      refs.set(input.ref.replace('refs/tags/', ''), input.sha);
      return send(201, { ref: input.ref });
    }
    if ((m = path.match(new RegExp(`^/repos/${REPO}/git/refs/tags/(.+)$`))) && req.method === 'DELETE') {
      return refs.delete(decodeURIComponent(m[1])) ? send(204) : send(422, { message: 'Reference does not exist' });
    }
    if ((m = path.match(new RegExp(`^/repos/${REPO}/releases/(\\d+)$`)))) {
      const r = releases.find((x) => x.id === Number(m[1]));
      if (!r) return send(404, { message: 'not found' });
      if (req.method === 'GET') return send(200, { ...r, files: undefined });
      if (req.method === 'DELETE') { releases.splice(releases.indexOf(r), 1); return send(204); }
      if (req.method === 'PATCH') { Object.assign(r, JSON.parse((await body(req)).toString())); return send(200, { ...r, files: undefined }); }
    }
    if ((m = path.match(new RegExp(`^/repos/${REPO}/releases/(\\d+)/assets$`))) && req.method === 'GET') {
      const r = releases.find((x) => x.id === Number(m[1]));
      return send(200, [...r.files.entries()].map(([name, f]) => ({ id: f.id, name })));
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
      if (failFirstUpload) { failFirstUpload = false; return send(502, { message: 'bad gateway' }); }
      const name = url.searchParams.get('name');
      if (r.files.has(name)) return send(422, { message: 'already_exists' });
      r.files.set(name, { id: nextId++, data });
      return send(201, { name });
    }
    return send(404, { message: 'no such route' });
  });
  await new Promise((r) => server.listen(0, '127.0.0.1', r));
  base = `http://127.0.0.1:${server.address().port}`;
  work = mkdtempSync(join(tmpdir(), 'release-assets-'));
});

after(() => { server.close(); rmSync(work, { recursive: true, force: true }); });

// The stand-in server lives in this process, so the program must run beside it, not block it.
const exec = (args, env) => new Promise((resolveRun) => {
  const child = spawn('node', [script, ...args], { env: { ...process.env, GITHUB_REPOSITORY: REPO, GITHUB_API_URL: base, GITHUB_OUTPUT: '', ...env } });
  let stdout = ''; let stderr = '';
  child.stdout.on('data', (d) => { stdout += d; });
  child.stderr.on('data', (d) => { stderr += d; });
  child.on('close', (status) => resolveRun({ status, stdout, stderr }));
});
const run = (...args) => exec(args, { GITHUB_TOKEN: 'test-token' });
const file = (name, text) => { const f = join(work, name); writeFileSync(f, text); return f; };

test('a draft release is made once and found again by its tag (also while it is a draft)', async () => {
  reset();
  const first = await run('create', '--tag', 'v1.0.0-trial3', '--target', 'abc123', '--title', 'Smart Retail POS v1.0.0-trial3', '--prerelease');
  assert.equal(first.status, 0, first.stderr);
  assert.match(first.stdout, /Made a draft release for v1.0.0-trial3: number 100 \(draft\)/);
  assert.equal(releases[0].draft, true);
  assert.equal(releases[0].prerelease, true);
  assert.equal(releases[0].target_commitish, 'abc123');
  const again = await run('create', '--tag', 'v1.0.0-trial3', '--target', 'abc123');
  assert.match(again.stdout, /Using the release that already has v1.0.0-trial3: number 100/);
  assert.equal(releases.length, 1);
});

test('the number is written for the next jobs when the runner gives an output file', async () => {
  reset();
  const out = join(work, 'github-output.txt');
  writeFileSync(out, '');
  const r = await exec(['create', '--tag', 'v2.0.0', '--target', 'abc'], { GITHUB_TOKEN: 'test-token', GITHUB_OUTPUT: out });
  assert.equal(r.status, 0, r.stderr);
  assert.equal(readFileSync(out, 'utf8'), 'release_id=100\ntag=v2.0.0\ntag_made=false\n');
});

test('files go up, a file with the same name is replaced, and they come down the same', async () => {
  reset();
  await run('create', '--tag', 'v1.0.0', '--target', 'abc');
  const a = file('a.zip', 'first version');
  const b = file('b.txt', 'bee');
  assert.equal((await run('upload', '--release', '100', a, b)).status, 0);
  writeFileSync(a, 'second version');
  const again = await run('upload', '--release', '100', a);
  assert.equal(again.status, 0, again.stderr);
  assert.deepEqual([...releases[0].files.keys()].sort(), ['a.zip', 'b.txt']);
  const out = join(work, 'down');
  const d = await run('download', '--release', '100', '--out', out);
  assert.equal(d.status, 0, d.stderr);
  assert.equal(readFileSync(join(out, 'a.zip'), 'utf8'), 'second version');
  assert.equal(readFileSync(join(out, 'b.txt'), 'utf8'), 'bee');
});

test('only the files whose names match are taken when asked', async () => {
  reset();
  await run('create', '--tag', 'v1.0.0', '--target', 'abc');
  await run('upload', '--release', '100', file('SmartRetailPOS-Hub-Setup-1.0.0.exe', 'setup'), file('SmartRetailPOS-Hub-1.0.0-win-x64.zip', 'zip'), file('other-thing.zip', 'no'));
  const out = join(work, 'down-match');
  const r = await run('download', '--release', '100', '--out', out, '--match', '^SmartRetailPOS-Hub-');
  assert.equal(r.status, 0, r.stderr);
  assert.deepEqual(readdirSync(out).sort(), ['SmartRetailPOS-Hub-1.0.0-win-x64.zip', 'SmartRetailPOS-Hub-Setup-1.0.0.exe']);
  const none = await run('download', '--release', '100', '--out', join(work, 'down-none'), '--match', '^nothing-like-this$');
  assert.notEqual(none.status, 0);
  assert.match(none.stderr, /no file whose name matches/);
});

test('a passing problem at GitHub is tried again', async () => {
  reset();
  await run('create', '--tag', 'v1.0.0', '--target', 'abc');
  failFirstUpload = true;
  const r = await run('upload', '--release', '100', file('c.txt', 'cee'));
  assert.equal(r.status, 0, r.stderr);
  assert.equal(releases[0].files.get('c.txt').data.toString(), 'cee');
});

test('publishing turns the draft into a release and sets its notes', async () => {
  reset();
  await run('create', '--tag', 'v1.0.0', '--target', 'abc');
  const notes = file('notes.md', 'What is in it');
  const r = await run('publish', '--release', '100', '--notes-file', notes);
  assert.equal(r.status, 0, r.stderr);
  assert.equal(releases[0].draft, false);
  assert.equal(releases[0].body, 'What is in it');
  assert.match(r.stdout, /Published v1.0.0/);
});

test('a name that is not just a file name is refused on the way down', async () => {
  reset();
  await run('create', '--tag', 'v1.0.0', '--target', 'abc');
  releases[0].files.set('..evil', { id: 999, data: Buffer.from('x') });
  const out = join(work, 'down2');
  const r = await run('download', '--release', '100', '--out', out);
  assert.notEqual(r.status, 0);
  assert.match(r.stderr, /not allowed/);
  assert.equal(existsSync(join(out, '..evil')), false);
  assert.deepEqual(existsSync(out) ? readdirSync(out) : [], []);
});

test('the tag is made at the commit in the first seconds when asked, and left alone when it is there', async () => {
  reset();
  const first = await run('create', '--tag', 'v1.0.0-trial5', '--target', 'abc123', '--make-tag');
  assert.equal(first.status, 0, first.stderr);
  assert.match(first.stdout, /Made the tag v1.0.0-trial5 at abc123/);
  assert.equal(refs.get('v1.0.0-trial5'), 'abc123');
  const out = join(work, 'github-output-2.txt');
  writeFileSync(out, '');
  const again = await exec(['create', '--tag', 'v1.0.0-trial5', '--target', 'abc123', '--make-tag'], { GITHUB_TOKEN: 'test-token', GITHUB_OUTPUT: out });
  assert.equal(again.status, 0, again.stderr);
  assert.doesNotMatch(again.stdout, /Made the tag/);
  assert.match(readFileSync(out, 'utf8'), /tag_made=false/);
  assert.equal(releases.length, 1);
});

test('when GitHub refuses the tag it says plainly why and what to do', async () => {
  reset();
  tagsRefused = true;
  const r = await run('create', '--tag', 'v1.0.0-trial6', '--target', 'abc123def', '--make-tag');
  assert.notEqual(r.status, 0);
  assert.match(r.stderr, /newest commit of the branch/);
  assert.match(r.stderr, /Start the run again/);
  assert.equal(releases.length, 0);
});

test('an unwanted draft and the tag made for it are removed, a published release never is', async () => {
  reset();
  await run('create', '--tag', 'v1.0.0-trial7', '--target', 'abc', '--make-tag');
  const gone = await run('discard', '--release', '100', '--tag', 'v1.0.0-trial7');
  assert.equal(gone.status, 0, gone.stderr);
  assert.equal(releases.length, 0);
  assert.equal(refs.has('v1.0.0-trial7'), false);

  await run('create', '--tag', 'v1.0.0-trial8', '--target', 'abc', '--make-tag');
  await run('publish', '--release', '101');
  const refused = await run('discard', '--release', '101', '--tag', 'v1.0.0-trial8');
  assert.notEqual(refused.status, 0);
  assert.match(refused.stderr, /is published; it is not removed/);
  assert.equal(releases.length, 1);
  assert.equal(refs.has('v1.0.0-trial8'), true);
});

test('without a token or a repository it says so in plain words and does nothing', async () => {
  const r = await exec(['create', '--tag', 'v1', '--target', 'a'], { GITHUB_TOKEN: '', GH_TOKEN: '' });
  assert.notEqual(r.status, 0);
  assert.match(r.stderr, /no GITHUB_TOKEN/);
  const r2 = await exec(['create', '--tag', 'v1', '--target', 'a'], { GITHUB_TOKEN: 't', GITHUB_REPOSITORY: 'not a repo' });
  assert.match(r2.stderr, /owner\/name/);
});

test('bad credentials stop it with GitHub\'s answer', async () => {
  reset();
  const r = await exec(['create', '--tag', 'v1', '--target', 'a'], { GITHUB_TOKEN: 'wrong' });
  assert.notEqual(r.status, 0);
  assert.match(r.stderr, /401/);
});
