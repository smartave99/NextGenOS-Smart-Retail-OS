-- Smart Retail POS by NextGen OS: the owner's live view, kept in the owner's own Supabase project.
--
-- Run it once in Supabase: SQL Editor > New query > paste this whole file > Run. Running it again is safe.
--
-- How it works:
--   * The owner signs up on the website (the admin panel's Live shop, or the owner's page) and creates the shop
--     (the first shop only: nobody else can create one in this project afterwards).
--   * The owner may turn on a second sign-in step, a code from an authenticator app. From then on the password
--     alone shows nothing: every read and every owner function below also needs that code (checked here, in the
--     database, not only on the website).
--   * On the website the owner makes a one-time code (valid 15 minutes) and types it into the shop PC
--     (Settings > Owner's live view). The PC gets its own long key in exchange, and keeps it; only a hash of the
--     key is stored here. It needs no Supabase sign-in, only the project's public (anon) key.
--   * Every minute the shop PC sends the shop's figures with that key; the owner sees them on the website, live.
--   * What is sent: today's totals, each bill's number, time and amount, sales by hour and by day, the best
--     sellers' names and quantities, low stock and the Fix now list. Once an hour it also sends the Monday review:
--     last week's sales against the week before and the same week a year before, and the products running out or
--     not selling, with their figures. Never customer names, phone numbers or what was on a bill.
--   * The owner can disconnect a shop PC on the website; its key then stops working at once.
--   * A shop may have several PCs (a main PC and the counters). The first PC connected is the main one, and only the
--     main PC sends to this project and takes the owner's questions; any PC can be made the main one in its Settings.
--   * The owner can ask the shop's AI from the website. The shop PC takes each question with its own key, answers
--     it with the shop's AI the way Ask AI answers at the shop (read-only, checked queries, contact details hidden
--     unless the shop turned that off), and sends the answer back here, for the shop's members only.
--   * If the owner turns it on in Settings, the shop PC also offers the products whose photos and listing are finished
--     for the website: the listing, the POS's price and up to five photos. They wait here, at most 25 at a time, and
--     nothing reaches the public website until the owner approves each one on the website. Only the owner sees them.

create extension if not exists pgcrypto with schema extensions;

-- The shop, and the people who may see it.
create table if not exists public.shops (
    id uuid primary key default gen_random_uuid(),
    name text not null check (char_length(name) between 1 and 120),
    created_at timestamptz not null default now()
);

create table if not exists public.shop_members (
    shop_id uuid not null references public.shops (id) on delete cascade,
    user_id uuid not null references auth.users (id) on delete cascade,
    role text not null check (role in ('owner', 'viewer')),
    added_at timestamptz not null default now(),
    primary key (shop_id, user_id)
);

-- The shop PCs that send figures, each with its own key; only the key's SHA-256 hash is kept.
create table if not exists public.shop_devices (
    id uuid primary key default gen_random_uuid(),
    shop_id uuid not null references public.shops (id) on delete cascade,
    label text not null default 'Shop PC' check (char_length(label) between 1 and 60),
    key_hash text not null unique,
    connected_at timestamptz not null default now(),
    last_seen_at timestamptz
);

-- One-time codes that connect a shop PC, made by the owner; each works once, within 15 minutes.
create table if not exists public.pairing_codes (
    code text primary key,
    shop_id uuid not null references public.shops (id) on delete cascade,
    created_by uuid not null references auth.users (id) on delete cascade,
    expires_at timestamptz not null,
    used_at timestamptz
);

-- The latest figures from the shop PC, one row per shop; and one row per day, for the history.
create table if not exists public.shop_live (
    shop_id uuid primary key references public.shops (id) on delete cascade,
    data jsonb not null,
    sent_at timestamptz not null default now()
);

create table if not exists public.shop_days (
    shop_id uuid not null references public.shops (id) on delete cascade,
    day date not null,
    data jsonb not null,
    sent_at timestamptz not null default now(),
    primary key (shop_id, day)
);

-- A shop can have several PCs (a main PC and the counters). Only the main one sends to this project and takes the owner's
-- questions: the PCs keep their own photos, notes and decisions, so two of them would send different versions of the same
-- thing. The first PC connected is the main one; any PC can be made the main one.
alter table public.shop_devices add column if not exists is_main boolean not null default false;

update public.shop_devices d set is_main = true
where d.id = (select x.id from public.shop_devices x where x.shop_id = d.shop_id order by x.connected_at, x.id limit 1)
  and not exists (select 1 from public.shop_devices y where y.shop_id = d.shop_id and y.is_main);

alter table public.shops enable row level security;
alter table public.shop_members enable row level security;
alter table public.shop_devices enable row level security;
alter table public.pairing_codes enable row level security;
alter table public.shop_live enable row level security;
alter table public.shop_days enable row level security;

-- Whether this sign-in is strong enough: someone who turned on the authenticator app must have entered its code
-- this time (Supabase marks such a sign-in "aal2"). Without the app, the password is enough.
create or replace function public.sign_in_strong_enough()
returns boolean
language plpgsql
stable
security definer
set search_path = ''
as $$
begin
    -- The sign-in's claims, as Supabase sets them for each request (what auth.jwt() returns).
    return coalesce(nullif(current_setting('request.jwt.claims', true), '')::jsonb ->> 'aal', 'aal1') = 'aal2'
        or not exists (
            select 1
            from auth.mfa_factors f
            where f.user_id = (select auth.uid())
              and f.status = 'verified'
        );
