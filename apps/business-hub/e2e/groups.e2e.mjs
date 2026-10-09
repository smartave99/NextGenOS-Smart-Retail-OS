// Quick groups in the browser (the older POS's combo packs, merge, products tools): a group of items is made, one press at the till adds every item at its usual quantity and its own price, and the
// group's own barcode does the same.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('groups');
const step = (s) => console.log('✓ ' + s);
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'Products');
  for (const [name, price, bar] of [['Bread', '40', '8900000000011'], ['Milk', '30', '8900000000028']]) {
    await page.locator('#add-item').click();
    await page.locator('#f-name').fill(name);
    await page.locator('#f-price').fill(price);
    await page.locator('#f-bar').fill(bar);
    await page.locator('#save-item').click();
    await page.getByText('Saved.').first().waitFor();
  }

  await page.locator('#items-groups').click();
  await page.locator('#groups-empty').waitFor();
  await page.locator('#add-group').click();
  await page.locator('#g-name').fill('Breakfast');
  await page.locator('#g-bar').fill('BF-1');
  await page.locator('.sheet select').nth(0).selectOption({ label: 'Bread' });
  await page.getByLabel('How many of item 1').fill('1');
  await page.locator('.sheet select').nth(1).selectOption({ label: 'Milk' });
  await page.getByLabel('How many of item 2').fill('2');
  await page.locator('#save-group').click();
  await page.getByText('Saved.').first().waitFor();
  await page.locator('#groups-table tbody tr', { hasText: 'Breakfast' }).getByText(/1 × Bread, 2 × Milk/).waitFor();
  // the same name again is refused in plain words
  await page.locator('#add-group').click();
  await page.locator('#g-name').fill('breakfast');
  await page.locator('.sheet select').nth(0).selectOption({ label: 'Bread' });
  await page.locator('#save-group').click();
  await page.getByText(/Another group has that name/).first().waitFor();
  await shot(page, '1-groups');
  await page.getByRole('button', { name: 'Cancel' }).click();
  step('the group Breakfast (1 Bread, 2 Milk) is made; a second group with the same name is refused in plain words');

  await go(page, 'New sale');
  await page.locator('.group-chip', { hasText: 'Breakfast' }).click();
  await page.locator('.line').nth(1).waitFor();
  const text = await page.locator('main').innerText();
  assert.match(text, /Bread/);
  assert.match(text, /Milk/);
  assert.strictEqual(await page.getByLabel(/^Quantity of Bread/).inputValue(), '1');
  assert.strictEqual(await page.getByLabel(/^Quantity of Milk/).inputValue(), '2');
  await shot(page, '2-till');
  step('pressing the group at the till adds Bread (1) and Milk (2) as lines of their own');

  await page.locator('#scan').fill('BF-1');
  await page.locator('#scan').press('Enter');
  await page.waitForFunction(() => document.querySelector('input[aria-label^="Quantity of Milk"]')?.value === '4');
  assert.strictEqual(await page.getByLabel(/^Quantity of Bread/).inputValue(), '2');
  step('scanning the group\'s own barcode adds the same again: Bread 2, Milk 4');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nQuick groups work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
