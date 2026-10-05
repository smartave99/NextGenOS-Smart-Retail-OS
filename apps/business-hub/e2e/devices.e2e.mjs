// Printers and scanners: a receipt printer prints every bill by itself, a drawer opens, labels come out in the label printer's language,
// a dead printer is explained, price tags and posters preview, and a camera reads a barcode into a sale. The printers are stand-ins on this PC that keep what they are sent.
import assert from 'node:assert';
import { writeFileSync, mkdirSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { createRequire } from 'node:module';
import { build, startHub, launch, newPage, setUp, signIn, shots, go, fakePrinter, deadPort } from './lib.mjs';

build();
const hub = await startHub();
const problems = [];
const shot = shots('devices');
const step = (s) => console.log('✓ ' + s);
const receipts = await fakePrinter();
const labels = await fakePrinter();
const dead = await deadPort();

// A short film of a barcode for the camera: Chromium's fake camera plays a file of JPEG pictures.
const require = createRequire(import.meta.url);
const sharp = require('../../storefront-web-mobile/node_modules/sharp');
const work = join(tmpdir(), 'hub-camera-' + process.pid);
mkdirSync(work, { recursive: true });
let browser;
try {
  // The Hub makes the barcode picture (this also tests /barcode/*.png): fetched once the Hub is signed in, below. A page is needed first.
  const probe = await launch();
  const probePage = await newPage(probe, []);
  await setUp(probePage, hub, { name: 'Corner Mart', industry: 'retail' });
  await signIn(probePage, hub);
  const pngResponse = await probePage.request.get(hub.url + '/barcode/ean13.png?data=8901000000019&w=420&h=140');
  console.log('barcode picture:', pngResponse.status(), pngResponse.headers()['content-type']);
  const png = Buffer.from(await pngResponse.body());
  assert.ok(png.length > 200);
  const frame = await sharp({ create: { width: 640, height: 480, channels: 3, background: '#ffffff' } }).composite([{ input: png, gravity: 'center' }]).jpeg({ quality: 92 }).toBuffer();
  writeFileSync(join(work, 'barcode.mjpeg'), Buffer.concat(Array.from({ length: 90 }, () => frame)));
  await probe.close();

  browser = await launch(['--use-fake-ui-for-media-stream', '--use-fake-device-for-media-stream', `--use-file-for-fake-video-capture=${join(work, 'barcode.mjpeg')}`]);
  const page = await newPage(browser, problems, { width: 1360, height: 860 }, ['camera']);
  await signIn(page, hub);

  // ---- a receipt printer ----------------------------------------------------------------------------------------------------------
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Printers' }).click();
  await page.locator('#add-printer').click();
  await page.getByLabel('Name', { exact: true }).fill('Counter');
  await page.getByLabel('Address of the printer').fill(`127.0.0.1:${receipts.port}`);
  await page.getByLabel('Paper', { exact: true }).selectOption('58');
  await page.getByLabel('Print every finished bill by itself').check();
  await page.locator('#save-printer').click();
  await page.getByText(/Saved\. Press/).waitFor();
  await page.getByRole('button', { name: 'Test page' }).click();
  await page.getByText('A test page was sent to Counter.').waitFor();
  await receipts.bytes().length || await new Promise((r) => setTimeout(r, 300));
  assert.ok(receipts.bytes().subarray(0, 2).equals(Buffer.from([0x1b, 0x40])), 'starts by resetting the printer');
  assert.match(receipts.text(), /Printer test/);
  assert.match(receipts.text(), /Corner Mart/);
  step('a receipt printer is added by its network address; its test page arrives in ESC/POS');
  receipts.clear();

  // ---- every bill prints by itself --------------------------------------------------------------------------------------------------
  await go(page, 'New sale');
  await page.locator('#scan').fill('8901000000019');
  await page.locator('#scan').press('Enter');
  await page.locator('.line').first().waitFor();
  await page.locator('#complete').click();
  await page.getByText('Printed on Counter.').waitFor();
  await new Promise((r) => setTimeout(r, 300));
  const bill = receipts.text();
  assert.match(bill, /Corner Mart/); assert.match(bill, /Tax Invoice/); assert.match(bill, /Basmati rice/); assert.match(bill, /CGST/); assert.match(bill, /TOTAL/);
  assert.match(bill, /Rs\d/);
  assert.ok(bill.includes('\x1dVB'), 'the paper is cut');
  step('a finished sale prints by itself: shop, tax invoice, CGST, total, rupees written as Rs, then a cut');
  receipts.clear();

  await page.locator('#print-receipt').click();
  await page.getByText('Printed on Counter.').waitFor();
  step('Print on the receipt printer also works from a bill later');

  await go(page, 'New sale');
  await page.locator('#drawer').click();
  await new Promise((r) => setTimeout(r, 300));
  assert.ok(receipts.bytes().includes(Buffer.from([0x1b, 0x70, 0x00, 0x19, 0xfa])), 'the drawer pulse');
  step('the cash drawer opens from the counter screen');

  // ---- the camera reads a barcode into the sale ------------------------------------------------------------------------------------------
  await page.locator('#cam-sell').click();
  await page.locator('.scan-video').waitFor();
  await page.locator('.line .nm', { hasText: 'Basmati rice' }).waitFor({ timeout: 20000 });
  await shot(page, '1-camera-sale');
  step('the camera reads the barcode it sees and adds the item to the sale');

  // ---- a label printer, and a dead printer ------------------------------------------------------------------------------------------------
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Printers' }).click();
  await page.locator('#add-printer').click();
  await page.getByLabel('Name', { exact: true }).fill('Shelf labels');
  await page.getByLabel('It prints').selectOption('label');
  await page.getByLabel('Language of the label printer').selectOption('Tspl');
  await page.getByLabel('Address of the printer').fill(`127.0.0.1:${labels.port}`);
  await page.locator('#save-printer').click();
  await page.getByText(/Saved\. Press/).waitFor();

  await page.locator('#add-printer').click();
  await page.getByLabel('Name', { exact: true }).fill('Broken');
  await page.getByLabel('Address of the printer').fill(`127.0.0.1:${dead}`);
  await page.locator('#save-printer').click();
  await page.getByText(/Saved\. Press/).waitFor();
  await page.locator('tr', { hasText: 'Broken' }).getByRole('button', { name: 'Test page' }).click();
  await page.locator('.notice.error', { hasText: /could not be reached/ }).waitFor();
  assert.match(await page.locator('.notice.error').innerText(), /Check that it is on/);
  step('a printer that is off is explained in plain words');

  await go(page, 'Products');
  await page.locator('tr', { hasText: 'Basmati rice' }).getByRole('button', { name: 'Labels' }).click();
  await page.getByLabel('How many labels').fill('3');
  await page.locator('#print-labels').click();
  await page.getByText('Sent to the label printer.').waitFor();
  await new Promise((r) => setTimeout(r, 300));
  assert.match(labels.text(), /SIZE 50 mm,30 mm/);
  assert.match(labels.text(), /Basmati rice 5 kg/);
  assert.match(labels.text(), /"EAN13"/);
  assert.match(labels.text(), /PRINT 3,1/);
  step('three price labels arrive in TSPL with the name, price and EAN-13 barcode');

  await page.locator('#add-item').click();
  await page.locator('#make-barcode').click();
  await page.waitForFunction(() => /^2\d{12}$/.test(document.querySelector('#f-bar').value));
  const made = await page.locator('#f-bar').inputValue();
  assert.match(made, /^2\d{12}$/);
  await page.getByRole('button', { name: 'Cancel' }).click();
  step('"Make a number for me" gives an in-store EAN-13 number: ' + made);

  // ---- posters ----------------------------------------------------------------------------------------------------------------------------
  await go(page, 'Price tags');
  await page.getByLabel('Print Basmati rice 5 kg').check();
  await page.getByLabel('Print Sunflower oil 1 L').check();
  await page.getByLabel('Copies of each').fill('2');
  await page.waitForFunction(() => document.querySelectorAll('.tag').length === 4);
  await page.locator('.tag-code').first().waitFor();
  assert.ok(await page.locator('.tag-code').first().evaluate((img) => img.complete && img.naturalWidth > 50), 'the barcode picture loaded');
  await page.getByLabel('Layout').selectOption('a3');
  await page.locator('.paper.a3').waitFor();
  await shot(page, '2-poster');
  step('price tags and A3 posters preview with barcode pictures, two copies of each');
} finally {
  if (browser) await browser.close();
  await receipts.close(); await labels.close();
  if (problems.length) { console.log('browser problems:', problems); process.exitCode = 1; }
  await hub.stop();
}
