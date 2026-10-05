'use strict';
// "apply-public-keys": the release build, which has no Studio, builds the public keys into the programs from the text "export-public-keys" wrote.

const test = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { spawnSync } = require('node:child_process');

const cli = path.join(__dirname, '..', 'src', 'cli.js');
const repo = path.resolve(__dirname, '..', '..', '..');

function tree() {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), 'ngos-cli-'));
  for (const rel of ['licensing/clients/dotnet/NextGenOS.Licensing/LicenceDefaults.cs', 'apps/storefront-web-mobile/src/lib/licence/defaults.ts']) {
    fs.mkdirSync(path.dirname(path.join(root, rel)), { recursive: true });
    fs.copyFileSync(path.join(repo, rel), path.join(root, rel));
  }
  return root;
}
const run = (root, args, env = {}) => spawnSync('node', ['--no-warnings', cli, ...args], { env: { ...process.env, NGOS_REPO_ROOT: root, ...env }, encoding: 'utf8' });
const KEY = { kid: 'k-test-1', publicKey: 'MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAE' + 'A'.repeat(70) };

test('the public keys and the address are built into both programs, and nothing else changes', () => {
  const root = tree();
  const before = fs.readFileSync(path.join(root, 'licensing/clients/dotnet/NextGenOS.Licensing/LicenceDefaults.cs'), 'utf8');
  fs.writeFileSync(path.join(root, 'keys.json'), JSON.stringify({ keys: [KEY] }));
  const r = run(root, ['apply-public-keys', '--keys', '@' + path.join(root, 'keys.json'), '--url', 'https://licence.example.com/']);
  assert.equal(r.status, 0, r.stderr);
  const cs = fs.readFileSync(path.join(root, 'licensing/clients/dotnet/NextGenOS.Licensing/LicenceDefaults.cs'), 'utf8');
  assert.match(cs, /new TrustedKey\("k-test-1", "MFkw/);
  assert.match(cs, /ServerUrl = "https:\/\/licence\.example\.com"/);
  assert.equal(cs.replace(/\/\/ GENERATED-KEYS-BEGIN[\s\S]*?GENERATED-KEYS-END/, '').replace(/\/\/ GENERATED-URL-BEGIN[\s\S]*?GENERATED-URL-END/, ''), before.replace(/\/\/ GENERATED-KEYS-BEGIN[\s\S]*?GENERATED-KEYS-END/, '').replace(/\/\/ GENERATED-URL-BEGIN[\s\S]*?GENERATED-URL-END/, ''));
  assert.match(fs.readFileSync(path.join(root, 'apps/storefront-web-mobile/src/lib/licence/defaults.ts'), 'utf8'), /"kid": "k-test-1"/);
});

test('a key text that holds anything private, a bad address, or no keys is refused, and no file is written', () => {
  const root = tree();
  const file = path.join(root, 'licensing/clients/dotnet/NextGenOS.Licensing/LicenceDefaults.cs');
  const before = fs.readFileSync(file, 'utf8');
  const bad = (keys, url, expect) => {
    const r = run(root, ['apply-public-keys', '--keys', typeof keys === 'string' ? keys : JSON.stringify(keys), '--url', url]);
    assert.notEqual(r.status, 0);
    assert.match(r.stderr, expect);
    assert.equal(fs.readFileSync(file, 'utf8'), before);
  };
  bad({ keys: [{ ...KEY, privateKey: 'x' }] }, 'https://a.example.com', /private key/i);
  bad('key: -----BEGIN PRIVATE KEY-----', 'https://a.example.com', /private key/i);
  bad({ keys: [] }, 'https://a.example.com', /list of/);
  bad({ keys: [{ kid: 'a b', publicKey: 'short' }] }, 'https://a.example.com', /list of/);
  bad({ keys: [KEY] }, 'http://licence.example.com', /https/);
  bad({ keys: [KEY] }, '', /where the Studio/);
  bad('not json', 'https://a.example.com', /valid JSON/);
});
