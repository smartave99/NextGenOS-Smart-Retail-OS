// A café: seat guests, take an order, send it to the kitchen, cook it, add service charge and tip, split the bill.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go, fakePrinter } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const bar = await fakePrinter();
const shot = shots('restaurant');
const step = (s) => console.log('✓ ' + s);
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Test Café', industry: 'restaurant' });
  await signIn(page, hub);
  const side = await page.getByRole('navigation', { name: 'Main' }).innerText();
  assert.match(side, /Tables/); assert.match(side, /Kitchen/); assert.doesNotMatch(side, /Desk|Projects|Bookings/);
  step('a café sees Tables and Kitchen, and not the library desk or projects');

  // A printer for the bar: its orders print as they are sent.
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Printers' }).click();
  await page.locator('#add-printer').click();
  await page.getByLabel('Name', { exact: true }).fill('Bar printer');
  await page.getByLabel('It prints').selectOption('kitchen');
  await page.getByLabel('Address of the printer').fill(`127.0.0.1:${bar.port}`);
  await page.getByLabel('Prints the orders of').fill('Bar');
  await page.locator('#save-printer').click();
  await page.getByText(/Saved\. Press/).waitFor();

  await go(page, 'Tables');
  await page.locator('.tile').first().waitFor();
  assert.strictEqual(await page.locator('.tile').count(), 7);
  assert.strictEqual(await page.locator('.tile.busy').count(), 3);
  await shot(page, '1-floor');
  step('seven tables, three of them with guests');

  await page.getByRole('button', { name: /Table T1, free/ }).click();
  await page.getByLabel('How many guests?').fill('3');
  await page.locator('#seat').click();
  await page.waitForURL(/\/order\/\d+$/);
  await page.getByRole('heading', { name: 'Table T1' }).waitFor();
  await page.locator('.item-btn', { hasText: 'Espresso' }).click();
  await page.locator('.item-btn', { hasText: 'Cappuccino' }).click();
  await page.locator('.item-btn', { hasText: 'Cappuccino' }).click();
  await page.locator('.item-btn', { hasText: 'Butter croissant' }).click();
  await page.locator('.line', { hasText: 'Cappuccino' }).waitFor();
  assert.match(await page.locator('.line', { hasText: 'Cappuccino' }).innerText(), /2 × Cappuccino/);
  await page.getByLabel('Note for Espresso').fill('Extra hot');
  await page.getByLabel('Note for Espresso').press('Tab');
  await page.locator('#send').click();
  await page.getByText(/Sent to/).waitFor();
  assert.strictEqual(await page.locator('.line .chip', { hasText: 'Sent' }).count(), 3);
  await new Promise((r) => setTimeout(r, 300));
  assert.match(bar.text(), /BAR/); assert.match(bar.text(), /Table T1/); assert.match(bar.text(), /Espresso/); assert.match(bar.text(), />> Extra hot/);
  assert.doesNotMatch(bar.text(), /croissant/i);
  step('table T1: three guests, three lines (one with a note) sent to the kitchen and the bar');

  // The kitchen
  await go(page, 'Kitchen');
  await page.locator('.ticket').first().waitFor();
  const mine = page.locator('.ticket', { hasText: 'Table T1' });
  assert.strictEqual(await mine.count(), 2);                    // one for the bar, one for the kitchen
  assert.match(await page.locator('.ticket', { hasText: 'Extra hot' }).innerText(), /Espresso/);
  await shot(page, '2-kitchen');
  for (const label of ['Start', 'Ready', 'Served']) {
    await page.locator('.ticket', { hasText: 'Table T1' }).first().getByRole('button', { name: label }).click();
    await page.waitForTimeout(250);
  }
  step('the kitchen screen: tickets for the bar and the kitchen, note shown, moved to served');

  // Service charge, tip, split bill, pay
  await go(page, 'Tables');
  await page.getByRole('button', { name: /Table T1, in use/ }).click();
  await page.locator('#total').waitFor();
  const before = await page.locator('#total').innerText();
  await page.locator('.chips[aria-label="Tip"] button', { hasText: '10%' }).click();
  await page.waitForFunction((t) => document.querySelector('#total').innerText !== t, before);
  const withTip = await page.locator('#total').innerText();
  await page.locator('#split').fill('2');
  await page.locator('#add-payment').click();
  await page.locator('#add-payment').click();
  await shot(page, '3-bill');
  await page.locator('#pay').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /Service charge/);
  assert.match(receipt, /Tip/);
  assert.match(receipt, /CGST/);
  assert.ok(receipt.includes(withTip), `the bill shows ${withTip}`);
  step('service charge and a 10% tip on the bill, split between two payments, closed with a numbered bill');

  // The table is free again
  await go(page, 'Tables');
  await page.getByRole('button', { name: /Table T1, free/ }).waitFor();
  step('the table is free again');

  // A takeaway that is cancelled
  await page.locator('#takeaway').click();
  await page.waitForURL(/\/order\/\d+$/);
  await page.locator('.item-btn', { hasText: 'Masala chai' }).click();
  await page.locator('#cancel-order').click();
  await page.getByLabel('Why is it cancelled?').fill('Customer left');
  await page.locator('#confirm-cancel').click();
  await page.waitForURL('**/tables');
  step('a takeaway order can be cancelled with a reason');

  // Reports for a café
  await go(page, 'Reports');
  await page.getByRole('heading', { name: 'Tables' }).waitFor();
  assert.ok((await page.locator('#r-count').innerText()) > 0);
  step('the report has table turnover');
} finally {
  await browser.close();
  await bar.close();
  if (problems.length) console.log('browser problems:', problems);
  await hub.stop();
  process.exitCode = problems.length ? 1 : process.exitCode;
}
