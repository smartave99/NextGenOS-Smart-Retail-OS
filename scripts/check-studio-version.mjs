#!/usr/bin/env node
/**
 * A Setup Studio release is made from a tag such as studio-v1.0.0 or studio-v1.0.0-rc1. The Studio carries its own version number
 * (tools/setup-studio/package.json) and writes it into the file names it is given, so the tag must name that same number:
 * otherwise the page would say one version and the files another.
 *
 *   node scripts/check-studio-version.mjs studio-v1.0.0-rc1 [--package tools/setup-studio/package.json]
 *
 * Exit 0 when the tag is a Studio tag and its number is the Studio's version; 1 with a plain message when it is not.
 */
import { readFileSync } from 'node:fs';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const args = process.argv.slice(2);
const tag = args.find((a) => !a.startsWith('--') && args[args.indexOf(a) - 1] !== '--package') ?? '';
const packageFile = resolve(args.includes('--package') ? args[args.indexOf('--package') + 1] : join(here, '..', 'tools', 'setup-studio', 'package.json'));

const m = /^studio-v(\d+\.\d+\.\d+)(?:-(?:rc|beta|alpha)\d+)?$/.exec(tag);
if (!m) {
  console.error(`"${tag}" is not a Setup Studio release tag. Name it studio-v1.0.0 (or studio-v1.0.0-rc1 to try it first): "studio-v", three numbers, and for a trial "-rc", "-beta" or "-alpha" and a number.`);
  process.exit(1);
}
let version;
try { version = JSON.parse(readFileSync(packageFile, 'utf8')).version; } catch { console.error(`The Studio's version could not be read from ${packageFile}.`); process.exit(1); }
if (version !== m[1]) {
  console.error(`The tag ${tag} says version ${m[1]}, but the Setup Studio in this code is version ${version}. Change the version in tools/setup-studio/package.json (and its lock file) first, or name the tag studio-v${version}.`);
  process.exit(1);
}
console.log(`The tag ${tag} matches the Setup Studio version ${version}.`);
