"use client";

import { RefObject, useEffect, useRef } from "react";

const FOCUSABLE_SELECTOR = [
    "a[href]",
    "button:not([disabled])",
    "input:not([disabled])",
    "select:not([disabled])",
    "textarea:not([disabled])",
    "[tabindex]:not([tabindex='-1'])",
].join(",");

interface DialogFocusOptions {
    open: boolean;
    onClose: () => void;
    containerRef: RefObject<HTMLElement | null>;
    initialFocusRef?: RefObject<HTMLElement | null>;
    returnFocusRef?: RefObject<HTMLElement | null>;
}

/**
 * Gives sheets and dialogs the keyboard behaviour expected by WCAG 2.2:
 * Escape closes, Tab remains inside, background scroll stops, and focus returns.
 */
export function useDialogFocus({
    open,
    onClose,
    containerRef,
    initialFocusRef,
    returnFocusRef,
}: DialogFocusOptions) {
    const previouslyFocusedRef = useRef<HTMLElement | null>(null);

    useEffect(() => {
        if (!open) return;

        previouslyFocusedRef.current = document.activeElement instanceof HTMLElement
            ? document.activeElement
            : null;
        const previousOverflow = document.body.style.overflow;
        document.body.style.overflow = "hidden";

        const focusInitialControl = window.requestAnimationFrame(() => {
            const firstFocusable = containerRef.current?.querySelector<HTMLElement>(FOCUSABLE_SELECTOR);
            (initialFocusRef?.current || firstFocusable || containerRef.current)?.focus();
        });

        const handleKeyDown = (event: KeyboardEvent) => {
            if (event.key === "Escape") {
                event.preventDefault();
                onClose();
                return;
            }

            if (event.key !== "Tab" || !containerRef.current) return;
            const focusable = Array.from(
                containerRef.current.querySelectorAll<HTMLElement>(FOCUSABLE_SELECTOR)
            ).filter((element) => !element.hasAttribute("hidden") && element.offsetParent !== null);

            if (focusable.length === 0) {
                event.preventDefault();
                containerRef.current.focus();
                return;
            }

            const first = focusable[0];
            const last = focusable[focusable.length - 1];
            if (event.shiftKey && document.activeElement === first) {
                event.preventDefault();
                last.focus();
            } else if (!event.shiftKey && document.activeElement === last) {
                event.preventDefault();
                first.focus();
            }
        };

        window.addEventListener("keydown", handleKeyDown);
        return () => {
            window.cancelAnimationFrame(focusInitialControl);
            window.removeEventListener("keydown", handleKeyDown);
            document.body.style.overflow = previousOverflow;
            window.requestAnimationFrame(() => {
                (returnFocusRef?.current || previouslyFocusedRef.current)?.focus();
            });
        };
    }, [containerRef, initialFocusRef, onClose, open, returnFocusRef]);
}
