// The customer's public settings: what a customer's website needs to know about its shop (name, address, country, kind of business, place, and the public keys of its own
// online accounts), and the rules that say what a good value looks like. ONE file, used by every program that reads or writes them:
//   - scripts/make-website-package.mjs   (the release's own build: the generic website, and the website made for one customer)
//   - the Setup Studio                   (tools/setup-studio/lib/public-settings.mjs: it puts the customer's details beside the finished website, on the staff PC)
//   - the website's own start-up         (apps/storefront-web-mobile/src/lib/runtime-settings/public-settings.mjs, and "public-settings.mjs" in the website package: the launcher)
// A copy that travels with a program is this file, unchanged (a test checks it). It imports nothing, so that it runs everywhere the same way.
//
// WHERE THE VALUES LIVE. Not in the program: a website is built once, the same for every customer, and the customer's own values are DATA that the website reads when it starts,
// from the folder "customer" that sits beside the program:
//     customer/public-settings.json   { "schema": 1, "customer": "luzon-fresh-mart", "settings": { "NEXT_PUBLIC_SITE_NAME": "Luzon Fresh Mart", ... } }
//     customer/brand.json             optional: the customer's brand kit (the file the Brand Studio and the Setup Studio write): name, colours, contact
//     customer/logo.png               optional: the customer's logo, a PNG
// The names of the settings are the ones the website has always had (NEXT_PUBLIC_SITE_NAME ...) and the ones the Setup Studio writes as website-settings.env: nothing was renamed.
// Passwords, keys and the database address are NOT public settings and never go in this folder: they belong in private-settings.env on the computer that runs the website.

export const CUSTOMER_FOLDER = 'customer';
export const SETTINGS_FILE = 'public-settings.json';
export const BRAND_FILE = 'brand.json';
export const LOGO_FILE = 'logo.png';
/** The most each file may hold (bytes): a customer's details are small. */
export const MAX_SETTINGS_BYTES = 32 * 1024;
export const MAX_BRAND_BYTES = 64 * 1024;
export const MAX_LOGO_BYTES = 3 * 1024 * 1024;
/** The name the website that is the same for every customer carries. It cannot be a customer's short name. */
export const GENERIC_NAME = 'generic';

/**
 * The customer's short name, as it is used in file names: 2 to 41 small letters, digits and hyphens (the same form as the Setup Studio's customer names and the brand kits').
 * Returns the problem in plain words, or null when it is fine.
 */
export function shortNameProblem(id) {
  const text = String(id ?? '');
  if (!/^[a-z0-9][a-z0-9-]{0,39}[a-z0-9]$/.test(text)) return `"${text.replace(/[^\x20-\x7e]/g, '?').slice(0, 60)}" cannot be used as the customer's short name. Use 2 to 41 small letters, digits and hyphens, for example luzon-fresh-mart.`;
  if (text === GENERIC_NAME) return `"${GENERIC_NAME}" is the name of the website that is the same for every customer, so it cannot be a customer's short name. Choose another.`;
  return null;
}

// ---------------------------------------------------------------------------------------------------------------------
// The settings and what a good value looks like
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
 * The public settings the website knows. Anything else is refused: a private setting (database address, password, key) belongs in private-settings.env on the computer that
 * runs the website, never in the package and never in the customer folder. Each check returns a few words that finish the sentence "<NAME> ...", or null.
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
        const b64 = m[1].replace(/-/g, '+').replace(/_/g, '/');
        const role = JSON.parse(new TextDecoder().decode(Uint8Array.from(atob(b64.padEnd(b64.length + ((4 - (b64.length % 4)) % 4), '=')), (c) => c.charCodeAt(0)))).role;
        return role === 'anon' ? null : 'is not the public (anon) key: a key with another role is never put in a website';
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
export const SETTING_NAMES = Object.keys(PUBLIC_SETTINGS);

