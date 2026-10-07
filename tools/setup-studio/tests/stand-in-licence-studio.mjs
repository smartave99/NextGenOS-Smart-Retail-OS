// A stand-in for the Licence Studio's staff calls ("contract v1"), on this PC, for the Studio's tests. It speaks only what the Studio uses:
//
//   GET  /api/staff/v1/customers/{id}/licences
//   POST /api/staff/v1/licences (Idempotency-Key)                      -> { lid, key }
//   POST /api/staff/v1/licences/{lid}/devices/{device}/free | /extend | /convert | /revoke | /restore
//
// with a Bearer staff access code, an X-Acting-User header, and errors written as { error, message }. It keeps licences in memory and plays the rules that matter to the Studio:
// a licence made twice with the same Idempotency-Key is made once, two moves of a PC a year at most, only a trial can be extended or turned into a paid one.
//
// Nothing here is the real Licence Studio (another program, written separately). What the real one answers is NOT verified by these tests (docs/SETUP-STUDIO.md says so). The
// stand-in writes its dates in two different ways (seconds, and a date text) on purpose: the Studio must read both.
import http from 'node:http';
import { createHash } from 'node:crypto';

const wait = (ms) => new Promise((done) => setTimeout(done, ms));
const hash = (value) => createHash('sha256').update(JSON.stringify(value)).digest('hex');

/**
 * Starts the stand-in. `token` is the staff access code it accepts; `plans` are the plan names it knows. Returns { url, close, options, seen, ... };
 * change `options` while it runs to change what it does next.
 */
