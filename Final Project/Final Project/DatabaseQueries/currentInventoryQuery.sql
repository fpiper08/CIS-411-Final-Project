SELECT I.ItemCode, I.ItemName, I.Quantity, T.UnitCost, T.Supplier
FROM Inventory I
INNER JOIN Items T ON T.ItemCode = I.ItemCode;

