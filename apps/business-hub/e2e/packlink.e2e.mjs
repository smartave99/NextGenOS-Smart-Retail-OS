// Selling loose from a box in the browser (the older POS's alternate unit, merge, products tools): a loose item is linked to its box, a sale of pieces opens a box by itself, and a box can be opened by hand.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('packlink');
const step = (s) => console.log('✓ ' + s);
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  const track = async () => { const t = page.getByLabel('Keep count of how many I have'); if (!(await t.isChecked())) await t.check(); };
  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Biscuits box');
  await page.locator('#f-price').fill('600');
  await page.locator('#f-cost').fill('400');
  await page.locator('#f-bar').fill('8900000000011');
  await track();
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();
  await page.locator('tbody tr', { hasText: 'Biscuits box' }).getByRole('button', { name: 'Stock' }).click();
  await page.locator('#s-delta').fill('10');
  await page.locator('#save-stock').click();
  await page.getByText('Stock updated.').first().waitFor();

  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Biscuits');
  await page.locator('#f-price').fill('50');
  await page.locator('#f-bar').fill('8900000000028');
  await track();
  await page.locator('#f-pack').selectOption({ label: 'Biscuits box' });
  await page.locator('#f-perpack').fill('1');
  await page.locator('#save-item').click();
  await page.getByText(/A pack must hold two or more whole pieces/).first().waitFor();
  await page.locator('#f-perpack').fill('12');
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();
  step('Biscuits are linked to the box with 12 in one; a pack of one is refused in plain words');

  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000028');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  const qty = page.getByLabel(/^Quantity of Biscuits/);
  await qty.fill('6');
  await qty.press('Tab');
  await page.waitForTimeout(300);
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);

  await go(page, 'Products');
  const chip = async (name) => (await page.locator('tbody tr', { hasText: name }).first().innerText());
  assert.match(await chip('Biscuits box'), /\b9\b/, 'one box was opened: nine are left');
  assert.match(await page.locator('tbody tr').filter({ hasText: 'Biscuits' }).filter({ hasNotText: 'Biscuits box' }).first().innerText(), /\b6\b/, '12 pieces came out of the box and six were sold');
  await shot(page, '1-after-sale');
  step('selling 6 pieces opened a box by itself: 9 boxes and 6 pieces are left');

  await page.locator('tbody tr').filter({ hasText: 'Biscuits' }).filter({ hasNotText: 'Biscuits box' }).getByRole('button', { name: 'Stock' }).click();
  await page.locator('#open-pack').click();
  await page.getByText('A pack was opened.').first().waitFor();
  assert.match(await chip('Biscuits box'), /\b8\b/);
  step('a box can be opened by hand from the stock sheet');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nSelling loose from a box works in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
