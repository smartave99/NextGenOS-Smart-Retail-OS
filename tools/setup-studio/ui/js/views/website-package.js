// "Make the website package for this customer": the website program from the programs (the kit), this customer's own folder and, when there is one, this customer's licence file,
// put together on this PC. No GitHub, no access code, no internet; nothing is built. A reviewer or administrator presses the button; a salesperson can see what is there.
import { h, icon, toast, when, ago, download } from '../dom.js';
import { get, post, put, del, api } from '../api.js';
import { SIZE, licenceWords, licenceFileProblem } from '../sitewords.js';

const programsWords = (p) => {
  const where = p.source === 'built-in' ? 'that came with the Studio' : 'in the folder you chose';
  if (p.source === 'none') return { tone: 'warn', text: 'There are no programs yet. An administrator chooses the programs folder in Settings (the files of a NextGenOS release).' };
  if (!p.ok) return { tone: 'warn', text: `The programs ${where} have a problem: ${p.problems[0] ?? 'they cannot be read'}.` };
  return { tone: p.trial ? 'warn' : 'ok', text: `The website program is in the programs ${where} (release ${p.version})${p.trial ? ', which was made without licence keys and is only to try' : ''}.` };
};

/** The card. Returns the page part; it loads and redraws itself. */
export async function render(ctx) {
  const c = ctx.customer;
  const base = `/api/customers/${encodeURIComponent(ctx.id)}/website-package`;
  const box = h('div', { class: 'card', id: 'site-local' });
  const chosen = new Set();
  let known = false;
  let say = null;      // what the last press said: { kind: 'ok' | 'bad', nodes }
  let status = null;
  let busy = false;

  const showError = (e) => { say = { kind: 'bad', nodes: [h('div', { style: { 'white-space': 'pre-line' } }, e.message)] }; };

  async function load() {
    status = await get(base);
    if (!known) { for (const s of status.systems) if (s.available) chosen.add(s.id); known = true; }
    draw();
  }

  async function putLicence(text) {
    try { status = { ...status, ...(await put(`${base}/licence`, { text })) }; say = { kind: 'ok', nodes: ['The licence file is in place. The next website package will carry it.'] }; toast('The licence file is in place.'); }
    catch (e) { showError(e); }
    draw();
  }

  function licenceBlock() {
    const l = licenceWords(status.licence);
    const file = h('input', { type: 'file', id: 'local-licence-file', accept: '.ngos,.txt,text/plain', 'aria-label': 'The licence file' });
    const paste = h('textarea', { id: 'local-licence-text', rows: 2, spellcheck: 'false', placeholder: 'Or paste what is inside the licence file (one line, it starts with NGOS1.)', 'aria-label': 'The licence file, pasted' });
    const can = ctx.can.build;
    return h('div', { id: 'local-licence', 'data-licence': status.licence.state },
      h('div', { class: 'notice ' + l.tone, id: 'local-licence-say' }, icon(l.tone === 'ok' ? 'check' : 'warn'), h('div', {}, l.text, (status.licence.notes ?? []).map((n) => h('div', { class: 'small mt-s' }, n)))),
      can ? h('div', { class: 'col mt-s' },
        h('p', { class: 'small muted' }, 'The licence for the website is made in the NextGenOS Licence Studio (this Studio cannot ask for it yet). Save the file it gives you, then put it here. The Studio keeps it on this PC only, outside its backups.'),
        h('div', { class: 'row wrap' }, file,
          h('button', { class: 'btn small', id: 'local-licence-put', type: 'button', onclick: async (e) => {
            const picked = file.files?.[0];
            let text = paste.value.trim();
            if (!text) {
              const why = licenceFileProblem(picked);
              if (why) { say = { kind: 'bad', nodes: [why] }; draw(); return; }
              try { text = await picked.text(); } catch { say = { kind: 'bad', nodes: ['The Studio could not read that file.'] }; draw(); return; }
            }
            e.currentTarget.classList.add('busy');
            await putLicence(text);
          } }, icon('upload', 's'), status.licence.state === 'none' ? 'Put the licence file in place' : 'Replace the licence file'),
          status.licence.state !== 'none' ? h('button', { class: 'btn small danger', id: 'local-licence-remove', type: 'button', onclick: async (e) => {
            e.currentTarget.classList.add('busy');
            try { status = { ...status, ...(await del(`${base}/licence`)) }; say = { kind: 'ok', nodes: ['The licence file was taken away.'] }; } catch (x) { showError(x); }
            draw();
          } }, 'Take it away') : null),
        paste)
        : h('p', { class: 'small muted' }, 'Your role cannot put a licence file in place. A reviewer or an administrator does.'));
  }

  async function make(e) {
    if (busy) return;
    const button = e.currentTarget;
    busy = true; button.classList.add('busy'); button.disabled = true;
    say = { kind: 'info', nodes: ['Putting the website together. This takes a little while on a big website; you can stay on this page.'] };
    drawSay();
    try {
      const r = await post(`${base}/make`, { systems: [...chosen], allowTrial: box.querySelector('#local-allow-trial')?.checked === true });
      status = r;
      say = { kind: 'ok', nodes: [h('b', {}, r.results.length > 1 ? 'The website packages are ready.' : 'The website package is ready.'),
        ...r.results.map((x) => h('div', { class: 'small', 'data-result': x.os }, `${x.name} (${SIZE(x.bytes)}). Fingerprint: ${x.sha256.slice(0, 16)}.${x.licenceIncluded ? ' The licence file is inside.' : ' No licence yet: the website will not start until the licence file is added.'}${x.trial ? ' Made from a trial release: only to try.' : ''}`)),
        h('div', { class: 'small' }, 'It is kept in this Studio\'s folder and goes into the customer\'s pack when you make the installer.')] };
      toast('The website package is ready.');
    } catch (x) { showError(x); try { status = await get(base); } catch { /* the error is shown */ } }
    busy = false;
    draw();
  }

  function madeTable() {
    const rows = status.made.filter((m) => !m.replaced);
    if (!rows.length) return null;
    return h('div', { class: 'mt' }, h('h3', {}, 'Made on this PC'),
      h('div', { class: 'panel mt-s' }, h('table', { class: 'tbl', id: 'local-made' }, h('thead', {}, h('tr', {}, ['Made', 'By', 'For', 'Release', 'Size', 'Fingerprint', 'Licence', ''].map((t) => h('th', {}, t)))),
        h('tbody', {}, rows.map((m) => h('tr', { 'data-made': m.os, 'data-release': m.release },
          h('td', { class: 'muted', title: when(m.at), style: { 'white-space': 'nowrap' } }, ago(m.at)), h('td', {}, m.by), h('td', {}, m.label + (m.trial ? ' (trial)' : '')),
          h('td', {}, m.forThisRelease ? String(m.release) : `${m.release} (an older approval)`), h('td', {}, SIZE(m.bytes)),
          h('td', { class: 'tiny muted', title: m.sha256, style: { 'font-family': 'var(--ngos-mono)' } }, m.sha256.slice(0, 16)),
          h('td', {}, m.licenceIncluded ? 'Inside' : 'Not yet'),
          h('td', { class: 'right' }, m.there && ctx.can.build ? h('button', { class: 'btn small', type: 'button', 'data-download-website': m.os, onclick: async () => {
            try { const res = await api('GET', `${base}/${m.release}/${m.os}/website.zip`, undefined, { raw: true }); download(await res.blob(), m.name); } catch (x) { toast(x.message, 'bad'); }
          } }, icon('download', 's'), 'Download') : h('span', { class: 'small muted' }, m.there ? '' : 'No longer there'))))))),
      h('p', { class: 'small muted mt-s' }, 'Give the website to the customer (or put it online) from here, or let it go into the customer\'s pack in the Installer step. The licence file and the customer\'s folder are inside it.'));
  }

  function drawSay() {
    const slot = box.querySelector('#local-say');
    if (!slot) return;
    slot.replaceChildren(...(say ? [h('div', { class: 'notice ' + (say.kind === 'ok' ? 'ok' : say.kind === 'bad' ? 'bad' : ''), id: say.kind === 'bad' ? 'local-problem' : 'local-result', role: say.kind === 'bad' ? 'alert' : 'status' }, icon(say.kind === 'ok' ? 'check' : say.kind === 'bad' ? 'warn' : 'info'), h('div', {}, say.nodes))] : []));
  }

  function draw() {
    const s = status;
    const p = programsWords(s.programs);
    const avail = s.systems.filter((x) => x.available);
    const can = ctx.can.build;
    const ready = s.canMake && can && chosen.size > 0 && !busy;
    // (replaceChildren takes nodes only: nested lists and empty parts are taken out first)
    box.replaceChildren(...[
      h('h2', {}, 'Make the website package'),
      h('p', { class: 'lead' }, `The website is one finished program that is the same for every customer. The Studio puts ${c.name}'s own name, colours, logo and settings beside it, adds ${c.name}'s licence file if you have one, and makes one file. It is all done on this PC: no internet, no GitHub, nothing is built.`),
      s.blockers.map((t) => h('div', { class: 'notice warn mt-s', 'data-local-blocker': '' }, icon('warn'), t)),
      h('div', { class: 'col mt-s' },
        h('div', { class: 'row', style: { 'align-items': 'flex-start' }, id: 'local-programs', 'data-state': s.programs.ok && avail.length ? 'ready' : 'missing' },
          h('span', { class: 'tone-' + (s.programs.ok && avail.length ? p.tone : 'warn'), style: { 'margin-top': '2px' } }, icon(s.programs.ok && avail.length && p.tone === 'ok' ? 'check' : 'warn', 's')),
          h('div', { class: 'grow' }, h('b', {}, '1. The website program'), h('div', { class: 'small muted' }, p.text),
            s.programs.ok && !avail.length ? h('div', { class: 'small muted' }, 'It does not hold the website program (website-linux.zip, website-windows.zip). Ask NextGenOS for the newest release.') : null)),
        h('div', { class: 'row', style: { 'align-items': 'flex-start' }, id: 'local-details' },
          h('span', { class: s.release ? 'tone-ok' : 'tone-warn', style: { 'margin-top': '2px' } }, icon(s.release && !s.blockers.length ? 'check' : 'warn', 's')),
          h('div', { class: 'grow' }, h('b', {}, `2. ${c.name}'s details`), h('div', { class: 'small muted' }, s.release ? `From the approved setup, release ${s.release}.${s.siteName ? ` The website is for ${s.siteName}.` : ' The details do not give the website a name (address) yet, so the website will not know its own address.'}` : 'Approve a setup first.'))),
        h('div', { class: 'row', style: { 'align-items': 'flex-start' } },
          h('span', { class: 'tone-' + (s.licence.state === 'ok' ? 'ok' : 'warn'), style: { 'margin-top': '2px' } }, icon(s.licence.state === 'ok' ? 'check' : 'warn', 's')),
          h('div', { class: 'grow' }, h('b', {}, `3. ${c.name}'s licence file`), licenceBlock()))),
      h('div', { class: 'mt' }, h('span', { class: 'label' }, 'Make it for'),
        h('div', { class: 'row wrap mt-s', id: 'local-systems' }, s.systems.map((x) => h('label', { class: 'row', style: { gap: '8px' } },
          h('input', { type: 'checkbox', 'data-local-system': x.id, checked: chosen.has(x.id), disabled: !x.available || !can || undefined, onchange: (e) => { if (e.target.checked) chosen.add(x.id); else chosen.delete(x.id); draw(); } }),
          h('span', {}, `${x.label}${x.available ? '' : ' (not in the programs)'}`, h('span', { class: 'small muted' }, ` · ${x.who}`)))))),
      s.programs.trial ? h('label', { class: 'row mt-s', style: { gap: '10px' } }, h('input', { type: 'checkbox', id: 'local-allow-trial', disabled: !can || undefined }), h('span', {}, 'This is only to try; it is not for a customer. (The programs were made without licence keys.)')) : null,
      h('div', { class: 'row mt wrap' },
        h('button', { class: 'btn primary', id: 'local-make', type: 'button', disabled: !ready || undefined, onclick: make }, icon('package', 's'), `Make ${c.name}'s website package`),
        !can ? h('span', { class: 'small muted', id: 'local-role-note' }, 'Your role cannot make it. A reviewer or an administrator does this.') : null,
        can && !s.canMake && s.why ? h('span', { class: 'small muted', id: 'local-why' }, s.why) : null,
        can && s.canMake && !chosen.size ? h('span', { class: 'small muted' }, 'Tick at least one system.') : null),
      h('div', { id: 'local-say', class: 'mt-s' }),
      madeTable(),
    ].flat(Infinity).filter(Boolean));
    drawSay();
  }

  await load();
  return box;
}
