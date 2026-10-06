// End-to-end check of the change log, in Chromium, on the demo shop: what changed in each update (CHANGELOG.md, built into
// the app). After an update the sidebar shows a "New" dot and Today a banner with the update's sentence; opening What's new
// lists every update newest first (this version marked, the ones not yet seen marked New, older ones folded away, an update
// that carried an earlier version's number named), and counts the version as seen: the dot and the banner go, and what was
// seen is kept beside the settings. Settings → Updates links to it. It starts the app itself on demo data, then stops it:
//   npm install && npm run test:whatsnew        (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-whatsnew-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli' }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

// What the project says about itself: the newest entry is what the app is built as.
const root = path.join(__dirname, '../../../..'); // the repository's root: CHANGELOG.md is there; the dashboard's own folder is apps/pos-dashboard-service
const log = fs.readFileSync(path.join(root, 'CHANGELOG.md'), 'utf8');
const newest = /^## (\d+\.\d+\.\d+)/m.exec(log)[1];
const built = /<Version>([^<]+)<\/Version>/.exec(fs.readFileSync(path.join(__dirname, '../../Directory.Build.props'), 'utf8'))[1];
assert.strictEqual(newest, built, 'the newest entry of CHANGELOG.md is the version the dashboard is built as');
const releases = [...log.matchAll(/^## (\d+\.\d+\.\d+)/gm)].map(m => m[1]);
// The kinds of change the newest entry lists (New, Improved, Fixed): the page shows each of them.
const newestKinds = [...log.split(/^## /m)[1].matchAll(/^### (\w+)/gm)].map(m => m[1]);
assert.ok(newestKinds.length > 0, 'the newest entry lists no change');

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

function stopApp(app) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid); } catch { /* gone */ }
}

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    // After an update: the dot in the sidebar and the banner on Today say there is something to read.
    await page.goto(BASE + '/', { waitUntil: 'networkidle' });
    const link = page.locator('.sidebar a.nav-item', { hasText: "What's new" });
    assert.strictEqual((await link.locator('.count.new').innerText()).trim(), 'New');
    const banner = page.locator('.news-banner');
    await banner.waitFor();
    assert.ok((await banner.innerText()).includes(`Smart Retail POS ${built}.`), await banner.innerText());
    const sentence = /^## [\d.]+ · .+\n\n(.+)/m.exec(log)[1];
    assert.ok((await banner.innerText()).includes(sentence.trim().slice(0, 40)), 'the banner says what the update is');
    await page.screenshot({ path: `${OUT}/whatsnew-banner.png` });
    step('after an update, the sidebar has a New dot and Today a banner with the update\'s sentence');

    // The banner leads to the page; opening it counts the version as seen.
    await banner.getByRole('link', { name: /What's new/ }).click();
    await page.waitForURL('**/whats-new');
    await page.locator('h1', { hasText: "What's new" }).waitFor();
    assert.ok((await page.locator('.page-head .pill').innerText()).includes(`You have version ${built}`));
    const newestSection = page.locator(`section[id="v${built}"]`);
    await newestSection.waitFor();
    assert.ok((await newestSection.getAttribute('class')).includes('current'));
    assert.ok((await newestSection.locator('.pill', { hasText: 'You have this' }).count()) === 1);
    assert.ok((await newestSection.locator('.pill', { hasText: /^New$/ }).count()) >= 1, 'the update not seen yet is marked New');
    await page.screenshot({ path: `${OUT}/whatsnew-page.png`, fullPage: false });
    step('What\'s new opens on the newest update: this version marked, and marked New as it was not seen');

    // The log: every release, newest first, with its day, sentence, kinds and bold lead-ins; older ones folded away.
    const shown = await page.locator('section.change-release h2').allTextContents();
    assert.deepStrictEqual(shown, releases.map(v => `Version ${v}`), 'every release is listed, newest first');
    assert.ok(await page.locator('details.earlier-versions').count() === 1);
    assert.strictEqual(await page.locator('details.earlier-versions[open]').count(), 0, 'the older updates are folded away');
    const openOnes = await page.locator('body > div, main, .content').first().evaluate(() => [...document.querySelectorAll('section.change-release')].filter(s => !s.closest('details')).length);
    assert.strictEqual(openOnes, 5, 'the newest five are open');
    assert.deepStrictEqual(await newestSection.locator('.change-kind .pill').allInnerTexts(), newestKinds);
    assert.ok((await newestSection.locator('.change-list li strong').count()) > 0, 'a lead-in is bold');
    assert.ok((await newestSection.locator('.change-summary').innerText()).length > 20);
    assert.ok((await newestSection.innerText()).match(/\d{1,2} \w+ 20\d\d/), 'its day is shown');
    await page.locator('details.earlier-versions > summary').click();
    const oldest = page.locator('section[id="v1.0.0"]');
    await oldest.waitFor({ state: 'visible' });
    assert.ok((await oldest.innerText()).includes('25 September 2026'));
    const carried = page.locator('section[id="v2.8.0"]');
    assert.ok((await carried.innerText()).includes('Includes 2.7.0, which was not released on its own.'), 'an update that carried a number says so');
    step('every update is listed newest first with its day, sentence and changes; older ones fold away; carried versions are named');

    // Seen: the dot and the banner are gone, and it is kept beside the settings.
    await page.waitForFunction(() => document.querySelectorAll('.sidebar .count.new').length === 0);
    const kept = JSON.parse(fs.readFileSync(path.join(work, 'whats-new.json'), 'utf8'));
    assert.deepStrictEqual(kept, { Seen: built });
    await page.goto(BASE + '/', { waitUntil: 'networkidle' });
    await page.locator('h1').first().waitFor();
    assert.strictEqual(await page.locator('.news-banner').count(), 0);
    assert.strictEqual(await link.locator('.count.new').count(), 0);
    step('once opened, the dot and the banner go, and what was seen is kept beside the settings');

    // An address with a version goes to that update.
    await page.goto(`${BASE}/whats-new#v2.9.0`, { waitUntil: 'networkidle' });
    assert.ok((await page.locator('section[id="v2.9.0"] h2').count()) === 1);

    // Settings → Updates leads here.
    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    const card = page.locator('#update-card');
    await card.getByRole('link', { name: /What changed in each update/ }).click();
    await page.waitForURL('**/whats-new');
    step('Settings → Updates leads to the change log');

    // The sidebar item is a normal link, current on its own page.
    await page.locator('.sidebar a.nav-item.active', { hasText: "What's new" }).waitFor();

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
