#!/usr/bin/env node
/**
 * Brand Studio: make a customer's look (name, colours, logo, contact, country, website, app) once, and get every place that needs it from it.
 *
 *   node tools/brand-studio/brand.mjs serve [--open]                       the point-and-click wizard, on this PC only
 *   node tools/brand-studio/brand.mjs list
 *   node tools/brand-studio/brand.mjs new <kit> --name "Luzon Fresh" --primary "#0f6cbd" [--logo logo.png] [more options]
 *   node tools/brand-studio/brand.mjs set <kit> [options]                  change a kit
 *   node tools/brand-studio/brand.mjs check <kit>                          say what is wrong, in words
 *   node tools/brand-studio/brand.mjs export <kit>                         write brand-exports/<kit>/ (preview.html, hub-look.json, ...)
 *
 * Options: --name --short --tagline --primary --accent --logo <file> --email --phone --address --country IN --industry retail --currency INR
 *          --language en-IN --site https://shop.example.com --android-id com.shop.app --receipt-header "..." --receipt-footer "..." --no-powered-by
 * See docs/BRAND-STUDIO.md.
 */
import { readFileSync, existsSync } from 'node:fs';
import { spawn } from 'node:child_process';
import { resolve } from 'node:path';
import { listKits, loadKit, saveKit, check, blank, countryCodes, industryIds, kitFolder, repoRoot, readLogo } from './lib/kit.mjs';
import { makeExports } from './lib/exports.mjs';
import { startServer } from './lib/server.mjs';

const [command, ...rest] = process.argv.slice(2);
const positional = [];
const opts = {};
for (let i = 0; i < rest.length; i += 1) {
  const a = rest[i];
  if (a.startsWith('--')) {
    const key = a.slice(2);
    if (['no-powered-by', 'open'].includes(key)) opts[key] = true;
    else { opts[key] = rest[i + 1]; i += 1; }
  } else positional.push(a);
}
const root = process.env.BRAND_STUDIO_ROOT ? resolve(process.env.BRAND_STUDIO_ROOT) : repoRoot;
const say = (m = '') => console.log(m);
const die = (m) => { console.error(`\n${m}\n`); process.exit(1); };

function apply(kit, o) {
  const k = JSON.parse(JSON.stringify(kit));
  const set = (field, value) => { if (value !== undefined) k[field] = value; };
  set('name', o.name); set('shortName', o.short); set('tagline', o.tagline); set('primaryColor', o.primary); set('accentColor', o.accent);
  set('country', o.country); set('industry', o.industry); set('currency', o.currency); set('language', o.language); set('legalName', o.legal);
  if (o.email !== undefined || o.phone !== undefined || o.address !== undefined) k.contact = { ...(k.contact || {}), ...(o.email !== undefined && { email: o.email }), ...(o.phone !== undefined && { phone: o.phone }), ...(o.address !== undefined && { address: o.address }) };
  if (o.site !== undefined) k.storefront = { ...(k.storefront || {}), siteUrl: o.site };
  if (o['android-id'] !== undefined) k.android = { ...(k.android || {}), appId: o['android-id'], storefrontUrl: o.site ?? k.storefront?.siteUrl ?? k.android?.storefrontUrl };
  if (o['receipt-header'] !== undefined || o['receipt-footer'] !== undefined) k.receipt = { ...(k.receipt || {}), ...(o['receipt-header'] !== undefined && { header: o['receipt-header'] }), ...(o['receipt-footer'] !== undefined && { footer: o['receipt-footer'] }) };
  if (o['no-powered-by']) k.poweredBy = false;
  return k;
}
const logoFrom = (o) => {
  if (!o.logo) return null;
  if (!existsSync(o.logo)) die(`The logo file ${o.logo} was not found.`);
  return readFileSync(o.logo);
};
const show = (warnings) => { for (const w of warnings || []) say(`  note: ${w}`); };

try {
  switch (command) {
    case 'list': {
      const kits = listKits(root);
      say(kits.length ? kits.join('\n') : 'No brand kits yet. Make one with: node tools/brand-studio/brand.mjs new <kit> --name "Shop Name" --primary "#0f6cbd"');
      break;
    }
    case 'new': {
      const [slug] = positional;
      if (!slug) die('Give the kit a name, for example: new luzon-fresh --name "Luzon Fresh Mart" --primary "#0f6cbd"');
      if (existsSync(resolve(kitFolder(slug, root), 'brand.json'))) die(`The kit ${slug} already exists. Change it with: set ${slug} ...`);
      if (!opts.name || !opts.primary) die('A new kit needs --name "Shop Name" and --primary "#0f6cbd" (the main colour).');
      const r = saveKit(slug, apply(blank(opts.name, opts.primary), opts), { logoBytes: logoFrom(opts), root });
      say(`Made brand-kits/${slug}/ (${r.folder}).`);
      show(r.warnings);
      say(`Next: node tools/brand-studio/brand.mjs export ${slug}   and open brand-exports/${slug}/preview.html`);
      break;
    }
    case 'set': {
      const [slug] = positional;
      if (!slug) die('Say which kit: set luzon-fresh --primary "#aa2233"');
      const { kit } = loadKit(slug, root);
      const bytes = logoFrom(opts);
      const r = saveKit(slug, apply(kit, opts), { logoBytes: bytes, root });
      say(`Saved brand-kits/${slug}/.`);
      show(r.warnings);
      break;
    }
    case 'check': {
      const [slug] = positional;
      if (!slug) die('Say which kit: check luzon-fresh');
      const { folder, kit } = loadKit(slug, root);
      const { errors, warnings } = check(kit, { folder, countries: countryCodes(root), industries: industryIds(root) });
      for (const e of errors) say(`  problem: ${e}`);
      show(warnings);
      if (errors.length) { say(`\nThe kit ${slug} has ${errors.length} problem(s).`); process.exit(1); }
      say(`The kit ${slug} is fine.`);
      break;
    }
    case 'export': {
      const [slug] = positional;
      if (!slug) die('Say which kit: export luzon-fresh');
      const r = makeExports(slug, { root });
      say(`Made ${r.dir}:\n  ${r.files.join('\n  ')}`);
      show(r.warnings);
      say(`\nOpen ${r.dir}${process.platform === 'win32' ? '\\' : '/'}preview.html in a browser to see how it will look.`);
      break;
    }
    case 'serve': {
      const { url, server } = await startServer({ root, port: Number(opts.port || 0) });
      say('Brand Studio is open on this PC only. Open this address in your web browser:\n');
      say(`  ${url}\n`);
      say('Press Ctrl+C here to close it.');
      if (opts.open) {
        const [cmd, args] = process.platform === 'win32' ? ['cmd', ['/c', 'start', '', url]] : process.platform === 'darwin' ? ['open', [url]] : ['xdg-open', [url]];
        spawn(cmd, args, { stdio: 'ignore', detached: true }).on('error', () => {}).unref();
      }
      process.on('SIGINT', () => { server.close(); process.exit(0); });
      break;
    }
    default:
      say(readFileSync(new URL(import.meta.url), 'utf8').split('*/')[0].replace(/^#!.*\n\/\*\*\n/, '').replace(/^ \* ?/gm, ''));
      process.exit(command ? 2 : 0);
  }
} catch (e) {
  die(e.message || String(e));
}
