// End-to-end check of the dashboard's part of automatic updates, in Chromium: what the Windows app found when it looked for
// a newer version (its status.json), shown in the bell and on the Updates card in Settings, and the messages the card sends
// to the app (Check now, Install now). The app itself, the download and the install are not here: they are Windows, and are
// checked by the unit tests and the setup's own check under Wine (SmartRetailAI/installer/test-update.sh). It starts the
// dashboard itself on demo data, with the Updates folder in a temporary folder the test writes status.json into:
//   npm install && npm run test:updates          (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-updates-'));
const updates = path.join(work, 'Updates');
const statusFile = path.join(updates, 'status.json');
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({}));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

let written = 0;
function writeStatus(status) {
  fs.mkdirSync(updates, { recursive: true });
  const temporary = statusFile + '.tmp';
  fs.writeFileSync(temporary, JSON.stringify(status, null, 2));
  fs.renameSync(temporary, statusFile);
  // Every write is a new one, whatever the file system's clock does.
  const time = new Date(Date.now() + (++written) * 2000);
  fs.utimesSync(statusFile, time, time);
}

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile, Updates__Folder: updates, Updates__PollSeconds: '1' },
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
  const watch = (page) => {
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));
  };
  try {
    // ---- In a plain browser: what the app found is shown, but only the app can check or install.
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    watch(page);
    const card = page.locator('#update-card');
    const badgeOf = async (p) => {
      const badge = p.locator('.wb-bell-button .wb-badge');
      return (await badge.count()) === 0 ? 0 : Number((await badge.innerText()).trim());
    };

    // The app's own window: its top bar (with the bell) shows only there, and pages can send it messages.
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 } });
    await context.addInitScript(() => {
      window.srposFrame = 'app';
      window.__sent = [];
      window.chrome = { webview: { postMessage: (m) => window.__sent.push(JSON.parse(m)), addEventListener() {} } };
    });
    const inApp = await context.newPage();
    watch(inApp);
    const appCard = inApp.locator('#update-card');
    const bell = inApp.locator('.wb-bell-button');
    const sent = () => inApp.evaluate(() => window.__sent.filter(m => m.type === 'update'));

    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await card.waitFor();
    assert.strictEqual(await card.getAttribute('data-state'), 'Unknown');
    assert.ok((await card.innerText()).includes('No update check yet'), 'nothing found yet is said so');
    assert.ok((await card.innerText()).includes('two minutes after it starts'), 'and when the app looks');
    assert.strictEqual(await card.locator('button:visible').count(), 0, 'a browser cannot check or install: no buttons');
    assert.ok(await card.getByText('Open Smart Retail POS itself to check for an update or to install one.').isVisible(), 'and it says why');
    assert.strictEqual(fs.existsSync(updates), false, 'the dashboard never makes the app\'s folder');
    // The demo shop has mistakes to fix, which the bell counts too: only the change is what counts here.
    await inApp.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await bell.waitFor();
    const others = await badgeOf(inApp);
    step('nothing found yet: the card says when the app looks, and a browser shows no buttons');

    // ---- An update the app downloaded and checked: on the card and in the bell, within a moment of being written.
    writeStatus({ State: 'Ready', Current: '2.9.0', Available: '9.9.9', File: 'SmartRetailAI-Setup-9.9.9.exe', Sha256: 'a'.repeat(64), Notes: 'Faster posters and a price check.', CheckedAt: new Date().toISOString() });
    await card.getByText('Version 9.9.9 is ready to install').waitFor({ timeout: 15000 });
    assert.strictEqual(await card.getAttribute('data-state'), 'Ready');
    assert.ok((await card.innerText()).includes('What is new: Faster posters and a price check.'), 'what is new is shown');
    assert.ok((await card.innerText()).includes('Windows may ask for permission'), 'and what will happen');
    await appCard.getByText('Version 9.9.9 is ready to install').waitFor({ timeout: 15000 });
    assert.strictEqual(await badgeOf(inApp), others + 1, 'the bell counts it as one more');
    await bell.click();
    const row = inApp.locator('.wb-pop-row', { hasText: 'Version 9.9.9 is ready to install' });
    await row.waitFor();
    assert.ok((await row.getAttribute('href')).endsWith('settings#updates'), 'the bell row goes to the card');
    await inApp.screenshot({ path: path.join(OUT, 'updates-bell.png') });
    await inApp.keyboard.press('Escape');
    await inApp.locator('.wb-backdrop').click({ force: true, position: { x: 5, y: 5 } }).catch(() => {});
    step('a ready update is on the card with what is new, and in the bell with a link to it');

    // ---- What is written by hand or wrongly never breaks the page, and is never shown as a ready update.
    writeStatus({ State: 'Ready', Available: 'latest <b>bold</b>', Notes: null, Problem: null });
    await inApp.waitForFunction((n) => (document.querySelector('.wb-bell-button .wb-badge')?.textContent.trim() || '0') === String(n), others, { timeout: 15000 });
    assert.strictEqual(await badgeOf(inApp), others, 'a version not written as the release writes it is not offered in the bell');
    fs.writeFileSync(statusFile, 'not json at all');
    const later = new Date(Date.now() + 60000);
    fs.utimesSync(statusFile, later, later);
    await page.waitForFunction(() => document.querySelector('#update-card')?.getAttribute('data-state') === 'Unknown', null, { timeout: 15000 });
    step('a status the release does not write, or a damaged file, is never offered and never breaks the page');

    // ---- Inside the app: the buttons, and the messages they send.
    writeStatus({ State: 'UpToDate', Current: '9.9.9', CheckedAt: '2026-09-29T10:30:00' });
    await inApp.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await appCard.waitFor();
    await inApp.waitForFunction(() => document.querySelector('#update-card')?.getAttribute('data-state') === 'UpToDate', null, { timeout: 15000 });
    assert.ok((await appCard.innerText()).includes('You have the latest version'), 'up to date is said');
    assert.ok((await appCard.innerText()).includes('Smart Retail POS 9.9.9. Last checked 29 Sept, 10:30 am.'), 'with its version and when: ' + (await appCard.innerText()));
    assert.ok(!(await appCard.innerText()).includes('Open Smart Retail POS itself'), 'inside the app there is nothing to open');
    assert.strictEqual(await appCard.getByRole('button', { name: 'Install now' }).count(), 0, 'nothing to install');

    // Check now: the app is asked, and the card shows it is looking until the app writes what it found.
    await appCard.getByRole('button', { name: 'Check now' }).click();
    await appCard.getByRole('button', { name: 'Checking…' }).waitFor();
    assert.strictEqual(await appCard.getByRole('button', { name: 'Checking…' }).isDisabled(), true, 'it cannot be pressed again meanwhile');
    assert.deepStrictEqual(await sent(), [{ type: 'update', value: 'check' }], 'the app was asked to check');
    writeStatus({ State: 'Ready', Current: '9.9.9', Available: '10.0.0', File: 'SmartRetailAI-Setup-10.0.0.exe', Sha256: 'b'.repeat(64), Notes: 'Automatic updates.', CheckedAt: new Date().toISOString() });
    await appCard.getByText('Version 10.0.0 is ready to install').waitFor({ timeout: 15000 });
    assert.strictEqual(await appCard.getByRole('button', { name: 'Check now' }).isDisabled(), false, 'the check is over');
    step('inside the app: Check now asks the app, shows it is looking, and shows what it found');

    // Install now: asks first, then the app is asked; Not now leaves everything as it was.
    await appCard.getByRole('button', { name: 'Install now' }).click();
    const dialog = appCard.getByRole('alertdialog', { name: 'Install the update?' });
    await dialog.waitFor();
    const text = await dialog.innerText();
    assert.ok(text.includes('Install version 10.0.0 now?') && text.includes('opens again by itself') && text.includes('Windows may ask for permission') && text.includes('settings, photos and plans are kept'), text);
    await inApp.screenshot({ path: path.join(OUT, 'updates-confirm.png') });
    await dialog.getByRole('button', { name: 'Not now' }).click();
    await dialog.waitFor({ state: 'detached' });
    assert.strictEqual((await sent()).filter(m => m.value === 'install').length, 0, 'and nothing was sent');
    await appCard.getByRole('button', { name: 'Install now' }).click();
    await dialog.getByRole('button', { name: 'Install and restart' }).click();
    await appCard.getByText('Starting the update.').waitFor();
    assert.deepStrictEqual((await sent()).filter(m => m.value === 'install'), [{ type: 'update', value: 'install' }], 'the app was asked to install, once');
    assert.strictEqual(await appCard.getByRole('button').count(), 0, 'no button while it starts');
    step('Install now asks first, Not now changes nothing, and Install and restart asks the app once');

    // A problem: said in words, with a way to try again.
    writeStatus({ State: 'Failed', Current: '9.9.9', CheckedAt: '2026-09-29T11:00:00', Problem: 'Version 10.0.0 was not published by the app\'s own release (it comes from another repository), so it was not downloaded.' });
    await appCard.getByText('The last check did not work').waitFor({ timeout: 15000 });
    assert.ok((await appCard.innerText()).includes('was not published by the app\'s own release'), 'the reason is shown');
    assert.ok((await appCard.innerText()).includes('Last tried 29 Sept, 11:00 am.'), 'and when');
    await appCard.getByRole('button', { name: 'Check again' }).waitFor({ timeout: 45000 });
    step('a failed check says why and offers Check again');

    // A copy built without an update folder.
    writeStatus({ State: 'Off', Current: '9.9.9' });
    await appCard.getByText('Updates are not set up').waitFor({ timeout: 15000 });
    assert.ok((await appCard.innerText()).includes('installed by hand from the Releases page'), 'and how to update instead');
    assert.strictEqual(await appCard.getByRole('button').count(), 0, 'nothing to press');
    step('a copy built without an update folder says so, and how to update instead');

    // Phone width.
    writeStatus({ State: 'Ready', Current: '9.9.9', Available: '10.0.0', File: 'SmartRetailAI-Setup-10.0.0.exe', Sha256: 'c'.repeat(64), Notes: 'A long description of what is new in this version, to see how it wraps on a narrow screen.', CheckedAt: new Date().toISOString() });
    await appCard.getByText('Version 10.0.0 is ready to install').waitFor({ timeout: 15000 });
    await page.setViewportSize({ width: 390, height: 800 });
    await page.goto(BASE + '/settings#updates', { waitUntil: 'networkidle' });
    await card.getByText('Version 10.0.0 is ready to install').waitFor({ timeout: 15000 });
    const overflow = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
    assert.ok(overflow <= 1, 'no sideways scrolling on a phone: ' + overflow);
    await page.screenshot({ path: path.join(OUT, 'updates-phone.png') });
    step('phone width: no sideways scrolling');
  } finally {
    await browser.close();
    stopApp(app);
    fs.rmSync(work, { recursive: true, force: true });
  }

  const real = errors.filter(e => !/favicon|Failed to load resource/.test(e));
  assert.deepStrictEqual(real, [], 'console or page errors: ' + real.join(' | '));
  console.log('No console or page errors.');
})().catch(e => { console.error(e); process.exit(1); });
