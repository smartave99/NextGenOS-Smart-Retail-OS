// End-to-end check of the Start with Windows switch on the Settings page, in Chromium. Only the Windows app can change the sign-in
// entry, so the page asks it by a message (srpos.send('startup', 'on' | 'off')); this test plays the app with a stand-in that
// keeps the messages. The entry itself (the registry, the setup's tick) is Windows: the unit tests check the rule, and the
// setup's own check under Wine (SmartRetailAI/installer/test-update.sh) checks that a new install ticks it. It starts the
// dashboard itself on demo data:
//   npm install && npm run test:startup          (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-startup-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({}));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile },
    stdio: 'ignore',
    detached: process.platform !== 'win32',
  });
  let last = 'no answer';
  for (let i = 0; i < 180; i++) {
    try {
      const answer = await fetch(BASE + '/');
      if (answer.ok) return app;
      last = answer.status + ' ' + (await answer.text()).replace(/\s+/g, ' ').slice(0, 160);
    } catch { /* not up yet */ }
    await new Promise(r => setTimeout(r, 1000));
  }
  stopApp(app); // never leave it running, holding the port for the next try
  throw new Error('The app did not start on ' + BASE + ' (last answer: ' + last + '). A 402 means the licence gate is closed: run the test through with-licence.mjs.');
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
    // ---- In a plain browser only the Windows app can change it: the row is not there.
    const plain = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    watch(plain);
    await plain.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await plain.locator('.setting-group', { hasText: 'Updates' }).waitFor();
    assert.strictEqual(await plain.locator('#start-with-windows').isVisible(), false, 'a browser cannot change it: the row is hidden');
    step('in a browser the switch is not offered');

    // ---- Inside the app's window: the switch, and the messages it sends.
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 } });
    await context.addInitScript(() => {
      window.srposFrame = 'app';
      window.__sent = [];
      window.chrome = { webview: { postMessage: (m) => window.__sent.push(JSON.parse(m)), addEventListener() {} } };
    });
    const page = await context.newPage();
    watch(page);
    const row = page.locator('#start-with-windows');
    const sent = () => page.evaluate(() => window.__sent.filter(m => m.type === 'startup'));
    await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
    await row.waitFor();
    assert.ok((await row.innerText()).includes('Start with Windows'), await row.innerText());
    assert.ok((await row.innerText()).includes('Off. Open Smart Retail POS from the Start menu when you need it.'), 'off until turned on');
    assert.strictEqual(await row.getByRole('radio', { name: 'Off' }).getAttribute('aria-checked'), 'true');
    assert.deepStrictEqual(await sent(), [], 'nothing is sent by looking');
    step('the switch shows what it is, and starts off when nothing has turned it on');

    await row.getByRole('radio', { name: 'On' }).click();
    await page.waitForFunction(() => document.querySelector('#start-with-windows').innerText.includes('On. Smart Retail POS starts by itself when you sign in to Windows'));
    assert.deepStrictEqual((await sent()).map(m => m.value), ['on']);
    assert.strictEqual(await row.getByRole('radio', { name: 'On' }).getAttribute('aria-checked'), 'true');
    step('turning it on asks the app, and says what it means');

    await row.getByRole('radio', { name: 'Off' }).click();
    await page.waitForFunction(() => document.querySelector('#start-with-windows').innerText.includes('Off. Open Smart Retail POS'));
    assert.deepStrictEqual((await sent()).map(m => m.value), ['on', 'off']);
    await row.screenshot({ path: path.join(OUT, 'start-with-windows.png') });
    step('turning it off asks the app again');

    // ---- The app window's narrowest size (760 px): no sideways scrolling.
    await page.setViewportSize({ width: 760, height: 800 });
    await row.scrollIntoViewIfNeeded();
    assert.ok(await page.evaluate(() => document.documentElement.scrollWidth <= window.innerWidth + 1), 'no sideways scrolling in the narrowest app window');
    step('the narrowest app window: no sideways scrolling');

    assert.deepStrictEqual(errors, [], 'no console or page errors: ' + errors.join(' | '));
    console.log('No console or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
  }
})().catch(e => { console.error(e); process.exit(1); });
