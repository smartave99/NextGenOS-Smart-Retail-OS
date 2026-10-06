#!/usr/bin/env node
/**
 * The release files travel between the build jobs of the Release workflow through a DRAFT GitHub Release, not through the workflow's artifact storage
 * (that storage has a small quota per account, and a release of this size fills it). The files are only visible to people who can write to the repository until the
 * last job publishes the release.
 *
 *   node scripts/release-assets.mjs create   --tag v1.0.0-trial3 --target <commit> --title "..." [--prerelease] [--notes-file file] [--make-tag]
 *       makes the draft (or finds the release that already has this tag, drafts included), prints its number and writes release_id= to $GITHUB_OUTPUT.
 *       --make-tag also makes the tag at the commit when it does not exist yet. GitHub lets the workflow's token make a tag or a release only at the newest commit of the
 *       branch, so this is done in the first seconds of a run, while its commit is that commit, and not after the long build.
 *   node scripts/release-assets.mjs discard  --release <number> [--tag v1.0.0-trial3]
 *       removes a draft that is not wanted (never a published release) and the tag named, but only a tag that points at no other release
 *   node scripts/release-assets.mjs upload   --release <number> <file>...      a file with the same name on the release is replaced
 *   node scripts/release-assets.mjs download --release <number> --out <folder>
 *   node scripts/release-assets.mjs publish  --release <number> [--notes-file file]    the draft becomes a published release
 *
 * It needs GITHUB_TOKEN (or GH_TOKEN) with write access to the repository's contents, and GITHUB_REPOSITORY (owner/name). GITHUB_API_URL is the usual
 * variable of the Actions runner; the tests point it at a small stand-in server.
 */
import { appendFileSync, mkdirSync, readFileSync, statSync, writeFileSync } from 'node:fs';
import { basename, join, resolve } from 'node:path';

const api = (process.env.GITHUB_API_URL || 'https://api.github.com').replace(/\/$/, '');
const token = process.env.GITHUB_TOKEN || process.env.GH_TOKEN || '';
const repo = process.env.GITHUB_REPOSITORY || '';

const fail = (message) => { console.error(message); process.exit(1); };
const sleep = (ms) => new Promise((r) => setTimeout(r, ms));

function headers(extra = {}) {
  return { authorization: `Bearer ${token}`, accept: 'application/vnd.github+json', 'x-github-api-version': '2022-11-28', 'user-agent': 'nextgenos-release', ...extra };
}

/** One request, tried again (up to 4 times) when the network or GitHub has a passing problem. */
async function call(method, url, { body, extra, raw } = {}) {
  let last;
  for (let attempt = 1; attempt <= 4; attempt += 1) {
    try {
      const res = await fetch(url.startsWith('http') ? url : `${api}${url}`, { method, headers: headers(extra), body });
      if (res.status >= 500 || res.status === 429) { last = new Error(`GitHub answered ${res.status}`); await sleep(1000 * attempt * attempt); continue; }
      if (!res.ok) { const text = await res.text().catch(() => ''); throw Object.assign(new Error(`GitHub answered ${res.status} for ${method} ${url.replace(/\?.*/, '')}: ${text.slice(0, 300)}`), { status: res.status }); }
      return raw ? res : res.status === 204 ? null : await res.json();
    } catch (e) {
      if (e.status) throw e;
      last = e;
      await sleep(1000 * attempt * attempt);
    }
  }
  throw last;
}

async function listAll(path) {
  const all = [];
  for (let page = 1; page <= 20; page += 1) {
    const items = await call('GET', `${path}${path.includes('?') ? '&' : '?'}per_page=100&page=${page}`);
    all.push(...items);
    if (items.length < 100) break;
  }
  return all;
}

const flag = (args, name) => { const i = args.indexOf(name); return i >= 0 ? args[i + 1] : undefined; };

/** Makes the tag at the commit when there is none. Says what to do when GitHub refuses (the branch has moved on since the run began). */
async function makeTag(tag, target) {
  try {
    await call('GET', `/repos/${repo}/git/ref/tags/${encodeURIComponent(tag)}`);
    return false;
  } catch (e) {
    if (e.status !== 404) throw e;
  }
  try {
    await call('POST', `/repos/${repo}/git/refs`, { body: JSON.stringify({ ref: `refs/tags/${tag}`, sha: target }), extra: { 'content-type': 'application/json' } });
  } catch (e) {
    if (e.status === 403) throw new Error(`GitHub does not let this run make the tag ${tag} at ${target.slice(0, 7)}. It only allows the newest commit of the branch: something was pushed to the branch after this run began. Start the run again and push nothing for the first minute.\n${e.message}`);
    throw e;
  }
  console.log(`Made the tag ${tag} at ${target.slice(0, 7)}.`);
  return true;
}

