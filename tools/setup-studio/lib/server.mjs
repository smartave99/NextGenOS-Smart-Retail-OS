// The Studio's local server: a web page for NextGenOS staff, on this PC only (127.0.0.1), opened with an address that holds a secret that is new every time it starts. It adds
// no power of its own: every action goes through the workspace (roles, approval, the activity record) and the AI tools (checked, never trusted).
import http from 'node:http';
import { randomBytes, timingSafeEqual } from 'node:crypto';
import { readFileSync, existsSync, mkdirSync, createReadStream, statSync } from 'node:fs';
import { join, resolve, dirname, extname, basename } from 'node:path';
import { fileURLToPath } from 'node:url';
import { homedir } from 'node:os';
import { Workspace, StudioError, ROLES, can } from './workspace.mjs';
import { OPTIONS, checkIntake } from './intake.mjs';
import { countries, industries } from './packs.mjs';
import { propose, reconcile } from './template.mjs';
import { diffProposals } from './diff.mjs';
import { importList } from './csv.mjs';
import { previewInput, previewHtml, brandCss, readAsset } from './preview.mjs';
import { makeZip } from './zip.mjs';
import { readBaseKit } from './basekit.mjs';
import { buildPack, planPack, PackError } from './pack.mjs';
import { handoverFor } from './handover.mjs';
import { inside } from './fsx.mjs';
import { askForProposal, preview as aiPreview, describeTools, ADAPTERS, AiError } from './ai/index.mjs';
import { toolStatus, listModels, checkUpdate, updateTool, updateHow } from './ai/control.mjs';
import { cleanToolConfig, EFFORTS } from './ai/options.mjs';
import { keyStatus, saveKey, removeKey, PROVIDERS, BUILD_CODES, saveBuildCode, removeBuildCode } from './secrets.mjs';
import { createBuildService, withSiteBuilds } from './builds.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const UI = resolve(here, '..', 'ui');
const TYPES = { '.html': 'text/html; charset=utf-8', '.css': 'text/css; charset=utf-8', '.js': 'text/javascript; charset=utf-8', '.svg': 'image/svg+xml', '.png': 'image/png', '.json': 'application/json; charset=utf-8' };
const IDLE_MS = 60 * 60 * 1000;
const MAX_MS = 12 * 60 * 60 * 1000;

export function defaultWorkspaceFolder(env = process.env) {
  if (env.SETUP_STUDIO_WORKSPACE) return resolve(env.SETUP_STUDIO_WORKSPACE);
  const docs = join(homedir(), 'Documents');
  return join(existsSync(docs) ? docs : homedir(), 'NextGenOS Setup Studio');
}

const CSP = "default-src 'none'; script-src 'self'; style-src 'self'; img-src 'self' data:; font-src 'self'; connect-src 'self'; frame-src 'self'; base-uri 'none'; form-action 'none'; frame-ancestors 'none'";
const PREVIEW_CSP = "default-src 'none'; style-src 'self'; img-src 'self' data:; font-src 'self'; base-uri 'none'; form-action 'none'; frame-ancestors 'self'";

/**
 * Starts the Studio. Returns { server, url, token, close, state }. `folder` is the workspace folder (made at first use). `build` is for tests only: it points the build service
 * client at a stand-in on this PC (addresses, how often to look); the real Studio always talks to the one real address.
 */
