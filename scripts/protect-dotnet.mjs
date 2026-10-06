#!/usr/bin/env node
/**
 * Makes the compiled .NET programs in a publish folder hard to read, before they are packed for a customer.
 *
 *   node scripts/protect-dotnet.mjs --dir <publish folder> [--partial NextGenOS.Hub.dll] [--obfuscar <path>]
 *
 * Every NextGenOS.*.dll in the folder gets its type, method, field and event names replaced, its text strings hidden, and its
 * disassembler markers set (SuppressIldasm). The files listed with --partial keep method and property names (the web program of
 * the Hub binds screens and endpoints by name at run time); their types are still renamed. The obfuscator's map file and all
 * debug symbols are deleted from the folder: the map is the key to the names, and it must stay with us (a private build log), never
 * in what a customer receives. (--map-to <file> keeps the map somewhere private, for reading customers' crash reports.)
 *
 * What this does and does not do (the longer account is in docs/SECURITY-MODEL.md): it turns a readable program into one that costs
 * days of work to understand instead of minutes. It cannot make code on someone's PC impossible to read. The protection that does not
 * depend on hiding code is the signed, device-bound, revocable licence, and the value that lives on our servers.
 */
import { spawnSync } from 'node:child_process';
import { existsSync, mkdtempSync, mkdirSync, readdirSync, copyFileSync, rmSync, writeFileSync, statSync, readFileSync } from 'node:fs';
import { createHash } from 'node:crypto';
import { tmpdir } from 'node:os';
import { join, resolve, basename } from 'node:path';
import { findObfuscar } from './lib/obfuscar.mjs';

const args = process.argv.slice(2);
const flag = (name) => { const i = args.indexOf(name); return i >= 0 ? args[i + 1] : undefined; };
const list = (name) => (flag(name) || '').split(',').map((s) => s.trim()).filter(Boolean);

const dir = flag('--dir');
if (!dir || !existsSync(dir)) { console.error('protect-dotnet: --dir <publish folder> is required and must exist'); process.exit(2); }
const folder = resolve(dir);
const partial = new Set(list('--partial').map((s) => s.toLowerCase()));
const obfuscar = flag('--obfuscar') || findObfuscar();
if (!obfuscar) { console.error('protect-dotnet: the obfuscator (Obfuscar) is not installed and could not be installed here: dotnet tool install --global Obfuscar.GlobalTool --version 2.2.50'); process.exit(2); }

const sha = (f) => createHash('sha256').update(readFileSync(f)).digest('hex');
const mine = readdirSync(folder).filter((f) => /^NextGenOS\..*\.dll$/i.test(f));
if (!mine.length) { console.error(`protect-dotnet: no NextGenOS.*.dll in ${folder}`); process.exit(2); }

// Where Obfuscar looks for the framework and the packages the programs use.
const runtimeDirs = [];
const dotnetRoot = process.env.DOTNET_ROOT || (existsSync('/usr/lib/dotnet') ? '/usr/lib/dotnet' : existsSync('/usr/share/dotnet') ? '/usr/share/dotnet' : process.platform === 'win32' ? 'C:\\Program Files\\dotnet' : '');
for (const pack of ['Microsoft.AspNetCore.App', 'Microsoft.NETCore.App']) {
  const root = join(dotnetRoot, 'shared', pack);
  if (existsSync(root)) {
    const versions = readdirSync(root).filter((v) => /^\d/.test(v)).sort((a, b) => a.localeCompare(b, undefined, { numeric: true }));
    if (versions.length) runtimeDirs.push(join(root, versions[versions.length - 1]));
  }
}

const work = mkdtempSync(join(tmpdir(), 'ngos-protect-'));
const inDir = join(work, 'in');
const outDir = join(work, 'out');
mkdirSync(inDir);
mkdirSync(outDir);
for (const f of mine) copyFileSync(join(folder, f), join(inDir, f));
const before = new Map(mine.map((f) => [f, sha(join(folder, f))]));

