#!/bin/bash
# Publishes a release to the update folder online (a public folder of the owner's Supabase Storage), where the app looks for
# automatic updates (SmartRetailAI/README.md, "Automatic updates"). The release workflow runs it, only for a release started by
# hand on main, and only once the update folder is set up. It:
#   1. names the setup SmartRetailAI-Setup-<version>.exe and works out its SHA-256, and cuts it into pieces of 32 MiB when it is
#      bigger (a free Supabase plan takes no file over 50 MiB; the app joins the pieces and checks the whole);
#   2. asks GitHub Actions for a signed statement (an OIDC token) whose audience is the version and that SHA-256: the app
#      installs only what GitHub says this project's own release made, so even whoever can write to the folder cannot make
#      the app install anything else;
#   3. writes latest.json (version, file, SHA-256, size, piece size, what is new, the statement);
#   4. signs in to Supabase as the one user that may write to the folder (never the project's service key), uploads the pieces
#      first and latest.json last, so the app never sees a description of files that are not there yet, then checks from the
#      outside that the public folder shows them; and removes the files of versions older than the last two.
#
#   publish-update.sh --version 2.9.0 --setup SmartRetailAI/dist/SmartRetailAI-Setup.exe [--notes "What is new."]
#
# From the environment (the workflow sets them): UPDATE_FEED_URL, the public folder, e.g.
#   https://<project>.supabase.co/storage/v1/object/public/app-updates/
# UPDATE_ANON_KEY (the project's public key), UPDATE_UPLOAD_EMAIL and UPDATE_UPLOAD_PASSWORD (the uploader), and GitHub's
# ACTIONS_ID_TOKEN_REQUEST_URL and ACTIONS_ID_TOKEN_REQUEST_TOKEN (given to a job that has "id-token: write").
# UPDATE_DRY_RUN_DIR: only write the files there, upload nothing (the tests use it). UPDATE_PART_BYTES: the piece size.
set -euo pipefail

fail() { echo "publish-update: $1" >&2; exit 1; }
usage() { echo "Usage: publish-update.sh --version 2.9.0 --setup <SmartRetailAI-Setup.exe> [--notes 'What is new.']" >&2; exit 2; }

version="" setup="" notes=""
while [ $# -gt 0 ]; do
  case "$1" in
    --version) version="${2:-}"; shift 2 ;;
    --setup) setup="${2:-}"; shift 2 ;;
    --notes) notes="${2:-}"; shift 2 ;;
    *) usage ;;
  esac
done
[[ "$version" =~ ^[0-9]{1,4}\.[0-9]{1,4}\.[0-9]{1,4}$ ]] || fail "the version must be three numbers, like 2.9.0"
[ -f "$setup" ] || fail "the setup file $setup is not there"
notes="${notes:0:300}"

