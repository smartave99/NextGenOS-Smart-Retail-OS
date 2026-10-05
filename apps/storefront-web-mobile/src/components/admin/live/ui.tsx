// Small building blocks of the Live shop section, in the admin panel's look.
import type { ReactNode } from "react";

export const inputClass =
    "w-full px-4 py-2.5 border border-gray-200 rounded-xl focus:outline-none focus:ring-2 focus:ring-brand-gold/30 focus:border-brand-gold transition-all text-sm bg-gray-50 focus:bg-white";

export const primaryButton =
    "inline-flex items-center justify-center gap-2 px-5 py-2.5 bg-brand-green hover:bg-brand-green/90 text-white rounded-xl transition-all text-sm font-medium shadow-sm disabled:opacity-60 disabled:cursor-not-allowed";

export const softButton =
    "inline-flex items-center justify-center gap-2 px-4 py-2 bg-white hover:bg-gray-50 text-brand-dark border border-gray-200 rounded-xl transition-all text-sm font-medium disabled:opacity-60 disabled:cursor-not-allowed";

export const linkButton = "text-sm font-medium text-brand-blue hover:underline disabled:opacity-60";

export function Card({ children, className = "" }: { children: ReactNode; className?: string }) {
    return <section className={`bg-white rounded-2xl border border-gray-100 shadow-sm p-5 sm:p-6 min-w-0 ${className}`}>{children}</section>;
}

export function CardHead({ title, children }: { title: string; children?: ReactNode }) {
    return (
        <div className="flex flex-wrap items-center justify-between gap-x-3 gap-y-2 mb-4">
            <h2 className="text-base font-semibold text-brand-dark">{title}</h2>
            {children}
        </div>
    );
}

type Tone = "live" | "warn" | "bad" | "plain";

const tones: Record<Tone, string> = {
    live: "bg-brand-green/10 text-brand-green",
    warn: "bg-amber-50 text-amber-800",
    bad: "bg-red-50 text-red-700",
    plain: "bg-gray-100 text-gray-700",
};

export function Pill({ tone = "plain", children, title }: { tone?: Tone; children: ReactNode; title?: string }) {
    return (
        <span title={title} className={`inline-flex items-center gap-1.5 rounded-full px-2.5 py-1 text-xs font-semibold whitespace-nowrap ${tones[tone]}`}>
            {children}
        </span>
    );
}

export function Note({ problem = false, children }: { problem?: boolean; children: ReactNode }) {
    return (
        <p role={problem ? "alert" : "status"} className={`rounded-xl px-4 py-3 text-sm ${problem ? "bg-red-50 text-red-700" : "bg-gray-50 text-gray-700"}`}>
            {children}
        </p>
    );
}

export function Field({ label, htmlFor, children }: { label: string; htmlFor: string; children: ReactNode }) {
    return (
        <div className="space-y-1.5">
            <label htmlFor={htmlFor} className="block text-xs font-medium text-brand-gray uppercase tracking-wider">{label}</label>
            {children}
        </div>
    );
}
