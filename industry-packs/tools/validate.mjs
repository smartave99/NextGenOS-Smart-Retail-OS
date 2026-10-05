// Checks an industry pack against SPEC.md and returns the problems in plain words.

const TERMS = ['customer', 'item', 'sale', 'invoice', 'staff', 'supplier', 'stock'];
const FEATURES = ['counterSale', 'tables', 'kitchen', 'lending', 'projects', 'appointments', 'credit', 'purchases', 'weighedItems'];
const STOCK = ['always', 'optional', 'never'];
const CLASSES = ['standard', 'reduced', 'zero', 'exempt'];
const REPORTS = ['daily-sales', 'top-items', 'tax-summary', 'stock-low', 'stock-value', 'payments', 'table-turnover', 'overdue', 'popular-titles', 'member-activity', 'fines-collected', 'project-status', 'project-costs', 'outstanding', 'retention-held', 'appointments', 'staff-sales', 'top-customers', 'purchases'];
const ADJ_KINDS = ['surcharge', 'fee', 'tip', 'retention', 'advance'];
const isObj = (x) => x && typeof x === 'object' && !Array.isArray(x);
const money = (s) => typeof s === 'string' && /^\d+(\.\d{1,3})?$/.test(s);

export { TERMS, FEATURES, REPORTS };

export function validateIndustry(pack, fileName) {
  const problems = [];
  const bad = (m) => problems.push(m);
  if (!isObj(pack)) return ['the file is not a JSON object'];
  if (pack.schema !== 1) bad('"schema" must be 1');
  if (!/^[a-z][a-z0-9-]*$/.test(pack.id ?? '')) bad('"id" must be lower case letters, digits and dashes');
  if (fileName && `${pack.id}.json` !== fileName) bad(`the file is called ${fileName} but "id" is ${pack.id}`);
  for (const k of ['name', 'summary', 'icon', 'aiContext']) if (!pack[k] || typeof pack[k] !== 'string') bad(`"${k}" is missing`);

  if (!isObj(pack.vocabulary)) bad('"vocabulary" is missing');
  else for (const t of TERMS) {
    const v = pack.vocabulary[t];
    if (!Array.isArray(v) || v.length !== 2 || v.some((x) => typeof x !== 'string' || !x.trim())) bad(`vocabulary "${t}" must be [singular, plural]`);
  }

  const f = pack.features;
  if (!isObj(f)) bad('"features" is missing');
  else {
    for (const k of FEATURES) if (typeof f[k] !== 'boolean') bad(`feature "${k}" must be true or false`);
    if (!STOCK.includes(f.stockTracking)) bad('feature "stockTracking" must be always, optional or never');
    if (!FEATURES.some((k) => k !== 'purchases' && k !== 'credit' && k !== 'weighedItems' && f[k])) bad('at least one working area (counterSale, tables, lending, projects or appointments) must be on');
    if (f.kitchen && !f.tables && !f.counterSale) bad('"kitchen" needs "tables" or "counterSale"');
  }

  const kinds = new Set();
  if (!Array.isArray(pack.itemKinds) || !pack.itemKinds.length) bad('"itemKinds" needs at least one kind');
  else for (const k of pack.itemKinds) {
    if (!/^[a-z][a-z0-9-]*$/.test(k.id ?? '') || !k.label || typeof k.tracksStock !== 'boolean') bad(`item kind "${k.id}" needs an id, a label and tracksStock`);
    kinds.add(k.id);
  }
  if (!Array.isArray(pack.partyKinds) || !pack.partyKinds.length) bad('"partyKinds" needs at least one kind');
  else for (const k of pack.partyKinds) if (!/^[a-z][a-z0-9-]*$/.test(k.id ?? '') || !k.label) bad(`party kind "${k.id}" needs an id and a label`);

  const d = pack.defaults;
  if (!isObj(d) || !Array.isArray(d.adjustments) || !Array.isArray(d.paymentMethods) || !d.paymentMethods.length) bad('"defaults" needs adjustments and paymentMethods');
  else for (const a of d.adjustments) {
    if (!/^[A-Z0-9]{2,10}$/.test(a.code ?? '') || !ADJ_KINDS.includes(a.kind) || !a.label) bad(`default adjustment "${a.code}" needs a code, a kind (${ADJ_KINDS.join(', ')}) and a label`);
    if (a.percent !== undefined && !/^\d+(\.\d{1,3})?$/.test(a.percent)) bad(`adjustment ${a.code}: percent must be a number`);
  }
  if (!isObj(pack.rules)) bad('"rules" must be an object (it may be empty)');
  else {
    const r = pack.rules;
    if (f?.lending) {
      if (!Array.isArray(r.memberTypes) || !r.memberTypes.length) bad('a lending pack needs rules.memberTypes');
      else for (const m of r.memberTypes) if (!m.id || !m.label || !(m.loanDays > 0) || !(m.maxLoans > 0)) bad(`member type "${m.id}" needs id, label, loanDays and maxLoans`);
      for (const k of ['finePerDay', 'fineCap']) if (!money(r[k])) bad(`rules.${k} must be an amount like "1.00"`);
      if (!(r.renewals >= 0) || !(r.graceDays >= 0) || !(r.reservationHoldDays > 0)) bad('rules need renewals, graceDays and reservationHoldDays');
    }
    if (f?.projects) {
      if (!/^\d+(\.\d{1,3})?$/.test(r.retentionPercent ?? '')) bad('a projects pack needs rules.retentionPercent');
      if (!['taxable', 'subTotal'].includes(r.retentionBase)) bad('rules.retentionBase must be taxable or subTotal');
    }
    if (f?.appointments && (!(r.slotMinutes > 0) || !/^\d\d:\d\d$/.test(r.openFrom ?? '') || !/^\d\d:\d\d$/.test(r.openTo ?? ''))) bad('an appointments pack needs rules.slotMinutes, openFrom and openTo');
    if (f?.kitchen && (!Array.isArray(r.stations) || !r.stations.length)) bad('a kitchen pack needs rules.stations');
  }
  if (!Array.isArray(pack.reports) || !pack.reports.length) bad('"reports" needs at least one report');
  else for (const r of pack.reports) if (!REPORTS.includes(r)) bad(`report "${r}" is not one the Hub knows`);

  const demo = pack.demo;
  if (!isObj(demo) || !demo.company || !Array.isArray(demo.items) || !demo.items.length || !Array.isArray(demo.parties)) bad('"demo" needs a company, items and parties');
  else {
    for (const it of demo.items) {
      if (!it.name || !money(it.price) || !CLASSES.includes(it.class) || !kinds.has(it.kind)) bad(`demo item "${it.name}" needs a name, a price, a class (${CLASSES.join(', ')}) and one of the pack's item kinds`);
    }
    if (f?.tables && !(Array.isArray(demo.tables) && demo.tables.length)) bad('a tables pack needs demo.tables');
    if (f?.projects && !(Array.isArray(demo.projects) && demo.projects.length)) bad('a projects pack needs demo.projects');
    if (f?.lending && !demo.items.every((i) => i.isbn && i.copies > 0)) bad('every demo title in a lending pack needs an isbn and copies');
  }
  if (!isObj(pack.coverage) || !Array.isArray(pack.coverage.works) || !pack.coverage.works.length || !Array.isArray(pack.coverage.notYet)) bad('"coverage" needs works and notYet lists');
  return problems;
}
