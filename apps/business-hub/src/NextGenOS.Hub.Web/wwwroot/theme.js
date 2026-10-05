// Before anything is drawn: light or dark as chosen in Settings, so the page never flashes the other one.
try {
  var theme = localStorage.getItem('hub-theme');
  if (theme === 'light' || theme === 'dark') document.documentElement.setAttribute('data-theme', theme);
} catch (e) { /* storage may be off: the PC's own light or dark is used */ }
