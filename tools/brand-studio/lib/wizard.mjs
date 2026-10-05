// The Brand Studio's page: a form on the left, the result on the right. Served by lib/server.mjs; no framework, no outside file.

export const WIZARD_HTML = `<!doctype html>
<html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1">
<title>Brand Studio</title><link rel="stylesheet" href="/wizard.css"></head>
<body>
<header class="top"><div><strong>Brand Studio</strong> <span class="muted">by NextGenOS</span></div><div id="kits" class="kits"></div></header>
<main class="grid">
  <form id="form" class="card" autocomplete="off" novalidate>
    <div id="msg" role="status" aria-live="polite"></div>
    <h2>The business</h2>
    <label for="slug">Kit name (letters, numbers, dashes)</label><input id="slug" maxlength="41" placeholder="luzon-fresh">
    <label for="name">Name of the business</label><input id="name" maxlength="60" placeholder="Luzon Fresh Mart">
    <div class="two"><div><label for="shortName">Short name</label><input id="shortName" maxlength="30"></div><div><label for="tagline">One line under the name</label><input id="tagline" maxlength="120"></div></div>
    <h2>The look</h2>
    <div class="two">
      <div><label for="primaryColor">Main colour</label><div class="pick"><input type="color" id="primaryPick" aria-label="Pick the main colour"><input id="primaryColor" maxlength="7" placeholder="#0f6cbd"></div></div>
      <div><label for="accentColor">Second colour</label><div class="pick"><input type="color" id="accentPick" aria-label="Pick the second colour"><input id="accentColor" maxlength="7" placeholder="#f59e0b"></div></div>
    </div>
    <label for="logo">Logo (PNG, JPEG or SVG)</label><input type="file" id="logo" accept="image/png,image/jpeg,image/svg+xml"><div id="logoNote" class="muted small"></div>
    <h2>Contact (on bills, the website and the app)</h2>
    <div class="two"><div><label for="email">Email</label><input id="email" maxlength="120"></div><div><label for="phone">Phone</label><input id="phone" maxlength="25"></div></div>
    <label for="address">Address</label><input id="address" maxlength="200">
    <h2>Where and what</h2>
    <div class="two"><div><label for="country">Country</label><select id="country"></select></div><div><label for="industry">Kind of business</label><select id="industry"></select></div></div>
    <div class="two"><div><label for="currency">Currency code</label><input id="currency" maxlength="3" placeholder="INR"></div><div><label for="language">Language</label><input id="language" maxlength="12" placeholder="en-IN"></div></div>
    <h2>Website and Android app</h2>
    <label for="siteUrl">Website address</label><input id="siteUrl" placeholder="https://shop.example.com">
    <label for="appId">Android app id</label><input id="appId" placeholder="com.luzonfresh.shop">
    <h2>Bills</h2>
    <div class="two"><div><label for="receiptHeader">Words at the top</label><input id="receiptHeader" maxlength="160"></div><div><label for="receiptFooter">Words at the bottom</label><input id="receiptFooter" maxlength="160" placeholder="Thank you!"></div></div>
    <label class="check"><input type="checkbox" id="poweredBy"> Show "by NextGenOS" (a reseller licence may turn this off)</label>
    <div class="actions"><button type="button" class="btn primary" id="save">Save the kit</button><button type="button" class="btn" id="export">Make the files</button></div>
    <div id="files" class="muted small"></div>
  </form>
  <section class="card"><h2>How it will look</h2><iframe id="preview" title="Preview" sandbox=""></iframe></section>
</main>
<script src="/wizard.js"></script>
</body></html>
`;

