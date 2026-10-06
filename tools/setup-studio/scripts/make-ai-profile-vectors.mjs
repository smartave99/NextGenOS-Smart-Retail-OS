// Makes apps/pos-ai-companion/tests/vectors/ai-profile.json: the cases both the AI assistant's own reader (apps/pos-ai-companion: Settings/ShopProfile.cs) and the Setup Studio
// (lib/aiprofile.mjs) must read the same way, and the files the Studio writes for a few customers.
// The inputs are written here by hand; the answers come from the Studio's twin of the reader, and the program's tests check that its own reading comes out identical
// (so what the Studio writes is never something the program drops, and the two cannot drift apart).
//   node tools/setup-studio/scripts/make-ai-profile-vectors.mjs
import { writeFileSync } from 'node:fs';
import { resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { readAiProfile, buildAiProfile } from '../lib/aiprofile.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const out = resolve(here, '..', '..', '..', 'apps', 'pos-ai-companion', 'tests', 'vectors', 'ai-profile.json');

const long = (n, c = 'x') => c.repeat(n);
const names = (n, prefix = 'Festival ') => Array.from({ length: n }, (_, i) => prefix + (i + 1));

/** What the program is told to read. "input" is a JSON value, "raw" is text. */
export const READ_CASES = [
  { name: 'a complete, good file', input: {
    schema: 1, country: { code: 'PH', name: 'the Philippines' }, shopKind: 'a small shop',
    images: { models: [{ title: 'Filipino model', looks: 'Filipino, in her late twenties' }, { title: 'Chinese-Filipino model', looks: 'Chinese-Filipino' }, { title: 'Visayan model', looks: 'Visayan, in his forties' }], festivals: ['Christmas', 'Sinulog', 'christmas'], localLanguage: { name: 'Filipino', tag: 'fil' } },
  } },
  { name: 'nothing at all', raw: '' },
  { name: 'only spaces', raw: '   ' },
  { name: 'not JSON', raw: '{ not json' },
  { name: 'a list is not a profile', raw: '[1,2,3]' },
  { name: 'a text is not a profile', raw: '"text"' },
  { name: 'null is not a profile', raw: 'null' },
  { name: 'an empty object has no schema', raw: '{}' },
  { name: 'a newer schema is refused', raw: '{"schema": 2}' },
  { name: 'schema as text is refused', raw: '{"schema": "1"}' },
  { name: 'schema with a fraction is refused', raw: '{"schema": 1.5}' },
  { name: 'only the schema is the neutral profile, and nothing is said', input: { schema: 1 } },
  { name: 'unknown parts are ignored without a word', input: { schema: 1, password: 'x', country: { code: 'PH', name: 'the Philippines', flag: 'x' }, other: [1], images: { sparkle: true } } },
  { name: 'words are trimmed', input: { schema: 1, country: { name: '  the Philippines  ' }, shopKind: '  a small restaurant ', images: { festivals: ['  Sinulog '], models: [{ title: '  Visayan model ', looks: ' in his forties ' }] } } },
  { name: 'markup, quotes and a backslash are never kept', input: { schema: 1, country: { name: '<script>alert(1)</script>' }, shopKind: 'a "quoted" shop', images: { models: [{ title: 'Back\\slash', looks: 'a > b' }], festivals: ['A', 'B"C', 'D', 'E<F', 'G'], localLanguage: { name: 'Hin<di>', tag: 'hi' } } } },
  { name: 'control characters are never kept', input: { schema: 1, country: { name: 'Bell\u0007land' }, shopKind: 'a\tshop', images: { models: [{ title: 'Ok model', looks: 'line one\nline two' }, { title: 'Del\u007fete', looks: 'next\u0085line' }], festivals: ['A', 'B\u0007', 'C'] } } },
  { name: 'a quote mark that is only an apostrophe, an ampersand and words in any script are kept', input: { schema: 1, country: { name: 'Türkiye' }, shopKind: 'a children\'s clothes shop', images: { festivals: ['Valentine\'s Day', 'Eid & Co', 'दीवाली', 'วันสงกรานต์', 'عيد'], models: [{ title: 'Thai model', looks: 'ไทย' }] } } },
  { name: 'the country and the kind of business: 60 letters are kept, 61 are not', input: { schema: 1, country: { name: long(60) }, shopKind: long(61) } },
  { name: 'a model\'s title: 40 letters are kept, 41 are not; its looks: 120 are kept, 121 are not', input: { schema: 1, images: { models: [{ title: long(40), looks: long(120) }, { title: long(41), looks: long(121) }] } } },
  { name: 'a festival: 40 letters are kept, 41 are not', input: { schema: 1, images: { festivals: [long(40), long(41), 'Ok'] } } },
  { name: 'the length counts UTF-16 units: twenty party poppers are 40, twenty-one are 42', input: { schema: 1, images: { festivals: ['\u{1F389}'.repeat(20), '\u{1F389}'.repeat(21), '\u{1F389}'] } } },
  { name: 'at most three model photos are read; one that is not an object is neutral', input: { schema: 1, images: { models: [{ title: 'One' }, 5, null, { title: 'Four' }, { title: 'Five' }] } } },
  { name: 'a model with only a title, or only a look', input: { schema: 1, images: { models: [{ title: 'Only title' }, { looks: 'only looks' }, {}] } } },
  { name: 'models, festivals and a language that are the wrong kind of thing are ignored without a word', input: { schema: 1, images: { models: 'many', festivals: 5, localLanguage: 'hi' } } },
  { name: 'images that is not an object is ignored', input: { schema: 1, images: [1, 2] } },
  { name: 'text that is the wrong kind of thing is ignored without a word', input: { schema: 1, country: { name: 5 }, shopKind: true, images: { festivals: [1, true, null, {}, []], models: [{ title: 7, looks: false }] } } },
  { name: 'blank text is nothing, without a word', input: { schema: 1, country: { name: '   ' }, shopKind: '', images: { festivals: ['  ', ''], models: [{ title: ' ', looks: ' ' }] } } },
  { name: 'festivals: a repeat in other letters is one, and a bad one is named', input: { schema: 1, images: { festivals: ['Diwali', 'DIWALI', 'diwali ', 'Holi', 'B\u0007d', 'Eid'] } } },
  { name: 'only capitals make a repeat: a sharp s and a dotless i are letters of their own', input: { schema: 1, images: { festivals: ['Straße', 'STRASSE', 'strasse', 'ı', 'I', 'i', 'ſ', 's', 'S', 'ǆ', 'Ǆ'] } } },
  { name: 'white space at the ends is trimmed as the program trims it: a next-line mark and a wide space go, a byte-order mark stays', input: { schema: 1, shopKind: '\u0085a shop\u3000', images: { festivals: ['\u00a0Eid\u0085', '\ufeffHoli', 'Holi'], models: [{ title: '\u0085\u0085', looks: '\u3000' }] } } },
  { name: 'at most 24 festivals; the rest are not used', input: { schema: 1, images: { festivals: names(30) } } },
  { name: 'a repeat does not take one of the 24 places', input: { schema: 1, images: { festivals: ['A', 'a', 'B', 'b', ...names(26)] } } },
  { name: 'a second language: its name and tag', input: { schema: 1, images: { localLanguage: { name: 'Hindi', tag: 'hi' } } } },
  { name: 'language tags: two or three small letters, then dashes and more', input: { schema: 1, images: { localLanguage: { name: 'Chinese', tag: 'zh-TW' } } } },
  { name: 'language tags: a region with a script', input: { schema: 1, images: { localLanguage: { name: 'Serbian', tag: 'sr-Latn-RS' } } } },
  { name: 'a language tag of 12 letters is kept', input: { schema: 1, images: { localLanguage: { name: 'Long', tag: 'fil-abcdefgh' } } } },
  { name: 'a language tag of 13 letters is not usable, so the language is left out', input: { schema: 1, images: { localLanguage: { name: 'Long', tag: 'fil-abcdefghi' } } } },
  { name: 'a language tag with capital letters first is not a tag', input: { schema: 1, images: { localLanguage: { name: 'Hindi', tag: 'Hi' } } } },
  { name: 'a language tag that is a whole word is not a tag', input: { schema: 1, images: { localLanguage: { name: 'Hindi', tag: 'hindi' } } } },
  { name: 'a language tag with an underscore is not a tag', input: { schema: 1, images: { localLanguage: { name: 'Hindi', tag: 'hi_IN' } } } },
  { name: 'a language with a name and no tag is left out, and said', input: { schema: 1, images: { localLanguage: { name: 'Hindi' } } } },
  { name: 'a language with a tag and no name is left out, and said', input: { schema: 1, images: { localLanguage: { tag: 'hi' } } } },
  { name: 'a language with neither is nothing, without a word', input: { schema: 1, images: { localLanguage: {} } } },
  { name: 'a language name of 40 letters is kept, of 41 is not', input: { schema: 1, images: { localLanguage: { name: long(41), tag: 'hi' } } } },
  { name: 'ready-made second-language lines are read for the poster kinds only, and only with a second language', input: { schema: 1, images: { localLanguage: { name: 'Hindi', tag: 'hi', lines: { clearance: 'भारी छूट', 'best-sellers': 'सबकी पसंद', diwali: 'x', 'new-arrivals': '<b>नया</b>', 'festival-offer': long(41) } } } } },
  { name: 'ready-made lines of all four kinds', input: { schema: 1, images: { localLanguage: { name: 'Filipino', tag: 'fil', lines: { clearance: 'Malaking bawas', 'new-arrivals': 'Bagong dating', 'best-sellers': 'Paborito ng lahat', 'festival-offer': 'Espesyal na presyo', extra: 'no' } } } } },
  { name: 'ready-made lines with no second language are not used', input: { schema: 1, images: { localLanguage: { lines: { clearance: 'भारी छूट' } } } } },
  { name: 'ready-made lines that are not an object are ignored', input: { schema: 1, images: { localLanguage: { name: 'Hindi', tag: 'hi', lines: ['x'] } } } },
];

/** What the Setup Studio writes, from a customer's details (only the parts the file is made from). */
export const BUILD_CASES = [
  { name: 'nothing typed: only what the country pack and the industry pack say', intake: { business: { country: 'PH', industry: 'retail' } } },
  { name: 'a country and a kind of business the packs do not know: the file says nothing', intake: { business: { country: 'ZZ', industry: 'spaceship' } } },
  { name: 'the country and the business named by hand', intake: { business: { country: 'PH', industry: 'retail' }, images: { countryName: 'the Philippines', shopKind: 'a small shop' } } },
  { name: 'another country and another trade', intake: { business: { country: 'JP', industry: 'restaurant' } } },
  { name: 'a lending library, in a country the pack names in full', intake: { business: { country: 'AE', industry: 'library' } } },
  { name: 'all three model photos', intake: { business: { country: 'PH', industry: 'retail' }, images: { models: [{ title: 'Filipino model', looks: 'Filipino, in her late twenties' }, { title: 'Chinese-Filipino model', looks: 'Chinese-Filipino' }, { title: 'Visayan model', looks: 'Visayan, in his forties' }] } } },
  { name: 'only the second photo is typed: the first and the third stay neutral', intake: { business: { country: 'PH', industry: 'retail' }, images: { models: [{ title: '', looks: '' }, { title: 'Visayan model', looks: '' }] } } },
  { name: 'a photo with only a look keeps its neutral title', intake: { business: { country: 'PH', industry: 'retail' }, images: { models: [{ title: '', looks: 'in her sixties' }] } } },
  { name: 'festivals: a repeat in other letters is one', intake: { business: { country: 'PH', industry: 'retail' }, images: { festivals: ['Christmas', 'Sinulog', 'christmas', 'Valentine\'s Day'] } } },
  { name: 'a second language with its name and tag', intake: { business: { country: 'PH', industry: 'retail' }, images: { localLanguage: { name: 'Filipino', tag: 'fil' } } } },
  { name: 'a second language with ready-made lines', intake: { business: { country: 'IN', industry: 'retail' }, images: { localLanguage: { name: 'Hindi', tag: 'hi', lines: { clearance: 'भारी छूट · सीमित स्टॉक', 'best-sellers': 'सबकी पसंद' } } } } },
  { name: 'a second language with only a name is left out of the file, and said', intake: { business: { country: 'PH', industry: 'retail' }, images: { localLanguage: { name: 'Filipino', tag: '' } } } },
  { name: 'ready-made lines without a second language are not written', intake: { business: { country: 'PH', industry: 'retail' }, images: { localLanguage: { name: '', tag: '', lines: { clearance: 'Malaking bawas' } } } } },
  { name: 'a customer with models, many festivals and a second language with lines', intake: {
    business: { country: 'IN', industry: 'retail' },
    images: { countryName: 'India', shopKind: 'a small shop', models: [{ title: 'Model A', looks: 'a first look' }, { title: 'Model B', looks: 'a second look, with a comma' }, { title: 'Model C', looks: 'a third look' }], festivals: names(15), localLanguage: { name: 'Hindi', tag: 'hi', lines: { clearance: 'भारी छूट · सीमित स्टॉक', 'new-arrivals': 'नया माल आ गया है', 'best-sellers': 'सबकी पसंद', 'festival-offer': 'त्योहार पर खास दाम' } } },
  } },
  { name: 'the most festivals the program uses', intake: { business: { country: 'PH', industry: 'retail' }, images: { festivals: names(24) } } },
];

export function build() {
  return {
    description: 'Shared by the AI assistant (apps/pos-ai-companion: Settings/ShopProfile.cs) and the Setup Studio (tools/setup-studio/lib/aiprofile.mjs): how profile/ai.json is read, and what the Studio writes. '
      + '"read": "input" (a JSON value) or "raw" (text) is the file; "value" is what the program ends up with (models as it names them, "Model 1" when a photo has no title) and "problems" are the things it leaves out, in order, in its own words. '
      + '"build": "intake" is the part of a customer\'s details the file is made from, "file" is what the Studio writes, "problems" are things the Studio could not write, and "read" is what the program ends up with when it reads that file (with no problem). '
      + 'Made by tools/setup-studio/scripts/make-ai-profile-vectors.mjs.',
    read: READ_CASES.map((c) => {
      const r = readAiProfile('raw' in c ? c.raw : JSON.stringify(c.input));
      return { name: c.name, ...('raw' in c ? { raw: c.raw } : { input: c.input }), expect: { value: r.value, problems: r.problems } };
    }),
    build: BUILD_CASES.map((c) => {
      const b = buildAiProfile(c.intake);
      return { name: c.name, intake: c.intake, expect: { file: b.file, problems: b.problems, read: readAiProfile(b.text).value } };
    }),
  };
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  // Letters nobody can see (control and white-space marks) are written as \uXXXX, so the file can be read by eye and edited safely.
  const text = JSON.stringify(build(), null, 2).replace(/[\u0080-\u009f\u00a0\u2028\u2029\u3000\ufeff]/g, (c) => '\\u' + c.charCodeAt(0).toString(16).padStart(4, '0'));
  writeFileSync(out, text + '\n');
  console.log('Wrote ' + out);
}
