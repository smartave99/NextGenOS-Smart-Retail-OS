#!/usr/bin/env node
/**
 * Sets the Android app up for one customer: its application id, its name and the address of its website.
 *
 *   node scripts/android-config.mjs --app-id com.shopname.app --app-name "Shop Name" --url https://shop.example.com [--version-name 1.0.0 --version-code 1]
 *
 * Nothing about a customer is built into the project; the release workflow (or the Brand Studio) calls this first.
 * The app is a shell around the customer's licensed website, so it holds no business code to copy.
 */
import { readFileSync, writeFileSync, mkdirSync, existsSync, renameSync, rmSync, readdirSync } from 'node:fs';
import { join, dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const arg = (name, fallback) => { const i = process.argv.indexOf(`--${name}`); return i > 0 && process.argv[i + 1] ? process.argv[i + 1] : fallback; };
const fail = (m) => { console.error(`android-config: ${m}`); process.exit(1); };

const appId = arg('app-id', process.env.APP_ID || 'com.nextgenos.smartretail');
const appName = arg('app-name', process.env.APP_NAME || 'Smart Retail POS');
const url = arg('url', process.env.STOREFRONT_URL || 'https://example.com').replace(/\/+$/, '');
const versionName = arg('version-name', process.env.VERSION_NAME || '1.0.0');
const versionCode = Number(arg('version-code', process.env.VERSION_CODE || '1'));

if (!/^[a-z][a-z0-9_]*(\.[a-z][a-z0-9_]*){2,}$/.test(appId)) fail('The app id must look like com.yourcompany.app (lower case, at least three parts).');
if (!/^[^<>&"'\\]{1,40}$/.test(appName)) fail('The app name must be 1 to 40 characters with no < > & " \' or backslash.');
if (!/^https:\/\/[a-z0-9]([a-z0-9.-]*[a-z0-9])?(:\d+)?$/i.test(url)) fail('The website address must start with https:// and have no path (for example https://shop.example.com).');
if (!/^\d+(\.\d+){0,2}$/.test(versionName) || !Number.isInteger(versionCode) || versionCode < 1) fail('Check the version name (1.0.0) and the version code (a whole number from 1).');

const host = new URL(url).hostname;
const cap = JSON.parse(readFileSync(join(root, 'capacitor.config.json'), 'utf8'));
Object.assign(cap, { appId, appName });
// The address of the sample app is a made-up one (example.com, example.org or example.net are reserved for examples and never hold a shop). An app built for it must not open that address and
// show a browser's "offline" or "not found" page, which looks like a broken app: it shows its own page that says it is a sample and is not connected to a shop.
const isSample = /(^|\.)example\.(com|org|net)$/i.test(host);
if (isSample) {
  delete cap.server;
  const page = join(root, 'android-shell', 'index.html');
  const html = readFileSync(page, 'utf8');
  const sample = html
    .replace('<title>Smart Retail POS</title>', `<title>${appName}</title>`)
    .replace(/<h1>[\s\S]*?<\/p>\s*<button[\s\S]*?<\/button>/, `<h1>${appName}</h1>\n    <p>This is the sample app. It is not connected to a shop, so there is nothing to show yet.</p>\n    <p>A customer's own app opens that customer's own shop.</p>`);
  if (sample === html) fail('The page of the sample app was not found in android-shell/index.html.');
  writeFileSync(page, sample);
} else cap.server = { url, cleartext: false, allowNavigation: [host, `*.${host}`] };
writeFileSync(join(root, 'capacitor.config.json'), JSON.stringify(cap, null, 2) + '\n');

const android = join(root, 'android', 'app');
const gradle = join(android, 'build.gradle');
let g = readFileSync(gradle, 'utf8');
g = g.replace(/namespace\s*=\s*"[^"]+"/, `namespace = "${appId}"`)
     .replace(/applicationId\s+"[^"]+"/, `applicationId "${appId}"`)
     .replace(/versionCode\s+\d+/, `versionCode ${versionCode}`)
     .replace(/versionName\s+"[^"]+"/, `versionName "${versionName}"`);
writeFileSync(gradle, g);

const strings = join(android, 'src', 'main', 'res', 'values', 'strings.xml');
writeFileSync(strings, `<?xml version='1.0' encoding='utf-8'?>\n<resources>\n    <string name="app_name">${appName}</string>\n    <string name="title_activity_main">${appName}</string>\n    <string name="package_name">${appId}</string>\n    <string name="custom_url_scheme">${appId}</string>\n</resources>\n`);

// The Java package follows the application id.
const javaRoot = join(android, 'src', 'main', 'java');
const target = join(javaRoot, ...appId.split('.'));
const found = [];
const walk = (d) => { for (const e of readdirSync(d, { withFileTypes: true })) { const p = join(d, e.name); if (e.isDirectory()) walk(p); else if (e.name === 'MainActivity.java') found.push(p); } };
walk(javaRoot);
if (found.length !== 1) fail('Expected exactly one MainActivity.java.');
if (found[0] !== join(target, 'MainActivity.java')) {
  mkdirSync(target, { recursive: true });
  renameSync(found[0], join(target, 'MainActivity.java'));
  // remove emptied old folders
  let d = dirname(found[0]);
  while (d !== javaRoot && existsSync(d) && readdirSync(d).length === 0) { rmSync(d, { recursive: true }); d = dirname(d); }
}
writeFileSync(join(target, 'MainActivity.java'), `package ${appId};\n\nimport com.getcapacitor.BridgeActivity;\n\npublic class MainActivity extends BridgeActivity {}\n`);

console.log(`Android app set up: ${appName} (${appId}) -> ${isSample ? 'no shop (the sample app shows its own page)' : url}, version ${versionName} (${versionCode}).`);
