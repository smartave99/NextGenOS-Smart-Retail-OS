// End-to-end check of Ask AI, in Chromium: the chat page and the side panel's page share one conversation, the
// built-in questions and typed ones get answers, Stop and New chat work. It starts the app itself on demo data, with
// stand-in-ai.js (slowed down, so Stop can be pressed) in place of a real AI tool, then stops it:
//   npm install && npm run test:ask          (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { png } = require('./png');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

// The side panel's settings file, as the app will read it: the stand-in as a "custom CLI" provider.
const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-ask-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({
  PreferredProvider: 'custom-cli',
  FallbackToOtherProviders: false,
  CustomCli: {
    DisplayName: 'Stand-in AI',
    ExecutablePath: process.execPath,
    // Photos and voice notes go to the stand-in as files, as they go to Codex.
    Arguments: `"${path.join(__dirname, 'stand-in-ai.js')}" {prompt_file} {image_files} {audio_files}`,
    PromptViaStdin: false,
    TimeoutSeconds: 60,
  },
  Panel: { Shortcut: 'Ctrl+Shift+Space' },
}, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile,
      STAND_IN_AI_DELAY_MS: '1200',
      STAND_IN_AI_STREAM_MS: '350',
    },
    stdio: 'ignore',
    detached: process.platform !== 'win32',
  });
  for (let i = 0; i < 180; i++) {
    try { if ((await fetch(BASE + '/')).ok) return app; } catch { /* not up yet */ }
    await new Promise(r => setTimeout(r, 1000));
  }
  throw new Error('The app did not start on ' + BASE);
}

function stopApp(app) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid); } catch { /* gone */ }
}

