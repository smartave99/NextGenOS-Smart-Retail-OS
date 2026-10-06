// A brand kit: a folder brand-kits/<name>/ with brand.json and a logo. Reading, checking and saving it, in words a shop owner understands.
// The same rules as licensing/spec/LICENCE-FORMAT.md section 5.2 (colours, logo) so a kit that passes here also shows in the programs.
import { readFileSync, writeFileSync, mkdirSync, existsSync, readdirSync, copyFileSync, statSync } from 'node:fs';
import { join, resolve, dirname, extname, basename } from 'node:path';
import { fileURLToPath } from 'node:url';

export const repoRoot = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..', '..');
export const kitsRoot = (root = repoRoot) => join(root, 'brand-kits');
export const MAX_LOGO_BYTES = 100_000;
export const SLUG = /^[a-z0-9][a-z0-9-]{1,40}$/;

const HEX = /^#[0-9a-fA-F]{6}$/;
const THEMES = ['auto', 'light', 'dark'];
const KNOWN = ['schema', 'name', 'shortName', 'legalName', 'tagline', 'primaryColor', 'accentColor', 'theme', 'logo', 'contact', 'country', 'industry', 'currency', 'language', 'storefront', 'android', 'receipt', 'poweredBy'];

/** WCAG contrast ratio of a "#rrggbb" colour with white. */
export function contrastWithWhite(hex) {
  const channel = (from) => { const c = parseInt(hex.slice(from, from + 2), 16) / 255; return c <= 0.04045 ? c / 12.92 : Math.pow((c + 0.055) / 1.055, 2.4); };
  return 1.05 / (0.2126 * channel(1) + 0.7152 * channel(3) + 0.0722 * channel(5) + 0.05);
}

/** A colour no white text can be read on is refused (it would make buttons unreadable). Returns a plain-words problem or null. */
export function colourProblem(value, what, { needsContrast = true } = {}) {
  if (typeof value !== 'string' || !HEX.test(value)) return `The ${what} must look like #0f6cbd (a # and six letters or numbers).`;
  if (needsContrast && contrastWithWhite(value) < 3) return `The ${what} (${value}) is too light to read white words on. Choose a darker colour.`;
  return null;
}

const clean = (t) => typeof t === 'string' && ![...t].some((c) => c.charCodeAt(0) < 32 || (c.charCodeAt(0) >= 127 && c.charCodeAt(0) <= 159));

