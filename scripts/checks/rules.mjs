// Release-gate check for the project's rules (CLAUDE.md, section 14): the rules the owner has given must stay in the repository, in one place, where every person and every
// assistant reads them, so that the owner never has to repeat them.

/** The numbered sections of CLAUDE.md, each with a phrase that must stay in it. A section that is renamed or emptied is a rule that was lost. */
export const REQUIRED_SECTIONS = [
  [1, 'Who and what', 'is a customer'],
  [2, 'The "all complete" rule', 'NOT VERIFIED'],
  [3, 'Security rules', 'No licence bypass'],
  [4, 'Licensing changes', 'all three'],
  [5, 'How to check your work', 'verify-all.mjs --full'],
  [6, 'Installers carry everything', 'factory-fresh'],
  [7, 'Hand over the output', 'Trial builds'],
  [8, 'Nothing the customer sees is fixed', 'neutral'],
  [9, 'Style', 'Plain words'],
  [10, 'Programs open like programs', 'No terminal or console window'],
  [11, 'What the product is', 'Setup Studio is the one tool'],
  [12, 'Releases', 'never lags behind'],
  [13, 'Working with the owner', 'never have to repeat'],
  [14, 'Everyone reads the same rules', 'AGENTS.md'],
  [15, 'Version 2', 'never depends on AI'],
  [16, 'How the platform works', 'docs/PLATFORM-DECISIONS.md'],
  [17, 'Reuse first', 'docs/OWNER-REQUESTS.md'],
];

/** The owner's decisions, recorded one by one in docs/PLATFORM-DECISIONS.md: every numbered decision must stay, so that no answer the owner gave is lost and asked again. */
export const DECISION_COUNT = 28;

/** The files that only point to CLAUDE.md, so that an assistant that does not read CLAUDE.md by name still finds the rules. */
export const POINTER_FILES = ['AGENTS.md', 'GEMINI.md', '.github/copilot-instructions.md', '.cursor/rules/project-rules.mdc'];

/** { read(file) -> text, '' when missing } in, a list of plain problems out (empty: all well). */
export function rulesProblems(read) {
  const problems = [];
  const rules = read('CLAUDE.md');
  if (!rules) problems.push('CLAUDE.md is missing: it is the one set of rules for every person and every assistant.');
  for (const [n, name, phrase] of REQUIRED_SECTIONS) {
    const heading = new RegExp(`^## ${n}\\. `, 'm');
    if (rules && !heading.test(rules)) problems.push(`CLAUDE.md has lost its section ${n} (${name}).`);
    else if (rules) {
      const start = rules.search(heading);
      const next = rules.slice(start + 3).search(/^## \d+\. /m);
      const body = rules.slice(start, next < 0 ? undefined : start + 3 + next);
      if (!body.includes(phrase)) problems.push(`CLAUDE.md section ${n} (${name}) no longer says "${phrase}".`);
    }
  }
  for (const f of POINTER_FILES) {
    const text = read(f);
    if (!text) problems.push(`${f} is missing: assistants that read it would not find the rules.`);
    else if (!text.includes('CLAUDE.md')) problems.push(`${f} does not point to CLAUDE.md.`);
    else if (text.split('\n').length > 40) problems.push(`${f} is long: it must only point to CLAUDE.md, not hold rules of its own (they would drift apart).`);
  }
  const decisions = read('docs/PLATFORM-DECISIONS.md');
  if (!decisions) problems.push("docs/PLATFORM-DECISIONS.md is missing: it is where the owner's questions and answers about how the platform works are kept, so that nobody asks again.");
  else {
    for (let n = 1; n <= DECISION_COUNT; n += 1) if (!new RegExp(`^### ${n}\\. `, 'm').test(decisions)) problems.push(`docs/PLATFORM-DECISIONS.md has lost decision ${n}.`);
    if (!decisions.includes('The picture, in the owner')) problems.push("docs/PLATFORM-DECISIONS.md has lost the owner's own description of the platform.");
  }
  const words = read('docs/OWNER-REQUESTS.md');
  if (!words) problems.push("docs/OWNER-REQUESTS.md is missing: it keeps the owner's own messages word for word, so that nobody has to guess what the owner wanted.");
  else {
    if (!words.includes('Standing words of the owner')) problems.push("docs/OWNER-REQUESTS.md has lost the owner's standing words.");
    if ((words.match(/^### \d{4}-\d{2}-\d{2}/gm) ?? []).length < 20) problems.push('docs/OWNER-REQUESTS.md has lost owner messages: it must keep every one, word for word (never shortened).');
  }
  const open = read('docs/OPEN-WORK.md');
  if (!open) problems.push('docs/OPEN-WORK.md is missing: it is where "what is left" and "what only the owner can do" are written.');
  else {
    for (const part of ['## Needs the owner', '## Needs an engineer or an assistant', '## What cannot be verified']) if (!open.includes(part)) problems.push(`docs/OPEN-WORK.md has lost its part "${part.slice(3)}".`);
    if (!/^Last updated: \d{1,2} [A-Z][a-z]+ \d{4}\.$/m.test(open)) problems.push('docs/OPEN-WORK.md has no "Last updated: <day month year>." line.');
  }
  return problems;
}

export function checks({ read }) {
  return [
    {
      name: 'project-rules',
      title: "The owner's rules are in the repository where every assistant and every person reads them (CLAUDE.md and the files that point to it), with the open-work list",
      run: () => {
        const problems = rulesProblems(read);
        return problems.length
          ? { status: 'FAIL', detail: problems.join('\n  ') }
          : { status: 'PASS', detail: `${REQUIRED_SECTIONS.length} rule sections, ${POINTER_FILES.length} pointer files, and the open-work list are in place` };
      },
    },
  ];
}
