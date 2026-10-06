// Before anything is drawn: light or dark as chosen in Settings, so the page never flashes the other one.
try {
  var theme = localStorage.getItem('hub-theme');
  if (theme === 'light' || theme === 'dark') document.documentElement.setAttribute('data-theme', theme);
  else {
    // The person has not chosen: the look the business was set up with (light, dark, or the PC's own).
    var set = document.documentElement.getAttribute('data-mode');
    if (set === 'light' || set === 'dark') document.documentElement.setAttribute('data-theme', set);
  }
} catch (e) { /* storage may be off: the PC's own light or dark is used */ }
