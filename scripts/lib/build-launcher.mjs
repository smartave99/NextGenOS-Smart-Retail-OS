// Makes the small Windows launcher program of one of our programs (scripts/launcher/AppLauncher.nsi) with NSIS. It runs on Linux (apt-get install nsis) or on Windows (NSIS installed).
// Two kinds (the header of AppLauncher.nsi says how each one behaves):
//   a program that opens its own window: the launcher only starts it, hidden (the Setup Studio, the website);
//   a background program that is used in a browser window (the Business Hub, the dashboard): pass `open`, and the launcher starts it once, waits for it, and opens the window.
import { existsSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { dirname, resolve, win32 } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
export const LAUNCHER_SCRIPT = resolve(here, '..', 'launcher', 'AppLauncher.nsi');

/** Where makensis is: on the path, or where NSIS puts itself on Windows. */
export function findMakensis({ platform = process.platform, env = process.env, exists = existsSync, run = spawnSync } = {}) {
  if (!run('makensis', ['-VERSION'], { encoding: 'utf8' }).error) return 'makensis';
  if (platform === 'win32') {
    for (const base of [env['ProgramFiles(x86)'], env.ProgramFiles, env.ProgramW6432].filter(Boolean)) {
      const p = win32.join(base, 'NSIS', 'makensis.exe');
      if (exists(p)) return p;
    }
  }
  return null;
}

const bad = (text) => /[\r\n"]/.test(text);

/** The address of a program that is shown in a window of its own: this PC only, and a plain http address with a port. Returns { url, host, port }. */
export function checkOpenAddress(url) {
  const text = String(url ?? '');
  let u;
  try { u = new URL(text); } catch { throw new Error(`The launcher's address is not a web address: ${text.slice(0, 80)}`); }
  if (u.protocol !== 'http:' || u.hostname !== '127.0.0.1' || !/^\d{1,5}$/.test(u.port) || Number(u.port) < 1 || Number(u.port) > 65535 || u.username || u.password || u.search || u.hash || bad(text) || /\s/.test(text)) {
    throw new Error(`The launcher's address must be this PC's own, like http://127.0.0.1:5280 (a program of the shop is never opened from another address): ${text.slice(0, 80)}`);
  }
  return { url: `http://127.0.0.1:${u.port}${u.pathname === '/' ? '' : u.pathname}`, host: u.hostname, port: Number(u.port) };
}

/**
 * The makensis -D settings for one launcher, after checking every value (nothing with a quote or a line break in it can reach the script). `program` is the program to start and
 * `check` a file that must be there, both relative to where the launcher will sit; `workdir` is where it runs (also relative); `args` is what it is given (may be empty).
 * `open: { url, waitSeconds, profile, helper }` makes it a launcher of a background program shown in a window (see the top of this file).
 */
export function launcherDefines({ outFile, name, program, args = '', workdir = '.', check = program, icon = null, version = '1.0.0', company = 'NextGenOS', open = null }) {
  for (const [what, value] of Object.entries({ name, program, workdir, check, version, company })) if (typeof value !== 'string' || !value || bad(value)) throw new Error(`The launcher's ${what} is missing or has a quote or a line break in it.`);
  if (typeof args !== 'string' || bad(args)) throw new Error('The launcher\'s args is not text, or has a quote or a line break in it.');
  if (!/^\d+\.\d+\.\d+$/.test(version)) throw new Error('The launcher\'s version must be three numbers, like 1.0.0.');
  if (icon && !existsSync(icon)) throw new Error(`The launcher's icon file is not there: ${icon}`);
  // makensis reads relative paths from the folder of the script, not from where it is run: the files are given in full.
  const defines = [`-DOUTFILE=${resolve(outFile)}`, `-DNAME=${name}`, `-DPROGRAM=${program}`, ...(args ? [`-DARGS=${args}`] : []), `-DWORKDIR=${workdir}`, `-DCHECK=${check}`, `-DVERSION=${version}`, `-DCOMPANY=${company}`, ...(icon ? [`-DICON=${resolve(icon)}`] : [])];
  if (open) {
    const { url, host, port } = checkOpenAddress(open.url);
    const wait = open.waitSeconds ?? 60;
    if (!Number.isInteger(wait) || wait < 1 || wait > 600) throw new Error('The launcher\'s waiting time must be a whole number of seconds, from 1 to 600.');
    defines.push(`-DOPEN_URL=${url}`, `-DOPEN_HOST=${host}`, `-DOPEN_PORT=${port}`, `-DOPEN_WAIT=${wait}`);
    if (open.profile !== undefined) {
      if (typeof open.profile !== 'string' || !/^[A-Za-z0-9][A-Za-z0-9 ._-]{0,60}$/.test(open.profile)) throw new Error('The launcher\'s window profile must be a plain folder name (letters, digits, spaces, dots, dashes).');
      defines.push(`-DOPEN_PROFILE=${open.profile}`);
    }
    if (open.helper !== undefined) {
      if (typeof open.helper !== 'string' || !open.helper || bad(open.helper)) throw new Error('The launcher\'s helper name is missing or has a quote or a line break in it.');
      defines.push(`-DOPEN_HELPER=${open.helper}`);
    }
  }
  return defines;
}

/** Writes the launcher. Throws an Error in plain words when it cannot be made. */
export function buildLauncher({ makensis = findMakensis(), ...options }) {
  const defines = launcherDefines(options);
  if (!makensis) throw new Error('The Windows launcher needs NSIS (makensis). On Linux: apt-get install nsis. On Windows: install NSIS from nsis.sourceforge.io.');
  const outFile = resolve(options.outFile);
  const made = spawnSync(makensis, ['-V2', ...defines, LAUNCHER_SCRIPT], { encoding: 'utf8' });
  if (made.error || made.status !== 0 || !existsSync(outFile)) throw new Error(`The Windows launcher could not be made.\n${made.error?.message ?? ''}${(made.stdout || '').slice(-1500)}${(made.stderr || '').slice(-1500)}`);
  return outFile;
}
