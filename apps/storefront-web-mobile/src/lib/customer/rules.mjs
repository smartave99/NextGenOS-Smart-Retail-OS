// The customer's settings for the website: what may be in the customer folder, how each value is checked, and how the folder is read.
//
// ONE file, used by three places, so the checks cannot drift apart:
//   - the running website (src/lib/customer/settings.ts) reads the customer folder with it when it starts;
//   - the package maker (scripts/make-website-package.mjs) checks a customer's settings with it before anything is made;
//   - the "assemble" step (tools/setup-studio/lib/website-assemble.mjs) loads the copy that travels inside the finished website package
//     (customer-rules.mjs, the same file, unchanged: a test checks it) and checks a customer folder with it before it is put beside the program.
//
// Plain JavaScript on purpose (no TypeScript, no import of anything outside Node.js), so that it can travel with the program and run on a staff computer
// that holds no source code. It reads files only through the `fs` and `path` it is given.
//
// The customer folder (everything optional; nothing in it is a secret):
//   brand.json             the brand kit's file (name, tagline, colours, contact, country, language, kind of business, web address, logo)
//   setup.json             the shop program's setup file (business.name, business.country, business.industry): the same folder can serve the shop program too
//   website-settings.env   the public settings of the website (NEXT_PUBLIC_*), exactly as the Setup Studio writes them; they win over brand.json
//   theme.json             the look of the shop program; the website does not use it yet (it is allowed, and left alone)
//   assets/                public pictures: the logo (png, jpg, webp or svg) and a favicon
// With nothing there, the result is NEUTRAL: no name, no country, no currency, no company (CLAUDE.md, section 8).

/** What the website shows when nothing is set. No market, no company, no currency. */
export const NEUTRAL_SETTINGS = Object.freeze({
  siteName: '',
  shortName: '',
  tagline: '',
  siteUrl: '',
  country: '',
  regionCode: '',
  industry: '',
  shopPlace: '',
  language: '',
  primaryColor: '',
  accentColor: '',
  contact: Object.freeze({ email: '', phone: '', address: '' }),
  logoUrl: '',
  supabase: Object.freeze({ url: '', key: '' }),
  firebase: Object.freeze({ apiKey: '', authDomain: '', projectId: '', storageBucket: '', messagingSenderId: '', appId: '' }),
  cloudinary: Object.freeze({ cloudName: '', apiKey: '' }),
});

// ---------------------------------------------------------------------------------------------------------------------
// The checks of one value
// ---------------------------------------------------------------------------------------------------------------------

const plain = (max) => (v) => (v.length > max ? `is longer than ${max} letters` : /[<>\u0000-\u001f\u007f]/.test(v) ? 'has a character that is not allowed (< > or a control character)' : null);
const webAddress = (secure) => (v) => {
  let u;
  try { u = new URL(v); } catch { return 'is not a web address (write it like https://shop.example.com)'; }
  if (u.protocol !== 'https:' && !(u.protocol === 'http:' && !secure)) return secure ? 'must start with https://' : 'must start with http:// or https://';
  if (u.username || u.password) return 'must not hold a user name or a password';
  if (u.search || u.hash) return 'must not have a ? or a # part';
  return v.length > 200 ? 'is too long' : null;
};
const pattern = (re, example) => (v) => (re.test(v) ? null : `is not in the form ${example}`);

/**
 * The public settings the website knows, by the name the Setup Studio writes them under (website-settings.env). Anything else is refused: a private setting
 * (database address, password, key) belongs in private-settings.env on the computer that runs the website, never in the package or the customer folder.
 */
