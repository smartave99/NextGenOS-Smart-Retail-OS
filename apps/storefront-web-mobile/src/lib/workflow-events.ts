import "server-only";

export type WorkflowEventType =
    | "product.created"
    | "product.updated"
    | "product.deleted"
    | "product.imported"
    | "product.requested"
    | "restock.requested";

interface WorkflowEvent<T extends Record<string, unknown>> {
    id: string;
    type: WorkflowEventType;
    occurredAt: string;
    source: "smart-avenue";
    data: T;
}

export async function emitWorkflowEvent<T extends Record<string, unknown>>(
    type: WorkflowEventType,
    data: T
): Promise<boolean> {
    const webhookUrl = process.env.N8N_WEBHOOK_URL;
    if (!webhookUrl) return false;

    const event: WorkflowEvent<T> = {
        id: crypto.randomUUID(),
        type,
        occurredAt: new Date().toISOString(),
        source: "smart-avenue",
        data,
    };

    try {
        const response = await fetch(webhookUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                ...(process.env.N8N_WEBHOOK_SECRET
                    ? { Authorization: `Bearer ${process.env.N8N_WEBHOOK_SECRET}` }
                    : {}),
            },
            body: JSON.stringify(event),
            cache: "no-store",
            signal: AbortSignal.timeout(5_000),
        });

        if (!response.ok) {
            console.warn(`[WorkflowEvents] n8n rejected ${type} with status ${response.status}`);
            return false;
        }
        return true;
    } catch (error) {
        console.warn(`[WorkflowEvents] Failed to deliver ${type}:`, error instanceof Error ? error.message : "unknown error");
        return false;
    }
}
