"use client";

import { useState } from "react";
import { usePathname } from "next/navigation";
import { AuthProvider, useAuth } from "@/context/auth-context";
import { ErrorBoundary } from "@/components/ErrorBoundary";
import AdminSidebar from "@/components/admin/AdminSidebar";
import { Menu } from "lucide-react";

export default function AdminLayout({ children }: { children: React.ReactNode }) {
    return (
        <ErrorBoundary>
            <AuthProvider>
                <AdminFrame>{children}</AdminFrame>
            </AuthProvider>
        </ErrorBoundary>
    );
}

function AdminFrame({ children }: { children: React.ReactNode }) {
    const [mobileOpen, setMobileOpen] = useState(false);
    const pathname = usePathname();
    const { user } = useAuth();

    // Live shop is the owner's: it signs in with the owner's Supabase account, so it also opens without the
    // website's admin sign-in, full screen and without the admin menu.
    if (!user && pathname?.startsWith("/admin/live")) {
        return <div className="fixed inset-0 z-50 bg-brand-sand overflow-y-auto">{children}</div>;
    }

    return (
        <div className="fixed inset-0 z-50 bg-brand-sand overflow-hidden flex">
            <AdminSidebar mobileOpen={mobileOpen} setMobileOpen={setMobileOpen} />

            <div className="flex-1 flex flex-col min-w-0 overflow-hidden relative">
                {/* Mobile Header Toggle */}
                <div className="lg:hidden bg-white border-b border-gray-200 p-4 flex items-center justify-between">
                    <div className="flex items-center">
                        <button onClick={() => setMobileOpen(true)} className="p-2 -ml-2 text-gray-600 hover:bg-gray-100 rounded-lg">
                            <Menu className="w-6 h-6" />
                        </button>
                        <span className="font-serif font-semibold text-lg ml-2 text-gray-800">Admin Portal</span>
                    </div>
                </div>

                <main className="flex-1 overflow-y-auto">
                    {children}
                </main>
            </div>
        </div>
    );
}

