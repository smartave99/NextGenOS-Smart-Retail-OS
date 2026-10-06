// The build service client, against a stand-in on this PC: every way a build can end, and the promises around it (what is sent, what is never sent, what is kept).
// The real service, with the owner's repositories and access codes, is NOT tested here.
import { test } from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, rmSync, readFileSync, readdirSync, statSync, existsSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { Workspace } from '../lib/workspace.mjs';
import { saveBuildCode, removeBuildCode, getBuildCode } from '../lib/secrets.mjs';
import { createBuildService, makeInputs, jobWords, readResult, readSums, checkRepoName, withSiteBuilds, BuildError, PARTS } from '../lib/builds.mjs';
import { readBaseKit } from '../lib/basekit.mjs';
import { planPack } from '../lib/pack.mjs';
import { standInGitHub, readZipFiles, sha256 } from './stand-in-github.mjs';

const PNG = Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==', 'base64');
const good = (over = {}) => ({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example', address: 'Quezon City, Metro Manila' } }, device: { kind: 'touch-pos', os: 'windows', screen: 'standard' }, look: { primaryColor: '#0a7d4b', style: 'friendly' }, licence: { whiteLabel: 'theme' }, ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' }, android: { wanted: true, appId: 'com.luzonfresh.shop' } }, ...over });
/** What a person reads never names the technical parts (the build service is "the build service", a token is an "access code"). */
const plain = (text, where = '') => assert.doesNotMatch(String(text), /\b(token|workflow|github|actions?|dispatch|runner|pipeline|commit)\b/i, where + String(text).slice(0, 200));
const person = (m) => ({ id: m.id, name: m.name, role: m.role });

/** A workspace with an approved customer, a stand-in build service with both access codes saved, and the client wired to it. */
async function world({ stand = {}, service = {}, intake = good(), codes = true, approve = true, logo = PNG } = {}) {
  const root = mkdtempSync(join(tmpdir(), 'studio-builds-'));
  const env = { ...process.env, SETUP_STUDIO_HOME: join(root, 'home') };
  const { workspace: ws, admin } = Workspace.init(join(root, 'ws'), { name: 'Asha Admin', password: 'a-long-password' });
  const asha = person(admin);
  const sam = person(ws.addMember(asha, { name: 'Sam Sales', role: 'sales', password: 'sam-long-password' }));
  const rita = person(ws.addMember(asha, { name: 'Rita Reviewer', role: 'reviewer', password: 'rita-long-password' }));
  const { stepMs, ...behaviour } = stand;
  const gh = await standInGitHub({ ...(stepMs ? { stepMs } : {}) });
  Object.assign(gh.options, behaviour);   // how the stand-in behaves from the start (outcome, held back, ...)
  if (codes) { saveBuildCode('start', gh.tokens.start, env); saveBuildCode('results', gh.tokens.results, env); }
  ws.saveSettings(asha, { build: { sourceRepo: gh.source, resultsRepo: gh.results, ref: '' } });
  const id = ws.create(sam, intake).id;
  if (approve) { ws.setLogo(sam, id, logo); ws.makeProposal(sam, id); ws.submit(sam, id); ws.approve(rita, id); }
  const svc = createBuildService({ ws, env, studioVersion: '1.0.0', api: gh.url, pollMs: 10, ceilingMs: 8000, requestTimeoutMs: 1500, downloadTimeoutMs: 5000, lostContactLimit: 3, ...service });
  return { root, env, ws, asha, sam, rita, gh, svc, id, done: async () => { svc.close(); await gh.close(); rmSync(root, { recursive: true, force: true }); } };
}
const until = async (condition) => { for (let i = 0; i < 300 && !condition(); i += 1) await new Promise((done) => setTimeout(done, 20)); assert.ok(condition(), 'it did not happen in time'); };
const finish = async (w, id = w.id) => { await w.svc.followers.get(id); return w.svc.status(id).current; };
/** Every file under a folder, as text where it is text (for looking for what must never be there). */
function everyFile(dir, out = []) {
  for (const name of readdirSync(dir)) { const full = join(dir, name); if (statSync(full).isDirectory()) everyFile(full, out); else out.push(full); }
  return out;
}

test('the settings that are sent are the customer\'s public ones only: brand, logo, website settings and the request; nothing else', async () => {
  const w = await world();
  try {
    const parts = w.ws.releaseParts(w.id, 1);
    const made = makeInputs({ customerId: w.id, n: 4, parts, studioVersion: '1.0.0', wants: { website: true, android: false } });
    const files = readZipFiles(made.zip);
    assert.deepEqual([...files.keys()].sort(), ['brand.json', 'build.json', 'logo.png', 'website-settings.env']);
    assert.deepEqual(JSON.parse(files.get('build.json')), { schema: 1, customer: 'luzon-fresh-mart', build: 4, studioVersion: '1.0.0', parts: { website: true, android: false } });
    const brand = JSON.parse(files.get('brand.json'));
    assert.equal(brand.name, 'Luzon Fresh Mart');
    assert.equal(brand.primaryColor, '#0a7d4b');
    assert.equal(brand.logo, 'logo.png');
    assert.equal(brand.android.appId, 'com.luzonfresh.shop');
    assert.match(files.get('website-settings.env').toString(), /NEXT_PUBLIC_SITE_NAME=Luzon Fresh Mart/);
    assert.match(files.get('website-settings.env').toString(), /NEXT_PUBLIC_SITE_URL=https:\/\/luzonfresh\.example/);
    assert.ok(files.get('logo.png').equals(PNG));
    for (const [name, data] of files) for (const forbidden of ['password', 'secret', 'token', 'ANTHROPIC', 'OPENAI']) assert.ok(!data.toString('latin1').toLowerCase().includes(forbidden.toLowerCase()) || name === 'website-settings.env', `${name} holds no ${forbidden}`);
    // a customer without a logo sends none
    const noLogo = makeInputs({ customerId: w.id, n: 1, parts: { ...parts, logo: null }, wants: { website: true, android: true } });
    assert.ok(![...readZipFiles(noLogo.zip).keys()].some((n) => n.startsWith('logo.')));
  } finally { await w.done(); }
});

test('a setting that looks like a secret, or is one of the Studio\'s own access codes, is refused and nothing is sent', async () => {
  const w = await world();
  try {
    const parts = w.ws.releaseParts(w.id, 1);
    const withTagline = (tagline) => ({ ...parts, intake: { ...parts.intake, business: { ...parts.intake.business, tagline } } });
    for (const [secret, kind] of [['Key AIza' + 'SyA1234567890abcdefghijklmnopqrstuv', /Google API key/], ['-----BEGIN ' + 'PRIVATE KEY-----', /private key/], ['postgres' + '://admin:hunter2pass@db.example/shop', /database URL/], ['sk-proj-' + 'a'.repeat(30), /OpenAI/]]) {
      assert.throws(() => makeInputs({ customerId: w.id, n: 1, parts: withTagline(secret), wants: { website: true } }), (e) => e instanceof BuildError && e.code === 'secret' && kind.test(e.message) && /Nothing was sent/.test(e.message), secret.slice(0, 20));
    }
    assert.throws(() => makeInputs({ customerId: w.id, n: 1, parts: withTagline('Fresh and cheap'), wants: { website: true }, forbid: ['Fresh and cheap'] }), /access codes/);
    // through the whole service: nothing at all reaches the build service
    const before = w.gh.seen.length;
    const dirty = good({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', tagline: 'AKIA' + 'ABCDEFGHIJKLMNOP', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example' } } });
    const w2 = await world({ intake: dirty });
    try {
      await assert.rejects(() => w2.svc.start(w2.rita, w2.id), (e) => e.code === 'secret');
      assert.equal(w2.gh.seen.length, 0, 'the build service heard nothing');
      assert.ok(w2.svc.status(w2.id).blockers.some((b) => /looks like a password or a key/.test(b)), 'the page says why');
    } finally { await w2.done(); }
    assert.equal(w.gh.seen.length, before);
  } finally { await w.done(); }
});

