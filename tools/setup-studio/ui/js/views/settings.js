import { h, icon, toast, sheet, confirmSheet } from '../dom.js';
import { get, put, del, post } from '../api.js';
import { app } from '../main.js';

export const title = () => 'Settings';
const EFFORT_WORDS = { minimal: 'Minimal', low: 'Low', medium: 'Medium', high: 'High', xhigh: 'Extra high', max: 'Maximum' };
const ADMIN = () => app.can.settings;

export async function render() {
  const [settings, tools] = await Promise.all([get('/api/settings'), get('/api/ai/tools')]);
  const root = h('div', { class: 'view' }, h('div', { class: 'page-head' }, h('div', { class: 'grow' }, h('h1', {}, 'Settings'), h('p', { class: 'sub' }, 'Your company, the build service, the AI tools, and keeping things safe.'))));
  if (!ADMIN()) root.append(h('div', { class: 'notice mt', style: { 'margin-bottom': '18px' } }, icon('lock'), 'Only an administrator can change settings. You can look at them here.'));
  root.append(companyCard(settings), await programsCard(), await buildServiceCard(), aiCard(settings, tools), keysCard(settings), safeCard(settings));
  return root;
}

// ---------- your company ----------
function companyCard(settings) {
  const c = settings.company;
  const f = (id, label, value, extra = {}) => h('div', { class: 'field' }, h('label', { for: id }, label), h('input', { type: 'text', id, value, disabled: !ADMIN(), ...extra }));
  const name = f('co-name', 'Company name', c.name, { placeholder: 'Shown on hand-over papers' });
  const mail = f('co-mail', 'Support email', c.supportEmail, { placeholder: 'help@yourcompany.example' });
  const phone = f('co-phone', 'Support phone', c.supportPhone);
  const site = f('co-site', 'Website', c.website);
  const get = (el) => el.querySelector('input').value;
  return h('div', { class: 'card', id: 'company-card' }, h('h2', {}, 'Your company'), h('p', { class: 'lead' }, 'Printed on the hand-over papers, so the customer knows who to call. Leave a field empty to leave it off the papers.'),
    h('div', { class: 'grid2' }, name, mail, phone, site),
    ADMIN() ? h('div', { class: 'row mt' }, h('button', { class: 'btn primary', id: 'company-save', type: 'button', onclick: async () => { try { await put('/api/company', { name: get(name), supportEmail: get(mail), supportPhone: get(phone), website: get(site) }); toast('Saved.'); } catch (e) { toast(e.message, 'bad'); } } }, 'Save')) : null);
}

