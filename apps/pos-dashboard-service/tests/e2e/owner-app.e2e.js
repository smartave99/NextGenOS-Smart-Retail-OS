// End-to-end check of the owner's web page (SmartRetailPOS/owner-app), in Chromium, against a real local Supabase
// with sign-in and live updates: the owner creates an account and the shop, makes a code, the shop PC (the app on
// demo data) connects with it, the figures appear on the page by themselves, a new bill follows within seconds,
// and the owner disconnects the PC. It needs a local Supabase started with Supabase's command-line tool:
//   npx supabase init
//   npx supabase start -x studio,imgproxy,edge-runtime,logflare,vector,supavisor,mailpit,postgres-meta,storage-api
//   OWNER_APP_SUPABASE=<that folder> npm run test:owner-app      (screenshots go to ./screenshots)
// It loads cloud/supabase-owner-view.sql into that local project and empties its shop tables first.
const { chromium } = require('playwright');
const { execFileSync, spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const http = require('http');
const os = require('os');
const path = require('path');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);
const APP_FOLDER = path.join(__dirname, '../../owner-app');
const SCHEMA = path.join(__dirname, '../../cloud/supabase-owner-view.sql');

const folder = process.env.OWNER_APP_SUPABASE;
if (!folder) {
  console.log('Skipped: set OWNER_APP_SUPABASE to the folder of a local Supabase (see the top of this file).');
  process.exit(0);
}

// The local project's address, keys and database, as the Supabase tool gives them.
const status = Object.fromEntries(execFileSync('npx', ['--yes', 'supabase', 'status', '-o', 'env'], { cwd: folder, encoding: 'utf8' })
  .split('\n').filter(l => l.includes('=')).map(l => { const i = l.indexOf('='); return [l.slice(0, i), l.slice(i + 1).replace(/^"|"$/g, '')]; }));
const psql = (sql) => execFileSync('psql', [status.DB_URL, '-v', 'ON_ERROR_STOP=1', '-q', '-At'], { input: sql, encoding: 'utf8', env: { ...process.env, PGOPTIONS: '--client-min-messages=warning' } }).trim();

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-owner-app-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli' }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