export const PUBLIC_SETTINGS = {
  NEXT_PUBLIC_SITE_NAME: { required: true, check: (v) => (v ? plain(80)(v) : 'is empty') },
  NEXT_PUBLIC_SITE_URL: { check: webAddress(false) },
  NEXT_PUBLIC_COUNTRY: { check: pattern(/^[A-Z]{2}$/, 'two capital letters, such as PH') },
  NEXT_PUBLIC_REGION_CODE: { check: pattern(/^[A-Z]{2}$/, 'two capital letters, such as PH') },
  NEXT_PUBLIC_INDUSTRY: { check: pattern(/^[a-z][a-z-]{1,30}$/, 'small letters, such as retail') },
  NEXT_PUBLIC_SHOP_PLACE: { check: plain(120) },
  NEXT_PUBLIC_SUPABASE_URL: { check: webAddress(true) },
  NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY: { check: (v) => (/^sb_publishable_[A-Za-z0-9_-]{10,}$/.test(v) ? null : 'must be the publishable key (sb_publishable_...). A secret key is never put in a website') },
  NEXT_PUBLIC_SUPABASE_ANON_KEY: {
    check: (v) => {
      const m = /^eyJ[\w-]+\.([\w-]+)\.[\w-]+$/.exec(v);
      if (!m) return 'is not a public (anon) key';
      try {
        const base64 = m[1].replace(/-/g, '+').replace(/_/g, '/');
        return JSON.parse(atob(base64.padEnd(base64.length + ((4 - (base64.length % 4)) % 4), '='))).role === 'anon' ? null : 'is not the public (anon) key: a key with another role is never put in a website';
      } catch { return 'is not a public (anon) key'; }
    },
  },
  NEXT_PUBLIC_FIREBASE_API_KEY: { check: pattern(/^[A-Za-z0-9_-]{20,60}$/, 'the web API key from the Firebase console') },
  NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN: { check: pattern(/^[a-z0-9.-]{4,100}$/, 'a host name') },
  NEXT_PUBLIC_FIREBASE_PROJECT_ID: { check: pattern(/^[a-z0-9-]{4,40}$/, 'a project id') },
  NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET: { check: pattern(/^[a-z0-9._-]{4,100}$/, 'a bucket name') },
  NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID: { check: pattern(/^\d{4,20}$/, 'a number') },
  NEXT_PUBLIC_FIREBASE_APP_ID: { check: pattern(/^\d+:\d+:web:[a-f0-9]+$/, '1:123:web:abc') },
  NEXT_PUBLIC_CLOUDINARY_CLOUD_NAME: { check: pattern(/^[A-Za-z0-9_-]{2,60}$/, 'a cloud name') },
  NEXT_PUBLIC_CLOUDINARY_API_KEY: { check: pattern(/^\d{6,20}$/, 'a number') },
};

/**
 * Reads the text of a settings file (KEY=value lines, # comments, CRLF or LF, a value may be in quotes).
 * Returns { values, problems }: every problem is a sentence a person can act on; nothing is made or shown while there is one.
 * `findSecrets(text)` (optional) names the kinds of secret a value seems to hold; the package maker passes the release gate's own scan, so a value that looks like a key is refused.
 */
export function parseSettings(text, { countries = null, industries = null, requireName = true, findSecrets = () => [] } = {}) {
  const values = {};
  const problems = [];
  String(text ?? '').split(/\r?\n/).forEach((raw, i) => {
    const line = raw.replace(/^﻿/, '').trim();
    if (!line || line.startsWith('#')) return;
    const at = `Line ${i + 1}`;
    const m = /^([A-Za-z_][A-Za-z0-9_]*)\s*=\s*(.*)$/.exec(line);
    if (!m) { problems.push(`${at} is not a setting. Write one setting per line, like NEXT_PUBLIC_SITE_NAME=My Shop.`); return; }
    const key = m[1];
    let value = m[2].trim();
    if (/^(".*"|'.*')$/.test(value) && value.length >= 2) value = value.slice(1, -1);
    if (!key.startsWith('NEXT_PUBLIC_')) {
      problems.push(`${at}: ${key} is not a public setting. Passwords, keys and the database address never go into the website package: they go in private-settings.env on the computer that runs the website.`);
      return;
    }
    const rule = PUBLIC_SETTINGS[key];
    if (!rule) { problems.push(`${at}: ${key} is not a setting this website knows.`); return; }
    if (key in values) { problems.push(`${at}: ${key} is written twice.`); return; }
    const why = value === '' && !rule.required ? null : rule.check(value);
    if (why) { problems.push(`${at}: ${key} ${why}.`); return; }
    const secret = findSecrets(value);
    if (secret.length) {
      problems.push(`${at}: ${key} looks like a secret key (${secret.join(', ')}). The package check refuses any value that looks like a key, so it cannot be put in a website.`);
      return;
    }
    if (value !== '') values[key] = value;
  });
  if (requireName) for (const [key, rule] of Object.entries(PUBLIC_SETTINGS)) if (rule.required && !values[key]) problems.push(`${key} is missing: the website needs the shop's name.`);
  if (values.NEXT_PUBLIC_COUNTRY && countries && !countries.includes(values.NEXT_PUBLIC_COUNTRY)) problems.push(`NEXT_PUBLIC_COUNTRY: there is no country pack for ${values.NEXT_PUBLIC_COUNTRY} (the packs are: ${countries.join(', ')}).`);
  if (values.NEXT_PUBLIC_INDUSTRY && industries && !industries.includes(values.NEXT_PUBLIC_INDUSTRY)) problems.push(`NEXT_PUBLIC_INDUSTRY: there is no industry pack called ${values.NEXT_PUBLIC_INDUSTRY} (the packs are: ${industries.join(', ')}).`);
  return { values, problems };
}

