#!/usr/bin/env node
/**
 * Checks the Hub's Linux package for real: it is built, installed with dpkg on THIS machine, started the way the service starts it (as its own account, with the
 * settings of the installed service file), then the customer's profile package is installed beside it, and everything is removed again.
 *   node apps/business-hub/installer/test-linux-package.mjs [--deb <a package already built>]
 *
 * What it proves: the package installs on a plain Debian-family system; its program folder cannot be changed by the account the Hub runs as, and its shop-data folder
 * can be used by that account and by no one else; the program starts as that account and refuses to work without a licence; the profile package adds only its files;
 * removing the program keeps the shop's data. What it cannot prove: starting under a real systemd, a real desktop, a browser, a printer (docs/SETUP-STUDIO.md lists them).
 * It changes this machine (installs, then removes, a package and one account), so it needs root (or passwordless sudo) and refuses to run where the Hub is already installed.
 */
import { spawn, spawnSync } from 'node:child_process';
import { existsSync, mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve } from 'node:path';
import net from 'node:net';
import { here, repo } from './common.mjs';
import { profileDeb } from '../../../tools/setup-studio/lib/pack.mjs';
import { checkIntake } from '../../../tools/setup-studio/lib/intake.mjs';

const args = process.argv.slice(2);
const given = args.includes('--deb') ? resolve(args[args.indexOf('--deb') + 1]) : null;
const isRoot = process.getuid?.() === 0;
const sudo = (cmd, a) => (isRoot ? spawnSync(cmd, a, { encoding: 'utf8' }) : spawnSync('sudo', ['-n', cmd, ...a], { encoding: 'utf8' }));
const quiet = (cmd, a) => spawnSync(cmd, a, { encoding: 'utf8' });

let failures = 0;
const check = (what, ok, detail = '') => { console.log(`${ok ? 'PASS' : 'FAIL'}  ${what}${ok ? '' : '  ' + String(detail).slice(0, 1500)}`); if (!ok) failures += 1; };
const sleep = (ms) => new Promise((r) => setTimeout(r, ms));

if (process.platform !== 'linux' || quiet('dpkg', ['--version']).status !== 0) { console.error('This check needs a Debian-family Linux with dpkg (Ubuntu, Linux Mint, Debian).'); process.exit(2); }
if (!isRoot && sudo('true', []).status !== 0) { console.error('This check installs a package, so it needs root or passwordless sudo.'); process.exit(2); }
// Never touch a real installation.
if (quiet('dpkg', ['-s', 'smart-retail-pos-hub']).status === 0 || existsSync('/var/lib/nextgenos') || quiet('getent', ['passwd', 'nextgenos']).status === 0) {
  console.error('The Hub (or its account or data folder) is already on this machine. This check will not touch a real installation: run it on a clean machine.');
  process.exit(2);
}

