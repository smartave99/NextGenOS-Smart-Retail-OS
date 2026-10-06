#!/usr/bin/env node
/**
 * Finds what is still fixed in program code that a customer could want different (CLAUDE.md, section 8): a market (India, Hindi, rupees, GST, Indian festivals),
 * a company's own name, a built-in picture. Each such spot is counted per file. The count may only go down: a change that adds a fixed spot, or puts one in a new file, fails.
 *
 *   node scripts/white-label-audit.mjs            check against docs/white-label-baseline.json (what the gate runs)
 *   node scripts/white-label-audit.mjs --report   the table by program and kind, nothing checked
 *   node scripts/white-label-audit.mjs --update   write a lower baseline (refuses to write a higher one)
 *
 * A spot that is only data (a country pack, an industry pack, a brand kit), a test, a document or a built file is not counted. A passing check does NOT mean nothing is
 * fixed: it means nothing new is. The remaining list is in docs/WHITE-LABEL-AUDIT.md.
 */
import { spawnSync } from 'node:child_process';
import { readFileSync, writeFileSync, existsSync, statSync } from 'node:fs';
import { resolve, dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const BASELINE = join(root, 'docs', 'white-label-baseline.json');

export const KINDS = [
  { id: 'market-india', label: 'India as the assumed place', re: /\bin India\b|\bIndian\b|\bIndia\b/g },
  { id: 'language-hindi', label: 'Hindi / Devanagari written into code', re: /Hindi|Devanagari|[ऀ-ॿ]/g },
  { id: 'festival', label: 'A festival or season written into code', re: /\b(Diwali|Rakhi|Navratri|Dussehra|Ganesh|Pongal|Onam)\b/g },
  { id: 'currency-inr', label: 'Rupee written into code', re: /₹|\bINR\b/g },
  { id: 'tax-gst', label: 'Indian tax words written into code', re: /\b(GSTIN?|CGST|SGST|IGST|HSN)\b/g },
  { id: 'company-name', label: 'A customer or company name written into code', re: new RegExp('Smart ?' + 'Avenue ?99|Smart' + 'Avenue99|Smart ?' + 'Avenue', 'gi') },   // (written in pieces so this file does not carry the name itself)
  { id: 'country-default', label: 'A default country written into code', re: /\bcountry\s*=\s*"IN"|Country\s*=\s*"IN"|\|\|\s*['"]IN['"]|\?\?\s*['"]IN['"]/g },
  { id: 'built-in-picture', label: 'A picture built into a program', re: /<(EmbeddedResource|Content|Resource|None|AndroidResource)\s[^>]*Include="[^"]+\.(png|jpe?g|svg|ico|gif|webp)"/gi },
];

const CODE = /\.(cs|vb|razor|cshtml|xaml|resx|vbproj|csproj|ts|tsx|js|mjs|html|css)$/i;
const SKIP = /(^|\/)(node_modules|bin|obj|\.next|dist|out|generated|vendor|Documentation|docs|tests?|Tests?|e2e|__tests__|country-packs|industry-packs|brand-kits|brand-exports|licenses|licensing|tools|scripts|\.github)(\/|$)|\.(test|spec|min)\.|\.Designer\.(vb|cs)$|\.g\.cs$|package-lock/;

function files() {
  const r = spawnSync('git', ['ls-files', '-co', '--exclude-standard', '-z'], { cwd: root, encoding: 'utf8', maxBuffer: 256 * 1024 * 1024 });
  return r.stdout.split('\0').filter((f) => f && f.startsWith('apps/') && CODE.test(f) && !SKIP.test(f) && existsSync(join(root, f)) && statSync(join(root, f)).size < 3_000_000);
}

/** What counts is what the program does, not what a comment says: comment lines are left out, and so is a line that says why it is fine (white-label-ok: the reason). */
function stripNotes(text, file) {
  const project = /\.(vbproj|csproj|resx)$/i.test(file);
  const vb = /\.vb$/i.test(file);
  return text.split('\n').filter((line) => {
    const t = line.trim();
    if (/white-label-ok/.test(line)) return false;
    if (project) return true;
    if (vb) return !t.startsWith("'");
    return !(t.startsWith('//') || t.startsWith('*') || t.startsWith('/*') || t.startsWith('<!--') || t.startsWith('@*'));
  }).join('\n');
}

export function scan() {
  const found = {};
  for (const f of files()) {
    let text;
    try { text = readFileSync(join(root, f), 'utf8'); } catch { continue; }
    const code = stripNotes(text, f);
    for (const k of KINDS) {
      const n = (code.match(k.re) || []).length;
      if (n > 0) (found[k.id] ??= {})[f] = n;
    }
  }
  return found;
}

const appOf = (f) => f.split('/')[1];
const total = (m) => Object.values(m ?? {}).reduce((a, b) => a + b, 0);

export function compare(found, baseline) {
  const worse = [];
  for (const [kind, byFile] of Object.entries(found)) for (const [f, n] of Object.entries(byFile)) {
    const was = baseline?.[kind]?.[f] ?? 0;
    if (n > was) worse.push(`${f}: ${kind} ${was} -> ${n}${was === 0 ? ' (new)' : ''}`);
  }
  return worse;
}

function report(found) {
  const apps = [...new Set(Object.values(found).flatMap((m) => Object.keys(m).map(appOf)))].sort();
  const rows = [['kind', ...apps, 'total']];
  for (const k of KINDS) {
    const m = found[k.id] ?? {};
    rows.push([k.id, ...apps.map((a) => String(Object.entries(m).filter(([f]) => appOf(f) === a).reduce((s, [, n]) => s + n, 0) || '')), String(total(m))]);
  }
  const width = rows[0].map((_, i) => Math.max(...rows.map((r) => r[i].length)));
  return rows.map((r) => r.map((c, i) => (i === 0 ? c.padEnd(width[i]) : c.padStart(width[i]))).join('  ')).join('\n');
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const args = process.argv.slice(2);
  const found = scan();
  const grand = Object.values(found).reduce((s, m) => s + total(m), 0);
  if (args.includes('--report')) { console.log(report(found)); console.log(`\n${grand} fixed spot(s) in program code.`); process.exit(0); }
  const baseline = existsSync(BASELINE) ? JSON.parse(readFileSync(BASELINE, 'utf8')).kinds : null;
  if (args.includes('--update')) {
    const worse = baseline ? compare(found, baseline) : [];
    if (worse.length) { console.error('Refusing to write a higher baseline:\n  ' + worse.join('\n  ')); process.exit(1); }
    writeFileSync(BASELINE, JSON.stringify({ note: 'What is still fixed in program code (CLAUDE.md section 8). Only ever lowered: node scripts/white-label-audit.mjs --update', kinds: found }, null, 1) + '\n');
    console.log(`Baseline written: ${grand} fixed spot(s).`);
    process.exit(0);
  }
  if (!baseline) { console.error('There is no docs/white-label-baseline.json yet: run with --update once.'); process.exit(2); }
  const worse = compare(found, baseline);
  const was = Object.values(baseline).reduce((s, m) => s + total(m), 0);
  if (worse.length) { console.log(`FAIL  ${worse.length} place(s) got more fixed spots than the baseline allows:\n  ${worse.slice(0, 40).join('\n  ')}`); process.exit(1); }
  console.log(`PASS  nothing new is fixed in program code (${grand} spot(s) remain, baseline ${was}; they are listed in docs/WHITE-LABEL-AUDIT.md)${grand < was ? `. Fewer than the baseline: run --update to lock the improvement in.` : ''}`);
}
