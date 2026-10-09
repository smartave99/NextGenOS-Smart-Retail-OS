// What changed between two proposals, in plain words (for the screen where a person decides whether to keep an AI tool's version).
const PLAIN = {
  'business.name': 'Business name', 'business.country': 'Country', 'business.region': 'Region', 'business.industry': 'Kind of business',
  'settings.pricesIncludeTax': 'Prices include tax', 'settings.taxRegistered': 'Registered for tax', 'settings.roundTotal': 'Round the total', 'settings.allowNegativeStock': 'Allow selling below zero stock',
  'settings.receiptFooter': 'Words at the bottom of a bill', 'settings.paymentMethods': 'Ways of paying', notes: 'Notes',
};
const THEME_WORDS = { look: 'Look of the program', mode: 'Light or dark', surface: 'Background tint', shape: 'Corner shape', density: 'Button size', font: 'Letters', fontScale: 'Letter size', nav: 'Menu position', navLabels: 'Menu words', cart: 'Basket position', depth: 'Shadows' };

function flatten(value, prefix = '', out = {}) {
  if (value === null || typeof value !== 'object' || Array.isArray(value)) { out[prefix] = value; return out; }
  for (const [k, v] of Object.entries(value)) {
    if (k === 'items' || k === 'people') out[`${prefix}${prefix ? '.' : ''}${k}`] = v;
    else flatten(v, `${prefix}${prefix ? '.' : ''}${k}`, out);
  }
  return out;
}
const show = (v) => (v === undefined ? 'nothing' : Array.isArray(v) ? (v.length && typeof v[0] === 'object' ? `${v.length} listed` : v.join(', ')) : typeof v === 'boolean' ? (v ? 'yes' : 'no') : String(v));

/** Lists what is different: [{ part, what, from, to }]. `part` is setup, look or brand. */
export function diffProposals(a, b) {
  const out = [];
  const compare = (part, left, right, nameOf) => {
    const x = flatten(left ?? {}), y = flatten(right ?? {});
    for (const key of [...new Set([...Object.keys(x), ...Object.keys(y)])]) {
      if (JSON.stringify(x[key]) === JSON.stringify(y[key])) continue;
      out.push({ part, key, what: nameOf(key), from: show(x[key]), to: show(y[key]) });
    }
  };
  compare('setup', a.setup, b.setup, (k) => PLAIN[k] ?? (k.startsWith('vocabulary.') ? `The word for "${k.slice(11)}"` : k.startsWith('features.') ? `Part "${k.slice(9)}" switched on` : k === 'starter.items' ? 'First items' : k === 'starter.people' ? 'First people' : k));
  compare('look', a.theme, b.theme, (k) => THEME_WORDS[k] ?? k);
  compare('brand', a.brand, b.brand, (k) => k);
  return out;
}
