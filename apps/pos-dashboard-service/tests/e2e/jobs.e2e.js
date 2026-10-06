// End-to-end check of each job's AI, in Chromium: the recommended thinking level for every job on Settings, Codex's
// usage in the menu, a model and thinking level chosen for Ask AI and reaching Codex, the growth plan thinking hard,
// "Back to recommended", a newer model shown after "Refresh the list" (which also removes the saved list an older Codex left),
// and a model typed by name; then Claude Code and Antigravity as the AI tool: their model lists, the thinking levels of each model, the
// version look in Settings and what the panel says of it. It starts the app itself on demo data, with stand-in-codex.js in place of Codex and
// stand-in-tool.js in place of Claude Code and Antigravity:
//   npm install && npm run test:jobs          (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-jobs-'));
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
// The command lines of Claude Code and Antigravity, for when the owner chooses one of them in Advanced settings.
const toolStandIn = path.join(__dirname, 'stand-in-tool.js');
const toolLog = path.join(work, 'tool-calls.log');
const launcher = (name) => {
  const file = path.join(work, process.platform === 'win32' ? name + '.cmd' : name);
  fs.writeFileSync(file, process.platform === 'win32'
    ? `@"${process.execPath}" "${toolStandIn}" ${name} %*\r\n`
    : `#!/bin/sh\nexec "${process.execPath}" "${toolStandIn}" ${name} "$@"\n`, { mode: 0o755 });
  return file;
};
const claudeTool = launcher('claude');
const agyTool = launcher('agy');
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', FallbackToOtherProviders: false, Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));
const runs = path.join(work, 'codex-runs.log');
// Codex's own folder, with the saved copy of the model list an older Codex left, and a file that must stay as it is.
const codexHome = path.join(work, 'codex-home');
const staleCopy = path.join(codexHome, 'models_cache.json');
const authFile = path.join(codexHome, 'auth.json');
fs.mkdirSync(codexHome, { recursive: true });
fs.writeFileSync(staleCopy, JSON.stringify({ fetched_at: '2026-09-20T09:00:00Z', etag: 'old', client_version: '0.0.0-old', models: [] }));
fs.writeFileSync(authFile, '{"tokens":"secret"}');
// A model that comes to the account later: the stand-in lists it once this file exists.
const newModels = path.join(work, 'new-models.json');

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile, STAND_IN_CODEX_LOG: runs, CODEX_HOME: codexHome, STAND_IN_CODEX_MODELS_FILE: newModels, STAND_IN_TOOL_LOG: toolLog },
    stdio: 'ignore',
    detached: process.platform !== 'win32',
  });
  let last = 'no answer';
  for (let i = 0; i < 180; i++) {
    try {
      const answer = await fetch(BASE + '/');
      if (answer.ok) return app;
      last = answer.status + ' ' + (await answer.text()).replace(/\s+/g, ' ').slice(0, 160);
    } catch { /* not up yet */ }
    await new Promise(r => setTimeout(r, 1000));
  }
  stopApp(app); // never leave it running, holding the port for the next try
  throw new Error('The app did not start on ' + BASE + ' (last answer: ' + last + '). A 402 means the licence gate is closed: run the test through with-licence.mjs.');
}

function stopApp(app) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid); } catch { /* gone */ }
}

