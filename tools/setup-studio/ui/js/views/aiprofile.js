// The pictures and posters the AI assistant makes: who the three model photos show, the festivals, the second language. Shown when the customer gets the AI assistant.
// Everything is optional and stays neutral until it is typed: nothing here is a default for any country or trade. The details are the customer's own (the "images" part).
import { h, icon } from '../dom.js';
import { errorBox } from './form.js';
import { aiExplain } from '../aiwords.js';

let counter = 0;

/** Takes empty things out of the "images" part, so a field that was typed in and cleared again leaves the details as they were. */
export function tidy(d) {
  const im = d.images;
  if (!im || typeof im !== 'object') { delete d.images; return; }
  const empty = (v) => typeof v !== 'string' || v.trim() === '';
  for (const k of ['countryName', 'shopKind']) if (empty(im[k])) delete im[k];
  if (Array.isArray(im.models)) {
    while (im.models.length && empty(im.models.at(-1).title) && empty(im.models.at(-1).looks)) im.models.pop();
    if (!im.models.length) delete im.models;
  } else delete im.models;
  if (!Array.isArray(im.festivals) || !im.festivals.length) delete im.festivals;
  const l = im.localLanguage;
  if (l && typeof l === 'object') {
    for (const [k, v] of Object.entries(l.lines ?? {})) if (empty(v)) delete l.lines[k];
    if (l.lines && !Object.keys(l.lines).length) delete l.lines;
    if (empty(l.name) && empty(l.tag) && !l.lines) delete im.localLanguage;
  } else delete im.localLanguage;
  if (!Object.keys(im).length) delete d.images;
}

/** One line of typing with its label, its hint and the problems the server found for it. */
function line(ctx, { path, label, hint, maxlength, placeholder, get, set }) {
  const id = `ai-${++counter}`;
  const input = h('input', { type: 'text', id, value: get() ?? '', placeholder, maxlength, autocomplete: 'off', spellcheck: 'false', 'data-path': path, oninput: (e) => { set(e.target.value); ctx.touch(path); } });
  const field = h('div', { class: 'field' }, h('label', { for: id }, label), input, hint ? h('span', { class: 'hint' }, hint) : null, errorBox(ctx, path));
  // after a save the details are replaced by what the server kept (trimmed, cleaned): the box shows that
  ctx.drawers.push(() => { const now = get() ?? ''; if (input.value !== now) input.value = now; });
  field.input = input;
  return field;
}

