#!/usr/bin/env node
/**
 * Writes the text of the GitHub Release page from the files that were really built, so that the page tells a person what to download and what to do with it.
 *
 *   node scripts/make-release-notes.mjs --dist dist --commit <sha> [--tag v1.0.0] [--version 1.0.0] [--only studio] [--template .github/release-notes.md] [--out notes.md]
 *
 * --only studio is the page of a release of the Setup Studio alone (a tag such as studio-v1.0.0): it uses .github/release-notes-studio.md and speaks only of the Studio.
 *
 * The frame of the page (what to read before testing, support) is the template .github/release-notes.md; it has these places, each written as two curly brackets around a name:
 * TRIAL_BANNER, VERSION, START_HERE (one section for each thing a person can try, with its steps), MISSING (what is not in this release, and why), ALL_FILES,
 * STATUS (BUILD-STATUS.txt) and COMMIT. A part that did not build is not described as if it were there: it is named under "Not in this release". Nothing about a customer is
 * written here: the website and the app say whose they are only because their file names do.
 */
import { existsSync, readdirSync, readFileSync, statSync, writeFileSync } from 'node:fs';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { RULES } from './make-base-kit.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const PLACES = ['TRIAL_BANNER', 'VERSION', 'CHANGELOG', 'START_HERE', 'MISSING', 'ALL_FILES', 'STATUS', 'COMMIT'];

/** Reads the newest entry from the relevant changelog file. */
function readChangelog(repo, only = '') {
  const file = only === 'studio'
    ? join(repo, 'tools', 'setup-studio', 'CHANGELOG.md')
    : join(repo, 'apps', 'business-hub', 'CHANGELOG.md');
  const fallback = join(repo, 'CHANGELOG.md');
  const target = existsSync(file) ? file : existsSync(fallback) ? fallback : null;
  if (!target) return '';
  const text = readFileSync(target, 'utf8');
  // The newest entry is everything from the first "## " heading to the next one (or the end of the file). ("$" with the m flag stops at the end of the first line, which cut the list to its first heading.)
  const m = /^##\s+[^\r\n]+[\r\n]+([\s\S]*?)(?=^##\s+|(?![\s\S]))/m.exec(text);
  if (!m) return '';
  // Folded away, so that the table of what to download stays near the top of the page.
  return `### What changed in this version (Change log)\n\n<details>\n<summary>Open the list</summary>\n\n${m[0].trim()}\n\n</details>\n\n`;
}

/** What each file that is not a program is, by its exact name. */
const NOTES = new Map([
  ['HOW-TO-TRY.txt', 'The long, step-by-step test plan for NextGenOS staff (the Studio, the Windows setup, the Linux package).'],
  ['BUILD-STATUS.txt', 'Which parts were built in this run, and which were not.'],
  ['SHA256SUMS.txt', 'Fingerprints, to check that a download is whole and unchanged.'],
  ['base-kit.json', 'The list the Setup Studio reads: which file is which, with its fingerprint.'],
  ['NO-LICENCE-KEYS-TRIAL-ONLY.txt', 'Says this is a trial built without licence keys. Never give it to a customer.'],
  ['WINDOWS-SIGNING.txt', 'Says whether the Windows setup is signed.'],
  ['ANDROID-SIGNING.txt', 'Says which key signed the Android app.'],
]);

const ROLE_TEXT = {
  'hub-windows-setup': 'The shop program (Business Hub) for Windows 10/11: the setup.',
  'hub-windows-zip': 'The same shop program as a plain folder, for a person who sets it up by hand: unpack it and double-click "Start Business Hub" (no black window; its READ ME FIRST says more). The setup is the normal way.',
  'hub-linux-deb': 'The shop program (Business Hub) for Ubuntu, Linux Mint and Debian.',
  'website-generic': 'The online shop (website) program, the same for every customer, with its own Node.js inside. The Setup Studio puts a customer\'s folder and licence beside it.',
  website: 'The online shop (website) made for one customer, with its own Node.js inside.',
  'android-apk': 'The Android app, to install on a phone.',
  'android-aab': 'The Android app in the form Google Play takes (for NextGenOS staff).',
};

const mb = (bytes) => (bytes < 1048576 ? `${Math.max(1, Math.round(bytes / 1024))} KB` : `${(bytes / 1048576).toFixed(1)} MB`);

