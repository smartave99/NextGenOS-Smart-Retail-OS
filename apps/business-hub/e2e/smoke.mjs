import assert from 'node:assert';
import { build, startHub, launch, newPage, setUp, signIn, shots } from './lib.mjs';

build();
const hub = await startHub();
const browser = await launch();
const problems = [];
const shot = shots('smoke');
try {
  const page = await newPage(browser, problems);
  await setUp(page, hub);
  await shot(page, '0-login');
  await signIn(page, hub);
  await page.waitForSelector('.card.stat');
  await shot(page, '1-today');
  const text = await page.locator('main').innerText();
  console.log(text.slice(0, 400));
  assert.ok(await page.locator('.side a').count() >= 5);
} finally {
  await browser.close();
  console.log('problems:', problems);
  console.log(hub.log().slice(-1500));
  await hub.stop();
}
