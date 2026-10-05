// End-to-end check of the Creatives studio, in Chromium, on the demo shop, with stand-in-codex.js in place of Codex.
// A creative for the demo's sunflower oil:
// - words with a number are refused before Codex is asked;
// - Codex designs the picture and the app adds the POS price, with the offer chosen, where Codex left room;
// - the price tag moves by dragging and with the arrow keys;
// - a change is made from the picture before, and both are kept;
// - the one to use is chosen, and the export is a PNG at the exact size with the price drawn on it;
// - the brand colours the tag, and the creative is deleted.
// It starts the app itself, then stops it:
//   npm install && npm run test:creatives        (needs the .NET 10 SDK; screenshots go to ./screenshots)
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

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-creatives-'));
const dataFolder = path.join(work, 'data');
// While this file exists the stand-in Codex meets its usage limit.
const limitFile = path.join(work, 'codex-limit');

// A "codex" launcher for the stand-in, like the one npm installs, set up as the side panel would.
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: dataFolder }));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile, STAND_IN_CODEX_DELAY_MS: '400', STAND_IN_CODEX_LIMIT_FILE: limitFile },
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

/** Waits until the check passes, reading files as the app writes them. */
async function until(check, what, timeout = 20000) {
  const end = Date.now() + timeout;
  for (;;) {
    try { const value = check(); if (value) return value; } catch { /* not yet */ }
    if (Date.now() > end) throw new Error('Timed out waiting for ' + what);
    await new Promise(r => setTimeout(r, 150));
  }
}

/** A PNG's size, from its header. */
function pngSize(bytes) {
  assert.strictEqual(bytes.toString('latin1', 1, 4), 'PNG');
  return [bytes.readUInt32BE(16), bytes.readUInt32BE(20)];
}

/** The colours of some points of a picture the app serves, read in the page: [r, g, b] each. */
function colours(page, url, points) {
  return page.evaluate(async ({ url, points }) => {
    const image = new Image();
    image.src = url;
    await image.decode();
    const canvas = document.createElement('canvas');
    canvas.width = image.naturalWidth;
    canvas.height = image.naturalHeight;
    const ctx = canvas.getContext('2d');
    ctx.drawImage(image, 0, 0);
    return points.map(([x, y]) => [...ctx.getImageData(Math.round(x), Math.round(y), 1, 1).data.slice(0, 3)]);
  }, { url, points });
}

const near = (colour, expected, what) =>
  assert.ok(colour.every((v, i) => Math.abs(v - expected[i]) <= 12), `${what}: ${colour} is not near ${expected}`);

