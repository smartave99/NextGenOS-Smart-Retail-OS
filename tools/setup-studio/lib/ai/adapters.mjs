// The AI tools the Studio can ask, one entry each. Every one takes the same question (a system part and a user part) and gives back text; reading that text, checking it and
// deciding about it is the Studio's job (index.mjs), not the tool's. A tool is never given the power to change a file: command-line tools are run with their own tools switched
// off, in an empty folder, and the web services only ever answer a question.
import { resolveExecutable, runCli, AiError, redact } from './cli.mjs';
import { getKey } from '../secrets.mjs';

const text = (v, max = 300) => String(v ?? '').replace(/\s+/g, ' ').trim().slice(0, max);

function explainFailure(label, r, secrets = []) {
  if (r.timedOut) return new AiError(`${label} took too long and was stopped. Try again, or choose another tool in Settings.`, 'timeout');
  if (r.tooLong) return new AiError(`${label} wrote far too much and was stopped.`, 'too-long');
  const why = redact(text(r.stderr || r.stdout), secrets);
  if (/log ?in|sign ?in|auth|credential|api key|unauthor|401|403/i.test(why)) return new AiError(`${label} is not signed in, or its key was refused. Sign in to it (or fix its key) and try again.${why ? ` It said: ${why}` : ''}`, 'auth');
  return new AiError(`${label} did not finish (it stopped with code ${r.code}).${why ? ` It said: ${why}` : ''}`, 'failed');
}

/** The address of a web service must be https (or a service on this same PC) and must not carry a password in it. */
export function checkEndpoint(url) {
  let u;
  try { u = new URL(url); } catch { throw new AiError('The service address is not a valid web address.', 'config'); }
  const local = ['127.0.0.1', 'localhost', '[::1]'].includes(u.hostname);
  if (u.username || u.password) throw new AiError('The service address must not have a name and password in it.', 'config');
  if (u.protocol !== 'https:' && !(u.protocol === 'http:' && local)) throw new AiError('The service address must start with https:// (a service on this same PC may use http://).', 'config');
  return u;
}

async function postJson(url, headers, body, { timeoutMs, secrets = [], label }) {
  checkEndpoint(url);
  let res;
  try { res = await fetch(url, { method: 'POST', headers: { 'content-type': 'application/json', ...headers }, body: JSON.stringify(body), redirect: 'error', signal: AbortSignal.timeout(timeoutMs) }); } catch (e) {
    if (e?.name === 'TimeoutError') throw new AiError(`${label} took too long to answer.`, 'timeout');
    throw new AiError(`${label} could not be reached (${redact(text(e?.cause?.code ?? e?.message, 120), secrets)}). Check the internet connection and the service address.`, 'network');
  }
  const raw = await res.text();
  if (raw.length > 2_000_000) throw new AiError(`${label} sent back far too much.`, 'too-long');
  let json = null;
  try { json = JSON.parse(raw); } catch { /* not JSON */ }
  if (!res.ok) {
    const detail = redact(text(json?.error?.message ?? json?.error ?? raw, 200), secrets);
    if (res.status === 401 || res.status === 403) throw new AiError(`${label} refused the key (${res.status}). Check the key in Settings.${detail ? ` It said: ${detail}` : ''}`, 'auth');
    if (res.status === 429) throw new AiError(`${label} says too many requests (or the account is out of credit). Wait a little and try again.${detail ? ` It said: ${detail}` : ''}`, 'rate');
    throw Object.assign(new AiError(`${label} returned an error (${res.status}).${detail ? ` It said: ${detail}` : ''}`, 'http'), { status: res.status });
  }
  if (json === null) throw new AiError(`${label} did not send back something the Studio can read.`, 'format');
  return json;
}

const cliCheck = (command) => () => { const path = resolveExecutable(command); return { found: !!path, where: path }; };