/** The files of the release folder, each with what it is. */
function inventory(dist) {
  const out = [];
  for (const name of readdirSync(dist).sort()) {
    const path = join(dist, name);
    if (!statSync(path).isFile()) continue;
    let what = NOTES.get(name) ?? null;
    let role = null;
    let info = {};
    for (const [pattern, r, extra] of RULES) {
      const m = pattern.exec(name);
      if (m) { role = r; info = extra(m); what = what ?? ROLE_TEXT[r]; break; }
    }
    const studio = /^NextGenOS-Setup-Studio-(\d+\.\d+\.\d+)-(windows|linux)\.zip$/.exec(name);
    if (studio) { role = 'studio'; info = { os: studio[2] }; what = 'The Setup Studio for NextGenOS staff, with its own Node.js. Never for a customer.'; }
    const studioSetup = /^NextGenOS-Setup-Studio-Setup-(\d+\.\d+\.\d+)\.exe$/.exec(name);
    if (studioSetup) { role = 'studio-installer'; info = { os: 'windows' }; what = 'The Setup Studio for Windows: 1-click setup installer (NextGenOS staff only).'; }
    out.push({ name, role, ...info, bytes: statSync(path).size, what: what ?? 'Other file of this release.' });
  }
  return out;
}

const readText = (dist, name) => (existsSync(join(dist, name)) ? readFileSync(join(dist, name), 'utf8').trim() : '');
const code = (s) => '`' + s + '`';

