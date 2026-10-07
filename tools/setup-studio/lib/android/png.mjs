// A small PNG reader, resizer and writer, so the Studio can make a customer's app icons and loading pictures from the customer's logo with nothing installed (no picture library,
// no tool to download). It reads every ordinary PNG (all colour types and bit depths, plain or interlaced) and writes 8-bit PNGs. Colour profiles and gamma are not applied.
import { inflateSync, deflateSync, crc32 } from 'node:zlib';

const SIGNATURE = Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]);
export class PngError extends Error {}

/** The width and height of a PNG without reading its pixels (null when it is not a PNG). */
export function pngSize(buf) {
  if (!Buffer.isBuffer(buf) || buf.length < 33 || !buf.subarray(0, 8).equals(SIGNATURE) || buf.toString('latin1', 12, 16) !== 'IHDR') return null;
  return { width: buf.readUInt32BE(16), height: buf.readUInt32BE(20) };
}

function chunksOf(buf) {
  if (!Buffer.isBuffer(buf) || buf.length < 33 || !buf.subarray(0, 8).equals(SIGNATURE)) throw new PngError('This is not a PNG picture. Use a PNG file for the logo.');
  const out = [];
  let at = 8;
  while (at + 12 <= buf.length) {
    const length = buf.readUInt32BE(at);
    const type = buf.toString('latin1', at + 4, at + 8);
    if (at + 12 + length > buf.length) throw new PngError('This PNG picture is cut short (incomplete). Save the logo again.');
    const data = buf.subarray(at + 8, at + 8 + length);
    if (crc32(buf.subarray(at + 4, at + 8 + length)) !== buf.readUInt32BE(at + 8 + length)) throw new PngError('This PNG picture is damaged (a part of it does not check out). Save the logo again.');
    out.push({ type, data });
    at += 12 + length;
    if (type === 'IEND') break;
  }
  return out;
}

const CHANNELS = { 0: 1, 2: 3, 3: 1, 4: 2, 6: 4 };
const ADAM7 = [[0, 0, 8, 8], [4, 0, 8, 8], [0, 4, 4, 8], [2, 0, 4, 4], [0, 2, 2, 4], [1, 0, 2, 2], [0, 1, 1, 2]];   // x start, y start, x step, y step

function unfilter(data, at, width, height, bitsPerPixel) {
  const bpp = Math.max(1, bitsPerPixel >> 3);
  const stride = Math.ceil((width * bitsPerPixel) / 8);
  const out = Buffer.alloc(stride * height);
  for (let y = 0; y < height; y += 1) {
    const type = data[at + y * (stride + 1)];
    const row = at + y * (stride + 1) + 1;
    const dst = y * stride;
    for (let x = 0; x < stride; x += 1) {
      const raw = data[row + x];
      const left = x >= bpp ? out[dst + x - bpp] : 0;
      const up = y > 0 ? out[dst - stride + x] : 0;
      const upLeft = y > 0 && x >= bpp ? out[dst - stride + x - bpp] : 0;
      let add;
      switch (type) {
        case 0: add = 0; break;
        case 1: add = left; break;
        case 2: add = up; break;
        case 3: add = (left + up) >> 1; break;
        case 4: { const p = left + up - upLeft; const pa = Math.abs(p - left); const pb = Math.abs(p - up); const pc = Math.abs(p - upLeft); add = pa <= pb && pa <= pc ? left : pb <= pc ? up : upLeft; break; }
        default: throw new PngError('This PNG picture uses a way of packing that is not valid. Save the logo again.');
      }
      out[dst + x] = (raw + add) & 255;
    }
  }
  return { bytes: out, stride, used: height * (stride + 1) };
}

