// End-to-end check of Smart Retail POS in Chromium: a cashier rings up and saves a bill.
// Start the app fresh in demo mode first (it checks stock going down from the demo figures), then:
//   npm install && npm test            (screenshots go to ./screenshots)
const { chromium } = require('playwright');
const assert = require('assert');

const BASE = process.env.POS_URL || 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
require('fs').mkdirSync(OUT, { recursive: true });
const problems = [];

(async () => {
  const browser = await chromium.launch();
  const page = await browser.newPage({ viewport: { width: 1440, height: 900 } });
  page.on('console', m => { if (m.type() === 'error') problems.push('console: ' + m.text()); });
  page.on('pageerror', e => problems.push('pageerror: ' + e.message));
  page.on('requestfailed', r => {
    // Blazor says goodbye to the server when a page unloads; a full reload cancels that beacon.
    if (r.url().endsWith('/_blazor/disconnect') && r.failure()?.errorText === 'net::ERR_ABORTED') return;
    problems.push('requestfailed: ' + r.url() + ' ' + r.failure()?.errorText);
  });
  const step = (s) => console.log('✓ ' + s);

  // Today
  await page.goto(BASE + '/');
  await page.getByRole('heading', { name: /^Good (morning|afternoon|evening)$/ }).waitFor();
  await page.locator('.hero .hero-figure').waitFor();
  assert.match(await page.locator('.hero .hero-figure').innerText(), /^₹[\d,]+$/);
  assert.strictEqual(await page.locator('.hero svg.chart path.c-bar').count(), 7);
  assert.ok(await page.locator('.shop-card .dot.demo').isVisible());
  assert.match(await page.locator('.hero-label').innerText(), /^Sales today · last bill at \d{1,2}:\d{2} (am|pm)$/);
  assert.ok(await page.locator('.today-hours svg path.c-bar').count() > 0, 'today by the hour, with last week behind it');
  assert.match(await page.locator('.today-eyebrow .live-state').innerText(), /Live · updated \d/);
  await page.screenshot({ path: `${OUT}/1-today.png` });
  step('Today: sales today with the last bill\'s time, the 7-day chart, today by the hour, live');

  // New bill (client-side navigation keeps the same session)
  await page.getByRole('link', { name: 'New bill' }).first().click();
  const scan = page.locator('input.scan-input');
  await scan.waitFor();
  assert.ok(await scan.evaluate(el => el === document.activeElement), 'search box should have focus');
  step('billing: search box focused on arrival');

  await scan.fill('rice');
  await page.locator('ul.suggestions li').first().waitFor();
  await scan.press('Enter');
  await page.locator('table.lines-table tbody tr').first().waitFor();
  step('typed "rice" + Enter adds the highlighted suggestion');

  // A scanner types the whole barcode, then Enter
  for (let i = 0; i < 2; i++) {
    await scan.fill('2000000000084');
    await scan.press('Enter');
    await page.waitForTimeout(250);
  }
  const milk = page.locator('tr', { hasText: 'Toned Milk 500 ml' });
  assert.strictEqual(await milk.locator('input[aria-label^="Quantity"]').inputValue(), '2');
  step('scanning the same barcode twice gives one line with qty 2');

  await scan.fill('chocolate');
  await page.locator('ul.suggestions li', { hasText: 'Milk Chocolate' }).waitFor();
  await scan.press('Enter');
  await page.locator('tr', { hasText: 'Milk Chocolate 50 g' }).waitFor();
  assert.strictEqual(await page.locator('table.lines-table tbody tr').count(), 3);

  await page.locator('tr', { hasText: 'Basmati Rice' }).locator('input[aria-label^="Discount"]').fill('10');
  await page.waitForTimeout(250);
  const grand = () => page.locator('.grand strong').innerText();
  assert.strictEqual(await grand(), '₹595.00', 'rice 494.10 + milk 56 + chocolate 45 = 595.10, rounded to 595');
  assert.strictEqual(await page.locator('.totals dt', { hasText: 'Round-off' }).locator('xpath=..').locator('dd').innerText(), '-₹0.10');
  step('10% discount on rice: total ₹595.00 with round-off -₹0.10');

  // A walk-in customer cannot take credit
  await page.locator('.pay-modes button', { hasText: 'Credit' }).click();
  await page.locator('.problems', { hasText: 'Choose a customer' }).waitFor();
  assert.ok(await page.locator('button.save-btn').isDisabled());
  step('credit for a walk-in customer is blocked');

  await page.locator('.pay-modes button', { hasText: 'Cash' }).click();
  await page.locator('.quick-cash button', { hasText: '₹1,000' }).click();
  await page.locator('.settle.good', { hasText: '₹405.00' }).waitFor();
  assert.ok(await page.locator('button.save-btn').isEnabled());
  await page.screenshot({ path: `${OUT}/2-new-bill.png` });
  step('cash ₹1,000 received: change ₹405.00, save enabled');

  // F9 saves
  await scan.focus();
  await page.keyboard.press('F9');
  await page.getByRole('heading', { name: 'Bill saved' }).waitFor();
  const number = await page.locator('.saved-number').innerText();
  assert.match(number, /^SR\/\d\d-\d\d\/\d{4}$/);
  assert.ok((await page.locator('.receipt').innerText()).includes(number));
  assert.ok(await page.getByRole('button', { name: 'New bill' }).evaluate(el => el === document.activeElement));
  await page.screenshot({ path: `${OUT}/3-bill-saved.png` });
  step(`F9 saved bill ${number}; receipt shown; "New bill" focused`);

  await page.emulateMedia({ media: 'print' });
  await page.pdf({ path: `${OUT}/receipt-print.pdf`, width: '80mm', printBackground: false });
  await page.emulateMedia({ media: 'screen' });
  step('print preview renders (receipt only)');

  await page.getByRole('button', { name: 'New bill' }).click();
  await page.locator('.empty', { hasText: 'This bill is empty' }).waitFor();
  step('"New bill" starts an empty bill');

  // The saved bill is first in the list; stock went down
  await page.getByRole('link', { name: 'Bills' }).click();
  await page.locator('table.data-table tbody tr').first().waitFor();
  assert.ok((await page.locator('table.data-table tbody tr').first().innerText()).includes(number));
  assert.match(await page.locator('table.bill-list tbody tr').first().locator('td.bill-time').innerText(), /^\d{1,2}:\d{2} (am|pm)$/);
  assert.match(await page.locator('.bill-kpis .kpi', { hasText: 'Latest bill' }).locator('.kpi-value').innerText(), /, \d{1,2}:\d{2} (am|pm)$/);
  await page.screenshot({ path: `${OUT}/4-bills.png` });
  step('bills list shows the new bill first, with the time it was made');

  // Every bill from the first, kept up to date while the page is open
  const billCount = async () => Number((await page.locator('.bill-kpis .kpi-value').first().innerText()).replace(/,/g, ''));
  const before = await billCount();
  assert.ok(before > 5000, `every demo bill is counted, not just the latest (${before})`);
  assert.match(await page.locator('.pager-count').innerText(), new RegExp(`^Page 1 of ${Math.ceil(before / 50)}$`));
  assert.match(await page.locator('.live-state').innerText(), /Live · checked \d/);

  // Today, open on another screen, follows the till by itself.
  const today = await browser.newPage({ viewport: { width: 1440, height: 900 } });
  await today.goto(BASE + '/');
  await today.locator('.hero .hero-figure').waitFor();
  await today.locator('.today-eyebrow .live-state').waitFor();
  const salesBefore = await today.locator('.hero .hero-figure').innerText();

  const till = await browser.newPage({ viewport: { width: 1440, height: 900 } });
  await till.goto(BASE + '/billing');
  const tillScan = till.locator('input.scan-input');
  await tillScan.waitFor();
  await tillScan.fill('tea');
  await till.locator('ul.suggestions li').first().waitFor();
  await tillScan.press('Enter');
  await till.locator('table.lines-table tbody tr').first().waitFor();
  await till.locator('.pay-modes button', { hasText: 'Cash' }).click();
  await till.locator('.quick-cash button', { hasText: 'Exact' }).click();
  await tillScan.focus();
  await till.keyboard.press('F9');
  await till.getByRole('heading', { name: 'Bill saved' }).waitFor();
  const liveNumber = await till.locator('.saved-number').innerText();
  await till.close();
  await page.locator('table.bill-list tr.is-new', { hasText: liveNumber }).waitFor({ timeout: 25000 });
  assert.strictEqual(await billCount(), before + 1);
  await page.screenshot({ path: `${OUT}/4b-bills-live.png` });
  step(`bill ${liveNumber} made at another till shows up by itself, marked new`);

  await today.waitForFunction(was => document.querySelector('.hero .hero-figure')?.innerText !== was, salesBefore, { timeout: 35000 });
  await today.screenshot({ path: `${OUT}/4d-today-live.png` });
  step(`Today's sales went from ${salesBefore} to ${await today.locator('.hero .hero-figure').innerText()} by themselves`);
  await today.close();

  await page.getByRole('button', { name: 'Older' }).click();
  await page.locator('.pager-count', { hasText: /^Page 2 of / }).waitFor();
  assert.ok(!(await page.locator('table.bill-list').innerText()).includes(liveNumber));
  await page.getByRole('button', { name: 'Oldest' }).click();
  await page.locator('.pager-count', { hasText: new RegExp(`^Page ${Math.ceil((before + 1) / 50)} of `) }).waitFor();
  assert.match(page.url(), /\/bills\?page=\d+$/);
  assert.ok((await page.locator('table.bill-list tbody tr').last().innerText()).includes('SR/24-25/0001'), 'the very first bill is on the last page');
  step('paging reaches the very first bill (SR/24-25/0001)');

  await page.getByRole('button', { name: 'Newest' }).click();
  await page.locator('.pager-count', { hasText: /^Page 1 of / }).waitFor();
  const billSearch = page.locator('input[aria-label="Search bills"]');
  await billSearch.fill(number);
  await page.waitForFunction(() => document.querySelectorAll('table.bill-list tbody tr').length === 1);
  assert.strictEqual(await billCount(), 1);
  assert.ok(page.url().includes('q=' + encodeURIComponent(number)));
  step(`searching the bill number finds just ${number}`);

  await page.locator('table.bill-list tbody tr').first().click();
  await page.getByRole('heading', { name: 'Bill ' + number }).waitFor();
  const itemsText = await page.locator('table.bill-items').innerText();
  for (const item of ['Basmati Rice', 'Toned Milk 500 ml', 'Milk Chocolate 50 g']) {
    assert.ok(itemsText.includes(item), `${item} is on the bill`);
  }
  assert.strictEqual(await page.locator('.bill-aside .grand strong').innerText(), '₹595.00');
  assert.match(await page.locator('.payments').innerText(), /Cash[\s\S]*₹595\.00/);
  await page.screenshot({ path: `${OUT}/4c-bill.png` });
  step('a bill opens with its items, total and payment');

  await page.locator('.eyebrow a', { hasText: 'Bills' }).click();
  await page.waitForFunction(() => document.querySelectorAll('table.bill-list tbody tr').length === 1);
  assert.strictEqual(await billSearch.inputValue(), number);
  step('back on the list, the search is still there');

  await page.getByRole('button', { name: 'Clear search' }).click();
  await page.getByRole('button', { name: 'Money owed' }).click();
  await page.waitForFunction(() => location.search.includes('owed=true'));
  await page.locator('table.bill-list tbody tr').first().waitFor();
  const statuses = await page.locator('table.bill-list tbody td:last-child').allInnerTexts();
  assert.ok(statuses.length > 0 && statuses.every(t => / due$/.test(t.trim())), 'only bills with money owed');
  step(`"Money owed" shows only bills given on credit (${statuses.length} on the first page)`);

  await page.goto(BASE + '/sales');
  const hours = page.locator('section.panel', { has: page.locator('h2', { hasText: 'Sales by hour of day' }) });
  await hours.waitFor({ timeout: 30000 });
  assert.match(await hours.locator('.panel-head').innerText(), /Busiest: \d{1,2}(–\d{1,2})? (am|pm)/);
  assert.ok(await hours.locator('svg path.c-bar').count() >= 10, 'a bar for every opening hour');
  step('sales by hour of day, with the busiest hours');

  const csv = await page.request.get(BASE + '/bills.csv');
  assert.strictEqual(csv.status(), 200);
  assert.match(csv.headers()['content-disposition'], /^attachment; filename="?bills\.csv"?;/);
  const lines = (await csv.text()).replace(/^\uFEFF/, '').trim().split('\n');
  assert.strictEqual(lines[0], 'Bill no.,Date,Time,Customer,Total,Paid,Balance');
  assert.strictEqual(lines.length - 1, before + 1, 'the download has every bill');
  step(`download: every bill (${lines.length - 1}) as a spreadsheet`);

  await page.getByRole('link', { name: 'Products' }).click();
  const search = page.locator('input[aria-label="Search products"]');
  await search.waitFor();
  await search.fill('milk');
  await page.waitForTimeout(300);
  const milkRow = page.locator('table.data-table tbody tr', { hasText: 'Toned Milk 500 ml' });
  assert.ok((await milkRow.innerText()).includes('34'), 'toned milk stock 36 - 2 sold = 34');
  await search.fill('');
  await page.waitForTimeout(300);
  await page.screenshot({ path: `${OUT}/5-products.png` });
  step('products: stock of toned milk fell from 36 to 34');

  await page.getByRole('link', { name: 'Low stock' }).click();
  await page.locator('table.data-table tbody tr').first().waitFor();
  await page.screenshot({ path: `${OUT}/6-low-stock.png` });
  step('low stock list renders');

  // Phone-width layout
  await page.setViewportSize({ width: 390, height: 844 });
  await page.goto(BASE + '/billing');
  await page.locator('input.scan-input').waitFor();
  const overflow = await page.evaluate(() => document.documentElement.scrollWidth - window.innerWidth);
  assert.ok(overflow <= 1, `no sideways scroll at 390px (overflow ${overflow}px)`);
  await page.screenshot({ path: `${OUT}/7-mobile.png`, fullPage: true });
  for (const route of ['/bills', '/bills/1']) {
    await page.goto(BASE + route);
    await page.locator('.kpis').waitFor();
    const sideways = await page.evaluate(() => document.documentElement.scrollWidth - window.innerWidth);
    assert.ok(sideways <= 1, `no sideways scroll on ${route} at 390px (overflow ${sideways}px)`);
  }
  step('phone width: no horizontal scrolling on billing, bills and a bill');

  // Common shop-PC screen: total and Save must be visible without scrolling
  await page.setViewportSize({ width: 1366, height: 768 });
  await page.goto(BASE + '/billing');
  const box = page.locator('input.scan-input');
  await box.waitFor();
  for (const term of ['ghee', 'atta', 'tea', 'soap', 'dal']) {
    await box.fill(term);
    await page.locator('ul.suggestions li').first().waitFor();
    await box.press('Enter');
    await page.waitForTimeout(200);
  }
  assert.strictEqual(await page.locator('table.lines-table tbody tr').count(), 5);
  for (const sel of ['button.save-btn', '.side-footer .grand']) {
    const b = await page.locator(sel).boundingBox();
    assert.ok(b && b.y >= 0 && b.y + b.height <= 768, `${sel} fully visible at 1366x768 (bottom ${b && b.y + b.height})`);
  }
  await page.screenshot({ path: `${OUT}/8-billing-1366x768.png` });
  step('1366x768: total and Save button visible without scrolling');

  await browser.close();
  if (problems.length) {
    console.error('Browser problems:\n' + problems.join('\n'));
    process.exit(1);
  }
  console.log('No console errors, page errors or failed requests.');
})().catch(async e => { console.error('FAILED: ' + e.message); process.exit(1); });
