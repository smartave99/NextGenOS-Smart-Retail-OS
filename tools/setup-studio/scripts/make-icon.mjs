#!/usr/bin/env node
/**
 * Makes launcher/studio.ico (the icon of "Setup Studio.exe") from ui/icon.svg. It is run by a person when the icon changes; the result is kept in the repository, so the
 * bundle's build needs no image library.
 *
 *   node tools/setup-studio/scripts/make-icon.mjs
 *
 * It needs the "sharp" library, which the website's folder has (apps/storefront-web-mobile/node_modules). The sizes up to 48 are plain bitmaps (every Windows reads them);
 * the 256 one is a PNG inside the icon file (Windows Vista and later).
 */
import { readFileSync, writeFileSync } from 'node:fs';
import { createRequire } from 'node:module';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const studio = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const repo = resolve(studio, '..', '..');
const sharp = createRequire(join(repo, 'apps', 'storefront-web-mobile', 'package.json'))('sharp');
const svg = readFileSync(join(studio, 'ui', 'icon.svg'));
const render = (size) => sharp(svg, { density: 512 }).resize(size, size).ensureAlpha();

/** A 32-bit bitmap frame of an icon: the picture upside down as BGRA, then an empty mask. */
async function bitmap(size) {
  const { data } = await render(size).raw().toBuffer({ resolveWithObject: true });
  const pixels = Buffer.alloc(size * size * 4);
  for (let y = 0; y < size; y += 1) for (let x = 0; x < size; x += 1) {
    const from = ((size - 1 - y) * size + x) * 4;
    const to = (y * size + x) * 4;
    pixels[to] = data[from + 2]; pixels[to + 1] = data[from + 1]; pixels[to + 2] = data[from]; pixels[to + 3] = data[from + 3];
  }
  const mask = Buffer.alloc(Math.ceil(size / 32) * 4 * size);
  const header = Buffer.alloc(40);
  header.writeUInt32LE(40, 0); header.writeInt32LE(size, 4); header.writeInt32LE(size * 2, 8); header.writeUInt16LE(1, 12); header.writeUInt16LE(32, 14);
  header.writeUInt32LE(pixels.length + mask.length, 20);
  return Buffer.concat([header, pixels, mask]);
}

const frames = [];
for (const size of [16, 24, 32, 48]) frames.push({ size, bytes: await bitmap(size) });
frames.push({ size: 256, bytes: await render(256).png({ compressionLevel: 9 }).toBuffer() });

const head = Buffer.alloc(6);
head.writeUInt16LE(1, 2); head.writeUInt16LE(frames.length, 4);
let offset = 6 + 16 * frames.length;
const entries = frames.map((f) => {
  const e = Buffer.alloc(16);
  e[0] = f.size >= 256 ? 0 : f.size; e[1] = f.size >= 256 ? 0 : f.size; e.writeUInt16LE(1, 4); e.writeUInt16LE(32, 6);
  e.writeUInt32LE(f.bytes.length, 8); e.writeUInt32LE(offset, 12);
  offset += f.bytes.length;
  return e;
});
const out = join(studio, 'launcher', 'studio.ico');
writeFileSync(out, Buffer.concat([head, ...entries, ...frames.map((f) => f.bytes)]));
console.log(`Wrote ${out} (${offset} bytes, sizes ${frames.map((f) => f.size).join(', ')}).`);
