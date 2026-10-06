#!/usr/bin/env node
// Industry packs: validate | list | sync | check
import { readFileSync, writeFileSync, readdirSync, existsSync, mkdirSync } from 'node:fs';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { validateIndustry } from './validate.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const packsDir = join(here, '..', 'packs');
const generated = join(here, '..', '..', 'apps', 'storefront-web-mobile', 'src', 'lib', 'industry', 'generated');
const load = () => Object.fromEntries(readdirSync(packsDir).filter((f) => f.endsWith('.json')).sort().map((f) => [f.replace('.json', ''), JSON.parse(readFileSync(join(packsDir, f), 'utf8'))]));
const packs = load();

/** What a web page needs of each kind of business: its words and the parts it uses. */
const liteText = () => JSON.stringify(Object.fromEntries(Object.entries(packs).map(([id, p]) => [id, { name: p.name, summary: p.summary, vocabulary: p.vocabulary, features: p.features, aiContext: p.aiContext }]))) + '\n';

function validateAll() {
  let bad = 0;
  for (const [id, p] of Object.entries(packs)) {
    const problems = validateIndustry(p, `${id}.json`);
    if (problems.length) { bad++; console.log(`${id}: ${problems.length} problem(s)`); problems.forEach((x) => console.log(`   - ${x}`)); }
  }
  return bad;
}

const command = process.argv[2];
if (command === 'validate') {
  const bad = validateAll();
  console.log(bad ? `\n${bad} pack(s) have problems.` : `All ${Object.keys(packs).length} industry packs are sound.`);
  process.exit(bad ? 1 : 0);
} else if (command === 'list') {
  for (const [id, p] of Object.entries(packs)) console.log(`${id.padEnd(14)} ${p.name.padEnd(46)} ${Object.entries(p.features).filter(([, v]) => v === true).map(([k]) => k).join(', ')}`);
} else if (command === 'sync') {
  mkdirSync(generated, { recursive: true });
  writeFileSync(join(generated, 'industries.json'), liteText());
  console.log(`Copied the vocabulary of ${Object.keys(packs).length} industries to ${generated}`);
} else if (command === 'check') {
  const problems = [];
  if (validateAll()) problems.push('some industry packs have problems (run validate)');
  const file = join(generated, 'industries.json');
  if (!existsSync(file) || readFileSync(file, 'utf8') !== liteText()) problems.push('the storefront copy of the industries is out of date (run sync)');
  if (problems.length) { console.log(problems.join('\n')); process.exit(1); }
  console.log(`Industry packs are consistent: ${Object.keys(packs).length} packs, copy current.`);
} else {
  console.log('Commands: validate | list | sync | check');
  process.exit(command ? 1 : 0);
}
