// The structure of .github/workflows/build-customer.yml, checked from its text (a real run needs GitHub, the owner's repositories and tokens: see docs/CUSTOMER-BUILDS.md).
// The same idea as the structure tests of the Release workflow in apps/pos-ai-companion/tests/SmartRetail.AI.Tests/CheckVersionScriptTests.cs, written in Node:
// the jobs and what each waits for, one build per customer, the publishing job last, the token read only from secrets and only by the steps that talk to the results place,
// typed values reaching scripts only through the environment, and nothing about a customer or a token written in the file.
import test from 'node:test';
import assert from 'node:assert/strict';
import { existsSync, readFileSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';
import { findSecrets } from '../audit-package.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const root = join(here, '..', '..');
const FILE = join(root, '.github', 'workflows', 'build-customer.yml');
const text = readFileSync(FILE, 'utf8').replace(/\r\n/g, '\n');

// ---------------------------------------------------------------------------------------------------------------------
// A small reader for the part of YAML the workflow files use: maps, lists of maps, flow lists, quoted text and block text (| and >).
// It is not a general YAML parser; it is enough to read these files, and the test below shows what it understands.
// ---------------------------------------------------------------------------------------------------------------------
export function parseYaml(source) {
  const raw = source.replace(/\r\n/g, '\n').split('\n').map((l) => l.replace(/\s+$/, ''));
  let i = 0;
  const indentOf = (l) => l.length - l.trimStart().length;
  const skipBlank = () => { while (i < raw.length && (raw[i].trim() === '' || raw[i].trim().startsWith('#'))) i += 1; };
  const scalar = (v) => {
    const t = v.trim();
    if (/^".*"$/.test(t) || /^'.*'$/.test(t)) return t.slice(1, -1);
    if (t.startsWith('[') && t.endsWith(']')) return t.slice(1, -1).split(',').map((x) => x.trim()).filter(Boolean);
    if (t === 'true') return true;
    if (t === 'false') return false;
    return t;
  };
  function block() {
    skipBlank();
    if (i >= raw.length) return null;
    const line = raw[i];
    return line.trimStart().startsWith('- ') || line.trim() === '-' ? list(indentOf(line)) : map(indentOf(line));
  }
  function map(indent) {
    const out = {};
    for (;;) {
      skipBlank();
      if (i >= raw.length) break;
      const line = raw[i];
      const ind = indentOf(line);
      if (ind < indent) break;
      if (ind > indent) throw new Error(`Unexpected indent at line ${i + 1}: ${line}`);
      if (line.trimStart().startsWith('- ')) break;
      const m = /^([A-Za-z0-9_.-]+|"[^"]+"):(?:\s+(.*))?$/.exec(line.trim());
      if (!m) throw new Error(`Cannot read line ${i + 1}: ${line}`);
      const key = m[1].replace(/^"|"$/g, '');
      const value = m[2];
      i += 1;
      if (value === undefined || value === '') {
        skipBlank();
        const next = raw[i];
        out[key] = next !== undefined && (indentOf(next) > ind || (indentOf(next) === ind && next.trimStart().startsWith('- '))) ? block() : null;
      } else if (/^[|>][+-]?$/.test(value)) {
        const lines = [];
        while (i < raw.length && (raw[i].trim() === '' || indentOf(raw[i]) > ind)) { lines.push(raw[i]); i += 1; }
        const base = Math.min(...lines.filter((l) => l.trim()).map(indentOf));
        out[key] = lines.map((l) => l.slice(base)).join('\n').replace(/\n+$/, '');
      } else {
        out[key] = scalar(value);
      }
    }
    return out;
  }
  function list(indent) {
    const out = [];
    for (;;) {
      skipBlank();
      if (i >= raw.length) break;
      const line = raw[i];
      if (indentOf(line) !== indent || !line.trimStart().startsWith('-')) break;
      const rest = line.trimStart().slice(1).trimStart();
      const column = line.length - rest.length;
      if (/^([A-Za-z0-9_.-]+):(\s|$)/.test(rest)) { raw[i] = ' '.repeat(column) + rest; out.push(map(column)); } else { out.push(scalar(rest)); i += 1; }
    }
    return out;
  }
  const result = block();
  return result;
}

const wf = parseYaml(text);
const jobs = wf.jobs;
const stepsOf = (job) => jobs[job].steps;
const find = (job, id) => stepsOf(job).find((s) => s.id === id);
const index = (job, id) => stepsOf(job).findIndex((s) => s.id === id);
const buildJobs = ['website', 'android'];
const env = (step) => step.env ?? {};

test('the reader understands what it is used for here (maps, lists of maps, flow lists, quoted text, block text)', () => {
  const y = parseYaml('a: 1\nb:\n  c: [x, y]\n  d: "q: r"\n  e: |\n    one\n      two\n\n    three\nl:\n  - name: n\n    run: |\n      echo hi\n  - uses: u@v1\n    with:\n      k: v\n  - plain\n# end\n');
  assert.deepEqual(y, { a: '1', b: { c: ['x', 'y'], d: 'q: r', e: 'one\n  two\n\nthree' }, l: [{ name: 'n', run: 'echo hi' }, { uses: 'u@v1', with: { k: 'v' } }, 'plain'] });
});

test('it starts only when the Setup Studio asks, with three small inputs that carry no setting', () => {
  assert.deepEqual(Object.keys(wf.on), ['workflow_dispatch'], 'no push, no pull request, no schedule: nobody else starts a build');
  const inputs = wf.on.workflow_dispatch.inputs;
  assert.deepEqual(Object.keys(inputs), ['customer', 'build', 'results_repo']);
  for (const input of Object.values(inputs)) { assert.equal(input.required, true); assert.equal(input.type, 'string'); assert.equal(input.default, undefined, 'no default: nothing is assumed'); }
});

test('one build per customer at a time, and a build that is running is never cancelled by a newer one', () => {
  assert.equal(wf.concurrency.group, 'customer-${{ inputs.customer }}');
  assert.equal(wf.concurrency['cancel-in-progress'], false);
});

test('the run\'s own token can read this repository and nothing more; no job asks for more', () => {
  assert.deepEqual(wf.permissions, { contents: 'read' });
  for (const job of Object.values(jobs)) assert.equal(job.permissions, undefined);
  assert.doesNotMatch(text, /:\s*write\b/, 'nothing in this file asks for write permission');
  assert.doesNotMatch(text, /id-token|pull-requests/);
});

test('the jobs, and what each waits for: read the settings, build the parts, then write the result and publish', () => {
  assert.deepEqual(Object.keys(jobs), ['inputs', 'website', 'android', 'publish']);
  assert.equal(jobs.inputs.needs, undefined);
  for (const job of buildJobs) assert.deepEqual(jobs[job].needs, ['inputs'], `${job} waits for the settings to be read and accepted`);
  assert.deepEqual(jobs.publish.needs, ['inputs', 'website', 'android'], 'the publishing job waits for every part, whatever it ended as');
  // Nothing waits for the publishing job: it is last.
  for (const [name, job] of Object.entries(jobs)) if (name !== 'publish') assert.ok(![].concat(job.needs ?? []).includes('publish'), name);
  // A part is built only when it was asked for.
  assert.equal(jobs.website.if, "${{ needs.inputs.outputs.website == 'true' }}");
  assert.equal(jobs.android.if, "${{ needs.inputs.outputs.android == 'true' }}");
  // The publishing job runs always, also when a part failed or was cancelled, so the Setup Studio is told.
  assert.equal(jobs.publish.if, '${{ always() }}');
});

test('the names of the jobs are plain words: the Setup Studio shows them as the steps of a build', () => {
  assert.equal(jobs.inputs.name, 'Reading the customer\'s settings');
  assert.equal(jobs.website.name, 'Building the website for ${{ matrix.label }}');
  assert.deepEqual(jobs.website.strategy.matrix.include.map((m) => m.label), ['Linux', 'Windows']);
  assert.equal(jobs.android.name, 'Building the Android app');
  assert.equal(jobs.publish.name, 'Writing the result and publishing it');
  for (const j of Object.values(jobs)) assert.doesNotMatch(j.name, /github|actions|workflow|runner|artifact/i);
});

test('the release is published by one step, the very last step of the very last job, and no other job can publish', () => {
  const publishing = (s) => /results\.mjs finish/.test(s.run ?? '');
  assert.deepEqual(Object.entries(jobs).filter(([, j]) => j.steps.some(publishing)).map(([n]) => n), ['publish']);
  const steps = stepsOf('publish');
  assert.ok(publishing(steps[steps.length - 1]), 'finish is the last step');
  assert.equal(steps.filter(publishing).length, 1);
  // The release of the programs' own repository is not touched: the files travel through the results place, and only through it.
  assert.doesNotMatch(text, /release-assets\.mjs/);
  assert.doesNotMatch(text, /github\.token|secrets\.GITHUB_TOKEN|GITHUB_TOKEN:/);
  // Every build job reports what happened to its part, also when it failed, after the step that puts its files in the results place.
  for (const job of buildJobs) {
    const report = stepsOf(job).findIndex((s) => /result\.mjs part/.test(s.run ?? ''));
    assert.ok(report > index(job, 'put'), `${job}: the report comes after the files were put in the results place`);
    assert.equal(stepsOf(job)[report].if, '${{ always() }}', `${job}: the report is written also when the job failed`);
    const handOver = stepsOf(job)[report + 1];
    assert.match(handOver.uses, /^actions\/upload-artifact@v4$/);
    assert.equal(handOver.if, '${{ always() }}');
    assert.match(handOver.with.name, /^part-/);
  }
  const download = steps.find((s) => /download-artifact/.test(s.uses ?? ''));
  assert.equal(download.with.pattern, 'part-*');
  assert.equal(download['continue-on-error'], true, 'when no part ran there is nothing to take, and the result says so');
});

test('the results token is read only from the repository secrets, and only by steps that talk to the results place', () => {
  for (const line of text.split('\n')) if (/RESULTS_TOKEN/.test(line) && !/^\s*#/.test(line)) {
    assert.match(line, /^\s+RESULTS_TOKEN: \$\{\{ secrets\.RESULTS_TOKEN \}\}$/, `a line that touches the token must only read it from secrets: ${line}`);
  }
  assert.equal(wf.env.RESULTS_TOKEN, undefined, 'not in the environment of the whole workflow');
  let readers = 0;
  for (const [name, job] of Object.entries(jobs)) {
    assert.equal(env(job).RESULTS_TOKEN, undefined, `${name}: not in the environment of a whole job`);
    for (const step of job.steps) {
      if (!('RESULTS_TOKEN' in env(step))) continue;
      readers += 1;
      assert.equal(env(step).RESULTS_TOKEN, '${{ secrets.RESULTS_TOKEN }}');
      assert.match(step.run, /scripts\/customer-build\/results\.mjs (download-inputs|upload|finish)/, `${name} / ${step.name}: only the steps that talk to the results place may hold the token`);
      // Not a step that builds or checks anything.
      assert.doesNotMatch(step.run, /make-website-package|smoke-website|audit-|npm |gradlew|android-config|make-icons/, `${name} / ${step.name}`);
    }
  }
  assert.ok(readers >= 5, 'download, upload and finish all read it');
  // Every other secret is the Android signing material, read by the step that makes the signing key and by no other.
  for (const [, job] of Object.entries(jobs)) for (const step of job.steps) {
    for (const [k, v] of Object.entries(env(step))) if (/secrets\./.test(String(v)) && k !== 'RESULTS_TOKEN') assert.ok(/^(KEYSTORE_B64|KEYSTORE_PASSWORD|KEY_ALIAS|KEY_PASSWORD)$/.test(k) && step.id === 'signing', `${step.name}: ${k}`);
  }
  // The token is never printed or switched on in a trace.
  assert.doesNotMatch(text, /echo[^\n]*RESULTS_TOKEN|printf[^\n]*RESULTS_TOKEN|set -x|set -o xtrace|ACTIONS_STEP_DEBUG|ACTIONS_RUNNER_DEBUG/);
});

test('what a person typed reaches a script only through the environment, never inside the text of a script', () => {
  for (const [name, job] of Object.entries(jobs)) for (const step of job.steps) {
    if (step.run !== undefined) assert.doesNotMatch(step.run, /\$\{\{/, `${name} / ${step.name}: no \${{ }} inside a script`);
  }
  // The dispatch inputs appear in the group name and as environment values, nowhere else.
  for (const line of text.split('\n').filter((l) => /\$\{\{\s*inputs\./.test(l))) {
    assert.match(line, /^\s+group: customer-\$\{\{ inputs\.customer \}\}$|^\s+[A-Z_]+: \$\{\{ inputs\.\w+ \}\}$/, line);
  }
  // The values the first job checked reach the other jobs through the environment too.
  for (const line of text.split('\n').filter((l) => /\$\{\{\s*needs\.inputs\.outputs\./.test(l))) {
    assert.ok(/^\s+(if: \$\{\{.*\}\}|[A-Z_]+: \$\{\{ needs\.inputs\.outputs\.\w+ \}\})$/.test(line), line);
  }
});

test('nothing about a customer, no repository name and no token is written in the file', () => {
  const identity = new RegExp(['smart ?aven', 'smartaven', 'smart_aven'].map((x) => x).join('|'), 'i');
  assert.doesNotMatch(text, identity, 'a customer\'s identity lives only in that customer\'s settings');
  for (const word of ['example-shop', 'luzon', 'brand-kits', '--kit', 'smartave99', 'gmail.com', 'nextgenos-customer-builds', 'NextGenOS-Smart-Retail-OS']) assert.ok(!text.includes(word), `the file must not name ${word}`);
  assert.deepEqual(findSecrets(text), [], 'no key, token or password');
  assert.doesNotMatch(text, /\bghp_|github_pat_|\bgho_|\bghs_/);
  // The only repository the workflow touches besides its own arrives as an input.
  assert.doesNotMatch(text, /github\.com\/[\w.-]+\/[\w.-]+/);
  // Nothing is assumed about the shop: no country, no currency, no language is chosen here.
  assert.doesNotMatch(text, /NEXT_PUBLIC_|--country|--industry|--currency|--language/);
});

test('the first job reads the licence keys state, takes the settings, checks them, and stops the whole build when they are refused', () => {
  const ids = stepsOf('inputs').map((s) => s.id).filter(Boolean);
  assert.deepEqual(ids, ['start', 'keys', 'download', 'check']);
  assert.match(find('inputs', 'keys').run, /validate-inputs\.mjs keys --report-only$/);
  const keysStop = stepsOf('inputs')[index('inputs', 'keys') + 1];
  assert.equal(keysStop.if, "${{ steps.keys.outputs.keys_problem != '' }}");
  assert.equal(keysStop.run, 'exit 1');
  assert.equal(env(find('inputs', 'keys')).DEFAULT_BRANCH, '${{ github.event.repository.default_branch }}');
  assert.match(find('inputs', 'download').run, /results\.mjs download-inputs --out "\$\{RUNNER_TEMP\}\/inputs\.zip"/);
  assert.match(find('inputs', 'check').run, /validate-inputs\.mjs check --zip .* --out .* --report-only$/);
  const stop = stepsOf('inputs').at(-1);
  assert.equal(stop.if, "${{ steps.check.outputs.ok != 'true' }}");
  assert.equal(stop.run, 'exit 1');
  // The licence keys are public values read from variables, never from secrets.
  assert.equal(env(find('inputs', 'keys')).NGOS_PUBLIC_KEYS, '${{ vars.NGOS_PUBLIC_KEYS }}');
  assert.equal(env(find('inputs', 'keys')).NGOS_LICENCE_URL, '${{ vars.NGOS_LICENCE_URL }}');
  for (const out of ['ok', 'website', 'android', 'version', 'message', 'trial', 'started_at']) assert.ok(jobs.inputs.outputs[out], out);
});

test('the website is built on the system it is for, as the Release workflow builds it, from the customer\'s settings, and is put in the results place only after it was tried', () => {
  const j = jobs.website;
  assert.equal(j.strategy['fail-fast'], false, 'one system failing does not stop the other');
  assert.deepEqual(j.strategy.matrix.include.map((m) => [m.os, m.runner]), [['linux', 'ubuntu-latest'], ['windows', 'windows-latest']]);
  assert.equal(j['runs-on'], '${{ matrix.runner }}');
  const build = find('website', 'build').run;
  assert.match(build, /node scripts\/make-website-package\.mjs --os "\$\{OS\}" --version "\$\{VERSION_NAME\}" --customer "\$\{CUSTOMER\}" --settings "\$\{RUNNER_TEMP\}\/inputs\/website-settings\.env"/);
  assert.match(build, /--logo "\$\{RUNNER_TEMP\}\/inputs\/logo\.png"/);
  assert.match(build, /--download-node 22\.22\.0/);
  assert.doesNotMatch(build, /--kit/);
  // Without the licence keys: the package is a trial; with them they are built in first, as the Release workflow does.
  assert.match(build, /if \[ "\$\{TRIAL\}" = "true" \]; then EXTRA="--allow-no-key"; fi/);
  assert.equal(find('website', 'keys').if, "${{ needs.inputs.outputs.trial != 'true' }}");
  assert.match(find('website', 'keys').run, /node licensing\/studio\/src\/cli\.js apply-public-keys --keys "@\$\{RUNNER_TEMP\}\/keys\.json" --url "\$\{NGOS_LICENCE_URL\}"/);
  assert.equal(env(j).TRIAL, '${{ needs.inputs.outputs.trial }}');
  // The Windows launcher tool is only for Windows, and the two audits, the start from the zip and the window like a person's run on the finished package.
  assert.equal(find('website', 'launcher').if, "${{ matrix.os == 'windows' }}");
  assert.match(find('website', 'launcher').run, /choco install nsis/);
  assert.match(find('website', 'audit').run, /node scripts\/audit-package\.mjs .* --node-app/);
  assert.match(find('website', 'audit').run, /node scripts\/audit-prerequisites\.mjs .* --os "\$\{OS\}"/);
  assert.equal(find('website', 'smoke').if, "${{ matrix.os == 'linux' }}");
  assert.match(find('website', 'smoke').run, /node scripts\/smoke-website\.mjs .* --os linux/);
  assert.equal(find('website', 'smoke_windows').if, "${{ matrix.os == 'windows' }}");
  assert.match(find('website', 'smoke_windows').run, /node scripts\/smoke-website\.mjs .* --os windows/);
  assert.equal(find('website', 'window').if, "${{ matrix.os == 'windows' }}");
  assert.match(find('website', 'window').run, /Start Website\.exe/);
  assert.match(find('website', 'window').run, /msedge\.exe/);
  // Order: settings, keys, tool, build, audits, tries, and only then the files go to the results place; the report is last.
  const order = ['settings', 'keys', 'launcher', 'build', 'audit', 'smoke', 'smoke_windows', 'window', 'put'].map((id) => index('website', id));
  assert.deepEqual(order, [...order].sort((a, b) => a - b));
  assert.match(find('website', 'put').run, /results\.mjs upload --files "\$\{RUNNER_TEMP\}\/website-out\/website-\$\{CUSTOMER\}-\$\{OS\}\.zip"/);
  // The report names the part by its system, and gives it every step it may have stopped at.
  const report = stepsOf('website').find((s) => /result\.mjs part/.test(s.run));
  assert.match(report.run, /--part "website-\$\{OS\}"/);
  for (const id of ['settings', 'keys', 'launcher', 'build', 'audit', 'smoke', 'smoke_windows', 'window', 'put']) assert.ok(env(report).STEPS.includes(`\${{ steps.${id}.outcome }}`), id);
});

test('the Android app is built from the customer\'s brand and logo in the settings, with the build number as its version code', () => {
  const j = jobs.android;
  assert.equal(j['runs-on'], 'ubuntu-latest');
  const configure = find('android', 'configure');
  assert.equal(configure['working-directory'], 'apps/storefront-web-mobile');
  assert.match(configure.run, /BRAND="\$\{RUNNER_TEMP\}\/inputs\/brand\.json"/);
  for (const field of ['.android.appId', '.name', '.android.storefrontUrl', '.primaryColor']) assert.ok(configure.run.includes(`jq -r '${field}'`), field);
  assert.match(configure.run, /node scripts\/android-config\.mjs --app-id "\$\{APP_ID\}" --app-name "\$\{APP_NAME\}" --url "\$\{STOREFRONT_URL\}" --version-name "\$\{VERSION_NAME\}" --version-code "\$\{BUILD\}"/);
  assert.match(configure.run, /--logo "\$\{RUNNER_TEMP\}\/inputs\/logo\.png"/);
  assert.match(configure.run, /node scripts\/make-icons\.mjs .*--colour "\$\{BRAND_COLOUR\}" --android/);
  assert.doesNotMatch(configure.run, /brand-kits/);
  assert.match(find('android', 'build').run, /\.\/gradlew assembleRelease bundleRelease/);
  assert.match(find('android', 'check').run, /apksigner" verify/);
  assert.match(find('android', 'check').run, /usesCleartextTraffic/);
  assert.match(find('android', 'name').run, /SmartRetailPOS-\$\{CUSTOMER\}-\$\{VERSION_NAME\}\.apk/);
  assert.match(find('android', 'name').run, /ANDROID-SIGNING\.txt/);
  const order = ['settings', 'install', 'configure', 'sync', 'signing', 'build', 'check', 'name', 'put'].map((id) => index('android', id));
  assert.deepEqual(order, [...order].sort((a, b) => a - b));
  // The signing key comes from the owner's secrets, or is a one-off test key that the notes say so about.
  assert.match(find('android', 'signing').run, /one-off TEST key/);
});

test('every part carries the same version: the product\'s two numbers and the build number', () => {
  assert.match(wf.env.PROGRAM_VERSION_BASE, /^\d+\.\d+$/);
  assert.equal(env(jobs.website).VERSION_NAME, '${{ needs.inputs.outputs.version }}');
  assert.equal(env(jobs.android).VERSION_NAME, '${{ needs.inputs.outputs.version }}');
});

test('the last job tells the Setup Studio everything it needs: the customer, the build, the commit, the time, the keys state, and how every job ended', () => {
  const finish = stepsOf('publish').at(-1);
  const e = env(finish);
  for (const k of ['CUSTOMER', 'BUILD', 'RESULTS_REPO', 'SOURCE_COMMIT', 'STARTED_AT', 'TRIAL', 'WEBSITE_REQUESTED', 'ANDROID_REQUESTED', 'INPUTS_RESULT', 'INPUTS_MESSAGE', 'WEBSITE_RESULT', 'ANDROID_RESULT']) assert.ok(e[k], k);
  assert.equal(e.SOURCE_COMMIT, '${{ github.sha }}');
  assert.equal(e.INPUTS_RESULT, '${{ needs.inputs.result }}');
  assert.equal(e.WEBSITE_RESULT, '${{ needs.website.result }}');
  assert.equal(e.ANDROID_RESULT, '${{ needs.android.result }}');
});

test('every action is pinned to a major version and every script the workflow runs exists', () => {
  for (const [name, job] of Object.entries(jobs)) for (const step of job.steps) {
    if (step.uses) assert.match(step.uses, /^(actions\/[\w-]+|android-actions\/[\w-]+)@v\d+$/, `${name}: ${step.uses}`);
  }
  for (const [name, job] of Object.entries(jobs)) for (const step of job.steps) {
    for (const m of (step.run ?? '').matchAll(/(?:node|node\.exe)\s+((?:scripts|licensing)\/[\w./-]+\.(?:mjs|js))/g)) {
      const base = step['working-directory'] && !step['working-directory'].includes('${{') ? step['working-directory'] : '.';
      assert.ok(existsSync(join(root, base, m[1])), `${name} / ${step.name}: ${m[1]} is not in ${base}`);
    }
  }
  for (const [name, job] of Object.entries(jobs)) assert.ok(Number(job['timeout-minutes']) > 0, `${name} has a time limit`);
});

test('the helper scripts the workflow calls are the tested ones', () => {
  const used = new Set([...text.matchAll(/scripts\/customer-build\/([\w-]+\.mjs)/g)].map((m) => m[1]));
  assert.deepEqual([...used].sort(), ['result.mjs', 'results.mjs', 'validate-inputs.mjs']);
  for (const f of used) assert.ok(existsSync(join(root, 'scripts', 'customer-build', f)));
});