const lastRun = (job) => fs.readFileSync(runs, 'utf8').trim().split('\n').map(line => JSON.parse(line)).filter(r => r.job === job).pop();
const jobs = () => JSON.parse(fs.readFileSync(settingsFile, 'utf8')).Jobs || {};

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    const row = (name) => page.locator('.setting', { has: page.getByRole('heading', { name, exact: true }) });
    const expected = [['Ask AI', 'Medium'], ['Growth plan', 'High'], ['Poster words', 'Medium'], ['Poster artwork', 'Low'], ['Product photos', 'Low'], ['Learning from chats', 'Low'], ['Product listings', 'Medium'], ['Creatives', 'Medium'], ['Playbooks', 'Medium'], ['Price check', 'Medium']];
    for (const [name, effort] of expected) {
      assert.strictEqual((await row(name).locator('.ai-choice-chip').innerText()).trim(), `${effort} thinking`, name);
    }
    step('Settings lists every job with its recommended thinking: more for the plan, less for photos');

    const meter = page.locator('.sidebar .usage-meter');
    await meter.waitFor({ timeout: 30000 });
    assert.deepStrictEqual(await meter.locator('.usage-row').allInnerTexts().then(rows => rows.map(r => r.replace(/\s+/g, ' ').trim())), ['5 h 23%', 'Week 8%']);
    assert.ok((await meter.getAttribute('title')).startsWith('23% of the 5-hour limit used, resets at'));
    await row('Codex use').locator('.usage-meter').waitFor();
    step('the menu shows how much of Codex\'s limits is used, from Codex itself');

    // A model and thinking level for Ask AI, from Codex's own list.
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    const chip = page.locator('.page-head .ai-choice-chip');
    assert.strictEqual((await chip.innerText()).trim(), 'Medium thinking');
    await page.getByRole('button', { name: 'Add a photo' }).waitFor({ timeout: 30000 });
    assert.strictEqual(await page.getByRole('button', { name: 'Record a voice question' }).count(), 0, "Codex's default model does not listen");
    await chip.click();
    const panel = page.locator('.ai-choice-panel');
    await panel.getByRole('option', { name: 'Stand-in Mini: The quick one.' }).waitFor({ state: 'attached', timeout: 30000 });
    assert.strictEqual(await panel.getByLabel('Model').locator('option').first().innerText(), "Codex's default (Stand-in Large)");
    await panel.getByLabel('Model').selectOption('gpt-stand-in-mini');
    // Only the thinking levels the chosen model offers.
    await page.waitForFunction(() => [...document.querySelectorAll('.ai-choice-panel select')][1]?.options.length === 3);
    assert.deepStrictEqual(await panel.getByLabel('Thinking').locator('option').allInnerTexts(), ['Recommended: Medium', 'Low', 'Medium']);
    await panel.getByLabel('Thinking').selectOption('low');
    await page.waitForFunction(() => document.querySelector('.page-head .ai-choice-chip')?.textContent.includes('Stand-in Mini'));
    await page.screenshot({ path: `${OUT}/ai-choice.png` });
    await panel.getByRole('button', { name: 'Done' }).click();
    assert.strictEqual((await chip.innerText()).trim(), 'Low thinking · Stand-in Mini');
    assert.deepStrictEqual(jobs().Ask, { Model: 'gpt-stand-in-mini', Effort: 'low' });
    // The question box follows the model at once: Mini listens, so a voice question can be recorded.
    await page.getByRole('button', { name: 'Record a voice question' }).waitFor({ timeout: 30000 });
    // Esc, or a click outside it, closes the panel too.
    await chip.click();
    await panel.getByLabel('Thinking').focus();
    await page.keyboard.press('Escape');
    await panel.waitFor({ state: 'detached' });
    await chip.click();
    await panel.waitFor();
    await page.mouse.click(700, 600);
    await panel.waitFor({ state: 'detached' });
    step('a model and thinking level are chosen for Ask AI from Codex\'s list, and kept, and the question box follows it; Esc or a click outside closes it');

    const box = page.locator('.composer textarea');
    await box.fill('How were sales this week?');
    await box.press('Enter');
    await page.locator('.msg-ai:not(.writing) .md', { hasText: 'Stand-in Codex answer.' }).waitFor({ timeout: 30000 });
    assert.deepStrictEqual(lastRun('ask'), { job: 'ask', model: 'gpt-stand-in-mini', effort: 'low' });
    step('Codex answers Ask AI with that model and thinking level');

    // The growth plan thinks hard, with Codex's default model.
    await page.goto(BASE + '/plan', { waitUntil: 'networkidle' });
    assert.strictEqual((await page.locator('.plan-actions .ai-choice-chip').innerText()).trim(), 'High thinking');
    await page.getByRole('button', { name: 'Write my plan' }).click();
    await page.locator('.plan .md', { hasText: 'Stand-in plan.' }).waitFor({ timeout: 60000 });
    assert.deepStrictEqual(lastRun('plan'), { job: 'plan', model: '', effort: 'high' });
    step('the growth plan runs with high thinking and Codex\'s default model');

    // A model without the plan's "high": the nearest level it has is kept, so Codex is never asked for one it lacks.
    const planChip = page.locator('.plan-actions .ai-choice-chip');
    await planChip.click();
    const planPanel = page.locator('.plan-actions .ai-choice-panel');
    await planPanel.getByRole('option', { name: 'Stand-in Mini: The quick one.' }).waitFor({ state: 'attached', timeout: 30000 });
    await planPanel.getByLabel('Model').selectOption('gpt-stand-in-mini');
    await page.waitForFunction(() => document.querySelector('.plan-actions .ai-choice-chip')?.textContent.includes('Stand-in Mini'));
    assert.deepStrictEqual(jobs().Plan, { Model: 'gpt-stand-in-mini', Effort: 'medium' });
    assert.strictEqual((await planChip.innerText()).trim(), 'Medium thinking · Stand-in Mini');
    await planPanel.getByRole('button', { name: 'Back to recommended' }).click();
    await planPanel.getByRole('button', { name: 'Done' }).click();
    // The chip follows the change a moment after the click, over the page's connection: wait for it, do not read it at once.
    await planChip.filter({ hasText: /^\s*High thinking\s*$/ }).waitFor({ timeout: 15000 });
    step('a model without the job\'s thinking level gets the nearest level it has (the plan on Mini: medium)');

    // Back to the recommended one.
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await chip.click();
    await panel.getByRole('button', { name: 'Back to recommended' }).click();
    await panel.getByRole('button', { name: 'Done' }).click();
    await chip.filter({ hasText: /^\s*Medium thinking\s*$/ }).waitFor({ timeout: 15000 });
    assert.strictEqual(jobs().Ask, undefined, 'nothing kept for a recommended job');
    step('"Back to recommended" goes back to the recommended thinking');

    // The list is Codex's own answer, kept for a few minutes. A model that comes to the account later shows after "Refresh the list",
    // which also removes the saved copy of the list an older Codex left, and nothing else in Codex's folder.
    await chip.click();
    const line = panel.locator('.ai-choice-models');
    await page.waitForFunction(() => /lists 2 models/.test(document.querySelector('.ai-choice-models')?.textContent || ''));
    assert.match(await line.innerText(), /^Codex 0\.0\.0 lists 2 models, read (just now|at \d{1,2}:\d{2} [AP]M)\./);
    assert.ok(fs.existsSync(staleCopy), "asking for the list does not touch Codex's saved copy");
    fs.writeFileSync(newModels, JSON.stringify([{ id: 'gpt-stand-in-new', model: 'gpt-stand-in-new', displayName: 'Stand-in New', description: 'The newest one.', hidden: false, isDefault: false,
      defaultReasoningEffort: 'medium', supportedReasoningEfforts: ['low', 'medium', 'high', 'xhigh'].map(e => ({ reasoningEffort: e, description: e })), inputModalities: ['text', 'image'] }]));
    await panel.getByRole('button', { name: 'Done' }).click();
    await chip.click();
    await panel.waitFor();
    assert.strictEqual(await panel.getByRole('option', { name: /Stand-in New/ }).count(), 0, 'the list from a few minutes ago is used, so pages do not start Codex each time');
    await panel.getByRole('button', { name: 'Refresh the list' }).click();
    await panel.getByRole('option', { name: 'Stand-in New: The newest one.' }).waitFor({ state: 'attached', timeout: 30000 });
    await page.waitForFunction(() => /lists 3 models/.test(document.querySelector('.ai-choice-models')?.textContent || ''));
    assert.ok(!fs.existsSync(staleCopy), 'the saved list of an older Codex is removed, so Codex fetches its own');
    assert.ok(fs.existsSync(authFile), "and nothing else in Codex's folder is touched");
    await panel.screenshot({ path: `${OUT}/ai-choice-refreshed.png` });
    step('"Refresh the list" shows a model that came later, says which Codex it asked, and removes the saved list of an older Codex');

    // A model typed by name, checked like a chosen one, kept for the job and reaching Codex.
    await panel.getByLabel('Model').selectOption('+another');
    const typedBox = panel.getByRole('textbox', { name: 'Model name' });
    await typedBox.waitFor();
    assert.strictEqual(await panel.locator('label[for$="-typed"] .req').count(), 1, 'a typed model name is compulsory');
    assert.strictEqual(await typedBox.getAttribute('aria-required'), 'true');
    await typedBox.fill('gpt 6 sol');
    await panel.getByRole('button', { name: 'Use', exact: true }).click();
    await panel.getByText("A model's name has only letters, digits, dots, dashes and underscores").waitFor();
    assert.strictEqual(jobs().Ask, undefined, 'a name that cannot go on a command line is not kept');
    await typedBox.fill('gpt-6.1-sol');
    await typedBox.press('Enter');
    await panel.getByRole('option', { name: 'gpt-6.1-sol (typed in)' }).waitFor({ state: 'attached' });
    await page.waitForFunction(() => document.querySelector('.page-head .ai-choice-chip')?.textContent.includes('gpt-6.1-sol'));
    assert.deepStrictEqual(jobs().Ask, { Model: 'gpt-6.1-sol', Effort: '' });
    assert.strictEqual(await panel.getByRole('textbox', { name: 'Model name' }).count(), 0);
    assert.deepStrictEqual(await panel.getByLabel('Thinking').locator('option').allInnerTexts(), ['Recommended: Medium', 'Low', 'Medium', 'High'], 'a model Codex does not list gets the usual levels');
    await panel.getByRole('button', { name: 'Done' }).click();
    const answers = () => page.locator('.msg-ai:not(.writing) .md', { hasText: 'Stand-in Codex answer.' }).count();
    const before = await answers();
    await box.fill('Which product sells most?');
    await box.press('Enter');
    await page.waitForFunction(n => [...document.querySelectorAll('.msg-ai:not(.writing) .md')].filter(e => e.textContent.includes('Stand-in Codex answer.')).length > n, before, { timeout: 30000 });
    assert.deepStrictEqual(lastRun('ask'), { job: 'ask', model: 'gpt-6.1-sol', effort: 'medium' });
    await chip.click();
    await panel.getByRole('button', { name: 'Back to recommended' }).click();
    await panel.getByRole('button', { name: 'Done' }).click();
    await chip.filter({ hasText: /^\s*Medium thinking\s*$/ }).waitFor({ timeout: 15000 });
    assert.strictEqual(jobs().Ask, undefined);
    step('a model can be typed by name: a bad name is refused, a good one is kept for the job and reaches Codex');

    // Claude Code chosen in Advanced settings, at "max": the chip says what it really runs with, the panel lists Claude's models and the levels of each.
    const original = fs.readFileSync(settingsFile, 'utf8');
    const settingsWith = (changes) => fs.writeFileSync(settingsFile, JSON.stringify({ ...JSON.parse(original), ...changes }, null, 2));
    const modelNames = async () => (await panel.getByLabel('Model').locator('option').allInnerTexts()).map(t => t.trim());
    const levels = () => panel.getByLabel('Thinking').locator('option').allInnerTexts();
    settingsWith({ PreferredProvider: 'claude-cli', ClaudeCli: { Effort: 'max', ExecutablePath: claudeTool } });
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    assert.strictEqual((await chip.innerText()).trim(), 'Max thinking · claude-opus-5');
    await chip.click();
    await panel.getByRole('option', { name: 'Claude Opus 5', exact: true }).waitFor({ state: 'attached', timeout: 30000 }); // the list is asked for when the panel opens
    const claudeModels = await modelNames();
    assert.strictEqual(claudeModels[0], "Claude Code's own choice (claude-opus-5)");
    for (const name of ['Claude Code\'s "opus" (the newest Opus)', 'Claude Opus 5', 'Claude Opus 4.6', 'Claude Haiku 4.5 (fastest, no thinking level)'])
      assert.ok(claudeModels.includes(name), 'the list lacks: ' + name);
    assert.strictEqual(claudeModels.at(-1), 'Another model…');
    assert.strictEqual(await panel.locator('.ai-choice-tool').count(), 0, 'Claude Code has its own list, not the one-line text of the other tools');
    assert.ok((await panel.locator('.ai-choice-models').innerText()).includes('There is no Anthropic key saved (Settings → API keys), so this is the list built into this program, which can be out of date.'));
    assert.strictEqual(await panel.locator('.ai-choice-newer').count(), 0, 'nothing is said of a newer Claude Code before it was looked at');
    assert.deepStrictEqual(await levels(), ['Recommended: Max', 'Low', 'Medium', 'High', 'Extra high', 'Max']);
    await page.screenshot({ path: `${OUT}/ai-choice-claude.png` });
    step('with Claude Code chosen, the chip shows its own thinking level and the panel lists its models (the built-in list, saying so) and its levels');

    // A model with fewer levels offers fewer; a model with none offers none; both are kept for the job.
    await panel.getByLabel('Model').selectOption('claude-opus-4-6');
    await page.waitForFunction(() => [...document.querySelectorAll('.ai-choice-panel select')][1]?.options.length === 5);
    assert.deepStrictEqual(await levels(), ['Recommended: Max', 'Low', 'Medium', 'High', 'Max'], 'Opus 4.6 has no Extra high');
    assert.deepStrictEqual(jobs().Ask, { Model: 'claude-opus-4-6', Effort: '' });
    await panel.getByLabel('Model').selectOption('claude-haiku-4-5');
    await panel.getByLabel('Thinking').waitFor({ state: 'detached' });
    assert.deepStrictEqual(jobs().Ask, { Model: 'claude-haiku-4-5', Effort: '' });
    await panel.getByLabel('Model').selectOption('sonnet');
    await page.waitForFunction(() => [...document.querySelectorAll('.ai-choice-panel select')][1]?.options.length === 6);
    assert.deepStrictEqual(await levels(), ['Recommended: Max', 'Low', 'Medium', 'High', 'Extra high', 'Max'], 'the short name "sonnet" takes every level');
    assert.deepStrictEqual(jobs().Ask, { Model: 'sonnet', Effort: '' });
    step('Claude: a model with fewer thinking levels offers fewer, one with none offers none, and the choice is kept for the job');

    // A model typed by name (a newer one the list does not have yet): a bad name is refused, a good one is kept and shown.
    await panel.getByLabel('Model').selectOption({ label: 'Another model…' });
    await panel.getByRole('textbox', { name: 'Model name' }).fill('bad name!');
    await panel.getByRole('button', { name: 'Use', exact: true }).click();
    assert.ok((await panel.getByRole('alert').innerText()).startsWith("A model's name has only letters, digits, dots, dashes and underscores"));
    await panel.getByRole('textbox', { name: 'Model name' }).fill('claude-opus-9-9');
    await panel.getByRole('button', { name: 'Use', exact: true }).click();
    await page.waitForFunction(() => document.querySelector('.ai-choice-panel select')?.selectedOptions[0]?.textContent.includes('claude-opus-9-9 (typed in)'));
    assert.deepStrictEqual(jobs().Ask, { Model: 'claude-opus-9-9', Effort: '' });
    assert.deepStrictEqual(await levels(), ['Recommended: Max', 'Low', 'Medium', 'High', 'Extra high', 'Max'], 'a model in no list gets the tool\'s levels');
    await panel.getByRole('button', { name: 'Refresh the list' }).click();
    await panel.getByRole('button', { name: 'Refresh the list' }).waitFor();
    assert.ok((await modelNames()).includes('Claude Opus 5'), 'the list is asked for again and is still there');
    await panel.getByRole('button', { name: 'Back to recommended' }).click();
    await page.waitForFunction(() => document.querySelector('.ai-choice-panel select')?.selectedOptions[0]?.textContent.startsWith("Claude Code's own choice"));
    assert.strictEqual(jobs().Ask, undefined);
    await page.keyboard.press('Escape');
    step('Claude: a typed model name is checked and kept, "Refresh the list" asks again, and "Back to recommended" clears the choice');

    // Settings looks at the version once when it opens, and again on request. The newest version comes from npm: when the PC can reach it the card says
    // so (a newer one is out, or this is the newest), else it says it could not be found out. Either way the panel must say the same.
    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    const card = page.locator('#tool-update-card');
    const settled = () => page.waitForFunction(() => { const c = document.querySelector('#tool-update-card'); return c && c.dataset.state !== 'none' && c.dataset.busy === 'false'; }, null, { timeout: 60000 });
    await settled();
    assert.strictEqual(await card.getAttribute('data-tool'), 'claude-cli');
    assert.strictEqual((await card.locator('h3').innerText()).trim(), 'Claude Code, the AI tool');
    const lineOf = async () => (await card.locator('p').first().innerText()).replace(/\s+/g, ' ').trim();
    const claudeState = await card.getAttribute('data-state');
    assert.ok(['available', 'current', 'unknown'].includes(claudeState), claudeState);
    const claudeLine = await lineOf();
    const shapes = { available: /^Version 2\.1\.200 is installed\. A newer one, (\d+\.\d+\.\d+), is out\.$/, current: /^Version 2\.1\.200 is installed\. That is the newest \(\d+\.\d+\.\d+\)\.$/, unknown: /^Version 2\.1\.200 is installed\. The newest version could not be found out just now\.$/ };
    assert.match(claudeLine, shapes[claudeState]);
    assert.ok((await card.innerText()).includes('Runs "claude update", Claude Code\'s own updater.'));
    const calls = () => fs.readFileSync(toolLog, 'utf8').trim().split('\n').map(l => JSON.parse(l));
    const versionAsks = () => calls().filter(c => c.tool === 'claude' && c.args[0] === '--version').length;
    const asked = versionAsks();
    await card.getByRole('button', { name: 'Check again' }).click();
    for (let i = 0; i < 120 && versionAsks() === asked; i++) await new Promise(r => setTimeout(r, 250));
    assert.ok(versionAsks() > asked, 'the version was asked for again');
    await settled();
    assert.ok(!calls().some(c => c.args[0] === 'update'), 'looking never updates');
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await chip.click();
    await panel.locator('.ai-choice-models').waitFor({ timeout: 30000 });
    if (claudeState === 'available') {
      const newer = claudeLine.match(shapes.available)[1];
      assert.ok((await panel.locator('.ai-choice-newer').innerText()).includes(`Claude Code ${newer} is out.`));
      assert.strictEqual(await panel.locator('.ai-choice-newer a').getAttribute('href'), 'settings#updates');
    } else {
      assert.strictEqual(await panel.locator('.ai-choice-newer').count(), 0, 'no newer Claude Code to say');
    }
    await page.keyboard.press('Escape');
    step(`Settings looks at Claude Code's version (${claudeState}) and again on request, never updating by itself; the panel says the same`);

    // Antigravity chosen: its own list from "agy models", its three levels, and what is said when it is not on the PC.
    settingsWith({ PreferredProvider: 'antigravity-cli', Antigravity: { ExecutablePath: agyTool } });
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    assert.strictEqual((await chip.innerText()).trim(), 'Medium thinking');
    await chip.click();
    await panel.getByRole('option', { name: 'stand-in-small: fast' }).waitFor({ state: 'attached', timeout: 30000 });
    assert.deepStrictEqual(await modelNames(), ["Antigravity's own choice", 'stand-in-large: the strongest', 'stand-in-small: fast', 'Another model…']);
    assert.ok((await panel.locator('.ai-choice-models').innerText()).includes('The list is Antigravity\'s own (from "agy models").'));
    assert.deepStrictEqual(await levels(), ['Recommended: Medium', 'Low', 'Medium', 'High']);
    await panel.getByLabel('Model').selectOption('stand-in-small');
    await page.waitForFunction(() => document.querySelector('.page-head .ai-choice-chip')?.textContent.includes('stand-in-small'));
    assert.deepStrictEqual(jobs().Ask, { Model: 'stand-in-small', Effort: '' });
    assert.strictEqual((await chip.innerText()).trim(), 'Medium thinking · stand-in-small');
    await page.keyboard.press('Escape');
    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await settled();
    assert.strictEqual(await card.getAttribute('data-tool'), 'antigravity-cli');
    assert.strictEqual(await card.getAttribute('data-state'), 'unknown', 'Antigravity has no place to ask for its newest version');
    assert.strictEqual(await lineOf(), 'Version 1.4.2 is installed. The newest version could not be found out just now.');
    assert.ok((await card.innerText()).includes(process.platform === 'win32' ? "Runs Google's official installer again" : 'Update Antigravity the way you installed it.'));
    step('Antigravity: its own list and three levels in the panel, its version in Settings');

    settingsWith({ PreferredProvider: 'antigravity-cli', Antigravity: { ExecutablePath: path.join(work, 'no-such-agy') } });
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await chip.click();
    // The list is kept for a few minutes (opening the panel is quick), so the new place of the tool is looked at when the owner asks again.
    await panel.getByRole('button', { name: 'Refresh the list' }).click();
    await page.waitForFunction(() => document.querySelector('.ai-choice-models')?.textContent.startsWith('Antigravity is not on this PC'), null, { timeout: 30000 });
    assert.deepStrictEqual(await modelNames(), ["Antigravity's own choice", 'Another model…']);
    assert.ok((await panel.locator('.ai-choice-models').innerText()).startsWith('Antigravity is not on this PC. Install it in PowerShell with:'));
    await page.keyboard.press('Escape');
    fs.writeFileSync(settingsFile, original);
    step('Antigravity not on the PC: the panel says so and how to install it, and the model can still be typed');

    await page.setViewportSize({ width: 390, height: 844 });
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await chip.click();
    await panel.waitFor();
    const box2 = await panel.boundingBox();
    assert.ok(box2.x >= 0 && box2.x + box2.width <= 390, 'the panel fits the phone\'s width');
    const overflow = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
    assert.ok(overflow <= 0, `no sideways scrolling (${overflow}px)`);
    await page.screenshot({ path: `${OUT}/ai-choice-phone.png` });
    step('phone width: the panel fits, no sideways scrolling');

    assert.deepStrictEqual(errors, [], 'no console errors');
    console.log('No console errors or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
  }
})().catch(e => {
  console.error(e);
  process.exit(1);
});
