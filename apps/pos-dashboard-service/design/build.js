// Writes the design-preview pages (sample data only). Run: node build.js
const fs = require('fs');
const path = require('path');

const ICONS = {
  house: '<path d="M3.5 10.5 12 3.5l8.5 7"/><path d="M5.5 9v11h13V9"/><path d="M10 20v-5.5h4V20"/>',
  chat: '<path d="M20.5 11.5c0 4.4-3.8 8-8.5 8-1.3 0-2.6-.3-3.7-.8L3.5 20l1.3-3.9a7.6 7.6 0 0 1-1.3-4.6c0-4.4 3.8-8 8.5-8s8.5 3.6 8.5 8z"/>',
  sparkles: '<path d="M11 3.5l1.7 4.6 4.6 1.7-4.6 1.7L11 16.1l-1.7-4.6-4.6-1.7 4.6-1.7z"/><path d="M18.5 14.5l.8 2 2 .8-2 .8-.8 2-.8-2-2-.8 2-.8z"/>',
  chart: '<path d="M3.5 20h17"/><path d="M6 16.5v-5M10.5 16.5V7M15 16.5v-7.5M19.5 16.5V4.5"/>',
  trend: '<path d="M3.5 17l6-6 4 4 7-7"/><path d="M14.5 8h6v6"/>',
  receipt: '<path d="M6 3.5h12V21l-3-2-3 2-3-2-3 2z"/><path d="M9 8h6M9 12h6M9 16h3"/>',
  cube: '<path d="M3.5 7.5 12 3.5l8.5 4v9l-8.5 4-8.5-4z"/><path d="M3.5 7.5 12 12l8.5-4.5M12 12v8.5"/>',
  alert: '<path d="M12 3.5 2.5 20h19z"/><path d="M12 10v4.5M12 17.2v.1"/>',
  camera: '<path d="M4 8h3l2-3h6l2 3h3a1 1 0 0 1 1 1v10a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V9a1 1 0 0 1 1-1z"/><circle cx="12" cy="13.5" r="3.5"/>',
  poster: '<rect x="4.5" y="2.5" width="15" height="19" rx="2"/><circle cx="9.5" cy="8" r="1.8"/><path d="M4.5 16l4.5-4 4 3.5 2.5-2 4 3.5"/>',
  folder: '<path d="M3 6.5A1.5 1.5 0 0 1 4.5 5h4l2 2.5h9A1.5 1.5 0 0 1 21 9v9.5a1.5 1.5 0 0 1-1.5 1.5h-15A1.5 1.5 0 0 1 3 18.5z"/>',
  sliders: '<path d="M4 7h9M17 7h3M4 12h3M11 12h9M4 17h11M19 17h1"/><circle cx="15" cy="7" r="2"/><circle cx="9" cy="12" r="2"/><circle cx="17" cy="17" r="2"/>',
  search: '<circle cx="11" cy="11" r="7"/><path d="m20 20-3.6-3.6"/>',
  download: '<path d="M12 4v11M7.5 10.5 12 15l4.5-4.5"/><path d="M5 19.5h14"/>',
  upload: '<path d="M12 15.5V4.5M7.5 9 12 4.5 16.5 9"/><path d="M5 19.5h14"/>',
  arrowup: '<path d="M12 19V5M6 11l6-6 6 6"/>',
  printer: '<path d="M6 9V3.5h12V9"/><rect x="3" y="9" width="18" height="8" rx="2"/><path d="M7 14h10v6.5H7z"/>',
  copy: '<rect x="8.5" y="8.5" width="12" height="12" rx="2.5"/><path d="M15.5 8.5V6a2.5 2.5 0 0 0-2.5-2.5H6A2.5 2.5 0 0 0 3.5 6v7A2.5 2.5 0 0 0 6 15.5h2.5"/>',
  external: '<path d="M14 4h6v6M20 4l-8.5 8.5"/><path d="M18 14v4.5a1.5 1.5 0 0 1-1.5 1.5h-11A1.5 1.5 0 0 1 4 18.5v-11A1.5 1.5 0 0 1 5.5 6H10"/>',
  chevron: '<path d="m9 6 6 6-6 6"/>',
  shield: '<path d="M12 3 5 6v5.5c0 4.2 3 7.9 7 9.5 4-1.6 7-5.3 7-9.5V6z"/><path d="m9 12 2.2 2.2L15.5 10"/>',
  check: '<path d="m5 12.5 4.5 4.5L19 7.5"/>',
  close: '<path d="M6 6l12 12M18 6 6 18"/>',
  plus: '<path d="M12 5v14M5 12h14"/>',
  expand: '<path d="M14 4h6v6M10 20H4v-6M20 4l-7 7M4 20l7-7"/>',
  person: '<circle cx="12" cy="8" r="4"/><path d="M4 21c0-4 3.6-6 8-6s8 2 8 6"/>',
  refresh: '<path d="M20 11a8 8 0 0 0-14.5-4.5L4 8"/><path d="M4 3.5V8h4.5"/><path d="M4 13a8 8 0 0 0 14.5 4.5L20 16"/><path d="M20 20.5V16h-4.5"/>',
  info: '<circle cx="12" cy="12" r="8.5"/><path d="M12 11v5M12 7.8v.1"/>',
  lock: '<rect x="5" y="11" width="14" height="9.5" rx="2"/><path d="M8 11V7.5a4 4 0 0 1 8 0V11"/>',
  bell: '<path d="M6 9.5a6 6 0 0 1 12 0c0 6.5 2.5 8 2.5 8h-17S6 16 6 9.5z"/><path d="M10 20.5a2.2 2.2 0 0 0 4 0"/>',
  flag: '<path d="M5 21V4"/><path d="M5 4.5h11.5l-2.2 4.2 2.2 4.3H5"/>',
  book: '<path d="M5 5a2 2 0 0 1 2-2h12v15H7a2 2 0 0 0-2 2z"/><path d="M5 20a2 2 0 0 0 2 2h12v-4"/>',
  tag: '<path d="M3.5 12.5V4.5a1 1 0 0 1 1-1h8l8 8-9 9z"/><circle cx="8" cy="8" r="1.5"/>',
};
const icon = (name) => `<svg class="i" viewBox="0 0 24 24" aria-hidden="true">${ICONS[name]}</svg>`;

