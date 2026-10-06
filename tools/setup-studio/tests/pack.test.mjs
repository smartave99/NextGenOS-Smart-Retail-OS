// The customer pack: the programs folder is checked, then copied exactly; what belongs to one customer is added beside it as plain data; nothing leaves the pack's folder.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, mkdirSync, writeFileSync, readFileSync, rmSync, existsSync, statSync, readdirSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { createHash, randomBytes } from 'node:crypto';
import { makeBaseKit } from '../../../scripts/make-base-kit.mjs';
import { readBaseKit } from '../lib/basekit.mjs';
import { checkIntake } from '../lib/intake.mjs';
import { buildPack, planPack, PackError, brandKitFor, fileSafe, PROFILE_FILES, websiteSettingsLine, websiteFileName } from '../lib/pack.mjs';
import { readDeb } from '../lib/deb.mjs';
import { listZip } from '../lib/zip.mjs';
import { check as checkKit } from '../../brand-studio/lib/kit.mjs';
import { auditFolder } from '../../../scripts/audit-package.mjs';
import { parseSettings, knownPacks, packageName } from '../../../scripts/make-website-package.mjs';

const PNG = Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNkYPhfDwAChwGA60e6kgAAAABJRU5ErkJggg==', 'base64');
const sha = (b) => createHash('sha256').update(b).digest('hex');
const tmp = () => mkdtempSync(join(tmpdir(), 'pack-test-'));

/** A programs folder with small stand-in files named as a real release names them. */
async function programs(root, { extra = {}, trial = false } = {}) {
  const dir = join(root, 'programs');
  mkdirSync(dir);
  const files = { 'SmartRetailPOS-Hub-Setup-1.4.0.exe': randomBytes(5000), 'smart-retail-pos-hub_1.4.0-1_amd64.deb': randomBytes(4000), 'smart-retail-pos-hub_1.4.0-1_arm64.deb': randomBytes(3000), ...extra };
  for (const [n, d] of Object.entries(files)) writeFileSync(join(dir, n), d);
  if (trial) writeFileSync(join(dir, 'NO-LICENCE-KEYS-TRIAL-ONLY.txt'), 'trial');
  const { manifest } = await makeBaseKit(dir);
  writeFileSync(join(dir, 'base-kit.json'), JSON.stringify(manifest));
  return { dir, files };
}

const intakeOf = (over = {}) => {
  const r = checkIntake({ business: { name: 'Luzon Fresh Mart', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'help@luzonfresh.example', address: 'Quezon City, Metro Manila' } }, device: { kind: 'touch-pos', os: 'windows', screen: 'standard' }, look: { primaryColor: '#0a7d4b', style: 'friendly' }, licence: { whiteLabel: 'theme', seats: 2 }, ...over });
  assert.ok(r.complete, JSON.stringify(r.errors));
  return r.value;
};
const partsOf = (intake, { logo = true } = {}) => ({
  info: { n: 3, bundleHash: 'ab'.repeat(32), approvedAt: '2026-10-05T10:00:00.000Z' },
  intake,
  files: { 'setup.json': Buffer.from('{"schema":1,"settings":{}}\n'), 'theme.json': Buffer.from('{"schema":1}\n'), 'brand.json': Buffer.from('{"schema":1,"name":"Luzon Fresh Mart"}\n') },
  logo: logo ? { ext: 'png', bytes: PNG } : null,
});

