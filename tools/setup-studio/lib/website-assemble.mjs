// Assemble, never build (docs/PLATFORM-DECISIONS.md, decisions 23 and 24): THE website, the one finished program that every customer gets, plus one customer's folder and that
// customer's licence file, become that customer's ready-to-run folder and zip. It copies files and checks them. It builds nothing, needs no network and no tool, and holds no source code.
//
//   generic package   website-<os>.zip (or its unpacked folder), made once per release by scripts/make-website-package.mjs; it holds no customer's settings
//   customer folder   brand.json, setup.json, website-settings.env, theme.json, assets/ (the logo): what the website reads when it starts (apps/storefront-web-mobile/src/lib/customer)
//   licence file      the customer's licence from the Licence Studio (NGOS1.<claims>.<signature>); the website checks its signature itself when it runs
//
// What it refuses (plain words, nothing is written): a customer name that could leave the folder; a customer folder that holds anything but the files above (an environment file, source
// code, a source map, a database, a key, a link, a folder inside a folder); a value in it that looks like a secret or breaks the website's own rules; a licence file that is missing (unless
// told it may be), too big, not in the licence's form, or for a PC instead of a website; a program that is not THE website (it must say so in PACKAGE-INFO.json and carry its rules file).
//
// Where it puts the customer's identity: PACKAGE-INFO.json (customer, name), READ ME FIRST.txt (a few lines in front), and a hidden mark (customer, person, time, licence fingerprint) in
// app/.next/server/.build-info, so that a copy that leaks points back to where it was made (decision 24). The mark is data in a file the package audit accepts.
import { createHash } from 'node:crypto';
import fs from 'node:fs';
import path from 'node:path';
import { pathToFileURL } from 'node:url';
import { findSecrets } from './secretscan.mjs';
import { ZipError, extractZip } from './unzip.mjs';
import { writeZipFile } from './zip.mjs';

/** Something a person must put right before a website can be assembled. */
export class AssembleError extends Error {}

export const CUSTOMER_FOLDER = 'customer';
export const RULES_FILE = 'customer-rules.mjs';
export const MARK_FILE = 'app/.next/server/.build-info';
const CRLF = (lines) => lines.join('\r\n') + '\r\n';
const sha256 = (data) => createHash('sha256').update(data).digest('hex');

/** The customer's short name, as it is used in file names: the same rule as scripts/make-website-package.mjs (and so the same as the build service's). */
export function checkCustomerName(id) {
  const text = String(id ?? '');
  if (!/^[a-z0-9][a-z0-9-]{0,39}[a-z0-9]$/.test(text)) {
    throw new AssembleError(`"${text.slice(0, 60).replace(/[^\x20-\x7e]/g, '?')}" cannot be used as the customer's short name. Use 2 to 41 small letters, digits and hyphens, for example luzon-fresh-mart.`);
  }
  return text;
}

/** The person who makes the website, for the mark: a name or a staff login, as plain text. */
export function checkPerson(person) {
  const text = String(person ?? '').trim();
  if (text.length < 2 || text.length > 80 || /[\u0000-\u001f\u007f<>]/.test(text)) throw new AssembleError('Say who is making this website (2 to 80 letters, a name or a staff login): it is written, with the time, in a hidden mark that points a leaked copy back to its source.');
  return text;
}

// ---------------------------------------------------------------------------------------------------------------------
// The customer's folder
// ---------------------------------------------------------------------------------------------------------------------

const WHY = [
  [/^\.env(\..*)?$/i, 'an environment file (it holds passwords and keys)'],
  [/\.(ts|tsx|jsx|cs|vb|py|sh|bat|ps1|exe|dll|so|js|mjs|cjs)$/i, 'a program or source code'],
  [/\.map$/i, 'a source map'],
  [/\.(db|sqlite|sqlite3|bak|log)$/i, 'a database, a backup or a log'],
  [/\.(pem|key|pfx|p12|jks|keystore|snk)$/i, 'a key or a certificate'],
  [/\.(ngos|ngoslic)$|^licen[cs]e/i, 'a licence file (the licence is given on its own, not inside the customer folder)'],
];
const reasonFor = (name) => WHY.find(([re]) => re.test(name))?.[1] ?? 'not a file a customer folder may hold';

/**
 * Looks at a customer folder without changing it. Returns { problems, files, settings }:
 *   files     the relative paths that will be copied (only ones that may be there)
 *   settings  what the website will use, read with the website's own rules (the copy that travels in the package)
 * `rules` is the website's rules file, loaded from the package (customer-rules.mjs). `packs` ({ countries, industries }) says which packs exist.
 */
