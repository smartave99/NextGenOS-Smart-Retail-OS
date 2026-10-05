#!/bin/bash
# Checks the setup's quiet update mode (SmartRetailAI-Setup /S /UPDATE) under Wine, with stand-ins for the app: what an
# update the app starts itself has to do (see installer/SmartRetailAI.nsi):
#   - an update waits for the running app to quit, instead of asking someone to close it;
#   - it keeps what the owner chose: a desktop shortcut that was deleted, or start with Windows that was turned off,
#     does not come back, while a shortcut and start with Windows the owner still has stay;
#   - start with Windows ticked in a normal setup also switches the entry on again in Windows' list of start-up apps (Task Manager)
#     if someone had switched an earlier copy off; an update leaves that as it was;
#   - it gives up (and installs nothing) when the app does not quit in time, and without /UPDATE a quiet setup still stops
#     at once when the app is running;
#   - the version, the files and the uninstaller are the new ones, and its uninstaller removes exactly them.
# Needs makensis (NSIS 3, with its 64-bit stub), wine64 and Xvfb: apt-get install nsis wine64 xvfb. No .NET, no WebView2.
#   SmartRetailAI/installer/test-update.sh
set -euo pipefail

here="$(cd "$(dirname "$0")" && pwd)"
work="$(mktemp -d)"
export WINEPREFIX="$work/prefix" WINEARCH=win64 WINEDEBUG=-all WINEDLLOVERRIDES="mscoree,mshtml="
export DISPLAY=":${XVFB_DISPLAY:-97}"

Xvfb "$DISPLAY" -screen 0 640x480x24 > /dev/null 2>&1 &
xvfb=$!
cleanup() {
  wineserver -k > /dev/null 2>&1 || true
  kill "$xvfb" > /dev/null 2>&1 || true
  rm -rf "$work"
}
trap cleanup EXIT
sleep 1

pass=0
fail() {
  echo "FAILED: $1"
  echo "--- the last setup's output:"
  tail -n 20 "$work/setup.log" 2> /dev/null || true
  echo "--- in the Wine drive:"
  find "$WINEPREFIX/drive_c" -maxdepth 3 \( -path "*/windows" -o -path "*/Program Files*" \) -prune -o -newer "$work/app.exe" -print 2> /dev/null | head -20
  exit 1
}
ok() { pass=$((pass + 1)); echo "ok - $1"; }
check() { if eval "$2"; then ok "$1"; else fail "$1 ($2)"; fi; }

# Stand-ins: "the app" (does nothing) and a holder that has the app's single-instance mutex for a few seconds and says so.
cat > "$work/app.nsi" <<'EOF'
Unicode true
Target amd64-unicode
OutFile "app.exe"
SilentInstall silent
RequestExecutionLevel user
Section
SectionEnd
EOF
cat > "$work/holder.nsi" <<'EOF'
Unicode true
Target amd64-unicode
!ifndef SECONDS
  !define SECONDS 6
!endif
!define /math MILLISECONDS ${SECONDS} * 1000
OutFile "holder-${SECONDS}.exe"
SilentInstall silent
RequestExecutionLevel user
Section
  System::Call 'kernel32::CreateMutexW(p 0, i 1, w "NextGenOS.SmartRetailPOS.AIAssistant") p .r0'
  FileOpen $1 "$EXEDIR\holding" w
  FileClose $1
  Sleep ${MILLISECONDS}
SectionEnd
EOF
(cd "$work" && makensis -V1 app.nsi && makensis -V1 -DSECONDS=6 holder.nsi && makensis -V1 -DSECONDS=40 holder.nsi)

