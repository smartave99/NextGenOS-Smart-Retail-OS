// The cases of the engine contract. Each one is run through the reference engine (reference.mjs); the C# and TypeScript engines must
// give the same answer. A case names a real pack by country code ("pack") or carries a small pack of its own ("inline").

const L = (qty, unitPrice, taxCode, extra = {}) => ({ qty, unitPrice, taxCode, ...extra });
const cases = [];
const add = (name, spec) => cases.push({ name, ...spec });

// ---- India -------------------------------------------------------------------------------------------------------------------
add('IN: 118.00 with 18% included, same state', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '27' }, lines: [L('1', '118.00', 'GST18')] });
add('IN: odd paise included (99.99 at 18%)', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '27' }, lines: [L('1', '99.99', 'GST18')] });
add('IN: odd paise included (1.00 at 5%)', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '29', buyerRegion: '29' }, lines: [L('1', '1.00', 'GST5')] });
add('IN: excluded 18% on 100.00, same state', { pack: 'IN', context: { pricesIncludeTax: false, sellerRegion: '27' }, lines: [L('1', '100.00', 'GST18')] });
add('IN: excluded 5% on 33.33 (half-up CGST)', { pack: 'IN', context: { pricesIncludeTax: false, sellerRegion: '27' }, lines: [L('3', '33.33', 'GST5')] });
add('IN: inter-state included becomes IGST', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '27', buyerRegion: '29' }, lines: [L('2', '590.00', 'GST18')] });
add('IN: inter-state excluded becomes IGST', { pack: 'IN', context: { pricesIncludeTax: false, sellerRegion: '27', buyerRegion: '07' }, lines: [L('1', '1999.00', 'GST18')] });
add('IN: weight and percent discount', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10' }, lines: [L('2.5', '45.50', 'GST5', { discountPercent: '10' })] });
add('IN: fixed discount amount', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10' }, lines: [L('1', '1000.00', 'GST18', { discountAmount: '99.00' })] });
add('IN: discount larger than the line is clamped', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10' }, lines: [L('1', '50.00', 'GST5', { discountAmount: '80.00' })] });
add('IN: old 28% rate with 12% cess, included', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '27' }, lines: [L('1', '1400.00', 'GST28', { cessPercent: '12' })] });
add('IN: old 28% rate with 12% cess, excluded, between states', { pack: 'IN', context: { pricesIncludeTax: false, sellerRegion: '27', buyerRegion: '29' }, lines: [L('1', '1000.00', 'GST28', { cessPercent: '12' })] });
add('IN: nil rated and exempt lines', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '09' }, lines: [L('1', '40.00', 'GST0'), L('1', '25.00', 'GSTEX'), L('1', '105.00', 'GST5')] });
add('IN: 40% luxury rate included', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '27' }, lines: [L('1', '1400.00', 'GST40')] });
add('IN: gold at 3%', { pack: 'IN', context: { pricesIncludeTax: false, sellerRegion: '32' }, lines: [L('10', '6500.00', 'GST3')] });
add('IN: a grocery bill with three rates, rounded to the rupee', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10', roundTotal: true }, lines: [
  L('2', '56.00', 'GST0'), L('1', '149.00', 'GST5'), L('3', '33.50', 'GST5', { discountPercent: '5' }), L('1', '499.00', 'GST18'), L('0.750', '260.00', 'GST5')] });
