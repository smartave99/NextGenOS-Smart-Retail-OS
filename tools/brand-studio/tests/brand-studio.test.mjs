import test from 'node:test';
import assert from 'node:assert/strict';
import vm from 'node:vm';
import { mkdtempSync, rmSync, readFileSync, existsSync, writeFileSync, mkdirSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import http from 'node:http';
import { tmpdir } from 'node:os';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { check, inspectLogo, colourProblem, contrastWithWhite, saveKit, blank, loadKit, listKits } from '../lib/kit.mjs';
import { previewHtml } from '../lib/preview.mjs';
import { makeExports } from '../lib/exports.mjs';
import { startServer } from '../lib/server.mjs';
import { WIZARD_JS } from '../lib/wizard.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const cli = join(here, '..', 'brand.mjs');
const PNG = Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==', 'base64');
const root = () => mkdtempSync(join(tmpdir(), 'brand-studio-'));
const run = (r, ...args) => spawnSync('node', [cli, ...args], { env: { ...process.env, BRAND_STUDIO_ROOT: r }, encoding: 'utf8' });
const good = () => ({ ...blank('Luzon Fresh Mart', '#0f6cbd'), country: 'PH', currency: 'PHP', storefront: { siteUrl: 'https://shop.luzonfresh.example' }, android: { appId: 'com.luzonfresh.shop', storefrontUrl: 'https://shop.luzonfresh.example' }, contact: { email: 'help@luzonfresh.example', phone: '+63 2 1234 5678', address: '12 Rizal Ave, Manila, Philippines' } });

test('colours: hex only, and light enough colours are refused with words', () => {
  assert.equal(colourProblem('#0f6cbd', 'main colour'), null);
  assert.match(colourProblem('blue', 'main colour'), /must look like #0f6cbd/);
  assert.match(colourProblem('#ffff00', 'main colour'), /too light/);
  assert.equal(colourProblem('#ffff00', 'second colour', { needsContrast: false }), null);
  assert.ok(contrastWithWhite('#000000') > 20 && contrastWithWhite('#ffffff') < 1.1);
});

test('a good kit passes; every kind of wrong value is named in plain words', () => {
  assert.deepEqual(check(good()).errors, []);
  const bad = {
    ...good(), name: '<b>x</b>', primaryColor: '#fafafa', accentColor: 'pink', theme: 'neon', country: 'philippines', currency: 'peso', language: 'English',
    storefront: { siteUrl: 'http://shop.example.com/path' }, android: { appId: 'Shop', storefrontUrl: 'ftp://x' }, contact: { email: 'not an email', phone: 'call me', address: '<script>' },
    receipt: { header: 'x'.repeat(200) }, poweredBy: 'yes', industry: 'Retail Shop',
  };
  const errors = check(bad).errors.join('\n');
  for (const needle of ['name of 1 to 60', 'too light', 'second colour', 'theme must be', 'two capital letters', 'three capital letters', 'en-IN', 'https://', 'app id', 'email', 'phone', 'address', 'bill header', 'true or false', 'kind of business']) assert.match(errors, new RegExp(needle, 'i'), needle);
  assert.match(check({ schema: 2 }).errors.join(), /schema/);
  assert.match(check('x').errors[0], /not a brand kit/);
  assert.match(check({ ...good(), surprise: 1 }).warnings.join(), /surprise/);
});

test('logos: the first bytes decide the kind; scripts and links in a picture are refused', () => {
  assert.equal(inspectLogo(PNG).kind, 'png');
  assert.equal(inspectLogo(Buffer.from([0xff, 0xd8, 0xff, 0xe0, 0, 0])).kind, 'jpeg');
  assert.equal(inspectLogo(Buffer.from('<svg xmlns="http://www.w3.org/2000/svg" width="1" height="1"><rect width="1" height="1"/></svg>')).problem, undefined);
  for (const evil of ['<svg><script>alert(1)</script></svg>', '<svg onload="alert(1)"/>', '<svg><foreignObject/></svg>', '<svg><image href="https://evil.example/a.png"/></svg>', '<svg><a href="javascript:alert(1)"/></svg>']) {
    assert.ok(inspectLogo(Buffer.from(evil)).problem, evil);
  }
  assert.ok(inspectLogo(Buffer.from('plain text')).problem);
});

test('the command line makes, checks, changes and exports a kit', () => {
  const r = root();
  try {
    writeFileSync(join(r, 'logo.png'), PNG);
    let out = run(r, 'new', 'luzon-fresh', '--name', 'Luzon Fresh Mart', '--primary', '#0f6cbd', '--logo', join(r, 'logo.png'), '--country', 'PH', '--site', 'https://shop.luzonfresh.example', '--android-id', 'com.luzonfresh.shop', '--email', 'help@luzonfresh.example');
    assert.equal(out.status, 0, out.stderr + out.stdout);
    assert.deepEqual(listKits(r), ['luzon-fresh']);
    assert.equal(run(r, 'new', 'luzon-fresh', '--name', 'x', '--primary', '#0f6cbd').status, 1, 'an existing kit is not overwritten');
    assert.match(run(r, 'new', 'bad', '--name', 'Bad', '--primary', '#ffff00').stderr, /too light/);
    assert.ok(!existsSync(join(r, 'brand-kits', 'bad')), 'a kit with problems is not written');
    assert.match(run(r, 'new', 'Bad Name', '--name', 'Bad', '--primary', '#0f6cbd').stderr, /small letters/);
    assert.match(run(r, 'check', 'luzon-fresh').stdout, /is fine/);
    out = run(r, 'set', 'luzon-fresh', '--primary', '#aa2233', '--receipt-footer', 'Salamat po!', '--no-powered-by');
    assert.equal(out.status, 0, out.stderr);
    const kit = loadKit('luzon-fresh', r).kit;
    assert.equal(kit.primaryColor, '#aa2233');
    assert.equal(kit.receipt.footer, 'Salamat po!');
    assert.equal(kit.poweredBy, false);
    assert.equal(kit.name, 'Luzon Fresh Mart', 'what was not mentioned is kept');

    out = run(r, 'export', 'luzon-fresh');
    assert.equal(out.status, 0, out.stderr);
    const dir = join(r, 'brand-exports', 'luzon-fresh');
    for (const f of ['preview.html', 'hub-look.json', 'licence-brand.txt', 'website.env', 'ANDROID.txt', 'README.txt']) assert.ok(existsSync(join(dir, f)), f);
    const look = JSON.parse(readFileSync(join(dir, 'hub-look.json'), 'utf8'));
    assert.equal(look.primaryColor, '#aa2233');
    assert.match(look.logo, /^data:image\/png;base64,/);
    assert.equal(look.poweredBy, false);
    assert.equal(look.schema, undefined);
    assert.equal(look.accentColor, undefined, 'a second colour white words cannot be read on is left out: the Hub would refuse the whole file');
    assert.match(out.stdout, /second colour #f59e0b is too light/);
    assert.match(readFileSync(join(dir, 'licence-brand.txt'), 'utf8'), /create-brand --name "Luzon Fresh Mart" --primary #aa2233 --accent #f59e0b --email "help@luzonfresh.example" --powered no/);
    assert.match(readFileSync(join(dir, 'website.env'), 'utf8'), /NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart\nNEXT_PUBLIC_SITE_URL=https:\/\/shop\.luzonfresh\.example\nNEXT_PUBLIC_COUNTRY=PH/);
    assert.match(readFileSync(join(dir, 'ANDROID.txt'), 'utf8'), /--app-id com\.luzonfresh\.shop/);
    const html = readFileSync(join(dir, 'preview.html'), 'utf8');
    assert.match(html, /Luzon Fresh Mart/);
    assert.doesNotMatch(html, /<script/i);
    for (const f of ['preview.html', 'hub-look.json', 'licence-brand.txt', 'website.env', 'ANDROID.txt']) assert.doesNotMatch(readFileSync(join(dir, f), 'utf8'), /BEGIN [A-Z ]*PRIVATE KEY|password|secret/i, `no secret in ${f}`);
  } finally { rmSync(r, { recursive: true, force: true }); }
});

test('the preview page escapes everything it is given and loads nothing from outside', () => {
  const html = previewHtml({ name: '"><img src=x onerror=alert(1)>', primaryColor: '#0f6cbd', receipt: { header: '<script>alert(1)</script>' }, contact: { address: '</style><script>x</script>' } }, null);
  assert.doesNotMatch(html, /<img src=x/);
  assert.doesNotMatch(html, /<script>/i);
  assert.match(html, /Content-Security-Policy/);
  assert.doesNotMatch(html, /https?:\/\//, 'nothing is fetched from outside');
});

test('a logo too big for the programs is left out of the Hub file, with a note', () => {
  const r = root();
  try {
    const big = Buffer.concat([PNG, Buffer.alloc(150_000)]);
    saveKit('big-logo', good(), { logoBytes: big, root: r });
    const out = makeExports('big-logo', { root: r });
    assert.match(out.warnings.join(), /over 100 KB/);
    assert.equal(JSON.parse(readFileSync(join(out.dir, 'hub-look.json'), 'utf8')).logo, undefined);
  } finally { rmSync(r, { recursive: true, force: true }); }
});

test('the wizard page script is valid JavaScript', () => {
  assert.doesNotThrow(() => new vm.Script(WIZARD_JS));
});

test('the wizard server: only this PC, only with the secret, and it saves and exports kits', async () => {
  const r = root();
  const s = await startServer({ root: r });
  const base = new URL(s.url).origin;
  const api = (path, { method = 'GET', body, headers = {} } = {}) => fetch(base + path, { method, headers: { 'X-Brand-Studio': s.token, 'Content-Type': 'application/json', ...headers }, body: body ? JSON.stringify(body) : undefined });
  try {
    assert.equal((await fetch(base + '/')).status, 200, 'the page itself needs no secret (it has none in it)');
    assert.equal((await fetch(base + '/api/options')).status, 401, 'the data does');
    assert.equal((await fetch(base + '/api/options', { headers: { 'X-Brand-Studio': 'wrong' } })).status, 401);
    assert.equal((await api('/api/options', { headers: { Origin: 'https://evil.example' } })).status, 403, 'a page on another site is refused');
    const withHost = (host) => new Promise((resolve, reject) => {
      const u = new URL(base);
      http.get({ host: '127.0.0.1', port: u.port, path: '/api/options', headers: { host, 'x-brand-studio': s.token } }, (res) => { res.resume(); resolve(res.statusCode); }).on('error', reject);
    });
    assert.equal(await withHost('evil.example'), 403, 'another name for this PC is refused');
    assert.equal(await withHost(`localhost:${new URL(base).port}`), 200, 'this PC\'s own name is fine');
    const page = await fetch(base + '/');
    assert.match(page.headers.get('content-security-policy'), /script-src 'self'/);
    assert.equal(page.headers.get('cache-control'), 'no-store');

    const options = await (await api('/api/options')).json();
    assert.deepEqual(options.kits, []);

    let res = await api('/api/kit/luzon', { method: 'POST', body: { kit: { ...good(), primaryColor: '#ffff00' } } });
    assert.equal(res.status, 400);
    assert.match((await res.json()).problems.join(), /too light/);
    res = await api('/api/kit/luzon', { method: 'POST', body: { kit: good(), logo: 'data:image/png;base64,' + PNG.toString('base64') } });
    assert.equal(res.status, 200, await res.clone().text());
    res = await api('/api/kit/luzon');
    const loaded = await res.json();
    assert.equal(loaded.kit.name, 'Luzon Fresh Mart');
    assert.match(loaded.logo, /^data:image\/png/);
    // saving again without a new logo keeps the old one
    res = await api('/api/kit/luzon', { method: 'POST', body: { kit: { ...good(), name: 'Luzon Fresh' }, keepLogo: true } });
    assert.equal(res.status, 200);
    assert.match((await (await api('/api/kit/luzon')).json()).logo, /^data:image\/png/);
    assert.equal((await api('/api/kit/..%2Fetc')).status, 400, 'a kit name cannot point at other folders');
    assert.equal((await api('/api/kit/luzon', { method: 'POST', body: { kit: good(), logo: 'data:text/html;base64,PGI+' } })).status, 400);

    res = await api('/api/preview', { method: 'POST', body: { kit: { name: '<b>x</b>', primaryColor: '#0f6cbd' } } });
    assert.doesNotMatch((await res.json()).html, /<b>x<\/b>/);
    res = await api('/api/export/luzon', { method: 'POST' });
    const made = await res.json();
    assert.equal(res.status, 200, JSON.stringify(made));
    assert.ok(made.files.includes('preview.html'));
    assert.equal((await api('/api/export/nothing', { method: 'POST' })).status, 400);
    const huge = await api('/api/kit/luzon', { method: 'POST', body: { kit: good(), logo: 'x'.repeat(700_000) } }).catch((e) => e);
    assert.ok(huge instanceof Error || huge.status >= 400, 'too much data is refused');
  } finally { await s.close(); rmSync(r, { recursive: true, force: true }); }
});
