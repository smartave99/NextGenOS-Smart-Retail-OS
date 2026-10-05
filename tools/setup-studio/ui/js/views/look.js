// The look and the machine, with a real picture of the program beside the choices: the Hub's own style sheets, in the chosen colours, shapes and layout.
import { h, icon, toast, b64url, debounce } from '../dom.js';
import { put } from '../api.js';
import { text, select, toggle, seg, cards, section, errorBox } from './form.js';

const DEVICES = { laptop: { small: [1280, 720], standard: [1440, 900], large: [1920, 1080] }, 'touch-pos': { small: [1024, 768], standard: [1280, 800], large: [1920, 1080] }, tablet: { small: [768, 1024], standard: [1024, 768], large: [1280, 800] }, kiosk: { small: [1080, 1920], standard: [1080, 1920], large: [1080, 1920] } };

/** WCAG contrast of a "#rrggbb" colour with white words. */
export function contrastWithWhite(hex) {
  const ch = (a) => { const c = parseInt(hex.slice(a, a + 2), 16) / 255; return c <= 0.04045 ? c / 12.92 : ((c + 0.055) / 1.055) ** 2.4; };
  return 1.05 / (0.2126 * ch(1) + 0.7152 * ch(3) + 0.0722 * ch(5) + 0.05);
}
const HEX = /^#[0-9a-fA-F]{6}$/;

export async function render(ctx) {
  const d = ctx.draft;
  const frame = previewStage(ctx);
  ctx.listeners.push(() => frame.update());

  // colours
  const colour = (path, label, { required }) => {
    const value = () => d.look[path.split('.')[1]] || '';
    const hex = h('input', { type: 'text', id: 'c-' + path, value: value(), placeholder: required ? '#0f6cbd' : 'optional', 'data-path': path, 'aria-label': label + ' (hex)', spellcheck: 'false' });
    const pick = h('input', { type: 'color', value: HEX.test(value()) ? value() : '#0f6cbd', 'aria-label': 'Pick ' + label.toLowerCase() });
    const say = h('div', { class: 'tiny' });
    const sync = (v) => {
      const ok = HEX.test(v);
      say.className = 'tiny ' + (!v && !required ? 'muted' : ok && contrastWithWhite(v) >= 3 ? '' : 'err');
      say.textContent = !v ? (required ? 'Choose a colour.' : 'Not set: the main colour is used.') : !ok ? 'Type a colour like #0f6cbd.' : contrastWithWhite(v) >= 3 ? `Reads well with white words (contrast ${contrastWithWhite(v).toFixed(1)}).` : 'Too light for white words on buttons. Choose a darker colour.';
      say.style.setProperty('color', !v ? '' : ok && contrastWithWhite(v) >= 3 ? 'var(--ngos-ok)' : '');
    };
    hex.addEventListener('input', () => { d.look[path.split('.')[1]] = hex.value.trim().toLowerCase(); if (HEX.test(hex.value)) pick.value = hex.value; sync(hex.value); ctx.touch(path); });
    pick.addEventListener('input', () => { hex.value = pick.value; d.look[path.split('.')[1]] = pick.value; sync(pick.value); ctx.touch(path); });
    sync(value());
    return h('div', { class: 'field' }, h('label', { for: 'c-' + path }, label), h('div', { class: 'row' }, pick, h('div', { class: 'grow' }, hex)), say, errorBox(ctx, path));
  };

  // logo
  const logoImg = h('div', { class: 'logo-box', id: 'logo-box' });
  const drawLogo = () => logoImg.replaceChildren(ctx.customer.hasLogo ? h('img', { src: `/api/logo/${ctx.id}?k=${encodeURIComponent(sessionStorage.getItem('studio-key'))}&t=${Date.now()}`, alt: 'Logo' }) : icon('store', 'l muted'));
  drawLogo();
  const file = h('input', { type: 'file', id: 'logo-file', accept: 'image/png,image/jpeg,image/svg+xml' });
  const upload = async (f) => {
    if (!f) return;
    if (f.size > 900_000) { toast('That picture is too big. Use one under 900 KB.', 'bad'); return; }
    const data = await new Promise((res, rej) => { const r = new FileReader(); r.onload = () => res(r.result); r.onerror = rej; r.readAsDataURL(f); });
    try {
      if (ctx.dirty()) await ctx.save(true);
      const r = await put(`/api/customers/${ctx.id}/logo`, { data });
      ctx.replace(r.customer); drawLogo(); frame.update(); toast('Logo set.');
    } catch (e) { toast(e.message, 'bad'); }
  };
  file.addEventListener('change', () => upload(file.files[0]));
  const drop = h('div', { class: 'drop', id: 'logo-drop', tabindex: '0', role: 'button', 'aria-label': 'Choose a logo picture', onclick: () => file.click(), onkeydown: (e) => { if (e.key === 'Enter' || e.key === ' ') { e.preventDefault(); file.click(); } },
    ondragover: (e) => { e.preventDefault(); drop.classList.add('over'); }, ondragleave: () => drop.classList.remove('over'), ondrop: (e) => { e.preventDefault(); drop.classList.remove('over'); upload(e.dataTransfer.files[0]); } },
    icon('upload'), h('b', {}, ctx.customer.hasLogo ? 'Change the logo' : 'Add the logo'), h('span', { class: 'small' }, 'PNG, JPEG or SVG. Drop a file here or click.'));

  const styleCards = cards(ctx, 'look.style', ctx.opts.options.styles, { label: 'Style', hint: 'The shape of buttons, the letters and the depth. A licence with a fixed look keeps its own.', minWidth: 170 });
  const left = h('div', { class: 'col' },
    section('Logo and colours', 'The customer\'s own identity.',
      h('div', { class: 'row', style: { 'align-items': 'flex-start' } }, logoImg, h('div', { class: 'grow' }, drop, file)),
      h('div', { class: 'col mt' }, colour('look.primaryColor', 'Main colour', { required: true }), colour('look.accentColor', 'Second colour (optional)', { required: false })),
      ctx.warnings.find((w) => w.field === 'licence.whiteLabel') ? h('div', { class: 'notice warn mt-s' }, icon('warn'), ctx.warnings.find((w) => w.field === 'licence.whiteLabel').message) : null),
    section('Style', null, styleCards, h('div', { class: 'mt-s' }, seg(ctx, 'look.appearance', ctx.opts.options.appearances.map((a) => ({ value: a.id, label: a.label })), { label: 'Light or dark' }))),
    section('The machine it runs on', 'The screens are laid out for it: big buttons for a finger, the menu where it is easiest to reach.',
      cards(ctx, 'device.kind', ctx.opts.options.deviceKinds.map((k) => ({ ...k, icon: { laptop: 'laptop', 'touch-pos': 'till', tablet: 'tablet', kiosk: 'kiosk' }[k.id] })), { label: 'Kind of machine', minWidth: 190 }),
      h('div', { class: 'col mt-s' }, seg(ctx, 'device.os', ctx.opts.options.systems.map((s) => ({ value: s.id, label: s.label })), { label: 'System' }), seg(ctx, 'device.screen', ctx.opts.options.screens.map((s) => ({ value: s.id, label: s.label })), { label: 'Screen size' })),
      h('div', { class: 'col mt-s' }, select(ctx, 'device.printer', ctx.opts.options.printers, { label: 'Printer' }), toggle(ctx, 'device.scanner', { label: 'Barcode scanner' }), toggle(ctx, 'device.drawer', { label: 'Cash drawer' }))));
  return h('div', { class: 'col', style: { gap: '18px' } }, frame.el, left);
}

