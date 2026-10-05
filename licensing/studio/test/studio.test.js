'use strict';
const test = require('node:test');
const assert = require('node:assert/strict');
const C = require('../lib/crypto');
const { ApiError, DAY } = require('../lib/studio');
const { makeStudio, ADMIN, SALES, fp } = require('./helpers');

function newLicence(ctx, over = {}) {
  const customer = ctx.studio.createCustomer({ name: 'Green Mart', country: 'India', contactName: 'Asha', email: 'asha@greenmart.example' }, ADMIN, '1.1.1.1');
  return ctx.studio.createLicence({ customerId: customer.id, planCode: 'business', term: 'y1', ...over }, ADMIN, '1.1.1.1');
}

test('tokens: sign, verify, and refuse tampering, wrong keys and wrong type', () => {
  const k = C.generateSigningKey();
  const other = C.generateSigningKey();
  const token = C.signToken({ typ: 'lic', lid: 'L-1' }, k);
  const trusted = [{ kid: k.kid, publicKey: k.publicKey }];

  assert.equal(C.verifyToken(token, trusted, 'lic').lid, 'L-1');
  assert.throws(() => C.verifyToken(token, trusted, 'act'), /Expected a act/);
  assert.throws(() => C.verifyToken(token, [{ kid: other.kid, publicKey: other.publicKey }], 'lic'), /Unknown signing key/);
  assert.throws(() => C.verifyToken(token, [{ kid: k.kid, publicKey: other.publicKey }], 'lic'), /Signature/);

  const [p, body, sig] = token.split('.');
  const forged = JSON.parse(Buffer.from(body, 'base64url').toString());
  forged.lid = 'L-2';
  const tampered = [p, Buffer.from(JSON.stringify(forged)).toString('base64url'), sig].join('.');
  assert.throws(() => C.verifyToken(tampered, trusted, 'lic'), /Signature/);
  assert.throws(() => C.verifyToken('garbage', trusted), /Not a NextGenOS token/);
});

test('private key encryption round-trips and rejects a wrong passphrase', () => {
  const box = C.encryptSecret('secret pem', 'correct horse');
  assert.equal(C.decryptSecret(box, 'correct horse'), 'secret pem');
  assert.throws(() => C.decryptSecret(box, 'wrong'), /Wrong passphrase/);
});

test('licence keys are well formed and forgiving to type', () => {
  const key = C.generateLicenceKey();
  assert.match(key, /^NGOS(-[0-9A-HJKMNP-TV-Z]{5}){4}$/);
  assert.equal(C.normaliseLicenceKey(key.toLowerCase().replace(/-/g, ' ')), key);
  assert.equal(C.normaliseLicenceKey('ngos-0oi1l-00000-00000-00000'), 'NGOS-00111-00000-00000-00000');
  assert.equal(C.normaliseLicenceKey('nope'), null);
  assert.notEqual(C.generateLicenceKey(), C.generateLicenceKey());
});

test('activate: issues a signed licence and activation bound to the PC', () => {
  const ctx = makeStudio();
  const lic = newLicence(ctx);
  const res = ctx.studio.activate({ key: lic.licence_key, version: '2.18.0', fp: fp('pc-a'), host: 'COUNTER-1' }, '9.9.9.9');

  const l = C.verifyToken(res.lic, ctx.trusted, 'lic');
  const a = C.verifyToken(res.act, ctx.trusted, 'act');
  const crl = C.verifyToken(res.crl, ctx.trusted, 'crl');
  assert.equal(l.lid, lic.lid);
  assert.deepEqual(l.modules, ['pos', 'ai', 'dashboard', 'owner-live']);
  assert.equal(l.cust.name, 'Green Mart');
  assert.equal(a.lid, lic.lid);
  assert.equal(a.fp.length, 5);
  assert.equal(a.fpMin, 3); // 60% of 5 parts
  assert.equal(a.next, ctx.state.t + 7 * DAY);
  assert.equal(a.until, ctx.state.t + 21 * DAY);
  assert.deepEqual(crl.revoked, []);
  assert.equal(ctx.studio.listActivations(lic.lid).length, 1);
});

test('activate: the same PC again does not use another seat; a 4th PC on a 3-PC plan is refused', () => {
  const ctx = makeStudio();
  const lic = newLicence(ctx);
  for (const name of ['pc-a', 'pc-a', 'pc-b', 'pc-c']) ctx.studio.activate({ key: lic.licence_key, fp: fp(name), host: name }, 'ip');
  assert.equal(ctx.studio.listActivations(lic.lid).filter((a) => a.active).length, 3);
  assert.throws(() => ctx.studio.activate({ key: lic.licence_key, fp: fp('pc-d'), host: 'pc-d' }, 'ip'), (e) => e instanceof ApiError && e.code === 'limit_reached');

  // Freeing a PC makes room.
  const first = ctx.studio.listActivations(lic.lid)[0];
  ctx.studio.freeDevice(first.id, ADMIN, 'ip');
  assert.ok(ctx.studio.activate({ key: lic.licence_key, fp: fp('pc-d'), host: 'pc-d' }, 'ip').act);
});

