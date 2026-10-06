// The AI assistant's profile (profile/ai.json): what staff type in the Studio, how it is checked, the file the Studio writes, and that the program reads all of it.
// The cases are shared with the program's own tests (apps/pos-ai-companion/tests/vectors/ai-profile.json), so the two sides cannot drift apart.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, mkdirSync, writeFileSync, readFileSync, readdirSync, existsSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { randomBytes } from 'node:crypto';
import { makeBaseKit } from '../../../scripts/make-base-kit.mjs';
import { readBaseKit } from '../lib/basekit.mjs';
import { checkIntake, OPTIONS, blankIntake } from '../lib/intake.mjs';
import { buildAiProfile, readAiProfile, checkImages, phrase, LIMITS, POSTER_KINDS } from '../lib/aiprofile.mjs';
import { countries, industries, industryPack, shopKindOf, languagesOf } from '../lib/packs.mjs';
import { buildPack } from '../lib/pack.mjs';
import { Workspace } from '../lib/workspace.mjs';
import { handoverFor } from '../lib/handover.mjs';
import { build as buildVectors, READ_CASES, BUILD_CASES } from '../scripts/make-ai-profile-vectors.mjs';
import { aiExplain } from '../ui/js/aiwords.js';
import { tidy } from '../ui/js/views/aiprofile.js';
import { auditFolder } from '../../../scripts/audit-package.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const root = resolve(here, '..', '..', '..');
const vectorsFile = resolve(root, 'apps', 'pos-ai-companion', 'tests', 'vectors', 'ai-profile.json');

