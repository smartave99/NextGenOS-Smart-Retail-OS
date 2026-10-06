// Makes the small Windows launcher program of one of our programs (scripts/launcher/AppLauncher.nsi) with NSIS. It runs on Linux (apt-get install nsis) or on Windows (NSIS installed).
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

/**
 * Writes the launcher. `program` is the program to start and `check` a file that must be there, both relative to where the launcher will sit; `workdir` is where it runs
 * (also relative); `args` is what it is given. Throws an Error in plain words when it cannot be made.
 */
export function buildLauncher({ outFile, name, program, args, workdir = '.', check = program, icon = null, version = '1.0.0', company = 'NextGenOS', makensis = findMakensis() }) {
  for (const [what, value] of Object.entries({ name, program, args, workdir, check, version, company })) if (typeof value !== 'string' || !value || bad(value)) throw new Error(`The launcher's ${what} is missing or has a quote or a line break in it.`);
  if (!/^\d+\.\d+\.\d+$/.test(version)) throw new Error('The launcher\'s version must be three numbers, like 1.0.0.');
  if (icon && !existsSync(icon)) throw new Error(`The launcher's icon file is not there: ${icon}`);
  if (!makensis) throw new Error('The Windows launcher needs NSIS (makensis). On Linux: apt-get install nsis. On Windows: install NSIS from nsis.sourceforge.io.');
  // makensis reads relative paths from the folder of the script, not from where it is run: the files are given in full.
  outFile = resolve(outFile);
  if (icon) icon = resolve(icon);
  const defines = [`-DOUTFILE=${outFile}`, `-DNAME=${name}`, `-DPROGRAM=${program}`, `-DARGS=${args}`, `-DWORKDIR=${workdir}`, `-DCHECK=${check}`, `-DVERSION=${version}`, `-DCOMPANY=${company}`, ...(icon ? [`-DICON=${icon}`] : [])];
  const made = spawnSync(makensis, ['-V2', ...defines, LAUNCHER_SCRIPT], { encoding: 'utf8' });
  if (made.error || made.status !== 0 || !existsSync(outFile)) throw new Error(`The Windows launcher could not be made.\n${made.error?.message ?? ''}${(made.stdout || '').slice(-1500)}${(made.stderr || '').slice(-1500)}`);
  return outFile;
}
