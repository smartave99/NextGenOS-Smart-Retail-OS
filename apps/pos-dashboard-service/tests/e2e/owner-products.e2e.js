// End-to-end check of offering finished products to the owner's website, and of a shop with several PCs, in Chromium.
// The shop PC (the app on demo data, with stand-in-codex.js for the photos, the listing and the category) is connected to the
// owner's Supabase project, which is local-supabase.js: Supabase's own database image with cloud/supabase-owner-view.sql, and
// PostgREST, in Docker. The owner's website is played by SQL as the signed-in owner: it sends its categories, and it decides on
// each product waiting for it. Part 1 follows one product: its photos and listing are made; the website's categories reach the
// PC; the AI finds no fit, the owner chooses one; the product is offered with its listing, the POS's prices and its five photos
// (nothing else), waits, is approved (its photos leave the project at once), is offered again when its category changes (the
// photos do not go again), is declined, and is offered again at the owner's wish. Part 2 is a shop with two PCs: the first to
// connect is the main PC; a second one is a counter that cannot send; when the other PC takes the role, this one sends nothing,
// says which PC is the main one and shows a button that takes the role back.
//   npm install && npm run test:owner-products        (needs Docker and the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');
const supabase = require('./local-supabase');
const { png, phonePhoto } = require('./png');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);
const OWNER = '11111111-1111-1111-1111-111111111111';
const KINDS = ['white', 'in-use', 'european-model', 'indian-model', 'east-asian-model'];

// The website's categories: a main category and the subcategories under it, as the website's admin sends them.
const CATEGORIES = [
  { id: 'c-groc', name: 'Grocery', parentId: null },
  { id: 'c-rice', name: 'Rice & Pulses', parentId: 'c-groc' },
  { id: 'c-oils', name: 'Oils & Ghee', parentId: null },
  { id: 'c-must', name: 'Mustard Oil', parentId: 'c-oils' },
  { id: 'c-ghee', name: 'Ghee', parentId: 'c-oils' },
  { id: 'c-bev', name: 'Beverages', parentId: null },
  { id: 'c-tea', name: 'Tea', parentId: 'c-bev' },
];
const WITH_SUNFLOWER = [...CATEGORIES, { id: 'c-sun', name: 'Sunflower Oil', parentId: 'c-oils' }];

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-owner-products-'));
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));
const phoneFile = path.join(work, 'IMG_20260924_101500.png');
fs.writeFileSync(phoneFile, png(320, 320, phonePhoto));
// What the stand-in Codex files the product under: a word of the category's place (the test changes it), and a line for each time it was asked.
const categoryWord = path.join(work, 'category-word');
const categoryRuns = path.join(work, 'category-runs.jsonl');
const asked = () => fs.existsSync(categoryRuns) ? fs.readFileSync(categoryRuns, 'utf8').trim().split('\n').filter(Boolean).map(line => JSON.parse(line)) : [];

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile,
      STAND_IN_CODEX_DELAY_MS: '300',
      STAND_IN_CODEX_STATE: path.join(work, 'codex-listings'),
      STAND_IN_CODEX_CATEGORY_FILE: categoryWord,
      STAND_IN_CODEX_CATEGORY_LOG: categoryRuns,
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

async function until(check, timeout, what) {
  const end = Date.now() + timeout;
  for (;;) {
    if (await check()) return;
    if (Date.now() > end) throw new Error('Timed out waiting: ' + what);
    await new Promise(r => setTimeout(r, 500));
  }
}

