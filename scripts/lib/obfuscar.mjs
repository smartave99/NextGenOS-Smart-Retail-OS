// Finds the code obfuscator (Obfuscar, MIT licence: a build tool, never shipped), or installs it into a private folder.
import { spawnSync } from 'node:child_process';
import { existsSync } from 'node:fs';
import { tmpdir, homedir } from 'node:os';
import { join } from 'node:path';

export const OBFUSCAR_VERSION = '2.2.50';

export function findObfuscar() {
  if (process.env.OBFUSCAR && existsSync(process.env.OBFUSCAR)) return process.env.OBFUSCAR;
  const exe = process.platform === 'win32' ? 'obfuscar.console.exe' : 'obfuscar.console';
  const onPath = spawnSync(process.platform === 'win32' ? 'where' : 'sh', process.platform === 'win32' ? [exe] : ['-c', `command -v ${exe}`], { encoding: 'utf8' });
  if (onPath.status === 0 && onPath.stdout.trim()) return onPath.stdout.trim().split(/\r?\n/)[0];
  for (const dir of [join(homedir(), '.dotnet', 'tools'), join(tmpdir(), 'ngos-tools')]) {
    if (existsSync(join(dir, exe))) return join(dir, exe);
  }
  const target = join(tmpdir(), 'ngos-tools');
  const r = spawnSync('dotnet', ['tool', 'install', '--tool-path', target, 'Obfuscar.GlobalTool', '--version', OBFUSCAR_VERSION], { encoding: 'utf8', timeout: 300_000 });
  if (r.status === 0 && existsSync(join(target, exe))) return join(target, exe);
  return null;
}
