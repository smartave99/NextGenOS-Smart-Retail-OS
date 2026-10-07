#!/usr/bin/env node
/**
 * Makes the small stand-in apps that the Android tests read (tools/setup-studio/tests/fixtures/android/):
 *
 *   template.apk            a stand-in for the generic Android template (what the release workflow builds once per release), made with Google's own resource compiler (aapt2)
 *   template-optimized.apk  the same after aapt2's "optimize" step, which shortens file paths and hides resource names (what a release build with shrinking can look like)
 *   template.aab            the same as an app bundle (aapt2 in protobuf form, put together the way bundletool and Gradle do)
 *
 * It is NOT run by the tests or by the gate: the files it makes are checked in. It needs aapt2 and an Android framework package (framework-res), which Apktool carries (Apache-2.0):
 *
 *   node tools/setup-studio/scripts/make-android-fixture.mjs --aapt2 /path/to/aapt2 --framework /path/to/android-framework.jar [--bundletool /path/to/bundletool-all.jar]
 *
 * The files hold no key and no signature: they are not apps anyone could install (their classes.dex is empty). The look is the one of the real project (Android/app of the storefront):
 * the same manifest shape, the same adaptive icon, the same loading pictures per density and per night/day, with flat grey stand-in pictures.
 */
import { spawnSync } from 'node:child_process';
import { mkdtempSync, mkdirSync, writeFileSync, readFileSync, rmSync, copyFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { createHash } from 'node:crypto';
const adler32 = (buf) => { let a = 1; let b = 0; for (const byte of buf) { a = (a + byte) % 65521; b = (b + a) % 65521; } return ((b << 16) | a) >>> 0; };
import { solid, encodePng } from '../lib/android/png.mjs';
import { readZip, writeZip } from '../lib/android/zipfile.mjs';
import { TEMPLATE } from '../lib/android/template.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const out = resolve(here, '..', 'tests', 'fixtures', 'android');
const args = process.argv.slice(2);
const flag = (n) => { const i = args.indexOf(n); return i >= 0 ? args[i + 1] : undefined; };
const aapt2 = flag('--aapt2'); const framework = flag('--framework'); const bundletool = flag('--bundletool');
if (!aapt2 || !framework) { console.error('Give --aapt2 <path> and --framework <path to android-framework.jar>.'); process.exit(2); }
const run = (cmd, a) => { const r = spawnSync(cmd, a, { encoding: 'utf8' }); if (r.status !== 0) { console.error(`${cmd} ${a.join(' ')}\n${r.stdout}${r.stderr}`); process.exit(1); } return r.stdout; };

const work = mkdtempSync(join(tmpdir(), 'android-fixture-'));
try {
  const src = join(work, 'src'); const res = join(src, 'res'); const assets = join(src, 'assets');
  const put = (rel, data) => { const p = join(src, rel); mkdirSync(dirname(p), { recursive: true }); writeFileSync(p, data); };
  const grey = (w, h, v = 120) => encodePng(solid(w, h, [v, v, v]));

  // the same files and sizes the real project has (res/mipmap-*, res/drawable-*)
  const dens = { ldpi: 36, mdpi: 48, hdpi: 72, xhdpi: 96, xxhdpi: 144, xxxhdpi: 192 };
  const adaptive = { ldpi: 81, mdpi: 108, hdpi: 162, xhdpi: 216, xxhdpi: 324, xxxhdpi: 432 };
  for (const d of Object.keys(dens)) {
    put(`res/mipmap-${d}/ic_launcher.png`, grey(dens[d], dens[d], 100));
    put(`res/mipmap-${d}/ic_launcher_round.png`, grey(dens[d], dens[d], 110));
    put(`res/mipmap-${d}/ic_launcher_foreground.png`, grey(adaptive[d], adaptive[d], 130));
    put(`res/mipmap-${d}/ic_launcher_background.png`, grey(adaptive[d], adaptive[d], 140));
  }
  const portrait = { ldpi: [200, 320], mdpi: [320, 480], hdpi: [480, 800], xhdpi: [720, 1280], xxhdpi: [960, 1600], xxxhdpi: [1280, 1920] };
  for (const [d, [w, h]] of Object.entries(portrait)) {
    put(`res/drawable-port-${d}/splash.png`, grey(w, h, 200));
    put(`res/drawable-port-night-${d}/splash.png`, grey(w, h, 40));
    put(`res/drawable-land-${d}/splash.png`, grey(h, w, 200));
    put(`res/drawable-land-night-${d}/splash.png`, grey(h, w, 40));
  }
  put('res/drawable/splash.png', grey(480, 320, 200));
  put('res/drawable-night/splash.png', grey(480, 320, 40));
  const adaptiveXml = (kind) => `<?xml version="1.0" encoding="utf-8"?>\n<adaptive-icon xmlns:android="http://schemas.android.com/apk/res/android">\n    <background>\n        <inset android:drawable="@mipmap/ic_launcher_background" android:inset="16.7%" />\n    </background>\n    <foreground>\n        <inset android:drawable="@mipmap/ic_launcher_foreground" android:inset="16.7%" />\n    </foreground>\n</adaptive-icon>\n<!-- ${kind} -->`;
  put('res/mipmap-anydpi-v26/ic_launcher.xml', adaptiveXml('square'));
  put('res/mipmap-anydpi-v26/ic_launcher_round.xml', adaptiveXml('round'));
  put('res/values/strings.xml', `<?xml version='1.0' encoding='utf-8'?>\n<resources>\n    <string name="app_name">${TEMPLATE.appName}</string>\n    <string name="title_activity_main">${TEMPLATE.appName}</string>\n    <string name="package_name">${TEMPLATE.appId}</string>\n    <string name="custom_url_scheme">${TEMPLATE.appId}</string>\n</resources>\n`);
  put('res/values/ic_launcher_background.xml', '<?xml version="1.0" encoding="utf-8"?>\n<resources>\n    <color name="ic_launcher_background">#FFFFFF</color>\n</resources>\n');
  put('res/values/styles.xml', '<?xml version="1.0" encoding="utf-8"?>\n<resources>\n    <style name="AppTheme" parent="@android:style/Theme.Material.Light.DarkActionBar" />\n    <style name="AppTheme.NoActionBarLaunch" parent="@android:style/Theme.Material.Light.NoActionBar">\n        <item name="android:background">@drawable/splash</item>\n    </style>\n</resources>\n');
  put('res/xml/network_security_config.xml', readFileSync(resolve(here, '..', '..', '..', 'apps', 'storefront-web-mobile', 'android', 'app', 'src', 'main', 'res', 'xml', 'network_security_config.xml')));
  put('res/xml/file_paths.xml', readFileSync(resolve(here, '..', '..', '..', 'apps', 'storefront-web-mobile', 'android', 'app', 'src', 'main', 'res', 'xml', 'file_paths.xml')));
  put('assets/capacitor.config.json', JSON.stringify({ appId: TEMPLATE.appId, appName: TEMPLATE.appName, webDir: 'android-shell', server: { url: TEMPLATE.url, cleartext: false, allowNavigation: [new URL(TEMPLATE.url).hostname, `*.${new URL(TEMPLATE.url).hostname}`] }, android: { allowMixedContent: false, webContentsDebuggingEnabled: false }, loggingBehavior: 'none' }, null, 2) + '\n');
  put('assets/capacitor.plugins.json', '[]\n');
  put('assets/public/index.html', '<!doctype html>\n<html lang="en"><head><meta charset="utf-8"><title>Smart Retail POS</title><style>:root { --accent:#0071e3; }</style></head><body><main><h1>You are offline</h1></main></body></html>\n');
  put('assets/public/cordova.js', '// stand-in\n');
  put('assets/ngos-template.json', JSON.stringify({ schema: 1, kind: 'ngos-android-template', ...TEMPLATE }, null, 2) + '\n');

  const manifest = `<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="${TEMPLATE.namespace}">
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.CAMERA" />
    <uses-permission android:name="android.permission.RECORD_AUDIO" />
    <uses-feature android:name="android.hardware.camera" android:required="false" />
    <uses-feature android:name="android.hardware.microphone" android:required="false" />
    <permission android:name="${TEMPLATE.appId}.DYNAMIC_RECEIVER_NOT_EXPORTED_PERMISSION" android:protectionLevel="signature" />
    <uses-permission android:name="${TEMPLATE.appId}.DYNAMIC_RECEIVER_NOT_EXPORTED_PERMISSION" />
    <application
        android:allowBackup="false"
        android:fullBackupContent="false"
        android:usesCleartextTraffic="false"
        android:networkSecurityConfig="@xml/network_security_config"
        android:icon="@mipmap/ic_launcher"
        android:label="@string/app_name"
        android:roundIcon="@mipmap/ic_launcher_round"
        android:supportsRtl="true"
        android:theme="@style/AppTheme">
        <activity
            android:name="${TEMPLATE.namespace}.MainActivity"
            android:configChanges="orientation|keyboardHidden|keyboard|screenSize|locale|smallestScreenSize|screenLayout|uiMode|navigation|density"
            android:label="@string/title_activity_main"
            android:theme="@style/AppTheme.NoActionBarLaunch"
            android:launchMode="singleTask"
            android:exported="true">
            <intent-filter>
                <action android:name="android.intent.action.MAIN" />
                <category android:name="android.intent.category.LAUNCHER" />
            </intent-filter>
        </activity>
        <provider
            android:name="androidx.core.content.FileProvider"
            android:authorities="${TEMPLATE.appId}.fileprovider"
            android:exported="false"
            android:grantUriPermissions="true">
            <meta-data android:name="android.support.FILE_PROVIDER_PATHS" android:resource="@xml/file_paths" />
        </provider>
        <provider
            android:name="androidx.startup.InitializationProvider"
            android:authorities="${TEMPLATE.appId}.androidx-startup"
            android:exported="false">
            <meta-data android:name="androidx.emoji2.text.EmojiCompatInitializer" android:value="androidx.startup" />
        </provider>
    </application>
</manifest>
`;
  put('AndroidManifest.xml', manifest);

  const compiled = join(work, 'compiled.zip');
  run(aapt2, ['compile', '--dir', res, '-o', compiled]);
  const common = ['link', compiled, '-I', framework, '--manifest', join(src, 'AndroidManifest.xml'), '--min-sdk-version', '24', '--target-sdk-version', '36', '--version-code', String(TEMPLATE.versionCode), '--version-name', TEMPLATE.versionName, '--rename-manifest-package', TEMPLATE.appId, '--no-compile-sdk-metadata'];
  const plain = join(work, 'plain.apk');
  run(aapt2, [...common, '-A', assets, '-o', plain]);
  const optimized = join(work, 'optimized.apk');
  run(aapt2, ['optimize', '--shorten-resource-paths', '--collapse-resource-names', '--enable-sparse-encoding', '-o', optimized, plain]);

  // an empty but well-formed classes.dex, so the stand-in has the same shape as a real app
  const dex = Buffer.alloc(128);
  dex.write('dex\n035\0', 0, 'latin1');
  dex.writeUInt32LE(128, 32); dex.writeUInt32LE(112, 36); dex.writeUInt32LE(0x12345678, 40);
  dex.writeUInt32LE(112, 52);   // map_off
  dex.writeUInt32LE(16, 104); dex.writeUInt32LE(112, 108);   // data_size, data_off
  dex.writeUInt32LE(1, 112); dex.writeUInt16LE(0, 116); dex.writeUInt16LE(0, 118); dex.writeUInt32LE(1, 120); dex.writeUInt32LE(0, 124);   // map list: the header item
  createHash('sha1').update(dex.subarray(32)).digest().copy(dex, 12);
  dex.writeUInt32LE(adler32(dex.subarray(12)), 8);

  const finish = (apk, name) => {
    const z = readZip(readFileSync(apk));
    const items = z.entries.map((e) => ({ name: e.name, from: e }));
    items.push({ name: 'classes.dex', data: dex });
    // resources.arsc is stored and lined up, as Android 11 and later require
    const fixed = items.map((i) => (i.name === 'resources.arsc' ? { name: i.name, data: i.from.data(), store: true } : i));
    mkdirSync(out, { recursive: true });
    writeFileSync(join(out, name), writeZip(fixed));
    console.log(`wrote ${name}`);
  };
  finish(plain, 'template.apk');
  finish(optimized, 'template-optimized.apk');

  // the bundle: aapt2 in protobuf form, then the module laid out as bundletool wants it
  const proto = join(work, 'proto.apk');
  run(aapt2, [...common, '--proto-format', '-A', assets, '-o', proto]);
  const pz = readZip(readFileSync(proto));
  const moduleItems = [];
  for (const e of pz.entries) {
    if (e.name === 'AndroidManifest.xml') moduleItems.push({ name: 'manifest/AndroidManifest.xml', from: e });
    else moduleItems.push({ name: e.name, from: e });
  }
  moduleItems.push({ name: 'dex/classes.dex', data: dex });
  const moduleZip = join(work, 'base.zip');
  writeFileSync(moduleZip, writeZip(moduleItems));
  if (bundletool) {
    run('java', ['-jar', bundletool, 'build-bundle', `--modules=${moduleZip}`, `--output=${join(out, 'template.aab')}`, '--overwrite']);
    console.log('wrote template.aab');
  } else copyFileSync(moduleZip, join(work, 'unused'));
} finally { rmSync(work, { recursive: true, force: true }); }
