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
    // The look of this computer only (decision 30): "list" or "counter"; anything else goes back to the shop's choice. The page is drawn again with it.
    setLook: function (value) {
      try { if (value === 'list' || value === 'counter') localStorage.setItem('hub-look', value); else localStorage.removeItem('hub-look'); } catch (e) { /* storage may be off */ }
      location.reload();
    },
    print: function () { window.print(); },
    focus: function (id) { var el = document.getElementById(id); if (el) { el.focus(); if (el.select) el.select(); } },
    csrf: token
  };
  document.addEventListener('click', function (e) {
    var b = e.target && e.target.closest ? e.target.closest('[data-set-look]') : null;
    if (b) { e.preventDefault(); window.hub.setLook(b.getAttribute('data-set-look')); }
  });
})();