export function inspectCustomerFolder(dir, rules, { packs = {} } = {}) {
  const problems = [];
  const files = [];
  let info;
  try { info = fs.lstatSync(dir); } catch { throw new AssembleError(`The customer folder ${dir} was not found.`); }
  if (info.isSymbolicLink() || !info.isDirectory()) throw new AssembleError(`${dir} is not a folder (a link is not accepted).`);
  const addPicture = (rel, full, stat) => {
    if (stat.size > rules.MAX_PICTURE_BYTES) { problems.push(`${rel} is bigger than 3 MB.`); return; }
    const bytes = fs.readFileSync(full);
    const name = path.basename(rel);
    if (name !== 'favicon.ico' && !rules.looksLikePicture(name, bytes)) { problems.push(`${rel} is not a real ${name.split('.').pop().toUpperCase()} picture.`); return; }
    if (/\.svg$/i.test(name) && /<script|\bon[a-z]+\s*=|javascript:/i.test(bytes.toString('utf8'))) { problems.push(`${rel} is a picture that carries a script; a picture may not.`); return; }
    files.push(rel);
  };
  const entries = fs.readdirSync(dir).sort();
  if (entries.length > 60) problems.push('The customer folder holds more than 60 entries: it holds the settings and the logo, and nothing else.');
  for (const name of entries.slice(0, 60)) {
    const full = path.join(dir, name);
    const stat = fs.lstatSync(full);
    if (stat.isSymbolicLink()) { problems.push(`${name} is a link, which a customer folder may not hold.`); continue; }
    if (stat.isDirectory()) {
      if (name !== 'assets') { problems.push(`${name}/ is a folder; a customer folder holds only the folder assets/.`); continue; }
      const inner = fs.readdirSync(full).sort();
      if (inner.length > 40) problems.push('assets/ holds more than 40 files.');
      for (const n of inner.slice(0, 40)) {
        const f = path.join(full, n);
        const st = fs.lstatSync(f);
        const rel = `assets/${n}`;
        if (st.isSymbolicLink() || !st.isFile()) { problems.push(`${rel} is not a plain file.`); continue; }
        if (!(rules.isPictureName(n) || n === 'favicon.ico')) { problems.push(`${rel} is ${reasonFor(n)}; assets/ holds pictures (png, jpg, webp, svg) only.`); continue; }
        addPicture(rel, f, st);
      }
      continue;
    }
    if (!stat.isFile()) { problems.push(`${name} is not a plain file.`); continue; }
    if (Object.hasOwn(rules.FOLDER_FILES, name)) {
      if (stat.size > rules.FOLDER_FILES[name]) { problems.push(`${name} is too big (more than ${Math.round(rules.FOLDER_FILES[name] / 1024)} KB).`); continue; }
      const text = fs.readFileSync(full, 'utf8');
      const secrets = findSecrets(text);
      if (secrets.length) { problems.push(`${name} contains what looks like a secret (${secrets.join(', ')}). A customer folder holds only public settings.`); continue; }
      files.push(name);
      continue;
    }
    if (rules.isPictureName(name)) { addPicture(name, full, stat); continue; }   // a brand kit keeps its logo beside brand.json
    problems.push(`${name} is ${reasonFor(name)}; it is not accepted in a customer folder.`);
  }
  // What the website will make of it, read with the website's own rules: anything it would leave out or refuse is said now, while a person can put it right.
  const read = rules.readCustomerFolder(dir, { fs, path }, { countries: packs.countries ?? null, industries: packs.industries ?? null, environment: null });
  problems.push(...read.problems);
  if (!read.settings.siteName) problems.push("The customer folder gives no shop name (brand.json: name, or website-settings.env: NEXT_PUBLIC_SITE_NAME). A website without a name would be neutral, not this customer's.");
  return { problems: [...new Set(problems)], files, settings: read.settings };
}

// ---------------------------------------------------------------------------------------------------------------------
// The licence file
// ---------------------------------------------------------------------------------------------------------------------

const hostMatches = (host, domains) => {
  const h = String(host ?? '').trim().toLowerCase().replace(/:\d+$/, '');
  return (domains ?? []).some((d) => { const x = String(d).toLowerCase(); return x.startsWith('*.') ? h.endsWith(x.slice(1)) && h.length > x.length - 1 : h === x; });
};