/** The settings of website-settings.env (NEXT_PUBLIC_* names) as the website's own fields. */
export function layerFromEnvValues(values) {
  const v = (k) => values[k] ?? '';
  const layer = {
    siteName: v('NEXT_PUBLIC_SITE_NAME'), siteUrl: v('NEXT_PUBLIC_SITE_URL').replace(/\/+$/, ''), country: v('NEXT_PUBLIC_COUNTRY'), regionCode: v('NEXT_PUBLIC_REGION_CODE'),
    industry: v('NEXT_PUBLIC_INDUSTRY'), shopPlace: v('NEXT_PUBLIC_SHOP_PLACE'),
    supabase: { url: v('NEXT_PUBLIC_SUPABASE_URL'), key: v('NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY') || v('NEXT_PUBLIC_SUPABASE_ANON_KEY') },
    firebase: {
      apiKey: v('NEXT_PUBLIC_FIREBASE_API_KEY'), authDomain: v('NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN'), projectId: v('NEXT_PUBLIC_FIREBASE_PROJECT_ID'),
      storageBucket: v('NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET'), messagingSenderId: v('NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID'), appId: v('NEXT_PUBLIC_FIREBASE_APP_ID'),
    },
    cloudinary: { cloudName: v('NEXT_PUBLIC_CLOUDINARY_CLOUD_NAME'), apiKey: v('NEXT_PUBLIC_CLOUDINARY_API_KEY') },
  };
  return layer;
}

// ---------------------------------------------------------------------------------------------------------------------
// brand.json and setup.json
// ---------------------------------------------------------------------------------------------------------------------

const HEX = /^#[0-9a-fA-F]{6}$/;
/** WCAG contrast of a "#rrggbb" colour with white (1 to 21): the same rule as the Brand Studio's and the licence's (a colour white words can be read on). */
export function contrastWithWhite(hex) {
  const channel = (from) => { const c = parseInt(hex.slice(from, from + 2), 16) / 255; return c <= 0.04045 ? c / 12.92 : ((c + 0.055) / 1.055) ** 2.4; };
  return 1.05 / (0.2126 * channel(1) + 0.7152 * channel(3) + 0.0722 * channel(5) + 0.05);
}
const usableColour = (v) => (typeof v === 'string' && HEX.test(v) && contrastWithWhite(v) >= 3 ? v.toLowerCase() : null);

const LOGO_NAME = /^[A-Za-z0-9][A-Za-z0-9._-]{0,80}\.(png|jpe?g|webp|svg)$/i;
/** A file name for a public picture of the customer: a plain name, one of a few picture types. */
export const isPictureName = (name) => typeof name === 'string' && LOGO_NAME.test(name);

