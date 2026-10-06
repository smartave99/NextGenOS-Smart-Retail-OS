// End-to-end check of paging through a long list, in Chromium, on the demo shop (27 products, shown 10 to a page here):
// the Product photos list and the Products list cut it into pages with Previous, Next and the page numbers; the page and
// the size are in the address, so Back from a product's page comes to the same page; searching goes back to the first
// page; a page beyond the end shows the last; a size that is not offered falls back. It starts the app itself on demo
// data, then stops it:
//   npm install && npm run test:paging        (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-paging-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli' }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

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
    const pager = page.locator('nav.pager');
    const count = () => pager.locator('.pager-count').innerText();
    const numbers = async () => (await pager.locator('.pager-nav button[aria-label^="Page"]').allInnerTexts()).join(' ');
    const waitForCount = (text) => page.waitForFunction(t => document.querySelector('nav.pager .pager-count')?.textContent.trim().startsWith(t), text);

    // ----- Product photos: all products, 10 to a page -----
    await page.goto(`${BASE}/photos?view=all&size=10`, { waitUntil: 'networkidle' });
    await pager.waitFor();
    assert.strictEqual(await count(), 'Showing 1–10 of 27 products · page 1 of 3');
    assert.strictEqual(await numbers(), '1 2 3');
    assert.strictEqual(await pager.getByRole('button', { name: 'Previous' }).isDisabled(), true);
    assert.strictEqual(await pager.getByRole('button', { name: 'Page 1' }).getAttribute('aria-current'), 'page');
    const names = async () => page.locator('table.data-table tbody tr .item-name').allInnerTexts();
    const first = await names();
    assert.strictEqual(first.length, 10);
    assert.deepStrictEqual(first, [...first].sort((a, b) => a.localeCompare(b)), 'sorted by name');
    await page.screenshot({ path: `${OUT}/paging-photos.png` });
    await pager.screenshot({ path: `${OUT}/paging-pager.png` });

    await pager.getByRole('button', { name: 'Next' }).click();
    await waitForCount('Showing 11–20 of 27');
    const second = await names();
    assert.strictEqual(second.length, 10);
    assert.ok(second.every(name => !first.includes(name)), 'the next page shows other products');
    assert.ok(page.url().endsWith('/photos?view=all&size=10&page=2'), page.url());
    await pager.getByRole('button', { name: 'Page 3' }).click();
    await waitForCount('Showing 21–27 of 27');
    assert.strictEqual((await names()).length, 7);
    assert.strictEqual(await pager.getByRole('button', { name: 'Next' }).isDisabled(), true);
    assert.ok(page.url().endsWith('page=3'), page.url());
    step('Product photos: Next and the page numbers walk through every product, 10 to a page');

    // Back from a product's page comes to the same page.
    const third = await names();
    await page.locator('table.data-table tbody tr').first().getByRole('link', { name: /Add photos|Open/ }).click();
    await page.waitForURL(/\/photos\/\d+$/);
    // The address changes before the product's page is drawn: Back from a page not yet shown would find the list still on screen.
    await page.locator('.page-head .eyebrow a[href="photos"]').waitFor();
    await page.goBack();
    await waitForCount('Showing 21–27 of 27');
    assert.deepStrictEqual(await names(), third);
    step('Back from a product comes to the same page');

    // Searching goes back to the first page of what matches; the size can be changed.
    await page.fill('.scan-input', 'milk');
    await page.waitForFunction(() => !location.search.includes('page='));
    assert.strictEqual(await pager.locator('.pager-count').innerText(), '2 products');
    assert.strictEqual(await pager.locator('.pager-nav').count(), 0, 'two products need no page buttons');
    await page.fill('.scan-input', '');
    await waitForCount('Showing 1–10 of 27');
    await pager.getByLabel('Rows per page').selectOption('25');
    await waitForCount('Showing 1–25 of 27');
    assert.strictEqual(await numbers(), '1 2');
    assert.strictEqual((await names()).length, 25);
    assert.ok(page.url().includes('size=25') && !page.url().includes('page='), page.url());
    step('searching goes back to the first page, and the rows per page can be changed');

    // A page beyond the end shows the last; a size that is not offered gives the usual 50.
    await page.goto(`${BASE}/photos?view=all&size=10&page=99`, { waitUntil: 'networkidle' });
    await waitForCount('Showing 21–27 of 27');
    await page.goto(`${BASE}/photos?view=all&size=7&page=abc`, { waitUntil: 'networkidle' });
    await waitForCount('27 products');
    assert.strictEqual(await count(), '27 products', 'all 27 fit on one page of 50');
    assert.strictEqual(await pager.locator('.pager-nav').count(), 0);
    step('a page beyond the end shows the last one; a size that is not offered gives the usual 50');

    // ----- Products: 10 to a page -----
    await page.goto(`${BASE}/products?size=10`, { waitUntil: 'networkidle' });
    await pager.waitFor();
    assert.strictEqual(await count(), 'Showing 1–10 of 27 products · page 1 of 3');
    const codes = async () => page.locator('table.data-table tbody tr td.mono:first-child').allInnerTexts();
    const firstCodes = await codes();
    assert.strictEqual(firstCodes.length, 10);
    await pager.getByRole('button', { name: 'Next' }).click();
    await waitForCount('Showing 11–20 of 27');
    const secondCodes = await codes();
    assert.ok(secondCodes.every(code => !firstCodes.includes(code)));
    assert.ok((await page.locator('table.data-table tbody tr .till-code').count()) >= 10, 'each row on the page has its till code');
    await pager.getByRole('button', { name: 'Page 3' }).click();
    await waitForCount('Showing 21–27 of 27');
    assert.strictEqual((await codes()).length, 7);
    await page.screenshot({ path: `${OUT}/paging-products.png` });
    await page.fill('.scan-input', 'sugar');
    await page.waitForFunction(() => !location.search.includes('page='));
    assert.strictEqual(await count(), '1 product');
    step('Products: the same pager, with the till codes read for the page shown');

    // A mistyped address (letters or a minus sign for the page, the size or the product picked) shows the list, not an error.
    await page.goto(`${BASE}/products?q=milk&picked=xyz&page=-1&size=abc`, { waitUntil: 'networkidle' });
    await waitForCount('2 products');
    assert.strictEqual(await page.locator('table.data-table tbody tr').count(), 2);
    assert.strictEqual(await page.locator('tbody tr.picked').count(), 0, 'nothing is marked for a product that is not a number');

    // The sidebar's search comes to the first page of what it found.
    await page.goto(`${BASE}/products?q=milk&size=10`, { waitUntil: 'networkidle' });
    await waitForCount('2 products');
    step('a search from the sidebar shows what it found');

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
