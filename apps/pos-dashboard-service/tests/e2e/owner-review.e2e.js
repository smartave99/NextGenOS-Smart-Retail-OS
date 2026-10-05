// End-to-end check of the Monday review in the owner's live view, in Chromium, without Docker or a Supabase project.
// Part 1, the shop PC: the app on demo data connects to a stand-in for the owner's Supabase REST API and sends the
// live figures and the Monday review (figures and product names only, never a customer). A project whose script is
// older has no function for the review: the PC says so in Settings and the live figures go on. The review goes when
// the owner marks the week as reviewed at the shop, and not again with every send.
// Part 2, the owner's page (SmartRetailPOS/owner-app): served with a stand-in for supabase-js and fed with the review
// the PC really sent: the Last week screen, a project without the reports table, a week not reviewed yet, a new
// review arriving live, a product named like HTML, and a phone.
//   npm install && npm run test:owner-review          (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
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
const KEY = 'sb_publishable_' + 'a'.repeat(24);
const DEVICE_KEY = 'k'.repeat(64);
const DEMO_CUSTOMERS = ['Priya Sharma', 'Ramesh Kumar', 'Kavita Patel', 'Gurpreet Singh'];

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-owner-review-'));
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

function stopApp(app) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid); } catch { /* gone */ }
}

async function until(check, timeout, what) {
  const end = Date.now() + timeout;
  for (;;) {
    if (await check()) return;
    if (Date.now() > end) throw new Error('Timed out waiting: ' + what);
    await new Promise(r => setTimeout(r, 250));
  }
}

const listen = (server) => new Promise(r => server.listen(0, '127.0.0.1', () => r(server)));
const readBody = (req) => new Promise(r => { let raw = ''; req.on('data', c => { raw += c; }); req.on('end', () => r(raw)); });
const iso = (d) => `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
const digits = (text) => Number(String(text).replace(/[^\d]/g, ''));
const dayOf = (text) => new Date(text + 'T12:00:00');

// The owner's Supabase REST API, as far as the shop PC uses it. `reports` says whether the project's script is new
// enough to have the function for the review (it answers like PostgREST does when a function is not there).
async function startProject() {
  const project = { reports: false, calls: [], live: null, reviews: [] };
  const server = http.createServer(async (req, res) => {
    const fn = new URL(req.url, 'http://x').pathname.replace('/rest/v1/rpc/', '');
    const raw = await readBody(req);
    let body = null;
    try { body = raw ? JSON.parse(raw) : null; } catch { /* not JSON */ }
    project.calls.push(fn);
    const send = (status, value) => { res.writeHead(status, { 'content-type': 'application/json' }); res.end(typeof value === 'string' ? value : JSON.stringify(value)); };
    if (req.headers.apikey !== KEY) return send(401, { message: 'Invalid API key' });
    if (fn === 'connect_shop_pc') {
      return body.p_code === 'ABCDEFGH'
        ? send(200, { key: DEVICE_KEY, shop_id: 'shop-1', shop_name: 'Smart Avenue 99' })
        : send(400, { code: 'P0001', message: 'That code is wrong or has expired. Make a new one on the website.' });
    }
    if (!body || body.p_key !== DEVICE_KEY) return send(403, { code: '28000', message: 'This shop PC is not connected' });
    if (fn === 'send_live_figures') {
      project.live = body.p_live;
      return send(200, JSON.stringify(new Date().toISOString()));
    }
    if (fn === 'send_shop_report') {
      if (!project.reports) return send(404, { code: 'PGRST202', message: 'Could not find the function public.send_shop_report(p_data, p_key, p_kind) in the schema cache' });
      project.reviews.push({ kind: body.p_kind, data: body.p_data });
      return send(200, JSON.stringify(new Date().toISOString()));
    }
    if (fn === 'next_shop_question') return send(200, 'null');
    if (fn === 'disconnect_shop_pc') return send(204, '');
    return send(404, { code: 'PGRST202', message: 'No such function' });
  });
  await listen(server);
  project.url = `http://127.0.0.1:${server.address().port}`;
  project.stop = () => server.close();
  project.count = (name) => project.calls.filter(c => c === name).length;
  return project;
}