export async function standInLicenceStudio({ token = 'licence-staff-code-0001-abcdef', plans = ['starter', 'business', 'growth'] } = {}) {
  const options = {
    forbidWrites: false,        // answer 403 to everything that changes something (an access code that may only look)
    forbidReads: false,         // answer 403 to looking too
    down: false,                // cut every request off with no answer
    html: false,                // answer with a web page, as another program at that address would
    unknownCustomer404: false,  // answer 404 { error: "unknown_customer" } for a customer it has no licence for (instead of an empty list)
    oldServer: false,           // answer 404 { error: "not_found" } to every staff call (an older Licence Studio)
    hideListOnce: 0,            // the next lists say "none" although there is one (an answer that did not arrive, a retry)
    dropAnswerOnce: 0,          // the next "make a licence" requests are carried out but their answers are cut off
    slowMs: 0,                  // wait this long before answering
    fail: [],                   // [{ match: /path/, status: 500, times: 1, body? }]: answer an error to the next such requests
    bigAnswer: false,           // answer with far more than a licence list should be
    onRequest: null,            // a function called with each request as it arrives (a test may add notes to it)
  };
  const seen = [];
  const licences = new Map();       // lid -> licence
  const byIdempotency = new Map();  // key -> { bodyHash, lid }
  let counter = 0;
  let closed = false;
  const sockets = new Set();

  const maskKey = (key) => key.replace(/^(NGOS)-[A-Z0-9]{5}-[A-Z0-9]{5}-[A-Z0-9]{5}-/, '$1-•••••-•••••-•••••-');
  const view = (l) => ({
    lid: l.lid, keyMasked: maskKey(l.key), plan: l.plan, modules: l.modules, limits: l.limits, exp: l.exp, onEnd: l.onEnd, trial: l.trial, trialDaysLeft: l.trial ? l.trialDaysLeft : null, status: l.status,
    devices: l.devices, moves: { used: l.moves, allowed: 2, windowDays: 365 },
  });
  const makeKey = (n) => { const part = (i) => (n * 7919 + i * 104729).toString(36).toUpperCase().padStart(5, '0').slice(-5).replace(/[ILOU]/g, 'X'); return `NGOS-${part(1)}-${part(2)}-${part(3)}-${part(4)}`; };

  /** Puts a licence in directly (for a test that needs one the Studio did not ask for). */
  function seed(customerId, over = {}) {
    counter += 1;
    const lid = over.lid ?? `L-SEED${String(counter).padStart(4, '0')}`;
    const l = { lid, key: over.key ?? makeKey(counter), customerId, plan: 'business', modules: ['pos', 'hub'], limits: { devices: 3, stores: 1, users: 10 }, exp: null, onEnd: 'banner', trial: false, trialDaysLeft: null, status: 'active', devices: [], moves: 0, ...over };
    licences.set(lid, l);
    return l;
  }
  const addDevice = (lid, device = {}) => { const l = licences.get(lid); l.devices.push({ id: `pc-${l.devices.length + 1}`, label: `Counter ${l.devices.length + 1}`, activatedAt: 1_790_000_000, lastCheckIn: '2026-10-05T08:30:00Z', version: '1.4.0', ...device }); return l; };

  const reply = (res, status, body, type = 'application/json; charset=utf-8') => { res.writeHead(status, { 'content-type': type }); res.end(typeof body === 'string' ? body : JSON.stringify(body)); };
  const error = (res, status, code, message) => reply(res, status, { error: code, message });

  const server = http.createServer(async (req, res) => {
    const url = new URL(req.url, 'http://127.0.0.1');
    const chunks = [];
    for await (const c of req) chunks.push(c);
    let body = null;
    try { body = chunks.length ? JSON.parse(Buffer.concat(chunks).toString('utf8')) : null; } catch { body = null; }
    const entry = { method: req.method, path: url.pathname, acting: req.headers['x-acting-user'] ?? null, idempotency: req.headers['idempotency-key'] ?? null, hadCode: /^Bearer .+/.test(req.headers.authorization ?? ''), body };
    seen.push(entry);
    options.onRequest?.(entry);
    if (options.down) { req.socket.destroy(); return undefined; }
    if (options.slowMs) await wait(options.slowMs);
    if (options.html) return reply(res, 200, '<html><body>Welcome to some other web page</body></html>', 'text/html; charset=utf-8');
    const planned = options.fail.find((f) => f.times > 0 && f.match.test(url.pathname));
    if (planned) { planned.times -= 1; return reply(res, planned.status, planned.body ?? { error: 'server_error', message: 'Something broke inside the Licence Studio.' }); }
    if (req.headers.authorization !== `Bearer ${token}`) return error(res, 401, 'unauthorized', 'The staff access code was not accepted.');
    if (!entry.acting) return error(res, 400, 'acting_user_required', 'Say which staff member is acting (X-Acting-User).');
    if (options.oldServer) return error(res, 404, 'not_found', 'There is nothing at this address.');
    if (options.forbidReads || (options.forbidWrites && req.method !== 'GET')) return error(res, 403, 'forbidden', req.method === 'GET' ? 'This staff access code may not look at licences.' : 'This staff access code may only look, not change anything.');
    if (options.bigAnswer) { res.writeHead(200, { 'content-type': 'application/json' }); res.end(`{"licences":[],"padding":"${'x'.repeat(2_500_000)}"}`); return undefined; }

    const path = url.pathname.replace(/^\/api\/staff\/v1/, '');
    let m;
    if (req.method === 'GET' && (m = /^\/customers\/([^/]+)\/licences$/.exec(path))) {
      const customer = decodeURIComponent(m[1]);
      const mine = [...licences.values()].filter((l) => l.customerId === customer);
      if (options.hideListOnce > 0) { options.hideListOnce -= 1; return reply(res, 200, { licences: [] }); }
      if (!mine.length && options.unknownCustomer404) return error(res, 404, 'unknown_customer', 'No customer with that id.');
      return reply(res, 200, { licences: mine.map(view) });
    }
    if (req.method === 'POST' && path === '/licences') {
      const key = entry.idempotency;
      if (!key) return error(res, 400, 'idempotency_key_required', 'Send an Idempotency-Key.');
      const b = body ?? {};
      if (typeof b.externalCustomerId !== 'string' || !b.externalCustomerId) return error(res, 400, 'bad_request', 'The customer id is missing.');
      if (!plans.includes(b.plan)) return error(res, 400, 'unknown_plan', `There is no plan called "${b.plan}". The plans are ${plans.join(', ')}.`);
      if (!Number.isInteger(b.limits?.devices) || b.limits.devices < 1) return error(res, 400, 'bad_request', 'The number of PCs must be a whole number of 1 or more.');
      const seenBefore = byIdempotency.get(key);
      if (seenBefore) {
        if (seenBefore.bodyHash !== hash(b)) return error(res, 409, 'idempotency_conflict', 'That Idempotency-Key was used for a different request.');
        const l = licences.get(seenBefore.lid);
        return reply(res, 200, { lid: l.lid, key: l.key });
      }
      counter += 1;
      const trial = typeof b.trialDays === 'number';
      const l = { lid: `L-NEW${String(counter).padStart(4, '0')}`, key: makeKey(counter), customerId: b.externalCustomerId, customerName: b.customerName, plan: b.plan, modules: ['pos', 'hub'], limits: { devices: b.limits.devices, stores: 1, users: 10 },
        exp: trial ? 1_790_000_000 + b.trialDays * 86400 : (b.exp ?? null), onEnd: b.onEnd === 'stop' ? 'stop' : 'banner', trial, trialDaysLeft: trial ? b.trialDays : null, status: 'active', devices: [], moves: 0, request: b };
      licences.set(l.lid, l);
      byIdempotency.set(key, { bodyHash: hash(b), lid: l.lid });
      if (options.dropAnswerOnce > 0) { options.dropAnswerOnce -= 1; req.socket.destroy(); return undefined; }
      return reply(res, 201, { lid: l.lid, key: l.key });
    }
    if (req.method === 'POST' && (m = /^\/licences\/([^/]+)\/(extend|convert|revoke|restore)$/.exec(path))) {
      const l = licences.get(decodeURIComponent(m[1]));
      if (!l) return error(res, 404, 'unknown_licence', 'No licence with that id.');
      if (m[2] === 'extend') {
        if (!l.trial) return error(res, 409, 'not_a_trial', 'Only a trial can be extended.');
        if (!Number.isInteger(body?.days) || body.days < 1) return error(res, 400, 'bad_request', 'days must be a whole number of 1 or more.');
        l.trialDaysLeft += body.days; l.exp += body.days * 86400;
      } else if (m[2] === 'convert') {
        if (!l.trial) return error(res, 409, 'not_a_trial', 'Only a trial can become a paid licence.');
        l.trial = false; l.trialDaysLeft = null; l.exp = null; l.onEnd = 'banner';
      } else if (m[2] === 'revoke') {
        if (typeof body?.reason !== 'string' || body.reason.length < 3) return error(res, 400, 'bad_request', 'A reason is needed.');
        l.status = 'revoked';
      } else if (l.status !== 'revoked') return error(res, 409, 'not_revoked', 'This licence is not switched off.');
      else l.status = 'active';
      return reply(res, 200, { ok: true });
    }
    if (req.method === 'POST' && (m = /^\/licences\/([^/]+)\/devices\/([^/]+)\/free$/.exec(path))) {
      const l = licences.get(decodeURIComponent(m[1]));
      if (!l) return error(res, 404, 'unknown_licence', 'No licence with that id.');
      const at = l.devices.findIndex((d) => d.id === decodeURIComponent(m[2]));
      if (at < 0) return error(res, 404, 'unknown_device', 'That PC is not on this licence.');
      if (typeof body?.reason !== 'string' || body.reason.length < 3) return error(res, 400, 'bad_request', 'A reason is needed.');
      if (l.moves >= 2) return error(res, 409, 'move_limit', 'This licence has been moved twice in the last year.');
      l.devices.splice(at, 1); l.moves += 1;
      return reply(res, 200, { ok: true });
    }
    return error(res, 404, 'not_found', 'There is nothing at this address.');
  });
  server.on('connection', (s) => { sockets.add(s); s.on('close', () => sockets.delete(s)); });
  await new Promise((done, fail) => { server.once('error', fail); server.listen(0, '127.0.0.1', done); });
  const url = `http://127.0.0.1:${server.address().port}`;
  return {
    url, options, seen, token, licences, seed, addDevice,
    made: () => [...licences.values()].filter((l) => l.request),
    close: () => new Promise((done) => { if (closed) return done(); closed = true; for (const s of sockets) s.destroy(); server.close(() => done()); }),
  };
}
