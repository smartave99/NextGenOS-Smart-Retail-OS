// Items in a spreadsheet, in the browser (the older POS's staff import launcher and Excel product screens, merge, products tools F): a sheet to fill in, a file with a row that is wrong (listed with
// its row, nothing can be written), the fixed file (what would be added), writing it, sending the items out and bringing the same file back (everything is as it is).
import assert from 'node:assert';
import { writeFileSync, mkdtempSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('itemsheet');
const step = (s) => console.log('✓ ' + s);
const folder = mkdtempSync(join(tmpdir(), 'hub-sheet-'));
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'Products');
  await page.locator('#items-sheet').click();
  await page.locator('#sheet-file').waitFor();
  const template = await page.request.get(hub.url + '/sheets/items-template.csv');
  assert.strictEqual(template.status(), 200);
  assert.match(await template.text(), /Name,Category,Barcode,SKU,Unit,Price/);
  step('a sheet to fill in can be downloaded, with the columns of the shop\'s country');

  const bad = join(folder, 'items-bad.csv');
  writeFileSync(bad, 'Name,Category,Barcode,Price,Tax,Opening stock\nRice,Grocery,8900000000011,60,5,100\nSoap,Home,8900000000028,abc,18,\n,Home,,10,,\n');
  await page.locator('#sheet-file').setInputFiles(bad);
  await page.locator('#sheet-problems').waitFor();
  const listed = await page.locator('#sheet-problems').innerText();
  assert.match(listed, /Row 3 \(Soap\): The price/);
  assert.match(listed, /Row 4: There is no name/);
  assert.strictEqual(await page.locator('#sheet-write').count(), 0, 'nothing can be written while there are rows to fix');
  await shot(page, '1-problems');
  step('a file with a wrong row lists every wrong row with its number and says nothing can be written');

  const good = join(folder, 'items.csv');
  writeFileSync(good, 'Name,Category,Barcode,Price,Tax,Opening stock\nRice,Grocery,8900000000011,60,5,100\nSoap,Home,8900000000028,35.50,18,\n');
  await page.locator('#sheet-file').setInputFiles(good);
  await page.locator('#sheet-summary', { hasText: '2 to add' }).waitFor();
  await shot(page, '2-report');
  assert.strictEqual((await page.locator('#sheet-lines tbody tr').count()), 2);
  await page.locator('#sheet-write').click();
  await page.getByText(/Done: 2 added, 0 changed, 1 opening stock counted/).first().waitFor();
  step('the fixed file shows two items to add, and writing them adds both (with the opening stock counted)');

  await go(page, 'Products');
  const riceRow = page.locator('tbody tr', { hasText: 'Rice' });
  await riceRow.waitFor();
  assert.match(await riceRow.innerText(), /100/);
  const out = await page.request.get(hub.url + '/sheets/items.csv');
  assert.strictEqual(out.status(), 200);
  const sent = await out.text();
  assert.match(sent, /Rice/);
  assert.match(sent, /Soap/);
  step('the items are in the shop with their stock, and go out again as a file');

  const back = join(folder, 'items-sent.csv');
  writeFileSync(back, sent);
  await page.locator('#items-sheet').click();
  await page.locator('#sheet-file').setInputFiles(back);
  await page.locator('#sheet-summary', { hasText: '0 to add' }).waitFor();
  assert.match(await page.locator('#sheet-summary').innerText(), /0 to change, 2 already as they are/);
  assert.strictEqual(await page.locator('#sheet-write').count(), 0, 'nothing to write when everything is as it is');
  step('the file that went out comes back as "everything is as it is": nothing to write');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nItems in a spreadsheet work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
