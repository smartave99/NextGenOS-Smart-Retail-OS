#!/bin/bash
# Checks supabase-owner-view.sql and supabase-app-updates.sql on Supabase's own database image, in a throwaway container: runs
# each script twice (running it again must be safe), then owner-view.test.sql and app-updates.test.sql. Needs Docker.
#   SmartRetailPOS/cloud/test/run.sh
set -euo pipefail
here="$(cd "$(dirname "$0")" && pwd)"
image="${SUPABASE_POSTGRES_IMAGE:-public.ecr.aws/supabase/postgres:17.6.1.177}"
name="srpos-owner-view-test-$$"
password="$(head -c 16 /dev/urandom | od -An -tx1 | tr -d ' \n')"

docker run -d --name "$name" -e POSTGRES_PASSWORD="$password" "$image" > /dev/null
trap 'docker rm -f "$name" > /dev/null' EXIT

# Supabase's own set-up runs first; the database is ready once it answers over TCP.
for _ in $(seq 1 90); do
  if docker exec "$name" psql -h localhost -U postgres -d postgres -Atc 'select 1' > /dev/null 2>&1; then break; fi
  sleep 2
done

psql() { docker exec -i -e PGOPTIONS=--client-min-messages=warning "$name" psql -h localhost -U "${1:-postgres}" -d postgres -v ON_ERROR_STOP=1 -q -o /dev/null; }

# The authenticator apps' table, which Supabase's sign-in service would add (see the file).
psql supabase_admin < "$here/auth-mfa-factors.sql"

psql < "$here/../supabase-owner-view.sql"
psql < "$here/../supabase-owner-view.sql"
echo "The script runs, and runs again."
psql < "$here/owner-view.test.sql"

# The update folder's script (the storage service's tables and auth.jwt() are made here, as the services make them).
psql supabase_admin < "$here/storage-stand-in.sql"
psql < "$here/../supabase-app-updates.sql"
psql < "$here/../supabase-app-updates.sql"
echo "The update folder's script runs, and runs again."
psql < "$here/app-updates.test.sql"

# The owner changes the one line marked CHANGE THIS: only the new e-mail has the rights afterwards.
sed "s/app-updates-uploader@example.com/other-uploader@example.com/" "$here/../supabase-app-updates.sql" | psql
psql < "$here/app-updates-email-changed.test.sql"