(async () => {
  const app = await startApp();
  // Chromium's stand-in camera and microphone (a moving picture and a tone), allowed without asking.
  const browser = await chromium.launch({ args: ['--use-fake-device-for-media-stream', '--use-fake-ui-for-media-stream'] });
  const errors = [];
  try {
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 } });
    const watch = (page) => {
      page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
      page.on('pageerror', e => errors.push(e.message));
    };
    const page = await context.newPage();
    watch(page);

    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await page.getByRole('heading', { name: 'Ask anything about your shop' }).waitFor();
    assert.ok((await page.locator('.privacy').innerText()).includes('sales figures and product names only'));
    step('Ask AI starts empty, and says what the AI sees on the demo shop');

    await page.getByRole('button', { name: 'Best sellers' }).click();
    await page.locator('.msg-user', { hasText: 'Which products sell best?' }).waitFor();
    await page.locator('.working').waitFor();
    assert.notStrictEqual(await page.locator('.working').innerText(), 'status');
    // The answer shows as it is written, then stays in the same place when it is done.
    const writing = page.locator('.msg-ai.writing .md');
    await writing.waitFor({ timeout: 30000 });
    assert.ok((await writing.innerText()).startsWith('You asked: “Which products sell best?”'));
    assert.strictEqual(await page.locator('.msg-ai.writing .working').innerText(), 'Writing…');
    const answer = page.locator('.msg-ai:not(.writing) .md').first();
    await answer.waitFor({ timeout: 30000 });
    assert.strictEqual(await page.locator('.msg-ai.writing').count(), 0);
    assert.ok((await answer.innerText()).includes('You asked: “Which products sell best?”'));
    assert.ok(await answer.locator('strong').count() === 1, 'bold figures stay bold');
    assert.ok((await page.locator('.act-meta').first().innerText()).startsWith('Stand-in AI · '));
    step('a suggested question is answered from the shop\'s figures, the words showing as they are written');

    // Quiet actions under the answer: Copy puts the answer on the clipboard; Ask again asks the same question.
    await context.grantPermissions(['clipboard-read', 'clipboard-write'], { origin: BASE });
    const actions = page.locator('.msg-ai:not(.writing) .msg-actions').first();
    await actions.getByRole('button', { name: 'Copy' }).click();
    await actions.getByRole('button', { name: 'Copied' }).waitFor();
    assert.ok((await page.evaluate(() => navigator.clipboard.readText())).includes('**'), 'the answer is copied as written, Markdown and all');
    await actions.getByRole('button', { name: 'Ask again' }).click();
    await page.waitForFunction(() => [...document.querySelectorAll('.msg-user')].filter(m => m.textContent.includes('Which products sell best?')).length === 2);
    await page.locator('.msg-ai:not(.writing) .md').nth(1).waitFor({ timeout: 30000 });
    step('an answer can be copied, and asked again');

    const box = page.locator('.composer textarea');
    await box.fill('Aaj kitna cash aaya?');
    await box.press('Enter');
    await page.locator('.msg-user', { hasText: 'Aaj kitna cash aaya?' }).waitFor();
    assert.strictEqual(await box.inputValue(), '', 'the box is emptied');
    await page.locator('.msg-ai:not(.writing) .md', { hasText: 'Aaj kitna cash aaya?' }).waitFor({ timeout: 30000 });
    step('a typed question is sent with Enter and answered');

    // The side panel's page shows the same conversation, and a question asked there appears here too.
    const panel = await context.newPage();
    watch(panel);
    await panel.setViewportSize({ width: 388, height: 860 });
    await panel.goto(BASE + '/panel', { waitUntil: 'networkidle' });
    await panel.locator('.msg-user', { hasText: 'Aaj kitna cash aaya?' }).waitFor();
    assert.strictEqual(await panel.locator('.msg-user').count(), 3);
    assert.ok(await panel.locator('.mini-stat .v').first().innerText() !== '–', 'today\'s sales are shown');
    assert.strictEqual(await panel.locator('.tools').isVisible(), false, 'the app\'s buttons are only shown inside the app');
    await panel.locator('.composer textarea').fill('Which product is running out?');
    await panel.locator('.composer .send').click();
    await page.locator('.msg-user', { hasText: 'Which product is running out?' }).waitFor({ timeout: 10000 });
    await page.locator('.msg-ai:not(.writing) .md', { hasText: 'Which product is running out?' }).waitFor({ timeout: 30000 });
    await panel.locator('.msg-ai:not(.writing) .md', { hasText: 'Which product is running out?' }).waitFor({ timeout: 30000 });
    await panel.screenshot({ path: `${OUT}/ask-panel.png` });
    step('the side panel shares the conversation both ways');

    // A reader who scrolls up while an answer is written stays there, with "Latest" to jump back.
    await page.setViewportSize({ width: 1366, height: 520 });
    await box.fill('Which product should I stock up on?');
    await box.press('Enter');
    await page.locator('.msg-ai.writing').waitFor();
    await page.evaluate(() => window.scrollTo(0, 0));
    await page.locator('.msg-ai:not(.writing) .md', { hasText: 'Which product should I stock up on?' }).waitFor({ timeout: 30000 });
    assert.ok(await page.evaluate(() => window.scrollY) < 40, 'the page did not pull the reader back down');
    const latest = page.locator('.jump-latest');
    await latest.waitFor({ state: 'visible' });
    await latest.click();
    await page.waitForFunction(() => document.documentElement.scrollHeight - window.scrollY - window.innerHeight < 80);
    await latest.waitFor({ state: 'hidden' });
    await page.setViewportSize({ width: 1366, height: 900 });
    step('reading further up is not interrupted by a new answer; Latest goes back down');

    await box.fill('A slow question');
    await box.press('Enter');
    await page.locator('.composer .send.stop').click();
    await page.locator('.msg-ai', { hasText: 'Stopped.' }).waitFor({ timeout: 10000 });
    assert.strictEqual(await page.locator('.working').count(), 0);
    step('Stop ends a question');

    // A photo from a file, sent with the question: the stand-in AI gets it as Codex would.
    const shelf = path.join(work, 'shelf.png');
    fs.writeFileSync(shelf, png(120, 90, (x, y) => [40 + x, 120, 200 - y]));
    await page.locator('.composer [data-pick]').setInputFiles(shelf);
    await page.locator('.composer-files .composer-file.photo').waitFor();
    await box.fill('What is this?');
    await box.press('Enter');
    await page.locator('.msg-user', { hasText: 'What is this?' }).locator('.msg-files img').waitFor();
    await page.locator('.msg-ai:not(.writing) .md', { hasText: 'I see 1 photo' }).waitFor({ timeout: 30000 });
    assert.strictEqual(await page.locator('.composer-files .composer-file').count(), 0, 'the box is emptied once sent');
    step('a photo from a file goes with the question, and shows in it');

    // A full box: the camera does not open, and says why.
    const four = [1, 2, 3, 4].map(i => {
      const file = path.join(work, `shelf-${i}.png`);
      fs.writeFileSync(file, png(60, 40, () => [i * 40, 90, 160]));
      return file;
    });
    await page.locator('.composer [data-pick]').setInputFiles(four);
    await page.waitForFunction(() => document.querySelectorAll('.composer-files .composer-file').length === 4);
    await page.getByRole('button', { name: 'Take a photo' }).click();
    await page.locator('.composer-note.problem', { hasText: 'Remove one to take a photo' }).waitFor();
    assert.strictEqual(await page.getByRole('dialog').count(), 0, 'the camera opened with the box full');
    for (let i = 0; i < 4; i++) await page.getByRole('button', { name: 'Remove this photo' }).first().click();
    await page.waitForFunction(() => document.querySelectorAll('.composer-files .composer-file').length === 0);
    step('with four photos waiting, the camera does not open, and says why');

    // A photo taken with the camera (Chromium's stand-in camera), sent on its own.
    await page.getByRole('button', { name: 'Take a photo' }).click();
    const camera = page.getByRole('dialog', { name: 'Take a photo for the AI' });
    await camera.getByRole('button', { name: 'Take photo' }).click({ timeout: 20000 });
    await camera.locator('img[alt="The photo just taken"]').waitFor();
    await camera.getByRole('button', { name: 'Use photo' }).click();
    await camera.waitFor({ state: 'detached' });
    assert.strictEqual(await page.evaluate(() => window.srposCamera.running()), 0, 'the camera is off once the photo is used');
    await page.locator('.composer-files .composer-file.photo').waitFor();
    await box.press('Enter');
    await page.locator('.msg-user.only-files .msg-files img').waitFor();
    await page.locator('.msg-ai:not(.writing) .md', { hasText: 'I see 1 photo' }).nth(1).waitFor({ timeout: 30000 });
    step('a photo taken with the camera is sent on its own; the camera stops when the dialog closes');

    // Ask again sends the photo again: the question had no words.
    await page.locator('.msg-ai', { hasText: 'only the photo' }).last().getByRole('button', { name: 'Ask again' }).click();
    await page.locator('.msg-ai:not(.writing) .md', { hasText: 'I see 1 photo' }).nth(2).waitFor({ timeout: 30000 });
    assert.strictEqual(await page.locator('.msg-user.only-files .msg-files img').count(), 2);
    step('Ask again sends the photo again');

    // A voice note, recorded with the microphone (Chromium's stand-in tone) and sent as a WAV file.
    await page.getByRole('button', { name: 'Record a voice question' }).click();
    // The stand-in microphone takes a moment to start, and the recording is only as long as it ran: record for longer than the length asked for.
    await page.waitForTimeout(2200);
    await page.getByRole('button', { name: 'Stop recording' }).click();
    await page.locator('.composer-file.voice', { hasText: /Voice note 0:0[1-9]/ }).waitFor({ timeout: 10000 });
    await box.press('Enter');
    await page.locator('.answer-heard', { hasText: 'Heard: “aaj kitna cash aaya”' }).waitFor({ timeout: 30000 });
    const heardLength = await page.locator('.msg-user .msg-voice audio').evaluate(audio => audio.readyState >= 1
      ? audio.duration
      : new Promise(done => audio.addEventListener('loadedmetadata', () => done(audio.duration), { once: true })));
    assert.ok(heardLength >= 1 && heardLength < 5, `the voice note plays back with its length: ${heardLength} s`);
    step('a voice note is recorded and sent; what the AI heard shows above its answer');

    // A camera that is blocked says what to do.
    await page.evaluate(() => {
      navigator.mediaDevices.getUserMedia = () => Promise.reject(Object.assign(new Error('blocked'), { name: 'NotAllowedError' }));
    });
    await page.getByRole('button', { name: 'Take a photo' }).click();
    assert.ok((await camera.getByRole('alert').innerText()).includes('blocked for this page'));
    await camera.getByRole('button', { name: 'Cancel' }).click();
    await camera.waitFor({ state: 'detached' });
    step('a blocked camera says what to do');

    await page.screenshot({ path: `${OUT}/ask.png` });
    await page.getByRole('button', { name: 'New chat' }).click();
    await page.getByRole('heading', { name: 'Ask anything about your shop' }).waitFor();
    await panel.waitForFunction(() => document.querySelectorAll('.msg-user').length === 0);
    step('New chat clears the conversation everywhere');

    await page.setViewportSize({ width: 390, height: 800 });
    await page.goto(BASE + '/ask', { waitUntil: 'networkidle' });
    await page.locator('.composer').waitFor();
    const overflow = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
    assert.ok(overflow <= 0, `sideways scrolling at phone width: ${overflow}px`);
    step('phone width: no sideways scrolling');

    // A long answer with every kind of Markdown: headings, nested lists, a table, a quote, a rule, code and a link.
    await box.fill('Tell me everything about this week');
    await box.press('Enter');
    const mixed = page.locator('.msg-ai:not(.writing) .md', { hasText: 'Everything about this week' });
    await mixed.waitFor({ timeout: 30000 });
    assert.strictEqual(await mixed.locator('h3').count(), 3);
    assert.strictEqual(await mixed.locator('ul ul li').count(), 2, 'a nested list stays nested');
    assert.strictEqual(await mixed.locator('.md-table-wrap td.num').count(), 4, 'numbers line up on the right');
    assert.strictEqual(await mixed.locator('.md-code .md-code-lang').innerText(), 'sql');
    assert.strictEqual(await mixed.locator('b').count(), 0, 'HTML in an answer is only text');
    assert.strictEqual(await mixed.locator('a[href="https://example.com/prices"][target="_blank"]').count(), 1);
    const sideways = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
    assert.ok(sideways <= 0, `a long answer made the page scroll sideways: ${sideways}px`);
    const codeScrolls = await mixed.locator('.md-code pre').evaluate(pre => pre.scrollWidth > pre.clientWidth);
    assert.ok(codeScrolls, 'long code scrolls inside its own box');
    await mixed.scrollIntoViewIfNeeded();
    await page.screenshot({ path: `${OUT}/ask-mixed-phone.png`, fullPage: true });
    await page.evaluate(() => window.srpos.setTheme('dark'));
    await page.setViewportSize({ width: 1366, height: 900 });
    await page.screenshot({ path: `${OUT}/ask-mixed-dark.png`, fullPage: true });
    await page.evaluate(() => window.srpos.setTheme('auto'));
    step('a long mixed answer keeps its structure, and tables and code scroll inside the column, light and dark');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e)), []);
    console.log('No console or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
    fs.rmSync(work, { recursive: true, force: true });
  }
})().catch(e => { console.error(e); process.exit(1); });
