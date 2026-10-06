// A small zip writer (deflate, no extras), so the Studio can hand over one file without needing any tool installed. Names are checked: no drive letters, no "..".
import { deflateRawSync, createDeflateRaw, crc32 } from 'node:zlib';
import { writeFileSync, readFileSync, readdirSync, statSync, createReadStream, createWriteStream, rmSync } from 'node:fs';
import { join, relative, sep } from 'node:path';

const u16 = (n) => { const b = Buffer.alloc(2); b.writeUInt16LE(n); return b; };
const u32 = (n) => { const b = Buffer.alloc(4); b.writeUInt32LE(n >>> 0); return b; };

function dosTime(d) {
  const time = (d.getHours() << 11) | (d.getMinutes() << 5) | (d.getSeconds() >> 1);
  const date = ((Math.max(d.getFullYear(), 1980) - 1980) << 9) | ((d.getMonth() + 1) << 5) | d.getDate();
  return { time, date };
}

/** entries: [{ name, data: Buffer, mode?: 0o755 }]. Returns the zip as a Buffer. */
export function makeZip(entries, { when = new Date() } = {}) {
  const { time, date } = dosTime(when);
  const parts = [];
  const central = [];
  let offset = 0;
  for (const entry of entries) {
    const name = entry.name.split(sep).join('/');
    if (!name || name.startsWith('/') || /^[A-Za-z]:/.test(name) || name.split('/').includes('..')) throw new Error(`A file in the zip has a name that is not allowed: ${name}`);
    const data = Buffer.isBuffer(entry.data) ? entry.data : Buffer.from(entry.data);
    const packed = deflateRawSync(data, { level: 9 });
    const useDeflate = packed.length < data.length;
    const body = useDeflate ? packed : data;
    const nameBytes = Buffer.from(name, 'utf8');
    const crc = crc32(data);
    const local = Buffer.concat([u32(0x04034b50), u16(20), u16(0x0800), u16(useDeflate ? 8 : 0), u16(time), u16(date), u32(crc), u32(body.length), u32(data.length), u16(nameBytes.length), u16(0), nameBytes]);
    parts.push(local, body);
    const mode = entry.mode ?? 0o644;
    central.push(Buffer.concat([u32(0x02014b50), u16(0x031e), u16(20), u16(0x0800), u16(useDeflate ? 8 : 0), u16(time), u16(date), u32(crc), u32(body.length), u32(data.length), u16(nameBytes.length), u16(0), u16(0), u16(0), u16(0), u32(((0o100000 | mode) << 16) >>> 0), u32(offset), nameBytes]));
    offset += local.length + body.length;
  }
  const dir = Buffer.concat(central);
  const end = Buffer.concat([u32(0x06054b50), u16(0), u16(0), u16(entries.length), u16(entries.length), u32(dir.length), u32(offset), u16(0)]);
  return Buffer.concat([...parts, dir, end]);
}

/** Every file under a folder as zip entries (names relative to the folder, with an optional prefix). */
export function entriesOf(folder, prefix = '') {
  const out = [];
  const walk = (dir) => {
    for (const name of readdirSync(dir).sort()) {
      const full = join(dir, name);
      const s = statSync(full);
      if (s.isDirectory()) walk(full);
      else if (s.isFile()) out.push({ name: (prefix ? prefix + '/' : '') + relative(folder, full).split(sep).join('/'), data: readFileSync(full), mode: s.mode & 0o111 ? 0o755 : 0o644 });
    }
  };
  walk(folder);
  return out;
}

export function writeZip(path, entries) { writeFileSync(path, makeZip(entries)); }

/** Lists the names in a zip Buffer (to check a zip that was made). */
export function listZip(buffer) {
  const end = buffer.lastIndexOf(Buffer.from([0x50, 0x4b, 0x05, 0x06]));
  if (end < 0) throw new Error('This is not a zip.');
  const count = buffer.readUInt16LE(end + 10);
  let at = buffer.readUInt32LE(end + 16);
  const names = [];
  for (let i = 0; i < count; i += 1) {
    const n = buffer.readUInt16LE(at + 28), m = buffer.readUInt16LE(at + 30), k = buffer.readUInt16LE(at + 32);
    names.push(buffer.toString('utf8', at + 46, at + 46 + n));
    at += 46 + n + m + k;
  }
  return names;
}

/** Files that are already compressed: putting them in a zip again only costs time. */
const ALREADY_PACKED = /\.(exe|msi|deb|zip|apk|aab|gz|tgz|xz|7z|png|jpe?g|webp)$/i;
const MAX_ZIP_BYTES = 3.5 * 1024 ** 3;

