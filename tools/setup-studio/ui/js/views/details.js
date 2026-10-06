import { h, icon, getPath, setPath, sheet, toast, ago } from '../dom.js';
import { post } from '../api.js';
import { text, area, select, toggle, seg, cards, section, errorBox } from './form.js';
import { aiSection } from './aiprofile.js';

const TABS = [['business', 'Business'], ['money', 'Bills and money'], ['data', 'Starting data'], ['extras', 'Extras and licence']];
// Puts one piece in a box, or empties it. (replaceChildren(null) would write the word "null" on the page.)
const show = (box, node) => (node ? box.replaceChildren(node) : box.replaceChildren());
const FEATURE_WORDS = { counterSale: ['Sell at the counter', 'Take sales at a till'], tables: ['Tables', 'Seat guests and run tabs'], kitchen: ['Kitchen screen', 'Send orders to a kitchen'], lending: ['Lending', 'Loans, returns and fines'], projects: ['Projects', 'Quotes, progress bills, retention'], appointments: ['Bookings', 'Appointments and visits'], credit: ['Credit accounts', 'Sell on account'], purchases: ['Buying', 'Orders to suppliers and stock in'], weighedItems: ['Weighed items', 'Sell by weight'] };

export async function render(ctx) {
  let tab = sessionStorage.getItem('details-tab') || 'business';
  const body = h('div', { class: 'col' });
  const tabs = h('div', { class: 'seg', role: 'tablist', 'aria-label': 'Details' }, TABS.map(([id, label]) => h('button', { type: 'button', role: 'tab', 'data-tab': id, 'aria-pressed': String(id === tab), onclick: () => { tab = id; try { sessionStorage.setItem('details-tab', id); } catch { /* private */ } for (const b of tabs.children) b.setAttribute('aria-pressed', String(b.dataset.tab === id)); draw(); } }, label)));
  const draw = () => { ctx.drawers.length = 0; ctx.listeners.length = 0; body.replaceChildren(...({ business, money, data, extras }[tab])(ctx)); ctx.redraw(); };
  draw();
  return h('div', { class: 'col' },
    h('div', { class: 'row wrap' }, h('div', { class: 'grow' }, h('h2', {}, 'Details')), tabs),
    ctx.errors.length ? h('div', { class: 'notice warn', id: 'detail-problems' }, icon('warn'), h('div', {}, h('b', {}, 'Before the setup can be prepared:'), h('ul', {}, ctx.errors.slice(0, 6).map((e) => h('li', {}, e.message))))) : null,
    body);
}

// ---------- Business ----------
function business(ctx) {
  const d = ctx.draft;
  const country = () => ctx.opts.countries.find((c) => c.code === d.business.country);
  const regionBox = h('div');
  const taxNote = h('div');
  const drawCountry = () => {
    const c = country();
    regionBox.replaceChildren();
    if (c && c.regions.length > 1) regionBox.append(select(ctx, 'business.region', c.regions, { label: c.regionLabel ?? 'Region', blank: 'The owner chooses while setting up', hint: 'Only needed when tax depends on the place.' }));
    show(taxNote, c && !c.reviewed ? h('div', { class: 'notice warn' }, icon('warn'), h('div', {}, h('b', {}, `The ${c.name} tax rules are not yet checked by a local tax adviser.`), h('div', { class: 'small' }, 'Tell the customer, and have their accountant confirm the rates and bill wording before real bills.'))) : null);
    ctx.redraw();
  };
  const industry = () => ctx.opts.industries.find((i) => i.id === d.business.industry);
  const coverage = h('div');
  const drawIndustry = () => { const i = industry(); show(coverage, i ? h('details', { class: 'more mt-s' }, h('summary', {}, icon('info', 's'), `What works today for ${i.name}`), h('div', { class: 'grid2 mt-s' }, h('div', {}, h('b', {}, 'Works today'), h('ul', {}, i.coverage.works.map((w) => h('li', {}, w)))), h('div', {}, h('b', {}, 'Not built yet'), h('ul', {}, i.coverage.notYet.length ? i.coverage.notYet.map((w) => h('li', {}, w)) : h('li', {}, 'Nothing listed'))))) : null); };
  const reg = h('div');
  const out = [
    section('The business', 'The name customers know it by, and where it is.',
      h('div', { class: 'grid2' }, text(ctx, 'business.name', { label: 'Business name', maxlength: 60, placeholder: 'For example, Luzon Fresh Mart' }), text(ctx, 'business.legalName', { label: 'Registered name (optional)', maxlength: 120, hint: 'If different, for bills.' })),
      h('div', { class: 'grid2 mt-s' }, select(ctx, 'business.country', ctx.opts.countries, { label: 'Country', onChange: () => { setPath(d, 'business.region', ''); drawCountry(); } }), regionBox),
      taxNote, h('div', { class: 'mt-s' }, text(ctx, 'business.tagline', { label: 'A short line about the business (optional)', maxlength: 120 }))),
    section('Kind of business', 'This sets the words, the screens and what the program does for them.',
      cards(ctx, 'business.industry', ctx.opts.industries.map((i) => ({ id: i.id, label: i.name, hint: i.summary })), { minWidth: 230, onChange: drawIndustry }), coverage),
    section('Tax', 'How prices and tax are shown.',
      h('div', { class: 'col' }, toggle(ctx, 'business.taxRegistered', { label: 'Registered for tax', text: 'If off, no tax is charged on bills.' }),
        seg(ctx, 'business.pricesIncludeTax', [{ value: null, label: 'As the country usually does' }, { value: true, label: 'Prices include tax' }, { value: false, label: 'Tax is added on top' }], { label: 'Shelf prices' }))),
    reg,
  ];
  drawCountry(); drawIndustry();
  return out;
}

