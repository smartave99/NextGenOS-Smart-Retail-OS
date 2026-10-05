"use client";

import { useState, useRef, useEffect, useCallback } from "react";
import { motion, AnimatePresence } from "framer-motion";
import {
    X,
    Send,
    Sparkles,
    Package,
    ChevronRight,
    Trash2,
    ArrowDown,
    ShoppingBag,
    Gift,
    TrendingUp,
    ImagePlus,
    Mic,
    ScanLine,
    Square,
} from "lucide-react";
import { Product } from "@/app/actions";
import Image from "next/image";
import Link from "next/link";
import { RecommendationRequest, RecommendationResponse } from "@/types/assistant-types";
import dynamic from "next/dynamic";
import { analyzeImage } from "@/app/actions/image-search-action";
import { processVoiceSearch } from "@/app/actions/voice-search-action";
import BarcodeScanner from "@/components/BarcodeScanner";

// Lazy-load ProductRequestModal (18KB) — only needed when user requests a product
const ProductRequestModal = dynamic(() => import("@/components/ProductRequestModal"), { ssr: false });

interface Message {
    id: string;
    role: "user" | "assistant";
    content: string;
    products?: Product[];
    showRequestLink?: boolean;
    suggestedActions?: string[];
    queryText?: string;
    timestamp: Date;
}

interface PublicAISettings {
    enabled: boolean;
    personaName: string;
    greeting: string;
    enableVoiceInput: boolean;
    enableProductRequests: boolean;
}

const QUICK_ACTIONS = [
    { label: "🔥 Trending Now", icon: TrendingUp, query: "What's trending right now? Show me the most popular products!" },
    { label: "🎁 Gift Ideas", icon: Gift, query: "I need help finding the perfect gift! Can you suggest something special?" },
    { label: "💰 Best Deals", icon: ShoppingBag, query: "Show me the best deals and discounts you have right now" },
    { label: "✨ New Arrivals", icon: Sparkles, query: "What's new in the store? Show me the latest additions!" },
];

const MAX_VISION_UPLOAD_BYTES = 2.5 * 1024 * 1024;

async function prepareVisionImage(file: File): Promise<File> {
    if (file.size <= MAX_VISION_UPLOAD_BYTES) return file;

    const bitmap = await createImageBitmap(file);
    const longestSide = Math.max(bitmap.width, bitmap.height);
    const scale = Math.min(1, 1_600 / longestSide);
    const canvas = document.createElement("canvas");
    canvas.width = Math.max(1, Math.round(bitmap.width * scale));
    canvas.height = Math.max(1, Math.round(bitmap.height * scale));

    const context = canvas.getContext("2d");
    if (!context) {
        bitmap.close();
        throw new Error("This browser could not prepare the image for AI search.");
    }

    context.fillStyle = "#ffffff";
    context.fillRect(0, 0, canvas.width, canvas.height);
    context.drawImage(bitmap, 0, 0, canvas.width, canvas.height);
    bitmap.close();

    const blob = await new Promise<Blob | null>(resolve => {
        canvas.toBlob(resolve, "image/jpeg", 0.82);
    });

    if (!blob || blob.size > MAX_VISION_UPLOAD_BYTES) {
        throw new Error("Please choose a smaller image for AI search.");
    }

    return new File([blob], `${file.name.replace(/\.[^.]+$/, "") || "product"}.jpg`, {
        type: "image/jpeg",
    });
}

const TypewriterText = ({ content }: { content: string }) => {
    const [visibleText, setVisibleText] = useState("");
    
    useEffect(() => {
        let i = 0;
        const timer = setInterval(() => {
            if (i >= content.length) {
                setVisibleText(content);
                clearInterval(timer);
                return;
            }
            i++;
            setVisibleText(content.slice(0, i));
        }, 15);
        
        return () => clearInterval(timer);
    }, [content]);

    return <div className="animate-fade-in whitespace-pre-wrap">{visibleText}</div>;
};