const appIcon = (size, cls = '') => `<svg class="app-icon ${cls}" width="${size}" height="${size}" viewBox="0 0 64 64" aria-hidden="true">
  <defs><linearGradient id="appg" x1="0" y1="0" x2="1" y2="1"><stop offset="0" stop-color="#7a5cff"/><stop offset=".55" stop-color="#2f7bff"/><stop offset="1" stop-color="#18b6f6"/></linearGradient></defs>
  <rect width="64" height="64" rx="15" fill="url(#appg)"/>
  <path d="M28 14c1.6 11.6 6.4 16.4 19 19-12.6 2.6-17.4 7.4-19 19-1.6-11.6-6.4-16.4-19-19 12.6-2.6 17.4-7.4 19-19z" fill="#fff"/>
  <path d="M47 9.5c.7 4.7 2.6 6.6 7.5 7.5-4.9.9-6.8 2.8-7.5 7.5-.7-4.7-2.6-6.6-7.5-7.5 4.9-.9 6.8-2.8 7.5-7.5z" fill="#fff" opacity=".9"/>
</svg>`;

// ---------------------------------------------------------------- chrome
function windowFrame(inner, { dark = false, title = 'Smart Retail POS' } = {}) {
  return `<div class="window ${dark ? 'dark' : 'light'}">
  <div class="titlebar">${appIcon(18)}<span>${title}</span>
    <div class="controls">
      <span><svg viewBox="0 0 12 12"><path d="M1 6h10"/></svg></span>
      <span><svg viewBox="0 0 12 12"><rect x="1.5" y="1.5" width="9" height="9" rx="1.5"/></svg></span>
      <span><svg viewBox="0 0 12 12"><path d="M1.5 1.5l9 9M10.5 1.5l-9 9"/></svg></span>
    </div>
  </div>
  ${inner}
</div>`;
}

// The app's own top bar, in place of the empty Windows title bar (1.6 preview): search in the middle, then the
// shop's data, the AI and the bell for what needs the owner, and the window buttons. The bar drags the window.
function appWindow(inner, { dark = false, bellOpen = false } = {}) {
  const pop = bellOpen ? `<div class="tb-pop">
      <div class="tb-pop-head"><b>Needs you</b><span class="muted">3 new</span></div>
      <div class="tb-pop-row"><span class="tile orange">${icon('alert')}</span><div><b>2 prices are below cost</b><p>Fix now · Toothpaste 150 g sells ₹4 below what it cost.</p></div></div>
      <div class="tb-pop-row"><span class="tile purple">${icon('book')}</span><div><b>The AI learned 1 thing from a chat</b><p>Memory · it waits for your Save.</p></div></div>
      <div class="tb-pop-row"><span class="tile green">${icon('flag')}</span><div><b>E-rickshaw ads: first result</b><p>Actions · sales 7% above the season after 8 days.</p></div></div>
    </div>` : '';
  return `<div class="window ${dark ? 'dark' : 'light'}">
  <div class="apptop">
    <div class="tb-brand">${appIcon(18)}<span>Smart Retail POS</span></div>
    <div class="tb-search">${icon('search')}<span>Search products, bills and pages</span><kbd>Ctrl K</kbd></div>
    <div class="tb-right">
      <span class="tb-chip"><span class="dot"></span>Live · read-only</span>
      <span class="tb-chip">${icon('sparkles')}AI ready<span class="tb-meter"><i style="width:23%"></i></span><span class="num">23%</span></span>
      <span class="tb-bell${bellOpen ? ' open' : ''}">${icon('bell')}<span class="tb-badge">3</span>${pop}</span>
    </div>
    <div class="controls">
      <span><svg viewBox="0 0 12 12"><path d="M1 6h10"/></svg></span>
      <span><svg viewBox="0 0 12 12"><rect x="1.5" y="1.5" width="9" height="9" rx="1.5"/></svg></span>
      <span><svg viewBox="0 0 12 12"><path d="M1.5 1.5l9 9M10.5 1.5l-9 9"/></svg></span>
    </div>
  </div>
  ${inner}
</div>`;
}

function sidebar(active, { search = true } = {}) {
  const item = (key, ico, label, extra = '') =>
    `<div class="nav-item${key === active ? ' active' : ''}">${icon(ico)}<span>${label}</span>${extra}</div>`;
  return `<aside class="sidebar">
  ${search ? `<div class="search">${icon('search')}<span>Search</span><kbd>Ctrl K</kbd></div>` : '<div style="height:8px"></div>'}
  ${item('today', 'house', 'Today')}
  ${item('ask', 'sparkles', 'Ask AI')}
  <div class="nav-label">Shop</div>
  ${item('sales', 'chart', 'Sales')}
  ${item('grow', 'trend', 'Grow sales')}
  ${item('bills', 'receipt', 'Bills')}
  ${item('products', 'cube', 'Products')}
  ${item('stock', 'alert', 'Low stock', '<span class="count">5</span>')}
  <div class="nav-label">Create</div>
  ${item('photos', 'camera', 'Product photos')}
  ${item('posters', 'poster', 'Posters', '<span class="new">NEW</span>')}
  <div class="spacer"></div>
  ${item('storage', 'folder', 'Storage')}
  ${item('settings', 'sliders', 'Settings')}
  <div class="shop-card">
    <div class="avatar">SG</div>
    <div><div class="name">Sharma General Store</div>
      <div class="status-line"><span class="dot"></span>Live · read-only</div></div>
  </div>
</aside>`;
}

