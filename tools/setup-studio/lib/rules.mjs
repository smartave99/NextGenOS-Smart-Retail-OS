// The rules a customer's profile must follow, written once for the Studio. They are the same rules the Business Hub applies when it reads the files
// (apps/business-hub: SetupProfile.cs, and licensing/clients/dotnet: ThemePolicy.cs, BrandPolicy.cs); the shared test vectors keep the two sides the same
// (apps/business-hub/tests/vectors/setup-profile.json, licensing/testvectors/theme-policy.json). The Studio uses them to check every proposal, whoever or whatever
// wrote it, before a person sees it: a proposal from an AI tool is only ever data to be checked.
import { countryPack, industryPack } from './packs.mjs';

export const MAX_STARTER = 2000;
const FEATURES = ['counterSale', 'tables', 'kitchen', 'lending', 'projects', 'appointments', 'credit', 'purchases', 'weighedItems'];
const KNOWN = ['schema', 'business', 'settings', 'vocabulary', 'features', 'starter', 'notes'];
const PRICE = /^\d{1,12}(\.\d{1,4})?$/;
const WORD = /^[\p{L}\p{N} -]{1,20}$/u;

const isObject = (v) => v !== null && typeof v === 'object' && !Array.isArray(v);

/** Control characters taken out (a new line may stay), trimmed, cut to max letters. Null when nothing is left. */
export function clean(text, max) {
  if (typeof text !== 'string' || text.trim() === '') return null;
  const t = [...text].filter((c) => { const n = c.charCodeAt(0); return !(n < 32 || (n >= 127 && n <= 159)) || n === 10; }).join('').trim();
  return t.length === 0 ? null : t.length <= max ? t : t.slice(0, max);
}
const text = (o, name) => (isObject(o) && typeof o[name] === 'string' ? o[name] : null);
const flag = (o, name) => (isObject(o) && typeof o[name] === 'boolean' ? o[name] : null);

function depthOf(v, d = 1) {
  if (v === null || typeof v !== 'object') return d - 1;
  let max = d;
  for (const x of Array.isArray(v) ? v : Object.values(v)) max = Math.max(max, depthOf(x, d + 1));
  return max;
}

/**
 * Reads a setup profile (the text, or the object already read). Never throws. A part that is wrong is left out and named in plain words; the rest still counts.
 * Returns { value, problems }; value is the profile in its one plain form (prices as text), ready to be written as setup.json.
 */
