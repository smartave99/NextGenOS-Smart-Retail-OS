import { test } from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, writeFileSync, chmodSync, rmSync, existsSync, mkdirSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, delimiter } from 'node:path';
import http from 'node:http';
import { cleanToolConfig, claudeArgs, codexArgs, antigravityArgs, EFFORTS, NEVER } from '../lib/ai/options.mjs';
import { listModels, toolStatus, checkUpdate, updateTool, updateHow, readCodexModels, latestVersion, CLAUDE_BUILT_IN } from '../lib/ai/control.mjs';

const home = mkdtempSync(join(tmpdir(), 'studio-ctl-home-'));
process.env.SETUP_STUDIO_HOME = home;
delete process.env.ANTHROPIC_API_KEY; delete process.env.OPENAI_API_KEY; delete process.env.GEMINI_API_KEY; delete process.env.GOOGLE_API_KEY;

const tools = () => {
  const dir = mkdtempSync(join(tmpdir(), 'studio-ctl-tools-'));
  const make = (name, body) => { const p = join(dir, name); writeFileSync(p, `#!/usr/bin/env node\n${body}\n`); chmodSync(p, 0o755); return p; };
  return { dir, make, done: () => rmSync(dir, { recursive: true, force: true }) };
};
const onPath = async (dir, work, { only = false } = {}) => { const old = process.env.PATH; process.env.PATH = only ? dir + delimiter + old.split(delimiter).filter((d) => !existsSync(join(d, 'claude')) && !existsSync(join(d, 'codex'))).join(delimiter) : dir + delimiter + old; try { return await work(); } finally { process.env.PATH = old; } };
async function service(handler) {
  const seen = [];
  const server = http.createServer((req, res) => { seen.push({ url: req.url, headers: req.headers }); const r = handler(req); res.writeHead(r.status ?? 200, { 'content-type': 'application/json' }); res.end(JSON.stringify(r.json)); });
  await new Promise((r) => server.listen(0, '127.0.0.1', r));
  return { seen, url: `http://127.0.0.1:${server.address().port}`, close: () => new Promise((r) => server.close(r)) };
}

test('settings of a tool are checked: the model, how hard to think (from the tool\'s own levels), budget, time; the rest is named and dropped', () => {
  const ok = cleanToolConfig('claude-code', { model: 'claude-opus-5-5', effort: 'XHIGH', fallbackModel: 'claude-sonnet-5-5', maxBudgetUsd: '2.5', timeoutSec: 120 });
  assert.deepEqual(ok.problems, []);
  assert.deepEqual(ok.value, { model: 'claude-opus-5-5', effort: 'xhigh', fallbackModel: 'claude-sonnet-5-5', maxBudgetUsd: 2.5, timeoutSec: 120 });
  const bad = cleanToolConfig('claude-code', { model: 'bad model; rm -rf /', effort: 'ultra', maxBudgetUsd: -1, timeoutSec: 5, fallbackModel: '$(x)' });
  assert.deepEqual(bad.value, {});
  assert.equal(bad.problems.length, 5);
  assert.ok(cleanToolConfig('codex', { effort: 'minimal' }).problems.length === 0, 'Codex has a minimal level');
  assert.ok(cleanToolConfig('claude-code', { effort: 'minimal' }).problems.length === 1, 'Claude does not');
  assert.ok(cleanToolConfig('gemini', { effort: 'high' }).problems.length === 1, 'Gemini has a thinking budget, not levels');
  assert.deepEqual(cleanToolConfig('gemini', { thinkingBudget: -1 }).value, { thinkingBudget: -1 });
  assert.equal(cleanToolConfig('gemini', { thinkingBudget: 99999 }).problems.length, 1);
  // known levels from the tool itself can replace the built-in ones
  assert.deepEqual(cleanToolConfig('codex', { effort: 'ultra' }, { knownEfforts: ['ultra', 'low'] }).value, { effort: 'ultra' });
});

