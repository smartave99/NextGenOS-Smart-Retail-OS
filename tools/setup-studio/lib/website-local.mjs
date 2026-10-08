// A customer's website package, made on this PC (docs/PLATFORM-DECISIONS.md, decisions 23 and 24: assemble, never build). No GitHub, no access code, no internet.
//
// What it uses, all of it already in the Studio:
//   the website program    website-linux.zip / website-windows.zip from the programs (the kit), the role "website-generic": one finished program, the same for every customer
//   the customer's folder  made here from the customer's APPROVED release, in the form the website reads (brand.json, website-settings.env, assets/<logo>): the very same functions that
//                          make the brand kit and the website settings for the pack and for the build service (pack.mjs), so there is no second format
//   the licence file       whatever the customer's licence slot holds (workspace.websiteLicence); without one the package is still made, and says plainly that the website will not
//                          start until the licence file is put in
//   assembleWebsite        website-assemble.mjs: copies and checks, refuses what must not go in, writes the hidden mark (customer, person, time)
//
// The result is one zip, kept in the customer's own folder of the Studio (builds/<customer>/website-local/<release>/). The Studio holds no source code, builds nothing and signs nothing.
import { createHash } from 'node:crypto';
import { existsSync, mkdirSync, mkdtempSync, readFileSync, renameSync, rmSync, statSync, statfsSync } from 'node:fs';
import { basename, join } from 'node:path';
import { pick, sha256File } from './basekit.mjs';
import { brandKitFor, websiteEnv } from './pack.mjs';
import { AssembleError, assembleWebsite, checkCustomerName, checkPerson, inspectLicence } from './website-assemble.mjs';
import { countries, industries } from './packs.mjs';
import { usableColour } from './rules.mjs';
import { StudioError } from './workspace.mjs';
import { writeAtomic } from './fsx.mjs';

/** The systems a website can be made for, with the words people use. */
export const SYSTEMS = [
  { id: 'linux', label: 'Linux', who: 'Ubuntu, Linux Mint or Debian (64-bit)' },
  { id: 'windows', label: 'Windows', who: 'Windows 10 or 11 (64-bit)' },
];
export const systemLabel = (os) => SYSTEMS.find((s) => s.id === os)?.label ?? String(os);

/** Which systems the programs hold the website for: [{ id, label, who, file: the kit's entry | null }]. */
export function websiteSystems(kit) {
  return SYSTEMS.map((s) => ({ ...s, file: kit ? pick(kit, 'website-generic', { os: s.id })[0] ?? null : null }));
}

/** The packs the website may be told about: the Studio's own copy of the country and industry packs. */
export const knownPacks = () => ({ countries: countries().map((c) => c.code), industries: industries().map((i) => i.id) });

// ---------------------------------------------------------------------------------------------------------------------
// The customer's folder
// ---------------------------------------------------------------------------------------------------------------------

/**
 * The files of the customer's folder, from an approved release (what ws.releaseParts gives): [{ name, data }].
 *   brand.json            the brand kit's file (name, colours, contact, country, kind of business, web address, logo), as the pack and the build service write it
 *   website-settings.env  the website's public settings, as the pack and the build service write them
 *   assets/logo.<ext>     the customer's logo, when there is one
 * setup.json and theme.json are left out on purpose: the website needs neither (brand.json and the settings file say the same), and setup.json may hold the customer's own lists of
 * items and people, which must not travel inside a website that is put online.
 */
export function customerFolderFiles(parts) {
  const intake = parts.intake;
  const logo = parts.logo ?? null;
  const brand = brandKitFor({ intake, logo });
  // The shop program leaves a second colour out when white words cannot be read on it; the website would refuse the folder over it, so it is left out here too.
  if (brand.accentColor && !usableColour(brand.accentColor)) delete brand.accentColor;
  const files = [
    { name: 'brand.json', data: JSON.stringify(brand, null, 2) + '\n' },
    { name: 'website-settings.env', data: websiteEnv(intake) },
  ];
  if (logo) files.push({ name: `assets/logo.${logo.ext}`, data: logo.bytes });
  return files;
}

/** Writes the customer's folder (made if missing) and returns its path. */
export function writeCustomerFolder(dir, parts) {
  for (const f of customerFolderFiles(parts)) writeAtomic(join(dir, ...f.name.split('/')), f.data);
  mkdirSync(dir, { recursive: true });
  return dir;
}

