// Changing many items at once, in the browser (the older POS's bulk price and bulk tax change, merge, products tools A): choose items, see what would change before it is saved, save it, read the
// record, take it back, type a new price beside each item, take items off sale. Nothing of this changes a bill already made.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('itemchanges');
const step = (s) => console.log('✓ ' + s);
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  for (const [name, price] of [['Soap', '100'], ['Tea', '50'], ['Rice', '200']]) {
    await go(page, 'Products');
    await page.locator('#add-item').click();
    await page.locator('#f-name').fill(name);
    await page.locator('#f-price').fill(price);
    await page.locator('#save-item').click();
    await page.getByText('Saved.').first().waitFor();
  }

  await go(page, 'Products');
  await page.locator('#change-many').click();
  await page.locator('#ch-items').waitFor();
  const priceOf = async (name) => (await page.locator('#ch-items tbody tr', { hasText: name }).locator('td.num').first().innerText()).replace(/[^\d.]/g, '');

  // everything shown, 10 percent up: the preview says what would change and nothing is saved yet
  await page.locator('#ch-all').click();
  await page.locator('#ch-count', { hasText: '3 chosen' }).waitFor();
  await page.locator('#ch-value').fill('10');
  await page.locator('#ch-preview-price').click();
  await page.locator('#ch-preview-table').waitFor();
  assert.match(await page.locator('#ch-summary').innerText(), /The price of 3 items raised by 10 percent/);
  assert.match(await page.locator('#ch-preview-table').innerText(), /110\.00/);
  assert.strictEqual(await priceOf('Soap'), '100.00', 'nothing is saved by looking');
  await shot(page, '1-preview');
  step('the preview shows what would change and saves nothing');

  await page.locator('#ch-save').click();
  await page.getByText('Saved: 3 items changed.').first().waitFor();
  assert.strictEqual(await priceOf('Soap'), '110.00');
  assert.strictEqual(await priceOf('Rice'), '220.00');
  await page.locator('#ch-history tbody tr').first().getByRole('button', { name: 'Details' }).click();
  await page.locator('#ch-detail').waitFor();
  assert.match(await page.locator('#ch-detail').innerText(), /Soap[\s\S]*100\.00[\s\S]*110\.00/);
  await shot(page, '2-saved');
  step('saved: the prices are up and the record says what each item was and became');

  await page.locator('#ch-history tbody tr').first().getByRole('button', { name: /Take back/ }).click();
  await page.getByText('Taken back: 3 items').first().waitFor();
  assert.strictEqual(await priceOf('Soap'), '100.00');
  assert.strictEqual(await priceOf('Rice'), '200.00');
  assert.match(await page.locator('#ch-history').innerText(), /Taken back/);
  step('taken back: the prices are as they were, and the taking back is in the record');

  // a new price typed beside one item
  await page.locator('#ch-none').click();
  await page.locator('#ch-how').selectOption('type');
  await page.locator('#ch-items tbody tr', { hasText: 'Tea' }).locator('input[inputmode=decimal]').fill('60');
  await page.locator('#ch-preview-price').click();
  await page.locator('#ch-preview-table').waitFor();
  assert.match(await page.locator('#ch-summary').innerText(), /The price of 1 item set to the price typed/);
  await page.locator('#ch-save').click();
  await page.getByText('Saved: 1 item changed.').first().waitFor();
  assert.strictEqual(await priceOf('Tea'), '60.00');
  assert.strictEqual(await priceOf('Soap'), '100.00');
  step('a price typed beside one item changes that item and no other');

  // something that cannot be read is refused in plain words
  await page.locator('#ch-how').selectOption('percent');
  await page.locator('#ch-none').click();
  await page.locator('#ch-items tbody tr', { hasText: 'Soap' }).getByRole('checkbox').check();
  await page.locator('#ch-value').fill('abc');
  await page.locator('#ch-preview-price').click();
  await page.getByText('Please type the percent as a number').first().waitFor();
  step('a percent that is not a number is refused in plain words');

  // off sale and back
  await page.locator('#ch-tab-sale').click();
  await page.locator('#ch-off').click();
  await page.getByText('1 item taken off sale.').first().waitFor();
  await page.locator('#ch-items tbody tr', { hasText: 'Soap' }).getByText('Not sold').waitFor();
  await page.locator('#ch-on').click();
  await page.getByText('1 item put back on sale.').first().waitFor();
  step('items are taken off sale and put back');

  // labels: with no label printer set up the screen says where to add one (the printing itself is tested against a stand-in printer)
  await page.locator('#ch-tab-labels').click();
  await page.locator('#ch-no-label-printer').waitFor();
  assert.match(await page.locator('#ch-items thead').innerText(), /labels/i);
  step('the Labels tab shows a column for the number of labels and says where to add a label printer');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nChanging many items at once works in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