test('activate: a PC with one changed part (disk) is still the same PC; a different PC is not', () => {
  const ctx = makeStudio();
  const lic = newLicence(ctx, { devices: 1 });
  const original = fp('pc-a');
  ctx.studio.activate({ key: lic.licence_key, fp: original, host: 'A' }, 'ip');

  const newDisk = { ...original, disk: fp('new-disk').disk };
  const res = ctx.studio.activate({ key: lic.licence_key, fp: newDisk, host: 'A' }, 'ip');
  assert.ok(res.act);
  assert.equal(ctx.studio.listActivations(lic.lid).filter((a) => a.active).length, 1);

  assert.throws(() => ctx.studio.activate({ key: lic.licence_key, fp: fp('other-pc'), host: 'B' }, 'ip'), (e) => e.code === 'limit_reached');
});

test('activate: unknown, revoked, suspended, expired and not-yet-started licences are refused', () => {
  const ctx = makeStudio();
  assert.throws(() => ctx.studio.activate({ key: 'NGOS-AAAAA-AAAAA-AAAAA-AAAAA', fp: fp('x') }, 'ip'), (e) => e.code === 'unknown_key');

  const lic = newLicence(ctx);
  ctx.studio.setStatus(lic.lid, 'suspended', 'unpaid', ADMIN, 'ip');
  assert.throws(() => ctx.studio.activate({ key: lic.licence_key, fp: fp('x') }, 'ip'), (e) => e.code === 'suspended');
  ctx.studio.setStatus(lic.lid, 'active', '', ADMIN, 'ip');
  assert.ok(ctx.studio.activate({ key: lic.licence_key, fp: fp('x') }, 'ip').act);
  ctx.studio.setStatus(lic.lid, 'revoked', 'fraud', ADMIN, 'ip');
  assert.throws(() => ctx.studio.activate({ key: lic.licence_key, fp: fp('y') }, 'ip'), (e) => e.code === 'revoked');
  assert.throws(() => ctx.studio.setStatus(lic.lid, 'active', '', ADMIN, 'ip'), (e) => e.code === 'conflict');

  const lic2 = newLicence(ctx, { term: 'trial30' });
  ctx.state.t += 31 * DAY;
  assert.throws(() => ctx.studio.activate({ key: lic2.licence_key, fp: fp('x') }, 'ip'), (e) => e.code === 'expired');

  const future = newLicence(ctx, { startDate: '2099-01-01' });
  assert.throws(() => ctx.studio.activate({ key: future.licence_key, fp: fp('x') }, 'ip'), (e) => e.code === 'not_started');
});

test('check-in: refreshes the activation, picks up changes, and sees revocation in the list', () => {
  const ctx = makeStudio();
  const lic = newLicence(ctx);
  const f = fp('pc-a');
  const first = ctx.studio.activate({ key: lic.licence_key, fp: f, host: 'A' }, 'ip');

  ctx.state.t += 6 * DAY;
  ctx.studio.updateLicence(lic.lid, { devices: 5 }, ADMIN, 'ip'); // revision 2
  const res = ctx.studio.checkin({ lid: lic.lid, act: first.act, fp: f, version: '2.19.0', usage: { stores: 1, devices: 2, users: 4 } }, 'ip');
  assert.equal(C.verifyToken(res.lic, ctx.trusted, 'lic').limits.devices, 5);
  assert.equal(C.verifyToken(res.lic, ctx.trusted, 'lic').rev, 2);
  assert.equal(C.verifyToken(res.act, ctx.trusted, 'act').next, ctx.state.t + 7 * DAY);

  ctx.studio.setStatus(lic.lid, 'revoked', '', ADMIN, 'ip');
  assert.throws(() => ctx.studio.checkin({ lid: lic.lid, act: res.act, fp: f }, 'ip'), (e) => e.code === 'revoked');
  assert.deepEqual(C.verifyToken(ctx.studio.crlToken(), ctx.trusted, 'crl').revoked, [lic.lid]);
});

