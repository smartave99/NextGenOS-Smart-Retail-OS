// One self-contained page that shows a kit as the programs will look: the side menu, a sale, a bill, the sign-in card and the app icon, in light and dark.
// Every text from the kit is escaped; the page has no script and loads nothing from outside.
const esc = (t) => String(t ?? '').replace(/[&<>"']/g, (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' }[c]));

export function logoDataUri(bytes, kind) {
  if (!bytes || !kind) return null;
  const type = kind === 'jpeg' ? 'image/jpeg' : kind === 'svg' ? 'image/svg+xml' : 'image/png';
  return `data:${type};base64,${bytes.toString('base64')}`;
}

export function previewHtml(kit, logo) {
  const c = kit.primaryColor || '#0f6cbd';
  const a = kit.accentColor || '#f59e0b';
  const name = esc(kit.name);
  const logoImg = logo ? `<img class="logo" src="${esc(logo)}" alt="">` : '';
  const initials = esc((kit.shortName || kit.name || '?').trim().split(/\s+/).slice(0, 2).map((w) => w[0]).join('').toUpperCase());
  const by = kit.poweredBy === false ? '' : '<div class="by">by NextGenOS</div>';
  const header = esc(kit.receipt?.header || '');
  const footer = esc(kit.receipt?.footer || 'Thank you!');
  const phone = esc(kit.contact?.phone || '');
  const address = esc(kit.contact?.address || '');
  const panel = (mode) => `
  <section class="panel ${mode}">
    <h2>${mode === 'light' ? 'Light' : 'Dark'}</h2>
    <div class="screen">
      <nav class="side">
        ${logoImg}<div class="pname">${name}</div>${by}
        <ul><li>Today</li><li class="on">New sale</li><li>Products</li><li>Reports</li></ul>
      </nav>
      <div class="main">
        <div class="bar"><strong>New sale</strong><span class="btn">Complete</span></div>
        <div class="line"><span>Basmati rice 5 kg</span><span>1 &times; 640.00</span></div>
        <div class="line"><span>Tea 250 g</span><span>2 &times; 125.00</span></div>
        <div class="total"><span>Total</span><strong>890.00</strong></div>
        <div class="chips"><span class="chip">Paid</span><span class="chip alt">Offer</span></div>
      </div>
    </div>
    <div class="row">
      <div class="bill"><div class="bn">${name}</div>${header ? `<div class="bh">${header}</div>` : ''}${address ? `<div class="bh">${address}</div>` : ''}${phone ? `<div class="bh">${phone}</div>` : ''}<hr><div class="bl"><span>Total</span><span>890.00</span></div><hr><div class="bf">${footer}</div></div>
      <div class="login">${logoImg}<div class="pname">${name}</div><div class="in"></div><div class="in"></div><span class="btn wide">Sign in</span></div>
      <div class="icon" aria-label="App icon">${logo ? logoImg : `<span>${initials}</span>`}</div>
    </div>
  </section>`;
  return `<!doctype html>
<html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1">
<meta http-equiv="Content-Security-Policy" content="default-src 'none'; img-src data:; style-src 'unsafe-inline'">
<title>${name}: how it will look</title>
<style>
:root{--c:${c};--a:${a}}
*{box-sizing:border-box}body{margin:0;font:15px/1.45 system-ui,-apple-system,Segoe UI,Roboto,sans-serif;background:#eceef2;color:#1d1d1f;padding:24px}
h1{font-size:1.4rem;margin:0 0 4px}.sub{color:#555;margin:0 0 20px}
.wrap{display:grid;grid-template-columns:repeat(auto-fit,minmax(420px,1fr));gap:20px}
.panel{border-radius:16px;padding:18px;border:1px solid #d5d8de}.panel h2{margin:0 0 12px;font-size:1rem}
.panel.light{background:#f5f5f7;color:#1d1d1f;--surface:#fff;--line:#e2e4e8;--muted:#6e6e73}
.panel.dark{background:#1c1c1e;color:#f5f5f7;--surface:#2c2c2e;--line:#3a3a3c;--muted:#a1a1a6}
.panel.dark{--c:color-mix(in srgb,${c} 82%,white)}
.screen{display:grid;grid-template-columns:150px 1fr;border:1px solid var(--line);border-radius:12px;overflow:hidden;background:var(--surface)}
.side{padding:14px;border-right:1px solid var(--line)}.side .logo{display:block;max-height:30px;max-width:120px;margin-bottom:6px}
.pname{font-weight:700}.by{font-size:.72rem;color:var(--muted)}.side ul{list-style:none;padding:0;margin:14px 0 0}
.side li{padding:6px 8px;border-radius:8px;margin-bottom:2px;color:var(--muted)}.side li.on{background:color-mix(in srgb,var(--c) 14%,transparent);color:var(--c);font-weight:600}
.main{padding:14px}.bar{display:flex;justify-content:space-between;align-items:center;margin-bottom:10px}
.btn{background:var(--c);color:#fff;border-radius:999px;padding:7px 16px;font-weight:600;display:inline-block}.btn.wide{display:block;text-align:center;margin-top:10px}
.line,.total{display:flex;justify-content:space-between;padding:6px 0;border-bottom:1px solid var(--line)}.total{border:0;font-size:1.05rem}
.chips{margin-top:6px}.chip{display:inline-block;border-radius:999px;padding:2px 10px;font-size:.78rem;background:color-mix(in srgb,var(--c) 14%,transparent);color:var(--c);margin-right:6px}.chip.alt{background:color-mix(in srgb,var(--a) 22%,transparent);color:inherit}
.row{display:flex;gap:14px;align-items:flex-start;margin-top:14px;flex-wrap:wrap}
.bill{width:190px;background:#fff;color:#111;border:1px dashed #aaa;border-radius:6px;padding:12px;font:12px/1.35 ui-monospace,Menlo,Consolas,monospace}.bn{font-weight:700;text-align:center}.bh{text-align:center;color:#444}.bl{display:flex;justify-content:space-between}.bf{text-align:center;margin-top:6px}
.login{width:190px;background:var(--surface);border:1px solid var(--line);border-radius:14px;padding:14px}.login .logo{display:block;max-height:30px;margin-bottom:6px}.in{height:28px;border:1px solid var(--line);border-radius:8px;margin-top:8px}
.icon{width:84px;height:84px;border-radius:20px;background:var(--c);color:#fff;display:grid;place-items:center;font-weight:700;font-size:1.6rem;overflow:hidden}.icon img{max-width:100%;max-height:100%}
</style></head><body>
<h1>${name}</h1><p class="sub">How the programs will look with this kit. Colours: main <strong style="color:${esc(c)}">${esc(c)}</strong>, second <strong style="color:${esc(a)}">${esc(a)}</strong>.</p>
<div class="wrap">${panel('light')}${panel('dark')}</div>
</body></html>
`;
}
