// Asks the chosen AI tool to improve a proposal, reads what comes back, and hands over a candidate to be checked and shown to a person. Nothing here saves anything.
import { ADAPTERS } from './adapters.mjs';
import { AiError } from './cli.mjs';
import { extractJson } from './extract.mjs';
import { systemPrompt, userPrompt } from './prompt.mjs';

export { AiError, ADAPTERS };
export { describeTools } from './adapters.mjs';
export { preview } from './prompt.mjs';

/**
 * Returns { candidate: { setup, theme }, explanation, meta }. Throws AiError (in plain words) when the tool is missing, signed out, late, refuses, or answers with something
 * that is not a setup. The candidate is not trusted: the caller reads it again through the Studio's rules (template.mjs reconcile).
 */
export async function askForProposal({ tool, config = {}, intake, baseline, timeoutMs = 240_000, env = process.env }) {
  const adapter = ADAPTERS[tool];
  if (!adapter) throw new AiError('That AI tool is not known. Choose one in Settings.', 'config');
  const system = systemPrompt(intake);
  const user = userPrompt(intake, baseline);
  const { text, meta } = await adapter.run({ system, user, config: config[tool] ?? {}, timeoutMs, env });
  const found = extractJson(text);
  if (found.problem) throw new AiError(found.problem, 'format');
  const { setup, theme, explanation } = found.value;
  if (!setup || typeof setup !== 'object') throw new AiError('The AI tool\'s answer had no setup in it. Nothing was changed; you can try again.', 'format');
  return { candidate: { setup, theme: theme && typeof theme === 'object' ? theme : {} }, explanation: typeof explanation === 'string' ? explanation.replace(/[\u0000-\u0008\u000b-\u001f]/g, '').slice(0, 800) : '', meta };
}
