// A small, careful zip reader, so that the Studio can open a finished program (the website package) without needing any tool installed, and without trusting the names inside it.
// It reads what zip.mjs writes (and ordinary zips): stored and deflated files, no encryption, no zip64. A name that is absolute, has a drive letter, a "..", a
// backslash or a zero byte, a link, a second file of the same name, or more than the limits, is refused and nothing is written.
import { closeSync, chmodSync, fstatSync, mkdirSync, openSync, readSync, writeFileSync } from 'node:fs';
import { dirname, resolve, sep } from 'node:path';
import { crc32, inflateRawSync } from 'node:zlib';

export class ZipError extends Error {}

const LIMITS = { files: 100_000, bytes: 3 * 1024 ** 3 };

function readAt(fd, position, length) {
  const buffer = Buffer.alloc(length);
  let done = 0;
  while (done < length) {
    const n = readSync(fd, buffer, done, length - done, position + done);
    if (n === 0) throw new ZipError('The zip is cut short: it was not saved or copied whole.');
    done += n;
  }
  return buffer;
}

/** A name from inside a zip, checked: the same rule as the one that writes (zip.mjs), and stricter about backslashes and zero bytes. */
export function safeEntryName(raw) {
  const name = String(raw);
  if (!name || name.startsWith('/') || /^[A-Za-z]:/.test(name) || name.includes('\\') || name.includes('\0') || name.split('/').some((part) => part === '..')) {
    throw new ZipError(`A file in the zip has a name that is not allowed: ${name.replace(/[^\x20-\x7e]/g, '?').slice(0, 80)}`);
  }
  return name;
}

/** Lists the entries of a zip file: [{ name, directory, method, crc, compressed, size, offset, mode, flags }]. */
export function readEntries(file) {
  const fd = openSync(file, 'r');
  try {
    const total = fstatSync(fd).size;
    const tailLength = Math.min(total, 65557);
    const tail = readAt(fd, total - tailLength, tailLength);
    const end = tail.lastIndexOf(Buffer.from([0x50, 0x4b, 0x05, 0x06]));
    if (end < 0) throw new ZipError('This is not a zip file.');
    const count = tail.readUInt16LE(end + 10);
    const size = tail.readUInt32LE(end + 12);
    const offset = tail.readUInt32LE(end + 16);
    if (count === 0xffff || size === 0xffffffff || offset === 0xffffffff) throw new ZipError('This zip is too big for this Studio (it needs the zip64 form).');
    if (count > LIMITS.files) throw new ZipError(`The zip holds more than ${LIMITS.files} files.`);
    const directory = readAt(fd, offset, size);
    const entries = [];
    let at = 0;
    let bytes = 0;
    for (let i = 0; i < count; i += 1) {
      if (directory.readUInt32LE(at) !== 0x02014b50) throw new ZipError('The zip is damaged (its list of files cannot be read).');
      const madeBy = directory.readUInt16LE(at + 4);
      const flags = directory.readUInt16LE(at + 8);
      const nameLength = directory.readUInt16LE(at + 28);
      const extraLength = directory.readUInt16LE(at + 30);
      const commentLength = directory.readUInt16LE(at + 32);
      const name = safeEntryName(directory.toString('utf8', at + 46, at + 46 + nameLength));
      const external = directory.readUInt32LE(at + 38);
      const mode = madeBy >> 8 === 3 ? (external >>> 16) & 0xffff : 0;
      const entry = {
        name, directory: name.endsWith('/'), flags, method: directory.readUInt16LE(at + 10), crc: directory.readUInt32LE(at + 16),
        compressed: directory.readUInt32LE(at + 20), size: directory.readUInt32LE(at + 24), offset: directory.readUInt32LE(at + 42), mode,
      };
      bytes += entry.size;
      if (bytes > LIMITS.bytes) throw new ZipError('The zip would unpack to more than 3 GB, which is more than any program of ours.');
      entries.push(entry);
      at += 46 + nameLength + extraLength + commentLength;
    }
    return entries;
  } finally {
    closeSync(fd);
  }
}

/**
 * Unpacks a zip file into a folder (made if it is missing). Returns { files, bytes, tops } where tops are the names at the top of the zip.
 * Nothing leaves the folder: every name is checked, a link is refused, a name used twice is refused, and every file's size and fingerprint are checked after it is read.
 */
export function extractZip(file, folder) {
  const entries = readEntries(file);
  const root = resolve(folder);
  mkdirSync(root, { recursive: true });
  const seen = new Set();
  const tops = new Set();
  for (const e of entries) {
    const key = e.name.toLowerCase();
    if (seen.has(key)) throw new ZipError(`The zip holds the name ${e.name} twice.`);
    seen.add(key);
    if ((e.mode & 0o170000) === 0o120000) throw new ZipError(`The zip holds a link (${e.name}), which is not allowed.`);
    if (e.flags & 1) throw new ZipError('The zip is locked with a password.');
    tops.add(e.name.split('/')[0]);
  }
  const fd = openSync(file, 'r');
  let files = 0;
  let bytes = 0;
  try {
    for (const e of entries) {
      const target = resolve(root, ...e.name.split('/'));
      if (target !== root && !target.startsWith(root + sep)) throw new ZipError(`A file in the zip would be written outside the folder: ${e.name.slice(0, 80)}`);
      if (e.directory) { mkdirSync(target, { recursive: true }); continue; }
      const local = readAt(fd, e.offset, 30);
      if (local.readUInt32LE(0) !== 0x04034b50) throw new ZipError('The zip is damaged (a file cannot be found where the list says).');
      const start = e.offset + 30 + local.readUInt16LE(26) + local.readUInt16LE(28);
      const raw = readAt(fd, start, e.compressed);
      let data;
      if (e.method === 0) data = raw;
      else if (e.method === 8) {
        try { data = inflateRawSync(raw, { maxOutputLength: e.size + 1 }); } catch { throw new ZipError(`${e.name} is damaged inside the zip.`); }
      } else throw new ZipError(`${e.name} is packed in a way this Studio cannot open.`);
      if (data.length !== e.size || crc32(data) !== e.crc) throw new ZipError(`${e.name} does not match its fingerprint inside the zip: the zip is damaged.`);
      mkdirSync(dirname(target), { recursive: true });
      writeFileSync(target, data);
      if (process.platform !== 'win32') chmodSync(target, e.mode & 0o111 ? 0o755 : 0o644);
      files += 1;
      bytes += data.length;
    }
  } finally {
    closeSync(fd);
  }
  return { files, bytes, tops: [...tops] };
}
