#!/bin/bash
# What CHANGELOG.md says about one version, for the release workflow (the text of the GitHub Release, and the notes the owner
# reads before installing an update) and for check-version.sh:
#
#   changelog-entry.sh 2.13.0              the whole entry: the sentence on the update, then its changes
#   changelog-entry.sh 2.13.0 --summary    only the sentence (empty when the entry has none), at most 300 letters
#
# The heading is matched whole: "## 2.1.1" never finds "## 2.1.10".
set -euo pipefail

version="${1:-}"
mode="${2:-}"
[[ "$version" =~ ^[0-9]{1,4}\.[0-9]{1,4}\.[0-9]{1,4}$ ]] || { echo "changelog-entry: the version must be three numbers, like 2.13.0" >&2; exit 2; }
[ -z "$mode" ] || [ "$mode" = "--summary" ] || { echo "changelog-entry: the only choice is --summary" >&2; exit 2; }

file="$(cd "$(dirname "$0")/.." && pwd)/CHANGELOG.md"
[ -f "$file" ] || { echo "changelog-entry: CHANGELOG.md is not there" >&2; exit 1; }

if [ "$mode" = "--summary" ]; then
  awk -v v="## $version" '
    $0 == v || index($0, v " ") == 1 { inside = 1; next }
    /^## / { inside = 0 }
    inside && NF && !/^###/ && !/^[-*] / && !/^Includes / { print substr($0, 1, 300); exit }' "$file"
else
  awk -v v="## $version" '
    $0 == v || index($0, v " ") == 1 { inside = 1; next }
    /^## / { inside = 0 }
    inside' "$file"
fi
