#!/usr/bin/env node
/**
 * What one customer build says about itself: the words for each part, result.json and SHA256SUMS.txt (docs/CUSTOMER-BUILDS.md).
 * No network here: scripts/customer-build/results.mjs puts what this makes on the release in the results place.
 *
 *   node scripts/customer-build/result.mjs part --part website-linux --job-status success --steps settings=success,build=success --files a.zip,b.apk --out <folder>
 *       Writes <folder>/part-<name>.json: whether the part worked, one sentence of plain words about it, and for a part that worked the name, size and SHA-256 fingerprint
 *       of each file it made. The last step of every build job runs it (also when the job failed), so the last job can tell the Setup Studio what happened to every part.
 *
 * The words never name GitHub or its Actions: the Setup Studio calls it "the build service", and its screens show these sentences as they are.
 */
import { mkdirSync, readFileSync, statSync, writeFileSync } from 'node:fs';
import { basename, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { findSecrets } from '../audit-package.mjs';
import { sha256 } from './github-api.mjs';

export const PARTS = ['website-linux', 'website-windows', 'android'];
export const PART_LABELS = { 'website-linux': 'website for Linux', 'website-windows': 'website for Windows', android: 'Android app' };
export const TRIAL_FILE = 'NO-LICENCE-KEYS-TRIAL-ONLY.txt';
export const TRIAL_TEXT = 'This build has NO licence keys: it can never be activated. It was made only to try the building. Do not give it to a customer.\n';

/** What each step of a build job is called when a person reads that it failed (the keys are the step ids in .github/workflows/build-customer.yml). */
export const STEP_WORDS = {
  settings: 'reading the customer\'s settings sent by the Setup Studio',
  keys: 'building the licence keys in',
  launcher: 'getting the tool for the Windows program ready',
  install: 'getting the libraries the app needs',
  build: 'building it',
  configure: 'setting the app up for this customer',
  sync: 'preparing the app project',
  signing: 'preparing the key the app is signed with',
  audit: 'checking that it holds no source, secret or database',
  smoke: 'starting it to see that it refuses to work without a licence',
  window: 'opening it in a window the way a person does',
  check: 'checking the app package',
  name: 'naming the files',
  put: 'putting the files with the results',
};

/** Whether a file name is one this build service makes (nothing else is ever put with the results, and nothing else is claimed by a result). */
export function isOutputName(name, customer) {
  const c = customer.replace(/[^a-z0-9-]/g, '');
  return new RegExp(`^(website-${c}-(linux|windows)\\.zip|SmartRetailPOS-${c}-\\d+\\.\\d+\\.\\d+\\.(apk|aab)|ANDROID-SIGNING\\.txt)$`).test(name);
}

/** The files each part makes: a website one zip for its system; the app its .apk, its .aab and a note on how it was signed. */
export function partFileProblem(part, files, customer) {
  const names = files.map((f) => f.name);
  const c = customer.replace(/[^a-z0-9-]/g, '');
  if (part === 'website-linux' || part === 'website-windows') {
    const os = part === 'website-linux' ? 'linux' : 'windows';
    return names.length === 1 && names[0] === `website-${c}-${os}.zip` ? null : `The ${PART_LABELS[part]} should be exactly one file, website-${c}-${os}.zip.`;
  }
  const apk = names.filter((n) => /\.apk$/.test(n)); const aab = names.filter((n) => /\.aab$/.test(n));
  const ok = names.length === 3 && apk.length === 1 && aab.length === 1 && names.includes('ANDROID-SIGNING.txt')
    && apk[0].replace(/\.apk$/, '') === aab[0].replace(/\.aab$/, '') && names.every((n) => isOutputName(n, customer));
  return ok ? null : 'The Android app should be an .apk, an .aab of the same version and ANDROID-SIGNING.txt.';
}

/**
 * One line of plain words, safe to show: no new lines, no control characters, a limit on its length, and never anything that looks like a secret or a token.
 */
export function safeMessage(text, { secrets = [], max = 400 } = {}) {
  let t = String(text ?? '').replace(/[\u0000-\u001f\u007f]+/g, ' ').replace(/\s+/g, ' ').trim();
  for (const s of secrets.filter((x) => x && String(x).length >= 6)) t = t.split(String(s)).join('***');
  if (findSecrets(t).length || /github_pat_|\bgh[pousr]_/.test(t)) return 'The message was left out because it looked like it held a secret.';
  return t.length > max ? `${t.slice(0, max - 1)}…` : t;
}

/**
 * The status and the sentence for a part, from how its job ended and how its steps ended.
 *   jobStatus: success | failure | cancelled   steps: { stepId: success | failure | skipped | cancelled }
 */
export function partOutcome(part, jobStatus, steps = {}) {
  const label = PART_LABELS[part];
  if (!label) throw new Error(`Unknown part: ${part}`);
  const cap = label[0].toUpperCase() + label.slice(1);
  if (jobStatus === 'success') return { status: 'success', message: `The ${label} was built, checked and put with the results.` };
  if (jobStatus === 'cancelled') return { status: 'failure', message: `The ${label} was stopped before it was finished.` };
  const failed = Object.entries(steps).find(([, outcome]) => outcome === 'failure');
  if (failed) {
    const words = STEP_WORDS[failed[0]];
    return { status: 'failure', message: words ? `The ${label} could not be made. It stopped while ${words}. The build service's log for this build shows the details.` : `The ${label} could not be made. The build service's log for this build shows the details.` };
  }
  return { status: 'failure', message: `${cap} did not finish, and the build service did not say why. Its log for this build shows the details.` };
}

/** When a part left no report at all (its job never ran, was lost or was stopped): what to say, from how the job ended. */
export function missingPartOutcome(part, jobResult) {
  const label = PART_LABELS[part];
  if (jobResult === 'cancelled') return { status: 'failure', message: `The ${label} was stopped before it was finished.` };
  if (jobResult === 'skipped') return { status: 'failure', message: `The ${label} was not started, because an earlier part of the build did not work.` };
  return { status: 'failure', message: `The ${label} did not report back, so it cannot be used. The build service's log for this build shows what happened.` };
}

/** The fingerprint list of a build: one line per file, in the form `sha256sum` writes (the Setup Studio checks every downloaded file against it). */
export function sumsText(entries) {
  return `${[...entries].sort((a, b) => (a.name < b.name ? -1 : a.name > b.name ? 1 : 0)).map((e) => `${e.sha256}  ${e.name}`).join('\n')}\n`;
}

/**
 * result.json, as agreed with the Setup Studio (schema 1). It holds the customer, the build number, whether it is a trial, the commit the programs were built from,
 * when it began and ended, and for each part whether it worked and what to tell a person. Nothing else: no token, no setting, no path.
 */
export function buildResultJson({ customer, build, trial, sourceCommit, startedAt, finishedAt, parts }) {
  return {
    schema: 1,
    customer,
    build,
    trial: Boolean(trial),
    sourceCommit,
    startedAt,
    finishedAt,
    parts: Object.fromEntries(PARTS.map((p) => [p, { status: parts[p].status, message: parts[p].message }])),
  };
}

/** Plain words for the page of the release in the results place (staff read it there; the Setup Studio does not need it). */
export function releaseNotes({ customer, build, trial, parts }) {
  const lines = [
    `Build ${build} for ${customer}.`,
    '',
    ...(trial ? ['TRIAL BUILD: it has no licence keys and can never be activated. Never give it to a customer.', ''] : []),
    ...PARTS.map((p) => `- ${PART_LABELS[p][0].toUpperCase()}${PART_LABELS[p].slice(1)}: ${parts[p].status === 'success' ? 'worked' : parts[p].status === 'skipped' ? 'not asked for' : 'did NOT work'}. ${parts[p].message}`),
    '',
    'result.json says the same for the Setup Studio. SHA256SUMS.txt holds the fingerprint of every file; the Setup Studio checks each file against it.',
  ];
  return lines.join('\n');
}

/** A part's report as it is read back by the last job: the shape is checked, because the report travels through places outside this job. */
export function readPartReport(text, part, customer) {
  let r;
  try { r = JSON.parse(text); } catch { return null; }
  if (!r || r.schema !== 1 || r.part !== part || !['success', 'failure'].includes(r.status) || typeof r.message !== 'string' || !Array.isArray(r.files)) return null;
  const files = [];
  for (const f of r.files) {
    if (!f || typeof f.name !== 'string' || !isOutputName(f.name, customer) || !Number.isInteger(f.size) || f.size < 0 || !/^[0-9a-f]{64}$/.test(f.sha256 || '')) return null;
    files.push({ name: f.name, size: f.size, sha256: f.sha256 });
  }
  if (r.status === 'success' && partFileProblem(part, files, customer)) return null;
  // A part that did not work claims no file, whatever its report says.
  return { status: r.status, message: safeMessage(r.message), files: r.status === 'success' ? files : [] };
}

/**
 * The outcome of each step, from "id=outcome,id=outcome": a step id that is written twice (the Linux and the Windows form of one step, of which only one runs) counts
 * as the worse of the two, so that a step that ran and failed is never hidden by its twin that was skipped.
 */
export function parseSteps(text) {
  const rank = { failure: 3, cancelled: 2, success: 1, skipped: 0 };
  const steps = {};
  for (const pair of String(text ?? '').split(',').filter(Boolean)) {
    const [id, outcome = ''] = pair.split('=');
    if (!/^[a-z_]+$/.test(id)) continue;
    if (!(id in steps) || (rank[outcome] ?? -1) > (rank[steps[id]] ?? -1)) steps[id] = outcome;
  }
  return steps;
}

/** { name, size, sha256 } of each file on this machine. */
export function describeFiles(paths) {
  return paths.map((p) => { const bytes = readFileSync(p); return { name: basename(p), size: statSync(p).size, sha256: sha256(bytes) }; });
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const [command, ...args] = process.argv.slice(2);
  const flag = (n) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : undefined; };
  if (command !== 'part') { console.error('Use: part'); process.exit(2); }
  const part = flag('--part'); const out = flag('--out');
  if (!PARTS.includes(part) || !out) { console.error(`Usage: node scripts/customer-build/result.mjs part --part ${PARTS.join('|')} --job-status success|failure|cancelled [--steps id=outcome,...] [--files a,b] --out <folder>`); process.exit(2); }
  const jobStatus = flag('--job-status') || 'failure';
  const steps = parseSteps(flag('--steps'));
  const outcome = partOutcome(part, jobStatus, steps);
  // A part that did not work hands over no file at all, however far it got.
  const files = outcome.status === 'success' ? describeFiles((flag('--files') || '').split(',').filter(Boolean)) : [];
  mkdirSync(out, { recursive: true });
  const file = join(out, `part-${part}.json`);
  writeFileSync(file, `${JSON.stringify({ schema: 1, part, ...outcome, files }, null, 2)}\n`);
  console.log(`${PART_LABELS[part]}: ${outcome.status}. ${outcome.message}`);
}
