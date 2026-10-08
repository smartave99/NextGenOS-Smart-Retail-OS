// The installer step: one customer pack per customer. The programs are the files of a NextGenOS release, copied exactly as they were released; what belongs to this customer
// (their set-up, their look, a page of steps, the hand-over sheet) is added beside them. Nothing is built here, so there is nothing to install on this PC.
import { h, icon, toast, flash, when, ago, download } from '../dom.js';
import { get, post, api } from '../api.js';

const SIZE = (b) => (b >= 1e9 ? (b / 1e9).toFixed(1) + ' GB' : b >= 1e6 ? Math.round(b / 1e6) + ' MB' : Math.max(1, Math.round(b / 1e3)) + ' KB');
const STATUS = { ready: ['check', 'ok', 'Ready'], missing: ['warn', 'warn', 'Not in the programs folder'], skipped: ['info', '', 'Left out'] };

export async function render(ctx) {
  const c = ctx.customer;
  const release = c.releases.at(-1);
  if (!release) return h('div', { class: 'empty' }, h('h2', {}, 'Nothing to make yet'), h('p', {}, 'Approve a setup first. Installers are made from an approved release.'));
  const data = await get(`/api/customers/${encodeURIComponent(ctx.id)}/outputs`);
  const box = h('div', { class: 'col' });
  const kit = data.programs;

  // 1. Where the programs are.
  const programs = h('div', { class: 'card', id: 'programs-card' }, h('h2', {}, 'The programs'),
    kit.folder && kit.ok
      ? h('div', { class: 'col' },
        h('div', { class: 'notice ok', id: 'programs-ok' }, icon('check'), h('div', {}, h('b', {}, `Version ${kit.version}: ${kit.files.length} files checked`), h('div', { class: 'small' }, `Every file matches its fingerprint, so none was damaged on the way.${data.source === 'built-in' ? ' These are the programs that came with the Studio.' : ''}`))),
        h('div', { class: 'row wrap' }, kit.files.map((f) => h('span', { class: 'pill', title: f.name }, `${f.role === 'hub-windows-setup' ? 'Windows setup' : f.role === 'hub-linux-deb' ? 'Linux ' + f.arch : f.role === 'ai-addon-windows' ? 'AI assistant' : f.role === 'android-apk' ? 'Android app' : f.role === 'website' ? 'Website' : f.role} · ${SIZE(f.bytes)}`))),
        kit.trial ? h('div', { class: 'notice warn', id: 'trial-note' }, icon('warn'), 'These programs were built without the licence keys, only to try the installing. A customer could never activate them.') : null,
        /not signed/i.test(kit.signing.windows) ? h('div', { class: 'notice' }, icon('info'), 'The Windows setup is not signed yet, so Windows will show a warning when it is opened. The page of steps tells the customer what to click.') : null,
        /test key/i.test(kit.signing.android) ? h('div', { class: 'notice' }, icon('info'), 'The Android apps were signed with a one-off test key. They are fine to try on a phone, not for a store.') : null)
      : h('div', { class: 'col' },
        h('p', { class: 'lead', style: { 'margin-bottom': 0 } }, kit.folder ? 'There is a problem with the programs folder.' : 'The Studio does not build programs. It puts a customer\'s set-up beside the programs NextGenOS has already built and released.'),
        kit.problems?.length ? h('div', { class: 'notice warn', id: 'programs-problems' }, icon('warn'), h('ul', {}, kit.problems.map((p) => h('li', {}, p)))) : null,
        h('div', { class: 'notice' }, icon('info'), h('div', {}, ctx.can.settings ? 'Download every file of a release into one folder, then ' : 'Ask an administrator to choose the programs folder: ', ctx.can.settings ? h('a', { href: '#/settings', id: 'choose-programs' }, 'choose that folder in Settings') : null, ctx.can.settings ? '.' : '.'))));
  box.append(programs);

  // 2. What goes in the pack.
  const items = data.items ?? [];
  const rows = items.map((i) => {
    const [ic, tone, word] = STATUS[i.status] ?? STATUS.skipped;
    // The website and the app are made for each customer in their own step, not taken from the programs folder.
    const madeHere = ['website', 'android'].includes(i.id) && i.status === 'missing';
    return h('div', { class: 'row', 'data-part': i.id, 'data-status': i.status, style: { 'align-items': 'flex-start', padding: '10px 0', 'border-top': '1px solid var(--ngos-line)' } },
      h('span', { class: 'tone-' + tone, style: { 'margin-top': '2px' } }, icon(ic, 's')),
      h('div', { class: 'grow' }, h('b', {}, i.title), h('div', { class: 'small muted' }, i.note), madeHere ? h('a', { class: 'small', href: `#/customers/${ctx.id}/site`, 'data-open-site': i.id }, 'Open "Website and app"') : null, i.files.length ? h('div', { class: 'tiny muted' }, i.files.join(' · ')) : null),
      h('span', { class: 'pill' + (tone ? ' ' + tone : '') }, madeHere ? 'Not made yet' : word));
  });
  const ready = items.find((i) => i.id === 'shop-pc')?.status === 'ready';
  const result = h('div', { id: 'pack-result' });
  const allow = h('input', { type: 'checkbox', id: 'allow-trial' });
  const make = h('button', { class: 'btn primary', id: 'make-pack', type: 'button', disabled: !ready || !ctx.can.build || undefined, onclick: async (e) => {
    const b = e.currentTarget; b.classList.add('busy'); b.disabled = true;
    try {
      const r = await post(`/api/customers/${encodeURIComponent(ctx.id)}/outputs/pack`, { allowTrial: allow.checked });
      flash(`The pack is made (${SIZE(r.build.bytes)}).`);
      location.reload();
    } catch (x) { toast(x.message, 'bad'); b.classList.remove('busy'); b.disabled = false; }
  } }, icon('package', 's'), `Make ${c.name}'s pack`);
  box.append(h('div', { class: 'card' }, h('h2', {}, `What goes in ${c.name}'s pack`),
    h('p', { class: 'lead' }, `From release ${release.n} (approved ${when(release.approvedAt)}). One folder and one zip file.`),
    items.length ? h('div', { id: 'pack-items' }, rows) : h('p', { class: 'muted' }, 'Choose the programs folder to see what the pack will hold.'),
    data.trial ? h('label', { class: 'row mt-s', style: { gap: '10px' } }, allow, h('span', {}, 'This is only to try the installing; it is not for a customer.')) : null,
    data.trial && !kit.trial ? h('div', { class: 'notice warn mt-s', id: 'site-trial-note' }, icon('warn'), 'The website or app in this pack was made without the licence keys, only to try. A customer could never use it.') : null,
    h('div', { class: 'row mt' }, make, !ctx.can.build ? h('span', { class: 'small muted' }, 'Your role cannot make installers.') : null), result));

  // 3. The website packages made on this PC for this release (the pack takes them from here), with their fingerprints.
  const seenSystem = new Set();
  const sites = [...(data.builds ?? [])].reverse().filter((b) => b.kind === 'website-local' && b.release === release.n && !seenSystem.has(b.os) && seenSystem.add(b.os));
  if (sites.length) {
    box.append(h('div', { class: 'card', id: 'website-packages' }, h('h2', {}, 'Website packages made on this PC'),
      h('div', { class: 'panel mt-s' }, h('div', { style: { 'overflow-x': 'auto' } }, h('table', { class: 'tbl', id: 'website-packages-table' }, h('thead', {}, h('tr', {}, ['Made', 'By', 'For', 'Size', 'Licence', 'Fingerprint'].map((t) => h('th', {}, t)))),
        h('tbody', {}, sites.map((b) => h('tr', { 'data-website-package': b.os }, h('td', { class: 'muted', title: when(b.at), style: { 'white-space': 'nowrap' } }, ago(b.at)), h('td', {}, b.by?.name ?? ''), h('td', {}, (b.os === 'windows' ? 'Windows' : 'Linux') + (b.trial ? ' (trial)' : '')), h('td', {}, SIZE(b.bytes)),
          h('td', {}, b.licenceIncluded ? 'Inside' : 'Not yet'), h('td', { class: 'tiny muted', title: b.sha256, style: { 'font-family': 'var(--ngos-mono)' } }, b.sha256.slice(0, 16)))))))),
      h('p', { class: 'small muted mt-s' }, `They are made in the step "Website and app" and go into the pack as they are. To make one again (a new licence file, new details), do it there, then make the pack again.`)));
  }

  // 4. What was made before.
  const packs = [...(data.builds ?? [])].filter((b) => b.kind === 'pack').reverse();
  const fetchPack = async (b) => { try { const res = await api('GET', `/api/customers/${encodeURIComponent(ctx.id)}/builds/${b.release}/pack.zip`, undefined, { raw: true }); download(await res.blob(), b.file.split('/').pop()); } catch (x) { toast(x.message, 'bad'); } };
  if (packs.length) {
    box.append(h('div', { class: 'card' }, h('h2', {}, 'Packs already made'),
      h('div', { class: 'panel mt-s' }, h('table', { class: 'tbl', id: 'packs' }, h('thead', {}, h('tr', {}, ['Made', 'By', 'Release', 'Programs', 'Size', 'Fingerprint', ''].map((t) => h('th', {}, t)))),
        h('tbody', {}, packs.map((b) => h('tr', {}, h('td', { class: 'muted', title: when(b.at), style: { 'white-space': 'nowrap' } }, ago(b.at)), h('td', { style: { 'white-space': 'nowrap' } }, b.by?.name ?? ''), h('td', {}, String(b.release)), h('td', {}, 'v' + b.programs + (b.trial ? ' (trial)' : '')), h('td', {}, SIZE(b.bytes)),
          h('td', { class: 'tiny muted', style: { 'font-family': 'var(--ngos-mono)' } }, b.sha256.slice(0, 12)),
          h('td', { class: 'right' }, ctx.can.build ? h('button', { class: 'btn small', type: 'button', 'data-download-pack': b.release, onclick: () => fetchPack(b) }, icon('download', 's'), 'Download') : null))))))));
    const last = packs[0];
    const absent = (last.parts ?? []).filter((p) => p.status === 'missing').map((p) => ({ ai: 'the AI assistant', website: 'the built website', android: 'the Android app' })[p.id] ?? p.id);
    result.append(h('div', { class: 'notice ok mt', id: 'last-pack' }, icon('check'), h('div', {}, h('b', {}, 'The latest pack is ready.'), h('div', { class: 'small' }, `Saved in this Studio's folder, under builds.${absent.length ? ' Not in it yet: ' + absent.join(', ') + '.' : ''}`))));
  }
  box.append(h('div', { class: 'card' }, h('h3', {}, 'Before it goes to the customer'),
    h('ul', {}, h('li', {}, 'Make their licence key in the Licence Studio (their number of PCs, and the look level you chose). The shop program\'s key is never in the pack. The website\'s licence file is inside the website package only if you put it in place in the step "Website and app"; otherwise the website will not start until it is added.'),
      h('li', {}, 'Open the pack\'s "START HERE" page and the page of steps for their computer, and check they say the right things.'),
      h('li', {}, 'Open the pack on a clean computer of the same kind once, if you can. The Studio cannot do that for you.'))));
  return box;
}
