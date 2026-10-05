'use strict';
// Builds the whole Studio (database, keys, API, pages) so that the server and the tests start it the same way.

const http = require('node:http');
const { open, now: unixNow } = require('../lib/db');
const keystore = require('../lib/keystore');
const { Studio } = require('../lib/studio');
const { Auth } = require('../lib/auth');
const H = require('../lib/http');
const { createApi } = require('../routes/api');
const { createUi } = require('../routes/ui');

function createApp({ dataDir, trustProxy = false, allowInsecure = false, clock }) {
  const db = open(dataDir);
  const signer = keystore.loadSigner(db, dataDir);
  const studio = new Studio({ db, signer, clock });
  studio.seedDefaults();
  const auth = new Auth(db, clock);
  const clientIp = (req) => H.clientIp(req, trustProxy);
  const isSecure = (req) => H.isSecureRequest(req, trustProxy);
  const api = createApi({ studio, clientIp, clock: clock ? () => clock() : undefined });
  const ui = createUi({ studio, auth, db, config: { allowInsecure }, clientIp, isSecure, clock, dataDir });

  const server = http.createServer(async (req, res) => {
    try {
      const url = new URL(req.url, 'http://studio.local');
      // Keys and passwords must not travel in clear text: only HTTPS, or this PC itself, is accepted.
      const local = H.isLoopback(String(req.socket.remoteAddress || '').replace(/^::ffff:/, ''));
      if (url.pathname !== '/api/v1/health' && !isSecure(req) && !local && !allowInsecure) {
        return H.send(res, 421, 'Please use https:// to open the Licence Studio.', { 'Content-Type': 'text/plain; charset=utf-8' });
      }
      if (isSecure(req)) res.setHeader('Strict-Transport-Security', 'max-age=31536000; includeSubDomains');
      if (url.pathname.startsWith('/api/')) return await api(req, res, url);
      return await ui(req, res, url);
    } catch (e) {
      console.error('Unexpected error:', e);
      if (!res.headersSent) H.send(res, 500, 'Something went wrong. Please try again.', { 'Content-Type': 'text/plain; charset=utf-8' });
    }
  });
  server.requestTimeout = 30000;
  server.headersTimeout = 15000;
  return { server, db, studio, auth };
}

module.exports = { createApp };