function page(file, body, { dark = false, extraHead = '' } = {}) {
  const html = `<!doctype html>
<html lang="en"><head><meta charset="utf-8"><title>${file}</title>
<link rel="stylesheet" href="design.css">${extraHead}</head>
<body class="${dark ? 'desk-dark' : ''}">
${body}
</body></html>`;
  fs.writeFileSync(path.join(__dirname, file), html);
}

// ---------------------------------------------------------------- illustrations (sample art, not real photos)
function bottle({ x = 100, base = 172, scale = 1, tilt = 0, id = 'b' } = {}) {
  // An insulated steel bottle, drawn around (100, 100) and moved into place.
  return `<g transform="translate(${x} ${base}) rotate(${tilt}) scale(${scale}) translate(-100 -172)">
    <defs>
      <linearGradient id="${id}body" x1="0" x2="1"><stop offset="0" stop-color="#0d6b6b"/><stop offset=".28" stop-color="#23b5b0"/><stop offset=".48" stop-color="#5fd6cf"/><stop offset=".62" stop-color="#1fa39f"/><stop offset="1" stop-color="#0b5a5c"/></linearGradient>
      <linearGradient id="${id}steel" x1="0" x2="1"><stop offset="0" stop-color="#6f767d"/><stop offset=".3" stop-color="#dfe4e8"/><stop offset=".5" stop-color="#f7f9fa"/><stop offset=".7" stop-color="#a9b0b7"/><stop offset="1" stop-color="#5e656b"/></linearGradient>
      <linearGradient id="${id}cap" x1="0" x2="1"><stop offset="0" stop-color="#151517"/><stop offset=".4" stop-color="#4a4a4f"/><stop offset=".55" stop-color="#6a6a70"/><stop offset="1" stop-color="#101012"/></linearGradient>
    </defs>
    <rect x="84" y="30" width="32" height="24" rx="6" fill="url(#${id}cap)"/>
    <rect x="80" y="44" width="40" height="12" rx="4" fill="url(#${id}cap)"/>
    <path d="M86 56h28v6c0 3 12 6 12 16v84a10 10 0 0 1-10 10H84a10 10 0 0 1-10-10V78c0-10 12-13 12-16z" fill="url(#${id}body)"/>
    <path d="M74 156h52v6a10 10 0 0 1-10 10H84a10 10 0 0 1-10-10z" fill="url(#${id}steel)"/>
    <rect x="87" y="98" width="26" height="4" rx="2" fill="#ffffff" opacity=".55"/>
    <path d="M95 70v82" stroke="#fff" stroke-width="3" stroke-linecap="round" opacity=".22"/>
  </g>`;
}

function shadow(cx, cy, rx, ry = 5, o = 0.18) {
  return `<ellipse cx="${cx}" cy="${cy}" rx="${rx}" ry="${ry}" fill="#000" opacity="${o}" filter="url(#soft)"/>`;
}
const FILTERS = `<defs>
  <filter id="soft" x="-50%" y="-50%" width="200%" height="200%"><feGaussianBlur stdDeviation="3"/></filter>
  <filter id="blur1" x="-20%" y="-20%" width="140%" height="140%"><feGaussianBlur stdDeviation="1.4"/></filter>
  <filter id="blur4" x="-30%" y="-30%" width="160%" height="160%"><feGaussianBlur stdDeviation="4.5"/></filter>
  <filter id="blur8" x="-40%" y="-40%" width="180%" height="180%"><feGaussianBlur stdDeviation="9"/></filter>
</defs>`;

const photoWhite = () => `<svg viewBox="0 0 200 200">${FILTERS}<rect width="200" height="200" fill="#fff"/>${shadow(100, 179, 30, 4, 0.22)}${bottle({ base: 178, scale: 1.02, id: 'w' })}</svg>`;

const photoInUse = () => `<svg viewBox="0 0 200 200">${FILTERS}
  <defs>
    <linearGradient id="wall" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#f6eee2"/><stop offset="1" stop-color="#e6d6bf"/></linearGradient>
    <linearGradient id="desk" x1="0" y1="0" x2="0" y2="1"><stop offset="0" stop-color="#c89668"/><stop offset="1" stop-color="#8f5f39"/></linearGradient>
  </defs>
  <rect width="200" height="200" fill="url(#wall)"/>
  <g filter="url(#blur4)">
    <rect x="8" y="10" width="70" height="92" rx="4" fill="#fffaf0"/>
    <rect x="41" y="10" width="4" height="92" fill="#e9dcc8"/>
    <rect x="130" y="92" width="62" height="44" rx="4" fill="#2b2d31"/>
    <rect x="124" y="134" width="76" height="6" rx="2" fill="#44474d"/>
    <circle cx="26" cy="118" r="18" fill="#4f8a4a"/><circle cx="12" cy="104" r="12" fill="#6aa561"/><circle cx="40" cy="104" r="11" fill="#3f7a3b"/>
    <rect x="16" y="124" width="22" height="22" rx="3" fill="#d9c1a1"/>
  </g>
  <rect y="146" width="200" height="54" fill="url(#desk)"/>
  <rect y="146" width="200" height="3" fill="#dcae80" opacity=".7"/>
  ${shadow(104, 177, 30, 4, 0.3)}
  ${bottle({ x: 104, base: 176, scale: 0.86, id: 'u' })}
  <g filter="url(#blur1)"><rect x="140" y="160" width="46" height="30" rx="3" fill="#f2efe9"/><path d="M146 168h30M146 175h24" stroke="#c9c3b8" stroke-width="2"/></g>
</svg>`;

