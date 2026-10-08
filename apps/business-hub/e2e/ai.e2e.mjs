// The AI helpers screen (Version 2, phase 1): off until switched on, owner only, a licence part of its own; services are connected, tested and
// limited as the owner decides; card details never leave the computer; a key is kept out of sight. No AI service is needed to run this: a small
// stand-in on this computer answers the "are you there?" question.
import assert from 'node:assert';
import http from 'node:http';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('ai');
const step = (s) => console.log('✓ ' + s);

const stand = http.createServer((req, res) => {
  res.setHeader('content-type', 'application/json');
  res.end(req.url.endsWith('/models') ? JSON.stringify({ data: [{ id: 'small-a' }, { id: 'small-b' }] }) : '{}');
});
await new Promise((r) => stand.listen(0, '127.0.0.1', r));
const standUrl = `http://127.0.0.1:${stand.address().port}`;

let hub;
const openAi = async (page) => {
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'AI helpers' }).click();
  await page.getByRole('heading', { name: 'AI helpers', level: 1 }).waitFor();
};
const connect = async (page, { name, where, url, model = 'small-a', key = '' }) => {
  await page.locator('#n-name').fill(name);
  await page.locator('#n-where').selectOption(where);
  await page.locator('#n-url').fill(url);
  await page.locator('#n-model').fill(model);
  if (key) await page.locator('#n-key').fill(key);
  await page.locator('#n-add').click();
};

