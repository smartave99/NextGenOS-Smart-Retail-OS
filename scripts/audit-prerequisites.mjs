#!/usr/bin/env node
/**
 * Checks that a package runs on a factory-new machine of its system with nothing installed first (CLAUDE.md, section 6).
 *
 *   node scripts/audit-prerequisites.mjs <package folder> --os windows|linux [--arch x64|arm64]
 *
 * It reads every program file in the package and lists what each needs from the machine: for Windows the DLLs it imports, for Linux the shared libraries it needs
 * and the newest glibc it asks for. Each thing must be inside the package, or be on the short list of what the operating system itself always has
 * (docs/PREREQUISITES.md). It also fails on a program that needs .NET to be installed (not self-contained), on files made for another processor, and on a package that
 * does not say, in prerequisites.json, what it carries and what it relies on the system for.
 */
import { readdirSync, readFileSync, statSync, openSync, readSync, closeSync, existsSync } from 'node:fs';
import { join, relative, resolve, basename, sep } from 'node:path';
import { fileURLToPath } from 'node:url';
import { peImports, elfNeeded } from './lib/binary-imports.mjs';

/** What every supported Windows (10 22H2 and 11, 64-bit) has in its own System32 folder. Kept short and exact. */
export const WINDOWS_SYSTEM = new Set([
  'kernel32.dll', 'kernelbase.dll', 'ntdll.dll', 'user32.dll', 'gdi32.dll', 'advapi32.dll', 'shell32.dll', 'shlwapi.dll', 'ole32.dll', 'oleaut32.dll', 'rpcrt4.dll', 'combase.dll',
  'ws2_32.dll', 'mswsock.dll', 'iphlpapi.dll', 'dnsapi.dll', 'netapi32.dll', 'wldap32.dll', 'winhttp.dll', 'wininet.dll', 'crypt32.dll', 'bcrypt.dll', 'ncrypt.dll', 'secur32.dll', 'sspicli.dll',
  'wintrust.dll', 'version.dll', 'winmm.dll', 'dbghelp.dll', 'userenv.dll', 'setupapi.dll', 'cfgmgr32.dll', 'imm32.dll', 'comctl32.dll', 'comdlg32.dll', 'uxtheme.dll', 'dwmapi.dll',
  'd3d11.dll', 'd3d12.dll', 'd3dcompiler_47.dll', 'dxgi.dll', 'fontsub.dll', 'usp10.dll', 'normaliz.dll', 'ucrtbase.dll', 'msvcrt.dll', 'hid.dll', 'winspool.drv', 'kernel.appcore.dll',
  'powrprof.dll', 'psapi.dll', 'wtsapi32.dll', 'mscoree.dll', 'bcryptprimitives.dll', 'cabinet.dll', 'authz.dll', 'clusapi.dll', 'api-ms-win-core-path-l1-1-0.dll',
]);
/** The Visual C++ runtime is not part of Windows: a file that imports it must have the DLLs beside it, or the setup must carry the redistributable. */
const VC_RUNTIME = /^(vcruntime\d+(_\d+)?|msvcp\d+(_\d+)?|concrt\d+|vccorlib\d+|mfc\d+u?|vcomp\d+)\.dll$/;

/** What every supported Linux desktop (Ubuntu 22.04 and 24.04, Debian 12 and later) has from its base install. */
export const LINUX_SYSTEM = new Set([
  'libc.so.6', 'libm.so.6', 'libdl.so.2', 'libpthread.so.0', 'librt.so.1', 'libutil.so.1', 'libresolv.so.2', 'libgcc_s.so.1', 'libstdc++.so.6',
  'ld-linux-x86-64.so.2', 'ld-linux-aarch64.so.1', 'linux-vdso.so.1',
]);
/** OpenSSL 3 is on every supported Linux desktop, but a program may rely on it only by saying so ("openssl-3" in prerequisites.json): the website's database library links to it. */
export const LINUX_OPENSSL = new Set(['libssl.so.3', 'libcrypto.so.3']);
/** The newest glibc the supported systems have is 2.35 (Ubuntu 22.04): nothing in the package may ask for more. */
export const MAX_GLIBC = [2, 35];

