#!/usr/bin/env node
/**
 * Talks to the RESULTS REPOSITORY of customer builds (docs/CUSTOMER-BUILDS.md): the private repository, with no source in it, where the Setup Studio leaves a customer's
 * settings and finds the finished programs. One build is one release there, named customer-<id>-<number>. The Studio makes it as a DRAFT and puts inputs.zip on it;
 * this script puts the outputs on it and then, last of all, publishes it. A published release that has result.json means "finished".
 *
 *   node scripts/customer-build/results.mjs download-inputs --out inputs.zip
 *       Takes inputs.zip off the draft release. Refuses a build that is already finished.
 *   node scripts/customer-build/results.mjs upload --files a.zip,b.apk,...
 *       Puts files of the build on the draft release. Only the files this build service makes are accepted, and only while the release is a draft.
 *   node scripts/customer-build/results.mjs finish --parts <folder with the reports of the parts> [--source-commit <sha>] [--started-at <time>] ...
 *       Writes result.json (also when a part failed, with plain words about it) and SHA256SUMS.txt, removes any file nobody claims, and PUBLISHES the release, last.
 *
 * The customer, the build number and the results place come from CUSTOMER, BUILD and RESULTS_REPO (or --customer, --build, --results-repo); the token from RESULTS_TOKEN.
 * That token reaches the results repository only. It is never printed, never written to a file, never put in a message.
 */