// The page as the owner puts it online: its own files, with config.js pointing at the local project.
function servePage() {
  const types = { '.html': 'text/html', '.js': 'text/javascript', '.css': 'text/css' };
  const server = http.createServer((req, res) => {
    const name = decodeURIComponent(new URL(req.url, 'http://x').pathname).replace(/^\/+/, '') || 'index.html';
    if (name === 'config.js') {
      res.writeHead(200, { 'content-type': 'text/javascript' });
      res.end(`window.SRPOS_OWNER = ${JSON.stringify({ supabaseUrl: status.API_URL, publicKey: status.ANON_KEY })};`);
      return;
    }
    const file = path.join(APP_FOLDER, name);
    if (!file.startsWith(APP_FOLDER + path.sep) || !fs.existsSync(file)) { res.writeHead(404).end(); return; }
    res.writeHead(200, { 'content-type': types[path.extname(file)] || 'application/octet-stream' });
    fs.createReadStream(file).pipe(res);
  });
  return new Promise(r => server.listen(0, '127.0.0.1', () => r(server)));
}

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
  psql(fs.readFileSync(SCHEMA, 'utf8'));
  psql('delete from public.shops;');
  const server = await servePage();
  const PAGE = `http://127.0.0.1:${server.address().port}/index.html`;
  let app;
  const browser = await chromium.launch();
  const errors = [];
  try {
    app = await startApp();
    const owner = await browser.newPage({ viewport: { width: 1280, height: 900 } });
    owner.on('pageerror', e => errors.push(e.message));
    owner.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    owner.on('dialog', d => d.accept());

    await owner.goto(PAGE);
    await owner.getByRole('heading', { name: 'See your shop, live' }).waitFor();
    await owner.getByRole('button', { name: 'Create an account' }).click();
    await owner.fill('#email', `owner${Date.now()}@example.com`);
    await owner.fill('#password', 'a-long-test-password');
    await owner.getByRole('button', { name: 'Create account' }).click();
    await owner.getByRole('heading', { name: 'Name your shop' }).waitFor({ timeout: 20000 });
    await owner.fill('#shop-name', 'Demo Mart 99');
    await owner.getByRole('button', { name: 'Create the shop' }).click();
    await owner.getByRole('heading', { name: 'No figures yet' }).waitFor({ timeout: 20000 });
    step('the owner created an account and the shop');

    await owner.getByRole('button', { name: 'Connect a shop PC' }).click();
    const code = (await owner.locator('#pairing-code').innerText()).trim();
    assert.match(code, /^[A-HJ-NP-Z2-9]{4}-[A-HJ-NP-Z2-9]{4}$/);
    assert.strictEqual(await owner.locator('.pairing dd').first().innerText(), status.API_URL);

    const pc = await browser.newPage({ viewport: { width: 1280, height: 900 } });
    await pc.goto(BASE + '/settings');
    const section = pc.locator('.owner-view');
    await pc.fill('#owner-url', status.API_URL);
    await pc.fill('#owner-key', status.ANON_KEY);
    await pc.fill('#owner-code', code);
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.getByRole('heading', { name: 'Sending to Demo Mart 99' }).waitFor({ timeout: 20000 });
    await owner.locator('#shop-pcs .note', { hasText: 'is connected' }).waitFor({ timeout: 20000 });
    await owner.locator('.hero .figure').waitFor({ timeout: 30000 });
    step(`the shop PC connected with ${code}; the page said so and showed the figures by itself`);

    assert.match(await owner.locator('.pill.live').innerText(), /^Live · /);
    assert.match(await owner.locator('.hero .label').innerText(), /^Sales today · last bill at \d{1,2}:\d{2} (am|pm)$/);
    assert.ok(await owner.locator('ul.bills li').count() >= 1);
    assert.ok(await owner.locator('text=These are the demo shop\'s figures').isVisible());
    await owner.getByRole('heading', { name: /^Last \d{2,} days$/ }).waitFor({ timeout: 20000 });
    await owner.screenshot({ path: `${OUT}/owner-app-1-live.png`, fullPage: true });
    step('today, its bills with their times, the hours, the week, best sellers, low stock, Fix now and the last days');

    // A new bill at the till
    const till = await browser.newPage({ viewport: { width: 1280, height: 900 } });
    await till.goto(BASE + '/billing');
    const scan = till.locator('input.scan-input');
    await scan.waitFor();
    await scan.fill('tea');
    await till.locator('ul.suggestions li').first().waitFor();
    await scan.press('Enter');
    await till.locator('table.lines-table tbody tr').first().waitFor();
    await till.locator('.pay-modes button', { hasText: 'Cash' }).click();
    await till.locator('.quick-cash button', { hasText: 'Exact' }).click();
    await scan.focus();
    await till.keyboard.press('F9');
    await till.getByRole('heading', { name: 'Bill saved' }).waitFor();
    const number = await till.locator('.saved-number').innerText();
    await till.close();
    const madeAt = Date.now();
    await owner.locator('ul.bills li', { hasText: number }).waitFor({ timeout: 60000 });
    step(`bill ${number} showed on the page ${Math.round((Date.now() - madeAt) / 1000)} s after it was saved, without a reload`);

    await owner.setViewportSize({ width: 390, height: 844 });
    await owner.waitForTimeout(400);
    const overflow = await owner.evaluate(() => document.documentElement.scrollWidth - window.innerWidth);
    assert.ok(overflow <= 1, `no sideways scroll on a phone (overflow ${overflow}px)`);
    await owner.screenshot({ path: `${OUT}/owner-app-2-phone.png`, fullPage: true });
    await owner.setViewportSize({ width: 1280, height: 900 });
    step('phone width: no sideways scrolling');

    await owner.locator('#shop-pcs').getByRole('button', { name: 'Disconnect' }).click();
    await owner.locator('#shop-pcs', { hasText: 'No shop PC is connected yet.' }).waitFor({ timeout: 15000 });
    await section.getByRole('button', { name: 'Send now' }).click();
    await section.locator('.owner-state.problem', { hasText: 'disconnected on the website' }).waitFor({ timeout: 20000 });
    step('the owner disconnected the shop PC on the page; the PC stopped and says so');

    await owner.getByRole('button', { name: 'Sign out' }).click();
    await owner.getByRole('heading', { name: 'See your shop, live' }).waitFor();
    step('signed out');

    assert.deepStrictEqual(errors, []);
    console.log('No console errors or page errors.');
  } catch (e) {
    console.error('FAILED: ' + (e && e.message));
    if (errors.length) console.error(errors.join('\n'));
    process.exitCode = 1;
  } finally {
    await browser.close();
    if (app) stopApp(app);
    server.close();
    psql('delete from public.shops;');
    fs.rmSync(work, { recursive: true, force: true });
  }
})();
