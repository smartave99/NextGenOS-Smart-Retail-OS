#!/usr/bin/env node
/**
 * Makes an .ico file for a launcher from an SVG picture. Run by a person when the picture changes; the .ico is kept in the repository, so a build needs no image library.
 *   node scripts/make-launcher-icon.mjs --svg design/brand/smart-retail-mark.svg --out scripts/launcher/product.ico
 * It needs the "sharp" library, which the website's folder has (apps/storefront-web-mobile/node_modules). The sizes up to 48 are plain bitmaps (every Windows reads them);
 * the 256 one is a PNG inside the icon file (Windows Vista and later).
 */
import { readFileSync, writeFileSync } from 'node:fs';
import { createRequire } from 'node:module';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const arg = (n) => { const i = process.argv.indexOf(n); return i > 0 ? process.argv[i + 1] : undefined; };
const svgPath = arg('--svg'); const outPath = arg('--out');
if (!svgPath || !outPath) { console.error('Usage: node scripts/make-launcher-icon.mjs --svg <picture.svg> --out <file.ico>'); process.exit(2); }
const sharp = createRequire(join(repo, 'apps', 'storefront-web-mobile', 'package.json'))('sharp');
const svg = readFileSync(resolve(svgPath));
const render = (size) => sharp(svg, { density: 512 }).resize(size, size, { fit: 'contain', background: { r: 0, g: 0, b: 0, alpha: 0 } }).ensureAlpha();

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
writeFileSync(resolve(outPath), Buffer.concat([head, ...entries, ...frames.map((f) => f.bytes)]));
console.log(`Wrote ${outPath} (${offset} bytes, sizes ${frames.map((f) => f.size).join(', ')}).`);
