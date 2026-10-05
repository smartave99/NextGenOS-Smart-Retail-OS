// The Studio's page: first-time welcome, sign-in, and the frame with its sidebar. Each screen is a module in views/.
import { h, mount, icon, toast, showFlash } from './dom.js';
import { get, post, session, setSession, onSignedOut, ApiError } from './api.js';

export const app = { options: null, me: null, can: {}, root: document.getElementById('app'), content: null, counts: {} };
export const go = (path) => { location.hash = path; };
const ROLE_WORDS = { admin: 'Administrator', reviewer: 'Reviewer', sales: 'Sales' };

const mark = () => h('div', { class: 'logo-mark' }, icon('package', 'l'));

// ---------- first use ----------
function welcome(st) {
  const name = h('input', { type: 'text', id: 'w-name', autocomplete: 'name', placeholder: 'Your full name' });
  const pass = h('input', { type: 'password', id: 'w-pass', autocomplete: 'new-password', placeholder: 'At least 8 characters' });
  const pass2 = h('input', { type: 'password', id: 'w-pass2', autocomplete: 'new-password', placeholder: 'Type it again' });
  const folder = h('input', { type: 'text', id: 'w-folder', value: st.folder, spellcheck: 'false' });
  const err = h('div', { class: 'err hidden', role: 'alert' });
  const go = h('button', { class: 'btn primary wide', id: 'w-go', type: 'button' }, 'Get started');
  go.onclick = async () => {
    err.classList.add('hidden');
    if (pass.value !== pass2.value) { err.textContent = 'The two passwords are not the same.'; err.classList.remove('hidden'); return; }
    go.classList.add('busy');
    try { const r = await post('/api/setup', { name: name.value, password: pass.value, folder: folder.value }); setSession(r.session); await enter(); } catch (e) { err.textContent = e.message; err.classList.remove('hidden'); go.classList.remove('busy'); }
  };
  mount(app.root, h('div', { class: 'auth' }, h('div', { class: 'auth-card view' },
    mark(), h('h1', {}, 'Welcome to the Setup Studio'),
    h('p', { class: 'lead' }, 'Turn a customer\'s details into a ready-to-install Smart Retail POS, with their own look, words and settings. First, create the administrator account for this Studio.'),
    h('div', { class: 'card auth-form' },
      h('div', { class: 'field' }, h('label', { for: 'w-name' }, 'Your name'), name),
      h('div', { class: 'field' }, h('label', { for: 'w-pass' }, 'Password'), pass),
      h('div', { class: 'field' }, h('label', { for: 'w-pass2' }, 'Password again'), pass2),
      h('details', { class: 'more' }, h('summary', {}, 'Where to keep the Studio\'s files'), h('div', { class: 'field mt-s' }, folder, h('span', { class: 'hint' }, 'Customers, approvals and the activity record live in this folder. Keep it on a drive that is backed up, and protected like the rest of your office files.'))),
      err, go),
    h('p', { class: 'legal' }, 'For NextGenOS staff only. Everything stays on this PC.'))));
  name.focus();
}

// ---------- sign in ----------
function signin(st) {
  const box = h('div', { class: 'auth-card view' });
  const pick = () => mount(box, mark(), h('h1', {}, 'Who is using the Studio?'), h('p', { class: 'lead' }, 'Choose your name.'),
    h('div', { class: 'people' }, st.team.map((m) => h('button', { class: 'person', type: 'button', 'data-person': m.name, onclick: () => ask(m) }, h('div', { class: 'avatar big' }, m.initials), h('b', {}, m.name), h('span', {}, ROLE_WORDS[m.role] ?? m.role)))),
    h('p', { class: 'legal' }, 'NextGenOS Setup Studio · for NextGenOS staff only'));
  const ask = (m) => {
    const pass = h('input', { type: 'password', id: 's-pass', autocomplete: 'current-password', placeholder: 'Password' });
    const err = h('div', { class: 'err hidden', role: 'alert' });
    const submit = async () => { err.classList.add('hidden'); try { const r = await post('/api/signin', { id: m.id, password: pass.value }); setSession(r.session); await enter(); } catch (e) { err.textContent = e.message; err.classList.remove('hidden'); pass.select(); } };
    pass.addEventListener('keydown', (e) => { if (e.key === 'Enter') submit(); });
    mount(box, h('div', { class: 'avatar big', style: { margin: '0 auto 16px' } }, m.initials), h('h1', {}, m.name), h('p', { class: 'lead' }, 'Enter your password.'),
      h('div', { class: 'auth-form' }, pass, err, h('button', { class: 'btn primary wide', id: 's-go', type: 'button', onclick: submit }, 'Sign in'), h('button', { class: 'btn quiet wide', type: 'button', onclick: pick }, 'Not you?')));
    pass.focus();
  };
  mount(app.root, h('div', { class: 'auth' }, box));
  pick();
}

