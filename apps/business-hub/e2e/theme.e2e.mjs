// How the Hub looks and is laid out: set by the customer's profile and by the owner, as far as the licence allows. A touch-screen counter gets big buttons and a menu along
// the bottom; a brand's own shape and letters show only when its licence allows them; a damaged profile changes nothing.
import assert from 'node:assert';
import { mkdtempSync, mkdirSync, writeFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('theme');
const step = (s) => console.log('✓ ' + s);
const work = mkdtempSync(join(tmpdir(), 'hub-theme-'));
const makeProfile = (name, files) => { const dir = join(work, name); mkdirSync(dir, { recursive: true }); for (const [f, c] of Object.entries(files)) writeFileSync(join(dir, f), typeof c === 'string' ? c : JSON.stringify(c)); return dir; };

const attr = (page, name) => page.evaluate((n) => document.documentElement.getAttribute(n), name);
const css = (page, selector, prop) => page.locator(selector).first().evaluate((el, p) => getComputedStyle(el)[p], prop);
let hub;
const run = async (args, body) => {
  hub = await startHub(args);
  try {
    const page = await newPage(browser, problems, { width: 1280, height: 800 });
    await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: true });
    await signIn(page, hub);
    await body(page);
    await page.context().close();
    assert.deepStrictEqual(problems, [], 'the browser saw problems');
  } finally { await hub.stop(); }
};

