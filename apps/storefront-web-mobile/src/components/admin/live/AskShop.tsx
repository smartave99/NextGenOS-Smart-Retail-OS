"use client";

import { useCallback, useEffect, useState, type FormEvent, type KeyboardEvent } from "react";
import type { SupabaseClient } from "@supabase/supabase-js";
import { ArrowUp, Loader2 } from "lucide-react";
import { answerCell, isNumberColumn, readAnswer, type Inline } from "@/lib/live-shop/answer";
import { calendarDate, clockTime } from "@/lib/live-shop/format";
import type { OwnerAnswer, Shop, ShopQuestion } from "@/lib/live-shop/types";
import { Card, CardHead, Note, Pill, inputClass, primaryButton } from "./ui";
import { languageList } from "@/lib/shop-facts";

const MAX_LENGTH = 1000;
const SHOWN = 20;
const LOOK_WHILE_WAITING_MS = 15_000;

const EXAMPLES = ["How were sales today?", "Which products sold most this week?", "How much credit is still owed?"];

/** Supabase's answer when the project has not had the 2.2.0 script run yet: no questions table or function. */
const NOT_SET_UP = new Set(["42P01", "42883", "PGRST202", "PGRST205"]);
const SCRIPT_NEEDED = "Questions need the updated script: run supabase-owner-view.sql from Smart Retail POS 2.2.0 in your Supabase project's SQL Editor (running it again is safe).";

function plain(error: { message: string; code?: string }): string {
    return error.code && NOT_SET_UP.has(error.code) ? SCRIPT_NEEDED : error.message;
}

/**
 * The owner asks the shop's own AI, as Ask AI does at the shop: the shop PC takes the question, looks in the POS and
 * sends back the answer. Answers are shown as text only.
 */
export default function AskShop({ db, shop, pcLive }: { db: SupabaseClient; shop: Shop; pcLive: boolean }) {
    const [questions, setQuestions] = useState<ShopQuestion[]>([]);
    const [text, setText] = useState("");
    const [sending, setSending] = useState(false);
    // Why the list could not be read (gone at the next good read), and why a question could not be asked.
    const [loadProblem, setLoadProblem] = useState<string | null>(null);
    const [askProblem, setAskProblem] = useState<string | null>(null);

    const load = useCallback(async () => {
        const { data, error } = await db
            .from("shop_questions")
            .select("id, question, status, answer, asked_at, answered_at")
            .eq("shop_id", shop.id)
            .order("asked_at", { ascending: false })
            .limit(SHOWN);
        if (error) {
            setLoadProblem(plain(error));
            return;
        }
        setLoadProblem(null);
        setQuestions((data ?? []) as ShopQuestion[]);
    }, [db, shop.id]);

    useEffect(() => {
        void load();
        const channel = db
            .channel(`shop-questions-${shop.id}`)
            .on("postgres_changes", { event: "*", schema: "public", table: "shop_questions", filter: `shop_id=eq.${shop.id}` }, () => void load())
            .subscribe();
        return () => {
            void db.removeChannel(channel);
        };
    }, [db, shop.id, load]);

    // While a question waits, a look every few seconds covers a lost connection.
    const waiting = questions.some((q) => q.status === "waiting" || q.status === "working");
    useEffect(() => {
        if (!waiting) return;
        const timer = setInterval(() => void load(), LOOK_WHILE_WAITING_MS);
        return () => clearInterval(timer);
    }, [waiting, load]);

    async function ask(event?: FormEvent) {
        event?.preventDefault();
        const question = text.trim();
        if (!question || sending) return;
        setSending(true);
        setAskProblem(null);
        const { error } = await db.rpc("ask_the_shop", { p_shop: shop.id, p_question: question });
        setSending(false);
        if (error) {
            setAskProblem(plain(error));
            return;
        }
        // Clear the box only if it still holds the question just asked: the owner may have started the next one.
        setText((current) => (current.trim() === question ? "" : current));
        await load();
    }

    function onKey(event: KeyboardEvent<HTMLTextAreaElement>) {
        if (event.key === "Enter" && !event.shiftKey && !event.nativeEvent.isComposing) {
            event.preventDefault();
            void ask();
        }
    }

    return (
        <Card>
            <CardHead title="Ask the shop's AI">
                <Pill tone={pcLive ? "live" : "warn"}>{pcLive ? "Shop PC on" : "Shop PC not sending"}</Pill>
            </CardHead>
            <form onSubmit={ask} className="space-y-3" data-testid="ask-shop">
                <label htmlFor="ask-shop-question" className="sr-only">Your question</label>
                <div className="flex items-end gap-2">
                    <textarea
                        id="ask-shop-question"
                        rows={2}
                        maxLength={MAX_LENGTH}
                        value={text}
                        onChange={(e) => setText(e.target.value)}
                        onKeyDown={onKey}
                        placeholder={`Ask about sales, stock or bills, in ${languageList()}…`}
                        className={`${inputClass} resize-none`}
                    />
                    <button type="submit" className={`${primaryButton} shrink-0 px-3`} disabled={sending || text.trim() === ""} aria-label="Ask">
                        {sending ? <Loader2 className="w-4 h-4 animate-spin" aria-hidden="true" /> : <ArrowUp className="w-4 h-4" aria-hidden="true" />}
                        <span className="hidden sm:inline">Ask</span>
                    </button>
                </div>
                {questions.length === 0 && (
                    <div className="flex flex-wrap gap-2">
                        {EXAMPLES.map((example) => (
                            <button key={example} type="button" onClick={() => setText(example)}
                                className="rounded-full border border-gray-200 px-3 py-1 text-xs text-brand-dark hover:bg-gray-50">
                                {example}
                            </button>
                        ))}
                    </div>
                )}
                {!pcLive && <Note>The shop PC is not sending right now. Questions wait, and are answered when it is back on.</Note>}
                {askProblem && <Note problem>{askProblem}</Note>}
                {loadProblem && <Note problem>{loadProblem}</Note>}
            </form>
            {questions.length > 0 && (
                <ol className="mt-5 space-y-5" aria-label="Questions and answers">
                    {questions.map((q) => <Question key={q.id} question={q} />)}
                </ol>
            )}
        </Card>
    );
}

