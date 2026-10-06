'use strict';
// Writes licensing/testvectors/vectors.json: signed example licences and what every client must decide for each.
// The Studio is the reference; the .NET and Node clients must agree with these results.
// Run: node scripts/make-testvectors.js        (the throw-away signing key is discarded; only the public key is kept)

const fs = require('node:fs');
const path = require('node:path');
const C = require('../lib/crypto');
const { DAY } = require('../lib/studio');

const NOW = 1_800_000_000;
const key = C.generateSigningKey();
const other = C.generateSigningKey();
const signer = { kid: key.kid, privateKeyPem: key.privateKeyPem };

const part = (kind, name) => require('node:crypto').createHash('sha256').update(`ngos-fp-v1:${kind}:${name}-${kind}`).digest('hex').slice(0, 32);
const kinds = ['bios', 'board', 'cpu', 'disk', 'os'];
const pc = (name) => Object.fromEntries(kinds.map((k) => [k, part(k, name)]));

const brand = { id: 'B-1', name: 'RetailPro', shortName: 'RetailPro', legalName: 'RetailPro Ltd', primaryColor: '#112233', accentColor: '#f59e0b', supportEmail: 'help@retailpro.example', supportPhone: '', supportUrl: '', websiteUrl: '', copyright: '(c) RetailPro', logo: null, poweredBy: true };

const lic = (over = {}, s = signer) => C.signToken({
  typ: 'lic', lid: 'L-TEST0001', rev: 1, iat: NOW - 10 * DAY, nbf: NOW - 10 * DAY, exp: NOW + 355 * DAY,
  cust: { id: 'C-1', name: 'Green Mart', country: 'IN', email: 'asha@greenmart.example' },
  product: 'smart-retail-os', edition: 'business', modules: ['pos', 'ai', 'dashboard', 'owner-live'],
  limits: { devices: 3, stores: 1, users: 10 }, bind: { mode: 'device', domains: [] }, brand,
  reseller: null, act: { online: true, checkInDays: 7, graceDays: 14, offlineDays: 365 }, trial: false, white: { level: 'theme' }, ...over,
}, s);

const fpList = (map) => Object.entries(map).map(([k, v]) => `${k}:${v}`).sort();
const act = (fpMap, over = {}, s = signer) => C.signToken({
  typ: 'act', lid: 'L-TEST0001', rev: 1, iat: NOW - 3 * DAY, fp: fpList(fpMap), fpMin: Math.max(1, Math.ceil(Object.keys(fpMap).length * 0.6)),
  next: NOW + 4 * DAY, until: NOW + 18 * DAY, ...over,
}, s);

const crl = (revoked = []) => C.signToken({ typ: 'crl', iat: NOW - DAY, next: NOW + DAY, revoked }, signer);

const A = pc('pc-a');
const goodLic = lic();
const goodAct = act(A);

const tamper = (token, change) => {
  const [p, body, sig] = token.split('.');
  const obj = JSON.parse(Buffer.from(body, 'base64url').toString());
  change(obj);
  return [p, Buffer.from(JSON.stringify(obj)).toString('base64url'), sig].join('.');
};

