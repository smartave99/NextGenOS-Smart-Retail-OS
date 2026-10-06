// A salon: book a client with a stylist at a free time, check in, charge the visit with a product and a tip.
import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('services');
const step = (s) => console.log('✓ ' + s);
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Test Studio', industry: 'services' });
  await signIn(page, hub);
  const side = await page.getByRole('navigation', { name: 'Main' }).innerText();
  assert.match(side, /Bookings/); assert.doesNotMatch(side, /Tables|Kitchen|Desk|Projects/);
  step('a salon sees Bookings, not tables or projects');

  await go(page, 'Bookings');
  await page.getByRole('heading', { name: /Kavya/ }).waitFor();
  await page.getByRole('heading', { name: /Imran/ }).waitFor();
  step('the day shows a column for each stylist');

  // Tomorrow, or the next open day: Sunday is closed
  const start = await page.locator('#day').inputValue();
  await page.locator('[aria-label="Day after"]').click();
  await page.waitForFunction((d) => document.querySelector('#day').value !== d, start);
  if (new Date(await page.locator('#day').inputValue() + 'T12:00:00').getDay() === 0) {
    const sunday = await page.locator('#day').inputValue();
    await page.locator('[aria-label="Day after"]').click();
    await page.waitForFunction((d) => document.querySelector('#day').value !== d, sunday);
  }
  await page.locator('#new-booking').click();
  await page.getByLabel('Client').selectOption({ label: 'Priya Nair' });
  await page.locator('#bk-service').selectOption({ index: 1 });
  await page.locator('#bk-staff').selectOption({ label: 'Kavya (stylist)' });
  const slot = page.locator('.slots button').nth(2);
  await slot.waitFor();
  const slotText = await slot.innerText();
  await slot.click();
  await page.locator('#save-booking').click();
  await page.locator('.notice.ok', { hasText: 'Booked.' }).waitFor();
  await page.locator('section', { hasText: 'Kavya' }).filter({ hasText: slotText }).waitFor();
  await shot(page, '1-day');
  step('booked Priya with Kavya at ' + slotText);

  // The same time with the same stylist is refused in words
  await page.locator('#new-booking').click();
  await page.locator('#bk-service').selectOption({ index: 1 });
  await page.locator('#bk-staff').selectOption({ label: 'Kavya (stylist)' });
  const times = await page.locator('.slots button').allInnerTexts();
  assert.ok(!times.includes(slotText), 'the time just booked is not offered again');
  await page.getByRole('dialog', { name: 'New booking' }).getByRole('button', { name: 'Cancel' }).click();
  step('a time already taken is not offered again');

  // Charge a visit that is today: a walk-in
  await page.locator('#day').fill(new Date().toISOString().slice(0, 10));
  await page.locator('#day').press('Enter');
  await page.getByRole('button', { name: 'Today' }).click();
  await page.locator('#new-booking').click();
  await page.getByLabel('Client').selectOption({ label: 'Priya Nair' });
  await page.locator('#bk-service').selectOption({ index: 1 });
  await page.locator('#bk-staff').selectOption({ label: 'Imran (stylist)' });
  await page.locator('#bk-walkin').check();
  await page.locator('#bk-time').fill('10:15');
  await page.locator('#save-booking').click();
  await page.locator('.notice.ok', { hasText: 'Booked.' }).waitFor();
  await page.getByRole('button', { name: 'Charge' }).last().click();
  await page.locator('#ex-item').selectOption({ index: 1 });
  await page.getByRole('button', { name: 'Add', exact: true }).click();
  const without = await page.locator('#total').innerText();
  await page.locator('#tip').fill('50');
  await page.locator('#tip').press('Tab');
  await page.waitForFunction((t) => document.querySelector('#total').innerText !== t, without);
  await shot(page, '2-charge');
  await page.locator('#charge').click();
  await page.waitForURL(/\/documents\/\d+(\?.*)?$/);
  const receipt = await page.locator('.receipt').innerText();
  assert.match(receipt, /Tip/);
  assert.match(receipt, /CGST/);
  step('a walk-in visit charged with a product and a tip: the bill has both and the tax');

  // The staff report
  await go(page, 'Reports');
  await page.getByRole('heading', { name: 'Staff sales' }).waitFor();
  assert.match(await page.locator('main').innerText(), /Imran|Kavya/);
  step('the report shows staff sales');
} finally {
  await browser.close();
  if (problems.length) console.log('browser problems:', problems);
  await hub.stop();
  process.exitCode = problems.length ? 1 : process.exitCode;
}
