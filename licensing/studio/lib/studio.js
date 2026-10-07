'use strict';
// The Studio's business rules: customers, plans, licences, activation, check-in, revocation, offline activation.
// No HTTP in here; routes/api.js and routes/ui.js call these methods.

const { transaction, now: unixNow } = require('./db');
const C = require('./crypto');

const DAY = 86400;
const PRODUCT = 'smart-retail-os';
const MODULES = ['pos', 'hub', 'ai', 'dashboard', 'storefront', 'owner-live', 'chain', 'api'];
const FP_KINDS = ['bios', 'board', 'cpu', 'disk', 'os'];
const WHITE_LEVELS = ['none', 'theme', 'full'];
const ON_END = ['banner', 'stop'];
// A customer may free their old PC themselves this often (spec section 8, "Moves"). Staff are not limited.
const MOVE_LIMIT = 2;
const MOVE_WINDOW_DAYS = 365;
const TRIAL_DEFAULT_DAYS = 14;
const TRIAL_MAX_DAYS = 365;
const EXTEND_MAX_DAYS = 3650;

class ApiError extends Error {
  constructor(status, code, message) {
    super(message);
    this.status = status;
    this.code = code;
  }
}

const text = (value, max, fallback = '') => String(value == null ? fallback : value).trim().slice(0, max);
const int = (value, fallback = 0) => {
  const n = Number.parseInt(value, 10);
  return Number.isFinite(n) && n >= 0 ? n : fallback;
};
const json = (value) => JSON.stringify(value);
const parse = (value, fallback = null) => {
  try { return JSON.parse(value); } catch (_) { return fallback; }
};
/** A whole number from min to max; anything else is an error in plain words (never silently replaced). */
const wholeNumber = (value, min, max, message) => {
  const n = typeof value === 'number' ? value : (/^\s*\d{1,9}\s*$/.test(String(value)) ? Number(value) : NaN);
  if (!Number.isInteger(n) || n < min || n > max) throw new ApiError(400, 'bad_request', message);
  return n;
};
const dateOf = (ts) => new Date(ts * 1000).toISOString().slice(0, 10);
/** Who did it, for the history: "Name (e-mail)" for a person, the text itself for a tool. */
const actorLabel = (actor) => (actor ? (actor.name && actor.email && actor.name !== actor.email ? `${actor.name} (${actor.email})` : (actor.email || actor.name || '')) : '');

const DEFAULT_PLANS = [
  { code: 'hub', name: 'Business Hub', description: 'Any kind of business in any country: shop, restaurant, library, builder, services. One site, its tax, its words.', modules: ['hub'], limits: { devices: 3, stores: 1, users: 10 }, caps: { devices: 10, stores: 1, users: 50 }, term_days: 365, sort: 0 },
  { code: 'starter', name: 'Starter', description: 'One shop, one counter. Billing, stock and reports.', modules: ['pos', 'hub'], limits: { devices: 1, stores: 1, users: 3 }, caps: { devices: 2, stores: 1, users: 10 }, term_days: 365, sort: 1 },
  { code: 'business', name: 'Business', description: 'A shop with several counters. Adds the AI assistant, the dashboard and the owner\'s live view.', modules: ['pos', 'hub', 'ai', 'dashboard', 'owner-live'], limits: { devices: 3, stores: 1, users: 10 }, caps: { devices: 10, stores: 1, users: 50 }, term_days: 365, sort: 2 },
  { code: 'growth', name: 'Growth', description: 'A few shops and an online store. Adds the website and mobile app.', modules: ['pos', 'hub', 'ai', 'dashboard', 'owner-live', 'storefront'], limits: { devices: 10, stores: 3, users: 30 }, caps: { devices: 30, stores: 10, users: 100 }, term_days: 365, sort: 3 },
  { code: 'chain', name: 'Chain', description: 'A group of shops with central control. Everything, with the chain hub and the API.', modules: ['pos', 'hub', 'ai', 'dashboard', 'owner-live', 'storefront', 'chain', 'api'], limits: { devices: 50, stores: 25, users: 200 }, caps: { devices: 500, stores: 250, users: 2000 }, term_days: 365, sort: 4 },
];

const DEFAULT_SETTINGS = {
  company_name: 'NextGenOS',
  support_email: 'smartave99@gmail.com',
  support_phone: '+91 6123115368',
  public_url: '',
  // About monthly, and 60 days of warnings after a missed check-in (spec section 13.2).
  check_in_days: '30',
  grace_days: '60',
  offline_days: '365',
};

// The "when does it end" choices. A paid licence has no end date unless staff choose one; a trial is 14 days unless staff choose another length.
const TERMS = {
  perpetual: { days: null, label: 'No end date (one-time purchase)' },
  y1: { days: 365, label: '1 year' },
  y2: { days: 730, label: '2 years' },
  y3: { days: 1095, label: '3 years' },
  trial: { days: TRIAL_DEFAULT_DAYS, label: 'Trial', trial: true },
  trial30: { days: 30, label: '30-day trial', trial: true, legacy: true }, // the older name, kept so old scripts keep working
};

class Studio {
  /** signer: { kid, privateKeyPem } of the active signing key. */
  constructor({ db, signer, clock }) {
    this.db = db;
    this.signer = signer;
    this.clock = clock || unixNow;
  }

  now() { return this.clock(); }

  // ---------- settings, keys, audit ----------

  seedDefaults() {
    const insert = this.db.prepare('INSERT OR IGNORE INTO settings(key, value) VALUES (?, ?)');
    for (const [k, v] of Object.entries(DEFAULT_SETTINGS)) insert.run(k, v);
    // Once: a Studio that still holds the old defaults (7 and 14 days) moves to monthly and 60 days. A value staff chose themselves stays.
    if (!this.db.prepare("SELECT 1 FROM settings WHERE key = 'defaults_v2'").get()) {
      this.db.prepare("UPDATE settings SET value = '30' WHERE key = 'check_in_days' AND value = '7'").run();
      this.db.prepare("UPDATE settings SET value = '60' WHERE key = 'grace_days' AND value = '14'").run();
      this.db.prepare("INSERT INTO settings(key, value) VALUES ('defaults_v2', '1')").run();
    }
    const planInsert = this.db.prepare('INSERT OR IGNORE INTO plans(code, name, description, modules, limits, caps, term_days, sort) VALUES (?,?,?,?,?,?,?,?)');
    for (const p of DEFAULT_PLANS) planInsert.run(p.code, p.name, p.description, json(p.modules), json(p.limits), json(p.caps), p.term_days, p.sort);
  }