async function create(args) {
  const tag = flag(args, '--tag'); const target = flag(args, '--target'); const title = flag(args, '--title') || tag;
  if (!tag || !target) fail('Say the tag and the commit: --tag v1.0.0 --target <commit>');
  const notesFile = flag(args, '--notes-file');
  const body = notesFile ? readFileSync(notesFile, 'utf8') : 'The release files are being built. This page is complete when the release is published.';
  const tagMade = args.includes('--make-tag') ? await makeTag(tag, target) : false;
  const existing = (await listAll(`/repos/${repo}/releases`)).find((r) => r.tag_name === tag);
  const release = existing ?? await call('POST', `/repos/${repo}/releases`, {
    body: JSON.stringify({ tag_name: tag, target_commitish: target, name: title, body, draft: true, prerelease: args.includes('--prerelease') }),
    extra: { 'content-type': 'application/json' },
  });
  console.log(`${existing ? 'Using the release that already has' : 'Made a draft release for'} ${tag}: number ${release.id}${release.draft ? ' (draft)' : ' (published)'}.`);
  if (process.env.GITHUB_OUTPUT) appendFileSync(process.env.GITHUB_OUTPUT, `release_id=${release.id}\ntag=${tag}\ntag_made=${tagMade}\n`);
  else console.log(release.id);
}

async function upload(args) {
  const id = flag(args, '--release');
  if (!id) fail('Say the release: --release <number>');
  const files = args.filter((a, i) => !a.startsWith('--') && args[i - 1] !== '--release').filter((f) => { try { return statSync(f).isFile(); } catch { return false; } });
  if (!files.length) fail('There is no file to put on the release.');
  const release = await call('GET', `/repos/${repo}/releases/${id}`);
  const base = release.upload_url.replace(/\{.*$/, '');
  const present = await listAll(`/repos/${repo}/releases/${id}/assets`);
  for (const file of files) {
    const name = basename(file);
    for (const old of present.filter((a) => a.name === name)) await call('DELETE', `/repos/${repo}/releases/assets/${old.id}`);
    const bytes = readFileSync(file);
    await call('POST', `${base}?name=${encodeURIComponent(name)}`, { body: bytes, extra: { 'content-type': 'application/octet-stream', 'content-length': String(bytes.length) } });
    console.log(`Put ${name} on the release (${(bytes.length / 1048576).toFixed(1)} MB).`);
  }
}

async function download(args) {
  const id = flag(args, '--release'); const out = flag(args, '--out');
  if (!id || !out) fail('Say the release and the folder: --release <number> --out <folder>');
  mkdirSync(out, { recursive: true });
  const assets = await listAll(`/repos/${repo}/releases/${id}/assets`);
  if (!assets.length) fail('The release has no files.');
  for (const asset of assets) {
    // A name is a file name and nothing more.
    if (asset.name !== basename(asset.name) || asset.name.includes('..') || /[\\/]/.test(asset.name)) fail(`The release has a file with a name that is not allowed: ${asset.name}`);
    const res = await call('GET', `/repos/${repo}/releases/assets/${asset.id}`, { extra: { accept: 'application/octet-stream' }, raw: true });
    writeFileSync(join(resolve(out), asset.name), Buffer.from(await res.arrayBuffer()));
    console.log(`Got ${asset.name}.`);
  }
}

async function discard(args) {
  const id = flag(args, '--release'); const tag = flag(args, '--tag');
  if (!id) fail('Say the release: --release <number>');
  const release = await call('GET', `/repos/${repo}/releases/${id}`).catch((e) => { if (e.status === 404) return null; throw e; });
  if (release && !release.draft) fail(`Release ${release.tag_name} is published; it is not removed.`);
  if (release) { await call('DELETE', `/repos/${repo}/releases/${id}`); console.log(`Removed the draft release ${release.tag_name}.`); }
  if (tag) {
    // Only when no release uses the tag any more.
    const used = (await listAll(`/repos/${repo}/releases`)).some((r) => r.tag_name === tag);
    if (used) { console.log(`The tag ${tag} stays: a release still uses it.`); return; }
    await call('DELETE', `/repos/${repo}/git/refs/tags/${encodeURIComponent(tag)}`).then(() => console.log(`Removed the tag ${tag}.`)).catch((e) => { if (e.status !== 404 && e.status !== 422) throw e; });
  }
}

async function publish(args) {
  const id = flag(args, '--release');
  if (!id) fail('Say the release: --release <number>');
  const notesFile = flag(args, '--notes-file');
  const change = { draft: false, ...(notesFile ? { body: readFileSync(notesFile, 'utf8') } : {}) };
  const release = await call('PATCH', `/repos/${repo}/releases/${id}`, { body: JSON.stringify(change), extra: { 'content-type': 'application/json' } });
  console.log(`Published ${release.tag_name}: ${release.html_url}`);
}

const [command, ...args] = process.argv.slice(2);
if (!token) fail('There is no GITHUB_TOKEN, so nothing can be put on a release.');
if (!/^[\w.-]+\/[\w.-]+$/.test(repo)) fail('GITHUB_REPOSITORY must look like owner/name.');
const commands = { create, upload, download, publish, discard };
if (!commands[command]) fail('Use one of: create, upload, download, publish, discard.');
await commands[command](args).catch((e) => fail(String(e.message || e)));
