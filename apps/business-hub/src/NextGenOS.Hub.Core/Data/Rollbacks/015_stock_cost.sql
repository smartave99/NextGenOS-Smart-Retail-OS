-- The way back from 015_stock_cost.sql: takes away the value of the moves, the opening rows that step made, and the books' entries that are made from them (what the shop's stock cost and
-- what its sales cost), because without the values those entries could not be made again. The bills, payments and stock quantities are untouched, and so are all the other entries of the
-- books. This is the only place that removes entries from the books, and it removes only entries made from stock values. Used by HubDb.Rollback, which copies the database first.
DROP TRIGGER IF EXISTS journal_lines_no_delete;
DROP TRIGGER IF EXISTS journal_entries_no_delete;
DELETE FROM journal_lines WHERE entry_id IN (SELECT id FROM journal_entries WHERE source IN ('stock-sale', 'stock-return', 'stock-purchase', 'stock-void', 'stock-move'));
DELETE FROM journal_entries WHERE source IN ('stock-sale', 'stock-return', 'stock-purchase', 'stock-void', 'stock-move');
CREATE TRIGGER journal_entries_no_delete BEFORE DELETE ON journal_entries BEGIN SELECT RAISE(ABORT, 'The books cannot be changed. Put a mistake right with a new entry.'); END;
CREATE TRIGGER journal_lines_no_delete BEFORE DELETE ON journal_lines BEGIN SELECT RAISE(ABORT, 'The books cannot be changed. Put a mistake right with a new entry.'); END;
DELETE FROM accounts WHERE role IN ('stock', 'cogs', 'stock-adjust') AND NOT EXISTS (SELECT 1 FROM journal_lines l WHERE l.account_id = accounts.id);
DELETE FROM stock_moves WHERE reason = 'valuation' AND qty_milli = 0;
ALTER TABLE stock_moves DROP COLUMN value_minor;