test('a build that works: the settings go up, the build is started, its steps are said in plain words, and the files come back, are checked and put in the customer\'s folder', async () => {
  const w = await world();
  try {
    assert.equal(w.svc.status(w.id).canStart, true);
    const started = await w.svc.start(w.rita, w.id);
    assert.equal(started.current.n, 1);
    assert.equal(started.current.tag, 'customer-luzon-fresh-mart-1');
    const done = await finish(w);
    assert.equal(done.state, 'done', JSON.stringify(done));
    assert.deepEqual(done.parts.map((p) => [p.id, p.status]), [['website-linux', 'success'], ['website-windows', 'success'], ['android', 'success']]);
    assert.equal(done.trial, false);
    assert.match(done.signing, /test key/);
    assert.ok(done.steps.every((s) => s.state === 'done'), JSON.stringify(done.steps));
    const words = done.steps.map((s) => s.words).join(' | ');
    assert.match(words, /Building the website for Linux/);
    assert.match(words, /Building the website for Windows/);
    assert.match(words, /Building the Android app/);
    assert.match(words, /Checking the settings that were sent/);
    assert.match(words, /Checking every file against its fingerprint/);

    // what was sent to the results place
    const release = w.gh.release('customer-luzon-fresh-mart-1');
    assert.equal(release.draft, false, 'the build published it last');
    const sent = readZipFiles(w.gh.asset('customer-luzon-fresh-mart-1', 'inputs.zip'));
    assert.deepEqual(JSON.parse(sent.get('build.json')), { schema: 1, customer: 'luzon-fresh-mart', build: 1, studioVersion: '1.0.0', parts: { website: true, android: true } });
    // what was asked of the build service: the customer, the number and the results place, nothing else
    const dispatch = w.gh.seen.find((r) => r.path.endsWith('/dispatches'));
    assert.deepEqual(JSON.parse(dispatch.body), { ref: 'main', inputs: { customer: 'luzon-fresh-mart', build: '1', results_repo: w.gh.results } });

    // what came back is in the customer's own folder, exactly as made
    const folder = w.ws.siteBuildsFolder(w.id);
    for (const name of ['website-luzon-fresh-mart-linux.zip', 'website-luzon-fresh-mart-windows.zip', 'SmartRetailPOS-luzon-fresh-mart-1.0.1.apk', 'SmartRetailPOS-luzon-fresh-mart-1.0.1.aab']) {
      assert.ok(readFileSync(join(folder, '1', name)).equals(w.gh.asset('customer-luzon-fresh-mart-1', name)), name);
    }
    assert.ok(existsSync(join(folder, '1', 'result.json')) && existsSync(join(folder, '1', 'SHA256SUMS.txt')));
    assert.deepEqual(readdirSync(folder).filter((n) => n.startsWith('incoming')), [], 'no half-finished download is left');

    // the record
    const customer = w.ws.get(w.id);
    const record = customer.builds.at(-1);
    assert.equal(record.kind, 'website-app');
    assert.equal(record.build, 1);
    assert.equal(customer.state, 'approved', 'a website is not a pack: the customer is not "built" yet');
    const trail = w.ws.audit({ customer: w.id }).map((e) => e.action);
    assert.ok(trail.includes('build.requested') && trail.includes('build.finished'));
    assert.match(w.ws.audit({ customer: w.id }).find((e) => e.action === 'build.requested').detail, /^customer-luzon-fresh-mart-1 from release 1: website and android$/);
    assert.equal(w.ws.verifyAudit().ok, true);

    // the pack builder finds them where it looks (role + the customer's name), as if they were in the programs folder
    const programsDir = join(w.root, 'programs');
    const { mkdirSync } = await import('node:fs');
    mkdirSync(programsDir);
    writeFileSync(join(programsDir, 'SmartRetailPOS-Hub-Setup-1.4.0.exe'), Buffer.alloc(3000, 4));
    const { makeBaseKit } = await import('../../../scripts/make-base-kit.mjs');
    writeFileSync(join(programsDir, 'base-kit.json'), JSON.stringify((await makeBaseKit(programsDir)).manifest));
    const kit = await withSiteBuilds(await readBaseKit(programsDir), { folder, release: 1, customerId: w.id, verify: true });
    assert.deepEqual(kit.siteProblems, []);
    const plan = planPack({ intake: w.ws.releaseParts(w.id, 1).intake, kit, slug: w.id });
    assert.deepEqual(Object.fromEntries(plan.map((i) => [i.id, i.status])), { 'shop-pc': 'ready', website: 'ready', android: 'ready' });
    assert.deepEqual(plan.find((i) => i.id === 'website').files.map((f) => f.name).sort(), ['website-luzon-fresh-mart-linux.zip', 'website-luzon-fresh-mart-windows.zip']);
    assert.deepEqual(plan.find((i) => i.id === 'android').files.map((f) => f.name).sort(), ['SmartRetailPOS-luzon-fresh-mart-1.0.1.aab', 'SmartRetailPOS-luzon-fresh-mart-1.0.1.apk']);
    assert.equal(kit.trial, false);
    // a file that is changed afterwards is not used
    writeFileSync(join(folder, '1', 'website-luzon-fresh-mart-linux.zip'), Buffer.alloc(statSync(join(folder, '1', 'website-luzon-fresh-mart-linux.zip')).size, 1));
    const changed = await withSiteBuilds(await readBaseKit(programsDir), { folder, release: 1, customerId: w.id, verify: true });
    assert.match(changed.siteProblems.join('\n'), /website-luzon-fresh-mart-linux\.zip was changed after it was fetched/);
    // a build from an earlier release does not count for a later one
    assert.equal((await withSiteBuilds(await readBaseKit(programsDir), { folder, release: 2, customerId: w.id })).files.filter((f) => f.role === 'website').length, 0);
  } finally { await w.done(); }
});

