// Reading barcodes with a camera. Where the browser can do it itself (BarcodeDetector: Chrome, Edge, Android) nothing leaves the PC;
// everywhere else a picture goes to this program's own /api/scan, which reads it. Only the picture is sent, and only to this program.
(function () {
  var state = { stream: null, timer: null, busy: false, last: '', lastAt: 0 };

  function token() { var m = document.querySelector('meta[name="csrf"]'); return m ? m.content : ''; }

  async function detectLocal(detector, canvas) {
    var codes = await detector.detect(canvas);
    return codes.length ? codes[0].rawValue : null;
  }

  async function detectRemote(canvas) {
    var blob = await new Promise(function (res) { canvas.toBlob(res, 'image/jpeg', 0.8); });
    if (!blob) return null;
    var r = await fetch('/api/scan', { method: 'POST', headers: { 'Content-Type': 'image/jpeg', 'RequestVerificationToken': token() }, body: blob, credentials: 'same-origin' });
    if (!r.ok) return null;
    var j = await r.json();
    return j.text || null;
  }

  window.hubScan = {
    supported: function () { return !!(navigator.mediaDevices && navigator.mediaDevices.getUserMedia); },
    start: async function (videoId, dotnet) {
      window.hubScan.stop();
      var video = document.getElementById(videoId);
      if (!video) return 'There is no place to show the camera.';
      try {
        state.stream = await navigator.mediaDevices.getUserMedia({ video: { facingMode: 'environment', width: { ideal: 1280 } }, audio: false });
      } catch (e) {
        return e && e.name === 'NotAllowedError' ? 'The camera is blocked. Allow it for this page in the browser, then try again.' : 'No camera could be started on this device.';
      }
      video.srcObject = state.stream;
      await video.play().catch(function () { });
      var detector = null;
      if ('BarcodeDetector' in window) {
        try { detector = new BarcodeDetector(); } catch (e) { detector = null; }
      }
      var canvas = document.createElement('canvas');
      state.timer = setInterval(async function () {
        if (state.busy || !video.videoWidth) return;
        state.busy = true;
        try {
          var scale = Math.min(1, 1280 / video.videoWidth);
          canvas.width = Math.round(video.videoWidth * scale);
          canvas.height = Math.round(video.videoHeight * scale);
          canvas.getContext('2d').drawImage(video, 0, 0, canvas.width, canvas.height);
          var text = detector ? await detectLocal(detector, canvas) : await detectRemote(canvas);
          var now = Date.now();
          if (text && (text !== state.last || now - state.lastAt > 2500)) {
            state.last = text; state.lastAt = now;
            await dotnet.invokeMethodAsync('OnCode', text);
          }
        } catch (e) { /* the next picture will do */ }
        state.busy = false;
      }, 400);
      return '';
    },
    stop: function () {
      if (state.timer) { clearInterval(state.timer); state.timer = null; }
      if (state.stream) { state.stream.getTracks().forEach(function (t) { t.stop(); }); state.stream = null; }
      state.busy = false;
    }
  };
})();
