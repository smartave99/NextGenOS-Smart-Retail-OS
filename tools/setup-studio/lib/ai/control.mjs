// Looking after the AI tools themselves: is the tool there, which version, signed in, which models it offers and how hard each can think, is there a newer version, and
// bringing it up to date. Looking is free; changing anything on the PC (an update) is only ever done when an administrator asks, one tool at a time, and is written in the activity record.
import { readFileSync, existsSync } from 'node:fs';
import { homedir, platform } from 'node:os';
import { join } from 'node:path';
import { resolveExecutable, runCli, AiError, toolEnv } from './cli.mjs';
import { EFFORTS, EFFORT_WORDS } from './options.mjs';
import { getKey } from '../secrets.mjs';
import { checkEndpoint } from './adapters.mjs';

const version = (text) => /(\d+\.\d+\.\d+)/.exec(String(text ?? ''))?.[1] ?? null;
const newer = (a, b) => { const x = a.split('.').map(Number), y = b.split('.').map(Number); for (let i = 0; i < 3; i += 1) { if (x[i] !== y[i]) return x[i] > y[i]; } return false; };

/** Fetches a small JSON answer from one of the few places the Studio looks for new versions: https only, a size and time limit, no redirects to elsewhere. */
export async function fetchJson(url, { timeoutMs = 20_000, headers = {} } = {}) {
  const u = checkEndpoint(url);
  if (u.protocol !== 'https:' && !['127.0.0.1', 'localhost'].includes(u.hostname)) throw new AiError('Only https addresses are used here.', 'config');
  const res = await fetch(u, { headers: { accept: 'application/json', 'user-agent': 'NextGenOS-Setup-Studio', ...headers }, redirect: 'error', signal: AbortSignal.timeout(timeoutMs) });
  if (!res.ok) throw new AiError(`The address answered ${res.status}.`, 'http');
  const text = await res.text();
  if (text.length > 2_000_000) throw new AiError('The answer was far too long.', 'too-long');
  return JSON.parse(text);
}

// ---- what each tool is, and what can be said about it without a key ---------------------------------------------------------------------

/** Models of Claude, by the tool's own aliases and by id, with the levels each takes. A list made when the Studio was built: when a key is set, the live list from Anthropic replaces it. */
export const CLAUDE_BUILT_IN = [
  { id: 'claude-fable-5-1', label: 'Claude Fable 5.1 (most capable)', efforts: ['low', 'medium', 'high', 'xhigh', 'max'], defaultEffort: 'high' },
  { id: 'claude-opus-5-5', label: 'Claude Opus 5.5', efforts: ['low', 'medium', 'high', 'xhigh', 'max'], defaultEffort: 'medium' },
  { id: 'claude-opus-5', label: 'Claude Opus 5', efforts: ['low', 'medium', 'high', 'xhigh', 'max'], defaultEffort: 'high' },
  { id: 'claude-opus-4-8', label: 'Claude Opus 4.8', efforts: ['low', 'medium', 'high', 'xhigh', 'max'], defaultEffort: 'high' },
  { id: 'claude-opus-4-7', label: 'Claude Opus 4.7', efforts: ['low', 'medium', 'high', 'xhigh', 'max'], defaultEffort: 'high' },
  { id: 'claude-opus-4-6', label: 'Claude Opus 4.6', efforts: ['low', 'medium', 'high', 'max'], defaultEffort: 'high' },
  { id: 'claude-sonnet-5-5', label: 'Claude Sonnet 5.5', efforts: ['low', 'medium', 'high', 'xhigh', 'max'], defaultEffort: 'high' },
  { id: 'claude-sonnet-5', label: 'Claude Sonnet 5', efforts: ['low', 'medium', 'high', 'xhigh', 'max'], defaultEffort: 'high' },
  { id: 'claude-sonnet-4-6', label: 'Claude Sonnet 4.6', efforts: ['low', 'medium', 'high', 'max'], defaultEffort: 'high' },
  { id: 'claude-haiku-4-5', label: 'Claude Haiku 4.5 (fastest, no thinking level)', efforts: [], defaultEffort: null },
];
export const CLAUDE_ALIASES = [
  { id: 'fable', label: 'Claude Code\'s "fable" (newest Fable)', efforts: EFFORTS['claude-code'], defaultEffort: null },
  { id: 'opus', label: 'Claude Code\'s "opus" (newest Opus)', efforts: EFFORTS['claude-code'], defaultEffort: null },
  { id: 'sonnet', label: 'Claude Code\'s "sonnet" (newest Sonnet)', efforts: EFFORTS['claude-code'], defaultEffort: null },
];

