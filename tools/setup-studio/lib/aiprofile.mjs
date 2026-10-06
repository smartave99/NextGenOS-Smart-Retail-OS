// The AI assistant's profile (profile/ai.json): what its pictures and posters need to know about one customer's business, kept as the customer's own data and never written into the
// program (CLAUDE.md, section 8). It holds the country, the kind of business, who the three model photos show, the festivals of the shop's customers and the second language of its posters.
//
// Three things live here:
//   - checkImages: the check of the optional "images" part of a customer's details (what staff type in the Studio), with a place and plain words for each problem;
//   - buildAiProfile: the file itself, made from an approved release's details (the country and the kind of business come from the packs);
//   - readAiProfile: the Studio's twin of the program's own reader (apps/pos-ai-companion: Settings/ShopProfile.cs). Both read the shared cases in
//     apps/pos-ai-companion/tests/vectors/ai-profile.json (made by tools/setup-studio/scripts/make-ai-profile-vectors.mjs), so what the Studio writes is never something the program drops.
// Nothing here assumes a market: with nothing typed, the file says only what the packs say (the country's name, the kind of business), or nothing.
import { countryPack, industryPack, shopKindOf } from './packs.mjs';

/** The limits the program reads by (ShopProfile.cs). */
export const LIMITS = Object.freeze({ country: 60, shopKind: 60, modelTitle: 40, modelLooks: 120, festival: 40, language: 40, tag: 12, line: 40, models: 3, festivals: 24 });
/** The kinds of poster that can have a ready-made second-language line (the dashboard's poster kinds). */
export const POSTER_KINDS = Object.freeze(['clearance', 'new-arrivals', 'best-sellers', 'festival-offer']);
/** The words people see for each kind of poster (the dashboard's own titles). */
export const POSTER_KIND_LABELS = Object.freeze({ clearance: 'Clearance', 'new-arrivals': 'New arrivals', 'best-sellers': 'Best sellers', 'festival-offer': 'Festival offer' });
const TAG = /^[a-z]{2,3}(-[A-Za-z0-9]{2,8})*$/;
const FORBIDDEN = /[\u0000-\u001f\u007f-\u009f<>"\\]/;
const isObj = (v) => v !== null && typeof v === 'object' && !Array.isArray(v);

// What the program trims from the ends of a phrase: .NET's white space. JavaScript's own trim() differs in two places (it also trims U+FEFF and does not trim U+0085), so it is not used.
const SPACE = String.raw`[\t\n\v\f\r \u0085\u00a0\u1680\u2000-\u200a\u2028\u2029\u202f\u205f\u3000]`;
const ENDS = new RegExp(`^${SPACE}+|${SPACE}+$`, 'g');
export const trimLikeTheProgram = (text) => text.replace(ENDS, '');

/** One short plain phrase, as the program reads it: trimmed, at most `max` letters, no markup and no control characters. Returns { text, problem } (problem: 'long', 'letters' or null). */
export function phrase(value, max) {
  if (typeof value !== 'string') return { text: '', problem: null };
  const text = trimLikeTheProgram(value);
  if (text === '') return { text: '', problem: null };
  if (text.length > max) return { text: '', problem: 'long' };
  if (FORBIDDEN.test(text)) return { text: '', problem: 'letters' };
  return { text, problem: null };
}
const said = (problem, max, label) => (problem === 'long' ? `${label} can have at most ${max} letters.` : `${label} cannot have < > " \\ or a line break.`);
// Two festival names are the same when only the case differs, as the program decides it (.NET's ordinal ignore-case: each letter by its simple capital).
// (A letter whose capital would be several letters stays as it is, and so does a letter outside ASCII whose capital is an ASCII one, like the dotless i: .NET leaves those out.)
const capital = (c) => { const up = c.toUpperCase(); return up.length === c.length && !(c.charCodeAt(0) > 127 && up.charCodeAt(0) < 128) ? up : c; };
const fold = (text) => Array.from(text, capital).join('');
const sameWord = (a, b) => fold(a) === fold(b);

/**
 * Checks the "images" part of a customer's details. Returns the part cleaned into its one form, or null when nothing is set.
 *   wanted: the AI assistant is part of this customer's order. Then a text that cannot be used is kept as typed and named as a problem (so it stays in front of the person until it is put
 *   right, as the other details do); when it is not, such a text is simply left out and stops nothing.
 * Cleaned form (each field is there only when it has something in it):
 *   { countryName, shopKind, models: [{ title, looks }] (up to 3), festivals: [text] (up to 24), localLanguage: { name, tag, lines: { clearance, ... } } }
 */
export function checkImages(raw, { wanted = false, bad = () => {}, warn = () => {} } = {}) {
  const src = isObj(raw) ? raw : {};
  const report = wanted ? bad : () => {};
  const note = wanted ? warn : () => {};
  // a byte-order mark that came in with a pasted text is not a letter and is dropped, so it cannot sit invisibly in the file
  const given = (value) => (typeof value === 'string' ? value.replace(/\ufeff/g, '') : value);
  const one = (value, max, field, label) => {
    const r = phrase(given(value), max);
    if (!r.problem) return r.text;
    report(field, said(r.problem, max, label));
    return wanted ? trimLikeTheProgram(given(value)).slice(0, max + 40) : '';
  };
  const out = {};

  const countryName = one(src.countryName, LIMITS.country, 'images.countryName', 'The name of the country for the AI');
  if (countryName) out.countryName = countryName;
  const shopKind = one(src.shopKind, LIMITS.shopKind, 'images.shopKind', 'The kind of business for the AI');
  if (shopKind) out.shopKind = shopKind;

  const photos = Array.isArray(src.models) ? src.models : [];
  if (photos.length > LIMITS.models) note('images.models', `Only the first ${LIMITS.models} model photos are used.`);
  const models = photos.slice(0, LIMITS.models).map((m, i) => ({
    title: one(isObj(m) ? m.title : '', LIMITS.modelTitle, `images.models.${i}.title`, `The name of product photo ${i + 3}`),
    looks: one(isObj(m) ? m.looks : '', LIMITS.modelLooks, `images.models.${i}.looks`, `The description of the person in product photo ${i + 3}`),
  }));
  while (models.length && !models.at(-1).title && !models.at(-1).looks) models.pop();
  if (models.length) out.models = models;

  const festivals = [];
  for (const f of Array.isArray(src.festivals) ? src.festivals : []) {
    const shown = typeof f === 'string' ? trimLikeTheProgram(given(f)) : '';
    const name = one(f, LIMITS.festival, 'images.festivals', shown ? `The festival name "${shown.slice(0, 12)}${shown.length > 12 ? '...' : ''}"` : 'A festival name');
    if (name && !festivals.some((x) => sameWord(x, name))) festivals.push(name);
  }
  if (festivals.length > LIMITS.festivals) { report('images.festivals', `At most ${LIMITS.festivals} festivals can be used. Take some out.`); festivals.length = Math.min(festivals.length, 50); }
  if (festivals.length) out.festivals = festivals;

  const l = isObj(src.localLanguage) ? src.localLanguage : {};
  const name = one(l.name, LIMITS.language, 'images.localLanguage.name', 'The name of the second language');
  const tagRead = phrase(given(l.tag), LIMITS.tag);
  let tag = one(l.tag, LIMITS.tag, 'images.localLanguage.tag', 'The short code of the second language');
  if (!tagRead.problem && tag) {
    tag = tag.replace(/^[A-Za-z]{2,3}/, (m) => m.toLowerCase());
    if (!TAG.test(tag)) {
      report('images.localLanguage.tag', 'The language tag is two or three small letters, like hi or fil (a dash and more letters may follow, like zh-TW).');
      if (!wanted) tag = '';
    }
  }
  const lines = {};
  const lineSource = isObj(l.lines) ? l.lines : {};
  for (const kind of POSTER_KINDS) {
    const line = one(lineSource[kind], LIMITS.line, `images.localLanguage.lines.${kind}`, `The ${POSTER_KIND_LABELS[kind].toLowerCase()} poster line`);
    if (line) lines[kind] = line;
  }
  if (name && !tag) report('images.localLanguage.tag', 'Type the language\'s tag as well, two or three small letters like hi or fil.');
  if (tag && !name) report('images.localLanguage.name', 'Type the language\'s name as well, like Hindi or Filipino.');
  if (Object.keys(lines).length && !(name && tag)) note('images.localLanguage', 'The ready-made poster lines are only used when a second language is chosen above.');
  if (name || tag || Object.keys(lines).length) out.localLanguage = { name, tag, ...(Object.keys(lines).length ? { lines } : {}) };

  return Object.keys(out).length ? out : null;
}

/**
 * The AI profile for one customer, from the details of an approved release. Returns { file, text, problems }:
 * `file` is the content of profile/ai.json, `text` is how it is written, and `problems` is empty when the program will read all of it (the file is read back by the twin of the program's reader).
 */
export function buildAiProfile(intake) {
  const problems = [];
  const business = isObj(intake?.business) ? intake.business : {};
  const images = isObj(intake?.images) ? intake.images : {};
  const use = (value, max, what) => {
    const r = phrase(value, max);
    if (r.problem) problems.push(`${what} cannot be used in the AI assistant's profile (${r.problem === 'long' ? `more than ${max} letters` : 'it has a < > " \\ or a line break'}).`);
    return r.text;
  };

  const pack = countryPack(business.country);
  const kind = industryPack(business.industry);
  const countryName = use(images.countryName || pack?.name, LIMITS.country, 'The country\'s name');
  const shopKind = use(images.shopKind || shopKindOf(kind), LIMITS.shopKind, 'The kind of business');

  const file = { schema: 1 };
  if (countryName) file.country = { ...(typeof business.country === 'string' && /^[A-Za-z]{2}$/.test(business.country) ? { code: business.country.toUpperCase() } : {}), name: countryName };
  if (shopKind) file.shopKind = shopKind;

  const part = {};
  const models = (Array.isArray(images.models) ? images.models : []).slice(0, LIMITS.models).map((m, i) => {
    const one = {};
    const title = use(m?.title, LIMITS.modelTitle, `The title of model photo ${i + 1}`);
    const looks = use(m?.looks, LIMITS.modelLooks, `The look of model photo ${i + 1}`);
    if (title) one.title = title;
    if (looks) one.looks = looks;
    return one;
  });
  while (models.length && Object.keys(models.at(-1)).length === 0) models.pop();
  if (models.length) part.models = models;

  const festivals = [];
  for (const f of Array.isArray(images.festivals) ? images.festivals : []) {
    const name = use(f, LIMITS.festival, 'A festival');
    if (name && !festivals.some((x) => sameWord(x, name))) festivals.push(name);
  }
  if (festivals.length > LIMITS.festivals) problems.push(`More than ${LIMITS.festivals} festivals were given; the program uses at most ${LIMITS.festivals}.`);
  if (festivals.length) part.festivals = festivals.slice(0, LIMITS.festivals);

  const l = isObj(images.localLanguage) ? images.localLanguage : {};
  const languageName = use(l.name, LIMITS.language, 'The second language\'s name');
  const tag = use(l.tag, LIMITS.tag, 'The second language\'s tag');
  if (languageName && tag && TAG.test(tag)) {
    const language = { name: languageName, tag };
    const lines = {};
    for (const k of POSTER_KINDS) {
      const line = use(isObj(l.lines) ? l.lines[k] : '', LIMITS.line, `The ready-made poster line for ${k}`);
      if (line) lines[k] = line;
    }
    if (Object.keys(lines).length) language.lines = lines;
    part.localLanguage = language;
  } else if (languageName || tag) problems.push('The second language needs a name and a tag like hi or fil.');
  if (Object.keys(part).length) file.images = part;

  const text = JSON.stringify(file, null, 2) + '\n';
  problems.push(...readAiProfile(text).problems);
  return { file, text, problems };
}

/** The neutral values of the program (ShopProfile.cs): what it uses with no profile. */
export const NEUTRAL = Object.freeze({ shopKind: 'a small shop' });

/**
 * The twin of the program's reader (ShopProfile.Parse): the same rules, the same limits, the same words for what it leaves out, in the same order.
 * Returns { value, problems }; `value` is what the program ends up with, in the plain form the shared cases use:
 *   { countryName, shopKind, models: [{ title, looks }] x3 (as the program names them: "Model 1" when no title), festivals, localLanguage: { name, tag } | null, posterLines: { kind: line } }
 */
export function readAiProfile(input) {
  const problems = [];
  const value = { countryName: '', shopKind: NEUTRAL.shopKind, models: [], festivals: [], localLanguage: null, posterLines: {} };
  const finish = () => {
    value.models = [0, 1, 2].map((i) => ({ title: trimLikeTheProgram(value.models[i]?.title ?? '') || `Model ${i + 1}`, looks: trimLikeTheProgram(value.models[i]?.looks ?? '') }));
    return { value, problems };
  };
  const words = (token, max, what) => {
    const r = phrase(token, max);
    if (r.problem) problems.push(`Something in the AI profile is not usable as ${what}; it is left out.`);
    return r.text;
  };

  let root = null;
  try { root = JSON.parse(typeof input === 'string' ? input : JSON.stringify(input) ?? ''); } catch { root = null; }
  if (!isObj(root)) { problems.push('The AI profile is not a JSON object; the neutral one is used.'); return finish(); }
  if (!Number.isInteger(root.schema) || root.schema !== 1) { problems.push('The AI profile does not say "schema": 1; the neutral one is used.'); return finish(); }

  value.countryName = words(isObj(root.country) ? root.country.name : null, LIMITS.country, 'the country\'s name');
  const kind = words(root.shopKind, LIMITS.shopKind, 'the kind of business');
  if (kind) value.shopKind = kind;

  const part = isObj(root.images) ? root.images : null;
  if (Array.isArray(part?.models)) {
    for (const item of part.models.slice(0, LIMITS.models)) {
      const one = isObj(item) ? item : null;
      value.models.push({ title: words(one?.title, LIMITS.modelTitle, 'a model\'s title'), looks: words(one?.looks, LIMITS.modelLooks, 'a model\'s looks') });
    }
  }
  if (Array.isArray(part?.festivals)) {
    for (const item of part.festivals) {
      const name = words(item, LIMITS.festival, 'a festival');
      if (name && !value.festivals.some((x) => sameWord(x, name)) && value.festivals.length < LIMITS.festivals) value.festivals.push(name);
    }
  }
  const language = isObj(part?.localLanguage) ? part.localLanguage : null;
  if (language) {
    const name = words(language.name, LIMITS.language, 'the second language');
    const tag = words(language.tag, LIMITS.tag, 'the language tag');
    if (name && TAG.test(tag)) {
      value.localLanguage = { name, tag };
      if (isObj(language.lines)) {
        for (const kindOfPoster of POSTER_KINDS) {
          const line = words(language.lines[kindOfPoster], LIMITS.line, 'a poster line');
          if (line) value.posterLines[kindOfPoster] = line;
        }
      }
    } else if (name || tag) problems.push('The second language needs a name and a tag like hi or fil; it is left out.');
  }
  return finish();
}
