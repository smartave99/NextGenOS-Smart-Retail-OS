#!/bin/bash
# The version a release is made under must be the version the app and the dashboard are built with (the <Version> in the two
# Directory.Build.props files). If it were not, the setup would install an app that still reports the old number, and the
# updater would offer the same update again after every install. It must also be the newest entry of CHANGELOG.md, with at least
# one change listed: the owner reads that list in the app (What's new) and in the release, so no update goes out without its
# entry. The release workflow runs this before it builds anything, so a version that was typed wrongly stops there.
#
#   check-version.sh 2.10.0
set -euo pipefail

version="${1:-}"
[[ "$version" =~ ^[0-9]{1,4}\.[0-9]{1,4}\.[0-9]{1,4}$ ]] || { echo "check-version: the version must be three numbers, like 2.10.0" >&2; exit 2; }

# The repository root is the nearest folder above this script that holds CHANGELOG.md. The two products live in SmartRetailAI and
# SmartRetailPOS (the old layout) or in apps/pos-ai-companion and apps/pos-dashboard-service (the monorepo).
root="$(cd "$(dirname "$0")" && pwd)"
while [ "$root" != "/" ] && [ ! -f "$root/CHANGELOG.md" ]; do root="$(dirname "$root")"; done
[ -f "$root/CHANGELOG.md" ] || root="$(cd "$(dirname "$0")/.." && pwd)"
if [ -d "$root/SmartRetailAI" ]; then ai=SmartRetailAI; pos=SmartRetailPOS; else ai=apps/pos-ai-companion; pos=apps/pos-dashboard-service; fi
for props in "$ai/Directory.Build.props" "$pos/Directory.Build.props"; do
  [ -f "$root/$props" ] || { echo "check-version: $props is not there" >&2; exit 1; }
  built="$(sed -n 's:.*<Version>\([^<]*\)</Version>.*:\1:p' "$root/$props" | head -n 1)"
  if [ "$built" != "$version" ]; then
    echo "check-version: the release is asked for as $version, but $props builds ${built:-no version}: change one of them so they are the same." >&2
    exit 1
  fi
done

# The change log: the newest heading is this version, and it lists at least one change.
[ -f "$root/CHANGELOG.md" ] || { echo "check-version: CHANGELOG.md is not there" >&2; exit 1; }
newest="$(sed -n 's/^## \([0-9][0-9]*\.[0-9][0-9]*\.[0-9][0-9]*\).*/\1/p' "$root/CHANGELOG.md" | head -n 1)"
if [ "$newest" != "$version" ]; then
  echo "check-version: the release is asked for as $version, but the newest entry of CHANGELOG.md is ${newest:-missing}: add '## $version · <day>' with what changed." >&2
  exit 1
fi
changes="$(bash "$root/$ai/changelog-entry.sh" "$version" | grep -c '^[-*] ' || true)"
if [ "$changes" -lt 1 ]; then
  echo "check-version: the entry for $version in CHANGELOG.md lists no change: write what is new, improved or fixed." >&2
  exit 1
fi

echo "The release $version is the version of the code, and CHANGELOG.md says what changed ($changes $([ "$changes" -eq 1 ] && echo change || echo changes))."

