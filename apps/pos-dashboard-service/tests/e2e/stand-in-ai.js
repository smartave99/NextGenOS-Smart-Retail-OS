// Stands in for an AI command-line tool in plan.e2e.js and ask.e2e.js, through the assistant's "custom CLI" provider.
// It checks that it was given the shop's figures, then answers in Markdown. It never calls a real AI.
const fs = require('fs');

if (process.argv[2] === '--version') {
  console.log('stand-in-ai 1.0');
  process.exit(0);
}

const prompt = fs.readFileSync(process.argv[2], 'utf8');
// Photos and voice notes sent with a question ({image_files} and {audio_files} in its command).
const sent = process.argv.slice(3).filter(f => fs.existsSync(f));
const photos = sent.filter(f => /\.(jpe?g|png|webp)$/i.test(f));
const voices = sent.filter(f => /\.wav$/i.test(f));

// The memory review after a chat: it suggests keeping what the owner asked for, as JSON.
if (prompt.includes('You keep the long-term memory')) {
  const said = prompt.split('The conversation:')[1] || '';
  const changes = [];
  if (/hinglish/i.test(said)) {
    changes.push({ op: 'add', part: 'owner', text: 'Prefers answers in Hinglish.', why: 'Asked for Hinglish in a chat.' });
  }
  const actions = [];
  if (/e-?rickshaw/i.test(said)) {
    changes.push({ op: 'add', part: 'shop', text: 'Planned e-rickshaw ads around the market this month.', why: 'Planned in a chat.' });
    // The action to track, from today for 30 days, as the owner said it.
    const today = (prompt.match(/^Today: (\d{4}-\d{2}-\d{2})$/m) || [])[1];
    const end = new Date(today + 'T00:00:00Z');
    end.setUTCDate(end.getUTCDate() + 29);
    actions.push({
      title: 'E-rickshaw ads around the market', kind: 'advert', start: today, end: end.toISOString().slice(0, 10),
      cost: 6000, products: [], expected: 'More bills from the market side',
    });
  }
  console.log(JSON.stringify({ changes, actions }));
  process.exit(0);
}

// A playbook, written (or improved) from an action and what came of it, as JSON.
if (prompt.includes('You write the playbooks of a retail shop')) {
  const kind = (prompt.match(/^- Kind: (.*)$/m) || ['', 'Other'])[1].trim();
  const improving = prompt.includes('The playbook so far:');
  const steps = [
    'Decide the dates and the budget a week before.',
    'Tell the staff what is on, and put the products in front.',
    'Compare the sales with the same days before on the Actions page.',
  ];
  if (improving) steps.push('Run it again only where it paid for itself.');
  console.log(JSON.stringify({ title: `${kind} around the market`, when: `When the shop runs ${kind.toLowerCase()} to bring more customers.`, steps }));
  process.exit(0);
}

if (!prompt.includes("THE SHOP'S FIGURES")) {
  console.error('The prompt has no figures.');
  process.exit(2);
}

const line = (re) => (prompt.match(re) || ['', ''])[1].trim();

const MIXED = [
  '# Everything about this week', '', 'Sales were **₹82,304**, up *12%* on last week. The best day was Sunday.', '',
  '## What sold', '- Groceries', '  - Basmati Rice 5 kg', '  - Sunflower Oil 1 L', '- Snacks', '', '1. Keep rice at the counter', '2. Reorder oil before Friday', '',
  '## By day', '| Day | Bills | Sales |', '|:--|--:|--:|', '| Monday | 42 | ₹9,850 |', '| Sunday | 88 | ₹21,400 |', '',
  '> Figures are from the shop PC, not typed by the AI.', '', '---', '',
  '```sql', 'SELECT TOP 5 p.Name, SUM(l.Qty) AS Qty FROM Product p JOIN BillLines l ON l.ProductId = p.Id GROUP BY p.Name ORDER BY Qty DESC -- a long line that must scroll inside its box', '```', '',
  'See <b>not bold</b> and [the supplier](https://example.com/prices).',
].join('\n');

// The chat on the demo shop: a short answer to the owner's question.
const asked = prompt.split("THE OWNER'S QUESTION\n")[1];
if (asked !== undefined) {
  const best = line(/^TOP PRODUCTS.*\n- (.*?) \[/m);
  // What the assistant remembers, when it was given: its first entry, to show it arrived.
  const remembered = line(/^WHAT YOU REMEMBER\n[\s\S]*?^- (.*)$/m);
  // STAND_IN_AI_DELAY_MS: a real AI takes a while, long enough to press Stop.
  setTimeout(() => {
    // A playbook, when one was given: its name, to show it arrived.
    const playbook = line(/^Playbook: (.*?) \(/m);
    const playbooks = (prompt.match(/^Playbook: /gm) || []).length;
    const memory = (remembered ? `\n\nI remember: ${remembered}` : '')
      + (playbook ? `\n\nYour playbook: ${playbook}\n\nPlaybooks given: ${playbooks}` : '');
    // "…everything…": a long answer with every kind of Markdown, to check how answers are laid out.
    let answer = /everything/i.test(asked) ? MIXED : `You asked: “${asked.trim()}”\n\nThe best seller is **${best}**.\n- Keep it near the counter.${memory}`;
    if (photos.length) {
      if (!prompt.includes('THE OWNER SENT A PHOTO') && !prompt.includes('PHOTOS (attached)')) { console.error('The prompt does not mention the photo.'); process.exit(2); }
      const bytes = photos.reduce((all, f) => all + fs.statSync(f).size, 0);
      answer = `I see ${photos.length} photo${photos.length === 1 ? '' : 's'} (${bytes} bytes).\n\n` + answer;
    }
    if (voices.length) {
      const wav = fs.readFileSync(voices[0]);
      if (wav.toString('ascii', 0, 4) !== 'RIFF' || wav.toString('ascii', 8, 12) !== 'WAVE') { console.error('The voice note is not a WAV file.'); process.exit(2); }
      answer = `Heard: aaj kitna cash aaya\n\nI heard a voice note (${wav.length} bytes).\n\n` + answer;
    }
    // STAND_IN_AI_STREAM_MS: print the answer a line at a time, as a real AI writes it, so the chat shows it growing.
    const pause = Number(process.env.STAND_IN_AI_STREAM_MS || 0);
    if (!pause) {
      console.log(answer);
      process.exit(0);
    }
    const lines = answer.split('\n');
    const next = () => {
      process.stdout.write(lines.shift() + '\n');
      if (lines.length) setTimeout(next, pause);
      else process.exit(0);
    };
    next();
  }, Number(process.env.STAND_IN_AI_DELAY_MS || 0));
  return;
}
const period = line(/^(Period: .*)$/m);
const top = line(/^TOP PRODUCTS.*\n- (.*?) \[/m);
const language = line(/Write the plan in ([^.(]*)/);

console.log(`## Where the shop stands
- ${period}
- Best seller: **${top}**
- <b>not bold</b> stays text

## Plan for the next 30 days
1. Put **${top}** at the counter.
2. Offer a *weekday combo*.

## Quick wins this week
- Ask every customer for a phone number.

## Stock
- Language asked for: ${language}`);
