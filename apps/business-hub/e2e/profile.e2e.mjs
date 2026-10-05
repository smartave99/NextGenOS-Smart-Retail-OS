// A business set up the way NextGenOS prepared it: the first page is already filled in, the first items and people are there when the owner finishes, the words and
// the receipt footer are the customer's, and the customer's colour shows as far as the licence allows. A damaged file changes nothing.
import assert from 'node:assert';
import { mkdtempSync, mkdirSync, writeFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { build, startHub, launch, newPage, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('profile');
const step = (s) => console.log('✓ ' + s);
const work = mkdtempSync(join(tmpdir(), 'hub-profile-'));
const makeProfile = (name, files) => { const dir = join(work, name); mkdirSync(dir, { recursive: true }); for (const [f, c] of Object.entries(files)) writeFileSync(join(dir, f), typeof c === 'string' ? c : JSON.stringify(c)); return dir; };

const setup = {
  schema: 1,
  business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail' },
  settings: { receiptFooter: 'Salamat po!', paymentMethods: ['cash', 'gcash', 'card'] },
  vocabulary: { item: ['Product', 'Products'] },
  starter: {
    items: [
      { name: 'Rice 5 kg', price: '285.00', kind: 'stock', unit: 'bag', category: 'Grocery', barcode: '4800000000011' },
      { name: 'Gift wrapping', price: 20, kind: 'service' },
    ],
    people: [{ kind: 'supplier', name: 'Manila Wholesale', phone: '+63 2 5555 0100' }],
  },
};

async function finishWizard(page, hub, { demo }) {
  await page.goto(hub.url + '/');
  await page.waitForURL('**/setup');
  await page.getByRole('button', { name: 'Next' }).click();
  await page.getByRole('button', { name: 'Next' }).click();
  await page.getByLabel('Your name').fill('Olivia Owner');
  await page.getByLabel('User name').fill('owner');
  await page.getByLabel('Password (at least 8 characters)').fill('a-long-test-password');
  await page.getByLabel('Password again').fill('a-long-test-password');
  await page.getByRole('button', { name: 'Next' }).click();
  const sample = page.getByLabel('Fill with a sample business so I can look around');
  if (demo) await sample.check(); else await sample.uncheck();
}

let hub;
try {
  const prepared = makeProfile('prepared', { 'setup.json': setup, 'brand.json': { primaryColor: '#0a7d4b', supportPhone: '+63 2 5555 0199' } });

  // ---- the prepared business -------------------------------------------------------------------------------------------------------
  hub = await startHub(['--E2E:White=theme', '--E2E:Brand=Luzon Fresh', `--Hub:ProfileFolder=${prepared}`]);
  let page = await newPage(browser, problems);
  await page.goto(hub.url + '/');
  await page.waitForURL('**/setup');
  await page.locator('#prepared-note').waitFor();
  assert.strictEqual(await page.locator('#name').inputValue(), 'Luzon Fresh Mart');
  assert.strictEqual(await page.locator('#country').inputValue(), 'PH');
  assert.match(await page.locator('#prepared-note').innerText(), /check it and change anything/);
  assert.ok(!/left out/.test(await page.locator('#prepared-note').innerText()), 'a good file reports no problem');
  await shot(page, '1-first-page');
  step('the first page is already filled in from the prepared file (name, country), with a friendly note, and everything can still be changed');

  await page.getByRole('button', { name: 'Next' }).click();
  assert.strictEqual(await page.locator('.choice.on strong').innerText(), 'Retail store', 'the kind of business is chosen');
  await page.getByRole('button', { name: 'Next' }).click();
  await page.getByLabel('Your name').fill('Olivia Owner');
  await page.getByLabel('User name').fill('owner');
  await page.getByLabel('Password (at least 8 characters)').fill('a-long-test-password');
  await page.getByLabel('Password again').fill('a-long-test-password');
  await page.getByRole('button', { name: 'Next' }).click();
  assert.match(await page.locator('#starter-note').innerText(), /Your first 2 items and 1 person will be added/);
  const sample = page.getByLabel('Fill with a sample business so I can look around');
  await sample.uncheck();
  await shot(page, '2-ready');
  await page.getByRole('button', { name: 'Finish' }).click();
  await page.waitForURL('**/login', { timeout: 60000 });
  await signIn(page, hub);
  step('the owner chooses only a name and a password; the prepared business is set up');

  await go(page, 'Products');
  await page.getByText('Rice 5 kg').first().waitFor();
  await page.getByText('Gift wrapping').first().waitFor();
  assert.match(await page.locator('main').innerText(), /285\.00/);
  step('the first items are there, under the customer\'s own word ("Products"), priced in pesos');
  await go(page, 'People');
  await page.getByRole('tab', { name: /Suppliers/ }).click();
  await page.getByText('Manila Wholesale').first().waitFor();
  step('the first people are there');

  assert.strictEqual(await page.evaluate(() => getComputedStyle(document.documentElement).getPropertyValue('--accent').trim()), '#0a7d4b');
  assert.match(await page.locator('.side .brand-name').innerText(), /Luzon Fresh/);
  step('the customer\'s colour shows (the licence allows style) and the licence keeps the name');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Look' }).click();
  await page.locator('#b-main').waitFor();
  assert.strictEqual(await page.locator('#b-main').inputValue(), '', 'the Look page shows only what the owner chose, so the prepared colour stays until the owner picks another');
  assert.strictEqual(await page.evaluate(() => getComputedStyle(document.documentElement).getPropertyValue('--accent').trim()), '#0a7d4b');
  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  await hub.stop();

  // ---- the sample company replaces the starter list (the two are never mixed) -----------------------------------------------------------
  hub = await startHub(['--E2E:White=theme', `--Hub:ProfileFolder=${prepared}`]);
  page = await newPage(browser, problems);
  await finishWizard(page, hub, { demo: true });
  await page.getByRole('button', { name: 'Finish' }).click();
  await page.waitForURL('**/login', { timeout: 60000 });
  await signIn(page, hub);
  await go(page, 'Products');
  await page.locator('table tbody tr').first().waitFor();
  assert.strictEqual(await page.getByText('Rice 5 kg').count(), 0, 'the sample company does not carry the prepared list');
  step('with the sample company chosen, the prepared list is not added on top of it');
  await page.context().close();
  await hub.stop();

  // ---- a damaged file changes nothing --------------------------------------------------------------------------------------------------
  for (const [label, text] of [['not JSON', '{ nope'], ['wrong kind', '[1,2]'], ['future version', '{"schema":9}'], ['mostly wrong', '{"schema":1,"business":{"country":"ZZ"},"starter":{"items":[{"name":"x"}]}}']]) {
    const dir = makeProfile('damaged-' + label.replace(/\W/g, ''), { 'setup.json': text });
    hub = await startHub(['--E2E:Licensed=true', `--Hub:ProfileFolder=${dir}`]);
    page = await newPage(browser, problems);
    await page.goto(hub.url + '/');
    await page.waitForURL('**/setup');
    assert.strictEqual(await page.locator('#name').inputValue(), '', label);
    assert.strictEqual(await page.locator('#starter-note').count(), 0, label);
    await page.context().close();
    await hub.stop();
  }
  step('a damaged or wrong prepared file is ignored: the wizard opens empty and nothing is added');

  // ---- no profile at all: the wizard is as it always was ---------------------------------------------------------------------------
  hub = await startHub(['--E2E:Licensed=true', `--Hub:ProfileFolder=${join(work, 'nowhere')}`]);
  page = await newPage(browser, problems);
  await page.goto(hub.url + '/');
  await page.waitForURL('**/setup');
  assert.strictEqual(await page.locator('#prepared-note').count(), 0);
  assert.strictEqual(await page.locator('#country').inputValue(), 'IN');
  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe prepared setup works.');
} catch (e) {
  console.error(e);
  if (hub) console.error('--- program log ---\n' + hub.log().slice(-3000));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
  rmSync(work, { recursive: true, force: true });
}