function photoModel({ bgA, bgB, hair, skin, top, id, bokeh = '#ffffff' }) {
  return `<svg viewBox="0 0 200 200">${FILTERS}
  <defs><linearGradient id="${id}bg" x1="0" y1="0" x2="1" y2="1"><stop offset="0" stop-color="${bgA}"/><stop offset="1" stop-color="${bgB}"/></linearGradient></defs>
  <rect width="200" height="200" fill="url(#${id}bg)"/>
  <g filter="url(#blur8)" opacity=".7">
    <circle cx="30" cy="40" r="16" fill="${bokeh}"/><circle cx="170" cy="30" r="12" fill="${bokeh}"/><circle cx="160" cy="120" r="18" fill="${bokeh}" opacity=".6"/>
  </g>
  <g filter="url(#blur4)">
    <ellipse cx="92" cy="74" rx="36" ry="42" fill="${hair}"/>
    <rect x="84" y="100" width="16" height="22" fill="${skin}"/>
    <ellipse cx="92" cy="72" rx="24" ry="30" fill="${skin}"/>
    <path d="M60 60c4-26 58-30 64 4-10-12-44-16-64-4z" fill="${hair}"/>
    <path d="M36 200c0-44 22-80 56-80s56 36 56 80z" fill="${top}"/>
  </g>
  <g filter="url(#blur1)"><rect x="112" y="118" width="40" height="30" rx="14" fill="${skin}"/></g>
  ${bottle({ x: 132, base: 188, scale: 0.72, tilt: -8, id })}
  <g filter="url(#blur1)"><rect x="113" y="128" width="36" height="22" rx="11" fill="${skin}"/><rect x="146" y="128" width="9" height="18" rx="4.5" fill="${skin}"/></g>
</svg>`;
}

const photoRaw = (variant) => `<svg viewBox="0 0 200 200">${FILTERS}
  <defs><linearGradient id="raw${variant}" x1="0" y1="0" x2="1" y2="1"><stop offset="0" stop-color="${variant ? '#b9b2a6' : '#c9c2b5'}"/><stop offset="1" stop-color="${variant ? '#8d8679' : '#9e978a'}"/></linearGradient></defs>
  <rect width="200" height="200" fill="url(#raw${variant})"/>
  <rect x="${variant ? 128 : 8}" y="${variant ? 18 : 120}" width="60" height="40" rx="3" fill="#e9e4da" opacity=".7" transform="rotate(${variant ? 8 : -6} 100 100)"/>
  ${shadow(variant ? 96 : 104, 180, 26, 5, 0.35)}
  ${bottle({ x: variant ? 96 : 104, base: 178, scale: variant ? 0.78 : 0.9, tilt: variant ? 5 : -3, id: 'r' + variant })}
</svg>`;

// Poster products (flat illustrations)
const productArt = {
  bhujia: (id) => `<svg viewBox="0 0 100 100"><defs><linearGradient id="${id}" x1="0" x2="1"><stop offset="0" stop-color="#e8a200"/><stop offset=".5" stop-color="#ffd24a"/><stop offset="1" stop-color="#d98f00"/></linearGradient></defs>
    <path d="M28 18h44l4 70H24z" fill="url(#${id})"/><rect x="28" y="12" width="44" height="9" rx="2" fill="#c0392b"/>
    <rect x="30" y="40" width="40" height="22" rx="3" fill="#c0392b"/><circle cx="50" cy="51" r="7" fill="#ffd24a"/><path d="M26 84h48l1 5H25z" fill="#b87a00"/></svg>`,
  coffee: (id) => `<svg viewBox="0 0 100 100"><defs><linearGradient id="${id}" x1="0" x2="1"><stop offset="0" stop-color="#3b2416"/><stop offset=".45" stop-color="#7a4a2c"/><stop offset="1" stop-color="#2d1a10"/></linearGradient></defs>
    <rect x="31" y="14" width="38" height="14" rx="3" fill="#b1122e"/><rect x="28" y="26" width="44" height="62" rx="9" fill="url(#${id})"/>
    <rect x="28" y="44" width="44" height="24" fill="#f3e6d2"/><path d="M38 56h24" stroke="#7a4a2c" stroke-width="4" stroke-linecap="round"/><rect x="36" y="30" width="5" height="54" rx="2.5" fill="#fff" opacity=".18"/></svg>`,
  dishwash: (id) => `<svg viewBox="0 0 100 100"><defs><linearGradient id="${id}" x1="0" x2="1"><stop offset="0" stop-color="#1f8a3a"/><stop offset=".45" stop-color="#5fd17a"/><stop offset="1" stop-color="#167030"/></linearGradient></defs>
    <path d="M44 8h12v8h6v8H38v-8h6z" fill="#e9eef2"/><path d="M36 24h28c4 0 7 4 7 9v48a7 7 0 0 1-7 7H36a7 7 0 0 1-7-7V33c0-5 3-9 7-9z" fill="url(#${id})"/>
    <rect x="35" y="46" width="30" height="22" rx="3" fill="#fff" opacity=".9"/><circle cx="50" cy="57" r="6" fill="#ffd60a"/><rect x="36" y="28" width="4" height="52" rx="2" fill="#fff" opacity=".25"/></svg>`,
  shampoo: (id) => `<svg viewBox="0 0 100 100"><defs><linearGradient id="${id}" x1="0" x2="1"><stop offset="0" stop-color="#4d3bb5"/><stop offset=".45" stop-color="#8e7bff"/><stop offset="1" stop-color="#3a2b96"/></linearGradient></defs>
    <rect x="37" y="8" width="26" height="14" rx="4" fill="#f2f2f7"/><path d="M34 22h32l4 8v52a8 8 0 0 1-8 8H38a8 8 0 0 1-8-8V30z" fill="url(#${id})"/>
    <rect x="36" y="44" width="28" height="24" rx="12" fill="#fff" opacity=".85"/><path d="M44 56h12" stroke="#5e4bd6" stroke-width="3" stroke-linecap="round"/><rect x="36" y="30" width="4" height="50" rx="2" fill="#fff" opacity=".25"/></svg>`,
};

