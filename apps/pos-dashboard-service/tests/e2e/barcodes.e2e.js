// End-to-end check of barcode help, in Chromium: the Products page shows the code the till scans; stickers are
// chosen, laid out on sticker paper (a part-used sheet too) and printed; the counter book is made from the best
// sellers; the side panel finds a code by name. It starts the app itself on demo data with its own settings file,
// then stops it. When Ghostscript and zxing-cpp are installed (pip install zxing-cpp pillow), every printed barcode
// is also read back by that independent reader:
//   npm install && npm run test:barcodes        (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn, spawnSync } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-barcodes-'));
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli' }, null, 2));
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

const has = (command, args) => spawnSync(command, args, { stdio: 'ignore' }).status === 0;
const canScan = has('gs', ['--version']) && has('python3', ['-c', 'import zxingcpp, PIL']);

// Renders one page of a printed PDF at 300 dpi and reads the barcode in each cell (x, y, width, height in mm).
function scanPage(pdf, pageNumber, cells) {
  const png = path.join(work, `scan-${pageNumber}.png`);
  const gs = spawnSync('gs', ['-q', '-dNOPAUSE', '-dBATCH', '-sDEVICE=pnggray', '-r300', `-dFirstPage=${pageNumber}`, `-dLastPage=${pageNumber}`, `-sOutputFile=${png}`, pdf]);
  assert.strictEqual(gs.status, 0, 'Ghostscript renders the PDF: ' + gs.stderr);
  const read = spawnSync('python3', [path.join(__dirname, 'scan_barcodes.py'), png, JSON.stringify({ dpi: 300, cells })], { encoding: 'utf8' });
  assert.strictEqual(read.status, 0, 'the reader runs: ' + read.stderr);
  return JSON.parse(read.stdout);
}

// The pages in a PDF and each one's size in points, as Ghostscript reads them.
function pdfPages(pdf) {
  const script = `(${pdf.replace(/\\/g, '/')}) (r) file runpdfbegin 1 1 pdfpagecount { pdfgetpage /MediaBox pget pop == } for quit`;
  const out = spawnSync('gs', ['-q', '-dNODISPLAY', '-dNOSAFER', '-c', script], { encoding: 'utf8' }).stdout.trim();
  return out.split('\n').map(line => line.replace(/[[\]]/g, '').trim().split(/\s+/).map(Number).slice(2));
}

async function printToPdf(page, file) {
  await page.emulateMedia({ media: 'print' });
  await page.pdf({ path: file, preferCSSPageSize: true, printBackground: true });
  await page.emulateMedia({ media: 'screen' });
}

