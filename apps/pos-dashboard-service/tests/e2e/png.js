// Draws the test photos for photos.e2e.js as PNG files, with nothing but Node itself:
// a phone photo of an oil bottle on a shop counter, and the clean catalogue photo the AI should make of it.
const zlib = require('zlib');

const crcTable = Array.from({ length: 256 }, (_, n) => {
  let c = n;
  for (let k = 0; k < 8; k++) c = c & 1 ? 0xedb88320 ^ (c >>> 1) : c >>> 1;
  return c >>> 0;
});

function crc32(bytes) {
  let c = 0xffffffff;
  for (const b of bytes) c = crcTable[(c ^ b) & 0xff] ^ (c >>> 8);
  return (c ^ 0xffffffff) >>> 0;
}

function chunk(type, data) {
  const out = Buffer.alloc(12 + data.length);
  out.writeUInt32BE(data.length, 0);
  out.write(type, 4, 'ascii');
  data.copy(out, 8);
  out.writeUInt32BE(crc32(out.subarray(4, 8 + data.length)), 8 + data.length);
  return out;
}

/** An RGB PNG of the given size; colourAt(x, y) gives [r, g, b] for each pixel. */
function png(width, height, colourAt) {
  const row = width * 3 + 1;
  const pixels = Buffer.alloc(row * height);
  for (let y = 0; y < height; y++) {
    for (let x = 0; x < width; x++) {
      colourAt(x, y).forEach((v, i) => { pixels[y * row + 1 + x * 3 + i] = Math.max(0, Math.min(255, Math.round(v))); });
    }
  }

  const header = Buffer.alloc(13);
  header.writeUInt32BE(width, 0);
  header.writeUInt32BE(height, 4);
  header[8] = 8; // bits per channel
  header[9] = 2; // RGB
  return Buffer.concat([
    Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]),
    chunk('IHDR', header),
    chunk('IDAT', zlib.deflateSync(pixels)),
    chunk('IEND', Buffer.alloc(0)),
  ]);
}

/** A 1 L oil bottle standing with its middle at x = cx, or null where the bottle is not. */
function bottle(x, y, cx, priceSticker) {
  const dx = x - cx;
  const oil = () => (dx >= -38 && dx <= -30 ? [255, 228, 150] : [232, 178, 58]);
  if (y >= 62 && y < 84) return Math.abs(dx) <= 23 ? [240, 190, 30] : null; // cap
  if (y >= 84 && y < 112) return Math.abs(dx) <= 19 ? [240, 200, 110] : null; // neck
  if (y >= 112 && y < 130) return Math.abs(dx) <= 19 + (y - 112) * 1.5 ? oil() : null; // shoulders
  if (y < 130 || y >= 290 || Math.abs(dx) > 46) return null;
  const corner = Math.abs(dx) - 28;
  if (y > 272 && corner > 0 && corner ** 2 + (y - 272) ** 2 > 18 ** 2) return null; // rounded bottom
  if (priceSticker && dx >= 16 && dx <= 40 && y >= 240 && y <= 256) return [230, 70, 50];
  if (y >= 170 && y <= 230) {
    const text = Math.abs(dx) <= 30 && ((y >= 188 && y <= 193) || (y >= 203 && y <= 206));
    return text ? [255, 255, 255] : [40, 140, 70]; // label
  }
  return oil();
}

/** The bottle as a phone sees it: off-centre on a wooden counter, with a hand, another item and a price sticker. */
function phonePhoto(x, y) {
  const item = bottle(x, y, 175, true);
  if (item) return item.map(v => v * 0.88);
  if (((x - 272) / 46) ** 2 + ((y - 300) / 62) ** 2 <= 1) return [196, 146, 116];
  if (x >= 12 && x <= 80 && y >= 205 && y <= 300) return [44, 92, 168];
  if (y < 95) return [206, 200, 190];
  const grain = 14 * Math.sin(y / 3.2 + 2 * Math.sin(x / 45));
  return [150 + grain, 104 + grain * 0.7, 66 + grain * 0.4];
}

/** The same bottle as a catalogue photo: centred on pure white with a soft shadow. */
function cleanPhoto(x, y) {
  const item = bottle(x, y, 160, false);
  if (item) return item;
  const d = ((x - 160) / 64) ** 2 + ((y - 291) / 9) ** 2;
  return d < 1 ? Array(3).fill(255 - 30 * (1 - d)) : [255, 255, 255];
}

/** Photo 2: the bottle on a kitchen counter, beside a cooking pot. */
function inUsePhoto(x, y) {
  const item = bottle(x, y, 200, false);
  if (item) return item;
  if (((x - 80) / 58) ** 2 + ((y - 250) / 42) ** 2 <= 1 && y >= 215) return [120, 124, 130];
  if (y < 200) return [236, 222, 196];
  return [196, 160, 118];
}

/** Photos 3 to 5: the bottle with a plain grey figure standing for the model, each on its own backdrop. */
function modelPhoto(backdrop) {
  return (x, y) => {
    const item = bottle(x, y, 225, false);
    if (item) return item;
    if ((x - 105) ** 2 + (y - 105) ** 2 <= 36 ** 2) return [96, 96, 104];
    if (x >= 55 && x <= 155 && y >= 150 && ((x - 105) / 50) ** 2 + ((y - 190) / 60) ** 2 <= 1.6) return [128, 128, 138];
    return backdrop;
  };
}

/** The picture the stand-in for Codex makes for photo 1 to 5. */
const photoNumber = [null, cleanPhoto, inUsePhoto, modelPhoto([214, 226, 240]), modelPhoto([246, 226, 212]), modelPhoto([218, 238, 222])];

/** What the stand-in does to a photo the owner asked to change: it comes out blue, so a change can be told from the photo before. */
const changed = (colour) => [colour[0] * 0.55, colour[1] * 0.7, Math.min(255, colour[2] + 90)];

module.exports = { png, phonePhoto, cleanPhoto, photoNumber, changed };
