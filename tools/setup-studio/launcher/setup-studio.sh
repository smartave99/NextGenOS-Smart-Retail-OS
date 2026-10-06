#!/bin/sh
# Opens the NextGenOS Setup Studio in a window of its own. The bundle carries its own Node.js.
#   ./setup-studio.sh                  opens the Studio; this terminal can be closed at once
#   ./setup-studio.sh --install-menu   puts "NextGenOS Setup Studio" in the applications menu, so it opens like any other program
#   ./setup-studio.sh --show           runs the Studio in this terminal and shows what it says (for finding a problem)
here="$(cd "$(dirname "$0")" && pwd)" || exit 1
studio="$here/tools/setup-studio"
cd "$studio" || exit 1
if [ ! -x ./node/bin/node ]; then echo "The Setup Studio's files are not all here. Unpack the whole zip again and run this from the unpacked folder."; exit 1; fi
case "${1:-}" in
  --show) exec ./node/bin/node studio.mjs serve --open ;;
  --install-menu)
    dir="${XDG_DATA_HOME:-$HOME/.local/share}/applications"
    mkdir -p "$dir" || exit 1
    cat > "$dir/nextgenos-setup-studio.desktop" <<DESKTOP
[Desktop Entry]
Type=Application
Name=NextGenOS Setup Studio
Comment=Turn a customer's details into a ready-to-install Smart Retail POS
Exec="$here/setup-studio.sh"
Icon=$studio/ui/icon.svg
Terminal=false
Categories=Office;
DESKTOP
    echo "Done. Find \"NextGenOS Setup Studio\" in your applications menu."
    exit 0 ;;
esac
log="${XDG_CACHE_HOME:-$HOME/.cache}/nextgenos-setup-studio.log"
mkdir -p "$(dirname "$log")" 2>/dev/null
nohup ./node/bin/node studio.mjs serve --app > "$log" 2>&1 &
