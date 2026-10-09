// The stock movement report, the day book and the cash and bank books in the browser (the older POS's reports, merge wave 2): what came in and went out of an item, each move one by one with its
// reason, the books' day book with a bill and its payment, the cash book with the money the till took, and the files for a spreadsheet.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('stockbooks');
const step = (s) => console.log('✓ ' + s);
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Soft drink');
  await page.locator('#f-price').fill('118');
  await page.locator('#f-bar').fill('8900000000011');
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();
  // a delivery of 10, and one damaged
  await page.getByRole('button', { name: 'Stock' }).first().click();
  await page.locator('#s-delta').fill('10');
  await page.locator('#save-stock').click();
  await page.getByText('Stock updated.').first().waitFor();
  await page.getByRole('button', { name: 'Stock' }).first().click();
  await page.locator('#s-delta').fill('-1');
  await page.locator('#s-why').selectOption('damaged');
  await page.locator('#save-stock').click();
  await page.getByText('Stock updated.').first().waitFor();

  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  step('a delivery of 10, one damaged and one sold');

  await go(page, 'Reports');
  await page.locator('#r-movement').waitFor();
  const row = page.locator('#r-movement tbody tr', { hasText: 'Soft drink' });
  await row.waitFor();
  // before 0, in 10, out 2 (the sale and the damaged one), left 8
  const cells = (await row.locator('td').allInnerTexts()).map((t) => t.replace(/\s*pc$/i, '').trim());
  assert.deepStrictEqual(cells.slice(1), ['0', '10', '2', '8'], `before, in, out, left: ${cells.join(' | ')}`);
  await shot(page, '1-movement');
  step('the report shows what was held before, what came in, what went out (damage too) and what is left');

  await row.locator('button.link').click();
  await page.locator('#r-card').waitFor();
  const card = await page.locator('#r-card').innerText();
  assert.match(card, /Delivery received/);
  assert.match(card, /Damaged or expired/);
  assert.match(card, /Sold on/);
  step('each move of the item is listed with its reason in words');

  const csv = await page.request.get(hub.url + '/export/stock-movement.csv');
  assert.strictEqual(csv.status(), 200);
  assert.match(await csv.text(), /Soft drink/);
  step('the report downloads as a file for a spreadsheet');

  await go(page, 'Books');
  await page.locator('#b-income').waitFor();
  await page.locator('#b-tab-day').click();
  await page.locator('#b-daybook').waitFor();
  const day = await page.locator('#b-daybook').innerText();
  assert.match(day, /Bill/);
  assert.match(day, /Payment/);
  await shot(page, '2-daybook');
  step('the day book lists the bill and its payment, entry by entry');

  await page.locator('#b-tab-money').click();
  await page.locator('#b-money').waitFor();
  assert.match(await page.locator('#b-money-title').innerText(), /Cash/);
  assert.match(await page.locator('#b-money').innerText(), /Before these days/);
  assert.match(await page.locator('#b-money-close').innerText(), /₹118\.00/);
  await shot(page, '3-cash');
  step('the cash book has the money the till took, and the figure at the end');

  const daybook = await page.request.get(hub.url + '/export/daybook.csv');
  assert.strictEqual(daybook.status(), 200);
  assert.match(await daybook.text(), /Payment/);
  const money = await page.request.get(hub.url + '/export/moneybook.csv?way=cash');
  assert.strictEqual(money.status(), 200);
  assert.match(await money.text(), /Before this period/);
  step('the day book and the cash book download as files');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe stock movement report, the day book and the cash book work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
