// End-to-end check of finding a product with the camera, in Chromium, on the demo shop. Chromium's stand-in camera
// plays pictures made here. First a barcode of the demo's Sunflower Oil: it is found by its barcode on the Barcodes and
// Products pages and in the side panel, with nothing downloaded. Then the oil bottle as a phone sees it: found by
// nothing while finding by look is off, then by its look once that is turned on in Settings, which "downloads" the
// tiny stand-in model from a server started here (checked by its size and SHA-256) and learns the products' photos.
// The person always picks the product. It starts the app itself on demo data, with stand-in-codex.js making the
// product photos, then stops it:
//   npm install && npm run test:camera        (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const crypto = require('crypto');
const fs = require('fs');
const http = require('http');
const os = require('os');
const path = require('path');
const { png, phonePhoto } = require('./png');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-camera-'));
const dataFolder = path.join(work, 'data');

// A "codex" launcher for the stand-in, which makes the product photos the camera search learns.
const standIn = path.join(__dirname, 'stand-in-codex.js');
const codex = path.join(work, process.platform === 'win32' ? 'codex.cmd' : 'codex');
fs.writeFileSync(codex, process.platform === 'win32'
  ? `@"${process.execPath}" "${standIn}" %*\r\n`
  : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
const settingsFile = path.join(work, 'settings.json');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: dataFolder }));

// The demo's Sunflower Oil is billed by the in-store EAN-13 its stock batch carries.
const OIL = { id: 6, name: 'Sunflower Oil 1 L', code: '1006', barcode: '2000000000060' };
const RICE = { id: 1, name: 'Basmati Rice 5 kg' };

// The tiny stand-in for DINOv2 (the unit tests' model), served as a mirror would serve the real one, and a second tiny model as the
// better one that a later version of the app offers.
const model = fs.readFileSync(path.join(__dirname, '../SmartRetail.Pos.Tests/Vision/tiny-embedder.onnx'));
const better = fs.readFileSync(path.join(__dirname, '../SmartRetail.Pos.Tests/Vision/tiny-embedder-tokens.onnx'));
let modelRequests = 0;
let betterRequests = 0;
const modelServer = http.createServer((request, response) => {
  const served = request.url === '/tiny.onnx' ? model : request.url === '/tiny2.onnx' ? better : null;
  if (!served) {
    response.writeHead(404).end();
    return;
  }

  if (served === model) modelRequests++; else betterRequests++;
  response.writeHead(200, { 'Content-Type': 'application/octet-stream', 'Content-Length': served.length });
  response.end(served);
});

// ----- Pictures for Chromium's stand-in camera -----

/** EAN-13 as its 95 modules, "1" for a bar. */
function ean13(digits) {
  const L = ['0001101', '0011001', '0010011', '0111101', '0100011', '0110001', '0101111', '0111011', '0110111', '0001011'];
  const R = L.map(code => [...code].map(bit => (bit === '1' ? '0' : '1')).join(''));
  const G = R.map(code => [...code].reverse().join(''));
  const parity = ['LLLLLL', 'LLGLGG', 'LLGGLG', 'LLGGGL', 'LGLLGG', 'LGGLLG', 'LGGGLL', 'LGLGLG', 'LGLGGL', 'LGGLGL'][+digits[0]];
  let bits = '101';
  for (let i = 1; i <= 6; i++) bits += (parity[i - 1] === 'L' ? L : G)[+digits[i]];
  bits += '01010';
  for (let i = 7; i <= 12; i++) bits += R[+digits[i]];
  return bits + '101';
}

/** A barcode held up to the camera: black bars on white paper. */
function barcodePicture(digits) {
  const bits = ean13(digits);
  const module = 4;
  const left = (640 - bits.length * module) / 2;
  return {
    name: 'barcode', width: 640, height: 480, colourAt: (x, y) => {
      const m = Math.floor((x - left) / module);
      return y >= 140 && y < 340 && m >= 0 && m < bits.length && bits[m] === '1' ? [0, 0, 0] : [255, 255, 255];
    },
  };
}

