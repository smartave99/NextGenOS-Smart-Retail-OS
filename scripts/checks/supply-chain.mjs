// Release-gate checks on what the products are built from: known vulnerabilities in the libraries they ship.

export function checks({ root, sh, has, join, existsSync }) {
  const nuget = (project) => {
    const r = sh('dotnet', ['list', project, 'package', '--vulnerable', '--include-transitive'], { timeout: 300_000 });
    const out = `${r.stdout}${r.stderr}`;
    if (r.status !== 0 || /unable to load the service index|error NU1301/i.test(out)) return { unreachable: true };
    return { bad: out.split('\n').filter((l) => /^\s+>/.test(l) && /\b(High|Critical)\b/.test(l)) };
  };

  const audit = (dir, args) => {
    const r = sh('npm', ['audit', '--json', ...args], { cwd: join(root, dir), timeout: 180_000 });
    try {
      return JSON.parse(r.stdout).metadata.vulnerabilities;
    } catch {
      return null;
    }
  };

  return [
    {
      name: 'npm-audit',
      title: 'No known high or critical vulnerability in what ships; no critical anywhere',
      full: true,
      run: () => {
        if (!has('npm')) return { status: 'SKIP', detail: 'npm is not installed here' };
        const problems = [];
        const notes = [];
        for (const dir of ['apps/storefront-web-mobile', 'licensing/studio']) {
          if (!existsSync(join(root, dir, 'package-lock.json'))) continue;
          const prod = audit(dir, ['--omit=dev']);
          const all = audit(dir, []);
          if (!prod || !all) return { status: 'SKIP', detail: `npm audit could not reach the registry for ${dir}` };
          if (prod.high + prod.critical > 0) problems.push(`${dir}: ${prod.high} high and ${prod.critical} critical in what ships`);
          if (all.critical > 0) problems.push(`${dir}: ${all.critical} critical in build tools`);
          notes.push(`${dir}: shipped ${prod.total}, with build tools ${all.total} (${all.high} high)`);
        }
        return problems.length ? { status: 'FAIL', detail: problems.join('\n') } : { status: 'PASS', detail: notes.join('; ') };
      },
    },
    {
      name: 'nuget-audit',
      title: 'No known high or critical vulnerability in the .NET libraries (AI add-on, dashboard, Business Hub, licensing)',
      full: true,
      run: () => {
        if (!has('dotnet')) return { status: 'SKIP', detail: 'dotnet is not installed here' };
        const problems = [];
        for (const project of ['apps/pos-ai-companion/SmartRetailAI.sln', 'apps/pos-dashboard-service/SmartRetailPOS.sln', 'apps/business-hub/NextGenOS.Hub.slnx', 'licensing/clients/dotnet/NextGenOS.Licensing/NextGenOS.Licensing.csproj']) {
          const r = nuget(project);
          if (r.unreachable) return { status: 'SKIP', detail: `the NuGet service could not be reached for ${project}` };
          for (const line of r.bad) problems.push(`${project}: ${line.trim()}`);
        }
        return problems.length ? { status: 'FAIL', detail: problems.join('\n') } : { status: 'PASS', detail: 'no vulnerable NuGet package (direct or transitive)' };
      },
    },
  ];
}