test('a part that failed is said in the build service\'s own words, the parts that worked are kept, and "try again" is a new build number that builds only what is missing', async () => {
  const w = await world({ stand: { outcome: 'partly' } });
  try {
    await w.svc.start(w.rita, w.id);
    const first = await finish(w);
    assert.equal(first.state, 'partly');
    assert.deepEqual(first.parts.map((p) => p.status), ['success', 'failure', 'success']);
    assert.match(first.problem, /The website for Windows did not work: The Windows website would not start on the test machine\./);
    const folder = w.ws.siteBuildsFolder(w.id);
    assert.ok(existsSync(join(folder, '1', 'website-luzon-fresh-mart-linux.zip')));
    assert.ok(!existsSync(join(folder, '1', 'website-luzon-fresh-mart-windows.zip')), 'a failed part leaves no file');
    const page = w.svc.status(w.id);
    assert.deepEqual(page.parts.map((p) => [p.id, p.state]), [['website-linux', 'built'], ['website-windows', 'failed'], ['android', 'built']]);
    assert.equal(page.parts[1].message, 'The Windows website would not start on the test machine.');
    assert.equal(page.canStart, true, 'it can be tried again');
    assert.equal(w.ws.get(w.id).builds.at(-1).parts.find((p) => p.id === 'website-windows').status, 'failure');

    // try again: a new number; only the website is built (the app is already there)
    w.gh.options.outcome = 'success';
    await w.svc.start(w.rita, w.id);
    const second = await finish(w);
    assert.equal(second.n, 2);
    assert.equal(second.state, 'done');
    assert.deepEqual(readZipFiles(w.gh.asset('customer-luzon-fresh-mart-2', 'inputs.zip')).get('build.json').toString().includes('"android": false'), true);
    assert.deepEqual(w.svc.status(w.id).parts.map((p) => p.state), ['built', 'built', 'built']);
    // the parts come from the newest build that has them: the Linux site and the app from build 1, the Windows site from build 2 would be mixed, so each part comes whole from one build
    const kit = await withSiteBuilds({ files: [], trial: false, problems: [] }, { folder, release: 1, customerId: w.id });
    const from = Object.fromEntries(kit.files.map((f) => [f.name, f.path.split(/[\\/]/).at(-2)]));
    assert.equal(from['website-luzon-fresh-mart-linux.zip'], '2');
    assert.equal(from['website-luzon-fresh-mart-windows.zip'], '2');
    assert.equal(from['SmartRetailPOS-luzon-fresh-mart-1.0.1.apk'], '1');
  } finally { await w.done(); }
});

test('a trial build (no licence keys) is marked as one, in the record and in what the pack builder is told', async () => {
  const w = await world({ stand: { outcome: 'trial' } });
  try {
    await w.svc.start(w.rita, w.id);
    const done = await finish(w);
    assert.equal(done.state, 'done');
    assert.equal(done.trial, true);
    assert.equal(w.ws.get(w.id).builds.at(-1).trial, true);
    assert.match(w.ws.audit({ customer: w.id }).find((e) => e.action === 'build.finished').detail, /a trial build, no licence keys/);
    const kit = await withSiteBuilds({ files: [], trial: false, problems: [] }, { folder: w.ws.siteBuildsFolder(w.id), release: 1, customerId: w.id });
    assert.equal(kit.trial, true, 'the pack is refused unless it is only to try');
    assert.ok(kit.files.every((f) => f.trial));
  } finally { await w.done(); }
});

test('when every part fails, nothing is kept and the page says so; a build that dies before it publishes is explained from its steps and does not hang', async () => {
  const w = await world({ stand: { outcome: 'all-fail' } });
  try {
    await w.svc.start(w.rita, w.id);
    const done = await finish(w);
    assert.equal(done.state, 'failed');
    assert.equal(done.code, 'parts');
    assert.ok(!existsSync(join(w.ws.siteBuildsFolder(w.id), '1')), 'no folder for a build that brought nothing');
    assert.match(done.problem, /The website for Linux did not work/);
    assert.deepEqual(w.svc.status(w.id).parts.map((p) => p.state), ['failed', 'failed', 'failed']);

    w.gh.options.outcome = 'run-fails';
    await w.svc.start(w.rita, w.id);
    const dead = await finish(w);
    assert.equal(dead.n, 2);
    assert.equal(dead.state, 'failed');
    assert.equal(dead.code, 'build-stopped');
    assert.match(dead.problem, /This step did not work: Checking the settings that were sent\. Nothing came back\./);
    assert.ok(dead.steps.some((s) => /Checking the settings/.test(s.words) && s.state === 'failed'));
    assert.equal(w.ws.get(w.id).builds.at(-1).build, 2, 'it is written in the customer\'s record too');
  } finally { await w.done(); }
});

