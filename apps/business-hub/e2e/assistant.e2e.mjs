// "Ask the shop" (Version 2, phase 6, step 1): off until the owner switches it on; with no AI service it still shows what it found in the owner's notes; with a (stand-in) AI service on this
// computer it chooses a lookup, the answer is written from the numbered facts and points at them, and a pointer to a fact that does not exist is taken out. The AI service here is a small
// program of this test that speaks the same web language as the usual local AI programs, so the real connection is used.
import assert from 'node:assert';
import http from 'node:http';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('assistant');
const step = (s) => console.log('✓ ' + s);
let hub;

const requests = [];
let answerMode = 'good';
const fake = http.createServer((req, res) => {
  let body = '';
  req.on('data', (d) => { body += d; });
  req.on('end', () => {
    res.setHeader('content-type', 'application/json');
    if (req.method === 'GET' && req.url === '/v1/models') { res.end(JSON.stringify({ data: [{ id: 'fake-model' }] })); return; }
    if (req.method === 'POST' && req.url === '/v1/chat/completions') {
      const payload = JSON.parse(body);
      requests.push(payload);
      const choosing = payload.messages[0].content.startsWith('You help a person who works in a shop');
      // The answer points at the sales fact, wherever it is in the list (a common word such as "we" can bring a note in before it).
      const sales = choosing ? null : /^\[(\d+)\] Sales for /m.exec(payload.messages[1].content)?.[1];
      const text = choosing
        ? JSON.stringify({ tools: [{ tool: 'sales.summary', args: { period: 'last-30-days' } }] })
        : answerMode === 'good' ? `The shop sold what the sales fact says [${sales}].` : `The shop sold a lot [${sales}] and also a loan [9].`;
      res.end(JSON.stringify({ model: 'fake-model', choices: [{ message: { role: 'assistant', content: text } }], usage: { prompt_tokens: 30, completion_tokens: 10 } }));
      return;
    }
    res.statusCode = 404;
    res.end('{}');
  });
});
await new Promise((r) => fake.listen(0, '127.0.0.1', r));
const fakeUrl = 'http://127.0.0.1:' + fake.address().port;

const ask = async (page, question) => {
  await page.locator('#as-q').fill(question);
  await page.locator('#as-go').click();
  await page.locator('#as-answer h2', { hasText: question }).waitFor({ timeout: 60000 });
};

