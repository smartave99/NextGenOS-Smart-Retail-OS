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

// The look of this screen (decision 30): a PC or laptop gets the list look, a touch screen the counter look. In order: this browser's own choice, the shop's choice,
// and for "auto" what the screen is. These values are the same as in Branding/ShopLook.cs (a test keeps them equal). No choice at all: the layout the page came with.
try {
  var root = document.documentElement;
  var looks = {
    list: { density: 'comfortable', nav: 'top', navLabels: 'full', cart: 'bottom', scale: '1.00' },
    counter: { density: 'touch', nav: 'left', navLabels: 'full', cart: 'right', scale: '1.10' }
  };
  var own = null;
  try { own = localStorage.getItem('hub-look'); } catch (e) { /* storage may be off */ }
  var shopLook = root.getAttribute('data-look-shop') || 'standard';
  var pick = (own === 'list' || own === 'counter') ? own
    : (shopLook === 'list' || shopLook === 'counter') ? shopLook
    : shopLook === 'auto' ? (window.matchMedia && window.matchMedia('(pointer: coarse)').matches ? 'counter' : 'list')
    : null;
  if (pick) {
    var look = looks[pick];
    root.setAttribute('data-density', look.density);
    root.setAttribute('data-nav', look.nav);
    root.setAttribute('data-nav-labels', look.navLabels);
    root.setAttribute('data-cart', look.cart);
    root.setAttribute('data-scale', look.scale);
  }
  root.setAttribute('data-look', pick || 'standard');
} catch (e) { /* the layout the page came with is used */ }
