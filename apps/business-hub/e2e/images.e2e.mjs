// Pictures of items in the browser (the older POS's product images, merge, products tools): a picture is added to an item, a file that is not a picture is refused whatever its name, the picture shows
// on the till's tile, and it can be taken away. The address of a picture is for people who are signed in.
import assert from 'node:assert';
import { writeFileSync, mkdtempSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('images');
const step = (s) => console.log('✓ ' + s);
const folder = mkdtempSync(join(tmpdir(), 'hub-pic-'));
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'Products');
  await page.locator('#add-item').click();
  await page.locator('#f-name').fill('Rice');
  await page.locator('#f-price').fill('100');
  await page.locator('#f-bar').fill('8900000000011');
  await page.getByText(/Save the .* first, then open it again to add pictures/).waitFor();
  await page.locator('#save-item').click();
  await page.getByText('Saved.').first().waitFor();

  await page.locator('tbody tr', { hasText: 'Rice' }).getByRole('button', { name: /^Edit/ }).click();
  const png = join(folder, 'rice.png');
  writeFileSync(png, Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg==', 'base64'));
  await page.locator('#f-picture').setInputFiles(png);
  await page.locator('#thumbs img').first().waitFor();
  const src = await page.locator('#thumbs img').first().getAttribute('src');
  const answer = await page.request.get(hub.url + src);
  assert.strictEqual(answer.status(), 200);
  assert.strictEqual(answer.headers()['content-type'], 'image/png');
  await shot(page, '1-picture');
  step('a picture is added to Rice and the address of the picture answers with a PNG');

  const fake = join(folder, 'rice2.png');
  writeFileSync(fake, '<svg xmlns="http://www.w3.org/2000/svg"><script>alert(1)</script></svg>');
  await page.locator('#f-picture').setInputFiles(fake);
  await page.getByText(/not a picture the Hub can keep/).first().waitFor();
  assert.strictEqual(await page.locator('#thumbs img').count(), 1);
  step('a file that is not a picture is refused in plain words, whatever its name says');

  const stranger = await browser.newContext();
  const outside = await stranger.request.get(hub.url + src, { maxRedirects: 0 });
  assert.notStrictEqual(outside.status(), 200, 'somebody not signed in does not get the picture');
  await stranger.close();
  step('somebody who is not signed in does not get the picture');

  await page.getByRole('button', { name: 'Cancel' }).click();
  await go(page, 'New sale');
  await page.locator('.item-btn', { hasText: 'Rice' }).locator('img.pic').waitFor();
  await shot(page, '2-till');
  step('the picture shows on the till\'s tile for Rice');

  await go(page, 'Products');
  await page.locator('tbody tr', { hasText: 'Rice' }).getByRole('button', { name: /^Edit/ }).click();
  await page.getByRole('button', { name: 'Take this picture away' }).click();
  await page.waitForFunction(() => document.querySelectorAll('#thumbs img').length === 0);
  step('the picture can be taken away');

  assert.deepStrictEqual(problems.filter((p) => !/401|redirect/i.test(String(p))), [], 'the browser saw problems');
  console.log('\nPictures of items work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
