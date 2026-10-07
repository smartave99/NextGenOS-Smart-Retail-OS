// Reading and writing the zip inside an Android app (.apk) or app bundle (.aab). Unchanged files are copied exactly as they were (their packed bytes are not touched), and the
// writer can line stored files up the way Android needs (resources.arsc on 4 bytes, native libraries on 16 KB). The old signature is never carried over: it is made again.
import { inflateRawSync, deflateRawSync, crc32 } from 'node:zlib';

export class ZipError extends Error {}

const EOCD = 0x06054b50; const CENTRAL = 0x02014b50; const LOCAL = 0x04034b50;
const u16 = (n) => { const b = Buffer.alloc(2); b.writeUInt16LE(n); return b; };
const u32 = (n) => { const b = Buffer.alloc(4); b.writeUInt32LE(n >>> 0); return b; };

/** Names that could write outside a folder, or that no zip tool would make, are refused. */
export function checkName(name) {
  if (!name || name.length > 500 || name.startsWith('/') || name.includes('\\') || /^[A-Za-z]:/.test(name) || name.split('/').includes('..') || /[\u0000-\u001f]/.test(name)) throw new ZipError(`A file in the app has a name that is not allowed: ${String(name).slice(0, 60)}`);
}

/** Reads a zip. Returns { entries, names } where each entry is { name, method, crc, csize, usize, time, date, attrs, madeBy, raw() , data() }. */
export function readZip(buf) {
  if (!Buffer.isBuffer(buf) || buf.length < 22) throw new ZipError('This file is not a zip (an app is a zip file).');
  let eocd = -1;
  for (let i = buf.length - 22; i >= Math.max(0, buf.length - 22 - 65535); i -= 1) if (buf.readUInt32LE(i) === EOCD) { eocd = i; break; }
  if (eocd < 0) throw new ZipError('This file is not a zip (an app is a zip file).');
  const count = buf.readUInt16LE(eocd + 10);
  const size = buf.readUInt32LE(eocd + 12);
  const offset = buf.readUInt32LE(eocd + 16);
  if (count === 0xffff || size === 0xffffffff || offset === 0xffffffff) throw new ZipError('This zip is too big for this Studio (the "zip64" kind).');
  if (offset + size > eocd) throw new ZipError('This zip is damaged (its list of files does not fit).');
  const entries = [];
  const seen = new Set();
  let at = offset;
  for (let i = 0; i < count; i += 1) {
    if (at + 46 > buf.length || buf.readUInt32LE(at) !== CENTRAL) throw new ZipError('This zip is damaged (its list of files is broken).');
    const madeBy = buf.readUInt16LE(at + 4); const flags = buf.readUInt16LE(at + 8); const method = buf.readUInt16LE(at + 10);
    const time = buf.readUInt16LE(at + 12); const date = buf.readUInt16LE(at + 14);
    const crc = buf.readUInt32LE(at + 16); const csize = buf.readUInt32LE(at + 20); const usize = buf.readUInt32LE(at + 24);
    const n = buf.readUInt16LE(at + 28); const m = buf.readUInt16LE(at + 30); const k = buf.readUInt16LE(at + 32);
    const attrs = buf.readUInt32LE(at + 38); const local = buf.readUInt32LE(at + 42);
    const name = buf.toString('utf8', at + 46, at + 46 + n);
    at += 46 + n + m + k;
    if (flags & 1) throw new ZipError('This zip has a locked file in it, which an app never has.');
    if (method !== 0 && method !== 8) throw new ZipError(`A file in this zip is packed in a way an app does not use (${name}).`);
    if (seen.has(name)) throw new ZipError(`This zip lists the same file twice (${name}), which is not safe to read.`);
    seen.add(name);
    const entry = { name, method, crc, csize, usize, time, date, attrs, madeBy, dir: name.endsWith('/') };
    entry.raw = () => {
      if (local + 30 > buf.length || buf.readUInt32LE(local) !== LOCAL) throw new ZipError(`This zip is damaged (${name} cannot be found where the list says).`);
      const start = local + 30 + buf.readUInt16LE(local + 26) + buf.readUInt16LE(local + 28);
      if (start + csize > offset) throw new ZipError(`This zip is damaged (${name} is cut short).`);
      return buf.subarray(start, start + csize);
    };
    entry.data = () => {
      const raw = entry.raw();
      let out;
      try { out = method === 0 ? Buffer.from(raw) : inflateRawSync(raw); } catch { throw new ZipError(`This zip is damaged (${name} cannot be unpacked).`); }
      if (out.length !== usize || crc32(out) !== crc) throw new ZipError(`This zip is damaged (${name} does not check out).`);
      return out;
    };
    entries.push(entry);
  }
  return { entries, byName: new Map(entries.map((e) => [e.name, e])), centralOffset: offset, centralSize: size };
}

