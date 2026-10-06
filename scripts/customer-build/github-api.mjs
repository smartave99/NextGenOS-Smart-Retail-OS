// A small client for GitHub's web interface, used only to reach the RESULTS REPOSITORY of customer builds (docs/CUSTOMER-BUILDS.md).
// It is modelled on scripts/release-assets.mjs and keeps its habits: a passing problem at GitHub is tried again, a file with the same name on a release is replaced,
// and a draft release is found by its tag (GitHub's own "release by tag" call does not return drafts).
//
// What it adds: the token is never put in a message, and it is only ever sent to GitHub's own address (and to the upload address that GitHub names in its answer,
// only when that is GitHub's too). The token is the one that can read and write the contents of the results repository and nothing else.

import { createHash } from 'node:crypto';

/** A problem a person can put right: the message is plain words. */
export class ResultsError extends Error {}

const sleep = (ms) => new Promise((r) => setTimeout(r, ms));

/** The release a customer build lives on: customer-<id>-<number>. */
export const releaseTag = (customer, build) => `customer-${customer}-${build}`;

/**
 * { token, repo ("owner/name"), apiUrl } in, a client out. Every method throws a ResultsError whose message holds no token.
 * `retryDelayMs` is only for the tests (the real wait grows 1, 4, 9 seconds).
 */
export function createClient({ token, repo, apiUrl = 'https://api.github.com', retryDelayMs = 1000 }) {
  if (!token) throw new ResultsError('There is no RESULTS_TOKEN, so nothing can be read from or put in the results place. The owner puts it in the repository secrets of the programs repository (docs/CUSTOMER-BUILDS.md).');
  if (!/^[\w.-]+\/[\w.-]+$/.test(repo || '')) throw new ResultsError('The results place must be written like owner/name.');
  const api = apiUrl.replace(/\/$/, '');
  const apiOrigin = new URL(api).origin;

  /** The text with every trace of the token taken out (a message must never hold it, even when GitHub repeats something back). */
  const scrub = (text) => String(text ?? '').split(token).join('***').replace(/\b(?:ghp|gho|ghu|ghs|ghr)_[A-Za-z0-9]{20,}/g, '***').replace(/github_pat_[A-Za-z0-9_]{20,}/g, '***');

  const trusted = (url) => {
    const origin = new URL(url).origin;
    return origin === apiOrigin || new URL(url).hostname === 'uploads.github.com';
  };
  const headers = (extra = {}) => ({ authorization: `Bearer ${token}`, accept: 'application/vnd.github+json', 'x-github-api-version': '2022-11-28', 'user-agent': 'nextgenos-customer-build', ...extra });

  /** One request, tried again (up to 4 times) when the network or GitHub has a passing problem. */
  async function call(method, url, { body, extra, raw } = {}) {
    const full = url.startsWith('http') ? url : `${api}${url}`;
    if (!trusted(full)) throw new ResultsError('The address GitHub gave for a file is not GitHub\'s own, so the token was not sent there.');
    let last;
    for (let attempt = 1; attempt <= 4; attempt += 1) {
      try {
        const res = await fetch(full, { method, headers: headers(extra), body });
        if (res.status >= 500 || res.status === 429) { last = new ResultsError(`GitHub answered ${res.status}`); await sleep(retryDelayMs * attempt * attempt); continue; }
        if (!res.ok) {
          const text = await res.text().catch(() => '');
          throw Object.assign(new ResultsError(scrub(`GitHub answered ${res.status} for ${method} ${url.replace(/\?.*/, '')}: ${text.slice(0, 300)}`)), { status: res.status });
        }
        return raw ? res : res.status === 204 ? null : await res.json();
      } catch (e) {
        if (e.status) throw e;
        last = new ResultsError(scrub(e.message || e));
        await sleep(retryDelayMs * attempt * attempt);
      }
    }
    throw last;
  }

  async function listAll(path, { stopWhen = null, maxPages = 20 } = {}) {
    const all = [];
    for (let page = 1; page <= maxPages; page += 1) {
      const items = await call('GET', `${path}${path.includes('?') ? '&' : '?'}per_page=100&page=${page}`);
      all.push(...items);
      if (items.length < 100 || (stopWhen && items.some(stopWhen))) break;
    }
    return all;
  }

  return {
    repo,
    scrub,
    call,
    /** The release with this tag, a draft too. null when there is none. */
    async findRelease(tag) {
      const found = (await listAll(`/repos/${repo}/releases`, { stopWhen: (r) => r.tag_name === tag })).find((r) => r.tag_name === tag);
      return found ?? null;
    },
    async listAssets(releaseId) {
      return listAll(`/repos/${repo}/releases/${releaseId}/assets`);
    },
    /** Puts a file on the release; a file with the same name is replaced. */
    async uploadAsset(release, name, bytes) {
      const base = release.upload_url.replace(/\{.*$/, '');
      for (const old of (await this.listAssets(release.id)).filter((a) => a.name === name)) await call('DELETE', `/repos/${repo}/releases/assets/${old.id}`);
      return call('POST', `${base}?name=${encodeURIComponent(name)}`, { body: bytes, extra: { 'content-type': 'application/octet-stream', 'content-length': String(bytes.length) } });
    },
    async downloadAsset(asset) {
      const res = await call('GET', `/repos/${repo}/releases/assets/${asset.id}`, { extra: { accept: 'application/octet-stream' }, raw: true });
      return Buffer.from(await res.arrayBuffer());
    },
    async deleteAsset(asset) {
      await call('DELETE', `/repos/${repo}/releases/assets/${asset.id}`);
    },
    /** The draft becomes a published release (this is what tells the Setup Studio the build is finished). */
    async publish(releaseId, notes) {
      return call('PATCH', `/repos/${repo}/releases/${releaseId}`, { body: JSON.stringify({ draft: false, ...(notes ? { body: notes } : {}) }), extra: { 'content-type': 'application/json' } });
    },
  };
}

export const sha256 = (bytes) => createHash('sha256').update(bytes).digest('hex');
