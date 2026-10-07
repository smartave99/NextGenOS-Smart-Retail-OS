// An app's resource table (resources.arsc): the list of everything the app has by number (its name under the icon, its pictures, its styles), as Android reads it. It is read to find
// where things are; the only thing ever written back is the table of words (so a text such as the app's name can be changed). Everything else is carried over byte for byte.
import { parsePool, buildPool, textOf, STRING_POOL, PoolError } from './stringpool.mjs';

export class ArscError extends Error {}

const TABLE = 0x0002; const PACKAGE = 0x0200; const TYPE = 0x0201; const SPEC = 0x0202;
const FLAG_COMPLEX = 0x1; const FLAG_COMPACT = 0x8;
const NO_ENTRY = 0xffffffff;

function packageName(buf, at) {
  let s = '';
  for (let i = 0; i < 128; i += 1) { const c = buf.readUInt16LE(at + i * 2); if (!c) break; s += String.fromCharCode(c); }
  return s;
}

/**
 * Reads the table. Returns { pool, rest, packages }, where `packages[i].entries` lists every value of every resource:
 *   { resId, type, key, config (the bytes), density, night, complex, value: { type, data } | null, map: [{ name, type, data }] | null, parent }
 * `value.type` 0x03 means text, and `data` is then a number in the table of words.
 */
export function parseArsc(buf) {
  if (!Buffer.isBuffer(buf) || buf.length < 12 || buf.readUInt16LE(0) !== TABLE) throw new ArscError('This is not an Android resource table.');
  const total = buf.readUInt32LE(4);
  if (total > buf.length) throw new ArscError('The resource table is cut short.');
  const headerSize = buf.readUInt16LE(2);
  let pool; let next;
  try { ({ pool, next } = parsePool(buf, headerSize)); } catch (e) { if (e instanceof PoolError) throw new ArscError(e.message); throw e; }
  const rest = Buffer.from(buf.subarray(next, total));
  const packages = [];
  let at = next;
  while (at + 8 <= total) {
    const type = buf.readUInt16LE(at); const size = buf.readUInt32LE(at + 4);
    if (size < 8 || at + size > total) throw new ArscError('The resource table is damaged.');
    if (type === PACKAGE) packages.push(readPackage(buf, at, size));
    at += size;
  }
  return { pool, rest, packages, headerSize };
}

function readPackage(buf, start, size) {
  const headerSize = buf.readUInt16LE(start + 2);
  const id = buf.readUInt32LE(start + 8);
  const name = packageName(buf, start + 12);
  const typeStrings = buf.readUInt32LE(start + 268); const keyStrings = buf.readUInt32LE(start + 276);
  const typeIdOffset = headerSize >= 288 ? buf.readUInt32LE(start + 284) : 0;
  let types; let keys;
  try { types = parsePool(buf, start + typeStrings).pool; keys = parsePool(buf, start + keyStrings).pool; } catch (e) { if (e instanceof PoolError) throw new ArscError(e.message); throw e; }
  const entries = [];
  let at = start + headerSize;
  const end = start + size;
  while (at + 8 <= end) {
    const type = buf.readUInt16LE(at); const csize = buf.readUInt32LE(at + 4);
    if (csize < 8 || at + csize > end) throw new ArscError('The resource table is damaged.');
    if (type === TYPE) readType(buf, at, csize, { id, types, keys, typeIdOffset, entries });
    at += csize;
  }
  return { id, name, types, keys, entries };
}

function readType(buf, at, size, ctx) {
  const headerSize = buf.readUInt16LE(at + 2);
  const typeId = buf[at + 8]; const flags = buf[at + 9];
  const count = buf.readUInt32LE(at + 12); const entriesStart = buf.readUInt32LE(at + 16);
  const configSize = buf.readUInt32LE(at + 20);
  const config = Buffer.from(buf.subarray(at + 20, at + 20 + Math.min(configSize, headerSize - 20)));
  const sdk = config.length >= 28 ? config.readUInt16LE(24) : 0;
  const density = config.length >= 16 ? config.readUInt16LE(14) : 0;
  const night = config.length >= 30 ? (config[29] & 0x30) === 0x20 : false;
  const typeName = textOf(ctx.types, typeId - 1 - ctx.typeIdOffset) ?? `type${typeId}`;
  const items = [];   // [entryIndex, offset]
  if (flags & 0x01) for (let i = 0; i < count; i += 1) { const p = at + headerSize + i * 4; items.push([buf.readUInt16LE(p), buf.readUInt16LE(p + 2) * 4]); }
  else if (flags & 0x02) for (let i = 0; i < count; i += 1) { const o = buf.readUInt16LE(at + headerSize + i * 2); if (o !== 0xffff) items.push([i, o * 4]); }
  else for (let i = 0; i < count; i += 1) { const o = buf.readUInt32LE(at + headerSize + i * 4); if (o !== NO_ENTRY) items.push([i, o]); }
  for (const [index, offset] of items) {
    const p = at + entriesStart + offset;
    if (p + 8 > at + size) throw new ArscError('The resource table is damaged.');
    const e = { resId: ((ctx.id << 24) | (typeId << 16) | index) >>> 0, type: typeName, config, density, night, sdk, complex: false, value: null, map: null, parent: 0, key: null };
    const eflags = buf.readUInt16LE(p + 2);
    if (eflags & FLAG_COMPACT) {   // a short entry: the name in the first two bytes, the kind of value in the high byte of the flags, the value after them
      e.key = textOf(ctx.keys, buf.readUInt16LE(p));
      e.value = { type: eflags >> 8, data: buf.readUInt32LE(p + 4) };
    } else {
      const esize = buf.readUInt16LE(p);
      e.key = textOf(ctx.keys, buf.readUInt32LE(p + 4));
      if (eflags & FLAG_COMPLEX) {
        e.complex = true;
        e.parent = buf.readUInt32LE(p + 8);
        const n = buf.readUInt32LE(p + 12);
        e.map = [];
        for (let m = 0; m < n && p + esize + m * 12 + 12 <= at + size; m += 1) { const q = p + esize + m * 12; e.map.push({ name: buf.readUInt32LE(q), type: buf[q + 7], data: buf.readUInt32LE(q + 8) }); }
      } else e.value = { type: buf[p + esize + 3], data: buf.readUInt32LE(p + esize + 4) };
    }
    ctx.entries.push(e);
  }
}

/** Every value of the resource with this number, over all kinds of screen. */
export const entriesFor = (table, resId) => table.packages.flatMap((p) => p.entries).filter((e) => e.resId === resId);

/** The text of a plain text value ("res/mipmap-hdpi/ic_launcher.png" for a file, or the words themselves). */
export const textValue = (table, e) => (e?.value && e.value.type === 0x03 ? textOf(table.pool, e.value.data) : null);

/** Writes the table again (only the table of words can have changed). */
export function buildArsc(table) {
  const pool = buildPool(table.pool);
  const body = Buffer.concat([pool, table.rest]);
  const head = Buffer.alloc(table.headerSize);
  head.writeUInt16LE(TABLE, 0); head.writeUInt16LE(table.headerSize, 2); head.writeUInt32LE(table.headerSize + body.length, 4); head.writeUInt32LE(table.packages.length, 8);
  return Buffer.concat([head, body]);
}

export { STRING_POOL };
