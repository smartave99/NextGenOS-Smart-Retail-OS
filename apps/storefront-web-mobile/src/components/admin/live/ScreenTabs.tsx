"use client";

import { useCallback, useEffect, useState } from "react";

export type Screen = "today" | "review" | "shop";

const SCREENS: { id: Screen; label: string }[] = [
    { id: "today", label: "Today" },
    { id: "review", label: "Last week" },
    { id: "shop", label: "From the shop" },
];

/** How each screen is written in the address; Today is the page itself. */
const HASH: Record<Screen, string> = { today: "", review: "#review", shop: "#shop" };

const fromAddress = (): Screen => {
    if (typeof window === "undefined") return "today";
    return SCREENS.find(({ id }) => HASH[id] !== "" && HASH[id] === window.location.hash)?.id ?? "today";
};

/**
 * Which screen is shown. It is kept in the address (`/admin/live#review`, `#shop`), so a screen can be bookmarked, survives a
 * reload and follows the browser's Back; changing screen never adds an entry to the history.
 */
export function useScreen(): [Screen, (next: Screen) => void] {
    const [screen, setScreen] = useState<Screen>(fromAddress);

    useEffect(() => {
        const follow = () => setScreen(fromAddress());
        window.addEventListener("hashchange", follow);
        return () => window.removeEventListener("hashchange", follow);
    }, []);

    const show = useCallback((next: Screen) => {
        setScreen(next);
        window.history.replaceState(null, "", window.location.pathname + window.location.search + HASH[next]);
    }, []);

    return [screen, show];
}

/**
 * Today, Last week and From the shop. All are buttons: Tab reaches them, Enter or Space opens one; the open one is marked as
 * current. `waiting` is how many products wait for the owner on From the shop (null when it cannot be said).
 */
export default function ScreenTabs({ screen, onChange, waiting = null }: { screen: Screen; onChange: (next: Screen) => void; waiting?: number | null }) {
    return (
        <nav aria-label="Screens" className="flex w-fit gap-1 rounded-xl bg-gray-100 p-1">
            {SCREENS.map(({ id, label }) => {
                const open = screen === id;
                return (
                    <button
                        key={id}
                        type="button"
                        aria-current={open ? "true" : undefined}
                        onClick={() => onChange(id)}
                        className={`rounded-lg px-4 py-1.5 text-sm font-medium transition-all focus-visible:outline-2 focus-visible:outline-brand-blue ${
                            open ? "bg-white text-brand-dark shadow-sm" : "text-brand-gray hover:text-brand-dark"
                        }`}
                    >
                        {label}
                        {id === "shop" && waiting ? (
                            <>
                                <span aria-hidden="true" className="ml-1.5 inline-flex min-w-5 items-center justify-center rounded-full bg-brand-green px-1.5 text-xs font-semibold text-white">{waiting}</span>
                                <span className="sr-only">{`, ${waiting} waiting for you`}</span>
                            </>
                        ) : null}
                    </button>
                );
            })}
        </nav>
    );
}
