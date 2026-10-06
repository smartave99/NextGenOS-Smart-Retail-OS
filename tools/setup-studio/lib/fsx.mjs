// Small, careful file helpers: a file is never half written (written beside, then moved into place), and nothing leaves the folder it is meant for.
import { writeFileSync, renameSync, mkdirSync, readFileSync, existsSync, rmSync, openSync, closeSync, statSync, chmodSync } from 'node:fs';
import { dirname, join, resolve, sep } from 'node:path';
import { createHash, randomBytes } from 'node:crypto';

export function writeAtomic(path, data, { mode } = {}) {
  mkdirSync(dirname(path), { recursive: true });
  const temp = `${path}.${process.pid}.${randomBytes(4).toString('hex')}.tmp`;
  writeFileSync(temp, data, mode ? { mode } : undefined);
  renameSync(temp, path);
}

export const writeJson = (path, value, options) => writeAtomic(path, JSON.stringify(value, null, 2) + '\n', options);

export function readJson(path, fallback = null) {
  if (!existsSync(path)) return fallback;
  try { return JSON.parse(readFileSync(path, 'utf8')); } catch { return fallback; }
}

export const sha256 = (data) => createHash('sha256').update(data).digest('hex');

/** The same text for the same value whatever order the fields were written in: used to stamp what a person approved. */
export function canonical(value) {
  if (Array.isArray(value)) return '[' + value.map(canonical).join(',') + ']';
  if (value && typeof value === 'object') return '{' + Object.keys(value).sort().map((k) => JSON.stringify(k) + ':' + canonical(value[k])).join(',') + '}';
  return JSON.stringify(value);
}

/** A path inside a folder, or an error: a name from outside can never reach out of it. */
export function inside(root, ...parts) {
  const base = resolve(root);
  const full = resolve(base, ...parts);
  if (full !== base && !full.startsWith(base + sep)) throw new Error('That path is outside the folder.');
  return full;
}

/** Runs work while holding a lock file (made with "wx"); waits a little for another holder, and breaks a lock left behind long ago. */
export function withLock(lockPath, work, { waitMs = 3000, staleMs = 15000 } = {}) {
  const until = Date.now() + waitMs;
  mkdirSync(dirname(lockPath), { recursive: true });
  for (;;) {
    try { closeSync(openSync(lockPath, 'wx')); break; } catch (e) {
      if (e.code !== 'EEXIST') throw e;
      try { if (Date.now() - statSync(lockPath).mtimeMs > staleMs) { rmSync(lockPath, { force: true }); continue; } } catch { continue; }
      if (Date.now() > until) throw new Error('Another copy of the Studio is saving at this moment. Please try again in a few seconds.');
      Atomics.wait(new Int32Array(new SharedArrayBuffer(4)), 0, 0, 25);
    }
  }
  try { return work(); } finally { rmSync(lockPath, { force: true }); }
}

export function makeReadOnly(path) { try { chmodSync(path, 0o444); } catch { /* not every system has the permission to give */ } }
export { join };
