-- One sale per request (blueprint item NET-007, invariant 1). A till, a counter PC or a retry can send the same request twice (a double tap, a network that dropped after the main PC had already saved the sale).
-- The request carries a key; the bill keeps it; asking again with the same key gives back the bill that was made the first time and makes nothing new (no second payment, no second stock move).
-- NEW COLUMN and a unique index only; nothing that exists is changed. Bills made before this step have no key. The way back is Data/Rollbacks/012_request_key.sql.
ALTER TABLE documents ADD COLUMN request_key TEXT;
CREATE UNIQUE INDEX ux_documents_request_key ON documents(request_key) WHERE request_key IS NOT NULL;
