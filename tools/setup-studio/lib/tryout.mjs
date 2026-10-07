// "Try this customer's setup on a test PC": the page of steps staff follow to see a customer's pack work before it goes to the customer. Plain words, made from the customer's
// own details and from what is really in the pack (the file names), so the page never names a file that is not there.
//
// What it will never say or do: skip the licence. The shop program checks its licence on every start and there is no switch, setting or helper in the Studio that turns the
// check off (CLAUDE.md, section 3). The page says so, and tells staff to ask for a short test licence from the Licence Studio instead.
import { OPTIONS } from './intake.mjs';
import { countryPack } from './packs.mjs';

const label = (list, id) => list.find((x) => x.id === id)?.label ?? '';
const names = (item) => (item?.files ?? []).map((f) => (typeof f === 'string' ? f : f.name));
const ready = (items, id) => items.find((i) => i.id === id && i.status === 'ready');

/**
 * The page as plain data: { title, intro, before: [text], steps: [{ heading, lines: [text] }], remove: { heading, lines }, notChecked: [text] }.
 *   intake: the approved release's details. items: what the pack holds ([{ id, status, files }], as planPack gives them). customerId: the customer's short name.
 *   trial: the programs are a trial build (no licence keys). packFolder: the name of the folder the pack was made in (null before it is made).
 */
