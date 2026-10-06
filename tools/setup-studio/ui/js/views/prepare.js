// Make the setup from the details, and improve it with an AI tool if wanted. Nothing an AI tool says is kept until a person looks at what it changed and accepts it.
import { h, icon, toast, flash, sheet, when } from '../dom.js';
import { get, post } from '../api.js';

const PART = { business: 'The business', layout: 'Layout for the machine', look: 'The look', licence: 'The licence', starter: 'First items and people', money: 'Ways of paying' };

export async function render(ctx) {
  const c = ctx.customer;
  const box = h('div', { class: 'col' });
  const can = ctx.can['proposal.edit'];
  const locked = c.state === 'review';

  const make = async (e) => {
    e.currentTarget.classList.add('busy');
    try { const r = await post(`/api/customers/${ctx.id}/proposal`); ctx.replace(r.customer); flash('The setup was prepared.'); location.reload(); } catch (x) { toast(x.message, 'bad'); e.currentTarget.classList.remove('busy'); }
  };
  const p = c.proposal;
  const intro = h('div', { class: 'card' },
    h('div', { class: 'row wrap' }, h('div', { class: 'grow' }, h('h2', {}, p ? 'The prepared setup' : 'Prepare the setup'),
      h('p', { class: 'lead', style: { 'margin-bottom': '0' } }, p ? `${c.stale ? 'The details changed after this was prepared. Prepare it again. ' : ''}Made ${when(p.preparedAt)} by ${p.preparedBy?.name ?? 'someone'}${p.source === 'template' ? ' from the details.' : p.source.startsWith('ai:') ? ` with help from ${p.source.slice(3)}.` : ', then changed by hand.'}` : 'The Studio turns the details into the files the program reads: the business, the words, the settings, the look and the first items.')),
      can && !locked ? h('button', { class: 'btn ' + (p ? '' : 'primary'), id: 'make-proposal', type: 'button', onclick: make }, icon('refresh', 's'), p ? 'Prepare again from the details' : 'Prepare the setup') : null),
    locked ? h('div', { class: 'notice mt-s' }, icon('info'), 'This setup is waiting for approval. A reviewer can approve it or send it back.') : null,
    c.rejection ? h('div', { class: 'notice warn mt-s', id: 'rejection' }, icon('warn'), h('div', {}, h('b', {}, `${c.rejection.by.name} sent it back`), h('div', {}, c.rejection.reason))) : null);
  box.append(intro);
  if (!p) return box;

  // what the setup says, in words
  box.append(h('div', { class: 'card', id: 'explain' }, h('h2', {}, 'What this does'), h('div', { class: 'col mt-s' }, (p.explain ?? []).map((e) => h('div', {}, h('b', {}, PART[e.part] ?? e.part), h('p', { class: 'muted' }, e.text))))));
  if (p.problems?.length) box.append(h('div', { class: 'notice warn', id: 'proposal-problems' }, icon('warn'), h('div', {}, h('b', {}, 'Parts that could not be used'), h('ul', {}, p.problems.map((x) => h('li', {}, x))))));

  // AI
  if (can && !locked) box.append(aiCard(ctx));

  // the files
  const view = (title, obj) => h('details', { class: 'more' }, h('summary', {}, icon('doc', 's'), title), h('pre', { class: 'code mt-s' }, JSON.stringify(obj, null, 2)));
  box.append(h('div', { class: 'card flat' }, h('h3', {}, 'The files the program reads'), h('p', { class: 'small muted' }, 'You do not need to read these. They are here so nothing is hidden. To change what is in them, change the details and prepare again.'),
    h('div', { class: 'col mt-s' }, view('setup.json: the business, words, settings and first items', p.setup), view('theme.json: the look and layout', p.theme), view('brand.json: name, colours and logo', { ...p.brand, logo: p.brand.logo ? '(the logo picture)' : undefined }))));
  return box;
}

