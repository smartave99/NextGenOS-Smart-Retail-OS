'use strict';
// What happens at a licence's end (banner or stop), trials, extending, turning a trial into a paid licence,
// the "2 moves in 365 days" rule, the history of PCs, and the defaults the Studio writes (spec sections 8, 10.1 and 13).

const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { DatabaseSync } = require('node:sqlite');
const C = require('../lib/crypto');
const { open } = require('../lib/db');
const { Studio, ApiError, DAY } = require('../lib/studio');
const { statusOf } = require('../views/layout');
const { makeStudio, ADMIN, SALES, fp } = require('./helpers');

const customerOf = (ctx, name = 'Green Mart') => ctx.studio.createCustomer({ name, country: 'IN', contactName: 'Asha' }, ADMIN, 'ip');
const issue = (ctx, over = {}, actor = ADMIN) => ctx.studio.createLicence({ customerId: customerOf(ctx, `Shop ${Math.random()}`).id, planCode: 'business', ...over }, actor, 'ip');
const claimsOf = (ctx, lic) => C.verifyToken(ctx.studio.licenceToken(lic), ctx.trusted, 'lic');
const code = (fn) => { try { fn(); } catch (e) { return e instanceof ApiError ? e.code : `other: ${e.message}`; } return 'no error'; };

// ---------- the defaults the Studio writes ----------

test('a paid licence has no end date and keeps working with a banner; check-in is monthly with 60 days of warnings', () => {
  const ctx = makeStudio();
  const lic = issue(ctx);
  assert.equal(lic.exp, null);
  assert.equal(lic.trial, false);
  assert.equal(lic.on_end, 'banner');
  assert.deepEqual({ online: lic.act.online, checkInDays: lic.act.checkInDays, graceDays: lic.act.graceDays, offlineDays: lic.act.offlineDays }, { online: true, checkInDays: 30, graceDays: 60, offlineDays: 365 });
  const claims = claimsOf(ctx, lic);
  assert.equal(claims.onEnd, 'banner');
  assert.equal(claims.exp, null);
  assert.equal(claims.trial, false);
  assert.equal(claims.act.checkInDays, 30);
  assert.equal(claims.act.graceDays, 60);
});

test('a paid licence with an end date defaults to banner; staff may choose stop', () => {
  const ctx = makeStudio();
  const yearly = issue(ctx, { term: 'y1' });
  assert.equal(yearly.exp, ctx.state.t + 365 * DAY);
  assert.equal(claimsOf(ctx, yearly).onEnd, 'banner');
  const strict = issue(ctx, { term: 'y1', onEnd: 'stop' });
  assert.equal(claimsOf(ctx, strict).onEnd, 'stop');
  assert.equal(code(() => issue(ctx, { term: 'y1', onEnd: 'carry-on' })), 'bad_request');
});

test('a trial is 14 days by default, any length staff choose, and always stops', () => {
  const ctx = makeStudio();
  const trial = issue(ctx, { term: 'trial' });
  assert.equal(trial.trial, true);
  assert.equal(trial.exp, ctx.state.t + 14 * DAY);
  const claims = claimsOf(ctx, trial);
  assert.equal(claims.trial, true);
  assert.equal(claims.onEnd, 'stop');

  assert.equal(issue(ctx, { term: 'trial', trialDays: 30 }).exp, ctx.state.t + 30 * DAY);
  assert.equal(issue(ctx, { trialDays: '7' }).exp, ctx.state.t + 7 * DAY, 'trial days alone make a trial');
  assert.equal(code(() => issue(ctx, { term: 'trial', trialDays: 0 })), 'bad_request');
  assert.equal(code(() => issue(ctx, { term: 'trial', trialDays: 366 })), 'bad_request');
  assert.equal(code(() => issue(ctx, { term: 'trial', trialDays: 'many' })), 'bad_request');
  assert.equal(code(() => issue(ctx, { term: 'y1', trialDays: 5 })), 'bad_request', 'trial days only go with a trial');
  assert.throws(() => issue(ctx, { term: 'trial', onEnd: 'banner' }), (e) => e.code === 'bad_request' && /always stops/.test(e.message));
  assert.equal(issue(ctx, { term: 'trial', onEnd: 'stop' }).on_end, 'stop');
});

