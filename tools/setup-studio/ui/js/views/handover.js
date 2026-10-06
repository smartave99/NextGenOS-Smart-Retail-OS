// The hand-over sheet: what the customer gets, how to put it in place, what their licence allows, and who to call. It prints cleanly. Then the hand-over is recorded.
import { h, icon, toast, flash, when } from '../dom.js';
import { get, post } from '../api.js';

export async function render(ctx) {
  const c = ctx.customer;
  const release = c.releases.at(-1);
  if (!release) return h('div', { class: 'empty' }, h('h2', {}, 'Nothing to hand over yet'), h('p', {}, 'Approve a setup first.'));
  // The sheet is made by the Studio's server from the approved release, so this page and the page inside the customer pack always say the same.
  const { sheet } = await get(`/api/customers/${encodeURIComponent(ctx.id)}/handover`);
  const sheetEl = h('div', { class: 'card', id: 'handover-sheet' },
    h('div', { class: 'row' }, h('div', { class: 'grow' }, h('h2', {}, sheet.title), h('p', { class: 'lead', style: { 'margin-bottom': 0 } }, sheet.subtitle))),
    ...sheet.sections.filter((s) => s.text || s.bullets?.length || s.steps?.length).map((s) => [
      h('h3', { class: 'mt' }, s.heading),
      s.text ? h('p', {}, s.text) : null,
      s.bullets?.length ? h('ul', {}, s.bullets.map((t) => h('li', {}, t))) : null,
      s.steps?.length ? h('ol', {}, s.steps.map((t) => h('li', {}, t))) : null,
    ]),
    sheet.helpMissing ? h('p', { class: 'muted no-print' }, 'Add your company\'s phone and email in Settings so they print here.') : null,
    h('p', { class: 'tiny muted mt' }, `Fingerprint of the approved setup: ${sheet.fingerprint}`));
  const delivered = c.delivered;
  const note = h('textarea', { rows: 2, id: 'deliver-note', placeholder: 'Who received it, and how (optional)' });
  return h('div', { class: 'col' }, sheetEl,
    h('div', { class: 'card no-print' }, delivered ? h('div', { class: 'notice ok', id: 'delivered-note' }, icon('check'), h('div', {}, h('b', {}, `Handed over ${when(delivered.at)} by ${delivered.by.name}`), delivered.note ? h('div', {}, delivered.note) : null))
      : h('div', {}, h('h2', {}, 'Record the hand-over'), h('p', { class: 'lead' }, 'When the customer has everything, mark it as handed over. Print the sheet first if they need it on paper.'), note,
        h('div', { class: 'row mt-s' }, h('button', { class: 'btn', type: 'button', onclick: () => window.print() }, icon('print', 's'), 'Print the sheet'),
          ctx.can.deliver ? h('button', { class: 'btn primary', id: 'deliver', type: 'button', onclick: async () => { try { await post(`/api/customers/${ctx.id}/deliver`, { note: note.value }); flash('Recorded.'); location.reload(); } catch (e) { toast(e.message, 'bad'); } } }, 'Mark as handed over') : null))));
}
