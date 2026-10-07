// The licence service: how the Studio asks the Licence Studio about a customer's licence, and the few things staff may do to it.
//
// The Licence Studio is a separate, private program on the owner's own server. It makes and signs the licences and keeps the signing key; this Studio never holds or sees that key
// (CLAUDE.md, sections 3 and 12). All this Studio holds is ONE limited staff access code, kept in its own secret store (secrets.mjs), that lets it
//   - ask which licences a customer has (their plan, whether it is a trial, what happens when it ends, the PCs in use, how many moves are used),
//   - ask for a licence when a customer's website and app are made (once; asked with an Idempotency-Key, so a double click or a retry never makes a second one),
//   - and, by a person's role in THIS Studio: free a PC, extend a trial, turn a trial into a paid licence, switch a licence off and on again.
// It is written against "contract v1" of the Licence Studio's staff calls (below). What the real Licence Studio does has NOT been tried: only a stand-in that speaks the same
// contract (tests/stand-in-licence-studio.mjs) was. docs/SETUP-STUDIO.md says so.
//
//   Authorization: Bearer <staff access code>      X-Acting-User: <the staff member's name>      errors: {"error": "<code>", "message": "<plain words>"}
//   GET  /api/staff/v1/customers/{externalCustomerId}/licences          -> { licences: [ { lid, keyMasked, plan, modules, limits, exp|null, onEnd, trial, trialDaysLeft|null, status, devices, moves } ] }
//   POST /api/staff/v1/licences   (Idempotency-Key)                      -> { lid, key }
//   POST /api/staff/v1/licences/{lid}/devices/{deviceId}/free {reason} | /extend {days} | /convert | /revoke {reason} | /restore
//
// The access code and every activation key are sent only to the Licence Studio, never followed to another address, and never appear in a file, a message or the activity record.
import { StudioError, can, need } from './workspace.mjs';
import { findSecrets } from './secretscan.mjs';
import { redact } from './ai/cli.mjs';
import { PLAN, BRAND_ID, TRIAL_DAYS } from './intake.mjs';
import { getLicenceCode, licenceCodeStatus, getLicenceKey, saveLicenceKey, heldLicenceKeys } from './secrets.mjs';

export const API_PREFIX = '/api/staff/v1';
const LID = /^[A-Za-z0-9][A-Za-z0-9_-]{2,39}$/;
const DEVICE = /^[A-Za-z0-9][A-Za-z0-9_.:-]{0,79}$/;
const PROBE = 'studio-connection-test';
const MOVES_ALLOWED = 2;
const MAX_ANSWER = 2_000_000;
const OFF = new Set(['revoked', 'suspended', 'off', 'switched_off', 'stopped']);

/**
 * Something said in plain words to a person. `code` tells the page what it may offer next: 'licence-service' (the Licence Studio could not be used right now: the page may offer to
 * build without a licence for now), 'licence-terms' (the approved setup does not say enough to ask for a licence), 'role', 'moves', ...
 */
export class LicenceError extends StudioError {
  constructor(message, code = 'licence', { status = 409, kind = 'failed' } = {}) { super(message, status, code); this.kind = kind; }
}

const isLoopback = (host) => ['127.0.0.1', 'localhost', '[::1]'].includes(host);
const clean = (text, max = 200) => String(text ?? '').replace(/[\u0000-\u001f<>]/g, ' ').replace(/\s+/g, ' ').trim().slice(0, max);
const wholeNumber = (v, lo, hi, fallback) => (Number.isFinite(v) && Math.trunc(v) >= lo && Math.trunc(v) <= hi ? Math.trunc(v) : fallback);
const plural = (n, one, many) => `${n} ${n === 1 ? one : many}`;
const periodWords = (m) => (m.windowDays === 365 ? 'this year' : `in the last ${m.windowDays} days`);

