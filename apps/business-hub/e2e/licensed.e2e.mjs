// The release as a customer gets it: the real Hub program (names hidden, no test stand-in for the licence) brought into use with a key from the
// real Licence Studio. Run through licensing/e2e/hub-e2e.mjs, which publishes and protects the program and sets these variables:
//   HUB_HOST_DLL (the published program), HUB_E2E_KEY (a licence key from the Studio), HUB_E2E_BRAND (the name on that licence).
import assert from 'node:assert';
import { mkdtempSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { startHub, launch, newPage, setUp, signIn, go } from './lib.mjs';

const key = process.env.HUB_E2E_KEY;
const brandName = process.env.HUB_E2E_BRAND;
if (!process.env.HUB_HOST_DLL || !key || !brandName) { console.error('Run through licensing/e2e/hub-e2e.mjs'); process.exit(2); }

const data = mkdtempSync(join(tmpdir(), 'hub-real-'));
const step = (s) => console.log('✓ ' + s);
const browser = await launch();
const problems = [];
let hub;
try {
  hub = await startHub([`--Hub:DataFolder=${data}`]);
  const page = await newPage(browser, []);

  // ---- no licence yet --------------------------------------------------------------------------------------------------------------
  const first = await page.goto(hub.url + '/');
  assert.strictEqual(first.status(), 402);
  assert.match(await page.locator('body').innerText(), /needs a licence/);
  for (const path of ['/setup', '/login', '/sell', '/export/sales.csv', '/_framework/blazor.web.js']) {
    assert.strictEqual((await page.request.get(hub.url + path)).status(), 402, path);
  }
  step('the protected program, with no licence, refuses every address with 402');

  await page.getByLabel('Licence key').fill('NGOS-AAAAA-BBBBB-CCCCC-DDDDD');
  await page.getByRole('button', { name: 'Activate' }).click();
  await page.locator('.problem').waitFor();
  assert.ok((await page.locator('.problem').innerText()).length > 10, 'a key the Studio does not know is refused in words');
  assert.strictEqual((await page.request.get(hub.url + '/login')).status(), 402, 'a refused key opens nothing');
  step('a made-up key is refused by the Studio, and nothing opens');

  // ---- a real key ------------------------------------------------------------------------------------------------------------------
  await page.getByLabel('Licence key').fill(key);
  await page.getByRole('button', { name: 'Activate' }).click();
  await page.waitForURL('**/setup', { timeout: 60000 });
  assert.match(await page.locator('.public-brand').innerText(), new RegExp(brandName), 'the licence brings the customer\'s own name');
  step(`the Studio's key activates this PC; the program now shows "${brandName}", not our name`);

  const body = await page.locator('body').innerText();
  // (another customer's name, written in two pieces so this file does not carry it)
  assert.ok(!new RegExp('Smart ' + 'Avenue|smart' + 'ave99', 'i').test(body), 'no other customer\'s name on the screen');

  await setUp(page, hub, { name: 'Luzon Fresh Mart', country: 'Philippines', industry: 'retail', demo: true });
  await signIn(page, hub);
  assert.match(await page.locator('.brand-name').first().innerText(), new RegExp(brandName));
  step('set up a shop in the Philippines with the sample company and signed in');

  await go(page, 'New sale');
  const scan = page.locator('#scan');
  await scan.waitFor();
  await scan.fill('8901000000019');
  await scan.press('Enter');
  await page.locator('.line').first().waitFor();
  const total = await page.locator('#total').innerText();
  assert.match(total, /^₱[\d,]+\.\d\d$/);
  await page.getByLabel('Amount received').fill('5000');
  await page.getByRole('button', { name: 'Add payment' }).click();
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /Luzon Fresh Mart/);
  assert.match(receipt, /VAT/);
  assert.ok(!/GST/.test(receipt), 'no Indian tax words on a Philippine bill');
  assert.ok(receipt.includes(total));
  step('a sale in pesos with VAT is rung up, paid and billed');
  await page.context().close();

  // ---- the look: what the licence from the Studio allows ("theme": colours and logo, not the name) --------------------------------
  const page2 = await newPage(browser, []);
  await signIn(page2, hub);
  await go(page2, 'Settings');
  await page2.getByRole('tab', { name: 'Look' }).click();
  await page2.locator('main h2', { hasText: /^Look$/ }).waitFor();
  assert.strictEqual(await page2.locator('#b-name').count(), 0, 'a "theme" licence from the Studio cannot rename the program');
  await page2.locator('#b-main').fill('#0a7d4b');
  await page2.locator('#save-look').click();
  await page2.waitForURL(/tab=look&saved=1/);
  assert.strictEqual(await page2.evaluate(() => getComputedStyle(document.documentElement).getPropertyValue('--accent').trim()), '#0a7d4b');
  assert.match(await page2.locator('.side .brand-name').innerText(), new RegExp(brandName));
  step('the Studio\'s "theme" licence lets the owner choose the colour, and keeps the licence\'s name');
  await page2.context().close();

  // ---- restart: the licence and the data are still there ---------------------------------------------------------------------------
  await hub.stop();
  hub = await startHub([`--Hub:DataFolder=${data}`]);
  const again = await newPage(browser, problems);
  await signIn(again, hub);
  await go(again, 'Reports');
  await again.getByRole('heading', { name: /Reports|Sales/ }).first().waitFor();
  step('after a restart the licence is remembered and the shop is where it was left');
  await again.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe protected Business Hub works with a real licence from the real Licence Studio.');
} catch (e) {
  console.error(e);
  if (hub) console.error('--- program log ---\n' + hub.log().slice(-3000));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
  rmSync(data, { recursive: true, force: true });
}
