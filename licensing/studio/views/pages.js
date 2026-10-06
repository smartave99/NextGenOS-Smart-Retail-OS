'use strict';
// Every screen of the Studio. Written in plain words for people in sales and support.

const { html, raw, page, fmtDate, fmtDateTime, ago, statusOf, badge, csrfField } = require('./layout');
const { MODULES, TERMS } = require('../lib/studio');
const { ROLE_LABELS } = require('../lib/auth');

const MODULE_LABELS = {
  pos: 'Billing (POS)', ai: 'AI assistant', dashboard: 'Dashboard', storefront: 'Website & app',
  hub: 'Business Hub', 'owner-live': "Owner's live view", chain: 'Chain control', api: 'Integrations (API)',
};
const WHITE_LABELS = {
  none: 'Locked: shows the supplier\'s brand only',
  theme: 'Customer can set shop name, logo, colours and receipts',
  full: 'Full re-brand (reseller): can also change the product name',
};
const moduleTags = (list) => list.map((m) => html`<span class="tag">${MODULE_LABELS[m] || m}</span>`);

function login(ctx, { email = '' } = {}) {
  const body = html`
  <div class="narrow card">
    <h1>Sign in</h1>
    <p class="lead">Licence Studio, for the company's staff.</p>
    <form method="post" action="/login" autocomplete="on">
      ${csrfField(ctx.csrf)}
      <label for="email">E-mail</label>
      <input id="email" name="email" type="email" value="${email}" autocomplete="username" required autofocus>
      <label for="password">Password</label>
      <input id="password" name="password" type="password" autocomplete="current-password" required>
      <p><button class="primary big btn" type="submit">Sign in</button></p>
    </form>
  </div>`;
  return page('Sign in', body, { ...ctx, user: null }, '');
}

function home(ctx, { stats, ending, recent }) {
  const now = ctx.now;
  const body = html`
  <div class="row between"><div><h1>Welcome, ${ctx.user.name}</h1><p class="lead">What would you like to do?</p></div>
    ${ctx.can('licences.create') ? html`<a class="btn primary big" href="/licences/new">+ New licence</a>` : ''}</div>
  <div class="grid cols-4">
    <div class="card stat"><div class="n">${stats.active}</div><div class="l">Active licences</div></div>
    <div class="card stat"><div class="n">${stats.expiringSoon}</div><div class="l">End in the next 30 days</div></div>
    <div class="card stat"><div class="n">${stats.devices}</div><div class="l">PCs in use</div></div>
    <div class="card stat"><div class="n">${stats.suspended}</div><div class="l">On hold or withdrawn</div></div>
  </div>
  <div class="grid cols-2">
    <section class="card"><h2>Ending soon</h2>
      ${ending.length ? html`<div class="table-wrap"><table><thead><tr><th>Customer</th><th>Ends</th><th></th></tr></thead><tbody>
        ${ending.map((l) => html`<tr><td>${l.customer_name}</td><td>${fmtDate(l.exp)}</td><td><a href="/licences/${l.lid}">Open</a></td></tr>`)}
      </tbody></table></div>` : html`<p class="muted">Nothing ends in the next 30 days.</p>`}
    </section>
    <section class="card"><h2>Recently activated PCs</h2>
      ${recent.length ? html`<div class="table-wrap"><table><thead><tr><th>Customer</th><th>PC</th><th>When</th></tr></thead><tbody>
        ${recent.map((a) => html`<tr><td><a href="/licences/${a.lid}">${a.customer_name}</a></td><td>${a.host || 'unknown'}</td><td>${ago(a.first_seen, now)}</td></tr>`)}
      </tbody></table></div>` : html`<p class="muted">No PC has been activated yet.</p>`}
    </section>
  </div>`;
  return page('Home', body, ctx, 'home');
}

function licenceList(ctx, { licences, q, status, expiring }) {
  const now = ctx.now;
  const body = html`
  <div class="row between"><div><h1>Licences</h1><p class="lead">Every licence sold. Search by customer name or licence key.</p></div>
    ${ctx.can('licences.create') ? html`<a class="btn primary" href="/licences/new">+ New licence</a>` : ''}</div>
  <form class="card row" method="get" action="/licences" role="search">
    <input type="search" name="q" value="${q}" placeholder="Customer or key" aria-label="Search" class="grow">
    <select name="status" aria-label="Show">
      <option value="">All</option>
      <option value="active" ${status === 'active' ? raw('selected') : ''}>Active</option>
      <option value="suspended" ${status === 'suspended' ? raw('selected') : ''}>On hold</option>
      <option value="revoked" ${status === 'revoked' ? raw('selected') : ''}>Withdrawn</option>
    </select>
    <label class="choice"><input type="checkbox" name="expiring" value="30" ${expiring ? raw('checked') : ''}> Ending in 30 days</label>
    <button class="btn" type="submit">Search</button>
  </form>
  <div class="card table-wrap">
    ${licences.length ? html`<table><thead><tr><th>Customer</th><th>Plan</th><th>Status</th><th>PCs</th><th>Ends</th><th>Key</th></tr></thead><tbody>
      ${licences.map((l) => html`<tr>
        <td><a href="/licences/${l.lid}"><strong>${l.customer_name}</strong></a><div class="muted">${l.customer_country}</div></td>
        <td>${l.plan_code}</td><td>${badge(statusOf(l, now))}</td>
        <td>${l.bind.mode === 'device' ? `${l.devices_in_use} of ${l.limits.devices || '∞'}` : (l.bind.mode === 'domain' ? 'website' : '-')}</td>
        <td>${l.exp ? fmtDate(l.exp) : 'no end'}</td><td class="mono">${l.licence_key}</td></tr>`)}
    </tbody></table>` : html`<p class="muted">No licences found.</p>`}
  </div>`;
  return page('Licences', body, ctx, 'licences');
}

