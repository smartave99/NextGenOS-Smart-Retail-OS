"use client";

import { Component, ReactNode } from "react";
import { SHOP_NAME } from "@/lib/shop-name";

interface Props {
    children: ReactNode;
    onCatch?: (error: Error, errorInfo: React.ErrorInfo) => void;
}

interface State {
    hasError: boolean;
    error: Error | null;
}

export class ErrorBoundary extends Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = { hasError: false, error: null };
    }

    static getDerivedStateFromError(error: Error): State {
        return { hasError: true, error };
    }

    componentDidCatch(error: Error, errorInfo: React.ErrorInfo) {
        console.error("Application error boundary caught error:", error, errorInfo);
        if (this.props.onCatch) {
            this.props.onCatch(error, errorInfo);
        }
    }

    render() {
        if (this.state.hasError) {
            return (
                <div className="min-h-screen flex items-center justify-center bg-red-50 p-4">
                    <div className="max-w-md w-full bg-white rounded-lg shadow-lg p-6 border border-red-200">
                        <h2 className="mb-2 text-xl font-bold text-red-800">Couldn’t load this page</h2>
                        <p className="text-gray-600 mb-4">
                            A page component stopped responding. Reload the page to try again; if it continues, contact the {SHOP_NAME} team.
                        </p>
                        {process.env.NODE_ENV === "development" && (
                            <div className="bg-gray-100 p-3 rounded text-sm font-mono overflow-auto max-h-40 mb-4">
                                {this.state.error?.message || "Unknown error"}
                            </div>
                        )}
                        <button
                            type="button"
                            onClick={() => {
                                this.setState({ hasError: false });
                                window.location.reload();
                            }}
                            className="min-h-11 rounded-lg bg-red-700 px-4 py-2 font-bold text-white transition-colors hover:bg-red-800"
                        >
                            Reload page
                        </button>
                    </div>
                </div>
            );
        }

        return this.props.children;
    }
}
