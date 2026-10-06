// What a program file needs from the machine it runs on, read from the file itself (no tools needed): the DLLs a Windows program imports (PE),
// and the shared libraries a Linux program needs (ELF). Used by scripts/audit-prerequisites.mjs.

/** @returns {{ kind: 'pe', managed: boolean, imports: string[] } | null} the DLL names a Windows file imports (lower case), or null when it is not a PE file. */
export function peImports(buf) {
  if (buf.length < 0x40 || buf.readUInt16LE(0) !== 0x5a4d) return null;
  const pe = buf.readUInt32LE(0x3c);
  if (pe + 24 > buf.length || buf.readUInt32LE(pe) !== 0x4550) return null;
  const sections = buf.readUInt16LE(pe + 6);
  const optSize = buf.readUInt16LE(pe + 20);
  const opt = pe + 24;
  const magic = buf.readUInt16LE(opt);
  const plus = magic === 0x20b;
  const dirsAt = opt + (plus ? 112 : 96);
  const dir = (n) => ({ rva: buf.readUInt32LE(dirsAt + n * 8), size: buf.readUInt32LE(dirsAt + n * 8 + 4) });
  const secStart = opt + optSize;
  const secs = [];
  for (let i = 0; i < sections; i += 1) {
    const s = secStart + i * 40;
    secs.push({ va: buf.readUInt32LE(s + 12), vsize: buf.readUInt32LE(s + 8), raw: buf.readUInt32LE(s + 20), rawsize: buf.readUInt32LE(s + 16) });
  }
  const toOffset = (rva) => { for (const s of secs) if (rva >= s.va && rva < s.va + Math.max(s.vsize, s.rawsize)) return rva - s.va + s.raw; return -1; };
  const cstr = (off) => { let e = off; while (e < buf.length && buf[e] !== 0) e += 1; return buf.toString('latin1', off, e).toLowerCase(); };
  const names = new Set();
  const readTable = (n, stride, nameAt) => {
    const d = dir(n);
    if (!d.rva) return;
    let at = toOffset(d.rva);
    if (at < 0) return;
    for (let i = 0; i < 4096 && at + stride <= buf.length; i += 1, at += stride) {
      const nameRva = buf.readUInt32LE(at + nameAt);
      if (nameRva === 0) break;
      const off = toOffset(nameRva);
      if (off >= 0) names.add(cstr(off));
    }
  };
  readTable(1, 20, 12);   // imports
  readTable(13, 32, 4);   // delay-load imports
  const managed = dir(14).rva !== 0;
  return { kind: 'pe', managed, imports: [...names] };
}

/** @returns {{ kind: 'elf', needed: string[], arch: string } | null} the shared libraries a Linux file needs, or null when it is not an ELF file. */
export function elfNeeded(buf) {
  if (buf.length < 64 || buf.readUInt32BE(0) !== 0x7f454c46) return null;
  if (buf[4] !== 2 || buf[5] !== 1) return { kind: 'elf', needed: [], arch: 'unsupported' };   // only 64-bit little-endian
  const machine = buf.readUInt16LE(18);
  const arch = machine === 62 ? 'x64' : machine === 183 ? 'arm64' : `machine-${machine}`;
  const phoff = Number(buf.readBigUInt64LE(32));
  const phentsize = buf.readUInt16LE(54);
  const phnum = buf.readUInt16LE(56);
  const loads = [];
  let dynamic = null;
  for (let i = 0; i < phnum; i += 1) {
    const p = phoff + i * phentsize;
    const type = buf.readUInt32LE(p);
    const offset = Number(buf.readBigUInt64LE(p + 8));
    const vaddr = Number(buf.readBigUInt64LE(p + 16));
    const filesz = Number(buf.readBigUInt64LE(p + 32));
    if (type === 1) loads.push({ offset, vaddr, filesz });
    if (type === 2) dynamic = { offset, filesz };
  }
  if (!dynamic) return { kind: 'elf', needed: [], arch };
  const toOffset = (va) => { for (const l of loads) if (va >= l.vaddr && va < l.vaddr + l.filesz) return va - l.vaddr + l.offset; return -1; };
  const needed = [];
  let strtab = 0;
  for (let at = dynamic.offset; at + 16 <= dynamic.offset + dynamic.filesz; at += 16) {
    const tag = Number(buf.readBigUInt64LE(at));
    const val = Number(buf.readBigUInt64LE(at + 8));
    if (tag === 0) break;
    if (tag === 1) needed.push(val);
    if (tag === 5) strtab = val;
  }
  const base = toOffset(strtab);
  const names = base < 0 ? [] : needed.map((o) => { let e = base + o; while (e < buf.length && buf[e] !== 0) e += 1; return buf.toString('latin1', base + o, e); });
  return { kind: 'elf', needed: names, arch };
}