/** Reads a PNG into { width, height, rgba (Uint8Array, 4 bytes a pixel, not premultiplied), transparent (true when some pixel is not fully opaque) }. */
export function decodePng(buf) {
  const chunks = chunksOf(buf);
  const head = chunks.find((c) => c.type === 'IHDR')?.data;
  if (!head || head.length < 13) throw new PngError('This PNG picture has no header. Save the logo again.');
  const width = head.readUInt32BE(0); const height = head.readUInt32BE(4);
  const depth = head[8]; const colour = head[9]; const interlace = head[12];
  if (!width || !height || width > 16384 || height > 16384 || width * height > 64_000_000) throw new PngError('This picture is too big to use as a logo (at most 16000 pixels a side). Make it smaller.');
  if (!CHANNELS[colour] || ![1, 2, 4, 8, 16].includes(depth) || (colour === 3 && depth === 16) || ([2, 4, 6].includes(colour) && depth < 8)) throw new PngError('This PNG picture has a kind of colour this Studio does not read. Save the logo again as a normal PNG.');
  const palette = chunks.find((c) => c.type === 'PLTE')?.data;
  const trns = chunks.find((c) => c.type === 'tRNS')?.data;
  if (colour === 3 && !palette) throw new PngError('This PNG picture has no colours in it. Save the logo again.');
  let packed;
  try { packed = inflateSync(Buffer.concat(chunks.filter((c) => c.type === 'IDAT').map((c) => c.data))); } catch { throw new PngError('This PNG picture is damaged (its pixels cannot be unpacked). Save the logo again.'); }
  const channels = CHANNELS[colour];
  const bitsPerPixel = channels * depth;
  const rgba = new Uint8Array(width * height * 4);
  const full = (row, x, c) => {   // one channel of one pixel as it is stored (16-bit stays 16-bit)
    if (depth === 8) return row[x * channels + c];
    if (depth === 16) return (row[(x * channels + c) * 2] << 8) | row[(x * channels + c) * 2 + 1];
    const bit = (x * channels + c) * depth;
    return (row[bit >> 3] >> (8 - depth - (bit & 7))) & ((1 << depth) - 1);
  };
  const maxv = depth === 16 ? 65535 : (1 << depth) - 1;
  const to8 = (v) => (depth === 8 ? v : depth === 16 ? v >> 8 : Math.round((v * 255) / maxv));
  const put = (bytes, stride, w, h, x0, y0, dx, dy) => {
    for (let y = 0; y < h; y += 1) {
      const row = bytes.subarray(y * stride, (y + 1) * stride);
      for (let x = 0; x < w; x += 1) {
        const o = ((y0 + y * dy) * width + (x0 + x * dx)) * 4;
        let r; let g; let b; let a = 255;
        if (colour === 0) {
          const v = full(row, x, 0);
          r = g = b = to8(v);
          if (trns && trns.length >= 2 && v === trns.readUInt16BE(0)) a = 0;
        } else if (colour === 2) {
          const fr = full(row, x, 0); const fg = full(row, x, 1); const fb = full(row, x, 2);
          r = to8(fr); g = to8(fg); b = to8(fb);
          if (trns && trns.length >= 6 && fr === trns.readUInt16BE(0) && fg === trns.readUInt16BE(2) && fb === trns.readUInt16BE(4)) a = 0;
        } else if (colour === 3) {
          const i = full(row, x, 0);
          r = palette[i * 3] ?? 0; g = palette[i * 3 + 1] ?? 0; b = palette[i * 3 + 2] ?? 0;
          if (trns && i < trns.length) a = trns[i];
        } else if (colour === 4) {
          r = g = b = to8(full(row, x, 0)); a = to8(full(row, x, 1));
        } else { r = to8(full(row, x, 0)); g = to8(full(row, x, 1)); b = to8(full(row, x, 2)); a = to8(full(row, x, 3)); }
        rgba[o] = r; rgba[o + 1] = g; rgba[o + 2] = b; rgba[o + 3] = a;
      }
    }
  };
  try {
    if (!interlace) {
      if (packed.length < Math.ceil((width * bitsPerPixel) / 8) * height + height) throw new PngError('x');
      const { bytes, stride } = unfilter(packed, 0, width, height, bitsPerPixel);
      put(bytes, stride, width, height, 0, 0, 1, 1);
    } else {
      let at = 0;
      for (const [x0, y0, dx, dy] of ADAM7) {
        const w = Math.ceil((width - x0) / dx); const h = Math.ceil((height - y0) / dy);
        if (w <= 0 || h <= 0) continue;
        if (at + Math.ceil((w * bitsPerPixel) / 8) * h + h > packed.length) throw new PngError('x');
        const { bytes, stride, used } = unfilter(packed, at, w, h, bitsPerPixel);
        put(bytes, stride, w, h, x0, y0, dx, dy);
        at += used;
      }
    }
  } catch (e) { if (e instanceof PngError && e.message === 'x') throw new PngError('This PNG picture is cut short (incomplete). Save the logo again.'); throw e; }
  let transparent = false;
  for (let i = 3; i < rgba.length; i += 4) if (rgba[i] < 250) { transparent = true; break; }
  return { width, height, rgba, transparent };
}

