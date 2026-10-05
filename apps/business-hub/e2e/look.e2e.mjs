// The owner changes the look on their own PC: colours, logo, support details, and (with a "full" licence) the program's name, but only as far as the
// licence allows. A licence with a fixed look keeps its look.
import assert from 'node:assert';
import zlib from 'node:zlib';
import { mkdirSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { build, startHub, launch, newPage, setUp, signIn, shots, go } from './lib.mjs';

build();
const browser = await launch();
const problems = [];
const shot = shots('look');
const step = (s) => console.log('✓ ' + s);

/** A small solid-colour PNG picture, written by hand (a real file, with the real first bytes). */
function png(width, height, [r, g, b]) {
  const crc = (buf) => { const c = Buffer.alloc(4); c.writeUInt32BE(zlib.crc32(buf) >>> 0); return c; };
  const chunk = (type, data) => { const len = Buffer.alloc(4); len.writeUInt32BE(data.length); const t = Buffer.concat([Buffer.from(type), data]); return Buffer.concat([len, t, crc(t)]); };
  const header = Buffer.alloc(13); header.writeUInt32BE(width, 0); header.writeUInt32BE(height, 4); header[8] = 8; header[9] = 2;
  const row = Buffer.concat([Buffer.from([0]), Buffer.concat(Array.from({ length: width }, () => Buffer.from([r, g, b])))]);
  const raw = Buffer.concat(Array.from({ length: height }, () => row));
  return Buffer.concat([Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]), chunk('IHDR', header), chunk('IDAT', zlib.deflateSync(raw)), chunk('IEND', Buffer.alloc(0))]);
}
const work = join(tmpdir(), 'hub-look-' + process.pid);
mkdirSync(work, { recursive: true });
writeFileSync(join(work, 'logo.png'), png(64, 32, [170, 34, 51]));
writeFileSync(join(work, 'notes.txt'), 'this is not a picture');
writeFileSync(join(work, 'fake.png'), 'this is not a picture either');
writeFileSync(join(work, 'big.png'), Buffer.concat([png(8, 8, [1, 2, 3]), Buffer.alloc(150_000)]));

const accent = (page) => page.evaluate(() => getComputedStyle(document.documentElement).getPropertyValue('--accent').trim());
let hub;
const run = async (args, body) => {
  hub = await startHub(args);
  try {
    const page = await newPage(browser, problems);
    await setUp(page, hub, { name: 'Corner Mart', industry: 'retail', demo: false });
    await signIn(page, hub);
    await body(page);
    await page.context().close();
    assert.deepStrictEqual(problems, [], 'the browser saw problems');
  } finally { await hub.stop(); }
};
const openLook = async (page) => {
  await go(page, 'Settings');
  await page.getByRole('tab', { name: 'Look' }).click();
  await page.locator('main h2', { hasText: /^Look$/ }).waitFor();
};

