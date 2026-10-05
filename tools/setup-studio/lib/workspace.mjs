// The Studio's workspace: one folder holding the team, the customers, every approved release and a tamper-evident activity record. Plain files, written carefully,
// so a person can back it up by copying the folder. It lives outside the code (never in the repository) and holds no password in plain form and no licence key.
//
//   studio.json  team.json  audit.jsonl  customers/<id>/{customer,intake,proposal}.json  customers/<id>/releases/<n>/  backups/  builds/
import { existsSync, mkdirSync, readdirSync, readFileSync, rmSync, writeFileSync, appendFileSync } from 'node:fs';
import { join, basename } from 'node:path';
import { randomBytes, scryptSync, timingSafeEqual } from 'node:crypto';
import { writeAtomic, writeJson, readJson, sha256, canonical, inside, withLock, makeReadOnly } from './fsx.mjs';
import { checkIntake, blankIntake, slugFor, SLUG } from './intake.mjs';
import { propose, reconcile } from './template.mjs';
import { logoProblem } from './rules.mjs';
import { makeZip, entriesOf } from './zip.mjs';

export class StudioError extends Error {
  constructor(message, status = 400, code = 'problem', details) { super(message); this.status = status; this.code = code; this.details = details; }
}

export const ROLES = [
  { id: 'admin', label: 'Administrator', hint: 'Everything, including the team and backups.' },
  { id: 'reviewer', label: 'Reviewer', hint: 'Checks and approves setups, builds installers, hands over.' },
  { id: 'sales', label: 'Sales', hint: 'Adds customers and prepares their setup. Someone else approves.' },
];
const PERMS = {
  admin: ['team', 'backup', 'settings', 'customer.edit', 'proposal.edit', 'review.submit', 'review.decide', 'build', 'deliver', 'override'],
  reviewer: ['customer.edit', 'proposal.edit', 'review.submit', 'review.decide', 'build', 'deliver'],
  sales: ['customer.edit', 'proposal.edit', 'review.submit'],
};
export const can = (member, perm) => !!member && (PERMS[member.role] ?? []).includes(perm);
const need = (member, perm, what) => {
  if (!member) throw new StudioError('Please sign in first.', 401, 'signin');
  if (can(member, perm)) return;
  const who = ROLES.filter((r) => PERMS[r.id].includes(perm)).map((r) => r.label.toLowerCase());
  throw new StudioError(`Your role (${ROLES.find((r) => r.id === member.role)?.label ?? member.role}) cannot ${what}. Ask ${who.length > 1 ? 'an ' + who.slice(0, -1).join(', ') + ' or ' + who.at(-1) : 'an ' + who[0]}.`, 403, 'role');
};
const hashPassword = (password, salt = randomBytes(16)) => ({ salt: salt.toString('hex'), hash: scryptSync(password, salt, 32).toString('hex') });
const passwordMatches = (password, rec) => { const a = Buffer.from(rec.hash, 'hex'); const b = scryptSync(password, Buffer.from(rec.salt, 'hex'), 32); return a.length === b.length && timingSafeEqual(a, b); };
export const checkPassword = (p) => (typeof p === 'string' && p.length >= 8 && p.length <= 200 ? null : 'A password needs at least 8 characters.');
const initials = (name) => name.split(/\s+/).filter(Boolean).slice(0, 2).map((w) => w[0].toUpperCase()).join('') || '?';
const stamp = () => new Date().toISOString();
const person = (m) => (m ? { id: m.id, name: m.name, role: m.role } : null);

export class Workspace {
  constructor(folder) { this.folder = folder; this.failures = new Map(); }

  // ---- making and opening -----------------------------------------------------------------------------------------------------------

  static exists(folder) { return existsSync(join(folder, 'studio.json')) && existsSync(join(folder, 'team.json')); }

