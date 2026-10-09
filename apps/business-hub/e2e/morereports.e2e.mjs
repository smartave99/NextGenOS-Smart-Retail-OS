// The older POS's report set in the browser (merge, reports): bill by bill with how each was paid and the profit, profit by item, most and least sold, what was bought, one item's sales, and what is out of stock.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('morereports');
const step = (s) => console.log('✓ ' + s);
const money = (text) => Number(text.replace(/[^0-9.]/g, ''));
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'Products');
  for (const [name, price, cost, bar] of [['Rice', '100', '60', '8900000000011'], ['Tea', '50', '30', '8900000000028']]) {
    await page.locator('#add-item').click();
    await page.locator('#f-name').fill(name);
    await page.locator('#f-price').fill(price);
    await page.locator('#f-cost').fill(cost);
    await page.locator('#f-bar').fill(bar);
    const track = page.getByLabel('Keep count of how many I have');
    if (!(await track.isChecked())) await track.check();
    await page.locator('#save-item').click();
    await page.getByText('Saved.').first().waitFor();
  }
  await page.locator('tbody tr', { hasText: 'Rice' }).getByRole('button', { name: 'Stock' }).click();
  await page.locator('#s-delta').fill('10');
  await page.locator('#save-stock').click();
  await page.getByText('Stock updated.').first().waitFor();
  step('Rice (cost 60, price 100) has 10 on the shelf; Tea has none');

  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  const qty = page.getByLabel(/^Quantity of Rice/);
  await qty.fill('2');
  await qty.press('Tab');
  await page.waitForTimeout(300);
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);

  await go(page, 'Reports');
  await page.locator('#more-reports').click();
  await page.getByRole('heading', { name: 'More reports' }).waitFor();
  await page.locator('#bills-table tbody tr').first().waitFor();
  const row = await page.locator('#bills-table tbody tr').first().innerText();
  const head = await page.locator('#bills-table thead').innerText();
  assert.match(head, /Cash/i, 'a column for the way it was paid');
  assert.match(row, /120\.00/, 'the goods cost 2 x 60.00');
  assert.ok(money(await page.locator('#bills-profit').innerText()) > 0, 'the bill earned more than the goods cost');
  await shot(page, '1-bills');
  step('the bill is listed with a Cash column, the cost of its goods (120.00) and its profit');

  await page.locator('#tab-profit').click();
  await page.locator('#profit-table tbody tr', { hasText: 'Rice' }).waitFor();
  step('profit by item lists Rice');

  await page.locator('#tab-selling').click();
  await page.locator('#best-table tbody tr', { hasText: 'Rice' }).waitFor();
  await page.locator('#low-table tbody tr', { hasText: 'Rice' }).waitFor();
  step('Rice is among the most and the least sold (it is the only thing sold)');

  await page.locator('#tab-history').click();
  await page.locator('#h-item').selectOption({ label: 'Rice' });
  await page.locator('#history-table tbody tr').first().waitFor();
  step('one item\'s sales: Rice has its line');

  await page.locator('#tab-buying').click();
  await page.getByText('Nothing bought in these days.').waitFor();
  await page.locator('#tab-out').click();
  await page.locator('#out-table tbody tr', { hasText: 'Tea' }).waitFor();
  assert.strictEqual(await page.locator('#out-table tbody tr', { hasText: 'Rice' }).count(), 0, 'Rice still has 8');
  await shot(page, '2-out');
  step('nothing was bought; Tea is out of stock and Rice is not');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe older POS\'s reports work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