export function tryoutFor({ intake, items = [], customerId = '', trial = false, packMade = false }) {
  const business = intake.business.name;
  const windows = intake.device.os === 'windows';
  const level = OPTIONS.whiteLabel.find((l) => l.id === intake.licence.whiteLabel);
  const country = countryPack(intake.business.country);
  const shop = ready(items, 'shop-pc');
  const ai = ready(items, 'ai');
  const site = ready(items, 'website');
  const app = ready(items, 'android');

  const before = [
    'Use a test PC: a spare computer, or a virtual machine, that you can wipe. Never the customer\'s own computer, and never a computer that holds real shop information.',
    `The program needs a licence key, and the key comes from the NextGenOS Licence Studio, never from this Studio. In the Licence Studio make a TEST licence for ${business}: one computer, the plan that includes the shop program, the look level "${level?.label ?? 'the one chosen for this customer'}" (the same as the customer's), and a short end date, so it stops by itself. Copy its key.`,
    'There is no way to run the shop program without a licence, and there never will be: the same check protects every customer. A test licence is a real licence that ends soon.',
    packMade ? null : 'Make the pack first (the button "Make the pack" above): the steps below use its folders.',
    trial ? 'These programs are a trial build, made without licence keys. They will say that they need a licence and nothing can activate them, so a test licence will not open them. Use them only to see the set-up open. For a real try-out, use the programs of a release made with your licence keys.' : null,
  ].filter(Boolean);

  const steps = [];
  if (shop) {
    if (windows) {
      steps.push({
        heading: 'Put the shop program on the test PC',
        lines: [
          'Press "Open the folder with this pack" above. Copy the folder "1 - Shop PC (Windows)" to the test PC, for example on a USB stick. Keep the setup file and the folder called "profile" together.',
          `On the test PC double-click ${names(shop)[0] ?? 'the setup file'}. Say Yes when Windows asks for permission. If Windows shows "Windows protected your PC" (the setup is not signed yet), click "More info", then "Run anyway".`,
          'When it finishes, the program opens in a window of its own. Type the test licence key when it asks.',
        ],
      });
    } else {
      steps.push({
        heading: 'Put the shop program on the test PC',
        lines: [
          'Press "Open the folder with this pack" above. Copy the folder "1 - Shop PC (Linux)" to the test PC (Ubuntu 22.04 or 24.04, Linux Mint 21 or later, or Debian 12 or later), for example on a USB stick.',
          'On the test PC open that folder, right-click an empty place, choose "Open in Terminal", type  sudo ./install.sh  and press Enter. (Installing is the one time a terminal is used; the program itself opens from its icon.)',
          'Open Smart Retail POS from the applications menu. Type the test licence key when it asks.',
        ],
      });
    }
    const look = [
      `The name "${business}" is at the top and on the sign-in screen.`,
      level?.id === 'none'
        ? 'This customer has a "fixed look" licence: the colours and logo come from the brand written on the licence, not from this pack. Check that they are the ones you expect.'
        : `The colours and logo are ${business}'s own (the main colour is ${intake.look.primaryColor}).`,
      country ? `The country, money and bill wording are those of ${country.name}.` : null,
      intake.starter.items.length || intake.starter.people.length ? `The first ${[intake.starter.items.length && intake.starter.items.length + ' items', intake.starter.people.length && intake.starter.people.length + ' people'].filter(Boolean).join(' and ')} are in the lists.` : null,
      intake.money.receiptFooter ? `The receipt ends with the customer's own words: "${intake.money.receiptFooter}".` : null,
      'If something looks wrong, change it in this customer\'s details, prepare and approve the set-up again, make the pack again and try again. Never change a file inside the pack by hand.',
    ].filter(Boolean);
    steps.push({ heading: 'Look at it', lines: look });
    steps.push({ heading: 'Try a sale', lines: ['Make a test sale and look at the receipt on the screen. The Studio cannot check a real printer, a scanner or a cash drawer: if the customer has them, try each one once on the real machine.'] });
  } else {
    steps.push({ heading: 'The shop program', lines: ['The shop program for this customer\'s kind of computer is not in the programs this Studio has, so there is nothing to try yet.'] });
  }

  if (ai) {
    steps.push({
      heading: 'The AI assistant (only if the customer is getting it)',
      lines: [
        `Copy the folder "2 - AI assistant (Windows)" to the test PC and double-click ${names(ai)[0] ?? 'its setup file'}. Keep the folder called "profile" next to it.`,
        'It reads the Windows POS\'s database, not yet the new shop program\'s own information, and it needs its own licence key with the AI add-on. Open it from the Start menu.',
      ],
    });
  }
  if (site) {
    steps.push({
      heading: 'The website (only if the customer is getting it)',
      lines: [
        'The website is for the person who will put it online, not for the shop computer. To see it open: unzip the website file for your test PC\'s system (' + names(site).join(' or ') + ') and start it with its "Start Website" icon (Windows) or start-website.sh (Linux).',
        'Without its licence it only shows a page that says it needs one. That is the correct result.',
      ],
    });
  }
  if (app) {
    steps.push({
      heading: 'The Android app (only if the customer is getting it)',
      lines: [
        'Copy the .apk file to a test phone and open it. If the phone asks, allow installing from this source. The .aab file is not for a phone: it is the package for the Google Play Store.',
        'The app shows the customer\'s website address, so that website has to be online for the app to show anything.',
      ],
    });
  }

  const remove = windows
    ? { heading: 'Take it off the test PC again', lines: [
      'Open Settings, then Apps, find "Smart Retail POS Hub" and press Uninstall. The shop program keeps its information on purpose, in the folder C:\\ProgramData\\NextGenOS\\Hub. On a TEST PC you may delete that folder yourself, to start again from nothing.',
      ai ? 'The AI assistant is "Smart Retail POS AI" in the same list.' : null,
      site ? 'For the website, close its window and delete its folder.' : null,
    ].filter(Boolean) }
    : { heading: 'Take it off the test PC again', lines: [
      `Open Software, find Smart Retail POS and remove it (or type  sudo apt remove smart-retail-pos-hub smart-retail-profile-${customerId || 'this-customer'}  in a terminal). The shop program keeps its information on purpose, in /var/lib/nextgenos. On a TEST PC you may delete that folder yourself, to start again from nothing.`,
      site ? 'For the website, close its window and delete its folder.' : null,
    ].filter(Boolean) };

  return {
    title: `Try ${business}'s setup on a test PC`,
    intro: [
      'The Studio makes the pack; it cannot install anything or look at a screen for you. This page is what a person does with the pack, on a test computer, before the pack goes to the customer.',
    ],
    before,
    steps,
    remove,
    notChecked: [
      'Whether the screens look right to the customer, and whether the wording is right for their country: only a person can say.',
      'A real printer, scanner, cash drawer or touch screen.',
      'That the customer\'s own computer has the internet the licence needs once, to activate.',
    ],
  };
}