// ---------------------------------------------------------------- the week chart
function weekChart() {
  const days = [['Sun', 61120], ['Mon', 38450], ['Tue', 35980], ['Wed', 41210], ['Thu', 43700], ['Fri', 44890], ['Today', 48260]];
  const W = 620, H = 212, left = 38, top = 22, bottom = 26, max = 70000;
  const plotH = H - top - bottom, plotW = W - left;
  const y = (v) => top + plotH - (v / max) * plotH;
  let out = '';
  for (const t of [0, 20000, 40000, 60000]) {
    out += `<line class="gridline" x1="${left}" x2="${W}" y1="${y(t)}" y2="${y(t)}"/>`;
    out += `<text x="${left - 10}" y="${y(t) + 4}" text-anchor="end">${t === 0 ? '0' : '₹' + t / 1000 + 'k'}</text>`;
  }
  const slot = plotW / days.length, bw = 24, r = 4;
  days.forEach(([label, v], i) => {
    const cx = left + slot * i + slot / 2, x = cx - bw / 2, yt = y(v), base = y(0);
    const now = label === 'Today';
    out += `<path class="bar${now ? ' now' : ''}" d="M${x} ${base}V${yt + r}Q${x} ${yt} ${x + r} ${yt}H${x + bw - r}Q${x + bw} ${yt} ${x + bw} ${yt + r}V${base}Z"/>`;
    out += `<text x="${cx}" y="${H - 6}" text-anchor="middle" class="${now ? 'today' : ''}">${label}</text>`;
    if (now) out += `<text class="cap" x="${cx}" y="${yt - 8}" text-anchor="middle">₹48.3k</text>`;
  });
  return `<svg viewBox="0 0 ${W} ${H}" role="img" aria-label="Sales for each of the last 7 days">${out}</svg>`;
}

// ---------------------------------------------------------------- screens
function today(dark, { topBar = false, bellOpen = false } = {}) {
  const content = `<main class="content">
  <div class="page-head">
    <div>
      <div class="eyebrow">Saturday, 26 September · FY 2026–27</div>
      <h1 class="title">Good evening</h1>
      <p class="lead">Here’s how the shop is doing today.</p>
    </div>
    <div class="actions"><span class="button gray">${icon('refresh')}Refresh</span><span class="button">${icon('sparkles')}Ask AI</span></div>
  </div>

  <section class="card hero">
    <div>
      <div class="label">Sales today</div>
      <div class="figure"><span class="rupee">₹</span>48,260</div>
      <div class="delta up">▲ 7.5% <span class="vs">vs last Saturday</span></div>
      <div class="facts">
        <div><strong>132</strong><span>bills</span></div>
        <div><strong>₹366</strong><span>average bill</span></div>
        <div><strong>₹3,450</strong><span>on credit</span></div>
      </div>
    </div>
    <div class="chart">
      <div class="chart-head"><div class="t">Last 7 days <span class="muted">· ₹3,13,610</span></div><div class="card-note up">▲ 6% vs the week before</div></div>
      ${weekChart()}
    </div>
  </section>

  <div class="row-2">
    <section class="card">
      <div class="card-head"><h2>${icon('sparkles')}For you</h2><span class="more">See the growth plan ${icon('chevron')}</span></div>
      <div class="suggestions">
        <div class="suggestion"><div class="tile orange">${icon('alert')}</div>
          <div><h3>Paneer 200 g may run out tomorrow</h3><p>8 left, and it sells about 9 a day. Reorder before the weekend rush.</p></div>
          <span class="button soft small">Low stock</span></div>
        <div class="suggestion"><div class="tile purple">${icon('camera')}</div>
          <div><h3>12 products have no photos yet</h3><p>Take a phone photo of each; the AI makes five shop-ready photos.</p></div>
          <span class="button soft small">Make photos</span></div>
        <div class="suggestion"><div class="tile pink">${icon('poster')}</div>
          <div><h3>4 slow products could clear with a poster</h3><p>Not sold for over a month. Suggested offers stay above cost.</p></div>
          <span class="button soft small">Make a poster</span></div>
        <div class="suggestion"><div class="tile green">${icon('trend')}</div>
          <div><h3>Sunday is your busiest day</h3><p>About 50% more sales than a weekday. Stock up on Saturday.</p></div>
          <span class="button soft small">See sales</span></div>
      </div>
    </section>

    <section class="card">
      <div class="card-head"><h2>Running low</h2><span class="more">See all ${icon('chevron')}</span></div>
      <div class="list">
        ${[['Floor Cleaner 1 L', 6, 2, 'bad'], ['Toothpaste 150 g', 12, 3, 'bad'], ['Sunflower Oil 1 L', 12, 4, 'warn'], ['Whole Wheat Atta 5 kg', 10, 6, 'warn'], ['Paneer 200 g', 10, 8, 'warn']]
          .map(([n, at, left, tone]) => `<div class="list-row"><div><div class="name">${n}</div><div class="sub">Reorder at ${at}</div></div><span class="pill ${tone}">${left} left</span></div>`).join('')}
      </div>
    </section>
  </div>
</main>`;
  return topBar
    ? appWindow(`<div class="app">${sidebar('today', { search: false })}${content}</div>`, { dark, bellOpen })
    : windowFrame(`<div class="app">${sidebar('today')}${content}</div>`, { dark });
}

