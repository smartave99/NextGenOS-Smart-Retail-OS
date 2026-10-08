// A wholesaler: trade prices, selling on account to a customer with a limit, taking payments later, what is owed, buying stock.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('wholesale');
const step = (s) => console.log('✓ ' + s);
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Test Wholesale', industry: 'wholesale' });
  await signIn(page, hub);

  await go(page, 'Take an order');
  await page.locator('#scan').waitFor();
  await page.locator('#scan').fill('8902000000016');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  const retail = await page.locator('.line .amt').first().innerText();
  await page.getByPlaceholder('Search by name or phone (or leave empty)').fill('Sharma');
  await page.getByRole('button', { name: 'Sharma General Store' }).click();
  await page.waitForFunction((r) => document.querySelector('.line .amt').innerText !== r, retail);
  const trade = await page.locator('.line .amt').first().innerText();
  step('choosing the trade customer changes the price from ' + retail + ' to the trade price ' + trade);

  await page.getByRole('button', { name: 'Put on account' }).click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  await page.locator('.receipt').waitFor();
  assert.match(await page.locator('.receipt').innerText(), /Balance due/);
  assert.match(await page.locator('main').innerText(), /Unpaid/);
  step('the order is put on account: the bill shows the balance due');

  await page.locator('#take-payment').click();
  await page.locator('#pay-amount').fill('1000');
  await page.locator('#save-payment').click();
  await page.getByText('Payment saved.').waitFor();
  assert.match(await page.locator('main').innerText(), /Part paid/);
  step('a part payment is taken: the bill shows it as part paid');

  await go(page, 'Reports');
  await page.getByRole('heading', { name: 'Owed to you' }).waitFor();
  assert.match(await page.locator('main').innerText(), /Sharma General Store/);
  step('the report of money owed lists the customer');

  // A customer over the limit is refused
  await go(page, 'Take an order');
  await page.locator('#scan').fill('8902000000016');
  await page.locator('#scan').press('Enter');
  await page.getByPlaceholder('Search by name or phone (or leave empty)').fill('Sharma');
  await page.getByRole('button', { name: 'Sharma General Store' }).click();
  await page.getByLabel('Quantity of Rice 25 kg').fill('200');
  await page.getByLabel('Quantity of Rice 25 kg').press('Tab');
  await page.getByRole('button', { name: 'Put on account' }).click();
  await page.locator('.notice.error').waitFor();
  assert.match(await page.locator('.notice.error').innerText(), /credit limit/i);
  await shot(page, '1-over-limit');
  step('a sale that would go over the credit limit is refused in plain words');

  // Buying stock
  await go(page, 'Buying');
  await page.locator('#new-order').click();
  await page.getByLabel('Supplier').selectOption({ label: 'National Foods Ltd' });
  await page.locator('#po-item').selectOption({ label: 'Rice 25 kg' });
  await page.getByLabel('How many').fill('40');
  await page.getByLabel('Cost of each').fill('1500');
  await page.locator('#add-order-line').click();
  await page.locator('#save-order').click();
  await page.getByText(/The order is placed/).waitFor();
  await page.getByRole('button', { name: 'Goods arrived' }).first().click();
  await page.getByText('Stock is updated.').waitFor();
  step('an order to a supplier is placed and received: stock goes up');

  // Sending some of it back (merge wave 2: purchase returns)
  // The list is filtered by the Hub after the choice is made, so wait until every row on it is of the kind chosen before reading it (reading at once may see the whole list).
  const showOnly = async (kind, word) => {
    await page.getByLabel('Kind').selectOption(kind);
    await page.waitForFunction((w) => {
      const rows = [...document.querySelectorAll('main table tbody tr')];
      return rows.length > 0 && rows.every((r) => r.innerText.includes(w));
    }, word);
  };
  await page.goto(hub.url + '/documents');
  await showOnly('purchase', 'Purchase');
  await page.locator('main table tbody tr a').first().click();
  await page.locator('#send-back').click();
  assert.match(await page.locator('#send-back-panel').innerText(), /taken back|put against what is still unpaid/);
  await page.getByLabel('Sending back: Rice 25 kg').fill('3');
  await page.locator('#sb-why').fill('torn bags');
  await page.locator('#save-send-back').click();
  await page.getByRole('heading', { name: /^Debit note DN-/ }).waitFor();
  assert.match(await page.locator('main').innerText(), /Debit note/);
  await shot(page, '2-sent-back');
  await page.goto(hub.url + '/documents');
  await showOnly('debit-note', 'Debit note');
  assert.strictEqual(await page.locator('main table tbody tr').count(), 1);
  await page.locator('main table tbody tr a').first().click();
  await page.getByRole('heading', { name: /^Debit note DN-/ }).waitFor();
  await page.goto(hub.url + '/documents');
  await showOnly('purchase', 'Purchase');
  await page.locator('main table tbody tr a').first().click();
  await page.getByRole('heading', { name: 'Goods sent back for this purchase' }).waitFor();
  step('goods can be sent back to the supplier: a debit note is made, it is listed, and the purchase shows it');

  await page.goto(hub.url + '/registers');
  await page.getByRole('tab', { name: 'Goods sent back' }).click();
  await page.getByRole('heading', { name: 'Goods sent back to suppliers' }).waitFor();
  await page.locator('main table tbody tr', { hasText: /DN-\d{4}-000001/ }).waitFor();
  assert.strictEqual(await page.locator('main table tbody tr').count(), 1);
  step('the tax registers list the goods sent back');
} finally {
  await browser.close();
  if (problems.length) console.log('browser problems:', problems);
  await hub.stop();
  process.exitCode = problems.length ? 1 : process.exitCode;
}
