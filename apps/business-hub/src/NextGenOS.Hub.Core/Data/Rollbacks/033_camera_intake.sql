-- The way back from 033_camera_intake.sql: drops the one table that step made, with the key fingerprints in it (a camera program then has to be given a new key if the step is applied again). Nothing of
-- the shop's own records is touched, and neither are the cameras (032) or the observations already written to the event history. Used by HubDb.Rollback, which copies the database first.
DROP TABLE IF EXISTS camera_intake_keys;