export function aiSection(ctx) {
  // The details are replaced as a whole when they are saved, so they are always looked up again, never kept.
  const draft = () => ctx.draft;
  const lim = ctx.opts.options.imageLimits;
  const country = () => ctx.opts.countries.find((c) => c.code === draft().business.country);
  const industry = () => ctx.opts.industries.find((i) => i.id === draft().business.industry);
  const images = () => (draft().images ??= {});
  const model = (i) => { const list = (images().models ??= []); while (list.length <= i) list.push({ title: '', looks: '' }); return list[i]; };
  const language = () => (images().localLanguage ??= { name: '', tag: '' });

  // what it changes, in words, live
  const list = h('ul', { id: 'ai-explain-list' });
  const drawExplain = () => list.replaceChildren(...aiExplain({ draft: draft(), country: country(), industry: industry(), posterKinds: ctx.opts.options.posterKinds }).map((l) => h('li', { 'data-line': l.id }, l.text)));
  ctx.listeners.push(() => { tidy(draft()); ctx.drawBar?.(); drawExplain(); });
  ctx.drawers.push(drawExplain);
  drawExplain();

  const place = h('div', { class: 'grid2 mt-s' },
    line(ctx, { path: 'images.countryName', label: 'How the AI says the country', maxlength: lim.country, placeholder: country()?.name ?? '', get: () => draft().images?.countryName, set: (v) => { images().countryName = v; }, hint: 'Leave empty to use the name from the country list. Some countries are said with "the", like the Philippines or the Netherlands.' }),
    line(ctx, { path: 'images.shopKind', label: 'How the AI says the kind of business', maxlength: lim.shopKind, placeholder: industry()?.shopKind ?? '', get: () => draft().images?.shopKind, set: (v) => { images().shopKind = v; }, hint: 'Said like "a small restaurant" or "a clothes shop". Leave empty to use the one for this kind of business.' }));

  const models = h('div', { class: 'col mt-s' }, [0, 1, 2].map((i) => h('div', { class: 'card flat' },
    h('b', {}, `Product photo ${i + 3}`),
    h('div', { class: 'grid2 mt-s' },
      line(ctx, { path: `images.models.${i}.title`, label: 'Name shown on the screen', maxlength: lim.modelTitle, placeholder: `Model ${i + 1}`, get: () => draft().images?.models?.[i]?.title, set: (v) => { model(i).title = v; } }),
      line(ctx, { path: `images.models.${i}.looks`, label: 'Who the person looks like (optional)', maxlength: lim.modelLooks, placeholder: 'Leave empty and the AI chooses', get: () => draft().images?.models?.[i]?.looks, set: (v) => { model(i).looks = v; } })))));

  // festivals, as little tags
  const chips = h('div', { class: 'chips', id: 'ai-festival-chips' });
  const add = h('input', { type: 'text', placeholder: 'Add a festival', maxlength: lim.festival, id: 'ai-festival-add', 'aria-label': 'Add a festival', autocomplete: 'off' });
  const drawChips = () => chips.replaceChildren(...(draft().images?.festivals ?? []).map((f) => h('span', { class: 'chip on' }, f,
    h('button', { type: 'button', 'aria-label': `Take out ${f}`, onclick: () => { draft().images.festivals = draft().images.festivals.filter((x) => x !== f); drawChips(); ctx.touch('images.festivals'); } }, icon('x', 's')))));
  const addNow = () => {
    const v = add.value.trim();
    if (!v) return;
    const now = draft().images?.festivals ?? [];
    if (now.length < lim.festivals && !now.some((x) => x.toLowerCase() === v.toLowerCase())) images().festivals = [...now, v];
    add.value = '';
    drawChips();
    ctx.touch('images.festivals');
  };
  add.addEventListener('keydown', (e) => { if (e.key === 'Enter') { e.preventDefault(); addNow(); } });
  drawChips();
  ctx.drawers.push(drawChips);

  // the second language
  const name = line(ctx, { path: 'images.localLanguage.name', label: 'Name of the language', maxlength: lim.language, placeholder: 'For example, Hindi', get: () => draft().images?.localLanguage?.name, set: (v) => { language().name = v; } });
  const tag = line(ctx, { path: 'images.localLanguage.tag', label: 'Its short code', maxlength: lim.tag, placeholder: 'hi', get: () => draft().images?.localLanguage?.tag, set: (v) => { language().tag = v; }, hint: 'Two or three small letters, like hi or fil.' });
  const offered = (country()?.languages ?? []).map((s) => h('button', { type: 'button', class: 'chip', 'data-language': s.tag, onclick: () => { language().name = s.name; language().tag = s.tag; name.input.value = s.name; tag.input.value = s.tag; ctx.touch('images.localLanguage.name'); } }, icon('plus', 's'), `${s.name} (${s.tag})`));
  const lines = h('div', { class: 'grid2 mt-s' }, ctx.opts.options.posterKinds.map((k) => line(ctx, { path: `images.localLanguage.lines.${k.id}`, label: `${k.label} poster`, maxlength: lim.line, get: () => draft().images?.localLanguage?.lines?.[k.id], set: (v) => { (language().lines ??= {})[k.id] = v; } })));

  return h('div', { class: 'card', id: 'ai-profile' },
    h('h2', {}, 'Pictures and posters made by the AI assistant'),
    h('p', { class: 'lead' }, 'Tell the AI who this shop\'s customers are, so its photos and posters feel like theirs. Everything here is optional. What you leave empty stays neutral: no festival, no second language, and no one in particular in the photos.'),
    h('h3', {}, 'The business'), place,
    h('h3', { class: 'mt' }, 'People in the product photos'),
    h('p', { class: 'hint' }, 'Photos 3, 4 and 5 of each product show a person using it. Name each photo as the shop will see it, and say in a few words who the person looks like. Nothing in the country list or the business list covers this, so it is typed.'),
    models,
    h('h3', { class: 'mt' }, 'Festivals'),
    h('p', { class: 'hint' }, 'The festivals this shop\'s customers keep, which offer posters can name. The country list has none, so type the ones that matter.'),
    chips, h('div', { class: 'row mt-s' }, h('div', { class: 'grow', style: { 'max-width': '320px' } }, add), h('button', { class: 'btn', type: 'button', id: 'ai-festival-button', onclick: addNow }, 'Add')), errorBox(ctx, 'images.festivals'),
    h('h3', { class: 'mt' }, 'A second language on posters'),
    h('p', { class: 'hint' }, offered.length ? 'These are the languages the country list names for this country (besides English). Choose one, or type another.' : 'Type the language if posters should carry a second line in it. Leave empty for one language.'),
    offered.length ? h('div', { class: 'chips mt-s', id: 'ai-language-offers' }, offered) : null,
    h('div', { class: 'grid2 mt-s' }, name, tag),
    h('p', { class: 'hint mt-s' }, 'Ready-made lines are optional. Where one is empty, the line is written when the AI makes the poster, or typed by the owner.'),
    lines, errorBox(ctx, 'images.localLanguage'),
    h('div', { class: 'notice mt', id: 'ai-explain', 'aria-live': 'polite' }, icon('info'), h('div', {}, h('b', {}, 'What this changes'), list,
      h('p', { class: 'small muted' }, 'The Studio checks the length and the letters allowed. It cannot tell whether a description gives a good picture, so try a few product photos at the first visit.'))));
}
