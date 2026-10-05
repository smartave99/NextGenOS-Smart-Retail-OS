"use client";

import { useState } from "react";
import {
    dayShort, hourName, longDate, quantity, rupees, share, shortDate, timeOfDay, weekday,
} from "@/lib/live-shop/format";
import type { OwnerDay, OwnerLive } from "@/lib/live-shop/types";
import Bars from "./Bars";
import { Card, CardHead, Pill, linkButton } from "./ui";

const HISTORY_DAYS = 60;

export function Today({ live }: { live: OwnerLive }) {
    const t = live.today;
    return (
        <Card className="bg-gradient-to-br from-white to-brand-green/5">
            <p className="text-sm font-medium text-brand-gray">
                Sales today{t.lastBillAt ? ` · last bill at ${timeOfDay(t.lastBillAt)}` : ""}
            </p>
            <p className="mt-1 text-4xl sm:text-5xl font-semibold text-brand-dark tracking-tight" data-testid="live-sales">{rupees(t.sales)}</p>
            {t.vsLastWeek === null || t.vsLastWeek === undefined ? (
                <p className="mt-2 text-sm text-brand-gray">Nothing to compare with last {weekday(t.day)}</p>
            ) : (
                <p className={`mt-2 text-sm font-semibold ${t.vsLastWeek >= 0 ? "text-brand-green" : "text-red-600"}`}>
                    {share(t.vsLastWeek)}
                    <span className="font-normal text-brand-gray">
                        {` vs last ${weekday(t.day)}${t.comparedAt ? " by " + timeOfDay(t.comparedAt) : ""} (${rupees(t.lastWeekSales)})`}
                    </span>
                </p>
            )}
            <div className="mt-5 grid grid-cols-3 gap-3">
                <Fact value={String(t.bills)} label={t.bills === 1 ? "bill" : "bills"} />
                <Fact value={t.bills ? rupees(t.sales / t.bills) : "–"} label="average bill" />
                <Fact value={rupees(t.credit)} label="on credit" />
            </div>
        </Card>
    );
}

function Fact({ value, label }: { value: string; label: string }) {
    return (
        <div className="rounded-xl bg-white/70 border border-gray-100 px-3 py-2">
            <strong className="block text-lg font-semibold text-brand-dark">{value}</strong>
            <span className="text-xs text-brand-gray">{label}</span>
        </div>
    );
}

export function Hours({ live }: { live: OwnerLive }) {
    const hours = live.hours ?? [];
    if (!hours.length) return null;
    const nowHour = live.today.lastBillAt ? Number(live.today.lastBillAt.slice(0, 2)) : -1;
    return (
        <Card>
            <CardHead title="Today by the hour">
                <span className="flex items-center gap-3 text-xs text-brand-gray">
                    <span className="flex items-center gap-1.5"><i className="inline-block w-2.5 h-2.5 rounded-sm bg-brand-green" />Today</span>
                    <span className="flex items-center gap-1.5"><i className="inline-block w-2.5 h-2.5 rounded-sm bg-gray-200" />Same day last week</span>
                </span>
            </CardHead>
            <Bars label="Sales by hour today, with the same day last week"
                bars={hours.map((x) => ({
                    label: hourName(x.hour), value: x.sales, ghost: x.lastWeekSales ?? 0, hi: x.hour === nowHour,
                    title: `${hourName(x.hour)}: ${rupees(x.sales)} from ${x.bills} bills today; ${rupees(x.lastWeekSales)} last week`,
                }))} />
        </Card>
    );
}

export function Bills({ live }: { live: OwnerLive }) {
    const [all, setAll] = useState(false);
    const bills = live.bills ?? [];
    const shown = all ? bills : bills.slice(0, 20);
    return (
        <Card>
            <CardHead title="Today's bills"><span className="text-sm text-brand-gray">{bills.length} so far</span></CardHead>
            {bills.length ? (
                <ul className="divide-y divide-gray-100" data-testid="live-bills">
                    {shown.map((bill, i) => (
                        <li key={`${bill.number}-${i}`} className="grid grid-cols-[5.5rem_1fr_auto] items-center gap-3 py-2.5 text-sm">
                            <span className="text-brand-gray">{bill.later ? "entered later" : timeOfDay(bill.time) || "–"}</span>
                            <span className="font-mono text-brand-dark truncate">{bill.number}</span>
                            <span className="text-right font-semibold text-brand-dark">
                                {rupees(bill.total)}
                                {bill.due > 0 && <small className="block text-xs font-normal text-amber-700">{rupees(bill.due)} due</small>}
                            </span>
                        </li>
                    ))}
                </ul>
            ) : (
                <p className="text-sm text-brand-gray">No bills yet today.</p>
            )}
            {bills.length > 20 && !all && (
                <button type="button" className={`${linkButton} mt-3`} onClick={() => setAll(true)}>Show all {bills.length} bills</button>
            )}
        </Card>
    );
}