/**
 * Checks a set of values ({ NAME: 'value' }). Returns { values, problems }: `values` holds the good, non-empty ones as text; every problem is a sentence a person can act on.
 *   countries, industries   the packs that exist (a website for a country with no pack would silently use the wrong money and dates); null skips the check
 *   requireName             the shop's name must be there
 *   findSecrets             (text) => [kind, ...]: a value that looks like a secret key is refused (the release's package check refuses any value that looks like one)
 */
export function checkSettings(input, { countries = null, industries = null, requireName = true, findSecrets = null } = {}) {
  const values = {};
  const problems = [];
  if (!input || typeof input !== 'object' || Array.isArray(input)) return { values, problems: ['The settings are not a list of names and values.'] };
  for (const [key, raw] of Object.entries(input)) {
    const rule = Object.hasOwn(PUBLIC_SETTINGS, key) ? PUBLIC_SETTINGS[key] : null;
    if (!rule) {
      problems.push(key.startsWith('NEXT_PUBLIC_') ? `${key} is not a setting this website knows.` : `${key} is not a public setting. Passwords, keys and the database address never go into the website package: they go in private-settings.env on the computer that runs the website.`);
      continue;
    }
    if (typeof raw !== 'string') { problems.push(`${key} must be written as text.`); continue; }
    const value = raw.trim();
    const why = value === '' && !rule.required ? null : rule.check(value);
    if (why) { problems.push(`${key} ${why}.`); continue; }
    const secret = findSecrets ? findSecrets(value) : [];
    if (secret.length) { problems.push(`${key} looks like a secret key (${secret.join(', ')}). The package check refuses any value that looks like a key, so it cannot be put in a website.`); continue; }
    if (value !== '') values[key] = value;
  }
  if (requireName) for (const [key, rule] of Object.entries(PUBLIC_SETTINGS)) if (rule.required && !values[key] && !problems.some((p) => p.startsWith(`${key} `))) problems.push(`${key} is missing: the website needs the shop's name.`);
  if (values.NEXT_PUBLIC_COUNTRY && countries && !countries.includes(values.NEXT_PUBLIC_COUNTRY)) problems.push(`NEXT_PUBLIC_COUNTRY: there is no country pack for ${values.NEXT_PUBLIC_COUNTRY} (the packs are: ${countries.join(', ')}).`);
  if (values.NEXT_PUBLIC_INDUSTRY && industries && !industries.includes(values.NEXT_PUBLIC_INDUSTRY)) problems.push(`NEXT_PUBLIC_INDUSTRY: there is no industry pack called ${values.NEXT_PUBLIC_INDUSTRY} (the packs are: ${industries.join(', ')}).`);
  return { values, problems };
}

// ---------------------------------------------------------------------------------------------------------------------
// The brand: the few things of a brand kit the website shows
// ---------------------------------------------------------------------------------------------------------------------

const HEX = /^#[0-9a-fA-F]{6}$/;
const clean = (t) => typeof t === 'string' && ![...t].some((c) => c.charCodeAt(0) < 32 || (c.charCodeAt(0) >= 127 && c.charCodeAt(0) <= 159));

/** WCAG contrast ratio of a "#rrggbb" colour with white (the same rule as the Brand Studio's). */
export function contrastWithWhite(hex) {
  const channel = (from) => { const c = parseInt(hex.slice(from, from + 2), 16) / 255; return c <= 0.04045 ? c / 12.92 : Math.pow((c + 0.055) / 1.055, 2.4); };
  return 1.05 / (0.2126 * channel(1) + 0.7152 * channel(3) + 0.0722 * channel(5) + 0.05);
}

/**
 * What the website takes from a brand kit (brand.json, in the form the Brand Studio and the Setup Studio write): the name, the tagline, the two colours and the contact details.
 * The rest of the kit (the app's id, the bill's words, ...) is for other programs and is left alone here. Returns { brand, problems }; brand is null when there is none.
 */
