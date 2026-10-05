-- Checks supabase-owner-view.sql on Supabase's own database image (see run.sh): who may see and do what.
-- Every check that fails stops the run with "TEST FAILED".
\set ON_ERROR_STOP on
\set owner '11111111-1111-1111-1111-111111111111'
\set stranger '22222222-2222-2222-2222-222222222222'

insert into auth.users (id, email) values (:'owner', 'owner@example.com'), (:'stranger', 'someone@example.com')
on conflict (id) do nothing;


-- Expects p_sql to fail with an error containing p_expected.
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

-- Without signing in, nothing can be read or made.
set role anon;
select pg_temp.fails('select * from public.shop_live', 'permission denied');
select pg_temp.fails('select * from public.shop_devices', 'permission denied');
select pg_temp.fails('select * from public.pairing_codes', 'permission denied');
select pg_temp.fails('select public.create_shop(''Mine'')', 'permission denied');
reset role;

-- The owner creates the shop and a code.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.create_shop('Demo Mart 99') as shop \gset
select public.new_pairing_code(:'shop') as code \gset
select pg_temp.check(:'code' ~ '^[A-HJ-NP-Z2-9]{8}$', 'the code is 8 easy-to-read letters and digits');
select pg_temp.fails('select public.create_shop(''Second shop'')', 'already has its shop');

-- Someone else, signed in, can neither see the shop nor make codes nor a shop.
set request.jwt.claim.sub = :'stranger';
select pg_temp.check((select count(*) from public.shops) = 0, 'a stranger does not see the shop');
select pg_temp.fails(format('select public.new_pairing_code(%L)', :'shop'), 'Only the shop''s owner');
select pg_temp.fails('select public.create_shop(''My shop'')', 'already has its shop');
reset role;

-- The shop PC connects with only the public key: a wrong code fails, the right one (typed with a dash, in small
-- letters) works once.
set role anon;
select pg_temp.fails('select public.connect_shop_pc(''WRONG-CODE'')', 'wrong or has expired');
select public.connect_shop_pc(lower(left(:'code', 4) || '-' || right(:'code', 4)), 'Counter PC') as pairing \gset
select pg_temp.fails(format('select public.connect_shop_pc(%L)', :'code'), 'wrong or has expired');
select (:'pairing')::jsonb ->> 'key' as key \gset
select pg_temp.check(length(:'key') = 64 and ((:'pairing')::jsonb ->> 'shop_name') = 'Demo Mart 99', 'the PC gets a long key and the shop''s name');

-- It sends figures; a wrong key, too much, or not an object is refused.
select public.send_live_figures(:'key', '{"today": {"sales": 5723, "bills": 5}}',
    '[{"day": "2026-09-27", "sales": 5723}, {"day": "2026-09-26", "sales": 9100}, {"day": "not a day"}]') is not null as sent \gset
select pg_temp.check(:'sent', 'figures are sent');
select public.send_live_figures(:'key', '{"today": {"sales": 6000, "bills": 6}}', '[{"day": "2026-09-27", "sales": 6000}]') is not null as sent \gset
select pg_temp.fails('select public.send_live_figures(''0000'', ''{}'')', 'not connected');
select pg_temp.fails(format('select public.send_live_figures(%L, %L)', :'key', '[1]'), 'missing or too large');
select pg_temp.fails(format('select public.send_live_figures(%L, jsonb_build_object(''x'', repeat(''a'', 300000)))', :'key'), 'missing or too large');
select pg_temp.fails(format('select public.send_live_figures(%L, ''{}'', (select jsonb_agg(jsonb_build_object(''day'', ''2026-01-01'')) from generate_series(1, 70)))', :'key'), 'Too many days');
select pg_temp.fails('select * from public.shop_live', 'permission denied');
reset role;

-- The owner sees the latest figures and the days; the stranger sees nothing.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select pg_temp.check((select (data -> 'today' ->> 'sales')::int from public.shop_live) = 6000, 'the owner sees the latest figures');
select pg_temp.check((select count(*) from public.shop_days) = 2, 'one row per day, the bad day left out');
select pg_temp.check((select (data ->> 'sales')::int from public.shop_days where day = '2026-09-27') = 6000, 'a day sent again is replaced');
select pg_temp.check((select label from public.shop_devices) = 'Counter PC' and (select last_seen_at from public.shop_devices) is not null, 'the owner sees the shop PC and when it last sent');
select pg_temp.fails('select key_hash from public.shop_devices', 'permission denied');
select pg_temp.fails('insert into public.shop_live (shop_id, data) values (gen_random_uuid(), ''{}'')', 'permission denied');
select pg_temp.fails(format('update public.shop_live set data = ''{}'' where shop_id = %L', :'shop'), 'permission denied');
set request.jwt.claim.sub = :'stranger';
select pg_temp.check((select count(*) from public.shop_live) = 0 and (select count(*) from public.shop_days) = 0, 'a stranger sees no figures');
delete from public.shop_devices;
reset role;
select pg_temp.check((select count(*) from public.shop_devices) = 1, 'a stranger cannot disconnect the shop PC');

