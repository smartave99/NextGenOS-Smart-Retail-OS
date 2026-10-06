// What the AI assistant will do for a customer, in plain words, worked out from the details being typed. There is no page code here, so the Studio's tests can read this file too
// and check it says what the profile file (lib/aiprofile.mjs) really holds. It never assumes a market: what is not set is said to be neutral.
const TAG = /^[a-z]{2,3}(-[A-Za-z0-9]{2,8})*$/;
const NEUTRAL_KIND = 'a small shop';   // what the program says when nothing names the kind of business (the same as lib/aiprofile.mjs: NEUTRAL)
const text = (v) => (typeof v === 'string' ? v.trim() : '');

/**
 * Returns [{ id, text }]: one line each for the business, the three model photos, the festivals and the second language.
 *   draft: the customer's details, country: the country's entry from the options (or undefined), industry: the kind of business's entry (or undefined), posterKinds: the options' list of poster kinds.
 */
export function aiExplain({ draft, country, industry, posterKinds = [] }) {
  const im = draft?.images ?? {};
  const kind = text(im.countryName) || text(country?.name);
  const shop = text(im.shopKind) || text(industry?.shopKind) || NEUTRAL_KIND;
  const lines = [{ id: 'business', text: `Pictures and posters are made for ${shop}${kind ? ' in ' + kind : ''}.` }];

  for (let i = 0; i < 3; i += 1) {
    const m = Array.isArray(im.models) ? im.models[i] : null;
    const title = text(m?.title) || `Model ${i + 1}`;
    const looks = text(m?.looks);
    lines.push({ id: `model-${i}`, text: `Product photo ${i + 3} is called "${title}". ${looks ? `The person looks like this: ${looks}.` : 'No look is asked for: the AI chooses the person.'}` });
  }

  const festivals = (Array.isArray(im.festivals) ? im.festivals : []).map(text).filter(Boolean);
  lines.push({ id: 'festivals', text: festivals.length ? `Offer posters can name these festivals: ${festivals.join(', ')}.` : 'No festival is named. The occasion of an offer poster is typed in each time.' });

  const l = im.localLanguage ?? {};
  const name = text(l.name);
  const tag = text(l.tag);
  if (name && TAG.test(tag)) {
    const given = posterKinds.filter((k) => text(l.lines?.[k.id])).map((k) => k.label.toLowerCase());
    lines.push({ id: 'language', text: `Posters carry a second line in ${name} (${tag}). ${given.length ? `Ready-made lines for: ${given.join(', ')}. The other posters get their line when the AI writes the poster.` : 'No ready-made lines: the line is written when the AI makes the poster.'}` });
  } else lines.push({ id: 'language', text: 'Posters are in one language.' });
  return lines;
}
