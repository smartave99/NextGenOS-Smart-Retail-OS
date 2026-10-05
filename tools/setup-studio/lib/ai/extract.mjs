// Finds the one JSON object in what an AI tool wrote back (it may have wrapped it in a code fence or said a sentence first). Never throws.
const MAX = 400_000;

/** Returns { value } or { problem } (the problem in plain words). */
export function extractJson(text) {
  if (typeof text !== 'string' || text.trim() === '') return { problem: 'The AI tool gave no answer.' };
  if (text.length > MAX) return { problem: 'The AI tool\'s answer was far too long to use.' };
  const body = text.replace(/^﻿/, '');
  const fenced = /```(?:json|JSON)?\s*\n([\s\S]*?)\n```/.exec(body);
  const candidates = fenced ? [fenced[1], body] : [body];
  for (const source of candidates) {
    const start = source.indexOf('{');
    if (start < 0) continue;
    let depth = 0, inString = false, escaped = false;
    for (let i = start; i < source.length; i += 1) {
      const c = source[i];
      if (inString) { if (escaped) escaped = false; else if (c === '\\') escaped = true; else if (c === '"') inString = false; continue; }
      if (c === '"') inString = true;
      else if (c === '{') depth += 1;
      else if (c === '}') {
        depth -= 1;
        if (depth === 0) {
          try { const value = JSON.parse(source.slice(start, i + 1)); if (value && typeof value === 'object' && !Array.isArray(value)) return { value }; } catch { /* try the next place */ }
          break;
        }
      }
    }
  }
  return { problem: 'The AI tool did not answer with a setup the Studio can read. Nothing was changed; you can try again.' };
}
