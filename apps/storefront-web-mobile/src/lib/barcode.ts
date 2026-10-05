/**
 * Barcode helpers shared by storefront and server-side recommendation flows.
 * Formatting separators are ignored so a scanner value can match a barcode
 * entered by an administrator with spaces or hyphens.
 */
export function normalizeBarcode(value: string): string {
    return value.trim().replace(/[\s-]+/g, "").toUpperCase();
}

function isPlausibleBarcode(value: string): boolean {
    return value.length >= 4
        && value.length <= 64
        && /\d/.test(value)
        && /^[A-Z0-9.]+$/.test(value);
}

/**
 * Detects explicit barcode requests such as "barcode:8901234567890".
 * A plain query is treated as a barcode only when it is entirely numeric,
 * which avoids misclassifying ordinary product names such as "iPhone 14".
 */
export function extractBarcodeCandidate(query: string): string | null {
    const trimmed = query.trim();
    if (!trimmed) return null;

    const labelledMatch = trimmed.match(
        /\b(?:barcode|bar\s*code|ean|upc|sku)\b\s*(?:number|no\.?|#|:|-)?\s*([a-z0-9.-]{4,64})/i
    );
    if (labelledMatch) {
        const labelled = normalizeBarcode(labelledMatch[1]);
        return isPlausibleBarcode(labelled) ? labelled : null;
    }

    const direct = normalizeBarcode(trimmed);
    return /^\d{6,32}$/.test(direct) ? direct : null;
}
