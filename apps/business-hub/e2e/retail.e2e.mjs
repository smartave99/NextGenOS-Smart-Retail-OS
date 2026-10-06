// A shop: sign in, ring up a sale with a scanned barcode, take cash, print the bill, take something back, add an item.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('retail');
const step = (s) => console.log('✓ ' + s);
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail' });
  await signIn(page, hub);
  step('set up a retail shop with the sample company and signed in');

  await go(page, 'New sale');
  const scan = page.locator('#scan');
  await scan.waitFor();
  assert.ok(await scan.evaluate((el) => el === document.activeElement), 'the scan box has focus on arrival');
  await scan.fill('8901000000019');           // a scanner types the barcode, then Enter
  await scan.press('Enter');
  await page.locator('.line').first().waitFor();
  assert.match(await page.locator('.line .nm').first().innerText(), /Basmati rice/);
  await scan.fill('8901000000019');
  await scan.press('Enter');
  await page.waitForFunction(() => document.querySelector('.line .qty')?.value === '2');
  step('scanning the same barcode twice makes one line of 2');

  assert.match(await page.locator('#total').innerText(), /^₹[\d,]+\.\d\d$/);
  const total = await page.locator('#total').innerText();
  await shot(page, '1-cart');
  await page.getByLabel('Amount received').fill('1000');
  await page.getByRole('button', { name: 'Add payment' }).click();
  await page.locator('#change').waitFor();
  step('cash of 1000 shows the change to give');

  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  await page.locator('.receipt').waitFor();
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /Corner Mart/);
  assert.match(receipt, /Tax Invoice/);
  assert.match(receipt, /CGST/);
  assert.match(receipt, /SGST/);
  assert.ok(receipt.includes(total), 'the bill shows the total ' + total);
  assert.match(receipt, /Change/);
  await shot(page, '2-bill');
  step('the bill: shop, tax invoice, CGST and SGST, total and change');

  // Take one bag back
  const billUrl = page.url();
  await page.locator('#give-back').click();
  await page.getByLabel(/Giving back: Basmati/).fill('1');
  await page.locator('#save-return').click();
  await page.waitForURL((u) => /\/documents\/\d+(\?.*)?$/.test(u.pathname) && u.toString() !== billUrl);
  await page.locator('.receipt', { hasText: 'Credit note' }).waitFor();
  step('taking one bag back makes a credit note');

  // A new item with a tax class and a barcode, then sold by scan
  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.getByLabel('Name', { exact: true }).fill('Test Soap');
  await page.getByLabel(/Price/).fill('59');
  await page.getByLabel('Barcode').fill('4006381333931');
  await page.locator('#save-item').click();
  await page.getByText('Test Soap').waitFor();
  step('a new product is added');

  // A duplicate barcode is refused in plain words
  await page.locator('#add-item').click();
  await page.getByLabel('Name', { exact: true }).fill('Another');
  await page.getByLabel(/Price/).fill('10');
  await page.getByLabel('Barcode').fill('4006381333931');
  await page.locator('#save-item').click();
  assert.match(await page.locator('.sheet .notice.error').innerText(), /barcode/i);
  await page.getByRole('button', { name: 'Cancel' }).click();
  step('a barcode used twice is refused');

  // The list of bills
  await go(page, 'Invoices');
  await page.getByRole('heading', { name: 'Invoices' }).waitFor();
  await page.getByText('INV-2026-').first().waitFor();
  assert.ok(await page.locator('.tbl tbody tr').count() > 20);
  step('the list of bills');

  // Sign out
  await page.getByRole('button', { name: 'Sign out' }).click();
  await page.waitForURL('**/login');
  await page.goto(hub.url + '/sell');
  await page.waitForURL(/\/login/);
  step('signed out: the counter needs signing in again');
} finally {
  await browser.close();
  if (problems.length) console.log('browser problems:', problems);
  await hub.stop();
  process.exitCode = problems.length ? 1 : process.exitCode;
}
