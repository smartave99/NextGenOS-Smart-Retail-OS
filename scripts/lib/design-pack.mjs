/**
 * The checked styling layer for a customer's shopper-facing website and app (decisions 5 and 6 in docs/PLATFORM-DECISIONS.md; the plain-words guide is docs/DESIGN-PACK.md).
 *
 * A DESIGN PACK is one JSON file: a few typed tokens (colours, fonts, corner shapes, spacing, shadows), optionally the customer's own font and picture files, and an optional style
 * sheet written against a public, documented list of "hooks" (data-ngos-part="header", ...) that the website promises to keep stable. The AI that shapes a client's look, or a
 * designer, writes it. It changes HOW THINGS LOOK and nothing else. This module is the one place that decides whether a pack is safe to use. It is used by:
 *   - the customer-build workflow (scripts/customer-build/validate-inputs.mjs) when it reads what the Setup Studio sent,
 *   - the website build (scripts/make-website-package.mjs, through scripts/design-pack.mjs),
 *   - and, later, the Setup Studio itself, to show staff what is wrong before anything is sent.
 *
 * The rules, in short (the full list, with reasons, is what the problems below say, and docs/DESIGN-PACK.md):
 *   - DEFAULT DENY. The style sheet is read with a real CSS tokenizer and parser. Anything it does not recognise is refused. There is no list of "bad words" to get around.
 *   - No scripts of any kind, no @import, no url() to anything but the pack's own bundled pictures and fonts, nothing from outside, no expression()/behavior/-moz-binding,
 *     no javascript: or data: addresses, no custom properties, no !important, no backslash escapes outside quoted text, no comments that are never closed.
 *   - Only the hooks may be styled (no element, class, id or attribute selectors that could reach a form, a field, or the licence, legal or security notices).
 *   - Each hook has a KIND (layout, text, control, notice, media, extra, slot) and each kind may only use some properties, with bounded values. Controls and notices (anything a
 *     shopper must be able to read or press) can be re-skinned but never hidden, shrunk, moved, faded, covered, disabled or made unreadable.
 *   - The output is written from what was checked (compileDesignPack), never copied from the text that came in.
 * A passing check does NOT prove a pack is good looking or that every device draws it as intended: a person must still look at the preview. It says only that nothing this module
 * knows to be dangerous or to hide a required thing was found.
 *
 * Pure JavaScript. No imports, no file or network access, no Node-only functions: it runs in Node (build scripts, the storefront build) and in a browser.
 */

export const DESIGN_PACK_SCHEMA = 1;

// ---------------------------------------------------------------------------------------------------------------------
// 1. What a pack may refer to: the hooks (the public list), the tokens and the limits
// ---------------------------------------------------------------------------------------------------------------------

/** What each kind of hook may be used for, in plain words (shown to designers). */
export const PART_KINDS = Object.freeze({
  layout: 'A block that holds other things. It can be coloured, shaped, spaced and arranged, never hidden.',
  text: 'Words (a heading or a paragraph). They can be restyled, never hidden.',
  control: 'Something a shopper presses or follows (a link, a button, a product card). It can be restyled, never hidden, moved, faded or switched off.',
  notice: 'Something a shopper must be able to read (a price, how shopping works here, the legal links, the copyright line). It can be restyled, never hidden or made hard to read.',
  media: 'A picture. It can be shaped and given effects, never hidden.',
  extra: 'An optional extra. It can be restyled, and it can be hidden.',
  slot: 'An empty decoration area inside a frame that the website itself clips and keeps behind the content. It can be drawn on freely and can never cover or block anything.',
});

const part = (kind, where, states = null) => Object.freeze({ kind, where, ...(states ? { states: Object.freeze(states) } : {}) });

/**
 * The hooks: the public, documented list the website promises to keep. data-ngos-part="<name>" is on the matching element of every page of the website.
 * Adding a part is allowed; renaming or removing one is a breaking change for every customer's pack. `where` says in plain words where it is.
 */
export const PARTS = Object.freeze({
  'page': part('layout', 'The whole page, behind everything else.'),
  'header': part('layout', 'The bar at the top of every page.'),
  'header-brand': part('control', 'The shop logo and name in the header. It takes shoppers to the home page.'),
  'nav': part('layout', 'The row of main menu links in the header (wide screens).'),
  'nav-link': part('control', 'One link of the main menu.', ['current']),
  'header-action': part('control', 'A button or link at the right of the header: search, menu, request a product, gift finder.'),
  'store-notice': part('notice', 'The strip under the header that says how shopping here works.'),
  'hero': part('layout', 'The big first block of the home page.'),
  'hero-title': part('text', 'The big heading in the hero.'),
  'hero-text': part('text', 'The paragraph under the hero heading.'),
  'hero-badge': part('extra', 'The small label above the hero heading.'),
  'hero-facts': part('extra', 'The small reassurance chips under the hero buttons.'),
  'button-primary': part('control', 'The main action button or link (in the hero, in the call-to-action block, in the footer).'),
  'button-secondary': part('control', 'The second action button or link, next to the main one.'),
  'section': part('layout', 'A block of the home page (offers, highlights, features, call to action).'),
  'section-title': part('text', 'The heading of a block.'),
  'section-text': part('text', 'The paragraph under the heading of a block.'),
  'product-grid': part('layout', 'The grid of product cards.'),
  'product-card': part('control', 'One product in the grid. Pressing it opens the product.', ['featured', 'sale']),
  'product-image': part('media', 'The picture of a product in the grid.'),
  'product-name': part('text', 'The name of a product in the grid.'),
  'product-price': part('notice', 'The price of a product in the grid.'),
  'product-availability': part('notice', 'The note on a product that says whether it is in store.', ['unavailable']),
  'product-description': part('extra', 'The short description of a product in the grid.'),
  'product-tags': part('extra', 'The tags of a product in the grid.'),
  'product-rating': part('extra', 'The star rating of a product in the grid.'),
  'product-badge': part('extra', 'A small label on a product picture (featured, offer).'),
  'footer': part('layout', 'The block at the bottom of every page.'),
  'footer-brand': part('control', 'The shop logo and name in the footer.'),
  'footer-text': part('text', 'A paragraph in the footer.'),
  'footer-link': part('control', 'A menu link in the footer.'),
  'legal-link': part('control', 'The small links at the very bottom of the footer (privacy, terms and the like).'),
  'footer-contact': part('control', 'An address, e-mail or phone link in the footer.'),
  'social-link': part('control', 'A link to one of the shop\'s social pages.'),
  'copyright': part('notice', 'The copyright line at the bottom of the footer.'),
  'decoration': part('slot', 'An empty decoration area inside the hero, the call-to-action block and the footer. Draw backgrounds, shapes and gradients here.'),
  'assistant-launcher': part('control', 'The round button that opens the shopping assistant.'),
  'banner': part('notice', 'A small message that slides in from the bottom (a new version is ready, install the app).'),
});

export const REQUIRED_KINDS = Object.freeze(['control', 'notice']);
export const isRequiredPart = (name) => Object.hasOwn(PARTS, name) && REQUIRED_KINDS.includes(PARTS[name].kind);

/** The highest z-index a pack may use. The website's own bars, banners and dialogs sit at 50 and above, so nothing in a pack can ever be drawn over them. */
export const Z_INDEX_CEILING = 10;

/** What a pack may not exceed. Bigger than any sensible design needs; there to stop abuse and to keep a customer's site fast. */
export const LIMITS = Object.freeze({
  packBytes: 3 * 1024 * 1024, cssBytes: 80 * 1024, cssTokens: 60000, nesting: 24,
  rules: 600, selectors: 1500, declarations: 6000, atRuleDepth: 3, selectorsPerRule: 12, compoundsPerSelector: 4,
  keyframesBlocks: 12, keyframeStops: 12,
  assets: 16, assetBytes: 700 * 1024, fontBytes: 400 * 1024, assetsTotalBytes: 2 * 1024 * 1024, pictureSide: 6000,
  fontFiles: 6, nameChars: 60, noteChars: 300, problems: 60,
});

/** The tokens: name, what it is for, and the neutral default (the website's own look today). A pack may set any of them. */
export const TOKEN_GROUPS = Object.freeze({
  color: Object.freeze({
    primary: '#1d4ed8', onPrimary: '#ffffff', accent: '#0f766e', night: '#071225', canvas: '#f4f7fb', surface: '#ffffff', text: '#0f172a', textMuted: '#475569',
    border: '#cbd5e1', success: '#047857', warning: '#92400e', danger: '#b91c1c', focus: '#2563eb',
  }),
  font: Object.freeze({ body: 'outfit', heading: 'outfit' }),
  radius: Object.freeze({ small: '0.5rem', medium: '0.75rem', large: '1rem', pill: '999px' }),
  space: Object.freeze({ unit: '0.25rem' }),
  shadow: Object.freeze({ small: '0 1px 2px rgba(15, 23, 42, 0.04), 0 8px 24px rgba(15, 23, 42, 0.08)', medium: '0 4px 8px rgba(15, 23, 42, 0.05), 0 12px 32px rgba(15, 23, 42, 0.12)', large: '0 4px 8px rgba(15, 23, 42, 0.05), 0 20px 48px rgba(15, 23, 42, 0.14)' }),
});

/** The fonts a pack may name without shipping a file. Each is a stack of fonts the visitor's own device is likely to have, or a font the website already carries. Nothing is fetched. */
export const FONT_STACKS = Object.freeze({
  'inter': 'var(--font-inter), system-ui, -apple-system, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif',
  'outfit': 'var(--font-outfit), system-ui, -apple-system, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif',
  'system-sans': 'system-ui, -apple-system, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans", sans-serif',
  'humanist': 'Seravek, "Gill Sans Nova", Ubuntu, Calibri, "DejaVu Sans", "Source Sans Pro", sans-serif',
  'geometric': 'Avenir, Montserrat, Corbel, "URW Gothic", "Source Sans Pro", sans-serif',
  'rounded': 'ui-rounded, "Hiragino Maru Gothic ProN", Quicksand, Comfortaa, Manjari, "Arial Rounded MT", "Arial Rounded MT Bold", Calibri, sans-serif',
  'system-serif': '"Iowan Old Style", "Apple Garamond", Baskerville, "Times New Roman", "Droid Serif", Times, "Source Serif Pro", serif',
  'classic-serif': 'Georgia, Cambria, "Times New Roman", Times, serif',
  'slab': 'Rockwell, "Rockwell Nova", "Roboto Slab", "DejaVu Serif", "Sitka Small", serif',
  'system-mono': 'ui-monospace, "Cascadia Code", "Source Code Pro", Menlo, Consolas, "DejaVu Sans Mono", monospace',
});

const GENERIC_FONT_WORDS = ['serif', 'sans-serif', 'monospace', 'cursive', 'fantasy', 'system-ui', 'ui-serif', 'ui-sans-serif', 'ui-monospace', 'ui-rounded', 'math', 'emoji', 'fangsong', 'inherit', 'initial', 'unset', 'revert', 'default'];

/** The custom properties a pack's style sheet may read with var(). Each is set by the website from the tokens (with the default when the pack does not set it). */
export const VARIABLES = (() => {
  const v = {};
  for (const k of Object.keys(TOKEN_GROUPS.color)) v[`--ngos-color-${k.replace(/[A-Z]/g, (c) => `-${c.toLowerCase()}`)}`] = 'color';
  for (const k of Object.keys(TOKEN_GROUPS.radius)) v[`--ngos-radius-${k}`] = 'radius';
  for (const k of Object.keys(TOKEN_GROUPS.shadow)) v[`--ngos-shadow-${k}`] = 'shadow';
  for (const id of Object.keys(FONT_STACKS)) v[`--ngos-stack-${id}`] = 'stack';
  v['--ngos-font-body'] = 'font';
  v['--ngos-font-heading'] = 'font';
  v['--ngos-space-unit'] = 'space';
  for (let i = 1; i <= 8; i += 1) v[`--ngos-space-${i}`] = 'space';
  return Object.freeze(v);
})();
export const SPACE_STEPS = Object.freeze([1, 2, 3, 4, 6, 8, 12, 16]);

// ---------------------------------------------------------------------------------------------------------------------
// 2. Small helpers
// ---------------------------------------------------------------------------------------------------------------------

const isObj = (v) => v !== null && typeof v === 'object' && !Array.isArray(v);
const own = (o, k) => Object.prototype.hasOwnProperty.call(o, k);
/** A short, safe piece of text for a message: no control characters, cut short. */
const clip = (value, max = 70) => {
  const s = String(value ?? '').replace(/[\u0000-\u001f\u007f-\u009f]/g, ' ').replace(/\s+/g, ' ').trim();
  return s.length > max ? `${s.slice(0, max - 1)}...` : s;
};
const list = (items, last = 'and') => (items.length <= 1 ? items.join('') : `${items.slice(0, -1).join(', ')} ${last} ${items[items.length - 1]}`);

