// End-to-end check, in Chromium, that the poster and product photo screens follow the customer's AI profile (profile/ai.json) and nothing is fixed to
// one market (CLAUDE.md, section 8). The same demo shop is started three ways and the screens are compared:
//   1. with NO profile: no festival suggestions, no second-language line, "Model 1/2/3" for the photos with a person (on the screens and in the
//      name a photo downloads under), and nothing about a country or a language in what the AI is asked;
//      The "for example" words in the Creatives, Past chats and Memory boxes follow the profile in the same way (a festival, a language, or neutral);
//   2. with a Filipino profile (second language Filipino, tag fil, festivals Christmas and Sinulog): the form says "Filipino line", suggests those
//      festivals, the photos are named as the profile names them, and the AI is asked for a Filipino line;
//   3. with the legacy India profile (Hindi, Diwali ...) the other tests use: the same screens now say Hindi and suggest Diwali.
// With stand-in-codex.js in place of the real Codex CLI (it answers a second language only when the task asks for one). It starts the app itself, then stops it:
//   npm install && npm run test:profiles        (needs the .NET 10 SDK; screenshots go to ./screenshots)
const { chromium } = require('playwright');
const { spawn } = require('child_process');
const assert = require('assert');
const fs = require('fs');
const os = require('os');
const path = require('path');
const { png } = require('./png');
const { writeShopProfile, filipinoShop, indiaShop } = require('./shop-profile');

const BASE = 'http://127.0.0.1:5080';
const OUT = process.argv[2] || 'screenshots';
fs.mkdirSync(OUT, { recursive: true });
const step = (s) => console.log('✓ ' + s);

const work = fs.mkdtempSync(path.join(os.tmpdir(), 'srpos-profiles-'));
const standIn = path.join(__dirname, 'stand-in-codex.js');

// The demo's ball pens (product 24) already have two photos, as if made on the Product photos page: the white one and the first with a person.
const penFile = 'european-model-20260920-100200.png';
function seedPen(dataFolder) {
  const folder = path.join(dataFolder, 'Product photos', '24 Ball Pen, pack of 5');
  fs.mkdirSync(folder, { recursive: true });
  const white = 'white-20260920-100100.png';
  fs.writeFileSync(path.join(folder, 'raw-20260920-100000.png'), png(60, 60, () => [120, 120, 120]));
  fs.writeFileSync(path.join(folder, white), png(240, 240, () => [255, 255, 255]));
  fs.writeFileSync(path.join(folder, penFile), png(240, 240, () => [200, 160, 120]));
  fs.writeFileSync(path.join(folder, 'product.json'), JSON.stringify({
    ProductId: 24, Code: '1024', Name: 'Ball Pen, pack of 5', Category: 'Stationery',
    Sets: [{
      Id: '20260920-100000', Started: '2026-09-20T10:00:00', RawFiles: ['raw-20260920-100000.png'],
      Images: [
        { Kind: 'WhiteBackground', File: white, Made: '2026-09-20T10:01:00', Provider: 'Codex CLI (OpenAI)' },
        { Kind: 'EuropeanModel', File: penFile, Made: '2026-09-20T10:02:00', Provider: 'Codex CLI (OpenAI)' },
      ],
      Pending: [],
    }],
  }, null, 2));
}

// One shop on this PC: its own settings, data folder and "codex" launcher (as the side panel would set them up), and the folder its profile is read from.
// "profile" is what to write (null: the shop has no profile at all: the folder it is read from is empty, and so is the one above it).
function makeShop(name, profile) {
  const folder = path.join(work, name);
  const profileFolder = path.join(folder, 'shop');
  fs.mkdirSync(profileFolder, { recursive: true });
  const codex = path.join(folder, process.platform === 'win32' ? 'codex.cmd' : 'codex');
  fs.writeFileSync(codex, process.platform === 'win32'
    ? `@"${process.execPath}" "${standIn}" %*\r\n`
    : `#!/bin/sh\nexec "${process.execPath}" "${standIn}" "$@"\n`, { mode: 0o755 });
  const settingsFile = path.join(folder, 'settings.json');
  fs.writeFileSync(settingsFile, JSON.stringify({ PreferredProvider: 'codex-cli', Codex: { ExecutablePath: codex, TimeoutSeconds: 120 } }, null, 2));
  fs.writeFileSync(path.join(folder, 'storage.json'), JSON.stringify({ DataFolder: path.join(folder, 'data') }));
  seedPen(path.join(folder, 'data'));
  const prompts = path.join(folder, 'poster-prompts.jsonl');
  const env = profile ? writeShopProfile(profileFolder, profile) : { Ai__ProfileFolder: profileFolder };
  return { name, folder, prompts, env: { Ai__SettingsFile: settingsFile, ...env, STAND_IN_CODEX_DELAY_MS: '200', STAND_IN_CODEX_POSTER_PROMPTS: prompts } };
}

