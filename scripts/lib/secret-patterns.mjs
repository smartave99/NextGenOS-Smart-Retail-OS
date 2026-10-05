// What counts as a secret. Used by the release gate (scripts/verify-all.mjs) and by the package audit (scripts/audit-package.mjs).

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
