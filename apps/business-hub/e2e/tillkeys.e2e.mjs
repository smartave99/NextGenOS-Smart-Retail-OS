// The keys of the sell screen in the browser (the older POS's shortcut keys, merge, study 04 D): the screen shows the keys in force, a key goes to the box it names, the shop chooses its own keys
// (a key used twice is refused in plain words), and the chosen key completes a sale.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('tillkeys');
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

  await go(page, 'New sale');
  await page.locator('#till-keys').waitFor();
  assert.match(await page.locator('#till-keys').innerText(), /F2 scan · F4 customer · F8 amount · F12 complete/);
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  await page.locator('#customer-search').focus();
  await page.keyboard.press('F2');
  await page.waitForFunction(() => document.activeElement && document.activeElement.id === 'scan');
  await page.keyboard.press('F4');
  await page.waitForFunction(() => document.activeElement && document.activeElement.id === 'customer-search');
  step('the screen shows the keys in force, and F2 and F4 go to the scan box and the customer box');

  await go(page, 'Settings');
  await page.locator('#till-keys-link').click();
  await page.locator('#key-complete').fill('F2');
  await page.locator('#key-complete').press('Tab');
  await page.locator('#keys-save').click();
  await page.getByText(/more than one thing/).first().waitFor();
  await page.locator('#key-complete').fill('alt+s');
  await page.locator('#key-complete').press('Tab');
  await page.locator('#keys-save').click();
  await page.getByText('Saved.').first().waitFor();
  assert.strictEqual(await page.locator('#key-complete').inputValue(), 'Alt+S');
  step('a key used for two things is refused; Alt+S is chosen for "complete the sale"');

  await go(page, 'New sale');
  await page.locator('#till-keys').waitFor();
  assert.match(await page.locator('#till-keys').innerText(), /Alt\+S complete/);
  assert.doesNotMatch(await page.locator('#till-keys').innerText(), /F12/);
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  await shot(page, '1-till');
  await page.keyboard.press('Alt+S');
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  step('the chosen key completes the sale: the bill is made');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe keys of the till work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
