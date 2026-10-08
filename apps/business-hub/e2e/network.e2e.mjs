// The main PC and a counter PC, for real: the Hub listens on the shop's network with its own certificate, a second browser (standing in for a counter PC, reaching the Hub by this PC's
// network address, not 127.0.0.1) is refused until it is paired with a one-time code, then works like a screen of the shop; removing it cuts it off at once; switching counter PCs off
// refuses everyone. The counter PC is told to trust the shop's certificate the way a person would be (by the certificate's own fingerprint), and the Hub's certificate is also checked
// against the shop's authority by Node's own TLS, with the address as the name.
import assert from 'node:assert';
import https from 'node:https';
import tls from 'node:tls';
import crypto from 'node:crypto';
import os from 'node:os';
import { build, startHub, launch, newPage, setUp, signIn, shots, freePort } from './lib.mjs';

const lan = Object.values(os.networkInterfaces()).flat().find((i) => i && i.family === 'IPv4' && !i.internal)?.address;
if (!lan) {
  console.error('This test needs a network address besides 127.0.0.1 (a computer with no network at all cannot test the shop network).');
  process.exit(1);
}

build();
const netPort = await freePort();
const hub = await startHub([], { files: { 'network.json': JSON.stringify({ enabled: true, port: netPort }) } });
const shop = `https://${lan}:${netPort}`;
let owner;
let counter;
const problems = [];
const counterProblems = [];
const shot = shots('network');
const step = (s) => console.log('✓ ' + s);

/** One request over the shop's network, the way a browser sends it; `ca` is what the caller trusts (nothing: the system's own list, which does not hold the shop's certificate). */
function ask(path, { ca, cookie, method = 'GET', body, headers = {}, insecure = false } = {}) {
  return new Promise((resolve, reject) => {
    const req = https.request(shop + path, { method, ca, rejectUnauthorized: !insecure, headers: { ...(cookie ? { cookie } : {}), ...headers } }, (res) => {
      const chunks = [];
      res.on('data', (d) => chunks.push(d));
      res.on('end', () => resolve({ status: res.statusCode, headers: res.headers, text: Buffer.concat(chunks).toString('utf8') }));
    });
    req.on('error', reject);
    if (body) req.write(body);
    req.end();
  });
}

