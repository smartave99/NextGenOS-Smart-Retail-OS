// Stock forecasts (blueprint INS-011): "Running low" on the Buying page. Off until switched on; a shop that sold 3 kg of rice a day for four weeks is told, with the figures, that 16 kg will not last the 7 days
// the supplier needs; the reasons are shown; an order is started from the warning; an order is asked for and approved by a person (suggested actions); a warning is set aside; the delivery times and the
// rule's settings are kept. The shop's four weeks of selling are put in by a test-only door of the test program (a real shop cannot be made to wait four weeks).
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('insights');
const step = (s) => console.log('✓ ' + s);
let hub;

try {
  hub = await startHub(['--E2E:Modules=hub,ai', '--E2E:Seed=true']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Wholesale', industry: 'wholesale', demo: false });
  await signIn(page, hub);
  await go(page, 'Buying');
  await page.getByRole('heading', { name: 'Buying', level: 1 }).waitFor();
  assert.strictEqual(await page.locator('#low-stock').count(), 0, 'nothing about running low while stock forecasts are switched off');
  step('with stock forecasts switched off the Buying page has nothing about running low');

  const seeded = await page.request.post(hub.url + '/__e2e/seed-stock');
  assert.strictEqual(seeded.status(), 200);
  await page.reload();
  await page.locator('#low-stock').waitFor();
  assert.match(await page.locator('#low-never').innerText(), /Not checked yet/);
  await page.locator('#low-check').click();
  await page.locator('.notice.ok', { hasText: 'Checked.' }).waitFor();
  assert.match(await page.locator('#low-summary').innerText(), /2 item\(s\) judged/);
  assert.strictEqual(await page.locator('.low-row').count(), 2);
  const rice = page.locator('.low-row', { hasText: 'Basmati rice' });
  const dal = page.locator('.low-row', { hasText: 'Toor dal' });
  const row = await rice.innerText();
  for (const part of ['Basmati rice', '16 kg on the shelf', 'sold 84 kg in the last 28 day(s)', 'about 3 kg a day', 'lasts about 5.3 day(s)', 'National Foods takes 5 day(s) to deliver and you want 2 spare', 'About 26 kg would cover the next 14 day(s)'])
    assert.ok(row.includes(part), 'the warning says: ' + part + '\n' + row);
  const dalText = await dal.innerText();
  for (const part of ['Toor dal', '4 kg on the shelf', 'about 2 kg a day', 'lasts about 2 day(s)', 'takes 4 day(s) to deliver and you want 1 spare', 'About 20 kg would cover the next 12 day(s)'])
    assert.ok(dalText.includes(part), 'the warning says: ' + part + '\n' + dalText);
  assert.match(await page.locator('.low-row').first().innerText(), /Toor dal/, 'the most urgent is first (2 days of the 5 needed, before 5.3 of 7)');
  await shot(page, '1-running-low');
  step('a shop that sold 3 kg of rice and 2 kg of dal a day is told what will not last the days the supplier needs, most urgent first, with the figures in plain words');

  await rice.locator('summary').click();
  assert.match(await rice.locator('details').innerText(), /A quantity is a proposal: look at it before you order\./);
  assert.match(await rice.locator('details').innerText(), /Worked out on .* from bills \d+/);
  step('"Why might this be wrong?" gives the ways the figure could mislead and the bills it rests on');

  await rice.locator('[id^="low-order-"]').click();
  await page.getByRole('dialog', { name: 'New order' }).waitFor();
  assert.strictEqual(await page.locator('#po-supplier option:checked').innerText(), 'National Foods');
  assert.match(await page.getByRole('dialog', { name: 'New order' }).innerText(), /26 × Basmati rice/);
  await page.locator('#save-order').click();
  await page.locator('.notice.ok', { hasText: 'The order is placed.' }).waitFor();
  step('an order is started from the warning with the supplier and the quantity filled in, and placed by a person');

  // Dal: asked for, not ordered by hand. A person who may buy approves; only then is a draft order made.
  await dal.locator('[id^="low-ask-"]').click();
  await page.locator('.notice.ok', { hasText: 'Asked for.' }).waitFor();
  await page.locator('#approvals').waitFor();
  assert.match(await page.locator('#approvals').innerText(), /Draft an order to National Foods for 20 kg of Toor dal, .* in all\./);
  assert.strictEqual(await page.locator('#approvals .approval-row').count(), 1);
  await shot(page, '2-waiting-for-approval');
  await page.locator('[id^="approve-"]').click();
  await page.locator('.notice.ok', { hasText: 'Approved. The order is drafted' }).waitFor();
  assert.strictEqual(await page.locator('#approvals').count(), 0, 'nothing is waiting once it is approved');
  await page.getByRole('button', { name: 'Goods arrived' }).first().waitFor();
  assert.strictEqual(await page.getByRole('button', { name: 'Goods arrived' }).count(), 2, 'the manual order and the approved one are both waiting for their goods');
  assert.strictEqual(await page.locator('.low-row', { hasText: 'Toor dal' }).count(), 0, 'the warning that was acted on leaves the list');
  step('an order is asked for from a warning, waits for approval, and only after a person approves is a draft order made');

  await page.locator('#low-check').click();
  await page.locator('.notice.ok', { hasText: 'Checked.' }).waitFor();
  assert.strictEqual(await page.locator('.low-row').count(), 2);
  for (const text of await page.locator('.low-row').allInnerTexts()) assert.match(text, /already on order/);
  assert.strictEqual(await page.locator('[id^="low-order-"]').count(), 0, 'nothing more to order once the orders cover it');
  step('with those orders open the warnings say they are already on order and propose nothing more');

  while (await page.locator('[id^="low-dismiss-"]').count() > 0) {
    const before = await page.locator('.low-row').count();
    await page.locator('[id^="low-dismiss-"]').first().click();
    await page.locator('.notice.ok', { hasText: 'Set aside.' }).waitFor();
    await page.waitForFunction((n) => document.querySelectorAll('.low-row').length === n - 1, before);
  }

  await page.locator('#low-none').waitFor();
  step('a warning can be set aside, and it leaves the list');

  await page.locator('#terms-open').click();
  await page.getByRole('dialog', { name: 'Delivery times' }).waitFor();
  await page.locator('#terms-item').selectOption({ label: 'Basmati rice ✓' });
  assert.deepStrictEqual([await page.locator('#terms-lead').inputValue(), await page.locator('#terms-safety').inputValue(), await page.locator('#terms-pack').inputValue()], ['5', '2', '1']);
  await page.locator('#terms-lead').fill('9');
  await page.locator('#terms-save').click();
  await page.locator('.notice.ok', { hasText: 'Saved.' }).waitFor();
  assert.match(await page.locator('#terms-table').innerText(), /Basmati rice\s+National Foods\s+9\s+2/);
  assert.match(await page.locator('#terms-table').innerText(), /Toor dal\s+National Foods\s+4\s+1/);
  await page.locator('#terms-lead').fill('many');
  await page.locator('#terms-save').click();
  await page.locator('.notice.error', { hasText: 'Please type the days they take to deliver' }).waitFor();
  step('the delivery times are shown, changed and kept, and a wrong entry is refused in plain words');

  await page.locator('#set-window').fill('3');
  await page.locator('#set-save').click();
  await page.locator('.notice.error', { hasText: 'Look back over between 7 and 365 days.' }).waitFor();
  await page.locator('#set-window').fill('14');
  await page.locator('#set-save').click();
  await page.locator('.notice.ok', { hasText: 'Saved.' }).waitFor();
  step('the owner changes how many days of selling are looked at, and a wrong number is refused');

  await page.getByRole('dialog', { name: 'Delivery times' }).getByRole('button', { name: 'Close' }).click();
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  for (const word of ['supply.set', 'insight.run', 'insight.dismiss', 'insight.settings', 'action.propose', 'action.approve', 'action.done']) assert.ok(activity.includes(word), 'the activity list shows ' + word);
  step('every change by a person is in the activity list');

  // What was sent to an AI service: a request through a fixed reason, with no service connected and a customer's name added, is refused and the screen says that nothing was sent and what was left out.
  const egress = await page.request.post(hub.url + '/__e2e/seed-egress');
  assert.strictEqual(egress.status(), 200);
  assert.strictEqual((await egress.json()).ok, false);
  await page.goto(hub.url + '/settings');
  await page.getByRole('tab', { name: 'AI helpers' }).click();
  await page.getByRole('heading', { name: 'AI helpers', level: 1 }).waitFor();
  await page.locator('#ai-sent').waitFor();
  const sentRow = (await page.locator('#ai-sent-table tbody tr').first().innerText()).replace(/\s+/g, ' ');
  for (const part of ['low_stock_explain', 'nothing', 'customer_name', 'Not allowed']) assert.ok(sentRow.includes(part), 'the row says ' + part + ': ' + sentRow);
  assert.ok(!sentRow.includes('Maria') && !sentRow.includes('Basmati'), 'the row holds no value that was supplied');
  step('the AI page says what was asked, that nothing was sent, what was left out, and never shows what the pieces said');

  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nRunning low: all steps passed.');
} catch (e) {
  console.error(e);
  if (hub) console.log(hub.log().split('\n').filter((l) => !l.includes('XmlKeyManager') && !l.includes('No XML encryptor')).slice(-40).join('\n'));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop().catch(() => {});
}
process.exit(process.exitCode || 0);
