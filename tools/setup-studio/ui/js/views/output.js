import { h } from '../dom.js';
export async function render() { return h('div', { class: 'card' }, h('h2', {}, 'Installer'), h('p', { class: 'lead' }, 'Coming next.')); }
