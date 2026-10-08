// A customer's account: what they owe, line by line; money received without naming a bill (oldest bills first, any extra kept as credit);
// credit used on a later bill; a return kept as credit instead of money back.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('accounts');
const step = (s) => console.log('✓ ' + s);
const money = (text) => Number(text.replace(/[^\d.]/g, ''));
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Trade Supplies', industry: 'wholesale' });
  await signIn(page, hub);

  // a customer who may buy on account
  await go(page, 'People');
  await page.locator('#add-person').click();
  await page.locator('#p-name').fill('Credit Test Store');
  await page.locator('#p-limit').fill('100000');
  await page.getByRole('button', { name: 'Save' }).click();
  await page.getByText('Credit Test Store').first().waitFor();
  step('a customer with a credit limit is added');

  const sellOnAccount = async () => {
    await go(page, 'Take an order');
    await page.locator('#scan').waitFor();
    await page.locator('.items .item-btn').first().click();
    await page.locator('.line').first().waitFor();
    await page.getByPlaceholder(/Search by name or phone/).fill('Credit Test');
    await page.locator('.chips button', { hasText: 'Credit Test Store' }).click();
    const total = money(await page.locator('#total').innerText());
    return total;
  };

  const total = await sellOnAccount();
  await page.getByRole('button', { name: 'Put on account' }).click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  await page.getByRole('link', { name: 'Credit Test Store' }).click();
  await page.waitForURL(/\/account\/\d+/);
  assert.strictEqual(money(await page.locator('#balance').innerText()), total, 'the account shows the bill');
  assert.match(await page.locator('#statement').innerText(), /Bill INV-/);
  await shot(page, '1-owes');
  step('a sale put on account shows on the customer\'s account, line by line');

  // part payment, then more than is owed
  const part = Math.round(total / 4);
  await page.locator('#r-amount').fill(String(part));
  await page.locator('#receive').click();
  await page.getByText(/Received/).first().waitFor();
  assert.ok(Math.abs(money(await page.locator('#balance').innerText()) - (total - part)) < 0.011, 'the part payment lowers what is owed');
  await page.locator('#r-amount').fill(String(total));      // more than the rest
  await page.locator('#receive').click();
  await page.getByText(/kept as credit for the next bill/).waitFor();
  await page.locator('.stat .label', { hasText: 'Has credit' }).waitFor();
  const credit = money(await page.locator('#balance').innerText());
  assert.ok(Math.abs(credit - part) < 0.011, `the extra ${part} is kept as credit: ${credit}`);
  await shot(page, '2-credit');
  step('money received settles the bill; what is over is kept as credit');

  // the credit pays a later bill without money
  const second = await sellOnAccount();
  assert.ok(second > credit, 'the next bill is bigger than the credit');
  await page.locator('#use-credit').click();
  await page.getByText('Credit on account').first().waitFor();
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  assert.match(await page.locator('.receipt').innerText(), /Credit on account/);
  step('the credit is used on the next bill (the rest paid in cash)');

  // a return kept as credit
  await page.locator('#give-back').click();
  await page.getByLabel(/Giving back:/).first().fill('1');
  await page.locator('#r-kind').selectOption({ label: "stays as credit on the customer's account" });
  await page.locator('#save-return').click();
  await page.locator('.receipt', { hasText: 'Credit note' }).waitFor();
  await page.getByRole('link', { name: 'Credit Test Store' }).click();
  await page.waitForURL(/\/account\/\d+/);
  await page.locator('.stat .label', { hasText: 'Has credit' }).waitFor();
  assert.match(await page.locator('#statement').innerText(), /Credit note/);
  step('a return can be kept as credit on the customer\'s account instead of money back');

  // the books: the two sides always equal
  await go(page, 'Books');
  await page.locator('#b-trial').waitFor();
  assert.strictEqual(await page.locator('#b-debit').innerText(), await page.locator('#b-credit').innerText(), 'debits equal credits');
  assert.ok(Math.abs(money(await page.locator('#b-assets').innerText()) - money(await page.locator('#b-liab').innerText()) - money(await page.locator('#b-worth').innerText())) < 0.011, 'what the shop has = what it owes + what it is worth');
  step('the Books page shows debits equal to credits');

  // the list shows it
  await go(page, 'People');
  await page.locator('tr', { hasText: 'Credit Test Store' }).locator('td.num', { hasText: /^Credit / }).waitFor();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nA customer\'s account works: line by line, money received, credit kept and used.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  await hub.stop();
}
