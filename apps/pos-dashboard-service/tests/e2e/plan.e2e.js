// End-to-end check of the sales dashboard and the AI plan to grow sales, in Chromium.
// It starts the app itself on demo data, with stand-in-ai.js in place of a real AI tool, then stops it:
//   npm install && npm run test:plan          (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

// The side panel's settings file, as the app will read it: the stand-in as a "custom CLI" provider.
const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-plan-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({
  PreferredProvider: 'custom-cli',
  FallbackToOtherProviders: false,
  CustomCli: {
    DisplayName: 'Stand-in AI',
    ExecutablePath: process.execPath,
    Arguments: `"${path.join(__dirname, 'stand-in-ai.js')}" {prompt_file}`,
    PromptViaStdin: false,
    TimeoutSeconds: 60,
  },
}, null, 2));
// The data folder (plans, photos), as the Storage page would set it.
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile,
    },
    stdio: 'ignore',
    detached: process.platform !== 'win32',
  });
  for (let i = 0; i < 180; i++) {
    try { if ((await fetch(BASE + '/')).ok) return app; } catch { /* not up yet */ }
    await new Promise(r => setTimeout(r, 1000));
  }
  throw new Error('The app did not start on ' + BASE);
}

function stopApp(app) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid); } catch { /* gone */ }
}

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 768 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    await page.goto(BASE + '/sales', { waitUntil: 'networkidle' });
    await page.locator('.kpis .kpi').first().waitFor();
    assert.strictEqual(await page.locator('.kpis .kpi').count(), 5);
    assert.ok(await page.locator('svg.chart .c-bar').count() >= 30, 'daily bars');
    assert.ok(await page.locator('svg.chart .c-line').count() === 1, '7-day average line');
    await page.screenshot({ path: `${OUT}/sales.png` });
    step('sales: five figures, a bar for every day and the 7-day average');

    await page.goto(BASE + '/plan', { waitUntil: 'networkidle' });
    await page.locator('.pill.good').waitFor({ timeout: 60000 });
    assert.ok((await page.locator('.panel').nth(1).innerText()).includes('Stand-in AI'));
    step('the AI tool from the side panel settings is ready');

    const brief = await page.locator('details.brief pre').textContent(); // collapsed, so innerText is empty
    assert.ok(brief.includes('TOP PRODUCTS') && brief.includes('(90 days)'));
    for (const detail of ['Ramesh', 'Priya', 'Anil', 'Sunita', 'Irfan', 'Kavita', 'Gurpreet', 'Lakshmi', '900000'])
      assert.ok(!brief.includes(detail), 'customer detail in the brief: ' + detail);
    step('the brief covers 90 days and has no customer names or phone numbers');
    await page.locator('details.brief').evaluate(d => { d.open = true; });
    await page.screenshot({ path: `${OUT}/plan.png` });
    await page.locator('details.brief').evaluate(d => { d.open = false; });

    await page.selectOption('#plan-language', 'Hinglish');
    await page.fill('#plan-goal', 'More sales on weekdays');
    await page.getByRole('button', { name: /Write my plan/ }).click();
    await page.locator('section.plan').waitFor({ timeout: 90000 });
    const plan = await page.locator('section.plan').innerText();
    assert.ok(plan.includes('Where the shop stands') && plan.includes('(90 days)') && plan.includes('Hinglish'));
    assert.ok((await page.locator('section.plan .md strong').count()) >= 2);
    assert.strictEqual(await page.locator('section.plan .md ol li').count(), 2);
    assert.ok(plan.includes('<b>not bold</b>'));
    assert.strictEqual(await page.locator('section.plan .md b').count(), 0);
    step('plan written and shown: headings, numbered list, bold; HTML stays text');

    const saved = page.locator('.plan-list li a').first();
    await saved.waitFor();
    await saved.click();
    await page.waitForURL(/open=plan-/);
    assert.ok((await page.locator('section.plan').innerText()).includes('Where the shop stands'));
    await page.goto(BASE + '/plan?open=..%2F..%2Fsettings.json', { waitUntil: 'networkidle' });
    assert.strictEqual(await page.locator('section.plan').count(), 0);
    step('the plan was saved, listed and reopened; a path in ?open= is refused');

    await page.setViewportSize({ width: 390, height: 800 });
    for (const route of ['/plan', '/sales']) {
      await page.goto(BASE + route, { waitUntil: 'networkidle' });
      await page.locator('.seg').waitFor();
      const overflow = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
      assert.ok(overflow <= 0, `sideways scrolling on ${route} at phone width: ${overflow}px`);
    }
    step('phone width: no sideways scrolling on Plan or Sales');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e)), []);
    console.log('No console or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
    fs.rmSync(work, { recursive: true, force: true });
  }
})().catch(e => { console.error(e); process.exit(1); });
