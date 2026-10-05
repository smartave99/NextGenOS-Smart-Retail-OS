// End-to-end check of the price check, in Chromium. A product is followed; Codex (stand-in-codex.js, in place of the real
// CLI) looks its prices up on "the web" and slips in what the app must leave out; the pages found wait for the owner, who
// confirms the ones that show exactly this product; the shop's price is set against them; the confirmed pages are read
// again. It starts the app itself on demo data, then stops it:
//   npm install && npm run test:prices        (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-prices-'));
const dataFolder = path.join(work, 'data');
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: dataFolder }));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile,
      STAND_IN_CODEX_DELAY_MS: '1500',
      STAND_IN_CODEX_STATE: path.join(work, 'codex-state'),
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
  const browser = await chromium.launch();
  const errors = [];
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    await page.goto(BASE + '/prices', { waitUntil: 'networkidle' });
    await page.getByRole('heading', { name: 'Price check', level: 1 }).waitFor();
    const about = await page.locator('.prices-about').innerText();
    for (const shop of ['Amazon.in', 'Flipkart', 'JioMart', 'BigBasket']) assert.ok(about.includes(shop), 'the page names ' + shop);
    assert.ok(about.includes('never your prices'), about);
    assert.ok(about.includes('a few words on what it is'), 'the notice names the short description that goes out too: ' + about);
    await page.getByText('No product is followed yet.').waitFor();
    assert.ok((await page.locator('.nav-item[href="prices"]').innerText()).includes('Price check'));
    step('Price check says how it works and which shops it reads, and that no price of the shop goes out');

    await page.getByLabel('Find a product to follow').fill('sunflower');
    await page.locator('.found-list li', { hasText: 'Sunflower Oil 1 L' }).getByRole('button', { name: 'Follow' }).click();
    const card = page.locator('section.price-card[data-product="6"]');
    await card.waitFor();
    assert.ok((await card.locator('.price-own').innerText()).includes('Your price ₹155 with GST'), await card.locator('.price-own').innerText());
    assert.ok((await card.innerText()).includes('Not looked yet.'));
    step('a product is followed, with the shop\'s own price from the POS');

    await card.getByRole('button', { name: 'Look online' }).click();
    await card.getByText('Codex is looking for prices on the web.').waitFor();
    assert.ok(await card.getByRole('button', { name: 'Look online' }).isDisabled(), 'one check at a time');
    const rows = card.locator('table.price-table tbody tr');
    await rows.first().waitFor({ timeout: 60000 });
    assert.strictEqual(await rows.count(), 3, 'the look-alike domain and the price of nothing are left out');
    assert.deepStrictEqual(await rows.evaluateAll(list => list.map(r => r.dataset.shop)), ['Flipkart', 'Amazon.in', 'JioMart']);
    const hrefs = await card.locator('table.price-table a').evaluateAll(list => list.map(a => [a.getAttribute('href'), a.target, a.rel]));
    assert.deepStrictEqual(hrefs, [
      ['https://www.flipkart.com/sunflower-oil-1-l/p/itm1', '_blank', 'noopener noreferrer'],
      ['https://www.amazon.in/Sunflower-Oil-1-L/dp/B0OIL1', '_blank', 'noopener noreferrer'],
      ['https://www.jiomart.com/p/groceries/sunflower-oil-2-l/590001', '_blank', 'noopener noreferrer'],
    ]);
    assert.ok(!(await card.innerText()).includes('evil'), 'nothing from the look-alike domain');
    const text = await card.innerText();
    for (const shown of ['Blinkit had none.', '1 answer left out: not a product page of', '1 answer left out: no price that could be read.',
      'Say which of the pages show exactly this product', 'Found: is it exactly this product, in this pack?', 'Maybe another pack'])
      assert.ok(text.includes(shown), 'the card shows “' + shown + '”: ' + text);
    assert.ok(text.includes('₹17 below yours') || text.includes('above yours') || text.includes('below yours'));
    assert.strictEqual(await card.getByRole('button', { name: 'Update confirmed prices' }).count(), 0, 'nothing confirmed yet, nothing to read again');
    await page.screenshot({ path: `${OUT}/prices-found.png`, fullPage: true });
    step('the pages Codex found wait for the owner; what is not a listed shop\'s product page or has no price is left out, and said so');

    // One at a time, each once the page shows the last change, as a person would.
    const confirmedRows = card.locator('table.price-table').first().locator('tbody tr');
    await rows.filter({ hasText: 'Flipkart' }).getByRole('button', { name: 'Same product' }).click();
    await card.getByText('Confirmed: exactly this product').waitFor();
    await rows.filter({ hasText: 'Amazon.in' }).getByRole('button', { name: 'Same product' }).click();
    await confirmedRows.nth(1).waitFor();
    await card.locator('tr[data-shop="JioMart"]').getByRole('button', { name: 'Not this' }).click();
    await card.getByText('Found: is it exactly this product, in this pack?').waitFor({ state: 'detached' });
    assert.strictEqual(await card.locator('table.price-table').count(), 1, 'nothing left to decide');
    assert.strictEqual(await card.locator('table.price-table tbody tr').count(), 2);
    await card.locator('.price-rejected summary', { hasText: 'Not this product (1)' }).waitFor();
    const verdict = await card.locator('.price-verdict').innerText();
    assert.ok(verdict.includes('Cheaper than online'), verdict);
    assert.ok(verdict.includes('Your price ₹155 is ₹17 (10%) below the lowest confirmed online price: ₹172 at Flipkart, seen '), verdict);
    step('two pages confirmed and one rejected: the shop\'s price is set against the lowest confirmed one');

    await card.getByRole('button', { name: 'Update confirmed prices' }).click();
    await card.getByText('Codex is looking for prices on the web.').waitFor();
    await card.locator('.price-verdict', { hasText: 'Dearer than online' }).waitFor({ timeout: 60000 });
    const again = await card.innerText();
    assert.ok(again.includes('Your price ₹155 is ₹5 (3%) above the lowest confirmed online price: ₹150 at Flipkart'), again);
    assert.ok(again.includes('was ₹172'), 'the earlier price is kept as history: ' + again);
    assert.ok(again.includes('1 answer left out: not one of the pages asked for.'), again);
    assert.strictEqual(await card.locator('table.price-table tbody tr').count(), 2, 'a page that was not asked for did not come in');
    await page.screenshot({ path: `${OUT}/prices.png`, fullPage: true });
    step('the confirmed pages are read again: the new price, the earlier one kept, and a page not asked for left out');

    const kept = JSON.parse(fs.readFileSync(path.join(dataFolder, 'Price checks', 'pricecheck.json'), 'utf8'));
    assert.deepStrictEqual(kept.Products.map(p => p.ProductId), [6]);
    assert.deepStrictEqual(kept.Products[0].Links.map(l => [l.Shop, l.Status]).sort(), [['Amazon.in', 'Confirmed'], ['Flipkart', 'Confirmed'], ['JioMart', 'Rejected']]);
    assert.ok(!JSON.stringify(kept).includes('evil'));
    step('what was found and confirmed is kept in the data folder\'s Price checks folder');

    // One product is looked up at a time: while it is, the other product's buttons wait and say why, and are free again after.
    await page.getByLabel('Find a product to follow').fill('toor');
    await page.locator('.found-list li', { hasText: 'Toor Dal 1 kg' }).getByRole('button', { name: 'Follow' }).click();
    const other = page.locator('section.price-card[aria-label="Toor Dal 1 kg"]');
    await other.waitFor();
    await card.getByRole('button', { name: 'Update confirmed prices' }).click();
    await card.getByText('Codex is looking for prices on the web.').waitFor();
    await other.getByText('Another product is being looked up now.').waitFor();
    assert.ok(await other.getByRole('button', { name: 'Look online' }).isDisabled(), 'the other product waits');
    await card.getByText('Codex is looking for prices on the web.').waitFor({ state: 'detached', timeout: 60000 });
    await other.getByText('Another product is being looked up now.').waitFor({ state: 'detached' });
    assert.ok(await other.getByRole('button', { name: 'Look online' }).isEnabled(), 'and it can be looked up when that is done');
    assert.ok((await card.innerText()).includes('Dearer than online'), 'the first product is as it was');
    await other.getByRole('button', { name: 'Stop following' }).click();
    await other.waitFor({ state: 'detached' });
    step('one product is looked up at a time: the other one waits, says why, and is free again after');

    await page.reload({ waitUntil: 'networkidle' });
    await card.waitFor();
    assert.ok((await card.innerText()).includes('Dearer than online'));
    await page.goto(BASE + '/storage', { waitUntil: 'networkidle' });
    assert.ok((await page.locator('.storage-line, main').first().innerText()).includes('Price checks'), 'the Storage page names the folder');
    await page.goto(BASE + '/prices', { waitUntil: 'networkidle' });
    await card.getByRole('button', { name: 'Stop following' }).click();
    await page.getByText('No product is followed yet.').waitFor();
    step('kept across a reload, named on the Storage page, and forgotten with "Stop following"');

    await page.getByLabel('Find a product to follow').fill('sunflower');
    await page.locator('.found-list li', { hasText: 'Sunflower Oil 1 L' }).getByRole('button', { name: 'Follow' }).click();
    await card.waitFor();
    await page.setViewportSize({ width: 390, height: 800 });
    await page.waitForTimeout(300);
    const overflow = await page.evaluate(() => Math.max(...[document.documentElement, ...document.querySelectorAll('.table-wrap')].map(e => e.scrollWidth - e.clientWidth)));
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
