#!/bin/sh
# Opens the Brand Studio in your web browser. Needs Node.js (https://nodejs.org), version 22 or newer.
cd "$(dirname "$0")/../.." || exit 1
command -v node >/dev/null 2>&1 || { echo "Node.js is not installed. Install it from https://nodejs.org and run this again."; exit 1; }
exec node tools/brand-studio/brand.mjs serve --open