/** Items a package may say it relies on the system for. Each one is explained in docs/PREREQUISITES.md. */
export const SYSTEM_ITEMS = {
  windows: new Set(['windows-10-22h2-or-11-x64', 'windows-system-dlls', 'web-browser-edge']),
  linux: new Set(['glibc-2.35-or-newer', 'libstdc++6-libgcc-s1', 'openssl-3', 'web-browser', 'systemd']),
};

function magic(path) {
  const fd = openSync(path, 'r');
  try { const b = Buffer.alloc(4); readSync(fd, b, 0, 4, 0); return b; } finally { closeSync(fd); }
}

/** Looks at a package folder. Returns { problems, files, native }. */
export function auditPrerequisites(folder, { os, arch = 'x64' }) {
  const root = resolve(folder);
  const problems = [];
  const present = new Set();
  const all = [];
  const walk = (dir) => {
    for (const e of readdirSync(dir, { withFileTypes: true })) {
      const full = join(dir, e.name);
      if (e.isDirectory()) walk(full);
      else if (e.isFile()) { all.push(full); present.add(e.name.toLowerCase()); }
    }
  };
  walk(root);

  // 1. The package says what it carries and what it relies on.
  let declared = [];
  // A launcher is a tiny 32-bit Windows program (made with NSIS) that only starts the 64-bit program beside it; every 64-bit Windows runs it (docs/PREREQUISITES.md).
  // It is accepted as 32-bit only when the package names it here, as a file at the top of the package; what it imports is checked like any other program.
  const launchers = new Set();
  const manifest = join(root, 'prerequisites.json');
  if (!existsSync(manifest)) problems.push('prerequisites.json is missing (it says what the package carries and what it relies on the system for)');
  else {
    try {
      const m = JSON.parse(readFileSync(manifest, 'utf8'));
      if (m.schema !== 1) problems.push('prerequisites.json must say "schema": 1');
      if (m.os !== os) problems.push(`prerequisites.json is for "${m.os}", not "${os}"`);
      if (m.arch !== arch) problems.push(`prerequisites.json is for "${m.arch}", not "${arch}"`);
      if (!Array.isArray(m.bundled) || m.bundled.length === 0) problems.push('prerequisites.json must list what is bundled');
      if (!Array.isArray(m.system) || m.system.length === 0) problems.push('prerequisites.json must list what the system supplies');
      else declared = m.system;
      if (Array.isArray(m.system)) for (const item of m.system) if (!SYSTEM_ITEMS[os].has(item)) problems.push(`prerequisites.json relies on "${item}", which is not on the allowed list for ${os} (docs/PREREQUISITES.md)`);
      if (typeof m.minimumSystem !== 'string' || !m.minimumSystem) problems.push('prerequisites.json must say the minimum system in words (minimumSystem)');
      if (m.launchers !== undefined) {
        if (!Array.isArray(m.launchers) || m.launchers.some((n) => typeof n !== 'string' || !/^[^\\/:*?"<>|]+\.exe$/i.test(n))) problems.push('prerequisites.json: "launchers" must be a list of .exe file names at the top of the package');
        else if (os !== 'windows') problems.push('prerequisites.json: only a Windows package has launchers');
        else for (const n of m.launchers) launchers.add(n);
      }
    } catch { problems.push('prerequisites.json is not valid JSON'); }
  }

  // 2. Every program file: what it needs.
  let native = 0;
  let glibc = [0, 0];
  const needs = new Map();
  for (const file of all) {
    const rel = relative(root, file).split(sep).join('/');
    let head;
    try { head = magic(file); } catch { continue; }
    if (os === 'windows' && head.readUInt16LE(0) === 0x5a4d) {
      const buf = readFileSync(file);
      const r = peImports(buf);
      if (!r) continue;
      const machine = buf.readUInt16LE(buf.readUInt32LE(0x3c) + 4);
      if (!r.managed) {
        native += 1;
        const want = arch === 'arm64' ? 0xaa64 : 0x8664;
        if (machine !== want && !(machine === 0x14c && arch === 'x64' && launchers.has(rel))) problems.push(`${rel}: made for another processor (0x${machine.toString(16)}), not ${arch}`);
        for (const dll of r.imports) {
          if (present.has(dll) || /^(api|ext)-ms-win-/.test(dll) || WINDOWS_SYSTEM.has(dll)) continue;
          problems.push(VC_RUNTIME.test(dll) ? `${rel}: needs ${dll} (the Visual C++ runtime), which is not in the package: carry it beside the file or in the setup` : `${rel}: needs ${dll}, which is neither in the package nor part of Windows`);
          needs.set(dll, rel);
        }
      }
    } else if (os === 'linux' && head.readUInt32BE(0) === 0x7f454c46) {
      const buf = readFileSync(file);
      const r = elfNeeded(buf);
      if (!r) continue;
      native += 1;
      if (r.arch !== arch) problems.push(`${rel}: made for another processor (${r.arch}), not ${arch}`);
      for (const lib of r.needed) {
        if (present.has(lib.toLowerCase()) || LINUX_SYSTEM.has(lib) || (LINUX_OPENSSL.has(lib) && declared.includes('openssl-3'))) continue;
        // The language data (ICU) the program carries is loaded by .NET under its full name (libicuuc.so.72.1.0.3); the libraries that need it ask for the short name (libicuuc.so.72),
        // which the loader satisfies from the copy already loaded. So a file named "<short name>.<more>" in the package counts as the short name.
        if (/^libicu(uc|i18n|data)\.so\.\d+$/.test(lib) && [...present].some((name) => name.startsWith(lib.toLowerCase() + '.'))) continue;
        problems.push(`${rel}: needs ${lib}, which is neither in the package nor part of the base system`);
        needs.set(lib, rel);
      }
      for (const m of buf.toString('latin1').matchAll(/GLIBC_(\d+)\.(\d+)/g)) {
        const v = [Number(m[1]), Number(m[2])];
        if (v[0] > glibc[0] || (v[0] === glibc[0] && v[1] > glibc[1])) glibc = v;
        if (v[0] > MAX_GLIBC[0] || (v[0] === MAX_GLIBC[0] && v[1] > MAX_GLIBC[1])) problems.push(`${rel}: needs glibc ${v.join('.')}, newer than the ${MAX_GLIBC.join('.')} of Ubuntu 22.04`);
      }
    }
  }
  if (native === 0) problems.push('no program file was found: is this the package folder?');

  // 3. A .NET program must carry its own runtime.
  for (const file of all.filter((f) => /\.runtimeconfig\.json$/i.test(f))) {
    try {
      const cfg = JSON.parse(readFileSync(file, 'utf8')).runtimeOptions || {};
      if (cfg.framework || cfg.frameworks) problems.push(`${relative(root, file).split(sep).join('/')}: needs .NET installed on the machine (not self-contained)`);
    } catch { /* not ours to judge */ }
  }
  return { problems: [...new Set(problems)], files: all.length, native, glibc: glibc[0] ? glibc.join('.') : null };
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const args = process.argv.slice(2);
  const value = (n) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : undefined; };
  const target = args.find((a, i) => !a.startsWith('--') && !(i > 0 && args[i - 1].startsWith('--')));
  const os = value('--os');
  if (!target || !['windows', 'linux'].includes(os || '')) { console.error('Usage: node scripts/audit-prerequisites.mjs <package folder> --os windows|linux [--arch x64|arm64]'); process.exit(2); }
  if (!existsSync(target) || !statSync(target).isDirectory()) { console.error(`${target}: not a folder`); process.exit(2); }
  const arch = value('--arch') || 'x64';
  const { problems, files, native, glibc } = auditPrerequisites(target, { os, arch });
  if (problems.length) {
    console.log(`FAIL  ${basename(resolve(target))}: ${problems.length} problem(s) for ${os} ${arch}`);
    for (const p of problems.slice(0, 60)) console.log('  ' + p);
    process.exit(1);
  }
  console.log(`PASS  ${basename(resolve(target))}: ${files} files, ${native} program files for ${os} ${arch}; each needs only what is in the package or in the base system${glibc ? ` (newest glibc asked for: ${glibc})` : ''}; carries its own runtime (nothing like .NET or Node.js is asked of the machine)`);
}