export const WIZARD_CSS = `
:root{--c:#0f6cbd}*{box-sizing:border-box}
body{margin:0;font:15px/1.45 system-ui,-apple-system,Segoe UI,Roboto,sans-serif;background:#f5f5f7;color:#1d1d1f}
.top{display:flex;justify-content:space-between;align-items:center;padding:14px 24px;background:#fff;border-bottom:1px solid #e2e4e8}
.muted{color:#6e6e73}.small{font-size:.82rem}
.kits{display:flex;gap:8px;flex-wrap:wrap}.kits button{border:1px solid #d5d8de;background:#fff;border-radius:999px;padding:5px 12px;cursor:pointer;font:inherit}
.grid{display:grid;grid-template-columns:minmax(360px,520px) 1fr;gap:20px;padding:20px 24px;align-items:start}
@media (max-width:900px){.grid{grid-template-columns:1fr}}
.card{background:#fff;border:1px solid #e2e4e8;border-radius:16px;padding:20px}
h2{font-size:1rem;margin:22px 0 4px}h2:first-of-type{margin-top:0}
label{display:block;margin:10px 0 4px;font-weight:600;font-size:.9rem}label.check{display:flex;gap:8px;align-items:center;font-weight:400;margin-top:14px}
input,select{width:100%;min-height:40px;padding:8px 12px;border:1px solid #d0d5dd;border-radius:10px;font:inherit;background:#fff}
input[type=checkbox]{width:20px;min-height:20px}input[type=color]{width:46px;padding:2px;flex:none}
.two{display:grid;grid-template-columns:1fr 1fr;gap:12px}.pick{display:flex;gap:8px}
.actions{display:flex;gap:10px;margin-top:20px}
.btn{border:1px solid #d0d5dd;background:#fff;border-radius:999px;padding:9px 20px;font:inherit;font-weight:600;cursor:pointer}.btn.primary{background:var(--c);border-color:var(--c);color:#fff}
#msg:not(:empty){padding:10px 14px;border-radius:10px;margin-bottom:14px;white-space:pre-line}#msg.ok{background:#e6f4ea;color:#17692f}#msg.bad{background:#fdecea;color:#a1271c}
#preview{width:100%;height:1200px;border:1px solid #e2e4e8;border-radius:12px;background:#fff}
`;