// ---------------------------------------------------------------------------------------------------------------------
// The licence slot
// ---------------------------------------------------------------------------------------------------------------------

/**
 * What the customer's licence slot holds, in words a person can use. `slot` is workspace.websiteLicence(id). The Studio cannot check the signature (the signing key is the owner's
 * alone and is never on a staff PC): the website checks it every time it starts. This reads only what the licence says about itself.
 *   { state: 'none' }  or  { state: 'ok' | 'problem', fingerprint, problems, notes, trial, tiedTo, ends }
 */
export function describeLicence(slot, { siteUrl = '', now = new Date() } = {}) {
  if (!slot) return { state: 'none', problems: [], notes: [] };
  const r = inspectLicence(slot.text, { siteUrl, now });
  const fingerprint = createHash('sha256').update(r.token).digest('hex').slice(0, 16);
  if (r.problems.length) return { state: 'problem', fingerprint, problems: r.problems, notes: r.notes, trial: false, tiedTo: [], ends: null };
  const bind = r.claims?.bind;
  return {
    state: 'ok', fingerprint, problems: [], notes: r.notes, trial: !!r.claims?.trial,
    tiedTo: bind?.mode === 'domain' ? (Array.isArray(bind.domains) ? bind.domains : []).slice(0, 10).map((d) => String(d).replace(/[^\x20-\x7e]/g, '?').slice(0, 100)) : [],
    ends: typeof r.claims?.exp === 'number' ? new Date(r.claims.exp * 1000).toISOString().slice(0, 10) : null,
  };
}

// ---------------------------------------------------------------------------------------------------------------------
// Making the package
// ---------------------------------------------------------------------------------------------------------------------

const enoughRoom = (dir, bytes) => { try { const s = statfsSync(dir); return s.bavail * s.bsize >= bytes; } catch { return true; } };   // when it cannot be read, go on

/** Something that went wrong inside, put as plain words (the cause is written to the Studio's own log, never shown as a code). */
function inPlainWords(e) {
  if (e instanceof StudioError) return e;
  if (e instanceof AssembleError) return new StudioError(e.message, 409, 'website');
  if (e?.code === 'ENOSPC') return new StudioError('There is no room left on this PC to put the website together. Free some space and try again. Nothing was kept.', 409, 'space');
  if (['EACCES', 'EPERM', 'EBUSY'].includes(e?.code)) return new StudioError('The Studio was not allowed to write in its own folder (or something else was using a file there). Close other programs that use the Studio\'s folder and try again. Nothing was kept.', 409, 'write');
  console.error('Studio: making a website package stopped:', e?.stack ?? e);
  return new StudioError('Something went wrong inside the Studio while it put the website together. Nothing was kept. Try again; if it happens again, ask NextGenOS.', 500, 'inside');
}

/**
 * Puts one system's website together for one customer. Writes nothing outside `folder` (the customer's website-local folder for this release); the finished zip is moved in only at the
 * very end. Returns { name, os, bytes, sha256, version, licenceIncluded, trial, notes, files, mark }.
 *   id          the customer's short name         parts    ws.releaseParts(id, n)       kit   the programs (readBaseKit)       os   'linux' | 'windows'
 *   licenceFile the licence slot's file, or null  person   the staff member's name      folder where the zip is kept           where  words for the programs' place (for a message)
 */
