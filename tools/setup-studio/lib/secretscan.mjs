// What counts as a secret, for the Studio. Before anything about a customer leaves this PC (the settings sent to the build service) it is read with these patterns, and a value that
// looks like a password or a key is refused. There is ONE source: scripts/lib/secret-patterns.mjs, which the release gate and the package audit use. This is a copy of its lists,
// because the Studio travels without the rest of the repository; tests/builds.test.mjs says the two lists are the same and agree on what they find (so a change in one alone fails).

export const SECRET_PATTERNS = [
  [/sk-proj-[A-Za-z0-9_-]{20,}/, 'OpenAI project key'],
  [/\bsk-[A-Za-z0-9]{32,}\b/, 'API key (sk-...)'],
  [/\bnpg_[A-Za-z0-9]{10,}/, 'Neon database password'],
  [/\bgsk_[A-Za-z0-9]{20,}/, 'Groq key'],
  [/AIza[0-9A-Za-z_-]{35}/, 'Google API key'],
  [/\bAKIA[0-9A-Z]{16}\b/, 'AWS access key'],
  [/\bghp_[A-Za-z0-9]{30,}/, 'GitHub token'],
  [/-----BEGIN (?:RSA |EC |OPENSSH |ENCRYPTED )?PRIVATE KEY-----/, 'private key'],
  [/postgres(?:ql)?:\/\/[^\s"'<>:@]+:[^\s"'<>@]{4,}@/, 'database URL with a password'],
  [/AuthSecret\s*=\s*"[^"]{12,}"/, 'Firebase database secret'],
  [/\b(?:Password|Pwd)=[^;"'\s${}(][^;"'\s]{5,};/i, 'password in a connection string'],
];
// Test and example files may hold obviously fake values; these exact fakes are allowed.
export const SECRET_ALLOW = [/Password=your_password/, /Password=not-a-real-password/, /sk-test-0+/, /postgres:\/\/user:secret@host/, /postgres:\/\/authenticator:\$\{/, /sk-abc/, /secret_test/];

/** The kinds of secret a text seems to hold, by name (an empty list when it holds none). The same rule as scripts/audit-package.mjs findSecrets. */
export function findSecrets(text) {
  const hits = [];
  if (!text) return hits;
  for (const [pattern, what] of SECRET_PATTERNS) {
    const global = new RegExp(pattern.source, pattern.flags.includes('g') ? pattern.flags : pattern.flags + 'g');
    for (const m of String(text).matchAll(global)) {
      const around = String(text).slice(Math.max(0, m.index - 20), m.index + m[0].length + 20);
      if (!SECRET_ALLOW.some((a) => a.test(around))) { hits.push(what); break; }
    }
  }
  return hits;
}
