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
    theme: function () { try { return localStorage.getItem('hub-theme') || ''; } catch (e) { return ''; } },
    print: function () { window.print(); },
    focus: function (id) { var el = document.getElementById(id); if (el) { el.focus(); if (el.select) el.select(); } },
    csrf: token
  };
})();
