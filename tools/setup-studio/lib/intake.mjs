// What staff write down about a customer (the "intake"), in plain words, and the checks on it. The intake is the one source: the proposal, the look, the installers
// and the hand-over papers are all made from it. Checks give every problem a place (the field) so a screen can show it next to the answer.
import { countryPack, industryPack, countries as allCountries } from './packs.mjs';
import { clean, usableColour } from './rules.mjs';
import { colourProblem } from '../../brand-studio/lib/kit.mjs';
import { checkImages, LIMITS as IMAGE_LIMITS, POSTER_KINDS, POSTER_KIND_LABELS } from './aiprofile.mjs';

export const SLUG = /^[a-z0-9][a-z0-9-]{1,40}$/;

/** The choices on the forms, with the words people see. One list, used by the screens, the checks and the proposal. */
export const OPTIONS = {
  deviceKinds: [
    { id: 'laptop', label: 'Laptop or desktop PC', hint: 'A keyboard and mouse, perhaps a touch screen too.' },
    { id: 'touch-pos', label: 'Touch-screen till', hint: 'An all-in-one counter machine used by touch.' },
    { id: 'tablet', label: 'Tablet', hint: 'A small touch screen used standing up or at a table.' },
    { id: 'kiosk', label: 'Self-service kiosk', hint: 'Customers use it themselves; big buttons, no sign-out needed.' },
  ],
  // How the shop program is laid out: the Hub's looks (apps/business-hub/.../ShopLook.cs keeps the same words; a test compares the ids).
  layouts: [
    { id: 'top', label: 'Top menu', hint: 'One bar along the top with big picture buttons. Works with a finger or a mouse. The starting choice.' },
    { id: 'list', label: 'List', hint: 'For a PC or laptop: items as a list you scroll down, the bill below.' },
    { id: 'counter', label: 'Counter', hint: 'For a touch counter: the menu down the left, the items in the middle and the bill on the right.' },
    { id: 'auto', label: 'Each screen decides', hint: 'A touch screen gets the counter look, any other screen gets the list look.' },
    { id: 'standard', label: 'By machine', hint: 'The older way: button size and menu place follow the kind of machine chosen below.' },
  ],
  systems: [
    { id: 'windows', label: 'Windows 10 or 11 (64-bit)' },
    { id: 'linux', label: 'Linux (Ubuntu, Mint, Debian)' },
  ],
  screens: [
    { id: 'small', label: 'Small (under 13 inch)' },
    { id: 'standard', label: 'Normal (13 to 17 inch)' },
    { id: 'large', label: 'Large (over 17 inch)' },
  ],
  printers: [
    { id: 'none', label: 'No printer' },
    { id: 'thermal-80', label: 'Receipt printer, 80 mm' },
    { id: 'thermal-58', label: 'Receipt printer, 58 mm' },
    { id: 'a4', label: 'Office printer (A4)' },
  ],
  styles: [
    { id: 'modern', label: 'Modern', hint: 'Rounded and clean. A good choice when unsure.' },
    { id: 'classic', label: 'Classic', hint: 'Paper tones and book-like letters. Calm and trusted.' },
    { id: 'friendly', label: 'Friendly', hint: 'Very round, warm, with soft shadows.' },
    { id: 'bold', label: 'Bold', hint: 'Square corners and strong letters. Confident.' },
    { id: 'minimal', label: 'Minimal', hint: 'Flat and quiet. Lets the content speak.' },
  ],
  appearances: [
    { id: 'auto', label: 'Follow the computer' },
    { id: 'light', label: 'Always light' },
    { id: 'dark', label: 'Always dark' },
  ],
  whiteLabel: [
    { id: 'none', label: 'Fixed look', hint: 'The customer sees the look we prepared and cannot restyle it.' },
    { id: 'theme', label: 'Their own colours and logo', hint: 'The owner can change colours, logo and layout.' },
    { id: 'full', label: 'Fully their own name', hint: 'The owner can also rename the program and remove "by NextGenOS".' },
  ],
  // The kinds of poster that can have a ready-made second-language line, and the limits the AI assistant's profile is read by (lib/aiprofile.mjs).
  posterKinds: POSTER_KINDS.map((id) => ({ id, label: POSTER_KIND_LABELS[id] })),
  imageLimits: IMAGE_LIMITS,
  states: [
    { id: 'draft', label: 'Details' }, { id: 'proposed', label: 'Prepared' }, { id: 'review', label: 'In review' },
    { id: 'approved', label: 'Approved' }, { id: 'built', label: 'Installer ready' }, { id: 'delivered', label: 'Handed over' },
  ],
};

