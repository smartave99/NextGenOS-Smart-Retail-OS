// Android's compiled XML (the app's AndroidManifest.xml and the other small XML files inside an .apk). Read it, look at its elements and attributes, change the words and numbers in
// it, and write it again. Nothing is added or taken away except words at the end of the word table, so every other part stays byte for byte as it was.
import { parsePool, buildPool, textOf, setText, addText, mapTexts, STRING_POOL, PoolError } from './stringpool.mjs';

export class AxmlError extends Error {}

const XML_TYPE = 0x0003; const RESOURCE_MAP = 0x0180;
const START_ELEMENT = 0x0102; const END_ELEMENT = 0x0103;
export const TYPE = { NULL: 0x00, REFERENCE: 0x01, ATTRIBUTE: 0x02, STRING: 0x03, FLOAT: 0x04, DIMENSION: 0x05, FRACTION: 0x06, INT_DEC: 0x10, INT_HEX: 0x11, INT_BOOLEAN: 0x12 };
export const ANDROID_NS = 'http://schemas.android.com/apk/res/android';
const NONE = 0xffffffff;

/** Reads a compiled XML file. */
export function parseAxml(buf) {
  if (!Buffer.isBuffer(buf) || buf.length < 8 || buf.readUInt16LE(0) !== XML_TYPE) throw new AxmlError('This is not a compiled Android XML file.');
  const total = buf.readUInt32LE(4);
  if (total > buf.length) throw new AxmlError('This compiled XML file is cut short.');
  let at = buf.readUInt16LE(2);
  let pool = null; let map = null;
  const nodes = [];
  try {
    while (at + 8 <= total) {
      const type = buf.readUInt16LE(at); const size = buf.readUInt32LE(at + 4);
      if (size < 8 || at + size > total) throw new AxmlError('This compiled XML file is damaged.');
      if (type === STRING_POOL && !pool) { pool = parsePool(buf, at).pool; }
      else if (type === RESOURCE_MAP && !map) map = Buffer.from(buf.subarray(at, at + size));
      else nodes.push({ type, raw: Buffer.from(buf.subarray(at, at + size)) });
      at += size;
    }
  } catch (e) { if (e instanceof PoolError) throw new AxmlError(e.message); throw e; }
  if (!pool) throw new AxmlError('This compiled XML file has no list of words.');
  return { pool, map, nodes };
}

/** Writes it again. */
export function buildAxml(doc) {
  const pool = buildPool(doc.pool);
  const body = Buffer.concat([pool, ...(doc.map ? [doc.map] : []), ...doc.nodes.map((n) => n.raw)]);
  const head = Buffer.alloc(8); head.writeUInt16LE(XML_TYPE, 0); head.writeUInt16LE(8, 2); head.writeUInt32LE(8 + body.length, 4);
  return Buffer.concat([head, body]);
}

/** The attribute ids the map holds for the first words of the table (so an attribute can be named by its number as well as its word). */
const mapIds = (doc) => (doc.map ? Array.from({ length: (doc.map.length - 8) / 4 }, (_, i) => doc.map.readUInt32LE(8 + i * 4)) : []);

/**
 * Every element in order, as { name, depth, attrs: [{ ns, name, resId, type, data, text, raw, at }], node }. `text` is the attribute's value as words when it is a string.
 * An attribute's `at` is where it sits in the element's bytes (so it can be changed in place).
 */
export function elementsOf(doc) {
  const ids = mapIds(doc);
  const out = [];
  let depth = 0;
  for (const node of doc.nodes) {
    if (node.type === END_ELEMENT) { depth -= 1; continue; }
    if (node.type !== START_ELEMENT) continue;
    const r = node.raw;
    const name = textOf(doc.pool, r.readUInt32LE(20));
    const attrStart = r.readUInt16LE(24); const attrSize = r.readUInt16LE(26); const count = r.readUInt16LE(28);
    const attrs = [];
    for (let i = 0; i < count; i += 1) {
      const at = 16 + attrStart + i * attrSize;
      const nsIdx = r.readUInt32LE(at); const nameIdx = r.readUInt32LE(at + 4); const rawIdx = r.readUInt32LE(at + 8);
      const type = r[at + 15]; const data = r.readUInt32LE(at + 16);
      attrs.push({ ns: nsIdx === NONE ? null : textOf(doc.pool, nsIdx), name: textOf(doc.pool, nameIdx), resId: ids[nameIdx] ?? null, type, data, raw: rawIdx, at, text: type === TYPE.STRING ? textOf(doc.pool, data) : rawIdx !== NONE ? textOf(doc.pool, rawIdx) : null });
    }
    out.push({ name, depth, attrs, node });
    depth += 1;
  }
  return out;
}

/** The attribute of an element by its word and (optionally) its name space, or undefined. */
export const attrOf = (el, name, ns = ANDROID_NS) => el.attrs.find((a) => a.name === name && (ns === undefined || a.ns === ns || (ns === null && a.ns === null)));

/** What an attribute says, in plain terms: a string, a number, true/false, or a reference like "@0x7f0e0001". */
export function valueOf(a) {
  if (!a) return undefined;
  switch (a.type) {
    case TYPE.STRING: return a.text;
    case TYPE.REFERENCE: return `@0x${a.data.toString(16).padStart(8, '0')}`;
    case TYPE.INT_BOOLEAN: return a.data !== 0;
    case TYPE.INT_DEC: return a.data | 0;
    case TYPE.INT_HEX: return a.data;
    default: return a.text ?? a.data;
  }
}
export const refOf = (a) => (a && a.type === TYPE.REFERENCE ? a.data : null);

/** Changes a number attribute (such as versionCode) in place. */
export function setInt(el, attr, value) {
  if (!attr || ![TYPE.INT_DEC, TYPE.INT_HEX].includes(attr.type)) throw new AxmlError(`${attr?.name ?? 'That setting'} is not a number in this file.`);
  el.node.raw.writeUInt32LE(value >>> 0, attr.at + 16);
  attr.data = value >>> 0;
}

/** Makes a string attribute say something else. A new word is added for it, so no other place that used the old word is touched. */
export function setString(doc, el, attr, text) {
  if (!attr || attr.type !== TYPE.STRING) throw new AxmlError(`${attr?.name ?? 'That setting'} is not text in this file.`);
  const idx = addText(doc.pool, text);
  el.node.raw.writeUInt32LE(idx, attr.at + 8);
  el.node.raw.writeUInt32LE(idx, attr.at + 16);
  attr.data = idx; attr.raw = idx; attr.text = text;
}

export { mapTexts, setText, addText, textOf };
