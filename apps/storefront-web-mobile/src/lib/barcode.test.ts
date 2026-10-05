import { describe, expect, it } from "vitest";
import { extractBarcodeCandidate, normalizeBarcode } from "./barcode";

describe("barcode helpers", () => {
    it("normalizes common barcode formatting", () => {
        expect(normalizeBarcode(" 8901-2345 6789 ")).toBe("890123456789");
    });

    it("recognizes a scanned numeric barcode", () => {
        expect(extractBarcodeCandidate("8901234567890")).toBe("8901234567890");
    });

    it("recognizes an explicitly labelled alphanumeric barcode", () => {
        expect(extractBarcodeCandidate("barcode: AB-12-CD-34")).toBe("AB12CD34");
    });

    it("does not mistake an ordinary product query for a barcode", () => {
        expect(extractBarcodeCandidate("iPhone 14 case")).toBeNull();
    });
});