test('what happens at the end is written only in the signed licence, and a trial can never be signed as banner', () => {
  const ctx = makeStudio();
  const trial = issue(ctx, { term: 'trial' });
  // Even if the stored value were wrong, a trial is signed as "stop".
  ctx.db.prepare("UPDATE licences SET on_end = 'banner' WHERE lid = ?").run(trial.lid);
  assert.equal(claimsOf(ctx, ctx.studio.getLicence(trial.lid)).onEnd, 'stop');
  // Changing the signed text breaks the signature.
  const [p, body, sig] = ctx.studio.licenceToken(issue(ctx, { term: 'y1', onEnd: 'stop' })).split('.');
  const forged = JSON.parse(Buffer.from(body, 'base64url').toString());
  forged.onEnd = 'banner';
  assert.throws(() => C.verifyToken([p, Buffer.from(JSON.stringify(forged)).toString('base64url'), sig].join('.'), ctx.trusted, 'lic'), /Signature/);
});

// ---------- after the end date ----------

test('a banner licence is still activated and checked in after its end date, and its activation is not cut at the end date', () => {
  const ctx = makeStudio();
  const lic = issue(ctx, { term: 'y1', onEnd: 'banner' });
  const f = fp('pc-a');
  const first = ctx.studio.activate({ key: lic.licence_key, fp: f, host: 'A' }, 'ip');
  ctx.state.t = lic.exp + 5 * DAY;
  const again = ctx.studio.checkin({ lid: lic.lid, act: first.act, fp: f }, 'ip');
  const act = C.verifyToken(again.act, ctx.trusted, 'act');
  assert.equal(act.next, ctx.state.t + 30 * DAY, 'the next check-in is a month away, not cut at the end date');
  assert.equal(act.until, ctx.state.t + 90 * DAY);
  assert.ok(ctx.studio.activate({ key: lic.licence_key, fp: fp('pc-b'), host: 'B' }, 'ip').act, 'a second PC can still be activated');
  assert.equal(C.verifyToken(again.lic, ctx.trusted, 'lic').onEnd, 'banner');
});

test('a licence that stops is refused after its end date and its activation is cut at the end date', () => {
  const ctx = makeStudio();
  const lic = issue(ctx, { term: 'y1', onEnd: 'stop' });
  const f = fp('pc-a');
  const first = ctx.studio.activate({ key: lic.licence_key, fp: f }, 'ip');
  ctx.state.t = lic.exp - 10 * DAY;
  const near = C.verifyToken(ctx.studio.checkin({ lid: lic.lid, act: first.act, fp: f }, 'ip').act, ctx.trusted, 'act');
  assert.equal(near.next, lic.exp, 'a month would pass the end date, so the check-in is cut at the end date');
  assert.equal(near.until, lic.exp);
  ctx.state.t = lic.exp + DAY;
  assert.equal(code(() => ctx.studio.checkin({ lid: lic.lid, act: first.act, fp: f }, 'ip')), 'expired');
  assert.equal(code(() => ctx.studio.activate({ key: lic.licence_key, fp: fp('pc-b') }, 'ip')), 'expired');
});

test('a switched-off licence is refused whatever it says about its end', () => {
  const ctx = makeStudio();
  const lic = issue(ctx, { term: 'y1', onEnd: 'banner' });
  ctx.state.t = lic.exp + DAY;
  ctx.studio.setStatus(lic.lid, 'suspended', 'unpaid', ADMIN, 'ip');
  assert.equal(code(() => ctx.studio.activate({ key: lic.licence_key, fp: fp('x') }, 'ip')), 'suspended');
  assert.deepEqual(C.verifyToken(ctx.studio.crlToken(), ctx.trusted, 'crl').revoked, [lic.lid]);
});

test('the words staff see for an ended licence: a paid one still works, a trial and a "stop" licence do not', () => {
  const ctx = makeStudio();
  const paid = issue(ctx, { term: 'y1', onEnd: 'banner' });
  const strict = issue(ctx, { term: 'y1', onEnd: 'stop' });
  const trial = issue(ctx, { term: 'trial' });
  ctx.state.t += 400 * DAY;
  assert.equal(statusOf(ctx.studio.getLicence(paid.lid), ctx.state.t).label, 'Ended, still working');
  assert.equal(statusOf(ctx.studio.getLicence(strict.lid), ctx.state.t).label, 'Ended');
  assert.equal(statusOf(ctx.studio.getLicence(trial.lid), ctx.state.t).label, 'Trial ended');
});

// ---------- extend and convert ----------

