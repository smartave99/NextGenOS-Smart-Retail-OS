'use strict';
// Page toolkit: safe HTML templates, the common page frame and small formatters.

class Raw { constructor(s) { this.s = s; } toString() { return this.s; } }
const raw = (s) => new Raw(String(s));

const ESC = { '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' };
const esc = (v) => String(v == null ? '' : v).replace(/[&<>"']/g, (c) => ESC[c]);

/** html`<p>${value}</p>`: values are escaped unless they are raw(...) or another html`` result; arrays are joined. */
function html(strings, ...values) {
  let out = strings[0];
  values.forEach((v, i) => {
    const part = Array.isArray(v) ? v.map((x) => (x instanceof Raw ? x.s : esc(x))).join('') : (v instanceof Raw ? v.s : esc(v));
    out += part + strings[i + 1];
  });
  return new Raw(out);
}

const pad = (n) => String(n).padStart(2, '0');
function fmtDate(ts) {
  if (!ts) return '';
  const d = new Date(ts * 1000);
  return `${d.getUTCFullYear()}-${pad(d.getUTCMonth() + 1)}-${pad(d.getUTCDate())}`;
}
function fmtDateTime(ts) {
  if (!ts) return '';
  const d = new Date(ts * 1000);
  return `${fmtDate(ts)} ${pad(d.getUTCHours())}:${pad(d.getUTCMinutes())} UTC`;
}
function ago(ts, now) {
  if (!ts) return 'never';
  const s = Math.max(0, now - ts);
  if (s < 90) return 'just now';
  if (s < 3600) return `${Math.round(s / 60)} min ago`;
  if (s < 86400) return `${Math.round(s / 3600)} h ago`;
  return `${Math.round(s / 86400)} days ago`;
}

/** The status a person should see for a licence row. */
function statusOf(lic, now) {
  if (lic.status === 'revoked') return { key: 'withdrawn', label: 'Withdrawn', cls: 'bad' };
  if (lic.status === 'suspended') return { key: 'hold', label: 'On hold', cls: 'warn' };
  if (lic.exp && lic.exp < now) return { key: 'ended', label: 'Ended', cls: 'muted' };
  if (lic.nbf > now) return { key: 'later', label: 'Starts ' + fmtDate(lic.nbf), cls: 'info' };
  if (lic.exp && lic.exp - now < 30 * 86400) return { key: 'soon', label: 'Ends soon', cls: 'warn' };
  return { key: 'active', label: lic.trial ? 'Trial' : 'Active', cls: lic.trial ? 'info' : 'ok' };
}
const badge = (s) => html`<span class="badge ${s.cls}">${s.label}</span>`;

function csrfField(csrf) { return html`<input type="hidden" name="_csrf" value="${csrf}">`; }

/**
 * The page frame. ctx: { user, can(permission), csrf, flash: {ok, err} }.
 * `active` marks the current menu entry.
 */
function page(title, body, ctx, active = '') {
  const u = ctx.user;
  const item = (href, label, key, perm) => (perm && !ctx.can(perm) ? '' : html`<a href="${href}" class="${active === key ? 'on' : ''}">${label}</a>`);
  const nav = u ? html`
    <nav aria-label="Main">
      ${item('/', 'Home', 'home')}
      ${item('/licences', 'Licences', 'licences', 'licences.view')}
      ${item('/customers', 'Customers', 'customers', 'customers.view')}
      ${item('/offline', 'Offline activation', 'offline', 'offline.use')}
      ${item('/brands', 'Brands', 'brands', 'brands.view')}
      ${item('/plans', 'Plans', 'plans', 'plans.manage')}
      ${item('/users', 'Team', 'users', 'users.manage')}
      ${item('/audit', 'History', 'audit', 'audit.view')}
      ${item('/settings', 'Settings', 'settings', 'settings.manage')}
      ${item('/help', 'Help', 'help')}
    </nav>
    <form method="post" action="/logout" class="account">
      ${csrfField(ctx.csrf)}
      <a href="/account">${u.name}</a>
      <button class="link" type="submit">Sign out</button>
    </form>` : '';
  const flash = [];
  if (ctx.flash && ctx.flash.ok) flash.push(html`<div class="flash ok" role="status">${ctx.flash.ok}</div>`);
  if (ctx.flash && ctx.flash.err) flash.push(html`<div class="flash err" role="alert">${ctx.flash.err}</div>`);
  return '<!doctype html>' + html`<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="robots" content="noindex">
<title>${title} · Licence Studio</title>
<link rel="stylesheet" href="/static/app.css">
<script src="/static/app.js" defer></script>
</head>
<body>
<header class="top"><a class="brand" href="/">Licence Studio</a>${nav}</header>
<main>
${flash}
${body}
</main>
<footer>NextGen OS Licence Studio · private: for the company's staff only</footer>
</body></html>`.s;
}

module.exports = { raw, esc, html, Raw, page, fmtDate, fmtDateTime, ago, statusOf, badge, csrfField };
