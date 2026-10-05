// End-to-end check of the one-click Google Lens search with a product's own photo, in Chromium, on the demo shop. The
// link opens a small page of the dashboard in the browser; that page makes the photo smaller, draws it again (which drops
// the place and camera details a phone puts in a photo) and sends it to Google as a form. Google is stood in for here: the
// test answers the request itself and keeps what was sent, so nothing leaves this PC and what Google would receive can be
// checked: one multipart form, the file in "encoded_image", a JPEG of at most 1600 pixels without EXIF, nothing else, and
// nothing sent twice by itself. Without a photo there is nothing to send. It starts the app itself on demo data, with
// stand-in-codex.js making the product photos, then stops it:
//   npm install && npm run test:lens        (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');
const { png, phonePhoto } = require('./png');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-lens-'));
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: path.join(work, 'data') }));

const OIL = { id: 6, name: 'Sunflower Oil 1 L' };
const RICE = { id: 1, name: 'Basmati Rice 5 kg' };

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile,
      STAND_IN_CODEX_DELAY_MS: '100',
      STAND_IN_CODEX_STATE: path.join(work, 'codex-listings'),
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

/** The size of a JPEG, from its first frame header. */
function jpegSize(bytes) {
  let at = 2;
  while (at + 9 < bytes.length) {
    if (bytes[at] !== 0xff) { at++; continue; }
    const marker = bytes[at + 1];
    if (marker >= 0xc0 && marker <= 0xcf && ![0xc4, 0xc8, 0xcc].includes(marker)) {
      return { height: bytes.readUInt16BE(at + 5), width: bytes.readUInt16BE(at + 7) };
    }
    at += 2 + bytes.readUInt16BE(at + 2);
  }
  throw new Error('no frame header in the JPEG');
}