end;
$$;

-- Whether the signed-in person may see the shop (as one of p_roles).
create or replace function public.is_shop_member(p_shop uuid, p_roles text[] default array['owner', 'viewer'])
returns boolean
language sql
stable
security definer
set search_path = ''
as $$
    select public.sign_in_strong_enough()
       and exists (
        select 1
        from public.shop_members m
        where m.shop_id = p_shop
          and m.user_id = (select auth.uid())
          and m.role = any (p_roles)
    );
$$;

-- Signed-in members read their shop's rows; nobody writes to the tables directly: the functions below do.
drop policy if exists "Members see their shop" on public.shops;
create policy "Members see their shop" on public.shops
    for select to authenticated using ((select public.is_shop_member(id)));

drop policy if exists "Members see who can see the shop" on public.shop_members;
create policy "Members see who can see the shop" on public.shop_members
    for select to authenticated using ((select public.is_shop_member(shop_id)));

drop policy if exists "Members see the shop PCs" on public.shop_devices;
create policy "Members see the shop PCs" on public.shop_devices
    for select to authenticated using ((select public.is_shop_member(shop_id)));

drop policy if exists "Owners disconnect a shop PC" on public.shop_devices;
create policy "Owners disconnect a shop PC" on public.shop_devices
    for delete to authenticated using ((select public.is_shop_member(shop_id, array['owner'])));

drop policy if exists "Members see the live figures" on public.shop_live;
create policy "Members see the live figures" on public.shop_live
    for select to authenticated using ((select public.is_shop_member(shop_id)));

drop policy if exists "Members see the days" on public.shop_days;
create policy "Members see the days" on public.shop_days
    for select to authenticated using ((select public.is_shop_member(shop_id)));

-- The table grants Supabase gives by default, narrowed: the public key reads and writes nothing directly, and
-- a device's key hash is never read back.
revoke all on public.shops, public.shop_members, public.shop_devices, public.pairing_codes, public.shop_live, public.shop_days
    from anon, authenticated;
grant select on public.shops, public.shop_members, public.shop_live, public.shop_days to authenticated;
grant select (id, shop_id, label, connected_at, last_seen_at, is_main) on public.shop_devices to authenticated;
grant delete on public.shop_devices to authenticated;

-- The owner creates the shop: once per project, by the first person signed in.
create or replace function public.create_shop(p_name text)
returns uuid
language plpgsql
security definer
set search_path = ''
as $$
declare
    v_user uuid := (select auth.uid());
    v_shop uuid;
begin
    if v_user is null then
        raise exception 'Sign in first.';
    end if;
    if not public.sign_in_strong_enough() then
        raise exception 'Enter the code from your authenticator app first.';
    end if;
    if coalesce(btrim(p_name), '') = '' then
        raise exception 'Give the shop a name.';
    end if;

    lock table public.shops in exclusive mode;
    if exists (select 1 from public.shops) then
        raise exception 'This project already has its shop. Ask its owner to add you.';
    end if;

    insert into public.shops (name) values (left(btrim(p_name), 120)) returning id into v_shop;
    insert into public.shop_members (shop_id, user_id, role) values (v_shop, v_user, 'owner');
    return v_shop;
end;
$$;

-- The owner makes a one-time code to connect a shop PC: 8 letters and digits that are easy to read (no 0, O, 1
-- or I), shown as ABCD-EFGH.
create or replace function public.new_pairing_code(p_shop uuid)
returns text
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_letters constant text := 'ABCDEFGHJKLMNPQRSTUVWXYZ23456789';
    v_bytes bytea := extensions.gen_random_bytes(8);
    v_code text := '';
begin
    if not public.sign_in_strong_enough() then
        raise exception 'Enter the code from your authenticator app first.';
    end if;
    if not public.is_shop_member(p_shop, array['owner']) then
        raise exception 'Only the shop''s owner can connect a shop PC.';
    end if;

    for i in 0..7 loop
        v_code := v_code || substr(v_letters, get_byte(v_bytes, i) % 32 + 1, 1);
    end loop;

    delete from public.pairing_codes where expires_at < now() - interval '1 day';
    insert into public.pairing_codes (code, shop_id, created_by, expires_at)
    values (v_code, p_shop, (select auth.uid()), now() + interval '15 minutes');
    return v_code;
end;
$$;

-- The shop PC connects with the code, using only the public key, and gets its own key back, once.
create or replace function public.connect_shop_pc(p_code text, p_label text default 'Shop PC')
returns jsonb
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_pairing public.pairing_codes;
    v_key text := encode(extensions.gen_random_bytes(32), 'hex');
    v_name text;
