#!/bin/sh
# For people working on the Studio from the source copy: runs it in this terminal and opens a tab in your usual browser. Staff use the bundle's setup-studio.sh, which opens a window of its own. A bundle carries its own Node.js (node/bin/node); a source copy needs Node.js 22 or newer.
cd "$(dirname "$0")" || exit 1
if [ -x node/bin/node ]; then NODE=node/bin/node; else NODE=node; command -v node >/dev/null 2>&1 || { echo "Node.js is not installed. Install it from https://nodejs.org and run this again."; exit 1; }; fi
exec "$NODE" studio.mjs serve --open
