"use server";

import { fanOutWrite, getWriteClient } from "@/lib/db-manager";
import { requireAdminSession } from "@/lib/auth-server";
import { checkRateLimit } from "@/lib/rate-limit";
import { headers } from "next/headers";
import { z } from "zod";

export interface Subscriber {
    id: string;
    email: string;
    subscribedAt: Date;
    status: "subscribed" | "unsubscribed";
}

export async function subscribeToNewsletter(email: string) {
    try {
        const validatedEmail = z.string().trim().email().max(254).parse(email).toLowerCase();
        const requestHeaders = await headers();
        const identifier = requestHeaders.get("x-forwarded-for")?.split(",")[0]?.trim() ||
            requestHeaders.get("x-real-ip") ||
            "anonymous";
        const rateLimit = await checkRateLimit(identifier, {
            limit: 5,
            windowSeconds: 300,
            prefix: "newsletter",
        });
        if (!rateLimit.allowed) {
            return { success: false, error: "Too many attempts. Please try again later." };
        }

        const existing = await getWriteClient().newsletterSubscriber.findUnique({
            where: { email: validatedEmail }
        });

        if (existing) {
            return { success: false, error: "Email already subscribed" };
        }

        await fanOutWrite(c => c.newsletterSubscriber.create({
            data: { email: validatedEmail, status: "subscribed" }
        }));

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

export async function getNewsletterSubscribers(): Promise<Subscriber[]> {
    try {
        await requireAdminSession();
        const subscribers = await getWriteClient().newsletterSubscriber.findMany({
            orderBy: { subscribedAt: "desc" }
        });
        return subscribers as unknown as Subscriber[];
    } catch (error) {
        console.error("Error fetching newsletter subscribers from Postgres:", error);
        return [];
    }
}

export async function deleteSubscriber(id: string) {
    try {
        await requireAdminSession();
        await fanOutWrite(c => c.newsletterSubscriber.delete({ where: { id } }));
        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}
