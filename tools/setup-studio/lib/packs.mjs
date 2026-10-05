// The country packs and industry packs the Hub is built from, read from files (country-packs/packs, industry-packs/packs). The Studio only reads them: it never
// changes a pack. Where the packs are: the repository this Studio sits in, or the folder named in SETUP_STUDIO_PACKS (the Studio's own copy in a delivered bundle).
import { readFileSync, readdirSync, existsSync } from 'node:fs';
import { join, resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

export const repoRoot = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..', '..');

export function packsRoot() {
  const chosen = process.env.SETUP_STUDIO_PACKS;
  if (chosen && existsSync(join(chosen, 'country-packs', 'packs'))) return resolve(chosen);
  const bundled = resolve(dirname(fileURLToPath(import.meta.url)), '..', 'packs');
  if (existsSync(join(bundled, 'country-packs', 'packs'))) return bundled;
  return repoRoot;
}

const cache = new Map();
function readAll(kind) {
  const root = packsRoot();
  const key = kind + '@' + root;
  if (cache.has(key)) return cache.get(key);
  const dir = join(root, kind === 'country' ? 'country-packs' : 'industry-packs', 'packs');
  const packs = new Map();
  if (existsSync(dir)) {
    for (const f of readdirSync(dir)) {
      if (!f.endsWith('.json')) continue;
      try {
        const p = JSON.parse(readFileSync(join(dir, f), 'utf8'));
        const id = kind === 'country' ? p.country : p.id;
        if (typeof id === 'string') packs.set(id, p);
      } catch { /* a pack that cannot be read is simply not offered */ }
    }
  }
  cache.set(key, packs);
  return packs;
}

export const countryPack = (code) => readAll('country').get(code) ?? null;
export const industryPack = (id) => readAll('industry').get(id) ?? null;

/** The countries to choose from, in name order, with what a form needs about each. */
export function countries() {
  return [...readAll('country').values()].map((p) => ({
    code: p.country, name: p.name, currency: p.currency?.code, symbol: p.currency?.symbol, phoneCode: p.phoneCode, timezone: p.timezone, language: p.locale,
    taxName: p.tax?.name, pricesIncludeTax: !!p.tax?.pricesIncludeTaxDefault,
    taxIdLabel: p.tax?.businessId?.label ?? null,
    regionLabel: p.tax?.regions?.label ?? null, regions: (p.tax?.regions?.list ?? []).map((r) => ({ code: r.code, name: r.name })),
    reviewed: !!p.review,
  })).sort((a, b) => a.name.localeCompare(b.name, 'en'));
}

/** The kinds of business to choose from, in the order the Hub shows them (the catch-all last). */
export function industries() {
  return [...readAll('industry').values()].map((p) => ({
    id: p.id, name: p.name, summary: p.summary, icon: p.icon, vocabulary: p.vocabulary, features: p.features,
    itemKinds: (p.itemKinds ?? []).map((k) => ({ id: k.id, label: k.label })), partyKinds: (p.partyKinds ?? []).map((k) => ({ id: k.id, label: k.label })),
    paymentMethods: p.defaults?.paymentMethods ?? [], aiContext: p.aiContext ?? '', coverage: p.coverage ?? { works: [], notYet: [] },
  })).sort((a, b) => (a.id === 'generic') - (b.id === 'generic') || a.name.localeCompare(b.name, 'en'));
}