// A stand-in for supabase-js, as far as the owner's page uses it: the owner is signed in, every table answers what the
// test says (fetched from /__stub/<table>), and the test can send a change as realtime would.
const STAND_IN_LIBRARY = `
window.supabase = { createClient() {
  const handlers = [];
  const query = (table) => {
    const q = {
      select(columns) { q.columns = columns || ''; return q; }, eq() { return q; }, gte() { return q; }, order() { return q; }, limit() { return q; },
      maybeSingle() { q.one = true; return q; },
      then(resolve, reject) {
        fetch('/__stub/' + table + '?columns=' + encodeURIComponent(q.columns || '')).then(r => r.json()).then(body => {
          const data = q.one && Array.isArray(body.data) ? (body.data[0] ?? null) : body.data;
          resolve({ data, error: body.error || null, status: body.status || 200 });
        }, reject);
      },
    };
    return q;
  };
  const client = {
    auth: {
      onAuthStateChange(callback) { setTimeout(() => callback('INITIAL_SESSION', { user: { id: 'owner' } }), 0); return { data: { subscription: { unsubscribe() {} } } }; },
      signOut() { return Promise.resolve({}); },
    },
    from: query,
    rpc() { return Promise.resolve({ data: null, error: null }); },
    channel() { const channel = { on(type, filter, callback) { handlers.push({ table: filter.table, callback }); return channel; }, subscribe() { return channel; } }; return channel; },
    removeChannel() {},
    emit(table, row) { for (const h of handlers) if (h.table === table) h.callback({ new: row }); },
  };
  window.__client = client;
  return client;
} };`;

// The owner's page as the owner puts it online, with the stand-in library and the tables the test sets.
async function servePage(tables) {
  const types = { '.html': 'text/html', '.js': 'text/javascript', '.css': 'text/css' };
  const server = http.createServer((req, res) => {
    const name = decodeURIComponent(new URL(req.url, 'http://x').pathname).replace(/^\/+/, '') || 'index.html';
    if (name === 'config.js') { res.writeHead(200, { 'content-type': 'text/javascript' }); res.end('window.SRPOS_OWNER = { supabaseUrl: "http://127.0.0.1:1", publicKey: "sb_publishable_test" };'); return; }
    if (name === 'vendor/supabase.js') { res.writeHead(200, { 'content-type': 'text/javascript' }); res.end(STAND_IN_LIBRARY); return; }
    if (name.startsWith('__stub/')) {
      // A table can say it lacks a column ("noColumn"): asked for it, it answers as PostgREST does for a column that is not there.
      let table = tables[name.slice(7)] ?? { data: [] };
      if (table.noColumn && (new URL(req.url, 'http://x').searchParams.get('columns') || '').includes(table.noColumn)) {
        table = { data: null, error: { code: '42703', message: `column ${table.noColumn} does not exist` }, status: 400 };
      }
      res.writeHead(200, { 'content-type': 'application/json' });
      res.end(JSON.stringify(table));
      return;
    }
    const file = path.join(APP_FOLDER, name);
    if (!file.startsWith(APP_FOLDER + path.sep) || !fs.existsSync(file)) { res.writeHead(404).end(); return; }
    res.writeHead(200, { 'content-type': types[path.extname(file)] || 'application/octet-stream' });
    fs.createReadStream(file).pipe(res);
  });
  await listen(server);
  return server;
}

