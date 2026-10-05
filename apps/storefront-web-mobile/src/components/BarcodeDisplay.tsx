"use client";

import { useRef } from "react";
import { ScanBarcode, Copy, Check } from "lucide-react";
import { useState } from "react";

interface BarcodeDisplayProps {
    productId: string;
    productName: string;
    barcode?: string | null;
}

/**
 * Generates a Code128B barcode as SVG paths.
 * Uses product ID to create a scannable barcode for billing & search.
 */
function generateCode128Bars(data: string): number[] {
    // Code 128B encoding table (simplified character set for alphanumeric)
    const CODE128B: Record<string, number[]> = {
        " ": [2, 1, 2, 2, 2, 2],
        "!": [2, 2, 2, 1, 2, 2],
        '"': [2, 2, 2, 2, 2, 1],
        "#": [1, 2, 1, 2, 2, 3],
        "$": [1, 2, 1, 3, 2, 2],
        "%": [1, 3, 1, 2, 2, 2],
        "&": [1, 2, 2, 2, 1, 3],
        "'": [1, 2, 2, 3, 1, 2],
        "(": [1, 3, 2, 2, 1, 2],
        ")": [2, 2, 1, 2, 1, 3],
        "*": [2, 2, 1, 3, 1, 2],
        "+": [2, 3, 1, 2, 1, 2],
        ",": [1, 1, 2, 2, 3, 2],
        "-": [1, 2, 2, 1, 3, 2],
        ".": [1, 2, 2, 2, 3, 1],
        "/": [1, 1, 3, 2, 2, 2],
        "0": [1, 2, 3, 1, 2, 2],
        "1": [1, 2, 3, 2, 2, 1],
        "2": [2, 2, 3, 2, 1, 1],
        "3": [2, 2, 1, 1, 3, 2],
        "4": [2, 2, 1, 2, 3, 1],
        "5": [2, 1, 3, 2, 1, 2],
        "6": [2, 2, 3, 1, 1, 2],
        "7": [3, 1, 2, 1, 3, 1],
        "8": [3, 1, 1, 2, 2, 2],
        "9": [3, 2, 1, 1, 2, 2],
        ":": [3, 2, 1, 2, 2, 1],
        ";": [3, 1, 2, 2, 1, 2],
        "<": [3, 2, 2, 1, 1, 2],
        "=": [3, 2, 2, 2, 1, 1],
        ">": [2, 1, 2, 1, 2, 3],
        "?": [2, 1, 2, 3, 2, 1],
        "@": [2, 3, 2, 1, 2, 1],
        "A": [1, 1, 1, 3, 2, 3],
        "B": [1, 3, 1, 1, 2, 3],
        "C": [1, 3, 1, 3, 2, 1],
        "D": [1, 1, 2, 3, 2, 2],  // Added missing D
        "E": [1, 3, 2, 1, 2, 2],  // Added missing E  
        "F": [1, 3, 2, 3, 2, 0],  // Added missing F
        "G": [2, 1, 1, 3, 1, 3],
        "H": [2, 3, 1, 1, 1, 3],
        "I": [2, 3, 1, 3, 1, 1],
        "J": [1, 1, 2, 1, 3, 3],
        "K": [1, 1, 2, 3, 3, 1],
        "L": [1, 3, 2, 1, 3, 1],
        "M": [1, 1, 3, 1, 2, 3],
        "N": [1, 1, 3, 3, 2, 1],
        "O": [1, 3, 3, 1, 2, 1],
        "P": [3, 1, 3, 1, 2, 1],
        "Q": [2, 1, 1, 3, 3, 1],
        "R": [2, 3, 1, 1, 3, 1],
        "S": [2, 1, 3, 1, 1, 3],
        "T": [2, 1, 3, 3, 1, 1],
        "U": [2, 1, 3, 1, 3, 1],
        "V": [3, 1, 1, 1, 2, 3],
        "W": [3, 1, 1, 3, 2, 1],
        "X": [3, 3, 1, 1, 2, 1],
        "Y": [3, 1, 2, 1, 1, 3],
        "Z": [3, 1, 2, 3, 1, 1],
        "a": [1, 1, 1, 3, 2, 3],
        "b": [1, 3, 1, 1, 2, 3],
        "c": [1, 3, 1, 3, 2, 1],
        "d": [1, 1, 2, 3, 2, 2],
        "e": [1, 3, 2, 1, 2, 2],
        "f": [1, 3, 2, 3, 2, 0],
        "g": [2, 1, 1, 3, 1, 3],
        "h": [2, 3, 1, 1, 1, 3],
        "i": [2, 3, 1, 3, 1, 1],
        "j": [1, 1, 2, 1, 3, 3],
        "k": [1, 1, 2, 3, 3, 1],
        "l": [1, 3, 2, 1, 3, 1],
        "m": [1, 1, 3, 1, 2, 3],
        "n": [1, 1, 3, 3, 2, 1],
        "o": [1, 3, 3, 1, 2, 1],
        "p": [3, 1, 3, 1, 2, 1],
        "q": [2, 1, 1, 3, 3, 1],
        "r": [2, 3, 1, 1, 3, 1],
        "s": [2, 1, 3, 1, 1, 3],
        "t": [2, 1, 3, 3, 1, 1],
        "u": [2, 1, 3, 1, 3, 1],
        "v": [3, 1, 1, 1, 2, 3],
        "w": [3, 1, 1, 3, 2, 1],
        "x": [3, 3, 1, 1, 2, 1],
        "y": [3, 1, 2, 1, 1, 3],
        "z": [3, 1, 2, 3, 1, 1],
    };

    const START_B = [2, 1, 1, 4, 1, 2];
    const STOP = [2, 3, 3, 1, 1, 1, 2];

    const bars: number[] = [...START_B];

    for (const char of data) {
        const pattern = CODE128B[char];
        if (pattern) {
            bars.push(...pattern);
        } else {
            // Fallback: use '?' pattern for unknown chars
            bars.push(...(CODE128B["?"] || [2, 1, 2, 3, 2, 1]));
        }
    }

    bars.push(...STOP);
    return bars;
}

