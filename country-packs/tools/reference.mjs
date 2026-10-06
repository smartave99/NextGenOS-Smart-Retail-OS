// Reference implementation of the tax engine (country-packs/SPEC.md). BigInt integers only: no floating point anywhere.
// It makes the vectors (tools/cli.mjs vectors); the C# and TypeScript engines must agree with it on every vector.

const R = (a, b) => (2n * a + b) / (2n * b); // round half up for non-negative a, positive b

/** "199.50" -> 19950n for 2 decimals. Accepts at most `decimals` digits after the point. */
export function parseDecimal(text, decimals) {
  const m = /^(\d+)(?:\.(\d+))?$/.exec(String(text).trim());
  if (!m) throw new Error(`not a number: ${text}`);
  const frac = m[2] ?? '';
  if (frac.length > decimals) throw new Error(`too many decimals in ${text} (max ${decimals})`);
  return BigInt(m[1] + frac.padEnd(decimals, '0'));
}

export function formatMinor(n, decimals) {
  const neg = n < 0n;
  const s = (neg ? -n : n).toString().padStart(decimals + 1, '0');
  const body = decimals ? `${s.slice(0, -decimals)}.${s.slice(-decimals)}` : s;
  return neg ? `-${body}` : body;
}

const milli = (text) => parseDecimal(text, 3); // "7.5" -> 7500n

function rateOf(pack, code) {
  const rate = pack.tax.rates.find((r) => r.code === code);
  if (!rate) throw new Error(`unknown tax code ${code}`);
  return rate;
}

function regionComponents(pack, region) {
  const found = (pack.tax.regions?.list ?? []).find((x) => x.code === region);
  if (!found || !found.components) throw new Error(`no tax components for region ${region}`);
  return found.components.map((c) => ({ name: c.name, milli: milli(c.percent) }));
}

