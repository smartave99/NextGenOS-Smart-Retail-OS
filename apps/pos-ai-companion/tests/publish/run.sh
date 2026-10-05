#!/bin/bash
# Checks publish-update.sh's talk to Supabase against a stand-in for it and for GitHub's token service (supabase-stand-in.py),
# over https with a certificate for shop.supabase.co, so the script runs unchanged: the uploader's sign-in, the pieces before
# latest.json, the headers, the check from outside, the removal of old versions, and what happens when something is wrong.
# Needs bash, curl, jq, python3 and openssl.
#   SmartRetailAI/tests/publish/run.sh
set -euo pipefail
here="$(cd "$(dirname "$0")" && pwd)"
script="$here/../../publish-update.sh"
work="$(mktemp -d)"
port=$(( 20000 + RANDOM % 20000 ))
pid=""
cleanup() { [ -n "$pid" ] && kill "$pid" > /dev/null 2>&1 || true; rm -rf "$work"; }
trap cleanup EXIT

pass=0
ok() { pass=$((pass + 1)); echo "ok - $1"; }
fail() { echo "FAILED: $1"; [ -f "$work/output.txt" ] && tail -n 15 "$work/output.txt"; exit 1; }

# The certificate the stand-in answers with, and curl told to reach shop.supabase.co there, and to trust that certificate.
openssl req -x509 -newkey rsa:2048 -nodes -days 1 -subj "/CN=shop.supabase.co" -addext "subjectAltName=DNS:shop.supabase.co" \
  -keyout "$work/key.pem" -out "$work/cert.pem" > /dev/null 2>&1
mkdir "$work/curl"
printf 'connect-to = "shop.supabase.co:443:127.0.0.1:%s"\nnoproxy = "*"\n' "$port" > "$work/curl/.curlrc"
unset HTTPS_PROXY https_proxy HTTP_PROXY http_proxy ALL_PROXY all_proxy
export CURL_HOME="$work/curl" CURL_CA_BUNDLE="$work/cert.pem" SSL_CERT_FILE="$work/cert.pem"

start() { # extra stand-in options
  python3 "$here/supabase-stand-in.py" --port "$port" --cert "$work/cert.pem" --key "$work/key.pem" --log "$work/log.json" "$@" &
  pid=$!
  for _ in $(seq 1 50); do curl -sS -o /dev/null "http://127.0.0.1:$((port + 1))/oidc" 2> /dev/null && return 0; sleep 0.2; done
  fail "the stand-in did not start"
}
stop() {
  curl -sS -o /dev/null "http://127.0.0.1:$((port + 1))/__stop" || true
  wait "$pid" 2> /dev/null || true
  pid=""
}

export UPDATE_FEED_URL="https://shop.supabase.co/storage/v1/object/public/app-updates/"
export UPDATE_ANON_KEY="the-public-key" UPDATE_UPLOAD_EMAIL="uploader@example.com" UPDATE_UPLOAD_PASSWORD="a long password"
export ACTIONS_ID_TOKEN_REQUEST_URL="http://127.0.0.1:$((port + 1))/oidc?api-version=2.0" ACTIONS_ID_TOKEN_REQUEST_TOKEN="request-token"
export UPDATE_PART_BYTES=1048576

setup() { head -c "$1" /dev/urandom > "$work/setup.exe"; }
publish() { # version -> output.txt, exit code
  if "$script" --version "$1" --setup "$work/setup.exe" --notes "Notes for $1." > "$work/output.txt" 2>&1; then return 0; else return 1; fi
}

echo "== three releases: the pieces, the order, the headers, and only the last two versions stay"
start
for version in 1.0.0 1.1.0 1.2.0; do
  setup 1500000
  publish "$version" || fail "publishing $version"
done
stop
result="$(cat "$work/log.json")"
[ "$(echo "$result" | jq -r '.log | map(select(.call == "sign-in")) | length')" = "3" ] && ok "it signed in once for each release" || fail "sign-ins"
[ "$(echo "$result" | jq -r '[.log[] | select(.call == "upload") | .ok] | all')" = "true" ] && ok "every upload had the uploader's token, the public key and x-upsert" || fail "upload headers"
order="$(echo "$result" | jq -r '[.log[] | select(.call == "upload" and (.name | startswith("SmartRetailAI-Setup-1.2.0")) or (.call == "upload" and .name == "latest.json")) | .name] | .[-3:] | join(" ")')"
[ "$order" = "SmartRetailAI-Setup-1.2.0.exe.001 SmartRetailAI-Setup-1.2.0.exe.002 latest.json" ] && ok "the pieces first, latest.json last ($order)" || fail "order: $order"
[ "$(echo "$result" | jq -r '.log[] | select(.call == "upload" and .name == "latest.json") | .type' | sort -u)" = "application/json" ] && ok "latest.json is sent as JSON" || fail "latest.json type"
[ "$(echo "$result" | jq -r '.log[] | select(.call == "statement") | .audience' | grep -c '^smartretail-update:1\.[012]\.0:[0-9a-f]\{64\}$')" = "3" ] && ok "GitHub was asked for a statement for each version and its SHA-256" || fail "statement audiences"
[ "$(echo "$result" | jq -r '.objects | keys | join(" ")')" = "SmartRetailAI-Setup-1.1.0.exe.001 SmartRetailAI-Setup-1.1.0.exe.002 SmartRetailAI-Setup-1.2.0.exe.001 SmartRetailAI-Setup-1.2.0.exe.002 latest.json" ] \
  && ok "the folder holds the last two versions and latest.json, and the oldest went" || fail "objects: $(echo "$result" | jq -c '.objects')"
[ "$(echo "$result" | jq -r '.objects["latest.json"]')" -gt 100 ] && ok "latest.json is there with its content" || fail "latest.json size"

echo "== when something is wrong nothing is left half done"
start
export UPDATE_UPLOAD_PASSWORD="the wrong password"
setup 1500000
if publish 3.0.0; then fail "a wrong password was accepted"; fi
grep -q "signing in as the uploader did not work" "$work/output.txt" && ok "a wrong password stops it, saying so" || fail "message for the password"
export UPDATE_UPLOAD_PASSWORD="a long password"
stop
[ "$(jq -r '.log | map(select(.call == "upload")) | length' "$work/log.json")" = "0" ] && ok "and nothing was uploaded" || fail "uploads after a wrong password"

start --private
setup 1500000
if publish 3.0.0; then fail "a folder that is not public was accepted"; fi
grep -q "is the folder 'app-updates' public" "$work/output.txt" && ok "a folder that is not public is noticed and said" || fail "message for a private folder"
stop

echo "== the input is checked"
setup 100
if "$script" --version 1.0 --setup "$work/setup.exe" > "$work/output.txt" 2>&1; then fail "a version of two numbers was accepted"; fi
grep -q "three numbers" "$work/output.txt" && ok "a version must be three numbers" || fail "version message"
if UPDATE_FEED_URL="http://shop.supabase.co/storage/v1/object/public/app-updates/" "$script" --version 1.0.0 --setup "$work/setup.exe" > "$work/output.txt" 2>&1; then fail "an http folder was accepted"; fi
grep -q "UPDATE_FEED_URL must look like https" "$work/output.txt" && ok "the folder must be https" || fail "feed message"

echo "All $pass checks passed."
