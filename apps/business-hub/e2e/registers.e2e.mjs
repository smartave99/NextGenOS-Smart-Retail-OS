// The tax registers in the browser: a bill to a buyer with a tax number shows in the sales register with that number and in the country's B2B list; the summary by code counts what was sold; the
// pages download as files; a country whose pack has no lists and no item code shows only the registers.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('registers');
const step = (s) => console.log('✓ ' + s);
let hub;
try {
  // ---- India ----------------------------------------------------------------------------------------------------------------------------
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'People');
  await page.locator('#add-person').click();
  await page.locator('#p-name').fill('Registered Ltd');
  await page.locator('#p-tax').fill('27AAPFU0939F1ZV');
  await page.getByRole('button', { name: 'Save' }).click();
  await page.getByText('Registered Ltd').first().waitFor();

  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Soft drink');
  await page.locator('#f-price').fill('118');
  await page.locator('#f-bar').fill('8900000000011');
  await page.locator('#f-code').fill('2202');
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();

  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  await page.getByPlaceholder(/Search by name or phone/).fill('Registered');
  await page.locator('.chips button', { hasText: 'Registered Ltd' }).click();
  await page.locator('.cart strong', { hasText: 'Registered Ltd' }).waitFor();
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  assert.match(await page.locator('.receipt').innerText(), /27AAPFU0939F1ZV/);
  step('a bill to a buyer with a tax number prints the number');

  await go(page, 'GST registers');
  await page.locator('#register-table').waitFor();
  const sales = await page.locator('#register-table').innerText();
  assert.match(sales, /Registered Ltd/);
  assert.match(sales, /27AAPFU0939F1ZV/);
  assert.match(sales, /CGST/);
  await shot(page, '1-sales-register');
  step('the sales register has the bill, with the buyer\'s number and each tax part');

  await page.getByRole('tab', { name: /^B2B/ }).click();
  await page.locator('#register-table h2', { hasText: /^B2B/ }).waitFor();            // a click only sends the request: wait until the screen shows the other list
  assert.match(await page.locator('#register-table').innerText(), /Registered Ltd/);
  await page.getByRole('tab', { name: /^B2CS/ }).click();
  await page.locator('#register-table h2', { hasText: /^B2CS/ }).waitFor();
  assert.match(await page.locator('#register-table').innerText(), /Nothing in these days/);
  step('the bill is in the B2B list and not in the list for buyers without a number');

  await page.getByRole('tab', { name: 'HSN or SAC code' }).click();
  await page.locator('#register-codes').waitFor();
  assert.match(await page.locator('#register-codes').innerText(), /2202/);
  assert.strictEqual(await page.locator('#codes-missing').count(), 0);
  step('the summary by code counts what was sold under its code');

  const csv = await page.request.get(hub.url + '/export/register-sales.csv');
  assert.strictEqual(csv.status(), 200);
  assert.match(await csv.text(), /27AAPFU0939F1ZV/);
  const codesCsv = await page.request.get(hub.url + '/export/codes.csv');
  assert.match(await codesCsv.text(), /2202/);
  step('the registers download as files for a spreadsheet');
  await page.close();
  await hub.stop();

  // ---- the Philippines: registers, no lists, no code summary ----------------------------------------------------------------------------
  hub = await startHub();
  const ph = await newPage(browser, problems);
  await setUp(ph, hub, { name: 'Manila Mart', country: 'Philippines', industry: 'retail', demo: false });
  await signIn(ph, hub);
  await go(ph, 'VAT registers');
  await ph.locator('#register-table').waitFor();
  const tabs = await ph.locator('#register-tabs').innerText();
  assert.match(tabs, /Sales/);
  assert.doesNotMatch(tabs, /B2B|HSN/);
  step('in the Philippines there are the registers and no GST lists');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe tax registers work: the bills as the tax books want them, the country\'s own lists, and nothing of them where the pack has none.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
