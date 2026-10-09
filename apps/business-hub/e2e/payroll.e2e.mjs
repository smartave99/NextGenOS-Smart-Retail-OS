// Employees in the browser (the older POS's employees, attendance, advances and salary slips, merge, staff part 2): a person is added, a day is written down with times, money is given in advance,
// a month's pay is worked out and paid with part of the advance taken out, the slip can be read and printed, a day on a slip is locked, and a cancelled slip gives the advance back.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('payroll');
const step = (s) => console.log('✓ ' + s);
const money = (text) => Number(text.replace(/[^0-9.]/g, ''));
let hub;
try {
  hub = await startHub();
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
  await signIn(page, hub);

  await go(page, 'Employees');
  await page.getByRole('heading', { name: 'Employees' }).waitFor();
  await page.locator('#add-employee').click();
  await page.locator('#emp-name').fill('Meera');
  await page.locator('#emp-dept').fill('Counter');
  await page.locator('#emp-pay').fill('30000');
  await page.locator('#emp-hours').fill('8');
  await page.locator('#save-employee').click();
  await page.getByText('Saved.').first().waitFor();
  await page.locator('#employees tbody tr', { hasText: 'Meera' }).getByText('EMP-1').waitFor();
  // no monthly pay: refused in plain words
  await page.locator('#add-employee').click();
  await page.locator('#emp-name').fill('Ravi');
  await page.locator('#save-employee').click();
  await page.getByText(/Please type the monthly pay/).first().waitFor();
  await page.getByRole('button', { name: 'Cancel' }).click();
  await shot(page, '1-people');
  step('an employee is added with the monthly pay; leaving the pay out is refused in plain words');

  await page.locator('#tab-days').click();
  await page.getByLabel('Came, Meera').fill('09:00');
  await page.getByLabel('Left, Meera').fill('18:30');
  await page.getByLabel('Left, Meera').press('Tab');
  await page.locator('#present-1').click();
  await page.locator('#day-sheet tbody tr', { hasText: 'Meera' }).getByText(/overtime 1:30/).waitFor();
  await shot(page, '2-days');
  step('today is written down: present from 09:00 to 18:30, which is 1:30 of overtime on an 8-hour day');

  await page.locator('#tab-advances').click();
  await page.locator('#a-person').selectOption({ label: 'Meera' });
  await page.locator('#a-amount').fill('500');
  await page.locator('#give-advance').click();
  await page.getByText('Recorded.').first().waitFor();
  assert.strictEqual(money(await page.locator('#advance-owed').innerText()), 500);
  step('500 is given in advance and shows as still to be paid back');

  await page.locator('#tab-pay').click();
  await page.locator('#rule-basis').fill('30');
  await page.locator('#rule-basis').press('Tab');
  await page.locator('#save-rules').click();
  await page.getByText('Saved.').first().waitFor();
  await page.locator('#p-person').selectOption({ label: 'Meera' });
  await page.locator('#p-rate').fill('100');
  await page.locator('#p-rate').press('Tab');
  await page.locator('#pv-overtime').waitFor();
  await page.locator('#p-repay').fill('200');
  await page.locator('#p-repay').press('Tab');
  await page.waitForFunction(() => document.querySelector('#pv-net')?.textContent.replace(/[^0-9.]/g, '') === '950.00');
  assert.strictEqual(money(await page.locator('#pv-earned').innerText()), 1000, 'one day of 30,000 over 30 days');
  assert.strictEqual(money(await page.locator('#pv-overtime').innerText()), 150, '90 minutes at 100 an hour');
  assert.strictEqual(await page.locator('#pv-days').innerText(), '1');
  await shot(page, '3-pay');
  step('the pay is worked out before it is paid: 1,000.00 for the day, 150.00 overtime, 200.00 of the advance taken out, 950.00 to pay out');

  await page.locator('#pay-employee').click();
  await page.getByText(/Paid\. Slip PAY-1/).first().waitFor();
  await page.locator('#slips tbody tr', { hasText: 'PAY-1' }).waitFor();
  // the day is on a slip now: it cannot be changed
  await page.locator('#tab-days').click();
  await page.locator('#absent-1').click();
  await page.getByText(/was paid for/).first().waitFor();
  step('the pay is made as slip PAY-1, and the day on the slip can no longer be changed');

  await page.locator('#tab-pay').click();
  await page.locator('#slips a', { hasText: 'PAY-1' }).click();
  await page.locator('#slip').waitFor();
  const slip = await page.locator('#slip').innerText();
  assert.match(slip, /Pay slip PAY-1/);
  assert.match(slip, /Meera/);
  assert.match(slip, /950\.00/);
  await page.locator('#print-slip').waitFor();
  await shot(page, '4-slip');
  step('the slip can be read and printed');

  await go(page, 'Employees');
  await page.locator('#tab-advances').click();
  await page.locator('#a-person').selectOption({ label: 'Meera' });
  assert.strictEqual(money(await page.locator('#advance-owed').innerText()), 300, '500 less the 200 taken out of the pay');
  await page.locator('#tab-pay').click();
  await page.locator('#slips tbody tr', { hasText: 'PAY-1' }).getByRole('button', { name: /Cancel slip/ }).click();
  await page.locator('#cancel-why').fill('wrong month');
  await page.locator('#cancel-slip').click();
  await page.getByText('The slip is cancelled.').first().waitFor();
  await page.locator('#slips tbody tr', { hasText: 'Cancelled' }).waitFor();
  await page.locator('#tab-advances').click();
  await page.locator('#a-person').selectOption({ label: 'Meera' });
  assert.strictEqual(money(await page.locator('#advance-owed').innerText()), 500, 'the advance paid back out of the slip is owed again');
  await page.locator('#tab-days').click();
  await page.locator('#absent-1').click();
  await page.locator('#day-sheet tbody tr', { hasText: 'Meera' }).getByText('Absent').waitFor();
  step('cancelling the slip gives the advance back, and the day can be changed again');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nEmployees and their pay work in the browser.');
} catch (e) {
  console.error(e);
  try { console.error('SCREEN SAYS:', (await browser.contexts()[0].pages()[0].locator('.notice').allInnerTexts()).join(' | ')); } catch (_) { /* nothing to show */ }
  if (hub) console.error(hub.log().slice(-1500));
  process.exitCode = 1;
} finally {
  await browser.close();
  if (hub) await hub.stop();
}
