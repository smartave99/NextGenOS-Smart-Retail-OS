// The business map screen (Version 2, phase 3): off until switched on; places and devices are added and put inside each other; connections join them to the shop's own
// products; the shop's own records are only looked at; what is removed ends its connections but stays in the history.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('map');
const step = (s) => console.log('✓ ' + s);
let hub;
const rows = async (page, selector, n) => {
  await page.waitForFunction(([sel, count]) => document.querySelectorAll(sel).length === count, [selector + ' tbody tr', n], { timeout: 15000 });
  assert.strictEqual(await page.locator(selector + ' tbody tr').count(), n);
};

try {
  hub = await startHub(['--E2E:Modules=hub,ai']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: true });
  await signIn(page, hub);
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'AI helpers' }).click();
  await page.locator('#ai-map-link').click();
  await page.getByRole('heading', { name: 'Business map', level: 1 }).waitFor();

  assert.match(await page.locator('#map-off').innerText(), /switched off, so nothing can be added/);
  assert.strictEqual(await page.locator('#a-go').isDisabled(), true);
  assert.strictEqual(await page.locator('#c-go').isDisabled(), true);
  assert.match(await page.locator('#map-empty').innerText(), /Nothing has been added yet/);
  assert.match(await page.locator('#check-ok').innerText(), /Every connection points at something that is still there/);
  await shot(page, '1-off');
  step('with the map switched off nothing can be added and the screen says so');

  // switch it on, from the AI helpers screen
  await page.goto(hub.url + '/settings/ai');
  await page.locator('#flag-business_ontology').check();
  await page.reload();
  await page.locator('#flag-business_ontology').waitFor();
  assert.strictEqual(await page.locator('#flag-business_ontology').isChecked(), true);
  await page.goto(hub.url + '/settings/map');
  await page.getByRole('heading', { name: 'Business map', level: 1 }).waitFor();
  assert.strictEqual(await page.locator('#map-off').count(), 0);

  const add = async (type, name, inside = '') => {
    await page.locator('#a-type').selectOption(type);
    await page.locator('#a-name').fill(name);
    await page.locator('#a-in').selectOption(inside);
    await page.locator('#a-go').click();
  };
  await add('site', 'Corner Mart');
  await rows(page, '#map-table', 1);
  await add('zone', 'Aisle 3', 'site:corner-mart');
  await rows(page, '#map-table', 2);
  await add('shelf', 'Top shelf', 'zone:aisle-3');
  await rows(page, '#map-table', 3);
  await add('device', 'Camera 1', 'site:corner-mart');
  await rows(page, '#map-table', 4);
  assert.match(await page.locator('#thing-shelf-top-shelf').innerText(), /Top shelf[\s\S]*shelf:top-shelf[\s\S]*Aisle 3 › Corner Mart/);
  assert.match(await page.locator('#thing-zone-aisle-3').innerText(), /Corner Mart/);
  await shot(page, '2-places');
  step('a shop, an area inside it, a shelf inside the area and a camera are added, and each says where it is');

  await page.locator('#c-type').selectOption('observes');
  await page.locator('#c-from').fill('device:camera-1');
  await page.locator('#c-to').fill('zone:aisle-3');
  await page.locator('#c-go').click();
  await rows(page, '#links-table', 4);   // three "inside" connections made by adding, and this one
  assert.match(await page.locator('#links-table').innerText(), /Camera 1\s+watches\s+Aisle 3/);
  step('a camera is connected to the area it watches');

  await page.locator('#p-text').fill('Basmati');
  await page.locator('#p-go').click();
  await page.locator('#find-list li', { hasText: 'Basmati rice 5 kg' }).waitFor();
  assert.match(await page.locator('#find-list').innerText(), /product:1\b/);
  await page.locator('#p-text').fill('zzzz-nothing');
  await page.locator('#p-go').click();
  await page.locator('#find-none').waitFor();
  step('a product is found by part of its name and its reference is shown');

  await page.locator('#c-type').selectOption('stocked_on');
  await page.locator('#c-from').fill('product:1');
  await page.locator('#c-to').fill('shelf:top-shelf');
  await page.locator('#c-go').click();
  await rows(page, '#links-table', 5);
  const productRow = await page.locator('#links-table tbody tr', { hasText: 'is kept on' }).innerText();
  assert.match(productRow, /Top shelf/);
  step('one of the shop\'s own products is connected to a shelf (and is not copied into the map)');

  await page.locator('#c-type').selectOption('part_of');
  await page.locator('#c-from').fill('shelf:top-shelf');
  await page.locator('#c-to').fill('site:corner-mart');
  await page.locator('#c-go').click();
  await page.locator('.notice.error').first().waitFor();
  assert.match(await page.locator('.notice.error').first().innerText(), /cannot be the one that 'is part of' something/);
  await page.locator('#c-from').fill('product:999999');
  await page.locator('#c-to').fill('shelf:top-shelf');
  await page.locator('#c-type').selectOption('stocked_on');
  await page.locator('#c-go').click();
  await page.locator('.notice.error', { hasText: 'is not in the map or in the shop' }).waitFor();
  await page.locator('#c-from').fill('not a reference');
  await page.locator('#c-go').click();
  await page.locator('.notice.error', { hasText: 'a kind, a colon, and a short key' }).waitFor();
  assert.strictEqual(await page.locator('#links-table tbody tr').count(), 5);
  step('connections that make no sense, that name something that is not there, or that are not written as a reference are refused in plain words');

  await page.locator('#l-ref').fill('product:1');
  await page.locator('#l-go').click();
  await page.locator('#look-result strong', { hasText: 'Basmati rice' }).waitFor();
  assert.match(await page.locator('#look-result').innerText(), /is kept on[\s\S]*Top shelf/);
  assert.match(await page.locator('#look-result').innerText(), /has a line for[\s\S]*\(from your records\)/);
  assert.ok((await page.locator('#look-links li').count()) <= 30, 'a long list is cut short');
  await page.locator('#l-ref').fill('zone:aisle-3');
  await page.locator('#l-go').click();
  await page.locator('#look-result strong', { hasText: 'Aisle 3' }).waitFor();
  const links = await page.locator('#look-links').innerText();
  assert.match(links, /Camera 1\s+watches\s+Aisle 3/);
  assert.match(links, /Top shelf\s+is in\s+Aisle 3/);
  assert.match(links, /Aisle 3\s+is part of\s+Corner Mart/);
  step('looking a thing up shows what it is connected to, in both directions');

  await page.locator('#thing-zone-aisle-3').getByRole('button', { name: 'Remove' }).click();
  await page.locator('.notice.ok', { hasText: 'Removed.' }).waitFor();
  await rows(page, '#map-table', 3);
  await page.locator('#links-table').waitFor();
  assert.doesNotMatch(await page.locator('#links-table').innerText(), /Aisle 3/);
  assert.match(await page.locator('#check-ok').innerText(), /in order|still there/);
  step('removing an area ends every connection to it and nothing is left pointing at it');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  for (const word of ['map.add', 'map.connect', 'map.retire']) assert.ok(activity.includes(word), 'the activity list shows ' + word);
  step('every change is in the activity list');

  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nBusiness map: all steps passed.');
} catch (e) {
  console.error(e);
  if (hub) console.log(hub.log().split('\n').filter((l) => !l.includes('XmlKeyManager') && !l.includes('No XML encryptor')).slice(-40).join('\n'));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop().catch(() => {});
}
process.exit(process.exitCode || 0);