export function Week({ live }: { live: OwnerLive }) {
    const week = live.week ?? [];
    return (
        <Card>
            <CardHead title="Last 7 days"><span className="text-sm text-brand-gray">{rupees(week.reduce((sum, d) => sum + d.sales, 0))}</span></CardHead>
            <Bars label="Sales in the last 7 days" labelEvery={1}
                bars={week.map((d, i) => ({
                    label: i === week.length - 1 ? "Today" : dayShort(d.day), value: d.sales, hi: i === week.length - 1,
                    title: `${shortDate(d.day)}: ${rupees(d.sales)} from ${d.bills} bills`,
                }))} />
        </Card>
    );
}

export function BestSellers({ live }: { live: OwnerLive }) {
    const top = live.top ?? [];
    return (
        <Card>
            <CardHead title="Best sellers today" />
            {top.length ? (
                <ol className="space-y-2 text-sm">
                    {top.map((p, i) => (
                        <li key={`${p.name}-${i}`} className="flex items-baseline justify-between gap-3">
                            <span className="min-w-0 truncate text-brand-dark"><span className="text-brand-gray">{i + 1}. </span>{p.name}</span>
                            <span className="shrink-0 text-brand-gray">{quantity(p.qty)} · {rupees(p.sales)}</span>
                        </li>
                    ))}
                </ol>
            ) : (
                <p className="text-sm text-brand-gray">Nothing sold yet today.</p>
            )}
        </Card>
    );
}

export function LowStock({ live }: { live: OwnerLive }) {
    const low = live.lowStock ?? [];
    return (
        <Card>
            <CardHead title="Running low" />
            {low.length ? (
                <ul className="space-y-2 text-sm">
                    {low.map((s, i) => (
                        <li key={`${s.name}-${i}`} className="flex items-center justify-between gap-3">
                            <span className="min-w-0 truncate text-brand-dark">{s.name}</span>
                            <Pill tone={s.left <= 0 ? "bad" : "warn"}>{s.left <= 0 ? "Out of stock" : `${quantity(s.left)} left of ${quantity(s.reorderAt)}`}</Pill>
                        </li>
                    ))}
                </ul>
            ) : (
                <p className="text-sm text-brand-gray">Every product is above its reorder level.</p>
            )}
        </Card>
    );
}

export function FixNow({ live }: { live: OwnerLive }) {
    const fix = live.fixNow ?? { count: 0, items: [] };
    return (
        <Card>
            <CardHead title="Fix now">{fix.count > 0 && <Pill tone="bad">{fix.count}</Pill>}</CardHead>
            {fix.items.length ? (
                <>
                    <ul className="space-y-2.5 text-sm">
                        {fix.items.map((f, i) => (
                            <li key={`${f.kind}-${i}`} className="flex items-center justify-between gap-3">
                                <span className="min-w-0">
                                    <span className="block text-brand-dark">{f.kind}</span>
                                    {f.title && <small className="block text-xs text-brand-gray truncate">{f.title}</small>}
                                </span>
                                <Pill tone={f.now ? "bad" : "warn"}>{f.now ? "Now" : "Soon"}</Pill>
                            </li>
                        ))}
                    </ul>
                    <p className="mt-3 text-xs text-brand-gray">Fixed in the POS at the shop; the details are on the Fix now page there.</p>
                </>
            ) : (
                <p className="text-sm text-brand-gray">Nothing needs fixing.</p>
            )}
        </Card>
    );
}

export function History({ days }: { days: OwnerDay[] }) {
    const [open, setOpen] = useState<string | null>(null);
    const shown = days.slice(-HISTORY_DAYS);
    if (shown.length < 2) return null;
    const day = open ? shown.find((d) => d.day === open) : undefined;
    return (
        <Card>
            <CardHead title={`Last ${shown.length} days`}><span className="text-sm text-brand-gray">{rupees(shown.reduce((sum, d) => sum + d.sales, 0))}</span></CardHead>
            <Bars label={`Sales in the last ${shown.length} days`}
                bars={shown.map((d) => ({
                    label: shortDate(d.day), value: d.sales, hi: d.day === open, onClick: () => setOpen(d.day),
                    title: `${shortDate(d.day)}: ${rupees(d.sales)} from ${d.bills} bills`,
                }))}
                labelEvery={shown.length > 30 ? 7 : undefined} />
            {day ? (
                <div className="mt-4 border-t border-gray-100 pt-4 space-y-3">
                    <h3 className="text-sm font-semibold text-brand-dark">{`${longDate(day.day)}: ${rupees(day.sales)} from ${day.bills} bills`}</h3>
                    {day.hours?.length > 0 && (
                        <Bars label={`Sales by hour on ${shortDate(day.day)}`} height={140}
                            bars={day.hours.map((x) => ({ label: hourName(x.hour), value: x.sales, title: `${hourName(x.hour)}: ${rupees(x.sales)}` }))} />
                    )}
                    {day.top?.length > 0 && (
                        <ol className="space-y-1.5 text-sm">
                            {day.top.map((p, i) => (
                                <li key={`${p.name}-${i}`} className="flex justify-between gap-3">
                                    <span className="truncate text-brand-dark">{p.name}</span>
                                    <span className="text-brand-gray">{rupees(p.sales)}</span>
                                </li>
                            ))}
                        </ol>
                    )}
                </div>
            ) : (
                <p className="mt-3 text-xs text-brand-gray">Tap a day to see its hours and best sellers.</p>
            )}
        </Card>
    );
}