test('the programs folder is read, and every kind of damage is named in plain words', async () => {
  const root = tmp();
  try {
    const { dir } = await programs(root);
    const ok = await readBaseKit(dir);
    assert.equal(ok.ok, true, ok.problems.join('; '));
    assert.equal(ok.version, '1.4.0');
    assert.deepEqual(ok.files.map((f) => f.role).sort(), ['hub-linux-deb', 'hub-linux-deb', 'hub-windows-setup']);

    assert.match((await readBaseKit(join(root, 'nope'))).problems[0], /not found/);
    assert.match((await readBaseKit(root)).problems[0], /base-kit\.json is not in that folder/);

    const cut = join(dir, 'SmartRetailPOS-Hub-Setup-1.4.0.exe');
    const original = readFileSync(cut);
    writeFileSync(cut, original.subarray(0, 100));
    assert.match((await readBaseKit(dir)).problems.join(' '), /incomplete/);
    writeFileSync(cut, Buffer.concat([Buffer.from([original[0] ^ 1]), original.subarray(1)]));
    assert.match((await readBaseKit(dir)).problems.join(' '), /fingerprint/);
    rmSync(cut);
    const gone = await readBaseKit(dir);
    assert.match(gone.problems.join(' '), /is missing/);
    assert.equal(gone.ok, false);

    const m = JSON.parse(readFileSync(join(dir, 'base-kit.json'), 'utf8'));
    m.files.push({ name: '../../etc/passwd', role: 'hub-windows-setup', sha256: 'x', bytes: 1 });
    writeFileSync(join(dir, 'base-kit.json'), JSON.stringify(m));
    assert.match((await readBaseKit(dir)).problems.join(' '), /name that is not allowed/);
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('what a pack would hold is worked out from the details: what is ready, what is missing, what does not apply', async () => {
  const root = tmp();
  try {
    const { dir } = await programs(root);
    const kit = await readBaseKit(dir);
    const win = planPack({ intake: intakeOf({ ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' }, android: { wanted: true, appId: 'com.luzonfresh.shop' }, aiAddon: { wanted: true } } }), kit, slug: 'luzon-fresh-mart' });
    const by = Object.fromEntries(win.map((i) => [i.id, i.status]));
    assert.deepEqual(by, { 'shop-pc': 'ready', ai: 'missing', website: 'missing', android: 'missing' });
    const lin = planPack({ intake: intakeOf({ device: { kind: 'laptop', os: 'linux', screen: 'standard' }, ecosystem: { aiAddon: { wanted: true } } }), kit, slug: 'luzon-fresh-mart' });
    assert.equal(lin.find((i) => i.id === 'ai').status, 'skipped');
    assert.equal(lin.find((i) => i.id === 'shop-pc').files.length, 2, 'both processors');
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('a Windows pack: the setup as released, the profile beside it, a page of steps, the hand-over sheet, and a list with every fingerprint', async () => {
  const root = tmp();
  try {
    const { dir, files } = await programs(root, { extra: { 'SmartRetailAI-Setup.exe': randomBytes(2000) } });
    const kit = await readBaseKit(dir);
    const intake = intakeOf({ ecosystem: { aiAddon: { wanted: true } } });
    const out = join(root, 'out');
    const r = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intake), kit, out, company: { name: 'Pinoy POS Partners', supportPhone: '+63 2 5555 0199' }, builtBy: 'Asha', now: new Date('2026-10-05T12:00:00Z') });
    const top = join(r.dir);
    assert.equal(readFileSync(join(top, '1 - Shop PC (Windows)', 'SmartRetailPOS-Hub-Setup-1.4.0.exe')).equals(files['SmartRetailPOS-Hub-Setup-1.4.0.exe']), true, 'copied exactly');
    for (const n of PROFILE_FILES) assert.ok(existsSync(join(top, '1 - Shop PC (Windows)', 'profile', n)), n);
    const ini = readFileSync(join(top, '1 - Shop PC (Windows)', 'profile', 'install.ini'), 'utf8');
    assert.match(ini, /\[install\]\r\nkind=touch-pos\r\nkiosk=yes\r\n/);
    assert.match(readFileSync(join(top, '1 - Shop PC (Windows)', 'profile', 'release.txt'), 'utf8'), /Prepared for: Luzon Fresh Mart[\s\S]*Setup release: 3/);
    assert.ok(existsSync(join(top, '2 - AI assistant (Windows)', 'SmartRetailAI-Setup.exe')));
    assert.match(readFileSync(join(top, '2 - AI assistant (Windows)', 'READ ME FIRST.txt'), 'utf8'), /does not yet read the information of the new/);
    assert.match(readFileSync(join(top, '1 - Shop PC (Windows)', 'READ ME FIRST.txt'), 'utf8'), /Pinoy POS Partners|\+63 2 5555 0199/);
    const sheet = readFileSync(join(top, 'START HERE.html'), 'utf8');
    assert.match(sheet, /Luzon Fresh Mart: your Smart Retail POS/);
    assert.match(sheet, /Content-Security-Policy/);
    assert.ok(!/<script/i.test(sheet));
    assert.match(sheet, /--accent: #0a7d4b/);
    assert.match(sheet, /<img class="logo" src="data:image\/png;base64,/);

    const contents = JSON.parse(readFileSync(join(top, 'PACK-CONTENTS.json'), 'utf8'));
    assert.equal(contents.release.bundleHash, 'ab'.repeat(32));
    assert.equal(contents.programs.version, '1.4.0');
    assert.ok(contents.files.length >= 10);
    for (const f of contents.files) assert.equal(sha(readFileSync(join(top, ...f.path.split('/')))), f.sha256, f.path);
    const names = listZip(readFileSync(r.zip));
    assert.ok(names.includes('Luzon Fresh Mart/START HERE.html') && names.includes('Luzon Fresh Mart/1 - Shop PC (Windows)/profile/theme.json') && names.includes('Luzon Fresh Mart/PACK-CONTENTS.json'));
    assert.equal(names.filter((n) => n.startsWith('..') || n.startsWith('/')).length, 0);
    assert.equal(r.sha256, sha(readFileSync(r.zip)));
    // what a customer receives is audited the way every other package is: no source, no key, no database, no licence file, no secret, no staff tool
    const audit = auditFolder(r.dir);
    assert.deepEqual(audit.problems, []);
    assert.ok(audit.files >= 10);
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('a Linux pack: both programs, a profile package that dpkg-style tools read back, an install script, and kiosk start-up for a till', async () => {
  const root = tmp();
  try {
    const { dir } = await programs(root);
    const kit = await readBaseKit(dir);
    const intake = intakeOf({ device: { kind: 'touch-pos', os: 'linux', screen: 'large' } });
    const r = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intake), kit, out: join(root, 'out'), company: { name: 'Pinoy POS Partners', supportEmail: 'help@pinoypos.example' } });
    const folder = join(r.dir, '1 - Shop PC (Linux)');
    const listing = readdirSync(folder).sort();
    assert.deepEqual(listing, ['READ ME FIRST.txt', 'install.sh', 'smart-retail-pos-hub_1.4.0-1_amd64.deb', 'smart-retail-pos-hub_1.4.0-1_arm64.deb', 'smart-retail-profile-luzon-fresh-mart_1.0.3_all.deb']);
    assert.ok(statSync(join(folder, 'install.sh')).mode & 0o100, 'the script can be run');
    const deb = readDeb(readFileSync(join(folder, 'smart-retail-profile-luzon-fresh-mart_1.0.3_all.deb')));
    assert.match(deb.control, /Package: smart-retail-profile-luzon-fresh-mart\nVersion: 1\.0\.3\nArchitecture: all\nMaintainer: Pinoy POS Partners <help@pinoypos\.example>/);
    assert.match(deb.control, /Conflicts: smart-retail-profile\nProvides: smart-retail-profile\nReplaces: smart-retail-profile/);
    assert.deepEqual(deb.files.map((f) => f.name).sort(), ['etc/xdg/autostart/smart-retail-pos-fullscreen.desktop', 'opt/nextgenos/smart-retail-hub/profile/brand.json', 'opt/nextgenos/smart-retail-hub/profile/release.txt', 'opt/nextgenos/smart-retail-hub/profile/setup.json', 'opt/nextgenos/smart-retail-hub/profile/theme.json']);
    assert.match(deb.scripts.postinst, /try-restart nextgenos-hub/);
    const script = readFileSync(join(folder, 'install.sh'), 'utf8');
    assert.match(script, /apt-get install -y "\.\/\$hub" "\.\/\$profile"/);
    assert.match(script.split('\n')[1], /^# Installs Smart Retail POS and the set-up prepared for Luzon Fresh Mart\.$/);
    // a business name that tries to run a command is made harmless in the script
    const hostile = await buildPack({ customerId: 'bobs-shop', parts: partsOf(intakeOf({ business: { name: "Bob's $(reboot) `id` Shop", country: 'PH', industry: 'retail' }, device: { kind: 'laptop', os: 'linux', screen: 'standard' } })), kit, out: join(root, 'out3') });
    const hostileScript = readFileSync(join(hostile.dir, '1 - Shop PC (Linux)', 'install.sh'), 'utf8');
    assert.ok(!hostileScript.includes('$(reboot)') && !hostileScript.includes('`id`'));
    assert.match(hostileScript.split('\n')[1], /^# Installs Smart Retail POS and the set-up prepared for Bob's reboot id Shop\.$/);
    // a laptop is not a kiosk: no full-screen start-up
    const laptop = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intakeOf({ device: { kind: 'laptop', os: 'linux', screen: 'standard' } })), kit, out: join(root, 'out2') });
    const d2 = readDeb(readFileSync(join(laptop.dir, '1 - Shop PC (Linux)', 'smart-retail-profile-luzon-fresh-mart_1.0.3_all.deb')));
    assert.ok(!d2.files.some((f) => f.name.includes('autostart')));
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('a pack is refused when the shop program is missing, and when the programs have no licence keys (a trial) unless it is only to try', async () => {
  const root = tmp();
  try {
    const trial = await programs(root, { trial: true });
    const trialKit = await readBaseKit(trial.dir);
    assert.equal(trialKit.trial, true);
    await assert.rejects(buildPack({ customerId: 'a-shop', parts: partsOf(intakeOf()), kit: trialKit, out: join(root, 'o1') }), (e) => e instanceof PackError && /licence keys/.test(e.message));
    const ok = await buildPack({ customerId: 'a-shop', parts: partsOf(intakeOf()), kit: trialKit, out: join(root, 'o2'), allowTrial: true });
    assert.equal(ok.contents.programs.trial, true);

    const root2 = tmp();
    try {
      const only = join(root2, 'programs'); mkdirSync(only);
      writeFileSync(join(only, 'smart-retail-pos-hub_1.4.0-1_amd64.deb'), 'x');
      const { manifest } = await makeBaseKit(only); writeFileSync(join(only, 'base-kit.json'), JSON.stringify(manifest));
      const kit = await readBaseKit(only);
      await assert.rejects(buildPack({ customerId: 'a-shop', parts: partsOf(intakeOf()), kit, out: join(root2, 'o') }), (e) => e instanceof PackError && /Windows setup is not in the programs folder/.test(e.message));
    } finally { rmSync(root2, { recursive: true, force: true }); }
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('names from the customer cannot reach outside the pack, and a name with markup is shown as text on the sheet', async () => {
  assert.equal(fileSafe('../../etc/passwd'), 'etc passwd');
  assert.equal(fileSafe('CON'), 'Customer');
  assert.equal(fileSafe('  ..  '), 'Customer');
  assert.ok(fileSafe('x'.repeat(200)).length <= 50);
  const root = tmp();
  try {
    const { dir } = await programs(root);
    const kit = await readBaseKit(dir);
    const intake = intakeOf({ business: { name: 'Tom & "Jerry" Mart', country: 'PH', industry: 'retail' } });
    const r = await buildPack({ customerId: 'tom-jerry-mart', parts: partsOf(intake), kit, out: join(root, 'out') });
    const sheet = readFileSync(join(r.dir, 'START HERE.html'), 'utf8');
    assert.match(sheet, /Tom &amp; &quot;Jerry&quot; Mart: your Smart Retail POS/);
    assert.ok(listZip(readFileSync(r.zip)).every((n) => n.startsWith('Tom & Jerry Mart/')), listZip(readFileSync(r.zip))[0]);
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('the brand kit made for the Android build is one the Brand Studio accepts', async () => {
  const intake = intakeOf({ ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' }, android: { wanted: true, appId: 'com.luzonfresh.shop' } }, money: { receiptFooter: 'Salamat po!' } });
  const kit = brandKitFor({ intake, logo: { ext: 'png', bytes: PNG } });
  const root = tmp();
  try {
    writeFileSync(join(root, 'logo.png'), PNG);
    const { errors } = checkKit(kit, { folder: root });
    assert.deepEqual(errors, []);
    assert.equal(kit.android.storefrontUrl, 'https://luzonfresh.example');
    assert.equal(kit.currency, 'PHP');
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('the website: the one built for THIS customer is copied with its fingerprint, one for another customer is not, and without one the steps say how to make it', async () => {
  const root = tmp();
  try {
    const linux = randomBytes(3000), windows = randomBytes(3500);
    const { dir } = await programs(root, { extra: { 'website-luzon-fresh-mart-linux.zip': linux, 'website-luzon-fresh-mart-windows.zip': windows, 'website-someone-else-linux.zip': randomBytes(2000) } });
    const kit = await readBaseKit(dir);
    const intake = intakeOf({ ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' } } });
    const plan = planPack({ intake, kit, slug: 'luzon-fresh-mart' }).find((i) => i.id === 'website');
    assert.equal(plan.status, 'ready');
    assert.deepEqual(plan.files.map((f) => f.name).sort(), ['website-luzon-fresh-mart-linux.zip', 'website-luzon-fresh-mart-windows.zip']);
    assert.match(plan.note, /built for this customer/);
    const r = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intake), kit, out: join(root, 'out'), now: new Date('2026-10-05T12:00:00Z') });
    const site = join(r.dir, '3 - Website');
    assert.equal(readFileSync(join(site, 'website-luzon-fresh-mart-linux.zip')).equals(linux), true, 'copied exactly');
    assert.equal(readFileSync(join(site, 'website-luzon-fresh-mart-windows.zip')).equals(windows), true);
    assert.ok(!existsSync(join(site, 'website-someone-else-linux.zip')), 'another customer\'s website is never in this pack');
    const readme = readFileSync(join(site, 'READ ME FIRST.txt'), 'utf8');
    assert.ok(readme.includes(`Fingerprint of website-luzon-fresh-mart-linux.zip (SHA-256): ${sha(linux)}`), 'the fingerprint is written down');
    assert.ok(readme.includes(sha(windows)));
    assert.match(readme, /nothing has to be installed first/);
    assert.doesNotMatch(readme, /someone-else/);
    const contents = JSON.parse(readFileSync(join(r.dir, 'PACK-CONTENTS.json'), 'utf8'));
    const part = contents.parts.find((p) => p.id === 'website');
    assert.deepEqual(part.programs.map((p) => p.sha256).sort(), [sha(linux), sha(windows)].sort());
    assert.ok(contents.files.some((f) => f.path === '3 - Website/website-luzon-fresh-mart-linux.zip' && f.sha256 === sha(linux)));
    assert.ok(listZip(readFileSync(r.zip)).some((n) => n.endsWith('3 - Website/website-luzon-fresh-mart-windows.zip')));
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('the website: with no website built for this customer, the pack keeps the public settings and says exactly how to make one', async () => {
  const root = tmp();
  try {
    const { dir } = await programs(root, { extra: { 'website-someone-else-linux.zip': randomBytes(2000) } });
    const kit = await readBaseKit(dir);
    const intake = intakeOf({ ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' } } });
    assert.equal(planPack({ intake, kit, slug: 'luzon-fresh-mart' }).find((i) => i.id === 'website').status, 'missing');
    const r = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intake), kit, out: join(root, 'out') });
    const site = join(r.dir, '3 - Website');
    assert.deepEqual(readdirSync(site).sort(), ['READ ME FIRST.txt', 'website-settings.env']);
    const readme = readFileSync(join(site, 'READ ME FIRST.txt'), 'utf8');
    assert.match(readme, /has not been built yet/);
    assert.match(readme, /Actions, "Release", Run workflow/);
    assert.match(readme, /Website customer/);
    assert.match(readme, /Website settings/);
    assert.ok(readme.includes(websiteSettingsLine(intake)), 'the one line to paste is there');
    assert.ok(readme.includes(websiteFileName('luzon-fresh-mart', 'windows')) && readme.includes(websiteFileName('luzon-fresh-mart', 'linux')));
    assert.doesNotMatch(readme, /someone-else/);
    assert.doesNotMatch(readme, /does not build one yet|the release does not build/i, 'no longer says the release builds none');
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('the website settings the pack writes are exactly what the website builder reads, on one line too, and a name changes the result', async () => {
  const packs = knownPacks();
  const intake = intakeOf({ ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' } } });
  const root = tmp();
  try {
    const { dir } = await programs(root);
    const kit = await readBaseKit(dir);
    const r = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intake), kit, out: join(root, 'out') });
    const file = readFileSync(join(r.dir, '3 - Website', 'website-settings.env'), 'utf8');
    const parsed = parseSettings(file, packs);
    assert.deepEqual(parsed.problems, []);
    assert.equal(parsed.values.NEXT_PUBLIC_SITE_NAME, 'Luzon Fresh Mart');
    assert.equal(parsed.values.NEXT_PUBLIC_SITE_URL, 'https://luzonfresh.example');
    const line = websiteSettingsLine(intake);
    assert.deepEqual(parseSettings(line.split(';').join('\n'), packs).values, parsed.values);
    // Another customer, another country: another result (nothing is fixed in the program).
    const other = intakeOf({ business: { name: 'Gilded Page Books', country: 'GB', industry: 'library', contact: { phone: '+44 20 7946 0000', email: 'hello@gilded.example', address: 'Leeds, England' } }, ecosystem: { website: { wanted: true, domain: 'gilded.example' } } });
    const v = parseSettings(websiteSettingsLine(other).split(';').join('\n'), packs).values;
    assert.deepEqual([v.NEXT_PUBLIC_SITE_NAME, v.NEXT_PUBLIC_COUNTRY, v.NEXT_PUBLIC_INDUSTRY], ['Gilded Page Books', 'GB', 'library']);
    // A value that holds a semicolon cannot be put on one line.
    assert.equal(websiteSettingsLine(intakeOf({ business: { name: 'Salt; Pepper', country: 'PH', industry: 'retail', contact: { phone: '+63 2 5555 0100', email: 'a@b.example', address: 'Manila' } } })), null);
    assert.equal(`${packageName('luzon-fresh-mart', 'linux')}.zip`, websiteFileName('luzon-fresh-mart', 'linux'), 'the Studio and the builder name the file the same way');
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('the Android app: the phone file and the store file made for THIS customer go in the pack; without them the steps point to the Studio\'s "Website and app" step', async () => {
  const root = tmp();
  const root2 = tmp();
  try {
    const apk = randomBytes(2500), aab = randomBytes(2600);
    const { dir } = await programs(root, { extra: { 'SmartRetailPOS-luzon-fresh-mart-1.0.4.apk': apk, 'SmartRetailPOS-luzon-fresh-mart-1.0.4.aab': aab, 'SmartRetailPOS-someone-else-1.0.1.apk': randomBytes(2000) } });
    const kit = await readBaseKit(dir);
    const intake = intakeOf({ ecosystem: { website: { wanted: true, domain: 'luzonfresh.example' }, android: { wanted: true, appId: 'com.luzonfresh.shop' } } });
    const plan = planPack({ intake, kit, slug: 'luzon-fresh-mart' }).find((i) => i.id === 'android');
    assert.equal(plan.status, 'ready');
    assert.deepEqual(plan.files.map((f) => f.name).sort(), ['SmartRetailPOS-luzon-fresh-mart-1.0.4.aab', 'SmartRetailPOS-luzon-fresh-mart-1.0.4.apk']);
    const r = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intake), kit, out: join(root, 'out') });
    const folder = join(r.dir, '4 - Android app');
    assert.ok(readFileSync(join(folder, 'SmartRetailPOS-luzon-fresh-mart-1.0.4.apk')).equals(apk) && readFileSync(join(folder, 'SmartRetailPOS-luzon-fresh-mart-1.0.4.aab')).equals(aab));
    assert.ok(!existsSync(join(folder, 'SmartRetailPOS-someone-else-1.0.1.apk')), 'another customer\'s app is never in this pack');
    assert.match(readFileSync(join(folder, 'READ ME FIRST.txt'), 'utf8'), /\.aab file is for the Google Play Store/);
    // without the app, and without the website: the pack says where they are made
    const bare = await programs(root2, {});
    const kit2 = await readBaseKit(bare.dir);
    const r2 = await buildPack({ customerId: 'luzon-fresh-mart', parts: partsOf(intake), kit: kit2, out: join(root2, 'out') });
    assert.match(readFileSync(join(r2.dir, '4 - Android app', 'READ ME FIRST.txt'), 'utf8'), /go to the step "Website and app"/);
    assert.match(readFileSync(join(r2.dir, '3 - Website', 'READ ME FIRST.txt'), 'utf8'), /go to the step "Website and app"/);
    const noApp = planPack({ intake, kit: kit2, slug: 'luzon-fresh-mart' });
    assert.match(noApp.find((i) => i.id === 'android').note, /"Website and app" step/);
    assert.match(noApp.find((i) => i.id === 'website').note, /"Website and app" step/);
  } finally { rmSync(root, { recursive: true, force: true }); rmSync(root2, { recursive: true, force: true }); }
});