function licenceNew(ctx, { plans, customers, brands, resellers, values = {}, error }) {
  const isAdmin = ctx.user.role === 'admin';
  const v = (k, d = '') => (values[k] !== undefined ? values[k] : d);
  const chosenPlan = v('planCode', 'business');
  const body = html`
  <h1>New licence</h1>
  <p class="lead">A few quick questions. You can change most things later.</p>
  <form method="post" action="/licences/new" id="new-licence">
    ${csrfField(ctx.csrf)}
    <div class="card"><ol class="steps">
      <li><h3>Who is it for?</h3>
        <label for="customerId">Customer</label>
        <select id="customerId" name="customerId">
          <option value="new">+ A new customer…</option>
          ${customers.map((c) => html`<option value="${c.id}" ${String(v('customerId')) === String(c.id) ? raw('selected') : ''}>${c.name}${c.country ? ' · ' + c.country : ''}</option>`)}
        </select>
        <div id="new-customer" class="grid cols-2">
          <div><label for="nc-name">Business name</label><input id="nc-name" name="nc_name" type="text" value="${v('nc_name')}" autocomplete="off"></div>
          <div><label for="nc-country">Country</label><input id="nc-country" name="nc_country" type="text" value="${v('nc_country')}" placeholder="India"></div>
          <div><label for="nc-contact">Contact person</label><input id="nc-contact" name="nc_contactName" type="text" value="${v('nc_contactName')}"></div>
          <div><label for="nc-email">Contact e-mail</label><input id="nc-email" name="nc_email" type="email" value="${v('nc_email')}"></div>
          <div><label for="nc-phone">Phone</label><input id="nc-phone" name="nc_phone" type="text" value="${v('nc_phone')}"></div>
        </div>
      </li>
      <li><h3>What did they buy?</h3>
        <div class="choices" role="radiogroup" aria-label="Plan">
          ${plans.map((p) => html`<label class="choice"><input type="radio" name="planCode" value="${p.code}" data-devices="${p.limits.devices}" data-stores="${p.limits.stores}" data-users="${p.limits.users}" data-cap-devices="${p.caps.devices}" data-cap-stores="${p.caps.stores}" data-cap-users="${p.caps.users}" ${chosenPlan === p.code ? raw('checked') : ''}>
            <strong>${p.name}</strong><small>${p.description}</small><div>${moduleTags(p.modules)}</div></label>`)}
        </div>
      </li>
      <li><h3>For how long?</h3>
        <div class="choices" role="radiogroup" aria-label="Term">
          ${Object.entries(TERMS).filter(([, t]) => !t.adminOnly || isAdmin).map(([k, t]) => html`<label class="choice"><input type="radio" name="term" value="${k}" ${v('term', 'y1') === k ? raw('checked') : ''}> <strong>${t.label}</strong>${t.trial ? html`<small>To try the product.</small>` : ''}</label>`)}
        </div>
        <label for="startDate">Starts on <span class="hint">(leave empty to start today)</span></label>
        <input id="startDate" name="startDate" type="date" value="${v('startDate')}">
      </li>
      <li><h3>How big is the business?</h3>
        <div class="grid cols-4">
          <div><label for="devices">PCs</label><input id="devices" name="devices" type="number" min="0" value="${v('devices')}"><div class="hint" id="devices-hint"></div></div>
          <div><label for="stores">Shops</label><input id="stores" name="stores" type="number" min="0" value="${v('stores')}"><div class="hint" id="stores-hint"></div></div>
          <div><label for="users">People who sign in</label><input id="users" name="users" type="number" min="0" value="${v('users')}"><div class="hint" id="users-hint"></div></div>
        </div>
        <p class="hint">Empty means what the plan includes.</p>
      </li>
      <li><h3>Where will it run?</h3>
        <div class="choices" role="radiogroup" aria-label="Binding">
          <label class="choice"><input type="radio" name="bindMode" value="device" ${v('bindMode', 'device') === 'device' ? raw('checked') : ''}> <strong>Windows PCs</strong><small>Each PC is activated once with the key.</small></label>
          <label class="choice"><input type="radio" name="bindMode" value="domain" ${v('bindMode') === 'domain' ? raw('checked') : ''}> <strong>A website</strong><small>For the online shop, tied to its web address.</small></label>
          ${isAdmin ? html`<label class="choice"><input type="radio" name="bindMode" value="none" ${v('bindMode') === 'none' ? raw('checked') : ''}> <strong>Not tied (special)</strong><small>Administrators only.</small></label>` : ''}
        </div>
        <div id="domains-box" class="hidden"><label for="domains">Website address <span class="hint">(for example shop.example.com; several allowed, one per line)</span></label>
          <textarea id="domains" name="domains" class="mono">${v('domains')}</textarea></div>
      </li>
      <li><h3>Options</h3>
        <div class="grid cols-2">
          <div><label for="whiteLevel">What may the customer change about the look?</label>
            <select id="whiteLevel" name="whiteLevel">
              ${['none', 'theme', ...(isAdmin ? ['full'] : [])].map((k) => html`<option value="${k}" ${v('whiteLevel', 'theme') === k ? raw('selected') : ''}>${WHITE_LABELS[k]}</option>`)}
            </select></div>
          <div><label for="brandId">Brand shown to the customer</label>
            <select id="brandId" name="brandId"><option value="">Our own (NextGenOS)</option>
              ${brands.map((b) => html`<option value="${b.id}" ${String(v('brandId')) === String(b.id) ? raw('selected') : ''}>${b.name}</option>`)}</select></div>
          <div><label for="resellerId">Sold through a reseller?</label>
            <select id="resellerId" name="resellerId"><option value="">No, direct</option>
              ${resellers.map((r) => html`<option value="${r.id}" ${String(v('resellerId')) === String(r.id) ? raw('selected') : ''}>${r.name}</option>`)}</select></div>
        </div>
        <label class="choice"><input type="checkbox" name="offline" ${v('offline') ? raw('checked') : ''}> <strong>The PC has no Internet</strong><small>The licence then works for a long time between codes. You will exchange codes by phone or e-mail.</small></label>
        <label for="notes">Notes <span class="hint">(only staff see these)</span></label>
        <textarea id="notes" name="notes">${v('notes')}</textarea>
      </li>
    </ol>
    <div class="row"><button class="primary big btn" type="submit">Create licence</button><a class="btn" href="/licences">Cancel</a></div>
    </div>
  </form>`;
  const ctx2 = error ? { ...ctx, flash: { err: error } } : ctx;
  return page('New licence', body, ctx2, 'licences');
}

