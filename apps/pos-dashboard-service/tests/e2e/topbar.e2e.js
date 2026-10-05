// End-to-end check of the app window's own top bar, as the page draws it, in Chromium. Inside the Windows app the
// page is told (window.srposFrame) that the bar stands in for the Windows title bar; here a stand-in for WebView2
// records what the page sends to the app. The bar: shown only then, a drag region with its controls outside it;
// the page says when it is on screen; the window buttons; the bell with what needs the owner; search and Ctrl+K;
// Get started's short bar; a narrower window. Dragging the real window is checked on Windows by the smoke test.
// It starts the app itself on demo data:
//   npm install && npm run test:topbar        (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-topbar-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli' }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile },
    stdio: 'ignore',
    detached: process.platform !== 'win32',
  });
  for (let i = 0; i < 180; i++) {
    try { if ((await fetch(BASE + '/')).ok) return app; } catch { /* not up yet */ }
    await new Promise(r => setTimeout(r, 1000));
  }
  throw new Error('The app did not start on ' + BASE);
}

/** Focus in a search box: the box draws one thin ring and the input inside draws none (both together made a thick glow). */
async function oneCalmRing(page, box, input) {
  await page.locator(input).focus();
  await page.waitForFunction(b => document.querySelector(b).getAnimations().length === 0, box);
  const ring = await page.evaluate(([b, i]) => ({
    box: getComputedStyle(document.querySelector(b)).boxShadow,
    input: getComputedStyle(document.querySelector(i)).boxShadow,
  }), [box, input]);
  assert.strictEqual(ring.input, 'none', 'the input draws no ring of its own');
  assert.match(ring.box, /^rgb\(\d+, \d+, \d+\) 0px 0px 0px 1\.5px$/, 'the box draws one thin ring: ' + ring.box);
  await page.locator(input).blur();
}