const ids = (list) => list.map((x) => x.id);
const isObj = (v) => v !== null && typeof v === 'object' && !Array.isArray(v);
const str = (v, max) => (typeof v === 'string' ? v.slice(0, max) : '');
const badText = (t) => /[<>]/.test(t);

/** A short name for folders and files from a business name: small letters, numbers and dashes. */
export function slugFor(name, taken = []) {
  const base = String(name || 'customer').normalize('NFKD').replace(/[̀-ͯ]/g, '').toLowerCase().replace(/[^a-z0-9]+/g, '-').replace(/^-+|-+$/g, '').slice(0, 36).replace(/-+$/g, '') || 'customer';
  const start = base.length >= 2 ? base : base + '-1';
  let slug = start;
  for (let n = 2; taken.includes(slug); n += 1) slug = `${start.slice(0, 36)}-${n}`;
  return slug;
}

/** A new, empty customer record with the sensible answers filled in. */
export function blankIntake(overrides = {}) {
  return {
    schema: 1,
    business: { name: '', legalName: '', tagline: '', country: 'IN', region: '', industry: 'retail', taxRegistered: true, pricesIncludeTax: null, contact: { phone: '', email: '', address: '' } },
    money: { paymentMethods: [], receiptFooter: '', roundTotal: null },
    look: { primaryColor: '#0f6cbd', accentColor: '', style: 'modern', appearance: 'auto', layout: 'top', logo: null, poweredBy: null },
    device: { kind: 'laptop', os: 'windows', screen: 'standard', printer: 'thermal-80', scanner: true, drawer: false },
    words: {},
    features: {},
    starter: { items: [], people: [] },
    ecosystem: { website: { wanted: false, domain: '' }, android: { wanted: false, appId: '' }, aiAddon: { wanted: false } },
    licence: { whiteLabel: 'none', seats: 1 },
    notes: '',
    ...overrides,
  };
}

/**
 * Looks at an intake. Returns { errors, warnings, value } where each problem is { field, message } and value is the intake cleaned into its one form.
 * "complete" is true when nothing is missing or wrong (warnings do not stop anything). A half-filled intake can be saved; it just is not complete.
 */
