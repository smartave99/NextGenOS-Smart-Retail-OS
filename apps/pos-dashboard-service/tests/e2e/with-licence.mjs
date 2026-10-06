#!/usr/bin/env node
// Runs the dashboard's browser tests the way a customer's PC runs the dashboard: with the licence gate in front of everything and a
// real licence from a real Licence Studio. Without a licence the dashboard answers every page with 402 ("No licence was found"), so a test
// that starts it and waits for the home page never gets past that: that is why these tests could not start the app once the dashboard
// was put behind the licence.
//
//   node licensing/e2e/with-studio.mjs -- node apps/pos-dashboard-service/tests/e2e/with-licence.mjs posters.e2e.js photos.e2e.js
//   (or, in this folder:  npm run test:licensed -- posters.e2e.js)
//
// Nothing in the repository is changed. The programs' sources are copied to a throw-away folder, the throw-away Studio's public key is
// built into the COPY of the licence library (the same "sync-clients" step an owner does before a release, pointed at the copy with
// NGOS_REPO_ROOT), the copy is built, a licence for the "dashboard" module is made in the Studio and activated through the app's own
// activation page, and then each test file (also the copy) is run. The tests start the app from "../../src/SmartRetail.Pos.Web" next
// to themselves, so they start the copy. The licence files the activation writes (the PC's shared licence folder) are removed at the end.
//
// Needs Playwright where Node can find it (NODE_PATH) and its browsers (PLAYWRIGHT_BROWSERS_PATH), as the tests do on their own.
// Ends with 0 when every test passed, 1 when one failed, 3 when none failed but some did not run (a test that needs Docker or a Supabase
// folder says "Skipped:"; it is listed as SKIPPED, not verified, never as passed).
import { spawn, spawnSync } from 'node:child_process';
import { cpSync, existsSync, mkdtempSync, mkdirSync, readdirSync, readFileSync, rmSync } from 'node:fs';
import { tmpdir, homedir } from 'node:os';
import { join, resolve, dirname, basename } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const repo = resolve(here, '..', '..', '..', '..');
const APP_PORT = 5080; // the tests' own address (they all use http://127.0.0.1:5080)
const ACTIVATION_PORT = 5081;
const tests = process.argv.slice(2).filter((a) => !a.startsWith('--'));
if (!process.env.NGOS_E2E_URL) { console.error('Run through licensing/e2e/with-studio.mjs (it starts the throw-away Licence Studio).'); process.exit(2); }
if (tests.length === 0) { console.error('Say which test files to run, for example: with-licence.mjs posters.e2e.js photos.e2e.js'); process.exit(2); }
for (const t of tests) {
  if (!/^[\w.-]+\.e2e\.js$/.test(t) || !existsSync(join(here, t))) { console.error(`There is no browser test called "${t}" in ${here}.`); process.exit(2); }
}

// The licence files a program on this PC writes (Linux: /usr/share when allowed, else the person's own folder). Leave no trace of the test.
const licenceDirs = [join('/usr/share', 'NextGenOS', 'SmartRetailPOS'), join(process.env.XDG_DATA_HOME || join(homedir(), '.local', 'share'), 'NextGenOS', 'SmartRetailPOS')];
const inUse = licenceDirs.filter((d) => existsSync(d) && readdirSync(d).length > 0);
if (inUse.length) { console.error(`A licence is already stored on this PC (${inUse.join(', ')}); this test will not touch it. Move it away and run again.`); process.exit(2); }

const answers = async (port) => { try { await fetch(`http://127.0.0.1:${port}/`); return true; } catch { return false; } };
if (await answers(APP_PORT)) {
  console.error(`Something already answers on http://127.0.0.1:${APP_PORT}. The browser tests start the dashboard there themselves: stop that program first (a test that failed earlier may have left one running).`);
  process.exit(2);
}

const studioCli = (...args) => {
  const [cmd, ...base] = process.env.NGOS_E2E_CLI.split(' ');
  const r = spawnSync(cmd, [...base, ...args], { env: { ...process.env, STUDIO_DATA: process.env.NGOS_E2E_DATA, NGOS_REPO_ROOT: work, NODE_NO_WARNINGS: '1' }, encoding: 'utf8' });
  if (r.status !== 0) throw new Error(`Studio command ${args.join(' ')} failed: ${r.stderr}${r.stdout}`);
  return r.stdout.trim();
};

const work = mkdtempSync(join(tmpdir(), 'ngos-dashboard-licensed-'));
const copyFilter = (src) => !['bin', 'obj', 'node_modules', 'screenshots', '.vs'].includes(basename(src));
const stopAppsOf = (folder) => {
  // Any program of this run's copy that a failed test left behind (a test that cannot start the app does not stop it).
  if (!existsSync('/proc')) return;
  for (const pid of readdirSync('/proc').filter((n) => /^\d+$/.test(n))) {
    try {
      const cmd = readFileSync(`/proc/${pid}/cmdline`, 'latin1');
      if (cmd.includes(folder)) process.kill(Number(pid), 'SIGKILL');
    } catch { /* gone, or not ours */ }
  }
};

// Runs one test file, showing what it prints as it goes and keeping it to look at afterwards.
function runTest(file, out) {
  return new Promise((done) => {
    let output = '';
    const child = spawn('node', [file, out], { cwd: dirname(file), env: process.env, stdio: ['ignore', 'pipe', 'inherit'] });
    const timer = setTimeout(() => child.kill('SIGKILL'), 1_200_000);
    child.stdout.on('data', (d) => { output += d; process.stdout.write(d); });
    child.on('exit', (status) => { clearTimeout(timer); done({ status: status ?? 1, output }); });
  });
}