-- The owner turns on the authenticator app: from then on the password alone shows nothing and makes nothing,
-- until the app's code is entered too (Supabase then marks the sign-in "aal2").
insert into auth.mfa_factors (id, user_id, friendly_name, factor_type, status, created_at, updated_at)
values (gen_random_uuid(), :'owner', 'Phone', 'totp', 'verified', now(), now());
set role authenticated;
set request.jwt.claim.sub = :'owner';
set request.jwt.claims = '{"aal": "aal1"}';
select pg_temp.check((select count(*) from public.shop_live) = 0 and (select count(*) from public.shops) = 0, 'with the app on, the password alone shows nothing');
select pg_temp.fails(format('select public.new_pairing_code(%L)', :'shop'), 'authenticator app');
select pg_temp.fails(format('select public.ask_the_shop(%L, ''How were sales today?'')', :'shop'), 'authenticator app');
delete from public.shop_devices;
reset role;
select pg_temp.check((select count(*) from public.shop_devices) = 1, 'with the app on, the password alone cannot disconnect a shop PC');
set role authenticated;
set request.jwt.claim.sub = :'owner';
set request.jwt.claims = '{"aal": "aal2"}';
select pg_temp.check((select (data -> 'today' ->> 'sales')::int from public.shop_live) = 6000, 'with the app''s code too, the owner sees the shop');
select public.new_pairing_code(:'shop') is not null as made \gset
select pg_temp.check(:'made', 'with the app''s code too, the owner makes codes');
reset role;
-- An app that was never confirmed does not count; turned off again, the password is enough.
update auth.mfa_factors set status = 'unverified' where user_id = :'owner';
set role authenticated;
set request.jwt.claim.sub = :'owner';
set request.jwt.claims = '{"aal": "aal1"}';
select pg_temp.check((select count(*) from public.shop_live) = 1, 'an unconfirmed app does not lock the owner out');
reset role;
delete from auth.mfa_factors where user_id = :'owner';
reset request.jwt.claims;

-- An expired code does not work.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.new_pairing_code(:'shop') as late_code \gset
reset role;
update public.pairing_codes set expires_at = now() - interval '1 minute' where code = :'late_code';
set role anon;
select pg_temp.fails(format('select public.connect_shop_pc(%L)', :'late_code'), 'wrong or has expired');
reset role;

-- The owner disconnects the shop PC; its key stops working at once.
set role authenticated;
set request.jwt.claim.sub = :'owner';
delete from public.shop_devices;
reset role;
set role anon;
select pg_temp.fails(format('select public.send_live_figures(%L, ''{}'')', :'key'), 'not connected');
reset role;

-- A PC connected again can forget its own connection.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.new_pairing_code(:'shop') as code2 \gset
reset role;
set role anon;
select (public.connect_shop_pc(:'code2')) ->> 'key' as key2 \gset
select public.disconnect_shop_pc(:'key2');
select pg_temp.fails(format('select public.send_live_figures(%L, ''{}'')', :'key2'), 'not connected');
reset role;

-- The owner asks the shop's AI; the shop PC takes the question with its own key, once, and answers it.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.new_pairing_code(:'shop') as code3 \gset
select public.ask_the_shop(:'shop', '  How were sales today?  ') as question \gset
select pg_temp.check((select question from public.shop_questions) = 'How were sales today?', 'the question is kept, trimmed');
select pg_temp.fails(format('select public.ask_the_shop(%L, %L)', :'shop', '   '), '1 to 1,000');
select pg_temp.fails(format('select public.ask_the_shop(%L, repeat(''a'', 1001))', :'shop'), '1 to 1,000');
set request.jwt.claim.sub = :'stranger';
select pg_temp.fails(format('select public.ask_the_shop(%L, ''Hi'')', :'shop'), 'Only the shop''s owner');
select pg_temp.check((select count(*) from public.shop_questions) = 0, 'a stranger sees no questions');
reset role;
-- A viewer sees the shop's figures but not the questions: an answer may name customers.
insert into public.shop_members (shop_id, user_id, role) values (:'shop', :'stranger', 'viewer');
set role authenticated;
set request.jwt.claim.sub = :'stranger';
select pg_temp.check((select count(*) from public.shops) = 1, 'a viewer sees the shop');
select pg_temp.check((select count(*) from public.shop_questions) = 0, 'a viewer sees no questions');
select pg_temp.fails(format('select public.ask_the_shop(%L, ''Hi'')', :'shop'), 'Only the shop''s owner');
reset role;
delete from public.shop_members where user_id = :'stranger';
set role anon;
select pg_temp.fails('select * from public.shop_questions', 'permission denied');
select pg_temp.fails(format('select public.ask_the_shop(%L, ''Hi'')', :'shop'), 'permission denied');
select (public.connect_shop_pc(:'code3')) ->> 'key' as key3 \gset
select pg_temp.fails('select public.next_shop_question(''0000'')', 'not connected');
select public.next_shop_question(:'key3') as taken \gset
select pg_temp.check((:'taken')::jsonb ->> 'question' = 'How were sales today?', 'the shop PC takes the question');
select pg_temp.check(public.next_shop_question(:'key3') is null, 'a question is taken once');
select pg_temp.fails(format('select public.answer_shop_question(''0000'', %L, ''{}'')', :'question'), 'not connected');
select pg_temp.fails(format('select public.answer_shop_question(%L, %L, ''[1]'')', :'key3', :'question'), 'missing or too large');
select public.answer_shop_question(:'key3', :'question', '{"text": "₹5,723 from 5 bills."}');
select pg_temp.fails(format('select public.answer_shop_question(%L, %L, ''{}'')', :'key3', :'question'), 'not waiting');
reset role;
set role authenticated;
set request.jwt.claim.sub = :'owner';
select pg_temp.check((select status = 'answered' and answer ->> 'text' = '₹5,723 from 5 bills.' from public.shop_questions), 'the owner sees the answer');
select pg_temp.fails(format('update public.shop_questions set status = ''waiting'' where id = %L', :'question'), 'permission denied');

-- At most 30 questions an hour.
select count(*) from (select public.ask_the_shop(:'shop', 'Question ' || i) from generate_series(1, 29) as i) as asked \gset
select pg_temp.fails(format('select public.ask_the_shop(%L, ''One more'')', :'shop'), '30 questions this hour');
reset role;

-- A question taken but never answered (the shop PC was switched off) is taken again after 10 minutes.
update public.shop_questions set status = 'answered', answer = '{}' where status = 'waiting';
update public.shop_questions set status = 'working', taken_at = now() - interval '11 minutes' where question = 'Question 1';
set role anon;
select pg_temp.check((public.next_shop_question(:'key3')) ->> 'question' = 'Question 1', 'a question never answered is taken again after 10 minutes');
reset role;