// ---------- the programs folder ----------
async function programsCard() {
  const first = await get('/api/programs');
  const { programs } = first;
  // The Studio may come with its own programs (a kit). Then nobody has to choose a folder; an administrator can still point to a newer one, and an empty box comes back to the kit.
  const input = h('input', { type: 'text', id: 'programs-folder', value: first.source === 'chosen' ? programs.folder : '', disabled: !ADMIN(), placeholder: first.builtIn.present ? 'Leave empty to use the programs that came with the Studio' : 'For example C:\\Users\\you\\Downloads\\release-1.0.0', spellcheck: 'false' });
  const say = h('div', { id: 'programs-say' });
  const show = (p, { saved = false, source = 'chosen', builtIn = { present: false } } = {}) => say.replaceChildren(
    p.ok ? h('div', { class: 'notice ok', id: 'programs-in-use' }, icon('check'), h('div', {},
      h('b', {}, `Version ${p.version}: ${p.files.length} files checked`),
      h('div', { class: 'small' }, source === 'built-in' ? 'These are the programs that came with the Studio; nobody has to choose a folder. Every file matches its fingerprint.' : saved ? 'Saved. Every file matches its fingerprint.' : 'Every file matches its fingerprint.'),
      source === 'chosen' && builtIn.present ? h('div', { class: 'small', id: 'programs-builtin-unused' }, `The programs that came with the Studio (version ${builtIn.version ?? '?'}) are not used while a folder is chosen here. Empty the box and press "Check and save" to go back to them.`) : null))
      : p.problems?.length ? h('div', { class: 'notice warn' }, icon('warn'), h('ul', {}, p.problems.map((t) => h('li', {}, t)))) : null);
  if (programs.folder) show(programs, { source: first.source, builtIn: first.builtIn });
  return h('div', { class: 'card', id: 'programs-settings' }, h('h2', {}, first.builtIn.present ? 'The programs' : 'The programs folder'),
    h('p', { class: 'lead' }, first.builtIn.present
      ? 'The Studio does not build programs. NextGenOS builds and releases them, and this Studio came with the programs of one release. The Studio checks each file, then puts a customer\'s set-up beside them. Only if you were given a newer release, type the folder where you saved its files (including base-kit.json).'
      : 'The Studio does not build programs. NextGenOS builds and releases them; download every file of a release into one folder (including base-kit.json) and tell the Studio where it is. The Studio checks each file, then puts a customer\'s set-up beside them.'),
    h('div', { class: 'field' }, h('label', { for: 'programs-folder' }, first.builtIn.present ? 'Another folder with release files (optional)' : 'Folder with the release files'), input), say,
    ADMIN() ? h('div', { class: 'row mt' }, h('button', { class: 'btn primary', id: 'programs-save', type: 'button', onclick: async (e) => {
      const b = e.currentTarget; b.classList.add('busy');
      try {
        const r = await put('/api/programs', { folder: input.value });
        if (r.programs.folder || r.programs.problems?.length) show(r.programs, { saved: r.saved, source: r.source, builtIn: r.builtIn ?? first.builtIn }); else say.replaceChildren();
        if (r.saved) toast('Saved.'); else if (r.source === 'built-in') toast('Using the programs that came with the Studio.');
      } catch (x) { toast(x.message, 'bad'); } finally { b.classList.remove('busy'); }
    } }, 'Check and save')) : null);
}