// ---------- Bills and money ----------
function money(ctx) {
  const d = ctx.draft;
  const ind = ctx.opts.industries.find((i) => i.id === d.business.industry);
  const usual = ind?.paymentMethods ?? ['cash', 'card'];
  const chips = h('div', { class: 'chips', id: 'pay-chips' });
  const add = h('input', { type: 'text', placeholder: 'Add another way, like gcash', maxlength: '20', id: 'pay-add', 'aria-label': 'Add a way of paying' });
  const draw = () => {
    const chosen = d.money.paymentMethods;
    chips.replaceChildren(...chosen.map((m) => h('span', { class: 'chip on' }, m, h('button', { type: 'button', 'aria-label': `Remove ${m}`, onclick: () => { d.money.paymentMethods = chosen.filter((x) => x !== m); draw(); ctx.touch('money.paymentMethods'); } }, icon('x', 's')))),
      ...usual.filter((m) => !chosen.includes(m)).map((m) => h('button', { type: 'button', class: 'chip', onclick: () => { d.money.paymentMethods = [...chosen, m]; draw(); ctx.touch('money.paymentMethods'); } }, icon('plus', 's'), m)));
  };
  const addNow = () => { const v = add.value.trim().toLowerCase(); if (!v) return; if (!d.money.paymentMethods.includes(v) && d.money.paymentMethods.length < 12) d.money.paymentMethods = [...d.money.paymentMethods, v]; add.value = ''; draw(); ctx.touch('money.paymentMethods'); };
  add.addEventListener('keydown', (e) => { if (e.key === 'Enter') { e.preventDefault(); addNow(); } });
  draw();
  return [
    section('Contact and bills', 'Shown on bills and on the help line of the screens.',
      h('div', { class: 'grid2' }, text(ctx, 'business.contact.phone', { label: 'Phone', type: 'tel', maxlength: 40, placeholder: '+63 2 5555 0100' }), text(ctx, 'business.contact.email', { label: 'Email', type: 'email', maxlength: 120 })),
      h('div', { class: 'mt-s' }, area(ctx, 'business.contact.address', { label: 'Address on bills', rows: 2, maxlength: 200 })),
      h('div', { class: 'mt-s' }, text(ctx, 'money.receiptFooter', { label: 'Words at the bottom of a bill', maxlength: 160, placeholder: 'Thank you!', hint: 'Write it in the language of the shop\'s customers.' }))),
    section('Ways of paying', `Tap the ones this shop takes. If you choose none, the usual ones for this kind of business are used: ${usual.join(', ')}.`,
      chips, h('div', { class: 'row mt-s' }, h('div', { class: 'grow', style: { 'max-width': '320px' } }, add), h('button', { class: 'btn', type: 'button', onclick: addNow }, 'Add')), errorBox(ctx, 'money.paymentMethods')),
    section('Rounding', 'Whether the total of a bill is rounded.',
      seg(ctx, 'money.roundTotal', [{ value: null, label: 'As the country usually does' }, { value: true, label: 'Round the total' }, { value: false, label: 'Do not round' }])),
  ];
}

