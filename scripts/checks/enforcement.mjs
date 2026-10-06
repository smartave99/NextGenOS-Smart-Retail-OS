// Release-gate checks for the Windows products: the licence check is wired into every entry point (a tripwire against someone
// removing it), and the AI add-on and the dashboard build and pass their tests.

export function checks({ root, sh, has, runCmd, read, join, existsSync, tail }) {
  const mustContain = (file, needles) => {
    const path = join(root, file);
    if (!existsSync(path)) return [`${file} is missing`];
    const text = read(file);
    return needles.filter((n) => !text.includes(n)).map((n) => `${file} no longer contains "${n}"`);
  };

  return [
    {
      name: 'enforcement',
      title: 'Every product entry point still checks the licence',
      run: () => {
        const problems = [
          ...mustContain('apps/pos-ai-companion/src/SmartRetail.AI.Desktop/Program.cs', ['LicenceGuard', 'EnsureLicensed']),
          ...mustContain('apps/pos-ai-companion/src/SmartRetail.AI.Desktop/AiLicence.cs', ['RequiredModule = Module', 'Module = "ai"']),
          ...mustContain('apps/pos-dashboard-service/src/SmartRetail.Pos.Web/Program.cs', ['UseLicenceGate()', 'AddLicensedWorker<', 'AddNextGenOSLicence("dashboard"']),
          ...mustContain('apps/pos-desktop/Source/Libraries/DevNetLM/DevNetLM/DevNet.cs', ['PosLicence.Manager', 'LicenceHeartbeat']),
          ...mustContain('apps/pos-desktop/Source/Libraries/DevNetLM/DevNetLM/PosLicence.cs', ['RequiredModule = "pos"']),
          ...mustContain('apps/storefront-web-mobile/src/middleware.ts', ['licence']),
        ];
        // The AI add-on and the dashboard must not start work before the licence: no worker may be registered without the gate.
        const program = 'apps/pos-dashboard-service/src/SmartRetail.Pos.Web/Program.cs';
        if (existsSync(join(root, program))) {
          const bare = read(program).split('\n').filter((l) => /AddHostedService</.test(l) && !/LicenceWorker/.test(l));
          for (const l of bare) problems.push(`Program.cs registers a background worker without the licence gate: ${l.trim()}`);
        }
        return problems.length ? { status: 'FAIL', detail: problems.join('\n') } : { status: 'PASS', detail: 'POS, AI app, dashboard and storefront all check the licence' };
      },
    },
    {
      name: 'dotnet-ai',
      title: 'AI add-on: build (net48 + net8) and tests',
      full: true,
      run: () => {
        if (!has('dotnet')) return { status: 'SKIP', detail: 'dotnet is not installed here' };
        const r = runCmd('dotnet-ai', 'dotnet', ['test', 'apps/pos-ai-companion/SmartRetailAI.sln', '-c', 'Release', '--nologo', '--logger', 'console;verbosity=normal']);
        if (r.status !== 'PASS') return r;
        // Only the test that needs the real Codex program (OpenAI's, not installed here) may be skipped.
        const unexpected = [...r.out.matchAll(/^\s+Skipped (\S+)/gm)].map((m) => m[1]).filter((n) => !/RealCodex/.test(n));
        return unexpected.length ? { status: 'FAIL', detail: `tests skipped that should have run:\n  ${unexpected.join('\n  ')}` } : r;
      },
    },
    {
      name: 'dotnet-dashboard',
      title: 'Dashboard: build and tests (only the tests that need SQL Server or the DINOv2 model may be skipped)',
      full: true,
      run: () => {
        if (!has('dotnet')) return { status: 'SKIP', detail: 'dotnet is not installed here' };
        const r = runCmd('dotnet-dashboard', 'dotnet', ['test', 'apps/pos-dashboard-service/SmartRetailPOS.sln', '-c', 'Release', '--nologo', '--logger', 'console;verbosity=normal']);
        if (r.status !== 'PASS') return r;
        const skipped = [...r.out.matchAll(/^\s+Skipped (\S+)/gm)].map((m) => m[1]);
        const unexpected = skipped.filter((n) => !/\.SqlServer\.|\.Vision\./.test(n));
        if (unexpected.length) return { status: 'FAIL', detail: `tests skipped that should have run:\n  ${unexpected.slice(0, 10).join('\n  ')}` };
        return { status: 'PASS', detail: `${tail({ stdout: r.out, stderr: '' }, 1)} (${skipped.length} need a SQL Server or the DINOv2 model: listed under NOT VERIFIED)` };
      },
    },
  ];
}
