// The build service: how the Studio gets a customer's website and Android app made, and brings them back into the customer's pack.
//
// A website and an app have the customer's name, colours and settings built into them, and building them needs the program's source code. The source never comes to a PC
// that runs the Studio (CLAUDE.md, sections 3 and 11), so the build is done where the source is. The Studio does five things, in this order:
//   1. it puts together the customer's PUBLIC settings (their brand, their logo, the website's public settings) as one small zip, and refuses it when anything looks like a secret;
//   2. it keeps that zip in a private "results" place, as a draft release named customer-<id>-<n> (n is the Studio's own count for that customer);
//   3. it asks the build service to start (the repository that holds the source), giving it only the customer's name, the number and the results place;
//   4. it watches the build every few seconds, and tells the person in plain words which step it is on;
//   5. when the build has published its result, it fetches the files, checks every one against SHA256SUMS.txt, and puts them in this customer's own folder, from where the pack
//      builder takes them exactly as it takes the files of the programs folder (withSiteBuilds).
//
// Two access codes do the talking. One may only start builds and watch them (it cannot read the source); the other may only keep and fetch the results (it cannot reach the source).
// They live only in the Studio's secret store (secrets.mjs), are sent only to the build service, are never followed to another address, and never appear in a file, a message or
// the activity record. The addresses are fixed: only a test may pass others in. What cannot be tested here (the real service with the owner's repositories) is said so in
// docs/SETUP-STUDIO.md.
import { createHash, randomBytes } from 'node:crypto';
import { createReadStream, createWriteStream, existsSync, mkdirSync, renameSync, rmSync, statSync, statfsSync, writeFileSync } from 'node:fs';
import { Readable, Transform, Writable } from 'node:stream';
import { pipeline } from 'node:stream/promises';
import { join } from 'node:path';
import { StudioError, can } from './workspace.mjs';
import { brandKitFor, websiteEnv } from './pack.mjs';
import { makeZip } from './zip.mjs';
import { findSecrets } from './secretscan.mjs';
import { getBuildCode, buildCodeStatus } from './secrets.mjs';
import { redact } from './ai/cli.mjs';
import { readJson, writeJson } from './fsx.mjs';

export const WORKFLOW_FILE = 'build-customer.yml';
const DEFAULT_API = 'https://api.github.com';
const DEFAULT_UPLOADS = 'https://uploads.github.com';
const REPO = /^[A-Za-z0-9][A-Za-z0-9-]{0,38}\/[A-Za-z0-9][A-Za-z0-9._-]{0,99}$/;
const REF = /^[A-Za-z0-9][A-Za-z0-9._/-]{0,100}$/;
const RESULTS_NAME = 'nextgenos-customer-builds';
const ACTIVE = new Set(['running', 'fetching']);
const MAX_FILE = 3 * 1024 * 1024 * 1024;
const MAX_TEXT = 2_000_000;

/** What can be built for a customer: the website (for each system) and the Android app. */
export const PARTS = [
  { id: 'website-linux', want: 'website', words: 'The website for Linux' },
  { id: 'website-windows', want: 'website', words: 'The website for Windows' },
  { id: 'android', want: 'android', words: 'The Android app' },
];
const PART_IDS = new Set(PARTS.map((p) => p.id));
const partWords = (id) => PARTS.find((p) => p.id === id)?.words ?? id;
const WHICH = { start: 'access code for starting builds', results: 'access code for keeping the results' };

/**
 * Something said in plain words to a person. `kind` says what the Studio does next: 'failed' (this build stops), 'retry' (a passing problem: try again at the next look),
 * 'stopped' (stop waiting, the person can look again later).
 */
export class BuildError extends StudioError {
  constructor(message, code = 'build', { status = 409, kind = 'failed' } = {}) { super(message, status, code); this.kind = kind; }
}

const isLoopback = (host) => ['127.0.0.1', 'localhost', '[::1]'].includes(host);
const sleep = (ms, signal) => new Promise((done) => { const t = setTimeout(done, ms); signal?.addEventListener('abort', () => { clearTimeout(t); done(); }, { once: true }); });
const clean = (text, max = 300) => String(text ?? '').replace(/[\u0000-\u001f<>]/g, ' ').replace(/\s+/g, ' ').trim().slice(0, max);
const sha = (buffer) => createHash('sha256').update(buffer).digest('hex');

/** A repository name as owner/name, or throws in plain words. An empty name is allowed (it clears the setting). */
export function checkRepoName(value, what) {
  const v = String(value ?? '').trim();
  if (!v) return '';
  if (!REPO.test(v) || v.includes('..')) throw new StudioError(`${what}: type the name like owner/name, for example your-account/your-repository.`);
  return v;
}

/** The words for one step of the build, from the name the build service gives that step. Anything not recognised is shown as a plain "another step", never as a raw name. */
export function jobWords(name) {
  const n = String(name ?? '').toLowerCase();
  if (/website|web site|storefront|\bsite\b/.test(n)) return /linux/.test(n) ? 'Building the website for Linux' : /windows|\bwin\b/.test(n) ? 'Building the website for Windows' : 'Building the website';
  if (/android|\bapk\b|\baab\b|\bapp\b/.test(n)) return 'Building the Android app';
  if (/valid|check|input|prepar|setting/.test(n)) return 'Checking the settings that were sent';
  if (/publish|release|upload|collect|gather|result|finish|summary|assemble/.test(n)) return 'Putting the finished files together';
  return 'Another step of the build';
}
const jobState = (j) => (j.status === 'completed' ? ({ success: 'done', skipped: 'skipped', neutral: 'done' }[j.conclusion] ?? (j.conclusion === 'cancelled' ? 'skipped' : 'failed')) : j.status === 'in_progress' ? 'working' : 'waiting');

/** What the customer's brand, public website settings and build request look like. `wants` is { website, android } (what is asked for this time). */
export function partsWanted(intake) {
  const e = intake.ecosystem ?? {};
  return { website: e.website?.wanted === true, android: e.android?.wanted === true && !!e.website?.domain };
}

/**
 * The small zip sent to the build service: exactly the files it accepts and no others: brand.json (as the Brand Studio writes it), logo.png, website-settings.env (public values
 * only) and build.json. A value that looks like a secret, or that is one of the access codes, stops everything: nothing is sent. `parts` is what the workspace gives for a
 * verified release. The build service takes the logo only as a PNG picture: a customer's logo in another form is left out (and brand.json does not name it), which the page says.
 */
