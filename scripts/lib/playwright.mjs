// Makes sure a folder with browser tests can start a real browser. Returns null when it can, or the reason in plain words when it cannot.
export function browserProblem({ sh, join, existsSync, dir }) {
  if (!existsSync(join(dir, 'node_modules', 'playwright'))) {
    const i = sh('npm', ['install', '--silent', '--no-audit', '--no-fund'], { cwd: dir, env: { ...process.env, PLAYWRIGHT_SKIP_BROWSER_DOWNLOAD: '1' }, timeout: 300_000 });
    if (i.status !== 0 || !existsSync(join(dir, 'node_modules', 'playwright'))) return `Playwright could not be installed here (npm install in ${dir})`;
  }
  const probe = sh('node', ['-e', "import('playwright').then(async (p) => { const b = await p.chromium.launch(); await b.close(); }).catch((e) => { console.error(String(e).slice(0, 200)); process.exit(1); })"], { cwd: dir, timeout: 60_000 });
  return probe.status === 0 ? null : 'no browser for Playwright here (run: npx playwright install chromium)';
}
