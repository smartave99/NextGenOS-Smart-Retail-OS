// Offers, coupons and gift vouchers in the browser: the owner makes an offer for a bill, a free-goods offer and a gift-voucher rule, gives a customer a standing discount and a coupon; the till uses
// them by itself (the cashier may leave the bill offer out); a coupon works once; a bill that earns a gift voucher prints its words; the words come from Settings.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('offers');
const step = (s) => console.log('✓ ' + s);
const money = (text) => Number(text.replace(/[^\d.]/g, ''));
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail' });
  await signIn(page, hub);

  const scanBasmati = async () => {
    const scan = page.locator('#scan');
    await scan.waitFor();
    await scan.fill('8901000000019');
    await scan.press('Enter');
    await page.locator('.line').first().waitFor();
  };
  const total = async () => money(await page.locator('#total').innerText());
  const startSale = async () => { await go(page, 'New sale'); await scanBasmati(); };
  const pickCustomer = async (name) => {
    await page.getByPlaceholder(/Search by name or phone/).fill(name);
    await page.locator('.chips button', { hasText: name }).click();
    await page.locator('.cart strong', { hasText: name }).waitFor();
  };

  // ---- nothing about offers on the till until there is something to show ------------------------------------------------------------
  await startSale();
  const plain = await total();
  assert.strictEqual(await page.locator('#offers').count(), 0, 'no offers area before any offer or coupon exists');
  await page.getByRole('button', { name: 'Cancel' }).click();
  step('the till shows nothing about offers until the shop makes some');

  // ---- a customer, with a standing discount ---------------------------------------------------------------------------------------------
  await go(page, 'People');
  await page.locator('#add-person').click();
  await page.locator('#p-name').fill('Offer Test');
  await page.locator('#p-discount').fill('10');
  await page.getByRole('button', { name: 'Save' }).click();
  await page.getByText('Offer Test').first().waitFor();
  await startSale();
  await pickCustomer('Offer Test');
  await page.getByLabel(/^Discount on Basmati/).waitFor();
  assert.strictEqual(await page.getByLabel(/^Discount on Basmati/).inputValue(), '10%', 'the customer\'s standing discount is on the line');
  const withRate = await total();
  assert.ok(withRate < plain * 0.91 && withRate > plain * 0.89, `10% off: ${plain} became ${withRate}`);
  await page.getByRole('button', { name: 'Cancel' }).click();
  step('a customer\'s standing discount goes on every line by itself');

  // ---- a free-goods offer ---------------------------------------------------------------------------------------------------------------------
  await go(page, 'Offers');
  await page.locator('#add-offer').click();
  await page.locator('#o-kind').selectOption('buy-get');
  await page.locator('#o-find').fill('Basmati');
  await page.locator('.sheet .chips button').first().click();
  await page.locator('#o-min').fill('3');
  await page.locator('#o-free').fill('1');
  await page.locator('#save-offer').click();
  await page.getByText('Saved.').first().waitFor();
  assert.match(await page.locator('#offers-table').innerText(), /buy 3, get 1 free/);
  step('the owner makes an offer: buy 3, get 1 free');

  await startSale();
  await page.getByLabel(/^Quantity of Basmati/).fill('3');
  await page.getByLabel(/^Quantity of Basmati/).press('Tab');
  await page.locator('.free-goods').waitFor();
  assert.match(await page.locator('.free-goods').innerText(), /Free/);
  assert.match(await page.locator('.free-goods').innerText(), /1 free/);
  const three = await total();
  assert.ok(three > plain * 2.5 && three < plain * 3.5, `three are paid for, the fourth is free: ${plain} each, ${three} for the bill`);
  await shot(page, '1-free-goods');
  step('the till adds the free one on its own line, and charges for three');
  await page.getByRole('button', { name: 'Cancel' }).click();

  // ---- an offer on the whole bill, which the cashier may leave out -------------------------------------------------------------------------
  await go(page, 'Offers');
  await page.locator('#add-offer').click();
  await page.locator('#o-name').fill('Welcome offer');
  await page.locator('#o-from').fill('1');
  await page.locator('#o-amount').fill('5');
  await page.locator('#save-offer').click();
  await page.getByText('Saved.').first().waitFor();
  await startSale();
  await page.locator('#offers .offer-row[data-offer="bill-offer"]').waitFor();
  assert.match(await page.locator('#offers').innerText(), /Welcome offer/);
  const withOffer = await total();
  assert.ok(withOffer < plain, `the offer lowers the bill: ${plain} to ${withOffer}`);
  await page.getByRole('button', { name: 'Leave out Welcome offer' }).click();
  await page.locator('#use-offer').waitFor();
  assert.strictEqual(await total(), plain, 'left out, the bill is back to its price');
  await page.locator('#use-offer').click();
  await page.locator('#offers .offer-row[data-offer="bill-offer"]').waitFor();
  step('an offer for the whole bill is used by itself; the cashier can leave it out and take it again');
  await page.getByRole('button', { name: 'Cancel' }).click();

  // ---- a coupon: made for a customer, used once ---------------------------------------------------------------------------------------------------
  await go(page, 'Offers');
  await page.locator('#tab-coupons').click();
  await page.locator('#c-find').fill('Offer Test');
  await page.locator('.chips button', { hasText: 'Offer Test' }).click();
  await page.locator('#c-amount').fill('10');
  await page.locator('#make-coupons').click();
  await page.locator('#made-coupons').waitFor();
  const code = (await page.locator('#made-coupons .codes-made').first().innerText()).trim();
  assert.match(code, /^[A-Z2-9]{4}-[A-Z2-9]{4}$/);
  await shot(page, '2-coupon-made');
  step('the owner makes a coupon for a customer and gets its code (' + code + ')');

  await startSale();
  await page.getByRole('button', { name: 'Leave out Welcome offer' }).click();          // keep the arithmetic to the coupon alone
  await page.locator('#voucher-code').fill('not-a-code');
  await page.locator('#use-code').click();
  await page.locator('.notice.error', { hasText: 'was not found' }).waitFor();
  await page.locator('#voucher-code').fill(code.toLowerCase());
  await page.locator('#use-code').click();
  await page.locator('#offers .offer-row[data-offer="coupon"]').waitFor();
  const withCoupon = await total();
  assert.ok(withCoupon < plain - 9 && withCoupon > plain - 12, `a coupon of 10 (tax included in the price) lowers ${plain} to ${withCoupon}`);
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, new RegExp('Coupon ' + code));
  assert.match(receipt, /Discount given/);
  step('a coupon typed in small letters works; the bill names it');

  await startSale();
  await page.locator('#voucher-code').fill(code);
  await page.locator('#use-code').click();
  await page.locator('.notice.error', { hasText: 'already used' }).waitFor();
  step('the same coupon is refused the second time, in plain words');
  await page.getByRole('button', { name: 'Cancel' }).click();

  // ---- a gift voucher: earned by a bill, its words from Settings ----------------------------------------------------------------------------------
  await go(page, 'Settings');
  await page.locator('#s-gift').fill('Present {code} for {amount} - {valid}');
  await page.locator('#save-shop').click();
  await page.getByText('Saved.').first().waitFor();
  await go(page, 'Offers');
  await page.locator('#add-offer').click();
  await page.locator('#o-kind').selectOption('gift-rule');
  await page.locator('#o-from').fill('1');
  await page.locator('#o-amount').fill('3');
  await page.locator('#save-offer').click();
  await page.getByText('Saved.').first().waitFor();
  await startSale();
  await pickCustomer('Offer Test');
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const gift = await page.locator('.gift-text').innerText();
  assert.match(gift, /^Present [A-Z2-9]{4}-[A-Z2-9]{4} for .*3\.00 - any day$/, 'the words are the shop\'s own: ' + gift);
  await shot(page, '3-gift-on-bill');
  step('a bill to a named customer earns a gift voucher, printed in the words set in Settings');

  await go(page, 'Offers');
  await page.locator('#tab-gifts').click();
  await page.locator('#voucher-table').waitFor();
  assert.match(await page.locator('#voucher-table').innerText(), /Ready/);
  step('the gift voucher is in the list, ready to use');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nOffers work: a standing discount, free goods, an offer for the bill, a coupon used once, a gift voucher with the shop\'s own words.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  await hub.stop();
}