test('options that would let a tool act on this PC are never passed, whoever asks; the useful ones are', () => {
  for (const flag of ['--dangerously-skip-permissions', '--permission-mode', '--tools', '--allowedTools', '--add-dir', '--mcp-config', '--sandbox', '--full-auto', '--image', '--cd']) {
    assert.ok(NEVER.includes(flag), flag);
    const r = cleanToolConfig('claude-code', { extraArgs: [flag, 'x'] });
    assert.equal(r.value.extraArgs, undefined);
    assert.match(r.problems[0], /never passed/);
  }
  assert.deepEqual(cleanToolConfig('claude-code', { extraArgs: ['--betas', 'some-beta-2026-01-01', '--no-chrome'] }).value.extraArgs, ['--betas', 'some-beta-2026-01-01', '--no-chrome']);
  assert.match(cleanToolConfig('claude-code', { extraArgs: ['--weird'] }).problems[0], /not one this tool offers/);
  assert.match(cleanToolConfig('claude-code', { extraArgs: ['--betas', '$(whoami)'] }).problems[0], /short value/);
  assert.match(cleanToolConfig('claude-code', { extraArgs: ['--betas', '--model'] }).problems[0], /short value/);
  assert.deepEqual(cleanToolConfig('codex', { extraArgs: ['-c', 'model_verbosity=low'] }).value.extraArgs, ['-c', 'model_verbosity=low']);
  assert.match(cleanToolConfig('codex', { extraArgs: ['-c', 'sandbox_mode=danger-full-access'] }).problems[0], /may set only/);
});

test('every choice becomes the tool\'s own option, and the safe ones are always there', () => {
  const all = { model: 'claude-opus-5-5', effort: 'high', fallbackModel: 'claude-sonnet-5-5', maxBudgetUsd: 3, extraArgs: ['--betas', 'b-1'] };
  assert.deepEqual(claudeArgs(all), ['-p', '--bare', '--output-format', 'json', '--tools', '', '--no-session-persistence', '--disable-slash-commands', '--strict-mcp-config', '--model', 'claude-opus-5-5', '--effort', 'high', '--fallback-model', 'claude-sonnet-5-5', '--max-budget-usd', '3', '--betas', 'b-1']);
  assert.deepEqual(claudeArgs({}), ['-p', '--bare', '--output-format', 'json', '--tools', '', '--no-session-persistence', '--disable-slash-commands', '--strict-mcp-config']);
  assert.deepEqual(codexArgs({ model: 'gpt-x', effort: 'xhigh' }), ['exec', '--skip-git-repo-check', '--sandbox', 'read-only', '--ephemeral', '--color', 'never', '--model', 'gpt-x', '-c', 'model_reasoning_effort=xhigh', '-']);
  assert.deepEqual(antigravityArgs({ model: 'm', effort: 'low' }, 90), ['--output-format', 'json', '--disable-slash-commands', '--sandbox', '--print-timeout', '90s', '--model', 'm', '--effort', 'low']);
  // whatever is in a saved setting, a dangerous option never reaches the command line
  const hostile = claudeArgs({ extraArgs: ['--dangerously-skip-permissions'], model: 'x y', effort: 'ultra' });
  assert.ok(!hostile.includes('--dangerously-skip-permissions') && !hostile.includes('--model') && !hostile.includes('--effort'));
  assert.ok(EFFORTS['claude-code'].includes('xhigh') && EFFORTS.codex.includes('minimal'));
});