try {
  owner = await launch();
  const page = await newPage(owner, problems);
  await setUp(page, hub, { name: 'Quiet Corner', industry: 'retail', demo: false });
  await signIn(page, hub);

  // ---- the owner's screen on the main PC ------------------------------------------------------------------------------------
  await page.goto(hub.url + '/settings/network');
  await page.locator('#net-state', { hasText: 'Counter PCs can connect now.' }).waitFor();
  const letters = (await page.locator('#net-letters').innerText()).replace(/\s+/g, '').toLowerCase();
  assert.match(letters, /^[0-9a-f]{64}$/, 'check letters are the 64 hex letters of the certificate fingerprint: ' + letters);
  assert.match(await page.locator('#net-add').innerText(), new RegExp(`https://${lan.replace(/\./g, '\\.')}:${netPort}/pair`));
  assert.match(await page.locator('#net-use').innerText(), /no limit/);
  await shot(page, '1-owner-screen');
  step('the owner sees that counter PCs can connect, the addresses to use, and the check letters');

  // ---- the shop's certificate -----------------------------------------------------------------------------------------------
  await assert.rejects(ask('/health'), /self[- ]signed|unable to (verify|get)|certificate/i, 'a computer that does not know the shop\'s certificate cannot trust the connection');
  const pem = (await ask('/pair/ca.crt', { insecure: true })).text;
  assert.match(pem, /^-----BEGIN CERTIFICATE-----/);
  assert.doesNotMatch(pem, /PRIVATE KEY/);
  const authority = new crypto.X509Certificate(pem);
  assert.strictEqual(authority.fingerprint256.replace(/:/g, '').toLowerCase(), letters, 'the certificate offered has the fingerprint the owner sees on the main PC');
  const trusted = await ask('/health', { ca: pem });
  assert.strictEqual(trusted.status, 200, 'the server\'s certificate is accepted when the shop\'s authority is trusted, with the address as its name');
  step('the connection is protected by the shop\'s own certificate, which is the one the owner\'s check letters name, and it is valid for this PC\'s address');

  // ---- a computer that is not paired ----------------------------------------------------------------------------------------
  for (const path of ['/', '/login', '/sell', '/_blazor/negotiate?negotiateVersion=1', '/_framework/blazor.web.js']) {
    const answer = await ask(path, { ca: pem });
    assert.strictEqual(answer.status, 403, path);
    assert.match(answer.text, /has not been paired/);
    assert.doesNotMatch(answer.text, /Quiet Corner/);
  }
  assert.match((await ask('/pair', { ca: pem })).text, /Pairing code/);
  step('a computer that is not paired is refused everywhere except the pairing page, and learns nothing of the shop');

  // ---- pairing from a second browser ----------------------------------------------------------------------------------------
  await page.reload();
  await page.locator('#net-code-make').click();
  const code = (await page.locator('#net-code').innerText()).trim();
  assert.match(code, /^[A-Z0-9]{4}-[A-Z0-9]{4}$/);
  await shot(page, '2-code');

  // The second browser is told to accept this PC's certificate (a person would install the shop's authority on the computer instead; Chromium cannot be given one from a script, and the
  // chain and the name were checked above by Node's own TLS). What this part proves is that a real browser works over the connection: pages, the secure cookie, the live screen.
  const leaf = await new Promise((resolve, reject) => {
    const socket = tls.connect({ host: lan, port: netPort, rejectUnauthorized: false }, () => { const raw = socket.getPeerCertificate().raw; socket.end(); resolve(new crypto.X509Certificate(raw)); });
    socket.on('error', reject);
  });
  const spki = crypto.createHash('sha256').update(leaf.publicKey.export({ type: 'spki', format: 'der' })).digest('base64');
  const env = Object.fromEntries(Object.entries(process.env).filter(([name]) => !/proxy/i.test(name)));
  counter = await launch([`--ignore-certificate-errors-spki-list=${spki}`], { env });
  const other = await newPage(counter, counterProblems);
  const sockets = [];
  other.on('websocket', (ws) => { const s = { url: ws.url(), closed: false }; ws.on('close', () => { s.closed = true; }); sockets.push(s); });
  await other.goto(shop + '/');
  assert.match(await other.locator('body').innerText(), /has not been paired with this shop/);
  await other.getByRole('link', { name: 'Pair this computer' }).click();
  await other.waitForURL('**/pair');
  await other.getByLabel('Pairing code').fill('WRNG-CODE');
  await other.getByLabel('A name for this computer').fill('Counter 2');
  await other.getByRole('button', { name: 'Connect' }).click();
  await other.locator('.problem', { hasText: 'not right' }).waitFor();
  await other.getByLabel('Pairing code').fill(code.toLowerCase());     // typed in small letters: it is the same code
  await other.getByLabel('A name for this computer').fill('Counter 2');
  await other.getByRole('button', { name: 'Connect' }).click();
  await other.locator('.ok', { hasText: 'paired as' }).waitFor();
  assert.match(await other.locator('body').innerText(), /Counter 2/);
  await shot(other, '3-paired');
  const cookies = await other.context().cookies();
  const device = cookies.find((c) => c.name === 'hub.device');
  assert.ok(device, 'the counter PC holds its token');
  assert.ok(device.httpOnly && device.secure && device.sameSite === 'Strict', 'the token cannot be read by a script, is sent only over the secure connection, and never to another site');
  step('a wrong code is refused in plain words; the right code, typed in small letters, pairs the counter PC once');

  // The code is used up.
  const again = await newPage(counter, counterProblems);
  await again.goto(shop + '/pair');
  await again.getByLabel('Pairing code').fill(code);
  await again.getByLabel('A name for this computer').fill('Counter 3');
  await again.getByRole('button', { name: 'Connect' }).click();
  await again.locator('.problem', { hasText: 'not right' }).waitFor();
  await again.context().close();
  step('the same code does not work a second time');

  // ---- working at the counter PC -------------------------------------------------------------------------------------------
  await other.goto(shop + '/login');
  await other.getByLabel('User name').fill('owner');
  await other.getByLabel('Password', { exact: true }).fill('a-long-test-password');
  await other.getByRole('button', { name: 'Sign in' }).click();
  await other.waitForURL(shop + '/');
  await other.getByRole('heading', { name: 'Today' }).waitFor();
  await other.goto(shop + '/sell');
  await other.getByRole('heading', { name: /Sell|Counter|Sale/ }).first().waitFor();
  assert.ok(sockets.some((s) => s.url.startsWith('wss://') && s.url.includes(lan)), 'the live screen runs over the shop\'s secure connection: ' + JSON.stringify(sockets));
  await shot(other, '4-at-the-counter');
  step('at the counter PC people sign in with their own user name and password, and the shop\'s screens work over the shop network');

  // ---- the owner sees it and removes it ------------------------------------------------------------------------------------
  await page.reload();
  const row = page.locator('#net-counters tbody tr', { hasText: 'Counter 2' });
  await row.waitFor();
  assert.match(await row.innerText(), new RegExp(lan.replace(/\./g, '\\.')));
  await row.locator('button', { hasText: 'Remove' }).click();
  await row.locator('button', { hasText: 'Yes, remove' }).click();
  await page.locator('.notice.ok', { hasText: 'Removed.' }).waitFor();
  await page.locator('#net-counters .empty').waitFor();
  const live = sockets.filter((s) => s.url.startsWith('wss://'));
  for (let i = 0; i < 80 && !live.every((s) => s.closed); i += 1) await new Promise((r) => setTimeout(r, 125));
  assert.ok(live.every((s) => s.closed), 'removing a counter PC ends its open screen at once');
  await other.goto(shop + '/');
  assert.match(await other.locator('body').innerText(), /has not been paired with this shop/);
  const gone = await ask('/login', { ca: pem, cookie: `hub.device=${device.value}` });
  assert.strictEqual(gone.status, 403);
  step('removing the counter PC from the main PC cuts its open screen and refuses its next request');

  // ---- switching off ---------------------------------------------------------------------------------------------------------
  await page.goto(hub.url + '/settings/network');
  await page.locator('#net-code-make').click();
  const second = (await page.locator('#net-code').innerText()).trim();
  await other.goto(shop + '/pair');
  await other.getByLabel('Pairing code').fill(second);
  await other.getByLabel('A name for this computer').fill('Counter 2');
  await other.getByRole('button', { name: 'Connect' }).click();
  await other.locator('.ok', { hasText: 'paired as' }).waitFor();
  assert.strictEqual((await ask('/health', { ca: pem })).status, 200);

  await page.locator('#net-on').uncheck();
  await page.locator('#net-save').click();
  await page.locator('.notice.ok', { hasText: 'Counter PCs are refused from now on.' }).waitFor();
  assert.strictEqual((await ask('/health', { ca: pem })).status, 403, 'nothing at all is served to the network once counter PCs are switched off');
  assert.strictEqual((await ask('/pair', { ca: pem })).status, 403);
  await other.goto(shop + '/');
  assert.match(await other.locator('body').innerText(), /has not been paired with this shop/);
  await page.goto(hub.url + '/');
  await page.getByRole('heading', { name: 'Today' }).waitFor();      // this PC carries on as before
  step('switching counter PCs off refuses every computer on the network at once, and the main PC carries on');

  // ---- what was written down ------------------------------------------------------------------------------------------------
  await page.goto(hub.url + '/settings?tab=activity');
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  // Switching on was done before the Hub started (the file was written first), so the list holds no line for it. A computer turned away is written once in a while for each address
  // (a wrong code and a page asked for without being paired from the same address count as one), so either line shows it.
  for (const word of ['network.code', 'network.pair', 'network.revoke', 'network.disable'])
    assert.ok(activity.includes(word), 'the activity list shows ' + word);
  assert.ok(activity.includes('network.refused') || activity.includes('network.pair-refused'), 'the activity list shows that a computer was turned away');
  step('pairing, removal and refusals are in the list of what people did');

  assert.deepStrictEqual(problems, [], 'the main PC\'s browser saw problems');
  // The counter PC's browser is cut off on purpose (removed, then switched off), so its live screen complains in the console and its requests fail; a script error or a server error (5xx) is never expected.
  const unexpected = counterProblems.filter((p) => !(p.startsWith('console: ') && /\b40[03]\b|WebSocket|negotiat|Failed to fetch|Failed to load resource|reconnect|circuit/i.test(p)) && !/^requestfailed: .*net::ERR_/.test(p));
  assert.deepStrictEqual(unexpected, [], 'the counter PC\'s browser saw problems that were not expected');
  console.log('\nAll network checks passed.');
} catch (e) {
  console.error('\nFAILED:', e.message);
  console.error('Main PC browser problems:', problems);
  console.error('Counter PC browser problems:', counterProblems);
  console.error(hub.log().slice(-3000));
  process.exitCode = 1;
} finally {
  await owner?.close().catch(() => {});
  await counter?.close().catch(() => {});
  await hub.stop();
}