/** The parts of a multipart form: name, file name, type and bytes of each. */
function parts(body, contentType) {
  const boundary = Buffer.from('--' + /boundary=(?:"([^"]+)"|([^;]+))/.exec(contentType).slice(1).find(Boolean));
  const found = [];
  let at = body.indexOf(boundary);
  while (at >= 0) {
    const next = body.indexOf(boundary, at + boundary.length);
    if (next < 0) break;
    const part = body.subarray(at + boundary.length + 2, next - 2);
    const split = part.indexOf('\r\n\r\n');
    const head = part.subarray(0, split).toString('latin1');
    found.push({
      name: /name="([^"]*)"/.exec(head)?.[1],
      filename: /filename="([^"]*)"/.exec(head)?.[1],
      type: /Content-Type: ([^\r\n]+)/i.exec(head)?.[1],
      bytes: part.subarray(split + 4),
    });
    at = next;
  }
  return found;
}

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 } });

    // Google is stood in for: what it is sent is kept, and the answer is a plain page.
    const posts = [];
    await context.route('https://lens.google.com/**', async route => {
      const request = route.request();
      posts.push({ method: request.method(), url: request.url(), type: request.headers()['content-type'] || '', body: request.postDataBuffer() });
      await route.fulfill({ status: 200, contentType: 'text/html; charset=utf-8', body: '<!doctype html><h1 id="results">Stand-in Google Lens results</h1>' });
    });
    const watch = (page) => {
      page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
      page.on('pageerror', e => errors.push(e.message));
    };

    const page = await context.newPage();
    watch(page);

    // Without a photo there is nothing to search with: no link, and the page says so and sends nothing.
    await page.goto(`${BASE}/photos/${RICE.id}`, { waitUntil: 'networkidle' });
    await page.locator('h1', { hasText: RICE.name }).waitFor();
    const none = page.locator('.page-head .actions .disabled', { hasText: 'Google Lens' });
    assert.strictEqual(await none.getAttribute('aria-disabled'), 'true');
    assert.strictEqual(await page.getByRole('link', { name: 'Google Lens', exact: true }).count(), 0);
    const missing = await page.goto(`${BASE}/lens/${RICE.id}`);
    assert.strictEqual(missing.status(), 404);
    assert.ok((await page.locator('h1').innerText()).includes('No photo to search with'));
    assert.ok((await page.content()).includes(RICE.name));
    assert.strictEqual(await page.locator('a[href="/photos/1"]').count(), 1);
    assert.strictEqual(posts.length, 0, 'nothing is sent when there is no photo');
    step('a product without a photo has no Lens link, and its Lens page says so and sends nothing');

    // A phone photo, bigger than Google needs (2400 × 1600).
    const phone = path.join(work, 'phone.png');
    fs.writeFileSync(phone, png(2400, 1600, (x, y) => phonePhoto(x / 6, y / 6)));
    await page.goto(`${BASE}/photos/${OIL.id}`, { waitUntil: 'networkidle' });
    await page.locator('h1', { hasText: OIL.name }).waitFor();
    await page.locator('input[type=file]').first().setInputFiles(phone);
    await page.getByText('All 5 photos made').waitFor({ timeout: 90000 });

    // The product's page: one Lens button, and one on each phone photo.
    const header = page.getByRole('link', { name: 'Google Lens', exact: true });
    assert.strictEqual(await header.getAttribute('href'), `lens/${OIL.id}`);
    assert.strictEqual(await header.getAttribute('target'), '_blank');
    assert.ok((await header.getAttribute('rel')).includes('noopener'));
    const rawName = (await page.locator('img.raw').first().getAttribute('src')).split('/').pop();
    assert.match(rawName, /^raw-\d{8}-\d{6}/);
    const tile = page.locator('.raw-tile a.raw-lens');
    assert.strictEqual(await tile.count(), 1);
    assert.strictEqual(await tile.getAttribute('href'), `lens/${OIL.id}?photo=${rawName}`);
    await page.screenshot({ path: `${OUT}/lens-product.png` });
    step('with a photo, the product page has a Google Lens button, and each phone photo has its own');

    // One click: the link opens the dashboard's Lens page in a new tab (the Windows app opens it in the browser), which sends
    // the photo to Google by itself.
    const [popup] = await Promise.all([context.waitForEvent('page'), header.click()]);
    watch(popup);
    const outside = [];
    popup.on('request', r => { const origin = new URL(r.url()).origin; if (origin !== BASE && origin !== 'https://lens.google.com') outside.push(r.url()); });
    await popup.waitForURL('https://lens.google.com/**', { timeout: 30000 });
    await popup.locator('#results').waitFor();
    assert.strictEqual(posts.length, 1);
    const sent = posts[0];
    assert.strictEqual(sent.method, 'POST');
    assert.strictEqual(sent.url, 'https://lens.google.com/v3/upload');
    assert.match(sent.type, /^multipart\/form-data; boundary=/);
    const form = parts(sent.body, sent.type);
    assert.deepStrictEqual(form.map(p => p.name), ['encoded_image'], 'only the photo is in the form');
    assert.strictEqual(form[0].filename, 'product.jpg');
    assert.strictEqual(form[0].type, 'image/jpeg');
    const jpeg = form[0].bytes;
    assert.deepStrictEqual([...jpeg.subarray(0, 3)], [0xff, 0xd8, 0xff], 'a JPEG');
    const size = jpegSize(jpeg);
    assert.deepStrictEqual(size, { width: 1600, height: 1067 }, 'made smaller: the longest side is 1600 pixels');
    assert.ok(!jpeg.includes(Buffer.from('Exif\0\0', 'latin1')), 'no EXIF: the photo was drawn again');
    assert.ok(jpeg.length < 2 * 1024 * 1024, 'a small upload: ' + jpeg.length + ' bytes');
    assert.deepStrictEqual(outside, [], 'nothing but the dashboard and the one form went anywhere');
    step('one click sends the photo to Google as one form: a JPEG of 1600 pixels at most, without EXIF, and nothing else');

    // Back from Google's results must not send the photo again by itself; "Search again" does, when asked.
    await popup.goBack();
    await popup.locator('#status').waitFor();
    await popup.getByText('This photo was already sent to Google Lens').waitFor();
    assert.strictEqual(posts.length, 1, 'coming back does not send it again');
    await popup.screenshot({ path: `${OUT}/lens-page.png` });
    await popup.getByRole('button', { name: 'Search again' }).click();
    await popup.waitForURL('https://lens.google.com/**');
    assert.strictEqual(posts.length, 2);
    step('coming back from Google does not send the photo again; Search again does');
    await popup.close();

    // A phone photo's own button sends that photo; a made photo can be searched too; names that are not the store's are refused.
    const second = await context.newPage();
    watch(second);
    await second.goto(`${BASE}/lens/${OIL.id}?photo=${rawName}`);
    await second.waitForURL('https://lens.google.com/**');
    assert.strictEqual(posts.length, 3);
    assert.strictEqual(jpegSize(parts(posts[2].body, posts[2].type)[0].bytes).width, 1600);
    for (const bad of ['..%2F..%2Fappsettings.json', 'product.json', 'raw-20200101-000000.png', 'white-20200101-000000.png']) {
      const response = await second.goto(`${BASE}/lens/${OIL.id}?photo=${bad}`);
      assert.strictEqual(response.status(), 404, bad + ' is refused');
      assert.ok((await second.locator('h1').innerText()).includes('No photo to search with'));
    }

    assert.strictEqual(posts.length, 3, 'refused names send nothing');
    step('a chosen phone photo is sent; a name that is not one of the product\'s photos is refused and sends nothing');

    // The page's headers: nothing cached, nothing leaks in the referrer, and only this dashboard's own photo is loaded.
    const raw = await second.request.get(`${BASE}/lens/${OIL.id}`);
    const headers = raw.headers();
    assert.strictEqual(headers['cache-control'], 'no-store');
    assert.strictEqual(headers['referrer-policy'], 'no-referrer');
    assert.strictEqual(headers['x-content-type-options'], 'nosniff');
    assert.ok(headers['content-security-policy'].includes("default-src 'none'"));
    assert.ok(!headers['content-security-policy'].includes('form-action'), 'the form must be able to go to Google');
    step('the Lens page is not cached, leaks no referrer, and may load only the dashboard\'s own photo');

    // Where else the button is: the product list, the photos list, the price check card.
    await second.goto(`${BASE}/products`, { waitUntil: 'networkidle' });
    await second.locator('table.data-table tbody tr').first().waitFor();
    const lensRows = second.locator('table.data-table tbody tr:has(a.lens-btn)');
    assert.strictEqual(await lensRows.count(), 1, 'only the product with a photo has the button');
    assert.ok((await lensRows.first().innerText()).includes(OIL.name));
    assert.strictEqual(await lensRows.first().locator('a.lens-btn').getAttribute('href'), `lens/${OIL.id}`);
    await second.goto(`${BASE}/photos?view=with`, { waitUntil: 'networkidle' });
    assert.strictEqual(await second.locator('a.lens-btn').count(), 1);
    await second.goto(`${BASE}/photos?view=all`, { waitUntil: 'networkidle' });
    assert.strictEqual(await second.locator('a.lens-btn').count(), 1, 'products without a photo have no button');
    step('the Products and Product photos lists have the button only for products with a photo');

    // The browser logs each page it was refused (404) that this test asked for on purpose: the product without a photo and
    // the four names that are not the product's photos. Nothing else may be logged.
    assert.deepStrictEqual(errors.filter(e => !e.includes('status of 404')), [], 'no console errors');
    assert.strictEqual(errors.filter(e => e.includes('status of 404')).length, 5, 'only the five refusals asked for');
    console.log('No console errors or page errors, besides the five refusals asked for.');
  } finally {
    await browser.close();
    stopApp(app);
  }
})().catch(e => {
  console.error(e);
  process.exit(1);
});