export function siteBrand(kit) {
  const problems = [];
  if (kit === undefined || kit === null) return { brand: null, problems };
  if (typeof kit !== 'object' || Array.isArray(kit)) return { brand: null, problems: ['brand.json is not a brand kit.'] };
  if (kit.schema !== 1) problems.push('brand.json must say "schema": 1.');
  const brand = {};
  if (kit.name !== undefined) {
    if (typeof kit.name !== 'string' || !kit.name.trim() || kit.name.length > 60 || !clean(kit.name) || /[<>]/.test(kit.name)) problems.push('brand.json: the business\'s name must be 1 to 60 letters (no < or >).');
    else brand.name = kit.name.trim();
  }
  if (kit.tagline !== undefined) {
    if (typeof kit.tagline !== 'string' || kit.tagline.length > 120 || !clean(kit.tagline) || /[<>]/.test(kit.tagline)) problems.push('brand.json: the tagline can have at most 120 letters (no < or >).');
    else if (kit.tagline.trim()) brand.tagline = kit.tagline.trim();
  }
  if (kit.primaryColor !== undefined) {
    if (typeof kit.primaryColor !== 'string' || !HEX.test(kit.primaryColor)) problems.push('brand.json: the main colour must look like #0f6cbd (a # and six letters or numbers).');
    else if (contrastWithWhite(kit.primaryColor) < 3) problems.push(`brand.json: the main colour (${kit.primaryColor}) is too light to read white words on. Choose a darker colour.`);
    else brand.primaryColor = kit.primaryColor.toLowerCase();
  }
  if (kit.accentColor !== undefined) {
    if (typeof kit.accentColor !== 'string' || !HEX.test(kit.accentColor)) problems.push('brand.json: the second colour must look like #0f6cbd (a # and six letters or numbers).');
    else brand.accentColor = kit.accentColor.toLowerCase();
  }
  const c = kit.contact;
  if (c !== undefined) {
    if (!c || typeof c !== 'object' || Array.isArray(c)) problems.push('brand.json: "contact" must hold email, phone and address.');
    else {
      const contact = {};
      if (c.email) { if (typeof c.email !== 'string' || !/^[^\s@<>]+@[^\s@<>]+\.[^\s@<>]+$/.test(c.email) || c.email.length > 120) problems.push('brand.json: the contact email does not look like an email address.'); else contact.email = c.email; }
      if (c.phone) { if (typeof c.phone !== 'string' || !/^[0-9 +().-]{5,25}$/.test(c.phone)) problems.push('brand.json: the contact phone can only have numbers, spaces and + - ( ).'); else contact.phone = c.phone; }
      if (c.address) { if (typeof c.address !== 'string' || c.address.length > 200 || !clean(c.address) || /[<>]/.test(c.address)) problems.push('brand.json: the address can have at most 200 letters (no < or >).'); else contact.address = c.address; }
      if (Object.keys(contact).length) brand.contact = contact;
    }
  }
  return { brand: Object.keys(brand).length ? brand : null, problems };
}

/** Whether bytes are a real PNG picture of a sensible size, in plain words (null when fine). The website refers to its logo as /logo.png. */
export function logoProblem(bytes) {
  const png = [0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a];
  if (!bytes || bytes.length < 8 || png.some((b, i) => bytes[i] !== b)) return 'logo.png is not a PNG picture. The website\'s logo must be a PNG.';
  if (bytes.length > MAX_LOGO_BYTES) return 'logo.png is bigger than 3 MB. Use a smaller logo.';
  return null;
}

// ---------------------------------------------------------------------------------------------------------------------
// The customer folder
// ---------------------------------------------------------------------------------------------------------------------

/** The text of customer/public-settings.json for a customer (the one way it is written). */
export function settingsFileText(customer, values) {
  const settings = {};
  for (const key of SETTING_NAMES) if (values[key] !== undefined && values[key] !== '') settings[key] = values[key];
  return JSON.stringify({ schema: 1, customer: customer ?? null, settings }, null, 2) + '\n';
}

/**
 * Reads and checks public-settings.json (its text). Returns { ok, problems, customer, values }. A file the program does not understand, a setting it does not know and a value
 * that is not good are all refused in plain words: nothing is half-used.
 */