test('extend adds days to the end date, or to today when it has ended; never to a licence with no end date', () => {
  const ctx = makeStudio();
  const trial = issue(ctx, { term: 'trial' }, SALES);
  const more = ctx.studio.extendDays(trial.lid, 7, SALES, 'ip');
  assert.equal(more.exp, trial.exp + 7 * DAY);
  assert.equal(more.rev, trial.rev + 1, 'PCs pick the change up at their next check-in');
  assert.equal(claimsOf(ctx, more).exp, more.exp);

  ctx.state.t = more.exp + 3 * DAY; // the trial has ended
  const again = ctx.studio.extendDays(trial.lid, 10, SALES, 'ip');
  assert.equal(again.exp, ctx.state.t + 10 * DAY, 'an ended trial runs again from today');

  const perpetual = issue(ctx);
  assert.throws(() => ctx.studio.extendDays(perpetual.lid, 7, SALES, 'ip'), (e) => e.code === 'conflict' && /no end date/.test(e.message));
  for (const bad of [0, -3, 3651, 'abc', 1.5, null, undefined]) assert.equal(code(() => ctx.studio.extendDays(trial.lid, bad, SALES, 'ip')), 'bad_request', String(bad));
  assert.equal(code(() => ctx.studio.extendDays('L-NOPE', 5, SALES, 'ip')), 'not_found');
  ctx.studio.setStatus(trial.lid, 'revoked', 'fraud', ADMIN, 'ip');
  assert.equal(code(() => ctx.studio.extendDays(trial.lid, 5, SALES, 'ip')), 'conflict');
  assert.ok(ctx.db.prepare("SELECT 1 FROM audit WHERE action = 'licence.extend'").get(), 'it is written to the history');
});

test('an ended trial that is extended works again: the Studio accepts a check-in once more', () => {
  const ctx = makeStudio();
  const trial = issue(ctx, { term: 'trial' });
  const f = fp('pc-a');
  const first = ctx.studio.activate({ key: trial.licence_key, fp: f }, 'ip');
  ctx.state.t = trial.exp + DAY;
  assert.equal(code(() => ctx.studio.checkin({ lid: trial.lid, act: first.act, fp: f }, 'ip')), 'expired');
  ctx.studio.extendDays(trial.lid, 7, SALES, 'ip');
  const back = ctx.studio.checkin({ lid: trial.lid, act: first.act, fp: f }, 'ip');
  assert.ok(C.verifyToken(back.lic, ctx.trusted, 'lic').exp > ctx.state.t);
});

test('a trial can be turned into a paid licence: no end date, banner, no longer a trial', () => {
  const ctx = makeStudio();
  const trial = issue(ctx, { term: 'trial' }, SALES);
  const paid = ctx.studio.convertTrial(trial.lid, {}, SALES, 'ip');
  assert.equal(paid.trial, false);
  assert.equal(paid.exp, null);
  assert.equal(paid.on_end, 'banner');
  assert.equal(paid.rev, trial.rev + 1);
  const claims = claimsOf(ctx, paid);
  assert.deepEqual([claims.trial, claims.exp, claims.onEnd], [false, null, 'banner']);
  assert.equal(code(() => ctx.studio.convertTrial(trial.lid, {}, SALES, 'ip')), 'conflict', 'it is not a trial any more');
  assert.equal(code(() => ctx.studio.convertTrial(issue(ctx, { term: 'y1' }).lid, {}, SALES, 'ip')), 'conflict');

  const other = issue(ctx, { term: 'trial' });
  const yearly = ctx.studio.convertTrial(other.lid, { term: 'y1' }, SALES, 'ip');
  assert.equal(yearly.exp, ctx.state.t + 365 * DAY);
  assert.equal(yearly.on_end, 'banner');
  assert.equal(code(() => ctx.studio.convertTrial(issue(ctx, { term: 'trial' }).lid, { term: 'trial' }, SALES, 'ip')), 'bad_request');
});

test('renewing a trial with a paid term makes it paid; a trial cannot be set to banner', () => {
  const ctx = makeStudio();
  const trial = issue(ctx, { term: 'trial' });
  assert.equal(code(() => ctx.studio.updateLicence(trial.lid, { onEnd: 'banner' }, ADMIN, 'ip')), 'bad_request');
  const renewed = ctx.studio.updateLicence(trial.lid, { extendTerm: 'y1' }, SALES, 'ip');
  assert.deepEqual([renewed.trial, renewed.on_end], [false, 'banner']);
  const changed = ctx.studio.updateLicence(trial.lid, { onEnd: 'stop' }, SALES, 'ip');
  assert.equal(changed.on_end, 'stop');
});