  setting(key) {
    const row = this.db.prepare('SELECT value FROM settings WHERE key = ?').get(key);
    return row ? row.value : (DEFAULT_SETTINGS[key] || '');
  }

  setSetting(key, value) {
    this.db.prepare('INSERT INTO settings(key, value) VALUES (?, ?) ON CONFLICT(key) DO UPDATE SET value = excluded.value').run(key, String(value));
  }

  settings() {
    const out = {};
    for (const k of Object.keys(DEFAULT_SETTINGS)) out[k] = this.setting(k);
    return out;
  }

  trustedKeys() {
    return this.db.prepare('SELECT kid, public_key AS publicKey FROM keys ORDER BY created_at').all();
  }

  audit(actor, action, target, detail, ip) {
    this.db.prepare('INSERT INTO audit(ts, user_id, user_email, action, target, detail, ip) VALUES (?,?,?,?,?,?,?)')
      .run(this.now(), actor && actor.id ? actor.id : null, actor && actor.email ? actor.email : '', action, text(target, 120), text(detail, 600), text(ip, 64));
  }

  // ---------- plans, customers, resellers, brands ----------

  listPlans(includeInactive = false) {
    const rows = this.db.prepare(`SELECT * FROM plans ${includeInactive ? '' : 'WHERE active = 1'} ORDER BY sort, name`).all();
    return rows.map((p) => ({ ...p, modules: parse(p.modules, []), limits: parse(p.limits, {}), caps: parse(p.caps, {}) }));
  }

  getPlan(code) {
    return this.listPlans(true).find((p) => p.code === code) || null;
  }

  savePlan(input, actor, ip) {
    const code = text(input.code, 30).toLowerCase().replace(/[^a-z0-9-]/g, '');
    if (!code) throw new ApiError(400, 'bad_request', 'The plan needs a short code (letters and digits).');
    const modules = (Array.isArray(input.modules) ? input.modules : []).filter((m) => MODULES.includes(m));
    if (!modules.length) throw new ApiError(400, 'bad_request', 'Choose at least one module.');
    const limits = { devices: int(input.devices, 1), stores: int(input.stores, 1), users: int(input.users, 5) };
    const caps = { devices: Math.max(limits.devices, int(input.capDevices, limits.devices)), stores: Math.max(limits.stores, int(input.capStores, limits.stores)), users: Math.max(limits.users, int(input.capUsers, limits.users)) };
    this.db.prepare(`INSERT INTO plans(code, name, description, modules, limits, caps, term_days, active, sort) VALUES (?,?,?,?,?,?,?,?,?)
      ON CONFLICT(code) DO UPDATE SET name=excluded.name, description=excluded.description, modules=excluded.modules, limits=excluded.limits, caps=excluded.caps, term_days=excluded.term_days, active=excluded.active, sort=excluded.sort`)
      .run(code, text(input.name, 60, code), text(input.description, 300), json(modules), json(limits), json(caps), int(input.termDays, 365), input.active === false ? 0 : 1, int(input.sort, 10));
    this.audit(actor, 'plan.save', code, '', ip);
    return this.getPlan(code);
  }

  createCustomer(input, actor, ip) {
    const name = text(input.name, 120);
    if (!name) throw new ApiError(400, 'bad_request', 'Enter the customer\'s business name.');
    const email = text(input.email, 120);
    if (email && !/^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(email)) throw new ApiError(400, 'bad_request', 'The e-mail address does not look right.');
    const externalId = input.externalId === undefined || input.externalId === null || input.externalId === '' ? null : this.cleanExternalId(input.externalId);
    if (externalId && this.getCustomerByExternalId(externalId)) throw new ApiError(409, 'conflict', 'A customer with that id already exists.');
    const r = this.db.prepare('INSERT INTO customers(name, country, contact_name, email, phone, notes, external_id, created_by, created_at) VALUES (?,?,?,?,?,?,?,?,?)')
      .run(name, text(input.country, 60), text(input.contactName, 80), email, text(input.phone, 40), text(input.notes, 500), externalId, actor ? actor.id : null, this.now());
    this.audit(actor, 'customer.create', name, externalId ? `id ${externalId}` : '', ip);
    return this.getCustomer(Number(r.lastInsertRowid));
  }

  /** The id the main Setup Studio gave a client (its project id): letters, digits and . _ : - only. */
  cleanExternalId(value) {
    const id = text(value, 200);
    if (!/^[A-Za-z0-9._:-]{1,80}$/.test(id)) throw new ApiError(400, 'bad_request', 'The customer id must be 1 to 80 letters, digits or the signs . _ : -');
    return id;
  }

  getCustomerByExternalId(externalId) {
    return this.db.prepare('SELECT * FROM customers WHERE external_id = ?').get(externalId) || null;
  }

  /** The customer for a client of the main Setup Studio: found by its id there, made when it is new, and renamed when the name changed. */
  upsertExternalCustomer({ externalId, name, country }, actor, ip) {
    const found = this.getCustomerByExternalId(externalId);
    if (!found) return this.createCustomer({ name, country, externalId }, actor, ip);
    const newName = text(name, 120) || found.name;
    const newCountry = country === undefined || country === null || country === '' ? found.country : text(country, 60);
    if (newName !== found.name || newCountry !== found.country) {
      this.db.prepare('UPDATE customers SET name = ?, country = ? WHERE id = ?').run(newName, newCountry, found.id);
      this.audit(actor, 'customer.update', newName, `id ${externalId}`, ip);
    }
    return this.getCustomer(found.id);
  }

  updateCustomer(id, input, actor, ip) {
    const c = this.getCustomer(id);
    if (!c) throw new ApiError(404, 'not_found', 'Customer not found.');
    const email = text(input.email, 120);
    if (email && !/^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(email)) throw new ApiError(400, 'bad_request', 'The e-mail address does not look right.');
    this.db.prepare('UPDATE customers SET name=?, country=?, contact_name=?, email=?, phone=?, notes=? WHERE id=?')
      .run(text(input.name, 120, c.name) || c.name, text(input.country, 60), text(input.contactName, 80), email, text(input.phone, 40), text(input.notes, 500), id);
    this.audit(actor, 'customer.update', c.name, '', ip);
    return this.getCustomer(id);
  }

