// The hand-over sheet: what the customer gets, how to put it in place, what their licence allows, and who to call. It prints cleanly. Then the hand-over is recorded.
import { h, icon, toast, flash, when, sheet } from '../dom.js';
import { get, post } from '../api.js';

const OS = { windows: 'Windows 10 or 11 (64-bit)', linux: 'Ubuntu 22.04 or 24.04, Linux Mint 21 or later, Debian 12 or later' };

export async function render(ctx) {
  const c = ctx.customer;
  const release = c.releases.at(-1);
  if (!release) return h('div', { class: 'empty' }, h('h2', {}, 'Nothing to hand over yet'), h('p', {}, 'Approve a setup first.'));
  const { company } = await get('/api/settings');
  const i = ctx.draft;
  const level = ctx.opts.options.whiteLabel.find((l) => l.id === i.licence.whiteLabel);
  const device = ctx.opts.options.deviceKinds.find((d) => d.id === i.device.kind);
  const printer = ctx.opts.options.printers.find((p) => p.id === i.device.printer);
  const country = ctx.opts.countries.find((x) => x.code === i.business.country);
  const industry = ctx.opts.industries.find((x) => x.id === i.business.industry);
  const contact = [company.supportPhone, company.supportEmail, company.website].filter(Boolean);
  const sheetEl = h('div', { class: 'card', id: 'handover-sheet' },
    h('div', { class: 'row' }, h('div', { class: 'grow' }, h('h2', {}, `${i.business.name}: your Smart Retail POS`), h('p', { class: 'lead', style: { 'margin-bottom': 0 } }, `Prepared ${when(release.approvedAt)} · setup release ${release.n}${company.name ? ' · ' + company.name : ''}`))),
    h('h3', { class: 'mt' }, 'What you are getting'),
    h('ul', {}, h('li', {}, `${industry?.name ?? ''} for ${country?.name ?? ''}, set up with ${i.business.name}'s own look, words and settings.`),
      h('li', {}, `For a ${device?.label.toLowerCase() ?? 'computer'} running ${OS[i.device.os] ?? i.device.os}.`),
      i.starter.items.length || i.starter.people.length ? h('li', {}, `Your first ${[i.starter.items.length && i.starter.items.length + ' items', i.starter.people.length && i.starter.people.length + ' people'].filter(Boolean).join(' and ')} are already in.`) : null,
      i.ecosystem.website.wanted ? h('li', {}, `Your website${i.ecosystem.website.domain ? ': ' + i.ecosystem.website.domain : ''}.`) : null,
      i.ecosystem.android.wanted ? h('li', {}, 'Your Android app.') : null),
    h('h3', { class: 'mt' }, 'Putting it in place'),
    h('ol', {}, h('li', {}, 'Run the setup file on the shop computer. It installs everything it needs; nothing has to be installed first.'),
      h('li', {}, 'Open the program in the browser window it shows. The first time, type the licence key you were given.'),
      h('li', {}, 'Your business details are already filled in. Check them, choose your own sign-in name and password, and finish.'),
      i.device.printer !== 'none' ? h('li', {}, `Connect the ${printer?.label.toLowerCase()}, then open Settings → Devices to choose it.`) : null,
      h('li', {}, 'Make your first sale to try it.')),
    h('h3', { class: 'mt' }, 'What your licence allows'),
    h('p', {}, h('b', {}, level?.label ?? ''), ': ' + (level?.hint ?? ''), i.licence.seats > 1 ? ` Up to ${i.licence.seats} computers.` : ''),
    h('h3', { class: 'mt' }, 'Need help?'),
    contact.length ? h('p', {}, contact.join(' · ')) : h('p', { class: 'muted no-print' }, 'Add your company\'s phone and email in Settings so they print here.'),
    h('p', { class: 'tiny muted mt' }, `Fingerprint of the approved setup: ${release.bundleHash.slice(0, 16)}`));
  const delivered = c.delivered;
  const note = h('textarea', { rows: 2, id: 'deliver-note', placeholder: 'Who received it, and how (optional)' });
  return h('div', { class: 'col' }, sheetEl,
    h('div', { class: 'card no-print' }, delivered ? h('div', { class: 'notice ok', id: 'delivered-note' }, icon('check'), h('div', {}, h('b', {}, `Handed over ${when(delivered.at)} by ${delivered.by.name}`), delivered.note ? h('div', {}, delivered.note) : null))
      : h('div', {}, h('h2', {}, 'Record the hand-over'), h('p', { class: 'lead' }, 'When the customer has everything, mark it as handed over. Print the sheet first if they need it on paper.'), note,
        h('div', { class: 'row mt-s' }, h('button', { class: 'btn', type: 'button', onclick: () => window.print() }, icon('print', 's'), 'Print the sheet'),
          ctx.can.deliver ? h('button', { class: 'btn primary', id: 'deliver', type: 'button', onclick: async () => { try { await post(`/api/customers/${ctx.id}/deliver`, { note: note.value }); flash('Recorded.'); location.reload(); } catch (e) { toast(e.message, 'bad'); } } }, 'Mark as handed over') : null))));
}
void sheet;
