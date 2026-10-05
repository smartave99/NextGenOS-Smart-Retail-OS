#!/usr/bin/env node
'use strict';
// Command line for the person who sets the Studio up and for scripts. Sales staff use the web pages instead.

const fs = require('node:fs');
const path = require('node:path');
const readline = require('node:readline/promises');
const config = require('./config').load();
const { open, now } = require('../lib/db');
const keystore = require('../lib/keystore');
const { Studio, ApiError } = require('../lib/studio');
const { Auth } = require('../lib/auth');
const C = require('../lib/crypto');

const REPO = path.resolve(__dirname, '..', '..', '..');
const TARGETS = {
  dotnet: path.join(REPO, 'licensing', 'clients', 'dotnet', 'NextGenOS.Licensing', 'LicenceDefaults.cs'),
  storefront: path.join(REPO, 'apps', 'storefront-web-mobile', 'src', 'lib', 'licence', 'defaults.ts'),
};

function parseArgs(argv) {
  const positional = [];
  const flags = {};
  for (let i = 0; i < argv.length; i += 1) {
    const a = argv[i];
    if (a.startsWith('--')) {
      const eq = a.indexOf('=');
      if (eq > 0) flags[a.slice(2, eq)] = a.slice(eq + 1);
      else if (argv[i + 1] !== undefined && !argv[i + 1].startsWith('--')) { flags[a.slice(2)] = argv[i + 1]; i += 1; } else flags[a.slice(2)] = true;
    } else positional.push(a);
  }
  return { positional, flags };
}

function tempPassword() {
  for (;;) {
    const p = Array.from({ length: 3 }, () => C.generateLicenceKey().slice(5, 9)).join('-');
    if (/[A-Z]/.test(p) && /[0-9]/.test(p)) return p;
  }
}

function openStudio() {
  const db = open(config.dataDir);
  const signer = keystore.loadSigner(db, config.dataDir);
  const studio = new Studio({ db, signer });
  studio.seedDefaults();
  return { db, studio, auth: new Auth(db) };
}

const actor = { id: null, email: 'cli', role: 'admin' };

