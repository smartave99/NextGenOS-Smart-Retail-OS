// The cameras register (Version 2, phase 7, step 1): off until the owner switches "Camera analytics" on; a camera must be on this computer or the shop's own network; no password in an address; a
// camera is switched on only after the program has reached it; its password goes to the safe place and is never shown; moving a camera switches it off again; retiring one deletes its password.
// The "camera" here is a small program of this test that only counts what it is sent: the program must connect and let go, and say nothing.
import assert from 'node:assert';
import net from 'node:net';
import { build, startHub, launch, newPage, setUp, signIn, shots, go, deadPort } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('cameras');
const step = (s) => console.log('✓ ' + s);
let hub;

let connections = 0;
let bytes = 0;
const door = net.createServer((socket) => { connections += 1; socket.on('data', (d) => { bytes += d.length; }); socket.on('error', () => {}); });
await new Promise((r) => door.listen(0, '127.0.0.1', r));
const doorPort = door.address().port;

const secret = 'zebra-pass-7741';

/** Fills the form; anything left out is left as it is. */
const fill = async (page, { name, kind, address, zone, confidence }) => {
  if (name !== undefined) await page.locator('#cam-name').fill(name);
  if (kind !== undefined) await page.locator('#cam-kind').selectOption(kind);
  if (address !== undefined) await page.locator('#cam-addr').fill(address);
  if (zone !== undefined) await page.locator('#cam-zone').fill(zone);
  if (confidence !== undefined) await page.locator('#cam-conf').fill(confidence);
};
const error = (page, pattern) => page.locator('.notice.error', { hasText: pattern }).waitFor({ timeout: 15000 });
const info = (page, pattern) => page.locator('.notice.ok', { hasText: pattern }).waitFor({ timeout: 15000 });