const STATUS: Record<ShopQuestion["status"], { text: string; tone: "live" | "warn" | "bad" | "plain" }> = {
    waiting: { text: "Waiting for the shop PC", tone: "plain" },
    working: { text: "The shop's AI is answering…", tone: "warn" },
    answered: { text: "Answered", tone: "live" },
    failed: { text: "Not answered", tone: "bad" },
};

function Question({ question }: { question: ShopQuestion }) {
    const status = STATUS[question.status] ?? STATUS.waiting;
    const asked = new Date(question.asked_at);
    return (
        <li className="border-t border-gray-100 pt-4 first:border-t-0 first:pt-0">
            <div className="flex flex-wrap items-start justify-between gap-2">
                <p className="min-w-0 font-medium text-brand-dark whitespace-pre-wrap break-words">{question.question}</p>
                <span className="flex items-center gap-2 text-xs text-brand-gray">
                    <time dateTime={question.asked_at}>{clockTime(asked)}, {calendarDate(asked)}</time>
                    {question.status !== "answered" && <Pill tone={status.tone}>{status.text}</Pill>}
                </span>
            </div>
            {question.answer && <Answer answer={question.answer} failed={question.status === "failed"} />}
        </li>
    );
}

function Answer({ answer, failed }: { answer: OwnerAnswer; failed: boolean }) {
    const rows = answer.rows ?? [];
    const columns = answer.columns ?? [];
    return (
        <div className="mt-2 space-y-3" data-testid="shop-answer">
            <div className={`space-y-2 text-sm leading-relaxed ${failed ? "text-red-700" : "text-brand-dark"}`}>
                {readAnswer(answer.text ?? "").map((block, i) => {
                    if (block.kind === "heading") return <h3 key={i} className="font-semibold pt-1"><Line parts={block.parts} /></h3>;
                    if (block.kind === "paragraph") return <p key={i}><Line parts={block.parts} /></p>;
                    const List = block.ordered ? "ol" : "ul";
                    return (
                        <List key={i} className={`pl-5 space-y-1 ${block.ordered ? "list-decimal" : "list-disc"}`}>
                            {block.items.map((item, j) => <li key={j}><Line parts={item} /></li>)}
                        </List>
                    );
                })}
            </div>
            {columns.length > 0 && (
                <div className="overflow-x-auto rounded-xl border border-gray-100">
                    <table className="min-w-full text-sm">
                        <thead className="bg-gray-50 text-left text-xs uppercase tracking-wider text-brand-gray">
                            <tr>
                                {columns.map((column, i) => (
                                    <th key={i} scope="col" className={`px-3 py-2 font-medium whitespace-nowrap ${isNumberColumn(rows, i) ? "text-right" : ""}`}>{column}</th>
                                ))}
                            </tr>
                        </thead>
                        <tbody className="divide-y divide-gray-100">
                            {rows.map((row, r) => (
                                <tr key={r}>
                                    {columns.map((_, i) => (
                                        <td key={i} className={`px-3 py-2 ${isNumberColumn(rows, i) ? "text-right tabular-nums whitespace-nowrap" : ""}`}>{answerCell(row[i])}</td>
                                    ))}
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            )}
            {(answer.totalRows > rows.length || answer.source) && (
                <p className="text-xs text-brand-gray">
                    {answer.totalRows > rows.length ? `Showing the first ${rows.length} of ${answer.totalRows} rows. ` : ""}
                    {answer.source ?? ""}
                </p>
            )}
        </div>
    );
}

function Line({ parts }: { parts: Inline[] }) {
    return <>{parts.map((part, i) => (part.bold ? <strong key={i}>{part.text}</strong> : <span key={i}>{part.text}</span>))}</>;
}