begin
    select * into v_pairing
    from public.pairing_codes
    where code = upper(replace(btrim(coalesce(p_code, '')), '-', ''))
    for update;

    if not found or v_pairing.used_at is not null or v_pairing.expires_at < now() then
        raise exception 'That code is wrong or has expired. Make a new one on the website.';
    end if;

    update public.pairing_codes set used_at = now() where code = v_pairing.code;
    insert into public.shop_devices (shop_id, label, key_hash, is_main)
    values (v_pairing.shop_id, left(coalesce(nullif(btrim(p_label), ''), 'Shop PC'), 60),
            encode(extensions.digest(v_key, 'sha256'), 'hex'),
            not exists (select 1 from public.shop_devices d where d.shop_id = v_pairing.shop_id and d.is_main));

    select s.name into v_name from public.shops s where s.id = v_pairing.shop_id;
    return jsonb_build_object('key', v_key, 'shop_id', v_pairing.shop_id, 'shop_name', v_name);
end;
$$;

-- The shop PC sends the latest figures, and any days whose totals changed.
create or replace function public.send_live_figures(p_key text, p_live jsonb, p_days jsonb default '[]'::jsonb)
returns timestamptz
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
    v_now timestamptz := now();
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');

    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;
    perform public.require_main_pc(v_device.id, v_device.shop_id);
    if p_live is null or jsonb_typeof(p_live) <> 'object' or octet_length(p_live::text) > 262144 then
        raise exception 'The figures are missing or too large.';
    end if;
    if p_days is not null and (jsonb_typeof(p_days) <> 'array' or jsonb_array_length(p_days) > 62
        or octet_length(p_days::text) > 524288) then
        raise exception 'Too many days at once.';
    end if;

    insert into public.shop_live (shop_id, data, sent_at)
    values (v_device.shop_id, p_live, v_now)
    on conflict (shop_id) do update set data = excluded.data, sent_at = excluded.sent_at;

    insert into public.shop_days (shop_id, day, data, sent_at)
    select v_device.shop_id, (d ->> 'day')::date, d, v_now
    from jsonb_array_elements(coalesce(p_days, '[]'::jsonb)) as d
    where jsonb_typeof(d) = 'object' and coalesce(d ->> 'day', '') ~ '^\d{4}-\d{2}-\d{2}$'
    on conflict (shop_id, day) do update set data = excluded.data, sent_at = excluded.sent_at;

    update public.shop_devices set last_seen_at = v_now where id = v_device.id;
    return v_now;
end;
$$;

-- The shop PC forgets its connection (Disconnect on the PC).
create or replace function public.disconnect_shop_pc(p_key text)
returns void
language sql
volatile
security definer
set search_path = ''
as $$
    delete from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
$$;

-- Which shop PC does the shop's work for the owner. A PC that is not the main one is told which is.
create or replace function public.require_main_pc(p_device uuid, p_shop uuid)
returns void
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_main public.shop_devices;
begin
    perform pg_advisory_xact_lock(hashtextextended('shop_main_pc:' || p_shop::text, 0));
    select * into v_main from public.shop_devices d where d.shop_id = p_shop and d.is_main;
    if not found then
        -- No main PC (the main one was disconnected): the first PC to ask becomes it.
        update public.shop_devices set is_main = true where id = p_device;
    elsif v_main.id <> p_device then
        raise exception 'Another shop PC, "%", is this shop''s main PC and does this for the shop. Make this PC the main one in its Settings if it should.', v_main.label;
    end if;
end;
$$;

-- The shop PC asks what it is: the main PC, or a counter (and which PC is the main one). This also marks it as seen.
create or replace function public.get_shop_pc_role(p_key text)
returns jsonb
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
    v_main public.shop_devices;
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;

    perform pg_advisory_xact_lock(hashtextextended('shop_main_pc:' || v_device.shop_id::text, 0));
    select * into v_main from public.shop_devices d where d.shop_id = v_device.shop_id and d.is_main;
    if not found then
        update public.shop_devices set is_main = true where id = v_device.id;
        v_main := v_device;
    end if;
    update public.shop_devices set last_seen_at = now() where id = v_device.id;

    return jsonb_build_object('main', v_main.id = v_device.id, 'main_label', case when v_main.id = v_device.id then null else v_main.label end);
end;
$$;

-- The shop PC makes itself the main one (the owner pressed the button on it). The answer names the PC that was the main one before.
create or replace function public.claim_main_pc(p_key text)
returns jsonb
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
    v_before public.shop_devices;
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;

    perform pg_advisory_xact_lock(hashtextextended('shop_main_pc:' || v_device.shop_id::text, 0));
    select * into v_before from public.shop_devices d where d.shop_id = v_device.shop_id and d.is_main;
    update public.shop_devices set is_main = (id = v_device.id) where shop_id = v_device.shop_id;
    update public.shop_devices set last_seen_at = now() where id = v_device.id;

    return jsonb_build_object('previous', case when v_before.id is distinct from v_device.id then v_before.label end);
end;
$$;

revoke all on function public.require_main_pc(uuid, uuid) from public, anon, authenticated;
revoke all on function public.get_shop_pc_role(text) from public;
revoke all on function public.claim_main_pc(text) from public;
grant execute on function public.get_shop_pc_role(text) to anon, authenticated;
grant execute on function public.claim_main_pc(text) to anon, authenticated;

