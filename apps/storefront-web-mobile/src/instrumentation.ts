/**
 * Runs once when the website starts (Next.js calls register() before the first visitor). The customer's details are read here: a website that was started to use a customer
 * folder (the start program of the website package does) does not start at all when that folder is missing or wrong, and says why in plain words.
 */
export async function register() {
    if (process.env.NEXT_RUNTIME !== "nodejs") return;
    // While the website is being built nothing runs for a customer: the program is built once and is the same for every customer.
    if (process.env.NEXT_PHASE === "phase-production-build") return;
    const { assertCustomerSettings } = await import("@/lib/runtime-settings/start-check");
    const settings = assertCustomerSettings();
    if (settings) console.log(`The shop's details were read from the customer folder${settings.customer ? ` (${settings.customer})` : ""}.`);
}
