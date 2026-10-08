// Loyalty points: the owner turns them on and says what a point is worth; a named customer earns points on a bill, uses them on a later bill as money off, and sees them on the bill and
// on the account. More points than the balance are refused.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('loyalty');
const step = (s) => console.log('✓ ' + s);
const money = (text) => Number(text.replace(/[^\d.]/g, ''));
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail' });
  await signIn(page, hub);

  // nothing about points anywhere until the owner turns them on
  await go(page, 'New sale');
  await page.locator('.items .item-btn').first().click();
  await page.locator('.line').first().waitFor();
  assert.strictEqual(await page.locator('#loyalty-row').count(), 0);
  await page.getByRole('button', { name: 'Cancel' }).click();

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Loyalty points' }).click();
  await page.locator('#loy-on').check();
  await page.locator('#loy-mode').selectOption('per');
  await page.locator('#loy-value').fill('5');
  await page.locator('#loy-worth').fill('0.50');
  await page.locator('#save-loyalty').click();
  await page.getByText('Saved.').first().waitFor();
  step('the owner turns on loyalty points: 5% of what a customer pays, each point worth 0.50');

  await go(page, 'People');
  await page.locator('#add-person').click();
  await page.locator('#p-name').fill('Points Test');
  await page.getByRole('button', { name: 'Save' }).click();
  await page.getByText('Points Test').first().waitFor();

  const startSale = async () => {
    await go(page, 'New sale');
    await page.locator('#scan').waitFor();
    await page.locator('.items .item-btn').first().click();
    await page.locator('.line').first().waitFor();
    await page.getByPlaceholder(/Search by name or phone/).fill('Points Test');
    await page.locator('.chips button', { hasText: 'Points Test' }).click();
    await page.locator('#loyalty-row').waitFor();
  };

  await startSale();
  assert.strictEqual(money(await page.locator('#points').innerText()), 0);
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const first = await page.locator('.receipt').innerText();
  assert.match(first, /Points earned/);
  const earned = money(first.match(/Points earned\s*([\d.]+)/)[1]);
  assert.ok(earned > 0, 'the first bill earned points: ' + earned);
  assert.match(first, /Points now/);
  step('a named customer earns points on a bill, and the bill says so (' + earned + ' points)');

  await startSale();
  assert.strictEqual(money(await page.locator('#points').innerText()), earned, 'the till shows the balance');
  const before = money(await page.locator('#total').innerText());
  await page.locator('#use-points').fill('2');
  await page.locator('#use-points').press('Tab');
  await page.locator('#discount-given').waitFor();
  const after = money(await page.locator('#total').innerText());
  assert.ok(after < before, `using 2 points (worth 1.00 before tax) lowers the total: ${before} to ${after}`);
  await page.locator('#use-points').fill(String(earned + 100));
  await page.locator('#use-points').press('Tab');
  await page.locator('.notice.error', { hasText: /has only/ }).waitFor();
  step('points used come off the bill; more points than the customer has are refused in plain words');

  await page.locator('#use-points').fill('2');
  await page.locator('#use-points').press('Tab');
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const second = await page.locator('.receipt').innerText();
  assert.match(second, /Points used\s*2/);
  assert.match(second, /Points earned/);
  step('the second bill shows the points used and the points earned');

  await page.getByRole('link', { name: 'Points Test' }).click();
  await page.waitForURL(/\/account\/\d+/);
  await page.locator('#points-card').waitFor();
  const rows = await page.locator('#points-statement tbody tr').count();
  assert.ok(rows >= 3, 'the account lists earned, used and earned again: ' + rows);
  await shot(page, '1-points-account');
  step('the customer\'s account lists the points, line by line');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nLoyalty points work: earned on a bill, used on the next, shown on the bill and the account.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  await hub.stop();
}
