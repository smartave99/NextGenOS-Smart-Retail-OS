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

// Where the programs' source files are (the tests point this at a copy).
const REPO = process.env.NGOS_REPO_ROOT || path.resolve(__dirname, '..', '..', '..');
const TARGETS = {
  dotnet: path.join(REPO, 'licensing', 'clients', 'dotnet', 'NextGenOS.Licensing', 'LicenceDefaults.cs'),
  storefront: path.join(REPO, 'apps', 'storefront-web-mobile', 'src', 'lib', 'licence', 'defaults.ts'),
};

function checkUrl(url) {
  if (!/^https:\/\//.test(url) && !/^http:\/\/(localhost|127\.0\.0\.1)(:\d+)?$/.test(url)) throw new Error('The address must start with https:// (http:// only for this PC).');
}

/** Builds the public keys and the Studio's address into the programs' source files (public data only). */
function writeClients(keys, url) {
  const cs = fs.readFileSync(TARGETS.dotnet, 'utf8');
  const keyLines = keys.map((k) => `            new TrustedKey("${k.kid}", "${k.publicKey}"),`).join('\n');
  fs.writeFileSync(TARGETS.dotnet, cs
    .replace(/\/\/ GENERATED-KEYS-BEGIN[\s\S]*?\/\/ GENERATED-KEYS-END/, `// GENERATED-KEYS-BEGIN\n${keyLines}\n            // GENERATED-KEYS-END`)
    .replace(/\/\/ GENERATED-URL-BEGIN[\s\S]*?\/\/ GENERATED-URL-END/, `// GENERATED-URL-BEGIN\n        public const string ServerUrl = "${url}";\n        // GENERATED-URL-END`));

  fs.mkdirSync(path.dirname(TARGETS.storefront), { recursive: true });
  fs.writeFileSync(TARGETS.storefront, `// Written by "node src/cli.js sync-clients" (licensing/studio). Public keys only.\nexport const TRUSTED_KEYS: { kid: string; publicKey: string }[] = ${JSON.stringify(keys.map((k) => ({ kid: k.kid, publicKey: k.publicKey })), null, 2)};\nexport const LICENCE_SERVER_URL = ${JSON.stringify(url)};\n`);
  console.log(`Built ${keys.length} public key(s) and the address ${url} into:\n  ${TARGETS.dotnet}\n  ${TARGETS.storefront}\nNow rebuild the apps.`);
}

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
      bindMode: flags.bind || 'device', domains: flags.domains, offline: !!flags.offline, whiteLevel: flags.white || 'theme', startDate: flags.start, brandId: flags.brand,
    }, actor, 'cli');
    console.log(JSON.stringify({ lid: lic.lid, key: lic.licence_key, exp: lic.exp }));
    db.close();
  },

  async 'licence-file'(flags, [lid]) {
    const { db, studio } = openStudio();
    const l = studio.getLicence(lid);
    if (!l) throw new Error('No such licence.');
    process.stdout.write(studio.licenceFile(l));
    db.close();
  },

  async 'create-brand'(flags) {
    const { db, studio } = openStudio();
    const id = studio.saveBrand(null, { name: flags.name, shortName: flags.short, primaryColor: flags.primary, accentColor: flags.accent, supportEmail: flags.email, supportPhone: flags.phone, poweredBy: flags.powered === 'no' ? '' : 'on' }, actor, 'cli');
    console.log(JSON.stringify({ brand: id }));
    db.close();
  },

  async renew(flags, [lid]) {
    const { db, studio } = openStudio();
    const l = studio.updateLicence(lid, { extendTerm: flags.term || 'y1' }, actor, 'cli');
    console.log(JSON.stringify({ lid: l.lid, exp: l.exp, rev: l.rev }));
    db.close();
  },

  async change(flags, [lid]) {
    const { db, studio } = openStudio();
    const l = studio.updateLicence(lid, { planCode: flags.plan, devices: flags.devices, stores: flags.stores, users: flags.users, whiteLevel: flags.white }, actor, 'cli');
    console.log(JSON.stringify({ lid: l.lid, limits: l.limits, rev: l.rev }));
    db.close();
  },

  async 'free-devices'(flags, [lid]) {
    const { db, studio } = openStudio();
    let n = 0;
    for (const a of studio.listActivations(lid)) if (a.active) { studio.freeDevice(a.id, actor, 'cli'); n += 1; }
    console.log(`Released ${n} PC(s).`);
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
    const url = String(flags.url || studio.setting('public_url') || '').replace(/\/+$/, '');
    if (!url) throw new Error('Say where the Studio will be reached: --url https://licence.yourcompany.com (or set it in Settings).');
    checkUrl(url);
    studio.setSetting('public_url', url);
    writeClients(studio.trustedKeys(), url);
    db.close();
  },

  // For a build machine that has no Studio (the release workflow): the public keys come from "export-public-keys", kept as plain text in the
  // repository's settings. Public keys only; a file with anything private in it is refused.
  async 'apply-public-keys'(flags) {
    const raw = String(flags.keys || '');
    const text = raw.startsWith('@') ? fs.readFileSync(raw.slice(1), 'utf8') : raw;
    if (!text.trim()) throw new Error('Give the public keys: --keys @file.json (the output of export-public-keys) or --keys \'{"keys":[...]}\'.');
    if (/PRIVATE|"d"\s*:|privateKey|private_key|passphrase/i.test(text)) throw new Error('That looks like it holds a private key. Only the public keys (export-public-keys) may be built into the apps.');
    let parsed;
    try { parsed = JSON.parse(text); } catch (e) { throw new Error('The keys are not valid JSON.'); }
    const keys = Array.isArray(parsed) ? parsed : parsed.keys;
    if (!Array.isArray(keys) || !keys.length || !keys.every((k) => /^[A-Za-z0-9_-]{1,64}$/.test(k.kid || '') && /^[A-Za-z0-9+/=_-]{40,200}$/.test(k.publicKey || ''))) throw new Error('The keys must be a list of { kid, publicKey }.');
    const url = String(flags.url || '').replace(/\/+$/, '');
    if (!url) throw new Error('Say where the Studio is reached: --url https://licence.yourcompany.com');
    checkUrl(url);
    writeClients(keys, url);
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
    console.log('NextGenOS Licence Studio: command line\n\nCommands:\n  init                    create the signing key and the first administrator\n  add-user                --email --name --role sales|support|admin\n  reset-password <email>\n  create-licence          --customer "Name" --plan business --term y1 [--devices N] [--bind domain --domains a.com]\n  list | status\n  revoke|suspend|resume <licence id> [--reason "..."]\n  licence-file <licence id>   |   create-brand --name X [--primary #112233]\n  renew <licence id> [--term y1]   |   change <licence id> [--devices N --plan business]\n  free-devices <licence id>\n  offline-activate <request code>\n  sync-clients --url https://licence.example.com   build the public key into the apps\n  apply-public-keys --keys @keys.json --url https://licence.example.com   the same, on a machine without the Studio (release build)\n  export-public-keys\n  backup [file]\n');
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