function stopApp(app) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid); } catch { /* gone */ }
}

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  const watch = (page) => {
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));
  };
  try {
    // A normal browser: no top bar, the sidebar as always.
    const plain = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    watch(plain);
    await plain.goto(BASE + '/', { waitUntil: 'networkidle' });
    await plain.locator('.sidebar .brand').waitFor();
    assert.strictEqual(await plain.locator('.window-bar').isVisible(), false);
    assert.ok(await plain.locator('#side-search').isVisible());
    assert.strictEqual(await plain.evaluate(() => document.querySelector('.sidebar').getBoundingClientRect().top), 0);
    assert.ok(await plain.getByRole('button', { name: 'Search products with the camera' }).isVisible(), 'the search box has the camera button');
    await oneCalmRing(plain, '.side-search', '#side-search');
    await plain.close();
    step('in a browser there is no top bar: the sidebar keeps the name and the search, with its camera and one calm focus ring');

    // Inside the app: the page is told before its scripts run, and what it sends is recorded.
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 } });
    await context.addInitScript(() => {
      window.srposFrame = 'app';
      window.__sent = [];
      window.chrome = { webview: { postMessage: (m) => window.__sent.push(JSON.parse(m)), addEventListener() {} } };
    });
    const page = await context.newPage();
    watch(page);
    const sent = () => page.evaluate(() => window.__sent);
    await page.goto(BASE + '/', { waitUntil: 'networkidle' });
    const bar = page.locator('.window-bar');
    await bar.waitFor();
    await page.waitForFunction(() => window.__sent.some(m => m.type === 'frame' && m.value === 'ready'));
    const look = await page.evaluate(() => {
      const region = (el) => { const s = getComputedStyle(el); return s.webkitAppRegion || s.appRegion; };
      const b = document.querySelector('.window-bar');
      return {
        height: b.getBoundingClientRect().height,
        bar: region(b),
        controls: [...b.querySelectorAll('a, button, input')].map(region).filter(r => r !== 'no-drag').length,
        sidebarTop: document.querySelector('.sidebar').getBoundingClientRect().top,
        sidebarBrand: getComputedStyle(document.querySelector('.sidebar .brand')).display,
        sidebarSearch: getComputedStyle(document.querySelector('.side-search')).display,
      };
    });
    assert.deepStrictEqual(look, { height: 40, bar: 'drag', controls: 0, sidebarTop: 40, sidebarBrand: 'none', sidebarSearch: 'none' });
    assert.strictEqual((await bar.locator('.wb-chip').first().innerText()).trim(), 'Demo data');
    await page.screenshot({ path: `${OUT}/top-bar.png` });
    step('in the app the top bar shows, drags the window with its controls left out, and tells the app it is there');

    // The top bar's search box has the camera button, and focus in it is one calm ring.
    await bar.getByRole('button', { name: 'Search products with the camera' }).waitFor();
    await oneCalmRing(page, '.wb-search', '#top-search');
    await page.locator('#top-search').focus();
    await bar.screenshot({ path: `${OUT}/top-bar-search-focus.png` });
    await page.locator('#top-search').blur();
    step('the top bar\'s search box has the camera button, and its focus is one calm ring, not a thick glow');

    // The window buttons, and the maximise button's look when the app says it is maximised.
    await page.evaluate(() => { window.__sent = []; });
    for (const name of ['Minimise', 'Maximise or restore', 'Close']) await bar.getByRole('button', { name }).click();
    assert.deepStrictEqual((await sent()).filter(m => m.type === 'window').map(m => m.value), ['minimize', 'maximize', 'close']);
    assert.ok(await bar.locator('.wb-max').isVisible());
    await page.evaluate(() => srpos.windowState('maximized'));
    assert.ok(await bar.locator('.wb-restore').isVisible());
    assert.strictEqual(await bar.locator('.wb-max').isVisible(), false);
    await page.evaluate(() => srpos.windowState('normal'));
    step('the window buttons ask the app to minimise, maximise and close; maximised, the button shows restore');

    // The bell: what needs the owner, from the demo's planted mistakes.
    const bell = bar.locator('.wb-bell-button');
    assert.strictEqual((await bell.locator('.wb-badge').innerText()).trim(), '3');
    await bell.click();
    const pop = bar.locator('.wb-pop');
    await pop.getByText('3 mistakes to fix now').waitFor();
    await page.screenshot({ path: `${OUT}/top-bar-bell.png` });
    await page.keyboard.press('Escape');
    await page.mouse.click(700, 600);
    await pop.waitFor({ state: 'detached' });
    await bell.click();
    await pop.getByRole('link', { name: /3 mistakes to fix now/ }).click();
    await page.waitForURL('**/fix-now');
    await pop.waitFor({ state: 'detached' });
    // After a page opens, Blazor puts the focus on its heading.
    await page.waitForFunction(() => document.activeElement && document.activeElement.tagName === 'H1');
    step('the bell counts what needs the owner, lists it, closes on a click outside, and opens Fix now');

    // Search, and Ctrl+K to it.
    await page.keyboard.press('Control+k');
    assert.strictEqual(await page.evaluate(() => document.activeElement && document.activeElement.id), 'top-search');
    await page.keyboard.type('sugar');
    await page.keyboard.press('Enter');
    await page.waitForURL('**/products?q=sugar');
    step('Ctrl+K goes to the top bar\'s search, which finds products');

    // Printed from the app: the bar is left out, so a sheet of stickers stays one page, as in a browser.
    await page.goto(BASE + '/barcodes?products=1', { waitUntil: 'networkidle' });
    await page.locator('.label-page .sticker').first().waitFor();
    assert.strictEqual(await page.locator('.label-page').count(), 1);
    const pdf = (await page.pdf({ preferCSSPageSize: true, printBackground: true })).toString('latin1');
    assert.strictEqual((pdf.match(/\/Type\s*\/Page(?!s)/g) || []).length, 1, 'one sticker sheet prints as one page');
    await page.emulateMedia({ media: 'print' });
    assert.strictEqual(await page.evaluate(() => getComputedStyle(document.querySelector('.window-bar')).display), 'none');
    await page.emulateMedia({ media: 'screen' });
    step('printing leaves the top bar out: a sheet of stickers is still one page');

    // A long page scrolled well past a screen, as a long chat is: the bar stays at the top.
    await page.goto(BASE + '/sales', { waitUntil: 'networkidle' });
    await bar.waitFor();
    const screens = await page.evaluate(() => document.documentElement.scrollHeight / window.innerHeight);
    assert.ok(screens > 2, `the page is not long enough to test (${screens} screens)`);
    await page.evaluate(() => window.scrollTo(0, document.documentElement.scrollHeight));
    await page.waitForFunction(() => window.scrollY > window.innerHeight);
    assert.deepStrictEqual(await page.evaluate(() => ({
      bar: document.querySelector('.window-bar').getBoundingClientRect().top,
      sidebar: document.querySelector('.sidebar').getBoundingClientRect().top,
    })), { bar: 0, sidebar: 40 });
    step('scrolled far down a long page, the top bar and the sidebar stay in place');

    // Get started: just the name and the window buttons.
    await page.goto(BASE + '/welcome', { waitUntil: 'networkidle' });
    await bar.waitFor();
    assert.strictEqual(await bar.locator('.wb-search').count(), 0);
    assert.strictEqual(await bar.getByRole('button', { name: 'Close' }).count(), 1);
    step('Get started has the top bar with just the name and the window buttons');

    // A narrower window: the chips drop their words, nothing scrolls sideways.
    await page.setViewportSize({ width: 900, height: 700 });
    await page.goto(BASE + '/', { waitUntil: 'networkidle' });
    await bar.waitFor();
    assert.strictEqual(await bar.locator('.wb-label').first().isVisible(), false);
    const overflow = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
    assert.ok(overflow <= 0, `no sideways scrolling (${overflow}px)`);
    await page.screenshot({ path: `${OUT}/top-bar-narrow.png` });
    step('a narrower window: the chips keep only their icons, nothing scrolls sideways');

    assert.deepStrictEqual(errors, [], 'no console errors');
    console.log('No console errors or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
  }
})().catch(e => {
  console.error(e);
  process.exit(1);
});