-- The weekly screens (the Monday review): the shop PC keeps one report of each kind up to date, with its own key.
set role anon;
select pg_temp.fails('select * from public.shop_reports', 'permission denied');
select pg_temp.fails('select public.send_shop_report(''0000'', ''review'', ''{}'')', 'not connected');
select pg_temp.fails(format('select public.send_shop_report(%L, ''Review'', ''{}'')', :'key3'), 'not known');
select pg_temp.fails(format('select public.send_shop_report(%L, %L, ''{}'')', :'key3', ''), 'not known');
select pg_temp.fails(format('select public.send_shop_report(%L, %L, ''{}'')', :'key3', 'review' || repeat('x', 40)), 'not known');
select pg_temp.fails(format('select public.send_shop_report(%L, ''review'', ''[1]'')', :'key3'), 'missing or too large');
select pg_temp.fails(format('select public.send_shop_report(%L, ''review'', jsonb_build_object(''x'', repeat(''a'', 300000)))', :'key3'), 'missing or too large');
select public.send_shop_report(:'key3', 'review', '{"version": 1, "thisWeek": {"sales": 100}}') is not null as sent \gset
select pg_temp.check(:'sent', 'the shop PC sends the review');
select public.send_shop_report(:'key3', 'review', '{"version": 1, "thisWeek": {"sales": 250}}') is not null as sent \gset
reset role;

-- The owner reads it; one row for each kind, the later one replacing the earlier; nobody writes it directly.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select pg_temp.check((select count(*) from public.shop_reports) = 1, 'one row for each kind of report');
select pg_temp.check((select (data -> 'thisWeek' ->> 'sales')::int from public.shop_reports where kind = 'review') = 250, 'a report sent again replaces the earlier one');
select pg_temp.fails('insert into public.shop_reports (shop_id, kind, data) values (gen_random_uuid(), ''x'', ''{}'')', 'permission denied');
select pg_temp.fails(format('update public.shop_reports set data = ''{}'' where shop_id = %L', :'shop'), 'permission denied');
select pg_temp.fails(format('delete from public.shop_reports where shop_id = %L', :'shop'), 'permission denied');
reset role;

-- A viewer reads the reports like the live figures; a stranger reads none.
insert into public.shop_members (shop_id, user_id, role) values (:'shop', :'stranger', 'viewer');
set role authenticated;
set request.jwt.claim.sub = :'stranger';
select pg_temp.check((select count(*) from public.shop_reports) = 1, 'a viewer sees the shop''s reports');
reset role;
delete from public.shop_members where user_id = :'stranger';
set role authenticated;
set request.jwt.claim.sub = :'stranger';
select pg_temp.check((select count(*) from public.shop_reports) = 0, 'a stranger sees no reports');
reset role;

-- With the authenticator app on, the password alone shows no reports either.
insert into auth.mfa_factors (id, user_id, friendly_name, factor_type, status, created_at, updated_at)
values (gen_random_uuid(), :'owner', 'Phone', 'totp', 'verified', now(), now());
set role authenticated;
set request.jwt.claim.sub = :'owner';
set request.jwt.claims = '{"aal": "aal1"}';
select pg_temp.check((select count(*) from public.shop_reports) = 0, 'with the app on, the password alone shows no reports');
set request.jwt.claims = '{"aal": "aal2"}';
select pg_temp.check((select count(*) from public.shop_reports) = 1, 'with the app''s code too, the owner sees the reports');
reset role;
delete from auth.mfa_factors where user_id = :'owner';
reset request.jwt.claims;

-- A shop keeps at most 20 kinds; a kind it already keeps can still be replaced.
set role anon;
select count(*) from (select public.send_shop_report(:'key3', 'kind-' || i, '{}') from generate_series(1, 19) as i) as sent \gset
select pg_temp.fails(format('select public.send_shop_report(%L, ''one-more'', ''{}'')', :'key3'), 'all the reports');
select public.send_shop_report(:'key3', 'review', '{"version": 1}') is not null as again \gset
select pg_temp.check(:'again', 'a kind already kept can still be replaced at the limit');
reset role;

-- The website's products: the shop PC offers the products it has finished, with its own key; they wait here for the
-- owner's decision, and nothing else reads or writes them.
\set v1 'aaaaaaaaaaaaaaaa1111111111111111'
\set v2 'aaaaaaaaaaaaaaaa2222222222222222'
\set v3 'aaaaaaaaaaaaaaaa3333333333333333'
\set p1 'bbbbbbbbbbbbbbbb1111111111111111'
\set p2 'bbbbbbbbbbbbbbbb2222222222222222'
set role anon;
select pg_temp.fails('select * from public.shop_products', 'permission denied');
select pg_temp.fails('select * from public.shop_product_photos', 'permission denied');
select pg_temp.fails(format('select public.send_shop_product(''0000'', ''1006'', ''{}'', %L, %L, array[''white''])', :'v1', :'p1'), 'not connected');
select pg_temp.fails(format('select public.send_shop_product_photo(''0000'', ''1006'', ''white'', ''image/jpeg'', repeat(''A'', 200), %L)', :'p1'), 'not connected');
select pg_temp.fails('select public.get_shop_product_states(''0000'')', 'not connected');
select pg_temp.fails('select public.withdraw_shop_product(''0000'', ''1006'')', 'not connected');
select pg_temp.fails(format('select public.decide_shop_product(%L, ''1006'', ''published'')', :'shop'), 'permission denied');

