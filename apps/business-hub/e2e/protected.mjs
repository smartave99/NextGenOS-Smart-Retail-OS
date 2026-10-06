#!/usr/bin/env node
// Every browser test of the Hub, run against the program as it is shipped: published and with its names hidden (scripts/protect-dotnet.mjs).
// Hiding names can break anything that finds things by name at run time; only running the whole thing shows whether it did.
import { spawnSync } from 'node:child_process';
import { mkdtempSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const repo = resolve(here, '..', '..', '..');
const work = mkdtempSync(join(tmpdir(), 'hub-protected-'));
let code = 1;
try {
  const publish = spawnSync('dotnet', ['publish', join(here, '..', 'tests', 'NextGenOS.Hub.E2EHost'), '-c', 'Release', '-o', work, '-p:DebugType=none', '-p:DebugSymbols=false', '--nologo', '-v', 'q'], { encoding: 'utf8', maxBuffer: 64 * 1024 * 1024 });
  if (publish.status !== 0) { console.error(publish.stdout + publish.stderr); throw new Error('publish failed'); }
  const protect = spawnSync('node', [join(repo, 'scripts', 'protect-dotnet.mjs'), '--dir', work, '--partial', 'NextGenOS.Hub.dll,NextGenOS.Hub.E2EHost.dll'], { encoding: 'utf8' });
  process.stdout.write(protect.stdout);
  if (protect.status !== 0) { process.stderr.write(protect.stderr); throw new Error('protect failed'); }
  const run = spawnSync('node', [join(here, 'hub.e2e.mjs')], { cwd: here, stdio: 'inherit', timeout: 1_700_000, env: { ...process.env, HUB_HOST_DLL: join(work, 'NextGenOS.Hub.E2EHost.dll') } });
  code = run.status ?? 1;
} catch (e) {
  console.error(String(e.message || e));
} finally {
  rmSync(work, { recursive: true, force: true });
}
process.exit(code);
