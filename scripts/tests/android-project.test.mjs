// The Android app (a shell around the customer's licensed website): its safety settings are still in place, and the script that sets it up for a
// customer works and refuses bad input. The app itself is built by the release workflow (it needs the Android SDK, which is not here).
import test from 'node:test';
import assert from 'node:assert/strict';
import { readFileSync, mkdtempSync, mkdirSync, cpSync, rmSync, existsSync, readdirSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const app = join(repo, 'apps', 'storefront-web-mobile');
const read = (p) => readFileSync(join(app, p), 'utf8');

test('the project says no to unencrypted traffic, debugging, backups and exposed parts', () => {
  const cap = JSON.parse(read('capacitor.config.json'));
  assert.match(cap.server.url, /^https:\/\//);
  assert.equal(cap.server.cleartext, false);
  assert.equal(cap.android.allowMixedContent, false);
  assert.equal(cap.android.webContentsDebuggingEnabled, false);
  assert.equal(cap.loggingBehavior, 'none');

  const manifest = read('android/app/src/main/AndroidManifest.xml');
  assert.match(manifest, /android:allowBackup="false"/);
  assert.match(manifest, /android:usesCleartextTraffic="false"/);
  assert.match(manifest, /android:networkSecurityConfig=/);
  assert.doesNotMatch(manifest, /android:debuggable="true"/);
  const exported = [...manifest.matchAll(/android:exported="true"/g)].length;
  assert.equal(exported, 1, 'only the main screen may be opened from outside');

  const net = read('android/app/src/main/res/xml/network_security_config.xml');
  assert.match(net, /cleartextTrafficPermitted="false"/);
  assert.doesNotMatch(net, /certificates src="user"/);

  const gradle = read('android/app/build.gradle');
  assert.match(gradle, /release\s*\{[^}]*minifyEnabled true/s);
  assert.match(gradle, /release\s*\{[^}]*debuggable false/s);
  assert.doesNotMatch(gradle, /(storePassword|keyPassword)\s+["'][^"']+["']/, 'no password in the build file');
  assert.doesNotMatch(gradle, /\.(jks|keystore)["']/, 'no key store file named in the build file');
});

test('the camera and microphone are asked for, never required', () => {
  const manifest = read('android/app/src/main/AndroidManifest.xml');
  assert.match(manifest, /uses-feature android:name="android.hardware.camera" android:required="false"/);
  assert.match(manifest, /uses-feature android:name="android.hardware.microphone" android:required="false"/);
});

function copyOfProject() {
  const root = mkdtempSync(join(tmpdir(), 'android-cfg-'));
  mkdirSync(join(root, 'scripts'), { recursive: true });
  cpSync(join(app, 'scripts', 'android-config.mjs'), join(root, 'scripts', 'android-config.mjs'));
  cpSync(join(app, 'capacitor.config.json'), join(root, 'capacitor.config.json'));
  cpSync(join(app, 'android', 'app', 'build.gradle'), join(root, 'android', 'app', 'build.gradle'), { recursive: true });
  cpSync(join(app, 'android', 'app', 'src', 'main', 'java'), join(root, 'android', 'app', 'src', 'main', 'java'), { recursive: true });
  mkdirSync(join(root, 'android', 'app', 'src', 'main', 'res', 'values'), { recursive: true });
  return root;
}
const configure = (root, ...a) => spawnSync('node', [join(root, 'scripts', 'android-config.mjs'), ...a], { encoding: 'utf8' });

test('setting the app up for a customer changes its id, name, address and version everywhere, and nothing of ours stays', () => {
  const root = copyOfProject();
  try {
    const r = configure(root, '--app-id', 'com.luzonfresh.shop', '--app-name', 'Luzon Fresh', '--url', 'https://shop.luzonfresh.example', '--version-name', '2.3.4', '--version-code', '7');
    assert.equal(r.status, 0, r.stderr);
    const cap = JSON.parse(readFileSync(join(root, 'capacitor.config.json'), 'utf8'));
    assert.equal(cap.appId, 'com.luzonfresh.shop');
    assert.equal(cap.server.url, 'https://shop.luzonfresh.example');
    assert.deepEqual(cap.server.allowNavigation, ['shop.luzonfresh.example', '*.shop.luzonfresh.example']);
    assert.equal(cap.server.cleartext, false);
    const gradle = readFileSync(join(root, 'android/app/build.gradle'), 'utf8');
    assert.match(gradle, /applicationId "com\.luzonfresh\.shop"/);
    assert.match(gradle, /versionCode 7/);
    assert.match(gradle, /versionName "2\.3\.4"/);
    assert.match(readFileSync(join(root, 'android/app/src/main/res/values/strings.xml'), 'utf8'), /Luzon Fresh/);
    assert.ok(existsSync(join(root, 'android/app/src/main/java/com/luzonfresh/shop/MainActivity.java')));
    assert.doesNotMatch(readFileSync(join(root, 'android/app/src/main/java/com/luzonfresh/shop/MainActivity.java'), 'utf8'), /nextgenos|smartavenue/i);
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('a wrong id, an unencrypted or path-bearing address, a bad name or a bad version is refused', () => {
  const root = copyOfProject();
  try {
    const ok = ['--app-id', 'com.shop.app', '--app-name', 'Shop', '--url', 'https://shop.example.com'];
    const refuse = (patch, expect) => {
      const a = [...ok];
      for (const [k, v] of Object.entries(patch)) a[a.indexOf(k) + 1] = v;
      const r = configure(root, ...a);
      assert.notEqual(r.status, 0, JSON.stringify(patch));
      assert.match(r.stderr, expect);
    };
    refuse({ '--app-id': 'Shop' }, /app id/i);
    refuse({ '--app-id': 'com.Shop.App' }, /app id/i);
    refuse({ '--url': 'http://shop.example.com' }, /https/);
    refuse({ '--url': 'https://shop.example.com/path' }, /https/);
    refuse({ '--app-name': 'Bad <name>' }, /name/i);
    const r = configure(root, ...ok, '--version-name', 'one');
    assert.notEqual(r.status, 0);
    assert.match(r.stderr, /version/i);
  } finally { rmSync(root, { recursive: true, force: true }); }
});

test('every brand kit that names an Android app gives a valid id and an https address', () => {
  const kits = join(repo, 'brand-kits');
  for (const d of readdirSync(kits, { withFileTypes: true }).filter((e) => e.isDirectory())) {
    const brand = JSON.parse(readFileSync(join(kits, d.name, 'brand.json'), 'utf8'));
    if (!brand.android) continue;
    assert.match(brand.android.appId, /^[a-z][a-z0-9_]*(\.[a-z][a-z0-9_]*){2,}$/, d.name);
    assert.match(brand.android.storefrontUrl, /^https:\/\/[a-z0-9.-]+$/i, d.name);
  }
});
