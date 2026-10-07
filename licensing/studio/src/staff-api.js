'use strict';
// The staff API (version 1): what the main Setup Studio calls to show a client's licence and press a few buttons.
// The contract is in ../../spec/STAFF-API.md. It signs in with a token an administrator made ("service account"), uses the
// Studio's own roles, writes every call to the History, and never touches a signing key (the Studio signs; this only asks it to).

const crypto = require('node:crypto');
const { ApiError, Studio, DAY } = require('../lib/studio');
const { can } = require('../lib/auth');
const { readJson, sendJson, RateLimiter } = require('../lib/http');

const PREFIX = '/api/staff/v1/';
const IDEMPOTENCY_KEY = /^[A-Za-z0-9._:-]{8,128}$/;

const PATHS = {
  list: /^\/api\/staff\/v1\/customers\/([^/]+)\/licences$/,
  create: /^\/api\/staff\/v1\/licences$/,
  free: /^\/api\/staff\/v1\/licences\/([^/]+)\/devices\/([^/]+)\/free$/,
  extend: /^\/api\/staff\/v1\/licences\/([^/]+)\/extend$/,
  convert: /^\/api\/staff\/v1\/licences\/([^/]+)\/convert$/,
  revoke: /^\/api\/staff\/v1\/licences\/([^/]+)\/revoke$/,
  restore: /^\/api\/staff\/v1\/licences\/([^/]+)\/restore$/,
};

// What a token's role needs for each call: the Studio's own permission names (lib/auth.js).
const ROUTES = [
  { name: 'list', method: 'GET', perm: 'licences.view' },
  { name: 'create', method: 'POST', perm: 'licences.create' },
  { name: 'free', method: 'POST', perm: 'devices.free' },
  { name: 'extend', method: 'POST', perm: 'licences.change' },
  { name: 'convert', method: 'POST', perm: 'licences.change' },
  { name: 'revoke', method: 'POST', perm: 'licences.hold' },
  { name: 'restore', method: 'POST', perm: 'licences.hold' },
];

/** Same text for the same JSON, whatever the order of the keys: used to tell a repeated call from a different one. */
function canonical(value) {
  if (Array.isArray(value)) return `[${value.map(canonical).join(',')}]`;
  if (value && typeof value === 'object') return `{${Object.keys(value).sort().map((k) => `${JSON.stringify(k)}:${canonical(value[k])}`).join(',')}}`;
  return JSON.stringify(value === undefined ? null : value);
}

const maskKey = (key) => `NGOS-*****-*****-*****-${String(key).slice(-5)}`;

/** What a person at the main Studio sees as the state of a licence (see STAFF-API.md for the words). */
function statusOf(lic, now) {
  if (lic.status === 'revoked') return 'withdrawn';
  if (lic.status === 'suspended') return 'revoked';
  if (lic.nbf > now) return 'not_started';
  if (lic.exp && now > lic.exp) return Studio.onEndOf(lic) === 'banner' ? 'ended' : 'stopped';
  return 'active';
}

function licenceView(studio, lic) {
  const now = studio.now();
  const devices = studio.listActivations(lic.lid).filter((a) => a.active).map((a) => ({
    id: a.id, label: a.host || 'Unnamed PC', activatedAt: a.first_seen, lastCheckIn: a.last_checkin, version: a.version || '',
  }));
  const trialDaysLeft = lic.trial ? (lic.exp ? Math.max(0, Math.ceil((lic.exp - now) / DAY)) : null) : null;
  return {
    lid: lic.lid,
    keyMasked: maskKey(lic.licence_key),
    plan: lic.plan_code,
    modules: lic.modules,
    limits: { devices: lic.limits.devices, stores: lic.limits.stores, users: lic.limits.users },
    exp: lic.exp === undefined ? null : lic.exp,
    onEnd: Studio.onEndOf(lic),
    trial: !!lic.trial,
    trialDaysLeft,
    status: statusOf(lic, now),
    devices,
    moves: studio.moves(lic.lid),
  };
}

function actingUser(req) {
  const raw = String(req.headers['x-acting-user'] || '').trim();
  let value = raw;
  try { value = decodeURIComponent(raw); } catch (_) { /* not encoded: use it as it is */ }
  return value.replace(/[\u0000-\u001f\u007f]/g, ' ').trim().slice(0, 80);
}

