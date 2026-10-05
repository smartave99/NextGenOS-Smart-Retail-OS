"use client";

import { useCallback, useEffect, useState, type ReactNode } from "react";
import type { SupabaseClient } from "@supabase/supabase-js";
import { calendarDate, clockTime, quantity, rupees, shortDate, weekName } from "@/lib/live-shop/format";
import { compare, readReview, reportsMissing, yearComparison, type Change } from "@/lib/live-shop/review";
import type { OwnerNotSelling, OwnerReview, OwnerRunningOut, OwnerWeek, Shop } from "@/lib/live-shop/types";
import { Card, CardHead, Note, Pill, softButton } from "./ui";

/** The shop PC sends the review once an hour; a look now and then covers a lost connection. */
const LOOK_EVERY_MS = 5 * 60_000;
/** A review not sent for this long means the shop PC has been off or cannot reach the internet. */
const STALE_AFTER_MS = 3 * 60 * 60_000;

/** The review in the database: the report as the shop PC sent it (null when it cannot be read) and when it came. */
interface Report { review: OwnerReview | null; sentAt: Date }

/**
 * Last week, as the Monday review at the shop shows it: sales, bills, the average bill and the profit against the week
 * before and the same week a year before, the products running out and the ones not selling. The shop PC sends it
 * (Smart Retail POS 2.17.0 or later); this only reads it. The rules only suggest: nothing here changes anything.
 */
export default function WeeklyReview({ db, shop, liveDemo }: { db: SupabaseClient; shop: Shop; liveDemo: boolean }) {
    const [report, setReport] = useState<Report | null>(null);
    const [loaded, setLoaded] = useState(false);
    // The project's script is older than this screen: there is no reports table yet.
    const [missing, setMissing] = useState(false);
    const [problem, setProblem] = useState<string | null>(null);

    const load = useCallback(async () => {
        const { data, error, status } = await db
            .from("shop_reports")
            .select("data, sent_at")
            .eq("shop_id", shop.id)
            .eq("kind", "review")
            .maybeSingle();
        if (error) {
            if (reportsMissing(error, status)) {
                setMissing(true);
                setProblem(null);
            } else {
                setProblem(error.message);
            }
        } else {
            setMissing(false);
            setProblem(null);
            setReport(data ? { review: readReview(data.data), sentAt: new Date(data.sent_at as string) } : null);
        }
        setLoaded(true);
    }, [db, shop.id]);

    // A channel of its own: in a project whose script is older the reports are not published, and that must not spoil
    // the live figures' channel.
    useEffect(() => {
        void load();
        const channel = db
            .channel(`shop-reports-${shop.id}`)
            .on("postgres_changes", { event: "*", schema: "public", table: "shop_reports", filter: `shop_id=eq.${shop.id}` }, () => void load())
            .subscribe();
        return () => {
            void db.removeChannel(channel);
        };
    }, [db, shop.id, load]);

    // Without the reports table there is nothing to look for until the owner has run the script and asks again.
    useEffect(() => {
        if (missing) return;
        const timer = setInterval(() => void load(), LOOK_EVERY_MS);
        return () => clearInterval(timer);
    }, [missing, load]);

    return (
        <div className="space-y-5" data-testid="weekly-review">
            {problem && <Note problem>{problem}</Note>}
            {!loaded ? (
                <Card><p role="status" className="text-sm text-brand-gray">Loading last week…</p></Card>
            ) : missing ? (
                <Empty title="The weekly review needs the updated script" onCheck={() => void load()}>
                    Run the latest supabase-owner-view.sql (a file of each Smart Retail POS release) in your Supabase project&apos;s SQL
                    Editor once more; running it again is safe. The shop PC then sends last week&apos;s review within the hour.
                </Empty>
            ) : !report ? (
                <Empty title="No review yet" onCheck={() => void load()}>
                    The shop PC sends last week&apos;s review once an hour, from Smart Retail POS 2.17.0 or later. It shows here soon after that.
                </Empty>
            ) : !report.review ? (
                <Empty title="The latest review could not be read" onCheck={() => void load()}>
                    The shop PC sends it again within the hour. If this stays, update Smart Retail POS on the shop PC and this page to
                    the latest versions.
                </Empty>
            ) : (
                <Review review={report.review} sentAt={report.sentAt} liveDemo={liveDemo} />
            )}
        </div>
    );
}

function Empty({ title, children, onCheck }: { title: string; children: ReactNode; onCheck: () => void }) {
    return (
        <Card>
            <h2 className="text-base font-semibold text-brand-dark">{title}</h2>
            <p className="mt-1 text-sm text-brand-gray">{children}</p>
            <button type="button" className={`${softButton} mt-4`} onClick={onCheck}>Check again</button>
        </Card>
    );
}

