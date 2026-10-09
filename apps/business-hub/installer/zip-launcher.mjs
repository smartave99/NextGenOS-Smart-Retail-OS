// What the Hub's plain zip carries beside the program so that nobody meets a black window (CLAUDE.md, section 10): a hidden launcher, "Start Business Hub", that starts the
// Hub in the background and opens it in a window of its own; a helper with a window for finding a problem; and a read-me that says the setup is the normal way.
// The setup (SmartRetailHub.nsi) does not carry these: it installs the Hub as a Windows service and puts the window shortcuts in the Start menu and on the desktop.
// The Hub is a background program of the shop: closing its window does NOT stop it (section 10 names it as the one kind that keeps running on purpose).
import { existsSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { join } from 'node:path';
import { buildLauncher, findMakensis } from '../../../scripts/lib/build-launcher.mjs';
import { repo } from './common.mjs';

/** Where the Hub answers (apps/business-hub/src/NextGenOS.Hub.Web/appsettings.json, Kestrel; the setup's shortcuts use the same address). */
export const HUB_ADDRESS = 'http://127.0.0.1:5280';
export const HUB_PROGRAM = 'NextGenOS.Hub.exe';
export const HUB_SERVICE = 'NextGenOSHub';   // the Windows service the setup makes (SmartRetailHub.nsi)
export const LAUNCHER_FILE = 'Start Business Hub.exe';
export const PROBLEM_HELPER = 'Start Business Hub (with a window, for problems)';
export const README_FILE = 'READ ME FIRST.txt';
/** The two small programs the SETUP puts beside the Hub (the Hub is a Windows service there): they wait until it answers and then open its window, normal or full screen. */
export const OPENER_FILE = 'Open Smart Retail POS.exe';
export const OPENER_FULL_FILE = 'Open Smart Retail POS (full screen).exe';

const crlf = (lines) => lines.join('\r\n') + '\r\n';

/** The helper that runs the Hub in a window that shows what it says, for finding a problem. Closing that window stops the Hub. */
export function problemHelperText() {
  return crlf([
    '@echo off',
    'rem Opens the Smart Retail POS Hub in this window so that you can read what it says, for finding a problem.',
    'rem The normal way is "Start Business Hub", which has no such window. Closing this window stops the Hub.',
    'cd /d "%~dp0"',
    `echo Smart Retail POS Hub is starting. It answers at ${HUB_ADDRESS} when it is ready.`,
    'echo Leave this window open while you use it. To stop it, close this window.',
    'echo.',
    HUB_PROGRAM,
    'echo.',
    'echo The Hub has stopped. If the lines above say why, send them to the person who gave you the program.',
    'pause',
  ]);
}

/** The read-me for a person who opens the zip: plain words; the setup is the normal way. */
export function readMeText(version) {
  return crlf([
    `Smart Retail POS Hub ${version}: the program as a plain folder`,
    '================================================================',
    '',
    'The normal way to put the Hub on a PC is the SETUP file (SmartRetailPOS-Hub-Setup-' + version + '.exe). It puts an icon on the desktop, starts the Hub with the PC, keeps it running',
    'in the background and removes it cleanly when you want. Use this folder only to try the Hub without installing it, or when the person who looks after your computers sets it up by hand.',
    '',
    'To open it',
    '  1. Unpack the whole zip (right-click, Extract All) into a folder you may write to, for example Documents. Open it from that folder, not from inside the zip.',
    '  2. Double-click "Start Business Hub" (the blue icon with a shopping bag).',
    '     There is no black window. The Hub starts quietly in the background and opens in a window of its own (Microsoft Edge, which every Windows 10 and 11 has).',
    '     The first time, it asks for your licence key.',
    '  3. If Windows says "Windows protected your PC" (the program is not signed yet): click "More info", then "Run anyway".',
    '',
    'What to know',
    '  - The Hub is a program that keeps running in the background, like the setup\'s version. Closing its window does NOT stop it: double-click "Start Business Hub" again to bring a window back.',
    '  - It stops when the PC is restarted or you sign out of Windows. To stop it sooner: press Ctrl+Shift+Esc (Task Manager), open "Details", choose NextGenOS.Hub.exe and press "End task".',
    '  - Do not use this folder and the setup on the same PC at the same time: both want the same address (' + HUB_ADDRESS.replace('http://', '') + ').',
    '  - Your shop\'s information is kept in C:\\ProgramData\\NextGenOS\\Hub, not in this folder. Copy that folder to a USB drive or a cloud drive regularly.',
    '',
    'If something goes wrong',
    `  Open "${PROBLEM_HELPER}" in this folder and read what it says (it opens a window that shows the Hub's messages). Send those lines to the person who gave you the program.`,
    '  Closing that window stops the Hub.',
    '',
    'Smart Retail POS by NextGenOS.',
    '',
  ]);
}

/**
 * Puts the launcher, the helper and the read-me into the folder that becomes the zip, and says in prerequisites.json that the launcher is the one 32-bit program
 * (docs/PREREQUISITES.md, "Launchers"). Returns the names written. Throws an Error in plain words when the launcher cannot be made.
 */
export function addZipLauncher(folder, { version, makensis = findMakensis() } = {}) {
  if (!/^\d+\.\d+\.\d+$/.test(String(version ?? ''))) throw new Error('Say the version as three numbers, like 1.0.0.');
  if (!existsSync(join(folder, HUB_PROGRAM))) throw new Error(`${HUB_PROGRAM} is not in ${folder}: the launcher has nothing to start.`);
  const manifestFile = join(folder, 'prerequisites.json');
  if (!existsSync(manifestFile)) throw new Error('prerequisites.json is missing: write it before adding the launcher.');
  buildLauncher({
    outFile: join(folder, LAUNCHER_FILE), name: 'Smart Retail POS Hub', program: HUB_PROGRAM, check: HUB_PROGRAM, version,
    icon: join(repo, 'scripts', 'launcher', 'product.ico'), makensis,
    open: { url: HUB_ADDRESS, waitSeconds: 90, profile: 'smart-retail-pos-window', helper: PROBLEM_HELPER },
  });
  writeFileSync(join(folder, `${PROBLEM_HELPER}.bat`), problemHelperText());
  writeFileSync(join(folder, README_FILE), readMeText(version));
  const manifest = JSON.parse(readFileSync(manifestFile, 'utf8'));
  manifest.launchers = [...new Set([...(manifest.launchers ?? []), LAUNCHER_FILE])];
  writeFileSync(manifestFile, JSON.stringify(manifest, null, 2) + '\n');
  return [LAUNCHER_FILE, `${PROBLEM_HELPER}.bat`, README_FILE];
}

/**
 * The setup's two launchers, put into the folder before the setup is written. Unlike the zip's launcher they never start the Hub themselves (Windows starts it, as a service, with the PC; a
 * second copy started by a person would run without the service's rights to the shop's data). They ask Windows to start the service when it is switched off, show a small "starting" window
 * until the Hub answers, then open its window of its own (never the usual web browser); when it does not answer they say in one sentence what is wrong and open a note (service: HUB_SERVICE).
 * Returns the names written.
 */
export function addServiceLaunchers(folder, { version, makensis = findMakensis() } = {}) {
  if (!/^\d+\.\d+\.\d+$/.test(String(version ?? ''))) throw new Error('Say the version as three numbers, like 1.0.0.');
  if (!existsSync(join(folder, HUB_PROGRAM))) throw new Error(`${HUB_PROGRAM} is not in ${folder}: the launcher has nothing to wait for.`);
  const manifestFile = join(folder, 'prerequisites.json');
  if (!existsSync(manifestFile)) throw new Error('prerequisites.json is missing: write it before adding the launchers.');
  const common = { name: 'Smart Retail POS', program: HUB_PROGRAM, check: HUB_PROGRAM, version, icon: join(repo, 'scripts', 'launcher', 'product.ico'), makensis };
  const open = { url: HUB_ADDRESS, waitSeconds: 180, profile: 'smart-retail-pos-window', waitOnly: true, service: HUB_SERVICE, startingText: 'Smart Retail POS is starting.' };
  buildLauncher({ ...common, outFile: join(folder, OPENER_FILE), open });
  buildLauncher({ ...common, outFile: join(folder, OPENER_FULL_FILE), open: { ...open, kiosk: true } });
  const manifest = JSON.parse(readFileSync(manifestFile, 'utf8'));
  manifest.launchers = [...new Set([...(manifest.launchers ?? []), OPENER_FILE, OPENER_FULL_FILE])];
  writeFileSync(manifestFile, JSON.stringify(manifest, null, 2) + '\n');
  return [OPENER_FILE, OPENER_FULL_FILE];
}

/** Takes the setup's two launchers out again (the zip has its own launcher and must not carry them). */
export function removeServiceLaunchers(folder) {
  for (const f of [OPENER_FILE, OPENER_FULL_FILE]) rmSync(join(folder, f), { force: true });
  const manifestFile = join(folder, 'prerequisites.json');
  const manifest = JSON.parse(readFileSync(manifestFile, 'utf8'));
  manifest.launchers = (manifest.launchers ?? []).filter((f) => f !== OPENER_FILE && f !== OPENER_FULL_FILE);
  writeFileSync(manifestFile, JSON.stringify(manifest, null, 2) + '\n');
}
