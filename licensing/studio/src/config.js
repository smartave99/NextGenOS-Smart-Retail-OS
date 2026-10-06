'use strict';
// Settings come from environment variables (or a .env file next to package.json). Defaults suit a trial on one PC.

const fs = require('node:fs');
const path = require('node:path');

function loadEnvFile(file) {
  if (!fs.existsSync(file)) return;
  for (const line of fs.readFileSync(file, 'utf8').split(/\r?\n/)) {
    const m = /^\s*([A-Z0-9_]+)\s*=\s*(.*?)\s*$/.exec(line);
    if (m && !(m[1] in process.env)) process.env[m[1]] = m[2].replace(/^["']|["']$/g, '');
  }
}

function load(root = path.join(__dirname, '..')) {
  loadEnvFile(path.join(root, '.env'));
  const env = process.env;
  return {
    root,
    dataDir: path.resolve(env.STUDIO_DATA || path.join(root, 'data')),
    host: env.HOST || '127.0.0.1',
    port: Number(env.PORT || 8080),
    trustProxy: env.TRUST_PROXY === '1',
    allowInsecure: env.ALLOW_INSECURE_HTTP === '1',
  };
}

module.exports = { load };
