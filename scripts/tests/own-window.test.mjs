// The owner's rule (CLAUDE.md, section 10): our programs open like programs, in a window of their own, with no address bar, like any other program on the PC. They never open as a page
// in the PC's usual web browser, and no screen, button or message tells a person to "open it in your web browser". This was broken once by the Business Hub's setup, whose "Open Smart
// Retail POS now" button opened the usual browser (and the owner had to say it twice). This test reads the scripts that start our programs and fails when one of them does it again.
// When no window of our own can be shown (no Edge, Chrome or Chromium), a program says so in plain words and tells the person what to do; it does not fall back to the browser.
import test from 'node:test';
import assert from 'node:assert/strict';
import { execFileSync } from 'node:child_process';
import { readFileSync } from 'node:fs';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const tracked = execFileSync('git', ['ls-files'], { cwd: repo, encoding: 'utf8', maxBuffer: 64 * 1024 * 1024 }).split('\n').filter(Boolean);
const text = (f) => readFileSync(join(repo, f), 'utf8');

/** Opening something that is not our program (a download page for a missing Windows part) in the browser is right, and says why. */
const NOT_OUR_PROGRAM = {
  'apps/pos-ai-companion/installer/SmartRetailAI.nsi': 'opens Microsoft\'s download page for a missing Windows part (.NET Framework): a web page, not our program',
};

/** Programs a person does not open from an icon (an engineer, or a server that staff run remotely) and that print an address on purpose. */
const FOR_ENGINEERS = {
  'tools/setup-studio/studio.mjs': 'the developer run (serve, without --app) prints the address; people use --app',
  'tools/brand-studio/brand.mjs': 'the developer run (serve, without --app) prints the address; people use --app',
  'scripts/website-launcher.cjs': 'the run in a terminal is for a server that staff run remotely; people use the window (--app)',
};

test('no Windows script opens one of our programs in the usual web browser', () => {
  const bad = [];
  for (const f of tracked.filter((x) => /\.(nsi|nsh)$/.test(x))) {
    if (NOT_OUR_PROGRAM[f]) continue;
    text(f).split(/\r?\n/).forEach((line, i) => { if (/ExecShell\s+"open"\s+"(https?:|\$\{(ADDRESS|OPEN_URL)\})/i.test(line)) bad.push(`${f}:${i + 1}: ${line.trim()}`); });
  }
  assert.deepEqual(bad, [], `These open an address in the usual web browser. Our programs open in a window of their own (a launcher: scripts/launcher/AppLauncher.nsi):\n  ${bad.join('\n  ')}`);
});

test('no setup page, description or message tells a person to use a web browser for our programs', () => {
  const bad = [];
  const files = tracked.filter((x) => /(installer|launcher)\/.*\.(nsi|nsh|mjs|sh|txt)$/.test(x) || /^(apps\/business-hub\/installer\/linux\/|tools\/setup-studio\/lib\/pack\.mjs)/.test(x));
  for (const f of files) {
    if (NOT_OUR_PROGRAM[f] || FOR_ENGINEERS[f]) continue;
    text(f).split(/\r?\n/).forEach((line, i) => {
      if (/^\s*(;|#|\/\/|\*)/.test(line)) return;   // a comment explaining the rule is fine
      if (/\b(in|on|with) (a|your|the usual|the PC's usual) (web )?browser\b/i.test(line) && !/never|not use|NOT used|never in/i.test(line)) bad.push(`${f}:${i + 1}: ${line.trim().slice(0, 160)}`);
    });
  }
  assert.deepEqual(bad, [], `These words send a person to a web browser:\n  ${bad.join('\n  ')}`);
});

test('the Linux menu entry never hands the address to the usual browser', () => {
  const script = text('apps/business-hub/installer/linux/smart-retail-pos');
  assert.ok(!/^[^#]*xdg-open/m.test(script), 'smart-retail-pos calls xdg-open');
});

test('the programs that show a window fall back to a note, never to the usual browser', () => {
  for (const f of ['tools/setup-studio/studio.mjs', 'tools/brand-studio/brand.mjs']) {
    const lines = text(f).split(/\r?\n/);
    const calls = lines.map((l, i) => [l, i + 1]).filter(([l]) => /openWithSystem\(/.test(l) && !/function openWithSystem/.test(l));
    const loose = calls.filter(([l]) => !/openWithSystem\(file\)/.test(l) && !/opts\.open\b/.test(l));
    assert.deepEqual(loose.map(([l, n]) => `${f}:${n}: ${l.trim()}`), [], `${f} hands an address to the usual browser outside the developer's --open run`);
  }
});

test('the Hub setup\'s icons and its Finish button go through the program that waits and then opens the window', () => {
  const nsi = text('apps/business-hub/installer/SmartRetailHub.nsi');
  const shortcuts = nsi.split(/\r?\n/).filter((l) => /^\s*CreateShortCut/.test(l));
  assert.ok(shortcuts.length >= 2);
  for (const l of shortcuts) assert.match(l, /\$\{OPENER(_FULL)?\}/, `a shortcut does not use the waiting launcher: ${l.trim()}`);
  assert.match(nsi, /Function OpenHub\s+Exec '"\$INSTDIR\\\$\{OPENER\}"'/, 'the Finish button must run the same launcher as the icon');
});