/** A white rice bag with a green label on a blue-grey table, as a phone photo of the rice. */
function ricePhoto(x, y) {
  if (x >= 90 && x <= 230 && y >= 50 && y <= 290) return y >= 150 && y <= 210 ? [30, 110, 60] : [236, 232, 220];
  return [70, 90, 120];
}

/** A Y4M video of one picture held still (4:2:0, BT.601), for Chromium's --use-file-for-fake-video-capture. */
function y4m({ width, height, colourAt }, file) {
  const lumaSize = width * height;
  const chromaSize = (width / 2) * (height / 2);
  const frame = Buffer.alloc(lumaSize + 2 * chromaSize);
  const rgb = new Float64Array(lumaSize * 3);
  for (let y = 0; y < height; y++) {
    for (let x = 0; x < width; x++) {
      const [r, g, b] = colourAt(x, y).map(v => Math.max(0, Math.min(255, v)));
      rgb.set([r, g, b], (y * width + x) * 3);
      frame[y * width + x] = Math.round(16 + 0.257 * r + 0.504 * g + 0.098 * b);
    }
  }

  for (let y = 0; y < height / 2; y++) {
    for (let x = 0; x < width / 2; x++) {
      let r = 0, g = 0, b = 0;
      for (const [dx, dy] of [[0, 0], [1, 0], [0, 1], [1, 1]]) {
        const at = ((2 * y + dy) * width + 2 * x + dx) * 3;
        r += rgb[at] / 4; g += rgb[at + 1] / 4; b += rgb[at + 2] / 4;
      }
      frame[lumaSize + y * (width / 2) + x] = Math.round(128 - 0.148 * r - 0.291 * g + 0.439 * b);
      frame[lumaSize + chromaSize + y * (width / 2) + x] = Math.round(128 + 0.439 * r - 0.368 * g - 0.071 * b);
    }
  }

  const header = Buffer.from(`YUV4MPEG2 W${width} H${height} F30:1 Ip A1:1 C420jpeg\n`);
  fs.writeFileSync(file, Buffer.concat([header, Buffer.from('FRAME\n'), frame, Buffer.from('FRAME\n'), frame]));
}

// ----- The app -----

async function startApp(port) {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: {
      ...process.env,
      ASPNETCORE_ENVIRONMENT: 'Development',
      Pos__Mode: 'Demo',
      Ai__SettingsFile: settingsFile,
      STAND_IN_CODEX_DELAY_MS: '150',
      STAND_IN_CODEX_STATE: path.join(work, 'codex-listings'),
      CameraSearch__ModelUrl: `http://127.0.0.1:${port}/tiny.onnx`,
      CameraSearch__ModelId: 'tiny@1',
      CameraSearch__ModelSize: String(model.length),
      CameraSearch__ModelSha256: crypto.createHash('sha256').update(model).digest('hex'),
      CameraSearch__BetterModelUrl: `http://127.0.0.1:${port}/tiny2.onnx`,
      CameraSearch__BetterModelId: 'tiny@2',
      CameraSearch__BetterModelSize: String(better.length),
      CameraSearch__BetterModelSha256: crypto.createHash('sha256').update(better).digest('hex'),
      CameraSearch__ModelsFolder: path.join(work, 'models'),
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

const errors = [];

/** A browser whose stand-in camera shows the picture, allowed without asking. */
async function withCamera(picture, run) {
  const video = path.join(work, picture.name + '.y4m');
  y4m(picture, video);
  const browser = await chromium.launch({
    args: ['--use-fake-device-for-media-stream', '--use-fake-ui-for-media-stream', `--use-file-for-fake-video-capture=${video}`],
  });
  try {
    const context = await browser.newContext({ viewport: { width: 1366, height: 900 } });
    await context.grantPermissions(['clipboard-read', 'clipboard-write'], { origin: BASE });
    const page = await context.newPage();
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));
    await run(page);
  } finally {
    await browser.close();
  }
}