function ask() {
  const rows = [['Bhujia 200 g', 35, '41 days ago', 55, 49], ['Instant Coffee 50 g', 9, '38 days ago', 175, 155], ['Dishwash Liquid 500 ml', 9, '52 days ago', 99, 84], ['Shampoo 180 ml', 14, '35 days ago', 160, 139]];
  const content = `<main class="content">
  <div class="chat-page">
    <div class="page-head">
      <div>
        <h1 class="title">Ask AI</h1>
        <p class="lead privacy">${icon('shield')}The AI sees sales figures and product names only — never customer names, phone numbers or bills.</p>
      </div>
      <div class="actions"><span class="pill good"><span class="dot"></span>ChatGPT connected</span><span class="button gray">${icon('plus')}New chat</span></div>
    </div>

    <div class="thread">
      <div class="msg-user">Which products should I put on offer this weekend?</div>
      <div class="msg-ai"><div class="ai-mark">${icon('sparkles')}</div>
        <div class="body">
          <p>These four haven’t sold for over a month. A small discount should clear them before the festival stock arrives:</p>
          <table class="answer-table">
            <tr><th>Product</th><th class="r">In stock</th><th>Last sold</th><th class="r">Suggested offer</th></tr>
            ${rows.map(([n, s, when, was, now]) => `<tr><td>${n}</td><td class="r">${s}</td><td class="muted">${when}</td><td class="r"><span class="old">₹${was}</span><span class="new">₹${now}</span></td></tr>`).join('')}
          </table>
          <p>Every offer stays above your cost price. Prices in the POS don’t change until you change them at the counter.</p>
          <div class="chips"><span class="chip accent">${icon('poster')}Make a clearance poster</span><span class="chip">${icon('chart')}Show them in Sales</span></div>
        </div>
      </div>
      <div class="msg-user">Great. What sold best this week?</div>
      <div class="msg-ai"><div class="ai-mark">${icon('sparkles')}</div>
        <div class="body"><p><b>Toned Milk 500 ml</b> sold the most (212 packets), then <b>Glucose Biscuits</b> (164). <b>Basmati Rice 5 kg</b> brought in the most money: ₹21,960. Milk and biscuits are often bought together, so keep them near the counter.</p></div>
      </div>
    </div>

    <div class="composer-wrap">
      <div class="chips"><span class="chip">How was this week compared with last week?</span><span class="chip">What should I reorder today?</span><span class="chip">Ideas for Diwali</span></div>
      <div class="composer">Ask about sales, stock or ideas…<span class="send">${icon('arrowup')}</span></div>
    </div>
  </div>
</main>`;
  return windowFrame(`<div class="app">${sidebar('ask')}${content}</div>`);
}

function photos() {
  const ring = (p) => `<svg class="ring" viewBox="0 0 50 50"><circle class="track" cx="25" cy="25" r="20"/><circle class="fill" cx="25" cy="25" r="20" stroke-dasharray="${(2 * Math.PI * 20 * p).toFixed(1)} 200"/></svg>`;
  const card = (n, title, img, status) => `<div class="card photo"><div class="img">${img}</div>
    <div class="cap"><div><b>${n} · ${title}</b><small>${status}</small></div>${status === 'Ready' ? `<span class="dl">${icon('download')}</span>` : ''}</div></div>`;
  const content = `<main class="content">
  <div class="page-head">
    <div>
      <div class="eyebrow">Product photos ${icon('chevron')}</div>
      <h1 class="title">Insulated Steel Bottle 750 ml</h1>
      <p class="lead">Five photos from your phone snapshots, ready for your website and Amazon.</p>
    </div>
    <div class="actions"><span class="button soft">${icon('download')}Download all</span><span class="button">${icon('upload')}New photos</span></div>
  </div>

  <div class="card steps-bar">
    <span class="what">Making photo 4 of 5 <span class="muted">· about a minute left</span></span>
    <div class="segments"><i class="done"></i><i class="done"></i><i class="done"></i><i class="doing"></i><i></i></div>
  </div>

  <div class="photo-row">
    ${card(1, 'White background', photoWhite(), 'Ready')}
    ${card(2, 'In use', photoInUse(), 'Ready')}
    ${card(3, 'European model', photoModel({ bgA: '#dfe7ef', bgB: '#a9b8c8', hair: '#a8773f', skin: '#f2cdb0', top: '#34465f', id: 'eu' }), 'Ready')}
    ${card(4, 'Indian model', photoModel({ bgA: '#f3e2cc', bgB: '#d7b48c', hair: '#2a1c15', skin: '#e3b58e', top: '#9c2f3b', id: 'in', bokeh: '#fff3dc' }) + `<div class="making">${ring(0.62)}Making…</div>`, 'Making now')}
    ${card(5, 'East Asian model', `<div class="waiting">${icon('person')}Next</div>`, 'Waiting')}
  </div>

  <div class="below">
    <section class="card">
      <div class="card-head"><h2>Your photos</h2><span class="card-note">2 phone photos</span></div>
      <div class="raw-row"><div class="raw">${photoRaw(0)}</div><div class="raw">${photoRaw(1)}</div><div class="add">${icon('plus')}Add</div></div>
      <div class="kept">${icon('folder')}<span>Kept in <b>D:\\Shop AI\\Photos</b> on this PC</span></div>
    </section>
    <section class="card">
      <div class="card-head"><h2>${icon('sparkles')}What the AI sees</h2><span class="more">Edit ${icon('chevron')}</span></div>
      <dl class="understanding">
        <dt>What it is</dt><dd>A double-wall steel bottle that keeps drinks cold for a day</dd>
        <dt>Where it’s used</dt><dd>Gym, office desk, school bag, travel</dd>
        <dt>European model</dt><dd>Woman, about 30, after a morning run</dd>
        <dt>Indian model</dt><dd>Woman, about 28, at her office desk</dd>
        <dt>East Asian model</dt><dd>Man, about 25, on a hiking trail</dd>
      </dl>
    </section>
  </div>

  <section class="card queue">
    <h2>Up next</h2>
    ${[['Copper Water Bottle 1 L', '3 phone photos'], ['Steel Lunch Box, 3 tiers', '2 phone photos'], ['Glass Jar Set of 3', '1 phone photo']]
      .map(([n, d]) => `<div class="queued"><span class="qthumb">${icon('camera')}</span><div><b>${n}</b><small>${d} · waiting</small></div></div>`).join('')}
    <span class="card-note">One product at a time, five photos each</span>
  </section>
</main>`;
  return windowFrame(`<div class="app">${sidebar('photos')}${content}</div>`);
}

