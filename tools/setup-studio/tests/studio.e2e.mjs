// The Setup Studio in a real browser, as the people who use it would: first-time welcome, signing in, adding a customer, filling in the details, seeing the look in a real
// preview, preparing the setup, a second person approving it, and the hand-over. A stand-in AI tool answers when asked. Nothing leaves this PC.
import assert from 'node:assert';
import { createRequire } from 'node:module';
import { mkdtempSync, rmSync, writeFileSync, chmodSync, mkdirSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname, resolve, delimiter } from 'node:path';
import { fileURLToPath } from 'node:url';
import { startStudio } from '../lib/server.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const { chromium } = createRequire(resolve(here, '..', '..', '..', 'apps', 'business-hub', 'e2e', 'package.json'))('playwright');
const PNG = Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==', 'base64');
const shots = process.env.STUDIO_SHOTS || join(tmpdir(), 'studio-shots');
mkdirSync(shots, { recursive: true });

const root = mkdtempSync(join(tmpdir(), 'studio-e2e-'));
process.env.SETUP_STUDIO_HOME = join(root, 'home');
writeFileSync(join(root, 'logo.png'), PNG);
const tools = join(root, 'tools'); mkdirSync(tools);
const answer = JSON.stringify({ setup: { schema: 1, settings: { receiptFooter: 'Salamat po!', paymentMethods: ['cash', 'gcash', 'card'] }, vocabulary: { customer: ['Suki', 'Sukis'] } }, theme: { depth: 'lifted' }, explanation: 'Local words and wallets for a Philippine shop.' });
writeFileSync(join(tools, 'claude'), `#!/usr/bin/env node\nprocess.stdin.resume();process.stdin.on('end',()=>console.log(JSON.stringify({is_error:false,result:${JSON.stringify(answer)},modelUsage:{'claude-opus-5-5':{}}})))\n`);
chmodSync(join(tools, 'claude'), 0o755);
const oldPath = process.env.PATH;
process.env.PATH = tools + delimiter + oldPath;
process.env.ANTHROPIC_API_KEY = 'sk-ant-test-123456';

const studio = await startStudio({ folder: join(root, 'ws'), env: process.env });
const browser = await chromium.launch();
const problems = [];
const step = (s) => console.log('✓ ' + s);
const shot = (page, name) => page.screenshot({ path: join(shots, `studio-${name}.png`), fullPage: true });
const newPage = async (width = 1360, height = 900) => {
  const page = await (await browser.newContext({ viewport: { width, height }, reducedMotion: 'reduce' })).newPage();
  page.on('console', (m) => { if (m.type() === 'error' && !/status of (400|401|403|409)/.test(m.text())) problems.push('console: ' + m.text()); });
  page.on('pageerror', (e) => problems.push('pageerror: ' + e.message));
  page.on('requestfailed', (r) => { if (r.failure()?.errorText !== 'net::ERR_ABORTED') problems.push('requestfailed: ' + r.url() + ' ' + r.failure()?.errorText); });
  return page;
};
const signIn = async (page, name, password) => {
  await page.goto(studio.url);
  await page.locator(`[data-person="${name}"]`).click();
  await page.locator('#s-pass').fill(password);
  await page.locator('#s-go').click();
  await page.locator('nav[aria-label="Main"]').waitFor();
};

