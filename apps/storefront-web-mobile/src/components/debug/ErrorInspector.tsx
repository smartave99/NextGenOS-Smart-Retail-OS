"use client";

import { useDebug } from "@/context/DebugContext";

/**
 * A small panel that lists the errors the app caught. It exists for developers: it renders nothing in a production
 * build, so a shop's customers never see technical messages.
 */
export function ErrorInspector() {
    const { errors, clearErrors, isDebugMode, toggleDebugMode } = useDebug();
    if (process.env.NODE_ENV === "production" || !isDebugMode) return null;

    return (
        <aside
            role="log"
            aria-label="Developer error inspector"
            style={{ position: "fixed", right: 12, bottom: 12, zIndex: 2147483000, width: "min(440px, 92vw)", maxHeight: "50vh", overflow: "auto", background: "#1c1c1e", color: "#f5f5f7", borderRadius: 14, padding: 12, font: "12px/1.4 ui-monospace, monospace", boxShadow: "0 12px 32px rgba(0,0,0,.4)" }}
        >
            <div style={{ display: "flex", justifyContent: "space-between", marginBottom: 8 }}>
                <strong>{errors.length} error{errors.length === 1 ? "" : "s"}</strong>
                <span>
                    <button type="button" onClick={clearErrors} style={{ marginRight: 8 }}>Clear</button>
                    <button type="button" onClick={toggleDebugMode}>Close</button>
                </span>
            </div>
            {errors.map((e) => (
                <details key={e.id} style={{ marginBottom: 6 }}>
                    <summary>{new Date(e.timestamp).toLocaleTimeString()} {e.message}</summary>
                    <pre style={{ whiteSpace: "pre-wrap", margin: "4px 0 0" }}>{e.stack}</pre>
                </details>
            ))}
        </aside>
    );
}
