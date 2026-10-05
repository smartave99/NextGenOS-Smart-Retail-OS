// Smart Retail POS by NextGenOS: the owner's live view. The shop PC sends the shop's figures to the owner's own
// Supabase project (cloud/supabase-owner-view.sql); this page signs the owner in and shows them, live, from anywhere.
// Only figures reach it: never a customer's name or phone number.
(() => {
  'use strict';

  const config = window.SRPOS_OWNER || {};
  const root = document.getElementById('app');
  const HISTORY_DAYS = 60;
  const STALE_AFTER_MS = 3 * 60 * 1000;
  const REFRESH_EVERY_MS = 60 * 1000;

  const money = new Intl.NumberFormat('en-IN', { style: 'currency', currency: 'INR', maximumFractionDigits: 0 });
  const number = new Intl.NumberFormat('en-IN', { maximumFractionDigits: 2 });
  const clock = new Intl.DateTimeFormat('en-IN', { hour: 'numeric', minute: '2-digit' });
  const clockSeconds = new Intl.DateTimeFormat('en-IN', { hour: 'numeric', minute: '2-digit', second: '2-digit' });
  const dayName = new Intl.DateTimeFormat('en-IN', { weekday: 'short' });
  const weekday = new Intl.DateTimeFormat('en-IN', { weekday: 'long' });
  const shortDate = new Intl.DateTimeFormat('en-IN', { day: 'numeric', month: 'short' });
  const longDate = new Intl.DateTimeFormat('en-IN', { weekday: 'long', day: 'numeric', month: 'long', year: 'numeric' });

  // --- Small DOM helpers: every piece of text goes in as text, never as HTML. ---
  function h(tag, attrs, ...children) {
    const el = document.createElement(tag);
    for (const [key, value] of Object.entries(attrs || {})) {
      if (value === false || value === null || value === undefined) continue;
      if (key === 'class') el.className = value;
      else if (key.startsWith('on')) el.addEventListener(key.slice(2), value);
      else el.setAttribute(key, value === true ? '' : String(value));
    }
    for (const child of children.flat()) {
      if (child === null || child === undefined || child === false) continue;
      el.append(child instanceof Node ? child : document.createTextNode(String(child)));
    }
    return el;
  }

  function svg(tag, attrs, ...children) {
    const el = document.createElementNS('http://www.w3.org/2000/svg', tag);
    for (const [key, value] of Object.entries(attrs || {})) el.setAttribute(key, String(value));
    for (const child of children.flat()) {
      if (child === null || child === undefined || child === false) continue;
      el.append(child instanceof Node ? child : document.createTextNode(String(child)));
    }
    return el;
  }

  function show(...children) {
    root.replaceChildren(...children.flat().filter(Boolean));
  }

  const rupees = (value) => money.format(Math.round(Number(value) || 0));
  const share = (value) => (value === null || value === undefined) ? '' : `${value >= 0 ? '+' : '−'}${Math.round(Math.abs(value) * 100)}%`;
  const hourName = (hour) => { const h12 = hour % 12 === 0 ? 12 : hour % 12; return `${h12} ${hour % 24 < 12 ? 'am' : 'pm'}`; };
  // "18:57" from the shop PC, in the shop's own time, as "6:57 pm".
  const timeOfDay = (text) => {
    const match = /^(\d{2}):(\d{2})$/.exec(text || '');
    if (!match) return '';
    const hour = Number(match[1]);
    return `${hour % 12 === 0 ? 12 : hour % 12}:${match[2]} ${hour < 12 ? 'am' : 'pm'}`;
  };
  const dateOf = (iso) => { const [y, m, d] = String(iso).split('-').map(Number); return new Date(y, m - 1, d); };

  if (!config.supabaseUrl || !config.publicKey || !window.supabase) {
    show(h('section', { class: 'card narrow' },
      h('h1', {}, 'Not set up yet'),
      h('p', {}, 'Put your Supabase project\'s URL and public key in config.js, next to this page. Both are in Supabase: Project Settings, then API Keys.')));
    return;
  }

  const db = window.supabase.createClient(config.supabaseUrl, config.publicKey, {
    auth: { persistSession: true, autoRefreshToken: true, detectSessionInUrl: true },
  });

  const state = {
    session: null,
    shop: null,
    live: null,
    sentAt: null,
    days: [],
    devices: [],
    pairing: null,
    pairingTimer: null,
    openDay: null,
    allBills: false,
    view: location.hash === '#review' ? 'review' : 'today',
    reports: {},
    reportsMissing: false,
    reportsChannel: null,
    problem: null,
    channel: null,
    timer: null,
    recovering: false,
  };

  // --- Signing in ---
  function signInView(mode = 'signin', note = null) {
    const email = h('input', { type: 'email', id: 'email', autocomplete: 'email', required: true, placeholder: 'you@example.com' });
    const password = h('input', { type: 'password', id: 'password', autocomplete: mode === 'signup' ? 'new-password' : 'current-password', required: true, minlength: 8 });
    const message = h('p', { class: note ? 'note' : 'note hidden', role: 'status' }, note || '');
    const button = h('button', { type: 'submit', class: 'primary' }, mode === 'signup' ? 'Create account' : 'Sign in');

    async function submit(event) {
      event.preventDefault();
      button.disabled = true;
      message.className = 'note';
      message.textContent = mode === 'signup' ? 'Creating your account…' : 'Signing in…';
      const credentials = { email: email.value.trim(), password: password.value };
      const { data, error } = mode === 'signup'
        ? await db.auth.signUp({ ...credentials, options: { emailRedirectTo: location.href.split('#')[0] } })
        : await db.auth.signInWithPassword(credentials);
      button.disabled = false;
      if (error) {
        message.className = 'note problem';
        message.textContent = error.message;
      } else if (mode === 'signup' && !data.session) {
        message.textContent = 'Check your email and open the link to confirm, then sign in here.';
      }
    }

    async function forgot() {
      if (!email.value.trim()) {
        message.className = 'note problem';
        message.textContent = 'Type your email first.';
        return;
      }
      const { error } = await db.auth.resetPasswordForEmail(email.value.trim(), { redirectTo: location.href.split('#')[0] });
      message.className = error ? 'note problem' : 'note';
      message.textContent = error ? error.message : 'Check your email for a link to set a new password.';
    }

    show(h('section', { class: 'card narrow sign-in' },
      h('div', { class: 'brand' }, h('span', { class: 'mark', 'aria-hidden': 'true' }), 'Smart Retail POS'),
      h('h1', {}, mode === 'signup' ? 'Create the owner\'s account' : 'See your shop, live'),
      h('p', { class: 'muted' }, mode === 'signup'
        ? 'The first account creates the shop. The shop PC then sends its figures here.'
        : 'Sign in to see today\'s sales, bills and stock from anywhere.'),
      h('form', { onsubmit: submit },
        h('label', { for: 'email' }, 'Email'), email,
        h('label', { for: 'password' }, 'Password'), password,
        button),
      message,
      h('div', { class: 'links' },
        mode === 'signup'
          ? h('button', { type: 'button', class: 'link', onclick: () => signInView('signin') }, 'I have an account: sign in')
          : [h('button', { type: 'button', class: 'link', onclick: () => signInView('signup') }, 'Create an account'),
             h('button', { type: 'button', class: 'link', onclick: forgot }, 'Forgot the password?')])));
  }

  function newPasswordView() {
    const password = h('input', { type: 'password', id: 'new-password', autocomplete: 'new-password', required: true, minlength: 8 });
    const message = h('p', { class: 'note hidden', role: 'status' });
    async function submit(event) {
      event.preventDefault();
      const { error } = await db.auth.updateUser({ password: password.value });
      message.className = error ? 'note problem' : 'note';
      message.textContent = error ? error.message : 'Saved.';
      if (!error) {
        state.recovering = false;
        loadShop();
      }
    }
    show(h('section', { class: 'card narrow' },
      h('h1', {}, 'Set a new password'),
      h('form', { onsubmit: submit }, h('label', { for: 'new-password' }, 'New password'), password, h('button', { type: 'submit', class: 'primary' }, 'Save')),
      message));
  }

  // --- The shop ---
  async function loadShop() {
    const { data, error } = await db.from('shops').select('id, name').order('created_at').limit(1);
    if (error) return problemView(error.message);
    if (!data.length) return createShopView();
    state.shop = data[0];
    await refresh(true);
    listen();
  }

  function createShopView(note = null) {
    const name = h('input', { id: 'shop-name', required: true, maxlength: 120, placeholder: 'Smart Avenue 99' });
    const message = h('p', { class: note ? 'note problem' : 'note hidden', role: 'status' }, note || '');
    async function submit(event) {
      event.preventDefault();
      const { error } = await db.rpc('create_shop', { p_name: name.value });
      if (error) {
        message.className = 'note problem';
        message.textContent = error.message;
        return;
      }
      loadShop();
    }
    show(topBar(), h('section', { class: 'card narrow' },
      h('h1', {}, 'Name your shop'),
      h('p', { class: 'muted' }, 'Then connect the shop PC with a code, and its figures show here.'),
      h('form', { onsubmit: submit }, h('label', { for: 'shop-name' }, 'Shop name'), name, h('button', { type: 'submit', class: 'primary' }, 'Create the shop')),
      message));
  }

  function problemView(text) {
    show(topBar(), h('section', { class: 'card narrow' }, h('h1', {}, 'Something went wrong'), h('p', { class: 'note problem' }, text),
      h('button', { type: 'button', onclick: () => loadShop() }, 'Try again')));
  }

  async function refresh(withDays = false) {
    const shopId = state.shop.id;
    const since = new Date(Date.now() - HISTORY_DAYS * 86400000).toISOString().slice(0, 10);
    const [live, devices, days, reports] = await Promise.all([
      db.from('shop_live').select('data, sent_at').eq('shop_id', shopId).maybeSingle(),
      loadDevices(shopId),
      withDays ? db.from('shop_days').select('day, data').eq('shop_id', shopId).gte('day', since).order('day') : Promise.resolve(null),
      withDays ? db.from('shop_reports').select('kind, data, sent_at').eq('shop_id', shopId) : Promise.resolve(null),
    ]);
    state.problem = live.error?.message || devices.error?.message || days?.error?.message || null;
    if (reports) {
      // A project whose script is older than this page has no reports table: that only means no weekly screens yet.
      state.reportsMissing = Boolean(reports.error) && (reports.error.code === 'PGRST205' || reports.error.code === '42P01' || reports.status === 404);
      if (reports.error && !state.reportsMissing) state.problem = state.problem || reports.error.message;
      if (reports.data) state.reports = Object.fromEntries(reports.data.map(r => [r.kind, { data: r.data, sentAt: new Date(r.sent_at) }]));
    }
    if (live.data) {
      state.live = live.data.data;
      state.sentAt = new Date(live.data.sent_at);
    }
    if (devices.data) setDevices(devices.data);
    if (days && days.data) state.days = days.data.map(d => d.data);
    render();
  }

  // Which PC is the main one came with the script of version 2.18.0; a project with an older script has no such column, and answers
  // without it, so the list is asked for again with what that script has.
  async function loadDevices(shopId) {
    const wanted = await db.from('shop_devices').select('id, label, connected_at, last_seen_at, is_main').eq('shop_id', shopId).order('connected_at');
    if (!wanted.error || wanted.error.code !== '42703') return wanted;
    return db.from('shop_devices').select('id, label, connected_at, last_seen_at').eq('shop_id', shopId).order('connected_at');
  }

  async function refreshDevices() {
    const { data, error } = await loadDevices(state.shop.id);
    if (error) return;
    setDevices(data);
    render();
  }

  // A shop PC that appears while a code is showing has just connected with it.
  function setDevices(devices) {
    if (devices.length > state.devices.length && state.pairing && state.pairing.code) {
      state.pairing = { connected: devices[devices.length - 1].label };
      clearInterval(state.pairingTimer);
    }
    state.devices = devices;
  }

  // New figures arrive the moment the shop PC sends them; a look every minute covers a lost connection.
  function listen() {
    if (state.channel) db.removeChannel(state.channel);
    state.channel = db.channel('shop-live-' + state.shop.id)
      .on('postgres_changes', { event: '*', schema: 'public', table: 'shop_live', filter: `shop_id=eq.${state.shop.id}` }, (change) => {
        if (change.new && change.new.data) {
          state.live = change.new.data;
          state.sentAt = new Date(change.new.sent_at);
          mergeToday();
          render();
          if (state.days.length < 2) refresh(true);
          else if (!state.devices.length) refreshDevices();
        }
      })
      .subscribe();
    // The reports have a channel of their own: in a project whose script is older they are not published, and that must not spoil the live one.
    if (state.reportsChannel) db.removeChannel(state.reportsChannel);
    state.reportsChannel = db.channel('shop-reports-' + state.shop.id)
      .on('postgres_changes', { event: '*', schema: 'public', table: 'shop_reports', filter: `shop_id=eq.${state.shop.id}` }, (change) => {
        if (change.new && change.new.kind && change.new.data) {
          state.reports[change.new.kind] = { data: change.new.data, sentAt: new Date(change.new.sent_at) };
          state.reportsMissing = false;
          render();
        }
      })
      .subscribe();
    clearInterval(state.timer);
    state.timer = setInterval(() => refresh(new Date().getMinutes() % 10 === 0), REFRESH_EVERY_MS);
  }

  // Today's figures also go into the history's last day.
  function mergeToday() {
    const today = state.live?.today;
    if (!today) return;
    const day = { day: today.day, sales: today.sales, bills: today.bills, returns: 0, hours: (state.live.hours || []).map(x => ({ hour: x.hour, sales: x.sales, bills: x.bills })), top: (state.live.top || []).slice(0, 5) };
    const index = state.days.findIndex(d => d.day === today.day);
    if (index >= 0) state.days[index] = { ...state.days[index], ...day, returns: state.days[index].returns };
    else state.days.push(day);
  }

  // While a code is showing, look for the shop PC every few seconds, to say when it has connected.
  async function makeCode() {
    const { data, error } = await db.rpc('new_pairing_code', { p_shop: state.shop.id });
    state.pairing = error ? { problem: error.message } : { code: data, until: Date.now() + 15 * 60 * 1000 };
    render();
    clearInterval(state.pairingTimer);
    if (!error) {
      state.pairingTimer = setInterval(() => {
        if (!state.pairing || !state.pairing.code || state.pairing.until < Date.now()) clearInterval(state.pairingTimer);
        else refreshDevices();
      }, 5000);
    }
  }

  async function disconnect(device) {
    if (!confirm(`Disconnect ${device.label}? It stops sending at once; it can be connected again with a new code.`)) return;
    const { error } = await db.from('shop_devices').delete().eq('id', device.id);
    state.problem = error ? error.message : null;
    if (!error) state.pairing = null;
    await refresh();
  }

  // --- The live view ---
  function topBar() {
    return h('header', { class: 'top' },
      h('div', { class: 'brand' }, h('span', { class: 'mark', 'aria-hidden': 'true' }), 'Smart Retail POS'),
      state.session ? h('button', { type: 'button', class: 'link', onclick: signOut }, 'Sign out') : null);
  }

  function liveState() {
    if (!state.sentAt) return h('span', { class: 'pill warn' }, 'Waiting for the shop PC');
    const age = Date.now() - state.sentAt.getTime();
    return age > STALE_AFTER_MS
      ? h('span', { class: 'pill warn', title: 'Is the shop PC on, with Smart Retail POS open and the internet working?' }, `Last sent ${clock.format(state.sentAt)}${age > 86400000 ? ', ' + shortDate.format(state.sentAt) : ''}`)
      : h('span', { class: 'pill live' }, h('i', { class: 'dot', 'aria-hidden': 'true' }), `Live · ${clockSeconds.format(state.sentAt)}`);
  }

  function render() {
    if (!state.shop) return;
    const live = state.live;
    const parts = [topBar()];
    parts.push(h('div', { class: 'heading' },
      h('div', {}, h('p', { class: 'eyebrow' }, live ? longDate.format(dateOf(live.today.day)) : ''), h('h1', {}, state.shop.name)),
      liveState()));
    if (state.problem) parts.push(h('p', { class: 'note problem' }, state.problem));
    if (live && live.demo) parts.push(h('p', { class: 'note' }, 'These are the demo shop\'s figures: the shop PC has not found the POS database.'));

    parts.push(tabs());
    if (state.view === 'review') {
      parts.push(...reviewView());
    } else if (!live) {
      parts.push(h('section', { class: 'card' }, h('h2', {}, 'No figures yet'),
        h('p', { class: 'muted' }, 'Connect the shop PC below. Its figures show here within a minute.')));
    } else {
      parts.push(todayCard(live), hoursCard(live), billsCard(live),
        h('div', { class: 'grid' }, weekCard(live), topCard(live), stockCard(live), fixCard(live)),
        historyCard());
    }
    if (state.view !== 'review') parts.push(devicesCard());
    parts.push(h('p', { class: 'foot' }, 'Figures from the shop PC. Customer names and phone numbers never leave the shop.'));
    show(parts);
  }

  // --- The screens: Today, and the weekly review ---
  function tabs() {
    const tab = (view, label) => h('button', { type: 'button', role: 'tab', class: state.view === view ? 'tab on' : 'tab', 'aria-selected': state.view === view ? 'true' : 'false', onclick: () => showView(view) }, label);
    return h('div', { class: 'tabs', role: 'tablist', 'aria-label': 'Screens' }, tab('today', 'Today'), tab('review', 'Last week'));
  }

  function showView(view) {
    state.view = view;
    history.replaceState(null, '', view === 'review' ? '#review' : location.pathname + location.search);
    render();
  }

  window.addEventListener('hashchange', () => {
    const view = location.hash === '#review' ? 'review' : 'today';
    if (view !== state.view && state.shop) { state.view = view; render(); }
  });

  // "21–27 Sep", or "29 Sep – 5 Oct" when the week crosses a month; with the year when asked.
  function weekName(from, to, withYear = false) {
    const a = dateOf(from);
    const b = dateOf(to);
    const year = withYear ? ' ' + b.getFullYear() : '';
    return a.getMonth() === b.getMonth()
      ? `${a.getDate()}–${shortDate.format(b)}${year}`
      : `${shortDate.format(a)} – ${shortDate.format(b)}${year}`;
  }

  // 0.12 is "▲ 12%", under half a percent is "same"; null when there is nothing to compare with.
  const growth = (now, before) => before > 0 ? (now - before) / before : null;
  const change = (g) => g === null ? '' : Math.abs(g) < 0.005 ? 'same' : `${g > 0 ? '▲' : '▼'} ${Math.round(Math.abs(g) * 100)}%`;
  const tone = (g) => g === null || Math.abs(g) < 0.005 ? '' : g > 0 ? 'up' : 'down';

  function reviewView() {
    if (state.reportsMissing) {
      return [h('section', { class: 'card' }, h('h2', {}, 'The weekly review needs a newer script'),
        h('p', { class: 'muted' }, 'Run supabase-owner-view.sql in your project\'s SQL Editor once more; running it again is safe. The shop PC then sends last week\'s review within the hour.'))];
    }
    const report = state.reports.review;
    if (!report) {
      return [h('section', { class: 'card' }, h('h2', {}, 'No review yet'),
        h('p', { class: 'muted' }, 'The shop PC sends last week\'s review once an hour, from the version of Smart Retail POS that has it. It shows here soon after that.'))];
    }
    const r = report.data;
    const week = r.thisWeek;
    const before = r.weekBefore;
    const stat = (label, value, delta, extra) => h('div', { class: 'card stat' },
      h('p', { class: 'label' }, label), h('p', { class: 'figure' }, value), delta, extra);
    const versus = (now, was, show) => {
      const g = growth(now, was);
      return g === null
        ? h('p', { class: 'delta' }, `${show(was)} the week before`)
        : h('p', { class: `delta ${tone(g)}` }, change(g), h('span', {}, ` vs ${show(was)}`));
    };
    const year = r.yearBefore;
    const yearGrowth = year ? growth(week.sales, year.sales) : null;
    const stale = Date.now() - report.sentAt.getTime() > 3 * 60 * 60 * 1000;
    return [
      h('div', { class: 'card-head review-head' },
        h('h2', {}, `Last week, ${weekName(week.from, week.to)}`),
        r.reviewedOn
          ? h('span', { class: 'pill live' }, `Reviewed on ${shortDate.format(dateOf(r.reviewedOn))}`)
          : h('span', { class: 'pill warn', title: 'At the shop, open Monday review in Smart Retail POS and mark the week as reviewed.' }, 'Not reviewed yet')),
      // The note above the tabs already says so when the live figures are the demo's too.
      r.demo && !(state.live && state.live.demo) ? h('p', { class: 'note' }, 'These are the demo shop\'s figures: the shop PC has not found the POS database.') : null,
      h('div', { class: 'stats' },
        stat('Sales', rupees(week.sales), versus(week.sales, before.sales, rupees)),
        stat('Bills', number.format(week.bills), versus(week.bills, before.bills, number.format)),
        stat('Average bill', rupees(week.averageBill), versus(week.averageBill, before.averageBill, rupees)),
        stat('Profit before GST', week.profit === null || week.profit === undefined ? '–' : rupees(week.profit),
          h('p', { class: 'delta' }, week.margin === null || week.margin === undefined ? 'No purchase prices recorded' : `${Math.round(week.margin * 100)}% margin`))),
      h('p', { class: 'muted small review-year' }, year
        ? `The same week a year before (${weekName(year.from, year.to, true)}): ${rupees(year.sales)} from ${number.format(year.bills)} bills${yearGrowth === null ? '.' : `, so last week was ${change(yearGrowth)}.`}`
        : 'The POS has no bills from the same week a year before, so the week is compared with the week before only.'),
      h('div', { class: 'grid' }, runningOutCard(r.runningOut || []), notSellingCard(r.notSelling || [])),
      h('p', { class: 'muted small' }, stale
        ? `Last sent ${clock.format(report.sentAt)}, ${shortDate.format(report.sentAt)}. `
        : `Sent at ${clock.format(report.sentAt)}. `,
        'The rules only suggest. Your decisions, what the shop is trying and the new products to decide are in Monday review on the shop PC.'),
    ];
  }

  function runningOutCard(items) {
    return h('section', { class: 'card' },
      h('div', { class: 'card-head' }, h('h2', {}, 'Running out'), h('span', { class: 'muted small' }, 'Regular sellers with under a week of stock')),
      items.length
        ? h('ul', { class: 'rows' }, items.map(p => h('li', {},
            h('span', {}, p.name, p.perDay > 0 ? h('small', {}, `sells about ${number.format(p.perDay)} a day`) : null),
            h('span', { class: `pill ${p.inHand <= 0 ? 'bad' : 'warn'}` }, p.inHand <= 0 ? 'Out of stock' : `${number.format(p.inHand)} left`))))
        : h('p', { class: 'muted' }, 'Nothing is running out.'));
  }

  function notSellingCard(items) {
    return h('section', { class: 'card' },
      h('div', { class: 'card-head' }, h('h2', {}, 'Not selling'), h('span', { class: 'muted small' }, 'In stock, not sold in 8 weeks')),
      items.length
        ? h('ul', { class: 'rows' }, items.map(p => h('li', {},
            h('span', {}, p.name, h('small', {}, `${number.format(p.inHand)} in stock`)),
            h('span', { class: 'muted' }, `${rupees(p.value)} tied up`))))
        : h('p', { class: 'muted' }, 'Nothing in stock has gone 8 weeks unsold.'));
  }

  function todayCard(live) {
    const t = live.today;
    const versus = t.vsLastWeek === null || t.vsLastWeek === undefined
      ? h('p', { class: 'delta' }, `Nothing to compare with last ${weekday.format(dateOf(t.day))}`)
      : h('p', { class: `delta ${t.vsLastWeek >= 0 ? 'up' : 'down'}` }, share(t.vsLastWeek),
          h('span', {}, ` vs last ${weekday.format(dateOf(t.day))}${t.comparedAt ? ' by ' + timeOfDay(t.comparedAt) : ''} (${rupees(t.lastWeekSales)})`));
    return h('section', { class: 'card hero' },
      h('p', { class: 'label' }, 'Sales today', t.lastBillAt ? ` · last bill at ${timeOfDay(t.lastBillAt)}` : ''),
      h('p', { class: 'figure' }, rupees(t.sales)),
      versus,
      h('div', { class: 'facts' },
        fact(String(t.bills), t.bills === 1 ? 'bill' : 'bills'),
        fact(t.bills ? rupees(t.sales / t.bills) : '–', 'average bill'),
        fact(rupees(t.credit), 'on credit')));
  }

  const fact = (value, label) => h('div', {}, h('strong', {}, value), h('span', {}, label));

  function hoursCard(live) {
    const hours = live.hours || [];
    if (!hours.length) return null;
    const nowHour = live.today.lastBillAt ? Number(live.today.lastBillAt.slice(0, 2)) : -1;
    return h('section', { class: 'card' },
      h('div', { class: 'card-head' }, h('h2', {}, 'Today by the hour'),
        h('div', { class: 'legend' }, h('span', {}, h('i', { class: 'swatch now' }), 'Today'), h('span', {}, h('i', { class: 'swatch ghost' }), 'Same day last week'))),
      bars(hours.map(x => ({ label: hourName(x.hour), value: x.sales, ghost: x.lastWeekSales, hi: x.hour === nowHour,
        title: `${hourName(x.hour)}: ${rupees(x.sales)} from ${x.bills} bills today; ${rupees(x.lastWeekSales)} last week` }))));
  }

  function billsCard(live) {
    const bills = live.bills || [];
    const list = h('ul', { class: 'bills' }, (state.allBills ? bills : bills.slice(0, 20)).map(billRow));
    const more = bills.length > 20 && !state.allBills
      ? h('button', { type: 'button', class: 'link', onclick: () => { state.allBills = true; render(); } }, `Show all ${bills.length} bills`)
      : null;
    return h('section', { class: 'card' },
      h('div', { class: 'card-head' }, h('h2', {}, 'Today\'s bills'), h('span', { class: 'muted' }, `${bills.length} so far`)),
      bills.length ? list : h('p', { class: 'muted' }, 'No bills yet today.'), more);
  }

  function billRow(bill) {
    return h('li', {},
      h('span', { class: 'time' }, bill.later ? 'entered later' : timeOfDay(bill.time) || '–'),
      h('span', { class: 'number' }, bill.number),
      h('span', { class: 'amount' }, rupees(bill.total), bill.due > 0 ? h('small', {}, `${rupees(bill.due)} due`) : null));
  }

  function weekCard(live) {
    const week = live.week || [];
    return h('section', { class: 'card' },
      h('div', { class: 'card-head' }, h('h2', {}, 'Last 7 days'), h('span', { class: 'muted' }, rupees(week.reduce((sum, d) => sum + d.sales, 0)))),
      bars(week.map((d, i) => ({ label: i === week.length - 1 ? 'Today' : dayName.format(dateOf(d.day)), value: d.sales, hi: i === week.length - 1,
        title: `${shortDate.format(dateOf(d.day))}: ${rupees(d.sales)} from ${d.bills} bills` })), { narrow: true, labelAll: true }));
  }

  function topCard(live) {
    const top = live.top || [];
    return h('section', { class: 'card' }, h('h2', {}, 'Best sellers today'),
      top.length ? h('ol', { class: 'rows' }, top.map(p => h('li', {}, h('span', {}, p.name), h('span', { class: 'muted' }, `${number.format(p.qty)} · ${rupees(p.sales)}`))))
        : h('p', { class: 'muted' }, 'Nothing sold yet today.'));
  }

  function stockCard(live) {
    const low = live.lowStock || [];
    return h('section', { class: 'card' }, h('h2', {}, 'Running low'),
      low.length ? h('ul', { class: 'rows' }, low.map(s => h('li', {}, h('span', {}, s.name),
        h('span', { class: `pill ${s.left <= 0 ? 'bad' : 'warn'}` }, s.left <= 0 ? 'Out of stock' : `${number.format(s.left)} left of ${number.format(s.reorderAt)}`))))
        : h('p', { class: 'muted' }, 'Every product is above its reorder level.'));
  }

  function fixCard(live) {
    const fix = live.fixNow || { count: 0, items: [] };
    return h('section', { class: 'card' },
      h('div', { class: 'card-head' }, h('h2', {}, 'Fix now'), fix.count ? h('span', { class: 'pill bad' }, String(fix.count)) : null),
      fix.items.length ? h('ul', { class: 'rows' }, fix.items.map(f => h('li', {}, h('span', {}, f.kind, f.title ? h('small', {}, f.title) : null),
        h('span', { class: `pill ${f.now ? 'bad' : 'warn'}` }, f.now ? 'Now' : 'Soon'))))
        : h('p', { class: 'muted' }, 'Nothing needs fixing.'),
      fix.items.length ? h('p', { class: 'muted small' }, 'Fixed in the POS at the shop; the details are on the Fix now page there.') : null);
  }

  function historyCard() {
    const days = state.days.slice(-HISTORY_DAYS);
    if (days.length < 2) return null;
    const total = days.reduce((sum, d) => sum + d.sales, 0);
    const open = state.openDay && days.find(d => d.day === state.openDay);
    return h('section', { class: 'card' },
      h('div', { class: 'card-head' }, h('h2', {}, `Last ${days.length} days`), h('span', { class: 'muted' }, rupees(total))),
      bars(days.map(d => ({ label: shortDate.format(dateOf(d.day)), value: d.sales, hi: d.day === state.openDay, onclick: () => { state.openDay = d.day; render(); },
        title: `${shortDate.format(dateOf(d.day))}: ${rupees(d.sales)} from ${d.bills} bills` })), { labelEvery: window.innerWidth > 700 ? 6 : 10 }),
      open ? h('div', { class: 'day' },
        h('h3', {}, `${longDate.format(dateOf(open.day))}: ${rupees(open.sales)} from ${open.bills} bills`),
        open.hours && open.hours.length ? bars(open.hours.map(x => ({ label: hourName(x.hour), value: x.sales, title: `${hourName(x.hour)}: ${rupees(x.sales)}` }))) : null,
        open.top && open.top.length ? h('ol', { class: 'rows' }, open.top.map(p => h('li', {}, h('span', {}, p.name), h('span', { class: 'muted' }, rupees(p.sales))))) : null)
        : h('p', { class: 'muted small' }, 'Tap a day to see its hours and best sellers.'));
  }

  // With more than one PC, which is the main one: only it sends the figures and the products, the others are counters.
  function roleOf(device) {
    if (state.devices.length < 2 || typeof device.is_main !== 'boolean') return null;
    return h('span', { class: device.is_main ? 'pill live role' : 'pill quiet role', title: device.is_main ? 'This PC sends the shop\'s figures' : 'A counter PC sends nothing' }, device.is_main ? 'Main PC' : 'Counter');
  }

  function devicesCard() {
    const pairing = state.pairing;
    const code = pairing && pairing.code && pairing.until > Date.now() ? pairing.code : null;
    return h('section', { class: 'card', id: 'shop-pcs' },
      h('div', { class: 'card-head' }, h('h2', {}, 'Shop PCs'),
        h('button', { type: 'button', class: 'primary small', onclick: makeCode }, code ? 'New code' : 'Connect a shop PC')),
      state.devices.length
        ? h('ul', { class: 'rows' }, state.devices.map(d => h('li', {},
            h('span', {}, d.label, roleOf(d), h('small', {}, d.last_seen_at ? `Last sent ${clock.format(new Date(d.last_seen_at))}, ${shortDate.format(new Date(d.last_seen_at))}` : 'Not sent yet')),
            h('button', { type: 'button', class: 'link danger', onclick: () => disconnect(d) }, 'Disconnect'))))
        : h('p', { class: 'muted' }, 'No shop PC is connected yet.'),
      pairing && pairing.problem ? h('p', { class: 'note problem' }, pairing.problem) : null,
      pairing && pairing.connected ? h('p', { class: 'note' }, `${pairing.connected} is connected. Its figures show here within a minute.`) : null,
      code ? h('div', { class: 'pairing' },
        h('p', {}, 'On the shop PC, open Smart Retail POS, then Settings, then Owner\'s live view. Paste the project URL and public key, type this code and press Connect. The code works once, for 15 minutes.'),
        h('p', { class: 'code', id: 'pairing-code' }, code.slice(0, 4) + '-' + code.slice(4)),
        h('dl', {}, h('dt', {}, 'Project URL'), h('dd', { class: 'mono' }, config.supabaseUrl), h('dt', {}, 'Public key'), h('dd', { class: 'mono key' }, config.publicKey)))
        : null);
  }

  // Columns for a chart: one per entry, the highest touching the top; pale columns behind for last week. Drawn at
  // about the size it shows, so its labels stay readable on a phone.
  function bars(entries, { narrow = false, labelAll = false, labelEvery = 0 } = {}) {
    const room = Math.max(280, Math.min(window.innerWidth, 980) - 64);
    const width = Math.round(narrow && window.innerWidth > 700 ? Math.min(room, 300) : Math.min(room, 900));
    const height = 170;
    const base = height - 22;
    const top = 10;
    const slot = width / Math.max(1, entries.length);
    const highest = Math.max(1, ...entries.map(e => Math.max(e.value || 0, e.ghost || 0)));
    const y = (v) => base - (Math.max(0, v || 0) / highest) * (base - top);
    const every = labelAll ? 1 : labelEvery || (slot >= 44 ? 1 : slot >= 24 ? 2 : 3);
    // The first and last labels keep inside the chart.
    const label = (e, i, centre) => {
      const first = i === 0 && slot < 60;
      const last = i === entries.length - 1 && slot < 60;
      return svg('text', { x: first ? 0 : last ? width : centre, y: height - 6, 'text-anchor': first ? 'start' : last ? 'end' : 'middle',
        class: e.hi ? 'tick hi' : 'tick' }, e.label);
    };
    return svg('svg', { class: 'chart', viewBox: `0 0 ${width} ${height}`, role: 'img', 'aria-label': 'Chart' },
      svg('line', { x1: 0, x2: width, y1: base, y2: base, class: 'axis' }),
      entries.map((e, i) => {
        const centre = slot * i + slot / 2;
        const w = Math.min(28, slot * 0.7);
        const g = svg('g', { class: e.onclick ? 'pick' : '' },
          svg('title', {}, e.title || ''),
          svg('rect', { x: slot * i, y: 0, width: slot, height, class: 'hit' }),
          e.ghost > 0 ? svg('rect', { x: centre - w / 2, y: y(e.ghost), width: w, height: base - y(e.ghost), rx: 3, class: 'bar ghost' }) : null,
          e.value > 0 ? svg('rect', { x: centre - (e.ghost !== undefined ? w * 0.3 : w / 2), y: y(e.value), width: e.ghost !== undefined ? w * 0.6 : w, height: base - y(e.value), rx: 3, class: e.hi ? 'bar hi' : 'bar' }) : null,
          (i % every === 0 || e.hi) ? label(e, i, centre) : null);
        if (e.onclick) g.addEventListener('click', e.onclick);
        return g;
      }));
  }

  async function signOut() {
    if (state.channel) db.removeChannel(state.channel);
    if (state.reportsChannel) db.removeChannel(state.reportsChannel);
    clearInterval(state.timer);
    clearInterval(state.pairingTimer);
    Object.assign(state, { shop: null, live: null, sentAt: null, days: [], devices: [], pairing: null, channel: null, reportsChannel: null, reports: {}, reportsMissing: false, timer: null, pairingTimer: null });
    await db.auth.signOut();
  }

  let resizing = null;
  window.addEventListener('resize', () => {
    clearTimeout(resizing);
    resizing = setTimeout(() => { if (state.shop) render(); }, 200);
  });

  // Keeps "Live" honest when nothing arrives, and the code's time limit.
  setInterval(() => { if (state.shop) render(); }, 30 * 1000);

  db.auth.onAuthStateChange((event, session) => {
    state.session = session;
    if (event === 'PASSWORD_RECOVERY') {
      state.recovering = true;
      setTimeout(newPasswordView);
      return;
    }
    if (state.recovering) return;
    if (!session) {
      setTimeout(() => signInView());
    } else if (!state.shop && (event === 'INITIAL_SESSION' || event === 'SIGNED_IN')) {
      // Supabase asks for no work inside this callback: load the shop just after it.
      setTimeout(loadShop);
    }
  });
})();