// ---------- moving a licence to a new PC ----------

test('a customer can free their own PC 2 times in any 365 days; the 3rd is refused and the PC keeps its seat', () => {
  const ctx = makeStudio();
  const lic = issue(ctx, { devices: 1 });
  const move = (name, next) => {
    const a = ctx.studio.activate({ key: lic.licence_key, fp: fp(name), host: name }, 'ip');
    ctx.studio.deactivate({ lid: lic.lid, act: a.act, fp: fp(name) }, 'ip');
    return a;
  };
  move('pc-1');
  assert.deepEqual(ctx.studio.moves(lic.lid), { used: 1, allowed: 2, windowDays: 365 });
  ctx.state.t += 10 * DAY;
  move('pc-2');
  assert.equal(ctx.studio.moves(lic.lid).used, 2);

  ctx.state.t += 10 * DAY;
  const third = ctx.studio.activate({ key: lic.licence_key, fp: fp('pc-3'), host: 'pc-3' }, 'ip');
  assert.throws(() => ctx.studio.deactivate({ lid: lic.lid, act: third.act, fp: fp('pc-3') }, 'ip'),
    (e) => e instanceof ApiError && e.status === 409 && e.code === 'move_limit_reached' && /2 times in the last 12 months/.test(e.message) && /contact your supplier/.test(e.message));
  assert.equal(ctx.studio.listActivations(lic.lid).filter((a) => a.active).length, 1, 'the seat is still taken');
  assert.ok(ctx.studio.checkin({ lid: lic.lid, act: third.act, fp: fp('pc-3') }, 'ip').act, 'and that PC still works');
  assert.equal(ctx.studio.moves(lic.lid).used, 2, 'a refused call is not a move');
});

test('the move window rolls: the oldest move stops counting 365 days after it', () => {
  const ctx = makeStudio();
  const lic = issue(ctx, { devices: 1 });
  const t0 = ctx.state.t;
  const move = (name) => {
    const a = ctx.studio.activate({ key: lic.licence_key, fp: fp(name), host: name }, 'ip');
    ctx.studio.deactivate({ lid: lic.lid, act: a.act, fp: fp(name) }, 'ip');
  };
  move('a');                          // day 0
  ctx.state.t = t0 + 100 * DAY; move('b'); // day 100
  ctx.state.t = t0 + 364 * DAY;
  const c = ctx.studio.activate({ key: lic.licence_key, fp: fp('c') }, 'ip');
  assert.equal(code(() => ctx.studio.deactivate({ lid: lic.lid, act: c.act, fp: fp('c') }, 'ip')), 'move_limit_reached', 'day 364: both moves still count');
  ctx.state.t = t0 + 365 * DAY;
  assert.equal(code(() => ctx.studio.deactivate({ lid: lic.lid, act: c.act, fp: fp('c') }, 'ip')), 'no error', 'day 365: the first move has left the window');
  assert.equal(ctx.studio.moves(lic.lid).used, 2);
  const d = ctx.studio.activate({ key: lic.licence_key, fp: fp('d') }, 'ip');
  assert.equal(code(() => ctx.studio.deactivate({ lid: lic.lid, act: d.act, fp: fp('d') }, 'ip')), 'move_limit_reached');
  ctx.state.t = t0 + 466 * DAY;       // day 100 has left too
  assert.equal(code(() => ctx.studio.deactivate({ lid: lic.lid, act: d.act, fp: fp('d') }, 'ip')), 'no error');
});

test('each licence has its own count; a call for a PC that is not an active seat is not a move', () => {
  const ctx = makeStudio();
  const a = issue(ctx, { devices: 1 });
  const b = issue(ctx, { devices: 1 });
  const f = fp('p');
  const act = ctx.studio.activate({ key: a.licence_key, fp: f }, 'ip').act;
  for (let i = 0; i < 4; i += 1) assert.deepEqual(ctx.studio.deactivate({ lid: a.lid, act, fp: f }, 'ip'), { ok: true }); // the first frees it, the others find nothing to free
  assert.equal(ctx.studio.moves(a.lid).used, 1);
  assert.equal(ctx.studio.moves(b.lid).used, 0);
});