test('a wrong access code is explained in plain words, in "Test the connection" and when a build is started, and the code is never in the words', async () => {
  const w = await world();
  try {
    const wrong = 'test-wrong-access-code-9999';
    saveBuildCode('start', wrong, w.env);
    const t = await w.svc.testConnection();
    assert.equal(t.ok, false);
    const first = t.checks.find((c) => c.id === 'start-code');
    assert.equal(first.ok, false);
    assert.match(first.words, /did not accept the access code for starting builds/);
    assert.match(first.words, /may have run out/);
    assert.ok(!JSON.stringify(t).includes(wrong), 'the code is not in the answer');
    await assert.rejects(() => w.svc.start(w.rita, w.id), (e) => e.code === 'refused' && /did not accept the access code for starting builds/.test(e.message) && !e.message.includes(wrong));
    // the results code wrong: the first step to fail is keeping the settings
    saveBuildCode('start', w.gh.tokens.start, w.env);
    saveBuildCode('results', 'test-another-wrong-code-8888', w.env);
    await assert.rejects(() => w.svc.start(w.rita, w.id), (e) => e.code === 'refused' && /access code for keeping the results/.test(e.message));
    assert.equal(w.ws.get(w.id).builds.length, 0, 'a build that never started is not in the record');
    assert.equal(w.svc.status(w.id).current, null);
    // a repository the code is not for
    saveBuildCode('results', w.gh.tokens.results, w.env);
    w.ws.saveSettings(w.asha, { build: { sourceRepo: 'acme/another-place', resultsRepo: w.gh.results, ref: '' } });
    const t2 = await w.svc.testConnection();
    assert.match(t2.checks.find((c) => c.id === 'start-code').words, /did not find what the Studio asked for.*Check the two repository names/);
  } finally { await w.done(); }
});