test('the models of Claude come live from Anthropic with the levels each takes, or from the built-in list, said plainly', async () => {
  const none = await listModels('claude-code', {});
  assert.equal(none.source, 'built-in');
  assert.match(none.note, /can be out of date/);
  assert.ok(none.models.some((m) => m.id === 'opus' && m.source === 'tool'));
  const haiku = none.models.find((m) => m.id === 'claude-haiku-4-5');
  assert.deepEqual(haiku.efforts, [], 'a model with no thinking level shows none');
  const opus = none.models.find((m) => m.id === 'claude-opus-5-5');
  assert.deepEqual(opus.efforts.map((e) => e.id), ['low', 'medium', 'high', 'xhigh', 'max']);
  assert.equal(opus.defaultEffort, 'medium');
  assert.ok(CLAUDE_BUILT_IN.length >= 10);

  const svc = await service(() => ({ json: { data: [
    { id: 'claude-opus-5-5', display_name: 'Claude Opus 5.5', max_input_tokens: 1000000, max_tokens: 128000, capabilities: { effort: { supported: true, low: { supported: true }, medium: { supported: true }, high: { supported: true }, xhigh: { supported: true }, max: { supported: true } } } },
    { id: 'claude-haiku-4-5', display_name: 'Claude Haiku 4.5', max_input_tokens: 200000, max_tokens: 64000, capabilities: { effort: { supported: false, low: { supported: false }, medium: { supported: false }, high: { supported: false }, max: { supported: false } } } },
    { id: 'claude-opus-4-6', display_name: 'Claude Opus 4.6', max_input_tokens: 1000000, max_tokens: 128000, capabilities: { effort: { supported: true, low: { supported: true }, medium: { supported: true }, high: { supported: true }, xhigh: { supported: false }, max: { supported: true } } } },
  ], has_more: false, first_id: 'claude-opus-5-5', last_id: 'claude-opus-4-6' } }));
  process.env.ANTHROPIC_API_KEY = 'sk-ant-test-123456';
  try {
    const live = await listModels('claude-code', { config: { baseUrl: svc.url } });
    assert.equal(live.source, 'anthropic');
    assert.equal(svc.seen[0].headers['x-api-key'], 'sk-ant-test-123456');
    const byId = Object.fromEntries(live.models.map((m) => [m.id, m]));
    assert.deepEqual(byId['claude-opus-5-5'].efforts.map((e) => e.id), ['low', 'medium', 'high', 'xhigh', 'max']);
    assert.deepEqual(byId['claude-haiku-4-5'].efforts, []);
    assert.deepEqual(byId['claude-opus-4-6'].efforts.map((e) => e.id), ['low', 'medium', 'high', 'max']);
    assert.match(byId['claude-opus-5-5'].notes, /1000K tokens in, 128K out/);
    assert.ok(byId.opus, 'the tool\'s own short names stay');
    const api = await listModels('anthropic', { config: { baseUrl: svc.url } });
    assert.equal(api.models.length, 3);
  } finally { delete process.env.ANTHROPIC_API_KEY; await svc.close(); }
});

test('the models of Codex are Codex\'s own list with its levels; with no list the Studio says so', async () => {
  const codexHome = mkdtempSync(join(tmpdir(), 'studio-codex-home-'));
  try {
    const env = { ...process.env, CODEX_HOME: codexHome };
    const empty = await listModels('codex', { env });
    assert.equal(empty.models.length, 0);
    assert.match(empty.note, /not written its model list yet/);
    writeFileSync(join(codexHome, 'models_cache.json'), JSON.stringify({ client_version: '0.158.0', models: [
      { slug: 'gpt-5-codex', display_name: 'GPT-5 Codex', description: 'Best for code', supported_reasoning_levels: [{ effort: 'low', description: 'x' }, { effort: 'medium' }, { effort: 'high' }], default_reasoning_level: 'medium', visibility: 'list' },
      { slug: 'hidden-one', visibility: 'hide' },
      { id: 'plain-id', supportedReasoningEfforts: ['minimal', 'low'] },
    ] }));
    const r = await listModels('codex', { env });
    assert.deepEqual(r.models.map((m) => m.id), ['gpt-5-codex', 'plain-id']);
    assert.deepEqual(r.models[0].efforts.map((e) => e.id), ['low', 'medium', 'high']);
    assert.equal(r.models[0].defaultEffort, 'medium');
    assert.deepEqual(r.models[1].efforts.map((e) => e.id), ['minimal', 'low']);
    assert.match(r.note, /from Codex 0\.158\.0/);
    writeFileSync(join(codexHome, 'models_cache.json'), '{ broken');
    assert.equal(readCodexModels(env), null);
  } finally { rmSync(codexHome, { recursive: true, force: true }); }
});

