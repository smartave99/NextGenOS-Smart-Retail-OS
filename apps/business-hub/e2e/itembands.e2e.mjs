// Quantity discounts in the browser (the older POS's "Item / Product Discount", merge, products tools B): bands are set up for an item on the Offers screen, and the till gives the discount of
// the band the quantity is in, takes it away when the quantity leaves the bands, and never overwrites a discount somebody typed.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('itembands');
const step = (s) => console.log('✓ ' + s);
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

  await go(page, 'Offers');
  await page.locator('#tab-bands').click();
  await page.locator('#band-find').fill('Ric');
  await page.locator('.chips button', { hasText: 'Rice' }).click();
  await page.locator('#band-from').fill('5');
  await page.locator('#band-to').fill('9');
  await page.locator('#band-pct').fill('5');
  await page.locator('#add-band').click();
  await page.getByText('The band was added.').first().waitFor();
  await page.locator('#band-from').fill('10');
  await page.locator('#band-pct').fill('10');
  await page.locator('#add-band').click();
  await page.locator('#bands-table tbody tr', { hasText: 'no limit' }).waitFor();
  // a band that overlaps one that is there is refused in plain words
  await page.locator('#band-from').fill('8');
  await page.locator('#band-to').fill('12');
  await page.locator('#band-pct').fill('7');
  await page.locator('#add-band').click();
  await page.getByText(/already covers some of those quantities/).first().waitFor();
  await shot(page, '1-bands');
  step('two bands are set for Rice (5 to 9 gives 5 percent, 10 and more gives 10), and an overlapping band is refused in plain words');

  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  const box = page.getByLabel(/^Discount on Rice/);
  const qty = page.getByLabel(/^Quantity of Rice/);
  assert.strictEqual(await box.inputValue(), '', 'one kilo: no band, no discount');
  await qty.fill('7');
  await qty.press('Tab');
  await page.waitForFunction(() => document.querySelector('input[aria-label^="Discount on Rice"]')?.value === '5%');
  await shot(page, '2-seven');
  step('7 of them: the 5 percent band gives its discount by itself');
  await qty.fill('12');
  await qty.press('Tab');
  await page.waitForFunction(() => document.querySelector('input[aria-label^="Discount on Rice"]')?.value === '10%');
  step('12 of them: the 10 percent band');
  await qty.fill('3');
  await qty.press('Tab');
  await page.waitForFunction(() => document.querySelector('input[aria-label^="Discount on Rice"]')?.value === '');
  step('3 of them: below every band, the discount goes (the older program gave the largest one here)');

  // a discount somebody typed stays
  await box.fill('2%');
  await box.press('Tab');
  await page.waitForFunction(() => document.querySelector('input[aria-label^="Discount on Rice"]')?.value === '2%');
  await qty.fill('12');
  await qty.press('Tab');
  await page.waitForTimeout(500);
  const typed = await box.inputValue();
  assert.strictEqual(typed, '2%', `the typed discount stays when the quantity changes: ${typed}`);
  step('a discount a person typed is left alone when the quantity changes');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nQuantity discounts work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
