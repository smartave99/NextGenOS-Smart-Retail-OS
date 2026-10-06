// The customer pack: everything one customer receives, in one folder and one zip, made from an approved release and the programs folder (the files of a NextGenOS release).
// Nothing is built here. The programs are copied exactly as released (their fingerprints were checked), and what belongs to this one customer is added beside them as plain data:
// the profile (the setup the Hub reads at its first run), a small package that carries it on Linux, a page of steps for each part, and the hand-over sheet.
import { createHash } from 'node:crypto';
import { chmodSync, copyFileSync, createReadStream, mkdirSync, readdirSync, rmSync, statSync, writeFileSync } from 'node:fs';
import { basename, join, relative, sep } from 'node:path';
import { makeDeb } from './deb.mjs';
import { writeZipFile } from './zip.mjs';
import { pick } from './basekit.mjs';
import { handoverFor, handoverHtml } from './handover.mjs';
import { countryPack } from './packs.mjs';
import { buildAiProfile } from './aiprofile.mjs';

/** Something a person must put right before a pack can be made. */
export class PackError extends Error {}

export const PROFILE_FILES = ['setup.json', 'theme.json', 'brand.json'];
const KIOSK_KINDS = ['touch-pos', 'kiosk'];
const CRLF = (lines) => lines.join('\r\n') + '\r\n';

