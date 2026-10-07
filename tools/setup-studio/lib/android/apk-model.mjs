// Reads an Android app (.apk) and says where its pictures are, by following the numbers the app itself uses: the manifest says which icon, which theme; the resource table says which
// file; the adaptive icon says which two pictures it is made of. No file or resource NAME is relied on, so this also works when a release build has hidden the names and shortened
// the file paths (which Android's own build tools can do). Only reading happens here.
import { readZip } from './zipfile.mjs';
import { parseAxml, elementsOf, attrOf, refOf, valueOf, TYPE } from './axml.mjs';
import { parseArsc, entriesFor, textValue } from './arsc.mjs';
import { pngSize } from './png.mjs';

const ATTR_BACKGROUND = 0x010100d4;   // android:background
const AXML_MAGIC = [0x03, 0x00, 0x08, 0x00];

export const isAxml = (buf) => buf.length > 8 && AXML_MAGIC.every((b, i) => buf[i] === b);

/** Opens an app: { zip, manifest (parsed), table (parsed), contents }. */
export function openApp(bytes) {
  const zip = readZip(bytes);
  const manifestEntry = zip.byName.get('AndroidManifest.xml');
  const arscEntry = zip.byName.get('resources.arsc');
  if (!manifestEntry) throw new Error('This app has no AndroidManifest.xml, so it is not an Android app.');
  if (!arscEntry) throw new Error('This app has no resources.arsc, so it is not a finished Android app.');
  return { zip, manifest: parseAxml(manifestEntry.data()), table: parseArsc(arscEntry.data()) };
}

/** The pictures and settings the manifest points at. */
export function manifestFacts(manifest) {
  const els = elementsOf(manifest);
  const root = els.find((e) => e.name === 'manifest');
  const app = els.find((e) => e.name === 'application');
  const activities = els.filter((e) => e.name === 'activity');
  const launcher = activities.find((a) => {
    const i = els.indexOf(a);
    const inside = [];
    for (let j = i + 1; j < els.length && els[j].depth > a.depth; j += 1) inside.push(els[j]);
    return inside.some((x) => x.name === 'category' && valueOf(attrOf(x, 'name')) === 'android.intent.category.LAUNCHER');
  }) ?? activities[0];
  return { els, root, app, launcher };
}

/** What a resource number points at, over all kinds of screen: [{ path, config density/night, entry }]. */
export function filesOfResource(table, resId) {
  const out = [];
  for (const e of entriesFor(table, resId)) {
    const path = !e.complex && e.value?.type === 0x03 ? textValue(table, e) : null;
    if (path && path.startsWith('res/')) out.push({ path, density: e.density, night: e.night, sdk: e.sdk, entry: e });
  }
  return out;
}

const extOf = (p) => (/\.([a-z0-9]+)$/i.exec(p)?.[1] ?? '').toLowerCase();

/** The pictures inside an adaptive icon (a compiled XML file): { role: 'background' | 'foreground' | 'monochrome', ref } in order. */
function adaptiveParts(zip, path) {
  const entry = zip.byName.get(path);
  if (!entry) return [];
  const data = entry.data();
  if (!isAxml(data)) return [];
  const els = elementsOf(parseAxml(data));
  if (els[0]?.name !== 'adaptive-icon') return [];
  const parts = [];
  for (let i = 1; i < els.length; i += 1) {
    if (els[i].depth !== els[0].depth + 1 || !['background', 'foreground', 'monochrome'].includes(els[i].name)) continue;
    // the picture is on the element itself, or on the first element inside it that names one (an <inset> around the picture, for example)
    let ref = refOf(attrOf(els[i], 'drawable'));
    for (let j = i + 1; ref === null && j < els.length && els[j].depth > els[i].depth; j += 1) ref = refOf(attrOf(els[j], 'drawable'));
    if (ref !== null) parts.push({ role: els[i].name, ref });
  }
  return parts;
}

/**
 * The picture files a customer's own pictures replace: [{ path, role, width, height, night }], and a list of things that could not be followed (each a plain sentence).
 * roles: launcher (the plain icon), round (the round icon), foreground and background (the two layers of the adaptive icon), splash (the loading picture).
 */
export function findPictures({ zip, manifest, table }) {
  const { app, launcher } = manifestFacts(manifest);
  const found = new Map();   // path -> role
  const notes = [];
  const add = (path, role, night = false) => {
    if (!zip.byName.has(path)) { notes.push(`The app lists the picture ${path}, but it is not in the app.`); return; }
    if (!['png'].includes(extOf(path))) { notes.push(`A picture of the app (${path}) is not a PNG, so it was left as it is.`); return; }
    if (!found.has(path)) found.set(path, { path, role, night });
  };
  const follow = (ref, role, depth = 0) => {
    for (const f of filesOfResource(table, ref)) {
      if (extOf(f.path) === 'xml') {
        const parts = depth === 0 ? adaptiveParts(zip, f.path) : [];
        if (!parts.length) notes.push(`A picture of the app (${f.path}) is a drawing, not a PNG, so it was left as it is.`);
        for (const p of parts) if (p.role !== 'monochrome') follow(p.ref, p.role, depth + 1);
        else notes.push('The app has a one-colour icon layer for themed icons. It was left as it is.');
      } else add(f.path, role, f.night);
    }
  };
  const iconRef = refOf(app && attrOf(app, 'icon'));
  const roundRef = refOf(app && attrOf(app, 'roundIcon'));
  if (iconRef === null) notes.push('The app does not say which icon it uses.'); else follow(iconRef, 'launcher');
  if (roundRef !== null) follow(roundRef, 'round');
  // the loading picture: the background that the launching screen's theme asks for (and the theme it builds on)
  const themeRefs = [refOf(launcher && attrOf(launcher, 'theme')), refOf(app && attrOf(app, 'theme'))].filter((r) => r !== null);
  const seen = new Set();
  const lookTheme = (id, depth = 0) => {
    if (depth > 6 || seen.has(id)) return;
    seen.add(id);
    for (const e of entriesFor(table, id)) {
      if (!e.complex) continue;
      for (const m of e.map ?? []) if (m.name === ATTR_BACKGROUND && m.type === TYPE.REFERENCE) follow(m.data, 'splash');
      if (e.parent) lookTheme(e.parent, depth + 1);
    }
  };
  for (const t of themeRefs) lookTheme(t);
  if (![...found.values()].some((f) => f.role === 'splash')) notes.push('The app has no loading picture that this Studio can find, so its loading screen is left as it is.');
  const pictures = [];
  for (const f of found.values()) {
    const size = pngSize(zip.byName.get(f.path).data());
    if (!size) { notes.push(`A picture of the app (${f.path}) is not a readable PNG, so it was left as it is.`); continue; }
    pictures.push({ ...f, ...size });
  }
  return { pictures, notes };
}

/** What the app calls itself: the name under the icon (from the table, or written in the manifest), taken for the screen with no special setting. */
export function labelOf(manifest, table) {
  const { app } = manifestFacts(manifest);
  const a = app && attrOf(app, 'label');
  if (!a) return null;
  if (a.type === TYPE.STRING) return a.text;
  const ref = refOf(a);
  if (ref === null) return null;
  const entries = entriesFor(table, ref).filter((e) => e.value?.type === 0x03);
  const plain = entries.find((e) => e.config.length <= 4 || e.config.every((b, i) => i < 4 || b === 0)) ?? entries[0];
  return plain ? textValue(table, plain) : null;
}
