// End-to-end check of past chats, in Chromium: the chat going on is kept after every answer (so stopping the app at
// once, as the app window does, loses nothing) and a new chat starts another; listed newest first, found by its words,
// opened and asked again, deleted one by one or all at once, and not kept when the owner turns it off. Chats older
// than six months are never shown, and are deleted when the app starts.
// It starts the app itself on demo data, with stand-in-ai.js in place of a real AI tool:
//   npm install && npm run test:history          (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-history-'));
const settingsFile = path.join(work, 'settings.json');
const dataFolder = path.join(work, 'data');
fs.writeFileSync(settingsFile, JSON.stringify({
  PreferredProvider: 'custom-cli',
  FallbackToOtherProviders: false,
  CustomCli: {
    DisplayName: 'Stand-in AI',
    ExecutablePath: process.execPath,
    Arguments: `"${path.join(__dirname, 'stand-in-ai.js')}" {prompt_file}`,
    PromptViaStdin: false,
    TimeoutSeconds: 60,
  },
}, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: dataFolder }));

// A chat from eight months ago, and a damaged copy of its month kept aside.
const long = new Date();
long.setDate(1);
long.setMonth(long.getMonth() - 8);
const longMonth = long.toISOString().slice(0, 7);
const oldFile = path.join(dataFolder, 'Memory', 'Chats', `chats-${longMonth}.json`);
fs.mkdirSync(path.dirname(oldFile), { recursive: true });
fs.writeFileSync(oldFile, JSON.stringify([{
  Id: `${longMonth.replace('-', '')}01120000-abcdef`,
  Title: 'A question from long ago',
  Started: long.toISOString(),
  Ended: long.toISOString(),
  Messages: [{ Role: 'Owner', Text: 'A question from long ago', At: long.toISOString() }],
}]));
fs.writeFileSync(oldFile + '.bad', '[ a damaged copy');

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile },
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

function stopApp(app, signal = 'SIGTERM') {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid, signal); } catch { /* gone */ }
}

async function untilDown() {
  for (let i = 0; i < 60; i++) {
    try { await fetch(BASE + '/'); } catch { return; }
    await new Promise(r => setTimeout(r, 500));
  }
  throw new Error('The app did not stop');
}