// ---------- the build service ----------
// A customer's website and Android app are made off this PC, by a build service. Two access codes (kept only in the Studio's own secret store, never shown again) and the names of
// two places. "Test the connection" says in plain words what is wrong.
async function buildServiceCard() {
  const { connection: conn } = await get('/api/build-service');
  const field = (id, label, value, hint, extra = {}) => h('div', { class: 'field' }, h('label', { for: id }, label), h('input', { type: 'text', id, value, disabled: !ADMIN(), spellcheck: 'false', autocomplete: 'off', ...extra }), h('span', { class: 'hint' }, hint));
  const source = field('build-source', 'Where the programs are made', conn.sourceRepo, 'The name of the place NextGenOS keeps the programs in, written like owner/name. NextGenOS tells you the name.', { placeholder: 'owner/name' });
  const results = field('build-results', 'Where the results are kept', conn.resultsRepo, 'A private place that holds no programs: only each customer\'s settings and the files made for them. Written like owner/name.', { placeholder: conn.suggestedResults || 'owner/name' });
  const version = field('build-ref', 'Which version of the programs to build from', conn.ref, 'Leave this empty to use the main one.', { placeholder: 'the main one' });
  const say = h('div', { id: 'build-test-result', class: 'col mt-s' });
  const status = h('div', { id: 'build-connected' });
  const showConnected = (c) => status.replaceChildren(c.ready ? h('div', { class: 'notice ok' }, icon('check'), 'Both places are named and both access codes are saved. Press "Test the connection" to check them.') : h('div', { class: 'notice warn' }, icon('warn'), c.why));
  showConnected(conn);

  const codes = h('div', { class: 'col', id: 'build-codes' });
  const hints = { start: 'Lets the Studio ask for a build and watch it. It must not be able to read the programs.', results: 'Lets the Studio keep a customer\'s settings and fetch the finished files. It must only reach the results place.' };
  const drawCodes = (c) => codes.replaceChildren(...Object.entries(c.codes).map(([id, k]) => {
    const input = h('input', { type: 'password', id: 'code-' + id, placeholder: k.set ? 'Paste a new code to replace it' : 'Paste the code', autocomplete: 'off', 'aria-label': k.label, disabled: !ADMIN() });
    return h('div', { class: 'field', 'data-code': id },
      h('label', { for: 'code-' + id }, k.label),
      h('div', { class: 'row wrap' }, h('div', { class: 'grow', style: { 'min-width': '220px' } }, input),
        ADMIN() ? h('button', { class: 'btn small', type: 'button', 'data-save-code': id, onclick: async () => { try { const r = await put(`/api/build-service/codes/${id}`, { code: input.value }); input.value = ''; drawCodes(r.connection); showConnected(r.connection); toast('Access code saved.'); } catch (e) { toast(e.message, 'bad'); } } }, 'Save') : null,
        ADMIN() && k.set ? h('button', { class: 'btn small danger', type: 'button', onclick: async () => { try { const r = await del(`/api/build-service/codes/${id}`); drawCodes(r.connection); showConnected(r.connection); toast('Access code removed.'); } catch (e) { toast(e.message, 'bad'); } } }, 'Remove') : null,
        k.set ? h('span', { class: 'pill ok' }, icon('check', 's'), 'Saved') : h('span', { class: 'pill' }, 'Not added')),
      h('span', { class: 'hint' }, hints[id]));
  }));
  drawCodes(conn);

  const showTest = (r) => say.replaceChildren(
    h('div', { class: 'notice ' + (r.ok ? 'ok' : 'warn'), id: 'build-test-summary' }, icon(r.ok ? 'check' : 'warn'), r.ok ? 'Everything checks out: each access code can do what it is for, and no more.' : 'Something needs attention. Each line below says what.'),
    h('ul', { class: 'col', style: { 'list-style': 'none', padding: 0, margin: 0, gap: '6px' } }, r.checks.map((c) => h('li', { class: 'row', 'data-check': c.id, 'data-ok': String(c.ok), style: { 'align-items': 'flex-start', gap: '10px' } }, h('span', { class: c.ok === true ? 'tone-ok' : c.ok === false ? 'tone-warn' : 'muted' }, icon(c.ok === true ? 'check' : c.ok === false ? 'warn' : 'info', 's')), h('span', { class: 'grow' }, c.words)))));

  return h('div', { class: 'card', id: 'build-settings' }, h('h2', {}, 'Connect the build service'),
    h('p', { class: 'lead' }, 'A customer\'s Android app is made by a build service, not on this PC: it carries the customer\'s own name and settings, and making it needs NextGenOS\'s program files, which never come to this PC. An administrator connects it once. (The website does not need this: it is made on this PC, in the customer\'s step "Website and app".) The steps for making the two access codes are in the Setup Studio guide, "Connecting the build service".'),
    status,
    h('div', { class: 'grid2 mt' }, source, results),
    h('details', { class: 'more mt-s' }, h('summary', {}, icon('gear', 's'), 'More options'), h('div', { class: 'grid2 mt-s' }, version)),
    h('div', { class: 'mt' }, codes),
    ADMIN() ? h('div', { class: 'row mt wrap' },
      h('button', { class: 'btn primary', id: 'build-save', type: 'button', onclick: async (e) => {
        const b = e.currentTarget; b.classList.add('busy');
        try { const r = await put('/api/build-service', { sourceRepo: source.querySelector('input').value, resultsRepo: results.querySelector('input').value, ref: version.querySelector('input').value }); showConnected(r.connection); toast('Saved.'); } catch (x) { toast(x.message, 'bad'); } finally { b.classList.remove('busy'); }
      } }, 'Save the names'),
      h('button', { class: 'btn', id: 'build-test', type: 'button', onclick: async (e) => {
        const b = e.currentTarget; b.classList.add('busy'); say.replaceChildren(h('p', { class: 'small muted' }, 'Asking the build service…'));
        try { showTest(await post('/api/build-service/test')); } catch (x) { say.replaceChildren(h('div', { class: 'err' }, icon('warn', 's'), x.message)); } finally { b.classList.remove('busy'); }
      } }, icon('refresh', 's'), 'Test the connection')) : null,
    say);
}

