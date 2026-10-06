"use server";

import { fanOutWrite, getWriteClient } from "@/lib/db-manager";
import { revalidatePath, revalidateTag, unstable_cache } from "next/cache";
import { requireAdminSession } from "@/lib/auth-server";
import { SHOP_NAME } from "@/lib/shop-name";
import { sanitizePageHtml } from "@/lib/sanitize-html";

export interface PageContent {
    title: string;
    content: string;
    lastUpdated: string;
}

// Starting texts only. The shop owner replaces them in Admin > Content with legal text from their own adviser: the law of each
// country differs, and these cannot know yours.
const DEFAULT_PAGES: Record<string, PageContent> = {
    privacy: {
        title: "Privacy Policy",
        content: `<h2>1. Introduction</h2>
<p>At ${SHOP_NAME}, we take your privacy seriously. This Privacy Policy explains how we collect, use and protect your information when you visit our store or use our website.</p>

<h2>2. Information We Collect</h2>
<p>We may collect information that identifies or relates to you:</p>
<ul>
<li>Contact details such as your name, address, email address or phone number, when you give them to us.</li>
<li>Records of products you bought or looked at.</li>
<li>Technical information about how you use our website.</li>
</ul>

<h2>3. How We Use Your Information</h2>
<p>We use the information we collect to:</p>
<ul>
<li>Complete and support your purchases.</li>
<li>Improve our products and services.</li>
<li>Send you offers and updates, only with your consent.</li>
<li>Keep our systems secure.</li>
</ul>

<h2>4. Sharing Your Information</h2>
<p>We do not sell your personal information. We may share limited information with service providers that help us run our website, communications, security and stores.</p>

<h2>5. Your Choices</h2>
<p>You can ask us to show, correct or delete the information we hold about you. Contact us using the details on this website.</p>`,
        lastUpdated: "",
    },
    terms: {
        title: "Terms of Service",
        content: `<h2>1. Acceptance of Terms</h2>
<p>By using the ${SHOP_NAME} website and store services, you agree to these Terms of Service and the laws that apply.</p>

<h2>2. Use of Services</h2>
<p>You agree to use our services only for lawful purposes.</p>

<h2>3. Product Information and Pricing</h2>
<p>We work to keep product descriptions and prices accurate, but we do not promise that they are free of errors. We may correct errors and change information at any time.</p>

<h2>4. Limitation of Liability</h2>
<p>To the extent the law allows, ${SHOP_NAME} is not liable for indirect or consequential damages resulting from your use of, or inability to use, our services.</p>

<h2>5. Governing Law</h2>
<p>These terms are governed by the laws that apply where ${SHOP_NAME} operates.</p>`,
        lastUpdated: "",
    },
};

/**
 * Internal fetcher for page content.
 */
async function _fetchPageContent(pageId: string): Promise<PageContent> {
    try {
        const page = await getWriteClient().page.findUnique({
            where: { id: pageId }
        });

        if (!page) {
            const defaultContent = DEFAULT_PAGES[pageId];
            if (defaultContent) {
                await fanOutWrite(c => c.page.create({
                    data: {
                        id: pageId,
                        title: defaultContent.title,
                        content: defaultContent.content,
                        lastUpdated: defaultContent.lastUpdated,
                    }
                }));
                return defaultContent;
            }
            return { title: "", content: "", lastUpdated: "" };
        }

        return {
            title: page.title,
            content: sanitizePageHtml(page.content),
            lastUpdated: page.lastUpdated,
        };
    } catch (error) {
        console.error(`Error fetching page content for ${pageId}:`, error);
        return DEFAULT_PAGES[pageId] || { title: "", content: "", lastUpdated: "" };
    }
}

/**
 * Fetches page content with caching.
 */
export async function getPageContent(pageId: string): Promise<PageContent> {
    const cachedFetch = unstable_cache(
        () => _fetchPageContent(pageId),
        [`page-content-${pageId}`],
        { revalidate: 300, tags: ["pages", `page-${pageId}`] }
    );
    return cachedFetch();
}

/**
 * Updates page content in Firestore.
 */
export async function updatePageContent(
    pageId: string,
    data: PageContent
): Promise<{ success: boolean; error?: string }> {
    try {
        await requireAdminSession();
        const content = sanitizePageHtml(data.content);
        await fanOutWrite(c => c.page.upsert({
            where: { id: pageId },
            update: {
                title: data.title,
                content,
                lastUpdated: data.lastUpdated,
            },
            create: {
                id: pageId,
                title: data.title,
                content,
                lastUpdated: data.lastUpdated,
            }
        }));

        revalidatePath(`/${pageId}`);
        revalidatePath(`/admin/content/${pageId}`);
        revalidateTag("pages");
        revalidateTag(`page-${pageId}`);

        return { success: true };
    } catch (error) {
        console.error(`Error updating page content for ${pageId}:`, error);
        return {
            success: false,
            error: error instanceof Error ? error.message : "Failed to update page content",
        };
    }
}
