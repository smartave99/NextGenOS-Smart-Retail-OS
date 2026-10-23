-- The way back from 032_cameras.sql: drops the one table that step made, with the cameras in it. Nothing of the shop's own records is touched. The cameras' passwords are in the secret store and are
-- not touched by this file (the program deletes a camera's password when the camera is retired). Used by HubDb.Rollback, which copies the database first (so the cameras are in that copy).
DROP INDEX IF EXISTS ux_cameras_ref;
DROP TABLE IF EXISTS cameras;