// ---------- AI tools ----------
function aiCard(settings, tools) {
  const card = h('div', { class: 'card', id: 'ai-settings' });
  const state = { tool: settings.ai.tool, cfg: JSON.parse(JSON.stringify(settings.ai.tools)), models: {} };
  const detail = h('div', { class: 'mt' });
  const picker = h('div', { class: 'choices' });

  const drawPicker = () => picker.replaceChildren(
    h('button', { class: 'choice', type: 'button', 'data-tool': 'none', 'aria-pressed': String(state.tool === 'none'), onclick: () => { state.tool = 'none'; drawPicker(); drawDetail(); } }, h('b', {}, 'No AI tool'), h('span', {}, 'Use only the plain setup. Nothing leaves this PC.')),
    ...tools.tools.map((t) => h('button', { class: 'choice', type: 'button', 'data-tool': t.id, 'aria-pressed': String(state.tool === t.id), onclick: () => { state.tool = t.id; drawPicker(); drawDetail(); } },
      h('b', {}, t.kind === 'cli' ? icon('terminal', 's') : icon('globe', 's'), t.label), h('span', {}, readyWords(t)))));

  const readyWords = (t) => {
    if (t.kind === 'cli') return t.status.found === false ? 'Not found on this PC' : t.status.found ? `Found${t.status.version ? ' · version ' + t.status.version : ''}${t.status.signedIn === false ? ' · not signed in' : ''}` : 'Set the program below';
    return t.ready ? 'Key is saved' : 'Needs a key';
  };

  async function drawDetail() {
    detail.replaceChildren();
    if (state.tool === 'none') { detail.append(save()); return; }
    const t = tools.tools.find((x) => x.id === state.tool);
    const cfg = (state.cfg[t.id] ??= {});
    const box = h('div', { class: 'card flat', id: 'tool-detail' });
    box.append(h('h3', {}, t.label), h('p', { class: 'small muted' }, t.help));
    if (t.kind === 'cli' && t.status.found === false) box.append(h('div', { class: 'notice warn mt-s' }, icon('warn'), t.install));
    if (t.needsKey && !t.ready) box.append(h('div', { class: 'notice warn mt-s' }, icon('key'), 'This tool needs an API key. Add it under "Keys" below.'));

    if (t.id === 'generic-cli') box.append(genericFields(cfg));

    // model and thinking level
    const modelsBox = h('div', { class: 'mt', id: 'model-box' }, h('p', { class: 'muted small' }, 'Looking up the models…'));
    box.append(modelsBox);
    detail.append(box, save());
    try {
      const m = state.models[t.id] ??= await get(`/api/ai/tools/${t.id}/models`);
      drawModels(modelsBox, t, cfg, m);
    } catch (e) { modelsBox.replaceChildren(h('div', { class: 'err' }, icon('warn', 's'), e.message)); }
    // the rest
    box.append(advanced(t, cfg));
    if (t.kind === 'cli') box.append(health(t));
  }

  function drawModels(boxEl, t, cfg, m) {
    const known = m.models;
    const sel = h('select', { id: 'model-select', 'aria-label': 'Model' },
      h('option', { value: '' }, 'The tool\'s own choice (recommended)'),
      known.map((x) => h('option', { value: x.id, selected: cfg.model === x.id }, x.label + (x.label !== x.id ? ` (${x.id})` : ''))),
      h('option', { value: '__custom__', selected: !!cfg.model && !known.some((x) => x.id === cfg.model) }, 'Another model…'));
    const custom = h('input', { type: 'text', id: 'model-custom', placeholder: 'Type the model name', value: known.some((x) => x.id === cfg.model) ? '' : cfg.model ?? '', maxlength: '100', class: sel.value === '__custom__' ? '' : 'hidden', 'aria-label': 'Model name' });
    const effortBox = h('div', { id: 'effort-box' });
    const chosen = () => known.find((x) => x.id === cfg.model);
    const drawEffort = () => {
      const levels = chosen() ? chosen().efforts.map((e) => e.id) : (m.defaultEfforts?.map((e) => e.id) ?? t.efforts ?? []);
      effortBox.replaceChildren();
      if (!levels.length) { effortBox.append(h('p', { class: 'small muted' }, chosen() ? 'This model has no thinking level to choose.' : t.efforts?.length === 0 ? 'This kind of tool has no thinking level.' : '')); delete cfg.effort; return; }
      if (cfg.effort && !levels.includes(cfg.effort)) delete cfg.effort;
      const def = chosen()?.defaultEffort;
      effortBox.append(h('span', { class: 'label' }, 'How hard it thinks'), h('div', { class: 'mt-s' }, h('div', { class: 'seg', id: 'effort-seg', role: 'group', 'aria-label': 'How hard it thinks' },
        h('button', { type: 'button', 'data-effort': '', 'aria-pressed': String(!cfg.effort), onclick: () => { delete cfg.effort; drawEffort(); } }, 'Tool\'s default' + (def ? ` (${EFFORT_WORDS[def] ?? def})` : '')),
        levels.map((l) => h('button', { type: 'button', 'data-effort': l, 'aria-pressed': String(cfg.effort === l), onclick: () => { cfg.effort = l; drawEffort(); } }, EFFORT_WORDS[l] ?? l)))),
        h('p', { class: 'hint mt-s' }, 'Higher is slower and costs more, and is usually only needed for hard problems. Medium is a good start.'));
    };
    sel.addEventListener('change', () => { if (sel.value === '__custom__') { custom.classList.remove('hidden'); custom.focus(); cfg.model = custom.value.trim() || undefined; } else { custom.classList.add('hidden'); if (sel.value) cfg.model = sel.value; else delete cfg.model; } if (!cfg.model) delete cfg.model; drawEffort(); });
    custom.addEventListener('input', () => { if (custom.value.trim()) cfg.model = custom.value.trim(); else delete cfg.model; drawEffort(); });
    boxEl.replaceChildren(h('div', { class: 'field' }, h('label', { for: 'model-select' }, 'Model'), sel, custom, h('span', { class: 'hint' }, m.note ?? '')), h('div', { class: 'mt-s' }, effortBox));
    drawEffort();
  }

  function genericFields(cfg) {
    const args = h('input', { type: 'text', id: 'g-args', value: (cfg.args ?? []).join(' '), placeholder: 'For example: --print --no-tools', 'aria-label': 'Options' });
    args.addEventListener('input', () => { cfg.args = args.value.trim() ? args.value.trim().split(/\s+/) : []; });
    const cmd = h('input', { type: 'text', id: 'g-command', value: cfg.command ?? '', placeholder: 'antigravity, gemini, or a full path', 'aria-label': 'Program' });
    cmd.addEventListener('input', () => { cfg.command = cmd.value.trim(); });
    const via = h('div', { class: 'seg' }, [['stdin', 'The question goes in as typed input'], ['arg', 'The question is the last option']].map(([v, l]) => h('button', { type: 'button', 'aria-pressed': String((cfg.promptVia ?? 'stdin') === v), onclick: (e) => { cfg.promptVia = v; for (const b of via.children) b.setAttribute('aria-pressed', String(b === e.currentTarget)); } }, l)));
    return h('div', { class: 'col mt-s' }, h('div', { class: 'field' }, h('label', { for: 'g-command' }, 'Program'), cmd), h('div', { class: 'field' }, h('label', { for: 'g-args' }, 'Options'), args, h('span', { class: 'hint' }, 'Use {model} and {effort} where the tool wants them. The tool is always run without a shell, in an empty folder.')), h('div', { class: 'field' }, h('span', { class: 'label' }, 'How the question is given'), via));
  }

  function advanced(t, cfg) {
    const num = (id, label, key, extra = {}, hint) => h('div', { class: 'field' }, h('label', { for: id }, label), h('input', { type: 'text', id, value: cfg[key] ?? '', inputmode: 'decimal', oninput: (e) => { const v = e.target.value.trim(); if (v === '') delete cfg[key]; else cfg[key] = key === 'maxBudgetUsd' ? v : Number(v); }, ...extra }), hint ? h('span', { class: 'hint' }, hint) : null);
    const bits = [num('timeout', 'Wait at most (seconds)', 'timeoutSec', { placeholder: '240' }, 'How long to wait for an answer.')];
    if (t.id === 'claude-code') bits.push(h('div', { class: 'field' }, h('label', { for: 'fallback' }, 'If the model cannot answer, use'), h('input', { type: 'text', id: 'fallback', value: cfg.fallbackModel ?? '', placeholder: 'for example claude-sonnet-5-5', oninput: (e) => { const v = e.target.value.trim(); if (v) cfg.fallbackModel = v; else delete cfg.fallbackModel; } })), num('budget', 'Spend at most (US dollars) on one answer', 'maxBudgetUsd', { placeholder: 'no limit' }));
    if (['anthropic', 'openai', 'gemini'].includes(t.id)) bits.push(h('div', { class: 'field' }, h('label', { for: 'baseurl' }, 'Service address'), h('input', { type: 'text', id: 'baseurl', value: cfg.baseUrl ?? '', placeholder: t.id === 'openai' ? 'https://api.openai.com/v1 (or a service on this PC)' : 'the usual address', oninput: (e) => { const v = e.target.value.trim(); if (v) cfg.baseUrl = v; else delete cfg.baseUrl; } }), h('span', { class: 'hint' }, 'Only https, or a service on this same PC.')));
    if (t.id === 'gemini') bits.push(num('think', 'Thinking budget (tokens)', 'thinkingBudget', { placeholder: 'the model decides' }, '-1 lets the model decide, 0 switches thinking off.'));
    if (t.id === 'antigravity') bits.push(h('label', { class: 'switch' }, h('input', { type: 'checkbox', checked: !!cfg.useGeminiKey, onchange: (e) => { cfg.useGeminiKey = e.target.checked; } }), h('span', { class: 'track' }), h('span', { class: 'text' }, h('b', {}, 'Use my Gemini key'), h('span', {}, 'Instead of the Google sign-in made in Antigravity.'))));
    return h('details', { class: 'more mt' }, h('summary', {}, icon('gear', 's'), 'More options'), h('div', { class: 'grid2 mt-s' }, bits),
      h('p', { class: 'hint mt-s' }, 'Options that would let a tool run commands, change files or browse are never passed: the Studio only needs it to answer in words.'));
  }

  function health(t) {
    const out = h('div', { id: 'health-' + t.id, class: 'col mt-s' });
    const draw = async () => {
      out.replaceChildren(h('p', { class: 'small muted' }, 'Checking for a newer version…'));
      try {
        const { update: u } = await get(`/api/ai/tools/${t.id}/update`);
        const rows = [];
        if (u.update === 'install') rows.push(h('div', { class: 'notice warn' }, icon('warn'), u.note));
        else {
          rows.push(h('dl', { class: 'kv' }, h('dt', {}, 'Installed'), h('dd', {}, u.version ?? 'unknown'), h('dt', {}, 'Newest'), h('dd', {}, u.latest ?? 'could not be found out'), h('dt', {}, 'Where'), h('dd', { class: 'small muted' }, u.where ?? '')));
          rows.push(u.update === 'available' ? h('div', { class: 'notice' }, icon('info'), `A newer version (${u.latest}) is out.`) : u.update === 'current' ? h('div', { class: 'notice ok' }, icon('check'), 'This is the newest version.') : h('div', { class: 'notice' }, icon('info'), 'The Studio could not tell whether a newer version is out.'));
          if (u.how?.text) rows.push(h('p', { class: 'small muted' }, 'Updating: ' + u.how.text));
          if (ADMIN()) rows.push(h('div', { class: 'row' }, h('button', { class: 'btn' + (u.update === 'available' ? ' primary' : ''), id: 'update-' + t.id, type: 'button', disabled: !u.canUpdate, onclick: () => update(t, u, draw) }, icon('download', 's'), u.update === 'available' ? 'Update now' : 'Update anyway'), h('button', { class: 'btn quiet', type: 'button', onclick: draw }, 'Check again')));
        }
        out.replaceChildren(...rows);
      } catch (e) { out.replaceChildren(h('div', { class: 'err' }, icon('warn', 's'), e.message)); }
    };
    return h('details', { class: 'more mt', onToggle: undefined, ontoggle: (e) => { if (e.target.open && !out.dataset.done) { out.dataset.done = '1'; draw(); } } }, h('summary', {}, icon('refresh', 's'), 'Version and updates'), out);
  }

  const update = async (t, u, again) => {
    const ok = await confirmSheet({ title: `Update ${t.label}?`, text: `${u.how.text} It is run on this PC, and written in the activity record. It can take a few minutes.`, yes: 'Update', no: 'Not now' });
    if (!ok) return;
    toast('Updating…');
    try { const { result } = await post(`/api/ai/tools/${t.id}/update`, { confirm: true }); toast(result.changed ? `Updated from ${result.before} to ${result.after}.` : 'The tool was already the newest.'); again(); } catch (e) { toast(e.message, 'bad'); }
  };

  const save = () => ADMIN() ? h('div', { class: 'row mt' }, h('button', { class: 'btn primary', id: 'ai-save', type: 'button', onclick: async () => {
    try { const r = await put('/api/settings', { ai: { tool: state.tool, tools: state.cfg } }); state.cfg = JSON.parse(JSON.stringify(r.ai.tools)); toast('Saved.'); } catch (e) { toast(e.message, 'bad'); }
  } }, 'Save the AI settings')) : null;

  card.append(h('h2', {}, 'AI tool'), h('p', { class: 'lead' }, 'Which tool improves a setup, and how. The Studio asks for a suggestion and checks everything it says; a person always decides.'), picker, detail);
  drawPicker(); drawDetail();
  return card;
}