export async function makeWebsitePackage({ id, parts, kit, os, licenceFile = null, person, folder, now = new Date(), allowTrial = false, where = 'the programs' }) {
  try {
    checkCustomerName(id);
    try { checkPerson(person); } catch { throw new StudioError('Your name in the Studio cannot be written into the website\'s hidden mark, which needs 2 to 80 letters without < or >. Ask an administrator to add you to the team again under another name.', 409, 'person'); }
    if (!SYSTEMS.some((s) => s.id === os)) throw new StudioError('Choose Linux or Windows.', 400);
    const generic = websiteSystems(kit).find((s) => s.id === os)?.file;
    if (!generic) throw new StudioError(`The website program for ${systemLabel(os)} (the file website-${os}.zip) is not in ${where}. It is part of the programs of a release. Ask NextGenOS for the newest release, or ask an administrator to choose a newer programs folder in Settings.`, 409, 'no-website-program');
    if (kit.trial && !allowTrial) throw new StudioError('These programs were made without the licence keys (a trial build). A website made from them can never be licensed and is only for trying. Tick "only to try" to make one anyway, and never give it to a customer.', 409, 'trial');
    mkdirSync(folder, { recursive: true });
    if (!enoughRoom(folder, generic.bytes * 4 + 300_000_000)) throw new StudioError(`There is not enough room on this PC to put the website together (about ${Math.ceil((generic.bytes * 4 + 300_000_000) / 1e6)} MB are needed). Free some space and try again.`, 409, 'space');
    const work = mkdtempSync(join(folder, '.making-'));
    try {
      const customerFolder = writeCustomerFolder(join(work, 'customer'), parts);
      const made = await assembleWebsite({
        genericPackage: generic.path, customerFolder, licenceFile, allowNoLicence: !licenceFile, customer: id, person, out: join(work, 'out'),
        packs: knownPacks(), expectedSha256: generic.sha256, now, zip: true,
      });
      const info = JSON.parse(readFileSync(join(made.folder, 'PACKAGE-INFO.json'), 'utf8'));
      const final = join(folder, `${made.name}.zip`);
      rmSync(final, { force: true });
      renameSync(made.zip, final);
      const trial = kit.trial === true || info.trialWithoutLicenceKeys === true;
      return { name: `${made.name}.zip`, os, bytes: statSync(final).size, sha256: made.sha256, version: made.version, licenceIncluded: Boolean(licenceFile), trial, notes: made.notes, files: made.files, mark: made.mark };
    } finally { rmSync(work, { recursive: true, force: true }); }
  } catch (e) { throw inPlainWords(e); }
}

// ---------------------------------------------------------------------------------------------------------------------
// What was made, and putting it in the pack
// ---------------------------------------------------------------------------------------------------------------------

/** The website packages made on this PC for one release, newest first (from the customer's record of what was made). */
export const websitesMade = (builds, release) => [...(builds ?? [])].filter((b) => b.kind === 'website-local' && (release === undefined || b.release === release)).reverse();

/** Of those, the newest for each system: what is current. */
export function newestWebsitesMade(builds, release) {
  const seen = new Set();
  return websitesMade(builds, release).filter((b) => SYSTEMS.some((s) => s.id === b.os) && !seen.has(b.os) && seen.add(b.os));
}

/**
 * The programs' kit plus the website packages made on this PC for this customer from this release, as the pack builder reads them (role "website", this customer): so the
 * website is copied into the pack, with its fingerprint, exactly like one put in the programs folder or fetched from the build service. A file whose size is not what was
 * made is left out and named in `siteProblems`; with { verify: true } every fingerprint is read again first. A package made here takes the place of one fetched from the build
 * service for the same system. `folderOf(release)` says where the packages of a release are kept.
 */
export async function withLocalWebsites(kit, { builds, folderOf, release, customerId, verify = false }) {
  const newest = new Map();
  for (const b of websitesMade(builds, release).reverse()) if (SYSTEMS.some((s) => s.id === b.os)) newest.set(b.os, b);   // a later record of the same system replaces an earlier one
  const extra = [];
  const problems = [];
  for (const [os, b] of newest) {
    const name = `website-${customerId}-${os}.zip`;
    const path = join(folderOf(release), name);
    let bad = null;
    if (basename(String(b.file ?? '')) !== name) bad = 'is not the file that was recorded';
    else if (!existsSync(path)) bad = 'is no longer in the Studio\'s folder';
    else if (statSync(path).size !== b.bytes) bad = 'is not the file that was made (its size is different)';
    else if (verify && await sha256File(path) !== b.sha256) bad = 'was changed after it was made (its fingerprint is different)';
    if (bad) problems.push(`${name} ${bad}. Make the website package again.`);
    else extra.push({ name, role: 'website', os, arch: 'x64', kit: customerId, bytes: b.bytes, sha256: b.sha256, path, trial: !!b.trial, assembled: true, licenceIncluded: !!b.licenceIncluded });
  }
  const same = (a, x) => a.role === x.role && a.os === x.os && a.kit === x.kit;
  return { ...kit, files: [...kit.files.filter((f) => !extra.some((x) => same(f, x))), ...extra], trial: kit.trial || extra.some((f) => f.trial), siteProblems: [...(kit.siteProblems ?? []), ...problems] };
}