function previewStage(ctx) {
  const d = ctx.draft;
  let screenName = 'sell';
  const frameEl = h('iframe', { title: 'How the program will look', id: 'preview-frame', sandbox: 'allow-same-origin', tabindex: '-1' });
  const screen = h('div', { class: 'screen' }, frameEl);
  const device = h('div', { class: 'device' }, screen);
  const caption = h('div', { class: 'small muted', style: { 'text-align': 'center' }, id: 'preview-caption' });
  const tabs = h('div', { class: 'seg' }, [['sell', 'New sale'], ['today', 'Today']].map(([id, label]) => h('button', { type: 'button', 'aria-pressed': String(id === screenName), onclick: () => { screenName = id; for (const b of tabs.children) b.setAttribute('aria-pressed', String(b.textContent === label)); update(); } }, label)));
  const layout = () => {
    const [w, hgt] = (DEVICES[d.device.kind] ?? DEVICES.laptop)[d.device.screen] ?? [1440, 900];
    device.className = 'device ' + d.device.kind;
    screen.style.setProperty('aspect-ratio', `${w} / ${hgt}`);
    // as wide as the page allows, but never taller than about a third of the window, so the choices below stay in view
    const pad = d.device.kind === 'tablet' || d.device.kind === 'kiosk' ? 20 : 16;
    const maxHeight = Math.max(200, Math.min(window.innerHeight * 0.34, 420));
    device.style.setProperty('max-width', Math.round(maxHeight * (w / hgt) + pad) + 'px');
    device.style.setProperty('margin', '0 auto');
    const scale = screen.clientWidth / w;
    frameEl.style.setProperty('width', w + 'px'); frameEl.style.setProperty('height', hgt + 'px'); frameEl.style.setProperty('transform', `scale(${scale || 0.5})`);
  };
  const update = debounce(() => {
    const payload = { name: d.business.name || 'Your business', country: d.business.country, industry: d.business.industry, primary: d.look.primaryColor, accent: d.look.accentColor, style: d.look.style, appearance: d.look.appearance, kind: d.device.kind, screen: d.device.screen, level: d.licence.whiteLabel, screenName, logo: ctx.customer.hasLogo ? ctx.id : null, poweredBy: d.look.poweredBy };
    frameEl.src = `/preview?k=${encodeURIComponent(sessionStorage.getItem('studio-key'))}&d=${b64url(JSON.stringify(payload))}`;
    const level = d.licence.whiteLabel;
    caption.textContent = level === 'none' ? 'With a "fixed look" licence the colours, shapes and letters come from the licence\'s own brand. Only the layout for the machine shows.' : level === 'theme' ? 'Their licence shows these colours, shapes and letters. The owner can change them.' : 'Their licence shows this look and name in full. The owner can change them.';
    layout();
  }, 120);
  const ro = new ResizeObserver(() => layout());
  setTimeout(() => { ro.observe(screen); update(); }, 0);
  const el = h('div', { class: 'stage' }, h('div', { class: 'row', style: { width: '100%' } }, h('b', { class: 'grow' }, 'Live preview'), tabs), device, caption);
  return { el, update };
}
