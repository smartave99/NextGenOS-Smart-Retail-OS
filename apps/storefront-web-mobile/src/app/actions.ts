"use server";
// Force re-compile


import { getSearchCache, CacheKeys } from "@/lib/search-cache";
import { revalidatePath, revalidateTag, unstable_cache } from "next/cache";
import { fanOutWrite, getWriteClient } from "@/lib/db-manager";
import { requireAdminSession } from "@/lib/auth-server";
import { emitWorkflowEvent } from "@/lib/workflow-events";
import { allowServerAction } from "@/lib/server-action-rate-limit";
import { normalizeBarcode } from "@/lib/barcode";
import {
    invalidateCatalogSearchState,
    syncProductSearchIndex,
    syncProductsSearchIndex,
} from "@/lib/product-indexing";

// ==================== OFFERS ====================

export interface Offer {
    id: string;
    title: string;
    discount: string;
    description: string;
    createdAt: Date;
}

export async function createOffer(title: string, discount: string, description: string) {
    try {
        await requireAdminSession("offers");
        const { primaryResult: doc } = await fanOutWrite(c => c.offer.create({
            data: { title, discount, description }
        }));

        revalidatePath("/offers");
        revalidatePath("/admin/content/offers");
        revalidatePath("/admin");
        revalidateTag("offers");

        return { success: true, id: doc.id };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

async function _fetchOffers(): Promise<Offer[]> {
    try {
        const offers = await getWriteClient().offer.findMany({
            orderBy: { createdAt: "desc" }
        });
        return offers as unknown as Offer[];
    } catch (error) {
        console.error("Error fetching offers:", error);
        return [];
    }
}

export const getOffers = unstable_cache(_fetchOffers, ["offers"], {
    revalidate: 300,
    tags: ["offers"],
});

async function _fetchOffer(id: string): Promise<Offer | null> {
    try {
        const offer = await getWriteClient().offer.findUnique({
            where: { id }
        });
        return offer as unknown as Offer;
    } catch (error) {
        console.error("Error fetching offer:", error);
        return null;
    }
}

export const getOffer = async (id: string) => {
    const cachedFetch = unstable_cache(
        () => _fetchOffer(id),
        [`offer-${id}`],
        { revalidate: 300, tags: ["offers", `offer-${id}`] }
    );
    return cachedFetch();
}

export async function deleteOffer(id: string) {
    try {
        await requireAdminSession("offers");
        await fanOutWrite(c => c.offer.delete({ where: { id } }));

        revalidatePath("/offers");
        revalidatePath("/admin/content/offers");
        revalidatePath("/admin");
        revalidateTag("offers");

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

export async function updateOffer(id: string, data: Partial<Omit<Offer, 'id' | 'createdAt'>>) {
    try {
        await requireAdminSession("offers");
        const updateData = { ...data };

        await fanOutWrite(c => c.offer.update({ where: { id }, data: updateData }));

        revalidatePath("/offers");
        revalidatePath("/admin/content/offers");
        revalidatePath("/admin");
        revalidateTag("offers");

        return { success: true };
    } catch (error: unknown) {
        console.error("Prisma updateOffer error:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

// ==================== DASHBOARD STATS ====================

export async function getDashboardStats() {
    await requireAdminSession();
    try {
        const [offersCount, productsCount, categoriesCount] = await Promise.all([
            getWriteClient().offer.count(),
            getWriteClient().product.count(),
            getWriteClient().category.count(),
        ]);
        return {
            offersCount,
            productsCount,
            categoriesCount,
        };
    } catch (error) {
        console.error("Error fetching dashboard stats:", error);
        return { offersCount: 0, productsCount: 0, categoriesCount: 0 };
    }
}

// ==================== SITE CONTENT ====================

export interface HeroContent {
    title: string;
    subtitle: string;
    tagline: string;
    ctaPrimary: string;
    ctaSecondary: string;
    learnMoreLink?: string;
    backgroundImage: string;
}

export interface DepartmentContent {
    id: string;
    title: string;
    description: string;
    icon: string;
    image: string;
    link?: string;
}

export interface ContactContent {
    address: string;
    phone: string;
    email: string;
    mapEmbed: string;
    storeHours: string;
}

export interface FeaturesContent {
    title: string;
    subtitle: string;
    items: {
        title: string;
        desc: string;
        icon: string;
    }[];
    description?: string;
}

export interface CTAContent {
    title: string;
    text: string;
    ctaPrimary: string;
    ctaLink: string;
    ctaSecondary: string;
    backgroundImage: string;
    images?: string[];
}

export interface HighlightsContent {
    title: string;
    subtitle: string;
    description: string;
    viewAllLabel?: string;
    exploreLabel?: string;
}

export interface ProductsPageContent {
    heroTitle: string;
    heroSubtitle: string;
    heroImage: string;
    // Filter visibility
    showSearch?: boolean;
    showSort?: boolean;
    showPriceRange?: boolean;
    showCategories?: boolean;
    showAvailability?: boolean;
}

export interface ProductDetailPageContent {
    availabilityText: string;
    availabilityBadge: string;
    callToActionNumber: string;
    visitStoreLink: string;
    authenticityTitle: string;
    authenticityText: string;
    storeLocationTitle: string;
    storeLocationText: string;
    storeHoursText: string;
}

export interface OffersPageContent {
    heroTitle: string;
    heroSubtitle: string;
    heroImage: string;
    catalogueUrl?: string;
    catalogueTitle?: string;
    catalogueSubtitle?: string;
}

export interface DepartmentsPageContent {
    heroTitle: string;
    heroSubtitle: string;
    heroImage: string;
    heroLabel?: string;
}

export interface AboutPageContent {
    heroTitle: string;
    heroSubtitle: string;
    heroImage: string;
    visionTitle: string;
    visionText1: string;
    visionText2: string;
    visionImage: string;
    heroLabel?: string;
    visionLabel?: string;
    statsCustomersLabel?: string;
    statsSatisfactionLabel?: string;
    contactTitle?: string;
    contactSubtitle?: string;
    statsCustomers: string;
    statsSatisfaction: string;
    valuesTitle: string;
    valuesSubtitle: string;
    values: {
        title: string;
        desc: string;
        icon: string; // Icon name matching Lucide icons
        color?: string; // Tailwind class
    }[];
}

// Get site content by section
import { getBlobJson, updateBlobJson } from "./actions/blob-json";

async function _fetchSiteContent<T>(section: string): Promise<T | null> {
    try {
        const _filename = `site_content_${section}.json`;
        const data = await getBlobJson<T | null>(_filename, null);
        return data;
    } catch (error) {
        console.error(`Error fetching ${section} content from Blob:`, error);
        return null;
    }
}

export async function getSiteContent<T>(section: string): Promise<T | null> {
    const cachedFetch = unstable_cache(
        () => _fetchSiteContent<T>(section),
        [`site-content-${section}`],
        { revalidate: 300, tags: ["site-content", `site-content-${section}`] }
    );
    return cachedFetch();
}

// Update site content by section
export async function updateSiteContent(section: string, data: Record<string, unknown>) {
    try {
        await requireAdminSession();
        const _filename = `site_content_${section}.json`;

        const newData = {
            ...data,
            updatedAt: new Date().toISOString()
        };

        const result = await updateBlobJson(_filename, newData);

        if (!result.success) {
            throw new Error(result.error || "Failed to save to Blob");
        }

        revalidatePath("/", "layout");
        revalidateTag("site-content");
        revalidateTag(`site-content-${section}`);

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

// Get all departments
async function _fetchDepartments(): Promise<DepartmentContent[]> {
    try {
        const data = await getBlobJson<{ items: DepartmentContent[] }>("site_content_departments.json", { items: [] });
        return data.items || [];
    } catch (error) {
        console.error("Error fetching departments from Blob:", error);
        return [];
    }
}

export const getDepartments = unstable_cache(_fetchDepartments, ["departments"], {
    revalidate: 300,
    tags: ["departments", "site-content"],
});

// Update departments
export async function updateDepartments(departments: DepartmentContent[]) {
    await requireAdminSession("departments");
    try {
        const result = await updateBlobJson("site_content_departments.json", {
            items: departments,
            updatedAt: new Date().toISOString()
        });

        if (!result.success) {
            throw new Error(result.error || "Failed to save to Blob");
        }

        revalidatePath("/");
        revalidateTag("departments");
        revalidateTag("site-content");

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

// ==================== STAFF MANAGEMENT ====================

export interface StaffMember {
    id: string;
    email: string;
    name: string;
    role: "admin" | "manager" | "editor";
    permissions: string[];
    createdAt: Date;
}

async function _fetchStaffMembers(): Promise<StaffMember[]> {
    try {
        const staff = await getWriteClient().staff.findMany({
            orderBy: { createdAt: "desc" }
        });
        return staff as unknown as StaffMember[];
    } catch (error) {
        console.error("Error fetching staff:", error);
        return [];
    }
}

const getCachedStaffMembers = unstable_cache(_fetchStaffMembers, ["staff"], {
    revalidate: 300,
    tags: ["staff"],
});

export async function getStaffMembers(): Promise<StaffMember[]> {
    await requireAdminSession("staff");
    return getCachedStaffMembers();
}

export async function createStaffMember(email: string, name: string, role: string, permissions: string[]) {
    try {
        await requireAdminSession("staff");
        const { primaryResult: staff } = await fanOutWrite(c => c.staff.create({
            data: { email: email.trim().toLowerCase(), name, role, permissions }
        }));

        revalidatePath("/admin/staff");
        revalidateTag("staff");

        return { success: true, id: staff.id };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

export async function updateStaffMember(id: string, data: Partial<StaffMember>) {
    try {
        await requireAdminSession("staff");
        const updateData: Prisma.StaffUpdateInput = { ...data };
        delete updateData.id;
        delete updateData.createdAt;

        await fanOutWrite(c => c.staff.update({ where: { id }, data: updateData }));

        revalidatePath("/admin/staff");
        revalidateTag("staff");

        return { success: true };
    } catch (error: unknown) {
        console.error("Prisma updateStaffMember error:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

export async function deleteStaffMember(id: string) {
    try {
        await requireAdminSession("staff");
        await fanOutWrite(c => c.staff.delete({ where: { id } }));

        revalidatePath("/admin/staff");
        revalidateTag("staff");

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

// Get staff data (role and permissions) by email
export async function getStaffData(email: string) {
    try {
        const identity = await requireAdminSession();
        if (identity.email !== email.toLowerCase() && !identity.permissions.includes("*")) {
            return null;
        }
        // The owner named in OWNER_ADMIN_EMAILS (verified e-mail only, see requireAdminSession)
        if (isOwnerAdmin(email)) {
            return {
                role: "Admin",
                permissions: ["*"] // All permissions
            };
        }

        const staff = await getWriteClient().staff.findUnique({
            where: { email }
        });

        if (staff) {
            return {
                role: staff.role ? staff.role.charAt(0).toUpperCase() + staff.role.slice(1) : "Staff",
                permissions: staff.permissions || []
            };
        }
        return null;
    } catch (error) {
        console.error("Error fetching staff data:", error);
        return null;
    }
}

// Keep for compatibility or replace usages
export async function getStaffRole(email: string): Promise<string | null> {
    const data = await getStaffData(email);
    return data ? data.role : null;
}

// ==================== CATEGORIES ====================

export interface Category {
    id: string;
    name: string;
    slug: string;
    parentId: string | null;
    order: number;
    createdAt: Date;
}

async function _fetchCategories(): Promise<Category[]> {
    try {
        const categories = await getWriteClient().category.findMany({
            orderBy: { order: "asc" }
        });
        return categories as Category[];
    } catch (error) {
        console.error("Error fetching categories:", error);
        return [];
    }
}

export const getCategories = unstable_cache(_fetchCategories, ["categories"], {
    revalidate: 300,
    tags: ["categories"],
});

export async function createCategory(name: string, parentId: string | null = null) {
    try {
        await requireAdminSession("categories");
        const slug = name.toLowerCase().replace(/\s+/g, "-").replace(/[^a-z0-9-]/g, "");
        const count = await getWriteClient().category.count();
        const order = count;

        const { primaryResult: doc } = await fanOutWrite(c => c.category.create({
            data: { name, slug, parentId, order }
        }));

        revalidatePath("/products");
        revalidatePath("/admin/content/categories");
        revalidateTag("categories");

        return { success: true, id: doc.id };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().delete(CacheKeys.categories());
    }
}

export async function updateCategory(id: string, data: Partial<Category>) {
    try {
        await requireAdminSession("categories");
        // eslint-disable-next-line @typescript-eslint/no-unused-vars
        const { id: _, createdAt: __, parentId, ...rest } = data;
        const updateData: Prisma.CategoryUpdateInput = {
            ...rest,
            parent: parentId === undefined ? undefined :
                (parentId === null || parentId === "" ? { disconnect: true } : { connect: { id: parentId } })
        };

        await fanOutWrite(c => c.category.update({ where: { id }, data: updateData }));

        revalidatePath("/products");
        revalidatePath("/admin/content/categories");
        revalidateTag("categories");

        return { success: true };
    } catch (error: unknown) {
        console.error("Prisma updateCategory error:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().delete(CacheKeys.categories());
    }
}

export async function deleteCategory(id: string) {
    try {
        await requireAdminSession("categories");
        await fanOutWrite(c => c.category.delete({ where: { id } }));

        revalidatePath("/products");
        revalidatePath("/admin/content/categories");
        revalidateTag("categories");

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().delete(CacheKeys.categories());
    }
}

// ==================== PRODUCTS ====================

export interface Product {
    id: string;
    name: string;
    description: string;
    price: number;
    originalPrice?: number;
    categoryId: string;
    subcategoryId?: string;
    imageUrl: string;
    images: string[];
    videoUrl?: string | null;
    available: boolean;
    featured: boolean;
    offerId?: string;
    tags: string[];
    averageRating?: number;
    reviewCount?: number;
    createdAt: Date;
    updatedAt?: Date;
    highlights?: string[];
    specifications?: { key: string; value: string }[];
    stockLevel?: number;
    barcode?: string | null;
}

import { Prisma } from "@prisma/client";
import { isOwnerAdmin } from "@/lib/owner-admins";

async function _fetchProducts(
    categoryId?: string,
    available?: boolean,
    limitCount: number = 20,
    startAfterId?: string,
    subcategoryId?: string
): Promise<Product[]> {
    try {
        const where: Prisma.ProductWhereInput = {};
        if (categoryId) where.categoryId = categoryId;
        if (subcategoryId) where.subcategoryId = subcategoryId;
        if (available !== undefined) where.available = available;

        let cursorDetails = {};
        let skipAmount = 0;

        if (startAfterId) {
            cursorDetails = { cursor: { id: startAfterId } };
            skipAmount = 1;
        }

        const products = await getWriteClient().product.findMany({
            where,
            orderBy: { createdAt: "desc" },
            take: limitCount,
            ...cursorDetails,
            skip: skipAmount
        });

        return products as unknown as Product[];
    } catch (error) {
        console.error("Error fetching products from Postgres:", error);
        return [];
    }
}

export async function getProducts(
    categoryId?: string,
    available: boolean | "all" = true, // Default to true (storefront), "all" to bypass
    limitCount: number = 20,
    startAfterId?: string,
    subcategoryId?: string
): Promise<Product[]> {
    const filterValue = available === "all" ? undefined : available;

    // Paginated queries cannot be cached because cursors are dynamic
    if (startAfterId) {
        return _fetchProducts(categoryId, filterValue, limitCount, startAfterId, subcategoryId);
    }

    const cacheKey = `products-${categoryId || "all"}-${available}-${limitCount}-${subcategoryId || "none"}`;

    const cachedFetch = unstable_cache(
        () => _fetchProducts(categoryId, filterValue, limitCount, undefined, subcategoryId),
        [cacheKey],
        { revalidate: 300, tags: ["products"] }
    );

    return cachedFetch();
}

/**
 * Get products matching a complex set of filters using DB-level filtering via Prisma.
 * This is scalable to any number of products — no in-memory limit.
 */
export async function getFilteredProducts(filters: {
    search?: string;
    category?: string | string[];
    subcategory?: string;
    minPrice?: number;
    maxPrice?: number;
    rating?: number;
    available?: boolean | "all";
    sort?: string;
}): Promise<Product[]> {
    // Build the Prisma where clause from the filter parameters
    const where: Prisma.ProductWhereInput = {};

    // 1. Availability — default to true (Storefront behavior)
    if (filters.available === undefined) {
        where.available = true;
    } else if (filters.available !== "all") {
        where.available = filters.available;
    }

    // 2. Category / Subcategory
    if (filters.subcategory) {
        where.subcategoryId = filters.subcategory;
    } else if (filters.category) {
        const cats = Array.isArray(filters.category) ? filters.category : [filters.category];
        if (cats.length > 0) {
            // A selected ID might be a parent category OR a subcategory.
            // Match products where EITHER field matches one of the selected IDs.
            where.AND = where.AND || [];
            (where.AND as Prisma.ProductWhereInput[]).push({
                OR: [
                    { categoryId: { in: cats } },
                    { subcategoryId: { in: cats } }
                ]
            });
        }
    }

    // 3. Price range
    if ((filters.minPrice !== undefined && !isNaN(filters.minPrice)) ||
        (filters.maxPrice !== undefined && !isNaN(filters.maxPrice))) {
        where.price = {};
        if (filters.minPrice !== undefined && !isNaN(filters.minPrice)) {
            where.price.gte = filters.minPrice;
        }
        if (filters.maxPrice !== undefined && !isNaN(filters.maxPrice)) {
            where.price.lte = filters.maxPrice;
        }
    }

    if (filters.rating !== undefined && !isNaN(filters.rating)) {
        where.averageRating = { gte: filters.rating };
    }

    // 4. Text search — Postgres ILIKE (case-insensitive contains) + word-level tag matching
    if (filters.search && filters.search.trim()) {
        const searchTerm = filters.search.trim();
        const searchWords = searchTerm.toLowerCase().split(/\s+/).filter(Boolean);
        where.OR = [
            { name: { contains: searchTerm, mode: "insensitive" } },
            { description: { contains: searchTerm, mode: "insensitive" } },
            { barcode: { contains: searchTerm, mode: "insensitive" } },
            // hasSome matches any word in the tags array (partial word match via splitting)
            ...(searchWords.length > 0 ? [{ tags: { hasSome: searchWords } }] : []),
        ];
    }

    // 5. Sorting — map to Prisma orderBy
    // When a search is active and the user hasn't changed sort from the default,
    // automatically use a relevance-proxy order (featured → top-rated → newest).
    const hasSearch = !!(filters.search && filters.search.trim());
    const effectiveSort = hasSearch && (!filters.sort || filters.sort === "newest")
        ? "relevance"
        : filters.sort;

    let orderBy: Prisma.ProductOrderByWithRelationInput | Prisma.ProductOrderByWithRelationInput[];
    switch (effectiveSort) {
        case "price_asc":
            orderBy = { price: "asc" };
            break;
        case "price_desc":
            orderBy = { price: "desc" };
            break;
        case "rating":
            orderBy = { averageRating: "desc" };
            break;
        case "featured":
            // Featured products first, then by newest
            orderBy = [{ featured: "desc" }, { createdAt: "desc" }];
            break;
        case "relevance":
            // Best proxy for search relevance: featured → highest rated → newest
            orderBy = [{ featured: "desc" }, { averageRating: "desc" }, { createdAt: "desc" }];
            break;
        case "newest":
        default:
            orderBy = { createdAt: "desc" };
            break;
    }

    try {
        // Keep storefront responses bounded. Ordinary browsing is cursor-
        // paginated in 20-item batches; complex filters use a larger capped
        // result set because those queries are not cursor-based.
        const hasComplexFilters = Boolean(
            hasSearch ||
            filters.minPrice !== undefined ||
            filters.maxPrice !== undefined ||
            filters.rating !== undefined ||
            (filters.sort && filters.sort !== "newest")
        );
        const products = await getWriteClient().product.findMany({
            where,
            orderBy,
            take: hasComplexFilters ? 60 : 20,
        });
        return products as unknown as Product[];
    } catch (error) {
        console.error("Error in getFilteredProducts:", error);
        return [];
    }
}

/**
 * Get ALL products for export (no pagination/limit)
 * Warning: heavy operation, use sparingly
 */
export async function getAllProductsForExport(): Promise<Product[]> {
    try {
        await requireAdminSession("products");
        const products = await getWriteClient().product.findMany({
            orderBy: { createdAt: "desc" }
        });
        return products as unknown as Product[];
    } catch (error) {
        console.error("Error fetching all products for export from Postgres:", error);
        return [];
    }
}


/**
 * Search products by text query with in-memory filtering
 * Optimized for speed by caching products and filtering client-side
 */
export async function searchProducts(
    searchQuery: string,
    categoryId?: string,
    subcategoryId?: string,
    available: boolean | "all" = true // Default to true
): Promise<Product[]> {
    // Fetch a large batch then score in-memory — fast because it uses the cache
    const allProducts = await getProducts(undefined, "all", 2000);

    const searchLower = searchQuery.toLowerCase().trim();
    const searchWords = searchLower.split(/\s+/).filter(Boolean);

    // 1. Filter by Availability
    let filtered = allProducts;
    if (available !== "all") {
        filtered = filtered.filter(p => p.available === available);
    }

    // 2. Relevance-scored text search
    if (searchLower) {
        const scored = filtered
            .map(p => {
                const nameLower = p.name.toLowerCase();
                const descLower = (p.description || "").toLowerCase();
                const tagsLower = (p.tags || []).map(t => t.toLowerCase());
                let score = 0;

                // Name scoring (highest weight)
                if (nameLower === searchLower)                            score += 100; // exact match
                else if (nameLower.startsWith(searchLower))               score += 80;  // prefix match
                else if (nameLower.includes(searchLower))                 score += 60;  // substring match
                else if (searchWords.some(w => nameLower.includes(w)))   score += 40;  // word match

                // Tag scoring (medium weight)
                if (tagsLower.some(t => t === searchLower))              score += 50;  // exact tag
                else if (tagsLower.some(t => t.includes(searchLower)))   score += 35;  // tag contains term
                else if (tagsLower.some(t =>
                    searchWords.some(w => t.includes(w))))                score += 20;  // tag contains word

                // Description scoring (lowest weight)
                if (descLower.includes(searchLower))                     score += 15;
                else if (searchWords.some(w => descLower.includes(w)))   score += 8;

                // Barcode exact match (extremely high weight)
                const barcodeLower = (p.barcode || "").toLowerCase();
                if (barcodeLower && barcodeLower === searchLower) score += 200;
                else if (barcodeLower && barcodeLower.includes(searchLower)) score += 50;

                // Featured products get a small boost within the same score tier
                if (p.featured) score += 5;

                return { product: p, score };
            })
            .filter(({ score }) => score > 0)
            .sort((a, b) => b.score - a.score)
            .map(({ product }) => product);

        filtered = scored;
    }

    // 3. Category Filter
    if (subcategoryId) {
        filtered = filtered.filter(p => p.subcategoryId === subcategoryId);
    } else if (categoryId) {
        filtered = filtered.filter(p => p.categoryId === categoryId);
    }

    return filtered;
}

async function _fetchProduct(id: string): Promise<Product | null> {
    try {
        const product = await getWriteClient().product.findUnique({
            where: { id }
        });
        if (product) {
            return {
                ...product,
                stockLevel: product.available ? (product.stockLevel ?? 10) : 0,
            } as unknown as Product;
        }
        return null;
    } catch (error) {
        console.error("Error fetching product from Postgres:", error);
        return null;
    }
}

export async function getProduct(id: string): Promise<Product | null> {
    const cachedFetch = unstable_cache(
        () => _fetchProduct(id),
        [`product-${id}`],
        { revalidate: 300, tags: ["products", `product-${id}`] }
    );
    return cachedFetch();
}


/**
 * Resolve a product by barcode without involving an LLM. The fallback
 * comparison ignores spaces and hyphens so older manually formatted values
 * still match the raw value returned by a camera scanner.
 */
export async function getProductByBarcode(
    barcode: string,
    available: boolean | "all" = true
): Promise<Product | null> {
    const normalized = normalizeBarcode(barcode);
    if (normalized.length < 4 || normalized.length > 64) return null;

    try {
        const availabilityFilter = available === "all" ? {} : { available };
        const exactProduct = await getWriteClient().product.findFirst({
            where: {
                ...availabilityFilter,
                barcode: { equals: normalized, mode: "insensitive" },
            },
        });
        if (exactProduct) return exactProduct as unknown as Product;

        const candidates = await getWriteClient().product.findMany({
            where: {
                ...availabilityFilter,
                barcode: { not: null },
            },
            orderBy: { updatedAt: "desc" },
            take: 5000,
        });

        return (candidates.find(product =>
            product.barcode && normalizeBarcode(product.barcode) === normalized
        ) as unknown as Product | undefined) || null;
    } catch (error) {
        console.error("Error looking up product barcode:", error);
        return null;
    }
}

// ==================== REVIEWS ====================

// Add new product
export async function createProduct(data: Record<string, unknown>) {
    try {
        await requireAdminSession("products");
        // Strip out any empty/undefined relations to null instead so Prisma accepts them
        const cleanedData = { ...data };
        if (cleanedData.subcategoryId === undefined || cleanedData.subcategoryId === "") cleanedData.subcategoryId = null;
        if (cleanedData.offerId === undefined || cleanedData.offerId === "") cleanedData.offerId = null;
        if (cleanedData.videoUrl === undefined || cleanedData.videoUrl === "") cleanedData.videoUrl = null;
        if (cleanedData.originalPrice === undefined || cleanedData.originalPrice === "") cleanedData.originalPrice = null;
        if (typeof cleanedData.barcode === "string") {
            cleanedData.barcode = normalizeBarcode(cleanedData.barcode) || null;
        }

        const { primaryResult: doc } = await fanOutWrite(c => c.product.create({
            data: { ...cleanedData as Prisma.ProductUncheckedCreateInput }
        }));

        revalidatePath("/");
        revalidatePath("/products");
        revalidatePath("/admin/content/products");
        revalidateTag("products");

        let indexingReady = false;
        try {
            const indexResult = await syncProductSearchIndex(doc);
            indexingReady = indexResult.success;
        } catch (error) {
            console.warn("[RAG] Immediate indexing failed for new product:", error);
        }
        // Publish a new cache revision only after the new index is ready. This
        // prevents a concurrent no-result response from being cached under the
        // same revision that is meant to expose the newly indexed product.
        await invalidateCatalogSearchState();

        await emitWorkflowEvent("product.created", {
            productId: doc.id,
            name: doc.name,
            available: doc.available,
            stockLevel: doc.stockLevel,
        });

        return { success: true, id: doc.id, indexingReady };
    } catch (error: unknown) {
        console.error("Prisma createProduct error:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().clearPrefix("products");
        getSearchCache().clearPrefix("query");
    }
}

// Update product
export async function updateProduct(id: string, data: Record<string, unknown>) {
    try {
        await requireAdminSession("products");
        // Turn undefined / empty strings into null for nullable fields so they are properly unset
        const cleanedData = { ...data };
        delete cleanedData.id; // ensure ID is never updated
        if (cleanedData.subcategoryId === undefined || cleanedData.subcategoryId === "") cleanedData.subcategoryId = null;
        if (cleanedData.offerId === undefined || cleanedData.offerId === "") cleanedData.offerId = null;
        if (cleanedData.videoUrl === undefined || cleanedData.videoUrl === "") cleanedData.videoUrl = null;
        if (cleanedData.originalPrice === undefined || cleanedData.originalPrice === "") cleanedData.originalPrice = null;
        if (typeof cleanedData.barcode === "string") {
            cleanedData.barcode = normalizeBarcode(cleanedData.barcode) || null;
        }

        const { primaryResult: updatedProduct } = await fanOutWrite(c => c.product.update({
            where: { id },
            data: { ...cleanedData as Prisma.ProductUncheckedUpdateInput }
        }));

        revalidatePath("/");
        revalidatePath("/products");
        revalidatePath("/admin/content/products");
        revalidatePath(`/products/${id}`);
        revalidateTag("products");
        revalidateTag(`product-${id}`);

        let indexingReady = false;
        try {
            const indexResult = await syncProductSearchIndex(updatedProduct);
            indexingReady = indexResult.success;
        } catch (error) {
            console.warn("[RAG] Immediate indexing failed for updated product:", error);
        }
        await invalidateCatalogSearchState();

        await emitWorkflowEvent("product.updated", {
            productId: updatedProduct.id,
            name: updatedProduct.name,
            available: updatedProduct.available,
            stockLevel: updatedProduct.stockLevel,
        });

        return { success: true, indexingReady };
    } catch (error: unknown) {
        console.error("Prisma updateProduct error:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().clearPrefix("products");
        getSearchCache().clearPrefix("query");
    }
}

// Delete product
export async function deleteProduct(id: string) {
    try {
        await requireAdminSession("products");
        await fanOutWrite(c => c.product.delete({ where: { id } }));

        revalidatePath("/");
        revalidatePath("/products");
        revalidatePath("/admin/content/products");
        revalidateTag("products");
        await invalidateCatalogSearchState();

        await emitWorkflowEvent("product.deleted", { productId: id });
        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().clearPrefix("products");
        getSearchCache().clearPrefix("query");
    }
}

// Bulk delete products
export async function deleteProducts(ids: string[]) {
    try {
        await requireAdminSession("products");
        await fanOutWrite(c => c.product.deleteMany({ where: { id: { in: ids } } }));

        revalidatePath("/");
        revalidatePath("/products");
        revalidatePath("/admin/content/products");
        revalidateTag("products");
        await invalidateCatalogSearchState();

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().clearPrefix("products");
        getSearchCache().clearPrefix("query");
    }
}

// Bulk update products (availability, featured, category, etc.)
export async function bulkUpdateProducts(ids: string[], data: Record<string, unknown>) {
    try {
        await requireAdminSession("products");
        await fanOutWrite(c => c.product.updateMany({
            where: { id: { in: ids } },
            // eslint-disable-next-line @typescript-eslint/no-explicit-any
            data: { ...data as any }
        }));

        revalidatePath("/");
        revalidatePath("/products");
        revalidatePath("/admin/content/products");
        revalidateTag("products");

        const searchableFields = new Set([
            "name", "description", "tags", "highlights", "categoryId",
            "subcategoryId", "barcode", "specifications", "imageUrl", "images",
        ]);
        const shouldReindex = Object.keys(data).some(key => searchableFields.has(key));
        let indexedCount = 0;

        if (shouldReindex) {
            try {
                const updatedProducts = await getWriteClient().product.findMany({
                    where: { id: { in: ids } },
                });
                const indexResults = await syncProductsSearchIndex(updatedProducts);
                indexedCount = indexResults.filter(result => result.success).length;
            } catch (error) {
                console.warn("[RAG] Bulk product reindex failed:", error);
            }
        }

        // Advance the distributed revision after (not before) searchable
        // fields have been reindexed, so fresh queries cannot cache a stale
        // retrieval result under the post-mutation revision.
        await invalidateCatalogSearchState();

        return { success: true, count: ids.length, indexedCount };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().clearPrefix("products");
        getSearchCache().clearPrefix("query");
    }
}

// Toggle product availability
export async function toggleProductAvailability(id: string, available: boolean) {
    try {
        await requireAdminSession("products");
        await fanOutWrite(c => c.product.update({ where: { id }, data: { available } }));

        revalidatePath("/");
        revalidatePath("/products");
        revalidatePath("/admin/content/products");
        revalidatePath(`/products/${id}`);
        revalidateTag("products");
        revalidateTag(`product-${id}`);
        await invalidateCatalogSearchState();

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().clearPrefix("products");
        getSearchCache().clearPrefix("query");
    }
}

// ==================== REVIEWS ====================

export interface Review {
    id: string;
    productId: string;
    userId: string;
    userName: string;
    rating: number;
    comment: string;
    createdAt: Date;
}

export async function addReview(productId: string, userId: string, userName: string, rating: number, comment: string) {
    try {
        if (!await allowServerAction("product-review", 5, 300)) {
            return { success: false, error: "Too many reviews submitted. Please try again later." };
        }
        const normalizedName = userName.trim().slice(0, 100);
        const normalizedComment = comment.trim().slice(0, 2_000);
        const normalizedUserId = userId.trim().slice(0, 200);
        if (!normalizedName || normalizedComment.length < 3 || !Number.isInteger(rating) || rating < 1 || rating > 5) {
            return { success: false, error: "Invalid review" };
        }

        await getWriteClient().$transaction(async (tx) => {
            const product = await tx.product.findUnique({
                where: { id: productId }
            });

            if (!product) {
                throw new Error("Product not found");
            }

            const currentCount = product.reviewCount || 0;
            const currentRating = product.averageRating || 0;

            const newCount = currentCount + 1;
            const newAverage = ((currentRating * currentCount) + rating) / newCount;

            await tx.review.create({
                data: {
                    productId,
                    userId: normalizedUserId,
                    userName: normalizedName,
                    rating,
                    comment: normalizedComment,
                }
            });

            await tx.product.update({
                where: { id: productId },
                data: {
                    reviewCount: newCount,
                    averageRating: newAverage
                }
            });
        });

        revalidatePath(`/products/${productId}`);
        revalidateTag("products");
        revalidateTag("reviews");
        revalidateTag(`reviews-${productId}`);

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().clearPrefix("products");
    }
}

async function _fetchReviews(productId: string): Promise<Review[]> {
    try {
        const reviews = await getWriteClient().review.findMany({
            where: { productId },
            orderBy: { createdAt: "desc" },
        });

        return reviews as unknown as Review[];
    } catch (error) {
        console.error("Error fetching reviews from Postgres:", error);
        return [];
    }
}

export async function getReviews(productId: string): Promise<Review[]> {
    const cachedFetch = unstable_cache(
        () => _fetchReviews(productId),
        [`reviews-${productId}`],
        { revalidate: 300, tags: ["reviews", `reviews-${productId}`] }
    );
    return cachedFetch();
}

export async function deleteReview(reviewId: string, productId: string, rating: number) {
    try {
        await requireAdminSession("reviews");
        await getWriteClient().$transaction(async (tx) => {
            const product = await tx.product.findUnique({
                where: { id: productId }
            });

            if (!product) {
                throw new Error("Product not found");
            }

            const currentCount = product.reviewCount || 0;
            const currentRating = product.averageRating || 0;

            if (currentCount <= 1) {
                await tx.product.update({
                    where: { id: productId },
                    data: { reviewCount: 0, averageRating: 0 }
                });
            } else {
                const newCount = currentCount - 1;
                // Calculate new average: (oldAvg * oldCount - ratingToRemove) / newCount
                const newAverage = ((currentRating * currentCount) - rating) / newCount;

                await tx.product.update({
                    where: { id: productId },
                    data: { reviewCount: newCount, averageRating: newAverage }
                });
            }

            await tx.review.delete({
                where: { id: reviewId }
            });
        });

        revalidatePath(`/products/${productId}`);
        revalidateTag("products");
        revalidateTag("reviews");
        revalidateTag(`reviews-${productId}`);

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    } finally {
        getSearchCache().clearPrefix("products");
    }
}

export async function getAllReviews(): Promise<(Review & { productName?: string })[]> {
    await requireAdminSession("reviews");
    try {
        const reviews = await getWriteClient().review.findMany({
            orderBy: { createdAt: "desc" },
            take: 50,
            include: { product: { select: { name: true } } }
        });

        return reviews.map(r => ({
            ...r,
            productName: r.product?.name
        })) as unknown as (Review & { productName?: string })[];
    } catch (error) {
        console.error("Error fetching all reviews from Postgres:", error);
        return [];
    }
}

// ==================== ADMIN ACCOUNT SETTINGS ====================

export interface AdminProfile {
    name: string;
    email: string;
    phone?: string;
    role: string;
    photoUrl?: string;
}

async function _fetchAdminProfile(email: string): Promise<AdminProfile | null> {
    try {
        const staff = await getWriteClient().staff.findUnique({
            where: { email }
        });

        if (staff) {
            return {
                name: staff.name || "",
                email: staff.email || email,
                phone: staff.phone || "",
                role: staff.role ? staff.role.charAt(0).toUpperCase() + staff.role.slice(1) : "Staff",
                photoUrl: staff.photoUrl || "",
            };
        }
        // The owner named in OWNER_ADMIN_EMAILS
        if (isOwnerAdmin(email)) {
            return {
                name: "Super Admin",
                email,
                phone: "",
                role: "Admin",
                photoUrl: "",
            };
        }
        return null;
    } catch (error) {
        console.error("Error fetching admin profile:", error);
        return null;
    }
}

export async function getAdminProfile(email: string): Promise<AdminProfile | null> {
    const identity = await requireAdminSession();
    if (identity.email !== email.toLowerCase() && !identity.permissions.includes("*")) {
        return null;
    }
    const cachedFetch = unstable_cache(
        () => _fetchAdminProfile(email),
        [`admin-profile-${email}`],
        { revalidate: 300, tags: ["admin-profile", `admin-profile-${email}`] }
    );
    return cachedFetch();
}

export async function updateAdminProfile(email: string, data: { name?: string; phone?: string }) {
    try {
        const identity = await requireAdminSession();
        if (identity.email !== email.toLowerCase() && !identity.permissions.includes("*")) {
            throw new Error("FORBIDDEN");
        }
        const existingStaff = await getWriteClient().staff.findUnique({ where: { email } });

        if (existingStaff) {
            await fanOutWrite(c => c.staff.update({ where: { email }, data }));
        } else {
            await fanOutWrite(c => c.staff.create({
                data: {
                    email,
                    name: data.name || "Admin",
                    phone: data.phone || "",
                    role: "admin",
                    permissions: ["*"],
                }
            }));
        }

        // Also update the Firebase Auth display name
        try {
            const { getAdminAuth } = await import("@/lib/firebase-admin");
            const authUser = await getAdminAuth().getUserByEmail(email);
            if (authUser) {
                await getAdminAuth().updateUser(authUser.uid, {
                    displayName: data.name || undefined,
                });
            }
        } catch (authError) {
            console.warn("Could not update Firebase Auth display name:", authError);
        }

        revalidatePath("/admin/settings");
        revalidatePath("/admin/staff");
        revalidateTag("admin-profile");
        revalidateTag("staff");

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

export async function updateAdminEmail(currentEmail: string, newEmail: string) {
    try {
        const identity = await requireAdminSession();
        if (identity.email !== currentEmail.toLowerCase() && !identity.permissions.includes("*")) {
            throw new Error("FORBIDDEN");
        }
        // Update Firebase Auth email
        const { getAdminAuth } = await import("@/lib/firebase-admin");
        const authUser = await getAdminAuth().getUserByEmail(currentEmail);
        if (!authUser) {
            return { success: false, error: "User not found in Firebase Auth" };
        }

        await getAdminAuth().updateUser(authUser.uid, { email: newEmail });

        // Update the Postgres staff record
        const existingStaff = await getWriteClient().staff.findUnique({ where: { email: currentEmail } });

        if (existingStaff) {
            await fanOutWrite(c => c.staff.update({
                where: { email: currentEmail },
                data: { email: newEmail }
            }));
        }

        revalidatePath("/admin/settings");
        revalidatePath("/admin/staff");
        revalidateTag("admin-profile");
        revalidateTag("staff");

        return { success: true };
    } catch (error: unknown) {
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}
