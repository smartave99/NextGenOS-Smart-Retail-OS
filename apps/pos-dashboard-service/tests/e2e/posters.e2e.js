// End-to-end check of A4 sale posters, in Chromium. On the demo shop, with stand-in-codex.js in place of the real
// Codex CLI: the AI picks a clearance poster's products and words, the app holds its offers to the rules (never below
// cost plus GST, at most 30% off), staff change an offer and the words, the artwork arrives, the poster prints as one
// A4 page, and it is kept in the data folder. It starts the app itself, then stops it:
//   npm install && npm run test:posters        (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');
const { png } = require('./png');
const { writeShopProfile } = require('./shop-profile');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-posters-'));
const dataFolder = path.join(work, 'data');

// A "codex" launcher for the stand-in, like the one npm installs, set up as the side panel would.
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: dataFolder }));
// While this file exists the stand-in Codex meets its usage limit: it is there from the start, so the first artwork waits, and the test deletes it.
const limitFile = path.join(work, 'codex-limit');
fs.writeFileSync(limitFile, '');

// The demo's ball pens (product 24) already have a white-background photo, as if made on the Product photos page.
const penFolder = path.join(dataFolder, 'Product photos', '24 Ball Pen, pack of 5');
fs.mkdirSync(penFolder, { recursive: true });
const penPhoto = 'white-20260920-100100.png';
fs.writeFileSync(path.join(penFolder, 'raw-20260920-100000.png'), png(60, 60, () => [120, 120, 120]));
fs.writeFileSync(path.join(penFolder, penPhoto), png(240, 240, (x, y) => (Math.abs(x - 120) < 14 && y > 30 && y < 210 ? [20, 60, 200] : [255, 255, 255])));
fs.writeFileSync(path.join(penFolder, 'product.json'), JSON.stringify({
  ProductId: 24, Code: '1024', Name: 'Ball Pen, pack of 5', Category: 'Stationery',
  Sets: [{
    Id: '20260920-100000', Started: '2026-09-20T10:00:00', RawFiles: ['raw-20260920-100000.png'],
    Images: [{ Kind: 'WhiteBackground', File: penPhoto, Made: '2026-09-20T10:01:00', Provider: 'Codex CLI (OpenAI)' }],
    Pending: [],
  }],
}, null, 2));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile, ...writeShopProfile(work), STAND_IN_CODEX_DELAY_MS: '1500', STAND_IN_CODEX_LIMIT_FILE: limitFile },
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

