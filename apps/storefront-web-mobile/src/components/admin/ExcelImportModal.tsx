"use client";

import React, { useState, useRef } from 'react';
import { Upload, X, FileSpreadsheet, Loader2, CheckCircle, AlertCircle } from 'lucide-react';
import { importProductsFromExcel } from '@/app/actions/product-import';
import { useDialogFocus } from '@/components/ui/useDialogFocus';

interface ExcelImportModalProps {
    isOpen: boolean;
    onClose: () => void;
    onSuccess: () => void;
}

export default function ExcelImportModal({ isOpen, onClose, onSuccess }: ExcelImportModalProps) {
    const [file, setFile] = useState<File | null>(null);
    const [isUploading, setIsUploading] = useState(false);
    const [result, setResult] = useState<{ success: boolean; count?: number; error?: string } | null>(null);
    const fileInputRef = useRef<HTMLInputElement>(null);
    const dialogRef = useRef<HTMLDivElement>(null);
    const closeRef = useRef<HTMLButtonElement>(null);

    useDialogFocus({
        open: isOpen,
        onClose,
        containerRef: dialogRef,
        initialFocusRef: closeRef,
    });

    if (!isOpen) return null;

    const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (e.target.files && e.target.files[0]) {
            setFile(e.target.files[0]);
            setResult(null);
        }
    };

    const handleDrop = (e: React.DragEvent) => {
        e.preventDefault();
        if (e.dataTransfer.files && e.dataTransfer.files[0]) {
            setFile(e.dataTransfer.files[0]);
            setResult(null);
        }
    };

    const handleUpload = async () => {
        if (!file) return;

        setIsUploading(true);
        const formData = new FormData();
        formData.append('file', file);

        try {
            const res = await importProductsFromExcel(formData);
            if (res.success) {
                setResult({ success: true, count: res.count });
                setTimeout(() => {
                    onSuccess();
                    onClose();
                }, 2000);
            } else {
                setResult({ success: false, error: res.error as string });
            }
        } catch {
            setResult({ success: false, error: "Couldn’t import the spreadsheet. Check the file and connection, then try again." });
        } finally {
            setIsUploading(false);
        }
    };

    return (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4">
            <button type="button" className="absolute inset-0 bg-black/50 backdrop-blur-sm" onClick={onClose} aria-label="Close spreadsheet import" />
            <div ref={dialogRef} tabIndex={-1} role="dialog" aria-modal="true" aria-labelledby="excel-import-title" aria-describedby="excel-import-help" className="relative z-10 w-full max-w-md overflow-hidden rounded-2xl bg-white shadow-2xl animate-in fade-in zoom-in duration-200">
                <div className="p-4 border-b border-gray-100 flex items-center justify-between bg-gray-50/50">
                    <h2 id="excel-import-title" className="flex items-center gap-2 font-semibold text-gray-800">
                        <FileSpreadsheet className="w-5 h-5 text-green-600" />
                        Import products from Excel
                    </h2>
                    <button ref={closeRef} type="button" onClick={onClose} className="grid h-11 w-11 place-items-center rounded-xl transition-colors hover:bg-gray-200" aria-label="Close spreadsheet import">
                        <X className="h-5 w-5 text-gray-600" aria-hidden="true" />
                    </button>
                </div>

                <div className="p-6">
                    {!result || !result.success ? (
                        <>
                            <div
                                className={`rounded-xl border-2 border-dashed p-3 text-center transition-colors
                                    ${file ? 'border-green-500 bg-green-50/30' : 'border-gray-200 hover:border-green-400 hover:bg-gray-50'}`}
                                onDragOver={(e) => e.preventDefault()}
                                onDrop={handleDrop}
                            >
                                <input
                                    type="file"
                                    ref={fileInputRef}
                                    className="hidden"
                                    accept=".xlsx"
                                    onChange={handleFileChange}
                                    aria-describedby="excel-import-help"
                                />
                                <button type="button" onClick={() => fileInputRef.current?.click()} className="flex min-h-44 w-full flex-col items-center justify-center rounded-lg px-4 py-6 focus-visible:ring-2 focus-visible:ring-green-700">
                                    {file ? (
                                        <>
                                            <FileSpreadsheet className="mb-2 h-12 w-12 text-green-700" aria-hidden="true" />
                                            <span className="break-all font-medium text-gray-800">{file.name}</span>
                                            <span className="text-sm text-gray-600">{(file.size / 1024).toFixed(1)} KB · Choose another file</span>
                                        </>
                                    ) : (
                                        <>
                                            <Upload className="mb-2 h-12 w-12 text-gray-400" aria-hidden="true" />
                                            <span className="font-medium text-gray-700">Choose an Excel file</span>
                                            <span className="mt-1 text-sm text-gray-600">or drag and drop · .xlsx</span>
                                        </>
                                    )}
                                </button>
                            </div>

                            <div id="excel-import-help" className="mt-4 rounded-lg border border-blue-100 bg-blue-50 p-3 text-sm leading-5 text-gray-700">
                                <p className="mb-1 font-semibold text-blue-800">Required columns</p>
                                <p>Name, Price. Optional: Description, Category, Subcategory, ImageUrl, Available (TRUE/FALSE), Featured (TRUE/FALSE), Tags, OfferTitle, Barcode.</p>
                            </div>

                            {result?.success === false && (
                                <div className="mt-4 flex items-start gap-2 rounded-lg bg-red-50 p-3 text-sm text-red-800" role="alert">
                                    <AlertCircle className="w-5 h-5 flex-shrink-0" />
                                    <span>{result.error}</span>
                                </div>
                            )}

                            <div className="mt-6 flex justify-end gap-3">
                                <button
                                    type="button"
                                    onClick={onClose}
                                    className="min-h-11 rounded-lg px-4 py-2 text-sm font-medium text-gray-700 hover:bg-gray-100 hover:text-gray-900"
                                >
                                    Cancel
                                </button>
                                <button
                                    type="button"
                                    onClick={handleUpload}
                                    disabled={!file || isUploading}
                                    aria-busy={isUploading}
                                    className="flex min-h-11 items-center gap-2 rounded-lg bg-green-700 px-4 py-2 text-sm font-medium text-white shadow-sm transition-colors hover:bg-green-800 disabled:cursor-not-allowed disabled:opacity-50"
                                >
                                    {isUploading ? <Loader2 className="w-4 h-4 animate-spin" /> : <Upload className="w-4 h-4" />}
                                    Import Products
                                </button>
                            </div>
                        </>
                    ) : (
                        <div className="py-6 text-center" role="status" aria-live="polite">
                            <div className="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-4 animate-in zoom-in duration-300">
                                <CheckCircle className="w-8 h-8 text-green-600" />
                            </div>
                            <h3 className="mb-2 text-xl font-bold text-gray-800">Import complete</h3>
                            <p className="text-gray-600">
                                Successfully processed <span className="font-bold text-green-700">{result.count}</span> products.
                            </p>
                            <p className="text-sm text-gray-500 mt-2">Refreshing product list...</p>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
}
