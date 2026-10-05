"use client";

import { useCallback, useEffect, useRef, useState } from "react";
import { ProductRequest, getProductRequests, updateRequestStatus } from "@/app/actions/request-actions";
import {
    Search, XCircle, ImageIcon, Loader2,
    Mail, Eye, Calendar, ExternalLink
} from "lucide-react";
import { format } from "date-fns";
import Image from "next/image";
import { toast } from "sonner";
import { useDialogFocus } from "@/components/ui/useDialogFocus";
import { money } from "@/lib/region/lite";

export default function RequestManagement() {
    const [requests, setRequests] = useState<ProductRequest[]>([]);
    const [filteredRequests, setFilteredRequests] = useState<ProductRequest[]>([]);
    const [loading, setLoading] = useState(true);
    const [loadError, setLoadError] = useState<string | null>(null);
    const [searchQuery, setSearchQuery] = useState("");
    const [statusFilter, setStatusFilter] = useState("ALL");

    const [selectedRequest, setSelectedRequest] = useState<ProductRequest | null>(null);
    const [note, setNote] = useState("");
    const [updating, setUpdating] = useState(false);
    const dialogRef = useRef<HTMLDivElement>(null);
    const closeRef = useRef<HTMLButtonElement>(null);
    const closeDetails = useCallback(() => setSelectedRequest(null), []);

    useDialogFocus({
        open: Boolean(selectedRequest),
        onClose: closeDetails,
        containerRef: dialogRef,
        initialFocusRef: closeRef,
    });

    const loadRequests = useCallback(async () => {
        setLoading(true);
        setLoadError(null);
        try {
            const data = await getProductRequests();
            setRequests(data);
        } catch (error) {
            console.error("Failed to load requests", error);
            setLoadError("Couldn’t load product requests. Check the connection and try again.");
        } finally {
            setLoading(false);
        }
    }, []);

    const filterRequests = useCallback(() => {
        let result = requests;

        if (statusFilter !== "ALL") {
            result = result.filter(r => r.status === statusFilter);
        }

        if (searchQuery) {
            const lower = searchQuery.toLowerCase();
            result = result.filter(r =>
                r.productName.toLowerCase().includes(lower) ||
                r.description.toLowerCase().includes(lower) ||
                (r.brand && r.brand.toLowerCase().includes(lower)) ||
                (r.contactInfo && r.contactInfo.toLowerCase().includes(lower))
            );
        }

        setFilteredRequests(result);
    }, [requests, searchQuery, statusFilter]);

    useEffect(() => {
        loadRequests();
    }, [loadRequests]);

    useEffect(() => {
        filterRequests();
    }, [filterRequests]);


    async function handleStatusUpdate(status: string) {
        if (!selectedRequest) return;
        setUpdating(true);
        try {
            const result = await updateRequestStatus(selectedRequest.id, status, note);
            if (result.success) {
                // Update local state
                setRequests(prev => prev.map(r =>
                    r.id === selectedRequest.id ? { ...r, status: status as ProductRequest["status"], notes: note } : r
                ));
                toast.success("Request status updated");
                setSelectedRequest(null);
                setNote("");
            } else {
                toast.error(result.error || "Couldn’t update the request status. Try again.");
            }
        } catch (error) {
            console.error(error);
            toast.error("Couldn’t update the request status. Check the connection and try again.");
        } finally {
            setUpdating(false);
        }
    }

    const getStatusColor = (status: string) => {
        switch (status) {
            case "PENDING": return "bg-yellow-100 text-yellow-800 border-yellow-200";
            case "REVIEWED": return "bg-blue-100 text-blue-800 border-blue-200";
            case "FULFILLED": return "bg-green-100 text-green-800 border-green-200";
            case "REJECTED": return "bg-red-100 text-red-800 border-red-200";
            default: return "bg-gray-100 text-gray-800 border-gray-200";
        }
    };

    return (
        <div className="space-y-6">
            {/* Header Actions */}
            <div className="flex flex-col sm:flex-row gap-4 justify-between items-start sm:items-center">
                <div className="relative flex-1 max-w-md w-full">
                    <Search className="absolute left-3 top-1/2 -translate-y-1/2 w-4 h-4 text-gray-400" />
                    <input
                        aria-label="Search product requests"
                        type="text"
                        placeholder="Search requests..."
                        value={searchQuery}
                        onChange={(e) => setSearchQuery(e.target.value)}
                        className="min-h-12 w-full rounded-xl border border-gray-300 py-3 pl-10 pr-4 outline-none focus:border-blue-700 focus:ring-4 focus:ring-blue-100"
                    />
                </div>

                <div className="flex items-center gap-2 w-full sm:w-auto overflow-x-auto pb-1 sm:pb-0">
                    {["ALL", "PENDING", "REVIEWED", "FULFILLED", "REJECTED"].map((status) => (
                        <button
                            key={status}
                            type="button"
                            onClick={() => setStatusFilter(status)}
                            aria-pressed={statusFilter === status}
                            className={`min-h-11 whitespace-nowrap rounded-full border px-4 py-2 text-sm font-medium transition-colors ${statusFilter === status
                                ? "bg-brand-dark text-white border-brand-dark"
                                : "bg-white text-gray-600 border-gray-200 hover:bg-gray-50"
                                }`}
                        >
                            {status === "ALL" ? "All Requests" : status.charAt(0) + status.slice(1).toLowerCase()}
                        </button>
                    ))}
                </div>
            </div>

            {/* Table */}
            <p className="sr-only" aria-live="polite">{filteredRequests.length} product requests shown</p>
            <div className="hidden overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm md:block">
                <div className="overflow-x-auto">
                    <table className="w-full text-sm text-left">
                        <caption className="sr-only">Customer product requests</caption>
                        <thead className="bg-gray-50 text-gray-500 font-medium border-b border-gray-200">
                            <tr>
                                <th scope="col" className="px-6 py-4">Product</th>
                                <th scope="col" className="px-6 py-4">Contact</th>
                                <th scope="col" className="px-6 py-4">Date</th>
                                <th scope="col" className="px-6 py-4">Status</th>
                                <th scope="col" className="px-6 py-4 text-right">Actions</th>
                            </tr>
                        </thead>
                        <tbody className="divide-y divide-gray-100">
                            {loadError ? (
                                <tr>
                                    <td colSpan={5} className="px-6 py-12 text-center text-red-800">
                                        <p>{loadError}</p>
                                        <button type="button" onClick={loadRequests} className="mt-4 min-h-11 rounded-lg bg-red-800 px-4 py-2 font-bold text-white hover:bg-red-900">Retry</button>
                                    </td>
                                </tr>
                            ) : loading ? (
                                <tr>
                                    <td colSpan={5} className="px-6 py-12 text-center text-gray-500">
                                        <Loader2 className="w-6 h-6 animate-spin mx-auto mb-2" />
                                        Loading requests...
                                    </td>
                                </tr>
                            ) : filteredRequests.length === 0 ? (
                                <tr>
                                    <td colSpan={5} className="px-6 py-12 text-center text-gray-500">
                                        No requests found matching your filters.
                                    </td>
                                </tr>
                            ) : (
                                filteredRequests.map((request) => (
                                    <tr key={request.id} className="hover:bg-gray-50/50 transition-colors">
                                        <td className="px-6 py-4">
                                            <div className="flex items-center gap-3">
                                                {request.imageUrl ? (
                                                    <div className="w-10 h-10 rounded-lg bg-gray-100 relative overflow-hidden shrink-0 border border-gray-200">
                                                        <Image src={request.imageUrl} alt="" fill className="object-cover" />
                                                    </div>
                                                ) : (
                                                    <div className="w-10 h-10 rounded-lg bg-gray-100 flex items-center justify-center text-gray-400 shrink-0 border border-gray-200">
                                                        <ImageIcon className="w-5 h-5" />
                                                    </div>
                                                )}
                                                <div>
                                                    <div className="font-medium text-gray-900">{request.productName}</div>
                                                    <div className="text-gray-500 text-xs truncate max-w-[200px]">
                                                        {request.brand ? `${request.brand} • ` : ""}{request.description}
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td className="px-6 py-4">
                                            <div className="flex items-center gap-2 text-gray-600">
                                                <Mail className="w-3.5 h-3.5" />
                                                <span className="truncate max-w-[150px]">{request.contactInfo}</span>
                                            </div>
                                        </td>
                                        <td className="px-6 py-4 text-gray-500 text-xs">
                                            {format(new Date(request.createdAt), "MMM d, yyyy")}
                                        </td>
                                        <td className="px-6 py-4">
                                            <span className={`px-2.5 py-1 rounded-full text-xs font-semibold border ${getStatusColor(request.status)}`}>
                                                {request.status}
                                            </span>
                                        </td>
                                        <td className="px-6 py-4 text-right">
                                            <button
                                                type="button"
                                                onClick={() => {
                                                    setSelectedRequest(request);
                                                    setNote(request.notes || "");
                                                }}
                                                aria-label={`Review request for ${request.productName}`}
                                                className="grid h-11 w-11 place-items-center rounded-lg text-gray-500 transition-colors hover:bg-blue-50 hover:text-blue-700"
                                            >
                                                <Eye className="w-4 h-4" />
                                            </button>
                                        </td>
                                    </tr>
                                ))
                            )}
                        </tbody>
                    </table>
                </div>
            </div>

            <div className="space-y-3 md:hidden" aria-label="Product request list">
                {loadError ? (
                    <div className="rounded-2xl border border-red-200 bg-red-50 p-5 text-center text-red-900" role="alert">
                        <p>{loadError}</p>
                        <button type="button" onClick={loadRequests} className="mt-4 min-h-11 rounded-lg bg-red-800 px-4 py-2 font-bold text-white">Retry</button>
                    </div>
                ) : loading ? (
                    <div className="rounded-2xl border border-slate-200 bg-white p-8 text-center text-slate-600" aria-busy="true">
                        <Loader2 className="mx-auto mb-2 h-6 w-6 animate-spin" aria-hidden="true" /> Loading requests…
                    </div>
                ) : filteredRequests.length === 0 ? (
                    <p className="rounded-2xl border border-slate-200 bg-white p-8 text-center text-slate-600">No requests match these filters.</p>
                ) : filteredRequests.map((request) => (
                    <button
                        type="button"
                        key={request.id}
                        onClick={() => { setSelectedRequest(request); setNote(request.notes || ""); }}
                        className="w-full rounded-2xl border border-slate-200 bg-white p-4 text-left shadow-sm focus-visible:ring-2 focus-visible:ring-blue-700"
                    >
                        <span className="flex items-start justify-between gap-3">
                            <span className="min-w-0">
                                <span className="block break-words font-bold text-slate-950">{request.productName}</span>
                                <span className="mt-1 block break-all text-sm text-slate-600">{request.contactInfo}</span>
                            </span>
                            <span className={`shrink-0 rounded-full border px-2.5 py-1 text-xs font-semibold ${getStatusColor(request.status)}`}>{request.status}</span>
                        </span>
                        <span className="mt-4 flex items-center justify-between text-sm text-slate-500">
                            <span>{format(new Date(request.createdAt), "d MMM yyyy")}</span>
                            <span className="font-semibold text-blue-700">Review details</span>
                        </span>
                    </button>
                ))}
            </div>

            {/* Details Modal */}
            {selectedRequest && (
                <div className="fixed inset-0 z-50 flex items-center justify-center p-4">
                    <button type="button" className="absolute inset-0 bg-black/60 backdrop-blur-sm" onClick={closeDetails} aria-label="Close request details" />
                    <div ref={dialogRef} tabIndex={-1} role="dialog" aria-modal="true" aria-labelledby="request-details-title" className="relative flex max-h-[90vh] w-full max-w-2xl flex-col overflow-hidden rounded-2xl bg-white shadow-2xl">
                        <div className="p-6 border-b border-gray-100 flex justify-between items-start">
                            <div>
                                <h2 id="request-details-title" className="text-xl font-bold text-gray-900">{selectedRequest.productName}</h2>
                                <div className="flex items-center gap-2 text-sm text-gray-500 mt-1">
                                    <Calendar className="w-3.5 h-3.5" />
                                    Requested on {format(new Date(selectedRequest.createdAt), "PPP")}
                                </div>
                            </div>
                            <button ref={closeRef} type="button" onClick={closeDetails} className="grid h-11 w-11 place-items-center rounded-xl text-gray-500 hover:bg-gray-100 hover:text-gray-700" aria-label="Close request details">
                                <XCircle className="h-6 w-6" aria-hidden="true" />
                            </button>
                        </div>

                        <div className="p-6 overflow-y-auto">
                            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                                <div>
                                    <h4 className="text-xs font-semibold text-gray-400 uppercase tracking-wider mb-3">Product Details</h4>
                                    <div className="space-y-4">
                                        <div className="bg-gray-50 p-4 rounded-xl border border-gray-100">
                                            <label className="text-xs text-gray-500 block mb-1">Brand</label>
                                            <p className="font-medium text-gray-900">{selectedRequest.brand || "Not specified"}</p>
                                        </div>
                                        <div className="bg-gray-50 p-4 rounded-xl border border-gray-100">
                                            <label className="text-xs text-gray-500 block mb-1">Description</label>
                                            <p className="text-gray-700 text-sm leading-relaxed">{selectedRequest.description}</p>
                                        </div>
                                        <div className="flex gap-4">
                                            <div className="flex-1 bg-gray-50 p-4 rounded-xl border border-gray-100">
                                                <label className="text-xs text-gray-500 block mb-1">Price Range</label>
                                                <p className="font-medium text-gray-900">
                                                    {selectedRequest.minPrice ? money(selectedRequest.minPrice) : "Any"} – {selectedRequest.maxPrice ? money(selectedRequest.maxPrice) : "Any"}
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div className="space-y-6">
                                    {selectedRequest.imageUrl && (
                                        <div>
                                            <h4 className="text-xs font-semibold text-gray-400 uppercase tracking-wider mb-3">Reference Image</h4>
                                            <div className="relative aspect-square rounded-xl overflow-hidden bg-gray-100 border border-gray-200 group">
                                                <Image src={selectedRequest.imageUrl} alt="Reference" fill className="object-cover" />
                                                <a
                                                    href={selectedRequest.imageUrl}
                                                    target="_blank"
                                                    rel="noopener noreferrer"
                                                    className="absolute right-2 top-2 grid h-11 w-11 place-items-center rounded-lg bg-white/95 text-slate-700 shadow-sm transition-colors hover:text-blue-700"
                                                    aria-label="Open reference image in a new tab"
                                                >
                                                    <ExternalLink className="w-4 h-4" />
                                                </a>
                                            </div>
                                        </div>
                                    )}

                                    <div>
                                        <h4 className="text-xs font-semibold text-gray-400 uppercase tracking-wider mb-3">Contact Info</h4>
                                        <div className="bg-blue-50 p-4 rounded-xl border border-blue-100 text-blue-900 flex items-center gap-3">
                                            <Mail className="w-5 h-5 text-blue-500" />
                                            <span className="font-medium">{selectedRequest.contactInfo}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div className="mt-8 border-t border-gray-100 pt-6">
                                <h4 className="text-xs font-semibold text-gray-400 uppercase tracking-wider mb-3">Admin Actions</h4>
                                <div className="flex flex-col gap-4">
                                    <label htmlFor="request-admin-note" className="text-sm font-semibold text-gray-700">Private admin note</label>
                                    <textarea
                                        id="request-admin-note"
                                        value={note}
                                        onChange={(e) => setNote(e.target.value)}
                                        placeholder="Add private admin notes..."
                                        className="w-full px-4 py-3 rounded-xl border border-gray-200 focus:ring-2 focus:ring-brand-blue/20 outline-none text-sm"
                                        rows={2}
                                    />
                                    <div className="flex flex-wrap gap-2">
                                        <button
                                            type="button"
                                            onClick={() => handleStatusUpdate("REVIEWED")}
                                            disabled={updating}
                                            className="min-h-11 rounded-lg bg-blue-100 px-4 py-2 text-sm font-medium text-blue-800 transition-colors hover:bg-blue-200"
                                        >
                                            Mark Reviewed
                                        </button>
                                        <button
                                            type="button"
                                            onClick={() => handleStatusUpdate("FULFILLED")}
                                            disabled={updating}
                                            className="min-h-11 rounded-lg bg-green-100 px-4 py-2 text-sm font-medium text-green-800 transition-colors hover:bg-green-200"
                                        >
                                            Mark Fulfilled
                                        </button>
                                        <button
                                            type="button"
                                            onClick={() => handleStatusUpdate("REJECTED")}
                                            disabled={updating}
                                            className="min-h-11 rounded-lg bg-red-100 px-4 py-2 text-sm font-medium text-red-800 transition-colors hover:bg-red-200"
                                        >
                                            Reject Request
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
}
