// Salespeople and brokers in the browser (the older POS's two commission methods, merge, staff part 1): a person is added on the Staff screen, named on a sale at the till, the commission is owed
// to them, a payment is recorded (paying more than is owed is allowed, with a warning in plain words), and the summary adds it up.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('staff');
const step = (s) => console.log('✓ ' + s);
const money = (text) => Number(text.replace(/[^0-9.]/g, ''));
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Rice');
  await page.locator('#f-price').fill('100');
  await page.locator('#f-bar').fill('8900000000011');
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();

  await go(page, 'Staff');
  await page.getByRole('heading', { name: 'Staff' }).waitFor();
  await page.locator('#add-earner').click();
  await page.locator('#e-name').fill('Asha');
  await page.locator('#e-phone').fill('9800000001');
  await page.locator('#e-pct').fill('2.5');
  await page.locator('#save-earner').click();
  await page.getByText('Saved.').first().waitFor();
  await page.locator('tbody tr', { hasText: 'Asha' }).getByText('2.5%').waitFor();
  // the same phone number twice is refused in plain words
  await page.locator('#add-earner').click();
  await page.locator('#e-name').fill('Asha Two');
  await page.locator('#e-phone').fill('9800000001');
  await page.locator('#save-earner').click();
  await page.getByText(/Another salesperson has that phone number/).first().waitFor();
  await page.getByRole('button', { name: 'Cancel' }).click();
  await page.locator('#kind-broker').click();
  await page.locator('#add-earner').click();
  await page.locator('#e-name').fill('Ravi');
  await page.locator('#save-earner').click();
  await page.getByText('Saved.').first().waitFor();
  await page.locator('tbody tr', { hasText: 'Ravi' }).waitFor();
  await shot(page, '1-people');
  step('a salesperson (2.5 percent) and a broker are added; the same phone number twice is refused');

  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  await page.locator('#salesperson').selectOption({ label: 'Asha' });
  await page.locator('#broker').selectOption({ label: 'Ravi' });
  await page.locator('#broker-unit').selectOption('amount');
  await page.locator('#broker-value').fill('10');
  await page.locator('#broker-value').press('Tab');
  await shot(page, '2-till');
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  step('the sale is made with Asha as the salesperson and Ravi as the broker (10 for this bill)');

  await go(page, 'Staff');
  await page.locator('#tab-owed').click();
  await page.locator('#o-person').selectOption({ label: 'Asha (salesperson)' });
  await page.locator('#statement tbody tr', { hasText: 'Commission on bill' }).waitFor();
  const owed = money(await page.locator('#owed-now').innerText());
  assert.ok(owed > 0 && owed < 3, `2.5 percent of a 100 sale is a little under 2.50: ${owed}`);
  await shot(page, '3-owed');
  step(`Asha is owed ${owed} (2.5 percent of the sale before tax)`);

  await page.locator('#o-person').selectOption({ label: 'Ravi (broker)' });
  await page.locator('#statement tbody tr', { hasText: 'Commission on bill' }).waitFor();
  assert.strictEqual(money(await page.locator('#owed-now').innerText()), 10, 'the broker is owed the amount typed for the bill');
  step('Ravi is owed exactly the 10 typed for the bill');

  // pay a part, then more than is owed
  await page.locator('#o-person').selectOption({ label: 'Asha (salesperson)' });
  await page.locator('#statement').waitFor();
  await page.locator('#o-amount').fill('0.5');
  await page.locator('#pay-earner').click();
  await page.getByText('Recorded.').first().waitFor();
  await page.locator('#statement tbody tr', { hasText: 'Paid in cash' }).waitFor();
  const after = money(await page.locator('#owed-now').innerText());
  assert.ok(Math.abs(owed - 0.5 - after) < 0.011, `0.50 paid: ${owed} -> ${after}`);
  await page.locator('#o-amount').fill('50');
  await page.locator('#pay-earner').click();
  await page.getByText(/more than was earned/).first().waitFor();
  assert.strictEqual(money(await page.locator('#owed-now').innerText()), 0, 'nothing is owed after paying too much');
  step('a part payment lowers what is owed; paying more than is owed is allowed and says so in plain words');

  await page.locator('#tab-summary').click();
  await page.locator('#summary tbody tr', { hasText: 'Asha' }).waitFor();
  await page.locator('#summary tbody tr', { hasText: 'Ravi' }).waitFor();
  await shot(page, '4-summary');
  step('the summary lists both with what was earned and paid');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nSalespeople and brokers work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