async function answers() {
  try { await fetch(BASE + '/'); return true; } catch { return false; }
}

async function startApp(shop) {
  const log = path.join(shop.folder, 'app.log');
  const out = fs.openSync(log, 'w');
  const app = spawn('dotnet', ['run', '--project', path.join(__dirname, '../../src/SmartRetail.Pos.Web'), '--no-launch-profile'], {
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', ...shop.env },
    stdio: ['ignore', out, out],
    detached: process.platform !== 'win32',
  });
  let exited = null;
  app.on('exit', code => { exited = code; });
  let last = 'no answer';
  for (let i = 0; i < 240; i++) {
    try {
      const r = await fetch(BASE + '/');
      if (r.ok) return app;
      last = `${r.status} ${(await r.text()).replace(/\s+/g, ' ').slice(0, 200)}`;
    } catch { /* not up yet */ }
    if (exited !== null) break;
    await new Promise(r => setTimeout(r, 1000));
  }
  await stopApp(app);
  const tail = fs.readFileSync(log, 'utf8').split('\n').slice(-15).join('\n');
  throw new Error(`The app did not start on ${BASE} (last answer: ${last}; the program ${exited === null ? 'was still running' : 'stopped with ' + exited}).\n${tail}`);
}

async function stopApp(app) {
  try { process.platform === 'win32' ? spawn('taskkill', ['/pid', String(app.pid), '/t', '/f']) : process.kill(-app.pid); } catch { /* gone */ }
  for (let i = 0; i < 40 && (await answers()); i++) await new Promise(r => setTimeout(r, 250));
}

