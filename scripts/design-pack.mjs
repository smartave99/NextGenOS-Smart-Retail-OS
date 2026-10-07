#!/usr/bin/env node
/**
 * The file side of a design pack (scripts/lib/design-pack.mjs has the rules; docs/DESIGN-PACK.md says it in plain words).
 *
 *   node scripts/design-pack.mjs check <design-pack.json>
 *       Checks the pack and says, in plain words, everything that is wrong. Exit code 0 only when the pack can be used. It changes nothing.
 *   node scripts/design-pack.mjs build <design-pack.json> --out <folder>
 *       Checks the pack and writes what the website would serve: <folder>/ngos-design/design.css and <folder>/ngos-design/assets/... (for looking at the result).
 *
 * The website build uses loadDesignPack() and writeDesignPack(): the pack is checked again there, whatever checked it before, and the build stops with the plain message when it is not
 * acceptable. The website then loads /ngos-design/design.css (src/lib/design/ in the storefront). Nothing here ever touches the repository's own website folder.
 */
import { existsSync, mkdirSync, readFileSync, rmSync, statSync, writeFileSync } from 'node:fs';
import { join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { findSecrets } from './audit-package.mjs';
import { compileDesignPack, DesignPackError, formatProblems, validateDesignPack, LIMITS } from './lib/design-pack.mjs';

/** The folder inside the website's public folder where a pack's files go. The storefront (src/lib/design) links to /ngos-design/design.css. */
export const DESIGN_DIR = 'ngos-design';
/** The build setting that tells the website which pack it was built with (a short id). Without it, the website does not load a pack and looks as it always did. */
export const DESIGN_ENV = 'NEXT_PUBLIC_NGOS_DESIGN';
/** The name a pack has in a customer's brand kit and in the bundle the Setup Studio sends. */
export const DESIGN_PACK_FILE = 'design-pack.json';

/** A problem a person can put right: said in plain words. */
export class DesignPackFileError extends Error {}

const scanner = (text) => findSecrets(text);

/** Reads and checks a pack file. Returns { ok, problems, message }. Never throws for a bad pack. */
export function checkDesignPackFile(file) {
  const path = resolve(file);
  if (!existsSync(path) || !statSync(path).isFile()) return { ok: false, problems: [], message: `The design pack ${file} was not found.` };
  if (statSync(path).size > LIMITS.packBytes) return { ok: false, problems: [], message: `The design pack ${file} is bigger than ${LIMITS.packBytes / 1024 / 1024} MB.` };
  const r = validateDesignPack(readFileSync(path), { findSecrets: scanner });
  return { ok: r.ok, problems: r.problems, message: r.ok ? '' : `The design pack cannot be used:\n${formatProblems(r.problems)}` };
}

/** Checks a pack file and writes it out as the website serves it. Returns { css, assets, id, name, files }. Throws DesignPackFileError with the plain message when the pack is not acceptable. */
export function loadDesignPack(file) {
  const path = resolve(file);
  if (!existsSync(path) || !statSync(path).isFile()) throw new DesignPackFileError(`The design pack ${file} was not found.`);
  if (statSync(path).size > LIMITS.packBytes) throw new DesignPackFileError(`The design pack is bigger than ${LIMITS.packBytes / 1024 / 1024} MB.`);
  try { return compileDesignPack(readFileSync(path), { findSecrets: scanner }); } catch (e) {
    if (e instanceof DesignPackError) throw new DesignPackFileError(e.message);
    throw e;
  }
}

/** Writes a compiled pack under <publicDir>/ngos-design (any earlier pack there is removed first, so a folder never holds two). Returns the files written, relative to publicDir. */
export function writeDesignPack(compiled, publicDir) {
  const root = join(resolve(publicDir), DESIGN_DIR);
  rmSync(root, { recursive: true, force: true });
  mkdirSync(join(root, 'assets'), { recursive: true });
  writeFileSync(join(root, 'design.css'), compiled.css);
  const written = [`${DESIGN_DIR}/design.css`];
  for (const [name, bytes] of Object.entries(compiled.assets)) {
    writeFileSync(join(root, 'assets', name), bytes);
    written.push(`${DESIGN_DIR}/assets/${name}`);
  }
  return written;
}

/** Takes a pack away (nothing is left of it in the website's public folder). */
export function removeDesignPack(publicDir) {
  rmSync(join(resolve(publicDir), DESIGN_DIR), { recursive: true, force: true });
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const [command, file, ...rest] = process.argv.slice(2);
  const flag = (n) => { const i = rest.indexOf(n); return i >= 0 ? rest[i + 1] : undefined; };
  if (!['check', 'build'].includes(command) || !file) {
    console.error('Usage: node scripts/design-pack.mjs check <design-pack.json>\n       node scripts/design-pack.mjs build <design-pack.json> --out <folder>');
    process.exit(2);
  }
  if (command === 'check') {
    const r = checkDesignPackFile(file);
    if (!r.ok) { console.error(r.message); process.exit(1); }
    console.log('The design pack can be used: nothing that is not allowed was found. (A person must still look at the preview: this check cannot judge how it looks.)');
  } else {
    const out = flag('--out');
    if (!out) { console.error('Say where to write: --out <folder>'); process.exit(2); }
    try {
      const compiled = loadDesignPack(file);
      const files = writeDesignPack(compiled, out);
      console.log(`Written (pack "${compiled.name}", id ${compiled.id}):\n  ${files.join('\n  ')}`);
    } catch (e) {
      if (e instanceof DesignPackFileError) { console.error(e.message); process.exit(1); }
      throw e;
    }
  }
}