/** Looks into a logo file: its real kind (from the first bytes, not the name), and whether it is safe. Returns { kind, problem }. */
export function inspectLogo(bytes) {
  const png = bytes.length > 8 && bytes[0] === 0x89 && bytes[1] === 0x50 && bytes[2] === 0x4e && bytes[3] === 0x47;
  const jpeg = bytes.length > 3 && bytes[0] === 0xff && bytes[1] === 0xd8 && bytes[2] === 0xff;
  if (png) return { kind: 'png' };
  if (jpeg) return { kind: 'jpeg' };
  const text = bytes.subarray(0, Math.min(bytes.length, 400_000)).toString('utf8');
  if (/^\s*(<\?xml[^>]*>\s*)?(<!--[\s\S]*?-->\s*)?<svg[\s>]/i.test(text)) {
    // A picture that can carry its own instructions or fetch things from elsewhere is not accepted.
    if (/<script|<foreignObject|<iframe|<embed|<object|<!ENTITY|javascript:|\son[a-z]+\s*=|(?:xlink:)?href\s*=\s*["']\s*(?!#|data:image\/)/i.test(text)) return { kind: 'svg', problem: 'This SVG picture holds scripts or links to other places. Export it again as a plain picture, or use a PNG.' };
    return { kind: 'svg' };
  }
  return { kind: null, problem: 'The logo must be a PNG, JPEG or SVG picture.' };
}

/** What is wrong with a kit, in plain words: { errors, warnings }. */
export function check(kit, { folder = null, countries = null, industries = null } = {}) {
  const errors = [];
  const warnings = [];
  const bad = (m) => errors.push(m);
  if (!kit || typeof kit !== 'object' || Array.isArray(kit)) return { errors: ['brand.json is not a brand kit.'], warnings };
  if (kit.schema !== 1) bad('The kit must say "schema": 1.');
  if (typeof kit.name !== 'string' || !kit.name.trim() || kit.name.length > 60 || !clean(kit.name) || /[<>]/.test(kit.name)) bad('Give the business a name of 1 to 60 letters (no < or >).');
  for (const [k, max] of [['shortName', 30], ['legalName', 120], ['tagline', 120]]) {
    if (kit[k] !== undefined && (typeof kit[k] !== 'string' || kit[k].length > max || !clean(kit[k]) || /[<>]/.test(kit[k]))) bad(`"${k}" can have at most ${max} letters (no < or >).`);
  }
  const p = colourProblem(kit.primaryColor, 'main colour'); if (p) bad(p);
  if (kit.accentColor !== undefined) { const a = colourProblem(kit.accentColor, 'second colour', { needsContrast: false }); if (a) bad(a); }
  if (kit.theme !== undefined && !THEMES.includes(kit.theme)) bad('The theme must be auto, light or dark.');
  if (kit.logo !== undefined) {
    if (typeof kit.logo !== 'string' || !/^[A-Za-z0-9._-]+$/.test(kit.logo)) bad('The logo must be the name of a file in the kit folder, like logo.png.');
    else if (folder) {
      const file = join(folder, kit.logo);
      if (!existsSync(file)) bad(`The logo file ${kit.logo} is not in the kit folder.`);
      else {
        const bytes = readFileSync(file);
        const info = inspectLogo(bytes);
        if (info.problem) bad(info.problem);
        else if (info.kind !== 'svg' && bytes.length > MAX_LOGO_BYTES) warnings.push(`The logo is ${Math.round(bytes.length / 1000)} KB. The programs take pictures of at most 100 KB; a smaller copy is used there.`);
        if (info.kind && extname(kit.logo).toLowerCase().replace('.jpg', '.jpeg') !== '.' + info.kind) warnings.push(`The logo file says ${extname(kit.logo)} but is really a ${info.kind.toUpperCase()} picture.`);
      }
    }
  } else warnings.push('There is no logo yet. Without one, the programs show the name only.');
  const c = kit.contact;
  if (c !== undefined) {
    if (!c || typeof c !== 'object') bad('"contact" must hold email, phone and address.');
    else {
      if (c.email && (typeof c.email !== 'string' || !/^[^\s@<>]+@[^\s@<>]+\.[^\s@<>]+$/.test(c.email) || c.email.length > 120)) bad('The contact email does not look like an email address.');
      if (c.phone && (typeof c.phone !== 'string' || !/^[0-9 +().-]{5,25}$/.test(c.phone))) bad('The contact phone can only have numbers, spaces and + - ( ).');
      if (c.address && (typeof c.address !== 'string' || c.address.length > 200 || !clean(c.address) || /[<>]/.test(c.address))) bad('The address can have at most 200 letters (no < or >).');
    }
  }
  if (kit.country !== undefined) {
    if (typeof kit.country !== 'string' || !/^[A-Z]{2}$/.test(kit.country)) bad('The country must be two capital letters, like IN or PH.');
    else if (countries && !countries.includes(kit.country)) warnings.push(`There is no tax pack for ${kit.country} yet (available: ${countries.join(', ')}).`);
  }
  if (kit.industry !== undefined) {
    if (typeof kit.industry !== 'string' || !/^[a-z]{3,20}$/.test(kit.industry)) bad('The kind of business must be one word in small letters, like retail or restaurant.');
    else if (industries && !industries.includes(kit.industry)) bad(`The kind of business ${kit.industry} is not one of: ${industries.join(', ')}.`);
  }
  if (kit.currency !== undefined && !/^[A-Z]{3}$/.test(kit.currency || '')) bad('The currency must be three capital letters, like INR or PHP.');
  if (kit.language !== undefined && !/^[a-z]{2,3}(-[A-Za-z0-9]{2,8})*$/.test(kit.language || '')) bad('The language must look like en-IN or fil-PH.');
  const site = kit.storefront?.siteUrl;
  if (site !== undefined && !/^https:\/\/[a-z0-9]([a-z0-9.-]*[a-z0-9])?(:\d+)?$/i.test(site)) bad('The website address must start with https:// and have nothing after the name (for example https://shop.example.com).');
  if (kit.android !== undefined) {
    const a = kit.android;
    if (!a || typeof a !== 'object') bad('"android" must hold appId and storefrontUrl.');
    else {
      if (!/^[a-z][a-z0-9_]*(\.[a-z][a-z0-9_]*){2,}$/.test(a.appId || '')) bad('The Android app id must look like com.yourshop.app (small letters, at least three parts).');
      if (!/^https:\/\/[a-z0-9]([a-z0-9.-]*[a-z0-9])?(:\d+)?$/i.test(a.storefrontUrl || '')) bad('The website the Android app opens must start with https:// and have nothing after the name.');
    }
  }
  if (kit.receipt !== undefined) {
    for (const k of ['header', 'footer']) {
      const v = kit.receipt?.[k];
      if (v !== undefined && (typeof v !== 'string' || v.length > 160 || !clean(v) || /[<>]/.test(v))) bad(`The bill ${k} can have at most 160 letters (no < or >).`);
    }
  }
  if (kit.poweredBy !== undefined && typeof kit.poweredBy !== 'boolean') bad('"poweredBy" must be true or false.');
  for (const k of Object.keys(kit)) if (!KNOWN.includes(k)) warnings.push(`"${k}" is not a field of a brand kit and is ignored.`);
  return { errors, warnings };
}

export function countryCodes(root = repoRoot) {
  const dir = join(root, 'country-packs', 'packs');
  return existsSync(dir) ? readdirSync(dir).filter((f) => /^[A-Z]{2}\.json$/.test(f)).map((f) => f.slice(0, 2)).sort() : null;
}

export function industryIds(root = repoRoot) {
  const dir = join(root, 'industry-packs', 'packs');
  return existsSync(dir) ? readdirSync(dir).filter((f) => /^[a-z]+\.json$/.test(f)).map((f) => f.slice(0, -5)).sort() : null;
}

export function listKits(root = repoRoot) {
  const dir = kitsRoot(root);
  return existsSync(dir) ? readdirSync(dir, { withFileTypes: true }).filter((e) => e.isDirectory() && existsSync(join(dir, e.name, 'brand.json'))).map((e) => e.name).sort() : [];
}

export function kitFolder(slug, root = repoRoot) {
  if (!SLUG.test(slug || '')) throw new Error('A kit name has 2 to 41 small letters, numbers or dashes, like luzon-fresh.');
  return join(kitsRoot(root), slug);
}

export function loadKit(slug, root = repoRoot) {
  const folder = kitFolder(slug, root);
  const file = join(folder, 'brand.json');
  if (!existsSync(file)) throw new Error(`There is no kit called ${slug}. Make it with: node tools/brand-studio/brand.mjs new ${slug} --name "Shop Name" --primary "#0f6cbd"`);
  let kit;
  try { kit = JSON.parse(readFileSync(file, 'utf8')); } catch { throw new Error(`${slug}/brand.json is not readable (it is not valid JSON).`); }
  return { slug, folder, kit };
}

/** Writes a kit, only when it passes the check. The logo (a file path, or bytes) is copied into the folder as logo.png / logo.jpg / logo.svg. */
export function saveKit(slug, kit, { logoBytes = null, root = repoRoot, countries = countryCodes(root), industries = industryIds(root) } = {}) {
  const folder = kitFolder(slug, root);
  const next = { ...kit };
  let logoKind = null;
  if (logoBytes) {
    const info = inspectLogo(logoBytes);
    if (info.problem) throw new Error(info.problem);
    logoKind = info.kind;
    next.logo = `logo.${info.kind === 'jpeg' ? 'jpg' : info.kind}`;
  }
  const { errors, warnings } = check(next, { folder: logoBytes ? null : folder, countries, industries });
  if (errors.length) { const e = new Error(errors.join('\n')); e.problems = errors; throw e; }
  mkdirSync(folder, { recursive: true });
  if (logoBytes) writeFileSync(join(folder, next.logo), logoBytes);
  writeFileSync(join(folder, 'brand.json'), JSON.stringify(next, null, 2) + '\n');
  return { folder, kit: next, warnings, logoKind };
}

export function readLogo(slug, root = repoRoot) {
  const { folder, kit } = loadKit(slug, root);
  if (!kit.logo) return null;
  const file = join(folder, basename(kit.logo));
  return existsSync(file) ? readFileSync(file) : null;
}

export function blank(name, primaryColor) {
  return { schema: 1, name, primaryColor, accentColor: '#f59e0b', theme: 'auto', contact: { email: '', phone: '', address: '' }, poweredBy: true };
}
