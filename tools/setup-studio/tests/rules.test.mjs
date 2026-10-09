import { test } from 'node:test';
import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';
import { resolve, dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';
import { parseSetup, parseTheme, parseBrand, resolveTheme, scale, usableColour, logoProblem, THEME_DEFAULTS, LOOKS } from '../lib/rules.mjs';
import { previewInput, previewHtml, previewTheme, previewLook } from '../lib/preview.mjs';
import { repoRoot } from '../lib/packs.mjs';
import { build as buildVectors } from '../scripts/make-setup-vectors.mjs';
import { propose, themeFor, deviceTokens, layoutTokens, LOOK_TOKENS, STYLES } from '../lib/template.mjs';
import { checkIntake, OPTIONS, blankIntake, slugFor } from '../lib/intake.mjs';
import { countries, industries } from '../lib/packs.mjs';
import { diffProposals } from '../lib/diff.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const root = resolve(here, '..', '..', '..');
const read = (...p) => JSON.parse(readFileSync(resolve(root, ...p), 'utf8'));

test('the setup vectors on disk are exactly what these rules produce (the Hub reads the same file)', () => {
  const onDisk = read('apps', 'business-hub', 'tests', 'vectors', 'setup-profile.json');
  assert.deepEqual(onDisk, JSON.parse(JSON.stringify(buildVectors())), 'run: node tools/setup-studio/scripts/make-setup-vectors.mjs');
  assert.ok(onDisk.cases.length >= 25);
});

test('the shared theme vectors (licensing/testvectors/theme-policy.json) come out the same here as in the Hub', () => {
  const vectors = read('licensing', 'testvectors', 'theme-policy.json');
  let checked = 0;
  for (const c of vectors.cases) {
    const levels = c.levels ?? [c.level];
    const profiles = c.profiles ?? [c.profile];
    const locals = c.locals ?? [c.local];
    for (const level of levels) for (const profile of profiles) for (const local of locals) {
      const got = resolveTheme(level, profile, local);
      for (const [token, want] of Object.entries(c.expect)) {
        if (token === 'fontScale') assert.ok(Math.abs(got[token] - want) < 1e-9, `${c.name}: ${token} ${got[token]} != ${want}`);
        else assert.equal(got[token], want, `${c.name}: ${token}`);
      }
      checked += 1;
    }
  }
  assert.ok(checked >= 20, `${checked} cases`);
  assert.deepEqual(resolveTheme('theme', null, null), THEME_DEFAULTS);
});

test('font sizes round to the nearest 0.05 and stay in range', () => {
  assert.equal(scale(1.12), 1.1);
  assert.equal(scale(1.075), 1.1);
  assert.equal(scale(0.85), 0.85);
  assert.equal(scale(1.35), 1.35);
  for (const bad of [0.84, 1.36, NaN, Infinity, '1.2', null, true, undefined]) assert.equal(scale(bad), null);
});

test('a look file keeps what is valid and names the rest in words', () => {
  const r = parseTheme({ shape: 'pill', nav: 'up', fontScale: 3, banana: 1, density: 'touch' });
  assert.deepEqual(r.value, { shape: 'pill', density: 'touch' });
  assert.equal(r.problems.length, 3);
  assert.match(r.problems.join(' '), /"nav" must be one of: left, top, bottom/);
  assert.deepEqual(parseTheme('{ nope').value, {});
  assert.deepEqual(parseTheme([1]).problems, ['The look file is not a look.']);
});

test('a brand file: colours must carry white words, the logo must be a real small picture, text is cleaned', () => {
  const PNG = 'data:image/png;base64,' + Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==', 'base64').toString('base64');
  const ok = parseBrand({ name: ' Luzon \u0007Fresh ', primaryColor: '#0A7D4B', accentColor: '#0f6cbd', logo: PNG, supportEmail: 'a@b.co', poweredBy: false });
  assert.deepEqual(ok.problems, []);
  assert.equal(ok.value.name, 'Luzon Fresh');
  assert.equal(ok.value.primaryColor, '#0a7d4b');
  const bad = parseBrand({ primaryColor: '#ffff00', accentColor: 'red', logo: 'https://evil.example/x.png', name: 'x'.repeat(61), color: 1 });
  assert.equal(Object.keys(bad.value).length, 0);
  assert.equal(bad.problems.length, 5);
  assert.equal(usableColour('#ffffff'), null);
  assert.equal(usableColour('#0F6CBD'), '#0f6cbd');
  assert.ok(logoProblem('data:image/png;base64,' + Buffer.from('not a png at all, no').toString('base64')));
  assert.ok(logoProblem('data:image/svg+xml;base64,PHN2Zz48L3N2Zz4='));
  assert.equal(logoProblem(PNG), null);
});

test('every kind of business in every country gets a proposal the Hub reads without a single problem', () => {
  let n = 0;
  for (const industry of industries()) {
    for (const country of countries()) {
      const r = propose({ business: { name: `Test ${industry.id}`, country: country.code, region: country.regions[0]?.code ?? '', industry: industry.id }, look: { primaryColor: '#0f6cbd' } });
      assert.equal(r.ok, true, `${industry.id}/${country.code}: ${JSON.stringify(r.errors)}`);
      assert.deepEqual(r.proposal.problems, [], `${industry.id}/${country.code}`);
      assert.equal(r.proposal.setup.business.country, country.code);
      n += 1;
    }
  }
  assert.ok(n >= 7 * 30, `${n} combinations`);
});

test('a proposal depends only on the details: the same details give the same files', () => {
  const details = { business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail' }, device: { kind: 'tablet', screen: 'small' }, look: { style: 'classic', primaryColor: '#7a1f2b' } };
  assert.deepEqual(propose(details).proposal, propose(JSON.parse(JSON.stringify(details))).proposal);
});

test('machines become layouts: touch and kiosk get big buttons, a small laptop gets a tight one, a normal laptop gets nothing special', () => {
  // "by machine" is the older way: the machine decides the button size and the menu place
  assert.deepEqual(themeFor(checkIntake({ business: { name: 'A' }, look: { layout: 'standard' }, device: { kind: 'laptop', screen: 'standard' } }).value), { look: 'standard' });
  const small = themeFor(checkIntake({ business: { name: 'A' }, look: { layout: 'standard' }, device: { kind: 'laptop', screen: 'small' } }).value);
  assert.deepEqual(small, { look: 'standard', density: 'compact', navLabels: 'icons' });
  const kiosk = deviceTokens({ kind: 'kiosk', screen: 'standard' });
  assert.equal(kiosk.density, 'touch'); assert.equal(kiosk.nav, 'bottom'); assert.equal(kiosk.fontScale, 1.2);
  const till = deviceTokens({ kind: 'touch-pos', screen: 'standard' });
  assert.equal(till.nav, 'left'); assert.equal(till.cart, 'right');
  assert.equal(deviceTokens({ kind: 'touch-pos', screen: 'small' }).cart, 'bottom');
  for (const k of OPTIONS.deviceKinds) for (const s of OPTIONS.screens) { const t = deviceTokens({ kind: k.id, screen: s.id }); assert.deepEqual(parseTheme(t).problems, [], `${k.id}/${s.id}`); }
  for (const style of OPTIONS.styles) assert.deepEqual(parseTheme(STYLES[style.id]).problems, [], style.id);
});

test('what the screens will show depends on the licence level, and the explanation says so in words', () => {
  const r = propose({ business: { name: 'A', country: 'IN', region: '27' }, look: { style: 'friendly' }, licence: { whiteLabel: 'none' } });
  assert.match(r.proposal.explain.find((e) => e.part === 'licence').text, /fixed look/);
  assert.match(propose({ business: { name: 'A', country: 'IN', region: '27' }, licence: { whiteLabel: 'full' } }).proposal.explain.find((e) => e.part === 'licence').text, /rename the program/);
});

test('the details are checked field by field in plain words, and what is wrong is never written into a file', () => {
  const c = checkIntake({ business: { name: '<b>x</b>', country: 'ZZ', industry: 'spaceship', contact: { email: 'nope', phone: 'call me' } }, look: { primaryColor: 'yellow' }, ecosystem: { website: { wanted: true, domain: 'https://x.com/' }, android: { wanted: true, appId: 'App' } } });
  const fields = c.errors.map((e) => e.field);
  for (const f of ['business.name', 'business.country', 'business.industry', 'business.contact.email', 'business.contact.phone', 'look.primaryColor', 'ecosystem.website.domain', 'ecosystem.android.appId']) assert.ok(fields.includes(f), f);
  assert.equal(c.complete, false);
  assert.equal(propose({ business: { name: '<b>x</b>' } }).ok, false);
  const clean = checkIntake({ business: { name: 'Fine', country: 'IN', region: '27' }, notes: 'x'.repeat(9000), money: { paymentMethods: ['Cash', 'cash', 'GCash'] } });
  assert.equal(clean.value.notes.length, 4000);
  assert.deepEqual(clean.value.money.paymentMethods, ['cash', 'gcash']);
  assert.equal(blankIntake().schema, 1);
});

test('a country with a list of regions must have one chosen, and a country with one region is filled in', () => {
  const india = checkIntake({ business: { name: 'A', country: 'IN' } });
  assert.ok(india.warnings.some((w) => w.field === 'business.region'), 'the owner will choose it while setting up');
  assert.equal(checkIntake({ business: { name: 'A', country: 'IN', region: '99' } }).errors.some((e) => e.field === 'business.region'), true);
  assert.equal(checkIntake({ business: { name: 'A', country: 'IN', region: '27' } }).value.business.region, '27');
});

test('names for folders: small letters, numbers and dashes, never taken twice', () => {
  assert.equal(slugFor('Luzon Fresh Mart'), 'luzon-fresh-mart');
  assert.equal(slugFor('  Café Zoë & Sons!! '), 'cafe-zoe-sons');
  assert.equal(slugFor('x'), 'x-1');
  assert.equal(slugFor('Luzon Fresh Mart', ['luzon-fresh-mart']), 'luzon-fresh-mart-2');
  assert.equal(slugFor('???'), 'customer');
  assert.ok(slugFor('a'.repeat(100)).length <= 41);
  assert.match(slugFor('../../etc/passwd'), /^[a-z0-9-]+$/);
});

test('the difference between two proposals is listed in plain words', () => {
  const a = propose({ business: { name: 'A', country: 'PH' }, look: { style: 'modern' } }).proposal;
  const b = JSON.parse(JSON.stringify(a));
  b.theme.shape = 'pill'; b.setup.settings.receiptFooter = 'Salamat po!'; b.setup.vocabulary = { customer: ['Suki', 'Sukis'] };
  const d = diffProposals(a, b);
  assert.deepEqual(d.map((x) => x.what).sort(), ['Corner shape', 'The word for "customer"', 'Words at the bottom of a bill'].sort());
  assert.deepEqual(diffProposals(a, a), []);
});

// ---- the look of the program, chosen per customer (the owner's idea: staff give each client the look they want, in a few clicks) --------------------------------------------------------------

test('a new customer gets the top menu look, written into the theme file by name, and the machine no longer decides the menu', () => {
  const a = checkIntake({ business: { name: 'A' } }).value;
  assert.equal(a.look.layout, 'top');
  assert.deepEqual(themeFor(a), { look: 'top' });
  const till = checkIntake({ business: { name: 'A' }, device: { kind: 'touch-pos', screen: 'standard' } }).value;
  assert.deepEqual(themeFor(till), { look: 'top' }, 'a touch till opens in the same look; its machine kind only sets printer and size of the preview');
  for (const layout of ['top', 'list', 'counter', 'auto', 'standard']) {
    const theme = themeFor(checkIntake({ business: { name: 'A' }, look: { layout, style: 'classic' } }).value);
    assert.equal(theme.look, layout);
    assert.deepEqual(parseTheme(theme).problems, [], layout);
  }
  assert.equal(checkIntake({ business: { name: 'A' }, look: { layout: 'poster' } }).value.look.layout, 'top', 'a word that is not a look is replaced by the starting look');
});

test('a theme file may name a look, and a word that is not a look is left out and said', () => {
  assert.deepEqual(parseTheme({ look: 'list' }), { value: { look: 'list' }, problems: [] });
  const bad = parseTheme({ look: 'poster', density: 'touch' });
  assert.deepEqual(bad.value, { density: 'touch' });
  assert.match(bad.problems.join(' '), /"look" must be one of/);
});

test('the looks are the same words in the Studio and in the Hub (the choices, and what each look is made of)', () => {
  assert.deepEqual(OPTIONS.layouts.map((l) => l.id), LOOKS);
  const hubDir = join(repoRoot, 'apps', 'business-hub', 'src', 'NextGenOS.Hub.Web');
  const code = readFileSync(join(hubDir, 'Branding', 'ShopLook.cs'), 'utf8');
  const choices = /Choices = \[([^\]]*)\]/.exec(code)[1].split(',').map((x) => x.trim().replace(/"/g, ''));
  assert.deepEqual([...choices].sort(), [...LOOKS].sort());
  const script = readFileSync(join(hubDir, 'wwwroot', 'theme.js'), 'utf8');
  for (const id of ['top', 'list', 'counter']) {
    const m = new RegExp(id + ": \\{ density: '(\\w+)', nav: '(\\w+)', navLabels: '(\\w+)', cart: '(\\w+)', scale: '([\\d.]+)' \\}").exec(script);
    assert.ok(m, 'theme.js has no values for ' + id);
    const t = LOOK_TOKENS[id];
    assert.deepEqual([t.density, t.nav, t.navLabels, t.cart, t.fontScale.toFixed(2)], [m[1], m[2], m[3], m[4], m[5]], id);
  }
});

test('"each screen decides" gives a touch machine the counter look and a laptop the list look; the preview follows the choice', () => {
  assert.equal(layoutTokens('auto', { kind: 'laptop', screen: 'standard' }).cart, 'bottom');
  assert.equal(layoutTokens('auto', { kind: 'touch-pos', screen: 'standard' }).nav, 'left');
  assert.equal(layoutTokens('top', { kind: 'kiosk', screen: 'small' }).nav, 'top');
  for (const layout of ['top', 'list', 'counter']) {
    const p = previewInput({ name: 'X', layout, kind: 'laptop', level: 'none' });
    assert.equal(previewTheme(p).nav, LOOK_TOKENS[layout].nav, layout);
    assert.match(previewHtml(p, { cssHref: '/b.css', logoSrc: null }), new RegExp(`data-look="${layout}"`));
  }
  assert.equal(previewLook(previewInput({ layout: 'auto', kind: 'tablet' })), 'counter');
  assert.equal(previewInput({ layout: 'poster' }).layout, 'top');
});