// The pages of a PDF and their sizes in points, read from its page objects.
function pdfPages(pdf) {
  const text = pdf.toString('latin1');
  return [...text.matchAll(/\/Type\s*\/Page[^s][\s\S]*?\/MediaBox\s*\[\s*([\d.]+)\s+([\d.]+)\s+([\d.]+)\s+([\d.]+)\s*\]/g)]
    .map(m => ({ width: Number(m[3]) - Number(m[1]), height: Number(m[4]) - Number(m[2]) }));
}

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  let page;
  try {
    page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('pageerror', e => errors.push(e.message));
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });

    // Today suggests a clearance poster for the slow sellers.
    await page.goto(BASE + '/');
    const tip = page.locator('.suggestion', { hasText: 'could clear with a poster' });
    await tip.waitFor();
    await tip.getByRole('link', { name: 'Make a poster' }).click();
    await page.waitForURL(/\/posters\?kind=clearance$/);
    await page.locator('.seg-item.on', { hasText: 'Clearance' }).waitFor();
    await page.getByText('3 products fit this poster right now.').waitFor();
    await page.getByText('Codex CLI (OpenAI) picks the products').waitFor();
    await page.getByRole('link', { name: 'Posters' }).first().waitFor();
    await page.screenshot({ path: path.join(OUT, 'posters-new.png') });
    step('Today leads to a clearance poster; 3 slow products fit');

    // Two products. The AI chose the notebook with 45% off and the pens with 15%: the notebook may only come down to
    // ₹40 (lowest allowed ₹39, 29% off), the pens (₹45) go to ₹39. The pens come first on the list: they have a photo.
    await page.getByRole('radio', { name: '2', exact: true }).click();
    await page.getByRole('button', { name: 'Make the poster' }).click();
    await page.waitForURL(/\/posters\/\d{8}-\d{6}-clearance$/);
    const id = page.url().split('/').pop();
    await page.getByRole('heading', { name: 'Clearance poster' }).waitFor();
    const sheet = page.locator('.print-me .sheet');
    await sheet.waitFor();
    const items = sheet.locator('.sheet-item');
    assert.strictEqual(await items.count(), 2);
    assert.deepStrictEqual(await sheet.locator('.sheet-name').allTextContents(), ['Notebook 172 pages', 'Ball Pen, pack of 5']);
    assert.deepStrictEqual(await sheet.locator('.sheet-prices s').allTextContents(), ['₹55', '₹45']);
    assert.deepStrictEqual(await sheet.locator('.sheet-prices b').allTextContents(), ['₹40', '₹39']);
    assert.strictEqual((await sheet.locator('.sheet-badge').innerText()).replace(/\s+/g, ' '), 'UP TO 27% OFF');
    assert.strictEqual(await sheet.locator('.sheet-headline').innerText(), 'STOCK CLEARANCE');
    assert.strictEqual(await sheet.locator('.sheet-local').innerText(), 'भारी छूट, जल्दी करें');
    // "Now 50% off" had a figure in it, so the app used its own line.
    assert.strictEqual(await sheet.locator('.sheet-sub').innerText(), "Grab them before they're gone");
    assert.strictEqual(await sheet.locator('.sheet-shop').innerText(), 'DEMO STORE');
    assert.match(await sheet.locator('.sheet-item').nth(1).locator('img').getAttribute('src'), new RegExp(`product-photos/24/${penPhoto}$`));
    assert.match(await sheet.locator('.sheet-foot').innerText(), /^Offers valid .+, while stock lasts\s+Prices include GST$/);
    step('The AI picked two products; offers held to the rules (₹55 → ₹40, ₹45 → ₹39), words checked');

    // Staff check the offers before printing; changing one asks again.
    const print = page.getByRole('button', { name: 'Print' });
    assert.ok(await print.isDisabled(), 'Print waits until the offers are checked');
    const notebookOffer = page.getByRole('combobox', { name: 'Offer on Notebook 172 pages' });
    const choices = await notebookOffer.locator('option').allTextContents();
    assert.deepStrictEqual(choices.map(c => c.replace(/\s+/g, ' ').trim()),
      ['No offer · ₹55', '₹53 · 3% off', '₹50 · 9% off', '₹47 · 14% off', '₹44 · 20% off', '₹42 · 23% off', '₹40 · 27% off', '₹39 · 29% off']);
    await notebookOffer.selectOption('47');
    await sheet.locator('.sheet-prices b', { hasText: '₹47' }).waitFor();
    await page.getByRole('combobox', { name: 'Offer on Ball Pen, pack of 5' }).selectOption('');
    await sheet.locator('.sheet-badge', { hasText: 'SAVE' }).waitFor();
    assert.deepStrictEqual(await sheet.locator('.sheet-prices b').allTextContents(), ['₹47', '₹45']);
    assert.strictEqual((await sheet.locator('.sheet-badge').innerText()).replace(/\s+/g, ' '), 'SAVE 14% OFF');
    await page.getByLabel('Headline').fill('Clearance sale');
    await page.getByLabel('Headline').press('Tab');
    await sheet.locator('.sheet-headline', { hasText: 'CLEARANCE SALE' }).waitFor();
    await page.getByLabel('I checked the prices and offers').check();
    await page.locator('.page-head button.btn-primary:enabled', { hasText: 'Print' }).waitFor();
    // The thumbnail among the earlier posters shows the changes too.
    await page.locator('.poster-link.current .sheet-headline', { hasText: 'CLEARANCE SALE' }).waitFor();
    step('Staff changed an offer and the headline; Print waits for "I checked the prices and offers"');

    // Codex's usage limit holds from the start: the artwork is not marked as failed; it waits, says when it carries on by itself, and is made
    // when the limit lifts (Try now stands in for the time coming).
    const waitingArt = page.locator('p[role=status]', { hasText: "Codex's usage limit was reached. The artwork carries on by itself at" });
    await waitingArt.waitFor({ timeout: 30000 });
    assert.ok(/carries on by itself at (tomorrow )?\d{1,2}:\d{2}/i.test(await waitingArt.innerText()), await waitingArt.innerText());
    assert.strictEqual(await page.getByText('The artwork could not be made').count(), 0, 'a usage limit is not a failure');
    await page.screenshot({ path: path.join(OUT, 'posters-paused.png') });
    fs.rmSync(limitFile);
    await waitingArt.getByRole('button', { name: 'Try now' }).click();
    step('Codex’s usage limit does not fail the artwork: it waits, says when it carries on, and goes on when the limit lifts');

    // The artwork arrives from Codex while the poster is open.
    await page.locator('.print-me .sheet.has-art').waitFor({ timeout: 30000 });
    const art = await sheet.evaluate(el => getComputedStyle(el).backgroundImage);
    assert.match(art, new RegExp(`/poster-art/${id}/artwork-\\d{8}-\\d{6}\\.png`));
    const artUrl = art.match(/url\("(.*)"\)/)[1];
    assert.strictEqual((await page.request.get(artUrl)).status(), 200);
    assert.strictEqual((await page.request.get(`${BASE}/poster-art/${id}/poster.json`)).status(), 404);
    assert.strictEqual((await page.request.get(`${BASE}/poster-art/..%2F..%2Fsettings/artwork-20260101-000000.png`)).status(), 404);
    await page.getByText('Artwork by Codex CLI (OpenAI) with ChatGPT Images').waitFor();
    await page.screenshot({ path: path.join(OUT, 'posters-made.png') });
    step('Codex made the artwork (no text); only the store\'s own files are served');

    // Printing leaves the poster alone, on one A4 page.
    await page.emulateMedia({ media: 'print' });
    assert.ok(!(await page.locator('.sidebar').isVisible()), 'the sidebar does not print');
    assert.ok(!(await page.locator('.poster-side').isVisible()), 'the form does not print');
    assert.ok(await sheet.isVisible(), 'the poster prints');
    const pdf = await page.pdf({ preferCSSPageSize: true, printBackground: true });
    fs.writeFileSync(path.join(OUT, 'poster.pdf'), pdf);
    const pages = pdfPages(pdf);
    assert.strictEqual(pages.length, 1, 'one page');
    assert.ok(Math.abs(pages[0].width - 595.3) < 2 && Math.abs(pages[0].height - 841.9) < 2, 'A4: ' + JSON.stringify(pages[0]));
    await page.emulateMedia({ media: 'screen' });
    step('It prints as a single A4 page with nothing but the poster');

    // Kept in the data folder, and listed with earlier posters.
    const saved = JSON.parse(fs.readFileSync(path.join(dataFolder, 'Posters', id, 'poster.json'), 'utf8'));
    assert.strictEqual(saved.Kind, 'Clearance');
    assert.deepStrictEqual(saved.Items.map(i => [i.Name, i.Price, i.OfferPrice]), [['Notebook 172 pages', 55, 47], ['Ball Pen, pack of 5', 45, null]]);
    assert.strictEqual(saved.Words.Headline, 'Clearance sale');
    await page.reload();
    await page.locator('.print-me .sheet-headline', { hasText: 'CLEARANCE SALE' }).waitFor();
    await page.locator('.poster-link.current').waitFor();
    step('The poster is kept in the data folder and opens again');

    // The owner lowers the biggest offer to 10%: the notebook's ₹47 (14% off) is no longer allowed. The poster says
    // so and does not print until today's rules are applied, which bring the offer to ₹50.
    await page.goto(BASE + '/settings');
    await page.getByRole('combobox', { name: 'Biggest offer on posters' }).selectOption('10');
    for (let i = 0; i < 20 && JSON.parse(fs.readFileSync(settingsFile, 'utf8')).Posters?.MaxOfferPercent !== 10; i++) await new Promise(r => setTimeout(r, 250));
    assert.strictEqual(JSON.parse(fs.readFileSync(settingsFile, 'utf8')).Posters.MaxOfferPercent, 10);
    await page.goto(`${BASE}/posters/${id}`);
    const changed = page.locator('.price-changes');
    await changed.getByText('Notebook 172 pages: the offer ₹47 is below what is allowed now (₹50)').waitFor();
    assert.ok(await page.getByRole('button', { name: 'Print' }).isDisabled(), 'no printing until it is fixed');
    await changed.getByRole('button', { name: "Use today's prices" }).click();
    await changed.waitFor({ state: 'detached' });
    assert.deepStrictEqual(await page.locator('.print-me .sheet-prices b').allTextContents(), ['₹50', '₹45']);
    await page.getByLabel('I checked the prices and offers').check();
    await page.locator('.page-head button.btn-primary:enabled', { hasText: 'Print' }).waitFor();
    step('A lower offer limit flags the saved poster; "Use today\'s prices" brings its offer within the rules');

    // New arrivals: one product, the newest, at today's price.
    await page.getByRole('link', { name: 'New poster' }).click();
    await page.getByRole('radio', { name: 'New arrivals' }).click();
    await page.getByText('3 products fit this poster right now.').waitFor();
    await page.getByRole('radio', { name: '1', exact: true }).click();
    await page.getByRole('button', { name: 'Make the poster' }).click();
    await page.waitForURL(/-new-arrivals$/);
    const single = page.locator('.print-me .sheet.n1');
    await single.waitFor();
    assert.strictEqual(await single.locator('.sheet-name').innerText(), 'Glass Jar Set of 3');
    assert.strictEqual(await single.locator('.sheet-prices b').innerText(), '₹299');
    assert.strictEqual(await single.locator('.sheet-badge').count(), 0);
    assert.ok(await page.getByRole('button', { name: 'Print' }).isEnabled(), 'no offers, nothing to confirm');
    await page.locator('.print-me .sheet.has-art').waitFor({ timeout: 30000 });
    await page.screenshot({ path: path.join(OUT, 'posters-new-arrivals.png') });
    assert.strictEqual(await page.locator('.poster-link').count(), 2);
    step('A one-product New arrivals poster shows the newest product at today\'s price');

    // Dark mode leaves the poster white, like paper.
    await page.evaluate(() => srpos.setTheme('dark'));
    const paper = await page.locator('.print-me .sheet-item').first().evaluate(el => getComputedStyle(el).backgroundColor);
    assert.strictEqual(paper, 'rgb(255, 255, 255)');
    await page.screenshot({ path: path.join(OUT, 'posters-dark.png') });
    await page.evaluate(() => srpos.setTheme('system'));

    // Deleting a poster removes its folder.
    await page.getByRole('button', { name: 'Delete poster' }).click();
    await page.getByRole('button', { name: 'Delete', exact: true }).click();
    await page.waitForURL(/\/posters$/);
    assert.strictEqual(fs.readdirSync(path.join(dataFolder, 'Posters')).length, 1);
    step('Dark mode keeps the paper white; a deleted poster is gone from the data folder');

    assert.deepStrictEqual(errors, [], 'no errors in the browser');
    console.log('\nAll poster checks passed. Screenshots in ' + OUT);
  } catch (e) {
    if (page) await page.screenshot({ path: path.join(OUT, 'posters-failed.png'), fullPage: true }).catch(() => {});
    if (errors.length) console.error('Browser errors:', errors);
    throw e;
  } finally {
    await browser.close();
    stopApp(app);
    fs.rmSync(work, { recursive: true, force: true });
  }
})().catch(e => { console.error(e); process.exit(1); });
