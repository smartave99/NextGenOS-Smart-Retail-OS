-- Checks supabase-app-updates.sql on Supabase's own database image (see run.sh): the folder is public to read, and only the
-- uploader, in this folder only, can read, add, replace and remove. Every check that fails stops the run with "TEST FAILED".
\set ON_ERROR_STOP on
\set uploader '33333333-3333-3333-3333-333333333333'
\set stranger '44444444-4444-4444-4444-444444444444'

insert into auth.users (id, email) values
    (:'uploader', 'app-updates-uploader@example.com'),
    (:'stranger', 'passerby@example.com')
on conflict do nothing;
-- Another folder, of someone else's, that the uploader must not reach.
insert into storage.buckets (id, name, public) values ('photos', 'photos', false) on conflict do nothing;
insert into storage.objects (bucket_id, name) values ('photos', 'private.png');

create or replace function pg_temp.fails(p_sql text, p_expected text) returns void language plpgsql as $$
begin
    execute p_sql;
    raise exception 'TEST FAILED: % ran, but should have failed with "%"', p_sql, p_expected;
exception when others then
    if sqlerrm like 'TEST FAILED%' then raise; end if;
    if position(p_expected in sqlerrm) = 0 then
        raise exception 'TEST FAILED: % failed with "%", not "%"', p_sql, sqlerrm, p_expected;
    end if;
end;
$$;

create or replace function pg_temp.check(p_ok boolean, p_what text) returns void language plpgsql as $$
begin
    if not coalesce(p_ok, false) then raise exception 'TEST FAILED: %', p_what; end if;
end;
$$;

-- The folder itself.
select pg_temp.check((select public from storage.buckets where id = 'app-updates'), 'the folder is public, so the app can read it without signing in');
select pg_temp.check((select file_size_limit from storage.buckets where id = 'app-updates') = 41943040, 'a file in it is at most 40 MB');
select pg_temp.check((select allowed_mime_types from storage.buckets where id = 'app-updates') = array['application/octet-stream', 'application/json'], 'only a setup and a description may be put in it');

-- Without signing in, nothing can be listed, added or removed (a public folder is read by its public address, not by a query).
set role anon;
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'app-updates') = 0, 'anonymous sees no rows');
select pg_temp.fails($$insert into storage.objects (bucket_id, name) values ('app-updates', 'latest.json')$$, 'row-level security');
reset role;

-- Someone else, signed in, cannot add, replace or remove either.
set role authenticated;
set request.jwt.claims = '{"role":"authenticated","sub":"44444444-4444-4444-4444-444444444444","email":"passerby@example.com"}';
select pg_temp.fails($$insert into storage.objects (bucket_id, name) values ('app-updates', 'latest.json')$$, 'row-level security');
reset role;
set role authenticated;
set request.jwt.claims = '{"role":"authenticated","sub":"33333333-3333-3333-3333-333333333333","email":"app-updates-uploader@example.com"}';

-- The uploader adds, reads, replaces and removes in the folder.
insert into storage.objects (bucket_id, name, metadata) values ('app-updates', 'latest.json', '{"size": 10}'), ('app-updates', 'SmartRetailAI-Setup-1.0.0.exe.001', '{"size": 20}');
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'app-updates') = 2, 'the uploader lists what is in the folder');
update storage.objects set metadata = '{"size": 11}' where bucket_id = 'app-updates' and name = 'latest.json';
select pg_temp.check((select (metadata ->> 'size')::int from storage.objects where bucket_id = 'app-updates' and name = 'latest.json') = 11, 'the uploader replaces a file');
delete from storage.objects where bucket_id = 'app-updates' and name = 'SmartRetailAI-Setup-1.0.0.exe.001';
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'app-updates') = 1, 'the uploader removes a file');

-- But only in this folder: not in another, not even to read.
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'photos') = 0, 'the uploader does not see another folder');
select pg_temp.fails($$insert into storage.objects (bucket_id, name) values ('photos', 'mine.png')$$, 'row-level security');
delete from storage.objects where bucket_id = 'photos';
reset role;
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'photos') = 1, 'the uploader removed nothing from another folder');
-- The uploader cannot move a file of the folder into another either.
set role authenticated;
set request.jwt.claims = '{"role":"authenticated","sub":"33333333-3333-3333-3333-333333333333","email":"app-updates-uploader@example.com"}';
select pg_temp.fails($$update storage.objects set bucket_id = 'photos' where bucket_id = 'app-updates' and name = 'latest.json'$$, 'row-level security');
-- Upper case in the e-mail changes nothing.
set request.jwt.claims = '{"role":"authenticated","sub":"33333333-3333-3333-3333-333333333333","email":"App-Updates-Uploader@Example.com"}';
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'app-updates') = 1, 'the e-mail is compared without regard to case');
-- A token without an e-mail is nobody.
set request.jwt.claims = '{"role":"authenticated","sub":"33333333-3333-3333-3333-333333333333"}';
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'app-updates') = 0, 'a token without an e-mail sees nothing');
reset role;

\echo 'All update folder checks passed.'
