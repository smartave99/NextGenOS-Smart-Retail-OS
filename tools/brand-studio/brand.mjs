#!/usr/bin/env node
/**
 * Brand Studio: make a customer's look (name, colours, logo, contact, country, website, app) once, and get every place that needs it from it.
 *
 *   node tools/brand-studio/brand.mjs serve --app                          the point-and-click wizard as a program of its own: a window with no address bar, no terminal;
 *                                                                          one copy at a time; closing the window stops it
 *   node tools/brand-studio/brand.mjs serve [--open]                       the same, in this terminal (and a tab in your usual browser with --open)
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
import { mkdirSync, writeFileSync } from 'node:fs';
import { homedir } from 'node:os';
import { join, resolve } from 'node:path';
import { listKits, loadKit, saveKit, check, blank, countryCodes, industryIds, kitFolder, repoRoot, readLogo } from './lib/kit.mjs';
import { makeExports } from './lib/exports.mjs';
import { startServer } from './lib/server.mjs';
import { clearRunning, findRunning, HANDED_OFF_IDLE_MS, idleWatch, openAppWindow, whatNextAfterWindow, writeRunning } from './lib/app-window.mjs';

const [command, ...rest] = process.argv.slice(2);
const positional = [];
const opts = {};
for (let i = 0; i < rest.length; i += 1) {
  const a = rest[i];
  if (a.startsWith('--')) {
    const key = a.slice(2);
    if (['no-powered-by', 'open', 'app', 'nowindow'].includes(key)) opts[key] = true;
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

/** Where the Brand Studio keeps its note that it is running, its window's profile and any problem note. */
function configDir() {
  if (process.env.BRAND_STUDIO_HOME) return resolve(process.env.BRAND_STUDIO_HOME);
  return process.platform === 'win32'
    ? join(process.env.APPDATA || join(homedir(), 'AppData', 'Roaming'), 'NextGenOS Brand Studio')
    : join(process.env.XDG_CONFIG_HOME || join(homedir(), '.config'), 'nextgenos-brand-studio');
}
function openWithSystem(target) {
  const [cmd, args] = process.platform === 'win32' ? ['cmd', ['/c', 'start', '""', target]] : process.platform === 'darwin' ? ['open', [target]] : ['xdg-open', [target]];
  try { spawn(cmd, args, { detached: true, stdio: 'ignore', windowsHide: true }).on('error', () => {}).unref(); } catch { /* the address is printed anyway */ }
}
/** In a window with no terminal a problem would be invisible: it is written in a note and the note is opened. */
function showProblem(message) {
  try {
    mkdirSync(configDir(), { recursive: true });
    const file = join(configDir(), 'Brand Studio problem.txt');
    writeFileSync(file, `The NextGenOS Brand Studio could not start.\r\n\r\n${message}\r\n\r\nIf it keeps happening, send this note to NextGenOS support (smartave99@gmail.com, +91 6123115368).\r\n`);
    openWithSystem(file);
  } catch { /* nothing more can be done */ }
}
/** The Brand Studio shows itself in a window of its own. When none can be opened the usual web browser is NOT used (the owner's rule: our programs open like programs); a note says what to do. */
function explainNoWindow() {
  showProblem('The Brand Studio opens in a window of its own, and that needs Microsoft Edge, Google Chrome or Chromium on this PC. None could be opened.\r\n\r\nMicrosoft Edge is free and comes with Windows 10 and 11 (run Windows Update), or it can be installed from microsoft.com/edge. Then open the Brand Studio again.');
}
const answers = async (url) => {
  const u = new URL(url);
  const res = await fetch(`${u.origin}/api/options`, { headers: { 'x-brand-studio': u.searchParams.get('k') ?? '' }, signal: AbortSignal.timeout(3000) });
  const body = res.ok ? await res.json() : null;
  return !!body && Array.isArray(body.kits);
};

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
      // A second double-click must not start a second Brand Studio: it brings up the one that is running, in a new window.
      if (opts.app) {
        const running = await findRunning(configDir(), { answers });
        if (running) {
          if (!opts.nowindow && !openAppWindow(running.url, { profileDir: join(configDir(), 'window') })) explainNoWindow();
          process.exit(0);
        }
      }
      let watch = null;
      let appWindow = null;
      let stopping = false;
      let studio = null;
      const stop = async () => {
        if (stopping) return;
        stopping = true;
        clearRunning(configDir());
        watch?.stop();
        try { appWindow?.child.kill(); } catch { /* it is already closed */ }
        await studio.close();
        process.exit(0);
      };
      let lastBeat = 0;   // when a page last said it is there
      studio = await startServer({ root, port: Number(opts.port || 0), onBeat: () => { lastBeat = Date.now(); watch?.beat(); }, onQuit: stop });
      const { url } = studio;
      if (opts.app) writeRunning({ url, folder: root }, configDir());
      say('Brand Studio is open on this PC only. Open this address in your web browser:\n');
      say(`  ${url}\n`);
      // With no window to watch (a tab in the usual browser, or a terminal run), it stops by itself after a long time with no page open.
      const watchForTheTab = (idleMs) => { watch ??= idleWatch({ idleMs, onIdle: stop }); };
      if (opts.app) {
        say('Close its window to stop it.');
        if (opts.nowindow) watchForTheTab();
        else {
          appWindow = openAppWindow(url, { profileDir: join(configDir(), 'window') });
          if (!appWindow) { explainNoWindow(); await stop(); }
          else {
            const { started } = appWindow;
            appWindow.closed.then(async (ended) => {
              const next = await whatNextAfterWindow(ended, { pageSeen: () => lastBeat >= started, waitMs: Number(process.env.NEXTGENOS_WINDOW_WAIT_MS) || undefined });
              if (next === 'stop') return stop();
              appWindow = null;
              if (next === 'handed-off') { watchForTheTab(HANDED_OFF_IDLE_MS); return undefined; }   // the window is open in a browser we cannot watch: do not open it a second time
              // The browser could not start, or the page never appeared: there is no window to show. The usual web browser is not used; a note says what to do, and the Brand Studio stops.
              explainNoWindow();
              await stop();
              return undefined;
            });
          }
        }
      } else {
        say('Press Ctrl+C here to close it.');
        if (opts.open) openWithSystem(url);
      }
      process.on('SIGINT', stop); process.on('SIGTERM', stop);
      break;
    }
    default:
      say(readFileSync(new URL(import.meta.url), 'utf8').split('*/')[0].replace(/^#!.*\n\/\*\*\n/, '').replace(/^ \* ?/gm, ''));
      process.exit(command ? 2 : 0);
  }
} catch (e) {
  if (opts.app) showProblem(e.message || String(e));
  die(e.message || String(e));
}
