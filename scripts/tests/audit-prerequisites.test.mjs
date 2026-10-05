// Tests for scripts/audit-prerequisites.mjs and scripts/lib/binary-imports.mjs, with small program files built here byte by byte.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, writeFileSync, mkdirSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { auditPrerequisites } from './../audit-prerequisites.mjs';
import { peImports, elfNeeded } from './../lib/binary-imports.mjs';

/** A minimal 64-bit ELF file that needs the given shared libraries (and mentions the given glibc versions). */
function makeElf({ needed = [], machine = 62, glibc = [] } = {}) {
  const strs = Buffer.concat([Buffer.from([0]), ...needed.map((n) => Buffer.from(n + '\0')), ...glibc.map((v) => Buffer.from(`GLIBC_${v}\0`))]);
  const offsets = []; let at = 1;
  for (const n of needed) { offsets.push(at); at += n.length + 1; }
  const dynEntries = [...offsets.map((o) => [1n, BigInt(o)]), [5n, 0n], [0n, 0n]];
  const phoff = 64, phsize = 56 * 2;
  const strOff = phoff + phsize;
  const dynOff = strOff + strs.length + ((8 - ((strOff + strs.length) % 8)) % 8);
  const dynSize = dynEntries.length * 16;
  const buf = Buffer.alloc(dynOff + dynSize);
  buf.writeUInt32BE(0x7f454c46, 0); buf[4] = 2; buf[5] = 1; buf[6] = 1;
  buf.writeUInt16LE(3, 16); buf.writeUInt16LE(machine, 18); buf.writeBigUInt64LE(BigInt(phoff), 32); buf.writeUInt16LE(56, 54); buf.writeUInt16LE(2, 56);
  // PT_LOAD over the whole file, vaddr = offset
  buf.writeUInt32LE(1, phoff); buf.writeBigUInt64LE(0n, phoff + 8); buf.writeBigUInt64LE(0n, phoff + 16); buf.writeBigUInt64LE(BigInt(buf.length), phoff + 32);
  // PT_DYNAMIC
  const p2 = phoff + 56; buf.writeUInt32LE(2, p2); buf.writeBigUInt64LE(BigInt(dynOff), p2 + 8); buf.writeBigUInt64LE(BigInt(dynOff), p2 + 16); buf.writeBigUInt64LE(BigInt(dynSize), p2 + 32);
  strs.copy(buf, strOff);
  dynEntries.forEach(([tag, val], i) => { buf.writeBigUInt64LE(tag, dynOff + i * 16); buf.writeBigUInt64LE(tag === 5n ? BigInt(strOff) : val, dynOff + i * 16 + 8); });
  return buf;
}

/** A minimal 64-bit Windows program file that imports the given DLLs. */
function makePe({ imports = [], managed = false, machine = 0x8664 } = {}) {
  const peAt = 0x80, optSize = 240, secAt = peAt + 24 + optSize, secRaw = 0x400;
  const descSize = (imports.length + 1) * 20;
  const names = Buffer.concat(imports.map((n) => Buffer.from(n + '\0')));
  const buf = Buffer.alloc(secRaw + descSize + names.length + 16);
  buf.writeUInt16LE(0x5a4d, 0); buf.writeUInt32LE(peAt, 0x3c);
  buf.writeUInt32LE(0x4550, peAt); buf.writeUInt16LE(machine, peAt + 4); buf.writeUInt16LE(1, peAt + 6); buf.writeUInt16LE(optSize, peAt + 20);
  const opt = peAt + 24; buf.writeUInt16LE(0x20b, opt);
  const dirs = opt + 112;
  buf.writeUInt32LE(0x1000, dirs + 8); buf.writeUInt32LE(descSize, dirs + 12);                       // import table at RVA 0x1000
  if (managed) { buf.writeUInt32LE(0x2000, dirs + 14 * 8); buf.writeUInt32LE(72, dirs + 14 * 8 + 4); }
  buf.write('.idata', secAt); buf.writeUInt32LE(descSize + names.length, secAt + 8); buf.writeUInt32LE(0x1000, secAt + 12); buf.writeUInt32LE(descSize + names.length, secAt + 16); buf.writeUInt32LE(secRaw, secAt + 20);
  let nameRva = 0x1000 + descSize;
  imports.forEach((n, i) => { buf.writeUInt32LE(nameRva, secRaw + i * 20 + 12); nameRva += n.length + 1; });
  names.copy(buf, secRaw + descSize);
  return buf;
}

function pack(files) {
  const dir = mkdtempSync(join(tmpdir(), 'prereq-test-'));
  for (const [name, content] of Object.entries(files)) { mkdirSync(join(dir, name, '..'), { recursive: true }); writeFileSync(join(dir, name), content); }
  return dir;
}
const manifest = (extra = {}) => JSON.stringify({ schema: 1, os: 'linux', arch: 'x64', bundled: ['the .NET runtime'], system: ['glibc-2.35-or-newer', 'libstdc++6-libgcc-s1'], minimumSystem: 'Ubuntu 22.04', ...extra });
const audit = (files, options) => { const dir = pack(files); try { return auditPrerequisites(dir, options); } finally { rmSync(dir, { recursive: true, force: true }); } };

