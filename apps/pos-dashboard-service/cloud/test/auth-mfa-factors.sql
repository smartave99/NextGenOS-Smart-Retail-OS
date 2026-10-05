-- For tests on Supabase's database image alone (run.sh, tests/e2e/local-supabase.js). Supabase's sign-in service
-- adds auth.mfa_factors (the authenticator apps) when it first starts, and the image alone does not have it: it is
-- made here the way that service makes it, as far as supabase-owner-view.sql reads it. Run as supabase_admin.
do $$
begin
    if to_regtype('auth.factor_status') is null then
        create type auth.factor_status as enum ('unverified', 'verified');
    end if;
    if to_regclass('auth.mfa_factors') is null then
        create table auth.mfa_factors (
            id uuid primary key,
            user_id uuid not null references auth.users (id) on delete cascade,
            friendly_name text,
            factor_type text not null,
            status auth.factor_status not null,
            created_at timestamptz not null,
            updated_at timestamptz not null
        );
    end if;
end;
$$;
grant select, insert, update, delete on auth.mfa_factors to postgres;