// Cells of an A4 sheet from its left/top margins, sticker size and gap across (mm), in page order.
const grid = (left, top, width, height, gap, across, count) =>
  Array.from({ length: count }, (_, i) => [left + (i % across) * (width + gap), top + Math.floor(i / across) * height, width, height]);

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    // The Products page shows the code the till scans, and opens stickers for a product
    await page.goto(BASE + '/products?q=atta');
    const atta = page.locator('table.data-table tbody tr', { hasText: 'Whole Wheat Atta 5 kg' });
    await atta.waitFor();
    assert.strictEqual(await atta.locator('.till-code').innerText(), '2000000000022');
    await atta.getByRole('link', { name: /Stickers/ }).click();
    await page.waitForURL(/\/barcodes\?products=\d+$/);
    await page.locator('.label-page .sticker').first().waitFor();
    assert.strictEqual(await page.locator('.label-page .sticker').count(), 1);
    step('Products shows the till code; Stickers opens the Barcodes page with the product');

    // Nine stickers for the nine pieces that lost theirs, and a product added by name
    const count = page.locator('input[aria-label="Stickers for Whole Wheat Atta 5 kg"]');
    await count.fill('9');
    await count.press('Tab');
    await page.waitForFunction(() => document.querySelectorAll('.label-page .sticker').length === 9);
    assert.match(await page.locator('.barcode-setup').innerText(), /9 stickers on 1 sheet\./);
    const find = page.locator('input[aria-label="Find a product"]');
    await find.fill('dal');
    await page.locator('.found-list li', { hasText: 'Toor Dal 1 kg' }).getByRole('button', { name: 'Add' }).click();
    await page.waitForFunction(() => document.querySelectorAll('.label-page .sticker').length === 10);
    const first = page.locator('.label-page .sticker').first();
    assert.match(await first.innerText(), /DEMO STORE[\s\S]*Whole Wheat Atta 5 kg[\s\S]*2000000000022[\s\S]*₹265[\s\S]*MRP ₹285/i);
    step('9 stickers for atta, 1 for dal found by name; each shows the shop, name, code, price and MRP');

    // A part-used sheet of 24: printing starts at sticker 21
    await page.locator('#paper').selectOption('a4-24');
    await page.locator('#start-at').fill('21');
    await page.locator('#start-at').press('Tab');
    await page.waitForFunction(() => document.querySelectorAll('.label-page').length === 2);
    const sheet = page.locator('.label-page').first();
    assert.strictEqual(await sheet.locator('.label-cell.empty').count(), 20);
    assert.strictEqual(await sheet.locator('.sticker').count(), 4);
    assert.strictEqual(await page.locator('.label-page').nth(1).locator('.sticker').count(), 6);
    await page.screenshot({ path: `${OUT}/barcodes-1-stickers.png`, fullPage: true });
    step('sheet of 24 started at sticker 21: 4 on the first sheet, 6 on the next');

    // Printed: two A4 pages, and every printed barcode reads back as the till's code
    const stickersPdf = path.join(work, 'stickers.pdf');
    await printToPdf(page, stickersPdf);
    if (canScan) {
      const sizes = pdfPages(stickersPdf);
      assert.strictEqual(sizes.length, 2, 'two sheets');
      sizes.forEach(([w, h]) => assert.ok(Math.abs(w - 595.3) < 1.5 && Math.abs(h - 841.9) < 1.5, `A4 page, got ${w} x ${h} pt`));
      const cells = grid(7.25, 12.9, 63.5, 33.9, 2.5, 3, 24);
      const firstSheet = scanPage(stickersPdf, 1, cells);
      const nextSheet = scanPage(stickersPdf, 2, cells);
      assert.deepStrictEqual(firstSheet.slice(0, 20), Array(20).fill(null), 'the used stickers stay empty');
      assert.deepStrictEqual(firstSheet.slice(20), Array(4).fill('2000000000022'));
      assert.deepStrictEqual(nextSheet.slice(0, 6), [...Array(5).fill('2000000000022'), '2000000000039']);
      step('printed on 2 A4 sheets; all 10 barcodes read back correctly by an independent reader (zxing-cpp)');
    } else {
      step('printed to PDF (install Ghostscript and zxing-cpp to also read the barcodes back)');
    }

    // The choices are kept: after a reload the paper is still the sheet of 24
    const saved = JSON.parse(fs.readFileSync(settingsFile, 'utf8'));
    assert.strictEqual(saved.Stickers.Paper, 'a4-24');
    await page.reload();
    await page.locator('#paper').waitFor();
    assert.strictEqual(await page.locator('#paper').inputValue(), 'a4-24');
    await page.locator('#paper').selectOption('a4-65');
    step('the sticker paper is remembered in the settings file');

    // The counter book: the best sellers, 18 cards to a page, printed and scanned
    await page.getByRole('link', { name: 'Counter book' }).click();
    await page.getByRole('button', { name: 'Add the best sellers' }).click();
    await page.waitForFunction(() => document.querySelectorAll('.book-card').length >= 15);
    const cards = await page.locator('.book-card').count();
    assert.strictEqual(await page.locator('.book-pages .label-page').count(), Math.ceil(cards / 18));
    assert.match(await page.locator('.book-card').first().innerText(), /₹\d/);
    await page.screenshot({ path: `${OUT}/barcodes-2-book.png`, fullPage: true });
    if (canScan) {
      const bookPdf = path.join(work, 'book.pdf');
      await printToPdf(page, bookPdf);
      const read = scanPage(bookPdf, 1, grid(6, 10.5, 64, 44, 3, 3, Math.min(cards, 18)).map(([x, y, w, h], i) => [x, y + Math.floor(i / 3) * 3, w, h]));
      const shown = await page.locator('.book-pages .label-page').first().locator('.bc-code').allInnerTexts();
      assert.deepStrictEqual(read, shown, 'every card on the first page reads back as the code printed under it');
      step(`counter book: ${cards} best sellers on ${Math.ceil(cards / 18)} page(s); every card's barcode reads back`);
    } else {
      step(`counter book: ${cards} best sellers on ${Math.ceil(cards / 18)} page(s)`);
    }

    // The side panel finds a code by name; Esc goes back to the chat. It stands in for the app here, so the messages
    // the panel sends it (Esc sends "hide") can be checked.
    const panel = await browser.newPage({ viewport: { width: 400, height: 800 } });
    panel.on('pageerror', e => errors.push(e.message));
    await panel.addInitScript(() => {
      window.sentToApp = [];
      window.chrome = { webview: { postMessage: message => window.sentToApp.push(JSON.parse(message).type), addEventListener() {} } };
    });
    await panel.goto(BASE + '/panel');
    const finder = panel.locator('input[aria-label="Find a barcode"]');
    await finder.fill('rice');
    await panel.locator('.pf-row', { hasText: 'Basmati Rice 5 kg' }).waitFor();
    assert.strictEqual(await panel.locator('.pf-row .pf-code').first().innerText(), '2000000000015');
    await panel.screenshot({ path: `${OUT}/barcodes-3-panel.png` });
    await finder.press('Escape');
    await panel.locator('.panel-thread').waitFor();
    assert.ok(!(await panel.evaluate(() => window.sentToApp)).includes('hide'), 'Esc clearing the finder must not hide the panel');
    await finder.press('Escape');
    await panel.waitForFunction(() => window.sentToApp.includes('hide'));
    step('side panel: typing "rice" shows its code; Esc clears the finder and keeps the panel; Esc again hides it');

    // Phone width: no sideways scrolling
    await page.setViewportSize({ width: 390, height: 844 });
    await page.goto(BASE + '/barcodes?products=1,2');
    await page.locator('.label-page').first().waitFor();
    const overflow = await page.evaluate(() => document.documentElement.scrollWidth - window.innerWidth);
    assert.ok(overflow <= 1, `no sideways scroll at 390px (overflow ${overflow}px)`);
    step('phone width: no sideways scrolling');

    assert.deepStrictEqual(errors.filter(e => !/_blazor\/disconnect/.test(e)), []);
    console.log('No console errors or page errors.');
  } catch (e) {
    console.error('FAILED: ' + (e && e.message));
    process.exitCode = 1;
  } finally {
    await browser.close();
    stopApp(app);
    fs.rmSync(work, { recursive: true, force: true });
  }
})();
