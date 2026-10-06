// End-to-end check of Live shop, the owner's section of the website's admin panel (smartave99/demo_shop,
// /admin/live), in Chromium, against a real local Supabase with sign-in, the authenticator app and live updates:
// the owner creates the account and the shop, makes a code, the shop PC (this app on demo data) connects with it,
// the figures appear by themselves and a new bill follows within seconds; the owner turns on the authenticator
// app, after which Supabase itself refuses the shop's data to the password alone, and signing in asks for the
// app's code; the owner turns it off again, and disconnects the PC. It needs:
//   * a local Supabase with the authenticator app on ([auth.mfa.totp] enroll_enabled and verify_enabled = true in
//     its supabase/config.toml), started as owner-app.e2e.js says;
//   * a checkout of the website with its packages installed (npm ci).
//   OWNER_APP_SUPABASE=<Supabase folder> LIVE_SHOP_SITE=<website folder> npm run test:live-shop   (screenshots: ./screenshots)
// It loads cloud/supabase-owner-view.sql into that local project and empties its shop tables first.
const { chromium } = require('playwright');
const { execFileSync, spawn } = require('child_process');
const assert = require('assert');
const crypto = require('crypto');
const fs = require('fs');
const os = require('os');
const path = require('path');

const BASE = 'http://127.0.0.1:5080';
const SITE_PORT = Number(process.env.LIVE_SHOP_PORT || 3100);
const SITE = `http://127.0.0.1:${SITE_PORT}`;
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);
const SCHEMA = path.join(__dirname, '../../cloud/supabase-owner-view.sql');

const folder = process.env.OWNER_APP_SUPABASE;
const site = process.env.LIVE_SHOP_SITE;
if (!folder || !site) {
  console.log('Skipped: set OWNER_APP_SUPABASE to a local Supabase folder and LIVE_SHOP_SITE to the website (see the top of this file).');
  process.exit(0);
}

const status = Object.fromEntries(execFileSync('npx', ['--yes', 'supabase', 'status', '-o', 'env'], { cwd: folder, encoding: 'utf8' })
  .split('\n').filter(l => l.includes('=')).map(l => { const i = l.indexOf('='); return [l.slice(0, i), l.slice(i + 1).replace(/^"|"$/g, '')]; }));
const psql = (sql) => execFileSync('psql', [status.DB_URL, '-v', 'ON_ERROR_STOP=1', '-q', '-At'], { input: sql, encoding: 'utf8', env: { ...process.env, PGOPTIONS: '--client-min-messages=warning' } }).trim();
const { createClient } = require(path.join(site, 'node_modules/@supabase/supabase-js'));

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-live-shop-'));
const settingsFile = path.join(work, 'settings.json');
// The shop's AI is the stand-in (stand-in-ai.js), as in ask.e2e.js: the owner's question from the website is answered by it.
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
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

// The authenticator app's 6-digit code (RFC 6238: SHA-1, 30 seconds), from the key the page shows.
function totp(secret, at = Date.now()) {
  const alphabet = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ234567';
  const bits = secret.replace(/=+$/, '').toUpperCase().split('').map(c => alphabet.indexOf(c).toString(2).padStart(5, '0')).join('');
  const key = Buffer.from(bits.match(/.{8}/g).map(b => parseInt(b, 2)));
  const counter = Buffer.alloc(8);
  counter.writeBigUInt64BE(BigInt(Math.floor(at / 30000)));
  const mac = crypto.createHmac('sha1', key).update(counter).digest();
  const offset = mac[mac.length - 1] & 0xf;
  return String((mac.readUInt32BE(offset) & 0x7fffffff) % 1000000).padStart(6, '0');
}

// A code not yet used: Supabase accepts each code once, so wait for the next 30 seconds when needed.
let lastCode = null;
async function freshCode(secret) {
  for (;;) {
    const code = totp(secret);
    if (code !== lastCode && Date.now() % 30000 < 25000) { lastCode = code; return code; }
    await new Promise(r => setTimeout(r, 1000));
  }
}

function start(command, args, options, what, url) {
  const child = spawn(command, args, { ...options, stdio: 'ignore', detached: process.platform !== 'win32' });
  return (async () => {
    for (let i = 0; i < 240; i++) {
      try { if ((await fetch(url)).ok) return child; } catch { /* not up yet */ }
      await new Promise(r => setTimeout(r, 1000));
    }
    throw new Error(`${what} did not start on ${url}`);
  })();
}

function stop(child) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(child.pid), '/t', '/f']) : process.kill(-child.pid); } catch { /* gone */ }
}

