// Release-gate checks for what a customer receives: the package audit works, the Hub is hidden and still runs, and it is brought into use with
// a real licence from the real Licence Studio. (CLAUDE.md, section 3: no source in anything a customer receives.)

import { browserProblem } from '../lib/playwright.mjs';
import { findObfuscar } from '../lib/obfuscar.mjs';

export function checks({ root, sh, has, runCmd, join, existsSync }) {
  const e2e = join(root, 'apps', 'business-hub', 'e2e');
  const needTools = () => {
    if (!has('dotnet') || !has('node')) return 'dotnet or node is not installed here';
    if (!findObfuscar()) return 'the obfuscator (Obfuscar) is not installed and could not be installed here (dotnet tool install --global Obfuscar.GlobalTool --version 2.2.50)';
    return browserProblem({ sh, join, existsSync, dir: e2e });
  };

  return [
    {
      name: 'package-audit-tests',
      title: 'The package audit catches source, tests, keys, databases, licences and secrets (and passes a clean package)',
      run: () => {
        const r = runCmd('package-audit-tests', 'node', ['--test', 'scripts/tests/audit-package.test.mjs']);
        if (r.status !== 'PASS') return r;
        const n = /# pass (\d+)/.exec(r.out);
        return { status: 'PASS', detail: `${n ? n[1] : 'all'} audit tests passed` };
      },
    },
    {
      name: 'hub-release',
      title: 'The real Business Hub, published, hidden and audited, is brought into use with a real Licence Studio key (activation, brand, a sale, a restart)',
      full: true,
      run: () => {
        const why = needTools();
        if (why) return { status: 'SKIP', detail: why };
        const r = runCmd('hub-release', 'node', ['licensing/e2e/with-studio.mjs', '--', 'node', 'licensing/e2e/hub-e2e.mjs'], { timeout: 1_500_000 });
        if (r.status !== 'PASS') return r;
        const audit = /^PASS\s+hub:.*$/m.exec(r.out);
        const steps = (r.out.match(/^✓ /gm) || []).length;
        return { status: 'PASS', detail: `${steps} steps passed; ${audit ? audit[0].replace(/^PASS\s+/, 'audit: ') : 'audit passed'}` };
      },
    },
    {
      name: 'hub-protected-e2e',
      title: 'Every Business Hub browser test, run again against the published program with its names hidden',
      full: true,
      run: () => {
        const why = needTools();
        if (why) return { status: 'SKIP', detail: why };
        const r = runCmd('hub-protected-e2e', 'node', ['apps/business-hub/e2e/protected.mjs'], { timeout: 1_700_000 });
        if (r.status !== 'PASS') return r;
        const steps = (r.out.match(/^✓ /gm) || []).length;
        return { status: 'PASS', detail: `${steps} steps passed against the protected build` };
      },
    },
  ];
}