  getCustomer(id) {
    return this.db.prepare('SELECT * FROM customers WHERE id = ?').get(id) || null;
  }

  listCustomers(q = '') {
    const like = `%${text(q, 60)}%`;
    return this.db.prepare(`SELECT c.*, (SELECT COUNT(*) FROM licences l WHERE l.customer_id = c.id) AS licence_count
      FROM customers c WHERE c.name LIKE ? OR c.email LIKE ? OR c.contact_name LIKE ? ORDER BY c.name LIMIT 500`).all(like, like, like);
  }

  listResellers() { return this.db.prepare('SELECT * FROM resellers WHERE active = 1 ORDER BY name').all(); }

  createReseller(input, actor, ip) {
    const name = text(input.name, 120);
    if (!name) throw new ApiError(400, 'bad_request', 'Enter the reseller\'s name.');
    const r = this.db.prepare('INSERT INTO resellers(name, email, notes, created_at) VALUES (?,?,?,?)').run(name, text(input.email, 120), text(input.notes, 500), this.now());
    this.audit(actor, 'reseller.create', name, '', ip);
    return Number(r.lastInsertRowid);
  }

  normaliseBrand(input) {
    const color = (v, d) => (/^#[0-9a-fA-F]{6}$/.test(String(v || '')) ? String(v) : d);
    const logo = text(input.logo, 150000);
    if (logo && !/^data:image\/(png|jpeg|svg\+xml);base64,[A-Za-z0-9+/=]+$/.test(logo)) throw new ApiError(400, 'bad_request', 'The logo must be a PNG, JPEG or SVG picture, under about 100 KB.');
    const name = text(input.name, 60);
    if (!name) throw new ApiError(400, 'bad_request', 'The brand needs a name.');
    return {
      name,
      shortName: text(input.shortName, 30, name),
      legalName: text(input.legalName, 120),
      primaryColor: color(input.primaryColor, '#0f6cbd'),
      accentColor: color(input.accentColor, '#f59e0b'),
      supportEmail: text(input.supportEmail, 120),
      supportPhone: text(input.supportPhone, 40),
      supportUrl: text(input.supportUrl, 200),
      websiteUrl: text(input.websiteUrl, 200),
      copyright: text(input.copyright, 120),
      logo: logo || null,
      poweredBy: input.poweredBy === true || input.poweredBy === 'on' || input.poweredBy === '1',
    };
  }

  listBrands() {
    return this.db.prepare('SELECT * FROM brands WHERE active = 1 ORDER BY name').all().map((b) => ({ ...b, data: parse(b.data, {}) }));
  }

  getBrand(id) {
    const b = this.db.prepare('SELECT * FROM brands WHERE id = ?').get(id);
    return b ? { ...b, data: parse(b.data, {}) } : null;
  }

  saveBrand(id, input, actor, ip) {
    const data = this.normaliseBrand(input);
    const resellerId = input.resellerId ? int(input.resellerId, 0) || null : null;
    if (id) {
      this.db.prepare('UPDATE brands SET name=?, data=?, reseller_id=? WHERE id=?').run(data.name, json(data), resellerId, id);
      this.audit(actor, 'brand.update', data.name, '', ip);
      return id;
    }
    const r = this.db.prepare('INSERT INTO brands(name, data, reseller_id, created_at) VALUES (?,?,?,?)').run(data.name, json(data), resellerId, this.now());
    this.audit(actor, 'brand.create', data.name, '', ip);
    return Number(r.lastInsertRowid);
  }

  // ---------- licences ----------

  hydrate(row) {
    if (!row) return null;
    return { ...row, modules: parse(row.modules, []), limits: parse(row.limits, {}), bind: parse(row.bind, { mode: 'device', domains: [] }), act: parse(row.act, {}), trial: !!row.trial };
  }

  getLicence(lid) { return this.hydrate(this.db.prepare('SELECT * FROM licences WHERE lid = ?').get(lid)); }

  getLicenceByKey(key) {
    const k = C.normaliseLicenceKey(key);
    return k ? this.hydrate(this.db.prepare('SELECT * FROM licences WHERE licence_key = ?').get(k)) : null;
  }

  /** Licences with their customer name and the number of active PCs. */
  listLicences({ q = '', status = '', customerId = 0, expiringDays = 0 } = {}) {
    const like = `%${text(q, 60)}%`;
    const rows = this.db.prepare(`
      SELECT l.*, c.name AS customer_name, c.country AS customer_country,
        (SELECT COUNT(*) FROM activations a WHERE a.lid = l.lid AND a.active = 1) AS devices_in_use
      FROM licences l JOIN customers c ON c.id = l.customer_id
      WHERE (c.name LIKE ? OR l.licence_key LIKE ? OR l.lid LIKE ?)
        AND (? = '' OR l.status = ?)
        AND (? = 0 OR l.customer_id = ?)
        AND (? = 0 OR (l.exp IS NOT NULL AND l.exp BETWEEN ? AND ?))
      ORDER BY l.created_at DESC LIMIT 500`).all(like, like, like, status, status, customerId, customerId, expiringDays, this.now(), this.now() + expiringDays * DAY);
    return rows.map((r) => this.hydrate(r));
  }

  stats() {
    const n = this.now();
    const one = (sql, ...p) => this.db.prepare(sql).get(...p).n;
    return {
      customers: one('SELECT COUNT(*) AS n FROM customers'),
      active: one("SELECT COUNT(*) AS n FROM licences WHERE status = 'active' AND (exp IS NULL OR exp > ?)", n),
      expiringSoon: one("SELECT COUNT(*) AS n FROM licences WHERE status = 'active' AND exp IS NOT NULL AND exp BETWEEN ? AND ?", n, n + 30 * DAY),
      expired: one("SELECT COUNT(*) AS n FROM licences WHERE exp IS NOT NULL AND exp <= ?", n),
      suspended: one("SELECT COUNT(*) AS n FROM licences WHERE status IN ('suspended','revoked')"),
      devices: one('SELECT COUNT(*) AS n FROM activations WHERE active = 1'),
    };
  }

  resolveTerm(term) {
    const t = Object.prototype.hasOwnProperty.call(TERMS, term) ? TERMS[term] : null;
    if (!t) throw new ApiError(400, 'bad_request', 'Choose how long the licence lasts.');
    return t;
  }

  /** What happens at the end date: "banner" or "stop". Left empty it is banner for a paid licence and stop for a trial. A trial always stops. */
  resolveOnEnd(value, isTrial) {
    const given = value === undefined || value === null || value === '' ? null : String(value);
    if (given !== null && !ON_END.includes(given)) throw new ApiError(400, 'bad_request', 'Choose what happens when the licence ends: it keeps working and shows a banner, or it stops.');
    if (isTrial && given === 'banner') throw new ApiError(400, 'bad_request', 'A trial always stops at its end date. To keep a customer going, turn the trial into a paid licence.');
    return given || (isTrial ? 'stop' : 'banner');
  }

  /**
   * Creates a licence. The customer is either an existing one (`customerId`) or, for a client of the main Setup Studio,
   * `customer: {externalId, name, country}` (found by its id there, made when new). `hooks.inTransaction(lid, customer)` runs
   * in the same transaction as the insert (the staff API stores its idempotency record there). Returns the stored licence.
   */
  createLicence(input, actor, ip, hooks = {}) {
    const plan = this.getPlan(text(input.planCode, 30));
    if (!plan || !plan.active) throw new ApiError(400, 'bad_request', 'Choose a plan.');
    let customer = null;
    let external = null;
    if (input.customer) {
      external = { externalId: this.cleanExternalId(input.customer.externalId), name: text(input.customer.name, 120), country: text(input.customer.country, 60) };
      if (!external.name) throw new ApiError(400, 'bad_request', 'Enter the customer\'s business name.');
    } else {
      customer = this.getCustomer(int(input.customerId, 0));
      if (!customer) throw new ApiError(400, 'bad_request', 'Choose the customer.');
    }
    const termName = text(input.term, 20) || (input.trialDays !== undefined && input.trialDays !== null && input.trialDays !== '' ? 'trial' : 'perpetual');
    const term = this.resolveTerm(termName);
    const trialDays = term.trial
      ? wholeNumber(input.trialDays === undefined || input.trialDays === null || input.trialDays === '' ? term.days : input.trialDays, 1, TRIAL_MAX_DAYS, `A trial lasts from 1 to ${TRIAL_MAX_DAYS} days.`)
      : null;
    if (!term.trial && input.trialDays !== undefined && input.trialDays !== null && input.trialDays !== '') throw new ApiError(400, 'bad_request', 'Trial days only go with a trial.');
    const onEnd = this.resolveOnEnd(input.onEnd, !!term.trial);

    const isAdmin = actor && actor.role === 'admin';
    const limits = {
      devices: this.cap(input.devices, plan.limits.devices, plan.caps.devices, isAdmin, 'PCs'),
      stores: this.cap(input.stores, plan.limits.stores, plan.caps.stores, isAdmin, 'shops'),
      users: this.cap(input.users, plan.limits.users, plan.caps.users, isAdmin, 'users'),
    };
    let modules = plan.modules.slice();
    if (isAdmin && Array.isArray(input.modules) && input.modules.length) modules = input.modules.filter((m) => MODULES.includes(m));
    if (!modules.length) throw new ApiError(400, 'bad_request', 'Choose at least one module.');

    const bindMode = ['device', 'domain', 'none'].includes(input.bindMode) ? input.bindMode : 'device';
    const domains = this.parseDomains(input.domains);
    if (bindMode === 'domain' && !domains.length) throw new ApiError(400, 'bad_request', 'Enter the website address (for example shop.example.com) the licence is for.');
    if (bindMode === 'none' && !isAdmin) throw new ApiError(403, 'forbidden', 'Only an administrator can issue a licence that is not tied to a PC or a website.');

    const brandId = input.brandId ? int(input.brandId, 0) || null : null;
    if (brandId && !this.getBrand(brandId)) throw new ApiError(400, 'bad_request', 'That brand does not exist.');
    const resellerId = input.resellerId ? int(input.resellerId, 0) || null : null;

    const start = input.startDate && /^\d{4}-\d{2}-\d{2}$/.test(input.startDate) ? Math.floor(Date.parse(input.startDate + 'T00:00:00Z') / 1000) : this.now();
    if (!Number.isFinite(start)) throw new ApiError(400, 'bad_request', 'The start date does not look right.');
    let exp;
    if (input.endsAt !== undefined) {
      // An exact end given by a tool (the staff API): null is "no end date".
      if (term.trial) throw new ApiError(400, 'bad_request', 'Give either the length of the trial or an end date, not both.');
      exp = input.endsAt === null ? null : wholeNumber(input.endsAt, 0, 4_102_444_800, 'The end date does not look right.');
    } else if (term.trial) exp = start + trialDays * DAY;
    else exp = term.days == null ? null : start + term.days * DAY;
    if (exp !== null && exp <= start) throw new ApiError(400, 'bad_request', 'The end date must be after the start date.');

    const whiteLevel = WHITE_LEVELS.includes(input.whiteLevel) ? input.whiteLevel : 'theme';
    if (whiteLevel === 'full' && !isAdmin) throw new ApiError(403, 'forbidden', 'Only an administrator can allow a full re-brand (a reseller licence).');

    const offline = input.offline === true || input.offline === 'on' || input.offline === '1';
    const actTerms = {
      online: !offline,
      checkInDays: int(this.setting('check_in_days'), 30) || 30,
      graceDays: int(this.setting('grace_days'), 60) || 60,
      offlineDays: int(this.setting('offline_days'), 365) || 365,
    };

    const made = transaction(this.db, () => {
      const owner = customer || this.upsertExternalCustomer(external, actor, ip);
      const lid = C.generateLicenceId();
      const key = C.generateLicenceKey();
      const t = this.now();
      this.db.prepare(`INSERT INTO licences(lid, licence_key, customer_id, reseller_id, plan_code, modules, limits, bind, brand_id, act, trial, white_level, on_end, nbf, exp, notes, created_by, created_at, updated_at)
        VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)`)
        .run(lid, key, owner.id, resellerId, plan.code, json(modules), json(limits), json({ mode: bindMode, domains }), brandId, json(actTerms), term.trial ? 1 : 0, whiteLevel, onEnd, start, exp, text(input.notes, 500), actor ? actor.id : null, t, t);
      if (hooks.inTransaction) hooks.inTransaction(lid, owner);
      return { lid, name: owner.name };
    });
    const how = term.trial ? `trial of ${trialDays} days, stops at the end` : (exp === null ? 'no end date' : `ends ${dateOf(exp)}`) + `, ${onEnd === 'banner' ? 'keeps working with a banner after the end' : 'stops at the end'}`;
    this.audit(actor, 'licence.create', `${made.lid} (${made.name})`, `${plan.code}, ${how}`, ip);
    return this.getLicence(made.lid);
  }

  cap(value, planDefault, planCap, isAdmin, label) {
    if (value === undefined || value === null || value === '') return planDefault;
    const n = int(value, planDefault);
    if (!isAdmin && planCap && n > planCap) throw new ApiError(403, 'forbidden', `This plan allows up to ${planCap} ${label}. Ask an administrator for more.`);
    return n;
  }

  parseDomains(value) {
    const list = Array.isArray(value) ? value : String(value || '').split(/[\s,;]+/);
    const out = [];
    for (const raw of list) {
      const d = String(raw).trim().toLowerCase().replace(/^https?:\/\//, '').replace(/\/.*$/, '').replace(/:\d+$/, '');
      if (!d) continue;
      if (!/^(\*\.)?[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)+$/.test(d) && d !== 'localhost') throw new ApiError(400, 'bad_request', `"${raw}" is not a website address.`);
      if (!out.includes(d)) out.push(d);
    }
    return out.slice(0, 20);
  }

  /** Changes what a licence allows; the revision goes up so that PCs pick the change up at their next check-in. */
  updateLicence(lid, input, actor, ip) {
    const lic = this.getLicence(lid);
    if (!lic) throw new ApiError(404, 'not_found', 'Licence not found.');
    if (lic.status === 'revoked') throw new ApiError(409, 'conflict', 'A revoked licence cannot be changed.');
    const isAdmin = actor && actor.role === 'admin';
    const plan = this.getPlan(input.planCode || lic.plan_code) || this.getPlan(lic.plan_code);
    const changes = [];

    let { modules, limits, exp, plan_code: planCode } = lic;
    if (input.planCode && input.planCode !== lic.plan_code && plan) {
      planCode = plan.code; modules = plan.modules.slice(); limits = { ...plan.limits };
      changes.push(`plan ${lic.plan_code} -> ${plan.code}`);
    }
    for (const [field, label, capKey] of [['devices', 'PCs', 'devices'], ['stores', 'shops', 'stores'], ['users', 'users', 'users']]) {
      if (input[field] !== undefined && input[field] !== '') {
        const n = this.cap(input[field], limits[field], plan && plan.caps[capKey], isAdmin, label);
        if (n !== limits[field]) { changes.push(`${label} ${limits[field]} -> ${n}`); limits = { ...limits, [field]: n }; }
      }
    }
    if (isAdmin && Array.isArray(input.modules) && input.modules.length) {
      modules = input.modules.filter((m) => MODULES.includes(m));
      changes.push('modules changed');
    }
    let trial = lic.trial;
    let onEnd = lic.on_end;
    if (input.extendTerm) {
      const term = this.resolveTerm(text(input.extendTerm, 20));
      if (term.days == null) { exp = null; changes.push('no end date'); } else {
        const base = exp && exp > this.now() ? exp : this.now(); // renewing before the end adds to the end date
        exp = base + term.days * DAY;
        changes.push(`renewed ${term.label}`);
      }
      // Renewing a trial with a paid term makes it a paid licence, which keeps working with a banner.
      if (trial && !term.trial) { trial = false; onEnd = 'banner'; changes.push('trial became paid'); }
    }
    if (input.onEnd !== undefined && input.onEnd !== '' && input.onEnd !== null) {
      const wanted = this.resolveOnEnd(input.onEnd, trial);
      if (wanted !== onEnd) { changes.push(`when it ends: ${onEnd} -> ${wanted}`); onEnd = wanted; }
    }
    let whiteLevel = lic.white_level;
    if (input.whiteLevel && WHITE_LEVELS.includes(input.whiteLevel) && input.whiteLevel !== lic.white_level) {
      if (input.whiteLevel === 'full' && !isAdmin) throw new ApiError(403, 'forbidden', 'Only an administrator can allow a full re-brand (a reseller licence).');
      whiteLevel = input.whiteLevel;
      changes.push(`branding freedom ${lic.white_level} -> ${whiteLevel}`);
    }
    if (input.notes !== undefined) {
      this.db.prepare('UPDATE licences SET notes = ? WHERE lid = ?').run(text(input.notes, 500), lid);
    }
    if (changes.length) {
      this.db.prepare('UPDATE licences SET white_level = ? WHERE lid = ?').run(whiteLevel, lid);
      this.db.prepare('UPDATE licences SET plan_code=?, modules=?, limits=?, exp=?, trial=?, on_end=?, rev = rev + 1, updated_at = ? WHERE lid = ?')
        .run(planCode, json(modules), json(limits), exp, trial ? 1 : 0, onEnd, this.now(), lid);
      this.audit(actor, 'licence.update', lid, changes.join('; '), ip);
    }
    return this.getLicence(lid);
  }

  /** Adds days to the end date, or to today when the licence has already ended (an ended trial runs again from today). */
  extendDays(lid, days, actor, ip) {
    const lic = this.getLicence(lid);
    if (!lic) throw new ApiError(404, 'not_found', 'Licence not found.');
    if (lic.status === 'revoked') throw new ApiError(409, 'conflict', 'A withdrawn licence cannot be changed. Issue a new licence.');
    const n = wholeNumber(days, 1, EXTEND_MAX_DAYS, `Give a whole number of days from 1 to ${EXTEND_MAX_DAYS}.`);
    if (lic.exp === null || lic.exp === undefined) throw new ApiError(409, 'conflict', 'This licence has no end date, so there is nothing to extend.');
    const t = this.now();
    const exp = (lic.exp > t ? lic.exp : t) + n * DAY;
    this.db.prepare('UPDATE licences SET exp = ?, rev = rev + 1, updated_at = ? WHERE lid = ?').run(exp, t, lid);
    this.audit(actor, 'licence.extend', lid, `${n} days, now ends ${dateOf(exp)}${lic.trial ? ' (trial)' : ''}`, ip);
    return this.getLicence(lid);
  }

  /** Turns a trial into a paid licence: no end date (or the term staff choose), and it keeps working with a banner at its end. */
  convertTrial(lid, opts, actor, ip) {
    const lic = this.getLicence(lid);
    if (!lic) throw new ApiError(404, 'not_found', 'Licence not found.');
    if (lic.status === 'revoked') throw new ApiError(409, 'conflict', 'A withdrawn licence cannot be changed. Issue a new licence.');
    if (!lic.trial) throw new ApiError(409, 'conflict', 'This licence is not a trial.');
    const term = this.resolveTerm(text(opts && opts.term, 20) || 'perpetual');
    if (term.trial) throw new ApiError(400, 'bad_request', 'Choose how long the paid licence lasts.');
    const t = this.now();
    const exp = term.days == null ? null : t + term.days * DAY;
    this.db.prepare("UPDATE licences SET trial = 0, on_end = 'banner', exp = ?, rev = rev + 1, updated_at = ? WHERE lid = ?").run(exp, t, lid);
    this.audit(actor, 'licence.convert', lid, `trial became paid, ${exp === null ? 'no end date' : 'ends ' + dateOf(exp)}`, ip);
    return this.getLicence(lid);
  }

  setStatus(lid, status, reason, actor, ip) {
    const lic = this.getLicence(lid);
    if (!lic) throw new ApiError(404, 'not_found', 'Licence not found.');
    if (lic.status === 'revoked' && status !== 'revoked') throw new ApiError(409, 'conflict', 'A revoked licence cannot be switched back on. Issue a new licence.');
    this.db.prepare('UPDATE licences SET status=?, status_reason=?, rev = rev + 1, updated_at=? WHERE lid=?').run(status, text(reason, 200), this.now(), lid);
    this.audit(actor, `licence.${status}`, lid, text(reason, 200), ip);
    return this.getLicence(lid);
  }

  // ---------- tokens ----------

  licenceToken(lic) {
    const customer = this.getCustomer(lic.customer_id) || {};
    const reseller = lic.reseller_id ? this.db.prepare('SELECT id, name FROM resellers WHERE id = ?').get(lic.reseller_id) : null;
    const brandRow = lic.brand_id ? this.getBrand(lic.brand_id) : null;
    return C.signToken({
      typ: 'lic', lid: lic.lid, rev: lic.rev, iat: this.now(), nbf: lic.nbf, exp: lic.exp,
      cust: { id: `C-${customer.id}`, name: customer.name || '', country: customer.country || '', email: customer.email || '' },
      product: PRODUCT, edition: lic.plan_code, modules: lic.modules, limits: lic.limits, bind: lic.bind,
      brand: brandRow ? { id: `B-${brandRow.id}`, ...brandRow.data } : null,
      reseller: reseller ? { id: `R-${reseller.id}`, name: reseller.name } : null,
      act: lic.act, trial: lic.trial, white: { level: lic.white_level || 'theme' },
      // What happens after `exp` is written here, signed, and nowhere else (spec 10.1). Only a paid licence can be "banner".
      onEnd: Studio.onEndOf(lic),
    }, this.signer);
  }

  /** What the licence says about its end: "banner" only for a paid licence that is set to it. A trial always stops (spec 10.1 and 13.1). */
  static onEndOf(lic) { return lic.on_end === 'banner' && !lic.trial ? 'banner' : 'stop'; }

  activationToken(lic, fpList, longOffline) {
    const t = this.now();
    let next;
    let until;
    if (!lic.act.online || longOffline) {
      next = until = t + (lic.act.offlineDays || 365) * DAY;
    } else {
      next = t + (lic.act.checkInDays || 30) * DAY;
      until = next + (lic.act.graceDays || 60) * DAY;
    }
    // A licence that stops at its end date never has an activation that outlasts it; one that keeps working with a banner does not (spec 4.2).
    if (lic.exp && Studio.onEndOf(lic) !== 'banner') { next = Math.min(next, lic.exp); until = Math.min(until, lic.exp); }
    return C.signToken({ typ: 'act', lid: lic.lid, rev: lic.rev, iat: t, fp: fpList, fpMin: Studio.fpMin(fpList.length), next, until }, this.signer);
  }

  crlToken() {
    const revoked = this.db.prepare("SELECT lid FROM licences WHERE status IN ('revoked','suspended') ORDER BY lid").all().map((r) => r.lid);
    const t = this.now();
    return C.signToken({ typ: 'crl', iat: t, next: t + DAY, revoked }, this.signer);
  }

  // ---------- activation protocol ----------

  parseFingerprint(fp) {
    if (!fp || typeof fp !== 'object' || Array.isArray(fp)) throw new ApiError(400, 'bad_request', 'The PC fingerprint is missing.');
    const parts = [];
    for (const [kind, hash] of Object.entries(fp)) {
      if (!FP_KINDS.includes(kind)) continue;
      if (!/^[0-9a-f]{32}$/.test(String(hash))) throw new ApiError(400, 'bad_request', 'The PC fingerprint is not valid.');
      const part = `${kind}:${hash}`;
      if (!parts.includes(part)) parts.push(part);
    }
    if (!parts.length) throw new ApiError(400, 'bad_request', 'The PC fingerprint is empty.');
    return parts.sort();
  }

  fingerprintList(value) {
    if (Array.isArray(value)) {
      const list = value.map(String);
      if (!list.length || list.some((h) => !/^(bios|board|cpu|disk|os):[0-9a-f]{32}$/.test(h))) throw new ApiError(400, 'bad_request', 'The PC fingerprint is not valid.');
      return list.slice().sort();
    }
    return this.parseFingerprint(value);
  }

  /** Spec section 7: at least 60% of the stored parts, and at least two strong parts (everything except the CPU id). */
  matches(stored, current) {
    return Studio.fingerprintMatches(stored, current, Studio.fpMin(stored.length));
  }

  static fpMin(count) { return Math.max(1, Math.ceil(count * 0.6)); }

  static fingerprintMatches(stored, current, fpMin) {
    const have = new Set(current);
    const common = stored.filter((p) => have.has(p));
    const strongStored = stored.filter((p) => !p.startsWith('cpu:')).length;
    const strongCommon = common.filter((p) => !p.startsWith('cpu:')).length;
    return common.length >= fpMin && strongCommon >= Math.min(2, strongStored) && common.length > 0;
  }

  checkUsable(lic) {
    const t = this.now();
    if (lic.status === 'revoked') return new ApiError(403, 'revoked', 'This licence has been withdrawn. Please contact your supplier.');
    if (lic.status === 'suspended') return new ApiError(403, 'suspended', 'This licence is on hold. Please contact your supplier.');
    if (t < lic.nbf) return new ApiError(403, 'not_started', 'This licence has not started yet.');
    // A licence that keeps working with a banner after its end date is still activated and checked in (spec 13.3).
    if (lic.exp && t > lic.exp && Studio.onEndOf(lic) !== 'banner') return new ApiError(403, 'expired', 'This licence has ended. Please renew it.');
    return null;
  }

  activate({ key, version, fp, host, longOffline }, ip) {
    const lic = this.getLicenceByKey(key);
    if (!lic) throw new ApiError(404, 'unknown_key', 'That licence key was not found. Please check it and try again.');
    const problem = this.checkUsable(lic);
    if (problem) { this.audit(null, 'activate.refused', lic.lid, problem.code, ip); throw problem; }
    const fpList = this.fingerprintList(fp);
    const hostName = text(host, 80);

    try {
      const result = transaction(this.db, () => {
        const t = this.now();
        if (lic.bind.mode !== 'device') {
          return { lic: this.licenceToken(lic), act: null, crl: this.crlToken() };
        }
        const rows = this.db.prepare('SELECT * FROM activations WHERE lid = ? AND active = 1').all(lic.lid);
        let row = rows.find((r) => this.matches(parse(r.fp, []), fpList));
        if (!row) {
          if (lic.limits.devices > 0 && rows.length >= lic.limits.devices) {
            throw new ApiError(409, 'limit_reached', `This licence is already used on ${rows.length} PC${rows.length === 1 ? '' : 's'}, which is all it allows. Free a PC in the Licence Studio, or ask your supplier for more.`);
          }
          const r = this.db.prepare('INSERT INTO activations(lid, fp, host, version, first_seen, last_seen, last_checkin, ip) VALUES (?,?,?,?,?,?,?,?)')
            .run(lic.lid, json(fpList), hostName, text(version, 30), t, t, t, text(ip, 64));
          row = { id: Number(r.lastInsertRowid) };
          this.recordEvent(lic.lid, 'activated', { activationId: row.id, host: hostName, actor: 'the customer' });
        } else {
          this.db.prepare('UPDATE activations SET fp=?, host=?, version=?, last_seen=?, last_checkin=?, ip=? WHERE id=?')
            .run(json(fpList), hostName || row.host, text(version, 30), t, t, text(ip, 64), row.id);
        }
        return { lic: this.licenceToken(lic), act: this.activationToken(lic, fpList, longOffline), crl: this.crlToken() };
      });
      this.audit(null, 'activate', lic.lid, hostName, ip);
      return result;
    } catch (e) {
      if (e instanceof ApiError) this.audit(null, 'activate.refused', lic.lid, `${e.code} ${hostName}`, ip);
      throw e;
    }
  }

  verifyOwnToken(token, type) {
    try {
      return C.verifyToken(token, this.trustedKeys(), type);
    } catch (e) {
      throw new ApiError(400, 'bad_request', 'The activation is not valid. Please activate again.');
    }
  }

  checkin({ lid, act, fp, version, usage }, ip) {
    const claims = this.verifyOwnToken(act, 'act');
    if (claims.lid !== lid) throw new ApiError(400, 'bad_request', 'The activation does not belong to this licence.');
    const lic = this.getLicence(lid);
    if (!lic) throw new ApiError(404, 'unknown_key', 'Licence not found.');
    const problem = this.checkUsable(lic);
    if (problem) { this.audit(null, 'checkin.refused', lid, problem.code, ip); throw problem; }
    const fpList = this.fingerprintList(fp);

    return transaction(this.db, () => {
      const rows = this.db.prepare('SELECT * FROM activations WHERE lid = ? AND active = 1').all(lid);
      const row = rows.find((r) => this.matches(parse(r.fp, []), fpList));
      if (!row) throw new ApiError(403, 'device_mismatch', 'This PC is no longer activated for the licence. Please activate it again.');
      const t = this.now();
      const cleanUsage = {};
      for (const k of ['stores', 'devices', 'users']) if (usage && Number.isFinite(usage[k])) cleanUsage[k] = Math.max(0, Math.min(1e6, Math.trunc(usage[k])));
      this.db.prepare('UPDATE activations SET fp=?, version=?, usage=?, last_seen=?, last_checkin=?, ip=? WHERE id=?')
        .run(json(fpList), text(version, 30), json(cleanUsage), t, t, text(ip, 64), row.id);
      return { lic: this.licenceToken(lic), act: this.activationToken(lic, fpList, false), crl: this.crlToken() };
    });
  }

  deactivate({ lid, act, fp }, ip) {
    const claims = this.verifyOwnToken(act, 'act');
    if (claims.lid !== lid) throw new ApiError(400, 'bad_request', 'The activation does not belong to this licence.');
    const fpList = this.fingerprintList(fp);
    const rows = this.db.prepare('SELECT * FROM activations WHERE lid = ? AND active = 1').all(lid);
    const row = rows.find((r) => this.matches(parse(r.fp, []), fpList));
    if (row) {
      // The customer's own "free this PC" is allowed MOVE_LIMIT times in any rolling MOVE_WINDOW_DAYS days (spec section 8, "Moves").
      const moves = this.moves(lid);
      if (moves.used >= moves.allowed) {
        this.audit(null, 'deactivate.refused', lid, 'move_limit_reached', ip);
        throw new ApiError(409, 'move_limit_reached', `This licence has already been moved to a new PC ${moves.allowed} times in the last 12 months, which is all a customer can do alone. To move it again, please contact your supplier: they can free the old PC for you.`);
      }
      transaction(this.db, () => {
        this.db.prepare('UPDATE activations SET active = 0 WHERE id = ?').run(row.id);
        this.recordEvent(lid, 'client_deactivate', { activationId: row.id, host: row.host, actor: 'the customer' });
      });
      this.audit(null, 'deactivate', lid, row.host, ip);
    }
    return { ok: true };
  }

  /** How many times the customer moved this licence in the last 365 days (spec section 8, "Moves"). Staff frees do not count. */
  moves(lid) {
    const since = this.now() - MOVE_WINDOW_DAYS * DAY;
    const used = this.db.prepare("SELECT COUNT(*) AS n FROM licence_events WHERE lid = ? AND kind = 'client_deactivate' AND ts > ?").get(lid, since).n;
    return { used, allowed: MOVE_LIMIT, windowDays: MOVE_WINDOW_DAYS };
  }

  recordEvent(lid, kind, { activationId = null, host = '', actor = '', reason = '' } = {}) {
    this.db.prepare('INSERT INTO licence_events(lid, ts, kind, activation_id, host, actor, reason) VALUES (?,?,?,?,?,?,?)')
      .run(lid, this.now(), kind, activationId, text(host, 80), text(actor, 200), text(reason, 200));
  }

  /** What happened to a licence's PCs, newest first: activations, moves by the customer, PCs freed by staff (who and why). */
  history(lid, limit = 100) {
    return this.db.prepare('SELECT * FROM licence_events WHERE lid = ? ORDER BY ts DESC, id DESC LIMIT ?').all(lid, limit);
  }

  listActivations(lid) {
    return this.db.prepare('SELECT * FROM activations WHERE lid = ? ORDER BY active DESC, last_seen DESC').all(lid)
      .map((a) => ({ ...a, fp: parse(a.fp, []), usage: parse(a.usage, {}) }));
  }

  getActivation(id) {
    return this.db.prepare('SELECT * FROM activations WHERE id = ?').get(id) || null;
  }

  /** Staff frees a PC's seat. Not limited, but a reason is needed and it is written down with who did it. Returns the licence id. */
  freeDevice(activationId, actor, ip, reason, expectLid) {
    const a = this.getActivation(activationId);
    if (!a || (expectLid && a.lid !== expectLid)) throw new ApiError(404, 'not_found', 'That PC was not found.');
    const why = text(reason, 200);
    if (!why) throw new ApiError(400, 'bad_request', 'Please say why you are freeing this PC (for example: the old computer broke).');
    if (!a.active) return a.lid; // already free: nothing to do
    transaction(this.db, () => {
      this.db.prepare('UPDATE activations SET active = 0 WHERE id = ?').run(activationId);
      this.recordEvent(a.lid, 'staff_free', { activationId, host: a.host, actor: actorLabel(actor), reason: why });
    });
    this.audit(actor, 'device.free', a.lid, `${a.host}: ${why}`, ip);
    return a.lid;
  }

  // ---------- repeated calls from tools ----------

  /** The licence an earlier "make a licence" call with this key made, if any: { body_hash, lid }. */
  findIdempotent(accountId, key) {
    return this.db.prepare('SELECT body_hash, lid FROM idempotency WHERE account_id = ? AND idem_key = ?').get(accountId, key) || null;
  }

  saveIdempotent(accountId, key, bodyHash, lid) {
    this.db.prepare('INSERT INTO idempotency(account_id, idem_key, body_hash, lid, created_at) VALUES (?,?,?,?,?)').run(accountId, key, bodyHash, lid, this.now());
  }

  // ---------- offline activation ----------

  static parseRequestCode(code) {
    const s = String(code || '').replace(/\s+/g, '');
    if (!s.startsWith('NGOSREQ1.')) throw new ApiError(400, 'bad_request', 'That is not a request code. It starts with NGOSREQ1.');
    try {
      const obj = JSON.parse(C.fromB64u(s.slice('NGOSREQ1.'.length)).toString('utf8'));
      if (!obj || typeof obj !== 'object') throw new Error('x');
      return obj;
    } catch (_) {
      throw new ApiError(400, 'bad_request', 'The request code is damaged. Please copy it again, all of it.');
    }
  }

  offlineActivate(requestCode, actor, ip) {
    const req = Studio.parseRequestCode(requestCode);
    const result = this.activate({ key: req.key, version: req.version, fp: req.fp, host: req.host, longOffline: true }, ip);
    this.audit(actor, 'activate.offline', this.getLicenceByKey(req.key).lid, text(req.host, 80), ip);
    const body = C.b64u(Buffer.from(JSON.stringify({ lic: result.lic, act: result.act, crl: result.crl }), 'utf8'));
    return `NGOSRES1.${body}`;
  }

  // ---------- messages for the sales team ----------

  customerMessage(lic) {
    const customer = this.getCustomer(lic.customer_id) || {};
    const brand = lic.brand_id ? this.getBrand(lic.brand_id) : null;
    const company = brand ? brand.data.name : this.setting('company_name');
    const supportEmail = brand && brand.data.supportEmail ? brand.data.supportEmail : this.setting('support_email');
    const supportPhone = brand && brand.data.supportPhone ? brand.data.supportPhone : this.setting('support_phone');
    const support = [supportEmail, supportPhone].filter(Boolean).join(' · ');
    const until = lic.exp ? new Date(lic.exp * 1000).toISOString().slice(0, 10) : 'no end date';
    const lines = [
      `Hello ${customer.contact_name || customer.name || ''},`.replace(/,$/, ',').replace('Hello ,', 'Hello,'),
      '',
      `Thank you for choosing ${company}. Your licence is ready.`,
      '',
      `Licence key:  ${lic.licence_key}`,
      lic.trial ? `Trial until:  ${until} (the program stops on that day, unless you buy the full licence before)` : `Valid until:  ${until}`,
    ];
    if (lic.bind.mode === 'device') lines.push(`PCs allowed:  ${lic.limits.devices || 'any number of'}`);
    if (lic.bind.mode === 'domain') lines.push(`Website:      ${lic.bind.domains.join(', ')}`);
    lines.push('',
      'To start:',
      '  1. Install the program (we sent the installer separately).',
      '  2. Open it. The Activation window appears.',
      '  3. Type the licence key above and press Activate. The PC needs the Internet for this one time.',
      '',
      'No Internet on that PC? Choose "Activate without Internet" in the same window, read us the code it shows, and we will send you a code to type back.',
    );
    if (support) lines.push('', `Questions? ${support}`);
    lines.push('', `${company}`);
    return lines.join('\n');
  }

  licenceFile(lic) {
    return this.licenceToken(lic) + '\n';
  }
}

module.exports = { Studio, ApiError, MODULES, TERMS, FP_KINDS, WHITE_LEVELS, ON_END, DAY, PRODUCT, MOVE_LIMIT, MOVE_WINDOW_DAYS, TRIAL_DEFAULT_DAYS, TRIAL_MAX_DAYS, EXTEND_MAX_DAYS, actorLabel };