-- Who may call what. Supabase lets everyone run new functions by default, so each is set here: the public key
-- only connects a PC and sends figures; making the shop and codes needs a signed-in person.
revoke all on function public.sign_in_strong_enough() from public, anon;
revoke all on function public.is_shop_member(uuid, text[]) from public, anon;
revoke all on function public.create_shop(text) from public, anon;
revoke all on function public.new_pairing_code(uuid) from public, anon;
revoke all on function public.connect_shop_pc(text, text) from public;
revoke all on function public.send_live_figures(text, jsonb, jsonb) from public;
revoke all on function public.disconnect_shop_pc(text) from public;
grant execute on function public.sign_in_strong_enough() to authenticated;
grant execute on function public.is_shop_member(uuid, text[]) to authenticated;
grant execute on function public.create_shop(text) to authenticated;
grant execute on function public.new_pairing_code(uuid) to authenticated;
grant execute on function public.connect_shop_pc(text, text) to anon, authenticated;
grant execute on function public.send_live_figures(text, jsonb, jsonb) to anon, authenticated;
grant execute on function public.disconnect_shop_pc(text) to anon, authenticated;

-- Questions the owner asks the shop's AI from the website, and the shop PC's answers.
create table if not exists public.shop_questions (
    id uuid primary key default gen_random_uuid(),
    shop_id uuid not null references public.shops (id) on delete cascade,
    asked_by uuid not null references auth.users (id) on delete cascade,
    question text not null check (char_length(question) between 1 and 1000),
    status text not null default 'waiting' check (status in ('waiting', 'working', 'answered', 'failed')),
    answer jsonb,
    asked_at timestamptz not null default now(),
    taken_at timestamptz,
    answered_at timestamptz
);

create index if not exists shop_questions_by_shop on public.shop_questions (shop_id, asked_at desc);

alter table public.shop_questions enable row level security;

-- Only the owner reads the questions and answers: an answer may name customers, which stay the owner's.
drop policy if exists "Members see the shop's questions" on public.shop_questions;
drop policy if exists "The owner sees the shop's questions" on public.shop_questions;
create policy "The owner sees the shop's questions" on public.shop_questions
    for select to authenticated using ((select public.is_shop_member(shop_id, array['owner'])));

revoke all on public.shop_questions from anon, authenticated;
grant select on public.shop_questions to authenticated;

-- The owner asks: 1 to 1,000 characters, at most 30 questions an hour. Questions older than 30 days go.
create or replace function public.ask_the_shop(p_shop uuid, p_question text)
returns uuid
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_question text := btrim(coalesce(p_question, ''));
    v_id uuid;
begin
    if not public.sign_in_strong_enough() then
        raise exception 'Enter the code from your authenticator app first.';
    end if;
    if not public.is_shop_member(p_shop, array['owner']) then
        raise exception 'Only the shop''s owner can ask the shop''s AI.';
    end if;
    if v_question = '' or char_length(v_question) > 1000 then
        raise exception 'Ask in 1 to 1,000 characters.';
    end if;
    if (select count(*) from public.shop_questions q
        where q.asked_by = (select auth.uid()) and q.asked_at > now() - interval '1 hour') >= 30 then
        raise exception 'That is 30 questions this hour. Ask again a little later.';
    end if;

    delete from public.shop_questions q where q.shop_id = p_shop and q.asked_at < now() - interval '30 days';
    insert into public.shop_questions (shop_id, asked_by, question)
    values (p_shop, (select auth.uid()), v_question)
    returning id into v_id;
    return v_id;
end;
$$;

-- The shop PC takes the oldest question waiting, with its own key; also one it took 10 minutes ago and never
-- answered (e.g. it was switched off). Null when there is none.
create or replace function public.next_shop_question(p_key text)
returns jsonb
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
    v_question public.shop_questions;
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;
    perform public.require_main_pc(v_device.id, v_device.shop_id);

    select * into v_question
    from public.shop_questions q
    where q.shop_id = v_device.shop_id
      and (q.status = 'waiting' or (q.status = 'working' and q.taken_at < now() - interval '10 minutes'))
    order by q.asked_at
    limit 1
    for update skip locked;
    if not found then
        return null;
    end if;

    update public.shop_questions set status = 'working', taken_at = now() where id = v_question.id;
    return jsonb_build_object('id', v_question.id, 'question', v_question.question, 'asked_at', v_question.asked_at);
end;
$$;

-- The shop PC gives the answer, or says it could not answer, with its own key.
create or replace function public.answer_shop_question(p_key text, p_id uuid, p_answer jsonb, p_failed boolean default false)
returns void
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;
    perform public.require_main_pc(v_device.id, v_device.shop_id);
    if p_answer is null or jsonb_typeof(p_answer) <> 'object' or octet_length(p_answer::text) > 262144 then
        raise exception 'The answer is missing or too large.';
    end if;

    update public.shop_questions
    set status = case when coalesce(p_failed, false) then 'failed' else 'answered' end,
        answer = p_answer,
        answered_at = now()
    where id = p_id and shop_id = v_device.shop_id and status = 'working';
    if not found then
        raise exception 'That question is not waiting for this shop PC''s answer.';
    end if;
