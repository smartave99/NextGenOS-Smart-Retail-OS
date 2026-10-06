#!/usr/bin/env node
/**
 * The checks the customer-build workflow makes before it builds anything (.github/workflows/build-customer.yml, docs/CUSTOMER-BUILDS.md).
 * What the Setup Studio sends is data from outside this repository, so every job reads it as untrusted: the names, the bundle `inputs.zip` and every file in it.
 *
 *   node scripts/customer-build/validate-inputs.mjs check --zip inputs.zip --out <folder> [--report-only]
 *       Reads the zip (CUSTOMER, BUILD and RESULTS_REPO from the environment, or --customer --build --results-repo), refuses anything that is not what the Studio is
 *       meant to send, and only when everything is in order writes the four files into <folder>. It says in plain words what is wrong, and writes ok=, customer=, build=,
 *       website=, android=, version= and message= to $GITHUB_OUTPUT for the jobs that follow. It exits with 1 when the files are refused (with --report-only it exits 0, so that the first job can hand its answer on before a following step stops it).
 *   node scripts/customer-build/validate-inputs.mjs keys [--report-only]
 *       Says whether the licence keys are there (NGOS_PUBLIC_KEYS and NGOS_LICENCE_URL, public values). Without both, the build is a TRIAL (trial=true); with only one of the
 *       two, it stops (a half-set value would give a website that cannot be licensed and is not marked). A real build (keys built in) is only made from the main branch
 *       (GITHUB_REF and DEFAULT_BRANCH say where this run was started and which branch is main); a trial may be made from any branch.
 *
 * What is accepted: a customer name of 2 to 41 small letters, digits and hyphens; a build number; a results place that is not the repository this workflow runs in
 * (that one holds the source; the results place never does); and a zip of exactly these files and no others: build.json, brand.json, website-settings.env, logo.png.
 * Refused: a name that could leave the folder, an encrypted or damaged zip, a file that is too big, a value that looks like a secret, a part that is not known,
 * a website without its settings, an app without its application id or the address it opens.
 */