function licenceView(ctx, { lic, customer, plan, brand, reseller, devices, history, message, plans }) {
  const now = ctx.now;
  const st = statusOf(lic, now);
  const isAdmin = ctx.user.role === 'admin';
  const canChange = ctx.can('licences.change');
  const body = html`
  <div class="row between"><div>
      <p class="muted"><a href="/licences">Licences</a> › <a href="/customers/${customer.id}">${customer.name}</a></p>
      <h1>${customer.name} ${badge(st)}</h1>
      <p class="lead">${plan ? plan.name : lic.plan_code} plan · licence ${lic.lid}${lic.status_reason ? ' · ' + lic.status_reason : ''}</p></div>
    <a class="btn" href="/licences/${lic.lid}/download">Download licence file</a></div>

  <section class="card">
    <h2>Licence key</h2>
    <p><span class="keybox" id="the-key">${lic.licence_key}</span></p>
    <p><button class="btn" type="button" data-copy="#the-key">Copy key</button></p>
    <h2>Message for the customer</h2>
    <p class="hint">Copy this into an e-mail or a chat. It already has the key and the steps.</p>
    <textarea id="customer-message" class="mono" readonly rows="14">${message}</textarea>
    <p class="row"><button class="btn primary" type="button" data-copy="#customer-message">Copy message</button>
      ${customer.email ? html`<a class="btn" href="mailto:${customer.email}?subject=${encodeURIComponent('Your licence')}&body=${encodeURIComponent(message)}">Open in my e-mail</a>` : ''}</p>
  </section>

  <div class="grid cols-2">
    <section class="card"><h2>What they bought</h2>
      <dl class="facts">
        <dt>Plan</dt><dd>${plan ? plan.name : lic.plan_code}</dd>
        <dt>Includes</dt><dd>${moduleTags(lic.modules)}</dd>
        <dt>PCs</dt><dd>${lic.limits.devices || 'any number'}</dd>
        <dt>Shops</dt><dd>${lic.limits.stores || 'any number'}</dd>
        <dt>People</dt><dd>${lic.limits.users || 'any number'}</dd>
        <dt>Starts</dt><dd>${fmtDate(lic.nbf)}</dd>
        <dt>Ends</dt><dd>${lic.exp ? fmtDate(lic.exp) : 'no end date'}</dd>
        <dt>Tied to</dt><dd>${lic.bind.mode === 'device' ? 'Windows PCs' : lic.bind.mode === 'domain' ? 'Website: ' + lic.bind.domains.join(', ') : 'Nothing (special)'}</dd>
        <dt>Look</dt><dd>${WHITE_LABELS[lic.white_level] || lic.white_level}</dd>
        <dt>Brand</dt><dd>${brand ? brand.name : 'NextGenOS'}</dd>
        <dt>Reseller</dt><dd>${reseller ? reseller.name : 'Direct'}</dd>
        <dt>Internet</dt><dd>${lic.act.online ? 'Checks in every ' + lic.act.checkInDays + ' days' : 'Works offline'}</dd>
        <dt>Revision</dt><dd>${lic.rev}</dd>
      </dl>
      ${lic.notes ? html`<p class="muted">Notes: ${lic.notes}</p>` : ''}
    </section>
    <section class="card"><h2>Contact</h2>
      <dl class="facts"><dt>Person</dt><dd>${customer.contact_name || '-'}</dd><dt>E-mail</dt><dd>${customer.email || '-'}</dd>
      <dt>Phone</dt><dd>${customer.phone || '-'}</dd><dt>Country</dt><dd>${customer.country || '-'}</dd></dl>
    </section>
  </div>

  ${lic.bind.mode === 'device' ? html`<section class="card"><h2>PCs using this licence</h2>
    ${devices.length ? html`<div class="table-wrap"><table><thead><tr><th>PC</th><th>Program version</th><th>First activated</th><th>Last seen</th><th>Status</th><th></th></tr></thead><tbody>
      ${devices.map((d) => html`<tr><td>${d.host || 'unknown'}</td><td>${d.version || '-'}</td><td>${fmtDate(d.first_seen)}</td><td>${ago(d.last_checkin, now)}</td>
        <td>${d.active ? html`<span class="badge ok">In use</span>` : html`<span class="badge muted">Released</span>`}</td>
        <td>${d.active && ctx.can('devices.free') ? html`<form method="post" action="/licences/${lic.lid}/free/${d.id}" data-confirm="Release this PC? It will need to be activated again.">${csrfField(ctx.csrf)}<button class="btn" type="submit">Free this PC</button></form>` : ''}</td></tr>`)}
    </tbody></table></div>` : html`<p class="muted">Not activated on any PC yet.</p>`}
    <p class="hint">"Free this PC" is for a customer who changed or lost a computer: it makes room for another one.</p>
  </section>` : ''}

  ${canChange && lic.status !== 'revoked' ? html`<section class="card"><h2>Renew or change</h2>
    <div class="grid cols-2">
      <form method="post" action="/licences/${lic.lid}/renew">${csrfField(ctx.csrf)}
        <label for="extendTerm">Renew for</label>
        <select id="extendTerm" name="extendTerm">${Object.entries(TERMS).filter(([k, t]) => !t.trial && (!t.adminOnly || isAdmin)).map(([k, t]) => html`<option value="${k}">${t.label}</option>`)}</select>
        <p class="hint">If it has not ended yet, the time is added to the end date.</p>
        <button class="btn primary" type="submit">Renew</button></form>
      <form method="post" action="/licences/${lic.lid}/change">${csrfField(ctx.csrf)}
        <label for="planCode">Plan</label>
        <select id="planCode" name="planCode">${plans.map((p) => html`<option value="${p.code}" ${p.code === lic.plan_code ? raw('selected') : ''}>${p.name}</option>`)}</select>
        <div class="grid cols-4"><div><label for="c-devices">PCs</label><input id="c-devices" name="devices" type="number" min="0" value="${lic.limits.devices}"></div>
        <div><label for="c-stores">Shops</label><input id="c-stores" name="stores" type="number" min="0" value="${lic.limits.stores}"></div>
        <div><label for="c-users">People</label><input id="c-users" name="users" type="number" min="0" value="${lic.limits.users}"></div></div>
        <label for="c-white">Look</label>
        <select id="c-white" name="whiteLevel">${['none', 'theme', ...(isAdmin ? ['full'] : [])].map((k) => html`<option value="${k}" ${lic.white_level === k ? raw('selected') : ''}>${WHITE_LABELS[k]}</option>`)}</select>
        <label for="c-notes">Notes</label><textarea id="c-notes" name="notes" rows="3">${lic.notes}</textarea>
        <p><button class="btn" type="submit">Save changes</button></p></form>
    </div>
    <p class="hint">Changes reach online PCs at their next check-in. For a PC without Internet, send the new licence file.</p>
  </section>` : ''}

  ${isAdmin ? html`<section class="card"><h2>Hold or withdraw</h2>
    ${lic.status === 'active' ? html`<form method="post" action="/licences/${lic.lid}/suspend" class="row" data-confirm="Put this licence on hold? Its PCs will stop working at their next check-in.">${csrfField(ctx.csrf)}
      <input name="reason" type="text" placeholder="Reason (for example: payment overdue)" aria-label="Reason" class="grow"><button class="btn" type="submit">Put on hold</button></form>` : ''}
    ${lic.status === 'suspended' ? html`<form method="post" action="/licences/${lic.lid}/resume" class="row">${csrfField(ctx.csrf)}<button class="btn primary" type="submit">Release the hold</button></form>` : ''}
    ${lic.status !== 'revoked' ? html`<form method="post" action="/licences/${lic.lid}/revoke" class="row" data-confirm="Withdraw this licence for good? This cannot be undone.">${csrfField(ctx.csrf)}
      <input name="reason" type="text" placeholder="Reason" aria-label="Reason" class="grow"><button class="btn danger" type="submit">Withdraw for good</button></form>` : ''}
    <p class="hint">A hold can be released. Withdrawing is permanent: issue a new licence instead.</p>
  </section>` : ''}

  ${history.length ? html`<section class="card"><h2>History</h2><div class="table-wrap"><table><thead><tr><th>When</th><th>Who</th><th>What</th></tr></thead><tbody>
    ${history.map((h) => html`<tr><td>${fmtDateTime(h.ts)}</td><td>${h.user_email || 'the program'}</td><td>${h.action}${h.detail ? ' · ' + h.detail : ''}</td></tr>`)}
  </tbody></table></div></section>` : ''}`;
  return page(customer.name, body, ctx, 'licences');
}