/** The place where a stored file's bytes must start, for Android: 16 KB for a native library (.so), 4 bytes for anything else that is stored. */
export const alignmentFor = (name) => (/\.so$/.test(name) ? 16384 : 4);

/**
 * Writes a zip. Each item is one of
 *   { name, data: Buffer, store?: true }          new bytes (packed unless store is true, or unless packing does not make it smaller)
 *   { name, from: entry }                         an entry of a zip read before, copied as it is
 * plus { time, date, attrs } to keep (they default to the entry's own, or to a fixed date so that two runs give the same file).
 * Stored files are aligned as alignmentFor says. Returns the whole file as a Buffer.
 */
export function writeZip(items) {
  const parts = []; const central = [];
  let offset = 0;
  const names = new Set();
  for (const item of items) {
    checkName(item.name);
    if (names.has(item.name)) throw new ZipError(`The same file is in the app twice: ${item.name}`);
    names.add(item.name);
    let method; let crc; let csize; let usize; let body;
    const src = item.from;
    if (src) { method = src.method; crc = src.crc; csize = src.csize; usize = src.usize; body = src.raw(); }
    else {
      const data = Buffer.isBuffer(item.data) ? item.data : Buffer.from(item.data);
      crc = crc32(data); usize = data.length;
      const packed = item.store || data.length === 0 ? null : deflateRawSync(data, { level: 9 });
      if (packed && packed.length < data.length) { method = 8; body = packed; } else { method = 0; body = data; }
      csize = body.length;
    }
    const nameBytes = Buffer.from(item.name, 'utf8');
    const time = item.time ?? src?.time ?? 0; const date = item.date ?? src?.date ?? 0x5821;   // 1 Jan 2024
    const attrs = item.attrs ?? src?.attrs ?? 0;
    // padding in the extra field so that the stored bytes start where Android wants them
    let pad = Buffer.alloc(0);
    if (method === 0 && !item.name.endsWith('/')) {
      const align = alignmentFor(item.name);
      const start = offset + 30 + nameBytes.length;
      let need = (align - (start % align)) % align;
      if (need > 0 && need < 4) need += align;
      if (need > 0) pad = Buffer.concat([u16(0xd935), u16(need - 4), Buffer.alloc(need - 4)]);
    }
    const local = Buffer.concat([u32(LOCAL), u16(20), u16(0x0800), u16(method), u16(time), u16(date), u32(crc), u32(csize), u32(usize), u16(nameBytes.length), u16(pad.length), nameBytes, pad]);
    parts.push(local, body);
    central.push(Buffer.concat([u32(CENTRAL), u16(src?.madeBy ?? 0x031e), u16(20), u16(0x0800), u16(method), u16(time), u16(date), u32(crc), u32(csize), u32(usize), u16(nameBytes.length), u16(0), u16(0), u16(0), u16(0), u32(attrs), u32(offset), nameBytes]));
    offset += local.length + body.length;
  }
  const dir = Buffer.concat(central);
  const end = Buffer.concat([u32(EOCD), u16(0), u16(0), u16(items.length), u16(items.length), u32(dir.length), u32(offset), u16(0)]);
  return Buffer.concat([...parts, dir, end]);
}

/** Where the three parts of a finished zip are: the files, the list of files, and the end record. */
export function layoutOf(buf) {
  const z = readZip(buf);
  const eocd = buf.length - 22;
  if (buf.readUInt32LE(eocd) !== EOCD) throw new ZipError('The zip has a comment at its end, which an app never has.');
  return { centralOffset: z.centralOffset, centralSize: z.centralSize, eocdOffset: eocd };
}
