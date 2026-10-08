// A quote for a shop sale: it shows the tax, nothing is sold, and the bill made from it comes to the same; a quote is made into a bill once.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('estimates');
const step = (s) => console.log('✓ ' + s);
const money = (text) => Number(text.replace(/[^\d.]/g, ''));
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail' });
  await signIn(page, hub);

  await go(page, 'New sale');
  await page.locator('.items .item-btn').first().click();
  await page.locator('.line').first().waitFor();
  await page.locator('.items .item-btn').first().click();     // two of it
  await page.waitForFunction(() => document.querySelector('.line .qty')?.value === '2');
  const total = money(await page.locator('#total').innerText());
  await page.locator('#save-estimate').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const quoteUrl = page.url().split('?')[0];
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /Quote/);
  assert.match(receipt, /CGST/);
  assert.strictEqual(money(await page.locator('.receipt .r.b span').last().innerText()), total, 'the quote comes to the total on the till, tax included');
  await shot(page, '1-quote');
  step('a sale kept as a quote shows the tax and the same total');

  await page.locator('#make-bill').click();
  await page.waitForURL(/\/sell\?estimate=\d+/);
  await page.locator('.line').first().waitFor();
  assert.strictEqual(money(await page.locator('#total').innerText()), total, 'the bill comes to the same');
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  assert.match(await page.locator('.receipt').innerText(), /Tax Invoice/);
  step('a bill made from the quote comes to the same, and is paid like any bill');

  await page.goto(quoteUrl);
  await page.locator('.chip', { hasText: /Made into bill/ }).waitFor();
  assert.strictEqual(await page.locator('#make-bill').count(), 0, 'a quote is made into a bill once');
  step('the quote says which bill it became, and cannot be billed again');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nQuotes for a shop sale work: tax shown, nothing sold, one bill from each.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  await hub.stop();
}
