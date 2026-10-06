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
let releases; let nextId; let calls; let failFirstUpload;

function reset() {
  releases = []; nextId = 100; calls = []; failFirstUpload = false;
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
    if ((m = path.match(new RegExp(`^/repos/${REPO}/releases/(\\d+)$`)))) {
      const r = releases.find((x) => x.id === Number(m[1]));
      if (!r) return send(404, { message: 'not found' });
      if (req.method === 'GET') return send(200, { ...r, files: undefined });
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
  assert.equal(readFileSync(out, 'utf8'), 'release_id=100\ntag=v2.0.0\n');
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
