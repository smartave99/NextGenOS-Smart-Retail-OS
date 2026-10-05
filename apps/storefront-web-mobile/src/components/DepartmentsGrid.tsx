"use client";

import { useCallback, useRef, useState } from "react";
import { AnimatePresence, motion, useReducedMotion } from "framer-motion";
import { ArrowRight, Cpu, Home as HomeIcon, LucideIcon, Package, PenTool, Smile, Smartphone, Utensils, X } from "lucide-react";
import { DepartmentContent } from "@/app/actions";
import Image from "next/image";
import Link from "next/link";
import { useDialogFocus } from "@/components/ui/useDialogFocus";
import { SHOP_NAME } from "@/lib/shop-name";

const iconMap: Record<string, LucideIcon> = {
    PenTool,
    Smile,
    Utensils,
    Home: HomeIcon,
    Package,
    Cpu,
    Smartphone,
};

export default function DepartmentsGrid({ departments }: { departments: DepartmentContent[] }) {
    const [selectedId, setSelectedId] = useState<string | null>(null);
    const dialogRef = useRef<HTMLDivElement>(null);
    const closeRef = useRef<HTMLButtonElement>(null);
    const triggerRef = useRef<HTMLButtonElement>(null);
    const reduceMotion = useReducedMotion();
    const closeDialog = useCallback(() => setSelectedId(null), []);

    useDialogFocus({
        open: Boolean(selectedId),
        onClose: closeDialog,
        containerRef: dialogRef,
        initialFocusRef: closeRef,
        returnFocusRef: triggerRef,
    });

    if (departments.length === 0) {
        return (
            <div className="mx-auto max-w-sm py-16 text-center">
                <Package className="mx-auto mb-4 h-12 w-12 text-slate-300" aria-hidden="true" />
                <h2 className="text-xl font-bold text-slate-800">No departments listed yet</h2>
                <p className="mt-2 text-base leading-6 text-slate-600">The store catalogue is being organised. Browse all products while it is updated.</p>
                <Link href="/products" className="mt-5 inline-flex min-h-12 items-center justify-center rounded-xl bg-blue-700 px-5 py-3 font-bold text-white hover:bg-blue-800">
                    Browse products
                </Link>
            </div>
        );
    }

    const selectedDepartment = departments.find((department, index) => (department.id || `dept-${index}`) === selectedId);

    return (
        <>
            <div className="grid auto-rows-[340px] grid-cols-1 gap-4 sm:auto-rows-[380px] md:grid-cols-2 lg:grid-cols-3 lg:gap-6">
                {departments.map((department, index) => {
                    const Icon = iconMap[department.icon] || Package;
                    const isLarge = index === 0 || index === 3;

                    return (
                        <button
                            ref={selectedId === (department.id || `dept-${index}`) ? triggerRef : undefined}
                            type="button"
                            key={department.id || `dept-${index}`}
                            onClick={(event) => {
                                triggerRef.current = event.currentTarget;
                                setSelectedId(department.id || `dept-${index}`);
                            }}
                            aria-haspopup="dialog"
                            className={`sa-card-link group relative cursor-pointer overflow-hidden rounded-3xl bg-slate-950 text-left focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:ring-offset-4 ${isLarge ? "md:col-span-2" : ""}`}
                        >
                            <Image
                                src={department.image}
                                alt=""
                                fill
                                className="sa-card-image object-cover"
                                sizes="(max-width: 768px) 100vw, (max-width: 1200px) 50vw, 33vw"
                            />
                            <div className="absolute inset-0 bg-gradient-to-t from-slate-950 via-slate-950/55 to-slate-950/10" />
                            <div className="absolute inset-x-0 bottom-0 z-10 p-5 sm:p-7">
                                <span className="mb-4 grid h-12 w-12 place-items-center rounded-2xl border border-white/20 bg-white/10 text-blue-200 backdrop-blur-sm">
                                    <Icon className="h-6 w-6" aria-hidden="true" />
                                </span>
                                <h2 className="text-2xl font-extrabold text-white sm:text-3xl">{department.title}</h2>
                                <p className="mt-2 line-clamp-2 max-w-2xl text-base leading-6 text-slate-200">{department.description}</p>
                                <span className="mt-4 inline-flex min-h-11 items-center gap-2 rounded-xl bg-white/10 px-4 text-sm font-bold text-white">
                                    Explore department <ArrowRight className="h-4 w-4" aria-hidden="true" />
                                </span>
                            </div>
                        </button>
                    );
                })}
            </div>

            <AnimatePresence>
                {selectedId && selectedDepartment && (
                    <div className="fixed inset-0 z-[90] flex items-end justify-center p-0 sm:items-center sm:p-6">
                        <motion.button
                            type="button"
                            aria-label="Close department details"
                            initial={reduceMotion ? false : { opacity: 0 }}
                            animate={{ opacity: 1 }}
                            exit={{ opacity: 0 }}
                            transition={{ duration: reduceMotion ? 0 : 0.2 }}
                            onClick={closeDialog}
                            className="absolute inset-0 bg-slate-950/75 backdrop-blur-sm"
                        />
                        <motion.div
                            ref={dialogRef}
                            tabIndex={-1}
                            initial={reduceMotion ? false : { opacity: 0, y: 24, scale: 0.98 }}
                            animate={{ opacity: 1, y: 0, scale: 1 }}
                            exit={reduceMotion ? undefined : { opacity: 0, y: 16, scale: 0.98 }}
                            transition={{ duration: reduceMotion ? 0 : 0.3, ease: [0, 0, 0.2, 1] }}
                            role="dialog"
                            aria-modal="true"
                            aria-labelledby="department-dialog-title"
                            aria-describedby="department-dialog-description"
                            className="relative z-10 flex max-h-[92vh] w-full max-w-5xl flex-col overflow-hidden rounded-t-3xl bg-white shadow-2xl sm:rounded-3xl md:flex-row"
                        >
                            <button
                                ref={closeRef}
                                type="button"
                                onClick={closeDialog}
                                aria-label="Close department details"
                                className="absolute right-4 top-4 z-20 grid h-11 w-11 place-items-center rounded-xl bg-slate-950/75 text-white backdrop-blur-sm hover:bg-slate-950"
                            >
                                <X className="h-5 w-5" aria-hidden="true" />
                            </button>

                            <div className="relative h-64 w-full shrink-0 md:h-auto md:w-1/2">
                                <Image
                                    src={selectedDepartment.image}
                                    alt=""
                                    fill
                                    className="object-cover"
                                    sizes="(max-width: 768px) 100vw, 50vw"
                                />
                            </div>

                            <div className="flex w-full flex-col overflow-y-auto p-6 sm:p-8 md:w-1/2 md:p-10">
                                {(() => {
                                    const Icon = iconMap[selectedDepartment.icon] || Package;
                                    return (
                                        <span className="mb-5 grid h-12 w-12 place-items-center rounded-2xl bg-blue-50 text-blue-700">
                                            <Icon className="h-6 w-6" aria-hidden="true" />
                                        </span>
                                    );
                                })()}
                                <h2 id="department-dialog-title" className="pr-10 text-3xl font-extrabold text-slate-950">{selectedDepartment.title}</h2>
                                <p id="department-dialog-description" className="mt-4 text-base leading-7 text-slate-600">{selectedDepartment.description}</p>
                                <p className="mt-6 rounded-2xl border border-amber-200 bg-amber-50 p-4 text-sm leading-6 text-amber-950">
                                    Browse available products online, then purchase in person at the {SHOP_NAME} store.
                                </p>
                                <Link
                                    href={selectedDepartment.link || `/products?search=${encodeURIComponent(selectedDepartment.title)}`}
                                    className="sa-press mt-8 inline-flex min-h-12 items-center justify-center gap-2 rounded-xl bg-blue-700 px-5 py-3 font-bold text-white transition-[transform,background-color] duration-100 hover:bg-blue-800"
                                >
                                    Browse {selectedDepartment.title} <ArrowRight className="h-5 w-5" aria-hidden="true" />
                                </Link>
                            </div>
                        </motion.div>
                    </div>
                )}
            </AnimatePresence>
        </>
    );
}