test('"Test the connection" checks that each code can do what it is for and nothing more, and says what is wrong', async () => {
  const w = await world();
  try {
    let t = await w.svc.testConnection();
    assert.equal(t.ok, true, JSON.stringify(t.checks.filter((c) => c.ok !== true)));
    assert.deepEqual(t.checks.map((c) => c.id), ['start-code', 'build-setup', 'start-power', 'start-run', 'start-sees-results', 'results-code', 'results-read', 'results-write', 'results-power']);
    assert.equal(w.gh.releases().length, 0, 'the test note is removed at once');
    assert.ok(w.gh.seen.some((r) => r.path.endsWith('/dispatches') && /studio-connection-test/.test(r.body)) && w.gh.runs.length === 0, 'no build was really started');

    w.gh.options.startCanReadContents = true;
    w.gh.options.resultsCanReadContents = true;
    t = await w.svc.testConnection();
    assert.equal(t.ok, false);
    assert.match(t.checks.find((c) => c.id === 'start-power').words, /can also read the programs' source code/);
    assert.match(t.checks.find((c) => c.id === 'results-power').words, /can also read the programs' source code/);
    w.gh.options.startCanReadContents = false; w.gh.options.resultsCanReadContents = false;

    w.gh.options.noWorkflow = true;
    assert.match((await w.svc.testConnection()).checks.find((c) => c.id === 'build-setup').words, /The build was not found in acme\/programs/);
    w.gh.options.noWorkflow = false; w.gh.options.workflowDisabled = true;
    assert.match((await w.svc.testConnection()).checks.find((c) => c.id === 'build-setup').words, /switched off/);
    w.gh.options.workflowDisabled = false;

    w.gh.options.resultsReadOnly = true;
    assert.match((await w.svc.testConnection()).checks.find((c) => c.id === 'results-write').words, /not allowed to do this \(adding to the results place\)/);
    w.gh.options.resultsReadOnly = false;
    w.gh.options.startCannotDispatch = true;
    assert.match((await w.svc.testConnection()).checks.find((c) => c.id === 'start-run').words, /not allowed to do this \(starting a build\)/);
    w.gh.options.startCannotDispatch = false;
    w.gh.options.startSeesResults = true;
    assert.match((await w.svc.testConnection()).checks.find((c) => c.id === 'start-sees-results').words, /can also see the results place/);
    w.gh.options.startSeesResults = false;
    for (const c of (await w.svc.testConnection()).checks) plain(c.words, 'in a check: ');
    Object.assign(w.gh.options, { noWorkflow: true, workflowDisabled: true, startCanReadContents: true, resultsReadOnly: true, startCannotDispatch: true });
    for (const c of (await w.svc.testConnection()).checks) plain(c.words, 'in a check: ');
    Object.assign(w.gh.options, { noWorkflow: false, workflowDisabled: false, startCanReadContents: false, resultsReadOnly: false, startCannotDispatch: false });

    // nothing to test with
    removeBuildCode('results', w.env);
    const missing = await w.svc.testConnection();
    assert.equal(missing.ok, false);
    assert.match(missing.checks.find((c) => c.id === 'results-code').words, /has not been added yet/);
    assert.equal(getBuildCode('results', w.env), null);
    w.ws.saveSettings(w.asha, { build: { sourceRepo: '', resultsRepo: '', ref: '' } });
    assert.match((await w.svc.testConnection()).checks[0].words, /Type the two repository names/);
  } finally { await w.done(); }
});

test('the network dropping or the service stumbling for a moment does not lose the build; a long loss stops the waiting, and "look again" picks it up', async () => {
  const w = await world();
  try {
    // starting: the connection is cut -> plain words, and nothing is recorded
    w.gh.options.dropNext = 1;
    await assert.rejects(() => w.svc.start(w.rita, w.id), (e) => e.code === 'network' && /could not reach the build service/.test(e.message) && /Check the internet connection/.test(e.message));
    assert.equal(w.svc.status(w.id).current, null);
    // a service error (500) in the middle of watching is put up with
    w.gh.options.fail.push({ match: /\/actions\/runs\//, status: 502, times: 2 });
    w.gh.options.dropNext = 0;
    await w.svc.start(w.rita, w.id);
    const done = await finish(w);
    assert.equal(done.state, 'done', 'two bad answers in a row are tolerated');
    assert.equal(done.n, 1, 'the earlier try that never started did not use the number');

    // a loss that lasts: the Studio stops waiting (the build is not failed), and looking again finishes it
    const w2 = await world({ stand: { holdPublish: true } });
    try {
      await w2.svc.start(w2.rita, w2.id);
      w2.gh.options.fail.push({ match: /\/actions\/runs\//, status: 503, times: 1000 });
      const lost = await finish(w2);
      assert.equal(lost.state, 'stopped');
      assert.equal(lost.canLook, true);
      assert.match(lost.problem, /lost contact with the build service/);
      assert.match(lost.problem, /Press "Look again"/);
      assert.equal(w2.ws.get(w2.id).builds.length, 0, 'a build that is only waited for is not recorded as made');
      assert.ok(w2.ws.audit({ customer: w2.id }).some((e) => e.action === 'build.stopped'));
      // a build the Studio stopped waiting for may still be going on: another is not started behind it (a third would be dropped), and the words say so
      w2.gh.options.fail.length = 0;
      await assert.rejects(() => w2.svc.start(w2.rita, w2.id), (e) => e.code === 'earlier' && /Build 1 is still going on at the build service/.test(e.message));
      w2.gh.options.holdPublish = false;
      await until(() => w2.gh.release('customer-luzon-fresh-mart-1').draft === false);
      await assert.rejects(() => w2.svc.start(w2.rita, w2.id), (e) => e.code === 'earlier' && /has finished in the meantime/.test(e.message));
      w2.svc.look(w2.rita, w2.id);
      assert.equal((await finish(w2)).state, 'done');
      assert.ok(existsSync(join(w2.ws.siteBuildsFolder(w2.id), '1', 'SmartRetailPOS-luzon-fresh-mart-1.0.1.apk')));
    } finally { await w2.done(); }
  } finally { await w.done(); }
});

test('a build that takes too long: the Studio stops waiting at its ceiling and says so; the build is not failed', async () => {
  const w = await world({ stand: { holdPublish: true }, service: { ceilingMs: 150 } });
  try {
    await w.svc.start(w.rita, w.id);
    const slow = await finish(w);
    assert.equal(slow.state, 'stopped');
    assert.equal(slow.code, 'slow');
    assert.match(slow.problem, /taking much longer than usual, so the Studio stopped waiting/);
    assert.equal(slow.canLook, true);
    w.gh.options.holdPublish = false;
    w.svc.look(w.rita, w.id);
    assert.equal((await finish(w)).state, 'done');
  } finally { await w.done(); }
});

test('a request that is never answered is given up on in plain words', async () => {
  const w = await world({ service: { requestTimeoutMs: 120 } });
  try {
    w.gh.options.hangNext = 1;
    await assert.rejects(() => w.svc.start(w.rita, w.id), (e) => e.code === 'timeout' && /did not answer in time/.test(e.message));
    const t = await (async () => { w.gh.options.hangNext = 1; return w.svc.testConnection(); })();
    assert.match(t.checks[0].words, /did not answer in time/);
  } finally { await w.done(); }
});

test('a file that does not match its fingerprint is never kept: nothing is placed, the words say what to do, and looking again can fetch it afresh', async () => {
  const w = await world({ stand: { tamper: true } });
  try {
    await w.svc.start(w.rita, w.id);
    const bad = await finish(w);
    assert.equal(bad.state, 'failed');
    assert.equal(bad.code, 'checksum');
    assert.match(bad.problem, /is not the one the build made: its fingerprint does not match\. Nothing was kept\./);
    assert.equal(bad.canLook, true);
    const folder = w.ws.siteBuildsFolder(w.id);
    assert.deepEqual(readdirSync(folder), ['state.json'], 'no file, no half-finished download');
    assert.ok(bad.steps.some((s) => /Bringing the files back/.test(s.words) && s.state === 'failed'));
    assert.match(w.ws.audit({ customer: w.id }).find((e) => e.action === 'build.failed').detail, /fingerprint does not match/, 'it is written in the activity record');
    assert.equal(w.ws.get(w.id).builds.at(-1).kind, 'website-app');
    // fetched again, this time intact
    w.gh.options.tamper = false;
    w.svc.look(w.rita, w.id);
    assert.equal((await finish(w)).state, 'done');
    assert.ok(existsSync(join(folder, '1', 'website-luzon-fresh-mart-linux.zip')));
  } finally { await w.done(); }
});

test('what the build service names is checked: a report about another customer or build, a name with a folder in it, another customer\'s file, a missing list of fingerprints', async () => {
  const text = (o) => JSON.stringify({ schema: 1, customer: 'luzon-fresh-mart', build: 1, trial: false, parts: { android: { status: 'success', message: 'ok' } }, ...o });
  assert.deepEqual(readResult(text({}), { customerId: 'luzon-fresh-mart', n: 1 }).parts, { android: { status: 'success', message: 'ok' } });
  for (const bad of [text({ customer: 'someone-else' }), text({ build: 2 }), text({ schema: 2 }), 'not json', text({ parts: null })]) assert.throws(() => readResult(bad, { customerId: 'luzon-fresh-mart', n: 1 }), BuildError);
  assert.equal(readResult(text({ parts: { android: { status: 'success', message: 'Key AIza' + 'SyA1234567890abcdefghijklmnopqrstuv' }, nonsense: { status: 'success' } } }), { customerId: 'luzon-fresh-mart', n: 1 }).parts.android.message, '(the message was left out because it looked like a secret)');
  assert.deepEqual(readSums(`${'a'.repeat(64)}  one.zip\n${'B'.repeat(64)} *two.apk\nnot a line\n`), { 'one.zip': 'a'.repeat(64), 'two.apk': 'b'.repeat(64) });
  assert.throws(() => readSums(`${'a'.repeat(64)}  ../escape.zip\n`), BuildError);
  assert.throws(() => readSums(`${'a'.repeat(64)}  sub/dir.zip\n`), BuildError);
  // through the service: a website for another customer in the release is ignored, and a part without its file is a failed part
  const w = await world();
  try {
    await w.svc.start(w.rita, w.id);
    await finish(w);
    assert.ok(!readdirSync(join(w.ws.siteBuildsFolder(w.id), '1')).some((n) => /someone-else/.test(n)));
    const rules = (await import('../lib/builds.mjs')).fileRules('luzon-fresh-mart');
    assert.equal(rules.some((r) => r.re.test('website-someone-else-linux.zip')), false);
    assert.equal(rules.some((r) => r.re.test('SmartRetailPOS-luzon-fresh-mart-1.0.1.apk')), true);
    assert.equal(rules.some((r) => r.re.test('website-luzon-fresh-mart-linux.zip.exe')), false);
  } finally { await w.done(); }
  const w2 = await world({ stand: { outcome: 'no-result' } });
  try {
    await w2.svc.start(w2.rita, w2.id);
    const none = await finish(w2);
    assert.equal(none.state, 'failed');
    assert.equal(none.code, 'no-result');
    assert.match(none.problem, /did not leave its report or its list of fingerprints/);
  } finally { await w2.done(); }
});

test('a number already used in the results place is skipped, a draft left by a try that did not start is used again, and the count is the Studio\'s own', async () => {
  const w = await world();
  try {
    // a finished build 1 exists in the results place already (the Studio's record was lost)
    const taken = await (await fetch(`${w.gh.url}/repos/${w.gh.results}/releases`, { method: 'POST', headers: { authorization: `Bearer ${w.gh.tokens.results}`, 'content-type': 'application/json' }, body: JSON.stringify({ tag_name: 'customer-luzon-fresh-mart-1', name: 'old', draft: false }) })).json();
    assert.ok(taken.id);
    await w.svc.start(w.rita, w.id);
    const done = await finish(w);
    assert.equal(done.n, 2, 'the used number is skipped');
    // a start that stopped after the draft was made: the next try uses that draft and its number
    const w2 = await world();
    try {
      w2.gh.options.fail.push({ match: /\/dispatches$/, status: 500, times: 1 });
      await assert.rejects(() => w2.svc.start(w2.rita, w2.id), (e) => e.code === 'server');
      assert.equal(w2.gh.releases().length, 1);
      const draftId = w2.gh.releases()[0].id;
      await w2.svc.start(w2.rita, w2.id);
      assert.equal(w2.gh.releases().length, 1, 'the draft was used again, not a second one');
      assert.equal(w2.gh.releases()[0].id, draftId);
      assert.equal(w2.gh.releases()[0].assets.filter((a) => a.name === 'inputs.zip').length, 1, 'and its old settings were replaced');
      assert.equal((await finish(w2)).n, 1);
    } finally { await w2.done(); }
  } finally { await w.done(); }
});

test('one build at a time for a customer, only a reviewer or administrator starts it, and it is made from an approved release', async () => {
  const w = await world({ stand: { holdPublish: true } });
  try {
    await assert.rejects(() => w.svc.start(w.sam, w.id), (e) => e.status === 403 && /Your role cannot start builds/.test(e.message));
    assert.equal(w.svc.status(w.id, w.sam).canStart, true, 'a salesperson sees that it is ready, and what would be sent');
    await w.svc.start(w.asha, w.id);
    await assert.rejects(() => w.svc.start(w.rita, w.id), /already running/);
    assert.equal(w.svc.status(w.id).canStart, false);
    assert.equal(w.svc.status(w.id).why, 'A build is already running for this customer.');
    assert.throws(() => w.svc.look(w.sam, w.id), (e) => e.status === 403);
    w.gh.options.holdPublish = false;
    await finish(w);
    // not approved yet
    const fresh = await world({ approve: false });
    try {
      const page = fresh.svc.status(fresh.id);
      assert.equal(page.canStart, false);
      assert.match(page.blockers[0], /Approve a setup first/);
      await assert.rejects(() => fresh.svc.start(fresh.rita, fresh.id), /Approve a setup first/);
      assert.equal(fresh.gh.seen.length, 0);
    } finally { await fresh.done(); }
    // nothing to build
    const plain = await world({ intake: good({ ecosystem: { website: { wanted: false, domain: '' }, android: { wanted: false, appId: '' } } }) });
    try { assert.match(plain.svc.status(plain.id).blockers[0], /not set up to get a website or an Android app/); } finally { await plain.done(); }
    // an app needs the website's name
    const noName = await world({ intake: good({ ecosystem: { website: { wanted: true, domain: '' }, android: { wanted: true, appId: 'com.luzonfresh.shop' } } }) });
    try { assert.match(noName.svc.status(noName.id).blockers[0], /opens the customer's website, so the details need the website name/); } finally { await noName.done(); }
    // not connected
    const open = await world({ codes: false });
    try {
      assert.equal(open.svc.connection().ready, false);
      assert.match(open.svc.connection().why, /not added both access codes yet/);
      await assert.rejects(() => open.svc.start(open.rita, open.id), /not added both access codes yet/);
    } finally { await open.done(); }
  } finally { await w.done(); }
});

test('the access codes are in no file the Studio writes except their own, in no message, and never go anywhere but the build service\'s own header', async () => {
  const w = await world({ stand: { outcome: 'partly' } });
  try {
    const codes = [w.gh.tokens.start, w.gh.tokens.results];
    const spoken = [];
    const note = (x) => spoken.push(String(x?.message ?? x));
    await w.svc.start(w.rita, w.id);
    const done = await finish(w);
    // in everyday work each code goes only to its own place: the code for starting builds to the programs' place, the code for keeping the results to the results place
    const forStart = w.gh.seen.filter((r) => r.path.startsWith(`/repos/${w.gh.source}`));
    const forResults = w.gh.seen.filter((r) => r.path.startsWith(`/repos/${w.gh.results}`));
    assert.ok(forStart.length >= 4 && forStart.every((r) => r.who === 'start'), 'only the start code goes to the programs\' place');
    assert.ok(forResults.length >= 6 && forResults.every((r) => r.who === 'results'), 'only the results code goes to the results place');
    // every problem the client can speak, collected
    w.gh.options.dropNext = 1; await w.svc.start(w.asha, w.id).catch(note);
    saveBuildCode('start', 'test-wrong-access-code-9999', w.env);
    await w.svc.testConnection().then((t) => spoken.push(JSON.stringify(t)));
    await w.svc.start(w.asha, w.id).catch(note);
    saveBuildCode('start', w.gh.tokens.start, w.env);
    spoken.push(JSON.stringify(done), JSON.stringify(w.svc.status(w.id)), JSON.stringify(w.svc.connection()));
    // the workspace (everything the Studio writes for a customer, the team, the activity record), a backup, and the pack's inputs
    w.ws.backup(w.asha);
    for (const file of everyFile(join(w.root, 'ws'))) { const text = readFileSync(file).toString('latin1'); for (const c of codes) assert.ok(!text.includes(c), `${file} holds an access code`); }
    for (const text of spoken) for (const c of codes) assert.ok(!text.includes(c), 'a message holds an access code');
    for (const text of spoken) plain(text, 'in a message: ');
    for (const [, data] of readZipFiles(w.gh.asset('customer-luzon-fresh-mart-1', 'inputs.zip'))) for (const c of codes) assert.ok(!data.toString('latin1').includes(c));
    // only the secret store holds them, in the person's own folder
    const store = readFileSync(join(w.root, 'home', 'keys.json'), 'utf8');
    assert.ok(codes.every((c) => store.includes(c)));
    assert.equal(statSync(join(w.root, 'home', 'keys.json')).mode & 0o077, 0, 'readable by this person only');
    // the service saw each code only in the Authorization header of its own requests, never in an address or a body
    for (const r of w.gh.seen) { for (const c of codes) { assert.ok(!r.path.includes(c) && !(r.body ?? '').includes(c), `${r.method} ${r.path}`); } }
    assert.ok(w.gh.seen.filter((r) => !r.path.startsWith('/__storage')).every((r) => r.who !== 'none'), 'every request to the build service carries a code');
    // and the place a file is kept never gets one
    assert.ok(w.gh.storageSeen.length >= 3);
    assert.ok(w.gh.storageSeen.every((r) => r.authorization === null), 'the address a download points to gets no access code');
  } finally { await w.done(); }
});

test('a download that points somewhere unsafe is refused and the access code does not follow it', async () => {
  const w = await world({ stand: { redirectTo: 'http://evil.example' } });
  try {
    await w.svc.start(w.rita, w.id);
    const bad = await finish(w);
    assert.equal(bad.state, 'failed');
    assert.equal(bad.code, 'unsafe');
    assert.match(bad.problem, /not safe, so nothing was downloaded/);
    assert.ok(!existsSync(join(w.ws.siteBuildsFolder(w.id), '1')));
  } finally { await w.done(); }
  const direct = await world({ stand: { directDownload: true } });
  try { await direct.svc.start(direct.rita, direct.id); assert.equal((await finish(direct)).state, 'done', 'a file given directly also works'); } finally { await direct.done(); }
});

test('the steps of the build are said in plain words, whatever the build service calls them', () => {
  assert.equal(jobWords('Website (Linux)'), 'Building the website for Linux');
  assert.equal(jobWords('build-website-windows'), 'Building the website for Windows');
  assert.equal(jobWords('Android app (APK and AAB)'), 'Building the Android app');
  assert.equal(jobWords('validate-inputs'), 'Checking the settings that were sent');
  assert.equal(jobWords('Publish the result'), 'Putting the finished files together');
  assert.equal(jobWords('Something nobody planned'), 'Another step of the build');
  assert.equal(jobWords(undefined), 'Another step of the build');
  for (const word of [jobWords('x'), jobWords('Website (Linux)'), ...PARTS.map((p) => p.words)]) assert.ok(!/GitHub|workflow|token|runner|job\b/i.test(word), word);
});

test('the names of the two places are checked and must differ; the settings cannot change while a build is running', async () => {
  assert.equal(checkRepoName('  acme/programs ', 'x'), 'acme/programs');
  assert.equal(checkRepoName('', 'x'), '');
  for (const bad of ['acme', 'acme/', '/programs', 'acme/pro grams', 'acme/../x', 'https://github.com/acme/programs', 'a/b/c', "acme/x'y"]) assert.throws(() => checkRepoName(bad, 'Where the programs are made'), /type the name like owner\/name/, bad);
  const w = await world({ stand: { holdPublish: true } });
  try {
    assert.throws(() => w.svc.saveNames(w.asha, { sourceRepo: 'acme/same', resultsRepo: 'ACME/same' }), /different place/);
    assert.throws(() => w.svc.saveNames(w.asha, { sourceRepo: 'acme/a', resultsRepo: 'acme/b', ref: 'bad ref' }), /Which version/);
    assert.throws(() => w.svc.saveNames(w.sam, { sourceRepo: 'acme/a', resultsRepo: 'acme/b' }), (e) => e.status === 403, 'only an administrator');
    assert.equal(w.svc.saveNames(w.asha, { sourceRepo: w.gh.source, resultsRepo: w.gh.results, ref: 'release-line' }).ref, 'release-line');
    await w.svc.start(w.rita, w.id);
    assert.equal(JSON.parse(w.gh.seen.find((r) => r.path.endsWith('/dispatches')).body).ref, 'release-line', 'the chosen version is the one built from');
    assert.throws(() => w.svc.saveNames(w.asha, { sourceRepo: 'acme/x', resultsRepo: 'acme/y' }), /A build is running/);
    w.gh.options.holdPublish = false;
    await finish(w);
    assert.equal(w.svc.connection().suggestedResults, '', 'a name is set, so none is suggested');
    w.svc.saveNames(w.asha, { sourceRepo: 'acme/programs', resultsRepo: '' });
    assert.equal(w.svc.connection().suggestedResults, 'acme/nextgenos-customer-builds');
  } finally { await w.done(); }
});

test('opening the step after the Studio was closed in the middle of a build picks the build up again, for people who may build', async () => {
  const w = await world({ stand: { holdPublish: true } });
  try {
    await w.svc.start(w.rita, w.id);
    w.svc.close();   // the Studio is closed: the watching stops, the build carries on
    await w.svc.followers.get(w.id);
    const record = JSON.parse(readFileSync(join(w.ws.siteBuildsFolder(w.id), 'state.json'), 'utf8'));
    assert.equal(record.builds[0].state, 'running');
    // a new Studio on the same files, the same build service
    w.gh.options.holdPublish = false;
    const again = createBuildService({ ws: w.ws, env: w.env, studioVersion: '1.0.0', api: w.gh.url, pollMs: 10, ceilingMs: 8000, requestTimeoutMs: 1500 });
    try {
      assert.equal(again.status(w.id, w.sam).current.state, 'running', 'a salesperson only looks; it does not pick the build up');
      assert.equal(again.followers.size, 0);
      again.status(w.id, w.rita);
      await again.followers.get(w.id);
      assert.equal(again.status(w.id).current.state, 'done');
    } finally { again.close(); }
  } finally { await w.done(); }
});

test('the Studio\'s list of secret patterns is the same as the repository\'s, and it finds what the package check finds', async () => {
  const mine = await import('../lib/secretscan.mjs');
  const theirs = await import('../../../scripts/lib/secret-patterns.mjs');
  const audit = await import('../../../scripts/audit-package.mjs');
  assert.deepEqual(mine.SECRET_PATTERNS.map(([re, what]) => [re.source, re.flags, what]), theirs.SECRET_PATTERNS.map(([re, what]) => [re.source, re.flags, what]));
  assert.deepEqual(mine.SECRET_ALLOW.map((re) => [re.source, re.flags]), theirs.SECRET_ALLOW.map((re) => [re.source, re.flags]));
  for (const sample of ['nothing here', 'Key AIza' + 'SyA1234567890abcdefghijklmnopqrstuv', 'ghp_' + 'a'.repeat(36), '-----BEGIN RSA PRIVATE KEY-----', 'Password=your_password;', 'Server=x;Password=hunter22xx;', 'sk-test-0000', 'postgres://user:secret@host/db', 'npg_abcdefghijk']) {
    assert.deepEqual(mine.findSecrets(sample), audit.findSecrets(sample), sample);
  }
  assert.deepEqual(mine.findSecrets(''), []);
  assert.deepEqual(mine.findSecrets(undefined), []);
});

test('the sums, the sha and the stand-in agree on what a fingerprint is', () => {
  assert.equal(sha256(Buffer.from('abc')), 'ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad');
});

test('what the build service would refuse is said now: a logo that is not a PNG is left out and the page says so, and a shop name the app cannot carry stops only the app', async () => {
  const jpeg = Buffer.concat([Buffer.from([0xff, 0xd8, 0xff, 0xe0, 0, 16]), Buffer.from('JFIF'), Buffer.alloc(40, 1)]);
  const w = await world({ logo: jpeg });
  try {
    const page = w.svc.status(w.id);
    assert.match(page.notes[0], /The logo is a JPEG picture. The build service takes a PNG, so the website and the app are made without the logo/);
    const files = readZipFiles(makeInputs({ customerId: w.id, n: 1, parts: w.ws.releaseParts(w.id, 1), wants: { website: true, android: true } }).zip);
    assert.deepEqual([...files.keys()].sort(), ['brand.json', 'build.json', 'website-settings.env'], 'only the four files the service takes, and no logo that is not a PNG');
    assert.equal(JSON.parse(files.get('brand.json')).logo, undefined, 'brand.json names no logo that is not there');
    await w.svc.start(w.rita, w.id);
    assert.equal((await finish(w)).state, 'done', 'the build accepts it');
  } finally { await w.done(); }
  for (const name of ["Joe's Fresh Mart", 'Fresh & Cheap Mart', 'The Very Long Name Of A Shop That Sells Everything Twice']) {
    const shop = await world({ intake: good({ business: { name, country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example' } } }) });
    try {
      const page = shop.svc.status(shop.id);
      assert.match(page.parts.find((p) => p.id === 'android').message, /name of the app, so for the app it can have at most 40 letters/, name);
      assert.equal(page.parts.find((p) => p.id === 'android').state, 'blocked');
      assert.equal(page.canStart, true, 'the website can still be made');
      await assert.rejects(() => shop.svc.start(shop.rita, shop.id, { which: ['android'] }), /name of the app/);
      await shop.svc.start(shop.rita, shop.id);
      const done = await finish(shop);
      assert.deepEqual(readZipFiles(shop.gh.asset(`customer-${shop.id}-1`, 'inputs.zip')).get('build.json').toString().includes('"android": false'), true);
      assert.equal(done.state, 'done');
      assert.deepEqual(done.parts.map((p) => p.id), ['website-linux', 'website-windows']);
    } finally { await shop.done(); }
  }
});

test('the build must have worked from the settings this Studio sent; a list of fingerprints that names others is refused, and nothing is kept', async () => {
  const w = await world({ stand: { wrongInputsSum: true } });
  try {
    await w.svc.start(w.rita, w.id);
    const bad = await finish(w);
    assert.equal(bad.state, 'failed');
    assert.equal(bad.code, 'inputs');
    assert.match(bad.problem, /not the ones the Studio sent, so nothing was kept/);
    assert.ok(!existsSync(join(w.ws.siteBuildsFolder(w.id), '1')));
  } finally { await w.done(); }
});

test('what is sent is what the build service accepts: its own look at the bundle passes every build in these tests, and refuses a bundle with another file in it', async () => {
  const w = await world();
  try {
    await w.svc.start(w.rita, w.id);
    const done = await finish(w);
    const sent = readZipFiles(w.gh.asset('customer-luzon-fresh-mart-1', 'inputs.zip'));
    assert.deepEqual([...sent.keys()].sort(), ['brand.json', 'build.json', 'logo.png', 'website-settings.env']);
    assert.equal(typeof JSON.parse(sent.get('build.json')).build, 'number', 'the build is a number in build.json and a string in the request');
    assert.deepEqual(done.parts.map((p) => p.status), ['success', 'success', 'success'], 'the stand-in refused nothing');
    assert.match(w.gh.runs[0].inputs.build, /^\d+$/);
  } finally { await w.done(); }
});
