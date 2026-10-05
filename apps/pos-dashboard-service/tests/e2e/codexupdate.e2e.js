// End-to-end check of the dashboard keeping Codex up to date, in Chromium: the card in Settings, the switch for updating by
// itself, the bell, and what the worker finds by itself. Codex is a stand-in program that only says its version, its help and
// that it is signed in (stand-in-codex-update.js), put where OpenAI's installer puts Codex; OpenAI's release channel is a small
// server the test runs. The installer itself is Windows only: it is checked by the unit tests (with stand-ins), and here what
// this Linux run shows when it cannot install is the failure path. It starts the dashboard itself on demo data:
//   npm install && npm run test:codexupdate        (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const http = require('http');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-codexupdate-'));
const local = path.join(work, 'local');
const installFolder = path.join(local, 'Programs', 'OpenAI', 'Codex', 'bin');
const otherFolder = path.join(work, 'npm');
fs.mkdirSync(installFolder, { recursive: true });
fs.mkdirSync(otherFolder, { recursive: true });
const versionFile = path.join(work, 'codex-version.txt');
const setVersion = (version) => fs.writeFileSync(versionFile, version + '\n');
setVersion('0.158.0');

const standIn = path.join(__dirname, 'stand-in-codex-update.js');
function makeCodex(folder) {
  const file = path.join(folder, process.platform === 'win32' ? 'codex.cmd' : 'codex');
  fs.writeFileSync(file, process.platform === 'win32'
    ? `@"${process.execPath}" "${standIn}" %*\r\n`
    : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
  return file;
}
makeCodex(installFolder);
const outsideCodex = makeCodex(otherFolder);

const settingsFile = path.join(work, 'settings.json');
const stateFile = path.join(work, 'codex-update.json');
const writeSettings = (settings) => fs.writeFileSync(settingsFile, JSON.stringify(settings));
writeSettings({});
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));
const state = () => JSON.parse(fs.readFileSync(stateFile, 'utf8'));

// OpenAI's release channel, as the test wants it.
let latest = 'rust-v0.159.0';
let down = false;
const asked = [];
const releases = http.createServer((request, response) => {
  asked.push(request.url);
  if (down) { response.statusCode = 503; response.end('down'); return; }
  response.setHeader('content-type', 'application/json');
  response.end(JSON.stringify({ tag_name: latest, assets: [] }));
});