function chunk(type, data) {
  const head = Buffer.alloc(8); head.writeUInt32BE(data.length, 0); head.write(type, 4, 'latin1');
  const crc = Buffer.alloc(4); crc.writeUInt32BE(crc32(Buffer.concat([head.subarray(4), data])), 0);
  return Buffer.concat([head, data, crc]);
}

/** Writes { width, height, rgba } as a PNG (colour, with transparency only when a pixel needs it). */
export function encodePng({ width, height, rgba }) {
  let opaque = true;
  for (let i = 3; i < rgba.length; i += 4) if (rgba[i] !== 255) { opaque = false; break; }
  const channels = opaque ? 3 : 4;
  const stride = width * channels;
  const rows = [];
  let prev = Buffer.alloc(stride);
  for (let y = 0; y < height; y += 1) {
    const row = Buffer.alloc(stride);
    for (let x = 0; x < width; x += 1) for (let c = 0; c < channels; c += 1) row[x * channels + c] = rgba[(y * width + x) * 4 + c];
    // the cheapest of the five filters for this row (the usual rule: smallest sum of the filtered bytes read as signed)
    let best = null;
    for (let type = 0; type < 5; type += 1) {
      const f = Buffer.alloc(stride + 1); f[0] = type;
      let cost = 0;
      for (let x = 0; x < stride; x += 1) {
        const left = x >= channels ? row[x - channels] : 0; const up = prev[x]; const upLeft = x >= channels ? prev[x - channels] : 0;
        let pred = 0;
        if (type === 1) pred = left; else if (type === 2) pred = up; else if (type === 3) pred = (left + up) >> 1;
        else if (type === 4) { const p = left + up - upLeft; const pa = Math.abs(p - left); const pb = Math.abs(p - up); const pc = Math.abs(p - upLeft); pred = pa <= pb && pa <= pc ? left : pb <= pc ? up : upLeft; }
        const v = (row[x] - pred) & 255;
        f[x + 1] = v; cost += v < 128 ? v : 256 - v;
      }
      if (!best || cost < best.cost) best = { f, cost };
    }
    rows.push(best.f);
    prev = row;
  }
  const head = Buffer.alloc(13);
  head.writeUInt32BE(width, 0); head.writeUInt32BE(height, 4); head[8] = 8; head[9] = opaque ? 2 : 6;
  return Buffer.concat([SIGNATURE, chunk('IHDR', head), chunk('IDAT', deflateSync(Buffer.concat(rows), { level: 9 })), chunk('IEND', Buffer.alloc(0))]);
}

// ---- drawing -------------------------------------------------------------------------------------------------------------------------------------

export const image = (width, height) => ({ width, height, rgba: new Uint8Array(width * height * 4) });

export function solid(width, height, [r, g, b, a = 255]) {
  const img = image(width, height);
  for (let i = 0; i < img.rgba.length; i += 4) { img.rgba[i] = r; img.rgba[i + 1] = g; img.rgba[i + 2] = b; img.rgba[i + 3] = a; }
  return img;
}

/** '#rrggbb' as [r, g, b]. */
export function colourOf(hex) {
  const m = /^#([0-9a-f]{2})([0-9a-f]{2})([0-9a-f]{2})$/i.exec(String(hex));
  if (!m) throw new PngError('A colour must look like #0071e3.');
  return [parseInt(m[1], 16), parseInt(m[2], 16), parseInt(m[3], 16)];
}

/** For each output position along one axis: which input positions count, and how much. Taking the average of the covered input when making smaller, a straight blend when making bigger. */
function axisWeights(from, to) {
  const table = [];
  const ratio = from / to;
  for (let i = 0; i < to; i += 1) {
    const list = [];
    if (ratio > 1) {
      const a = i * ratio; const b = (i + 1) * ratio;
      for (let s = Math.floor(a); s < Math.min(from, Math.ceil(b)); s += 1) { const w = Math.min(b, s + 1) - Math.max(a, s); if (w > 0) list.push([s, w / ratio]); }
    } else {
      const centre = (i + 0.5) * ratio - 0.5;
      const s0 = Math.floor(centre); const t = centre - s0;
      list.push([Math.min(Math.max(s0, 0), from - 1), 1 - t], [Math.min(Math.max(s0 + 1, 0), from - 1), t]);
    }
    table.push(list);
  }
  return table;
}

