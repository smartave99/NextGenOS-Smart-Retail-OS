// Release-gate checks for the country packs and the tax engine, and for country assumptions creeping back into the products.

export function checks({ root, sh, has, runCmd, repoFiles, read, isText, join, existsSync }) {
  return [
    {
      name: 'country-packs',
      title: 'Country packs are sound, the vectors are current and the copies are in step',
      run: () => (has('node') ? runCmd('country-packs', 'node', ['country-packs/tools/cli.mjs', 'check'], { cwd: root }) : { status: 'SKIP', detail: 'node is not installed here' }),
    },
    {
      name: 'industry-packs',
      title: 'Industry packs are sound and the storefront copy is in step',
      run: () => (has('node') ? runCmd('industry-packs', 'node', ['industry-packs/tools/cli.mjs', 'check'], { cwd: root }) : { status: 'SKIP', detail: 'node is not installed here' }),
    },
    {
      name: 'no-country-in-code',
      title: "No country's money, language or tax written into the storefront (it all comes from the country pack)",
      run: () => {
        const allowed = /(\.test\.tsx?$|\/lib\/region\/|\/lib\/shop-facts\.ts$|\/\.next\/|\/node_modules\/)/;
        const patterns = [
          [/₹/, 'the rupee sign (use money() from lib/region/lite)'],
          [/["'`]en-IN["'`]/, '"en-IN" (use LOCALE from lib/region/lite)'],
          [/\bINR\b/, '"INR" (use CURRENCY.code)'],
          [/\bPatna\b|\bPatliputra\b|\bBihar\b/, "one shop's town"],
        ];
        const hits = [];
        for (const f of repoFiles()) {
          if (!f.startsWith('apps/storefront-web-mobile/src/') || !/\.(ts|tsx)$/.test(f) || allowed.test('/' + f)) continue;
          const lines = read(f).split('\n');
          lines.forEach((line, i) => {
            const code = line.replace(/\/\/.*$/, '').replace(/\/\*.*?\*\//g, '');
            if (/^\s*(\*|\/\*)/.test(line)) return;
            for (const [re, what] of patterns) if (re.test(code)) hits.push(`${f}:${i + 1}: ${what}`);
          });
        }
        return hits.length ? { status: 'FAIL', detail: hits.slice(0, 40).join('\n') } : { status: 'PASS', detail: 'the storefront reads its country from the pack' };
      },
    },
    {
      name: 'dotnet-tax',
      title: '.NET tax library: builds for .NET Framework 4.8 and .NET 8, passes every vector',
      full: true,
      run: () => (has('dotnet') ? runCmd('dotnet-tax', 'dotnet', ['test', 'libs/dotnet/NextGenOS.Tax.Tests', '-c', 'Release', '--nologo'], { cwd: root }) : { status: 'SKIP', detail: 'dotnet is not installed here' }),
    },
  ];
}
