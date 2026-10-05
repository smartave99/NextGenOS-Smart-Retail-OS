// A small stand-in for a Supabase project on this PC, for the owner view's browser test: Supabase's own database
// image with cloud/supabase-owner-view.sql, and PostgREST (the API Supabase serves under /rest/v1) behind a proxy
// that adds that path. Needs Docker. Nothing here touches a real Supabase project.
const { execFileSync, spawn } = require('child_process');
const crypto = require('crypto');
const http = require('http');
const path = require('path');
const fs = require('fs');

const DATABASE = process.env.SUPABASE_POSTGRES_IMAGE || 'public.ecr.aws/supabase/postgres:17.6.1.177';
const POSTGREST = process.env.SUPABASE_POSTGREST_IMAGE || 'public.ecr.aws/supabase/postgrest:v13.0.7';
const SCHEMA = path.join(__dirname, '../../cloud/supabase-owner-view.sql');
const MFA_FACTORS = path.join(__dirname, '../../cloud/test/auth-mfa-factors.sql');

const run = (args, input) => execFileSync('docker', args, { input, encoding: 'utf8', stdio: ['pipe', 'pipe', 'pipe'] });

function hasDocker() {
  try { run(['version', '--format', '{{.Server.Version}}']); return true; } catch { return false; }
}

// An HS256 token like Supabase's older keys.
function token(payload, secret) {
  const part = (o) => Buffer.from(JSON.stringify(o)).toString('base64url');
  const body = part({ alg: 'HS256', typ: 'JWT' }) + '.' + part(payload);
  return body + '.' + crypto.createHmac('sha256', secret).update(body).digest('base64url');
}

async function start() {
  const id = crypto.randomBytes(4).toString('hex');
  const names = { network: 'srpos-owner-' + id, db: 'srpos-owner-db-' + id, api: 'srpos-owner-api-' + id };
  const password = crypto.randomBytes(16).toString('hex');
  const secret = crypto.randomBytes(32).toString('hex');
  run(['network', 'create', names.network]);
  run(['run', '-d', '--name', names.db, '--network', names.network, '-e', 'POSTGRES_PASSWORD=' + password, DATABASE]);

  const psql = (sql, user = 'postgres') => run(['exec', '-i', '-e', 'PGOPTIONS=--client-min-messages=warning', names.db,
    'psql', '-h', 'localhost', '-U', user, '-d', 'postgres', '-v', 'ON_ERROR_STOP=1', '-q', '-At'], sql).trim();
  for (let i = 0; ; i++) {
    try { psql('select 1'); break; } catch (e) { if (i > 90) throw e; await new Promise(r => setTimeout(r, 1000)); }
  }
  psql(`alter role authenticator with password '${password}';`, 'supabase_admin');
  psql(fs.readFileSync(MFA_FACTORS, 'utf8'), 'supabase_admin');
  psql(fs.readFileSync(SCHEMA, 'utf8'));

  run(['run', '-d', '--name', names.api, '--network', names.network,
    '-e', `PGRST_DB_URI=postgres://authenticator:${password}@${names.db}:5432/postgres`,
    '-e', 'PGRST_DB_SCHEMAS=public', '-e', 'PGRST_DB_ANON_ROLE=anon', '-e', 'PGRST_JWT_SECRET=' + secret, POSTGREST]);
  const apiAddress = run(['inspect', '-f', `{{(index .NetworkSettings.Networks "${names.network}").IPAddress}}`, names.api]).trim();

  // Supabase serves PostgREST under /rest/v1; the proxy takes that off, as Supabase's gateway does.
  const proxy = http.createServer((req, res) => {
    if (!req.url.startsWith('/rest/v1/')) { res.writeHead(404).end(); return; }
    const forward = http.request({ host: apiAddress, port: 3000, path: req.url.slice('/rest/v1'.length), method: req.method, headers: req.headers }, answer => {
      res.writeHead(answer.statusCode, answer.headers);
      answer.pipe(res);
    });
    forward.on('error', () => { res.writeHead(502).end(); });
    req.pipe(forward);
  });
  await new Promise(r => proxy.listen(0, '127.0.0.1', r));
  const url = `http://127.0.0.1:${proxy.address().port}`;

  for (let i = 0; ; i++) {
    const ok = await fetch(url + '/rest/v1/', { headers: { apikey: 'x' } }).then(r => r.status < 500).catch(() => false);
    if (ok) break;
    if (i > 60) throw new Error('PostgREST did not start');
    await new Promise(r => setTimeout(r, 1000));
  }

  const now = Math.floor(Date.now() / 1000);
  return {
    url,
    anonKey: token({ iss: 'supabase', ref: 'local', role: 'anon', iat: now, exp: now + 3600 }, secret),
    serviceKey: token({ iss: 'supabase', ref: 'local', role: 'service_role', iat: now, exp: now + 3600 }, secret),
    psql,
    // Runs SQL as a signed-in person, as the website does through Supabase.
    asUser: (userId, sql) => psql(`set role authenticated; set request.jwt.claim.sub = '${userId}'; ${sql}`),
    stop: () => {
      proxy.close();
      for (const name of [names.api, names.db]) { try { run(['rm', '-f', name]); } catch { /* gone */ } }
      try { run(['network', 'rm', names.network]); } catch { /* gone */ }
    },
  };
}

module.exports = { hasDocker, start };
