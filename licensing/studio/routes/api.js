'use strict';
// The calls the apps make: activate, check in, deactivate, revocation list. Specified in spec/LICENCE-FORMAT.md section 8.

const { ApiError } = require('../lib/studio');
const { readJson, sendJson, RateLimiter } = require('../lib/http');

function createApi({ studio, clientIp, clock }) {
  const perIp = new RateLimiter(60, 60, clock);          // all calls: 60 a minute per address
  const failures = new RateLimiter(10, 600, clock);       // wrong keys: 10 in 10 minutes per address

  return async function handle(req, res, url) {
    const ip = clientIp(req);
    try {
      if (!perIp.take(ip)) throw new ApiError(429, 'rate_limited', 'Too many requests. Please wait a minute.');
      const route = `${req.method} ${url.pathname}`;

      if (route === 'GET /api/v1/health') return sendJson(res, 200, { ok: true });
      if (route === 'GET /api/v1/crl') return sendJson(res, 200, { crl: studio.crlToken() });
      if (route === 'GET /api/v1/keys') return sendJson(res, 200, { keys: studio.trustedKeys() });

      if (req.method === 'POST' && ['/api/v1/activate', '/api/v1/checkin', '/api/v1/deactivate'].includes(url.pathname)) {
        const body = await readJson(req);
        if (url.pathname === '/api/v1/activate') {
          if (typeof body.key !== 'string') throw new ApiError(400, 'bad_request', 'The licence key is missing.');
          try {
            return sendJson(res, 200, studio.activate({ key: body.key, version: body.version, fp: body.fp, host: body.host }, ip));
          } catch (e) {
            if (e instanceof ApiError && e.code === 'unknown_key' && !failures.take(ip)) throw new ApiError(429, 'rate_limited', 'Too many wrong keys. Please wait ten minutes.');
            throw e;
          }
        }
        if (typeof body.lid !== 'string' || typeof body.act !== 'string') throw new ApiError(400, 'bad_request', 'The request is incomplete.');
        if (url.pathname === '/api/v1/checkin') return sendJson(res, 200, studio.checkin({ lid: body.lid, act: body.act, fp: body.fp, version: body.version, usage: body.usage }, ip));
        return sendJson(res, 200, studio.deactivate({ lid: body.lid, act: body.act, fp: body.fp }, ip));
      }
      throw new ApiError(404, 'not_found', 'Unknown call.');
    } catch (e) {
      if (e instanceof ApiError) return sendJson(res, e.status, { error: { code: e.code, message: e.message } });
      console.error('API error:', e);
      return sendJson(res, 500, { error: { code: 'server_error', message: 'Something went wrong on the licence server.' } });
    }
  };
}

module.exports = { createApi };
