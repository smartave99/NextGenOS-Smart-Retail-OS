// The "Licence" step: the customer's licence from the Licence Studio, in plain words. Which plan, whether it is a trial or paid, what happens when it ends, which PCs use it and when they
// last checked in, how many times a PC was moved this year, and (by the staff member's role in this Studio) the few things staff may do: free a PC, extend a trial, turn a trial into a
// paid licence, switch a licence off and on again. The activation key is hidden until a person presses Show, so it can be handed to the customer.
// The Licence Studio makes and keeps the licences; this page only asks it and shows what it answers.
import { h, icon, toast, ago, when, sheet, confirmSheet } from '../dom.js';
import { get, post } from '../api.js';

export const title = () => 'Licence';

const day = (iso) => (iso ? new Date(iso).toLocaleDateString(undefined, { day: 'numeric', month: 'short', year: 'numeric' }) : '');
const KEY_SHOWN_MS = 60_000;

/** Asks for one typed answer in a sheet (a reason, a number of days). Resolves to the text, or null when the person cancels. */
function ask({ title: heading, text, label, number = false, value = '', yes = 'Continue', danger = false }) {
  return new Promise((resolve) => {
    let answered = false;
    const input = number ? h('input', { type: 'number', id: 'licence-ask', value, min: '1', max: '90', inputmode: 'numeric' }) : h('textarea', { id: 'licence-ask', rows: 3, maxlength: '200' });
    const finish = (v, close) => { answered = true; close(); resolve(v); };
    const s = sheet((close) => h('div', {}, h('h2', {}, heading), h('p', { class: 'muted mt-s' }, text), h('div', { class: 'field mt' }, h('label', { for: 'licence-ask' }, label), input),
      h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', id: 'licence-ask-no', onclick: () => finish(null, close) }, 'Cancel'),
        h('button', { class: 'btn primary' + (danger ? ' danger' : ''), type: 'button', id: 'licence-ask-yes', onclick: () => finish(input.value, close) }, yes))));
    new MutationObserver(() => { if (!document.body.contains(s.el) && !answered) { answered = true; resolve(null); } }).observe(document.body, { childList: true, subtree: true });
  });
}

/** Puts text on the clipboard; the page of the Studio is on this PC only, which the browser counts as safe for this. */
async function copyText(text) {
  try { await navigator.clipboard.writeText(text); return true; } catch { /* an older way, below */ }
  const box = h('textarea', { style: { position: 'fixed', opacity: '0' } }); box.value = text; document.body.append(box); box.select();
  let done = false;
  try { done = document.execCommand('copy'); } catch { done = false; }
  box.remove();
  return done;
}

