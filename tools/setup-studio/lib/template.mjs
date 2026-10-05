// The first proposal for a customer, made from the intake by plain rules (no AI, no network, always the same answer for the same intake). An AI tool may later improve
// on it, but this is the baseline everyone starts from and the answer when no AI tool is set up.
import { parseSetup, parseTheme, parseBrand, logoProblem, usableColour, resolveTheme, THEME_DEFAULTS, DEVICE_TOKENS } from './rules.mjs';
import { checkIntake, OPTIONS } from './intake.mjs';
import { countryPack, industryPack } from './packs.mjs';
import { canonical } from './fsx.mjs';

/** How a kind of style becomes the named choices of a look. */
export const STYLES = {
  modern: { shape: 'rounded', surface: 'neutral', font: 'system', depth: 'soft' },
  classic: { shape: 'soft', surface: 'paper', font: 'serif', depth: 'flat' },
  friendly: { shape: 'pill', surface: 'warm', font: 'rounded', depth: 'lifted' },
  bold: { shape: 'square', surface: 'neutral', font: 'humanist', depth: 'lifted' },
  minimal: { shape: 'soft', surface: 'neutral', font: 'system', depth: 'flat' },
};

/** How a machine becomes the layout choices: size of buttons and letters, where the menu and the basket sit. */
export function deviceTokens(device) {
  const small = device.screen === 'small';
  switch (device.kind) {
    case 'touch-pos': return small ? { density: 'touch', nav: 'bottom', navLabels: 'full', cart: 'bottom', fontScale: 1.1 } : { density: 'touch', nav: 'left', navLabels: 'full', cart: 'right', fontScale: 1.1 };
    case 'tablet': return { density: 'touch', nav: 'bottom', navLabels: 'full', cart: small ? 'bottom' : 'right', fontScale: 1.05 };
    case 'kiosk': return { density: 'touch', nav: 'bottom', navLabels: 'full', cart: 'bottom', fontScale: 1.2 };
    default: return small ? { density: 'compact', nav: 'left', navLabels: 'icons', cart: 'right', fontScale: 1 } : { density: 'comfortable', nav: 'left', navLabels: 'full', cart: 'right', fontScale: 1 };
  }
}

/** The theme file for an intake. Only what differs from the plain defaults is written, so the file stays short and says what was chosen. */
export function themeFor(intake) {
  const wanted = { ...STYLES[intake.look.style] ?? STYLES.modern, mode: intake.look.appearance, ...deviceTokens(intake.device) };
  const theme = {};
  for (const [token, value] of Object.entries(wanted)) if (value !== THEME_DEFAULTS[token]) theme[token] = value;
  return theme;
}

/** The brand file for an intake. The logo is added as a picture data address when it is a PNG or JPEG the Hub accepts. */
export function brandFor(intake, logoUri = null) {
  const brand = { name: intake.business.name, primaryColor: intake.look.primaryColor };
  if (usableColour(intake.look.accentColor)) brand.accentColor = intake.look.accentColor;
  if (logoUri && !logoProblem(logoUri)) brand.logo = logoUri;
  if (intake.business.contact.email) brand.supportEmail = intake.business.contact.email;
  if (intake.business.contact.phone) brand.supportPhone = intake.business.contact.phone;
  if (intake.look.poweredBy !== null && intake.licence.whiteLabel === 'full') brand.poweredBy = intake.look.poweredBy;
  return brand;
}

/** The setup file for an intake. */
export function setupFor(intake) {
  const b = intake.business;
  const business = { name: b.name, country: b.country, industry: b.industry };
  if (b.region) business.region = b.region;
  const settings = { taxRegistered: b.taxRegistered };
  if (b.pricesIncludeTax !== null) settings.pricesIncludeTax = b.pricesIncludeTax;
  if (intake.money.roundTotal !== null) settings.roundTotal = intake.money.roundTotal;
  if (intake.money.receiptFooter) settings.receiptFooter = intake.money.receiptFooter;
  if (intake.money.paymentMethods.length) settings.paymentMethods = intake.money.paymentMethods;
  const setup = { schema: 1, business, settings };
  if (Object.keys(intake.words).length) setup.vocabulary = intake.words;
  if (Object.keys(intake.features).length) setup.features = intake.features;
  if (intake.starter.items.length || intake.starter.people.length) setup.starter = { ...(intake.starter.items.length && { items: intake.starter.items }), ...(intake.starter.people.length && { people: intake.starter.people }) };
  return setup;
}

const label = (list, id) => list.find((x) => x.id === id)?.label ?? id;