export function parseSetup(input) {
  const problems = [];
  const empty = () => ({ value: { schema: 1 }, problems });
  let root = input;
  if (typeof input === 'string' || input === undefined || input === null) {
    if (input === undefined || input === null || input.trim() === '') return { value: null, problems };
    try { root = JSON.parse(input); } catch { problems.push('The setup file is not readable (it is not valid JSON).'); return { value: null, problems }; }
    if (depthOf(root) > 16) { problems.push('The setup file is not readable (it is not valid JSON).'); return { value: null, problems }; }
  }
  if (!isObject(root)) { problems.push('The setup file is not a setup profile.'); return { value: null, problems }; }
  for (const name of Object.keys(root)) if (!KNOWN.includes(name)) problems.push(`"${name}" is not a part of a setup profile and is ignored.`);
  if (typeof root.schema !== 'number' || root.schema !== 1) { problems.push('The setup file must say "schema": 1.'); return { value: null, problems }; }

  const out = { schema: 1 };
  const business = {};
  let country = null, industry = null;
  if (isObject(root.business)) {
    const b = root.business;
    const name = clean(text(b, 'name'), 80);
    if (name) business.name = name;
    const c = text(b, 'country')?.trim().toUpperCase();
    let pack = null;
    if (c) {
      pack = countryPack(c);
      if (!pack) problems.push(`There is no tax pack for the country "${c}"; the country is left to choose.`);
      else { country = c; business.country = c; }
    }
    const i = text(b, 'industry')?.trim().toLowerCase();
    if (i) {
      if (!industryPack(i)) problems.push(`There is no kind of business called "${i}"; it is left to choose.`);
      else { industry = i; business.industry = i; }
    }
    const r = text(b, 'region')?.trim();
    if (r) {
      if ((pack?.tax?.regions?.list ?? []).some((x) => x.code === r)) business.region = r;
      else problems.push(`The region "${r}" is not one of the country's; it is left to choose.`);
    }
  }
  if (Object.keys(business).length) out.business = business;

  if (isObject(root.settings)) {
    const s = root.settings;
    const settings = {};
    for (const f of ['pricesIncludeTax', 'taxRegistered', 'roundTotal', 'allowNegativeStock']) { const v = flag(s, f); if (v !== null) settings[f] = v; }
    const footer = clean(text(s, 'receiptFooter'), 160);
    if (footer) settings.receiptFooter = footer;
    if (Array.isArray(s.paymentMethods)) {
      const methods = [];
      for (const m of s.paymentMethods) {
        const word = typeof m === 'string' ? m.trim().toLowerCase() : '';
        if (!WORD.test(word)) { problems.push('A way of paying must be a short word (letters, numbers, spaces); one was left out.'); continue; }
        if (!methods.includes(word) && methods.length < 12) methods.push(word);
      }
      if (methods.length) settings.paymentMethods = methods;
    }
    if (Object.keys(settings).length) out.settings = settings;
  }

  const pack = industryPack(industry ?? 'retail');
  if (isObject(root.vocabulary)) {
    const vocabulary = {};
    for (const [term, value] of Object.entries(root.vocabulary)) {
      const pair = Array.isArray(value) ? value.map((x) => (typeof x === 'string' ? clean(x, 30) : null)) : [];
      if (pair.length !== 2 || pair[0] === null || pair[1] === null) { problems.push(`The word for "${term}" needs a one and a many (two short words); it was left out.`); continue; }
      if (pack && !Object.hasOwn(pack.vocabulary ?? {}, term)) { problems.push(`"${term}" is not a word this kind of business uses; it was left out.`); continue; }
      vocabulary[term] = pair;
    }
    if (Object.keys(vocabulary).length) out.vocabulary = vocabulary;
  }
  if (isObject(root.features)) {
    const features = {};
    for (const [name, value] of Object.entries(root.features)) {
      if (!FEATURES.includes(name) || typeof value !== 'boolean') { problems.push(`"${name}" is not a part of the program that can be switched on or off; it was left out.`); continue; }
      features[name] = value;
    }
    if (Object.keys(features).length) out.features = features;
  }

  if (isObject(root.starter)) {
    const itemKinds = new Set((pack?.itemKinds ?? []).map((k) => k.id));
    const partyKinds = new Set((pack?.partyKinds ?? []).map((k) => k.id));
    const starter = {};
    if (Array.isArray(root.starter.items)) {
      const items = [];
      let skipped = 0;
      for (const e of root.starter.items) {
        if (items.length >= MAX_STARTER) { skipped += 1; continue; }
        const name = clean(text(e, 'name'), 80);
        const raw = isObject(e) && 'price' in e ? (typeof e.price === 'number' ? String(e.price) : typeof e.price === 'string' ? e.price.trim() : null) : null;
        if (name === null || raw === null || !PRICE.test(raw)) { skipped += 1; continue; }
        const given = text(e, 'kind');
        let kind = given === null ? 'stock' : given.trim();
        if (itemKinds.size > 0 && !itemKinds.has(kind)) kind = itemKinds.has('stock') ? 'stock' : [...itemKinds][0];
        const item = { name, price: raw, kind, taxClass: clean(text(e, 'taxClass'), 20) ?? 'standard' };
        for (const [field, max] of [['barcode', 40], ['unit', 10], ['category', 40]]) { const v = clean(text(e, field), max); if (v) item[field] = v; }
        items.push(item);
      }
      if (skipped > 0) problems.push(`${skipped} starter item(s) were left out (a name and a price like 125.50 are needed, and at most ${MAX_STARTER}).`);
      if (items.length) starter.items = items;
    }
    if (Array.isArray(root.starter.people)) {
      const people = [];
      let skipped = 0;
      for (const e of root.starter.people) {
        if (people.length >= MAX_STARTER) { skipped += 1; continue; }
        const name = clean(text(e, 'name'), 80);
        const given = text(e, 'kind');
        const kind = given === null ? 'customer' : given.trim();
        if (name === null || (partyKinds.size > 0 && !partyKinds.has(kind))) { skipped += 1; continue; }
        const person = { kind, name };
        for (const [field, max] of [['phone', 30], ['email', 120]]) { const v = clean(text(e, field), max); if (v) person[field] = v; }
        people.push(person);
      }
      if (skipped > 0) problems.push(`${skipped} starter person(s) were left out (a name and a kind this business uses are needed).`);
      if (people.length) starter.people = people;
    }
    if (Object.keys(starter).length) out.starter = starter;
  }
  if (typeof root.notes === 'string') { const n = clean(root.notes, 2000); if (n) out.notes = n; }
  return { value: out, problems };
}

