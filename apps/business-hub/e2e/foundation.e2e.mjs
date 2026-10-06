// What every business needs: no licence, no data; roles that really limit people; settings that change the bills; other countries' tax.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('foundation');
const step = (s) => console.log('✓ ' + s);
let hub;
const pages = [];
const fresh = async (list = problems) => { const p = await newPage(browser, list); pages.push(p); return p; };
const endPhase = async (label) => {
  for (const p of pages.splice(0)) await p.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems: ' + label);
  problems.length = 0;
  await hub.stop();
};
try {
  // ---- no licence ----------------------------------------------------------------------------------------------------------------
  hub = await startHub(['--E2E:Licensed=false']);
  {
    const page = await fresh([]);
    const response = await page.goto(hub.url + '/');
    assert.strictEqual(response.status(), 402);
    assert.match(await page.locator('body').innerText(), /needs a licence/);
    await page.getByLabel('Licence key').fill('hello');
    await page.getByRole('button', { name: 'Activate' }).click();
    assert.match(await page.locator('.problem').innerText(), /does not look like a licence key/);
    for (const path of ['/setup', '/login', '/sell', '/export/sales.csv', '/_framework/blazor.web.js']) {
      const r = await page.request.get(hub.url + path);
      assert.strictEqual(r.status(), 402, path);
    }
    await shot(page, '0-no-licence');
    step('without a licence: every address says 402, the page offers a place for the key and refuses a wrong one');
  }
  await endPhase('no licence');

  // ---- a blank shop in India: setup rules, roles ---------------------------------------------------------------------------------------
  hub = await startHub();
  const page = await fresh();
  await page.goto(hub.url + '/');
  await page.waitForURL('**/setup');
  await page.getByLabel('Business name').fill('Blank Shop');
  await page.getByLabel('Country').selectOption({ label: 'India' });
  await page.getByRole('button', { name: 'Next' }).click();
  await page.locator('.notice.error', { hasText: /State/i }).waitFor();
  await page.getByLabel('State').selectOption({ label: 'Karnataka' });
  await page.getByLabel(/GSTIN/).fill('not a gstin');
  await page.getByRole('button', { name: 'Next' }).click();
  await page.locator('.notice.error', { hasText: /GSTIN/ }).waitFor();
  await page.getByLabel(/GSTIN/).fill('');
  await page.getByRole('button', { name: 'Next' }).click();
  await page.getByRole('button', { name: /^Retail store/ }).click();
  await page.getByRole('button', { name: 'Next' }).click();
  await page.getByLabel('Your name').fill('Olivia Owner');
  await page.getByLabel('User name').fill('owner');
  await page.getByLabel('Password (at least 8 characters)').fill('short');
  await page.getByLabel('Password again').fill('short');
  await page.getByRole('button', { name: 'Next' }).click();
  await page.locator('.notice.error', { hasText: /8 characters/ }).waitFor();
  await page.getByLabel('Password (at least 8 characters)').fill('a-long-test-password');
  await page.getByLabel('Password again').fill('a-different-password');
  await page.getByRole('button', { name: 'Next' }).click();
  await page.locator('.notice.error', { hasText: /not the same/ }).waitFor();
  await page.getByLabel('Password again').fill('a-long-test-password');
  await page.getByRole('button', { name: 'Next' }).click();
  await page.getByLabel('Fill with a sample business so I can look around').uncheck();
  await page.getByRole('button', { name: 'Finish' }).click();
  await page.waitForURL('**/login');
  await page.goto(hub.url + '/setup');
  await page.waitForURL('**/login');
  step('setup: a state is required, a wrong tax number, short and different passwords are refused in words; after setup the page is closed');

  await signIn(page, hub);
  await go(page, 'Products');
  assert.match(await page.locator('.empty').innerText(), /Nothing here yet/);
  await page.locator('#add-item').click();
  await page.getByLabel('Name', { exact: true }).fill('Tea cup');
  await page.getByLabel(/Price/).fill('118');
  await page.locator('#save-item').click();
  await page.getByText('Tea cup').first().waitFor();
  await go(page, 'New sale');
  await page.locator('#scan').fill('cup');
  await page.locator('#scan').press('Enter');
  await page.locator('#complete').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /CGST/);
  assert.match(receipt, /₹118\.00/);
  step('a blank shop: first product, first sale with one tap on Complete, paid in cash by default');

  // ---- roles ---------------------------------------------------------------------------------------------------------------------
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'People' }).click();
  await page.getByLabel('Name', { exact: true }).fill('Tara Till');
  await page.getByLabel('User name', { exact: true }).fill('till');
  await page.getByLabel('Role', { exact: true }).selectOption({ label: 'Cashier / front desk' });
  await page.locator('#u-pass').fill('another-good-password');
  await page.locator('#add-user').click();
  await page.getByText(/Added\./).waitFor();
  step('the owner adds a cashier');

  const cashier = await fresh();
  await cashier.goto(hub.url + '/login');
  for (let i = 0; i < 2; i += 1) {
    await cashier.getByLabel('User name').fill('till');
    await cashier.getByLabel('Password', { exact: true }).fill('wrong-password');
    await cashier.getByRole('button', { name: 'Sign in' }).click();
    await cashier.locator('.notice.error').waitFor();
    await cashier.locator('.notice.error', { hasText: /not right/ }).waitFor();
  }
  await signIn(cashier, hub, 'till', 'another-good-password');
  const nav = await cashier.getByRole('navigation', { name: 'Main' }).innerText();
  assert.doesNotMatch(nav, /Settings|Reports|Buying/);
  await cashier.goto(hub.url + '/settings');
  await cashier.getByText('This is not for your role').waitFor();
  const csv = await cashier.request.get(hub.url + '/export/sales.csv', { maxRedirects: 0 });
  assert.notStrictEqual(csv.status(), 200);
  step('a cashier does not see Settings, Reports or Buying, is told so on the address bar, and cannot download reports');

  // Switching the cashier off ends their session
  await page.getByRole('button', { name: 'Switch off' }).last().click();
  await cashier.goto(hub.url + '/');
  await cashier.waitForURL(/\/login/);
  step('a person switched off is signed out at their next move');

  // Locking after five wrong passwords
  await page.getByRole('button', { name: 'Switch on' }).click();
  const attacker = await fresh([]);
  await attacker.goto(hub.url + '/login');
  for (let i = 0; i < 5; i += 1) {
    await attacker.getByLabel('User name').fill('till');
    await attacker.getByLabel('Password', { exact: true }).fill('guess-' + i + '-guess');
    await attacker.getByRole('button', { name: 'Sign in' }).click();
    await attacker.locator('.notice.error').waitFor();
  }
  await attacker.getByLabel('User name').fill('till');
  await attacker.getByLabel('Password', { exact: true }).fill('another-good-password');
  await attacker.getByRole('button', { name: 'Sign in' }).click();
  await attacker.locator('.notice.error', { hasText: /Too many wrong passwords/ }).waitFor();
  step('after five wrong passwords the account is locked, even for the right password');

  // ---- settings change the bills ----------------------------------------------------------------------------------------------------------
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Tax' }).click();
  await page.getByText(/not been checked by a local tax adviser/).waitFor();
  const rate = page.getByLabel('Rate of GST 18%').or(page.locator('input[aria-label^="Rate of"]').nth(0));
  assert.ok(await page.locator('input[aria-label^="Rate of"]').count() >= 2);
  step('the tax page says plainly that the rates were not checked by an adviser, and lists them to correct');
  await page.getByRole('tab', { name: 'Parts and words' }).click();
  await page.getByLabel('Customer (one)').fill('Client');
  await page.getByLabel('Customers (many)').fill('Clients');
  // Saving reloads the page: wait for that reload itself (the address does not change, so waiting for the address would not wait for it).
  await Promise.all([page.waitForEvent('load'), page.locator('#save-parts').click()]);
  await page.getByRole('heading', { name: 'Settings' }).waitFor();
  await go(page, 'People');
  await page.getByRole('tab', { name: 'Clients' }).waitFor();
  step('a renamed word shows up on the screens');

  // ---- Philippines ---------------------------------------------------------------------------------------------------------------------
  await endPhase('India');
  hub = await startHub();
  const ph = await fresh();
  await setUp(ph, hub, { name: 'Manila Mart', country: 'Philippines', industry: 'retail', demo: true });
  await signIn(ph, hub);
  await go(ph, 'New sale');
  await ph.locator('#scan').fill('8901000000019');
  await ph.locator('#scan').press('Enter');
  await ph.locator('.line').first().waitFor();
  await ph.locator('#complete').click();
  await ph.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const phReceipt = await ph.locator('.receipt').innerText();
  assert.match(phReceipt, /₱/);
  assert.match(phReceipt, /VAT/);
  assert.doesNotMatch(phReceipt, /CGST|SGST/);
  await shot(ph, '1-philippines');
  step('Philippines: pesos and VAT, no GST words');

  // ---- United States: the shop sets its own sales tax -----------------------------------------------------------------------------------
  await endPhase('Philippines');
  hub = await startHub();
  const us = await fresh();
  await setUp(us, hub, { name: 'Austin Shop', country: 'United States', industry: 'retail', demo: false, salesTax: '8' });
  await signIn(us, hub);
  await go(us, 'Products');
  await us.locator('#add-item').click();
  await us.getByLabel('Name', { exact: true }).fill('Mug');
  await us.getByLabel(/Price/).fill('10');
  await us.locator('#save-item').click();
  await us.getByText('Mug').first().waitFor();
  await go(us, 'New sale');
  await us.locator('#scan').fill('mug');
  await us.locator('#scan').press('Enter');
  await us.locator('#complete').click();
  await us.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const usReceipt = await us.locator('.receipt').innerText();
  assert.match(usReceipt, /\$10\.80/);
  assert.match(usReceipt, /Sales tax/);
  step('United States: the shop\'s own 8% sales tax is added to a $10 mug: $10.80');
  await endPhase('United States');
  hub = null;
} catch (e) {
  if (hub) console.log(hub.log().split('\n').filter((l) => !l.includes('XmlKeyManager') && !l.includes('No XML encryptor')).slice(-40).join('\n'));
  throw e;
} finally {
  await browser.close();
  if (hub) await hub.stop();
  process.exitCode = problems.length ? 1 : process.exitCode;
}
