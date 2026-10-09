import { test } from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, rmSync, readFileSync, writeFileSync, existsSync, readdirSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { Workspace, StudioError } from '../lib/workspace.mjs';
import { listZip } from '../lib/zip.mjs';

const PNG = Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==', 'base64');
const good = (over = {}) => ({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example' } }, device: { kind: 'touch-pos', os: 'windows', screen: 'standard' }, look: { primaryColor: '#0a7d4b', style: 'friendly' }, licence: { whiteLabel: 'theme' }, ...over });

function fresh() {
  const folder = mkdtempSync(join(tmpdir(), 'studio-ws-'));
  const { workspace, admin } = Workspace.init(folder, { name: 'Asha Admin', password: 'a-long-password' });
  const actor = (m) => ({ id: m.id, name: m.name, role: m.role });
  const asha = actor(admin);
  const sam = actor(workspace.addMember(asha, { name: 'Sam Sales', role: 'sales', password: 'sam-long-password' }));
  const rita = actor(workspace.addMember(asha, { name: 'Rita Reviewer', role: 'reviewer', password: 'rita-long-password' }));
  return { folder, ws: workspace, asha, sam, rita, done: () => rmSync(folder, { recursive: true, force: true }) };
}

test('a workspace starts with one administrator, who signs in with a password that is never kept in plain form', () => {
  const { folder, ws, asha, done } = fresh();
  try {
    assert.equal(ws.team().length, 3);
    assert.deepEqual(ws.signIn(asha.id, 'a-long-password'), asha);
    assert.throws(() => ws.signIn(asha.id, 'wrong'), (e) => e instanceof StudioError && e.status === 401);
    const text = readFileSync(join(folder, 'team.json'), 'utf8');
    assert.ok(!text.includes('a-long-password') && !text.includes('sam-long-password'));
    assert.throws(() => Workspace.init(folder, { name: 'x', password: 'another-password' }), /already a Studio workspace/);
    assert.throws(() => Workspace.init(mkdtempSync(join(tmpdir(), 'x-')), { name: 'x', password: 'short' }), /at least 8/);
  } finally { done(); }
});

test('five wrong passwords lock that person for a minute, and the first signed-in person is not locked by another\'s tries', () => {
  const { ws, asha, sam, done } = fresh();
  try {
    for (let i = 0; i < 5; i += 1) assert.throws(() => ws.signIn(sam.id, 'nope-nope'), /not right/);
    assert.throws(() => ws.signIn(sam.id, 'sam-long-password'), (e) => e.status === 429);
    assert.deepEqual(ws.signIn(asha.id, 'a-long-password'), asha);
    assert.throws(() => ws.signIn('m-unknown', 'whatever-long'), /not right/, 'a name that does not exist looks the same as a wrong password');
  } finally { done(); }
});

test('roles decide who can do what, and there is always one administrator', () => {
  const { ws, asha, sam, rita, done } = fresh();
  try {
    assert.throws(() => ws.addMember(sam, { name: 'X Y', role: 'sales', password: 'long-enough-1' }), (e) => e.status === 403);
    assert.throws(() => ws.changeRole(asha, asha.id, 'sales'), /one administrator/);
    assert.throws(() => ws.setActive(asha, asha.id, false), /one administrator/);
    ws.changeRole(asha, rita.id, 'admin');
    ws.changeRole(asha, asha.id, 'reviewer');
    assert.equal(ws.team().filter((m) => m.role === 'admin').length, 1);
    ws.setActive(ws.member(rita.id), sam.id, false);
    assert.equal(ws.member(sam.id), null, 'a person switched off cannot sign in');
    assert.throws(() => ws.signIn(sam.id, 'sam-long-password'), /not right/);
  } finally { done(); }
});

test('a customer goes from details to an approved release, and approval needs a second person', () => {
  const { ws, asha, sam, rita, done } = fresh();
  try {
    const c = ws.create(sam, good());
    assert.equal(c.id, 'luzon-fresh-mart');
    assert.equal(c.state, 'draft');
    assert.equal(c.check.complete, true);
    ws.setLogo(sam, c.id, PNG);
    const proposed = ws.makeProposal(sam, c.id);
    assert.equal(proposed.state, 'proposed');
    assert.equal(proposed.proposal.theme.look, 'top');
    assert.match(proposed.proposal.brand.logo, /^data:image\/png;base64,/);
    assert.throws(() => ws.approve(rita, c.id), /not waiting for approval/);
    assert.throws(() => ws.submit(rita, 'luzon-fresh-mart-2'), /not a customer|not found/i);
    ws.submit(sam, c.id);
    assert.throws(() => ws.approve(sam, c.id), (e) => e.status === 403, 'sales cannot approve');
    assert.throws(() => ws.makeProposal(sam, c.id), /waiting for approval/);
    const approved = ws.approve(rita, c.id);
    assert.equal(approved.state, 'approved');
    assert.equal(approved.releases.length, 1);
    assert.equal(approved.releases[0].approvedBy.name, 'Rita Reviewer');
    assert.equal(approved.releases[0].preparedBy.name, 'Sam Sales');
    assert.equal(ws.verifyRelease(c.id, 1).ok, true);
    const files = ws.profileFiles(c.id, 1).map((f) => f.name);
    assert.deepEqual(files, ['profile/setup.json', 'profile/theme.json', 'profile/brand.json']);
    const log = ws.audit({ customer: c.id }).map((e) => e.action);
    for (const a of ['customer.created', 'customer.logo', 'proposal.saved', 'review.submitted', 'release.approved']) assert.ok(log.includes(a), a);
    assert.equal(ws.verifyAudit().ok, true);
    void asha;
  } finally { done(); }
});

test('someone who prepared a setup cannot approve it, unless an administrator says why', () => {
  const { ws, asha, rita, done } = fresh();
  try {
    const c = ws.create(rita, good());
    ws.makeProposal(rita, c.id);
    ws.submit(rita, c.id);
    assert.throws(() => ws.approve(rita, c.id), (e) => e.code === 'same-person');
    assert.throws(() => ws.approve(rita, c.id, { overrideReason: 'I am in a hurry to finish' }), (e) => e.code === 'same-person', 'a reviewer has no override');
    const ok = ws.approve(asha, c.id);
    assert.equal(ok.releases[0].selfApproved, false);
    const d = ws.create(asha, good({ business: { name: 'Second Shop', country: 'IN', region: '27', industry: 'retail' } }));
    ws.makeProposal(asha, d.id); ws.submit(asha, d.id);
    assert.throws(() => ws.approve(asha, d.id, { overrideReason: 'short' }), /say why/);
    const self = ws.approve(asha, d.id, { overrideReason: 'Only one person in the office today' });
    assert.equal(self.releases[0].selfApproved, true);
    assert.match(ws.audit({ customer: d.id })[0].detail, /prepared it\. Reason: Only one person/);
  } finally { done(); }
});

test('changing the details after a setup was prepared makes it out of date, and an approved release stays as it was', () => {
  const { ws, sam, rita, done } = fresh();
  try {
    const c = ws.create(sam, good());
    ws.makeProposal(sam, c.id); ws.submit(sam, c.id); ws.approve(rita, c.id);
    const changed = ws.saveIntake(sam, c.id, good({ look: { primaryColor: '#aa2233', style: 'bold' } }));
    assert.equal(changed.state, 'draft');
    assert.equal(changed.stale, true);
    assert.equal(changed.releases.length, 1);
    assert.equal(JSON.parse(readFileSync(join(ws.release(c.id, 1).dir, 'brand.json'), 'utf8')).primaryColor, '#0a7d4b', 'the release keeps what was approved');
    ws.makeProposal(sam, c.id); ws.submit(sam, c.id);
    const second = ws.approve(rita, c.id);
    assert.equal(second.releases.length, 2);
    assert.equal(ws.summary(c.id).latestRelease, 2);
  } finally { done(); }
});

test('a release that was changed afterwards is noticed and refused', () => {
  const { ws, sam, rita, done } = fresh();
  try {
    const c = ws.create(sam, good());
    ws.makeProposal(sam, c.id); ws.submit(sam, c.id); ws.approve(rita, c.id);
    const file = join(ws.release(c.id, 1).dir, 'theme.json');
    rmSync(file, { force: true });
    writeFileSync(file, '{"density":"compact"}');
    const v = ws.verifyRelease(c.id, 1);
    assert.equal(v.ok, false);
    assert.match(v.problems.join(), /theme\.json was changed after it was approved/);
    assert.throws(() => ws.profileFiles(c.id, 1), (e) => e.code === 'tampered');
  } finally { done(); }
});

test('the activity record notices a line that was changed or removed', () => {
  const { folder, ws, sam, done } = fresh();
  try {
    ws.create(sam, good());
    assert.equal(ws.verifyAudit().ok, true);
    const file = join(folder, 'audit.jsonl');
    const lines = readFileSync(file, 'utf8').split('\n').filter(Boolean);
    assert.ok(lines.length >= 4);
    const tampered = lines.slice();
    tampered[2] = tampered[2].replace('"action":"', '"action":"x');
    writeFileSync(file, tampered.join('\n') + '\n');
    const r = ws.verifyAudit();
    assert.equal(r.ok, false);
    assert.equal(r.brokenAt, 3);
    writeFileSync(file, [lines[0], lines[2], ...lines.slice(3)].join('\n') + '\n');
    assert.equal(ws.verifyAudit().ok, false, 'a removed line shows too');
  } finally { done(); }
});

test('a proposal from elsewhere is read again by the rules: bad parts are named, and the customer\'s own identity is put back', () => {
  const { ws, sam, done } = fresh();
  try {
    const c = ws.create(sam, good());
    const out = ws.saveProposal(sam, c.id, {
      setup: { schema: 1, business: { name: 'Totally Other Name', country: 'IN', industry: 'restaurant' }, settings: { receiptFooter: 'Salamat po!', paymentMethods: ['cash', '<script>'], taxRegistered: false }, vocabulary: { customer: ['Suki', 'Sukis'] }, password: 'x' },
      theme: { shape: 'pill', surface: 'plaid', fontScale: 5 },
      brand: { name: 'Evil', primaryColor: '#ffff00', logo: 'https://evil.example/x.png' },
    }, { source: 'ai:test', note: 'From a test' });
    const p = out.proposal;
    assert.equal(p.setup.business.name, 'Luzon Fresh Mart');
    assert.equal(p.setup.business.country, 'PH');
    assert.equal(p.setup.business.industry, 'retail');
    assert.equal(p.setup.settings.taxRegistered, true, 'what the details say wins');
    assert.deepEqual(p.setup.settings.paymentMethods, ['cash']);
    assert.deepEqual(p.setup.vocabulary.customer, ['Suki', 'Sukis']);
    assert.equal(p.theme.shape, 'pill');
    assert.equal(p.theme.surface, undefined);
    assert.equal(p.brand.name, 'Luzon Fresh Mart');
    assert.equal(p.brand.primaryColor, '#0a7d4b');
    assert.equal(p.brand.logo, undefined);
    const all = p.problems.join('\n');
    for (const part of ['password', 'surface', 'letter size', 'too light', 'kept']) assert.match(all, new RegExp(part, 'i'));
    assert.equal(p.source, 'ai:test');
    assert.throws(() => ws.saveProposal(sam, c.id, { setup: '{ nope' }), /could not be used/);
  } finally { done(); }
});

test('an incomplete customer can be saved but not prepared, and roles stop what they must', () => {
  const { ws, sam, rita, done } = fresh();
  try {
    const c = ws.create(sam, { business: { name: 'Half Done', country: 'PH' }, look: { primaryColor: '#ffff00' } });
    assert.equal(c.check.complete, false);
    assert.ok(c.check.errors.some((e) => e.field === 'look.primaryColor'));
    assert.throws(() => ws.makeProposal(sam, c.id), (e) => e.code === 'incomplete' && e.details.length > 0);
    assert.throws(() => ws.create(sam, { business: { name: '' } }), /name of the business/);
    assert.throws(() => ws.recordBuild(sam, c.id, { release: 1 }), (e) => e.status === 403);
    assert.throws(() => ws.recordBuild(rita, c.id, { release: 1 }), /approved release/);
  } finally { done(); }
});

test('an edit made at the same time as another is refused, not silently lost', () => {
  const { ws, sam, rita, done } = fresh();
  try {
    const c = ws.create(sam, good());
    ws.saveIntake(sam, c.id, good({ notes: 'first' }), { ifRev: c.rev });
    assert.throws(() => ws.saveIntake(rita, c.id, good({ notes: 'second' }), { ifRev: c.rev }), (e) => e.status === 409);
  } finally { done(); }
});

test('a name that is not a customer, or tries to leave the folder, finds nothing', () => {
  const { ws, sam, done } = fresh();
  try {
    for (const id of ['../team', '..', 'a/b', 'A', '', 'x'.repeat(60)]) assert.throws(() => ws.get(id), (e) => e.status === 404, id);
    assert.throws(() => ws.release('luzon', 1), /not a customer|not found/i);
    void sam;
  } finally { done(); }
});

test('a backup is one zip of what cannot be made again, and a logo that is not a picture is refused', () => {
  const { ws, asha, sam, done } = fresh();
  try {
    const c = ws.create(sam, good());
    assert.throws(() => ws.setLogo(sam, c.id, Buffer.from('MZ not a picture')), /PNG, JPEG or SVG/);
    assert.throws(() => ws.setLogo(sam, c.id, Buffer.from('<svg xmlns="http://www.w3.org/2000/svg"><script>alert(1)</script></svg>')), /scripts/);
    assert.throws(() => ws.backup(sam), (e) => e.status === 403);
    const { file } = ws.backup(asha);
    const names = listZip(readFileSync(file));
    for (const n of ['studio.json', 'team.json', 'audit.jsonl', 'customers/luzon-fresh-mart/intake.json', 'customers/luzon-fresh-mart/customer.json']) assert.ok(names.includes(n), n);
    assert.ok(!names.some((n) => n.startsWith('backups/')));
    assert.ok(existsSync(join(file, '..')) && readdirSync(join(file, '..')).length === 1);
  } finally { done(); }
});