function startHere(files, ctx) {
  const by = (role, os) => files.filter((f) => f.role === role && (!os || f.os === os));
  const sections = [];
  const trialNote = ctx.trial
    ? 'This is a trial build, so it says the program **needs a licence**. That is the correct result: nothing more opens without a licence key.'
    : 'When it asks for a licence key, type the key NextGenOS gave you.';

  const studioOnly = ctx.only === 'studio';
  const [setup] = studioOnly ? [] : by('hub-windows-setup');
  if (setup) {
    sections.push([
      '#### The shop program on a Windows PC (Windows 10 or 11, 64-bit)',
      `Download ${code(setup.name)}.`,
      '1. Double-click it and answer **Yes** when Windows asks for permission.',
      ctx.windowsSigned
        ? '2. Windows shows the publisher\'s name. That is expected.'
        : '2. Windows may say "unknown publisher", because this setup is not signed yet. Click **More info**, then **Run anyway**.',
      '3. When it finishes, the program opens in a window of its own (no address bar). The program runs in the background and starts by itself every time the PC starts (it is a Windows service), so closing the window does not stop it. Open it again from the Smart Retail POS icon on the desktop or in the Start menu.',
      `4. ${trialNote}`,
      '5. To remove it: Settings, then Apps. The shop\'s information stays on the PC on purpose (folder `C:\\ProgramData\\NextGenOS`).',
    ]);
  }

  const debs = studioOnly ? [] : by('hub-linux-deb');
  if (debs.length) {
    const first = debs.find((d) => d.arch === 'x64') ?? debs[0];
    sections.push([
      '#### The shop program on Linux (Ubuntu 22.04 or 24.04, Linux Mint 21 or later, Debian 12 or later)',
      `Download ${debs.map((d) => code(d.name) + (d.arch === 'x64' ? ' (Intel or AMD computers: most PCs)' : ' (ARM computers)')).join(' or ')}.`,
      '1. Open a terminal in the folder where you saved it.',
      `2. Type ${code('sudo apt install ./' + first.name)} and press Enter.`,
      '3. Choose "Smart Retail POS" in the applications menu: the program opens in a window of its own (no address bar). The program runs in the background and starts by itself every time the computer starts, so closing the window does not stop it.',
      `4. ${trialNote}`,
      '5. To remove it: `sudo apt remove smart-retail-pos-hub`. The shop\'s information stays in `/var/lib/nextgenos` on purpose.',
    ]);
  }

  const sites = studioOnly ? [] : [...by('website-generic'), ...by('website')];
  if (sites.length) {
    const win = sites.find((s) => s.os === 'windows');
    const lin = sites.find((s) => s.os === 'linux');
    const lines = [
      '#### The online shop (website)',
      `Download ${sites.map((s) => code(s.name) + (s.os === 'windows' ? ' (Windows)' : ' (Linux)')).join(' or ')}.`,
    ];
    if (win) lines.push(`- **Windows:** right-click ${code(win.name)} and choose Extract All. Open the new folder and double-click **Start Website** (the icon with the blue box). The website opens in a window of its own; there is no black terminal window. Windows may say "Windows protected your PC" (the program is not signed yet): click **More info**, then **Run anyway**.`);
    if (lin) lines.push(`- **Linux:** unzip ${code(lin.name)}, open a terminal in the new folder and type ${code('./start-website.sh --app')}. The website opens in a window of its own and the terminal can be closed at once. ${code('./start-website.sh --install-menu')} puts it in the applications menu.`);
    lines.push('- To stop it, close its window. Opening it again while it is open only brings up the same window.');
    lines.push(`- ${ctx.trial ? 'This is a trial build: the window shows the page where a licence key is typed, and nothing can be activated. Visitors to a website with no licence see a page that says it is not available. That is the correct result for a trial.' : 'With no licence yet the window shows the page where the licence key is typed. The shop shows once the customer\'s licence is in.'}`);
    const kits = [...new Set(sites.filter((s) => s.kit).map((s) => s.kit))];
    if (sites.some((s) => !s.kit)) lines.push('- This is THE website: the same program for every customer, with nothing of a customer inside. Opened as it is, it shows a plain shop with no name, no country and no money symbol. A customer\'s own website is made by the Setup Studio, on a staff computer, by putting that customer\'s folder (name, address, country, language, colours, logo) and licence file beside this program: nothing is built.');
    if (kits.length) lines.push(`- ${kits.length === 1 ? 'This website was' : 'These websites were'} made for ${kits.map((k) => code(k)).join(', ')} (the name in the file): the customer's settings are in the folder "customer" beside the program.`);
    if (win) lines.push('- The Windows one was started by the build machine, not by a person on a real PC yet.');
    sections.push(lines);
  }

  const [apk] = studioOnly ? [] : by('android-apk');
  const [aab] = studioOnly ? [] : by('android-aab');
  if (apk || aab) {
    const lines = ['#### The Android app'];
    if (apk) {
      lines.push(
        `Download ${code(apk.name)}.`,
        '1. Copy it to the phone (or download it on the phone) and open it.',
        '2. Android asks to allow installing apps from this source: allow it for this one install.',
        `3. The app opens the shop's website. ${apk.kit === 'example-shop' ? 'This one is the example app: it opens the placeholder address `https://shop.example.com`, so it shows an error page. A customer\'s app is built for the customer\'s real website.' : `This one opens the website of ${code(apk.kit)}.`}`,
        `4. Signed with: ${ctx.androidSigning || 'not said'}.`,
      );
    }
    if (aab) lines.push('', `${code(aab.name)} is the same app in the form Google Play takes. It is for NextGenOS staff to upload to Google Play; do not install it.`);
    sections.push(lines);
  }

  const studios = files.filter((f) => f.role === 'studio' || f.role === 'studio-installer');
  if (studios.length) {
    const installer = studios.find((s) => s.role === 'studio-installer');
    const win = studios.find((s) => s.role === 'studio' && s.os === 'windows');
    const lin = studios.find((s) => s.role === 'studio' && s.os === 'linux');
    const zips = studios.filter((s) => s.role === 'studio');
    const lines = [
      '#### For NextGenOS staff only: the Setup Studio',
    ];
    if (installer) {
      lines.push(
        `Download **${code(installer.name)}** (the Windows 1-click installer) or ${zips.map((s) => code(s.name) + (s.os === 'windows' ? ' (Windows portable zip)' : ' (Linux zip)')).join(' or ')}. **Never give it to a customer.**`,
        '',
        `1. **Windows 1-click install:** double-click ${code(installer.name)} and follow the setup wizard. It adds shortcuts to your Desktop and Start menu and opens Setup Studio in a window of its own (no terminal).`,
        installer && !ctx.windowsSigned ? '   Windows may say "Windows protected your PC", because the program is not signed yet. Click **More info**, then **Run anyway**.' : '',
        `2. **Or run portable from zip:** unzip ${code((win ?? lin).name)} and double-click **Setup Studio** (or ${code('./setup-studio.sh')} on Linux).`,
        '3. The first time, make the administrator account (a name and a password of at least 8 characters).',
        '4. To stop the Studio, close its window, or press the power button at the bottom left of the Studio. Opening it again while it is open just brings up its window.',
        studioOnly
          ? '5. To make a customer\'s setup the Studio needs the programs of a full release (the shop program, the website and the Android app): download every file of that release into one folder and give that folder to the Studio (Settings, "The programs folder"). This release holds only the Studio.'
          : '5. To make a customer\'s setup, download every file of this release into one folder and give that folder to the Studio (Settings, "The programs folder"). It uses `base-kit.json` to check that no file is damaged.',
        files.some((f) => f.name === 'HOW-TO-TRY.txt') ? `6. The whole walk-through, with what to look for, is in ${code('HOW-TO-TRY.txt')}.` : '',
      );
    } else {
      lines.push(
        `Download ${studios.map((s) => code(s.name) + (s.os === 'windows' ? ' (Windows)' : ' (Linux)')).join(' or ')}. **Never give it to a customer.**`,
        '1. Unzip it, and open the folder "NextGenOS Setup Studio" inside.',
        `2. ${[win ? 'Windows: double-click **Setup Studio** (the icon with the blue box)' : '', lin ? `Linux: type ${code('./setup-studio.sh')} in a terminal in that folder (the terminal can be closed at once; ${code('./setup-studio.sh --install-menu')} puts the Studio in the applications menu)` : ''].filter(Boolean).join('. ')}. The Studio opens in a window of its own. There is no black terminal window.`,
        win ? '   Windows may say "Windows protected your PC", because the program is not signed yet. Click **More info**, then **Run anyway**.' : '',
        '3. The first time, make the administrator account (a name and a password of at least 8 characters).',
        '4. To stop the Studio, close its window, or press the power button at the bottom left of the Studio. Opening it again while it is open just brings up its window.',
        studioOnly
          ? '5. To make a customer\'s setup the Studio needs the programs of a full release (the shop program, the website and the Android app): download every file of that release into one folder and give that folder to the Studio (Settings, "The programs folder"). This release holds only the Studio.'
          : '5. To make a customer\'s setup, download every file of this release into one folder and give that folder to the Studio (Settings, "The programs folder"). It uses `base-kit.json` to check that no file is damaged.',
        files.some((f) => f.name === 'HOW-TO-TRY.txt') ? `6. The whole walk-through, with what to look for, is in ${code('HOW-TO-TRY.txt')}.` : '',
      );
    }
    sections.push(lines.filter((l) => l !== ''));
  }

  if (files.some((f) => f.name === 'SHA256SUMS.txt')) {
    sections.push([
      '#### Check your download (optional)',
      `${code('SHA256SUMS.txt')} lists a fingerprint for every file. On Windows, type ${code('certutil -hashfile <file name> SHA256')} in a command window and compare. On Linux, type ${code('sha256sum -c SHA256SUMS.txt --ignore-missing')} in the folder.`,
    ]);
  }

  if (!sections.length) return '### Start here\n\nThere is no program in this release: see the file list below and `BUILD-STATUS.txt`.\n';
  const table = [
    '| I want to try | Download |',
    '|---|---|',
    ...[
      ['The shop program on Windows', studioOnly ? [] : by('hub-windows-setup').map((f) => f.name)],
      ['The shop program on Linux', studioOnly ? [] : by('hub-linux-deb').map((f) => f.name)],
      ['The online shop (website)', studioOnly ? [] : [...by('website-generic'), ...by('website')].map((f) => f.name)],
      ['The Android app', studioOnly ? [] : by('android-apk').map((f) => f.name)],
      ['The Setup Studio for Windows (1-click installer)', files.filter((f) => f.role === 'studio-installer').map((f) => f.name)],
      [files.some((f) => f.role === 'studio-installer') ? 'The Setup Studio (portable zip)' : 'The Setup Studio (NextGenOS staff only)', files.filter((f) => f.role === 'studio').map((f) => f.name)],
    ].filter(([, names]) => names.length).map(([what, names]) => `| ${what} | ${names.map(code).join('<br>')} |`),
  ].join('\n');
  // A blank line after the heading and after the "Download ..." line, so every list is drawn as a list.
  const drawn = sections.map(([heading, download, ...steps]) => [heading, '', download, '', ...steps].join('\n') + '\n');
  return ['### Start here: what do you want to try?', '', table, '', ...drawn].join('\n');
}

