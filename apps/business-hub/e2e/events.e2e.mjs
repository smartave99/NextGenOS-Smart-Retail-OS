// The business event history screen (Version 2, phase 2): off until switched on; what is kept, looked through, explained and corrected by a person; how long things are kept.
// Events are put in through the event store by a test-only door of the test program (nothing in the shop writes events yet).
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('events');
const step = (s) => console.log('✓ ' + s);
let hub;
// The list is redrawn after the server answers: wait for the number of rows asked for, rather than read the old list.
const rows = async (page, selector, n) => {
  await page.waitForFunction(([sel, count]) => document.querySelectorAll(sel).length === count, [selector + ' tbody tr', n], { timeout: 15000 });
  assert.strictEqual(await page.locator(selector + ' tbody tr').count(), n);
};

try {
  hub = await startHub(['--E2E:Modules=hub,ai', '--E2E:Seed=true']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', demo: false });
  await signIn(page, hub);
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'AI helpers' }).click();
  await page.locator('#ai-events-link').click();
  await page.getByRole('heading', { name: 'Business events', level: 1 }).waitFor();

  assert.match(await page.locator('#ev-off').innerText(), /switched off, so nothing is being recorded/);
  assert.strictEqual(await page.locator('#ev-total').innerText(), '0');
  assert.match(await page.locator('#ev-none').innerText(), /No events match/);
  await shot(page, '1-off');
  step('with the history switched off the screen says nothing is being recorded and shows nothing');

  const seeded = await page.request.post(hub.url + '/__e2e/seed-events');
  assert.strictEqual(seeded.status(), 200);
  await page.reload();
  await page.getByRole('heading', { name: 'Business events', level: 1 }).waitFor();
  assert.strictEqual(await page.locator('#ev-off').count(), 0, 'the notice is gone once it is switched on');
  assert.strictEqual(await page.locator('#ev-total').innerText(), '4');
  assert.strictEqual(await page.locator('#ev-obs').innerText(), '2');
  await page.locator('#f-go').click();
  await page.locator('#ev-table').waitFor();
  assert.strictEqual(await page.locator('#ev-table tbody tr').count(), 4);
  const table = await page.locator('#ev-table').innerText();
  assert.match(table, /Customer session: picked up product/);
  assert.match(table, /Waiting to be checked/);
  assert.match(table, /Replaced by a correction/);
  assert.match(table, /track:cam1:17/);
  assert.match(table, /90%/);
  await shot(page, '2-seeded');
  step('after the switch is on, the events appear newest first with who, where, how sure and where they stand');

  await page.locator('#ev-table tbody tr', { hasText: 'picked up product' }).getByRole('button', { name: 'Why?' }).click();
  await page.locator('#ev-why').waitFor();
  const sentence = await page.locator('#ev-sentence').innerText();
  assert.match(sentence, /Made by an automatic rule 'pickup-rule' \(version 1\.0\), 90% sure\./);
  assert.match(sentence, /A hand stayed at the shelf and the product left it\./);
  assert.match(sentence, /It rests on 2 observations and 1 piece of evidence\./);
  const why = await page.locator('#ev-why').innerText();
  assert.match(why, /camera-1\/frame-0042\.jpg/);
  assert.match(why, /seen by an ai model cam-1/i);
  await shot(page, '3-why');
  step('"Why?" says what made it, how sure, what it rests on, and where the evidence is kept');

  await page.locator('#ev-why').getByRole('button', { name: 'Close' }).click();
  await page.locator('#f-status').selectOption('superseded');
  await page.locator('#f-go').click();
  await rows(page, '#ev-table', 1);
  await page.locator('#ev-table tbody tr').first().getByRole('button', { name: 'Why?' }).click();
  assert.match(await page.locator('#ev-sentence').innerText(), /It was replaced by event \d+\./);
  assert.match(await page.locator('#ev-why').innerText(), /It was replaced by a later event: Shelf: checked/);
  step('a replaced event stays in the history and says what replaced it');

  await page.locator('#f-status').selectOption('');
  await page.locator('#f-type').fill('shelf');
  await page.locator('#f-go').click();
  await rows(page, '#ev-table', 3);
  await page.locator('#f-type').fill('customer_session');
  await page.locator('#f-go').click();
  await rows(page, '#ev-table', 1);
  await page.locator('#f-type').fill('nothing.like.this');
  await page.locator('#f-go').click();
  await page.locator('#ev-none').waitFor();
  step('events are found by the start of their type');

  await page.locator('#f-type').fill('');
  await page.locator('#f-status').selectOption('proposed');
  await page.locator('#f-go').click();
  await rows(page, '#ev-table', 1);
  await page.locator('#ev-table tbody tr').first().getByRole('button', { name: 'Yes, it happened' }).click();
  await page.locator('.notice.ok', { hasText: 'Confirmed.' }).waitFor();
  assert.strictEqual(await page.locator('#ev-obs').innerText(), '2');
  await page.locator('#f-status').selectOption('confirmed');
  await page.locator('#f-go').click();
  await rows(page, '#ev-table', 3);
  step('a person confirms an event that was only proposed, and it is counted as confirmed');

  await page.locator('#f-what').selectOption('observations');
  await page.locator('#f-status').selectOption('');
  await page.locator('#f-go').click();
  await rows(page, '#obs-table', 2);
  assert.match(await page.locator('#obs-table').innerText(), /An AI model cam-1 · detector 2\.1/);
  step('what cameras and sensors saw is shown apart from the events');

  const biometric = page.locator('#ev-retention tr', { hasText: 'Biometric data' });
  assert.strictEqual(await biometric.locator('#ret-observation-BIOMETRIC').getAttribute('placeholder'), 'not kept');
  assert.strictEqual(await biometric.locator('#ret-event-BIOMETRIC').getAttribute('placeholder'), 'not kept');
  assert.strictEqual(await page.locator('#ev-retention tr', { hasText: 'Card and payment' }).count(), 0, 'card details have no row: they are never kept');
  assert.strictEqual(await page.locator('#ret-observation-VIDEO').getAttribute('placeholder'), '3');
  await page.locator('#ret-observation-BIOMETRIC').fill('2');
  await biometric.getByRole('button', { name: 'Save' }).click();
  await page.locator('.notice.ok', { hasText: 'Saved.' }).waitFor();
  await page.reload();
  await page.locator('#ret-observation-BIOMETRIC').waitFor();
  assert.strictEqual(await page.locator('#ret-observation-BIOMETRIC').inputValue(), '2');
  assert.strictEqual(await page.locator('#ret-event-BIOMETRIC').inputValue(), '');
  await page.locator('#ret-observation-BIOMETRIC').fill('abc');
  await page.locator('#ev-retention tr', { hasText: 'Biometric data' }).getByRole('button', { name: 'Save' }).click();
  await page.locator('.notice.error', { hasText: 'not a number of days' }).waitFor();
  step('biometric data is not kept unless a number of days is written; card details have no row at all; a bad number is refused');

  await page.locator('#ev-forget').click();
  await page.locator('.notice.ok', { hasText: 'Nothing is past its time.' }).waitFor();
  step('"forget what is past its time" does nothing when nothing is due');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  for (const word of ['events.status', 'events.supersede', 'events.retention']) assert.ok(activity.includes(word), 'the activity list shows ' + word);
  step('every change by a person is in the activity list');

  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nBusiness events: all steps passed.');
} catch (e) {
  console.error(e);
  if (hub) console.log(hub.log().split('\n').filter((l) => !l.includes('XmlKeyManager') && !l.includes('No XML encryptor')).slice(-40).join('\n'));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop().catch(() => {});
}
process.exit(process.exitCode || 0);