end;
$$;

revoke all on function public.ask_the_shop(uuid, text) from public, anon;
revoke all on function public.next_shop_question(text) from public;
revoke all on function public.answer_shop_question(text, uuid, jsonb, boolean) from public;
grant execute on function public.ask_the_shop(uuid, text) to authenticated;
grant execute on function public.next_shop_question(text) to anon, authenticated;
grant execute on function public.answer_shop_question(text, uuid, jsonb, boolean) to anon, authenticated;

-- The weekly screens: besides the live figures the shop PC keeps one report of each kind up to date (the Monday
-- review is 'review'), a small piece of figures replaced whenever the PC sends it again. The shop's members read
-- them like the live figures; a new screen in a later version is a new kind and needs no change here.
create table if not exists public.shop_reports (
    shop_id uuid not null references public.shops (id) on delete cascade,
    kind text not null check (kind ~ '^[a-z][a-z0-9-]{0,30}$'),
    data jsonb not null,
    sent_at timestamptz not null default now(),
    primary key (shop_id, kind)
);

alter table public.shop_reports enable row level security;

drop policy if exists "Members see the reports" on public.shop_reports;
create policy "Members see the reports" on public.shop_reports
    for select to authenticated using ((select public.is_shop_member(shop_id)));

revoke all on public.shop_reports from anon, authenticated;
grant select on public.shop_reports to authenticated;

-- The shop PC sends a report with its own key: 'review', for example. A shop keeps at most 20 kinds.
create or replace function public.send_shop_report(p_key text, p_kind text, p_data jsonb)
returns timestamptz
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
    v_now timestamptz := now();
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;
    perform public.require_main_pc(v_device.id, v_device.shop_id);
    if coalesce(p_kind, '') !~ '^[a-z][a-z0-9-]{0,30}$' then
        raise exception 'That kind of report is not known.';
    end if;
    if p_data is null or jsonb_typeof(p_data) <> 'object' or octet_length(p_data::text) > 262144 then
        raise exception 'The report is missing or too large.';
    end if;
    if not exists (select 1 from public.shop_reports r where r.shop_id = v_device.shop_id and r.kind = p_kind)
       and (select count(*) from public.shop_reports r where r.shop_id = v_device.shop_id) >= 20 then
        raise exception 'This shop keeps all the reports it can.';
    end if;

    insert into public.shop_reports (shop_id, kind, data, sent_at)
    values (v_device.shop_id, p_kind, p_data, v_now)
    on conflict (shop_id, kind) do update set data = excluded.data, sent_at = excluded.sent_at;

    update public.shop_devices set last_seen_at = v_now where id = v_device.id;
    return v_now;
end;
$$;

revoke all on function public.send_shop_report(text, text, jsonb) from public;
grant execute on function public.send_shop_report(text, text, jsonb) to anon, authenticated;

-- The website's products: besides figures, the shop PC can offer the products whose photos and listing are finished
-- (Smart Retail POS: Product photos) for the owner's website, if the owner turned that on in Settings. They wait
-- here, with their photos, in a short list. Nothing reaches the public website until the owner decides, on the
-- website, one product at a time with the listing and the photos in front of them. The prices are the POS's, never
-- an AI's. A product is "sending" while its photos arrive, "waiting" for the owner's decision, then "published" or
-- "declined"; its photos are kept here only until the owner decides. At most 25 products wait at once: the shop PC
-- sends more as the owner decides on these.
create table if not exists public.shop_products (
    shop_id uuid not null references public.shops (id) on delete cascade,
    product_key text not null check (product_key ~ '^[0-9]{1,10}$'),
    data jsonb not null,
    version text not null check (version ~ '^[0-9a-f]{16,64}$'),
    photos_version text not null check (photos_version ~ '^[0-9a-f]{16,64}$'),
    photo_kinds text[] not null,
    state text not null check (state in ('sending', 'waiting', 'published', 'declined')),
    sent_at timestamptz not null default now(),
    decided_at timestamptz,
    primary key (shop_id, product_key)
);

create table if not exists public.shop_product_photos (
    shop_id uuid not null,
    product_key text not null,
    kind text not null check (kind in ('white', 'in-use', 'european-model', 'indian-model', 'east-asian-model')),
    mime text not null check (mime in ('image/jpeg', 'image/png', 'image/webp')),
    content text not null check (char_length(content) between 100 and 900000),
    sent_at timestamptz not null default now(),
    primary key (shop_id, product_key, kind),
    foreign key (shop_id, product_key) references public.shop_products (shop_id, product_key) on delete cascade
);

alter table public.shop_products enable row level security;
alter table public.shop_product_photos enable row level security;

-- Only the owner reads them: nobody writes to the tables directly, the functions below do.
drop policy if exists "The owner sees the products on the list" on public.shop_products;
create policy "The owner sees the products on the list" on public.shop_products
    for select to authenticated using ((select public.is_shop_member(shop_id, array['owner'])));

drop policy if exists "The owner sees the photos on the list" on public.shop_product_photos;
create policy "The owner sees the photos on the list" on public.shop_product_photos
    for select to authenticated using ((select public.is_shop_member(shop_id, array['owner'])));