import { appendFileSync, existsSync, mkdirSync, readFileSync, statSync, writeFileSync } from 'node:fs';
import { basename, dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { createClient, releaseTag, ResultsError, sha256 } from './github-api.mjs';
import {
  buildResultJson, isOutputName, missingPartOutcome, PARTS, readPartReport, releaseNotes, safeMessage, sumsText, TRIAL_FILE, TRIAL_TEXT,
} from './result.mjs';
import { checkBuildNumber, checkCustomerName, checkResultsRepo, InputsError } from './validate-inputs.mjs';

export const INPUTS_FILE = 'inputs.zip';
export const RESULT_FILE = 'result.json';
export const SUMS_FILE = 'SHA256SUMS.txt';

const plain = (e) => (e instanceof InputsError ? new ResultsError(e.message) : e);

/** The draft release of this build, or a ResultsError that says what to do. */
async function draftRelease(client, customer, build, { forInputs = false } = {}) {
  const tag = releaseTag(customer, build);
  const release = await client.findRelease(tag);
  if (!release) {
    throw new ResultsError(`The results place has no build called ${tag}. The Setup Studio makes it before it asks for the build: in the Setup Studio open Settings, "Connect the build service", press "Test the connection", and start the build again.`);
  }
  if (!release.draft) throw new ResultsError(`Build ${build} of ${customer} is already finished (its release is published), so it is not changed. Start a new build in the Setup Studio.`);
  if (forInputs) {
    const assets = await client.listAssets(release.id);
    if (assets.some((a) => a.name === RESULT_FILE)) throw new ResultsError(`Build ${build} of ${customer} already has its result, so it is not built again. Start a new build in the Setup Studio.`);
    return { release, assets };
  }
  return { release, assets: await client.listAssets(release.id) };
}

/** Takes inputs.zip off the draft release and writes it to `out`. */
export async function downloadInputs({ client, customer, build, out }) {
  const { release, assets } = await draftRelease(client, customer, build, { forInputs: true });
  const inputs = assets.find((a) => a.name === INPUTS_FILE);
  if (!inputs) throw new ResultsError(`Build ${build} of ${customer} has no ${INPUTS_FILE} in the results place: the Setup Studio has not finished sending the customer's settings. Start the build again from the Setup Studio.`);
  if (inputs.size > 8 * 1024 * 1024) throw new ResultsError(`${INPUTS_FILE} is far bigger than a customer's settings should be, so it is not used.`);
  const bytes = await client.downloadAsset(inputs);
  mkdirSync(dirname(resolve(out)), { recursive: true });
  writeFileSync(out, bytes);
  return { releaseId: release.id, bytes: bytes.length };
}

/** Puts files of the build on the draft release. Nothing but this build service's own files is accepted. */
export async function uploadOutputs({ client, customer, build, files, log = console.log }) {
  const { release } = await draftRelease(client, customer, build);
  for (const file of files) {
    const name = basename(file);
    if (!isOutputName(name, customer)) throw new ResultsError(`${name} is not a file this build service makes for ${customer}, so it is not put in the results place.`);
    if (!existsSync(file) || !statSync(file).isFile()) throw new ResultsError(`${name} is not there to be put in the results place.`);
    const bytes = readFileSync(file);
    await client.uploadAsset(release, name, bytes);
    log(`Put ${name} in the results place (${(bytes.length / 1048576).toFixed(1)} MB).`);
  }
  return release.id;
}

const REPORT_FILE = (part) => `part-${part}.json`;

/**
 * Writes result.json and SHA256SUMS.txt, takes away every file nobody claims, and publishes the release, last.
 * `parts` is the folder where the reports of the parts were put (a report per part that ran), `requested` says which parts were asked for ({ website, android }: true, false or
 * null when it is not known, which counts as asked for), `jobResults` how each job ended (success, failure, cancelled, skipped), `inputs` how reading the settings went.
 */
export async function finishBuild({ client, customer, build, sourceCommit, startedAt, now = new Date(), trial, requested, jobResults, inputsMessage, partsDir, log = console.log }) {
  const { release, assets } = await draftRelease(client, customer, build);
  const asked = { 'website-linux': requested.website !== false, 'website-windows': requested.website !== false, android: requested.android !== false };

  const parts = {};
  const claimed = new Map();      // file name -> { size, sha256 }
  for (const part of PARTS) {
    const jobResult = part === 'android' ? jobResults.android : jobResults.website;
    if (!asked[part]) { parts[part] = { status: 'skipped', message: 'This part was not asked for in this build.' }; continue; }
    if (jobResults.inputs !== 'success') {
      parts[part] = { status: 'failure', message: safeMessage(inputsMessage) || 'The build service could not read the customer\'s settings from the results place, so nothing was built. In the Setup Studio open Settings, "Connect the build service", press "Test the connection", and try again.' };
      continue;
    }
    const file = join(partsDir, REPORT_FILE(part));
    const report = existsSync(file) ? readPartReport(readFileSync(file, 'utf8'), part, customer) : null;
    if (!report) { parts[part] = missingPartOutcome(part, jobResult); continue; }
    if (report.status === 'failure') { parts[part] = { status: 'failure', message: report.message }; continue; }
    // The files must really be in the results place, whole (the size matches; and GitHub's own fingerprint too when it gives one).
    const wrong = report.files.find((f) => {
      const a = assets.find((x) => x.name === f.name);
      if (!a || a.size !== f.size) return true;
      return typeof a.digest === 'string' && /^sha256:/.test(a.digest) && a.digest !== `sha256:${f.sha256}`;
    });
    if (wrong) { parts[part] = { status: 'failure', message: `The ${part === 'android' ? 'Android app' : `website for ${part === 'website-linux' ? 'Linux' : 'Windows'}`} was built, but its files did not arrive whole in the results place. Start the build again.` }; continue; }
    parts[part] = { status: 'success', message: report.message };
    for (const f of report.files) claimed.set(f.name, f);
  }

  // The release holds the settings, the files of the parts that worked, and what is written below: nothing else. A part that did not work leaves nothing behind.
  const own = new Set([INPUTS_FILE, RESULT_FILE, SUMS_FILE, TRIAL_FILE]);
  for (const a of assets) if (!own.has(a.name) && !claimed.has(a.name)) { await client.deleteAsset(a); log(`Took away ${a.name}: no part that worked claims it.`); }

  const finished = buildResultJson({ customer, build: Number(build), trial, sourceCommit, startedAt, finishedAt: now.toISOString(), parts });
  const resultBytes = Buffer.from(`${JSON.stringify(finished, null, 2)}\n`);
  if (findLeak(resultBytes.toString('utf8'), client)) throw new ResultsError('result.json would hold something that looks like a secret, so it was not written.');

  const sums = [...claimed.values()].map((f) => ({ name: f.name, sha256: f.sha256 }));
  if (trial) { const t = Buffer.from(TRIAL_TEXT); await client.uploadAsset(release, TRIAL_FILE, t); sums.push({ name: TRIAL_FILE, sha256: sha256(t) }); log(`Put ${TRIAL_FILE} in the results place.`); }
  else if (assets.some((a) => a.name === TRIAL_FILE)) await client.deleteAsset(assets.find((a) => a.name === TRIAL_FILE));
  await client.uploadAsset(release, RESULT_FILE, resultBytes);
  sums.push({ name: RESULT_FILE, sha256: sha256(resultBytes) });
  log(`Put ${RESULT_FILE} in the results place.`);
  const inputsAsset = assets.find((a) => a.name === INPUTS_FILE);
  if (inputsAsset) sums.push({ name: INPUTS_FILE, sha256: sha256(await client.downloadAsset(inputsAsset)) });
  await client.uploadAsset(release, SUMS_FILE, Buffer.from(sumsText(sums)));
  log(`Put ${SUMS_FILE} in the results place (${sums.length} files).`);

  // Last of all: until now the release was a draft, which the Setup Studio does not take for finished.
  const published = await client.publish(release.id, releaseNotes({ customer, build, trial, parts }));
  log(`Published ${releaseTag(customer, build)}: the build is finished (${PARTS.map((p) => `${p}: ${parts[p].status}`).join(', ')}).`);
  return { result: finished, sums, published };
}

/** Whether a text holds the token or anything shaped like a secret. */
function findLeak(text, client) {
  return client.scrub(text) !== text || /github_pat_|\bgh[pousr]_[A-Za-z0-9]{20,}/.test(text);
}

// ---------------------------------------------------------------------------------------------------------------------
// The command line
// ---------------------------------------------------------------------------------------------------------------------

async function main() {
  const [command, ...args] = process.argv.slice(2);
  const flag = (n, env) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : (env ? process.env[env] : undefined); };
  const output = (values) => { if (process.env.GITHUB_OUTPUT) appendFileSync(process.env.GITHUB_OUTPUT, Object.entries(values).map(([k, v]) => `${k}=${String(v ?? '').replace(/[\r\n]+/g, ' ').slice(0, 900)}\n`).join('')); };
  try {
    if (!['download-inputs', 'upload', 'finish'].includes(command)) throw new ResultsError('Use one of: download-inputs, upload, finish.');
    const customer = checkCustomerName(flag('--customer', 'CUSTOMER'));
    const build = checkBuildNumber(flag('--build', 'BUILD'));
    const repo = checkResultsRepo(flag('--results-repo', 'RESULTS_REPO'), { sourceRepo: process.env.GITHUB_REPOSITORY || '' });
    const client = createClient({ token: process.env.RESULTS_TOKEN, repo, apiUrl: process.env.GITHUB_API_URL || undefined, retryDelayMs: Number(process.env.RESULTS_RETRY_DELAY_MS) || 1000 });
    if (command === 'download-inputs') {
      const out = flag('--out');
      if (!out) throw new ResultsError('Say where to put the file: --out inputs.zip');
      const got = await downloadInputs({ client, customer, build, out });
      output({ release_id: got.releaseId });
      console.log(`Took ${INPUTS_FILE} (${got.bytes} bytes) from build ${build} of ${customer}.`);
    } else if (command === 'upload') {
      const files = (flag('--files') || '').split(',').filter(Boolean);
      if (!files.length) throw new ResultsError('Say which files to put in the results place: --files a.zip,b.apk');
      await uploadOutputs({ client, customer, build, files });
    } else {
      const state = (v) => (v === 'true' ? true : v === 'false' ? false : null);
      const commit = flag('--source-commit', 'SOURCE_COMMIT') || '';
      if (!/^[0-9a-f]{40}$/.test(commit)) throw new ResultsError('The commit the programs were built from must be given (--source-commit, 40 letters and numbers).');
      const begun = flag('--started-at', 'STARTED_AT') || '';
      await finishBuild({
        client, customer, build, sourceCommit: commit,
        startedAt: /^\d{4}-\d\d-\d\dT\d\d:\d\d:\d\dZ$/.test(begun) ? begun : new Date().toISOString(),
        // When it is not known whether the keys were there, the build counts as a trial: the cautious answer.
        trial: flag('--trial', 'TRIAL') !== 'false',
        requested: { website: state(flag('--website', 'WEBSITE_REQUESTED')), android: state(flag('--android', 'ANDROID_REQUESTED')) },
        jobResults: { inputs: flag('--inputs-result', 'INPUTS_RESULT') || 'failure', website: flag('--website-result', 'WEBSITE_RESULT') || 'skipped', android: flag('--android-result', 'ANDROID_RESULT') || 'skipped' },
        inputsMessage: flag('--inputs-message', 'INPUTS_MESSAGE') || '',
        partsDir: resolve(flag('--parts') || 'parts'),
      });
    }
  } catch (e) {
    const error = plain(e);
    const token = process.env.RESULTS_TOKEN || '';
    const said = (token ? String(error?.message || error).split(token).join('***') : String(error?.message || error));
    const known = error instanceof ResultsError || error instanceof InputsError;
    // The first job hands the reason on, in plain words, for the result that the last job writes.
    if (command === 'download-inputs') output({ ok: false, message: known ? `The build service could not take the customer's settings from the results place. ${said}` : 'The build service could not take the customer\'s settings from the results place.' });
    console.error(known ? said : `Something unexpected went wrong: ${said.slice(0, 300)}`);
    process.exit(1);
  }
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) await main();
