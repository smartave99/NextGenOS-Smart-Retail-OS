'use strict';
// Small helpers for the Studio pages. Nothing here is needed to read the pages; it only makes them easier.
(function () {
  function $(sel, root) { return (root || document).querySelector(sel); }
  function $all(sel, root) { return Array.prototype.slice.call((root || document).querySelectorAll(sel)); }

  // Copy buttons: <button data-copy="#id">
  document.addEventListener('click', function (e) {
    var btn = e.target.closest('[data-copy]');
    if (!btn) return;
    var el = $(btn.getAttribute('data-copy'));
    if (!el) return;
    var text = el.value !== undefined ? el.value : el.textContent;
    var done = function () { var old = btn.textContent; btn.textContent = 'Copied ✓'; setTimeout(function () { btn.textContent = old; }, 1800); };
    if (navigator.clipboard && navigator.clipboard.writeText) { navigator.clipboard.writeText(text).then(done, function () { fallback(el, done); }); } else { fallback(el, done); }
  });
  function fallback(el, done) {
    if (el.select) { el.select(); } else { var r = document.createRange(); r.selectNodeContents(el); var s = window.getSelection(); s.removeAllRanges(); s.addRange(r); }
    try { document.execCommand('copy'); done(); } catch (err) { /* the text is selected; the person can copy it */ }
  }

  // Ask before something that cannot be taken back: <form data-confirm="Are you sure?">
  document.addEventListener('submit', function (e) {
    var msg = e.target.getAttribute && e.target.getAttribute('data-confirm');
    if (msg && !window.confirm(msg)) e.preventDefault();
  });

  // New licence: show the new-customer fields, fill the sizes from the plan, show the website box.
  var form = $('#new-licence');
  if (form) {
    var customer = $('#customerId');
    var newBox = $('#new-customer');
    var syncCustomer = function () { newBox.classList.toggle('hidden', customer.value !== 'new'); };
    customer.addEventListener('change', syncCustomer); syncCustomer();

    var sizes = ['devices', 'stores', 'users'];
    var fillHints = function () {
      var plan = $('input[name=planCode]:checked', form);
      if (!plan) return;
      sizes.forEach(function (k) {
        var input = $('#' + k);
        input.placeholder = plan.getAttribute('data-' + k);
        var cap = plan.getAttribute('data-cap-' + k);
        $('#' + k + '-hint').textContent = 'Plan includes ' + plan.getAttribute('data-' + k) + (cap ? ', up to ' + cap + ' without approval' : '');
      });
    };
    $all('input[name=planCode]', form).forEach(function (r) { r.addEventListener('change', fillHints); });
    fillHints();

    var bind = function () {
      var v = ($('input[name=bindMode]:checked', form) || {}).value;
      $('#domains-box').classList.toggle('hidden', v !== 'domain');
    };
    $all('input[name=bindMode]', form).forEach(function (r) { r.addEventListener('change', bind); });
    bind();
  }

  // Brand logo: read the picture into a hidden field, small pictures only.
  $all('input[data-logo-target]').forEach(function (input) {
    input.addEventListener('change', function () {
      var file = input.files && input.files[0];
      if (!file) return;
      if (file.size > 100 * 1024) { window.alert('That picture is too big. Please use one under 100 KB.'); input.value = ''; return; }
      var reader = new FileReader();
      reader.onload = function () {
        $(input.getAttribute('data-logo-target')).value = reader.result;
        var img = $('#logo-preview');
        if (img) { img.src = reader.result; img.classList.remove('hidden'); }
      };
      reader.readAsDataURL(file);
    });
  });
})();