function customers(ctx, { list, q }) {
  const body = html`
  <div class="row between"><div><h1>Customers</h1><p class="lead">The businesses you sell to.</p></div></div>
  <form class="card row" method="get" action="/customers" role="search"><input type="search" name="q" value="${q}" placeholder="Name, contact or e-mail" aria-label="Search" class="grow"><button class="btn" type="submit">Search</button></form>
  <div class="card table-wrap">${list.length ? html`<table><thead><tr><th>Name</th><th>Country</th><th>Contact</th><th>Licences</th></tr></thead><tbody>
    ${list.map((c) => html`<tr><td><a href="/customers/${c.id}"><strong>${c.name}</strong></a></td><td>${c.country}</td><td>${c.contact_name}${c.email ? ' · ' + c.email : ''}</td><td>${c.licence_count}</td></tr>`)}
  </tbody></table>` : html`<p class="muted">No customers yet. They are added when you create a licence.</p>`}</div>`;
  return page('Customers', body, ctx, 'customers');
}

function customerView(ctx, { customer, licences }) {
  const now = ctx.now;
  const body = html`
  <p class="muted"><a href="/customers">Customers</a> ›</p><h1>${customer.name}</h1>
  <div class="grid cols-2">
  <section class="card"><h2>Details</h2>
    <form method="post" action="/customers/${customer.id}">${csrfField(ctx.csrf)}
      <label for="c-name">Business name</label><input id="c-name" name="name" type="text" value="${customer.name}" required>
      <label for="c-country">Country</label><input id="c-country" name="country" type="text" value="${customer.country}">
      <label for="c-contact">Contact person</label><input id="c-contact" name="contactName" type="text" value="${customer.contact_name}">
      <label for="c-email">E-mail</label><input id="c-email" name="email" type="email" value="${customer.email}">
      <label for="c-phone">Phone</label><input id="c-phone" name="phone" type="text" value="${customer.phone}">
      <label for="c-notes">Notes</label><textarea id="c-notes" name="notes">${customer.notes}</textarea>
      ${ctx.can('customers.write') ? html`<p><button class="btn primary" type="submit">Save</button></p>` : ''}
    </form></section>
  <section class="card"><h2>Licences</h2>
    ${licences.length ? html`<table><tbody>${licences.map((l) => html`<tr><td><a href="/licences/${l.lid}">${l.plan_code}</a></td><td>${badge(statusOf(l, now))}</td><td>${l.exp ? fmtDate(l.exp) : 'no end'}</td></tr>`)}</tbody></table>` : html`<p class="muted">No licences yet.</p>`}
    ${ctx.can('licences.create') ? html`<p><a class="btn primary" href="/licences/new?customer=${customer.id}">+ New licence</a></p>` : ''}
  </section></div>`;
  return page(customer.name, body, ctx, 'customers');
}