function posterPaper() {
  const items = [['bhujia', 'Bhujia', '200 g', 55, 49], ['coffee', 'Instant Coffee', '50 g', 175, 155], ['dishwash', 'Dishwash Liquid', '500 ml', 99, 84], ['shampoo', 'Shampoo', '180 ml', 160, 139]];
  return `<div class="paper"><svg viewBox="0 0 440 622" width="440" height="622" style="display:block">
  ${FILTERS}
  <defs>
    <linearGradient id="pbg" x1="0" y1="0" x2="1" y2="1"><stop offset="0" stop-color="#ff2d55"/><stop offset=".55" stop-color="#ff5e3a"/><stop offset="1" stop-color="#ff9500"/></linearGradient>
    <radialGradient id="glow" cx=".8" cy=".15" r=".7"><stop offset="0" stop-color="#ffe29a" stop-opacity=".75"/><stop offset="1" stop-color="#ffe29a" stop-opacity="0"/></radialGradient>
  </defs>
  <rect width="440" height="622" fill="#fff8f0"/>
  <path d="M0 0h440v262c-90 34-250 40-440 6z" fill="url(#pbg)"/>
  <path d="M0 0h440v262c-90 34-250 40-440 6z" fill="url(#glow)"/>
  <g opacity=".35" filter="url(#blur1)">
    <circle cx="380" cy="48" r="26" fill="#fff"/><circle cx="52" cy="210" r="14" fill="#fff"/><circle cx="330" cy="200" r="8" fill="#fff"/>
    <path d="M92 44l5 12 12 5-12 5-5 12-5-12-12-5 12-5z" fill="#fff"/><path d="M300 110l3 8 8 3-8 3-3 8-3-8-8-3 8-3z" fill="#fff"/>
  </g>
  <text x="34" y="64" fill="#fff" font-family="Inter" font-size="15" font-weight="700" letter-spacing="3">SHARMA GENERAL STORE</text>
  <text x="32" y="132" fill="#fff" font-family="Inter" font-size="62" font-weight="900" letter-spacing="-2">CLEARANCE</text>
  <text x="34" y="176" fill="#fff" font-family="Inter" font-size="40" font-weight="300" letter-spacing="10">SALE</text>
  <text x="34" y="222" fill="#fff" class="hi" font-size="23" font-weight="700">भारी छूट · सीमित स्टॉक</text>
  <g transform="translate(374 200) rotate(-10)"><circle r="46" fill="#ffd60a"/><text y="-8" text-anchor="middle" font-family="Inter" font-size="12" font-weight="700" fill="#b3261e">UP TO</text><text y="20" text-anchor="middle" font-family="Inter" font-size="30" font-weight="900" fill="#b3261e" letter-spacing="-1">15%</text><text y="35" text-anchor="middle" font-family="Inter" font-size="11" font-weight="800" fill="#b3261e">OFF</text></g>
  ${items.map(([key, name, size, was, now], i) => {
    const x = 26 + (i % 2) * 200, y = 292 + Math.floor(i / 2) * 142;
    return `<g transform="translate(${x} ${y})">
      <rect width="188" height="130" rx="14" fill="#fff" stroke="#f1e4d6"/>
      <svg x="8" y="14" width="78" height="100" viewBox="0 0 100 100">${productArt[key]('pa' + i).replace(/^<svg[^>]*>|<\/svg>$/g, '')}</svg>
      <text x="88" y="36" font-family="Inter" font-size="12" font-weight="700" fill="#1d1d1f">${name}</text>
      <text x="88" y="52" font-family="Inter" font-size="12" font-weight="500" fill="#6e6e73">${size}</text>
      <text x="88" y="78" font-family="Inter" font-size="13" font-weight="500" fill="#8e8e93" text-decoration="line-through">₹${was}</text>
      <text x="86" y="110" font-family="Inter" font-size="32" font-weight="900" fill="#e0182d" letter-spacing="-1">₹${now}</text>
    </g>`;
  }).join('')}
  <rect x="0" y="584" width="440" height="38" fill="#1d1d1f"/>
  <text x="26" y="607" font-family="Inter" font-size="12" font-weight="600" fill="#fff">26–30 September, while stock lasts</text>
  <text x="414" y="607" text-anchor="end" font-family="Inter" font-size="12" font-weight="500" fill="#c7c7cc">Prices include GST</text>
</svg></div>`;
}

function posters() {
  const picks = [['bhujia', 'Bhujia 200 g', 'Last sold 41 days ago · 35 in stock', 55, 49], ['coffee', 'Instant Coffee 50 g', 'Last sold 38 days ago · 9 in stock', 175, 155], ['dishwash', 'Dishwash Liquid 500 ml', 'Last sold 52 days ago · 9 in stock', 99, 84], ['shampoo', 'Shampoo 180 ml', 'Last sold 35 days ago · 14 in stock', 160, 139]];
  const content = `<main class="content">
  <div class="poster-page">
    <div>
      <div class="page-head" style="margin-bottom:18px">
        <div>
          <h1 class="title">Posters</h1>
          <p class="lead">A4 posters for the shop, chosen from what’s selling and what isn’t.</p>
        </div>
      </div>
      <section class="card form-card">
        <div class="field"><div class="field-label">Kind of poster</div>
          <div class="segmented"><span class="on">Clearance</span><span>New arrivals</span><span>Best sellers</span><span>Festival offer</span></div></div>
        <div class="field"><div class="field-label">How many products</div>
          <div class="segmented"><span>1</span><span>2</span><span class="on">4</span><span>6</span></div></div>
        <div class="field"><div class="field-label">The AI picked these</div>
          <ul class="picks">
            ${picks.map(([k, n, why, was, now], i) => `<li class="pick"><span class="check">${icon('check')}</span><span class="thumb">${productArt[k]('pk' + i)}</span>
              <div><div class="name">${n}</div><div class="why">${why}</div></div>
              <div class="price"><s>₹${was}</s><b>₹${now}</b></div></li>`).join('')}
          </ul>
          <div class="note">${icon('info')}<span>Offers never go below cost. The POS prices stay as they are, so change them at the counter before you put the poster up.</span></div>
        </div>
      </section>
      <div class="actions" style="margin-top:18px"><span class="button big">${icon('sparkles')}Make it again</span><span class="button big soft">${icon('printer')}Print</span></div>
    </div>
    <div class="paper-wrap">
      ${posterPaper()}
      <div class="paper-caption">Artwork by ChatGPT Images. Product names and prices are printed by the app, exactly as in your POS.</div>
    </div>
  </div>
</main>`;
  return windowFrame(`<div class="app">${sidebar('posters')}${content}</div>`);
}

