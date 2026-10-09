// Small helpers the screens call: signing out, the light/dark choice, printing, focusing a box, downloading nothing from anywhere else.
(function () {
  function token() { var m = document.querySelector('meta[name="csrf"]'); return m ? m.content : ''; }
  window.hub = {
    signOut: async function () {
      try { await fetch('/logout', { method: 'POST', headers: { 'RequestVerificationToken': token() }, credentials: 'same-origin' }); } catch (e) { /* signing in again fixes it */ }
      location.href = '/login';
    },
    setTheme: function (value) {
      try { if (value === 'light' || value === 'dark') { localStorage.setItem('hub-theme', value); document.documentElement.setAttribute('data-theme', value); } else { localStorage.removeItem('hub-theme'); document.documentElement.removeAttribute('data-theme'); } } catch (e) { /* ignore */ }
    },
    // The look in force now: the person's own choice, else what the business was set up with, else the PC's own light or dark.
    theme: function () {
      try { var own = localStorage.getItem('hub-theme'); if (own === 'light' || own === 'dark') return own; } catch (e) { /* storage may be off */ }
      var set = document.documentElement.getAttribute('data-theme');
      if (set === 'light' || set === 'dark') return set;
      return window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    },
    // The look of this computer only (decision 30): "top", "list" or "counter"; anything else goes back to the shop's choice. The page is drawn again with it.
    setLook: function (value) {
      try { if (value === 'top' || value === 'list' || value === 'counter') localStorage.setItem('hub-look', value); else localStorage.removeItem('hub-look'); } catch (e) { /* storage may be off */ }
      location.reload();
    },
    print: function () { window.print(); },
    focus: function (id) { var el = document.getElementById(id); if (el) { el.focus(); if (el.select) el.select(); } },
    csrf: token,
    // Keys of the sell screen: the page hands over the keys in force (key text -> action) and is told when one is pressed. The map is the shop's own (Settings), never written here.
    keys: {
      _handler: null,
      name: function (e) {
        var key = null;
        if (/^F([1-9]|1[0-2])$/.test(e.key)) key = e.key;
        else if (e.code && /^Key[A-Z]$/.test(e.code)) key = e.code.slice(3);
        else if (e.code && /^Digit[0-9]$/.test(e.code)) key = e.code.slice(5);
        if (!key) return null;
        return (e.ctrlKey ? 'Ctrl+' : '') + (e.altKey ? 'Alt+' : '') + (e.shiftKey ? 'Shift+' : '') + key;
      },
      start: function (ref, map) {
        window.hub.keys.stop();
        window.hub.keys._handler = function (e) {
          var action = map[window.hub.keys.name(e)];
          if (!action) return;
          e.preventDefault();
          ref.invokeMethodAsync('OnTillKey', action).catch(function () { /* the page was closed */ });
        };
        document.addEventListener('keydown', window.hub.keys._handler, true);
      },
      stop: function () {
        if (window.hub.keys._handler) document.removeEventListener('keydown', window.hub.keys._handler, true);
        window.hub.keys._handler = null;
      }
    }
  };
  document.addEventListener('click', function (e) {
    var b = e.target && e.target.closest ? e.target.closest('[data-set-look]') : null;
    if (b) { e.preventDefault(); window.hub.setLook(b.getAttribute('data-set-look')); }
  });
})();
