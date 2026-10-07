// A stand-in for the build service, on this PC, for the Studio's tests. It speaks only the few things the Studio uses: reading a repository and a build, starting a build, the
// draft release that holds a customer's settings and the files that come back, and the redirect to where a file is kept. It also plays the build itself, step by step, so the
// Studio can be tried against every ending: it works, a part fails, it is only a trial, the access code is wrong, the network drops, it takes too long, a file is damaged.
//
// Nothing here is the real service. What the real one does with the owner's repositories and access codes is NOT verified by these tests (docs/SETUP-STUDIO.md says so).
import http from 'node:http';
import { createHash } from 'node:crypto';
import { inflateRawSync } from 'node:zlib';

export const sha256 = (data) => createHash('sha256').update(data).digest('hex');
const wait = (ms) => new Promise((done) => setTimeout(done, ms));

/** Every file of a zip, as a Map of name to bytes (only stored and deflated entries, which is all the Studio writes). */
export function readZipFiles(buffer) {
  const end = buffer.lastIndexOf(Buffer.from([0x50, 0x4b, 0x05, 0x06]));
  const count = buffer.readUInt16LE(end + 10);
  let at = buffer.readUInt32LE(end + 16);
  const out = new Map();
  for (let i = 0; i < count; i += 1) {
    const method = buffer.readUInt16LE(at + 10), csize = buffer.readUInt32LE(at + 20), n = buffer.readUInt16LE(at + 28), m = buffer.readUInt16LE(at + 30), k = buffer.readUInt16LE(at + 32), local = buffer.readUInt32LE(at + 42);
    const name = buffer.toString('utf8', at + 46, at + 46 + n);
    const dataAt = local + 30 + buffer.readUInt16LE(local + 26) + buffer.readUInt16LE(local + 28);
    const body = buffer.subarray(dataAt, dataAt + csize);
    out.set(name, method === 8 ? inflateRawSync(body) : Buffer.from(body));
    at += 46 + n + m + k;
  }
  return out;
}

/**
 * Starts the stand-in. `source` and `results` are the two repository names; `tokens` are the two access codes it accepts. `stepMs` is how long each step of the pretend build takes.
 * Returns { url, close, options, seen, releases, runs, ... }; change `options` while it runs to change what it does next.
 */