add('IN: rounding off down', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10', roundTotal: true }, lines: [L('1', '100.40', 'GST0')] });
add('IN: rounding off up on a half', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10', roundTotal: true }, lines: [L('1', '100.50', 'GST0')] });
add('IN: an unregistered seller charges no tax', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10', registered: false }, lines: [L('1', '118.00', 'GST18')] });
add('IN: zero quantity', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10' }, lines: [L('0', '118.00', 'GST18')] });
add('IN: a very large bill', { pack: 'IN', context: { pricesIncludeTax: false, sellerRegion: '27' }, lines: [L('123456.789', '98765432.10', 'GST18')] });

// ---- Philippines -------------------------------------------------------------------------------------------------------------
add('PH: 112.00 with 12% VAT included', { pack: 'PH', context: { pricesIncludeTax: true }, lines: [L('1', '112.00', 'VAT12')] });
add('PH: VAT added on top', { pack: 'PH', context: { pricesIncludeTax: false }, lines: [L('4', '25.00', 'VAT12')] });
add('PH: senior citizen discount (VAT-exempt, 20%)', { pack: 'PH', context: { pricesIncludeTax: true }, lines: [L('1', '112.00', 'VAT12', { customerDiscount: 'SENIOR' })] });
add('PH: person with a disability on two items', { pack: 'PH', context: { pricesIncludeTax: true }, lines: [L('2', '56.50', 'VAT12', { customerDiscount: 'PWD' })] });
add('PH: a bill with one senior item and one normal item', { pack: 'PH', context: { pricesIncludeTax: true }, lines: [L('1', '224.00', 'VAT12', { customerDiscount: 'SENIOR' }), L('1', '89.00', 'VAT12')] });
add('PH: senior discount with prices that do not include VAT', { pack: 'PH', context: { pricesIncludeTax: false }, lines: [L('1', '100.00', 'VAT12', { customerDiscount: 'SENIOR' })] });
add('PH: zero-rated and exempt', { pack: 'PH', context: { pricesIncludeTax: true }, lines: [L('1', '500.00', 'VAT0'), L('1', '300.00', 'VATEX'), L('1', '112.00', 'VAT12')] });
add('PH: not VAT-registered (NON-VAT receipt)', { pack: 'PH', context: { pricesIncludeTax: true, registered: false }, lines: [L('1', '112.00', 'VAT12'), L('2', '30.00', 'VAT12')] });

// ---- other countries (the real packs) -----------------------------------------------------------------------------------------
add('GB: 20% included', { pack: 'GB', context: { pricesIncludeTax: true }, lines: [L('1', '24.00', 'VAT20'), L('1', '5.25', 'VAT5')] });
add('DE: 19% and 7% included, two lines', { pack: 'DE', context: { pricesIncludeTax: true }, lines: [L('3', '4.99', 'MWST19'), L('2', '2.49', 'MWST7')] });
add('FR: 5.5% and 2.1% (one decimal of a percent)', { pack: 'FR', context: { pricesIncludeTax: true }, lines: [L('1', '10.55', 'TVA5P5'), L('1', '10.21', 'TVA2P1')] });
add('JP: no decimals, 10% and 8% included', { pack: 'JP', context: { pricesIncludeTax: true }, lines: [L('1', '1100', 'JCT10'), L('3', '108', 'JCT8')] });
add('ID: no decimals, 11% added on top', { pack: 'ID', context: { pricesIncludeTax: false }, lines: [L('7', '12500', 'PPN11')] });
add('SG: GST 9% with cash rounding to 5 cents', { pack: 'SG', context: { pricesIncludeTax: true, roundTotal: true }, lines: [L('1', '3.33', 'GST9'), L('1', '4.46', 'GST9')] });
add('NL: 21% with cash rounding to 5 cents', { pack: 'NL', context: { pricesIncludeTax: true, roundTotal: true }, lines: [L('1', '2.99', 'BTW21')] });
add('AU: GST-free and 10%', { pack: 'AU', context: { pricesIncludeTax: true }, lines: [L('1', '4.50', 'GSTFREE'), L('1', '11.00', 'GST10')] });
add('CA: Ontario HST 13% included', { pack: 'CA', context: { pricesIncludeTax: true, sellerRegion: 'ON' }, lines: [L('1', '113.00', 'TAXABLE')] });
add('CA: Quebec GST 5% and QST 9.975% excluded', { pack: 'CA', context: { pricesIncludeTax: false, sellerRegion: 'QC' }, lines: [L('1', '100.00', 'TAXABLE')] });
add('CA: Quebec GST and QST included (the last part takes the remainder)', { pack: 'CA', context: { pricesIncludeTax: true, sellerRegion: 'QC' }, lines: [L('1', '114.98', 'TAXABLE'), L('2', '7.77', 'TAXABLE')] });
add('CA: British Columbia with a zero-rated item and cash rounding', { pack: 'CA', context: { pricesIncludeTax: false, sellerRegion: 'BC', roundTotal: true }, lines: [L('1', '10.00', 'ZERO'), L('1', '19.99', 'TAXABLE')] });
add('CA: the buyer\'s province decides', { pack: 'CA', context: { pricesIncludeTax: false, sellerRegion: 'AB', buyerRegion: 'ON' }, lines: [L('1', '50.00', 'TAXABLE')] });
add('HK: no tax at all', { pack: 'HK', context: { pricesIncludeTax: true }, lines: [L('2', '88.88', 'NONE')] });
add('TH: 7% included', { pack: 'TH', context: { pricesIncludeTax: true }, lines: [L('1', '107.00', 'VAT7')] });
add('MY: service tax 8% added, rounded to 5 sen', { pack: 'MY', context: { pricesIncludeTax: false, roundTotal: true }, lines: [L('1', '33.33', 'SVC8')] });

// ---- small packs of their own (rules the real packs do not reach) --------------------------------------------------------------
const kwd = { schema: 1, country: 'KW', currency: { decimals: 3 }, tax: { name: 'VAT', model: 'vat', rates: [{ code: 'V5', percent: '5' }], rounding: { total: 'none' } } };
add('Three decimals (a dinar): 5% included', { inline: kwd, context: { pricesIncludeTax: true }, lines: [L('1', '10.500', 'V5'), L('3', '0.375', 'V5')] });
const us = { schema: 1, country: 'US', currency: { decimals: 2 }, tax: { name: 'Sales tax', model: 'regional', rates: [{ code: 'TAXABLE', taxable: true }, { code: 'EXEMPT', exempt: true }],
  regions: { list: [{ code: 'STORE', components: [{ name: 'Sales tax', percent: '8.875', editable: true }] }] }, rounding: { total: 'none' } } };
add('A shop-set sales tax of 8.875% (excluded)', { inline: us, context: { pricesIncludeTax: false, sellerRegion: 'STORE' }, lines: [L('1', '19.99', 'TAXABLE'), L('1', '5.00', 'EXEMPT')] });
add('A shop-set sales tax of 8.875% (included)', { inline: us, context: { pricesIncludeTax: true, sellerRegion: 'STORE' }, lines: [L('1', '19.99', 'TAXABLE')] });
const vat3 = { schema: 1, country: 'ZZ', currency: { decimals: 2 }, tax: { name: 'VAT', model: 'vat', rates: [{ code: 'V7P5', percent: '7.5' }, { code: 'V0', zero: true }], rounding: { total: 'nearest', increment: '0.10', defaultOn: true } } };
add('A rate with half a percent and rounding that is on by default', { inline: vat3, context: { pricesIncludeTax: false }, lines: [L('1', '13.37', 'V7P5')] });
add('Rounding that is on by default can be switched off', { inline: vat3, context: { pricesIncludeTax: false, roundTotal: false }, lines: [L('1', '13.37', 'V7P5')] });
const vatCess = { schema: 1, country: 'ZZ', currency: { decimals: 2 }, tax: { name: 'VAT', model: 'vat', rates: [{ code: 'V10', percent: '10' }], rounding: { total: 'none' } } };
add('VAT with a cess, included', { inline: vatCess, context: { pricesIncludeTax: true }, lines: [L('1', '121.00', 'V10', { cessPercent: '10' })] });

// ---- document adjustments --------------------------------------------------------------------------------------------------------
add('Restaurant: 10% service charge with VAT, and a tip', { pack: 'GB', context: { pricesIncludeTax: true }, lines: [L('2', '12.50', 'VAT20'), L('1', '6.00', 'VAT20')], adjustments: [
  { code: 'SVC', kind: 'surcharge', label: 'Service charge', percent: '10', taxCode: 'VAT20' }, { code: 'TIP', kind: 'tip', amount: '4.00' }] });
add('Restaurant: service charge on the whole bill, not taxed', { pack: 'IN', context: { pricesIncludeTax: false, sellerRegion: '27' }, lines: [L('2', '250.00', 'GST5'), L('1', '120.00', 'GST5')], adjustments: [
  { code: 'SVC', kind: 'surcharge', percent: '5', base: 'subTotal' }] });
add('Restaurant in India: service charge taxed at 5% GST', { pack: 'IN', context: { pricesIncludeTax: false, sellerRegion: '27' }, lines: [L('2', '250.00', 'GST5')], adjustments: [
  { code: 'SVC', kind: 'surcharge', percent: '10', taxCode: 'GST5' }] });
add('Builder: 5% retention and an advance', { pack: 'GB', context: { pricesIncludeTax: false }, lines: [L('1', '25000.00', 'VAT20', { })], adjustments: [
  { code: 'RET', kind: 'retention', percent: '5', label: 'Retention' }, { code: 'ADV', kind: 'advance', amount: '5000.00' }] });
add('Builder: retention on the total including tax', { pack: 'GB', context: { pricesIncludeTax: false }, lines: [L('1', '1000.00', 'VAT20')], adjustments: [
  { code: 'RET', kind: 'retention', percent: '10', base: 'subTotal' }] });
add('Library: a fine that is not taxed', { pack: 'IN', context: { pricesIncludeTax: true, sellerRegion: '10' }, lines: [L('1', '0.00', 'GSTEX')], adjustments: [
  { code: 'FINE', kind: 'fee', label: 'Late fee', amount: '12.50' }] });
add('Delivery fee taxed at 20%', { pack: 'GB', context: { pricesIncludeTax: true }, lines: [L('1', '60.00', 'VAT20')], adjustments: [
  { code: 'DEL', kind: 'fee', amount: '5.00', taxCode: 'VAT20' }] });
add('An advance larger than the bill leaves a credit', { pack: 'GB', context: { pricesIncludeTax: true }, lines: [L('1', '60.00', 'VAT20')], adjustments: [
  { code: 'ADV', kind: 'advance', amount: '100.00' }] });
add('Surcharge rounded with the total (cash rounding)', { pack: 'SG', context: { pricesIncludeTax: false, roundTotal: true }, lines: [L('1', '17.30', 'GST9')], adjustments: [
  { code: 'SVC', kind: 'surcharge', percent: '10', taxCode: 'GST9' }, { code: 'TIP', kind: 'tip', amount: '1.00' }] });
add('Regional surcharge (Quebec): the service charge pays GST and QST', { pack: 'CA', context: { pricesIncludeTax: false, sellerRegion: 'QC' }, lines: [L('1', '80.00', 'TAXABLE')], adjustments: [
  { code: 'SVC', kind: 'surcharge', percent: '15', taxCode: 'TAXABLE' }] });
add('Senior discount line and a service charge on the rest (Philippines)', { pack: 'PH', context: { pricesIncludeTax: true }, lines: [L('1', '112.00', 'VAT12', { customerDiscount: 'SENIOR' }), L('1', '224.00', 'VAT12')], adjustments: [
  { code: 'SVC', kind: 'surcharge', percent: '10', taxCode: 'VAT12' }] });

// ---- how an amount is written (country, amount) --------------------------------------------------------------------------------------
const formats = [
  ['IN', '0'], ['IN', '5.5'], ['IN', '999.99'], ['IN', '1000'], ['IN', '12345.6'], ['IN', '1234567.5'], ['IN', '123456789.99'], ['IN', '-1234.56'],
  ['PH', '1234567.5'], ['US', '1234.5'], ['US', '-0'], ['GB', '1000000'], ['DE', '1234.5'], ['FR', '1234567.89'], ['NL', '12345.6'], ['ES', '999.99'], ['ES', '1000'],
  ['JP', '1234567'], ['ID', '15000'], ['VN', '250000'], ['ZA', '1234567.8'], ['BD', '1234567.8'], ['AE', '1234.5'], ['CH', '0'],
].filter(([c]) => c !== 'CH');

export { cases, formats };
