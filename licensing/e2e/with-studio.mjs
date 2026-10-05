#!/usr/bin/env node
// Starts a throw-away Licence Studio (own data folder, random port) and runs a command with these variables set:
//   NGOS_E2E_URL        the Studio's address
//   NGOS_E2E_CLI        how to run its command line, e.g. "node /path/cli.js"
//   NGOS_E2E_DATA       its data folder (the CLI needs it)
//   NGOS_E2E_KEYS       its public keys, JSON
//   NGOS_E2E_ADMIN      "email:password" of an administrator, NGOS_E2E_SALES for a salesperson
// Usage: node with-studio.mjs -- <command> [args]
import { spawn, spawnSync } from 'node:child_process';
import { mkdtempSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import net from 'node:net';

const here = dirname(fileURLToPath(import.meta.url));
const studio = resolve(here, '..', 'studio');
const sep = process.argv.indexOf('--');
const command = process.argv.slice(sep + 1);
if (sep < 0 || command.length === 0) { console.error('Usage: with-studio.mjs -- <command>'); process.exit(2); }

const port = await new Promise((res) => { const s = net.createServer(); s.listen(0, '127.0.0.1', () => { const p = s.address().port; s.close(() => res(p)); }); });
const data = mkdtempSync(join(tmpdir(), 'ngos-e2e-'));
const env = { ...process.env, STUDIO_DATA: data, PORT: String(port), HOST: '127.0.0.1', NODE_NO_WARNINGS: '1' };
delete env.STUDIO_PASSPHRASE;
const cli = (...args) => spawnSync('node', ['--no-warnings', join(studio, 'src', 'cli.js'), ...args], { env, encoding: 'utf8' });

const init = cli('init', '--admin-email', 'admin@demo.example', '--admin-name', 'Demo Admin');
if (init.status !== 0) { console.error(init.stdout, init.stderr); process.exit(1); }
const adminPw = /Temporary password \(shown once\): (\S+)/.exec(init.stdout)[1];
const sales = cli('add-user', '--email', 'sales@demo.example', '--name', 'Demo Sales', '--role', 'sales');
const salesPw = /Temporary password \(shown once\): (\S+)/.exec(sales.stdout)[1];
const keys = cli('export-public-keys').stdout;

const server = spawn('node', ['--no-warnings', join(studio, 'src', 'server.js')], { env, stdio: ['ignore', 'pipe', 'pipe'] });
let log = '';
server.stdout.on('data', (d) => { log += d; });
server.stderr.on('data', (d) => { log += d; });
const url = `http://127.0.0.1:${port}`;
for (let i = 0; i < 60; i += 1) {
  try { if ((await fetch(`${url}/api/v1/health`)).ok) break; } catch (_) { /* not up yet */ }
  await new Promise((r) => setTimeout(r, 250));
  if (i === 59) { console.error('The Studio did not start.\n' + log); server.kill(); process.exit(1); }
}

const child = spawn(command[0], command.slice(1), {
  stdio: 'inherit',
  env: { ...process.env, NGOS_E2E_URL: url, NGOS_E2E_CLI: `node --no-warnings ${join(studio, 'src', 'cli.js')}`, NGOS_E2E_DATA: data, NGOS_E2E_KEYS: keys,
    NGOS_E2E_ADMIN: `admin@demo.example:${adminPw}`, NGOS_E2E_SALES: `sales@demo.example:${salesPw}` },
});
const code = await new Promise((r) => child.on('exit', (c) => r(c ?? 1)));
server.kill();
rmSync(data, { recursive: true, force: true });
process.exit(code);
