"use client";

import { createContext, useContext, type ReactNode } from "react";
import { getPublicSettings, type PublicSettings } from "./index";

const PublicSettingsContext = createContext<PublicSettings | null>(null);

/** Hands the customer's public settings (read once by the server) to every component below it. The root layout puts it around the whole site. */
export function PublicSettingsProvider({ settings, children }: { settings: PublicSettings; children: ReactNode }) {
    return <PublicSettingsContext.Provider value={settings}>{children}</PublicSettingsContext.Provider>;
}

/** The customer's public settings: the shop's name, address, country, kind of business and place. Works outside the provider too (it then reads them the same way the provider's server did). */
export function usePublicSettings(): PublicSettings {
    return useContext(PublicSettingsContext) ?? getPublicSettings();
}