const commands = {
  async init(flags) {
    const db = open(config.dataDir);
    const studio = new Studio({ db, signer: null });
    studio.seedDefaults();
    let created = null;
    if (!db.prepare('SELECT 1 FROM keys LIMIT 1').get()) {
      created = keystore.createKey(db, config.dataDir, now());
      console.log(`Created the signing key ${created.kid}.`);
      console.log('  Its private half is stored encrypted in ' + path.join(config.dataDir, 'keys') + '.');
      console.log('  The passphrase is in ' + path.join(config.dataDir, 'passphrase.txt') + ' (move it to the STUDIO_PASSPHRASE setting on a real server).');
    } else console.log('The signing key already exists. Nothing changed.');

    const auth = new Auth(db);
    if (!db.prepare("SELECT 1 FROM users WHERE role = 'admin' LIMIT 1").get()) {
      let email = flags['admin-email'];
      let name = flags['admin-name'];
      if (!email && process.stdin.isTTY) {
        const rl = readline.createInterface({ input: process.stdin, output: process.stdout });
        email = await rl.question('Administrator e-mail: ');
        name = name || await rl.question('Administrator name: ');
        rl.close();
      }
      if (!email) throw new Error('Give the first administrator with --admin-email you@company.com --admin-name "Your Name".');
      const password = tempPassword();
      auth.createUser({ email, name: name || email, role: 'admin', password, mustChange: true });
      console.log(`\nFirst administrator: ${email}\nTemporary password (shown once): ${password}\nYou will be asked to choose your own at the first sign-in.`);
    }
    db.close();
    console.log(`\nNext:\n  1. node src/server.js        (starts the Studio)\n  2. Open http://127.0.0.1:${config.port} and sign in.\n  3. node src/cli.js sync-clients --url https://your-studio-address   (builds the public key into the apps)`);
  },

  async 'add-user'(flags) {
    const { db, auth, studio } = openStudio();
    const password = tempPassword();
    auth.createUser({ email: flags.email, name: flags.name, role: flags.role || 'sales', password, mustChange: true });
    studio.audit(actor, 'user.create', flags.email, flags.role || 'sales', 'cli');
    console.log(`Created ${flags.email}. Temporary password (shown once): ${password}`);
    db.close();
  },

  async 'reset-password'(flags, [email]) {
    const { db, auth } = openStudio();
    const row = db.prepare('SELECT id FROM users WHERE email = ?').get(String(email || flags.email || '').toLowerCase());
    if (!row) throw new Error('No such user.');
    const password = tempPassword();
    auth.setPassword(row.id, password, true);
    console.log(`New temporary password (shown once): ${password}`);
    db.close();
  },

  async 'create-licence'(flags) {
    const { db, studio } = openStudio();
    let customer = db.prepare('SELECT * FROM customers WHERE name = ?').get(flags.customer);
    if (!customer) customer = studio.createCustomer({ name: flags.customer, country: flags.country, email: flags.email }, actor, 'cli');
    const lic = studio.createLicence({
      customerId: customer.id, planCode: flags.plan || 'business', term: flags.term || 'y1', devices: flags.devices, stores: flags.stores, users: flags.users,
      bindMode: flags.bind || 'device', domains: flags.domains, offline: !!flags.offline, whiteLevel: flags.white || 'theme', startDate: flags.start,
    }, actor, 'cli');
    console.log(JSON.stringify({ lid: lic.lid, key: lic.licence_key, exp: lic.exp }));
    db.close();
  },

  async revoke(flags, [lid]) { setStatus(lid, 'revoked', flags.reason); },
  async suspend(flags, [lid]) { setStatus(lid, 'suspended', flags.reason); },
  async resume(flags, [lid]) { setStatus(lid, 'active', ''); },

  async 'offline-activate'(flags, [request]) {
    const { db, studio } = openStudio();
    console.log(studio.offlineActivate(request, actor, 'cli'));
    db.close();
  },

  async list() {
    const { db, studio } = openStudio();
    for (const l of studio.listLicences()) console.log(`${l.lid}  ${l.licence_key}  ${l.status.padEnd(9)} ${l.plan_code.padEnd(9)} ${l.customer_name}  ends ${l.exp ? new Date(l.exp * 1000).toISOString().slice(0, 10) : 'never'}  PCs ${l.devices_in_use}/${l.limits.devices}`);
    db.close();
  },

  async 'export-public-keys'() {
    const { db, studio } = openStudio();
    console.log(JSON.stringify({ keys: studio.trustedKeys() }, null, 2));
    db.close();
  },

  async 'sync-clients'(flags) {
    const { db, studio } = openStudio();
    const keys = studio.trustedKeys();
    const url = String(flags.url || studio.setting('public_url') || '').replace(/\/+$/, '');
    if (!url) throw new Error('Say where the Studio will be reached: --url https://licence.yourcompany.com (or set it in Settings).');
    if (!/^https:\/\//.test(url) && !/^http:\/\/(localhost|127\.0\.0\.1)(:\d+)?$/.test(url)) throw new Error('The address must start with https:// (http:// only for this PC).');
    studio.setSetting('public_url', url);

    const cs = fs.readFileSync(TARGETS.dotnet, 'utf8');
    const keyLines = keys.map((k) => `            new TrustedKey("${k.kid}", "${k.publicKey}"),`).join('\n');
    fs.writeFileSync(TARGETS.dotnet, cs
      .replace(/\/\/ GENERATED-KEYS-BEGIN[\s\S]*?\/\/ GENERATED-KEYS-END/, `// GENERATED-KEYS-BEGIN\n${keyLines}\n            // GENERATED-KEYS-END`)
      .replace(/\/\/ GENERATED-URL-BEGIN[\s\S]*?\/\/ GENERATED-URL-END/, `// GENERATED-URL-BEGIN\n        public const string ServerUrl = "${url}";\n        // GENERATED-URL-END`));

    fs.mkdirSync(path.dirname(TARGETS.storefront), { recursive: true });
    fs.writeFileSync(TARGETS.storefront, `// Written by "node src/cli.js sync-clients" (licensing/studio). Public keys only.\nexport const TRUSTED_KEYS: { kid: string; publicKey: string }[] = ${JSON.stringify(keys.map((k) => ({ kid: k.kid, publicKey: k.publicKey })), null, 2)};\nexport const LICENCE_SERVER_URL = ${JSON.stringify(url)};\n`);
    console.log(`Built ${keys.length} public key(s) and the address ${url} into:\n  ${TARGETS.dotnet}\n  ${TARGETS.storefront}\nNow rebuild the apps.`);
    db.close();
  },

  async backup(flags, [file]) {
    const { db } = openStudio();
    const out = path.resolve(file || `licence-studio-${new Date().toISOString().slice(0, 10)}.db`);
    db.exec(`VACUUM INTO '${out.replace(/'/g, "''")}'`);
    console.log(`Database copied to ${out}.\nAlso keep: ${path.join(config.dataDir, 'keys')} and the passphrase, somewhere safe and separate.`);
    db.close();
  },

  async status() {
    const { db, studio } = openStudio();
    console.log(JSON.stringify({ stats: studio.stats(), keys: db.prepare('SELECT kid, status FROM keys').all() }, null, 2));
    db.close();
  },
};

function setStatus(lid, status, reason) {
  const { db, studio } = openStudio();
  studio.setStatus(lid, status, reason, actor, 'cli');
  console.log(`${lid} is now ${status}.`);
  db.close();
}

async function main() {
  const { positional, flags } = parseArgs(process.argv.slice(2));
  const name = positional.shift();
  if (!name || !commands[name]) {
    console.log('NextGen OS Licence Studio: command line\n\nCommands:\n  init                    create the signing key and the first administrator\n  add-user                --email --name --role sales|support|admin\n  reset-password <email>\n  create-licence          --customer "Name" --plan business --term y1 [--devices N] [--bind domain --domains a.com]\n  list | status\n  revoke|suspend|resume <licence id> [--reason "..."]\n  offline-activate <request code>\n  sync-clients --url https://licence.example.com   build the public key into the apps\n  export-public-keys\n  backup [file]\n');
    process.exit(name ? 1 : 0);
  }
  try {
    await commands[name](flags, positional);
  } catch (e) {
    console.error(`\n${e instanceof ApiError ? e.message : (e.message || e)}\n`);
    process.exit(1);
  }
}

main();
