import { h, icon, sheet, toast, confirmSheet } from '../dom.js';
import { get, post, put } from '../api.js';
import { app } from '../main.js';

export const title = () => 'Team';

export async function render() {
  const { team } = await get('/api/team');
  const roles = app.options.roles;
  const label = (id) => roles.find((r) => r.id === id)?.label ?? id;
  const admin = app.can.team;
  const reload = () => import('./team.js').then((m) => m.render()).then((n) => { document.getElementById('main').replaceChildren(n); });
  const rows = team.map((m) => h('div', { class: 'item', style: { cursor: 'default' }, 'data-member': m.name },
    h('div', { class: 'avatar' }, m.initials),
    h('div', { class: 'grow' }, h('div', { class: 'name' }, m.name, m.id === app.me.id ? h('span', { class: 'muted small' }, '  (you)') : null), h('div', { class: 'meta' }, roles.find((r) => r.id === m.role)?.hint ?? '')),
    admin && m.id !== app.me.id ? h('select', { 'aria-label': `Role of ${m.name}`, style: { width: '170px' }, onchange: async (e) => { try { await put(`/api/team/${m.id}`, { role: e.target.value }); toast('Role changed.'); reload(); } catch (x) { toast(x.message, 'bad'); reload(); } } }, roles.map((r) => h('option', { value: r.id, selected: r.id === m.role }, r.label))) : h('span', { class: 'pill' }, label(m.role)),
    m.disabled ? h('span', { class: 'pill bad' }, 'Switched off') : null,
    admin ? h('div', { class: 'row' },
      h('button', { class: 'btn small', type: 'button', onclick: () => password(m, reload) }, 'New password'),
      m.id !== app.me.id ? h('button', { class: 'btn small', type: 'button', onclick: async () => { const ok = await confirmSheet({ title: m.disabled ? `Switch ${m.name} on?` : `Switch ${m.name} off?`, text: m.disabled ? 'They can sign in again.' : 'They will be signed out at once and cannot sign in. Everything they did stays in the record.', yes: m.disabled ? 'Switch on' : 'Switch off', danger: !m.disabled }); if (ok) { try { await put(`/api/team/${m.id}`, { active: !!m.disabled }); reload(); } catch (x) { toast(x.message, 'bad'); } } } }, m.disabled ? 'Switch on' : 'Switch off') : null) : null));
  return h('div', { class: 'view' },
    h('div', { class: 'page-head' }, h('div', { class: 'grow' }, h('h1', {}, 'Team'), h('p', { class: 'sub' }, 'Who can do what. A setup prepared by one person is approved by another.')),
      admin ? h('button', { class: 'btn primary', id: 'add-member', type: 'button', onclick: () => add(reload) }, icon('plus', 's'), 'Add a person') : null),
    h('div', { class: 'panel' }, h('div', { class: 'list' }, rows)),
    h('div', { class: 'card flat mt' }, h('h3', {}, 'What each role can do'), h('div', { class: 'grid3 mt-s' }, roles.map((r) => h('div', {}, h('b', {}, r.label), h('p', { class: 'muted small' }, r.hint))))));
}

function add(reload) {
  const name = h('input', { type: 'text', id: 'm-name', placeholder: 'Full name', autocomplete: 'off' });
  const role = h('select', { id: 'm-role' }, app.options.roles.map((r) => h('option', { value: r.id, selected: r.id === 'sales' }, `${r.label}: ${r.hint}`)));
  const pass = h('input', { type: 'password', id: 'm-pass', placeholder: 'At least 8 characters', autocomplete: 'new-password' });
  const err = h('div', { class: 'err hidden', role: 'alert' });
  sheet((close) => h('div', {}, h('h2', {}, 'Add a person'), h('p', { class: 'muted mt-s' }, 'They will choose their name on the sign-in screen and type this password. Ask them to change it.'),
    h('div', { class: 'col mt' }, h('div', { class: 'field' }, h('label', { for: 'm-name' }, 'Name'), name), h('div', { class: 'field' }, h('label', { for: 'm-role' }, 'Role'), role), h('div', { class: 'field' }, h('label', { for: 'm-pass' }, 'First password'), pass), err),
    h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', onclick: close }, 'Cancel'), h('button', { class: 'btn primary', id: 'm-save', type: 'button', onclick: async () => { try { await post('/api/team', { name: name.value, role: role.value, password: pass.value }); close(); toast('Added.'); reload(); } catch (e) { err.textContent = e.message; err.classList.remove('hidden'); } } }, 'Add'))));
}
function password(m, reload) {
  const pass = h('input', { type: 'password', placeholder: 'At least 8 characters', autocomplete: 'new-password' });
  const err = h('div', { class: 'err hidden', role: 'alert' });
  sheet((close) => h('div', {}, h('h2', {}, `New password for ${m.name}`), h('div', { class: 'col mt' }, pass, err),
    h('div', { class: 'actions' }, h('button', { class: 'btn', type: 'button', onclick: close }, 'Cancel'), h('button', { class: 'btn primary', type: 'button', onclick: async () => { try { await put(`/api/team/${m.id}`, { password: pass.value }); close(); toast('Password changed.'); reload(); } catch (e) { err.textContent = e.message; err.classList.remove('hidden'); } } }, 'Save'))));
}
