// Stock forecasts (blueprint INS-011): "Running low" on the Buying page. Off until switched on; a shop that sold 3 kg of rice a day for four weeks is told, with the figures, that 16 kg will not last the 7 days
// the supplier needs; the reasons are shown; an order is started from the warning; a warning is set aside; the delivery times and the rule's settings are kept.
// The shop's four weeks of selling are put in by a test-only door of the test program (a real shop cannot be made to wait four weeks).
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
  assert.match(await page.locator('#low-summary').innerText(), /1 item\(s\) judged/);
  assert.strictEqual(await page.locator('.low-row').count(), 1);
  const row = await page.locator('.low-row').innerText();
  for (const part of ['Basmati rice', '16 kg on the shelf', 'sold 84 kg in the last 28 day(s)', 'about 3 kg a day', 'lasts about 5.3 day(s)', 'National Foods takes 5 day(s) to deliver and you want 2 spare', 'About 26 kg would cover the next 14 day(s)'])
    assert.ok(row.includes(part), 'the warning says: ' + part + '\n' + row);
  await shot(page, '1-running-low');
  step('a shop that sold 3 kg a day is told that 16 kg will not last the 7 days the supplier needs, with the figures in plain words');

  await page.locator('.low-row summary').click();
  assert.match(await page.locator('.low-row details').innerText(), /A quantity is a proposal: look at it before you order\./);
  assert.match(await page.locator('.low-row details').innerText(), /Worked out on .* from bills \d+/);
  step('"Why might this be wrong?" gives the ways the figure could mislead and the bills it rests on');

  await page.locator('[id^="low-order-"]').click();
  await page.getByRole('dialog', { name: 'New order' }).waitFor();
  assert.strictEqual(await page.locator('#po-supplier option:checked').innerText(), 'National Foods');
  assert.match(await page.getByRole('dialog', { name: 'New order' }).innerText(), /26 × Basmati rice/);
  await page.locator('#save-order').click();
  await page.locator('.notice.ok', { hasText: 'The order is placed.' }).waitFor();
  step('an order is started from the warning with the supplier and the quantity filled in, and placed by a person');

  await page.locator('#low-check').click();
  await page.locator('.notice.ok', { hasText: 'Checked.' }).waitFor();
  assert.match(await page.locator('.low-row').innerText(), /already on order/);
  assert.strictEqual(await page.locator('[id^="low-order-"]').count(), 0, 'nothing more to order once the order covers it');
  step('with that order open the warning says it is already on order and proposes nothing more');

  await page.locator('[id^="low-dismiss-"]').click();
  await page.locator('.notice.ok', { hasText: 'Set aside.' }).waitFor();
  await page.locator('#low-none').waitFor();
  assert.strictEqual(await page.locator('.low-row').count(), 0);
  step('a warning can be set aside, and it leaves the list');

  await page.locator('#terms-open').click();
  await page.getByRole('dialog', { name: 'Delivery times' }).waitFor();
  await page.locator('#terms-item').selectOption({ label: 'Basmati rice ✓' });
  assert.deepStrictEqual([await page.locator('#terms-lead').inputValue(), await page.locator('#terms-safety').inputValue(), await page.locator('#terms-pack').inputValue()], ['5', '2', '1']);
  await page.locator('#terms-lead').fill('9');
  await page.locator('#terms-save').click();
  await page.locator('.notice.ok', { hasText: 'Saved.' }).waitFor();
  assert.match(await page.locator('#terms-table').innerText(), /Basmati rice\s+National Foods\s+9\s+2/);
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
  for (const word of ['supply.set', 'insight.run', 'insight.dismiss', 'insight.settings']) assert.ok(activity.includes(word), 'the activity list shows ' + word);
  step('every change by a person is in the activity list');

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