/** The address of the Licence Studio as it will be used, or '' for none; throws in plain words. Only a safe address is taken: https (http only for a program on this same PC), no name or password in it. */
export function checkAddress(value) {
  const text = String(value ?? '').trim();
  if (!text) return '';
  const say = (why) => new LicenceError(`The address of the Licence Studio ${why} Type it like https://licence.yourcompany.example, the way the owner opens the Licence Studio.`, 'address', { status: 400 });
  let u;
  try { u = new URL(text); } catch { throw say('is not an address.'); }
  if (u.protocol !== 'https:' && !(u.protocol === 'http:' && isLoopback(u.hostname))) throw say('must start with https:// (a plain http:// address is only allowed for a Licence Studio on this same PC).');
  if (u.username || u.password) throw say('must not hold a name or a password.');
  if (u.search || u.hash) throw say('must be the plain address, with nothing after the name.');
  if (text.length > 200 || !/^[A-Za-z0-9._~/-]*$/.test(u.pathname) || u.pathname.includes('..')) throw say('is too long or has strange characters in it.');
  if (findSecrets(text).length) throw say('looks like it holds a key.');
  return u.origin + u.pathname.replace(/\/+$/, '');
}

/** The staff member's name as it can travel in a header: plain text as it is; anything else (other alphabets, a percent sign) written with %-escapes, which the Licence Studio reads back. */
export function actingName(me) {
  const name = clean(me?.name ?? '', 60) || 'unknown';
  return /^[\x20-\x7e]*$/.test(name) && !name.includes('%') ? name : encodeURIComponent(name);
}

/** What the approved setup says the customer's licence is to be. A setup approved before these choices existed has none: the plan is then empty (nothing can be asked for). */
export function termsOf(intake) {
  const l = intake?.licence ?? {};
  const trial = l.trial === true;
  const chosen = l.onEnd === 'banner' || l.onEnd === 'stop' ? l.onEnd : null;
  return {
    plan: typeof l.plan === 'string' && PLAN.test(l.plan) ? l.plan : '',
    trial,
    trialDays: trial ? wholeNumber(l.trialDays, TRIAL_DAYS.min, TRIAL_DAYS.max, TRIAL_DAYS.usual) : null,
    devices: wholeNumber(l.seats, 1, 500, 1),
    onEnd: chosen ?? (trial ? 'stop' : 'banner'),
    onEndChosen: !!chosen,
    brandId: typeof l.brandId === 'string' && BRAND_ID.test(l.brandId) ? l.brandId : '',
    whiteLabel: ['none', 'theme', 'full'].includes(l.whiteLabel) ? l.whiteLabel : 'none',
  };
}

const endRule = (onEnd) => (onEnd === 'stop' ? 'the till stops selling (the owner can still see and export their own data)' : onEnd === 'banner' ? 'the shop keeps working and shows a banner' : null);

/** The terms in plain words, for a person to read before a licence is asked for. */
export function termsWords(t) {
  const parts = [t.plan ? `plan "${t.plan}"` : 'no plan chosen yet', plural(t.devices, 'PC', 'PCs'), t.trial ? `a trial of ${plural(t.trialDays, 'day', 'days')}` : 'paid, with no end date'];
  return `${parts.join(', ')}; when it ends, ${endRule(t.onEnd)}`;
}

/** The idempotency key for a customer's first licence: the same customer and the same approved release always give the same key. */
export const idempotencyKey = (customerId, release) => `ngos-studio-${customerId}-release-${release}`;

/** The body of the request for a customer's licence, from the approved setup (never from details that may have changed since). */
export function requestBody(customerId, intake) {
  const t = termsOf(intake);
  return {
    externalCustomerId: customerId, customerName: clean(intake.business?.name, 120), country: clean(intake.business?.country, 2).toUpperCase(),
    plan: t.plan, limits: { devices: t.devices }, onEnd: t.onEnd,
    ...(t.trial ? { trialDays: t.trialDays } : { exp: null }),
    ...(t.brandId ? { brandId: /^\d+$/.test(t.brandId) ? Number(t.brandId) : t.brandId } : {}),
    white: { level: t.whiteLabel },
  };
}

// ---- reading what the Licence Studio answers (it is another program: nothing it says is trusted as it comes) ---------------------------------------------------------------

/** A moment as an ISO text, from a number of seconds or milliseconds since 1970 or from a date text; or null. */
export function isoOf(v) {
  let ms = null;
  if (typeof v === 'number' && Number.isFinite(v) && v > 0) ms = v > 1e11 ? v : v * 1000;
  else if (typeof v === 'string' && v.trim() && !Number.isNaN(Date.parse(v))) ms = Date.parse(v);
  return ms !== null && ms < 8.64e15 ? new Date(ms).toISOString() : null;
}
const DATE = new Intl.DateTimeFormat('en-GB', { day: 'numeric', month: 'short', year: 'numeric', timeZone: 'UTC' });
export const dateWords = (iso) => (iso ? DATE.format(new Date(iso)) : '');