test('the file readers see what the files need', () => {
  assert.deepEqual(elfNeeded(makeElf({ needed: ['libc.so.6', 'libfoo.so.1'] })).needed, ['libc.so.6', 'libfoo.so.1']);
  assert.equal(elfNeeded(makeElf({ machine: 183 })).arch, 'arm64');
  assert.equal(elfNeeded(Buffer.from('not elf at all, just text')), null);
  assert.deepEqual(peImports(makePe({ imports: ['KERNEL32.dll', 'vcruntime140.dll'] })).imports.sort(), ['kernel32.dll', 'vcruntime140.dll']);
  assert.equal(peImports(makePe({ managed: true, imports: ['mscoree.dll'] })).managed, true);
  assert.equal(peImports(Buffer.from('plain')), null);
});

test('Linux: a package that needs only itself and the base system passes', () => {
  const r = audit({ 'prerequisites.json': manifest(), app: makeElf({ needed: ['libc.so.6', 'libstdc++.so.6', 'libhelper.so'], glibc: ['2.34'] }), 'libhelper.so': makeElf({ needed: ['libm.so.6'] }) }, { os: 'linux' });
  assert.deepEqual(r.problems, []);
  assert.equal(r.glibc, '2.34');
});

test('Linux: a library that is neither in the package nor in the base system, a newer glibc, another processor and a missing manifest are all named', () => {
  const r = audit({ app: makeElf({ needed: ['libc.so.6', 'libfontconfig.so.1'], glibc: ['2.38'] }), 'other.so': makeElf({ machine: 183 }) }, { os: 'linux' }).problems.join('\n');
  assert.match(r, /prerequisites\.json is missing/);
  assert.match(r, /app: needs libfontconfig\.so\.1/);
  assert.match(r, /needs glibc 2\.38, newer than the 2\.35/);
  assert.match(r, /other\.so: made for another processor \(arm64\), not x64/);
});

test('Windows: system DLLs and API sets are fine; the Visual C++ runtime and unknown DLLs must be carried', () => {
  const ok = audit({ 'prerequisites.json': manifest({ os: 'windows', system: ['windows-10-22h2-or-11-x64', 'windows-system-dlls'] }), 'a.dll': makePe({ imports: ['kernel32.dll', 'api-ms-win-crt-runtime-l1-1-0.dll', 'd3d12.dll', 'helper.dll'] }), 'helper.dll': makePe({ imports: ['ntdll.dll'] }) }, { os: 'windows' });
  assert.deepEqual(ok.problems, []);
  const bad = audit({ 'prerequisites.json': manifest({ os: 'windows', system: ['windows-system-dlls'] }), 'a.dll': makePe({ imports: ['kernel32.dll', 'vcruntime140.dll', 'msvcp140.dll', 'weird.dll'] }) }, { os: 'windows' }).problems.join('\n');
  assert.match(bad, /needs vcruntime140\.dll \(the Visual C\+\+ runtime\)/);
  assert.match(bad, /needs msvcp140\.dll/);
  assert.match(bad, /needs weird\.dll, which is neither in the package nor part of Windows/);
  const carried = audit({ 'prerequisites.json': manifest({ os: 'windows', system: ['windows-system-dlls'] }), 'a.dll': makePe({ imports: ['vcruntime140.dll'] }), 'vcruntime140.dll': makePe({ imports: ['kernel32.dll'] }) }, { os: 'windows' });
  assert.deepEqual(carried.problems, [], 'a runtime that is beside the file counts as carried');
});

test('Windows: managed (.NET) assemblies are not judged by their one import; a file for another processor is named', () => {
  const r = audit({ 'prerequisites.json': manifest({ os: 'windows', system: ['windows-system-dlls'] }), 'm.dll': makePe({ managed: true, imports: ['mscoree.dll'] }), 'n.dll': makePe({ imports: ['kernel32.dll'], machine: 0x14c }) }, { os: 'windows' }).problems.join('\n');
  assert.doesNotMatch(r, /m\.dll/);
  assert.match(r, /n\.dll: made for another processor/);
});

test('the manifest must name only what the operating system really supplies, and say a minimum', () => {
  const r = audit({ 'prerequisites.json': manifest({ system: ['dotnet-runtime', 'glibc-2.35-or-newer'], minimumSystem: '' }), app: makeElf({ needed: ['libc.so.6'] }) }, { os: 'linux' }).problems.join('\n');
  assert.match(r, /relies on "dotnet-runtime", which is not on the allowed list/);
  assert.match(r, /minimum system/);
});

test('a program that needs .NET installed is refused; a folder with no program is refused', () => {
  const dep = audit({ 'prerequisites.json': manifest(), app: makeElf({ needed: ['libc.so.6'] }), 'app.runtimeconfig.json': JSON.stringify({ runtimeOptions: { framework: { name: 'Microsoft.NETCore.App', version: '10.0.0' } } }) }, { os: 'linux' }).problems.join('\n');
  assert.match(dep, /needs \.NET installed/);
  assert.match(audit({ 'prerequisites.json': manifest(), 'readme.txt': 'hi' }, { os: 'linux' }).problems.join('\n'), /no program file was found/);
});