export async function render(ctx) {
  const c = ctx.customer;
  const base = `/api/customers/${encodeURIComponent(ctx.id)}/licences`;
  const box = h('div', { class: 'col', id: 'licence-step' });
  let model = null;
  const timers = new Set();

  const load = async () => { model = await get(base); draw(); };
  const lookAgain = async () => { try { await load(); } catch (e) { toast(e.message, 'bad'); } };
  /** Does one thing to a licence (the answer is the page, as it is now) and says so. */
  const act = async (event, path, body, done) => {
    const b = event?.currentTarget; b?.classList.add('busy');
    try { model = await post(`${base}/${path}`, body ?? {}); draw(); toast(done); } catch (e) { toast(e.message, 'bad'); b?.classList.remove('busy'); }
  };

  function keyRow(l) {
    const out = h('span', { id: `licence-key-${l.lid}`, 'data-shown': 'no', style: { 'font-family': 'var(--ngos-mono)', 'word-break': 'break-all' } }, l.keyMasked || 'Hidden');
    if (!model.can.key) return h('div', {}, out, h('div', { class: 'small muted' }, 'Only a reviewer or an administrator can show the key.'));
    if (!l.keyHeld) return h('div', {}, out, h('div', { class: 'small muted', 'data-key-missing': l.lid }, 'This PC does not hold the whole key. The Licence Studio shows a key only once, when the licence is made, so look for it in the Licence Studio.'));
    let shown = null;
    let timer = null;
    const copy = h('button', { class: 'btn small', type: 'button', id: `licence-copy-${l.lid}`, disabled: true, onclick: async () => { if (shown && await copyText(shown)) toast('Copied. Give it to the customer; it is not kept in this page.'); else toast('The key could not be copied. Select it and copy it by hand.', 'bad'); } }, icon('doc', 's'), 'Copy');
    const toggle = h('button', { class: 'btn small', type: 'button', id: `licence-show-${l.lid}`, onclick: async () => {
      if (shown) { hide(); return; }
      try {
        shown = (await post(`${base}/${encodeURIComponent(l.lid)}/key`)).key;
        out.textContent = shown; out.dataset.shown = 'yes'; toggle.textContent = 'Hide'; copy.disabled = false;
        timer = setTimeout(hide, KEY_SHOWN_MS); timers.add(timer);
      } catch (e) { toast(e.message, 'bad'); }
    } }, icon('eye', 's'), 'Show');
    function hide() { shown = null; clearTimeout(timer); out.textContent = l.keyMasked || 'Hidden'; out.dataset.shown = 'no'; toggle.replaceChildren(icon('eye', 's'), 'Show'); copy.disabled = true; }
    return h('div', {}, out, h('div', { class: 'row wrap mt-s' }, toggle, copy, h('span', { class: 'small muted' }, 'Shown for one minute. Give it to the customer: they type it when they first start the program.')));
  }

  function pcsList(l) {
    if (!l.devices.length) return h('p', { class: 'small muted', 'data-no-pcs': l.lid }, 'No PC has started with this licence yet.');
    const exhausted = l.moves.used >= l.moves.allowed && !model.can.admin;
    return h('div', { class: 'col', 'data-pcs': l.lid }, l.devices.map((d) => h('div', { class: 'row wrap', 'data-pc': d.id, style: { 'align-items': 'center', padding: '10px 0', 'border-top': '1px solid var(--ngos-line)' } },
      h('div', { class: 'grow' }, h('b', {}, d.label), h('div', { class: 'small muted' },
        `Started ${d.activatedAt ? day(d.activatedAt) : 'on a day that is not known'}`, ' · ', 'last check-in ', d.lastCheckIn ? h('span', { title: when(d.lastCheckIn) }, ago(d.lastCheckIn)) : 'not yet', d.version ? ` · version ${d.version}` : '')),
      model.can.manage ? h('button', { class: 'btn small', type: 'button', 'data-free': d.id, disabled: exhausted || undefined, title: exhausted ? 'All the moves of this year are used. An administrator can still free a PC.' : '', onclick: async (e) => {
        const why = await ask({ title: `Free ${d.label}?`, text: `${d.label} will stop working with this licence, and the licence can then be used on another PC. This counts as one of the ${l.moves.allowed} moves a year the customer is allowed (${l.moves.used} used). It is written in the activity record.`, label: 'Why is this PC being freed?', yes: 'Free this PC' });
        if (why !== null) act(e, `${encodeURIComponent(l.lid)}/devices/${encodeURIComponent(d.id)}/free`, { reason: why }, `${d.label} is freed.`);
      } }, 'Free this PC') : null)));
  }

  function licenceCard(l) {
    const w = l.words;
    const buttons = [];
    if (model.can.manage && l.trial) {
      buttons.push(h('button', { class: 'btn', type: 'button', 'data-extend': l.lid, onclick: async (e) => {
        const days = await ask({ title: 'Extend the trial', text: 'The trial goes on for the days you add. It is written in the activity record.', label: 'Days to add (1 to 90)', number: true, value: '7', yes: 'Extend' });
        if (days !== null) act(e, `${encodeURIComponent(l.lid)}/extend`, { days: Number(days) }, 'The trial is extended.');
      } }, 'Extend the trial'));
      buttons.push(h('button', { class: 'btn', type: 'button', 'data-convert': l.lid, onclick: async (e) => {
        if (await confirmSheet({ title: 'Turn this trial into a paid licence?', text: 'It stops being a trial and has no end date. Do this when the customer has paid.', yes: 'Make it a paid licence' })) act(e, `${encodeURIComponent(l.lid)}/convert`, {}, 'It is a paid licence now.');
      } }, 'Turn into a paid licence'));
    }
    if (model.can.admin && !w.off) {
      buttons.push(h('button', { class: 'btn danger', type: 'button', 'data-revoke': l.lid, onclick: async (e) => {
        const why = await ask({ title: 'Switch this licence off?', text: 'The customer\'s PCs stop being allowed to run the program when they next check in with the Licence Studio. That is not at once: it can take some days. It is written in the activity record.', label: 'Why is it being switched off?', yes: 'Switch it off', danger: true });
        if (why !== null) act(e, `${encodeURIComponent(l.lid)}/revoke`, { reason: why }, 'The licence is switched off.');
      } }, 'Switch off'));
    }
    if (model.can.admin && w.off) {
      buttons.push(h('button', { class: 'btn', type: 'button', 'data-restore': l.lid, onclick: async (e) => {
        if (await confirmSheet({ title: 'Switch this licence on again?', text: 'The customer\'s PCs are allowed to run the program again.', yes: 'Switch it on again' })) act(e, `${encodeURIComponent(l.lid)}/restore`, {}, 'The licence is on again.');
      } }, 'Switch on again'));
    }
    return h('div', { class: 'card', id: `licence-${l.lid}`, 'data-lid': l.lid },
      h('div', { class: 'row wrap' }, h('div', { class: 'grow' }, h('h2', {}, l.plan ? `Plan: ${l.plan}` : 'Licence'), h('p', { class: 'small muted', style: { margin: '2px 0 0' } }, `Licence ${l.lid}`)),
        h('span', { class: 'pill' + (w.tone ? ' ' + w.tone : ''), 'data-status': l.status }, w.state), l.trial ? h('span', { class: 'pill warn' }, 'Trial') : null),
      h('dl', { class: 'kv mt' },
        h('dt', {}, 'Kind'), h('dd', { 'data-kind': '' }, w.kind),
        h('dt', {}, 'When it ends'), h('dd', {}, h('span', { 'data-ends': '' }, w.whenItEnds), h('div', { class: 'small muted' }, 'This is what the licence says. A shop program follows it only if its version knows the rule; an older one may still stop at an end date.')),
        h('dt', {}, 'PCs'), h('dd', { 'data-pcs-words': '' }, w.pcs),
        h('dt', {}, 'Moves'), h('dd', {}, h('span', { 'data-moves': '' }, w.moves), h('div', { class: 'small muted' }, `A customer may free an old PC for a new one ${l.moves.allowed} times ${l.moves.windowDays === 365 ? 'a year' : `in ${l.moves.windowDays} days`}. More needs staff.`)),
        h('dt', {}, 'Activation key'), h('dd', {}, keyRow(l))),
      h('h3', { class: 'mt' }, 'PCs in use'), pcsList(l),
      buttons.length ? h('div', { class: 'row wrap mt' }, buttons) : (!model.can.manage ? h('p', { class: 'small muted mt', id: 'licence-role-note' }, 'Your role can look at the licence. A reviewer or an administrator can change it.') : null));
  }

  function draw() {
    for (const t of timers) clearTimeout(t);
    timers.clear();
    const nodes = [];
    const intro = [h('h2', {}, 'Licence'),
      h('p', { class: 'lead' }, `${c.name}'s licence says which PCs may run their Smart Retail POS and what happens when it ends. It is made and kept by the Licence Studio; this page asks it and shows what it answers. The key that signs licences never comes to this Studio.`)];
    if (!model.service.ready) {
      intro.push(h('div', { class: 'notice warn', id: 'licence-not-connected' }, icon('warn'), h('div', {}, model.service.why, model.can.connect ? [' ', h('a', { href: '#/settings', id: 'licence-open-connect' }, 'Open Settings')] : ' Ask an administrator.')));
    } else if (model.problem) {
      intro.push(h('div', { class: 'notice warn', id: 'licence-problem' }, icon('warn'), h('div', {}, model.problem)), h('div', { class: 'row mt' }, h('button', { class: 'btn', type: 'button', id: 'licence-again', onclick: lookAgain }, icon('refresh', 's'), 'Look again')));
    }
    const e = model.expected;
    if (e) {
      intro.push(h('div', { class: 'mt', id: 'licence-expected' }, h('b', {}, 'What the approved setup asks for'),
        e.ok ? h('p', { class: 'small', style: { margin: '4px 0 0' } }, `From release ${e.release}: ${e.words}.`) : h('div', { class: 'notice warn mt-s', id: 'licence-expected-problem' }, icon('warn'), e.problem)));
    }
    nodes.push(h('div', { class: 'card' }, ...intro));
    if (model.service.ready && !model.problem) {
      if (!model.licences.length) {
        nodes.push(h('div', { class: 'card', id: 'licence-none' }, h('h2', {}, 'No licence yet'),
          h('p', { class: 'lead', style: { 'margin-bottom': 0 } }, 'The Licence Studio has no licence for this customer. It is asked for once, when you press the build button in "Website and app". Or make it in the Licence Studio yourself.'),
          h('div', { class: 'row mt' }, h('a', { class: 'btn', href: `#/customers/${ctx.id}/site`, id: 'licence-to-site' }, 'Go to "Website and app"'))));
      }
      for (const l of model.licences) nodes.push(licenceCard(l));
    }
    box.replaceChildren(...nodes);
  }

  await load();
  return box;
}
