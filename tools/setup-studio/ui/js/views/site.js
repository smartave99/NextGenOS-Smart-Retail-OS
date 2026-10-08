// The "Website and app" step.
//   The website: made on this PC, with no GitHub and no internet (website-package.js): the website program from the programs + this customer's folder + this customer's licence file.
//   The Android app: has the customer's name, colours and settings built into it, so it is made by a build service, not on this PC (the website can be made that way too, but need not).
// For the build service the Studio sends this customer's public settings, watches the build and says in plain words which step it is on, then brings the finished files back into this
// customer's folder, from where the installer step puts them in the pack. A salesperson can see what is ready and what would be sent; a reviewer or administrator starts the build.
import { h, icon, toast, when, ago } from '../dom.js';
import { get, post } from '../api.js';
import { render as renderWebsitePackage } from './website-package.js';

const STEP_LOOK = { done: ['check', 'tone-ok'], working: ['refresh', 'muted'], waiting: ['clock', 'muted'], failed: ['warn', 'tone-warn'], skipped: ['info', 'muted'] };
const STEP_WORD = { done: 'done', working: 'going on now', waiting: 'waiting', failed: 'did not work', skipped: 'left out' };
const PART_LOOK = { built: ['check', 'ok', 'Made'], building: ['refresh', '', 'Being made now'], failed: ['warn', 'warn', 'Did not work'], blocked: ['warn', 'warn', 'Cannot be made yet'], missing: ['clock', '', 'Not made yet'] };
const STATE_WORD = { running: 'Going on', fetching: 'Bringing the files back', done: 'Finished', partly: 'Partly finished', failed: 'Did not work', stopped: 'Waiting stopped' };
const STATE_TONE = { running: '', fetching: '', done: 'ok', partly: 'warn', failed: 'bad', stopped: 'warn' };
const active = (b) => b && ['running', 'fetching'].includes(b.state);

export const title = () => 'Website and app';