/**
 * Writes a zip of big files without holding them in memory (a setup program can be 100 MB).
 *   items: [{ name, file?: 'path', data?: Buffer, mode?: 0o755 }]    (a name is checked the same way makeZip checks it)
 * Already-compressed files are stored as they are. Zip64 is not written: a pack over about 3.5 GB is refused.
 */
export async function writeZipFile(path, items, { when = new Date() } = {}) {
  const { time, date } = dosTime(when);
  for (const item of items) {   // every name is checked before anything is written
    const name = item.name.split(sep).join('/');
    if (!name || name.startsWith('/') || /^[A-Za-z]:/.test(name) || name.split('/').includes('..')) throw new Error(`A file in the zip has a name that is not allowed: ${name}`);
  }
  const out = createWriteStream(path);
  const failed = new Promise((_, reject) => out.on('error', reject));
  failed.catch(() => {});
  const write = (buf) => Promise.race([new Promise((res) => { if (out.write(buf)) res(); else out.once('drain', res); }), failed]);
  const central = [];
  let offset = 0;
  const put = async (buf) => { await write(buf); offset += buf.length; };
  const crcOf = async (file) => { let c = 0; for await (const chunk of createReadStream(file)) c = crc32(chunk, c); return c; };
  try {
    for (const item of items) {
      const name = item.name.split(sep).join('/');
      if (!name || name.startsWith('/') || /^[A-Za-z]:/.test(name) || name.split('/').includes('..')) throw new Error(`A file in the zip has a name that is not allowed: ${name}`);
      const nameBytes = Buffer.from(name, 'utf8');
      const mode = item.mode ?? (item.file && statSync(item.file).mode & 0o111 ? 0o755 : 0o644);
      const start = offset;
      let crc; let csize; let usize; let method;
      if (item.data !== undefined) {
        const data = Buffer.isBuffer(item.data) ? item.data : Buffer.from(item.data);
        const packed = deflateRawSync(data, { level: 9 });
        method = packed.length < data.length ? 8 : 0;
        const body = method === 8 ? packed : data;
        crc = crc32(data); csize = body.length; usize = data.length;
        await put(Buffer.concat([u32(0x04034b50), u16(20), u16(0x0800), u16(method), u16(time), u16(date), u32(crc), u32(csize), u32(usize), u16(nameBytes.length), u16(0), nameBytes]));
        await put(body);
      } else if (ALREADY_PACKED.test(name)) {
        usize = csize = statSync(item.file).size; method = 0; crc = await crcOf(item.file);
        await put(Buffer.concat([u32(0x04034b50), u16(20), u16(0x0800), u16(0), u16(time), u16(date), u32(crc), u32(csize), u32(usize), u16(nameBytes.length), u16(0), nameBytes]));
        for await (const chunk of createReadStream(item.file)) await put(chunk);
      } else {
        method = 8; crc = 0; usize = 0; csize = 0;
        await put(Buffer.concat([u32(0x04034b50), u16(20), u16(0x0808), u16(8), u16(time), u16(date), u32(0), u32(0), u32(0), u16(nameBytes.length), u16(0), nameBytes]));
        const deflate = createReadStream(item.file).pipe(createDeflateRaw({ level: 9 }));
        const reading = (async () => { for await (const chunk of createReadStream(item.file)) { crc = crc32(chunk, crc); usize += chunk.length; } })();
        for await (const chunk of deflate) { csize += chunk.length; await put(chunk); }
        await reading;
        await put(Buffer.concat([u32(0x08074b50), u32(crc), u32(csize), u32(usize)]));
      }
      if (offset > MAX_ZIP_BYTES) throw new Error('This pack is too big for one zip file (over 3.5 GB). Make the pack without the biggest part.');
      const flags = item.data === undefined && !ALREADY_PACKED.test(name) ? 0x0808 : 0x0800;
      central.push(Buffer.concat([u32(0x02014b50), u16(0x031e), u16(20), u16(flags), u16(method), u16(time), u16(date), u32(crc), u32(csize), u32(usize), u16(nameBytes.length), u16(0), u16(0), u16(0), u16(0), u32(((0o100000 | mode) << 16) >>> 0), u32(start), nameBytes]));
    }
    const dir = Buffer.concat(central);
    const cdOffset = offset;
    await put(dir);
    await put(Buffer.concat([u32(0x06054b50), u16(0), u16(0), u16(items.length), u16(items.length), u32(dir.length), u32(cdOffset), u16(0)]));
    await new Promise((res, rej) => { out.end(res); out.once('error', rej); });
  } catch (e) {
    out.destroy();
    await new Promise((res) => out.once('close', res));
    rmSync(path, { force: true });   // never leave half a zip that looks like a whole one
    throw e;
  }
}
