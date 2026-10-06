// End-to-end check of product photos and storage, in Chromium. From one phone photo, five photos are made one by
// one; they can be stopped, continued, made again, changed with a note from the owner and downloaded; they follow the
// shape of the owner's photo (a tall phone photo gives tall photos); the page, the sidebar and the Product photos list say
// which photo is being made, what comes next and which products wait; the AI's brief learns what the product is; the
// listings for Amazon and the website are written once, checked, copied, downloaded, changed and written again; and
// the data moves to another folder chosen on the Storage page. It starts the app itself on demo data, with
// stand-in-codex.js in place of the real Codex CLI, then stops it:
//   npm install && npm run test:photos        (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');
const { writeShopProfile } = require('./shop-profile');
const { png, phonePhoto, photoNumber, changed } = require('./png');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-photos-'));
const firstFolder = path.join(work, 'data A');
const secondFolder = path.join(work, 'data B');
const productFolder = (root) => path.join(root, 'Product photos', '6 Sunflower Oil 1 L');

// A "codex" launcher for the stand-in, like the one npm installs, set up as the side panel would.
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: firstFolder }));

const phoneFile = path.join(work, 'IMG_20260924_101500.png');
fs.writeFileSync(phoneFile, png(320, 320, phonePhoto));
// A tall phone photo, 3:4: the picture of the oil bottle with room above and below.
const tallFile = path.join(work, 'IMG_20260925_080000.png');
fs.writeFileSync(tallFile, png(300, 400, (x, y) => phonePhoto(x, Math.max(0, Math.min(319, y - 40)))));
// While this file exists the stand-in Codex meets its usage limit (after as many photos as the file says).
const limitFile = path.join(work, 'codex-limit');
// What the stand-in Codex was asked for each photo (one line each), to check what the app sends.
const asked = path.join(work, 'codex-photos.jsonl');
const runs = () => fs.existsSync(asked) ? fs.readFileSync(asked, 'utf8').trim().split('\n').filter(Boolean).map(line => JSON.parse(line)) : [];
const kinds = ['white', 'in-use', 'european-model', 'indian-model', 'east-asian-model'];
const titles = ['White background', 'In use', 'European model', 'Indian model', 'East Asian model'];

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile, ...writeShopProfile(work),
      STAND_IN_CODEX_DELAY_MS: '1500',
      STAND_IN_CODEX_STATE: path.join(work, 'codex-listings'),
      STAND_IN_CODEX_PHOTOS_LOG: asked,
      STAND_IN_CODEX_LIMIT_FILE: limitFile,
    },
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

// Waits until every image matching the selector has loaded, then gives their widths.
async function loaded(page, selector) {
  await page.waitForFunction(s => [...document.querySelectorAll(s)].every(i => i.complete && i.naturalWidth > 0), selector);
  return page.locator(selector).evaluateAll(list => list.map(img => img.naturalWidth));
}

// The names of the files in a ZIP, read from its central directory.
function zipNames(zip) {
  const end = zip.lastIndexOf(Buffer.from([0x50, 0x4b, 0x05, 0x06]));
  let at = zip.readUInt32LE(end + 16);
  const names = [];
  for (let i = zip.readUInt16LE(end + 10); i > 0; i--) {
    const length = zip.readUInt16LE(at + 28);
    names.push(zip.toString('utf8', at + 46, at + 46 + length));
    at += 46 + length + zip.readUInt16LE(at + 30) + zip.readUInt16LE(at + 32);
  }
  return names;
}

async function fullPageShot(page, file) {
  await page.setViewportSize({ width: 1366, height: await page.evaluate(() => document.documentElement.scrollHeight) });
  await page.screenshot({ path: file });
  await page.setViewportSize({ width: 1366, height: 900 });
}

