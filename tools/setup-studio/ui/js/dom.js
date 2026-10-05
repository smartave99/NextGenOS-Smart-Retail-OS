// A very small way to make page parts. Text is always put in as text (never as markup), so nothing a person types can run as a page.
const SVG = 'http://www.w3.org/2000/svg';

export function h(tag, attrs = {}, ...kids) {
  const el = document.createElement(tag);
  for (const [k, v] of Object.entries(attrs ?? {})) {
    if (v === undefined || v === null || v === false) continue;
    if (k === 'class') el.className = v;
    else if (k.startsWith('on') && typeof v === 'function') el.addEventListener(k.slice(2).toLowerCase(), v);
    else if (k === 'value') el.value = v;
    else if (k === 'checked' || k === 'disabled' || k === 'selected' || k === 'open' || k === 'hidden') el[k] = !!v;
    else if (k === 'style' && typeof v === 'object') for (const [p, val] of Object.entries(v)) el.style.setProperty(p, val);
    else el.setAttribute(k, v === true ? '' : String(v));
  }
  add(el, kids);
  return el;
}
function add(el, kids) {
  for (const k of kids.flat(Infinity)) {
    if (k === null || k === undefined || k === false) continue;
    el.append(k instanceof Node ? k : document.createTextNode(String(k)));
  }
}
export const clear = (el) => { while (el.firstChild) el.removeChild(el.firstChild); return el; };
export const mount = (el, ...kids) => { clear(el); add(el, kids); return el; };

