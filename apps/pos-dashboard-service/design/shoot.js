// Renders every preview page to a PNG. Run: NODE_PATH=/opt/node22/lib/node_modules node shoot.js [page-prefix]
const { chromium } = require('playwright');
const fs = require('fs');
const http = require('http');
const path = require('path');

const types = { '.html': 'text/html; charset=utf-8', '.css': 'text/css', '.woff2': 'font/woff2', '.ttf': 'font/ttf' };
const server = http.createServer((req, res) => {
  const file = path.join(__dirname, decodeURIComponent(req.url.split('?')[0]));
  if (!file.startsWith(__dirname) || !fs.existsSync(file)) { res.writeHead(404); return res.end(); }
  res.writeHead(200, { 'Content-Type': types[path.extname(file)] || 'application/octet-stream' });
  fs.createReadStream(file).pipe(res);
});

(async () => {
  await new Promise(r => server.listen(8765, '127.0.0.1', r));
  const only = process.argv[2] || '';
  const pages = fs.readdirSync(__dirname).filter(f => /^\d-.*\.html$/.test(f) && f.startsWith(only)).sort();
  fs.mkdirSync(path.join(__dirname, 'png'), { recursive: true });
  const browser = await chromium.launch();
  const context = await browser.newContext({ viewport: { width: 1440, height: 900 }, deviceScaleFactor: 2 });
  const page = await context.newPage();
  const errors = [];
  page.on('console', m => { if (m.type() === 'error') errors.push(m.text()); });
  page.on('requestfailed', r => errors.push('failed: ' + r.url()));
  for (const f of pages) {
    await page.goto('http://127.0.0.1:8765/' + f, { waitUntil: 'networkidle' });
    await page.evaluate(() => document.fonts.ready);
    const fonts = await page.evaluate(() => [...document.fonts].filter(x => x.status === 'loaded').map(x => x.family));
    await page.screenshot({ path: path.join(__dirname, 'png', f.replace('.html', '.png')) });
    console.log(f, 'fonts:', [...new Set(fonts)].join(', '));
  }
  if (errors.length) console.log('errors:', errors);
  await browser.close();
  server.close();
})().catch(e => { console.error(e); process.exit(1); });
