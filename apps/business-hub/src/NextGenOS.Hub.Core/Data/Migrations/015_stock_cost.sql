-- Stock cost (docs/PLATFORM-DECISIONS.md decision 36: the cost of an item is the average of what was paid, worked out again at each purchase; blueprint ticket FIN-003).
-- NEW COLUMN ONLY on a table that exists, and one opening row for each item that already has stock; nothing that exists is changed or removed.
--   stock_moves.value_minor   what the move was worth in money, signed like its quantity (stock in is positive, stock out is negative). Null on a move made before this step: its value is
--                             not known and is not made up. What an item holds is the sum of its moves, and so is what it is worth; the average cost is the one divided by the other.
-- Stock that is already on the shelves is given its value once, as a move of no quantity ("valuation") worth the quantity on hand times the item's cost price, half-up (the rule the stock
-- report always used). The books take it in as an opening entry against "Opening balances" (decision 32), so old bills are never re-posted or worked out again.
-- The way back is Data/Rollbacks/015_stock_cost.sql.

ALTER TABLE stock_moves ADD COLUMN value_minor INTEGER;

INSERT INTO stock_moves(item_id, qty_milli, reason, note, at, value_minor)
SELECT i.id, 0, 'valuation', 'The value of the stock when its cost began to be kept', strftime('%Y-%m-%dT%H:%M:%SZ', 'now'), (2 * q.on_hand * i.cost_minor + 1000) / 2000
FROM items i JOIN (SELECT item_id, SUM(qty_milli) AS on_hand FROM stock_moves GROUP BY item_id) q ON q.item_id = i.id
WHERE i.track_stock = 1 AND q.on_hand > 0 AND i.cost_minor > 0;
