// The table of strings that Android's compiled files (the manifest, other compiled XML, resources.arsc) keep their text in. Strings are read, replaced in place or added at the end
// (so the numbers other parts use to point at a string stay valid), and the table is written again. A string that is not changed is written back byte for byte.

export class PoolError extends Error {}

export const STRING_POOL = 0x0001;
const UTF8_FLAG = 1 << 8;
const SORTED_FLAG = 1;

function readLen8(buf, at) { const a = buf[at]; return a & 0x80 ? [((a & 0x7f) << 8) | buf[at + 1], 2] : [a, 1]; }
function readLen16(buf, at) { const a = buf.readUInt16LE(at); return a & 0x8000 ? [((a & 0x7fff) << 16) | buf.readUInt16LE(at + 2), 4] : [a, 2]; }

/** Reads a string pool chunk that starts at `at` in `buf`. Returns the pool and the offset just after it. */
export function parsePool(buf, at = 0) {
  if (buf.length < at + 28 || buf.readUInt16LE(at) !== STRING_POOL) throw new PoolError('The list of words in this file is missing.');
  const headerSize = buf.readUInt16LE(at + 2);
  const size = buf.readUInt32LE(at + 4);
  const count = buf.readUInt32LE(at + 8);
  const styleCount = buf.readUInt32LE(at + 12);
  const flags = buf.readUInt32LE(at + 16);
  const stringsStart = buf.readUInt32LE(at + 20);
  const stylesStart = buf.readUInt32LE(at + 24);
  if (headerSize < 28 || at + size > buf.length || size < headerSize + count * 4 + styleCount * 4 || count > 5_000_000 || stringsStart > size) throw new PoolError('The list of words in this file is damaged.');
  const utf8 = (flags & UTF8_FLAG) !== 0;
  const strings = [];
  const end = stylesStart && styleCount ? at + stylesStart : at + size;
  for (let i = 0; i < count; i += 1) {
    const rel = buf.readUInt32LE(at + headerSize + i * 4);
    let p = at + stringsStart + rel;
    const start = p;
    if (p >= at + size) throw new PoolError('The list of words in this file is damaged.');
    let text;
    if (utf8) {
      const [chars, a] = readLen8(buf, p); p += a;
      const [bytes, b] = readLen8(buf, p); p += b;
      if (p + bytes > end) throw new PoolError('The list of words in this file is damaged.');
      text = buf.toString('utf8', p, p + bytes);
      p += bytes + 1;
      void chars;
    } else {
      const [chars, a] = readLen16(buf, p); p += a;
      if (p + chars * 2 > end) throw new PoolError('The list of words in this file is damaged.');
      text = buf.toString('utf16le', p, p + chars * 2);
      p += chars * 2 + 2;
    }
    strings.push({ text, raw: Buffer.from(buf.subarray(start, p)) });
  }
  const styleOffsets = [];
  for (let i = 0; i < styleCount; i += 1) styleOffsets.push(buf.readUInt32LE(at + headerSize + (count + i) * 4));
  const styleBytes = styleCount ? Buffer.from(buf.subarray(at + stylesStart, at + size)) : Buffer.alloc(0);
  return { pool: { utf8, flags, strings, styleOffsets, styleBytes, headerSize: 28 }, next: at + size };
}

function encodeString(text, utf8) {
  if (utf8) {
    const body = Buffer.from(text, 'utf8');
    const chars = text.length;
    if (chars > 0x7fff || body.length > 0x7fff) throw new PoolError('A word in this file is too long.');
    const len = (n) => (n > 0x7f ? Buffer.from([(n >> 8) | 0x80, n & 0xff]) : Buffer.from([n]));
    return Buffer.concat([len(chars), len(body.length), body, Buffer.from([0])]);
  }
  const body = Buffer.from(text, 'utf16le');
  const chars = text.length;
  const head = Buffer.alloc(chars > 0x7fff ? 4 : 2);
  if (chars > 0x7fff) { head.writeUInt16LE(0x8000 | (chars >> 16), 0); head.writeUInt16LE(chars & 0xffff, 2); } else head.writeUInt16LE(chars, 0);
  return Buffer.concat([head, body, Buffer.alloc(2)]);
}

/** Writes the pool as a chunk. Strings that were not changed keep their exact bytes. */
export function buildPool(pool) {
  const count = pool.strings.length;
  const styleCount = pool.styleOffsets.length;
  const encoded = pool.strings.map((s) => s.raw ?? encodeString(s.text, pool.utf8));
  const offsets = Buffer.alloc(count * 4);
  let at = 0;
  encoded.forEach((e, i) => { offsets.writeUInt32LE(at, i * 4); at += e.length; });
  let data = Buffer.concat(encoded);
  const padded = (data.length + 3) & ~3;
  data = Buffer.concat([data, Buffer.alloc(padded - data.length)]);
  const stringsStart = 28 + count * 4 + styleCount * 4;
  const stylesStart = styleCount ? stringsStart + data.length : 0;
  const size = stringsStart + data.length + (styleCount ? pool.styleBytes.length : 0);
  const head = Buffer.alloc(28);
  head.writeUInt16LE(STRING_POOL, 0); head.writeUInt16LE(28, 2); head.writeUInt32LE(size, 4);
  head.writeUInt32LE(count, 8); head.writeUInt32LE(styleCount, 12);
  head.writeUInt32LE(pool.flags >>> 0, 16);   // (a table that was changed has lost its "sorted" mark: setText and addText take it off)
  head.writeUInt32LE(stringsStart, 20); head.writeUInt32LE(stylesStart, 24);
  const styleOffs = Buffer.alloc(styleCount * 4);
  pool.styleOffsets.forEach((o, i) => styleOffs.writeUInt32LE(o, i * 4));
  return Buffer.concat([head, offsets, styleOffs, data, styleCount ? pool.styleBytes : Buffer.alloc(0)]);
}

export const textOf = (pool, i) => (i === 0xffffffff || i === -1 || i >= pool.strings.length ? null : pool.strings[i].text);

/** Changes the word at an index (every place that points at it changes with it). */
export function setText(pool, i, text) { pool.strings[i] = { text }; pool.flags &= ~SORTED_FLAG; }

/** Adds a word at the end and returns its index. An identical word that is there already is used instead. */
export function addText(pool, text) {
  const found = pool.strings.findIndex((s) => s.text === text);
  if (found >= 0) return found;
  pool.strings.push({ text }); pool.flags &= ~SORTED_FLAG;
  return pool.strings.length - 1;
}

/** Changes every word with `fn` (return the same text to leave it). Returns how many words changed. */
export function mapTexts(pool, fn) {
  let changed = 0;
  pool.strings.forEach((s, i) => { const next = fn(s.text, i); if (typeof next === 'string' && next !== s.text) { pool.strings[i] = { text: next }; changed += 1; } });
  if (changed) pool.flags &= ~SORTED_FLAG;
  return changed;
}
