// Release-gate checks for what a customer receives: the package audit works, the Hub is hidden and still runs, and it is brought into use with
// a real licence from the real Licence Studio. (CLAUDE.md, section 3: no source in anything a customer receives.)

import { browserProblem } from '../lib/playwright.mjs';
import { findObfuscar } from '../lib/obfuscar.mjs';

export function checks({ root, sh, has, runCmd, join, existsSync }) {
  const e2e = join(root, 'apps', 'business-hub', 'e2e');
  const needTools = () => {
    if (!has('dotnet') || !has('node')) return 'dotnet or node is not installed here';
    if (!findObfuscar()) return 'the obfuscator (Obfuscar) is not installed and could not be installed here (dotnet tool install --global Obfuscar.GlobalTool --version 2.2.50)';
    return browserProblem({ sh, join, existsSync, dir: e2e });
  };

  return [
    {
      name: 'package-audit-tests',
      title: 'The package audit catches source, tests, keys, databases, licences and secrets (and passes a clean package), and the history scan finds a secret that was committed and later deleted, and the release page is written from the files that were really built',
      run: () => {
        const r = runCmd('package-audit-tests', 'node', ['--test', 'scripts/tests/audit-package.test.mjs', 'scripts/tests/scan-history.test.mjs', 'scripts/tests/release-assets.test.mjs', 'scripts/tests/make-release-notes.test.mjs', 'scripts/tests/build-launcher.test.mjs', 'scripts/tests/hub-launcher.test.mjs']);
        if (r.status !== 'PASS') return r;
        const n = /# pass (\d+)/.exec(r.out);
        return { status: 'PASS', detail: `${n ? n[1] : 'all'} audit tests passed` };
      },
    },
    {
      name: 'brand-studio',
      title: 'The Brand Studio makes, checks and exports brand kits (rules, command line, files for the Hub, licence, website and app, the local wizard\'s safety)',
      run: () => {
        const r = runCmd('brand-studio', 'node', ['--test', 'tools/brand-studio/tests/brand-studio.test.mjs', 'tools/brand-studio/tests/app-mode.test.mjs']);
        if (r.status !== 'PASS') return r;
        const n = /# pass (\d+)/.exec(r.out);
        return { status: 'PASS', detail: `${n ? n[1] : 'all'} tests passed` };
      },
    },
    {
      name: 'brand-studio-wizard',
      title: 'The Brand Studio wizard in a real browser: fill the form, see the preview, save, make the files',
      full: true,
      run: () => {
        if (!has('node')) return { status: 'SKIP', detail: 'node is not installed here' };
        const why = browserProblem({ sh, join, existsSync, dir: e2e });
        if (why) return { status: 'SKIP', detail: why };
        const r = runCmd('brand-studio-wizard', 'node', ['tools/brand-studio/tests/wizard.e2e.mjs'], { timeout: 300_000 });
        if (r.status !== 'PASS') return r;
        return { status: 'PASS', detail: `${(r.out.match(/^✓ /gm) || []).length} steps passed in a real browser (Chromium)` };
      },
    },
    {
      name: 'android-project',
      title: 'The Android app project keeps its safety settings, and its set-up script works and refuses bad input (the app itself is built by the release workflow)',
      run: () => {
        const r = runCmd('android-project', 'node', ['--test', 'scripts/tests/android-project.test.mjs']);
        if (r.status !== 'PASS') return r;
        const n = /# pass (\d+)/.exec(r.out);
        return { status: 'PASS', detail: `${n ? n[1] : 'all'} checks passed; the .apk and .aab are NOT built here (no Android SDK): the release workflow builds and signs them` };
      },
    },
    {
      name: 'hub-release',
      title: 'The real Business Hub, published, hidden and audited, is brought into use with a real Licence Studio key (activation, brand, a sale, a restart)',
      full: true,
      run: () => {
        const why = needTools();
        if (why) return { status: 'SKIP', detail: why };
        const r = runCmd('hub-release', 'node', ['licensing/e2e/with-studio.mjs', '--', 'node', 'licensing/e2e/hub-e2e.mjs'], { timeout: 1_500_000 });
        if (r.status !== 'PASS') return r;
        const audit = /^PASS\s+hub:.*$/m.exec(r.out);
        const steps = (r.out.match(/^✓ /gm) || []).length;
        return { status: 'PASS', detail: `${steps} steps passed; ${audit ? audit[0].replace(/^PASS\s+/, 'audit: ') : 'audit passed'}` };
      },
    },
    {
      name: 'hub-installer',
      title: 'The Hub setup program installs, updates and uninstalls cleanly (under Wine, with a stand-in program), keeping the shop\'s data',
      full: true,
      run: () => {
        const wine = has('wine64') || existsSync('/usr/lib/wine/wine64');
        const missing = [['makensis', has('makensis')], ['wine64', wine], ['Xvfb', has('Xvfb')], ['node', has('node')]].filter(([, ok]) => !ok).map(([n]) => n);
        if (missing.length) return { status: 'SKIP', detail: `not installed here: ${missing.join(', ')} (apt-get install nsis wine64 xvfb)` };
        const r = runCmd('hub-installer', 'bash', ['apps/business-hub/installer/test-installer.sh'], { timeout: 900_000 });
        if (r.status !== 'PASS') return r;
        const passed = (r.out.match(/^PASS /gm) || []).length;
        return { status: 'PASS', detail: `${passed} setup checks passed (installed, updated, uninstalled; the service itself and the real program need Windows)` };
      },
    },
    {
      name: 'prerequisites-and-base-kit',
      title: 'The prerequisite audit (a package needs nothing a factory-new PC lacks) and the release file list the Setup Studio reads both work and refuse what they should',
      run: () => {
        const r = runCmd('prerequisites-and-base-kit', 'node', ['--test', 'scripts/tests/audit-prerequisites.test.mjs', 'scripts/tests/make-base-kit.test.mjs']);
        if (r.status !== 'PASS') return r;
        const n = /# pass (\d+)/.exec(r.out);
        return { status: 'PASS', detail: `${n ? n[1] : 'all'} tests passed` };
      },
    },
    {
      name: 'hub-linux-package',
      title: 'The Hub\'s Linux package: built, installed with dpkg on this machine, started as its own unprivileged account, given a customer profile package, removed (the shop\'s data stays)',
      full: true,
      run: () => {
        if (process.platform !== 'linux' || !has('dpkg-deb') || !has('dpkg')) return { status: 'SKIP', detail: 'this check needs a Debian-family Linux with dpkg (Ubuntu, Mint, Debian)' };
        if (!has('dotnet') || !has('node')) return { status: 'SKIP', detail: 'dotnet or node is not installed here' };
        if (!findObfuscar()) return { status: 'SKIP', detail: 'the obfuscator (Obfuscar) is not installed and could not be installed here' };
        const root_ = process.getuid?.() === 0;
        if (!root_ && sh('sudo', ['-n', 'true']).status !== 0) return { status: 'SKIP', detail: 'this check installs a package, so it needs root or passwordless sudo' };
        const r = runCmd('hub-linux-package', 'node', ['apps/business-hub/installer/test-linux-package.mjs'], { timeout: 1_200_000 });
        if (r.status !== 'PASS') return r;
        const passed = (r.out.match(/^PASS /gm) || []).length;
        return { status: 'PASS', detail: `${passed} checks passed (real dpkg and a real unprivileged account; not under a real systemd or a desktop)` };
      },
    },
    {
      name: 'hub-protected-e2e',
      title: 'Every Business Hub browser test, run again against the published program with its names hidden',
      full: true,
      run: () => {
        const why = needTools();
        if (why) return { status: 'SKIP', detail: why };
        const r = runCmd('hub-protected-e2e', 'node', ['apps/business-hub/e2e/protected.mjs'], { timeout: 1_700_000 });
        if (r.status !== 'PASS') return r;
        const steps = (r.out.match(/^✓ /gm) || []).length;
        return { status: 'PASS', detail: `${steps} steps passed against the protected build` };
      },
    },
  ];
}