export function calculate(pack, context, lines, adjustments = []) {
  const d = pack.currency.decimals;
  const model = pack.tax.model;
  const registered = context.registered !== false;
  const inclusive = !!context.pricesIncludeTax;
  const rounding = pack.tax.rounding ?? { total: 'none' };
  const roundTotal = context.roundTotal ?? !!rounding.defaultOn;

  const outLines = [];
  for (const line of lines) {
    const rate = rateOf(pack, line.taxCode);
    const Q = parseDecimal(line.qty, 3);
    const P = parseDecimal(line.unitPrice, d);
    const gross = R(Q * P, 1000n);
    let discount = 0n;
    if (line.discountAmount != null) discount = parseDecimal(line.discountAmount, d);
    else if (line.discountPercent != null) discount = R(gross * milli(line.discountPercent), 100000n);
    if (discount > gross) discount = gross;
    const net = gross - discount;

    const isExemptCode = !!rate.exempt;
    const taxFree = !registered || rate.exempt || rate.zero || model === 'none';
    let r = 0n;
    let comps = null; // regional components
    if (model === 'regional') {
      // The components are always known so that a zero-rated line still shows its (zero) amounts in the same columns.
      comps = regionComponents(pack, context.buyerRegion ?? context.sellerRegion);
      if (!taxFree) r = comps.reduce((a, c) => a + c.milli, 0n);
    } else if (!taxFree) {
      r = milli(rate.percent);
    }
    const c = taxFree ? 0n : line.cessPercent != null ? milli(line.cessPercent) : 0n;

    const out = { code: line.taxCode, percent: formatPercent(r), gross, discount, taxable: 0n, parts: [], cess: 0n, customerDiscount: 0n, exemptAmount: 0n, lineTotal: 0n };
    const names = componentNames(pack, model, context, rate, comps);

    const cd = line.customerDiscount ? (pack.tax.customerDiscounts ?? []).find((x) => x.code === line.customerDiscount) : null;
    if (line.customerDiscount && !cd) throw new Error(`unknown customer discount ${line.customerDiscount}`);

    if (cd) {
      const base = inclusive ? R(net * 100000n, 100000n + r) : net;
      const cdAmount = R(base * milli(cd.percent), 100000n);
      out.customerDiscount = cdAmount;
      if (cd.vatExempt) {
        out.taxable = 0n;
        out.parts = names.map((n) => ({ name: n, amount: 0n }));
        out.exemptAmount = base;
        out.lineTotal = base - cdAmount;
      } else {
        const t = base - cdAmount;
        const rest = taxLine(model, names, t, r, c, false, context, comps);
        out.taxable = t;
        out.parts = rest.parts;
        out.cess = rest.cess;
        out.lineTotal = t + sum(rest.parts) + rest.cess;
      }
    } else {
      const rest = taxLine(model, names, net, r, c, inclusive, context, comps);
      out.taxable = rest.taxable;
      out.parts = rest.parts;
      out.cess = rest.cess;
      out.exemptAmount = isExemptCode ? rest.taxable : 0n;
      out.lineTotal = rest.taxable + sum(rest.parts) + rest.cess;
    }
    outLines.push(out);
  }

  // totals
  const names = outLines[0]?.parts.map((p) => p.name) ?? componentNames(pack, model, context, { }, null);
  const totals = { gross: 0n, discount: 0n, taxable: 0n, parts: new Map(), cess: 0n, customerDiscount: 0n, exemptSales: 0n, subTotal: 0n };
  const byCode = new Map();
  for (const l of outLines) {
    totals.gross += l.gross; totals.discount += l.discount; totals.taxable += l.taxable; totals.cess += l.cess;
    totals.customerDiscount += l.customerDiscount; totals.exemptSales += l.exemptAmount; totals.subTotal += l.lineTotal;
    for (const p of l.parts) totals.parts.set(p.name, (totals.parts.get(p.name) ?? 0n) + p.amount);
    const b = byCode.get(l.code) ?? { code: l.code, percent: l.percent, taxable: 0n, parts: new Map(), cess: 0n };
    b.taxable += l.taxable; b.cess += l.cess;
    for (const p of l.parts) b.parts.set(p.name, (b.parts.get(p.name) ?? 0n) + p.amount);
    byCode.set(l.code, b);
  }
  // adjustments (section 9): worked from the lines only
  const lineTaxable = totals.taxable;
  const lineSub = totals.subTotal;
  const adjOut = [];
  let tips = 0n, advances = 0n, retention = 0n;
  for (const adj of adjustments) {
    const baseValue = (adj.base ?? 'taxable') === 'subTotal' ? lineSub : lineTaxable;
    const pct = adj.percent != null ? milli(adj.percent) : null;
    if (adj.kind === 'surcharge' || adj.kind === 'fee') {
      const amount = pct != null ? R(baseValue * pct, 100000n) : parseDecimal(adj.amount, d);
      let parts = [];
      let taxable = 0n;
      if (adj.taxCode) {
        const rate = rateOf(pack, adj.taxCode);
        const taxFree = !registered || rate.exempt || rate.zero || model === 'none';
        let r = 0n;
        let comps = null;
        if (model === 'regional') {
          comps = regionComponents(pack, context.buyerRegion ?? context.sellerRegion);
          if (!taxFree) r = comps.reduce((a, c) => a + c.milli, 0n);
        } else if (!taxFree) r = milli(rate.percent);
        const rest = taxLine(model, componentNames(pack, model, context, rate, comps), amount, r, 0n, false, context, comps);
        taxable = rest.taxable;
        parts = rest.parts;
        totals.taxable += taxable;
        for (const p of parts) totals.parts.set(p.name, (totals.parts.get(p.name) ?? 0n) + p.amount);
        const b = byCode.get(adj.taxCode) ?? { code: adj.taxCode, percent: formatPercent(r), taxable: 0n, parts: new Map(), cess: 0n };
        b.taxable += taxable;
        for (const p of parts) b.parts.set(p.name, (b.parts.get(p.name) ?? 0n) + p.amount);
        byCode.set(adj.taxCode, b);
      }
      const total = amount + sum(parts);
      totals.subTotal += total;
      adjOut.push({ code: adj.code, kind: adj.kind, label: adj.label ?? '', amount, taxable, parts });
    } else if (adj.kind === 'tip') {
      const amount = parseDecimal(adj.amount, d);
      tips += amount;
      adjOut.push({ code: adj.code, kind: adj.kind, label: adj.label ?? '', amount, taxable: 0n, parts: [] });
    } else if (adj.kind === 'advance') {
      const amount = parseDecimal(adj.amount, d);
      advances += amount;
      adjOut.push({ code: adj.code, kind: adj.kind, label: adj.label ?? '', amount, taxable: 0n, parts: [] });
    } else if (adj.kind === 'retention') {
      const amount = pct != null ? R(baseValue * pct, 100000n) : parseDecimal(adj.amount, d);
      retention += amount;
      adjOut.push({ code: adj.code, kind: adj.kind, label: adj.label ?? '', amount, taxable: 0n, parts: [] });
    } else {
      throw new Error(`unknown adjustment kind ${adj.kind}`);
    }
  }

  let grand = totals.subTotal;
  if (roundTotal && rounding.total === 'nearest') {
    const inc = parseDecimal(rounding.increment, d);
    grand = R(totals.subTotal, inc) * inc;
  }
  let payable = grand + tips - advances - retention;
  let credit = 0n;
  if (payable < 0n) { credit = -payable; payable = 0n; }
  const f = (n) => formatMinor(n, d);
  const compOut = (map) => [...map.entries()].map(([name, amount]) => ({ name, amount: f(amount) }));
  return {
    lines: outLines.map((l) => ({
      gross: f(l.gross), discount: f(l.discount), taxable: f(l.taxable), components: l.parts.map((p) => ({ name: p.name, amount: f(p.amount) })),
      cess: f(l.cess), customerDiscount: f(l.customerDiscount), exemptAmount: f(l.exemptAmount), lineTotal: f(l.lineTotal),
    })),
    adjustments: adjOut.map((a) => ({ code: a.code, kind: a.kind, label: a.label, amount: f(a.amount), taxable: f(a.taxable), components: a.parts.map((p) => ({ name: p.name, amount: f(p.amount) })) })),
    totals: {
      gross: f(totals.gross), discount: f(totals.discount), taxable: f(totals.taxable), components: names.map((n) => ({ name: n, amount: f(totals.parts.get(n) ?? 0n) })),
      cess: f(totals.cess), customerDiscount: f(totals.customerDiscount), exemptSales: f(totals.exemptSales),
      subTotal: f(totals.subTotal), roundOff: f(grand - totals.subTotal), grandTotal: f(grand),
      tips: f(tips), advances: f(advances), retention: f(retention), payable: f(payable), credit: f(credit),
    },
    byCode: [...byCode.values()].map((b) => ({ code: b.code, percent: b.percent, taxable: f(b.taxable), components: compOut(b.parts), cess: f(b.cess) })),
  };
}