export function makeInputs({ customerId, n, parts, studioVersion = '', wants, forbid = [] }) {
  const intake = parts.intake;
  const logo = parts.logo?.ext === 'png' ? parts.logo : null;
  const brand = JSON.stringify(brandKitFor({ intake, logo }), null, 2) + '\n';
  const settings = websiteEnv(intake);
  const request = JSON.stringify({ schema: 1, customer: customerId, build: n, studioVersion, parts: { website: !!wants.website, android: !!wants.android } }, null, 2) + '\n';
  for (const [text, what] of [[brand, 'the business details (name, tagline, contact, words on the bill)'], [settings, 'the website settings']]) {
    const hits = findSecrets(text);
    if (hits.length) throw new BuildError(`${what} hold something that looks like a password or a key (${hits.join(', ')}). A customer's details must never hold one. Take it out of the details, prepare the setup again and have it approved again. Nothing was sent.`, 'secret', { status: 400 });
    if (forbid.some((f) => f && text.includes(f))) throw new BuildError(`${what} hold one of the Studio's own access codes. Take it out of the details. Nothing was sent.`, 'secret', { status: 400 });
  }
  const entries = [{ name: 'brand.json', data: Buffer.from(brand) }, { name: 'website-settings.env', data: Buffer.from(settings) }, { name: 'build.json', data: Buffer.from(request) }];
  if (logo) entries.push({ name: 'logo.png', data: logo.bytes });
  return { zip: makeZip(entries), entries: entries.map((e) => ({ name: e.name, bytes: e.data.length })), brand, settings };
}

/** Reads result.json as the build service wrote it, and checks it is about this customer and this build. */
export function readResult(text, { customerId, n }) {
  let r;
  try { r = JSON.parse(text); } catch { throw new BuildError('The build left a report that the Studio cannot read.', 'result'); }
  if (!r || r.schema !== 1 || r.customer !== customerId || r.build !== n || typeof r.parts !== 'object' || !r.parts) throw new BuildError('The report the build left is not about this customer and this build, so the Studio did not use it.', 'result');
  const parts = {};
  for (const [id, p] of Object.entries(r.parts)) {
    if (!PART_IDS.has(id) || !p || !['success', 'failure', 'skipped'].includes(p.status)) continue;
    const message = clean(p.message);
    parts[id] = { status: p.status, message: message && findSecrets(message).length ? '(the message was left out because it looked like a secret)' : message };
  }
  return { trial: r.trial === true, sourceCommit: /^[0-9a-f]{7,40}$/i.test(String(r.sourceCommit ?? '')) ? String(r.sourceCommit) : null, startedAt: clean(r.startedAt, 40), finishedAt: clean(r.finishedAt, 40), parts };
}

/** The lines of SHA256SUMS.txt as { name: sha256 }. A name with a folder in it is not allowed. */
export function readSums(text) {
  const out = {};
  for (const line of String(text ?? '').split(/\r?\n/)) {
    const m = /^([0-9a-fA-F]{64})\s+\*?(\S.*?)\s*$/.exec(line);
    if (!m) continue;
    if (/[\\/]/.test(m[2]) || m[2].includes('..')) throw new BuildError('The list of fingerprints that came back holds a name with a folder in it, so the Studio did not use it.', 'sums');
    out[m[2]] = m[1].toLowerCase();
  }
  return out;
}

/** For a customer: which files each part is made of, and the names that are allowed (never another customer's). */
export function fileRules(customerId) {
  return [
    { part: 'website-linux', role: 'website', os: 'linux', arch: 'x64', re: new RegExp(`^website-${customerId}-linux\\.zip$`), need: true },
    { part: 'website-windows', role: 'website', os: 'windows', arch: 'x64', re: new RegExp(`^website-${customerId}-windows\\.zip$`), need: true },
    { part: 'android', role: 'android-apk', os: 'android', re: new RegExp(`^SmartRetailPOS-${customerId}-\\d+\\.\\d+\\.\\d+\\.apk$`), need: true },
    { part: 'android', role: 'android-aab', os: 'android', re: new RegExp(`^SmartRetailPOS-${customerId}-\\d+\\.\\d+\\.\\d+\\.aab$`), need: false },
  ];
}

/** Which parts of the newest builds of one release can be used: { part: { build, trial } }. A part comes whole from one build. */
function bestParts(state, release) {
  const out = {};
  for (const rec of [...state.builds].sort((a, b) => b.n - a.n)) {
    if (rec.release !== release) continue;
    for (const f of rec.files ?? []) if (!out[f.part]) out[f.part] = { build: rec.n, trial: !!rec.trial };
  }
  return out;
}

/**
 * The programs folder's kit plus the website and app made for this customer from this release, as the pack builder reads them (pack.mjs asks for role + kit): so a built website is
 * copied into the pack exactly like a website put in the programs folder. Files whose size is not what was fetched are left out and named in `problems`; with { verify: true } every
 * fingerprint is read again first. A customer's own built file takes the place of a file of the same kind in the programs folder.
 */
export async function withSiteBuilds(kit, { folder, release, customerId, verify = false }) {
  const state = readJson(join(folder, 'state.json'), { builds: [] });
  const best = bestParts(state, release);
  const extra = [];
  const problems = [];
  for (const rec of state.builds) {
    for (const f of rec.files ?? []) {
      if (best[f.part]?.build !== rec.n) continue;
      const path = join(folder, String(rec.n), f.name);
      let bad = null;
      if (!existsSync(path)) bad = 'is no longer in the Studio\'s folder';
      else if (statSync(path).size !== f.bytes) bad = 'is not the file that was fetched (its size is different)';
      else if (verify && await sha256Of(path) !== f.sha256) bad = 'was changed after it was fetched (its fingerprint is different)';
      if (bad) problems.push(`${f.name} ${bad}. Build it again.`);
      else extra.push({ name: f.name, role: f.role, os: f.os, arch: f.arch ?? '', kit: customerId, bytes: f.bytes, sha256: f.sha256, path, trial: !!rec.trial });
    }
  }
  const same = (a, b) => a.role === b.role && a.os === b.os && a.kit === b.kit;
  return { ...kit, files: [...kit.files.filter((f) => !extra.some((x) => same(f, x))), ...extra], trial: kit.trial || extra.some((f) => f.trial), problems: kit.problems ?? [], siteProblems: problems };
}

async function sha256Of(path) {
  const h = createHash('sha256');
  for await (const chunk of createReadStream(path)) h.update(chunk);
  return h.digest('hex');
}

/**
 * The service. `ws` is the workspace; `env` is where the Studio's secret store is looked for. The other options exist so a test can use a stand-in service on this PC:
 * `api`, `uploads` (addresses), `fetchFn`, how often to look (`pollMs`), how long to wait (`ceilingMs`), and how many passing problems in a row are put up with.
 */
