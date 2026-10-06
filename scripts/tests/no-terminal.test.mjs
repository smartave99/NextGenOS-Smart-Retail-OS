// CLAUDE.md, section 10: programs open like programs (no terminal, ever). This checks the repository for the ways a person could still be shown a terminal:
//   - every script a person could double-click is either one of the allowed engineers' tools (a short list, each with its reason: it only shrinks) or is named
//     "(with a window, for problems)" / "(with a window, for developers)" and says at its top why it exists;
//   - the older Windows programs open as windows (a window program, or started with no window by the program that needs them), the setups point their shortcuts at them
//     or at Edge, never at a console program;
//   - the Hub's plain zip and the dashboard's package carry a hidden launcher, not a script, as the way in;
//   - no guide, read-me or script still names an old way in (a start-*.bat, "Start Website.bat", ...).
// A real Windows PC with a person looking is still needed to see that no black window flashes (docs/OPEN-WORK.md).
import test from 'node:test';
import assert from 'node:assert/strict';
import { readFileSync, existsSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const tracked = spawnSync('git', ['ls-files', '-z'], { cwd: repo, encoding: 'utf8', maxBuffer: 64 * 1024 * 1024 }).stdout.split('\0').filter(Boolean);
const read = (rel) => readFileSync(join(repo, rel), 'utf8');

/** The scripts a person could open: by extension, plus the extension-less Linux scripts of the Hub's package. */
const isScript = (f) => /\.(bat|cmd|ps1|vbs|sh)$/i.test(f) || /^apps\/business-hub\/installer\/linux\/(postinst|postrm|prerm|smart-retail-pos)$/.test(f);
// The Setup Studio checks its own launchers (tools/setup-studio/tests/bundle.test.mjs, scripts/checks/setup-studio.mjs).
const scripts = tracked.filter((f) => isScript(f) && !f.startsWith('tools/setup-studio/'));

/**
 * Scripts that are tools for engineers or are run by the machine, not programs a person opens: each is here with its reason. A new script does not belong on this list
 * unless it is also an engineer's tool; a person's program gets a hidden launcher (scripts/lib/build-launcher.mjs) instead. The list only shrinks.
 */
const ENGINEERS_TOOLS = {
  'apps/pos-ai-companion/build.ps1': 'builds and packs the AI add-on; run by an engineer on a build PC',
  'apps/pos-dashboard-service/build.ps1': 'builds and packs the dashboard (and makes its hidden launcher); run by an engineer on a build PC',
  'scripts/build-all.ps1': 'builds every program; run by an engineer',
  'apps/pos-ai-companion/changelog-entry.sh': 'release tool for engineers',
  'apps/pos-ai-companion/check-version.sh': 'release tool for engineers',
  'apps/pos-ai-companion/publish-update.sh': 'release tool for engineers',
  'apps/pos-ai-companion/installer/test-update.sh': 'a test',
  'apps/pos-ai-companion/tests/publish/run.sh': 'a test',
  'apps/pos-dashboard-service/cloud/test/run.sh': 'a test',
  'apps/business-hub/installer/test-installer.sh': 'a test',
  'apps/pos-desktop/scripts/verify-command-browser.ps1': 'a check run by an engineer',
  'apps/pos-desktop/scripts/verify-frontend-repairs.ps1': 'a check run by an engineer',
  'apps/pos-desktop/scripts/verify-ui.ps1': 'a check run by an engineer',
  'apps/pos-desktop/scripts/verify-workspaces.ps1': 'a check run by an engineer',
  'apps/storefront-web-mobile/android/gradlew.bat': "Gradle's own wrapper, for building the Android app",
  'apps/business-hub/installer/linux/postinst': 'run by dpkg while the package installs; no window',
  'apps/business-hub/installer/linux/postrm': 'run by dpkg while the package is removed; no window',
  'apps/business-hub/installer/linux/prerm': 'run by dpkg while the package is removed; no window',
  'apps/business-hub/installer/linux/smart-retail-pos': 'the Linux menu entry: opens a window of its own (the .desktop files say Terminal=false; scripts/tests/hub-launcher.test.mjs runs it)',
  'scripts/dev/suite-menu.ps1': 'opened only by "Menu of all programs (with a window, for developers).bat"',
  'tools/brand-studio/brand-studio.sh': 'source-copy helper for developers (its first lines say so); staff use the Setup Studio',
};

const NAMED = /\(with a window, for (problems|developers)\)/;
const looseScripts = (files) => files.filter((f) => isScript(f) && !f.startsWith('tools/setup-studio/') && !NAMED.test(f) && !(f in ENGINEERS_TOOLS));

test('the check itself catches a new script that would show a terminal, and lets the named and listed ones through', () => {
  assert.deepEqual(looseScripts(['scripts/start-something.bat', 'apps/new-program/Start.cmd', 'tools/x/run.ps1', 'apps/a/b.sh']), ['scripts/start-something.bat', 'apps/new-program/Start.cmd', 'tools/x/run.ps1', 'apps/a/b.sh']);
  assert.deepEqual(looseScripts(['apps/x/Start X (with a window, for problems).cmd', 'scripts/dev/Y (with a window, for developers).bat', 'scripts/build-all.ps1', 'README.md', 'scripts/x.mjs']), []);
});

test('every script a person could double-click is an engineer\'s tool, or says in its name that it shows a window on purpose', () => {
  const loose = looseScripts(tracked);
  assert.deepEqual(loose, [], `These scripts would show a terminal and are not named "(with a window, for problems)" or "(with a window, for developers)", nor listed as an engineer's tool with a reason.\nA program a person opens gets a hidden launcher instead (scripts/lib/build-launcher.mjs):\n  ${loose.join('\n  ')}`);
});

test('the list of engineers\' tools has no entry for a file that is gone, and none that is also named as a window helper', () => {
  for (const f of Object.keys(ENGINEERS_TOOLS)) {
    assert.ok(tracked.includes(f), `${f} is on the list of engineers' tools but is not in the repository any more: take it off the list`);
    assert.ok(!NAMED.test(f), `${f} is named as a window helper: it does not belong on the list of engineers' tools`);
  }
});

test('a script that shows a window on purpose says at its top why it exists and what the normal way is', () => {
  const named = scripts.filter((f) => NAMED.test(f));
  assert.ok(named.length >= 8, `the named helpers are there (found ${named.length})`);
  for (const f of named) {
    const lines = read(f).split(/\r?\n/).map((l) => l.trim()).filter((l) => l && !/^@?echo off$/i.test(l));
    assert.match(lines[0], /^rem /i, `${f} starts with a note that says why it shows a window`);
    const note = lines.filter((l) => /^rem /i.test(l)).slice(0, 3).join(' ');
    if (/for developers/.test(f)) assert.match(note, /for developers|work from the source/i, `${f}: the note says it is for developers`);
    else assert.match(note, /normal way|for finding a problem|for a problem/i, `${f}: the note says what the normal way is`);
  }
});

test('the old Windows programs are window programs, or are started with no window by the program that needs them', () => {
  // The Windows POS's project is found, not named here: a customer's name belongs only in that customer's own files (CLAUDE.md, section 1).
  const posProject = tracked.find((f) => /^apps\/pos-desktop\/Source\/[^/]+_POS_VB\/[^/]+\/[^/]+\.vbproj$/.test(f));
  assert.ok(posProject, 'the Windows POS project is in the repository');
  assert.match(read(posProject), /<OutputType>WinExe<\/OutputType>/, 'the Windows POS is a window program');
  assert.match(read('apps/pos-ai-companion/src/SmartRetail.AI.Desktop/SmartRetail.AI.Desktop.csproj'), /<OutputType>WinExe<\/OutputType>/, 'the AI add-on is a window program');
  assert.match(read('apps/pos-ai-companion/src/SmartRetail.AI.Desktop/WindowsDashboardHost.cs'), /CreateNoWindow\s*=\s*true/, 'the AI add-on starts the dashboard it carries with no console window');
});

test('every shortcut a setup makes opens a window program or Edge, never a console program', () => {
  // The Hub: the shortcut is Edge in "app" mode ($R0), or the web address file; the program file is only the icon.
  const hub = read('apps/business-hub/installer/SmartRetailHub.nsi');
  const hubShortcuts = [...hub.matchAll(/CreateShortCut\s+"([^"]+)"\s+("[^"]+"|\S+)/gi)];
  assert.ok(hubShortcuts.length >= 4, 'the Hub setup makes its shortcuts');
  for (const [line, , target] of hubShortcuts) assert.ok(!/EXE/.test(target), `a Hub shortcut starts the console program itself (that would show a black window): ${line}`);
  assert.ok(hubShortcuts.some(([, , target]) => target.includes('$R0')), 'the Hub shortcuts start Edge');
  assert.match(hub, /--app=\$\{ADDRESS\}/, 'in app mode: a window with no address bar');
  // The AI add-on and the Windows POS: their shortcuts start the window program.
  assert.match(read('apps/pos-ai-companion/installer/SmartRetailAI.nsi'), /CreateShortcut "\$SMPROGRAMS\\\$\{APP\}\.lnk" "\$INSTDIR\\\$\{EXE\}"/);
  assert.match(read('apps/pos-ai-companion/installer/SmartRetailAI.nsi'), /!define EXE "SmartRetailAI\.exe"/);
  const inno = read('apps/pos-desktop/installer/SmartRetailOS_Setup.iss');
  for (const m of inno.matchAll(/^Name: "[^"]+"; Filename: "([^"]+)"/gm)) assert.ok(!/\.(bat|cmd)/i.test(m[1]), `an Inno shortcut starts a script: ${m[1]}`);
  assert.ok(!/Filename: "[^"]*\.(bat|cmd|ps1)"/i.test(inno), 'the Windows POS setup runs no script');
});

