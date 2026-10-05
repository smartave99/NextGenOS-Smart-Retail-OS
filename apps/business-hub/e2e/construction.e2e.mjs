// A contractor: projects, a progress bill with retention, a payment, costs, a change to the contract, an advance.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('construction');
const step = (s) => console.log('✓ ' + s);
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Test Builders', industry: 'construction' });
  await signIn(page, hub);
  const side = await page.getByRole('navigation', { name: 'Main' }).innerText();
  assert.match(side, /Projects/); assert.doesNotMatch(side, /Tables|Kitchen|Desk|Bookings|New /);
  step('a contractor sees Projects, not tables or the library desk');

  await go(page, 'Projects');
  await page.getByRole('link', { name: /P-001/ }).waitFor();
  assert.strictEqual(await page.locator('.tbl tbody tr').count(), 2);
  await shot(page, '1-projects');
  step('two running projects with contract, billed and to-come-in figures');

  await page.getByRole('link', { name: /P-002/ }).click();
  await page.getByRole('heading', { name: /P-002/ }).waitFor();
  assert.match(await page.locator('main').innerText(), /Advance/);
  await page.getByRole('link', { name: 'Projects' }).first().click().catch(() => {});
  await go(page, 'Projects');
  await page.getByRole('link', { name: /P-001/ }).click();
  await page.getByRole('heading', { name: /P-001/ }).waitFor();
  const owedBefore = await page.locator('#owed').innerText();
  const billedBefore = await page.locator('#billed').innerText();
  await shot(page, '2-overview');
  step('project P-001: ' + billedBefore + ' billed, ' + owedBefore + ' still to come in');

  // A progress bill
  await page.getByRole('tab', { name: 'New progress bill' }).click();
  const inputs = page.locator('input.qty');
  await inputs.first().waitFor();
  const count = await inputs.count();
  assert.ok(count >= 4, 'one box for each item of work');
  await page.getByLabel(/Built to date: Brickwork walls/).fill('80');
  await page.getByLabel(/Built to date: Roof slab/).fill('60');
  await page.locator('#make-bill').click();
  await page.waitForURL(/\/documents\/\d+$/);
  await page.locator('.receipt').waitFor();
  const bill = await page.locator('.receipt').innerText();
  assert.match(bill, /Progress bill/);
  assert.match(bill, /Retention/);
  assert.match(bill, /CGST/);
  await shot(page, '3-bill');
  step('a progress bill with the tax and the retention held back');

  // Back on the project: more is billed and owed; record the payment
  await page.goBack();
  await page.getByRole('heading', { name: /P-001/ }).waitFor();
  await page.getByRole('tab', { name: 'Overview' }).click();
  await page.waitForFunction((b) => document.querySelector('#billed')?.innerText !== b, billedBefore);
  step('the project shows the new bill');
  await page.getByRole('tab', { name: 'Bills' }).click();
  await page.locator('.tbl tbody tr').first().waitFor();
  await page.getByRole('button', { name: 'Payment received' }).last().click();
  await page.locator('#save-bill-payment').click();
  await page.getByText('Payment saved.').waitFor();
  step('a payment is recorded against a bill (the full balance)');

  // A cost and a change to the contract
  await page.getByRole('tab', { name: 'Costs' }).click();
  await page.getByLabel('Amount').fill('18500');
  await page.getByLabel('What was it for').fill('Sand and aggregate');
  await page.locator('#add-cost').click();
  await page.getByText('Sand and aggregate').waitFor();
  step('a cost is added');

  await page.getByRole('tab', { name: 'Changes' }).click();
  await page.getByLabel('What changes').fill('Extra door in the back wall');
  await page.getByLabel(/Amount \(before tax\)/).fill('12000');
  await page.locator('#add-variation').click();
  await page.getByText('Extra door in the back wall').waitFor();
  await page.getByRole('button', { name: 'Client agreed' }).last().click();
  await page.getByText(/Agreed: it is now part of the contract/).waitFor();
  step('a change is proposed and agreed: it joins the contract');

  await page.getByRole('tab', { name: 'Items of work' }).click();
  await page.getByText('Extra door in the back wall').first().waitFor();
  step('the extra work is in the list of items');

  // Wrong input is refused in words
  await page.getByRole('tab', { name: 'Costs' }).click();
  await page.getByLabel('Amount').fill('lots');
  await page.getByLabel('What was it for').fill('Something');
  await page.locator('#add-cost').click();
  assert.match(await page.locator('.notice.error').innerText(), /number/i);
  step('a cost typed as "lots" is refused');

  // The report of money owed lists the client
  await go(page, 'Reports');
  await page.getByRole('heading', { name: 'Owed to you' }).waitFor();
  assert.match(await page.locator('main').innerText(), /Singh|Bright/);
  step('the report of money owed names the clients');
} finally {
  await browser.close();
  if (problems.length) console.log('browser problems:', problems);
  await hub.stop();
  process.exitCode = problems.length ? 1 : process.exitCode;
}
