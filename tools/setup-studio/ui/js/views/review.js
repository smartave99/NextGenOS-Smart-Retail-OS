// A second person checks and approves. The page says who prepared it, what is fine, what to look at, and what approval does.
import { h, icon, toast, flash, sheet, when, download, confirmSheet } from '../dom.js';
import { post, api } from '../api.js';

export async function render(ctx) {
  const c = ctx.customer;
  const p = c.proposal;
  const me = ctx.app.me;
  const box = h('div', { class: 'col' });
  if (!p) return h('div', { class: 'empty' }, h('h2', {}, 'Nothing to review yet'), h('p', {}, 'Prepare the setup first.'));
  const checks = [
    [c.check.complete, 'The details are complete', 'Some details are missing'],
    [!c.stale, 'The setup matches the details', 'The details changed after the setup was prepared'],
    [!p.problems?.length, 'Everything in the setup is understood by the program', `${p.problems?.length ?? 0} thing(s) were left out, put back or kept as they were (listed below)`],
  ];
  const warnings = [...c.check.warnings.map((w) => w.message)];
  box.append(h('div', { class: 'card' }, h('h2', {}, 'Before it is approved'),
    h('div', { class: 'col mt-s', id: 'checklist' }, checks.map(([ok, yes, no]) => h('div', { class: 'row' }, icon(ok ? 'check' : 'warn', 's'), h('span', { style: { color: ok ? 'var(--ngos-ok)' : 'var(--ngos-warn)' } }, ok ? yes : no)))),
    p.problems?.length ? h('div', { class: 'notice warn mt', id: 'review-problems' }, icon('warn'), h('div', {}, h('b', {}, 'What was left out or kept'), h('ul', {}, p.problems.map((t) => h('li', {}, t))))) : null,
    warnings.length ? h('div', { class: 'notice warn mt', id: 'review-warnings' }, icon('warn'), h('div', {}, h('b', {}, 'Things to know'), h('ul', {}, warnings.map((w) => h('li', {}, w))))) : null));
  box.append(h('div', { class: 'card' }, h('h2', {}, 'Who did what'),
    h('dl', { class: 'kv mt-s' }, h('dt', {}, 'Prepared by'), h('dd', {}, `${p.preparedBy?.name ?? '—'} · ${when(p.preparedAt)}`), c.review ? [h('dt', {}, 'Sent for approval by'), h('dd', {}, `${c.review.submittedBy.name} · ${when(c.review.submittedAt)}`)] : null,
      c.releases.length ? [h('dt', {}, 'Approved by'), h('dd', { id: 'approved-by' }, `${c.releases.at(-1).approvedBy.name} · ${when(c.releases.at(-1).approvedAt)}${c.releases.at(-1).selfApproved ? ' (approved by the person who prepared it, with a reason)' : ''}`)] : null),
    h('p', { class: 'small muted mt-s' }, 'The person who prepared or sent a setup cannot approve it. Approval makes a numbered release that never changes; installers are made from a release.')));

  const actions = h('div', { class: 'row wrap' });
  if (c.state === 'proposed' && ctx.can['review.submit']) actions.append(h('button', { class: 'btn primary', id: 'submit', type: 'button', onclick: async (e) => { e.currentTarget.classList.add('busy'); try { await post(`/api/customers/${ctx.id}/submit`); flash('Sent for approval.'); location.reload(); } catch (x) { toast(x.message, 'bad'); e.currentTarget.classList.remove('busy'); } } }, icon('flag', 's'), 'Send for approval'));
  if (c.state === 'review' && ctx.can['review.decide']) {
    const mine = p.preparedBy?.id === me.id || c.review?.submittedBy?.id === me.id;
    actions.append(
      h('button', { class: 'btn primary', id: 'approve', type: 'button', onclick: () => approve(ctx, mine) }, icon('check', 's'), 'Approve'),
      h('button', { class: 'btn', id: 'reject', type: 'button', onclick: () => reject(ctx) }, 'Send back…'),
      mine ? h('span', { class: 'small muted' }, 'You prepared this yourself' + (ctx.can.override ? ', so you must say why you approve it.' : ', so someone else must approve it.')) : null);
  }
  if (c.state === 'review' && !ctx.can['review.decide']) actions.append(h('div', { class: 'notice' }, icon('clock'), 'Waiting for a reviewer to approve this.'));
  if (actions.children.length) box.append(h('div', { class: 'card' }, actions));

  if (c.releases.length) {
    const fetchZip = async (n) => { try { const res = await api('GET', `/api/customers/${ctx.id}/releases/${n}/profile.zip`, undefined, { raw: true }); download(await res.blob(), `${ctx.id}-profile-${n}.zip`); } catch (x) { toast(x.message, 'bad'); } };
    const rows = [...c.releases].reverse().map((r) => h('tr', {},
      h('td', {}, h('b', {}, `Release ${r.n}`)), h('td', { class: 'muted' }, when(r.approvedAt)), h('td', {}, r.approvedBy.name),
      h('td', { class: 'tiny muted', style: { 'font-family': 'var(--ngos-mono)' } }, r.bundleHash.slice(0, 12)),
      h('td', { class: 'right' }, h('button', { class: 'btn small', type: 'button', 'data-download': r.n, onclick: () => fetchZip(r.n) }, icon('download', 's'), 'Setup files'))));
    const head = h('thead', {}, h('tr', {}, ['Release', 'Approved', 'By', 'Fingerprint', ''].map((t) => h('th', {}, t))));
    box.append(h('div', { class: 'card' }, h('h2', {}, 'Approved releases'), h('div', { class: 'panel mt-s' }, h('table', { class: 'tbl', id: 'releases' }, head, h('tbody', {}, rows)))));
  }
  return box;
}

