#!/usr/bin/env node
/**
 * Looks for secrets in everything the current commit is built on: every line ever added, in every commit reachable from HEAD.
 * (A key that was committed and then deleted is still in the history, and anyone who can read the history can read the key.)
 *
 *   node scripts/scan-history.mjs [--json] [--root <repository folder>]
 *
 * It prints WHERE a secret pattern was found (commit, file, kind) and never the value. Exit code 1 when something was found.
 * Same patterns, allowances and skipped files as the release gate (scripts/lib/secret-patterns.mjs).
 */
import { spawn, spawnSync } from 'node:child_process';
import { resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { SECRET_PATTERNS, SECRET_ALLOW, SECRET_SKIP_PATH } from './lib/secret-patterns.mjs';

export function scanHistory(root) {
  const git = (...a) => spawnSync('git', ['-C', root, ...a], { encoding: 'utf8' });
  const shallow = git('rev-parse', '--is-shallow-repository').stdout.trim() === 'true';
  const commits = Number(git('rev-list', '--count', 'HEAD').stdout.trim()) || 0;
  return new Promise((done, fail) => {
    const p = spawn('git', ['-C', root, 'log', 'HEAD', '--full-history', '-p', '-U0', '--no-color', '--no-textconv', '--format=@@C %H'], { stdio: ['ignore', 'pipe', 'pipe'] });
    const found = new Map();
    let buf = ''; let commit = ''; let file = ''; let err = '';
    const line = (l) => {
      if (l.startsWith('@@C ')) { commit = l.slice(4, 16); return; }
      if (l.startsWith('+++ ')) { file = l.startsWith('+++ b/') ? l.slice(6).replace(/\t$/, '') : ''; return; } // git adds a tab after a name that holds a space
      if (!l.startsWith('+') || !file || l.length > 4000 || SECRET_SKIP_PATH.test(file)) return;
      for (const [re, kind] of SECRET_PATTERNS) {
        if (re.test(l) && !SECRET_ALLOW.some((a) => a.test(l))) found.set(`${commit}|${file}|${kind}`, { commit, file, kind });
      }
    };
    p.stdout.setEncoding('utf8');
    p.stdout.on('data', (d) => { buf += d; let i; while ((i = buf.indexOf('\n')) >= 0) { line(buf.slice(0, i)); buf = buf.slice(i + 1); } });
    p.stderr.on('data', (d) => { err += d; });
    p.on('error', fail);
    p.on('close', (code) => { line(buf); if (code !== 0) fail(new Error(`git log failed: ${err.trim().slice(-300)}`)); else done({ shallow, commits, hits: [...found.values()] }); });
  });
}

if (process.argv[1] && resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const args = process.argv.slice(2);
  const rootArg = args.indexOf('--root');
  const root = rootArg >= 0 ? resolve(args[rootArg + 1]) : resolve(dirname(fileURLToPath(import.meta.url)), '..');
  try {
    const r = await scanHistory(root);
    if (args.includes('--json')) console.log(JSON.stringify(r));
    else {
      for (const h of r.hits) console.log(`commit ${h.commit}  ${h.file}  ${h.kind}`);
      console.log(r.hits.length ? `${r.hits.length} place(s) in ${r.commits} commit(s)` : `no secret pattern in ${r.commits} commit(s)${r.shallow ? ' (only part of the history is here)' : ''}`);
    }
    process.exit(r.hits.length ? 1 : 0);
  } catch (e) { console.error(String(e.message || e)); process.exit(2); }
}