function normaliseDevice(raw) {
  if (!raw || typeof raw !== 'object') return null;
  const id = String(raw.id ?? '');
  if (!DEVICE.test(id)) return null;
  return { id, label: clean(raw.label, 80) || 'A PC', activatedAt: isoOf(raw.activatedAt), lastCheckIn: isoOf(raw.lastCheckIn), version: clean(raw.version, 30) };
}

/** One licence as the Licence Studio gave it, cleaned and limited; null when it cannot be used. */
export function normaliseLicence(raw) {
  if (!raw || typeof raw !== 'object') return null;
  const lid = String(raw.lid ?? '');
  if (!LID.test(lid)) return null;
  const limit = (v) => wholeNumber(v, 0, 1_000_000, 0);
  return {
    lid,
    keyMasked: /^[A-Za-z0-9*•.\- ]{4,60}$/.test(String(raw.keyMasked ?? '')) ? String(raw.keyMasked) : '',
    plan: clean(raw.plan, 60),
    modules: (Array.isArray(raw.modules) ? raw.modules : []).map((m) => String(m)).filter((m) => /^[a-z0-9-]{1,30}$/.test(m)).slice(0, 20),
    limits: { devices: limit(raw.limits?.devices), stores: limit(raw.limits?.stores), users: limit(raw.limits?.users) },
    exp: raw.exp === null || raw.exp === undefined ? null : isoOf(raw.exp),
    onEnd: raw.onEnd === 'stop' ? 'stop' : raw.onEnd === 'banner' ? 'banner' : null,
    trial: raw.trial === true,
    trialDaysLeft: Number.isFinite(raw.trialDaysLeft) ? Math.trunc(raw.trialDaysLeft) : null,
    status: /^[a-z_ -]{1,30}$/i.test(String(raw.status ?? '')) ? String(raw.status).toLowerCase() : 'unknown',
    devices: (Array.isArray(raw.devices) ? raw.devices : []).slice(0, 500).map(normaliseDevice).filter(Boolean),
    moves: { used: wholeNumber(raw.moves?.used, 0, 1_000_000, 0), allowed: wholeNumber(raw.moves?.allowed, 0, 1_000_000, MOVES_ALLOWED), windowDays: wholeNumber(raw.moves?.windowDays, 1, 3650, 365) },
  };
}

const STATUS_WORDS = {
  active: ['Working', 'ok'], ok: ['Working', 'ok'], trial: ['Working (trial)', 'ok'], expired: ['Ended', 'warn'], not_started: ['Not started yet', 'warn'],
  revoked: ['Switched off', 'bad'], suspended: ['Switched off', 'bad'], off: ['Switched off', 'bad'], switched_off: ['Switched off', 'bad'], stopped: ['Switched off', 'bad'],
};

/** A licence in plain words: its state, what kind it is, and what happens when it ends. */
export function describeLicence(l) {
  const [state, tone] = STATUS_WORDS[l.status.replace(/[ -]/g, '_')] ?? [`Status: ${l.status}`, ''];
  let kind = 'Paid';
  if (l.trial) {
    if (l.status === 'expired' || (l.trialDaysLeft !== null && l.trialDaysLeft < 0)) kind = 'Trial (ended)';
    else if (l.trialDaysLeft === null) kind = 'Trial';
    else if (l.trialDaysLeft === 0) kind = 'Trial: ends today';
    else kind = `Trial: ${plural(l.trialDaysLeft, 'day', 'days')} left`;
  }
  const rule = endRule(l.onEnd);
  const ends = l.exp ? `Ends on ${dateWords(l.exp)}` : 'No end date';
  const whenItEnds = !rule ? 'The Licence Studio did not say what happens when it ends.'
    : l.exp ? `${ends}. When it ends, ${rule}.` : `${ends}: it keeps working. If an end date is ever set, then when it ends ${rule}.`;
  const m = l.moves;
  return {
    state, tone, off: OFF.has(l.status.replace(/[ -]/g, '_')), kind, whenItEnds,
    pcs: `${l.devices.length} of ${l.limits.devices || 'any number of'} PCs in use`,
    moves: `Moves used: ${m.used} of ${m.allowed} ${periodWords(m)}`, movesLeft: Math.max(0, m.allowed - m.used),
  };
}

