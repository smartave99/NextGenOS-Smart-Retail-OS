// The staff bundle: the Studio, its packs and style files, its one library and Node.js, in one folder that works with nothing else installed, and holds no test, key or secret.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, mkdirSync, writeFileSync, readFileSync, rmSync, existsSync, statSync, copyFileSync, readdirSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname } from 'node:path';
import { spawn, spawnSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { listZip } from '../lib/zip.mjs';

const script = join(dirname(fileURLToPath(import.meta.url)), '..', 'scripts', 'make-bundle.mjs');

test('the bundle is made, opens on its own and answers, and holds only what staff need', async (t) => {
  const root = mkdtempSync(join(tmpdir(), 'bundle-test-'));
  let child = null;
  try {
    // a stand-in Node.js (the real one is copied in below, after the zip was checked)
    const rt = join(root, 'rt'); mkdirSync(join(rt, 'bin'), { recursive: true });
    writeFileSync(join(rt, 'bin', 'node'), '#!/bin/sh\necho stand-in\n', { mode: 0o755 });
    writeFileSync(join(rt, 'LICENSE'), 'The Node.js licence text.\n');
    const made = spawnSync('node', [script, '--os', 'linux', '--version', '9.8.7', '--out', join(root, 'out'), '--node-runtime', rt], { encoding: 'utf8', timeout: 240_000 });
    assert.equal(made.status, 0, made.stdout + made.stderr);
    assert.match(made.stdout, /files checked: no test, no workspace, no key, no database, no secret pattern/);
    const zip = join(root, 'out', 'NextGenOS-Setup-Studio-9.8.7-linux.zip');
    assert.ok(existsSync(zip));
    const names = listZip(readFileSync(zip));
    const top = 'NextGenOS Setup Studio/';
    for (const want of ['READ ME FIRST.txt', 'Setup Studio.bat', 'setup-studio.sh', 'tools/setup-studio/studio.mjs', 'tools/setup-studio/lib/pack.mjs', 'tools/setup-studio/ui/index.html', 'tools/setup-studio/assets/hub.css', 'tools/setup-studio/assets/tokens.css', 'tools/setup-studio/packs/country-packs/packs/PH.json', 'tools/setup-studio/packs/industry-packs/packs/retail.json', 'tools/brand-studio/lib/kit.mjs', 'tools/setup-studio/node/bin/node', 'tools/setup-studio/node/LICENSE', 'tools/setup-studio/node_modules/@anthropic-ai/sdk/package.json']) assert.ok(names.includes(top + want), want);
    assert.equal(names.filter((n) => !n.includes('/node_modules/') && /\/tests?\/|\.test\.mjs|\.e2e\.mjs|\.env|keys\.json|\.git\//.test(n)).length, 0, 'none of our tests, no key');
    assert.ok(!names.some((n) => n.includes('/scripts/')), 'no build scripts');

    // unpack it somewhere that is not the repository, put the real Node.js in, and use it as a member of staff would
    const out = join(root, 'unpacked'); mkdirSync(out);
    const unzip = spawnSync('unzip', ['-q', zip, '-d', out], { encoding: 'utf8' });
    if (unzip.error) spawnSync('python3', ['-c', 'import sys,zipfile; zipfile.ZipFile(sys.argv[1]).extractall(sys.argv[2])', zip, out]);
    const bundle = join(out, 'NextGenOS Setup Studio');
    assert.ok(statSync(join(bundle, 'setup-studio.sh')).mode & 0o100, 'the launcher can be run');
    assert.ok(statSync(join(bundle, 'tools', 'setup-studio', 'node', 'bin', 'node')).mode & 0o100, 'node can be run');
    assert.match(readFileSync(join(bundle, 'Setup Studio.bat'), 'utf8'), /node\\node\.exe" studio\.mjs serve --open/);
    copyFileSync(process.execPath, join(bundle, 'tools', 'setup-studio', 'node', 'bin', 'node'));

    const env = { PATH: '/usr/bin:/bin', HOME: join(root, 'home'), SETUP_STUDIO_HOME: join(root, 'cfg') };
    child = spawn(join(bundle, 'tools', 'setup-studio', 'node', 'bin', 'node'), ['studio.mjs', 'serve', '--folder', join(root, 'ws')], { cwd: join(bundle, 'tools', 'setup-studio'), env, stdio: ['ignore', 'pipe', 'pipe'] });
    let log = '';
    child.stdout.on('data', (d) => { log += d; }); child.stderr.on('data', (d) => { log += d; });
    const url = await new Promise((res, rej) => { const timer = setTimeout(() => rej(new Error('no address printed:\n' + log)), 20_000); const look = setInterval(() => { const m = /(http:\/\/127\.0\.0\.1:\d+\/\?k=[\w-]+)/.exec(log); if (m) { clearTimeout(timer); clearInterval(look); res(m[1]); } }, 100); });
    const base = url.split('?')[0].replace(/\/$/, '');
    const key = /k=([\w-]+)/.exec(url)[1];
    const call = async (method, path, { body, session } = {}) => { const r = await fetch(base + path, { method, headers: { 'x-studio-key': key, 'content-type': 'application/json', ...(session ? { 'x-studio-session': session } : {}) }, body: body ? JSON.stringify(body) : undefined }); return { status: r.status, json: await r.json().catch(() => null) }; };
    assert.equal((await call('GET', '/api/state')).json.initialised, false);
    const setup = await call('POST', '/api/setup', { body: { name: 'Asha Admin', password: 'a-long-password' } });
    assert.equal(setup.status, 200, JSON.stringify(setup.json));
    const options = await call('GET', '/api/options', { session: setup.json.session });
    assert.ok(options.json.countries.length >= 30, 'the packs came with it');
    assert.ok(options.json.industries.length >= 7);
    assert.equal((await fetch(base + '/assets/hub.css')).status, 200, 'the Hub\'s style file for the preview came with it');
    assert.equal((await fetch(base + '/assets/tokens.css')).status, 200);
    const sdk = readdirSync(join(bundle, 'tools', 'setup-studio', 'node_modules', '@anthropic-ai'));
    assert.ok(sdk.includes('sdk'));
  } finally {
    if (child) { child.kill('SIGTERM'); await new Promise((r) => setTimeout(r, 300)); }
    rmSync(root, { recursive: true, force: true });
  }
});