test('staff freeing a PC is never limited and not counted, but needs a reason and is written down with who did it', () => {
  const ctx = makeStudio();
  const lic = issue(ctx, { devices: 1 });
  for (let i = 0; i < 5; i += 1) {
    ctx.studio.activate({ key: lic.licence_key, fp: fp(`pc-${i}`), host: `PC-${i}` }, 'ip');
    const seat = ctx.studio.listActivations(lic.lid).find((x) => x.active);
    assert.throws(() => ctx.studio.freeDevice(seat.id, SALES, 'ip', '  '), (e) => e.code === 'bad_request' && /why/.test(e.message));
    assert.equal(ctx.studio.getActivation(seat.id).active, 1, 'no reason, nothing freed');
    ctx.studio.freeDevice(seat.id, { ...SALES, name: 'Sam' }, 'ip', `reason ${i}`);
  }
  assert.equal(ctx.studio.moves(lic.lid).used, 0, 'staff frees are not the customer\'s moves');
  const frees = ctx.studio.history(lic.lid).filter((e) => e.kind === 'staff_free');
  assert.equal(frees.length, 5);
  assert.equal(frees[0].actor, 'Sam (sales@example.com)');
  assert.equal(frees[0].reason, 'reason 4');
  assert.equal(frees[0].host, 'PC-4');
  assert.ok(ctx.db.prepare("SELECT 1 FROM audit WHERE action = 'device.free' AND detail LIKE '%reason 4%'").get());
});

test('freeing a PC checks it belongs to the licence, and freeing it twice changes nothing', () => {
  const ctx = makeStudio();
  const a = issue(ctx, { devices: 2 });
  const b = issue(ctx, { devices: 2 });
  ctx.studio.activate({ key: a.licence_key, fp: fp('x'), host: 'X' }, 'ip');
  const seat = ctx.studio.listActivations(a.lid)[0];
  assert.equal(code(() => ctx.studio.freeDevice(seat.id, ADMIN, 'ip', 'why', b.lid)), 'not_found');
  assert.equal(ctx.studio.getActivation(seat.id).active, 1);
  ctx.studio.freeDevice(seat.id, ADMIN, 'ip', 'why', a.lid);
  ctx.studio.freeDevice(seat.id, ADMIN, 'ip', 'why again', a.lid);
  assert.equal(ctx.studio.history(a.lid).filter((e) => e.kind === 'staff_free').length, 1);
});

test('the history of a licence lists activations, moves by the customer and frees by staff, newest first', () => {
  const ctx = makeStudio();
  const lic = issue(ctx, { devices: 2 });
  const t0 = ctx.state.t;
  const a = ctx.studio.activate({ key: lic.licence_key, fp: fp('a'), host: 'A' }, 'ip');
  ctx.state.t = t0 + DAY;
  ctx.studio.deactivate({ lid: lic.lid, act: a.act, fp: fp('a') }, 'ip');
  ctx.state.t = t0 + 2 * DAY;
  ctx.studio.activate({ key: lic.licence_key, fp: fp('b'), host: 'B' }, 'ip');
  ctx.state.t = t0 + 3 * DAY;
  ctx.studio.freeDevice(ctx.studio.listActivations(lic.lid).find((x) => x.active).id, ADMIN, 'ip', 'sold the PC');
  const kinds = ctx.studio.history(lic.lid).map((e) => `${e.kind}:${e.host}`);
  assert.deepEqual(kinds, ['staff_free:B', 'activated:B', 'client_deactivate:A', 'activated:A']);
  // A PC that activates again (same hardware) is not a new seat and not a new event.
  ctx.studio.activate({ key: lic.licence_key, fp: fp('c'), host: 'C' }, 'ip');
  ctx.studio.activate({ key: lic.licence_key, fp: fp('c'), host: 'C' }, 'ip');
  assert.equal(ctx.studio.history(lic.lid).filter((e) => e.host === 'C').length, 1);
});

// ---------- settings and old databases ----------