export function parseSettingsFile(text, options = {}) {
  const fail = (m) => ({ ok: false, problems: [m], customer: null, values: {} });
  if (typeof text !== 'string' || new TextEncoder().encode(text).length > MAX_SETTINGS_BYTES) return fail(`${SETTINGS_FILE} is missing or far bigger than a shop's details should be.`);
  let file;
  try { file = JSON.parse(text.replace(/^﻿/, '')); } catch { return fail(`${SETTINGS_FILE} cannot be read: it is not valid JSON. Make it again with the Setup Studio.`); }
  if (!file || typeof file !== 'object' || Array.isArray(file)) return fail(`${SETTINGS_FILE} is not a list of settings.`);
  if (file.schema !== 1) return fail(`${SETTINGS_FILE} is not in a form this website understands (schema ${JSON.stringify(file.schema)}). Update the website, or make the file again with the Setup Studio.`);
  const extra = Object.keys(file).filter((k) => !['schema', 'customer', 'settings'].includes(k));
  const problems = extra.length ? [`${SETTINGS_FILE} holds something this website does not know: ${extra.slice(0, 3).join(', ')}.`] : [];
  let customer = null;
  if (file.customer !== undefined && file.customer !== null) {
    const why = typeof file.customer === 'string' ? shortNameProblem(file.customer) : 'The customer\'s short name must be written as text.';
    if (why) problems.push(`${SETTINGS_FILE}: ${why}`); else customer = file.customer;
  }
  const checked = checkSettings(file.settings, options);
  problems.push(...checked.problems);
  return { ok: problems.length === 0, problems, customer, values: checked.values };
}

/**
 * Looks at a customer folder as a program would when it starts. `read(name)` gives the file's bytes (a Buffer or any Uint8Array), or null when there is no such file (and may throw: that is read as
 * "cannot be read"). Returns { ok, problems, customer, values, brand, hasLogo }.
 */
export function readCustomerFolder(read, options = {}) {
  const get = (name) => { try { return read(name); } catch { return undefined; } };
  const out = { ok: false, problems: [], customer: null, values: {}, brand: null, hasLogo: false };
  const settings = get(SETTINGS_FILE);
  if (settings === undefined) { out.problems.push(`${SETTINGS_FILE} in the folder "${CUSTOMER_FOLDER}" cannot be read.`); return out; }
  if (settings === null) {
    out.problems.push(`This website has no shop details yet: the file ${SETTINGS_FILE} is not in its folder "${CUSTOMER_FOLDER}". The website program is the same for every customer; the NextGenOS Setup Studio puts a customer's name, address and look into that folder. Open the website that the Setup Studio made for this customer.`);
    return out;
  }
  const parsed = parseSettingsFile(new TextDecoder().decode(settings), options);
  out.problems.push(...parsed.problems);
  out.customer = parsed.customer;
  out.values = parsed.values;
  const brandBytes = get(BRAND_FILE);
  if (brandBytes === undefined) out.problems.push(`${BRAND_FILE} in the folder "${CUSTOMER_FOLDER}" cannot be read.`);
  else if (brandBytes !== null) {
    if (brandBytes.length > MAX_BRAND_BYTES) out.problems.push(`${BRAND_FILE} is far bigger than a brand kit should be.`);
    else {
      let kit = null;
      try { kit = JSON.parse(brandBytes.toString('utf8').replace(/^﻿/, '')); } catch { out.problems.push(`${BRAND_FILE} cannot be read: it is not valid JSON.`); }
      if (kit !== null) { const b = siteBrand(kit); out.brand = b.brand; out.problems.push(...b.problems); }
    }
  }
  const logo = get(LOGO_FILE);
  if (logo === undefined) out.problems.push(`${LOGO_FILE} in the folder "${CUSTOMER_FOLDER}" cannot be read.`);
  else if (logo !== null) { const why = logoProblem(logo); if (why) out.problems.push(why); else out.hasLogo = true; }
  out.ok = out.problems.length === 0;
  return out;
}