/**
 * Looks at a licence file's text. It cannot check the signature (the signing key is the owner's alone and is never here; the website checks it every time it runs), so it checks the
 * form, and reads what the licence says about itself to catch the usual mistakes. Returns { token, problems, notes, claims }.
 */
export function inspectLicence(text, { siteUrl = '', now = new Date() } = {}) {
  const problems = [];
  const notes = [];
  const token = String(text ?? '').trim();
  if (!token) return { token, problems: ['The licence file is empty.'], notes, claims: null };
  if (token.length > 20000) return { token, problems: ['The licence file is too big to be a licence.'], notes, claims: null };
  const m = /^NGOS1\.([A-Za-z0-9_-]{16,16000})\.([A-Za-z0-9_-]{86})$/.exec(token);
  if (!m) return { token, problems: ['This is not a licence file from the Licence Studio (it must be one line that starts with NGOS1.). Was it saved whole?'], notes, claims: null };
  let claims;
  try { claims = JSON.parse(Buffer.from(m[1], 'base64url').toString('utf8')); } catch { return { token, problems: ['The licence file is damaged (its text cannot be read).'], notes, claims: null }; }
  if (!claims || claims.iss !== 'nextgenos' || claims.typ !== 'lic' || claims.v !== 1) return { token, problems: ['This file is not a licence (it is another kind of file from the Licence Studio, such as a list of stopped licences).'], notes, claims: null };
  if (claims.bind?.mode === 'device') problems.push('This licence is for Windows PCs, not for a website. Ask the Licence Studio for a website licence.');
  const when = Math.floor(now.getTime() / 1000);
  if (claims.nbf && claims.nbf > when + 86400) notes.push('The licence starts in the future; the website will not accept it before then.');
  if (typeof claims.exp === 'number' && claims.exp < when) {
    if (claims.trial) problems.push('This is a trial licence and it has ended: a website with it would stop at once.');
    else notes.push('The licence has an end date that has passed; a paid licence keeps working with a banner.');
  }
  if (claims.trial) notes.push('This is a TRIAL licence: the website stops working at its end date. It is never for a customer who has paid.');
  if (claims.bind?.mode === 'domain' && siteUrl) {
    let host = '';
    try { host = new URL(siteUrl).host; } catch { /* the folder's own check has said what is wrong */ }
    if (host && !hostMatches(host, claims.bind.domains)) notes.push(`The licence is tied to ${(claims.bind.domains ?? []).join(', ') || 'no web address'}, but the customer folder says the website is at ${host}. The website will refuse to run at that address.`);
  }
  return { token, problems, notes, claims };
}

// ---------------------------------------------------------------------------------------------------------------------
// Assembling
// ---------------------------------------------------------------------------------------------------------------------

const walk = (root, prefix = '') => fs.readdirSync(root, { withFileTypes: true }).sort((a, b) => (a.name < b.name ? -1 : 1)).flatMap((e) => {
  const rel = prefix ? `${prefix}/${e.name}` : e.name;
  return e.isDirectory() ? walk(path.join(root, e.name), rel) : [rel];
});

/** The lines in front of the package's own README: whose website this is. */
function readmeHeader({ name, id, version, trial, licenceGiven, madeOn }) {
  const title = `${name}: the website`;
  return CRLF([
    ...(trial ? ['*** TRIAL BUILD, NO LICENCE KEYS ***', 'This website was made without the licence keys. It can never be licensed. Never give it to a customer.', ''] : []),
    title,
    '='.repeat(title.length),
    '',
    `This is the website of ${name} (customer "${id}"), put together on ${madeOn} from version ${version} of Smart Retail POS's website, the same program every shop gets.`,
    'What belongs to this shop is in two folders beside this file:',
    '  customer   the shop\'s settings: name, address, country, language, colours and logo',
    licenceGiven ? '  licence    the shop\'s licence file (licence.ngos)' : '  licence    EMPTY: the licence file is not here yet. Put it here, named licence.ngos, or type the licence key on the page /admin/licence.',
    'The steps below are the same for every shop.',
    '',
    '------------------------------------------------------------------------',
    '',
  ]);
}

/**
 * Puts THE website, one customer's folder and that customer's licence file together. Returns { folder, zip, name, os, version, files, notes, sha256, mark, settings }.
 *   genericPackage   the generic package: website-<os>.zip, or the folder it unpacks to
 *   customerFolder   the customer's folder (see the top of this file)
 *   licenceFile      the customer's licence file; required unless allowNoLicence (a website for a customer whose licence is added later, as the build service does)
 *   customer         the short name (2 to 41 small letters, digits, hyphens)
 *   person           who is making it (it goes in the hidden mark)
 *   out              the folder to write into (made if missing); the website is out/website-<customer>-<os> and out/website-<customer>-<os>.zip
 *   packs            { countries, industries }: the packs that exist (from the Studio's own packs); without it only the shape of a country or kind of business is checked
 *   expectedSha256   the fingerprint the generic zip must have (from the programs folder's list); a zip that does not match is refused
 *   zip              false to write the folder only
 */
