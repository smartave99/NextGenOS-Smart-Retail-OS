// Photos and voice notes in Ask AI's box. Photos come from files, a paste, a drop or the camera; a voice note is
// recorded with the microphone, only while the button shows it, and made into a WAV file (16 kHz, mono) that the AI can
// read. They wait in the box, with a way to remove each, until the question is sent: the dashboard then takes them
// (srposChat.take) and keeps them on the PC for the chat. Photos are made at most 2000 px on the long side, without EXIF.
(function () {
    const MAX_FILES = 4;
    const MAX_SIDE = 2000;
    const boxes = new Map();   // composer element -> [{ id, kind, blob, url, seconds }]
    let nextId = 1;
    let recording = null;      // { composer, recorder, stream, chunks, started }

    function filesOf(composer) {
        if (!boxes.has(composer)) boxes.set(composer, []);
        return boxes.get(composer);
    }

    function tray(composer) {
        const wrap = composer.closest('.composer-wrap, .panel-foot') || composer.parentElement;
        return wrap && wrap.querySelector('[data-files]');
    }

    function say(composer, text) {
        const wrap = composer.closest('.composer-wrap, .panel-foot') || composer.parentElement;
        const note = wrap && wrap.querySelector('[data-files-note]');
        if (note) {
            note.textContent = text || '';
            note.hidden = !text;
        }
    }

    function draw(composer) {
        const holder = tray(composer);
        if (!holder) return;
        holder.replaceChildren();
        for (const file of filesOf(composer)) {
            const item = document.createElement('div');
            item.className = 'composer-file ' + file.kind;
            if (file.kind === 'photo') {
                const img = document.createElement('img');
                img.src = file.url;
                img.alt = 'Photo to send';
                item.appendChild(img);
            } else {
                const label = document.createElement('span');
                const seconds = Math.max(1, Math.round(file.seconds || 0));
                label.textContent = 'Voice note ' + Math.floor(seconds / 60) + ':' + String(seconds % 60).padStart(2, '0');
                item.appendChild(label);
            }
            const remove = document.createElement('button');
            remove.type = 'button';
            remove.className = 'composer-file-remove';
            remove.setAttribute('aria-label', file.kind === 'photo' ? 'Remove this photo' : 'Remove this voice note');
            remove.textContent = '×';
            remove.addEventListener('click', () => chat.remove(composer, file.id));
            item.appendChild(remove);
            holder.appendChild(item);
        }
        holder.hidden = filesOf(composer).length === 0;
    }

    /** A picture file as a JPEG at most 2000 px on the long side, turned the right way up, without EXIF. */
    async function shrink(file) {
        const bitmap = await createImageBitmap(file);
        const scale = Math.min(1, MAX_SIDE / Math.max(bitmap.width, bitmap.height));
        const canvas = document.createElement('canvas');
        canvas.width = Math.max(1, Math.round(bitmap.width * scale));
        canvas.height = Math.max(1, Math.round(bitmap.height * scale));
        canvas.getContext('2d').drawImage(bitmap, 0, 0, canvas.width, canvas.height);
        bitmap.close && bitmap.close();
        return new Promise(done => canvas.toBlob(done, 'image/jpeg', 0.9));
    }

    /** Recorded sound as a 16 kHz mono WAV file. */
    async function toWave(blob) {
        const context = new (window.AudioContext || window.webkitAudioContext)();
        try {
            const decoded = await context.decodeAudioData(await blob.arrayBuffer());
            const rate = 16000;
            const offline = new OfflineAudioContext(1, Math.max(1, Math.ceil(decoded.duration * rate)), rate);
            const source = offline.createBufferSource();
            source.buffer = decoded;
            source.connect(offline.destination);
            source.start();
            const samples = (await offline.startRendering()).getChannelData(0);
            const bytes = new DataView(new ArrayBuffer(44 + samples.length * 2));
            const text = (at, value) => { for (let i = 0; i < value.length; i++) bytes.setUint8(at + i, value.charCodeAt(i)); };
            text(0, 'RIFF'); bytes.setUint32(4, 36 + samples.length * 2, true); text(8, 'WAVE');
            text(12, 'fmt '); bytes.setUint32(16, 16, true); bytes.setUint16(20, 1, true); bytes.setUint16(22, 1, true);
            bytes.setUint32(24, rate, true); bytes.setUint32(28, rate * 2, true); bytes.setUint16(32, 2, true); bytes.setUint16(34, 16, true);
            text(36, 'data'); bytes.setUint32(40, samples.length * 2, true);
            for (let i = 0; i < samples.length; i++) {
                const value = Math.max(-1, Math.min(1, samples[i]));
                bytes.setInt16(44 + i * 2, value < 0 ? value * 0x8000 : value * 0x7fff, true);
            }
            return { blob: new Blob([bytes.buffer], { type: 'audio/wav' }), seconds: decoded.duration };
        } finally {
            context.close && context.close();
        }
    }

    const chat = {
        /** Hooks up a box: pasting or dropping pictures adds them. */
        init(composer) {
            if (!composer || composer.dataset.files) return;
            composer.dataset.files = '1';
            const picker = composer.querySelector('input[type=file][data-pick]');
            if (picker) {
                picker.addEventListener('change', async () => {
                    await chat.addFiles(composer, [...picker.files]);
                    picker.value = '';
                });
            }
            composer.addEventListener('paste', (e) => {
                const pictures = [...(e.clipboardData ? e.clipboardData.files : [])].filter(f => f.type.startsWith('image/'));
                if (pictures.length && composer.dataset.photos === '1') {
                    e.preventDefault();
                    chat.addFiles(composer, pictures);
                }
            });
            composer.addEventListener('dragover', (e) => {
                if (composer.dataset.photos === '1' && e.dataTransfer && [...e.dataTransfer.types].includes('Files')) {
                    e.preventDefault();
                    composer.classList.add('dropping');
                }
            });
            composer.addEventListener('dragleave', () => composer.classList.remove('dropping'));
            composer.addEventListener('drop', (e) => {
                composer.classList.remove('dropping');
                if (composer.dataset.photos !== '1' || !e.dataTransfer) return;
                const pictures = [...e.dataTransfer.files].filter(f => f.type.startsWith('image/'));
                if (pictures.length) {
                    e.preventDefault();
                    chat.addFiles(composer, pictures);
                }
            });
        },

        /** Opens the file picker. */
        pick(composer) {
            const picker = composer && composer.querySelector('input[type=file][data-pick]');
            if (picker) picker.click();
        },

        async addFiles(composer, files) {
            say(composer, '');
            for (const file of files) {
                if (filesOf(composer).length >= MAX_FILES) {
                    say(composer, 'Send at most ' + MAX_FILES + ' photos or voice notes with one question.');
                    break;
                }
                if (!/^image\/(jpeg|png|webp|gif|bmp|heic|heif)$/.test(file.type)) {
                    say(composer, 'Only photos can be added here.');
                    continue;
                }
                try {
                    chat.add(composer, await shrink(file), 'photo');
                } catch {
                    say(composer, 'That picture could not be read.');
                }
            }
        },

        /** Adds a photo or voice note (a Blob); false, saying why, when the box is full. */
        add(composer, blob, kind, seconds) {
            const files = filesOf(composer);
            if (!blob) return false;
            if (files.length >= MAX_FILES) {
                say(composer, 'Send at most ' + MAX_FILES + ' photos or voice notes with one question.');
                return false;
            }
            files.push({ id: 'file-' + nextId++, kind, blob, url: URL.createObjectURL(blob), seconds });
            draw(composer);
            return true;
        },

        remove(composer, id) {
            const files = filesOf(composer);
            const at = files.findIndex(f => f.id === id);
            if (at >= 0) {
                URL.revokeObjectURL(files[at].url);
                files.splice(at, 1);
            }
            draw(composer);
        },

        /** What waits in the box: [{ id, kind }]. */
        list(composer) {
            return composer ? filesOf(composer).map(f => ({ id: f.id, kind: f.kind })) : [];
        },

        /** A waiting file's bytes, for the dashboard to keep (read as a stream by .NET). */
        async take(composer, id) {
            const file = filesOf(composer).find(f => f.id === id);
            return file ? new Uint8Array(await file.blob.arrayBuffer()) : new Uint8Array(0);
        },

        /** Empties the box once the question is sent. */
        clear(composer) {
            for (const file of filesOf(composer)) URL.revokeObjectURL(file.url);
            boxes.set(composer, []);
            draw(composer);
            say(composer, '');
        },

        /** Starts recording a voice note; { ok } or { ok: false, problem }. */
        async record(composer) {
            if (recording) return { ok: true };
            if (!navigator.mediaDevices || !window.MediaRecorder) {
                return { ok: false, problem: 'This browser cannot record here. Type the question instead.' };
            }
            if (filesOf(composer).length >= MAX_FILES) {
                return { ok: false, problem: 'Send at most ' + MAX_FILES + ' photos or voice notes with one question.' };
            }
            try {
                const stream = await navigator.mediaDevices.getUserMedia({ audio: true, video: false });
                const recorder = new MediaRecorder(stream);
                const chunks = [];
                recorder.ondataavailable = (e) => { if (e.data && e.data.size) chunks.push(e.data); };
                recorder.start();
                recording = { composer, recorder, stream, chunks, started: Date.now() };
                return { ok: true };
            } catch (error) {
                const blocked = error && (error.name === 'NotAllowedError' || error.name === 'SecurityError');
                return {
                    ok: false,
                    problem: blocked
                        ? 'The microphone is turned off for this app. In Windows Settings, open Privacy & security, then Microphone, and let desktop apps use it.'
                        : 'No microphone could be used. Type the question instead.',
                };
            }
        },

        /** Stops recording and adds the voice note to the box; { ok, seconds } or { ok: false, problem }. */
        async stop() {
            const held = recording;
            recording = null;
            if (!held) return { ok: false, problem: '' };
            const stopped = new Promise(done => { held.recorder.onstop = done; });
            held.recorder.stop();
            await stopped;
            held.stream.getTracks().forEach(track => track.stop());
            try {
                const wave = await toWave(new Blob(held.chunks, { type: held.recorder.mimeType || 'audio/webm' }));
                if (wave.seconds < 0.3) return { ok: false, problem: 'That was too short to hear. Hold on a little longer.' };
                chat.add(held.composer, wave.blob, 'voice', wave.seconds);
                return { ok: true, seconds: wave.seconds };
            } catch {
                return { ok: false, problem: 'The recording could not be read. Try again, or type the question.' };
            }
        },

        /** Stops without keeping anything, e.g. when the page is left. */
        cancel() {
            const held = recording;
            recording = null;
            if (!held) return;
            try { held.recorder.stop(); } catch { /* already stopped */ }
            held.stream.getTracks().forEach(track => track.stop());
        },

        /** Windows voice typing (Win+H), inside the app: the box gets the focus, then the app starts it. */
        dictate(textarea) {
            if (textarea && textarea.focus) textarea.focus();
            return window.srpos ? window.srpos.send('dictate') : false;
        },
    };

    window.addEventListener('pagehide', () => chat.cancel());
    window.srposChat = chat;
})();