test('models of OpenAI-compatible services and Gemini come live from the service with the key in a header', async () => {
  const oa = await service(() => ({ json: { data: [{ id: 'gpt-5' }, { id: 'o3-mini' }, { id: 'text-embedding-3' }] } }));
  const gm = await service(() => ({ json: { models: [{ name: 'models/gemini-3.5-flash', displayName: 'Gemini 3.5 Flash', supportedGenerationMethods: ['generateContent'], thinking: true }, { name: 'models/embedding-001', supportedGenerationMethods: ['embedContent'] }] } }));
  process.env.OPENAI_API_KEY = 'sk-test-key-123456'; process.env.GEMINI_API_KEY = 'gem-test-key-123456';
  try {
    const o = await listModels('openai', { config: { baseUrl: oa.url + '/v1' } });
    assert.deepEqual(o.models.map((m) => m.id), ['gpt-5', 'o3-mini', 'text-embedding-3']);
    assert.deepEqual(o.models[0].efforts.map((e) => e.id), ['minimal', 'low', 'medium', 'high']);
    assert.deepEqual(o.models[2].efforts, []);
    assert.equal(oa.seen[0].headers.authorization, 'Bearer sk-test-key-123456');
    const g = await listModels('gemini', { config: { baseUrl: gm.url + '/v1beta' } });
    assert.deepEqual(g.models.map((m) => m.id), ['gemini-3.5-flash']);
    assert.equal(gm.seen[0].headers['x-goog-api-key'], 'gem-test-key-123456');
    assert.ok(!gm.seen[0].url.includes('gem-test-key'));
    const down = await listModels('openai', { config: { baseUrl: 'http://127.0.0.1:9/v1' } });
    assert.equal(down.models.length, 0);
    assert.match(down.note, /could not be read/);
  } finally { delete process.env.OPENAI_API_KEY; delete process.env.GEMINI_API_KEY; await oa.close(); await gm.close(); }
  assert.match((await listModels('antigravity', {})).note, /does not publish a model list/);
  assert.equal((await listModels('generic-cli', {})).models.length, 0);
});

test('a tool\'s status says where it is, its version and whether it can be used; an API says nothing to install', async () => {
  const { dir, make, done } = tools();
  try {
    make('codex', `if(process.argv[2]==='--version'){console.log('codex-cli 0.158.0')}else if(process.argv[2]==='login'){console.log('Logged in using ChatGPT');}`);
    make('claude', `console.log('2.1.289 (Claude Code)')`);
    const c = await onPath(dir, () => toolStatus('codex', {}));
    assert.deepEqual([c.found, c.version, c.signedIn], [true, '0.158.0', true]);
    const cl = await onPath(dir, () => toolStatus('claude-code', {}));
    assert.deepEqual([cl.found, cl.version, cl.signedIn], [true, '2.1.289', false], 'no key yet: it cannot be used');
    process.env.ANTHROPIC_API_KEY = 'sk-ant-test-123456';
    try { assert.equal((await onPath(dir, () => toolStatus('claude-code', {}))).signedIn, true); } finally { delete process.env.ANTHROPIC_API_KEY; }
    const gone = await onPath(dir, () => toolStatus('antigravity', {}), { only: true });
    assert.deepEqual([gone.found, gone.version], [false, null]);
    assert.equal((await toolStatus('openai', {})).kind, 'api');
    const gen = make('mytool', `console.log('mytool v3.4.5')`);
    assert.equal((await toolStatus('generic-cli', { config: { command: gen } })).version, '3.4.5');
  } finally { done(); }
});

