"use client";

import { useRef, useState } from "react";
import { X, Send, Loader2, PackagePlus, AlertCircle, CheckCircle2 } from "lucide-react";
import { motion, AnimatePresence, useReducedMotion } from "framer-motion";
import { createProductRequest, ProductRequestInput } from "@/app/actions/request-actions";
import ImageUpload from "./CloudinaryUpload";
import { useDialogFocus } from "@/components/ui/useDialogFocus";
import { SHOP_NAME } from "@/lib/shop-name";

interface ProductRequestModalProps {
    isOpen: boolean;
    onClose: () => void;
    initialQuery?: string;
}

export default function ProductRequestModal({
    isOpen,
    onClose,
    initialQuery = "",
}: ProductRequestModalProps) {
    const [formData, setFormData] = useState<ProductRequestInput>({
        productName: initialQuery,
        brand: "",
        description: "",
        minPrice: undefined,
        maxPrice: undefined,
        imageUrl: "",
        contactInfo: "",
    });

    const [isSubmitting, setIsSubmitting] = useState(false);
    const [isSuccess, setIsSuccess] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const reduceMotion = useReducedMotion();
    const dialogRef = useRef<HTMLDivElement>(null);
    const closeRef = useRef<HTMLButtonElement>(null);

    useDialogFocus({
        open: isOpen,
        onClose,
        containerRef: dialogRef,
        initialFocusRef: closeRef,
    });

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setIsSubmitting(true);
        setError(null);

        try {
            const result = await createProductRequest(formData);
            if (result.success) {
                setIsSuccess(true);
                setIsSubmitting(false);
            } else {
                setError(result.error as string);
                setIsSubmitting(false);
            }
        } catch {
            setError("Couldn’t send your product request. Check your connection and try again; your details are still here.");
            setIsSubmitting(false);
        }
    };

    return (
        <AnimatePresence>
            {isOpen && (
                <div className="fixed inset-0 z-[100] flex items-center justify-center p-4 sm:p-6">
                    {/* Backdrop */}
                    <motion.button
                        type="button"
                        aria-label="Close product request"
                        initial={reduceMotion ? false : { opacity: 0 }}
                        animate={{ opacity: 1 }}
                        exit={{ opacity: 0 }}
                        transition={{ duration: 0.3 }}
                        onClick={onClose}
                        className="absolute inset-0 bg-slate-900/40 backdrop-blur-md"
                    />

                    {/* Modal */}
                    <motion.div
                        ref={dialogRef}
                        tabIndex={-1}
                        role="dialog"
                        aria-modal="true"
                        aria-labelledby="product-request-title"
                        initial={reduceMotion ? false : { opacity: 0, scale: 0.95, y: 10 }}
                        animate={{ opacity: 1, scale: 1, y: 0 }}
                        exit={{ opacity: 0, scale: 0.95, y: 10 }}
                        transition={reduceMotion ? { duration: 0 } : { type: "spring", damping: 25, stiffness: 300 }}
                        className="relative flex max-h-[90vh] w-full max-w-xl flex-col overflow-hidden rounded-3xl border border-white/50 bg-white/95 shadow-2xl backdrop-blur-xl"
                    >
                        {/* Header */}
                        <div className="relative px-8 pt-8 pb-4 flex justify-between items-start shrink-0 z-10">
                            <div>
                                <h2 id="product-request-title" className="flex items-center gap-2 text-2xl font-bold tracking-tight text-gray-900">
                                    <PackagePlus className="h-5 w-5 text-blue-700" aria-hidden="true" />
                                    Request a product
                                </h2>
                                <p className="text-slate-500 text-sm mt-1 font-medium">
                                    Tell the store team what you are looking for. This is not an order or reservation.
                                </p>
                            </div>
                            <button
                                ref={closeRef}
                                type="button"
                                onClick={onClose}
                                aria-label="Close product request"
                                className="-mr-2 -mt-2 grid h-11 w-11 place-items-center rounded-xl text-slate-500 transition-colors duration-100 hover:bg-slate-100 hover:text-slate-700"
                            >
                                <X className="w-5 h-5" />
                            </button>
                        </div>

                        {/* Content */}
                        <div className="flex-1 overflow-y-auto px-8 pb-8 custom-scrollbar">
                            <AnimatePresence mode="wait">
                                {isSuccess ? (
                                    <motion.div
                                        key="success"
                                        initial={{ opacity: 0, scale: 0.9 }}
                                        animate={{ opacity: 1, scale: 1 }}
                                        exit={{ opacity: 0, scale: 0.9 }}
                                        className="h-full flex flex-col items-center justify-center py-12 text-center"
                                    >
                                        <div className="w-20 h-20 bg-green-100/50 text-green-600 rounded-full flex items-center justify-center mb-6 shadow-sm">
                                            <CheckCircle2 className="w-10 h-10" />
                                        </div>
                                        <h3 className="mb-2 text-2xl font-bold text-gray-900">Request received</h3>
                                        <p className="text-gray-500 max-w-xs mx-auto text-base">
                                            This is not an order or reservation. Please visit the store to check availability and make your purchase.
                                        </p>
                                        <button type="button" onClick={onClose} className="mt-6 inline-flex min-h-12 items-center justify-center rounded-xl bg-blue-700 px-6 py-3 font-bold text-white hover:bg-blue-800">
                                            Close request confirmation
                                        </button>
                                    </motion.div>
                                ) : (
                                    <motion.form
                                        key="form"
                                        initial={{ opacity: 0 }}
                                        animate={{ opacity: 1 }}
                                        exit={{ opacity: 0 }}
                                        onSubmit={handleSubmit}
                                        className="space-y-6"
                                    >
                                        {error && (
                                            <div className="p-4 bg-red-50 text-red-600 rounded-2xl text-sm flex items-center gap-3 border border-red-100" role="alert">
                                                <AlertCircle className="w-5 h-5 shrink-0" />
                                                <span className="font-medium">{error}</span>
                                            </div>
                                        )}

                                        <div className="space-y-5">
                                            {/* Product Name */}
                                            <div className="group">
                                                <label htmlFor="request-product-name" className="mb-2 block text-sm font-semibold text-slate-700">Product name</label>
                                                <input
                                                    id="request-product-name"
                                                    type="text"
                                                    required
                                                    value={formData.productName}
                                                    onChange={(e) => setFormData({ ...formData, productName: e.target.value })}
                                                    className="min-h-12 w-full rounded-xl border border-slate-300 bg-slate-50 px-4 py-3 font-medium text-slate-800 outline-none transition-[border-color,box-shadow,background-color] duration-100 placeholder:text-slate-500 focus:border-blue-700 focus:bg-white focus:ring-4 focus:ring-blue-100"
                                                    placeholder="What are you looking for?"
                                                />
                                            </div>

                                            {/* Details Grid */}
                                            <div className="grid grid-cols-1 gap-5 sm:grid-cols-2">
                                                <div>
                                                    <label htmlFor="request-brand" className="mb-2 block text-sm font-semibold text-slate-700">Brand <span className="font-normal text-slate-500">(optional)</span></label>
                                                    <input
                                                        id="request-brand"
                                                        type="text"
                                                        value={formData.brand}
                                                        onChange={(e) => setFormData({ ...formData, brand: e.target.value })}
                                                        className="min-h-12 w-full rounded-xl border border-slate-300 bg-slate-50 px-4 py-3 font-medium text-slate-800 outline-none transition-[border-color,box-shadow,background-color] duration-100 focus:border-blue-700 focus:bg-white focus:ring-4 focus:ring-blue-100"
                                                        placeholder="For example, Milton"
                                                    />
                                                </div>
                                                <div>
                                                    <label htmlFor="request-contact" className="mb-2 block text-sm font-semibold text-slate-700">Phone number or email</label>
                                                    <input
                                                        id="request-contact"
                                                        type="text"
                                                        required
                                                        autoComplete="tel"
                                                        value={formData.contactInfo}
                                                        onChange={(e) => setFormData({ ...formData, contactInfo: e.target.value })}
                                                        className="min-h-12 w-full rounded-xl border border-slate-300 bg-slate-50 px-4 py-3 font-medium text-slate-800 outline-none transition-[border-color,box-shadow,background-color] duration-100 focus:border-blue-700 focus:bg-white focus:ring-4 focus:ring-blue-100"
                                                        placeholder="How should the store contact you?"
                                                    />
                                                </div>
                                            </div>

                                            {/* Price Range */}
                                            <div className="grid grid-cols-1 gap-5 sm:grid-cols-2">
                                                <div>
                                                    <label htmlFor="request-min-price" className="mb-2 block text-sm font-semibold text-slate-700">Minimum price <span className="font-normal text-slate-500">(optional)</span></label>
                                                    <div className="relative">
                                                        <span className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 font-medium">₹</span>
                                                        <input
                                                            id="request-min-price"
                                                            type="number"
                                                            min="0"
                                                            value={formData.minPrice || ""}
                                                            onChange={(e) => setFormData({ ...formData, minPrice: e.target.value ? Number(e.target.value) : undefined })}
                                                            inputMode="numeric"
                                                            className="min-h-12 w-full rounded-xl border border-slate-300 bg-slate-50 py-3 pl-8 pr-4 font-medium text-slate-800 outline-none transition-[border-color,box-shadow,background-color] duration-100 focus:border-blue-700 focus:bg-white focus:ring-4 focus:ring-blue-100"
                                                            placeholder="0"
                                                        />
                                                    </div>
                                                </div>
                                                <div>
                                                    <label htmlFor="request-max-price" className="mb-2 block text-sm font-semibold text-slate-700">Maximum price <span className="font-normal text-slate-500">(optional)</span></label>
                                                    <div className="relative">
                                                        <span className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 font-medium">₹</span>
                                                        <input
                                                            id="request-max-price"
                                                            type="number"
                                                            min="0"
                                                            value={formData.maxPrice || ""}
                                                            onChange={(e) => setFormData({ ...formData, maxPrice: e.target.value ? Number(e.target.value) : undefined })}
                                                            inputMode="numeric"
                                                            className="min-h-12 w-full rounded-xl border border-slate-300 bg-slate-50 py-3 pl-8 pr-4 font-medium text-slate-800 outline-none transition-[border-color,box-shadow,background-color] duration-100 focus:border-blue-700 focus:bg-white focus:ring-4 focus:ring-blue-100"
                                                            placeholder="Any"
                                                        />
                                                    </div>
                                                </div>
                                            </div>

                                            {/* Description */}
                                            <div>
                                                <label htmlFor="request-description" className="mb-2 block text-sm font-semibold text-slate-700">Product details</label>
                                                <textarea
                                                    id="request-description"
                                                    required
                                                    rows={3}
                                                    value={formData.description}
                                                    onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                                                    className="w-full resize-y rounded-xl border border-slate-300 bg-slate-50 px-4 py-3 font-medium text-slate-800 outline-none transition-[border-color,box-shadow,background-color] duration-100 focus:border-blue-700 focus:bg-white focus:ring-4 focus:ring-blue-100"
                                                    placeholder="Details about color, size, material, year, etc."
                                                />
                                            </div>

                                            {/* Image Upload */}
                                            <div>
                                                <p className="mb-2 text-sm font-semibold text-slate-700">Reference image <span className="font-normal text-slate-500">(optional)</span></p>
                                                <div className="bg-slate-50/50 rounded-2xl p-2 border border-slate-100 hover:border-brand-blue/30 transition-colors">
                                                    <ImageUpload
                                                        folder="product-requests"
                                                        onUpload={(files) => {
                                                            if (files.length > 0) {
                                                                setFormData({ ...formData, imageUrl: files[0].url });
                                                            }
                                                        }}
                                                        currentImages={formData.imageUrl ? [formData.imageUrl] : []}
                                                        onRemoveImage={() => setFormData({ ...formData, imageUrl: "" })}
                                                        maxFiles={1}
                                                        accept="image/*"
                                                        className="[&_button]:w-full [&_button]:border-2 [&_button]:border-dashed [&_button]:border-slate-200 [&_button]:bg-white [&_button]:py-4 [&_button]:text-slate-600 [&_button]:shadow-none [&_button]:transition-[border-color,color] [&_button]:duration-100 [&_button]:hover:border-blue-500 [&_button]:hover:text-blue-700"
                                                    />
                                                </div>
                                            </div>
                                        </div>

                                        <div className="pt-4">
                                            <p className="mb-4 rounded-xl border border-amber-200 bg-amber-50 p-3 text-center text-xs font-medium leading-5 text-amber-900">
                                                Suggestions do not reserve products. All purchases happen in person at the {SHOP_NAME} store.
                                            </p>
                                            <button
                                                type="submit"
                                                disabled={isSubmitting}
                                                aria-busy={isSubmitting}
                                                className="sa-press flex min-h-12 w-full items-center justify-center gap-2 rounded-xl bg-blue-700 px-5 py-3 text-base font-bold text-white shadow-lg shadow-blue-950/15 transition-[transform,background-color] duration-100 hover:bg-blue-800 disabled:cursor-not-allowed disabled:opacity-70"
                                            >
                                                {isSubmitting ? <Loader2 className="w-5 h-5 animate-spin" /> : <Send className="w-5 h-5" />}
                                                <span>{isSubmitting ? "Sending request…" : "Send product request"}</span>
                                            </button>
                                        </div>
                                    </motion.form>
                                )}
                            </AnimatePresence>
                        </div>
                    </motion.div>
                </div>
            )}
        </AnimatePresence>
    );
}
