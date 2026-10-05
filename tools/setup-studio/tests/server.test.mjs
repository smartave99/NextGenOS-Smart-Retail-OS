import { test } from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, rmSync, writeFileSync, chmodSync, readFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, delimiter } from 'node:path';
import http from 'node:http';
import { startStudio } from '../lib/server.mjs';
import { listZip } from '../lib/zip.mjs';

const PNG = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==';
const good = (over = {}) => ({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example' } }, device: { kind: 'touch-pos', os: 'windows', screen: 'standard' }, look: { primaryColor: '#0a7d4b', style: 'friendly' }, licence: { whiteLabel: 'theme' }, ...over });

async function boot() {
  const root = mkdtempSync(join(tmpdir(), 'studio-srv-'));
  process.env.SETUP_STUDIO_HOME = join(root, 'home');
  const env = process.env;   // the live settings, as the real Studio uses
  const studio = await startStudio({ folder: join(root, 'ws'), env });
  const base = studio.url.split('?')[0].replace(/\/$/, '');
  const call = async (method, path, { body, session, key = studio.token, headers = {} } = {}) => {
    const res = await fetch(base + path, { method, headers: { 'content-type': 'application/json', 'x-studio-key': key ?? '', ...(session ? { 'x-studio-session': session } : {}), ...headers }, body: body === undefined ? undefined : JSON.stringify(body) });
    const type = res.headers.get('content-type') ?? '';
    return { status: res.status, headers: res.headers, json: type.includes('json') ? await res.json() : null, buffer: type.includes('json') ? null : Buffer.from(await res.arrayBuffer()) };
  };
  return { root, studio, base, call, done: async () => { await studio.close(); rmSync(root, { recursive: true, force: true }); delete process.env.SETUP_STUDIO_HOME; } };
}

test('the Studio only answers this PC, with the secret, and sends strict headers', async () => {
  const s = await boot();
  try {
    const page = await fetch(s.base + '/', { headers: {} });
    assert.equal(page.status, 200);
    assert.match(page.headers.get('content-security-policy'), /script-src 'self'/);
    assert.match(page.headers.get('content-security-policy'), /frame-ancestors 'none'/);
    assert.equal(page.headers.get('x-content-type-options'), 'nosniff');
    assert.equal((await s.call('GET', '/api/state', { key: null })).status, 401, 'no secret');
    assert.equal((await s.call('GET', '/api/state', { key: 'wrong-secret-value-here' })).status, 401);
    assert.equal((await s.call('GET', '/api/state', { headers: { origin: 'https://evil.example' } })).status, 403, 'a page from elsewhere cannot use it');
    const wrongHost = await new Promise((resolveHost) => {
      const r = http.request({ host: '127.0.0.1', port: s.studio.server.address().port, path: '/api/state', headers: { host: 'evil.example', 'x-studio-key': s.studio.token } }, (res) => resolveHost(res.statusCode));
      r.on('error', () => resolveHost(0)); r.end();
    });
    assert.equal(wrongHost, 403, 'another name for this PC is refused (a page cannot point its own name at it)');
    assert.equal((await s.call('GET', '/api/customers')).status, 409, 'not set up yet');
    assert.equal((await s.call('GET', '/js/../../package.json')).status, 404);
    assert.equal((await fetch(s.base + '/js/..%2f..%2fpackage.json')).status, 404);
    assert.equal((await fetch(s.base + '/nothing')).status, 404);
  } finally { await s.done(); }
});

test('first use makes the workspace and the administrator; signing in, roles and the whole path from details to an approved release over the real interface', async () => {
  const s = await boot();
  try {
    const st = await s.call('GET', '/api/state');
    assert.equal(st.json.initialised, false);
    assert.equal((await s.call('POST', '/api/setup', { body: { name: 'Asha Admin', password: 'short' } })).status, 400);
    const setup = await s.call('POST', '/api/setup', { body: { name: 'Asha Admin', password: 'a-long-password' } });
    assert.equal(setup.status, 200);
    const admin = setup.json.session;
    assert.equal((await s.call('POST', '/api/setup', { body: { name: 'X', password: 'another-password' } })).status, 409);

    assert.equal((await s.call('GET', '/api/customers', {})).status, 401, 'signing in is needed');
    const me = await s.call('GET', '/api/me', { session: admin });
    assert.equal(me.json.member.role, 'admin');
    assert.equal(me.json.can.team, true);

    const sales = (await s.call('POST', '/api/team', { session: admin, body: { name: 'Sam Sales', role: 'sales', password: 'sam-long-password' } })).json.member;
    const reviewer = (await s.call('POST', '/api/team', { session: admin, body: { name: 'Rita Reviewer', role: 'reviewer', password: 'rita-long-password' } })).json.member;
    const state = await s.call('GET', '/api/state');
    assert.deepEqual(state.json.team.map((m) => m.name).sort(), ['Asha Admin', 'Rita Reviewer', 'Sam Sales']);
    assert.ok(!JSON.stringify(state.json).includes('hash'), 'nothing secret about the team is shown before signing in');
    assert.equal((await s.call('POST', '/api/signin', { body: { id: sales.id, password: 'wrong-password' } })).status, 401);
    const samS = (await s.call('POST', '/api/signin', { body: { id: sales.id, password: 'sam-long-password' } })).json.session;
    const ritaS = (await s.call('POST', '/api/signin', { body: { id: reviewer.id, password: 'rita-long-password' } })).json.session;
    assert.equal((await s.call('POST', '/api/team', { session: samS, body: { name: 'X Y', role: 'sales', password: 'long-enough-1' } })).status, 403);

    const opts = await s.call('GET', '/api/options', { session: samS });
    assert.ok(opts.json.countries.length >= 30 && opts.json.industries.length >= 7 && opts.json.options.styles.length === 5);

    const created = await s.call('POST', '/api/customers', { session: samS, body: { intake: good() } });
    assert.equal(created.status, 200);
    const id = created.json.customer.id;
    assert.equal(id, 'luzon-fresh-mart');
    const withLogo = await s.call('PUT', `/api/customers/${id}/logo`, { session: samS, body: { data: PNG } });
    assert.equal(withLogo.json.customer.hasLogo, true);
    assert.equal((await s.call('PUT', `/api/customers/${id}/logo`, { session: samS, body: { data: 'data:text/html;base64,PHNjcmlwdD4=' } })).status, 400);
    const pic = await s.call('GET', `/api/customers/${id}/logo`, { session: samS });
    assert.equal(pic.headers.get('content-type'), 'image/png');
    assert.match(pic.headers.get('content-security-policy'), /sandbox/);

    const proposed = await s.call('POST', `/api/customers/${id}/proposal`, { session: samS });
    assert.equal(proposed.json.customer.state, 'proposed');
    assert.match(proposed.json.customer.proposal.brand.logo, /^data:image\/png/);
    assert.equal((await s.call('POST', `/api/customers/${id}/submit`, { session: samS })).json.customer.state, 'review');
    assert.equal((await s.call('POST', `/api/customers/${id}/approve`, { session: samS })).status, 403, 'sales cannot approve');
    const approved = await s.call('POST', `/api/customers/${id}/approve`, { session: ritaS });
    assert.equal(approved.json.customer.state, 'approved');

    const zip = await s.call('GET', `/api/customers/${id}/releases/1/profile.zip`, { session: ritaS });
    assert.equal(zip.headers.get('content-type'), 'application/zip');
    assert.deepEqual(listZip(zip.buffer), ['profile/setup.json', 'profile/theme.json', 'profile/brand.json']);

    const audit = await s.call('GET', `/api/audit?customer=${id}`, { session: ritaS });
    assert.ok(audit.json.entries.some((e) => e.action === 'release.approved' && e.who.name === 'Rita Reviewer'));
    assert.equal((await s.call('GET', '/api/audit/verify', { session: ritaS })).json.result.ok, true);

    // a person switched off, and a role changed, take effect on the very next request
    await s.call('PUT', `/api/team/${sales.id}`, { session: admin, body: { active: false } });
    assert.equal((await s.call('GET', '/api/customers', { session: samS })).status, 401);
    assert.equal((await s.call('POST', '/api/signout', { session: ritaS })).status, 200);
    assert.equal((await s.call('GET', '/api/customers', { session: ritaS })).status, 401);
  } finally { await s.done(); }
});

test('lists are read from a spreadsheet and checked; a body that is far too big is refused', async () => {
  const s = await boot();
  try {
    const session = (await s.call('POST', '/api/setup', { body: { name: 'Asha Admin', password: 'a-long-password' } })).json.session;
    const r = await s.call('POST', '/api/import', { session, body: { kind: 'items', industry: 'retail', csv: 'Item;Rate\nRice;12,50\nTea;\n' } });
    assert.equal(r.json.count, 1);
    assert.equal(r.json.rows[0].price, '12.50');
    assert.match(r.json.problems[0], /Line 3/);
    assert.equal((await s.call('POST', '/api/import', { session, body: { kind: 'cars', csv: 'a' } })).status, 400);
    const big = await fetch(s.base + '/api/import', { method: 'POST', headers: { 'x-studio-key': s.studio.token, 'x-studio-session': session, 'content-type': 'application/json' }, body: JSON.stringify({ kind: 'items', csv: 'x'.repeat(5_000_000) }) }).catch(() => null);
    assert.ok(!big || big.status === 413);
  } finally { await s.done(); }
});

test('the preview is the Hub\'s own style with the chosen look, escapes everything, and needs the secret', async () => {
  const s = await boot();
  try {
    const d = Buffer.from(JSON.stringify({ name: '"><script>alert(1)</script>', country: 'PH', industry: 'retail', primary: '#0a7d4b', style: 'friendly', kind: 'touch-pos', level: 'theme' })).toString('base64url');
    assert.equal((await fetch(`${s.base}/preview?d=${d}`)).status, 401);
    const html = await (await fetch(`${s.base}/preview?k=${s.studio.token}&d=${d}`)).text();
    assert.match(html, /data-density="touch"/);
    assert.match(html, /data-shape="pill"/);
    assert.ok(!html.includes('<script>alert'), 'escaped');
    assert.ok(!/<script/i.test(html));
    const css = await (await fetch(`${s.base}/preview.css?k=${s.studio.token}&d=${d}`)).text();
    assert.match(css, /--ngos-accent:#0a7d4b/);
    const fixed = Buffer.from(JSON.stringify({ name: 'A', primary: '#0a7d4b', level: 'none' })).toString('base64url');
    assert.equal(await (await fetch(`${s.base}/preview.css?k=${s.studio.token}&d=${fixed}`)).text(), '', 'a fixed-look licence does not take the profile colour');
    assert.match((await fetch(`${s.base}/preview?k=${s.studio.token}&d=${d}`)).headers.get('content-security-policy'), /default-src 'none'/);
    for (const css of ['/assets/hub.css', '/assets/tokens.css']) assert.equal((await fetch(s.base + css)).status, 200);
    assert.equal((await fetch(`${s.base}/preview?k=${s.studio.token}&d=not-base64-@@@`)).status, 200, 'a damaged request still gives a plain preview');
  } finally { await s.done(); }
});

test('the AI tools over the interface: settings are checked, keys are never shown, models and levels, an AI answer is read again by the rules and only kept when a person accepts', async () => {
  const s = await boot();
  const tools = mkdtempSync(join(tmpdir(), 'studio-srv-tools-'));
  const oldPath = process.env.PATH;
  try {
    const session = (await s.call('POST', '/api/setup', { body: { name: 'Asha Admin', password: 'a-long-password' } })).json.session;
    const sam = (await s.call('POST', '/api/team', { session, body: { name: 'Sam Sales', role: 'sales', password: 'sam-long-password' } })).json.member;
    const samS = (await s.call('POST', '/api/signin', { body: { id: sam.id, password: 'sam-long-password' } })).json.session;

    // keys: saved, never returned
    assert.equal((await s.call('PUT', '/api/keys/anthropic', { session: samS, body: { key: 'sk-ant-test-123456' } })).status, 403);
    const saved = await s.call('PUT', '/api/keys/anthropic', { session, body: { key: 'sk-ant-test-123456' } });
    assert.equal(saved.json.keys.anthropic.set, true);
    assert.ok(!JSON.stringify(saved.json).includes('sk-ant-test'));
    assert.equal((await s.call('PUT', '/api/keys/anthropic', { session, body: { key: 'bad key' } })).status, 400);
    const log = await s.call('GET', '/api/audit', { session });
    assert.ok(!JSON.stringify(log.json).includes('sk-ant-test'), 'a key is never in the activity record');

    // settings: checked
    const bad = await s.call('PUT', '/api/settings', { session, body: { ai: { tool: 'claude-code', tools: { 'claude-code': { model: 'x y', effort: 'ultra', extraArgs: ['--dangerously-skip-permissions'] } } } } });
    assert.equal(bad.status, 400);
    assert.match(bad.json.error, /never passed/);
    const okSettings = await s.call('PUT', '/api/settings', { session, body: { ai: { tool: 'claude-code', tools: { 'claude-code': { model: 'claude-opus-5-5', effort: 'high', timeoutSec: 60 } } } } });
    assert.equal(okSettings.json.ai.tools['claude-code'].effort, 'high');
    assert.equal((await s.call('PUT', '/api/settings', { session: samS, body: { ai: { tool: 'none' } } })).status, 403);

    // tools, models and levels
    const list = await s.call('GET', '/api/ai/tools', { session });
    assert.deepEqual(list.json.tools.map((t) => t.id).sort(), ['anthropic', 'antigravity', 'claude-code', 'codex', 'gemini', 'generic-cli', 'openai']);
    assert.ok(list.json.tools.find((t) => t.id === 'claude-code').efforts.includes('xhigh'));
    const models = await s.call('GET', '/api/ai/tools/claude-code/models', { session });
    assert.ok(models.json.models.some((m) => m.id === 'claude-opus-5-5' && m.efforts.length === 5));
    assert.equal((await s.call('GET', '/api/ai/tools/nonsense/models', { session })).status, 404);

    // a customer, and a fake Claude Code
    const id = (await s.call('POST', '/api/customers', { session: samS, body: { intake: good() } })).json.customer.id;
    const pv = await s.call('POST', `/api/customers/${id}/ai/preview`, { session: samS });
    assert.ok(pv.json.preview.user.includes('<customer_details>') && !pv.json.preview.user.includes('help@luzonfresh'));
    const answer = JSON.stringify({ setup: { schema: 1, business: { name: 'Hijack', country: 'IN' }, settings: { receiptFooter: 'Salamat po!' }, vocabulary: { customer: ['Suki', 'Sukis'] } }, theme: { shape: 'pill' }, explanation: 'Local words.' });
    const claude = join(tools, 'claude');
    writeFileSync(claude, `#!/usr/bin/env node\nprocess.stdin.resume();process.stdin.on('end',()=>console.log(JSON.stringify({is_error:false,result:${JSON.stringify(answer)}})))\n`);
    chmodSync(claude, 0o755);
    process.env.PATH = tools + delimiter + oldPath;
    const run = await s.call('POST', `/api/customers/${id}/ai/run`, { session: samS, body: {} });
    assert.equal(run.status, 200, JSON.stringify(run.json));
    assert.equal(run.json.proposal.setup.business.name, 'Luzon Fresh Mart', 'the customer\'s own name is put back');
    assert.deepEqual(run.json.changes.map((c) => c.what).sort(), ['The word for "customer"', 'Words at the bottom of a bill'].sort());
    assert.match(run.json.problems.join('\n'), /customer's own details were kept/);
    assert.equal((await s.call('GET', `/api/customers/${id}`, { session: samS })).json.customer.proposal, null, 'nothing is kept until a person accepts');
    const accepted = await s.call('POST', `/api/customers/${id}/ai/accept`, { session: samS, body: { setup: run.json.proposal.setup, theme: run.json.proposal.theme, tool: 'claude-code', explanation: run.json.explanation } });
    assert.equal(accepted.json.customer.proposal.source, 'ai:claude-code');
    assert.equal(accepted.json.customer.proposal.setup.settings.receiptFooter, 'Salamat po!');
    const trail = (await s.call('GET', `/api/audit?customer=${id}`, { session })).json.entries.map((e) => e.action);
    assert.ok(trail.includes('ai.asked') && trail.includes('proposal.saved'));
    // an update needs an administrator and a confirmation, and is written down
    assert.equal((await s.call('POST', '/api/ai/tools/claude-code/update', { session: samS, body: { confirm: true } })).status, 403);
    assert.equal((await s.call('POST', '/api/ai/tools/claude-code/update', { session, body: {} })).status, 400);
  } finally { process.env.PATH = oldPath; rmSync(tools, { recursive: true, force: true }); await s.done(); }
});
