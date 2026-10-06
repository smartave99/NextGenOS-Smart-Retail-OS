// A small writer for Debian packages (.deb), so the Studio can make a customer's profile package on any PC, with no Linux tools installed. A .deb is an "ar" archive of three
// parts: the version note, the control archive (what the package is, and its scripts) and the data archive (the files). Both archives are gzip-compressed tar files.
import { createHash } from 'node:crypto';
import { gzipSync, gunzipSync } from 'node:zlib';

const PACKAGE = /^[a-z0-9][a-z0-9+.-]+$/;
const VERSION = /^[0-9][A-Za-z0-9.+~-]*$/;
const ARCH = /^(all|amd64|arm64)$/;
const oneLine = (v) => String(v).replace(/[\r\n]+/g, ' ').trim();

function octal(n, width) { return n.toString(8).padStart(width - 1, '0') + '\0'; }

/** One tar entry (ustar): a 512-byte header, then the data padded to 512. Names over 100 letters are split at a "/" into the prefix field. */
function tarEntry({ name, data = null, mode, type }, mtime) {
  let prefix = '';
  let base = name;
  if (Buffer.byteLength(base) > 100) {
    let found = -1;
    for (let i = base.indexOf('/'); i !== -1; i = base.indexOf('/', i + 1)) {
      if (Buffer.byteLength(base.slice(0, i)) <= 155 && Buffer.byteLength(base.slice(i + 1)) <= 100) { found = i; break; }
    }
    if (found < 0) throw new Error(`A file name in the package is too long: ${name}`);
    prefix = base.slice(0, found); base = base.slice(found + 1);
  }
  const size = type === '5' ? 0 : data.length;
  const h = Buffer.alloc(512);
  h.write(base, 0, 100, 'utf8');
  h.write(octal(mode, 8), 100); h.write(octal(0, 8), 108); h.write(octal(0, 8), 116);
  h.write(octal(size, 12), 124); h.write(octal(mtime, 12), 136);
  h.write('        ', 148);
  h.write(type, 156);
  h.write('ustar\0', 257); h.write('00', 263);
  h.write('root', 265); h.write('root', 297);
  h.write(octal(0, 8), 329); h.write(octal(0, 8), 337);
  h.write(prefix, 345, 155, 'utf8');
  let sum = 0;
  for (const b of h) sum += b;
  h.write(sum.toString(8).padStart(6, '0') + '\0 ', 148);
  const pad = (512 - (size % 512)) % 512;
  return type === '5' ? h : Buffer.concat([h, data, Buffer.alloc(pad)]);
}

/** entries: [{ name: 'opt/x/y.json', data: Buffer, mode: 0o644 }]. The folders above each file are added (owned by root, 0755). Returns a gzip-compressed tar file. */
function tarGz(entries, mtime) {
  const dirs = new Set();
  for (const e of entries) {
    const parts = e.name.split('/');
    for (let i = 1; i < parts.length; i += 1) dirs.add(parts.slice(0, i).join('/'));
  }
  const list = [{ name: './', type: '5', mode: 0o755 }, ...[...dirs].sort().map((d) => ({ name: `./${d}/`, type: '5', mode: 0o755 })), ...entries.map((e) => ({ name: `./${e.name}`, data: e.data, mode: e.mode ?? 0o644, type: '0' }))];
  const blocks = list.map((e) => tarEntry(e, mtime));
  return gzipSync(Buffer.concat([...blocks, Buffer.alloc(1024)]), { level: 9, mtime: 0 });
}

function arMember(name, data, mtime) {
  const h = Buffer.alloc(60, 0x20);
  h.write(name, 0, 16, 'latin1'); h.write(String(mtime), 16, 12, 'latin1'); h.write('0', 28, 6, 'latin1'); h.write('0', 34, 6, 'latin1'); h.write('100644', 40, 8, 'latin1');
  h.write(String(data.length), 48, 10, 'latin1'); h.write('`\n', 58, 2, 'latin1');
  return Buffer.concat([h, data, data.length % 2 ? Buffer.from('\n') : Buffer.alloc(0)]);
}

/**
 * Makes a .deb.
 *   control: { Package, Version, Architecture, Maintainer, Description (first line, then more lines), Depends?, Conflicts?, Provides?, Replaces?, Section?, Priority? }
 *   files:   [{ name: 'opt/nextgenos/x.txt', data: Buffer | string, mode?: 0o644 }]
 *   scripts: { postinst?, prerm?, postrm?, preinst? }  (text of a shell script)
 */
