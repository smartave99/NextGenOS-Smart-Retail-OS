// Discounts at the till: a line discount (a percent or an amount), a discount on the whole bill that is spread over the lines so the tax falls with it, who may give one
// (owners and managers always; a cashier only up to the limit the owner sets), the bill that shows it, and giving goods back from a discounted bill.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('discounts');
const step = (s) => console.log('✓ ' + s);
const money = (text) => Number(text.replace(/[^\d.]/g, ''));
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail' });
  await signIn(page, hub);

  // ---- a line discount, then one on the whole bill -----------------------------------------------------------------------------------
  await go(page, 'New sale');
  const scan = page.locator('#scan');
  await scan.waitFor();
  await scan.fill('8901000000019');
  await scan.press('Enter');
  await page.locator('.line').first().waitFor();
  const full = money(await page.locator('#total').innerText());
  assert.strictEqual(await page.locator('#discount-given').count(), 0, 'no discount line before one is given');

  const lineBox = page.getByLabel(/^Discount on Basmati/);
  await lineBox.fill('10%');
  await lineBox.press('Tab');
  await page.locator('#discount-given').waitFor();
  const afterLine = money(await page.locator('#total').innerText());
  assert.ok(afterLine < full * 0.91 && afterLine > full * 0.89, `10% off the line: ${full} became ${afterLine}`);
  assert.strictEqual(await lineBox.inputValue(), '10%');
  step('a percent typed on a line comes off the line, and the tax falls with it');

  await lineBox.fill('25');
  await lineBox.press('Tab');
  await page.waitForFunction((before) => Number(document.querySelector('#total').innerText.replace(/[^\d.]/g, '')) !== before, afterLine);
  const afterAmount = money(await page.locator('#total').innerText());
  assert.ok(Math.abs((full - afterAmount) - 25) < 0.011, `25 off the line (prices include the tax): ${full} became ${afterAmount}`);
  assert.strictEqual(await lineBox.inputValue(), '25.00');
  step('a plain number typed on a line is an amount of money');

  const bill = page.locator('#bill-discount');
  await bill.fill('5%');
  await bill.press('Tab');
  await page.waitForFunction((before) => Number(document.querySelector('#total').innerText.replace(/[^\d.]/g, '')) < before, afterAmount);
  const afterBill = money(await page.locator('#total').innerText());
  assert.ok(afterBill < afterAmount, 'the whole-bill discount lowers the total further');
  await shot(page, '1-discounted-cart');
  await bill.fill('abc');
  await bill.press('Tab');
  await page.locator('.notice.error', { hasText: /Please type a discount/ }).waitFor();
  await bill.fill('999999');
  await bill.press('Tab');
  await page.locator('.notice.error', { hasText: /more than the bill/ }).waitFor();
  step('a discount on the whole bill lowers the total again; nonsense and a discount bigger than the bill are refused in plain words');

  await page.getByLabel('Amount received').fill('1000');
  await page.getByRole('button', { name: 'Add payment' }).click();
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /Discount given/);
  assert.ok(receipt.includes('₹' + afterBill.toFixed(2)) || receipt.includes(afterBill.toLocaleString('en-IN', { minimumFractionDigits: 2 })), 'the bill shows the discounted total ' + afterBill);
  await shot(page, '2-discounted-bill');
  step('the bill shows the discount given and the discounted total');

  // giving goods back from a discounted bill: the credit note gives back what was paid for them, not the list price
  const billUrl = page.url();
  await page.locator('#give-back').click();
  await page.getByLabel(/Giving back: Basmati/).fill('1');
  await page.locator('#save-return').click();
  await page.waitForURL((u) => /\/documents\/\d+(\?.*)?$/.test(u.pathname) && u.toString() !== billUrl);
  const note = await page.locator('.receipt', { hasText: 'Credit note' }).innerText();
  assert.match(note, /Discount given/);
  step('one bag back from the discounted bill makes a credit note that carries its share of the discount');

  // ---- a cashier: no discount at all until the owner allows some, then only up to the limit --------------------------------------------
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'People' }).click();
  await page.getByLabel('Name', { exact: true }).fill('Tara Till');
  await page.getByLabel('User name', { exact: true }).fill('till');
  await page.getByLabel('Role', { exact: true }).selectOption({ label: 'Cashier / front desk' });
  await page.locator('#u-pass').fill('another-good-password');
  await page.locator('#add-user').click();
  await page.getByText(/Added\./).waitFor();

  const till = await newPage(browser, problems);
  await signIn(till, hub, 'till', 'another-good-password');
  await go(till, 'New sale');
  await till.locator('#scan').fill('8901000000019');
  await till.locator('#scan').press('Enter');
  await till.locator('.line').first().waitFor();
  assert.strictEqual(await till.locator('#bill-discount').count(), 0, 'a cashier is not offered a discount until the owner allows some');
  step('a cashier is not offered a discount until the owner allows some');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Business' }).click();
  await page.locator('#s-cdisc').fill('5');
  await page.locator('#save-shop').click();
  await page.getByText('Saved.').first().waitFor();

  await till.reload();
  await go(till, 'New sale');
  await till.locator('#scan').fill('8901000000019');
  await till.locator('#scan').press('Enter');
  await till.locator('.line').first().waitFor();
  const cashierFull = money(await till.locator('#total').innerText());
  const tillBill = till.locator('#bill-discount');
  await tillBill.fill('10%');
  await tillBill.press('Tab');
  await till.locator('.notice.error', { hasText: /up to 5% of a bill/ }).waitFor();
  assert.strictEqual(money(await till.locator('#total').innerText()), cashierFull, 'a discount over the limit is not kept');
  await tillBill.fill('4%');
  await tillBill.press('Tab');
  await till.locator('#discount-given').waitFor();
  assert.ok(money(await till.locator('#total').innerText()) < cashierFull);
  step('a cashier can give a discount up to the owner\'s limit and no more');

  assert.deepStrictEqual(problems.filter((p) => !/403|400/.test(p)), [], 'the browser saw problems');
  console.log('\nDiscounts at the till work as agreed: by line and by bill, tax falling with them, with limits for cashiers.');
} catch (e) {
  console.error(e);
  console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  await hub.stop();
}
