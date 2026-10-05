'use strict';
// The Studio's web pages: sign-in, licences, customers, brands, plans, team, history, settings.

const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const C = require('../lib/crypto');
const { ApiError } = require('../lib/studio');
const { can } = require('../lib/auth');
const keystore = require('../lib/keystore');
const H = require('../lib/http');
const P = require('../views/pages');

const COOKIE = 'ngos_session';
const PRE_COOKIE = 'ngos_pre';
const STATIC_DIR = path.join(__dirname, '..', 'public');
const STATIC_TYPES = { '.css': 'text/css; charset=utf-8', '.js': 'text/javascript; charset=utf-8', '.svg': 'image/svg+xml', '.png': 'image/png' };

function createUi({ studio, auth, db, config, clientIp, isSecure, clock, dataDir }) {
  const loginLimiter = new H.RateLimiter(10, 600, clock);
  const routes = [];
  const route = (method, pattern, handler, opts = {}) => {
    const keys = [];
    const re = new RegExp('^' + pattern.replace(/:([a-zA-Z]+)/g, (_, k) => { keys.push(k); return '([^/]+)'; }) + '$');
    routes.push({ method, re, keys, handler, ...opts });
  };

  const now = () => (clock ? clock() : Math.floor(Date.now() / 1000));
  const msg = (url, key) => String(url.searchParams.get(key) || '').slice(0, 300);
  const ok = (res, location, text) => H.redirect(res, `${location}${location.includes('?') ? '&' : '?'}ok=${encodeURIComponent(text)}`);
  const fail = (res, location, text) => H.redirect(res, `${location}${location.includes('?') ? '&' : '?'}err=${encodeURIComponent(text)}`);
  const num = (v) => (v === undefined || v === '' ? undefined : v);
  const ipOf = (req) => clientIp(req);

  // ---------- pages ----------

  route('GET', '/', (c) => {
    const stats = studio.stats();
    const ending = studio.listLicences({ expiringDays: 30 }).slice(0, 8);
    const recent = db.prepare(`SELECT a.lid, a.host, a.first_seen, c.name AS customer_name FROM activations a
      JOIN licences l ON l.lid = a.lid JOIN customers c ON c.id = l.customer_id ORDER BY a.first_seen DESC LIMIT 8`).all();
    return c.html(P.home(c.ctx, { stats, ending, recent }));
  });

  route('GET', '/licences', (c) => {
    const q = c.url.searchParams.get('q') || '';
    const status = c.url.searchParams.get('status') || '';
    const expiring = c.url.searchParams.get('expiring') ? 30 : 0;
    return c.html(P.licenceList(c.ctx, { licences: studio.listLicences({ q, status, expiringDays: expiring }), q, status, expiring }));
  }, { perm: 'licences.view' });

  const newForm = (c, values = {}, error) => c.html(P.licenceNew(c.ctx, {
    plans: studio.listPlans(), customers: studio.listCustomers(), brands: studio.listBrands(), resellers: studio.listResellers(), values, error,
  }));

  route('GET', '/licences/new', (c) => newForm(c, c.url.searchParams.get('customer') ? { customerId: c.url.searchParams.get('customer') } : {}), { perm: 'licences.create' });

  route('POST', '/licences/new', (c) => {
    const f = c.form;
    try {
      let customerId = f.customerId;
      if (customerId === 'new') {
        customerId = studio.createCustomer({ name: f.nc_name, country: f.nc_country, contactName: f.nc_contactName, email: f.nc_email, phone: f.nc_phone }, c.user, c.ip).id;
      }
      const lic = studio.createLicence({
        customerId, planCode: f.planCode, term: f.term, startDate: f.startDate,
        devices: num(f.devices), stores: num(f.stores), users: num(f.users),
        bindMode: f.bindMode, domains: f.domains, brandId: f.brandId, resellerId: f.resellerId,
        whiteLevel: f.whiteLevel, offline: f.offline === 'on', notes: f.notes,
      }, c.user, c.ip);
      return ok(c.res, `/licences/${lic.lid}`, 'The licence is ready. Copy the message below and send it to the customer.');
    } catch (e) {
      if (e instanceof ApiError) return newForm(c, f, e.message);
      throw e;
    }
  }, { perm: 'licences.create' });

  route('GET', '/licences/:lid', (c) => {
    const lic = studio.getLicence(c.params.lid);
    if (!lic) return c.notFound();
    const customer = studio.getCustomer(lic.customer_id);
    const brand = lic.brand_id ? studio.getBrand(lic.brand_id) : null;
    const reseller = lic.reseller_id ? db.prepare('SELECT * FROM resellers WHERE id = ?').get(lic.reseller_id) : null;
    const history = db.prepare('SELECT * FROM audit WHERE target LIKE ? ORDER BY ts DESC LIMIT 30').all(`${lic.lid}%`);
    return c.html(P.licenceView(c.ctx, {
      lic, customer, plan: studio.getPlan(lic.plan_code), brand, reseller, devices: studio.listActivations(lic.lid), history,
      message: studio.customerMessage(lic), plans: studio.listPlans(),
    }));
  }, { perm: 'licences.view' });

  route('GET', '/licences/:lid/download', (c) => {
    const lic = studio.getLicence(c.params.lid);
    if (!lic) return c.notFound();
    studio.audit(c.user, 'licence.download', lic.lid, '', c.ip);
    return H.send(c.res, 200, studio.licenceFile(lic), { 'Content-Type': 'text/plain; charset=utf-8', 'Content-Disposition': `attachment; filename="licence-${lic.lid}.ngoslic"` });
  }, { perm: 'licences.view' });

  const back = (c) => `/licences/${c.params.lid}`;
  route('POST', '/licences/:lid/renew', (c) => { studio.updateLicence(c.params.lid, { extendTerm: c.form.extendTerm }, c.user, c.ip); return ok(c.res, back(c), 'The licence is renewed.'); }, { perm: 'licences.change' });
  route('POST', '/licences/:lid/change', (c) => {
    const f = c.form;
    studio.updateLicence(c.params.lid, { planCode: f.planCode, devices: num(f.devices), stores: num(f.stores), users: num(f.users), whiteLevel: f.whiteLevel, notes: f.notes }, c.user, c.ip);
    return ok(c.res, back(c), 'Saved. Online PCs pick this up at their next check-in.');
  }, { perm: 'licences.change' });
  route('POST', '/licences/:lid/suspend', (c) => { studio.setStatus(c.params.lid, 'suspended', c.form.reason, c.user, c.ip); return ok(c.res, back(c), 'The licence is on hold.'); }, { perm: 'licences.hold' });
  route('POST', '/licences/:lid/resume', (c) => { studio.setStatus(c.params.lid, 'active', '', c.user, c.ip); return ok(c.res, back(c), 'The hold is released.'); }, { perm: 'licences.hold' });
  route('POST', '/licences/:lid/revoke', (c) => { studio.setStatus(c.params.lid, 'revoked', c.form.reason, c.user, c.ip); return ok(c.res, back(c), 'The licence is withdrawn.'); }, { perm: 'licences.hold' });
  route('POST', '/licences/:lid/free/:id', (c) => { studio.freeDevice(Number(c.params.id), c.user, c.ip); return ok(c.res, back(c), 'The PC is released. The customer can activate another one.'); }, { perm: 'devices.free' });

  route('GET', '/customers', (c) => c.html(P.customers(c.ctx, { list: studio.listCustomers(c.url.searchParams.get('q') || ''), q: c.url.searchParams.get('q') || '' })), { perm: 'customers.view' });
  route('GET', '/customers/:id', (c) => {
    const customer = studio.getCustomer(Number(c.params.id));
    if (!customer) return c.notFound();
    return c.html(P.customerView(c.ctx, { customer, licences: studio.listLicences({ customerId: customer.id }) }));
  }, { perm: 'customers.view' });
  route('POST', '/customers/:id', (c) => { studio.updateCustomer(Number(c.params.id), c.form, c.user, c.ip); return ok(c.res, `/customers/${c.params.id}`, 'Saved.'); }, { perm: 'customers.write' });

  route('GET', '/offline', (c) => c.html(P.offline(c.ctx, {})), { perm: 'offline.use' });
  route('POST', '/offline', (c) => {
    try {
      const code = studio.offlineActivate(c.form.request, c.user, c.ip);
      const req = require('../lib/studio').Studio.parseRequestCode(c.form.request);
      const lic = studio.getLicenceByKey(req.key);
      const customer = lic ? studio.getCustomer(lic.customer_id) : null;
      return c.html(P.offline(c.ctx, { result: code, request: c.form.request, info: `Ready for ${customer ? customer.name : 'the customer'}, PC "${req.host || 'unknown'}".` }));
    } catch (e) {
      if (e instanceof ApiError) return c.html(P.offline({ ...c.ctx, flash: { err: e.message } }, { request: c.form.request }));
      throw e;
    }
  }, { perm: 'offline.use' });

  route('GET', '/brands', (c) => c.html(P.brands(c.ctx, { list: studio.listBrands() })), { perm: 'brands.view' });
  route('GET', '/brands/new', (c) => c.html(P.brandEdit(c.ctx, { brand: null, resellers: studio.listResellers() })), { perm: 'brands.manage' });
  route('GET', '/brands/:id', (c) => {
    const brand = studio.getBrand(Number(c.params.id));
    return brand ? c.html(P.brandEdit(c.ctx, { brand, resellers: studio.listResellers() })) : c.notFound();
  }, { perm: 'brands.manage' });
  route('POST', '/brands', (c) => { studio.saveBrand(null, c.form, c.user, c.ip); return ok(c.res, '/brands', 'The brand is saved.'); }, { perm: 'brands.manage' });
  route('POST', '/brands/:id', (c) => { studio.saveBrand(Number(c.params.id), c.form, c.user, c.ip); return ok(c.res, '/brands', 'The brand is saved.'); }, { perm: 'brands.manage' });

  route('GET', '/plans', (c) => c.html(P.plans(c.ctx, { list: studio.listPlans(true) })), { perm: 'plans.manage' });
  route('POST', '/plans', (c) => {
    const f = c.form;
    studio.savePlan({ ...f, modules: [].concat(f.modules || []), active: f.active === '1' }, c.user, c.ip);
    return ok(c.res, '/plans', 'The plan is saved.');
  }, { perm: 'plans.manage' });

  route('GET', '/users', (c) => c.html(P.users(c.ctx, { list: auth.listUsers() })), { perm: 'users.manage' });
  route('POST', '/users', (c) => {
    const password = tempPassword();
    try {
      auth.createUser({ email: c.form.email, name: c.form.name, role: c.form.role, password, mustChange: true });
    } catch (e) {
      return fail(c.res, '/users', e.message);
    }
    studio.audit(c.user, 'user.create', c.form.email, c.form.role, c.ip);
    return c.html(P.users(c.ctx, { list: auth.listUsers(), temp: { email: c.form.email, password } }));
  }, { perm: 'users.manage' });
  route('POST', '/users/:id/role', (c) => { try { auth.setRole(Number(c.params.id), c.form.role); } catch (e) { return fail(c.res, '/users', e.message); } studio.audit(c.user, 'user.role', c.params.id, c.form.role, c.ip); return ok(c.res, '/users', 'Saved.'); }, { perm: 'users.manage' });
  route('POST', '/users/:id/off', (c) => { try { auth.setActive(Number(c.params.id), false); } catch (e) { return fail(c.res, '/users', e.message); } studio.audit(c.user, 'user.off', c.params.id, '', c.ip); return ok(c.res, '/users', 'Switched off.'); }, { perm: 'users.manage' });
  route('POST', '/users/:id/on', (c) => { auth.setActive(Number(c.params.id), true); studio.audit(c.user, 'user.on', c.params.id, '', c.ip); return ok(c.res, '/users', 'Switched on.'); }, { perm: 'users.manage' });
  route('POST', '/users/:id/reset', (c) => {
    const user = auth.getUser(Number(c.params.id));
    if (!user) return c.notFound();
    const password = tempPassword();
    auth.setPassword(user.id, password, true);
    studio.audit(c.user, 'user.reset', user.email, '', c.ip);
    return c.html(P.users(c.ctx, { list: auth.listUsers(), temp: { email: user.email, password } }));
  }, { perm: 'users.manage' });

  route('GET', '/audit', (c) => c.html(P.audit(c.ctx, { rows: db.prepare('SELECT * FROM audit ORDER BY id DESC LIMIT 300').all() })), { perm: 'audit.view' });

  route('GET', '/settings', (c) => c.html(P.settings(c.ctx, { settings: studio.settings(), keys: db.prepare('SELECT kid, public_key AS publicKey, status FROM keys ORDER BY created_at DESC').all() })), { perm: 'settings.manage' });
  route('POST', '/settings', (c) => {
    for (const k of ['company_name', 'support_email', 'support_phone', 'public_url', 'check_in_days', 'grace_days', 'offline_days']) if (c.form[k] !== undefined) studio.setSetting(k, String(c.form[k]).trim().slice(0, 200));
    studio.audit(c.user, 'settings.save', '', '', c.ip);
    return ok(c.res, '/settings', 'Saved.');
  }, { perm: 'settings.manage' });
  route('POST', '/settings/key/prepare', (c) => {
    const k = keystore.createKey(db, dataDir, now());
    studio.audit(c.user, 'key.prepare', k.kid, '', c.ip);
    return ok(c.res, '/settings', `A new key (${k.kid}) is prepared. Build it into the apps before switching to it.`);
  }, { perm: 'settings.manage' });
  route('POST', '/settings/key/switch', (c) => {
    keystore.activateKey(db, c.form.kid);
    studio.signer = keystore.loadSigner(db, dataDir);
    studio.audit(c.user, 'key.switch', c.form.kid, '', c.ip);
    return ok(c.res, '/settings', 'The Studio now signs with the new key.');
  }, { perm: 'settings.manage' });

  route('GET', '/backup', (c) => {
    const tmp = path.join(os.tmpdir(), `studio-backup-${Date.now()}-${C.randomToken(6)}.db`);
    db.exec(`VACUUM INTO '${tmp.replace(/'/g, "''")}'`);
    const data = fs.readFileSync(tmp);
    fs.unlinkSync(tmp);
    studio.audit(c.user, 'backup.download', '', '', c.ip);
    return H.send(c.res, 200, data, { 'Content-Type': 'application/octet-stream', 'Content-Disposition': `attachment; filename="licence-studio-${new Date().toISOString().slice(0, 10)}.db"` });
  }, { perm: 'settings.manage' });

  route('GET', '/help', (c) => c.html(P.help(c.ctx)));
  route('GET', '/account', (c) => c.html(P.account(c.ctx, { forced: c.url.searchParams.get('forced') === '1' })));
  route('POST', '/account/password', (c) => {
    const row = db.prepare('SELECT pass_hash FROM users WHERE id = ?').get(c.user.id);
    if (!C.verifyPassword(String(c.form.current || ''), row.pass_hash)) return fail(c.res, '/account', 'The current password is not right.');
    try { auth.setPassword(c.user.id, c.form.password, false); } catch (e) { return fail(c.res, '/account', e.message); }
    studio.audit(c.user, 'user.password', c.user.email, '', c.ip);
    // The sessions were ended by the change; sign in again with the new password.
    return H.redirect(c.res, '/login?ok=' + encodeURIComponent('Password changed. Please sign in again.'), { 'Set-Cookie': expireCookie(COOKIE, c.secure) });
  });

  // ---------- plumbing ----------

  function tempPassword() {
    for (;;) {
      const raw = Array.from({ length: 3 }, () => C.generateLicenceKey().slice(5, 9)).join('-');
      if (/[A-Z]/.test(raw) && /[0-9]/.test(raw)) return raw;
    }
  }

  const cookie = (name, value, secure, maxAge) => `${name}=${value}; Path=/; HttpOnly; SameSite=Strict${secure ? '; Secure' : ''}${maxAge ? `; Max-Age=${maxAge}` : ''}`;
  const expireCookie = (name, secure) => `${name}=; Path=/; HttpOnly; SameSite=Strict${secure ? '; Secure' : ''}; Max-Age=0`;

  return async function handle(req, res, url) {
    const ip = ipOf(req);
    const secure = isSecure(req);

    // Static files
    if (req.method === 'GET' && url.pathname.startsWith('/static/')) {
      const file = path.join(STATIC_DIR, path.basename(url.pathname));
      const type = STATIC_TYPES[path.extname(file)];
      if (!type || !fs.existsSync(file)) return H.send(res, 404, 'Not found', { 'Content-Type': 'text/plain' });
      return H.send(res, 200, fs.readFileSync(file), { 'Content-Type': type, 'Cache-Control': 'public, max-age=300' });
    }
    if (req.method === 'GET' && url.pathname === '/favicon.ico') return H.send(res, 204, '');

    const cookies = H.parseCookies(req.headers.cookie);
    const session = auth.session(cookies[COOKIE]);
    const user = session ? session.user : null;
    const flash = { ok: msg(url, 'ok'), err: msg(url, 'err') };
    const ctx = { user, csrf: session ? session.csrf : '', flash, now: now(), can: (p) => can(user, p) };
    const notFound = () => H.sendHtml(res, 404, P.message(ctx, 'Not found', 'That page does not exist.'));

    // ----- sign in / out -----
    if (url.pathname === '/login') {
      if (req.method === 'GET') {
        const pre = cookies[PRE_COOKIE] || C.randomToken(24);
        return H.sendHtml(res, 200, P.login({ ...ctx, csrf: pre, user: null }, {}), { 'Set-Cookie': cookie(PRE_COOKIE, pre, secure) });
      }
      if (req.method === 'POST') {
        const form = await H.readForm(req);
        const pre = cookies[PRE_COOKIE];
        const retry = (text) => H.sendHtml(res, 200, P.login({ ...ctx, csrf: pre || '', user: null, flash: { err: text } }, { email: form.email }));
        if (!pre || !C.safeEqual(form._csrf || '', pre)) return retry('The page expired. Please try again.');
        if (!loginLimiter.take(ip)) return retry('Too many attempts. Please wait ten minutes.');
        const result = auth.login(form.email, form.password);
        if (!result.ok) { studio.audit(null, 'login.failed', String(form.email || '').slice(0, 80), '', ip); return retry(result.message); }
        const s = auth.startSession(result.user.id, ip);
        studio.audit(result.user, 'login', result.user.email, '', ip);
        return H.redirect(res, result.user.mustChange ? '/account?forced=1' : '/', { 'Set-Cookie': [cookie(COOKIE, s.token, secure, s.maxAge), expireCookie(PRE_COOKIE, secure)] });
      }
    }
    if (url.pathname === '/logout' && req.method === 'POST') {
      auth.endSession(cookies[COOKIE]);
      return H.redirect(res, '/login', { 'Set-Cookie': expireCookie(COOKIE, secure) });
    }

    // ----- everything else needs a signed-in user -----
    if (!user) return H.redirect(res, '/login');
    if (user.mustChange && !['/account', '/account/password'].includes(url.pathname)) return H.redirect(res, '/account?forced=1');

    for (const r of routes) {
      if (r.method !== req.method) continue;
      const m = r.re.exec(url.pathname);
      if (!m) continue;
      if (r.perm && !can(user, r.perm)) return H.sendHtml(res, 403, P.message(ctx, 'Not allowed', 'Your role does not include this. Ask an administrator.'));
      const params = {};
      r.keys.forEach((k, i) => { params[k] = decodeURIComponent(m[i + 1]); });
      let form = {};
      if (req.method === 'POST') {
        form = await H.readForm(req);
        if (!C.safeEqual(form._csrf || '', session.csrf)) return H.sendHtml(res, 403, P.message(ctx, 'The page expired', 'Please go back, reload the page and try again.'));
      }
      const c = {
        req, res, url, params, form, user, ip, secure, ctx,
        html: (body) => H.sendHtml(res, 200, body),
        notFound,
      };
      try {
        return await r.handler(c);
      } catch (e) {
        if (e instanceof ApiError) return fail(res, req.headers.referer ? new URL(req.headers.referer, 'http://x').pathname : '/', e.message);
        throw e;
      }
    }
    return notFound();
  };
}

module.exports = { createUi };