export async function standInGitHub({ source = 'acme/programs', results = 'acme/customer-builds', tokens = { start: 'test-start-access-code-0001', results: 'test-results-access-code-0002' }, stepMs = 15 } = {}) {
  const options = {
    outcome: 'success',            // success | partly | trial | all-fail | run-fails (the run dies before it publishes) | no-result (published with no report)
                                   // | never-started (GitHub gives the run no machine, as when the account's minutes or spending limit are used up) | settings-not-taken (the first job cannot read the settings: the results key is missing)
    tamper: false,                 // serve a changed file, so it no longer matches its fingerprint
    holdPublish: false,            // the build keeps working and does not publish until this is false again
    startCanReadContents: false, resultsCanReadContents: false, startSeesResults: false, resultsReadOnly: false, startCannotDispatch: false, noWorkflow: false, workflowDisabled: false,
    runTitles: true,               // the run carries the build's name in its title
    directDownload: false,         // serve a file at once instead of redirecting to where it is kept
    dropNext: 0,                   // the next requests are cut off with no answer
    hangNext: 0,                   // the next requests are never answered
    fail: [],                      // [{ match: /path/, status: 500, times: 2 }]: answer an error to the next such requests
    redirectTo: null,              // send file requests to this address instead of the stand-in's own storage
    wrongInputsSum: false,         // the list of fingerprints names settings other than the ones that were sent
  };
  const seen = [];
  const releases = new Map();
  const runs = [];
  const storageSeen = [];
  let closed = false;
  let nextId = 1000;
  const id = () => (nextId += 1);
  const who = (req) => {
    const m = /^Bearer (.+)$/.exec(req.headers.authorization ?? '');
    if (!m) return 'none';
    return m[1] === tokens.start ? 'start' : m[1] === tokens.results ? 'results' : 'wrong';
  };
  const releaseView = (r) => ({ id: r.id, tag_name: r.tag_name, name: r.name, draft: r.draft, assets: r.assets.map((a) => ({ id: a.id, name: a.name, size: a.bytes.length, state: 'uploaded' })), upload_url: `${server.url}/repos/${results}/releases/${r.id}/assets{?name,label}` });
  const runView = (r) => ({ id: r.id, status: r.status, conclusion: r.conclusion, created_at: r.created_at, display_title: options.runTitles ? r.title : 'Build customer website and app', name: 'Build a customer', event: 'workflow_dispatch' });

  /** What the real build refuses in the bundle of settings (see docs/CUSTOMER-BUILDS.md on the workflow side): a file that is not one of four, a number that is not a number, a part without its file. */
  function refusal(zip, request, inputs) {
    for (const name of zip.keys()) if (!['build.json', 'brand.json', 'website-settings.env', 'logo.png'].includes(name)) return `it holds a file called "${name}", which is not one of the files the Setup Studio sends`;
    if (request.schema !== 1 || request.customer !== inputs.customer) return 'build.json is for another customer';
    if (typeof request.build !== 'number' || request.build !== Number(inputs.build)) return 'build.json is for another build number';
    if (typeof request.parts?.website !== 'boolean' || typeof request.parts?.android !== 'boolean' || !(request.parts.website || request.parts.android) || Object.keys(request.parts).length !== 2) return 'build.json does not say which parts to build';
    if (request.studioVersion !== undefined && !/^[A-Za-z0-9 ._+-]{1,40}$/.test(String(request.studioVersion))) return 'build.json names a Setup Studio version that is not written plainly';
    if (request.parts.website && !zip.has('website-settings.env')) return 'website-settings.env is missing';
    if (zip.has('logo.png') && !zip.get('logo.png').subarray(0, 8).equals(Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]))) return 'logo.png is not a PNG picture';
    if (zip.has('brand.json')) {
      const brand = JSON.parse(zip.get('brand.json').toString('utf8'));
      if (brand.logo && !zip.has(brand.logo)) return `the logo file ${brand.logo} is not in the kit folder`;
      if (request.parts.android) {
        if (!brand.android?.appId || !brand.android?.storefrontUrl || !brand.primaryColor) return 'brand.json has no application id, website address or main colour for the app';
        if (!/^[^<>&"'\\]{1,40}$/.test(brand.name ?? '')) return 'the business\'s name cannot be the name of the app';
      }
    } else if (request.parts.android) return 'brand.json is missing';
    return null;
  }

  /** The pretend build: reads the settings that were sent, runs its steps, and (unless it is made to fail) publishes the release with the files and the report. */
  async function play(run, release) {
    const zip = readZipFiles(release.assets.find((a) => a.name === 'inputs.zip').bytes);
    const request = JSON.parse(zip.get('build.json').toString('utf8'));
    const refused = refusal(zip, request, run.inputs);
    const { customer, build } = request;
    const parts = { 'website-linux': request.parts.website, 'website-windows': request.parts.website, android: request.parts.android };
    const job = (name) => ({ name, status: 'queued', conclusion: null });
    run.jobs = [job("Reading the customer's settings"), ...(request.parts.website ? [job('Building the website for Linux'), job('Building the website for Windows')] : []), ...(request.parts.android ? [job('Building the Android app')] : []), job('Writing the result and publishing it')];
    if (options.outcome === 'never-started') {
      // No machine was ever given: every job fails in a moment, with no runner and no steps, and the run ends at once.
      for (const j of run.jobs) { j.status = 'completed'; j.conclusion = 'failure'; j.runner_id = 0; j.steps = []; }
      run.status = 'completed'; run.conclusion = 'failure';
      return;
    }
    await wait(stepMs);
    run.status = 'in_progress';
    run.jobs[0].status = 'in_progress';
    await wait(stepMs);
    if (options.outcome === 'settings-not-taken') {
      run.jobs[0].status = 'completed'; run.jobs[0].conclusion = 'failure'; run.jobs[0].runner_id = 7;
      run.jobs[0].steps = [{ name: 'Set up job', conclusion: 'success' }, { name: 'Take the settings from the results place', conclusion: 'failure' }];
      for (const j of run.jobs.slice(1)) { j.status = 'completed'; j.conclusion = 'skipped'; }
      run.status = 'completed'; run.conclusion = 'failure';
      return;
    }
    if (options.outcome === 'run-fails') {
      run.jobs[0].status = 'completed'; run.jobs[0].conclusion = 'failure';
      for (const j of run.jobs.slice(1)) { j.status = 'completed'; j.conclusion = 'skipped'; }
      run.status = 'completed'; run.conclusion = 'failure';
      return;
    }
    run.jobs[0].status = 'completed'; run.jobs[0].conclusion = 'success';
    for (const j of run.jobs.slice(1, -1)) j.status = 'in_progress';
    await wait(stepMs);
    while (options.holdPublish && !closed) await wait(10);
    if (closed) return;
    for (const j of run.jobs.slice(1, -1)) { j.status = 'completed'; j.conclusion = 'success'; }
    const last = run.jobs.at(-1);
    last.status = 'in_progress';
    await wait(stepMs);

    const failed = new Set(refused || options.outcome === 'all-fail' ? Object.keys(parts) : options.outcome === 'partly' ? ['website-windows'] : []);
    const files = new Map();
    const report = { schema: 1, customer, build, trial: options.outcome === 'trial', sourceCommit: 'abc1234def5678', startedAt: new Date(run.startedMs).toISOString(), finishedAt: new Date().toISOString(), parts: {} };
    for (const [part, wanted] of Object.entries(parts)) {
      if (!wanted) { report.parts[part] = { status: 'skipped', message: 'Not asked for.' }; continue; }
      if (failed.has(part)) { report.parts[part] = { status: 'failure', message: refused ? `The files the Setup Studio sent were not accepted. ${refused}.` : part === 'website-windows' && options.outcome === 'partly' ? 'The Windows website would not start on the test machine.' : 'The build could not finish this part.' }; continue; }
      report.parts[part] = { status: 'success', message: 'Built.' };
      if (part === 'website-linux') files.set(`website-${customer}-linux.zip`, Buffer.from(`pretend Linux website for ${customer}, build ${build}`.repeat(50)));
      if (part === 'website-windows') files.set(`website-${customer}-windows.zip`, Buffer.from(`pretend Windows website for ${customer}, build ${build}`.repeat(60)));
      if (part === 'android') { files.set(`SmartRetailPOS-${customer}-1.0.${build}.apk`, Buffer.from(`pretend app for ${customer}`.repeat(80))); files.set(`SmartRetailPOS-${customer}-1.0.${build}.aab`, Buffer.from(`pretend store file for ${customer}`.repeat(70))); files.set('ANDROID-SIGNING.txt', Buffer.from('Signed with: a one-off test key\n')); }
    }
    if (options.outcome === 'trial') files.set('NO-LICENCE-KEYS-TRIAL-ONLY.txt', Buffer.from('This build has no licence keys.\n'));
    for (const [name, bytes] of files) release.assets.push({ id: id(), name, bytes });
    if (options.outcome !== 'no-result') {
      const text = Buffer.from(JSON.stringify(report, null, 2) + '\n');
      release.assets.push({ id: id(), name: 'result.json', bytes: text });
      files.set('result.json', text);
    }
    // the list of fingerprints (result.json is listed too, as a real list may list it)
    // the list of fingerprints names every file on the release except itself, the settings that were sent included
    const listed = new Map([...files, ['inputs.zip', options.wrongInputsSum ? Buffer.from('some other settings') : release.assets.find((a) => a.name === 'inputs.zip').bytes]]);
    const sums = [...listed].map(([name, bytes]) => `${sha256(bytes)}  ${name}`).join('\n') + '\n';
    release.assets.push({ id: id(), name: 'SHA256SUMS.txt', bytes: Buffer.from(sums) });
    release.draft = false;
    last.status = 'completed'; last.conclusion = 'success';
    run.status = 'completed'; run.conclusion = 'success';
  }

  const routes = [];
  const route = (method, pattern, handler) => routes.push({ method, re: new RegExp('^' + pattern.replace(/:([a-z]+)/g, '([^/]+)') + '$'), handler });
  const json = (res, status, body) => { res.writeHead(status, { 'content-type': 'application/json' }); res.end(body === undefined ? '' : JSON.stringify(body)); };
  const S = `/repos/${source}`;
  const R = `/repos/${results}`;
  const need = (res, ok, status = 404) => { if (!ok) { json(res, status, { message: status === 403 ? 'Resource not accessible by personal access token' : 'Not Found' }); return false; } return true; };

  route('GET', `${S}`, ({ res, who: w }) => { if (need(res, w === 'start')) json(res, 200, { full_name: source, default_branch: 'main', private: true }); });
  route('GET', `${S}/contents`, ({ res, who: w }) => { if (w === 'start' && options.startCanReadContents || w === 'results' && options.resultsCanReadContents) json(res, 200, [{ name: 'README.md' }]); else json(res, w === 'start' ? 403 : 404, { message: 'Resource not accessible by personal access token' }); });
  route('GET', `${S}/actions/workflows/build-customer.yml`, ({ res, who: w }) => { if (need(res, w === 'start' && !options.noWorkflow)) json(res, 200, { id: 7, path: '.github/workflows/build-customer.yml', state: options.workflowDisabled ? 'disabled_manually' : 'active' }); });
  route('POST', `${S}/actions/workflows/build-customer.yml/dispatches`, ({ res, who: w, body }) => {
    if (!need(res, w === 'start')) return;
    if (options.startCannotDispatch) { json(res, 403, { message: 'Resource not accessible by personal access token' }); return; }
    if (body?.ref !== 'main' && body?.ref !== 'release-line') { json(res, 422, { message: `No ref found for: ${body?.ref}` }); return; }
    const inputs = body.inputs ?? {};
    if (!inputs.customer || !inputs.build || !inputs.results_repo) { json(res, 422, { message: 'Required input not provided' }); return; }
    const release = [...releases.values()].find((r) => r.tag_name === `customer-${inputs.customer}-${inputs.build}`);
    if (!release || inputs.results_repo !== results) { json(res, 422, { message: 'The inputs do not name a build in the results place' }); return; }
    const run = { id: id(), status: 'queued', conclusion: null, created_at: new Date().toISOString(), startedMs: Date.now(), title: `customer-${inputs.customer}-${inputs.build}`, jobs: [], inputs };
    runs.push(run);
    play(run, release).catch((e) => console.error('stand-in build:', e));
    json(res, 204);
  });
  route('GET', `${S}/actions/workflows/build-customer.yml/runs`, ({ res, who: w }) => { if (need(res, w === 'start')) json(res, 200, { total_count: runs.length, workflow_runs: [...runs].reverse().map(runView) }); });
  route('GET', `${S}/actions/runs/:id`, ({ res, who: w, m }) => { const r = runs.find((x) => x.id === Number(m[1])); if (need(res, w === 'start' && r)) json(res, 200, runView(r)); });
  route('GET', `${S}/actions/runs/:id/jobs`, ({ res, who: w, m }) => { const r = runs.find((x) => x.id === Number(m[1])); if (need(res, w === 'start' && r)) json(res, 200, { total_count: r.jobs.length, jobs: r.jobs.map((j, i) => ({ id: i + 1, ...j })) }); });

  route('GET', `${R}`, ({ res, who: w }) => { if (need(res, w === 'results' || (w === 'start' && options.startSeesResults))) json(res, 200, { full_name: results, default_branch: 'main', private: true }); });
  route('GET', `${R}/releases`, ({ res, who: w, url }) => {
    if (!need(res, w === 'results')) return;
    const per = Number(url.searchParams.get('per_page') ?? 30), page = Number(url.searchParams.get('page') ?? 1);
    json(res, 200, [...releases.values()].reverse().slice((page - 1) * per, page * per).map(releaseView));
  });
  route('POST', `${R}/releases`, ({ res, who: w, body }) => {
    if (!need(res, w === 'results')) return;
    if (options.resultsReadOnly) { json(res, 403, { message: 'Resource not accessible by personal access token' }); return; }
    if ([...releases.values()].some((r) => r.tag_name === body.tag_name && !r.draft)) { json(res, 422, { message: 'Validation Failed', errors: [{ code: 'already_exists', field: 'tag_name' }] }); return; }
    const r = { id: id(), tag_name: String(body.tag_name), name: String(body.name ?? ''), draft: body.draft !== false, assets: [] };
    releases.set(r.id, r);
    json(res, 201, releaseView(r));
  });
  route('GET', `${R}/releases/:id`, ({ res, who: w, m }) => { const r = releases.get(Number(m[1])); if (need(res, w === 'results' && r)) json(res, 200, releaseView(r)); });
  route('DELETE', `${R}/releases/:id`, ({ res, who: w, m }) => {
    if (!need(res, w === 'results')) return;
    if (options.resultsReadOnly) { json(res, 403, { message: 'Resource not accessible by personal access token' }); return; }
    releases.delete(Number(m[1])); json(res, 204);
  });
  route('DELETE', `${R}/releases/assets/:id`, ({ res, who: w, m }) => {
    if (!need(res, w === 'results')) return;
    for (const r of releases.values()) r.assets = r.assets.filter((a) => a.id !== Number(m[1]));
    json(res, 204);
  });
  route('POST', `${R}/releases/:id/assets`, ({ res, who: w, m, url, raw }) => {
    const r = releases.get(Number(m[1]));
    if (!need(res, w === 'results' && r)) return;
    const name = url.searchParams.get('name');
    if (r.assets.some((a) => a.name === name)) { json(res, 422, { message: 'Validation Failed', errors: [{ code: 'already_exists', field: 'name' }] }); return; }
    const a = { id: id(), name, bytes: raw };
    r.assets.push(a);
    json(res, 201, { id: a.id, name, size: raw.length, state: 'uploaded' });
  });
  route('GET', `${R}/releases/assets/:id`, ({ res, who: w, m }) => {
    if (!need(res, w === 'results')) return;
    const found = [...releases.values()].flatMap((r) => r.assets).find((a) => a.id === Number(m[1]));
    if (!found) { json(res, 404, { message: 'Not Found' }); return; }
    if (options.directDownload) { res.writeHead(200, { 'content-type': 'application/octet-stream' }); res.end(found.bytes); return; }
    res.writeHead(302, { location: options.redirectTo ? `${options.redirectTo}/__storage/${found.id}` : `${server.url}/__storage/${found.id}?signature=abc` });
    res.end();
  });
  route('GET', '/__storage/:id', ({ res, m, req }) => {
    storageSeen.push({ authorization: req.headers.authorization ?? null, path: req.url });
    const found = [...releases.values()].flatMap((r) => r.assets).find((a) => a.id === Number(m[1]));
    if (!found) { json(res, 404, { message: 'Not Found' }); return; }
    const bytes = options.tamper && /\.(apk|zip)$/.test(found.name) ? Buffer.concat([found.bytes.subarray(0, found.bytes.length - 1), Buffer.from('X')]) : found.bytes;
    res.writeHead(200, { 'content-type': 'application/octet-stream', 'content-length': bytes.length });
    res.end(bytes);
  });

  const server = http.createServer((req, res) => {
    const chunks = [];
    req.on('data', (c) => chunks.push(c)).on('end', () => {
      const url = new URL(req.url, 'http://127.0.0.1');
      const raw = Buffer.concat(chunks);
      const w = who(req);
      seen.push({ method: req.method, path: url.pathname + url.search, who: w, authorization: req.headers.authorization ?? null, body: /json|text/.test(req.headers['content-type'] ?? '') ? raw.toString('utf8') : null, size: raw.length, contentType: req.headers['content-type'] ?? null });
      if (options.dropNext > 0 && !url.pathname.startsWith('/__storage')) { options.dropNext -= 1; req.socket.destroy(); return; }
      if (options.hangNext > 0 && !url.pathname.startsWith('/__storage')) { options.hangNext -= 1; return; }
      const failing = options.fail.find((f) => f.times > 0 && f.match.test(url.pathname));
      if (failing) { failing.times -= 1; json(res, failing.status, { message: 'Injected failure' }); return; }
      if (!url.pathname.startsWith('/__storage') && w === 'wrong') { json(res, 401, { message: 'Bad credentials' }); return; }
      if (!url.pathname.startsWith('/__storage') && w === 'none') { json(res, 401, { message: 'Requires authentication' }); return; }
      let body = null;
      if ((req.headers['content-type'] ?? '').includes('json') && raw.length) { try { body = JSON.parse(raw.toString('utf8')); } catch { json(res, 400, { message: 'Problems parsing JSON' }); return; } }
      const found = routes.find((r) => r.method === req.method && r.re.test(url.pathname));
      if (!found) { json(res, 404, { message: 'Not Found' }); return; }
      found.handler({ req, res, url, who: w, body, raw, m: found.re.exec(url.pathname) });
    });
  });
  await new Promise((done) => server.listen(0, '127.0.0.1', done));
  server.url = `http://127.0.0.1:${server.address().port}`;
  return {
    url: server.url, options, seen, runs, storageSeen, tokens, source, results,
    releases: () => [...releases.values()],
    release: (tag) => [...releases.values()].find((r) => r.tag_name === tag) ?? null,
    asset: (tag, name) => [...releases.values()].find((r) => r.tag_name === tag)?.assets.find((a) => a.name === name)?.bytes ?? null,
    close: () => new Promise((done) => { closed = true; server.close(() => done()); server.closeAllConnections?.(); }),
  };
}
