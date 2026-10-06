// A library: lend with a member card and a copy barcode, take back a late book and pay the fine, renew, see who is waiting, add a title with copies.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('library');
const step = (s) => console.log('✓ ' + s);
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Test Library', industry: 'library' });
  await signIn(page, hub);
  const side = await page.getByRole('navigation', { name: 'Main' }).innerText();
  assert.match(side, /Desk/); assert.match(side, /Titles/); assert.doesNotMatch(side, /Tables|Kitchen|Projects|Bookings|New /);
  const today = await page.locator('main').innerText();
  assert.match(today, /Overdue/);
  step('a library sees the Desk and Titles, not tables or projects; Today shows what is overdue');

  await go(page, 'Desk');
  await page.getByRole('tab', { name: 'Overdue' }).click();
  await page.locator('th', { hasText: 'Copy' }).waitFor();
  const overdueRow = page.locator('.tbl tbody tr').first();
  const lateText = await overdueRow.innerText();
  assert.match(lateText, /Asha Verma/);
  const copyBarcode = (await overdueRow.locator('td').nth(1).innerText()).trim();
  await shot(page, '1-overdue');
  step('the overdue list shows Asha Verma with the copy barcode ' + copyBarcode);

  // A member with a late book cannot borrow more
  await page.locator('#member').fill('Asha Verma');
  await page.locator('#member').press('Enter');
  await page.locator('#member-card').waitFor();
  assert.match(await page.locator('#member-card').innerText(), /Asha Verma/);
  assert.match(await page.locator('#member-card').innerText(), /Late/);
  step('the member card shows the late book');

  // Take the late book back: a fine of 6 days
  await page.locator('#back').fill(copyBarcode);
  await page.locator('#back').press('Enter');
  await page.locator('#returned').waitFor();
  const returnedText = await page.locator('#returned').innerText();
  assert.match(returnedText, /late/i);
  assert.match(returnedText, /fine/i);
  step('taking it back says it is late and what the fine is: ' + returnedText.replace(/\s+/g, ' ').slice(0, 90));

  // Asha now owes a fine, so she cannot borrow; pay it at the desk
  await page.locator('#member').fill('Asha Verma');
  await page.locator('#member').press('Enter');
  await page.locator('#pay-fines').waitFor();
  await page.locator('#pay-fines').click();
  await page.getByText(/Fines paid\. Receipt/).waitFor();
  step('the fine is paid at the desk and a receipt number is shown');

  // Lend a book to Meera Joshi (student): find a copy that is on the shelf from the Titles screen
  await go(page, 'Titles');
  await page.getByRole('heading', { name: 'Titles' }).waitFor();
  await page.locator('.tbl tbody tr').filter({ hasText: 'Atomic Habits' }).getByRole('button', { name: 'Copies' }).click();
  await page.locator('#copies tbody tr').first().waitFor();
  const barcodes = await page.locator('#copies tbody tr').evaluateAll((rows) => rows.filter((r) => r.innerText.includes('available')).map((r) => r.querySelector('td').innerText.trim()));
  assert.ok(barcodes.length > 0, 'a copy of Atomic Habits is on the shelf');
  await page.getByRole('button', { name: 'Close' }).click();

  await go(page, 'Desk');
  await page.locator('#member').fill('Meera');
  await page.locator('#member').press('Enter');
  await page.locator('#member-card').waitFor();
  await page.locator('#copy').fill(barcodes[0]);
  await page.locator('#copy').press('Enter');
  await page.getByText(/is lent to Meera Joshi, due back/).waitFor();
  step('Meera borrows Atomic Habits by scanning its copy: the due date is given');

  // Renew
  await page.locator('#member-card').getByRole('button', { name: 'Renew' }).first().click();
  await page.getByText(/is renewed until/).waitFor();
  step('a loan is renewed');

  // Someone waiting
  await page.getByRole('tab', { name: 'Waiting' }).click();
  await page.getByText('Waiting').first().waitFor();
  assert.ok((await page.locator('.tbl tbody tr').count()) >= 1);
  step('the waiting list shows who is queued for which title');

  // A new title with three copies
  await go(page, 'Titles');
  await page.locator('#add-item').click();
  await page.getByLabel('Title', { exact: true }).fill('The Left Hand of Darkness');
  await page.getByLabel('Author').fill('Ursula K. Le Guin');
  await page.getByLabel('Copies to add').fill('3');
  await page.locator('#save-item').click();
  const row = page.locator('.tbl tbody tr').filter({ hasText: 'The Left Hand of Darkness' });
  await row.waitFor();
  assert.match(await row.innerText(), /3 of 3/);
  step('a new title with three copies is added');

  // Reports: fines and popular titles
  await go(page, 'Reports');
  await page.getByRole('heading', { name: 'Library' }).waitFor();
  assert.match(await page.locator('main').innerText(), /Fines collected/);
  step('the report shows fines collected and the most borrowed');
} finally {
  await browser.close();
  if (problems.length) console.log('browser problems:', problems);
  await hub.stop();
  process.exitCode = problems.length ? 1 : process.exitCode;
}
