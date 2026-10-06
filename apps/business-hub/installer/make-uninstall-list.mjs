#!/usr/bin/env node
// Writes the part of the uninstaller that removes exactly the files setup installed (and the folders it made, once empty), from the program folder:
//   node make-uninstall-list.mjs <program folder> <uninstall-files.nsh>
// A person's other files in the install folder are never touched: nothing is removed that is not on this list.
import { readdirSync, writeFileSync } from 'node:fs';
import { join, sep } from 'node:path';

const [folder, out] = process.argv.slice(2);
if (!folder || !out) { console.error('Usage: node make-uninstall-list.mjs <program folder> <uninstall-files.nsh>'); process.exit(2); }

const files = [];
const dirs = [];
const walk = (dir, rel) => {
  for (const e of readdirSync(dir, { withFileTypes: true })) {
    const r = rel ? rel + sep + e.name : e.name;
    if (e.isDirectory()) { dirs.push(r); walk(join(dir, e.name), r); } else files.push(r);
  }
};
walk(folder, '');
const win = (p) => p.split(sep).join('\\').replace(/\$/g, '$$$$');
const lines = ['; Written by make-uninstall-list.mjs: every file setup installed.'];
for (const f of files) lines.push(`Delete "$INSTDIR\\${win(f)}"`);
for (const d of dirs.sort((a, b) => b.length - a.length)) lines.push(`RMDir "$INSTDIR\\${win(d)}"`);
writeFileSync(out, lines.join('\r\n') + '\r\n');
console.log(`${files.length} files and ${dirs.length} folders listed for the uninstaller`);
