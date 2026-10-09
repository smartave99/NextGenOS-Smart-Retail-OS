// Batch numbers and expiry dates in the browser (the older POS's lots, merge, products tools): an item that keeps batches is switched on, a delivery names its batch and dates (the batch is asked for,
// and refused in plain words when missing), out of date stock is listed, and the till sells the batch that expires first, never the out of date one, and the bill says which batches the goods came from.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('batches');
const step = (s) => console.log('✓ ' + s);
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Pharmacy', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'People');
  await page.getByRole('tab', { name: 'Suppliers' }).click();
  await page.locator('#add-person').click();
  await page.locator('#p-name').fill('Pharma Co');
  await page.locator('#save-person').click();
  await page.getByText('Saved.').first().waitFor();

  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Paracetamol');
  await page.locator('#f-price').fill('50');
  await page.locator('#f-bar').fill('8900000000099');
  const track = page.getByLabel('Keep count of how many I have');
  if (!(await track.isChecked())) await track.check();
  await page.locator('#f-batches').check();
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();
  step('Paracetamol is set to keep batch numbers and expiry dates');

  // two deliveries, each naming its batch
  for (const [qty, no, exp] of [['100', 'A100', '2031-12-31'], ['50', 'B200', '2030-06-30']]) {
    await go(page, 'Buying');
    await page.locator('#new-order').click();
    await page.getByLabel('Supplier').selectOption({ label: 'Pharma Co' });
    await page.locator('#po-item').selectOption({ label: 'Paracetamol' });
    await page.getByLabel('How many').fill(qty);
    await page.getByLabel('Cost of each').fill('10');
    await page.locator('#add-order-line').click();
    await page.locator('#save-order').click();
    await page.getByText(/The order is placed/).waitFor();
    await page.getByRole('button', { name: 'Goods arrived' }).first().click();
    await page.locator('#confirm-receive').waitFor();
    if (no === 'A100') {
      await page.locator('#confirm-receive').click();
      await page.getByText(/Please give the batch number of Paracetamol/).first().waitFor();
      await shot(page, '1-batch-asked');
    }
    await page.locator('input[id^="rb-no-"]').first().fill(no);
    await page.locator('input[id^="rb-exp-"]').first().fill(exp);
    await page.locator('#confirm-receive').click();
    await page.getByText('Stock is updated.').first().waitFor();
  }
  step('a delivery without a batch number is refused in plain words; with it, 100 of A100 and 50 of B200 are in stock');

  // out of date stock found on the shelf
  await go(page, 'Products');
  await page.locator('tbody tr', { hasText: 'Paracetamol' }).getByRole('button', { name: 'Stock' }).click();
  await page.locator('#s-delta').fill('20');
  await page.locator('#s-batch').fill('OLD');
  await page.locator('#s-exp').fill('2020-01-31');
  await page.locator('#save-stock').click();
  await page.getByText('Stock updated.').first().waitFor();

  await page.locator('#items-batches').click();
  await page.locator('#batches-table tbody tr[data-state="expired"]', { hasText: 'OLD' }).waitFor();
  await page.getByText('Out of date', { exact: true }).first().waitFor();
  await shot(page, '2-expiry');
  step('the batch that is out of date is listed under "Out of date or soon"');

  // the till
  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000099');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  const qty = page.getByLabel(/^Quantity of Paracetamol/);
  await qty.fill('60');
  await qty.press('Tab');
  await page.waitForTimeout(300);
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /Batch B200, expires 30 Jun 2030/, receipt);
  assert.match(receipt, /Batch A100, expires 31 Dec 2031/, receipt);
  assert.doesNotMatch(receipt, /Batch OLD/, 'the out of date batch is never sold');
  await shot(page, '3-bill');
  step('60 are sold: 50 come from B200 (it expires first) and 10 from A100, and the bill says so; the out of date batch is not touched');

  await go(page, 'Products');
  await page.locator('#items-batches').click();
  await page.locator('#show-all').click();
  const rowFor = (no) => page.locator('#batches-table tbody tr', { hasText: no });
  await rowFor('A100').getByText(/90/).waitFor();
  assert.match(await rowFor('OLD').innerText(), /20/);
  assert.strictEqual(await rowFor('B200').count(), 0, 'a batch with nothing left is not listed');
  step('what is left: A100 has 90, OLD still has its 20, B200 is used up');

  // a wrong date is put right
  await rowFor('A100').getByRole('button', { name: /Change the dates/ }).click();
  await page.locator('#d-exp').fill('2031-11-30');
  await page.locator('#save-dates').click();
  await page.getByText('Saved.').first().waitFor();
  await rowFor('A100').getByText('30 Nov 2031').waitFor();
  step('the expiry date of a batch can be corrected');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nBatches and expiry work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
