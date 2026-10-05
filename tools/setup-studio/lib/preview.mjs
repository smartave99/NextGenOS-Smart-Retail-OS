// A picture of the customer's program as set: the Business Hub's own style sheets with a small sample screen, in the chosen look and layout, for the Studio to show while staff
// choose. It is what the Hub will show (same files, same rules); only the content is a sample. Everything written into it is escaped, and nothing is loaded from outside.
import { readFileSync, existsSync } from 'node:fs';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { repoRoot, countryPack, industryPack } from './packs.mjs';
import { resolveTheme, usableColour } from './rules.mjs';
import { themeFor, STYLES, deviceTokens } from './template.mjs';

const here = dirname(fileURLToPath(import.meta.url));

/** Where the Hub's style files are: the repository, or the Studio's own copy in a delivered bundle (assets/). */
export function assetFile(name) {
  const bundled = resolve(here, '..', 'assets', name);
  if (existsSync(bundled)) return bundled;
  const inRepo = { 'hub.css': join(repoRoot, 'apps', 'business-hub', 'src', 'NextGenOS.Hub.Web', 'wwwroot', 'hub.css'), 'tokens.css': join(repoRoot, 'design', 'tokens.css') }[name];
  return inRepo && existsSync(inRepo) ? inRepo : null;
}
export const readAsset = (name) => { const f = assetFile(name); return f ? readFileSync(f) : null; };

