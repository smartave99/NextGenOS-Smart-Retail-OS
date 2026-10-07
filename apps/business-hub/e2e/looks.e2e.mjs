// The two looks (decision 30): a list look for a PC or laptop monitor (menu on top, items as a list you scroll down, the bill below) and a counter look for a touch screen
// (big buttons, menu on the left, items in the middle, bill on the right). The owner chooses one for the shop, or lets each screen decide; one computer can have its own.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('looks');
const step = (s) => console.log('✓ ' + s);
const attr = (page, name) => page.evaluate((n) => document.documentElement.getAttribute(n), name);
const hub = await startHub(['--E2E:White=none']);

/** Opens the sell screen with one item in the bill and says where things are. */
const sellLayout = async (page) => {
  await go(page, 'New sale');
  await page.locator('.items .item-btn').nth(1).waitFor();
  const [a, b] = [await page.locator('.items .item-btn').nth(0).boundingBox(), await page.locator('.items .item-btn').nth(1).boundingBox()];
  const items = await page.locator('.items').boundingBox();
  const cart = await page.locator('.cart').boundingBox();
  return { a, b, items, cart };
};

const chooseShop = async (page, id) => {
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Look' }).click();
  await page.locator('#look-card').waitFor();
  await page.locator('#look-' + id).click();
  await page.waitForURL(/tab=look&saved=1/);
  await page.locator('#look-card').waitFor();
};

try {
  const page = await newPage(browser, problems, { width: 1280, height: 800 });
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: true });
  await signIn(page, hub);

  // ---- nothing chosen yet: the layout the program always had ---------------------------------------------------------------------------
  assert.strictEqual(await attr(page, 'data-look'), 'standard');
  assert.strictEqual(await attr(page, 'data-nav'), 'left');
  step('with nothing chosen the layout is the one the program always had');

  // ---- the owner chooses the counter look for the shop ----------------------------------------------------------------------------------
  await chooseShop(page, 'counter');
  assert.strictEqual(await page.locator('#look-counter').getAttribute('aria-pressed'), 'true', 'the choice in force is shown');
  assert.strictEqual(await attr(page, 'data-look'), 'counter');
  assert.strictEqual(await attr(page, 'data-density'), 'touch');
  assert.strictEqual(await attr(page, 'data-nav'), 'left');
  assert.strictEqual(await attr(page, 'data-cart'), 'right');
  assert.strictEqual(await attr(page, 'data-scale'), '1.10');
  let l = await sellLayout(page);
  assert.ok(l.cart.x > l.items.x + l.items.width - 4, 'the bill is to the right of the items');
  assert.ok(Math.abs(l.a.y - l.b.y) < 4 && l.b.x > l.a.x, 'items sit side by side (tiles)');
  assert.ok(l.a.height >= 100, 'item buttons are big: ' + l.a.height);
  const side = await page.locator('.side').boundingBox();
  assert.ok(side.x < 2 && side.height > 500, 'the menu is down the left');
  await shot(page, '1-counter-sell');
  step('the counter look: big buttons, the menu on the left, the items in the middle and the bill on the right');

  // ---- and the list look ------------------------------------------------------------------------------------------------------------------
  await chooseShop(page, 'list');
  assert.strictEqual(await page.locator('#look-list').getAttribute('aria-pressed'), 'true');
  assert.strictEqual(await attr(page, 'data-look'), 'list');
  assert.strictEqual(await attr(page, 'data-density'), 'comfortable');
  assert.strictEqual(await attr(page, 'data-nav'), 'top');
  assert.strictEqual(await attr(page, 'data-cart'), 'bottom');
  const top = await page.locator('.side').boundingBox();
  assert.ok(top.y < 2 && top.height < 90 && top.width > 1000, 'the menu is along the top');
  l = await sellLayout(page);
  assert.ok(Math.abs(l.a.x - l.b.x) < 4 && l.b.y > l.a.y, 'items are a list, one under the other');
  assert.ok(l.a.width > 600, 'each row is wide, with its price at the end: ' + l.a.width);
  assert.ok(l.cart.y > l.items.y + l.items.height - 4, 'the bill is below the items');
  await page.locator('.items .item-btn').first().click();
  await page.locator('.line').first().waitFor();
  await shot(page, '2-list-sell');
  step('the list look: the menu along the top, the items as rows you scroll down, the bill below');

  // ---- "each screen decides": a monitor gets the list, a touch screen gets the counter ----------------------------------------------
  await chooseShop(page, 'auto');
  assert.strictEqual(await attr(page, 'data-look'), 'list', 'a monitor with a mouse gets the list look');
  const touch = await browser.newContext({ viewport: { width: 1280, height: 800 }, hasTouch: true, isMobile: true });
  const touchPage = await touch.newPage();
  touchPage.on('pageerror', (e) => problems.push('pageerror: ' + e.message));
  await signIn(touchPage, hub);
  assert.strictEqual(await attr(touchPage, 'data-look'), 'counter', 'a touch screen gets the counter look');
  assert.strictEqual(await attr(touchPage, 'data-density'), 'touch');
  await touch.close();
  step('"each screen decides": a monitor gets the list look and a touch screen gets the counter look');

  // ---- this computer's own look beats the shop's --------------------------------------------------------------------------------------
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Look' }).click();
  await page.locator('#here-counter').click();
  await page.waitForFunction(() => document.documentElement.getAttribute('data-look') === 'counter');
  assert.strictEqual(await page.evaluate(() => localStorage.getItem('hub-look')), 'counter');
  assert.strictEqual(await attr(page, 'data-look-shop'), 'auto', 'the shop\'s choice is not touched');
  await page.getByRole('tab', { name: 'Look' }).click();
  await page.locator('#here-shop').waitFor();
  await page.locator('#here-shop').click();
  await page.waitForFunction(() => document.documentElement.getAttribute('data-look') === 'list');
  assert.strictEqual(await page.evaluate(() => localStorage.getItem('hub-look')), null);
  step('one computer can have its own look, and "same as the shop" gives it back');

  // ---- "as it was" puts the old layout back ---------------------------------------------------------------------------------------------
  await chooseShop(page, 'standard');
  assert.strictEqual(await attr(page, 'data-look'), 'standard');
  assert.strictEqual(await attr(page, 'data-nav'), 'left');
  assert.strictEqual(await attr(page, 'data-density'), 'comfortable');
  step('"as it was" puts the standard layout back');

  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe Hub has a list look for a monitor and a counter look for a touch screen, chosen for the shop or for one computer.');
} catch (e) {
  console.error(e);
  console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  await hub.stop();
}
