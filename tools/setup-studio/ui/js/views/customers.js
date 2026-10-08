import { h, icon, sheet, toast, ago } from '../dom.js';
import { get, post } from '../api.js';
import { app, go, refreshCounts } from '../main.js';

export const title = () => 'Customers';
const STATE = { draft: 'Details', proposed: 'Prepared', review: 'In review', approved: 'Approved', built: 'Installer ready', delivered: 'Handed over' };
export const statePill = (c) => h('span', { class: 'pill ' + (c.stale ? 'draft' : c.state) }, h('i', { class: 'dot' }), c.stale ? 'Needs updating' : STATE[c.state] ?? c.state);
const FILTERS = [['all', 'All'], ['work', 'Needs work'], ['review', 'In review'], ['done', 'Approved or handed over']];
const inFilter = (f, c) => f === 'all' || (f === 'work' && ['draft', 'proposed'].includes(c.state)) || (f === 'review' && c.state === 'review') || (f === 'done' && ['approved', 'built', 'delivered'].includes(c.state));

const READY_WORD = { ready: 'There', trial: 'Only to try', partly: 'Only one system', missing: 'Not there yet', problem: 'Needs fixing', 'not-built': 'Not in this version' };

/** What the Studio still needs before it can give a customer their outputs: plain words, so nobody wonders why nothing came out. */
function readinessCard(r) {
  if (!r || r.allReady) return null;
  return h('div', { class: 'card', id: 'readiness' },
    h('h2', {}, 'Before the Studio can give a customer their outputs'),
    h('p', { class: 'lead' }, 'The Studio keeps each customer\'s details and look and puts their setup together. It does not build programs. The shop program and the website program come ready-made with a NextGenOS release, and the Studio puts each customer\'s settings beside them on this PC. The Android app is made elsewhere (on GitHub) and brought here. This is what is there, and what is not.'),
    h('div', { class: 'col mt-s' }, r.items.map((i) => h('div', { class: 'row', 'data-readiness': i.id, 'data-state': i.state, style: { 'align-items': 'flex-start', 'padding': '8px 0', 'border-top': '1px solid var(--ngos-line)' } },
      h('span', { class: i.state === 'ready' ? 'tone-ok' : 'tone-warn', style: { 'margin-top': '2px' } }, icon(i.state === 'ready' ? 'check' : 'warn', 's')),
      h('div', { class: 'grow' }, h('b', {}, i.title), h('div', { class: 'small muted' }, i.text)),
      h('span', { class: 'pill' + (i.state === 'ready' ? ' ok' : ' warn') }, READY_WORD[i.state] ?? i.state)))),
    app.can.settings ? h('div', { class: 'row mt' }, h('a', { class: 'btn', href: '#/settings', id: 'readiness-settings' }, 'Open Settings')) : h('p', { class: 'small muted mt-s' }, 'An administrator does these in Settings.'));
}

