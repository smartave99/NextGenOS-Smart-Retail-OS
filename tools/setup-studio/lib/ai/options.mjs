// The settings of each AI tool and how they become the tool's own options. Every option a tool really has for choosing the model and how hard it thinks is here, and each one is
// checked (a short word, from the tool's own list where there is one). What is NOT offered is on purpose: the Studio only needs the tool to answer in words, so the options that
// let a tool run commands, change files, browse, or skip its safety questions are never passed, whoever asks. (docs/SETUP-STUDIO.md, "What the AI tools may and may not do".)

/** How hard each kind of tool can be asked to think, in the order a person would choose. */
export const EFFORTS = {
  'claude-code': ['low', 'medium', 'high', 'xhigh', 'max'],
  anthropic: ['low', 'medium', 'high', 'xhigh', 'max'],
  codex: ['minimal', 'low', 'medium', 'high', 'xhigh'],
  antigravity: ['low', 'medium', 'high'],
  openai: ['minimal', 'low', 'medium', 'high'],
  gemini: [],
  'generic-cli': [],
};

export const EFFORT_WORDS = {
  minimal: 'Minimal: almost no thinking, fastest', low: 'Low: quick answers', medium: 'Medium: balanced', high: 'High: careful', xhigh: 'Extra high: very careful', max: 'Maximum: slowest and most thorough',
};

const TOKEN = /^[A-Za-z0-9][A-Za-z0-9._:/@+-]{0,99}$/;
const FLAG_VALUE = /^[A-Za-z0-9_@%+=:,./-]{1,100}$/;

/** What each tool lets an administrator pass besides the model and the level: (flag -> how many values it takes). Anything else is refused. */
export const EXTRA_FLAGS = {
  'claude-code': { '--betas': 1, '--exclude-dynamic-system-prompt-sections': 0, '--no-chrome': 0 },
  codex: { '-c': 1 },
  antigravity: { '--max-turns': 1 },
};
const CODEX_KEYS = ['model_reasoning_effort', 'model_reasoning_summary', 'model_verbosity'];

/** Never passed, for any tool. A message says so when one is asked for. */
export const NEVER = ['--dangerously-skip-permissions', '--allow-dangerously-skip-permissions', '--dangerously-bypass-approvals-and-sandbox', '--permission-mode', '--allowedTools', '--allowed-tools', '--tools', '--add-dir',
  '--mcp-config', '--settings', '--plugin-dir', '--agents', '--bg', '--background', '--cloud', '--remote', '--worktree', '--full-auto', '--sandbox', '--cd', '-C', '--image', '--enable', '--resume', '--continue', '--session-id'];

export const isToken = (v) => typeof v === 'string' && TOKEN.test(v);

/**
 * Checks the settings given for a tool and returns { value, problems }: only what is valid is kept. `known` is the tool's own list of models and levels when it is available
 * (a word outside it is still allowed for a model, since a tool is often newer than any list, but a thinking level must be one the tool has).
 */