// What the screens show for the shop that is running: the festival form, a clearance poster, the photo pages. Gives what it saw.
async function look(browser, shop) {
  const errors = [];
  const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
  page.on('pageerror', e => errors.push(e.message));
  page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
  const seen = {};
  try {
    // The festival form: what it suggests and what it says when nothing is suggested.
    await page.goto(BASE + '/posters?kind=festival-offer');
    const festival = page.locator('#festival');
    await festival.waitFor();
    seen.festivals = await page.locator('#festivals option').evaluateAll(list => list.map(o => o.getAttribute('value')));
    seen.festivalHint = await festival.getAttribute('placeholder');
    await page.screenshot({ path: path.join(OUT, `profiles-${shop.name}-festival.png`) });

    // A clearance poster for two products: the words it has.
    await page.goto(BASE + '/posters?kind=clearance');
    await page.locator('.seg-item.on', { hasText: 'Clearance' }).waitFor();
    await page.getByText('3 products fit this poster right now.').waitFor();
    await page.getByRole('radio', { name: '2', exact: true }).click();
    await page.getByRole('button', { name: 'Make the poster' }).click();
    await page.waitForURL(/\/posters\/\d{8}-\d{6}-clearance$/);
    const sheet = page.locator('.print-me .sheet');
    await sheet.waitFor();
    await sheet.locator('.sheet-headline', { hasText: 'STOCK CLEARANCE' }).waitFor();
    seen.localLabel = await page.locator('label[for=local-line]').count() ? (await page.locator('label[for=local-line]').innerText()).trim() : null;
    seen.localField = await page.locator('#local-line').count() ? { value: await page.locator('#local-line').inputValue(), lang: await page.locator('#local-line').getAttribute('lang') } : null;
    seen.sheetLocal = await sheet.locator('.sheet-local').count() ? (await sheet.locator('.sheet-local').innerText()).trim() : null;
    await page.screenshot({ path: path.join(OUT, `profiles-${shop.name}-poster.png`) });
    seen.prompts = fs.existsSync(shop.prompts) ? fs.readFileSync(shop.prompts, 'utf8').split('\n').filter(Boolean).map(l => JSON.parse(l)) : [];

    // The photo pages: who the three photos with a person show.
    await page.goto(BASE + '/photos');
    await page.locator('table.data-table tbody tr').first().waitFor();
    seen.photosIntro = (await page.locator('.page-head .sub').innerText()).replace(/\s+/g, ' ');
    await page.goto(BASE + '/photos/6');
    await page.locator('ol.kind-list').waitFor();
    seen.photoTitles = await page.locator('ol.kind-list li').allInnerTexts();
    await page.screenshot({ path: path.join(OUT, `profiles-${shop.name}-photos.png`) });
    // A product that has photos: the slot of the first photo with a person, and the name the photo downloads under.
    await page.goto(BASE + '/photos/24');
    const slot = page.locator('.slot[data-kind=european-model]');
    await slot.locator('img').waitFor();
    seen.slotTitle = (await slot.locator('strong').innerText()).replace(/\s+/g, ' ').trim();
    const download = await page.request.get(`${BASE}/product-photos/24/${penFile}?download=true`);
    assert.strictEqual(download.status(), 200);
    seen.downloadName = decodeURIComponent(download.headers()['content-disposition'] || '');

    // The "for example" words in the boxes: a creative's headline and background, the search of past chats, what the memory might hold.
    await page.goto(BASE + '/creatives', { waitUntil: 'networkidle' });
    await page.fill('.creative-new .scan-input', 'sunflower');
    await page.locator('.creative-new .found-list li', { hasText: 'Sunflower Oil 1 L' }).getByRole('button', { name: 'Add' }).click();
    await page.locator('.picked-products li', { hasText: 'Sunflower Oil 1 L' }).waitFor();
    await page.getByRole('button', { name: 'Start the creative' }).click();
    await page.waitForURL(/\/creatives\/\d{8}-\d{6}$/);
    await page.locator('#headline').waitFor();
    seen.creativeHeadline = await page.locator('#headline').getAttribute('placeholder');
    seen.creativeSubtitle = await page.locator('#subtitle').getAttribute('placeholder');
    seen.creativeBackground = await page.locator('#background').getAttribute('placeholder');
    await page.goto(BASE + '/ask/past', { waitUntil: 'networkidle' });
    seen.pastSearch = await page.getByLabel('Search past chats').getAttribute('placeholder');
    await page.goto(BASE + '/memory', { waitUntil: 'networkidle' });
    seen.memoryShop = await page.getByLabel('Add to About the shop').getAttribute('placeholder');
    seen.memoryYou = await page.getByLabel('Add to About you').getAttribute('placeholder');
  } finally {
    await page.close();
  }
  assert.deepStrictEqual(errors, [], `no errors in the browser (${shop.name})`);
  return seen;
}

