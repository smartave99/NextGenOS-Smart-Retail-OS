// Release-gate checks for the Business Hub (apps/business-hub): the licence is wired into its program and cannot be skipped by anything
// that ships, it builds, its tests pass, and every kind of business works in a real browser.

import { browserProblem } from '../lib/playwright.mjs';

export function checks({ root, sh, has, runCmd, read, join, existsSync, tail }) {
  const hub = 'apps/business-hub';

  return [
    {
      name: 'hub-enforcement',
      title: 'The Business Hub checks the licence first, and nothing that ships can skip it',
      run: () => {
        const problems = [];
        const hubHost = `${hub}/src/NextGenOS.Hub.Web/HubHost.cs`;
        if (!existsSync(join(root, hubHost))) return { status: 'FAIL', detail: `${hubHost} is missing` };
        const text = read(hubHost);
        for (const needle of ['AddNextGenOSLicence("hub"', 'app.UseLicenceGate()', 'AddLicensedWorker<HubWorker>']) {
          if (!text.includes(needle)) problems.push(`${hubHost} no longer contains ${needle}`);
        }
        const gate = text.indexOf('app.UseLicenceGate()');
        for (const later of ['app.UseAuthentication()', 'app.UseAuthorization()', 'app.MapStaticAssets()', 'app.MapRazorComponents']) {
          const at = text.indexOf(later);
          if (at >= 0 && gate > at) problems.push(`${hubHost}: the licence gate must come before ${later}`);
        }
        if (/AddHostedService</.test(text)) problems.push(`${hubHost} registers a background worker without the licence gate`);
        if (!read(`${hub}/src/NextGenOS.Hub.Web/Program.cs`).includes('HubHost.UseHub(app)')) problems.push('Program.cs no longer builds the Hub through HubHost');

        // No stand-in for the licence in anything that ships: only the test host may swap it, and the Hub project must never refer to it.
        const csproj = read(`${hub}/src/NextGenOS.Hub.Web/NextGenOS.Hub.Web.csproj`);
        if (/<ProjectReference[^>]*(E2EHost|Tests)/.test(csproj)) problems.push('NextGenOS.Hub.Web.csproj refers to a test project');
        for (const rel of ['HubHost.cs', 'Program.cs', 'Auth/Session.cs', 'Auth/HubWorker.cs', 'ExportEndpoint.cs']) {
          const body = read(`${hub}/src/NextGenOS.Hub.Web/${rel}`);
          if (/new ProductLicence\(|E2E:|GetEnvironmentVariable\(\s*"[A-Z_]*LICEN[CS]E/i.test(body)) problems.push(`${rel} builds or switches the licence itself`);
        }
        return problems.length ? { status: 'FAIL', detail: problems.join('\n') } : { status: 'PASS', detail: 'the Hub checks the licence before anything else, and has no switch to skip it' };
      },
    },
    {
      name: 'dotnet-hub',
      title: 'Business Hub and Devices library: build, domain tests (every industry and country), printer languages, web tests (licence gate, sign-in, roles, headers)',
      full: true,
      run: () => {
        if (!has('dotnet')) return { status: 'SKIP', detail: 'dotnet is not installed here' };
        const r = runCmd('dotnet-hub', 'dotnet', ['test', `${hub}/NextGenOS.Hub.slnx`, '-c', 'Release', '--nologo', '--logger', 'console;verbosity=normal']);
        if (r.status !== 'PASS') return r;
        const skipped = [...r.out.matchAll(/^\s+Skipped (\S+)/gm)].map((m) => m[1]);
        if (skipped.length) return { status: 'FAIL', detail: `tests skipped that should have run:\n  ${skipped.slice(0, 10).join('\n  ')}` };
        const totals = [...r.out.matchAll(/Passed!\s+-\s+Failed:\s+0,\s+Passed:\s+(\d+)/g)].map((m) => Number(m[1]));
        return { status: 'PASS', detail: `${totals.reduce((a, b) => a + b, 0)} tests passed in ${totals.length} test projects` };
      },
    },
    {
      name: 'hub-e2e',
      title: 'Business Hub in a real browser: a retail shop, a café, a library, a contractor, a salon, a wholesaler, roles, no licence, other countries',
      full: true,
      run: () => {
        if (!has('dotnet') || !has('node')) return { status: 'SKIP', detail: 'dotnet or node is not installed here' };
        const e2e = join(root, hub, 'e2e');
        const why = browserProblem({ sh, join, existsSync, dir: e2e });
        if (why) return { status: 'SKIP', detail: why };
        const r = runCmd('hub-e2e', 'node', ['hub.e2e.mjs'], { cwd: e2e, timeout: 1_500_000 });
        if (r.status !== 'PASS') return r;
        const steps = (r.out.match(/^✓ /gm) || []).length;
        return { status: 'PASS', detail: `${steps} steps passed in a real browser (Chromium)` };
      },
    },
  ];
}