export const WIZARD_JS = `
'use strict';
const token = new URLSearchParams(location.search).get('k') || '';
const $ = (id) => document.getElementById(id);
let logoData = null;
let existing = false;

async function api(path, method, body) {
  const r = await fetch(path, { method: method || 'GET', headers: { 'X-Brand-Studio': token, 'Content-Type': 'application/json' }, body: body ? JSON.stringify(body) : undefined });
  const data = await r.json().catch(() => ({}));
  if (!r.ok) { const e = new Error((data.problems || [data.error || 'Something went wrong.']).join('\\n')); throw e; }
  return data;
}
const say = (text, ok) => { const m = $('msg'); m.textContent = text || ''; m.className = text ? (ok ? 'ok' : 'bad') : ''; };
const slugOf = (name) => name.toLowerCase().normalize('NFKD').replace(/[^a-z0-9]+/g, '-').replace(/^-+|-+$/g, '').slice(0, 41);

function readForm() {
  const v = (id) => $(id).value.trim();
  const kit = { schema: 1, name: v('name'), primaryColor: v('primaryColor'), theme: 'auto', poweredBy: $('poweredBy').checked };
  for (const k of ['shortName', 'tagline']) if (v(k)) kit[k] = v(k);
  if (v('accentColor')) kit.accentColor = v('accentColor');
  kit.contact = { email: v('email'), phone: v('phone'), address: v('address') };
  for (const k of ['country', 'industry', 'currency', 'language']) if (v(k)) kit[k] = v(k);
  if (v('siteUrl')) kit.storefront = { siteUrl: v('siteUrl') };
  if (v('appId')) kit.android = { appId: v('appId'), storefrontUrl: v('siteUrl') };
  if (v('receiptHeader') || v('receiptFooter')) kit.receipt = { header: v('receiptHeader'), footer: v('receiptFooter') };
  return kit;
}
function fillForm(kit) {
  const set = (id, value) => { $(id).value = value || ''; };
  set('name', kit.name); set('shortName', kit.shortName); set('tagline', kit.tagline); set('primaryColor', kit.primaryColor); set('accentColor', kit.accentColor);
  set('email', kit.contact && kit.contact.email); set('phone', kit.contact && kit.contact.phone); set('address', kit.contact && kit.contact.address);
  set('country', kit.country); set('industry', kit.industry); set('currency', kit.currency); set('language', kit.language);
  set('siteUrl', kit.storefront && kit.storefront.siteUrl); set('appId', kit.android && kit.android.appId);
  set('receiptHeader', kit.receipt && kit.receipt.header); set('receiptFooter', kit.receipt && kit.receipt.footer);
  $('poweredBy').checked = kit.poweredBy !== false;
  syncPickers();
}
function syncPickers() {
  const hex = /^#[0-9a-fA-F]{6}$/;
  if (hex.test($('primaryColor').value)) $('primaryPick').value = $('primaryColor').value;
  if (hex.test($('accentColor').value)) $('accentPick').value = $('accentColor').value;
  if (hex.test($('primaryColor').value)) document.documentElement.style.setProperty('--c', $('primaryColor').value);
}

let timer = null;
function previewSoon() { clearTimeout(timer); timer = setTimeout(preview, 250); }
async function preview() {
  try { const r = await api('/api/preview', 'POST', { kit: readForm(), logo: logoData }); $('preview').srcdoc = r.html; } catch (e) { /* the form is still being filled in */ }
}

async function loadKit(slug) {
  try {
    const r = await api('/api/kit/' + encodeURIComponent(slug));
    existing = true; $('slug').value = slug; fillForm(r.kit); logoData = r.logo; $('logoNote').textContent = r.logo ? 'A logo is in the kit. Choose a file to replace it.' : 'No logo yet.';
    say(r.warnings.length ? r.warnings.join('\\n') : '', true); previewSoon();
  } catch (e) { say(e.message, false); }
}

let optionsLoaded = false;
async function start() {
  const o = await api('/api/options');
  if (!optionsLoaded) {
    for (const [id, list] of [['country', o.countries], ['industry', o.industries]]) { $(id).innerHTML = '<option value=""></option>' + list.map((x) => '<option>' + x + '</option>').join(''); }
    $('primaryColor').value = '#0f6cbd'; $('accentColor').value = '#f59e0b'; $('poweredBy').checked = true;
    optionsLoaded = true;
  }
  const kits = $('kits');
  kits.innerHTML = '';
  const fresh = document.createElement('button'); fresh.type = 'button'; fresh.textContent = '+ New kit';
  fresh.onclick = () => { existing = false; $('form').reset(); $('primaryColor').value = '#0f6cbd'; $('accentColor').value = '#f59e0b'; $('poweredBy').checked = true; logoData = null; $('logoNote').textContent = ''; syncPickers(); say(''); previewSoon(); };
  kits.appendChild(fresh);
  for (const k of o.kits) { const b = document.createElement('button'); b.type = 'button'; b.textContent = k; b.onclick = () => loadKit(k); kits.appendChild(b); }
  syncPickers(); previewSoon();
}

$('form').addEventListener('input', (e) => {
  if (e.target.id === 'name' && !existing) $('slug').value = slugOf($('name').value);
  if (e.target.id === 'primaryPick') $('primaryColor').value = e.target.value;
  if (e.target.id === 'accentPick') $('accentColor').value = e.target.value;
  syncPickers(); previewSoon();
});
$('logo').addEventListener('change', () => {
  const f = $('logo').files[0]; if (!f) return;
  if (f.size > 300000) { say('That picture is too big. Use one of at most 300 KB.', false); return; }
  const reader = new FileReader();
  reader.onload = () => { logoData = reader.result; $('logoNote').textContent = f.name; previewSoon(); };
  reader.readAsDataURL(f);
});
$('save').onclick = async () => {
  try { const r = await api('/api/kit/' + encodeURIComponent($('slug').value.trim()), 'POST', { kit: readForm(), logo: logoData && logoData.startsWith('data:') ? logoData : null, keepLogo: !!logoData }); existing = true; say('Saved in brand-kits/' + $('slug').value.trim() + '.' + (r.warnings.length ? '\\n' + r.warnings.join('\\n') : ''), true); start(); } catch (e) { say(e.message, false); }
};
$('export').onclick = async () => {
  try { const r = await api('/api/export/' + encodeURIComponent($('slug').value.trim()), 'POST'); $('files').textContent = 'Made in ' + r.dir + ': ' + r.files.join(', '); say('The files are ready. Open preview.html in that folder to see them.' + (r.warnings.length ? '\\n' + r.warnings.join('\\n') : ''), true); } catch (e) { say(e.message, false); }
};
start();
`;