revoke all on public.shop_products, public.shop_product_photos from anon, authenticated;
grant select on public.shop_products, public.shop_product_photos to authenticated;

-- The shop PC offers a product with its own key. It says what the product is (p_data, the listing and the POS's prices),
-- a fingerprint of that (p_version) and of its photos (p_photos_version), and which photos it has (p_photo_kinds). The
-- answer is the product's state and the photos to send now. A product it sent before and nothing changed in is left
-- alone; a declined product stays declined unless the PC offers it again (p_again) at the owner's wish.
create or replace function public.send_shop_product(p_key text, p_product text, p_data jsonb, p_version text,
    p_photos_version text, p_photo_kinds text[], p_again boolean default false)
returns jsonb
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_all constant text[] := array['white', 'in-use', 'european-model', 'indian-model', 'east-asian-model'];
    v_limit constant int := 25;
    v_device public.shop_devices;
    v_row public.shop_products;
    v_kinds text[];
    v_now timestamptz := now();
    v_state text;
    v_send text[];
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;
    perform public.require_main_pc(v_device.id, v_device.shop_id);
    if coalesce(p_product, '') !~ '^[0-9]{1,10}$' then
        raise exception 'That product is not known.';
    end if;
    if p_data is null or jsonb_typeof(p_data) <> 'object' or octet_length(p_data::text) > 65536 then
        raise exception 'The product is missing or too large.';
    end if;
    if coalesce(p_version, '') !~ '^[0-9a-f]{16,64}$' or coalesce(p_photos_version, '') !~ '^[0-9a-f]{16,64}$' then
        raise exception 'The product''s version is not known.';
    end if;
    if cardinality(coalesce(p_photo_kinds, '{}')) not between 1 and 5 or not (p_photo_kinds <@ v_all)
       or not ('white' = any (p_photo_kinds)) then
        raise exception 'The product''s photos are not known: it needs at least its white-background photo.';
    end if;
    -- In the order the photos are made in, none twice.
    select array_agg(k order by array_position(v_all, k)) into v_kinds from (select distinct unnest(p_photo_kinds) as k) as u;

    -- One product at a time per shop, so two shop PCs cannot overfill the list together.
    perform pg_advisory_xact_lock(hashtextextended('shop_products:' || v_device.shop_id::text, 0));
    delete from public.shop_products x
    where x.shop_id = v_device.shop_id and x.state = 'sending' and x.sent_at < v_now - interval '2 days' and x.product_key <> p_product;

    select * into v_row from public.shop_products x where x.shop_id = v_device.shop_id and x.product_key = p_product for update;
    if not found then
        if (select count(*) from public.shop_products x where x.shop_id = v_device.shop_id and x.state in ('sending', 'waiting')) >= v_limit then
            raise exception 'The waiting list is full: decide on some of the products on the website, and more are sent.';
        end if;
        insert into public.shop_products (shop_id, product_key, data, version, photos_version, photo_kinds, state, sent_at)
        values (v_device.shop_id, p_product, p_data, p_version, p_photos_version, v_kinds, 'sending', v_now);
        v_state := 'sending';
    elsif v_row.state = 'declined' and not coalesce(p_again, false) then
        v_state := 'declined';
    elsif v_row.state <> 'declined' and v_row.version = p_version and v_row.photos_version = p_photos_version and v_row.photo_kinds = v_kinds then
        v_state := v_row.state;
    else
        -- Changed, or offered again. A product that was decided on needs a place on the list again.
        if v_row.state in ('published', 'declined')
           and (select count(*) from public.shop_products x where x.shop_id = v_device.shop_id and x.state in ('sending', 'waiting')) >= v_limit then
            raise exception 'The waiting list is full: decide on some of the products on the website, and more are sent.';
        end if;
        if v_row.state = 'declined' or v_row.photos_version <> p_photos_version or v_row.photo_kinds <> v_kinds then
            -- New photos are needed: the photos changed, or a declined product's photos were dropped.
            delete from public.shop_product_photos f where f.shop_id = v_row.shop_id and f.product_key = v_row.product_key;
            update public.shop_products x
            set data = p_data, version = p_version, photos_version = p_photos_version, photo_kinds = v_kinds,
                state = 'sending', sent_at = v_now, decided_at = null
            where x.shop_id = v_row.shop_id and x.product_key = v_row.product_key;
            v_state := 'sending';
        else
            -- Only its words or prices changed: the photos it has stay as they are (a published product has none left here).
            v_state := case when v_row.state = 'sending' then 'sending' else 'waiting' end;
            update public.shop_products x
            set data = p_data, version = p_version, state = v_state, sent_at = v_now, decided_at = null
            where x.shop_id = v_row.shop_id and x.product_key = v_row.product_key;
        end if;
    end if;

    -- The photos still to send, in order; none for a product that is waiting or decided on.
    if v_state = 'sending' then
        select coalesce(array_agg(t.k order by t.n), '{}') into v_send
        from unnest(v_kinds) with ordinality as t (k, n)
        where not exists (select 1 from public.shop_product_photos f
                          where f.shop_id = v_device.shop_id and f.product_key = p_product and f.kind = t.k);
        if cardinality(v_send) = 0 then
            update public.shop_products x set state = 'waiting' where x.shop_id = v_device.shop_id and x.product_key = p_product;
            v_state := 'waiting';
        end if;
    else
        v_send := '{}';
    end if;

    update public.shop_devices set last_seen_at = v_now where id = v_device.id;
    return jsonb_build_object('state', v_state, 'send_photos', to_jsonb(v_send));
end;
$$;

-- The shop PC sends one of the product's photos (a picture of at most about 600 KB, as base64). The product turns
-- "waiting" for the owner when the last one has arrived.
create or replace function public.send_shop_product_photo(p_key text, p_product text, p_kind text, p_mime text,
    p_content text, p_photos_version text)
returns text
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
    v_row public.shop_products;
    v_now timestamptz := now();
    v_state text;
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;
    perform public.require_main_pc(v_device.id, v_device.shop_id);
    if coalesce(p_kind, '') not in ('white', 'in-use', 'european-model', 'indian-model', 'east-asian-model') then
        raise exception 'That photo is not known.';
    end if;
    if coalesce(p_mime, '') not in ('image/jpeg', 'image/png', 'image/webp') then
        raise exception 'That kind of picture is not taken.';
    end if;
    if p_content is null or char_length(p_content) not between 100 and 900000 or p_content !~ '^[A-Za-z0-9+/]+={0,2}$' then
        raise exception 'The photo is missing or too large.';
    end if;

    select * into v_row
    from public.shop_products x
    where x.shop_id = v_device.shop_id and x.product_key = coalesce(p_product, '')
    for update;
    if not found or v_row.state not in ('sending', 'waiting') or v_row.photos_version <> coalesce(p_photos_version, '') then
        raise exception 'This product is not waiting for photos any more.';
    end if;
    if not (p_kind = any (v_row.photo_kinds)) then
        raise exception 'That photo is not one of the product''s photos.';
    end if;

    insert into public.shop_product_photos (shop_id, product_key, kind, mime, content, sent_at)
    values (v_row.shop_id, v_row.product_key, p_kind, p_mime, p_content, v_now)
    on conflict (shop_id, product_key, kind) do update set mime = excluded.mime, content = excluded.content, sent_at = excluded.sent_at;

    v_state := v_row.state;
    if v_row.state = 'sending'
       and (select count(*) from public.shop_product_photos f where f.shop_id = v_row.shop_id and f.product_key = v_row.product_key)
           >= cardinality(v_row.photo_kinds) then
        update public.shop_products x set state = 'waiting', sent_at = v_now
        where x.shop_id = v_row.shop_id and x.product_key = v_row.product_key;
        v_state := 'waiting';
    end if;

    update public.shop_devices set last_seen_at = v_now where id = v_device.id;
    return v_state;
end;
$$;

-- What the list holds, for the shop PC: each product's state, its versions and which photos are here.
create or replace function public.get_shop_product_states(p_key text)
returns jsonb
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;

    return coalesce((
        select jsonb_agg(jsonb_build_object(
            'product', p.product_key,
            'state', p.state,
            'version', p.version,
            'photos_version', p.photos_version,
            'photo_kinds', to_jsonb(p.photo_kinds),
            'staged', (select coalesce(jsonb_agg(f.kind order by f.kind), '[]'::jsonb)
                       from public.shop_product_photos f
                       where f.shop_id = p.shop_id and f.product_key = p.product_key)))
        from (select * from public.shop_products x where x.shop_id = v_device.shop_id order by x.product_key limit 10000) as p
    ), '[]'::jsonb);
end;
$$;

-- The shop PC takes a product back that is no longer fit to offer (its photos were removed at the shop, say), if the
-- owner has not decided on it yet.
create or replace function public.withdraw_shop_product(p_key text, p_product text)
returns void
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;
    perform public.require_main_pc(v_device.id, v_device.shop_id);

    delete from public.shop_products x
    where x.shop_id = v_device.shop_id and x.product_key = coalesce(p_product, '') and x.state in ('sending', 'waiting');
end;
$$;

-- The owner decides, on the website: the product is published there, or declined. Its photos are dropped here at once.
create or replace function public.decide_shop_product(p_shop uuid, p_product text, p_state text)
returns void
language plpgsql
volatile
security definer
set search_path = ''
as $$
begin
    if not public.sign_in_strong_enough() then
        raise exception 'Enter the code from your authenticator app first.';
    end if;
    if not public.is_shop_member(p_shop, array['owner']) then
        raise exception 'Only the shop''s owner can decide on the products.';
    end if;
    if coalesce(p_state, '') not in ('published', 'declined') then
        raise exception 'Decide on the product: published or declined.';
    end if;

    update public.shop_products x set state = p_state, decided_at = now()
    where x.shop_id = p_shop and x.product_key = coalesce(p_product, '') and x.state = 'waiting';
    if not found then
        raise exception 'That product is not waiting for a decision.';
    end if;
    delete from public.shop_product_photos f where f.shop_id = p_shop and f.product_key = p_product;
end;
$$;

revoke all on function public.send_shop_product(text, text, jsonb, text, text, text[], boolean) from public;
revoke all on function public.send_shop_product_photo(text, text, text, text, text, text) from public;
revoke all on function public.get_shop_product_states(text) from public;
revoke all on function public.withdraw_shop_product(text, text) from public;
revoke all on function public.decide_shop_product(uuid, text, text) from public, anon;
grant execute on function public.send_shop_product(text, text, jsonb, text, text, text[], boolean) to anon, authenticated;
grant execute on function public.send_shop_product_photo(text, text, text, text, text, text) to anon, authenticated;
grant execute on function public.get_shop_product_states(text) to anon, authenticated;
grant execute on function public.withdraw_shop_product(text, text) to anon, authenticated;
grant execute on function public.decide_shop_product(uuid, text, text) to authenticated;

-- The website's categories, for the shop PC: a product on the website needs one. The website's admin sends its list
-- here (signed in as the owner), and the shop PC reads it with its key, to choose each product's category from it.
create table if not exists public.site_categories (
    shop_id uuid primary key references public.shops (id) on delete cascade,
    categories jsonb not null,
    updated_at timestamptz not null default now()
);

alter table public.site_categories enable row level security;

drop policy if exists "The owner sees the website's categories" on public.site_categories;
create policy "The owner sees the website's categories" on public.site_categories
    for select to authenticated using ((select public.is_shop_member(shop_id, array['owner'])));

revoke all on public.site_categories from anon, authenticated;
grant select on public.site_categories to authenticated;

-- The owner's website sends its categories: up to 1,000, each with an id, a name and the id of its main category
-- (null for a main category). Only those three things are kept.
create or replace function public.save_site_categories(p_shop uuid, p_categories jsonb)
returns void
language plpgsql
volatile
security definer
set search_path = ''
as $$
begin
    if not public.sign_in_strong_enough() then
        raise exception 'Enter the code from your authenticator app first.';
    end if;
    if not public.is_shop_member(p_shop, array['owner']) then
        raise exception 'Only the shop''s owner can send the website''s categories.';
    end if;
    if p_categories is null or jsonb_typeof(p_categories) <> 'array' or jsonb_array_length(p_categories) not between 1 and 1000
       or octet_length(p_categories::text) > 262144 then
        raise exception 'The categories are missing or too many.';
    end if;
    if exists (
        select 1
        from jsonb_array_elements(p_categories) as c
        where jsonb_typeof(c) <> 'object'
           or coalesce(jsonb_typeof(c -> 'id'), '') <> 'string' or char_length(c ->> 'id') not between 1 and 64
           or coalesce(jsonb_typeof(c -> 'name'), '') <> 'string' or char_length(btrim(c ->> 'name')) not between 1 and 120
           or coalesce(jsonb_typeof(c -> 'parentId'), 'null') not in ('null', 'string')
           or (jsonb_typeof(c -> 'parentId') = 'string' and char_length(c ->> 'parentId') not between 1 and 64)
    ) then
        raise exception 'The categories are not as expected: each needs an id and a name.';
    end if;

    insert into public.site_categories (shop_id, categories, updated_at)
    select p_shop,
           jsonb_agg(jsonb_build_object('id', c.value ->> 'id', 'name', btrim(c.value ->> 'name'), 'parentId', c.value -> 'parentId') order by c.ordinality),
           now()
    from jsonb_array_elements(p_categories) with ordinality as c (value, ordinality)
    on conflict (shop_id) do update set categories = excluded.categories, updated_at = excluded.updated_at;
end;
$$;

-- The shop PC reads them with its key: null until the website has sent them.
create or replace function public.get_site_categories(p_key text)
returns jsonb
language plpgsql
volatile
security definer
set search_path = ''
as $$
declare
    v_device public.shop_devices;
    v_row public.site_categories;
begin
    select * into v_device
    from public.shop_devices
    where key_hash = encode(extensions.digest(coalesce(p_key, ''), 'sha256'), 'hex');
    if not found then
        raise exception 'This shop PC is not connected: it may have been disconnected on the website.' using errcode = '28000';
    end if;

    select * into v_row from public.site_categories c where c.shop_id = v_device.shop_id;
    if not found then
        return null;
    end if;
    return jsonb_build_object('updated_at', v_row.updated_at, 'categories', v_row.categories);
end;
$$;

revoke all on function public.save_site_categories(uuid, jsonb) from public, anon;
revoke all on function public.get_site_categories(text) from public;
grant execute on function public.save_site_categories(uuid, jsonb) to authenticated;
grant execute on function public.get_site_categories(text) to anon, authenticated;

-- The website shows new figures, reports and answers the moment they arrive.
do $$
declare
    v_table text;
begin
    if exists (select 1 from pg_publication where pubname = 'supabase_realtime') then
        foreach v_table in array array['shop_live', 'shop_questions', 'shop_reports', 'shop_products'] loop
            if not exists (select 1 from pg_publication_tables
                           where pubname = 'supabase_realtime' and schemaname = 'public' and tablename = v_table) then
                execute format('alter publication supabase_realtime add table public.%I', v_table);
            end if;
        end loop;
    end if;
end;
$$;