feed="${UPDATE_FEED_URL:-}"
[[ "$feed" =~ ^(https://[^/?#@]+)/storage/v1/object/public/([A-Za-z0-9._-]+)/$ ]] \
  || fail "UPDATE_FEED_URL must look like https://<project>.supabase.co/storage/v1/object/public/app-updates/ (https, ending in /)"
host="${BASH_REMATCH[1]}"
bucket="${BASH_REMATCH[2]}"

min_part=$((1024 * 1024))
max_part=$((64 * 1024 * 1024))
max_size=$((500 * 1024 * 1024))
max_parts=64
part_bytes="${UPDATE_PART_BYTES:-33554432}"
[[ "$part_bytes" =~ ^[0-9]+$ ]] && [ "$part_bytes" -ge "$min_part" ] && [ "$part_bytes" -le "$max_part" ] || fail "UPDATE_PART_BYTES must be between 1 MiB and 64 MiB"

work="$(mktemp -d)"
trap 'rm -rf "$work"' EXIT
name="SmartRetailAI-Setup-$version.exe"
cp "$setup" "$work/$name"
size="$(stat -c %s "$work/$name")"
[ "$size" -gt 0 ] && [ "$size" -le "$max_size" ] || fail "the setup's size ($size bytes) is not one the app accepts"
sha="$(sha256sum "$work/$name" | cut -d' ' -f1)"

# The setup as it is put online: one file, or pieces of $part_bytes (the last is what is left), numbered 001, 002, ...
if [ "$size" -gt "$part_bytes" ]; then
  parts=$(( (size + part_bytes - 1) / part_bytes ))
  [ "$parts" -le "$max_parts" ] || fail "the setup would need $parts pieces; the app takes at most $max_parts"
  split -b "$part_bytes" -d -a 3 --numeric-suffixes=1 "$work/$name" "$work/$name."
  rm "$work/$name"
  part_size="$part_bytes"
  mapfile -t files < <(ls "$work/$name".[0-9][0-9][0-9] | sort)
  [ "${#files[@]}" -eq "$parts" ] || fail "cutting the setup gave ${#files[@]} pieces, not $parts"
else
  part_size=0
  files=("$work/$name")
fi

# GitHub's signed statement that this project's own release made this setup: its audience is the version and the SHA-256.
audience="smartretail-update:$version:$sha"
[ -n "${ACTIONS_ID_TOKEN_REQUEST_URL:-}" ] && [ -n "${ACTIONS_ID_TOKEN_REQUEST_TOKEN:-}" ] \
  || fail "no signed statement can be asked for: the job needs 'permissions: id-token: write'"
encoded="$(jq -rn --arg a "$audience" '$a | @uri')"
statement="$(curl -sS --fail --retry 3 -H "Authorization: bearer $ACTIONS_ID_TOKEN_REQUEST_TOKEN" -H "Accept: application/json" \
  "${ACTIONS_ID_TOKEN_REQUEST_URL}&audience=${encoded}" | jq -r '.value // empty')"
[[ "$statement" =~ ^[A-Za-z0-9_-]+\.[A-Za-z0-9_-]+\.[A-Za-z0-9_-]+$ ]] || fail "GitHub did not give a signed statement"

jq -n --arg v "$version" --arg f "$name" --arg s "$sha" --argjson size "$size" --argjson partSize "$part_size" --arg notes "$notes" --arg st "$statement" \
  '{Version: $v, File: $f, Sha256: $s, Size: $size, PartSize: $partSize, Notes: $notes, Statement: $st}' > "$work/latest.json"

if [ -n "${UPDATE_DRY_RUN_DIR:-}" ]; then
  mkdir -p "$UPDATE_DRY_RUN_DIR"
  cp "${files[@]}" "$work/latest.json" "$UPDATE_DRY_RUN_DIR/"
  echo "Version $version written to $UPDATE_DRY_RUN_DIR (${#files[@]} file(s) and latest.json), nothing uploaded."
  exit 0
fi

: "${UPDATE_ANON_KEY:?UPDATE_ANON_KEY is not set}" "${UPDATE_UPLOAD_EMAIL:?UPDATE_UPLOAD_EMAIL is not set}" "${UPDATE_UPLOAD_PASSWORD:?UPDATE_UPLOAD_PASSWORD is not set}"
api="$host/storage/v1/object/$bucket"

# The uploader's own sign-in: what it can do is only what the folder's policies give that one user (cloud/supabase-app-updates.sql).
token="$(jq -n --arg e "$UPDATE_UPLOAD_EMAIL" --arg p "$UPDATE_UPLOAD_PASSWORD" '{email: $e, password: $p}' \
  | curl -sS --fail --retry 3 -X POST "$host/auth/v1/token?grant_type=password" -H "apikey: $UPDATE_ANON_KEY" -H "Content-Type: application/json" --data-binary @- \
  | jq -r '.access_token // empty')" || token=""
[ -n "$token" ] || fail "signing in as the uploader did not work: check UPDATE_UPLOAD_EMAIL, UPDATE_UPLOAD_PASSWORD and UPDATE_ANON_KEY"

upload() { # file, name in the folder, content type
  curl -sS --fail --retry 3 -X POST "$api/$2" -H "Authorization: Bearer $token" -H "apikey: $UPDATE_ANON_KEY" \
    -H "x-upsert: true" -H "Content-Type: $3" --data-binary "@$1" > /dev/null \
    || fail "uploading $2 did not work: does the folder '$bucket' exist, and may the uploader write to it?"
}
for file in "${files[@]}"; do
  upload "$file" "$(basename "$file")" application/octet-stream
done
upload "$work/latest.json" latest.json application/json

# From the outside, as the app sees it: the description and every piece, with the right size.
seen="$(curl -sS --fail --retry 3 "${feed}latest.json?check=$(date +%s)" | jq -r '.Sha256 // empty')" || seen=""
[ "$seen" = "$sha" ] || fail "the public folder does not show the new latest.json: is the folder '$bucket' public?"
for file in "${files[@]}"; do
  got="$(curl -sS --fail --retry 3 -o /dev/null -w '%{size_download}' "${feed}$(basename "$file")")" || got=""
  [ "$got" = "$(stat -c %s "$file")" ] || fail "the public folder does not give $(basename "$file") whole"
done

# Only the last two versions stay online (a PC in the middle of a download of the one before is not cut off).
remove_old() {
  local listing name number keep=() old=() versions
  listing="$(jq -n '{prefix: "", limit: 1000, offset: 0}' \
    | curl -sS --fail -X POST "$host/storage/v1/object/list/$bucket" -H "Authorization: Bearer $token" -H "apikey: $UPDATE_ANON_KEY" -H "Content-Type: application/json" --data-binary @-)" || return 0
  versions="$(printf '%s' "$listing" | jq -r '.[].name | select(test("^SmartRetailAI-Setup-[0-9]+\\.[0-9]+\\.[0-9]+\\.exe"))' \
    | sed -E 's/^SmartRetailAI-Setup-([0-9]+\.[0-9]+\.[0-9]+)\.exe.*/\1/' | sort -Vu | sort -Vr | head -n 2)"
  while read -r name; do
    number="${name#SmartRetailAI-Setup-}"
    number="${number%%.exe*}"
    if printf '%s\n' "$versions" | grep -qx -- "$number"; then keep+=("$name"); else old+=("$name"); fi
  done < <(printf '%s' "$listing" | jq -r '.[].name | select(test("^SmartRetailAI-Setup-[0-9]+\\.[0-9]+\\.[0-9]+\\.exe"))')
  [ "${#old[@]}" -gt 0 ] || return 0
  printf '%s\n' "${old[@]}" | jq -R . | jq -s '{prefixes: .}' \
    | curl -sS --fail -X DELETE "$api" -H "Authorization: Bearer $token" -H "apikey: $UPDATE_ANON_KEY" -H "Content-Type: application/json" --data-binary @- > /dev/null || return 0
  echo "Removed from the update folder: ${old[*]}"
}
remove_old || echo "Older versions could not be removed from the update folder; they stay until next time."

echo "Version $version is in the update folder: ${#files[@]} file(s) and latest.json."