/** The picture made to exactly width x height (the shape may change). Transparent edges do not bleed into the colours. */
export function resize(img, width, height) {
  if (img.width === width && img.height === height) return { width, height, rgba: Uint8Array.from(img.rgba) };
  const wx = axisWeights(img.width, width); const wy = axisWeights(img.height, height);
  const mid = new Float32Array(width * img.height * 4);   // premultiplied
  for (let y = 0; y < img.height; y += 1) for (let x = 0; x < width; x += 1) {
    let r = 0; let g = 0; let b = 0; let a = 0;
    for (const [s, w] of wx[x]) { const o = (y * img.width + s) * 4; const al = img.rgba[o + 3] / 255; r += img.rgba[o] * al * w; g += img.rgba[o + 1] * al * w; b += img.rgba[o + 2] * al * w; a += al * w; }
    const o = (y * width + x) * 4; mid[o] = r; mid[o + 1] = g; mid[o + 2] = b; mid[o + 3] = a;
  }
  const out = image(width, height);
  for (let y = 0; y < height; y += 1) for (let x = 0; x < width; x += 1) {
    let r = 0; let g = 0; let b = 0; let a = 0;
    for (const [s, w] of wy[y]) { const o = (s * width + x) * 4; r += mid[o] * w; g += mid[o + 1] * w; b += mid[o + 2] * w; a += mid[o + 3] * w; }
    const o = (y * width + x) * 4;
    if (a > 0.0001) { out.rgba[o] = Math.min(255, Math.round(r / a)); out.rgba[o + 1] = Math.min(255, Math.round(g / a)); out.rgba[o + 2] = Math.min(255, Math.round(b / a)); out.rgba[o + 3] = Math.min(255, Math.round(a * 255)); }
  }
  return out;
}

/** The picture made to fit inside box x box, keeping its shape (it is not made bigger than the box asks for: it is scaled to touch the box on its longer side). */
export function fitInside(img, boxW, boxH) {
  const scale = Math.min(boxW / img.width, boxH / img.height);
  return resize(img, Math.max(1, Math.round(img.width * scale)), Math.max(1, Math.round(img.height * scale)));
}

/** Puts `over` on `base` (normal "over" blending), with its top-left corner at (x, y). Changes base. */
export function paste(base, over, x0, y0) {
  for (let y = 0; y < over.height; y += 1) {
    const by = y0 + y; if (by < 0 || by >= base.height) continue;
    for (let x = 0; x < over.width; x += 1) {
      const bx = x0 + x; if (bx < 0 || bx >= base.width) continue;
      const o = (y * over.width + x) * 4; const d = (by * base.width + bx) * 4;
      const sa = over.rgba[o + 3] / 255; if (sa === 0) continue;
      const da = base.rgba[d + 3] / 255;
      const oa = sa + da * (1 - sa);
      for (let c = 0; c < 3; c += 1) base.rgba[d + c] = Math.round((over.rgba[o + c] * sa + base.rgba[d + c] * da * (1 - sa)) / oa);
      base.rgba[d + 3] = Math.round(oa * 255);
    }
  }
  return base;
}

/** Centres `over` on `base`. */
export const pasteCentre = (base, over) => paste(base, over, Math.round((base.width - over.width) / 2), Math.round((base.height - over.height) / 2));

/** Cuts the picture to a rounded square (corner radius a share of its width) or a circle, with smooth edges. Changes img. */
export function maskShape(img, { circle = false, radius = 0 }) {
  const cx = img.width / 2; const cy = img.height / 2;
  const hx = img.width / 2; const hy = img.height / 2;
  const r = circle ? Math.min(hx, hy) : Math.min(radius, hx, hy);
  for (let y = 0; y < img.height; y += 1) for (let x = 0; x < img.width; x += 1) {
    const px = x + 0.5 - cx; const py = y + 0.5 - cy;
    let sd;
    if (circle) sd = Math.hypot(px, py) - r;
    else { const qx = Math.abs(px) - (hx - r); const qy = Math.abs(py) - (hy - r); sd = Math.hypot(Math.max(qx, 0), Math.max(qy, 0)) + Math.min(Math.max(qx, qy), 0) - r; }
    const cover = Math.min(1, Math.max(0, 0.5 - sd));
    const o = (y * img.width + x) * 4 + 3;
    img.rgba[o] = Math.round(img.rgba[o] * cover);
  }
  return img;
}
