// The "Website and app" step: the customer's website and Android app are made for each customer (their name, colours and settings are built in), by a build service, not on this PC.
// The Studio sends it this customer's public settings, watches the build and says in plain words which step it is on, then brings the finished files back into this customer's folder,
// from where the installer step puts them in the pack. A salesperson can see what is ready and what would be sent; a reviewer or administrator starts the build.
import { h, icon, toast, when, ago, confirmSheet } from '../dom.js';
import { get, post, ApiError } from '../api.js';

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
  const licenceBase = `/api/customers/${encodeURIComponent(ctx.id)}/licences`;
  let last = null;
  let timer = null;
  // The customer's licence, as the Licence Studio has it now (asked once, and again after a build is started): the step says whether a licence will be asked for, or was.
  let licence = null;
  const loadLicence = async () => { try { licence = await get(licenceBase); } catch { licence = null; } if (last) draw(last); };

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
    try {
      last = await post(`${base}/${path}`, body); draw(last); clearTimeout(timer); timer = setTimeout(refresh, 1500);
      if (path === 'build') { loadLicence(); if (last.licence?.outcome === 'made') toast('The licence was made. Open the Licence step to show the key and hand it over.'); }
    } catch (x) {
      b.classList.remove('busy');
      // The Licence Studio could not be used right now (or the setup does not say which plan): the person may build now and make the licence later.
      if (path === 'build' && x instanceof ApiError && ['licence-service', 'licence-terms'].includes(x.code) && !body.withoutLicence) {
        if (await confirmSheet({ title: 'The licence could not be made', text: `${x.message} You can make the website and the app now and make the licence later: the build is then marked "no licence made yet".`, yes: 'Build without a licence', no: 'Cancel' })) act(e, path, { ...body, withoutLicence: true });
        return;
      }
      toast(x.message, 'bad');
    }
  };

  function draw(s) {
    const cur = s.current;
    const parts = s.parts.filter((p) => p.state !== 'not-wanted');
    const needed = parts.some((p) => !['built', 'blocked'].includes(p.state));
    const failedBefore = parts.some((p) => p.state === 'failed');
    const nodes = [];

    nodes.push(h('div', { class: 'card' }, h('h2', {}, 'Website and app'),
      h('p', { class: 'lead' }, `${c.name}'s website and Android app have ${c.name}'s own name, colours and settings built into them, so each customer's are made for them. The Studio asks the build service to make them, watches it, and brings the finished files back into this customer's folder. Closing the Studio does not stop the build: open this step again and the Studio picks it up.`),
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
    const licenceRow = licenceNote(licence);
    const make = h('button', { class: 'btn primary', id: 'site-build', type: 'button', disabled: !s.canStart || !ctx.can.build || undefined, onclick: (e) => act(e, 'build') }, icon('upload', 's'), parts.length && !needed ? 'Make them again' : failedBefore ? 'Try again' : `Build ${c.name}'s ${what}`);
    nodes.push(h('div', { class: 'card' }, h('h2', {}, 'What will be made'),
      h('p', { class: 'lead' }, `From release ${s.release} (approved ${when(release.approvedAt)}). If the details change and a new setup is approved, make them again.`),
      parts.length ? h('div', { id: 'site-parts' }, rows) : h('p', { class: 'muted' }, 'This customer was not set up to get a website or an Android app.'),
      licenceRow,
      h('div', { class: 'row mt wrap' }, make,
        !ctx.can.build ? h('span', { class: 'small muted', id: 'site-role-note' }, 'Your role cannot start builds. A reviewer or an administrator does this.') : null,
        ctx.can.build && !s.canStart && s.why ? h('span', { class: 'small muted', id: 'site-why' }, s.why) : null)));

    // the build now, or the last one
    if (cur) nodes.push(buildCard(cur));

    // which Android file goes to whom, once a build has brought them back
    if (s.android) nodes.push(androidNote(s.android));

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
      licenceOfBuild(cur.licence),
      cur.trial ? h('div', { class: 'notice warn mt', id: 'site-trial' }, icon('warn'), 'This build was made without the licence keys, only to try. A customer could never use it. It is never given to a customer.') : null,
      /test key/i.test(cur.signing) ? h('div', { class: 'notice mt' }, icon('info'), 'The Android app was signed with a one-off test key. It is fine to try on a phone, not for a store.') : null,
      done ? h('div', { class: 'notice ok mt', id: 'site-ready' }, icon('check'), h('div', {}, h('b', {}, cur.state === 'done' ? 'The website and the app are ready.' : 'What worked is ready.'), h('div', { class: 'small' }, 'Every file was checked against its fingerprint and is kept in this Studio\'s folder. Make the installer to put them in the customer\'s pack.'))) : null,
      h('div', { class: 'row mt wrap' },
        done ? h('button', { class: 'btn primary', id: 'site-to-installer', type: 'button', onclick: () => ctx.go('installer') }, 'Go to the installer', icon('chevron', 's')) : null,
        cur.canLook && ctx.can.build ? h('button', { class: 'btn', id: 'site-look', type: 'button', onclick: (e) => act(e, 'look') }, icon('refresh', 's'), 'Look again') : null,
        running ? h('span', { class: 'small muted' }, 'You can leave this page or close the Studio. The build carries on.') : null),
      h('details', { class: 'more mt' }, h('summary', {}, icon('info', 's'), 'Details for support'), h('p', { class: 'small muted mt-s' }, `Build name: ${cur.tag}. From release ${cur.release}.`)));
  }

  // What the licence step before this build did, so a build made with no licence says so on its face.
  function licenceOfBuild(l) {
    if (!l) return null;
    const link = h('a', { href: `#/customers/${ctx.id}/licence`, id: 'site-open-licence' }, 'Open the Licence step');
    if (l.outcome === 'made') return h('div', { class: 'notice ok mt', id: 'site-licence-made', 'data-licence': 'made' }, icon('check'), h('div', {}, h('b', {}, 'The customer\'s licence was made.'), h('div', { class: 'small' }, `${l.plan ? `Plan: ${l.plan}. ` : ''}Show its key for the hand-over on the Licence step. `, link)));
    if (l.outcome === 'existing') return h('div', { class: 'notice mt', id: 'site-licence-existing', 'data-licence': 'existing' }, icon('info'), h('div', {}, 'The customer already had a licence, so none was made. ', link));
    return h('div', { class: 'notice warn mt', id: 'site-no-licence', 'data-licence': l.outcome }, icon('warn'), h('div', {}, h('b', {}, 'No licence made yet.'),
      h('div', { class: 'small' }, l.outcome === 'skipped' ? 'You chose to make the website and the app without a licence for now. Make the licence later, in the Licence Studio, or press the button again once the licence service works.'
        : 'The licence service is not connected, so no licence was asked for. Make the licence in the Licence Studio, or ask an administrator to connect the licence service (Settings).')));
  }

  /** The line under "What will be made": whether a licence will be asked for when the button is pressed. */
  function licenceNote(l) {
    if (!l) return null;
    if (!l.service.ready) return h('div', { class: 'notice warn mt-s', id: 'site-licence', 'data-licence': 'not-connected' }, icon('warn'), h('div', {}, h('b', {}, 'No licence will be made.'), h('div', { class: 'small' }, 'The licence service is not connected. The website and the app can still be made; the build is then marked "no licence made yet".', ctx.can.settings ? [' ', h('a', { href: '#/settings' }, 'Open Settings')] : ' An administrator connects it in Settings.')));
    if (l.problem) return h('div', { class: 'notice warn mt-s', id: 'site-licence', 'data-licence': 'problem' }, icon('warn'), h('div', {}, h('b', {}, 'The licence cannot be checked now.'), h('div', { class: 'small' }, l.problem)));
    if (l.licences.length) return h('div', { class: 'notice mt-s', id: 'site-licence', 'data-licence': 'there' }, icon('check'), h('div', {}, h('b', {}, 'The customer has a licence.'), h('div', { class: 'small' }, `${l.licences[0].plan ? `Plan: ${l.licences[0].plan}. ` : ''}${l.licences[0].words.kind}, ${l.licences[0].words.pcs}. No other will be made. `, h('a', { href: `#/customers/${ctx.id}/licence` }, 'Open the Licence step'))));
    if (l.expected && !l.expected.ok) return h('div', { class: 'notice warn mt-s', id: 'site-licence', 'data-licence': 'terms' }, icon('warn'), h('div', {}, h('b', {}, 'The licence cannot be asked for yet.'), h('div', { class: 'small' }, l.expected.problem)));
    return h('div', { class: 'notice mt-s', id: 'site-licence', 'data-licence': 'will-ask' }, icon('key'), h('div', {}, h('b', {}, 'The licence is asked for first.'), h('div', { class: 'small' }, l.expected ? `Pressing the button also asks the Licence Studio for this customer's licence (${l.expected.words}). It is asked for only once, even if the button is pressed twice.` : 'Pressing the button also asks the Licence Studio for this customer\'s licence.')));
  }

  /** Which Android file goes to whom. */
  function androidNote(a) {
    return h('div', { class: 'card', id: 'site-android-note' }, h('h2', {}, 'Which Android file goes to whom'),
      h('p', { class: 'lead' }, 'The build brought back two files for the app. They are for different people.'),
      h('dl', { class: 'kv' },
        h('dt', {}, 'The .apk file'), h('dd', { 'data-android': 'apk' }, a.apk ? 'For quick sharing: send it by link or message to the customer\'s own staff, and use it for trials. A phone warns before it installs an app that did not come from the store, so it is not for the general public.' : 'Not in this build.'),
        h('dt', {}, 'The Play Store package (.aab)'), h('dd', { 'data-android': 'aab' }, a.aab ? 'For publishing the app in the Google Play Store under the customer\'s own Google Play account. The customer, or NextGenOS staff for them, sets that account up once; after that, updates reach shoppers through the store.' : 'Not in this build. Make them again to get it.')),
      h('ul', { class: 'small muted', style: { margin: '12px 0 0', 'padding-left': '18px' } },
        h('li', {}, 'The keys that sign the app stay with NextGenOS in a protected place. They are never on a staff PC.'),
        h('li', {}, 'The app opens the customer\'s website, so the website must be online before the app shows anything.'),
        h('li', {}, 'This Studio does not set up the customer\'s Google Play account for them yet.')));
  }

  await refresh();
  loadLicence();
  return box;
}