(async () => {
  const app = await startApp();
  // Chromium's stand-in camera, allowed without asking, for the photos taken on the product's page.
  const browser = await chromium.launch({ args: ['--use-fake-device-for-media-stream', '--use-fake-ui-for-media-stream'] });
  const errors = [];
  try {
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 }, acceptDownloads: true });
    await context.grantPermissions(['clipboard-read', 'clipboard-write'], { origin: BASE });
    const page = await context.newPage();
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    await page.goto(BASE + '/photos', { waitUntil: 'networkidle' });
    await page.locator('table.data-table tbody tr').first().waitFor();
    assert.ok((await page.locator('.storage-line').innerText()).includes(firstFolder));
    assert.ok((await page.locator('.panel-head').last().innerText()).includes('0 of 27 products have a photo'));
    await page.fill('.scan-input', 'sunflower');
    await page.waitForFunction(() => document.querySelectorAll('tbody tr').length === 1);
    await page.getByRole('link', { name: 'Add photos' }).click();
    await page.waitForURL(/\/photos\/6$/);
    await page.locator('h1', { hasText: 'Sunflower Oil 1 L' }).waitFor();
    await page.locator('.pill.good', { hasText: 'Ready' }).waitFor({ timeout: 60000 });
    step('photos list shows where photos are kept; on to the product; Codex is ready');

    await page.locator('input[type=file]').first().setInputFiles(phoneFile);
    await page.getByText('Making photo 1 of 5: White background').waitFor({ timeout: 30000 });
    // Which photo is being made, what comes next for this product, and how many photos are left, also in the sidebar.
    await page.locator('.steps-bar .what', { hasText: 'next: In use and 3 more' }).waitFor();
    const photosBadge = page.locator('.sidebar a.nav-item[href="photos"] .count.busy');
    await photosBadge.waitFor();
    assert.match((await photosBadge.innerText()).trim(), /^[1-5]$/);
    await page.locator('.slot[data-kind=white] img').waitFor({ timeout: 30000 });
    assert.strictEqual(await page.locator('.slot[data-kind=east-asian-model] img').count(), 0, 'all photos came at once');
    await page.locator('#listing .listing-status', { hasText: 'Writing the listings' }).waitFor({ timeout: 30000 });
    await page.locator('.steps-bar .what', { hasText: 'then In use photo' }).waitFor({ timeout: 30000 });
    await page.getByText('Making photo 2 of 5: In use').waitFor({ timeout: 30000 });
    step('one phone photo in: the photos start by themselves and come one by one, with the listings after the first');

    await page.getByText('All 5 photos made').waitFor({ timeout: 90000 });
    assert.deepStrictEqual(await loaded(page, '.photo-set img'), [320, 320, 320, 320, 320]);
    for (const [i, kind] of kinds.entries()) {
      const caption = await page.locator(`.slot[data-kind=${kind}] figcaption`).innerText();
      assert.ok(caption.includes(`${i + 1} · ${titles[i]}`) && caption.includes('320 × 320 px (small for Amazon zoom) · the shape of your photo (1:1)'), caption);
    }
    const seen = await page.locator('.understanding').innerText();
    for (const text of ['Sunflower Oil, 1 L Bottle', 'golden sunflower oil with a yellow cap', 'सूरजमुखी का तेल', 'a sunny kitchen counter while cooking', 'a woman in her early 30s'])
      assert.ok(seen.includes(text), 'description is missing: ' + text);
    await fullPageShot(page, `${OUT}/photo.png`);
    step('all five made, each with its size, and the AI says what the product is, where it is used and who uses it');

    // The listings, written once right after the white photo. What the AI slipped in (a price, a claim, a link and a
    // "sale" tag) is taken out and said so; the price, MRP and barcode come from the POS.
    const listing = page.locator('#listing');
    const firstTitle = 'Sunflower Oil 1 L Bottle, Light Refined Cooking Oil for Frying';
    await listing.locator('.listing-title', { hasText: firstTitle }).waitFor();
    assert.strictEqual(await listing.locator('.listing-title').innerText(), firstTitle);
    const bullets = await listing.locator('.listing-list li').allInnerTexts();
    assert.strictEqual(bullets.length, 5);
    assert.strictEqual(bullets[1], 'Easy grip: the 1 L bottle is easy to hold and pour.');
    assert.ok(!(await listing.innerText()).includes('189'), 'a price the AI wrote is shown');
    const notes = await listing.locator('.listing-notes').innerText();
    for (const note of ['Prices and offers were taken out', '“best seller”', 'Links, phone numbers and e-mail addresses'])
      assert.ok(notes.includes(note), 'missing note: ' + note);
    assert.ok((await listing.locator('.listing-field', { hasText: 'Search terms' }).innerText()).includes('surajmukhi tel kachi ghani'));
    assert.ok((await listing.locator('.listing-details').first().innerText()).includes('Not on the pack: fill in'), 'the brand could not be read, and says so');
    assert.ok((await listing.locator('.listing-name .listing-pos-name').innerText()).includes('In your POS this product is called “Sunflower Oil 1 L”.'), 'the POS name is not told apart from the one name');
    assert.strictEqual(await listing.locator('.listing-title').count(), 1, 'one name, not one for each tab');
    const pos = await listing.locator('.listing-pos').innerText();
    assert.ok(pos.includes('₹155.00') && pos.includes('₹175.00'), pos);
    assert.ok(pos.includes("The shop's own code"), 'an in-store code is called the maker\'s barcode');
    const barcode = (await listing.locator('.listing-pos .mono').innerText()).trim();
    await listing.getByRole('button', { name: 'Copy the name' }).click();
    await listing.getByRole('button', { name: 'Copy the name' }).filter({ hasText: 'Copied' }).waitFor();
    assert.strictEqual(await page.evaluate(() => navigator.clipboard.readText()), firstTitle);
    step('the listings: what the AI may not say is taken out, and the price and barcode come from the POS; parts copy');

    const [amazonFile] = await Promise.all([page.waitForEvent('download'), listing.getByRole('button', { name: 'Download for Amazon' }).click()]);
    assert.strictEqual(amazonFile.suggestedFilename(), 'Sunflower Oil 1 L - Amazon listing.txt');
    const amazonText = fs.readFileSync(await amazonFile.path(), 'utf8');
    for (const part of [`Title\n${firstTitle}\n`, '- Easy grip: the 1 L bottle is easy to hold and pour.\n', 'Price the customer pays: ₹155.00\nMRP: ₹175.00\n', `Barcode: ${barcode} (the shop's own code`])
      assert.ok(amazonText.includes(part), 'the Amazon file lacks: ' + part);
    await listing.getByRole('tab', { name: 'Your website' }).click();
    await listing.locator('.listing-tags').waitFor();
    assert.strictEqual(await listing.locator('.listing-title').innerText(), firstTitle, 'the website shows the same name as Amazon');
    assert.ok(!(await listing.innerText()).includes('example.com'), 'a link the AI wrote is shown');
    assert.deepStrictEqual(await listing.locator('.listing-tags .pill').allInnerTexts(), ['sunflower oil', 'cooking oil', 'refined oil']);
    const [siteFile] = await Promise.all([page.waitForEvent('download'), listing.getByRole('button', { name: 'Download for the website' }).click()]);
    assert.strictEqual(siteFile.suggestedFilename(), 'Sunflower Oil 1 L - website listing.json');
    const site = JSON.parse(fs.readFileSync(await siteFile.path(), 'utf8').replace(/^\uFEFF/, ''));
    assert.strictEqual(site.name, firstTitle, 'the website file carries the one name');
    assert.strictEqual(site.price, 155);
    assert.strictEqual(site.originalPrice, 175);
    assert.strictEqual(site.barcode, barcode);
    assert.deepStrictEqual(site.highlights, ['Light and golden', 'Easy-grip 1 L bottle', 'For cooking and frying']);
    assert.deepStrictEqual(site.images, titles.map((t, i) => `Sunflower Oil 1 L - ${i + 1} ${t}.png`));
    step('downloads: text for Amazon, and JSON in the website\'s product fields, with the POS price and barcode');

    const zipHref = await page.getByRole('link', { name: 'Download all' }).getAttribute('href');
    const zip = await page.request.get(BASE + '/' + zipHref);
    assert.strictEqual(zip.status(), 200);
    assert.deepStrictEqual(zipNames(await zip.body()),
      [...titles.map((t, i) => `Sunflower Oil 1 L - ${i + 1} ${t}.png`), 'Sunflower Oil 1 L - Amazon listing.txt', 'Sunflower Oil 1 L - website listing.json']);
    const one = await page.request.get(BASE + '/' + await page.locator('.slot[data-kind=in-use] a[download]').getAttribute('href'));
    assert.match(one.headers()['content-disposition'] || '', /Sunflower Oil 1 L - 2 In use\.png/);
    assert.ok(Buffer.compare(await one.body(), png(320, 320, photoNumber[2])) === 0, 'the downloaded photo is the one Codex made');
    for (const bad of ['product.json', '..%2F..%2Fsettings.json', 'raw-20260924-101500.exe', 'white-20260924-101500.png%2F..%2F..%2Fproduct.json'])
      assert.strictEqual((await page.request.get(`${BASE}/product-photos/6/${bad}`)).status(), 404, 'served: ' + bad);
    assert.strictEqual((await page.request.get(`${BASE}/product-photos/7/all.zip`)).status(), 404);
    const files = fs.readdirSync(productFolder(firstFolder)).sort().join(' ');
    assert.match(files, /^east-asian-model-\S+\.png european-model-\S+\.png in-use-\S+\.png indian-model-\S+\.png product\.json raw-\S+\.png white-\S+\.png$/);
    step('ZIP (with the listings) and single downloads carry readable names; only photos the store made are served');

    // Changed by hand: held to the same rules; the earlier version can come back; Write again writes a new one.
    await listing.getByRole('tab', { name: 'Amazon' }).click();
    await listing.getByRole('button', { name: 'Edit' }).click();
    await listing.getByLabel('Name on your website and Amazon').fill('Fortune Sunflower Oil 1 L Bottle');
    await listing.getByLabel('Brand').fill('Fortune');
    await listing.getByLabel('Bullet point 5').fill('Store well: keep it cool. Call 98765 43210 to order.');
    await listing.getByRole('button', { name: 'Save' }).click();
    await listing.locator('.listing-message', { hasText: 'Saved. Links, phone numbers and e-mail addresses were taken out.' }).waitFor();
    assert.strictEqual((await listing.locator('.listing-list li').allInnerTexts())[4], 'Store well: keep it cool.');
    assert.strictEqual(await listing.locator('.listing-title').innerText(), 'Fortune Sunflower Oil 1 L Bottle', 'the name you wrote is the name of both');
    await listing.getByRole('tab', { name: 'Your website' }).click();
    assert.strictEqual(await listing.locator('.listing-title').innerText(), 'Fortune Sunflower Oil 1 L Bottle');
    await listing.getByRole('tab', { name: 'Amazon' }).click();
    await listing.locator('.listing-field', { hasText: 'Search terms' }).waitFor();
    assert.ok((await listing.locator('.listing-details').first().innerText()).includes('Fortune'));
    assert.ok((await listing.locator('.listing-meta').innerText()).includes('changed by you'));
    await listing.locator('.listing-earlier summary', { hasText: 'Earlier versions (1)' }).click();
    await listing.getByRole('button', { name: 'Use this one' }).click();
    await listing.locator('.listing-message', { hasText: 'The earlier version is back' }).waitFor();
    assert.ok(!(await listing.locator('.listing-details').first().innerText()).includes('Fortune'));
    await listing.getByRole('button', { name: 'Write again' }).click();
    await listing.locator('.listing-status', { hasText: 'Writing the listings' }).waitFor();
    await listing.locator('.listing-title', { hasText: 'Sunflower Oil 1 L, Light Cooking Oil for Everyday Frying' }).waitFor({ timeout: 30000 });
    assert.strictEqual(await listing.locator('.listing-earlier summary').innerText(), 'Earlier versions (2)');
    const kept = JSON.parse(fs.readFileSync(path.join(productFolder(firstFolder), 'product.json'), 'utf8'));
    assert.strictEqual(kept.Listing.Amazon.Title, 'Sunflower Oil 1 L, Light Cooking Oil for Everyday Frying');
    assert.strictEqual(kept.Listing.DisplayName, kept.Listing.Amazon.Title);
    assert.strictEqual(kept.Listing.Website.Name, kept.Listing.Amazon.Title);
    assert.strictEqual(kept.Name, 'Sunflower Oil 1 L', 'the POS name is left as it is');
    assert.strictEqual(kept.EarlierListings.length, 2);
    await fullPageShot(page, `${OUT}/photo-listing.png`);
    step('the listings are changed by hand under the same rules, taken back, written again, and kept in product.json');

    await page.locator('.slot[data-kind=european-model] button', { hasText: 'Make again' }).click();
    await page.getByText('Making photo 3 of 5: European model').waitFor();
    await page.getByRole('button', { name: 'Stop' }).click();
    await page.getByText('Stopped at photo 3: European model').waitFor();
    await page.getByRole('button', { name: 'Continue' }).click();
    await page.getByText('All 5 photos made').waitFor({ timeout: 30000 });
    await page.locator('h2', { hasText: 'Earlier photos' }).waitFor();
    assert.strictEqual(await page.locator('.panel:has(h2:text("Earlier photos")) img').count(), 1);
    step('made again: stopped half-way, continued, and the earlier version is kept');

    // Change one photo with a short note: the photo made before goes to the AI together with what the owner wrote (a quote
    // mark becomes an apostrophe), the new photo says what was changed, and the earlier ones are kept.
    const inUse = page.locator('.slot[data-kind=in-use]');
    assert.strictEqual(await page.locator('.slot[data-kind=east-asian-model] button', { hasText: 'Change it' }).count(), 1, 'every made photo can be changed');
    await inUse.getByRole('button', { name: 'Change it' }).click();
    const changeForm = page.getByRole('form', { name: 'Change the In use photo' });
    const makeChange = changeForm.getByRole('button', { name: 'Change photo' });
    assert.strictEqual(await makeChange.isDisabled(), true, 'nothing is asked until something is written');
    const note = 'make the bottle "bigger" and the light warmer';
    // The note is compulsory (nothing is asked without it): its label has a star.
    assert.strictEqual(await changeForm.locator('label .req').count(), 1, 'the note is compulsory');
    assert.strictEqual(await changeForm.locator('textarea').getAttribute('aria-required'), 'true');
    await changeForm.getByLabel('What to change in the In use photo').fill(note);
    // The words go to the page as they are typed, and the button wakes up when they arrive.
    await page.waitForFunction(() => !document.querySelector('form.slot-change button[type=submit]').disabled);
    assert.ok((await changeForm.innerText()).includes('Text, prices and offers are never added.'));
    await page.screenshot({ path: `${OUT}/photo-change.png` });
    await makeChange.click();
    await page.getByText('Making photo 2 of 5: In use').waitFor();
    await page.getByText('All 5 photos made').waitFor({ timeout: 30000 });
    await inUse.locator('.slot-note', { hasText: "Changed: “make the bottle 'bigger' and the light warmer”" }).waitFor();
    const changes = runs().filter(run => run.change !== null);
    assert.deepStrictEqual(changes, [{ n: 2, change: "make the bottle 'bigger' and the light warmer", first: 'previous-photo.png', orientation: 'square', ratio: '1:1', shown: '320x320', toolSize: '1024 x 1024 (square)' }]);
    const changedBody = await (await page.request.get(BASE + '/' + await inUse.locator('a[download]').getAttribute('href'))).body();
    assert.ok(Buffer.compare(changedBody, png(320, 320, (x, y) => changed(photoNumber[2](x, y)))) === 0, 'the photo shown is the changed one');
    assert.strictEqual(await page.locator('.panel:has(h2:text("Earlier photos")) img').count(), 2, 'the photo before the change is kept, with the one made again earlier');
    assert.strictEqual(await page.locator('.slot[data-kind=european-model] .slot-note').count(), 0, 'a photo made again without a note says nothing was changed');
    await page.locator('.slot[data-kind=white] button', { hasText: 'Change it' }).click();
    await page.getByRole('button', { name: 'Cancel' }).click();
    await page.getByRole('form', { name: 'Change the White background photo' }).waitFor({ state: 'detached' });
    await fullPageShot(page, `${OUT}/photo-changed.png`);
    step('one photo changed with a note: the photo before goes with it, the note is shown, the earlier photos are kept');

    await page.goto(BASE + '/plan', { waitUntil: 'networkidle' });
    await page.locator('details.brief pre').waitFor({ state: 'attached' });
    assert.ok((await page.locator('details.brief pre').textContent()).includes('Sunflower Oil 1 L (a 1 litre plastic bottle of golden sunflower oil with a yellow cap)'));
    step('the AI brief says what Sunflower Oil 1 L is');

    await page.goto(BASE + '/photos?view=with', { waitUntil: 'networkidle' });
    await page.locator('tbody img.thumb').first().waitFor();
    assert.strictEqual(await page.locator('tbody tr').count(), 1);
    assert.strictEqual(await page.locator('tbody td.status-col .pill.good').innerText(), '5 of 5');
    step('photos list: the thumbnail and "5 of 5"');

    await page.goto(BASE + '/storage', { waitUntil: 'networkidle' });
    await page.locator('#current-folder').waitFor();
    assert.strictEqual((await page.locator('#current-folder').innerText()).trim(), firstFolder);
    assert.ok(await page.locator('.drive-list li').count() >= 1, 'drives are listed');
    assert.ok((await page.locator('.folder-stats').innerText()).includes('products with photos'));
    // The folder must be given: its label has a star and the field is announced as required.
    assert.strictEqual(await page.locator('label[for="data-folder"] .req').count(), 1, 'the folder is compulsory');
    assert.strictEqual(await page.locator('#data-folder').getAttribute('aria-required'), 'true');
    await page.fill('#data-folder', 'relative/folder');
    await page.getByRole('button', { name: 'Check' }).click();
    assert.match(await page.locator('.check-result').innerText(), /full path/);
    await page.fill('#data-folder', secondFolder);
    await page.getByRole('button', { name: 'Check' }).click();
    assert.match(await page.locator('.check-result').innerText(), /Can be used: .* free there\. .* of photos and plans will be moved\./);
    await fullPageShot(page, `${OUT}/storage.png`);
    await page.getByRole('button', { name: 'Move my data here' }).click();
    await page.getByText(/Moved \d+ files/).waitFor({ timeout: 30000 });
    assert.strictEqual((await page.locator('#current-folder').innerText()).trim(), secondFolder);
    assert.strictEqual(fs.readdirSync(productFolder(secondFolder)).length, files.split(' ').length + 2, 'every file moved, with the photo made again and the one changed since');
    assert.ok(!fs.existsSync(path.join(firstFolder, 'Product photos')), 'the old copies are deleted');
    assert.strictEqual(JSON.parse(fs.readFileSync(path.join(work, 'storage.json'), 'utf8')).DataFolder, secondFolder);
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    assert.deepStrictEqual(await loaded(page, '.photo-set img'), [320, 320, 320, 320, 320]);
    await page.locator('#listing .listing-title', { hasText: 'Sunflower Oil 1 L, Light Cooking Oil for Everyday Frying' }).waitFor();
    step('Storage: the data moved to another folder, and the photos and listings are shown from there');

    // Photos taken with the camera: three taken, one removed, Done. They start a new set of five; the listings stay
    // as written, and say that new photos came after them.
    await page.getByRole('button', { name: 'Take photos' }).first().click();
    const camera = page.getByRole('dialog', { name: 'Photos of Sunflower Oil 1 L' });
    for (let i = 0; i < 3; i++) {
      await camera.getByRole('button', { name: 'Take photo' }).click({ timeout: 20000 });
      await camera.getByRole('button', { name: 'Keep photo' }).click();
    }
    await camera.getByRole('button', { name: 'Remove photo 2' }).click();
    await camera.getByRole('button', { name: 'Remove photo 3' }).waitFor({ state: 'detached' });
    assert.strictEqual(await camera.locator('.camera-shot').count(), 2);
    await page.screenshot({ path: `${OUT}/photo-camera.png` });
    await camera.getByRole('button', { name: 'Done (2)' }).click();
    await camera.waitFor({ state: 'detached' });
    assert.strictEqual(await page.evaluate(() => window.srposCamera.running()), 0, 'the camera is off once Done is pressed');
    await page.getByText('Making photo 1 of 5: White background').waitFor({ timeout: 30000 });
    await page.getByText('All 5 photos made').waitFor({ timeout: 90000 });
    assert.strictEqual(await page.locator('.below .raw-strip img.raw').count(), 2);
    const cameraPhotos = fs.readdirSync(productFolder(secondFolder)).filter(f => /^raw-.*\.jpg$/.test(f));
    assert.strictEqual(cameraPhotos.length, 2, 'the camera photos are kept as JPEG files');
    await page.locator('#listing .listing-message', { hasText: 'New photos were added after these were written' }).waitFor();
    step('photos taken with the camera start a new set; the listings stay, and say that new photos came');

    // A phone photo added by mistake can be removed, also while the AI is making the photos from it; so can a whole set.
    const rawFiles = () => fs.readdirSync(productFolder(secondFolder)).filter(f => /^raw-/.test(f));
    const phoneFilesBefore = rawFiles().length;
    const removePhoto = page.getByRole('button', { name: 'Remove this phone photo' });
    const removing = page.getByRole('alertdialog', { name: 'Remove this photo?' });
    const deleting = page.getByRole('alertdialog', { name: 'Delete this set of photos?' });
    await page.locator('input[type=file]').first().setInputFiles([phoneFile, phoneFile]);
    await page.getByText('Making photo 1 of 5: White background').waitFor({ timeout: 30000 });
    assert.strictEqual(await page.locator('.below .raw-strip img.raw').count(), 2);
    assert.strictEqual(rawFiles().length, phoneFilesBefore + 2);
    await removePhoto.nth(1).click();
    await removing.waitFor();
    assert.ok((await removing.innerText()).includes('The photo being made now starts again without it.'), await removing.innerText());
    await page.screenshot({ path: `${OUT}/photo-remove.png` });
    await removing.getByRole('button', { name: 'Keep it' }).click();
    await removing.waitFor({ state: 'detached' });
    assert.strictEqual(rawFiles().length, phoneFilesBefore + 2, '"Keep it" keeps the photo');
    await removePhoto.nth(1).click();
    await removing.getByRole('button', { name: 'Remove the photo' }).click();
    await page.locator('.plan-error', { hasText: 'Photo removed. The photo being made starts again without it.' }).waitFor();
    assert.strictEqual(await page.locator('.below .raw-strip img.raw').count(), 1);
    assert.strictEqual(rawFiles().length, phoneFilesBefore + 1, 'the photo is deleted from this PC');
    step('a phone photo added by mistake is removed after asking, while the AI is making the photos; the file is deleted');

    await page.getByText('All 5 photos made').waitFor({ timeout: 120000 });
    await removePhoto.first().click();
    assert.ok((await removing.innerText()).includes('removing it deletes the whole set'), await removing.innerText());
    await removing.getByRole('button', { name: 'Keep it' }).click();
    await page.getByRole('button', { name: 'Delete this set of photos' }).click();
    await deleting.waitFor();
    await deleting.getByRole('button', { name: 'Delete the set' }).click();
    await page.locator('.plan-error', { hasText: 'The set of photos was deleted.' }).waitFor();
    assert.strictEqual(await page.locator('.below .raw-strip img.raw').count(), 2, 'the earlier set, with its two camera photos, is the newest again');
    assert.strictEqual(rawFiles().length, phoneFilesBefore, 'only the deleted set’s phone photos went');
    step('a whole set is deleted, with the photos made from it; the earlier set is the newest again');

    await page.locator('input[type=file]').first().setInputFiles(phoneFile);
    await page.getByText('Making photo 1 of 5: White background').waitFor({ timeout: 30000 });
    await page.getByRole('button', { name: 'Delete this set of photos' }).click();
    await deleting.getByRole('button', { name: 'Delete the set' }).click();
    await page.locator('.plan-error', { hasText: 'The set of photos was deleted.' }).waitFor();
    const madeFiles = () => fs.readdirSync(productFolder(secondFolder)).filter(f => /^(white|in-use|european-model|indian-model|east-asian-model)-/.test(f)).length;
    const madeAfterDeleting = madeFiles();
    await page.waitForTimeout(4000);
    assert.strictEqual(await page.getByText(/Making photo \d of 5/).count(), 0, 'the AI does not carry on with a deleted set');
    assert.strictEqual(madeFiles(), madeAfterDeleting, 'no photo comes for a deleted set');
    assert.strictEqual(rawFiles().length, phoneFilesBefore);
    assert.strictEqual(await page.locator('.below .raw-strip img.raw').count(), 2);
    step('a set deleted while the AI is making its photos stops the work, and no photo comes for it');

    await page.locator('input[type=file]').first().setInputFiles({ name: 'note.jpg', mimeType: 'image/jpeg', buffer: Buffer.from('not a photo at all') });
    await page.locator('.plan-error', { hasText: 'note.jpg is not a JPG, PNG or WEBP photo.' }).waitFor();
    step('a file that only looks like a photo by its name is refused');

    // Photos follow the shape of the owner's photo. Sugar's photos are made first; the tall photo of the oil comes after, and the
    // page, the sidebar and the Product photos list say which photo is being made, what comes next and which products wait.
    await page.goto(BASE + '/photos?view=all', { waitUntil: 'networkidle' });
    await page.fill('.scan-input', 'sugar');
    await page.waitForFunction(() => document.querySelectorAll('tbody tr').length === 1);
    await page.getByRole('link', { name: 'Add photos' }).click();
    await page.waitForURL(/\/photos\/\d+$/);
    await page.locator('input[type=file]').first().setInputFiles(phoneFile);
    await page.getByText('Making photo 1 of 5: White background').waitFor({ timeout: 30000 });
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await page.locator('input[type=file]').first().setInputFiles(tallFile);
    const waitingBar = page.locator('.steps-bar .what', { hasText: 'Waiting for its turn' });
    await waitingBar.waitFor({ timeout: 30000 });
    assert.ok((await waitingBar.innerText()).includes('now making Sugar 1 kg: '), await waitingBar.innerText());
    assert.ok((await waitingBar.innerText()).includes('· next'), 'it is next in the queue');
    await page.locator('.sidebar a.nav-item[href="photos"]').click();
    const queue = page.locator('section.photo-queue');
    await queue.waitFor();
    // The panel and the sidebar's number are read together: a photo may be finished between two reads.
    const { queueText, badge } = await page.evaluate(() => ({
      queueText: document.querySelector('section.photo-queue').innerText,
      badge: document.querySelector('.sidebar a.nav-item[href="photos"] .count.busy')?.innerText.trim(),
    }));
    assert.ok(queueText.includes('Making photos') && queueText.includes('Sugar 1 kg') && /photo \d of 5, |writing the listings/.test(queueText), queueText);
    assert.ok(/Waiting after it:/.test(queueText) && queueText.includes('Sunflower Oil 1 L') && queueText.includes('5 photos'), queueText);
    const left = Number(/(\d+) photos? left/.exec(queueText)[1]);
    assert.ok(left >= 6 && left <= 10, 'photos left: ' + left);
    assert.strictEqual(badge, String(left), 'the sidebar says the same');
    await queue.screenshot({ path: `${OUT}/photo-queue.png` });
    await page.setViewportSize({ width: 390, height: 800 });
    assert.ok(await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth) <= 0, 'the queue fits a phone');
    await page.screenshot({ path: `${OUT}/photo-queue-phone.png`, fullPage: true });
    await page.setViewportSize({ width: 1366, height: 900 });
    await queue.getByRole('link', { name: 'Sunflower Oil 1 L' }).click();
    await page.waitForURL(/\/photos\/6$/);
    await page.getByText('All 5 photos made').waitFor({ timeout: 120000 });
    assert.deepStrictEqual(await loaded(page, '.photo-set img'), [320, 320, 320, 320, 320]);
    const tallSizes = await page.locator('.photo-set img').evaluateAll(list => list.map(img => [img.naturalWidth, img.naturalHeight]));
    assert.deepStrictEqual(tallSizes, Array(5).fill([320, 427]), 'the tool made 320 x 480; it is trimmed from the middle to the 3:4 of the owner\'s photo');
    for (const kind of kinds) {
      const caption = await page.locator(`.slot[data-kind=${kind}] figcaption`).innerText();
      assert.ok(caption.includes('320 × 427 px (small for Amazon zoom) · the shape of your photo (3:4)'), caption);
    }
    const tall = runs().filter(run => run.shown === '300x400');
    assert.deepStrictEqual(tall.map(run => run.n), [1, 2, 3, 4, 5]);
    assert.ok(tall.every(run => run.orientation === 'portrait' && run.ratio === '3:4' && run.toolSize === '1024 x 1536 (tall)' && run.change === null), JSON.stringify(tall));
    await fullPageShot(page, `${OUT}/photo-tall.png`);
    await page.locator('.sidebar a.nav-item[href="photos"]').click();
    await page.locator('h1').waitFor();
    await page.locator('section.photo-queue').waitFor({ state: 'detached', timeout: 10000 });
    await page.locator('.sidebar .count.busy').waitFor({ state: 'detached', timeout: 10000 });
    step('photos follow the shape of the owner\'s photo (tall gives tall, trimmed from the middle); the page, the sidebar and the list say what is made now, what is next and who waits');

    // Codex's usage limit: nothing fails and nobody presses Continue. The photos made stay, the one that met the limit waits with the
    // rest and says when it carries on by itself, and once the limit has lifted the work goes on from the photo it stopped at.
    const runsBeforeLimit = runs().length;
    fs.writeFileSync(limitFile, '2');
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await page.locator('input[type=file]').first().setInputFiles(phoneFile);
    const paused = page.locator('.steps-bar .what', { hasText: 'Paused: Codex' });
    await paused.waitFor({ timeout: 60000 });
    const pausedText = await paused.innerText();
    assert.ok(/it carries on by itself at (tomorrow )?\d{1,2}:\d{2}/i.test(pausedText) && pausedText.includes('from photo 3: European model'), pausedText);
    assert.strictEqual(await page.locator('.slot[data-kind=white] img').count(), 1);
    assert.strictEqual(await page.locator('.slot[data-kind=in-use] img').count(), 1);
    assert.strictEqual(await page.locator('.slot[data-kind=european-model] img').count(), 0);
    assert.strictEqual(await page.getByText('Stopped at photo').count(), 0, 'a usage limit is not a failure');
    assert.strictEqual(await page.locator('.plan-error.trend-down').count(), 0, 'a problem is shown');
    assert.strictEqual(await page.getByRole('button', { name: 'Continue' }).count(), 0, 'nobody has to press Continue');
    await page.getByRole('button', { name: 'Try now' }).waitFor();
    await page.getByRole('button', { name: 'Stop', exact: true }).waitFor();
    await page.screenshot({ path: `${OUT}/photo-paused.png` });
    await page.reload({ waitUntil: 'networkidle' });
    await paused.waitFor();
    const pausedBadge = page.locator('.sidebar a.nav-item[href="photos"] .count.busy.paused');
    await pausedBadge.waitFor();
    assert.ok((await pausedBadge.getAttribute('title')).includes("Codex's usage limit was reached"));
    await page.locator('.sidebar a.nav-item[href="photos"]').click();
    const pausedPanel = page.locator('section.photo-queue.paused');
    await pausedPanel.waitFor();
    const panelText = await pausedPanel.innerText();
    assert.ok(panelText.includes('Photos paused') && panelText.includes('carry on by themselves at') && panelText.includes('Sunflower Oil 1 L'), panelText);
    await pausedPanel.screenshot({ path: `${OUT}/photo-paused-panel.png` });
    step('Codex’s usage limit is not a failure: the photos made stay, the rest waits and says when it carries on by itself');

    // The limit lifts: the work goes on from photo 3 (a press of Try now stands in for the time coming).
    fs.rmSync(limitFile);
    await pausedPanel.getByRole('button', { name: 'Try now' }).click();
    await pausedPanel.waitFor({ state: 'detached', timeout: 60000 });
    await page.goto(BASE + '/photos/6', { waitUntil: 'networkidle' });
    await page.getByText('All 5 photos made').waitFor({ timeout: 60000 });
    assert.deepStrictEqual(runs().slice(runsBeforeLimit).map(run => run.n), [1, 2, 3, 4, 5], 'the photos made before the limit are not made again');
    assert.strictEqual(await page.locator('.photo-set .slot img').count(), 5);
    step('after the limit lifts the work goes on from photo 3, without making photo 1 and 2 again');

    await page.setViewportSize({ width: 390, height: 800 });
    for (const route of ['/photos', '/photos/6', '/storage']) {
      await page.goto(BASE + route, { waitUntil: 'networkidle' });
      await page.locator('h1').waitFor();
      await page.waitForTimeout(300);
      // The page, and any table inside it, must fit the screen.
      const overflow = await page.evaluate(() => Math.max(...[document.documentElement, ...document.querySelectorAll('.table-wrap')]
        .map(e => e.scrollWidth - e.clientWidth)));
      assert.ok(overflow <= 0, `sideways scrolling on ${route} at phone width: ${overflow}px`);
      await page.screenshot({ path: `${OUT}/phone${route.replaceAll('/', '-')}.png`, fullPage: true });
    }
    step('phone width: no sideways scrolling on the photo and storage pages');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e)), []);
    console.log('No console or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
    fs.rmSync(work, { recursive: true, force: true });
  }
})().catch(e => { console.error(e); process.exit(1); });
