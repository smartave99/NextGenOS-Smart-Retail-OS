import Link from "next/link";
import { ArrowRight } from "lucide-react";
import { getDepartments, HighlightsContent } from "@/app/actions";
import HighlightsCarousel from "./HighlightsCarousel";

export default async function Highlights({ content }: { content?: HighlightsContent }) {
    const departments = await getDepartments();

    // If no departments exist in the database, don't render the section
    if (departments.length === 0) {
        return null;
    }

    // If no content provided, do not render
    if (!content) {
        return null;
    }

    const finalContent = content;

    return (
        <section className="relative overflow-hidden bg-slate-50 py-14 sm:py-20" aria-labelledby="departments-heading">
            {/* Tech Grid Background Pattern */}
            <div className="absolute inset-0 z-0 opacity-[0.03]"
                style={{
                    backgroundImage: "linear-gradient(#000 1px, transparent 1px), linear-gradient(90deg, #000 1px, transparent 1px)",
                    backgroundSize: "40px 40px"
                }}
            />

            <div className="container mx-auto px-4 md:px-6 relative z-10">
                <div className="mb-10 flex flex-col items-start justify-between gap-6 md:mb-12 md:flex-row md:items-end">
                    <div className="max-w-xl">
                        <span className="text-brand-blue font-bold tracking-widest uppercase text-xs mb-2 block">{finalContent.subtitle}</span>
                        <h2 id="departments-heading" className="text-3xl font-extrabold text-brand-dark mb-4 tracking-tight sm:text-4xl md:text-5xl">
                            {finalContent.title}
                        </h2>
                        <p className="text-slate-500 text-lg leading-relaxed">
                            {finalContent.description}
                        </p>
                    </div>
                    <Link href="/departments" className="group flex min-h-11 items-center gap-2 rounded-lg px-2 font-semibold text-slate-900 transition-colors hover:bg-white hover:text-blue-700 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500">
                        {finalContent.viewAllLabel || "View All Departments"}
                        <ArrowRight className="w-4 h-4 group-hover:translate-x-1 transition-transform" />
                    </Link>
                </div>

                {/* Carousel with all departments */}
                <HighlightsCarousel
                    departments={departments}
                    exploreLabel={finalContent.exploreLabel}
                />
            </div>
        </section>
    );
}