  static init(folder, { name, password }) {
    if (Workspace.exists(folder)) throw new StudioError('There is already a Studio workspace in that folder. Open it instead.', 409, 'exists');
    if (!name || !String(name).trim()) throw new StudioError('Please type your name.');
    const bad = checkPassword(password); if (bad) throw new StudioError(bad);
    mkdirSync(join(folder, 'customers'), { recursive: true });
    const admin = { id: 'm-' + randomBytes(4).toString('hex'), name: String(name).trim().slice(0, 60), role: 'admin', createdAt: stamp(), disabled: false, ...hashPassword(password) };
    writeJson(join(folder, 'studio.json'), { schema: 1, id: 'ws-' + randomBytes(6).toString('hex'), createdAt: stamp(), settings: { ai: { tool: 'none' } } });
    writeJson(join(folder, 'team.json'), { schema: 1, members: [admin] });
    const ws = new Workspace(folder);
    ws.log(admin, 'workspace.created', null, 'Studio workspace created');
    return { workspace: ws, admin: ws.publicMember(admin) };
  }

  static open(folder) {
    if (!Workspace.exists(folder)) throw new StudioError('There is no Studio workspace in that folder yet.', 404, 'missing');
    return new Workspace(folder);
  }

  get info() { return readJson(join(this.folder, 'studio.json'), { schema: 1, settings: {} }); }

  settings() { return this.info.settings ?? {}; }

  saveSettings(actor, settings) {
    need(actor, 'settings', 'change the Studio\'s settings');
    const info = this.info;
    info.settings = { ...info.settings, ...settings };
    writeJson(join(this.folder, 'studio.json'), info);
    this.log(actor, 'settings.changed', null, Object.keys(settings).join(', '));
    return info.settings;
  }

  // ---- team ----------------------------------------------------------------------------------------------------------------------------

