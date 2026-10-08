// Starts the Hub on a fresh data folder for a browser test, and gives back what the test needs. The Hub is started with a stand-in for the licence
// (tests/NextGenOS.Hub.E2EHost); the real licence check is tested in the licensing library and the gate tests.
import { spawn, spawnSync } from 'node:child_process';
import { mkdtempSync, rmSync, mkdirSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import net from 'node:net';

const here = dirname(fileURLToPath(import.meta.url));
const host = resolve(here, '..', 'tests', 'NextGenOS.Hub.E2EHost');

export function build() {
  if (process.env.HUB_HOST_DLL) return;     // a published (and perhaps obfuscated) copy is being tested: nothing to build
  const r = spawnSync('dotnet', ['build', host, '-c', 'Release', '--nologo', '-v', 'q'], { encoding: 'utf8' });
  if (r.status !== 0) { console.error(r.stdout, r.stderr); process.exit(1); }
}

export async function freePort() {
  return new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); });
}

/** `files` are put in the data folder before the Hub starts (for example network.json, which the Hub reads before it opens its doors): { 'name': 'text' }. */
export async function startHub(extraArgs = [], { files = {} } = {}) {
  const data = mkdtempSync(join(tmpdir(), 'hub-e2e-'));
  for (const [name, text] of Object.entries(files)) writeFileSync(join(data, name), text);
  const port = await freePort();
  const url = `http://127.0.0.1:${port}`;
  const dll = process.env.HUB_HOST_DLL || join(host, 'bin', 'Release', 'net10.0', 'NextGenOS.Hub.E2EHost.dll');
  const child = spawn('dotnet', [dll, `--Hub:DataFolder=${data}`, `--urls=${url}`, `--Kestrel:Endpoints:Http:Url=${url}`, '--Logging:LogLevel:Default=Warning', ...extraArgs], { stdio: ['ignore', 'pipe', 'pipe'], env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Production', DOTNET_NOLOGO: '1' } });
  let log = '';
  child.stdout.on('data', (d) => { log += d; });
  child.stderr.on('data', (d) => { log += d; });
  for (let i = 0; i < 120; i += 1) {
    try { await fetch(`${url}/health`); break; } catch (_) { /* not up yet */ }
    await new Promise((r) => setTimeout(r, 250));
    if (i === 119) { child.kill(); throw new Error('The Hub did not start.\n' + log); }
  }
  return {
    url, data,
    log: () => log,
    stop: async () => { child.kill('SIGTERM'); await new Promise((r) => setTimeout(r, 300)); rmSync(data, { recursive: true, force: true }); },
  };
}

export async function launch(args = [], options = {}) {
  const { chromium } = await import('playwright');
  const browser = await chromium.launch({ args, ...options });
  return browser;
}

/** A page that records every problem the browser sees: console errors, failed requests, page errors. */
export async function newPage(browser, problems, viewport = { width: 1360, height: 860 }, permissions = []) {
  const context = await browser.newContext({ viewport, permissions });
  const page = await context.newPage();
  page.on('console', (m) => { if (m.type() === 'error') problems.push('console: ' + m.text()); });
  page.on('pageerror', (e) => problems.push('pageerror: ' + e.message));
  page.on('requestfailed', (r) => {
    if (r.url().endsWith('/_blazor/disconnect') && r.failure()?.errorText === 'net::ERR_ABORTED') return;
    if (r.failure()?.errorText === 'net::ERR_ABORTED') return;
    problems.push('requestfailed: ' + r.url() + ' ' + r.failure()?.errorText);
  });
  page.on('response', (r) => { if (r.status() >= 500) problems.push('http ' + r.status() + ': ' + r.url()); });
  return page;
}

const KIND = { retail: 'Retail store', restaurant: 'Restaurant', library: 'Library', construction: 'Construction', services: 'Services', wholesale: 'Wholesale', generic: 'Any other' };

/** Runs the setup wizard in the browser: a business of the given kind in the given country, with or without the sample company. */
export async function setUp(page, hub, { name = 'Test Business', country = 'India', region = 'Maharashtra', industry = 'retail', demo = true, owner = 'owner', password = 'a-long-test-password', salesTax = null } = {}) {
  await page.goto(hub.url + '/');
  await page.waitForURL('**/setup');
  await page.getByLabel('Business name').fill(name);
  await page.getByLabel('Country').selectOption({ label: country });
  await page.waitForTimeout(500);           // the form is redrawn for the country chosen
  const regionBox = page.locator('#region');
  if (await regionBox.count()) await regionBox.selectOption({ label: region });
  if (salesTax !== null) await page.getByLabel(/Sales tax at your shop/).fill(String(salesTax));
  await page.getByRole('button', { name: 'Next' }).click();
  await page.getByRole('button', { name: new RegExp('^' + KIND[industry]) }).click();
  await page.getByRole('button', { name: 'Next' }).click();
  await page.getByLabel('Your name').fill('Olivia Owner');
  await page.getByLabel('User name').fill(owner);
  await page.getByLabel('Password (at least 8 characters)').fill(password);
  await page.getByLabel('Password again').fill(password);
  await page.getByRole('button', { name: 'Next' }).click();
  const sample = page.getByLabel('Fill with a sample business so I can look around');
  if (demo) await sample.check(); else await sample.uncheck();
  await page.getByRole('button', { name: 'Finish' }).click();
  try {
    await page.waitForURL('**/login', { timeout: 60000 });
  } catch (e) {
    // Say what the screen showed (a refusal from the program is written there), so that a stall is not a mystery.
    const text = (await page.locator('body').innerText({ timeout: 5000 }).catch(() => '(the page could not be read)')).replace(/\s+/g, ' ').slice(0, 600);
    throw new Error('The setup did not reach the sign-in page within 60 seconds. The screen says: ' + text + '\n' + e.message);
  }
}

export async function signIn(page, hub, user = 'owner', password = 'a-long-test-password') {
  await page.goto(hub.url + '/login');
  await page.getByLabel('User name').fill(user);
  await page.getByLabel('Password', { exact: true }).fill(password);
  await page.getByRole('button', { name: 'Sign in' }).click();
  await page.waitForURL(hub.url + '/');
  await page.getByRole('heading', { name: 'Today' }).waitFor();
}

export function shots(name) {
  const dir = process.env.HUB_SHOTS || join(tmpdir(), 'hub-shots');
  mkdirSync(dir, { recursive: true });
  return (page, label) => page.screenshot({ path: join(dir, `${name}-${label}.png`), fullPage: true });
}

/** Opens a screen from the side menu. */
export async function go(page, name) {
  await page.getByRole('navigation', { name: 'Main' }).getByRole('link', { name, exact: true }).click();
}

/** A stand-in network printer: it keeps every byte it is sent, so a test can see what would have been printed. */
export async function fakePrinter() {
  const chunks = [];
  const server = net.createServer((socket) => { socket.on('data', (d) => chunks.push(d)); socket.on('error', () => {}); });
  await new Promise((r) => server.listen(0, '127.0.0.1', r));
  return {
    port: server.address().port,
    bytes: () => Buffer.concat(chunks),
    text: () => Buffer.concat(chunks).toString('latin1'),
    clear: () => { chunks.length = 0; },
    close: () => new Promise((r) => server.close(r)),
  };
}

/** A port nothing listens on: a printer that is switched off. */
export function deadPort() { return new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); }); }