export const ADAPTERS = {
  'claude-code': {
    label: 'Claude Code (on this PC)', kind: 'cli', command: 'claude', needsKey: false,
    help: 'Uses the Claude Code program installed on this PC and the sign-in you already made in it. Nothing to paste.',
    install: 'Install Claude Code from https://claude.com/claude-code and sign in once by running "claude" in a terminal.',
    detect: cliCheck('claude'),
    async run({ system, user, config, timeoutMs }) {
      const args = ['-p', '--output-format', 'json', '--tools', '', '--no-session-persistence', '--safe-mode'];
      if (config.model) args.push('--model', String(config.model));
      const r = await runCli({ command: 'claude', args, input: `${system}\n\n${user}`, timeoutMs });
      if (r.code !== 0 || r.timedOut || r.tooLong) throw explainFailure('Claude Code', r);
      let out;
      try { out = JSON.parse(r.stdout); } catch { throw new AiError('Claude Code did not answer in a form the Studio can read.', 'format'); }
      if (out.is_error) throw new AiError(`Claude Code reported a problem: ${text(out.result)}`, 'failed');
      return { text: String(out.result ?? ''), meta: { tool: 'claude-code', model: Object.keys(out.modelUsage ?? {})[0] ?? config.model ?? null } };
    },
  },
  codex: {
    label: 'Codex (on this PC)', kind: 'cli', command: 'codex', needsKey: false,
    help: 'Uses the Codex program installed on this PC and the sign-in you already made in it. It is run read-only, in an empty folder.',
    install: 'Install the Codex command line from OpenAI and sign in once by running "codex" in a terminal.',
    detect: cliCheck('codex'),
    async run({ system, user, config, timeoutMs }) {
      const args = ['exec', '--skip-git-repo-check', '--sandbox', 'read-only', '--color', 'never'];
      if (config.model) args.push('--model', String(config.model));
      args.push('-');
      const r = await runCli({ command: 'codex', args, input: `${system}\n\n${user}`, timeoutMs });
      if (r.code !== 0 || r.timedOut || r.tooLong) throw explainFailure('Codex', r);
      return { text: r.stdout, meta: { tool: 'codex', model: config.model ?? null } };
    },
  },
  'generic-cli': {
    label: 'Another command-line tool', kind: 'cli', command: null, needsKey: false,
    help: 'Any tool that reads a question and prints an answer: Antigravity, Gemini CLI, a local model, a script. An administrator sets the program name and its options in Settings.',
    install: 'Set the program in Settings. It must read the question from its standard input (or take it as its last option) and print the answer.',
    detect: (config = {}) => { const path = config.command ? resolveExecutable(config.command) : null; return { found: !!path, where: path }; },
    async run({ system, user, config, timeoutMs }) {
      if (!config.command) throw new AiError('No program is set for the other tool yet. An administrator can set it in Settings.', 'config');
      const args = Array.isArray(config.args) ? config.args.map(String) : [];
      const question = `${system}\n\n${user}`;
      const viaArg = config.promptVia === 'arg';
      if (viaArg && question.length > 100_000) throw new AiError('The question is too long to pass as an option; set the tool to read it from its standard input.', 'config');
      const key = getKey('generic');
      const r = await runCli({ command: String(config.command), args: viaArg ? [...args, question] : args, input: viaArg ? '' : question, timeoutMs, extraEnv: key ? { SETUP_STUDIO_KEY: key } : {} });
      if (r.code !== 0 || r.timedOut || r.tooLong) throw explainFailure('The tool', r, [key]);
      return { text: r.stdout, meta: { tool: 'generic-cli', model: null } };
    },
  },
  anthropic: {
    label: 'Claude (Anthropic API key)', kind: 'api', provider: 'anthropic', needsKey: true,
    help: 'Asks Claude directly with your Anthropic API key. Only the question described above leaves this PC, to Anthropic.',
    install: 'Paste an Anthropic API key in Settings, or set ANTHROPIC_API_KEY on this PC.',
    detect: () => ({ found: !!getKey('anthropic'), where: null }),
    async run({ system, user, config, timeoutMs, env }) {
      const key = getKey('anthropic', env);
      if (!key) throw new AiError('There is no Anthropic key yet. Paste one in Settings.', 'auth');
      let Anthropic;
      try { ({ default: Anthropic } = await import('@anthropic-ai/sdk')); } catch { throw new AiError('The Anthropic library is not installed with this Studio. Reinstall the Studio, or choose another tool.', 'missing'); }
      const client = new Anthropic({ apiKey: key, baseURL: config.baseUrl ? checkEndpoint(config.baseUrl).href.replace(/\/$/, '') : undefined, maxRetries: 1, timeout: timeoutMs });
      const model = config.model || 'claude-opus-5-5';
      const request = { model, max_tokens: 16000, system, messages: [{ role: 'user', content: user }] };
      let response;
      try {
        // A policy decline is passed to a fallback model by the service itself (the "default" fallback), when it is allowed for this account; if it is not, the plain call is made.
        try { response = await client.beta.messages.create({ ...request, betas: ['server-side-fallback-2026-07-01'], fallbacks: 'default' }); } catch (e) { if (e?.status === 400 && config.fallbacks !== false) response = await client.messages.create(request); else throw e; }
      } catch (e) {
        const detail = redact(text(e?.message, 200), [key]);
        if (e?.status === 401 || e?.status === 403) throw new AiError(`Anthropic refused the key (${e.status}). Check the key in Settings.`, 'auth');
        if (e?.status === 429) throw new AiError('Anthropic says too many requests (or the account is out of credit). Wait a little and try again.', 'rate');
        if (e?.name === 'APIConnectionTimeoutError') throw new AiError('Claude took too long to answer.', 'timeout');
        throw new AiError(`Claude could not answer (${detail || 'error'}).`, 'failed');
      }
      if (response.stop_reason === 'refusal') throw new AiError('Claude declined to prepare this setup. Nothing was changed. Try the plain proposal, or change the notes and try again.', 'refused');
      const out = (response.content ?? []).filter((b) => b.type === 'text').map((b) => b.text).join('\n');
      return { text: out, meta: { tool: 'anthropic', model: response.model ?? model, inputTokens: response.usage?.input_tokens ?? null, outputTokens: response.usage?.output_tokens ?? null } };
    },
  },
  openai: {
    label: 'OpenAI or compatible (API key)', kind: 'api', provider: 'openai', needsKey: true,
    help: 'Asks OpenAI, or any service that speaks the same way (OpenRouter, Azure, a model running on this PC), with a key. Set the address and model in Settings.',
    install: 'Paste the key in Settings (or set OPENAI_API_KEY), and set the service address and model name.',
    detect: () => ({ found: !!getKey('openai'), where: null }),
    async run({ system, user, config, timeoutMs, env }) {
      const key = getKey('openai', env);
      const base = checkEndpoint(config.baseUrl || 'https://api.openai.com/v1').href.replace(/\/$/, '');
      const local = ['127.0.0.1', 'localhost', '[::1]'].includes(new URL(base).hostname);
      if (!key && !local) throw new AiError('There is no key for this service yet. Paste one in Settings.', 'auth');
      if (!config.model) throw new AiError('Set the model name for this service in Settings.', 'config');
      const body = { model: config.model, messages: [{ role: 'system', content: system }, { role: 'user', content: user }], response_format: { type: 'json_object' } };
      const headers = key ? { authorization: `Bearer ${key}` } : {};
      let json;
      try { json = await postJson(`${base}/chat/completions`, headers, body, { timeoutMs, secrets: [key], label: 'The service' }); } catch (e) {
        if (e.status !== 400) throw e;
        delete body.response_format;   // some compatible services do not know this option
        json = await postJson(`${base}/chat/completions`, headers, body, { timeoutMs, secrets: [key], label: 'The service' });
      }
      const choice = json?.choices?.[0];
      if (choice?.finish_reason === 'content_filter') throw new AiError('The service declined to answer. Nothing was changed.', 'refused');
      const content = choice?.message?.content;
      return { text: typeof content === 'string' ? content : '', meta: { tool: 'openai', model: json?.model ?? config.model, inputTokens: json?.usage?.prompt_tokens ?? null, outputTokens: json?.usage?.completion_tokens ?? null } };
    },
  },
  gemini: {
    label: 'Google Gemini (API key)', kind: 'api', provider: 'gemini', needsKey: true,
    help: 'Asks Google Gemini with your key. Set the model name in Settings.',
    install: 'Paste a Gemini key in Settings (or set GEMINI_API_KEY).',
    detect: () => ({ found: !!getKey('gemini'), where: null }),
    async run({ system, user, config, timeoutMs, env }) {
      const key = getKey('gemini', env);
      if (!key) throw new AiError('There is no Gemini key yet. Paste one in Settings.', 'auth');
      if (!config.model || !/^[A-Za-z0-9._-]+$/.test(config.model)) throw new AiError('Set the Gemini model name in Settings.', 'config');
      const base = checkEndpoint(config.baseUrl || 'https://generativelanguage.googleapis.com/v1beta').href.replace(/\/$/, '');
      const json = await postJson(`${base}/models/${config.model}:generateContent`, { 'x-goog-api-key': key }, {
        systemInstruction: { parts: [{ text: system }] }, contents: [{ role: 'user', parts: [{ text: user }] }], generationConfig: { responseMimeType: 'application/json' },
      }, { timeoutMs, secrets: [key], label: 'Gemini' });
      if (json?.promptFeedback?.blockReason) throw new AiError('Gemini declined to answer. Nothing was changed.', 'refused');
      const parts = json?.candidates?.[0]?.content?.parts ?? [];
      return { text: parts.map((p) => p.text ?? '').join(''), meta: { tool: 'gemini', model: config.model, inputTokens: json?.usageMetadata?.promptTokenCount ?? null, outputTokens: json?.usageMetadata?.candidatesTokenCount ?? null } };
    },
  },
};

/** What is available on this PC, for the Settings screen. */
export function describeTools(config = {}) {
  return Object.entries(ADAPTERS).map(([id, a]) => {
    const found = a.detect(config[id] ?? {});
    return { id, label: a.label, kind: a.kind, help: a.help, install: a.install, ready: found.found, where: found.where, needsKey: a.needsKey, provider: a.provider ?? null };
  });
}
