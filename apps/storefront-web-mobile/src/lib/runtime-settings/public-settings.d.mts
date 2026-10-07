// Types for ./public-settings.mjs (that file is the same one the Setup Studio and the website package carry, so it is plain JavaScript; this file only describes it).
export const CUSTOMER_FOLDER: "customer";
export const SETTINGS_FILE: "public-settings.json";
export const BRAND_FILE: "brand.json";
export const LOGO_FILE: "logo.png";
export const MAX_SETTINGS_BYTES: number;
export const MAX_BRAND_BYTES: number;
export const MAX_LOGO_BYTES: number;
export const GENERIC_NAME: "generic";

export interface SettingRule {
    required?: boolean;
    check: (value: string) => string | null;
}
export const PUBLIC_SETTINGS: Readonly<Record<string, SettingRule>>;
export const SETTING_NAMES: string[];

export function shortNameProblem(id: unknown): string | null;
export function contrastWithWhite(hex: string): number;

export interface CheckOptions {
    countries?: string[] | null;
    industries?: string[] | null;
    requireName?: boolean;
    findSecrets?: ((text: string) => string[]) | null;
}
export function checkSettings(input: unknown, options?: CheckOptions): { values: Record<string, string>; problems: string[] };

export interface SiteBrandData {
    name?: string;
    tagline?: string;
    primaryColor?: string;
    accentColor?: string;
    contact?: { email?: string; phone?: string; address?: string };
}
export function siteBrand(kit: unknown): { brand: SiteBrandData | null; problems: string[] };
export function logoProblem(bytes: Uint8Array | null | undefined): string | null;

export function settingsFileText(customer: string | null, values: Record<string, string | undefined>): string;
export function parseSettingsFile(text: unknown, options?: CheckOptions): { ok: boolean; problems: string[]; customer: string | null; values: Record<string, string> };
export function readCustomerFolder(
    read: (name: string) => Uint8Array | null,
    options?: CheckOptions,
): { ok: boolean; problems: string[]; customer: string | null; values: Record<string, string>; brand: SiteBrandData | null; hasLogo: boolean };