// ---------- Starting data ----------
function data(ctx) {
  const d = ctx.draft;
  const ind = ctx.opts.industries.find((i) => i.id === d.business.industry);
  const countsBox = h('div');
  const drawCounts = () => countsBox.replaceChildren(
    h('div', { class: 'row wrap' }, h('span', { class: 'pill' }, `${d.starter.items.length} item${d.starter.items.length === 1 ? '' : 's'}`), h('span', { class: 'pill' }, `${d.starter.people.length} ${d.starter.people.length === 1 ? 'person' : 'people'}`),
      d.starter.items.length || d.starter.people.length ? h('button', { class: 'btn quiet small', type: 'button', onclick: () => { d.starter = { items: [], people: [] }; drawCounts(); ctx.touch('starter'); } }, 'Clear both') : null));
  drawCounts();
  const importCard = (kind) => h('div', { class: 'card flat' }, h('h3', {}, kind === 'items' ? 'Items' : 'People'), h('p', { class: 'small muted' }, kind === 'items' ? 'A spreadsheet saved as CSV, with columns like Name, Price, Barcode, Unit, Category.' : 'A spreadsheet saved as CSV, with columns like Name, Phone, Email, and Type (customer or supplier).'),
    h('button', { class: 'btn mt-s', type: 'button', 'data-import': kind, onclick: () => importSheet(ctx, kind, ind, drawCounts) }, icon('upload', 's'), 'Bring in a list'));
  // words
  const terms = Object.keys(ind?.vocabulary ?? {});
  const wordsBox = h('div', { class: 'col' }, terms.map((t) => {
    const [one, many] = ind.vocabulary[t];
    const cur = d.words[t] ?? ['', ''];
    const set = (i, v) => { const w = [...(d.words[t] ?? ['', ''])]; w[i] = v; if (!w[0] && !w[1]) delete d.words[t]; else d.words[t] = w; ctx.touch('words'); };
    return h('div', { class: 'grid3', style: { 'align-items': 'center' } }, h('div', {}, h('b', {}, t[0].toUpperCase() + t.slice(1)), h('div', { class: 'tiny muted' }, `Now "${one}" / "${many}"`)),
      h('input', { type: 'text', value: cur[0], placeholder: one, maxlength: '30', 'aria-label': `${t}, one`, 'data-word': t + '-one', oninput: (e) => set(0, e.target.value) }), h('input', { type: 'text', value: cur[1], placeholder: many, maxlength: '30', 'aria-label': `${t}, many`, 'data-word': t + '-many', oninput: (e) => set(1, e.target.value) }));
  }));
  // parts
  const featBox = h('div', { class: 'grid2' }, Object.keys(FEATURE_WORDS).map((f) => {
    const def = !!ind?.features?.[f];
    const input = h('input', { type: 'checkbox', checked: f in d.features ? d.features[f] : def, 'data-feature': f, onchange: (e) => { if (e.target.checked === def) delete d.features[f]; else d.features[f] = e.target.checked; ctx.touch('features'); } });
    return h('label', { class: 'switch' }, input, h('span', { class: 'track' }), h('span', { class: 'text' }, h('b', {}, FEATURE_WORDS[f][0]), h('span', {}, FEATURE_WORDS[f][1] + (def ? ' · on for this kind of business' : ''))));
  }));
  return [
    section('First items and people', 'Bring in what the shop already has, so it starts with its own list. The owner can add more later.', countsBox, h('div', { class: 'grid2 mt-s' }, importCard('items'), importCard('people')),
      h('p', { class: 'hint mt-s' }, 'Only how many there are is ever shown to an AI tool, never the names.')),
    section('Their own words', 'If the shop says "Suki" for a customer or "Dish" for an item, type it here. Leave empty to keep the usual word.', wordsBox),
    section('What the program does', 'Switch parts on or off. The screens show only what is on.', featBox),
  ];
}

