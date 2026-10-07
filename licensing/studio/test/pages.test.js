'use strict';
// The Studio's pages for what staff do with trials, end dates, moves and tools' sign-ins.

const test = require('node:test');
const assert = require('node:assert/strict');
const { fp } = require('./helpers');
const { start, Browser } = require('./browser');

test('a trial, extending it, turning it into a paid licence, all from the licence page', async () => {
  const s = await start();
  try {
    const sam = new Browser(s.base);
    await sam.login('sam@example.com');
    const form = await (await sam.fetch('/licences/new')).text();
    assert.match(form, /name="term" value="perpetual" checked/, 'a paid licence with no end date is the first choice');
    assert.match(form, /name="trialDays"[^>]*value="14"/, 'a trial is 14 days unless staff type another number');
    assert.match(form, /The program keeps working and shows a banner/);

    const made = await sam.post('/licences/new', { customerId: 'new', nc_name: 'Trial Shop', planCode: 'starter', term: 'trial', trialDays: '21', onEnd: 'stop', bindMode: 'device', whiteLevel: 'theme' }, '/licences/new');
    assert.equal(made.status, 303);
    const lid = /\/licences\/(L-[0-9A-Z]+)/.exec(made.headers.get('location'))[1];
    const lic = s.app.studio.getLicence(lid);
    assert.deepEqual([lic.trial, lic.on_end, lic.exp - lic.nbf], [true, 'stop', 21 * 86400]);

    // A trial that is asked to carry on is refused with a plain message and nothing is made.
    const before = s.app.db.prepare('SELECT COUNT(*) AS n FROM licences').get().n;
    const clash = await sam.post('/licences/new', { customerId: '1', planCode: 'starter', term: 'trial', onEnd: 'banner', bindMode: 'device', whiteLevel: 'theme' }, '/licences/new');
    assert.equal(clash.status, 200);
    assert.match(await clash.text(), /always stops at its end date/);
    assert.equal(s.app.db.prepare('SELECT COUNT(*) AS n FROM licences').get().n, before);

    // A paid licence made from the page: no end date, banner (the choices the page starts with).
    const paid0 = await sam.post('/licences/new', { customerId: '1', planCode: 'starter', term: 'perpetual', onEnd: 'banner', trialDays: '14', bindMode: 'device', whiteLevel: 'theme' }, '/licences/new');
    assert.equal(paid0.status, 303, 'the trial-days box is ignored for a paid licence');
    const paid0Lid = /\/licences\/(L-[0-9A-Z]+)/.exec(paid0.headers.get('location'))[1];
    assert.deepEqual([s.app.studio.getLicence(paid0Lid).exp, s.app.studio.getLicence(paid0Lid).on_end, s.app.studio.getLicence(paid0Lid).trial], [null, 'banner', false]);

    const view = await (await sam.fetch(`/licences/${lid}`)).text();
    assert.match(view, /Extend the trial/);
    assert.match(view, /Turn the trial into a paid licence/);
    assert.match(view, /The program stops/);
    assert.match(view, /PC history/);

    await sam.post(`/licences/${lid}/extend`, { days: '7' }, `/licences/${lid}`);
    assert.equal(s.app.studio.getLicence(lid).exp, lic.exp + 7 * 86400);
    const bad = await sam.post(`/licences/${lid}/extend`, { days: '0' }, `/licences/${lid}`);
    assert.equal(bad.status, 303);
    assert.match(decodeURIComponent(bad.headers.get('location')), /whole number of days/);

    await sam.post(`/licences/${lid}/convert`, { term: 'perpetual' }, `/licences/${lid}`);
    const paid = s.app.studio.getLicence(lid);
    assert.deepEqual([paid.trial, paid.exp, paid.on_end], [false, null, 'banner']);
    const after = await (await sam.fetch(`/licences/${lid}`)).text();
    assert.doesNotMatch(after, /Turn the trial into a paid licence/);
    assert.match(after, /Never \(no end date\)/);
  } finally { await s.stop(); }
});

test('the licence page shows how many times the customer moved the licence, and the history of PCs', async () => {
  const s = await start();
  try {
    const admin = new Browser(s.base);
    await admin.login('boss@example.com');
    const made = await admin.post('/licences/new', { customerId: 'new', nc_name: 'Mover', planCode: 'starter', term: 'perpetual', bindMode: 'device', whiteLevel: 'theme' }, '/licences/new');
    const lid = /\/licences\/(L-[0-9A-Z]+)/.exec(made.headers.get('location'))[1];
    const key = s.app.studio.getLicence(lid).licence_key;
    const call = async (p, body) => { const r = await fetch(s.base + p, { method: 'POST', headers: { 'content-type': 'application/json' }, body: JSON.stringify(body) }); return { status: r.status, body: await r.json() }; };
    const a = await call('/api/v1/activate', { key, fp: fp('old-pc'), host: 'OLD-PC' });
    assert.deepEqual((await call('/api/v1/deactivate', { lid, act: a.body.act, fp: fp('old-pc') })).body, { ok: true });
    await call('/api/v1/activate', { key, fp: fp('new-pc'), host: 'NEW-PC' });
    const view = await (await admin.fetch(`/licences/${lid}`)).text();
    assert.match(view, /Used so far: <strong>1 of 2<\/strong>/);
    assert.match(view, /The customer moved the licence off a PC: OLD-PC/);
    assert.match(view, /A PC was activated: NEW-PC/);
  } finally { await s.stop(); }
});