/** A name that is safe as a folder or file name on Windows, Linux and macOS, and still reads as the business's own name. */
export function fileSafe(name, fallback = 'Customer') {
  const t = String(name ?? '').normalize('NFC').replace(/[<>:"/\\|?*\u0000-\u001f]/g, ' ').replace(/\s+/g, ' ').replace(/^[. ]+|[. ]+$/g, '').slice(0, 50).trim();
  return /^(con|prn|aux|nul|com\d|lpt\d)$/i.test(t) ? fallback : (t || fallback);
}

async function sha256Of(path) {
  const h = createHash('sha256');
  for await (const chunk of createReadStream(path)) h.update(chunk);
  return h.digest('hex');
}

/** The small data files that go beside a program: what install.ini says for Windows, and the note about where this came from. */
export function profileExtras({ intake, info }) {
  const kiosk = KIOSK_KINDS.includes(intake.device.kind);
  return {
    kiosk,
    installIni: CRLF(['[install]', `kind=${intake.device.kind}`, `kiosk=${kiosk ? 'yes' : 'no'}`, `screen=${intake.device.screen}`, `printer=${intake.device.printer}`, `scanner=${intake.device.scanner ? 'yes' : 'no'}`, `drawer=${intake.device.drawer ? 'yes' : 'no'}`, `release=${info.n}`]),
    releaseNote: CRLF([`Prepared for: ${intake.business.name}`, `Setup release: ${info.n}`, `Fingerprint: ${info.bundleHash}`, 'Made by the NextGenOS Setup Studio.']),
  };
}

const PROFILE_POSTINST = `#!/bin/sh
# The Hub reads its profile when it starts: start it again so the prepared set-up is used.
set -e
if [ "$1" = "configure" ] && [ -d /run/systemd/system ]; then systemctl try-restart nextgenos-hub.service > /dev/null 2>&1 || true; fi
exit 0
`;
const PROFILE_POSTRM = `#!/bin/sh
set -e
if [ "$1" = "remove" ] || [ "$1" = "purge" ]; then
  if [ -d /run/systemd/system ]; then systemctl try-restart nextgenos-hub.service > /dev/null 2>&1 || true; fi
fi
exit 0
`;

/** The Linux package that carries one customer's profile (and, for a till or kiosk, opens the program full screen at sign-in). Installed with the Hub's package, in any order. */
export function profileDeb({ customerId, intake, info, files, company = {}, when }) {
  const extras = profileExtras({ intake, info });
  const dir = 'opt/nextgenos/smart-retail-hub/profile';
  const list = [...PROFILE_FILES.map((n) => ({ name: `${dir}/${n}`, data: files[n] })), { name: `${dir}/release.txt`, data: extras.releaseNote.replace(/\r\n/g, '\n') }];
  if (extras.kiosk) list.push({ name: 'etc/xdg/autostart/smart-retail-pos-fullscreen.desktop', data: '[Desktop Entry]\nType=Application\nName=Smart Retail POS (full screen)\nExec=/usr/bin/smart-retail-pos --fullscreen\nX-GNOME-Autostart-enabled=true\nTerminal=false\n' });
  const maintainer = company.name ? (company.supportEmail ? `${company.name} <${company.supportEmail}>` : company.name) : 'NextGenOS';
  const data = makeDeb({
    control: {
      Package: `smart-retail-profile-${customerId}`, Version: `1.0.${info.n}`, Architecture: 'all', Maintainer: maintainer,
      Conflicts: 'smart-retail-profile', Provides: 'smart-retail-profile', Replaces: 'smart-retail-profile',
      Description: `The set-up prepared for ${intake.business.name}\nOnly data: the look, the words and the settings of one business. It holds no program.\nInstall it with the Smart Retail POS Hub package, in any order.`,
    },
    files: list, scripts: { postinst: PROFILE_POSTINST, postrm: PROFILE_POSTRM }, when,
  });
  return { name: `smart-retail-profile-${customerId}_1.0.${info.n}_all.deb`, data };
}

export function installScript({ business }) {
  return `#!/bin/sh
# Installs Smart Retail POS and the set-up prepared for ${business.replace(/[^\p{L}\p{N} .,&'-]/gu, '')}.
# Run it with:   sudo ./install.sh
set -e
cd "$(dirname "$0")"
if [ "$(id -u)" -ne 0 ]; then echo "Please run it like this:  sudo ./install.sh"; exit 1; fi
if ! command -v apt-get > /dev/null 2>&1; then echo "This needs Ubuntu, Linux Mint or Debian."; exit 1; fi
case "$(dpkg --print-architecture 2> /dev/null)" in
  amd64) kind=amd64 ;;
  arm64) kind=arm64 ;;
  *) echo "This computer is not a 64-bit Intel/AMD or ARM computer, which the program needs."; exit 1 ;;
esac
hub="$(ls smart-retail-pos-hub_*_"$kind".deb 2> /dev/null | head -n 1)"
if [ -z "$hub" ]; then echo "The program for this kind of computer ($kind) is not in this folder."; exit 1; fi
profile="$(ls smart-retail-profile-*_all.deb 2> /dev/null | head -n 1)"
if [ -z "$profile" ]; then echo "The prepared set-up file (smart-retail-profile-...) is not in this folder."; exit 1; fi
echo "Installing. Anything the program needs that this computer lacks is fetched for you, so be online for this step."
apt-get install -y "./$hub" "./$profile"
echo
echo "Done. Open Smart Retail POS from the menu, or go to http://127.0.0.1:5280 in a web browser."
`;
}

const readme = (title, lines, help) => CRLF([title, '='.repeat(title.length), '', ...lines, '', ...(help ? ['Need help?  ' + help] : [])]);

/** The brand kit of the customer, in the form the Brand Studio and the release workflow read (brand-kits/<name>/brand.json). */
export function brandKitFor({ intake, logo }) {
  const b = intake.business;
  const country = countryPack(b.country);
  const siteUrl = intake.ecosystem.website.domain ? `https://${intake.ecosystem.website.domain}` : null;
  const kit = {
    schema: 1, name: b.name, ...(b.legalName ? { legalName: b.legalName } : {}), ...(b.tagline ? { tagline: b.tagline } : {}),
    primaryColor: intake.look.primaryColor, ...(intake.look.accentColor ? { accentColor: intake.look.accentColor } : {}), theme: intake.look.appearance,
    ...(logo ? { logo: `logo.${logo.ext}` } : {}),
    contact: { email: b.contact.email, phone: b.contact.phone, address: b.contact.address },
    country: b.country, industry: b.industry, ...(country?.currency?.code ? { currency: country.currency.code } : {}),
    ...(siteUrl ? { storefront: { siteUrl } } : {}),
    ...(intake.ecosystem.android.wanted && siteUrl ? { android: { appId: intake.ecosystem.android.appId, storefrontUrl: siteUrl } } : {}),
    ...(intake.money.receiptFooter ? { receipt: { footer: intake.money.receiptFooter } } : {}),
    ...(typeof intake.look.poweredBy === 'boolean' ? { poweredBy: intake.look.poweredBy } : {}),
  };
  return kit;
}

const websiteEnv = (intake) => CRLF([
  `# Public settings for ${intake.business.name}'s website. Put these in the website's environment before it is built.`,
  `NEXT_PUBLIC_SITE_NAME=${intake.business.name}`,
  intake.ecosystem.website.domain ? `NEXT_PUBLIC_SITE_URL=https://${intake.ecosystem.website.domain}` : '# NEXT_PUBLIC_SITE_URL=https://   (the website name was not given)',
  `NEXT_PUBLIC_COUNTRY=${intake.business.country}`,
  `NEXT_PUBLIC_INDUSTRY=${intake.business.industry}`,
  intake.business.contact.address ? `NEXT_PUBLIC_SHOP_PLACE=${intake.business.contact.address.split(',').slice(-2).join(',').trim()}` : '# NEXT_PUBLIC_SHOP_PLACE=',
  '',
  '# No password or key is written here. The website\'s own accounts (its database and picture storage) are set up separately.',
]);

/** The same public settings on one line, separated by semicolons: what a person pastes into the release workflow's "Website settings" box. Null when a value holds a semicolon (use a brand kit then). */
export function websiteSettingsLine(intake) {
  const values = websiteEnv(intake).split(/\r?\n/).filter((l) => /^NEXT_PUBLIC_[A-Z_]+=/.test(l));
  return values.some((l) => l.includes(';')) ? null : values.join(';');
}

/** The file name the release workflow gives a customer's website for one system (scripts/make-website-package.mjs): website-<customer>-<windows|linux>.zip. */
export const websiteFileName = (customerId, os) => `website-${customerId}-${os}.zip`;

/**
 * What a pack would hold, and what is missing, without writing anything (slug: the customer's short name, which is also its brand kit's name). Returns [{ id, title, wanted, status: 'ready'|'missing'|'skipped', files: [programs], note }].
 * `kit` is the result of readBaseKit.
 */
export function planPack({ intake, kit, slug }) {
  const eco = intake.ecosystem;
  const windows = intake.device.os === 'windows';
  const items = [];
  const hub = intake.device.os === 'linux' ? pick(kit, 'hub-linux-deb', { os: 'linux' }) : pick(kit, 'hub-windows-setup', { os: 'windows', arch: 'x64' });
  items.push({
    id: 'shop-pc', title: windows ? 'The program for the shop computer (Windows)' : 'The program for the shop computer (Linux)', wanted: true, files: hub,
    status: hub.length ? 'ready' : 'missing', note: hub.length ? `Version ${kit.version}${kit.trial ? ', a trial build without licence keys' : ''}.` : `${windows ? 'The Windows setup' : 'The Linux package'} is not in the programs folder.`,
  });
  if (eco.aiAddon?.wanted) {
    const ai = windows ? pick(kit, 'ai-addon-windows') : [];
    items.push({ id: 'ai', title: 'The AI assistant (Windows)', wanted: true, files: ai, status: !windows ? 'skipped' : ai.length ? 'ready' : 'missing',
      note: !windows ? 'It is a Windows program, so it is left out of a Linux pack.' : ai.length ? 'It reads the Windows POS database, not yet the new program\'s own data.' : 'The AI assistant\'s setup is not in the programs folder (it is built on a Windows PC with apps/pos-ai-companion/build.ps1 -Installer).' });
  }
  if (eco.website.wanted) {
    // A website is built for one customer (its name, address and country are built in): only the one named for this customer is used, for each system the release has.
    const site = pick(kit, 'website', { kit: slug });
    items.push({ id: 'website', title: 'The website', wanted: true, files: site, status: site.length ? 'ready' : 'missing',
      note: site.length ? `The website built for this customer (${site.map((f) => f.os === 'windows' ? 'Windows' : 'Linux').join(' and ')}), with its public settings.` : 'The website\'s public settings are in the pack. A website for this customer has not been built yet: each customer has their own build. The pack holds the steps (the release workflow, with these settings).' });
  }
  if (eco.android.wanted) {
    const apk = pick(kit, 'android-apk', { kit: slug });
    items.push({ id: 'android', title: 'The Android app', wanted: true, files: apk, status: apk.length ? 'ready' : 'missing',
      note: apk.length ? 'The signed app made for this customer.' : 'The app for this customer has not been built yet. The pack holds its brand kit and the steps to build it (the release workflow, with this brand kit).' });
  }
  return items;
}

/**
 * Makes the pack. A pack from a trial release (no licence keys) is refused unless allowTrial says it is only for trying. Returns { dir, zip, bytes, sha256, items, contents }.
 *   parts: what the workspace gives for a verified release: { info, intake, files: { 'setup.json': Buffer, ... }, logo: { ext, bytes } | null }
 *   kit: readBaseKit result (must be ok). out: an empty folder to write into (made if missing). The pack's folder and zip are written inside it.
 */
export async function buildPack({ customerId, parts, kit, out, company = {}, builtBy = null, now = new Date(), studioVersion = '', allowTrial = false }) {
  const { info, files, logo } = parts;
  const intake = parts.intake;
  const business = intake.business.name;
  const top = fileSafe(business);
  const root = join(out, `${customerId}-pack-release-${info.n}`);
  rmSync(root, { recursive: true, force: true });
  mkdirSync(root, { recursive: true });
  const dir = join(root, top);
  mkdirSync(dir, { recursive: true });
  const help = [company.supportPhone, company.supportEmail, company.website].filter(Boolean).join(' · ');
  const extras = profileExtras({ intake, info });
  const plan = planPack({ intake, kit, slug: customerId });
  const main = plan.find((p) => p.id === 'shop-pc');
  if (main.status !== 'ready') throw new PackError(`${main.note} Download the release's files into the programs folder and try again.`);
  if (kit.trial && !allowTrial) throw new PackError('These programs were built without the licence keys (a trial build). A customer could never activate them. Use a real release.');
  const written = [];   // folder-relative paths of what was written
  const put = (rel, data) => { const full = join(dir, ...rel.split('/')); mkdirSync(join(full, '..'), { recursive: true }); writeFileSync(full, data); written.push(rel); };
  const copy = (rel, from) => { const full = join(dir, ...rel.split('/')); mkdirSync(join(full, '..'), { recursive: true }); copyFileSync(from, full); written.push(rel); };

  for (const item of plan) {
    if (item.status !== 'ready' && item.id !== 'website' && item.id !== 'android') continue;
    if (item.id === 'shop-pc' && item.status === 'ready') {
      if (intake.device.os === 'windows') {
        const folder = '1 - Shop PC (Windows)';
        for (const f of item.files) copy(`${folder}/${f.name}`, f.path);
        for (const n of PROFILE_FILES) put(`${folder}/profile/${n}`, files[n]);
        put(`${folder}/profile/install.ini`, extras.installIni);
        put(`${folder}/profile/release.txt`, extras.releaseNote);
        const signed = /signed with/i.test(kit.signing.windows);
        put(`${folder}/READ ME FIRST.txt`, readme(`${business}: the program for your shop computer`, [
          'This is for a computer with Windows 10 or Windows 11 (64-bit). Nothing has to be installed first.',
          '',
          '1. Keep this whole folder together: the setup file and the folder called "profile" next to it.',
          `2. Double-click "${item.files[0].name}" and follow the steps. Say Yes when Windows asks for permission.`,
          '3. When it finishes, the program opens in your web browser. The first time, type the licence key you were given.',
          '4. Your business details are already filled in. Check them, choose your own sign-in name and password, and finish.',
          ...(extras.kiosk ? ['', 'This computer is a touch-screen till or a kiosk, so the program also opens full screen by itself when the computer starts.'] : []),
          '',
          signed ? 'The setup is signed, so Windows shows who made it.' : 'If Windows shows a blue notice "Windows protected your PC", click "More info", then "Run anyway". It appears because this setup is not signed yet.',
          '',
          'To remove it: Settings, Apps, Smart Retail POS Hub, Uninstall. The shop\'s information is kept.',
        ], help));
      } else {
        const folder = '1 - Shop PC (Linux)';
        for (const f of item.files) copy(`${folder}/${f.name}`, f.path);
        const deb = profileDeb({ customerId, intake, info, files, company, when: now });
        put(`${folder}/${deb.name}`, deb.data);
        put(`${folder}/install.sh`, installScript({ business }));
        chmodSync(join(dir, ...folder.split('/'), 'install.sh'), 0o755);
        put(`${folder}/READ ME FIRST.txt`, readme(`${business}: the program for your shop computer`, [
          'This is for Ubuntu 22.04 or 24.04, Linux Mint 21 or later, or Debian 12 or later. Nothing has to be installed first.',
          '',
          'The easy way:',
          '1. Open this folder, right-click an empty place and choose "Open in Terminal".',
          '2. Type   sudo ./install.sh   and press Enter. Type your password when asked.',
          '3. When it says "Done", open Smart Retail POS from the menu. The first time, type the licence key you were given.',
          '',
          'Or, without a terminal: double-click the file that starts with smart-retail-pos-hub and press Install, then do the same with the file that starts with smart-retail-profile.',
          ...(extras.kiosk ? ['', 'This computer is a touch-screen till or a kiosk, so the program also opens full screen by itself when someone signs in.'] : []),
          '',
          'To remove it: open Software, find Smart Retail POS and remove it. The shop\'s information (in /var/lib/nextgenos) is kept.',
        ], help));
      }
    }
    if (item.id === 'ai' && item.status === 'ready') {
      const folder = '2 - AI assistant (Windows)';
      for (const f of item.files) copy(`${folder}/${f.name}`, f.path);
      // The business's own settings for its pictures and posters (country, who the model photos show, festivals, second language): plain data beside the setup, which copies it in.
      const aiProfile = buildAiProfile(intake);
      if (aiProfile.problems.length) throw new PackError(`The AI assistant's settings for ${business} cannot be written: ${aiProfile.problems.join(' ')}`);
      put(`${folder}/profile/ai.json`, aiProfile.text);
      put(`${folder}/READ ME FIRST.txt`, readme(`${business}: the AI assistant`, [
        'The AI assistant answers questions about sales and stock, and makes sale posters.',
        'It runs beside the Windows POS on the same computer and only reads its database; it never changes anything.',
        'It does not yet read the information of the new Smart Retail POS program.',
        '',
        '1. Keep this whole folder together: the setup file and the folder called "profile" next to it.',
        `2. Double-click "${item.files[0].name}" and follow the steps.`,
        '3. Open the AI assistant from the Start menu. The first time, type the licence key you were given.',
        '',
        'The folder "profile" holds this business\'s own settings for the AI: its country, who the people in product photos look like, its festivals and the second language of its posters. Setup copies it in. It holds no password or key. Without it the AI still works, with neutral wording.',
      ], help));
    }
    if (item.id === 'website') {
      const folder = '3 - Website';
      for (const f of item.files) copy(`${folder}/${f.name}`, f.path);
      put(`${folder}/website-settings.env`, websiteEnv(intake));
      const line = websiteSettingsLine(intake);
      put(`${folder}/READ ME FIRST.txt`, readme(`${business}: the website`, item.files.length ? [
        `The website built for ${business} is in this folder: ${item.files.map((f) => f.name).join(', ')}.`,
        'Use the one for the computer that will run the website: "windows" for Windows 10 or 11 (64-bit), "linux" for Ubuntu, Linux Mint or Debian (64-bit). Unpack it and read "READ ME FIRST.txt" inside. It carries its own Node.js: nothing has to be installed first.',
        ...item.files.map((f) => `Fingerprint of ${f.name} (SHA-256): ${f.sha256}`),
        ...(kit.trial ? ['', 'This website was built without the licence keys (a trial build). It can never be licensed. Never give it to a customer.'] : []),
        '',
        'The name, address, country and kind of business are built into this website, from website-settings.env (it holds no password). To change them, make a new website.',
        'It needs the licence for the website, and its own accounts (its database and its picture storage). Those are set up by the person who puts the website online; the folder inside lists them in private-settings.example.env.',
      ] : [
        `The website for ${business} has not been built yet. A website is built for each customer, because its name, address and country are built in.`,
        'website-settings.env holds those public settings. It holds no password.',
        `To build it: on GitHub, open Actions, "Release", Run workflow. Type ${customerId} as "Website customer"${line ? ' and paste this line as "Website settings":' : ', and give the settings of website-settings.env (the box takes one line; a setting that holds a semicolon needs a brand kit in brand-kits/ instead):'}`,
        ...(line ? ['', line, ''] : []),
        `The release makes ${websiteFileName(customerId, 'windows')} and ${websiteFileName(customerId, 'linux')}. Download them into the programs folder of the Setup Studio and make the pack again.`,
        'The website also needs its own accounts (its database and its picture storage). Those are set up by the person who puts the website online.',
      ], help));
    }
    if (item.id === 'android') {
      const folder = '4 - Android app';
      for (const f of item.files) copy(`${folder}/${f.name}`, f.path);
      const kitFolder = `${folder}/brand-kit/${customerId}`;
      put(`${kitFolder}/brand.json`, JSON.stringify(brandKitFor({ intake, logo }), null, 2) + '\n');
      if (logo) put(`${kitFolder}/logo.${logo.ext}`, logo.bytes);
      put(`${folder}/READ ME FIRST.txt`, readme(`${business}: the Android app`, item.files.length ? [
        `The app is in this folder: ${item.files.map((f) => f.name).join(', ')}.`,
        'Copy it to the phone and open it. If the phone asks, allow installing from this source.',
      ] : [
        'The app for this business has not been built yet.',
        `The folder brand-kit holds this business's look (brand.json and the logo). To build the app: put the folder "${customerId}" into brand-kits/ of the NextGenOS repository, then on GitHub run the "Release" workflow by hand with Brand kit = ${customerId}.`,
        'It makes the signed app. Download it into the programs folder of the Setup Studio and make the pack again.',
      ], help));
    }
  }

  // The hand-over sheet, last, so it can name what is in the pack.
  const logoUri = logo ? `data:image/${logo.ext === 'jpg' ? 'jpeg' : logo.ext === 'svg' ? 'svg+xml' : logo.ext};base64,${logo.bytes.toString('base64')}` : null;
  const sheet = handoverFor({ intake, info, company, pack: { ai: plan.some((p) => p.id === 'ai' && p.status === 'ready') } });
  put('START HERE.html', handoverHtml(sheet, { colour: intake.look.primaryColor, logo: logoUri }));

  // What is in it, with every file's fingerprint.
  const entries = [];
  for (const rel of written.sort()) {
    const full = join(dir, ...rel.split('/'));
    entries.push({ path: rel, bytes: statSync(full).size, sha256: await sha256Of(full) });
  }
  const contents = {
    schema: 1, customer: { id: customerId, name: business }, release: { n: info.n, bundleHash: info.bundleHash },
    programs: { version: kit.version, trial: kit.trial, signing: kit.signing },
    builtAt: now.toISOString(), builtBy, studio: studioVersion,
    parts: plan.map(({ id, title, status, note, files: f }) => ({ id, title, status, note, programs: f.map((x) => ({ name: x.name, sha256: x.sha256 })) })),
    files: entries,
  };
  writeFileSync(join(dir, 'PACK-CONTENTS.json'), JSON.stringify(contents, null, 2) + '\n');

  // One zip of the whole folder (a person can also copy the folder itself).
  const items = [];
  const walk = (d) => { for (const name of readdirSync(d).sort()) { const full = join(d, name); if (statSync(full).isDirectory()) walk(full); else items.push({ name: `${top}/${relative(dir, full).split(sep).join('/')}`, file: full, ...(name === 'install.sh' ? { mode: 0o755 } : {}) }); } };
  walk(dir);
  const zip = join(root, `${customerId}-pack-release-${info.n}.zip`);
  await writeZipFile(zip, items, { when: now });
  return { dir, zip, bytes: statSync(zip).size, sha256: await sha256Of(zip), plan, contents, name: basename(zip) };
}