const whyNot = (e) => (e?.status === 401 || e?.status === 403 ? 'the service did not accept the key' : e?.status === 429 ? 'too many requests just now' : e?.name?.includes('Timeout') ? 'it took too long' : 'the service could not be reached');
const effortWords = (levels) => levels.map((id) => ({ id, label: EFFORT_WORDS[id] ?? id }));
const shape = (m, source) => ({ id: m.id, label: m.label ?? m.id, efforts: effortWords(m.efforts ?? []), defaultEffort: m.defaultEffort ?? null, source, notes: m.notes ?? null });

/** Every model Anthropic lists for this key, with the thinking levels each says it supports. Needs a key and the internet. */
async function anthropicLive(config = {}, env = process.env) {
  const key = getKey('anthropic', env);
  if (!key) return null;
  const { default: Anthropic } = await import('@anthropic-ai/sdk');
  const client = new Anthropic({ apiKey: key, baseURL: config.baseUrl ? checkEndpoint(config.baseUrl).href.replace(/\/$/, '') : undefined, maxRetries: 1, timeout: 20_000 });
  const out = [];
  for await (const m of client.models.list({ limit: 100 })) {
    const levels = [];
    const effort = m.capabilities?.effort;
    if (effort?.supported) for (const level of EFFORTS.anthropic) if (effort[level]?.supported) levels.push(level);
    out.push({ id: m.id, label: m.display_name ?? m.id, efforts: levels, defaultEffort: null, notes: m.max_input_tokens ? `${Math.round(m.max_input_tokens / 1000)}K tokens in, ${Math.round((m.max_tokens ?? 0) / 1000)}K out` : null });
    if (out.length >= 200) break;
  }
  return out;
}

function codexHome(env = process.env) { return env.CODEX_HOME || join(homedir(), '.codex'); }

/** Codex keeps the list of models it offers in its own folder (models_cache.json). Reads what is there, tolerating the shapes seen so far. */
export function readCodexModels(env = process.env) {
  const file = join(codexHome(env), 'models_cache.json');
  if (!existsSync(file)) return null;
  let json;
  try { json = JSON.parse(readFileSync(file, 'utf8')); } catch { return null; }
  const list = Array.isArray(json) ? json : Array.isArray(json?.models) ? json.models : [];
  const out = [];
  for (const m of list) {
    const id = m.slug ?? m.id ?? m.model;
    if (typeof id !== 'string' || !id || String(m.visibility ?? '').toLowerCase() === 'hide') continue;
    const levels = (m.supported_reasoning_levels ?? m.supportedReasoningEfforts ?? m.reasoning_levels ?? []).map((l) => (typeof l === 'string' ? l : l.effort ?? l.reasoningEffort ?? l.id)).filter((l) => typeof l === 'string');
    out.push({ id, label: m.display_name ?? m.displayName ?? id, efforts: levels, defaultEffort: m.default_reasoning_level ?? m.defaultReasoningEffort ?? null, notes: m.description ?? null });
  }
  return { models: out, version: typeof json?.client_version === 'string' ? json.client_version : null };
}

