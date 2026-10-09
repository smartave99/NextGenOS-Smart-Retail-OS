// Every screen in both looks (decision 30: "every screen works and looks right in both; none is usable in only one"): each screen of the menu, and the screens inside them, is opened in the list look
// on a laptop screen and in the counter look on a touch screen. On every one: it opens without an error, the page is not wider than the window, the menu is where the look puts it (along the top, or
// down the left), and in the counter look nothing a finger must press is smaller than 40 pixels. A new screen is added to the list here, and then it has to pass too.
import assert from 'node:assert';
import { build, startHub, launch, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('screenlooks');
const step = (s) => console.log('✓ ' + s);
const hub = await startHub(['--E2E:White=none']);

const SCREENS = ['/', '/sell', '/items', '/items/batches', '/items/changes', '/items/sheet', '/items/groups', '/posters', '/people', '/people/sheet', '/purchases', '/documents', '/staff', '/employees', '/reports',
  '/reports/more', '/books', '/registers', '/offers', '/settings', '/settings/keys', '/settings/network', '/settings/ai', '/settings/events', '/settings/map', '/help'];

/** What the page looks like to a person: how far it spills sideways, which pressable things are too small, and where the menu is. */
const measure = () => {
  const width = document.documentElement.clientWidth;
  const small = [];
  const pressable = 'button, a.btn, select, input:not([type=hidden]):not([type=checkbox]):not([type=radio]):not([type=file]), textarea, [role=tab], .side a, .chip-btn';
  for (const el of document.querySelectorAll(pressable)) {
    const r = el.getBoundingClientRect();
    if (r.width === 0 || r.height === 0) continue;
    const s = getComputedStyle(el);
    if (s.visibility === 'hidden' || s.display === 'none') continue;
    if (r.height < 40) small.push(`${el.tagName.toLowerCase()}${el.id ? '#' + el.id : ''} "${(el.innerText || el.value || el.getAttribute('aria-label') || '').trim().slice(0, 24)}" ${Math.round(r.width)}x${Math.round(r.height)}`);
  }
  const menu = document.querySelector('.side')?.getBoundingClientRect();
  const heading = document.querySelector('main#content h1')?.innerText ?? '';
  return { spill: document.documentElement.scrollWidth - width, small, menu: menu ? { x: Math.round(menu.x), y: Math.round(menu.y), w: Math.round(menu.width), h: Math.round(menu.height) } : null, heading };
};

const visitAll = async (page, look, routes, check) => {
  for (const route of routes) {
    await page.goto(hub.url + route);
    await page.locator('main#content').waitFor();
    await page.waitForTimeout(600);                                   // the screen is drawn in the browser a moment after it opens
    const m = await page.evaluate(measure);
    assert.ok(m.heading.length > 0 || route === '/sell', `${look}: ${route} has no heading`);
    assert.ok(m.spill <= 1, `${look}: ${route} is ${m.spill}px wider than the window`);
    assert.ok(m.menu, `${look}: ${route} has no menu`);
    check(route, m);
  }
};

try {
  // the list look on a laptop, the counter look on a touch screen
  const laptop = await browser.newContext({ viewport: { width: 1366, height: 768 } });
  const touch = await browser.newContext({ viewport: { width: 1280, height: 800 }, hasTouch: true });
  for (const context of [laptop, touch]) {
    const page = await context.newPage();
    page.on('console', (m) => { if (m.type() === 'error') problems.push('console: ' + m.text()); });
    page.on('pageerror', (e) => problems.push('pageerror: ' + e.message));
    if (context === laptop) await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: true });
    await signIn(page, hub);
    const look = context === laptop ? 'list' : 'counter';
    await go(page, 'Settings');
    await page.getByRole('tab', { name: 'Look' }).click();
    await page.locator('#look-card').waitFor();
    await page.locator('#look-' + look).click();
    await page.waitForURL(/tab=look&saved=1/);

    // every link of the menu is on the list (a new menu item that is not here fails the test)
    const links = (await page.locator('.side a[href]').evaluateAll((as) => as.map((a) => new URL(a.href).pathname))).filter((p, i, all) => all.indexOf(p) === i);
    for (const link of links) assert.ok(SCREENS.includes(link), `the menu has ${link}, which is not on the list of screens checked in both looks`);

    // a bill, as a receipt and as a full page
    await page.goto(hub.url + '/documents');
    await page.locator('main#content').waitFor();
    await page.waitForTimeout(600);
    const bill = await page.locator('a[href^="documents/"]').first().getAttribute('href');
    const extra = bill ? ['/' + bill, '/' + bill + '?layout=a4'] : [];

    if (look === 'list') {
      await visitAll(page, look, [...SCREENS, ...extra], (route, m) => assert.ok(m.menu.y < 2 && m.menu.w > 1000 && m.menu.h < 90, `list: the menu is along the top on ${route}: ${JSON.stringify(m.menu)}`));
      await shot(page, '1-list-reports');
      step(`the list look on a laptop: ${SCREENS.length + extra.length} screens open with no error, none is wider than the window, the menu is along the top on each`);
    } else {
      await visitAll(page, look, [...SCREENS, ...extra], (route, m) => {
        assert.ok(m.menu.x < 2 && m.menu.h > 500, `counter: the menu is down the left on ${route}: ${JSON.stringify(m.menu)}`);
        assert.deepStrictEqual(m.small, [], `counter: on ${route} these are smaller than a finger needs (40 pixels): ${m.small.join('; ')}`);
      });
      await shot(page, '2-counter-reports');
      step(`the counter look on a touch screen: ${SCREENS.length + extra.length} screens open with no error, none is wider than the window, the menu is down the left, nothing pressable is under 40 pixels`);
    }
  }
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nEvery screen works in both looks.');
} catch (e) {
  console.error(e);
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  await hub.stop();
}