const esc = (v) => String(v ?? '').replace(/[&<>"']/g, (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' }[c]));
const scaleAttr = (n) => (n ?? 1).toFixed(2);

/** What the preview needs, taken from details (the same fields the form has). Anything else is ignored. */
export function previewInput(d) {
  const o = d && typeof d === 'object' ? d : {};
  const pick = (v, list, fallback) => (list.includes(v) ? v : fallback);
  return {
    name: String(o.name ?? 'Your business').slice(0, 60),
    country: /^[A-Z]{2}$/.test(o.country) ? o.country : 'IN',
    industry: /^[a-z]{3,20}$/.test(o.industry ?? '') ? o.industry : 'retail',
    primary: usableColour(o.primary) ?? null,
    accent: usableColour(o.accent) ?? null,
    style: pick(o.style, Object.keys(STYLES), 'modern'),
    appearance: pick(o.appearance, ['auto', 'light', 'dark'], 'auto'),
    kind: pick(o.kind, ['laptop', 'touch-pos', 'tablet', 'kiosk'], 'laptop'),
    screen: pick(o.screen, ['small', 'standard', 'large'], 'standard'),
    level: pick(o.level, ['none', 'theme', 'full'], 'none'),
    screenName: pick(o.screenName, ['sell', 'today'], 'sell'),
    logo: typeof o.logo === 'string' && /^[a-z0-9-]{2,41}$/.test(o.logo) ? o.logo : null,
    poweredBy: o.poweredBy !== false,
  };
}

/** The look the Hub would show for these details and licence level (the same resolve the Hub does). */
export function previewTheme(p) {
  const wanted = { ...STYLES[p.style], mode: p.appearance, ...deviceTokens({ kind: p.kind, screen: p.screen }) };
  return resolveTheme(p.level, wanted, null);
}

/** The brand colour as the Hub writes it into the page (BrandService), or nothing when the licence's own look applies. */
export function brandCss(colour, highlight = null) {
  if (!colour) return '';
  const mix = (hex, part) => { const ch = (a) => Math.round(parseInt(hex.slice(a, a + 2), 16) * (1 - part) + 255 * part).toString(16).padStart(2, '0'); return `#${ch(1)}${ch(3)}${ch(5)}`; };
  const lum = (hex) => { const c = (a) => { const v = parseInt(hex.slice(a, a + 2), 16) / 255; return v <= 0.04045 ? v / 12.92 : ((v + 0.055) / 1.055) ** 2.4; }; return 0.2126 * c(1) + 0.7152 * c(3) + 0.0722 * c(5); };
  const ratio = (a, b) => (Math.max(lum(a), lum(b)) + 0.05) / (Math.min(lum(a), lum(b)) + 0.05);
  const on = (hex) => (ratio(hex, '#ffffff') >= ratio(hex, '#00111f') ? '#ffffff' : '#00111f');
  const dark = mix(colour, 0.18);
  const light = `--ngos-accent:${colour};--ngos-accent-strong:color-mix(in srgb,${colour} 85%,black);--ngos-accent-contrast:${on(colour)};--ngos-accent-soft:color-mix(in srgb,${colour} 12%,transparent)${highlight ? `;--ngos-highlight:${highlight}` : ''}`;
  const night = `--ngos-accent:${dark};--ngos-accent-strong:color-mix(in srgb,${colour} 65%,white);--ngos-accent-contrast:${on(dark)};--ngos-accent-soft:color-mix(in srgb,${colour} 22%,transparent)`;
  return `:root{${light}}\n@media (prefers-color-scheme:dark){:root:not([data-theme="light"]){${night}}}\n:root[data-theme="dark"]{${night}}`;
}

const ICONS = {
  home: '<path d="M4 11.5 12 5l8 6.5"/><path d="M6 10.5V19h12v-8.5"/><path d="M10 19v-5h4v5"/>',
  cart: '<circle cx="9" cy="19" r="1.4"/><circle cx="17" cy="19" r="1.4"/><path d="M3.5 5h2.4l1.6 9.5h10l1.6-7H7"/>',
  box: '<path d="m12 3.5 8 4.2v8.6L12 20.5l-8-4.2V7.7Z"/><path d="m4 7.7 8 4.3 8-4.3M12 12v8.5"/>',
  people: '<circle cx="9" cy="8.5" r="3"/><path d="M3.5 19c.4-3 2.6-4.8 5.5-4.8s5.1 1.8 5.5 4.8"/><path d="M16 5.8a3 3 0 0 1 0 5.6M17.5 14.4c1.7.5 2.8 2 3 4.1"/>',
  chart: '<path d="M4 19.5h16"/><path d="M7 16v-4.5M12 16V7.5M17 16v-7"/>',
  gear: '<circle cx="12" cy="12" r="3"/><path d="M12 3.5v2.2M12 18.3v2.2M3.5 12h2.2M18.3 12h2.2M6 6l1.6 1.6M16.4 16.4 18 18M18 6l-1.6 1.6M7.6 16.4 6 18"/>',
};
const icon = (n) => `<svg class="icon" viewBox="0 0 24 24" width="20" height="20" fill="none" stroke="currentColor" stroke-width="1.8" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true">${ICONS[n]}</svg>`;

/** The sample page. `css` is the address of the brand style sheet; `logoSrc` the address of the logo (or null). */
export function previewHtml(p, { cssHref, logoSrc }) {
  const t = previewTheme(p);
  const country = countryPack(p.country);
  const industry = industryPack(p.industry) ?? industryPack('retail');
  const v = industry?.vocabulary ?? {};
  const word = (k, i, d) => (v[k]?.[i] ?? d);
  const dec = country?.currency?.decimals ?? 2;
  const sym = country?.currency?.symbol ?? '';
  const money = (s) => `${sym}${Number(s).toFixed(dec)}`;
  const items = (industry?.demo?.items ?? []).slice(0, 8);
  const sample = items.length ? items : [{ name: 'Sample item', price: '10' }, { name: 'Another item', price: '25' }];
  const first = sample.slice(0, 2);
  const total = first.reduce((s, i) => s + Number(i.price), 0);
  const nav = [['home', 'Today'], ['cart', word('sale', 0, 'Sale') === 'Order' ? 'Take an order' : `New ${word('sale', 0, 'sale').toLowerCase()}`], ['box', word('item', 1, 'Items')], ['people', 'People'], ['chart', 'Reports'], ['gear', 'Settings']];
  const active = p.screenName === 'today' ? 0 : 1;
  const by = p.level === 'full' ? p.poweredBy : true;
  const brand = `${logoSrc ? `<img class="brand-logo" src="${esc(logoSrc)}" alt="">` : ''}<span class="brand-name">${esc(p.name)}</span>${by ? '<span class="brand-by">by NextGenOS</span>' : ''}`;
  const body = p.screenName === 'today'
    ? `<h1>Today</h1><p class="sub">${esc(p.name)}</p><div class="grid">
        <div class="card stat"><span class="label">${esc(word('sale', 1, 'Sales'))} today</span><span class="value">24</span><span class="note">${money(total * 9)} in total</span></div>
        <div class="card stat"><span class="label">Average</span><span class="value">${money(total / 2)}</span><span class="note">for each ${esc(word('sale', 0, 'sale').toLowerCase())}</span></div>
        <div class="card stat"><span class="label">Low on ${esc(word('stock', 0, 'stock').toLowerCase())}</span><span class="value">3</span><span class="note">to reorder soon</span></div></div>`
    : `<h1>${esc(word('sale', 0, 'Sale') === 'Order' ? 'Take an order' : `New ${word('sale', 0, 'sale').toLowerCase()}`)}</h1><p class="sub">Scan a barcode, or type a name and press Enter.</p>
       <div class="pos"><div><div class="card"><input class="big-input-left" placeholder="Scan or search" aria-label="Scan or search" tabindex="-1">
         <div class="items">${sample.map((i) => `<button type="button" class="item-btn" tabindex="-1"><span class="nm">${esc(i.name)}</span><span class="pr">${money(i.price)}</span></button>`).join('')}</div></div></div>
       <div class="card cart"><h2>${esc(word('sale', 0, 'Sale'))}</h2>
         ${first.map((i) => `<div class="line"><span class="nm">${esc(i.name)}</span><span class="amt">${money(i.price)}</span></div>`).join('')}
         <div class="total-row big"><span>Total</span><span>${money(total)}</span></div>
         <h3>Payment</h3><div class="pay-methods">${(industry?.defaults?.paymentMethods ?? ['cash', 'card']).slice(0, 3).map((m, i) => `<button type="button" class="chips-btn ${i === 0 ? 'on' : ''}" tabindex="-1">${esc(m[0].toUpperCase() + m.slice(1))}</button>`).join('')}</div>
         <div class="row"><button type="button" class="btn primary grow" tabindex="-1">Complete ${esc(word('sale', 0, 'sale').toLowerCase())}</button><button type="button" class="btn ghost" tabindex="-1">Cancel</button></div></div></div>`;
  return `<!doctype html>
<html lang="en" data-mode="${esc(t.mode)}" data-surface="${esc(t.surface)}" data-shape="${esc(t.shape)}" data-density="${esc(t.density)}" data-font="${esc(t.font)}" data-scale="${scaleAttr(t.fontScale)}" data-nav="${esc(t.nav)}" data-nav-labels="${esc(t.navLabels)}" data-cart="${esc(t.cart)}" data-depth="${esc(t.depth)}">
<head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1"><meta name="color-scheme" content="light dark"><title>Preview</title>
<link rel="stylesheet" href="/assets/tokens.css"><link rel="stylesheet" href="/assets/hub.css"><link rel="stylesheet" href="${esc(cssHref)}"></head>
<body><div class="shell"><nav class="side" aria-label="Main"><div class="brand">${brand}</div>
<ul>${nav.map(([ic, label], i) => `<li><a href="#" tabindex="-1" class="${i === active ? 'active' : ''}" title="${esc(label)}">${icon(ic)}<span>${esc(label)}</span></a></li>`).join('')}</ul></nav>
<div class="main"><header class="top"><span class="top-brand">${esc(p.name)}${by ? '<small>by NextGenOS</small>' : ''}</span><span class="shop-name">${esc(p.name)}</span><span class="spacer"></span><span class="who">Your name</span></header>
<main id="content">${body}</main></div></div></body></html>`;
}