function offline(ctx, { result, request, info }) {
  const body = html`
  <h1>Activate without Internet</h1>
  <p class="lead">For a customer whose PC cannot reach the Internet. They read you a code; you give them one back.</p>
  <ol class="card steps">
    <li><h3>Ask the customer for the request code</h3><p class="muted">In the program: Activate, then "Activate without Internet". The code starts with <span class="mono">NGOSREQ1.</span> and can be sent by e-mail or chat.</p></li>
    <li><h3>Paste it here</h3>
      <form method="post" action="/offline">${csrfField(ctx.csrf)}
        <label for="request">Request code</label><textarea id="request" name="request" class="mono" required>${request || ''}</textarea>
        <p><button class="btn primary" type="submit">Make the answer code</button></p></form></li>
    <li><h3>Send the answer code back</h3>
      ${result ? html`<p>${info}</p><textarea id="answer" class="mono" readonly rows="6">${result}</textarea><p><button class="btn primary" type="button" data-copy="#answer">Copy answer code</button></p>
        <p class="muted">The customer pastes it into the same window of the program.</p>` : html`<p class="muted">It appears here.</p>`}</li>
  </ol>`;
  return page('Offline activation', body, ctx, 'offline');
}

function brands(ctx, { list }) {
  const body = html`
  <div class="row between"><div><h1>Brands</h1><p class="lead">The name, logo and colours a customer or reseller sees. Attach one when you create a licence.</p></div>
    ${ctx.can('brands.manage') ? html`<a class="btn primary" href="/brands/new">+ New brand</a>` : ''}</div>
  <div class="card table-wrap">${list.length ? html`<table><thead><tr><th>Brand</th><th>Support</th><th>Powered by</th></tr></thead><tbody>
    ${list.map((b) => html`<tr><td>${ctx.can('brands.manage') ? html`<a href="/brands/${b.id}"><strong>${b.name}</strong></a>` : html`<strong>${b.name}</strong>`}</td><td>${b.data.supportEmail || '-'}</td><td>${b.data.poweredBy ? 'Shown' : 'Hidden'}</td></tr>`)}
  </tbody></table>` : html`<p class="muted">No brands yet. Licences use NextGenOS's own name and colours.</p>`}</div>`;
  return page('Brands', body, ctx, 'brands');
}

