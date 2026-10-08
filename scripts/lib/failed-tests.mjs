/**
 * What a failed test run said about each test that failed (its name, its message and the first lines of where it happened). The end of the run's output holds only the last project's
 * summary, so without this a failure seen on a build machine (GitHub) cannot be told from a timing accident, and nobody can fix its cause.
 */
export function failedTests(out, limit = 6) {
  const lines = out.split('\n');
  const found = [];
  for (let i = 0; i < lines.length && found.length < limit; i += 1) {
    if (!/^\s+Failed \S+ \[/.test(lines[i])) continue;
    const block = [lines[i].trim()];
    for (let j = i + 1; j < lines.length && block.length < 14 && !/^\s+(Failed|Passed|Skipped) \S+ \[/.test(lines[j]) && !/^\s*(Failed|Passed)!/.test(lines[j]); j += 1) {
      if (lines[j].trim() !== '') block.push('    ' + lines[j].trim().slice(0, 300));
    }
    found.push(block.join('\n'));
  }
  return found;
}