(async () => {
  const shops = {
    none: makeShop('no-profile', null),
    filipino: makeShop('filipino', filipinoShop),
    india: makeShop('india', indiaShop),
  };
  const browser = await chromium.launch();
  const saw = {};
  try {
    for (const shop of Object.values(shops)) {
      const app = await startApp(shop);
      try { saw[shop.name] = await look(browser, shop); } finally { await stopApp(app); }
    }

    // 1. No profile: nothing about a market on the poster and photo screens, and nothing about one in what the AI is asked.
    const none = saw['no-profile'];
    assert.deepStrictEqual(none.festivals, [], 'no festival is suggested: ' + JSON.stringify(none.festivals));
    assert.strictEqual(none.festivalHint, 'The holiday or season');
    assert.strictEqual(none.localLabel, null, 'no second-language line to fill in');
    assert.strictEqual(none.localField, null);
    assert.strictEqual(none.sheetLocal, null, 'no second-language line on the poster');
    assert.deepStrictEqual(none.photoTitles, ['White background', 'In use', 'Model 1', 'Model 2', 'Model 3']);
    assert.ok(none.photosIntro.includes('(model 1, model 2, model 3)'), none.photosIntro);
    assert.strictEqual(none.prompts.length, 1, 'the AI was asked once for the poster');
    assert.ok(!/India|Hindi|Diwali|Navratri|Filipino|Philippines|local_line|second language|\bin its own script\b/i.test(none.prompts[0]), 'the AI was told of a market: ' + none.prompts[0]);
    assert.ok(!/(European|Indian|East Asian) model/.test(none.photoTitles.join(' ')));
    assert.deepStrictEqual([none.creativeHeadline, none.creativeSubtitle, none.creativeBackground], ['e.g. Seasonal sale', 'e.g. Fresh stock just in', 'e.g. a warm evening glow']);
    assert.deepStrictEqual([none.pastSearch, none.memoryShop, none.memoryYou],
      ['Search past chats, e.g. best sellers', 'e.g. Sales are higher in the last week of the month', 'e.g. Answer short, with the main figures first']);
    assert.ok(!/diwali|diya|hindi|hinglish|rupee|india|festival/i.test(JSON.stringify([none.creativeHeadline, none.creativeSubtitle, none.creativeBackground, none.pastSearch, none.memoryShop, none.memoryYou])), 'a sample names a market');
    assert.strictEqual(none.slotTitle, '3 · Model 1');
    assert.ok(none.downloadName.includes('Ball Pen, pack of 5 - 3 Model 1.png'), none.downloadName);
    step('With no profile: no festival suggestions, no second-language line, "Model 1/2/3", and the AI is told nothing about a country or language');

    // 2. A Filipino profile: its words everywhere.
    const fil = saw.filipino;
    assert.deepStrictEqual(fil.festivals, ['Christmas', 'Sinulog']);
    assert.strictEqual(fil.festivalHint, 'For example Christmas');
    assert.strictEqual(fil.localLabel, 'Filipino line');
    assert.deepStrictEqual(fil.localField, { value: 'Malaking tipid, bilisan na', lang: 'fil' });
    assert.strictEqual(fil.sheetLocal, 'Malaking tipid, bilisan na');
    assert.deepStrictEqual(fil.photoTitles, ['White background', 'In use', 'Filipino model', 'Cebuano model', 'Chinese-Filipino model']);
    assert.ok(fil.photosIntro.includes('(filipino model, cebuano model, chinese-filipino model)'), fil.photosIntro);
    assert.deepStrictEqual([fil.creativeHeadline, fil.creativeSubtitle, fil.creativeBackground], ['e.g. Christmas offer', 'e.g. Fresh stock for Christmas', 'e.g. a warm evening glow with Christmas decorations']);
    assert.deepStrictEqual([fil.pastSearch, fil.memoryShop, fil.memoryYou],
      ['Search past chats, e.g. sugar Christmas', 'e.g. Sales are higher in Christmas week', 'e.g. Answer in Filipino, short, with the main figures first']);
    assert.strictEqual(fil.slotTitle, '3 · Filipino model');
    assert.ok(fil.downloadName.includes('Ball Pen, pack of 5 - 3 Filipino model.png'), fil.downloadName);
    assert.strictEqual(fil.prompts.length, 1);
    assert.ok(/one line in Filipino/.test(fil.prompts[0]) && /the Philippines/.test(fil.prompts[0]) && /local_line/.test(fil.prompts[0]), 'the AI was not asked for a Filipino line: ' + fil.prompts[0]);
    assert.ok(!/India|Hindi|Diwali|Navratri/i.test(fil.prompts[0]), 'the AI was told of another market: ' + fil.prompts[0]);
    step('With a Filipino profile: "Filipino line", Christmas and Sinulog suggested, the photos named as the profile says, and the AI asked for a Filipino line');

    // 3. The India profile of the other tests: the same screens, other words. Changing the profile changes the result.
    const india = saw.india;
    assert.ok(india.festivals.includes('Diwali') && !india.festivals.includes('Sinulog'));
    assert.strictEqual(india.festivalHint, 'For example Diwali');
    assert.strictEqual(india.localLabel, 'Hindi line');
    assert.strictEqual(india.localField.lang, 'hi');
    assert.strictEqual(india.sheetLocal, 'भारी छूट, जल्दी करें');
    assert.deepStrictEqual(india.photoTitles, ['White background', 'In use', 'European model', 'Indian model', 'East Asian model']);
    assert.deepStrictEqual([india.creativeHeadline, india.pastSearch, india.memoryShop, india.memoryYou],
      ['e.g. Diwali offer', 'Search past chats, e.g. sugar Diwali', 'e.g. Sales are higher in Diwali week', 'e.g. Answer in Hindi, short, with the main figures first']);
    assert.strictEqual(india.slotTitle, '3 · European model');
    assert.ok(india.downloadName.includes('Ball Pen, pack of 5 - 3 European model.png'), india.downloadName);
    assert.ok(/one line in Hindi/.test(india.prompts[0]) && !/Filipino|Philippines/.test(india.prompts[0]));
    step('With the India profile the same screens say Hindi and suggest Diwali: the profile, not the program, decides');

    console.log('\nAll profile checks passed. Screenshots in ' + OUT);
  } finally {
    await browser.close();
    fs.rmSync(work, { recursive: true, force: true });
  }
})().catch(e => { console.error(e); process.exit(1); });
