import '@testing-library/jest-dom';

// The product's own default is neutral (no country, no currency, no kind of shop: lib/customer/rules.mjs). Most of the existing tests were written for a shop in India that sells
// products, and say so here, through the developer's fallback (the customer's own settings come from a customer folder, which the tests of lib/customer make themselves).
process.env.NEXT_PUBLIC_COUNTRY ??= 'IN';
process.env.NEXT_PUBLIC_INDUSTRY ??= 'retail';
