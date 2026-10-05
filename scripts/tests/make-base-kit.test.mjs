// scripts/make-base-kit.mjs: which release file is which, and what it refuses.
import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, writeFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { createHash } from 'node:crypto';
import { makeBaseKit } from '../make-base-kit.mjs';

const folder = (files) => { const d = mkdtempSync(join(tmpdir(), 'base-kit-')); for (const [n, c] of Object.entries(files)) writeFileSync(d + '/' + n, c); return d; };
const sha = (t) => createHash('sha256').update(t).digest('hex');

test('every kind of release file gets its role, system and fingerprint; other files are left out and said', async () => {
  const d = folder({
    'SmartRetailPOS-Hub-Setup-2.0.1.exe': 'a', 'SmartRetailPOS-Hub-2.0.1-win-x64.zip': 'b', 'smart-retail-pos-hub_2.0.1-1_amd64.deb': 'c', 'smart-retail-pos-hub_2.0.1-1_arm64.deb': 'd',
    'SmartRetailAI-Setup.exe': 'e', 'SmartRetailPOS-luzon-fresh-mart-1.0.0.apk': 'f', 'SmartRetailPOS-luzon-fresh-mart-1.0.0.aab': 'g', 'SHA256SUMS.txt': 'x', 'notes.md': 'y',
    'ANDROID-SIGNING.txt': 'Signed with: one-off TEST key\n', 'WINDOWS-SIGNING.txt': 'NOT signed\n',
  });
  try {
    const { manifest, ignored } = await makeBaseKit(d, { now: new Date('2026-01-01T00:00:00Z') });
    assert.equal(manifest.version, '2.0.1');
    assert.equal(manifest.trial, false);
    assert.deepEqual(manifest.signing, { windows: 'NOT signed', android: 'one-off TEST key' });
    const by = Object.fromEntries(manifest.files.map((f) => [f.name, f]));
    assert.deepEqual([by['SmartRetailPOS-Hub-Setup-2.0.1.exe'].role, by['SmartRetailPOS-Hub-Setup-2.0.1.exe'].os, by['SmartRetailPOS-Hub-Setup-2.0.1.exe'].arch], ['hub-windows-setup', 'windows', 'x64']);
    assert.equal(by['smart-retail-pos-hub_2.0.1-1_arm64.deb'].arch, 'arm64');
    assert.equal(by['smart-retail-pos-hub_2.0.1-1_amd64.deb'].arch, 'x64');
    assert.equal(by['SmartRetailAI-Setup.exe'].role, 'ai-addon-windows');
    assert.deepEqual([by['SmartRetailPOS-luzon-fresh-mart-1.0.0.apk'].role, by['SmartRetailPOS-luzon-fresh-mart-1.0.0.apk'].kit], ['android-apk', 'luzon-fresh-mart']);
    assert.equal(by['SmartRetailPOS-luzon-fresh-mart-1.0.0.aab'].role, 'android-aab');
    assert.equal(by['SmartRetailPOS-Hub-Setup-2.0.1.exe'].sha256, sha('a'));
    assert.equal(by['SmartRetailPOS-Hub-Setup-2.0.1.exe'].bytes, 1);
    assert.deepEqual(ignored.sort(), ['ANDROID-SIGNING.txt', 'SHA256SUMS.txt', 'WINDOWS-SIGNING.txt', 'notes.md']);
  } finally { rmSync(d, { recursive: true, force: true }); }
});

test('a trial build (no licence keys) is marked as one', async () => {
  const d = folder({ 'SmartRetailPOS-Hub-Setup-1.0.0.exe': 'a', 'NO-LICENCE-KEYS-TRIAL-ONLY.txt': 'trial' });
  try { assert.equal((await makeBaseKit(d)).manifest.trial, true); } finally { rmSync(d, { recursive: true, force: true }); }
});

test('it refuses an empty folder, mixed Hub versions, and a version that is not three numbers', async () => {
  const empty = folder({ 'notes.md': 'x' });
  const mixed = folder({ 'SmartRetailPOS-Hub-Setup-1.0.0.exe': 'a', 'smart-retail-pos-hub_1.1.0-1_amd64.deb': 'b' });
  const ok = folder({ 'SmartRetailAI-Setup.exe': 'a' });
  try {
    await assert.rejects(makeBaseKit(empty), /No release file was recognised/);
    await assert.rejects(makeBaseKit(mixed), /different versions/);
    await assert.rejects(makeBaseKit(ok), /Say the version/);
    assert.equal((await makeBaseKit(ok, { version: '3.2.1' })).manifest.version, '3.2.1');
  } finally { for (const d of [empty, mixed, ok]) rmSync(d, { recursive: true, force: true }); }
});
