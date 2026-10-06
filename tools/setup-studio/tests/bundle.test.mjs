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
    for (const want of ['READ ME FIRST.txt', 'setup-studio.sh', 'tools/setup-studio/studio.mjs', 'tools/setup-studio/lib/pack.mjs', 'tools/setup-studio/ui/index.html', 'tools/setup-studio/assets/hub.css', 'tools/setup-studio/assets/tokens.css', 'tools/setup-studio/packs/country-packs/packs/PH.json', 'tools/setup-studio/packs/industry-packs/packs/retail.json', 'tools/brand-studio/lib/kit.mjs', 'tools/setup-studio/node/bin/node', 'tools/setup-studio/node/LICENSE', 'tools/setup-studio/node_modules/@anthropic-ai/sdk/package.json']) assert.ok(names.includes(top + want), want);
    assert.equal(names.filter((n) => !n.includes('/node_modules/') && /\/tests?\/|\.test\.mjs|\.e2e\.mjs|\.env|keys\.json|\.git\//.test(n)).length, 0, 'none of our tests, no key');
    assert.ok(!names.some((n) => n.includes('/scripts/')), 'no build scripts');

    // unpack it somewhere that is not the repository, put the real Node.js in, and use it as a member of staff would
    const out = join(root, 'unpacked'); mkdirSync(out);
    const unzip = spawnSync('unzip', ['-q', zip, '-d', out], { encoding: 'utf8' });
    if (unzip.error) spawnSync('python3', ['-c', 'import sys,zipfile; zipfile.ZipFile(sys.argv[1]).extractall(sys.argv[2])', zip, out]);
    const bundle = join(out, 'NextGenOS Setup Studio');
    assert.ok(statSync(join(bundle, 'setup-studio.sh')).mode & 0o100, 'the launcher can be run');
    assert.ok(statSync(join(bundle, 'tools', 'setup-studio', 'node', 'bin', 'node')).mode & 0o100, 'node can be run');
    const launcher = readFileSync(join(bundle, 'setup-studio.sh'), 'utf8');
    assert.match(launcher, /studio\.mjs serve --app/, 'it opens the Studio in a window of its own');
    assert.match(launcher, /--install-menu/, 'it can put the Studio in the applications menu');
    assert.ok(!names.some((n) => /\.(bat|exe)$/.test(n) && !n.includes('/node_modules/')), 'the Linux bundle has no Windows launcher');
    assert.match(readFileSync(join(bundle, 'READ ME FIRST.txt'), 'utf8'), /window of its own/);
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

test('the Windows bundle opens with a program of its own: no terminal window, the Studio\'s icon, and a plain launcher for problems', { skip: spawnSync('makensis', ['-VERSION']).error ? 'makensis (NSIS) is not installed here' : false }, async () => {
  const root = mkdtempSync(join(tmpdir(), 'bundle-win-test-'));
  try {
    const rt = join(root, 'rt'); mkdirSync(rt, { recursive: true });
    writeFileSync(join(rt, 'node.exe'), 'MZ stand-in');
    writeFileSync(join(rt, 'LICENSE'), 'The Node.js licence text.\n');
    const made = spawnSync('node', [script, '--os', 'windows', '--version', '9.8.7', '--out', join(root, 'out'), '--node-runtime', rt], { encoding: 'utf8', timeout: 240_000 });
    assert.equal(made.status, 0, made.stdout + made.stderr);
    const zip = join(root, 'out', 'NextGenOS-Setup-Studio-9.8.7-windows.zip');
    const names = listZip(readFileSync(zip));
    const top = 'NextGenOS Setup Studio/';
    for (const want of ['Setup Studio.exe', 'Setup Studio (with a window, for problems).bat', 'READ ME FIRST.txt', 'tools/setup-studio/studio.mjs', 'tools/setup-studio/lib/launch.mjs', 'tools/setup-studio/node/node.exe']) assert.ok(names.includes(top + want), want);
    assert.ok(!names.includes(top + 'setup-studio.sh'), 'no Linux launcher in the Windows bundle');
    assert.ok(!names.some((n) => n.endsWith('.nsi') || n.endsWith('.ico')), 'the launcher\'s source and icon file stay behind: only the finished program goes in');

    const exe = spawnSync('unzip', ['-p', zip, top + 'Setup Studio.exe'], { maxBuffer: 16 * 1024 * 1024 }).stdout;
    assert.equal(exe.subarray(0, 2).toString('latin1'), 'MZ', 'it is a Windows program');
    const pe = exe.readUInt32LE(0x3c);
    assert.equal(exe.subarray(pe, pe + 4).toString('latin1'), 'PE\0\0');
    assert.equal(exe.readUInt16LE(pe + 24 + 68), 2, 'it is a window program (subsystem 2), not a console program: no black window opens');
    assert.ok(exe.includes(Buffer.from('studio.mjs serve --app', 'utf16le')), 'it starts the Studio as an app window');

    const bat = spawnSync('unzip', ['-p', zip, top + 'Setup Studio (with a window, for problems).bat'], { encoding: 'utf8' }).stdout;
    assert.match(bat, /studio\.mjs serve --open/);
    assert.match(spawnSync('unzip', ['-p', zip, top + 'READ ME FIRST.txt'], { encoding: 'utf8' }).stdout, /no black terminal window/);
  } finally { rmSync(root, { recursive: true, force: true }); }
});
