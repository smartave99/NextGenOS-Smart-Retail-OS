#!/usr/bin/env node
/**
 * Makes every icon and splash screen of the website and the Android app from one logo.
 *
 *   node scripts/make-icons.mjs                                   NextGenOS's neutral Smart Retail POS mark
 *   node scripts/make-icons.mjs --logo ../../brand-kits/shop/logo.png --colour "#064e3b"
 *
 * Writes: public/logo.png, public/favicon.ico, src/app/icon.png, src/app/apple-icon.png, assets/*.png, and (with --android)
 * fills android/app/src/main/res (launcher icons and splash screens). A logo with a transparent background is placed on a rounded
 * square of the brand colour; a logo that already fills its square is used as it is.
 */
import { readFileSync, writeFileSync, mkdirSync } from 'node:fs';
import { join, dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import sharp from 'sharp';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const arg = (n, d) => { const i = process.argv.indexOf(`--${n}`); return i > 0 && process.argv[i + 1] && !process.argv[i + 1].startsWith('--') ? process.argv[i + 1] : d; };
const logoPath = arg('logo', resolve(root, '..', '..', 'design', 'brand', 'smart-retail-mark.svg'));
const colour = arg('colour', '#0071e3');
if (!/^#[0-9a-fA-F]{6}$/.test(colour)) { console.error('The colour must look like #0071e3.'); process.exit(1); }

const logoBuffer = readFileSync(logoPath);
const meta = await sharp(logoBuffer, { density: 384 }).metadata();
const hasAlpha = !!meta.hasAlpha && logoPath.toLowerCase() !== resolve(root, '..', '..', 'design', 'brand', 'smart-retail-mark.svg').toLowerCase();

/** The logo as a square of `size` pixels: on the brand colour (rounded) when it is transparent, as it is otherwise. */
async function square(size, { rounded = true, padding = 0.14, onColour = hasAlpha } = {}) {
  const logo = await sharp(logoBuffer, { density: 384 }).resize(Math.round(size * (onColour ? 1 - 2 * padding : 1)), Math.round(size * (onColour ? 1 - 2 * padding : 1)), { fit: 'contain', background: { r: 0, g: 0, b: 0, alpha: 0 } }).png().toBuffer();
  if (!onColour) return sharp(logo).resize(size, size).png().toBuffer();
  const radius = rounded ? Math.round(size * 0.22) : 0;
  const mask = Buffer.from(`<svg xmlns="http://www.w3.org/2000/svg" width="${size}" height="${size}"><rect width="${size}" height="${size}" rx="${radius}" fill="${colour}"/></svg>`);
  return sharp(mask).composite([{ input: logo, gravity: 'centre' }]).png().toBuffer();
}

const out = (rel, buf) => { const p = join(root, rel); mkdirSync(dirname(p), { recursive: true }); writeFileSync(p, buf); };

// Website
out('public/logo.png', await square(512));
out('src/app/icon.png', await square(512));
out('src/app/apple-icon.png', await square(180, { rounded: false }));

// favicon.ico: an ICO file that holds one PNG (every current browser reads it)
const png48 = await square(48);
const header = Buffer.alloc(22);
header.writeUInt16LE(0, 0); header.writeUInt16LE(1, 2); header.writeUInt16LE(1, 4);
header[6] = 48; header[7] = 48; header[8] = 0; header[9] = 0; header.writeUInt16LE(1, 10); header.writeUInt16LE(32, 12);
header.writeUInt32LE(png48.length, 14); header.writeUInt32LE(22, 18);
out('public/favicon.ico', Buffer.concat([header, png48]));

// Source images for the Capacitor asset tool (Android icons and splash screens)
out('assets/icon-only.png', await square(1024, { rounded: false }));
const foreground = await sharp(logoBuffer, { density: 384 }).resize(660, 660, { fit: 'contain', background: { r: 0, g: 0, b: 0, alpha: 0 } }).extend({ top: 182, bottom: 182, left: 182, right: 182, background: { r: 0, g: 0, b: 0, alpha: 0 } }).png().toBuffer();
out('assets/icon-foreground.png', foreground);
out('assets/icon-background.png', await sharp({ create: { width: 1024, height: 1024, channels: 4, background: colour } }).png().toBuffer());
const splashLogo = await sharp(logoBuffer, { density: 384 }).resize(720, 720, { fit: 'contain', background: { r: 0, g: 0, b: 0, alpha: 0 } }).png().toBuffer();
out('assets/splash.png', await sharp({ create: { width: 2732, height: 2732, channels: 4, background: '#f5f5f7' } }).composite([{ input: splashLogo, gravity: 'centre' }]).png().toBuffer());
out('assets/splash-dark.png', await sharp({ create: { width: 2732, height: 2732, channels: 4, background: '#000000' } }).composite([{ input: splashLogo, gravity: 'centre' }]).png().toBuffer());
out('assets/icon.png', await square(1024, { rounded: false }));

console.log(`Icons made from ${logoPath} on ${colour}.`);

if (process.argv.includes('--android')) {
  // The Android icons and splash screens, made here with sharp (no separate tool to install or trust).
  const res = 'android/app/src/main/res';
  const dens = { ldpi: 36, mdpi: 48, hdpi: 72, xhdpi: 96, xxhdpi: 144, xxxhdpi: 192 };
  const adaptive = { ldpi: 81, mdpi: 108, hdpi: 162, xhdpi: 216, xxhdpi: 324, xxxhdpi: 432 };
  const circle = (size) => Buffer.from(`<svg xmlns="http://www.w3.org/2000/svg" width="${size}" height="${size}"><circle cx="${size / 2}" cy="${size / 2}" r="${size / 2}" fill="#fff"/></svg>`);
  const fg = foreground; // 1024 px, logo inside the safe zone
  const bg = await sharp({ create: { width: 1024, height: 1024, channels: 4, background: colour } }).png().toBuffer();
  const flat = await square(1024, { rounded: false });
  for (const d of Object.keys(dens)) {
    out(`${res}/mipmap-${d}/ic_launcher.png`, await sharp(flat).resize(dens[d], dens[d]).png().toBuffer());
    out(`${res}/mipmap-${d}/ic_launcher_round.png`, await sharp(flat).resize(dens[d], dens[d]).composite([{ input: circle(dens[d]), blend: 'dest-in' }]).png().toBuffer());
    out(`${res}/mipmap-${d}/ic_launcher_foreground.png`, await sharp(fg).resize(adaptive[d], adaptive[d]).png().toBuffer());
    out(`${res}/mipmap-${d}/ic_launcher_background.png`, await sharp(bg).resize(adaptive[d], adaptive[d]).png().toBuffer());
  }
  const portrait = { ldpi: [200, 320], mdpi: [320, 480], hdpi: [480, 800], xhdpi: [720, 1280], xxhdpi: [960, 1600], xxxhdpi: [1280, 1920] };
  const splash = async (w, h, back) => {
    const mark = await sharp(splashLogo).resize(Math.round(Math.min(w, h) * 0.34), Math.round(Math.min(w, h) * 0.34)).png().toBuffer();
    return sharp({ create: { width: w, height: h, channels: 4, background: back } }).composite([{ input: mark, gravity: 'centre' }]).png().toBuffer();
  };
  for (const [d, [w, h]] of Object.entries(portrait)) {
    out(`${res}/drawable-port-${d}/splash.png`, await splash(w, h, '#f5f5f7'));
    out(`${res}/drawable-port-night-${d}/splash.png`, await splash(w, h, '#000000'));
    out(`${res}/drawable-land-${d}/splash.png`, await splash(h, w, '#f5f5f7'));
    out(`${res}/drawable-land-night-${d}/splash.png`, await splash(h, w, '#000000'));
  }
  out(`${res}/drawable/splash.png`, await splash(480, 320, '#f5f5f7'));
  out(`${res}/drawable-night/splash.png`, await splash(480, 320, '#000000'));
  console.log('Android icons and splash screens written to ' + res + '.');
}
