// Tests for scripts/audit-package.mjs: it must catch what must never reach a customer, and pass a clean package.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, mkdirSync, writeFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { auditFolder, findSecrets, typeNamesFrom } from '../audit-package.mjs';

function make(files) {
  const dir = mkdtempSync(join(tmpdir(), 'audit-test-'));
  for (const [name, content] of Object.entries(files)) {
    const full = join(dir, name);
    mkdirSync(join(full, '..'), { recursive: true });
    writeFileSync(full, content);
  }
  return dir;
}
const problemsOf = (files, options) => { const dir = make(files); try { return auditFolder(dir, options).problems.join('\n'); } finally { rmSync(dir, { recursive: true, force: true }); } };
const utf16 = (s) => Buffer.from(s, 'utf16le');

test('a clean package passes', () => {
  assert.equal(problemsOf({ 'App.dll': Buffer.from([1, 2, 3]), 'wwwroot/app.css': 'body{}', 'readme.txt': 'hello', 'appsettings.json': '{"Hub":{"DataFolder":""}}' }), '');
});

test('source, project and symbol files are refused', () => {
  const found = problemsOf({ 'Program.cs': 'class A{}', 'App.csproj': '<Project/>', 'App.pdb': 'x', 'site.js.map': '{}', 'page.tsx': 'x', 'Page.razor': 'x', 'A.sln': 'x', 'B.slnx': 'x', 'a.vb': 'x' });
  for (const needle of ['Program.cs', 'App.csproj', 'App.pdb', 'site.js.map', 'page.tsx', 'Page.razor', 'A.sln', 'B.slnx', 'a.vb']) assert.match(found, new RegExp(needle.replace('.', '\\.')));
});

test('test programs, the studio and node_modules are refused', () => {
  const found = problemsOf({ 'Hub.Tests.dll': 'x', 'NextGenOS.Hub.E2EHost.dll': 'x', 'xunit.core.dll': 'x', 'licensing/studio/server.js': 'x', 'node_modules/a/index.js': 'x', 'e2e/run.mjs': 'x', 'a.test.mjs': 'x' });
  for (const needle of ['Hub.Tests.dll', 'E2EHost', 'xunit.core.dll', 'licensing/', 'node_modules/', 'e2e/', 'a.test.mjs']) assert.match(found, new RegExp(needle.replace('.', '\\.')));
});

test('the staff tools (Setup Studio, Brand Studio) and the Setup Studio\'s workspace are refused', () => {
  const found = problemsOf({ 'tools/setup-studio/lib/pack.mjs': 'x', 'brand-studio/kit.mjs': 'x', 'NextGenOS Setup Studio/studio.json': '{}' });
  for (const needle of ['setup-studio/', 'brand-studio/', 'NextGenOS Setup Studio/']) assert.match(found, new RegExp(needle));
});

test('secrets and private data files are refused: env files, databases, licences, keys, name maps', () => {
  const found = problemsOf({ '.env': 'A=1', '.env.production': 'A=1', 'shop.db': 'x', 'shop.db-wal': 'x', 'licence.ngos': 'NGOS1.x', 'signing.pem': 'x', 'cert.pfx': 'x', 'Mapping.txt': 'x', 'appsettings.Local.json': '{}', 'debug.log': 'x', 'private-key.json': '{}' });
  for (const needle of ['\\.env', 'shop\\.db', 'licence\\.ngos', 'signing\\.pem', 'cert\\.pfx', 'Mapping\\.txt', 'appsettings\\.Local', 'debug\\.log', 'private-key']) assert.match(found, new RegExp(needle));
});

test('a secret in a text file, and in a program as plain or .NET text, is found', () => {
  // (Built from pieces, so this test file does not itself look like a file holding a secret.)
  const key = '-----BEGIN ' + 'PRIVATE KEY-----';
  assert.match(problemsOf({ 'a.json': `{"k":"${key}"}` }), /a\.json.*private key/);
  assert.match(problemsOf({ 'b.dll': Buffer.concat([Buffer.from('MZ....'), Buffer.from(key)]) }), /b\.dll.*private key/);
  assert.match(problemsOf({ 'c.dll': Buffer.concat([Buffer.from('MZ.'), utf16(key)]) }), /c\.dll.*private key/);
  assert.match(problemsOf({ 'd.js': 'const k = "' + 'sk-' + 'proj-abcdefghijklmnopqrstuvwxyz0123456789"' }), /d\.js.*OpenAI/);
  assert.match(problemsOf({ 'e.config': 'Server=x;' + 'Pass' + 'word=Hunter22x;' }), /e\.config.*password/);
});

test('the obviously fake values the tests use are not reported', () => {
  assert.deepEqual(findSecrets('Password=your_password;'), []);
  assert.deepEqual(findSecrets('nothing to see'), []);
});

