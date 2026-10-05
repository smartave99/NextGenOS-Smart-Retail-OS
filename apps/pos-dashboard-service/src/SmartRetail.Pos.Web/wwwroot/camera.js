// The camera, for a product's photos, a photo in Ask AI and finding a product by its look. It starts only when a
// person presses a button, shows a live preview, and takes one still at a time. Every track stops when the dialog
// closes, the page is left or hidden: nothing is ever recorded. Stills are JPEG (at most 2000 px on the long side, no
// EXIF, so no location), kept here until the dashboard takes them.
(function () {
    const streams = new Map();   // video element -> { stream, devices, index }
    const stills = new Map();    // id -> { blob, url }
    let nextId = 1;
    const MAX_SIDE = 2000;

    function problem(error) {
        const name = error && error.name;
        if (name === 'NotAllowedError' || name === 'SecurityError') {
            return window.srpos && window.srpos.inApp
                ? 'The camera is turned off for apps. In Windows Settings, open Privacy & security, then Camera, and let desktop apps use the camera.'
                : 'The camera is blocked for this page. Allow it in the browser (the camera sign in the address bar), then try again.';
        }
        if (name === 'NotFoundError' || name === 'OverconstrainedError') return 'No camera was found. Connect a webcam, or add photos from files.';
        if (name === 'NotReadableError' || name === 'AbortError') return 'The camera is busy in another app. Close that app, then try again.';
        return 'The camera could not start here. Add photos from files instead.';
    }

    async function open(video, deviceId) {
        const constraints = deviceId
            ? { video: { deviceId: { exact: deviceId }, width: { ideal: 1920 }, height: { ideal: 1080 } }, audio: false }
            : { video: { facingMode: { ideal: 'environment' }, width: { ideal: 1920 }, height: { ideal: 1080 } }, audio: false };
        try {
            return await navigator.mediaDevices.getUserMedia(constraints);
        } catch (error) {
            if (error && error.name === 'OverconstrainedError') {
                return navigator.mediaDevices.getUserMedia({ video: true, audio: false });
            }
            throw error;
        }
    }

    function stopTracks(video) {
        const held = streams.get(video);
        if (held) held.stream.getTracks().forEach(track => track.stop());
        streams.delete(video);
        if (video) video.srcObject = null;
    }

    const camera = {
        supported() {
            return !!(navigator.mediaDevices && navigator.mediaDevices.getUserMedia);
        },

        /** Starts the preview; { ok, cameras } or { ok: false, problem }. */
        async start(video, deviceId) {
            if (!camera.supported()) return { ok: false, problem: 'This browser cannot use a camera here. Add photos from files instead.' };
            stopTracks(video);
            try {
                const stream = await open(video, deviceId);
                const devices = (await navigator.mediaDevices.enumerateDevices()).filter(d => d.kind === 'videoinput');
                const track = stream.getVideoTracks()[0];
                const current = track && track.getSettings ? track.getSettings().deviceId : null;
                streams.set(video, { stream, devices, index: Math.max(0, devices.findIndex(d => d.deviceId === current)) });
                video.srcObject = stream;
                video.muted = true;
                video.setAttribute('playsinline', '');
                await video.play().catch(() => { /* shown anyway once data comes */ });
                return { ok: true, cameras: devices.length };
            } catch (error) {
                stopTracks(video);
                return { ok: false, problem: problem(error) };
            }
        },

        /** The next camera, when there is more than one. */
        async next(video) {
            const held = streams.get(video);
            if (!held || held.devices.length < 2) return { ok: true, cameras: held ? held.devices.length : 0 };
            const device = held.devices[(held.index + 1) % held.devices.length];
            return camera.start(video, device.deviceId);
        },

        /** Takes a still from the preview; { id, url, width, height }. The preview keeps running for a retake. */
        async capture(video) {
            const width = video.videoWidth, height = video.videoHeight;
            if (!width || !height) return null;
            const scale = Math.min(1, MAX_SIDE / Math.max(width, height));
            const canvas = document.createElement('canvas');
            canvas.width = Math.round(width * scale);
            canvas.height = Math.round(height * scale);
            canvas.getContext('2d').drawImage(video, 0, 0, canvas.width, canvas.height);
            const blob = await new Promise(done => canvas.toBlob(done, 'image/jpeg', 0.9));
            if (!blob) return null;
            const id = 'still-' + nextId++;
            stills.set(id, { blob, url: URL.createObjectURL(blob) });
            return { id, url: stills.get(id).url, width: canvas.width, height: canvas.height };
        },

        /** Stops the camera: every track, at once. */
        stop(video) {
            stopTracks(video);
        },

        /** Forgets a still that was not used. */
        discard(id) {
            const still = stills.get(id);
            if (still) URL.revokeObjectURL(still.url);
            stills.delete(id);
        },

        /** The still's bytes, for the dashboard to keep (read as a stream by .NET); the still is then forgotten. */
        async take(id) {
            const still = stills.get(id);
            if (!still) return new Uint8Array(0);
            const bytes = new Uint8Array(await still.blob.arrayBuffer());
            camera.discard(id);
            return bytes;
        },

        /** Hands the still to Ask AI's box, to be sent with the question; false (the still kept) when the box is full. */
        giveToChat(id, composer) {
            const still = stills.get(id);
            if (!still || !window.srposChat || !window.srposChat.add(composer, still.blob, 'photo')) return false;
            camera.discard(id);
            return true;
        },

        /** How many cameras are running (for tests: none once a dialog closes). */
        running() {
            let live = 0;
            for (const held of streams.values()) live += held.stream.getTracks().filter(t => t.readyState === 'live').length;
            return live;
        },
    };

    // Leaving or hiding the page stops any camera still on.
    const stopAll = () => { for (const video of [...streams.keys()]) stopTracks(video); };
    window.addEventListener('pagehide', stopAll);
    document.addEventListener('visibilitychange', () => { if (document.hidden) stopAll(); });

    window.srposCamera = camera;
})();