const cases = [
  { name: 'valid_online', lic: goodLic, act: goodAct, fp: A, expect: 'Valid' },
  { name: 'valid_one_part_changed', lic: goodLic, act: goodAct, fp: { ...A, disk: part('disk', 'replacement') }, expect: 'Valid' },
  { name: 'valid_module_required_present', lic: goodLic, act: goodAct, fp: A, module: 'ai', expect: 'Valid' },
  { name: 'module_not_licensed', lic: goodLic, act: goodAct, fp: A, module: 'chain', expect: 'ModuleNotLicensed' },
  { name: 'grace_after_checkin_due', lic: goodLic, act: goodAct, fp: A, now: NOW + 10 * DAY, expect: 'Grace' },
  { name: 'needs_checkin_after_grace', lic: goodLic, act: goodAct, fp: A, now: NOW + 19 * DAY, expect: 'NeedsCheckIn' },
  { name: 'expired', lic: goodLic, act: act(A, { next: NOW + 400 * DAY, until: NOW + 410 * DAY }), fp: A, now: NOW + 356 * DAY, expect: 'Expired' },
  { name: 'not_yet_valid', lic: lic({ nbf: NOW + 5 * DAY }), act: goodAct, fp: A, expect: 'NotYetValid' },
  { name: 'perpetual_is_valid', lic: lic({ exp: null }), act: goodAct, fp: A, expect: 'Valid' },
  { name: 'revoked_by_crl', lic: goodLic, act: goodAct, crl: crl(['L-TEST0001']), fp: A, expect: 'Revoked' },
  { name: 'other_licence_in_crl_is_fine', lic: goodLic, act: goodAct, crl: crl(['L-OTHER']), fp: A, expect: 'Valid' },
  { name: 'single_part_pc_matches_itself', lic: goodLic, act: act({ os: A.os }), fp: { os: A.os }, expect: 'Valid' },
  { name: 'single_part_pc_other_machine', lic: goodLic, act: act({ os: A.os }), fp: { os: pc('z').os }, expect: 'DeviceMismatch' },
  { name: 'copied_to_another_pc', lic: goodLic, act: goodAct, fp: pc('pc-b'), expect: 'DeviceMismatch' },
  { name: 'two_parts_changed_still_same_pc', lic: goodLic, act: goodAct, fp: { ...A, disk: part('disk', 'r1'), board: part('board', 'r2') }, expect: 'Valid' },
  { name: 'three_parts_changed_is_another_pc', lic: goodLic, act: goodAct, fp: { ...A, disk: part('disk', 'r1'), board: part('board', 'r2'), bios: part('bios', 'r3') }, expect: 'DeviceMismatch' },
  { name: 'cloned_image_same_cpu_and_os_only', lic: goodLic, act: goodAct, fp: { ...pc('clone'), cpu: A.cpu, os: A.os }, expect: 'DeviceMismatch' },
  { name: 'cpu_alone_never_carries_a_match', lic: goodLic, act: goodAct, fp: { ...pc('other'), cpu: A.cpu, os: A.os, disk: A.disk }, expect: 'Valid' },
  { name: 'only_one_part_matches', lic: goodLic, act: goodAct, fp: { ...pc('pc-b'), bios: A.bios }, expect: 'DeviceMismatch' },
  { name: 'not_activated', lic: goodLic, act: null, fp: A, expect: 'NotActivated' },
  { name: 'activation_of_another_licence', lic: goodLic, act: act(A, { lid: 'L-OTHER' }), fp: A, expect: 'Invalid' },
  { name: 'tampered_licence_modules', lic: tamper(goodLic, (o) => { o.modules.push('chain'); }), act: goodAct, fp: A, expect: 'Invalid' },
  { name: 'tampered_licence_expiry', lic: tamper(goodLic, (o) => { o.exp = null; }), act: goodAct, fp: A, expect: 'Invalid' },
  { name: 'signed_by_unknown_key', lic: lic({}, { kid: other.kid, privateKeyPem: other.privateKeyPem }), act: goodAct, fp: A, expect: 'Invalid' },
  { name: 'activation_signed_by_unknown_key', lic: goodLic, act: act(A, {}, { kid: other.kid, privateKeyPem: other.privateKeyPem }), fp: A, expect: 'Invalid' },
  { name: 'activation_used_as_licence', lic: goodAct, act: goodAct, fp: A, expect: 'Invalid' },
  { name: 'garbage_licence', lic: 'hello', act: null, fp: A, expect: 'Invalid' },
  { name: 'missing', lic: null, act: null, fp: A, expect: 'Missing' },
  { name: 'clock_rolled_back', lic: goodLic, act: goodAct, fp: A, now: NOW - 5 * DAY, expect: 'ClockTampered' },
  { name: 'clock_rolled_back_by_state', lic: goodLic, act: goodAct, fp: A, now: NOW, lastSeen: NOW + 3 * DAY, expect: 'ClockTampered' },
  { name: 'wrong_product', lic: lic({ product: 'something-else' }), act: goodAct, fp: A, expect: 'Invalid' },
  { name: 'domain_exact', lic: lic({ bind: { mode: 'domain', domains: ['shop.example.com'] } }), act: null, host: 'shop.example.com', fp: A, expect: 'Valid' },
  { name: 'domain_case_and_port', lic: lic({ bind: { mode: 'domain', domains: ['shop.example.com'] } }), act: null, host: 'SHOP.Example.com:3000', fp: A, expect: 'Valid' },
  { name: 'domain_wildcard', lic: lic({ bind: { mode: 'domain', domains: ['*.example.org'] } }), act: null, host: 'a.b.example.org', fp: A, expect: 'Valid' },
  { name: 'domain_wildcard_not_apex', lic: lic({ bind: { mode: 'domain', domains: ['*.example.org'] } }), act: null, host: 'example.org', fp: A, expect: 'DomainMismatch' },
  { name: 'domain_lookalike', lic: lic({ bind: { mode: 'domain', domains: ['shop.example.com'] } }), act: null, host: 'shop.example.com.evil.test', fp: A, expect: 'DomainMismatch' },
  { name: 'domain_no_host', lic: lic({ bind: { mode: 'domain', domains: ['shop.example.com'] } }), act: null, host: null, fp: A, expect: 'DomainMismatch' },
  { name: 'unbound_licence', lic: lic({ bind: { mode: 'none', domains: [] } }), act: null, fp: A, expect: 'Valid' },
];

const out = {
  about: 'Generated by studio/scripts/make-testvectors.js. Every client must return `expect` for each case. `now` defaults to the top-level now.',
  now: NOW,
  publicKeys: [{ kid: key.kid, publicKey: key.publicKey }],
  fingerprintKinds: kinds,
  fingerprintExample: { kind: 'bios', value: 'ABC123', listed: 'bios:' + require('node:crypto').createHash('sha256').update('ngos-fp-v1:bios:ABC123').digest('hex').slice(0, 32), part: require('node:crypto').createHash('sha256').update('ngos-fp-v1:bios:ABC123').digest('hex').slice(0, 32) },
  cases: cases.map((c) => ({ name: c.name, lic: c.lic, act: c.act || null, crl: c.crl || null, fp: c.fp, host: c.host === undefined ? null : c.host, module: c.module || null, now: c.now || NOW, lastSeen: c.lastSeen || null, expect: c.expect })),
};

const file = path.join(__dirname, '..', '..', 'testvectors', 'vectors.json');
fs.writeFileSync(file, JSON.stringify(out, null, 2) + '\n');
console.log(`Wrote ${out.cases.length} cases to ${path.relative(process.cwd(), file)}`);
