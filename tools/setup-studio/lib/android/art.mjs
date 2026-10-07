// A customer's app icon and loading picture, made from the customer's own logo and colour (a PNG). The look follows what the website's picture maker does for the app
// (apps/storefront-web-mobile/scripts/make-icons.mjs): a logo with a see-through background sits on the brand colour, a logo that already fills its square is used as it is,
// the two layers of the adaptive icon keep the logo inside the safe middle, and the loading picture is the logo on a plain light (or dark) screen. Nothing here is a company's:
// with no logo the caller gets no pictures at all and the template's own stay.
import { decodePng, encodePng, fitInside, resize, solid, pasteCentre, maskShape, image, colourOf } from './png.mjs';

const LIGHT = [0xf5, 0xf5, 0xf7]; const DARK = [0, 0, 0];   // the plain screens behind the logo while the app opens

/** Prepares the pictures for one logo and one colour. `logo` is the PNG file's bytes, `colour` is '#rrggbb'. */
export function artFor({ logo, colour }) {
  const brand = colourOf(colour);
  const source = decodePng(logo);
  const onColour = source.transparent;
  const cache = new Map();
  const memo = (key, make) => { if (!cache.has(key)) cache.set(key, make()); return cache.get(key); };

  // the plain icon at 1024 pixels: the logo on the brand colour when it is see-through, or the logo as it is
  const flat = () => memo('flat', () => {
    if (!onColour) return pasteCentre(image(1024, 1024), fitInside(source, 1024, 1024));
    return pasteCentre(solid(1024, 1024, [...brand, 255]), fitInside(source, Math.round(1024 * 0.72), Math.round(1024 * 0.72)));
  });
  // the logo alone inside the safe middle of a layer (the two layers of an adaptive icon are cut to different shapes by different phones)
  const layer = () => memo('layer', () => pasteCentre(image(1024, 1024), fitInside(source, 660, 660)));
  const mark = () => memo('mark', () => fitInside(source, 720, 720));
  const squareOf = (img, w, h) => (img.width === w && img.height === h ? img : resize(img, w, h));

  return {
    onColour,
    /** the plain icon (what a phone without adaptive icons shows) */
    launcher: (w, h) => squareOf(flat(), w, h),
    /** the same cut to a circle */
    round: (w, h) => { const sq = squareOf(flat(), w, h); return maskShape({ width: sq.width, height: sq.height, rgba: Uint8Array.from(sq.rgba) }, { circle: true }); },
    /** the front layer of the adaptive icon: the logo, see-through around it */
    foreground: (w, h) => squareOf(layer(), w, h),
    /** the back layer: the brand colour */
    background: (w, h) => solid(w, h, [...brand, 255]),
    /** the loading picture: the logo in the middle of a plain light screen, or a dark one at night */
    splash: (w, h, night = false) => {
      const side = Math.max(1, Math.round(Math.min(w, h) * 0.34));
      return pasteCentre(solid(w, h, [...(night ? DARK : LIGHT), 255]), fitInside(mark(), side, side));
    },
    /** the picture as a PNG file, for a role and a size */
    png(role, w, h, night = false) {
      const make = { launcher: () => this.launcher(w, h), round: () => this.round(w, h), foreground: () => this.foreground(w, h), background: () => this.background(w, h), splash: () => this.splash(w, h, night) }[role];
      if (!make) throw new Error(`No picture is made for "${role}".`);
      return encodePng(make());
    },
  };
}

