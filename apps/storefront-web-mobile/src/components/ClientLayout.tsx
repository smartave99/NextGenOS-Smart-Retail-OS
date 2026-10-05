"use client";

import dynamic from "next/dynamic";
import { usePathname } from "next/navigation";
import { AuthProvider } from "@/context/auth-context";
import { SiteConfigProvider } from "@/context/SiteConfigContext";
import Header from "./Header";
import Footer from "./Footer";
import { ErrorBoundary } from "./ErrorBoundary";
import { DebugProvider, useDebug } from "@/context/DebugContext";
import { ErrorInspector } from "./debug/ErrorInspector";

import { SiteConfig } from "@/types/site-config";

// Lazy-load non-critical components to reduce initial JS bundle
const AssistantChat = dynamic(() => import("./assistant/AssistantChat"), { ssr: false });
const PwaInstallPrompt = dynamic(() => import("./PwaInstallPrompt"), { ssr: false });
const SwUpdateBanner = dynamic(() => import("./SwUpdateBanner"), { ssr: false });
const VersionManager = dynamic(() => import("./VersionManager"), { ssr: false });

function DebugErrorBoundary({ children }: { children: React.ReactNode }) {
    const { addError } = useDebug();
    return (
        <ErrorBoundary
            onCatch={(error, info) => {
                addError({
                    message: error.message,
                    stack: error.stack,
                    context: { componentStack: info.componentStack }
                });
            }}
        >
            {children}
        </ErrorBoundary>
    );
}

export default function ClientLayout({
    children,
    initialConfig,
}: {
    children: React.ReactNode;
    initialConfig: SiteConfig;
}) {
    const pathname = usePathname();

    // The admin dashboard renders itself as a full-screen `fixed inset-0 z-50` overlay.
    // The public site chrome is fixed-position and sits at a higher stacking level
    // (Header is z-[60], SwUpdateBanner z-[9999], the chat launcher and PWA prompt are
    // z-50 but paint later), so it would cover the admin header, form fields and the
    // floating save bar. Public chrome has no purpose inside the admin portal anyway.
    const isAdminRoute = pathname?.startsWith("/admin") ?? false;

    return (
        <DebugProvider>
            <DebugErrorBoundary>
                <AuthProvider>
                    <SiteConfigProvider initialConfig={initialConfig}>
                        {!isAdminRoute && <Header />}
                        {children}
                        {!isAdminRoute && (
                            <>
                                <AssistantChat />
                                <PwaInstallPrompt />
                                <SwUpdateBanner />
                            </>
                        )}
                        <VersionManager />
                        {!isAdminRoute && <Footer />}
                        <ErrorInspector />
                    </SiteConfigProvider>
                </AuthProvider>
            </DebugErrorBoundary>
        </DebugProvider>
    );
}
