// The two things a country's tax may ask for besides the rate: a code for what is sold and an extra tax set per item. Where the country's pack names them (India: an HSN or SAC code and cess) the item
// screen has both fields, the bill prints the code under the line and the extra tax under the country's word for it; where it does not (the Philippines) there is no such field and no such word.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('taxinputs');
const step = (s) => console.log('✓ ' + s);
let hub;
try {
  // ---- India ------------------------------------------------------------------------------------------------------------------------------
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);
  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Soft drink');
  await page.locator('#f-price').fill('1400');
  await page.locator('#f-bar').fill('8900000000011');
  assert.match(await page.locator('label[for="f-code"]').innerText(), /HSN or SAC code/);
  assert.match(await page.locator('label[for="f-extra"]').innerText(), /Cess/);
  await page.locator('#f-code').fill('2202');
  await page.locator('#f-extra').fill('12');
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();
  step('in India the item screen asks for an HSN or SAC code and a cess percent');

  await go(page, 'New sale');
  await page.locator('#scan').fill('8900000000011');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /HSN or SAC code: 2202/);
  assert.match(receipt, /Cess/);
  await shot(page, '1-india-bill');
  step('the bill prints the code under the line and the cess under its own word');

  // the same item, edited: the fields carry what was typed
  await go(page, 'Products');
  await page.getByRole('button', { name: 'Edit' }).first().click();
  assert.strictEqual(await page.locator('#f-code').inputValue(), '2202');
  assert.strictEqual(await page.locator('#f-extra').inputValue(), '12');
  await page.locator('#f-extra').fill('twelve');
  await page.locator('#save-item').click();
  await page.locator('.notice.error', { hasText: /as a percent/ }).waitFor();
  step('a cess that is not a percent is refused in plain words');
  await page.close();
  await hub.stop();

  // ---- the Philippines: neither field -----------------------------------------------------------------------------------------------------
  hub = await startHub();
  const ph = await newPage(browser, problems);
  await setUp(ph, hub, { name: 'Manila Mart', country: 'Philippines', industry: 'retail', demo: false });
  await signIn(ph, hub);
  await go(ph, 'Products');
  await ph.locator('#add-item').click();
  await ph.locator('#f-name').waitFor();
  assert.strictEqual(await ph.locator('#f-code').count(), 0);
  assert.strictEqual(await ph.locator('#f-extra').count(), 0);
  assert.doesNotMatch(await ph.locator('.sheet').innerText(), /HSN|Cess/i);
  step('in the Philippines the item screen has neither field, and says nothing about them');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe item code and the extra tax follow the country: shown, kept and printed where the pack has them, absent where it does not.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