export default function BarcodeDisplay({ productId, barcode }: BarcodeDisplayProps) {
    const svgRef = useRef<SVGSVGElement>(null);
    const [copied, setCopied] = useState(false);

    // Use custom barcode if set, otherwise fallback to product ID
    const displayValue = barcode ? barcode.trim() : productId;
    const barcodeValue = barcode ? barcode.trim() : productId.substring(0, 16);
    const bars = generateCode128Bars(barcodeValue);

    const barWidth = 1.5;
    const height = 50;
    const totalWidth = bars.reduce((sum, w) => sum + w * barWidth, 0);

    const handleCopy = async () => {
        try {
            await navigator.clipboard.writeText(displayValue);
            setCopied(true);
            setTimeout(() => setCopied(false), 2000);
        } catch {
            // Fallback for older browsers
            const textArea = document.createElement("textarea");
            textArea.value = displayValue;
            document.body.appendChild(textArea);
            textArea.select();
            document.execCommand("copy");
            document.body.removeChild(textArea);
            setCopied(true);
            setTimeout(() => setCopied(false), 2000);
        }
    };

    // Render barcode bars
    let xPos = 0;
    const barElements: { x: number; width: number; fill: boolean }[] = [];
    bars.forEach((width, index) => {
        barElements.push({
            x: xPos,
            width: width * barWidth,
            fill: index % 2 === 0, // Even indices are dark bars
        });
        xPos += width * barWidth;
    });

    return (
        <div className="bg-white border border-slate-200 rounded-2xl p-5 space-y-3">
            {/* Header */}
            <div className="flex items-center justify-between">
                <div className="flex items-center gap-2">
                    <div className="p-1.5 bg-slate-100 rounded-lg">
                        <ScanBarcode className="w-4 h-4 text-slate-600" />
                    </div>
                    <h4 className="font-bold text-sm text-slate-800 uppercase tracking-wider">
                        Product Barcode
                    </h4>
                </div>
                <button
                    onClick={handleCopy}
                    className="flex items-center gap-1.5 px-3 py-1.5 text-xs font-medium text-slate-500 bg-slate-50 hover:bg-slate-100 rounded-lg transition-colors border border-slate-200"
                    title={barcode ? "Copy Barcode" : "Copy Product ID"}
                >
                    {copied ? (
                        <>
                            <Check className="w-3 h-3 text-green-500" />
                            <span className="text-green-600">Copied!</span>
                        </>
                    ) : (
                        <>
                            <Copy className="w-3 h-3" />
                            {barcode ? "Copy Barcode" : "Copy ID"}
                        </>
                    )}
                </button>
            </div>

            {/* Barcode SVG */}
            <div className="flex justify-center bg-white py-4 px-6 rounded-xl border border-dashed border-slate-200">
                <svg
                    ref={svgRef}
                    width={totalWidth + 20}
                    height={height + 20}
                    viewBox={`0 0 ${totalWidth + 20} ${height + 20}`}
                    className="max-w-full h-auto"
                >
                    {barElements.map((bar, i) => (
                        <rect
                            key={i}
                            x={bar.x + 10}
                            y={5}
                            width={bar.width}
                            height={height}
                            fill={bar.fill ? "#0f172a" : "white"}
                        />
                    ))}
                </svg>
            </div>

            {/* Product ID / Barcode Label */}
            <div className="text-center">
                <p className="font-mono text-xs text-slate-500 tracking-widest select-all">
                    {displayValue}
                </p>
                <p className="text-xs text-slate-400 mt-1 uppercase tracking-wider">
                    {barcode ? "Scan for quick billing • Search by Barcode" : "Scan for quick billing • Search by ID"}
                </p>
            </div>
        </div>
    );
}

