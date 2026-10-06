// Release-gate checks for the website package (scripts/make-website-package.mjs): what goes into a customer's website, what never does, and that the real package
// is built here, audited, started with its own Node.js and refuses to work without a licence (CLAUDE.md, sections 3 and 6).

export function checks({ root, has, runCmd, join, existsSync }) {
  return [
    {
      name: 'website-package-tests',
      title: 'The website package: settings checked, names that escape refused, what goes in and what never does, the start program, the audits pass a good package and refuse a planted file, key or .env',
      run: () => {
        const r = runCmd('website-package-tests', 'node', ['--test', 'scripts/tests/make-website-package.test.mjs', 'scripts/tests/website-app-mode.test.mjs']);
        if (r.status !== 'PASS') return r;
        const n = /# pass (\d+)/.exec(r.out);
        return { status: 'PASS', detail: `${n ? n[1] : 'all'} tests passed` };
      },
    },
    {
      name: 'website-package',
      title: 'The real website package: built (next build) for a customer, audited, unpacked, started with its own Node.js, refuses without a licence, works with a licence from a real Licence Studio',
      full: true,
      run: () => {
        if (!has('node')) return { status: 'SKIP', detail: 'node is not installed here' };
        if (process.platform !== 'linux' && process.platform !== 'win32') return { status: 'SKIP', detail: 'a website package is built on Windows or Linux only' };
        if (process.platform === 'linux' && !has('unzip')) return { status: 'SKIP', detail: 'unzip is not installed here (apt-get install unzip)' };
        if (!existsSync(join(root, 'apps', 'storefront-web-mobile', 'node_modules'))) return { status: 'SKIP', detail: 'run npm ci in apps/storefront-web-mobile first' };
        // One build serves everything: the package is made from a copy of the website that has a throw-away Studio's public key built in (the repository is not changed),
        // the audits are run on the folder and the zip, the unlicensed package is started and must refuse, then a licence from that Studio is put in and it must work.
        const r = runCmd('website-package', 'node', ['licensing/e2e/with-studio.mjs', '--', 'node', 'licensing/e2e/website-package-e2e.mjs'], { timeout: 1_500_000 });
        if (r.status !== 'PASS') {
          if (/nodejs\.org|fetch failed|ENOTFOUND|could not be downloaded/i.test(r.out) && !/FAIL {2}/.test(r.out)) return { status: 'SKIP', detail: `Node.js could not be fetched from nodejs.org (no network?):\n${r.detail}` };
          return r;
        }
        const passed = (r.out.match(/^PASS /gm) || []).length;
        return { status: 'PASS', detail: `${passed} checks passed: package built, both audits pass, started with its own Node.js, refuses with no licence, serves with a licence (Linux build only; the Windows package is built and started by the release workflow)` };
      },
    },
  ];
}