function Review({ review, sentAt, liveDemo }: { review: OwnerReview; sentAt: Date; liveDemo: boolean }) {
    const { thisWeek: week, weekBefore: before } = review;
    const stale = Date.now() - sentAt.getTime() > STALE_AFTER_MS;
    return (
        <>
            <div className="flex flex-wrap items-center justify-between gap-x-3 gap-y-2">
                <h2 className="text-lg sm:text-xl font-semibold text-brand-dark">{`Last week, ${weekName(week.from, week.to)}`}</h2>
                {review.reviewedOn ? (
                    <Pill tone="live">{`Reviewed on ${shortDate(review.reviewedOn)}`}</Pill>
                ) : (
                    <Pill tone="warn" title="At the shop, open Monday review in Smart Retail POS and mark the week as reviewed.">Not reviewed yet</Pill>
                )}
            </div>
            {/* The note above the screens already says so when the live figures are the demo's too. */}
            {review.demo && !liveDemo && <Note>These are the demo shop&apos;s figures: the shop PC has not found the POS database.</Note>}
            <div className="grid gap-3 sm:gap-5 grid-cols-1 min-[420px]:grid-cols-2 xl:grid-cols-4">
                <Stat label="Sales" value={rupees(week.sales)} change={compare(week.sales, before.sales)} was={rupees(before.sales)} testId="review-sales" />
                <Stat label="Bills" value={quantity(week.bills)} change={compare(week.bills, before.bills)} was={quantity(before.bills)} testId="review-bills" />
                <Stat label="Average bill" value={rupees(week.averageBill)} change={compare(week.averageBill, before.averageBill)} was={rupees(before.averageBill)} testId="review-average" />
                <Profit week={week} />
            </div>
            <p className="text-sm text-brand-gray" data-testid="review-year">{yearComparison(week, review.yearBefore)}</p>
            <div className="grid gap-5 md:grid-cols-2">
                <RunningOut items={review.runningOut} />
                <NotSelling items={review.notSelling} />
            </div>
            <p className="text-xs text-brand-gray">
                {stale ? `Last sent ${clockTime(sentAt)}, ${calendarDate(sentAt)}. ` : `Sent at ${clockTime(sentAt)}. `}
                The rules only suggest. Your decisions, what the shop is trying and the new products to decide are in Monday review on the shop PC.
            </p>
        </>
    );
}

function Stat({ label, value, change, was, testId }: { label: string; value: string; change: Change; was: string; testId: string }) {
    return (
        <Card>
            <p className="text-sm font-medium text-brand-gray">{label}</p>
            <p className="mt-1 text-2xl sm:text-3xl font-semibold text-brand-dark tracking-tight" data-testid={testId}>{value}</p>
            <Versus change={change} was={was} />
        </Card>
    );
}

/** "+12% vs the week before (₹1,00,000)", green for more and red for less, as Today's card says it. */
function Versus({ change, was }: { change: Change; was: string }) {
    if (change.kind === "none") return <p className="mt-2 text-sm text-brand-gray">Nothing to compare with the week before</p>;
    const colour = change.kind === "up" ? "text-brand-green" : change.kind === "down" ? "text-red-600" : "text-brand-gray";
    const how = change.kind === "same" ? "Same" : `${change.kind === "up" ? "+" : "−"}${change.percent}%`;
    return (
        <p className={`mt-2 text-sm font-semibold ${colour}`}>
            {how}
            <span className="font-normal text-brand-gray">{` vs the week before (${was})`}</span>
        </p>
    );
}

function Profit({ week }: { week: OwnerWeek }) {
    return (
        <Card>
            <p className="text-sm font-medium text-brand-gray">Profit before GST</p>
            <p className="mt-1 text-2xl sm:text-3xl font-semibold text-brand-dark tracking-tight" data-testid="review-profit">
                {week.profit === null ? "–" : rupees(week.profit)}
            </p>
            <p className="mt-2 text-sm text-brand-gray">
                {week.margin === null ? "No purchase prices recorded" : `${Math.round(week.margin * 100)}% margin`}
            </p>
        </Card>
    );
}

function RunningOut({ items }: { items: OwnerRunningOut[] }) {
    return (
        <Card>
            <CardHead title="Running out"><span className="text-xs text-brand-gray">Regular sellers with under a week of stock</span></CardHead>
            {items.length ? (
                <ul className="space-y-2.5 text-sm" data-testid="review-running-out">
                    {items.map((p, i) => (
                        <li key={`${p.name}-${i}`} className="flex items-center justify-between gap-3">
                            <span className="min-w-0">
                                <span className="block truncate text-brand-dark">{p.name}</span>
                                {p.perDay !== null && p.perDay > 0 && <small className="block text-xs text-brand-gray">{`sells about ${quantity(p.perDay)} a day`}</small>}
                            </span>
                            <Pill tone={p.inHand <= 0 ? "bad" : "warn"}>{p.inHand <= 0 ? "Out of stock" : `${quantity(p.inHand)} left`}</Pill>
                        </li>
                    ))}
                </ul>
            ) : (
                <p className="text-sm text-brand-gray">Nothing is running out.</p>
            )}
        </Card>
    );
}

function NotSelling({ items }: { items: OwnerNotSelling[] }) {
    return (
        <Card>
            <CardHead title="Not selling"><span className="text-xs text-brand-gray">In stock, not sold in 8 weeks</span></CardHead>
            {items.length ? (
                <ul className="space-y-2.5 text-sm" data-testid="review-not-selling">
                    {items.map((p, i) => (
                        <li key={`${p.name}-${i}`} className="flex items-center justify-between gap-3">
                            <span className="min-w-0">
                                <span className="block truncate text-brand-dark">{p.name}</span>
                                <small className="block text-xs text-brand-gray">{`${quantity(p.inHand)} in stock`}</small>
                            </span>
                            <span className="shrink-0 text-brand-gray">{`${rupees(p.value)} tied up`}</span>
                        </li>
                    ))}
                </ul>
            ) : (
                <p className="text-sm text-brand-gray">Nothing in stock has gone 8 weeks unsold.</p>
            )}
        </Card>
    );
}