# A package like build.ps1's, with a version in a file, and the list of what it installs (deepest folders first).
make_package() { # folder version
  mkdir -p "$1/sql"
  cp "$work/app.exe" "$1/SmartRetailAI.exe"
  echo "$2" > "$1/version.txt"
  echo "readme $2" > "$1/README.md"
  echo "select $2" > "$1/sql/login.sql"
  (
    cd "$1"
    find . -type f | sed 's|^\./||' | sort | while read -r file; do printf 'Delete "$INSTDIR\\%s"\n' "${file//\//\\}"; done
    find . -mindepth 1 -type d | sed 's|^\./||' | awk '{ print length($0) " " $0 }' | sort -rn | cut -d' ' -f2- | while read -r dir; do printf 'RMDir "$INSTDIR\\%s"\n' "${dir//\//\\}"; done
  ) > "$1.nsh"
}
build_setup() { # version package output [more makensis options]
  local version="$1" package="$2" output="$3"
  shift 3
  makensis -V1 "-DVERSION=$version" "-DSOURCE=$package" "-DUNINSTALL_LIST=$package.nsh" "-DOUTFILE=$output" "$@" "$here/SmartRetailAI.nsi"
}
make_package "$work/pkg1" 1
make_package "$work/pkg2" 2
build_setup 1.0.0 "$work/pkg1" "$work/setup-1.0.0.exe"
build_setup 2.0.0 "$work/pkg2" "$work/setup-2.0.0.exe"
build_setup 3.0.0 "$work/pkg2" "$work/setup-3.0.0-quick-give-up.exe" -DUPDATE_WAIT_SECONDS=3

wineboot -u > /dev/null 2>&1
wineserver -w
# The setup wants .NET Framework 4.8 (the app runs on it); Wine here has none, so the registry says it is there.
wine reg add 'HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full' /v Release /t REG_DWORD /d 533320 /f > /dev/null 2>&1
wineserver -w

profile="$WINEPREFIX/drive_c/users/$(id -un)"
app="$WINEPREFIX/drive_c/App"
desktop="$profile/Desktop/Smart Retail POS AI.lnk"
menu="$profile/AppData/Roaming/Microsoft/Windows/Start Menu/Programs/Smart Retail POS AI.lnk"
runkey='HKCU\Software\Microsoft\Windows\CurrentVersion\Run'
runvalue='SmartRetailPOS-AI-Assistant'
approvedkey='HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run'
uninstallkey='HKCU\Software\Microsoft\Windows\CurrentVersion\Uninstall\NextGenOS.SmartRetailPOS.AI'

# Wine quotes arguments with spaces, so /D= goes through cmd.
run_setup() { # setup [options]
  local setup="$1"
  shift
  (cd "$work" && wine cmd /c "$setup $* /D=C:\\App") > "$work/setup.log" 2>&1
}
has_run_value() { wine reg query "$runkey" /v "$runvalue" > /dev/null 2>&1; }
# Windows keeps a value like this in its list of start-up apps when someone switches an entry off (Task Manager).
switch_off_in_windows() { wine reg add "$approvedkey" /v "$runvalue" /t REG_BINARY /d 030000000000000000000000 /f > /dev/null 2>&1; }
is_switched_off_in_windows() { wine reg query "$approvedkey" /v "$runvalue" > /dev/null 2>&1; }
version_installed() { wine reg query "$uninstallkey" /v DisplayVersion 2> /dev/null | tr -d '\r' | awk '/DisplayVersion/ { print $3 }'; }
hold() { # holder
  rm -f "$work/holding"
  (cd "$work" && wine "$1" > /dev/null 2>&1) &
  for _ in $(seq 1 60); do [ -f "$work/holding" ] && return 0; sleep 0.5; done
  fail "the stand-in for the running app did not start"
}

echo "== a first install, as always"
switch_off_in_windows   # an earlier copy was switched off in Windows' list of start-up apps
run_setup setup-1.0.0.exe /S /CurrentUser || true
wineserver -w
check "version 1 is installed" '[ "$(cat "$app/version.txt" 2>/dev/null)" = "1" ] && [ "$(version_installed)" = "1.0.0" ]'
check "it made the desktop shortcut, the Start menu one and start with Windows" '[ -f "$desktop" ] && [ -f "$menu" ] && has_run_value'
check "start with Windows, ticked in the setup, is on again in Windows' list as well" '! is_switched_off_in_windows'