test('an ended paid licence says it still works; a trial and a licence set to stop say they ended', async () => {
  const s = await start();
  try {
    const admin = new Browser(s.base);
    await admin.login('boss@example.com');
    const customer = s.app.studio.createCustomer({ name: 'Old Shop' }, { id: null, email: 'x', role: 'admin' }, 'ip');
    const issue = (over) => s.app.studio.createLicence({ customerId: customer.id, planCode: 'starter', startDate: '2020-01-01', ...over }, { id: null, email: 'x', role: 'admin' }, 'ip');
    const paid = issue({ term: 'y1', onEnd: 'banner' });
    const strict = issue({ term: 'y1', onEnd: 'stop' });
    const trial = issue({ term: 'trial' });
    const list = await (await admin.fetch('/licences')).text();
    assert.equal((list.match(/Ended, still working/g) || []).length, 1);
    assert.equal((list.match(/Trial ended/g) || []).length, 1);
    assert.match(await (await admin.fetch(`/licences/${paid.lid}`)).text(), /Keeps working and shows a banner/);
    assert.match(await (await admin.fetch(`/licences/${strict.lid}`)).text(), /The program stops/);
    assert.match(await (await admin.fetch(`/licences/${trial.lid}`)).text(), /Trial ended/);
  } finally { await s.stop(); }
});

test('an administrator makes a service account, sees its token once, and can switch it off; nobody else can', async () => {
  const s = await start();
  try {
    const admin = new Browser(s.base);
    await admin.login('boss@example.com');
    const sam = new Browser(s.base);
    await sam.login('sam@example.com');
    assert.equal((await sam.fetch('/service-accounts')).status, 403);
    assert.equal((await sam.post('/service-accounts', { name: 'Sneaky', role: 'admin' }, '/licences')).status, 403);
    assert.equal(s.app.accounts.list().length, 0);

    assert.match(await (await admin.fetch('/service-accounts')).text(), /No service account yet/);
    const made = await admin.post('/service-accounts', { name: 'Main Studio', role: 'sales' }, '/service-accounts');
    assert.equal(made.status, 200);
    const html = await made.text();
    const token = /id="the-token">(ngsa_[A-Za-z0-9_-]{43})</.exec(html)[1];
    assert.match(html, /shown only this once/);
    // The token works against the staff API ...
    const res = await fetch(s.base + '/api/staff/v1/customers/x/licences', { headers: { authorization: `Bearer ${token}` } });
    assert.equal(res.status, 200);
    // ... and is never shown again.
    const list = await (await admin.fetch('/service-accounts')).text();
    assert.ok(!list.includes(token));
    assert.match(list, /Main Studio/);
    assert.match(list, /ngsa_[A-Za-z0-9_-]{4}…/);
    // Bad input is refused in plain words.
    const noName = await admin.post('/service-accounts', { name: '  ', role: 'sales' }, '/service-accounts');
    assert.equal(noName.status, 303);
    assert.match(decodeURIComponent(noName.headers.get('location')), /Give the account a name/);
    assert.equal((await admin.post('/service-accounts', { name: 'X', role: 'emperor' }, '/service-accounts')).status, 303);
    assert.equal(s.app.accounts.list().length, 1);

    const id = s.app.accounts.list()[0].id;
    assert.equal((await admin.post(`/service-accounts/${id}/off`, {}, '/service-accounts')).status, 303);
    assert.equal((await fetch(s.base + '/api/staff/v1/customers/x/licences', { headers: { authorization: `Bearer ${token}` } })).status, 401);
    const audit = await (await admin.fetch('/audit')).text();
    for (const word of ['service-account.create', 'service-account.off']) assert.ok(audit.includes(word), word);
  } finally { await s.stop(); }
});

test('the staff API answers with the same hardening headers as every other page and call', async () => {
  const s = await start();
  try {
    // (The rule that a token never travels in clear text, HTTPS or this PC only, is the one in src/app.js for every page and call;
    // it could not be tried here from another address.)
    const res = await fetch(s.base + '/api/staff/v1/customers/x/licences');
    assert.equal(res.status, 401);
    assert.equal(res.headers.get('x-content-type-options'), 'nosniff');
    assert.equal(res.headers.get('cache-control'), 'no-store');
    assert.match(res.headers.get('content-security-policy'), /default-src 'none'/);
  } finally { await s.stop(); }
});
