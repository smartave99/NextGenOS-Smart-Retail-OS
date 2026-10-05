// The Creatives studio in the page: price tags staff can move on the picture (drag, or the arrow keys), and the
// export, drawn on a canvas at the creative's exact size: the picture made by the AI, fitted as the preview shows it,
// with each price tag drawn by the app from the POS's figures. The same proportions as app.css's .ctag, so the export
// is what the preview shows.
(function () {
    // A tag, as shares of the picture's width: its size, corner, padding and the size of each line.
    const TAG = { width: 0.26, height: 0.13, radius: 0.02, padding: 0.016, name: 0.02, nameLine: 0.026, price: 0.056, longPrice: 0.047, priceLine: 0.06, was: 0.02, wasLine: 0.026 };
    const FONT = 'Inter, "Noto Sans Devanagari", system-ui, sans-serif';
    const watched = new WeakMap();

    function share(value) {
        return Math.round(Math.min(1, Math.max(0, value)) * 10000) / 10000;
    }

    /** Lets staff move the frame's .ctag elements; each move is told to .NET (TagMoved) when it ends. */
    function tags(frame, dotnet) {
        if (!frame || watched.has(frame)) {
            if (frame) watched.get(frame).dotnet = dotnet;
            return;
        }
        const state = { dotnet, drag: null, timer: 0 };
        watched.set(frame, state);

        const report = (tag) => {
            const x = parseFloat(tag.style.left) / 100, y = parseFloat(tag.style.top) / 100;
            state.dotnet.invokeMethodAsync('TagMoved', Number(tag.dataset.index), share(x), share(y)).catch(() => { /* page gone */ });
        };
        const place = (tag, x, y) => {
            const box = frame.getBoundingClientRect();
            const maxX = 1 - tag.offsetWidth / box.width, maxY = 1 - tag.offsetHeight / box.height;
            tag.style.left = (Math.min(maxX, Math.max(0, x)) * 100).toFixed(2) + '%';
            tag.style.top = (Math.min(maxY, Math.max(0, y)) * 100).toFixed(2) + '%';
        };

        frame.addEventListener('pointerdown', (e) => {
            const tag = e.target.closest('.ctag');
            if (!tag || e.button !== 0) return;
            const box = frame.getBoundingClientRect(), own = tag.getBoundingClientRect();
            state.drag = { tag, dx: e.clientX - own.left, dy: e.clientY - own.top, moved: false };
            tag.setPointerCapture(e.pointerId);
            tag.classList.add('dragging');
            e.preventDefault();
        });
        frame.addEventListener('pointermove', (e) => {
            const drag = state.drag;
            if (!drag) return;
            const box = frame.getBoundingClientRect();
            place(drag.tag, (e.clientX - drag.dx - box.left) / box.width, (e.clientY - drag.dy - box.top) / box.height);
            drag.moved = true;
        });
        const end = () => {
            const drag = state.drag;
            state.drag = null;
            if (!drag) return;
            drag.tag.classList.remove('dragging');
            if (drag.moved) report(drag.tag);
        };
        frame.addEventListener('pointerup', end);
        frame.addEventListener('pointercancel', end);
        frame.addEventListener('keydown', (e) => {
            const tag = e.target.closest && e.target.closest('.ctag');
            const step = e.shiftKey ? 0.05 : 0.01;
            const move = { ArrowLeft: [-step, 0], ArrowRight: [step, 0], ArrowUp: [0, -step], ArrowDown: [0, step] }[e.key];
            if (!tag || !move) return;
            e.preventDefault();
            place(tag, parseFloat(tag.style.left) / 100 + move[0], parseFloat(tag.style.top) / 100 + move[1]);
            clearTimeout(state.timer);
            state.timer = setTimeout(() => report(tag), 300);
        });
    }

    function load(url) {
        return new Promise((resolve, reject) => {
            const image = new Image();
            image.onload = () => resolve(image);
            image.onerror = () => reject(new Error('The picture could not be loaded.'));
            image.src = url;
        });
    }

    function roundRect(ctx, x, y, w, h, r) {
        ctx.beginPath();
        ctx.moveTo(x + r, y);
        ctx.arcTo(x + w, y, x + w, y + h, r);
        ctx.arcTo(x + w, y + h, x, y + h, r);
        ctx.arcTo(x, y + h, x, y, r);
        ctx.arcTo(x, y, x + w, y, r);
        ctx.closePath();
    }

    /** Text cut to fit the width, with an ellipsis, as CSS's text-overflow does. */
    function fit(ctx, text, width) {
        if (ctx.measureText(text).width <= width) return text;
        let cut = text;
        while (cut.length > 1 && ctx.measureText(cut + '…').width > width) cut = cut.slice(0, -1);
        return cut.trimEnd() + '…';
    }

    function drawTag(ctx, W, tag) {
        const x = tag.x * ctx.canvas.width, y = tag.y * ctx.canvas.height;
        const w = TAG.width * W, h = TAG.height * W, pad = TAG.padding * W, inner = w - 2 * pad;
        ctx.save();
        ctx.shadowColor = 'rgba(0, 0, 0, 0.25)';
        ctx.shadowBlur = 0.018 * W;
        ctx.shadowOffsetY = 0.006 * W;
        ctx.fillStyle = tag.background;
        roundRect(ctx, x, y, w, h, TAG.radius * W);
        ctx.fill();
        ctx.restore();

        const lines = TAG.nameLine + TAG.priceLine + (tag.was ? TAG.wasLine : 0);
        let top = y + (h - lines * W) / 2;
        ctx.fillStyle = tag.words;
        ctx.textBaseline = 'middle';
        ctx.textAlign = 'left';

        ctx.globalAlpha = 0.92;
        ctx.font = `600 ${TAG.name * W}px ${FONT}`;
        ctx.fillText(fit(ctx, tag.name, inner), x + pad, top + TAG.nameLine * W / 2);
        ctx.globalAlpha = 1;
        top += TAG.nameLine * W;

        ctx.font = `800 ${(tag.long ? TAG.longPrice : TAG.price) * W}px ${FONT}`;
        ctx.fillText(fit(ctx, tag.pays, inner), x + pad, top + TAG.priceLine * W / 2);
        top += TAG.priceLine * W;

        if (tag.was) {
            ctx.font = `500 ${TAG.was * W}px ${FONT}`;
            const middle = top + TAG.wasLine * W / 2;
            const was = tag.was;
            const wasWidth = ctx.measureText(was).width;
            ctx.globalAlpha = 0.85;
            ctx.fillText(was, x + pad, middle);
            ctx.fillRect(x + pad, middle, wasWidth, Math.max(1, 0.0022 * W));
            ctx.globalAlpha = 1;
            if (tag.off) {
                ctx.font = `700 ${TAG.was * W}px ${FONT}`;
                ctx.fillText(fit(ctx, ' · ' + tag.off, inner - wasWidth), x + pad + wasWidth, middle);
            }
        }
    }

    /**
     * The creative as a PNG at its exact size: { width, height, picture, tags: [{ x, y, name, pays, was, off, long,
     * background, words }] }. The picture is fitted to cover the size, as the preview shows it.
     */
    async function render(spec) {
        await Promise.all([document.fonts.load(`800 40px Inter`), document.fonts.load(`600 20px Inter`), document.fonts.load(`500 20px Inter`)]);
        const image = await load(spec.picture);
        const canvas = document.createElement('canvas');
        canvas.width = spec.width;
        canvas.height = spec.height;
        const ctx = canvas.getContext('2d');
        const scale = Math.max(spec.width / image.naturalWidth, spec.height / image.naturalHeight);
        const w = image.naturalWidth * scale, h = image.naturalHeight * scale;
        ctx.imageSmoothingQuality = 'high';
        ctx.drawImage(image, (spec.width - w) / 2, (spec.height - h) / 2, w, h);
        for (const tag of spec.tags || []) drawTag(ctx, spec.width, tag);
        const blob = await new Promise(done => canvas.toBlob(done, 'image/png'));
        if (!blob) throw new Error('The picture could not be exported.');
        return new Uint8Array(await blob.arrayBuffer());
    }

    /** Downloads a file the dashboard serves. */
    function download(url, name) {
        const link = document.createElement('a');
        link.href = url;
        link.download = name || '';
        document.body.appendChild(link);
        link.click();
        link.remove();
    }

    /** Brings the picture into view after Make it or Change it, which sit lower on the page. */
    function show(element) {
        if (element && element.scrollIntoView) element.scrollIntoView({ block: 'nearest', behavior: 'smooth' });
    }

    window.srposCreative = { tags, render, download, show };
})();