/** The parts that are not in the folder, each with the line of the status that says what happened to it. */
function missing(files, status, only = '') {
  const has = (role, os, arch) => files.some((f) => f.role === role && (!os || f.os === os) && (!arch || f.arch === arch));
  const line = (re) => status.split('\n').find((l) => re.test(l)) ?? '';
  const parts = [
    ['The shop program for Windows (the setup)', !has('hub-windows-setup'), /^Windows setup/],
    ['The shop program for Linux, Intel or AMD', !has('hub-linux-deb', 'linux', 'x64'), /^Linux packages/],
    ['The shop program for Linux, ARM', !has('hub-linux-deb', 'linux', 'arm64'), /^Linux packages/],
    ['The website for Windows', !has('website-generic', 'windows') && !has('website', 'windows'), /^Website/],
    ['The website for Linux', !has('website-generic', 'linux') && !has('website', 'linux'), /^Website/],
    ['The Android app', !has('android-apk'), /^Android/],
    ['The Setup Studio for Windows', !has('studio', 'windows') && !has('studio-installer', 'windows'), /^Setup Studio/],
    ['The Setup Studio for Linux', !has('studio', 'linux'), /^Setup Studio/],
  ].filter(([what, absent]) => absent && (only !== 'studio' || /Setup Studio/.test(what)));
  if (!parts.length) return '';
  return ['### Not in this release', '', 'These were not built in this run, so there is nothing to download for them. `BUILD-STATUS.txt` has the result of each step.', '',
    ...parts.map(([what, , re]) => `- **${what}.**${line(re) ? ` Status: ${line(re)}` : ''}`), ''].join('\n');
}

