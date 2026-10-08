// The customer page's "Make the website package" part, run without a browser: the page's own code is loaded with a very small stand-in for the page (just enough of the
// document to build and look at elements), and the Studio's answers are made up. This does not replace looking at it in a real browser (the end-to-end test does that where a
// browser exists); it catches a part that cannot be drawn, a button that says the wrong thing, and wording that claims what is not so.
import { test } from 'node:test';
import assert from 'node:assert/strict';

// ---- a very small stand-in for the page --------------------------------------------------------------------------------------------------
const realSetTimeout = globalThis.setTimeout;
globalThis.setTimeout = (fn, ms, ...rest) => { const t = realSetTimeout(fn, ms, ...rest); t.unref?.(); return t; };   // the page's fading messages must not keep the test waiting
class FakeNode { constructor() { this.children = []; this.parent = null; } }
class FakeText extends FakeNode { constructor(text) { super(); this.text = String(text); } get textContent() { return this.text; } }
class FakeElement extends FakeNode {
  constructor(tag) {
    super(); this.tag = tag; this.attrs = {}; this.listeners = {}; this.className = ''; if (tag === 'input' || tag === 'textarea') this.value = ''; this.style = { setProperty: (k, v) => { this.style[k] = v; } };
  }
  setAttribute(k, v) { this.attrs[k] = String(v); }
  getAttribute(k) { return this.attrs[k] ?? null; }
  addEventListener(type, fn) { (this.listeners[type] ??= []).push(fn); }
  append(...kids) { for (let k of kids) { if (!(k instanceof FakeNode)) k = new FakeText(k); k.parent = this; this.children.push(k); } }
  replaceChildren(...kids) { this.children = []; this.append(...kids); }
  remove() { if (this.parent) this.parent.children = this.parent.children.filter((c) => c !== this); }
  get textContent() { return this.children.map((c) => c.textContent).join(''); }
  get classList() {
    const set = () => new Set(this.className.split(/\s+/).filter(Boolean));
    return { add: (c) => { const s = set(); s.add(c); this.className = [...s].join(' '); }, remove: (c) => { const s = set(); s.delete(c); this.className = [...s].join(' '); }, contains: (c) => set().has(c) };
  }
  find(test) { for (const c of this.children) { if (c instanceof FakeElement) { if (test(c)) return c; const f = c.find(test); if (f) return f; } } return null; }
  findAll(test, out = []) { for (const c of this.children) { if (c instanceof FakeElement) { if (test(c)) out.push(c); c.findAll(test, out); } } return out; }
  querySelector(selector) { const id = /^#([\w-]+)$/.exec(selector)?.[1]; return id ? this.find((e) => e.attrs.id === id) : null; }
  async click() { for (const fn of this.listeners.click ?? []) await fn({ currentTarget: this, target: this }); }
}
const stand = new FakeElement('body');
globalThis.document = { createElement: (tag) => new FakeElement(tag), createElementNS: (_ns, tag) => new FakeElement(tag), createTextNode: (t) => new FakeText(t), body: stand, addEventListener() {}, removeEventListener() {}, activeElement: null };
globalThis.Node = FakeNode;
globalThis.sessionStorage = { getItem: () => null, setItem() {}, removeItem() {} };
globalThis.location = { search: '', pathname: '/', hash: '' };
globalThis.history = { replaceState() {} };
globalThis.window = { addEventListener() {}, print() {} };
globalThis.URL.createObjectURL ??= () => 'blob:x';

const asked = [];
let answers = {};
globalThis.fetch = async (path, options = {}) => {
  const method = options.method ?? 'GET';
  asked.push({ method, path, body: options.body ? JSON.parse(options.body) : undefined });
  const answer = answers[`${method} ${path}`];
  if (!answer) return { ok: false, status: 404, json: async () => ({ error: `nothing is set up for ${method} ${path}` }) };
  return { ok: (answer.status ?? 200) < 400, status: answer.status ?? 200, json: async () => answer.body };
};

const { render } = await import('../ui/js/views/website-package.js');
const { siteMissing, licenceWords, licenceFileProblem, SIZE } = await import('../ui/js/sitewords.js');

// ---- made-up answers -----------------------------------------------------------------------------------------------------------------------
const STATUS = '/api/customers/luzon-fresh-mart/website-package';
const LUZON = { name: 'Luzon Fresh Mart' };
const status = (over = {}) => ({
  release: 1, blockers: [], why: null, canMake: true, busy: false, siteName: 'luzonfresh.example',
  programs: { source: 'built-in', ok: true, version: '1.4.0', trial: false, problems: [] },
  systems: [{ id: 'linux', label: 'Linux', who: 'Ubuntu, Linux Mint or Debian (64-bit)', available: true, name: 'website-linux.zip' }, { id: 'windows', label: 'Windows', who: 'Windows 10 or 11 (64-bit)', available: true, name: 'website-windows.zip' }],
  licence: { state: 'none', problems: [], notes: [] }, made: [], ...over,
});
const draw = async (s, can = { build: true }) => {
  asked.length = 0;
  answers = { [`GET ${STATUS}`]: { body: s } };
  return render({ id: 'luzon-fresh-mart', customer: LUZON, can });
};
const text = (node) => node.textContent.replace(/\s+/g, ' ');
const byId = (node, id) => node.find((e) => e.attrs.id === id);

test('with the programs there and no licence yet, the page says plainly what will happen and the button is ready', async () => {
  const card = await draw(status());
  assert.match(text(card), /Make the website package/);
  assert.match(text(card), /same for every customer.*Luzon Fresh Mart's own name, colours, logo and settings.*no internet, no GitHub, nothing is built/);
  assert.match(text(byId(card, 'local-programs')), /The website program is in the programs that came with the Studio \(release 1\.4\.0\)/);
  assert.match(text(byId(card, 'local-licence')), /No licence yet: the website will not start until the licence file is added\./);
  assert.match(text(byId(card, 'local-licence')), /Licence Studio \(this Studio cannot ask for it yet\)/, 'it does not claim to ask for the licence');
  const make = byId(card, 'local-make');
  assert.equal(make.disabled, undefined);
  assert.match(text(make), /Make Luzon Fresh Mart's website package/);
  const boxes = card.findAll((e) => e.attrs['data-local-system']);
  assert.deepEqual(boxes.map((b) => [b.attrs['data-local-system'], b.checked]), [['linux', true], ['windows', true]]);
  assert.equal(byId(card, 'local-allow-trial'), null, 'no "only to try" box for a real release');
  assert.doesNotMatch(text(card), /\bnull\b|\bundefined\b|\[object|NaN/, 'no stray word of the code on the page');
});

test('pressing the button asks for the systems that are ticked, and shows what came back with its fingerprint', async () => {
  const card = await draw(status());
  const after = status({ made: [{ at: new Date().toISOString(), by: 'Rita Reviewer', release: 1, os: 'linux', label: 'Linux', name: 'website-luzon-fresh-mart-linux.zip', bytes: 3_200_000, sha256: 'ab'.repeat(32), programs: '1.4.0', trial: false, licenceIncluded: false, forThisRelease: true, replaced: false, there: true }] });
  answers[`POST ${STATUS}/make`] = { body: { ...after, results: [{ os: 'linux', name: 'website-luzon-fresh-mart-linux.zip', bytes: 3_200_000, sha256: 'ab'.repeat(32), licenceIncluded: false, trial: false, notes: [] }] } };
  const windowsBox = card.find((e) => e.attrs['data-local-system'] === 'windows');
  windowsBox.checked = false;
  for (const fn of windowsBox.listeners.change) fn({ target: windowsBox });
  const redrawn = card;   // the card redraws itself in place
  await byId(redrawn, 'local-make').click();
  assert.deepEqual(asked.filter((a) => a.method === 'POST'), [{ method: 'POST', path: `${STATUS}/make`, body: { systems: ['linux'], allowTrial: false } }]);
  const done = byId(redrawn, 'local-result');
  assert.match(text(done), /The website package is ready\./);
  assert.match(text(done), /website-luzon-fresh-mart-linux\.zip \(3 MB\)\. Fingerprint: abababababababab\./);
  assert.match(text(done), /No licence yet: the website will not start until the licence file is added\./);
  assert.match(text(byId(redrawn, 'local-made')), /Rita Reviewer.*Linux.*3 MB.*abababababababab.*Not yet/);
  assert.ok(redrawn.find((e) => e.attrs['data-download-website'] === 'linux'), 'it can be taken away from here');
});

test('a problem is shown on the page in the Studio\'s own words, every line of it, and nothing is shown as made', async () => {
  const card = await draw(status());
  answers[`POST ${STATUS}/make`] = { status: 409, body: { error: 'The website cannot be put together yet:\n  Customer folder: brand.json contains what looks like a secret (database URL with a password). A customer folder holds only public settings.', code: 'website' } };
  await byId(card, 'local-make').click();
  const problem = byId(card, 'local-problem');
  assert.match(text(problem), /The website cannot be put together yet:.*brand\.json contains what looks like a secret/);
  assert.equal(problem.attrs.role, 'alert');
  assert.equal(problem.find((e) => e.style['white-space'] === 'pre-line') !== null, true, 'the lines of the message are kept');
  assert.equal(byId(card, 'local-result'), null);
  assert.equal(byId(card, 'local-made'), null);
});

test('a salesperson sees what is there and cannot make it or put a licence file in place; the page says whose job it is', async () => {
  const card = await draw(status(), { build: false });
  assert.ok(byId(card, 'local-make').disabled);
  assert.match(text(byId(card, 'local-role-note')), /Your role cannot make it\. A reviewer or an administrator does this\./);
  assert.equal(byId(card, 'local-licence-put'), null);
  assert.match(text(byId(card, 'local-licence')), /Your role cannot put a licence file in place/);
});

test('without the website program, or without an approved setup, the button is off and the page says why', async () => {
  const none = await draw(status({ canMake: false, why: 'The programs do not hold the website program (website-linux.zip and website-windows.zip). Ask NextGenOS for the newest release.', systems: status().systems.map((s) => ({ ...s, available: false })) }));
  assert.ok(byId(none, 'local-make').disabled);
  assert.match(text(byId(none, 'local-why')), /do not hold the website program/);
  assert.match(text(byId(none, 'local-programs')), /It does not hold the website program \(website-linux\.zip, website-windows\.zip\)/);
  assert.deepEqual(none.findAll((e) => e.attrs['data-local-system']).map((b) => [b.disabled, Boolean(b.checked)]), [[true, false], [true, false]]);
  assert.match(text(none), /Linux \(not in the programs\)/);

  const early = await draw(status({ release: null, canMake: false, blockers: ['Approve a setup first. The website package is made from an approved release.'], why: 'Approve a setup first. The website package is made from an approved release.' }));
  assert.match(text(early.find((e) => 'data-local-blocker' in e.attrs)), /Approve a setup first/);
  assert.ok(byId(early, 'local-make').disabled);
  for (const part of [none, early]) assert.doesNotMatch(text(part), /\bnull\b|\bundefined\b|\[object|NaN/);

  const noPrograms = await draw(status({ canMake: false, why: 'There are no programs yet.', programs: { source: 'none', ok: false, version: null, trial: false, problems: [] }, systems: status().systems.map((s) => ({ ...s, available: false })) }));
  assert.match(text(byId(noPrograms, 'local-programs')), /There are no programs yet\. An administrator chooses the programs folder in Settings/);
});

test('a trial kit shows the "only to try" box, and what it says is sent', async () => {
  const card = await draw(status({ programs: { source: 'chosen', ok: true, version: '1.4.0', trial: true, problems: [] } }));
  assert.match(text(byId(card, 'local-programs')), /in the folder you chose.*made without licence keys and is only to try/);
  const box = byId(card, 'local-allow-trial');
  assert.ok(box);
  box.checked = true;
  answers[`POST ${STATUS}/make`] = { body: { ...status(), results: [] } };
  await byId(card, 'local-make').click();
  assert.equal(asked.find((a) => a.method === 'POST').body.allowTrial, true);
});

test('a licence file is put in place from a pasted text, and the page then says what the file says about itself', async () => {
  const card = await draw(status());
  const paste = byId(card, 'local-licence-text');
  paste.value = 'NGOS1.eyJ2IjoxfQ.' + 'A'.repeat(86);
  answers[`PUT ${STATUS}/licence`] = { body: status({ licence: { state: 'ok', fingerprint: '0123456789abcdef', problems: [], notes: [], trial: false, tiedTo: ['luzonfresh.example'], ends: null } }) };
  await byId(card, 'local-licence-put').click();
  assert.deepEqual(asked.find((a) => a.method === 'PUT').body, { text: paste.value });
  const words = text(byId(card, 'local-licence'));
  assert.match(words, /A licence file is in place \(fingerprint 0123456789abcdef\)\. It is tied to luzonfresh\.example\. It says it has no end date\. The Studio cannot check its signature: the website does that every time it starts\./);
  assert.ok(byId(card, 'local-licence-remove'), 'it can be taken away again');
  assert.doesNotMatch(words, /No licence yet/);
  // a refused file: the Studio's reason is shown
  answers[`PUT ${STATUS}/licence`] = { status: 400, body: { error: 'This file cannot be used. This licence is for Windows PCs, not for a website. Ask the Licence Studio for a website licence.' } };
  byId(card, 'local-licence-text').value = paste.value;
  await byId(card, 'local-licence-put').click();
  assert.match(text(byId(card, 'local-problem')), /This licence is for Windows PCs, not for a website/);
});

test('the words about a licence file, a file chosen on this PC, and what is still to be made for a customer', () => {
  assert.match(licenceWords(null).text, /^No licence yet: the website will not start until the licence file is added\./);
  assert.equal(licenceWords({ state: 'problem', problems: ['The licence file is empty.'] }).tone, 'warn');
  assert.equal(licenceWords({ state: 'ok', fingerprint: 'f', tiedTo: [], ends: '2027-01-31', trial: false }).tone, 'ok');
  assert.match(licenceWords({ state: 'ok', fingerprint: 'f', tiedTo: [], ends: '2027-01-31', trial: false }).text, /It says it ends on 2027-01-31\./);
  assert.equal(licenceWords({ state: 'ok', fingerprint: 'f', tiedTo: [], ends: null, trial: true }).tone, 'warn', 'a trial licence is a warning');
  assert.equal(licenceFileProblem(null), 'Choose the licence file first.');
  assert.match(licenceFileProblem({ size: 0 }), /empty/);
  assert.match(licenceFileProblem({ size: 50_000 }), /too big/);
  assert.equal(licenceFileProblem({ size: 900 }), null);
  assert.equal(SIZE(3_200_000), '3 MB');
  assert.equal(SIZE(1_500_000_000), '1.5 GB');

  const customer = (builds, eco = {}) => ({ releases: [{ n: 2 }], builds, intake: { ecosystem: { website: { wanted: true, domain: 'luzon.example' }, android: { wanted: true }, ...eco } } });
  assert.deepEqual(siteMissing(customer([])), { website: true, android: true });
  assert.deepEqual(siteMissing(customer([{ kind: 'website-local', release: 2, os: 'linux' }])), { website: false, android: true }, 'a website package made on this PC counts');
  assert.deepEqual(siteMissing(customer([{ kind: 'website-local', release: 1, os: 'linux' }])), { website: true, android: true }, 'one made from an older approval does not');
  assert.deepEqual(siteMissing(customer([{ kind: 'website-app', release: 2, parts: [{ id: 'website-linux', status: 'success' }] }])), { website: true, android: true }, 'the build service needs both systems, as before');
  assert.deepEqual(siteMissing(customer([{ kind: 'website-app', release: 2, parts: [{ id: 'website-linux', status: 'success' }, { id: 'website-windows', status: 'success' }, { id: 'android', status: 'success' }] }])), { website: false, android: false });
  assert.deepEqual(siteMissing(customer([], { website: { wanted: false, domain: '' }, android: { wanted: false } })), { website: false, android: false });
});