const PATHS = {
  users: '<circle cx="9" cy="8.5" r="3.2"/><path d="M3.5 19c.4-3.2 2.6-5 5.5-5s5.1 1.8 5.5 5"/><path d="M16 5.8a3.2 3.2 0 0 1 0 5.8M17.8 14.4c1.7.6 2.7 2.1 2.9 4.2"/>',
  person: '<circle cx="12" cy="8" r="3.6"/><path d="M5 20c.6-3.6 3.3-5.6 7-5.6s6.4 2 7 5.6"/>',
  plus: '<path d="M12 5v14M5 12h14"/>', check: '<path d="m5 12.5 4.5 4.5L19 7.5"/>', x: '<path d="M6 6l12 12M18 6 6 18"/>',
  chevron: '<path d="m9 5 7 7-7 7"/>', back: '<path d="m15 5-7 7 7 7"/>', down: '<path d="m6 9 6 6 6-6"/>',
  gear: '<circle cx="12" cy="12" r="3"/><path d="M12 3.5v2.2M12 18.3v2.2M3.5 12h2.2M18.3 12h2.2M6 6l1.6 1.6M16.4 16.4 18 18M18 6l-1.6 1.6M7.6 16.4 6 18"/>',
  clock: '<circle cx="12" cy="12" r="8.5"/><path d="M12 7.5V12l3 2"/>', shield: '<path d="M12 3.5 5 6.2v5.3c0 4.2 2.9 7.3 7 8.9 4.1-1.6 7-4.7 7-8.9V6.2z"/><path d="m9 12 2.2 2.2L15.5 10"/>',
  sparkles: '<path d="M12 4l1.7 4.3L18 10l-4.3 1.7L12 16l-1.7-4.3L6 10l4.3-1.7z"/><path d="M18.5 15l.7 1.8 1.8.7-1.8.7-.7 1.8-.7-1.8-1.8-.7 1.8-.7z"/>',
  upload: '<path d="M12 16V5M7.5 9.5 12 5l4.5 4.5"/><path d="M5 15v3.5h14V15"/>', download: '<path d="M12 5v11M7.5 11.5 12 16l4.5-4.5"/><path d="M5 18.5h14"/>',
  trash: '<path d="M5 7h14M10 7V5h4v2M7 7l.8 12h8.4L17 7"/>', print: '<path d="M7 9V4h10v5M7 17H4.5v-6.5h15V17H17"/><path d="M7 14h10v6H7z"/>',
  refresh: '<path d="M19 8a7.5 7.5 0 0 0-13.5 1.5M5 16a7.5 7.5 0 0 0 13.5-1.5"/><path d="M19 4v4h-4M5 20v-4h4"/>', warn: '<path d="M12 4 3 19.5h18z"/><path d="M12 10v4.5M12 17.2v.1"/>',
  info: '<circle cx="12" cy="12" r="8.5"/><path d="M12 11v5M12 8v.1"/>', lock: '<rect x="5" y="10.5" width="14" height="9.5" rx="2.2"/><path d="M8.5 10.5V8a3.5 3.5 0 0 1 7 0v2.5"/>',
  laptop: '<rect x="5" y="5.5" width="14" height="9.5" rx="1.6"/><path d="M3 19h18"/>', tablet: '<rect x="6" y="3.5" width="12" height="17" rx="2"/><path d="M11 17.5h2"/>',
  till: '<rect x="4" y="4.5" width="16" height="11" rx="1.8"/><path d="M8 20h8M12 15.5V20"/>', kiosk: '<rect x="7" y="3" width="10" height="14" rx="1.8"/><path d="M9 21h6M12 17v4"/>',
  globe: '<circle cx="12" cy="12" r="8.5"/><path d="M3.5 12h17M12 3.5c2.5 2.5 3.5 5.5 3.5 8.5s-1 6-3.5 8.5c-2.5-2.5-3.5-5.5-3.5-8.5S9.5 6 12 3.5z"/>',
  phone: '<rect x="7" y="3" width="10" height="18" rx="2.2"/><path d="M11 18h2"/>', package: '<path d="m12 3.5 8 4.2v8.6L12 20.5l-8-4.2V7.7z"/><path d="m4 7.7 8 4.3 8-4.3M12 12v8.5"/>',
  key: '<circle cx="8" cy="14" r="3.5"/><path d="M10.5 11.5 19 3M16 6l2.5 2.5M14 8l2 2"/>', doc: '<path d="M7 3.5h7l4 4v13H7z"/><path d="M14 3.5V8h4M9.5 12h5M9.5 15.5h5"/>',
  list: '<path d="M8 6h11M8 12h11M8 18h11M4.5 6h.1M4.5 12h.1M4.5 18h.1"/>', store: '<path d="M4 9.5 5.5 4h13L20 9.5"/><path d="M4 9.5c0 1.4 1.1 2.5 2.5 2.5S9 10.9 9 9.5c0 1.4 1.1 2.5 2.5 2.5h1c1.4 0 2.5-1.100 2.5-2.500 0 1.400 1.100 2.500 2.500 2.500S20 10.900 20 9.500"/><path d="M5.5 12v8h13v-8"/>',
  eye: '<path d="M2.5 12S6 5.5 12 5.5 21.5 12 21.5 12 18 18.5 12 18.5 2.5 12 2.5 12z"/><circle cx="12" cy="12" r="2.8"/>', pen: '<path d="m4 20 1-4L16.5 4.500a2 2 0 0 1 2.800 0l.2.2a2 2 0 0 1 0 2.800L8 19z"/>',
  flag: '<path d="M6 21V4M6 5h11l-2 4 2 4H6"/>', terminal: '<rect x="3.5" y="5" width="17" height="14" rx="2.2"/><path d="m8 10 3 2.500L8 15M13 15h3.500"/>',
};
export function icon(name, cls = '') {
  const svg = document.createElementNS(SVG, 'svg');
  svg.setAttribute('viewBox', '0 0 24 24'); svg.setAttribute('fill', 'none'); svg.setAttribute('stroke', 'currentColor'); svg.setAttribute('stroke-width', '1.8');
  svg.setAttribute('stroke-linecap', 'round'); svg.setAttribute('stroke-linejoin', 'round'); svg.setAttribute('aria-hidden', 'true');
  svg.setAttribute('class', ('icon ' + cls).trim());
  // The shapes are fixed text written in this file (never data), so this is the one place markup is set.
  svg.innerHTML = PATHS[name] ?? PATHS.info;
  return svg;
}