function brandEdit(ctx, { brand, resellers }) {
  const d = (brand && brand.data) || { primaryColor: '#0f6cbd', accentColor: '#f59e0b', poweredBy: true };
  const body = html`
  <p class="muted"><a href="/brands">Brands</a> ›</p><h1>${brand ? brand.name : 'New brand'}</h1>
  <form method="post" action="${brand ? '/brands/' + brand.id : '/brands'}" class="card" id="brand-form">${csrfField(ctx.csrf)}
    <div class="grid cols-2">
      <div><label for="b-name">Brand name</label><input id="b-name" name="name" type="text" value="${d.name || ''}" required></div>
      <div><label for="b-short">Short name <span class="hint">(for small spaces)</span></label><input id="b-short" name="shortName" type="text" value="${d.shortName || ''}"></div>
      <div><label for="b-legal">Company's legal name</label><input id="b-legal" name="legalName" type="text" value="${d.legalName || ''}"></div>
      <div><label for="b-copy">Copyright line</label><input id="b-copy" name="copyright" type="text" value="${d.copyright || ''}" placeholder="© 2026 Your Company"></div>
      <div><label for="b-primary">Main colour</label><input id="b-primary" name="primaryColor" type="color" value="${d.primaryColor || '#0f6cbd'}"></div>
      <div><label for="b-accent">Accent colour</label><input id="b-accent" name="accentColor" type="color" value="${d.accentColor || '#f59e0b'}"></div>
      <div><label for="b-mail">Support e-mail</label><input id="b-mail" name="supportEmail" type="email" value="${d.supportEmail || ''}"></div>
      <div><label for="b-phone">Support phone</label><input id="b-phone" name="supportPhone" type="text" value="${d.supportPhone || ''}"></div>
      <div><label for="b-support-url">Support web page</label><input id="b-support-url" name="supportUrl" type="text" value="${d.supportUrl || ''}"></div>
      <div><label for="b-site">Web site</label><input id="b-site" name="websiteUrl" type="text" value="${d.websiteUrl || ''}"></div>
    </div>
    <label for="b-logo-file">Logo <span class="hint">(PNG, JPEG or SVG, under 100 KB)</span></label>
    <input id="b-logo-file" type="file" accept="image/png,image/jpeg,image/svg+xml" data-logo-target="#b-logo">
    <input id="b-logo" name="logo" type="hidden" value="${d.logo || ''}">
    ${d.logo ? html`<img class="logo-preview" id="logo-preview" alt="Current logo" src="${d.logo}">` : html`<img class="logo-preview hidden" id="logo-preview" alt="Logo preview">`}
    <label class="choice"><input type="checkbox" name="poweredBy" ${d.poweredBy ? raw('checked') : ''}> <strong>Show "Powered by NextGenOS"</strong></label>
    <p class="row"><button class="btn primary" type="submit">Save brand</button><a class="btn" href="/brands">Cancel</a></p>
  </form>`;
  return page(brand ? brand.name : 'New brand', body, ctx, 'brands');
}

function plans(ctx, { list }) {
  const row = (p) => html`<form method="post" action="/plans" class="card">${csrfField(ctx.csrf)}
    <h2>${p ? p.name : 'New plan'}</h2>
    <div class="grid cols-2">
      <div><label>Short code <span class="hint">(letters and digits)</span></label><input name="code" type="text" value="${p ? p.code : ''}" ${p ? raw('readonly') : ''} required></div>
      <div><label>Name</label><input name="name" type="text" value="${p ? p.name : ''}" required></div>
    </div>
    <label>What it is, in one line</label><input name="description" type="text" value="${p ? p.description : ''}">
    <label>Includes</label>
    <div class="choices">${MODULES.map((m) => html`<label class="choice"><input type="checkbox" name="modules" value="${m}" ${p && p.modules.includes(m) ? raw('checked') : ''}> ${MODULE_LABELS[m]}</label>`)}</div>
    <div class="grid cols-4"><div><label>PCs</label><input name="devices" type="number" min="0" value="${p ? p.limits.devices : 1}"></div>
      <div><label>Shops</label><input name="stores" type="number" min="0" value="${p ? p.limits.stores : 1}"></div>
      <div><label>People</label><input name="users" type="number" min="0" value="${p ? p.limits.users : 5}"></div>
      <div><label>Sort order</label><input name="sort" type="number" value="${p ? p.sort : 10}"></div></div>
    <p class="hint">Most a salesperson may sell without asking an administrator:</p>
    <div class="grid cols-4"><div><label>PCs</label><input name="capDevices" type="number" min="0" value="${p ? p.caps.devices : 5}"></div>
      <div><label>Shops</label><input name="capStores" type="number" min="0" value="${p ? p.caps.stores : 1}"></div>
      <div><label>People</label><input name="capUsers" type="number" min="0" value="${p ? p.caps.users : 20}"></div></div>
    <label class="choice"><input type="checkbox" name="active" value="1" ${!p || p.active ? raw('checked') : ''}> Available to sell</label>
    <p><button class="btn primary" type="submit">${p ? 'Save plan' : 'Add plan'}</button></p></form>`;
  const body = html`<h1>Plans</h1><p class="lead">What can be sold. Salespeople choose from these.</p>${list.map(row)}${row(null)}`;
  return page('Plans', body, ctx, 'plans');
}