test('a Studio that still has the old defaults (7 and 14 days) moves to 30 and 60 once; a value staff chose stays', () => {
  const ctx = makeStudio();
  ctx.db.prepare("DELETE FROM settings WHERE key = 'defaults_v2'").run();
  ctx.studio.setSetting('check_in_days', '7');
  ctx.studio.setSetting('grace_days', '21'); // chosen by staff: not the old default
  ctx.studio.seedDefaults();
  assert.equal(ctx.studio.setting('check_in_days'), '30');
  assert.equal(ctx.studio.setting('grace_days'), '21');
  // Done once: staff who go back to 7 later are not changed again.
  ctx.studio.setSetting('check_in_days', '7');
  ctx.studio.seedDefaults();
  assert.equal(ctx.studio.setting('check_in_days'), '7');
  assert.equal(issue(ctx).act.checkInDays, 7, 'the setting is what a new licence gets');
});

test('a database made before this change gets the new columns, and its old licences keep stopping at their end', () => {
  const dir = fs.mkdtempSync(path.join(os.tmpdir(), 'studio-old-'));
  const old = new DatabaseSync(path.join(dir, 'studio.db'));
  old.exec(`CREATE TABLE customers (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, country TEXT NOT NULL DEFAULT '', contact_name TEXT NOT NULL DEFAULT '', email TEXT NOT NULL DEFAULT '', phone TEXT NOT NULL DEFAULT '', notes TEXT NOT NULL DEFAULT '', created_by INTEGER, created_at INTEGER NOT NULL);
    CREATE TABLE licences (lid TEXT PRIMARY KEY, licence_key TEXT NOT NULL UNIQUE, customer_id INTEGER NOT NULL, reseller_id INTEGER, plan_code TEXT NOT NULL, modules TEXT NOT NULL, limits TEXT NOT NULL, bind TEXT NOT NULL, brand_id INTEGER, act TEXT NOT NULL, trial INTEGER NOT NULL DEFAULT 0, white_level TEXT NOT NULL DEFAULT 'theme', nbf INTEGER NOT NULL, exp INTEGER, status TEXT NOT NULL DEFAULT 'active', status_reason TEXT NOT NULL DEFAULT '', rev INTEGER NOT NULL DEFAULT 1, notes TEXT NOT NULL DEFAULT '', created_by INTEGER, created_at INTEGER NOT NULL, updated_at INTEGER NOT NULL);
    INSERT INTO customers(name, created_at) VALUES ('Old Shop', 1);
    INSERT INTO licences(lid, licence_key, customer_id, plan_code, modules, limits, bind, act, nbf, exp, created_at, updated_at) VALUES ('L-OLD00001', 'NGOS-AAAAA-AAAAA-AAAAA-AAAAA', 1, 'business', '["pos"]', '{"devices":1,"stores":1,"users":1}', '{"mode":"device","domains":[]}', '{"online":true,"checkInDays":7,"graceDays":14,"offlineDays":365}', 1, 99, 1, 1);`);
  old.close();
  const db = open(dir);
  const cols = (t) => db.prepare(`PRAGMA table_info(${t})`).all().map((c) => c.name);
  assert.ok(cols('licences').includes('on_end'));
  assert.ok(cols('customers').includes('external_id'));
  const studio = new Studio({ db, signer: null });
  const lic = studio.getLicence('L-OLD00001');
  assert.equal(lic.on_end, 'stop');
  assert.equal(Studio.onEndOf(lic), 'stop');
  db.close();
  fs.rmSync(dir, { recursive: true, force: true });
});

test('one customer id is one customer: the staff tools find a client by its id in the main Studio', () => {
  const ctx = makeStudio();
  const first = ctx.studio.upsertExternalCustomer({ externalId: 'proj_1', name: 'Green Mart', country: 'IN' }, ADMIN, 'ip');
  const again = ctx.studio.upsertExternalCustomer({ externalId: 'proj_1', name: 'Green Mart Ltd', country: '' }, ADMIN, 'ip');
  assert.equal(again.id, first.id);
  assert.equal(again.name, 'Green Mart Ltd', 'a renamed client is renamed');
  assert.equal(again.country, 'IN', 'an empty country does not wipe the old one');
  assert.equal(ctx.studio.getCustomerByExternalId('proj_1').id, first.id);
  assert.equal(ctx.studio.getCustomerByExternalId('proj_2'), null);
  assert.equal(code(() => ctx.studio.createCustomer({ name: 'Twin', externalId: 'proj_1' }, ADMIN, 'ip')), 'conflict');
  for (const bad of ['', 'a b', 'x/y', 'é', 'a'.repeat(81)]) assert.equal(code(() => ctx.studio.cleanExternalId(bad)), 'bad_request', JSON.stringify(bad));
});
