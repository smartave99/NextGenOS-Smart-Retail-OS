-- Smart Retail POS: the update folder for automatic updates (SmartRetailAI/README.md, "Automatic updates").
--
-- Run this once in the SQL Editor of your Supabase project, after making the uploader (Authentication > Users > Add user,
-- with "Auto Confirm User" ticked): a user of its own, with a long password, used by nothing but the release workflow.
-- Before you run it, put that user's e-mail on the line marked CHANGE THIS. Running it again is safe.
--
-- It makes a folder (a "bucket") called app-updates that anyone can read, because the app has no sign-in, and that only
-- the uploader can write to. What it holds is the setup, cut in pieces, and latest.json. The app installs nothing that
-- GitHub did not sign as made by this project's own release, so even if someone got into the folder, the app would not
-- install what they put there; but only the uploader can put anything there at all, and the uploader can do nothing else in
-- your project: it has no policy on any other folder or table, and it is not the project's service key.
do $$
declare
    -- CHANGE THIS: the e-mail of the uploader user you made.
    uploader constant text := 'app-updates-uploader@example.com';
    folder constant text := 'app-updates';
    policy text;
begin
    if uploader !~ '^[^@\s]+@[^@\s]+$' then
        raise exception 'Put the uploader''s e-mail on the line marked CHANGE THIS, then run this again.';
    end if;

    -- The folder: public to read; a piece is at most 40 MB (the free plan takes no file over 50 MB) and is a setup or a description.
    insert into storage.buckets (id, name, public, file_size_limit, allowed_mime_types)
    values (folder, folder, true, 41943040, array['application/octet-stream', 'application/json'])
    on conflict (id) do update
        set public = true, file_size_limit = excluded.file_size_limit, allowed_mime_types = excluded.allowed_mime_types;

    -- The uploader, and no one else: read (a listing, an upload that replaces), add, replace and remove in this folder only.
    -- Earlier policies of this script go first, so a changed e-mail above takes the rights from the old one.
    foreach policy in array array['app updates: the uploader reads', 'app updates: the uploader adds', 'app updates: the uploader replaces', 'app updates: the uploader removes'] loop
        execute format('drop policy if exists %I on storage.objects', policy);
    end loop;
    execute format($p$create policy %I on storage.objects for select to authenticated
        using (bucket_id = %L and lower(coalesce(auth.jwt() ->> 'email', '')) = lower(%L))$p$, 'app updates: the uploader reads', folder, uploader);
    execute format($p$create policy %I on storage.objects for insert to authenticated
        with check (bucket_id = %L and lower(coalesce(auth.jwt() ->> 'email', '')) = lower(%L))$p$, 'app updates: the uploader adds', folder, uploader);
    execute format($p$create policy %I on storage.objects for update to authenticated
        using (bucket_id = %L and lower(coalesce(auth.jwt() ->> 'email', '')) = lower(%L))
        with check (bucket_id = %L and lower(coalesce(auth.jwt() ->> 'email', '')) = lower(%L))$p$, 'app updates: the uploader replaces', folder, uploader, folder, uploader);
    execute format($p$create policy %I on storage.objects for delete to authenticated
        using (bucket_id = %L and lower(coalesce(auth.jwt() ->> 'email', '')) = lower(%L))$p$, 'app updates: the uploader removes', folder, uploader);

    if not exists (select 1 from auth.users where lower(email) = lower(uploader)) then
        raise notice 'The folder is ready, but there is no user % yet: add it under Authentication > Users > Add user.', uploader;
    end if;
end
$$;
