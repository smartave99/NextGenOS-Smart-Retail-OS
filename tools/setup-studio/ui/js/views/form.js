// Form pieces that read and write one place in the customer's details (a path like "business.name"), show the problem the server found for it, and tell the page something changed.
import { h, icon, getPath, setPath } from '../dom.js';

/** `ctx` has draft, errors (path -> text), warnings, touch(). */
export function errorBox(ctx, path, { warnings = true } = {}) {
  const box = h('div', { 'data-error-for': path });
  const draw = () => {
    box.replaceChildren();
    for (const e of ctx.errors.filter((x) => x.field === path)) box.append(h('div', { class: 'err' }, icon('warn', 's'), e.message));
    if (warnings) for (const w of ctx.warnings.filter((x) => x.field === path)) box.append(h('div', { class: 'warn' }, icon('info', 's'), w.message));
  };
  ctx.drawers.push(draw); draw();
  return box;
}
const wrap = (ctx, path, label, control, hint, id) => h('div', { class: 'field' }, label ? h('label', { for: id }, label) : null, control, hint ? h('span', { class: 'hint' }, hint) : null, errorBox(ctx, path, { warnings: !['business.country', 'business.contact', 'look.logo'].includes(path) }));
let n = 0;
const uid = (path) => `f-${path.replace(/\W+/g, '-')}-${++n}`;

export function text(ctx, path, { label, hint, type = 'text', placeholder, maxlength, autocomplete, inputmode } = {}) {
  const id = uid(path);
  const input = h('input', { type, id, value: getPath(ctx.draft, path) ?? '', placeholder, maxlength, autocomplete: autocomplete ?? 'off', inputmode, spellcheck: 'false', 'data-path': path, oninput: (e) => { setPath(ctx.draft, path, type === 'number' ? (e.target.value === '' ? '' : Number(e.target.value)) : e.target.value); ctx.touch(path); } });
  return wrap(ctx, path, label, input, hint, id);
}
export function area(ctx, path, { label, hint, placeholder, maxlength, rows = 4 } = {}) {
  const id = uid(path);
  const el = h('textarea', { id, rows, placeholder, maxlength, 'data-path': path, oninput: (e) => { setPath(ctx.draft, path, e.target.value); ctx.touch(path); } });
  el.value = getPath(ctx.draft, path) ?? '';
  return wrap(ctx, path, label, el, hint, id);
}
export function select(ctx, path, options, { label, hint, onChange, blank } = {}) {
  const id = uid(path);
  const cur = getPath(ctx.draft, path) ?? '';
  const el = h('select', { id, 'data-path': path, onchange: (e) => { setPath(ctx.draft, path, e.target.value); onChange?.(e.target.value); ctx.touch(path); } },
    blank ? h('option', { value: '' }, blank) : null, options.map((o) => h('option', { value: o.id ?? o.code, selected: (o.id ?? o.code) === cur }, o.label ?? o.name)));
  return wrap(ctx, path, label, el, hint, id);
}
export function toggle(ctx, path, { label, text: sub, onChange, invert = false } = {}) {
  const input = h('input', { type: 'checkbox', checked: invert ? !getPath(ctx.draft, path) : !!getPath(ctx.draft, path), 'data-path': path, onchange: (e) => { setPath(ctx.draft, path, invert ? !e.target.checked : e.target.checked); onChange?.(e.target.checked); ctx.touch(path); } });
  return h('div', {}, h('label', { class: 'switch' }, input, h('span', { class: 'track' }), h('span', { class: 'text' }, h('b', {}, label), sub ? h('span', {}, sub) : null)), errorBox(ctx, path));
}
/** A row of buttons of which one is chosen. Values may be strings or booleans; null means "as the country or the kind of business has it". */
export function seg(ctx, path, options, { label, hint, onChange } = {}) {
  const box = h('div', { class: 'seg', role: 'group', 'aria-label': label ?? path, 'data-path': path });
  const draw = () => { for (const b of box.children) b.setAttribute('aria-pressed', String(b._value === getPath(ctx.draft, path))); };
  for (const o of options) { const b = h('button', { type: 'button', 'data-value': String(o.value), onclick: () => { setPath(ctx.draft, path, o.value); draw(); onChange?.(o.value); ctx.touch(path); } }, o.label); b._value = o.value; box.append(b); }
  draw();
  return h('div', { class: 'field' }, label ? h('span', { class: 'label' }, label) : null, h('div', {}, box), hint ? h('span', { class: 'hint' }, hint) : null, errorBox(ctx, path));
}
/** Cards, one of which is chosen. Each option: { id, label, hint, icon? }. */
export function cards(ctx, path, options, { label, hint, onChange, minWidth } = {}) {
  const box = h('div', { class: 'choices', role: 'group', 'aria-label': label ?? path, 'data-path': path });
  if (minWidth) box.style.setProperty('grid-template-columns', `repeat(auto-fill, minmax(${minWidth}px, 1fr))`);
  const draw = () => { for (const b of box.children) b.setAttribute('aria-pressed', String(b._id === getPath(ctx.draft, path))); };
  for (const o of options) { const b = h('button', { type: 'button', class: 'choice', 'data-value': o.id, onclick: () => { setPath(ctx.draft, path, o.id); draw(); onChange?.(o.id); ctx.touch(path); } }, h('b', {}, o.icon ? icon(o.icon) : null, o.label), o.hint ? h('span', {}, o.hint) : null); b._id = o.id; box.append(b); }
  draw();
  return h('div', { class: 'field' }, label ? h('span', { class: 'label' }, label) : null, box, hint ? h('span', { class: 'hint' }, hint) : null, errorBox(ctx, path));
}
export const section = (title, lead, ...kids) => h('div', { class: 'card' }, h('h2', {}, title), lead ? h('p', { class: 'lead' }, lead) : null, ...kids);