export default function AssistantChat() {
    const [isOpen, setIsOpen] = useState(false);
    const [inputValue, setInputValue] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const [messages, setMessages] = useState<Message[]>([]);
    const [showGreetingPopup, setShowGreetingPopup] = useState(false);
    const [showScrollDown, setShowScrollDown] = useState(false);
    const [aiSettings, setAiSettings] = useState<PublicAISettings | null>(null);
    const messagesEndRef = useRef<HTMLDivElement>(null);
    const messagesContainerRef = useRef<HTMLDivElement>(null);
    const inputRef = useRef<HTMLInputElement>(null);
    const [isRequestModalOpen, setIsRequestModalOpen] = useState(false);
    const [requestModalQuery, setRequestModalQuery] = useState("");
    const [isRecording, setIsRecording] = useState(false);
    const [isBarcodeScannerOpen, setIsBarcodeScannerOpen] = useState(false);
    const imageInputRef = useRef<HTMLInputElement>(null);
    const mediaRecorderRef = useRef<MediaRecorder | null>(null);
    const audioChunksRef = useRef<Blob[]>([]);

    // Defer AI settings fetch by 5 seconds to avoid competing with critical page resources.
    // If the user opens the chat before that, we fetch immediately.
    const settingsFetchedRef = useRef(false);

    const fetchAiSettings = useCallback(() => {
        if (settingsFetchedRef.current) return;
        settingsFetchedRef.current = true;
        fetch("/api/assistant/settings")
            .then(res => res.json())
            .then((data: PublicAISettings) => setAiSettings(data))
            .catch(() => setAiSettings({
                enabled: true,
                personaName: "Genie",
                greeting: "Hey there! ✨ I'm Genie, your personal shopping assistant at Smart Avenue 99! Whether you need help finding the perfect product, a gift for someone special, or just want to explore what's trending — I've got you covered. What are you looking for today? 🛍️",
                enableVoiceInput: false,
                enableProductRequests: true,
            }));
    }, []);

    useEffect(() => {
        const timer = setTimeout(() => fetchAiSettings(), 5000);
        return () => clearTimeout(timer);
    }, [fetchAiSettings]);

    // Load messages from local storage on mount
    useEffect(() => {
        if (!aiSettings) return;
        const savedMessages = localStorage.getItem("assistant_chat_history");
        if (savedMessages) {
            try {
                const parsed = JSON.parse(savedMessages);
                if (Array.isArray(parsed)) {
                    const hydratedMessages = parsed.map((msg: Message) => ({
                        ...msg,
                        timestamp: new Date(msg.timestamp),
                    }));
                    setMessages(hydratedMessages);
                }
            } catch (e) {
                console.error("Failed to parse chat history", e);
            }
        } else {
            setMessages([
                {
                    id: "welcome",
                    role: "assistant",
                    content: aiSettings.greeting,
                    timestamp: new Date(),
                },
            ]);
            const timer = setTimeout(() => setShowGreetingPopup(true), 3000);
            return () => clearTimeout(timer);
        }
    }, [aiSettings]);

    // Save messages to local storage
    useEffect(() => {
        if (messages.length > 0) {
            localStorage.setItem("assistant_chat_history", JSON.stringify(messages));
        }
    }, [messages]);

    // Proactive Greeting based on page context (Simulated Silicon Valley feature)
    useEffect(() => {
        if (!isOpen && !showGreetingPopup && messages.length <= 1) {
            const path = window.location.pathname;
            let contextualGreeting = "";
            if (path.includes("/products/")) {
                contextualGreeting = "Viewing a product? I can compare it or check availability! ✨";
            } else if (path.includes("/offers")) {
                contextualGreeting = "Want me to find the best deals for you? 💰";
            }
            
            if (contextualGreeting) {
                const timer = setTimeout(() => {
                    setMessages(prev => {
                        if (prev.length <= 1) {
                            return [{
                                id: "welcome-contextual",
                                role: "assistant",
                                content: contextualGreeting,
                                timestamp: new Date(),
                            }];
                        }
                        return prev;
                    });
                    setShowGreetingPopup(true);
                }, 4000);
                return () => clearTimeout(timer);
            }
        }
    }, [isOpen, showGreetingPopup, messages.length]);

    // Auto-scroll to bottom
    useEffect(() => {
        messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    }, [messages]);

    // Focus input on open
    useEffect(() => {
        if (isOpen) {
            setTimeout(() => inputRef.current?.focus(), 200);
        }
    }, [isOpen]);

    // Listen for custom open event
    useEffect(() => {
        const handleOpenChat = () => setIsOpen(true);
        window.addEventListener("open-assistant-chat", handleOpenChat);
        return () => window.removeEventListener("open-assistant-chat", handleOpenChat);
    }, []);

    // Scroll detection for "scroll to bottom" button
    useEffect(() => {
        const container = messagesContainerRef.current;
        if (!container) return;
        const handleScroll = () => {
            const isNearBottom = container.scrollHeight - container.scrollTop - container.clientHeight < 100;
            setShowScrollDown(!isNearBottom);
        };
        container.addEventListener("scroll", handleScroll);
        return () => container.removeEventListener("scroll", handleScroll);
    }, [isOpen]);

    const scrollToBottom = () => {
        messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    };

    const clearChat = () => {
        const greeting = aiSettings?.greeting || "Hi, I'm Genie! How can I help you today?";
        setMessages([
            {
                id: "welcome",
                role: "assistant",
                content: greeting,
                timestamp: new Date(),
            },
        ]);
        localStorage.removeItem("assistant_chat_history");
    };

    const handleSend = async (e?: React.FormEvent, quickQuery?: string) => {
        if (e) e.preventDefault();
        const query = quickQuery || inputValue.trim();
        if (!query || isLoading) return;

        const userMessage: Message = {
            id: Date.now().toString(),
            role: "user",
            content: query,
            timestamp: new Date(),
        };

        setMessages((prev) => [...prev, userMessage]);
        setInputValue("");
        setIsLoading(true);

        try {
            const history = messages.slice(-20).map((m) => ({
                role: m.role,
                content: m.content,
            }));

            const reqBody: RecommendationRequest = {
                query: userMessage.content,
                messages: history,
                maxResults: 5,
            };

            const response = await fetch("/api/assistant/recommend", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(reqBody),
            });

            if (!response.ok) throw new Error("Failed to get recommendations");

            const data: RecommendationResponse = await response.json();

            const hasProducts = data.success && data.recommendations.length > 0;
            // Greetings and small talk are normal conversation, not failed product searches.
            const isGeneralChat = data.intent?.isGeneralChat === true;

            const assistantMessage: Message = {
                id: (Date.now() + 1).toString(),
                role: "assistant",
                content:
                    data.summary?.trim() ||
                    "I didn't quite catch that. Could you tell me a little more about what you're looking for? 😊",
                products: hasProducts ? data.recommendations.map((r) => r.product) : [],
                showRequestLink:
                    !hasProducts && !isGeneralChat && aiSettings?.enableProductRequests !== false,
                suggestedActions: data.suggestedActions?.filter((action) => action.trim()).slice(0, 3),
                queryText: query,
                timestamp: new Date(),
            };

            setMessages((prev) => [...prev, assistantMessage]);
        } catch (error) {
            console.error("Chat error:", error);
            setMessages((prev) => [
                ...prev,
                {
                    id: (Date.now() + 1).toString(),
                    role: "assistant",
                    content:
                        "I'm sorry, I encountered an error. Please try again in a moment. 🙏",
                    timestamp: new Date(),
                },
            ]);
        } finally {
            setIsLoading(false);
        }
    };

    const handleBarcodeDetected = (barcode: string) => {
        const value = barcode.trim();
        if (!value || isLoading) return;
        setIsBarcodeScannerOpen(false);
        void handleSend(undefined, `barcode:${value}`);
    };

    const addAssistantError = (message: string) => {
        setMessages((previous) => [
            ...previous,
            {
                id: `${Date.now()}-multimodal-error`,
                role: "assistant",
                content: message,
                timestamp: new Date(),
            },
        ]);
    };

    const handleImageSelection = async (event: React.ChangeEvent<HTMLInputElement>) => {
        const file = event.target.files?.[0];
        event.target.value = "";
        if (!file || isLoading) return;

        setIsLoading(true);
        try {
            const preparedFile = await prepareVisionImage(file);
            const formData = new FormData();
            formData.append("image", preparedFile);
            const result = await analyzeImage(formData);
            if (!result.success || !result.query) {
                throw new Error(result.error || "I could not understand that image.");
            }
            setIsLoading(false);
            await handleSend(undefined, result.query);
        } catch (error) {
            addAssistantError(error instanceof Error ? error.message : "I could not analyze that image.");
            setIsLoading(false);
        }
    };

    const handleVoiceToggle = async () => {
        if (isRecording) {
            mediaRecorderRef.current?.stop();
            setIsRecording(false);
            return;
        }

        try {
            const stream = await navigator.mediaDevices.getUserMedia({ audio: true });
            const recorder = new MediaRecorder(stream);
            audioChunksRef.current = [];
            mediaRecorderRef.current = recorder;

            recorder.ondataavailable = (event) => {
                if (event.data.size > 0) audioChunksRef.current.push(event.data);
            };
            recorder.onstop = async () => {
                stream.getTracks().forEach((track) => track.stop());
                setIsLoading(true);
                try {
                    const audio = new Blob(audioChunksRef.current, {
                        type: recorder.mimeType || "audio/webm",
                    });
                    const formData = new FormData();
                    formData.append("audio", audio, "voice-search.webm");
                    const result = await processVoiceSearch(formData);
                    if (!result.success || !result.text) {
                        throw new Error(result.error || "I could not understand that recording.");
                    }
                    setIsLoading(false);
                    await handleSend(undefined, result.text);
                } catch (error) {
                    addAssistantError(error instanceof Error ? error.message : "Voice search failed.");
                    setIsLoading(false);
                }
            };

            recorder.start();
            setIsRecording(true);
        } catch {
            addAssistantError("Microphone access is unavailable. Please allow access or type your request.");
            setIsRecording(false);
        }
    };

    const personaName = aiSettings?.personaName || "Genie";
    const isEnabled = aiSettings?.enabled !== false;

    // Don't render if AI is disabled
    if (aiSettings && !isEnabled) return null;

    return (
        <>
            {/* Floating Action Button */}
            <AnimatePresence>
                <motion.div
                    initial={{ scale: 0, opacity: 0 }}
                    animate={{ scale: 1, opacity: 1 }}
                    exit={{ scale: 0, opacity: 0 }}
                    transition={{ type: "spring", stiffness: 260, damping: 20, delay: 0.5 }}
                    className="fixed bottom-24 right-4 md:bottom-6 md:right-6 z-50 flex flex-col items-end gap-3"
                >
                    {/* Greeting Popup */}
                    <AnimatePresence>
                        {showGreetingPopup && (
                            <motion.div
                                initial={{ opacity: 0, y: 10, scale: 0.85 }}
                                animate={{ opacity: 1, y: 0, scale: 1 }}
                                exit={{ opacity: 0, scale: 0.85, y: 10 }}
                                transition={{ type: "spring", stiffness: 300, damping: 25 }}
                                className="mb-2 mr-2 bg-white/80 backdrop-blur-2xl p-5 rounded-2xl shadow-xl shadow-slate-900/5 border border-white max-w-[300px] relative"
                            >
                                <button
                                    onClick={() => setShowGreetingPopup(false)}
                                    className="absolute -top-2 -right-2 w-6 h-6 bg-gray-100 hover:bg-gray-200 rounded-full flex items-center justify-center text-gray-500 transition-colors shadow-sm"
                                >
                                    <X className="w-3 h-3" />
                                </button>
                                <div className="flex gap-3">
                                    <div className="w-10 h-10 rounded-full bg-white border border-slate-100 flex items-center justify-center flex-shrink-0 shadow-sm">
                                        <Sparkles className="w-4 h-4 text-slate-800" />
                                    </div>
                                    <div className="flex-1">
                                        <p className="text-sm font-bold text-gray-900 mb-0.5">
                                            {personaName} is here
                                        </p>
                                        <p className="text-xs text-gray-500 leading-relaxed">
                                            I can help you discover products, compare options and plan your store visit.
                                        </p>
                                        <button
                                            onClick={() => {
                                                setIsOpen(true);
                                                setShowGreetingPopup(false);
                                            }}
                                            className="mt-2.5 text-xs font-semibold text-slate-900 hover:text-indigo-600 transition-colors"
                                        >
                                            Explore products
                                        </button>
                                    </div>
                                </div>
                                <div className="absolute bottom-[-6px] right-7 w-3 h-3 bg-white/80 border-r border-b border-white rotate-45 backdrop-blur-2xl" />
                            </motion.div>
                        )}
                    </AnimatePresence>

                    {/* FAB Button */}
                    <motion.button
                        whileHover={{ scale: 1.08 }}
                        whileTap={{ scale: 0.92 }}
                        onClick={() => {
                            setIsOpen(true);
                            setShowGreetingPopup(false);
                            fetchAiSettings(); // Fetch immediately if not yet loaded
                        }}
                        className="group relative w-[56px] h-[56px] rounded-full shadow-lg shadow-slate-900/10 flex items-center justify-center overflow-hidden bg-slate-900 border border-slate-800"
                    >
                        <div className="absolute inset-0 bg-white/5 opacity-0 group-hover:opacity-100 transition-opacity" />
                        <Sparkles className="w-6 h-6 text-white relative z-10" />
                        <span className="absolute top-1 right-1 w-3 h-3 bg-green-500 rounded-full border-2 border-slate-900" />
                    </motion.button>
                </motion.div>
            </AnimatePresence>

            {/* Chat Window */}
            <AnimatePresence>
                {isOpen && (
                    <>
                        {/* Mobile backdrop */}
                        <motion.div
                            initial={{ opacity: 0 }}
                            animate={{ opacity: 1 }}
                            exit={{ opacity: 0 }}
                            className="fixed inset-0 bg-black/30 backdrop-blur-sm z-50 md:hidden"
                            onClick={() => setIsOpen(false)}
                        />

                        <motion.div
                            initial={{ opacity: 0, y: 24, scale: 0.96 }}
                            animate={{ opacity: 1, y: 0, scale: 1 }}
                            exit={{ opacity: 0, y: 24, scale: 0.96 }}
                            transition={{ type: "spring", stiffness: 300, damping: 30 }}
                            className="fixed z-50 
                                inset-x-0 bottom-0 md:inset-auto md:bottom-6 md:right-6
                                w-full md:w-[420px] 
                                h-[100dvh] md:h-[640px] md:max-h-[85vh] 
                                bg-white md:rounded-3xl shadow-2xl shadow-black/15 
                                flex flex-col overflow-hidden 
                                md:border md:border-gray-100"
                        >
                            {/* Premium Header */}
                            <div className="relative px-5 py-4 flex items-center justify-between overflow-hidden flex-shrink-0 bg-white border-b border-slate-100">
                                <div className="flex items-center gap-3 relative z-10">
                                    <div className="relative">
                                        <div className="w-10 h-10 rounded-full bg-slate-50 border border-slate-100 flex items-center justify-center">
                                            <Sparkles className="w-4 h-4 text-slate-800" />
                                        </div>
                                        <span className="absolute bottom-0 right-0 w-2.5 h-2.5 bg-green-500 rounded-full border-2 border-white" />
                                    </div>
                                    <div>
                                        <h3 className="font-semibold text-[15px] text-slate-900 tracking-tight">
                                            {personaName}
                                        </h3>
                                        <p className="text-xs text-slate-500 font-medium tracking-wide uppercase">
                                            Product discovery · Purchase in store
                                        </p>
                                    </div>
                                </div>

                                <div className="flex items-center gap-1 relative z-10">
                                    <button
                                        onClick={clearChat}
                                        className="p-2 hover:bg-slate-50 rounded-full transition-colors text-slate-400 hover:text-slate-600"
                                        title="Clear chat"
                                    >
                                        <Trash2 className="w-4 h-4" />
                                    </button>
                                    <button
                                        onClick={() => setIsOpen(false)}
                                        className="p-2 hover:bg-slate-50 rounded-full transition-colors text-slate-400 hover:text-slate-600"
                                    >
                                        <X className="w-5 h-5" />
                                    </button>
                                </div>
                            </div>

                            {/* Messages Area */}
                            <div
                                ref={messagesContainerRef}
                                className="flex-1 overflow-y-auto px-4 py-6 space-y-6 bg-white relative"
                            >
                                {messages.map((msg) => (
                                    <motion.div
                                        key={msg.id}
                                        initial={{ opacity: 0, y: 12 }}
                                        animate={{ opacity: 1, y: 0 }}
                                        transition={{ duration: 0.3, ease: "easeOut" }}
                                        className={`flex flex-col ${msg.role === "user" ? "items-end" : "items-start"
                                            }`}
                                    >
                                        {/* Avatar for assistant */}
                                        {msg.role === "assistant" && (
                                            <div className="flex items-center gap-2 mb-1.5">
                                                <div className="w-5 h-5 rounded-full bg-slate-50 border border-slate-100 flex items-center justify-center">
                                                    <Sparkles className="w-2.5 h-2.5 text-slate-800" />
                                                </div>
                                                <span className="text-xs font-semibold text-slate-500">
                                                    {personaName}
                                                </span>
                                            </div>
                                        )}

                                        <div
                                            className={`max-w-[85%] px-4 py-3 text-[14px] leading-relaxed ${msg.role === "user"
                                                ? "bg-slate-900 text-white rounded-[20px] rounded-br-[4px] shadow-sm font-medium"
                                                : "bg-white text-slate-800 rounded-[20px] rounded-tl-[4px] border border-slate-200 shadow-sm"
                                                }`}
                                        >
                                            {msg.role === "assistant" && msg.id !== "welcome" && msg.id !== "welcome-contextual" && messages[messages.length - 1].id === msg.id ? (
                                                <TypewriterText content={msg.content} />
                                            ) : (
                                                <div className="whitespace-pre-wrap">{msg.content}</div>
                                            )}
                                        </div>

                                        {/* Product Cards */}
                                        {msg.products && msg.products.length > 0 && (
                                            <div className="mt-3 w-full space-y-2">
                                                {msg.products.map((product) => (
                                                    <Link
                                                        key={product.id}
                                                        href={`/products/${product.id}`}
                                                        className="flex items-center gap-3 p-3 bg-white rounded-2xl border border-slate-100 hover:border-slate-300 transition-[transform,opacity,background-color,border-color,color,box-shadow] group shadow-sm hover:shadow"
                                                    >
                                                        <div className="relative w-16 h-16 bg-gray-50 rounded-xl overflow-hidden flex-shrink-0">
                                                            {product.imageUrl ? (
                                                                <Image
                                                                    src={product.imageUrl}
                                                                    alt={product.name}
                                                                    fill
                                                                    className="object-cover group-hover:scale-105 transition-transform duration-300"
                                                                    quality={90}
                                                                    sizes="64px"
                                                                />
                                                            ) : (
                                                                <div className="w-full h-full flex items-center justify-center">
                                                                    <Package className="w-6 h-6 text-gray-300" />
                                                                </div>
                                                            )}
                                                        </div>
                                                        <div className="flex-1 min-w-0">
                                                            <h4 className="font-semibold text-[13px] text-gray-900 truncate group-hover:text-indigo-600 transition-colors">
                                                                {product.name}
                                                            </h4>
                                                            <p className="text-xs text-gray-400 line-clamp-1 mb-1">
                                                                {product.description}
                                                            </p>
                                                            <div className="flex items-baseline gap-2">
                                                                <span className="font-bold text-sm text-gray-900">
                                                                    ₹{product.price.toLocaleString()}
                                                                </span>
                                                                {product.originalPrice && (
                                                                    <span className="text-xs text-gray-400 line-through">
                                                                        ₹{product.originalPrice.toLocaleString()}
                                                                    </span>
                                                                )}
                                                                {product.originalPrice && (
                                                                    <span className="text-xs font-bold text-green-600 bg-green-50 px-1.5 py-0.5 rounded-md">
                                                                        {Math.round(
                                                                            ((product.originalPrice - product.price) /
                                                                                product.originalPrice) *
                                                                            100
                                                                        )}
                                                                        % off
                                                                    </span>
                                                                )}
                                                            </div>
                                                        </div>
                                                        <div className="p-2 rounded-full bg-slate-50 group-hover:bg-slate-900 group-hover:text-white text-slate-400 transition-[transform,opacity,background-color,border-color,color,box-shadow]">
                                                            <ChevronRight className="w-4 h-4" />
                                                        </div>
                                                    </Link>
                                                ))}
                                                <div className="text-center pt-1">
                                                    <Link
                                                        href="/products"
                                                        className="text-xs font-semibold text-slate-500 hover:text-slate-900 transition-colors"
                                                    >
                                                        View all products →
                                                    </Link>
                                                </div>
                                            </div>
                                        )}

                                        {/* Product Request Link (when no products found) */}
                                        {msg.showRequestLink && (
                                            <div className="mt-3 w-full">
                                                <button
                                                    onClick={() => {
                                                        setRequestModalQuery(msg.queryText || "");
                                                        setIsRequestModalOpen(true);
                                                    }}
                                                    className="w-full flex items-center justify-center gap-2 px-4 py-3 bg-gradient-to-r from-slate-900 to-slate-800 text-white rounded-2xl font-semibold text-[13px] shadow-lg hover:shadow-xl hover:scale-[1.01] active:scale-[0.99] transition-[transform,opacity,background-color,border-color,color,box-shadow]"
                                                >
                                                    <Sparkles className="w-4 h-4" />
                                                    Request This Product
                                                </button>
                                            </div>
                                        )}

                                        {/* Suggested follow-up replies on the latest assistant turn. */}
                                        {msg.role === "assistant" &&
                                            msg.suggestedActions &&
                                            msg.suggestedActions.length > 0 &&
                                            messages[messages.length - 1].id === msg.id &&
                                            !isLoading && (
                                                <div className="mt-3 flex flex-wrap gap-2">
                                                    {msg.suggestedActions.map((action) => (
                                                        <button
                                                            key={action}
                                                            onClick={() => handleSend(undefined, action)}
                                                            className="px-3.5 py-2 bg-white rounded-full border border-slate-200 hover:border-slate-400 hover:shadow-sm active:scale-[0.98] transition-[transform,opacity,background-color,border-color,color,box-shadow] text-[13px] font-medium text-slate-600 hover:text-slate-900 tracking-tight"
                                                        >
                                                            {action}
                                                        </button>
                                                    ))}
                                                </div>
                                            )}
                                        <span className="text-xs text-gray-400 mt-1.5 px-1">
                                            {msg.timestamp instanceof Date
                                                ? msg.timestamp.toLocaleTimeString([], {
                                                    hour: "2-digit",
                                                    minute: "2-digit",
                                                })
                                                : ""}
                                        </span>
                                    </motion.div>
                                ))}

                                {/* Premium Loading Indicator */}
                                {isLoading && (
                                    <motion.div
                                        initial={{ opacity: 0, y: 8 }}
                                        animate={{ opacity: 1, y: 0 }}
                                        className="flex items-start"
                                    >
                                        <div className="flex items-center gap-2 mb-1.5">
                                            <div className="w-5 h-5 rounded-full bg-slate-50 border border-slate-100 flex items-center justify-center">
                                                <Sparkles className="w-2.5 h-2.5 text-slate-800" />
                                            </div>
                                        </div>
                                        <div className="bg-white ml-2 px-4 py-3 rounded-[20px] rounded-tl-[4px] border border-slate-200 shadow-sm flex flex-col gap-2 min-w-[120px]">
                                            <div className="flex items-center gap-2 mb-1">
                                                <Sparkles className="w-3 h-3 text-brand-blue animate-spin-slow" />
                                                <span className="text-xs font-medium text-slate-500 uppercase tracking-wider">Analyzing</span>
                                            </div>
                                            <div className="flex gap-1.5 items-center">
                                                <span className="w-1.5 h-1.5 bg-brand-blue rounded-full animate-bounce" style={{ animationDelay: "0ms" }} />
                                                <span className="w-1.5 h-1.5 bg-brand-blue rounded-full animate-bounce" style={{ animationDelay: "150ms" }} />
                                                <span className="w-1.5 h-1.5 bg-brand-blue rounded-full animate-bounce" style={{ animationDelay: "300ms" }} />
                                            </div>
                                        </div>
                                    </motion.div>
                                )}

                                {/* Quick Actions (show when few messages) */}
                                {messages.length <= 2 && !isLoading && (
                                    <motion.div
                                        initial={{ opacity: 0, y: 12 }}
                                        animate={{ opacity: 1, y: 0 }}
                                        transition={{ delay: 0.3 }}
                                        className="pt-2"
                                    >
                                        <p className="text-xs font-medium text-gray-400 mb-2 px-1">
                                            How can I help you shop today?
                                        </p>
                                        <div className="grid grid-cols-2 gap-2">
                                            {QUICK_ACTIONS.map((action) => {
                                                const Icon = action.icon;
                                                return (
                                                    <button
                                                        key={action.label}
                                                        onClick={() => handleSend(undefined, action.query)}
                                                        className="flex items-center gap-2 px-4 py-2 bg-white rounded-full border border-slate-200 hover:border-slate-400 hover:shadow-sm transition-[transform,opacity,background-color,border-color,color,box-shadow] text-left group"
                                                    >
                                                        <Icon className="w-3.5 h-3.5 text-slate-500 group-hover:text-slate-900 transition-colors" />
                                                        <span className="text-[13px] font-medium text-slate-600 group-hover:text-slate-900 transition-colors tracking-tight">
                                                            {action.label}
                                                        </span>
                                                    </button>
                                                );
                                            })}
                                        </div>
                                    </motion.div>
                                )}

                                <div ref={messagesEndRef} />
                            </div>

                            {/* Scroll to bottom button */}
                            <AnimatePresence>
                                {showScrollDown && (
                                    <motion.button
                                        initial={{ opacity: 0, scale: 0.8 }}
                                        animate={{ opacity: 1, scale: 1 }}
                                        exit={{ opacity: 0, scale: 0.8 }}
                                        onClick={scrollToBottom}
                                        className="absolute bottom-20 left-1/2 -translate-x-1/2 z-10 w-8 h-8 bg-white rounded-full shadow-lg border border-gray-200 flex items-center justify-center hover:bg-gray-50 transition-colors"
                                    >
                                        <ArrowDown className="w-4 h-4 text-gray-500" />
                                    </motion.button>
                                )}
                            </AnimatePresence>

                            {/* Input Area */}
                            <form
                                onSubmit={handleSend}
                                className="p-4 bg-white flex-shrink-0"
                            >
                                <div className="relative flex items-center">
                                    <input
                                        ref={imageInputRef}
                                        type="file"
                                        accept="image/jpeg,image/png,image/webp"
                                        onChange={handleImageSelection}
                                        className="hidden"
                                    />
                                    <div className="absolute left-1.5 flex items-center">
                                        <button
                                            type="button"
                                            onClick={() => imageInputRef.current?.click()}
                                            disabled={isLoading}
                                            className="p-2 rounded-full text-slate-500 hover:bg-white disabled:opacity-40 transition-colors"
                                            title="Search with an image"
                                            aria-label="Search with an image"
                                        >
                                            <ImagePlus className="w-4 h-4" />
                                        </button>
                                        <button
                                            type="button"
                                            onClick={() => setIsBarcodeScannerOpen(true)}
                                            disabled={isLoading}
                                            className="p-2 rounded-full text-slate-500 hover:bg-white disabled:opacity-40 transition-colors"
                                            title="Scan a product barcode"
                                            aria-label="Scan a product barcode"
                                        >
                                            <ScanLine className="w-4 h-4" />
                                        </button>
                                        {aiSettings?.enableVoiceInput && (
                                            <button
                                                type="button"
                                                onClick={handleVoiceToggle}
                                                disabled={isLoading && !isRecording}
                                                className={`p-2 rounded-full transition-colors disabled:opacity-40 ${
                                                    isRecording ? "bg-red-100 text-red-600" : "text-slate-500 hover:bg-white"
                                                }`}
                                                title={isRecording ? "Stop recording" : "Search by voice"}
                                                aria-label={isRecording ? "Stop recording" : "Search by voice"}
                                            >
                                                {isRecording ? <Square className="w-3.5 h-3.5 fill-current" /> : <Mic className="w-4 h-4" />}
                                            </button>
                                        )}
                                    </div>
                                    <input
                                        ref={inputRef}
                                        type="text"
                                        value={inputValue}
                                        onChange={(e) => setInputValue(e.target.value)}
                                        placeholder="Ask about a product or scan its barcode"
                                        disabled={isLoading}
                                        className={`w-full bg-slate-100 rounded-full py-3.5 ${aiSettings?.enableVoiceInput ? "pl-28" : "pl-20"} pr-12 text-[14px] focus:ring-2 focus:ring-slate-900/10 focus:bg-white transition-[transform,opacity,background-color,border-color,color,box-shadow] outline-none md:border border-slate-200 placeholder:text-slate-400`}
                                    />
                                    <button
                                        type="submit"
                                        disabled={!inputValue.trim() || isLoading}
                                        className="absolute right-1.5 p-2 rounded-full bg-slate-900 text-white disabled:opacity-40 disabled:bg-slate-200 transition-[transform,opacity,background-color,border-color,color,box-shadow] active:scale-95 flex items-center justify-center"
                                    >
                                        <Send className="w-4 h-4 ml-0.5" />
                                    </button>
                                </div>
                                <p className="text-xs text-slate-400 text-center mt-3 font-medium tracking-wide">
                                    Smart Avenue 99 • Product, image, voice & barcode search
                                </p>
                            </form>
                        </motion.div>
                    </>
                )}
            </AnimatePresence>

            <BarcodeScanner
                open={isBarcodeScannerOpen}
                onClose={() => setIsBarcodeScannerOpen(false)}
                onDetected={handleBarcodeDetected}
                title="Ask Genie by barcode"
            />

            {/* Product Request Modal */}
            <ProductRequestModal
                isOpen={isRequestModalOpen}
                onClose={() => setIsRequestModalOpen(false)}
                initialQuery={requestModalQuery}
            />
        </>
    );
}