  #members() { return readJson(join(this.folder, 'team.json'), { members: [] }).members; }
  #saveMembers(members) { writeJson(join(this.folder, 'team.json'), { schema: 1, members }); }
  publicMember(m) { return { id: m.id, name: m.name, role: m.role, initials: initials(m.name), disabled: !!m.disabled, createdAt: m.createdAt }; }
  team() { return this.#members().map((m) => this.publicMember(m)); }
  member(id) { const m = this.#members().find((x) => x.id === id && !x.disabled); return m ? { id: m.id, name: m.name, role: m.role } : null; }

  addMember(actor, { name, role, password }) {
    need(actor, 'team', 'add people to the team');
    if (!name || !String(name).trim()) throw new StudioError('Please type the person\'s name.');
    if (!ROLES.some((r) => r.id === role)) throw new StudioError('Please choose a role.');
    const bad = checkPassword(password); if (bad) throw new StudioError(bad);
    const members = this.#members();
    if (members.some((m) => !m.disabled && m.name.toLowerCase() === String(name).trim().toLowerCase())) throw new StudioError('Someone with that name is already in the team.', 409);
    const m = { id: 'm-' + randomBytes(4).toString('hex'), name: String(name).trim().slice(0, 60), role, createdAt: stamp(), disabled: false, ...hashPassword(password) };
    this.#saveMembers([...members, m]);
    this.log(actor, 'team.added', null, `${m.name} (${role})`);
    return this.publicMember(m);
  }

  changeRole(actor, id, role) {
    need(actor, 'team', 'change roles');
    if (!ROLES.some((r) => r.id === role)) throw new StudioError('Please choose a role.');
    const members = this.#members();
    const m = members.find((x) => x.id === id);
    if (!m) throw new StudioError('That person is not in the team.', 404);
    if (m.role === 'admin' && role !== 'admin' && members.filter((x) => x.role === 'admin' && !x.disabled).length < 2) throw new StudioError('There must always be one administrator.', 409);
    m.role = role;
    this.#saveMembers(members);
    this.log(actor, 'team.role', null, `${m.name} is now ${role}`);
    return this.publicMember(m);
  }

  setPassword(actor, id, password) {
    if (!actor || (actor.id !== id && !can(actor, 'team'))) throw new StudioError('Only you or an administrator can change this password.', 403, 'role');
    const bad = checkPassword(password); if (bad) throw new StudioError(bad);
    const members = this.#members();
    const m = members.find((x) => x.id === id);
    if (!m) throw new StudioError('That person is not in the team.', 404);
    Object.assign(m, hashPassword(password));
    this.#saveMembers(members);
    this.log(actor, 'team.password', null, `${m.name}'s password was changed`);
  }

  setActive(actor, id, active) {
    need(actor, 'team', 'switch people on or off');
    const members = this.#members();
    const m = members.find((x) => x.id === id);
    if (!m) throw new StudioError('That person is not in the team.', 404);
    if (!active && m.role === 'admin' && members.filter((x) => x.role === 'admin' && !x.disabled).length < 2) throw new StudioError('There must always be one administrator.', 409);
    m.disabled = !active;
    this.#saveMembers(members);
    this.log(actor, active ? 'team.on' : 'team.off', null, m.name);
  }

  /** Signs a person in. Five wrong tries lock that person for a minute. Returns the member, or throws in plain words. */
  signIn(id, password) {
    const f = this.failures.get(id) ?? { count: 0, until: 0 };
    if (f.until > Date.now()) throw new StudioError('Too many tries. Please wait a minute and try again.', 429, 'locked');
    const m = this.#members().find((x) => x.id === id && !x.disabled);
    // The same work is done whether or not the person exists, so the time taken does not say.
    const ok = m ? passwordMatches(String(password ?? ''), m) : (scryptSync(String(password ?? ''), Buffer.alloc(16), 32), false);
    if (!ok) {
      f.count += 1;
      if (f.count >= 5) { f.until = Date.now() + 60_000; f.count = 0; }
      this.failures.set(id, f);
      if (m) this.log(person(m), 'signin.failed', null, 'Wrong password');
      throw new StudioError('That password is not right.', 401, 'password');
    }
    this.failures.delete(id);
    this.log(person(m), 'signin', null, 'Signed in');
    return { id: m.id, name: m.name, role: m.role };
  }

  // ---- the activity record ------------------------------------------------------------------------------------------------------------

  /** Writes one line to the activity record. Each line holds the fingerprint of the one before, so a line changed or removed later shows up (verifyAudit). */
  log(actor, action, customer, detail) {
    const file = join(this.folder, 'audit.jsonl');
    withLock(join(this.folder, 'audit.lock'), () => {
      const lines = existsSync(file) ? readFileSync(file, 'utf8').split('\n').filter(Boolean) : [];
      const last = lines.length ? JSON.parse(lines[lines.length - 1]) : null;
      const entry = { n: (last?.n ?? 0) + 1, at: stamp(), who: actor ? { id: actor.id, name: actor.name, role: actor.role } : null, action, customer: customer ?? null, detail: String(detail ?? '').slice(0, 500), prev: last?.hash ?? '0'.repeat(64) };
      entry.hash = sha256(canonical(entry));
      appendFileSync(file, JSON.stringify(entry) + '\n');
    });
  }

  audit({ customer = null, limit = 200 } = {}) {
    const file = join(this.folder, 'audit.jsonl');
    if (!existsSync(file)) return [];
    const all = readFileSync(file, 'utf8').split('\n').filter(Boolean).map((l) => JSON.parse(l));
    return all.filter((e) => !customer || e.customer === customer).slice(-limit).reverse();
  }

  verifyAudit() {
    const file = join(this.folder, 'audit.jsonl');
    if (!existsSync(file)) return { ok: true, count: 0 };
    let prev = '0'.repeat(64);
    let n = 0;
    for (const line of readFileSync(file, 'utf8').split('\n').filter(Boolean)) {
      let e;
      try { e = JSON.parse(line); } catch { return { ok: false, count: n, brokenAt: n + 1, why: 'A line cannot be read.' }; }
      const { hash, ...rest } = e;
      if (e.prev !== prev || sha256(canonical(rest)) !== hash || e.n !== n + 1) return { ok: false, count: n, brokenAt: e.n ?? n + 1, why: 'A line was changed, removed or added by hand.' };
      prev = hash; n += 1;
    }
    return { ok: true, count: n };
  }

  // ---- customers -----------------------------------------------------------------------------------------------------------------------

  #dir(id) { if (!SLUG.test(id || '')) throw new StudioError('That is not a customer name this Studio knows.', 404, 'missing'); return inside(this.folder, 'customers', id); }
  #meta(id) { const m = readJson(join(this.#dir(id), 'customer.json')); if (!m) throw new StudioError('That customer was not found.', 404, 'missing'); return m; }
  #saveMeta(id, meta, actor) { meta.rev = (meta.rev ?? 0) + 1; meta.updatedAt = stamp(); meta.updatedBy = person(actor); writeJson(join(this.#dir(id), 'customer.json'), meta); }
  #intake(id) { return readJson(join(this.#dir(id), 'intake.json'), blankIntake()); }
  #proposal(id) { return readJson(join(this.#dir(id), 'proposal.json')); }

  ids() { const dir = join(this.folder, 'customers'); return existsSync(dir) ? readdirSync(dir, { withFileTypes: true }).filter((e) => e.isDirectory() && SLUG.test(e.name) && existsSync(join(dir, e.name, 'customer.json'))).map((e) => e.name).sort() : []; }

  releaseNumbers(id) {
    const dir = join(this.#dir(id), 'releases');
    return existsSync(dir) ? readdirSync(dir).filter((n) => /^\d+$/.test(n)).map(Number).sort((a, b) => a - b) : [];
  }

  summary(id) {
    const meta = this.#meta(id);
    const intake = this.#intake(id);
    const checked = checkIntake(intake);
    return {
      id, name: intake.business?.name || id, country: intake.business?.country, industry: intake.business?.industry, os: intake.device?.os, device: intake.device?.kind,
      state: meta.state, stale: !!meta.stale, complete: checked.complete, createdAt: meta.createdAt, updatedAt: meta.updatedAt, updatedBy: meta.updatedBy, preparedBy: meta.preparedBy ?? null,
      latestRelease: this.releaseNumbers(id).at(-1) ?? null, rev: meta.rev,
    };
  }

  list() { return this.ids().map((id) => this.summary(id)).sort((a, b) => String(b.updatedAt).localeCompare(String(a.updatedAt))); }

  /** Everything about a customer, for its page. */
  get(id) {
    const meta = this.#meta(id);
    const intake = this.#intake(id);
    const checked = checkIntake(intake);
    return {
      ...this.summary(id), intake: checked.value, check: { errors: checked.errors, warnings: checked.warnings, complete: checked.complete },
      proposal: this.#proposal(id), review: meta.review ?? null, rejection: meta.rejection ?? null, delivered: meta.delivered ?? null,
      releases: this.releaseNumbers(id).map((n) => this.release(id, n).info), builds: meta.builds ?? [], hasLogo: !!this.logo(id),
    };
  }

  create(actor, input) {
    need(actor, 'customer.edit', 'add customers');
    const checked = checkIntake(input);
    if (!checked.value.business.name) throw new StudioError('Please type the name of the business.', 400, 'invalid', checked.errors);
    const id = slugFor(checked.value.business.name, this.ids());
    const dir = this.#dir(id);
    mkdirSync(dir, { recursive: true });
    writeJson(join(dir, 'intake.json'), checked.value);
    const meta = { schema: 1, id, state: 'draft', rev: 0, createdAt: stamp(), createdBy: person(actor), review: null };
    this.#saveMeta(id, meta, actor);
    this.log(actor, 'customer.created', id, checked.value.business.name);
    return this.get(id);
  }

  /**
   * Saves what was written about a customer. A half-filled intake can be saved; a setup cannot be prepared until it is complete. Changing the details of a customer
   * whose setup was prepared, submitted or approved starts a new round: the old proposal is kept but marked as out of date, and an approved release stays as it is.
   */
  saveIntake(actor, id, input, { ifRev } = {}) {
    need(actor, 'customer.edit', 'change a customer\'s details');
    const meta = this.#meta(id);
    if (ifRev !== undefined && ifRev !== meta.rev) throw new StudioError('Someone else changed this customer while you were editing. Please reload the page and make your change again.', 409, 'conflict');
    const before = this.#intake(id);
    const checked = checkIntake({ ...input, look: { ...input?.look, logo: input?.look?.logo ?? before.look?.logo ?? null }, starter: input?.starter ?? before.starter });
    if (!checked.value.business.name) throw new StudioError('Please type the name of the business.', 400, 'invalid', checked.errors);
    const changed = canonical(before) !== canonical(checked.value);
    if (changed) {
      writeJson(join(this.#dir(id), 'intake.json'), checked.value);
      if (['proposed', 'review', 'approved', 'built', 'delivered'].includes(meta.state)) { meta.state = 'draft'; meta.stale = true; meta.review = null; }
      this.#saveMeta(id, meta, actor);
      this.log(actor, 'customer.changed', id, 'Details changed' + (meta.stale ? ' (the prepared setup is out of date)' : ''));
    }
    return this.get(id);
  }

  setLogo(actor, id, bytes) {
    need(actor, 'customer.edit', 'change a customer\'s logo');
    const meta = this.#meta(id);
    const info = inspectPicture(bytes);
    if (info.problem) throw new StudioError(info.problem);
    const dir = this.#dir(id);
    for (const ext of ['png', 'jpg', 'svg']) rmSync(join(dir, `logo.${ext}`), { force: true });
    const name = `logo.${info.ext}`;
    writeAtomic(join(dir, name), bytes);
    const intake = this.#intake(id);
    intake.look = { ...intake.look, logo: name };
    writeJson(join(dir, 'intake.json'), intake);
    if (['proposed', 'review', 'approved', 'built', 'delivered'].includes(meta.state)) { meta.state = 'draft'; meta.stale = true; meta.review = null; }
    this.#saveMeta(id, meta, actor);
    this.log(actor, 'customer.logo', id, `Logo set (${info.kind}, ${Math.round(bytes.length / 1000)} KB)`);
    return this.get(id);
  }

  logo(id) {
    const dir = this.#dir(id);
    for (const [ext, type] of [['png', 'image/png'], ['jpg', 'image/jpeg'], ['svg', 'image/svg+xml']]) {
      const file = join(dir, `logo.${ext}`);
      if (existsSync(file)) return { bytes: readFileSync(file), type, ext };
    }
    return null;
  }

  /** The logo as a data address for the Hub, or null (the Hub only takes a PNG or JPEG of at most 100 KB). */
  logoUri(id) {
    const l = this.logo(id);
    if (!l || l.ext === 'svg') return null;
    const uri = `data:${l.type};base64,${l.bytes.toString('base64')}`;
    return logoProblem(uri) ? null : uri;
  }

  // ---- the proposal and the approval -------------------------------------------------------------------------------------------------

  /** Makes the first proposal from the details, by plain rules. */
  makeProposal(actor, id) {
    need(actor, 'proposal.edit', 'prepare a setup');
    const meta = this.#meta(id);
    if (meta.state === 'review') throw new StudioError('This setup is waiting for approval. Ask the reviewer to send it back first.', 409);
    const result = propose(this.#intake(id), { logoUri: this.logoUri(id) });
    if (!result.ok) throw new StudioError('The details are not complete yet.', 400, 'incomplete', result.errors);
    return this.#store(actor, id, meta, result.proposal, 'template', 'Prepared from the details');
  }

  /**
   * Keeps a proposal that came from somewhere else (an AI tool, or a person's edit). Whatever it says, it is read again through the same rules as the Hub's; the customer's own
   * name, country, kind of business, contact and look are put back from the details; what could not be used is named. Returns the stored proposal.
   */
  saveProposal(actor, id, candidate, { source = 'edited', note = '' } = {}) {
    need(actor, 'proposal.edit', 'change a setup');
    const meta = this.#meta(id);
    if (meta.state === 'review') throw new StudioError('This setup is waiting for approval. Ask the reviewer to send it back first.', 409);
    const intake = checkIntake(this.#intake(id));
    if (!intake.complete) throw new StudioError('The details are not complete yet.', 400, 'incomplete', intake.errors);
    const base = propose(intake.value, { logoUri: this.logoUri(id) }).proposal;
    const r = reconcile(base, candidate);
    if (!r.ok) throw new StudioError(r.error, 400, 'invalid');
    const proposal = r.proposal;
    return this.#store(actor, id, meta, proposal, source, note || 'Setup changed');
  }

  #store(actor, id, meta, proposal, source, note) {
    const stored = { ...proposal, source, preparedBy: person(actor), preparedAt: stamp(), note };
    stored.hash = sha256(canonical({ setup: stored.setup, theme: stored.theme, brand: stored.brand }));
    writeJson(join(this.#dir(id), 'proposal.json'), stored);
    meta.state = 'proposed'; meta.stale = false; meta.review = null; meta.rejection = null; meta.preparedBy = person(actor);
    this.#saveMeta(id, meta, actor);
    this.log(actor, 'proposal.saved', id, `${note} (${source})${stored.problems.length ? `; ${stored.problems.length} thing(s) could not be used` : ''}`);
    return this.get(id);
  }

  submit(actor, id) {
    need(actor, 'review.submit', 'send a setup for approval');
    const meta = this.#meta(id);
    const proposal = this.#proposal(id);
    if (meta.state !== 'proposed' || !proposal) throw new StudioError('Prepare the setup first, then send it for approval.', 409);
    meta.state = 'review';
    meta.review = { submittedBy: person(actor), submittedAt: stamp(), hash: proposal.hash };
    meta.rejection = null;
    this.#saveMeta(id, meta, actor);
    this.log(actor, 'review.submitted', id, 'Sent for approval');
    return this.get(id);
  }

  reject(actor, id, reason) {
    need(actor, 'review.decide', 'send a setup back');
    const meta = this.#meta(id);
    if (meta.state !== 'review') throw new StudioError('This setup is not waiting for approval.', 409);
    const why = String(reason ?? '').trim();
    if (why.length < 3) throw new StudioError('Please say, in a few words, what to change.');
    meta.state = 'proposed';
    meta.rejection = { by: person(actor), at: stamp(), reason: why.slice(0, 500) };
    meta.review = null;
    this.#saveMeta(id, meta, actor);
    this.log(actor, 'review.rejected', id, why.slice(0, 200));
    return this.get(id);
  }

  /**
   * Approves the setup that is waiting. A second person must do it: whoever prepared or sent it cannot approve it. (An administrator may approve their own work, but only by giving
   * a reason, and that is written in the activity record.) Approval makes a numbered release that never changes; installers are made from a release.
   */
  approve(actor, id, { overrideReason } = {}) {
    need(actor, 'review.decide', 'approve a setup');
    const meta = this.#meta(id);
    const proposal = this.#proposal(id);
    if (meta.state !== 'review' || !proposal || meta.review?.hash !== proposal.hash) throw new StudioError('This setup is not waiting for approval (or it changed after it was sent).', 409);
    const intake = checkIntake(this.#intake(id));
    if (!intake.complete) throw new StudioError('The details are not complete.', 400, 'incomplete', intake.errors);
    const same = [proposal.preparedBy?.id, meta.review.submittedBy?.id].includes(actor.id);
    let detail = 'Approved';
    if (same) {
      const reason = String(overrideReason ?? '').trim();
      if (!can(actor, 'override')) throw new StudioError('You prepared or sent this setup, so someone else must approve it.', 403, 'same-person');
      if (reason.length < 10) throw new StudioError('You prepared this setup yourself. To approve it anyway, say why in at least a few words.', 403, 'same-person');
      detail = `Approved by the person who prepared it. Reason: ${reason.slice(0, 300)}`;
    }
    const n = (this.releaseNumbers(id).at(-1) ?? 0) + 1;
    const dir = join(this.#dir(id), 'releases', String(n));
    mkdirSync(dir, { recursive: true });
    const files = {};
    const put = (name, data) => { const path = join(dir, name); writeAtomic(path, data); makeReadOnly(path); files[name] = sha256(data); };
    put('setup.json', JSON.stringify(proposal.setup, null, 2) + '\n');
    put('theme.json', JSON.stringify(proposal.theme, null, 2) + '\n');
    put('brand.json', JSON.stringify(proposal.brand, null, 2) + '\n');
    const snapshot = intake.value;
    put('intake.json', JSON.stringify(snapshot, null, 2) + '\n');
    const logo = this.logo(id);
    if (logo) put(`logo.${logo.ext}`, logo.bytes);
    const info = {
      schema: 1, n, customerId: id, customerName: snapshot.business.name, approvedAt: stamp(), approvedBy: person(actor), preparedBy: proposal.preparedBy, submittedBy: meta.review.submittedBy,
      source: proposal.source, selfApproved: same, whiteLabel: snapshot.licence.whiteLabel, os: snapshot.device.os, device: snapshot.device.kind, files,
    };
    info.bundleHash = sha256(canonical(files));
    writeAtomic(join(dir, 'release.json'), JSON.stringify(info, null, 2) + '\n'); makeReadOnly(join(dir, 'release.json'));
    meta.state = 'approved'; meta.review = null; meta.stale = false;
    this.#saveMeta(id, meta, actor);
    this.log(actor, 'release.approved', id, `Release ${n}. ${detail}`);
    return this.get(id);
  }

  release(id, n) {
    const dir = inside(this.#dir(id), 'releases', String(Number(n)));
    const info = readJson(join(dir, 'release.json'));
    if (!info) throw new StudioError('That release was not found.', 404, 'missing');
    return { info, dir };
  }

  /** Reads a release back and says whether every file is still exactly what was approved. */
  verifyRelease(id, n) {
    const { info, dir } = this.release(id, n);
    const problems = [];
    for (const [name, hash] of Object.entries(info.files)) {
      const path = join(dir, name);
      if (!existsSync(path)) problems.push(`${name} is missing`);
      else if (sha256(readFileSync(path)) !== hash) problems.push(`${name} was changed after it was approved`);
    }
    if (sha256(canonical(info.files)) !== info.bundleHash) problems.push('the list of files was changed after it was approved');
    return { ok: problems.length === 0, problems };
  }

  /** The profile folder for a release: exactly the three files the Hub reads (profile/setup.json, theme.json, brand.json). Never anything else. */
  profileFiles(id, n) {
    const verified = this.verifyRelease(id, n);
    if (!verified.ok) throw new StudioError('This release does not match what was approved: ' + verified.problems.join('; '), 409, 'tampered');
    const { dir } = this.release(id, n);
    return ['setup.json', 'theme.json', 'brand.json'].map((name) => ({ name: 'profile/' + name, data: readFileSync(join(dir, name)) }));
  }

  /** An approved release read back and checked, with everything a customer pack is made from: its record, its details, its profile files and its logo. */
  releaseParts(id, n) {
    const verified = this.verifyRelease(id, n);
    if (!verified.ok) throw new StudioError('This release does not match what was approved: ' + verified.problems.join('; '), 409, 'tampered');
    const { info, dir } = this.release(id, n);
    const files = {};
    for (const name of ['setup.json', 'theme.json', 'brand.json']) files[name] = readFileSync(join(dir, name));
    const intake = JSON.parse(readFileSync(join(dir, 'intake.json'), 'utf8'));
    const logoName = Object.keys(info.files).find((f) => /^logo\.(png|jpg|jpeg|svg)$/.test(f));
    return { info, intake, files, logo: logoName ? { ext: logoName.split('.').pop(), bytes: readFileSync(join(dir, logoName)) } : null };
  }

  recordBuild(actor, id, build) {
    need(actor, 'build', 'make installers');
    const meta = this.#meta(id);
    if (!this.releaseNumbers(id).includes(build.release)) throw new StudioError('Make installers from an approved release.', 409);
    meta.builds = [...(meta.builds ?? []), { ...build, at: stamp(), by: person(actor) }].slice(-50);
    if (meta.state === 'approved') meta.state = 'built';
    this.#saveMeta(id, meta, actor);
    this.log(actor, 'build.made', id, `${build.kind ?? 'installer'} from release ${build.release}`);
  }

  deliver(actor, id, note) {
    need(actor, 'deliver', 'record a hand-over');
    const meta = this.#meta(id);
    if (!['approved', 'built'].includes(meta.state)) throw new StudioError('Only an approved setup can be handed over.', 409);
    meta.state = 'delivered';
    meta.delivered = { at: stamp(), by: person(actor), note: String(note ?? '').slice(0, 500) };
    this.#saveMeta(id, meta, actor);
    this.log(actor, 'customer.delivered', id, String(note ?? '').slice(0, 200));
    return this.get(id);
  }

  buildsFolder(id, n) { return inside(this.folder, 'builds', id, String(Number(n))); }

  // ---- safe keeping ---------------------------------------------------------------------------------------------------------------------

  /** One zip file with everything in the workspace except old backups and built installers (those can be made again). */
  backup(actor) {
    need(actor, 'backup', 'make a backup');
    const entries = [];
    for (const name of ['studio.json', 'team.json', 'audit.jsonl']) if (existsSync(join(this.folder, name))) entries.push({ name, data: readFileSync(join(this.folder, name)) });
    if (existsSync(join(this.folder, 'customers'))) entries.push(...entriesOf(join(this.folder, 'customers'), 'customers'));
    const dir = join(this.folder, 'backups');
    mkdirSync(dir, { recursive: true });
    const file = join(dir, `studio-${stamp().replace(/[:.]/g, '-').slice(0, 19)}.zip`);
    writeFileSync(file, makeZip(entries));
    this.log(actor, 'backup.made', null, basename(file));
    return { file, files: entries.length };
  }
}

/** Looks into a picture's first bytes (never its name): PNG, JPEG or a plain SVG. */
export function inspectPicture(bytes) {
  if (!Buffer.isBuffer(bytes) || bytes.length === 0) return { problem: 'That file is empty.' };
  if (bytes.length > 1_000_000) return { problem: 'The logo is too big. Use a picture under 1 MB.' };
  const png = bytes.length > 8 && bytes[0] === 0x89 && bytes[1] === 0x50 && bytes[2] === 0x4e && bytes[3] === 0x47;
  const jpeg = bytes.length > 3 && bytes[0] === 0xff && bytes[1] === 0xd8 && bytes[2] === 0xff;
  if (png) return { kind: 'png', ext: 'png' };
  if (jpeg) return { kind: 'jpeg', ext: 'jpg' };
  const text = bytes.subarray(0, 400_000).toString('utf8');
  if (/^\s*(<\?xml[^>]*>\s*)?(<!--[\s\S]*?-->\s*)?<svg[\s>]/i.test(text)) {
    if (/<script|<foreignObject|<iframe|<embed|<object|<!ENTITY|javascript:|\son[a-z]+\s*=|(?:xlink:)?href\s*=\s*["']\s*(?!#|data:image\/)/i.test(text)) return { problem: 'This SVG picture holds scripts or links to other places. Export it again as a plain picture, or use a PNG.' };
    return { kind: 'svg', ext: 'svg' };
  }
  return { problem: 'The logo must be a PNG, JPEG or SVG picture.' };
}