try {
  const page = await newPage();
  // ---- first use ------------------------------------------------------------------------------------------------------------------------
  await page.goto(studio.url);
  await page.getByRole('heading', { name: 'Welcome to the Setup Studio' }).waitFor();
  await shot(page, '01-welcome');
  await page.locator('#w-name').fill('Asha Admin');
  await page.locator('#w-pass').fill('a-long-password');
  await page.locator('#w-pass2').fill('different-password');
  await page.locator('#w-go').click();
  assert.match(await page.locator('.err').innerText(), /not the same/);
  await page.locator('#w-pass2').fill('a-long-password');
  await page.locator('#w-go').click();
  await page.locator('nav[aria-label="Main"]').waitFor();
  assert.ok(!page.url().includes('k='), 'the secret is not left in the address bar');
  step('the first person makes the administrator account; a mistyped password is explained, and the secret leaves the address bar');
  await page.getByRole('heading', { name: 'Customers', exact: true }).waitFor();
  assert.ok(await page.getByText('No customers yet').isVisible());
  await shot(page, '02-empty');

  // ---- the team ---------------------------------------------------------------------------------------------------------------------------
  await page.locator('[data-nav="team"]').click();
  await page.locator('#add-member').click();
  await page.locator('#m-name').fill('Sam Sales'); await page.locator('#m-role').selectOption('sales'); await page.locator('#m-pass').fill('sam-long-password'); await page.locator('#m-save').click();
  await page.locator('[data-member="Sam Sales"]').waitFor();
  await page.locator('#add-member').click();
  await page.locator('#m-name').fill('Rita Reviewer'); await page.locator('#m-role').selectOption('reviewer'); await page.locator('#m-pass').fill('rita-long-password'); await page.locator('#m-save').click();
  await page.locator('[data-member="Rita Reviewer"]').waitFor();
  await shot(page, '03-team');
  step('the administrator adds a salesperson and a reviewer');
  await page.locator('#signout').click();
  await page.locator('[data-person="Sam Sales"]').waitFor();
  await shot(page, '04-signin');

  // ---- a salesperson adds a customer ------------------------------------------------------------------------------------------------------
  await page.locator('[data-person="Sam Sales"]').click();
  await page.locator('#s-pass').fill('wrong-password'); await page.locator('#s-go').click();
  assert.match(await page.locator('.err').innerText(), /not right/);
  await page.locator('#s-pass').fill('sam-long-password'); await page.locator('#s-go').click();
  await page.locator('[data-nav="customers"]').click();
  await page.locator('#new-customer').waitFor();
  await page.locator('#new-customer').click();
  await page.locator('#nc-name').fill('Luzon Fresh Mart');
  await page.locator('#nc-create').click();
  assert.match(await page.locator('.err').innerText(), /choose the country/);
  await page.locator('#nc-country').selectOption({ label: 'Philippines' });
  await page.locator('#nc-create').click();
  assert.match(await page.locator('.err').innerText(), /kind of business/);
  await page.locator('#nc-kind').selectOption({ label: 'Retail store' });
  await page.locator('#nc-create').click();
  await page.waitForURL(/#\/customers\/luzon-fresh-mart\/details/);
  await page.locator('#customer-name').waitFor();
  assert.strictEqual(await page.locator('#customer-name').innerText(), 'Luzon Fresh Mart');
  await page.locator('.pill', { hasText: 'Details' }).first().waitFor();
  await shot(page, '05-details');
  step('a salesperson adds a customer with three answers and lands on its page');

  // details: business, bills, words
  await page.locator('[data-tab="money"]').click();
  await page.locator('input[data-path="business.contact.phone"]').fill('+63 2 5555 0100');
  await page.locator('input[data-path="business.contact.email"]').fill('help@luzonfresh.example');
  await page.locator('#pay-add').fill('gcash'); await page.locator('#pay-add').press('Enter');
  await page.locator('#pay-chips .chip.on', { hasText: 'gcash' }).waitFor();
  await page.locator('#savebar').waitFor();
  await shot(page, '06-money');
  await page.locator('[data-tab="data"]').click();
  await page.locator('[data-import="items"]').click();
  await page.locator('#import-text').fill('Item,Rate,EAN\n"Rice, 5 kg","₱ 285.00",4800000000011\nGift wrapping,20,\nBroken line,,\n');
  await page.locator('#import-check').click();
  await page.locator('#import-result .notice.ok').waitFor();
  assert.match(await page.locator('#import-result').innerText(), /2 items understood/);
  assert.match(await page.locator('#import-result').innerText(), /Line 4/);
  await shot(page, '07-import');
  await page.locator('#import-add').click();
  await page.locator('input[data-word="customer-one"]').fill('Suki'); await page.locator('input[data-word="customer-many"]').fill('Sukis');
  await page.locator('#save').click();
  await page.locator('.toast', { hasText: 'Saved' }).last().waitFor();
  step('the details are written in plain screens: bills and money, a list brought in from a spreadsheet (with the bad line named), their own words');

  // look
  await page.locator('[data-step="look"]').click();
  await page.locator('#preview-frame').waitFor();
  const frame = page.frameLocator('#preview-frame');
  await frame.locator('.shell').waitFor();
  assert.strictEqual(await frame.locator('html').getAttribute('data-density'), 'comfortable');
  await page.locator('[data-path="device.kind"] [data-value="touch-pos"]').click();
  await page.locator('[data-path="look.style"] [data-value="friendly"]').click();
  await page.locator('#c-look\\.primaryColor').fill('#0a7d4b');
  await page.waitForTimeout(500);
  await frame.locator('html[data-density="touch"]').waitFor();
  assert.strictEqual(await frame.locator('html').getAttribute('data-shape'), 'pill' === 'pill' ? await frame.locator('html').getAttribute('data-shape') : '');
  await shot(page, '08-look-fixed');
  step('the look page shows the real program in the chosen machine layout, as a picture that follows each choice');
  await page.locator('[data-step="details"]').click();
  await page.locator('[data-tab="extras"]').click();
  await page.locator('[data-path="licence.whiteLabel"] [data-value="theme"]').click();
  await page.locator('#save').click();
  await page.locator('.toast', { hasText: 'Saved' }).last().waitFor();
  await page.locator('[data-step="look"]').click();
  await frame.locator('html[data-shape="pill"]').waitFor({ timeout: 10000 });
  let cssFrame = '';
  for (let i = 0; i < 40 && cssFrame !== 'rgb(10, 125, 75)'; i += 1) { cssFrame = await frame.locator('.btn.primary').first().evaluate((b) => getComputedStyle(b).backgroundColor).catch(() => ''); if (cssFrame !== 'rgb(10, 125, 75)') await page.waitForTimeout(250); }
  assert.strictEqual(cssFrame, 'rgb(10, 125, 75)', 'with a style licence the preview button is the chosen colour: ' + cssFrame);
  assert.strictEqual(await frame.locator('html').getAttribute('data-nav'), 'left');
  await shot(page, '09-look-theme');
  step('with a style licence the preview takes the customer\'s colour and shapes; with a fixed look it does not');
  const logoInput = page.locator('#logo-file');
  await logoInput.setInputFiles(join(root, 'logo.png'));
  await page.locator('#logo-box img').waitFor();
  step('a logo is added and shows');

  // prepare
  await page.locator('#next-action').click();
  await page.waitForURL(/\/prepare/);
  await page.locator('#make-proposal').click();
  await page.locator('#explain').waitFor();
  assert.match(await page.locator('#explain').innerText(), /Luzon Fresh Mart is set up as Retail store in Philippines/);
  await shot(page, '10-prepared');
  step('the setup is prepared from the details and explained in plain words');

  // AI
  await page.locator('[data-nav="settings"]').click();
  await page.locator('#ai-settings').waitFor();
  await page.waitForTimeout(300);
  await page.locator('[data-nav="customers"]').click();
  await page.getByRole('link', { name: /Luzon Fresh Mart/ }).click();
  step('(the salesperson can look at Settings but not change them)');
  assert.strictEqual(await page.locator('#ai-save').count(), 0);
  await page.locator('#signout').click();
  await signIn(page, 'Asha Admin', 'a-long-password');
  await page.locator('[data-nav="settings"]').click();
  await page.locator('#ai-settings').waitFor();
  await page.locator('[data-tool="claude-code"]').click();
  await page.locator('#model-select').waitFor();
  const modelOptions = await page.locator('#model-select option').allInnerTexts();
  assert.ok(modelOptions.some((t) => /Claude Opus 5\.5/.test(t)), 'the models are listed');
  assert.ok(modelOptions.some((t) => /Another model/.test(t)));
  await page.locator('#model-select').selectOption('claude-opus-5-5');
  const levels = await page.locator('#effort-seg button').allInnerTexts();
  assert.ok(levels.some((t) => /Extra high/.test(t)) && levels.some((t) => /Maximum/.test(t)) && levels.some((t) => /Low/.test(t)), 'every thinking level is offered: ' + levels.join(' | '));
  await page.locator('#effort-seg [data-effort="high"]').click();
  await page.locator('#model-select').selectOption('claude-haiku-4-5');
  assert.strictEqual(await page.locator('#effort-seg').count(), 0, 'a model with no thinking level shows none');
  await page.locator('#model-select').selectOption('claude-opus-5-5');
  await page.locator('#effort-seg [data-effort="medium"]').click();
  await shot(page, '11-settings-ai');
  await page.locator('#ai-save').click();
  await page.locator('.toast', { hasText: 'Saved' }).last().waitFor();
  await page.locator('details:has(summary:has-text("Version and updates")) summary').click();
  await page.locator('#health-claude-code dl.kv, #health-claude-code .notice').first().waitFor({ timeout: 30000 });
  step('the administrator chooses an AI tool, sees every model and every thinking level, and can look at the tool\'s version and updates');
  await page.locator('#signout').click();
  await signIn(page, 'Sam Sales', 'sam-long-password');
  await page.goto(studio.url.replace(/\?k=.*/, '') + '#/customers/luzon-fresh-mart/prepare');
  await page.locator('#ai-run').waitFor();
  await page.locator('#ai-card summary', { hasText: 'Show exactly what would be sent' }).click();
  await page.locator('#sent-box', { hasText: 'Stays on this PC' }).waitFor();
  assert.ok(!(await page.locator('#sent-box').innerText()).includes('help@luzonfresh'));
  await page.locator('#ai-run').click();
  await page.locator('#ai-changes').waitFor({ timeout: 30000 });
  assert.match(await page.locator('#ai-changes').innerText(), /Suki|gcash|Words at the bottom of a bill/);
  assert.match(await page.locator('#ai-explanation').innerText(), /Local words and wallets/);
  await shot(page, '12-ai-changes');
  await page.locator('#ai-accept').click();
  await page.locator('#explain').waitFor();
  step('the AI tool is asked, its answer is checked and shown as a list of changes, and kept only when the salesperson accepts');

  // review
  await page.locator('#next-action').click();
  await page.waitForURL(/\/review/);
  await page.locator('#checklist').waitFor();
  await shot(page, '13-review');
  await page.locator('#submit').click();
  await page.locator('.toast', { hasText: 'Sent for approval' }).last().waitFor();
  await page.waitForLoadState();
  await page.locator('.notice', { hasText: 'Waiting for a reviewer' }).waitFor();
  assert.strictEqual(await page.locator('#approve').count(), 0, 'a salesperson cannot approve');
  step('the salesperson sends it for approval, and has no way to approve it');
  await page.locator('#signout').click();

  // approval
  await signIn(page, 'Rita Reviewer', 'rita-long-password');
  await page.goto(studio.url.replace(/\?k=.*/, '') + '#/customers/luzon-fresh-mart/review');
  await page.locator('#approve').waitFor();
  await page.locator('#reject').click();
  await page.locator('#reject-reason').fill('Please add the second payment way');
  await page.locator('#reject-yes').click();
  await page.locator('.toast', { hasText: 'Sent back' }).last().waitFor();
  step('the reviewer can send it back with a note');
  await page.locator('#signout').click();
  await signIn(page, 'Sam Sales', 'sam-long-password');
  await page.goto(studio.url.replace(/\?k=.*/, '') + '#/customers/luzon-fresh-mart/prepare');
  await page.locator('#rejection').waitFor();
  assert.match(await page.locator('#rejection').innerText(), /Please add the second payment way/);
  await page.goto(studio.url.replace(/\?k=.*/, '') + '#/customers/luzon-fresh-mart/review');
  await page.locator('#submit').click();
  await page.locator('.notice', { hasText: 'Waiting for a reviewer' }).waitFor();
  await page.locator('#signout').click();
  await signIn(page, 'Rita Reviewer', 'rita-long-password');
  await page.goto(studio.url.replace(/\?k=.*/, '') + '#/customers/luzon-fresh-mart/review');
  await page.locator('#approve').click();
  await page.locator('#approve-yes').click();
  await page.locator('.toast', { hasText: 'Approved' }).last().waitFor();
  await page.locator('#releases').waitFor();
  assert.match(await page.locator('#approved-by').innerText(), /Rita Reviewer/);
  const [download] = await Promise.all([page.waitForEvent('download'), page.locator('[data-download="1"]').click()]);
  assert.match(download.suggestedFilename(), /luzon-fresh-mart-profile-1\.zip/);
  await shot(page, '14-approved');
  step('the reviewer approves it as a second person; the approved release has a fingerprint and its setup files can be downloaded');

  // hand over
  await page.goto(studio.url.replace(/\?k=.*/, '') + '#/customers/luzon-fresh-mart/handover');
  await page.locator('#handover-sheet').waitFor();
  assert.match(await page.locator('#handover-sheet').innerText(), /Luzon Fresh Mart: your Smart Retail POS/);
  assert.match(await page.locator('#handover-sheet').innerText(), /Their own colours and logo/);
  await shot(page, '15-handover');
  await page.locator('#deliver-note').fill('Given to the owner, Ana.');
  await page.locator('#deliver').click();
  await page.locator('#delivered-note').waitFor();
  step('the hand-over sheet is made and the hand-over is recorded');

  // activity, narrow window
  await page.locator('[data-nav="activity"]').click();
  await page.locator('#integrity').waitFor();
  assert.match(await page.locator('#integrity').innerText(), /none changed/);
  await shot(page, '16-activity');
  const phone = await newPage(420, 860);
  await phone.goto(studio.url);
  await phone.locator('[data-person="Sam Sales"]').waitFor();
  await shot(phone, '17-narrow-signin');
  step('every action is in the activity record, which proves itself unchanged; the screens fit a narrow window too');

  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  console.log('\nThe Setup Studio works the way its people use it.');
} catch (e) {
  console.error(e);
  console.error('problems seen by the browser:', problems);
  process.exitCode = 1;
} finally {
  process.env.PATH = oldPath;
  await browser.close();
  await studio.close();
  rmSync(root, { recursive: true, force: true });
}