const isObject = (v) => v !== null && typeof v === 'object' && !Array.isArray(v);
function parseJson(text, what, problems) {
  if (text === null) return null;
  let root;
  try { root = JSON.parse(String(text).replace(/^﻿/, '')); } catch { problems.push(`${what} cannot be read (it is not valid JSON).`); return null; }
  if (!isObject(root)) { problems.push(`${what} is not a settings file (it must be an object).`); return null; }
  return root;
}

/**
 * Reads the text of a brand.json (the brand kit's file). Returns { layer, logoName, problems }: only valid values are kept; each wrong one is named in plain words.
 * `countries` and `industries` (lists of codes, optional) say which packs exist.
 */
export function parseBrand(text, { countries = null, industries = null } = {}) {
  const problems = [];
  const root = parseJson(text, 'brand.json', problems);
  const layer = {};
  let logoName = '';
  if (!root) return { layer, logoName, problems };
  const take = (value, check, label) => {
    if (value === undefined || value === null || value === '') return '';
    if (typeof value !== 'string') { problems.push(`brand.json: ${label} must be text.`); return ''; }
    const t = value.trim();
    const why = check(t);
    if (why) { problems.push(`brand.json: ${label} ${why}.`); return ''; }
    return t;
  };
  layer.siteName = take(root.name, plain(80), 'the name');
  layer.shortName = take(root.shortName, plain(60), 'the short name');
  layer.tagline = take(root.tagline, plain(160), 'the tagline');
  const colour = (v, label) => {
    if (v === undefined || v === null || v === '') return '';
    const c = usableColour(v);
    if (!c) problems.push(typeof v === 'string' && HEX.test(v) ? `brand.json: the ${label} is too light to read white words on. Choose a darker colour.` : `brand.json: the ${label} must look like #0f6cbd (a # and six letters or numbers).`);
    return c ?? '';
  };
  layer.primaryColor = colour(root.primaryColor, 'main colour');
  layer.accentColor = colour(root.accentColor, 'second colour');
  layer.country = take(root.country, pattern(/^[A-Z]{2}$/, 'two capital letters, such as PH'), 'the country');
  if (layer.country && countries && !countries.includes(layer.country)) { problems.push(`brand.json: there is no country pack for ${layer.country}; the country is left neutral.`); layer.country = ''; }
  layer.industry = take(root.industry, pattern(/^[a-z][a-z-]{1,30}$/, 'small letters, such as retail'), 'the kind of business');
  if (layer.industry && industries && !industries.includes(layer.industry)) { problems.push(`brand.json: there is no industry pack called ${layer.industry}; the kind of business is left neutral.`); layer.industry = ''; }
  layer.language = take(root.language, pattern(/^[a-z]{2,3}(-[A-Za-z0-9]{2,8}){0,2}$/, 'a language such as en or en-PH'), 'the language');
  if (isObject(root.contact)) {
    layer.contact = {
      email: take(root.contact.email, plain(120), 'the e-mail address'),
      phone: take(root.contact.phone, plain(40), 'the phone number'),
      address: take(root.contact.address, plain(200), 'the address'),
    };
    const place = layer.contact.address.split(',').slice(-2).join(',').trim();
    if (place) layer.shopPlace = place.slice(0, 120);
  }
  if (isObject(root.storefront)) layer.siteUrl = take(root.storefront.siteUrl, webAddress(false), 'the web address').replace(/\/+$/, '');
  if (typeof root.logo === 'string' && root.logo !== '') {
    if (isPictureName(root.logo)) logoName = root.logo;
    else problems.push('brand.json: the logo must be the name of a picture file (png, jpg, webp or svg) next to it, with no folder in the name; it is left out.');
  }
  return { layer, logoName, problems };
}

