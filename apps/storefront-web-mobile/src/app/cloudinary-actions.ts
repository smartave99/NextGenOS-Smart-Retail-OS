"use server";

import { v2 as cloudinary } from "cloudinary";
import { requireAdminSession } from "@/lib/auth-server";
import { checkRateLimit } from "@/lib/rate-limit";
import { headers } from "next/headers";

/**
 * Cloudinary Multi-Account Rotation
 * 
 * Supports up to 3 Cloudinary accounts plus the default.
 * Env vars: CLOUDINARY_CLOUD_NAME_1, CLOUDINARY_API_KEY_1, CLOUDINARY_API_SECRET_1
 *           CLOUDINARY_CLOUD_NAME_2, CLOUDINARY_API_KEY_2, CLOUDINARY_API_SECRET_2
 *           etc. + fallback to CLOUDINARY_CLOUD_NAME, CLOUDINARY_API_KEY, CLOUDINARY_API_SECRET
 */

interface CloudinaryConfig {
    cloud_name: string;
    api_key: string;
    api_secret: string;
}

function getCloudinaryConfigs(): CloudinaryConfig[] {
    const configs: CloudinaryConfig[] = [];

    // Numbered accounts (1, 2, 3)
    for (let i = 1; i <= 3; i++) {
        const cloud_name = process.env[`CLOUDINARY_CLOUD_NAME_${i}`];
        const api_key = process.env[`CLOUDINARY_API_KEY_${i}`];
        const api_secret = process.env[`CLOUDINARY_API_SECRET_${i}`];
        if (cloud_name && api_key && api_secret) {
            configs.push({ cloud_name, api_key, api_secret });
        }
    }

    // Fallback to default env vars
    const defaultName = process.env.CLOUDINARY_CLOUD_NAME;
    const defaultKey = process.env.CLOUDINARY_API_KEY;
    const defaultSecret = process.env.CLOUDINARY_API_SECRET;
    if (defaultName && defaultKey && defaultSecret) {
        const alreadyExists = configs.some(c => c.cloud_name === defaultName);
        if (!alreadyExists) {
            configs.push({ cloud_name: defaultName, api_key: defaultKey, api_secret: defaultSecret });
        }
    }

    return configs;
}

const cloudinaryConfigs = getCloudinaryConfigs();

function applyConfig(config: CloudinaryConfig): void {
    cloudinary.config({
        cloud_name: config.cloud_name,
        api_key: config.api_key,
        api_secret: config.api_secret,
    });
}

function isLimitError(error: unknown): boolean {
    const msg = error instanceof Error ? error.message.toLowerCase() : String(error).toLowerCase();
    return msg.includes("limit") || msg.includes("quota") || msg.includes("429") || msg.includes("402") || msg.includes("exceeded") || msg.includes("rate");
}

// Apply the first config by default (for any internal usage)
if (cloudinaryConfigs.length > 0) {
    applyConfig(cloudinaryConfigs[0]);
}

/**
 * Generates a signature for the Cloudinary Media Library widget.
 */
export async function getMediaLibrarySignature() {
    await requireAdminSession();
    if (cloudinaryConfigs.length === 0) {
        return { success: false, error: "No Cloudinary accounts configured." };
    }

    for (let i = 0; i < cloudinaryConfigs.length; i++) {
        const config = cloudinaryConfigs[i];
        try {
            applyConfig(config);

            const timestamp = Math.round(new Date().getTime() / 1000);
            const signature = cloudinary.utils.api_sign_request(
                { timestamp },
                config.api_secret
            );

            return {
                success: true,
                signature,
                timestamp,
                cloudName: config.cloud_name,
                apiKey: config.api_key
            };
        } catch (error) {
            if (isLimitError(error) && i < cloudinaryConfigs.length - 1) {
                console.warn(`[Cloudinary] Account ${i + 1} hit a limit on getMediaLibrarySignature. Rotating...`);
                continue;
            }
            console.error("Cloudinary media library signature error:", error);
            return {
                success: false,
                error: error instanceof Error ? error.message : "Unknown error",
            };
        }
    }

    return { success: false, error: "All Cloudinary accounts exhausted." };
}

