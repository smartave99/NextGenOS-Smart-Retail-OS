-- For tests on Supabase's database image alone (run.sh). The image has the sign-in service's users but not the storage
-- service's tables, nor auth.jwt(), which the sign-in service adds when it first starts. They are made here the way those
-- services make them, as far as supabase-app-updates.sql uses them: the folders and their files with row-level security
-- on, and the signed-in person's token. Run as supabase_admin.
create or replace function auth.jwt() returns jsonb language sql stable as $$
    select coalesce(nullif(current_setting('request.jwt.claim', true), ''), nullif(current_setting('request.jwt.claims', true), ''), '{}')::jsonb
$$;
grant execute on function auth.jwt() to anon, authenticated, service_role;

create schema if not exists storage;
create table if not exists storage.buckets (
    id text primary key,
    name text not null unique,
    owner uuid,
    created_at timestamptz default now(),
    updated_at timestamptz default now(),
    public boolean default false,
    avif_autodetection boolean default false,
    file_size_limit bigint,
    allowed_mime_types text[],
    owner_id text
);
create table if not exists storage.objects (
    id uuid primary key default gen_random_uuid(),
    bucket_id text references storage.buckets (id),
    name text,
    owner uuid,
    created_at timestamptz default now(),
    updated_at timestamptz default now(),
    metadata jsonb,
    owner_id text
);
alter table storage.buckets enable row level security;
alter table storage.objects enable row level security;
grant usage on schema storage to anon, authenticated, service_role, postgres;
grant all on storage.buckets, storage.objects to anon, authenticated, service_role, postgres;