try {
  // ---- a licence with a fixed look ------------------------------------------------------------------------------------------------
  await run(['--E2E:White=none', '--E2E:Brand=Luzon Fresh'], async (page) => {
    await openLook(page);
    assert.match(await page.locator('main').innerText(), /fixed look: Luzon Fresh/);
    assert.strictEqual(await page.locator('#save-look').count(), 0, 'nothing to save with a fixed look');
    assert.match(await page.locator('.side .brand-name').innerText(), /Luzon Fresh/);
    assert.strictEqual(await accent(page), '#0f6cbd');
    await shot(page, '1-fixed');
    step('a licence with a fixed look says so, offers nothing to change, and keeps the licence\'s name and colour');
  });

  // ---- theme: colours, logo, help; not the name -----------------------------------------------------------------------------------
  await run(['--E2E:White=theme', '--E2E:Brand=Luzon Fresh'], async (page) => {
    await openLook(page);
    assert.strictEqual(await page.locator('#b-name').count(), 0, 'a theme licence cannot rename the program');
    assert.strictEqual(await page.locator('#b-by').count(), 0);

    // a look file from the Brand Studio: loaded into the form, not saved until the owner presses Save
    const logoUri = 'data:image/png;base64,' + png(64, 32, [34, 102, 170]).toString('base64');
    writeFileSync(join(work, 'hub-look.json'), JSON.stringify({ name: 'From The File', primaryColor: '#226699', accentColor: '#cc6600', logo: logoUri, supportEmail: 'file@shop.example', poweredBy: false }));
    writeFileSync(join(work, 'empty.json'), '{"surprise": 1}');
    writeFileSync(join(work, 'junk.json'), 'not json at all');
    for (const bad of ['empty.json', 'junk.json']) {
      await page.locator('#b-file').setInputFiles(join(work, bad));
      await page.locator('.notice.error', { hasText: /There is no look in that file/ }).waitFor();
    }
    await page.locator('#b-file').setInputFiles(join(work, 'hub-look.json'));
    await page.locator('.notice', { hasText: /Loaded\. Look it over/ }).waitFor();
    assert.strictEqual(await page.locator('#b-main').inputValue(), '#226699');
    assert.strictEqual(await page.locator('#b-second').inputValue(), '#cc6600');
    assert.strictEqual(await page.locator('#b-mail').inputValue(), 'file@shop.example');
    await page.locator('main .brand-logo').waitFor();
    assert.strictEqual(await accent(page), '#0f6cbd', 'nothing changes until Save');
    step('a look file from the Brand Studio fills the form (and a file with no look in it is refused); nothing changes until Save');

    await page.locator('#b-main').fill('red');
    await page.locator('#save-look').click();
    await page.locator('.notice.error', { hasText: /must look like #0f6cbd/ }).waitFor();
    await page.locator('#b-main').fill('#ffff00');
    await page.locator('#save-look').click();
    await page.locator('.notice.error', { hasText: /too light to read/ }).waitFor();
    step('a word that is not a colour, and a colour too light to read, are refused in plain words');

    const before = await page.locator('main .brand-logo').getAttribute('src');
    for (const bad of ['notes.txt', 'fake.png', 'big.png']) {
      await page.locator('#b-logo').setInputFiles(join(work, bad));
      await page.locator('.notice.error').waitFor();
      assert.strictEqual(await page.locator('main .brand-logo').getAttribute('src'), before, 'a refused picture never replaces the logo: ' + bad);
    }
    step('a text file, a fake picture and a picture that is too big are refused as a logo');

    await page.locator('#b-main').fill('#aa2233');
    await page.locator('#b-second').fill('#336699');
    await page.locator('#b-logo').setInputFiles(join(work, 'logo.png'));
    await page.locator('main .brand-logo').waitFor();
    await page.locator('#b-mail').fill('help@corner.example');
    await page.locator('#save-look').click();
    await page.waitForURL(/tab=look&saved=1/);
    await page.locator('.notice', { hasText: /Saved/ }).waitFor();
    assert.strictEqual(await accent(page), '#aa2233');
    assert.strictEqual(await page.locator('main .btn.primary').first().evaluate((b) => getComputedStyle(b).backgroundColor), 'rgb(170, 34, 51)', 'the button itself is the chosen colour, not only a variable');
    await page.locator('.side .brand-logo').waitFor();
    assert.ok(await page.locator('.side .brand-logo').evaluate((img) => img.naturalWidth === 64), 'the picture shows');
    assert.match(await page.locator('.side .brand-name').innerText(), /Luzon Fresh/);
    assert.match(await page.locator('.side .brand-by').innerText(), /by NextGenOS/);
    await shot(page, '2-theme-saved');
    step('a theme licence: the owner\'s colour and logo show on every screen; the licence\'s name and "by NextGenOS" stay');

    // the sign-in page wears it too
    await page.getByRole('button', { name: 'Sign out' }).click();
    await page.waitForURL('**/login');
    await page.locator('.public-brand').waitFor();
    assert.strictEqual(await accent(page), '#aa2233');
    await page.locator('.brand-logo').waitFor();
    await shot(page, '3-login');
    await signIn(page, hub);
    step('the sign-in page shows the owner\'s look too');

    await openLook(page);
    assert.strictEqual(await page.locator('#b-main').inputValue(), '#aa2233', 'what was saved is shown again');
    await page.locator('#reset-look').click();
    await page.waitForURL(/tab=look&saved=1/);
    assert.strictEqual(await accent(page), '#0f6cbd');
    assert.strictEqual(await page.locator('.side .brand-logo').count(), 0);
    await openLook(page);
    assert.strictEqual(await page.locator('#b-main').inputValue(), '');
    step('going back to the standard look gives the licence\'s colour back and removes the logo');
  });

  // ---- full: the name too ------------------------------------------------------------------------------------------------------------
  await run(['--E2E:White=full', '--E2E:Brand=Luzon Fresh'], async (page) => {
    await openLook(page);
    await page.locator('#b-name').fill('Mine Mart POS');
    await page.locator('#b-by').uncheck();
    await page.locator('#save-look').click();
    await page.waitForURL(/tab=look&saved=1/);
    assert.match(await page.locator('.side .brand-name').innerText(), /Mine Mart POS/);
    assert.strictEqual(await page.locator('.side .brand-by').count(), 0, 'no "by NextGenOS" when the owner turned it off');
    step('a full licence: the owner renames the program and takes off "by NextGenOS"');
  });

  // ---- no brand at all, theme: the standard NextGenOS look takes the owner's colour -----------------------------------------------
  await run(['--E2E:White=theme'], async (page) => {
    assert.match(await page.locator('.side .brand-name').innerText(), /Smart Retail POS/);
    await openLook(page);
    await page.locator('#b-main').fill('#0a7d4b');
    await page.locator('#save-look').click();
    await page.waitForURL(/tab=look&saved=1/);
    assert.strictEqual(await accent(page), '#0a7d4b');
    step('with no licence brand, a theme licence still lets the owner choose the colour');
  });
  console.log('\nThe look can be changed exactly as far as the licence allows.');
} catch (e) {
  console.error(e);
  if (hub) console.error(hub.log().slice(-2000));
  process.exitCode = 1;
} finally {
  await browser.close();
}
