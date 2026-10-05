// Makes apps/business-hub/tests/vectors/setup-profile.json: the cases both the Business Hub (SetupProfile.cs) and the Setup Studio (lib/rules.mjs) must read the same way.
// The inputs are written here by hand; the answers are what the Studio's rules say, and the Hub's tests check that its own reading comes out identical.
//   node tools/setup-studio/scripts/make-setup-vectors.mjs
import { writeFileSync } from 'node:fs';
import { resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { parseSetup } from '../lib/rules.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const out = resolve(here, '..', '..', '..', 'apps', 'business-hub', 'tests', 'vectors', 'setup-profile.json');

const long = (n, c = 'x') => c.repeat(n);
const items = (n) => Array.from({ length: n }, (_, i) => ({ name: `Item ${i}`, price: '1' }));
export const CASES = [
  { name: 'a complete, good file', input: {
    schema: 1, business: { name: 'Luzon Fresh Mart', country: 'ph', industry: 'Retail', region: '' },
    settings: { pricesIncludeTax: true, taxRegistered: true, roundTotal: false, allowNegativeStock: false, receiptFooter: 'Salamat po!', paymentMethods: ['Cash', 'gcash', 'card', 'cash'] },
    vocabulary: { customer: ['Suki', 'Sukis'] }, features: { tables: false, weighedItems: true },
    starter: { items: [{ name: 'Rice 5 kg', price: '285.00', kind: 'stock', unit: 'bag', category: 'Grocery', barcode: '4800000000011' }, { name: 'Gift wrapping', price: 20, kind: 'service', taxClass: 'zero' }], people: [{ kind: 'supplier', name: 'Manila Wholesale', phone: '+63 2 5555 0100', email: 'orders@example.com' }] },
    notes: 'Opens at 8.',
  } },
  { name: 'nothing at all', raw: '' },
  { name: 'only spaces', raw: '   ' },
  { name: 'not JSON', raw: '{ not json' },
  { name: 'a list is not a profile', raw: '[1,2,3]' },
  { name: 'a text is not a profile', raw: '"text"' },
  { name: 'an empty object has no schema', raw: '{}' },
  { name: 'a newer schema is refused', raw: '{"schema": 2}' },
  { name: 'schema as text is refused', raw: '{"schema": "1"}' },
  { name: 'schema with a fraction is refused', raw: '{"schema": 1.5}' },
  { name: 'unknown parts are named and ignored', input: { schema: 1, password: 'x', business: { name: 'A' }, licence: 'NGOS' } },
  { name: 'a file nested far too deep is refused', raw: '{"a":'.repeat(200) + '1' + '}'.repeat(200) },
  { name: 'only the schema', input: { schema: 1 } },
  { name: 'a wrong country, industry and region are left to choose', input: { schema: 1, business: { name: 'Test', country: 'ZZ', industry: 'spaceship', region: 'nope' } } },
  { name: 'a region of the country is kept, one that is not is named', input: { schema: 1, business: { country: 'IN', region: '27' } } },
  { name: 'a region with no country is named', input: { schema: 1, business: { region: '27' } } },
  { name: 'names are cleaned: control characters out, long text cut', input: { schema: 1, business: { name: '  A\u0007B\u0000C  ' }, settings: { receiptFooter: long(300) }, notes: long(5000) } },
  { name: 'a name of only spaces is not a name', input: { schema: 1, business: { name: '   ' } } },
  { name: 'ways of paying: odd ones are named, the rest kept, at most 12', input: { schema: 1, settings: { paymentMethods: ['cash', '<script>', 5, '', 'a'.repeat(21), 'Mobile wallet', 'bank-transfer', 'm1', 'm2', 'm3', 'm4', 'm5', 'm6', 'm7', 'm8', 'm9', 'm10'] } } },
  { name: 'settings of the wrong kind are ignored without a word', input: { schema: 1, settings: { pricesIncludeTax: 'yes', roundTotal: 1, taxRegistered: null, allowNegativeStock: false } } },
  { name: 'words: a pair is needed and only the business\'s own words count', input: { schema: 1, vocabulary: { customer: ['Guest'], item: ['Dish', 'Dishes'], nonsense: ['a', 'b'], sale: ['', 'x'], staff: [1, 2], supplier: 'Vendor', invoice: ['A'.repeat(31), 'Bills'] } } },
  { name: 'words are checked against the kind of business chosen', input: { schema: 1, business: { industry: 'library' }, vocabulary: { customer: ['Reader', 'Readers'], stock: ['Copy', 'Copies'] } } },
  { name: 'parts that can be switched on and off', input: { schema: 1, features: { tables: true, kitchen: 'yes', launchRockets: true, credit: false } } },
  { name: 'starter items: a name and a price are needed', input: { schema: 1, starter: { items: [{ name: 'No price' }, { name: 'Negative', price: '-5' }, { name: 'Text price', price: 'ten' }, { price: '5' }, 7, { name: 'Fine', price: '10.5' }, { name: 'Number', price: 12 }, { name: 'Four places', price: '1.2345' }, { name: 'Five places', price: '1.23456' }, { name: 'Huge', price: '1234567890123' }] } } },
  { name: 'starter items: the kind falls back to one the business uses', input: { schema: 1, business: { industry: 'library' }, starter: { items: [{ name: 'Moby Dick', price: '0', kind: 'gadget' }, { name: 'Dune', price: '0' }, { name: 'Odd', price: '0', kind: '' }] } } },
  { name: 'starter items: extra fields are cleaned and cut', input: { schema: 1, starter: { items: [{ name: ' Rice ', price: ' 5 ', barcode: long(60, '1'), unit: long(20), category: long(60), taxClass: long(30) }] } } },
  { name: 'starter people: a kind the business uses and a name are needed', input: { schema: 1, starter: { people: [{ name: 'Ana' }, { kind: 'supplier', name: 'Metro Foods', phone: long(40, '1'), email: 'a@b.co' }, { kind: 'alien', name: 'Zed' }, { kind: 'customer' }, 'text'] } } },
  { name: 'at most 2000 starter items', input: { schema: 1, starter: { items: items(2050) } } },
  { name: 'a starter that is not a list is ignored', input: { schema: 1, starter: { items: 'many', people: { a: 1 } } } },
  { name: 'a business that is not an object is ignored', input: { schema: 1, business: 'Luzon', settings: [1], vocabulary: 3, features: null, starter: 'none', notes: 5 } },
];

export function build() {
  return {
    description: 'Shared by the Business Hub (apps/business-hub: SetupProfile.cs) and the Setup Studio (tools/setup-studio/lib/rules.mjs): how a setup profile is read. "input" (a JSON value) or "raw" (text) is what is read; "value" is the profile in its one plain form (null when the file is not a profile) and "problems" are the things named in plain words, in order. Made by tools/setup-studio/scripts/make-setup-vectors.mjs.',
    cases: CASES.map((c) => {
      const r = parseSetup('raw' in c ? c.raw : JSON.stringify(c.input));
      return { name: c.name, ...('raw' in c ? { raw: c.raw } : { input: c.input }), expect: { value: r.value, problems: r.problems } };
    }),
  };
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  writeFileSync(out, JSON.stringify(build(), null, 2) + '\n');
  console.log('Wrote ' + out);
}