export async function getCloudinarySignature(folder: string, transformation?: string) {
    const safeFolder = folder.replace(/[^a-zA-Z0-9/_-]/g, "").slice(0, 100);
    if (safeFolder !== "product-requests") {
        await requireAdminSession();
    } else {
        const requestHeaders = await headers();
        const identifier = requestHeaders.get("x-forwarded-for")?.split(",")[0]?.trim() ||
            requestHeaders.get("x-real-ip") ||
            "anonymous";
        const rateLimit = await checkRateLimit(identifier, {
            limit: 5,
            windowSeconds: 300,
            prefix: "product-request-upload",
        });
        if (!rateLimit.allowed) {
            return { success: false, error: "Upload limit reached. Please try again later." };
        }
    }

    if (cloudinaryConfigs.length === 0) {
        return { success: false, error: "No Cloudinary accounts configured." };
    }

    for (let i = 0; i < cloudinaryConfigs.length; i++) {
        const config = cloudinaryConfigs[i];
        try {
            applyConfig(config);

            const timestamp = Math.round(new Date().getTime() / 1000);
            const params: Record<string, string | number> = {
                timestamp,
                folder: `smart-avenue/${safeFolder}`,
            };

            if (transformation) {
                params.transformation = transformation;
            }

            const signature = cloudinary.utils.api_sign_request(params, config.api_secret);

            return {
                success: true,
                signature,
                timestamp,
                cloudName: config.cloud_name,
                apiKey: config.api_key
            };
        } catch (error) {
            if (isLimitError(error) && i < cloudinaryConfigs.length - 1) {
                console.warn(`[Cloudinary] Account ${i + 1} hit a limit on getCloudinarySignature. Rotating...`);
                continue;
            }
            console.error("Cloudinary signature error:", error);
            return {
                success: false,
                error: error instanceof Error ? error.message : "Unknown error",
            };
        }
    }

    return { success: false, error: "All Cloudinary accounts exhausted." };
}

export async function deleteFromCloudinary(publicId: string) {
    await requireAdminSession();
    if (cloudinaryConfigs.length === 0) {
        return { success: false, error: "No Cloudinary accounts configured." };
    }

    for (let i = 0; i < cloudinaryConfigs.length; i++) {
        try {
            applyConfig(cloudinaryConfigs[i]);
            const result = await cloudinary.uploader.destroy(publicId);
            return { success: true, result };
        } catch (error) {
            if (isLimitError(error) && i < cloudinaryConfigs.length - 1) {
                console.warn(`[Cloudinary] Account ${i + 1} hit a limit on delete. Rotating...`);
                continue;
            }
            console.error("Cloudinary delete error:", error);
            return {
                success: false,
                error: error instanceof Error ? error.message : "Unknown delete error",
            };
        }
    }

    return { success: false, error: "All Cloudinary accounts exhausted." };
}

export async function uploadToCloudinary(base64Image: string, folder: string, resourceType: "image" | "video" | "raw" = "image") {
    await requireAdminSession();
    if (cloudinaryConfigs.length === 0) {
        return { success: false, error: "No Cloudinary accounts configured." };
    }

    for (let i = 0; i < cloudinaryConfigs.length; i++) {
        try {
            applyConfig(cloudinaryConfigs[i]);

            const result = await cloudinary.uploader.upload(base64Image, {
                folder: `smart-avenue/${folder}`,
                resource_type: resourceType,
            });

            console.log(`[Cloudinary] Successfully uploaded using Account ${i + 1}`);
            return {
                success: true,
                url: result.secure_url,
                publicId: result.public_id,
            };
        } catch (error) {
            if (isLimitError(error) && i < cloudinaryConfigs.length - 1) {
                console.warn(`[Cloudinary] Account ${i + 1} hit a limit on upload. Rotating...`);
                continue;
            }
            console.error("Cloudinary upload error:", error);
            return {
                success: false,
                error: error instanceof Error ? error.message : "Unknown upload error",
            };
        }
    }

    return { success: false, error: "All Cloudinary accounts have reached their limits." };
}