export function createBuildService({ ws, env = process.env, studioVersion = '', api = DEFAULT_API, uploads = null, fetchFn = fetch, pollMs = 20_000, ceilingMs = 90 * 60_000, requestTimeoutMs = 30_000, downloadTimeoutMs = 30 * 60_000, lostContactLimit = 5 } = {}) {
  const uploadBase = uploads ?? (api === DEFAULT_API ? DEFAULT_UPLOADS : api);
  const local = isLoopback(new URL(api).hostname);
  const closing = new AbortController();
  const followers = new Map();
  const starting = new Set();
  const code = (which) => getBuildCode(which, env);
  const secretsNow = () => [code('start'), code('results')].filter(Boolean);

  // ---- what is set ----------------------------------------------------------------------------------------------------------------------

  const settings = () => { const b = ws.settings().build ?? {}; return { sourceRepo: b.sourceRepo ?? '', resultsRepo: b.resultsRepo ?? '', ref: b.ref ?? '' }; };
  const suggestResults = (source) => (REPO.test(source) ? `${source.split('/')[0]}/${RESULTS_NAME}` : '');
  const missing = () => {
    const s = settings();
    if (!s.sourceRepo || !s.resultsRepo) return 'An administrator has not connected the build service yet (Settings, "Connect the build service": the two repository names).';
    if (!code('start') || !code('results')) return 'An administrator has not added both access codes yet (Settings, "Connect the build service").';
    return null;
  };

  /** What anyone signed in may see: the names, whether each code is there, and whether builds can be started. Never a code. */
  function connection() {
    const s = settings();
    return { ...s, suggestedResults: s.resultsRepo ? '' : suggestResults(s.sourceRepo), codes: buildCodeStatus(env), ready: !missing(), why: missing() };
  }

  function saveNames(me, input) {
    const sourceRepo = checkRepoName(input.sourceRepo, 'Where the programs are made');
    const resultsRepo = checkRepoName(input.resultsRepo, 'Where the results are kept');
    const ref = String(input.ref ?? '').trim();
    if (ref && (!REF.test(ref) || ref.includes('..'))) throw new StudioError('Which version to build from: type a name made of letters, numbers, dots, dashes and slashes, or leave it empty.');
    if (ws.ids().some((id) => load(id).builds.some((b) => ACTIVE.has(b.state)))) throw new StudioError('A build is running. Wait for it to finish before changing where builds are made.', 409);
    if (sourceRepo && resultsRepo && sourceRepo.toLowerCase() === resultsRepo.toLowerCase()) throw new StudioError('The results must be kept in a different place from the programs: no program is ever kept with the results, and the two access codes are for two places.');
    ws.saveSettings(me, { build: { sourceRepo, resultsRepo, ref } });
    return connection();
  }

  // ---- talking to the build service --------------------------------------------------------------------------------------------------------

  const reached = (e) => {
    if (closing.signal.aborted) return new BuildError('The Studio is closing.', 'closing', { kind: 'stopped' });
    if (e instanceof BuildError) return e;
    if (e?.name === 'TimeoutError') return new BuildError('The build service did not answer in time. Check the internet connection.', 'timeout', { kind: 'retry' });
    const why = redact(clean(e?.cause?.code ?? e?.code ?? e?.name ?? 'error', 60), secretsNow());
    return new BuildError(`The Studio could not reach the build service (${why}). Check the internet connection and try again.`, 'network', { kind: 'retry' });
  };

  /** One request, with the access code in its header only. A redirect is never followed from here (the code would go with it): it is read as an answer. */
  async function call(which, method, url, { json, body, headers = {}, timeoutMs = requestTimeoutMs } = {}) {
    const token = code(which);
    if (!token) throw new BuildError(`The ${WHICH[which]} has not been added yet. An administrator adds it in Settings, "Connect the build service".`, 'no-code', { kind: 'stopped' });
    try {
      return await fetchFn(url, {
        method, redirect: 'manual', signal: AbortSignal.any([AbortSignal.timeout(timeoutMs), closing.signal]),
        headers: { authorization: `Bearer ${token}`, accept: 'application/vnd.github+json', 'x-github-api-version': '2022-11-28', 'user-agent': 'NextGenOS-Setup-Studio', ...(json !== undefined ? { 'content-type': 'application/json' } : {}), ...headers },
        body: json !== undefined ? JSON.stringify(json) : body,
      });
    } catch (e) { throw reached(e); }
  }

  /** Why the build service said no, in plain words. */
  async function refused(res, which, what) {
    let detail = '';
    try { detail = clean(JSON.parse(await res.text())?.message, 160); } catch { /* no reason given */ }
    detail = redact(detail, secretsNow());
    const asking = what ? ` (${what})` : '';
    if (res.status === 429 || (res.status === 403 && res.headers.get('x-ratelimit-remaining') === '0')) return new BuildError('The build service says there have been too many requests. Wait a few minutes and try again.', 'rate', { kind: 'retry' });
    if (res.status === 401) return new BuildError(`The build service did not accept the ${WHICH[which]}. It may have been typed wrongly, or it may have run out (access codes end on a date chosen when they were made). An administrator can add a new one in Settings, "Connect the build service".`, 'refused');
    if (res.status === 403) return new BuildError(`The ${WHICH[which]} is not allowed to do this${asking}. It was probably made without the permission it needs. The guide ("Connecting the build service") says what each code must be allowed to do.`, 'forbidden');
    if (res.status === 404) return new BuildError(`The build service did not find what the Studio asked for${asking}. Check the two repository names in Settings, and that the ${WHICH[which]} was made for the right one.`, 'not-found');
    if ([301, 302, 307, 308].includes(res.status)) return new BuildError('A repository has been moved or renamed. Check its name in Settings, "Connect the build service".', 'moved');
    if (res.status >= 500) return new BuildError(`The build service had a problem (${res.status}). It usually passes: try again in a minute.`, 'server', { kind: 'retry' });
    if (res.status === 422) return new BuildError(`The build service did not accept the request${asking}${detail ? `: ${detail}` : ''}.`, 'rejected');
    return new BuildError(`The build service answered something the Studio did not expect${asking} (${res.status}${detail ? `, ${detail}` : ''}).`, 'unexpected');
  }

  /** The status of an answer whose body is not wanted (the connection test only asks whether the door is open). */
  const statusOf = async (res) => { await res.body?.cancel().catch(() => {}); return res.status; };

  async function ok(res, which, what, accept = [200, 201, 204]) {
    if (!accept.includes(res.status)) throw await refused(res, which, what);
    if (res.status === 204) return null;
    try { return JSON.parse(await res.text()); } catch { throw new BuildError('The build service sent an answer the Studio cannot read.', 'format', { kind: 'retry' }); }
  }
  const get = async (which, path, what) => ok(await call(which, 'GET', `${api}${path}`), which, what);

  // ---- "Test the connection" -----------------------------------------------------------------------------------------------------------------

  /** Asks the build service a few harmless questions and says in plain words what is right and what is wrong. A code must be able to do what it is for, and nothing more. */
  async function testConnection() {
    const s = settings();
    const checks = [];
    const add = (id, okay, words) => checks.push({ id, ok: okay, words });
    const attempt = async (id, run) => { try { await run(); } catch (e) { add(id, false, e instanceof BuildError ? e.message : 'The check could not be made.'); } };
    if (!s.sourceRepo || !s.resultsRepo) { add('names', false, 'Type the two repository names and save them first.'); return { ok: false, checks }; }
    const have = buildCodeStatus(env);
    if (!have.start.set) add('start-code', false, `The ${WHICH.start} has not been added yet.`);
    if (!have.results.set) add('results-code', false, `The ${WHICH.results} has not been added yet.`);

    if (have.start.set) {
      let repo = null;
      await attempt('start-code', async () => { repo = await get('start', `/repos/${s.sourceRepo}`, 'looking for the programs'); add('start-code', true, `The ${WHICH.start} is accepted for ${s.sourceRepo}.`); });
      if (repo) {
        await attempt('build-setup', async () => {
          let flow;
          try { flow = await get('start', `/repos/${s.sourceRepo}/actions/workflows/${WORKFLOW_FILE}`, 'looking for the build'); } catch (e) {
            if (e.code === 'not-found' || e.code === 'forbidden') throw new BuildError(`The build was not found in ${s.sourceRepo}. Either it has not been added there yet (NextGenOS adds it), or this access code is not allowed to look at builds.`, e.code);
            throw e;
          }
          if (flow?.state && flow.state !== 'active') throw new BuildError('The build is there but it is switched off. Switch it on in the repository, as the guide says.', 'off');
          add('build-setup', true, 'The build is set up and switched on.');
        });
        await attempt('start-power', async () => {
          // A code that may only start builds cannot read the source. If it can, it is stronger than it should be.
          if (await statusOf(await call('start', 'GET', `${api}/repos/${s.sourceRepo}/contents`)) === 200) add('start-power', false, 'This access code can also read the programs\' source code. It only needs to start builds. Make a new one that is not allowed to read the code (the guide shows how) and replace this one.');
          else add('start-power', true, 'It cannot read the programs\' source code, which is right: it only starts builds.');
        });
        await attempt('start-run', async () => {
          // Starting a build for a version that does not exist is refused, but only after the permission to start one has been checked: a harmless way to ask.
          const res = await call('start', 'POST', `${api}/repos/${s.sourceRepo}/actions/workflows/${WORKFLOW_FILE}/dispatches`, { json: { ref: `refs/heads/studio-connection-test-${randomBytes(4).toString('hex')}`, inputs: {} } });
          if (res.status === 403 || res.status === 401) throw await refused(res, 'start', 'starting a build');
          if (await statusOf(res) === 422) add('start-run', true, 'It may start builds.');
          else add('start-run', null, 'The Studio cannot tell, without really starting one, whether this code may start builds. The first build will show it.');
        });
        await attempt('start-sees-results', async () => {
          if (await statusOf(await call('start', 'GET', `${api}/repos/${s.resultsRepo}`)) === 200) add('start-sees-results', false, 'The code for starting builds can also see the results place. It should only be made for the programs\' place. Make a new one, as the guide says.');
          else add('start-sees-results', true, 'It cannot reach the results place, which is right.');
        });
      }
    }

    if (have.results.set) {
      let repo = null;
      await attempt('results-code', async () => { repo = await get('results', `/repos/${s.resultsRepo}`, 'looking for the results place'); add('results-code', true, `The ${WHICH.results} is accepted for ${s.resultsRepo}.`); });
      if (repo) {
        await attempt('results-read', async () => { await get('results', `/repos/${s.resultsRepo}/releases?per_page=1`, 'reading the results'); add('results-read', true, 'It can read what is kept there.'); });
        await attempt('results-write', async () => {
          // A draft is made and removed at once, which shows the code may add and remove files there.
          const made = await ok(await call('results', 'POST', `${api}/repos/${s.resultsRepo}/releases`, { json: { tag_name: `studio-connection-test-${randomBytes(4).toString('hex')}`, name: 'Connection test (safe to delete)', body: 'Made by the Setup Studio to test the connection. It is removed straight away.', draft: true } }), 'results', 'adding to the results place');
          try { await ok(await call('results', 'DELETE', `${api}/repos/${s.resultsRepo}/releases/${Number(made.id)}`), 'results', 'removing the test note'); add('results-write', true, 'It can add and remove files there.'); } catch { add('results-write', false, 'It could add a test note but not remove it. Delete the draft called "Connection test (safe to delete)" in the results place by hand.'); }
        });
        await attempt('results-power', async () => {
          if (await statusOf(await call('results', 'GET', `${api}/repos/${s.sourceRepo}/contents`)) === 200) add('results-power', false, 'The code for keeping the results can also read the programs\' source code. It should only be made for the results place. Make a new one, as the guide says.');
          else add('results-power', true, 'It cannot reach the programs\' source code, which is right.');
        });
      }
    }
    return { ok: checks.every((c) => c.ok !== false), checks };
  }

  // ---- what is stored about the builds of one customer ----------------------------------------------------------------------------------

  const folderOf = (id) => ws.siteBuildsFolder(id);
  const load = (id) => readJson(join(folderOf(id), 'state.json'), { schema: 1, seq: 0, builds: [] });
  const save = (id, st) => writeJson(join(folderOf(id), 'state.json'), { ...st, builds: st.builds.slice(-100) });
  /** Changes one build's record at once (no waiting in between), so two things at a time cannot overwrite each other. */
  function patch(id, n, change) {
    const st = load(id);
    const rec = st.builds.find((b) => b.n === n);
    if (!rec) return null;
    Object.assign(rec, typeof change === 'function' ? change(rec) : change);
    save(id, st);
    return rec;
  }
  const find = (id, n) => load(id).builds.find((b) => b.n === n) ?? null;
  const latest = (st) => [...st.builds].sort((a, b) => b.n - a.n)[0] ?? null;
  const person = (m) => ({ id: m.id, name: m.name, role: m.role });

  function nextNumber(id) {
    const st = load(id);
    const asked = ws.audit({ customer: id, limit: 100_000 }).filter((e) => e.action === 'build.requested' && e.detail.startsWith(`customer-${id}-`)).map((e) => Number(/^customer-.+?-(\d+)(?: |$)/.exec(e.detail)?.[1])).filter(Number.isFinite);
    return Math.max(st.seq ?? 0, ...st.builds.map((b) => b.n), ...asked) + 1;
  }

  // ---- what a build would do, without doing it -------------------------------------------------------------------------------------------

  /** The whole picture for the customer's "Website and app" step: what is wanted, what is built, what would be sent, and what stops a build. Nothing is sent. */
  function plan(id) {
    ws.get(id);   // a customer that does not exist is a plain 404
    const release = ws.releaseNumbers(id).at(-1) ?? null;
    const blockers = [];
    let parts = null;
    if (!release) blockers.push('Approve a setup first. The website and the app are made from an approved release.');
    else { try { parts = ws.releaseParts(id, release); } catch (e) { blockers.push(e.message); } }
    const eco = parts?.intake.ecosystem;
    const wants = parts ? partsWanted(parts.intake) : { website: false, android: false };
    if (parts && !eco.website.wanted && !eco.android.wanted) blockers.push('This customer was not set up to get a website or an Android app. Switch them on in the details, prepare the setup again and have it approved again.');
    if (parts && eco.android.wanted && !eco.website.domain) blockers.push('The Android app opens the customer\'s website, so the details need the website name too. Add it, prepare the setup again and have it approved again.');
    // What the build service would refuse, said now and not after a long build (it checks the same things again): the customer's short name, and for the app the shop's name.
    if (!/^[a-z0-9][a-z0-9-]{0,39}[a-z0-9]$/.test(id)) blockers.push('This customer\'s short name cannot be used for a website or an app (it must be 2 to 41 small letters, digits and hyphens, and not end with a hyphen). Add the customer again with a different name.');
    const partBlocked = { android: null };
    if (parts && wants.android && !/^[^<>&"'\\]{1,40}$/.test(parts.intake.business.name)) partBlocked.android = 'The business\'s name is also the name of the app, so for the app it can have at most 40 letters and none of < > & " \' or a backslash. Change the name in the details, prepare the setup again and have it approved again. The website can still be made.';
    const notes = [];
    if (parts?.logo && parts.logo.ext !== 'png') notes.push(`The logo is a ${parts.logo.ext === 'svg' ? 'SVG' : 'JPEG'} picture. The build service takes a PNG, so the website and the app are made without the logo. To have it in them, use a PNG logo, prepare the setup again and have it approved again.`);
    const st = load(id);
    const good = release ? bestParts(st, release) : {};
    const active = st.builds.find((b) => ACTIVE.has(b.state));
    const need = { website: wants.website && !(good['website-linux'] && good['website-windows']), android: wants.android && !good.android && !partBlocked.android };
    const partList = PARTS.map((p) => {
      const last = [...st.builds].sort((a, b) => b.n - a.n).find((b) => b.release === release && (b.parts ?? []).some((x) => x.id === p.id));
      const lastPart = last?.parts.find((x) => x.id === p.id);
      let state = 'not-wanted';
      if (wants[p.want]) state = good[p.id] ? 'built' : active?.wants?.[p.want] ? 'building' : p.want === 'android' && partBlocked.android ? 'blocked' : lastPart?.status === 'failure' ? 'failed' : 'missing';
      return { id: p.id, words: p.words, state, build: good[p.id]?.build ?? null, trial: good[p.id]?.trial ?? false, message: state === 'failed' ? lastPart.message : state === 'blocked' ? partBlocked.android : '' };
    });
    return { release, parts, wants, need, good, partList, blockers, partBlocked, notes, active: active ? active.n : null };
  }

  // ---- starting a build ---------------------------------------------------------------------------------------------------------------------

  /** The draft release for this build in the results place: made, or the one left by an earlier try that stopped before the build started. 'taken' when the number is used. */
  async function draftFor(tag, s) {
    for (let page = 1; page <= 2; page += 1) {
      const list = await ok(await call('results', 'GET', `${api}/repos/${s.resultsRepo}/releases?per_page=30&page=${page}`), 'results', 'looking in the results place');
      const found = (Array.isArray(list) ? list : []).find((r) => r?.tag_name === tag);
      // A number that is published, or whose draft already holds a report, is a build that finished: it is never used again (the build service refuses it too).
      if (found) { if (!found.draft || (found.assets ?? []).some((a) => a?.name === 'result.json')) throw new BuildError('taken', 'taken'); return found; }
      if (!Array.isArray(list) || list.length < 30) break;
    }
    const res = await call('results', 'POST', `${api}/repos/${s.resultsRepo}/releases`, { json: { tag_name: tag, name: tag, body: 'Made by the NextGenOS Setup Studio. It holds one customer\'s public settings and, when the build has finished, the files it made.', draft: true } });
    if (res.status === 422) throw new BuildError('taken', 'taken');
    return ok(res, 'results', 'adding to the results place', [201]);
  }

  /**
   * A build the Studio stopped waiting for may still be going on at the build service. A second build of the same customer would wait behind it (and a third would be dropped), so
   * another is not started until the earlier one is known to be over.
   */
  async function earlierOver(id, s) {
    const rec = latest(load(id));
    if (!rec || rec.state !== 'stopped' || !rec.releaseId) return;
    const release = await get('results', `/repos/${s.resultsRepo}/releases/${rec.releaseId}`, 'looking at the earlier build');
    if (release?.draft === false) throw new BuildError(`Build ${rec.n} has finished in the meantime. Press "Look again" to bring its files back before starting another.`, 'earlier');
    const going = rec.runId ? (await get('start', `/repos/${s.sourceRepo}/actions/runs/${rec.runId}`, 'looking at the earlier build')).status !== 'completed' : Date.now() - rec.dispatchedAt < 10 * 60_000;
    if (going) throw new BuildError(`Build ${rec.n} is still going on at the build service. Wait for it to finish, or press "Look again".`, 'earlier');
  }

  /**
   * Starts a build for the customer's latest approved release. `which` says what to build ('website', 'android'); by default what is wanted and not yet built (or everything,
   * when all of it is built already). Waits only until the build service has accepted the request; the rest is followed in the background. Returns the customer's status.
   */
  async function start(me, id, { which = null } = {}) {
    if (!can(me, 'build')) throw new BuildError('Your role cannot start builds. Ask a reviewer or an administrator.', 'role', { status: 403 });
    const p = plan(id);
    const why = p.blockers[0] ?? missing() ?? (p.active || starting.has(id) ? 'A build is already running for this customer. Wait for it to finish.' : null);
    if (why) throw new BuildError(why, 'blocked');
    const s = settings();
    const doable = { website: p.wants.website, android: p.wants.android && !p.partBlocked.android };
    let chosen;
    if (Array.isArray(which) && which.length) chosen = { website: which.includes('website') && doable.website, android: which.includes('android') && doable.android };
    else if (p.need.website || p.need.android) chosen = { website: p.need.website, android: p.need.android };
    else chosen = doable;
    if (!chosen.website && !chosen.android) throw new BuildError(p.partBlocked.android && p.wants.android && (!which?.length || which.includes('android')) ? p.partBlocked.android : 'Choose what to build.', 'blocked');
    starting.add(id);
    try {
      await earlierOver(id, s);
      let n = nextNumber(id);
      let release = null;
      let inputs = null;
      for (let tries = 0; tries < 25 && !release; tries += 1) {
        inputs = makeInputs({ customerId: id, n, parts: p.parts, studioVersion, wants: chosen, forbid: secretsNow() });
        try { release = await draftFor(`customer-${id}-${n}`, s); } catch (e) { if (e.code === 'taken') n += 1; else throw e; }
      }
      if (!release) throw new BuildError('The Studio could not find a free build number in the results place.', 'taken');
      const tag = `customer-${id}-${n}`;
      for (const a of release.assets ?? []) if (a?.name === 'inputs.zip') await ok(await call('results', 'DELETE', `${api}/repos/${s.resultsRepo}/releases/assets/${Number(a.id)}`), 'results', 'replacing the settings');
      await ok(await call('results', 'POST', `${uploadBase}/repos/${s.resultsRepo}/releases/${Number(release.id)}/assets?name=inputs.zip`, { body: inputs.zip, headers: { 'content-type': 'application/zip' } }), 'results', 'sending the settings');
      const ref = s.ref || (await get('start', `/repos/${s.sourceRepo}`, 'looking for the programs')).default_branch;
      if (!ref || !REF.test(String(ref))) throw new BuildError('The Studio could not tell which version of the programs to build from. Type it in Settings, "Connect the build service".', 'ref');
      const dispatchedAt = Date.now();
      await ok(await call('start', 'POST', `${api}/repos/${s.sourceRepo}/actions/workflows/${WORKFLOW_FILE}/dispatches`, { json: { ref, inputs: { customer: id, build: String(n), results_repo: s.resultsRepo } } }), 'start', 'starting the build', [204]);

      const rec = {
        n, tag, release: p.release, state: 'running', phase: 'wait', startedAt: new Date(dispatchedAt).toISOString(), startedBy: person(me), dispatchedAt, watchedFrom: dispatchedAt,
        wants: chosen, releaseId: Number(release.id), inputsSha256: sha(inputs.zip), runId: null, jobs: [], problem: '', code: '', trial: false, parts: [], files: [], sourceCommit: null,
      };
      const st = load(id);
      st.builds.push(rec);
      st.seq = n;
      save(id, st);
      const asked = Object.entries(chosen).filter(([, v]) => v).map(([k]) => k).join(' and ');
      ws.log(me, 'build.requested', id, `${tag} from release ${p.release}: ${asked}`);
      follow(me, id, n);
    } finally { starting.delete(id); }
    return status(id, me);
  }

  // ---- watching a build -----------------------------------------------------------------------------------------------------------------------

  function follow(actor, id, n) {
    if (followers.has(id)) return followers.get(id);
    const done = loop(actor, id, n).catch((e) => { if (!closing.signal.aborted) console.error('Studio: following a build stopped:', e?.stack ?? e); }).finally(() => followers.delete(id));
    followers.set(id, done);
    return done;
  }

  async function loop(actor, id, n) {
    let lost = 0;
    for (;;) {
      if (closing.signal.aborted) return;
      const rec = find(id, n);
      if (!rec || !ACTIVE.has(rec.state)) return;
      try {
        if (await tick(actor, id, n)) return;
        lost = 0;
      } catch (e) {
        if (closing.signal.aborted) return;
        if (!(e instanceof BuildError)) { settle(actor, id, n, 'stopped', new BuildError('Something went wrong inside the Studio while it was watching the build. Press "Look again".', 'inside')); console.error('Studio: watching a build:', e?.stack ?? e); return; }
        if (e.kind === 'retry') {
          lost += 1;
          if (lost >= lostContactLimit) { settle(actor, id, n, 'stopped', new BuildError(`The Studio lost contact with the build service (${e.message}) The build may still be going. Press "Look again" when the connection is back.`, 'lost')); return; }
        } else { settle(actor, id, n, e.kind === 'stopped' ? 'stopped' : 'failed', e); return; }
      }
      if (Date.now() - find(id, n).watchedFrom > ceilingMs) { settle(actor, id, n, 'stopped', new BuildError('The build is taking much longer than usual, so the Studio stopped waiting. It may still finish: press "Look again" later.', 'slow')); return; }
      await sleep(pollMs, closing.signal);
    }
  }

  /** The newest run the build service started for this build: by its title when it carries the build's name, otherwise the only new one. */
  async function findRun(rec, s) {
    const since = new Date(rec.dispatchedAt - 120_000).toISOString();
    const list = await get('start', `/repos/${s.sourceRepo}/actions/workflows/${WORKFLOW_FILE}/runs?event=workflow_dispatch&per_page=30&created=${encodeURIComponent('>=' + since)}`, 'looking at the build');
    const runs = (list?.workflow_runs ?? []).filter((r) => Date.parse(r.created_at) >= rec.dispatchedAt - 120_000);
    return runs.find((r) => String(r.display_title ?? r.name ?? '').includes(rec.tag)) ?? (runs.length === 1 ? runs[0] : null);
  }

  /** One look: at the build's steps (the start code), then at the results place (the other code). Returns true when this build has been settled. */
  async function tick(actor, id, n) {
    const s = settings();
    let rec = find(id, n);
    if (!rec.runId) { const run = await findRun(rec, s); if (run) rec = patch(id, n, { runId: Number(run.id) }); }
    let ended = false;
    if (rec.runId) {
      const run = await get('start', `/repos/${s.sourceRepo}/actions/runs/${rec.runId}`, 'looking at the build');
      const jobs = (await get('start', `/repos/${s.sourceRepo}/actions/runs/${rec.runId}/jobs?per_page=100`, 'looking at the build'))?.jobs ?? [];
      ended = run.status === 'completed';
      rec = patch(id, n, { jobs: jobs.slice(0, 60).map((j) => ({ name: clean(j.name, 100), status: j.status, conclusion: j.conclusion ?? null })), runEnded: ended, runConclusion: run.conclusion ?? null });
    }
    const release = await get('results', `/repos/${s.resultsRepo}/releases/${rec.releaseId}`, 'looking for the results');
    if (release?.draft === false) { await fetchResults(actor, id, n, release, s); return true; }
    if (ended) {
      // The build ended but has not published its result. Allow a short while (the last step may still be finishing), then say what stopped.
      const seen = (rec.endedLooks ?? 0) + 1;
      patch(id, n, { endedLooks: seen });
      if (seen >= 3) { settle(actor, id, n, 'failed', new BuildError(describeStop(rec), 'build-stopped')); return true; }
    }
    return false;
  }

  function describeStop(rec) {
    const failed = (rec.jobs ?? []).filter((j) => j.conclusion && !['success', 'skipped', 'neutral'].includes(j.conclusion));
    if (rec.runConclusion === 'cancelled') return 'The build was cancelled before it finished.';
    if (failed.length) return `The build stopped before it finished. This step did not work: ${[...new Set(failed.map((j) => jobWords(j.name)))].join('; ')}. Nothing came back. Check the settings you sent, then try again.`;
    return 'The build stopped before it finished, and nothing came back. Try again; if it happens again, ask NextGenOS.';
  }

  // ---- bringing the files back --------------------------------------------------------------------------------------------------------------

  /** Fetches one file of the results (the code is sent only to the build service; the address it points to next gets none). To a file, or to memory when `into` is null. */
  async function fetchAsset(s, asset, { into = null, maxBytes }) {
    const url = `${api}/repos/${s.resultsRepo}/releases/assets/${Number(asset.id)}`;
    let res = await call('results', 'GET', url, { headers: { accept: 'application/octet-stream' }, timeoutMs: downloadTimeoutMs });
    for (let hops = 0; res.status >= 300 && res.status < 400; hops += 1) {
      let target;
      await res.body?.cancel().catch(() => {});
      try { target = new URL(res.headers.get('location') ?? '', url); } catch { throw new BuildError('The build service sent the Studio somewhere it could not follow, so nothing was downloaded.', 'unsafe'); }
      if (hops >= 3 || !(target.protocol === 'https:' || (local && target.protocol === 'http:' && isLoopback(target.hostname)))) throw new BuildError('The build service sent the Studio to an address that is not safe, so nothing was downloaded.', 'unsafe');
      try { res = await fetchFn(target, { method: 'GET', redirect: 'manual', headers: { accept: 'application/octet-stream', 'user-agent': 'NextGenOS-Setup-Studio' }, signal: AbortSignal.any([AbortSignal.timeout(downloadTimeoutMs), closing.signal]) }); } catch (e) { throw reached(e); }
    }
    if (res.status !== 200) throw await refused(res, 'results', 'fetching a file');
    const hash = createHash('sha256');
    const chunks = [];
    let bytes = 0;
    const meter = new Transform({ transform(chunk, _encoding, next) {
      bytes += chunk.length;
      if (bytes > maxBytes) return next(new BuildError('A file that came back is far bigger than it should be, so it was not kept.', 'too-big'));
      hash.update(chunk);
      return next(null, chunk);
    } });
    const sink = into ? createWriteStream(into) : new Writable({ write(chunk, _encoding, next) { chunks.push(chunk); next(); } });
    try { await pipeline(res.body ? Readable.fromWeb(res.body) : Readable.from([]), meter, sink); } catch (e) { if (into) rmSync(into, { force: true }); throw reached(e); }
    return { bytes, sha256: hash.digest('hex'), buffer: into ? null : Buffer.concat(chunks) };
  }

  async function fetchResults(actor, id, n, release, s) {
    let rec = patch(id, n, { state: 'fetching', phase: 'fetch' });
    const assets = new Map((release.assets ?? []).filter((a) => a && typeof a.name === 'string' && Number.isInteger(a.id) && (!a.state || a.state === 'uploaded')).map((a) => [a.name, a]));
    if (!assets.has('result.json') || !assets.has('SHA256SUMS.txt')) throw new BuildError('The build finished but did not leave its report or its list of fingerprints. Nothing was kept. Try again; if it happens again, ask NextGenOS.', 'no-result');
    const text = async (name) => (await fetchAsset(s, assets.get(name), { maxBytes: MAX_TEXT })).buffer;
    const resultBytes = await text('result.json');
    const result = readResult(resultBytes.toString('utf8'), { customerId: id, n });
    const sumsBytes = await text('SHA256SUMS.txt');
    const sums = readSums(sumsBytes.toString('utf8'));
    if (sums['result.json'] && sums['result.json'] !== sha(resultBytes)) throw new BuildError('The report the build left does not match its fingerprint, so nothing was kept. Press "Look again"; if it happens again, try again.', 'checksum');
    // The build must have worked from what this Studio sent (the list of fingerprints names the settings it was given), and the small marker of a trial must be what was listed.
    if (sums['inputs.zip'] && rec.inputsSha256 && sums['inputs.zip'] !== rec.inputsSha256) throw new BuildError('The settings the build worked from are not the ones the Studio sent, so nothing was kept. Try again; if it happens again, ask NextGenOS.', 'inputs');
    if (assets.has('NO-LICENCE-KEYS-TRIAL-ONLY.txt') && sums['NO-LICENCE-KEYS-TRIAL-ONLY.txt'] && sums['NO-LICENCE-KEYS-TRIAL-ONLY.txt'] !== sha(await text('NO-LICENCE-KEYS-TRIAL-ONLY.txt'))) throw new BuildError('The note that marks a trial build does not match its fingerprint, so nothing was kept. Press "Look again"; if it happens again, try again.', 'checksum');

    // Which parts came out, and which files each needs.
    const wantedParts = PARTS.filter((p) => rec.wants[p.want]);
    const partResults = [];
    const fetchList = [];
    for (const p of wantedParts) {
      const r = result.parts[p.id] ?? { status: 'failure', message: 'The build did not say what happened to this part.' };
      let status = r.status;
      let message = r.message;
      if (status === 'success') {
        const mine = fileRules(id).filter((f) => f.part === p.id).map((f) => ({ ...f, names: [...assets.keys()].filter((name) => f.re.test(name) && sums[name]) }));
        const lacking = mine.find((f) => f.need && f.names.length !== 1);
        if (lacking) { status = 'failure'; message = lacking.names.length > 1 ? 'The build left more than one file for this part, so none was used.' : 'The files for this part were not in the list that came back, so none was used.'; }
        else for (const f of mine) if (f.names.length === 1) fetchList.push({ part: p.id, role: f.role, os: f.os, arch: f.arch, name: f.names[0], asset: assets.get(f.names[0]), sha256: sums[f.names[0]] });
      }
      partResults.push({ id: p.id, status, message });
    }
    const trial = result.trial || assets.has('NO-LICENCE-KEYS-TRIAL-ONLY.txt');

    let files = [];
    let signing = '';
    if (fetchList.length) {
      const folder = folderOf(id);
      mkdirSync(folder, { recursive: true });
      const total = fetchList.reduce((sum, f) => sum + (f.asset.size ?? 0), 0);
      try { const fs = statfsSync(folder); if (fs.bavail * fs.bsize < total * 1.1 + 100_000_000) throw new BuildError(`There is not enough room on this PC for the files that came back (${Math.ceil(total / 1e6)} MB). Free some space and press "Look again".`, 'space', { kind: 'stopped' }); } catch (e) { if (e instanceof BuildError) throw e; /* the space cannot be read here: go on */ }
      const staging = join(folder, `incoming-${n}-${randomBytes(4).toString('hex')}`);
      mkdirSync(staging, { recursive: true });
      try {
        let done = 0;
        for (const f of fetchList) {
          rec = patch(id, n, { fetching: `${done + 1} of ${fetchList.length}` });
          const got = await fetchAsset(s, f.asset, { into: join(staging, f.name), maxBytes: MAX_FILE });
          if (got.sha256 !== f.sha256) throw new BuildError(`The file ${f.name} that came back is not the one the build made: its fingerprint does not match. Nothing was kept. Press "Look again" to fetch it again; if it happens again, try again.`, 'checksum');
          files.push({ part: f.part, role: f.role, os: f.os, ...(f.arch ? { arch: f.arch } : {}), name: f.name, bytes: got.bytes, sha256: got.sha256 });
          done += 1;
        }
        patch(id, n, { phase: 'check' });
        if (assets.has('ANDROID-SIGNING.txt') && files.some((f) => f.part === 'android')) {
          const note = await text('ANDROID-SIGNING.txt');
          if (sums['ANDROID-SIGNING.txt'] && sums['ANDROID-SIGNING.txt'] !== sha(note)) throw new BuildError('The note about how the app was signed does not match its fingerprint, so nothing was kept. Press "Look again"; if it happens again, try again.', 'checksum');
          signing = clean(note.toString('utf8').replace(/^Signed with:\s*/i, ''), 120);
        }
        patch(id, n, { phase: 'place' });
        writeFileSync(join(staging, 'result.json'), resultBytes);
        writeFileSync(join(staging, 'SHA256SUMS.txt'), sumsBytes);
        const final = join(folder, String(n));
        rmSync(final, { recursive: true, force: true });
        renameSync(staging, final);
      } catch (e) { rmSync(staging, { recursive: true, force: true }); throw e; }
    }

    const okParts = partResults.filter((p) => p.status === 'success').length;
    const state = okParts === partResults.length ? 'done' : okParts ? 'partly' : 'failed';
    const problem = state === 'done' ? '' : partResults.filter((p) => p.status !== 'success').map((p) => `${partWords(p.id)} did not work${p.message ? `: ${p.message}` : ''}`).join(' ');
    patch(id, n, { state, phase: 'done', fetching: '', parts: partResults, files, trial, signing, sourceCommit: result.sourceCommit, finishedAt: new Date().toISOString(), problem, code: state === 'failed' ? 'parts' : '' });
    record(actor, id, find(id, n), state === 'done' ? 'build.finished' : state === 'partly' ? 'build.partly' : 'build.failed');
  }

  /** Writes the end of a build in the customer's record and the activity record (the first with the actor's right to build, the second whatever happens). */
  function record(actor, id, rec, action) {
    const parts = (rec.parts ?? []).map((p) => ({ id: p.id, status: p.status }));
    const detail = `${rec.tag}: ${action === 'build.finished' ? 'the files came back' : action === 'build.partly' ? 'some of the files came back' : 'no file came back'}${rec.trial ? ' (a trial build, no licence keys)' : ''}${rec.problem ? `. ${rec.problem}` : ''}`.slice(0, 480);
    try { ws.recordBuild(actor, id, { kind: 'website-app', release: rec.release, build: rec.n, trial: rec.trial, parts, files: (rec.files ?? []).map((f) => f.name) }, { action, detail, keepState: true }); } catch { ws.log(actor, action, id, detail); }
  }

  /** Ends the watching of a build, with the reason in plain words. A build the service could not finish is recorded; one the Studio only stopped waiting for is not. */
  function settle(actor, id, n, state, error) {
    const rec = patch(id, n, { state, problem: error.message, code: error.code, fetching: '', finishedAt: state === 'stopped' ? null : new Date().toISOString() });
    if (!rec) return;
    if (state === 'failed') record(actor, id, rec, 'build.failed');
    else ws.log(actor, 'build.stopped', id, `${rec.tag}: ${error.message}`.slice(0, 480));
  }

  /** Looks again at a build the Studio stopped waiting for (or whose files did not check out): picks up where it left off. */
  function look(me, id) {
    if (!can(me, 'build')) throw new BuildError('Your role cannot start builds. Ask a reviewer or an administrator.', 'role', { status: 403 });
    const rec = latest(load(id));
    const again = rec && rec.releaseId && (rec.state === 'stopped' || (rec.state === 'failed' && rec.code === 'checksum'));
    if (!again) throw new BuildError('There is nothing to look at again.', 'blocked');
    const why = missing();
    if (why) throw new BuildError(why, 'blocked');
    patch(id, rec.n, { state: 'running', problem: '', code: '', watchedFrom: Date.now(), endedLooks: 0, finishedAt: null });
    follow(me, id, rec.n);
    return status(id, me);
  }

  // ---- what the page shows ---------------------------------------------------------------------------------------------------------------

  const PHASES = ['send', 'wait', 'fetch', 'check', 'place', 'done'];
  /** The steps of a build as a person reads them: what is done, what is going on, what is still to come. */
  function stepsOf(rec) {
    const at = PHASES.indexOf(rec.phase);
    const active = ACTIVE.has(rec.state);
    const gotFiles = (rec.files ?? []).length > 0;
    // A row for the Studio's own part of the work: done once it is passed, going on while it is the current one, not reached yet otherwise.
    const own = (phase, words) => {
      if (rec.phase === 'done') return { words, state: gotFiles ? 'done' : 'skipped' };
      const row = PHASES.indexOf(phase);
      return { words, state: at > row ? 'done' : at === row ? (active ? 'working' : 'failed') : 'waiting' };
    };
    const jobs = (rec.jobs ?? []).map((j) => ({ words: jobWords(j.name), state: jobState(j) }));
    const moved = at > PHASES.indexOf('wait');
    const wait = jobs.length ? jobs.map((j) => (moved && j.state === 'working' ? { ...j, state: 'done' } : j))
      : [{ words: rec.runId ? 'The build is starting' : 'Waiting for the build service to start', state: moved ? 'done' : active ? 'working' : 'failed' }];
    return [
      { words: 'Putting the customer\'s settings together', state: 'done' },
      { words: 'Sending them to the build service and asking it to start', state: 'done' },
      ...wait,
      own('fetch', rec.fetching ? `Bringing the files back (${rec.fetching})` : 'Bringing the files back'),
      own('check', 'Checking every file against its fingerprint'),
      own('place', 'Putting the files where the pack looks for them'),
    ];
  }

  function view(rec) {
    return {
      n: rec.n, tag: rec.tag, release: rec.release, state: rec.state, startedAt: rec.startedAt, startedBy: rec.startedBy?.name ?? '', finishedAt: rec.finishedAt ?? null,
      wants: rec.wants, steps: stepsOf(rec), problem: rec.problem, code: rec.code, trial: !!rec.trial, signing: rec.signing ?? '',
      parts: (rec.parts ?? []).map((p) => ({ id: p.id, words: partWords(p.id), status: p.status, message: p.message })), canLook: rec.state === 'stopped' || (rec.state === 'failed' && rec.code === 'checksum'),
    };
  }

  /** Everything the "Website and app" step needs. Opening it with the right to build also picks up a build that was going when the Studio was closed. */
  function status(id, me) {
    const p = plan(id);
    const st = load(id);
    const last = latest(st);
    if (me && can(me, 'build') && last && ACTIVE.has(last.state) && !followers.has(id) && !starting.has(id) && last.releaseId) { patch(id, last.n, { watchedFrom: Date.now() }); follow(me, id, last.n); }
    const inputs = p.parts ? (() => { try { const made = makeInputs({ customerId: id, n: 0, parts: p.parts, studioVersion, wants: p.wants, forbid: secretsNow() }); return { problem: '', files: made.entries, brand: made.brand, settings: made.settings }; } catch (e) { if (e instanceof BuildError) return { problem: e.message, files: [], brand: '', settings: '' }; throw e; } })() : null;
    const problems = [...p.blockers, ...(inputs?.problem ? [inputs.problem] : [])];
    const doable = p.wants.website || (p.wants.android && !p.partBlocked.android);
    const why = problems[0] ?? missing() ?? (doable ? null : p.partBlocked.android);
    return {
      service: connection(), release: p.release, wants: p.wants, need: p.need, parts: p.partList, blockers: problems, notes: p.notes, canStart: !why && !p.active && !starting.has(id), why: why ?? (p.active ? 'A build is already running for this customer.' : null),
      inputs, current: last ? view(last) : null, builds: [...st.builds].sort((a, b) => b.n - a.n).slice(0, 12).map(view),
    };
  }

  return { connection, saveNames, testConnection, plan, status, start, look, followers, close: () => closing.abort(), settings };
}
