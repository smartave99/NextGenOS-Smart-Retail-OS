-- Version 2, Phase 4, step 1: finding "what is true now" about one thing or one place in the business event history. NEW INDEXES ONLY; no table, column or row is changed or removed.
-- Without them, asking for everything the history knows about 'item:12' or 'zone:entrance' reads every event; with them it reads only that thing's events, newest first.
-- Each index starts with tenant_id and site_id like every other, so one shop's questions never read another's rows.
-- The way back is Data/Rollbacks/028_event_subject_index.sql.

CREATE INDEX ix_events_subject ON events(tenant_id, site_id, subject_ref, occurred_at);
CREATE INDEX ix_events_zone ON events(tenant_id, site_id, zone_ref, occurred_at);