async function noSidewaysScroll(page, url) {
  await page.setViewportSize({ width: 390, height: 844 });
  await page.goto(url, { waitUntil: 'networkidle' });
  const wide = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
  assert.ok(wide <= 1, `${url} scrolls sideways by ${wide}px at phone width`);
  await page.setViewportSize({ width: 1366, height: 900 });
}

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 }, acceptDownloads: true });
    const page = await context.newPage();
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    await page.goto(BASE + '/creatives', { waitUntil: 'networkidle' });
    await page.getByText('No creatives yet').waitFor();
    await page.fill('.creative-new .scan-input', 'sunflower');
    await page.locator('.creative-new .found-list li', { hasText: 'Sunflower Oil 1 L' }).getByRole('button', { name: 'Add' }).click();
    await page.locator('.picked-products li', { hasText: 'Sunflower Oil 1 L' }).waitFor();
    await page.getByRole('button', { name: 'Start the creative' }).click();
    await page.waitForURL(/\/creatives\/\d{8}-\d{6}$/);
    const id = page.url().split('/').pop();
    const folder = path.join(dataFolder, 'Creatives', id);
    const project = () => JSON.parse(fs.readFileSync(path.join(folder, 'creative.json'), 'utf8'));
    await page.locator('.title-input').waitFor();
    assert.strictEqual(await page.locator('.title-input').inputValue(), 'Sunflower Oil 1 L');
    step('a new creative for the oil, named after it, kept in the data folder');

    // The brief. The offers are the poster rules' (never below the purchase price plus GST).
    const offer = page.getByRole('combobox', { name: 'Offer on Sunflower Oil 1 L' });
    assert.deepStrictEqual(await offer.locator('option').evaluateAll(list => list.map(o => o.value)), ['', '148', '140']);
    await offer.selectOption('148');
    await until(() => project().Brief.Products[0].Offer === 148, 'the offer to be saved');
    await page.fill('#headline', 'Diwali 50% off');
    await page.press('#headline', 'Tab');
    await page.locator('.word-field', { hasText: 'Headline' }).getByText('has a number, ₹ or % in it').waitFor();
    await page.getByRole('button', { name: 'Make it', exact: true }).click();
    await page.locator('.plan-error', { hasText: 'The headline has a number, ₹ or % in it.' }).waitFor();
    assert.strictEqual(project().Generations.length, 0, 'a picture was asked for with a number in its words');
    await page.fill('#headline', 'Diwali Dhamaka');
    await page.press('#headline', 'Tab');
    // The brief is three short steps; the style, the call to action and the other extras are under "More choices", closed until used.
    assert.ok(/Nothing here is compulsory/.test(await page.locator('.brief-lead').innerText()), 'the page says nothing is compulsory');
    assert.deepStrictEqual(await page.locator('.brief-step').evaluateAll(list => list.map(e => e.textContent.replace(/\s+/g, ' ').trim())),
      ['1 What is it for?', '2 What should it show? Optional', '3 What should it say? Optional']);
    assert.strictEqual(await page.locator('.brief-more').evaluate(e => e.open), false, 'the extras are folded away until they are used');
    assert.strictEqual(await page.locator('.brief-more #cta').isVisible(), false);
    await page.screenshot({ path: `${OUT}/creative-brief-short.png` });
    await page.locator('.brief-more > summary').click();
    await page.fill('#cta', 'Visit us today');
    await page.press('#cta', 'Tab');
    await until(() => project().Brief.CallToAction === 'Visit us today', 'the call to action to be saved');
    await page.fill('#cta', '');
    await page.press('#cta', 'Tab');
    await until(() => !project().Brief.CallToAction, 'the emptied call to action to be saved');
    assert.strictEqual(await page.locator('.brief-more').evaluate(e => e.open), true, 'emptying the last field does not fold the section away under the cursor');
    await page.fill('#cta', 'Visit us today');
    await page.press('#cta', 'Tab');
    await page.getByRole('radio', { name: 'Festive' }).click();
    await until(() => project().Brief.Style === 'festive' && project().Brief.CallToAction === 'Visit us today', 'the brief to be saved');
    step('the brief: an offer within the rules; words with a number are refused before Codex is asked');

    await page.getByRole('button', { name: 'Make it', exact: true }).click();
    await page.locator('.creative-wait', { hasText: 'Codex' }).waitFor();
    await page.locator('.creative-frame img').waitFor({ timeout: 60000 });
    const tag = page.locator('.ctag');
    const said = await tag.innerText();
    for (const part of ['Sunflower Oil 1 L', '₹148', '₹155', '4% off']) assert.ok(said.includes(part), `the tag does not say ${part}: ${said}`);
    const prompt = fs.readFileSync(path.join(folder, 'generations', '1', 'prompt.txt'), 'utf8');
    assert.ok(prompt.includes('"Diwali Dhamaka"') && prompt.includes('festive, for an Indian festival'), prompt);
    assert.ok(!/₹\s*\d|148|155/.test(prompt), 'the prompt holds a price');
    const made = project().Generations[0];
    assert.deepStrictEqual([made.HasImage, made.Tags[0].X, made.Tags[0].Y], [true, 0.07, 0.735]);
    await page.screenshot({ path: `${OUT}/creative.png` });
    step('Codex designs the picture; the price tag is the app’s, from the POS, where Codex left room');

    // Move the tag: dragged, then with the arrow keys.
    await tag.scrollIntoViewIfNeeded();
    const before = await tag.boundingBox();
    await page.mouse.move(before.x + before.width / 2, before.y + before.height / 2);
    await page.mouse.down();
    await page.mouse.move(before.x + before.width / 2 + 180, before.y + before.height / 2 - 260, { steps: 8 });
    await page.mouse.up();
    const dragged = await until(() => { const t = project().Generations[0].Tags[0]; return t.X > 0.2 && t.Y < 0.6 && t; }, 'the dragged tag to be saved');
    await tag.focus();
    await page.keyboard.press('ArrowLeft');
    await until(() => Math.abs(project().Generations[0].Tags[0].X - (dragged.X - 0.01)) < 0.002, 'the tag to move left');
    await page.reload({ waitUntil: 'networkidle' });
    assert.strictEqual(await page.locator('.brief-more').evaluate(e => e.open), true, 'a creative with something under "More choices" opens with it shown');
    const style = await page.locator('.ctag').getAttribute('style');
    assert.ok(style.includes(`left: ${Math.round((dragged.X - 0.01) * 10000) / 100}%`), style);
    step('the price tag moves by dragging and with the arrow keys, and stays where it was put');

    // A change needs words, so its box has a star and is announced as required.
    assert.strictEqual(await page.locator('label[for="creative-change"] .req').count(), 1, 'what to change is compulsory');
    assert.strictEqual(await page.locator('#creative-change').getAttribute('aria-required'), 'true');
    await page.fill('.change-row input', 'make the background deep blue');
    await page.getByRole('button', { name: 'Change it' }).click();
    await page.locator('.creative-frame img[src$="/picture/2"]').waitFor({ timeout: 60000 });
    assert.strictEqual(await page.locator('.hist-item img').count(), 2);
    const second = project().Generations[1];
    assert.deepStrictEqual([second.Parent, second.Change], [1, 'make the background deep blue']);
    near((await colours(page, `${BASE}/creative-files/${id}/picture/2`, [[8, 8]]))[0], [40, 90, 200], 'the changed picture');
    step('a change is made from the picture before (the stand-in got it first), and both are kept');

    await page.getByRole('button', { name: 'Use this one' }).click();
    await page.locator('.pill.good', { hasText: 'The one you chose' }).waitFor();
    assert.strictEqual(project().Chosen, 2);
    const exportButton = page.getByRole('button', { name: 'Export PNG' });
    assert.ok(await exportButton.isDisabled(), 'the export needs the words and prices checked');
    await page.getByLabel('I checked the words and the prices').check();
    const [download] = await Promise.all([page.waitForEvent('download'), exportButton.click()]);
    assert.strictEqual(download.suggestedFilename(), 'sunflower-oil-1-l-square-2.png');
    const exported = path.join(work, 'export.png');
    await download.saveAs(exported);
    assert.deepStrictEqual(pngSize(fs.readFileSync(exported)), [1080, 1080]);
    assert.ok(fs.existsSync(path.join(folder, 'exports', 'sunflower-oil-1-l-square-2.png')), 'no copy was kept with the creative');
    const place = project().Generations[1].Tags[0];
    const [inTag, away] = await colours(page, `${BASE}/creative-files/${id}/export/sunflower-oil-1-l-square-2.png`,
      [[(place.X + 0.25) * 1080, (place.Y + 0.065) * 1080], [1070, 10]]);
    near(inTag, [0xD7, 0x26, 0x3D], 'the price tag in the export');
    near(away, [40, 90, 200], 'the picture in the export');
    await page.locator('.plan-error', { hasText: 'Exported as sunflower-oil-1-l-square-2.png, 1080 × 1080 px' }).waitFor();
    step('the chosen picture exports as a 1080 × 1080 PNG with the price tag drawn on it, and a copy is kept');

    // Open at first, while the shop has no brand yet.
    if (await page.locator('.brand-card details').getAttribute('open') === null) await page.locator('.brand-card summary').click();
    await page.fill('#shop-name', 'Sharma Store');
    await page.getByLabel("The shop's main colour (price tags use it)").fill('#1d3557');
    await page.getByRole('button', { name: 'Save the brand' }).click();
    await page.locator('.plan-error', { hasText: 'The brand is saved.' }).waitFor();
    assert.ok((await page.locator('.ctag').getAttribute('style')).includes('background: #1D3557; color: #FFFFFF'));
    await offer.selectOption('');
    await page.waitForFunction(() => !document.querySelector('.ctag-was'));
    assert.ok((await page.locator('.ctag').innerText()).includes('₹155'));
    await page.screenshot({ path: `${OUT}/creative-brand.png` });
    step('the brand colours the price tag; without an offer the tag shows the POS price only');

    // A product deleted from the POS since it was put on the brief (the demo shop has no product 99999) stays on the
    // brief, so it can be taken off.
    await until(() => project().Brief.Products[0].Offer === null, 'no offer to be saved');
    const withGone = project();
    withGone.Brief.Products.push({ ProductId: 99999, Offer: null });
    fs.writeFileSync(path.join(folder, 'creative.json'), JSON.stringify(withGone, null, 2));
    await page.reload({ waitUntil: 'networkidle' });
    const gone = page.locator('.picks li', { hasText: 'No longer in the POS. Take it off the creative.' });
    await gone.waitFor();
    await gone.scrollIntoViewIfNeeded();
    await page.screenshot({ path: `${OUT}/creative-gone.png` });
    assert.strictEqual(await gone.locator('select').count(), 0, 'a product no longer in the POS offers an offer');
    await gone.getByRole('button', { name: 'Take A product off' }).click();
    await until(() => project().Brief.Products.length === 1 && project().Brief.Products[0].ProductId !== 99999, 'the product to be taken off');
    await gone.waitFor({ state: 'detached' });
    step('a product deleted from the POS since stays on the brief, to be taken off');

    // Another format for the next picture: the chosen square picture keeps its own shape on the list.
    await page.getByRole('radio', { name: 'Story' }).click();
    await until(() => project().Brief.Format === 'story', 'the format to be saved');

    await noSidewaysScroll(page, `${BASE}/creatives/${id}`);
    await noSidewaysScroll(page, `${BASE}/creatives`);
    step('phone width: no sideways scrolling');

    await page.goto(`${BASE}/creatives`, { waitUntil: 'networkidle' });
    const card = page.locator('.creative-card', { hasText: 'Sunflower Oil 1 L' });
    assert.ok((await card.innerText()).includes('Square post · 2 pictures'), await card.innerText());
    assert.ok((await card.locator('.cc-picture').getAttribute('style')).includes('aspect-ratio: 1080 / 1080'), 'the card is not the chosen picture’s shape');
    assert.strictEqual(await card.locator('img').getAttribute('src'), `creative-files/${id}/picture/2`, 'the card shows the chosen picture');
    await page.screenshot({ path: `${OUT}/creatives.png` });
    await card.click();
    await page.waitForURL(new RegExp(`/creatives/${id}$`));
    await page.getByRole('button', { name: 'Delete' }).click();
    await page.getByRole('button', { name: 'Press again to delete it' }).click();
    await page.waitForURL(/\/creatives$/);
    await page.getByText('No creatives yet').waitFor();
    assert.ok(!fs.existsSync(folder), 'the creative’s folder is still there');
    step('the creative is deleted with its pictures');

    // Codex's usage limit: the picture is not marked as failed; it waits, says when it is made by itself, and is made when the limit lifts.
    fs.writeFileSync(limitFile, '');
    await page.fill('.creative-new .scan-input', 'sunflower');
    await page.locator('.creative-new .found-list li', { hasText: 'Sunflower Oil 1 L' }).getByRole('button', { name: 'Add' }).click();
    await page.getByRole('button', { name: 'Start the creative' }).click();
    await page.waitForURL(/\/creatives\/\d{8}-\d{6}$/);
    const limited = page.url().split('/').pop();
    const limitedFile = path.join(dataFolder, 'Creatives', limited, 'creative.json');
    await page.getByRole('button', { name: 'Make it', exact: true }).click();
    const waiting = page.locator('.creative-wait', { hasText: 'Paused: Codex' });
    await waiting.waitFor({ timeout: 30000 });
    assert.ok(/This picture is made by itself at (tomorrow )?\d{1,2}:\d{2}/i.test(await waiting.innerText()), await waiting.innerText());
    const held = await until(() => { const g = JSON.parse(fs.readFileSync(limitedFile, 'utf8')).Generations[0]; return g && g.WaitingForLimit && g; }, 'the picture to wait for the limit');
    assert.ok(!held.Problem && !held.Finished, 'a usage limit marked the picture as failed');
    await page.screenshot({ path: `${OUT}/creative-paused.png` });
    fs.rmSync(limitFile);
    await waiting.getByRole('button', { name: 'Try now' }).click();
    await page.locator('.creative-frame img').waitFor({ timeout: 60000 });
    const done = JSON.parse(fs.readFileSync(limitedFile, 'utf8')).Generations[0];
    assert.deepStrictEqual([done.HasImage, done.WaitingForLimit], [true, false]);
    step('Codex’s usage limit does not fail a creative’s picture: it waits, says so, and is made when the limit lifts');

    assert.deepStrictEqual(errors, [], 'console or page errors: ' + errors.join('\n'));
    console.log('No console or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
  }
})().catch(error => {
  console.error(error);
  process.exit(1);
});