export async function render() {
  const { customers } = await get('/api/customers');
  const readiness = await get('/api/readiness').catch(() => null);
  const countries = Object.fromEntries(app.options.countries.map((c) => [c.code, c.name]));
  const kinds = Object.fromEntries(app.options.industries.map((i) => [i.id, i.name]));
  let filter = 'all', query = '';
  const list = h('div', { class: 'panel' });
  const draw = () => {
    const shown = customers.filter((c) => inFilter(filter, c) && (!query || `${c.name} ${countries[c.country] ?? ''} ${kinds[c.industry] ?? ''}`.toLowerCase().includes(query)));
    list.replaceChildren(...(shown.length ? [h('div', { class: 'list' }, shown.map((c) => h('a', { class: 'item', href: `#/customers/${c.id}`, 'data-customer': c.id },
      h('div', { class: 'avatar' }, (c.name || '?').slice(0, 2).toUpperCase()),
      h('div', { class: 'grow' }, h('div', { class: 'name' }, c.name), h('div', { class: 'meta' }, [countries[c.country], kinds[c.industry], c.latestRelease ? `Release ${c.latestRelease}` : null].filter(Boolean).join(' · '))),
      h('div', { class: 'meta right' }, c.updatedAt ? `Changed ${ago(c.updatedAt)}${c.updatedBy ? ' by ' + c.updatedBy.name : ''}` : ''),
      statePill(c), icon('chevron', 's muted'))))]
      : [h('div', { class: 'empty' }, h('div', { class: 'art' }, icon('store', 'l')), h('h2', {}, customers.length ? 'Nothing matches' : 'No customers yet'),
        h('p', {}, customers.length ? 'Try another word, or another filter.' : 'Add your first customer: type their name, and the Studio helps you from there.'),
        !customers.length && app.can['customer.edit'] ? h('button', { class: 'btn primary mt', type: 'button', onclick: newCustomer }, icon('plus', 's'), 'Add a customer') : null)]));
  };
  const search = h('input', { type: 'search', placeholder: 'Search customers', 'aria-label': 'Search customers', oninput: (e) => { query = e.target.value.trim().toLowerCase(); draw(); } });
  const seg = h('div', { class: 'seg', role: 'group', 'aria-label': 'Show' }, FILTERS.map(([id, label]) => h('button', { type: 'button', 'aria-pressed': String(id === filter), 'data-filter': id, onclick: (e) => { filter = id; for (const b of seg.children) b.setAttribute('aria-pressed', String(b === e.currentTarget)); draw(); } }, label)));
  draw();
  return h('div', { class: 'view' },
    h('div', { class: 'page-head' }, h('div', { class: 'grow' }, h('h1', {}, 'Customers'), h('p', { class: 'sub' }, 'Every business you are setting up, and where each one is.')),
      app.can['customer.edit'] ? h('button', { class: 'btn primary', id: 'new-customer', type: 'button', onclick: newCustomer }, icon('plus', 's'), 'New customer') : null),
    readinessCard(readiness),
    h('div', { class: 'row wrap', style: { 'margin-bottom': '18px' } }, h('div', { class: 'grow', style: { 'max-width': '360px' } }, search), seg), list);
}

function newCustomer() {
  const name = h('input', { type: 'text', id: 'nc-name', placeholder: 'For example, Luzon Fresh Mart', maxlength: '60', autocomplete: 'off' });
  const country = h('select', { id: 'nc-country' }, h('option', { value: '' }, 'Choose a country…'), app.options.countries.map((c) => h('option', { value: c.code }, c.name)));
  const kind = h('select', { id: 'nc-kind' }, h('option', { value: '' }, 'Choose the kind of business…'), app.options.industries.map((i) => h('option', { value: i.id }, i.name)));
  const err = h('div', { class: 'err hidden', role: 'alert' });
  sheet((close) => {
    const create = async (e) => {
      err.classList.add('hidden');
      if (!name.value.trim()) { err.textContent = 'Please type the business\'s name.'; err.classList.remove('hidden'); return; }
      if (!country.value) { err.textContent = 'Please choose the country.'; err.classList.remove('hidden'); return; }
      if (!kind.value) { err.textContent = 'Please choose the kind of business.'; err.classList.remove('hidden'); return; }
      e.currentTarget.classList.add('busy');
      try {
        const r = await post('/api/customers', { intake: { business: { name: name.value, country: country.value, industry: kind.value } } });
        close(); await refreshCounts(); toast(`${r.customer.name} was added.`); go(`/customers/${r.customer.id}/details`);
      } catch (x) { err.textContent = x.message; err.classList.remove('hidden'); e.currentTarget.classList.remove('busy'); }
    };
    return h('div', {}, h('h2', {}, 'New customer'), h('p', { class: 'muted mt-s' }, 'Three quick answers to start. You can fill in the rest on the next screen.'),
      h('div', { class: 'col mt' }, h('div', { class: 'field' }, h('label', { for: 'nc-name' }, 'Business name'), name), h('div', { class: 'field' }, h('label', { for: 'nc-country' }, 'Country'), country, h('span', { class: 'hint' }, 'The country decides the money, the tax and the words on bills.')), h('div', { class: 'field' }, h('label', { for: 'nc-kind' }, 'Kind of business'), kind), err),
      h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', onclick: close }, 'Cancel'), h('button', { class: 'btn primary', id: 'nc-create', type: 'button', onclick: create }, 'Continue')));
  });
}
