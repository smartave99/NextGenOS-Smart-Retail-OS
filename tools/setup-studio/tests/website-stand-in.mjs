// A stand-in for THE website program and for a programs folder (a kit) that holds it, for the Studio's own tests. The real website is built by scripts/make-website-package.mjs on
// a build machine; here only what the assemble step looks at is made: its description (PACKAGE-INFO.json), its rules file (the real one, copied), a start file. No source, no key.
import { chmodSync, copyFileSync, mkdirSync, readFileSync, readdirSync, writeFileSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';
import { makeZip } from '../lib/zip.mjs';
import { makeBaseKit } from '../../../scripts/make-base-kit.mjs';

const here = dirname(fileURLToPath(import.meta.url));
export const repo = join(here, '..', '..', '..');
export const RULES = join(repo, 'apps', 'storefront-web-mobile', 'src', 'lib', 'customer', 'rules.mjs');

const put = (root, files) => { for (const [name, content] of Object.entries(files)) { const full = join(root, ...name.split('/')); mkdirSync(dirname(full), { recursive: true }); writeFileSync(full, content); } return root; };

/** The folder of THE website for one system. */
export function genericFolder(root, { os = 'linux', info = {}, extra = {} } = {}) {
  const dir = join(root, `website-${os}`);
  put(dir, {
    'PACKAGE-INFO.json': JSON.stringify({ schema: 1, product: 'Smart Retail POS website', generic: true, version: '1.2.3', os, arch: 'x64', builtAt: '2026-01-01T00:00:00.000Z', node: 'v22.22.0', licenceKeysBuiltIn: 1, trialWithoutLicenceKeys: false, customerFolder: 'customer', ...info }, null, 2),
    'READ ME FIRST.txt': 'Smart Retail POS: the website\r\n===\r\nThe steps are the same for every shop.\r\n',
    'start-website.js': '// starts the website\n',
    'start-website.sh': '#!/bin/sh\necho start\n',
    'app/server.js': '// the server\n',
    'app/.next/BUILD_ID': 'abc',
    'app/.next/server/app/page.js': 'module.exports = {};',
    'licence/READ ME.txt': 'Put the licence file here.',
    'node/LICENSE': 'Node.js licence',
    ...extra,
  });
  copyFileSync(RULES, join(dir, 'customer-rules.mjs'));
  if (process.platform !== 'win32') chmodSync(join(dir, 'start-website.sh'), 0o755);
  return dir;
}

/** The zip of that folder, named like the release file (website-linux.zip), in `into`. */
export function genericZip(folder, into) {
  const entries = [];
  const top = folder.split(/[\\/]/).pop();
  const walk = (d, prefix) => { for (const e of readdirSync(d, { withFileTypes: true })) { if (e.isDirectory()) walk(join(d, e.name), `${prefix}/${e.name}`); else entries.push({ name: `${prefix}/${e.name}`, data: readFileSync(join(d, e.name)), mode: e.name.endsWith('.sh') ? 0o755 : 0o644 }); } };
  walk(folder, top);
  mkdirSync(into, { recursive: true });
  const zip = join(into, `${top}.zip`);
  writeFileSync(zip, makeZip(entries));
  return zip;
}

/**
 * A programs folder (the kit) with a Hub setup, a Linux package and the website program for the systems asked, plus base-kit.json. `trial` marks it as made without licence keys.
 * `work` is a scratch folder (the unpacked stand-ins are made there).
 */
export async function makeKit(root, { name = 'kit', websites = ['linux', 'windows'], trial = false, work = join(root, 'stand-in-work') } = {}) {
  const dir = join(root, name);
  mkdirSync(dir, { recursive: true });
  writeFileSync(join(dir, 'SmartRetailPOS-Hub-Setup-1.4.0.exe'), Buffer.alloc(4000, 7));
  writeFileSync(join(dir, 'smart-retail-pos-hub_1.4.0-1_amd64.deb'), Buffer.alloc(3000, 9));
  for (const os of websites) genericZip(genericFolder(join(work, name), { os, info: trial ? { trialWithoutLicenceKeys: true } : {} }), dir);
  if (trial) writeFileSync(join(dir, 'NO-LICENCE-KEYS-TRIAL-ONLY.txt'), 'trial');
  const { manifest } = await makeBaseKit(dir);
  writeFileSync(join(dir, 'base-kit.json'), JSON.stringify(manifest));
  return dir;
}

/** A licence-shaped file (the signature is not checked by the Studio: the website does that when it runs). */
export const licenceText = (claims = {}) => `NGOS1.${Buffer.from(JSON.stringify({ v: 1, iss: 'nextgenos', typ: 'lic', kid: 'k1', lid: 'L-1', exp: null, trial: false, bind: { mode: 'domain', domains: ['luzonfresh.example'] }, ...claims })).toString('base64url')}.${'A'.repeat(86)}`;