const xmlPath = (p) => p.replace(/\\/g, '/').replace(/&/g, '&amp;').replace(/"/g, '&quot;');
const modules = mine.map((f) => partial.has(f.toLowerCase())
  ? `  <Module file="$(InPath)/${f}">\n    <SkipMethod type="*" name="*" />\n    <SkipProperty type="*" name="*" />\n  </Module>`
  // Constructors keep their parameter names: the JSON reader and the dependency container match values to them by name.
  : `  <Module file="$(InPath)/${f}">\n    <SkipMethod type="*" name=".ctor" />\n  </Module>`).join('\n');
const config = `<?xml version='1.0'?>
<Obfuscator>
  <Var name="InPath" value="${xmlPath(inDir)}" />
  <Var name="OutPath" value="${xmlPath(outDir)}" />
  <Var name="KeepPublicApi" value="false" />
  <Var name="HidePrivateApi" value="true" />
  <Var name="RenameProperties" value="false" />
  <Var name="RenameEvents" value="true" />
  <Var name="RenameFields" value="true" />
  <Var name="HideStrings" value="true" />
  <Var name="OptimizeMethods" value="true" />
  <Var name="SuppressIldasm" value="true" />
  <Var name="ReuseNames" value="true" />
  <Var name="UseUnicodeNames" value="false" />
  <Var name="RegenerateDebugInfo" value="false" />
${runtimeDirs.map((d) => `  <AssemblySearchPath path="${xmlPath(d)}" />`).join('\n')}
  <AssemblySearchPath path="${xmlPath(folder)}" />
${modules}
</Obfuscator>
`;
const configPath = join(work, 'obfuscar.xml');
writeFileSync(configPath, config);

const r = spawnSync(obfuscar, [configPath], { encoding: 'utf8', maxBuffer: 64 * 1024 * 1024 });
if (r.error || r.status !== 0) {
  console.error(`protect-dotnet: the obfuscator failed (${r.error ? r.error.message : 'exit ' + r.status})`);
  console.error(`${r.stdout || ''}${r.stderr || ''}`.split('\n').slice(-25).join('\n'));
  rmSync(work, { recursive: true, force: true });
  process.exit(1);
}

// The map from new names back to the real ones is how we read a customer's crash report. It goes to a private place we choose, or nowhere.
const mapOut = flag('--map-to');
const mapFile = ['Mapping.txt', 'Mapping.xml'].map((n) => join(outDir, n)).find((p) => existsSync(p));
if (mapOut && mapFile) copyFileSync(mapFile, resolve(mapOut));

const done = [];
for (const f of mine) {
  const out = join(outDir, f);
  if (!existsSync(out)) { console.error(`protect-dotnet: the obfuscator did not write ${f}`); rmSync(work, { recursive: true, force: true }); process.exit(1); }
  copyFileSync(out, join(folder, f));
  if (sha(join(folder, f)) === before.get(f)) { console.error(`protect-dotnet: ${f} came out unchanged`); rmSync(work, { recursive: true, force: true }); process.exit(1); }
  done.push(`${f}${partial.has(f.toLowerCase()) ? ' (types and fields only)' : ''}  ${(statSync(join(folder, f)).size / 1024).toFixed(0)} KB`);
}

// Nothing that explains the names may stay behind: the map files, the symbols.
let removed = 0;
const sweep = (d) => {
  for (const e of readdirSync(d, { withFileTypes: true })) {
    const p = join(d, e.name);
    if (e.isDirectory()) { sweep(p); continue; }
    if (/\.pdb$/i.test(e.name) || /^Mapping\.(txt|xml)$/i.test(e.name)) { rmSync(p); removed++; }
  }
};
sweep(folder);
rmSync(work, { recursive: true, force: true });

console.log(`protected ${done.length} assemblies in ${basename(folder)}:`);
for (const d of done) console.log('  ' + d);
if (removed) console.log(`removed ${removed} symbol/map file(s)`);