const sum = (parts) => parts.reduce((a, p) => a + p.amount, 0n);

function formatPercent(milliPercent) {
  const whole = milliPercent / 1000n;
  const frac = (milliPercent % 1000n).toString().padStart(3, '0').replace(/0+$/, '');
  return frac ? `${whole}.${frac}` : `${whole}`;
}

function componentNames(pack, model, context, rate, comps) {
  if (model === 'gst-india') {
    const inter = context.buyerRegion && context.sellerRegion && context.buyerRegion !== context.sellerRegion;
    return inter ? ['IGST'] : ['CGST', 'SGST'];
  }
  if (model === 'regional') return (comps ?? regionComponents(pack, context.buyerRegion ?? context.sellerRegion)).map((c) => c.name);
  if (model === 'none') return [];
  return [rate.component ?? pack.tax.name];
}

/** Steps 5-7 of the specification for one value. `value` is the net (inclusive) or the taxable value (exclusive). */
function taxLine(model, names, value, r, c, inclusive, context, comps) {
  let taxable;
  let tax;
  let cess;
  if (inclusive) {
    taxable = R(value * 100000n, 100000n + r + c);
    const taxTotal = value - taxable;
    cess = R(taxable * c, 100000n);
    tax = taxTotal - cess;
  } else {
    taxable = value;
    cess = R(taxable * c, 100000n);
    tax = 0n; // set below per model
  }

  let parts;
  if (model === 'none' || names.length === 0) {
    parts = [];
  } else if (model === 'gst-india') {
    if (names.length === 2) {
      const cgst = inclusive ? R(tax, 2n) : R(taxable * r, 200000n);
      const sgst = inclusive ? tax - cgst : cgst;
      parts = [{ name: 'CGST', amount: cgst }, { name: 'SGST', amount: sgst }];
    } else {
      parts = [{ name: 'IGST', amount: inclusive ? tax : R(taxable * r, 100000n) }];
    }
  } else if (model === 'regional') {
    const total = inclusive ? tax : R(taxable * r, 100000n);
    parts = [];
    let used = 0n;
    comps.forEach((comp, i) => {
      let amount;
      if (i === comps.length - 1) amount = total - used;
      else if (r === 0n) amount = 0n;
      else amount = inclusive ? R(total * comp.milli, r) : R(taxable * comp.milli, 100000n);
      used += amount;
      parts.push({ name: comp.name, amount });
    });
  } else {
    parts = [{ name: names[0], amount: inclusive ? tax : R(taxable * r, 100000n) }];
  }
  return { taxable, parts, cess };
}

/** The amount as a person reads it in this currency (SPEC section 3, currency): "₹12,34,567.50", "1.234,50 €", "-$5.00". */
export function formatMoney(amount, currency) {
  const text = String(amount).trim();
  const negative = text.startsWith('-');
  const minor = parseDecimal(negative ? text.slice(1) : text, currency.decimals);
  const plain = formatMinor(minor, currency.decimals);
  const [whole, frac = ''] = plain.split('.');
  const size = currency.grouping === 'indian' ? 2 : 3;
  let grouped = whole;
  if (currency.grouping !== 'none' && whole.length > 3) {
    const parts = [];
    let head = whole.slice(0, -3);
    while (head.length > size) { parts.unshift(head.slice(-size)); head = head.slice(0, -size); }
    if (head) parts.unshift(head);
    parts.push(whole.slice(-3));
    grouped = parts.join(currency.groupSeparator);
  }
  const number = frac ? grouped + currency.decimalSeparator + frac : grouped;
  const space = currency.symbolSpace ? '\u00a0' : '';
  const shown = currency.symbolPosition === 'after' ? number + space + currency.symbol : currency.symbol + space + number;
  return negative && minor !== 0n ? '-' + shown : shown;
}