import { existsSync, mkdirSync, readFileSync, rmSync, writeFileSync, appendFileSync } from 'node:fs';
import { join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { crc32, inflateRawSync } from 'node:zlib';
import { findSecrets } from '../audit-package.mjs';
import { checkCustomer, checkLogo, knownPacks, parseSettings, WebsiteError } from '../make-website-package.mjs';
import { check as checkBrand } from '../../tools/brand-studio/lib/kit.mjs';

/** A problem a person can put right: said in plain words. */
export class InputsError extends Error {}

export const PARTS_KNOWN = ['website', 'android'];
/** The only files the bundle may hold, and the most each may be (bytes). */
export const FILE_LIMITS = { 'build.json': 8 * 1024, 'brand.json': 64 * 1024, 'website-settings.env': 32 * 1024, 'logo.png': 3 * 1024 * 1024 };
export const MAX_ZIP_BYTES = 8 * 1024 * 1024;
export const MAX_UNPACKED_BYTES = 4 * 1024 * 1024 + 256 * 1024;

// ---------------------------------------------------------------------------------------------------------------------
// The names that come in
// ---------------------------------------------------------------------------------------------------------------------

/** The customer's short name: the same rule as the website package's (scripts/make-website-package.mjs), so the file names it makes are always allowed. */
export function checkCustomerName(value) {
  try { return checkCustomer(value); } catch (e) {
    if (e instanceof WebsiteError) throw new InputsError(`The customer's short name "${String(value ?? '').replace(/[^\x20-\x7e]/g, '?').slice(0, 40)}" cannot be used. A short name is 2 to 41 small letters, digits and hyphens (for example luzon-fresh-mart).`);
    throw e;
  }
}
export function checkBuildNumber(value) {
  if (!/^[1-9][0-9]{0,6}$/.test(String(value ?? ''))) throw new InputsError(`The build number "${String(value ?? '').replace(/[^\x20-\x7e]/g, '?').slice(0, 20)}" is not a whole number from 1 (the Setup Studio counts the builds of each customer).`);
  return Number(value);
}
/** The results place, written owner/name. It must not be the repository this workflow runs in: that one holds the programs' source, and no customer data may be put there. */
export function checkResultsRepo(value, { sourceRepo = '' } = {}) {
  const text = String(value ?? '');
  if (!/^[A-Za-z0-9_.-]{1,100}\/[A-Za-z0-9_.-]{1,100}$/.test(text)) throw new InputsError('The results place must be written like owner/name.');
  if (sourceRepo && text.toLowerCase() === String(sourceRepo).toLowerCase()) throw new InputsError('The results place is the same repository as the one that holds the programs\' source. Use a separate private repository that holds no source (docs/CUSTOMER-BUILDS.md).');
  return text;
}
/** The version the three parts of one build carry: the product's major and minor number, and the build number (a phone takes a higher number as an update). */
export function versionFor(build, base = '1.0') {
  if (!/^\d+\.\d+$/.test(base)) throw new InputsError('PROGRAM_VERSION_BASE must be two numbers, like 1.0.');
  return `${base}.${build}`;
}

// ---------------------------------------------------------------------------------------------------------------------
// The zip: read from its table of contents, never trusting a name, a size or a method it does not know
// ---------------------------------------------------------------------------------------------------------------------

/** { name: Buffer } of a zip, or an InputsError. Only the names in `allowed` are accepted, each once, each within its limit, and every checksum must match. */
export function readInputsZip(buffer, { allowed = FILE_LIMITS, maxUnpacked = MAX_UNPACKED_BYTES } = {}) {
  const bad = (why) => new InputsError(`The bundle of files from the Setup Studio cannot be used: ${why}`);
  if (!Buffer.isBuffer(buffer) || buffer.length < 22) throw bad('it is not a zip file.');
  if (buffer.length > MAX_ZIP_BYTES) throw bad('it is far bigger than a customer\'s settings should be.');
  const end = buffer.lastIndexOf(Buffer.from([0x50, 0x4b, 0x05, 0x06]));
  if (end < 0 || end + 22 > buffer.length) throw bad('it is not a zip file.');
  const count = buffer.readUInt16LE(end + 10);
  const cdSize = buffer.readUInt32LE(end + 12);
  const cdOffset = buffer.readUInt32LE(end + 16);
  if (count === 0xffff || cdOffset === 0xffffffff) throw bad('it is a zip of a kind that is not used here.');
  if (count === 0 || count > Object.keys(allowed).length) throw bad(`it holds ${count} files; it should hold at most ${Object.keys(allowed).length}.`);
  if (cdOffset + cdSize > end) throw bad('it is damaged.');

  const files = {};
  let at = cdOffset;
  let unpacked = 0;
  for (let i = 0; i < count; i += 1) {
    if (at + 46 > buffer.length || buffer.readUInt32LE(at) !== 0x02014b50) throw bad('it is damaged.');
    const flags = buffer.readUInt16LE(at + 8);
    const method = buffer.readUInt16LE(at + 10);
    const crc = buffer.readUInt32LE(at + 16);
    const csize = buffer.readUInt32LE(at + 20);
    const usize = buffer.readUInt32LE(at + 24);
    const nameLen = buffer.readUInt16LE(at + 28);
    const extraLen = buffer.readUInt16LE(at + 30);
    const commentLen = buffer.readUInt16LE(at + 32);
    const local = buffer.readUInt32LE(at + 42);
    const name = buffer.toString('utf8', at + 46, at + 46 + nameLen);
    at += 46 + nameLen + extraLen + commentLen;

    // A name is one of the four, written exactly so: no folder, no "..", no drive, no other file.
    if (!Object.hasOwn(allowed, name)) throw bad(`it holds a file called "${name.replace(/[^\x20-\x7e]/g, '?').slice(0, 60)}", which is not one of the files the Setup Studio sends (${Object.keys(allowed).join(', ')}).`);
    if (Object.hasOwn(files, name)) throw bad(`it holds ${name} twice.`);
    if (flags & 0x1) throw bad(`${name} is locked with a password.`);
    if (method !== 0 && method !== 8) throw bad(`${name} is packed in a way that is not used here.`);
    if (csize === 0xffffffff || usize === 0xffffffff) throw bad(`${name} is too big.`);
    if (usize > allowed[name]) throw bad(`${name} is bigger than it should be (more than ${Math.round(allowed[name] / 1024)} KB).`);
    unpacked += usize;
    if (unpacked > maxUnpacked) throw bad('together the files are bigger than they should be.');
    if (local + 30 > buffer.length || buffer.readUInt32LE(local) !== 0x04034b50) throw bad('it is damaged.');
    const start = local + 30 + buffer.readUInt16LE(local + 26) + buffer.readUInt16LE(local + 28);
    if (start + csize > cdOffset) throw bad('it is damaged.');
    const packed = buffer.subarray(start, start + csize);
    let data;
    try { data = method === 8 ? inflateRawSync(packed, { maxOutputLength: allowed[name] }) : packed; } catch { throw bad(`${name} is damaged or bigger than it should be.`); }
    if (data.length !== usize || crc32(data) !== crc) throw bad(`${name} is damaged (its checksum is wrong).`);
    files[name] = Buffer.from(data);
  }
  return files;
}

// ---------------------------------------------------------------------------------------------------------------------
// What is in the files
// ---------------------------------------------------------------------------------------------------------------------

const asText = (name, bytes) => {
  const text = bytes.toString('utf8');
  if (text.includes('\u0000') || text.includes('�')) throw new InputsError(`${name} is not plain text.`);
  return text;
};
const asJson = (name, bytes) => {
  try { return JSON.parse(asText(name, bytes)); } catch (e) { if (e instanceof InputsError) throw e; throw new InputsError(`${name} cannot be read (it is not valid JSON).`); }
};
const isPlainObject = (v) => v && typeof v === 'object' && !Array.isArray(v);

/**
 * build.json: { "schema": 1, "customer": "<id>", "build": <n>, "studioVersion": "...", "parts": { "website": bool, "android": bool } }.
 * Returns { parts: { website, android } }. It must agree with the customer and the build number the workflow was started with.
 */
export function checkBuildJson(data, { customer, build }) {
  if (!isPlainObject(data)) throw new InputsError('build.json is not a description of a build.');
  if (data.schema !== 1) throw new InputsError('build.json is of a kind this build service does not know (it must say "schema": 1).');
  if (data.customer !== customer) throw new InputsError('build.json is for another customer than the one this build was started for.');
  if (data.build !== build) throw new InputsError('build.json is for another build number than the one this build was started for.');
  if (data.studioVersion !== undefined && !/^[A-Za-z0-9 ._+-]{1,40}$/.test(String(data.studioVersion))) throw new InputsError('build.json names a Setup Studio version that is not written plainly.');
  if (!isPlainObject(data.parts)) throw new InputsError('build.json does not say which parts to build.');
  for (const key of Object.keys(data.parts)) if (!PARTS_KNOWN.includes(key)) throw new InputsError(`build.json asks for a part this build service does not know ("${key.replace(/[^\x20-\x7e]/g, '?').slice(0, 30)}"). It builds: ${PARTS_KNOWN.join(', ')}.`);
  for (const key of PARTS_KNOWN) if (data.parts[key] !== undefined && typeof data.parts[key] !== 'boolean') throw new InputsError(`build.json must say true or false for "${key}".`);
  const parts = { website: data.parts.website === true, android: data.parts.android === true };
  if (!parts.website && !parts.android) throw new InputsError('build.json asks for nothing to be built.');
  return { parts };
}

/** What is wrong with the files, in plain words (a list; empty means they can be used). `dir` is where the files were written (the brand check looks at the logo there). */
export function problemsWith(files, { parts, dir, packs = knownPacks() }) {
  const problems = [];
  const add = (p) => { if (!problems.includes(p)) problems.push(p); };
  const need = (name, why) => { if (!files[name]) add(`${name} is missing: ${why}`); };

  // A value that looks like a key, a password or a database address is refused everywhere, whatever file it is in (the Studio refuses them too; this is the second look).
  for (const [name, bytes] of Object.entries(files)) {
    if (name === 'logo.png') continue;
    const found = findSecrets(bytes.toString('utf8'));
    if (found.length) add(`${name} holds something that looks like a secret (${found.join(', ')}). Nothing of that kind is ever sent to be built.`);
  }

  if (parts.website) {
    need('website-settings.env', 'the website is built from the customer\'s public settings.');
    if (files['website-settings.env']) {
      const settings = parseSettings(asText('website-settings.env', files['website-settings.env']), { ...packs, requireName: true });
      for (const p of settings.problems) add(`website-settings.env: ${p}`);
    }
  }

  const brand = files['brand.json'] ? (() => { try { return asJson('brand.json', files['brand.json']); } catch (e) { add(e.message); return null; } })() : null;
  if (parts.android) need('brand.json', 'the app takes its name, colour and address from it.');
  if (brand) {
    const { errors } = checkBrand(brand, { folder: dir, countries: packs.countries, industries: packs.industries });
    for (const e of errors) add(`brand.json: ${e}`);
    if (parts.android) {
      if (!brand.android?.appId) add('brand.json has no application id for the app (android.appId).');
      if (!brand.android?.storefrontUrl) add('brand.json has no website address for the app to open (android.storefrontUrl).');
      if (!brand.primaryColor) add('brand.json has no main colour for the app.');
      // The app is named after the business: the app set-up refuses a longer name or one with these characters, so it is said now, not after a long build.
      if (typeof brand.name === 'string' && !/^[^<>&"'\\]{1,40}$/.test(brand.name)) add('The business\'s name is also the name of the app, so for the app it can have at most 40 letters and none of < > & " \' or a backslash. Change the name in the Setup Studio and build again.');
    }
  }

  if (files['logo.png']) {
    try {
      const probe = join(dir, 'logo.png');
      checkLogo(probe);
    } catch (e) { add(e instanceof WebsiteError ? e.message : 'logo.png cannot be read as a picture.'); }
  }
  return problems;
}

/** Takes away only the files this check writes (never the folder, and nothing else in it). */
const removeOurs = (dir) => { for (const name of Object.keys(FILE_LIMITS)) rmSync(join(dir, name), { force: true }); };

/**
 * The whole check. `zip` is the bytes of inputs.zip. When everything is in order the files are written into `outDir` and { ok: true, ... } comes back;
 * otherwise nothing stays in outDir and { ok: false, problems, message } comes back (parts is filled in when build.json could be read, so the result can say which parts were wanted).
 */
export function validateInputs({ customer, build, resultsRepo, sourceRepo = '', zip, outDir, versionBase = '1.0', packs }) {
  const fail = (problems, parts = null) => {
    removeOurs(outDir);
    let message = `The files the Setup Studio sent were not accepted. ${problems.join(' ')}`.replace(/\s+/g, ' ').slice(0, 900);
    // A message goes into a result that staff read: it never repeats anything that looks like a secret.
    if (findSecrets(message).length) message = 'The files the Setup Studio sent were not accepted. One of them holds something that looks like a secret.';
    return { ok: false, problems, parts, message };
  };
  let id; let n;
  try {
    id = checkCustomerName(customer);
    n = checkBuildNumber(build);
    checkResultsRepo(resultsRepo, { sourceRepo });
  } catch (e) { if (e instanceof InputsError) return fail([e.message]); throw e; }

  let files; let described;
  try {
    files = readInputsZip(zip);
    if (!files['build.json']) throw new InputsError('build.json is missing: it says which parts to build.');
    described = checkBuildJson(asJson('build.json', files['build.json']), { customer: id, build: n });
  } catch (e) {
    if (!(e instanceof InputsError)) throw e;
    // When build.json can still be read, the answer says which parts were wanted.
    let parts = null;
    try { parts = files?.['build.json'] ? checkBuildJson(asJson('build.json', files['build.json']), { customer: id, build: n }).parts : null; } catch { /* then every part counts as wanted */ }
    return fail([e.message], parts);
  }

  // The files go to the folder only now, and are taken away again if anything else is wrong.
  removeOurs(outDir);
  mkdirSync(outDir, { recursive: true });
  for (const [name, bytes] of Object.entries(files)) writeFileSync(join(outDir, name), bytes);
  let problems;
  try { problems = problemsWith(files, { parts: described.parts, dir: outDir, packs }); } catch (e) { if (e instanceof InputsError) problems = [e.message]; else throw e; }
  if (problems.length) return fail(problems, described.parts);
  return { ok: true, problems: [], parts: described.parts, customer: id, build: n, version: versionFor(n, versionBase), outDir, message: '' };
}

/**
 * Whether the licence keys are built in: { trial, problem }. Both public values set: a real build. Neither: a trial. One of them: a stop, said plainly.
 * A real build is only made from the repository's main branch (`ref` is the branch the run was started on, `defaultBranch` the main one; both are given by the workflow):
 * code that has not been merged into main never gets the licence keys built in for a customer. A trial may be made from any branch.
 */
export function licenceKeysState({ publicKeys = '', licenceUrl = '', ref = '', defaultBranch = '' } = {}) {
  const keys = String(publicKeys).trim() !== '';
  const url = String(licenceUrl).trim() !== '';
  if (!keys && !url) return { trial: true, problem: null };
  if (keys !== url) return { trial: true, problem: `Only one of the two licence values is set in the repository (${keys ? 'NGOS_PUBLIC_KEYS is set but NGOS_LICENCE_URL is not' : 'NGOS_LICENCE_URL is set but NGOS_PUBLIC_KEYS is not'}). Set both for a real build, or neither for a trial build (docs/CUSTOMER-BUILDS.md).` };
  if (ref && defaultBranch && ref !== `refs/heads/${defaultBranch}`) {
    const where = String(ref).replace(/^refs\/(heads|tags)\//, '').replace(/[^\x20-\x7e]/g, '?').slice(0, 60);
    return { trial: false, problem: `A real build, with the licence keys built in, is only made from the main branch (${defaultBranch}). This one was started from "${where}", whose code may not be released yet. Start it from the main branch.` };
  }
  return { trial: false, problem: null };
}

// ---------------------------------------------------------------------------------------------------------------------
// The command line
// ---------------------------------------------------------------------------------------------------------------------

/** One line of text, for $GITHUB_OUTPUT: a value is never allowed to hold a new line (it could make a second output). */
const oneLine = (v) => String(v ?? '').replace(/[\r\n]+/g, ' ').slice(0, 900);
export function writeOutputs(values, file = process.env.GITHUB_OUTPUT) {
  if (!file) return;
  appendFileSync(file, Object.entries(values).map(([k, v]) => `${k}=${oneLine(v)}\n`).join(''));
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const [command, ...args] = process.argv.slice(2);
  const flag = (n, env) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : (env ? process.env[env] : undefined); };
  if (command === 'keys') {
    const state = licenceKeysState({ publicKeys: process.env.NGOS_PUBLIC_KEYS, licenceUrl: process.env.NGOS_LICENCE_URL, ref: process.env.GITHUB_REF, defaultBranch: process.env.DEFAULT_BRANCH });
    writeOutputs({ trial: state.trial, keys_problem: state.problem ?? '' });
    // The first job only reports (keys_problem=) and a following step stops it; a command run on its own stops at once.
    if (state.problem) { console.error(state.problem); if (!args.includes('--report-only')) process.exit(1); else process.exit(0); }
    console.log(state.trial ? 'The licence keys are not set in the repository: this build is a TRIAL (marked, and never for a customer).' : 'The licence keys are set: they are built in.');
  } else if (command === 'check') {
    const zipFile = flag('--zip'); const out = flag('--out');
    if (!zipFile || !out) { console.error('Usage: node scripts/customer-build/validate-inputs.mjs check --zip inputs.zip --out <folder>'); process.exit(2); }
    const base = process.env.PROGRAM_VERSION_BASE || '1.0';
    let result;
    try {
      if (!existsSync(zipFile)) throw new InputsError('The bundle of files from the Setup Studio was not found.');
      result = validateInputs({
        customer: flag('--customer', 'CUSTOMER'), build: flag('--build', 'BUILD'), resultsRepo: flag('--results-repo', 'RESULTS_REPO'), sourceRepo: process.env.GITHUB_REPOSITORY || '',
        zip: readFileSync(zipFile), outDir: resolve(out), versionBase: base,
      });
    } catch (e) {
      if (!(e instanceof InputsError)) throw e;
      result = { ok: false, problems: [e.message], parts: null, message: `The files the Setup Studio sent were not accepted. ${e.message}` };
    }
    writeOutputs({
      ok: result.ok, customer: result.customer ?? '', build: result.build ?? '', version: result.version ?? '', message: result.message,
      website: result.parts ? result.parts.website : 'unknown', android: result.parts ? result.parts.android : 'unknown',
    });
    const reportOnly = args.includes('--report-only');
    if (result.ok) console.log(`The files are in order. Parts to build: ${Object.entries(result.parts).filter(([, v]) => v).map(([k]) => k).join(', ')}. Version ${result.version}.`);
    else {
      console.error(result.message);
      // The first job only reports (ok=false) and a following step stops it; the jobs that build stop at once.
      if (!reportOnly) process.exit(1);
    }
  } else {
    console.error('Use: check or keys.');
    process.exit(2);
  }
}
