import { h, icon, when } from '../dom.js';
import { get } from '../api.js';

export const title = () => 'Activity';
const WORDS = {
  'workspace.created': 'Created the Studio', 'signin': 'Signed in', 'signin.failed': 'A wrong password was typed', 'team.added': 'Added to the team', 'team.role': 'Role changed', 'team.password': 'Password changed', 'team.on': 'Switched on', 'team.off': 'Switched off',
  'customer.created': 'Added a customer', 'customer.changed': 'Changed a customer\'s details', 'customer.logo': 'Set the logo', 'proposal.saved': 'Saved a setup', 'review.submitted': 'Sent for approval', 'review.rejected': 'Sent back',
  'release.approved': 'Approved', 'build.made': 'Built an installer', 'customer.delivered': 'Handed over', 'backup.made': 'Made a backup', 'settings.changed': 'Changed settings', 'ai.asked': 'Asked an AI tool', 'key.saved': 'Saved a key', 'key.removed': 'Removed a key',
  'tool.update.start': 'Started updating a tool', 'tool.update.done': 'Updated a tool', 'tool.update.failed': 'A tool update failed',
};

export async function render({ params }) {
  const customer = params[0] && params[0] !== 'all' ? params[0] : null;
  const [{ entries }, { result }] = await Promise.all([get('/api/audit' + (customer ? `?customer=${encodeURIComponent(customer)}` : '')), get('/api/audit/verify')]);
  return h('div', { class: 'view' },
    h('div', { class: 'page-head' }, h('div', { class: 'grow' }, h('h1', {}, 'Activity'), h('p', { class: 'sub' }, customer ? `Everything done for this customer.` : 'Everything anyone did in the Studio, newest first.')),
      h('span', { class: 'pill ' + (result.ok ? 'ok' : 'bad'), id: 'integrity', title: result.ok ? 'No line of this record was changed or removed.' : result.why }, icon(result.ok ? 'shield' : 'warn', 's'), result.ok ? `Record checked: ${result.count} entries, none changed` : `The record was changed at entry ${result.brokenAt}`)),
    entries.length ? h('div', { class: 'panel' }, h('table', { class: 'tbl' }, h('thead', {}, h('tr', {}, ['When', 'Who', 'What', 'Details'].map((t) => h('th', {}, t)))),
      h('tbody', {}, entries.map((e) => h('tr', {}, h('td', { class: 'muted small', style: { 'white-space': 'nowrap' } }, when(e.at)), h('td', {}, e.who ? e.who.name : ''), h('td', {}, WORDS[e.action] ?? e.action, e.customer ? h('span', { class: 'muted small' }, '  ' + e.customer) : null), h('td', { class: 'muted small' }, e.detail)))))) : h('div', { class: 'empty' }, h('h2', {}, 'Nothing yet')));
}
