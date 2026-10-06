// End-to-end check of the Get started page, in Chromium: the AI step signs Codex in with an OpenAI API key, and with
// ChatGPT using a one-time code, with nothing to type in a terminal. It starts the app itself on demo data, with
// stand-in-codex.js in place of the real Codex CLI, then stops it:
//   npm install && npm run test:setup        (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-setup-'));
const signedIn = path.join(work, 'codex-signed-in');

// A "codex" launcher for the stand-in, like the one OpenAI's installer puts on the PC.
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile,
      STAND_IN_CODEX_SIGNED_IN_FILE: signedIn,
      STAND_IN_CODEX_SIGN_IN_MS: '2500',
    },
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

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 } });
    await context.grantPermissions(['clipboard-read', 'clipboard-write'], { origin: BASE });
    const page = await context.newPage();
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    await page.goto(BASE + '/', { waitUntil: 'networkidle' });
    await page.locator('.setup-banner', { hasText: 'Sign in with ChatGPT' }).waitFor({ timeout: 30000 });
    await page.locator('.setup-banner').click();
    await page.waitForURL(/\/welcome$/);
    await page.getByText('Codex is installed. Sign in once with your ChatGPT account').waitFor({ timeout: 30000 });
    assert.ok((await page.locator('.rail-step').first().innerText()).includes('demo shop'));
    step('the dashboard asks to finish setting up; Get started shows the data and the AI step');

    await page.getByText('Use an OpenAI API key instead').click();
    assert.strictEqual(await page.locator('label[for="openai-api-key"] .req').count(), 1, 'the key is compulsory');
    assert.strictEqual(await page.locator('input[aria-label="OpenAI API key"]').getAttribute('aria-required'), 'true');
    await page.fill('input[aria-label="OpenAI API key"]', 'sk-test-0000000000000000000000');
    await page.getByRole('button', { name: 'Save the key' }).click();
    await page.locator('#ai-step .pill.good', { hasText: 'Signed in' }).waitFor({ timeout: 30000 });
    assert.strictEqual(fs.readFileSync(signedIn, 'utf8'), 'api-key');
    step('signed in with an OpenAI API key');

    fs.rmSync(signedIn);
    await page.reload({ waitUntil: 'networkidle' });
    await page.getByRole('button', { name: 'Sign in with ChatGPT' }).click();
    await page.locator('#one-time-code').waitFor({ timeout: 30000 });
    assert.strictEqual(await page.locator('#one-time-code').getAttribute('data-code'), 'TEST-12345');
    assert.strictEqual(await page.locator('#one-time-code .ch').count(), 9, 'one box for each letter and number');
    assert.strictEqual(await page.getByRole('link', { name: 'Open the sign-in page' }).getAttribute('href'), 'https://auth.openai.com/codex/device');
    await page.getByRole('button', { name: 'Copy the code' }).click();
    await page.getByRole('button', { name: 'Copied' }).waitFor();
    assert.strictEqual(await page.evaluate(() => navigator.clipboard.readText()), 'TEST-12345');
    await page.setViewportSize({ width: 1366, height: await page.evaluate(() => document.documentElement.scrollHeight) });
    await page.screenshot({ path: `${OUT}/welcome.png` });
    await page.setViewportSize({ width: 1366, height: 900 });
    step('Sign in with ChatGPT shows the page to open and the one-time code, and copies the code');

    await page.locator('#ai-step .pill.good', { hasText: 'Signed in' }).waitFor({ timeout: 30000 });
    assert.strictEqual(fs.readFileSync(signedIn, 'utf8'), 'chatgpt');
    assert.ok(await page.locator('#ai-step.done').count() === 1);
    await page.goto(BASE + '/', { waitUntil: 'networkidle' });
    await page.locator('.hero').waitFor();
    assert.strictEqual(await page.locator('.setup-banner').count(), 0);
    step('once the code is entered the page shows Signed in by itself, and the reminder goes away');

    // Signed out, then signed in again outside the app (e.g. "codex login" in a terminal): opening Settings asks Codex
    // again, and says what Codex says, with the plan.
    fs.rmSync(signedIn);
    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await page.getByRole('button', { name: 'Check again' }).click();
    await page.getByRole('heading', { name: 'Codex is not ready yet' }).waitFor({ timeout: 30000 });
    fs.writeFileSync(signedIn, 'chatgpt');
    await new Promise(r => setTimeout(r, 6000));
    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await page.getByRole('heading', { name: 'Codex is ready' }).waitFor({ timeout: 30000 });
    await page.getByText('Signed in with ChatGPT (Plus).').waitFor();
    step('signed in outside the app: Settings asks Codex again and shows it ready, with the plan');

    await page.setViewportSize({ width: 390, height: 800 });
    await page.goto(BASE + '/welcome', { waitUntil: 'networkidle' });
    await page.locator('#ai-step').waitFor();
    const overflow = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
    assert.ok(overflow <= 0, `sideways scrolling at phone width: ${overflow}px`);
    step('phone width: no sideways scrolling');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e)), []);
    console.log('No console or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
    fs.rmSync(work, { recursive: true, force: true });
  }
})().catch(e => { console.error(e); process.exit(1); });
