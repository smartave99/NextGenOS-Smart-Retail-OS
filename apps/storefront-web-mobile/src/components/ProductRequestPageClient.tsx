"use client";

import { useState } from "react";
import { ArrowRight, Camera, CheckCircle2, PackagePlus, Store } from "lucide-react";
import ProductRequestModal from "@/components/ProductRequestModal";
import { SHOP_NAME } from "@/lib/shop-name";

interface ProductRequestPageClientProps {
    initialQuery?: string;
}

const STEPS = [
    {
        icon: PackagePlus,
        title: "Describe the product",
        description: "Add the product name, brand, budget, and the details that matter to you.",
    },
    {
        icon: Camera,
        title: "Add a reference photo",
        description: "Upload a picture when you have one so our store team can identify it accurately.",
    },
    {
        icon: Store,
        title: "Check with the store",
        description: "We will record your suggestion. Purchases and availability checks happen in store.",
    },
];

export default function ProductRequestPageClient({
    initialQuery = "",
}: ProductRequestPageClientProps) {
    const [isFormOpen, setIsFormOpen] = useState(true);

    return (
        <>
            <main className="min-h-screen bg-slate-50 px-4 pb-20 pt-40 sm:px-6">
                <div className="mx-auto max-w-6xl">
                    <section className="relative overflow-hidden rounded-[2rem] bg-slate-950 px-6 py-12 text-white shadow-2xl sm:px-10 lg:px-14 lg:py-16">
                        <div className="absolute -right-24 -top-24 h-72 w-72 rounded-full bg-blue-500/25 blur-3xl" />
                        <div className="absolute -bottom-32 left-1/3 h-72 w-72 rounded-full bg-emerald-400/15 blur-3xl" />

                        <div className="relative max-w-3xl">
                            <div className="mb-6 inline-flex items-center gap-2 rounded-full border border-white/15 bg-white/10 px-4 py-2 text-sm font-bold text-emerald-200">
                                <PackagePlus className="h-4 w-4" aria-hidden="true" />
                                Product suggestion
                            </div>
                            <h1 className="text-4xl font-black tracking-tight sm:text-5xl lg:text-6xl">
                                Can&apos;t find what you need?
                            </h1>
                            <p className="mt-5 max-w-2xl text-lg leading-8 text-slate-300">
                                Tell the {SHOP_NAME} team what you would like us to stock. Add a photo,
                                preferred brand, and budget to help us understand your request.
                            </p>
                            <button
                                type="button"
                                onClick={() => setIsFormOpen(true)}
                                className="mt-8 inline-flex min-h-12 items-center justify-center gap-3 rounded-xl bg-white px-6 py-3 font-bold text-slate-950 transition-colors hover:bg-emerald-100 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-emerald-300"
                            >
                                Open request form
                                <ArrowRight className="h-4 w-4" aria-hidden="true" />
                            </button>
                        </div>
                    </section>

                    <section className="grid gap-5 py-10 md:grid-cols-3" aria-label="How product requests work">
                        {STEPS.map(({ icon: Icon, title, description }, index) => (
                            <article key={title} className="rounded-2xl border border-slate-200 bg-white p-6 shadow-sm">
                                <div className="flex items-center justify-between">
                                    <span className="grid h-11 w-11 place-items-center rounded-xl bg-blue-50 text-blue-700">
                                        <Icon className="h-5 w-5" aria-hidden="true" />
                                    </span>
                                    <span className="text-sm font-black text-slate-300">0{index + 1}</span>
                                </div>
                                <h2 className="mt-5 text-lg font-extrabold text-slate-950">{title}</h2>
                                <p className="mt-2 text-sm leading-6 text-slate-600">{description}</p>
                            </article>
                        ))}
                    </section>

                    <div className="flex items-start gap-3 rounded-2xl border border-amber-200 bg-amber-50 p-5 text-sm leading-6 text-amber-950">
                        <CheckCircle2 className="mt-0.5 h-5 w-5 shrink-0" aria-hidden="true" />
                        <p>
                            Sending this form records a product suggestion only. It does not create an
                            order, reserve stock, accept payment, or promise availability.
                        </p>
                    </div>
                </div>
            </main>

            <ProductRequestModal
                isOpen={isFormOpen}
                onClose={() => setIsFormOpen(false)}
                initialQuery={initialQuery}
            />
        </>
    );
}