// ---------- the frame ----------
const NAV = [['customers', 'Customers', 'store'], ['team', 'Team', 'users'], ['activity', 'Activity', 'clock'], ['settings', 'Settings', 'gear']];
const views = {
  customers: () => import('./views/customers.js'), customer: () => import('./views/customer.js'),
  team: () => import('./views/team.js'), activity: () => import('./views/activity.js'), settings: () => import('./views/settings.js'),
};

function frame() {
  const nav = h('nav', { class: 'nav', 'aria-label': 'Main' }, NAV.map(([id, label, ic]) => h('a', { href: '#/' + id, 'data-nav': id }, icon(ic), label, id === 'customers' ? h('span', { class: 'count', id: 'count-customers' }, '') : null)));
  const me = app.me;
  app.content = h('main', { class: 'content', id: 'main' });
  mount(app.root, h('div', { class: 'frame' },
    h('aside', { class: 'sidebar' }, h('div', { class: 'logo' }, h('div', { class: 'logo-mark' }, icon('package')), h('div', {}, h('b', {}, 'Setup Studio'), h('span', {}, 'NextGenOS'))), nav,
      h('div', { class: 'side-foot' }, h('div', { class: 'avatar' }, me.name.split(/\s+/).map((w) => w[0]).slice(0, 2).join('').toUpperCase()), h('div', { class: 'who grow' }, h('b', {}, me.name), h('span', {}, ROLE_WORDS[me.role] ?? me.role)),
        h('button', { class: 'btn quiet small', id: 'signout', type: 'button', title: 'Sign out', onclick: signOut }, icon('lock', 's')))),
    app.content));
}
async function signOut() { try { await post('/api/signout'); } catch { /* already out */ } setSession(''); await start(); }

let token = 0;
async function route() {
  if (!app.content) return;
  const parts = location.hash.replace(/^#\/?/, '').split('/').filter(Boolean).map(decodeURIComponent);
  const name = parts[0] === 'customers' && parts[1] ? 'customer' : parts[0] || 'customers';
  const mine = ++token;
  for (const a of document.querySelectorAll('[data-nav]')) { if (a.dataset.nav === (name === 'customer' ? 'customers' : name)) a.setAttribute('aria-current', 'page'); else a.removeAttribute('aria-current'); }
  if (!views[name]) { go('/customers'); return; }
  mount(app.content, h('div', { class: 'empty' }, icon('refresh', 'l spin')));
  try {
    const mod = await views[name]();
    const node = await mod.render({ params: parts.slice(1), app, go, toast });
    if (mine !== token) return;
    mount(app.content, node);
    app.content.scrollTo?.(0, 0); window.scrollTo(0, 0);
    document.title = (mod.title ? mod.title(node) + ' · ' : '') + 'Setup Studio';
    node.querySelector?.('[data-autofocus]')?.focus();
    showFlash();
  } catch (e) {
    if (mine !== token || e instanceof ApiError && e.code === 'signin') return;
    mount(app.content, h('div', { class: 'empty' }, h('div', { class: 'art' }, icon('warn', 'l')), h('h2', {}, 'This page could not open'), h('p', {}, e.message), h('div', { class: 'row mt', style: { 'justify-content': 'center' } }, h('button', { class: 'btn', type: 'button', onclick: () => route() }, 'Try again'))));
  }
}
export const refreshCounts = async () => { try { const r = await get('/api/customers'); const el = document.getElementById('count-customers'); if (el) el.textContent = r.customers.length || ''; } catch { /* the page shows the problem */ } };

async function enter() {
  const [me, options] = await Promise.all([get('/api/me'), get('/api/options')]);
  app.me = me.member; app.can = me.can; app.options = options; session.me = me.member; session.can = me.can;
  frame();
  if (!location.hash || location.hash === '#') go('/customers');
  await route();
  refreshCounts();
}
window.addEventListener('hashchange', route);
onSignedOut.run = () => { app.me = null; start(); };

export async function start() {
  let st;
  try { st = await get('/api/state'); } catch (e) {
    mount(app.root, h('div', { class: 'auth' }, h('div', { class: 'auth-card' }, mark(), h('h1', {}, 'Open the Studio again'), h('p', { class: 'lead' }, e.status === 401 ? 'This page needs the address the Studio printed when it started (it ends with ?k=…). Open the Studio from its icon or its start file.' : e.message))));
    return;
  }
  if (!st.initialised) return welcome(st);
  if (!session.id) return signin(st);
  try { await enter(); } catch (e) { if (e instanceof ApiError && e.status === 401) { setSession(''); return signin(st); } throw e; }
}
start();
