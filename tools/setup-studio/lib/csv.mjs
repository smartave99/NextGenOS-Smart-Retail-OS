// Reads the lists staff already have (items, people) from a spreadsheet saved as CSV, in any of the usual layouts, and says in plain words what could not be used.
import { parseSetup, MAX_STARTER } from './rules.mjs';

/** Splits CSV text into rows (quotes, doubled quotes, new lines inside quotes, a leading byte-order mark; the separator is found by itself). */
export function parseCsv(input, { maxRows = MAX_STARTER + 1 } = {}) {
  const text = String(input ?? '').replace(/^﻿/, '');
  const first = text.split(/\r?\n/, 1)[0] ?? '';
  const delimiter = [',', ';', '\t'].map((d) => [d, first.split(d).length]).sort((a, b) => b[1] - a[1])[0][0];
  const rows = [];
  let row = [], cell = '', quoted = false;
  for (let i = 0; i < text.length; i += 1) {
    const c = text[i];
    if (quoted) {
      if (c === '"') { if (text[i + 1] === '"') { cell += '"'; i += 1; } else quoted = false; } else cell += c;
    } else if (c === '"' && cell === '') quoted = true;
    else if (c === delimiter) { row.push(cell); cell = ''; }
    else if (c === '\n' || c === '\r') {
      if (c === '\r' && text[i + 1] === '\n') i += 1;
      row.push(cell); cell = '';
      if (row.some((x) => x.trim() !== '')) rows.push(row);
      row = [];
      if (rows.length > maxRows) break;
    } else cell += c;
  }
  if (cell !== '' || row.length) { row.push(cell); if (row.some((x) => x.trim() !== '')) rows.push(row); }
  return { rows, delimiter };
}

const norm = (h) => String(h ?? '').toLowerCase().replace(/[^a-z0-9]+/g, ' ').trim();
const SYNONYMS = {
  items: {
    name: ['name', 'item', 'item name', 'product', 'product name', 'title', 'description', 'article'],
    price: ['price', 'rate', 'mrp', 'selling price', 'sale price', 'unit price', 'sp', 'amount'],
    barcode: ['barcode', 'bar code', 'ean', 'upc', 'sku', 'code', 'item code', 'product code'],
    unit: ['unit', 'uom', 'unit of measure'],
    category: ['category', 'group', 'department', 'type of item', 'class'],
    kind: ['kind', 'type'],
    taxClass: ['tax', 'tax class', 'taxclass', 'vat', 'gst', 'tax rate class'],
  },
  people: {
    name: ['name', 'full name', 'customer', 'supplier', 'party', 'contact', 'company'],
    kind: ['kind', 'type', 'role', 'party type'],
    phone: ['phone', 'mobile', 'telephone', 'tel', 'contact number', 'phone number'],
    email: ['email', 'e mail', 'mail', 'email address'],
  },
};

/** "Rs. 1,234.50", "1.234,50", "12,5" all become "1234.50", "1234.50", "12.5". Returns null when it is not a price. */
export function cleanPrice(value) {
  let t = String(value ?? '').trim().replace(/[^\d.,]/g, '');
  if (!t || !/\d/.test(t)) return null;
  const lastDot = t.lastIndexOf('.'), lastComma = t.lastIndexOf(',');
  if (lastDot >= 0 && lastComma >= 0) { const dec = Math.max(lastDot, lastComma); t = t.slice(0, dec).replace(/[.,]/g, '') + '.' + t.slice(dec + 1); }
  else if (lastComma >= 0) t = /,\d{1,2}$/.test(t) && t.indexOf(',') === lastComma ? t.replace(',', '.') : t.replace(/,/g, '');
  else if ((t.match(/\./g) || []).length > 1) t = t.replace(/\./g, '');
  return /^\d{1,12}(\.\d{1,4})?$/.test(t) ? t : null;
}

function mapHeader(header, kind) {
  const map = {};
  header.forEach((h, i) => { for (const [field, names] of Object.entries(SYNONYMS[kind])) if (map[field] === undefined && names.includes(norm(h))) map[field] = i; });
  return map;
}

/**
 * Reads a list of items or people. Returns { rows, problems, count, columns }: rows are ready for the setup file, problems name each line that was left out (with its line number,
 * at most 15 named), and columns say which column was used for what so a person can see the file was understood.
 */
export function importList(kind, csvText, { industry = 'retail' } = {}) {
  const { rows } = parseCsv(csvText);
  const problems = [];
  if (rows.length < 2) return { rows: [], problems: ['The file needs a first line with the column names (like Name, Price) and then one line for each ' + (kind === 'items' ? 'item' : 'person') + '.'], count: 0, columns: {} };
  const header = rows[0];
  const map = mapHeader(header, kind);
  if (map.name === undefined) return { rows: [], problems: ['I could not find a column called Name (or Item, Product, Title). Add one to the first line and try again.'], count: 0, columns: {} };
  if (kind === 'items' && map.price === undefined) return { rows: [], problems: ['I could not find a column called Price (or Rate, MRP). Add one to the first line and try again.'], count: 0, columns: {} };
  const columns = Object.fromEntries(Object.entries(map).map(([f, i]) => [f, String(header[i]).trim()]));
  const out = [];
  const say = (n, m) => { if (problems.length < 15) problems.push(`Line ${n}: ${m}`); else if (problems.length === 15) problems.push('… and more lines were left out.'); };
  const pack = parseSetup({ schema: 1, business: { industry }, starter: { items: [], people: [] } });
  void pack;
  rows.slice(1).forEach((r, i) => {
    const n = i + 2;
    const cellOf = (f) => (map[f] === undefined ? '' : String(r[map[f]] ?? '').trim());
    const name = cellOf('name');
    if (!name) { say(n, 'no name.'); return; }
    if (kind === 'items') {
      const price = cleanPrice(cellOf('price'));
      if (price === null) { say(n, `"${name.slice(0, 30)}" has no price I can read ("${cellOf('price').slice(0, 20)}").`); return; }
      const item = { name, price };
      for (const f of ['barcode', 'unit', 'category', 'kind', 'taxClass']) if (cellOf(f)) item[f] = f === 'kind' ? cellOf(f).toLowerCase() : cellOf(f);
      out.push(item);
    } else {
      const person = { name, kind: (cellOf('kind') || 'customer').toLowerCase() };
      for (const f of ['phone', 'email']) if (cellOf(f)) person[f] = cellOf(f);
      out.push(person);
    }
  });
  // The same rules the Hub applies (lengths, kinds the business uses, at most 2000) decide what is kept.
  const checked = parseSetup({ schema: 1, business: { industry }, starter: kind === 'items' ? { items: out } : { people: out } });
  const kept = (kind === 'items' ? checked.value?.starter?.items : checked.value?.starter?.people) ?? [];
  for (const p of checked.problems) problems.push(p);
  return { rows: kept, problems, count: kept.length, columns };
}