function approve(ctx, mine) {
  const reason = h('textarea', { id: 'override-reason', rows: 3, placeholder: 'For example: I am the only person in the office today, and I checked it twice.' });
  const err = h('div', { class: 'err hidden', role: 'alert' });
  sheet((close) => h('div', {}, h('h2', {}, 'Approve this setup?'), h('p', { class: 'muted mt-s' }, 'It becomes a numbered release that cannot be changed. The activity record keeps your name.'),
    mine ? h('div', { class: 'col mt' }, h('div', { class: 'notice warn' }, icon('warn'), 'You prepared or sent this yourself. An administrator may approve it only by giving a reason, which is written in the record.'), h('div', { class: 'field' }, h('label', { for: 'override-reason' }, 'Why are you approving your own work?'), reason)) : null, err,
    h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', onclick: close }, 'Not yet'),
      h('button', { class: 'btn primary', id: 'approve-yes', type: 'button', onclick: async () => { try { await post(`/api/customers/${ctx.id}/approve`, { overrideReason: reason.value }); close(); flash('Approved.'); location.reload(); } catch (e) { err.textContent = e.message; err.classList.remove('hidden'); } } }, 'Approve'))));
}
function reject(ctx) {
  const reason = h('textarea', { id: 'reject-reason', rows: 3, placeholder: 'What should change?' });
  const err = h('div', { class: 'err hidden', role: 'alert' });
  sheet((close) => h('div', {}, h('h2', {}, 'Send it back'), h('p', { class: 'muted mt-s' }, 'Say, in a few words, what to change. The person who prepared it will see this.'), h('div', { class: 'field mt' }, reason), err,
    h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', onclick: close }, 'Cancel'),
      h('button', { class: 'btn primary', id: 'reject-yes', type: 'button', onclick: async () => { try { await post(`/api/customers/${ctx.id}/reject`, { reason: reason.value }); close(); flash('Sent back.'); location.reload(); } catch (e) { err.textContent = e.message; err.classList.remove('hidden'); } } }, 'Send back'))));
}
void confirmSheet;