test('an update is looked for in the vendor\'s own place, compared, and only made when asked; the result is checked by asking the tool again', async () => {
  const { dir, make, done } = tools();
  const state = join(dir, 'installed.txt');
  writeFileSync(state, '2.1.289');
  make('claude', `const fs=require('fs');const a=process.argv[2];if(a==='--version'){console.log(fs.readFileSync(${JSON.stringify(state)},'utf8')+' (Claude Code)')}else if(a==='update'){fs.writeFileSync(${JSON.stringify(state)},'2.2.0');console.log('Updated to 2.2.0')}`);
  const feed = await service((req) => ({ json: req.url.startsWith('/claude') ? { version: '2.2.0' } : { tag_name: 'rust-v0.160.0' } }));
  const sources = { claude: feed.url + '/claude/latest', codex: [feed.url + '/codex/latest'] };
  try {
    const check = await onPath(dir, () => checkUpdate('claude-code', { sources }));
    assert.deepEqual([check.update, check.latest, check.version, check.canUpdate], ['available', '2.2.0', '2.1.289', true]);
    assert.match(check.how.text, /claude update/);
    const result = await onPath(dir, () => updateTool('claude-code', {}));
    assert.deepEqual([result.before, result.after, result.changed], ['2.1.289', '2.2.0', true]);
    assert.match(result.output, /Updated to 2.2.0/);
    const again = await onPath(dir, () => checkUpdate('claude-code', { sources }));
    assert.equal(again.update, 'current');
    assert.equal(await latestVersion('codex', { sources }), '0.160.0');
    // an alpha or odd tag is not "the latest"
    const odd = await service(() => ({ json: { tag_name: 'rust-v0.161.0-alpha.3' } }));
    try { assert.equal(await latestVersion('codex', { sources: { codex: [odd.url] } }), null); } finally { await odd.close(); }
    assert.equal(await latestVersion('codex', { sources: { codex: ['http://127.0.0.1:9/none'] } }), null, 'no internet is "unknown", not an error');
    const missing = await onPath(dir, () => checkUpdate('codex', {}), { only: true });
    assert.equal(missing.update, 'install');
    assert.match(missing.note, /Install Codex/);
    assert.equal((await checkUpdate('gemini', {})).update, 'none');
  } finally { await feed.close(); done(); }
});

test('an update that does not finish, or leaves the tool as it was, is reported as it is; a tool the Studio cannot update says what to do', async () => {
  const { dir, make, done } = tools();
  try {
    make('claude', `if(process.argv[2]==='--version')console.log('1.0.0');else{console.error('network down');process.exit(3)}`);
    await assert.rejects(() => onPath(dir, () => updateTool('claude-code', {})), /did not finish \(it stopped with code 3\)/);
    make('claude', `if(process.argv[2]==='--version')console.log('1.0.0');else console.log('already latest')`);
    const same = await onPath(dir, () => updateTool('claude-code', {}));
    assert.equal(same.changed, false);
    await assert.rejects(() => updateTool('generic-cli', {}), (e) => e.code === 'manual');
    assert.equal(updateHow('openai').command, null);
    assert.match(updateHow('antigravity', {}).text, /Update Antigravity|installer/);
    // Codex on this system: npm when it is there, a plain instruction when it is not
    if (process.platform !== 'win32') {
      make('npm', 'console.log("ok")');
      assert.match(await onPath(dir, () => updateHow('codex').command), /npm install -g @openai\/codex@latest/);
      assert.equal(await onPath(dir, () => updateHow('codex', { PATH: '/nonexistent' }).command), null);
    }
  } finally { done(); }
});

test.after(() => { rmSync(home, { recursive: true, force: true }); });