const work = mkdtempSync(join(tmpdir(), 'hub-linux-test-'));
let installed = false;
try {
  const arch = quiet('dpkg', ['--print-architecture']).stdout.trim();
  let deb = given;
  if (!deb) {
    console.log('== building the package');
    const b = spawnSync('node', [join(here, 'build-linux.mjs'), '--version', '1.0.0', '--arch', arch === 'arm64' ? 'arm64' : 'x64', '--out', work, '--allow-no-key'], { cwd: repo, encoding: 'utf8', maxBuffer: 128 * 1024 * 1024 });
    check('the package builds (publish, hide names, prerequisite audit, package audit)', b.status === 0, (b.stdout + b.stderr).slice(-2500));
    if (b.status !== 0) throw new Error('no package');
    deb = join(work, `smart-retail-pos-hub_1.0.0-1_${arch}.deb`);
  }
  console.log('== the package');
  const field = (f) => quiet('dpkg-deb', ['-f', deb, f]).stdout.trim();
  check('it is named, versioned and made for this processor', field('Package') === 'smart-retail-pos-hub' && field('Architecture') === arch, `${field('Package')} ${field('Architecture')}`);
  check('it asks the system only for the base system (no .NET, no libraries beyond the C and C++ runtime and openssl)', /^libc6 .*libgcc-s1, libstdc\+\+6, libssl3 \| libssl3t64, systemd$/.test(field('Depends')), field('Depends'));
  const list = quiet('dpkg-deb', ['-c', deb]).stdout;
  for (const want of ['/lib/systemd/system/nextgenos-hub.service', '/usr/bin/smart-retail-pos', '/usr/share/applications/smart-retail-pos.desktop', '/usr/share/applications/smart-retail-pos-fullscreen.desktop', '/opt/nextgenos/smart-retail-hub/NextGenOS.Hub', '/opt/nextgenos/smart-retail-hub/prerequisites.json', '/usr/share/doc/smart-retail-pos-hub/copyright']) check(`it holds ${want}`, list.includes('.' + want));
  check('it holds no debugging or memory-dump helper', !/createdump|libmscordbi|libmscordaccore|libcoreclrtraceptprovider/.test(list));

  console.log('== installing');
  const dpkg = sudo('dpkg', ['-i', deb]);
  installed = true;
  check('dpkg installs it (with no systemd running, as in a container, the scripts still finish)', dpkg.status === 0, dpkg.stdout + dpkg.stderr);
  if (dpkg.status !== 0) throw new Error('not installed');
  // The shop's data folders are closed to everyone but the Hub's account, so on a machine where this check does not run as root (GitHub's runner) only root can look inside them.
  const stat = (p, f) => sudo('stat', ['-c', f, p]).stdout.trim();
  const exists = (p) => sudo('test', ['-e', p]).status === 0;
  check('the Hub has its own account that cannot sign in', /nologin/.test(quiet('getent', ['passwd', 'nextgenos']).stdout));
  check('the shop data folder belongs to that account and is closed to everyone else (0750)', stat('/var/lib/nextgenos/hub', '%U %a') === 'nextgenos 750', stat('/var/lib/nextgenos/hub', '%U %a'));
  check('the program folder belongs to root', stat('/opt/nextgenos/smart-retail-hub/NextGenOS.Hub', '%U %a') === 'root 755', stat('/opt/nextgenos/smart-retail-hub/NextGenOS.Hub', '%U %a'));
  const as = (user, a) => sudo('runuser', ['-u', user, '--', ...a]);
  check('the Hub\'s account can read the program but cannot change or add anything in its folder', as('nextgenos', ['test', '-x', '/opt/nextgenos/smart-retail-hub/NextGenOS.Hub']).status === 0 && as('nextgenos', ['sh', '-c', 'touch /opt/nextgenos/smart-retail-hub/x 2>/dev/null || exit 0; exit 1']).status === 0 && !existsSync('/opt/nextgenos/smart-retail-hub/x'));
  check('the Hub\'s account can write its shop data', as('nextgenos', ['touch', '/var/lib/nextgenos/hub/keep-me.txt']).status === 0);
  check('another account cannot even list the shop data', as('nobody', ['sh', '-c', 'ls /var/lib/nextgenos/hub > /dev/null 2>&1 && exit 1; exit 0']).status === 0);
  const verify = quiet('systemd-analyze', ['verify', '/lib/systemd/system/nextgenos-hub.service']);
  if (verify.error) console.log('NOTE  systemd-analyze is not installed here: the service file was not syntax-checked');
  else check('the service file is valid for systemd', verify.status === 0 && !/Unknown key|Unknown section|Failed to|not found/i.test(verify.stdout + verify.stderr), verify.stdout + verify.stderr);

  // Starts the installed program the way the service file says (its account, its settings), on a free port.
  const unit = readFileSync('/lib/systemd/system/nextgenos-hub.service', 'utf8');
  const envPairs = [...unit.matchAll(/^Environment=(.+)$/gm)].map((m) => m[1]);
  const exec = /^ExecStart=(.+)$/m.exec(unit)[1];
  const port = await new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); });
  const startHub = async () => {
    const cmd = ['runuser', '-u', 'nextgenos', '--', 'env', ...envPairs, exec, `--Kestrel:Endpoints:Http:Url=http://127.0.0.1:${port}`, '--Logging:LogLevel:Default=Warning'];
    const child = spawn(isRoot ? cmd[0] : 'sudo', isRoot ? cmd.slice(1) : ['-n', ...cmd], { detached: true, stdio: ['ignore', 'pipe', 'pipe'] });
    let log = ''; let code = null;
    child.stdout.on('data', (d) => { log += d; }); child.stderr.on('data', (d) => { log += d; });
    child.on('exit', (c) => { code = c; });
    let response = null;
    for (let i = 0; i < 90 && code === null && !response; i += 1) {
      try { response = await fetch(`http://127.0.0.1:${port}/`, { headers: { accept: 'text/html' }, redirect: 'manual' }); } catch { await sleep(500); }
    }
    return { child, log: () => log, exited: () => code, response };
  };
  const stopHub = async (h) => {
    try { process.kill(-h.child.pid, 'SIGTERM'); } catch { /* it already stopped */ }
    sudo('pkill', ['-u', 'nextgenos']);
    for (let i = 0; i < 20 && h.exited() === null; i += 1) await sleep(250);
  };

  console.log('== starting it as the service does');
  let hub = await startHub();
  check('the installed program starts as its own account', hub.response !== null, hub.exited() !== null ? `it stopped with code ${hub.exited()}\n${hub.log().slice(-1500)}` : 'no answer in 45 seconds\n' + hub.log().slice(-1500));
  if (hub.response) {
    const text = await hub.response.text();
    check('with no licence it answers 402 and asks for a key, in plain words', hub.response.status === 402 && /needs a licence/i.test(text) && /name="key"/.test(text), String(hub.response.status));
    check('it listens on this machine only', !/0\.0\.0\.0|\[::\]/.test(hub.log()));
  }
  await stopHub(hub);

  console.log('== the profile package for one customer');
  const intake = checkIntake({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail' }, device: { kind: 'touch-pos', os: 'linux', screen: 'standard' }, look: { primaryColor: '#0a7d4b' } }).value;
  const files = { 'setup.json': Buffer.from('{"schema":1}\n'), 'theme.json': Buffer.from('{"schema":1,"shape":"pill"}\n'), 'brand.json': Buffer.from('{"schema":1,"name":"Luzon Fresh Mart","primaryColor":"#0a7d4b"}\n') };
  const profile = profileDeb({ customerId: 'luzon-fresh-mart', intake, info: { n: 3, bundleHash: 'ab'.repeat(32) }, files, company: { name: 'Pinoy POS Partners' } });
  const profilePath = join(work, profile.name);
  writeFileSync(profilePath, profile.data);
  const p = sudo('dpkg', ['-i', profilePath]);
  check('the profile package installs', p.status === 0, p.stdout + p.stderr);
  const dir = '/opt/nextgenos/smart-retail-hub/profile';
  check('it puts the three profile files and a note beside the program, readable by the Hub', ['setup.json', 'theme.json', 'brand.json', 'release.txt'].every((f) => existsSync(`${dir}/${f}`) && as('nextgenos', ['test', '-r', `${dir}/${f}`]).status === 0));
  check('they are the files that were made, byte for byte', readFileSync(`${dir}/brand.json`, 'utf8') === files['brand.json'].toString());
  check('a touch till starts the program full screen when someone signs in', existsSync('/etc/xdg/autostart/smart-retail-pos-fullscreen.desktop'));
  hub = await startHub();
  check('the program still starts, with the profile beside it', hub.response !== null && hub.response.status === 402, hub.log().slice(-1200));
  await stopHub(hub);

  console.log('== removing it');
  const rm = sudo('dpkg', ['-r', 'smart-retail-pos-hub']);
  check('removing the program works', rm.status === 0, rm.stdout + rm.stderr);
  check('the program and its service file are gone', !existsSync('/opt/nextgenos/smart-retail-hub/NextGenOS.Hub') && !existsSync('/lib/systemd/system/nextgenos-hub.service') && !existsSync('/usr/bin/smart-retail-pos'));
  check('the profile package is still there on its own', existsSync(`${dir}/theme.json`));
  const purge = sudo('dpkg', ['-P', 'smart-retail-pos-hub', 'smart-retail-profile-luzon-fresh-mart']);
  check('purging both works', purge.status === 0, purge.stdout + purge.stderr);
  check('the profile files and the full screen start-up are gone', !existsSync(`${dir}/theme.json`) && !existsSync('/etc/xdg/autostart/smart-retail-pos-fullscreen.desktop'));
  check('the shop\'s data is still there, even after a purge', exists('/var/lib/nextgenos/hub/keep-me.txt'));
  installed = false;
} catch (e) {
  if (!['no package', 'not installed'].includes(e.message)) { console.error(String(e.stack || e)); failures += 1; }
} finally {
  // Put this machine back as it was: only what this check made.
  if (installed) { sudo('dpkg', ['-P', 'smart-retail-pos-hub']); sudo('dpkg', ['-P', 'smart-retail-profile-luzon-fresh-mart']); }
  sudo('systemctl', ['stop', 'nextgenos-hub.service']);
  sudo('pkill', ['-u', 'nextgenos']);
  sudo('userdel', ['nextgenos']);
  sudo('groupdel', ['nextgenos']);
  sudo('rm', ['-rf', '--', '/var/lib/nextgenos']);
  rmSync(work, { recursive: true, force: true });
}
if (failures) { console.log(`\n${failures} check(s) failed`); process.exit(1); }
console.log('\nAll Linux package checks passed (real dpkg and a real unprivileged account; not under a real systemd or a desktop).');