(async () => {
  let app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));
    const box = page.locator('.composer textarea');
    const ask = async (question) => {
      await box.fill(question);
      await box.press('Enter');
      await page.locator('.msg-ai', { hasText: question.replace(/^Remember that /, '') }).last().waitFor({ timeout: 30000 });
    };
    const titles = () => page.locator('.past-list .past-title').allInnerTexts();

    await page.goto(BASE + '/ask/past', { waitUntil: 'networkidle' });
    await page.locator('.past-list .memory-empty', { hasText: 'No past chats yet.' }).waitFor();
    for (let i = 0; i < 40 && (fs.existsSync(oldFile) || fs.existsSync(oldFile + '.bad')); i++) await new Promise(r => setTimeout(r, 250));
    assert.ok(!fs.existsSync(oldFile) && !fs.existsSync(oldFile + '.bad'), 'the chat from eight months ago is deleted');
    step('Past chats starts empty: a chat older than six months is not shown, and was deleted when the app started');

    // The chat going on is kept after every answer, as one past chat; a new chat starts another.
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await ask('How much sugar did we sell last week?');
    await page.goto(BASE + '/ask/past', { waitUntil: 'networkidle' });
    await page.locator('.past-list .past-title', { hasText: 'How much sugar did we sell last week?' }).waitFor();
    assert.ok((await page.locator('.past-list .m-meta').first().innerText()).endsWith('1 question'));
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await ask('Which products sell best?');
    await page.getByRole('button', { name: 'New chat' }).click();
    await ask('Remember that I like short answers');
    await ask('What should I reorder?');
    await page.getByRole('button', { name: 'New chat' }).click();
    await page.getByRole('link', { name: 'Past chats' }).click();
    await page.waitForURL('**/ask/past');
    await page.locator('.past-list .past-title').nth(1).waitFor();
    assert.deepStrictEqual(await titles(), ['Remember that I like short answers', 'How much sugar did we sell last week?']);
    assert.ok((await page.locator('.past-list .m-meta').first().innerText()).endsWith('2 questions'));
    step('the chat going on is kept after every answer, as one past chat; a new chat starts another; newest first');

    // Found by its words.
    const search = page.getByLabel('Search past chats');
    await search.fill('sugar week');
    await page.getByRole('button', { name: 'Search', exact: true }).click();
    await page.getByRole('heading', { name: 'Found for “sugar week”' }).waitFor();
    assert.deepStrictEqual(await titles(), ['How much sugar did we sell last week?']);
    assert.ok((await page.locator('.past-snippet').innerText()).toLowerCase().includes('sugar'));
    await search.fill('coffee');
    await page.getByRole('button', { name: 'Search', exact: true }).click();
    await page.locator('.past-list .memory-empty', { hasText: 'Nothing found.' }).waitFor();
    await page.getByRole('button', { name: 'Show the latest' }).click();
    await page.locator('.past-list .past-title').nth(1).waitFor();
    await page.screenshot({ path: `${OUT}/past-chats.png`, fullPage: true });
    step('a search finds chats with all its words; nothing found says so');

    // Opened, and asked again.
    await page.getByRole('link', { name: 'How much sugar did we sell last week?' }).click();
    await page.getByRole('heading', { name: 'How much sugar did we sell last week?' }).waitFor();
    assert.strictEqual(await page.locator('.past-thread .msg-user').count(), 2);
    assert.ok((await page.locator('.past-thread .msg-ai').first().innerText()).includes('You asked: “How much sugar did we sell last week?”'));
    await page.screenshot({ path: `${OUT}/past-chat.png`, fullPage: true });
    await page.locator('.ask-again').getByRole('button', { name: 'Which products sell best?' }).click();
    await page.waitForURL('**/ask');
    await page.locator('.msg-ai:not(.writing) .md', { hasText: 'You asked: “Which products sell best?”' }).waitFor({ timeout: 30000 });
    step('a past chat opens, and its question is asked again in Ask AI');

    // Deleted one by one.
    await page.goto(BASE + '/ask/past', { waitUntil: 'networkidle' });
    await page.getByRole('link', { name: 'Remember that I like short answers' }).click();
    await page.getByRole('button', { name: 'Delete' }).click();
    await page.getByRole('button', { name: 'Delete this chat' }).click();
    await page.waitForURL('**/ask/past');
    await page.locator('.past-list .past-title').first().waitFor();
    // The chat asked again goes on, so it is kept too.
    assert.deepStrictEqual(await titles(), ['Which products sell best?', 'How much sugar did we sell last week?']);
    step('a past chat is deleted after asking first');

    // Turned off, then all deleted, on the Memory page.
    await page.goto(BASE + '/memory', { waitUntil: 'networkidle' });
    const keep = page.getByRole('radiogroup', { name: 'Keep past chats' });
    assert.strictEqual(await keep.getByRole('radio', { name: 'On' }).getAttribute('aria-checked'), 'true');
    await page.getByText('2 are kept now.').waitFor();
    await keep.getByRole('radio', { name: 'Off' }).click();
    await page.waitForFunction(() => document.querySelector('[aria-label="Keep past chats"] .seg-item.on')?.textContent === 'Off');
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await ask('Is the milk in stock?');
    await page.getByRole('button', { name: 'New chat' }).click();
    await page.goto(BASE + '/ask/past', { waitUntil: 'networkidle' });
    await page.locator('.past-list .past-title').nth(1).waitFor();
    assert.deepStrictEqual(await titles(), ['Which products sell best?', 'How much sugar did we sell last week?'], 'not kept while turned off');
    await page.getByRole('link', { name: 'Which products sell best?' }).click();
    await page.getByRole('heading', { name: 'Which products sell best?' }).waitFor();
    assert.strictEqual(await page.locator('.past-thread .msg-user').count(), 1, 'a question asked while turned off was kept');
    await page.goto(BASE + '/memory', { waitUntil: 'networkidle' });
    await page.goto(BASE + '/memory', { waitUntil: 'networkidle' });
    await page.getByRole('button', { name: 'Delete all past chats' }).click();
    await page.getByRole('button', { name: 'Delete them all' }).click();
    await page.getByText('None are kept now.').waitFor();
    const month = fs.readdirSync(path.join(dataFolder, 'Memory', 'Chats')).filter(f => f.endsWith('.json'));
    assert.deepStrictEqual(month, [], 'the chat files are gone');
    step('keeping chats can be turned off, and all of them deleted');

    // Stopped at once in the middle of a chat, as the app window stops the dashboard when it closes, then started again.
    await keep.getByRole('radio', { name: 'On' }).click();
    await page.waitForFunction(() => document.querySelector('[aria-label="Keep past chats"] .seg-item.on')?.textContent === 'On');
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await ask('Is the rice in stock?');
    await page.goto('about:blank');
    stopApp(app, 'SIGKILL');
    await untilDown();
    app = await startApp();
    await page.goto(BASE + '/ask/past', { waitUntil: 'networkidle' });
    await page.locator('.past-list .past-title', { hasText: 'Is the rice in stock?' }).waitFor();
    step('stopped at once in the middle of a chat and started again, the chat is in Past chats');

    await page.setViewportSize({ width: 390, height: 844 });
    await page.goto(BASE + '/ask/past', { waitUntil: 'networkidle' });
    const overflow = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
    assert.ok(overflow <= 0, `no sideways scrolling (${overflow}px)`);
    step('phone width: no sideways scrolling');

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
