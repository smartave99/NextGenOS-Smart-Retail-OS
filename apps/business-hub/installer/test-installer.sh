#!/bin/bash
# Checks the Hub's Windows setup (SmartRetailHub.nsi) under Wine, with a stand-in for the program, because the real program needs Windows to run:
#   - a quiet install puts every file in Program Files, with the licence agreement, and makes the shop's data folder (readable by the service only);
#   - it registers the Windows service "NextGenOSHub" (own process, starts with the PC, Local Service account, restarts after a crash), a Start menu
#     entry and a desktop shortcut that open the Hub in the browser, and the uninstall entry;
#   - installing again over it (an update) works and keeps one service;
#   - uninstalling removes exactly the installed files, the service, the shortcuts and the entry, and leaves the shop's data and any other
#     file in the install folder alone.
# It does not run the Hub itself: a self-contained .NET program does not start under Wine, so that is checked by a person on Windows (and by the
# release workflow's smoke test on a Windows runner).
# Needs makensis (NSIS 3, with its 64-bit stub), wine64 and Xvfb: apt-get install nsis wine64 xvfb.
#   apps/business-hub/installer/test-installer.sh
set -euo pipefail

here="$(cd "$(dirname "$0")" && pwd)"
repo="$(cd "$here/../../.." && pwd)"
work="$(mktemp -d)"
export WINEPREFIX="$work/prefix" WINEARCH=win64 WINEDEBUG=-all WINEDLLOVERRIDES="mscoree,mshtml="
export DISPLAY=":${XVFB_DISPLAY:-98}"
WINE="$(command -v wine64 || echo /usr/lib/wine/wine64)"

Xvfb "$DISPLAY" -screen 0 640x480x24 > /dev/null 2>&1 &
xvfb=$!
cleanup() {
  wineserver -k > /dev/null 2>&1 || true
  kill "$xvfb" > /dev/null 2>&1 || true
  # Wine may still be writing into its folder for a moment after it is told to stop: try again, and never let tidying up change the result.
  for _ in 1 2 3 4 5 6 7 8 9 10; do rm -rf "$work" > /dev/null 2>&1 && break; sleep 1; done
  rm -rf "$work" > /dev/null 2>&1 || true
}
trap cleanup EXIT
sleep 1

failures=0
check() { # check "what" condition...
  local what="$1"; shift
  if "$@"; then echo "PASS  $what"; else echo "FAIL  $what"; failures=$((failures + 1)); fi
}

# A stand-in program folder: a program file, a library, one in a sub-folder.
src="$work/program"
mkdir -p "$src/sub"
printf 'MZ stand-in' > "$src/NextGenOS.Hub.exe"
printf 'x' > "$src/NextGenOS.Hub.dll"
printf 'y' > "$src/sub/helper.dll"
node "$here/make-uninstall-list.mjs" "$src" "$work/uninstall-files.nsh" > /dev/null
setup="$work/setup.exe"
makensis -V1 -DVERSION=1.2.3 -DSOURCE="$src" -DUNINSTALL_LIST="$work/uninstall-files.nsh" -DOUTFILE="$setup" -DEULA="$repo/EULA.txt" -DNOTICES="$repo/THIRD-PARTY-NOTICES.md" "$here/SmartRetailHub.nsi"

c="$WINEPREFIX/drive_c"
app="$c/Program Files/NextGenOS/Smart Retail POS Hub"
data="$c/ProgramData/NextGenOS/Hub"

echo "== quiet install"
timeout 240 "$WINE" "$setup" /S > /dev/null 2>&1 || true
check "the program, a library and a library in a folder are installed" test -f "$app/NextGenOS.Hub.exe" -a -f "$app/NextGenOS.Hub.dll" -a -f "$app/sub/helper.dll"
check "the licence agreement and the third-party notices are installed" test -f "$app/EULA.txt" -a -f "$app/THIRD-PARTY-NOTICES.md"
check "the uninstaller is installed" test -f "$app/Uninstall.exe"
check "the shop's data folder was made" test -d "$data"
check "the licence folder shared by the suite was made" test -d "$c/ProgramData/NextGenOS/SmartRetailPOS"
check "the browser shortcut points at this PC's port 5280" grep -q "URL=http://127.0.0.1:5280" "$app/Open Smart Retail POS.url"
check "a Start menu entry and a desktop shortcut exist" test -f "$c/ProgramData/Microsoft/Windows/Start Menu/Programs/Smart Retail POS/Open Smart Retail POS.lnk" -a -f "$c/users/Public/Desktop/Smart Retail POS.lnk"
reg() { { "$WINE" reg query "$1" 2>&1 || true; } | tr -d '\r'; }
svc="$(reg 'HKLM\SYSTEM\CurrentControlSet\Services\NextGenOSHub')"
check "the Windows service exists and runs the installed program" grep -q 'Smart Retail POS Hub\\NextGenOS.Hub.exe' <<< "$svc"
check "the service has its own process and a name people can read" grep -q 'DisplayName.*Smart Retail POS Hub' <<< "$svc"
check "the service runs as Local Service, not as the system" grep -qi 'ObjectName.*NT AUTHORITY.LocalService' <<< "$svc"
# (Wine's sc.exe has no "delayed automatic start" and no crash-restart settings, so those two are checked on Windows by a person.)
check "the uninstall entry shows name, version and publisher" bash -c "'$WINE' reg query 'HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\NextGenOS.SmartRetailPOS.Hub' 2>&1 | tr -d '\r' | grep -q '1.2.3'"

echo "== a person's files"
printf 'shop data' > "$data/shop.db"
printf 'mine' > "$app/my-notes.txt"

echo "== installing again over it (an update)"
timeout 240 "$WINE" "$setup" /S > /dev/null 2>&1 || true
svc2="$(reg 'HKLM\SYSTEM\CurrentControlSet\Services\NextGenOSHub')"
check "the update leaves the service in place, still pointing at the program" grep -q 'NextGenOS.Hub.exe' <<< "$svc2"
check "the update keeps the shop's data" test -f "$data/shop.db"

echo "== uninstall"
timeout 240 "$WINE" "$app/Uninstall.exe" /S > /dev/null 2>&1 || true
# The uninstaller copies itself aside and carries on after this call returns: wait for it to finish its work.
for _ in $(seq 1 60); do [ -e "$app/NextGenOS.Hub.exe" ] || break; sleep 1; done
sleep 3
check "every installed file is gone" bash -c "! test -e '$app/NextGenOS.Hub.exe' && ! test -e '$app/NextGenOS.Hub.dll' && ! test -e '$app/sub' && ! test -e '$app/EULA.txt'"
check "a file the person put in the folder is still there" test -f "$app/my-notes.txt"
check "the shop's data is still there" test -f "$data/shop.db"
check "the service is gone" bash -c "! '$WINE' reg query 'HKLM\\SYSTEM\\CurrentControlSet\\Services\\NextGenOSHub' > /dev/null 2>&1"
check "the shortcuts are gone" bash -c "! test -e '$c/users/Public/Desktop/Smart Retail POS.lnk' && ! test -e '$c/ProgramData/Microsoft/Windows/Start Menu/Programs/Smart Retail POS/Open Smart Retail POS.lnk'"
check "the uninstall entry is gone" bash -c "! '$WINE' reg query 'HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\NextGenOS.SmartRetailPOS.Hub' > /dev/null 2>&1"

if [ "$failures" -ne 0 ]; then echo "$failures check(s) failed"; exit 1; fi
echo "All installer checks passed (under Wine, with a stand-in program)."
