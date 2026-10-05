"use client";

import { useState, useEffect, useCallback } from "react";
import {
    RefreshCw,
    CheckCircle,
    XCircle,
    AlertCircle,
    Database,
    RotateCcw,
    Loader2,
    CloudLightning,
    Wifi,
} from "lucide-react";

// ── Types ────────────────────────────────────────────────────────────────────

interface AccountStatus {
    clientIndex: number;
    label: string;
    reachable: boolean;
    error?: string;
}

interface SyncResult {
    clientIndex: number;
    label: string;
    success: boolean;
    error?: string;
}

interface SyncState {
    redis: AccountStatus[];
    neon: AccountStatus[];
    timestamp: string | null;
    loading: boolean;
    error: string | null;
}

// Known Redis config keys that can be individually re-synced
const REDIS_KEYS = [
    { key: "site_config.json", label: "Site Config" },
    { key: "llmo.json", label: "AI Settings" },
    { key: "llmo_prompts.json", label: "AI Prompts" },
    { key: "site_content_hero.json", label: "Hero Section" },
    { key: "site_content_departments.json", label: "Departments" },
    { key: "site_content_features.json", label: "Features" },
    { key: "site_content_cta.json", label: "CTA Section" },
    { key: "site_content_highlights.json", label: "Highlights" },
    { key: "site_content_contact.json", label: "Contact" },
];

// ── Helper components ────────────────────────────────────────────────────────

function StatusBadge({ reachable, error }: { reachable: boolean; error?: string }) {
    if (reachable) {
        return (
            <span className="inline-flex items-center gap-1.5 px-2.5 py-1 rounded-full bg-green-50 text-green-700 text-xs font-medium border border-green-200">
                <CheckCircle className="w-3 h-3" />
                Online
            </span>
        );
    }
    return (
        <span
            title={error}
            className="inline-flex items-center gap-1.5 px-2.5 py-1 rounded-full bg-red-50 text-red-700 text-xs font-medium border border-red-200 cursor-help"
        >
            <XCircle className="w-3 h-3" />
            Down
        </span>
    );
}

function SyncResultBadge({ result }: { result: SyncResult }) {
    if (result.success) {
        return (
            <span className="inline-flex items-center gap-1 text-green-600 text-xs font-medium">
                <CheckCircle className="w-3.5 h-3.5" /> Synced
            </span>
        );
    }
    return (
        <span title={result.error} className="inline-flex items-center gap-1 text-red-600 text-xs font-medium cursor-help">
            <XCircle className="w-3.5 h-3.5" /> Failed
        </span>
    );
}

// ── Main Component ───────────────────────────────────────────────────────────