echo "== an update while the app is running: it waits for the app, and keeps the owner's choices"
rm -f "$desktop"
wine reg delete "$runkey" /v "$runvalue" /f > /dev/null 2>&1
hold holder-6.exe
started=$(date +%s)
run_setup setup-2.0.0.exe /S /UPDATE /CurrentUser || true
took=$(( $(date +%s) - started ))
wineserver -w
check "it waited for the app to quit (took ${took} s)" '[ "$took" -ge 3 ]'
check "version 2 is installed: files and version" '[ "$(cat "$app/version.txt")" = "2" ] && [ "$(version_installed)" = "2.0.0" ] && grep -q "select 2" "$app/sql/login.sql"'
check "the desktop shortcut that was deleted did not come back" '[ ! -f "$desktop" ]'
check "start with Windows, turned off, did not come back" '! has_run_value'
check "the Start menu shortcut and the uninstaller are there" '[ -f "$menu" ] && [ -f "$app/Uninstall.exe" ]'

echo "== an update keeps what the owner still has"
run_setup setup-1.0.0.exe /S /CurrentUser || true   # to have both again: a normal quiet install
wineserver -w
check "a normal quiet install makes them again" '[ -f "$desktop" ] && has_run_value'
switch_off_in_windows   # someone switched it off in Windows' list of start-up apps
run_setup setup-2.0.0.exe /S /UPDATE /CurrentUser || true
wineserver -w
check "the update keeps the desktop shortcut and start with Windows" '[ -f "$desktop" ] && has_run_value && [ "$(version_installed)" = "2.0.0" ]'
check "and does not switch it on again against what was chosen in Windows" 'is_switched_off_in_windows'

echo "== when the app does not quit in time, nothing is installed"
run_setup setup-1.0.0.exe /S /CurrentUser || true   # back to version 1
wineserver -w
hold holder-40.exe
started=$(date +%s)
if run_setup setup-3.0.0-quick-give-up.exe /S /UPDATE /CurrentUser; then code=0; else code=$?; fi
took=$(( $(date +%s) - started ))
check "the update gave up after its wait and did not install (exit code $code after ${took} s)" '[ "$code" -ne 0 ] && [ "$(cat "$app/version.txt")" = "1" ] && [ "$(version_installed)" = "1.0.0" ]'

echo "== without /UPDATE, a quiet setup still stops at once while the app runs"
started=$(date +%s)
if run_setup setup-2.0.0.exe /S /CurrentUser; then code=0; else code=$?; fi
took=$(( $(date +%s) - started ))
check "it stopped straight away and installed nothing (exit code $code after ${took} s)" '[ "$code" -ne 0 ] && [ "$took" -lt 15 ] && [ "$(cat "$app/version.txt")" = "1" ]'
wineserver -k > /dev/null 2>&1 || true
wineserver -w 2> /dev/null || true

echo "== uninstall: exactly what was installed goes"
mkdir -p "$app/keep"
echo mine > "$app/keep/notes.txt"
run_setup setup-2.0.0.exe /S /UPDATE /CurrentUser || true
wineserver -w
(cd "$work" && wine cmd /c 'C:\App\Uninstall.exe /S _?=C:\App') > /dev/null 2>&1 || true
wineserver -w
check "the program's files and the uninstaller are gone" '[ ! -f "$app/version.txt" ] && [ ! -f "$app/SmartRetailAI.exe" ] && [ ! -d "$app/sql" ]'
check "a folder of the owner's in the same place is left alone" '[ -f "$app/keep/notes.txt" ]'
check "the shortcuts and the entries are gone" '[ ! -f "$desktop" ] && [ ! -f "$menu" ] && ! has_run_value'

echo "All $pass checks passed."
