-- After the owner changed the e-mail on the CHANGE THIS line and ran supabase-app-updates.sql again (run.sh): the new
-- e-mail has the uploader's rights and the earlier one has lost them. Every check that fails stops the run with "TEST FAILED".
\set ON_ERROR_STOP on
create or replace function pg_temp.check(p_ok boolean, p_what text) returns void language plpgsql as $$
begin
    if not coalesce(p_ok, false) then raise exception 'TEST FAILED: %', p_what; end if;
end;
$$;
select pg_temp.check((select count(*) from pg_policies where schemaname = 'storage' and tablename = 'objects' and policyname like 'app updates:%') = 4, 'the four policies are there once, not twice');

set role authenticated;
set request.jwt.claims = '{"role":"authenticated","sub":"33333333-3333-3333-3333-333333333333","email":"app-updates-uploader@example.com"}';
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'app-updates') = 0, 'the earlier uploader has lost its rights');
set request.jwt.claims = '{"role":"authenticated","sub":"55555555-5555-5555-5555-555555555555","email":"other-uploader@example.com"}';
select pg_temp.check((select count(*) from storage.objects where bucket_id = 'app-updates') = 1, 'the new e-mail has them');
reset role;

\echo 'The e-mail on the CHANGE THIS line moves the rights.'
