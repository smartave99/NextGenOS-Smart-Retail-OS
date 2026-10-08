// Checks a country pack against the specification (SPEC.md). Returns a list of problems in plain words; an empty list means it is sound.

const MODELS = ['gst-india', 'vat', 'regional', 'none'];
const KINDS = ['surcharge', 'fee', 'tip', 'retention', 'advance'];
const isObj = (x) => x && typeof x === 'object' && !Array.isArray(x);
const decimal = (s, maxDecimals) => typeof s === 'string' && new RegExp(`^\\d+(\\.\\d{1,${maxDecimals}})?$`).test(s);

export function validatePack(pack, fileName) {
  const problems = [];
  const bad = (m) => problems.push(m);
  if (!isObj(pack)) return ['the file is not a JSON object'];
  if (pack.schema !== 1) bad('"schema" must be 1');
  if (typeof pack.country !== 'string' || !/^[A-Z]{2}$/.test(pack.country)) bad('"country" must be two capital letters, like IN');
  if (fileName && pack.country + '.json' !== fileName) bad(`the file is called ${fileName} but "country" is ${pack.country}`);
  if (!pack.name || typeof pack.name !== 'string') bad('"name" is missing');
  if (!/^\d{4}-\d{2}-\d{2}$/.test(pack.asOf ?? '')) bad('"asOf" must be a date like 2026-10-05');
  if (pack.review !== null && !(isObj(pack.review) && pack.review.by && /^\d{4}-\d{2}-\d{2}$/.test(pack.review.on ?? ''))) bad('"review" must be null or { "by", "on" }');

  const c = pack.currency;
  if (!isObj(c)) bad('"currency" is missing');
  else {
    if (!/^[A-Z]{3}$/.test(c.code ?? '')) bad('currency "code" must be three capital letters');
    if (!c.symbol) bad('currency "symbol" is missing');
    if (![0, 1, 2, 3].includes(c.decimals)) bad('currency "decimals" must be 0, 1, 2 or 3');
    if (!['before', 'after'].includes(c.symbolPosition)) bad('"symbolPosition" must be before or after');
    if (typeof c.symbolSpace !== 'boolean') bad('"symbolSpace" must be true or false');
    if (!['indian', 'standard', 'none'].includes(c.grouping)) bad('"grouping" must be indian, standard or none');
    if (![',', '.'].includes(c.decimalSeparator)) bad('"decimalSeparator" must be "." or ","');
    if (typeof c.groupSeparator !== 'string' || c.groupSeparator.length !== 1) bad('"groupSeparator" must be one character');
    if (c.groupSeparator === c.decimalSeparator) bad('the group and decimal separators must differ');
  }
  if (!pack.locale || !/^[a-z]{2,3}(-[A-Za-z0-9]{2,8})*$/.test(pack.locale)) bad('"locale" must look like en-IN');
  if (!Array.isArray(pack.languages) || !pack.languages.length) bad('"languages" must list at least one language');
  if (!pack.timezone || !/^[A-Za-z_]+\/[A-Za-z_\/-]+$/.test(pack.timezone)) bad('"timezone" must look like Asia/Kolkata');
  if (!/^\+\d{1,4}$/.test(pack.phoneCode ?? '')) bad('"phoneCode" must look like +91');
  const fy = pack.fiscalYearStart;
  if (!isObj(fy) || !(fy.month >= 1 && fy.month <= 12) || !(fy.day >= 1 && fy.day <= 31)) bad('"fiscalYearStart" needs a month and a day');

  const t = pack.tax;
  if (!isObj(t)) { bad('"tax" is missing'); return problems; }
  if (!t.name) bad('tax "name" is missing');
  if (!MODELS.includes(t.model)) bad(`tax "model" must be one of ${MODELS.join(', ')}`);
  if (typeof t.pricesIncludeTaxDefault !== 'boolean') bad('"pricesIncludeTaxDefault" must be true or false');
  if (!Array.isArray(t.rates) || !t.rates.length) bad('tax "rates" needs at least one rate');
  else {
    const seen = new Set();
    for (const r of t.rates) {
      if (!/^[A-Za-z0-9]{1,12}$/.test(r.code ?? '')) bad(`rate code "${r.code}" must be letters and digits, up to 12`);
      if (seen.has(r.code)) bad(`rate code ${r.code} is used twice`);
      seen.add(r.code);
      if (!r.label) bad(`rate ${r.code} has no label`);
      const kinds = ['percent', 'exempt', 'zero', 'taxable'].filter((k) => r[k] !== undefined);
      if (kinds.length !== 1) bad(`rate ${r.code} must have exactly one of percent, exempt, zero or taxable`);
      if (r.percent !== undefined && !(decimal(r.percent, 3) && Number(r.percent) <= 100)) bad(`rate ${r.code}: percent "${r.percent}" must be a number from 0 to 100 with at most 3 decimals`);
      if (t.model === 'regional' && r.percent !== undefined) bad(`rate ${r.code}: in a regional pack rates have no percent (the region gives it)`);
      if (t.model !== 'regional' && r.taxable !== undefined) bad(`rate ${r.code}: "taxable" is for regional packs`);
    }
  }
  if (t.model === 'gst-india' || t.model === 'regional') {
    const list = t.regions?.list;
    if (!Array.isArray(list) || !list.length) bad(`a ${t.model} pack needs "regions"`);
    else {
      const codes = new Set();
      for (const rg of list) {
        if (!rg.code || !rg.name) bad('every region needs a code and a name');
        if (codes.has(rg.code)) bad(`region ${rg.code} is listed twice`);
        codes.add(rg.code);
        if (t.model === 'regional') {
          if (!Array.isArray(rg.components) || !rg.components.length) bad(`region ${rg.code} needs components`);
          else for (const comp of rg.components) if (!comp.name || !decimal(comp.percent, 3)) bad(`region ${rg.code}: component "${comp.name}" needs a name and a percent`);
        }
      }
    }
  }
  for (const d of t.customerDiscounts ?? []) {
    if (!/^[A-Z0-9]{2,12}$/.test(d.code ?? '') || !d.label || !decimal(d.percent, 3) || typeof d.vatExempt !== 'boolean') bad(`customer discount "${d.code}" needs a code, a label, a percent and vatExempt`);
  }
  if (!isObj(t.classes) || !t.classes.standard) bad('"classes" must at least name the "standard" rate code');
  else {
    const codes = new Set((t.rates ?? []).map((r) => r.code));
    for (const [k, v] of Object.entries(t.classes)) {
      if (!['standard', 'reduced', 'zero', 'exempt'].includes(k)) bad(`class "${k}" is not one of standard, reduced, zero, exempt`);
      else if (!codes.has(v)) bad(`class ${k} names the code ${v}, which is not in "rates"`);
    }
  }
  const rd = t.rounding;
  if (!isObj(rd) || !['nearest', 'none'].includes(rd.total) || typeof rd.defaultOn !== 'boolean') bad('tax "rounding" needs total (nearest or none) and defaultOn');
  else if (rd.total === 'nearest') {
    if (!decimal(rd.increment, c?.decimals ?? 3) || Number(rd.increment) <= 0) bad('rounding "increment" must be a positive amount in the currency, like 0.05');
  }
  if (t.businessId && !t.businessId.label) bad('businessId needs a label');
  if (t.businessId?.pattern) { try { new RegExp(t.businessId.pattern); } catch { bad('businessId "pattern" is not a valid pattern'); } }
  for (const part of ['itemCode', 'extraTax']) {
    if (t[part] === undefined) continue;
    if (!isObj(t[part]) || typeof t[part].label !== 'string' || !t[part].label.trim()) bad(`${part} needs a label (the words the programs show for it)`);
    else if (t[part].help !== undefined && typeof t[part].help !== 'string') bad(`${part} "help" must be text`);
  }
  const inv = pack.invoice;
  if (!isObj(inv) || !inv.title || !Array.isArray(inv.requiredFields)) bad('"invoice" needs a title and requiredFields');
  if (!Array.isArray(pack.notes)) bad('"notes" must be a list');
  return problems;
}

export { KINDS };
