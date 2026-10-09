#!/usr/bin/env node
// Runs every browser test of the Business Hub, one after the other, each on its own fresh shop. Exit code 0 only if all pass.
import { spawnSync } from 'node:child_process';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const scenarios = ['retail', 'restaurant', 'library', 'construction', 'services', 'wholesale', 'devices', 'look', 'looks', 'discounts', 'accounts', 'loyalty', 'estimates', 'offers', 'taxinputs', 'registers', 'stockbooks', 'itemchanges', 'itembands', 'itemsheet', 'staff', 'theme', 'profile', 'foundation', 'ai', 'events', 'map', 'insights', 'help', 'updates', 'backups', 'network'];
let failed = 0;
for (const name of scenarios) {
  console.log(`\n== ${name} ==`);
  const r = spawnSync('node', [join(here, `${name}.e2e.mjs`)], { stdio: 'inherit', timeout: 900_000 });
  if (r.status !== 0) { failed += 1; console.log(`✗ ${name} FAILED`); }
}
console.log(failed ? `\n${failed} of ${scenarios.length} scenarios failed.` : `\nAll ${scenarios.length} scenarios passed.`);
process.exit(failed ? 1 : 0);
