// Small helpers for the screens. Inside the Smart Retail AI app (a WebView2 window) the page can also talk to
// the app: hide the side panel, open the full window, show the advanced settings.
(function () {
    const root = document.documentElement;
    const webview = window.chrome && window.chrome.webview;
    const darkQuery = window.matchMedia('(prefers-color-scheme: dark)');

    function storedTheme() {
        try {
            const theme = localStorage.getItem('srpos-theme');
            return theme === 'light' || theme === 'dark' ? theme : 'auto';
        } catch {
            return 'auto';
        }
    }

    const srpos = {
        inApp: !!webview,

        /** Sends a message to the Smart Retail AI app; false in a normal browser. */
        send(type, value) {
            if (!webview) return false;
            webview.postMessage(JSON.stringify({ type: type, value: value == null ? '' : String(value) }));
            return true;
        },

        /** True inside the Smart Retail AI app (its window or side panel). */
        isInApp() {
            return !!webview;
        },

        theme: storedTheme,

        isDark() {
            const theme = storedTheme();
            return theme === 'dark' || (theme === 'auto' && darkQuery.matches);
        },

        /** "auto" follows Windows; "light" or "dark" is kept for this PC. */
        setTheme(theme) {
            try {
                if (theme === 'light' || theme === 'dark') localStorage.setItem('srpos-theme', theme);
                else localStorage.removeItem('srpos-theme');
            } catch { /* private window: this visit only */ }
            if (theme === 'light' || theme === 'dark') root.setAttribute('data-theme', theme);
            else root.removeAttribute('data-theme');
            srpos.reportTheme();
        },

        /** The app colours its title bar to match. */
        reportTheme() {
            srpos.send('theme', srpos.isDark() ? 'dark' : 'light');
        },

        copy(text) {
            return navigator.clipboard.writeText(text);
        },

        /** The top bar is on screen: the app window can hide the Windows title bar. */
        frameReady() {
            if (window.srposFrame === 'app') srpos.send('frame', 'ready');
        },

        /** The app window says whether it is maximised, for the top bar's maximise or restore button. */
        windowState(state) {
            root.setAttribute('data-window-state', state === 'maximized' ? 'maximized' : 'normal');
        },

        /** Prints the page; the poster and barcode pages' print styles leave only their pages. Waits for pictures first. */
        async print() {
            const images = [...document.querySelectorAll('.print-me img, .label-pages img')];
            await Promise.all(images.map(img => img.complete ? null : new Promise(done => { img.onload = img.onerror = done; })));
            await document.fonts.ready;
            window.print();
        },

        focus(element) {
            if (element && element.focus) element.focus();
        },

        /**
         * Keeps a chat at its newest words while the reader is there. `end` is an element at the end of the chat; the
         * chat scrolls in its nearest scrolling box, else the page. A reader who scrolled up stays where they are and
         * gets a "Latest" button; `force` (a question just asked) always goes to the end.
         */
        follow(end, force) {
            const scroller = scrollerOf(end);
            const state = followers.get(scroller) || watch(scroller);
            if (force) state.pinned = true;
            if (state.pinned) toEnd(scroller);
            showJump(scroller, state);
        },

        /** Saves text as a file, e.g. an answer's table as CSV (with a byte-order mark, so Excel reads ₹ right). */
        download(fileName, text, type) {
            const blob = new Blob(['\ufeff' + text], { type: (type || 'text/plain') + ';charset=utf-8' });
            const url = URL.createObjectURL(blob);
            const link = document.createElement('a');
            link.href = url;
            link.download = fileName;
            document.body.appendChild(link);
            link.click();
            link.remove();
            setTimeout(() => URL.revokeObjectURL(url), 10000);
        },

        /** The question box: grows with its text, and Enter sends (Shift+Enter starts a new line). */
        composer(textarea) {
            if (!textarea || textarea.dataset.composer) return;
            textarea.dataset.composer = '1';
            textarea.addEventListener('input', () => grow(textarea));
            textarea.addEventListener('keydown', (e) => {
                if (e.key === 'Enter' && !e.shiftKey && !e.isComposing) {
                    e.preventDefault();
                    const send = textarea.closest('.composer').querySelector('.send:not(.stop)');
                    if (send && !send.disabled) send.click();
                }
            });
            grow(textarea);
        },

        /** Takes the typed question out of the box. */
        take(textarea) {
            if (!textarea) return '';
            const text = textarea.value;
            textarea.value = '';
            grow(textarea);
            return text;
        },

        /** Puts a question back, when it could not be sent. */
        put(textarea, text) {
            if (!textarea) return;
            textarea.value = text;
            grow(textarea);
        },

        /** The app calls this when it shows the side panel, so the cashier can type straight away. */
        focusComposer() {
            const box = document.querySelector('.composer textarea');
            if (box) box.focus();
        },
    };

    // The chats being followed, by the box they scroll in.
    const followers = new Map();
    const NEAR_END = 80;

    function scrollerOf(element) {
        for (let node = element && element.parentElement; node && node !== document.body; node = node.parentElement) {
            if (/(auto|scroll)/.test(getComputedStyle(node).overflowY)) return node;
        }
        return document.scrollingElement || document.documentElement;
    }

    function atEnd(scroller) {
        return scroller.scrollHeight - scroller.scrollTop - scroller.clientHeight < NEAR_END;
    }

    function toEnd(scroller) {
        scroller.scrollTop = scroller.scrollHeight;
    }

    function watch(scroller) {
        const state = { pinned: true };
        const target = scroller === document.scrollingElement || scroller === document.documentElement ? window : scroller;
        target.addEventListener('scroll', () => {
            state.pinned = atEnd(scroller);
            showJump(scroller, state);
        }, { passive: true });
        followers.set(scroller, state);
        return state;
    }

    function showJump(scroller, state) {
        const jump = document.querySelector('[data-jump]');
        if (jump) jump.setAttribute('data-show', !state.pinned && !atEnd(scroller) ? '1' : '0');
    }

    function grow(textarea) {
        textarea.style.height = 'auto';
        textarea.style.height = Math.min(textarea.scrollHeight, 160) + 'px';
    }

    window.srpos = srpos;
    if (webview) root.setAttribute('data-host', 'app');

    darkQuery.addEventListener('change', () => srpos.reportTheme());
    window.addEventListener('load', () => srpos.reportTheme());

    // The top bar's window buttons: minimise, maximise or restore, close. Plain clicks, not the page's own events, so
    // they work even when the page has lost the dashboard.
    document.addEventListener('click', (e) => {
        const button = e.target instanceof Element && e.target.closest('[data-window]');
        if (button) srpos.send('window', button.getAttribute('data-window'));

        // "Latest": back to the end of the chat, following it again.
        const jump = e.target instanceof Element && e.target.closest('[data-jump]');
        if (jump) {
            for (const [scroller, state] of followers) {
                if (!document.contains(scroller) && scroller !== document.scrollingElement) {
                    followers.delete(scroller);
                    continue;
                }
                state.pinned = true;
                scroller.scrollTo({ top: scroller.scrollHeight, behavior: 'smooth' });
                jump.setAttribute('data-show', '0');
            }
        }
    });

    document.addEventListener('keydown', (e) => {
        // Ctrl+K: the search box, in the top bar when the app window shows it, else in the sidebar.
        if ((e.ctrlKey || e.metaKey) && !e.altKey && e.key.toLowerCase() === 'k') {
            const top = document.getElementById('top-search');
            const search = top && top.offsetParent !== null ? top : document.getElementById('side-search');
            if (search) {
                e.preventDefault();
                search.focus();
                search.select();
            }
        }

        // Esc in the side panel puts the cashier straight back in the POS, except when it clears the barcode finder or
        // closes the camera.
        if (e.key === 'Escape' && document.querySelector('.panel-page')) {
            const finder = e.target instanceof HTMLInputElement && e.target.closest('.panel-find');
            if (finder && e.target.value !== '') return;
            if (e.target instanceof Element && e.target.closest('.camera-dialog')) return;
            srpos.send('hide');
        }
    });
})();