const intakeOf = (images, over = {}) => {
  const r = checkIntake({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail' }, ecosystem: { aiAddon: { wanted: true } }, ...(images === undefined ? {} : { images }), ...over });
  return r;
};
const imagesErrors = (r) => r.errors.filter((e) => e.field.startsWith('images'));

// ---- the shared cases ------------------------------------------------------------------------------------------------------------------

test('the shared cases on disk are exactly what the Studio makes (the program reads the same file)', () => {
  const onDisk = JSON.parse(readFileSync(vectorsFile, 'utf8'));
  assert.deepEqual(onDisk, JSON.parse(JSON.stringify(buildVectors())), 'run: node tools/setup-studio/scripts/make-ai-profile-vectors.mjs');
  assert.ok(onDisk.read.length >= 40 && onDisk.build.length >= 12);
  assert.equal(onDisk.read.length, READ_CASES.length);
  assert.equal(onDisk.build.length, BUILD_CASES.length);
});

test('every file the Studio writes in the shared cases is read whole: nothing is left out, and it reads as the cases say', () => {
  for (const c of JSON.parse(readFileSync(vectorsFile, 'utf8')).build) {
    const r = readAiProfile(JSON.stringify(c.expect.file));
    assert.deepEqual(r.problems, [], c.name);
    assert.deepEqual(r.value, c.expect.read, c.name);
    assert.deepEqual(buildAiProfile(c.intake).file, c.expect.file, c.name);
  }
});

test('the shared read cases cover the ways a file can go wrong, and each wrong part is named', () => {
  const cases = JSON.parse(readFileSync(vectorsFile, 'utf8')).read;
  const named = cases.filter((c) => c.expect.problems.length > 0);
  assert.ok(named.length >= 15, `${named.length} cases name a problem`);
  for (const c of named) for (const p of c.expect.problems) assert.match(p, /^(The AI profile|Something in the AI profile|The second language needs)/, c.name);
  // no case lets markup or a control character through
  for (const c of cases) {
    const words = [c.expect.value.countryName, c.expect.value.shopKind, ...c.expect.value.festivals, ...c.expect.value.models.flatMap((m) => [m.title, m.looks]), ...Object.values(c.expect.value.posterLines), c.expect.value.localLanguage?.name ?? '', c.expect.value.localLanguage?.tag ?? ''];
    for (const w of words) assert.ok(!/[\u0000-\u001f\u007f-\u009f<>"\\]/.test(w), `${c.name}: ${JSON.stringify(w)}`);
  }
});

// ---- the details (intake) --------------------------------------------------------------------------------------------------------------

test('nothing typed means no "images" part at all, so details saved before this existed are unchanged', () => {
  assert.equal('images' in blankIntake(), false);
  const r = intakeOf(undefined);
  assert.equal('images' in r.value, false);
  assert.deepEqual(r.errors.filter((e) => e.field.startsWith('images')), []);
  const again = checkIntake(r.value);
  assert.deepEqual(again.value, r.value, 'checking twice changes nothing');
  assert.equal(intakeOf({}).value.images, undefined);
  assert.equal(intakeOf({ models: [{ title: ' ', looks: '' }], festivals: [' '], localLanguage: { name: '', tag: '' } }).value.images, undefined, 'blank is nothing');
});

test('the images part is cleaned into its one form and a second check changes nothing', () => {
  const r = intakeOf({
    countryName: '  the Philippines ', shopKind: ' a small shop ',
    models: [{ title: ' Filipino model ', looks: 'Filipino, in her late twenties' }, {}, { title: '', looks: '' }, { title: 'dropped: a fourth' }],
    festivals: [' Christmas', 'Sinulog', 'christmas', '', 5, null, 'SINULOG'],
    localLanguage: { name: ' Filipino ', tag: 'FIL', lines: { clearance: ' Malaking bawas ', 'best-sellers': '', unknown: 'x' } },
  });
  assert.deepEqual(imagesErrors(r), []);
  assert.deepEqual(r.value.images, {
    countryName: 'the Philippines', shopKind: 'a small shop',
    models: [{ title: 'Filipino model', looks: 'Filipino, in her late twenties' }],
    festivals: ['Christmas', 'Sinulog'],
    localLanguage: { name: 'Filipino', tag: 'fil', lines: { clearance: 'Malaking bawas' } },
  });
  assert.ok(r.warnings.some((w) => w.field === 'images.models'), 'a fourth photo is said not to be used');
  assert.deepEqual(checkIntake(r.value).value, r.value);
});

test('the Studio refuses what the program would drop, with the place and plain words, by the same rules', () => {
  const bad = (images) => imagesErrors(intakeOf(images));
  const at = (errors, field) => errors.find((e) => e.field === field)?.message;
  assert.match(at(bad({ countryName: 'x'.repeat(61) }), 'images.countryName'), /at most 60 letters/);
  assert.match(at(bad({ shopKind: 'a <b>shop</b>' }), 'images.shopKind'), /cannot have < > " \\ or a line break/);
  assert.match(at(bad({ models: [{ title: 'x'.repeat(41), looks: 'ok' }] }), 'images.models.0.title'), /product photo 3 can have at most 40 letters/);
  assert.match(at(bad({ models: [{}, { title: 'ok', looks: 'x'.repeat(121) }] }), 'images.models.1.looks'), /product photo 4 can have at most 120 letters/);
  assert.match(at(bad({ models: [{ looks: 'one\ntwo' }] }), 'images.models.0.looks'), /cannot have/);
  assert.match(at(bad({ festivals: ['Fine', 'Bad"quote'] }), 'images.festivals'), /festival name/);
  assert.match(at(bad({ festivals: ['x'.repeat(41)] }), 'images.festivals'), /at most 40 letters/);
  assert.match(at(bad({ festivals: Array.from({ length: 25 }, (_, i) => 'F' + i) }), 'images.festivals'), /At most 24 festivals/);
  assert.deepEqual(bad({ festivals: Array.from({ length: 24 }, (_, i) => 'F' + i) }), []);
  assert.deepEqual(bad({ festivals: [...Array.from({ length: 24 }, (_, i) => 'F' + i), 'f0', 'F1'] }), [], 'a repeat does not use a place');
  assert.match(at(bad({ localLanguage: { name: 'Hindi', tag: 'hindi' } }), 'images.localLanguage.tag'), /two or three small letters/);
  assert.match(at(bad({ localLanguage: { name: 'Hindi', tag: 'hi_IN' } }), 'images.localLanguage.tag'), /two or three small letters/);
  assert.match(at(bad({ localLanguage: { name: 'Hindi' } }), 'images.localLanguage.tag'), /Type the language's tag/);
  assert.match(at(bad({ localLanguage: { tag: 'hi' } }), 'images.localLanguage.name'), /Type the language's name/);
  assert.match(at(bad({ localLanguage: { name: 'Hindi', tag: 'hi', lines: { clearance: 'x'.repeat(41) } } }), 'images.localLanguage.lines.clearance'), /clearance poster line can have at most 40 letters/);
  assert.deepEqual(bad({ localLanguage: { name: 'Chinese', tag: 'zh-TW' } }), []);
  assert.deepEqual(bad({ localLanguage: { name: 'Hindi', tag: 'Hi' } }), [], 'a capital first letter is made small');
  // every problem makes the details incomplete
  assert.equal(intakeOf({ countryName: 'x'.repeat(61) }).complete, false);
  // ...but only when the customer gets the AI assistant: an optional part nobody asked for stops nothing
  const unwanted = checkIntake({ business: { name: 'A Shop', country: 'PH', industry: 'retail' }, images: { countryName: 'x'.repeat(61), festivals: ['ok'] } });
  assert.deepEqual(imagesErrors(unwanted), []);
  assert.deepEqual(unwanted.value.images, { festivals: ['ok'] });
  // apostrophes, ampersands and words in any script are fine
  assert.deepEqual(bad({ festivals: ["Valentine's Day", 'Eid & Co', 'दीवाली', 'วันสงกรานต์'] }), []);
});

test('a text that cannot be used stays in front of the person with its problem, saved or not, until it is put right', () => {
  const base = mkdtempSync(join(tmpdir(), 'ai-ws-'));
  try {
    const { workspace: ws, admin } = Workspace.init(join(base, 'ws'), { name: 'Asha', password: 'a-long-password' });
    const details = { business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail' }, ecosystem: { aiAddon: { wanted: true } } };
    const made = ws.create(admin, { ...details, images: { festivals: ['Sinulog', '<b>Eid</b>'], localLanguage: { name: 'Hindi', tag: 'hindi' } } });
    assert.deepEqual(made.intake.images.festivals, ['Sinulog', '<b>Eid</b>'], 'what was typed is kept, so it can be corrected');
    assert.equal(made.check.complete, false);
    assert.deepEqual(made.check.errors.filter((e) => e.field.startsWith('images')).map((e) => e.field).sort(), ['images.festivals', 'images.localLanguage.tag']);
    // the problem is the same when the saved details are read again later
    assert.deepEqual(ws.get(made.id).check.errors, made.check.errors);
    // put right, it is complete
    const fixed = ws.saveIntake(admin, made.id, { ...made.intake, images: { festivals: ['Sinulog', 'Eid'], localLanguage: { name: 'Hindi', tag: 'hi' } } });
    assert.deepEqual(fixed.check.errors.filter((e) => e.field.startsWith('images')), []);
    assert.equal(fixed.check.complete, true);
    // the assistant switched off: what is valid is kept for later, and nothing in it stops anything
    const off = ws.saveIntake(admin, made.id, { ...fixed.intake, ecosystem: { aiAddon: { wanted: false } } });
    assert.deepEqual(off.intake.images.festivals, ['Sinulog', 'Eid']);
    assert.equal(off.check.complete, true);
  } finally { rmSync(base, { recursive: true, force: true }); }
});

test('ready-made lines are kept but said to be unused when there is no second language', () => {
  const r = intakeOf({ localLanguage: { name: '', tag: '', lines: { clearance: 'Malaking bawas' } } });
  assert.ok(r.warnings.some((w) => w.field === 'images.localLanguage'));
  assert.equal(buildAiProfile(r.value).file.images, undefined);
});

test('the choices a screen shows come from one place and match the program\'s poster kinds', () => {
  assert.deepEqual(OPTIONS.posterKinds.map((k) => k.id), [...POSTER_KINDS]);
  assert.ok(OPTIONS.posterKinds.every((k) => k.label.length > 0));
  assert.deepEqual(OPTIONS.imageLimits, { ...LIMITS });
});

test('what is typed can never reach the program as something it drops: a thousand mixed attempts', () => {
  let seed = 20261006;
  const rnd = (n) => { seed = (seed * 1664525 + 1013904223) >>> 0; return seed % n; };
  const safe = ['a', 'B', 'z', ' ', '-', "'", '&', 'é', 'ü', 'द', 'ก', '1', '_'];
  const hostile = [...safe, '\u{1F389}', '<', '>', '"', '\\', '\n', '\t', '\u0007', '\u0085', '\u007f'];
  const pick = (list) => list[rnd(list.length)];
  let withProblems = 0;
  let clean = 0;
  for (let n = 0; n < 1000; n += 1) {
    const bad = rnd(3) === 0;          // a third of the attempts may hold anything, too long or with markup
    const word = (max) => Array.from({ length: rnd(bad ? max + 8 : max + 1) }, () => pick(bad ? hostile : safe)).join('');
    const some = (max, how) => Array.from({ length: rnd(max) }, how);
    const images = {
      ...(rnd(2) ? { countryName: word(60) } : {}), ...(rnd(2) ? { shopKind: word(60) } : {}),
      models: some(bad ? 5 : 4, () => ({ title: word(40), looks: word(120) })),
      festivals: some(bad ? 30 : 25, () => word(40)),
      localLanguage: bad || rnd(3) === 0 ? { name: word(40), tag: pick(['hi', 'fil', 'zh-TW', 'Hi', 'hindi', '', 'x', word(12)]), lines: Object.fromEntries(POSTER_KINDS.map((k) => [k, word(40)])) }
        : { name: 'Language ' + word(20), tag: pick(['hi', 'fil', 'zh-TW', 'Hi']), lines: Object.fromEntries(POSTER_KINDS.map((k) => [k, word(40)])) },
    };
    const r = checkIntake({ business: { name: 'Shop', country: pick(['PH', 'IN', 'JP', 'GB']), industry: pick(['retail', 'restaurant', 'library']) }, ecosystem: { aiAddon: { wanted: true } }, images });
    if (imagesErrors(r).length) { withProblems += 1; continue; }
    clean += 1;
    const built = buildAiProfile(r.value);
    assert.deepEqual(built.problems, [], JSON.stringify(images));
    const read = readAiProfile(built.text);
    assert.deepEqual(read.problems, [], JSON.stringify(images));
    // what was typed is what the program ends up with
    const im = r.value.images ?? {};
    assert.deepEqual(read.value.festivals, im.festivals ?? []);
    for (let i = 0; i < 3; i += 1) {
      assert.equal(read.value.models[i].title, im.models?.[i]?.title || `Model ${i + 1}`);
      assert.equal(read.value.models[i].looks, im.models?.[i]?.looks ?? '');
    }
    const language = im.localLanguage?.name && im.localLanguage?.tag ? { name: im.localLanguage.name, tag: im.localLanguage.tag } : null;
    assert.deepEqual(read.value.localLanguage, language);
    if (language) assert.deepEqual(Object.keys(read.value.posterLines), POSTER_KINDS.filter((k) => im.localLanguage.lines?.[k]));
    else assert.deepEqual(read.value.posterLines, {});
  }
  assert.ok(clean >= 100 && withProblems >= 30, `${clean} clean, ${withProblems} with problems: both kinds must be tried`);
});

// ---- the file --------------------------------------------------------------------------------------------------------------------------

test('with nothing typed the file says only what the packs say, and nothing about any market', () => {
  const { file } = buildAiProfile(intakeOf(undefined).value);
  assert.deepEqual(file, { schema: 1, country: { code: 'PH', name: 'Philippines' }, shopKind: 'a retail shop' });
  assert.deepEqual(buildAiProfile({ business: { country: 'ZZ', industry: 'nope' } }).file, { schema: 1 });
  assert.deepEqual(buildAiProfile({}).file, { schema: 1 });
  assert.equal(readAiProfile(buildAiProfile({}).text).value.shopKind, 'a small shop', 'the program stays neutral');
  for (const c of countries()) {
    const text = buildAiProfile({ business: { country: c.code, industry: 'generic' } }).text;
    for (const word of ['Hindi', 'Diwali', 'fair complexion', 'European', 'East Asian']) assert.ok(!text.includes(word), `${c.code}: ${word}`);
    if (c.code !== 'IN') assert.ok(!/India/.test(text), `${c.code}: no other country is named`);
    assert.ok(!/images/.test(text), `${c.code}: nothing about pictures unless typed`);
  }
});

test('changing one setting changes the file, and only its own part', () => {
  const base = { business: { country: 'PH', industry: 'retail' }, images: { models: [{ title: 'Filipino model', looks: 'Filipino' }], festivals: ['Christmas'], localLanguage: { name: 'Filipino', tag: 'fil', lines: { clearance: 'Malaking bawas' } } } };
  const file = (over) => buildAiProfile({ ...base, ...over, business: { ...base.business, ...(over?.business ?? {}) }, images: { ...base.images, ...(over?.images ?? {}) } }).file;
  const before = file({});
  const changes = {
    'the country': { business: { country: 'JP' } },
    'the kind of business': { business: { industry: 'restaurant' } },
    'the country as the AI says it': { images: { countryName: 'the Philippines' } },
    'the kind of business as the AI says it': { images: { shopKind: 'a small shop' } },
    'a model photo': { images: { models: [{ title: 'Visayan model', looks: 'Visayan' }] } },
    'the festivals': { images: { festivals: ['Christmas', 'Sinulog'] } },
    'the second language': { images: { localLanguage: { name: 'Hindi', tag: 'hi' } } },
    'a ready-made line': { images: { localLanguage: { name: 'Filipino', tag: 'fil', lines: { clearance: 'Iba pa' } } } },
  };
  for (const [what, over] of Object.entries(changes)) {
    const after = file(over);
    assert.notDeepEqual(after, before, `changing ${what} must change the file`);
    // only its own part changed
    const part = (f) => ({ country: f.country, shopKind: f.shopKind, models: f.images?.models, festivals: f.images?.festivals, language: f.images?.localLanguage });
    const changed = Object.keys(part(before)).filter((k) => JSON.stringify(part(before)[k]) !== JSON.stringify(part(after)[k]));
    const expected = { 'the country': ['country'], 'the kind of business': ['shopKind'], 'the country as the AI says it': ['country'], 'the kind of business as the AI says it': ['shopKind'], 'a model photo': ['models'], 'the festivals': ['festivals'], 'the second language': ['language'], 'a ready-made line': ['language'] }[what];
    assert.deepEqual(changed, expected, what);
    // and the program reads the change
    assert.notDeepEqual(readAiProfile(JSON.stringify(after)).value, readAiProfile(JSON.stringify(before)).value, what);
  }
});

test('the kind of business and the country come from the packs; every pack gives words the program can use', () => {
  for (const i of industries()) {
    assert.ok(i.shopKind.length > 0, i.id);
    assert.equal(phrase(i.shopKind, LIMITS.shopKind).problem, null, i.id);
    assert.equal(i.shopKind, shopKindOf(industryPack(i.id)));
  }
  assert.equal(industries().find((i) => i.id === 'retail').shopKind, 'a retail shop');
  for (const c of countries()) {
    assert.equal(phrase(c.name, LIMITS.country).problem, null, c.code);
    assert.ok(c.name.length > 0);
    // the language suggestions: never English, each with a name and a tag the program accepts
    for (const l of c.languages) {
      assert.notEqual(l.tag, 'en');
      assert.match(l.tag, /^[a-z]{2,3}$/);
      assert.ok(l.name && l.name !== l.tag, `${c.code} ${l.tag}`);
      assert.equal(phrase(l.name, LIMITS.language).problem, null);
    }
  }
  assert.deepEqual(countries().find((c) => c.code === 'PH').languages, [{ tag: 'fil', name: 'Filipino' }]);
  assert.deepEqual(countries().find((c) => c.code === 'GB').languages, []);
  assert.deepEqual(languagesOf(null), []);
  assert.deepEqual(languagesOf({ languages: ['en', 'hi', 'hi', 5, 'HI', 'a', 'toolong'] }).map((l) => l.tag), ['hi']);
});

// ---- the screen ------------------------------------------------------------------------------------------------------------------------

test('the live explanation says what the file holds, and changes when a setting changes', () => {
  const country = (code) => countries().find((c) => c.code === code);
  const industry = (id) => industries().find((i) => i.id === id);
  const lines = (draft) => Object.fromEntries(aiExplain({ draft, country: country(draft.business.country), industry: industry(draft.business.industry), posterKinds: OPTIONS.posterKinds }).map((l) => [l.id, l.text]));
  const plain = { business: { country: 'PH', industry: 'retail' } };
  const none = lines(plain);
  assert.equal(none.business, 'Pictures and posters are made for a retail shop in Philippines.');
  assert.match(none['model-0'], /Product photo 3 is called "Model 1"\. No look is asked for/);
  assert.match(none.festivals, /No festival is named/);
  assert.equal(none.language, 'Posters are in one language.');
  assert.equal(lines({ business: { country: 'ZZ', industry: 'nope' } }).business, 'Pictures and posters are made for a small shop.', 'with nothing known it stays neutral');

  const full = { ...plain, images: { countryName: 'the Philippines', shopKind: 'a small shop', models: [{ title: 'Filipino model', looks: 'Filipino' }], festivals: ['Christmas', 'Sinulog'], localLanguage: { name: 'Filipino', tag: 'fil', lines: { clearance: 'Malaking bawas', 'new-arrivals': ' ' } } } };
  const said = lines(full);
  assert.equal(said.business, 'Pictures and posters are made for a small shop in the Philippines.');
  assert.match(said['model-0'], /called "Filipino model"\. The person looks like this: Filipino\./);
  assert.match(said['model-1'], /called "Model 2"/);
  assert.match(said.festivals, /Christmas, Sinulog/);
  assert.match(said.language, /second line in Filipino \(fil\)\. Ready-made lines for: clearance\./);
  for (const id of ['business', 'model-0', 'festivals', 'language']) assert.notEqual(none[id], said[id], `the explanation of ${id} changes with the setting`);
  assert.equal(none['model-1'], said['model-1'], 'a photo that was not typed stays as it was');

  // it agrees with the file that is written
  const intake = checkIntake({ business: { name: 'A Shop', country: 'PH', industry: 'retail' }, ecosystem: { aiAddon: { wanted: true } }, images: full.images }).value;
  const built = buildAiProfile(intake).file;
  assert.equal(said.business.replace('Pictures and posters are made for ', '').replace(/\.$/, ''), `${built.shopKind} in ${built.country.name}`);
  for (const f of built.images.festivals) assert.ok(said.festivals.includes(f));
  assert.ok(said['model-0'].includes(built.images.models[0].title));
  assert.ok(said.language.includes(built.images.localLanguage.name) && said.language.includes(built.images.localLanguage.tag));
  // the screen's own neutral wording is the program's
  assert.equal(readAiProfile('{"schema":1}').value.shopKind, 'a small shop');
});

test('the screen keeps the details as they were when something typed is cleared again', () => {
  const d = { business: {}, images: { countryName: ' ', models: [{ title: '', looks: '' }, { title: '', looks: '' }], festivals: [], localLanguage: { name: '', tag: '', lines: { clearance: '' } } } };
  tidy(d);
  assert.equal('images' in d, false);
  const e = { images: { models: [{ title: '', looks: '' }, { title: 'Second', looks: '' }, { title: '', looks: '' }], localLanguage: { name: 'Hindi', tag: '', lines: { clearance: ' ', 'best-sellers': 'x' } } } };
  tidy(e);
  assert.deepEqual(e.images, { models: [{ title: '', looks: '' }, { title: 'Second', looks: '' }], localLanguage: { name: 'Hindi', tag: '', lines: { 'best-sellers': 'x' } } });
  // the same form the server keeps
  const kept = checkIntake({ business: { name: 'A', country: 'PH', industry: 'retail' }, ecosystem: { aiAddon: { wanted: true } }, images: e.images });
  assert.deepEqual(kept.value.images.models, e.images.models);
});

// ---- the customers' own profiles --------------------------------------------------------------------------------------------------------

test('each customer\'s own profile in its brand kit is read without a problem, and the Studio could write the same file from details', () => {
  const kits = readdirSync(join(root, 'brand-kits'), { withFileTypes: true }).filter((e) => e.isDirectory() && existsSync(join(root, 'brand-kits', e.name, 'ai.json'))).map((e) => e.name);
  assert.ok(kits.length >= 1, 'a customer whose pictures and posters used to be fixed keeps them as data');
  for (const kit of kits) {
    const text = readFileSync(join(root, 'brand-kits', kit, 'ai.json'), 'utf8');
    const r = readAiProfile(text);
    assert.deepEqual(r.problems, [], kit);
    assert.ok(r.value.countryName && r.value.festivals.length > 0 && r.value.localLanguage && r.value.models.every((m) => m.looks), kit);
    // the details that make this file
    const file = JSON.parse(text);
    const intake = checkIntake({ business: { name: 'A Shop', country: file.country.code, industry: 'retail' }, ecosystem: { aiAddon: { wanted: true } }, images: { countryName: file.country.name, shopKind: file.shopKind, ...file.images } });
    assert.deepEqual(imagesErrors(intake), [], kit);
    assert.deepEqual(buildAiProfile(intake.value).file, file, `${kit}: the Studio writes exactly this file from these details`);
  }
});

// ---- the customer pack -------------------------------------------------------------------------------------------------------------------

async function programs(rootFolder) {
  const dir = join(rootFolder, 'programs');
  mkdirSync(dir);
  const files = { 'SmartRetailPOS-Hub-Setup-1.4.0.exe': randomBytes(2000), 'smart-retail-pos-hub_1.4.0-1_amd64.deb': randomBytes(2000), 'SmartRetailAI-Setup.exe': randomBytes(1500) };
  for (const [n, d] of Object.entries(files)) writeFileSync(join(dir, n), d);
  const { manifest } = await makeBaseKit(dir);
  writeFileSync(join(dir, 'base-kit.json'), JSON.stringify(manifest));
  return dir;
}
const partsOf = (intake) => ({
  info: { n: 2, bundleHash: 'cd'.repeat(32), approvedAt: '2026-10-05T10:00:00.000Z' }, intake,
  files: { 'setup.json': Buffer.from('{"schema":1}\n'), 'theme.json': Buffer.from('{"schema":1}\n'), 'brand.json': Buffer.from('{"schema":1}\n') }, logo: null,
});

test('the customer pack carries profile/ai.json beside the AI assistant\'s setup, listed and fingerprinted, and says so in plain words', async () => {
  const base = mkdtempSync(join(tmpdir(), 'ai-pack-'));
  try {
    const kit = await readBaseKit(await programs(base));
    const withImages = intakeOf({ models: [{ title: 'Filipino model', looks: 'Filipino' }], festivals: ['Christmas', 'Sinulog'], localLanguage: { name: 'Filipino', tag: 'fil', lines: { clearance: 'Malaking bawas' } } }).value;
    const r = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(withImages), kit, out: join(base, 'out'), now: new Date('2026-10-05T12:00:00Z') });
    const folder = join(r.dir, '2 - AI assistant (Windows)');
    assert.ok(existsSync(join(folder, 'SmartRetailAI-Setup.exe')));
    const text = readFileSync(join(folder, 'profile', 'ai.json'), 'utf8');
    assert.equal(text, buildAiProfile(withImages).text);
    const read = readAiProfile(text);
    assert.deepEqual(read.problems, []);
    assert.deepEqual(read.value.festivals, ['Christmas', 'Sinulog']);
    assert.equal(read.value.countryName, 'Philippines');
    assert.deepEqual(readdirSync(join(folder, 'profile')), ['ai.json'], 'only the data file, nothing else');
    assert.ok(r.contents.files.some((f) => f.path === '2 - AI assistant (Windows)/profile/ai.json'), 'PACK-CONTENTS lists it');
    assert.match(readFileSync(join(folder, 'READ ME FIRST.txt'), 'utf8'), /Keep this whole folder together[\s\S]*folder called "profile"[\s\S]*Without it the AI still works, with neutral wording/);
    const sheet = readFileSync(join(r.dir, 'START HERE.html'), 'utf8');
    assert.match(sheet, /The AI assistant, for the Windows POS, set up with the people in its product photos, its festivals and the second language of its posters/);
    assert.match(sheet, /for the AI assistant, open the folder &quot;2 - AI assistant \(Windows\)&quot;/);
    // what a customer receives is audited the way every other package is
    assert.deepEqual(auditFolder(r.dir).problems, []);

    // nothing typed: still a file, neutral beyond the country and the kind of business, and a different pack gives a different file
    const plain = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intakeOf(undefined).value), kit, out: join(base, 'out2'), now: new Date('2026-10-05T12:00:00Z') });
    const plainText = readFileSync(join(plain.dir, '2 - AI assistant (Windows)', 'profile', 'ai.json'), 'utf8');
    assert.deepEqual(JSON.parse(plainText), { schema: 1, country: { code: 'PH', name: 'Philippines' }, shopKind: 'a retail shop' });
    assert.notEqual(plainText, text);
    assert.match(readFileSync(join(plain.dir, 'START HERE.html'), 'utf8'), /The AI assistant, for the Windows POS\./);

    // no AI assistant ordered: no AI folder and no file; on Linux it is left out
    const none = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intakeOf(undefined, { ecosystem: { aiAddon: { wanted: false } } }).value), kit, out: join(base, 'out3') });
    assert.equal(existsSync(join(none.dir, '2 - AI assistant (Windows)')), false);
    const linux = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intakeOf({ festivals: ['Christmas'] }, { device: { kind: 'laptop', os: 'linux', screen: 'standard' } }).value), kit, out: join(base, 'out4') });
    assert.equal(existsSync(join(linux.dir, '2 - AI assistant (Windows)')), false);
    assert.doesNotMatch(readFileSync(join(linux.dir, 'START HERE.html'), 'utf8'), /AI assistant/);
  } finally { rmSync(base, { recursive: true, force: true }); }
});

test('the hand-over sheet only talks about the AI assistant\'s folder when the pack has it', () => {
  const intake = intakeOf({ festivals: ['Christmas'] }).value;
  const info = { n: 1, approvedAt: '2026-10-05T10:00:00Z', bundleHash: 'ab'.repeat(32) };
  const steps = (pack) => handoverFor({ intake, info, pack }).sections.find((s) => s.steps)?.steps ?? [];
  assert.ok(!steps(true).some((s) => /AI assistant/.test(s)));
  assert.ok(!steps(null).some((s) => /AI assistant/.test(s)));
  assert.ok(steps({ ai: true }).some((s) => /2 - AI assistant \(Windows\)/.test(s)));
  const what = handoverFor({ intake, info }).sections[0].bullets.find((b) => /AI assistant/.test(b));
  assert.equal(what, 'The AI assistant, for the Windows POS, set up with its festivals.');
});
