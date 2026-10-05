// The hand-over sheet: what the customer gets, how to put it in place, what their licence allows, and who to call. Made from the approved release (not from details that may
// have changed since), once, here: the Studio shows it on screen and the customer pack carries it as a page that prints cleanly.
import { OPTIONS } from './intake.mjs';
import { countryPack, industryPack } from './packs.mjs';

const SYSTEMS = { windows: 'Windows 10 or 11 (64-bit)', linux: 'Ubuntu 22.04 or 24.04, Linux Mint 21 or later, Debian 12 or later' };
const label = (list, id) => list.find((x) => x.id === id)?.label ?? '';
const esc = (t) => String(t ?? '').replace(/[&<>"']/g, (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' })[c]);

/**
 * The sheet as plain data: { title, subtitle, sections: [{ heading, text?, bullets?, steps? }], fingerprint }.
 *   intake: the release's details, info: the release's record, company: { name, supportPhone, supportEmail, website }, pack: what is in the customer pack (optional)
 */
export function handoverFor({ intake: i, info, company = {}, pack = null }) {
  const country = countryPack(i.business.country);
  const industry = industryPack(i.business.industry);
  const device = OPTIONS.deviceKinds.find((d) => d.id === i.device.kind);
  const level = OPTIONS.whiteLabel.find((l) => l.id === i.licence.whiteLabel);
  const printer = OPTIONS.printers.find((p) => p.id === i.device.printer);
  const what = [
    `${industry?.name ?? ''} for ${country?.name ?? ''}, set up with ${i.business.name}'s own look, words and settings.`,
    `For a ${(device?.label ?? 'computer').toLowerCase()} running ${SYSTEMS[i.device.os] ?? i.device.os}.`,
  ];
  const first = [i.starter.items.length && `${i.starter.items.length} items`, i.starter.people.length && `${i.starter.people.length} people`].filter(Boolean).join(' and ');
  if (first) what.push(`Your first ${first} are already in.`);
  if (i.ecosystem.website.wanted) what.push(`Your website${i.ecosystem.website.domain ? ': ' + i.ecosystem.website.domain : ''}.`);
  if (i.ecosystem.android.wanted) what.push('Your Android app.');
  if (i.ecosystem.aiAddon?.wanted && i.device.os === 'windows') what.push('The AI assistant, for the Windows POS.');

  const steps = [];
  if (pack) {
    steps.push(i.device.os === 'linux'
      ? 'Open the folder "1 - Shop PC (Linux)" and read the page in it, or open a terminal there and type: sudo ./install.sh'
      : `Open the folder "1 - Shop PC (Windows)" and double-click the setup file. It installs everything it needs; nothing has to be installed first.`);
  } else steps.push('Run the setup file on the shop computer. It installs everything it needs; nothing has to be installed first.');
  steps.push('Open the program in the browser window it shows. The first time, type the licence key you were given.',
    'Your business details are already filled in. Check them, choose your own sign-in name and password, and finish.');
  if (i.device.printer !== 'none') steps.push(`Connect the ${(printer?.label ?? 'printer').toLowerCase()}, then open Settings, then Devices, to choose it.`);
  steps.push('Make your first sale to try it.');

  const contact = [company.supportPhone, company.supportEmail, company.website].filter(Boolean);
  const sections = [
    { heading: 'What you are getting', bullets: what },
    { heading: 'Putting it in place', steps },
    { heading: 'What your licence allows', text: `${level?.label ?? ''}: ${level?.hint ?? ''}${i.licence.seats > 1 ? ` Up to ${i.licence.seats} computers.` : ''}` },
    { heading: 'Need help?', text: contact.join(' · ') },
  ];
  return {
    title: `${i.business.name}: your Smart Retail POS`,
    subtitle: `Prepared ${String(info.approvedAt).slice(0, 10)} · setup release ${info.n}${company.name ? ' · ' + company.name : ''}`,
    sections,
    fingerprint: info.bundleHash.slice(0, 16),
    helpMissing: contact.length === 0,
  };
}

/** One page that opens in any browser and prints cleanly. The customer's own colour and logo; no scripts; nothing is loaded from anywhere. */
export function handoverHtml(sheet, { colour = '#0f6cbd', logo = null } = {}) {
  const accent = /^#[0-9a-fA-F]{6}$/.test(colour) ? colour : '#0f6cbd';
  const body = sheet.sections.filter((s) => s.text || s.bullets?.length || s.steps?.length).map((s) => `
    <h2>${esc(s.heading)}</h2>
    ${s.text ? `<p>${esc(s.text)}</p>` : ''}
    ${s.bullets?.length ? `<ul>${s.bullets.map((b) => `<li>${esc(b)}</li>`).join('')}</ul>` : ''}
    ${s.steps?.length ? `<ol>${s.steps.map((b) => `<li>${esc(b)}</li>`).join('')}</ol>` : ''}`).join('');
  const picture = logo && /^data:image\/(png|jpeg|svg\+xml);base64,[A-Za-z0-9+/=]+$/.test(logo) ? `<img class="logo" src="${logo}" alt="">` : '';
  return `<!doctype html>
<html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Security-Policy" content="default-src 'none'; img-src data:; style-src 'unsafe-inline'">
<title>${esc(sheet.title)}</title>
<style>
  :root { --accent: ${accent}; color-scheme: light; }
  body { font: 17px/1.55 system-ui, -apple-system, "Segoe UI", Roboto, sans-serif; color: #1d1d1f; background: #fff; margin: 0; }
  main { max-width: 720px; margin: 0 auto; padding: 48px 24px 64px; }
  .logo { display: block; max-height: 72px; max-width: 220px; margin-bottom: 24px; }
  h1 { font-size: 32px; line-height: 1.15; margin: 0 0 6px; letter-spacing: -0.02em; }
  .sub { color: #6e6e73; margin: 0 0 28px; }
  h2 { font-size: 20px; margin: 32px 0 8px; padding-top: 14px; border-top: 3px solid var(--accent); }
  li { margin: 6px 0; }
  .fp { color: #6e6e73; font-size: 13px; margin-top: 40px; }
  @media print { main { padding: 0; } }
</style></head>
<body><main>
  ${picture}
  <h1>${esc(sheet.title)}</h1>
  <p class="sub">${esc(sheet.subtitle)}</p>
  ${body}
  <p class="fp">Fingerprint of the approved setup: ${esc(sheet.fingerprint)}</p>
</main></body></html>
`;
}
