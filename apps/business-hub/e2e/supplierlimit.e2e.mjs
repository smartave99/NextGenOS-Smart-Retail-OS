// The most the shop may owe a supplier, in the browser (the older POS's supplier credit limit, merge, suppliers): a limit is set on the supplier; goods that would take what is owed over it are refused in
// plain words and nothing arrives; paying part of what is owed makes room; a total exactly at the limit is allowed.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('supplierlimit');
const step = (s) => console.log('✓ ' + s);
let hub;

async function order(page, cost) {
  await go(page, 'Buying');
  await page.locator('#new-order').click();
  await page.getByLabel('Supplier').selectOption({ label: 'Grain Co' });
  await page.locator('#po-item').selectOption({ label: 'Rice' });
  await page.getByLabel('How many').fill('1');
  await page.getByLabel('Cost of each').fill(String(cost));
  await page.locator('#add-order-line').click();
  await page.locator('#save-order').click();
  await page.getByText(/The order is placed/).waitFor();
}

try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'People');
  await page.getByRole('tab', { name: 'Suppliers' }).click();
  await page.locator('#add-person').click();
  await page.locator('#p-name').fill('Grain Co');
  await page.locator('#p-limit').fill('1000');
  await page.locator('#save-person').click();
  await page.getByText('Saved.').first().waitFor();

  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Rice');
  await page.locator('#f-price').fill('10');
  await page.locator('#f-bar').fill('8900000000011');
  const track = page.getByLabel('Keep count of how many I have');
  if (!(await track.isChecked())) await track.check();
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();
  step('a supplier with a limit of 1,000.00 and an item are set up');

  await order(page, 600);
  await page.getByRole('button', { name: 'Goods arrived' }).first().click();
  await page.getByText('Stock is updated.').first().waitFor();
  step('goods of 600.00 arrive: 600.00 is owed');

  await order(page, 500);
  await page.getByRole('button', { name: 'Goods arrived' }).first().click();
  await page.getByText(/owing Grain Co ₹1,100\.00, more than the limit of ₹1,000\.00/).first().waitFor();
  await shot(page, '1-refused');
  step('500.00 more would make 1,100.00: refused in plain words, the goods did not arrive');

  // pay part of the first order (the first row with an amount still owed is the first order), then the second can arrive
  await page.getByRole('button', { name: 'To pay' }).click();
  await page.locator('tbody tr', { hasText: '600.00' }).getByRole('button', { name: 'Pay' }).click();
  await page.locator('#pp-amt').fill('100');
  await page.locator('#save-supplier-payment').click();
  await page.getByText('Payment saved.').first().waitFor();
  await page.getByRole('button', { name: 'To receive' }).click();
  await page.getByRole('button', { name: 'Goods arrived' }).first().click();
  await page.getByText('Stock is updated.').first().waitFor();
  step('paying 100.00 first makes room: 500.00 + 500.00 is exactly the limit, and the goods arrive');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe supplier limit works in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
