// Release-gate checks for the Setup Studio (tools/setup-studio) and for what every customer-facing program may not fix in code (CLAUDE.md, section 8).

import { browserProblem } from '../lib/playwright.mjs';

export function checks({ root, sh, has, runCmd, join, existsSync }) {
  const studio = join(root, 'tools', 'setup-studio');
  return [
    {
      name: 'white-label',
      title: 'Nothing new is fixed in program code that a customer could want different (a market, a company name, a built-in picture); the list only shrinks',
      run: () => {
        if (!has('node')) return { status: 'SKIP', detail: 'node is not installed here' };
        const r = runCmd('white-label', 'node', ['scripts/white-label-audit.mjs']);
        return r.status === 'PASS' ? { status: 'PASS', detail: r.out.trim().split('\n').pop() } : r;
      },
    },
    {
      name: 'setup-studio',
      title: 'The Setup Studio: rules shared with the Hub by test vectors, intake, proposals, team and approval, the activity record, and the AI tools (with stand-in programs and services)',
      run: () => {
        if (!has('node') || !has('npm')) return { status: 'SKIP', detail: 'node or npm is not installed here' };
        if (!existsSync(join(studio, 'node_modules', '@anthropic-ai', 'sdk'))) {
          const install = runCmd('setup-studio-install', 'npm', ['ci', '--no-audit', '--no-fund'], { cwd: studio, timeout: 300_000 });
          if (install.status !== 'PASS') return { status: 'FAIL', detail: `the Studio's library could not be installed:\n${install.detail}` };
        }
        const r = runCmd('setup-studio', 'node', ['--test', 'tests/*.test.mjs'], { cwd: studio });
        if (r.status !== 'PASS') return r;
        const n = /# pass (\d+)/.exec(r.out);
        return { status: 'PASS', detail: `${n ? n[1] : 'all'} tests passed` };
      },
    },
    {
      name: 'setup-studio-e2e',
      title: 'The Setup Studio in a real browser: first sign-in, a customer, the live preview in the customer\'s colours, an AI answer read again by the rules, a second person approving, the hand-over',
      full: true,
      run: () => {
        if (!has('node')) return { status: 'SKIP', detail: 'node is not installed here' };
        const why = browserProblem({ sh, join, existsSync, dir: join(root, 'apps', 'business-hub', 'e2e') });
        if (why) return { status: 'SKIP', detail: why };
        const r = runCmd('setup-studio-e2e', 'node', ['tests/studio.e2e.mjs'], { cwd: studio, timeout: 600_000 });
        if (r.status !== 'PASS') return r;
        return { status: 'PASS', detail: `${(r.out.match(/^✓ /gm) || []).length} steps passed in a real browser (Chromium)` };
      },
    },
  ];
}