// ---------- keys ----------
function keysCard(settings) {
  const card = h('div', { class: 'card', id: 'keys-card' }, h('h2', {}, 'Keys'), h('p', { class: 'lead' }, 'A key lets the Studio ask an AI service on your account. It is kept in your own user folder on this PC (not in the Studio\'s files or any backup), never shown again, and sent only to its own service. A key set on the computer itself takes the place of one pasted here.'));
  const list = h('div', { class: 'col' });
  const draw = (keys) => list.replaceChildren(...Object.entries(keys).map(([id, k]) => {
    const input = h('input', { type: 'password', placeholder: k.set ? 'Paste a new key to replace it' : 'Paste the key', autocomplete: 'off', 'aria-label': `${k.label} key`, id: 'key-' + id, disabled: !ADMIN() });
    return h('div', { class: 'row wrap', 'data-key': id }, h('div', { style: { width: '260px' } }, h('b', {}, k.label), h('div', { class: 'tiny muted' }, k.set ? (k.from === 'computer' ? `Set on this computer (${k.envNames.join(' or ')})` : 'Saved in the Studio') : 'Not set')),
      h('div', { class: 'grow', style: { 'min-width': '200px' } }, input),
      ADMIN() ? h('button', { class: 'btn small', type: 'button', onclick: async () => { try { const r = await put(`/api/keys/${id}`, { key: input.value }); draw(r.keys); toast('Key saved.'); } catch (e) { toast(e.message, 'bad'); } } }, 'Save') : null,
      ADMIN() && k.set && k.from === 'studio' ? h('button', { class: 'btn small danger', type: 'button', onclick: async () => { try { const r = await del(`/api/keys/${id}`); draw(r.keys); toast('Key removed.'); } catch (e) { toast(e.message, 'bad'); } } }, 'Remove') : null,
      k.set ? h('span', { class: 'pill ok' }, icon('check', 's'), 'Ready') : null);
  }));
  draw(settings.keys);
  card.append(list);
  return card;
}

// ---------- safe keeping ----------
function safeCard(settings) {
  const info = h('div', { class: 'small muted mt-s', id: 'backup-info' });
  return h('div', { class: 'card', id: 'safe-card' }, h('h2', {}, 'Keeping things safe'), h('p', { class: 'lead' }, 'Everything the Studio knows is in one folder. Back it up like any other important office folder.'),
    h('dl', { class: 'kv' }, h('dt', {}, 'Studio folder'), h('dd', { class: 'small', id: 'ws-folder' }, settings.folder)),
    app.can.backup ? h('div', { class: 'row mt' }, h('button', { class: 'btn', id: 'backup', type: 'button', onclick: async () => { try { const r = await post('/api/backup'); info.textContent = `Backup saved: ${r.file} (${r.files} files).`; toast('Backup made.'); } catch (e) { toast(e.message, 'bad'); } } }, icon('download', 's'), 'Make a backup now')) : null, info);
}
void sheet;
