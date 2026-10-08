// The words and small rules of the website step that need no page to run (so a test can run them): what is still to be made for a customer, and how a licence file is put in words.

/** A size in words people use. */
export const SIZE = (b) => (b >= 1e9 ? (b / 1e9).toFixed(1) + ' GB' : b >= 1e6 ? Math.round(b / 1e6) + ' MB' : Math.max(1, Math.round(b / 1e3)) + ' KB');

/**
 * What of the customer's website and Android app is still to be made for the latest approved release (from the customer's record of what was made). The website counts as made when
 * a website package was made on the Studio's PC for it, or the build service made it for both systems. The app needs the website's name.
 */
export function siteMissing(c) {
  const release = c.releases.at(-1)?.n;
  const eco = c.intake.ecosystem;
  const made = new Set();
  let packageMade = false;
  for (const b of c.builds ?? []) {
    if (b.release !== release) continue;
    if (b.kind === 'website-local') packageMade = true;
    if (b.kind === 'website-app') for (const p of b.parts ?? []) if (p.status === 'success') made.add(p.id);
  }
  return {
    website: eco.website.wanted && !packageMade && !(made.has('website-linux') && made.has('website-windows')),
    android: eco.android.wanted && !!eco.website.domain && !made.has('android'),
  };
}

/** The licence slot as one sentence and a tone ('ok', 'warn', ''), from what the server says about it. */
export function licenceWords(l) {
  if (!l || l.state === 'none') return { tone: 'warn', text: 'No licence yet: the website will not start until the licence file is added. The website package is still made without it.' };
  if (l.state === 'problem') return { tone: 'warn', text: `The licence file in place cannot be used. ${l.problems.join(' ')}` };
  const bits = [`A licence file is in place (fingerprint ${l.fingerprint}).`];
  if (l.tiedTo?.length) bits.push(`It is tied to ${l.tiedTo.join(', ')}.`);
  bits.push(l.ends ? `It says it ends on ${l.ends}.` : 'It says it has no end date.');
  bits.push('The Studio cannot check its signature: the website does that every time it starts.');
  return { tone: l.trial ? 'warn' : 'ok', text: bits.join(' ') };
}

/** Whether a licence file chosen on this PC is worth sending (the server looks at it properly). */
export function licenceFileProblem(file) {
  if (!file) return 'Choose the licence file first.';
  if (file.size === 0) return 'That file is empty.';
  if (file.size > 20000) return 'That file is too big to be a licence file.';
  return null;
}
