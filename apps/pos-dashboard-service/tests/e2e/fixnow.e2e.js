// End-to-end check of the Fix now list, in Chromium, on the demo shop's planted mistakes: the Today page and the
// menu say how many things need fixing; the Fix now page lists them with their figures and what to do; one is
// marked as on purpose (kept in the data folder), stays hidden after a reload, and is shown again. It starts the
// app itself on demo data with its own settings and data folder, then stops it:
//   npm install && npm run test:fixnow        (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-fixnow-'));
const dataFolder = path.join(work, 'data');
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli' }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: dataFolder }));
const notesFile = path.join(dataFolder, 'Shop checks', 'on-purpose.json');
const seenFile = path.join(dataFolder, 'Shop checks', 'seen.json');

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile },
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
  const browser = await chromium.launch();
  const errors = [];
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));
    const badge = page.locator('nav[aria-label="Main"] a[href="fix-now"] .count');

    // Today and the menu say what needs fixing
    await page.goto(BASE + '/');
    const banner = page.locator('a.fix-banner');
    await banner.waitFor();
    assert.match(await banner.innerText(), /^3 things to fix now\. Selling below cost: Glucose Biscuits 200 g; Sold at a loss this week: Glucose Biscuits 200 g; and more\./);
    assert.strictEqual(await badge.innerText(), '3');
    await page.screenshot({ path: `${OUT}/fixnow-1-today.png` });
    step('Today: "3 things to fix now" with the first two, and 3 on the menu');

    // The Fix now page: each mistake with its figures and what to do in the POS
    await banner.click();
    await page.waitForURL(/\/fix-now$/);
    const group = (heading) => page.locator('section.fix-group', { has: page.getByRole('heading', { name: heading }) });
    await group('Selling below cost').waitFor();
    const biscuits = group('Selling below cost').locator('li.finding', { hasText: 'Glucose Biscuits 200 g' });
    assert.match(await biscuits.innerText(), /Sells for ₹20\.00 but costs ₹21\.53 with 5% GST \(bought at ₹20\.50\)\. Each one sold loses ₹1\.53\. 120 in stock\./);
    assert.match(await biscuits.innerText(), /raise the price to at least ₹22/);
    assert.strictEqual(await group('Sold at a loss this week').locator('li.finding').count(), 2);
    assert.match(await group('Sold at a loss this week').innerText(), /Sold 2 at ₹12\.00 each after a discount/);
    assert.match(await group('Big discounts this week').innerText(), /₹16\.00 off \(40%\)/);
    assert.match(await group('Missing bill numbers').innerText(), /1 bill missing after SR\/26-27\/\d{4}/);
    assert.match(await group('Money owed for a long time').innerText(), /owed for over 30 days/);
    // Each finding says when it happened: a bill's date and time (from the POS log), or, for a price the POS gives no date, when this app first noticed it.
    assert.match(await biscuits.locator('.f-when').innerText(), /^Already there when this app first checked, on \d{1,2} \w+ \d{4}$/);
    const losses = await group('Sold at a loss this week').locator('li.finding .f-when').allInnerTexts();
    assert.strictEqual(losses.length, 2);
    for (const text of losses) assert.match(text, /^(Billed|Latest bill) \d{1,2} \w+ \d{4}(, \d{1,2}:\d{2} [ap]m)?/i, text);
    assert.ok(losses.some(text => /, \d{1,2}:\d{2} [ap]m/i.test(text)), 'a bill saved on its own day has its time: ' + losses);
    assert.match(await group('Big discounts this week').locator('.f-when').first().innerText(), /^Billed \d{1,2} \w+ \d{4}, \d{1,2}:\d{2} [ap]m$/i);
    assert.match(await group('Missing bill numbers').locator('.f-when').innerText(), /^Between \d{1,2}:\d{2} [ap]m and \d{1,2}:\d{2} [ap]m on \d{1,2} \w+ \d{4}$/i);
    assert.match(await group('Money owed for a long time').locator('.f-when').innerText(), /^Oldest unpaid bill is from \d{1,2} \w+ \d{4}$/);
    const seen = JSON.parse(fs.readFileSync(seenFile, 'utf8'));
    assert.ok(seen.Items.some(item => item.Problem.startsWith('below-cost|') && item.AtStart === true), 'what was first noticed is kept in the data folder');
    step('each finding says when: the bill\'s date and time, the window of a missing bill, the oldest unpaid bill, and for a price when it was first noticed');
    const levels = await page.locator('section.fix-group').evaluateAll(list => list.map(s => s.classList.contains('now') ? 'now' : 'soon'));
    assert.deepStrictEqual(levels, [...levels].sort(), 'fix now groups come before check soon ones');
    await page.screenshot({ path: `${OUT}/fixnow-2-page.png`, fullPage: true });
    step('Fix now page: below cost, sold at a loss, big discount, missing bill, money owed, each with what to do');

    // Links go to the bill and the product
    await group('Big discounts this week').getByRole('link', { name: 'Open the bill' }).click();
    await page.waitForURL(/\/bills\/\d+$/);
    await page.locator('table.bill-items').waitFor();
    assert.match(await page.locator('table.bill-items').innerText(), /Drinking Water 1 L/);
    await page.goBack();
    await group('Selling below cost').getByRole('link', { name: 'See the product' }).click();
    await page.waitForURL(/\/products\?q=Glucose/);
    await page.locator('table.data-table tbody tr', { hasText: 'Glucose Biscuits 200 g' }).waitFor();
    step('"Open the bill" and "See the product" go to that bill and product');

    // On purpose: hidden, kept in the data folder, still hidden after a reload, then shown again
    await page.goto(BASE + '/fix-now');
    await group('Selling below cost').waitFor();
    await biscuits.getByRole('button', { name: 'It’s on purpose' }).click();
    await biscuits.getByRole('textbox', { name: 'Why it is on purpose' }).fill('Clearing old stock before the new price list');
    await biscuits.getByRole('button', { name: 'Mark as on purpose' }).click();
    await page.locator('section.on-purpose', { hasText: 'Clearing old stock before the new price list' }).waitFor();
    assert.strictEqual(await group('Selling below cost').count(), 0);
    await page.waitForFunction(() => document.querySelector('nav[aria-label="Main"] a[href="fix-now"] .count')?.textContent.trim() === '2');
    const notes = JSON.parse(fs.readFileSync(notesFile, 'utf8'));
    assert.strictEqual(notes.length, 1);
    assert.match(notes[0].Key, /^below-cost\|/);
    assert.strictEqual(notes[0].Note, 'Clearing old stock before the new price list');
    await page.reload();
    await page.locator('section.on-purpose').waitFor();
    assert.strictEqual(await group('Selling below cost').count(), 0);
    await page.screenshot({ path: `${OUT}/fixnow-3-on-purpose.png`, fullPage: true });
    await page.locator('section.on-purpose').getByRole('button', { name: 'Show it again' }).click();
    await group('Selling below cost').waitFor();
    await page.waitForFunction(() => document.querySelector('nav[aria-label="Main"] a[href="fix-now"] .count')?.textContent.trim() === '3');
    assert.deepStrictEqual(JSON.parse(fs.readFileSync(notesFile, 'utf8')), []);
    step('"It\'s on purpose" hides it (with the reason, kept in the data folder, after a reload too); "Show it again" brings it back');

    // Check again runs the checks now
    await page.getByRole('button', { name: 'Check again' }).click();
    await page.getByRole('button', { name: 'Check again' }).and(page.locator(':enabled')).waitFor();
    await group('Selling below cost').waitFor();
    step('"Check again" checks the POS again');

    // Phone width: no sideways scrolling
    await page.setViewportSize({ width: 390, height: 844 });
    await page.goto(BASE + '/fix-now');
    await group('Selling below cost').waitFor();
    const overflow = await page.evaluate(() => document.documentElement.scrollWidth - window.innerWidth);
    assert.ok(overflow <= 1, `no sideways scroll at 390px (overflow ${overflow}px)`);
    step('phone width: no sideways scrolling');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e)), []);
    console.log('No console errors or page errors.');
  } catch (e) {
    console.error('FAILED: ' + (e && e.message));
    process.exitCode = 1;
  } finally {
    await browser.close();
    stopApp(app);
    fs.rmSync(work, { recursive: true, force: true });
  }
})();
