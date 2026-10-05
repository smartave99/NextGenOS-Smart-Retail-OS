// Runs another program for the Studio (an AI tool's command line) the careful way: no shell, an empty folder to work in, only the settings the program needs, a time limit,
// a limit on how much it may print, and the whole group stopped when it is done or late. The question goes in through the program's standard input, so it never shows in a
// list of running programs and has no length limit of its own.
import { spawn, spawnSync } from 'node:child_process';
import { existsSync, mkdtempSync, rmSync, statSync } from 'node:fs';
import { tmpdir, platform } from 'node:os';
import { join, delimiter, extname, isAbsolute, sep } from 'node:path';

export class AiError extends Error {
  constructor(message, code = 'ai') { super(message); this.code = code; }
}

const WIN = platform() === 'win32';
const KEEP = ['PATH', 'Path', 'PATHEXT', 'HOME', 'USERPROFILE', 'APPDATA', 'LOCALAPPDATA', 'SystemRoot', 'SYSTEMROOT', 'ComSpec', 'TEMP', 'TMP', 'TMPDIR', 'LANG', 'LC_ALL', 'USER', 'USERNAME', 'LOGNAME',
  'HTTP_PROXY', 'HTTPS_PROXY', 'NO_PROXY', 'http_proxy', 'https_proxy', 'no_proxy', 'SSL_CERT_FILE', 'SSL_CERT_DIR', 'NODE_EXTRA_CA_CERTS', 'REQUESTS_CA_BUNDLE', 'CURL_CA_BUNDLE', 'XDG_CONFIG_HOME', 'XDG_DATA_HOME', 'XDG_CACHE_HOME', 'XDG_RUNTIME_DIR', 'DISPLAY', 'CLAUDE_CONFIG_DIR', 'CODEX_HOME'];

/** Finds a program by name on the PATH (or checks a full path). Returns the full path, or null. */
export function resolveExecutable(command, env = process.env) {
  if (typeof command !== 'string' || !command || /[\0\r\n]/.test(command)) return null;
  const isFile = (p) => { try { return statSync(p).isFile(); } catch { return false; } };
  const exts = WIN ? (extname(command) ? [''] : (env.PATHEXT || '.COM;.EXE;.BAT;.CMD').split(';').filter(Boolean)) : [''];
  if (isAbsolute(command) || command.includes('/') || command.includes(sep)) return exts.map((e) => command + e).find(isFile) ?? null;
  for (const dir of (env.PATH || env.Path || '').split(delimiter).filter(Boolean)) for (const e of exts) { const full = join(dir, command + e); if (isFile(full)) return full; }
  return null;
}

/** The settings a tool is given: the usual ones it needs to find its own sign-in and the network, and nothing else (no keys of ours), plus what is named. */
export function toolEnv(extra = {}, env = process.env) {
  const out = {};
  for (const k of KEEP) if (env[k] !== undefined) out[k] = env[k];
  return { ...out, ...extra };
}

const SAFE_ARG = /^[A-Za-z0-9_@%+=:,./\\-]*$/;

function launch(path, args) {
  if (WIN && /\.(cmd|bat)$/i.test(path)) {
    // A .cmd file can only be started through the command interpreter. Every part of the command line is checked first so nothing can be added to it.
    if (!SAFE_ARG.test(path.replace(/[ ()]/g, '')) || args.some((a) => !SAFE_ARG.test(a))) throw new AiError('This tool\'s settings have characters that are not allowed on Windows.', 'unsafe');
    const quote = (a) => (a === '' ? '""' : a);
    return { file: process.env.ComSpec || 'cmd.exe', args: ['/d', '/s', '/c', `"${[`"${path}"`, ...args.map(quote)].join(' ')}"`], options: { windowsVerbatimArguments: true } };
  }
  return { file: path, args, options: {} };
}

function stopTree(child) {
  try {
    if (WIN) spawnSync('taskkill', ['/pid', String(child.pid), '/t', '/f'], { windowsHide: true });
    else process.kill(-child.pid, 'SIGKILL');
  } catch { try { child.kill('SIGKILL'); } catch { /* already gone */ } }
}

/**
 * Runs a program. Returns { code, stdout, stderr, timedOut, tooLong }. Does not throw for a program that fails; throws AiError when the program is not there or cannot start.
 */
export async function runCli({ command, args = [], input = '', timeoutMs = 180_000, extraEnv = {}, maxBytes = 2_000_000, env = process.env }) {
  const path = resolveExecutable(command, env);
  if (!path) throw new AiError(`The program "${command}" was not found on this PC.`, 'missing');
  const work = mkdtempSync(join(tmpdir(), 'studio-ai-'));
  try {
    const { file, args: realArgs, options } = launch(path, args);
    return await new Promise((resolve, reject) => {
      let child;
      try { child = spawn(file, realArgs, { cwd: work, env: toolEnv(extraEnv, env), stdio: ['pipe', 'pipe', 'pipe'], windowsHide: true, shell: false, detached: !WIN, ...options }); } catch (e) { reject(new AiError(`The program "${command}" could not be started (${e.code ?? 'error'}).`, 'start')); return; }
      let stdout = '', stderr = '', size = 0, tooLong = false, timedOut = false, finished = false;
      const done = (result) => { if (finished) return; finished = true; clearTimeout(timer); stopTree(child); resolve(result); };
      const timer = setTimeout(() => { timedOut = true; stopTree(child); }, timeoutMs);
      child.stdout.on('data', (d) => { size += d.length; if (size > maxBytes) { tooLong = true; stopTree(child); } else stdout += d; });
      child.stderr.on('data', (d) => { if (stderr.length < 20_000) stderr += d; });
      child.on('error', (e) => { if (!finished) { finished = true; clearTimeout(timer); reject(new AiError(`The program "${command}" could not be started (${e.code ?? 'error'}).`, 'start')); } });
      child.on('close', (code) => done({ code, stdout, stderr, timedOut, tooLong }));
      child.stdin.on('error', () => { /* the program stopped reading: its exit says why */ });
      child.stdin.end(input);
    });
  } finally { rmSync(work, { recursive: true, force: true }); }
}

/** Takes a key out of a text (so an error shown to a person can never show it). */
export function redact(text, secrets = []) {
  let out = String(text ?? '');
  for (const s of secrets) if (s && s.length >= 6) out = out.split(s).join('••••');
  return out;
}
