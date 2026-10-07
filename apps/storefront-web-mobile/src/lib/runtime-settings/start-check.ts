import "server-only";

import lite from "@/lib/region/generated/lite.json";
import industries from "@/lib/industry/generated/industries.json";
import { customerDir, readFolder, type PublicSettings } from "./index";

/**
 * Looks at the customer's folder when the website starts. When the program was started to use a customer folder (NGOS_CUSTOMER_DIR), the folder must be there and every value in it
 * must be good, including that the country and the kind of business are ones this website has packs for. Otherwise the website does not start, and the message says what to do.
 * Returns null when no folder is used (development and tests read the environment).
 */
export function assertCustomerSettings(): PublicSettings | null {
    const dir = customerDir();
    if (!dir) return null;
    return readFolder(dir, { countries: Object.keys(lite), industries: Object.keys(industries) });
}
