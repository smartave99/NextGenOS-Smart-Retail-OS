// The shop's own copies: the owner chooses a second place, makes a copy, sees whether it worked, is told when the drive is not there, and sets a copy aside to be put back.
// A folder that disappears stands in for a USB drive that is unplugged. (Putting a copy in place happens at the next start of the program: the Core tests do that part.)
import assert from 'node:assert';
import { existsSync, mkdtempSync, readdirSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const second = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('backups');
const step = (s) => console.log('✓ ' + s);
const place = mkdtempSync(join(tmpdir(), 'hub-backup-place-'));
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail' });
  await signIn(page, hub);

  assert.match(await page.locator('#backup-banner').innerText(), /Copies are switched off/);
  step('the owner is told on the first screen that no copies are being made');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Backups' }).click();
  await page.locator('#backup-place').fill(place);
  await page.locator('#backup-on').check();
  await page.locator('#backup-save').click();
  await page.locator('.notice.ok', { hasText: 'Saved.' }).waitFor();
  assert.match(await page.locator('#backup-status').innerText(), /No copy has been made yet/);
  assert.ok(existsSync(join(place, '.nextgenos-backup-place')), 'the place is marked');
  step('a place is chosen and saved, and the screen says no copy has been made yet');

  await page.locator('#backup-now').click();
  await page.locator('#backup-status', { hasText: 'The last good copy was made on' }).waitFor();
  const files = readdirSync(place).filter((f) => f.endsWith('.bak'));
  assert.strictEqual(files.length, 1, 'one copy in the place');
  await page.locator('#backup-copies tbody tr').first().waitFor();
  assert.match(await page.locator('#backup-copies').innerText(), new RegExp(files[0].replace(/\./g, '\\.')));
  await shot(page, '1-copy-made');
  step('"Back up now" makes a copy, the screen says so and lists it');

  await go(page, 'Today');
  await page.getByRole('heading', { name: 'Today' }).waitFor();
  assert.strictEqual(await page.locator('#backup-banner').count(), 0, 'no banner while the copies work');
  step('the first screen is quiet while the copies work');

  rmSync(place, { recursive: true, force: true });                      // the drive is unplugged
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Backups' }).click();
  await page.locator('#backup-now').click();
  await page.locator('.notice.error', { hasText: 'not the one chosen' }).first().waitFor();
  assert.match(await page.locator('#backup-status').innerText(), /did not work/);
  assert.match(await page.locator('#backup-status').innerText(), /The last good copy was made on/);
  await go(page, 'Today');
  await page.locator('#backup-banner').waitFor();
  assert.match(await page.locator('#backup-banner').innerText(), /did not work/);
  step('an unplugged drive is said in plain words, with when the last good copy was made, on the screen and on the first screen');

  // A copy that was made is set aside to be put back: nothing changes until the program starts again, and it can be taken back.
  const place2 = mkdtempSync(join(tmpdir(), 'hub-backup-place-'));
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Backups' }).click();
  await page.locator('#backup-place').fill(place2);
  await page.locator('#backup-save').click();
  await page.locator('.notice.ok', { hasText: 'Saved.' }).waitFor();
  await page.locator('#backup-now').click();
  await page.locator('#backup-copies tbody tr').first().waitFor();
  await page.locator('#backup-copies button[data-copy]').first().click();
  await page.locator('#restore-confirm').waitFor();
  assert.ok(await page.locator('#restore-confirm').isDisabled(), 'the owner has to say they understand first');
  await page.locator('#restore-understood').check();
  await page.locator('#restore-confirm').click();
  await page.locator('#restore-pending').waitFor();
  assert.match(await page.locator('#restore-pending').innerText(), /Close the program and open it again/);
  await shot(page, '2-put-back-ready');
  await page.locator('#restore-cancel').click();
  await page.locator('#restore-pending').waitFor({ state: 'detached' });
  step('a copy is set aside to be put back, with the shop kept as it is until the program starts again, and it can be taken back');

  // A PC with no shop yet can start from a copy.
  const copyFile = join(place2, readdirSync(place2).find((f) => f.endsWith('.bak')));
  const fresh = await newPage(browser, problems);
  await fresh.goto(second.url + '/setup');
  await fresh.locator('#have-a-copy summary').click();
  await fresh.locator('#copy-path').fill(join(place2, 'missing.bak'));
  await fresh.locator('#copy-check').click();
  await fresh.locator('.notice.error', { hasText: 'not there' }).waitFor();
  await fresh.locator('#copy-path').fill(copyFile);
  await fresh.locator('#copy-check').click();
  await fresh.locator('#copy-ready').waitFor();
  assert.match(await fresh.locator('#copy-ready').innerText(), /Close the program and open it again/);
  step('the first screen of a PC with no shop checks a copy and sets it aside');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nBackups: the choice, the copy, the unplugged drive, the copy set aside, the new PC: all steps passed.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  await hub.stop();
  await second.stop();
  rmSync(place, { recursive: true, force: true });
}
