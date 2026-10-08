// Updates through the main PC (blueprint REL-016, decision 7): the owner's page looks for a newer version, shows what is new, keeps the checked setup on this PC, reminds on the first
// screen, copies the shop before an approval, and then says the last step in plain words. Nothing is installed by the program. The online folder and GitHub's signing are stand-ins
// in memory (the real checker still verifies the signed statement and the file's fingerprint); the Hub is told they are the places to trust.
import assert from 'node:assert';
import { existsSync, readdirSync } from 'node:fs';
import { join } from 'node:path';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('updates');
const step = (s) => console.log('✓ ' + s);
let hub;

const openUpdates = async (page) => {
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Updates' }).click();
  await page.getByRole('heading', { name: 'Updates', level: 2 }).waitFor();
};
const today = async (page) => {
  await go(page, 'Today');
  await page.getByRole('heading', { name: 'Today', level: 1 }).waitFor();
};

try {
  // ---- a program that was not built to look ---------------------------------------------------------------------------------------------------
  hub = await startHub();
  {
    const page = await newPage(browser, problems);
    await setUp(page, hub, { name: 'Corner Mart', demo: false });
    await signIn(page, hub);
    await openUpdates(page);
    assert.match(await page.locator('#update-status').innerText(), /was not made to look for new versions/);
    assert.strictEqual(await page.locator('#update-now').count(), 0, 'nothing to press when it cannot look');
    assert.strictEqual(await page.locator('#update-look').count(), 0);
    await shot(page, '1-not-built');
    step('a program not built to look for updates says so, and offers nothing to press');
    await page.context().close();
  }
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  await hub.stop();

  // ---- a program that looks -------------------------------------------------------------------------------------------------------------------
  hub = await startHub(['--E2E:Seed=true', '--E2E:Updates=true']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', demo: false });
  await signIn(page, hub);
  await openUpdates(page);

  assert.match(await page.locator('#update-status').innerText(), /Not looked yet/);
  assert.strictEqual(await page.locator('#update-look').isChecked(), true);
  assert.strictEqual(await page.locator('#update-new').count(), 0);
  assert.match(await page.locator('#updates').innerText(), /nothing about your shop is sent/);
  assert.match(await page.locator('#updates').innerText(), /Nothing is installed until you say so/);
  assert.match(await page.locator('#updates').innerText(), /only browsers/);
  step('it has not looked yet, looks by itself (switched on), and says in plain words what is and is not sent');

  await page.locator('#update-now').click();
  await page.locator('#update-status', { hasText: 'The last look for a new version did not work' }).waitFor();   // nothing is published yet: a plain problem, not a crash
  assert.match(await page.locator('#update-status').innerText(), /answered 404/);
  assert.match(await page.locator('#update-status').innerText(), /shop carries on as it is/);
  step('an online folder with nothing in it is a plain problem, and the shop carries on');

  assert.strictEqual((await fetch(`${hub.url}/__e2e/publish-update?version=1.0.0&notes=Same`, { method: 'POST' })).status, 200);
  await page.locator('#update-now').click();
  await page.locator('#update-status', { hasText: 'You have the newest version (1.0.0)' }).waitFor();
  step('when the published version is the one running, it says so');

  assert.strictEqual((await fetch(`${hub.url}/__e2e/publish-update?version=1.2.0&notes=${encodeURIComponent('Faster checkout. <b>Bold</b> is just text.')}`, { method: 'POST' })).status, 200);
  await page.locator('#update-now').click();
  await page.locator('#update-new').waitFor();
  assert.match(await page.locator('#update-status').innerText(), /Version 1\.2\.0 is ready\./);
  assert.match(await page.locator('#update-status').innerText(), /Nothing is installed until you approve it/);
  assert.match(await page.locator('#update-new h2').innerText(), /Version 1\.2\.0 is here/);
  assert.strictEqual(await page.locator('#update-notes').innerText(), 'Faster checkout. <b>Bold</b> is just text.', 'notes are shown as text, never as markup');
  assert.strictEqual(await page.locator('#update-notes b').count(), 0);
  assert.ok(existsSync(join(hub.data, 'updates', 'SmartRetailHub-Setup-1.2.0.exe')), 'the checked setup is kept on this PC');
  assert.strictEqual(await page.locator('#update-steps').count(), 0, 'no installing steps until it is approved');
  await shot(page, '2-ready');
  step('a newer version is found, proved to be the program\'s own release, kept on this PC, and shown with its notes as text');

  await today(page);
  assert.match(await page.locator('#update-banner').innerText(), /A new version \(1\.2\.0\) is ready\. Nothing changes until you say so\./);
  await page.locator('#update-banner a', { hasText: 'Settings, Updates' }).click();
  await page.getByRole('heading', { name: 'Version 1.2.0 is here' }).waitFor();
  step('the first screen reminds the owner, and the reminder opens the page');

  await page.locator('#update-skip').click();
  await page.locator('.notice.ok', { hasText: 'will not remind you about this version' }).waitFor();
  assert.strictEqual(await page.locator('#update-approve').count(), 1, 'still on offer here');
  await today(page);
  assert.strictEqual(await page.locator('#update-banner').count(), 0, 'not now: no reminder for that version');
  step('"Not now" stops the reminder for that version and keeps it on offer on its page');

  await openUpdates(page);
  await page.locator('#update-approve').click();
  await page.locator('.notice.ok', { hasText: 'Approved. The shop was copied first.' }).waitFor();
  assert.match(await page.locator('#update-status').innerText(), /Version 1\.2\.0 is approved\./);
  assert.match(await page.locator('#update-note').innerText(), /No second place for copies is chosen yet/);
  const steps = await page.locator('#update-steps').innerText();
  assert.match(steps, /Windows key and R/);
  assert.match(steps, /Yes/);
  assert.match(steps, /keeps all the shop's data/);
  const path = await page.locator('#update-path').inputValue();
  assert.ok(path.endsWith('SmartRetailHub-Setup-1.2.0.exe'), path);
  assert.ok(existsSync(path), 'the file the page names is there');
  const copies = readdirSync(join(hub.data, 'updates', 'copies'));
  assert.deepStrictEqual(copies, ['NextGenOS-shop-before-1.2.0.bak']);
  await shot(page, '3-approved');
  step('approving copies the shop first, then names the checked file and the last step in plain words; nothing is installed');

  await page.goto(hub.url + '/settings?tab=updates');   // the tab opens from its address, as the first screen's reminder does
  await page.locator('#update-steps').waitFor();
  assert.match(await page.locator('#update-status').innerText(), /is approved\./);
  await today(page);
  assert.match(await page.locator('#update-banner').innerText(), /Version 1\.2\.0 is approved and waiting for you to run it\./);
  step('the approval is kept after the page is opened again, and the first screen reminds that it waits');

  await openUpdates(page);
  await page.locator('#update-look').uncheck();
  await page.locator('.notice.ok', { hasText: 'It will not look for new versions.' }).waitFor();
  await page.goto(hub.url + '/settings?tab=updates');
  await page.locator('#update-look').waitFor();
  assert.strictEqual(await page.locator('#update-look').isChecked(), false);
  assert.match(await page.locator('#update-status').innerText(), /Looking for new versions is switched off/);
  step('the owner can switch looking off, and it stays off');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  for (const word of ['update.found', 'update.look', 'update.skip', 'update.approve', 'update.switch']) assert.ok(activity.includes(word), 'the activity list shows ' + word);
  step('every step is in the activity list');

  // ---- who is offered it ------------------------------------------------------------------------------------------------------------------------
  await page.getByRole('tab', { name: 'People' }).click();
  await page.locator('#u-name').fill('Mia Manager');
  await page.locator('#u-user').fill('mia');
  await page.locator('#u-role').selectOption('manager');
  await page.locator('#u-pass').fill('manager-test-password');
  await page.locator('#add-user').click();
  await page.getByText('Mia Manager').first().waitFor();
  await page.getByRole('button', { name: 'Sign out' }).click();
  await page.waitForURL('**/login');
  await signIn(page, hub, 'mia', 'manager-test-password');
  assert.strictEqual(await page.locator('#update-banner').count(), 0, 'a manager is not reminded');
  await page.goto(hub.url + '/settings');
  await page.getByRole('heading', { name: 'This is not for your role' }).waitFor();
  step('a manager is not reminded and is told "this is not for your role" at Settings');

  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  await hub.stop();
  console.log('\nUpdates: all steps passed.');
} catch (e) {
  console.error(e);
  if (hub) console.log(hub.log().split('\n').filter((l) => !l.includes('XmlKeyManager') && !l.includes('No XML encryptor')).slice(-40).join('\n'));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop().catch(() => {});
}
process.exit(process.exitCode || 0);