test('a program that still shows the real names of its types is refused; one that does not, passes', () => {
  const src = make({ 'Thing.cs': 'public sealed class InvoicePrinterService {}\npublic class ShortOne {}\npublic class PartyKind {}\npublic class Holder { public List<PartyKind> PartyKinds { get; set; } }' });
  try {
    const names = typeNamesFrom([src]);
    assert.ok(names.has('InvoicePrinterService'));
    assert.ok(!names.has('ShortOne'), 'short names say too little to check');
    // The name table of a program lists names one after another, each ending in a zero byte.
    const plain = Buffer.concat([Buffer.from('\0InvoicePrinterService\0Other\0')]);
    const renamed = Buffer.concat([Buffer.from('\0a\0b\0c\0InvoicePrinterServices\0')]);
    assert.match(problemsOf({ 'P.dll': plain }, { obfuscated: ['P.dll'], names }), /P\.dll.*not obfuscated.*InvoicePrinterService/);
    assert.equal(problemsOf({ 'P.dll': renamed }, { obfuscated: ['P.dll'], names }), '', 'a longer name that merely contains the real one is not the real one');
    assert.match(problemsOf({}, { obfuscated: ['Missing.dll'], names }), /Missing\.dll.*missing/);
  } finally { rmSync(src, { recursive: true, force: true }); }
});

// Fake secrets are built from pieces, so that no line of this file looks like a secret to the gate's scan (scripts/scan-history.mjs reads every commit).
const KEY_HEAD = ['-----BEGIN', 'PRIVATE KEY-----'].join(' ');
const DB_URL = ['postgres://admin', 'SuperSecret99@db.example.invalid/shop'].join(':');
const MINIFIED = 's.pass' + 'word=r.pass' + 'word,s.host=r.host,s.port=r.port;break;';

test('a Node.js app (the website): its node_modules folder is accepted only with nodeApp, and everything inside it is still checked', () => {
  const files = { 'app/server.js': 'x', 'app/node_modules/lib/index.js': 'module.exports = 1;' };
  assert.match(problemsOf(files), /node_modules\/\s+node_modules/);
  assert.equal(problemsOf(files, { nodeApp: true }), '');
  const found = problemsOf({ 'app/node_modules/lib/index.d.ts': 'x', 'app/node_modules/lib/index.js.map': '{}', 'app/node_modules/lib/.env': 'A=1', 'app/node_modules/lib/test.test.js': 'x', 'app/node_modules/lib/tests/a.js': 'x', 'app/node_modules/lib/yarn.lock': 'x', 'app/node_modules/lib/k.pem': 'x', 'app/node_modules/lib/a.js': DB_URL }, { nodeApp: true });
  for (const needle of ['index.d.ts', 'index.js.map', '.env', 'test.test.js', 'tests/', 'yarn.lock', 'k.pem', 'database URL with a password']) assert.match(found, new RegExp(needle.replace('.', '\\.')), needle);
});

test('a Node.js app: JavaScript code is read as code (minified password fields, a library that names the header of a key file), but a real key or connection string in it is still found', () => {
  const code = { 'a/node_modules/next/polyfill.js': `case 1:s.username=r.username,${MINIFIED}`, 'a/node_modules/google-auth/pem.js': `const header = "${KEY_HEAD}"; const re = /-----BEGIN (RSA )?PRIVATE KEY-----/;`, 'a/node_modules/jwks-rsa/src/errors/SigningKeyNotFoundError.js': 'class E extends Error {}' };
  assert.equal(problemsOf(code, { nodeApp: true }), '');
  assert.match(problemsOf({ 'a/polyfill.js': code['a/node_modules/next/polyfill.js'] }), /password in a connection string/, 'without nodeApp the same text is refused');
  assert.match(problemsOf({ 'a/pem.js': code['a/node_modules/google-auth/pem.js'] }), /private key/, 'and so is a file that only names the header');
  const body = `${KEY_HEAD}\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC7abcdef`;
  assert.match(problemsOf({ 'a/key.js': `const k = "${body}";` }, { nodeApp: true }), /key\.js\s+contains private key/);
  assert.match(problemsOf({ 'a/key.txt': KEY_HEAD }, { nodeApp: true }), /key\.txt\s+contains private key/, 'only JavaScript is read as code');
  assert.match(problemsOf({ 'a/db.js': `const url = "${DB_URL}";` }, { nodeApp: true }), /db\.js\s+contains database URL with a password/);
  assert.match(problemsOf({ 'a/signing-key.js': 'x' }, { nodeApp: true }), /signing-key\.js\s+private or signing key/, 'outside node_modules the name is still refused');
});
