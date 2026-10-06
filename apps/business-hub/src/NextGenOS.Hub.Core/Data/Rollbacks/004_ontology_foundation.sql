-- The way back from 004_ontology_foundation.sql: drops only the tables that migration made (in the opposite order). Used by HubDb.Rollback, which copies the database first.
DROP INDEX IF EXISTS ix_ontology_to;
DROP INDEX IF EXISTS ix_ontology_from;
DROP INDEX IF EXISTS ix_ontology_live;
DROP TABLE IF EXISTS ontology_relationships;
DROP TABLE IF EXISTS ontology_entities;
DROP TABLE IF EXISTS ontology_relation_types;
DROP TABLE IF EXISTS ontology_entity_types;