test('check-in: refuses a different PC, a freed PC and a token for another licence', () => {
  const ctx = makeStudio();
  const a = newLicence(ctx);
  const b = newLicence(ctx);
  const f = fp('pc-a');
  const act = ctx.studio.activate({ key: a.licence_key, fp: f, host: 'A' }, 'ip').act;
  const actB = ctx.studio.activate({ key: b.licence_key, fp: f, host: 'A' }, 'ip').act;

  assert.throws(() => ctx.studio.checkin({ lid: a.lid, act, fp: fp('copy') }, 'ip'), (e) => e.code === 'device_mismatch');
  assert.throws(() => ctx.studio.checkin({ lid: a.lid, act: actB, fp: f }, 'ip'), (e) => e.code === 'bad_request');
  assert.throws(() => ctx.studio.checkin({ lid: a.lid, act: 'junk', fp: f }, 'ip'), (e) => e.code === 'bad_request');

  ctx.studio.freeDevice(ctx.studio.listActivations(a.lid)[0].id, SALES, 'ip');
  assert.throws(() => ctx.studio.checkin({ lid: a.lid, act, fp: f }, 'ip'), (e) => e.code === 'device_mismatch');
});

test('deactivate releases the seat', () => {
  const ctx = makeStudio();
  const lic = newLicence(ctx, { devices: 1 });
  const f = fp('pc-a');
  const act = ctx.studio.activate({ key: lic.licence_key, fp: f, host: 'A' }, 'ip').act;
  ctx.studio.deactivate({ lid: lic.lid, act, fp: f }, 'ip');
  assert.ok(ctx.studio.activate({ key: lic.licence_key, fp: fp('pc-b'), host: 'B' }, 'ip').act);
});

test('offline activation: request code in, response code out, long validity', () => {
  const ctx = makeStudio();
  const lic = newLicence(ctx);
  const request = 'NGOSREQ1.' + Buffer.from(JSON.stringify({ key: lic.licence_key, fp: fp('offline-pc'), host: 'REMOTE', version: '2.18.0' })).toString('base64url');
  const response = ctx.studio.offlineActivate(request, ADMIN, 'ip');
  assert.ok(response.startsWith('NGOSRES1.'));
  const body = JSON.parse(Buffer.from(response.slice(9), 'base64url').toString());
  const act = C.verifyToken(body.act, ctx.trusted, 'act');
  assert.equal(act.next, ctx.state.t + 365 * DAY);
  assert.equal(act.until, act.next);
  assert.throws(() => ctx.studio.offlineActivate('NGOSREQ1.@@@', ADMIN, 'ip'), (e) => e.code === 'bad_request');
  assert.throws(() => ctx.studio.offlineActivate('hello', ADMIN, 'ip'), (e) => e.code === 'bad_request');
});

test('terms: an activation never outlasts the licence; trial is flagged', () => {
  const ctx = makeStudio();
  const trial = newLicence(ctx, { term: 'trial30' });
  assert.equal(trial.trial, true);
  ctx.state.t += 20 * DAY; // 10 days of the trial left
  const act = C.verifyToken(ctx.studio.activate({ key: trial.licence_key, fp: fp('t') }, 'ip').act, ctx.trusted, 'act');
  assert.equal(act.next, ctx.state.t + 7 * DAY);
  assert.equal(act.until, trial.exp); // 21 days would pass the end of the trial, so it stops at the end of the trial
});

test('roles: sales cannot exceed plan caps, issue perpetual licences or unbound licences', () => {
  const ctx = makeStudio();
  const customer = ctx.studio.createCustomer({ name: 'X' }, SALES, 'ip');
  const base = { customerId: customer.id, planCode: 'business', term: 'y1' };
  assert.throws(() => ctx.studio.createLicence({ ...base, devices: 11 }, SALES, 'ip'), (e) => e.code === 'forbidden');
  assert.throws(() => ctx.studio.createLicence({ ...base, term: 'perpetual' }, SALES, 'ip'), (e) => e.code === 'forbidden');
  assert.throws(() => ctx.studio.createLicence({ ...base, bindMode: 'none' }, SALES, 'ip'), (e) => e.code === 'forbidden');
  assert.ok(ctx.studio.createLicence({ ...base, devices: 10 }, SALES, 'ip'));
  assert.equal(ctx.studio.createLicence({ ...base, devices: 40, term: 'perpetual' }, ADMIN, 'ip').exp, null);
  // Sales cannot add modules the plan does not include.
  const l = ctx.studio.createLicence({ ...base, modules: ['pos', 'chain', 'api'] }, SALES, 'ip');
  assert.ok(!l.modules.includes('chain'));
});

