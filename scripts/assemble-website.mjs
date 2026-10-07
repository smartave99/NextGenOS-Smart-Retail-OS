#!/usr/bin/env node
/**
 * Puts one customer's website together: THE website (the one program every customer gets, made once per release by scripts/make-website-package.mjs) + the customer's folder
 * + the customer's licence file. Copies files and checks them; builds nothing, needs no network and no build tool (docs/PLATFORM-DECISIONS.md, decisions 23 and 24).
 *
 *   node scripts/assemble-website.mjs --program website-linux.zip --customer-folder <folder> --licence <licence.ngos> --customer luzon-fresh-mart --person "Asha Admin" --out dist [--audit]
 *
 *   --program          the generic package (website-linux.zip or website-windows.zip), or the folder it unpacks to
 *   --customer-folder  the customer's folder: brand.json, setup.json, website-settings.env, assets/ (see apps/storefront-web-mobile/src/lib/customer/rules.mjs)
 *   --settings, --kit, --logo   instead of a folder: the older way the build service and the release workflow give a customer (a website-settings.env, a brand kit's name, a PNG logo); the
 *                      folder is made from them and checked with the same rules as before
 *   --licence          the customer's licence file from the Licence Studio (licence.ngos); --no-licence makes the website without one (it is put in later)
 *   --customer         the customer's short name (2 to 41 small letters, digits and hyphens): the result is website-<customer>-<system>
 *   --person           who is making it (default: the name of the person logged in to this computer): it goes, with the time, in a hidden mark
 *   --out              where to write the folder and the zip (default: dist)
 *   --expect-sha256    the fingerprint the program zip must have (from the programs folder's base-kit.json)
 *   --audit            also run the package audit on the result (scripts/audit-package.mjs, as for a customer's website); a result that fails it is removed
 *   --no-zip           write the folder only
 *
 * The library is tools/setup-studio/lib/website-assemble.mjs, because that is where the Studio's own assembling code lives (it travels with the Studio, which holds no source code and
 * does not carry scripts/). This command is for the people who work on the repository and for the release workflow; the audit lives here, which is why it can be asked for here.
 */
import { mkdtempSync, rmSync } from 'node:fs';
import os from 'node:os';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { auditFolder } from './audit-package.mjs';
import { WebsiteError, knownPacks, repo, resolveCustomerSettings, writeCustomerFolder } from './make-website-package.mjs';
import { AssembleError, assembleWebsite } from '../tools/setup-studio/lib/website-assemble.mjs';

export async function main(argv) {
  const args = argv;
  const flag = (n) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : undefined; };
  const has = (n) => args.includes(n);
  if (!args.length || has('--help')) {
    console.log('Usage: node scripts/assemble-website.mjs --program <website-linux.zip|website-windows.zip|folder> (--customer-folder <folder> | --settings <website-settings.env> | --kit <brand kit name>) (--licence <licence.ngos> | --no-licence) --customer <short-name> [--person "Name"] [--logo <logo.png>] [--out dist] [--expect-sha256 <hash>] [--audit] [--no-zip]');
    return args.length ? 0 : 2;
  }
  try {
    const person = flag('--person') || (() => { try { return os.userInfo().username; } catch { return process.env.USERNAME || process.env.USER || ''; } })();
    let customer = flag('--customer');
    let customerFolder = flag('--customer-folder') ? resolve(flag('--customer-folder')) : null;
    let temp = null;
    if (!customerFolder && (flag('--settings') || flag('--kit'))) {
      const checked = resolveCustomerSettings({ customer: customer || null, kit: flag('--kit') || null, settingsFile: flag('--settings') ? resolve(flag('--settings')) : null, logo: flag('--logo') || null });
      customer = checked.customer;
      temp = mkdtempSync(join(os.tmpdir(), 'ngos-customer-'));
      customerFolder = writeCustomerFolder(join(temp, 'customer'), checked);
    }
    let made;
    try {
      made = await assembleWebsite({
      genericPackage: flag('--program') ? resolve(flag('--program')) : null, customerFolder,
      licenceFile: flag('--licence') ? resolve(flag('--licence')) : null, allowNoLicence: has('--no-licence'), customer, person,
      out: resolve(flag('--out') ?? `${repo}/dist`), packs: knownPacks(), expectedSha256: flag('--expect-sha256') ?? null, zip: !has('--no-zip'),
      });
    } finally {
      if (temp) rmSync(dirname(customerFolder), { recursive: true, force: true });
    }
    if (has('--audit')) {
      const audit = auditFolder(made.folder, { nodeApp: true, customerPackage: true });
      if (audit.problems.length) {
        rmSync(made.folder, { recursive: true, force: true });
        if (made.zip) rmSync(made.zip, { force: true });
        console.error(`\nThe package audit refused the website, so it was removed:\n  ${audit.problems.slice(0, 40).join('\n  ')}`);
        return 1;
      }
      console.log(`The package audit passed: ${audit.files} files checked (${audit.programs} program files); no source, project, test, database or key; no secret pattern; one licence file, in the one place the website reads it.`);
    }
    console.log(`\nWrote:\n  ${made.folder}${made.zip ? `\n  ${made.zip}\n  SHA-256 ${made.sha256}` : ''}\n\n${made.name}: ${made.files} files, version ${made.version}. Made by ${made.mark.person} at ${made.mark.madeAt}.`);
    for (const note of made.notes) console.log(`NOTE: ${note}`);
    return 0;
  } catch (e) {
    if (e instanceof AssembleError || e instanceof WebsiteError) { console.error(`\n${e.message}`); return 1; }
    throw e;
  }
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  process.exit(await main(process.argv.slice(2)));
}