(async () => {
  if (!supabase.hasDocker()) {
    console.log('Skipped: the products test needs Docker.');
    return;
  }

  const project = await supabase.start();
  let app;
  const browser = await chromium.launch();
  const errors = [];
  try {
    app = await startApp();
    const json = (sql) => JSON.parse(project.psql(sql) || 'null');
    const rows = () => json("select coalesce(jsonb_agg(to_jsonb(p) - 'shop_id' order by product_key), '[]'::jsonb) from public.shop_products p;");
    const photos = () => json("select coalesce(jsonb_agg(jsonb_build_object('kind', kind, 'mime', mime, 'size', char_length(content), 'start', left(content, 4)) order by kind), '[]'::jsonb) from public.shop_product_photos;");
    const devices = () => json("select coalesce(jsonb_agg(jsonb_build_object('label', label, 'main', is_main) order by connected_at), '[]'::jsonb) from public.shop_devices;");
    let shop;
    const sendCategories = (list) => project.asUser(OWNER, `select public.save_site_categories('${shop}', '${JSON.stringify(list)}'::jsonb);`);
    const decide = (state) => project.asUser(OWNER, `select public.decide_shop_product('${shop}', '6', '${state}');`);

    // The owner signs up on the website, creates the shop and makes a code.
    project.psql(`insert into auth.users (id, email) values ('${OWNER}', 'owner@example.com');`);
    shop = project.asUser(OWNER, "select public.create_shop('Demo Mart 99');");
    const code = project.asUser(OWNER, `select public.new_pairing_code('${shop}');`);

    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));
    const section = page.locator('.owner-view');
    const website = page.locator('#website-products');
    // Presses Look now and waits until a look at the waiting list is over (the page counts them in data-runs).
    const lookNow = async () => {
      await page.goto(BASE + '/settings');
      const before = Number(await website.getAttribute('data-runs'));
      await website.getByRole('button', { name: 'Look now' }).click();
      await page.waitForFunction(([selector, n]) => Number(document.querySelector(selector)?.getAttribute('data-runs')) > n, ['#website-products', before], { timeout: 90000 });
    };

    // --- Part 1: one product, from its photos to the website's waiting list.
    await page.goto(BASE + '/settings');
    await page.fill('#owner-url', project.url);
    await page.fill('#owner-key', project.anonKey);
    await page.fill('#owner-code', code);
    await section.getByRole('button', { name: 'Connect' }).click();
    await section.getByRole('heading', { name: 'Sending to Demo Mart 99' }).waitFor();
    await section.locator('.owner-state', { hasText: /Last sent at \d/ }).waitFor({ timeout: 30000 });
    assert.deepStrictEqual((await devices()).map(d => d.main), [true], 'the first PC to connect is the main PC');
    assert.strictEqual(await section.locator('#owner-counter').count(), 0, 'the main PC is not told it is a counter');
    step('connected: the first PC of the shop is its main PC');

    // Offering products is off until the owner turns it on, and nothing is offered before.
    await website.getByRole('heading', { name: 'Offer finished products to your website' }).waitFor();
    assert.strictEqual(await website.getByRole('radio', { name: 'On' }).getAttribute('aria-checked'), 'false');
    await website.getByRole('radio', { name: 'On' }).click();
    await website.getByRole('button', { name: 'Look now' }).waitFor();
    await website.locator('.website-line', { hasText: "Your website's categories have not reached this PC yet" }).waitFor();
    assert.deepStrictEqual(await rows(), [], 'nothing is offered before the owner turns it on');
    step('offering products is off by default; turned on, the PC says the website has not sent its categories');

    // The product's photos and listing are made, as in photos.e2e.js.
    await page.goto(BASE + '/photos', { waitUntil: 'networkidle' });
    await page.locator('table.data-table tbody tr').first().waitFor();
    await page.fill('.scan-input', 'sunflower');
    await page.waitForFunction(() => document.querySelectorAll('tbody tr').length === 1);
    await page.getByRole('link', { name: 'Add photos' }).click();
    await page.waitForURL(/\/photos\/6$/);
    await page.locator('.pill.good', { hasText: 'Ready' }).waitFor({ timeout: 60000 });
    await page.locator('input[type=file]').first().setInputFiles(phoneFile);
    await page.getByText('All 5 photos made').waitFor({ timeout: 120000 });
    const listing = page.locator('#listing');
    await listing.locator('.listing-title').waitFor({ timeout: 60000 });
    await listing.getByRole('tab', { name: 'Your website' }).click();
    const place = listing.locator('.website-category');
    await place.locator('.listing-value', { hasText: 'Oils & Ghee > Sunflower Oil' }).waitFor();
    await place.getByText("Your website's categories have not reached this PC yet").waitFor();
    assert.strictEqual(await place.locator('select').count(), 0);
    step("photos and listing made; the product page shows the AI's first guess and that the website's categories are not here yet");

    // The website's admin sends its categories; the Check again button reads them.
    sendCategories(CATEGORIES);
    await place.getByRole('button', { name: 'Check again' }).click();
    await place.locator('select#website-category').waitFor();
    await place.locator('.listing-value', { hasText: 'Not chosen yet' }).waitFor();
    assert.deepStrictEqual(await place.locator('select option').allInnerTexts(), [
      'Choose a category…', 'Grocery', 'Grocery › Rice & Pulses', 'Oils & Ghee', 'Oils & Ghee › Mustard Oil', 'Oils & Ghee › Ghee', 'Beverages', 'Beverages › Tea',
    ]);
    step("the website's categories reached the PC, a main category with its subcategories");

    // The AI chooses from that list only: the product is not a mustard oil or a ghee, and nothing in the list is sunflower oil.
    fs.writeFileSync(categoryWord, 'sunflower');
    await lookNow();
    await until(() => asked().length === 1, 30000, 'the AI to be asked for the category');
    assert.deepStrictEqual(asked()[0], { ids: CATEGORIES.map(c => c.id), picked: '' });
    await website.locator('.website-line', { hasText: '1 finished product needs a category of your website' }).waitFor();
    assert.deepStrictEqual(await rows(), [], 'a product without a category is not offered');
    await website.screenshot({ path: `${OUT}/owner-products-1-needs-category.png` });
    step('the AI was given only the website\'s own list and found no fit: the product waits for the owner and is not offered');

    // The owner chooses one on the product page.
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await listing.getByRole('tab', { name: 'Your website' }).click();
    await place.locator('.listing-value', { hasText: 'Not chosen yet' }).waitFor();
    await place.getByText('which is not one of your website\'s categories').waitFor();
    await place.locator('select#website-category').selectOption({ label: 'Oils & Ghee' });
    await place.locator('.listing-value', { hasText: /^Oils & Ghee$/ }).waitFor();
    await place.getByText('Chosen by you.').waitFor();
    await lookNow();
    await until(async () => (await rows()).length === 1 && (await rows())[0].state === 'waiting', 60000, 'the product to wait on the website\'s list');

    const [offered] = await rows();
    assert.strictEqual(offered.product_key, '6');
    assert.deepStrictEqual(offered.photo_kinds, KINDS);
    const data = offered.data;
    assert.strictEqual(data.name, 'Sunflower Oil 1 L Bottle, Light Refined Cooking Oil for Frying', 'the listing\'s one name, with the AI\'s claim taken out');
    assert.strictEqual(data.posName, 'Sunflower Oil 1 L');
    assert.deepStrictEqual([data.price, data.originalPrice], [155, 175], 'the prices are the POS\'s, not the AI\'s (it wrote ₹189)');
    assert.deepStrictEqual([data.categoryId, data.subcategoryId || ''], ['c-oils', '']);
    assert.ok(data.description.length > 20 && data.highlights.length === 3 && data.tags.length >= 2);
    assert.ok(!JSON.stringify(data).includes('189') && !/best seller|example\.com|#Sale/i.test(JSON.stringify(data)), 'what the AI slipped in is not offered');
    const allowed = ['name', 'description', 'price', 'originalPrice', 'highlights', 'specifications', 'key', 'value', 'tags', 'categoryId', 'subcategoryId', 'categoryPath', 'barcode', 'posName', 'code'];
    const names = new Set();
    JSON.stringify(data, (k, v) => { if (k && Number.isNaN(Number(k))) names.add(k); return v; });
    assert.deepStrictEqual([...names].filter(n => !allowed.includes(n)), [], 'only the listing, the prices and the place leave the PC');
    const sent = await photos();
    assert.deepStrictEqual(sent.map(p => p.kind).sort(), [...KINDS].sort());
    assert.ok(sent.every(p => p.mime === 'image/jpeg' && p.start === '/9j/' && p.size > 100 && p.size < 900000), JSON.stringify(sent));
    step('offered with the listing, the POS\'s prices and the five photos as small JPEGs, and waiting for the owner; nothing else left the PC');

    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await listing.getByRole('tab', { name: 'Your website' }).click();
    await listing.locator('.website-state .pill', { hasText: 'Waiting for you' }).waitFor();
    await listing.locator('.website-state-text', { hasText: 'Waiting for your approval on your website.' }).waitFor();
    await page.goto(BASE + '/settings');
    await website.locator('.owner-state', { hasText: '1 waiting for your approval' }).waitFor();
    await website.screenshot({ path: `${OUT}/owner-products-2-waiting.png` });
    step('the product page and Settings both say it waits for the owner\'s approval on the website');

    // The owner approves it on the website: the photos leave the project at once, and the PC does not offer it again.
    decide('published');
    assert.deepStrictEqual(await photos(), [], 'the photos are dropped when the owner decides');
    const publishedAt = (await rows())[0].sent_at;
    await lookNow();
    await website.locator('.owner-state', { hasText: '1 approved' }).waitFor();
    assert.deepStrictEqual([(await rows())[0].state, (await rows())[0].sent_at, (await photos()).length], ['published', publishedAt, 0], 'an approved product is not sent again');
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await listing.getByRole('tab', { name: 'Your website' }).click();
    await listing.locator('.website-state .pill.good', { hasText: 'On your website' }).waitFor();
    step('approved: its photos left the project, the PC says it is on the website and does not send it again');

    // The website's list gains "Sunflower Oil" under Oils & Ghee: the owner's choice stays, and the AI can choose again.
    sendCategories(WITH_SUNFLOWER);
    await lookNow();
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await listing.getByRole('tab', { name: 'Your website' }).click();
    await place.locator('.listing-value', { hasText: /^Oils & Ghee$/ }).waitFor();
    fs.writeFileSync(categoryWord, 'sunflower');
    await place.getByRole('button', { name: 'Let the AI choose again' }).click();
    await place.locator('.listing-value', { hasText: 'Oils & Ghee › Sunflower Oil' }).waitFor({ timeout: 30000 });
    await place.getByText('Chosen by the AI from your website\'s list.').waitFor();
    assert.deepStrictEqual(asked()[1], { ids: ['c-groc', 'c-rice', 'c-oils', 'c-must', 'c-ghee', 'c-sun', 'c-bev', 'c-tea'], picked: 'c-sun' });
    const versionBefore = (await rows())[0].version;
    const photosVersion = (await rows())[0].photos_version;
    await lookNow();
    await until(async () => (await rows())[0].state === 'waiting', 60000, 'the changed product to wait again');
    const [again] = await rows();
    assert.notStrictEqual(again.version, versionBefore, 'a changed category is a new version');
    assert.strictEqual(again.photos_version, photosVersion);
    assert.deepStrictEqual([again.data.categoryId, again.data.subcategoryId], ['c-oils', 'c-sun']);
    assert.deepStrictEqual(await photos(), [], 'the photos did not go again, they have not changed');
    step('a new category: the AI chose again from the new list, and the product is offered again for approval, without its photos');

    // The owner declines it; the PC says so and can offer it again, with its photos, at the owner's wish.
    decide('declined');
    await lookNow();
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await listing.getByRole('tab', { name: 'Your website' }).click();
    await listing.locator('.website-state .pill.bad', { hasText: 'Declined' }).waitFor();
    await lookNow();
    assert.strictEqual((await rows())[0].state, 'declined', 'a declined product stays declined');
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await listing.getByRole('tab', { name: 'Your website' }).click();
    await listing.getByRole('button', { name: 'Offer it again' }).click();
    await until(async () => (await rows())[0].state === 'waiting', 90000, 'the declined product to be offered again');
    assert.deepStrictEqual((await photos()).map(p => p.kind).sort(), [...KINDS].sort(), 'a declined product\'s photos are sent again');
    step('declined: it stays declined until the owner presses Offer it again, and then its photos go again');

    // --- Part 2: a shop with several PCs.
    const second = project.asUser(OWNER, `select public.new_pairing_code('${shop}');`);
    const counter = JSON.parse(project.psql(`select public.connect_shop_pc('${second}', 'Counter 2');`));
    const counterRole = JSON.parse(project.psql(`select public.get_shop_pc_role('${counter.key}');`));
    assert.strictEqual(counterRole.main, false);
    assert.ok(counterRole.main_label && counterRole.main_label !== 'Counter 2', 'the counter is told which PC is the main one');
    assert.deepStrictEqual((await devices()).map(d => d.main), [true, false]);
    assert.throws(() => project.psql(`select public.send_shop_report('${counter.key}', 'review', '{}'::jsonb);`), /is this shop's main PC/);
    assert.throws(() => project.psql(`select public.send_shop_product('${counter.key}', '7', '{}'::jsonb, '${'a'.repeat(32)}', '${'b'.repeat(32)}', array['white']);`), /is this shop's main PC/);
    step('a second PC joins as a counter: told which PC is the main one, and the project refuses what only the main PC may send');

    // The other PC takes the role: this PC sends nothing, and says so.
    project.psql(`select public.claim_main_pc('${counter.key}');`);
    await page.goto(BASE + '/settings');
    await section.getByRole('button', { name: 'Send now' }).click();
    const note = section.locator('#owner-counter');
    await note.waitFor({ timeout: 30000 });
    assert.ok((await note.innerText()).includes('Counter 2'), await note.innerText());
    assert.strictEqual(await website.count(), 0, 'a counter PC does not offer products');
    const lastSent = project.asUser(OWNER, 'select sent_at from public.shop_live;');
    const waitingBefore = JSON.stringify(await rows());
    await section.getByRole('button', { name: 'Send now' }).click();
    await page.waitForTimeout(3000);
    assert.strictEqual(project.asUser(OWNER, 'select sent_at from public.shop_live;'), lastSent, 'a counter PC sends no figures');
    assert.strictEqual(JSON.stringify(await rows()), waitingBefore, 'a counter PC offers no products');
    await section.screenshot({ path: `${OUT}/owner-products-3-counter.png` });
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await listing.getByRole('tab', { name: 'Your website' }).click();
    await listing.locator('.website-counter', { hasText: 'Counter 2' }).waitFor();
    step('the other PC took the role: this one sends nothing, says Counter 2 is the main PC, and its product page says the main PC offers products');

    // The owner presses the button on this PC: it is the main PC again, and sends at once.
    await page.goto(BASE + '/settings');
    await section.locator('#owner-counter').waitFor();
    await section.getByRole('button', { name: 'Make this the main PC' }).click();
    await section.locator('#owner-counter').waitFor({ state: 'detached', timeout: 30000 });
    await until(() => project.asUser(OWNER, 'select sent_at from public.shop_live;') !== lastSent, 30000, 'this PC to send its figures again');
    assert.deepStrictEqual((await devices()).map(d => d.main), [true, false], 'this PC is the main PC again, the other one a counter');
    assert.throws(() => project.psql(`select public.send_shop_report('${counter.key}', 'review', '{}'::jsonb);`), /is this shop's main PC/);
    await website.getByRole('heading', { name: 'Offer finished products to your website' }).waitFor();
    step('"Make this the main PC": this PC sends again at once, and the other PC is a counter');

    // The owner disconnects the main PC on the website: the next PC to ask becomes the main one.
    project.asUser(OWNER, "delete from public.shop_devices where label <> 'Counter 2';");
    const role = JSON.parse(project.psql(`select public.get_shop_pc_role('${counter.key}');`));
    assert.strictEqual(role.main, true, 'without a main PC, the next to ask becomes it');
    step('the main PC was disconnected on the website: the counter became the main PC when it asked');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e)), []);
    console.log('No console errors or page errors.');
  } catch (e) {
    console.error('FAILED: ' + (e && e.stack || e));
    process.exitCode = 1;
  } finally {
    await browser.close();
    if (app) stopApp(app);
    await project.stop();
    fs.rmSync(work, { recursive: true, force: true });
  }
})();