function aiCard(ctx) {
  const card = h('div', { class: 'card', id: 'ai-card' });
  const draw = async () => {
    let settings, tools;
    try { [settings, tools] = await Promise.all([get('/api/settings'), get('/api/ai/tools')]); } catch (e) { card.replaceChildren(h('div', { class: 'err' }, icon('warn', 's'), e.message)); return; }
    const active = settings.ai.tool;
    const tool = tools.tools.find((t) => t.id === active);
    const cfg = settings.ai.tools[active] ?? {};
    card.replaceChildren(
      h('div', { class: 'row wrap' }, h('div', { class: 'grow' }, h('h2', {}, icon('sparkles'), ' Improve with an AI tool'), h('p', { class: 'lead', style: { 'margin-bottom': '0' } }, 'Optional. The AI suggests local words, ways of paying and a fitting look. You see every change before anything is kept.')),
        active !== 'none' && tool ? h('button', { class: 'btn primary', id: 'ai-run', type: 'button', onclick: () => run(ctx, active, tool, cfg) }, icon('sparkles', 's'), 'Ask ' + tool.label.replace(/ \(.*/, '')) : h('a', { class: 'btn', href: '#/settings' }, 'Choose a tool in Settings')),
      active !== 'none' && tool ? h('p', { class: 'small muted mt-s' }, [`Tool: ${tool.label}`, cfg.model ? `model ${cfg.model}` : 'the tool\'s own model', cfg.effort ? `thinking: ${cfg.effort}` : null].filter(Boolean).join(' · '), tool.status?.found === false ? '  ·  not found on this PC' : '') : h('p', { class: 'small muted mt-s' }, 'No AI tool is chosen. The plain setup works without one.'),
      h('details', { class: 'more mt-s' }, h('summary', { onclick: () => showSent(ctx, card) }, icon('eye', 's'), 'Show exactly what would be sent'), h('div', { id: 'sent-box', class: 'mt-s' })));
  };
  draw();
  return card;
}

async function showSent(ctx, card) {
  const box = card.querySelector('#sent-box');
  if (box.dataset.loaded) return;
  box.dataset.loaded = '1';
  try {
    const { preview } = await post(`/api/customers/${ctx.id}/ai/preview`);
    box.replaceChildren(h('div', { class: 'grid2' }, h('div', {}, h('b', {}, 'Leaves this PC'), h('ul', {}, preview.leaves.map((x) => h('li', {}, x)))), h('div', {}, h('b', {}, 'Stays on this PC'), h('ul', {}, preview.stays.map((x) => h('li', {}, x))))),
      h('details', { class: 'more' }, h('summary', {}, 'The full message'), h('pre', { class: 'code mt-s' }, preview.system + '\n\n————————\n\n' + preview.user)));
  } catch (e) { box.replaceChildren(h('div', { class: 'err' }, icon('warn', 's'), e.message)); }
}

function run(ctx, tool, info, cfg) {
  let timer;
  const body = h('div', {});
  const s = sheet((close) => { const x = () => { clearInterval(timer); close(); }; body._close = x; return h('div', {}, body); }, { wide: true });
  const started = Date.now();
  const clock = h('span', { class: 'muted' }, '0 s');
  body.replaceChildren(h('h2', {}, `Asking ${info.label}…`), h('p', { class: 'muted mt-s' }, 'This can take a minute or two. You can leave this window open and keep reading.'),
    h('div', { class: 'row mt', style: { 'justify-content': 'center', padding: '28px 0' } }, icon('refresh', 'l spin'), clock));
  timer = setInterval(() => { clock.textContent = `${Math.round((Date.now() - started) / 1000)} s`; }, 1000);
  post(`/api/customers/${ctx.id}/ai/run`, { tool }).then((r) => {
    clearInterval(timer);
    body.replaceChildren(h('h2', {}, 'What the AI suggests'),
      r.explanation ? h('p', { class: 'mt-s', id: 'ai-explanation' }, r.explanation) : null,
      r.meta?.model ? h('p', { class: 'tiny muted' }, `Answered by ${r.meta.model}${r.meta.effort ? ' at ' + r.meta.effort + ' thinking' : ''}.`) : null,
      r.changes.length ? h('div', { class: 'panel mt' }, h('table', { class: 'tbl', id: 'ai-changes' }, h('thead', {}, h('tr', {}, ['What', 'Was', 'Becomes'].map((t) => h('th', {}, t)))), h('tbody', {}, r.changes.map((c) => h('tr', {}, h('td', {}, c.what), h('td', { class: 'muted' }, c.from), h('td', {}, h('b', {}, c.to))))))) : h('div', { class: 'notice ok mt' }, icon('check'), 'The AI would change nothing. The setup already fits.'),
      r.problems.length ? h('div', { class: 'notice warn mt-s' }, icon('warn'), h('div', {}, h('b', {}, 'Left out or put back'), h('ul', {}, r.problems.map((x) => h('li', {}, x))))) : null,
      h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', id: 'ai-discard', onclick: () => body._close() }, 'Do not use it'),
        h('button', { class: 'btn primary', id: 'ai-accept', type: 'button', disabled: !r.changes.length, onclick: async (e) => { e.currentTarget.classList.add('busy'); try { await post(`/api/customers/${ctx.id}/ai/accept`, { setup: r.proposal.setup, theme: r.proposal.theme, tool, explanation: r.explanation }); flash('The improved setup was kept.'); body._close(); location.reload(); } catch (x) { toast(x.message, 'bad'); e.currentTarget.classList.remove('busy'); } } }, 'Keep these changes')));
  }).catch((e) => {
    clearInterval(timer);
    body.replaceChildren(h('h2', {}, 'The AI tool could not help'), h('div', { class: 'notice bad mt', id: 'ai-error' }, icon('warn'), e.message), h('p', { class: 'muted mt-s' }, 'Nothing was changed. You can try again, choose another tool in Settings, or go on with the plain setup.'),
      h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', onclick: () => body._close() }, 'Close')));
  });
  void s;
}