export async function render(ctx) {
  const c = ctx.customer;
  const release = c.releases.at(-1);
  if (!release) return h('div', { class: 'empty' }, h('h2', {}, 'Nothing to make yet'), h('p', {}, 'Approve a setup first. The website and the app are made from an approved release.'));
  const base = `/api/customers/${encodeURIComponent(ctx.id)}/website-app`;
  const box = h('div', { class: 'col', id: 'site-step' });
  let last = null;
  let timer = null;

  const refresh = async () => {
    try {
      const s = await get(base);
      const was = last?.current;
      last = s;
      draw(s);
      if (was && active(was) && s.current && s.current.n === was.n && !active(s.current)) toast(s.current.state === 'done' ? 'The website and the app are ready.' : s.current.state === 'partly' ? 'Part of the website and app came back.' : 'The build is over: see what it says.', s.current.state === 'done' ? '' : 'bad');
    } catch (e) { if (document.body.contains(box)) toast(e.message, 'bad'); }
    clearTimeout(timer);
    if (document.body.contains(box) && active(last?.current)) timer = setTimeout(refresh, 3000);
  };
  const act = async (e, path, body = {}) => {
    const b = e.currentTarget; b.classList.add('busy');
    try { last = await post(`${base}/${path}`, body); draw(last); clearTimeout(timer); timer = setTimeout(refresh, 1500); } catch (x) { toast(x.message, 'bad'); b.classList.remove('busy'); }
  };

  function draw(s) {
    const cur = s.current;
    const parts = s.parts.filter((p) => p.state !== 'not-wanted');
    const needed = parts.some((p) => !['built', 'blocked'].includes(p.state));
    const failedBefore = parts.some((p) => p.state === 'failed');
    const nodes = [];

    nodes.push(h('div', { class: 'card', id: 'site-service' }, h('h2', {}, 'The Android app, and the other way to get a website'),
      h('p', { class: 'lead' }, `${c.name}'s Android app has ${c.name}'s own name, colours and settings built into it, and making it needs program files that never come to this PC. So the Studio asks the build service (on GitHub) to make it, watches it, and brings the finished file back into this customer's folder. The build service can make the website as well, but you do not need it for that: the website package above is made on this PC. Closing the Studio does not stop a build: open this step again and the Studio picks it up.`),
      !s.service.ready ? h('div', { class: 'notice warn', id: 'site-not-connected' }, icon('warn'), h('div', {}, s.service.why, ctx.can.settings ? [' ', h('a', { href: '#/settings', id: 'open-connect' }, 'Open Settings')] : ' Ask an administrator.')) : null,
      s.blockers.map((t) => h('div', { class: 'notice warn mt-s', 'data-blocker': '' }, icon('warn'), t)),
      (s.notes ?? []).map((t) => h('div', { class: 'notice mt-s', 'data-note': '' }, icon('info'), t))));

    // what will be made
    const rows = parts.map((p) => {
      const [ic, tone, word] = PART_LOOK[p.state] ?? PART_LOOK.missing;
      return h('div', { class: 'row', 'data-part': p.id, 'data-state': p.state, style: { 'align-items': 'flex-start', padding: '10px 0', 'border-top': '1px solid var(--ngos-line)' } },
        h('span', { class: tone ? 'tone-' + tone : 'muted', style: { 'margin-top': '2px' } }, icon(ic, 's' + (p.state === 'building' ? ' spin' : ''))),
        h('div', { class: 'grow' }, h('b', {}, p.words), p.state === 'built' ? h('div', { class: 'small muted' }, `From build ${p.build}${p.trial ? ', made without the licence keys (only to try)' : ''}.`) : null, ['failed', 'blocked'].includes(p.state) && p.message ? h('div', { class: 'small muted' }, p.message) : null),
        h('span', { class: 'pill' + (tone ? ' ' + tone : '') }, word));
    });
    const what = s.wants.website && s.wants.android ? 'website and app' : s.wants.website ? 'website' : 'app';
    const make = h('button', { class: 'btn primary', id: 'site-build', type: 'button', disabled: !s.canStart || !ctx.can.build || undefined, onclick: (e) => act(e, 'build') }, icon('upload', 's'), parts.length && !needed ? 'Make them again' : failedBefore ? 'Try again' : `Build ${c.name}'s ${what}`);
    nodes.push(h('div', { class: 'card' }, h('h2', {}, 'What will be made'),
      h('p', { class: 'lead' }, `From release ${s.release} (approved ${when(release.approvedAt)}). If the details change and a new setup is approved, make them again.`),
      parts.length ? h('div', { id: 'site-parts' }, rows) : h('p', { class: 'muted' }, 'This customer was not set up to get a website or an Android app.'),
      h('div', { class: 'row mt wrap' }, make,
        !ctx.can.build ? h('span', { class: 'small muted', id: 'site-role-note' }, 'Your role cannot start builds. A reviewer or an administrator does this.') : null,
        ctx.can.build && !s.canStart && s.why ? h('span', { class: 'small muted', id: 'site-why' }, s.why) : null)));

    // the build now, or the last one
    if (cur) nodes.push(buildCard(cur));

    // exactly what is sent
    if (s.inputs && s.inputs.files.length) {
      nodes.push(h('div', { class: 'card flat' }, h('h3', {}, 'What is sent to the build service'),
        h('p', { class: 'small muted' }, 'Only this customer\'s public details: the look, the name, the website\'s public settings. No password or key is ever sent. If something in the details looks like one, nothing is sent and the Studio says so.'),
        h('div', { class: 'col mt-s', id: 'site-sent' },
          h('details', { class: 'more' }, h('summary', {}, icon('doc', 's'), 'brand.json: name, colours, contact, words'), h('pre', { class: 'code mt-s' }, s.inputs.brand)),
          h('details', { class: 'more' }, h('summary', {}, icon('doc', 's'), 'website-settings.env: the website\'s public settings'), h('pre', { class: 'code mt-s' }, s.inputs.settings.replace(/\r/g, ''))),
          h('p', { class: 'small muted' }, `Also: ${s.inputs.files.some((f) => f.name.startsWith('logo.')) ? 'the logo, ' : 'no logo, '}and a note of what to build.`))));
    }

    // earlier builds
    const earlier = s.builds.filter((b) => !cur || b.n !== cur.n);
    if (earlier.length) {
      nodes.push(h('div', { class: 'card' }, h('h2', {}, 'Earlier builds'),
        h('div', { class: 'panel mt-s' }, h('table', { class: 'tbl', id: 'site-builds' }, h('thead', {}, h('tr', {}, ['Build', 'Started', 'By', 'Result'].map((t) => h('th', {}, t)))),
          h('tbody', {}, earlier.map((b) => h('tr', { 'data-build': b.n }, h('td', {}, `Build ${b.n}`), h('td', { class: 'muted', title: when(b.startedAt), style: { 'white-space': 'nowrap' } }, ago(b.startedAt)), h('td', {}, b.startedBy), h('td', {}, h('span', { class: 'pill ' + (STATE_TONE[b.state] ?? '') }, STATE_WORD[b.state] ?? b.state), b.trial ? h('span', { class: 'pill warn', style: { 'margin-left': '6px' } }, 'trial') : null))))))));
    }
    box.replaceChildren(...nodes);
  }

  function buildCard(cur) {
    const running = active(cur);
    const done = cur.state === 'done' || cur.state === 'partly';
    return h('div', { class: 'card', id: 'site-current', 'data-state': cur.state },
      h('div', { class: 'row wrap' }, h('div', { class: 'grow' }, h('h2', {}, `Build ${cur.n}`), h('p', { class: 'small muted', style: { margin: '2px 0 0' } }, `Started ${ago(cur.startedAt)} by ${cur.startedBy}.`)),
        h('span', { class: 'pill ' + (STATE_TONE[cur.state] ?? ''), id: 'site-state' }, running ? icon('refresh', 's spin') : null, STATE_WORD[cur.state] ?? cur.state)),
      h('ol', { class: 'col', id: 'site-steps', style: { 'list-style': 'none', padding: 0, margin: '16px 0 0', gap: '8px' } }, cur.steps.map((st) => {
        const [ic, tone] = STEP_LOOK[st.state] ?? STEP_LOOK.waiting;
        return h('li', { class: 'row', 'data-step-state': st.state, style: { 'align-items': 'flex-start', gap: '10px' } }, h('span', { class: tone }, icon(ic, 's' + (st.state === 'working' ? ' spin' : ''))), h('span', { class: 'grow' }, st.words), h('span', { class: 'small muted' }, STEP_WORD[st.state] ?? ''));
      })),
      cur.problem ? h('div', { class: 'notice ' + (cur.state === 'stopped' ? 'warn' : 'bad') + ' mt', id: 'site-problem' }, icon('warn'), h('div', {}, cur.state === 'partly' ? h('b', {}, 'Part of it did not work') : null, h('div', {}, cur.problem))) : null,
      cur.trial ? h('div', { class: 'notice warn mt', id: 'site-trial' }, icon('warn'), 'This build was made without the licence keys, only to try. A customer could never use it. It is never given to a customer.') : null,
      /test key/i.test(cur.signing) ? h('div', { class: 'notice mt' }, icon('info'), 'The Android app was signed with a one-off test key. It is fine to try on a phone, not for a store.') : null,
      done ? h('div', { class: 'notice ok mt', id: 'site-ready' }, icon('check'), h('div', {}, h('b', {}, cur.state === 'done' ? 'The website and the app are ready.' : 'What worked is ready.'), h('div', { class: 'small' }, 'Every file was checked against its fingerprint and is kept in this Studio\'s folder. Make the installer to put them in the customer\'s pack.'))) : null,
      h('div', { class: 'row mt wrap' },
        done ? h('button', { class: 'btn primary', id: 'site-to-installer', type: 'button', onclick: () => ctx.go('installer') }, 'Go to the installer', icon('chevron', 's')) : null,
        cur.canLook && ctx.can.build ? h('button', { class: 'btn', id: 'site-look', type: 'button', onclick: (e) => act(e, 'look') }, icon('refresh', 's'), 'Look again') : null,
        running ? h('span', { class: 'small muted' }, 'You can leave this page or close the Studio. The build carries on.') : null),
      h('details', { class: 'more mt' }, h('summary', {}, icon('info', 's'), 'Details for support'), h('p', { class: 'small muted mt-s' }, `Build name: ${cur.tag}. From release ${cur.release}.`)));
  }

  await refresh();
  // The website package is made on this PC, so it does not wait for the build service; a problem reaching its page must not hide the rest of the step.
  let local = null;
  if (c.intake.ecosystem.website.wanted) {
    try { local = await renderWebsitePackage(ctx); } catch (e) { local = h('div', { class: 'notice warn', id: 'site-local-failed' }, icon('warn'), `The website package part could not be shown: ${e.message}`); }
  }
  return h('div', { class: 'col', id: 'site-both' }, local, box);
}