let code = 1;
try {
  // 1. A private copy of what the dashboard is built from. The tests are copied too: they start the app from the folder they are in.
  const copy = (rel) => { cpSync(join(repo, rel), join(work, rel), { recursive: true, filter: copyFilter }); };
  copy(join('apps', 'pos-dashboard-service'));
  copy(join('apps', 'pos-ai-companion', 'Directory.Build.props'));
  copy(join('apps', 'pos-ai-companion', 'src', 'SmartRetail.AI.Core'));
  copy(join('licensing', 'clients', 'dotnet', 'NextGenOS.Licensing'));
  copy(join('licensing', 'clients', 'dotnet', 'NextGenOS.Licensing.AspNetCore'));
  copy('CHANGELOG.md');
  console.log('Copied the dashboard sources to a throw-away folder.');

  // 2. The Studio's public key and address, built into the copy of the licence library only.
  console.log(studioCli('sync-clients', '--url', process.env.NGOS_E2E_URL).split('\n')[0]);
  const web = join(work, 'apps', 'pos-dashboard-service', 'src', 'SmartRetail.Pos.Web');
  const built = spawnSync('dotnet', ['build', web, '--nologo', '-v', 'q'], { cwd: work, encoding: 'utf8', maxBuffer: 64 * 1024 * 1024 });
  if (built.status !== 0) { console.error((built.stdout || '').slice(-4000) + (built.stderr || '').slice(-2000)); throw new Error('The copy of the dashboard did not build.'); }
  console.log('Built the copy with the Studio\'s key.');

  // 3. A licence with the dashboard module, activated through the app's own activation page (the page every customer sees).
  const lic = JSON.parse(studioCli('create-licence', '--customer', 'Browser test shop', '--country', 'Philippines', '--plan', 'business', '--devices', '2', '--white', 'theme'));
  const activator = spawn('dotnet', ['run', '--project', web, '--no-build', '--no-launch-profile'], {
    cwd: web, stdio: 'ignore', detached: true,
    env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Development', Pos__Mode: 'Demo', Kestrel__Endpoints__Http__Url: `http://127.0.0.1:${ACTIVATION_PORT}` },
  });
  try {
    let up = false;
    for (let i = 0; i < 90 && !up; i += 1) { up = await answers(ACTIVATION_PORT); if (!up) await new Promise((r) => setTimeout(r, 1000)); }
    if (!up) throw new Error('The dashboard did not start for the activation.');
    const asked = await fetch(`http://127.0.0.1:${ACTIVATION_PORT}/`);
    if (asked.status !== 402) throw new Error(`The dashboard should have asked for a licence (402), it answered ${asked.status}.`);
    const done = await fetch(`http://127.0.0.1:${ACTIVATION_PORT}/licence-activate`, { method: 'POST', redirect: 'manual', headers: { 'content-type': 'application/x-www-form-urlencoded' }, body: new URLSearchParams({ key: lic.key }) });
    if (done.status !== 302) throw new Error(`The licence key was not accepted (status ${done.status}): ${(await done.text()).replace(/<[^>]+>/g, ' ').replace(/\s+/g, ' ').slice(0, 400)}`);
    const open = await fetch(`http://127.0.0.1:${ACTIVATION_PORT}/`);
    if (!open.ok) throw new Error(`After activation the dashboard still answers ${open.status}.`);
    console.log('Activated a "business" licence (dashboard module) from the Studio; the dashboard opens.');
  } finally {
    try { process.kill(-activator.pid, 'SIGKILL'); } catch { /* gone */ }
  }
  for (let i = 0; i < 20 && (await answers(ACTIVATION_PORT)); i += 1) await new Promise((r) => setTimeout(r, 250));

  // 4. The tests, one after the other, from the copy.
  const results = [];
  const screenshots = join(work, 'screenshots');
  for (const t of tests) {
    console.log(`\n=== ${t}`);
    const out = join(screenshots, t.replace(/\.e2e\.js$/, ''));
    mkdirSync(out, { recursive: true });
    const r = await runTest(join(work, 'apps', 'pos-dashboard-service', 'tests', 'e2e', t), out);
    // A test that cannot run here (it needs Docker, a Supabase folder ...) says "Skipped:" and ends well: that is not a pass.
    results.push([t, r.status !== 0 ? `FAILED (exit ${r.status})` : /^Skipped:/m.test(r.output) ? 'SKIPPED (not verified)' : 'passed']);
    stopAppsOf(work); // never leave the port taken for the next test
    for (let i = 0; i < 20 && (await answers(APP_PORT)); i += 1) await new Promise((r2) => setTimeout(r2, 250));
    if (r.status !== 0 && existsSync(out) && readdirSync(out).length) {
      // Keep what a failed test showed: copy the screenshots next to the tests (the folder is not part of the repository's files).
      const keep = join(here, 'screenshots', t.replace(/\.e2e\.js$/, ''));
      mkdirSync(keep, { recursive: true });
      cpSync(out, keep, { recursive: true });
    }
  }
  console.log('\nBrowser tests with the licence gate in front:');
  for (const [t, s] of results) console.log(`  ${s.padEnd(24)} ${t}`);
  // 0: every test passed. 1: one failed. 3: none failed, but some did not run (they are not verified).
  code = results.some(([, s]) => s.startsWith('FAILED')) ? 1 : results.some(([, s]) => s.startsWith('SKIPPED')) ? 3 : 0;
} catch (e) {
  console.error(String(e.message || e));
} finally {
  stopAppsOf(work);
  licenceDirs.forEach((d) => { try { rmSync(d, { recursive: true, force: true }); } catch { /* nothing to remove */ } });
  rmSync(work, { recursive: true, force: true });
}
process.exit(code);