try {
  hub = await startHub(['--E2E:Modules=hub,ai', '--E2E:Seed=true']);
  const page = await newPage(browser, problems);
  await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: true });
  await signIn(page, hub);

  // Off by default: no menu entry, and the page says how to switch it on.
  assert.strictEqual(await page.getByRole('navigation', { name: 'Main' }).getByRole('link', { name: 'Ask the shop', exact: true }).count(), 0);
  await page.goto(hub.url + '/ask');
  await page.getByRole('heading', { name: 'Ask the shop', level: 1 }).waitFor();
  assert.match(await page.locator('#as-off').innerText(), /switched off.*AI helpers/s);
  assert.strictEqual(await page.locator('#as-q').count(), 0);
  await shot(page, '1-off');
  step('it is off until the owner switches it on: no menu entry, no question box, and the screen says how');

  // The owner switches on "Business assistant" and "Search by meaning" (so that notes can be written), and writes a note.
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'AI helpers' }).click();
  await page.locator('#flag-ai_assistant').waitFor();
  await page.locator('#flag-ai_assistant').check();
  await page.locator('.notice.ok', { hasText: 'Switched on.' }).waitFor();
  await page.locator('#flag-local_embeddings').check();
  await page.waitForFunction(() => document.querySelector('#flag-local_embeddings').checked, null, { timeout: 15000 });
  await page.locator('#ai-knowledge-link').click();
  await page.getByRole('heading', { name: 'Notes to search', level: 1 }).waitFor();
  await page.locator('#kn-title').fill('Rice supplier');
  await page.locator('#kn-class').selectOption('INTERNAL');
  await page.locator('#kn-text').fill('The supplier gives a cheap price for rice when we order ten bags.');
  await page.locator('#kn-save').click();
  await page.locator('.notice.ok', { hasText: 'Kept.' }).waitFor();

  await go(page, 'Ask the shop');
  await page.getByRole('heading', { name: 'Ask the shop', level: 1 }).waitFor();
  assert.match(await page.locator('#as-can').innerText(), /your notes.*sales.*best sellers.*out of stock/s);
  step('once it is on, a menu entry appears and the owner is told what the assistant can look in');

  // No AI service at all: the notes are searched and the facts are shown; nothing fails.
  await ask(page, 'what price does the rice supplier give');
  await page.locator('#as-facts-only').waitFor();
  assert.match(await page.locator('#as-fact-1').innerText(), /Rice supplier.*note:1.*cheap price for rice/s);
  assert.match(await page.locator('#as-answer').innerText(), /No AI service/);
  assert.strictEqual(await page.locator('#as-text').count(), 0);
  await shot(page, '2-facts-only');
  step('with no AI service it still shows what it found in the notes, with where it came from, and says why there is no written answer');

  await ask(page, 'zebra giraffe');
  await page.locator('#as-nothing').waitFor();
  assert.strictEqual(await page.locator('#as-facts').count(), 0);
  step('when nothing is found it says so and does not make an answer up');

  // Connect a service on this computer (the test's own), switch it on, and ask a question about the sales.
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'AI helpers' }).click();
  await page.locator('#n-name').fill('Local test model');
  await page.locator('#n-url').fill(fakeUrl);
  await page.locator('#n-model').fill('fake-model');
  await page.locator('#n-add').click();
  await page.locator('.notice.ok', { hasText: 'Connected.' }).waitFor();
  const service = (await page.locator('[id^="svc-"]').first().getAttribute('id')).slice(4);
  await page.locator('#test-' + service).click();
  await page.locator('.notice.ok', { hasText: 'It answers' }).waitFor();
  await page.locator('#on-' + service).check();
  await page.waitForFunction((id) => document.querySelector('#on-' + id).checked, service, { timeout: 15000 });

  await go(page, 'Ask the shop');
  await ask(page, 'How much did we sell in the last 30 days?');
  await page.locator('#as-text').waitFor();
  assert.strictEqual((await page.locator('#as-text').innerText()).trim(), 'The shop sold what the sales fact says [2].');
  const fact = await page.locator('#as-facts tr', { hasText: 'Sales for the last 30 days' }).innerText();
  assert.match(fact, /^2\t/);
  assert.match(fact, /Sales for the last 30 days \(/);
  assert.match(fact, /from \d+ /);
  assert.match(fact, /used in the answer/);
  assert.doesNotMatch(await page.locator('#as-fact-1').innerText(), /used in the answer/, 'a note that only shares a common word with the question is shown but not marked as used');
  await shot(page, '3-answered');
  step('with a service on this computer: it chose the sales lookup, wrote the answer from the numbered fact, and the answer points at it');

  assert.strictEqual(requests.length, 2, 'one request to choose the lookups, one to write the answer');
  assert.match(requests[0].messages[0].content, /sales\.summary: /);
  assert.match(requests[0].messages[0].content, /JSON only/);
  assert.strictEqual(requests[0].messages[1].content, 'How much did we sell in the last 30 days?');
  assert.match(requests[1].messages[0].content, /^You are the assistant of a shop\./);
  assert.match(requests[1].messages[1].content, /^Facts:\n\[1\] From the note “Rice supplier” \(note:1\): .*\n\[2\] Sales for the last 30 days \(.*\n\nQuestion: How much did we sell in the last 30 days\?$/s);
  assert.strictEqual(requests[1].temperature, 0);
  step('the service was sent the instructions, the numbered fact and the question, and nothing else');

  answerMode = 'bad';
  await ask(page, 'How much did we sell in the last 30 days, again?');
  await page.locator('#as-text').waitFor();
  assert.strictEqual((await page.locator('#as-text').innerText()).trim(), 'The shop sold a lot [2] and also a loan.');
  assert.match(await page.locator('#as-answer').innerText(), /pointed at 1 fact that does not exist; that pointer was taken out/);
  step('a pointer to a fact that does not exist is taken out, and the screen says so');

  const recent = await page.locator('#as-recent').innerText();
  assert.match(recent, /How much did we sell in the last 30 days\?/);
  assert.match(recent, /answered/);
  assert.match(recent, /facts shown, no answer written/);
  assert.match(recent, /sales\.summary\(period=last-30-days\)/);
  assert.ok(!recent.includes('sales fact says'), 'the answers are not kept');
  step('the questions asked are listed with what was looked at and how each ended, without the answers');

  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Activity' }).click();
  await page.getByRole('heading', { name: 'What people did' }).waitFor();
  const activity = await page.locator('main').innerText();
  assert.ok(activity.includes('assistant.ask'));
  assert.ok(!activity.includes('rice supplier give'), 'the words of a question are not in the activity list');
  step('every question is in the activity list, without its words');
} finally {
  await browser.close();
  fake.close();
  if (problems.length) console.log('Browser problems:', problems);
  await hub?.stop();
}

assert.deepStrictEqual(problems, [], 'the browser saw problems');
console.log('\nAsk the shop: all steps passed.');