export async function assembleWebsite({ genericPackage, customerFolder, licenceFile = null, customer, person, out, now = new Date(), allowNoLicence = false, packs = {}, expectedSha256 = null, zip = true }) {
  const id = checkCustomerName(customer);
  const by = checkPerson(person);
  if (!genericPackage || !fs.existsSync(genericPackage)) throw new AssembleError('The website program (the generic package, website-linux.zip or website-windows.zip) was not found.');
  if (!customerFolder) throw new AssembleError('Give the customer\'s folder.');
  if (!out) throw new AssembleError('Say where to put the finished website.');
  if (!licenceFile && !allowNoLicence) throw new AssembleError('The licence file is missing. A customer\'s website is made with the customer\'s own licence file from the Licence Studio (licence.ngos).');
  if (licenceFile && !fs.existsSync(licenceFile)) throw new AssembleError(`The licence file ${licenceFile} was not found.`);
  const outDir = path.resolve(out);
  fs.mkdirSync(outDir, { recursive: true });
  const work = fs.mkdtempSync(path.join(outDir, '.assembling-'));
  try {
    // 1. THE website: unpacked (a zip) or copied (a folder) into the working folder. Nothing is written outside it until everything has been checked.
    let top;
    if (fs.statSync(genericPackage).isDirectory()) {
      top = path.basename(path.resolve(genericPackage));
      fs.cpSync(genericPackage, path.join(work, 'pkg', top), { recursive: true, dereference: false });
    } else {
      if (expectedSha256 && sha256(fs.readFileSync(genericPackage)) !== expectedSha256) throw new AssembleError('The website program does not match the fingerprint in the programs folder, so it was damaged or changed. It is not used. Take the files of the release again.');
      let unpacked;
      try { unpacked = extractZip(genericPackage, path.join(work, 'pkg')); } catch (e) { throw e instanceof ZipError ? new AssembleError(`The website program could not be opened: ${e.message}`) : e; }
      if (unpacked.tops.length !== 1) throw new AssembleError('The website program is not in the form expected (one folder at the top of the zip).');
      top = unpacked.tops[0];
    }
    const base = path.join(work, 'pkg', top);
    if (!/^website-(windows|linux)$/.test(top)) throw new AssembleError(`The folder ${top} is not THE website (it must be called website-windows or website-linux).`);
    let info;
    try { info = JSON.parse(fs.readFileSync(path.join(base, 'PACKAGE-INFO.json'), 'utf8')); } catch { throw new AssembleError('The website program has no PACKAGE-INFO.json, so it is not a finished website.'); }
    if (info.generic !== true || 'customer' in info || 'publicSettings' in info) throw new AssembleError('This website program is not the generic one: it has a customer\'s settings built in already, or was already assembled. Use the generic program (website-linux.zip or website-windows.zip) from the release.');
    if (info.os !== top.slice('website-'.length)) throw new AssembleError('The website program says it is for another system than its folder name does.');
    if (fs.existsSync(path.join(base, CUSTOMER_FOLDER)) || fs.existsSync(path.join(base, 'licence', 'licence.ngos'))) throw new AssembleError('The website program already holds a customer folder or a licence file. Use the generic program from the release.');
    const rulesPath = path.join(base, RULES_FILE);
    if (!fs.existsSync(rulesPath)) throw new AssembleError(`This website program is too old to be assembled: it carries no ${RULES_FILE} (the rules that check a customer folder). Use a newer release.`);
    const rules = await import(`${pathToFileURL(rulesPath).href}?v=${sha256(fs.readFileSync(rulesPath)).slice(0, 12)}`);
    for (const need of ['readCustomerFolder', 'isPictureName', 'looksLikePicture', 'FOLDER_FILES', 'MAX_PICTURE_BYTES']) if (!(need in rules)) throw new AssembleError(`${RULES_FILE} of this website program does not have ${need}: it is not the one this Studio understands. Use a release that matches this Studio.`);

    // 2. The customer's folder and the licence file, looked at.
    const folder = inspectCustomerFolder(path.resolve(customerFolder), rules, { packs });
    const licence = licenceFile ? inspectLicence(fs.readFileSync(licenceFile, 'utf8'), { siteUrl: folder.settings.siteUrl, now }) : null;
    const problems = [...folder.problems.map((p) => `Customer folder: ${p}`), ...(licence ? licence.problems.map((p) => `Licence: ${p}`) : [])];
    if (problems.length) throw new AssembleError(`The website cannot be put together yet:\n  ${problems.join('\n  ')}`);
    const notes = licence ? licence.notes : ['There is no licence file yet: the website will show a page that says it is not available until the licence is put in the folder "licence".'];

    // 3. Put them together, beside the program, in the working folder.
    const name = folder.settings.siteName;
    const finalName = `website-${id}-${info.os}`;
    const dest = path.join(work, finalName);
    fs.renameSync(base, dest);
    for (const rel of folder.files) {
      const target = path.join(dest, CUSTOMER_FOLDER, ...rel.split('/'));
      fs.mkdirSync(path.dirname(target), { recursive: true });
      fs.copyFileSync(path.join(path.resolve(customerFolder), ...rel.split('/')), target);
      if (process.platform !== 'win32') fs.chmodSync(target, 0o644);
    }
    fs.mkdirSync(path.join(dest, CUSTOMER_FOLDER), { recursive: true });   // an empty folder is still the folder
    if (licence) {
      fs.mkdirSync(path.join(dest, 'licence'), { recursive: true });
      fs.writeFileSync(path.join(dest, 'licence', 'licence.ngos'), licence.token + '\n', { mode: 0o600 });
    }
    const madeAt = now.toISOString();
    fs.writeFileSync(path.join(dest, 'PACKAGE-INFO.json'), JSON.stringify({ ...info, generic: false, customer: id, name, assembledAt: madeAt, licenceIncluded: Boolean(licence) }, null, 2) + '\n');
    const genericReadme = fs.readFileSync(path.join(dest, 'READ ME FIRST.txt'), 'utf8');
    fs.writeFileSync(path.join(dest, 'READ ME FIRST.txt'), readmeHeader({ name, id, version: info.version, trial: Boolean(info.trialWithoutLicenceKeys), licenceGiven: Boolean(licence), madeOn: madeAt.slice(0, 10) }) + genericReadme);
    const mark = { schema: 1, customer: id, person: by, madeAt, licence: licence ? sha256(licence.token).slice(0, 16) : null, program: info.version };
    fs.mkdirSync(path.dirname(path.join(dest, ...MARK_FILE.split('/'))), { recursive: true });
    fs.writeFileSync(path.join(dest, ...MARK_FILE.split('/')), JSON.stringify(mark) + '\n');

    // 4. Look at what was made, as a customer's computer would: the customer folder holds exactly what was approved, the licence is only where the website reads it, nothing else was added.
    const made = walk(path.join(dest, CUSTOMER_FOLDER)).sort();
    if (JSON.stringify(made) !== JSON.stringify([...folder.files].sort())) throw new AssembleError('The customer folder in the finished website is not what was checked. Nothing was written.');
    const allFiles = walk(dest);
    const stray = allFiles.filter((f) => /\.licen[cs]e$|\.ngos(lic)?$/i.test(f) && f !== 'licence/licence.ngos');
    if (stray.length) throw new AssembleError(`A licence file is somewhere it must not be: ${stray.slice(0, 3).join(', ')}.`);

    // 5. Only now does anything appear in the output folder.
    const finalDir = path.join(outDir, finalName);
    const finalZip = path.join(outDir, `${finalName}.zip`);
    fs.rmSync(finalDir, { recursive: true, force: true });
    fs.renameSync(dest, finalDir);
    let zipFile = null;
    let digest = null;
    if (zip) {
      const items = walk(finalDir).map((rel) => ({ name: `${finalName}/${rel}`, file: path.join(finalDir, ...rel.split('/')), ...(process.platform !== 'win32' && fs.statSync(path.join(finalDir, ...rel.split('/'))).mode & 0o111 ? { mode: 0o755 } : {}) }));
      await writeZipFile(finalZip, items, { when: now });
      zipFile = finalZip;
      digest = sha256(fs.readFileSync(finalZip));
    }
    return { folder: finalDir, zip: zipFile, name: finalName, os: info.os, version: info.version, files: allFiles.length, notes, sha256: digest, mark, settings: folder.settings };
  } finally {
    fs.rmSync(work, { recursive: true, force: true });
  }
}