/** Shapes of secrets that must never be in a pack. Used in addition to a stricter scanner the caller may pass (the repository's own list). */
const SECRET_SHAPES = [
  [/sk-[A-Za-z0-9_-]{20,}/, 'an API key (sk-...)'], [/\bAKIA[0-9A-Z]{16}\b/, 'an AWS access key'], [/AIza[0-9A-Za-z_-]{30,}/, 'a Google API key'],
  [/\b(?:ghp|gho|ghs|ghu|github_pat)_[A-Za-z0-9_]{20,}/, 'a GitHub token'], [/\bgsk_[A-Za-z0-9]{20,}/, 'an API key (gsk_...)'], [/\bnpg_[A-Za-z0-9]{10,}/, 'a database password'],
  [/-----BEGIN [A-Z ]*PRIVATE KEY-----/, 'a private key'], [/\b[a-z][a-z0-9+.-]*:\/\/[^\s"'<>:@/]+:[^\s"'<>@/]{3,}@/i, 'an address with a password in it'],
  [/\beyJ[A-Za-z0-9_-]{10,}\.[A-Za-z0-9_-]{10,}\.[A-Za-z0-9_-]{10,}/, 'a sign-in token (JWT)'], [/\b(?:password|passwd|secret|api[_-]?key|token)\s*[:=]\s*["']?[^\s"';]{8,}/i, 'a password, secret or key written out'],
];

/** Collects problems: { code, where, what, why }, each in plain words. Stops at LIMITS.problems and says so. */
class Sink {
  constructor() { this.list = []; this.seen = new Set(); this.truncated = false; }
  add(code, where, what, why) {
    const key = `${code}|${where}|${what}`;
    if (this.seen.has(key)) return;
    if (this.list.length >= LIMITS.problems) { this.truncated = true; return; }
    this.seen.add(key);
    this.list.push({ code, where, what, why });
  }
  get ok() { return this.list.length === 0; }
  finish() {
    if (this.truncated) this.list.push({ code: 'many-problems', where: 'the pack', what: `There are more than ${LIMITS.problems} problems; only the first ${LIMITS.problems} are listed.`, why: 'Fix these first and check again.' });
    return this.list;
  }
}

/** Looks for something that looks like a secret in `text`. Returns the kinds found (never the text itself). */
function secretsIn(text, extra) {
  const found = [];
  for (const [re, what] of SECRET_SHAPES) if (re.test(text)) found.push(what);
  if (typeof extra === 'function') { try { for (const k of extra(text) || []) if (!found.includes(k)) found.push(String(k)); } catch { /* a scanner that fails must not make a bad pack pass: it is ignored, the built-in shapes still apply */ } }
  return found;
}

// ---------------------------------------------------------------------------------------------------------------------
// 3. The CSS tokenizer (CSS Syntax Level 3, written to follow the specification so that this reading and a browser's agree)
//    Escapes (a backslash) are only understood inside quoted text; anywhere else they are refused.
// ---------------------------------------------------------------------------------------------------------------------

const isDigit = (c) => c >= 48 && c <= 57;
const isHexDigit = (c) => isDigit(c) || (c >= 65 && c <= 70) || (c >= 97 && c <= 102);
const isLetter = (c) => (c >= 65 && c <= 90) || (c >= 97 && c <= 122);
const isIdentStart = (c) => isLetter(c) || c === 95 || c >= 0x80;
const isIdentChar = (c) => isIdentStart(c) || isDigit(c) || c === 45;
const isWs = (c) => c === 32 || c === 9 || c === 10;

/**
 * Turns style sheet text into tokens. Returns { tokens, errors } where an error is { code, what, why }.
 * Token types: ws, ident, function, atkw, hash, string, url, num, pct, dim, delim, comma, colon, semi, open (, [, {), close (), ], }).
 */
export function tokenizeCss(input) {
  const errors = [];
  const err = (code, what, why) => { if (!errors.some((e) => e.code === code)) errors.push({ code, what, why }); };
  const src = String(input ?? '').replace(/^﻿/, '').replace(/\r\n?|\f/g, '\n');
  const n = src.length;
  const tokens = [];
  let i = 0;
  const at = (k) => (k < n ? src.charCodeAt(k) : -1);

  const startsIdent = (k) => {
    const c = at(k);
    if (c === 45) { const d = at(k + 1); return isIdentStart(d) || d === 45 || (d === 92 && at(k + 2) !== 10 && at(k + 2) !== -1); }
    if (isIdentStart(c)) return true;
    return c === 92 && at(k + 1) !== 10 && at(k + 1) !== -1;
  };
  const startsNumber = (k) => {
    const c = at(k);
    if (c === 43 || c === 45) { const d = at(k + 1); return isDigit(d) || (d === 46 && isDigit(at(k + 2))); }
    if (c === 46) return isDigit(at(k + 1));
    return isDigit(c);
  };

  // A name: letters, digits, "-" and "_" (non-ASCII letters are read but refused later). A backslash is refused: it is how "\6a avascript" hides a word.
  function consumeName() {
    let out = '';
    for (;;) {
      const c = at(i);
      if (isIdentChar(c)) { if (c >= 0x80) err('non-ascii-name', 'A name in the style sheet uses a letter that is not plain A to Z.', 'Names (properties, parts, words like "flex") are written with plain English letters, so that nothing can hide behind a look-alike letter.'); out += src[i]; i += 1; }
      else if (c === 92) { err('escape', 'A name in the style sheet uses a backslash escape (like \\6a).', 'Backslash escapes are only allowed inside quoted text. In names they can be used to spell a forbidden word so that a checker does not recognise it.'); i += 1; if (i < n) i += 1; }
      else break;
    }
    return out;
  }
  function consumeNumber() {
    const start = i;
    if (at(i) === 43 || at(i) === 45) i += 1;
    while (isDigit(at(i))) i += 1;
    let int = true;
    if (at(i) === 46 && isDigit(at(i + 1))) { int = false; i += 1; while (isDigit(at(i))) i += 1; }
    if ((at(i) === 101 || at(i) === 69) && (isDigit(at(i + 1)) || ((at(i + 1) === 43 || at(i + 1) === 45) && isDigit(at(i + 2))))) { int = false; i += 2; while (isDigit(at(i))) i += 1; }
    const repr = src.slice(start, i);
    return { v: Number(repr), repr, int };
  }
  /** Quoted text, with escapes understood. Returns the text, or null when it is broken. */
  function consumeString(quote) {
    i += 1;
    let out = '';
    for (;;) {
      if (i >= n) { err('open-string', 'A piece of quoted text is never closed.', 'Every quote must be closed before the end of the line.'); return null; }
      const c = at(i);
      if (c === quote) { i += 1; return out; }
      if (c === 10) { err('open-string', 'A piece of quoted text runs onto the next line.', 'Every quote must be closed on the line where it starts.'); return null; }
      if (c === 92) {
        i += 1;
        if (i >= n) continue;
        if (at(i) === 10) { i += 1; continue; }
        if (isHexDigit(at(i))) {
          let hex = '';
          while (hex.length < 6 && isHexDigit(at(i))) { hex += src[i]; i += 1; }
          if (isWs(at(i))) i += 1;
          let cp = parseInt(hex, 16);
          if (cp === 0 || cp > 0x10ffff || (cp >= 0xd800 && cp <= 0xdfff)) cp = 0xfffd;
          out += String.fromCodePoint(cp);
        } else { out += src[i]; i += 1; }
        continue;
      }
      out += src[i];
      i += 1;
    }
  }

  while (i < n) {
    const c = at(i);
    if (isWs(c)) { while (isWs(at(i))) i += 1; tokens.push({ t: 'ws' }); continue; }
    if (c === 47 && at(i + 1) === 42) {
      const end = src.indexOf('*/', i + 2);
      if (end < 0) { err('open-comment', 'A comment is never closed.', 'A comment that is never closed would swallow everything after it, and what a browser keeps from it can differ from what was checked.'); i = n; } else i = end + 2;
      continue;
    }
    if (c === 34 || c === 39) {
      const s = consumeString(c);
      if (s !== null && s.includes('<')) err('angle', 'A piece of quoted text in the style sheet contains the character <.', 'A "<" has no place in a pack\'s style sheet, and "</style" or "<!--" could break out of a page if the sheet were ever placed inside one.');
      tokens.push({ t: 'string', v: s ?? '' });
      continue;
    }
    if (c === 35) {
      if (isIdentChar(at(i + 1)) || (at(i + 1) === 92 && at(i + 2) !== 10)) { i += 1; const v = consumeName(); tokens.push({ t: 'hash', v }); } else { tokens.push({ t: 'delim', v: '#' }); i += 1; }
      continue;
    }
    if (c === 40 || c === 91 || c === 123) { tokens.push({ t: 'open', v: src[i] }); i += 1; continue; }
    if (c === 41 || c === 93 || c === 125) { tokens.push({ t: 'close', v: src[i] }); i += 1; continue; }
    if (c === 44) { tokens.push({ t: 'comma' }); i += 1; continue; }
    if (c === 58) { tokens.push({ t: 'colon' }); i += 1; continue; }
    if (c === 59) { tokens.push({ t: 'semi' }); i += 1; continue; }
    if (c === 60) { err('angle', 'The style sheet contains the character <.', 'A "<" has no place in a pack\'s style sheet, and "</style" or "<!--" could break out of a page if the sheet were ever placed inside one.'); tokens.push({ t: 'delim', v: '<' }); i += 1; continue; }
    if (c === 64) {
      if (startsIdent(i + 1)) { i += 1; const v = consumeName(); tokens.push({ t: 'atkw', v: v.toLowerCase() }); } else { tokens.push({ t: 'delim', v: '@' }); i += 1; }
      continue;
    }
    if (c === 92) { err('escape', 'The style sheet uses a backslash outside quoted text.', 'Backslash escapes are only allowed inside quoted text. Outside it they can be used to spell a forbidden word so that a checker does not recognise it.'); i += 2; tokens.push({ t: 'delim', v: '\\' }); continue; }
    if (startsNumber(i)) {
      const num = consumeNumber();
      if (startsIdent(i)) { const unit = consumeName(); tokens.push({ t: 'dim', v: num.v, repr: num.repr, int: false, unit: unit.toLowerCase() }); } else if (at(i) === 37) { i += 1; tokens.push({ t: 'pct', v: num.v, repr: num.repr }); } else tokens.push({ t: 'num', v: num.v, repr: num.repr, int: num.int });
      continue;
    }
    if (c === 45 && at(i + 1) === 45 && at(i + 2) === 62) { err('angle', 'The style sheet contains "-->".', 'A "-->" has no place in a pack\'s style sheet.'); i += 3; tokens.push({ t: 'delim', v: '-' }); continue; }
    if (startsIdent(i)) {
      const name = consumeName();
      if (at(i) === 40) {
        if (name.toLowerCase() === 'url') {
          // url( "..." ) is a function with a string; url(...) with no quote is read as one piece (spec section 4.3.6).
          let k = i + 1;
          while (isWs(at(k))) k += 1;
          if (at(k) === 34 || at(k) === 39) { i += 1; tokens.push({ t: 'function', v: 'url' }); } else {
            i += 1;
            while (isWs(at(i))) i += 1;
            let out = '';
            let bad = false;
            for (;;) {
              if (i >= n) { bad = true; break; }
              const d = at(i);
              if (d === 41) { i += 1; break; }
              if (isWs(d)) { while (isWs(at(i))) i += 1; if (at(i) === 41) { i += 1; break; } bad = true; continue; }
              if (d === 34 || d === 39 || d === 40 || d < 32 || d === 127) { bad = true; i += 1; continue; }
              if (d === 92) { bad = true; i += 2; continue; }
              out += src[i]; i += 1;
            }
            if (bad) { err('bad-url', 'A url(...) is written in a way a browser reads differently from a checker.', 'Write addresses in quotes, like url("assets/photo.webp").'); tokens.push({ t: 'url', v: out, bad: true }); } else tokens.push({ t: 'url', v: out });
          }
        } else { i += 1; tokens.push({ t: 'function', v: name.toLowerCase() }); }
      } else tokens.push({ t: 'ident', v: name.toLowerCase(), raw: name });
      continue;
    }
    if (c < 32 && c !== 9 && c !== 10) { err('control', 'The style sheet contains a control character.', 'A style sheet is plain text.'); i += 1; continue; }
    tokens.push({ t: 'delim', v: src[i] });
    i += 1;
  }
  return { tokens, errors };
}

// ---------------------------------------------------------------------------------------------------------------------
// 4. From tokens to a tree of nodes: functions and brackets hold what is inside them
// ---------------------------------------------------------------------------------------------------------------------

/**
 * Nodes: tokens, plus { t: 'fn', name, items } and { t: 'block', open, items }. Returns { items, errors }.
 * A closing bracket that does not match, a bracket never closed, or nesting deeper than LIMITS.nesting is an error.
 */
export function buildTree(tokens) {
  const errors = [];
  const err = (code, what, why) => { if (!errors.some((e) => e.code === code)) errors.push({ code, what, why }); };
  const root = { t: 'root', items: [] };
  const stack = [root];
  const closer = { '(': ')', '[': ']', '{': '}' };
  for (const tok of tokens) {
    const top = stack[stack.length - 1];
    if (tok.t === 'function') {
      const node = { t: 'fn', name: tok.v, items: [], close: ')' };
      top.items.push(node); stack.push(node);
    } else if (tok.t === 'open') {
      const node = { t: 'block', open: tok.v, items: [], close: closer[tok.v] };
      top.items.push(node); stack.push(node);
    } else if (tok.t === 'close') {
      if (stack.length > 1 && top.close === tok.v) stack.pop();
      else { err('unbalanced', 'A bracket in the style sheet does not match.', 'Every ( [ { needs its closing ) ] }.'); }
    } else top.items.push(tok);
    if (stack.length > LIMITS.nesting + 1) { err('too-deep', 'The style sheet nests brackets too deeply.', `Brackets are nested more than ${LIMITS.nesting} deep.`); break; }
  }
  if (stack.length > 1) err('unbalanced', 'A bracket in the style sheet is never closed.', 'Every ( [ { needs its closing ) ] }.');
  return { items: root.items, errors };
}

// ---------------------------------------------------------------------------------------------------------------------
// 5. Rules: split the tree into rules, at-rules and declarations
// ---------------------------------------------------------------------------------------------------------------------

const sig = (items) => items.filter((x) => x.t !== 'ws');
const splitOn = (items, t) => { const out = [[]]; for (const it of items) { if (it.t === t) out.push([]); else out[out.length - 1].push(it); } return out; };

/** Writes nodes back as text, in one canonical form (single spaces, ", " between list items). Only nodes this checker accepts ever get here. */
export function nodeText(node) {
  switch (node.t) {
    case 'ident': return node.v;
    case 'num': return node.repr;
    case 'dim': return `${node.repr}${node.unit}`;
    case 'pct': return `${node.repr}%`;
    case 'hash': return `#${node.v}`;
    case 'string': return `"${String(node.v).replace(/[\\"]/g, '\\$&').replace(/\n/g, '\\a ')}"`;
    case 'url': return `url("${String(node.v).replace(/[\\"]/g, '\\$&')}")`;
    case 'comma': return ',';
    case 'colon': return ':';
    case 'delim': return node.v;
    case 'fn': return `${node.name}(${nodesText(node.items)})`;
    case 'block': return `${node.open}${nodesText(node.items)}${node.close}`;
    default: return '';
  }
}
export function nodesText(items) {
  const out = [];
  for (const it of items) {
    if (it.t === 'ws') continue;
    if (it.t === 'comma' || it.t === 'colon') { if (out.length) out[out.length - 1] += nodeText(it); else out.push(nodeText(it)); continue; }
    out.push(nodeText(it));
  }
  return out.join(' ');
}

/** Rules and at-rules at one level: { kind: 'style'|'at', name?, prelude, body } (body: the items inside { }, or null for an at-rule that ends with ";"). */
function splitRules(items, problem) {
  const rules = [];
  let i = 0;
  while (i < items.length) {
    while (i < items.length && (items[i].t === 'ws' || items[i].t === 'semi')) i += 1;
    if (i >= items.length) break;
    let j = i;
    while (j < items.length && !(items[j].t === 'block' && items[j].open === '{') && items[j].t !== 'semi') j += 1;
    const prelude = items.slice(i, j);
    const first = sig(prelude)[0];
    const isAt = first && first.t === 'atkw';
    if (j < items.length && items[j].t === 'block') { rules.push({ kind: isAt ? 'at' : 'style', name: isAt ? first.v : null, prelude: isAt ? prelude.slice(prelude.indexOf(first) + 1) : prelude, body: items[j].items }); i = j + 1; } else if (isAt) { rules.push({ kind: 'at', name: first.v, prelude: prelude.slice(prelude.indexOf(first) + 1), body: null }); i = j + 1; } else {
      problem('half-rule', 'A rule in the style sheet has no { } block.', `"${clip(nodesText(prelude), 50)}" is not followed by a block of settings.`);
      i = j + 1;
    }
  }
  return rules;
}

/** The "name: value" settings inside a block. Returns { decls: [{ name, value, important }], nested }. A nested rule (a { } inside) is reported, never read. */
function splitDeclarations(items, problem) {
  const decls = [];
  let nested = false;
  for (const chunk of splitOn(items, 'semi')) {
    const s = sig(chunk);
    if (s.length === 0) continue;
    if (s.some((x) => x.t === 'block' && x.open === '{')) { nested = true; continue; }
    if (s[0].t !== 'ident' || !s[1] || s[1].t !== 'colon') { problem('not-a-setting', 'Something in the style sheet is not a "name: value" setting.', `"${clip(nodesText(chunk), 60)}" is not a setting.`); continue; }
    let value = chunk.slice(chunk.indexOf(s[1]) + 1);
    let important = false;
    const vs = sig(value);
    const n = vs.length;
    if (n >= 2 && vs[n - 2].t === 'delim' && vs[n - 2].v === '!' && vs[n - 1].t === 'ident' && vs[n - 1].v === 'important') { important = true; value = value.slice(0, value.lastIndexOf(vs[n - 2])); } else if (vs.some((x) => x.t === 'delim' && x.v === '!')) important = true;
    decls.push({ name: s[0].v, value, important });
  }
  return { decls, nested };
}

// ---------------------------------------------------------------------------------------------------------------------
// 6. Selectors: only the hooks, a few states, nothing that could reach a form, a field or a notice that is not a hook
// ---------------------------------------------------------------------------------------------------------------------

const PSEUDO_CLASSES = new Set(['hover', 'focus', 'focus-visible', 'focus-within', 'active', 'first-child', 'last-child', 'only-child', 'disabled']);
const PSEUDO_ELEMENTS = new Set(['before', 'after', 'selection', 'placeholder', 'marker', 'first-letter', 'first-line']);
const LEGACY_PSEUDO_ELEMENTS = new Set(['before', 'after', 'first-letter', 'first-line']);

const attributeWhy = 'A pack may only style the parts the website names (data-ngos-part). A selector on anything else could reach a sign-in form, a field, a licence or legal notice, or a part of the page that is not meant to be changed.';

/** Parses one selector list into [{ compounds: [{ part, state, classes, element }], combinators, subject, text }] or null (problems are reported). */
function parseSelectorList(prelude, problem) {
  const lists = splitOn(prelude, 'comma');
  const out = [];
  let bad = false;
  const fail = (code, what, why) => { bad = true; problem(code, what, why); };
  if (lists.length > LIMITS.selectorsPerRule) fail('too-many-selectors', `A rule has more than ${LIMITS.selectorsPerRule} selectors.`, 'Split it into several rules.');
  for (const raw of lists) {
    const items = raw.slice();
    while (items.length && items[0].t === 'ws') items.shift();
    while (items.length && items[items.length - 1].t === 'ws') items.pop();
    if (items.length === 0) { fail('empty-selector', 'A selector is empty.', 'There is a comma with nothing before or after it.'); continue; }
    const compounds = [];
    const combinators = [];
    let cur = null;
    let pending = null;
    const flush = () => { if (cur) { compounds.push(cur); cur = null; } };
    const fresh = () => ({ part: null, state: null, classes: [], element: null, hasAttr: 0 });
    let broken = false;
    const stop = (code, what, why) => { fail(code, what, why); broken = true; };
    for (let k = 0; k < items.length && !broken; k += 1) {
      const it = items[k];
      if (it.t === 'ws') {
        if (cur) { flush(); pending = pending ?? ' '; }
        continue;
      }
      if (it.t === 'delim' && it.v === '>') { flush(); pending = '>'; continue; }
      if (!cur) {
        if (compounds.length > 0) { combinators.push(pending ?? ' '); }
        pending = null;
        cur = fresh();
      } else if (pending) pending = null;
      if (it.t === 'block' && it.open === '[') {
        const s = sig(it.items);
        const name = s[0] && s[0].t === 'ident' ? s[0].v : null;
        if (s.length !== 3 || !name || s[1].t !== 'delim' || s[1].v !== '=' || (s[2].t !== 'string' && s[2].t !== 'ident')) { stop('selector-attribute', `The selector "[${clip(nodesText(it.items), 40)}]" is not one of the allowed forms.`, `${attributeWhy} Write [data-ngos-part="header"].`); break; }
        const value = s[2].t === 'string' ? s[2].v : s[2].raw;
        if (name === 'data-ngos-part') {
          if (cur.part) { stop('selector-two-parts', 'A selector names two parts at once.', 'An element has only one part name, so such a selector could never match. Put them one after the other with a space.'); break; }
          if (!own(PARTS, value)) { stop('unknown-part', `There is no part called "${clip(value, 40)}".`, `The parts are: ${Object.keys(PARTS).join(', ')}.`); break; }
          cur.part = value;
        } else if (name === 'data-ngos-state') {
          if (cur.state) { stop('selector-two-states', 'A selector names two states at once.', 'An element has one state at a time.'); break; }
          cur.state = value;
        } else { stop('selector-attribute', `The selector [${clip(name, 30)}=...] is not allowed.`, attributeWhy); break; }
        continue;
      }
      if (it.t === 'colon') {
        const nx = items[k + 1];
        if (nx && nx.t === 'colon') {
          const el = items[k + 2];
          if (!el || el.t !== 'ident' || !PSEUDO_ELEMENTS.has(el.v)) { stop('pseudo-element', `The pseudo-element "::${clip(el?.raw ?? '', 20)}" is not allowed.`, `Allowed: ${[...PSEUDO_ELEMENTS].map((x) => `::${x}`).join(', ')}.`); break; }
          if (cur.element) { stop('pseudo-element', 'A selector uses two pseudo-elements.', 'Only one is possible.'); break; }
          cur.element = el.v; k += 2; continue;
        }
        if (nx && nx.t === 'ident') {
          if (LEGACY_PSEUDO_ELEMENTS.has(nx.v)) { cur.element = nx.v; k += 1; continue; }
          if (!PSEUDO_CLASSES.has(nx.v)) { stop('pseudo-class', `The state ":${clip(nx.raw, 20)}" is not allowed.`, `Allowed: ${[...PSEUDO_CLASSES].map((x) => `:${x}`).join(', ')}, :nth-child(...).`); break; }
          if (cur.element) { stop('pseudo-class', 'A state comes after a pseudo-element.', 'Write the state first: ...:hover::before.'); break; }
          cur.classes.push(nx.v); k += 1; continue;
        }
        if (nx && nx.t === 'fn' && nx.name === 'nth-child') {
          const text = sig(nx.items).map(nodeText).join('');
          if (!/^(odd|even|-?\d{1,2}|-?\d{0,2}n([+-]\d{1,2})?)$/.test(text)) { stop('pseudo-class', 'The ":nth-child(...)" is not in a simple form.', 'Use odd, even, a number, or a form like 2n+1.'); break; }
          cur.classes.push(`nth-child(${text})`); k += 1; continue;
        }
        stop('pseudo-class', 'A ":" in a selector is not one of the allowed states.', `Allowed: ${[...PSEUDO_CLASSES].map((x) => `:${x}`).join(', ')}, :nth-child(...).`);
        break;
      }
      if (it.t === 'ident') { stop('selector-element', `The selector "${clip(it.raw, 30)}" names an element (or something else) that is not a part.`, attributeWhy); break; }
      if (it.t === 'hash') { stop('selector-id', `The selector "#${clip(it.v, 30)}" targets one element by its id.`, attributeWhy); break; }
      if (it.t === 'delim' && it.v === '.') { stop('selector-class', 'A selector uses a class (".name").', attributeWhy); break; }
      if (it.t === 'delim' && it.v === '*') { stop('selector-all', 'A selector uses "*" (everything).', attributeWhy); break; }
      if (it.t === 'delim' && (it.v === '+' || it.v === '~')) { stop('selector-sibling', `The combinator "${it.v}" is not allowed.`, 'Only a space (inside) and ">" (directly inside) are allowed between parts.'); break; }
      stop('selector-form', `Something in a selector is not allowed ("${clip(nodesText([it]), 20)}").`, attributeWhy);
    }
    if (broken) continue;
    flush();
    if (compounds.length === 0) { fail('empty-selector', 'A selector is empty.', 'There is nothing to style.'); continue; }
    if (pending === '>') { fail('selector-form', 'A selector ends with ">".', 'Name the part after it.'); continue; }
    if (compounds.length > LIMITS.compoundsPerSelector) { fail('selector-long', `A selector has more than ${LIMITS.compoundsPerSelector} parts.`, 'Keep selectors short.'); continue; }
    let wrong = false;
    compounds.forEach((c, idx) => {
      if (wrong) return;
      if (!c.part) { wrong = true; fail('selector-no-part', 'A selector has a piece that does not name a part.', `${attributeWhy} Start each piece with [data-ngos-part="..."].`); return; }
      if (c.state && !(PARTS[c.part].states || []).includes(c.state)) { wrong = true; const known = PARTS[c.part].states; fail('unknown-state', `The part "${c.part}" has no state "${clip(c.state, 30)}".`, known ? `It has: ${known.join(', ')}.` : 'It has no states.'); return; }
      if (c.element && idx !== compounds.length - 1) { wrong = true; fail('pseudo-element', 'A pseudo-element is not at the end of a selector.', 'It can only come after the last part.'); }
    });
    if (wrong) continue;
    const subject = compounds[compounds.length - 1];
    const text = compounds.map((c, idx) => `${idx ? ` ${combinators[idx - 1] === '>' ? '> ' : ''}` : ''}[data-ngos-part="${c.part}"]${c.state ? `[data-ngos-state="${c.state}"]` : ''}${c.classes.map((x) => `:${x}`).join('')}${c.element ? `::${c.element}` : ''}`).join('');
    out.push({ compounds, combinators, subject: subject.part, element: subject.element, classes: subject.classes, text });
  }
  return bad || out.length === 0 ? null : out;
}

// ---------------------------------------------------------------------------------------------------------------------
// 7. At-rules: @media and @supports (conditions only), @keyframes; everything else is refused with a reason
// ---------------------------------------------------------------------------------------------------------------------

const AT_RULE_WHY = {
  import: 'It pulls in another file from somewhere else, and that file could change at any time or be a tracking address. Everything a pack uses must be inside the pack.',
  'font-face': 'Fonts are declared in the pack\'s "fontFiles" list, which is checked, so that no other address can sneak in.',
  charset: 'It is not needed: a pack is plain UTF-8 text.',
  namespace: 'It changes what element names mean, and is not needed.',
  layer: 'Layers decide which rule wins; a pack must not reorder the website\'s own rules.',
  container: 'It is not supported in a pack yet.',
  property: 'It registers new kinds of custom properties; a pack uses the tokens instead.',
  page: 'It is for printing and is not supported in a pack.',
  scope: 'It is not supported in a pack yet.',
  'starting-style': 'It is not supported in a pack yet.',
  'view-transition': 'It is not supported in a pack yet.',
  'counter-style': 'It is not supported in a pack yet.',
  'font-feature-values': 'It is not supported in a pack yet.',
  document: 'It can pick pages by their address, which is not allowed.',
  '-moz-document': 'It can pick pages by their address, which is not allowed.',
  viewport: 'It changes how the page is scaled on a phone, which is not allowed.',
  tailwind: 'A pack is plain style rules, not a Tailwind file.',
  apply: 'A pack is plain style rules, not a Tailwind file.',
  media: '',
};

const MEDIA_FEATURES = {
  width: 'size', height: 'size', 'min-width': 'size', 'max-width': 'size', 'min-height': 'size', 'max-height': 'size',
  orientation: ['portrait', 'landscape'], 'prefers-color-scheme': ['light', 'dark'], 'prefers-reduced-motion': ['reduce', 'no-preference'], 'prefers-contrast': ['more', 'less', 'no-preference', 'custom'],
  hover: ['hover', 'none'], 'any-hover': ['hover', 'none'], pointer: ['fine', 'coarse', 'none'], 'any-pointer': ['fine', 'coarse', 'none'],
  'display-mode': ['browser', 'standalone', 'minimal-ui', 'fullscreen'], 'forced-colors': ['active', 'none'],
  resolution: 'resolution', 'min-resolution': 'resolution', 'max-resolution': 'resolution', 'aspect-ratio': 'ratio', 'min-aspect-ratio': 'ratio', 'max-aspect-ratio': 'ratio',
};

/** Checks the condition of @media. Returns the canonical text or null (problems reported). */
function checkMediaCondition(prelude, problem) {
  const s = sig(prelude);
  if (s.length === 0) return '';
  const words = new Set(['screen', 'print', 'all', 'only', 'not', 'and', 'or']);
  const parts = [];
  for (const node of s) {
    if (node.t === 'comma') { parts.push(','); continue; }
    if (node.t === 'ident' && words.has(node.v)) { parts.push(node.v); continue; }
    if (node.t === 'block' && node.open === '(') {
      const inner = sig(node.items);
      const name = inner[0] && inner[0].t === 'ident' ? inner[0].v : null;
      const kind = name ? MEDIA_FEATURES[name] : undefined;
      if (!kind) { problem('media-condition', `The @media condition "(${clip(nodesText(node.items), 40)})" is not one the pack may use.`, `Allowed: ${Object.keys(MEDIA_FEATURES).join(', ')}.`); return null; }
      if (inner.length === 1) { parts.push(`(${name})`); continue; }
      if (inner[1].t !== 'colon' || inner.length < 3) { problem('media-condition', `The @media condition "(${clip(nodesText(node.items), 40)})" is not written as (name: value).`, 'Write (min-width: 40rem), for example.'); return null; }
      const v = inner.slice(2);
      let ok = false;
      if (kind === 'size') ok = v.length === 1 && ((v[0].t === 'dim' && ['px', 'em', 'rem'].includes(v[0].unit) && v[0].v >= 0 && v[0].v <= 4000) || (v[0].t === 'num' && v[0].v === 0));
      else if (kind === 'resolution') ok = v.length === 1 && v[0].t === 'dim' && ['dppx', 'dpi', 'x'].includes(v[0].unit) && v[0].v > 0 && v[0].v < 1000;
      else if (kind === 'ratio') ok = (v.length === 1 && v[0].t === 'num') || (v.length === 3 && v[0].t === 'num' && v[1].t === 'delim' && v[1].v === '/' && v[2].t === 'num');
      else ok = v.length === 1 && v[0].t === 'ident' && kind.includes(v[0].v);
      if (!ok) { problem('media-condition', `The value in the @media condition "(${clip(nodesText(node.items), 40)})" is not allowed.`, kind === 'size' ? 'Use px, em or rem.' : Array.isArray(kind) ? `Allowed: ${kind.join(', ')}.` : 'Check the number.'); return null; }
      parts.push(`(${name}: ${nodesText(v)})`);
      continue;
    }
    problem('media-condition', `The @media condition has something that is not allowed ("${clip(nodesText([node]), 30)}").`, 'Use media types (screen, print, all), and, or, not, and conditions in brackets.');
    return null;
  }
  return parts.join(' ').replace(/ ,/g, ',');
}

const SUPPORTS_FUNCTIONS = new Set(['blur', 'rgb', 'rgba', 'hsl', 'hsla', 'saturate', 'brightness']);
function checkSupportsCondition(prelude, problem) {
  const s = sig(prelude);
  if (s.length === 0) { problem('supports-condition', '@supports has no condition.', 'Write (property: value).'); return null; }
  const walk = (nodes, depth) => {
    const parts = [];
    for (const node of nodes) {
      if (node.t === 'ident' && ['and', 'or', 'not'].includes(node.v)) { parts.push(node.v); continue; }
      if (node.t === 'block' && node.open === '(') {
        const inner = sig(node.items);
        if (inner[0] && inner[0].t === 'ident' && inner[1] && inner[1].t === 'colon') {
          const name = inner[0].v;
          if (!/^-?[a-z][a-z-]{0,48}$/.test(name) || name.startsWith('--')) { problem('supports-condition', `The @supports property "${clip(name, 30)}" is not allowed.`, 'Name a normal property.'); return null; }
          const v = inner.slice(2);
          const okValue = v.length > 0 && v.every((x) => ['ident', 'num', 'dim', 'pct', 'hash', 'comma'].includes(x.t) || (x.t === 'delim' && x.v === '/') || (x.t === 'fn' && SUPPORTS_FUNCTIONS.has(x.name) && sig(x.items).every((y) => ['num', 'dim', 'pct', 'comma'].includes(y.t) || (y.t === 'ident' && y.v === 'none') || (y.t === 'delim' && y.v === '/'))));
          if (!okValue) { problem('supports-condition', `The @supports test "(${clip(nodesText(node.items), 40)})" has a value that is not allowed.`, 'Test a simple value, such as (display: grid) or (backdrop-filter: blur(4px)).'); return null; }
          parts.push(`(${name}: ${nodesText(v)})`);
          continue;
        }
        if (depth >= 3) { problem('supports-condition', '@supports conditions are nested too deeply.', 'Keep them simple.'); return null; }
        const innerParts = walk(inner, depth + 1);
        if (!innerParts) return null;
        parts.push(`(${innerParts})`);
        continue;
      }
      problem('supports-condition', `The @supports condition has something that is not allowed ("${clip(nodesText([node]), 30)}").`, 'Use (property: value) with and, or, not. Tests of selectors, fonts or urls are not allowed.');
      return null;
    }
    return parts.join(' ');
  };
  return walk(s, 0);
}

// ---------------------------------------------------------------------------------------------------------------------
// 8. Values: colours, lengths, pictures, shadows, movement. Every checker answers null (fine) or a reason in plain words.
// ---------------------------------------------------------------------------------------------------------------------

const NAMED = Object.fromEntries(('aliceblue:f0f8ff antiquewhite:faebd7 aqua:00ffff aquamarine:7fffd4 azure:f0ffff beige:f5f5dc bisque:ffe4c4 black:000000 blanchedalmond:ffebcd blue:0000ff blueviolet:8a2be2 brown:a52a2a burlywood:deb887 '
  + 'cadetblue:5f9ea0 chartreuse:7fff00 chocolate:d2691e coral:ff7f50 cornflowerblue:6495ed cornsilk:fff8dc crimson:dc143c cyan:00ffff darkblue:00008b darkcyan:008b8b darkgoldenrod:b8860b darkgray:a9a9a9 darkgreen:006400 '
  + 'darkgrey:a9a9a9 darkkhaki:bdb76b darkmagenta:8b008b darkolivegreen:556b2f darkorange:ff8c00 darkorchid:9932cc darkred:8b0000 darksalmon:e9967a darkseagreen:8fbc8f darkslateblue:483d8b darkslategray:2f4f4f '
  + 'darkslategrey:2f4f4f darkturquoise:00ced1 darkviolet:9400d3 deeppink:ff1493 deepskyblue:00bfff dimgray:696969 dimgrey:696969 dodgerblue:1e90ff firebrick:b22222 floralwhite:fffaf0 forestgreen:228b22 fuchsia:ff00ff '
  + 'gainsboro:dcdcdc ghostwhite:f8f8ff gold:ffd700 goldenrod:daa520 gray:808080 green:008000 greenyellow:adff2f grey:808080 honeydew:f0fff0 hotpink:ff69b4 indianred:cd5c5c indigo:4b0082 ivory:fffff0 khaki:f0e68c '
  + 'lavender:e6e6fa lavenderblush:fff0f5 lawngreen:7cfc00 lemonchiffon:fffacd lightblue:add8e6 lightcoral:f08080 lightcyan:e0ffff lightgoldenrodyellow:fafad2 lightgray:d3d3d3 lightgreen:90ee90 lightgrey:d3d3d3 '
  + 'lightpink:ffb6c1 lightsalmon:ffa07a lightseagreen:20b2aa lightskyblue:87cefa lightslategray:778899 lightslategrey:778899 lightsteelblue:b0c4de lightyellow:ffffe0 lime:00ff00 limegreen:32cd32 linen:faf0e6 '
  + 'magenta:ff00ff maroon:800000 mediumaquamarine:66cdaa mediumblue:0000cd mediumorchid:ba55d3 mediumpurple:9370db mediumseagreen:3cb371 mediumslateblue:7b68ee mediumspringgreen:00fa9a mediumturquoise:48d1cc '
  + 'mediumvioletred:c71585 midnightblue:191970 mintcream:f5fffa mistyrose:ffe4e1 moccasin:ffe4b5 navajowhite:ffdead navy:000080 oldlace:fdf5e6 olive:808000 olivedrab:6b8e23 orange:ffa500 orangered:ff4500 orchid:da70d6 '
  + 'palegoldenrod:eee8aa palegreen:98fb98 paleturquoise:afeeee palevioletred:db7093 papayawhip:ffefd5 peachpuff:ffdab9 peru:cd853f pink:ffc0cb plum:dda0dd powderblue:b0e0e6 purple:800080 rebeccapurple:663399 red:ff0000 '
  + 'rosybrown:bc8f8f royalblue:4169e1 saddlebrown:8b4513 salmon:fa8072 sandybrown:f4a460 seagreen:2e8b57 seashell:fff5ee sienna:a0522d silver:c0c0c0 skyblue:87ceeb slateblue:6a5acd slategray:708090 slategrey:708090 '
  + 'snow:fffafa springgreen:00ff7f steelblue:4682b4 tan:d2b48c teal:008080 thistle:d8bfd8 tomato:ff6347 turquoise:40e0d0 violet:ee82ee wheat:f5deb3 white:ffffff whitesmoke:f5f5f5 yellow:ffff00 yellowgreen:9acd32')
  .split(' ').map((x) => x.split(':')));

const hexToRgba = (hex) => {
  const h = hex.length <= 4 ? hex.split('').map((x) => x + x).join('') : hex;
  const n = (i) => parseInt(h.slice(i, i + 2), 16);
  return [n(0), n(2), n(4), h.length === 8 ? Math.round((n(6) / 255) * 1000) / 1000 : 1];
};
const hslToRgba = (h, s, l, a) => {
  const k = (n) => (n + h / 30) % 12;
  const f = (n) => l - s * Math.min(l, 1 - l) * Math.max(-1, Math.min(k(n) - 3, Math.min(9 - k(n), 1)));
  return [Math.round(f(0) * 255), Math.round(f(8) * 255), Math.round(f(4) * 255), a];
};
const luminance = ([r, g, b]) => { const c = (x) => { const s = x / 255; return s <= 0.03928 ? s / 12.92 : ((s + 0.055) / 1.055) ** 2.4; }; return 0.2126 * c(r) + 0.7152 * c(g) + 0.0722 * c(b); };
/** WCAG contrast ratio (1 to 21) of two colours; a colour with some see-through is first laid over `under` (white when not given). */
export function contrastRatio(a, b, under = [255, 255, 255, 1]) {
  const flat = (x, base) => { const al = x[3] ?? 1; return [0, 1, 2].map((i) => Math.round(x[i] * al + base[i] * (1 - al))); };
  const bb = flat(b, under);
  const la = luminance(flat(a, bb)); const lb = luminance(bb);
  return (Math.max(la, lb) + 0.05) / (Math.min(la, lb) + 0.05);
}
const ANGLE_UNITS = new Set(['deg', 'rad', 'grad', 'turn']);

/** { reason } or { rgba } (null when the colour cannot be worked out here, for example color-mix) or { rgba, transparent / current }. */
function parseColor(node, c) {
  if (node.t === 'hash') {
    if (!/^[0-9a-fA-F]+$/.test(node.v) || ![3, 4, 6, 8].includes(node.v.length)) return { reason: `"#${clip(node.v, 12)}" is not a colour (write #rgb, #rrggbb or #rrggbbaa).` };
    return { rgba: hexToRgba(node.v.toLowerCase()) };
  }
  if (node.t === 'ident') {
    if (node.v === 'transparent') return { rgba: [0, 0, 0, 0], transparent: true };
    if (node.v === 'currentcolor') return { rgba: null, current: true };
    if (own(NAMED, node.v)) return { rgba: hexToRgba(NAMED[node.v]) };
    return { reason: `"${clip(node.v, 24)}" is not a colour the pack may use.` };
  }
  if (node.t !== 'fn') return { reason: 'is not a colour.' };
  const n = node.name;
  const items = sig(node.items);
  if (n === 'var') {
    const first = items[0];
    if (!first || first.t !== 'ident' || VARIABLES[first.raw] !== 'color') return { reason: `var(${clip(first?.raw ?? '', 40)}) is not one of the colour variables (${Object.keys(VARIABLES).filter((k) => VARIABLES[k] === 'color').slice(0, 4).join(', ')}, ...).` };
    if (items.length > 1) {
      if (items[1].t !== 'comma' || items.length < 3) return { reason: 'var() has something after the name that is not a fallback colour.' };
      const fb = parseColor(items[2], c);
      if (fb.reason || items.length > 3) return { reason: fb.reason || 'var() has more than one fallback.' };
    }
    const hex = c.env.tokenColors?.[first.raw];
    return { rgba: hex ? hexToRgba(hex.slice(1)) : null, variable: first.raw };
  }
  if (['rgb', 'rgba', 'hsl', 'hsla', 'hwb', 'lab', 'lch', 'oklab', 'oklch'].includes(n)) {
    const values = [];
    let slash = false;
    for (const it of items) {
      if (it.t === 'comma') continue;
      if (it.t === 'delim' && it.v === '/') { slash = true; continue; }
      if (it.t === 'num' || it.t === 'pct' || (it.t === 'dim' && ANGLE_UNITS.has(it.unit)) || (it.t === 'ident' && it.v === 'none')) { values.push(it); continue; }
      return { reason: `${n}() has something in it that is not a number (${it.t === 'ident' && it.v === 'from' ? 'relative colours' : it.t === 'fn' ? 'a function' : 'a word'} is not allowed there).` };
    }
    if (values.length < 3 || values.length > 4) return { reason: `${n}() needs three numbers and an optional see-through value.` };
    if (!['rgb', 'rgba', 'hsl', 'hsla'].includes(n) || values.some((x) => x.t === 'ident')) return { rgba: null };
    const num = (x, scale) => (x.t === 'pct' ? (x.v / 100) * scale : x.v);
    const alpha = values[3] ? Math.max(0, Math.min(1, values[3].t === 'pct' ? values[3].v / 100 : values[3].v)) : 1;
    if (n.startsWith('rgb')) return { rgba: [0, 1, 2].map((i) => Math.max(0, Math.min(255, Math.round(num(values[i], 255))))).concat(alpha) };
    const hue = values[0].t === 'dim' ? (values[0].unit === 'turn' ? values[0].v * 360 : values[0].unit === 'rad' ? (values[0].v * 180) / Math.PI : values[0].unit === 'grad' ? values[0].v * 0.9 : values[0].v) : values[0].v;
    return { rgba: hslToRgba(((hue % 360) + 360) % 360, Math.max(0, Math.min(1, num(values[1], 1) / (values[1].t === 'pct' ? 1 : 100))), Math.max(0, Math.min(1, num(values[2], 1) / (values[2].t === 'pct' ? 1 : 100))), alpha) };
  }
  if (n === 'color-mix') {
    const parts = splitOn(items, 'comma').map(sig);
    if (parts.length !== 3 || !parts[0][0] || parts[0][0].t !== 'ident' || parts[0][0].v !== 'in' || !parts[0].slice(1).every((x) => x.t === 'ident')) return { reason: 'color-mix() must be written color-mix(in srgb, colour, colour).' };
    for (const p of parts.slice(1)) {
      const colours = p.filter((x) => x.t !== 'pct');
      if (colours.length !== 1 || p.length > 2) return { reason: 'color-mix() needs a colour (and an optional percentage) in each of its two places.' };
      const r = parseColor(colours[0], c);
      if (r.reason) return r;
    }
    return { rgba: null };
  }
  return { reason: `the colour function "${n}()" is not allowed. Use a hex colour, rgb(), hsl(), color-mix() or a colour variable.` };
}

// ----- lengths -----
const mk = (o) => Object.freeze(o);
const PROF = {
  space: mk({ px: [0, 96], rem: [0, 6], em: [0, 6], ch: [0, 12], pct: [0, 20], vw: [0, 20], vh: [0, 20], vars: 'space' }),
  minSize: mk({ px: [0, 1200], rem: [0, 75], em: [0, 75], ch: [0, 100], pct: [0, 100], vw: [0, 100], vh: [0, 100] }),
  minSizeSmall: mk({ px: [0, 480], rem: [0, 30], em: [0, 30], ch: [0, 60], pct: [0, 100], vw: [0, 100], vh: [0, 100] }),
  maxWidth: mk({ px: [280, 2400], rem: [17.5, 150], em: [17.5, 150], ch: [20, 200], pct: [60, 100], vw: [80, 100], vh: [0, 0] }),
  radius: mk({ px: [0, 999], rem: [0, 60], em: [0, 60], pct: [0, 50], vars: 'radius' }),
  border: mk({ px: [0, 12], rem: [0, 0.75], em: [0, 0.75] }),
  offset: mk({ px: [-4, 12], rem: [-0.25, 0.75], em: [-0.25, 0.75] }),
  boxShadow: mk({ px: [-80, 80], rem: [-5, 5], em: [-5, 5] }),
  textShadow: mk({ px: [-20, 20], rem: [-1.25, 1.25], em: [-1.25, 1.25] }),
  letter: mk({ px: [-1, 6], rem: [-0.06, 0.4], em: [-0.06, 0.4] }),
  word: mk({ px: [0, 16], rem: [0, 1], em: [0, 1] }),
  indent: mk({ px: [0, 64], rem: [0, 4], em: [0, 4], pct: [0, 10] }),
  lineLen: mk({ px: [12, 200], rem: [0.75, 12], em: [1, 3], pct: [100, 300] }),
  tiny: mk({ px: [0, 8], rem: [0, 0.5], em: [0, 0.5] }),
  bg: mk({ px: [-4000, 4000], rem: [-250, 250], em: [-250, 250], pct: [-500, 500], vw: [-500, 500], vh: [-500, 500] }),
  pseudo: mk({ px: [0, 400], rem: [0, 25], em: [0, 25], pct: [0, 100], vw: [0, 100], vh: [0, 100] }),
  free: mk({ px: [-20000, 20000], rem: [-1250, 1250], em: [-1250, 1250], pct: [-2000, 2000], vw: [-1000, 1000], vh: [-1000, 1000], ch: [-1000, 1000] }),
  move: mk({ px: [-16, 16], rem: [-1, 1], em: [-1, 1], pct: [-10, 10] }),
  track: mk({ px: [40, 1600], rem: [2.5, 100], em: [2.5, 100], ch: [4, 100], pct: [5, 100], vw: [5, 100], vh: [5, 100] }),
  trackMin: mk({ px: [0, 1600], rem: [0, 100], em: [0, 100], ch: [0, 100], pct: [0, 100], vw: [0, 100], vh: [0, 100] }),
  radiusBlur: mk({ px: [0, 24], rem: [0, 1.5], em: [0, 1.5] }),
  fontSize: mk({ px: [12, 160], rem: [0.75, 10], em: [0.75, 10], pct: [75, 500], vw: [0, 12], vh: [0, 12] }),
};
const BUCKET = { px: 'px', rem: 'rem', em: 'em', ch: 'ch', vw: 'vw', dvw: 'vw', svw: 'vw', lvw: 'vw', vh: 'vh', dvh: 'vh', svh: 'vh', lvh: 'vh', vmin: 'vh', vmax: 'vh' };
const MATH_FNS = new Set(['calc', 'min', 'max', 'clamp']);
const unitsOf = (prof) => ['px', 'rem', 'em', 'ch', 'vw', 'vh'].filter((u) => prof[u]).concat(prof.pct ? ['%'] : []);

function varReason(fn, allowedKind) {
  const first = sig(fn.items)[0];
  const kind = first && first.t === 'ident' ? VARIABLES[first.raw] : undefined;
  if (!allowedKind || kind !== allowedKind) return `var(${clip(first?.raw ?? '', 40)}) cannot be used here${allowedKind ? ` (only ${allowedKind} variables, like ${Object.keys(VARIABLES).find((k) => VARIABLES[k] === allowedKind)})` : ''}.`;
  if (sig(fn.items).length > 1) return 'var() with a fallback value is not allowed here.';
  return null;
}

/** null when the length (a number with a unit, a percentage, 0, a variable, or calc/min/max/clamp of those) is inside the profile; otherwise the reason. */
function lengthReason(node, prof, c, depth = 0) {
  if (node.t === 'num') return node.v === 0 ? (['px', 'rem', 'em'].every((u) => !prof[u] || prof[u][0] <= 0) ? null : 'zero is too small here.') : `${node.repr} needs a unit (px, rem, em...).`;
  if (node.t === 'pct') { const b = prof.pct; if (!b) return 'percentages are not allowed here.'; return node.v >= b[0] && node.v <= b[1] ? null : `${node.repr}% is outside what is allowed here (${b[0]}% to ${b[1]}%).`; }
  if (node.t === 'dim') {
    const bucket = BUCKET[node.unit];
    const b = bucket ? prof[bucket] : null;
    if (!b) return `the unit "${clip(node.unit, 12)}" is not allowed here (allowed: ${unitsOf(prof).join(', ')}).`;
    return node.v >= b[0] && node.v <= b[1] ? null : `${node.repr}${node.unit} is outside what is allowed here (${b[0]}${node.unit} to ${b[1]}${node.unit}).`;
  }
  if (node.t === 'fn') {
    if (node.name === 'var') return varReason(node, prof.vars);
    if (MATH_FNS.has(node.name)) return mathReason(node, prof, c, depth);
    return `"${clip(node.name, 20)}()" is not allowed here.`;
  }
  return 'is not a length.';
}
function mathReason(fn, prof, c, depth) {
  if (c.noCalc && fn.name === 'calc') return 'calc() is not allowed on a control or a notice; write the value plainly (clamp(), min() and max() are allowed).';
  if (depth > 3) return `${fn.name}() is nested too deeply.`;
  let leaves = 0;
  const walk = (arr) => {
    for (const it of arr) {
      if (it.t === 'comma') continue;
      if (it.t === 'delim') { if (!['+', '-', '*', '/'].includes(it.v)) return `the sign "${clip(it.v, 4)}" is not allowed inside ${fn.name}().`; continue; }
      if (it.t === 'num') { if (Math.abs(it.v) > 10) return `a number above 10 is not allowed inside ${fn.name}().`; continue; }
      if (it.t === 'block' && it.open === '(') { const r = walk(sig(it.items)); if (r) return r; continue; }
      if (it.t === 'dim' || it.t === 'pct' || it.t === 'fn') { leaves += 1; const r = lengthReason(it, prof, c, depth + 1); if (r) return r; continue; }
      return `something inside ${fn.name}() is not a length.`;
    }
    return null;
  };
  const r = walk(sig(fn.items));
  if (r) return r;
  return leaves > 12 ? `${fn.name}() has too many parts.` : null;
}

const FONT_SIZE_KW = new Set(['small', 'medium', 'large', 'x-large', 'xx-large', 'larger', 'smaller']);
/** Whether a font size is a plain size that never goes below 12px; the viewport units may only be used inside clamp() with a safe first value or max() with a safe value. */
function floorOk(node) {
  if (node.t === 'dim') return (node.unit === 'px' && node.v >= 12) || ((node.unit === 'rem' || node.unit === 'em') && node.v >= 0.75);
  if (node.t === 'pct') return node.v >= 75;
  return false;
}

// ----- pictures -----
function assetReason(address, c, want) {
  const text = String(address);
  const lower = text.toLowerCase().replace(/[\u0000- ]/g, '');
  if (/^(javascript|vbscript|livescript|mocha):/.test(lower)) return `the address "${clip(text, 30)}" would run a script.`;
  if (/^data:/.test(lower)) return 'a "data:" address is not allowed (it can carry anything, even code).';
  if (/^[a-z][a-z0-9+.-]*:/.test(lower) || lower.startsWith('//') || lower.startsWith('\\\\')) return `the address "${clip(text, 40)}" leads outside the pack. A pack may only point at its own files (assets/<name>).`;
  const m = /^assets\/([a-z0-9][a-z0-9._-]{0,47})$/.exec(text);
  if (!m) return `the address "${clip(text, 40)}" is not one of the pack's own files. Write it as assets/<file name>, for example url("assets/photo.webp").`;
  const asset = c.env.assets[m[1]];
  if (!asset) return `the file "${m[1]}" is not in the pack's "assets" (add it there, or remove this).`;
  if (asset.type !== want) return `the file "${m[1]}" is ${asset.type === 'font' ? 'a font' : 'a picture'}; it cannot be used here.`;
  c.env.usedAssets.add(m[1]);
  return null;
}
const urlOf = (node) => (node.t === 'url' ? { value: node.v, bad: node.bad } : node.t === 'fn' && node.name === 'url' ? (() => { const s = sig(node.items); return s.length === 1 && s[0].t === 'string' ? { value: s[0].v, bad: false } : { value: null, bad: true }; })() : null);

const GRADIENTS = new Set(['linear-gradient', 'radial-gradient', 'conic-gradient', 'repeating-linear-gradient', 'repeating-radial-gradient', 'repeating-conic-gradient']);
const GRADIENT_WORDS = new Set(['to', 'top', 'bottom', 'left', 'right', 'center', 'closest-side', 'farthest-side', 'closest-corner', 'farthest-corner', 'circle', 'ellipse', 'at', 'in', 'from', 'srgb', 'srgb-linear', 'oklab', 'oklch', 'lab', 'lch', 'hsl', 'hwb', 'shorter', 'longer', 'increasing', 'decreasing', 'hue', 'transparent']);
const REFUSED_IMAGE_FUNCTIONS = {
  'image-set': 'It hides addresses inside text, so it is not allowed. Use url("assets/...") with a file from the pack.', '-webkit-image-set': 'It hides addresses inside text, so it is not allowed. Use url("assets/...") with a file from the pack.',
  'cross-fade': 'It mixes in other pictures by address, so it is not allowed.', '-webkit-cross-fade': 'It mixes in other pictures by address, so it is not allowed.',
  element: 'It copies another part of the page into a background, so it is not allowed.', '-moz-element': 'It copies another part of the page into a background, so it is not allowed.',
  paint: 'It runs a program from a file, so it is not allowed.', image: 'It is not supported; use url("assets/...") with a file from the pack.',
  expression: 'expression() runs program code in very old browsers. Scripts of any kind are not allowed.',
};
/** null, or why a gradient is not allowed. */
function gradientReason(fn, c) {
  const items = sig(fn.items);
  if (items.length > 40) return 'it has too many stops.';
  for (const it of items) {
    if (it.t === 'comma' || (it.t === 'delim' && it.v === '/')) continue;
    if (it.t === 'num' || it.t === 'pct') continue;
    if (it.t === 'dim') { const r = ANGLE_UNITS.has(it.unit) ? null : lengthReason(it, PROF.bg, c); if (r) return r; continue; }
    if (it.t === 'ident' && GRADIENT_WORDS.has(it.v)) continue;
    if (it.t === 'hash' || it.t === 'ident' || (it.t === 'fn' && !MATH_FNS.has(it.name))) { const r = parseColor(it, c); if (r.reason) return r.reason; continue; }
    if (it.t === 'fn') { const r = lengthReason(it, PROF.bg, c); if (r) return r; continue; }
    return `something in the gradient is not allowed ("${clip(nodesText([it]), 24)}").`;
  }
  return null;
}
/** null, or why one background picture is not allowed. `none`, a url to the pack's own picture, or a gradient. */
function imageReason(node, c) {
  if (node.t === 'ident' && node.v === 'none') return null;
  const u = urlOf(node);
  if (u) { if (u.bad || u.value === null) return 'this address is not written as url("assets/...").'; return assetReason(u.value, c, 'image'); }
  if (node.t === 'fn') {
    if (GRADIENTS.has(node.name)) { c.info.gradient = true; return gradientReason(node, c); }
    if (own(REFUSED_IMAGE_FUNCTIONS, node.name)) return REFUSED_IMAGE_FUNCTIONS[node.name];
  }
  return 'is not a picture the pack may use (use none, url("assets/..."), or a gradient).';
}

// ----- shadows, movement, filters -----
const timeReason = (node, max) => (node.t === 'dim' && (node.unit === 's' || node.unit === 'ms') && node.v >= 0 && (node.unit === 's' ? node.v <= max : node.v <= max * 1000) ? null : node.t === 'num' && node.v === 0 ? null : `is not a time between 0 and ${max} seconds.`);
const EASING = new Set(['ease', 'ease-in', 'ease-out', 'ease-in-out', 'linear', 'step-start', 'step-end']);
const easingFnReason = (fn) => {
  const s = sig(fn.items).filter((x) => x.t !== 'comma');
  if (fn.name === 'cubic-bezier') return s.length === 4 && s.every((x, i) => x.t === 'num' && (i % 2 === 0 ? x.v >= 0 && x.v <= 1 : x.v >= -2 && x.v <= 3)) ? null : 'cubic-bezier() needs four numbers (the first and third between 0 and 1).';
  if (fn.name === 'steps') return s.length >= 1 && s.length <= 2 && s[0].t === 'num' && s[0].v >= 1 && s[0].v <= 100 && (!s[1] || (s[1].t === 'ident' && ['start', 'end', 'jump-start', 'jump-end', 'jump-none', 'jump-both'].includes(s[1].v))) ? null : 'steps() needs a number from 1 to 100.';
  return `"${fn.name}()" is not an easing.`;
};

function shadowListReason(v, c, prof, { allowInset }) {
  const layers = splitOn(v, 'comma').map(sig);
  if (layers.length > 6) return 'it has more than 6 layers.';
  for (const layer of layers) {
    let lengths = 0; let colours = 0; let inset = 0;
    for (const n of layer) {
      if (n.t === 'ident' && n.v === 'inset') { if (!allowInset) return 'inset is not allowed here.'; inset += 1; continue; }
      const isColourVar = n.t === 'fn' && n.name === 'var' && VARIABLES[sig(n.items)[0]?.raw] === 'color';
      if (n.t === 'dim' || n.t === 'num' || (n.t === 'fn' && (MATH_FNS.has(n.name) || n.name === 'var') && !isColourVar)) { lengths += 1; const r = lengthReason(n, prof, c); if (r) return r; continue; }
      const col = parseColor(n, c);
      if (col.reason) return col.reason;
      colours += 1;
    }
    if (lengths < 2 || lengths > 4 || colours > 1 || inset > 1) return 'a shadow is written: offset-x offset-y blur spread colour (the last two are optional).';
  }
  return null;
}

const TRANSFORM_FNS = {
  translate: 'move', translatex: 'move', translatey: 'move', scale: 'scale', scalex: 'scale', scaley: 'scale', rotate: 'rotate', skew: 'skew', skewx: 'skew', skewy: 'skew',
};
function transformReason(v, c, free) {
  if (v.length === 1 && v[0].t === 'ident' && v[0].v === 'none') return null;
  if (v.length > 6) return 'it has too many steps.';
  for (const f of v) {
    if (f.t !== 'fn') return 'is not a movement (translate, scale or rotate).';
    const kind = TRANSFORM_FNS[f.name];
    if (!kind) return `"${clip(f.name, 20)}()" is not allowed (allowed: translate, scale, rotate${free ? ', skew' : ''}).`;
    const args = sig(f.items).filter((x) => x.t !== 'comma');
    if (args.length === 0 || args.length > 2) return `${f.name}() has the wrong number of values.`;
    for (const a of args) {
      if (kind === 'move') { const r = lengthReason(a, free ? PROF.free : PROF.move, c); if (r) return r; } else if (kind === 'scale') { if (a.t !== 'num' || (free ? a.v < 0 || a.v > 10 : a.v < 0.9 || a.v > 1.15)) return free ? 'a scale must be between 0 and 10.' : 'a scale on a part must stay between 0.9 and 1.15 (the part may not be shrunk away).'; } else if (kind === 'rotate') { if (a.t !== 'dim' || a.unit !== 'deg' || (!free && Math.abs(a.v) > 5)) return free ? 'a rotation is written in deg.' : 'a rotation on a part is written in deg and stays within 5 degrees.'; } else if (a.t !== 'dim' || a.unit !== 'deg' || Math.abs(a.v) > 60) return 'a skew is written in deg, up to 60.';
    }
  }
  return null;
}

const FILTER_RANGES = { blur: [0, 24, 'px'], brightness: [0.5, 1.6], contrast: [0.6, 1.6], grayscale: [0, 1], 'hue-rotate': [0, 360, 'deg'], saturate: [0, 3], sepia: [0, 1], invert: [0, 1], opacity: [0, 1] };
function filterReason(v, c, free) {
  if (v.length === 1 && v[0].t === 'ident' && v[0].v === 'none') return null;
  if (v.length > 5) return 'it has too many effects.';
  for (const f of v) {
    const r = f.t === 'fn' ? FILTER_RANGES[f.name] : null;
    if (!r) return f.t === 'fn' ? `the effect "${clip(f.name, 20)}()" is not allowed (allowed: ${Object.keys(FILTER_RANGES).filter((k) => free || k !== 'opacity').join(', ')}).` : 'is not an effect.';
    if ((f.name === 'opacity' || f.name === 'invert') && !free) return `${f.name}() can hide or flip what it is applied to, so it is only allowed on the empty decoration areas.`;
    const a = sig(f.items);
    if (a.length !== 1) return `${f.name}() needs one value.`;
    const x = a[0];
    if (r[2] === 'px') { if (x.t === 'num' && x.v === 0) continue; if (x.t !== 'dim' || x.unit !== 'px' || x.v < r[0] || x.v > (free ? 200 : r[1])) return `blur() must be between 0 and ${free ? 200 : r[1]}px.`; continue; }
    if (r[2] === 'deg') { if (x.t !== 'dim' || x.unit !== 'deg') return 'hue-rotate() is written in deg.'; continue; }
    const val = x.t === 'pct' ? x.v / 100 : x.t === 'num' ? x.v : NaN;
    if (!(val >= r[0] && val <= r[1])) return `${f.name}() must be between ${r[0]} and ${r[1]}.`;
  }
  return null;
}

// ---------------------------------------------------------------------------------------------------------------------
// 9. The properties a pack may use, which kinds of part may use each, and how its value is checked
// ---------------------------------------------------------------------------------------------------------------------

const KIND = {
  all: ['layout', 'text', 'control', 'notice', 'media', 'extra', 'slot'],
  texty: ['layout', 'text', 'control', 'notice', 'extra'],
  boxy: ['layout', 'control', 'notice'],
  movable: ['layout', 'text', 'control', 'notice', 'media', 'extra', 'slot'],
  hideable: ['extra', 'slot'],
  slot: ['slot'],
  img: ['media', 'slot'],
};

const WHY_KIND = {
  control: 'A control is something a shopper must always be able to find, see and press, so a pack may change how it looks (colours, borders, shape, shadow, type, padding) but not where it is, how big it is, or whether it shows.',
  notice: 'A notice is something a shopper must always be able to read (a price, how shopping works, a legal link), so a pack may change how it looks but not where it is, how big it is, or whether it shows.',
  layout: 'A block that holds other things may be coloured, shaped, spaced and arranged, but not hidden, shrunk or moved, because the things inside it must stay visible and reachable.',
  text: 'Words may be restyled, but not hidden, moved or shrunk, because they are the shop\'s own wording.',
  media: 'A picture may be shaped and given effects, but not hidden or moved.',
  extra: 'An optional extra may be restyled or hidden, but not moved or resized.',
  slot: '',
};
const WHY_PROPERTY = {
  position: 'Moving parts around could put one over a button or take it off the screen. Only the empty decoration areas may be positioned, and never with fixed or sticky.',
  top: 'Moving parts around could put one over a button or take it off the screen. Only the empty decoration areas may be positioned.', right: 'Moving parts around could put one over a button or take it off the screen. Only the empty decoration areas may be positioned.',
  bottom: 'Moving parts around could put one over a button or take it off the screen. Only the empty decoration areas may be positioned.', left: 'Moving parts around could put one over a button or take it off the screen. Only the empty decoration areas may be positioned.',
  inset: 'Moving parts around could put one over a button or take it off the screen. Only the empty decoration areas may be positioned.',
  'pointer-events': 'It can make a button stop reacting to a press, or let an empty area swallow the press meant for a button.',
  clip: 'It can cut a part away until nothing is left of it.', 'clip-path': 'It can cut a part away until nothing is left of it. Only the empty decoration areas may use it.',
  mask: 'It can hide parts of what is under it.', 'mask-image': 'It can hide parts of what is under it, and takes an address.',
  filter: 'A filter such as opacity(0) or blur(50px) can make a part disappear. Only pictures and the empty decoration areas may use it.',
  'content-visibility': 'It can switch off drawing a part altogether.', contain: 'It changes how a part is laid out and drawn, and is not needed.', 'will-change': 'It is not needed and can slow the page.',
  float: 'Floating changes where things sit and can push a button out of view.', 'writing-mode': 'It turns text on its side, which can make a notice unreadable.', direction: 'It reverses the reading direction.', 'unicode-bidi': 'It changes how text is ordered.',
  'text-orientation': 'It turns text on its side.', 'text-combine-upright': 'It is not needed.', zoom: 'It rescales a part.', scale: 'Use transform: scale(...) with a small value instead.', translate: 'Use transform: translate(...) with a small value instead.', rotate: 'Use transform: rotate(...) with a small value instead.',
  width: 'A fixed width can squeeze a button or a price down to nothing. Use min-width or max-width, or ask for a part of its own.', height: 'A fixed height can squeeze a button or a price down to nothing. Use min-height.', 'max-height': 'A height limit can cut off a button or a notice.',
  'list-style-image': 'It takes a picture address.', 'border-image': 'It takes a picture address, and can cover a part.', 'border-image-source': 'It takes a picture address.', 'shape-outside': 'It takes a picture address and changes how text flows.',
  cursor: 'Only plain pointer shapes are allowed.', behavior: 'behavior is an old Internet Explorer feature that runs program code from a file. Scripts of any kind are not allowed.', '-moz-binding': '-moz-binding is an old Firefox feature that attaches program code to a part. Scripts of any kind are not allowed.',
  expression: 'expression() runs program code in very old browsers. Scripts of any kind are not allowed.', '-webkit-line-clamp': 'It needs display: -webkit-box, which is not allowed. Use text-overflow: ellipsis.', 'text-fill-color': 'It can make text invisible.', '-webkit-text-fill-color': 'It can make text invisible.',
  'overflow-clip-margin': 'It is not needed.', 'accent-color': 'It is not needed.', appearance: 'It changes what a control is drawn as, and is not needed.', resize: 'It is not needed.', 'user-select': 'It can stop shoppers from copying a price or an address.', 'touch-action': 'It changes how a touch is read, which can make a control stop responding.',
  'scroll-snap-type': 'It is not needed.', 'scroll-behavior': 'It is not needed.', all: 'It resets everything and could undo the website\'s own protection of a part.', 'counter-reset': 'It is not needed.', quotes: 'It is not needed.',
  src: 'Fonts are declared in the pack\'s "fontFiles" list.', 'font-display': 'Fonts are declared in the pack\'s "fontFiles" list.', 'unicode-range': 'Fonts are declared in the pack\'s "fontFiles" list.',
  transform: 'A movement is only allowed in small amounts.', animation: 'Animations are only allowed on the empty decoration areas.', 'transition-behavior': 'It is not needed.',
};

/** A reason that starts with a verb ("is not a colour", "needs one value") is read as "It is not a colour". */
const said = (r) => (/^(is|needs|has|must|cannot|are)\b/.test(r) ? `It ${r}` : r.charAt(0).toUpperCase() + r.slice(1));

const PROPS = new Map();
const def = (names, kinds, f, why) => { for (const n of [].concat(names)) PROPS.set(n, { kinds: new Set(kinds), f, why }); };

const globalKw = new Set(['inherit', 'initial', 'unset', 'revert', 'revert-layer']);
const kw = (...words) => { const s = new Set(words); return (v) => (v.length === 1 && v[0].t === 'ident' && s.has(v[0].v) ? null : `Allowed: ${words.join(', ')}.`); };
const single = (fn) => (v, c) => (v.length === 1 ? fn(v[0], c) : 'needs exactly one value.');
const lens = (prof, { min = 1, max = 4, words = [] } = {}) => (v, c) => {
  if (v.length < min || v.length > max) return `needs ${min === max ? min : `${min} to ${max}`} value${max > 1 ? 's' : ''}.`;
  for (const n of v) { if (n.t === 'ident' && words.includes(n.v)) continue; const r = lengthReason(n, prof, c); if (r) return r; }
  return null;
};
const colourOnly = (record) => single((n, c) => {
  const r = parseColor(n, c);
  if (r.reason) return r.reason;
  if (record) c.info[record] = r;
  return null;
});
const colours = (min, max) => (v, c) => { if (v.length < min || v.length > max) return `needs ${min} to ${max} colours.`; for (const n of v) { const r = parseColor(n, c); if (r.reason) return r.reason; } return null; };

// colour and backgrounds
def('color', KIND.all, colourOnly('color'));
def('background-color', KIND.all, colourOnly('bg'));
def('background-image', KIND.all, (v, c) => { for (const layer of splitOn(v, 'comma')) { const s = sig(layer); if (s.length !== 1) return 'each picture is one value.'; const r = imageReason(s[0], c); if (r) return r; } return null; });
const BG_WORDS = new Set(['repeat', 'no-repeat', 'repeat-x', 'repeat-y', 'space', 'round', 'left', 'right', 'top', 'bottom', 'center', 'cover', 'contain', 'auto', 'scroll', 'fixed', 'local', 'border-box', 'padding-box', 'content-box', 'text', 'none']);
def('background', KIND.all, (v, c) => {
  const layers = splitOn(v, 'comma').map(sig);
  if (layers.length > 6) return 'it has more than 6 layers.';
  for (const layer of layers) {
    for (const n of layer) {
      if (n.t === 'ident' && BG_WORDS.has(n.v)) { if (n.v === 'text') { if (c.kind !== 'text') return 'background-clip: text is only allowed on text parts (for gradient headings).'; c.info.clipText = true; } continue; }
      if (n.t === 'delim' && n.v === '/') continue;
      if (n.t === 'url' || (n.t === 'fn' && (n.name === 'url' || GRADIENTS.has(n.name) || own(REFUSED_IMAGE_FUNCTIONS, n.name)))) { const r = imageReason(n, c); if (r) return r; continue; }
      if (n.t === 'dim' || n.t === 'pct' || n.t === 'num' || (n.t === 'fn' && MATH_FNS.has(n.name))) { const r = lengthReason(n, PROF.bg, c); if (r) return r; continue; }
      const col = parseColor(n, c);
      if (col.reason) return col.reason;
      c.info.bg = col;
    }
  }
  return null;
});
def('background-size', KIND.all, (v, c) => { for (const layer of splitOn(v, 'comma').map(sig)) { if (layer.length < 1 || layer.length > 2) return 'each size is one or two values.'; for (const n of layer) { if (n.t === 'ident' && ['cover', 'contain', 'auto'].includes(n.v)) continue; const r = lengthReason(n, PROF.bg, c); if (r) return r; } } return null; });
def('background-position', KIND.all, (v, c) => { for (const layer of splitOn(v, 'comma').map(sig)) { if (layer.length < 1 || layer.length > 4) return 'each position is one to four values.'; for (const n of layer) { if (n.t === 'ident' && ['left', 'right', 'top', 'bottom', 'center'].includes(n.v)) continue; const r = lengthReason(n, PROF.bg, c); if (r) return r; } } return null; });
def('background-repeat', KIND.all, (v) => (v.every((n) => (n.t === 'ident' && ['repeat', 'no-repeat', 'repeat-x', 'repeat-y', 'space', 'round'].includes(n.v)) || n.t === 'comma') ? null : 'Allowed: repeat, no-repeat, repeat-x, repeat-y, space, round.'));
def('background-attachment', KIND.all, (v) => (v.every((n) => (n.t === 'ident' && ['scroll', 'fixed', 'local'].includes(n.v)) || n.t === 'comma') ? null : 'Allowed: scroll, fixed, local.'));
def(['background-origin'], KIND.all, (v) => (v.every((n) => (n.t === 'ident' && ['border-box', 'padding-box', 'content-box'].includes(n.v)) || n.t === 'comma') ? null : 'Allowed: border-box, padding-box, content-box.'));
def(['background-clip', '-webkit-background-clip'], KIND.all, (v, c) => {
  for (const n of v) {
    if (n.t === 'comma') continue;
    if (n.t !== 'ident' || !['border-box', 'padding-box', 'content-box', 'text'].includes(n.v)) return 'Allowed: border-box, padding-box, content-box, text.';
    if (n.v === 'text') { if (c.kind !== 'text') return 'background-clip: text is only allowed on text parts (for gradient headings).'; c.info.clipText = true; }
  }
  return null;
});

// borders, outlines, shadows
const BORDER_STYLES = ['none', 'solid', 'dashed', 'dotted', 'double', 'groove', 'ridge', 'inset', 'outset', 'hidden'];
const borderShorthand = (kind) => (v, c) => {
  if (v.length < 1 || v.length > 3) return 'needs a width, a style and a colour (in any order).';
  for (const n of v) {
    if (n.t === 'ident' && BORDER_STYLES.includes(n.v)) { if (kind === 'outline' && (n.v === 'none' || n.v === 'hidden')) return 'An outline may not be switched off: it is how a keyboard user sees where they are. Change its colour, width or offset instead.'; continue; }
    if (n.t === 'ident' && ['thin', 'medium', 'thick'].includes(n.v)) continue;
    if (n.t === 'dim' || n.t === 'num' || (n.t === 'fn' && (MATH_FNS.has(n.name) || (n.name === 'var' && VARIABLES[sig(n.items)[0]?.raw] !== 'color')))) { const r = lengthReason(n, PROF.border, c); if (r) return r; if (kind === 'outline' && n.t !== 'fn' && n.v === 0) return 'An outline may not be switched off (width 0).'; continue; }
    const col = parseColor(n, c);
    if (col.reason) return col.reason;
  }
  return null;
};
def(['border', 'border-top', 'border-right', 'border-bottom', 'border-left', 'border-block', 'border-inline', 'border-block-start', 'border-block-end', 'border-inline-start', 'border-inline-end'], KIND.all, borderShorthand('border'));
def('outline', KIND.all, borderShorthand('outline'));
def(['border-width', 'border-top-width', 'border-right-width', 'border-bottom-width', 'border-left-width'], KIND.all, (v, c) => { if (v.length < 1 || v.length > 4) return 'needs 1 to 4 values.'; for (const n of v) { if (n.t === 'ident' && ['thin', 'medium', 'thick'].includes(n.v)) continue; const r = lengthReason(n, PROF.border, c); if (r) return r; } return null; });
def('outline-width', KIND.all, (v, c) => { if (v.length !== 1) return 'needs one value.'; const n = v[0]; if (n.t === 'ident' && ['thin', 'medium', 'thick'].includes(n.v)) return null; if (n.t !== 'fn' && n.v === 0) return 'An outline may not be switched off (width 0).'; return lengthReason(n, PROF.border, c); });
def(['border-style', 'border-top-style', 'border-right-style', 'border-bottom-style', 'border-left-style'], KIND.all, (v) => (v.length >= 1 && v.length <= 4 && v.every((n) => n.t === 'ident' && BORDER_STYLES.includes(n.v)) ? null : `Allowed: ${BORDER_STYLES.join(', ')}.`));
def('outline-style', KIND.all, kw('solid', 'dashed', 'dotted', 'double', 'groove', 'ridge', 'inset', 'outset'));
def(['border-color', 'border-top-color', 'border-right-color', 'border-bottom-color', 'border-left-color'], KIND.all, colours(1, 4));
def('outline-color', KIND.all, colourOnly(null));
def('outline-offset', KIND.all, lens(PROF.offset, { min: 1, max: 1 }));
def(['border-radius', 'border-top-left-radius', 'border-top-right-radius', 'border-bottom-left-radius', 'border-bottom-right-radius'], KIND.all, (v, c) => {
  let slashes = 0;
  for (const n of v) { if (n.t === 'delim' && n.v === '/') { slashes += 1; continue; } const r = lengthReason(n, PROF.radius, c); if (r) return r; }
  return slashes > 1 || v.length > 9 ? 'must have at most four values on each side of one "/".' : null;
});
def('box-shadow', KIND.all, (v, c) => (v.length === 1 && v[0].t === 'ident' && v[0].v === 'none' ? null : shadowListReason(v, c, PROF.boxShadow, { allowInset: true })));
def('text-shadow', KIND.all, (v, c) => (v.length === 1 && v[0].t === 'ident' && v[0].v === 'none' ? null : shadowListReason(v, c, PROF.textShadow, { allowInset: false })));
def('cursor', KIND.all, kw('auto', 'default', 'pointer', 'text', 'help', 'zoom-in', 'zoom-out', 'grab', 'grabbing', 'crosshair'));
def('opacity', KIND.all, single((n, c) => {
  const val = n.t === 'num' ? n.v : n.t === 'pct' ? n.v / 100 : NaN;
  if (!(val >= 0 && val <= 1)) return 'must be a number from 0 to 1 (or 0% to 100%).';
  if (!KIND.hideable.includes(c.kind) && val < 0.6) return 'Anything that stays on the page must stay at least 60% solid, so that it cannot be faded out. Only optional extras and the decoration areas may be faded further.';
  return null;
}));
def(['backdrop-filter', '-webkit-backdrop-filter'], KIND.all, (v, c) => {
  if (v.length === 1 && v[0].t === 'ident' && v[0].v === 'none') return null;
  for (const f of v) {
    if (f.t !== 'fn' || !['blur', 'saturate', 'brightness', 'contrast', 'grayscale', 'sepia'].includes(f.name)) return 'Allowed: blur(), saturate(), brightness(), contrast(), grayscale(), sepia().';
    const a = sig(f.items)[0];
    if (!a || sig(f.items).length !== 1) return `${f.name}() needs one value.`;
    if (f.name === 'blur') { const r = lengthReason(a, PROF.radiusBlur, c); if (r) return `blur() ${r}`; continue; }
    const val = a.t === 'pct' ? a.v / 100 : a.t === 'num' ? a.v : NaN;
    const range = FILTER_RANGES[f.name];
    if (!(val >= range[0] && val <= range[1])) return `${f.name}() must be between ${range[0]} and ${range[1]}.`;
  }
  return null;
});

// transitions (what changes on hover and press): fine for everything that is allowed to change
const TRANSITION_EXTRA = new Set(['all', 'none']);
const transitionBody = (v, c) => {
  for (const item of splitOn(v, 'comma').map(sig)) {
    if (item.length === 0 || item.length > 6) return 'each transition is a property, a time, a delay and an easing.';
    for (const n of item) {
      if (n.t === 'ident') { if (EASING.has(n.v) || TRANSITION_EXTRA.has(n.v) || PROPS.has(n.v)) continue; return `"${clip(n.v, 30)}" is not a property or an easing.`; }
      if (n.t === 'dim' || n.t === 'num') { const r = timeReason(n, 2); if (r) return r; continue; }
      if (n.t === 'fn') { const r = easingFnReason(n); if (r) return r; continue; }
      return 'is not allowed in a transition.';
    }
  }
  return null;
};
def('transition', KIND.all, (v, c) => transitionBody(v, c));
def('transition-property', KIND.all, (v) => (v.every((n) => n.t === 'comma' || (n.t === 'ident' && (TRANSITION_EXTRA.has(n.v) || PROPS.has(n.v)))) ? null : 'Name properties, or all.'));
def(['transition-duration', 'transition-delay'], KIND.all, (v, c) => { for (const n of v) { if (n.t === 'comma') continue; const r = timeReason(n, 2); if (r) return r; } return null; });
def('transition-timing-function', KIND.all, (v) => { for (const n of v) { if (n.t === 'comma') continue; if (n.t === 'ident' && EASING.has(n.v)) continue; if (n.t === 'fn') { const r = easingFnReason(n); if (r) return r; continue; } return 'is not an easing.'; } return null; });

// type
def('font-family', KIND.texty, (v, c) => {
  for (const item of splitOn(v, 'comma').map(sig)) {
    if (item.length !== 1) return 'each font is one name (put names with spaces in quotes).';
    const n = item[0];
    if (n.t === 'ident' && GENERIC_FONT_WORDS.includes(n.v)) continue;
    if (n.t === 'string') { if (c.env.fontFamilies.has(n.v)) { c.env.usedFamilies.add(n.v); continue; } return `the font "${clip(n.v, 30)}" is not one of the pack's own font files. Fonts that are not shipped may look different on every device, or be fetched from someone else. Use var(--ngos-font-body), a var(--ngos-stack-...) stack, or add the font file to "fontFiles".`; }
    if (n.t === 'fn' && n.name === 'var') { const name = sig(n.items)[0]?.raw; if (VARIABLES[name] === 'font' || VARIABLES[name] === 'stack') continue; return `var(${clip(name ?? '', 40)}) is not a font variable.`; }
    return `the font "${clip(nodesText([n]), 30)}" is not allowed. Use var(--ngos-font-body), a var(--ngos-stack-...) stack, a generic family (serif, sans-serif, monospace, system-ui) or a font file from the pack.`;
  }
  return null;
});
def('font-size', KIND.texty, single((n, c) => {
  if (n.t === 'ident') return FONT_SIZE_KW.has(n.v) ? null : `Allowed: ${[...FONT_SIZE_KW].join(', ')} (very small sizes are not allowed).`;
  const r = lengthReason(n, PROF.fontSize, c);
  if (r) return r;
  if (n.t === 'dim' && ['vw', 'vh', 'dvw', 'svw', 'lvw', 'dvh', 'svh', 'lvh', 'vmin', 'vmax'].includes(n.unit)) return 'a size in vw or vh alone can shrink below 12px on a small screen. Use clamp(1rem, 2.5vw, 2rem), for example.';
  if (n.t === 'fn') {
    const args = splitOn(n.items, 'comma').map(sig);
    if (n.name === 'clamp') return args[0] && args[0].length === 1 && floorOk(args[0][0]) ? null : 'in clamp() the first value is the smallest size, and it must be at least 12px (0.75rem).';
    if (n.name === 'max') return args.some((a) => a.length === 1 && floorOk(a[0])) ? null : 'max() needs at least one value that is at least 12px (0.75rem).';
    if (n.name === 'var') return 'a variable cannot be used for the size.';
    return `${n.name}() is not allowed for a font size on a part (write a plain size, clamp(), or max()).`;
  }
  return null;
}));
def('font-weight', KIND.texty, single((n) => (n.t === 'ident' ? (['normal', 'bold', 'bolder', 'lighter'].includes(n.v) ? null : 'Allowed: normal, bold, bolder, lighter, or a number 1 to 1000.') : n.t === 'num' && n.v >= 1 && n.v <= 1000 ? null : 'is a number from 1 to 1000.')));
def('font-style', KIND.texty, kw('normal', 'italic', 'oblique'));
def('font-variant', KIND.texty, kw('normal', 'small-caps', 'all-small-caps', 'none'));
def('font-variant-numeric', KIND.texty, (v) => (v.every((n) => n.t === 'ident' && ['normal', 'tabular-nums', 'proportional-nums', 'lining-nums', 'oldstyle-nums', 'slashed-zero', 'ordinal'].includes(n.v)) ? null : 'Allowed: normal, tabular-nums, proportional-nums, lining-nums, oldstyle-nums, slashed-zero, ordinal.'));
def('line-height', KIND.texty, single((n, c) => (n.t === 'ident' ? (n.v === 'normal' ? null : 'Allowed: normal, a number, or a length.') : n.t === 'num' ? (n.v >= 1 && n.v <= 3 ? null : 'a line height number is between 1 and 3 (lines may not be piled on top of each other).') : lengthReason(n, PROF.lineLen, c))));
def('letter-spacing', KIND.texty, single((n, c) => (n.t === 'ident' ? (n.v === 'normal' ? null : 'Allowed: normal, or a small length.') : lengthReason(n, PROF.letter, c))));
def('word-spacing', KIND.texty, single((n, c) => (n.t === 'ident' ? (n.v === 'normal' ? null : 'Allowed: normal, or a small length.') : lengthReason(n, PROF.word, c))));
def('text-indent', KIND.texty, single((n, c) => lengthReason(n, PROF.indent, c)));
def('text-align', KIND.texty, kw('left', 'right', 'center', 'justify', 'start', 'end'));
def('text-transform', KIND.texty, kw('none', 'uppercase', 'lowercase', 'capitalize'));
def('text-decoration', KIND.texty, (v, c) => {
  for (const n of v) {
    if (n.t === 'ident' && ['none', 'underline', 'overline', 'line-through', 'solid', 'double', 'dotted', 'dashed', 'wavy'].includes(n.v)) { if (n.v === 'line-through' && c.kind === 'notice') return 'A line through a price or notice reads as "old price" or "not available", so it is not allowed there.'; continue; }
    if (n.t === 'dim' || n.t === 'num') { const r = lengthReason(n, PROF.tiny, c); if (r) return r; continue; }
    const col = parseColor(n, c);
    if (col.reason) return col.reason;
  }
  return null;
});
def('text-decoration-line', KIND.texty, (v, c) => (v.every((n) => n.t === 'ident' && ['none', 'underline', 'overline', ...(c.kind === 'notice' ? [] : ['line-through'])].includes(n.v)) ? null : `Allowed: none, underline, overline${c.kind === 'notice' ? ' (a line through a notice reads as "old price", so it is not allowed there)' : ', line-through'}.`));
def('text-decoration-style', KIND.texty, kw('solid', 'double', 'dotted', 'dashed', 'wavy'));
def('text-decoration-color', KIND.texty, colourOnly(null));
def(['text-decoration-thickness', 'text-underline-offset'], KIND.texty, single((n, c) => (n.t === 'ident' ? (['auto', 'from-font'].includes(n.v) ? null : 'Allowed: auto, from-font, or a small length.') : lengthReason(n, PROF.tiny, c))));
def('text-overflow', KIND.texty, kw('clip', 'ellipsis'));
def('white-space', KIND.texty, kw('normal', 'nowrap', 'pre-line', 'pre-wrap', 'break-spaces'));
def('word-break', KIND.texty, kw('normal', 'break-word', 'break-all', 'keep-all'));
def('overflow-wrap', KIND.texty, kw('normal', 'break-word', 'anywhere'));
def('hyphens', KIND.texty, kw('none', 'manual', 'auto'));
def('text-wrap', KIND.texty, kw('wrap', 'nowrap', 'balance', 'pretty', 'stable'));
def('vertical-align', KIND.all, kw('baseline', 'middle', 'top', 'bottom', 'text-top', 'text-bottom', 'sub', 'super'));

// space around and between
const marginish = lens(PROF.space, { min: 1, max: 4, words: ['auto'] });
def(['margin', 'margin-top', 'margin-right', 'margin-bottom', 'margin-left', 'margin-inline', 'margin-block', 'margin-inline-start', 'margin-inline-end', 'margin-block-start', 'margin-block-end'], KIND.all, marginish);
def(['padding', 'padding-top', 'padding-right', 'padding-bottom', 'padding-left', 'padding-inline', 'padding-block', 'padding-inline-start', 'padding-inline-end', 'padding-block-start', 'padding-block-end'], KIND.all, lens(PROF.space, { min: 1, max: 4 }));
def(['gap', 'row-gap', 'column-gap'], KIND.boxy, lens(PROF.space, { min: 1, max: 2, words: ['normal'] }));

// arrangement
const DISPLAYS = {
  boxy: ['block', 'inline', 'inline-block', 'flex', 'inline-flex', 'grid', 'inline-grid', 'flow-root'],
  text: ['block', 'inline', 'inline-block', 'flow-root'], media: ['block', 'inline', 'inline-block'],
  extra: ['block', 'inline', 'inline-block', 'flow-root', 'none'], slot: ['block', 'inline', 'inline-block', 'flex', 'inline-flex', 'grid', 'inline-grid', 'flow-root', 'none'],
};
def('display', KIND.all, single((n, c) => {
  const set = c.boxLike ? DISPLAYS.boxy : DISPLAYS[c.kind === 'layout' || c.kind === 'control' || c.kind === 'notice' ? 'boxy' : c.kind];
  if (n.t === 'ident' && set.includes(n.v)) return null;
  if (n.t === 'ident' && n.v === 'none') return `display: none would hide this part. ${c.kind === 'control' || c.kind === 'notice' ? 'Shoppers must always be able to find and use it.' : 'Only optional extras and the decoration areas may be hidden.'}`;
  if (n.t === 'ident' && n.v === 'contents') return 'display: contents removes the part\'s own box, so nothing about it could be styled and a control would lose its shape.';
  return `Allowed: ${set.join(', ')}.`;
}));
def('visibility', KIND.hideable, kw('visible', 'hidden'));
def('flex', KIND.boxy, (v, c) => {
  if (v.length === 1 && v[0].t === 'ident' && ['none', 'auto', 'initial'].includes(v[0].v)) return null;
  if (v.length < 1 || v.length > 3) return 'needs one to three values.';
  for (const n of v) { if (n.t === 'num') { if (n.v < 0 || n.v > 10) return 'a flex number is between 0 and 10.'; continue; } const r = lengthReason(n, PROF.minSize, c); if (r) return r; }
  return null;
});
def('flex-direction', KIND.boxy, kw('row', 'row-reverse', 'column', 'column-reverse'));
def('flex-wrap', KIND.boxy, kw('nowrap', 'wrap', 'wrap-reverse'));
def('flex-flow', KIND.boxy, (v) => (v.every((n) => n.t === 'ident' && ['row', 'row-reverse', 'column', 'column-reverse', 'nowrap', 'wrap', 'wrap-reverse'].includes(n.v)) && v.length <= 2 ? null : 'Allowed: row, column, wrap, nowrap (and the reverse forms).'));
def(['flex-grow', 'flex-shrink'], KIND.boxy, single((n) => (n.t === 'num' && n.v >= 0 && n.v <= 10 ? null : 'must be a number from 0 to 10.')));
def('flex-basis', KIND.boxy, single((n, c) => (n.t === 'ident' ? (['auto', 'content'].includes(n.v) ? null : 'Allowed: auto, content, or a length.') : lengthReason(n, PROF.minSize, c))));
def(['align-items', 'align-self', 'justify-items', 'justify-self'], KIND.boxy, kw('start', 'end', 'center', 'stretch', 'baseline', 'flex-start', 'flex-end', 'normal', 'auto', 'self-start', 'self-end'));
def(['align-content', 'justify-content'], KIND.boxy, kw('start', 'end', 'center', 'stretch', 'space-between', 'space-around', 'space-evenly', 'flex-start', 'flex-end', 'normal'));
def(['place-items', 'place-content', 'place-self'], KIND.boxy, (v) => (v.length >= 1 && v.length <= 2 && v.every((n) => n.t === 'ident' && ['start', 'end', 'center', 'stretch', 'baseline', 'space-between', 'space-around', 'space-evenly', 'normal', 'auto'].includes(n.v)) ? null : 'Allowed: start, end, center, stretch, space-between, space-around, space-evenly.'));
def('order', KIND.boxy.concat(['text', 'media', 'extra']), single((n) => (n.t === 'num' && n.int && n.v >= -10 && n.v <= 10 ? null : 'must be a whole number from -10 to 10.')));
def(['overflow', 'overflow-x', 'overflow-y'], KIND.boxy, (v) => (v.length >= 1 && v.length <= 2 && v.every((n) => n.t === 'ident' && ['visible', 'hidden', 'auto', 'clip'].includes(n.v)) ? null : 'Allowed: visible, hidden, auto, clip.'));
def('box-sizing', KIND.all, kw('border-box', 'content-box'));
const trackReason = (n, c, depth, first) => {
  if (n.t === 'ident') return ['auto', 'min-content', 'max-content', 'none', 'masonry'].includes(n.v) && n.v !== 'masonry' ? null : `"${clip(n.v, 20)}" is not a track size.`;
  if (n.t === 'dim' && n.unit === 'fr') return n.v > 0 && n.v <= 12 ? null : 'a fr size is a number above 0 up to 12 (0fr could make a column vanish).';
  if (n.t === 'dim' || n.t === 'pct') return lengthReason(n, first ? PROF.trackMin : PROF.track, c);
  if (n.t === 'num' && n.v === 0 && first) return null;
  if (n.t === 'fn') {
    const a = splitOn(n.items, 'comma').map(sig);
    if (n.name === 'minmax') { if (a.length !== 2 || a[0].length !== 1 || a[1].length !== 1) return 'minmax() needs two values.'; return trackReason(a[0][0], c, depth + 1, true) || trackReason(a[1][0], c, depth + 1, false); }
    if (n.name === 'fit-content') { if (a.length !== 1 || a[0].length !== 1) return 'fit-content() needs one length.'; return lengthReason(a[0][0], PROF.track, c); }
    if (n.name === 'repeat') {
      if (depth > 1 || a.length < 2) return 'repeat() is written repeat(count, sizes).';
      const count = a[0][0];
      if (a[0].length !== 1 || !((count.t === 'num' && count.int && count.v >= 1 && count.v <= 12) || (count.t === 'ident' && ['auto-fill', 'auto-fit'].includes(count.v)))) return 'repeat() takes a count from 1 to 12, or auto-fill / auto-fit.';
      for (const part of a.slice(1)) for (const x of part) { const r = trackReason(x, c, depth + 1, false); if (r) return r; }
      return null;
    }
    return `"${clip(n.name, 20)}()" is not allowed here.`;
  }
  return 'is not a track size.';
};
def(['grid-template-columns', 'grid-template-rows', 'grid-auto-columns', 'grid-auto-rows'], KIND.boxy, (v, c) => { if (v.length > 16) return 'has too many tracks.'; for (const n of v) { const r = trackReason(n, c, 0, false); if (r) return r; } return null; });
def('grid-auto-flow', KIND.boxy, (v) => (v.every((n) => n.t === 'ident' && ['row', 'column', 'dense'].includes(n.v)) ? null : 'Allowed: row, column, dense.'));
def(['grid-column', 'grid-row', 'grid-column-start', 'grid-column-end', 'grid-row-start', 'grid-row-end', 'grid-area'], KIND.all, (v) => (v.length <= 7 && v.every((n) => (n.t === 'num' && n.int && Math.abs(n.v) <= 24) || (n.t === 'ident' && ['span', 'auto'].includes(n.v)) || (n.t === 'delim' && n.v === '/')) ? null : 'Allowed: whole numbers, span, auto and "/".'));

// sizes
const sizeProf = (c) => (c.kind === 'slot' ? PROF.free : c.kind === 'layout' ? PROF.minSize : PROF.minSizeSmall);
def('min-height', KIND.all, single((n, c) => (n.t === 'ident' ? (n.v === 'auto' ? null : 'Allowed: a length.') : lengthReason(n, sizeProf(c), c))));
def('min-width', KIND.all, single((n, c) => (n.t === 'ident' ? (n.v === 'auto' ? null : 'Allowed: a length.') : lengthReason(n, sizeProf(c), c))));
def('max-width', KIND.all, single((n, c) => (n.t === 'ident' ? (['none', 'fit-content', 'max-content'].includes(n.v) ? null : 'Allowed: none, fit-content, or a length of at least 280px.') : lengthReason(n, c.kind === 'slot' ? PROF.free : PROF.maxWidth, c))));
def('aspect-ratio', KIND.all, (v) => {
  if (v.length === 1 && v[0].t === 'ident' && v[0].v === 'auto') return null;
  const nums = v.filter((n) => n.t === 'num');
  if (nums.length < 1 || nums.length > 2 || v.some((n) => n.t !== 'num' && !(n.t === 'delim' && n.v === '/')) || v.length > 3) return 'must be written like 16 / 9.';
  const ratio = nums.length === 2 ? nums[0].v / nums[1].v : nums[0].v;
  return ratio >= 0.2 && ratio <= 5 ? null : 'must be between 1:5 and 5:1.';
});
def('object-fit', KIND.img, kw('fill', 'contain', 'cover', 'none', 'scale-down'));
def('object-position', KIND.img, (v, c) => { if (v.length < 1 || v.length > 4) return 'needs one to four values.'; for (const n of v) { if (n.t === 'ident' && ['left', 'right', 'top', 'bottom', 'center'].includes(n.v)) continue; const r = lengthReason(n, PROF.bg, c); if (r) return r; } return null; });
const freeLen = (v, c, words = ['auto']) => { if (v.length < 1 || v.length > 4) return 'needs one to four values.'; for (const n of v) { if (n.t === 'ident' && words.includes(n.v)) continue; const r = lengthReason(n, PROF.free, c); if (r) return r; } return null; };
def(['width', 'height', 'max-height'], KIND.slot, (v, c) => freeLen(v, c, ['auto', 'fit-content', 'min-content', 'max-content', 'none']));
def(['top', 'right', 'bottom', 'left', 'inset'], KIND.slot, (v, c) => freeLen(v, c));
def('position', KIND.slot, kw('static', 'relative', 'absolute'));
def('z-index', KIND.all, single((n, c) => {
  if (n.t === 'ident') return n.v === 'auto' ? null : 'Allowed: auto, or a whole number.';
  if (n.t !== 'num' || !n.int) return 'must be a whole number.';
  const lo = c.kind === 'slot' ? -Z_INDEX_CEILING : 0;
  return n.v >= lo && n.v <= Z_INDEX_CEILING ? null : `must be a whole number from ${lo} to ${Z_INDEX_CEILING}. Everything above ${Z_INDEX_CEILING} belongs to the website's own bars, banners and dialogs, so that nothing in a pack can be drawn over them${lo === 0 ? ' (and a negative number would put a part behind the page)' : ''}.`;
}));
def('transform', KIND.movable, (v, c) => transformReason(v, c, c.kind === 'slot'));
def('transform-origin', KIND.slot, (v, c) => freeLen(v, c, ['left', 'right', 'top', 'bottom', 'center']));
def('filter', KIND.img, (v, c) => filterReason(v, c, c.kind === 'slot'));
def('mix-blend-mode', KIND.slot, kw('normal', 'multiply', 'screen', 'overlay', 'darken', 'lighten', 'color-dodge', 'color-burn', 'hard-light', 'soft-light', 'difference', 'exclusion', 'hue', 'saturation', 'color', 'luminosity'));
def('clip-path', KIND.slot, (v, c) => {
  if (v.length === 1 && v[0].t === 'ident' && v[0].v === 'none') return null;
  if (v.length !== 1 || v[0].t !== 'fn' || !['circle', 'ellipse', 'inset', 'polygon'].includes(v[0].name)) return 'Allowed: circle(), ellipse(), inset(), polygon().';
  const items = sig(v[0].items);
  if (items.length > 40) return 'has too many points.';
  for (const n of items) {
    if (n.t === 'comma' || n.t === 'num') continue;
    if (n.t === 'ident' && ['at', 'round', 'closest-side', 'farthest-side', 'center', 'top', 'bottom', 'left', 'right', 'nonzero', 'evenodd'].includes(n.v)) continue;
    if (n.t === 'dim' || n.t === 'pct') { const r = lengthReason(n, PROF.free, c); if (r) return r; continue; }
    return 'has something in it that is not allowed.';
  }
  return null;
});
def('content', KIND.all, single((n, c) => {
  if (!c.boxLike) return 'only works on ::before and ::after.';
  if (n.t === 'ident') return ['none', 'normal'].includes(n.v) ? null : 'Allowed: none, normal, or a short symbol in quotes (counters, attributes, pictures and the like are not allowed).';
  if (n.t !== 'string') return 'must be a short symbol in quotes, like "\\2022".';
  const max = c.kind === 'slot' ? 12 : 3;
  if ([...n.v].length > max) return `a symbol is at most ${max} characters long.`;
  if (/[\p{L}\p{N}]/u.test(n.v)) return 'words and numbers are the shop\'s own wording, so a style sheet may not add any. Only symbols (a bullet, an arrow, a quote mark) are allowed.';
  return null;
}));

// animation: only on the empty decoration areas, only with keyframes the pack declares itself
const KEYFRAME_NAME = /^pack-[a-z0-9][a-z0-9-]{0,40}$/;
const animationItem = (n, c, tally) => {
  if (n.t === 'ident') {
    if (['normal', 'forwards', 'backwards', 'both', 'running', 'paused', 'infinite', 'alternate', 'reverse', 'alternate-reverse', 'none'].includes(n.v) || EASING.has(n.v)) return null;
    if (n.raw === n.v && KEYFRAME_NAME.test(n.v)) { c.info.animationNames.push(n.v); return null; }
    return `"${clip(n.raw, 30)}" is not an animation word, and animation names must start with "pack-" and be declared with @keyframes in the same pack.`;
  }
  if (n.t === 'num') { if (n.v < 0 || n.v > 100) return 'a repeat count is from 0 to 100.'; tally.counts += 1; return null; }
  if (n.t === 'dim') return timeReason(n, 60);
  if (n.t === 'fn') return easingFnReason(n);
  return 'is not allowed in an animation.';
};
def('animation', KIND.slot, (v, c) => { for (const item of splitOn(v, 'comma').map(sig)) { const tally = { counts: 0 }; for (const n of item) { const r = animationItem(n, c, tally); if (r) return r; } } return null; });
def(['animation-name', 'animation-duration', 'animation-delay', 'animation-iteration-count', 'animation-direction', 'animation-fill-mode', 'animation-play-state', 'animation-timing-function'], KIND.slot, (v, c) => { for (const n of v) { if (n.t === 'comma') continue; const r = animationItem(n, c, { counts: 0 }); if (r) return r; } return null; });

const PSEUDO_SIZE = new Set(['width', 'height', 'min-width', 'min-height', 'max-width', 'max-height']);
/** The properties that may carry a url() in their value (everything else with a url is refused by the value check anyway). */
export const PROPERTY_NAMES = Object.freeze([...PROPS.keys()].sort());

/** One setting "name: value" of a rule whose subject is `c.kind`. Returns the canonical text, or null when it was refused (a problem was reported). */
function checkSetting(decl, c, report) {
  let name = decl.name;
  if (name.startsWith('--')) { report('custom-property', `The style sheet defines its own variable "${clip(name, 30)}".`, 'A pack sets its look through the tokens. A free-form variable could hold anything and hand it on to a setting that is checked, so it is not allowed. Read the website\'s variables with var(--ngos-...).'); return null; }
  if (decl.important) { report('important', `The setting "${clip(name, 30)}" uses !important.`, '!important would let a pack override the website\'s own protection of its controls and notices, so it is not allowed.'); return null; }
  const pseudoBox = c.boxLike && PSEUDO_SIZE.has(name) && c.kind !== 'slot';
  let entry = PROPS.get(name);
  if (!entry) {
    const why = own(WHY_PROPERTY, name) ? WHY_PROPERTY[name] : /^-(moz|ms|o)-/.test(name) || /^-webkit-/.test(name) ? 'Browser-specific settings are not on the list a pack may use.' : 'It is not on the list of settings a pack may use (docs/DESIGN-PACK.md).';
    report('property-not-allowed', `The setting "${clip(name, 40)}" is not allowed.`, why);
    return null;
  }
  if (pseudoBox) entry = { kinds: new Set(KIND.all), f: single((n, cc) => (n.t === 'ident' ? (n.v === 'auto' || n.v === 'none' ? null : 'Allowed: a length.') : lengthReason(n, PROF.pseudo, cc))), why: '' };
  if (!entry.kinds.has(c.kind)) {
    const why = own(WHY_PROPERTY, name) ? WHY_PROPERTY[name] : '';
    report('property-not-for-part', `The setting "${name}" cannot be used on the part "${c.part}" (a ${c.kind}).`, `${why ? `${why} ` : ''}${WHY_KIND[c.kind] || ''}`.trim());
    return null;
  }
  const v = sig(decl.value);
  if (v.length === 0) { report('empty-value', `The setting "${name}" has no value.`, 'Write a value after the colon.'); return null; }
  if (v.length === 1 && v[0].t === 'ident' && globalKw.has(v[0].v)) return `${name}: ${v[0].v}`;
  // Something that can carry an address or code is looked at before anything else, so that the reason given is the real one.
  const hasOutside = (nodes) => nodes.some((n) => n.t === 'url' || (n.t === 'fn' && (n.name === 'url' || own(REFUSED_IMAGE_FUNCTIONS, n.name))) || (n.items && hasOutside(n.items)));
  if (hasOutside(v) && !['background', 'background-image'].includes(name)) { report('url-not-allowed', `The setting "${name}" uses a picture or file address.`, 'Only background and background-image may use a picture, and only the pack\'s own files (assets/<name>).'); return null; }
  const reason = entry.f(v, c);
  if (reason) { report('value-not-allowed', `The setting "${name}: ${clip(nodesText(decl.value), 60)}" is not allowed.`, said(reason)); return null; }
  return `${name}: ${nodesText(decl.value)}`;
}

// ---------------------------------------------------------------------------------------------------------------------
// 10. Reading a whole style sheet: rules, @media, @supports, @keyframes
// ---------------------------------------------------------------------------------------------------------------------

/** What a rule's settings may not do together (the single settings were already checked one by one). */
function checkCombinations(c, report) {
  if (c.kind === 'slot') return;
  const { color, bg } = c.info;
  if (color && color.rgba && color.rgba[3] < 0.5) {
    if (!(c.kind === 'text' && c.info.clipText && c.info.gradient)) report('text-invisible', `The text colour of "${c.part}" is transparent, or nearly so.`, 'Text that cannot be seen cannot be read. (A gradient heading is allowed on a text part when the rule also says background-clip: text and gives a gradient background.)');
  }
  if (color && color.rgba && bg && bg.rgba && color.rgba[3] >= 0.5 && bg.rgba[3] >= 0.5) {
    const ratio = contrastRatio(color.rgba, bg.rgba);
    if (ratio < 3) report('low-contrast', `In this rule the text colour and the background colour of "${c.part}" are too alike (contrast ${ratio.toFixed(1)} to 1; at least 3 to 1 is needed).`, 'Text that is hard to tell from its background cannot be read. Pick colours that differ more.');
  }
}

const newInfo = () => ({ color: null, bg: null, clipText: false, gradient: false, animationNames: [] });

function analyseStyleSheet(css, env, sink) {
  const stats = { rules: 0, selectors: 0, declarations: 0 };
  const defined = new Set();
  const usedAnimations = new Set();
  const topProblem = (code, what, why) => sink.add(code, 'style sheet', what, why);
  if (typeof css !== 'string') { topProblem('css-type', 'The style sheet is not text.', 'It must be a piece of text.'); return { sheet: '', stats }; }
  if (new TextEncoder().encode(css).length > LIMITS.cssBytes) { topProblem('css-too-big', `The style sheet is bigger than ${Math.round(LIMITS.cssBytes / 1024)} KB.`, 'A pack\'s style sheet is meant to be a small set of rules. A very big one slows every visitor\'s first page.'); return { sheet: '', stats }; }
  const { tokens, errors } = tokenizeCss(css);
  for (const e of errors) topProblem(e.code, e.what, e.why);
  if (tokens.length > LIMITS.cssTokens) { topProblem('css-too-big', 'The style sheet has far too many pieces.', 'Keep it to a small set of rules.'); return { sheet: '', stats }; }
  const tree = buildTree(tokens);
  for (const e of tree.errors) topProblem(e.code, e.what, e.why);
  if (errors.length || tree.errors.length) return { sheet: '', stats };

  const keyframesBlock = (r, where) => {
    const s = sig(r.prelude);
    const nameNode = s[0];
    if (s.length !== 1 || nameNode.t !== 'ident' || nameNode.raw !== nameNode.v || !KEYFRAME_NAME.test(nameNode.v)) { sink.add('keyframes-name', where, 'An animation name is not written the allowed way.', 'Animation names start with "pack-" and use small letters, digits and hyphens (for example pack-float), so that they can never replace one of the website\'s own animations.'); return null; }
    if (defined.has(nameNode.v)) { sink.add('keyframes-twice', where, `The animation "${nameNode.v}" is declared twice.`, 'Declare each animation once.'); return null; }
    if (defined.size >= LIMITS.keyframesBlocks) { sink.add('too-many-keyframes', where, `There are more than ${LIMITS.keyframesBlocks} animations.`, 'Keep to a few.'); return null; }
    defined.add(nameNode.v);
    if (!r.body) { sink.add('keyframes-body', where, `The animation "${nameNode.v}" has no frames.`, 'Write @keyframes pack-name { from { ... } to { ... } }.'); return null; }
    const frames = splitRules(r.body, (code, what, why) => sink.add(code, where, what, why));
    if (frames.length === 0 || frames.length > LIMITS.keyframeStops) { sink.add('keyframes-body', where, `The animation "${nameNode.v}" has ${frames.length} frames.`, `It needs 1 to ${LIMITS.keyframeStops}.`); return null; }
    const out = [];
    for (const f of frames) {
      if (f.kind !== 'style') { sink.add('keyframes-body', where, 'A frame of an animation is not written the allowed way.', 'Use from, to, or percentages.'); continue; }
      const stops = splitOn(f.prelude, 'comma').map(sig);
      const stopText = [];
      for (const st of stops) {
        if (st.length === 1 && st[0].t === 'ident' && (st[0].v === 'from' || st[0].v === 'to')) stopText.push(st[0].v);
        else if (st.length === 1 && st[0].t === 'pct' && st[0].v >= 0 && st[0].v <= 100) stopText.push(`${st[0].repr}%`);
        else sink.add('keyframes-stop', where, `The frame position "${clip(nodesText(st), 20)}" is not allowed.`, 'Use from, to, or a percentage from 0% to 100%.');
      }
      const { decls, nested } = splitDeclarations(f.body, (code, what, why) => sink.add(code, where, what, why));
      if (nested) sink.add('nested-rule', where, 'A frame has another rule inside it.', 'Frames contain only settings.');
      const c = { kind: 'slot', part: 'decoration', pseudo: null, boxLike: false, env, info: newInfo(), noCalc: false, inKeyframes: true };
      const texts = [];
      for (const d of decls) {
        stats.declarations += 1;
        if (/^(animation|transition)/.test(d.name)) { sink.add('keyframes-setting', where, `A frame of an animation sets "${d.name}".`, 'Frames may only change how the part looks, not start another animation.'); continue; }
        const t = checkSetting(d, c, (code, what, why) => sink.add(code, where, what, why));
        if (t) texts.push(t);
      }
      if (stopText.length) out.push(`${stopText.join(', ')} { ${texts.join('; ')} }`);
    }
    return `@keyframes ${nameNode.v} {\n${out.join('\n')}\n}`;
  };

  const walk = (rules, depth) => {
    const out = [];
    for (const r of rules) {
      if (r.kind === 'at') {
        const where = `style sheet, @${r.name}`;
        if (r.name === 'media' || r.name === 'supports') {
          if (depth >= LIMITS.atRuleDepth) { sink.add('at-rule-deep', where, `@${r.name} blocks are nested more than ${LIMITS.atRuleDepth} deep.`, 'Keep them shallow.'); continue; }
          if (!r.body) { sink.add('at-rule-body', where, `@${r.name} has no { } block.`, 'Write the rules to apply inside { }.'); continue; }
          const cond = r.name === 'media' ? checkMediaCondition(r.prelude, (code, what, why) => sink.add(code, where, what, why)) : checkSupportsCondition(r.prelude, (code, what, why) => sink.add(code, where, what, why));
          const inner = walk(splitRules(r.body, (code, what, why) => sink.add(code, where, what, why)), depth + 1);
          if (cond !== null && inner.length) out.push(`@${r.name} ${cond} {\n${inner.join('\n')}\n}`);
        } else if (r.name === 'keyframes' || r.name === '-webkit-keyframes') {
          if (depth > 0) { sink.add('keyframes-nested', where, '@keyframes is inside another block.', 'Write @keyframes at the top of the style sheet.'); continue; }
          const k = keyframesBlock(r, where);
          if (k) out.push(k);
        } else {
          sink.add(r.name === 'import' ? 'import' : 'at-rule', where, `The style sheet uses @${clip(r.name, 30)}.`, own(AT_RULE_WHY, r.name) ? AT_RULE_WHY[r.name] : 'It is not one of the at-rules a pack may use (@media, @supports, @keyframes).');
        }
        continue;
      }
      stats.rules += 1;
      if (stats.rules > LIMITS.rules) { sink.add('too-many-rules', 'style sheet', `There are more than ${LIMITS.rules} rules.`, 'Keep the sheet small.'); break; }
      const where0 = `style sheet, rule ${stats.rules}`;
      const sels = parseSelectorList(r.prelude, (code, what, why) => sink.add(code, `${where0} (${clip(nodesText(r.prelude), 50)})`, what, why));
      if (!sels) continue;
      const where = `${where0} (${clip(sels.map((s) => s.text).join(', '), 70)})`;
      stats.selectors += sels.length;
      if (stats.selectors > LIMITS.selectors) { sink.add('too-many-selectors', 'style sheet', `There are more than ${LIMITS.selectors} selectors.`, 'Keep the sheet small.'); break; }
      const { decls, nested } = splitDeclarations(r.body, (code, what, why) => sink.add(code, where, what, why));
      if (nested) sink.add('nested-rule', where, 'A rule has another rule inside it (nesting).', 'Write every rule on its own, with its full selector. Nested rules are read differently by different browsers.');
      stats.declarations += decls.length;
      if (stats.declarations > LIMITS.declarations) { sink.add('too-many-settings', 'style sheet', `There are more than ${LIMITS.declarations} settings.`, 'Keep the sheet small.'); break; }
      const subjects = [];
      for (const s of sels) if (!subjects.some((x) => x.part === s.subject && x.element === s.element)) subjects.push({ part: s.subject, element: s.element });
      let allOk = !nested;
      let texts = [];
      subjects.forEach((s, i) => {
        const kind = PARTS[s.part].kind;
        const c = { kind, part: s.part, pseudo: s.element, boxLike: s.element === 'before' || s.element === 'after', env, info: newInfo(), noCalc: REQUIRED_KINDS.includes(kind), inKeyframes: false };
        const own1 = [];
        for (const d of decls) {
          const t = checkSetting(d, c, (code, what, why) => sink.add(code, where, what, why));
          if (t) own1.push(t); else allOk = false;
        }
        checkCombinations(c, (code, what, why) => { allOk = false; sink.add(code, where, what, why); });
        for (const n of c.info.animationNames) usedAnimations.add(n);
        if (i === 0) texts = own1;
      });
      if (allOk && texts.length) out.push(`${sels.map((s) => `:root ${s.text}`).join(',\n')} {\n  ${texts.join(';\n  ')};\n}`);
    }
    return out;
  };

  const top = splitRules(tree.items, topProblem);
  const out = walk(top, 0);
  for (const n of usedAnimations) if (!defined.has(n)) sink.add('animation-unknown', 'style sheet', `The animation "${n}" is used but never declared.`, 'Declare it with @keyframes in the same style sheet.');
  return { sheet: out.join('\n'), stats };
}

/** A last, independent look at text that is about to be written out: it must hold nothing from the list of things that are never allowed, whatever the checks above decided. */
function finalScan(text) {
  const issues = [];
  const noStrings = text.replace(/"(?:[^"\\]|\\.)*"/g, '""');
  if (/\\/.test(noStrings)) issues.push('a backslash outside quoted text');
  if (/[<]/.test(text) || /<\/|<!--|-->/.test(text)) issues.push('a "<" character');
  const lower = text.toLowerCase();
  for (const word of ['javascript:', 'vbscript:', 'livescript:', '@import', 'expression(', '-moz-binding', 'data:', 'image-set(', 'cross-fade(', 'element(', 'paint(', 'attr(', 'env(', '@charset', '@namespace', 'src(']) if (lower.includes(word)) issues.push(`"${word}"`);
  if (/(^|[^a-z-])behavior\s*:/.test(lower)) issues.push('"behavior"');
  const urls = (text.match(/url\(/gi) || []).length;
  const good = (text.match(/url\("assets\/[a-z0-9][a-z0-9._-]{0,47}"\)/g) || []).length;
  if (urls !== good) issues.push('an address that is not one of the pack\'s own files');
  return issues;
}

// ---------------------------------------------------------------------------------------------------------------------
// 11. The whole pack
// ---------------------------------------------------------------------------------------------------------------------

const TOP_KEYS = ['schema', 'name', 'note', 'tokens', 'fontFiles', 'css', 'assets'];
const PLAIN_NAME = /^[\p{L}\p{N} ._,'()&-]{1,60}$/u;
const PLAIN_NOTE = /^[^<>\u0000-\u0008\u000b-\u001f\u007f]{0,300}$/u;
const ASSET_NAME = /^[a-z0-9][a-z0-9._-]{0,47}\.(woff2|woff|png|jpe?g|webp)$/;
const kebab = (k) => k.replace(/[A-Z]/g, (ch) => `-${ch.toLowerCase()}`);

/** Reads a hex colour token "#rgb" or "#rrggbb" (no see-through) as "#rrggbb", or null. */
const hexToken = (v) => (typeof v === 'string' && /^#(?:[0-9a-fA-F]{3}|[0-9a-fA-F]{6})$/.test(v) ? `#${(v.length === 4 ? v.slice(1).split('').map((x) => x + x).join('') : v.slice(1)).toLowerCase()}` : null);
const lengthToken = (v) => { const m = typeof v === 'string' ? /^(\d+(?:\.\d+)?)(px|rem)$/.exec(v) : null; return m ? { n: Number(m[1]), unit: m[2], px: Number(m[1]) * (m[2] === 'rem' ? 16 : 1) } : null; };

function b64Bytes(text) {
  if (typeof text !== 'string' || text.length === 0 || text.length % 4 !== 0 || !/^[A-Za-z0-9+/]+={0,2}$/.test(text)) return null;
  let bin;
  try { bin = atob(text); } catch { return null; }
  const bytes = new Uint8Array(bin.length);
  for (let i = 0; i < bin.length; i += 1) bytes[i] = bin.charCodeAt(i);
  return bytes;
}
const startsWith = (b, sigBytes, at = 0) => sigBytes.every((x, i) => b[at + i] === x);
function sniff(bytes) {
  if (startsWith(bytes, [0x77, 0x4f, 0x46, 0x32])) return { type: 'font', format: 'woff2' };
  if (startsWith(bytes, [0x77, 0x4f, 0x46, 0x46])) return { type: 'font', format: 'woff' };
  if (startsWith(bytes, [0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a])) return { type: 'image', format: 'png' };
  if (startsWith(bytes, [0xff, 0xd8, 0xff])) return { type: 'image', format: 'jpeg' };
  if (startsWith(bytes, [0x52, 0x49, 0x46, 0x46]) && startsWith(bytes, [0x57, 0x45, 0x42, 0x50], 8)) return { type: 'image', format: 'webp' };
  return null;
}

/** FNV-1a (64 bit) over the text and the files, as 12 hex digits: a label for "this exact pack", used to name a version. It is not a security measure. */
export function packId(css, assets = {}) {
  let h = 0xcbf29ce484222325n;
  const mix = (b) => { h ^= BigInt(b); h = (h * 0x100000001b3n) & 0xffffffffffffffffn; };
  for (const b of new TextEncoder().encode(css)) mix(b);
  for (const name of Object.keys(assets).sort()) { for (const b of new TextEncoder().encode(name)) mix(b); for (const b of assets[name]) mix(b); }
  return h.toString(16).padStart(16, '0').slice(0, 12);
}

/**
 * Checks a design pack. `input` is the pack as text (a string or bytes) or as an object.
 *   options: { findSecrets(text) -> [kind] }  an extra secret scanner (the repository's own list); the built-in shapes are always used.
 * Returns { ok, problems: [{ code, where, what, why }], pack, sheet, stats } where `sheet` is the checked style sheet written out afresh (only when ok).
 */
export function validateDesignPack(input, options = {}) {
  const sink = new Sink();
  const done = (extra = {}) => { const problems = sink.finish(); return { ok: problems.length === 0, problems, pack: null, sheet: '', stats: null, ...(problems.length === 0 ? extra : {}) }; };
  let pack = input;
  if (typeof input === 'string' || input instanceof Uint8Array) {
    let text = input;
    if (typeof input !== 'string') { try { text = new TextDecoder('utf-8', { fatal: true }).decode(input); } catch { sink.add('not-text', 'the pack', 'The pack is not plain text.', 'A pack is one JSON text file.'); return done(); } }
    if (new TextEncoder().encode(text).length > LIMITS.packBytes) { sink.add('pack-too-big', 'the pack', `The pack is bigger than ${Math.round(LIMITS.packBytes / 1024 / 1024)} MB.`, 'Use fewer or smaller pictures and fonts.'); return done(); }
    try { pack = JSON.parse(text); } catch { sink.add('not-json', 'the pack', 'The pack cannot be read: it is not valid JSON.', 'A pack is one JSON file. Check the commas and quotes.'); return done(); }
  }
  if (!isObj(pack)) { sink.add('not-object', 'the pack', 'The pack is not a JSON object.', 'It must start with { and hold name, tokens, css and so on.'); return done(); }
  for (const k of Object.keys(pack)) if (!TOP_KEYS.includes(k)) sink.add('unknown-key', 'the pack', `The pack has a part called "${clip(k, 30)}", which is not known.`, `A pack has only: ${TOP_KEYS.join(', ')}.`);
  if (pack.schema !== DESIGN_PACK_SCHEMA) sink.add('schema', 'schema', `The pack's "schema" is ${clip(JSON.stringify(pack.schema), 20)}; it must be ${DESIGN_PACK_SCHEMA}.`, 'This is the version of the pack format.');
  if (typeof pack.name !== 'string' || !PLAIN_NAME.test(pack.name)) sink.add('name', 'name', 'The pack needs a name of 1 to 60 plain characters (letters, digits, spaces and . , \' ( ) & -).', 'The name is shown to staff.');
  if (pack.note !== undefined && (typeof pack.note !== 'string' || !PLAIN_NOTE.test(pack.note))) sink.add('note', 'note', 'The note must be plain text of at most 300 characters, with no < or >.', 'The note is shown to staff.');

  // ----- assets -----
  const assets = {};
  const assetBytes = {};
  let total = 0;
  if (pack.assets !== undefined) {
    if (!isObj(pack.assets)) sink.add('assets', 'assets', '"assets" must be an object of file names.', 'Each file is { "base64": "..." }.');
    else {
      const names = Object.keys(pack.assets);
      if (names.length > LIMITS.assets) sink.add('assets-many', 'assets', `There are more than ${LIMITS.assets} files.`, 'Keep only what the design uses.');
      for (const name of names) {
        const where = `assets.${clip(name, 40)}`;
        if (!ASSET_NAME.test(name)) { sink.add('asset-name', where, `The file name "${clip(name, 40)}" is not allowed.`, 'Use small letters, digits, dots, hyphens and underscores, ending in .woff2, .woff, .png, .jpg, .jpeg or .webp (at most 48 characters, no folders).'); continue; }
        const item = pack.assets[name];
        if (!isObj(item) || Object.keys(item).some((k) => k !== 'base64')) { sink.add('asset-shape', where, 'A file must be written as { "base64": "..." }.', 'Nothing else is allowed beside the file\'s content.'); continue; }
        const bytes = b64Bytes(item.base64);
        if (!bytes) { sink.add('asset-base64', where, 'The file\'s content is not valid base64 text.', 'The content must be the file written in base64.'); continue; }
        const kind = sniff(bytes);
        const ext = name.slice(name.lastIndexOf('.') + 1);
        if (!kind) { sink.add('asset-type', where, 'The file is not a font (woff2, woff) or a picture (png, jpeg, webp).', 'The first bytes of the file say what it really is, and this is not one of the allowed kinds. Scalable pictures (svg) are not allowed, because they can carry program code.'); continue; }
        if ((ext === 'jpg' ? 'jpeg' : ext) !== kind.format) { sink.add('asset-type', where, `The file is named .${ext} but is really a ${kind.format} file.`, 'The name must match what the file is.'); continue; }
        const max = kind.type === 'font' ? LIMITS.fontBytes : LIMITS.assetBytes;
        if (bytes.length > max) { sink.add('asset-big', where, `The file is ${Math.round(bytes.length / 1024)} KB; the most for a ${kind.type === 'font' ? 'font' : 'picture'} is ${Math.round(max / 1024)} KB.`, 'Big files slow every visitor\'s first page.'); continue; }
        if (kind.format === 'png') {
          const w = ((bytes[16] << 24) | (bytes[17] << 16) | (bytes[18] << 8) | bytes[19]) >>> 0; const h = ((bytes[20] << 24) | (bytes[21] << 16) | (bytes[22] << 8) | bytes[23]) >>> 0;
          if (!w || !h || w > LIMITS.pictureSide || h > LIMITS.pictureSide || w * h > 36e6) { sink.add('asset-dimensions', where, `The picture is ${w} by ${h} pixels.`, `A picture may be at most ${LIMITS.pictureSide} pixels on a side. A huge picture can make a phone run out of memory.`); continue; }
        }
        total += bytes.length;
        assets[name] = { type: kind.type, format: kind.format };
        assetBytes[name] = bytes;
      }
      if (total > LIMITS.assetsTotalBytes) sink.add('assets-total', 'assets', `The files together are ${(total / 1024 / 1024).toFixed(1)} MB; the most is ${LIMITS.assetsTotalBytes / 1024 / 1024} MB.`, 'Big pages are slow, especially on phones.');
    }
  }

  // ----- font files -----
  const families = new Set();
  const fontFileEntries = [];
  if (pack.fontFiles !== undefined) {
    if (!Array.isArray(pack.fontFiles)) sink.add('fontfiles', 'fontFiles', '"fontFiles" must be a list.', 'Each entry names a font file from "assets".');
    else {
      if (pack.fontFiles.length > LIMITS.fontFiles) sink.add('fontfiles', 'fontFiles', `There are more than ${LIMITS.fontFiles} font files.`, 'Keep the fonts to what the design really uses.');
      pack.fontFiles.slice(0, LIMITS.fontFiles).forEach((f, i) => {
        const where = `fontFiles[${i}]`;
        if (!isObj(f) || Object.keys(f).some((k) => !['family', 'file', 'weight', 'style'].includes(k))) { sink.add('fontfile-shape', where, 'A font entry must be { family, file, weight, style }.', 'Nothing else is allowed.'); return; }
        if (typeof f.family !== 'string' || !/^[A-Za-z][A-Za-z0-9 ]{1,38}$/.test(f.family) || GENERIC_FONT_WORDS.includes(f.family.toLowerCase()) || own(FONT_STACKS, f.family.toLowerCase())) { sink.add('fontfile-family', where, `The font family name "${clip(f.family, 40)}" is not allowed.`, 'Use 2 to 39 letters, digits and spaces, not starting with a digit, and not the name of a generic family (serif, sans-serif, ...) or one of the website\'s own fonts.'); return; }
        if (typeof f.file !== 'string' || !assets[f.file] || assets[f.file].type !== 'font') { sink.add('fontfile-file', where, `The font file "${clip(f.file, 40)}" is not a font in "assets".`, 'Add the .woff2 or .woff file to "assets" first.'); return; }
        const weight = f.weight === undefined ? '400' : f.weight;
        if (typeof weight !== 'string' || !/^(normal|bold|[1-9]00|[1-9]00 [1-9]00)$/.test(weight)) { sink.add('fontfile-weight', where, 'The weight is written like 400, or 100 900 for a range.', 'Use normal, bold, or numbers from 100 to 900.'); return; }
        const style = f.style === undefined ? 'normal' : f.style;
        if (style !== 'normal' && style !== 'italic') { sink.add('fontfile-style', where, 'The style is normal or italic.', 'Nothing else is allowed.'); return; }
        families.add(f.family);
        fontFileEntries.push({ family: f.family, file: f.file, weight, style, format: assets[f.file].format });
      });
    }
  }

  // ----- tokens -----
  const resolved = { color: { ...TOKEN_GROUPS.color }, font: { ...TOKEN_GROUPS.font }, radius: { ...TOKEN_GROUPS.radius }, space: { ...TOKEN_GROUPS.space }, shadow: { ...TOKEN_GROUPS.shadow } };
  const set = { color: {}, font: {}, radius: {}, space: {}, shadow: {} };
  if (pack.tokens !== undefined) {
    if (!isObj(pack.tokens)) sink.add('tokens', 'tokens', '"tokens" must be an object.', 'It holds color, font, radius, space and shadow.');
    else {
      for (const group of Object.keys(pack.tokens)) {
        if (!own(TOKEN_GROUPS, group)) { sink.add('token-group', `tokens.${clip(group, 30)}`, `There is no token group called "${clip(group, 30)}".`, `The groups are: ${Object.keys(TOKEN_GROUPS).join(', ')}.`); continue; }
        const values = pack.tokens[group];
        if (!isObj(values)) { sink.add('token-group', `tokens.${group}`, `"${group}" must be an object.`, 'It holds the named values.'); continue; }
        for (const key of Object.keys(values)) {
          const where = `tokens.${group}.${clip(key, 30)}`;
          const value = values[key];
          if (!own(TOKEN_GROUPS[group], key)) { sink.add('token-name', where, `There is no token called "${clip(key, 30)}".`, `The ${group} tokens are: ${Object.keys(TOKEN_GROUPS[group]).join(', ')}.`); continue; }
          if (group === 'color') {
            const hex = hexToken(value);
            if (!hex) { sink.add('token-colour', where, `"${clip(value, 20)}" is not a colour.`, 'Write a solid colour as #rrggbb (for example #0f6cbd).'); continue; }
            resolved.color[key] = hex; set.color[key] = hex;
          } else if (group === 'font') {
            const custom = typeof value === 'string' && value.startsWith('custom:') ? value.slice(7) : null;
            if (typeof value === 'string' && own(FONT_STACKS, value)) { resolved.font[key] = value; set.font[key] = value; } else if (custom && families.has(custom)) { resolved.font[key] = value; set.font[key] = value; } else sink.add('token-font', where, `"${clip(value, 40)}" is not an allowed font.`, `Use one of: ${Object.keys(FONT_STACKS).join(', ')}, or "custom:<family>" for a family in fontFiles.`);
          } else if (group === 'radius') {
            const len = lengthToken(value);
            const max = key === 'pill' ? 9999 : 40;
            if (!len || len.px > max) sink.add('token-length', where, `"${clip(value, 20)}" is not an allowed corner size.`, `Write a size in px or rem, at most ${key === 'pill' ? '9999px' : '40px (2.5rem)'}.`); else { resolved.radius[key] = value; set.radius[key] = value; }
          } else if (group === 'space') {
            const len = lengthToken(value);
            if (!len || len.px < 3 || len.px > 6) sink.add('token-length', where, `"${clip(value, 20)}" is not an allowed spacing unit.`, 'The unit is between 3px and 6px (0.1875rem to 0.375rem). Every gap on the website is a multiple of it. 4px (0.25rem) is the usual one.'); else { resolved.space[key] = value; set.space[key] = value; }
          } else if (group === 'shadow') {
            const probe = { kind: 'layout', part: 'page', pseudo: null, boxLike: false, env: { assets: {}, fontFamilies: new Set(), usedAssets: new Set(), usedFamilies: new Set(), tokenColors: {} }, info: newInfo() };
            const { tokens: ts, errors: es } = typeof value === 'string' ? tokenizeCss(value) : { tokens: [], errors: [1] };
            const tree = buildTree(ts);
            const reason = es.length || tree.errors.length ? 'is not a shadow.' : (() => { const v = sig(tree.items); return v.length === 1 && v[0].t === 'ident' && v[0].v === 'none' ? null : shadowListReason(v, probe, PROF.boxShadow, { allowInset: true }); })();
            if (reason) sink.add('token-shadow', where, `The shadow "${clip(value, 50)}" is not allowed.`, said(reason)); else { resolved.shadow[key] = nodesText(sig(tree.items)); set.shadow[key] = resolved.shadow[key]; }
          }
        }
      }
    }
  }

  // Colours that must stay readable, however the pack sets them (the website writes white and light-grey text in many places on these).
  const touched = (...keys) => keys.some((k) => own(set.color, k));
  const need = (fg, bg, min, key, what) => {
    const ratio = contrastRatio(hexToRgba(fg.slice(1)), hexToRgba(bg.slice(1)));
    if (ratio < min) sink.add('token-contrast', `tokens.color.${key}`, `${what} is hard to read (${ratio.toFixed(1)} to 1; at least ${min} to 1 is needed).`, 'Text that is hard to tell from its background cannot be read. Pick colours that differ more.');
  };
  const c = resolved.color;
  if (touched('text', 'canvas')) need(c.text, c.canvas, 4.5, 'text', `The text colour ${c.text} on the page colour ${c.canvas}`);
  if (touched('text', 'surface')) need(c.text, c.surface, 4.5, 'text', `The text colour ${c.text} on the card colour ${c.surface}`);
  if (touched('textMuted', 'canvas')) need(c.textMuted, c.canvas, 4.5, 'textMuted', `The quiet text colour ${c.textMuted} on the page colour ${c.canvas}`);
  if (touched('textMuted', 'surface')) need(c.textMuted, c.surface, 4.5, 'textMuted', `The quiet text colour ${c.textMuted} on the card colour ${c.surface}`);
  if (touched('onPrimary', 'primary')) need(c.onPrimary, c.primary, 4.5, 'onPrimary', `The text colour ${c.onPrimary} on the main colour ${c.primary}`);
  if (touched('primary')) { need('#ffffff', c.primary, 4.5, 'primary', `White text on the main colour ${c.primary} (the website writes white text on the main colour in many places)`); need(c.primary, c.surface, 4.5, 'primary', `The main colour ${c.primary} as text on the card colour ${c.surface}`); }
  if (touched('night')) need('#cbd5e1', c.night, 4.5, 'night', `Light text on the dark colour ${c.night} (the footer and dark blocks write light text on it)`);
  for (const k of ['success', 'warning', 'danger']) if (touched(k, 'surface')) need(c[k], c.surface, 4.5, k, `The ${k} colour ${c[k]} on the card colour ${c.surface}`);
  if (touched('focus', 'surface')) need(c.focus, c.surface, 3, 'focus', `The focus ring colour ${c.focus} on the card colour ${c.surface}`);

  // ----- the style sheet -----
  const env = { assets, fontFamilies: families, usedAssets: new Set(), usedFamilies: new Set(), tokenColors: Object.fromEntries(Object.keys(TOKEN_GROUPS.color).map((k) => [`--ngos-color-${kebab(k)}`, resolved.color[k]])) };
  let sheet = '';
  let stats = null;
  if (pack.css !== undefined) {
    const r = analyseStyleSheet(pack.css, env, sink);
    sheet = r.sheet; stats = r.stats;
    const issues = sink.list.length === 0 ? finalScan(sheet) : [];
    for (const issue of issues) sink.add('final-scan', 'style sheet', `The final safety scan found ${issue} in what would be written out.`, 'This should never happen. The pack is refused rather than risk it.');
  }
  for (const name of Object.keys(assets)) {
    const usedByFont = fontFileEntries.some((f) => f.file === name);
    if (!usedByFont && !env.usedAssets.has(name)) sink.add('asset-unused', `assets.${name}`, `The file "${name}" is in the pack but nothing uses it.`, 'Remove it, or use it with url("assets/' + name + '") or in "fontFiles". Unused files only make the website bigger.');
  }

  // ----- secrets -----
  const scan = (text, where) => { for (const kind of secretsIn(String(text), options.findSecrets)) sink.add('secret', where, `${where} holds something that looks like a secret (${kind}).`, 'Nothing like a key, a password or a database address may ever be in a pack: it goes to the customer and to the build service.'); };
  scan(pack.name ?? '', 'name'); if (pack.note) scan(pack.note, 'note'); if (typeof pack.css === 'string') scan(pack.css, 'css');
  for (const [g, vs] of Object.entries(pack.tokens && isObj(pack.tokens) ? pack.tokens : {})) if (isObj(vs)) for (const [k, v] of Object.entries(vs)) if (typeof v === 'string') scan(v, `tokens.${clip(g, 20)}.${clip(k, 20)}`);
  for (const name of Object.keys(isObj(pack.assets) ? pack.assets : {})) scan(name, 'an asset name');

  return done({ pack: { ...pack, tokens: pack.tokens ?? {} }, sheet, stats, resolved, set, fontFiles: fontFileEntries, assets, assetBytes, id: null });
}

// ---------------------------------------------------------------------------------------------------------------------
// 12. Writing the pack out: the style sheet the website loads, from what was checked
// ---------------------------------------------------------------------------------------------------------------------

/** A list of problems as plain text, one line each. */
export function formatProblems(problems) {
  return problems.map((p) => `- ${p.where}: ${p.what} ${p.why}`.replace(/\s+/g, ' ')).join('\n');
}

/** Thrown by compileDesignPack when the pack is not acceptable. `problems` is the list; `message` says it in plain words. */
export class DesignPackError extends Error {
  constructor(problems) {
    super(`The design pack cannot be used:\n${formatProblems(problems)}`);
    this.name = 'DesignPackError';
    this.problems = problems;
  }
}

const stackOf = (id) => (id.startsWith('custom:') ? `"${id.slice(7)}", system-ui, -apple-system, "Segoe UI", Roboto, Arial, sans-serif` : FONT_STACKS[id]);

/**
 * What the website's own style sheet sets, and which pack token changes it (only when the pack set that token). Written next to the tokens in the output.
 * Tailwind writes its shadows into each class, so the shadow tokens reach only the website's own cards (--sa-shadow-*), and the hooks, through var(--ngos-shadow-*).
 */
export const WEBSITE_VARIABLES = Object.freeze({
  color: { primary: ['--sa-accent'], night: ['--sa-night'], canvas: ['--sa-canvas'], surface: ['--sa-surface'], text: ['--sa-label'], textMuted: ['--sa-label-muted'], border: ['--sa-border'], success: ['--sa-success'], warning: ['--sa-warning'], danger: ['--sa-danger'], focus: ['--sa-focus'] },
  radius: { small: ['--radius-lg'], medium: ['--radius-xl'], large: ['--radius-2xl'] },
  space: { unit: ['--spacing'] },
  shadow: { small: ['--sa-shadow-1'], large: ['--sa-shadow-2'] },
});

/**
 * Checks the pack and writes what the website loads: { css, assets: { name: bytes }, id, name, files }.
 * The css is built from what was checked, never copied from the text that came in: tokens as variables, the pack's own fonts, the checked sheet, and a short guard that always
 * wins and keeps every control and notice visible and pressable. Throws DesignPackError (with the problems) when the pack is not acceptable.
 */
export function compileDesignPack(input, options = {}) {
  const v = validateDesignPack(input, options);
  if (!v.ok) throw new DesignPackError(v.problems);
  const { resolved, set, fontFiles, sheet, assetBytes, pack } = v;
  const blocks = [`/* Design pack "${pack.name}" for the shopper's website. Checked and written out by scripts/lib/design-pack.mjs: it is not edited by hand. */`];

  for (const f of fontFiles) blocks.push(`@font-face {\n  font-family: "${f.family}";\n  src: url("assets/${f.file}") format("${f.format}");\n  font-weight: ${f.weight};\n  font-style: ${f.style};\n  font-display: swap;\n}`);

  const root = ['/* The tokens: the pack\'s value, or the website\'s own neutral default. */'];
  for (const k of Object.keys(TOKEN_GROUPS.color)) root.push(`--ngos-color-${kebab(k)}: ${resolved.color[k]};`);
  for (const k of Object.keys(TOKEN_GROUPS.radius)) root.push(`--ngos-radius-${k}: ${resolved.radius[k]};`);
  for (const k of Object.keys(TOKEN_GROUPS.shadow)) root.push(`--ngos-shadow-${k}: ${resolved.shadow[k]};`);
  root.push(`--ngos-space-unit: ${resolved.space.unit};`);
  for (const n of SPACE_STEPS) root.push(`--ngos-space-${SPACE_STEPS.indexOf(n) + 1}: calc(var(--ngos-space-unit) * ${n});`);
  root.push('/* The website\'s own variables, set from the tokens this pack changed. */');
  const mapped = [];
  for (const [group, names] of Object.entries(WEBSITE_VARIABLES)) {
    for (const [token, targets] of Object.entries(names)) {
      if (!own(set[group], token)) continue;
      for (const target of targets) { root.push(`${target}: var(--ngos-${group === 'space' ? 'space-unit' : `${group}-${kebab(token)}`});`); mapped.push(target); }
    }
  }
  if (own(set.color, 'primary')) root.push('--sa-accent-hover: var(--ngos-color-primary);');
  if (own(set.radius, 'large')) root.push('--radius-3xl: calc(var(--ngos-radius-large) * 1.5);');
  blocks.push(`:root {\n  ${root.join('\n  ')}\n}`);
  if (own(set.color, 'primary')) blocks.push('@supports (color: color-mix(in srgb, red 50%, blue)) {\n  :root {\n    --sa-accent-hover: color-mix(in srgb, var(--ngos-color-primary) 85%, black);\n  }\n}');

  // Fonts are variables on <body>, because the website's own font variables are defined there.
  const body = ['/* Fonts. The website\'s own fonts are set on the page body, so the variables that name them are read here. */'];
  body.push(`--ngos-font-body: ${stackOf(resolved.font.body)};`);
  body.push(`--ngos-font-heading: ${stackOf(resolved.font.heading)};`);
  for (const id of Object.keys(FONT_STACKS)) body.push(`--ngos-stack-${id}: ${FONT_STACKS[id]};`);
  if (own(set.font, 'body')) body.push('--font-sans: var(--ngos-font-body);');
  if (own(set.font, 'heading')) body.push('--font-heading: var(--ngos-font-heading);');
  if (!own(set.font, 'body')) body[1] = '--ngos-font-body: var(--font-sans);';
  if (!own(set.font, 'heading')) body[2] = '--ngos-font-heading: var(--font-sans);';
  blocks.push(`body {\n  ${body.join('\n  ')}\n}`);

  if (sheet) blocks.push(`/* The pack's own rules, checked. */\n${sheet}`);

  // What always wins, because a pack's rules can never use !important: nothing in a pack can make a control or notice invisible or unpressable, or cut a part away.
  const required = Object.keys(PARTS).filter((n) => isRequiredPart(n));
  const visible = Object.keys(PARTS).filter((n) => !['extra', 'slot'].includes(PARTS[n].kind));
  blocks.push(`/* The guard: it always wins over the pack's rules. */\n${visible.map((n) => `:root [data-ngos-part="${n}"]`).join(',\n')} {\n  visibility: visible !important;\n}\n${required.map((n) => `:root [data-ngos-part="${n}"]`).join(',\n')} {\n  pointer-events: auto !important;\n  clip: auto !important;\n  clip-path: none !important;\n  mask: none !important;\n  filter: none !important;\n}`);

  const css = `${blocks.join('\n\n')}\n`;
  const issues = finalScan(css.replace(/!important/g, ''));
  if (issues.length) throw new DesignPackError([{ code: 'final-scan', where: 'the written style sheet', what: `The final safety scan found ${issues.join(', ')}.`, why: 'This should never happen. The pack is refused rather than risk it.' }]);
  const used = {};
  for (const name of Object.keys(assetBytes)) used[name] = assetBytes[name];
  return { css, assets: used, id: packId(css, used), name: pack.name, files: ['design.css', ...Object.keys(used).map((n) => `assets/${n}`)], mapped };
}

/** The tokens and parts as plain data, for a screen that shows designers what they may use. */
export function describeHooks() {
  return {
    schema: DESIGN_PACK_SCHEMA,
    kinds: PART_KINDS,
    parts: Object.fromEntries(Object.entries(PARTS).map(([name, p]) => [name, { kind: p.kind, required: REQUIRED_KINDS.includes(p.kind), where: p.where, states: p.states ?? [] }])),
    tokens: TOKEN_GROUPS,
    fonts: Object.keys(FONT_STACKS),
    variables: VARIABLES,
    properties: PROPERTY_NAMES,
    zIndexCeiling: Z_INDEX_CEILING,
    limits: LIMITS,
  };
}

/** Checks only a style sheet (for a preview screen). `assets` is { name: { type: 'image' | 'font' } }. Returns { ok, problems, sheet }. */
export function validateStyleSheet(css, { assets = {}, fontFamilies = [] } = {}) {
  const sink = new Sink();
  const env = { assets, fontFamilies: new Set(fontFamilies), usedAssets: new Set(), usedFamilies: new Set(), tokenColors: Object.fromEntries(Object.keys(TOKEN_GROUPS.color).map((k) => [`--ngos-color-${kebab(k)}`, TOKEN_GROUPS.color[k]])) };
  const r = analyseStyleSheet(css, env, sink);
  if (sink.list.length === 0) for (const issue of finalScan(r.sheet)) sink.add('final-scan', 'style sheet', `The final safety scan found ${issue}.`, 'This should never happen.');
  const problems = sink.finish();
  return { ok: problems.length === 0, problems, sheet: problems.length === 0 ? r.sheet : '' };
}
