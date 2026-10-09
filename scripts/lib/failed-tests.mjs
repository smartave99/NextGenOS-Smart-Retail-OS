/**
 * What a failed test run said about each test that failed (its name, its message and the first lines of where it happened). The end of the run's output holds only the last project's
 * summary, so without this a failure seen on a build machine (GitHub) cannot be told from a timing accident, and nobody can fix its cause. It reads the .NET test runner's
 * "Failed <name> [..]" blocks and Node's own test runner's "not ok <n> - <name>" blocks (with the message under them): a Node test that failed on GitHub once (a pattern that
 * matched a fingerprint by chance) could not be named from the log, because only the last thirty lines of the output are kept.
 */
export function failedTests(out, limit = 6) {
  const lines = out.split('\n');
  const found = [];
  for (let i = 0; i < lines.length && found.length < limit; i += 1) {
    if (/^\s*not ok \d+ - /.test(lines[i])) {
      const block = [lines[i].trim()];
      for (let j = i + 1; j < lines.length && block.length < 16 && !/^\s*(not )?ok \d+ - /.test(lines[j]) && !/^\s*# Subtest:/.test(lines[j]); j += 1) {
        const t = lines[j].trim();
        if (t !== '' && t !== '---' && t !== '...' && !/^(duration_ms|type|stack):/.test(t) && !/^at /.test(t)) block.push('    ' + t.slice(0, 300));
      }
      found.push(block.join('\n'));
      continue;
    }
    if (!/^\s+Failed \S+ \[/.test(lines[i])) continue;
    const block = [lines[i].trim()];
    for (let j = i + 1; j < lines.length && block.length < 14 && !/^\s+(Failed|Passed|Skipped) \S+ \[/.test(lines[j]) && !/^\s*(Failed|Passed)!/.test(lines[j]); j += 1) {
      if (lines[j].trim() !== '') block.push('    ' + lines[j].trim().slice(0, 300));
    }
    found.push(block.join('\n'));
  }
  return found;
}
