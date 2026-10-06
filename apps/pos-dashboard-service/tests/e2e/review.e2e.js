// End-to-end check of the Monday review, in Chromium: Today's reminder, last week against the week before and a year
// before, the stock rules' alerts (running out, not selling) and the owner's decision on each, kept in the data
// folder's Memory folder, then judged on its review day from the POS's figures, and the week marked as reviewed. It
// starts the app itself on demo data (two years of bills):
//   npm install && npm run test:review          (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-review-'));
const settingsFile = path.join(work, 'settings.json');
const dataFolder = path.join(work, 'data');
fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli' }, null, 2));
fs.writeFileSync(path.join(work, 'storage.json'), JSON.stringify({ DataFolder: dataFolder }));
const decisionsFile = path.join(dataFolder, 'Memory', 'decisions.json');
// Something the shop is trying: noted on the Actions page three weeks ago, still going on.
fs.mkdirSync(path.join(dataFolder, 'Memory'), { recursive: true });
const book = () => JSON.parse(fs.readFileSync(decisionsFile, 'utf8'));

async function startApp() {
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Ai__SettingsFile: settingsFile },
    stdio: 'ignore',
    detached: process.platform !== 'win32',
  });
  let last = 'no answer';
  for (let i = 0; i < 180; i++) {
    try {
      const answer = await fetch(BASE + '/');
      if (answer.ok) return app;
      last = answer.status + ' ' + (await answer.text()).replace(/\s+/g, ' ').slice(0, 160);
    } catch { /* not up yet */ }
    await new Promise(r => setTimeout(r, 1000));
  }
  stopApp(app); // never leave it running, holding the port for the next try
  throw new Error('The app did not start on ' + BASE + ' (last answer: ' + last + '). A 402 means the licence gate is closed: run the test through with-licence.mjs.');
}

function stopApp(app) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid); } catch { /* gone */ }
}

async function until(check, what, ms = 10000) {
  const end = Date.now() + ms;
  for (;;) {
    let value;
    try { value = check(); } catch { value = false; }
    if (value) return value;
    if (Date.now() > end) throw new Error('Timed out waiting for ' + what);
    await new Promise(r => setTimeout(r, 100));
  }
}