export function cleanToolConfig(tool, input, { knownEfforts = null } = {}) {
  const problems = [];
  const value = {};
  const src = input && typeof input === 'object' && !Array.isArray(input) ? input : {};
  const efforts = knownEfforts ?? EFFORTS[tool] ?? [];
  if (src.model !== undefined && src.model !== '') { if (isToken(src.model)) value.model = src.model; else problems.push('The model name can only have letters, numbers and . _ : / - and at most 100 characters.'); }
  if (src.effort !== undefined && src.effort !== '') {
    if (typeof src.effort === 'string' && efforts.includes(src.effort.toLowerCase())) value.effort = src.effort.toLowerCase();
    else problems.push(`How hard to think must be one of: ${efforts.join(', ') || 'none (this tool has no such setting)'}.`);
  }
  if (src.fallbackModel !== undefined && src.fallbackModel !== '') { if (isToken(src.fallbackModel)) value.fallbackModel = src.fallbackModel; else problems.push('The fallback model name is not valid.'); }
  if (src.maxBudgetUsd !== undefined && src.maxBudgetUsd !== null && src.maxBudgetUsd !== '') {
    const n = Number(src.maxBudgetUsd);
    if (Number.isFinite(n) && n > 0 && n <= 1000) value.maxBudgetUsd = Math.round(n * 100) / 100; else problems.push('The most to spend on one answer must be a number of dollars from 0.01 to 1000.');
  }
  if (src.timeoutSec !== undefined && src.timeoutSec !== '') {
    const n = Number(src.timeoutSec);
    if (Number.isInteger(n) && n >= 10 && n <= 1800) value.timeoutSec = n; else problems.push('The time to wait must be from 10 to 1800 seconds.');
  }
  if (src.baseUrl !== undefined && src.baseUrl !== '') { if (typeof src.baseUrl === 'string' && src.baseUrl.length <= 200) value.baseUrl = src.baseUrl; else problems.push('The service address is not valid.'); }
  if (typeof src.useGeminiKey === 'boolean') value.useGeminiKey = src.useGeminiKey;
  if (typeof src.fallbacks === 'boolean') value.fallbacks = src.fallbacks;
  if (src.thinkingBudget !== undefined && src.thinkingBudget !== '' && tool === 'gemini') {
    const n = Number(src.thinkingBudget);
    if (Number.isInteger(n) && n >= -1 && n <= 32768) value.thinkingBudget = n; else problems.push('The thinking budget must be -1 (the model decides), 0 (none), or a number up to 32768.');
  }
  if (tool === 'generic-cli') {
    if (typeof src.command === 'string' && src.command.trim()) { if (/[\0\r\n]/.test(src.command) || src.command.length > 300) problems.push('The program name is not valid.'); else value.command = src.command.trim(); }
    if (Array.isArray(src.args)) {
      const args = src.args.map(String);
      if (args.length > 40 || args.some((a) => a.length > 300 || /[\0\r\n]/.test(a))) problems.push('The program\'s options are not valid.'); else value.args = args;
    }
    if (src.promptVia === 'stdin' || src.promptVia === 'arg') value.promptVia = src.promptVia;
    if (typeof src.versionArgs === 'string' && FLAG_VALUE.test(src.versionArgs)) value.versionArgs = src.versionArgs;
  }
  if (Array.isArray(src.extraArgs) && src.extraArgs.length) {
    const allowed = EXTRA_FLAGS[tool] ?? {};
    const out = [];
    const list = src.extraArgs.map(String);
    for (let i = 0; i < list.length; i += 1) {
      const flag = list[i];
      if (NEVER.includes(flag)) { problems.push(`The option ${flag} is never passed: it would let the tool act on this PC, and the Studio only needs it to answer in words.`); const n = allowed[flag]; i += n ?? 0; continue; }
      if (!(flag in allowed)) { problems.push(`The option ${flag} is not one this tool offers here. Allowed: ${Object.keys(allowed).join(', ') || 'none'}.`); continue; }
      const take = allowed[flag];
      const vals = list.slice(i + 1, i + 1 + take);
      if (vals.length !== take || vals.some((v) => !FLAG_VALUE.test(v) || v.startsWith('-'))) { problems.push(`The option ${flag} needs ${take} short value(s).`); i += take; continue; }
      if (tool === 'codex' && flag === '-c' && !CODEX_KEYS.includes(String(vals[0]).split('=')[0])) { problems.push(`Codex's -c may set only: ${CODEX_KEYS.join(', ')}.`); i += take; continue; }
      out.push(flag, ...vals);
      i += take;
    }
    if (out.length) value.extraArgs = out;
  }
  return { value, problems };
}

/** The options for Claude Code: bare mode (API key only), every tool off, nothing kept. */
export function claudeArgs(config = {}) {
  const c = cleanToolConfig('claude-code', config).value;
  const args = ['-p', '--bare', '--output-format', 'json', '--tools', '', '--no-session-persistence', '--disable-slash-commands', '--strict-mcp-config'];
  if (c.model) args.push('--model', c.model);
  if (c.effort) args.push('--effort', c.effort);
  if (c.fallbackModel) args.push('--fallback-model', c.fallbackModel);
  if (c.maxBudgetUsd) args.push('--max-budget-usd', String(c.maxBudgetUsd));
  if (c.extraArgs) args.push(...c.extraArgs);
  return args;
}

/** The options for Codex: read-only, nothing kept, the question on standard input. */
export function codexArgs(config = {}) {
  const c = cleanToolConfig('codex', config).value;
  const args = ['exec', '--skip-git-repo-check', '--sandbox', 'read-only', '--ephemeral', '--color', 'never'];
  if (c.model) args.push('--model', c.model);
  if (c.effort) args.push('-c', `model_reasoning_effort=${c.effort}`);
  if (c.extraArgs) args.push(...c.extraArgs);
  args.push('-');
  return args;
}

/** The options for Antigravity (agy): sandboxed, JSON out. The question is added by the caller as the value of -p. */
export function antigravityArgs(config = {}, timeoutSec = 240) {
  const c = cleanToolConfig('antigravity', config).value;
  const args = ['--output-format', 'json', '--disable-slash-commands', '--sandbox', '--print-timeout', `${timeoutSec}s`];
  if (c.model) args.push('--model', c.model);
  if (c.effort) args.push('--effort', c.effort);
  if (c.extraArgs) args.push(...c.extraArgs);
  return args;
}