let toastBox;
export function toast(message, kind = '') {
  if (!toastBox) { toastBox = h('div', { class: 'toasts', role: 'status' }); document.body.append(toastBox); }
  const t = h('div', { class: 'toast ' + kind }, kind === 'bad' ? icon('warn', 's') : icon('check', 's'), message);
  toastBox.append(t);
  setTimeout(() => { t.style.setProperty('opacity', '0'); t.style.setProperty('transition', 'opacity 300ms'); setTimeout(() => t.remove(), 320); }, kind === 'bad' ? 7000 : 3200);
}

/** Shows a message on the next page that opens (after a reload), so it is not lost. */
export function flash(message, kind = '') { try { sessionStorage.setItem('studio-flash', JSON.stringify({ message, kind })); } catch { toast(message, kind); } }
export function showFlash() { try { const f = JSON.parse(sessionStorage.getItem('studio-flash') || 'null'); sessionStorage.removeItem('studio-flash'); if (f) toast(f.message, f.kind); } catch { /* nothing to show */ } }

/** A sheet over the page. Returns { close, el, body }. `build(close)` fills it and returns the pieces (title, body, actions). */
export function sheet(build, { wide = false } = {}) {
  const previous = document.activeElement;
  const back = h('div', { class: 'backdrop', role: 'dialog', 'aria-modal': 'true' });
  const box = h('div', { class: 'sheet' + (wide ? ' wide' : '') });
  const close = () => { back.remove(); document.removeEventListener('keydown', onKey); previous?.focus?.(); };
  const onKey = (e) => { if (e.key === 'Escape') close(); };
  document.addEventListener('keydown', onKey);
  back.addEventListener('mousedown', (e) => { if (e.target === back) close(); });
  add(box, [build(close)]);
  back.append(box); document.body.append(back);
  box.querySelector('input, select, textarea, button')?.focus();
  return { close, el: box };
}

/** Asks a question in a sheet. Resolves to true or false. */
export function confirmSheet({ title, text, yes = 'Continue', no = 'Cancel', danger = false }) {
  return new Promise((resolve) => {
    let answered = false;
    const s = sheet((close) => h('div', {}, h('h2', {}, title), h('p', { class: 'muted mt-s' }, text),
      h('div', { class: 'actions' }, h('button', { class: 'btn', onclick: () => { answered = true; close(); resolve(false); } }, no),
        h('button', { class: 'btn primary' + (danger ? ' danger' : ''), onclick: () => { answered = true; close(); resolve(true); } }, yes))));
    new MutationObserver(() => { if (!document.body.contains(s.el) && !answered) { answered = true; resolve(false); } }).observe(document.body, { childList: true, subtree: true });
  });
}

export function ago(iso) {
  const t = Date.parse(iso); if (!t) return '';
  const s = Math.round((Date.now() - t) / 1000);
  if (s < 45) return 'just now'; if (s < 3600) return `${Math.round(s / 60)} min ago`; if (s < 86400) return `${Math.round(s / 3600)} h ago`;
  if (s < 86400 * 7) return `${Math.round(s / 86400)} days ago`;
  return new Date(t).toLocaleDateString(undefined, { day: 'numeric', month: 'short', year: 'numeric' });
}
export const when = (iso) => (Date.parse(iso) ? new Date(iso).toLocaleString(undefined, { day: 'numeric', month: 'short', year: 'numeric', hour: '2-digit', minute: '2-digit' }) : '');

export function download(blob, name) {
  const url = URL.createObjectURL(blob);
  const a = h('a', { href: url, download: name }); document.body.append(a); a.click(); a.remove();
  setTimeout(() => URL.revokeObjectURL(url), 5000);
}
export const b64url = (text) => btoa(String.fromCharCode(...new TextEncoder().encode(text))).replace(/\+/g, '-').replace(/\//g, '_').replace(/=+$/, '');
export const getPath = (o, path) => path.split('.').reduce((a, k) => (a === undefined || a === null ? undefined : a[k]), o);
export function setPath(o, path, value) { const ks = path.split('.'); let a = o; for (const k of ks.slice(0, -1)) { a[k] ??= {}; a = a[k]; } a[ks.at(-1)] = value; }
export const debounce = (fn, ms) => { let t; return (...a) => { clearTimeout(t); t = setTimeout(() => fn(...a), ms); }; };
