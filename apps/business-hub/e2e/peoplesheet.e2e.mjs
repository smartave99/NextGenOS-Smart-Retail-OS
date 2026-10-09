// Customers and suppliers in a spreadsheet, in the browser (merge, the older POS's staff import launcher): a sheet to fill in, a file with wrong rows (listed with their row numbers), the fixed file,
// writing it (a customer's balance goes into the books), and the people going out and coming back as "everything is as it is".
import assert from 'node:assert';
import { writeFileSync, mkdtempSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('peoplesheet');
const step = (s) => console.log('✓ ' + s);
const folder = mkdtempSync(join(tmpdir(), 'hub-people-'));
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'People');
  await page.locator('#people-sheet').click();
  await page.locator('#sheet-file').waitFor();
  const template = await page.request.get(hub.url + '/people-sheets/people-template.csv');
  assert.strictEqual(template.status(), 200);
  assert.match(await template.text(), /Name,Kind,Phone,Email,Address/);
  step('a sheet to fill in can be downloaded');

  const bad = join(folder, 'people-bad.csv');
  writeFileSync(bad, 'Name,Kind,Phone,Credit limit,Balance\nSharma Store,customer,98000 11111,50000,12500.50\nBad one,robot,,,\n,customer,,,\n');
  await page.locator('#sheet-file').setInputFiles(bad);
  await page.locator('#sheet-problems').waitFor();
  const listed = await page.locator('#sheet-problems').innerText();
  assert.match(listed, /Row 3 \(Bad one\): .*not a kind of person/);
  assert.match(listed, /Row 4: There is no name/);
  assert.strictEqual(await page.locator('#sheet-write').count(), 0);
  await shot(page, '1-problems');
  step('wrong rows are listed with their numbers and nothing can be written');

  const good = join(folder, 'people.csv');
  writeFileSync(good, 'Name,Kind,Phone,Credit limit,Balance\nSharma Store,customer,98000 11111,50000,12500.50\nNational Foods,supplier,98000 22222,,8000\n');
  await page.locator('#sheet-file').setInputFiles(good);
  await page.locator('#sheet-summary', { hasText: '2 to add' }).waitFor();
  await page.locator('#sheet-write').click();
  await page.getByText(/Done: 2 added, 0 changed, 2 opening balance/).first().waitFor();
  step('the fixed file adds both people with their opening balances');

  await go(page, 'Books');
  await page.getByText('Balance brought across', { exact: false }).first().waitFor().catch(() => {});
  const out = await page.request.get(hub.url + '/people-sheets/people.csv');
  assert.strictEqual(out.status(), 200);
  const sent = await out.text();
  assert.match(sent, /Sharma Store/);
  assert.match(sent, /National Foods/);
  await page.goto(hub.url + '/people/sheet');
  const back = join(folder, 'people-sent.csv');
  writeFileSync(back, sent);
  await page.locator('#sheet-file').setInputFiles(back);
  await page.locator('#sheet-summary', { hasText: '0 to add' }).waitFor();
  assert.match(await page.locator('#sheet-summary').innerText(), /0 to change, 2 already as they are/);
  step('the people go out as a file and come back as "everything is as it is"');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nPeople in a spreadsheet work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