export function checkIntake(input) {
  const errors = [];
  const warnings = [];
  const bad = (field, message) => errors.push({ field, message });
  const warn = (field, message) => warnings.push({ field, message });
  const base = blankIntake();
  const src = isObj(input) ? input : {};
  const value = JSON.parse(JSON.stringify(base));

  const b = isObj(src.business) ? src.business : {};
  value.business.name = (clean(str(b.name, 200), 60) ?? '');
  if (!value.business.name) bad('business.name', 'Please type the name of the business (up to 60 letters).');
  else if (badText(value.business.name)) bad('business.name', 'The name cannot have < or >.');
  for (const [field, max] of [['legalName', 120], ['tagline', 120]]) {
    value.business[field] = clean(str(b[field], 400), max) ?? '';
    if (badText(value.business[field])) bad(`business.${field}`, 'This cannot have < or >.');
  }
  value.business.country = str(b.country, 2).toUpperCase() || base.business.country;
  const country = countryPack(value.business.country);
  if (!country) bad('business.country', `There is no tax pack for ${value.business.country || 'that country'}. Choose one from the list.`);
  else if (!country.review) warn('business.country', `The ${country.name} tax rules have not yet been checked by a local tax adviser. Tell the customer, and have their accountant confirm the rates before real bills.`);
  const regions = country?.tax?.regions?.list ?? [];
  value.business.region = str(b.region, 20);
  if (regions.length > 1 && !regions.some((r) => r.code === value.business.region)) { if (value.business.region) bad('business.region', 'That is not one of the places in this country.'); else warn('business.region', `The owner will choose the ${(country.tax.regions.label || 'region').toLowerCase()} while setting up.`); }
  else if (regions.length === 1) value.business.region = regions[0].code;
  else if (regions.length === 0) value.business.region = '';
  value.business.industry = str(b.industry, 20).toLowerCase() || base.business.industry;
  if (!industryPack(value.business.industry)) bad('business.industry', 'Choose the kind of business from the list.');
  value.business.taxRegistered = typeof b.taxRegistered === 'boolean' ? b.taxRegistered : true;
  value.business.pricesIncludeTax = typeof b.pricesIncludeTax === 'boolean' ? b.pricesIncludeTax : null;
  const c = isObj(b.contact) ? b.contact : {};
  value.business.contact = { phone: str(c.phone, 40).trim(), email: str(c.email, 120).trim(), address: clean(str(c.address, 400), 200) ?? '' };
  if (value.business.contact.email && !/^[^\s@<>]+@[^\s@<>]+\.[^\s@<>]+$/.test(value.business.contact.email)) bad('business.contact.email', 'That does not look like an email address.');
  if (value.business.contact.phone && !/^[0-9 +().-]{5,25}$/.test(value.business.contact.phone)) bad('business.contact.phone', 'A phone number can only have numbers, spaces and + - ( ).');
  if (badText(value.business.contact.address)) bad('business.contact.address', 'The address cannot have < or >.');
  if (!value.business.contact.phone && !value.business.contact.email) warn('business.contact', 'Without a phone or email, the help line on the screens stays empty.');

  const m = isObj(src.money) ? src.money : {};
  value.money.paymentMethods = Array.isArray(m.paymentMethods) ? [...new Set(m.paymentMethods.filter((x) => typeof x === 'string').map((x) => x.trim().toLowerCase()).filter(Boolean))].slice(0, 12) : [];
  for (const w of value.money.paymentMethods) if (!/^[\p{L}\p{N} -]{1,20}$/u.test(w)) bad('money.paymentMethods', `"${w}" is not a short word (letters, numbers, spaces).`);
  value.money.receiptFooter = clean(str(m.receiptFooter, 400), 160) ?? '';
  if (badText(value.money.receiptFooter)) bad('money.receiptFooter', 'The bill footer cannot have < or >.');
  value.money.roundTotal = typeof m.roundTotal === 'boolean' ? m.roundTotal : null;

  const l = isObj(src.look) ? src.look : {};
  value.look.primaryColor = str(l.primaryColor, 7).toLowerCase() || base.look.primaryColor;
  const pc = colourProblem(value.look.primaryColor, 'main colour');
  if (pc) bad('look.primaryColor', pc);
  value.look.accentColor = str(l.accentColor, 7).toLowerCase();
  if (value.look.accentColor) {
    // The Hub does not take a second colour that white words cannot be read on, so a light one is only a note: it is left out of the brand file.
    const ac = colourProblem(value.look.accentColor, 'second colour', { needsContrast: false });
    if (ac) bad('look.accentColor', ac);
    else if (!usableColour(value.look.accentColor)) warn('look.accentColor', `The second colour ${value.look.accentColor} is too light to read white words on, so the screens will not use it. The main colour is used.`);
  }
  value.look.style = ids(OPTIONS.styles).includes(l.style) ? l.style : 'modern';
  value.look.appearance = ids(OPTIONS.appearances).includes(l.appearance) ? l.appearance : 'auto';
  value.look.layout = ids(OPTIONS.layouts).includes(l.layout) ? l.layout : 'top';
  value.look.logo = typeof l.logo === 'string' && /^logo\.(png|jpg|svg)$/.test(l.logo) ? l.logo : null;
  value.look.poweredBy = typeof l.poweredBy === 'boolean' ? l.poweredBy : null;
  if (!value.look.logo) warn('look.logo', 'There is no logo yet. Without one, the screens show the name only.');

  const d = isObj(src.device) ? src.device : {};
  value.device.kind = ids(OPTIONS.deviceKinds).includes(d.kind) ? d.kind : 'laptop';
  value.device.os = ids(OPTIONS.systems).includes(d.os) ? d.os : 'windows';
  value.device.screen = ids(OPTIONS.screens).includes(d.screen) ? d.screen : 'standard';
  value.device.printer = ids(OPTIONS.printers).includes(d.printer) ? d.printer : 'thermal-80';
  value.device.scanner = d.scanner !== false;
  value.device.drawer = d.drawer === true;

  value.words = {};
  if (isObj(src.words)) for (const [k, v] of Object.entries(src.words)) if (Array.isArray(v) && v.length === 2 && v.every((x) => typeof x === 'string' && clean(x, 30))) value.words[k] = v.map((x) => clean(x, 30));
  value.features = {};
  if (isObj(src.features)) for (const [k, v] of Object.entries(src.features)) if (typeof v === 'boolean') value.features[k] = v;
  const s = isObj(src.starter) ? src.starter : {};
  value.starter = { items: Array.isArray(s.items) ? s.items.slice(0, 2000) : [], people: Array.isArray(s.people) ? s.people.slice(0, 2000) : [] };

  const e = isObj(src.ecosystem) ? src.ecosystem : {};
  const w = isObj(e.website) ? e.website : {};
  const a = isObj(e.android) ? e.android : {};
  value.ecosystem.website = { wanted: w.wanted === true, domain: str(w.domain, 120).trim().toLowerCase() };
  if (value.ecosystem.website.wanted && value.ecosystem.website.domain && !/^[a-z0-9]([a-z0-9.-]*[a-z0-9])?$/.test(value.ecosystem.website.domain)) bad('ecosystem.website.domain', 'Type the website name without https:// and without a slash, like shop.example.com.');
  value.ecosystem.aiAddon = { wanted: isObj(e.aiAddon) && e.aiAddon.wanted === true };
  if (value.ecosystem.aiAddon.wanted && value.device.os !== 'windows') warn('ecosystem.aiAddon', 'The AI assistant is a Windows program, so it cannot go on a Linux machine.');
  // The pictures and posters the AI assistant makes: who the model photos show, the festivals, the second language. Optional; with nothing typed the AI assistant stays neutral.
  const images = checkImages(src.images, { wanted: value.ecosystem.aiAddon.wanted, bad, warn });
  if (images) value.images = images;
  value.ecosystem.android = { wanted: a.wanted === true, appId: str(a.appId, 80).trim().toLowerCase() };
  if (value.ecosystem.android.wanted) {
    if (!/^[a-z][a-z0-9_]*(\.[a-z][a-z0-9_]*){2,}$/.test(value.ecosystem.android.appId)) bad('ecosystem.android.appId', 'The app id must look like com.yourshop.app (small letters, at least three parts).');
    if (!value.ecosystem.website.wanted || !value.ecosystem.website.domain) warn('ecosystem.android', 'The Android app opens the customer\'s website, so it needs the website name too.');
  }

  const lic = isObj(src.licence) ? src.licence : {};
  value.licence = { whiteLabel: ids(OPTIONS.whiteLabel).includes(lic.whiteLabel) ? lic.whiteLabel : 'none', seats: Number.isInteger(lic.seats) && lic.seats >= 1 && lic.seats <= 500 ? lic.seats : 1 };
  value.notes = clean(str(src.notes, 6000), 4000) ?? '';
  if (value.licence.whiteLabel === 'none' && (value.look.primaryColor !== base.look.primaryColor || value.look.logo)) warn('licence.whiteLabel', 'With a "fixed look" licence, the colours and logo come from the brand on the licence, not from this setup. Choose "Their own colours and logo" if the profile\'s colours must show.');
  if (value.licence.whiteLabel !== 'full' && value.look.poweredBy === false) warn('look.poweredBy', 'Only a "fully their own name" licence can remove "by NextGenOS".');

  return { errors, warnings, value, complete: errors.length === 0 };
}

export const countryList = () => allCountries();