export default function DatabaseSyncPanel() {
    const [state, setState] = useState<SyncState>({
        redis: [],
        neon: [],
        timestamp: null,
        loading: false,
        error: null,
    });

    const [resyncing, setResyncing] = useState<string | null>(null);
    const [resyncResults, setResyncResults] = useState<Record<string, SyncResult[]>>({});

    // Fetch status from API
    const fetchStatus = useCallback(async () => {
        setState(s => ({ ...s, loading: true, error: null }));
        try {
            const res = await fetch("/api/admin/db-sync");
            const data = await res.json();
            if (data.success) {
                setState(s => ({
                    ...s,
                    redis: data.redis || [],
                    neon: data.neon || [],
                    timestamp: data.timestamp,
                    loading: false,
                }));
            } else {
                setState(s => ({ ...s, error: data.error || "Failed to fetch status", loading: false }));
            }
        } catch (err) {
            setState(s => ({
                ...s,
                error: err instanceof Error ? err.message : "Network error",
                loading: false,
            }));
        }
    }, []);

    useEffect(() => {
        fetchStatus();
    }, [fetchStatus]);

    // Force re-sync a specific Redis key
    const handleResync = async (key: string) => {
        setResyncing(key);
        setResyncResults(prev => ({ ...prev, [key]: [] }));
        try {
            const res = await fetch("/api/admin/db-sync", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ action: "resync-redis-key", key }),
            });
            const data = await res.json();
            setResyncResults(prev => ({ ...prev, [key]: data.results || [] }));
        } catch (err) {
            console.error("Resync error:", err);
        } finally {
            setResyncing(null);
            // Refresh status after re-sync
            setTimeout(fetchStatus, 500);
        }
    };

    const redisOnline = state.redis.filter(r => r.reachable).length;
    const neonOnline = state.neon.filter(r => r.reachable).length;

    return (
        <div className="space-y-6">
            {/* Header */}
            <div className="flex items-center justify-between">
                <div>
                    <h3 className="text-lg font-semibold text-gray-900 flex items-center gap-2">
                        <Wifi className="w-5 h-5 text-brand-green" />
                        Database Sync Status
                    </h3>
                    {state.timestamp && (
                        <p className="text-xs text-gray-400 mt-0.5">
                            Last checked: {new Date(state.timestamp).toLocaleTimeString()}
                        </p>
                    )}
                </div>
                <button
                    onClick={fetchStatus}
                    disabled={state.loading}
                    className="flex items-center gap-2 px-3 py-1.5 text-sm bg-gray-100 hover:bg-gray-200 rounded-lg transition-colors disabled:opacity-50"
                >
                    <RefreshCw className={`w-4 h-4 ${state.loading ? "animate-spin" : ""}`} />
                    Refresh
                </button>
            </div>

            {state.error && (
                <div className="flex items-center gap-2 p-3 bg-red-50 border border-red-200 rounded-lg text-red-700 text-sm">
                    <AlertCircle className="w-4 h-4 flex-shrink-0" />
                    {state.error}
                </div>
            )}

            {/* ── Upstash Redis Accounts ── */}
            <div className="bg-white border border-gray-200 rounded-xl overflow-hidden shadow-sm">
                <div className="px-4 py-3 bg-gray-50 border-b border-gray-200 flex items-center justify-between">
                    <div className="flex items-center gap-2">
                        <CloudLightning className="w-4 h-4 text-purple-500" />
                        <span className="font-semibold text-gray-800 text-sm">Upstash Redis</span>
                        <span className="text-xs text-gray-500">({redisOnline}/{state.redis.length} online)</span>
                    </div>
                    <span className={`text-xs font-medium px-2 py-0.5 rounded-full ${redisOnline === state.redis.length && state.redis.length > 0
                            ? "bg-green-100 text-green-700"
                            : redisOnline > 0
                                ? "bg-yellow-100 text-yellow-700"
                                : "bg-red-100 text-red-700"
                        }`}>
                        {redisOnline === 0 && state.redis.length > 0 ? "All Down" :
                            redisOnline < state.redis.length ? "Partial" : "Healthy"}
                    </span>
                </div>

                {state.loading && state.redis.length === 0 ? (
                    <div className="p-6 flex justify-center">
                        <Loader2 className="w-5 h-5 animate-spin text-gray-400" />
                    </div>
                ) : state.redis.length === 0 ? (
                    <p className="p-4 text-sm text-gray-500">No Redis accounts configured.</p>
                ) : (
                    <div className="divide-y divide-gray-100">
                        {state.redis.map(account => (
                            <div key={account.clientIndex} className="px-4 py-3 flex items-center justify-between">
                                <div className="flex items-center gap-3">
                                    <div className={`w-2 h-2 rounded-full ${account.reachable ? "bg-green-500" : "bg-red-500"}`} />
                                    <span className="text-sm font-medium text-gray-700">{account.label}</span>
                                </div>
                                <StatusBadge reachable={account.reachable} error={account.error} />
                            </div>
                        ))}
                    </div>
                )}
            </div>

            {/* ── Neon Postgres Accounts ── */}
            <div className="bg-white border border-gray-200 rounded-xl overflow-hidden shadow-sm">
                <div className="px-4 py-3 bg-gray-50 border-b border-gray-200 flex items-center justify-between">
                    <div className="flex items-center gap-2">
                        <Database className="w-4 h-4 text-blue-500" />
                        <span className="font-semibold text-gray-800 text-sm">Neon Postgres</span>
                        <span className="text-xs text-gray-500">({neonOnline}/{state.neon.length} online)</span>
                    </div>
                    <span className={`text-xs font-medium px-2 py-0.5 rounded-full ${neonOnline === state.neon.length && state.neon.length > 0
                            ? "bg-green-100 text-green-700"
                            : neonOnline > 0
                                ? "bg-yellow-100 text-yellow-700"
                                : "bg-red-100 text-red-700"
                        }`}>
                        {neonOnline === 0 && state.neon.length > 0 ? "All Down" :
                            neonOnline < state.neon.length ? "Partial" : "Healthy"}
                    </span>
                </div>

                {state.loading && state.neon.length === 0 ? (
                    <div className="p-6 flex justify-center">
                        <Loader2 className="w-5 h-5 animate-spin text-gray-400" />
                    </div>
                ) : state.neon.length === 0 ? (
                    <p className="p-4 text-sm text-gray-500">No Neon accounts configured.</p>
                ) : (
                    <div className="divide-y divide-gray-100">
                        {state.neon.map(account => (
                            <div key={account.clientIndex} className="px-4 py-3 flex items-center justify-between">
                                <div className="flex items-center gap-3">
                                    <div className={`w-2 h-2 rounded-full ${account.reachable ? "bg-green-500" : "bg-red-500"}`} />
                                    <div>
                                        <span className="text-sm font-medium text-gray-700">{account.label}</span>
                                        {account.clientIndex === 1 && (
                                            <span className="ml-2 text-xs text-gray-400">(primary — handles all writes)</span>
                                        )}
                                    </div>
                                </div>
                                <StatusBadge reachable={account.reachable} error={account.error} />
                            </div>
                        ))}
                    </div>
                )}
            </div>

            {/* ── Redis Key Manual Re-Sync ── */}
            <div className="bg-white border border-gray-200 rounded-xl overflow-hidden shadow-sm">
                <div className="px-4 py-3 bg-gray-50 border-b border-gray-200 flex items-center gap-2">
                    <RotateCcw className="w-4 h-4 text-amber-500" />
                    <span className="font-semibold text-gray-800 text-sm">Manual Redis Re-Sync</span>
                    <span className="text-xs text-gray-400">— force push a config key to all accounts</span>
                </div>
                <div className="divide-y divide-gray-100">
                    {REDIS_KEYS.map(({ key, label }) => {
                        const results = resyncResults[key] || [];
                        const isRunning = resyncing === key;

                        return (
                            <div key={key} className="px-4 py-3 flex items-center justify-between gap-4">
                                <div className="min-w-0">
                                    <p className="text-sm font-medium text-gray-700">{label}</p>
                                    <p className="text-xs text-gray-400 font-mono truncate">{key}</p>
                                </div>
                                <div className="flex items-center gap-3 flex-shrink-0">
                                    {/* Per-account results */}
                                    {results.length > 0 && (
                                        <div className="flex items-center gap-2">
                                            {results.map(r => (
                                                <div key={r.clientIndex} className="flex flex-col items-center">
                                                    <span className="text-xs text-gray-400">{r.label}</span>
                                                    <SyncResultBadge result={r} />
                                                </div>
                                            ))}
                                        </div>
                                    )}
                                    <button
                                        onClick={() => handleResync(key)}
                                        disabled={isRunning || !!resyncing}
                                        className="flex items-center gap-1.5 px-3 py-1.5 text-xs font-medium bg-amber-50 hover:bg-amber-100 text-amber-700 border border-amber-200 rounded-lg transition-colors disabled:opacity-50 disabled:cursor-not-allowed"
                                    >
                                        {isRunning ? (
                                            <Loader2 className="w-3 h-3 animate-spin" />
                                        ) : (
                                            <RotateCcw className="w-3 h-3" />
                                        )}
                                        {isRunning ? "Syncing…" : "Re-Sync"}
                                    </button>
                                </div>
                            </div>
                        );
                    })}
                </div>
            </div>

            {/* Note about Neon */}
            <div className="flex items-start gap-2 p-3 bg-blue-50 border border-blue-200 rounded-lg text-blue-700 text-xs">
                <AlertCircle className="w-4 h-4 flex-shrink-0 mt-0.5" />
                <span>
                    <strong>Neon note:</strong> All write operations (add/edit/delete products, categories, offers, etc.)
                    automatically fan-out to all configured Neon accounts. No manual re-sync needed for Neon —
                    add <code className="bg-blue-100 px-1 rounded">DATABASE_URL_2</code> and <code className="bg-blue-100 px-1 rounded">DATABASE_URL_3</code> in your env to enable.
                </span>
            </div>
        </div>
    );
}