try {
  // ---- a licence without the AI part ---------------------------------------------------------------------------------------------------
  hub = await startHub();
  {
    const page = await newPage(browser, problems);
    await setUp(page, hub, { name: 'Corner Mart', demo: false });
    await signIn(page, hub);
    await openAi(page);
    assert.match(await page.locator('#ai-unlicensed').innerText(), /not part of this shop's licence/);
    assert.strictEqual(await page.locator('#n-add').isDisabled(), true);
    assert.strictEqual(await page.locator('#flag-ai_assistant').isDisabled(), true);
    await shot(page, '1-unlicensed');
    step('without the AI part in the licence the screen says so and nothing can be switched on or connected');
    await page.context().close();
  }
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  await hub.stop();

  // ---- a licence with the AI part --------------------------------------------------------------------------------------------------------
  hub = await startHub(['--E2E:Modules=hub,ai']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', demo: false });
  await signIn(page, hub);
  await openAi(page);

  assert.strictEqual(await page.locator('#ai-unlicensed').count(), 0);
  assert.match(await page.locator('#ai-computer').innerText(), /This computer[\s\S]*Memory:/);
  for (const key of ['ai_assistant', 'camera_analytics', 'local_embeddings', 'remote_ai', 'business_ontology', 'event_engine', 'predictive_inventory', 'advanced_rules'])
    assert.strictEqual(await page.locator(`#flag-${key}`).isChecked(), false, key + ' starts off');
  assert.match(await page.locator('#ai-services').innerText(), /No AI service is connected/);
  await shot(page, '2-licensed');
  step('with the AI part in the licence every switch starts off, no service is connected, and the computer is described in plain words');

  await page.locator('#flag-ai_assistant').check();
  await page.locator('.notice.ok', { hasText: 'Switched on.' }).waitFor();      // the Hub has kept the choice (a reload before that could cut it off on a slow machine)
  await page.reload();
  await page.locator('#flag-ai_assistant').waitFor();
  assert.strictEqual(await page.locator('#flag-ai_assistant').isChecked(), true);
  assert.strictEqual(await page.locator('#flag-remote_ai').isChecked(), false);
  step('a switch the owner turns on is still on after the page is opened again, and the others stay off');

  // ---- connecting services ---------------------------------------------------------------------------------------------------------------
  await connect(page, { name: 'Local helper', where: 'local', url: 'https://api.example.com' });
  await page.locator('.notice.error').first().waitFor();
  assert.match(await page.locator('.notice.error').first().innerText(), /points to this computer/);
  assert.strictEqual(await page.locator('#svc-local-helper').count(), 0);
  step('a service said to run on this computer is refused at an address that is not this computer');

  await connect(page, { name: 'Local helper', where: 'local', url: standUrl });
  await page.locator('#svc-local-helper').waitFor();
  assert.strictEqual(await page.locator('#on-local-helper').isChecked(), false);
  assert.match(await page.locator('#svc-local-helper').innerText(), /runs on this computer, so nothing leaves it/);
  await page.locator('#test-local-helper').click();
  await page.locator('#svc-local-helper .notice.ok').waitFor();
  assert.match(await page.locator('#svc-local-helper .notice.ok').innerText(), /answers and has 2 models/);
  await page.locator('#on-local-helper').check();
  await page.locator('.notice.ok', { hasText: 'Switched on.' }).waitFor();
  await page.reload();
  await page.locator('#on-local-helper').waitFor();
  assert.strictEqual(await page.locator('#on-local-helper').isChecked(), true);
  step('a service on this computer starts switched off, is tested without sending anything of the shop, and then switched on');

  const key = 'sk-test-KEEP-THIS-OUT-OF-SIGHT-9876';
  await connect(page, { name: 'Online helper', where: 'api', url: 'https://api.example.com/v1', key });
  await page.locator('#svc-online-helper').waitFor();
  const card = page.locator('#svc-online-helper');
  assert.strictEqual(await card.locator('#on-online-helper').isChecked(), false);
  assert.match(await card.innerText(), /Card and payment details: never leaves this computer/);
  assert.match(await card.innerText(), /Biometric data[^\n]*never leaves this computer/);
  assert.match(await card.innerText(), /Public information: may go there without asking/);
  assert.match(await card.innerText(), /Key \(one is kept\)/);
  assert.strictEqual(await page.locator('#allow-online-helper-PAYMENT_SENSITIVE').count(), 0, 'there is no box to allow card details');
  assert.strictEqual(await page.locator('#allow-online-helper-PERSONAL').isChecked(), false);
  await page.locator('#allow-online-helper-PERSONAL').check();
  await page.locator('.notice.ok', { hasText: 'Allowed.' }).waitFor();   // the Hub has kept the choice (a reload before that could cut it off on a slow machine)
  await page.reload();
  await page.locator('#allow-online-helper-PERSONAL').waitFor();
  assert.strictEqual(await page.locator('#allow-online-helper-PERSONAL').isChecked(), true);
  assert.strictEqual(await page.locator('#allow-online-helper-FINANCIAL').isChecked(), false);
  step('an online service may be allowed to receive some kinds of data and never card details or biometrics');

  const html = await page.content();
  assert.ok(!html.includes(key), 'the key is not in the page');
  assert.ok(!(await page.locator('#key-online-helper').inputValue()).includes('KEEP'), 'the key box is empty');
  assert.match(await card.innerText(), /Key \(one is kept\)/);
  step('the key that was typed is kept and never shown again, not even in the page');

  await page.locator('#svc-online-helper').getByRole('button', { name: 'Remove this service' }).click();
  await page.locator('#svc-online-helper').waitFor({ state: 'detached' });
  assert.strictEqual(await page.locator('#svc-local-helper').count(), 1);
  step('removing a service removes only that service');

  // ---- models --------------------------------------------------------------------------------------------------------------------------------
  await page.locator('#m-name').fill('small-a');
  await page.locator('#m-task').selectOption('generate');
  await page.locator('#m-lic').selectOption('no');
  await page.locator('#m-add').click();
  await page.locator('#ai-models table').waitFor();
  assert.match(await page.locator('#ai-models table').innerText(), /small-a[\s\S]*Candidate[\s\S]*Not allowed/);
  await page.locator('#ai-models').getByRole('button', { name: 'Start testing' }).click();
  await page.locator('#ai-models').getByText('Being tested').waitFor();
  assert.strictEqual(await page.locator('#ai-models').getByRole('button', { name: 'Put in use' }).count(), 1);
  await page.locator('#ai-models').getByRole('button', { name: 'Put in use' }).click();
  await page.locator('.notice.error').first().waitFor();
  assert.match(await page.locator('.notice.error').first().innerText(), /does not allow use in a business/);
  step('a model moves one stage at a time and one whose licence forbids business use cannot be put in use');

  // ---- the audit log keeps what was done -------------------------------------------------------------------------------------------------
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  for (const word of ['ai.flag', 'ai.provider.add', 'ai.provider.enable', 'ai.consent.grant', 'ai.secret.set', 'ai.provider.delete', 'ai.model.add'])
    assert.ok(activity.includes(word), 'the activity list shows ' + word);
  assert.ok(!activity.includes('KEEP-THIS-OUT-OF-SIGHT'), 'the activity list never shows a key');
  step('every change is in the activity list, and no key is');

  // ---- who is offered it -----------------------------------------------------------------------------------------------------------------
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
  assert.strictEqual(await page.getByRole('navigation', { name: 'Main' }).getByRole('link', { name: 'Settings', exact: true }).count(), 0, 'a manager has no Settings in the menu');
  await page.goto(hub.url + '/settings/ai');
  await page.getByRole('heading', { name: 'This is not for your role' }).waitFor();
  assert.strictEqual(await page.getByRole('heading', { name: 'AI helpers', level: 1 }).count(), 0);
  step('a manager has no settings menu and is told "this is not for your role" when typing the address of the AI helpers');

  await page.context().close();
  assert.deepStrictEqual(problems, [], 'the browser saw problems');
  await hub.stop();
  console.log('\nAI helpers: all steps passed.');
} catch (e) {
  console.error(e);
  if (hub) console.log(hub.log().split('\n').filter((l) => !l.includes('XmlKeyManager') && !l.includes('No XML encryptor')).slice(-40).join('\n'));
  process.exitCode = 1;
} finally {
  stand.close();
  await browser.close();
  if (hub) await hub.stop().catch(() => {});
}
process.exit(process.exitCode || 0);
