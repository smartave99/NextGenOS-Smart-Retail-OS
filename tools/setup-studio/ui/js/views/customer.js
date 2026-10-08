// One customer, as a journey: details, look and screens, prepare, review, website and app, installer, hand over. The page shows where the customer is and the one next thing to do.
import { h, icon, toast, ago, confirmSheet } from '../dom.js';
import { get, put, ApiError } from '../api.js';
import { app, go, refreshCounts } from '../main.js';
import { statePill } from './customers.js';
import { siteMissing } from '../sitewords.js';

export const title = (node) => node.dataset.title || 'Customer';

export const STEPS = [
  { id: 'details', label: 'Details', sub: 'Who they are and what they sell' },
  { id: 'look', label: 'Look and screens', sub: 'Colours, logo, machine' },
  { id: 'prepare', label: 'Prepare', sub: 'Make and improve the setup' },
  { id: 'review', label: 'Review', sub: 'A second person approves' },
  { id: 'site', label: 'Website and app', sub: 'Made for this customer' },
  { id: 'installer', label: 'Installer', sub: 'What goes to the customer' },
  { id: 'handover', label: 'Hand over', sub: 'Papers and sign-off' },
];
const MODULES = { details: () => import('./details.js'), look: () => import('./look.js'), prepare: () => import('./prepare.js'), review: () => import('./review.js'), site: () => import('./site.js'), installer: () => import('./output.js'), handover: () => import('./handover.js') };


function stepInfo(c) {
  const hasRelease = c.releases.length > 0;
  const site = hasRelease ? siteMissing(c) : { website: true, android: true };
  return {
    details: { done: c.check.complete, locked: false },
    look: { done: c.check.complete, locked: false },
    prepare: { done: !!c.proposal && !c.stale, locked: !c.check.complete, why: 'Finish the details first' },
    review: { done: ['approved', 'built', 'delivered'].includes(c.state), locked: !c.proposal, why: 'Prepare the setup first' },
    site: { done: hasRelease && !site.website && !site.android, locked: !hasRelease, why: 'Approve a setup first' },
    installer: { done: ['built', 'delivered'].includes(c.state), locked: !hasRelease, why: 'Approve a setup first' },
    handover: { done: c.state === 'delivered', locked: !hasRelease, why: 'Approve a setup first' },
  };
}

/** The one next thing to do, in words, and where it is. */
export function nextAction(c, can) {
  if (!c.check.complete) return { label: 'Finish the details', step: 'details' };
  if (c.state === 'draft' || !c.proposal) return { label: c.stale ? 'Prepare the setup again' : 'Prepare the setup', step: 'prepare' };
  if (c.state === 'proposed') return { label: 'Send for approval', step: 'review' };
  if (c.state === 'review') return can['review.decide'] ? { label: 'Review and approve', step: 'review' } : { label: 'Waiting for approval', step: 'review', quiet: true };
  if (c.state === 'approved') {
    const site = siteMissing(c);
    return site.website || site.android ? { label: 'Make the website and app', step: 'site' } : { label: 'Make the installer', step: 'installer' };
  }
  if (c.state === 'built') return { label: 'Hand over', step: 'handover' };
  return { label: 'See the hand-over', step: 'handover', quiet: true };
}