async function startApp(port) {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile,
      // Where OpenAI's installer keeps Codex on this run's "PC".
      XDG_DATA_HOME: local,
      LOCALAPPDATA: local,
      STAND_IN_CODEX_VERSION_FILE: versionFile,
      CodexUpdate__ChannelUrl: `http://127.0.0.1:${port}/channels/latest`,
      CodexUpdate__GitHubUrl: `http://127.0.0.1:${port}/github/latest`,
      CodexUpdate__FirstLookSeconds: '15',
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
  await new Promise(r => releases.listen(0, '127.0.0.1', r));
  const app = await startApp(releases.address().port);
  const browser = await chromium.launch();
  const errors = [];
  const watch = (page) => {
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));
  };
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    watch(page);
    const card = page.locator('#codex-update-card');
    const stateOf = () => card.getAttribute('data-state');
    const settled = (page, outcome) => page.waitForFunction(o => {
      const c = document.querySelector('#codex-update-card');
      return c && c.getAttribute('data-state') === o && c.getAttribute('data-busy') === 'false';
    }, outcome, { timeout: 60000 });
    const checkNow = async () => { await card.locator('#codex-check-now').click(); };

    // The app's own window, for its bell.
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 } });
    await context.addInitScript(() => {
      window.srposFrame = 'app';
      window.chrome = { webview: { postMessage() {}, addEventListener() {} } };
    });
    const inApp = await context.newPage();
    watch(inApp);
    const badgeOf = async () => {
      const badge = inApp.locator('.wb-bell-button .wb-badge');
      return (await badge.count()) === 0 ? 0 : Number((await badge.innerText()).trim());
    };

    // ---- Before the first look: the card says when Codex is looked at, and updating by itself is on.
    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await card.waitFor();
    assert.strictEqual(await stateOf(), 'None', 'nothing looked at yet');
    const first = await card.innerText();
    assert.ok(first.includes('Codex, the AI tool'), first);
    assert.ok(first.includes('Not looked at yet'), first);
    assert.ok(first.includes('A newer Codex is installed by itself a day after it comes out'), 'says what happens by itself: ' + first);
    assert.strictEqual(await card.getByRole('radio', { name: 'On' }).getAttribute('aria-checked'), 'true', 'updating by itself is on unless turned off');
    assert.strictEqual(await card.locator('#codex-update-now').count(), 0, 'nothing to update yet');
    await inApp.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await inApp.locator('.wb-bell-button').waitFor();
    const others = await badgeOf();
    step('before the first look: the card says when Codex is looked at, and updating by itself is on');

    // ---- The worker looks by itself: a release it has just seen settles for a day before it is installed.
    await settled(page, 'Settling');
    const settling = await card.innerText();
    assert.ok(settling.includes('Codex 0.159.0 came out a short while ago. It is installed by itself after a day, or now if you choose Update now.'), settling);
    assert.ok(await card.locator('#codex-update-now').isVisible(), 'the owner can update at once');
    assert.ok(asked.includes('/channels/latest'), 'OpenAI\'s release channel was asked: ' + asked);
    assert.strictEqual(fs.existsSync(stateFile), true, 'what was seen is kept beside the settings');
    assert.strictEqual(state().SeenVersion, '0.159.0');
    assert.ok(state().CheckedAt, 'and when it looked');
    assert.strictEqual(state().Automatic, true);
    await card.screenshot({ path: path.join(OUT, 'codex-update-settling.png') });
    step('the worker looks by itself, and a release just seen settles before it is installed');

    // ---- Check now: the newer Codex is out.
    await checkNow();
    await settled(page, 'Available');
    const available = await card.innerText();
    assert.ok(available.includes('Codex 0.159.0 is out; this PC has 0.158.0.'), available);
    assert.ok(await card.locator('#codex-update-now').isVisible());
    assert.strictEqual(await badgeOf(), others, 'while updating by itself is on, nothing needs the owner');
    step('Check now says a newer Codex is out and this PC has the older one');

    // ---- A job's model list says a newer Codex is out, since a new model sometimes needs it.
    await page.locator('.setting', { has: page.getByRole('heading', { name: 'Ask AI', exact: true }) }).locator('.ai-choice-chip').click();
    const newer = page.locator('.ai-choice-panel .ai-choice-newer');
    await newer.waitFor();
    assert.ok((await newer.innerText()).includes('Codex 0.159.0 is out. A new model sometimes needs the newest Codex.'), await newer.innerText());
    assert.strictEqual(await newer.getByRole('link', { name: 'Update it in Settings' }).getAttribute('href'), 'settings#updates');
    await page.keyboard.press('Escape');
    await page.locator('.ai-choice-panel').waitFor({ state: 'detached' });
    step('the model picker says a newer Codex is out and links to the Updates card');

    // ---- Turned off, it only looks; the bell tells the owner, and turning it on again takes the row away.
    await card.getByRole('radio', { name: 'Off' }).click();
    await page.waitForFunction(() => document.querySelector('#codex-update-card').innerText.includes('Automatic updates are off'));
    assert.strictEqual(state().Automatic, false, 'the choice is kept');
    await inApp.locator('.wb-bell-button').click();
    await inApp.locator('.wb-pop-row', { hasText: 'Codex 0.159.0 is out' }).waitFor();
    assert.strictEqual(await badgeOf(), others + 1);
    const row = await inApp.locator('.wb-pop-row', { hasText: 'Codex 0.159.0 is out' }).innerText();
    assert.ok(row.includes('Automatic updates are off. Update it in Settings.'), row);
    assert.strictEqual(await inApp.locator('.wb-pop-row', { hasText: 'Codex 0.159.0 is out' }).getAttribute('href'), 'settings#updates');
    await card.getByRole('radio', { name: 'On' }).click();
    await inApp.waitForFunction(() => ![...document.querySelectorAll('.wb-pop-row')].some(r => r.innerText.includes('Codex 0.159.0')));
    assert.strictEqual(state().Automatic, true);
    assert.strictEqual(await badgeOf(), others);
    step('with updating by itself off the bell says so, and it goes when it is turned on again');

    // ---- A Codex the installer did not put there is left to be updated the way it came.
    writeSettings({ Codex: { ExecutablePath: outsideCodex } });
    await checkNow();
    await settled(page, 'Manual');
    const manual = await card.innerText();
    assert.ok(manual.includes('was not put here by OpenAI\'s installer, so it is updated the way it was installed'), manual);
    assert.strictEqual(await card.locator('#codex-update-now').count(), 0, 'nothing for the app to update');
    writeSettings({});
    step('a Codex the installer did not put there is left to be updated the way it came');

    // ---- OpenAI not answering is said in a few words, and can be tried again.
    down = true;
    await checkNow();
    await settled(page, 'Unknown');
    assert.ok((await card.innerText()).includes('OpenAI could not be asked which Codex is the newest now.'), await card.innerText());
    assert.ok(await card.locator('#codex-check-now', { hasText: 'Check again' }).isVisible());
    down = false;
    step('OpenAI not answering is said, and offers Check again');

    // ---- The newest one installed: up to date.
    setVersion('0.159.0');
    await checkNow();
    await settled(page, 'UpToDate');
    const upToDate = await card.innerText();
    assert.ok(upToDate.includes('Codex 0.159.0 is the newest.'), upToDate);
    assert.strictEqual(await card.locator('#codex-update-now').count(), 0);
    setVersion('0.158.0');
    step('the newest Codex installed: up to date');

    // ---- Update now. The installer is Windows only, so what this run shows is a failure said plainly, and Codex staying as it was.
    if (process.platform !== 'win32') {
      await checkNow();
      await settled(page, 'Available');
      await card.locator('#codex-update-now').click();
      await settled(page, 'Failed');
      const failed = await card.locator('.update-problem').innerText();
      assert.ok(failed.includes('Codex could not be updated, so 0.158.0 stays: Installing Codex automatically works on Windows only.'), failed);
      assert.strictEqual(state().Problem, failed);
      assert.ok(await card.locator('#codex-check-now', { hasText: 'Check again' }).isVisible());
      await card.screenshot({ path: path.join(OUT, 'codex-update-failed.png') });
      step('Update now that cannot install says why, and Codex stays as it was');
    }

    // ---- Phone width: no sideways scrolling.
    const phone = await browser.newPage({ viewport: { width: 390, height: 800 } });
    watch(phone);
    await phone.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await phone.locator('#codex-update-card').scrollIntoViewIfNeeded();
    assert.ok(await phone.evaluate(() => document.documentElement.scrollWidth <= window.innerWidth + 1), 'no sideways scrolling at phone width');
    await phone.screenshot({ path: path.join(OUT, 'codex-update-phone.png') });
    step('phone width: no sideways scrolling');

    assert.deepStrictEqual(errors, [], 'no console or page errors: ' + errors.join(' | '));
    console.log('No console or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
    releases.close();
  }
})().catch(e => { console.error(e); process.exit(1); });
