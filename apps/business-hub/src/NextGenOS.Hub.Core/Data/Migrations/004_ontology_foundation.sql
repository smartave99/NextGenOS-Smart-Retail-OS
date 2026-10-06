-- Version 2, phase 3: the business map (the ontology). NEW TABLES ONLY: nothing that exists is changed, and the shop's own records (products, parties, documents, payments, people,
-- tables, projects) are NOT copied into it: they stay where they are and are read in place. Only what has no table of its own is kept here: places (a site, a zone, a shelf) and
-- devices (a camera, a sensor), and the connections between things. Connections are data, with the day they began and the day they ended: an ended connection stays in the history.
-- Every table carries tenant_id and site_id ('local', 'main'). The way back is Data/Rollbacks/004_ontology_foundation.sql.

-- The kinds of thing the business map knows. "mapped" kinds are records the shop already has (read in place); "native" kinds live only here. The built-in ones are written by the
-- program the first time the map is used; the owner may add native kinds.
CREATE TABLE ontology_entity_types (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  name TEXT NOT NULL, label TEXT NOT NULL, kind TEXT NOT NULL CHECK (kind IN ('mapped', 'native')), data_class TEXT NOT NULL,
  builtin INTEGER NOT NULL DEFAULT 0 CHECK (builtin IN (0, 1)),
  PRIMARY KEY (tenant_id, site_id, name));

-- The kinds of connection, and which kinds of thing each may join. "derived" connections are worked out from the shop's own records (a payment settles a bill) and are never stored.
CREATE TABLE ontology_relation_types (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  name TEXT NOT NULL, label TEXT NOT NULL, from_types TEXT NOT NULL, to_types TEXT NOT NULL,
  derived INTEGER NOT NULL DEFAULT 0 CHECK (derived IN (0, 1)), builtin INTEGER NOT NULL DEFAULT 0 CHECK (builtin IN (0, 1)),
  PRIMARY KEY (tenant_id, site_id, name));

-- Places and devices: things that have no table of their own. key is a short plain name ("aisle-3"); a retired thing stays, marked.
CREATE TABLE ontology_entities (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main',
  type TEXT NOT NULL, key TEXT NOT NULL, name TEXT NOT NULL, attributes TEXT,
  created_at TEXT NOT NULL, created_by INTEGER, retired_at TEXT,
  PRIMARY KEY (tenant_id, site_id, type, key));

-- A connection between two things, by reference ("zone:aisle-3", "product:12"). Ended, never deleted. At most one live connection of a kind between the same two things.
CREATE TABLE ontology_relationships (
  tenant_id TEXT NOT NULL DEFAULT 'local', site_id TEXT NOT NULL DEFAULT 'main', id INTEGER NOT NULL,
  type TEXT NOT NULL, from_ref TEXT NOT NULL, to_ref TEXT NOT NULL, attributes TEXT,
  source TEXT NOT NULL CHECK (source IN ('person', 'rule', 'system', 'import')),
  valid_from TEXT NOT NULL, valid_to TEXT, created_by INTEGER, ended_by INTEGER,
  PRIMARY KEY (tenant_id, site_id, id));
CREATE UNIQUE INDEX ix_ontology_live ON ontology_relationships(tenant_id, site_id, type, from_ref, to_ref) WHERE valid_to IS NULL;
CREATE INDEX ix_ontology_from ON ontology_relationships(tenant_id, site_id, from_ref);
CREATE INDEX ix_ontology_to ON ontology_relationships(tenant_id, site_id, to_ref);