function importSheet(ctx, kind, ind, done) {
  const d = ctx.draft;
  const ta = h('textarea', { id: 'import-text', rows: 7, placeholder: 'Paste the list here, or choose a file below.', 'aria-label': 'List' });
  const file = h('input', { type: 'file', accept: '.csv,text/csv,text/plain', id: 'import-file' });
  const result = h('div', { id: 'import-result' });
  let found = null;
  const check = async () => {
    result.replaceChildren(h('p', { class: 'muted' }, 'Reading…'));
    try {
      found = await post('/api/import', { kind, csv: ta.value, industry: d.business.industry });
      result.replaceChildren(
        found.count ? h('div', { class: 'notice ok' }, icon('check'), h('div', {}, h('b', {}, `${found.count} ${kind === 'items' ? 'item' : 'people'}${found.count === 1 && kind === 'items' ? '' : kind === 'items' ? 's' : ''} understood.`), h('div', { class: 'small' }, 'Columns used: ' + Object.entries(found.columns).map(([f, c]) => `${c} → ${f}`).join(', ')))) : null,
        found.problems.length ? h('div', { class: 'notice warn mt-s' }, icon('warn'), h('div', {}, h('b', {}, 'Left out'), h('ul', {}, found.problems.map((p) => h('li', {}, p))))) : null,
        found.count ? h('div', { class: 'panel mt-s' }, h('table', { class: 'tbl' }, h('tbody', {}, found.rows.slice(0, 5).map((r) => h('tr', {}, h('td', {}, r.name), h('td', { class: 'muted' }, r.price ?? r.kind ?? ''), h('td', { class: 'muted' }, r.phone ?? r.barcode ?? ''))), found.count > 5 ? h('tr', {}, h('td', { class: 'muted', colspan: 3 }, `… and ${found.count - 5} more`)) : null))) : null);
    } catch (e) { result.replaceChildren(h('div', { class: 'err' }, icon('warn', 's'), e.message)); }
  };
  file.addEventListener('change', async () => { const f = file.files[0]; if (!f) return; if (f.size > 3_000_000) { toast('That file is too big. Use a list of up to 2000 lines.', 'bad'); return; } ta.value = await f.text(); check(); });
  sheet((close) => h('div', {}, h('h2', {}, kind === 'items' ? 'Bring in items' : 'Bring in people'), h('p', { class: 'muted mt-s' }, 'The first line has the column names. The Studio finds the right columns by itself.'),
    h('div', { class: 'col mt' }, ta, h('div', { class: 'row' }, h('label', { class: 'btn', for: 'import-file' }, icon('upload', 's'), 'Choose a file'), file, h('button', { class: 'btn', type: 'button', id: 'import-check', onclick: check }, 'Check the list')), result),
    h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', onclick: close }, 'Cancel'),
      h('button', { class: 'btn primary', type: 'button', id: 'import-add', onclick: () => { if (!found?.count) { toast('Check the list first.', 'bad'); return; } d.starter[kind === 'items' ? 'items' : 'people'] = found.rows; close(); done(); ctx.touch('starter'); toast(`${found.count} added. Save to keep them.`); } }, 'Use this list'))), { wide: true });
}

// ---------- Extras and licence ----------
function extras(ctx) {
  const d = ctx.draft;
  const site = h('div'); const app = h('div');
  const drawSite = () => show(site, d.ecosystem.website.wanted ? text(ctx, 'ecosystem.website.domain', { label: 'Website name', placeholder: 'shop.example.com', hint: 'Without https:// and without a slash.' }) : null);
  const drawApp = () => show(app, d.ecosystem.android.wanted ? text(ctx, 'ecosystem.android.appId', { label: 'App id', placeholder: 'com.yourshop.app', hint: 'Small letters, at least three parts separated by dots.' }) : null);
  drawSite(); drawApp();
  // The AI assistant's own settings (who the model photos show, festivals, a second language) are shown only when the customer gets the assistant.
  const ai = h('div', { id: 'ai-profile-holder' });
  let aiBuilt = false;
  const drawAi = () => { const wanted = ctx.draft.ecosystem.aiAddon.wanted; if (wanted && !aiBuilt) { ai.append(aiSection(ctx)); aiBuilt = true; } ai.hidden = !wanted; };
  drawAi();
  const level = () => ctx.opts.options.whiteLabel.find((l) => l.id === d.licence.whiteLabel);
  return [
    section('The rest of the ecosystem', 'Does this customer also get a website and a phone app?',
      h('div', { class: 'grid2' }, h('div', { class: 'col' }, toggle(ctx, 'ecosystem.website.wanted', { label: 'A website', text: 'An online shop for their products', onChange: drawSite }), site),
        h('div', { class: 'col' }, toggle(ctx, 'ecosystem.android.wanted', { label: 'An Android app', text: 'Opens their website as an app', onChange: drawApp }), app)),
      h('div', { class: 'mt-s' }, toggle(ctx, 'ecosystem.aiAddon.wanted', { label: 'The AI assistant (Windows)', text: 'Answers questions about sales and stock, and makes product photos and sale posters. It reads the Windows POS database, not yet the new program\'s own data.', onChange: drawAi }))),
    ai,
    section('What their licence will allow', 'How much of the look the owner can change on their own. This is what you choose when you make their licence.',
      cards(ctx, 'licence.whiteLabel', ctx.opts.options.whiteLabel, { minWidth: 230 }),
      h('div', { class: 'mt-s', style: { 'max-width': '240px' } }, text(ctx, 'licence.seats', { label: 'Number of PCs', type: 'number', inputmode: 'numeric' }))),
    section('Notes', 'Anything the next person should know.', area(ctx, 'notes', { rows: 5, maxlength: 4000, placeholder: 'For example: opens at 8, sells mostly rice and canned goods, wants the screens in warm colours.', hint: 'If you use an AI tool to improve the setup, these notes are shown to it. Do not write phone numbers, passwords or other private things here.' })),
  ];
}