/** Says in plain words what a proposal does, for the screen and for the hand-over papers. */
export function explain(intake, proposal) {
  const out = [];
  const b = intake.business;
  const country = countryPack(b.country);
  const industry = industryPack(b.industry);
  out.push({ part: 'business', text: `${b.name} is set up as ${industry?.name ?? b.industry} in ${country?.name ?? b.country}. The money, tax and bill words come from the ${country?.name ?? b.country} rules${country?.review ? '' : ' (not yet checked by a local tax adviser)'}.` });
  const t = proposal.theme;
  const layout = [];
  if (t.density === 'touch') layout.push('big buttons for fingers');
  if (t.density === 'compact') layout.push('closer-packed screens for a small display');
  if (t.nav === 'bottom') layout.push('the menu along the bottom');
  if (t.navLabels === 'icons') layout.push('the menu as small pictures');
  if (t.cart === 'bottom') layout.push('the basket below the items');
  if (t.fontScale && t.fontScale !== 1) layout.push(`letters ${Math.round((t.fontScale - 1) * 100)}% bigger`);
  out.push({ part: 'layout', text: `For a ${label(OPTIONS.deviceKinds, intake.device.kind).toLowerCase()} (${label(OPTIONS.screens, intake.device.screen).toLowerCase()} screen): ${layout.length ? layout.join(', ') : 'the standard layout'}.` });
  const s = STYLES[intake.look.style] ?? STYLES.modern;
  out.push({ part: 'look', text: `The "${label(OPTIONS.styles, intake.look.style)}" look: ${s.shape} corners, ${s.surface} background, ${s.font} letters, ${s.depth} shadows, in ${intake.look.primaryColor}${usableColour(intake.look.accentColor) ? ` with ${intake.look.accentColor}` : ''}. Appearance: ${label(OPTIONS.appearances, intake.look.appearance).toLowerCase()}.` });
  const level = intake.licence.whiteLabel;
  out.push({ part: 'licence', text: level === 'none'
    ? 'Licence level "fixed look": the screen layout shows, but the colours, name and shapes come from the brand on the licence, and the owner cannot restyle it.'
    : level === 'theme' ? 'Licence level "their own colours and logo": this look shows in full, and the owner may change colours, logo and layout. The program name stays the licence\'s.'
      : 'Licence level "fully their own name": this look and name show in full, and the owner may rename the program and remove "by NextGenOS".' });
  const n = proposal.setup.starter;
  if (n) out.push({ part: 'starter', text: `The shop starts with ${[n.items?.length && `${n.items.length} item${n.items.length === 1 ? '' : 's'}`, n.people?.length && `${n.people.length} ${n.people.length === 1 ? 'person' : 'people'}`].filter(Boolean).join(' and ')} already added.` });
  if (proposal.setup.settings?.paymentMethods) out.push({ part: 'money', text: `Ways of paying: ${proposal.setup.settings.paymentMethods.join(', ')}.` });
  return out;
}

/**
 * Makes the first proposal. Returns { ok, errors, proposal } where proposal is { setup, theme, brand, explain, problems, source }; every file has been through the same
 * checks the Hub applies (rules.mjs), so what is returned is what the Hub will read. logoUri is the customer's logo as a data address, or null.
 */
export function propose(intakeInput, { logoUri = null } = {}) {
  const checked = checkIntake(intakeInput);
  if (!checked.complete) return { ok: false, errors: checked.errors, proposal: null };
  const intake = checked.value;
  const problems = [];
  const setup = parseSetup(setupFor(intake));
  const theme = parseTheme(themeFor(intake));
  const brand = parseBrand(brandFor(intake, logoUri));
  problems.push(...setup.problems, ...theme.problems, ...brand.problems);
  const proposal = { setup: setup.value, theme: theme.value, brand: brand.value, problems, source: 'template' };
  proposal.explain = explain(intake, proposal);
  return { ok: true, errors: [], proposal };
}

/** What the customer's screens will show, for a licence level: the proposal's theme as the Hub resolves it. */
export const shown = (level, proposal) => resolveTheme(level, proposal.theme, null);
export { DEVICE_TOKENS };

/**
 * Reads a proposal that came from somewhere else (an AI tool, or a person's edit) through the same rules as the Hub's. The customer's own identity (name, country, region, kind of
 * business, whether they are registered for tax, and the whole brand) is put back from the base proposal made from the details, whatever the candidate said, and what could not be
 * used is named. Returns { ok, error, proposal } where proposal is { setup, theme, brand, problems, explain }.
 */
export function reconcile(base, candidate) {
  const problems = [];
  const setup = parseSetup(candidate?.setup);
  const theme = parseTheme(candidate?.theme ?? {});
  const brand = parseBrand(candidate?.brand ?? {});
  problems.push(...setup.problems, ...theme.problems, ...brand.problems);
  if (!setup.value) return { ok: false, error: 'The setup file could not be used: ' + (setup.problems.join(' ') || 'it is empty.'), proposal: null };
  const kept = [];
  const lock = (have, want, what) => { if (have !== undefined && have !== want) kept.push(what); };
  lock(setup.value.business?.name, base.setup.business.name, 'the business name');
  lock(setup.value.business?.country, base.setup.business.country, 'the country');
  lock(setup.value.business?.industry, base.setup.business.industry, 'the kind of business');
  lock(setup.value.business?.region, base.setup.business.region, 'the region');
  setup.value.business = { ...base.setup.business };
  if (base.setup.settings?.taxRegistered !== undefined) {
    lock(setup.value.settings?.taxRegistered, base.setup.settings.taxRegistered, 'whether the business is registered for tax');
    setup.value.settings = { ...setup.value.settings, taxRegistered: base.setup.settings.taxRegistered };
  }
  // The first items and people are real data from the details; a proposal can neither add to them nor drop them.
  if (setup.value.starter !== undefined && canonical(setup.value.starter) !== canonical(base.setup.starter ?? null)) kept.push('the first items and people');
  if (base.setup.starter) setup.value.starter = base.setup.starter; else delete setup.value.starter;
  if (canonical(brand.value) !== canonical(base.brand)) kept.push('the brand (name, colours, logo and contact)');
  if (kept.length) problems.push(`The customer's own details were kept: the proposal tried to change ${kept.join(', ')}.`);
  return { ok: true, error: null, proposal: { setup: setup.value, theme: theme.value, brand: { ...base.brand }, problems, explain: base.explain } };
}
