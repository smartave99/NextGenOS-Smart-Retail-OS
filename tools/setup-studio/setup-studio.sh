#!/bin/sh
# Opens the NextGenOS Setup Studio in your web browser. A bundle carries its own Node.js (node/bin/node); a source copy needs Node.js 22 or newer.
cd "$(dirname "$0")" || exit 1
if [ -x node/bin/node ]; then NODE=node/bin/node; else NODE=node; command -v node >/dev/null 2>&1 || { echo "Node.js is not installed. Install it from https://nodejs.org and run this again."; exit 1; }; fi
exec "$NODE" studio.mjs serve --open
