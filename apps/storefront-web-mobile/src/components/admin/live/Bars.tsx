"use client";

import { useEffect, useRef, useState, type KeyboardEvent } from "react";

export interface Bar {
    label: string;
    value: number;
    /** A pale column behind, e.g. the same hour last week. */
    ghost?: number;
    hi?: boolean;
    title: string;
    onClick?: () => void;
}

/**
 * Columns, the highest touching the top, drawn at the size they show so the labels stay readable on a phone.
 * Every column has its figure as a tooltip. Columns that open something are buttons: Tab reaches them, and Enter or
 * Space opens them, as a click does.
 */
export default function Bars({ bars, labelEvery, height = 170, label }: { bars: Bar[]; labelEvery?: number; height?: number; label: string }) {
    const box = useRef<HTMLDivElement>(null);
    const [width, setWidth] = useState(600);

    useEffect(() => {
        const element = box.current;
        if (!element) return;
        const measure = () => setWidth(Math.max(240, Math.round(element.clientWidth)));
        measure();
        if (typeof ResizeObserver === "undefined") return;
        const observer = new ResizeObserver(measure);
        observer.observe(element);
        return () => observer.disconnect();
    }, []);

    const base = height - 22;
    const top = 10;
    const slot = width / Math.max(1, bars.length);
    const highest = Math.max(1, ...bars.map((b) => Math.max(b.value || 0, b.ghost || 0)));
    const y = (v: number) => base - (Math.max(0, v || 0) / highest) * (base - top);
    const every = labelEvery ?? (slot >= 44 ? 1 : slot >= 24 ? 2 : 3);
    const w = Math.min(28, slot * 0.7);
    const interactive = bars.some((b) => b.onClick);

    return (
        <div ref={box} className="w-full">
            <svg width={width} height={height} viewBox={`0 0 ${width} ${height}`} role={interactive ? "group" : "img"} aria-label={label}
                className="block max-w-full">
                <line x1={0} x2={width} y1={base} y2={base} className="stroke-gray-200" strokeWidth={1} />
                {bars.map((b, i) => {
                    const centre = slot * i + slot / 2;
                    const first = i === 0 && slot < 60;
                    const last = i === bars.length - 1 && slot < 60;
                    const withGhost = b.ghost !== undefined;
                    return (
                        <g key={i} {...(b.onClick ? pressable(b) : {})}>
                            <title>{b.title}</title>
                            <rect x={slot * i + 1} y={1} width={Math.max(0, slot - 2)} height={height - 2} rx={4} fill="transparent" strokeWidth={2}
                                className={b.onClick ? "stroke-transparent group-focus-visible:stroke-brand-blue" : undefined} />
                            {withGhost && (b.ghost ?? 0) > 0 && (
                                <rect x={centre - w / 2} y={y(b.ghost!)} width={w} height={base - y(b.ghost!)} rx={3} className="fill-gray-200" />
                            )}
                            {b.value > 0 && (
                                <rect
                                    x={centre - (withGhost ? w * 0.3 : w / 2)}
                                    y={y(b.value)}
                                    width={withGhost ? w * 0.6 : w}
                                    height={base - y(b.value)}
                                    rx={3}
                                    className={b.hi ? "fill-brand-blue" : "fill-brand-green"}
                                />
                            )}
                            {(i % every === 0 || b.hi) && (
                                <text
                                    x={first ? 0 : last ? width : centre}
                                    y={height - 6}
                                    textAnchor={first ? "start" : last ? "end" : "middle"}
                                    className={b.hi ? "fill-brand-dark font-semibold" : "fill-gray-500"}
                                    fontSize={11}
                                >
                                    {b.label}
                                </text>
                            )}
                        </g>
                    );
                })}
            </svg>
        </div>
    );
}

/** A column that opens something, as a button: focusable, named by its tooltip, opened by a click, Enter or Space. */
function pressable(b: Bar) {
    return {
        role: "button",
        tabIndex: 0,
        "aria-label": b.title,
        "aria-pressed": b.hi ?? false,
        className: "group cursor-pointer outline-none",
        onClick: b.onClick,
        onKeyDown: (event: KeyboardEvent<SVGGElement>) => {
            if (event.key === "Enter" || event.key === " ") {
                event.preventDefault();
                b.onClick?.();
            }
        },
    };
}
