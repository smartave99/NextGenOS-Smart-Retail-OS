// The Help button (the owner's decision 18): the owner says what went wrong in their own words and makes a support file that is shown in full before anything is saved or sent; it holds no sales,
// customers, staff names, amounts, passwords or keys; nothing is sent by the program; a manager has no Help and is told "this is not for your role".
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('help');
const step = (s) => console.log('✓ ' + s);
let hub;

try {
  hub = await startHub(['--E2E:Modules=hub,ai']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', demo: true });
  await signIn(page, hub);

  // The sample company has customers and suppliers with names: none of them may be in the file.
  await go(page, 'People');
  await page.locator('main table tbody tr').first().waitFor();
  const names = (await page.locator('main table tbody tr td:first-child').allInnerTexts()).map((n) => n.split('\n')[0].trim()).filter((n) => n.length >= 4).slice(0, 12);
  assert.ok(names.length >= 1, 'the sample company has people to look for: ' + names.join(', '));

  const nav = page.getByRole('navigation', { name: 'Main' });
  await nav.getByRole('link', { name: 'Help', exact: true }).click();
  await page.getByRole('heading', { name: 'Help', level: 1 }).waitFor();
  assert.match(await page.locator('main').innerText(), /Nothing is sent from here/);
  assert.strictEqual(await page.locator('#help-file').count(), 0, 'no file until it is asked for');
  step('the owner finds Help in the menu, and the page says plainly that nothing is sent from it');

  await page.locator('#help-message').fill('The printer stopped when I pressed Pay. The customer rang me on +91 98765 43210 and paid with 4111 1111 1111 1111.');
  await page.locator('#help-make').click();
  await page.locator('#support-text').waitFor();
  const text = await page.locator('#support-text').inputValue();
  for (const part of ['SUPPORT FILE', 'Read this before you send it.', 'WHAT YOU SAID', 'The printer stopped when I pressed Pay.', 'THE PROGRAM', 'YOUR LICENCE', 'State: Valid', "YOUR SHOP'S DATA", 'File check: no problem found',
    'COPIES OF YOUR SHOP', 'COUNTER PCS', 'AI HELPERS AND WAITING LINES', 'THE KIND OF SHOP', 'Kind of business: retail'])
    assert.ok(text.includes(part), 'the file says: ' + part + '\n' + text.slice(0, 1500));
  step('the file is shown in full on the screen, in plain words, before anything is saved');

  for (const secret of ['98765', '4111', 'a-long-test-password', 'Olivia', 'Corner Mart', ...names])
    assert.ok(!text.toLowerCase().includes(secret.toLowerCase()), 'the file has no ' + secret);
  assert.match(text, /WHAT YOU SAID\nThe printer stopped when I pressed Pay\. .*\[number\]/);
  step('what the owner typed has the obvious personal details taken out, and the file holds no customer, staff name, shop name or password (the sample company has people with names, and none of them is in the file)');

  const save = page.locator('#help-save');
  assert.match((await save.getAttribute('download')) ?? '', /^support-file-\d{4}-\d{2}-\d{2}\.txt$/);
  assert.ok(((await save.getAttribute('href')) ?? '').startsWith('data:text/plain;charset=utf-8,'));
  assert.ok(decodeURIComponent(((await save.getAttribute('href')) ?? '').split(',')[1]).includes('SUPPORT FILE'));
  await shot(page, '1-support-file');
  step('"Save it as a file" saves exactly the text that was shown, from the page itself, with no request to anything else');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  assert.ok((await page.locator('main').innerText()).includes('support.made'));
  step('making a support file is in the activity list (and says nothing was sent)');

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
  assert.strictEqual(await page.getByRole('navigation', { name: 'Main' }).getByRole('link', { name: 'Help', exact: true }).count(), 0, 'a manager has no Help in the menu');
  await page.goto(hub.url + '/help');
  await page.getByRole('heading', { name: 'This is not for your role' }).waitFor();
  step('a manager has no Help in the menu and is told "this is not for your role" at its address');

  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nHelp: all steps passed.');
} catch (e) {
  console.error(e);
  if (hub) console.log(hub.log().split('\n').filter((l) => !l.includes('XmlKeyManager') && !l.includes('No XML encryptor')).slice(-40).join('\n'));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop().catch(() => {});
}
process.exit(process.exitCode || 0);