async function readLimited(res, max) {
  if (!res.body) return '';
  const reader = res.body.getReader();
  const chunks = [];
  let size = 0;
  for (;;) {
    const { done, value } = await reader.read();
    if (done) break;
    size += value.length;
    if (size > max) { await reader.cancel().catch(() => {}); throw new LicenceError('The Licence Studio sent far more than it should, so the Studio did not read it.', 'licence-service'); }
    chunks.push(value);
  }
  return Buffer.concat(chunks).toString('utf8');
}

// ---- the service -----------------------------------------------------------------------------------------------------------------------------------------------

/**
 * `ws` is the workspace; `env` is where the secret store is looked for. The rest exists so a test can use a stand-in Licence Studio on this PC: `fetchFn` and how long to wait.
 * The address of the Licence Studio is a setting of the Studio (the owner's own server has no fixed one); only a safe address is taken (checkAddress).
 */
export function createLicenceService({ ws, env = process.env, fetchFn = fetch, studioVersion = '', requestTimeoutMs = 20_000 } = {}) {
  const closing = new AbortController();
  const locks = new Map();
  const code = () => getLicenceCode(env);
  const secretsNow = () => [code(), ...heldLicenceKeys(env)].filter(Boolean);
  const settings = () => { const s = ws.settings().licenceService ?? {}; return { url: typeof s.url === 'string' ? s.url : '' }; };
  const missing = () => {
    if (!settings().url) return 'An administrator has not connected the licence service yet (Settings, "Connect the licence service": the address of the Licence Studio and its staff access code).';
    if (!code()) return 'An administrator has not added the staff access code for the Licence Studio yet (Settings, "Connect the licence service").';
    return null;
  };
  /** What anyone signed in may see: the address, whether the code is there, and whether licences can be asked for. Never the code. */
  const connection = () => ({ ...settings(), code: licenceCodeStatus(env), ready: !missing(), why: missing() });
  const perms = (me) => ({ key: can(me, 'licence.key'), manage: can(me, 'licence.manage'), admin: can(me, 'licence.admin'), connect: can(me, 'settings') });

  function saveAddress(me, input) {
    need(me, 'settings', 'connect the licence service');
    const url = checkAddress(input?.url);
    ws.saveSettings(me, { licenceService: { url } });
    return connection();
  }

  // ---- talking to the Licence Studio ------------------------------------------------------------------------------------------------------------------------

  const reached = (e) => {
    if (closing.signal.aborted) return new LicenceError('The Studio is closing.', 'closing', { kind: 'stopped' });
    if (e instanceof LicenceError) return e;
    if (e?.name === 'TimeoutError') return new LicenceError('The Licence Studio did not answer in time. Check the internet connection and that its address in Settings is right.', 'licence-service');
    const why = redact(clean(e?.cause?.code ?? e?.code ?? e?.name ?? 'error', 60), secretsNow());
    return new LicenceError(`The Studio could not reach the Licence Studio (${why}). Check the internet connection and that its address in Settings is right.`, 'licence-service');
  };

  /** One request, with the staff access code and the staff member's name in its headers only. A redirect is never followed from here (the code would go with it). */
  async function send(me, method, path, { json, idempotency, timeoutMs = requestTimeoutMs } = {}) {
    const why = missing();
    if (why) throw new LicenceError(why, 'licence-service', { kind: 'stopped' });
    try {
      return await fetchFn(`${settings().url}${API_PREFIX}${path}`, {
        method, redirect: 'manual', signal: AbortSignal.any([AbortSignal.timeout(timeoutMs), closing.signal]),
        headers: {
          authorization: `Bearer ${code()}`, 'x-acting-user': actingName(me), accept: 'application/json', 'user-agent': `NextGenOS-Setup-Studio/${studioVersion || '1'}`,
          ...(json !== undefined ? { 'content-type': 'application/json' } : {}), ...(idempotency ? { 'idempotency-key': idempotency } : {}),
        },
        body: json !== undefined ? JSON.stringify(json) : undefined,
      });
    } catch (e) { throw reached(e); }
  }

  /** What the Licence Studio said, as { status, body, raw }: body is the parsed answer, or null when it was not JSON. */
  async function read(res) {
    let raw = '';
    try { raw = await readLimited(res, MAX_ANSWER); } catch (e) { throw reached(e); }
    let body = null;
    try { body = raw ? JSON.parse(raw) : null; } catch { body = null; }
    return { status: res.status, body, raw, isJson: /json/i.test(res.headers.get('content-type') ?? '') };
  }

  /** What the Licence Studio wrote in its own words, made safe to show. */
  const said = (body) => {
    const m = redact(clean(typeof body?.message === 'string' ? body.message : '', 200), secretsNow());
    return m && !findSecrets(m).length ? m : '';
  };

  /** Why the Licence Studio said no, in plain words. */
  function refusal({ status, body }, what) {
    const code = clean(typeof body?.error === 'string' ? body.error : '', 40).toLowerCase();
    const theirs = said(body);
    const add = theirs ? ` It says: ${theirs}` : '';
    if (status === 401) return new LicenceError('The Licence Studio did not accept this Studio\'s staff access code. It may have been typed wrongly, switched off in the Licence Studio, or run out. An administrator can add a new one in Settings, "Connect the licence service".', 'licence-service');
    if (status === 403) return new LicenceError(`The Licence Studio will not let this Studio ${what}.${add} The staff access code may have been made without that right: the owner of the Licence Studio can change it.`, 'licence-refused', { status: 403 });
    if (status === 404) return new LicenceError(`The Licence Studio did not find what the Studio asked for (${what}).${add} It may have been removed there: look again.`, 'licence-gone', { status: 404 });
    if (status === 429) return new LicenceError('The Licence Studio says there have been too many requests. Wait a few minutes and try again.', 'licence-service');
    if (status === 409 && /move|limit/.test(code)) return new LicenceError(`This customer has already moved their licence to a new PC as often as a year allows (${MOVES_ALLOWED} times).${add} To allow more, the owner has to approve it in the Licence Studio.`, 'moves', { status: 409 });
    if (status === 409) return new LicenceError(`The Licence Studio could not do that (${what}) because of how things stand there.${add}`, 'licence-conflict');
    if (status === 400 || status === 422) return new LicenceError(`The Licence Studio did not accept the request (${what}).${add || ' Check what was typed in the customer\'s details.'}`, 'licence-rejected', { status: 400 });
    if (status >= 500) return new LicenceError(`The Licence Studio had a problem (${status}). It usually passes: try again in a minute.${add}`, 'licence-service');
    return new LicenceError(`The Licence Studio answered something the Studio did not expect (${what}; ${status}).${add}`, 'licence-service');
  }

  const notTheStudio = () => new LicenceError('That address answered, but not the way the Licence Studio does. Check the address in Settings, "Connect the licence service".', 'licence-service');

  /** Calls and returns the parsed answer of a success; `needBody` says the answer must be a JSON object. */
  async function ask(me, method, path, what, { json, idempotency, needBody = true, accept = [200, 201, 204] } = {}) {
    const answer = await read(await send(me, method, path, { json, idempotency }));
    if (!accept.includes(answer.status)) throw refusal(answer, what);
    if (needBody && (!answer.body || typeof answer.body !== 'object' || Array.isArray(answer.body))) throw notTheStudio();
    return answer.body ?? {};
  }

  /** The customer's licences, as the Licence Studio has them now. A customer the Licence Studio does not know yet has none. */
  async function fetchList(me, id) {
    const answer = await read(await send(me, 'GET', `/customers/${encodeURIComponent(id)}/licences`));
    if (answer.status === 404 && answer.isJson && /customer/i.test(String(answer.body?.error ?? ''))) return [];
    if (answer.status !== 200) throw refusal(answer, 'look at this customer\'s licences');
    if (!answer.body || !Array.isArray(answer.body.licences)) throw notTheStudio();
    return answer.body.licences.slice(0, 50).map(normaliseLicence).filter(Boolean);
  }

  // ---- "Test the connection" --------------------------------------------------------------------------------------------------------------------------------

  /** Asks the Licence Studio one harmless question (about a customer that does not exist) and says in plain words what is right and what is wrong. */
  async function testConnection(me) {
    const checks = [];
    const add = (id, ok, words) => checks.push({ id, ok, words });
    const s = settings();
    if (!s.url) add('address', false, 'Type the address of the Licence Studio and save it first.'); else add('address', true, `The address is ${s.url}.`);
    if (!code()) add('code-set', false, 'The staff access code has not been added yet.');
    if (!s.url || !code()) return { ok: false, checks };
    let answer;
    try { answer = await read(await send(me, 'GET', `/customers/${PROBE}/licences`)); } catch (e) {
      add('answers', false, e instanceof LicenceError ? e.message : 'The check could not be made.');
      return { ok: false, checks };
    }
    const theirError = answer.isJson && answer.body && typeof answer.body.error === 'string' ? String(answer.body.error) : '';
    if (answer.status === 200 && Array.isArray(answer.body?.licences)) { add('answers', true, 'The Licence Studio answered.'); add('code', true, 'The Licence Studio accepted the staff access code and can look up a customer\'s licences.'); }
    else if (answer.status === 200) add('answers', false, 'That address answered, but not the way the Licence Studio does. Check the address.');
    else if (answer.status === 401) { add('answers', true, 'The Licence Studio answered.'); add('code', false, 'The Licence Studio did not accept the staff access code. It may have been typed wrongly, switched off, or run out: make a new one in the Licence Studio and add it here.'); }
    else if (answer.status === 403) { add('answers', true, 'The Licence Studio answered.'); add('code', false, `The Licence Studio knows the staff access code but will not let it look at licences.${said(answer.body) ? ` It says: ${said(answer.body)}` : ''} The owner of the Licence Studio can change what the code is allowed to do.`); }
    else if (answer.status === 404 && /customer/i.test(theirError)) { add('answers', true, 'The Licence Studio answered.'); add('code', true, 'The Licence Studio accepted the staff access code (it does not know the test customer, as expected).'); }
    else if (answer.status === 404 && theirError) add('answers', false, 'The address answered, but the Licence Studio there does not know the staff calls this Studio uses. It may be an older version of the Licence Studio, or the address may belong to something else.');
    else if (answer.isJson && theirError) add('answers', false, refusal(answer, 'look at a customer\'s licences').message);
    else add('answers', false, 'That address answered, but not the way the Licence Studio does. Check the address.');
    add('rights', null, 'Whether the code may also make licences, free a PC, extend a trial and switch a licence off is decided by the Licence Studio, and is only known the first time each is used.');
    return { ok: checks.every((c) => c.ok !== false), checks };
  }

  // ---- the customer's licences, for the page ---------------------------------------------------------------------------------------------------------------

  const latestRelease = (id) => ws.releaseNumbers(id).at(-1) ?? null;

  /** What the approved setup says the licence is to be, in plain words, or why nothing can be asked for. */
  function expected(id) {
    const release = latestRelease(id);
    if (!release) return null;
    let parts;
    try { parts = ws.releaseParts(id, release); } catch (e) { return { release, ok: false, problem: e.message }; }
    const t = termsOf(parts.intake);
    return { release, ok: !!t.plan, problem: t.plan ? '' : 'No plan is chosen in the approved setup. Choose it in the details (Extras and licence), prepare the setup again and have it approved again. Until then no licence can be asked for.', terms: t, words: termsWords(t) };
  }

  const dress = (id, l) => ({ ...l, keyHeld: !!getLicenceKey(id, l.lid, env), words: describeLicence(l) });

  /** Everything the Licences section needs. A problem with the Licence Studio is a plain sentence on the page, not an error: the page can still be shown. */
  async function view(me, id) {
    ws.get(id);   // a customer that does not exist is a plain 404
    const out = { service: connection(), can: perms(me), expected: expected(id), licences: [], problem: '' };
    if (!out.service.ready) return out;
    try { out.licences = (await fetchList(me, id)).map((l) => dress(id, l)); } catch (e) { if (!(e instanceof LicenceError)) throw e; out.problem = e.message; }
    return out;
  }

  /** One of this customer's licences, read fresh from the Licence Studio (a licence that is not this customer's cannot be reached through this customer's page). */
  async function mine(me, id, lid) {
    ws.get(id);
    if (!LID.test(String(lid))) throw new LicenceError('That is not a licence this Studio knows.', 'licence-gone', { status: 404 });
    const lic = (await fetchList(me, id)).find((l) => l.lid === lid);
    if (!lic) throw new LicenceError('That licence is not one of this customer\'s (any more). Look at the page again.', 'licence-gone', { status: 404 });
    return lic;
  }

  /** A reason a person typed, checked: a few words, no secret. */
  function reasonOf(text, what) {
    const why = clean(text, 200);
    if (why.length < 5) throw new LicenceError(`Please say why you ${what}, in a few words. It is written in the activity record.`, 'reason', { status: 400 });
    if (findSecrets(why).length || secretsNow().some((s) => s.length >= 6 && why.includes(s))) throw new LicenceError('The reason looks like it holds a password or a key. Write it in words, without one.', 'reason', { status: 400 });
    return why;
  }

  /** The activation key, for the hand-over: only when this PC holds it (the Licence Studio shows it once, when it makes the licence). */
  function showKey(me, id, lid) {
    need(me, 'licence.key', 'show an activation key');
    ws.get(id);
    const key = LID.test(String(lid)) ? getLicenceKey(id, lid, env) : null;
    if (!key) throw new LicenceError('This PC does not hold the whole key of this licence. The Licence Studio shows a key only once, when the licence is made. Look for it in the Licence Studio (an administrator there can find it).', 'licence-key-missing', { status: 404 });
    ws.log(me, 'licence.key.shown', id, `licence ${lid}`);   // that it was shown, and to whom: never the key
    return { key };
  }

  async function freeDevice(me, id, lid, deviceId, reason) {
    need(me, 'licence.manage', 'free a PC');
    const why = reasonOf(reason, 'free this PC');
    if (!DEVICE.test(String(deviceId))) throw new LicenceError('That is not a PC this Studio knows.', 'licence-gone', { status: 404 });
    const lic = await mine(me, id, lid);
    const dev = lic.devices.find((d) => d.id === deviceId);
    if (!dev) throw new LicenceError('That PC is not on this licence (any more). Look at the page again.', 'licence-gone', { status: 404 });
    if (lic.moves.used >= lic.moves.allowed && !can(me, 'licence.admin')) {
      throw new LicenceError(`This customer has already moved their licence ${lic.moves.used} of ${lic.moves.allowed} times ${periodWords(lic.moves)}, which is as often as the licence allows. Moving more needs an administrator.`, 'moves', { status: 403 });
    }
    await ask(me, 'POST', `/licences/${encodeURIComponent(lid)}/devices/${encodeURIComponent(deviceId)}/free`, 'free this PC', { json: { reason: why }, needBody: false });
    ws.log(me, 'licence.device.freed', id, `${lid}: ${dev.label}. Reason: ${why}`);
    return view(me, id);
  }

  async function extend(me, id, lid, days) {
    need(me, 'licence.manage', 'extend a trial');
    const n = Number(days);
    if (!Number.isInteger(n) || n < 1 || n > TRIAL_DAYS.max) throw new LicenceError(`Type the number of days to add, a whole number from 1 to ${TRIAL_DAYS.max}.`, 'days', { status: 400 });
    const lic = await mine(me, id, lid);
    if (!lic.trial) throw new LicenceError('Only a trial can be extended. This licence is not a trial.', 'licence-kind', { status: 409 });
    await ask(me, 'POST', `/licences/${encodeURIComponent(lid)}/extend`, 'extend this trial', { json: { days: n }, needBody: false });
    ws.log(me, 'licence.extended', id, `${lid}: the trial was extended by ${plural(n, 'day', 'days')}`);
    return view(me, id);
  }

  async function convert(me, id, lid) {
    need(me, 'licence.manage', 'turn a trial into a paid licence');
    const lic = await mine(me, id, lid);
    if (!lic.trial) throw new LicenceError('This licence is not a trial. There is nothing to turn into a paid licence.', 'licence-kind', { status: 409 });
    await ask(me, 'POST', `/licences/${encodeURIComponent(lid)}/convert`, 'turn this trial into a paid licence', { json: {}, needBody: false });
    ws.log(me, 'licence.converted', id, `${lid}: the trial became a paid licence`);
    return view(me, id);
  }

  async function revoke(me, id, lid, reason) {
    need(me, 'licence.admin', 'switch a licence off');
    const why = reasonOf(reason, 'switch this licence off');
    const lic = await mine(me, id, lid);
    if (describeLicence(lic).off) throw new LicenceError('This licence is already switched off.', 'licence-kind', { status: 409 });
    await ask(me, 'POST', `/licences/${encodeURIComponent(lid)}/revoke`, 'switch this licence off', { json: { reason: why }, needBody: false });
    ws.log(me, 'licence.revoked', id, `${lid}: switched off. Reason: ${why}`);
    return view(me, id);
  }

  async function restore(me, id, lid) {
    need(me, 'licence.admin', 'switch a licence on again');
    const lic = await mine(me, id, lid);
    if (!describeLicence(lic).off) throw new LicenceError('This licence is not switched off.', 'licence-kind', { status: 409 });
    await ask(me, 'POST', `/licences/${encodeURIComponent(lid)}/restore`, 'switch this licence on again', { json: {}, needBody: false });
    ws.log(me, 'licence.restored', id, `${lid}: switched on again`);
    return view(me, id);
  }

  // ---- asking for the customer's licence when their outputs are made ------------------------------------------------------------------------------------------

  /** One at a time for a customer, so a double click waits for the first press and then finds the licence already there. */
  async function oneAtATime(id, work) {
    const run = (locks.get(id) ?? Promise.resolve()).catch(() => {}).then(work);
    locks.set(id, run);
    try { return await run; } finally { if (locks.get(id) === run) locks.delete(id); }
  }

  /**
   * Before a customer's website and app are made: the customer's licence, if they have none yet and the licence service is connected. Returns what happened, to be shown and kept
   * with the build: { outcome: 'made' | 'existing' | 'not-connected' | 'skipped', ... } (never the key). A problem with the Licence Studio throws a plain LicenceError and nothing is
   * built (the person may choose to build without a licence for now: `skip`).
   */
  async function ensureForBuild(me, id, { skip = false } = {}) {
    need(me, 'build', 'make a customer\'s outputs');
    if (skip) return { outcome: 'skipped' };
    if (missing()) return { outcome: 'not-connected' };
    return oneAtATime(id, async () => {
      const release = latestRelease(id);
      if (!release) throw new LicenceError('Approve a setup first. The licence is asked for from an approved setup.', 'licence-terms', { status: 409 });
      const existing = await fetchList(me, id);
      if (existing.length) return { outcome: 'existing', lid: existing[0].lid, plan: existing[0].plan, trial: existing[0].trial };
      const intake = ws.releaseParts(id, release).intake;
      const terms = termsOf(intake);
      if (!terms.plan) throw new LicenceError('No plan is chosen in the approved setup, so no licence can be asked for. Choose the plan in the details (Extras and licence), prepare the setup again and have it approved again. Or build now and make the licence later.', 'licence-terms', { status: 409 });
      const made = await ask(me, 'POST', '/licences', 'make this customer\'s licence', { json: requestBody(id, intake), idempotency: idempotencyKey(id, release) });
      if (!LID.test(String(made.lid ?? ''))) throw new LicenceError('The Licence Studio answered, but the Studio could not read the licence it made. Look in the Licence Studio before trying again: a licence may have been made.', 'licence-service');
      let keyKept = false;
      try { saveLicenceKey(id, made.lid, made.key, env); keyKept = true; } catch { /* the licence is made; the key can be looked up in the Licence Studio */ }
      ws.log(me, 'licence.requested', id, `${made.lid}: ${termsWords(terms)}; from release ${release}${keyKept ? '' : '; the Studio could not keep the key'}`);
      return { outcome: 'made', lid: made.lid, plan: terms.plan, trial: terms.trial, devices: terms.devices, keyKept };
    });
  }

  return { connection, saveAddress, testConnection, view, showKey, freeDevice, extend, convert, revoke, restore, ensureForBuild, expected, close: () => closing.abort() };
}
