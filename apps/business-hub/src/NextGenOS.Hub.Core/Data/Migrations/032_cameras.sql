-- Version 2, Phase 7, step 1: the register of the shop's cameras. NEW TABLE ONLY; nothing that exists is changed.
-- A row says where a camera is (its kind, its address on the shop's own network, the place it looks at on the business map), what it may look for (a short closed list: people, trolleys, baskets,
-- products; never faces) and how sure the program must be before it counts something; and whether the owner has switched that camera on. A camera is off until the owner switches it on, and this
-- step does nothing with a camera that is on: it reads no picture and no video (that comes later, one step at a time). The camera's password is NOT here: it is in the computer's secret store,
-- under the name "camera/<id>". Every table carries tenant_id and site_id. The way back is Data/Rollbacks/032_cameras.sql.

CREATE TABLE cameras (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  ref TEXT NOT NULL, name TEXT NOT NULL, kind TEXT NOT NULL, address TEXT NOT NULL, zone_ref TEXT,
  classes TEXT NOT NULL, min_confidence INTEGER NOT NULL, enabled INTEGER NOT NULL DEFAULT 0,
  checked_at TEXT, check_status TEXT, check_note TEXT,
  created_at TEXT NOT NULL, created_by INTEGER, updated_at TEXT NOT NULL, updated_by INTEGER, retired_at TEXT,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE UNIQUE INDEX ux_cameras_ref ON cameras(tenant_id, site_id, ref);