/** The part of a setup.json (the shop program's profile) that the website can use: the business's name, country and kind of business. */
export function parseSetup(text, { countries = null, industries = null } = {}) {
  const problems = [];
  const root = parseJson(text, 'setup.json', problems);
  const layer = {};
  const b = root && isObject(root.business) ? root.business : null;
  if (!b) return { layer, problems };
  if (typeof b.name === 'string' && b.name.trim()) {
    const why = plain(80)(b.name.trim());
    if (why) problems.push(`setup.json: the business name ${why}.`); else layer.siteName = b.name.trim();
  }
  if (typeof b.country === 'string' && b.country.trim()) {
    const c = b.country.trim().toUpperCase();
    if (!/^[A-Z]{2}$/.test(c) || (countries && !countries.includes(c))) problems.push(`setup.json: there is no country pack for "${b.country}"; the country is left neutral.`);
    else layer.country = c;
  }
  if (typeof b.industry === 'string' && b.industry.trim()) {
    const i = b.industry.trim().toLowerCase();
    if (!/^[a-z][a-z-]{1,30}$/.test(i) || (industries && !industries.includes(i))) problems.push(`setup.json: there is no kind of business called "${b.industry}"; it is left neutral.`);
    else layer.industry = i;
  }
  return { layer, problems };
}

// ---------------------------------------------------------------------------------------------------------------------
// Putting the layers together
// ---------------------------------------------------------------------------------------------------------------------

const cloneNeutral = () => JSON.parse(JSON.stringify(NEUTRAL_SETTINGS));

/** A layer's non-empty values over a base (groups such as contact and supabase are merged field by field). Returns the base. */
function overlay(base, layer) {
  for (const [key, value] of Object.entries(layer ?? {})) {
    if (isObject(value) && isObject(base[key])) { for (const [k, v] of Object.entries(value)) if (typeof v === 'string' && v !== '') base[key][k] = v; }
    else if (typeof value === 'string' && value !== '' && key in base) base[key] = value;
  }
  return base;
}

/** The first non-empty value wins, highest priority first: website-settings.env, brand.json, setup.json, then the developer's own environment (a fallback only). */
export function mergeLayers({ env = {}, brand = {}, setup = {}, fallback = {} } = {}) {
  const out = cloneNeutral();
  for (const layer of [fallback, setup, brand, env]) overlay(out, layer);
  return out;
}

/**
 * What a developer may set instead of a customer folder, for trying the website on their own computer: the NEXT_PUBLIC_* values of the computer's environment.
 * A production package never needs them. The values are checked by the same rules; the ones that fail are left out.
 */
export function fallbackFromEnvironment(environment, { countries = null, industries = null } = {}) {
  const text = Object.keys(PUBLIC_SETTINGS).filter((k) => typeof environment[k] === 'string' && environment[k].trim() !== '').map((k) => `${k}=${environment[k].trim()}`).join('\n');
  const parsed = parseSettings(text, { countries, industries, requireName: false });
  // A line that failed is dropped on its own: re-read each good line (a bad value must not take the good ones with it).
  const good = {};
  for (const line of text.split('\n')) {
    const one = parseSettings(line, { countries, industries, requireName: false });
    if (!one.problems.length) Object.assign(good, one.values);
  }
  return { layer: layerFromEnvValues(good), problems: parsed.problems };
}

// ---------------------------------------------------------------------------------------------------------------------
// Reading the folder
// ---------------------------------------------------------------------------------------------------------------------

/** The files the customer folder may hold at its top, and the sizes allowed (a bigger file is refused: nobody needs a 5 MB settings file). */
export const FOLDER_FILES = { 'brand.json': 262144, 'setup.json': 262144, 'theme.json': 262144, 'website-settings.env': 65536 };
export const MAX_PICTURE_BYTES = 3 * 1024 * 1024;
const PNG = [0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a];

/** Whether the bytes are a real picture of the kind the file name says (the first bytes say so). */
export function looksLikePicture(name, bytes) {
  const ext = /\.([a-z0-9]+)$/i.exec(name)?.[1]?.toLowerCase();
  if (!bytes || bytes.length < 8) return false;
  if (ext === 'png') return PNG.every((b, i) => bytes[i] === b);
  if (ext === 'jpg' || ext === 'jpeg') return bytes[0] === 0xff && bytes[1] === 0xd8 && bytes[2] === 0xff;
  if (ext === 'webp') return String.fromCharCode(...bytes.subarray(0, 4)) === 'RIFF' && String.fromCharCode(...bytes.subarray(8, 12)) === 'WEBP';
  if (ext === 'svg') { const head = new TextDecoder().decode(bytes.subarray(0, 512)).trimStart(); return /^(<\?xml|<svg|<!--|<!DOCTYPE svg)/i.test(head); }
  return false;
}

