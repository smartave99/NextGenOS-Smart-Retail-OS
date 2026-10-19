// The notes screen (Version 2, phase 5): off until switched on; the owner's notes are kept in pieces on this computer, found by their words with no AI service at all, and retired for good.
// The test program has no AI service, so "Prepare" says why nothing was prepared; the meaning of words is tested in the unit tests with a stand-in service.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('knowledge');
const step = (s) => console.log('✓ ' + s);
let hub;
const rows = async (page, selector, n) => {
  await page.waitForFunction(([sel, count]) => document.querySelectorAll(sel).length === count, [selector + ' tbody tr', n], { timeout: 15000 });
  assert.strictEqual(await page.locator(selector + ' tbody tr').count(), n);
};

try {
  hub = await startHub(['--E2E:Modules=hub,ai', '--E2E:Seed=true']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'AI helpers' }).click();
  await page.locator('#ai-knowledge-link').click();
  await page.getByRole('heading', { name: 'Notes to search', level: 1 }).waitFor();

  assert.match(await page.locator('#kn-off').innerText(), /switched off, so new notes cannot be written/);
  assert.match(await page.locator('#kn-none').innerText(), /no notes yet/);
  await page.locator('#kn-title').fill('Rice supplier');
  await page.locator('#kn-text').fill('The supplier gives a cheap price for rice when we order ten bags.');
  await page.locator('#kn-save').click();
  await page.locator('.notice.error', { hasText: 'switched off, so notes cannot be added' }).waitFor();
  await shot(page, '1-off');
  step('with "Search by meaning" off a note cannot be written, and the screen says so in plain words');

  const on = await page.request.post(hub.url + '/__e2e/seed-knowledge');
  assert.deepStrictEqual(await on.json(), { recording: true });
  await page.reload();
  await page.locator('#kn-title').waitFor();
  assert.strictEqual(await page.locator('#kn-off').count(), 0, 'the notice is gone once it is switched on');
  await page.locator('#kn-title').fill('Rice supplier');
  await page.locator('#kn-class').selectOption('INTERNAL');
  await page.locator('#kn-text').fill('The supplier gives a cheap price for rice when we order ten bags.');
  await page.locator('#kn-save').click();
  await page.locator('.notice.ok', { hasText: 'Kept.' }).waitFor();
  await page.locator('#kn-title').fill('Opening hours');
  await page.locator('#kn-text').fill('We open at nine and close at six on weekdays.');
  await page.locator('#kn-save').click();
  await rows(page, '#kn-table', 2);
  assert.match(await page.locator('#kn-table').innerText(), /Rice supplier\s+\(note:1\)/);
  assert.match(await page.locator('#kn-table').innerText(), /Internal figures/);
  await shot(page, '2-notes');
  step('notes are kept with a reference and the kind of information they hold');

  await page.locator('#kn-title').fill('Card');
  await page.locator('#kn-text').fill('The customer paid with 4111 1111 1111 1111.');
  await page.locator('#kn-save').click();
  await page.locator('.notice.error', { hasText: 'card number' }).waitFor();
  await page.locator('#kn-text').fill('');
  await page.locator('#kn-title').fill('');
  step('a note that looks like it holds a card number is refused');

  await page.locator('#kn-q').fill('what price for rice');
  await page.locator('#kn-go').click();
  await page.locator('#kn-hits').waitFor();
  const found = await page.locator('#kn-hits').innerText();
  assert.match(found, /Rice supplier\s+\(note:1\)/);
  assert.match(found, /cheap price for rice/);
  assert.match(found, /its words/);
  assert.doesNotMatch(found, /Opening hours/);
  await shot(page, '3-found');
  await page.locator('#kn-q').fill('zebra');
  await page.locator('#kn-go').click();
  await page.locator('#kn-found-none').waitFor();
  step('a question finds the note by its words, with where it came from, with no AI service at all; a question with no match says so');

  await page.locator('#kn-prepare').click();
  await page.locator('.notice.ok', { hasText: '0 piece(s) prepared' }).waitFor();
  assert.match(await page.locator('.notice.ok').innerText(), /No AI service/);
  assert.match(await page.locator('#kn-waiting').innerText(), /2 piece\(s\) waiting/);
  step('"Prepare" says in plain words why nothing was prepared (no AI service is set up) and keeps the notes');

  await page.locator('#kn-1').getByRole('button', { name: 'Change' }).click();
  await page.waitForFunction(() => document.querySelector('#kn-title').value === 'Rice supplier', null, { timeout: 15000 });   // the screen is redrawn after the server answers
  assert.match(await page.locator('#kn-text').inputValue(), /cheap price for rice/);
  await page.locator('#kn-text').fill('The supplier now asks for a fair price for rice.');
  await page.locator('#kn-save').click();
  await page.locator('.notice.ok', { hasText: 'Saved.' }).waitFor();
  await page.locator('#kn-q').fill('cheap');
  await page.locator('#kn-go').click();
  await page.locator('#kn-found-none').waitFor();
  step('changing a note replaces its words');

  await page.locator('#kn-1').getByRole('button', { name: 'Retire' }).click();
  await page.locator('.notice.ok', { hasText: 'Retired.' }).waitFor();
  await rows(page, '#kn-table', 1);
  await page.locator('#kn-q').fill('fair price');
  await page.locator('#kn-go').click();
  await page.locator('#kn-found-none').waitFor();
  step('a retired note is gone from the list and from every search');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  assert.ok(activity.includes('knowledge.add') && activity.includes('knowledge.update') && activity.includes('knowledge.retire'));
  assert.ok(!activity.includes('fair price'), 'the words of a note are not in the activity list');
  step('every change is in the activity list, without the words of the note');
} finally {
  await browser.close();
  if (problems.length) console.log('Browser problems:', problems);
  await hub?.stop();
}

assert.deepStrictEqual(problems, [], 'the browser saw problems');
console.log('\nNotes to search: all steps passed.');
