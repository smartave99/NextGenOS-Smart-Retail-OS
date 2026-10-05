// End-to-end check of the owner's live view, in Chromium. The shop PC connects to the owner's Supabase project with
// the one-time code the website shows; it sends the shop's figures at once (never a customer's name or phone
// number), again within seconds of a new bill, and stops when the owner disconnects it on the website. The project
// is local-supabase.js: Supabase's own database image with cloud/supabase-owner-view.sql, and PostgREST, in Docker.
// It starts the app itself on demo data, with its own settings and data folder, then stops everything:
//   npm install && npm run test:owner        (needs Docker and the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');
const supabase = require('./local-supabase');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);
const OWNER = '11111111-1111-1111-1111-111111111111';
const DEMO_CUSTOMERS = ['Priya Sharma', 'Ramesh Kumar', 'Kavita Patel', 'Gurpreet Singh'];

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-owner-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli' }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

async function startApp(env = {}) {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile, ...env },
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

async function until(check, timeout, what) {
  const end = Date.now() + timeout;
  for (;;) {
    if (await check()) return;
    if (Date.now() > end) throw new Error('Timed out waiting: ' + what);
    await new Promise(r => setTimeout(r, 1000));
  }
}

(async () => {
  if (!supabase.hasDocker()) {
    console.log('Skipped: the owner view test needs Docker.');
    return;
  }

  const project = await supabase.start();
  let app;
  const browser = await chromium.launch();
  const errors = [];
  try {
    app = await startApp();
    const live = () => JSON.parse(project.asUser(OWNER, 'select data from public.shop_live;') || 'null');

    // The owner signs up on the website, creates the shop and makes a code.
    project.psql(`insert into auth.users (id, email) values ('${OWNER}', 'owner@example.com');`);
    const shop = project.asUser(OWNER, "select public.create_shop('Demo Mart 99');");
    const code = project.asUser(OWNER, `select public.new_pairing_code('${shop}');`);
    assert.match(code, /^[A-HJ-NP-Z2-9]{8}$/);

    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));
    await page.goto(BASE + '/settings');
    const section = page.locator('.owner-view');
    await section.getByRole('heading', { name: 'See the shop from anywhere' }).waitFor();
    await page.fill('#owner-url', project.url);
    await page.fill('#owner-key', project.serviceKey);
    await page.fill('#owner-code', code);
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.locator('.field-error', { hasText: 'secret key' }).waitFor();
    step('the project\'s secret key is refused: the shop PC must never hold one');

    await page.fill('#owner-key', project.anonKey);
    await page.fill('#owner-code', 'WXYZ-2345');
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.locator('.field-error', { hasText: 'wrong or has expired' }).waitFor();
    step('a wrong code is refused, in the words of the project');

    await page.fill('#owner-code', code.slice(0, 4).toLowerCase() + '-' + code.slice(4).toLowerCase());
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.getByRole('heading', { name: 'Sending to Demo Mart 99' }).waitFor();
    await section.locator('.owner-state', { hasText: /Last sent at \d/ }).waitFor({ timeout: 30000 });
    await page.screenshot({ path: `${OUT}/owner-1-connected.png` });
    step(`connected with the website's code (typed as ${code.slice(0, 4).toLowerCase()}-…), and the figures went at once`);

    const first = live();
    assert.strictEqual(first.demo, true);
    assert.ok(first.today.bills >= 1, 'today has bills');
    assert.strictEqual(first.bills.length, first.today.bills);
    assert.ok(first.bills.every(b => /^\d\d:\d\d$/.test(b.time) && b.number.startsWith('SR/')), 'each bill with its number and time');
    assert.strictEqual(first.week.length, 7);
    assert.ok(first.top.length > 0 && first.hours.length > 0);
    const days = Number(project.asUser(OWNER, 'select count(*) from public.shop_days;'));
    assert.ok(days >= 55, `the last 60 days for the history (${days})`);
    const everything = project.psql("select string_agg(data::text, ' ') from (select data from public.shop_live union all select data from public.shop_days) t;");
    for (const name of DEMO_CUSTOMERS) assert.ok(!everything.includes(name), `no customer name (${name})`);
    assert.ok(!/(?<![\d.])[6-9]\d{9}(?!\d)/.test(everything), 'no phone numbers');
    step(`the owner sees today (${first.today.bills} bills, ${first.bills[0].time} the latest), the week, best sellers and ${days} days, with no customer names or numbers`);

    // A new bill at the till reaches the owner within seconds.
    const till = await browser.newPage({ viewport: { width: 1366, height: 900 } });
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
    await until(() => live().today.bills === first.today.bills + 1, 45000, 'the new bill to reach the owner');
    assert.strictEqual(live().bills[0].number, number);
    step(`bill ${number} reached the owner ${Math.round((Date.now() - madeAt) / 1000)} s after it was saved`);

    // Each send carries the last 8 days again, so a bill typed in or corrected for an earlier day reaches the owner;
    // the whole 60 days go again every hour.
    const [sentAgain, lastEight, older] = project.asUser(OWNER, `select concat_ws(' ',
        count(*) filter (where d.sent_at = l.sent_at),
        count(*) filter (where d.day > (select max(day) from public.shop_days) - 8),
        count(*) filter (where d.sent_at < l.sent_at))
      from public.shop_days d cross join public.shop_live l;`).split(' ').map(Number);
    assert.ok(lastEight >= 7, `the demo has bills on most of the last 8 days (${lastEight})`);
    assert.strictEqual(sentAgain, lastEight, 'the last 8 days were sent again with the new bill');
    assert.strictEqual(older, days - lastEight, 'older days wait for the hourly send');
    step(`the new bill's send carried the last ${sentAgain} days again, not only today and yesterday`);

    // The owner disconnects the shop PC on the website: its key stops working, and the PC says so.
    project.asUser(OWNER, 'delete from public.shop_devices;');
    await section.getByRole('button', { name: 'Send now' }).click();
    await section.locator('.owner-state.problem', { hasText: 'disconnected on the website' }).waitFor({ timeout: 30000 });
    await section.getByRole('heading', { name: 'See the shop from anywhere' }).waitFor();
    assert.strictEqual(JSON.parse(fs.readFileSync(settingsFile, 'utf8')).OwnerView.ProtectedKey, '');
    await page.screenshot({ path: `${OUT}/owner-2-disconnected.png` });
    step('disconnected on the website: the PC stops and asks for a new code, keeping the URL and public key');

    // Connected again, the PC can disconnect itself, and the project forgets its key.
    const again = project.asUser(OWNER, `select public.new_pairing_code('${shop}');`);
    assert.strictEqual(await page.inputValue('#owner-url'), project.url);
    await page.fill('#owner-code', again);
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.getByRole('heading', { name: 'Sending to Demo Mart 99' }).waitFor();
    assert.strictEqual(project.asUser(OWNER, 'select count(*) from public.shop_devices;'), '1');
    await section.getByRole('button', { name: 'Disconnect' }).click();
    await section.getByRole('heading', { name: 'See the shop from anywhere' }).waitFor();
    assert.strictEqual(project.asUser(OWNER, 'select count(*) from public.shop_devices;'), '0');
    step('connected again with a new code, then "Disconnect" on the PC removes it from the project too');

    const third = project.asUser(OWNER, `select public.new_pairing_code('${shop}');`);
    await page.fill('#owner-code', third);
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.getByRole('heading', { name: 'Sending to Demo Mart 99' }).waitFor();
    await section.locator('.owner-state', { hasText: /Last sent at \d/ }).waitFor({ timeout: 30000 });

    // A PC that finds no POS database when it starts (Pos:Mode Auto falls back to the demo shop, e.g. while SQL
    // Server is not ready) never sends: the figures would be the demo's, in place of the shop's.
    const lastSent = project.asUser(OWNER, 'select sent_at from public.shop_live;');
    const beforeRestart = errors.length;
    stopApp(app);
    await until(async () => { try { await fetch(BASE + '/'); return false; } catch { return true; } }, 30000, 'the app to stop');
    app = await startApp({ Pos__Mode: 'Auto' });
    await page.goto(BASE + '/settings');
    errors.splice(beforeRestart); // the open page tried to reconnect while the app was stopped
    await section.getByRole('heading', { name: 'Sending to Demo Mart 99' }).waitFor();
    await section.locator('.owner-state.problem', { hasText: 'did not find the POS database' }).waitFor({ timeout: 30000 });
    await section.getByRole('button', { name: 'Send now' }).click();
    await page.waitForTimeout(8000); // the app's first look is 5 seconds after it starts
    assert.strictEqual(project.asUser(OWNER, 'select sent_at from public.shop_live;'), lastSent, 'nothing was sent');
    await page.screenshot({ path: `${OUT}/owner-3-no-pos.png` });
    step('started without finding the POS database, the PC sent nothing, and says why');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e)), []);
    console.log('No console errors or page errors.');
  } catch (e) {
    console.error('FAILED: ' + (e && e.message));
    process.exitCode = 1;
  } finally {
    await browser.close();
    if (app) stopApp(app);
    project.stop();
    fs.rmSync(work, { recursive: true, force: true });
  }
})();