// ---- the look: theme.json -----------------------------------------------------------------------------------------------------------------

export const THEME = {
  density: ['compact', 'comfortable', 'touch'], nav: ['left', 'top', 'bottom'], navLabels: ['full', 'icons'], cart: ['right', 'left', 'bottom'],
  mode: ['auto', 'light', 'dark'], surface: ['neutral', 'warm', 'cool', 'paper'], shape: ['square', 'soft', 'rounded', 'pill'], font: ['system', 'humanist', 'serif', 'rounded', 'mono'], depth: ['flat', 'soft', 'lifted'],
};
/** The looks of the shop program (the Hub's ShopLooks): a named bundle of the layout choices. A profile may name one in theme.json ("look"); the owner can still choose another. */
export const LOOKS = ['top', 'list', 'counter', 'auto', 'standard'];
export const THEME_DEFAULTS = { mode: 'auto', surface: 'neutral', shape: 'rounded', density: 'comfortable', font: 'system', fontScale: 1, nav: 'left', navLabels: 'full', cart: 'right', depth: 'soft' };
/** The choices about the device (screen and layout), which every licence lets through; the others are the brand's identity and need a "theme" or "full" licence. */
export const DEVICE_TOKENS = ['density', 'nav', 'navLabels', 'cart', 'fontScale'];
export const IDENTITY_TOKENS = ['mode', 'surface', 'shape', 'font', 'depth'];

/** A font scale inside 0.85 to 1.35, rounded to the nearest 0.05 (half up); otherwise null. */
export function scale(value) {
  if (typeof value !== 'number' || !Number.isFinite(value) || value < 0.85 || value > 1.35) return null;
  return Math.floor(value * 20 + 0.5) / 20;
}

/** The theme to show for a licence level: the defaults, then the profile, then the local choice, each token only when valid and when the level allows it. */
export function resolveTheme(level, profile, local) {
  const result = { ...THEME_DEFAULTS };
  const identity = level === 'theme' || level === 'full';
  for (const source of [profile, local]) {
    if (!isObject(source)) continue;
    for (const token of ['density', 'nav', 'navLabels', 'cart']) if (typeof source[token] === 'string' && THEME[token].includes(source[token])) result[token] = source[token];
    const s = scale(source.fontScale);
    if (s !== null) result.fontScale = s;
    if (!identity) continue;
    for (const token of IDENTITY_TOKENS) if (typeof source[token] === 'string' && THEME[token].includes(source[token])) result[token] = source[token];
  }
  return result;
}

/** Checks a theme file's contents. Returns { value, problems }: only valid tokens are kept; each wrong one is named in plain words. */
export function parseTheme(input) {
  const problems = [];
  let root = input;
  if (typeof input === 'string') { try { root = JSON.parse(input); } catch { return { value: {}, problems: ['The look file is not readable (it is not valid JSON).'] }; } }
  if (!isObject(root)) return { value: {}, problems: ['The look file is not a look.'] };
  const value = {};
  for (const [token, v] of Object.entries(root)) {
    if (token === 'fontScale') {
      const s = scale(v);
      if (s === null) problems.push('The letter size must be a number from 0.85 to 1.35; it was left out.');
      else value.fontScale = s;
    } else if (token === 'look') {
      if (typeof v === 'string' && LOOKS.includes(v)) value.look = v;
      else problems.push(`"look" must be one of: ${LOOKS.join(', ')}; it was left out.`);
    } else if (THEME[token]) {
      if (typeof v === 'string' && THEME[token].includes(v)) value[token] = v;
      else problems.push(`"${token}" must be one of: ${THEME[token].join(', ')}; it was left out.`);
    } else problems.push(`"${token}" is not a part of the look and is ignored.`);
  }
  return { value, problems };
}