try {
  const touch = makeProfile('touch', { 'theme.json': { density: 'touch', nav: 'bottom', cart: 'bottom', fontScale: 1.1, shape: 'pill', font: 'serif', surface: 'warm', depth: 'lifted' } });

  // ---- a fixed look: the screen choices apply, the style does not ---------------------------------------------------------------------
  await run(['--E2E:White=none', '--E2E:Brand=Luzon Fresh', `--Hub:ProfileFolder=${touch}`], async (page) => {
    assert.strictEqual(await attr(page, 'data-density'), 'touch');
    assert.strictEqual(await attr(page, 'data-nav'), 'bottom');
    assert.strictEqual(await attr(page, 'data-shape'), 'rounded', 'a fixed look keeps its shape');
    assert.strictEqual(await attr(page, 'data-font'), 'system');
    assert.strictEqual(await attr(page, 'data-surface'), 'neutral');
    const side = await page.locator('.side').boundingBox();
    const viewport = page.viewportSize();
    assert.ok(Math.abs(side.y + side.height - viewport.height) < 2, 'the menu is along the bottom');
    assert.ok(side.width >= viewport.width - 2, 'the menu spans the screen');
    const tap = await page.locator('.btn').first().boundingBox();
    assert.ok(tap.height >= 44, 'even the small buttons are big enough for a finger: ' + tap.height);
    await page.locator('.top-brand').waitFor();
    assert.match(await page.locator('.top-brand').innerText(), /Luzon Fresh/);
    assert.match(await page.locator('.top-brand').innerText(), /by NextGenOS/);
    assert.ok(await page.locator('.side .brand').evaluate((el) => getComputedStyle(el).display === 'none'), 'the name moves to the top bar');
    await shot(page, '1-touch-today');
    await go(page, 'New sale');
    await page.locator('.items .item-btn').first().waitFor();
    const item = await page.locator('.items .item-btn').first().boundingBox();
    assert.ok(item.height >= 118, 'item buttons are big: ' + item.height);
    await page.locator('.items .item-btn').first().click();
    await page.locator('.line').first().waitFor();
    const cart = await page.locator('.cart').boundingBox();
    const items = await page.locator('.items').boundingBox();
    assert.ok(cart.y > items.y + items.height - 4, 'the cart is below the items');
    const complete = await page.locator('#complete').boundingBox();
    assert.ok(complete.height >= 54, 'the Complete button is big: ' + complete.height);
    await shot(page, '2-touch-sell');
    step('a fixed look takes the touch layout (big buttons, menu along the bottom, cart below) but keeps its own shape, letters and tint; the name stays in sight');
  });

  // ---- a style licence: the profile's style shows ---------------------------------------------------------------------------------------
  await run(['--E2E:White=theme', '--E2E:Brand=Luzon Fresh', `--Hub:ProfileFolder=${touch}`], async (page) => {
    assert.strictEqual(await attr(page, 'data-shape'), 'pill');
    assert.strictEqual(await attr(page, 'data-font'), 'serif');
    assert.strictEqual(await attr(page, 'data-surface'), 'warm');
    assert.strictEqual(await attr(page, 'data-depth'), 'lifted');
    assert.ok(parseFloat(await css(page, '.btn', 'borderTopLeftRadius')) > 100, 'buttons are pills');
    assert.match(await css(page, 'body', 'fontFamily'), /Georgia|Palatino|Iowan|Serif/i);
    assert.strictEqual(await css(page, 'html', 'fontSize'), '17.6px', 'letters are 110%');
    assert.strictEqual((await css(page, 'body', 'backgroundColor')).replace(/\s/g, ''), 'rgb(247,243,238)', 'the warm tint');
    await shot(page, '3-style-today');
    step('a style licence shows the profile\'s shape, letters, tint, shadows and letter size');

    // the owner changes the layout on this PC
    await go(page, 'Settings');
    await page.getByRole('tab', { name: 'Look' }).click();
    await page.locator('#layout-card').waitFor();
    assert.strictEqual(await page.locator('#t-density').inputValue(), 'touch', 'the form shows what is in force');
    await page.locator('#t-density').selectOption('compact');
    await page.locator('#t-nav').selectOption('top');
    await page.locator('#t-cart').selectOption('left');
    await page.locator('#t-labels').selectOption('icons');
    await page.locator('#t-scale').selectOption('100');
    await page.locator('#t-shape').selectOption('square');
    await page.locator('#save-theme').click();
    await page.waitForURL(/tab=look&saved=1/);
    assert.strictEqual(await attr(page, 'data-density'), 'compact');
    assert.strictEqual(await attr(page, 'data-nav'), 'top');
    assert.strictEqual(await attr(page, 'data-shape'), 'square');
    assert.strictEqual(await attr(page, 'data-font'), 'serif', 'what was not changed stays as the profile set it');
    const nav = await page.locator('.side').boundingBox();
    assert.ok(nav.y < 2 && nav.height < 90 && nav.width > 1000, 'the menu is along the top');
    assert.strictEqual(await page.locator('.side a').first().getAttribute('title'), 'Today', 'a hint for picture-only menus');
    await page.getByRole('link', { name: 'New sale' }).click();
    await page.locator('.cart').waitFor();
    const cart = await page.locator('.cart').boundingBox();
    const items = await page.locator('.items').boundingBox();
    assert.ok(cart.x < items.x, 'the cart is on the left');
    await shot(page, '4-owner-top-compact');
    step('the owner changes the menu, the cart, the size and the corners on this PC, and the rest stays as the profile set it');

    await go(page, 'Settings');
    await page.getByRole('tab', { name: 'Look' }).click();
    await page.locator('#reset-theme').click();
    await page.waitForURL(/tab=look&saved=1/);
    assert.strictEqual(await attr(page, 'data-density'), 'touch', 'going back gives the profile\'s layout back');
    assert.strictEqual(await attr(page, 'data-nav'), 'bottom');
    step('going back to the standard layout gives the profile\'s layout back');
  });

  // ---- the owner on a fixed look may change the screen but not the style ---------------------------------------------------------------
  await run(['--E2E:White=none', '--E2E:Brand=Luzon Fresh'], async (page) => {
    await go(page, 'Settings');
    await page.getByRole('tab', { name: 'Look' }).click();
    await page.locator('#layout-card').waitFor();
    assert.strictEqual(await page.locator('#t-shape').count(), 0, 'no style choices with a fixed look');
    assert.match(await page.locator('#layout-card').innerText(), /fixed style/);
    await page.locator('#t-density').selectOption('touch');
    await page.locator('#t-nav').selectOption('bottom');
    await page.locator('#save-theme').click();
    await page.waitForURL(/tab=look&saved=1/);
    assert.strictEqual(await attr(page, 'data-nav'), 'bottom');
    assert.strictEqual(await attr(page, 'data-shape'), 'rounded');
    step('with a fixed look the owner can still set up a touch screen, and sees no style choices');
  });

  // ---- a damaged profile changes nothing and breaks nothing --------------------------------------------------------------------------
  const broken = makeProfile('broken', { 'theme.json': '{ this is not json', 'brand.json': '[1,2,3]' });
  await run(['--E2E:White=full', `--Hub:ProfileFolder=${broken}`], async (page) => {
    assert.strictEqual(await attr(page, 'data-density'), 'comfortable');
    assert.strictEqual(await attr(page, 'data-nav'), 'left');
    assert.match(await page.locator('main h1').innerText(), /Today/);
    step('a damaged profile file changes nothing and breaks nothing');
  });

  // ---- a dark profile follows until the person chooses -------------------------------------------------------------------------------
  const dark = makeProfile('dark', { 'theme.json': { mode: 'dark' } });
  await run(['--E2E:White=theme', `--Hub:ProfileFolder=${dark}`], async (page) => {
    assert.strictEqual(await page.evaluate(() => document.documentElement.getAttribute('data-theme')), 'dark');
    assert.strictEqual((await css(page, 'body', 'backgroundColor')).replace(/\s/g, ''), 'rgb(0,0,0)');
    await page.getByRole('button', { name: 'Switch between light and dark' }).filter({ hasText: 'Light' }).waitFor();
    await page.getByRole('button', { name: 'Switch between light and dark' }).click();
    await page.waitForFunction(() => document.documentElement.getAttribute('data-theme') === 'light');
    step('a profile can start the business in dark mode, and the person can still switch');
  });
  console.log('\nThe Hub looks and is laid out as set, as far as the licence allows.');
} catch (e) {
  console.error(e);
  process.exitCode = 1;
} finally {
  await browser.close();
  rmSync(work, { recursive: true, force: true });
}
