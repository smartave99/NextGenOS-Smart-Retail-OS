// What a kit is turned into, so each place that needs it has it in the form it takes. Written to brand-exports/<kit>/ (never into the programs' own folders).
import { mkdirSync, writeFileSync } from 'node:fs';
import { join } from 'node:path';
import { loadKit, readLogo, inspectLogo, check, countryCodes, industryIds, contrastWithWhite, MAX_LOGO_BYTES, repoRoot } from './kit.mjs';
import { previewHtml, logoDataUri } from './preview.mjs';

const shellQuote = (t) => `"${String(t).replace(/(["\\$`])/g, '\\$1')}"`;

/** Makes every export of a kit. Returns { dir, files, warnings }. */
export function makeExports(slug, { root = repoRoot, outRoot = join(root, 'brand-exports') } = {}) {
  const { folder, kit } = loadKit(slug, root);
  const { errors, warnings } = check(kit, { folder, countries: countryCodes(root), industries: industryIds(root) });
  if (errors.length) { const e = new Error(`The kit ${slug} has problems; fix them first:\n- ${errors.join('\n- ')}`); e.problems = errors; throw e; }
  const dir = join(outRoot, slug);
  mkdirSync(dir, { recursive: true });
  const files = [];
  const write = (name, text) => { writeFileSync(join(dir, name), text); files.push(name); };

  const bytes = readLogo(slug, root);
  const info = bytes ? inspectLogo(bytes) : { kind: null };
  const small = bytes && (info.kind === 'png' || info.kind === 'jpeg') && bytes.length <= MAX_LOGO_BYTES;
  if (bytes && !small) warnings.push(info.kind === 'svg' ? 'The Hub takes a PNG or JPEG logo; the SVG is left out of hub-look.json.' : `The logo is over 100 KB, so it is left out of hub-look.json. Make a smaller picture.`);

  // 1. For the Hub's Settings > Look page ("Load a look file"): the values the program accepts, with the logo inside.
  const look = {};
  look.name = kit.name;
  if (kit.shortName) look.shortName = kit.shortName;
  look.primaryColor = kit.primaryColor.toLowerCase();
  // The Hub refuses a second colour that white words cannot be read on (licensing/spec section 5.2), and it would refuse the whole file: so a light one is left out here.
  if (kit.accentColor) {
    if (contrastWithWhite(kit.accentColor) >= 3) look.accentColor = kit.accentColor.toLowerCase();
    else warnings.push(`The second colour ${kit.accentColor} is too light to read white words on, so it is left out of hub-look.json (the Hub does not take it). The main colour is used.`);
  }
  if (small) look.logo = logoDataUri(bytes, info.kind);
  if (kit.contact?.email) look.supportEmail = kit.contact.email;
  if (kit.contact?.phone) look.supportPhone = kit.contact.phone;
  if (typeof kit.poweredBy === 'boolean') look.poweredBy = kit.poweredBy;
  write('hub-look.json', JSON.stringify(look, null, 2) + '\n');

  // 2. For the Licence Studio: the brand a licence carries (the licence decides how much of a kit the customer may change on their own).
  const c = kit.contact || {};
  write('licence-brand.txt', [
    `The brand for the licence of ${kit.name}`,
    '',
    'In the Licence Studio, either open "Brands" and add one with these values, or run this one command in the Studio folder:',
    '',
    `  node src/cli.js create-brand --name ${shellQuote(kit.name)}${kit.shortName ? ` --short ${shellQuote(kit.shortName)}` : ''} --primary ${kit.primaryColor}${kit.accentColor ? ` --accent ${kit.accentColor}` : ''}${c.email ? ` --email ${shellQuote(c.email)}` : ''}${c.phone ? ` --phone ${shellQuote(c.phone)}` : ''}${kit.poweredBy === false ? ' --powered no' : ''}`,
    '',
    'Then choose that brand when you make the customer\'s licence. How much of this look the customer may change on their own PC is the licence\'s "white label" level:',
    '  none  nothing (they see the look you set);   theme  colours, logo, help details;   full  also the program\'s name and the "by NextGenOS" line.',
    '',
    kit.logo ? `The logo for the brand form is the file brand-kits/${slug}/${kit.logo} (a picture of at most 100 KB).` : 'There is no logo in this kit yet.',
    '',
  ].join('\n'));

  // 3. For the website.
  const place = c.address ? c.address.split(',').slice(-2).join(',').trim() : '';
  write('website.env', [
    `# Settings for ${kit.name}'s website (apps/storefront-web-mobile). Put these in the website's environment.`,
    `NEXT_PUBLIC_SITE_NAME=${kit.name}`,
    kit.storefront?.siteUrl ? `NEXT_PUBLIC_SITE_URL=${kit.storefront.siteUrl}` : '# NEXT_PUBLIC_SITE_URL=https://   (not in the kit yet)',
    kit.country ? `NEXT_PUBLIC_COUNTRY=${kit.country}` : '# NEXT_PUBLIC_COUNTRY=   (not in the kit yet)',
    kit.industry ? `NEXT_PUBLIC_INDUSTRY=${kit.industry}` : '# NEXT_PUBLIC_INDUSTRY=retail   (not in the kit yet)',
    place ? `NEXT_PUBLIC_SHOP_PLACE=${place}` : '# NEXT_PUBLIC_SHOP_PLACE=',
    '',
    '# The website\'s icons and logo are made from the kit\'s logo:',
    `#   cd apps/storefront-web-mobile && node scripts/make-icons.mjs --logo ../../brand-kits/${slug}/${kit.logo || 'logo.png'} --colour "${kit.primaryColor}"`,
    '',
  ].join('\n'));

  // 4. For the Android app.
  write('ANDROID.txt', [
    `The Android app for ${kit.name}`,
    '',
    kit.android ? `Application id: ${kit.android.appId}\nIt opens: ${kit.android.storefrontUrl}` : 'This kit has no "android" part yet. Add the app id (like com.yourshop.app) and the website the app opens.',
    '',
    'The easy way (no Android tools on your PC): commit the folder brand-kits/' + slug + ' and, on GitHub, run the "Release" workflow by hand with Brand kit = ' + slug + '.',
    'It builds a signed .apk and .aab and attaches them to a release.',
    '',
    'On a PC with the Android tools:',
    '  cd apps/storefront-web-mobile',
    kit.android ? `  node scripts/android-config.mjs --app-id ${kit.android.appId} --app-name ${shellQuote(kit.name)} --url ${kit.android.storefrontUrl} --version-name 1.0.0 --version-code 1` : '  node scripts/android-config.mjs --app-id com.yourshop.app --app-name "Shop Name" --url https://shop.example.com',
    `  node scripts/make-icons.mjs --logo ../../brand-kits/${slug}/${kit.logo || 'logo.png'} --colour "${kit.primaryColor}" --android`,
    '  npx cap sync android',
    '  cd android && ./gradlew assembleRelease',
    '',
  ].join('\n'));

  // 5. A picture of the result.
  write('preview.html', previewHtml(kit, small || info.kind === 'svg' ? logoDataUri(bytes, info.kind) : null));

  write('README.txt', [
    `What is in this folder (made from brand-kits/${slug}/brand.json). Open preview.html in a browser to see the result.`,
    '',
    'preview.html       How the programs will look: side menu, a sale, a bill, the sign-in card, the app icon, light and dark.',
    'hub-look.json      For the Business Hub: Settings > Look > "Load a look file". The Hub shows as much of it as the licence allows.',
    'licence-brand.txt  For the Licence Studio: the brand to put on the customer\'s licence.',
    'website.env        For the website: its name, address and country, and how to make its icons.',
    'ANDROID.txt        How to make the Android app.',
    '',
    'Nothing here has a password or a key in it, and nothing here changes the programs: they only change when you use these files.',
    '',
  ].join('\n'));

  return { dir, files, warnings };
}