// ---- the brand: brand.json ----------------------------------------------------------------------------------------------------------------

const HEX = /^#[0-9a-fA-F]{6}$/;
/** WCAG contrast of a "#rrggbb" colour with white (1 to 21). */
export function contrastWithWhite(hex) {
  const channel = (from) => { const c = parseInt(hex.slice(from, from + 2), 16) / 255; return c <= 0.04045 ? c / 12.92 : ((c + 0.055) / 1.055) ** 2.4; };
  return 1.05 / (0.2126 * channel(1) + 0.7152 * channel(3) + 0.0722 * channel(5) + 0.05);
}
export const usableColour = (v) => (typeof v === 'string' && HEX.test(v) && contrastWithWhite(v) >= 3 ? v.toLowerCase() : null);

/** The values of profile/brand.json (the Hub's LocalBrand). The logo is a small PNG or JPEG as a data address. */
export function parseBrand(input) {
  const problems = [];
  let root = input;
  if (typeof input === 'string') { try { root = JSON.parse(input); } catch { return { value: {}, problems: ['The brand file is not readable (it is not valid JSON).'] }; } }
  if (!isObject(root)) return { value: {}, problems: ['The brand file is not a brand.'] };
  const value = {};
  for (const [field, label] of [['primaryColor', 'main colour'], ['accentColor', 'second colour']]) {
    if (root[field] === undefined || root[field] === '') continue;
    const c = usableColour(root[field]);
    if (c) value[field] = c;
    else problems.push(typeof root[field] === 'string' && HEX.test(root[field]) ? `The ${label} is too light to read white words on. Choose a darker colour.` : `The ${label} must look like #0f6cbd (a # and six letters or numbers).`);
  }
  for (const [field, max, label] of [['name', 60, 'name'], ['shortName', 60, 'short name'], ['supportEmail', 120, 'support email'], ['supportPhone', 40, 'support phone']]) {
    if (root[field] === undefined || root[field] === '') continue;
    const t = clean(typeof root[field] === 'string' ? root[field] : '', 500);
    if (t === null || t.length > max) problems.push(`The ${label} can have at most ${max} letters.`);
    else value[field] = t;
  }
  if (typeof root.poweredBy === 'boolean') value.poweredBy = root.poweredBy;
  if (root.logo !== undefined && root.logo !== '') {
    const problem = logoProblem(root.logo);
    if (problem) problems.push(problem); else value.logo = root.logo;
  }
  for (const name of Object.keys(root)) if (!['name', 'shortName', 'primaryColor', 'accentColor', 'logo', 'supportEmail', 'supportPhone', 'poweredBy'].includes(name)) problems.push(`"${name}" is not a part of a brand and is ignored.`);
  return { value, problems };
}

/** A logo for the Hub must be a real PNG or JPEG picture (the first bytes say so) of at most 100 KB. Returns a problem in words, or null. */
export function logoProblem(uri) {
  const problem = 'The logo must be a PNG or JPEG picture of at most 100 KB.';
  const m = typeof uri === 'string' ? /^data:image\/(png|jpeg);base64,([A-Za-z0-9+/=]+)$/.exec(uri) : null;
  if (!m || uri.length > 140_000) return problem;
  const bytes = Buffer.from(m[2], 'base64');
  if (bytes.length > 100_000) return problem;
  const png = bytes.length > 8 && bytes[0] === 0x89 && bytes[1] === 0x50 && bytes[2] === 0x4e && bytes[3] === 0x47;
  const jpeg = bytes.length > 3 && bytes[0] === 0xff && bytes[1] === 0xd8 && bytes[2] === 0xff;
  return (m[1] === 'png' && png) || (m[1] === 'jpeg' && jpeg) ? null : problem;
}