test('every .desktop file says Terminal=false', () => {
  const desktop = tracked.filter((f) => f.endsWith('.desktop'));
  assert.ok(desktop.length >= 2);
  for (const f of desktop) assert.match(read(f), /^Terminal=false$/m, f);
});

test('the dashboard package gets a hidden launcher made by the shared maker, and its address is the dashboard\'s own', () => {
  const build = read('apps/pos-dashboard-service/build.ps1');
  assert.match(build, /scripts\/make-launcher\.mjs/);
  assert.match(build, /--program SmartRetail\.Pos\.Web\.exe/);
  const address = /--open "(http:\/\/127\.0\.0\.1:\d+)"/.exec(build)?.[1];
  assert.ok(address, 'the launcher is given the address the dashboard answers at');
  assert.equal(JSON.parse(read('apps/pos-dashboard-service/src/SmartRetail.Pos.Web/appsettings.json')).Kestrel.Endpoints.Http.Url, address, 'the launcher waits at the address the dashboard listens on');
  assert.match(build, /\$helper = "Start Smart Retail POS \(with a window, for problems\)"/);
  assert.ok(existsSync(join(repo, 'apps/pos-dashboard-service/packaging/Start Smart Retail POS (with a window, for problems).cmd')));
  assert.ok(!existsSync(join(repo, 'apps/pos-dashboard-service/packaging/Start Smart Retail POS.cmd')), 'the old script that opened a console is gone');
  assert.match(build, /if \(\$LASTEXITCODE -ne 0\) \{ throw "The launcher could not be made/, 'a package without its launcher is never written');
});

test('no guide, read-me or script still names a way in that shows a terminal', () => {
  // Built from pieces so that this file does not name them itself.
  const old = ['start-suite-menu', 'start-pos-', 'start-storefront', 'Start' + '_POS', 'Teardown' + '_Test', 'Start Smart Retail POS' + '.cmd', 'Start Website' + '.bat', 'Brand Studio' + '.bat'];
  const files = tracked.filter((f) => /\.(md|txt|mjs|cjs|js|json|ps1|bat|cmd|sh|yml|nsi|iss)$/i.test(f) && !/package-lock\.json$|node_modules|^apps\/pos-desktop\/Source\/|^apps\/storefront-web-mobile\/(src|android|public)\//.test(f) && !['scripts/tests/no-terminal.test.mjs', 'scripts/tests/make-website-package.test.mjs'].includes(f));
  const hits = [];
  for (const f of files) {
    let text;
    try { text = read(f); } catch { continue; }
    for (const name of old) if (text.includes(name)) hits.push(`${f}: ${name}`);
  }
  assert.deepEqual(hits, []);
});

test('the guides say, for each program, which kind it is (it keeps running, or closing the window stops it)', () => {
  const guide = read('docs/CUSTOMER-GUIDE.md');
  assert.match(guide, /It keeps running/);
  assert.match(guide, /The website stops/);
  assert.match(guide, /with a window, for problems/);
  assert.match(guide, /Start Business Hub/);
  assert.match(guide, /Start Smart Retail POS/);
  const dashboardReadme = read('apps/pos-dashboard-service/README.md');
  assert.match(dashboardReadme, /background program of the shop/);
  assert.match(dashboardReadme, /Start Smart Retail POS\*\* \(the icon\)/);
  assert.match(read('licensing/README.md'), /a \*server\* that you run on a machine that stays on/, 'the Licence Studio is said to be a server that is run remotely');
});
