"use client";

import { FormEvent, useEffect, useRef, useState } from "react";
import { Camera, Keyboard, Loader2, ScanLine, X } from "lucide-react";

interface DetectedBarcode {
    rawValue: string;
}

interface BarcodeDetectorInstance {
    detect(source: HTMLVideoElement): Promise<DetectedBarcode[]>;
}

type BarcodeDetectorConstructor = new (options?: {
    formats?: string[];
}) => BarcodeDetectorInstance;

interface BarcodeScannerProps {
    open: boolean;
    onClose: () => void;
    onDetected: (barcode: string) => void;
    title?: string;
}

const SUPPORTED_FORMATS = [
    "ean_13",
    "ean_8",
    "upc_a",
    "upc_e",
    "code_128",
    "code_39",
    "codabar",
    "itf",
];

export default function BarcodeScanner({
    open,
    onClose,
    onDetected,
    title = "Scan product barcode",
}: BarcodeScannerProps) {
    const videoRef = useRef<HTMLVideoElement>(null);
    const [manualValue, setManualValue] = useState("");
    const [error, setError] = useState<string | null>(null);
    const [starting, setStarting] = useState(false);

    useEffect(() => {
        if (!open) return;

        let stream: MediaStream | null = null;
        let timer: number | null = null;
        let detecting = false;
        let cancelled = false;

        const stop = () => {
            if (timer !== null) window.clearInterval(timer);
            stream?.getTracks().forEach(track => track.stop());
            if (videoRef.current) videoRef.current.srcObject = null;
        };

        const start = async () => {
            setError(null);
            setStarting(true);

            const Detector = (window as unknown as {
                BarcodeDetector?: BarcodeDetectorConstructor;
            }).BarcodeDetector;

            if (!Detector) {
                setError("Live barcode scanning is not supported in this browser. Enter the barcode below.");
                setStarting(false);
                return;
            }

            if (!navigator.mediaDevices?.getUserMedia) {
                setError("Camera access is not available. Enter the barcode below.");
                setStarting(false);
                return;
            }

            try {
                const detector = new Detector({ formats: SUPPORTED_FORMATS });
                stream = await navigator.mediaDevices.getUserMedia({
                    video: {
                        facingMode: { ideal: "environment" },
                        width: { ideal: 1280 },
                        height: { ideal: 720 },
                    },
                    audio: false,
                });

                if (cancelled || !videoRef.current) {
                    stop();
                    return;
                }

                videoRef.current.srcObject = stream;
                await videoRef.current.play();
                setStarting(false);

                timer = window.setInterval(async () => {
                    if (detecting || !videoRef.current || videoRef.current.readyState < 2) return;
                    detecting = true;
                    try {
                        const results = await detector.detect(videoRef.current);
                        const barcode = results[0]?.rawValue?.trim();
                        if (barcode) {
                            stop();
                            onDetected(barcode);
                            onClose();
                        }
                    } catch {
                        // Individual frames may fail while the camera focuses.
                    } finally {
                        detecting = false;
                    }
                }, 250);
            } catch (cameraError) {
                console.error("Barcode camera error:", cameraError);
                setError("Camera permission was denied or the camera is unavailable. Enter the barcode below.");
                setStarting(false);
                stop();
            }
        };

        void start();

        return () => {
            cancelled = true;
            stop();
        };
    }, [open, onClose, onDetected]);

    useEffect(() => {
        if (!open) {
            setManualValue("");
            setError(null);
            setStarting(false);
        }
    }, [open]);

    const submitManualBarcode = (event: FormEvent) => {
        event.preventDefault();
        const value = manualValue.trim();
        if (!value) return;
        onDetected(value);
        onClose();
    };

    if (!open) return null;

    return (
        <div
            className="fixed inset-0 z-[100] flex items-end justify-center bg-slate-950/75 p-3 backdrop-blur-sm sm:items-center"
            role="dialog"
            aria-modal="true"
            aria-labelledby="barcode-scanner-title"
        >
            <button
                type="button"
                className="absolute inset-0 cursor-default"
                onClick={onClose}
                aria-label="Close barcode scanner"
            />

            <div className="relative w-full max-w-lg overflow-hidden rounded-3xl bg-white shadow-2xl">
                <div className="flex items-center justify-between border-b border-slate-100 px-5 py-4">
                    <div>
                        <h2 id="barcode-scanner-title" className="flex items-center gap-2 font-extrabold text-slate-950">
                            <ScanLine className="h-5 w-5 text-blue-600" aria-hidden="true" />
                            {title}
                        </h2>
                        <p className="mt-1 text-xs text-slate-500">Point the rear camera at the printed barcode.</p>
                    </div>
                    <button
                        type="button"
                        onClick={onClose}
                        className="grid h-10 w-10 place-items-center rounded-xl bg-slate-100 text-slate-600 hover:bg-slate-200"
                        aria-label="Close barcode scanner"
                    >
                        <X className="h-5 w-5" aria-hidden="true" />
                    </button>
                </div>

                <div className="p-5">
                    <div className="relative aspect-[4/3] overflow-hidden rounded-2xl bg-slate-950">
                        <video
                            ref={videoRef}
                            className="h-full w-full object-cover"
                            muted
                            playsInline
                            aria-label="Live camera preview for barcode scanning"
                        />
                        <div className="pointer-events-none absolute inset-x-10 top-1/2 h-24 -translate-y-1/2 rounded-xl border-2 border-blue-400 shadow-[0_0_0_999px_rgba(2,6,23,0.3)]">
                            <div className="absolute inset-x-3 top-1/2 h-0.5 -translate-y-1/2 animate-pulse bg-red-400" />
                        </div>
                        {starting && (
                            <div className="absolute inset-0 grid place-items-center bg-slate-950/65 text-white">
                                <div className="flex items-center gap-2 text-sm font-bold">
                                    <Loader2 className="h-5 w-5 animate-spin" aria-hidden="true" />
                                    Starting camera…
                                </div>
                            </div>
                        )}
                        {!starting && error && (
                            <div className="absolute inset-0 flex flex-col items-center justify-center gap-3 bg-slate-950/85 px-8 text-center text-white">
                                <Camera className="h-8 w-8 text-slate-300" aria-hidden="true" />
                                <p className="text-sm leading-6">{error}</p>
                            </div>
                        )}
                    </div>

                    <form onSubmit={submitManualBarcode} className="mt-5">
                        <label htmlFor="manual-barcode" className="mb-2 flex items-center gap-2 text-sm font-bold text-slate-700">
                            <Keyboard className="h-4 w-4" aria-hidden="true" />
                            Or enter barcode
                        </label>
                        <div className="flex gap-2">
                            <input
                                id="manual-barcode"
                                value={manualValue}
                                onChange={event => setManualValue(event.target.value)}
                                inputMode="numeric"
                                autoComplete="off"
                                placeholder="Example: 8901234567890"
                                className="min-w-0 flex-1 rounded-xl border border-slate-200 px-4 py-3 text-slate-950 outline-none focus:border-blue-500 focus:ring-2 focus:ring-blue-500/20"
                            />
                            <button
                                type="submit"
                                disabled={!manualValue.trim()}
                                className="rounded-xl bg-blue-600 px-5 py-3 text-sm font-extrabold text-white hover:bg-blue-700 disabled:cursor-not-allowed disabled:opacity-40"
                            >
                                Find
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}
