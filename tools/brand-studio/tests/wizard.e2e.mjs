// The Brand Studio wizard in a real browser: fill the form, see the preview change, save, make the files, and be told in words what is wrong.
import assert from 'node:assert';
import { createRequire } from 'node:module';
import { mkdtempSync, rmSync, writeFileSync, existsSync, readFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { startServer } from '../lib/server.mjs';

const here = dirname(fileURLToPath(import.meta.url));
// Playwright is installed with the Business Hub's browser tests.
const { chromium } = createRequire(resolve(here, '..', '..', '..', 'apps', 'business-hub', 'e2e', 'package.json'))('playwright');

const PNG = Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==', 'base64');
const root = mkdtempSync(join(tmpdir(), 'brand-wizard-'));
writeFileSync(join(root, 'logo.png'), PNG);
const server = await startServer({ root });
const browser = await chromium.launch();
const problems = [];
const step = (s) => console.log('✓ ' + s);
try {
  const page = await (await browser.newContext({ viewport: { width: 1360, height: 900 } })).newPage();
  // (The one 400 is the refused save below, which is the point of that step.)
  page.on('console', (m) => { if (m.type() === 'error' && !/status of 400/.test(m.text())) problems.push('console: ' + m.text()); });
  page.on('pageerror', (e) => problems.push('pageerror: ' + e.message));
  page.on('requestfailed', (r) => problems.push('requestfailed: ' + r.url()));
  await page.goto(server.url);
  const frame = () => page.frameLocator('#preview');
  await frame().locator('h1').waitFor();
  step('the wizard opens with its secret address and shows a preview straight away');

  await page.locator('#name').fill('Luzon Fresh Mart');
  assert.strictEqual(await page.locator('#slug').inputValue(), 'luzon-fresh-mart', 'the kit name follows the business name');
  await frame().locator('h1', { hasText: 'Luzon Fresh Mart' }).waitFor();
  await page.locator('#primaryColor').fill('#aa2233');
  await page.waitForFunction(() => document.getElementById('preview').srcdoc.includes('#aa2233'));
  step('typing the name and a colour changes the preview as you type');

  await page.locator('#primaryColor').fill('#ffff00');
  await page.locator('#save').click();
  await page.locator('#msg.bad', { hasText: /too light to read white words on/ }).waitFor();
  await page.locator('#primaryColor').fill('#aa2233');
  step('a colour that cannot be read is refused in words');

  await page.locator('#country').selectOption('PH');
  await page.locator('#industry').selectOption('retail');
  await page.locator('#email').fill('help@luzon.example');
  await page.locator('#siteUrl').fill('https://shop.luzon.example');
  await page.locator('#appId').fill('com.luzon.shop');
  await page.locator('#logo').setInputFiles(join(root, 'logo.png'));
  await page.waitForFunction(() => document.getElementById('preview').srcdoc.includes('data:image/png'));
  await page.locator('#save').click();
  await page.locator('#msg.ok', { hasText: /Saved in brand-kits\/luzon-fresh-mart/ }).waitFor();
  assert.ok(existsSync(join(root, 'brand-kits', 'luzon-fresh-mart', 'brand.json')));
  assert.ok(existsSync(join(root, 'brand-kits', 'luzon-fresh-mart', 'logo.png')));
  const kit = JSON.parse(readFileSync(join(root, 'brand-kits', 'luzon-fresh-mart', 'brand.json'), 'utf8'));
  assert.strictEqual(kit.country, 'PH');
  assert.strictEqual(kit.primaryColor, '#aa2233');
  assert.strictEqual(kit.android.appId, 'com.luzon.shop');
  step('saving writes the kit and its logo');

  await page.locator('#export').click();
  await page.locator('#msg.ok', { hasText: /files are ready/ }).waitFor();
  for (const f of ['preview.html', 'hub-look.json', 'licence-brand.txt', 'website.env', 'ANDROID.txt']) assert.ok(existsSync(join(root, 'brand-exports', 'luzon-fresh-mart', f)), f);
  step('"Make the files" writes everything the other programs need');

  await page.locator('.kits button', { hasText: 'luzon-fresh-mart' }).click();
  await page.waitForFunction(() => document.getElementById('name').value === 'Luzon Fresh Mart');
  assert.strictEqual(await page.locator('#primaryColor').inputValue(), '#aa2233');
  assert.strictEqual(await page.locator('#country').inputValue(), 'PH');
  await page.screenshot({ path: join(tmpdir(), 'brand-studio-wizard.png'), fullPage: true });
  step('a saved kit opens again with everything in place');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe Brand Studio wizard works.');
} catch (e) {
  console.error(e);
  process.exitCode = 1;
} finally {
  await browser.close();
  await server.close();
  rmSync(root, { recursive: true, force: true });
}