test('renewal adds to the end date when renewed early, and from today when already ended', () => {
  const ctx = makeStudio();
  const lic = newLicence(ctx);
  const renewed = ctx.studio.updateLicence(lic.lid, { extendTerm: 'y1' }, SALES, 'ip');
  assert.equal(renewed.exp, lic.exp + 365 * DAY);
  assert.equal(renewed.rev, 2);
  ctx.state.t = renewed.exp + 10 * DAY;
  const again = ctx.studio.updateLicence(lic.lid, { extendTerm: 'y1' }, SALES, 'ip');
  assert.equal(again.exp, ctx.state.t + 365 * DAY);
});

test('domain-bound licences need a website and activate without a PC seat', () => {
  const ctx = makeStudio();
  const customer = ctx.studio.createCustomer({ name: 'Web Shop' }, ADMIN, 'ip');
  assert.throws(() => ctx.studio.createLicence({ customerId: customer.id, planCode: 'growth', term: 'y1', bindMode: 'domain' }, ADMIN, 'ip'), (e) => e.code === 'bad_request');
  assert.throws(() => ctx.studio.createLicence({ customerId: customer.id, planCode: 'growth', term: 'y1', bindMode: 'domain', domains: 'not a domain' }, ADMIN, 'ip'), (e) => e.code === 'bad_request');
  const lic = ctx.studio.createLicence({ customerId: customer.id, planCode: 'growth', term: 'y1', bindMode: 'domain', domains: 'https://Shop.Example.com/, *.example.org' }, ADMIN, 'ip');
  assert.deepEqual(lic.bind, { mode: 'domain', domains: ['shop.example.com', '*.example.org'] });
  const res = ctx.studio.activate({ key: lic.licence_key, fp: fp('server') }, 'ip');
  assert.equal(res.act, null);
  assert.deepEqual(C.verifyToken(res.lic, ctx.trusted, 'lic').bind.domains, ['shop.example.com', '*.example.org']);
});

test('brand profile travels inside the signed licence; bad logos are refused', () => {
  const ctx = makeStudio();
  const brandId = ctx.studio.saveBrand(null, { name: 'RetailPro', primaryColor: '#112233', supportEmail: 'help@retailpro.example', poweredBy: 'on' }, ADMIN, 'ip');
  const lic = newLicence(ctx, { brandId });
  const claims = C.verifyToken(ctx.studio.activate({ key: lic.licence_key, fp: fp('p') }, 'ip').lic, ctx.trusted, 'lic');
  assert.equal(claims.brand.name, 'RetailPro');
  assert.equal(claims.brand.primaryColor, '#112233');
  assert.equal(claims.brand.poweredBy, true);
  assert.equal(claims.brand.accentColor, '#f59e0b');
  assert.throws(() => ctx.studio.saveBrand(null, { name: 'Bad', logo: 'data:text/html;base64,PHNjcmlwdD4=' }, ADMIN, 'ip'), (e) => e.code === 'bad_request');
});

test('the customer message contains the key, the end date and the steps', () => {
  const ctx = makeStudio();
  const lic = newLicence(ctx);
  const msg = ctx.studio.customerMessage(lic);
  assert.match(msg, /Licence key:\s+NGOS-/);
  assert.ok(msg.includes(lic.licence_key));
  assert.match(msg, /Hello Asha,/);
  assert.match(msg, /Activate without Internet/);
});

test('users: password rules, lockout after repeated failures, last admin is protected', () => {
  const ctx = makeStudio();
  assert.match(ctx.auth.constructor.validatePassword('short'), /10 characters/);
  const id = ctx.auth.createUser({ email: 'boss@example.com', name: 'Boss', role: 'admin', password: 'Correct-Horse-9' });
  ctx.auth.setActive(1, false); // the helper's own admin; "boss" becomes the only one
  assert.equal(ctx.auth.login('boss@example.com', 'wrong').ok, false);
  assert.equal(ctx.auth.login('nobody@example.com', 'x').message, ctx.auth.login('boss@example.com', 'wrong').message);
  for (let i = 0; i < 5; i += 1) ctx.auth.login('boss@example.com', 'wrong');
  assert.match(ctx.auth.login('boss@example.com', 'Correct-Horse-9').message, /Too many wrong attempts/);
  ctx.state.t += 16 * 60;
  const ok = ctx.auth.login('boss@example.com', 'Correct-Horse-9');
  assert.equal(ok.ok, true);
  assert.throws(() => ctx.auth.setActive(id, false), /at least one active administrator/);
  assert.throws(() => ctx.auth.setRole(id, 'sales'), /at least one active administrator/);

  const s = ctx.auth.startSession(id, '1.2.3.4');
  assert.equal(ctx.auth.session(s.token).user.email, 'boss@example.com');
  ctx.state.t += 11 * 3600;
  assert.equal(ctx.auth.session(s.token), null);
});