function users(ctx, { list, temp }) {
  const body = html`
  <h1>Team</h1><p class="lead">The people who can sign in to the Studio.</p>
  ${temp ? html`<div class="flash ok" role="status"><strong>${temp.email}</strong> can sign in now. Temporary password (shown once): <span class="mono">${temp.password}</span><br>They must choose their own at the first sign-in.</div>` : ''}
  <div class="card table-wrap"><table><thead><tr><th>Name</th><th>E-mail</th><th>Role</th><th></th></tr></thead><tbody>
    ${list.map((u) => html`<tr><td>${u.name}${u.active ? '' : html` <span class="badge muted">Switched off</span>`}</td><td>${u.email}</td>
      <td><form method="post" action="/users/${u.id}/role" class="row">${csrfField(ctx.csrf)}<select name="role" aria-label="Role">${Object.entries(ROLE_LABELS).map(([k, l]) => html`<option value="${k}" ${u.role === k ? raw('selected') : ''}>${l}</option>`)}</select><button class="btn" type="submit">Set</button></form></td>
      <td class="row"><form method="post" action="/users/${u.id}/${u.active ? 'off' : 'on'}" data-confirm="${u.active ? 'Switch this person off?' : 'Switch this person on?'}">${csrfField(ctx.csrf)}<button class="btn" type="submit">${u.active ? 'Switch off' : 'Switch on'}</button></form>
        <form method="post" action="/users/${u.id}/reset" data-confirm="Make a new temporary password for this person?">${csrfField(ctx.csrf)}<button class="btn" type="submit">New password</button></form></td></tr>`)}
  </tbody></table></div>
  <form method="post" action="/users" class="card">${csrfField(ctx.csrf)}<h2>Add a person</h2>
    <div class="grid cols-2"><div><label for="u-name">Name</label><input id="u-name" name="name" type="text" required></div>
    <div><label for="u-email">E-mail</label><input id="u-email" name="email" type="email" required></div></div>
    <label for="u-role">Role</label><select id="u-role" name="role">${Object.entries(ROLE_LABELS).map(([k, l]) => html`<option value="${k}" ${k === 'sales' ? raw('selected') : ''}>${l}</option>`)}</select>
    <p class="hint">Sales: makes customers and licences within the plan limits. Support: looks things up and frees PCs. Administrator: everything.</p>
    <p><button class="btn primary" type="submit">Add person</button></p></form>`;
  return page('Team', body, ctx, 'users');
}

function audit(ctx, { rows }) {
  const body = html`<h1>History</h1><p class="lead">Everything that was done, newest first.</p>
  <div class="card table-wrap"><table><thead><tr><th>When</th><th>Who</th><th>What</th><th>About</th><th>From</th></tr></thead><tbody>
    ${rows.map((r) => html`<tr><td>${fmtDateTime(r.ts)}</td><td>${r.user_email || 'the program'}</td><td>${r.action}</td><td>${r.target}${r.detail ? ' · ' + r.detail : ''}</td><td class="muted">${r.ip}</td></tr>`)}
  </tbody></table></div>`;
  return page('History', body, ctx, 'audit');
}

function settings(ctx, { settings, keys, releaseKeys = [] }) {
  const body = html`
  <h1>Settings</h1>
  <form method="post" action="/settings" class="card">${csrfField(ctx.csrf)}<h2>Your company</h2>
    <div class="grid cols-2">
      <div><label for="s-company">Company name <span class="hint">(in messages to customers)</span></label><input id="s-company" name="company_name" type="text" value="${settings.company_name}"></div>
      <div><label for="s-support">Support e-mail <span class="hint">(in messages to customers)</span></label><input id="s-support" name="support_email" type="email" value="${settings.support_email}"></div>
      <div><label for="s-phone">Support phone <span class="hint">(in messages to customers)</span></label><input id="s-phone" name="support_phone" type="text" value="${settings.support_phone}"></div>
      <div><label for="s-url">This server's public address</label><input id="s-url" name="public_url" type="text" value="${settings.public_url}" placeholder="https://licence.example.com"></div>
    </div>
    <h2>Rules for PCs</h2>
    <div class="grid cols-4">
      <div><label for="s-checkin">Check in every (days)</label><input id="s-checkin" name="check_in_days" type="number" min="1" max="60" value="${settings.check_in_days}"></div>
      <div><label for="s-grace">Works without check-in for (days)</label><input id="s-grace" name="grace_days" type="number" min="1" max="90" value="${settings.grace_days}"></div>
      <div><label for="s-offline">Offline code lasts (days)</label><input id="s-offline" name="offline_days" type="number" min="30" max="1095" value="${settings.offline_days}"></div>
    </div>
    <p><button class="btn primary" type="submit">Save settings</button></p></form>

  <section class="card"><h2>Signing keys</h2>
    <p class="muted">The Studio signs every licence with a private key that never leaves this server. The apps hold only the public key.</p>
    <div class="table-wrap"><table><thead><tr><th>Key</th><th>Status</th><th>Public key (goes into the apps)</th></tr></thead><tbody>
      ${keys.map((k) => html`<tr><td class="mono">${k.kid}</td><td>${k.status === 'active' ? html`<span class="badge ok">Signing</span>` : k.status === 'pending' ? html`<span class="badge info">Prepared</span>` : html`<span class="badge muted">Retired</span>`}</td><td class="mono">${k.publicKey}</td></tr>`)}
    </tbody></table></div>
    <div class="row">
      <form method="post" action="/settings/key/prepare" data-confirm="Prepare a new signing key? Nothing changes until you switch to it.">${csrfField(ctx.csrf)}<button class="btn" type="submit">Prepare a new key</button></form>
      ${keys.filter((k) => k.status === 'pending').map((k) => html`<form method="post" action="/settings/key/switch" data-confirm="Switch to key ${k.kid}? Only do this after every app has been released with this key built in.">${csrfField(ctx.csrf)}<input type="hidden" name="kid" value="${k.kid}"><button class="btn danger" type="submit">Start signing with ${k.kid}</button></form>`)}
    </div>
    <p class="hint">To change keys safely: prepare the key, build it into the next release of the apps, wait until customers have updated, then switch.</p>
  </section>
  <section class="card"><h2>For a release build (GitHub)</h2>
    <p class="muted">A release can only be activated when it carries your public keys and this server's address. Copy each box into the repository's settings on GitHub: <span class="mono">Settings, Secrets and variables, Actions, Variables</span>, with the name written above the box. These are public values: no private key is shown here and none is ever needed by the build.</p>
    ${releaseKeys.length === 0 ? '' : html`<label for="rel-keys">Variable <span class="mono">NGOS_PUBLIC_KEYS</span></label>
    <textarea id="rel-keys" class="mono" rows="6" readonly>${JSON.stringify({ keys: releaseKeys }, null, 2)}</textarea>
    <p><button class="btn" type="button" data-copy="#rel-keys">Copy</button></p>`}
    <label for="rel-url">Variable <span class="mono">NGOS_LICENCE_URL</span></label>
    ${settings.public_url ? html`<input id="rel-url" class="mono" type="text" readonly value="${settings.public_url.replace(/\/+$/, '')}"><p><button class="btn" type="button" data-copy="#rel-url">Copy</button></p>`
      : html`<p class="flash err" role="alert">Fill in "This server's public address" above and save it first: a release must know where to activate.</p>`}
  </section>
  <section class="card"><h2>Backup</h2>
    <p class="muted">Download a copy of the licence database. Also keep a copy of the <span class="mono">keys</span> folder and the passphrase, in a safe place that is not on this server.</p>
    <p><a class="btn" href="/backup">Download database backup</a></p></section>`;
  return page('Settings', body, ctx, 'settings');
}