export async function startStudio({ folder = defaultWorkspaceFolder(), port = 0, env = process.env, onBeat = null, onQuit = null, build = {} } = {}) {
  const hooks = { beat: onBeat, quit: onQuit };
  const token = randomBytes(18).toString('base64url');
  const tokenBuf = Buffer.from(token);
  const state = { ws: Workspace.exists(folder) ? Workspace.open(folder) : null, folder, sessions: new Map(), aiRunning: new Set(), builds: null };
  const studioVersion = () => JSON.parse(readFileSync(resolve(here, '..', 'package.json'), 'utf8')).version;
  /** The build service (made when first needed, because the workspace may only be made after the Studio has started). */
  const builds = () => (state.builds ??= createBuildService({ ws: state.ws, env, studioVersion: studioVersion(), ...build }));
  const checkKey = (given) => { const g = Buffer.from(String(given ?? '')); return g.length === tokenBuf.length && timingSafeEqual(g, tokenBuf); };

  const send = (res, status, body, type = 'application/json; charset=utf-8', extra = {}) => {
    res.writeHead(status, { 'Content-Type': type, 'Cache-Control': 'no-store', 'X-Content-Type-Options': 'nosniff', 'Referrer-Policy': 'no-referrer', 'Cross-Origin-Resource-Policy': 'same-origin', 'Content-Security-Policy': CSP, ...extra });
    res.end(typeof body === 'string' || Buffer.isBuffer(body) ? body : JSON.stringify(body));
  };
  const readBody = (req, limit) => new Promise((resolveBody, reject) => {
    const chunks = []; let size = 0;
    req.on('data', (c) => { size += c.length; if (size > limit) { reject(new StudioError('That is too much to send at once.', 413)); req.destroy(); } else chunks.push(c); });
    req.on('end', () => { try { resolveBody(chunks.length ? JSON.parse(Buffer.concat(chunks).toString('utf8')) : {}); } catch { reject(new StudioError('That was not understood.')); } });
    req.on('error', reject);
  });

  const sessionOf = (req) => {
    const id = req.headers['x-studio-session'];
    const s = id && state.sessions.get(String(id));
    if (!s) return null;
    const now = Date.now();
    if (now - s.last > IDLE_MS || now - s.started > MAX_MS) { state.sessions.delete(String(id)); return null; }
    s.last = now;
    // The role is looked up each time: a change of role or switching someone off takes effect at once.
    const member = state.ws?.member(s.member.id);
    if (!member) { state.sessions.delete(String(id)); return null; }
    return { id: String(id), member };
  };

  const routes = [];
  const route = (method, pattern, options, handler) => routes.push({ method, re: new RegExp('^' + pattern.replace(/[.+*?^${}()|[\]\\]/g, '\\$&').replace(/:([a-z]+)/g, '([^/]+)') + '$'), names: [...pattern.matchAll(/:([a-z]+)/g)].map((m) => m[1]), options, handler });

  // ---- before sign-in ------------------------------------------------------------------------------------------------------------------
  const teamPublic = () => (state.ws ? state.ws.team().filter((m) => !m.disabled).map((m) => ({ id: m.id, name: m.name, role: m.role, initials: m.initials })) : []);
  route('GET', '/api/state', { open: true }, () => ({ initialised: !!state.ws, folder: state.folder, team: teamPublic(), roles: ROLES, version: JSON.parse(readFileSync(resolve(here, '..', 'package.json'), 'utf8')).version }));
  // The page says it is still open (so a Studio that nobody is looking at can stop by itself), and the person can quit it from the page.
  route('GET', '/api/alive', { open: true }, () => { hooks.beat?.(); return { ok: true }; });
  route('POST', '/api/quit', { open: true, limit: 1000 }, () => {
    if (!hooks.quit) throw new StudioError('This Studio is stopped by closing the window or the terminal it was started from.', 409);
    if (state.aiRunning.size) throw new StudioError('The AI is still working on something. Wait until it has finished, then quit.', 409);
    setTimeout(() => hooks.quit(), 200);
    return { ok: true };
  });
  route('POST', '/api/setup', { open: true, limit: 20_000 }, ({ body }) => {
    if (state.ws) throw new StudioError('This Studio is already set up. Sign in instead.', 409);
    const chosen = body.folder ? resolve(String(body.folder)) : state.folder;
    mkdirSync(dirname(chosen), { recursive: true });
    const { workspace, admin } = Workspace.init(chosen, { name: body.name, password: body.password });
    state.ws = workspace; state.folder = chosen;
    return signInAs(workspace.signIn(admin.id, body.password));
  });
  const signInAs = (member) => { const id = randomBytes(24).toString('base64url'); state.sessions.set(id, { member, started: Date.now(), last: Date.now() }); return { session: id, member }; };
  route('POST', '/api/signin', { open: true, limit: 5_000 }, ({ body }) => {
    if (!state.ws) throw new StudioError('This Studio is not set up yet.', 409);
    return signInAs(state.ws.signIn(String(body.id ?? ''), body.password));
  });
  route('POST', '/api/signout', { open: true }, ({ req }) => { state.sessions.delete(String(req.headers['x-studio-session'] ?? '')); return { ok: true }; });

  // ---- facts -------------------------------------------------------------------------------------------------------------------------------
  route('GET', '/api/me', {}, ({ me }) => ({ member: me, can: Object.fromEntries(['team', 'backup', 'settings', 'customer.edit', 'proposal.edit', 'review.submit', 'review.decide', 'build', 'deliver', 'override'].map((p) => [p, can(me, p)])) }));
  route('GET', '/api/options', {}, () => ({ options: OPTIONS, countries: countries(), industries: industries(), roles: ROLES, efforts: EFFORTS }));

  // ---- customers -------------------------------------------------------------------------------------------------------------------------
  route('GET', '/api/customers', {}, () => ({ customers: state.ws.list() }));
  route('POST', '/api/customers', { limit: 3_000_000 }, ({ me, body }) => ({ customer: state.ws.create(me, body.intake ?? body) }));
  route('GET', '/api/customers/:id', {}, ({ params }) => ({ customer: state.ws.get(params.id) }));
  route('PUT', '/api/customers/:id', { limit: 3_000_000 }, ({ me, params, body }) => ({ customer: state.ws.saveIntake(me, params.id, body.intake ?? {}, { ifRev: Number.isInteger(body.rev) ? body.rev : undefined }) }));
  route('PUT', '/api/customers/:id/logo', { limit: 1_900_000 }, ({ me, params, body }) => {
    const m = /^data:image\/(png|jpeg|svg\+xml);base64,([A-Za-z0-9+/=]+)$/.exec(String(body.data ?? ''));
    if (!m) throw new StudioError('The logo must be a PNG, JPEG or SVG picture.');
    return { customer: state.ws.setLogo(me, params.id, Buffer.from(m[2], 'base64')) };
  });
  route('GET', '/api/customers/:id/logo', { raw: true }, ({ params, res }) => {
    const l = state.ws.logo(params.id);
    if (!l) return send(res, 404, { error: 'No logo.' });
    // A picture is shown as a picture only: never as a page, and never with anything it holds running.
    return send(res, 200, l.bytes, l.type, { 'Content-Security-Policy': "default-src 'none'; style-src 'unsafe-inline'; sandbox" });
  });
  route('POST', '/api/import', { limit: 4_000_000 }, ({ body }) => {
    if (!['items', 'people'].includes(body.kind)) throw new StudioError('Say whether this is a list of items or of people.');
    return importList(body.kind, String(body.csv ?? ''), { industry: /^[a-z]{3,20}$/.test(body.industry ?? '') ? body.industry : 'retail' });
  });

  // ---- the proposal, the AI, review and approval -----------------------------------------------------------------------------
  route('POST', '/api/customers/:id/proposal', {}, ({ me, params }) => ({ customer: state.ws.makeProposal(me, params.id) }));
  route('PUT', '/api/customers/:id/proposal', { limit: 600_000 }, ({ me, params, body }) => ({ customer: state.ws.saveProposal(me, params.id, { setup: body.setup, theme: body.theme }, { source: 'edited', note: String(body.note ?? 'Changed by hand').slice(0, 120) }) }));
  const baseline = (id) => { const c = state.ws.get(id); const r = propose(c.intake, { logoUri: state.ws.logoUri(id) }); if (!r.ok) throw new StudioError('The details are not complete yet.', 400, 'incomplete', r.errors); return { intake: c.intake, base: r.proposal, current: c.proposal }; };
  route('POST', '/api/customers/:id/ai/preview', {}, ({ params }) => { const { intake, base } = baseline(params.id); return { preview: aiPreview(intake, base) }; });
  route('POST', '/api/customers/:id/ai/run', { limit: 10_000 }, async ({ me, params, body }) => {
    if (!can(me, 'proposal.edit')) throw new StudioError('Your role cannot prepare a setup.', 403, 'role');
    if (state.aiRunning.has(params.id)) throw new StudioError('An AI answer for this customer is already being made. Please wait for it.', 409);
    const settings = state.ws.settings().ai ?? {};
    const tool = String(body.tool ?? settings.tool ?? 'none');
    if (!ADAPTERS[tool]) throw new StudioError('Choose an AI tool in Settings first (or use the plain proposal).', 400, 'no-tool');
    const { intake, base } = baseline(params.id);
    state.aiRunning.add(params.id);
    try {
      const cfg = settings.tools ?? {};
      const timeoutMs = (cfg[tool]?.timeoutSec ?? 240) * 1000;
      const answer = await askForProposal({ tool, config: cfg, intake, baseline: base, timeoutMs, env });
      const r = reconcile(base, answer.candidate, { merge: true });
      if (!r.ok) throw new StudioError(r.error, 422, 'invalid');
      state.ws.log(me, 'ai.asked', params.id, `${tool}${answer.meta?.model ? ' ' + answer.meta.model : ''}${answer.meta?.effort ? ' (' + answer.meta.effort + ')' : ''}`);
      return { tool, meta: answer.meta, explanation: answer.explanation, proposal: r.proposal, changes: diffProposals(base, r.proposal), problems: r.proposal.problems };
    } finally { state.aiRunning.delete(params.id); }
  });
  route('POST', '/api/customers/:id/ai/accept', { limit: 600_000 }, ({ me, params, body }) => ({ customer: state.ws.saveProposal(me, params.id, { setup: body.setup, theme: body.theme }, { source: `ai:${String(body.tool ?? 'tool').slice(0, 30)}`, note: String(body.explanation ?? 'Improved by an AI tool').slice(0, 200) }) }));
  route('POST', '/api/customers/:id/submit', {}, ({ me, params }) => ({ customer: state.ws.submit(me, params.id) }));
  route('POST', '/api/customers/:id/reject', { limit: 5_000 }, ({ me, params, body }) => ({ customer: state.ws.reject(me, params.id, body.reason) }));
  route('POST', '/api/customers/:id/approve', { limit: 5_000 }, ({ me, params, body }) => ({ customer: state.ws.approve(me, params.id, { overrideReason: body.overrideReason }) }));
  route('POST', '/api/customers/:id/deliver', { limit: 5_000 }, ({ me, params, body }) => ({ customer: state.ws.deliver(me, params.id, body.note) }));
  route('GET', '/api/customers/:id/releases/:n/profile.zip', { raw: true }, ({ params, res }) => {
    const files = state.ws.profileFiles(params.id, Number(params.n));
    return send(res, 200, makeZip(files), 'application/zip', { 'Content-Disposition': `attachment; filename="${basename(params.id)}-profile-${Number(params.n)}.zip"` });
  });

  // ---- the programs folder, the customer pack, the hand-over sheet ------------------------------------------------------------------
  const programsFolder = () => String(state.ws.settings().programs?.folder ?? '');
  const kitSummary = (kit) => ({ ok: kit.ok, folder: kit.folder, version: kit.version, trial: kit.trial, signing: kit.signing, problems: kit.problems, files: kit.files.map((f) => ({ name: f.name, role: f.role, os: f.os, arch: f.arch, bytes: f.bytes })) });
  const noKit = { ok: false, folder: '', version: null, trial: false, signing: { windows: 'unknown', android: 'unknown' }, problems: [], files: [] };
  route('GET', '/api/programs', {}, async () => ({ programs: programsFolder() ? kitSummary(await readBaseKit(programsFolder())) : noKit }));
  route('PUT', '/api/programs', { limit: 5_000 }, async ({ me, body }) => {
    if (!can(me, 'settings')) throw new StudioError('Only an administrator can choose the programs folder.', 403, 'role');
    const folder = String(body.folder ?? '').trim().replace(/^["']|["']$/g, '');
    const kit = await readBaseKit(folder);
    if (!folder) { state.ws.saveSettings(me, { programs: { folder: '' } }); return { programs: noKit }; }
    if (!kit.ok) return { programs: kitSummary(kit), saved: false };
    state.ws.saveSettings(me, { programs: { folder: kit.folder } });
    return { programs: kitSummary(kit), saved: true };
  });
  const latest = (id) => state.ws.releaseNumbers(id).at(-1) ?? null;
  route('GET', '/api/customers/:id/outputs', {}, async ({ params }) => {
    const customer = state.ws.get(params.id);
    const n = latest(params.id);
    if (!n) return { release: null, programs: noKit, items: [], builds: customer.builds };
    const parts = state.ws.releaseParts(params.id, n);
    const programs = programsFolder() ? await readBaseKit(programsFolder()) : null;
    // The website and the app made for this customer from this release (by the build service) count as if they were in the programs folder.
    const kit = programs?.ok ? await withSiteBuilds(programs, { folder: state.ws.siteBuildsFolder(params.id), release: n, customerId: params.id }) : null;
    const items = kit ? planPack({ intake: parts.intake, kit, slug: params.id }).map((i) => ({ id: i.id, title: i.title, status: i.status, note: i.note, files: i.files.map((f) => f.name) })) : [];
    return { release: parts.info, programs: programs ? kitSummary(programs) : noKit, items, trial: !!kit?.trial, builds: customer.builds };
  });
  route('POST', '/api/customers/:id/outputs/pack', { limit: 2_000 }, async ({ me, params, body }) => {
    if (!can(me, 'build')) throw new StudioError('Your role cannot make installers.', 403, 'role');
    const n = latest(params.id);
    if (!n) throw new StudioError('Approve a setup first. Installers are made from an approved release.', 409);
    if (!programsFolder()) throw new StudioError('Choose the programs folder first (the files of a NextGenOS release).', 409, 'no-programs');
    const programs = await readBaseKit(programsFolder());
    if (!programs.ok) throw new StudioError('The programs folder has problems:\n' + programs.problems.join('\n'), 409, 'programs', programs.problems);
    // Every fingerprint of the website and app made for this customer is read again before they are copied into the pack.
    const kit = await withSiteBuilds(programs, { folder: state.ws.siteBuildsFolder(params.id), release: n, customerId: params.id, verify: true });
    if (kit.siteProblems.length) throw new StudioError('The website or app made for this customer cannot be used:\n' + kit.siteProblems.join('\n'), 409, 'site', kit.siteProblems);
    const parts = state.ws.releaseParts(params.id, n);
    if (state.aiRunning.has('pack:' + params.id)) throw new StudioError('A pack is already being made for this customer.', 409);
    state.aiRunning.add('pack:' + params.id);
    try {
      const out = state.ws.buildsFolder(params.id, n);
      const company = companySettings();
      let result;
      try { result = await buildPack({ customerId: params.id, parts, kit, out, company, builtBy: me.name, studioVersion: JSON.parse(readFileSync(join(here, '..', 'package.json'), 'utf8')).version, allowTrial: body.allowTrial === true }); }
      catch (e) { if (e instanceof PackError) throw new StudioError(e.message, 409, 'pack'); throw e; }
      state.ws.recordBuild(me, params.id, { kind: 'pack', release: n, programs: kit.version, trial: kit.trial, file: `${params.id}-pack-release-${n}/${result.name}`, bytes: result.bytes, sha256: result.sha256, parts: result.plan.map((p) => ({ id: p.id, status: p.status })) });
      return { build: { file: result.name, bytes: result.bytes, sha256: result.sha256, folder: result.dir }, customer: state.ws.get(params.id) };
    } finally { state.aiRunning.delete('pack:' + params.id); }
  });
  route('GET', '/api/customers/:id/builds/:n/pack.zip', { raw: true }, ({ me, params, res }) => {
    if (!can(me, 'build')) throw new StudioError('Your role cannot download installers.', 403, 'role');
    const build = [...(state.ws.get(params.id).builds ?? [])].reverse().find((b) => b.kind === 'pack' && b.release === Number(params.n));
    if (!build) throw new StudioError('No pack was made from that release yet.', 404);
    const file = inside(state.ws.buildsFolder(params.id, params.n), build.file);
    if (!existsSync(file)) throw new StudioError('The pack file is no longer there. Make it again.', 404);
    res.writeHead(200, { 'Content-Type': 'application/zip', 'Content-Length': statSync(file).size, 'Cache-Control': 'no-store', 'X-Content-Type-Options': 'nosniff', 'Content-Disposition': `attachment; filename="${basename(file)}"`, 'Content-Security-Policy': CSP });
    createReadStream(file).pipe(res);
    return undefined;
  });
  route('GET', '/api/customers/:id/handover', {}, ({ params }) => {
    const n = latest(params.id);
    if (!n) throw new StudioError('Approve a setup first.', 409);
    const parts = state.ws.releaseParts(params.id, n);
    const made = [...(state.ws.get(params.id).builds ?? [])].reverse().find((b) => b.kind === 'pack' && b.release === n);
    return { sheet: handoverFor({ intake: parts.intake, info: parts.info, company: companySettings(), pack: made ? { ai: !!made.parts?.some((p) => p.id === 'ai' && p.status === 'ready') } : null }) };
  });

  // ---- the build service: a customer's website and Android app are made off this PC, for each customer, and come back into the pack ---------
  route('GET', '/api/build-service', {}, () => ({ connection: builds().connection() }));
  route('PUT', '/api/build-service', { limit: 5_000 }, ({ me, body }) => {
    if (!can(me, 'settings')) throw new StudioError('Only an administrator can connect the build service.', 403, 'role');
    return { connection: builds().saveNames(me, body) };
  });
  route('PUT', '/api/build-service/codes/:which', { limit: 5_000 }, ({ me, params, body }) => {
    if (!can(me, 'settings')) throw new StudioError('Only an administrator can save an access code.', 403, 'role');
    try { saveBuildCode(params.which, body.code, env); } catch (e) { throw new StudioError(e.message); }
    state.ws.log(me, 'key.saved', null, `build service: ${BUILD_CODES[params.which].label.toLowerCase()}`);   // the code itself is never written anywhere but its own file
    return { connection: builds().connection() };
  });
  route('DELETE', '/api/build-service/codes/:which', {}, ({ me, params }) => {
    if (!can(me, 'settings')) throw new StudioError('Only an administrator can remove an access code.', 403, 'role');
    try { removeBuildCode(params.which, env); } catch (e) { throw new StudioError(e.message); }
    state.ws.log(me, 'key.removed', null, `build service: ${BUILD_CODES[params.which].label.toLowerCase()}`);
    return { connection: builds().connection() };
  });
  route('POST', '/api/build-service/test', { limit: 2_000 }, async ({ me }) => {
    if (!can(me, 'settings')) throw new StudioError('Only an administrator can test the connection.', 403, 'role');
    const result = await builds().testConnection();
    state.ws.log(me, 'build.service.tested', null, result.ok ? 'every check passed' : `${result.checks.filter((c) => c.ok === false).length} check(s) need attention`);
    return result;
  });
  route('GET', '/api/customers/:id/website-app', {}, ({ me, params }) => builds().status(params.id, me));
  route('POST', '/api/customers/:id/website-app/build', { limit: 2_000 }, ({ me, params, body }) => builds().start(me, params.id, { which: Array.isArray(body.parts) ? body.parts.map(String) : null }));
  route('POST', '/api/customers/:id/website-app/look', { limit: 2_000 }, ({ me, params }) => builds().look(me, params.id));

  // ---- team, record, safe keeping -------------------------------------------------------------------------------------------------
  route('GET', '/api/team', {}, () => ({ team: state.ws.team() }));
  route('POST', '/api/team', { limit: 5_000 }, ({ me, body }) => ({ member: state.ws.addMember(me, body) }));
  route('PUT', '/api/team/:id', { limit: 5_000 }, ({ me, params, body }) => {
    if (body.role !== undefined) state.ws.changeRole(me, params.id, body.role);
    if (body.active !== undefined) state.ws.setActive(me, params.id, !!body.active);
    if (body.password !== undefined) state.ws.setPassword(me, params.id, body.password);
    return { team: state.ws.team() };
  });
  route('GET', '/api/audit', {}, ({ url }) => ({ entries: state.ws.audit({ customer: url.searchParams.get('customer') || null, limit: 300 }) }));
  route('GET', '/api/audit/verify', {}, () => ({ result: state.ws.verifyAudit() }));
  route('POST', '/api/backup', {}, ({ me }) => { const b = state.ws.backup(me); return { file: b.file, files: b.files }; });

  // ---- the AI tools (settings, models and levels, updates) ----------------------------------------------------------------------
  const aiSettings = () => { const a = state.ws.settings().ai ?? {}; return { tool: a.tool ?? 'none', tools: a.tools ?? {} }; };
  const companySettings = () => { const c = state.ws.settings().company ?? {}; return { name: c.name ?? '', supportEmail: c.supportEmail ?? '', supportPhone: c.supportPhone ?? '', website: c.website ?? '' }; };
  route('GET', '/api/settings', {}, () => ({ ai: aiSettings(), company: companySettings(), keys: keyStatus(env), folder: state.folder }));
  route('PUT', '/api/company', { limit: 5_000 }, ({ me, body }) => {
    const clean = (v, max) => String(v ?? '').replace(/[\u0000-\u001f<>]/g, '').trim().slice(0, max);
    const company = { name: clean(body.name, 80), supportEmail: clean(body.supportEmail, 120), supportPhone: clean(body.supportPhone, 40), website: clean(body.website, 120) };
    if (company.supportEmail && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(company.supportEmail)) throw new StudioError('That does not look like an email address.');
    state.ws.saveSettings(me, { company });
    return { company: companySettings() };
  });
  route('PUT', '/api/settings', { limit: 60_000 }, ({ me, body }) => {
    const incoming = body.ai ?? {};
    const problems = [];
    const tools = {};
    for (const [id, cfg] of Object.entries(incoming.tools ?? {})) {
      if (!ADAPTERS[id]) continue;
      const r = cleanToolConfig(id, cfg, { knownEfforts: Array.isArray(cfg?.knownEfforts) ? cfg.knownEfforts.filter((x) => typeof x === 'string') : null });
      tools[id] = r.value;
      for (const p of r.problems) problems.push(`${ADAPTERS[id].label}: ${p}`);
    }
    if (problems.length) throw new StudioError('Some settings could not be used:\n' + problems.join('\n'), 400, 'invalid', problems);
    const tool = incoming.tool === 'none' || ADAPTERS[incoming.tool] ? incoming.tool : 'none';
    state.ws.saveSettings(me, { ai: { tool, tools } });
    return { ai: aiSettings() };
  });
  route('PUT', '/api/keys/:provider', { limit: 5_000 }, ({ me, params, body }) => {
    if (!can(me, 'settings')) throw new StudioError('Only an administrator can save a key.', 403, 'role');
    try { saveKey(params.provider, body.key, env); } catch (e) { throw new StudioError(e.message); }
    state.ws.log(me, 'key.saved', null, params.provider);   // the key itself is never written anywhere but its own file
    return { keys: keyStatus(env) };
  });
  route('DELETE', '/api/keys/:provider', {}, ({ me, params }) => {
    if (!can(me, 'settings')) throw new StudioError('Only an administrator can remove a key.', 403, 'role');
    removeKey(params.provider, env);
    state.ws.log(me, 'key.removed', null, params.provider);
    return { keys: keyStatus(env) };
  });
  route('GET', '/api/ai/tools', {}, async () => {
    const cfg = aiSettings().tools;
    const list = describeTools(cfg);
    const status = await Promise.all(list.map((t) => toolStatus(t.id, { config: cfg[t.id] ?? {}, env }).catch(() => ({ found: null }))));
    return { tools: list.map((t, i) => ({ ...t, status: status[i], efforts: EFFORTS[t.id] ?? [], how: t.kind === 'cli' ? updateHow(t.id, env) : null })), active: aiSettings().tool };
  });
  route('GET', '/api/ai/tools/:id/models', {}, async ({ params }) => { if (!ADAPTERS[params.id]) throw new StudioError('That tool is not known.', 404); return listModels(params.id, { config: aiSettings().tools[params.id] ?? {}, env }); });
  route('GET', '/api/ai/tools/:id/update', {}, async ({ params }) => { if (!ADAPTERS[params.id]) throw new StudioError('That tool is not known.', 404); return { update: await checkUpdate(params.id, { config: aiSettings().tools[params.id] ?? {}, env }) }; });
  route('POST', '/api/ai/tools/:id/update', { limit: 2_000 }, async ({ me, params, body }) => {
    if (!can(me, 'settings')) throw new StudioError('Only an administrator can update a tool.', 403, 'role');
    if (!ADAPTERS[params.id]) throw new StudioError('That tool is not known.', 404);
    if (body.confirm !== true) throw new StudioError('Please confirm the update.', 400, 'confirm');
    const how = updateHow(params.id, env);
    state.ws.log(me, 'tool.update.start', null, `${params.id}: ${how.command ?? 'manual'}`);
    try {
      const r = await updateTool(params.id, { env });
      state.ws.log(me, 'tool.update.done', null, `${params.id}: ${r.before ?? '?'} -> ${r.after ?? '?'}`);
      return { result: r };
    } catch (e) { state.ws.log(me, 'tool.update.failed', null, `${params.id}: ${String(e.message).slice(0, 150)}`); throw e; }
  });

  // ---- the preview ---------------------------------------------------------------------------------------------------------------------
  const previewParts = (url) => {
    let data = {};
    try { const raw = url.searchParams.get('d'); if (raw && raw.length < 6000) data = JSON.parse(Buffer.from(raw, 'base64url').toString('utf8')); } catch { /* an unreadable value is an empty preview */ }
    return previewInput(data);
  };
  route('GET', '/preview', { raw: true, query: true }, ({ url, res }) => {
    const p = previewParts(url);
    const k = url.searchParams.get('k');
    const d = url.searchParams.get('d') ?? '';
    const html = previewHtml(p, { cssHref: `/preview.css?k=${encodeURIComponent(k)}&d=${encodeURIComponent(d)}`, logoSrc: p.logo ? `/api/logo/${p.logo}?k=${encodeURIComponent(k)}` : null });
    return send(res, 200, html, 'text/html; charset=utf-8', { 'Content-Security-Policy': PREVIEW_CSP });
  });
  route('GET', '/preview.css', { raw: true, query: true }, ({ url, res }) => {
    const p = previewParts(url);
    return send(res, 200, p.level === 'none' ? '' : brandCss(p.primary, p.accent), 'text/css; charset=utf-8', { 'Content-Security-Policy': PREVIEW_CSP });
  });
  route('GET', '/api/logo/:id', { raw: true, query: true }, ({ params, res }) => {
    const l = state.ws?.logo(params.id);
    if (!l) return send(res, 404, { error: 'No logo.' });
    return send(res, 200, l.bytes, l.type, { 'Content-Security-Policy': "default-src 'none'; style-src 'unsafe-inline'; sandbox" });
  });

  // ---- the server --------------------------------------------------------------------------------------------------------------------
  const server = http.createServer(async (req, res) => {
    try {
      const portNow = server.address().port;
      const host = String(req.headers.host ?? '');
      if (host !== `127.0.0.1:${portNow}` && host !== `localhost:${portNow}`) return send(res, 403, { error: 'Not allowed.' });
      const url = new URL(req.url, 'http://127.0.0.1');
      const path = url.pathname;

      // The page itself and its files: the same for everyone who has the address.
      if (req.method === 'GET' && (path === '/' || path === '/index.html')) return send(res, 200, readFileSync(join(UI, 'index.html')), TYPES['.html']);
      if (req.method === 'GET' && /^\/(studio\.css|js\/(?:views\/)?[a-z0-9-]+\.js|icon\.svg)$/.test(path)) { const f = join(UI, path.slice(1)); if (existsSync(f)) return send(res, 200, readFileSync(f), TYPES[extname(f)] ?? 'application/octet-stream'); }
      if (req.method === 'GET' && (path === '/assets/hub.css' || path === '/assets/tokens.css')) { const b = readAsset(basename(path)); return b ? send(res, 200, b, TYPES['.css'], { 'Content-Security-Policy': PREVIEW_CSP }) : send(res, 404, { error: 'Not found.' }); }

      const found = routes.find((r) => r.method === req.method && r.re.test(path));
      if (!found) return send(res, path.startsWith('/api/') ? 404 : 404, { error: 'Not found.' });
      const m = found.re.exec(path);
      const params = Object.fromEntries(found.names.map((n, i) => [n, decodeURIComponent(m[i + 1])]));

      if (found.options.query) {
        // Pictures and the preview are loaded by the page itself, which cannot add a header: they carry the secret in the address.
        if (!checkKey(url.searchParams.get('k'))) return send(res, 401, { error: 'Open the Studio with the address it printed.' });
      } else {
        if (!checkKey(req.headers['x-studio-key'])) return send(res, 401, { error: 'Open the Studio with the address it printed (it ends with ?k=...).' });
        if (req.headers.origin && req.headers.origin !== `http://127.0.0.1:${portNow}` && req.headers.origin !== `http://localhost:${portNow}`) return send(res, 403, { error: 'Not allowed.' });
      }
      let me = null;
      if (!found.options.open && !found.options.query) {
        if (!state.ws) return send(res, 409, { error: 'This Studio is not set up yet.', code: 'not-setup' });
        const s = sessionOf(req);
        if (!s) return send(res, 401, { error: 'Please sign in again.', code: 'signin' });
        me = s.member;
      }
      const body = req.method === 'GET' || req.method === 'DELETE' ? {} : await readBody(req, found.options.limit ?? 1_000_000);
      const out = await found.handler({ req, res, url, params, body, me });
      if (found.options.raw) return undefined;
      return send(res, 200, out ?? { ok: true });
    } catch (e) {
      if (e instanceof StudioError) return send(res, e.status, { error: e.message, code: e.code, details: e.details });
      if (e instanceof AiError) return send(res, e.code === 'config' ? 400 : 502, { error: e.message, code: e.code });
      console.error('Studio error:', e?.stack ?? e);
      return send(res, 500, { error: 'Something went wrong in the Studio. Nothing was lost; please try again.' });
    }
  });
  await new Promise((r, j) => { server.once('error', j); server.listen(port, '127.0.0.1', r); });
  const url = `http://127.0.0.1:${server.address().port}/?k=${token}`;
  return { server, url, token, state, close: () => new Promise((r) => { state.builds?.close(); server.close(() => r()); server.closeAllConnections?.(); }) };
}
