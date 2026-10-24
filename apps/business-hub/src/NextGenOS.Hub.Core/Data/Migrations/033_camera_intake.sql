-- Version 2, Phase 7, step 2: the key a camera program uses to send what it saw. NEW TABLE ONLY; nothing that exists is changed.
-- A camera that the owner has registered (032_cameras.sql) can be given one key. A separate program on this same computer that reads that camera sends the key with what it saw (counts of people,
-- trolleys, baskets and products, never a picture and never a face), and the Hub writes it into the business event history as observations. Only a fingerprint (SHA-256) of the key is kept here:
-- the key itself is shown to the owner once, when it is made, and cannot be read back. Removing the key, or retiring the camera, deletes the row. The counters say how much the camera program has
-- sent, so the owner can see that it works. Every table carries tenant_id and site_id. The way back is Data/Rollbacks/033_camera_intake.sql.

CREATE TABLE camera_intake_keys (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', camera_id INTEGER NOT NULL,
  key_hash TEXT NOT NULL, created_at TEXT NOT NULL, created_by INTEGER,
  last_used_at TEXT, accepted_total INTEGER NOT NULL DEFAULT 0, rejected_total INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (tenant_id, site_id, camera_id));