function account(ctx, { forced }) {
  const body = html`<div class="narrow card"><h1>${forced ? 'Choose your own password' : 'Your account'}</h1>
    <p class="lead">${forced ? 'The password you were given is temporary.' : ctx.user.email}</p>
    <form method="post" action="/account/password">${csrfField(ctx.csrf)}
      <label for="cur">Current password</label><input id="cur" name="current" type="password" autocomplete="current-password" required>
      <label for="new">New password <span class="hint">(10 or more characters, with letters and a number)</span></label><input id="new" name="password" type="password" autocomplete="new-password" required>
      <p><button class="btn primary" type="submit">Change password</button></p></form></div>`;
  return page('Account', body, ctx, '');
}

function help(ctx) {
  const body = html`
  <h1>How it works</h1>
  <p class="lead">Everything you need to sell and support, in plain steps.</p>
  <section class="card"><h2>Selling a licence</h2><ol>
    <li>Press <strong>+ New licence</strong>.</li>
    <li>Choose or add the customer, the plan, and how long it lasts.</li>
    <li>Press <strong>Create licence</strong>. You get a licence key and a ready message.</li>
    <li>Copy the message and send it to the customer. That is all.</li></ol></section>
  <section class="card"><h2>What the customer does</h2><ol>
    <li>Installs the program.</li><li>Opens it and types the licence key in the Activation window.</li>
    <li>The PC is now activated. It checks in quietly every few days.</li></ol></section>
  <section class="card"><h2>Common situations</h2>
    <dl class="facts">
      <dt>Renewal</dt><dd>Open the licence, choose <em>Renew for</em>, press Renew. Customers online get it by themselves.</dd>
      <dt>New computer</dt><dd>Open the licence, press <em>Free this PC</em> next to the old one. The customer activates the new PC with the same key.</dd>
      <dt>No Internet</dt><dd>Use <em>Offline activation</em>: the customer reads you a code, you send one back.</dd>
      <dt>More PCs</dt><dd>Open the licence, raise <em>PCs</em> (within the plan limit) and save. For more than the limit, ask an administrator.</dd>
      <dt>Customer did not pay</dt><dd>Ask an administrator to put the licence on hold. It can be released later.</dd>
      <dt>Lost key</dt><dd>Open the licence: the key and the message are always there.</dd>
    </dl></section>
  <section class="card"><h2>Good to know</h2><ul>
    <li>Every change is written in <em>History</em>.</li>
    <li>A customer's PC keeps working for a couple of weeks even if it cannot reach the Internet.</li>
    <li>Never send a customer the Studio's address or your own password.</li></ul></section>`;
  return page('Help', body, ctx, 'help');
}

function message(ctx, title, text) {
  const body = html`<div class="narrow card"><h1>${title}</h1><p>${text}</p><p><a class="btn" href="/">Back to the start</a></p></div>`;
  return page(title, body, ctx, '');
}

module.exports = { message, login, home, licenceList, licenceNew, licenceView, customers, customerView, offline, brands, brandEdit, plans, users, audit, settings, account, help, MODULE_LABELS, WHITE_LABELS };