/** The models a tool offers and how hard each can think: from the tool itself or the service when possible, else from the list built into the Studio, said plainly. */
export async function listModels(tool, { config = {}, env = process.env } = {}) {
  const note = (source, text) => ({ source, note: text });
  switch (tool) {
    case 'claude-code': {
      let live = null, why = null;
      try { live = await anthropicLive(config, env); } catch (e) { why = `The live list from Anthropic could not be read (${whyNot(e)}).`; }
      if (live?.length) return { models: [...CLAUDE_ALIASES.map((m) => shape(m, 'tool')), ...live.map((m) => shape(m, 'anthropic'))], ...note('anthropic', 'The list comes live from Anthropic for your key.') };
      return { models: [...CLAUDE_ALIASES.map((m) => shape(m, 'tool')), ...CLAUDE_BUILT_IN.map((m) => shape(m, 'built-in'))], ...note('built-in', why ?? 'This list was written when the Studio was made and can be out of date. Add an Anthropic key in Settings to see the live list, or type any model name.') };
    }
    case 'anthropic': {
      let live = null, why = null;
      try { live = await anthropicLive(config, env); } catch (e) { why = `The live list could not be read (${whyNot(e)}).`; }
      if (live?.length) return { models: live.map((m) => shape(m, 'anthropic')), ...note('anthropic', 'The list comes live from Anthropic for your key.') };
      return { models: CLAUDE_BUILT_IN.map((m) => shape(m, 'built-in')), ...note('built-in', why ?? 'Built-in list (can be out of date). Paste a key to see the live list.') };
    }
    case 'codex': {
      const r = readCodexModels(env);
      if (r?.models.length) return { models: r.models.map((m) => shape(m, 'tool')), ...note('tool', `The list is Codex's own${r.version ? ` (from Codex ${r.version})` : ''}.`) };
      return { models: [], ...note('none', 'Codex has not written its model list yet. Run "codex" once, or update it, then look again; or type any model name.'), defaultEfforts: effortWords(EFFORTS.codex) };
    }
    case 'antigravity': {
      // Antigravity's own list: "agy models", the first word of each line. One set of thinking levels for all its models.
      const none = (text) => ({ models: [], ...note('none', text), defaultEfforts: effortWords(EFFORTS.antigravity) });
      if (!resolveExecutable('agy', env)) return none('Antigravity is not on this PC. Leave the model empty for its own choice, or type the model name.');
      let r;
      try { r = await runCli({ command: 'agy', args: ['models'], timeoutMs: 20_000, env }); } catch { return none('Antigravity\'s list of models could not be read. Leave this empty for its own choice, or type the model name.'); }
      if (r.code !== 0 || r.timedOut) return none('Antigravity\'s list of models could not be read. Leave this empty for its own choice, or type the model name.');
      const seen = new Set();
      const models = [];
      for (const raw of String(r.stdout ?? '').split('\n')) {
        const line = raw.trim().replace(/^[-*\u2022\s]+/, '').trim();
        if (!line) continue;
        const [first, ...rest] = line.split(/\s+/);
        const id = first.replace(/[:,]+$/, '');
        if (!/^[A-Za-z0-9][A-Za-z0-9._:/-]{1,79}$/.test(id) || ['models', 'model', 'available', 'name', 'names', 'id', 'ids', 'usage', 'default', 'error', 'no', 'none'].includes(id.toLowerCase()) || seen.has(id)) continue;
        seen.add(id);
        const about = rest.join(' ').replace(/^\(|\)$/g, '').trim();
        models.push({ id, label: about ? `${id}: ${about}` : id, efforts: EFFORTS.antigravity, defaultEffort: null });
        if (models.length >= 100) break;
      }
      if (!models.length) return none('Antigravity\'s list of models could not be read. Leave this empty for its own choice, or type the model name.');
      return { models: models.map((m) => shape(m, 'tool')), ...note('tool', 'The list is Antigravity\'s own (from "agy models").') };
    }
    case 'openai': {
      const key = getKey('openai', env);
      const base = checkEndpoint(config.baseUrl || 'https://api.openai.com/v1').href.replace(/\/$/, '');
      try {
        const headers = key ? { authorization: `Bearer ${key}` } : {};
        const json = await fetchJson(`${base}/models`, { headers });
        const models = (json.data ?? []).map((m) => m.id).filter((id) => typeof id === 'string').sort().map((id) => ({ id, label: id, efforts: /^(o\d|gpt-5|gpt-6)/.test(id) ? EFFORTS.openai : [], defaultEffort: null }));
        return { models: models.map((m) => shape(m, 'service')), ...note('service', 'The list comes live from the service.') };
      } catch (e) { return { models: [], ...note('none', `The list could not be read (${whyNot(e)}). Type the model name.`), defaultEfforts: effortWords(EFFORTS.openai) }; }
    }
    case 'gemini': {
      const key = getKey('gemini', env);
      const base = checkEndpoint(config.baseUrl || 'https://generativelanguage.googleapis.com/v1beta').href.replace(/\/$/, '');
      if (!key) return { models: [], ...note('none', 'Add a Gemini key to see the live list, or type the model name.') };
      try {
        const json = await fetchJson(`${base}/models?pageSize=200`, { headers: { 'x-goog-api-key': key } });
        const models = (json.models ?? []).filter((m) => (m.supportedGenerationMethods ?? []).includes('generateContent')).map((m) => ({ id: String(m.name).replace(/^models\//, ''), label: m.displayName ?? m.name, efforts: [], defaultEffort: null, notes: m.thinking ? 'Can think (set a thinking budget)' : null }));
        return { models: models.map((m) => shape(m, 'service')), ...note('service', 'The list comes live from Google.') };
      } catch (e) { return { models: [], ...note('none', `The list could not be read (${whyNot(e)}). Type the model name.`) }; }
    }
    default: return { models: [], ...note('none', 'Type the model name the tool takes, if it takes one.') };
  }
}

// ---- is it there, and is it current --------------------------------------------------------------------------------------------------

const COMMAND = { 'claude-code': 'claude', codex: 'codex', antigravity: 'agy' };

/** Where the tool is, its version, and whether it is signed in. Never changes anything. */
export async function toolStatus(tool, { config = {}, env = process.env } = {}) {
  const command = tool === 'generic-cli' ? config.command : COMMAND[tool];
  if (!command) return { tool, kind: 'api', found: null };
  const where = resolveExecutable(command, env);
  if (!where) return { tool, kind: 'cli', found: false, where: null, version: null, signedIn: null };
  let v = null, signedIn = null;
  try {
    const args = tool === 'generic-cli' ? (config.versionArgs ? [config.versionArgs] : ['--version']) : ['--version'];
    const r = await runCli({ command, args, timeoutMs: 20_000, env });
    v = version(r.stdout || r.stderr);
  } catch { /* a program that does not say its version */ }
  try {
    if (tool === 'claude-code') {
      // The Studio runs Claude Code with an API key only (never a subscription sign-in): what matters is that a key is set.
      signedIn = !!getKey('anthropic', env);
    } else if (tool === 'codex') {
      const r = await runCli({ command, args: ['login', 'status'], timeoutMs: 20_000, env });
      signedIn = r.code === 0;
    }
  } catch { signedIn = null; }
  return { tool, kind: 'cli', found: true, where, version: v, signedIn };
}

/** The newest released version, from the places each vendor publishes it. Null when it could not be found out. */
export async function latestVersion(tool, { sources = {} } = {}) {
  try {
    if (tool === 'claude-code') return version((await fetchJson(sources.claude ?? 'https://registry.npmjs.org/@anthropic-ai/claude-code/latest')).version);
    if (tool === 'codex') {
      for (const url of sources.codex ?? ['https://releases.openai.com/codex/channels/latest', 'https://api.github.com/repos/openai/codex/releases/latest']) {
        try {
          const tag = (await fetchJson(url)).tag_name;
          const m = typeof tag === 'string' ? /^(?:rust-)?v?(\d+\.\d+\.\d+)$/.exec(tag) : null;
          if (m) return m[1];
        } catch { /* try the next place */ }
      }
    }
  } catch { /* no internet */ }
  return null;
}

/** Says whether a newer version is out and how the Studio would update it. */
export async function checkUpdate(tool, opts = {}) {
  const status = await toolStatus(tool, opts);
  if (status.kind === 'api') return { tool, kind: 'api', update: 'none', note: 'This is a web service; there is nothing to install on this PC.' };
  if (!status.found) return { tool, kind: 'cli', update: 'install', note: installNote(tool), ...status };
  const latest = status.version ? await latestVersion(tool, { sources: opts.sources }) : null;
  const how = updateHow(tool, opts.env);
  const upToDate = latest && status.version ? !newer(latest, status.version) : null;
  return { tool, kind: 'cli', ...status, latest, upToDate, update: upToDate === false ? 'available' : upToDate === true ? 'current' : 'unknown', how, canUpdate: !!how.command };
}

const WIN = platform() === 'win32';

function installNote(tool) {
  if (tool === 'claude-code') return WIN ? 'Install Claude Code in PowerShell with: irm https://claude.ai/install.ps1 | iex' : 'Install Claude Code from https://claude.com/claude-code (the native installer), then run it once.';
  if (tool === 'codex') return 'Install Codex with OpenAI\'s installer or "npm install -g @openai/codex", then sign in with "codex login".';
  if (tool === 'antigravity') return WIN ? 'Install Antigravity in PowerShell with: irm https://antigravity.google/cli/install.ps1 | iex, then run "agy" once to sign in.' : 'Install Antigravity from Google, then run "agy" once to sign in.';
  return 'Install the program, and set its name in Settings.';
}

/** What an update would run, in words and exactly. Null command: the Studio does not know a safe way on this PC and says what to do instead. */
export function updateHow(tool, env = process.env) {
  if (tool === 'claude-code') return { command: 'claude update', text: 'Runs "claude update", Claude Code\'s own updater.' };
  if (tool === 'codex') {
    if (WIN) return { command: 'powershell install.ps1', text: 'Downloads and runs OpenAI\'s official installer (https://chatgpt.com/codex/install.ps1) for the newest Codex. It changes only Codex\'s own folder and your PATH.' };
    if (resolveExecutable('npm', env)) return { command: 'npm install -g @openai/codex@latest', text: 'Runs "npm install -g @openai/codex@latest".' };
    return { command: null, text: 'Update Codex the way you installed it (npm install -g @openai/codex@latest, or OpenAI\'s installer).' };
  }
  if (tool === 'antigravity') return WIN ? { command: 'powershell install.ps1', text: 'Runs Google\'s official installer again (https://antigravity.google/cli/install.ps1), which brings Antigravity up to date.' } : { command: null, text: 'Update Antigravity the way you installed it.' };
  return { command: null, text: 'The Studio does not update this program. Update it the way you installed it.' };
}

/**
 * Brings a tool up to date. Only for the tools above, only when asked. Returns { before, after, output }. The result is checked by asking the tool its version again; a tool
 * that is no newer afterwards is reported as such, not as a success.
 */
export async function updateTool(tool, { env = process.env, progress } = {}) {
  const how = updateHow(tool, env);
  if (!how.command) throw new AiError(how.text, 'manual');
  const before = (await toolStatus(tool, { env })).version;
  let r;
  if (tool === 'claude-code') r = await runCli({ command: 'claude', args: ['update'], timeoutMs: 600_000, env });
  else if (tool === 'codex' && !WIN) r = await runCli({ command: 'npm', args: ['install', '-g', '@openai/codex@latest'], timeoutMs: 600_000, env });
  else if (WIN && (tool === 'codex' || tool === 'antigravity')) {
    const url = tool === 'codex' ? 'https://chatgpt.com/codex/install.ps1' : 'https://antigravity.google/cli/install.ps1';
    const ps = join(env.SystemRoot || 'C:\\Windows', 'System32', 'WindowsPowerShell', 'v1.0', 'powershell.exe');
    r = await runCli({ command: ps, args: ['-NoProfile', '-NonInteractive', '-ExecutionPolicy', 'Bypass', '-Command', `$ProgressPreference='SilentlyContinue'; Invoke-RestMethod -UseBasicParsing -Uri '${url}' | Invoke-Expression`], timeoutMs: 600_000, extraEnv: { CODEX_NON_INTERACTIVE: '1', CODEX_RELEASE: '' }, env });
  } else throw new AiError(how.text, 'manual');
  const output = `${r.stdout}\n${r.stderr}`.trim().split('\n').slice(-12).join('\n').slice(0, 1500);
  progress?.(output);
  if (r.timedOut) throw new AiError('The update took too long and was stopped. Check the internet connection and try again.', 'timeout');
  if (r.code !== 0) throw new AiError(`The update did not finish (it stopped with code ${r.code}). ${output.slice(-300)}`, 'failed');
  const after = (await toolStatus(tool, { env })).version;
  return { before, after, changed: !!(before && after && before !== after), output };
}

export { toolEnv };
