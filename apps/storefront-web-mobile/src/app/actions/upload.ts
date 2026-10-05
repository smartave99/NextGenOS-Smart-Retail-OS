"use server";

import { uploadToCloudinary } from "@/app/cloudinary-actions";
import { requireAdminSession } from "@/lib/auth-server";

/**
 * Uploads a file to Cloudinary (with multi-account rotation).
 * Replaces the previous Vercel Blob implementation.
 *
 * Cloudinary accounts are configured via:
 *   CLOUDINARY_CLOUD_NAME_1/2/3, CLOUDINARY_API_KEY_1/2/3, CLOUDINARY_API_SECRET_1/2/3
 *   (+ fallback: CLOUDINARY_CLOUD_NAME, CLOUDINARY_API_KEY, CLOUDINARY_API_SECRET)
 */
export async function uploadFile(formData: FormData) {
    try {
        await requireAdminSession();
        const file = formData.get("file") as File;
        const requestedFolder = (formData.get("folder") as string) || "uploads";
        const folder = requestedFolder.replace(/[^a-zA-Z0-9/_-]/g, "").slice(0, 100) || "uploads";

        if (!file) {
            return { success: false, error: "No file provided" };
        }
        const isImage = ["image/jpeg", "image/png", "image/webp", "image/gif", "image/svg+xml"].includes(file.type);
        const isVideo = ["video/mp4", "video/webm", "video/quicktime"].includes(file.type);
        if (!isImage && !isVideo) {
            return { success: false, error: "Unsupported file type" };
        }
        const maximumSize = isVideo ? 25 * 1024 * 1024 : 8 * 1024 * 1024;
        if (file.size > maximumSize) {
            return { success: false, error: `File is too large (max ${isVideo ? 25 : 8}MB)` };
        }

        // Convert File to base64 data URI for Cloudinary uploader
        const arrayBuffer = await file.arrayBuffer();
        const base64 = Buffer.from(arrayBuffer).toString("base64");
        const mimeType = file.type || "image/jpeg";
        const dataUri = `data:${mimeType};base64,${base64}`;

        // Determine Cloudinary resource type
        const resourceType: "image" | "video" | "raw" = mimeType.startsWith("video/")
            ? "video"
            : mimeType.startsWith("image/")
                ? "image"
                : "raw";

        const result = await uploadToCloudinary(dataUri, folder, resourceType);

        if (!result.success) {
            return { success: false, error: result.error || "Upload failed" };
        }

        console.log(`[upload] Successfully uploaded to Cloudinary: ${result.url}`);
        return { success: true, url: result.url, publicId: result.publicId };

    } catch (error) {
        console.error("Server upload error:", error);
        return {
            success: false,
            error: error instanceof Error ? error.message : "Upload failed",
        };
    }
}