(async () => {
  const project = await startProject();
  let app;
  let pageServer;
  const browser = await chromium.launch();
  const errors = [];
  try {
    // ---- Part 1: the shop PC ----
    app = await startApp();
    const pc = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    pc.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    pc.on('pageerror', e => errors.push(e.message));
    await pc.goto(BASE + '/settings');
    const section = pc.locator('.owner-view');
    await pc.fill('#owner-url', project.url);
    await pc.fill('#owner-key', KEY);
    await pc.fill('#owner-code', 'ABCD-EFGH');
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.getByRole('heading', { name: 'Sending to Smart Avenue 99' }).waitFor();
    await section.locator('.owner-state:not(.owner-review-state)', { hasText: /Last sent at \d/ }).waitFor({ timeout: 30000 });
    await section.locator('.owner-review-state.problem', { hasText: 'does not have the weekly review yet' }).waitFor({ timeout: 30000 });
    assert.ok(project.live && project.live.today, 'the live figures were sent');
    assert.strictEqual(project.reviews.length, 0);
    assert.strictEqual(await section.locator('.owner-state.problem:not(.owner-review-state)').count(), 0, 'the live view has no problem');
    await pc.screenshot({ path: `${OUT}/owner-review-1-old-script.png` });
    step('a project whose script is older has no function for the review: Settings says to run the script again, and the live figures go on');

    // A try that failed is repeated after ten minutes, not with every send.
    const asked = project.count('send_shop_report');
    const livePerhaps = project.count('send_live_figures');
    await section.getByRole('button', { name: 'Send now' }).click();
    await until(() => project.count('send_live_figures') > livePerhaps, 30000, 'the live figures to go again');
    await new Promise(r => setTimeout(r, 1500));
    assert.strictEqual(project.count('send_shop_report'), asked, 'the review is not asked for again at once');
    step('the review is not asked for again with every send, only after ten minutes');

    // The project's script is updated. Marking the week as reviewed at the shop makes the review due at once.
    project.reports = true;
    const shop = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    await shop.goto(BASE + '/review');
    const shopKpis = shop.locator('.kpis');
    await shopKpis.waitFor();
    await shop.getByRole('button', { name: 'Mark the week as reviewed' }).click();
    await shop.locator('.pill.good', { hasText: 'Reviewed' }).waitFor();
    await section.getByRole('button', { name: 'Send now' }).click();
    await until(() => project.reviews.length === 1, 30000, 'the review to be sent');
    await section.locator('.owner-review-state:not(.problem)', { hasText: 'The Monday review was sent at' }).waitFor();
    await pc.screenshot({ path: `${OUT}/owner-review-2-sent.png` });
    step('after the script was updated and the week marked as reviewed at the shop, the review went at once');

    // Sent again with the live figures, it is not due again: it goes once an hour.
    const liveBefore = project.count('send_live_figures');
    await section.getByRole('button', { name: 'Send now' }).click();
    await until(() => project.count('send_live_figures') > liveBefore, 30000, 'the live figures to be sent again');
    await new Promise(r => setTimeout(r, 1500));
    assert.strictEqual(project.reviews.length, 1, 'the review waits for its hour');
    step('the live figures go on as before, and the review is not sent with every one of them');

    // What was sent.
    const sent = project.reviews[0];
    const review = sent.data;
    assert.strictEqual(sent.kind, 'review');
    assert.strictEqual(review.version, 1);
    assert.strictEqual(review.demo, true);
    assert.strictEqual(dayOf(review.thisWeek.from).getDay(), 1, 'last week starts on a Monday');
    assert.strictEqual(dayOf(review.thisWeek.to).getDay(), 0, 'and ends on a Sunday');
    assert.strictEqual((dayOf(review.thisWeek.to) - dayOf(review.thisWeek.from)) / 86400000, 6);
    assert.strictEqual(iso(new Date(dayOf(review.weekBefore.to).getTime() + 86400000)), review.thisWeek.from, 'the week before ends the day before');
    assert.ok(review.thisWeek.sales > 0 && review.thisWeek.bills > 0 && review.thisWeek.averageBill > 0, 'the demo shop sold last week');
    assert.ok(review.yearBefore === null || iso(new Date(dayOf(review.thisWeek.from).getTime() - 364 * 86400000)) === review.yearBefore.from, 'a year before is 52 weeks back');
    assert.strictEqual(review.reviewedOn, iso(new Date()), 'the week was marked as reviewed today');
    assert.ok(Array.isArray(review.runningOut) && Array.isArray(review.notSelling));
    assert.ok(review.runningOut.length + review.notSelling.length > 0, 'the demo shop has products running out or not selling');
    const text = JSON.stringify(review);
    for (const name of DEMO_CUSTOMERS) assert.ok(!text.includes(name), `no customer name (${name})`);
    assert.ok(!/(?<![\d.])[6-9]\d{9}(?!\d)/.test(text), 'no phone numbers');
    const allowed = new Set(['version', 'demo', 'sentAt', 'thisWeek', 'weekBefore', 'yearBefore', 'runningOut', 'notSelling', 'reviewedOn',
      'from', 'to', 'sales', 'bills', 'averageBill', 'profit', 'margin', 'name', 'inHand', 'perDay', 'daysLeft', 'value']);
    const keys = new Set();
    JSON.stringify(review, (key, value) => { if (key && !/^\d+$/.test(key)) keys.add(key); return value; });
    assert.deepStrictEqual([...keys].filter(k => !allowed.has(k)), [], 'only the properties the page knows');

    // The owner sees what the shop's own Monday review shows.
    const kpiText = await shopKpis.innerText();
    const salesShown = digits(/Sales\s*₹([\d,]+)/.exec(kpiText)?.[1]);
    const billsShown = digits(/Bills\s*([\d,]+)/.exec(kpiText)?.[1]);
    assert.ok(Math.abs(salesShown - Math.round(review.thisWeek.sales)) <= 1, `the same sales as the shop's review (${salesShown} and ${review.thisWeek.sales})`);
    assert.strictEqual(billsShown, review.thisWeek.bills);
    const shownOut = await shop.locator('section[aria-labelledby="out-head"] .review-alert strong').allInnerTexts();
    const shownDead = await shop.locator('section[aria-labelledby="dead-head"] .review-alert strong').allInnerTexts();
    assert.deepStrictEqual(review.runningOut.map(p => p.name), shownOut);
    assert.deepStrictEqual(review.notSelling.map(p => p.name), shownDead);
    step(`the review carries last week (${review.thisWeek.bills} bills, ${Math.round(review.thisWeek.sales)} rupees), the week before, ${review.yearBefore ? 'a year before' : 'no year before'}, ${review.runningOut.length} products running out and ${review.notSelling.length} not selling, as the shop's own Monday review shows them, with no customer names or numbers`);

    // ---- Part 2: the owner's page ----
    const now = new Date().toISOString();
    const tables = {
      shops: { data: [{ id: 'shop-1', name: 'Smart Avenue 99' }] },
      shop_live: { data: [{ data: project.live, sent_at: now }] },
      shop_devices: { data: [{ id: 'd1', label: 'Shop PC (TILL-1)', connected_at: now, last_seen_at: now }] },
      shop_days: { data: [] },
      shop_reports: { data: [{ kind: 'review', data: review, sent_at: now }] },
    };
    pageServer = await servePage(tables);
    const PAGE = `http://127.0.0.1:${pageServer.address().port}/index.html`;
    const owner = await browser.newPage({ viewport: { width: 1280, height: 900 } });
    // A new query each time, so that opening the page is a real load, not a change of the address's hash.
    let loads = 0;
    const open = (hash = '') => owner.goto(`${PAGE}?load=${++loads}${hash}`);
    owner.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    owner.on('pageerror', e => errors.push(e.message));
    await open();
    const today = owner.getByRole('tab', { name: 'Today' });
    const lastWeek = owner.getByRole('tab', { name: 'Last week' });
    await owner.locator('.hero .figure').waitFor();
    assert.strictEqual(await today.getAttribute('aria-selected'), 'true');
    assert.strictEqual(await lastWeek.getAttribute('aria-selected'), 'false');
    step('the page opens on Today, with a tab for Last week');

    await lastWeek.click();
    const rupees = (value) => new Intl.NumberFormat('en-IN', { style: 'currency', currency: 'INR', maximumFractionDigits: 0 }).format(Math.round(value));
    await owner.getByRole('heading', { name: /^Last week, / }).waitFor();
    assert.strictEqual(await lastWeek.getAttribute('aria-selected'), 'true');
    assert.strictEqual(new URL(owner.url()).hash, '#review');
    assert.match(await owner.getByRole('heading', { name: /^Last week, / }).innerText(), /^Last week, \d{1,2}(–\d{1,2} [A-Z][a-z]{2,3}| [A-Z][a-z]{2,3} – \d{1,2} [A-Z][a-z]{2,3})$/);
    assert.strictEqual(await owner.locator('.hero').count(), 0, 'Today is not drawn on this screen');
    const stats = await owner.locator('.stat').evaluateAll(cards => cards.map(c => ({ label: c.querySelector('.label').textContent, figure: c.querySelector('.figure').textContent, delta: c.querySelector('.delta').textContent })));
    assert.deepStrictEqual(stats.map(s => s.label), ['Sales', 'Bills', 'Average bill', 'Profit before GST']);
    assert.strictEqual(digits(stats[0].figure), digits(rupees(review.thisWeek.sales)));
    assert.strictEqual(digits(stats[1].figure), review.thisWeek.bills);
    assert.match(stats[0].delta, /^(▲|▼) \d+% vs ₹|^same vs ₹/);
    assert.strictEqual(digits(stats[0].delta.split(' vs ')[1]), digits(rupees(review.weekBefore.sales)), 'the week before is named in rupees');
    const yearLine = await owner.locator('.review-year').innerText();
    assert.ok(review.yearBefore ? yearLine.startsWith('The same week a year before (') : yearLine.startsWith('The POS has no bills from the same week a year before'), yearLine);
    assert.deepStrictEqual(await owner.locator('section:has(h2:text-is("Running out")) .rows li > span:first-child').evaluateAll(l => l.map(e => e.firstChild.textContent)), review.runningOut.map(p => p.name));
    assert.deepStrictEqual(await owner.locator('section:has(h2:text-is("Not selling")) .rows li > span:first-child').evaluateAll(l => l.map(e => e.firstChild.textContent)), review.notSelling.map(p => p.name));
    await owner.getByText('Reviewed on', { exact: false }).waitFor();
    await owner.screenshot({ path: `${OUT}/owner-review-3-page.png`, fullPage: true });
    step('Last week shows the four figures against the week before, the year before, what is running out and what is not selling, and that the week was reviewed');

    // The link to the screen, and back.
    await open('#review');
    await owner.getByRole('heading', { name: /^Last week, / }).waitFor();
    await today.click();
    await owner.locator('.hero .figure').waitFor();
    assert.strictEqual(new URL(owner.url()).hash, '');
    step('#review opens the screen, and Today goes back');

    // A product named like HTML is drawn as text; a week not reviewed yet says so; a review arrives live.
    const odd = {
      ...review,
      reviewedOn: null,
      runningOut: [{ name: '<img src=x onerror="window.__xss=1">Rice', inHand: 0, perDay: 2.5, daysLeft: 0 }, ...review.runningOut.slice(0, 2)],
      notSelling: [{ name: '<b>Pen</b>', inHand: 40, value: 200 }],
    };
    tables.shop_reports = { data: [{ kind: 'review', data: odd, sent_at: now }] };
    await open('#review');
    await owner.getByText('Not reviewed yet').waitFor();
    assert.strictEqual(await owner.locator('section:has(h2:text-is("Running out")) .rows li').first().innerText().then(t => t.includes('<img src=x')), true);
    assert.strictEqual(await owner.evaluate(() => window.__xss), undefined, 'a name is text, not HTML');
    assert.strictEqual(await owner.locator('.rows img, .rows b').count(), 0);
    assert.ok((await owner.locator('section:has(h2:text-is("Running out")) .pill.bad').first().innerText()).includes('Out of stock'));
    await owner.screenshot({ path: `${OUT}/owner-review-4-odd.png`, fullPage: true });
    await owner.evaluate((row) => window.__client.emit('shop_reports', row), { kind: 'review', data: { ...review, thisWeek: { ...review.thisWeek, sales: 777 } }, sent_at: new Date().toISOString() });
    await owner.locator('.stat .figure').first().filter({ hasText: '₹777' }).waitFor();
    step('a name like HTML is drawn as text, a week not reviewed says so, and a new review shows the moment it arrives');

    // A project whose script is older has no table for reports; or the shop PC has not sent one yet.
    tables.shop_reports = { data: null, error: { code: 'PGRST205', message: "Could not find the table 'public.shop_reports' in the schema cache" }, status: 404 };
    await open('#review');
    await owner.getByRole('heading', { name: 'The weekly review needs a newer script' }).waitFor();
    await today.click();
    await owner.locator('.hero .figure').waitFor();
    assert.strictEqual(await owner.locator('.note.problem').count(), 0, 'Today does not show a problem for it');
    tables.shop_reports = { data: [] };
    await open('#review');
    await owner.getByRole('heading', { name: 'No review yet' }).waitFor();
    step('without the reports table the page says to run the script again, and Today is not troubled by it; with no review yet it says so');

    // Several shop PCs: the main one is marked. One PC needs no mark, and a project whose script is older has no such column.
    const pcs = owner.locator('#shop-pcs');
    tables.shop_devices = { data: [
      { id: 'd1', label: 'Mother PC', connected_at: now, last_seen_at: now, is_main: true },
      { id: 'd2', label: 'Counter 2', connected_at: now, last_seen_at: now, is_main: false },
    ] };
    await open();
    await pcs.locator('li', { hasText: 'Mother PC' }).locator('.pill.role', { hasText: 'Main PC' }).waitFor();
    await pcs.locator('li', { hasText: 'Counter 2' }).locator('.pill.role', { hasText: 'Counter' }).waitFor();
    await pcs.screenshot({ path: `${OUT}/owner-review-6-pcs.png` });
    tables.shop_devices = { data: [{ id: 'd1', label: 'Mother PC', connected_at: now, last_seen_at: now, is_main: true }] };
    await open();
    await pcs.locator('li', { hasText: 'Mother PC' }).waitFor();
    assert.strictEqual(await pcs.locator('.pill.role').count(), 0, 'one PC is not marked');
    tables.shop_devices = { noColumn: 'is_main', data: [
      { id: 'd1', label: 'Mother PC', connected_at: now, last_seen_at: now },
      { id: 'd2', label: 'Counter 2', connected_at: now, last_seen_at: now },
    ] };
    await open();
    await pcs.locator('li', { hasText: 'Counter 2' }).waitFor();
    assert.strictEqual(await pcs.locator('li').count(), 2);
    assert.strictEqual(await owner.locator('.pill.role, .note.problem').count(), 0, 'a project without the column still shows its PCs');
    step('with several shop PCs the main one is marked; one PC is not marked; a project without the column still lists its PCs');

    tables.shop_reports = { data: [{ kind: 'review', data: review, sent_at: now }] };
    await open('#review');
    await owner.getByRole('heading', { name: /^Last week, / }).waitFor();
    await owner.setViewportSize({ width: 390, height: 844 });
    await owner.waitForTimeout(400);
    const overflow = await owner.evaluate(() => document.documentElement.scrollWidth - window.innerWidth);
    assert.ok(overflow <= 1, `no sideways scroll on a phone (overflow ${overflow}px)`);
    await owner.screenshot({ path: `${OUT}/owner-review-5-phone.png`, fullPage: true });
    step('phone width: no sideways scrolling');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e) && !/Failed to load resource: the server responded with a status of 404/.test(e)), []);
    console.log('No console errors or page errors.');
  } catch (e) {
    console.error('FAILED: ' + (e && e.message));
    if (errors.length) console.error(errors.join('\n'));
    process.exitCode = 1;
  } finally {
    await browser.close();
    if (app) stopApp(app);
    if (pageServer) pageServer.close();
    project.stop();
    fs.rmSync(work, { recursive: true, force: true });
  }
})();
