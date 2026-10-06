#!/usr/bin/env node
/**
 * Makes the Windows launcher of a program (a small program a person double-clicks: no black terminal window) from the command line, for the build scripts that are not written in
 * JavaScript (the PowerShell build.ps1 files of the older Windows programs). The work is scripts/lib/build-launcher.mjs; this is only its command line.
 *
 *   node scripts/make-launcher.mjs --out "dist/App/Start Smart Retail POS.exe" --name "Smart Retail POS" --program SmartRetail.Pos.Web.exe
 *        --open http://127.0.0.1:5080 [--wait 60] [--profile smart-retail-pos-window] [--helper "Start Smart Retail POS (with a window, for problems)"]
 *        [--args "..."] [--workdir <folder>] [--check <file>] [--icon <file.ico>] [--version 1.0.0]
 *
 * With --open the launcher is the kind for a background program that is used in a browser window (it starts the program once, waits for it, opens the window; the program keeps
 * running when the window is closed). Without it the launcher only starts the program, hidden (the program then opens its own window).
 * It needs NSIS (makensis): apt-get install nsis on Linux, nsis.sourceforge.io on Windows. A problem stops it, in plain words; it never makes a launcher that is not what was asked for.
 */
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { buildLauncher } from './lib/build-launcher.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const KNOWN = ['--out', '--name', '--program', '--open', '--wait', '--profile', '--helper', '--args', '--workdir', '--check', '--icon', '--version'];
const USAGE = 'Usage: node scripts/make-launcher.mjs --out <file.exe> --name <name> --program <program, relative to the launcher> [--open http://127.0.0.1:5080] [--wait 60] [--profile <folder name>] [--helper <file name>] [--args <text>] [--workdir <folder>] [--check <file>] [--icon <file.ico>] [--version 1.0.0]';

/** The settings, as { name: value }. A word that is not a known setting, or a setting with no value, is a typing mistake: it is said, and nothing is made. */
export function parseArguments(argv) {
  const settings = {};
  for (let i = 0; i < argv.length; i += 2) {
    if (!KNOWN.includes(argv[i])) throw new Error(`I do not know "${argv[i]}".\n${USAGE}`);
    if (argv[i + 1] === undefined) throw new Error(`${argv[i]} needs a value after it.\n${USAGE}`);
    settings[argv[i]] = argv[i + 1];
  }
  for (const needed of ['--out', '--name', '--program']) if (!settings[needed]) throw new Error(`${needed} is missing.\n${USAGE}`);
  for (const only of ['--wait', '--profile', '--helper']) if (settings[only] !== undefined && !settings['--open']) throw new Error(`${only} only goes with --open.\n${USAGE}`);
  return settings;
}

/** What buildLauncher is given for those settings. */
export function launcherOptions(s) {
  return {
    outFile: resolve(s['--out']),
    name: s['--name'],
    program: s['--program'],
    ...(s['--args'] !== undefined ? { args: s['--args'] } : {}),
    ...(s['--workdir'] ? { workdir: s['--workdir'] } : {}),
    ...(s['--check'] ? { check: s['--check'] } : {}),
    icon: resolve(s['--icon'] ?? join(here, 'launcher', 'product.ico')),
    ...(s['--version'] ? { version: s['--version'] } : {}),
    ...(s['--open'] ? { open: { url: s['--open'], ...(s['--wait'] ? { waitSeconds: Number(s['--wait']) } : {}), ...(s['--profile'] ? { profile: s['--profile'] } : {}), ...(s['--helper'] ? { helper: s['--helper'] } : {}) } } : {}),
  };
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  try {
    console.log(`Wrote ${buildLauncher(launcherOptions(parseArguments(process.argv.slice(2))))}`);
  } catch (e) {
    console.error(e.message);
    process.exit(e.message.includes('Usage:') ? 2 : 1);
  }
}
