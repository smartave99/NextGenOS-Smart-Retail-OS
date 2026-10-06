// The Brand Studio's wizard: a small web page on this PC only (127.0.0.1), opened with a secret address that is new every time it starts.
// It only reads and writes brand kits (brand-kits/) and the files made from them (brand-exports/). Nothing leaves this PC.
import http from 'node:http';
import { randomBytes, timingSafeEqual } from 'node:crypto';
import { WIZARD_HTML, WIZARD_CSS, WIZARD_JS } from './wizard.mjs';
import { listKits, loadKit, saveKit, readLogo, check, countryCodes, industryIds, inspectLogo, repoRoot, SLUG } from './kit.mjs';
import { previewHtml, logoDataUri } from './preview.mjs';
import { makeExports } from './exports.mjs';

const MAX_BODY = 600_000;

function dataUriBytes(uri) {
  const m = /^data:image\/(png|jpeg|svg\+xml);base64,([A-Za-z0-9+/=]+)$/.exec(uri || '');
  return m ? Buffer.from(m[2], 'base64') : null;
}

/** Starts the wizard. Returns { server, url, token, close }. */
export function startServer({ root = repoRoot, port = 0, onBeat = null, onQuit = null } = {}) {
  const token = randomBytes(18).toString('base64url');
  const tokenBuf = Buffer.from(token);

  const send = (res, status, body, type = 'application/json; charset=utf-8') => {
    res.writeHead(status, {
      'Content-Type': type,
      'Cache-Control': 'no-store',
      'X-Content-Type-Options': 'nosniff',
      'Referrer-Policy': 'no-referrer',
      'Cross-Origin-Resource-Policy': 'same-origin',
      'Content-Security-Policy': "default-src 'self'; style-src 'self' 'unsafe-inline'; script-src 'self'; frame-src 'self'; img-src 'self' data:; base-uri 'none'; form-action 'none'; frame-ancestors 'none'",
    });
    res.end(typeof body === 'string' || Buffer.isBuffer(body) ? body : JSON.stringify(body));
  };
  const fail = (res, status, message, problems) => send(res, status, { error: message, problems });
  const authorised = (req) => {
    const given = Buffer.from(String(req.headers['x-brand-studio'] || ''));
    return given.length === tokenBuf.length && timingSafeEqual(given, tokenBuf);
  };
  const body = (req) => new Promise((resolve, reject) => {
    const chunks = []; let size = 0;
    req.on('data', (c) => { size += c.length; if (size > MAX_BODY) { reject(new Error('That is too much to send at once.')); req.destroy(); } else chunks.push(c); });
    req.on('end', () => { try { resolve(chunks.length ? JSON.parse(Buffer.concat(chunks).toString('utf8')) : {}); } catch { reject(new Error('That was not understood.')); } });
    req.on('error', reject);
  });

  const server = http.createServer(async (req, res) => {
    try {
      // Only this PC's own name for itself: a web page on another site cannot reach this wizard by pointing its own name at 127.0.0.1.
      const host = String(req.headers.host || '');
      if (host !== `127.0.0.1:${server.address().port}` && host !== `localhost:${server.address().port}`) return fail(res, 403, 'Not allowed.');
      const url = new URL(req.url, 'http://127.0.0.1');
      const path = url.pathname;

      if (req.method === 'GET' && path === '/') return send(res, 200, WIZARD_HTML, 'text/html; charset=utf-8');
      if (req.method === 'GET' && path === '/wizard.css') return send(res, 200, WIZARD_CSS, 'text/css; charset=utf-8');
      if (req.method === 'GET' && path === '/wizard.js') return send(res, 200, WIZARD_JS, 'text/javascript; charset=utf-8');
      if (!path.startsWith('/api/')) return fail(res, 404, 'Not found.');

      if (!authorised(req)) return fail(res, 401, 'Open the Brand Studio with the address it printed (it ends with ?k=...).');
      // A form from another web site cannot send this header, and a fetch from another origin is stopped by the browser; this makes it explicit.
      const port = server.address().port;
      if (req.headers.origin && req.headers.origin !== `http://127.0.0.1:${port}` && req.headers.origin !== `http://localhost:${port}`) return fail(res, 403, 'Not allowed.');

      // The page says it is still open (so a Brand Studio that nobody is looking at can stop by itself), and the person can quit it from the page.
      if (req.method === 'GET' && path === '/api/alive') { if (onBeat) onBeat(); return send(res, 200, { ok: true }); }
      if (req.method === 'POST' && path === '/api/quit') {
        if (!onQuit) return fail(res, 409, 'This Brand Studio is stopped by closing the window or the terminal it was started from.');
        send(res, 200, { ok: true });
        setTimeout(onQuit, 200);
        return undefined;
      }
      if (req.method === 'GET' && path === '/api/options') return send(res, 200, { kits: listKits(root), countries: countryCodes(root) || countryCodes(repoRoot) || [], industries: industryIds(root) || industryIds(repoRoot) || [] });

      let m = /^\/api\/kit\/([^/]+)$/.exec(path);
      if (m) {
        const slug = decodeURIComponent(m[1]);
        if (!SLUG.test(slug)) return fail(res, 400, 'A kit name has 2 to 41 small letters, numbers or dashes, like luzon-fresh.');
        if (req.method === 'GET') {
          const { folder, kit } = loadKit(slug, root);
          const bytes = readLogo(slug, root);
          const info = bytes ? inspectLogo(bytes) : { kind: null };
          const { warnings } = check(kit, { folder, countries: countryCodes(root), industries: industryIds(root) });
          return send(res, 200, { kit, logo: bytes && info.kind ? logoDataUri(bytes, info.kind) : null, warnings });
        }
        if (req.method === 'POST') {
          const input = await body(req);
          const logoBytes = input.logo ? dataUriBytes(input.logo) : null;
          if (input.logo && !logoBytes) return fail(res, 400, 'The logo must be a PNG, JPEG or SVG picture.');
          let kit = input.kit || {};
          if (!logoBytes && input.keepLogo) {
            try { const old = loadKit(slug, root).kit; if (old.logo) kit = { ...kit, logo: old.logo }; } catch { /* a new kit has none */ }
          }
          try { const r = saveKit(slug, kit, { logoBytes, root }); return send(res, 200, { warnings: r.warnings }); }
          catch (e) { return fail(res, 400, e.message, e.problems || [e.message]); }
        }
      }
      if (req.method === 'POST' && path === '/api/preview') {
        const input = await body(req);
        const bytes = input.logo ? dataUriBytes(input.logo) : null;
        const info = bytes ? inspectLogo(bytes) : { kind: null };
        const uri = bytes && info.kind && !info.problem ? logoDataUri(bytes, info.kind) : null;
        return send(res, 200, { html: previewHtml({ primaryColor: '#0f6cbd', ...(input.kit || {}), name: String(input.kit?.name || 'Your business') }, uri) });
      }
      m = /^\/api\/export\/([^/]+)$/.exec(path);
      if (m && req.method === 'POST') {
        const slug = decodeURIComponent(m[1]);
        if (!SLUG.test(slug)) return fail(res, 400, 'A kit name has 2 to 41 small letters, numbers or dashes.');
        try { const r = makeExports(slug, { root }); return send(res, 200, r); } catch (e) { return fail(res, 400, e.message, e.problems); }
      }
      return fail(res, 404, 'Not found.');
    } catch (e) {
      return fail(res, 500, e.message || 'Something went wrong.');
    }
  });

  return new Promise((resolve, reject) => {
    server.on('error', reject);
    server.listen(port, '127.0.0.1', () => {
      const p = server.address().port;
      resolve({ server, token, url: `http://127.0.0.1:${p}/?k=${token}`, close: () => new Promise((r) => server.close(r)) });
    });
  });
}