// Days as the POS and decisions.json count them, from today on this PC.
const MONTHS = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
const dayOf = (offset) => { const d = new Date(); d.setHours(12, 0, 0, 0); d.setDate(d.getDate() + offset); return d; };
const iso = (d) => `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
const lastWeekName = () => {
  const monday = dayOf(-(((new Date().getDay() + 6) % 7) + 7));
  const sunday = new Date(monday);
  sunday.setDate(monday.getDate() + 6);
  return monday.getMonth() === sunday.getMonth()
    ? `${monday.getDate()}–${sunday.getDate()} ${MONTHS[sunday.getMonth()]}`
    : `${monday.getDate()} ${MONTHS[monday.getMonth()]} – ${sunday.getDate()} ${MONTHS[sunday.getMonth()]}`;
};

fs.writeFileSync(path.join(dataFolder, 'Memory', 'actions.json'), JSON.stringify({
  Actions: [{
    Id: 'erickshaw', Title: 'E-rickshaw ads around the market', Kind: 'Advert', Start: iso(dayOf(-21)), End: null, Cost: 6000,
    ProductIds: [], ProductNames: [], Expected: '', Source: 'Owner', Added: `${iso(dayOf(-21))}T10:00:00`, Cancelled: false, Lesson: null,
  }, {
    // A new product whose test was judged yesterday: it waits for the owner's decision.
    Id: 'oiltest', Title: 'Sunflower oil in a new pack', Kind: 'NewProduct', Start: iso(dayOf(-29)), End: null, Cost: 0,
    ProductIds: [6], ProductNames: ['Sunflower Oil 1 L'], Expected: '', Source: 'Owner', Added: `${iso(dayOf(-29))}T10:00:00`, Cancelled: false, Lesson: null,
    Test: { Signal: 'CustomersAsked', Bought: 24, Hoped: 20, ReviewOn: iso(dayOf(-1)), Decision: null, DecisionNote: '', DecidedOn: null },
  }],
  Suggested: [],
}, null, 2));

async function noSidewaysScroll(page, url) {
  await page.setViewportSize({ width: 390, height: 844 });
  await page.goto(url, { waitUntil: 'networkidle' });
  await page.locator('.review-week').waitFor();
  const wide = await page.evaluate(() => document.documentElement.scrollWidth - document.documentElement.clientWidth);
  assert.ok(wide <= 1, `${url} scrolls sideways by ${wide}px at phone width`);
  await page.screenshot({ path: `${OUT}/review-phone.png`, fullPage: true });
  await page.setViewportSize({ width: 1366, height: 900 });
}

(async () => {
  const app = await startApp();
  const browser = await chromium.launch();
  const errors = [];
  try {
    const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
    page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
    page.on('pageerror', e => errors.push(e.message));

    await page.goto(BASE + '/', { waitUntil: 'networkidle' });
    const reminder = page.locator('.suggestion', { hasText: 'Your Monday review is ready' });
    await reminder.waitFor();
    assert.ok((await reminder.innerText()).includes(`How last week (${lastWeekName()}) went`), await reminder.innerText());
    const testDone = page.locator('.suggestion', { hasText: 'Sunflower oil in a new pack: its test is done' });
    assert.strictEqual(await testDone.getByRole('link', { name: 'Decide' }).getAttribute('href'), 'actions');
    await reminder.getByRole('link', { name: 'Review the week' }).click();
    await page.waitForURL(/\/review$/);
    step('Today reminds the owner of the Monday review and of a new product whose test is done, and opens the review');

    await page.locator('.review-week', { hasText: `Last week, ${lastWeekName()}` }).waitFor();
    const kpis = await page.locator('.kpis .kpi').allInnerTexts();
    assert.deepStrictEqual(kpis.map(k => k.split('\n')[0]), ['Sales', 'Bills', 'Average bill', 'Profit before GST']);
    assert.ok(/^₹[\d,]+$/.test((await page.locator('.kpis .kpi-value').first().innerText()).trim()), 'no sales figure');
    assert.ok(kpis[0].includes(' vs ₹'), 'sales are not compared with the week before: ' + kpis[0]);
    assert.ok((await page.locator('.review-year').innerText()).startsWith('The same week a year before'), 'no year-before figures');
    const trying = page.locator('section[aria-labelledby="actions-head"] .memory-item');
    assert.strictEqual(await trying.count(), 1);
    const said = await trying.innerText();
    for (const part of ['E-rickshaw ads around the market', 'Advertising · from ']) assert.ok(said.includes(part), said);
    assert.ok(/Sales rose|Sales fell|No clear change/.test(said), 'the action has no verdict after three weeks: ' + said);
    await page.screenshot({ path: `${OUT}/review.png`, fullPage: true });
    step('last week’s sales, bills, average bill and profit, against the week before and the same week a year before');
    step('what the shop is trying, with what the figures say: ' + said.split('\n')[1]);

    const deciding = page.locator('section[aria-labelledby="tests-head"] .review-test', { hasText: 'Sunflower oil in a new pack' });
    await deciding.waitFor();
    assert.ok((await deciding.innerText()).includes('The rules suggest:'), await deciding.innerText());
    await deciding.getByLabel('What will you do?').selectOption('Reorder');
    await deciding.getByRole('button', { name: 'Save the decision' }).click();
    await page.locator('section[aria-labelledby="tests-head"]').waitFor({ state: 'detached' });
    const actionsFile = JSON.parse(fs.readFileSync(path.join(dataFolder, 'Memory', 'actions.json'), 'utf8'));
    assert.deepStrictEqual([actionsFile.Actions[1].Test.Decision, actionsFile.Actions[1].Test.DecidedOn], ['Reorder', iso(dayOf(0))]);
    await trying.filter({ hasText: 'Sunflower oil in a new pack' }).waitFor();
    step('a new product whose review day came is decided on in the review, and then listed with what the shop is trying');

    const running = page.locator('section[aria-labelledby="out-head"] .review-alert');
    const notSelling = page.locator('section[aria-labelledby="dead-head"] .review-alert');
    const runningCount = await running.count();
    assert.ok(runningCount >= 2, 'the demo shop has fewer than 2 products running out');
    assert.ok(await notSelling.count() >= 1, 'the demo shop has nothing unsold for 8 weeks');
    const first = (await running.nth(0).locator('strong').innerText()).trim();
    const second = (await running.nth(1).locator('strong').innerText()).trim();
    const dead = (await notSelling.nth(0).locator('strong').innerText()).trim();
    assert.ok((await running.nth(0).innerText()).includes('Reorder'), 'a running-out alert does not say to reorder');
    assert.ok((await notSelling.nth(0).innerText()).includes('not sold in 8 weeks'), 'a not-selling alert does not give its figures');
    step(`the rules’ alerts, with their figures: ${runningCount} running out (first ${first}), ${await notSelling.count()} not selling (first ${dead})`);

    await running.nth(0).getByRole('button', { name: 'Do it' }).click();
    await until(() => book().Decisions.length === 1, 'the first decision to be saved');
    await page.locator('section[aria-labelledby="out-head"] .review-alert', { hasText: first }).waitFor({ state: 'detached' });
    const decisions = page.locator('section[aria-labelledby="decisions-head"] .memory-item');
    await decisions.filter({ hasText: first }).filter({ hasText: 'You: did it.' }).waitFor();
    step('“Do it”: the alert leaves the list and the decision is kept');

    const other = page.locator('section[aria-labelledby="out-head"] .review-alert', { hasText: second });
    await other.getByRole('button', { name: 'Something else' }).click();
    // The words are compulsory here, so the field has a star and is announced as required.
    await other.locator('.review-note label').waitFor();
    assert.strictEqual(await other.locator('.review-note label .req').count(), 1, 'what you will do instead is compulsory');
    assert.strictEqual(await other.locator('.review-note input').getAttribute('aria-required'), 'true');
    await other.getByRole('button', { name: 'Save' }).click();
    await page.locator('.alert-danger', { hasText: 'Say what you will do instead.' }).waitFor();
    await other.getByLabel('What will you do instead?').fill('Order 10 from the wholesaler on Friday');
    await other.getByRole('button', { name: 'Save' }).click();
    await until(() => book().Decisions.length === 2, 'the second decision to be saved');
    await decisions.filter({ hasText: second }).filter({ hasText: 'You: something else. Order 10 from the wholesaler on Friday' }).waitFor();

    const deadAlert = page.locator('section[aria-labelledby="dead-head"] .review-alert', { hasText: dead });
    assert.strictEqual(await deadAlert.getByRole('link', { name: 'Make a clearance poster' }).getAttribute('href'), 'posters?kind=clearance');
    await deadAlert.getByRole('button', { name: 'Not now' }).click();
    // For “Not now” the words may be left out, so the field has no star.
    await deadAlert.locator('.review-note label').waitFor();
    assert.strictEqual(await deadAlert.locator('.review-note label .req').count(), 0, 'the reason for not now is optional');
    assert.strictEqual(await deadAlert.locator('.review-note input').getAttribute('aria-required'), null);
    await deadAlert.getByRole('button', { name: 'Save' }).click();
    await until(() => book().Decisions.length === 3, 'the third decision to be saved');
    await decisions.filter({ hasText: dead }).filter({ hasText: 'You: not now.' }).waitFor();
    step('“Something else” needs a few words, “Not now” may go without');

    const saved = book().Decisions;
    assert.deepStrictEqual(saved.map(d => [d.Name, d.Kind, d.Choice]),
      [[first, 'StockOut', 'Accepted'], [second, 'StockOut', 'Changed'], [dead, 'DeadStock', 'Rejected']]);
    assert.deepStrictEqual(saved.map(d => d.ReviewOn), [iso(dayOf(14)), iso(dayOf(14)), iso(dayOf(28))]);
    assert.ok(saved.every(d => d.Figures.length > 0 && d.Recommendation.length > 0 && d.Outcome === null), 'a decision lacks the rule’s figures');
    await page.reload({ waitUntil: 'networkidle' });
    await page.locator('.review-week').waitFor();
    for (const name of [first, second]) {
      assert.strictEqual(await page.locator('section[aria-labelledby="out-head"] .review-alert', { hasText: name }).count(), 0, `${name} is back before its review day`);
    }
    step('decisions.json in the data folder’s Memory folder keeps each with the rule’s figures and its review day (2 weeks, 4 for stock)');

    // Their review day comes: the app judges each from the POS's figures, and the alert may come back.
    // The first is due today; the second was due yesterday, when the app did not see it.
    const due = book();
    due.Decisions[0].ReviewOn = iso(dayOf(0));
    due.Decisions[1].ReviewOn = iso(dayOf(-1));
    fs.writeFileSync(decisionsFile, JSON.stringify(due, null, 2));
    await page.reload({ waitUntil: 'networkidle' });
    await decisions.filter({ hasText: first }).locator('.trend-up', { hasText: 'In stock on the review day' }).waitFor();
    await decisions.filter({ hasText: second }).getByText(/^Checked late, on .* so it is not counted\.$/).waitFor();
    assert.ok((await decisions.filter({ hasText: dead }).innerText()).includes('Checked on'), 'the stock decision was judged early');
    assert.strictEqual((await page.locator('.review-tally').innerText()).trim(),
      'Checked so far: when you followed the rule, 1 of 1 went well. Going well means still in stock on its review day, or stock that sold again by then; a product running out that was checked late is not counted.');
    const judged = book().Decisions;
    assert.deepStrictEqual(judged.map(d => d.WentWell), [true, null, null]);
    assert.deepStrictEqual(judged.slice(0, 2).map(d => d.OutcomeOn), [iso(dayOf(0)), iso(dayOf(0))]);
    await page.locator('section[aria-labelledby="out-head"] .review-alert', { hasText: first }).waitFor();
    await page.screenshot({ path: `${OUT}/review-judged.png`, fullPage: true });
    step('each decision is judged from the POS on its review day and kept (one checked late is not counted); the tally compares following the rules with not');

    await page.getByRole('button', { name: 'Mark the week as reviewed' }).click();
    await page.locator('.page-head .pill.good', { hasText: 'Reviewed' }).waitFor();
    const monday = dayOf(-(((new Date().getDay() + 6) % 7) + 7));
    assert.deepStrictEqual(book().Reviewed.map(r => r.Monday), [iso(monday)]);
    await page.goto(BASE + '/', { waitUntil: 'networkidle' });
    await page.locator('.suggestions-card .suggestion').first().waitFor();
    assert.strictEqual(await page.locator('.suggestion', { hasText: 'Your Monday review is ready' }).count(), 0, 'the reminder stays after the review');
    step('the week is marked as reviewed, and Today stops reminding');

    await noSidewaysScroll(page, BASE + '/review');
    step('phone width: no sideways scrolling');

    assert.deepStrictEqual(errors, [], 'console or page errors: ' + errors.join('\n'));
    console.log('No console or page errors.');
  } finally {
    await browser.close();
    stopApp(app);
  }
})().catch(error => {
  console.error(error);
  process.exit(1);
});