export async function render({ params }) {
  const id = params[0];
  const { customer } = await get(`/api/customers/${encodeURIComponent(id)}`);
  const requested = STEPS.find((s) => s.id === params[1])?.id;
  const step = requested ?? nextAction(customer, app.can).step;
  const ctx = {
    id, customer, step, app, can: app.can, opts: app.options, draft: JSON.parse(JSON.stringify(customer.intake)), saved: JSON.stringify(customer.intake),
    errors: customer.check.errors, warnings: customer.check.warnings, drawers: [], listeners: [], busy: false,
    go: (s) => goStep(ctx, s),
  };
  ctx.dirty = () => JSON.stringify(ctx.draft) !== ctx.saved;
  ctx.redraw = () => ctx.drawers.forEach((d) => d());
  ctx.touch = (path) => { drawBar(); ctx.listeners.forEach((l) => l(path)); };
  ctx.save = (quiet = false) => save(ctx, quiet);
  ctx.reload = () => { go(`/customers/${id}/${ctx.step}`); location.reload(); };
  ctx.replace = (c) => { ctx.customer = c; ctx.draft = JSON.parse(JSON.stringify(c.intake)); ctx.saved = JSON.stringify(c.intake); ctx.errors = c.check.errors; ctx.warnings = c.check.warnings; ctx.redraw(); drawHeader(); drawSteps(); drawBar(); };

  const root = h('div', { class: 'view', 'data-title': customer.name });
  const head = h('div', { class: 'page-head' });
  const stepsBox = h('nav', { class: 'steps', 'aria-label': 'Steps' });
  const pane = h('div', { class: 'col', id: 'pane' });
  const bar = h('div', { class: 'savebar hidden', role: 'status', id: 'savebar' });

  function drawHeader() {
    const c = ctx.customer;
    const act = nextAction(c, app.can);
    head.replaceChildren(
      h('div', { class: 'grow' }, h('a', { class: 'crumb', href: '#/customers' }, icon('back', 's'), 'Customers'),
        h('div', { class: 'row wrap' }, h('h1', { id: 'customer-name' }, c.name), statePill(c)),
        h('p', { class: 'sub' }, [ctx.opts.countries.find((x) => x.code === c.country)?.name, ctx.opts.industries.find((x) => x.id === c.industry)?.name, c.updatedAt ? `Changed ${ago(c.updatedAt)}${c.updatedBy ? ' by ' + c.updatedBy.name : ''}` : null].filter(Boolean).join(' · '))),
      h('button', { class: 'btn ' + (act.quiet ? '' : 'primary'), id: 'next-action', type: 'button', onclick: () => ctx.go(act.step) }, act.label, act.quiet ? null : icon('chevron', 's')));
    root.dataset.title = c.name;
  }
  function drawSteps() {
    const info = stepInfo(ctx.customer);
    stepsBox.replaceChildren(...STEPS.map((s, i) => {
      const st = info[s.id];
      return h('button', { type: 'button', class: 'step' + (st.done ? ' done' : '') + (st.locked ? ' locked' : ''), 'data-step': s.id, 'aria-current': s.id === step ? 'step' : null, title: st.locked ? st.why : '', onclick: () => { if (st.locked) { toast(st.why + '.', 'bad'); return; } ctx.go(s.id); } },
        h('span', { class: 'no' }, st.done && s.id !== step ? icon('check', 's') : String(i + 1)), h('span', {}, h('b', {}, s.label), h('span', { class: 's' }, s.sub)));
    }));
  }
  function drawBar() {
    if (!ctx.dirty()) { bar.classList.add('hidden'); return; }
    bar.classList.remove('hidden');
    bar.replaceChildren(icon('info', 's'), h('span', { class: 'grow' }, 'You have changes that are not saved yet.'),
      h('button', { class: 'btn small', type: 'button', id: 'discard', onclick: async () => { if (await confirmSheet({ title: 'Throw away your changes?', text: 'The details go back to how they were when you opened this page.', yes: 'Throw away', danger: true })) { ctx.draft = JSON.parse(ctx.saved); location.reload(); } } }, 'Discard'),
      h('button', { class: 'btn primary small', type: 'button', id: 'save', onclick: () => ctx.save() }, 'Save'));
  }
  ctx.drawBar = drawBar;

  drawHeader(); drawSteps();
  const mod = await MODULES[step]();
  pane.append(await mod.render(ctx));
  root.append(head, h('div', { class: 'journey' }, stepsBox, h('div', {}, pane, bar)));
  drawBar();
  window.addEventListener('beforeunload', (e) => { if (ctx.dirty()) { e.preventDefault(); e.returnValue = ''; } });
  return root;
}

async function save(ctx, quiet) {
  if (ctx.busy) return false;
  ctx.busy = true;
  try {
    const r = await put(`/api/customers/${encodeURIComponent(ctx.id)}`, { intake: ctx.draft, rev: ctx.customer.rev });
    ctx.replace(r.customer);
    await refreshCounts();
    if (!quiet) toast('Saved.');
    return true;
  } catch (e) {
    toast(e.message, 'bad');
    if (e instanceof ApiError && e.details) { ctx.errors = e.details; ctx.redraw(); }
    return false;
  } finally { ctx.busy = false; }
}

async function goStep(ctx, s) {
  if (ctx.dirty()) { const ok = await ctx.save(true); if (!ok) return; }
  go(`/customers/${ctx.id}/${s}`);
}
