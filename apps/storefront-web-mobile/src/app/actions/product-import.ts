"use server";

import { getWriteClient, fanOutWrite } from "@/lib/db-manager";
import { revalidatePath } from "next/cache";
import { revalidateTag } from "next/cache";
import { requireAdminSession } from "@/lib/auth-server";
import { sheetRowsToObjects } from "@/lib/sheet-rows";
import { emitWorkflowEvent } from "@/lib/workflow-events";
import {
    invalidateCatalogSearchState,
    syncProductsSearchIndex,
    type ProductSearchIndexInput,
} from "@/lib/product-indexing";

// Type definition for Excel row
// Type definition for Excel row
interface ProductRow {
    [key: string]: unknown; // Allow flexible keys for initial parsing
}

export async function importProductsFromExcel(formData: FormData) {
    try {
        await requireAdminSession("products");
        const file = formData.get('file') as File;
        if (!file) {
            return { success: false, error: "No file uploaded" };
        }
        if (file.size > 10 * 1024 * 1024) {
            return { success: false, error: "Spreadsheet is too large (max 10MB)" };
        }

        const buffer = Buffer.from(await file.arrayBuffer());
        // An .xlsx file is a zip archive: anything else (an old .xls, a renamed file) is refused before it is read.
        if (buffer.length < 4 || buffer[0] !== 0x50 || buffer[1] !== 0x4b || buffer[2] !== 0x03 || buffer[3] !== 0x04) {
            return { success: false, error: "Please upload an Excel .xlsx file (in Excel: File, Save As, Excel Workbook)." };
        }

        const { readSheet } = await import('read-excel-file/node');
        const sheetRows = await readSheet(buffer);
        const rows = sheetRowsToObjects(sheetRows);

        if (!rows || rows.length === 0) {
            return { success: false, error: "Excel file is empty" };
        }
        if (rows.length > 5_000) {
            return { success: false, error: "Import is limited to 5,000 rows at a time" };
        }

        // 1. Prefetch master data (Categories & Offers) from primary write client
        const writeClient = getWriteClient();
        const [categories, offers] = await Promise.all([
            writeClient.category.findMany(),
            writeClient.offer.findMany()
        ]);

        const categoryMap = new Map<string, string>(); // Name(lowercase) -> ID
        const offerMap = new Map<string, string>(); // Title(lowercase) -> ID

        categories.forEach(cat => {
            if (cat.name) categoryMap.set(cat.name.toLowerCase(), cat.id);
            categoryMap.set(cat.id, cat.id);
            if (cat.slug) categoryMap.set(cat.slug.toLowerCase(), cat.id);
        });

        offers.forEach(off => {
            if (off.title) offerMap.set(off.title.toLowerCase(), off.id);
            offerMap.set(off.id, off.id);
        });

        // 2. Prepare data & Identify duplicates
        const validRows: Record<string, unknown>[] = [];
        const productNames = new Set<string>();

        for (const rawRow of rows) {
            const row: Record<string, unknown> = {};
            Object.keys(rawRow).forEach(key => {
                row[key.trim().toLowerCase()] = rawRow[key];
            });

            const Name = row['name'];
            const Price = row['price'];

            if (Name && Price) {
                validRows.push(row);
                productNames.add(String(Name).trim());
            }
        }

        if (validRows.length === 0) {
            return { success: false, error: "No valid products found. Ensure columns 'Name' and 'Price' exist." };
        }

        // 3. Batched check for existing products (CASE-INSENSITIVE to prevent duplicates)
        const productNameArray = Array.from(productNames);
        const existingProductMap = new Map<string, string>(); // Name(lowercase) -> Id

        const CHUNK_SIZE = 500;
        const nameChunks = [];
        for (let i = 0; i < productNameArray.length; i += CHUNK_SIZE) {
            nameChunks.push(productNameArray.slice(i, i + CHUNK_SIZE));
        }

        await Promise.all(nameChunks.map(async (chunk) => {
            // Case-insensitive lookup: fetch all products, compare lowercased names
            const products = await writeClient.product.findMany({
                where: {
                    name: {
                        in: chunk,
                        mode: 'insensitive'
                    }
                },
                select: { id: true, name: true }
            });
            products.forEach(p => {
                existingProductMap.set(p.name.toLowerCase(), p.id);
            });
        }));

        // 4. Operations
        let totalImported = 0;
        let indexedCount = 0;

        // We'll process in sequential chunks to avoid connection pool exhaustion
        const PROCESS_CHUNK = 50;
        for (let i = 0; i < validRows.length; i += PROCESS_CHUNK) {
            const chunk = validRows.slice(i, i + PROCESS_CHUNK);
            const chunkProducts: ProductSearchIndexInput[] = [];
            const operations = chunk.map(row => {
                const Name = String(row['name']).trim();
                const Price = row['price'];

                // Extract other fields
                const Category = row['category'];
                const Subcategory = row['subcategory'];
                const OfferTitle = row['offertitle'];
                const Description = row['description'];
                const OriginalPrice = row['originalprice'];
                const ImageUrl = row['imageurl'];
                const Available = row['available'];
                const Featured = row['featured'];
                const Tags = row['tags'];
                const Barcode = row['barcode'];

                // Resolve References
                let categoryId = "";
                let subcategoryId = "";

                if (Category) {
                    const catKey = String(Category).trim().toLowerCase();
                    if (categoryMap.has(catKey)) categoryId = categoryMap.get(catKey)!;
                }
                if (Subcategory) {
                    const subKey = String(Subcategory).trim().toLowerCase();
                    if (categoryMap.has(subKey)) subcategoryId = categoryMap.get(subKey)!;
                }

                let offerId = "";
                if (OfferTitle) {
                    const offerKey = String(OfferTitle).trim().toLowerCase();
                    if (offerMap.has(offerKey)) offerId = offerMap.get(offerKey)!;
                }

                // Determine Ref (Update vs Create) — case-insensitive match
                const existingId = existingProductMap.get(Name.toLowerCase());
                const isUpdate = !!existingId;

                // eslint-disable-next-line @typescript-eslint/no-explicit-any
                const productData: any = {
                    name: Name,
                    price: Number(Price),
                    categoryId: categoryId || "uncategorized-orphan",
                    available: Available === true || String(Available).toLowerCase() === "true",
                };

                // Conditional updates for optional fields
                if (Description || !isUpdate) productData.description = Description || "";
                if (OriginalPrice || !isUpdate) productData.originalPrice = OriginalPrice ? Number(OriginalPrice) : null;
                if (subcategoryId || !isUpdate) productData.subcategoryId = subcategoryId || null;

                if (ImageUrl) {
                    productData.imageUrl = ImageUrl;
                    productData.images = [ImageUrl];
                } else if (!isUpdate) {
                    productData.imageUrl = null;
                    productData.images = [];
                }

                if (Featured !== undefined || !isUpdate) productData.featured = Featured === true || String(Featured).toLowerCase() === "true";
                if (offerId || !isUpdate) productData.offerId = offerId || null;
                if (Tags || !isUpdate) productData.tags = Tags ? String(Tags).split(',').map((s: string) => s.trim()) : [];
                if (Barcode !== undefined || !isUpdate) productData.barcode = Barcode ? String(Barcode).trim() : null;

                if (isUpdate) {
                    return (client: import("@prisma/client").PrismaClient) =>
                        client.product.update({
                            where: { id: existingId },
                            data: productData
                        });
                } else {
                    productData.reviewCount = 0;
                    productData.averageRating = 0;
                    // Generate ID upfront so all 3 DBs get the same UUID
                    const newId = crypto.randomUUID();
                    productData.id = newId;
                    return (client: import("@prisma/client").PrismaClient) =>
                        client.product.create({
                            data: productData
                        });
                }
            });

            // Fan-out each operation to all 3 databases
            for (const operationFn of operations) {
                try {
                    const { primaryResult } = await fanOutWrite(operationFn);
                    chunkProducts.push(primaryResult);
                    totalImported += 1;
                } catch (err) {
                    console.error("[Import] Fan-out write failed for one product:", err);
                }
            }

            // Index each committed chunk before moving on. If a very large
            // import is interrupted, already-written products are still
            // immediately searchable instead of waiting for a final bulk job.
            if (chunkProducts.length > 0) {
                const chunkIndexResults = await syncProductsSearchIndex(chunkProducts);
                indexedCount += chunkIndexResults.filter(result => result.success).length;
                revalidateTag("products");
                await invalidateCatalogSearchState();
            }
        }

        revalidatePath("/products");
        revalidatePath("/admin/content/products");
        revalidateTag("products");

        await emitWorkflowEvent("product.imported", {
            importedCount: totalImported,
            fileName: file.name.slice(0, 200),
        });

        return {
            success: true,
            count: totalImported,
            indexedCount,
            indexingFailed: totalImported - indexedCount,
        };

    } catch (error: unknown) {
        console.error("Import Error:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown import error" };
    }
}