const need = (value, message) => {
  if (typeof value !== 'string' || !value.trim()) throw new ApiError(400, 'bad_request', message);
  return value.trim();
};

const optionalCount = (value, label) => {
  if (value === undefined || value === null) return undefined;
  if (!Number.isInteger(value) || value < 0 || value > 1_000_000) throw new ApiError(400, 'bad_request', `${label} must be a whole number.`);
  return value;
};

/** The end date of a new licence: a Unix time, a date (the end of that day, UTC) or null. */
function endDate(value) {
  if (value === null) return null;
  if (typeof value === 'number') return value;
  if (typeof value === 'string' && /^\d{4}-\d{2}-\d{2}$/.test(value)) {
    const t = Date.parse(`${value}T23:59:59Z`);
    if (Number.isFinite(t)) return Math.floor(t / 1000);
  }
  throw new ApiError(400, 'bad_request', 'The end date (exp) must be a Unix time, a date like 2027-12-31, or null for no end date.');
}

function createStaffApi({ studio, accounts, clientIp, clock }) {
  const perToken = new RateLimiter(120, 60, clock);   // 120 calls a minute for each token
  const wrongTokens = new RateLimiter(10, 600, clock); // 10 wrong tokens in 10 minutes for each address
  const pathParam = (v) => { try { return decodeURIComponent(v); } catch (_) { throw new ApiError(400, 'bad_request', 'The address of the call is not valid.'); } };

  function signIn(req, ip) {
    const match = /^Bearer\s+(\S+)$/i.exec(String(req.headers.authorization || ''));
    const account = match ? accounts.authenticate(match[1]) : null;
    if (account) return account;
    if (!wrongTokens.take(ip)) throw new ApiError(429, 'rate_limited', 'Too many wrong tokens from this address. Please wait ten minutes.');
    studio.audit(null, 'staff.auth.refused', '', 'no token, a wrong token, or one that was switched off', ip);
    throw new ApiError(401, 'unauthorized', 'The access token is missing, wrong, or switched off.');
  }

  // ---------- the calls ----------

  const calls = {
    list(ctx) {
      const external = studio.cleanExternalId(pathParam(ctx.params[0]));
      ctx.call.target = external;
      const customer = studio.getCustomerByExternalId(external);
      const licences = customer ? studio.listLicences({ customerId: customer.id }) : [];
      return { status: 200, body: { licences: licences.map((l) => licenceView(studio, l)) } };
    },

    async create(ctx) {
      const key = String(ctx.req.headers['idempotency-key'] || '').trim();
      if (!key) throw new ApiError(400, 'idempotency_key_required', 'Please send an Idempotency-Key header, so that a repeated call can never make a second licence.');
      if (!IDEMPOTENCY_KEY.test(key)) throw new ApiError(400, 'bad_request', 'The Idempotency-Key must be 8 to 128 letters, digits or the signs . _ : -');
      const body = await readJson(ctx.req);
      const bodyHash = crypto.createHash('sha256').update(canonical(body)).digest('hex');
      ctx.call.detail = `key ${key}`;

      const prior = studio.findIdempotent(ctx.account.id, key);
      if (prior) {
        if (prior.body_hash !== bodyHash) throw new ApiError(422, 'idempotency_conflict', 'That Idempotency-Key was already used for a different request. Use a new key for a new licence.');
        const lic = studio.getLicence(prior.lid);
        ctx.call.target = prior.lid;
        ctx.call.detail = `repeated call, same licence returned (key ${key})`;
        return { status: 200, body: { lid: lic.lid, key: lic.licence_key } };
      }

      const external = need(body.externalCustomerId, 'externalCustomerId is needed: the client\'s id in the main Studio.');
      const name = need(body.customerName, 'customerName is needed: the client\'s business name.');
      const plan = need(body.plan, 'plan is needed: a plan code from the Licence Studio\'s Plans page.');
      if (body.country !== undefined && body.country !== null && typeof body.country !== 'string') throw new ApiError(400, 'bad_request', 'country must be text.');
      const isTrial = body.trialDays !== undefined && body.trialDays !== null;
      if (isTrial && 'exp' in body) throw new ApiError(400, 'bad_request', 'Give either trialDays or exp, not both.');
      if (body.onEnd !== undefined && body.onEnd !== null && typeof body.onEnd !== 'string') throw new ApiError(400, 'bad_request', 'onEnd must be "banner" or "stop".');

      const planRow = studio.getPlan(plan);
      if (!planRow || !planRow.active) throw new ApiError(400, 'bad_request', `There is no plan "${plan.slice(0, 40)}" to sell. Plan codes are on the Licence Studio's Plans page.`);
      if (body.modules !== undefined) {
        if (!Array.isArray(body.modules) || body.modules.some((m) => typeof m !== 'string')) throw new ApiError(400, 'bad_request', 'modules must be a list of module names.');
        const same = planRow && body.modules.length === planRow.modules.length && body.modules.every((m) => planRow.modules.includes(m));
        if (!same && ctx.account.role !== 'admin') throw new ApiError(403, 'forbidden', 'Only an administrator token can change what a plan includes.');
      }
      let limits = {};
      if (body.limits !== undefined) {
        if (!body.limits || typeof body.limits !== 'object' || Array.isArray(body.limits)) throw new ApiError(400, 'bad_request', 'limits must be like {"devices": 3, "stores": 1, "users": 10}.');
        limits = { devices: optionalCount(body.limits.devices, 'limits.devices'), stores: optionalCount(body.limits.stores, 'limits.stores'), users: optionalCount(body.limits.users, 'limits.users') };
      }
      let brandId;
      if (body.brandId !== undefined && body.brandId !== null) {
        if (!Number.isInteger(body.brandId) || body.brandId < 1) throw new ApiError(400, 'bad_request', 'brandId must be the number of a brand on the Licence Studio\'s Brands page.');
        brandId = body.brandId;
      }
      let white = body.white;
      if (white && typeof white === 'object' && !Array.isArray(white)) white = white.level;
      if (white !== undefined && white !== null && typeof white !== 'string') throw new ApiError(400, 'bad_request', 'white must be "none", "theme" or "full".');
      if (white && !['none', 'theme', 'full'].includes(white)) throw new ApiError(400, 'bad_request', 'white must be "none", "theme" or "full".');
      if (body.bindMode !== undefined && !['device', 'domain', 'none'].includes(body.bindMode)) throw new ApiError(400, 'bad_request', 'bindMode must be "device", "domain" or "none".');
      if (body.domains !== undefined && !Array.isArray(body.domains) && typeof body.domains !== 'string') throw new ApiError(400, 'bad_request', 'domains must be a list of website addresses.');

      const lic = studio.createLicence({
        customer: { externalId: external, name, country: body.country || '' },
        planCode: plan,
        modules: body.modules,
        devices: limits.devices, stores: limits.stores, users: limits.users,
        trialDays: isTrial ? body.trialDays : undefined,
        endsAt: !isTrial && 'exp' in body ? endDate(body.exp) : undefined,
        onEnd: body.onEnd,
        brandId,
        whiteLevel: white || undefined,
        bindMode: body.bindMode,
        domains: body.domains,
      }, ctx.actor, ctx.ip, { inTransaction: (lid) => studio.saveIdempotent(ctx.account.id, key, bodyHash, lid) });
      ctx.call.target = lic.lid;
      ctx.call.detail = `${lic.plan_code} for ${external} (key ${key})`;
      return { status: 201, body: { lid: lic.lid, key: lic.licence_key } };
    },

    async free(ctx) {
      const lid = pathParam(ctx.params[0]);
      ctx.call.target = lid;
      const id = /^\d{1,12}$/.test(ctx.params[1]) ? Number(ctx.params[1]) : NaN;
      if (!Number.isInteger(id)) throw new ApiError(404, 'not_found', 'That PC was not found.');
      const body = await readJson(ctx.req);
      const reason = need(body.reason, 'Please say why this PC is freed (reason), for example: the old computer broke.');
      studio.freeDevice(id, ctx.actor, ctx.ip, reason, lid);
      ctx.call.detail = `PC ${id}: ${reason}`;
      return { status: 200, body: { ok: true, licence: licenceView(studio, studio.getLicence(lid)) } };
    },

    async extend(ctx) {
      const lid = pathParam(ctx.params[0]);
      ctx.call.target = lid;
      const body = await readJson(ctx.req);
      const lic = studio.extendDays(lid, body.days, ctx.actor, ctx.ip);
      ctx.call.detail = `${body.days} days`;
      return { status: 200, body: { ok: true, licence: licenceView(studio, lic) } };
    },

    async convert(ctx) {
      const lid = pathParam(ctx.params[0]);
      ctx.call.target = lid;
      await readJson(ctx.req);
      const lic = studio.convertTrial(lid, {}, ctx.actor, ctx.ip);
      return { status: 200, body: { ok: true, licence: licenceView(studio, lic) } };
    },

    async revoke(ctx) {
      const lid = pathParam(ctx.params[0]);
      ctx.call.target = lid;
      const body = await readJson(ctx.req);
      const reason = need(body.reason, 'Please say why the licence is switched off (reason), for example: payment overdue.');
      const current = studio.getLicence(lid);
      if (!current) throw new ApiError(404, 'not_found', 'Licence not found.');
      if (current.status === 'revoked') throw new ApiError(409, 'conflict', 'This licence was withdrawn for good, so there is nothing to switch off.');
      const lic = studio.setStatus(lid, 'suspended', reason, ctx.actor, ctx.ip);
      ctx.call.detail = reason;
      return { status: 200, body: { ok: true, licence: licenceView(studio, lic) } };
    },

    async restore(ctx) {
      const lid = pathParam(ctx.params[0]);
      ctx.call.target = lid;
      await readJson(ctx.req);
      const current = studio.getLicence(lid);
      if (!current) throw new ApiError(404, 'not_found', 'Licence not found.');
      const lic = current.status === 'active' ? current : studio.setStatus(lid, 'active', '', ctx.actor, ctx.ip);
      return { status: 200, body: { ok: true, licence: licenceView(studio, lic) } };
    },
  };

  /** Handles one request for a path under /api/staff/v1/. Never throws: every problem becomes {error, message}. */
  return async function handle(req, res, url) {
    const ip = clientIp(req);
    const call = { name: 'call', target: '', detail: '' };
    let account = null;
    let acting = '';
    try {
      account = signIn(req, ip);
      if (!perToken.take(`token:${account.id}`)) throw new ApiError(429, 'rate_limited', 'Too many calls. Please wait a minute.');
      acting = actingUser(req);

      const route = ROUTES.find((r) => r.method === req.method && PATHS[r.name].test(url.pathname));
      if (!route) throw new ApiError(404, 'not_found', 'Unknown call.');
      call.name = route.name;
      const params = PATHS[route.name].exec(url.pathname).slice(1);
      try { call.target = decodeURIComponent(params[0]).slice(0, 80); } catch (_) { call.target = ''; }
      if (!can({ role: account.role }, route.perm)) throw new ApiError(403, 'forbidden', 'This access token\'s role may not do that. Ask an administrator for a token with a different role.');
      if (req.method !== 'GET' && !acting) throw new ApiError(400, 'acting_user_required', 'Please send the name of the staff member in the X-Acting-User header, so the Licence Studio can write down who did this.');

      const label = `${acting || '(no name given)'} via ${account.name}`;
      const ctx = {
        req, url, ip, account, call, params,
        actor: { id: null, email: label, name: label, role: account.role },
      };
      const result = await calls[route.name](ctx);
      studio.audit(ctx.actor, `staff.${call.name}`, call.target, call.detail, ip);
      return sendJson(res, result.status, result.body);
    } catch (e) {
      if (e instanceof ApiError) {
        // Calls refused after sign-in are written down too, with who asked; a refusal for rate or a wrong token is not written one by one.
        if (account && e.code !== 'rate_limited') studio.audit({ id: null, email: `${acting || '(no name given)'} via ${account.name}` }, `staff.${call.name}.refused`, call.target, `${e.code}: ${e.message}`, ip);
        // A body that is too big was not read to the end: answer, then close the connection.
        return sendJson(res, e.status, { error: e.code, message: e.message }, e.status === 413 ? { Connection: 'close' } : {});
      }
      console.error('Staff API error:', e);
      return sendJson(res, 500, { error: 'server_error', message: 'Something went wrong in the Licence Studio.' });
    }
  };
}

module.exports = { createStaffApi, PREFIX, licenceView, statusOf };