/**
 * Reads a customer folder with the `fs` and `path` it is given. Returns { settings, problems, found, logoFile }:
 *   settings   what the website uses (NEUTRAL where the folder says nothing)
 *   problems   plain sentences about what was wrong and left out; the rest still counts
 *   found      whether the folder exists
 *   logoFile   the logo's path inside the folder ('assets/logo.png'), or ''
 * It never throws for a bad file; a folder that cannot be read at all gives the neutral settings and a problem.
 */
export function readCustomerFolder(dir, { fs, path }, { countries = null, industries = null, environment = null } = {}) {
  const problems = [];
  const packs = { countries, industries };
  const fallback = environment ? fallbackFromEnvironment(environment, packs) : { layer: {}, problems: [] };
  let found = false;
  try { found = Boolean(dir) && fs.existsSync(dir) && fs.statSync(dir).isDirectory(); } catch { found = false; }
  if (!found) return { settings: mergeLayers({ fallback: fallback.layer }), problems: [], found: false, logoFile: '' };

  const readText = (name) => {
    const file = path.join(dir, name);
    try {
      if (!fs.existsSync(file)) return null;
      const s = fs.statSync(file);
      if (!s.isFile()) { problems.push(`${name} is not a file.`); return null; }
      if (s.size > FOLDER_FILES[name]) { problems.push(`${name} is too big (more than ${Math.round(FOLDER_FILES[name] / 1024)} KB) and is not used.`); return null; }
      return fs.readFileSync(file, 'utf8');
    } catch { problems.push(`${name} could not be read.`); return null; }
  };

  const envText = readText('website-settings.env');
  let env = {};
  if (envText !== null) {
    const parsed = parseSettings(envText, { ...packs, requireName: false });
    problems.push(...parsed.problems.map((p) => `website-settings.env: ${p}`));
    env = layerFromEnvValues(parsed.values);
  }
  const brand = parseBrand(readText('brand.json'), packs);
  problems.push(...brand.problems);
  const setup = parseSetup(readText('setup.json'), packs);
  problems.push(...setup.problems);

  // The logo: the file brand.json names, else assets/logo.*; found in assets/ (or next to brand.json, where the brand kit keeps it).
  let logoFile = '';
  const candidates = [];
  const named = brand.logoName;
  for (const name of named ? [named] : ['logo.png', 'logo.svg', 'logo.webp', 'logo.jpg', 'logo.jpeg']) for (const where of ['assets', '']) candidates.push(where ? `${where}/${name}` : name);
  for (const rel of candidates) {
    const file = path.join(dir, ...rel.split('/'));
    try {
      if (!fs.existsSync(file) || !fs.statSync(file).isFile()) continue;
      if (fs.statSync(file).size > MAX_PICTURE_BYTES) { problems.push(`The logo ${rel} is bigger than 3 MB and is not used.`); continue; }
      const bytes = fs.readFileSync(file);
      if (!looksLikePicture(rel, bytes)) { problems.push(`The logo ${rel} is not a real ${rel.split('.').pop().toUpperCase()} picture and is not used.`); continue; }
      logoFile = rel;
      break;
    } catch { /* an unreadable candidate is skipped */ }
  }
  if (named && !logoFile && !problems.some((p) => p.includes(named))) problems.push(`brand.json names the logo ${named}, but no such picture is in the folder (put it in assets/).`);
  const settings = mergeLayers({ env, brand: brand.layer, setup: setup.layer, fallback: fallback.layer });
  if (logoFile) settings.logoUrl = `/customer-assets/${logoFile.split('/').pop()}`;
  return { settings, problems: [...problems, ...fallback.problems.map((p) => `environment: ${p}`)], found: true, logoFile };
}
