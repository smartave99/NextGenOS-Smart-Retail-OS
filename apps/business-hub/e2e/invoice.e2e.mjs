// The bill as a full page in the browser (the older POS's tax invoice, merge): the receipt stays the starting look; one bill can be shown as a full A4 or A5 page; the page has the shop's
// tax number, each line with its tax parts, the tax for each rate, the total in words (India's pack gives the money's words), the terms the shop typed and a place to sign; the shop can
// choose the full page for every bill; a country whose pack gives no words shows no line in words.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('invoice');
const step = (s) => console.log('✓ ' + s);
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Business' }).click();
  await page.locator('#s-tax').fill('27AAPFU0939F1ZV');
  await page.locator('#s-terms').fill('Pay within 7 days.\nBank: Test Bank 123');
  await page.locator('#save-shop').click();
  await page.getByText('Saved.').first().waitFor();

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
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  await page.locator('#receipt').waitFor();
  assert.strictEqual(await page.locator('#invoice').count(), 0, 'the receipt is the starting look');
  step('the bill is a receipt at first');

  await page.locator('#layout-a4').click();
  await page.locator('#invoice').waitFor();
  assert.strictEqual(await page.locator('#receipt').count(), 0);
  const text = await page.locator('#invoice').innerText();
  assert.match(text, /Corner Mart/);
  assert.match(text, /27AAPFU0939F1ZV/);
  assert.match(text, /CGST/);
  assert.match(text, /SGST/);
  assert.match(text, /2202/, 'the item code is on the line');
  assert.match(text, /Pay within 7 days\./);
  assert.match(text, /Authorised signature/);
  await page.locator('#tax-by-rate').waitFor();
  assert.match(await page.locator('#tax-by-rate').innerText(), /9\.00/, 'each half of 18 percent on 100.00');
  assert.match(await page.locator('#inv-words').innerText(), /One hundred eighteen rupees only/);
  assert.match(await page.locator('#inv-total').innerText(), /118\.00/);
  await shot(page, '1-a4');
  step('the full page has the tax number, the tax parts, the code, the tax by rate, the total in words, the terms and the signing line');

  await page.locator('#layout-a5').click();
  await page.locator('#invoice.a5').waitFor();
  await page.locator('#layout-receipt').click();
  await page.locator('#receipt').waitFor();
  step('A5 and the receipt are one click away');

  // the shop chooses the full page for every bill
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Business' }).click();
  await page.locator('#s-layout').selectOption('a4');
  await page.locator('#save-shop').click();
  await page.getByText('Saved.').first().waitFor();
  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  await page.locator('#invoice').waitFor();
  step('with the full page chosen in Settings, the next bill opens as a full page');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe full-page bill works in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