/** Presses the camera button, takes a photo, has it looked for, and gives what it found. */
async function findWithCamera(page, button = 'Find a product with the camera') {
  await page.getByRole('button', { name: button }).click();
  const camera = page.getByRole('dialog', { name: 'Find a product' });
  await camera.getByRole('button', { name: 'Take photo' }).click({ timeout: 20000 });
  await camera.getByRole('button', { name: 'Find it' }).click();
  await camera.waitFor({ state: 'detached' });
  assert.strictEqual(await page.evaluate(() => window.srposCamera.running()), 0, 'the camera is off once the photo is taken');
  await page.waitForFunction(() => {
    const heading = document.querySelector('.camera-matches h2');
    return heading && !heading.textContent.includes('Looking');
  }, null, { timeout: 30000 });
  return page.locator('.camera-matches');
}

/** Every file under the folder, for checking that a search keeps nothing. */
function filesUnder(folder) {
  return fs.readdirSync(folder, { recursive: true }).filter(f => fs.statSync(path.join(folder, f)).isFile()).sort();
}

(async () => {
  await new Promise(r => modelServer.listen(0, '127.0.0.1', r));
  const app = await startApp(modelServer.address().port);
  try {
    await withCamera(barcodePicture(OIL.barcode), async (page) => {
      await page.goto(BASE + '/barcodes', { waitUntil: 'networkidle' });
      let found = await findWithCamera(page);
      assert.strictEqual(await found.locator('h2').innerText(), 'Found by its barcode');
      const row = found.locator('.cm-item');
      assert.strictEqual(await row.count(), 1);
      const text = await row.innerText();
      for (const part of [OIL.name, 'Code ' + OIL.code, '₹155', 'Exact match'])
        assert.ok(text.includes(part), `the match does not say "${part}": ${text}`);
      assert.strictEqual(await row.locator('.till-code.read').innerText(), OIL.barcode);
      assert.ok(!text.includes('Exact match:'), 'the barcode read is the one the till scans, so it is not said twice');
      assert.ok(!(await found.innerText()).includes('Only barcodes are read'), 'a barcode found says nothing about looks');
      await page.screenshot({ path: `${OUT}/camera-barcodes.png` });
      await row.getByRole('button', { name: 'Add: ' + OIL.name }).click();
      await found.waitFor({ state: 'detached' });
      const chosen = page.locator('.chosen-list tbody tr');
      await chosen.first().waitFor();
      assert.strictEqual(await chosen.count(), 1);
      assert.ok((await chosen.first().innerText()).includes(OIL.name));
      assert.strictEqual(await chosen.first().locator('.till-code').innerText(), OIL.barcode);
      assert.strictEqual(modelRequests, 0, 'barcodes need no download');
      step('Barcodes: a photo of the barcode finds the product at once, on this PC, and Add puts it on the sticker list');

      await page.goto(BASE + '/products', { waitUntil: 'networkidle' });
      await page.locator('table.data-table tbody tr').first().waitFor();
      found = await findWithCamera(page);
      assert.strictEqual(await found.locator('h2').innerText(), 'Found by its barcode');
      await found.getByRole('button', { name: 'Show: ' + OIL.name }).click();
      await page.locator('tbody tr.picked').waitFor();
      const first = page.locator('tbody tr').first();
      assert.ok((await first.getAttribute('class')).includes('picked'));
      assert.ok((await first.innerText()).includes(OIL.name));
      assert.strictEqual(await page.locator('.toolbar .scan-input').inputValue(), OIL.code);
      await page.screenshot({ path: `${OUT}/camera-products.png` });
      step('Products: Show puts the product first, marked, found by its code');

      // The camera in the sidebar's search box (the top bar's, inside the app) works on every page: what it found is a card
      // over the page, and Show opens Products on the product, first and marked.
      await page.goto(BASE + '/', { waitUntil: 'networkidle' });
      found = await findWithCamera(page, 'Search products with the camera');
      assert.strictEqual(await found.evaluate(el => getComputedStyle(el).position), 'fixed', 'what it found is a card over the page');
      assert.strictEqual(await found.locator('h2').innerText(), 'Found by its barcode');
      await page.screenshot({ path: `${OUT}/camera-everywhere.png` });
      await found.getByRole('button', { name: 'Show: ' + OIL.name }).click();
      await page.waitForURL(`**/products?q=${OIL.code}&picked=${OIL.id}`);
      await page.locator('tbody tr.picked').waitFor();
      assert.ok((await page.locator('tbody tr').first().innerText()).includes(OIL.name));
      assert.strictEqual(await page.locator('.toolbar .scan-input').inputValue(), OIL.code);
      assert.strictEqual(await page.evaluate(() => window.srposCamera.running()), 0, 'the camera is off');
      step('every page: the camera in the search box finds the product too, and Show opens Products on it');

      await page.setViewportSize({ width: 420, height: 860 });
      await page.goto(BASE + '/panel', { waitUntil: 'networkidle' });
      found = await findWithCamera(page);
      assert.strictEqual(await page.locator('.panel-thread').count(), 0, 'what was found takes the chat’s place');
      await page.screenshot({ path: `${OUT}/camera-panel-barcode.png` });
      await found.getByRole('button', { name: 'Select: ' + OIL.name }).click();
      await page.locator('.pf-camera', { hasText: 'Chosen from the camera: ' + OIL.name }).waitFor();
      assert.strictEqual(await page.locator('.pf-code').innerText(), OIL.barcode);
      await page.getByRole('button', { name: 'Copy ' + OIL.barcode }).click();
      await page.waitForFunction(code => navigator.clipboard.readText().then(text => text === code), OIL.barcode);
      await page.fill('.panel-find .scan-input', 'sugar');
      await page.locator('.pf-row', { hasText: 'Sugar 1 kg' }).waitFor();
      assert.strictEqual(await page.locator('.pf-camera').count(), 0, 'typing a name replaces what the camera chose');
      await page.setViewportSize({ width: 1366, height: 900 });
      step('side panel: Select shows the code the till scans, ready to copy; typing a name takes over');

      // Photos for two products, which finding by look learns once it is turned on.
      for (const [product, picture] of [[OIL, phonePhoto], [RICE, ricePhoto]]) {
        const file = path.join(work, `phone-${product.id}.png`);
        fs.writeFileSync(file, png(320, 320, picture));
        await page.goto(`${BASE}/photos/${product.id}`, { waitUntil: 'networkidle' });
        await page.locator('h1', { hasText: product.name }).waitFor();
        await page.locator('input[type=file]').first().setInputFiles(file);
        await page.getByText('All 5 photos made').waitFor({ timeout: 90000 });
      }
      step('two products have photos');
    });

    await withCamera({ name: 'bottle', width: 320, height: 320, colourAt: phonePhoto }, async (page) => {
      await page.setViewportSize({ width: 420, height: 860 });
      await page.goto(BASE + '/panel', { waitUntil: 'networkidle' });
      let found = await findWithCamera(page);
      assert.strictEqual(await found.locator('h2').innerText(), 'No product found');
      const said = await found.innerText();
      assert.ok(said.includes('Only barcodes are read'), said);
      assert.ok(said.includes('Take it again closer'), said);
      assert.strictEqual(modelRequests, 0);
      await page.screenshot({ path: `${OUT}/camera-panel-nothing.png` });
      await found.getByRole('button', { name: 'Open Settings' }).click();
      await page.waitForURL(/\/settings/);
      step('with finding by look off, a photo without a barcode finds nothing and says where to turn it on');

      const setting = page.locator('.camera-search-setting');
      await setting.getByRole('button', { name: 'Turn on' }).click();
      await setting.getByText('On. 2 of 2 products with photos learned.').waitFor({ timeout: 60000 });
      assert.strictEqual(modelRequests, 1, 'the model is downloaded once');
      for (const product of [OIL, RICE]) {
        const folder = fs.readdirSync(path.join(dataFolder, 'Product photos')).find(f => f.startsWith(product.id + ' '));
        assert.ok(fs.existsSync(path.join(dataFolder, 'Product photos', folder, 'visual.json')), 'nothing learned for ' + product.name);
      }
      step('turned on: the model comes from the mirror, checked, and both products’ photos are learned');

      const before = filesUnder(dataFolder);
      await page.goto(BASE + '/panel', { waitUntil: 'networkidle' });
      found = await findWithCamera(page);
      assert.strictEqual(await found.locator('h2').innerText(), 'Possible matches');
      const rows = found.locator('.cm-item');
      const best = await rows.first().innerText();
      assert.ok(best.includes(OIL.name), best);
      assert.ok(best.includes('Best match') && /Match score 0\.\d\d/.test(best), best);
      assert.ok((await found.innerText()).includes('Choose a product only when its photo and name are right'));
      for (let i = 1; i < await rows.count(); i++) {
        const other = await rows.nth(i).innerText();
        assert.ok(!other.includes('Best match') && other.includes('Match score'), other);
      }
      await page.screenshot({ path: `${OUT}/camera-panel-look.png` });
      await found.getByRole('button', { name: 'Select: ' + OIL.name }).click();
      await page.locator('.pf-camera', { hasText: 'Chosen from the camera: ' + OIL.name }).waitFor();
      assert.strictEqual(await page.locator('.pf-code').innerText(), OIL.barcode);
      assert.deepStrictEqual(filesUnder(dataFolder), before, 'the photo looked for is not kept');
      step('by look: the oil comes first as the best match with its score, the person selects it, and the photo is not kept');

      // A better model, offered by a later version of the app: chosen by the owner, never by the app. It is downloaded while the one
      // working goes on, the photos are learned again with it, and the old model is deleted once it works.
      await page.goto(BASE + '/settings', { waitUntil: 'networkidle' });
      const modelCard = page.locator('.camera-model-setting');
      await modelCard.waitFor();
      assert.match(await modelCard.innerText(), /Using tiny@1 \(\d+ KB\)/);
      assert.ok((await modelCard.locator('.camera-better').innerText()).startsWith('A better model is available: tiny@2'), await modelCard.innerText());
      assert.strictEqual(betterRequests, 0, 'the app does not switch by itself');
      assert.strictEqual(JSON.parse(fs.readFileSync(settingsFile, 'utf8')).CameraSearch.Model || '', '');
      await modelCard.screenshot({ path: `${OUT}/camera-model-offer.png` });
      await modelCard.getByLabel('Model').selectOption('tiny@2');
      await modelCard.getByRole('button', { name: 'Use this model' }).click();
      await page.locator('.camera-model-setting', { hasText: 'Using tiny@2' }).waitFor({ timeout: 60000 });
      await page.locator('.camera-search-setting').getByText('On. 2 of 2 products with photos learned.').waitFor({ timeout: 60000 });
      assert.strictEqual(betterRequests, 1);
      assert.strictEqual(modelRequests, 1, 'the model working is not downloaded again');
      assert.strictEqual(JSON.parse(fs.readFileSync(settingsFile, 'utf8')).CameraSearch.Model, 'tiny@2', 'the choice is kept');
      for (const product of [OIL, RICE]) {
        const folder = fs.readdirSync(path.join(dataFolder, 'Product photos')).find(f => f.startsWith(product.id + ' '));
        const learned = JSON.parse(fs.readFileSync(path.join(dataFolder, 'Product photos', folder, 'visual.json'), 'utf8'));
        assert.strictEqual(learned.Model, 'tiny@2', 'the photos of ' + product.name + ' are learned again with the new model');
      }
      const kept = fs.readdirSync(path.join(work, 'models'));
      assert.strictEqual(kept.length, 1, 'the old model is deleted once the new one works: ' + kept);
      assert.strictEqual(await modelCard.locator('.camera-better').count(), 0, 'nothing better is left to offer');
      await modelCard.screenshot({ path: `${OUT}/camera-model-switched.png` });
      await page.goto(BASE + '/panel', { waitUntil: 'networkidle' });
      const again = await findWithCamera(page);
      assert.strictEqual(await again.locator('h2').innerText(), 'Possible matches');
      assert.ok((await again.locator('.cm-item').first().innerText()).includes(OIL.name));
      step('a better model is offered, chosen by the owner, downloaded once, the photos learned again, the old model deleted, and finding by look goes on');
    });

    assert.deepStrictEqual(errors, [], 'console or page errors: ' + errors.join('\n'));
    console.log('No console or page errors.');
  } finally {
    stopApp(app);
    modelServer.close();
  }
})().catch(error => {
  console.error(error);
  process.exit(1);
});