function setup() {
  const inner = `<div class="setup">
  <aside class="setup-rail">
    <div class="brand">${appIcon(44)}<div><b>Smart Retail POS</b><small>Get started</small></div></div>
    <div class="rail-step done"><span class="mark">${icon('check')}</span><div><b>Your shop’s data</b><small>Found on this PC · only read</small></div></div>
    <div class="rail-step now"><span class="mark">2</span><div><b>The AI</b><small>Sign in with ChatGPT</small></div></div>
    <div class="rail-step"><span class="mark">3</span><div><b>Photos and plans</b><small>Drive D: · 212 GB free</small></div></div>
    <div class="rail-foot">${icon('lock')}<span>Nothing here changes your POS.<br>You can come back to this any time.</span></div>
  </aside>
  <main class="setup-main"><div class="inner">
    <div class="kicker">Step 2 of 3</div>
    <h1>Connect the AI</h1>
    <p class="lead">The AI tool is installed. Sign in once with your ChatGPT account — the same one you use on chatgpt.com.</p>
    <section class="card code-card">
      <div class="code-step"><span class="n">1</span><div>
        <div class="t">Open the sign-in page<small>On this PC or on your phone: auth.openai.com/codex/device</small></div>
        <span class="button">Open the sign-in page ${icon('external')}</span></div></div>
      <div class="code-step"><span class="n">2</span><div>
        <div class="t">Type this code there</div>
        <div class="code">${'WRB5'.split('').map((c) => `<span class="ch">${c}</span>`).join('')}<em></em>${'1KWS7'.split('').map((c) => `<span class="ch">${c}</span>`).join('')}<span class="button soft">${icon('copy')}Copy</span></div></div></div>
    </section>
    <div class="wait"><span class="spinner"></span>Waiting for you to sign in. This page moves on by itself.</div>
    <div class="alt-link">Use an OpenAI API key instead</div>
  </div></main>
</div>`;
  return windowFrame(inner);
}

function panel() {
  const pos = `<div class="pos">
  <div class="pos-title">Billing — POS</div>
  <div class="pos-menu"><span>File</span><span>Billing</span><span>Stock</span><span>Reports</span><span>Help</span></div>
  <div class="pos-body">
    <div class="grid"><table>
      <tr><th>#</th><th>Item</th><th>Qty</th><th>Rate</th><th>Amount</th></tr>
      ${[['Basmati Rice 5 kg', 1, 549], ['Toned Milk 500 ml', 4, 28], ['Glucose Biscuits 200 g', 3, 20], ['Desi Ghee 1 L', 1, 640], ['Tea 250 g', 1, 140]]
        .map(([n, q, r], i) => `<tr><td>${i + 1}</td><td>${n}</td><td>${q}</td><td>${r.toFixed(2)}</td><td>${(q * r).toFixed(2)}</td></tr>`).join('')}
      ${Array.from({ length: 12 }, () => '<tr><td>&nbsp;</td><td></td><td></td><td></td><td></td></tr>').join('')}
    </table></div>
    <div>
      <div class="box">Customer: Cash<br><br>Items: 10<br>Discount: 0.00<br>GST: 64.05</div>
      <div class="total">1,501.00</div>
    </div>
  </div>
</div>`;
  const side = `<div class="panel light">
  <div class="panel-head">${appIcon(28)}<b>Smart Retail AI</b><div class="tools"><span class="round">${icon('expand')}</span><span class="round">${icon('close')}</span></div></div>
  <div class="mini-stats">
    <div class="card mini-stat"><div class="label">Sales today</div><div class="v">₹48,260</div><div class="d up">▲ 7.5% vs last Sat</div></div>
    <div class="card mini-stat"><div class="label">Bills today</div><div class="v">132</div><div class="d muted">₹366 average</div></div>
  </div>
  <div class="panel-thread">
    <div class="msg-ai"><div class="ai-mark">${icon('sparkles')}</div><div class="body bubble-ai">Good evening. Two things need a look:
      <ul class="mini-list"><li><b>Paneer 200 g</b>: 8 left, and it sells about 9 a day.</li><li><b>4 slow products</b> could clear with a poster.</li></ul></div></div>
    <div class="msg-user">Price of Desi Ghee 1 L?</div>
    <div class="msg-ai"><div class="ai-mark">${icon('sparkles')}</div><div class="body bubble-ai"><b>₹640</b> (MRP ₹675). 7 in stock; last sold 20 minutes ago.</div></div>
    <div class="msg-user">How much did we sell yesterday?</div>
    <div class="msg-ai"><div class="ai-mark">${icon('sparkles')}</div><div class="body bubble-ai"><b>₹44,890</b> from 121 bills, 3% more than the Friday before.</div></div>
  </div>
  <div class="panel-foot">
    <div class="chips"><span class="chip">Today’s sales</span><span class="chip">Low stock</span><span class="chip accent">${icon('expand')}Open the full app</span></div>
    <div class="composer">Ask anything…<span class="send">${icon('arrowup')}</span></div>
    <div class="hint"><kbd class="k">Ctrl</kbd> <kbd class="k">Shift</kbd> <kbd class="k">Space</kbd> shows or hides this panel</div>
  </div>
</div>`;
  return `<div class="window light" style="grid-template-rows:minmax(0,1fr)"><div style="position:relative;height:100%;overflow:hidden">${pos}${side}</div></div>`;
}

page('1-today.html', today(false));
page('2-today-dark.html', today(true), { dark: true });
page('3-ask-ai.html', ask());
page('4-product-photos.html', photos());
page('5-posters.html', posters());
page('6-get-started.html', setup());
page('7-side-panel.html', panel());
page('8-top-bar.html', today(false, { topBar: true, bellOpen: true }));
page('9-top-bar-dark.html', today(true, { topBar: true }), { dark: true });
console.log('pages written');