export function makeDeb({ control, files, scripts = {}, when = new Date() }) {
  if (!PACKAGE.test(control.Package ?? '')) throw new Error('The package name must be small letters, numbers, + - and .');
  if (!VERSION.test(control.Version ?? '')) throw new Error('The package version must start with a number.');
  if (!ARCH.test(control.Architecture ?? '')) throw new Error('The package system must be all, amd64 or arm64.');
  const mtime = Math.floor(when.getTime() / 1000);
  const data = files.map((f) => {
    if (!f.name || f.name.startsWith('/') || f.name.split('/').some((p) => p === '..' || p === '')) throw new Error(`A file in the package has a name that is not allowed: ${f.name}`);
    return { name: f.name, data: Buffer.isBuffer(f.data) ? f.data : Buffer.from(f.data), mode: f.mode ?? 0o644 };
  });
  const installedKib = Math.max(1, Math.ceil(data.reduce((n, f) => n + f.data.length, 0) / 1024));
  const order = ['Package', 'Version', 'Architecture', 'Maintainer', 'Installed-Size', 'Depends', 'Recommends', 'Conflicts', 'Provides', 'Replaces', 'Section', 'Priority'];
  const fields = { Section: 'misc', Priority: 'optional', ...control, 'Installed-Size': String(installedKib) };
  const [first, ...more] = String(control.Description ?? '').split('\n');
  const text = order.filter((k) => fields[k]).map((k) => `${k}: ${oneLine(fields[k])}`).join('\n')
    + `\nDescription: ${oneLine(first || control.Package)}\n${more.map((l) => ' ' + (l.trim() === '' ? '.' : oneLine(l))).join('\n')}${more.length ? '\n' : ''}`;
  const md5 = data.map((f) => `${createHash('md5').update(f.data).digest('hex')}  ${f.name}`).join('\n') + '\n';
  const controlFiles = [{ name: 'control', data: Buffer.from(text), mode: 0o644 }, { name: 'md5sums', data: Buffer.from(md5), mode: 0o644 }];
  for (const key of ['preinst', 'postinst', 'prerm', 'postrm']) if (scripts[key]) controlFiles.push({ name: key, data: Buffer.from(scripts[key]), mode: 0o755 });
  // The control archive has no folder entries but "./" in packages dpkg builds; a plain list of files is just as valid.
  const controlTar = gzipSync(Buffer.concat([...controlFiles.map((e) => tarEntry({ name: `./${e.name}`, data: e.data, mode: e.mode, type: '0' }, mtime)), Buffer.alloc(1024)]), { level: 9, mtime: 0 });
  return Buffer.concat([Buffer.from('!<arch>\n'), arMember('debian-binary', Buffer.from('2.0\n'), mtime), arMember('control.tar.gz', controlTar, mtime), arMember('data.tar.gz', tarGz(data, mtime), mtime)]);
}

/** Reads a .deb back (to check one that was made): { control: 'text', scripts: {name: text}, files: [{ name, mode, data }] }. */
export function readDeb(buffer) {
  if (buffer.subarray(0, 8).toString('latin1') !== '!<arch>\n') throw new Error('This is not a Debian package.');
  const parts = {};
  for (let at = 8; at + 60 <= buffer.length;) {
    const name = buffer.subarray(at, at + 16).toString('latin1').trim().replace(/\/$/, '');
    const size = Number(buffer.subarray(at + 48, at + 58).toString('latin1').trim());
    parts[name] = buffer.subarray(at + 60, at + 60 + size);
    at += 60 + size + (size % 2);
  }
  const untar = (gz) => {
    const tar = gunzipSync(gz);
    const out = [];
    for (let at = 0; at + 512 <= tar.length;) {
      const h = tar.subarray(at, at + 512);
      if (h.every((b) => b === 0)) break;
      const str = (from, len) => h.toString('utf8', from, from + len).replace(/\0.*$/s, '');
      let sum = 0;
      for (let i = 0; i < 512; i += 1) sum += i >= 148 && i < 156 ? 0x20 : h[i];
      if (sum !== parseInt(str(148, 8).trim(), 8)) throw new Error('A file in the package has a wrong checksum.');
      const size = parseInt(str(124, 12).trim() || '0', 8);
      const prefix = str(345, 155);
      out.push({ name: (prefix ? prefix + '/' : '') + str(0, 100), mode: parseInt(str(100, 8).trim() || '0', 8), type: str(156, 1) || '0', data: tar.subarray(at + 512, at + 512 + size) });
      at += 512 + Math.ceil(size / 512) * 512;
    }
    return out;
  };
  const control = untar(parts['control.tar.gz']);
  const named = Object.fromEntries(control.map((e) => [e.name.replace(/^\.\//, ''), e.data.toString('utf8')]));
  const { control: text, md5sums, ...scripts } = named;
  return { control: text, md5sums, scripts, files: untar(parts['data.tar.gz']).filter((e) => e.type === '0').map((e) => ({ name: e.name.replace(/^\.\//, ''), mode: e.mode, data: e.data })) };
}