function allFiles(files) {
  const rows = files.map((f) => `| ${code(f.name)} | ${mb(f.bytes)} | ${f.what} |`);
  return ['<details>', '<summary><b>All files in this release</b></summary>', '', '| File | Size | What it is |', '|---|---|---|', ...rows, '', '</details>', ''].join('\n');
}

export function makeNotes({ dist, template, commit, tag = '', version = '', only = '' }) {
  if (only && only !== 'studio') throw new Error(`--only can be "studio", not "${only}".`);
  const files = inventory(dist);
  const hub = files.find((f) => f.role?.startsWith('hub-'));
  const fromName = hub ? /(\d+\.\d+\.\d+)/.exec(hub.name)?.[1] : '';
  const fromStudio = /(\d+\.\d+\.\d+)/.exec(files.find((f) => f.role === 'studio' || f.role === 'studio-installer')?.name ?? '')?.[1] ?? '';
  const fromTag = /^(?:studio-)?v?(\d+\.\d+\.\d+)/.exec(tag)?.[1] ?? '';
  const status = readText(dist, 'BUILD-STATUS.txt');
  const trial = existsSync(join(dist, 'NO-LICENCE-KEYS-TRIAL-ONLY.txt'));
  const ctx = {
    only,
    trial,
    windowsSigned: /^signed/i.test(readText(dist, 'WINDOWS-SIGNING.txt')),
    androidSigning: readText(dist, 'ANDROID-SIGNING.txt').replace(/^Signed with:\s*/i, ''),
  };
  const values = {
    TRIAL_BANNER: trial
      ? '> **TRIAL BUILD, NO LICENCE KEYS.** The programs in this release can never be activated. They are only for trying the install, the service and the uninstall. Never give them to a customer.\n\n'
      : '',
    VERSION: version || (only === 'studio' ? fromStudio : fromName) || fromTag || 'unknown',
    CHANGELOG: readChangelog(resolve(here, '..'), only),
    START_HERE: startHere(files, ctx),
    MISSING: missing(files, status, only),
    ALL_FILES: allFiles(files),
    STATUS: status || 'No status was written.',
    COMMIT: commit || 'an unknown commit',
  };
  let text = readFileSync(template, 'utf8');
  const used = [...text.matchAll(/\{\{([A-Z_]+)\}\}/g)].map((m) => m[1]);
  const unknown = used.filter((u) => !PLACES.includes(u));
  if (unknown.length) throw new Error(`The template has places this program does not know: ${[...new Set(unknown)].join(', ')}.`);
  for (const place of PLACES) text = text.split(`{{${place}}}`).join(values[place]);
  return text.replace(/\n{3,}/g, '\n\n');
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const args = process.argv.slice(2);
  const flag = (name, fallback = '') => { const i = args.indexOf(name); return i >= 0 && args[i + 1] ? args[i + 1] : fallback; };
  const dist = flag('--dist');
  if (!dist || !existsSync(dist)) { console.error('Usage: node scripts/make-release-notes.mjs --dist <folder of release files> --commit <sha> [--tag v1.0.0] [--version 1.0.0] [--only studio] [--template file] [--out file]'); process.exit(2); }
  try {
    const only = flag('--only');
    const text = makeNotes({ dist: resolve(dist), template: resolve(flag('--template', join(here, '..', '.github', only === 'studio' ? 'release-notes-studio.md' : 'release-notes.md'))), commit: flag('--commit'), tag: flag('--tag'), version: flag('--version'), only });
    if (flag('--out')) writeFileSync(resolve(flag('--out')), text);
    else process.stdout.write(text);
  } catch (e) { console.error(String(e.message || e)); process.exit(1); }
}