try {
  hub = await startHub(['--E2E:Modules=hub,ai', '--E2E:Seed=true']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: true });
  await signIn(page, hub);

  // Off by default: the screen says so, and adding is refused in plain words.
  await page.goto(hub.url + '/settings/cameras');
  await page.getByRole('heading', { name: 'Cameras', level: 1 }).waitFor();
  assert.match(await page.locator('#cam-off').innerText(), /switched off.*AI helpers/s);
  assert.strictEqual(await page.locator('#cam-none').count(), 1);
  await fill(page, { name: 'Front door', address: `rtsp://127.0.0.1:${doorPort}/stream1` });
  await page.locator('#cam-save').click();
  await error(page, /Camera analytics is switched off/);
  assert.strictEqual(await page.locator('#cam-none').count(), 1, 'nothing was added');
  await shot(page, '1-off');
  step('it is off until the owner switches it on: the screen says how, and nothing can be added');

  // The owner switches it on under AI helpers; the AI helpers page links to the cameras.
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'AI helpers' }).click();
  await page.locator('#flag-camera_analytics').waitFor();
  await page.locator('#flag-camera_analytics').check();
  await info(page, 'Switched on.');
  assert.match(await page.locator('main').innerText(), /does not watch or read any camera/);
  await page.locator('#ai-cameras-link').click();
  await page.getByRole('heading', { name: 'Cameras', level: 1 }).waitFor();
  assert.strictEqual(await page.locator('#cam-off').count(), 0);
  step('once "Camera analytics" is on, the Cameras page is open for adding, and the switch says the program does not read any camera yet');

  // Refusals, in plain words: a camera on the internet, a password in the address, nothing to look for.
  await fill(page, { name: 'Front door', kind: 'rtsp', address: 'rtsp://8.8.8.8/stream1' });
  await page.locator('#cam-save').click();
  await error(page, /on this computer or on the shop's own network/);
  await fill(page, { address: `rtsp://admin:${secret}@127.0.0.1:${doorPort}/stream1` });
  await page.locator('#cam-save').click();
  await error(page, /Do not put a user name or password in the address/);
  assert.doesNotMatch(await page.locator('main').innerText(), new RegExp(secret), 'a password typed into the address is not shown back');
  await fill(page, { address: `rtsp://127.0.0.1:${doorPort}/stream1` });
  await page.locator('#cam-class-person').uncheck();
  await page.locator('#cam-save').click();
  await error(page, /Choose at least one thing/);
  assert.strictEqual(await page.locator('#cam-class-face').count(), 0, 'there is no choice for a face');
  assert.doesNotMatch(await page.locator('#cam-form').innerText(), /face recogni|who anyone is(?!\.)/i);
  assert.match(await page.locator('#cam-form').innerText(), /does not look at faces and does not know who anyone is/);
  assert.strictEqual(await page.locator('#cam-none').count(), 1);
  step('an address on the internet, a password in the address and "look for nothing" are refused; there is no choice for a face');

  // A good one: it starts switched off and not checked.
  await page.locator('#cam-class-person').check();
  await fill(page, { zone: 'zone:entrance', confidence: '60' });
  await page.locator('#cam-save').click();
  await info(page, 'Added. It is switched off');
  const row = page.locator('#cam-table tbody tr').first();
  const text = await row.innerText();
  assert.match(text, /Front door/);
  assert.match(text, /camera:front-door/);
  assert.match(text, /Looks at zone:entrance/);
  assert.match(text, /at least 60% sure/);
  assert.match(text, /not checked yet/);
  assert.match(text, /Switched off/);
  assert.strictEqual(connections, 0, 'adding a camera does not connect to it');
  await shot(page, '2-added');
  step('the camera is kept switched off and not checked, and adding it connects to nothing');

  // Switching on before it was reached is refused.
  const id = (await row.getAttribute('id')).slice(4);
  await page.locator('#cam-switch-' + id).click();
  await error(page, /Test the camera first/);
  assert.match(await row.innerText(), /Switched off/);
  step('it cannot be switched on before the program has reached it');

  // Test: the program connects, lets go and says nothing; the stand-in camera is sent no bytes.
  await page.locator('#cam-test-' + id).click();
  await info(page, /Front door: The camera answered at 127\.0\.0\.1:\d+\. No picture was read\./);
  await page.waitForFunction(() => document.querySelector('#cam-table tbody tr').innerText.includes('reached'), null, { timeout: 15000 });
  assert.doesNotMatch(await row.innerText(), /not reached|not checked yet/);
  assert.strictEqual(connections, 1);
  await new Promise((r) => setTimeout(r, 500));
  assert.strictEqual(bytes, 0, 'the program sent the camera nothing: no request, no picture asked for');
  step('the test connects once and lets go: the stand-in camera was sent nothing');

  await page.locator('#cam-switch-' + id).click();
  await info(page, /Switched on\. It is not read yet/);
  assert.match(await row.innerText(), /Switched on/);
  await shot(page, '3-on');
  step('after it was reached it can be switched on, and the screen says it is not read yet');

  // The password: kept in the safe place, never shown.
  await row.getByRole('button', { name: 'Change' }).click();
  await page.getByRole('heading', { name: 'Change the camera', level: 3 }).waitFor();
  await page.locator('#cam-secret').fill(secret);
  await page.locator('#cam-key').click();
  await info(page, 'Kept in a safe place');
  assert.match(await row.innerText(), /password kept/);
  assert.strictEqual(await page.locator('#cam-secret').inputValue(), '');
  assert.ok(!(await page.content()).includes(secret), 'the password is not anywhere on the page');
  await page.locator('#cam-key-remove').waitFor();
  step('the password goes to the safe place; the page says only that one is kept, and never shows it');

  // Changing only the name keeps it on; moving it switches it off and forgets the check.
  await fill(page, { name: 'Door camera' });
  await page.locator('#cam-save').click();
  await page.locator('#cam-table tbody tr', { hasText: 'Door camera' }).waitFor({ timeout: 15000 });
  assert.match(await row.innerText(), /Switched on/);
  await row.getByRole('button', { name: 'Change' }).click();
  await page.getByRole('heading', { name: 'Change the camera', level: 3 }).waitFor();   // the form is filled with the camera's own words only after this
  await fill(page, { address: `rtsp://127.0.0.1:${doorPort}/other` });
  await page.locator('#cam-save').click();
  await page.locator('#cam-table tbody tr', { hasText: '/other' }).waitFor({ timeout: 15000 });
  assert.match(await row.innerText(), /Switched off/);
  assert.match(await row.innerText(), /not checked yet/);
  await page.locator('#cam-switch-' + id).click();
  await error(page, /Test the camera first/);
  step('a new name keeps the camera on; a new address switches it off and forgets the check');

  // A camera that does not answer cannot be switched on.
  const closed = await deadPort();
  await fill(page, { name: 'Back room', kind: 'rtsp', address: `rtsp://127.0.0.1:${closed}/s`, zone: '' });
  await page.locator('#cam-save').click();
  await page.locator('#cam-table tbody tr', { hasText: 'Back room' }).waitFor({ timeout: 15000 });
  const back = page.locator('#cam-table tbody tr', { hasText: 'Back room' });
  const backId = (await back.getAttribute('id')).slice(4);
  await page.locator('#cam-test-' + backId).click();
  await info(page, /Back room: The camera could not be reached/);
  assert.match(await back.innerText(), /not reached/);
  await page.locator('#cam-switch-' + backId).click();
  await error(page, /could not reach this camera/);
  assert.match(await back.innerText(), /Switched off/);
  await shot(page, '4-not-reached');
  step('a camera that does not answer says so, and cannot be switched on');

  // The record: names, never the address or the password.
  await back.getByRole('button', { name: 'Retire' }).click();
  await info(page, 'Retired.');
  assert.strictEqual(await page.locator('#cam-table tbody tr', { hasText: 'Back room' }).count(), 0);
  await row.getByRole('button', { name: 'Retire' }).click();
  await info(page, 'Retired. Its password was deleted.');
  await page.locator('#cam-none').waitFor();
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  for (const action of ['camera.add', 'camera.test', 'camera.enable', 'camera.password', 'camera.update', 'camera.retire']) assert.ok(activity.includes(action), action + ' is in the activity list');
  assert.ok(!activity.includes('127.0.0.1') && !activity.includes('stream1') && !activity.includes(secret), 'the activity list has the camera names, not the addresses or the password');
  step('retiring removes a camera from the list and deletes its password; the activity list has names only');
} finally {
  await browser.close();
  door.close();
  if (problems.length) console.log('Browser problems:', problems);
  await hub?.stop();
}

assert.deepStrictEqual(problems, [], 'the browser saw problems');
console.log('\nCameras: all steps passed.');