(async () => {
  psql(fs.readFileSync(SCHEMA, 'utf8'));
  psql('delete from public.shops;');
  let app, web;
  const browser = await chromium.launch();
  const errors = [];
  try {
    app = await start('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'],
      { env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile } }, 'The app', BASE + '/');
    web = await start('npx', ['next', 'dev', '--turbopack', '-H', '127.0.0.1', '-p', String(SITE_PORT)],
      { cwd: site, env: { ...process.env, NEXT_TELEMETRY_DISABLED: '1', NEXT_PUBLIC_SUPABASE_URL: status.API_URL, NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY: status.PUBLISHABLE_KEY } },
      'The website', SITE + '/robots.txt');

    const owner = await browser.newPage({ viewport: { width: 1280, height: 900 } });
    const failed = [];
    owner.on('pageerror', e => errors.push(e.message));
    owner.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    owner.on('dialog', d => d.accept());
    owner.on('response', r => { if (r.status() >= 400) failed.push(`${r.status()} ${r.request().method()} ${r.url()}`); });
    // A request the server answered counts as done, even when the page did not read the (empty) answer.
    owner.on('requestfailed', async r => { if (!(await r.response().catch(() => null))) failed.push(`${r.failure()?.errorText} ${r.url()}`); });

    // Without the website's admin sign-in, Live shop opens on its own: the owner's Supabase account is the key.
    await owner.goto(SITE + '/admin/live', { timeout: 240000 });
    await owner.getByRole('heading', { name: 'See your shop, live' }).waitFor({ timeout: 120000 });
    assert.strictEqual(await owner.getByText('Admin Portal').count(), 0, 'no admin menu without the website\'s admin sign-in');
    const email = `owner${Date.now()}@example.com`;
    const password = 'a-long-test-password';
    await owner.getByRole('button', { name: 'Create the owner\'s account' }).click();
    await owner.fill('#live-email', email);
    await owner.fill('#live-password', password);
    await owner.getByRole('button', { name: 'Create account' }).click();
    await owner.getByRole('heading', { name: 'Name your shop' }).waitFor({ timeout: 30000 });
    await owner.fill('#live-shop-name', 'Demo Mart 99');
    await owner.getByRole('button', { name: 'Create the shop' }).click();
    await owner.getByRole('heading', { name: 'No figures yet' }).waitFor({ timeout: 30000 });
    step('the owner created the account and the shop on the website\'s Live shop');

    await owner.getByRole('button', { name: 'Connect a shop PC' }).click();
    const code = (await owner.locator('#live-pairing-code').innerText()).trim();
    assert.match(code, /^[A-HJ-NP-Z2-9]{4}-[A-HJ-NP-Z2-9]{4}$/);

    const pc = await browser.newPage({ viewport: { width: 1280, height: 900 } });
    await pc.goto(BASE + '/settings');
    const section = pc.locator('.owner-view');
    await pc.fill('#owner-url', status.API_URL);
    await pc.fill('#owner-key', status.PUBLISHABLE_KEY);
    await pc.fill('#owner-code', code);
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.getByRole('heading', { name: 'Sending to Demo Mart 99' }).waitFor({ timeout: 20000 });
    await owner.getByText(/is connected\. Its figures show here within a minute\./).waitFor({ timeout: 20000 });
    await owner.getByTestId('live-sales').waitFor({ timeout: 60000 });
    assert.match(await owner.getByTestId('live-state').innerText(), /^Live · /);
    assert.ok(await owner.getByTestId('live-bills').locator('li').count() >= 1);
    await owner.getByRole('heading', { name: /^Last \d{2,} days$/ }).waitFor({ timeout: 30000 });
    await owner.screenshot({ path: `${OUT}/live-shop-1.png`, fullPage: true });
    step(`the shop PC connected with ${code}; the figures, bills and history showed by themselves`);

    // A new bill at the till reaches the page without a reload.
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
    await owner.getByTestId('live-bills').getByText(number).waitFor({ timeout: 60000 });
    step(`bill ${number} showed on Live shop ${Math.round((Date.now() - madeAt) / 1000)} s after it was saved`);

    // The owner asks the shop's AI from the website: the shop PC takes the question and answers with its own AI.
    const ask = owner.getByTestId('ask-shop');
    await ask.getByLabel('Your question').fill('  Which product sells best?  ');
    await ask.getByRole('button', { name: 'Ask' }).click();
    const askedAt = Date.now();
    const answer = owner.getByTestId('shop-answer').first();
    await answer.getByText('You asked: “Which product sells best?”').waitFor({ timeout: 60000 });
    assert.match(await answer.locator('strong').first().innerText(), /\S/);
    assert.strictEqual(await answer.locator('li').count(), 1);
    await owner.screenshot({ path: `${OUT}/live-shop-ask.png`, fullPage: true });
    step(`the owner asked the shop's AI on the website; the shop PC answered in ${Math.round((Date.now() - askedAt) / 1000)} s`);

    // The owner turns on the authenticator app.
    const security = owner.locator('section', { has: owner.getByRole('heading', { name: 'Two-step sign-in' }) });
    await security.getByText('Off', { exact: true }).waitFor();
    await security.getByRole('button', { name: 'Turn on' }).click();
    await security.getByRole('img', { name: 'Code to scan with the authenticator app' }).waitFor();
    const secret = (await security.locator('p.font-mono').innerText()).trim();
    assert.match(secret, /^[A-Z2-7]{16,}$/);
    await owner.fill('#live-mfa-code', await freshCode(secret));
    await security.getByRole('button', { name: 'Turn on' }).click();
    await security.getByText('On', { exact: true }).waitFor({ timeout: 20000 });
    step('the owner turned on the authenticator app (its key read from the page)');

    // Supabase itself now refuses the shop's data to the password alone; with the app's code as well, it shows it.
    const direct = createClient(status.API_URL, status.PUBLISHABLE_KEY, { auth: { persistSession: false, autoRefreshToken: false } });
    const signIn = await direct.auth.signInWithPassword({ email, password });
    assert.ifError(signIn.error);
    const onlyPassword = await direct.from('shop_live').select('shop_id');
    assert.deepStrictEqual([onlyPassword.error, onlyPassword.data], [null, []], 'the password alone sees nothing');
    const refused = await direct.rpc('new_pairing_code', { p_shop: (await direct.from('shop_devices').select('shop_id')).data?.[0]?.shop_id || '00000000-0000-0000-0000-000000000000' });
    assert.ok(refused.error, 'the password alone makes no code');
    const factors = await direct.auth.mfa.listFactors();
    const verified = await direct.auth.mfa.challengeAndVerify({ factorId: factors.data.totp[0].id, code: await freshCode(secret) });
    assert.ifError(verified.error);
    const withCode = await direct.from('shop_live').select('shop_id');
    assert.strictEqual(withCode.data.length, 1, 'with the app\'s code the owner sees the shop');
    await direct.auth.signOut({ scope: 'local' });
    step('Supabase itself refused the shop\'s data to the password alone, and showed it with the app\'s code');

    // Signed out and in again, the page asks for the app's code.
    await owner.getByRole('button', { name: 'Sign out' }).click();
    await owner.getByRole('heading', { name: 'See your shop, live' }).waitFor();
    await owner.fill('#live-email', email);
    await owner.fill('#live-password', password);
    await owner.getByRole('button', { name: 'Sign in' }).click();
    await owner.getByRole('heading', { name: 'Enter the code' }).waitFor({ timeout: 20000 });
    await owner.fill('#live-code', '000000');
    await owner.getByRole('button', { name: 'Continue' }).click();
    await owner.getByRole('alert').waitFor();
    await owner.fill('#live-code', await freshCode(secret));
    await owner.getByRole('button', { name: 'Continue' }).click();
    await owner.getByTestId('live-bills').getByText(number).waitFor({ timeout: 30000 });
    step('signing in again asked for the app\'s code (a wrong one refused), then showed the shop');

    await owner.setViewportSize({ width: 390, height: 844 });
    await owner.waitForTimeout(500);
    const overflow = await owner.evaluate(() => {
      const scroller = document.querySelector('.overflow-y-auto') || document.documentElement;
      return Math.max(document.documentElement.scrollWidth - window.innerWidth, scroller.scrollWidth - scroller.clientWidth);
    });
    assert.ok(overflow <= 1, `no sideways scroll on a phone (overflow ${overflow}px)`);
    await owner.screenshot({ path: `${OUT}/live-shop-2-phone.png`, fullPage: true });
    await owner.setViewportSize({ width: 1280, height: 900 });
    step('phone width: no sideways scrolling');

    // The owner turns the app off again, then disconnects the shop PC.
    await security.getByRole('button', { name: 'Turn off' }).click();
    await security.getByText('Off', { exact: true }).waitFor({ timeout: 20000 });
    await owner.locator('section', { has: owner.getByRole('heading', { name: 'Shop PCs' }) }).getByRole('button', { name: 'Disconnect' }).click();
    await owner.getByText('No shop PC is connected yet.').waitFor({ timeout: 20000 });
    await section.getByRole('button', { name: 'Send now' }).click();
    await section.locator('.owner-state.problem', { hasText: 'disconnected on the website' }).waitFor({ timeout: 20000 });
    step('the owner turned the app off and disconnected the shop PC; the PC stopped and says so');

    // Only the wrong code may fail (and, in a sandbox without the internet's certificates, the website's own
    // Vercel Speed Insights script); the browser writes each failed request to the console as well.
    const wrongCode = failed.filter(f => /^422 POST .*\/auth\/v1\/factors\/[^/]+\/verify$/.test(f));
    const unexpected = failed.filter(f => !wrongCode.includes(f) && !/ https:\/\/va\.vercel-scripts\.com\//.test(f));
    assert.strictEqual(wrongCode.length, 1, 'the wrong code was refused, once');
    assert.deepStrictEqual(unexpected, [], 'no other request failed');
    assert.deepStrictEqual(errors.filter(e => !/^Failed to load resource/.test(e) && !/Download the React DevTools|\[Fast Refresh\]/.test(e)), []);
    console.log('No console errors or page errors.');
  } catch (e) {
    console.error('FAILED: ' + (e && e.message));
    if (errors.length) console.error(errors.join('\n'));
    process.exitCode = 1;
  } finally {
    await browser.close();
    if (app) stop(app);
    if (web) stop(web);
    psql('delete from public.shops;');
    fs.rmSync(work, { recursive: true, force: true });
  }
})();