-- What the shop PC may offer: a product number, an object of at most 64 KB, its two fingerprints, and its photos
-- (the white-background one among them).
select pg_temp.fails(format('select public.send_shop_product(%L, ''abc'', ''{}'', %L, %L, array[''white''])', :'key3', :'v1', :'p1'), 'not known');
select pg_temp.fails(format('select public.send_shop_product(%L, '''', ''{}'', %L, %L, array[''white''])', :'key3', :'v1', :'p1'), 'not known');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''[1]'', %L, %L, array[''white''])', :'key3', :'v1', :'p1'), 'missing or too large');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', jsonb_build_object(''x'', repeat(''a'', 70000)), %L, %L, array[''white''])', :'key3', :'v1', :'p1'), 'missing or too large');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{}'', ''xyz'', %L, array[''white''])', :'key3', :'p1'), 'version is not known');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{}'', %L, ''XYZ'', array[''white''])', :'key3', :'v1'), 'version is not known');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{}'', %L, %L, array[]::text[])', :'key3', :'v1', :'p1'), 'photos are not known');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{}'', %L, %L, null)', :'key3', :'v1', :'p1'), 'photos are not known');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{}'', %L, %L, array[''white'', ''selfie''])', :'key3', :'v1', :'p1'), 'photos are not known');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{}'', %L, %L, array[''in-use''])', :'key3', :'v1', :'p1'), 'white-background');
select pg_temp.check((select count(*) from pg_catalog.pg_class where relname = 'shop_products') = 1, 'the list exists');

-- A new product is "sending" until its photos are here; the photos it asks for come in the order they are made in,
-- and a photo sent twice is not asked for twice.
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 160}', :'v1', :'p1', array['in-use', 'white', 'white']) as offered \gset
select pg_temp.check((:'offered')::jsonb ->> 'state' = 'sending' and (:'offered')::jsonb -> 'send_photos' = '["white", "in-use"]'::jsonb,
    'a new product is "sending" and asks for its photos in order, each once');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''selfie'', ''image/jpeg'', repeat(''A'', 400), %L)', :'key3', :'p1'), 'not known');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''white'', ''text/html'', repeat(''A'', 400), %L)', :'key3', :'p1'), 'not taken');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''white'', ''image/jpeg'', ''abc'', %L)', :'key3', :'p1'), 'missing or too large');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''white'', ''image/jpeg'', repeat(''A'', 900001), %L)', :'key3', :'p1'), 'missing or too large');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''white'', ''image/jpeg'', %L, %L)', :'key3', repeat('<script>', 60), :'p1'), 'missing or too large');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''white'', ''image/jpeg'', repeat(''A'', 400), %L)', :'key3', :'p2'), 'not waiting for photos');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''9999'', ''white'', ''image/jpeg'', repeat(''A'', 400), %L)', :'key3', :'p1'), 'not waiting for photos');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''european-model'', ''image/jpeg'', repeat(''A'', 400), %L)', :'key3', :'p1'), 'not one of the product''s photos');
select public.send_shop_product_photo(:'key3', '1006', 'white', 'image/jpeg', repeat('A', 400), :'p1') as after_first \gset
select pg_temp.check(:'after_first' = 'sending', 'with one of two photos the product is still sending');
select public.get_shop_product_states(:'key3') as states \gset
select pg_temp.check((:'states')::jsonb -> 0 ->> 'product' = '1006' and (:'states')::jsonb -> 0 -> 'staged' = '["white"]'::jsonb and (:'states')::jsonb -> 0 ->> 'state' = 'sending',
    'the shop PC is told which photos are here');
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 160}', :'v1', :'p1', array['white', 'in-use']) as again_offered \gset
select pg_temp.check((:'again_offered')::jsonb ->> 'state' = 'sending' and (:'again_offered')::jsonb -> 'send_photos' = '["in-use"]'::jsonb, 'an unfinished product asks only for the photos it lacks');
select public.send_shop_product_photo(:'key3', '1006', 'in-use', 'image/png', repeat('B', 400), :'p1') as after_second \gset
select pg_temp.check(:'after_second' = 'waiting', 'with the last photo the product waits for the owner');
reset role;

-- The owner sees the product and its photos; nobody writes to them directly.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select pg_temp.check((select state from public.shop_products where product_key = '1006') = 'waiting', 'the owner sees the product waiting');
select pg_temp.check((select data ->> 'name' from public.shop_products where product_key = '1006') = 'Sunflower Oil 1 L', 'with what the PC said about it');
select pg_temp.check((select count(*) from public.shop_product_photos where product_key = '1006') = 2, 'and its photos');
select pg_temp.fails('insert into public.shop_products (shop_id, product_key, data, version, photos_version, photo_kinds, state) values (gen_random_uuid(), ''9'', ''{}'', ''aaaaaaaaaaaaaaaa'', ''bbbbbbbbbbbbbbbb'', ''{white}'', ''waiting'')', 'permission denied');
select pg_temp.fails(format('update public.shop_products set state = ''published'' where shop_id = %L', :'shop'), 'permission denied');
select pg_temp.fails(format('delete from public.shop_products where shop_id = %L', :'shop'), 'permission denied');
select pg_temp.fails(format('update public.shop_product_photos set content = ''x'' where shop_id = %L', :'shop'), 'permission denied');
select pg_temp.fails(format('delete from public.shop_product_photos where shop_id = %L', :'shop'), 'permission denied');
reset role;

-- A viewer, a stranger, and a password alone (with the authenticator app on) see no products.
insert into public.shop_members (shop_id, user_id, role) values (:'shop', :'stranger', 'viewer');
set role authenticated;
set request.jwt.claim.sub = :'stranger';
select pg_temp.check((select count(*) from public.shop_products) = 0 and (select count(*) from public.shop_product_photos) = 0, 'a viewer sees no products');
select pg_temp.fails(format('select public.decide_shop_product(%L, ''1006'', ''published'')', :'shop'), 'Only the shop''s owner');
reset role;
delete from public.shop_members where user_id = :'stranger';
set role authenticated;
set request.jwt.claim.sub = :'stranger';
select pg_temp.check((select count(*) from public.shop_products) = 0, 'a stranger sees no products');
select pg_temp.fails(format('select public.decide_shop_product(%L, ''1006'', ''published'')', :'shop'), 'Only the shop''s owner');
reset role;
insert into auth.mfa_factors (id, user_id, friendly_name, factor_type, status, created_at, updated_at)
values (gen_random_uuid(), :'owner', 'Phone', 'totp', 'verified', now(), now());
set role authenticated;
set request.jwt.claim.sub = :'owner';
set request.jwt.claims = '{"aal": "aal1"}';
select pg_temp.check((select count(*) from public.shop_products) = 0, 'with the app on, the password alone shows no products');
select pg_temp.fails(format('select public.decide_shop_product(%L, ''1006'', ''published'')', :'shop'), 'authenticator app');
set request.jwt.claims = '{"aal": "aal2"}';
select pg_temp.check((select count(*) from public.shop_products) = 1, 'with the app''s code too, the owner sees the products');
reset role;
delete from auth.mfa_factors where user_id = :'owner';
reset request.jwt.claims;

-- Offered again: nothing changed leaves it as it is; new words or prices keep its photos; new photos start the photos again.
set role anon;
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 160}', :'v1', :'p1', array['white', 'in-use']) as same \gset
select pg_temp.check((:'same')::jsonb ->> 'state' = 'waiting' and (:'same')::jsonb -> 'send_photos' = '[]'::jsonb, 'the same product again changes nothing');
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 170}', :'v2', :'p1', array['white', 'in-use']) as price \gset
select pg_temp.check((:'price')::jsonb ->> 'state' = 'waiting' and (:'price')::jsonb -> 'send_photos' = '[]'::jsonb, 'a new price keeps the product waiting, with its photos');
reset role;
select pg_temp.check((select (data ->> 'price')::int from public.shop_products where product_key = '1006') = 170
    and (select count(*) from public.shop_product_photos where product_key = '1006') = 2, 'the new price replaced the old, the photos stayed');
set role anon;
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 170}', :'v2', :'p2', array['white']) as photos \gset
select pg_temp.check((:'photos')::jsonb ->> 'state' = 'sending' and (:'photos')::jsonb -> 'send_photos' = '["white"]'::jsonb, 'new photos start the product sending again');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''in-use'', ''image/jpeg'', repeat(''A'', 400), %L)', :'key3', :'p1'), 'not waiting for photos');
select public.send_shop_product_photo(:'key3', '1006', 'white', 'image/jpeg', repeat('C', 400), :'p2') as again_waiting \gset
select pg_temp.check(:'again_waiting' = 'waiting', 'and waiting again with the new photo');
reset role;
select pg_temp.check((select count(*) from public.shop_product_photos where product_key = '1006') = 1, 'the old photos went when the new ones began');

-- The owner decides. A product waits for that decision only; its photos go at once.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select pg_temp.fails(format('select public.decide_shop_product(%L, ''1006'', ''waiting'')', :'shop'), 'published or declined');
select pg_temp.fails(format('select public.decide_shop_product(%L, ''1006'', null)', :'shop'), 'published or declined');
select pg_temp.fails(format('select public.decide_shop_product(%L, ''9999'', ''published'')', :'shop'), 'not waiting for a decision');
select public.decide_shop_product(:'shop', '1006', 'published');
select pg_temp.check((select state from public.shop_products where product_key = '1006') = 'published'
    and (select decided_at from public.shop_products where product_key = '1006') is not null, 'the owner publishes it');
select pg_temp.check((select count(*) from public.shop_product_photos) = 0, 'its photos are dropped from the list');
select pg_temp.fails(format('select public.decide_shop_product(%L, ''1006'', ''declined'')', :'shop'), 'not waiting for a decision');
reset role;

-- A published product: left alone while nothing changes; a new price asks the owner again, without photos; new photos send them again.
set role anon;
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 170}', :'v2', :'p2', array['white']) as pub \gset
select pg_temp.check((:'pub')::jsonb ->> 'state' = 'published' and (:'pub')::jsonb -> 'send_photos' = '[]'::jsonb, 'a published product is left alone while nothing changes');
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 180}', :'v3', :'p2', array['white']) as pub_price \gset
select pg_temp.check((:'pub_price')::jsonb ->> 'state' = 'waiting' and (:'pub_price')::jsonb -> 'send_photos' = '[]'::jsonb, 'a new price asks the owner again, without photos');
reset role;
select pg_temp.check((select count(*) from public.shop_product_photos where product_key = '1006') = 0 and (select decided_at from public.shop_products where product_key = '1006') is null, 'the update has no photos and no decision yet');
set role anon;
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 180}', :'v3', :'p1', array['white', 'in-use']) as pub_photos \gset
select pg_temp.check((:'pub_photos')::jsonb ->> 'state' = 'sending' and (:'pub_photos')::jsonb -> 'send_photos' = '["white", "in-use"]'::jsonb, 'new photos of a published product are sent again');
reset role;

-- A declined product stays declined, whatever the PC says, unless the PC offers it again at the owner's wish.
set role anon;
select public.send_shop_product(:'key3', '2001', '{"name": "Tea 250 g", "price": 120}', :'v1', :'p1', array['white']) is not null as offered \gset
select public.send_shop_product_photo(:'key3', '2001', 'white', 'image/jpeg', repeat('D', 400), :'p1') as waiting \gset
reset role;
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.decide_shop_product(:'shop', '2001', 'declined');
select pg_temp.check((select state from public.shop_products where product_key = '2001') = 'declined' and (select count(*) from public.shop_product_photos where product_key = '2001') = 0, 'the owner declines it, and its photos go');
reset role;
set role anon;
select public.send_shop_product(:'key3', '2001', '{"name": "Tea 250 g", "price": 120}', :'v1', :'p1', array['white']) as declined_same \gset
select public.send_shop_product(:'key3', '2001', '{"name": "Tea 250 g", "price": 130}', :'v2', :'p2', array['white']) as declined_changed \gset
select pg_temp.check((:'declined_same')::jsonb ->> 'state' = 'declined' and (:'declined_changed')::jsonb ->> 'state' = 'declined'
    and (:'declined_changed')::jsonb -> 'send_photos' = '[]'::jsonb, 'a declined product stays declined, changed or not');
select public.send_shop_product(:'key3', '2001', '{"name": "Tea 250 g", "price": 130}', :'v2', :'p2', array['white'], true) as offered_again \gset
select pg_temp.check((:'offered_again')::jsonb ->> 'state' = 'sending' and (:'offered_again')::jsonb -> 'send_photos' = '["white"]'::jsonb, 'offered again at the owner''s wish it is sending, with its photos');
select public.send_shop_product(:'key3', '2001', '{"name": "Tea 250 g", "price": 130}', :'v2', :'p2', array['white'], true) as offered_twice \gset
select pg_temp.check((:'offered_twice')::jsonb ->> 'state' = 'sending', 'offering it again twice does no harm');
reset role;

-- A shop PC takes back a product it can no longer offer, before the owner has decided; one decided on stays.
set role anon;
select public.withdraw_shop_product(:'key3', '2001');
select public.withdraw_shop_product(:'key3', '1006');
select public.withdraw_shop_product(:'key3', 'nothing');
select public.get_shop_product_states(:'key3') as states \gset
select pg_temp.check(jsonb_array_length((:'states')::jsonb) = 0, 'products still being sent are taken back');
reset role;
select pg_temp.check((select count(*) from public.shop_products) = 0 and (select count(*) from public.shop_product_photos) = 0, 'with its photos');
set role anon;
select public.send_shop_product(:'key3', '1006', '{"name": "Sunflower Oil 1 L", "price": 160}', :'v1', :'p1', array['white']) is not null as ok \gset
select public.send_shop_product_photo(:'key3', '1006', 'white', 'image/jpeg', repeat('A', 400), :'p1') is not null as ok \gset
reset role;
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.decide_shop_product(:'shop', '1006', 'published');
reset role;
set role anon;
select public.withdraw_shop_product(:'key3', '1006');
select public.get_shop_product_states(:'key3') as states \gset
select pg_temp.check((:'states')::jsonb -> 0 ->> 'state' = 'published', 'a published product is not taken back');
reset role;

-- At most 25 products wait at once: the 26th is refused; one already on the list may still change; the owner's
-- decisions make room.
set role anon;
select count(*) from (select public.send_shop_product(:'key3', (3000 + i)::text, '{}', :'v1', :'p1', array['white']) from generate_series(1, 25) as i) as sent \gset
select pg_temp.fails(format('select public.send_shop_product(%L, ''4000'', ''{}'', %L, %L, array[''white''])', :'key3', :'v1', :'p1'), 'waiting list is full');
select public.send_shop_product(:'key3', '3001', '{"changed": true}', :'v2', :'p1', array['white']) as full_change \gset
select pg_temp.check((:'full_change')::jsonb ->> 'state' = 'sending', 'a product already on the list can still change at the limit');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{"changed": true}'', %L, %L, array[''white''])', :'key3', :'v2', :'p1'), 'waiting list is full');
reset role;

-- Decisions make room: a product waiting is declined, and another can come.
select public.send_shop_product_photo(:'key3', '3002', 'white', 'image/jpeg', repeat('E', 400), :'p1') as filled \gset
reset role;
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.decide_shop_product(:'shop', '3002', 'declined');
reset role;
set role anon;
select public.send_shop_product(:'key3', '4000', '{}', :'v1', :'p1', array['white']) is not null as roomy \gset
select pg_temp.check(:'roomy', 'when the owner decides on one, there is room for another');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{"changed": true}'', %L, %L, array[''white''])', :'key3', :'v2', :'p1'), 'waiting list is full');
select pg_temp.fails(format('select public.send_shop_product(%L, ''3002'', ''{}'', %L, %L, array[''white''], true)', :'key3', :'v1', :'p1'), 'waiting list is full');
reset role;

-- A product whose photos never arrived (the PC was switched off) is dropped after two days, to make room.
update public.shop_products set sent_at = now() - interval '3 days' where product_key = '3010';
set role anon;
select public.send_shop_product(:'key3', '3001', '{"changed": true}', :'v2', :'p1', array['white']) is not null as touched \gset
reset role;
select pg_temp.check(not exists (select 1 from public.shop_products where product_key = '3010'), 'a product that never got its photos is dropped after two days');
select pg_temp.check((select count(*) from public.shop_products where state in ('sending', 'waiting')) = 24, 'which makes room on the list');

-- The shop PC reads what the list holds.
set role anon;
select public.get_shop_product_states(:'key3') as states \gset
select pg_temp.check(jsonb_array_length((:'states')::jsonb) = 26, 'the shop PC reads every product on the list');
select pg_temp.check((select e ->> 'state' from jsonb_array_elements((:'states')::jsonb) as e where e ->> 'product' = '1006') = 'published'
    and (select e ->> 'state' from jsonb_array_elements((:'states')::jsonb) as e where e ->> 'product' = '3002') = 'declined'
    and (select e -> 'staged' from jsonb_array_elements((:'states')::jsonb) as e where e ->> 'product' = '3002') = '[]'::jsonb,
    'with the state of each, and which photos are here');
reset role;

-- The website's categories: the owner's website sends them, the shop PC reads them.
set role anon;
select pg_temp.fails('select * from public.site_categories', 'permission denied');
select pg_temp.fails(format('select public.save_site_categories(%L, ''[{"id": "a", "name": "Grocery"}]'')', :'shop'), 'permission denied');
select pg_temp.check(public.get_site_categories(:'key3') is null, 'the shop PC hears of no categories before the website sends them');
select pg_temp.fails('select public.get_site_categories(''0000'')', 'not connected');
reset role;
set role authenticated;
set request.jwt.claim.sub = :'stranger';
select pg_temp.fails(format('select public.save_site_categories(%L, ''[{"id": "a", "name": "Grocery"}]'')', :'shop'), 'Only the shop''s owner');
set request.jwt.claim.sub = :'owner';
select pg_temp.fails(format('select public.save_site_categories(%L, null)', :'shop'), 'missing or too many');
select pg_temp.fails(format('select public.save_site_categories(%L, ''{}'')', :'shop'), 'missing or too many');
select pg_temp.fails(format('select public.save_site_categories(%L, ''[]'')', :'shop'), 'missing or too many');
select pg_temp.fails(format('select public.save_site_categories(%L, (select jsonb_agg(jsonb_build_object(''id'', i::text, ''name'', ''Category '' || i)) from generate_series(1, 1001) as i))', :'shop'), 'missing or too many');
select pg_temp.fails(format('select public.save_site_categories(%L, ''[{"id": "a"}]'')', :'shop'), 'not as expected');
select pg_temp.fails(format('select public.save_site_categories(%L, ''[{"id": "a", "name": "  "}]'')', :'shop'), 'not as expected');
select pg_temp.fails(format('select public.save_site_categories(%L, ''[{"id": 5, "name": "Grocery"}]'')', :'shop'), 'not as expected');
select pg_temp.fails(format('select public.save_site_categories(%L, ''[{"id": "a", "name": "Grocery", "parentId": 7}]'')', :'shop'), 'not as expected');
select pg_temp.fails(format('select public.save_site_categories(%L, ''["Grocery"]'')', :'shop'), 'not as expected');
select pg_temp.fails(format('select public.save_site_categories(%L, jsonb_build_array(jsonb_build_object(''id'', repeat(''x'', 65), ''name'', ''Grocery'')))', :'shop'), 'not as expected');
select public.save_site_categories(:'shop', '[{"id": "cat-1", "name": " Grocery ", "parentId": null, "slug": "grocery", "secret": "x"}, {"id": "cat-2", "name": "Oils", "parentId": "cat-1"}]');
select pg_temp.check((select categories from public.site_categories) = '[{"id": "cat-1", "name": "Grocery", "parentId": null}, {"id": "cat-2", "name": "Oils", "parentId": "cat-1"}]'::jsonb,
    'only the id, the name and the main category are kept, in the order sent');
select public.save_site_categories(:'shop', '[{"id": "cat-1", "name": "Grocery"}]');
select pg_temp.check((select jsonb_array_length(categories) from public.site_categories) = 1, 'a list sent again replaces the earlier');
select pg_temp.fails('insert into public.site_categories (shop_id, categories) values (gen_random_uuid(), ''[]'')', 'permission denied');
select pg_temp.fails(format('update public.site_categories set categories = ''[]'' where shop_id = %L', :'shop'), 'permission denied');
select pg_temp.fails(format('delete from public.site_categories where shop_id = %L', :'shop'), 'permission denied');
reset role;
set role authenticated;
set request.jwt.claim.sub = :'stranger';
select pg_temp.check((select count(*) from public.site_categories) = 0, 'a stranger does not see the categories');
reset role;
set role anon;
select public.get_site_categories(:'key3') as cats \gset
select pg_temp.check((:'cats')::jsonb -> 'categories' -> 0 ->> 'name' = 'Grocery' and (:'cats')::jsonb ->> 'updated_at' is not null, 'the shop PC reads the website''s categories');
reset role;

-- Several PCs in one shop: the first one connected is the main PC, and only it sends and takes the owner's questions; the
-- others are counters, which the main PC's name is told to. Any PC can be made the main one.
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.new_pairing_code(:'shop') as code4 \gset
reset role;
set role anon;
select (public.connect_shop_pc(:'code4', 'Counter 2')) ->> 'key' as key4 \gset
select pg_temp.check((public.get_shop_pc_role(:'key3')) ->> 'main' = 'true' and (public.get_shop_pc_role(:'key3')) -> 'main_label' = 'null'::jsonb, 'the first PC connected is the main one');
select pg_temp.check((public.get_shop_pc_role(:'key4')) ->> 'main' = 'false' and (public.get_shop_pc_role(:'key4')) ->> 'main_label' = 'Shop PC', 'the next PC is a counter and is told which is the main one');
select pg_temp.fails('select public.get_shop_pc_role(''0000'')', 'not connected');
select pg_temp.fails('select public.claim_main_pc(''0000'')', 'not connected');
select pg_temp.fails('select public.require_main_pc(gen_random_uuid(), gen_random_uuid())', 'permission denied');
reset role;
set role authenticated;
set request.jwt.claim.sub = :'owner';
select pg_temp.check((select array_agg(is_main order by connected_at) from public.shop_devices) = array[true, false], 'the owner sees which PC is the main one');
reset role;
select pg_temp.check((select last_seen_at from public.shop_devices where label = 'Counter 2') is not null, 'asking its role marks a counter as seen');

-- A counter sends nothing and takes nothing; what it may do is read.
set role anon;
select pg_temp.fails(format('select public.send_live_figures(%L, ''{"today": {}}'')', :'key4'), 'main PC');
select pg_temp.fails(format('select public.send_shop_report(%L, ''review'', ''{}'')', :'key4'), 'main PC');
select pg_temp.fails(format('select public.next_shop_question(%L)', :'key4'), 'main PC');
select pg_temp.fails(format('select public.answer_shop_question(%L, gen_random_uuid(), ''{}'')', :'key4'), 'main PC');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{}'', %L, %L, array[''white''])', :'key4', :'v1', :'p1'), 'main PC');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''white'', ''image/jpeg'', repeat(''A'', 400), %L)', :'key4', :'p1'), 'main PC');
select pg_temp.fails(format('select public.withdraw_shop_product(%L, ''1006'')', :'key4'), '"Shop PC"');
select pg_temp.check(jsonb_typeof(public.get_shop_product_states(:'key4')) = 'array', 'a counter may read the waiting list');
select pg_temp.check(jsonb_typeof(public.get_site_categories(:'key4')) = 'object', 'and the website''s categories');
-- The main PC goes on as before.
select public.send_shop_report(:'key3', 'review', '{"version": 1}') is not null as still_main \gset
select pg_temp.check(:'still_main', 'the main PC still sends');
reset role;

-- A counter made the main PC: the PC that was main becomes a counter.
set role anon;
select public.claim_main_pc(:'key4') as claimed \gset
select pg_temp.check((:'claimed')::jsonb ->> 'previous' = 'Shop PC', 'the PC that was the main one is named');
select public.claim_main_pc(:'key4') as claimed_again \gset
select pg_temp.check((:'claimed_again')::jsonb -> 'previous' = 'null'::jsonb, 'claiming it again names nobody');
select pg_temp.fails(format('select public.send_shop_report(%L, ''review'', ''{}'')', :'key3'), 'main PC');
select pg_temp.fails(format('select public.send_shop_report(%L, ''review'', ''{}'')', :'key3'), '"Counter 2"');
select public.send_shop_report(:'key4', 'review', '{"version": 1}') is not null as now_main \gset
select pg_temp.check(:'now_main', 'the new main PC sends');
reset role;
select pg_temp.check((select count(*) from public.shop_devices where is_main) = 1, 'a shop has one main PC');

-- The main PC is disconnected on the website: the next PC to ask becomes the main one.
set role authenticated;
set request.jwt.claim.sub = :'owner';
delete from public.shop_devices where is_main;
reset role;
select pg_temp.check((select count(*) from public.shop_devices where is_main) = 0, 'no main PC while the main one is gone');
set role anon;
select pg_temp.check((public.get_shop_pc_role(:'key3')) ->> 'main' = 'true', 'the next PC to ask becomes the main one');
reset role;
select pg_temp.check((select count(*) from public.shop_devices where is_main) = 1 and (select is_main from public.shop_devices where label = 'Shop PC'), 'and that is kept');
update public.shop_devices set is_main = false;
set role anon;
select pg_temp.check(public.next_shop_question(:'key3') is null, 'a PC that asks for a question first becomes the main one too');
reset role;
select pg_temp.check((select is_main from public.shop_devices where label = 'Shop PC'), 'and takes the owner''s questions');

-- The PC that connected first is the main one, even when another asks first.
delete from public.shop_devices;
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.new_pairing_code(:'shop') as code5 \gset
select public.new_pairing_code(:'shop') as code6 \gset
reset role;
set role anon;
select (public.connect_shop_pc(:'code5', 'First PC')) ->> 'key' as key5 \gset
select (public.connect_shop_pc(:'code6', 'Second PC')) ->> 'key' as key6 \gset
select pg_temp.check((public.get_shop_pc_role(:'key6')) ->> 'main' = 'false' and (public.get_shop_pc_role(:'key6')) ->> 'main_label' = 'First PC', 'the PC that connected first is the main one, whoever asks first');
reset role;
delete from public.shop_devices;
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.new_pairing_code(:'shop') as code7 \gset
reset role;
set role anon;
select (public.connect_shop_pc(:'code7', 'Shop PC')) ->> 'key' as key3 \gset
reset role;
set role authenticated;
set request.jwt.claim.sub = :'owner';
select public.new_pairing_code(:'shop') as code8 \gset
reset role;
set role anon;
select (public.connect_shop_pc(:'code8', 'Counter 2')) ->> 'key' as key4 \gset
reset role;

-- A shop that had PCs before the roles existed: the PC that connected first is made the main one.
update public.shop_devices set is_main = false;
update public.shop_devices d set is_main = true
where d.id = (select x.id from public.shop_devices x where x.shop_id = d.shop_id order by x.connected_at, x.id limit 1)
  and not exists (select 1 from public.shop_devices y where y.shop_id = d.shop_id and y.is_main);
select pg_temp.check((select count(*) from public.shop_devices where is_main) = 1, 'the PC connected first is made the main one');
select pg_temp.check((select label from public.shop_devices where is_main) = 'Shop PC', 'that is the oldest');
set role anon;
select pg_temp.check((public.get_shop_pc_role(:'key3')) ->> 'main' = 'true', 'and it is the one in use');
select public.disconnect_shop_pc(:'key4');
reset role;
select pg_temp.check((select count(*) from public.shop_devices) = 1, 'a counter can forget its own connection');

-- A disconnected PC can no longer send reports.
set role authenticated;
set request.jwt.claim.sub = :'owner';
delete from public.shop_devices;
reset role;
set role anon;
select pg_temp.fails(format('select public.send_shop_report(%L, ''review'', ''{}'')', :'key3'), 'not connected');
select pg_temp.fails(format('select public.send_shop_product(%L, ''1006'', ''{}'', %L, %L, array[''white''])', :'key3', :'v1', :'p1'), 'not connected');
select pg_temp.fails(format('select public.send_shop_product_photo(%L, ''1006'', ''white'', ''image/jpeg'', repeat(''A'', 400), %L)', :'key3', :'p1'), 'not connected');
select pg_temp.fails(format('select public.get_shop_product_states(%L)', :'key3'), 'not connected');
select pg_temp.fails(format('select public.withdraw_shop_product(%L, ''1006'')', :'key3'), 'not connected');
select pg_temp.fails(format('select public.get_site_categories(%L)', :'key3'), 'not connected');
reset role;

-- The website gets new figures, and answers, as they arrive.
select pg_temp.check(exists (select 1 from pg_publication_tables where pubname = 'supabase_realtime' and tablename = 'shop_live'), 'live figures are published for the website');
select pg_temp.check(exists (select 1 from pg_publication_tables where pubname = 'supabase_realtime' and tablename = 'shop_questions'), 'answers are published for the website');
select pg_temp.check(exists (select 1 from pg_publication_tables where pubname = 'supabase_realtime' and tablename = 'shop_reports'), 'reports are published for the website');
select pg_temp.check(exists (select 1 from pg_publication_tables where pubname = 'supabase_realtime' and tablename = 'shop_products'), 'the products on the list are published for the website');

\echo 'All owner view checks passed.'
